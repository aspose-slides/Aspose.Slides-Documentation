---
title: Python में प्रस्तुति स्लाइड्स पर आकार बदलें
type: docs
weight: 130
url: /hi/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/re-sizing-shapes-on-slide/
  - /hi/python-net/re-sizing-shapes-on-slide/
keywords:
- आकार बदलें
- आकार का आकार बदलें
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "PowerPoint और OpenDocument स्लाइड्स पर Aspose.Slides for Python via .NET के साथ आसानी से आकार बदलें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

जब आप प्रस्तुति के स्लाइड आकार को बदलते हैं, तो आपको नई मापदंडों में फिट करने के लिए उसके आकार को पुनः आकार देना और उनकी स्थिति बदलना भी आवश्यक हो सकता है। यह लेख दिखाता है कि आकारों को मैन्युअल रूप से कैसे स्केल किया जाए और स्लाइड, मास्टर और लेआउट में तालिकाओं को कैसे संभाला जाए।

## **आकारों को पुनः आकार देना**

प्रत्येक आकार की सापेक्ष स्थिति और आकार को बनाए रखने के लिए, उसके क्षैतिज निर्देशांक और चौड़ाई को नई स्लाइड की चौड़ाई और मूल चौड़ाई के अनुपात से गुणा करें। समान अनुपात को ऊँचाई के लिए उसके ऊर्ध्वाधर निर्देशांक और ऊँचाई पर लागू करें।

पहला उदाहरण एक प्रस्तुति लोड करता है जिसकी स्लाइडों में कोई तालिका नहीं होती, स्लाइड आकार को A4 में बदलता है, और परिणाम सहेजता है। यह स्केलिंग को नियंत्रित करने के लिए बाद के लूप को सक्षम करने हेतु [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) को [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) के साथ उपयोग करता है। अनुपात बिना इकाई के होते हैं; आकार की स्थितियाँ और आयाम पॉइंट में मापे जाते हैं। अलग-अलग चौड़ाई और ऊँचाई अनुपात आकारों को विकृत कर सकते हैं, और आकार की आयाम बदलने से उसके फ़ॉन्ट आकार स्केल नहीं होते।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # स्वतंत्र क्षैतिज और ऊर्ध्वाधर स्केल कारकों की गणना करें।
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
तालिकाओं को अलग से संभालना आवश्यक है: तालिका की कुल चौड़ाई और ऊँचाई निर्धारित करने की बजाय उनके स्तंभ की चौड़ाइयों और पंक्तियों की ऊँचाइयों को स्केल करें। यदि सेल सामग्री को अधिक स्थान चाहिए तो पंक्ति की ऊँचाई अनुरोधित से बड़ी रह सकती है।
{{% /alert %}}

दूसरा उदाहरण तालिकाओं का समर्थन करता है और आकारों को मास्टर और लेआउट के साथ-साथ व्यक्तिगत स्लाइड्स पर भी संसाधित करता है, फिर पुनः आकारित प्रस्तुति को सहेजता है। उसका हेल्पर प्रत्येक [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) को [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) और [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) को स्केल करके संभालता है। फिर वह तालिका की स्थिति को स्केल करता है बिना उसके कुल आयामों को अलग से स्केल किए।

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # तालिका के आयाम कॉलम की चौड़ाइयों और पंक्ति ऊँचाइयों द्वारा नियंत्रित होते हैं।
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # स्वतंत्र क्षैतिज और ऊर्ध्वाधर स्केल कारकों की गणना करें।
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # मास्टर और लेआउट पर परिभाषित आकारों को, साथ ही व्यक्तिगत स्लाइडों को भी पुनः आकार दें।
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड का आकार बदलने के बाद आकार क्यों विकृत या कटे हुए दिखते हैं?**

यदि आप स्लाइड आकार बदलते हैं लेकिन आकारों को स्केल नहीं करते, तो वे अपनी मूल स्थितियों और आयामों को बनाए रखते हैं और स्लाइड से बाहर निकल सकते हैं। चौड़ाई और ऊँचाई को अलग-अलग अनुपात से स्केल करने से भी आकार विकृत हो सकते हैं।

**क्या प्रदान किया गया कोड सभी आकार प्रकारों के लिए काम करता है?**

पहला उदाहरण आकार की सीमाओं को सीधे बदलता है और वह तालिका रहित स्लाइड्स के लिए अभिप्रेत है। दूसरा उदाहरण तालिकाओं को अलग से संभालता है। परिणामी लेआउट, विशेषकर टेक्स्ट और तालिकाओं की जाँच करें, क्योंकि इन उदाहरणों में फ़ॉन्ट आकार स्केल नहीं किए जाते और तालिका की सामग्री पंक्ति की ऊँचाई को सीमित कर सकती है।

**स्लाइड का आकार बदलते समय तालिकाओं का आकार कैसे बदलें?**

चौड़ाई अनुपात से कॉलम की चौड़ाइयों को और ऊँचाई अनुपात से न्यूनतम पंक्ति ऊँचाइयों को स्केल करें, फिर तालिका की स्थिति को स्केल करें, जैसा कि दूसरे उदाहरण में दिखाया गया है।

**क्या यह पुनः आकार देना मास्टर स्लाइड्स और लेआउट स्लाइड्स पर काम करेगा?**

हां। दूसरा उदाहरण [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) और प्रत्येक मास्टर की [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) के माध्यम से इटरेट करता है और उनके आकारों पर समान पुनः आकार देने का तर्क लागू करता है।

**क्या मैं स्लाइड की अभिविन्यास (लंबवत/क्षैतिज) को पुनः आकार के साथ बदल सकता हूँ?**

हां। स्लाइड का आकार बदलने के बाद और लक्ष्य माप पढ़ने से पहले [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) सेट करें, ताकि स्केल कारक अंतिम अभिविन्यास को दर्शाएँ।

**क्या मैं जो स्लाइड आकार निर्धारित कर सकता हूँ, उसकी कोई सीमा है?**

आप [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) के साथ कस्टम स्लाइड आयाम निर्दिष्ट कर सकते हैं। समर्थित आयाम प्रस्तुति प्रारूप और फ़ाइल को खोलने वाले एप्लिकेशन पर भी निर्भर करते हैं।

**स्थिर अनुपात वाले आकारों को विकृत होने से कैसे रोकूँ?**

चौड़ाई और ऊँचाई के लिए समान स्केल फ़ैक्टर का उपयोग करें। मूल लेआउट को नई स्लाइड आयामों में फिट करने के लिए, दोनों आयामों और स्थितियों के लिये चौड़ाई और ऊँचाई में से छोटे अनुपात का प्रयोग करें। यह अनुपात को बनाए रखता है लेकिन एक किनारे पर अप्रयुक्त स्थान छोड़ सकता है।