---
title: .NET में प्रस्तुतियों में वॉटरमार्क जोड़ें
linktitle: वॉटरमार्क
type: docs
weight: 40
url: /hi/net/watermark/
keywords:
- वॉटरमार्क
- टेक्स्ट वॉटरमार्क
- इमेज वॉटरमार्क
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
- .NET
- C#
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में .NET के साथ टेक्स्ट और इमेज वॉटरमार्क प्रबंधित करें ताकि ड्राफ्ट, गोपनीय जानकारी, कॉपीराइट आदि दर्शाए जा सकें।"
---
## **परिचय**

**वॉटरमार्क** प्रस्तुति में एक पाठ या छवि मोहर है जो किसी स्लाइड पर या सभी प्रस्तुति स्लाइडों में उपयोग की जाती है। आमतौर पर, वॉटरमार्क यह दर्शाने के लिए उपयोग किया जाता है कि प्रस्तुति ड्राफ्ट है (उदाहरण के लिए, "Draft" वॉटरमार्क), इसमें गोपनीय जानकारी है (उदाहरण के लिए, "Confidential" वॉटरमार्क), यह किस कंपनी की है यह बताने के लिए (उदाहरण के लिए, "Company Name" वॉटरमार्क), प्रस्तुति लेखक की पहचान करने आदि। वॉटरमार्क कॉपीराइट उल्लंघन को रोकने में मदद करता है यह संकेत देकर कि प्रस्तुति की नकल नहीं की जानी चाहिए। वॉटरमार्क दोनों PowerPoint और OpenDocument प्रस्तुति फ़ॉर्मेट में उपयोग किए जाते हैं। Aspose.Slides में, आप PowerPoint PPT, PPTX और OpenDocument ODP फ़ाइल फ़ॉर्मेट में वॉटरमार्क जोड़ सकते हैं।

In [**Aspose.Slides**](https://products.aspose.com/slides/hi/net/), Aspose.Slides में, PowerPoint या OpenDocument दस्तावेज़ों में वॉटरमार्क बनाने और उनके डिज़ाइन और व्यवहार को संशोधित करने के विभिन्न तरीके हैं। सामान्य बात यह है कि पाठ वॉटरमार्क जोड़ने के लिए आपको [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) interface का उपयोग करना चाहिए, और छवि वॉटरमार्क जोड़ने के लिए [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/) class या वॉटरमार्क आकार को छवि से भरना चाहिए। `PictureFrame` implements the [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape) interface, allowing you to use all the flexible settings of the shape object. Since `ITextFrame` is not a shape and its settings are limited, it is wrapped into an [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape) object.

वॉटरमार्क लागू करने के दो तरीके हैं: एकल स्लाइड पर या सभी प्रस्तुति स्लाइडों पर। स्लाइड मास्टर का उपयोग सभी प्रस्तुति स्लाइडों पर वॉटरमार्क लागू करने के लिए किया जाता है — वॉटरमार्क स्लाइड मास्टर में जोड़ा जाता है, वहाँ पूर्ण रूप से डिज़ाइन किया जाता है, और सभी स्लाइडों पर लागू किया जाता है बिना व्यक्तिगत स्लाइडों पर वॉटरमार्क को संशोधित करने की अनुमति को प्रभावित किए।

वॉटरमार्क आमतौर पर अन्य उपयोगकर्ताओं द्वारा संपादन योग्य नहीं माना जाता। वॉटरमार्क (या वॉटरमार्क के पैरेंट आकार) को संपादित होने से रोकने के लिए, Aspose.Slides shape locking कार्यक्षमता प्रदान करता है। एक विशिष्ट आकार को सामान्य स्लाइड या Slide Master पर लॉक किया जा सकता है। जब वॉटरमार्क आकार Slide Master पर लॉक किया जाता है, तो यह सभी प्रस्तुति स्लाइडों पर लॉक हो जाएगा।

आप वॉटरमार्क का नाम सेट कर सकते हैं ताकि भविष्य में यदि आप इसे हटाना चाहते हैं, तो आप इसे स्लाइड के आकारों में नाम द्वारा पा सकें।

आप वॉटरमार्क को किसी भी तरह से डिज़ाइन कर सकते हैं; हालांकि, आमतौर पर वॉटरमार्क में कुछ सामान्य विशेषताएँ होती हैं, जैसे केंद्र संरेखण, घूर्णन, अग्रस्थान आदि। हम नीचे के उदाहरणों में इनका उपयोग कैसे करें, इस पर विचार करेंगे।

## **पाठ वॉटरमार्क**

### **स्लाइड में पाठ वॉटरमार्क जोड़ें**

PPT, PPTX या ODP में पाठ वॉटरमार्क जोड़ने के लिए, आप पहले स्लाइड में एक आकार जोड़ सकते हैं, फिर इस आकार में एक टेक्स्ट फ्रेम जोड़ें। टेक्स्ट फ्रेम को [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe) interface द्वारा प्रतिनिधित्व किया जाता है। यह प्रकार [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) से विरासत में नहीं मिला है, जिसके पास वॉटरमार्क को लचीले तरीके से स्थित करने के लिए कई गुण होते हैं। इसलिए, [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe) object को एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) object में लपेटा जाता है। आकार में वॉटरमार्क पाठ जोड़ने के लिए, नीचे दिखाए अनुसार [AddTextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/methods/addtextframe) मेथड का उपयोग करें।

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// स्लाइड में वॉटरमार्क जोड़ें।
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="और देखें" %}} 
- [टेक्स्टफ़्रेम क्लास का उपयोग कैसे करें?](/slides/hi/net/text-formatting/)
{{% /alert %}}

### **प्रस्तुति में पाठ वॉटरमार्क जोड़ें**

यदि आप पूरे प्रस्तुति (अर्थात सभी स्लाइडों) में पाठ वॉटरमार्क जोड़ना चाहते हैं, तो इसे [MasterSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/masterslide/) में जोड़ें। बाकी लॉजिक एकल स्लाइड में वॉटरमार्क जोड़ने के समान है — एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) object बनाएं और फिर [AddTextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/methods/addtextframe) मेथड का उपयोग करके वॉटरमार्क जोड़ें।

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// मास्टर स्लाइड में वॉटरमार्क जोड़ें।
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="और देखें" %}} 
- [Slide Master का उपयोग कैसे करें?](/slides/hi/net/slide-master/)
{{% /alert %}}

### **वॉटरमार्क आकार की पारदर्शिता सेट करें**

डिफ़ॉल्ट रूप में, आयताकार आकार को fill और line रंगों के साथ स्टाइल किया जाता है। इसका मतलब है कि जब वॉटरमार्क जोड़ा जाता है, तो यह ठोस पृष्ठभूमि या बॉर्डर के साथ दिखाई दे सकता है जो स्लाइड की सामग्री से ध्यान भटका सकता है। वॉटरमार्क को सूक्ष्म रखने और प्रस्तुति के दृश्य डिज़ाइन में बाधा न डालने के लिए, आप आकार को पूरी तरह से पारदर्शी बना सकते हैं।

निम्नलिखित कोड पंक्तियों से आकार की fill और border दोनों रंगों को हटाकर उसे पारदर्शी बनाया जाता है:

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **पाठ वॉटरमार्क के फ़ॉन्ट को सेट करें**

स्लाइड में पाठ वॉटरमार्क लागू करने से पहले, इसका स्वरूप अनुकूलित करना महत्वपूर्ण है ताकि यह समग्र डिज़ाइन के साथ सामंजस्य स्थापित करे। आप फ़ॉन्ट प्रकार और आकार बदल सकते हैं ताकि वॉटरमार्क पठनीय और सौंदर्यपूर्ण हो। फ़ॉन्ट को कस्टमाइज़ करना ब्रांड पहचान को सुदृढ़ करने या बस प्रस्तुति शैली से मेल खाने में मदद करता है।

निम्न कोड स्निपेट एक विशिष्ट लैटिन फ़ॉन्ट चुनकर उचित फ़ॉन्ट ऊँचाई सेट करके वॉटरमार्क के फ़ॉन्ट सेटिंग्स को समायोजित करता है:

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **वॉटरमार्क पाठ का रंग सेट करें**

वॉटरमार्क लागू करने से पहले, यह सुनिश्चित करना आवश्यक है कि पाठ रंग उचित रूप से सेट हो ताकि वह आपके स्लाइड सामग्री के साथ अच्छा मेल बनाए और उसे अधिक नहीं भड़के। रंग की पारदर्शिता (alpha) को रेड, ग्रीन और ब्लू घटकों के साथ समायोजित करके आप एक सूक्ष्म, अर्द्ध-पारदर्शी वॉटरमार्क बना सकते हैं जो दृश्यमान लेकिन अग्रभूमि में नहीं है। यह तरीका आपके मुख्य प्रस्तुति पर ध्यान बनाए रखता है जबकि आपके कंटेंट को सुरक्षित रखता है।

वॉटरमार्क पाठ का रंग सेट करने के लिए, निम्न कोड का उपयोग करें:

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **पाठ वॉटरमार्क को केंद्रित करें**

पाठ वॉटरमार्क को सही ढंग से केंद्रित करने से आपके प्रस्तुति की सौंदर्यशास्त्र में काफी सुधार होता है, क्योंकि वॉटरमार्क स्लाइड आयामों के बावजूद सममित रूप से स्थित रहता है। यह आपके स्लाइड को पेशेवर लुक देता है और मुख्य सामग्री में बाधा नहीं बनता।

निम्न कोड स्निपेट स्लाइड के केंद्र स्थान की गणना करके पाठ वॉटरमार्क को उसी अनुसार रखता है:

```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

नीचे चित्र अंतिम परिणाम दिखाता है।

![पाठ वॉटरमार्क](text_watermark.png)

## **छवि वॉटरमार्क**

### **प्रस्तुति में छवि वॉटरमार्क जोड़ें**

कई मामलों में, छवि वॉटरमार्क एक अनोखा ब्रांडिंग तत्व या पाठ वॉटरमार्क का अधिक दृश्य रूप से आकर्षक विकल्प प्रदान कर सकता है। वॉटरमार्क जोड़ने से पहले सुनिश्चित करें कि छवि फ़ाइल उपलब्ध है (उदाहरण के लिए, पारदर्शिता के लिए PNG)। नीचे दिया गया उदाहरण दर्शाता है कि कैसे अपने फ़ाइल सिस्टम से छवि लोड करें, उसे प्रस्तुति में जोड़ें, और फिर आकार की fill प्रॉपर्टी का उपयोग करके इसे वॉटरमार्क के रूप में लागू करें।

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **वॉटरमार्क को संपादन से लॉक करें**

यदि वॉटरमार्क को संपादित होने से रोकना आवश्यक है, तो आकार पर [IAutoShape.ShapeLock](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/properties/shapelock) प्रॉपर्टी का उपयोग करें। इस प्रॉपर्टी के साथ आप आकार को चयन, आकार बदलने, पुनःवस्थान, अन्य तत्वों के साथ समूह बनाने, उसके टेक्स्ट को संपादन से लॉक करने आदि से सुरक्षित रख सकते हैं:

```cs
// वॉटरमार्क आकार को संशोधित करने से लॉक करें।
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **वॉटरमार्क को आगे लाएँ**

Aspose.Slides में, आकारों का Z-order [IShapeCollection.Reorder](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/reorder/#reorder) मेथड द्वारा सेट किया जा सकता है। ऐसा करने के लिए, आपको प्रस्तुति स्लाइडों की सूची से इस मेथड को कॉल करना होगा और आकार रेफ़रेंस और उसका क्रमांक मेथड में पास करना होगा। इस तरह, आप आकार को स्लाइड के आगे या पीछे ले जा सकते हैं। यह सुविधा विशेष रूप से तब उपयोगी होती है जब आपको वॉटरमार्क को प्रस्तुति के सामने रखना हो:

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **वॉटरमार्क घूर्णन सेट करें**

वॉटरमार्क का घूर्णन समायोजित करने से आपके प्रस्तुति की दृश्य प्रभावशीलता और सूक्ष्मता में काफी सुधार हो सकता है। उदाहरण के लिए, तिरछा वॉटरमार्क कम बाधक हो सकता है जबकि अभी भी अनधिकृत उपयोग के खिलाफ मजबूत सुरक्षा प्रदान करता है। नीचे दिया गया उदाहरण स्लाइड के आयामों के आधार पर उपयुक्त कोण की गणना करता है ताकि वॉटरमार्क स्लाइड में तिरछा स्थित हो। यह गतिशील गणना सुनिश्चित करती है कि विभिन्न स्लाइड आकारों के बावजूद वॉटरमार्क प्रभावी बना रहे।

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **वॉटरमार्क को नाम दें**

Aspose.Slides आपको आकार का नाम सेट करने की अनुमति देता है। आकार नाम का उपयोग करके आप भविष्य में इसे संशोधित या हटाने के लिए ढूँढ सकते हैं। वॉटरमार्क आकार का नाम सेट करने के लिए, इसे [IAutoShape.Name](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/properties/name) प्रॉपर्टी को असाइन करें:

```cs
watermarkShape.Name = "watermark";
```

## **वॉटरमार्क हटाएँ**

वॉटरमार्क आकार को हटाने के लिए, स्लाइड के आकारों में इसे खोजने हेतु [IAutoShape.Name](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/properties/name) प्रॉपर्टी का उपयोग करें। फिर, वॉटरमार्क आकार को [IShapeCollection.Remove](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/remove/) मेथड में पास करें:

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **एक लाइव उदाहरण**

आप **Aspose.Slides फ़्री** [Add Watermark](https://products.aspose.app/slides/hi/watermark) और [Remove Watermark](https://products.aspose.app/slides/hi/watermark/remove-watermark) ऑनलाइन टूल्स को देख सकते हैं।

![ऑनलाइन टूल्स वॉटरमार्क जोड़ने और हटाने के लिए](online_tools.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**वॉटरمار्क क्या है और मुझे इसे क्यों उपयोग करना चाहिए?**

वॉटरमार्क एक पाठ या छवि ओवरले है जो स्लाइडों पर लागू किया जाता है और बौद्धिक संपदा की रक्षा, ब्रांड पहचान बढ़ाने, या प्रस्तुतियों के अनधिकृत उपयोग को रोकने में मदद करता है।

**क्या मैं प्रस्तुति की सभी स्लाइडों में वॉटरमार्क जोड़ सकता हूँ?**

हाँ, Aspose.Slides आपको प्रोग्रामmatically हर स्लाइड में वॉटरमार्क जोड़ने की अनुमति देता है। आप सभी स्लाइडों पर इटरेट करके वॉटरमार्क सेटिंग्स व्यक्तिगत रूप से लागू कर सकते हैं।

**मैं वॉटरमार्क की पारदर्शिता कैसे समायोजित कर सकता हूँ?**

आप आकार की fill सेटिंग्स ([FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/fillformat/)) को संशोधित करके वॉटरमार्क की पारदर्शिता को समायोजित कर सकते हैं। इससे वॉटरमार्क सूक्ष्म रहता है और स्लाइड सामग्री से ध्यान नहीं हटाता।

**वॉटरमार्क के लिए कौनसे इमेज फ़ॉर्मेट सपोर्टेड हैं?**

Aspose.Slides PNG, JPEG, GIF, BMP, SVG और अन्य विभिन्न इमेज फ़ॉर्मेट को सपोर्ट करता है।

**क्या मैं पाठ वॉटरमार्क के फ़ॉन्ट और शैली को कस्टमाइज़ कर सकता हूँ?**

हाँ, आप किसी भी फ़ॉन्ट, आकार और शैली का चयन कर सकते हैं जो आपकी प्रस्तुति के डिज़ाइन और ब्रांड स्थिरता से मेल खाता हो।

**वॉटरमार्क की स्थिति या अभिविन्यास कैसे बदलूँ?**

आप प्रोग्रामmatically आकार के निर्देशांक, आकार और घूर्णन प्रॉपर्टी को बदलकर वॉटरमार्क की स्थिति और अभिविन्यास समायोजित कर सकते हैं।