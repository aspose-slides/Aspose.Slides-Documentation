---
title: نصب به صورت دستی
type: docs
weight: 30
url: /fa/reportingservices/install-manually/
---
{{% alert color="primary" %}} 

این مراحل را فقط در صورتی دنبال کنید که قصد نصب Aspose.Slides for Reporting Services به‌صورت دستی را دارید. در این صورت، بسته ZIP شامل فایل‌های اسمبلی را دانلود کرده‌اید. 

{{% /alert %}} 

{{% alert title="توجه" color="warning" %}} 

**Aspose.Slides for Reporting Services** نیاز به نصب **.NET Framework 3.5** بر روی ماشین میزبان دارد. 

{{% /alert %}}

### **نصب دستی**
این دستورالعمل‌ها نشان می‌دهند چگونه فایل‌ها را در دایرکتوری که Microsoft SQL Server Reporting Services نصب شده است، کپی و تغییر دهید:

1. پوشه نصب Report Server را پیدا کنید.
   مسیر ریشه Microsoft SQL Server معمولاً اینجا است: ***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 و 2008**: ممکن است چندین نمونه Microsoft SQL Server بر روی ماشین پیکربندی شده باشند و ممکن است در زیرشاخه‌های مختلف MSSQL.x مانند MSSQL.1، MSSQL.2 و غیره قرار گیرند. قبل از ادامه به مرحله بعد، باید دایرکتوری صحیح ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** را پیدا کنید. 
   
   {{% /alert %}} تمام مسیرهای استفاده‌شده در ادامه به این دایرکتوری به عنوان <Instance> ارجاع می‌شوند. 

2. فایل Aspose.Slides.ReportingServices.dll را به پوشه **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin** کپی کنید.
   پکیج دانلود شده **Aspose.Slides.ReportingServices.zip** شامل **Aspose.Slides.ReportingServices.dll** است. {{% alert color="primary" %}} 

در برخی موارد، هنگام کپی کردن DLL به دایرکتوری **ReportServer\bin**, مجوزهای صریح NTFS که به آن اختصاص داده شده‌اند نیز کپی می‌شوند. این مجوزهای NTFS باعث می‌شود Microsoft SQL Server Reporting Services هنگام بارگذاری **Aspose.Slides.ReportingServices.dll** دسترسی نداشته باشد. اگر این اتفاق افتاد، فرمت‌های صادراتی جدید در دسترس نخواهند بود. اطمینان حاصل کنید که مجوزهای NTFS صحیح تنظیم شده‌اند :

   1. روی **Aspose.Slides.ReportingServices.dll** راست‌کلیک کنید.
   1. **Properties** را کلیک کنید و برگه **Security** را انتخاب کنید.
   1. هر مجوز صریح NTFS را حذف کنید و فقط مجوزهای وارثتی را بگذارید.

{{% /alert %}}

3. Aspose.Slides for Reporting Services را به‌عنوان یک افزونه رندرینگ ثبت کنید:
   1. فایل *C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config* را باز کنید.
   2. این خطوط را به عنصر <Render> اضافه کنید: 

**<Render>**

``` xml

   ...

  <!--از اینجا شروع کنید.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--از اینجا پایان.-->

</Render>



```

4. به Aspose.Slides for Reporting Services اجازه اجرا بدهید:
   1. فایل **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config** را باز کنید.
   2. موارد زیر را به عنوان آخرین آیتم در عنصر دوم به‌علاوه <CodeGroup> خارجی اضافه کنید (که باید <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. "> باشد). 

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--از اینجا شروع کنید.-->

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

    <!--از اینجا پایان.-->

  </CodeGroup>

</CodeGroup>



```

5. تأیید کنید که Aspose.Slides for Reporting Services با موفقیت نصب شده است:
   1. Report Manager را باز کنید و فهرست انواع صادراتی موجود برای یک گزارش را بررسی کنید. 
   
      {{% alert color="primary" %}} می‌توانید Report Manager را با باز کردن یک مرورگر (Microsoft Internet Explorer 6.0 یا بالاتر) و وارد کردن URL Report Manager در نوار آدرس اجرا کنید (به‌طور پیش‌فرض http://<ComputerName>/Reports است). 
   
      {{% /alert %}}

1. یک گزارش روی سرور انتخاب کنید.
1. فهرست **Select Format** را باز کنید.
   باید فهرستی از فرمت‌های صادراتی ارائه‌شده توسط Aspose.Slides for Reporting Services ببینید.
1. **PPT – PowerPoint Presentation via Aspose.Slides** را انتخاب کنید. 

   **Aspose.Slides for Reporting Services با موفقیت نصب شد و فرمت‌های صادراتی جدید در دسترس هستند.** 

![todo:image_alt_text](install-manually_1.png)




6. روی لینک **Export** کلیک کنید.
   گزارش در فرمت انتخابی تولید می‌شود، به مشتری ارسال می‌گردد و سپس در برنامه مناسب باز می‌شود. در مثال ما، گزارش در Microsoft PowerPoint باز شد. 

   **یک گزارش PPT که توسط Aspose.Slides for Reporting Services تولید شده است.** 

![todo:image_alt_text](install-manually_2.png)

شما با موفقیت Aspose.Slides for Reporting Services را نصب کرده و گزارشی به‌صورت ارائه Microsoft PowerPoint تولید کردید!