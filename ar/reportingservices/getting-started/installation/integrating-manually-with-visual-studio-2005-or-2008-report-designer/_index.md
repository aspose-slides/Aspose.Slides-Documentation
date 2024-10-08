---
title: التكامل اليدوي مع مصمم تقارير Visual Studio 2005 أو 2008
type: docs
weight: 50
url: /ar/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---

{{% alert color="primary" %}} 

هذه المقالة تعلّمك كيفية دمج Aspose.Slides لــ Reporting Services يدويًا مع Visual Studio. 

{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}} 

**Aspose.Slides لــ Reporting Services** يتطلب تثبيت **.NET Framework 3.5** على الجهاز المضيف. 

{{% /alert %}}

## **دمج Aspose.Slides لــ Reporting Services مع Visual Studio**
نوصي باستخدام مثبت MSI لتثبيت Aspose.Slides لــ Reporting Services لأنه يقوم بجميع مهام التثبيت اللازمة وعمليات التكوين تلقائيًا. ومع ذلك، إذا فشل التثبيت مع مثبت MSI، فاستخدم الدليل هنا. 

تظهر لك هذه المقالة أيضًا كيفية تثبيت Aspose.Slides لــ Reporting Services على جهاز كمبيوتر مزود باستوديو تطوير ذكاء الأعمال. سيمكنك ذلك من تصدير التقارير إلى تنسيقات Microsoft PowerPoint في وقت التصميم من مصمم تقارير Microsoft Visual Studio 2005 أو 2008. 

1. انسخ Aspose.Slides.ReportingServices.dll إلى دليل Visual Studio.

   - للتكامل مع مصمم تقارير Visual Studio 2005، انسخ **Aspose.Slides.ReportingServices.dll** إلى دليل **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies**.
   - للتكامل مع مصمم تقارير Visual Studio 2008، انسخ **Aspose.Slides.ReportingServices.dll** إلى دليل **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies**.
2. قم بتسجيل Aspose.Slides لــ Reporting Services كامتداد للتقديم.

3. افتح **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config** (حيث <Version> هو "8" لـ Visual Studio 2005 أو "9.0" لـ Visual Studio 2008) وأضف هذه الأسطر إلى عنصر <Render>:

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

``` 

4. امنح Aspose.Slides لــ Reporting Services الأذونات للتنفيذ. 
   1. افتح **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** (حيث <Version> هو "8" لـ Visual Studio 2005 أو "9.0" لـ Visual Studio 2008).
   1. أضف هذا السطر كآخر عنصر في عنصر <CodeGroup> الخارجي الثاني (الذي يجب أن يكون <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="هذه مجموعة أكواد تمنح إذن تنفيذ كود MyComputer.">) 

**<CodeGroup>**

``` xml

...

  <CodeGroup>

    ...

    <!--ابدأ هنا.-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="هذه مجموعة أكواد تمنح الثقة الكاملة لمجمع AS4SSRS.">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

            PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--انتهى هنا.-->

  </CodeGroup>

</CodeGroup>

``` 

5. تحقق من نجاح تثبيت Aspose.Slides لــ Reporting Services. 
6. قم بتشغيل أو إعادة تشغيل مصمم تقارير Microsoft Visual Studio 2005 أو 2008. يجب أن تلاحظ تنسيقات جديدة في قائمة تنسيقات التصدير.

**تظهر تنسيقات تصدير جديدة في مصمم التقارير.** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)