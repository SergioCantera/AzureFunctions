using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSFFIntegration.Models
{
    public class LearningPlan
    {
        public List<Course> value { get; set; }
    }

    public class Course
    {
        public string sku { get; set; }
        public string cpnt_classification { get; set; }
        public bool isUserRequestsEnabled { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string userID { get; set; }
        public string personGUID { get; set; }
        public string personExternalID { get; set; }
        public string componentTypeID { get; set; }
        public string componentTypeDesc { get; set; }
        public string componentID { get; set; }
        public int componentKey { get; set; }
        public double componentLength { get; set; }
        public object contactHours { get; set; }
        public object creditHours { get; set; }
        public object cpeHours { get; set; }
        public object revisionDate { get; set; }
        public object assignedDate { get; set; }
        public bool availableNewRevision { get; set; }
        public string revisionNumber { get; set; }
        public object requiredDate { get; set; }
        public int? daysRemaining { get; set; }
        public string addUser { get; set; }
        public string addUserName { get; set; }
        public string addUserTypeLabelID { get; set; }
        public object orderItemID { get; set; }
        public object usedOrderTicketNumber { get; set; }
        public object usedOrderTicketSequence { get; set; }
        public bool onlineLaunched { get; set; }
        public string origin { get; set; }
        public object cdpGoalID { get; set; }
        public int seqNumber { get; set; }
        public object scheduleID { get; set; }
        public object qualificationID { get; set; }
        public object rootQualificationID { get; set; }
        public object qualTitle { get; set; }
        public bool isRequired { get; set; }
        public object orderItemStatusTypeID { get; set; }
        public bool showInCatalog { get; set; }
        public string requirementTypeDescription { get; set; }
        public string requirementTypeId { get; set; }
        public bool hasOnlinePart { get; set; }
        public object itemDetailsDeeplink { get; set; }
        public object courseDeeplink { get; set; }
        public object criteria { get; set; }
        public List<object> linkedSchedules { get; set; }
        public object programType { get; set; }
        public object programEndDate { get; set; }
        public object programStartDate { get; set; }
        public object programDuration { get; set; }
        public object programDurationType { get; set; }
        public object programDeeplink { get; set; }
        public object vlsLink { get; set; }
        public object studentSurveyID { get; set; }
        public object itemSurveyID { get; set; }
        public object surveyID { get; set; }
        public object surveyLevel { get; set; }
        public object surveydesc { get; set; }
        public object surveyStatusID { get; set; }
        public object surveyDeepLink { get; set; }
        public List<object> learnerActions { get; set; }
        public object embeddableDeeplink { get; set; }
    }
}
