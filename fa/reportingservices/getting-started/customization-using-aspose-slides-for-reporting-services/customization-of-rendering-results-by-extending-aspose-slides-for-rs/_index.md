---
title: سفارشی‌سازی نتایج رندرینگ با گسترش Aspose.Slides برای RS
type: docs
weight: 10
url: /fa/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---
{{% alert color="primary" %}}

این صفحه توضیح می‌دهد که چگونه افزونه‌ای برای Aspose.Slides for RS ایجاد کنید.

- [ایجاد یک مجموعه افزونه](/slides/fa/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [یکپارچه‌سازی افزونه](/slides/fa/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}}

ویژگی افزونه سفارشی به شما این امکان را می‌دهد که در حین صادرات گزارش، عناصر اضافی اضافه کنید یا عناصر موجود را به‌روزرسانی کنید.
## **چگونه یک مجموعه افزونه ایجاد کنید**
1. یک پروژه .NET ایجاد کنید و ارجاعی به Aspose.Slides.ReportingServices.dll اضافه کنید.
1. یک کلاس اضافه کنید و از Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase ارث‌بری کنید.
1. متدهای مجازی کلاس را بازنویسی کنید تا عملکرد سفارشی اضافه شود.
### **مثال**
فرض کنیم می‌خواهیم برای هر گزارش صادر شده با Aspose.Slides for RS، یک یادداشت با متن، یک لوگو اضافه کنیم و نام شرکت را به‌روزرسانی کنیم.

برای این منظور کلاس زیر را اضافه می‌کنیم:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//یادداشت را به اولین اسلاید اضافه کنید

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("This is the demo of Rendering Extension for Aspose.Slides for ReportingServices",

textFormat);

}

//نمایش لوگو روی هر اسلاید در گوشه پایین‑راست

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//اضافه کردن (TM) به هر اشاره‌ای به نام شرکت در گزارش

string companyName = "Adventure Works";

if (textBox.Text.Contains(companyName))

{

textBox.Text = textBox.Text.Replace(companyName, companyName + "™");

}

base.PostProcessTextBox(textBox);

}

}
```

{{% alert color="primary" %}}

آن را بسازید و مجموعه افزونه را دریافت خواهید کرد. ما آماده یکپارچه‌سازی افزونه هستیم.

{{% /alert %}}

[پروژهٔ Visual Studio از RenderingExtensionDemo.zip](attachments/10289195/10452998.zip)
### **یکپارچه‌سازی افزونه**
فرض کنید اسمبلی شما با نام **TestSlidesRenderingExtension.dll** باشد:

- اسمبلی را به پوشه **bin** سرویس گزارش‌دهی (ReportingService) در کنار Aspose.Slides.ReportingServices.dll کپی کنید. (به عنوان مثال: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- با افزودن گروه کد (CodeGroup) زیر به **rssrvpolicy.config**، مجوز FullTrust را به اسمبلی خود بدهید:

``` xml

 <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Nothing">

<IMembershipCondition class="AllMembershipCondition" version="1" />

...

<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">

<IMembershipCondition class="ZoneMembershipCondition" version="1" Zone="MyComputer" />

...

<CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_Extension" Description="This code group grants full trust to the Aspose.Slides for Reporting Services Rendering extension.">

<IMembershipCondition	class="UrlMembershipCondition"	version="1" Url="c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin\TestSlidesRenderingExtension.dll" />

</CodeGroup>

</CodeGroup>

</CodeGroup>

```

بخش‌های پیکربندی افزونه رندرینگ Aspose.Slides در **rsreportserver.config** را به‌روزرسانی کنید تا افزونه شما شامل شود.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

اگر می‌خواهید از افزونه برای هر نوع خروجی پشتیبانی‌شده توسط Aspose.Slides استفاده کنید، همان پیکربندی را به افزونه‌هایی با نام‌های ASPPTX، ASPPT، ASPPS و ASPPSX اضافه کنید.

محتوای برچسب Extension یک نام assembly-qualified از نوع است. (به <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname> مراجعه کنید)

حال سرویس‌های گزارش‌دهی را دوباره راه‌اندازی کنید و گزارش را صادر کنید. چیزی شبیه به [این ارائه](attachments/10289195/10452997.pptx) از گزارش Company Sales SQL2008R2 نمونه‌های Adventureworks دریافت می‌کنید.