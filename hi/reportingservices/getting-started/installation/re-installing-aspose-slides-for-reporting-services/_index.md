---
title: Aspose.Slides for Reporting Services को पुनः इंस्टॉल करना
type: docs
weight: 40
url: /hi/reportingservices/re-installing-aspose-slides-for-reporting-services/
---
{{% alert color="primary" %}} 
यह लेख उस स्थिति के समाधान का वर्णन करता है जिसमें Aspose.Slides for Reporting Services पहले से स्थापित है, लेकिन किसी कारणवश इसे पुनः स्थापित करना आवश्यक है।
{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 
**Aspose.Slides for Reporting Services** को होस्ट मशीन पर **.NET Framework 3.5** की स्थापना की आवश्यकता होती है। 
{{% /alert %}}

## **Aspose.Slides for Reporting Services को पुनः स्थापित करने के चरण**
सबसे महत्वपूर्ण बात यह है कि पहले की सभी Aspose.Slides for Reporting Services स्थापितियों को पूरी तरह हटाया जाए। जबकि MSI इंस्टॉलर स्वचालित रूप से अनइंस्टॉल और फिर Aspose.Slides for Reporting Services को पुनः स्थापित करने के लिए आवश्यक कार्य सफलतापूर्वक कर सकता है, इन चरणों का पालन करना आवश्यक है:

1. MSI इंस्टॉलर का उपयोग करके Aspose.Slides for Reporting Services को अनइंस्टॉल करें। 

2. Aspose.Slides for Reporting Services की स्थापना निर्देशिका खोजें, जो सामान्यतः यहाँ स्थित होती है:

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3. यदि MSI इंस्टॉलर ने Aspose.Slides for Reporting Services को अनइंस्टॉल करते समय “Aspose.Slides for Reporting Services” निर्देशिका नहीं हटाई है, तो फ़ोल्डर को हटाएँ। 

4. प्रत्येक SQL Server Reporting Service इंस्टेंस के “bin” निर्देशिका में **Aspose.Slides.ReportingServices.dll** बाइनरी खोजें। उदाहरण के लिए, यदि Microsoft SQL Server 2008 इंस्टेंस “MSSQLSERVER” है, तो संबंधित Reporting Service “bin” निर्देशिका संभवतः यहाँ होगी: 

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. यदि MSI इंस्टॉलर ने Aspose.Slides for Reporting Services को अनइंस्टॉल करते समय उपरोक्त निर्देशिका से Aspose.Slides.ReportingServices.dll बाइनरी फ़ाइल नहीं हटाई है, तो अब फ़ाइल को हटाएँ।

6. प्रत्येक SSRS इंस्टेंस के लिए **rsreportserver.config** फ़ाइल खोजें। उदाहरण के लिए, यदि Reporting Service इंस्टेंस “**MSRS10.MSSQLSERVER**” है, तो **rsreportserver.config** फ़ाइल इस निर्देशिका में होगी:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. किसी भी एडिटर में **rsreportserver.config** फ़ाइल खोलें और उन पंक्तियों को खोजें जो Aspose.Slides for Reporting Services की स्थापना के दौरान PowerPoint Format Extensions जोड़ने के लिए बनाई गई थीं। 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

**Step** **8:** यदि MSI इंस्टॉलर ने Aspose.Slides for Reporting Services को अनइंस्टॉल करते समय उन पंक्तियों को नहीं हटाया है, तो अब **rsreportserver.config** फ़ाइल से उन पंक्तियों को हटाएँ। 

**Step** **9:** प्रत्येक SSRS इंस्टेंस के लिए **rssrvpolicy.config** फ़ाइल खोजें। उदाहरण के लिए, यदि Reporting Service इंस्टेंस “MSRS10.MSSQLSERVER” है, तो **rssrvpolicy.config** फ़ाइल इस निर्देशिका में होगी:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Step** **10:** किसी भी एडिटर में **rssrvpolicy.config** फ़ाइल खोलें और उन पंक्तियों को खोजें जो Aspose.Slides for Reporting Services की स्थापना के दौरान इसे निष्पादन अनुमति देने के लिए बनाई गई थीं। 

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

**Step** **11:** यदि MSI इंस्टॉलर ने उत्पाद को अनइंस्टॉल करते समय उपरोक्त पंक्तियों को नहीं हटाया, तो अब **rssrvpolicy.config** फ़ाइल से उन पंक्तियों को हटा दें। 

**Step** **12:** यदि Aspose.Slides for Reporting Services को Microsoft Visual Studio के साथ RDL रिपोर्ट विकास और Microsoft Visual Studio वातावरण में PowerPoint फ़ॉर्मेट निर्यात के लिए भी स्थापित किया गया था, तो Microsoft Visual Studio 2008 के मामले में बाइनरी फ़ाइल Aspose.Slides.ReportingServices.dll और कॉन्फ़िगरेशन फ़ाइलें (**rsreportserver.config** और **rssrvpolicy.config**) इस स्थान पर होगी:

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Step** **13:** यदि MSI इंस्टॉलर ने **Aspose.Slides.ReportingServices.dll** बाइनरी को नहीं हटाया, तो उसे हटाएँ। अतिरिक्त रूप से, यदि उसने **rsreportserver.config** और **rssrvpolicy.config** फ़ाइलों को क्रमशः PowerPoint Format Extensions और कोड निष्पादन अनुमतियों को हटाने के लिए अपडेट नहीं किया, तो आपको उन्हें मैन्युअली उसी तरह हटाना होगा जैसा आपने पिछले चरणों में फ़ाइलों को हटाया था। 

**Step** **14:** अब Aspose.Slides for Reporting Services को पुनः स्थापित करने का समय है। स्वचालित स्थापना के लिए MSI इंस्टॉलर का उपयोग करें या मैन्युअल रूप से करें।