---
title: C++ में प्रस्तुति स्लाइड्स को इमेज में बदलें
linktitle: स्लाइड से इमेज
type: docs
weight: 41
url: /hi/cpp/convert-slide/
keywords:
- स्लाइड बदलें
- स्लाइड निर्यात करें
- स्लाइड से इमेज
- स्लाइड को इमेज के रूप में सहेजें
- स्लाइड से PNG
- स्लाइड से JPEG
- स्लाइड से बिटमैप
- स्लाइड से TIFF
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C++ में PPT, PPTX और ODP स्लाइड्स को इमेज में बदलें—तेज़, उच्च-गुणवत्ता रेंडरिंग और स्पष्ट कोड उदाहरणों के साथ।"
---
## **परिचय**

Aspose.Slides for C++ आपको आसानी से PowerPoint और OpenDocument प्रस्तुति स्लाइड्स को विभिन्न इमेज फ़ॉर्मेट्स, जैसे BMP, PNG, JPG (JPEG), GIF, और अन्य में परिवर्तित करने की सुविधा देता है।

एक स्लाइड को इमेज में बदलने के लिए, निम्न चरणों का पालन करें:

1. वांछित रूपांतरण सेटिंग्स को निर्धारित करें और उन स्लाइड्स को चुनें जिन्हें आप निर्यात करना चाहते हैं, इसके लिए उपयोग करें:
    - [ITiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/itiffoptions/) इंटरफ़ेस, या
    - [IRenderingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/irenderingoptions/) इंटरफ़ेस।
2. [GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/getimage/) मेथड को कॉल करके स्लाइड इमेज बनाएँ।

एक [Bitmap](https://reference.aspose.com/slides/hi/cpp/system.drawing/bitmap/) एक ऑब्जेक्ट है जो पिक्सेल डेटा द्वारा परिभाषित इमेज के साथ काम करने की अनुमति देता है। आप इस क्लास की एक इंस्टेंस का उपयोग करके BMP, JPG, PNG आदि जैसे कई फ़ॉर्मेट में इमेज सहेज सकते हैं।

## **स्लाइड्स को बिटमैप में बदलें और PNG में इमेज सहेजें**

आप स्लाइड को एक बिटमैप ऑब्जेक्ट में बदल सकते हैं और इसे सीधे अपने एप्लिकेशन में उपयोग कर सकते हैं। वैकल्पिक रूप से, आप स्लाइड को बिटमैप में बदलकर फिर JPEG या किसी अन्य पसंदीदा फ़ॉर्मेट में इमेज सहेज सकते हैं।

यह C++ कोड दर्शाता है कि प्रस्तुति की पहली स्लाइड को बिटमैप ऑब्जेक्ट में कैसे बदलें और फिर PNG फ़ॉर्मेट में इमेज सहेजें:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// प्रस्तुति में पहली स्लाइड को बिटमैप में बदलें।
auto image = presentation->get_Slide(0)->GetImage();

// इमेज को PNG फ़ॉर्मेट में सहेजें।
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **कस्टम आकार के साथ स्लाइड्स को इमेज में बदलें**

आपको किसी निश्चित आकार की इमेज चाहिए हो सकती है। [GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/getimage/) के एक ओवरलोड का उपयोग करके, आप स्लाइड को विशिष्ट आयाम (चौड़ाई और ऊँचाई) के साथ इमेज में बदल सकते हैं।

यह नमूना कोड दिखाता है कि यह कैसे किया जाए:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// प्रस्तुति में पहली स्लाइड को निर्दिष्ट आकार के साथ बिटमैप में बदलें।
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// इमेज को JPEG फ़ॉर्मेट में सहेजें।
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **नोट्स और कमेंट्स वाले स्लाइड्स को इमेज में बदलें**

कुछ स्लाइड्स में नोट्स और कमेंट्स हो सकते हैं।

Aspose.Slides दो इंटरफ़ेस—[ITiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/itiffoptions/) और [IRenderingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/irenderingoptions/)— प्रदान करता है जो प्रस्तुति स्लाइड्स को इमेज में रेंडर करने को नियंत्रित करते हैं। दोनों इंटरफ़ेस में `set_SlidesLayoutOptions` मेथड शामिल है, जो स्लाइड को इमेज में बदलते समय नोट्स और कमेंट्स के रेंडरिंग को कॉन्फ़िगर करने की अनुमति देता है।

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/notescommentslayoutingoptions/) क्लास के साथ, आप उत्पन्न इमेज में नोट्स और कमेंट्स की इच्छित स्थिति निर्दिष्ट कर सकते हैं।

यह C++ कोड दर्शाता है कि नोट्स और कमेंट्स वाले स्लाइड को कैसे बदला जाए:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// प्रस्तुति फ़ाइल लोड करें।
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // नोट्स की स्थिति सेट करें।
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // टिप्पणियों की स्थिति सेट करें।
notesCommentsOptions->set_CommentsAreaWidth(500);                          // टिप्पणी क्षेत्र की चौड़ाई सेट करें।
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // टिप्पणी क्षेत्र का रंग सेट करें.

// रेंडरिंग विकल्प बनाएं।
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// प्रस्तुति की पहली स्लाइड को इमेज में बदलें।
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// इमेज को GIF फ़ॉर्मेट में सहेजें।
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 
किसी भी स्लाइड-से-इमेज रूपांतरण प्रक्रिया में, [set_NotesPosition](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) मेथड `BottomFull` लागू नहीं कर सकता (नोट्स की स्थिति निर्दिष्ट करने के लिये) क्योंकि नोट का पाठ बहुत बड़ा हो सकता है, जिससे वह निर्दिष्ट इमेज आकार में फिट नहीं हो पाता।
{{% /alert %}} 

## **TIFF विकल्पों का उपयोग करके स्लाइड्स को इमेज में बदलें**

[ITiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/itiffoptions/) इंटरफ़ेस आपको आकार, रिज़ॉल्यूशन, कलर पैलेट आदि जैसे पैरामीटर निर्दिष्ट करके परिणामी TIFF इमेज पर अधिक नियंत्रण देता है।

यह C++ कोड एक रूपांतरण प्रक्रिया दर्शाता है जहाँ TIFF विकल्पों का उपयोग करके 300 DPI रिज़ॉल्यूशन और 2160 × 2800 आकार के साथ काली-से-बिल्ली इमेज आउटपुट की जाती है:

```cpp 
// प्रस्तुति फ़ाइल लोड करें।
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// प्रस्तुति से पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// आउटपुट TIFF इमेज की सेटिंग्स कॉन्फ़िगर करें।
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // इमेज का आकार सेट करें।
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // पिक्सेल फ़ॉर्मेट सेट करें (काला और सफ़ेद)।
tiffOptions->set_DpiX(300);                                         // क्षैतिज रेज़ॉल्यूशन सेट करें।
tiffOptions->set_DpiY(300);                                         // लंबवत रेज़ॉल्यूशन सेट करें.

// निर्दिष्ट विकल्पों के साथ स्लाइड को इमेज में बदलें।
auto image = slide->GetImage(tiffOptions);

// इमेज को TIFF फ़ॉर्मेट में सहेजें।
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **सभी स्लाइड्स को इमेज में बदलें**

Aspose.Slides आपको प्रस्तुति की सभी स्लाइड्स को इमेज में बदलने की अनुमति देता है, जिससे पूरी प्रस्तुति को इमेजों की श्रृंखला में बदला जा सकता है।

यह नमूना कोड दर्शाता है कि C++ में प्रस्तुती की सभी स्लाइड्स को इमेज में कैसे बदला जाए:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// प्रस्तुति को स्लाइड दर स्लाइड इमेज में रेंडर करें।
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // छिपी हुई स्लाइड्स को नियंत्रित करें (छिपी स्लाइड्स को रेंडर न करें)।
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // स्लाइड को इमेज में बदलें।
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // इमेज को JPEG फ़ॉर्मेट में सहेजें।
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **रंगीन इमोजी रेंडरिंग**

{{% alert title="Note" color="warning" %}} 
जब प्रस्तुति स्लाइड्स को इमेज में बदलते समय रंगीन इमोजी सही ढंग से रेंडर करने हों, तो प्रस्तुति में उपयोग किए गए इमोजी फ़ॉन्ट को उस प्रणाली पर स्थापित और उपलब्ध होना चाहिए जहाँ रूपांतरण किया जा रहा है। उदाहरण के लिए, यदि प्रस्तुति में **Segoe UI Emoji** फ़ॉन्ट उपयोग किया गया है और वह गायब है, तो आउटपुट इमेज में इमोजी मोनोक्रोम दिखाई दे सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides एनीमेशन के साथ स्लाइड्स को रेंडर करने का समर्थन करता है?**

नहीं, `GetImage` मेथड केवल स्लाइड की स्थिर इमेज सहेजता है, एनीमेशन नहीं।

**क्या छिपी हुई स्लाइड्स को इमेज के रूप में निर्यात किया जा सकता है?**

हाँ, छिपी हुई स्लाइड्स को सामान्य स्लाइड्स की तरह प्रोसेस किया जा सकता है। सुनिश्चित करें कि वे प्रोसेसिंग लूप में शामिल हों।

**क्या इमेजेस को छाया और प्रभावों के साथ सहेजा जा सकता है?**

हाँ, Aspose.Slides स्लाइड्स को इमेज के रूप में सहेजते समय छाया, पारदर्शिता और अन्य ग्राफ़िक प्रभावों को रेंडर करने का समर्थन करता है।