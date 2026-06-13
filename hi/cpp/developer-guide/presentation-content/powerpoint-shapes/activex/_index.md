---
title: C++ का उपयोग करके प्रस्तुतियों में ActiveX नियंत्रणों का प्रबंधन
linktitle: ActiveX
type: docs
weight: 80
url: /hi/cpp/activex/
keywords:
- ActiveX
- ActiveX नियंत्रण
- ActiveX प्रबंधन
- ActiveX जोड़ें
- ActiveX संशोधित करें
- मीडिया प्लेयर
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "जानिए कैसे Aspose.Slides for C++ ActiveX का उपयोग करके PowerPoint प्रस्तुतियों को स्वचालित और बेहतर बनाता है, जिससे डेवलपर्स को स्लाइड्स पर शक्तिशाली नियंत्रण मिलता है।"
---
## **परिचय**

ActiveX नियंत्रण प्रेजेंटेशन में उपयोग किए जाते हैं। Aspose.Slides for C++ आपको ActiveX नियंत्रणों को प्रबंधित करने की सुविधा देता है, लेकिन इन्हें प्रबंधित करना थोड़ा जटिल और सामान्य प्रेजेंटेशन शैलियों से अलग है। Aspose.Slides for C++ 18.1 से, यह घटक ActiveX नियंत्रणों के प्रबंधन को समर्थन देता है। वर्तमान में, आप अपने प्रेजेंटेशन में पहले से जोड़े गए ActiveX नियंत्रण तक पहुँच सकते हैं और उसके विभिन्न गुणों का उपयोग करके उसे संशोधित या हटाया जा सकता है। याद रखें, ActiveX नियंत्रण शैलियाँ नहीं हैं और प्रेजेंटेशन की IShapeCollection का हिस्सा नहीं होते बल्कि अलग IControlCollection का हिस्सा होते हैं। यह लेख इनसे काम करने का तरीका दिखाता है।

## **ActiveX नियंत्रण को संशोधित करना**
एक स्लाइड पर टेक्स्ट बॉक्स और सरल कमांड बटन जैसे साधारण ActiveX नियंत्रण को प्रबंधित करने के लिए:

1. Presentation क्लास का एक इंस्टेंस बनाएं और उसमें ActiveX नियंत्रणों वाले प्रेजेंटेशन को लोड करें।
2. इंडेक्स के आधार पर स्लाइड का रेफ़रेंस प्राप्त करें।
3. IControlCollection तक पहुँचकर स्लाइड में मौजूद ActiveX नियंत्रणों तक पहुँचें।
4. ControlEx ऑब्जेक्ट का उपयोग करके TextBox1 ActiveX नियंत्रण तक पहुँचें।
5. TextBox1 ActiveX नियंत्रण के विभिन्न गुणों जैसे टेक्स्ट, फ़ॉन्ट, फ़ॉन्ट ऊँचाई और फ्रेम स्थिति को बदलें।
6. CommandButton1 नामक दूसरे एक्सेस कंट्रोल तक पहुँचें।
7. बटन कैप्शन, फ़ॉन्ट और स्थिति बदलें।
8. ActiveX नियंत्रण के फ्रेम की स्थिति को शिफ्ट करें।
9. संशोधित प्रेजेंटेशन को PPTX फ़ाइल में लिखें।

नीचे दिया गया कोड स्निपेट प्रेजेंटेशन स्लाइड्स में ActiveX नियंत्रणों को नीचे दिखाए अनुसार अपडेट करता है।

``` cpp
// ActiveX नियंत्रणों के साथ प्रस्तुति तक पहुँच रहे हैं
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// प्रस्तुति में पहली स्लाइड तक पहुँच रहे हैं
auto slide = presentation->get_Slides()->idx_get(0);

// TextBox का टेक्स्ट बदल रहे हैं
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // स्थानीय छवि बदल रहे हैं। PowerPoint सक्रियण के दौरान इस छवि को बदल देगा, इसलिए कभी‑कभी छवि को अपरिवर्तित छोड़ देना ठीक है।
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// बटन का कैप्शन बदल रहे हैं
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // विकल्पीय चित्र बदल रहे हैं
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// ActiveX फ्रेम्स को 100 पॉइंट नीचे ले जा रहे हैं
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// संकलित ActiveX नियंत्रणों के साथ प्रस्तुति को सहेज रहे हैं
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// अब नियंत्रणों को हटा रहे हैं
slide->get_Controls()->Clear();

// साफ किए गए ActiveX नियंत्रणों के साथ प्रस्तुति को सहेज रहे हैं
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **Media Player ActiveX नियंत्रण जोड़ना**
ActiveX नियंत्रण प्रेजेंटेशन में उपयोग किए जाते हैं। Aspose.Slides for C++ आपको ActiveX नियंत्रण जोड़ने और प्रबंधित करने की सुविधा देता है, लेकिन इन्हें प्रबंधित करना थोड़ा जटिल और सामान्य प्रेजेंटेशन शैलियों से अलग है। Aspose.Slides for C++ 18.1 से, Media Player ActiveX नियंत्रण जोड़ने के लिए समर्थन Aspose.Slides में जोड़ा गया है। याद रखें, ActiveX नियंत्रण शैलियाँ नहीं हैं और प्रेजेंटेशन की IShapeCollection का हिस्सा नहीं होते बल्कि अलग IControlExCollection का हिस्सा होते हैं। यह लेख इनसे काम करने का तरीका दिखाता है। Media Player ActiveX नियंत्रण को प्रबंधित करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. Presentation क्लास का एक इंस्टेंस बनाएं और उसमें Media Player ActiveX नियंत्रणों वाले सैंपल प्रेजेंटेशन को लोड करें।
2. टार्गेट Presentation क्लास का एक इंस्टेंस बनाएं और एक खाली प्रेजेंटेशन बनायें।
3. टेम्पलेट प्रेजेंटेशन में Media Player ActiveX नियंत्रण वाली स्लाइड को टार्गेट Presentation में क्लोन करें।
4. टार्गेट Presentation में क्लोन की गई स्लाइड तक पहुँचें।
5. IControlCollection तक पहुँचकर स्लाइड में मौजूद ActiveX नियंत्रणों तक पहुँचें।
6. Media Player ActiveX नियंत्रण तक पहुँचें और उसकी प्रॉपर्टीज़ का उपयोग करके वीडियो पाथ सेट करें।
7. प्रेजेंटेशन को PPTX फ़ाइल में सहेजें।

``` cpp
// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंटिएट करें
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// खाली प्रस्तुति इंस्टेंस बनाएं
auto newPresentation = System::MakeObject<Presentation>();

// डिफ़ॉल्ट स्लाइड हटाएँ
newPresentation->get_Slides()->RemoveAt(0);

// Media Player ActiveX नियंत्रण वाली स्लाइड को क्लोन करें
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Media Player ActiveX नियंत्रण तक पहुँचें और वीडियो पाथ सेट करें
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// प्रस्तुति सहेजें
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**क्या Aspose.Slides C++ रनटाइम में निष्पादित नहीं हो सकने पर पढ़ते और पुनः सहेजते समय ActiveX नियंत्रणों को सुरक्षित रखता है?**

**हाँ। Aspose.Slides इन्हें प्रेजेंटेशन का हिस्सा मानता है और उनके गुणों और फ्रेम को पढ़/संशोधित कर सकता है; नियंत्रणों को स्वयं निष्पादित करने की आवश्यकता नहीं है उन्हें सुरक्षित रखने के लिए।**

**ActiveX नियंत्रण प्रेजेंटेशन में OLE ऑब्जेक्ट्स से कैसे भिन्न होते हैं?**

ActiveX नियंत्रण इंटरैक्टिव मैनेज्ड कंट्रोल (बटन, टेक्स्ट बॉक्स, मीडिया प्लेयर) होते हैं, जबकि [OLE](/slides/hi/cpp/manage-ole/) एम्बेडेड एप्लिकेशन ऑब्जेक्ट्स (उदाहरण के लिए, Excel वर्कशीट) को दर्शाता है। इन्हें अलग तरीके से संग्रहीत और संभाला जाता है तथा इनकी प्रॉपर्टी मॉडल अलग होती है।

**क्या ActiveX इवेंट्स और VBA मैक्रोज़ काम करते हैं यदि फाइल को Aspose.Slides द्वारा संशोधित किया गया हो?**

Aspose.Slides मौजूदा मार्कअप और मेटाडेटा को सुरक्षित रखता है; लेकिन इवेंट्स और मैक्रोज़ केवल Windows पर PowerPoint के अंदर ही चलते हैं जब सुरक्षा अनुमति देती है। लाइब्रेरी VBA को निष्पादित नहीं करती।