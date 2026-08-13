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
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में .NET का उपयोग करके टेक्स्ट और इमेज वॉटरमार्क प्रबंधित करें, ताकि ड्राफ्ट, गोपनीय जानकारी, कॉपीराइट आदि दर्शाया जा सके।"
---
## **परिचय**

**एक वॉटरमार्क** प्रस्तुति में वह पाठ या छवि मोहर है जो स्लाइड पर या सभी प्रस्तुति स्लाइडों में उपयोग की जाती है। आमतौर पर वॉटरमार्क यह संकेत देने के लिए प्रयोग किया जाता है कि प्रस्तुति ड्राफ्ट है (जैसे, “Draft” वॉटरमार्क), इसमें गोपनीय जानकारी है (जैसे, “Confidential” वॉटरमार्क), यह किस कंपनी से संबंधित है (जैसे, “Company Name” वॉटरमार्क), प्रस्तुति लेखक को पहचाने आदि। वॉटरमार्क कॉपीराइट उल्लंघन को रोकने में मदद करता है यह संकेत देकर कि प्रस्तुति की प्रतिलिपि नहीं बनानी चाहिए। वॉटरमार्क PowerPoint और OpenDocument दोनों फ़ॉर्मेट में उपयोग होते हैं। Aspose.Slides में आप PowerPoint PPT, PPTX और OpenDocument ODP फ़ाइल फ़ॉर्मेट में वॉटरमार्क जोड़ सकते हैं।

[**Aspose.Slides**](https://products.aspose.com/slides/hi/net/) में आप PowerPoint या OpenDocument दस्तावेज़ों में वॉटरमार्क बनाने और उनके डिज़ाइन व व्यवहार को बदलने के कई तरीके पा सकते हैं। सामान्य बात यह है कि पाठ वॉटरमार्क जोड़ने के लिए आपको [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) इंटरफ़ेस उपयोग करना चाहिए, और छवि वॉटरमार्क जोड़ने के लिए [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/) क्लास या वॉटरमार्क आकार को छवि से भरना चाहिए। `PictureFrame` [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape) इंटरफ़ेस को लागू करता है, जिससे आप आकार ऑब्जेक्ट की सभी लचीली सेटिंग्स उपयोग कर सकते हैं। चूँकि `ITextFrame` आकार नहीं है और इसकी सेटिंग्स सीमित हैं, इसलिए इसे एक [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape) ऑब्जेक्ट में लपेटा जाता है।

वॉटरमार्क दो तरीकों से लागू किया जा सकता है: एकल स्लाइड पर या सभी प्रस्तुति स्लाइडों पर। सभी स्लाइडों पर वॉटरमार्क लागू करने के लिए स्लाइड मास्टर का उपयोग किया जाता है — वॉटरमार्क स्लाइड मास्टर में जोड़ा जाता है, वहाँ पूरी तरह डिज़ाइन किया जाता है और सभी स्लाइडों पर लागू हो जाता है, जिससे व्यक्तिगत स्लाइडों पर वॉटरमार्क को संशोधित करने की अनुमति नहीं प्रभावित होती।

वॉटरमार्क आम तौर पर अन्य उपयोगकर्ताओं द्वारा संपादन योग्य नहीं माना जाता। वॉटरमार्क (या उसके पैरेंट आकार) को संपादन से बचाने के लिए Aspose.Slides आकार लॉक करने की सुविधा प्रदान करता है। एक विशिष्ट आकार को सामान्य स्लाइड या स्लाइड मास्टर पर लॉक किया जा सकता है। जब वॉटरमार्क आकार स्लाइड मास्टर पर लॉक किया जाता है, तो यह सभी प्रस्तुति स्लाइडों पर लॉक हो जाता है।

आप वॉटरमार्क का नाम सेट कर सकते हैं ताकि भविष्य में उसे हटाने की जरूरत पड़े तो आप स्लाइड के आकारों में नाम से उसे खोज सकें।

आप वॉटरमार्क को किसी भी तरह डिज़ाइन कर सकते हैं; हालांकि, सामान्यतः वॉटरमार्क में केंद्र संरेखण, घुमाव, सामने की स्थिति आदि जैसी विशेषताएं होती हैं। हम नीचे के उदाहरणों में इनका उपयोग कैसे करें, इसे देखेंगे।

## **टेक्स्ट वॉटरमार्क**

### **स्लाइड में टेक्स्ट वॉटरमार्क जोड़ें**

PPT, PPTX या ODP में टेक्स्ट वॉटरमार्क जोड़ने के लिए आप पहले स्लाइड में एक आकार जोड़ सकते हैं, फिर उस आकार में एक टेक्स्ट फ़्रेम जोड़ सकते हैं। टेक्स्ट फ़्रेम [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe) इंटरफ़ेस द्वारा प्रतिनिधित्व किया जाता है। यह प्रकार [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) से विरासत में नहीं मिला है, जिसके पास आकार को लचीले तरीके से स्थित करने के विस्तृत गुण होते हैं। इसलिए, [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe) ऑब्जेक्ट को एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) ऑब्जेक्ट में लपेटा जाता है। आकार में वॉटरमार्क पाठ जोड़ने के लिए, नीचे दिखाए अनुसार [AddTextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/methods/addtextframe) मेथड का उपयोग करें।

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// स्लाइड में वॉटरमार्क जोड़ें।
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="और देखें" %}} 
- [How to Use the TextFrame Class?](/slides/hi/net/text-formatting/)
{{% /alert %}}

### **प्रस्तुति में टेक्स्ट वॉटरमार्क जोड़ें**

यदि आप पूरी प्रस्तुति (अर्थात सभी स्लाइडों) में टेक्स्ट वॉटरमार्क जोड़ना चाहते हैं, तो इसे [MasterSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/masterslide/) में जोड़ें। बाकी लॉजिक वही है जैसा कि एकल स्लाइड में वॉटरमार्क जोड़ते समय किया जाता है — एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) ऑब्जेक्ट बनाएं और फिर [AddTextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/methods/addtextframe) मेथड से वॉटरमार्क जोड़ें।

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// मास्टर स्लाइड में वॉटरमार्क जोड़ें।
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="और देखें" %}} 
- [How to Use the Slide Master?](/slides/hi/net/slide-master/)
{{% /alert %}}

### **वॉटरमार्क आकार की पारदर्शिता सेट करें**

डिफ़ॉल्ट रूप से, आयताकार आकार को भरने और रेखा रंग से सजाया जाता है। इसका मतलब है कि वॉटरमार्क जोड़ने पर यह ठोस पृष्ठभूमि या बॉर्डर के साथ दिखाई दे सकता है, जो स्लाइड की सामग्री से ध्यान भटका सकता है। वॉटरमार्क को सूक्ष्म रखने और प्रस्तुति के दृश्य डिज़ाइन में बाधा न डालने के लिए आप आकार को पूरी तरह पारदर्शी बना सकते हैं।

निम्न लाइनें कोड भरने और बॉर्डर रंग दोनों को हटाकर आकार को पारदर्शी बनाती हैं:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **टेक्स्ट वॉटरमार्क का फ़ॉन्ट सेट करें**

स्लाइड पर टेक्स्ट वॉटरमार्क लागू करने से पहले, इसका स्वरूप ऐसा बनाना महत्वपूर्ण है जो समग्र डिज़ाइन के साथ सामंजस्य रखे। आप फ़ॉन्ट प्रकार और आकार बदल सकते हैं ताकि वॉटरमार्क पठनीय और सौंदर्यपूर्ण दोनों हो। फ़ॉन्ट को कस्टमाइज़ करने से ब्रांड पहचान को मजबूत करने या प्रस्तुति शैली से मेल खाने में मदद मिलती है।

नीचे दिया गया कोड स्निपेट विशेष लैटिन फ़ॉन्ट चुनकर और उचित फ़ॉन्ट हाइट सेट करके वॉटरमार्क के फ़ॉन्ट सेटिंग्स को समायोजित करता है:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **वॉटरमार्क टेक्स्ट का रंग सेट करें**

वॉटरमार्क लागू करने से पहले यह सुनिश्चित करना आवश्यक है कि टेक्स्ट रंग ठीक से सेट हो, ताकि वह स्लाइड सामग्री के साथ सामंजस्य रखे और अत्यधिक न हो। रंग की पारदर्शिता (अल्फा) के साथ लाल, हरा और नीला घटक समायोजित करने से आप एक सूक्ष्म, अर्ध-पारदर्शी वॉटरमार्क बना सकते हैं जो दिखता है लेकिन बाधा नहीं बनता। यह तरीका मुख्य प्रस्तुति पर ध्यान बनाए रखता है जबकि आपके कंटेंट की सुरक्षा करता है।

वॉटरमार्क टेक्स्ट का रंग सेट करने के लिए नीचे दिया गया कोड उपयोग करें:

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **टेक्स्ट वॉटरमार्क को केंद्रित करें**

टेक्स्ट वॉटरमार्क को सही तरीके से केंद्रित करने से आपकी प्रस्तुति की कुल सौंदर्य में बड़ा सुधार होता है, क्योंकि वॉटरमार्क स्लाइड आयामों की परवाह किए बिना सममित रूप से स्थित रहता है। यह आपका स्लाइड पेशेवर बनाता है और मुख्य सामग्री में बाधा नहीं डालता।

नीचे दिया गया कोड स्निपेट स्लाइड के केंद्र स्थान की गणना करता है और उसी अनुसार टेक्स्ट वॉटरमार्क रखता है:

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

नीचे की छवि अंतिम परिणाम दर्शाती है।

![The text watermark](text_watermark.png)

## **इमेज वॉटरमार्क**

### **प्रस्तुति में इमेज वॉटरमार्क जोड़ें**

कई मामलों में इमेज वॉटरमार्क एक विशिष्ट ब्रांडिंग तत्व या टेक्स्ट वॉटरमार्क का अधिक दृश्यात्मक विकल्प प्रदान कर सकता है। वॉटरमार्क जोड़ने से पहले सुनिश्चित करें कि छवि फ़ाइल उपलब्ध है (जैसे, पारदर्शिता के लिए PNG)। निम्न उदाहरण दर्शाता है कि फ़ाइल सिस्टम से छवि लोड करके, उसे प्रस्तुति में जोड़ें और फिर आकार की फ़िल प्रॉपर्टी का उपयोग करके वॉटरमार्क के रूप में लागू करें।

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **वॉटरमार्क को संपादन से लॉक करें**

यदि वॉटरमार्क को संपादित होने से रोकना आवश्यक है, तो आकार पर [IAutoShape.ShapeLock](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/properties/shapelock) प्रॉपर्टी का उपयोग करें। इस प्रॉपर्टी से आप आकार को चयन, आकार बदलने, पुनःस्थापित करने, अन्य तत्वों के साथ समूह बनाने, टेक्स्ट को संपादन से लॉक करने आदि से बचा सकते हैं:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// वॉटरमार्क आकार को संशोधन से लॉक करें।
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **वॉटरमार्क को सामने लाएँ**

Aspose.Slides में, आकारों की Z‑order को [IShapeCollection.Reorder](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/reorder/#reorder) मेथड से सेट किया जा सकता है। इसे करने के लिए आप प्रस्तुति स्लाइड सूची से इस मेथड को कॉल करते हैं और आकार संदर्भ तथा उसका क्रमांक पास करते हैं। इस प्रकार आप आकार को सामने ला सकते हैं या स्लाइड के पीछे भेज सकते हैं। यह सुविधा विशेष रूप से तब उपयोगी होती है जब आपको वॉटरमार्क को प्रस्तुति के सामने रखना हो:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **वॉटरमार्क का घुमाव सेट करें**

वॉटरमार्क का घुमाव समायोजित करने से आपकी प्रस्तुति का दृश्य प्रभाव और सूक्ष्मता काफी बढ़ सकती है। उदाहरण के लिए, तिरछा वॉटरमार्क कम बाधा उत्पन्न करता है फिर भी अनधिकृत उपयोग के विरुद्ध मजबूत सुरक्षा प्रदान करता है। नीचे दिया गया उदाहरण स्लाइड आयामों के आधार पर उपयुक्त कोण की गणना करता है, जिससे वॉटरमार्क स्लाइड के अंतराल पर तिरछा स्थित हो जाता है। यह गतिशील गणना सुनिश्चित करती है कि विभिन्न स्लाइड आकारों पर वॉटरमार्क प्रभावी रहे।

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **वॉटरमार्क का नाम सेट करें**

Aspose.Slides आपको आकार का नाम सेट करने की अनुमति देता है। आकार नाम का उपयोग करके आप भविष्य में उसे संशोधित या हटाने के लिए खोज सकते हैं। वॉटरमार्क आकार का नाम सेट करने के लिए इसे [IAutoShape.Name](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/properties/name) प्रॉपर्टी में असाइन करें:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **वॉटरमार्क हटाएँ**

वॉटरमार्क आकार को हटाने के लिए, स्लाइड के आकारों में [IAutoShape.Name](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/properties/name) प्रॉपर्टी से उसे खोजें। फिर उस वॉटरमार्क आकार को [IShapeCollection.Remove](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/remove/) मेथड में पास करें:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **लाइव उदाहरण**

आप **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/hi/watermark) और [Remove Watermark](https://products.aspose.app/slides/hi/watermark/remove-watermark) ऑनलाइन टूल्स को देख सकते हैं।

![Online tools to add and remove watermarks](online_tools.png)

## **अक्सर पूछे जाने वाले प्रश्न**

### वॉटरमार्क क्या है और मुझे इसे क्यों उपयोग करना चाहिए?

वॉटरमार्क वह टेक्स्ट या छवि ओवरले है जो स्लाइडों पर लागू किया जाता है और बौद्धिक संपदा की रक्षा, ब्रांड पहचान बढ़ाने, या अनधिकृत उपयोग को रोकने में मदद करता है।

### क्या मैं पूरे प्रस्तुति की सभी स्लाइडों में वॉटरमार्क जोड़ सकता हूँ?

हाँ, Aspose.Slides आपको प्रोग्रामmatically प्रत्येक स्लाइड में वॉटरमार्क जोड़ने की अनुमति देता है। आप सभी स्लाइडों को लूप करके वॉटरमार्क सेटिंग्स व्यक्तिगत रूप से लागू कर सकते हैं।

### मैं वॉटरमार्क की पारदर्शिता कैसे समायोजित करूँ?

आप आकार की फ़िल सेटिंग्स ([FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/fillformat/)) को बदलकर वॉटरमार्क की पारदर्शिता समायोजित कर सकते हैं। इससे वॉटरमार्क सूक्ष्म रहता है और स्लाइड सामग्री से ध्यान नहीं हटाता।

### वॉटरमार्क के लिए कौन‑से छवि फ़ॉर्मेट समर्थित हैं?

Aspose.Slides PNG, JPEG, GIF, BMP, SVG आदि विभिन्न छवि फ़ॉर्मेट का समर्थन करता है।

### क्या मैं टेक्स्ट वॉटरमार्क के फ़ॉन्ट और शैली को कस्टमाइज़ कर सकता हूँ?

हाँ, आप कोई भी फ़ॉन्ट, आकार और शैली चुन सकते हैं जो आपकी प्रस्तुति के डिज़ाइन और ब्रांड लगातारिता के साथ मेल खाती हो।

### मैं वॉटरमार्क की स्थिति या अभिविन्यास कैसे बदलूँ?

आप आकार के निर्देशांक, आकार और घुमाव प्रॉपर्टी को प्रोग्रामmatically बदलकर वॉटरमार्क की स्थिति और अभिविन्यास समायोजित कर सकते हैं।