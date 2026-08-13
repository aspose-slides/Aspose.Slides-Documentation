---
title: حل عملي لإعادة تحجيم ورقة العمل
type: docs
weight: 40
url: /ar/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- صورة معاينة
- تعديل حجم الصورة
- Excel
- ورقة عمل
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إصلاح إعادة تحجيم OLE لورقة عمل Excel في العروض التقديمية: طريقتان للحفاظ على اتساق إطارات الكائن—تعديل حجم الإطار أو الورقة—عبر صيغ PPT و PPTX."
---
{{% alert color="info" %}} 

تم ملاحظة أن أوراق عمل Excel المدمجة ككائنات OLE في عرض PowerPoint عبر مكونات Aspose يتم تغيير حجمها إلى مقياس غير معروف بعد التفعيل الأول. ينتج عن هذا سلوك فرق بصري واضح في العرض بين حالتي ما قبل وبعد التفعيل لكائن OLE. لقد حقّقنا في هذه المشكلة بالتفصيل وقدّمنا حلاً، وهو ما يغطيه هذا المقال.

{{% /alert %}} 

## **الخلفية**

في المقالة [Manage OLE](/slides/ar/net/manage-ole/)، شرحنا كيفية إضافة إطار OLE إلى عرض PowerPoint باستخدام Aspose.Slides for .NET. لمعالجة [object preview issue](/slides/ar/net/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة للمنطقة المحددة من ورقة العمل إلى إطار كائن OLE. في العرض الناتج، عند النقر المزدوج على إطار كائن OLE الذي يعرض صورة ورقة العمل، يتم تفعيل مصنف Excel. يمكن للمستخدمين إجراء أي تغييرات مرغوبة على مصنف Excel الفعلي ثم العودة إلى الشريحة بالنقر خارج مصنف Excel المفعل. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. عامل إعادة الحجم سيختلف بناءً على حجم إطار كائن OLE ومصنف Excel المدمج.

## **سبب إعادة الحجم**

نظرًا لأن مصنف Excel له حجم نافذة خاص به، فإنه يحاول الحفاظ على حجمه الأصلي عند التفعيل الأول. من ناحية أخرى، لإطار كائن OLE حجمه الخاص. وفقًا لـ Microsoft، عندما يتم تفعيل مصنف Excel، يتفاوض Excel وPowerPoint على الحجم لضمان الحفاظ على النسب الصحيحة كجزء من عملية الدمج. تحدث إعادة الحجم بناءً على الفروق بين حجم نافذة Excel وحجم وإحداثيات إطار كائن OLE.

## **الحل العملي**

هناك حلّان ممكنان لتجنّب تأثير إعادة الحجم.

- تعديل مقياس حجم إطار OLE في عرض PowerPoint لمطابقة ارتفاع وعرض عدد الصفوف والأعمدة المطلوبة في إطار OLE.
- الحفاظ على حجم إطار OLE ثابتًا وتعديل مقياس حجم الصفوف والأعمدة المشاركة لتناسب حجم إطار OLE المحدد.

### **تعديل مقياس حجم إطار OLE**

في هذا النهج، سنتعلم كيفية ضبط حجم إطار OLE للمصنف المدمج ليتطابق مع الحجم التراكمي للصفوف والأعمدة المشاركة في ورقة عمل Excel.

افترض أن لدينا قالب Excel ونريد إضافته إلى عرض كإطار OLE. في هذا السيناريو، سيُحسب أولاً حجم إطار كائن OLE بناءً على الارتفاعات التراكمية للصفوف وعروض الأعمدة المشاركة في المصنف. ثم نقوم بضبط حجم إطار OLE إلى هذه القيمة المحسوبة. لتجنّب رسالة "EMBEDDED OLE OBJECT" الحمراء لإطار OLE في PowerPoint، سنلتقط أيضًا صورة للأجزاء المطلوبة من الصفوف والأعمدة في المصنف ونعينها كصورة إطار OLE.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// تعيين الحجم المعروض عندما يُستخدم ملف المصنف ككائن OLE في PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// الحصول على عرض وارتفاع صورة OLE بالنقاط.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// نحتاج إلى استخدام المصنف المعدل.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// إضافة صورة OLE إلى موارد العرض التقديمي.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// إنشاء إطار كائن OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **تعديل مقياس حجم نطاق الخلايا**

في هذا النهج، سنتعلم كيفية تعديل ارتفاعات الصفوف المشاركة وعرض الأعمدة المشاركة ليتطابق مع حجم إطار OLE مخصص.

افترض أن لدينا قالب Excel ونريد إضافته إلى عرض كإطار OLE. في هذا السيناريو، سنحدد حجم إطار OLE ونعدل حجم الصفوف والأعمدة التي تشارك في منطقة إطار OLE. ثم سنحفظ المصنف إلى تدفق لتطبيق التغييرات ونحوّله إلى مصفوفة بايت لإضافته إلى إطار OLE. لتجنّب رسالة "EMBEDDED OLE OBJECT" الحمراء لإطار OLE في PowerPoint، سنلتقط أيضًا صورة للأجزاء المطلوبة من الصفوف والأعمدة في المصنف ونعينها كصورة إطار OLE.

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// تعيين الحجم المعروض عندما يُستخدم ملف المصنف ككائن OLE في PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// تحجيم نطاق الخلايا ليتناسب مع حجم الإطار.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// نحتاج إلى استخدام المصنف المعدل.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// إضافة صورة OLE إلى موارد العرض التقديمي.
var oleImage = presentation.Images.AddImage(imageStream);

// إنشاء إطار كائن OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">العرض المتوقع لنطاق الخلايا بالنقاط.</param>
/// <param name="height">الارتفاع المتوقع لنطاق الخلايا بالنقاط.</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **الخاتمة**

{{% alert color="info" %}}

هناك نهجان لحل مشكلة تغيير حجم ورقة العمل. يعتمد اختيار النهج المناسب على المتطلبات الخاصة وحالة الاستخدام. كلا النهجين يعملان بنفس الطريقة، سواء تم إنشاء العروض من قالب أو من الصفر. بالإضافة إلى ذلك، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.

{{% /alert %}}

## **الأسئلة المتكررة**

### لماذا يتغيّر حجم ورقة عمل Excel المدمجة عند تفعيلها لأول مرة في PowerPoint؟
يحدث ذلك لأن Excel يحاول الحفاظ على حجم نافذته الأصلي عند التفعيل، بينما يمتلك إطار كائن OLE في PowerPoint أبعادًا خاصة به. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يؤدي إلى تغيير الحجم.

### هل يمكن منع مشكلة إعادة الحجم هذه تمامًا؟
نعم. عن طريق تعديل مقياس إطار OLE ليتناسب مع حجم نطاق خلايا Excel أو تعديل مقياس نطاق الخلايا ليتناسب مع حجم إطار OLE المطلوب، يمكنك منع إعادة الحجم غير المرغوب فيها.

### أي طريقة تعديل مقياس يجب أن أستخدم، تعديل مقياس إطار OLE أم تعديل مقياس نطاق الخلايا؟
اختر **تعديل مقياس إطار OLE** إذا كنت ترغب في الحفاظ على أحجام الصفوف والأعمدة الأصلية في Excel. اختر **تعديل مقياس نطاق الخلايا** إذا كنت تريد حجمًا ثابتًا لإطار OLE في عرضك.

### هل ستعمل هذه الحلول إذا كان عرضي مبنيًا على قالب؟
نعم. كلا الحلين يعملان لعروض تم إنشاؤها من القوالب أو من الصفر.

### هل هناك حد لحجم إطار OLE عند استخدام هذه الطرق؟
لا. يمكنك جعل إطار كائن OLE بأي حجم طالما قمت بضبط المقياس بشكل مناسب.

### هل هناك طريقة لتجنب نص العنصر النائب "EMBEDDED OLE OBJECT" في PowerPoint؟
نعم. عن طريق التقاط صورة لنطاق خلايا Excel المستهدف وتعيينها كصورة للعنصر النائب لإطار OLE، يمكنك عرض صورة معاينة مخصصة بدلاً من العنصر النائب الافتراضي.

## **مقالات ذات صلة**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/ar/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/ar/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)