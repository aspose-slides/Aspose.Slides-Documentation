---
title: C++ में एक प्रेज़ेंटेशन व्यूअर बनाएं
linktitle: प्रेज़ेंटेशन व्यूअर
type: docs
weight: 50
url: /hi/cpp/presentation-viewer/
keywords:
- प्रेज़ेंटेशन देखें
- प्रेज़ेंटेशन व्यूअर
- प्रेज़ेंटेशन व्यूअर बनाएं
- PPT देखें
- PPTX देखें
- ODP देखें
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C++ में एक कस्टम प्रेज़ेंटेशन व्यूअर बनाएं। Microsoft PowerPoint के बिना आसानी से PowerPoint और OpenDocument फ़ाइलों को प्रदर्शित करें।"
---
## **परिचय**

Aspose.Slides for C++ का उपयोग स्लाइड वाले प्रेज़ेंटेशन फ़ाइलें बनाने के लिए किया जाता है। इन स्लाइडों को Microsoft PowerPoint जैसे प्रेज़ेंटेशन खोलकर देखा जा सकता है। हालांकि, कभी‑कभी डेवलपर्स को स्लाइडों को अपनी पसंदीदा इमेज व्यूअर में इमेज के रूप में देखना पड़ता है या अपना स्वयं का प्रेज़ेंटेशन व्यूअर बनाना होता है। ऐसे मामलों में, Aspose.Slides आपको किसी एकल स्लाइड को इमेज के रूप में निर्यात करने की सुविधा देता है। इस लेख में बताया गया है कि यह कैसे किया जाता है।

## **स्लाइड से SVG इमेज बनाना**

Aspose.Slides के साथ प्रेज़ेंटेशन स्लाइड से SVG इमेज बनाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक instance बनाएँ।
2. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।
3. एक फ़ाइल स्ट्रीम खोलें।
4. स्लाइड को SVG इमेज के रूप में फ़ाइल स्ट्रीम में सहेजें।

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```

## **कस्टम शेप ID के साथ SVG बनाना**

Aspose.Slides का उपयोग कस्टम शेप ID वाले स्लाइड से एक [SVG](https://docs.fileformat.com/page-description-language/svg/) बनाने के लिए किया जा सकता है। ऐसा करने के लिए, `set_Id` मेथड को [ISvgShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/isvgshape/) से उपयोग करें। `CustomSvgShapeFormattingController` का उपयोग करके शेप ID सेट की जा सकती है।

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```
```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```

## **स्लाइड थंबनेल इमेज बनाएं**

Aspose.Slides आपको स्लाइडों के थंबनेल इमेज बनाने में मदद करता है। Aspose.Slides का उपयोग करके स्लाइड का थंबनेल बनाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक instance बनाएँ।
2. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।
3. परिभाषित स्केल पर संदर्भित स्लाइड की थंबनेल इमेज प्राप्त करें।
4. थंबनेल इमेज को मनचाहे इमेज फ़ॉर्मेट में सहेजें।

```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **उपयोगकर्ता‑परिभाषित आयामों के साथ स्लाइड थंबनेल बनाएं**

उपयोगकर्ता द्वारा परिभाषित आयामों के साथ स्लाइड थंबनेल इमेज बनाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक instance बनाएँ।
2. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।
3. परिभाषित आयामों के साथ संदर्भित स्लाइड की थंबनेल इमेज प्राप्त करें।
4. थंबनेल इमेज को मनचाहे इमेज फ़ॉर्मेट में सहेजें।

```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **स्पीकर नोट्स के साथ स्लाइड थंबनेल बनाएं**

Aspose.Slides का उपयोग करके स्पीकर नोट्स के साथ स्लाइड का थंबनेल बनाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [RenderingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/renderingoptions/) क्लास का एक instance बनाएँ।
2. स्पीकर नोट्स की स्थिति सेट करने के लिए `RenderingOptions.set_SlidesLayoutOptions` मेथड का उपयोग करें।
3. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक instance बनाएँ।
4. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।
5. रेंडरिंग विकल्पों के साथ संदर्भित स्लाइड की थंबनेल इमेज प्राप्त करें।
6. थंबनेल इमेज को मनचाहे इमेज फ़ॉर्मेट में सहेजें।

```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **लाइव उदाहरण**

आप Aspose.Slides API के साथ आप क्या लागू कर सकते हैं, देखने के लिए मुफ्त ऐप [**Aspose.Slides Viewer**](https://products.aspose.app/slides/hi/viewer/) आज़मा सकते हैं:

![ऑनलाइन PowerPoint व्यूअर](online-PowerPoint-viewer.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं वेब एप्लिकेशन में प्रेज़ेंटेशन व्यूअर एम्बेड कर सकता हूँ?**

हां। आप सर्वर साइड पर Aspose.Slides का उपयोग करके स्लाइडों को इमेज या HTML के रूप में रेंडर कर सकते हैं और उन्हें ब्राउज़र में प्रदर्शित कर सकते हैं। नेविगेशन और जूम सुविधाओं को जावास्क्रिप्ट के साथ लागू किया जा सकता है ताकि इंटरैक्टिव अनुभव मिल सके।

**कस्टम व्यूअर के अंदर स्लाइड्स को प्रदर्शित करने का सबसे अच्छा तरीका क्या है?**

सिफारिश किया गया तरीका यह है कि प्रत्येक स्लाइड को इमेज (जैसे PNG या SVG) के रूप में रेंडर किया जाए या Aspose.Slides का उपयोग करके HTML में परिवर्तित किया जाए, फिर आउटपुट को डेस्कटॉप के लिए पिक्चर बॉक्स या वेब के लिए HTML कंटेनर में प्रदर्शित किया जाए।

**मैं कई स्लाइडों वाले बड़े प्रेज़ेंटेशन को कैसे संभालूं?**

बड़े प्रेज़ेंटेशन के लिए, स्लाइडों का लेज़ी‑लोडिंग या ऑन‑डिमांड रेंडरिंग करने पर विचार करें। इसका मतलब है कि जब उपयोगकर्ता उस स्लाइड पर जाता है तभी उसकी सामग्री जेनरेट की जाए, जिससे मेमोरी और लोड समय कम हो जाता है।