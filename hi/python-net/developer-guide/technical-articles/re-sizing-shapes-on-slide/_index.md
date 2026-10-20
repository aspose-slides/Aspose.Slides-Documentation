---
title: प्रस्तुति स्लाइड्स पर पायथन में आकृतियों का आकार बदलें
type: docs
weight: 130
url: /hi/python-net/resizing-shapes-on-slide/
aliases:
  - /hi/python-net/re-sizing-shapes-on-slide/
keywords:
- आकार बदलें
- आकृति का आकार बदलें
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- पायथन
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument स्लाइड्स पर आकृतियों को आसानी से आकार बदलें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

जब आप प्रस्तुति की स्लाइड का आकार बदलते हैं, तो नई आयामों के अनुकूल बनाने के लिये आपको उसकी आकृतियों को पुनः आकार देना और पुनः स्थित करना भी आवश्यक हो सकता है। यह लेख दिखाता है कि आकृतियों को मैन्युअल रूप से कैसे स्केल किया जाए और स्लाइड, मास्टर और लेआउट में तालिकाओं को कैसे संभाला जाए।

## **आकार बदलना**

प्रत्येक आकृति की सापेक्ष स्थिति और आकार को बनाए रखने के लिये, उसकी क्षैतिज निर्देशांक और चौड़ाई को नई स्लाइड की चौड़ाई और मूल चौड़ाई के अनुपात से गुणा करें। समान ऊँचाई अनुपात को उसकी लंबवत निर्देशांक और ऊँचाई पर लागू करें।

पहला उदाहरण एक ऐसी प्रस्तुति को लोड करता है जिसकी स्लाइड में कोई तालिका नहीं है, स्लाइड आकार को A4 में बदलता है, और परिणाम को सहेजता है। यह बाद के लूप द्वारा स्केलिंग को नियंत्रित करने के लिये [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) को [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) के साथ उपयोग करता है। अनुपात बिना इकाई के होते हैं; आकृति की स्थितियों और आयामों को पॉइंट में मापा जाता है। विभिन्न चौड़ाई और ऊँचाई अनुपात से आकृतियों में विकृति आ सकती है, और आकृति के आयाम बदलने से उसके फ़ॉन्ट आकार नहीं बदलते।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # स्वतंत्र क्षैतिज और लंबवत स्केल कारकों की गणना करें।
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
तालिकाओं को अलग से संभालने की आवश्यकता होती है: उन्हें कुल तालिका की चौड़ाई और ऊँचाई निर्धारित करने के बजाय उनके कॉलम चौड़ाई और पंक्ति ऊँचाई को स्केल करना चाहिए। यदि सेल सामग्री को अधिक स्थान चाहिए तो पंक्ति ऊँचाई अनुरोधित से बड़ी रह सकती है।
{{% /alert %}}

दूसरा उदाहरण तालिकाओं को समर्थन देता है और आकारों को मास्टर और लेआउट पर तथा व्यक्तिगत स्लाइडों पर भी संसाधित करता है, फिर पुनः आकार वाली प्रस्तुति को सहेजता है। इसका हेल्पर प्रत्येक [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) को [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) तथा [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) को स्केल करके संभालता है। इसके बाद यह तालिका की स्थिति को स्केल करता है, बिना उसकी कुल आयामों को अलग से स्केल किए।

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # टेबल के आयाम कॉलम चौड़ाइयों और पंक्ति ऊँचाइयों द्वारा नियंत्रित होते हैं।
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
    # स्वतंत्र क्षैतिज और लंबवत स्केल कारकों की गणना करें।
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # मास्टर्स और लेआउट्स पर परिभाषित आकृतियों तथा व्यक्तिगत स्लाइड्स को पुनः आकार दें।
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड का आकार बदलने के बाद आकृतियों में विकृति या कटौती क्यों होती है?**

यदि आप स्लाइड आकार बदलते समय आकृतियों को स्केल नहीं करते हैं, तो वे अपनी मूल स्थितियों और आयामों को बनाए रखती हैं और स्लाइड के बाहर तक पहुँच सकती हैं। अलग-अलग अनुपात से चौड़ाई और ऊँचाई को स्केल करने से भी आकृतियों में विकृति आ सकती है।

**क्या दिया गया कोड सभी प्रकार की आकृतियों के लिये काम करता है?**

पहला उदाहरण आकृति की सीमा को सीधे बदलता है और यह उन स्लाइडों के लिये है जिनमें कोई तालिका नहीं है। दूसरा उदाहरण तालिकाओं को अलग से संभालता है। परिणामस्वरूप लेआउट, विशेष रूप से टेक्स्ट और तालिकाओं, की जाँच करें क्योंकि ये उदाहरण फ़ॉन्ट आकार को स्केल नहीं करते और तालिका की सामग्री पंक्ति ऊँचाइयों को सीमित कर सकती है।

**स्लाइड का आकार बदलते समय तालिकाओं को कैसे पुनः आकार दिया जाए?**

कॉलम चौड़ाई को चौड़ाई अनुपात से और न्यूनतम पंक्ति ऊँचाई को ऊँचाई अनुपात से स्केल करें, फिर तालिका की स्थिति को स्केल करें, जैसा कि दूसरे उदाहरण में दिखाया गया है।

**क्या यह पुनः आकार देना मास्टर स्लाइड और लेआउट स्लाइड पर भी काम करेगा?**

हां। दूसरा उदाहरण [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) और प्रत्येक मास्टर की [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) के माध्यम से इटरनेट करता है और उनके आकारों पर समान पुनः आकार तर्क लागू करता है।

**क्या मैं स्लाइड की अभिविन्यास (पोर्ट्रेट/लैंडस्केप) को पुनः आकार के साथ बदल सकता हूँ?**

हां। स्लाइड आकार बदलने और लक्ष्य आयाम पढ़ने से पहले [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) सेट करें, ताकि स्केल कारक अंतिम अभिविन्यास को दर्शाएँ।

**क्या स्लाइड आकार पर कोई सीमा है जिसे मैं सेट कर सकता हूँ?**

आप [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) के साथ कस्टम स्लाइड आयाम निर्दिष्ट कर सकते हैं। समर्थित आयाम प्रस्तुति फ़ॉर्मेट और फ़ाइल खोलने वाले एप्लिकेशन पर भी निर्भर करते हैं।

**मैं कैसे सुनिश्चित करूँ कि निश्चित अनुपात वाली आकृतियों में विकृति न हो?**

चौड़ाई और ऊँचाई के लिये एक ही स्केल कारक उपयोग करें। मूल लेआउट को नई स्लाइड आयामों में फिट करने के लिये दोनों ही आयामों और स्थितियों के लिये चौड़ाई और ऊँचाई अनुपात में से छोटा मान उपयोग करें। इससे अनुपात बना रहेगा, पर एक किनारे पर अप्रयुक्त स्थान बच सकता है।