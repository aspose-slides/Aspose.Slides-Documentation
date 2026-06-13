---
title: Java में प्रेजेंटेशन व्यूअर बनाएं
linktitle: प्रेजेंटेशन व्यूअर
type: docs
weight: 50
url: /hi/java/presentation-viewer/
keywords:
- प्रेजेंटेशन देखें
- प्रेजेंटेशन व्यूअर
- प्रेजेंटेशन व्यूअर बनाएं
- PPT देखें
- PPTX देखें
- ODP देखें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Java में एक कस्टम प्रेजेंटेशन व्यूअर बनाएं। Microsoft PowerPoint के बिना आसानी से PowerPoint और OpenDocument फ़ाइलें प्रदर्शित करें।"
---
## **परिचय**

Aspose.Slides for Java का उपयोग स्लाइड्स वाले प्रेजेंटेशन फ़ाइलें बनाने के लिए किया जाता है। इन स्लाइड्स को Microsoft PowerPoint जैसे प्रोग्राम में प्रेजेंटेशन खोलकर देखा जा सकता है। हालांकि, कभी‑कभी डेवलपर्स को स्लाइड्स को अपनी पसंद के इमेज व्यूअर में इमेज के रूप में देखना या अपना स्वयं का प्रेजेंटेशन व्यूअर बनाना पड़ सकता है। ऐसे मामलों में, Aspose.Slides आपको एकल स्लाइड को इमेज के रूप में निर्यात करने की सुविधा देता है। यह लेख बताता है कि यह कैसे किया जाए।

## **स्लाइड से SVG इमेज उत्पन्न करना**

Aspose.Slides के साथ प्रेजेंटेशन स्लाइड से SVG इमेज उत्पन्न करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।
3. फ़ाइल स्ट्रीम खोलें।
4. स्लाइड को SVG इमेज के रूप में फ़ाइल स्ट्रीम में सहेजें।

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **कस्टम शैप ID के साथ SVG उत्पन्न करना**

Aspose.Slides का उपयोग कस्टम शैप ID वाले स्लाइड से [SVG](https://docs.fileformat.com/page-description-language/svg/) जनरेट करने के लिए किया जा सकता है। इसके लिए, [ISvgShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgshape/) से `setId` मेथड का उपयोग करें। `CustomSvgShapeFormattingController` का उपयोग करके शैप ID सेट की जा सकती है।

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
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **स्लाइड थंबनेल इमेज बनाना**

Aspose.Slides आपको स्लाइडों की थंबनेल इमेज बनाने में मदद करता है। Aspose.Slides का उपयोग कर स्लाइड की थंबनेल बनाना है तो, कृपया नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।
3. परिभाषित स्केल पर संदर्भित स्लाइड की थंबनेल इमेज प्राप्त करें।
4. थंबनेल इमेज को मनचाहे इमेज फ़ॉर्मेट में सहेजें।

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

## **उपयोगकर्ता परिभाषित आयामों के साथ स्लाइड थंबनेल बनाएं**

Aspose.Slides आपको स्लाइडों की थंबनेल इमेज बनाने में मदद करता है। उपयोगकर्ता परिभाषित आयामों के साथ स्लाइड थंबनेल बनाना है तो, कृपया नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।
3. परिभाषित आयामों के साथ संदर्भित स्लाइड की थंबनेल इमेज प्राप्त करें।
4. थंबनेल इमेज को मनचाहे इमेज फ़ॉर्मेट में सहेजें।

```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **स्पीकर नोट्स के साथ स्लाइड थंबनेल बनाएं**

Aspose.Slides का उपयोग कर स्पीकर नोट्स सहित स्लाइड की थंबनेल बनाने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. [RenderingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/renderingoptions/) क्लास का एक इंस्टेंस बनाएं।
2. `RenderingOptions.setSlidesLayoutOptions` मेथड का उपयोग करके स्पीकर नोट्स की स्थिति सेट करें।
3. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
4. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।
5. रेंडरिंग विकल्पों के साथ संदर्भित स्लाइड की थंबनेल इमेज प्राप्त करें।
6. थंबनेल इमेज को मनचाहे इमेज फ़ॉर्मेट में सहेजें।

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

आप मुफ्त ऐप [**Aspose.Slides Viewer**](https://products.aspose.app/slides/hi/viewer/) को आज़मा सकते हैं ताकि देख सकें कि Aspose.Slides API के साथ आप क्या बना सकते हैं:

![ऑनलाइन PowerPoint Viewer](online-PowerPoint-viewer.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं वेब एप्लीकेशन में प्रेजेंटेशन व्यूअर एम्बेड कर सकता हूँ?**

हाँ। आप सर्वर साइड पर Aspose.Slides का उपयोग करके स्लाइड्स को इमेज या HTML के रूप में रेंडर कर सकते हैं और उन्हें ब्राउज़र में प्रदर्शित कर सकते हैं। नेविगेशन और ज़ूम फीचर जावास्क्रिप्ट के माध्यम से लागू करके इंटरेक्टिव अनुभव दिया जा सकता है।

**कस्टम व्यूअर के भीतर स्लाइड्स को प्रदर्शित करने का सबसे अच्छा तरीका क्या है?**

सिफ़ारिश किया गया तरीका यह है कि प्रत्येक स्लाइड को इमेज (जैसे PNG या SVG) के रूप में रेंडर करें या Aspose.Slides का उपयोग करके इसे HTML में कन्वर्ट करें, फिर आउटपुट को डेस्कटॉप के लिए पिक्चर बॉक्स या वेब के लिए HTML कंटेनर में प्रदर्शित करें।

**बहुत सारी स्लाइड्स वाले बड़े प्रेजेंटेशन को कैसे संभालूँ?**

बड़े डेक्स के लिए, स्लाइड्स को लेज़ी-लोडिंग या ऑन-डिमांड रेंडरिंग पर विचार करें। इसका अर्थ है कि स्लाइड की सामग्री केवल तभी जनरेट करें जब उपयोगकर्ता उसके पास नेविगेट करे, जिससे मेमोरी और लोड टाइम कम हो जाता है।