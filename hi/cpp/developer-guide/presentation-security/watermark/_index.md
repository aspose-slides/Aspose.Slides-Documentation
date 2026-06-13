---
title: प्रस्तुति में वॉटरमार्क जोड़ें C++ के साथ
linktitle: वॉटरमार्क
type: docs
weight: 40
url: /hi/cpp/watermark/
keywords:
- वॉटरमार्क
- पाठ वॉटरमार्क
- छवि वॉटरमार्क
- वॉटरमार्क जोड़ें
- वॉटरमार्क बदलें
- वॉटरमार्क हटाएँ
- वॉटरमार्क मिटाएँ
- PPT में वॉटरमार्क जोड़ें
- PPTX में वॉटरमार्क जोड़ें
- ODP में वॉटरमार्क जोड़ें
- PPT से वॉटरमार्क हटाएँ
- PPTX से वॉटरमार्क हटाएँ
- ODP से वॉटरमार्क हटाएँ
- PPT से वॉटरमार्क मिटाएँ
- PPTX से वॉटरमार्क मिटाएँ
- ODP से वॉटरमार्क मिटाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ में PowerPoint और OpenDocument प्रस्तुतियों में पाठ और छवि वॉटरमार्क प्रबंधित करें ताकि ड्राफ्ट, गोपनीय जानकारी, कॉपीराइट आदि को दर्शाया जा सके।"
---
## **परिचय**

**एक वॉटरमार्क** प्रस्तुति में वह पाठ या चित्र मोहर है जो किसी स्लाइड पर या सभी प्रस्तुति स्लाइडों में प्रयुक्त होती है। आमतौर पर वॉटरमार्क यह दर्शाने के लिए उपयोग किया जाता है कि प्रस्तुति ड्राफ्ट है (जैसे, “Draft” वॉटरमार्क), इसमें गोपनीय जानकारी है (जैसे, “Confidential” वॉटरमार्क), यह किस कंपनी की है (जैसे, “Company Name” वॉटरमार्क), प्रस्तुति के लेखक की पहचान आदि। वॉटरमार्क यह संकेत देकर कॉपीराइट उल्लंघन को रोकने में मदद करता है कि प्रस्तुति की नकल नहीं की जानी चाहिए। वॉटरमार्क दोनों PowerPoint और OpenOffice प्रस्तुति फ़ॉर्मेट में प्रयुक्त होते हैं। Aspose.Slides में आप PowerPoint PPT, PPTX और OpenOffice ODP फ़ाइल फ़ॉर्मेट में वॉटरमार्क जोड़ सकते हैं।

Aspose.Slides में, PowerPoint या OpenOffice दस्तावेज़ों में वॉटरमार्क बनाने और उनके डिज़ाइन व व्यवहार को बदलने के कई तरीके हैं। सामान्य बात यह है कि पाठ वॉटरमार्क जोड़ने के लिए आपको **ITextFrame** इंटरफ़ेस का प्रयोग करना चाहिए, और चित्र वॉटरमार्क जोड़ने के लिए **PictureFrame** क्लास या वॉटरमार्क आकृति को चित्र से भरना चाहिए। **PictureFrame** **IShape** इंटरफ़ेस को लागू करता है, जिससे आप आकृति ऑब्जेक्ट की सभी लचीली सेटिंग्स इस्तेमाल कर सकते हैं। चूँकि **ITextFrame** एक आकृति नहीं है और उसकी सेटिंग्स सीमित हैं, इसे **IShape** ऑब्जेक्ट में लपेटा जाता है।

वॉटरमार्क लागू करने के दो तरीके हैं: एकल स्लाइड पर या सभी प्रस्तुति स्लाइडों पर। सभी स्लाइडों पर वॉटरमार्क लागू करने के लिए **Slide Master** का उपयोग किया जाता है — वॉटरमार्क को Slide Master में जोड़ा जाता है, वहाँ पूर्ण रूप से डिज़ाइन किया जाता है, और सभी स्लाइडों पर लागू किया जाता है, जबकि व्यक्तिगत स्लाइडों पर वॉटरमार्क को संशोधित करने की अनुमति प्रभावित नहीं होती।

आमतौर पर वॉटरमार्क को अन्य उपयोगकर्ताओं द्वारा संपादित नहीं किया जा सकता माना जाता है। वॉटरमार्क (या मूलतः वॉटरमार्क की पैरेंट आकृति) को संपादन से रोकने के लिए Aspose.Slides आकृति लॉकिंग कार्यक्षमता प्रदान करता है। किसी विशिष्ट आकृति को सामान्य स्लाइड पर या Slide Master पर लॉक किया जा सकता है। जब Slide Master पर वॉटरमार्क आकृति लॉक होती है, तो वह सभी प्रस्तुति स्लाइडों पर लॉक हो जाती है।

आप वॉटरमार्क का नाम सेट कर सकते हैं ताकि भविष्य में उसे हटाना चाहें, तो इसे स्लाइड की आकृतियों में नाम से खोजा जा सके।

आप वॉटरमार्क को किसी भी शैली में बना सकते हैं; हालाँकि सामान्यतः वॉटरमार्क में कुछ सामान्य विशेषताएँ होती हैं, जैसे कि मध्य संरेखण, घूर्णन, अग्रस्थिति आदि। नीचे दिए गए उदाहरणों में हम इनका उपयोग कैसे करें, देखते हैं।

## **पाठ वॉटरमार्क**

### **एक स्लाइड में पाठ वॉटरमार्क जोड़ें**

PPT, PPTX या ODP में पाठ वॉटरमार्क जोड़ने के लिए आप पहले स्लाइड में एक आकृति जोड़ सकते हैं, फिर उस आकृति में एक टेक्स्ट फ्रेम जोड़ें। टेक्स्ट फ्रेम **ITextFrame** इंटरफ़ेस द्वारा प्रतिनिधित्व किया जाता है। यह प्रकार **IShape** से विरासत में नहीं मिला है, जिसके पास वॉटरमार्क को लचीले ढंग से स्थित करने के लिए विस्तृत गुण होते हैं। इसलिए, **ITextFrame** ऑब्जेक्ट को **IAutoShape** ऑब्जेक्ट में लपेटा जाता है। आकृति में वॉटरमार्क पाठ जोड़ने के लिए नीचे दिखाए अनुसार **AddTextFrame** मेथड का उपयोग करें।

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/hi/cpp/text-formatting/)
{{% /alert %}}

### **एक प्रस्तुति में पाठ वॉटरमार्क जोड़ें**

यदि आप पूरी प्रस्तुति (यानी सभी स्लाइडों में एक बार) में पाठ वॉटरमार्क जोड़ना चाहते हैं, तो इसे **MasterSlide** में जोड़ें। शेष लॉजिक वही है जैसा एकल स्लाइड में वॉटरमार्क जोड़ते समय होता है — एक **IAutoShape** ऑब्जेक्ट बनाइए और फिर **AddTextFrame** मेथड से उसमें वॉटरमार्क जोड़िए।

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/hi/cpp/slide-master/)
{{% /alert %}}

### **वॉटरमार्क आकृति की पारदर्शिता सेट करें**

डिफ़ॉल्ट रूप से आयत आकृति को भराव और रेखा रंगों से स्टाइल किया गया होता है। नीचे दिया कोड आकृति को पारदर्शी बनाता है।

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **पाठ वॉटरमार्क का फ़ॉन्ट सेट करें**

आप नीचे दिखाए अनुसार पाठ वॉटरमार्क का फ़ॉन्ट बदल सकते हैं।

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **वॉटरमार्क पाठ का रंग सेट करें**

वॉटरमार्क पाठ का रंग सेट करने के लिए यह कोड उपयोग करें:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **पाठ वॉटरमार्क को मध्य में रखें**

आप स्लाइड पर वॉटरमार्क को मध्य में रख सकते हैं; इसके लिए नीचे दिया गया कोड उपयोग करें:

```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

नीचे की छवि अंतिम परिणाम दिखाती है।

![पाठ वॉटरमार्क](text_watermark.png)

## **छवि वॉटरमार्क**

### **एक प्रस्तुति में छवि वॉटरमार्क जोड़ें**

प्रस्तुति स्लाइड में छवि वॉटरमार्क जोड़ने के लिए आप निम्नलिखित कर सकते हैं:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **वॉटरमार्क को संपादन से लॉक करें**

यदि वॉटरमार्क को संपादित होने से रोकना आवश्यक है, तो आकृति पर **IAutoShape::get_AutoShapeLock** मेथड का उपयोग करें। इस प्रॉपर्टी के साथ आप आकृति को चयन, आकार बदलना, पुन:स्थित करना, अन्य तत्वों के साथ समूहित करना, उसके पाठ को संपादन से लॉक करना आदि से सुरक्षित रख सकते हैं:

```cpp
// वॉटरमार्क आकृति को संशोधन से लॉक करें
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **वॉटरमार्क को अग्रभाग में लाएँ**

Aspose.Slides में आकृतियों के Z‑order को **IShapeCollection::Reorder** मेथड के माध्यम से सेट किया जा सकता है। इसके लिए आपको प्रस्तुति स्लाइड सूची से इस मेथड को कॉल करना होगा और आकृति रेफ़रेंस एवं उसका क्रमांक पास करना होगा। इस प्रकार आप आकृति को अग्रभाग में ला सकते हैं या स्लाइड के पीछे भेज सकते हैं। यह सुविधा विशेष रूप से तब उपयोगी होती है जब आपको वॉटरमार्क को प्रस्तुति के सामने रखना हो:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **वॉटरमार्क का घूर्णन सेट करें**

नीचे कोड उदाहरण दर्शाता है कि वॉटरमार्क का घूर्णन कैसे समायोजित करें ताकि वह स्लाइड में तिरछे स्थित हो:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **वॉटरमार्क के लिए नाम सेट करें**

Aspose.Slides आपको आकृति का नाम सेट करने की अनुमति देता है। आकृति नाम का उपयोग करके आप भविष्य में उसे संशोधित या हटाने के लिए खोज सकते हैं। वॉटरमार्क आकृति का नाम सेट करने के लिए इसे **IAutoShape::set_Name** मेथड को असाइन करें:

```cpp
watermarkShape->set_Name(u"watermark");
```

## **वॉटरमार्क हटाएँ**

वॉटरमार्क आकृति को हटाने के लिए **IAutoShape::get_Name** मेथड से उसे स्लाइड की आकृतियों में खोजें। फिर वॉटरमार्क आकृति को **IShapeCollection::Remove** मेथड में पास करें:

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **एक लाइव उदाहरण**

आप Aspose.Slides के मुफ्त [Add Watermark](https://products.aspose.app/slides/hi/watermark) और [Remove Watermark](https://products.aspose.app/slides/hi/watermark/remove-watermark) ऑनलाइन टूल्स देख सकते हैं।

![ऑनलाइन टूल्स वॉटरमार्क जोड़ने और हटाने के लिए](online_tools.png)

## **FAQ**

**वॉटरमार्क क्या है और मुझे इसे क्यों उपयोग करना चाहिए?**  
वॉटरमार्क एक पाठ या चित्र ओवरले है जो स्लाइडों पर लागू होता है और बौद्धिक संपदा को सुरक्षित रखने, ब्रांड पहचान बढ़ाने या अनधिकृत प्रस्तुति उपयोग को रोकने में मदद करता है।

**क्या मैं सभी स्लाइडों में वॉटरमार्क जोड़ सकता हूँ?**  
हाँ, Aspose.Slides आपको प्रोग्रामmatically प्रत्येक स्लाइड पर वॉटरमार्क जोड़ने की अनुमति देता है। आप सभी स्लाइडों पर लूप करके वॉटरमार्क सेटिंग्स लागू कर सकते हैं।

**मैं वॉटरमार्क की पारदर्शिता कैसे समायोजित करूँ?**  
आप आकृति की भराव सेटिंग्स (**FillFormat**(https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/get_fillformat/)) को बदलकर वॉटरमार्क की पारदर्शिता समायोजित कर सकते हैं। इससे वॉटरमार्क सूक्ष्म बना रहता है और स्लाइड सामग्री से ध्यान नहीं भटकाता।

**वॉटरमार्क के लिए कौन‑से चित्र फ़ॉर्मेट समर्थित हैं?**  
Aspose.Slides PNG, JPEG, GIF, BMP, SVG और अन्य कई चित्र फ़ॉर्मेट का समर्थन करता है।

**क्या मैं पाठ वॉटरमार्क का फ़ॉन्ट और शैली अनुकूलित कर सकता हूँ?**  
हाँ, आप अपनी प्रस्तुति के डिज़ाइन और ब्रांड संगतता के अनुसार कोई भी फ़ॉन्ट, आकार और शैली चुन सकते हैं।

**मैं वॉटरमार्क की स्थिति या अभिविन्यास कैसे बदलूँ?**  
आप प्रोग्रामmatically आकृति के निर्देशांक, आकार और घूर्णन गुण बदलकर वॉटरमार्क की स्थिति और अभिविन्यास समायोजित कर सकते हैं।