---
title: إعادة تثبيت Aspose.Slides لـ Reporting Services
type: docs
weight: 40
url: /ar/reportingservices/re-installing-aspose-slides-for-reporting-services/
---

{{% alert color="primary" %}} 

تصف هذه المقالة الحل لحالة تم فيها تثبيت Aspose.Slides لـ Reporting Services بالفعل، ولكن لأي سبب من الأسباب، يجب إعادة تثبيته.

{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}} 

**Aspose.Slides لـ Reporting Services** يتطلب تثبيت **.NET Framework 3.5** على الجهاز المضيف. 

{{% /alert %}}

## **خطوات إعادة تثبيت Aspose.Slides لـ Reporting Services**
أهم شيء هو إزالة تثبيتات Aspose.Slides لـ Reporting Services السابقة بالكامل. بينما يمكن لمثبت MSI تنفيذ الإجراءات اللازمة لإلغاء تثبيت، وبالتالي، إعادة تثبيت Aspose.Slides لـ Reporting Services تلقائيًا بنجاح، يجب اتباع هذه الخطوات:

1. قم بإلغاء تثبيت Aspose.Slides لـ Reporting Services باستخدام مثبت MSI.

2. حدد دليل تثبيت Aspose.Slides لــ Reporting Services والذي يكون عادة عند:

   **محرك النظام\ملفات البرنامج\Aspose\Aspose.Slides لــ Reporting Services**

3. إذا لم يقم مثبت MSI بإزالة دليل "Aspose.Slides لــ Reporting Services" عند إلغاء تثبيت Aspose.Slides لــ Reporting Services، احذف المجلد.

4. حدد ملف **Aspose.Slides.ReportingServices.dll** الثنائي في دليل "bin" لكل مثيل من SQL Server Reporting Service. على سبيل المثال، إذا كان هناك مثيل Microsoft SQL Server 2008 "MSSQLSERVER"، فمن المحتمل أن يكون دليل Reporting Service "bin" في:

   **محرك النظام\ملفات البرنامج\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin**

5. إذا لم يقم مثبت MSI بإزالة ملف Aspose.Slides.ReportingServices.dll الثنائي من الدليل أعلاه عند إلغاء تثبيت Aspose.Slides لــ Reporting Services، احذف الملف الآن.

6. حدد ملف **rsreportserver.config** لكل مثيل من SSRS. على سبيل المثال، إذا كان هناك مثيل Reporting Service " **MSRS10.MSSQLSERVER** "، سيكون ملف **rsreportserver.config** في هذا الدليل:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer**

7. افتح ملف **rsreportserver.config** في أي محرر وابحث عن السطور التي تم إنشاؤها لإضافة ملحقات صيغة PowerPoint أثناء تثبيت Aspose.Slides لــ Reporting Services.

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

```

**الخطوة** **8:** إذا لم يقم مثبت MSI بإزالة تلك السطور عند إلغاء تثبيت Aspose.Slides لــ Reporting Services، احذف السطور من ملف **rsreportserver.config** الآن.

**الخطوة** **9:** حدد ملف **rssrvpolicy.config** لكل مثيل من SSRS. على سبيل المثال، إذا كان هناك مثيل Reporting Service "MSRS10.MSSQLSERVER"، سيكون ملف **rssrvpolicy.config** في هذا الدليل:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer**

**الخطوة** **10:** افتح ملف **rssrvpolicy.config** في أي محرر وابحث عن السطور التي تم إنشاؤها لمنح أذونات التنفيذ لـ Aspose.Slides لــ Reporting Services أثناء تثبيت Aspose.Slides لــ Reporting Services.

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

        Description="تمنح هذه المجموعة من التعليمات البرمجية الثقة الكاملة لتجميع AS4SSRS.">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

           PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--انته هنا.-->

  </CodeGroup>

</CodeGroup>

```

**الخطوة** **11:** إذا لم يقم مثبت MSI بإزالة السطور أعلاه عند إلغاء تثبيت المنتج، احذف تلك السطور من ملف **rssrvpolicy.config** الآن.

**الخطوة** **12:** إذا تم تثبيت Aspose.Slides لــ Reporting Services أيضًا مع Microsoft Visual Studio لتطوير تقارير RDL والتصدير إلى صيغ PowerPoint داخل بيئة Microsoft Visual Studio، يجب أن يكون الملف الثنائي Aspose.Slides.ReportingServices.dll وملفات التكوين ( **rsreportserver.config** و **rssrvpolicy.config** ) في حالة Microsoft Visual Studio 2008 هي:

**محرك النظام\ملفات البرنامج\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies**

**الخطوة** **13:** إذا لم يقم مثبت MSI بإزالة **Aspose.Slides.ReportingServices.dll** الثنائي، احذفه. علاوة على ذلك، إذا لم يقم بتحديث **rsreportserver.config** و **rssrvpolicy.config** لإزالة ملحقات صيغة PowerPoint وأذونات تنفيذ التعليمات البرمجية على التوالي، يجب عليك إزالتها يدويًا بنفس الطريقة التي فعلتها مع الملفات في الخطوات السابقة.

**الخطوة** **14:** حان الوقت لإعادة تثبيت Aspose.Slides لــ Reporting Services. استخدم مثبت MSI للتثبيت التلقائي أو قم بذلك يدويًا.