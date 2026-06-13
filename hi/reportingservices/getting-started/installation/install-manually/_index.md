---
title: मैन्युअली स्थापित करें
type: docs
weight: 30
url: /hi/reportingservices/install-manually/
---
{{% alert color="primary" %}} 

यदि आप Aspose.Slides for Reporting Services को मैन्युअल रूप से स्थापित करने की योजना बना रहे हैं तो ही इन चरणों का पालन करें। इस स्थिति में, आपने असेंबली फ़ाइलों वाले ZIP पैकेज को डाउनलोड किया है। 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** को होस्ट मशीन पर **.NET Framework 3.5** की स्थापना की आवश्यकता है। 

{{% /alert %}}

### **मैन्युअल इंस्टॉलेशन**
ये निर्देश बताते हैं कि आप Microsoft SQL Server Reporting Services स्थापित होने वाली निर्देशिका में फ़ाइलों को कैसे कॉपी और संशोधित कर सकते हैं:

1. रिपोर्ट सर्वर की इंस्टॉलेशन डायरेक्टरी खोजें।  
   Microsoft SQL Server की रूट डायरेक्टरी आमतौर पर यहाँ होती है: ***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 and 2008**: मशीन पर कई Microsoft SQL Server इंस्टेंस कॉन्फ़िगर किए जा सकते हैं और वे अलग‑अलग MSSQL.x सबडायरेक्टरी जैसे MSSQL.1, MSSQL.2 आदि में हो सकते हैं। आपको अगला चरण करने से पहले सही ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** डायरेक्टरी ढूँढ़नी होगी।  
   
   {{% /alert %}} नीचे उपयोग किए जाने वाले सभी पाथ इस डायरेक्टरी को <Instance> के रूप में संदर्भित करेंगे। 

2. Aspose.Slides.ReportingServices.dll को **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin** फ़ोल्डर में कॉपी करें।  
   डाउनलोड की गई **Aspose.Slides.ReportingServices.zip** में **Aspose.Slides.ReportingServices.dll** शामिल है। {{% alert color="primary" %}} 

कुछ मामलों में, जब आप DLL को **ReportServer\bin** डायरेक्टरी में कॉपी करते हैं, तो यह उस पर असाइन की गई स्पष्ट NTFS फ़ाइल अनुमतियों के साथ भी कॉपी हो सकता है। NTFS अनुमतियों के कारण Microsoft SQL Server Reporting Services को **Aspose.Slides.ReportingServices.dll** लोड करने पर पहुंच से वंचित किया जाता है। यदि ऐसा होता है, तो नए एक्सपोर्ट फॉर्मैट उपलब्ध नहीं होंगे। सुनिश्चित करें कि सही NTFS अनुमतियां मौजूद हैं :

   1. **Aspose.Slides.ReportingServices.dll** पर राइट‑क्लिक करें।  
   1. **Properties** पर क्लिक करें और **Security** टैब चुनें।  
   1. किसी भी स्पष्ट रूप से असाइन किए गए NTFS परमिशन को निकालें और केवल इनहेरिटेड परमिशन रखें।  

{{% /alert %}}

3. Aspose.Slides for Reporting Services को रेंडरिंग एक्सटेंशन के रूप में रजिस्टर करें:  
   1. *C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config* खोलें।  
   1. <Render> तत्व में इन लाइनों को जोड़ें :  

**<Render>**

``` xml

   ...

  <!--यहाँ से शुरू करें।-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--यहाँ समाप्त करें।-->

</Render>



```

4. Aspose.Slides for Reporting Services को निष्पादित करने की अनुमति दें:  
   1. **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config** खोलें।  
   1. नीचे दिया गया कोड दूसरे बाहरी <CodeGroup> तत्व के अंत में जोड़ें (जो इस प्रकार होना चाहिए: <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">)।  

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--यहाँ से शुरू करें।-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="This code group grants full trust to the AS4SSRS assembly.">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

            PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--यहाँ समाप्त करें।-->

  </CodeGroup>

</CodeGroup>



```

5. पुष्टि करें कि Aspose.Slides for Reporting Services सफलतापूर्वक स्थापित हो गया है:  
   1. Report Manager खोलें और रिपोर्ट के लिए उपलब्ध एक्सपोर्ट प्रकारों की सूची जांचें।  
   
   {{% alert color="primary" %}} आप एक ब्राउज़र (Microsoft Internet Explorer 6.0 या बाद वाला) खोलकर और एड्रेस बार में Report Manager URL टाइप करके Report Manager लॉन्च कर सकते हैं (डिफ़ॉल्ट रूप से यह http://< ComputerName >/Reports है)।  
   
   {{% /alert %}}

   1. सर्वर पर एक रिपोर्ट चुनें।  
   1. **Select Format** सूची खोलें।  
      आपको Aspose.Slides for Reporting Services द्वारा प्रदान किए गए एक्सपोर्ट फॉर्मैट की सूची दिखनी चाहिए।  
   1. **PPT – PowerPoint Presentation via Aspose.Slides** चुनें।  

   **Aspose.Slides for Reporting Services सफलतापूर्वक स्थापित हो गया है और नए एक्सपोर्ट फॉर्मैट उपलब्ध हैं।**  

![todo:image_alt_text](install-manually_1.png)




6. **Export** लिंक पर क्लिक करें।  
   रिपोर्ट चयनित फॉर्मैट में जेनरेट होती है, क्लाइंट को भेजी जाती है, और फिर उपयुक्त एप्लिकेशन में खोली जाती है। हमारे मामले में, रिपोर्ट Microsoft PowerPoint में खोली गई थी।  

   **Aspose.Slides for Reporting Services द्वारा उत्पन्न PPT रिपोर्ट।**  

![todo:image_alt_text](install-manually_2.png)

आपने Aspose.Slides for Reporting Services को सफलतापूर्वक स्थापित कर लिया है और Microsoft PowerPoint प्रस्तुतिकरण के रूप में रिपोर्ट जेनरेट की है!