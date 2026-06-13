---
title: یکپارچه‌سازی به صورت دستی با Visual Studio 2005 یا 2008 Report Designer
type: docs
weight: 50
url: /fa/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---
{{% alert color="primary" %}} 

این مقاله نحوه یکپارچه‌سازی Aspose.Slides for Reporting Services به‌صورت دستی با Visual Studio را آموزش می‌دهد. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** برای اجرا بر روی ماشین میزبان نیاز به نصب **.NET Framework 3.5** دارد. 

{{% /alert %}}

## **یکپارچه‌سازی Aspose.Slides for Reporting Services با Visual Studio**
ما توصیه می‌کنیم از نصب‌کننده MSI برای نصب Aspose.Slides for Reporting Services استفاده کنید، زیرا تمام وظایف نصب و پیکربندی لازم را به‌صورت خودکار انجام می‌دهد. با این حال، اگر نصب با MSI اجرا نشد، از راهنمای زیر استفاده کنید. 

این مقاله همچنین نشان می‌دهد چگونه Aspose.Slides for Reporting Services را بر روی کامپیوتری که Business Intelligence Development Studio نصب شده است، نصب کنید. این کار امکان خروجی‌گیری گزارش‌ها به فرمت‌های Microsoft PowerPoint را در زمان طراحی از Microsoft Visual Studio 2005 یا 2008 Report Designer فراهم می‌کند. 

1. فایل **Aspose.Slides.ReportingServices.dll** را به پوشه Visual Studio کپی کنید.

   - برای یکپارچه‌سازی با Visual Studio 2005 Report Designer، **Aspose.Slides.ReportingServices.dll** را به مسیر **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies** کپی کنید.
   - برای یکپارچه‌سازی با Visual Studio 2008 Report Designer، **Aspose.Slides.ReportingServices.dll** را به مسیر **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** کپی کنید.
2. Aspose.Slides for Reporting Services را به‌عنوان یک افزونه رندرینگ ثبت کنید. 

3. فایل **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config** را باز کنید (که در آن <Version> برای Visual Studio 2005 مقدار «8» و برای Visual Studio 2008 مقدار «9.0» است) و این خطوط را در عنصر `<Render>` اضافه کنید: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. به Aspose.Slides for Reporting Services اجازه اجرا بدهید. 
   1. فایل **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** را باز کنید (که در آن <Version> برای Visual Studio 2005 مقدار «8» و برای Visual Studio 2008 مقدار «9.0» است). 
   1. این خط را به‌عنوان آخرین مورد در عنصر دوم به‑علیه `<CodeGroup>` اضافه کنید (که باید به شکل `<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission.">` باشد) 

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--از اینجا شروع می‌شود.-->

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

    <!--در اینجا پایان می‌یابد.-->

  </CodeGroup>

</CodeGroup>



```

5. تأیید کنید که Aspose.Slides for Reporting Services به‌درستی نصب شده است. 
6. Microsoft Visual Studio 2005 یا 2008 Report Designer را اجرا یا دوباره راه‌اندازی کنید. باید فرمت‌های جدید را در لیست فرمت‌های خروجی مشاهده کنید.

**فرمت‌های جدید خروجی در Report Designer ظاهر می‌شوند.** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)