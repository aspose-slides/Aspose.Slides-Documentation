---
title: تحسين إدارة الصور في العروض التقديمية باستخدام C++
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/cpp/image/
keywords:
- إضافة صورة
- إضافة صورة
- إضافة bitmap
- استبدال صورة
- استبدال صورة
- من الويب
- خلفية
- إضافة PNG
- إضافة JPG
- إضافة SVG
- إضافة EMF
- إضافة WMF
- إضافة TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- EMF
- SVG
- C++
- Aspose.Slides
description: "تبسيط إدارة الصور في PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++، مما يحسن الأداء ويُؤتمت سير العمل الخاص بك."
---

## **الصور في شرائح العرض**

تجعل الصور العروض التقديمية أكثر جذبًا وإثارة للاهتمام. في Microsoft PowerPoint، يمكنك إدراج الصور من ملف أو من الإنترنت أو من مواقع أخرى إلى الشرائح. بالمثل، يتيح Aspose.Slides إضافة الصور إلى الشرائح في عروضك باستخدام إجراءات مختلفة. 

{{% alert title="نصيحة" color="primary" %}} 

يوفر Aspose محولات مجانية—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تسمح للناس بإنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

{{% alert title="معلومات" color="info" %}}

إذا كنت ترغب في إضافة صورة ككائن إطار—خصوصًا إذا كنت تخطط لاستخدام خيارات تنسيق قياسية عليه لتغيير حجمه، إضافة تأثيرات، وما إلى ذلك—اطلع على [Picture Frame](/slides/ar/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}}

يمكنك التعامل مع عمليات الإدخال/الإخراج المتعلقة بالصور وعروض PowerPoint لتحويل صورة من صيغة إلى أخرى. راجع هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/)؛ تحويل [JPG to image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/)؛ تحويل [JPG to PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/)، تحويل [PNG to JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/)؛ تحويل [PNG to SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/)، تحويل [SVG to PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/). 

{{% /alert %}}

يدعم Aspose.Slides عمليات مع الصور في هذه الصيغ الشائعة: JPEG، PNG، GIF، وغيرها. 

## **إضافة صور مخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة أو عدة صور من جهاز الكمبيوتر إلى شريحة في عرض تقديمي. يظهر لك هذا المثال البرمجي بلغة C++ كيفية إضافة صورة إلى شريحة:
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```




## **إضافة صور من الويب إلى الشرائح**

إذا كانت الصورة التي تريد إضافتها إلى شريحة غير متوفرة على جهازك، يمكنك إضافتها مباشرة من الويب. 

يعرض لك هذا المثال البرمجي كيفية إضافة صورة من الويب إلى شريحة بلغة C++:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **إضافة صور إلى القوالب الرئيسية للشرائح**

القالب الرئيسي للشرائح هو الشريحة العليا التي تخزن وتتحكم في معلومات (السمة، التخطيط، إلخ) لجميع الشرائح تحته. لذلك، عندما تضيف صورة إلى القالب الرئيسي، تظهر تلك الصورة على كل شريحة تحت ذلك القالب. 

يظهر لك هذا المثال البرمجي بلغة C++ كيفية إضافة صورة إلى القالب الرئيسي:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **إضافة صور كخلفيات للشرائح**

قد تقرر استخدام صورة كخلفية لشريحة معينة أو لعدة شرائح. في هذه الحالة، عليك الاطلاع على *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**
يمكنك إضافة أو إدراج أي صورة في عرض تقديمي باستخدام طريقة [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) التي تنتمي إلى واجهة [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection). 

لإنشاء كائن صورة يعتمد على صورة SVG، يمكنك فعل ذلك بهذه الطريقة:

1. إنشاء كائن SvgImage لإدراجه في ImageShapeCollection
2. إنشاء كائن PPImage من ISvgImage
3. إنشاء كائن PictureFrame باستخدام واجهة IPPImage

يعرض لك هذا المثال البرمجي تنفيذ الخطوات المذكورة لإضافة صورة SVG إلى عرض تقديمي:
``` cpp
// مسار مجلد المستندات
System::String dataDir = u"D:\\Documents\\";

// اسم ملف SVG المصدر
System::String svgFileName = dataDir + u"sample.svg";

// اسم ملف العرض التقديمي الناتج
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

// حفظ العرض التقديمي بصيغة PPTX
p->Save(outPptxPath, SaveFormat::Pptx);
```


## **تحويل SVG إلى مجموعة من الأشكال**
تحويل Aspose.Slides لـ SVG إلى مجموعة من الأشكال مشابه للوظيفة الموجودة في PowerPoint للعمل مع صور SVG:

![PowerPoint Popup Menu](img_01_01.png)

تُوفر الوظيفة من خلال أحد التحميلات الزائدة لطريقة [AddGroupShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) في واجهة [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) التي تستقبل كائن [ISvgImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_svg_image) كوسيط أول. 

يعرض لك هذا المثال البرمجي كيفية استخدام الطريقة المذكورة لتحويل ملف SVG إلى مجموعة من الأشكال:
``` cpp 
// مسار مجلد المستندات
System::String dataDir = u"D:\\Documents\\";

// اسم ملف SVG المصدر
System::String svgFileName = dataDir + u"sample.svg";

// اسم ملف العرض التقديمي الناتج
System::String outPptxPath = dataDir + u"presentation.pptx";

// إنشاء عرض تقديمي جديد
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// قراءة محتوى ملف SVG
System::String svgContent = File::ReadAllText(svgFileName);

// إنشاء كائن SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// الحصول على حجم الشريحة
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// تحويل صورة SVG إلى مجموعة من الأشكال وتوسيعها لتناسب حجم الشريحة
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// حفظ العرض التقديمي بصيغة PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```


## **إضافة صور كـ EMF إلى الشرائح**
يسمح Aspose.Slides للغة C++ بإنشاء صور EMF من جداول إكسل وإضافة تلك الصور كـ EMF في الشرائح باستخدام Aspose.Cells. 

يعرض لك هذا المثال البرمجي كيفية تنفيذ المهمة الموصوفة:
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

// Save the workbook to stream
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


## **استبدال الصور في مجموعة الصور**

يتيح Aspose.Slides استبدال الصور المخزنة في مجموعة الصور الخاصة بالعرض (بما فيها تلك المستخدمة من قبل أشكال الشرائح). يوضح هذا القسم عدة نهج لتحديث الصور في المجموعة. توفر الـ API طرقًا مباشرة لاستبدال صورة باستخدام بيانات بايت خام، أو كائن [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) موجود، أو صورة أخرى موجودة بالفعل في المجموعة. 

اتبع الخطوات التالية:

1. تحميل ملف العرض الذي يحتوي على الصور باستخدام فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. تحميل صورة جديدة من ملف إلى مصفوفة بايت.
3. استبدال الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت.
4. في النهج الثاني، تحميل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) واستبدال الصورة المستهدفة بذلك الكائن.
5. في النهج الثالث، استبدال الصورة المستهدفة بصورة موجودة بالفعل في مجموعة صور العرض.
6. كتابة العرض المعدل كملف PPTX. 
```cpp
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// الطريقة الأولى.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// الطريقة الثانية.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// الطريقة الثالثة.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// حفظ العرض التقديمي إلى ملف.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert title="معلومات" color="info" %}}

باستخدام محول Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) يمكنك بسهولة تحريك النصوص، وإنشاء GIFs من النصوص، وما إلى ذلك. 

{{% /alert %}}

## **الأسئلة المتكررة**

**هل تبقى دقة الصورة الأصلية كما هي بعد الإدراج؟**

نعم. يتم الحفاظ على بكسلات المصدر، لكن المظهر النهائي يعتمد على كيفية تحجيم [picture](/slides/ar/cpp/picture-frame/) على الشريحة وأي ضغط يُطبق عند الحفظ.

**ما هي أفضل طريقة لاستبدال نفس الشعار عبر العشرات من الشرائح مرة واحدة؟**

ضع الشعار على الشريحة الرئيسية أو على تخطيط، واستبدله في مجموعة صور العرض—ستنتشر التغييرات إلى جميع العناصر التي تستخدم هذا المورد.

**هل يمكن تحويل SVG المُدرَج إلى أشكال يمكن تعديلها؟**

نعم. يمكنك تحويل SVG إلى مجموعة من الأشكال، وبعد ذلك تصبح الأجزاء الفردية قابلة للتعديل باستخدام خصائص الشكل القياسية.

**كيف يمكنني ضبط صورة كخلفية لعدة شرائح في آن واحد؟**

[Assign the image as the background](/slides/ar/cpp/presentation-background/) على الشريحة الرئيسية أو التخطيط المناسب—سيتم توريث الخلفية إلى جميع الشرائح التي تستخدم ذلك القالب/التخطيط.

**كيف أمنع أن يصبح حجم العرض كبيرًا جدًا بسبب كثرة الصور؟**

أعد استخدام مصدر صورة واحد بدلاً من النسخ المتكررة، اختر دقة معقولة، طبق الضغط عند الحفظ، واحفظ الرسومات المتكررة على القالب الرئيسي حيثما كان ذلك مناسبًا.