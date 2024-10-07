---
title: تحويل باور بوينت PPT إلى JPG
type: docs
weight: 60
url: /cpp/convert-powerpoint-to-jpg/
keywords:
- تحويل عرض باور بوينت
- JPG
- JPEG
- باور بوينت إلى JPG
- باور بوينت إلى JPEG
- PPT إلى JPG
- PPTX إلى JPG
- PPT إلى JPEG
- PPTX إلى JPEG
- C++
- Aspose.Slides
description: "تحويل باور بوينت إلى JPG: PPT إلى JPG، PPTX إلى JPG في C++"
---

## **تحويل العرض إلى مجموعة من الصور**

في بعض الحالات، من الضروري تحويل العرض بالكامل إلى مجموعة من الصور، 
كما يسمح باور بوينت. الكود بلغة C++ يوضح لك كيفية تحويل عرض إلى صور JPG:

```c++
auto imageScale = 1.0f;

auto pres = System::MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : pres->get_Slides())
{
    // Creates a full scale image
    System::SharedPtr<IImage> image = slide->GetImage(imageScale, imageScale);

    // Saves the image to disk in JPEG format
    auto imageFileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(imageFileName, ImageFormat::Jpeg);

    image->Dispose();
}

pres->Dispose();
```

{{% alert color="primary" %}} 

لرؤية كيفية تحويل Aspose.Slides باور بوينت إلى صور JPG، قد ترغب في تجربة هذه المحولات المجانية عبر الإنترنت: باور بوينت [PPTX إلى JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و[PPT إلى JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

## تحويل باور بوينت PPT/PPTX إلى JPG بأبعاد مخصصة**

لتغيير أبعاد الصورة المصغرة الناتجة وصورة JPG، يمكنك تعيين قيم *ScaleX* و*ScaleY* عن طريق تمريرها إلى `float scaleX, float Y` من [**ISlide::GetImage()**](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagefloat-float-method) الطريقة:

```c++
auto pres = System::MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

// Defines dimensions
int32_t desiredX = 1200, desiredY = 800;

// Gets scaled values of X and Y
float scaleX = (float)(1.0 / pres->get_SlideSize()->get_Size().get_Width()) * desiredX;
float scaleY = (float)(1.0 / pres->get_SlideSize()->get_Size().get_Height()) * desiredY;

for (auto&& slide : pres->get_Slides())
{
    // Creates a full scale image
    System::SharedPtr<IImage> image = slide->GetImage(scaleX, scaleY);

    // Saves the image to disk in JPEG format
    auto imageFileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(imageFileName, ImageFormat::Jpeg);

    image->Dispose();
}

pres->Dispose();
```

{{% alert title="نصيحة" color="primary" %}}

توفر Aspose تطبيق ويب [مجاناً لجمع الصور](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو صور PNG إلى PNG، وإنشاء [شبكات الصور](https://products.aspose.app/slides/collage/photo-grid)، وهكذا. 

باستخدام نفس المبادئ الموصوفة في هذه المقالة، يمكنك تحويل الصور من تنسيق إلى آخر. لمزيد من المعلومات، راجع هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **انظر أيضا**

انظر خيارات أخرى لتحويل PPT/PPTX إلى صورة مثل:

- [تحويل PPT/PPTX إلى SVG](/slides/cpp/render-a-slide-as-an-svg-image/)