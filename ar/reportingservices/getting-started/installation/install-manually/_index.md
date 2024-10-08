---
title: التثبيت اليدوي
type: docs
weight: 30
url: /ar/reportingservices/install-manually/
---

{{% alert color="primary" %}} 

اتبع هذه الخطوات فقط إذا كنت تخطط لتثبيت Aspose.Slides لخدمات التقارير يدويًا. في هذه الحالة، قمت بتنزيل حزمة ZIP تحتوي على ملفات التجميع. 

{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}} 

**Aspose.Slides لخدمات التقارير** يتطلب تثبيت **.NET Framework 3.5** على الجهاز المضيف. 

{{% /alert %}}

### **التثبيت اليدوي**
توضح هذه التعليمات كيفية نسخ وتعديل الملفات في الدليل الذي تم تثبيت Microsoft SQL Server Reporting Services فيه:

1. حدد دليل تثبيت خادم التقرير.
   يكون الدليل الجذري لـ Microsoft SQL Server عادةً هنا: ***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 و 2008**: قد يكون هناك عدة مثيلات من Microsoft SQL Server مُكوّنة على الجهاز وقد تشغل مجلدات MSSQL.x فرعية مختلفة مثل MSSQL.1، MSSQL.2 وهكذا. يجب عليك العثور على الدليل الصحيح ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** قبل المتابعة إلى الخطوة التالية.
   
   {{% /alert %}} تشير جميع المسارات المستخدمة أدناه إلى هذا الدليل باعتباره <Instance>. 

2. انسخ Aspose.Slides.ReportingServices.dll إلى المجلد **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin**.
   تحتوي تنزيل **Aspose.Slides.ReportingServices.zip** على **Aspose.Slides.ReportingServices.dll**. {{% alert color="primary" %}} 

في بعض الحالات، عند نسخ DLL إلى دليل **ReportServer\bin**، قد يتم نسخه بجانب أذونات ملف NTFS المعينة له. تتسبب أذونات NTFS في رفض Microsoft SQL Server Reporting Services الوصول عند تحميل **Aspose.Slides.ReportingServices.dll**. إذا حدث ذلك، فلن تصبح تنسيقات التصدير الجديدة متاحة. تحقق وتأكد من أن أذونات NTFS الصحيحة موجودة :

   1. انقر بزر الماوس الأيمن على **Aspose.Slides.ReportingServices.dll**.
   1. انقر على **خصائص** واختر علامة التبويب **الأمان**.
   1. قم بإزالة أي أذونات NTFS المعينة بشكل صريح واترك فقط الأذونات الموروثة.

{{% /alert %}}

3. سجل Aspose.Slides لخدمات التقارير كامتداد عرض: 
   1. افتح *C:\Program
      Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*.
   1. أضف هذه الأسطر إلى عنصر <Render>: 

**<Render>**

``` xml

   ...

  <!--ابدأ هنا.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--انتهى هنا.-->

</Render>

```

4. أعطِ Aspose.Slides لخدمات التقارير أذونات للتنفيذ: 
   1. افتح **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**.
   1. أضف ما يلي كآخر عنصر في عنصر <CodeGroup> الخارجي الثاني (الذي يجب أن يكون <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="هذا مجموعة التعليمات البرمجية تمنح أذونات تنفيذ لكود MyComputer. ">).

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

        Description="هذه مجموعة التعليمات البرمجية تمنح الثقة الكاملة لتجميع AS4SSRS.">

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

5. تحقق من أنه تم تثبيت Aspose.Slides لخدمات التقارير بنجاح: 
   1. افتح مدير التقارير وافحص قائمة أنواع التصدير المتاحة للتقرير. 
   
      {{% alert color="primary" %}} يمكنك تشغيل مدير التقارير عن طريق فتح متصفح (Microsoft Internet Explorer 6.0 أو إصدار أحدث) وكتابة عنوان URL لمدير التقارير في شريط العنوان (بشكل افتراضي هو http://< ComputerName >/Reports ). 
   
      {{% /alert %}}

1. اختر تقريرًا على الخادم.
1. افتح قائمة **اختيار التنسيق**.
   يجب أن ترى قائمة بتنسيقات التصدير المقدمة من Aspose.Slides لخدمات التقارير. 
1. اختر **PPT – عرض تقديمي PowerPoint عبر Aspose.Slides**. 

   **تم تثبيت Aspose.Slides لخدمات التقارير بنجاح والتنسيقات الجديدة متاحة.** 

![todo:image_alt_text](install-manually_1.png)

6. انقر على رابط **تصدير**.
   يتم إنشاء التقرير بالتنسيق المختار، ثم يُرسل إلى العميل، ثم يُفتح في التطبيق المناسب. في حالتنا، تم فتح التقرير في Microsoft PowerPoint. 

   **تقرير PPT تم إنشاؤه بواسطة Aspose.Slides لخدمات التقارير.** 

![todo:image_alt_text](install-manually_2.png)

لقد قمت بتثبيت Aspose.Slides لخدمات التقارير بنجاح وأنشأت تقريرًا كعرض تقديمي من Microsoft PowerPoint!