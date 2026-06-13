---
title: نصب مجدد Aspose.Slides برای Reporting Services
type: docs
weight: 40
url: /fa/reportingservices/re-installing-aspose-slides-for-reporting-services/
---
{{% alert color="primary" %}} 

این مقاله راه حل وضعیتی را که در آن Aspose.Slides for Reporting Services قبلاً نصب شده است، اما به دلایلی باید دوباره نصب شود، توضیح می‌دهد.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** نیاز به نصب **.NET Framework 3.5** بر روی ماشین میزبان دارد. 

{{% /alert %}}

## **مراحل دوباره نصب Aspose.Slides for Reporting Services**
مهم‌ترین نکته حذف کامل نصب‌های قبلی Aspose.Slides for Reporting Services است. در حالی که نصب‌کننده MSI می‌تواند به‌صورت خودکار اقدامات لازم برای حذف و در نتیجه دوباره نصب Aspose.Slides for Reporting Services را انجام دهد، باید این مراحل را دنبال کنید:

1. با استفاده از نصب‌کننده MSI، Aspose.Slides for Reporting Services را حذف کنید. 

2. دایرکتوری نصب Aspose.Slides for Reporting Services را که معمولاً در مسیر زیر قرار دارد پیدا کنید:

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3. اگر نصب‌کننده MSI هنگام حذف Aspose.Slides for Reporting Services، دایرکتوری “Aspose.Slides for Reporting Services” را حذف نکرده باشد، پوشه را حذف کنید. 

4. فایل باینری **Aspose.Slides.ReportingServices.dll** را در دایرکتوری “bin” هر نمونه از SQL Server Reporting Service پیدا کنید. به‌عنوان مثال، اگر یک نمونه Microsoft SQL Server 2008 به نام “MSSQLSERVER” وجود داشته باشد، مسیر دایرکتوری “bin” سرویس گزارش‌دهی مربوطه احتمالاً به صورت زیر است: 

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. اگر نصب‌کننده MSI هنگام حذف Aspose.Slides for Reporting Services، فایل باینری Aspose.Slides.ReportingServices.dll را از مسیر بالا حذف نکرده باشد، اکنون این فایل را حذف کنید.

6. فایل **rsreportserver.config** را برای هر نمونه SSRS پیدا کنید. به‌عنوان مثال، اگر یک نمونه Reporting Service به نام “**MSRS10.MSSQLSERVER**” وجود داشته باشد، فایل **rsreportserver.config** در این دایرکتوری قرار خواهد داشت:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. فایل **rsreportserver.config** را در هر ویرایشگری باز کنید و خطوطی را که برای افزودن PowerPoint Format Extensions هنگام نصب Aspose.Slides for Reporting Services ایجاد شده‌اند، پیدا کنید. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

**Step** **8:** اگر نصب‌کننده MSI هنگام حذف Aspose.Slides for Reporting Services، این خطوط را حذف نکرده باشد، آنها را هم‌اکنون از فایل **rsreportserver.config** حذف کنید. 

**Step** **9:** فایل **rssrvpolicy.config** را برای هر نمونه SSRS پیدا کنید. به‌عنوان مثال، اگر یک نمونه Reporting Service به نام “MSRS10.MSSQLSERVER” وجود داشته باشد، فایل **rssrvpolicy.config** در این دایرکتوری قرار خواهد داشت:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Step** **10:** فایل **rssrvpolicy.config** را در هر ویرایشگری باز کنید و خطوطی را که برای اعطای مجوزهای اجرا به Aspose.Slides for Reporting Services هنگام نصب آن ایجاد شده‌اند، پیدا کنید. 

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

    <!--در اینجا پایان.-->

  </CodeGroup>

</CodeGroup>



```

**Step** **11:** اگر نصب‌کننده MSI هنگام حذف محصول، خطوط فوق را حذف نکرده باشد، هم‌اکنون این خطوط را از فایل **rssrvpolicy.config** حذف کنید. 

**Step** **12:** اگر Aspose.Slides for Reporting Services همچنین با Microsoft Visual Studio برای توسعه گزارش‌های RDL و خروجی به فرمت‌های PowerPoint در محیط Microsoft Visual Studio نصب شده باشد، فایل باینری Aspose.Slides.ReportingServices.dll و فایل‌های پیکربندی (**rsreportserver.config** و **rssrvpolicy.config**) در صورت استفاده از Microsoft Visual Studio 2008 باید در مسیر زیر قرار داشته باشند: 

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Step** **13:** اگر نصب‌کننده MSI فایل باینری **Aspose.Slides.ReportingServices.dll** را حذف نکرده باشد، آن را حذف کنید. علاوه بر این، اگر فایل‌های **rsreportserver.config** و **rssrvpolicy.config** را به‌منظور حذف PowerPoint Format Extensions و مجوزهای اجرا به‌روزرسانی نکرده باشد، باید آنها را به‌صورت دستی همان‌طور که در مراحل قبلی فایل‌ها را حذف کردید، حذف کنید. 

**Step** **14:** زمان دوباره نصب Aspose.Slides for Reporting Services رسیده است. از نصب‌کننده MSI برای نصب خودکار استفاده کنید یا به‌صورت دستی نصب کنید.