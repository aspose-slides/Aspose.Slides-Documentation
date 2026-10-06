---
title: مدیریت SmartArt در ارائه‌های PowerPoint با .NET
linktitle: مدیریت SmartArt
type: docs
weight: 10
url: /fa/net/manage-smartart/
keywords:
- SmartArt
- متن SmartArt
- نوع طرح‌بندی
- خاصیت مخفی
- نمودار سازمانی
- نمودار سازمانی تصویری
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "با استفاده از نمونه‌های کد واضح C#، یاد بگیرید که چگونه SmartArt PowerPoint را با Aspose.Slides برای .NET بسازید و ویرایش کنید و فرآیند طراحی اسلاید و خودکارسازی را سرعت بخشید."
---
## **مرور کلی**

SmartArt یک نمودار PowerPoint است که از گره‌ها، شکل‌های گره و یک طرح ساخته شده است. با Aspose.Slides برای .NET، می‌توانید SmartArt ایجاد کنید، متن را از گره‌های آن بخوانید، طرح آن را تغییر دهید، گره‌های مخفی را بررسی کنید، طرح‌های نمودار سازمانی را پیکربندی کنید و نمودارهای سازمانی تصویری ایجاد کنید.

## **دریافت متن از یک شیء SmartArt**

یک گره SmartArt می‌تواند یک یا چند شکل داشته باشد. برای خواندن متن از شکل‌های گره، از طریق [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/) مرور کنید، سپس [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) برگردانده شده توسط [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/) را بخوانید.

این مثال به یک ارائه با حداقل یک اسلاید و یک شیء SmartArt به عنوان اولین شکل در آن اسلاید نیاز دارد. هر فریم متن موجود را در کنسول چاپ می‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **تغییر نوع طرح‌بندی یک شیء SmartArt**

طرح‌بندی SmartArt کنترل می‌کند که گره‌ها چگونه چیده و متصل شوند. مثال زیر یک شیء SmartArt با مقدار `BasicBlockList` از [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) ایجاد می‌کند، آن را به مقدار `BasicProcess` تغییر می‌دهد و ارائه را ذخیره می‌کند. موقعیت و اندازه‌ای که به [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) پاس داده می‌شود بر حسب پوینت اندازه‌گیری می‌شود. برای تغییر طرح‌بندی، [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) را تنظیم کنید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **بررسی اینکه آیا یک گره SmartArt مخفی است**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) نشان می‌دهد که آیا گره در مدل داده‌های SmartArt مخفی است یا خیر. گره‌های مخفی می‌توانند در ساختار وجود داشته باشند حتی زمانی که طرح‌بندی انتخاب‌شده آن‌ها را به عنوان عناصر نمودار قابل مشاهده نمایش نمی‌دهد.

مثال زیر یک گره به شیء SmartArt که از مقدار `RadialCycle` از [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) استفاده می‌کند اضافه می‌کند و وضعیت مخفی بودن گره اضافه‌شده را بررسی می‌کند. اگر گره مخفی باشد پیامی چاپ می‌کند و نمودار را ذخیره می‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **دریافت یا تنظیم طرح‌بندی نمودار سازمانی**

برای نمودارهای SmartArt که از طرح‌بندی نمودار سازمانی استفاده می‌کنند، [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) تعریف می‌کند که گره‌های فرزند تحت یک گره والد چگونه چیدمان شوند. به عنوان مثال، می‌توانید گره‌های فرزند را طوری تنظیم کنید که از سمت چپ، راست یا هر دو طرف آویز شوند، بسته به [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) انتخاب‌شده.

مثال زیر یک نمودار سازمانی ایجاد می‌کند و طرح‌بندی گره اول را به مقدار `LeftHanging` از [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) تنظیم می‌کند. اندیس صفر پایه `0` گره سطح بالای اول را انتخاب می‌کند؛ گره‌های فرزند آن از چیدمان انتخاب‌شده استفاده می‌کنند. سپس ارائه اصلاح‌شده ذخیره می‌شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **ایجاد یک نمودار سازمانی تصویری**

نمودار سازمانی تصویری یک طرح‌بندی SmartArt است که برای نمودارهای سلسله‌مراتبی شامل جای‌دارهای تصویر طراحی شده است. هنگام افزودن شیء SmartArt به اسلاید، از مقدار `PictureOrganizationChart` از [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) استفاده کنید. این مثال یک نمودار با جای‌دارهای تصویر ذخیره می‌کند؛ اما جای‌دارها را با تصویر پر نمی‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **تبدیل نمودارهای قدیمی به گروه‌هایی از شکل‌ها**

هنگام به‌روز رسانی یک ارائه موجود، ممکن است نیاز داشته باشید یک نمودار سازمانی که ابتدا در PowerPoint 97–2003 ایجاد شده را به‌روزرسانی کنید. Aspose.Slides این نمودارهای قدیمی را به عنوان اشیاء [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/) نمایش می‌دهد. برای تبدیل یک نمودار به گروهی از شکل‌ها و ویرایش عناصر بصری جداگانه، از [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) استفاده کنید. برای جزئیات به [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/) مراجعه کنید.

تبدیل یک گروه جدید به مجموعه شکل‌ها اضافه می‌کند بدون اینکه نمودار اصلی حذف شود. پس از تبدیل موفق، برای جلوگیری از محتوای تکراری، اصل را با [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) حذف کنید. پیش از تبدیل، نمودارهای قدیمی را در یک آرایه جمع‌آوری کنید تا افزودن و حذف شکل‌ها از تکرار جلوگیری کند.

مثال زیر یک ارائه را باز می‌کند، هر اسلاید را جستجو می‌کند، نمودارها را به گروه‌هایی از شکل‌ها تبدیل می‌کند و ارائه بروز‌شده را به صورت PPTX ذخیره می‌کند.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

ارائه ذخیره‌شده شامل گروه‌های ویرایش‌پذیر شکل‌ها به جای نمودارهای قدیمی تبدیل‌شده است و دیگر هیچ نمودار اصلی در کنار آن‌ها وجود ندارد. PPTX را در PowerPoint باز کنید تا عناصر جداگانه در هر گروه، مانند متن، پرکننده یا موقعیتشان را ویرایش کنید.

## **پرسش‌های متداول**

**آیا SmartArt از آینه‌سازی یا وارونه‌سازی برای زبان‌های راست به چپ پشتیبانی می‌کند؟**

بله. خصوصیت [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) جهت نمودار را از چپ به راست به راست به چپ یا برعکس می‌کند، زمانی که طرح‌بندی SmartArt انتخاب‌شده از وارونه‌سازی پشتیبانی کند.

**چگونه می‌توانم SmartArt را به همان اسلاید یا به ارائه دیگری کپی کنم در حالی که قالب‌بندی حفظ شود؟**

شما می‌توانید [کپی‌کردن شکل SmartArt](/slides/fa/net/shape-manipulations/) را با [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) یا [کپی‌کردن کل اسلاید](/slides/fa/net/clone-slides/) که شامل SmartArt است، انجام دهید. هر دو روش اندازه، موقعیت و قالب‌بندی را حفظ می‌کند.

**چگونه می‌توانم SmartArt را به تصویر رستر برای پیش‌نمایش یا صادرات وب رندر کنم؟**

[رندر اسلاید](/slides/fa/net/convert-powerpoint-to-png/) یا کل ارائه را به PNG یا JPEG تبدیل کنید. SmartArt به عنوان بخشی از اسلاید رندر می‌شود.

**چگونه می‌توانم یک شیء SmartArt خاص را در یک اسلاید پیدا کنم اگر چندین مورد موجود باشد؟**

یک مقدار متمایز برای [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) یا [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) روی شکل SmartArt تنظیم کنید، آن مقدار را در [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) جستجو کنید و سپس بررسی کنید که شکل یافت‌شده یک [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/) باشد.