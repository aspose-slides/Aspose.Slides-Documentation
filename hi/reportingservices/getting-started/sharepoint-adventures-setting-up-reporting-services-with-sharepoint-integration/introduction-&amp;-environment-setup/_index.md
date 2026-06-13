---
title: परिचय & पर्यावरण सेटअप
type: docs
weight: 10
url: /hi/reportingservices/introduction-&-environment-setup/
---
{{% alert color="primary" %}}

पहले Aspose.Slides के Reporting Services एकीकरण को SharePoint के साथ लेकर पूछताछ हुई है। इस लेख में, हम SharePoint 2010 पर ध्यान केंद्रित करेंगे। यह मान लिया गया है कि SharePoint Farm पर्यावरण पहले से सेट अप है। इस लेख में हम जिन उदाहरणों का पालन करेंगे, वे एक पूर्ण SharePoint क्लाउड पर हैं, लेकिन चरण SharePoint Foundation Server के लिए भी समान होंगे। आगे बढ़ने से पहले, चलिए कुछ प्रमुख दस्तावेज़ों से शुरू करते हैं जिन्हें आप संदर्भ के लिए उपयोग कर सकते हैं:

- [Reporting Services और SharePoint प्रौद्योगिकी एकीकरण का अवलोकन](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [SharePoint 2010 एकीकरण के लिए Reporting Services को कॉन्फ़िगर करना](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}}
#### **पर्यावरण सेटअप**
हमारी सेटअप में **4 सर्वर** शामिल हैं। इसमें एक **Domain Controller**, एक **SQL Server**, एक **SharePoint Server** और **Reporting Services** के लिए एक सर्वर शामिल है। आप SharePoint और Reporting Services को एक ही बॉक्स पर रखने का विकल्प चुन सकते हैं।