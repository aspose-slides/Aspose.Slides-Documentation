---
title: C++ में प्रस्तुति स्लाइड्स को छवियों में बदलें
linktitle: स्लाइड से छवि
type: docs
weight: 41
url: /hi/cpp/convert-slide/
keywords: 
- स्लाइड बदलें
- स्लाइड निर्यात करें
- स्लाइड से छवि
- स्लाइड को छवि के रूप में सहेजें
- स्लाइड से PNG
- स्लाइड से JPEG
- स्लाइड से बिटमैप
- स्लाइड से TIFF
- PowerPoint
- OpenDocument
- प्रस्तुती
- C++
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C++ में PPT, PPTX और ODP की स्लाइड्स को छवियों में बदलें—तेज़, उच्च-गुणवत्ता रेंडरिंग के साथ स्पष्ट कोड उदाहरण।"
---
## **परिचय**

Aspose.Slides for C++ आपको PowerPoint और OpenDocument प्रस्तुति स्लाइड्स को विभिन्न छवि प्रारूपों जैसे BMP, PNG, JPG (JPEG), GIF और अन्य में आसानी से बदलने में सक्षम बनाता है।

एक स्लाइड को छवि में परिवर्तित करने के लिए, नीचे दी गई चरणों का पालन करें:

1. वांछित रूपांतरण सेटिंग्स को परिभाषित करें और उन स्लाइड्स का चयन करें जिन्हें आप निर्यात करना चाहते हैं, इस प्रकार:
    - [ITiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/itiffoptions/) इंटरफ़ेस, या
    - [IRenderingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/irenderingoptions/) इंटरफ़ेस.
2. स्लाइड छवि को बनाने के लिए [GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/getimage/) मेथड को कॉल करें।

[Bitmap](https://reference.aspose.com/slides/hi/cpp/system.drawing/bitmap/) एक ऑब्जेक्ट है जो पिक्सेल डेटा द्वारा परिभाषित छवियों के साथ काम करने की अनुमति देता है। आप इस क्लास की एक इंस्टेंस का उपयोग करके विभिन्न प्रारूपों (BMP, JPG, PNG, आदि) में छवियों को सहेज सकते हैं।

## **स्लाइड्स को बिटमैप में बदलें और PNG में छवियों को सहेजें**

आप स्लाइड को बिटमैप ऑब्जेक्ट में बदल सकते हैं और उसे सीधे अपने एप्लिकेशन में उपयोग कर सकते हैं। वैकल्पिक रूप से, आप स्लाइड को बिटमैप में बदलकर फिर छवि को JPEG या किसी अन्य इच्छित फ़ॉर्मेट में सहेज सकते हैं।

यह C++ कोड दिखाता है कि प्रस्तुति की पहली स्लाइड को बिटमैप ऑब्जेक्ट में कैसे बदलें और फिर PNG फ़ॉर्मेट में छवि को कैसे सहेजें:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Convert the first slide in the presentation to a bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Save the image in the PNG format.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **कस्टम आकार के साथ स्लाइड्स को छवियों में बदलें**

आपको किसी निश्चित आकार की छवि चाहिए हो सकती है। [GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/getimage/) के ओवरलोड का उपयोग करके, आप स्लाइड को विशिष्ट आयामों (चौड़ाई और ऊँचाई) के साथ छवि में बदल सकते हैं। 

यह नमूना कोड दिखाता है कि इसे कैसे करें:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// प्रस्तुति में पहले स्लाइड को निर्दिष्ट आकार के साथ बिटमैप में बदलें।
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// छवि को JPEG फ़ॉर्मेट में सहेजें।
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **नोट्स और कमेंट्स वाली स्लाइड्स को छवियों में बदलें**

कुछ स्लाइड्स में नोट्स और कमेंट्स हो सकते हैं।

Aspose.Slides दो इंटरफ़ेस प्रदान करता है—[ITiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/itiffoptions/) और [IRenderingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/irenderingoptions/)—जो आपको प्रस्तुति स्लाइड्स को छवियों में रेंडर करने को नियंत्रित करने की अनुमति देते हैं। दोनों इंटरफ़ेस में `set_SlidesLayoutOptions` मेथड शामिल है, जो स्लाइड को छवि में बदलते समय नोट्स और कमेंट्स के रेंडरिंग को कॉन्फ़िगर करने में सक्षम बनाता है।

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/notescommentslayoutingoptions/) क्लास के साथ, आप परिणामी छवि में नोट्स और कमेंट्स की वांछित स्थिति निर्दिष्ट कर सकते हैं।

यह C++ कोड दिखाता है कि नोट्स और कमेंट्स वाली स्लाइड को कैसे बदलें:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// प्रस्तुति फ़ाइल लोड करें।
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // नोट्स की स्थिति सेट करें।
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // कमेंट्स की स्थिति सेट करें।
notesCommentsOptions->set_CommentsAreaWidth(500);                          // कमेंट्स क्षेत्र की चौड़ाई सेट करें।
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // कमेंट्स क्षेत्र के लिए रंग सेट करें।

// रेंडरिंग विकल्प बनाएं।
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// प्रस्तुति की पहली स्लाइड को छवि में बदलें।
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// छवि को GIF फ़ॉर्मेट में सहेजें।
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 
किसी भी स्लाइड-से-छवि रूपांतरण प्रक्रिया में, [set_NotesPosition](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) मेथड `BottomFull` लागू नहीं कर सकता (नोट्स की स्थिति निर्दिष्ट करने के लिए) क्योंकि नोट का टेक्स्ट बहुत बड़ा हो सकता है, जिससे वह निर्दिष्ट छवि आकार में फिट नहीं हो पाता। 
{{% /alert %}} 

## **TIFF विकल्पों का उपयोग करके स्लाइड्स को छवियों में बदलें**

[ITiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/itiffoptions/) इंटरफ़ेस आपको आकार, रिज़ॉल्यूशन, कलर पैलेट आदि जैसे पैरामीटर निर्दिष्ट करके उत्पन्न TIFF छवि पर अधिक नियंत्रण देता है।

यह C++ कोड एक रूपांतरण प्रक्रिया दर्शाता है जहाँ TIFF विकल्पों का उपयोग करके 300 DPI रिज़ॉल्यूशन और 2160 × 2800 आकार की काली-सेफ़ेद छवि आउटपुट की जाती है:

```cpp 
// प्रस्तुति फ़ाइल लोड करें।
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// प्रस्तुति से पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// आउटपुट TIFF छवि की सेटिंग्स कॉन्फ़िगर करें।
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // छवि का आकार सेट करें।
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // पिक्सेल फ़ॉर्मेट सेट करें (काला और सफ़ेद)।
tiffOptions->set_DpiX(300);                                         // क्षैतिज रिज़ॉल्यूशन सेट करें।
tiffOptions->set_DpiY(300);                                         // ऊर्ध्वाधर रिज़ॉल्यूशन सेट करें.

// निर्दिष्ट विकल्पों के साथ स्लाइड को छवि में बदलें।
auto image = slide->GetImage(tiffOptions);

// छवि को TIFF फ़ॉर्मेट में सहेजें।
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **सभी स्लाइड्स को छवियों में बदलें**

Aspose.Slides आपको प्रस्तुति की सभी स्लाइड्स को छवियों में बदलने की अनुमति देता है, जिससे पूरी प्रस्तुति को छवियों की श्रृंखला में प्रभावी रूप से बदल दिया जाता है।

यह नमूना कोड दिखाता है कि C++ में प्रस्तुति की सभी स्लाइड्स को छवियों में कैसे बदलें:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// प्रस्तुति को स्लाइड दर स्लाइड छवियों में रेंडर करें।
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // छिपी स्लाइड्स को नियंत्रित करें (छिपी स्लाइड्स को रेंडर न करें)।
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // स्लाइड को छवि में बदलें।
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // छवि को JPEG फ़ॉर्मेट में सहेजें।
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides एनीमेशन के साथ स्लाइड्स को रेंडर करने का समर्थन करता है?**

नहीं, `GetImage` मेथड स्लाइड की केवल स्थिर छवि को सहेजता है, एनीमेशन के बिना।

**क्या छिपी हुई स्लाइड्स को छवियों के रूप में निर्यात किया जा सकता है?**

हां, छिपी हुई स्लाइड्स को सामान्य स्लाइड्स की तरह ही प्रोसेस किया जा सकता है। सुनिश्चित करें कि वे प्रोसेसिंग लूप में शामिल हों।

**क्या छवियों को शैडो और इफ़ेक्ट्स के साथ सहेजा जा सकता है?**

हां, Aspose.Slides स्लाइड्स को छवियों के रूप में सहेजते समय शैडो, ट्रांसपैरेंसी और अन्य ग्राफ़िक इफ़ेक्ट्स को रेंडर करने का समर्थन करता है।