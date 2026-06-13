---
title: Visual Studio 2005 या 2008 Report Designer के साथ मैन्युअली एकीकृत करना
type: docs
weight: 50
url: /hi/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---
{{% alert color="primary" %}} 
यह लेख आपको Aspose.Slides for Reporting Services को Visual Studio के साथ मैन्युअल रूप से एकीकृत करने का तरीका सिखाता है। 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 
**Aspose.Slides for Reporting Services** को होस्ट मशीन पर **.NET Framework 3.5** की स्थापना आवश्यक है। 
{{% /alert %}}

## **Aspose.Slides for Reporting Services को Visual Studio के साथ एकीकृत करना**
हम अनुशंसा करते हैं कि आप Aspose.Slides for Reporting Services को स्थापित करने के लिए MSI इंस्टॉलर का उपयोग करें क्योंकि यह सभी आवश्यक स्थापना कार्य और कॉन्फ़िगरेशन प्रक्रियाएँ स्वचालित रूप से करता है। हालांकि, यदि MSI इंस्टॉलर के साथ स्थापना विफल हो जाती है, तो यहाँ दिए गए मार्गदर्शन का उपयोग करें। 

यह लेख यह भी दर्शाता है कि Business Intelligence Development Studio वाले कंप्यूटर पर Aspose.Slides for Reporting Services को कैसे स्थापित किया जाए। यह आपको Microsoft Visual Studio 2005 या 2008 Report Designer से डिजाइन समय पर रिपोर्ट को Microsoft PowerPoint स्वरूपों में निर्यात करने में सक्षम बनाएगा। 

1. Aspose.Slides.ReportingServices.dll को Visual Studio निर्देशिका में कॉपी करें।

   - Visual Studio 2005 Report Designer के साथ एकीकृत करने के लिए, **Aspose.Slides.ReportingServices.dll** को **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies** निर्देशिका में कॉपी करें।
   - Visual Studio 2008 Report Designer के साथ एकीकृत करने के लिए, **Aspose.Slides.ReportingServices.dll** को **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** निर्देशिका में कॉपी करें।
2. Aspose.Slides for Reporting Services को एक रेंडरिंग एक्सटेंशन के रूप में पंजीकृत करें। 

3. **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config** खोलें (जहाँ <Version> Visual Studio 2005 के लिए “8” या Visual Studio 2008 के लिए “9.0” है) और इन पंक्तियों को <Render> तत्व में जोड़ें: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. Aspose.Slides for Reporting Services को निष्पादन की अनुमति दें। 
   1. **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** खोलें (जहाँ <Version> Visual Studio 2005 के लिए “8” या Visual Studio 2008 के लिए “9.0” है)।
   1. इस पंक्ति को दूसरे से बाहरी <CodeGroup> तत्व के अंतिम आइटम के रूप में जोड़ें (जो इस प्रकार होना चाहिए <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission.">) 

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--यहाँ शुरू करें।-->

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

5. सुनिश्चित करें कि Aspose.Slides for Reporting Services सफलतापूर्वक स्थापित हो गया है। 
6. Microsoft Visual Studio 2005 या 2008 Report Designer चलाएँ या पुनरारंभ करें। आपको निर्यात फ़ॉर्मेट की सूची में नए स्वरूप दिखाई देंगे। 

**Report Designer में नए निर्यात स्वरूप दिखाई देते हैं।** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)