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
- ورقة عمل
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إصلاح تغيير حجم ورقة عمل Excel ككائن OLE في العروض التقديمية: طريقتان للحفاظ على إطارات الكائن ثابتة — إما بتحجيم الإطار أو الورقة — عبر صيغ PPT و PPTX."
---
{{% alert color="info" title="Note" %}}
قد يتم تغيير حجم أوراق عمل Excel المدمجة ككائنات OLE في عرض تقديمي PowerPoint باستخدام مكونات Aspose بشكل غير متوقع بعد التفعيل الأول. يؤدي هذا السلوك إلى فرق بصري ملحوظ بين كائن OLE قبل وبعد التفعيل. يشرح هذا المقال المشكلة ويصف طريقتين لمعالجتها.
{{% /alert %}} 

## **الخلفية**

في المقالة [Manage OLE](/slides/ar/net/manage-ole/)، شرحنا كيفية إضافة إطار OLE إلى عرض تقديمي PowerPoint باستخدام Aspose.Slides for .NET. لمعالجة [object preview issue](/slides/ar/net/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة لمنطقة ورقة العمل المحددة إلى إطار كائن OLE. في العرض الناتج، عند النقر المزدوج على إطار كائن OLE الذي يعرض صورة ورقة العمل، يتم تنشيط مصنف Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات مرغوبة على المصنف الفعلي ثم العودة إلى الشريحة بالنقر خارج المصنف النشط. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. سيتفاوت عامل تغيير الحجم اعتمادًا على حجم إطار كائن OLE والمصنف المدمج.

## **سبب تغيير الحجم**

نظرًا لأن مصنف Excel له حجمه الخاص في النافذة، فإنه يحاول الحفاظ على حجمه الأصلي عند التفعيل الأول. من ناحية أخرى، يمتلك إطار كائن OLE حجمه الخاص. وفقًا لمايكروسوفت، عند تنشيط مصنف Excel، يتفاوض Excel وPowerPoint على الحجم لضمان الحفاظ على النسب الصحيحة كجزء من عملية الدمج. يحدث تغيير الحجم بناءً على الفروقات بين حجم نافذة Excel وحجم وموقع إطار كائن OLE.

## **الحل العملي**

هناك حلان محتملان لتجنب تأثير تغيير الحجم.

- قياس إطار OLE في عرض PowerPoint ليتطابق مع الارتفاع والعرض الكلي للصفوف والأعمدة المحددة.
- الحفاظ على حجم إطار OLE ثابتًا وتغيير حجم الصفوف والأعمدة المحددة لتتناسب معه.

### **قياس حجم إطار OLE**

تحدد هذه الطريقة حجم إطار OLE ليتطابق مع الارتفاع والعرض الكلي للصفوف والأعمدة المحددة في ورقة Excel المدمجة.

يقوم المثال بتحميل مصنف Excel موجود ويختار أول 10 صفوف و13 عمودًا من ورقة العمل الأولى باستخدام فهارس بدءًا من الصفر. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) يحدد النطاق المعروض. يتم إنشاء معاينة بدقة 96 DPI، وتُحول أبعاد البكسل إلى نقاط باستخدام 72 نقطة لكل بوصة. [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) يدمج المصنف المعدل في إطار بهذه الأبعاد. تُعيّن المعاينة عبر [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) لاستبدال العنصر النائب "EMBEDDED OLE OBJECT" في العرض المحفوظ.

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

// حدد الحجم المعروض عند استخدام ملف المصنف ككائن OLE في PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// We need to use the modified workbook.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Add the OLE image to the presentation resources.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Create the OLE object frame.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

يقوم مساعد المعاينة بتحديد [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) إلى النطاق المحدد وإزالة الهوامش والرؤوس والتذييلات. عند تمكين [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/)، تقوم [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) بتحويل النطاق إلى صورة PNG. يعيد المساعد موضع تدفق الصورة إلى البداية قبل إرجاعه للاستخدام في العرض.

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

### **قياس حجم نطاق الخلية**

تقوم هذه الطريقة بتغيير ارتفاعات الصفوف المحددة وعرض الأعمدة المحددة لتتناسب مع حجم إطار OLE مخصص.

يقوم المثال بتحميل مصنف Excel موجود ويختار أول 10 صفوف و13 عمودًا من ورقة العمل الأولى باستخدام فهارس صفرية. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) يحدد النطاق المعروض، ويساعد المساعد أدناه على تغيير حجم ذلك النطاق ليلائم إطار بعرض 400 نقطة وارتفاع 100 نقطة. بعد حفظ المصنف المعدل إلى تدفق، يدمج [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/)ه في الحجم المحدد. تُعيّن معاينة بدقة 96 DPI عبر [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/)، بحيث يعرض العرض المحفوظ الخلايا المحددة بدلاً من العنصر النائب الافتراضي.

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

// حدد الحجم المعروض عند استخدام ملف المصنف ككائن OLE في PowerPoint.
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

يحسب مساعد التحجيم نسب العرض والارتفاع المنفصلة للنطاق المحدد، مع الحفاظ على العرض النسبي لأعمدته والارتفاع النسبي لصفوفه. يُحول الأبعاد المحسوبة من نقاط إلى بوصات قبل تطبيقها باستخدام [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) و[Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/). يجب أن يكون للنطاق المختار عرض وارتفاع غير صفري.

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

يقوم هذا المساعد في المعاينة بتحويل النطاق المتغير إلى صورة باستخدام [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/). يقتصر [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) على ذلك النطاق، ويزيل الهوامش والرؤوس والتذييلات، ويعيد تدفق PNG في بدايته.

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

## **الخلاصة**

{{% alert color="info" title="Note" %}}
هناك طريقتان لحل مشكلة تغيير حجم ورقة العمل. اختر الطريقة التي تتناسب مع متطلباتك وحالتك الاستخدامية. كلا الطريقتين تعملان بنفس الطريقة، سواء تم إنشاء العروض من قالب أو من الصفر. بالإضافة إلى ذلك، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.
{{% /alert %}}

## **الأسئلة الشائعة**

**لماذا يتغير حجم ورقة عمل Excel المدمجة عند تفعيلها لأول مرة في PowerPoint؟**

يحدث هذا لأن Excel يحاول الحفاظ على حجم النافذة الأصلي عند التفعيل، بينما يمتلك إطار كائن OLE في PowerPoint أبعاده الخاصة. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يتسبب في تغيير الحجم.

**هل من الممكن منع مشكلة تغيير الحجم هذه تمامًا؟**

نعم. عن طريق تغيير حجم إطار OLE ليتناسب مع حجم نطاق خلايا Excel أو تغيير حجم النطاق ليتناسب مع حجم إطار OLE المطلوب، يمكنك منع تغيير الحجم غير المرغوب فيه.

**أي طريقة تحجيم يجب أن أستخدمها، تحجيم إطار OLE أم تحجيم نطاق الخلايا؟**

اختر **OLE frame scaling** إذا كنت تريد الحفاظ على أحجام الصفوف والأعمدة الأصلية في Excel. اختر **cell range scaling** إذا كنت تريد حجمًا ثابتًا لإطار OLE في عرضك.

**هل ستعمل هذه الحلول إذا كان العرض التقديمي مبنيًا على قالب؟**

نعم. كلا الحلين يعملان للعروض التي تم إنشاؤها من القوالب وكذلك من الصفر.

**هل هناك حد لحجم إطار OLE عند استخدام هذه الطرق؟**

لا. يمكنك جعل إطار كائن OLE بأي حجم بقدر ما تقوم بضبط التحجيم بشكل مناسب.

**هل هناك طريقة لتجنب نص العنصر النائب "EMBEDDED OLE OBJECT" في PowerPoint؟**

نعم. عن طريق أخذ لقطة لنطاق خلايا Excel الهدف وتعيينها كصورة العنصر النائب لإطار OLE، يمكنك عرض صورة معاينة مخصصة بدلاً من العنصر النائب الافتراضي.

## **المقالات ذات الصلة**

[إنشاء مخطط Excel وتضمينه في عرض تقديمي ككائن OLE](/slides/ar/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[تحديث كائنات OLE تلقائيًا باستخدام إضافة MS PowerPoint](/slides/ar/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)