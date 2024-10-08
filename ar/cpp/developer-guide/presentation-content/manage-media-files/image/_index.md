---
title: صورة
type: docs
weight: 10
url: /ar/cpp/image/
---


## **الصور في الشريحة في العروض التقديمية**

تجعل الصور العروض التقديمية أكثر تفاعلاً وإثارة للاهتمام. في Microsoft PowerPoint، يمكنك إدراج صور من ملف أو من الإنترنت أو من مواقع أخرى إلى الشرائح. بالمثل، يسمح Aspose.Slides لك بإضافة صور إلى الشرائح في عروضك التقديمية من خلال إجراءات مختلفة. 

{{% alert title="نصيحة" color="primary" %}} 

يوفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تسمح للناس بإنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

{{% alert title="معلومات" color="info" %}}

إذا كنت ترغب في إضافة صورة ككائن إطار—خصوصًا إذا كنت تخطط لاستخدام خيارات التنسيق القياسية عليها لتغيير حجمها، إضافة تأثيرات، وما إلى ذلك—انظر إلى [إطار الصورة](/slides/ar/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="ملحوظة" color="warning" %}}

يمكنك التعامل مع عمليات الإدخال/الإخراج التي تشمل الصور والعروض التقديمية في PowerPoint لتحويل صورة من تنسيق إلى آخر. انظر إلى هذه الصفحات: تحويل [الصورة إلى JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/)؛ تحويل [JPG إلى صورة](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/)؛ تحويل [JPG إلى PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/)؛ تحويل [PNG إلى JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/)؛ تحويل [PNG إلى SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/)؛ تحويل [SVG إلى PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

يدعم Aspose.Slides عمليات مع الصور في هذه التنسيقات الشائعة: JPEG، PNG، GIF، وغيرها. 

## **إضافة صور محفوظة محليًا إلى الشرائح**

يمكنك إضافة صورة واحدة أو أكثر من جهاز الكمبيوتر الخاص بك إلى شريحة في عرض تقديمي. يُظهر هذا الرمز التجريبي في C++ كيفية إضافة صورة إلى شريحة:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **إضافة صور من الويب إلى الشرائح**

إذا لم تكن الصورة التي ترغب في إضافتها إلى شريحة متاحة على جهاز الكمبيوتر الخاص بك، يمكنك إضافة الصورة مباشرة من الويب. 

يعرض هذا الرمز التجريبي كيفية إضافة صورة من الويب إلى شريحة في C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **إضافة صور إلى مخططات الشرائح**

مخطط الشريحة هو الشريحة العليا التي تخزن وتتحكم في المعلومات (ثيم، تخطيط، إلخ) عن جميع الشرائح تحتها. لذا، عند إضافة صورة إلى مخطط الشريحة، تظهر تلك الصورة في كل شريحة تحت ذلك المخطط. 

يظهر هذا الرمز التجريبي في C++ كيفية إضافة صورة إلى مخطط الشريحة:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **إضافة صور كخلفية للشرائح**

قد تقرر استخدام صورة كخلفية لشريحة معينة أو عدة شرائح. في هذه الحالة، يجب عليك الاطلاع على *[تعيين الصور كخلفيات للشرائح](https://docs.aspose.com/slides/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **إدراج/إضافة SVG في العروض التقديمية**
يمكنك إضافة أو إدراج أي صورة في عرض تقديمي باستخدام طريقة [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) التي تنتمي إلى واجهة [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

لإنشاء كائن صورة استنادًا إلى صورة SVG، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء كائن SvgImage لإضافته إلى ImageShapeCollection
2. إنشاء كائن PPImage من ISvgImage
3. إنشاء كائن PictureFrame باستخدام واجهة IPPImage

يعرض هذا الرمز التجريبي كيفية تنفيذ الخطوات أعلاه لإضافة صورة SVG إلى عرض تقديمي:
``` cpp 
// المسار إلى مجلد المستندات
System::String dataDir = u"D:\\Documents\\";

// اسم ملف SVG المصدر
System::String svgFileName = dataDir + u"sample.svg";

// اسم ملف العرض التقديمي النهائي
System::String outPptxPath = dataDir + u"presentation.pptx";

// إنشاء عرض تقديمي جديد
auto p = System::MakeObject<Presentation>();

// قراءة محتوى ملف SVG
System::String svgContent = File::ReadAllText(svgFileName);

// إنشاء كائن SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// إنشاء كائن PPImage
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// إنشاء إطار صورة جديد 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// حفظ العرض التقديمي بتنسيق PPTX
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **تحويل SVG إلى مجموعة من الأشكال**
تحويل Aspose.Slides لصيغة SVG إلى مجموعة من الأشكال مشابه للوظيفة المستخدمة في PowerPoint للعمل مع صور SVG:


![قائمة منبثقة PowerPoint](img_01_01.png)

توفر الوظيفة بواسطة إحدى التحميلات المفرطة لطريقة [AddGroupShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) الخاصة بواجهة [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) التي تأخذ كائن [ISvgImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_svg_image) كوسيط أول.

يعرض هذا الرمز التجريبي كيفية استخدام الطريقة الموصوفة لتحويل ملف SVG إلى مجموعة من الأشكال:

``` cpp 
// المسار إلى مجلد المستندات
System::String dataDir = u"D:\\Documents\\";

// اسم ملف SVG المصدر
System::String svgFileName = dataDir + u"sample.svg";

// اسم ملف العرض التقديمي النهائي
System::String outPptxPath = dataDir + u"presentation.pptx";

// إنشاء عرض تقديمي جديد
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// قراءة محتوى ملف SVG
System::String svgContent = File::ReadAllText(svgFileName);

// إنشاء كائن SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// الحصول على حجم الشريحة
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// تحويل صورة SVG إلى مجموعة من الأشكال مع تغيير حجمها لتتناسب مع حجم الشريحة
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// حفظ العرض التقديمي بتنسيق PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **إضافة صور كـ EMF في الشرائح**
يسمح Aspose.Slides لـ C++ بإنشاء صور EMF من جداول البيانات وإضافة الصور كـ EMF في الشرائح باستخدام Aspose.Cells. 

يعرض هذا الرمز التجريبي كيفية تنفيذ المهمة الموصوفة:

``` cpp 
System::String dataDir = u"D:\\Documents\\";

StringPtr cellsXls = new String(dataDir.ToWCS().c_str());
cellsXls->Append(L"chart.xls");
intrusive_ptr<Aspose::Cells::IWorkbook> book = Aspose::Cells::Factory::CreateIWorkbook(cellsXls);

intrusive_ptr<Aspose::Cells::IWorksheet> sheet = book->GetIWorksheets()->GetObjectByIndex(0);
intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> options = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
options->SetHorizontalResolution(200);
options->SetVerticalResolution(200);
options->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetEmf());

// حفظ مصنف الدفتر في دفق
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Page" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```

{{% alert title="معلومات" color="info" %}}

باستخدام محول Aspose المجاني [نص إلى GIF](https://products.aspose.app/slides/text-to-gif)، يمكنك بسهولة تحريك النصوص، وإنشاء GIFs من النصوص، إلخ. 

{{% /alert %}}