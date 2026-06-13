---
title: "بهینه‌سازی مدیریت تصاویر در ارائه‌ها با استفاده از C++"
linktitle: "مدیریت تصاویر"
type: docs
weight: 10
url: /fa/cpp/image/
keywords:
- "افزودن تصویر"
- "افزودن عکس"
- "افزودن بیت‌مپ"
- "جایگزینی تصویر"
- "جایگزینی عکس"
- "از وب"
- "پس‌زمینه"
- "افزودن PNG"
- "افزودن JPG"
- "افزودن SVG"
- "افزودن EMF"
- "افزودن WMF"
- "افزودن TIFF"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "EMF"
- "SVG"
- "C++"
- "Aspose.Slides"
description: "مدیریت تصاویر را در PowerPoint و OpenDocument با Aspose.Slides برای C++ ساده کنید، عملکرد را بهینه‌سازی کنید و جریان کاری خود را خودکار نمایید."
---
## **معرفی**

تصاویر ارائه‌ها را جذاب‌تر و جالب‌تر می‌کنند. در Microsoft PowerPoint می‌توانید تصاویر را از یک فایل، اینترنت یا مکان‌های دیگر روی اسلایدها قرار دهید. به‌طور مشابه، Aspose.Slides به شما اجازه می‌دهد تا تصاویر را به اسلایدهای ارائه‌تان از طریق روش‌های مختلف اضافه کنید.

{{% alert title="Tip" color="primary" %}} 
Aspose مبدل‌های رایگانی ارائه می‌دهد—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—که به افراد امکان می‌دهد به سرعت از تصاویر ارائه‌ها را ایجاد کنند. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
اگر می‌خواهید یک تصویر را به‌عنوان شیء قاب اضافه کنید—به‌ویژه اگر قصد دارید از گزینه‌های قالب‌بندی استاندارد برای تغییر اندازه، افزودن افکت و غیره استفاده کنید—به ‎[قاب تصویر](/slides/fa/cpp/picture-frame/) مراجعه کنید. 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
می‌توانید عملیات ورودی/خروجی مربوط به تصاویر و ارائه‌های PowerPoint را دستکاری کنید تا یک تصویر را از قالبی به قالب دیگر تبدیل کنید. این صفحات را ببینید: تبدیل [تصویر به JPG](https://products.aspose.com/slides/fa/cpp/conversion/image-to-jpg/); تبدیل [JPG به تصویر](https://products.aspose.com/slides/fa/cpp/conversion/jpg-to-image/); تبدیل [JPG به PNG](https://products.aspose.com/slides/fa/cpp/conversion/jpg-to-png/); تبدیل [PNG به JPG](https://products.aspose.com/slides/fa/cpp/conversion/png-to-jpg/); تبدیل [PNG به SVG](https://products.aspose.com/slides/fa/cpp/conversion/png-to-svg/); تبدیل [SVG به PNG](https://products.aspose.com/slides/fa/cpp/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides از عملیات با تصاویر در این قالب‌های محبوب پشتیبانی می‌کند: JPEG، PNG، GIF و دیگران. 

## **افزودن تصاویر ذخیره‌شده به صورت محلی به اسلایدها**

می‌توانید یک یا چند تصویر موجود بر روی رایانه خود را به یک اسلاید در ارائه اضافه کنید. این کد نمونه در C++ نشان می‌دهد چگونه یک تصویر را به اسلاید اضافه کنید:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **افزودن تصاویر از وب به اسلایدها**

اگر تصویری که می‌خواهید به اسلاید اضافه کنید روی رایانه‌تان موجود نیست، می‌توانید تصویر را مستقیماً از وب اضافه کنید. 

این کد نمونه نشان می‌دهد چگونه یک تصویر را از وب به اسلاید در C++ اضافه کنید:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **افزودن تصاویر به اسلاید مسترها**

یک اسلاید مستر بالاترین اسلاید است که اطلاعات (قالب، چیدمان و غیره) درباره تمام اسلایدهای زیرمجموعه‌اش را ذخیره و کنترل می‌کند. بنابراین، وقتی تصویری را به اسلاید مستر اضافه می‌کنید، آن تصویر در هر اسلاید زیر آن مستر ظاهر می‌شود. 

این کد نمونه در C++ نشان می‌دهد چگونه یک تصویر را به اسلاید مستر اضافه کنید:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **افزودن تصاویر به عنوان پس‌زمینه اسلایدها**

ممکن است تصمیم بگیرید از یک تصویر به‌عنوان پس‌زمینه برای یک اسلاید خاص یا چند اسلاید استفاده کنید. در این صورت، باید *[تنظیم تصاویر به عنوان پس‌زمینه اسلایدها](https://docs.aspose.com/slides/fa/cpp/presentation-background/#setting-images-as-background-for-slides)* را ببینید.

## **افزودن SVG به ارائه‌ها**

می‌توانید هر تصویری را با استفاده از متد [AddPictureFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) که متعلق به رابط [IShapeCollection](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_shape_collection) است، به یک ارائه اضافه یا وارد کنید.

برای ایجاد یک شیء تصویر بر پایه تصویر SVG، می‌توانید به این شکل عمل کنید:

1. ایجاد شیء SvgImage برای درج آن در ImageShapeCollection  
2. ایجاد شیء PPImage از ISvgImage  
3. ایجاد شیء PictureFrame با استفاده از رابط IPPImage  

این کد نمونه نشان می‌دهد چگونه مراحل فوق را برای افزودن یک تصویر SVG به یک ارائه پیاده‌سازی کنید:
``` cpp 
// مسیر پوشه اسناد
System::String dataDir = u"D:\\Documents\\";

// نام فایل SVG منبع
System::String svgFileName = dataDir + u"sample.svg";

// نام فایل خروجی ارائه
System::String outPptxPath = dataDir + u"presentation.pptx";

// ایجاد ارائه جدید
auto p = System::MakeObject<Presentation>();

// خواندن محتوای فایل SVG
System::String svgContent = File::ReadAllText(svgFileName);

// ایجاد شیء SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// ایجاد شیء PPImage
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// یک PictureFrame جدید ایجاد می‌کند
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// ذخیره ارائه در قالب PPTX
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **تبدیل SVG به مجموعه‌ای از اشکال**

تبدیل SVG به مجموعه‌ای از اشکال در Aspose.Slides مشابه عملکرد PowerPoint است که برای کار با تصاویر SVG استفاده می‌شود:

![منوی کشویی PowerPoint](img_01_01.png)

این قابلیت توسط یکی از overloadهای متد [AddGroupShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) رابط [IShapeCollection](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_shape_collection) که شیء [ISvgImage](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_svg_image) را به‌عنوان اولین آرگومان می‌گیرد، فراهم می‌شود.

این کد نمونه نشان می‌دهد چگونه از روش توضیح‌داده‌شده برای تبدیل یک فایل SVG به مجموعه‌ای از اشکال استفاده کنید:

``` cpp 
// مسیر پوشه اسناد
System::String dataDir = u"D:\\Documents\\";

// نام فایل SVG منبع
System::String svgFileName = dataDir + u"sample.svg";

// نام فایل خروجی ارائه
System::String outPptxPath = dataDir + u"presentation.pptx";

// ایجاد ارائه جدید
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// خواندن محتوای فایل SVG
System::String svgContent = File::ReadAllText(svgFileName);

// ایجاد شیء SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// دریافت اندازه اسلاید
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// تبدیل تصویر SVG به گروهی از شکل‌ها با مقیاس‌بندی به اندازه اسلاید
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// ذخیره ارائه در قالب PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **افزودن تصاویر به‌صورت EMF به اسلایدها**

Aspose.Slides برای C++ به شما امکان می‌دهد تصاویر EMF را از شیت‌های اکسل تولید کنید و این تصاویر را به‌صورت EMF در اسلایدها با Aspose.Cells اضافه کنید. 

این کد نمونه نشان می‌دهد چگونه کار مذکور را انجام دهید:

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

## **جایگزینی تصاویر در مجموعه تصویرها**

Aspose.Slides به شما اجازه می‌دهد تصاویر ذخیره‌شده در مجموعه تصویرهای یک ارائه (از جمله آنهایی که توسط اشکال اسلاید استفاده می‌شوند) را جایگزین کنید. این بخش چند رویکرد برای به‌روزرسانی تصاویر در مجموعه را نشان می‌دهد. API روش‌های ساده‌ای برای جایگزینی یک تصویر با استفاده از داده‌های بایت خام، یک نمونه [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) یا تصویر دیگری که قبلاً در مجموعه وجود دارد، فراهم می‌کند.

مراحل زیر را دنبال کنید:

1. فایل ارائه‌حاوی تصاویر را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) بارگیری کنید.  
2. یک تصویر جدید را از فایل به یک آرایه بایت بارگیری کنید.  
3. تصویر هدف را با تصویر جدید با استفاده از آرایه بایت جایگزین کنید.  
4. در روش دوم، تصویر را به یک شیء [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) بارگیری کنید و تصویر هدف را با آن شیء جایگزین کنید.  
5. در روش سوم، تصویر هدف را با تصویری که قبلاً در مجموعه تصویرهای ارائه موجود است، جایگزین کنید.  
6. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

```cpp
// ایجاد شی کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// روش اول.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// روش دوم.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// روش سوم.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// ذخیره ارائه به یک فایل.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
با استفاده از مبدل رایگان Aspose [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) می‌توانید به سادگی متن‌ها را انیمیشن کنید، GIFهایی از متن‌ها ایجاد کنید و غیره. 
{{% /alert %}}

## **سوالات رایج**

**آیا وضوح تصویر اصلی پس از درج حفظ می‌شود؟**  
بله. پیکسل‌های منبع حفظ می‌شوند، اما ظاهر نهایی به این‌که [تصویر](/slides/fa/cpp/picture-frame/) چگونه در اسلاید مقیاس‌بندی شود و هرگونه فشرده‌سازی در هنگام ذخیره‌سازی اعمال شود، وابسته است.

**بهترین روش برای جایگزینی یک لوگو یکسان در ده‌ها اسلاید به‌طور همزمان چیست؟**  
لوگو را در اسلاید مستر یا یک چیدمان قرار دهید و آن را در مجموعه تصویرهای ارائه جایگزین کنید—به‌روزرسانی‌ها به تمام عناصری که از این منبع استفاده می‌کنند، انتشار می‌یابد.

**آیا می‌توان یک SVG درج‌شده را به اشکال قابل ویرایش تبدیل کرد؟**  
بله. می‌توانید SVG را به یک گروه از اشکال تبدیل کنید؛ پس از آن بخش‌های جداگانه قابل ویرایش با خواص استاندارد شکل‌ها می‌شوند.

**چگونه می‌توان یک تصویر را به‌عنوان پس‌زمینه برای چند اسلاید به‌طور همزمان تنظیم کرد؟**  
[تصویر را به‌عنوان پس‌زمینه](/slides/fa/cpp/presentation-background/) در اسلاید مستر یا چیدمان مربوطه اختصاص دهید—هر اسلایدی که از آن مستر/چیدمان استفاده می‌کند، پس‌زمینه را به ارث می‌برد.

**چگونه می‌توان از «پف شدن» اندازه ارائه به دلیل تعداد زیاد تصاویر جلوگیری کرد؟**  
به‌جای تصویرهای تکراری از یک منبع تصویر واحد استفاده کنید، وضوح‌های معقول انتخاب کنید، در زمان ذخیره‌سازی فشرده‌سازی اعمال کنید و گرافیک‌های تکراری را در مستر نگه دارید.