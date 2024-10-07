---
title: تخصيص نتائج العرض عن طريق توسيع Aspose.Slides لـ RS
type: docs
weight: 10
url: /reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---

{{% alert color="primary" %}} 

تصف هذه الصفحة كيفية إنشاء ملحق لـ Aspose.Slides لـ RS.

- [إنشاء تجميع ملحق](/slides/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [دمج الملحق](/slides/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

تتيح لك ميزة الملحق المخصص إضافة عناصر إضافية أو تحديث العناصر الموجودة أثناء تصدير التقرير.
## **كيفية إنشاء تجميع ملحق**
1. أنشئ مشروع .NET وأضف مرجعًا إلى Aspose.Slides.ReportingServices.dll.
1. أضف فئة وارثها من Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase.
1. تجاوز الطرق الافتراضية للفئة لإضافة وظيفة مخصصة.
### **مثال**
افترض أننا نريد إضافة ملاحظة مع بعض النص، وشعار، وتحديث اسم الشركة لكل تقرير يتم تصديره باستخدام Aspose.Slides لـ RS.

لهذا الغرض نضيف الفئة التالية:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//أضف ملاحظة إلى الشريحة الأولى

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("هذه هي عرض ملحق rendering لـ Aspose.Slides لـ ReportingServices",

textFormat);

}

//عرض الشعار على كل شريحة في الزاوية السفلى اليمنى

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//أضف (TM) إلى أي ذكر اسم شركة في التقرير

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

قم بإنشائه وسنحصل على تجميع الملحق. نحن مستعدون لدمج الملحق.

{{% /alert %}} 

[مشروع Visual Studio لـ RenderingExtensionDemo.zip](attachments/10289195/10452998.zip)
### **دمج الملحق**
افترض أن تجميعك يسمى **TestSlidesRenderingExtension.dll**:

- انسخ التجميع إلى دليل **bin** الخاص بـ ReportingService بجوار Aspose.Slides.ReportingServices.dll. (على سبيل المثال: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- امنح إذن FullTrust لتجميعك عن طريق إضافة مجموعة التعليمات البرمجية التالية إلى **rssrvpolicy.config**:

``` xml

 <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Nothing">

<IMembershipCondition class="AllMembershipCondition" version="1" /> 

... 

<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="تمنح هذه المجموعة الإذن لتنفيذ شفرة MyComputer. ">

<IMembershipCondition class="ZoneMembershipCondition" version="1" Zone="MyComputer" />

... 

<CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_Extension" Description="تمنح هذه المجموعة الثقة الكاملة لملحق Aspose.Slides لخدمات التقارير.">

<IMembershipCondition	class="UrlMembershipCondition"	version="1" Url="c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin\TestSlidesRenderingExtension.dll" />

</CodeGroup>

</CodeGroup>

</CodeGroup>

```

قم بتحديث أقسام تكوين ملحق Aspose.Slides في **rsreportserver.config** لتضمين ملحقك.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

إذا كنت ترغب في استخدام الملحق لكل نوع إخراج مدعوم من Aspose.Slides، أضف نفس التكوين إلى الملحقات مع الأسماء ASPPTX، ASPPT، ASPPS، ASPPSX.
محتوى عنصر الملحق هو اسم مؤهل للتجميع لنوع الفئة. (انظر <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

الآن أعد تشغيل خدمات التقارير وقم بتصدير التقرير. ستحصل على شيء مثل [هذا العرض التقديمي](attachments/10289195/10452997.pptx) من تقرير مبيعات الشركة SQL2008R2 من عينات Adventureworks.