---
title: एंड्रॉइड पर प्रस्तुति व्यूअर बनाएं
linktitle: प्रस्तुति व्यूअर
type: docs
weight: 50
url: /hi/androidjava/presentation-viewer/
keywords:
- प्रस्तुति देखें
- प्रस्तुति व्यूअर
- प्रस्तुति व्यूअर बनाएं
- PPT देखें
- PPTX देखें
- ODP देखें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "एंड्रॉइड के लिए Aspose.Slides का उपयोग करके जावा में एक कस्टम प्रस्तुति व्यूअर बनाएँ। माइक्रोसॉफ्ट PowerPoint के बिना आसानी से PowerPoint और OpenDocument फ़ाइलें प्रदर्शित करें।"
---
## **परिचय**

Aspose.Slides for Android via Java का उपयोग स्लाइड वाले प्रस्तुति फ़ाइलें बनाने के लिए किया जाता है। इन स्लाइडों को Microsoft PowerPoint आदि में प्रस्तुति खोलकर देखा जा सकता है। हालांकि, कभी‑कभी डेवलपर को अपनी पसंद के इमेज व्यूअर में स्लाइड को छवि के रूप में देखना पड़ सकता है या अपना स्वयं का प्रस्तुति व्यूअर बनाना पड़ सकता है। ऐसे मामलों में, Aspose.Slides आपको एकल स्लाइड को छवि के रूप में निर्यात करने की सुविधा देता है। यह लेख दर्शाता है कि यह कैसे किया जाए।

## **एक स्लाइड से SVG छवि उत्पन्न करें**

Aspose.Slides के साथ प्रस्तुति स्लाइड से SVG छवि उत्पन्न करने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।
1. फ़ाइल स्ट्रीम खोलें।
1. स्लाइड को SVG छवि के रूप में फ़ाइल स्ट्रीम में सहेजें।

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **कस्टम शेप ID के साथ SVG उत्पन्न करें**

Aspose.Slides का उपयोग कस्टम शेप ID वाले स्लाइड से एक [SVG](https://docs.fileformat.com/page-description-language/svg/) उत्पन्न करने के लिए किया जा सकता है। इसके लिए, [ISvgShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgshape/) से `setId` मेथड का उपयोग करें। `CustomSvgShapeFormattingController` का उपयोग करके शेप ID सेट की जा सकती है।

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **स्लाइड थंबनेल छवि बनाएं**

Aspose.Slides आपको स्लाइड की थंबनेल छवियां बनाने में मदद करता है। Aspose.Slides का उपयोग करके स्लाइड का थंबनेल उत्पन्न करने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।
1. परिभाषित स्केल पर संदर्भित स्लाइड की थंबनेल छवि प्राप्त करें।
1. थंबनेल छवि को इच्छित किसी भी इमेज फ़ॉर्मेट में सहेजें।

```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **उपयोगकर्ता द्वारा निर्धारित आयामों के साथ स्लाइड थंबनेल बनाएं**

उपयोगकर्ता द्वारा निर्धारित आयामों के साथ स्लाइड थंबनेल छवि बनाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।
1. परिभाषित आयामों के साथ संदर्भित स्लाइड की थंबनेल छवि प्राप्त करें।
1. थंबनेल छवि को इच्छित किसी भी इमेज फ़ॉर्मेट में सहेजें।

```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **स्पीकर नोट्स के साथ स्लाइड थंबनेल बनाएं**

Aspose.Slides का उपयोग करके स्पीकर नोट्स के साथ स्लाइड का थंबनेल उत्पन्न करने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [RenderingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/renderingoptions/) क्लास का एक इंस्टेंस बनाएं।
1. `RenderingOptions.setSlidesLayoutOptions` मेथड का उपयोग करके स्पीकर नोट्स की स्थिति सेट करें।
1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।
1. रेंडरिंग विकल्पों के साथ संदर्भित स्लाइड की थंबनेल छवि प्राप्त करें।
1. थंबनेल छवि को इच्छित किसी भी इमेज फ़ॉर्मेट में सहेजें।

```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **लाइव उदाहरण**

आप Aspose.Slides API के साथ क्या लागू कर सकते हैं, यह देखने के लिए मुफ्त ऐप [**Aspose.Slides Viewer**](https://products.aspose.app/slides/hi/viewer/) आज़मा सकते हैं:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं वेब एप्लिकेशन में प्रस्तुति व्यूअर एंबेड कर सकता हूँ?**

हाँ। आप सर्वर साइड पर Aspose.Slides का उपयोग करके स्लाइड को छवि या HTML के रूप में रेंडर कर सकते हैं और ब्राउज़र में प्रदर्शित कर सकते हैं। नेविगेशन और ज़ूम सुविधाओं को जावास्क्रिप्ट के माध्यम से इंटरैक्टिव अनुभव के लिए लागू किया जा सकता है।

**कस्टम व्यूअर में स्लाइड दिखाने का सबसे अच्छा तरीका क्या है?**

सुझाए गए तरीके में प्रत्येक स्लाइड को छवि (जैसे PNG या SVG) के रूप में रेंडर करना या Aspose.Slides का उपयोग करके इसे HTML में परिवर्तित करना शामिल है, फिर आउटपुट को डेस्कटॉप के लिए पिक्चर बॉक्स या वेब के लिए HTML कंटेनर में प्रदर्शित किया जाता है।

**बहुत सारी स्लाइड वाली बड़ी प्रस्तुतियों को मैं कैसे संभालूँ?**

बड़ी प्रस्तुतियों के लिए, स्लाइडों को लेज़ी-लोडिंग या ऑन-डिमांड रेंडरिंग पर विचार करें। इसका मतलब है कि उपयोगकर्ता जब स्लाइड पर नेविगेट करे तब ही उसकी सामग्री उत्पन्न की जाए, जिससे मेमोरी और लोड समय कम होता है।