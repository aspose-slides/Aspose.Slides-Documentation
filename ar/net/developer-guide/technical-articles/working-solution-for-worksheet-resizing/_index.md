---
title: حل عملي لتغيير حجم ورقة العمل
type: docs
weight: 40
url: /ar/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- صورة المعاينة
- تغيير حجم الصورة
- Excel
- ورقة العمل
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إصلاح تغيير حجم OLE لورقة عمل Excel في العروض التقديمية: طريقتان للحفاظ على تناسق إطارات الكائن - إما بتحجيم الإطار أو الورقة - عبر صيغ PPT و PPTX."
---

{{% alert color="primary" %}} 
تمت ملاحظة أن أوراق عمل Excel المدمجة ككائنات OLE في عرض PowerPoint من خلال مكونات Aspose يتم تغيير حجمها إلى مقياس غير محدد بعد التنشيط الأول. يخلق هذا السلوك اختلافًا بصريًا واضحًا في العرض بين حالتي ما قبل وبعد تنشيط كائن OLE. لقد قمنا بالتحقيق في هذه المشكلة بالتفصيل وقد قدمنا حلاً، وهو مغطى في هذه المقالة.
{{% /alert %}} 

## **الخلفية**

في المقالة [إدارة OLE](/slides/ar/net/manage-ole/)، شرحنا كيفية إضافة إطار OLE إلى عرض PowerPoint باستخدام Aspose.Slides for .NET. لمعالجة [مشكلة معاينة الكائن](/slides/ar/net/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة لمنطقة ورقة العمل المحددة إلى إطار كائن OLE. في العرض الناتج، عند النقر المزدوج على إطار كائن OLE الذي يعرض صورة ورقة العمل، يتم تنشيط مصنف Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات مرغوبة على المصنف الفعلي ثم العودة إلى الشريحة بالنقر خارج المصنف النشط. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. سيختلف عامل التحجيم اعتمادًا على حجم إطار كائن OLE ومصنف Excel المدمج.

## **سبب التحجيم**

نظرًا لأن مصنف Excel يمتلك حجماً خاصًا للنافذة، فإنه يحاول الحفاظ على حجمه الأصلي عند التنشيط الأول. من ناحية أخرى، يمتلك إطار كائن OLE حجماً خاصاً به. وفقًا لمايكروسوفت، عندما يتم تنشيط مصنف Excel، يتفاوض Excel وPowerPoint على الحجم لضمان الحفاظ على النسب الصحيحة كجزء من عملية التضمين. يحدث التحجيم بناءً على الفروق بين حجم نافذة Excel وحجم وموقع إطار كائن OLE.

## **الحل العملي**

هناك حلان محتملان لتجنب تأثير التحجيم.

- ضبط حجم إطار OLE في عرض PowerPoint ليتطابق مع ارتفاع وعرض عدد الصفوف والأعمدة المطلوب في الإطار.
- الحفاظ على حجم إطار OLE ثابتًا وتعديل حجم الصفوف والأعمدة المشاركة لتناسب حجم إطار OLE المختار.

### **ضبط حجم إطار OLE**

في هذا النهج، سنتعلم كيفية ضبط حجم إطار OLE للمصنف المدمج في Excel ليتطابق مع الحجم التراكمى للصفوف والأعمدة المشاركة في ورقة عمل Excel.

افترض أن لدينا ورقة Excel نموذجية ونرغب في إضافتها إلى عرض كإطار OLE. في هذا السيناريو، سيتم حساب حجم إطار كائن OLE أولاً بناءً على ارتفاعات الصفوف المتراكمة وعروض الأعمدة المتراكمة للصفوف والأعمدة المشاركة في المصنف. ثم سنضبط حجم إطار OLE إلى هذه القيمة المحسوبة. لتجنب ظهور رسالة "EMBEDDED OLE OBJECT" الحمراء لإطار OLE في PowerPoint، سنقوم أيضًا بالتقاط صورة للأقسام المطلوبة من الصفوف والأعمدة في المصنف وتعيينها كصورة إطار OLE.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// اضبط الحجم المعروض عندما يُستخدم ملف المصنف ككائن OLE في PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// احصل على عرض وارتفاع صورة OLE بالنقاط.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// نحتاج إلى استخدام المصنف المعدل.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// أضف صورة OLE إلى موارد العرض التقديمي.
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


### **ضبط حجم نطاق الخلايا**

في هذا النهج، سنتعلم كيفية تعديل ارتفاعات الصفوف المشاركة وعرض الأعمدة المشاركة ليتطابق مع حجم إطار OLE مخصص.

افترض أن لدينا ورقة Excel نموذجية ونرغب في إضافتها إلى عرض كإطار OLE. في هذا السيناريو، سنحدد حجم إطار OLE ونضبط حجم الصفوف والأعمدة التي تشارك في مساحة إطار OLE. ثم سنحفظ المصنف إلى تدفق لتطبيق التغييرات وتحويله إلى مصفوفة بايت لإضافته إلى إطار OLE. لتجنب ظهور رسالة "EMBEDDED OLE OBJECT" الحمراء لإطار OLE في PowerPoint، سنقوم أيضًا بالتقاط صورة للأقسام المطلوبة من الصفوف والأعمدة في المصنف وتعيينها كصورة إطار OLE.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// ضبط الحجم المعروض عندما يُستخدم ملف المصنف ككائن OLE في PowerPoint.
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

{{% alert color="primary" %}}
هناك نهجان لإصلاح مشكلة تحجيم ورقة العمل. يعتمد اختيار النهج المناسب على المتطلبات المحددة وحالة الاستخدام. كلا النهجين يعملان بنفس الطريقة، سواء تم إنشاء العروض من قالب أو من الصفر. بالإضافة إلى ذلك، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.
{{% /alert %}}

## الأسئلة المتكررة

**س:** لماذا يتغير حجم ورقة عمل Excel المدمجة عند تنشيطها لأول مرة في PowerPoint?  
يحدث هذا لأن Excel يحاول الحفاظ على حجم النافذة الأصلي عند التنشيط، بينما يمتلك إطار كائن OLE في PowerPoint أبعاده الخاصة. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة الأبعاد، مما قد يسبب التحجيم.

**س:** هل يمكن منع هذه المشكلة بالكامل؟  
نعم. من خلال تعديل حجم إطار OLE ليتناسب مع حجم نطاق خلايا Excel أو تعديل نطاق الخلايا ليناسب حجم إطار OLE المطلوب، يمكنك منع التحجيم غير المرغوب فيه.

**س:** أي طريقة تعديل يجب أن أستخدمها، تعديل إطار OLE أم تعديل نطاق الخلايا؟  
اختر **تعديل إطار OLE** إذا كنت تريد الحفاظ على أحجام الصفوف والأعمدة الأصلية في Excel. اختر **تعديل نطاق الخلايا** إذا كنت تريد حجمًا ثابتًا لإطار OLE في العرض.

**س:** هل ستعمل هذه الحلول إذا كان العرض مبنيًا على قالب؟  
نعم. كلا الحلين يعملان للعروض التي تم إنشاؤها من القوالب أو من الصفر.

**س:** هل هناك حد لحجم إطار OLE عند استخدام هذه الطرق؟  
لا. يمكنك جعل إطار كائن OLE بأي حجم طالما قمت بضبط المقياس بشكل مناسب.

**س:** هل هناك طريقة لتجنب نص العنصر النائب "EMBEDDED OLE OBJECT" في PowerPoint؟  
نعم. من خلال أخذ لقطة للنطاق المستهدف من خلايا Excel وتعيينها كصورة العنصر النائب لإطار OLE، يمكنك عرض صورة معاينة مخصصة بدلاً من العنصر النائب الافتراضي.

## **مقالات ذات صلة**

[إنشاء مخطط Excel وتضمينه في عرض ككائن OLE](/slides/ar/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[تحديث كائنات OLE تلقائيًا باستخدام إضافة MS PowerPoint](/slides/ar/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)