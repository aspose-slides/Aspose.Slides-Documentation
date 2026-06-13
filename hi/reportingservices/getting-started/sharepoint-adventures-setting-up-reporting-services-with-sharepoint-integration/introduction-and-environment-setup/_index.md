---
title: परिचय और पर्यावरण सेटअप
type: docs
weight: 10
url: /hi/reportingservices/introduction-and-environment-setup/
---
{{% alert color="primary" %}}

पहले Aspose.Slides को Reporting Services के साथ SharePoint एकीकरण के संबंध में कुछ प्रश्न पूछे गए थे। इस लेख में हम SharePoint 2010 पर ध्यान केंद्रित करेंगे। यह माना जाता है कि आपके पास पहले से ही एक SharePoint Farm पर्यावरण स्थापित है। इस लेख में हम जिन उदाहरणों का पालन करेंगे वे एक पूर्ण SharePoint Cloud होंगे, लेकिन चरण SharePoint Foundation Server के लिए समान होंगे। आगे बढ़ने से पहले, आइए कुछ प्रमुख दस्तावेज़ों के साथ शुरू करते हैं जिन्हें आप इस काम के लिए संदर्भ के रूप में उपयोग कर सकते हैं:

- [Reporting Services और SharePoint तकनीक एकीकरण का अवलोकन](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [SharePoint 2010 एकीकरण के लिए Reporting Services को कॉन्फ़िगर करना](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}}
#### **पर्यावरण सेटअप**
जो सेटअप हम बना रहे हैं वह **4 सर्वर** से मिलकर बना है। इसमें एक **डोमेन कंट्रोलर**, एक **SQL Server**, एक **SharePoint Server** और **Reporting Services** के लिए एक सर्वर शामिल है। आप SharePoint और Reporting Services को एक ही बॉक्स पर रख सकते हैं।