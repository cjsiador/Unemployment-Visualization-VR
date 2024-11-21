using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    private DataAttributes _dataAttributes;
    public DataAttributes dataAttributes
    {
        get { return dataAttributes; }
        set { _dataAttributes = value;}
    }

    public void ChangeDataAttributes()
    {
        switch (_dataAttributes)
        {
            case DataAttributes.TotalCivilianNonInstitutionalPopulationInState:
                Debug.Log("Change to NonInstitutional Population");
                break;
            case DataAttributes.TotalCivilianLaborforceInState:
                Debug.Log("Change to Total CivilianLaborforce in State");
                break;
            case DataAttributes.TotalEmploymentInState:
                Debug.Log("Change to Total Employment in State");
                break;
            case DataAttributes.TotalUnemploymentInState:
                break;
        }
    }
}



public enum DataAttributes
{
    TotalCivilianNonInstitutionalPopulationInState,
    TotalCivilianLaborforceInState,
    TotalEmploymentInState,
    TotalUnemploymentInState,

}
