---
title: حل عملي لتغيير حجم ورقة العمل
type: docs
weight: 130
url: /cpp/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

تمت ملاحظة أن أوراق عمل Excel المدمجة كـ OLE في عرض PowerPoint من خلال مكونات Aspose تتغير إلى مقياس غير معروف بعد التفعيل الأول. تتسبب هذه الظاهرة في فرق بصري ملحوظ في العرض بين حالات تنشيط الرسم البياني السابقة واللاحقة. لقد قمنا بالتحقيق في هذه المشكلة بالتفصيل ووجدنا الحل لهذه المشكلة التي تم تناولها في هذه المقالة.

{{% /alert %}} 
## **الخلفية**
في مقال إضافة إطارات Ole، أوضحنا كيفية إضافة إطار Ole في العرض التقديمي في عرض PowerPoint باستخدام Aspose.Slides لـ C++. من أجل استيعاب قضية تغيير الكائن، قمنا بتعيين صورة ورقة العمل للمنطقة المحددة إلى إطار كائن الرسم البياني OLE. في العرض الناتج، عندما نقوم بالنقر المزدوج على إطار كائن OLE الذي يظهر صورة ورقة العمل، يتم تنشيط رسم Excel. يمكن لمستخدمي النهاية إجراء أي تغييرات مرغوبة في كتاب Excel الفعلي ثم العودة إلى الشريحة المعنية عن طريق النقر خارج مكتبة Excel المفعلة. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. سيكون عامل تغيير الحجم مختلفًا لأحجام مختلفة من إطار كائن OLE وكتاب Excel المدمج.
## **سبب تغيير الحجم**
نظرًا لأن مكتبة Excel لها حجم نافذة خاص بها، فإنها تحاول الاحتفاظ بحجمها الأصلي عند التفعيل الأول. من ناحية أخرى، سيكون لإطار كائن OLE حجمه الخاص. وفقًا لـ Microsoft، عند تنشيط مكتبة Excel، تتفاوض Excel و PowerPoint على الحجم وتضمن أنه في النسب الصحيحة كجزء من عملية التضمين. بناءً على الاختلافات في حجم Windows Excel وحجم/موضع إطار كائن OLE، يحدث تغيير الحجم.
## **الحل العملي**
هناك حلان محتملان لتجنب تأثير إعادة تغيير الحجم.

- تغيير حجم إطار Ole في PPT ليتناسب مع الحجم من حيث ارتفاع/عرض عدد الصفوف/الأعمدة المرغوبة في إطار Ole
- الحفاظ على حجم إطار Ole ثابتًا وتغيير حجم الصفوف/الأعمدة المشاركة لتناسب حجم إطار Ole المحدد
## **تغيير حجم إطار Ole ليتناسب مع حجم الصفوف/الأعمدة المحددة في ورقة العمل**
في هذا النهج، سنتعلم كيفية تعيين حجم إطار Ole لكتاب Excel المدمج بما يتناسب مع الحجم التراكمي لعدد الصفوف والأعمدة المشاركة في ورقة العمل Excel.
## **مثال**
افترض أننا قمنا بتعريف ورقة Excel نموذجية ونرغب في إضافتها إلى العرض التقديمي كإطار Ole. في هذا السيناريو، سيتم حساب حجم إطار كائن OLE أولاً بناءً على ارتفاع الصفوف التراكمي وعرض الأعمدة للصفوف والأعمدة الخاصة بالمكتبة المعنية. ثم سنقوم بتعيين حجم إطار Ole إلى تلك القيمة المحسوبة. لتجنب رسالة **كائن مدمج** الحمراء لإطار Ole في PowerPoint، سنقوم أيضًا بالحصول على صورة للأجزاء المرغوبة من الصفوف والأعمدة في المكتبة وتعيين ذلك كصورة إطار Ole.

``` cpp
auto workbookDesigner = Aspose::Cells::Factory::CreateIWorkbookDesigner();
workbookDesigner->SetIWorkbook(Aspose::Cells::Factory::CreateIWorkbook(new Aspose::Cells::Systems::String("d:/AsposeTest.xls")));

System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>(u"d:/AsposeTest.ppt");
System::SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

System::String fileName = u"d:/AsposeTest_Ole.ppt";
presentation->Save(fileName, Export::SaveFormat::Pptx);
```

``` cpp
System::Drawing::Size SetOleAccordingToSelectedRowsColumns(intrusive_ptr<Aspose::Cells::IWorkbook> workbook, int32_t startRow, int32_t endRow, int32_t startCol, int32_t endCol, int32_t dataSheetIdx)
{
    intrusive_ptr<Aspose::Cells::IWorksheet> work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);

    double actualHeight = 0, actualWidth = 0;

    for (int32_t i = startRow; i <= endRow; i++)
    {
        actualHeight += work->GetICells()->GetRowHeightInch(i);
    }

    for (int32_t i = startCol; i <= endCol; i++)
    {
        actualWidth += work->GetICells()->GetColumnWidthInch(i);
    }

    // ضبط ارتفاع الصف والعمود الجديد
    return System::Drawing::Size((int32_t)(System::Math::Round(actualWidth, 2) * 576), (int32_t)(System::Math::Round(actualHeight, 2) * 576));
}
```

``` cpp
void AddOleFrame(System::SharedPtr<ISlide> slide, int32_t startRow, int32_t endRow,
    int32_t startCol, int32_t endCol, int32_t dataSheetIdx, int32_t x, int32_t y,
    double OleWidth, double OleHeight, System::SharedPtr<IPresentation> presentation, 
    intrusive_ptr<Aspose::Cells::IWorkbookDesigner> workbookDesigner, 
    bool onePagePerSheet, int32_t outputWidth, int32_t outputHeight)
{
    std::wstring tempFileName = System::IO::Path::GetTempFileName_().ToWCS();
    if (startRow == 0)
    {
        startRow++;
        endRow++;
    }

    // ضبط مؤشر ورقة العمل النشطة للمكتبة
    workbookDesigner->GetIWorkbook()->GetIWorksheets()->SetActiveSheetIndex(dataSheetIdx);

    // الحصول على المكتبة وورقة العمل المحددة  
    intrusive_ptr<Aspose::Cells::IWorkbook> workbook = workbookDesigner->GetIWorkbook();
    intrusive_ptr<Aspose::Cells::IWorksheet> work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);

    // ضبط حجم Ole وفقاً للصفوف والأعمدة المحددة
    System::Drawing::Size SlideOleSize = SetOleAccordingToSelectedRowsColumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.get_Width();
    OleHeight = SlideOleSize.get_Height();

    // تعيين حجم Ole في المكتبة
    workbook->GetIWorksheets()->SetOleSize(startRow, endRow, startCol, endCol);

    workbook->GetIWorksheets()->GetObjectByIndex(0)->SetGridlinesVisible(false);

    // ضبط خيارات الصورة لأخذ صورة ورقة العمل
    intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> imageOrPrintOptions = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
    imageOrPrintOptions->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetBmp());
    imageOrPrintOptions->SetOnePagePerSheet(onePagePerSheet);

    intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> render = Aspose::Cells::Factory::CreateISheetRender(workbookDesigner->GetIWorkbook()->GetIWorksheets()->GetObjectByIndex(dataSheetIdx), imageOrPrintOptions);
    tempFileName.append(L".bmp");
    render->ToImage(0, new String(tempFileName.c_str()));
    
    System::String slidesTempFileName = System::String::FromWCS(tempFileName);
    System::SharedPtr<System::Drawing::Image> image = ScaleImage(System::Drawing::Image::FromFile(slidesTempFileName), outputWidth, outputHeight);
    System::String newTempFileName = slidesTempFileName.Replace(u".tmp", u".tmp1");
    image->Save(newTempFileName, System::Drawing::Imaging::ImageFormat::get_Bmp());

    // إضافة الصورة إلى مجموعة الصور في الشريحة
    auto ppImage = presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(newTempFileName));

    // حفظ المكتبة إلى تدفق ونسخها في مصفوفة بت
    System::SharedPtr<System::IO::Stream> mstream = ToSlidesMemoryStream(workbook->SaveToStream());
    System::ArrayPtr<uint8_t> chartOleData = System::MakeArray<uint8_t>(mstream->get_Length(), 0);
    mstream->set_Position(0);
    mstream->Read(chartOleData, 0, chartOleData->get_Length());

    // إضافة إطار كائن Ole
    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(chartOleData, u"xls");
    System::SharedPtr<IOleObjectFrame> oleObjectFrame = slide->get_Shapes()->AddOleObjectFrame(x, y, OleWidth, OleHeight, dataInfo);

    // ضبط صورة إطار Ole والنص البديل    
    oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(ppImage);
    oleObjectFrame->set_AlternativeText(System::String(u"image") + ppImage);
}
```
``` cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

``` cpp
System::SharedPtr<System::Drawing::Image> ScaleImage(System::SharedPtr<System::Drawing::Image> image, int32_t outputWidth, int32_t outputHeight)
{
    if (outputWidth == 0 && outputHeight == 0)
    {
        outputWidth = image->get_Width();
        outputHeight = image->get_Height();
    }
    System::SharedPtr<System::Drawing::Bitmap> outputImage = System::MakeObject<System::Drawing::Bitmap>(outputWidth, outputHeight, image->get_PixelFormat());
    outputImage->SetResolution(image->get_HorizontalResolution(), image->get_VerticalResolution());
    System::SharedPtr<System::Drawing::Graphics> graphics = System::Drawing::Graphics::FromImage(outputImage);
    graphics->set_InterpolationMode(System::Drawing::Drawing2D::InterpolationMode::HighQualityBicubic);
    System::Drawing::Rectangle srcDestRect(0, 0, outputWidth, outputHeight);
    graphics->DrawImage(image, srcDestRect, srcDestRect, System::Drawing::GraphicsUnit::Pixel);
    graphics->Dispose();

    return outputImage;
}
```

## **تغيير ارتفاع الصفوف وعرض الأعمدة في ورقة العمل وفقًا لحجم إطار Ole**
في هذا النهج، سنتعلم كيفية تغيير ارتفاعات الصفوف المشاركة وعرض الأعمدة المشاركة وفقًا لحجم إطار Ole المحدد.
## **مثال**
افترض أننا قمنا بتعريف ورقة Excel نموذجية ونرغب في إضافتها إلى العرض التقديمي كإطار Ole. في هذا السيناريو، سنقوم بتعيين حجم إطار Ole وتغيير حجم الصفوف والأعمدة المشاركة في منطقة إطار Ole. سنقوم بعد ذلك بحفظ المكتبة في تدفق لحفظ التغييرات وتحويل ذلك إلى مصفوفة بت لإضافته في إطار Ole. لتجنب رسالة **كائن مدمج** الحمراء لإطار Ole في PowerPoint، سنقوم أيضًا بالحصول على صورة للأجزاء المرغوبة من الصفوف والأعمدة في المكتبة وتعيين ذلك كصورة إطار Ole.

``` cpp
auto workbookDesigner = Aspose::Cells::Factory::CreateIWorkbookDesigner();
workbookDesigner->SetIWorkbook(Aspose::Cells::Factory::CreateIWorkbook(new Aspose::Cells::Systems::String("d:/AsposeTest.xls")));

System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>(u"d:/AsposeTest.ppt");
System::SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

System::String fileName = u"d:/AsposeTest_Ole.ppt";
presentation->Save(fileName, Export::SaveFormat::Pptx);
```

``` cpp
void SetOleAccordingToCustomHeightWidth(intrusive_ptr<Aspose::Cells::IWorkbook> workbook, int32_t startRow, int32_t endRow, int32_t startCol, int32_t endCol, double slideWidth, double slideHeight, int32_t dataSheetIdx)
{
    auto work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);

    double actualHeight = 0, actualWidth = 0;

    double newHeight = slideHeight;
    double newWidth = slideWidth;
    double tem = 0;
    double newTem = 0;

    for (int32_t i = startRow; i <= endRow; i++)
    {
        actualHeight += work->GetICells()->GetRowHeightInch(i);
    }

    for (int32_t i = startCol; i <= endCol; i++)
    {
        actualWidth += work->GetICells()->GetColumnWidthInch(i);
    }

    // ضبط ارتفاع الصف والعمود الجديد
    for (int32_t i = startRow; i <= endRow; i++)
    {
        tem = work->GetICells()->GetRowHeightInch(i);
        newTem = (tem / actualHeight) * newHeight;
        work->GetICells()->SetRowHeightInch(i, newTem);
    }

    for (int32_t i = startCol; i <= endCol; i++)
    {
        tem = work->GetICells()->GetColumnWidthInch(i);
        newTem = (tem / actualWidth) * newWidth;
        work->GetICells()->SetColumnWidthInch(i, newTem);
    }
}
```

``` cpp
void AddOleFrame(System::SharedPtr<ISlide> slide, int32_t startRow, int32_t endRow,
        int32_t startCol, int32_t endCol, int32_t dataSheetIdx, int32_t x, int32_t y,
        double OleWidth, double OleHeight, System::SharedPtr<IPresentation> presentation,
        intrusive_ptr<Aspose::Cells::IWorkbookDesigner> workbookDesigner,
        bool onePagePerSheet, int32_t outputWidth, int32_t outputHeight)
{
    std::wstring tempFileName = System::IO::Path::GetTempFileName_().ToWCS();
    if (startRow == 0)
    {
        startRow++;
        endRow++;
    }

    // ضبط مؤشر ورقة العمل النشطة للمكتبة
    workbookDesigner->GetIWorkbook()->GetIWorksheets()->SetActiveSheetIndex(dataSheetIdx);

    // الحصول على المكتبة وورقة العمل المحددة  
    intrusive_ptr<Aspose::Cells::IWorkbook> workbook = workbookDesigner->GetIWorkbook();
    intrusive_ptr<Aspose::Cells::IWorksheet> work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);

    // تغيير ارتفاع الصفوف وعرض الأعمدة وفقًا لحجم Ole المخصص
    double height = OleHeight / 576.0f;
    double width = OleWidth / 576.0f;

    // ضبط حجم Ole وفقاً للصفوف والأعمدة المحددة
    SetOleAccordingToCustomHeightWidth(workbook, startRow, endRow, startCol, endCol, width, height, dataSheetIdx);

    // تعيين حجم Ole في المكتبة
    workbook->GetIWorksheets()->SetOleSize(startRow, endRow, startCol, endCol);
    workbook->GetIWorksheets()->GetObjectByIndex(0)->SetGridlinesVisible(false);

    // ضبط خيارات الصورة لأخذ صورة ورقة العمل
    intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> imageOrPrintOptions = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
    imageOrPrintOptions->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetBmp());
    imageOrPrintOptions->SetOnePagePerSheet(onePagePerSheet);

    intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> render = Aspose::Cells::Factory::CreateISheetRender(workbookDesigner->GetIWorkbook()->GetIWorksheets()->GetObjectByIndex(dataSheetIdx), imageOrPrintOptions);
    tempFileName.append(L".bmp");
    render->ToImage(0, new String(tempFileName.c_str()));

    System::String slidesTempFileName = System::String::FromWCS(tempFileName);
    System::SharedPtr<System::Drawing::Image> image = ScaleImage(System::Drawing::Image::FromFile(slidesTempFileName), outputWidth, outputHeight);
    System::String newTempFileName = slidesTempFileName.Replace(u".tmp", u".tmp1");
    image->Save(newTempFileName, System::Drawing::Imaging::ImageFormat::get_Bmp());

    // إضافة الصورة إلى مجموعة الصور في الشريحة
    auto ppImage = presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(newTempFileName));

    // حفظ المكتبة إلى تدفق ونسخها في مصفوفة بت
    System::SharedPtr<System::IO::Stream> mstream = ToSlidesMemoryStream(workbook->SaveToStream());
    System::ArrayPtr<uint8_t> chartOleData = System::MakeArray<uint8_t>(mstream->get_Length(), 0);
    mstream->set_Position(0);
    mstream->Read(chartOleData, 0, chartOleData->get_Length());

    // إضافة إطار كائن Ole
    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(chartOleData, u"xls");
    System::SharedPtr<IOleObjectFrame> oleObjectFrame = slide->get_Shapes()->AddOleObjectFrame(x, y, OleWidth, OleHeight, dataInfo);

    // ضبط صورة إطار Ole والنص البديل    
    oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(ppImage);
    oleObjectFrame->set_AlternativeText(System::String(u"image") + ppImage);
}
```

``` cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

``` cpp
System::SharedPtr<System::Drawing::Image> ScaleImage(System::SharedPtr<System::Drawing::Image> image, int32_t outputWidth, int32_t outputHeight)
{
    if (outputWidth == 0 && outputHeight == 0)
    {
        outputWidth = image->get_Width();
        outputHeight = image->get_Height();
    }
    System::SharedPtr<System::Drawing::Bitmap> outputImage = System::MakeObject<System::Drawing::Bitmap>(outputWidth, outputHeight, image->get_PixelFormat());
    outputImage->SetResolution(image->get_HorizontalResolution(), image->get_VerticalResolution());
    System::SharedPtr<System::Drawing::Graphics> graphics = System::Drawing::Graphics::FromImage(outputImage);
    graphics->set_InterpolationMode(System::Drawing::Drawing2D::InterpolationMode::HighQualityBicubic);
    System::Drawing::Rectangle srcDestRect(0, 0, outputWidth, outputHeight);
    graphics->DrawImage(image, srcDestRect, srcDestRect, System::Drawing::GraphicsUnit::Pixel);
    graphics->Dispose();

    return outputImage;
}
```

## **الخاتمة**

{{% alert color="primary" %}}   {{% /alert %}} 

هناك نهجان لإصلاح مشكلة تغيير حجم ورقة العمل. يعتمد اختيار النهج المناسب على المتطلبات وحالة الاستخدام. تعمل كلا النهجين بنفس الطريقة سواء تمت إنشاء العروض التقديمية من نموذج أو إنشائها من الصفر. أيضًا، لا توجد حدود لحجم إطار كائن OLE في الحل. 

h4. {_}الأقسام ذات الصلة 
{_}

[إنشاء وتضمين مخطط Excel ككائن OLE في العرض التقديمي](/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)