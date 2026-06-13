---
title: चित्र
type: docs
weight: 50
url: /hi/cpp/examples/elements/picture/
keywords:
- कोड उदाहरण
- चित्र
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में चित्रों के साथ काम करें: सम्मिलित करें, क्रॉप करें, संकुचित करें, रंग बदलें और छवियों को निर्यात करें, PPT, PPTX और ODP प्रस्तुतियों के लिए C++ उदाहरणों के साथ।"
---
यह लेख दिखाता है कि कैसे इन‑मेमोरी इमेज़ों से चित्र सम्मिलित और एक्सेस करें **Aspose.Slides for C++** का उपयोग करके। नीचे के उदाहरण एक इमेज़ मेमोरी में बनाते हैं, उसे स्लाइड पर रखते हैं, और फिर उसे पुनः प्राप्त करते हैं।

## **चित्र जोड़ें**

यह कोड एक छोटा बिटमैप बनाता है, उसे स्ट्रीम में बदलता है, और पहले स्लाइड पर इसे एक चित्र फ्रेम के रूप में जोड़ता है।

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // एक सरल इन‑मेमोरी इमेज बनाएं।
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // बिटमैप को बाइट ऐरे में बदलें।
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // इमेज को प्रेजेंटेशन में जोड़ें।
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // पहले स्लाइड पर इमेज दिखाने वाला पिक्चर फ्रेम सम्मिलित करें।
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **चित्र तक पहुँचें**

यह उदाहरण सुनिश्चित करता है कि स्लाइड में एक चित्र फ्रेम है और फिर वह पहला मिलने वाला चित्र एक्सेस करता है।

```cpp
static void AccessPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto bitmap = MakeObject<Bitmap>(40, 40, PixelFormat::Format32bppArgb);
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0, 0, 40, 40, image);

    auto pictureFrame = SharedPtr<IPictureFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            pictureFrame = ExplicitCast<IPictureFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```