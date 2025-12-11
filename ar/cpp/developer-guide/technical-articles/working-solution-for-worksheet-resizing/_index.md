---
title: حل عملي لتغيير حجم ورقة العمل
type: docs
weight: 130
url: /ar/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- صورة معاينة
- تغيير حجم الصورة
- Excel
- ورقة عمل
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides for C++
description: "حل عملي لتغيير حجم ورقة العمل في عروض PowerPoint باستخدام C++"
---

{{% alert color="primary" %}}
تم ملاحظة أن أوراق عمل Excel المدمجة ككائنات OLE في عرض PowerPoint عبر مكونات Aspose يتم تغيير حجمها إلى مقياس غير معروف بعد التنشيط الأول. يخلق هذا السلوك فرقًا مرئيًا ملحوظًا في العرض بين حالتي ما قبل وما بعد تنشيط كائن OLE. لقد قمنا بالتحقيق في هذه المشكلة بالتفصيل وقدمنا حلاً، وهو مغطى في هذه المقالة.
{{% /alert %}}

## **الخلفية**

في المقالة [إدارة OLE](/slides/ar/cpp/manage-ole/)، شرحنا كيفية إضافة إطار OLE إلى عرض PowerPoint باستخدام Aspose.Slides for C++. لمعالجة [مشكلة معاينة الكائن](/slides/ar/cpp/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة لمنطقة ورقة العمل المختارة إلى إطار كائن OLE. في العرض الناتج، عند النقر المزدوج على إطار كائن OLE الذي يعرض صورة ورقة العمل، يتم تنشيط مصنف Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات مرغوبة على مصنف Excel الفعلي ثم العودة إلى الشريحة بالنقر خارج مصنف Excel المنشط. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. سيختلف معامل تغيير الحجم اعتمادًا على حجم إطار كائن OLE ومصنف Excel المدمج.

## **سبب تغيير الحجم**

نظرًا لأن لمصنف Excel نافذة بالحجم الخاص به، فإنه يحاول الحفاظ على حجمه الأصلي عند التنشيط الأول. من ناحية أخرى، يمتلك إطار كائن OLE حجمه الخاص. وفقًا لمايكروسوفت، عند تنشيط مصنف Excel، يتفاوض Excel وPowerPoint على الحجم لضمان الحفاظ على النسب الصحيحة كجزء من عملية الدمج. يحدث تغيير الحجم بناءً على الفروق بين حجم نافذة Excel وحجم وموقع إطار كائن OLE.

## **الحل العملي**

هناك حلان محتملان لتجنب تأثير تغيير الحجم.

- تحجيم حجم إطار OLE في عرض PowerPoint ليتوافق مع الطول والعرض للعدد المطلوب من الصفوف والأعمدة في إطار OLE.
- الإبقاء على حجم إطار OLE ثابتًا وتحجيم حجم الصفوف والأعمدة المشاركة لتتناسب مع حجم إطار OLE المحدد.

### **تحجيم حجم إطار OLE**

في هذا النهج، سنتعلم كيفية ضبط حجم إطار OLE للمصنف المدمج ليتوافق مع الحجم التراكمي للصفوف والأعمدة المشاركة في ورقة عمل Excel.

لنفترض أن لدينا قالب ورقة Excel ونريد إضافتها إلى عرض تقديمي كإطار OLE. في هذا السيناريو، سيُحسب أولاً حجم إطار كائن OLE بناءً على الارتفاعات التراكمية للصفوف والعروض التراكمية للأعمدة المشاركة في المصنف. ثم سنضبط حجم إطار OLE على هذه القيمة المحسوبة. لتجنب رسالة "EMBEDDED OLE OBJECT" الحمراء لإطار OLE في PowerPoint، سنلتقط صورة للأجزاء المطلوبة من الصفوف والأعمدة في المصنف ونعيّنها كصورة لإطار OLE.
```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// ضبط الحجم المعروض عندما يُستخدم ملف المصنف ككائن OLE في PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// احصل على عرض وارتفاع صورة OLE بالنقاط.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// نحتاج إلى استخدام المصنف المعدل.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// إضافة صورة OLE إلى موارد العرض التقديمي.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// إنشاء إطار كائن OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```


### **تحجيم حجم نطاق الخلايا**

في هذا النهج، سنتعلم كيفية تحجيم ارتفاعات الصفوف المشاركة وعرض الأعمدة المشاركة لتتناسب مع حجم إطار OLE مخصص.

لنفترض أن لدينا قالب ورقة Excel ونريد إضافتها إلى عرض تقديمي كإطار OLE. في هذا السيناريو، سنضبط حجم إطار OLE ونقوّم حجم الصفوف والأعمدة التي تشارك في مساحة إطار OLE. ثم سنحفظ المصنف إلى تدفق لتطبيق التغييرات ونحوّله إلى مصفوفة بايت لإضافته إلى إطار OLE. لتجنب رسالة "EMBEDDED OLE OBJECT" الحمراء لإطار OLE في PowerPoint، سنلتقط صورة للأجزاء المطلوبة من الصفوف والأعمدة في المصنف ونعيّنها كصورة لإطار OLE.
```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// ضبط الحجم المعروض عند استخدام ملف المصنف ككائن OLE في PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// تحجيم نطاق الخلايا ليتناسب مع حجم الإطار.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// نحتاج إلى استخدام المصنف المعدل.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// إضافة صورة OLE إلى موارد العرض التقديمي.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// إنشاء إطار كائن OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```


```cpp
/// <param name="width">العرض المتوقع لنطاق الخلايا بالنقاط.</param>
/// <param name="height">الارتفاع المتوقع لنطاق الخلايا بالنقاط.</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cpp
SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```


## **الخلاصة**
{{% alert color="primary" %}}
هناك نهجان لإصلاح مشكلة تغيير حجم ورقة العمل. يعتمد اختيار النهج المناسب على المتطلبات وحالة الاستخدام المحددة. كلا النهجين يعملان بنفس الطريقة، سواء تم إنشاء العروض من قالب أو من الصفر. بالإضافة إلى ذلك، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.
{{% /alert %}}

## **الأسئلة المتكررة**

**لماذا يتغير حجم ورقة Excel المدمجة عند تنشيطها لأول مرة في PowerPoint؟**  
يحدث ذلك لأن Excel يحاول الحفاظ على حجم نافذته الأصلي عند التنشيط، بينما يمتلك إطار كائن OLE في PowerPoint أبعاده الخاصة. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة الأبعاد، مما قد يسبب تغيير الحجم.

**هل يمكن منع مشكلة تغيير الحجم هذه تمامًا؟**  
نعم. من خلال تحجيم إطار OLE ليتناسب مع حجم نطاق خلايا Excel أو تحجيم نطاق الخلايا ليتناسب مع حجم إطار OLE المطلوب، يمكنك منع تغيير الحجم غير المرغوب.

**أي طريقة تحجيم يجب أن أستخدم، تحجيم إطار OLE أم تحجيم نطاق الخلايا؟**  
اختر **تحجيم إطار OLE** إذا أردت الحفاظ على أحجام الصفوف والأعمدة الأصلية في Excel. اختر **تحجيم نطاق الخلايا** إذا رغبت في الحصول على حجم ثابت لإطار OLE في عرضك.

**هل ستعمل هذه الحلول إذا كان العرض مبنيًا على قالب؟**  
نعم. كلا الحلين يعملان للعروض التي تم إنشاؤها من القوالب أو من الصفر.

**هل هناك حد لحجم إطار OLE عند استخدام هذه الأساليب؟**  
لا. يمكنك ضبط إطار كائن OLE لأي حجم طالما قمت بتحديد معامل التحجيم بشكل مناسب.

**هل هناك طريقة لتجنب نص العنصر النائب "EMBEDDED OLE OBJECT" في PowerPoint؟**  
نعم. من خلال التقاط لقطة لنطاق خلايا Excel المستهدف وتعيينها كصورة عنصر نائب لإطار OLE، يمكنك عرض صورة معاينة مخصصة بدلاً من العنصر النائب الافتراضي.

## **مقالات ذات صلة**

[إنشاء مخطط Excel وتضمينه في عرض تقديمي ككائن OLE](/slides/ar/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)