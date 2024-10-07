---
title: حل عملي لتغيير حجم ورقة العمل
type: docs
weight: 40
url: /net/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

لقد لوحظ أن أوراق Excel المدمجة كـ OLE في عرض PowerPoint التقديمي من خلال مكونات Aspose يتم إعادة تغيير حجمها إلى مقياس غير محدد بعد التنشيط لأول مرة. هذه السلوك يخلق فرقًا بصريًا كبيرًا في العرض بين حالات التنشيط قبل وبعد. لقد قمنا بالتحقيق في هذه المشكلة بالتفصيل ووجدنا الحل لهذه المشكلة الذي تم تغطيته في هذه المقالة. 

{{% /alert %}} 
## **الخلفية**
في [مقال إضافة إطارات Ole](), قمنا بشرح كيفية إضافة إطار Ole في العرض التقديمي في عرض PowerPoint باستخدام Aspose.Slides لـ .NET. من أجل استيعاب [مشكلة تغيير الكائن](/slides/net/object-changed-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة ورقة العمل للمنطقة المحددة إلى إطار OLE Object. في العرض الناتج، عند النقر المزدوج على إطار OLE Object الذي يظهر صورة ورقة العمل، يتم تنشيط مخطط Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات مرغوبة في دفتر عمل Excel الفعلي ثم العودة إلى الشريحة المعنية عن طريق النقر خارج دفتر عمل Excel المنشط. سيتغير حجم إطار OLE Object عندما يعود المستخدم إلى الشريحة. سيكون عامل إعادة الحجم مختلفًا لأحجام مختلفة من إطار OLE Object ودفتر عمل Excel المدمج. 
## **سبب إعادة الحجم**
نظرًا لأن دفتر عمل Excel له حجمه الخاص من النافذة، فإنه يحاول الاحتفاظ بحجمه الأصلي عند التنشيط لأول مرة. من ناحية أخرى، سيكون لإطار OLE Object حجمه الخاص. وفقًا لشركة Microsoft، عند تنشيط دفتر عمل Excel، تتفاوض Excel وPowerPoint على الحجم وتضمن أنه في النسب الصحيحة كجزء من عملية التضمين. استنادًا إلى الفروق في حجم نافذة Excel وحجم إطار OLE Object / موضعه، يحدث إعادة الحجم. 
## **الحل العملي**
هناك حلان ممكنان لتجنب تأثير إعادة الحجم.

- تغيير حجم إطار Ole في PPT ليتناسب مع الحجم من حيث الارتفاع / العرض لعدد الصفوف / الأعمدة المطلوبة في إطار Ole
- الحفاظ على حجم إطار Ole ثابت وتغيير حجم الصفوف / الأعمدة المشاركة لتناسب حجم إطار Ole المحدد
## **تغيير حجم إطار Ole ليتناسب مع حجم الصفوف / الأعمدة المحددة في ورقة العمل**
في هذا النهج، سنتعلم كيفية تعيين حجم إطار Ole لدفتر عمل Excel المدمج ليكون مكافئًا للحجم التراكمي لعدد الصفوف والأعمدة المشاركة في ورقة Excel. 
## **مثال**
افترض أننا عرفنا ورقة Excel نموذجية ونرغب في إضافة ذلك إلى العرض التقديمي كإطار Ole. في هذا السيناريو، سيتم حساب حجم إطار OLE Object أولاً بناءً على ارتفاع الصفوف التراكمي وعرض الأعمدة للصفوف والأعمدة المشاركة على التوالي. ثم سنقوم بتعيين حجم إطار Ole إلى تلك القيمة المحسوبة. لتجنب رسالة **الكائن المدمج** الحمراء لإطار Ole في PowerPoint، سنحصل أيضًا على صورة للأجزاء المطلوبة من الصفوف والأعمدة في دفتر العمل ونقوم بتعيينها كصورة إطار Ole. 

```csharp
WorkbookDesigner workbookDesigner = new WorkbookDesigner();
workbookDesigner.Workbook = new Workbook("AsposeTest.xls");

Presentation presentation = new Presentation("AsposeTest.ppt");

Slide slide = (Slide)presentation.Slides[0];

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

String fileName = "AsposeTest_Ole.ppt";
presentation.Save(fileName, Aspose.Slides.Export.SaveFormat.Ppt);
```

```csharp
private static Size SetOleAccordingToSelectedRowsCloumns(Workbook workbook, Int32 startRow, Int32 endRow, Int32 startCol,Int32 endCol, Int32 dataSheetIdx)
{
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    double actualHeight = 0, actualWidth = 0;

    for (int i = startRow; i <= endRow; i++)
        actualHeight += work.Cells.GetRowHeightInch(i);

    for (int i = startCol; i <= endCol; i++)
        actualWidth += work.Cells.GetColumnWidthInch(i);
    //تعيين ارتفاع الصف وعمود جديد

    return new Size((int)(Math.Round(actualWidth, 2) * 576), (int)(Math.Round(actualHeight, 2) * 576));
}
```
```csharp
private static void AddOleFrame(Slide slide, Int32 startRow, Int32 endRow, Int32 startCol, Int32 endCol,
    Int32 dataSheetIdx, Int32 x, Int32 y, Double OleWidth, Double OleHeight,
    Presentation presentation, WorkbookDesigner workbookDesigner,
    Boolean onePagePerSheet, Int32 outputWidth, Int32 outputHeight)
{
    String tempFileName = Path.GetTempFileName();
    if (startRow == 0)
    {
        startRow++;
        endRow++;
    }

    //تعيين فهرس ورقة العمل النشطة في دفتر العمل
    workbookDesigner.Workbook.Worksheets.ActiveSheetIndex = dataSheetIdx;

    //الحصول على دفتر العمل وورقة العمل المحددة  
    Workbook workbook = workbookDesigner.Workbook;
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    //تعيين حجم Ole وفقًا للصفوف والأعمدة المحددة
    Size SlideOleSize = SetOleAccordingToSelectedRowsCloumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.Width;
    OleHeight = SlideOleSize.Height;

    //تعيين حجم Ole في دفتر العمل
    workbook.Worksheets.SetOleSize(startRow, endRow, startCol, endCol);

    workbook.Worksheets[0].IsGridlinesVisible = false;

    //تعيين خيارات الصورة لأخذ صورة ورقة العمل
    ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
    imageOrPrintOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
    imageOrPrintOptions.OnePagePerSheet = onePagePerSheet;

    SheetRender render = new SheetRender(workbookDesigner.Workbook.Worksheets[dataSheetIdx], imageOrPrintOptions);
    String ext = ".bmp";
    render.ToImage(0, tempFileName + ext);
    Image image = ScaleImage(Image.FromFile(tempFileName + ext), outputWidth, outputHeight);
    String newTempFileName = tempFileName.Replace(".tmp", ".tmp1") + ext;
    image.Save(newTempFileName, System.Drawing.Imaging.ImageFormat.Bmp);

    //إضافة الصورة إلى مجموعة صور الشريحة
    var ppImage = presentation.Images.AddImage(File.ReadAllBytes(newTempFileName));

    //حفظ دفتر العمل إلى البث ونسخه في مصفوفة البايت
    Stream mstream = workbook.SaveToStream();
    byte[] chartOleData = new byte[mstream.Length];
    mstream.Position = 0;
    mstream.Read(chartOleData, 0, chartOleData.Length);

    //إضافة إطار كائن Ole
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(x, y, Convert.ToInt32(OleWidth),
        Convert.ToInt32(OleHeight), dataInfo);

    //تعيين اسم إطار ole الخاص وبديل النص    
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    oleObjectFrame.AlternativeText = "image" + ppImage;
}
```

```csharp
private static Image ScaleImage(Image image, Int32 outputWidth, Int32 outputHeight)
{
    if (outputWidth == 0 && outputHeight == 0)
    {
        outputWidth = image.Width;
        outputHeight = image.Height;
    }
    Bitmap outputImage = new Bitmap(outputWidth, outputHeight, image.PixelFormat);
    outputImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
    Graphics graphics = Graphics.FromImage(outputImage);
    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    System.Drawing.Rectangle srcDestRect = new System.Drawing.Rectangle(0, 0, outputWidth, outputHeight);
    graphics.DrawImage(image, srcDestRect, srcDestRect, GraphicsUnit.Pixel);
    graphics.Dispose();

    return outputImage;
}
```

## **تغيير ارتفاع الصفوف وعرض الأعمدة في ورقة العمل وفقًا لحجم إطار Ole**
في هذا النهج، سنتعلم كيفية تغيير ارتفاعات الصفوف المشاركة وعرض العمود المشاركة وفقًا لحجم إطار Ole المحدد
## **مثال**
افترض أننا عرفنا ورقة Excel نموذجية ونرغب في إضافة ذلك إلى العرض التقديمي كإطار Ole. في هذا السيناريو، سنقوم بتعيين حجم إطار Ole وتغيير حجم الصفوف والأعمدة المشاركة في منطقة إطار Ole. ثم سنقوم بحفظ دفتر العمل في دفق لحفظ التغييرات وتحويل ذلك إلى مصفوفة بايت لإضافته في إطار Ole. لتجنب رسالة **الكائن المدمج** الحمراء لإطار Ole في PowerPoint، سنحصل أيضًا على صورة للأجزاء المطلوبة من الصفوف والأعمدة في دفتر العمل ونقوم بتعيينها كصورة إطار Ole. 

```csharp
WorkbookDesigner workbookDesigner = new WorkbookDesigner();
workbookDesigner.Workbook = new Workbook("AsposeTest.xls");

Presentation presentation = new Presentation("AsposeTest.ppt");

Slide slide = (Slide)presentation.Slides[0];

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

String fileName = "AsposeTest_Ole.ppt";
presentation.Save(fileName, Aspose.Slides.Export.SaveFormat.Ppt);
```

```csharp
private static void SetOleAccordingToCustomHeighWidth(Workbook workbook, Int32 startRow,
    Int32 endRow, Int32 startCol, Int32 endCol, double slideWidth, double slideHeight, Int32 dataSheetIdx)
{
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    double actualHeight = 0, actualWidth = 0;

    double newHeight = slideHeight;
    double newWidth = slideWidth;
    double tem = 0;
    double newTem = 0;

    for (int i = startRow; i <= endRow; i++)
        actualHeight += work.Cells.GetRowHeightInch(i);

    for (int i = startCol; i <= endCol; i++)
        actualWidth += work.Cells.GetColumnWidthInch(i);
    ///تعيين ارتفاع الصف وعمود جديد

    for (int i = startRow; i <= endRow; i++)
    {
        tem = work.Cells.GetRowHeightInch(i);
        newTem = (tem / actualHeight) * newHeight;
        work.Cells.SetRowHeightInch(i, newTem);
    }

    for (int i = startCol; i <= endCol; i++)
    {
        tem = work.Cells.GetColumnWidthInch(i);
        newTem = (tem / actualWidth) * newWidth;
        work.Cells.SetColumnWidthInch(i, newTem);

    }
}

```

```csharp
private static void AddOleFrame(Slide slide, Int32 startRow, Int32 endRow, Int32 startCol, Int32 endCol,
    Int32 dataSheetIdx, Int32 x, Int32 y, Double OleWidth, Double OleHeight,
    Presentation presentation, WorkbookDesigner workbookDesigner,
    Boolean onePagePerSheet, Int32 outputWidth, Int32 outputHeight)
{
    String tempFileName = Path.GetTempFileName();
    if (startRow == 0)
    {
        startRow++;
        endRow++;
    }

    //تعيين فهرس ورقة العمل النشطة في دفتر العمل
    workbookDesigner.Workbook.Worksheets.ActiveSheetIndex = dataSheetIdx;

    //الحصول على دفتر العمل وورقة العمل المحددة  
    Workbook workbook = workbookDesigner.Workbook;
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    //تعيين حجم Ole وفقًا للصفوف والأعمدة المحددة
    Size SlideOleSize = SetOleAccordingToSelectedRowsCloumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.Width;
    OleHeight = SlideOleSize.Height;

    //تعيين حجم Ole في دفتر العمل
    workbook.Worksheets.SetOleSize(startRow, endRow, startCol, endCol);

    workbook.Worksheets[0].IsGridlinesVisible = false;

    //تعيين خيارات الصورة لأخذ صورة ورقة العمل
    ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
    imageOrPrintOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
    imageOrPrintOptions.OnePagePerSheet = onePagePerSheet;

    SheetRender render = new SheetRender(workbookDesigner.Workbook.Worksheets[dataSheetIdx], imageOrPrintOptions);
    String ext = ".bmp";
    render.ToImage(0, tempFileName + ext);
    Image image = ScaleImage(Image.FromFile(tempFileName + ext), outputWidth, outputHeight);
    String newTempFileName = tempFileName.Replace(".tmp", ".tmp1") + ext;
    image.Save(newTempFileName, System.Drawing.Imaging.ImageFormat.Bmp);

    //إضافة الصورة إلى مجموعة صور الشريحة
    var ppImage = presentation.Images.AddImage(File.ReadAllBytes(newTempFileName));

    //حفظ دفتر العمل إلى البث ونسخه في مصفوفة البايت
    Stream mstream = workbook.SaveToStream();
    byte[] chartOleData = new byte[mstream.Length];
    mstream.Position = 0;
    mstream.Read(chartOleData, 0, chartOleData.Length);

    //إضافة إطار كائن Ole
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(x, y, Convert.ToInt32(OleWidth),
        Convert.ToInt32(OleHeight), dataInfo);

    //تعيين اسم إطار ole الخاص وبديل النص    
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    oleObjectFrame.AlternativeText = "image" + ppImage;
}
```

```csharp
private static Image ScaleImage(Image image, Int32 outputWidth, Int32 outputHeight)
{
    if (outputWidth == 0 && outputHeight == 0)
    {
        outputWidth = image.Width;
        outputHeight = image.Height;
    }
    Bitmap outputImage = new Bitmap(outputWidth, outputHeight, image.PixelFormat);
    outputImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
    Graphics graphics = Graphics.FromImage(outputImage);
    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    System.Drawing.Rectangle srcDestRect = new System.Drawing.Rectangle(0, 0, outputWidth, outputHeight);
    graphics.DrawImage(image, srcDestRect, srcDestRect, GraphicsUnit.Pixel);
    graphics.Dispose();

    return outputImage;
}
```


## **الاستنتاج**


{{% alert color="primary" %}}  هناك نهجان لحل مشكلة تغيير حجم ورقة العمل. يعتمد اختيار النهج المناسب على المتطلبات وحالة الاستخدام. يعمل كلا النهجين بنفس الطريقة سواء تم إنشاء العروض التقديمية من نموذج أو إنشاؤها من الصفر. أيضًا، لا يوجد حد لحجم إطار OLE Object في الحل. {{% /alert %}} 
## **الأقسام ذات الصلة**
[إنشاء وتضمين مخطط Excel ككائن OLE في العرض التقديمي](/slides/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[تحديث كائنات OLE تلقائيًا](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)