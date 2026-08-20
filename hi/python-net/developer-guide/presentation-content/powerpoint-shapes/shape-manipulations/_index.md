---
title: Python में प्रस्तुति आकृतियों का प्रबंधन
linktitle: आकृति हेरफेर
type: docs
weight: 40
url: /hi/python-net/shape-manipulations/
keywords:
- PowerPoint आकृति
- प्रस्तुति आकृति
- स्लाइड पर आकृति
- आकृति खोजें
- आकृति क्लोन करें
- आकृति हटाएँ
- आकृति छुपाएँ
- आकृति क्रम बदलें
- इंटरऑप आकृति ID प्राप्त करें
- आकृति वैकल्पिक पाठ
- आकृति लेआउट प्रारूप
- आकृति SVG रूप में
- आकृति को SVG में
- आकृति संरेखित करें
- आकृति फ़्लिप करें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ प्रस्तुति आकृतियों की पहचान, क्लोन, हटाना, छुपाना, पुनः क्रम, निर्यात, संरेखण और फ़्लिप करने के तरीके सीखें।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET स्लाइड पर आकृतियों को क्रमबद्ध [ShapeCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/) के रूप में दर्शाता है। यह संग्रह वह जगह है जहाँ आप आकृतियों को खोजते और संशोधित करते हैं और उनका स्टैक क्रम निर्धारित करता है: सूचकांक `0` सबसे पीछे वाली आकृति है, जबकि अंतिम सूचकांक सबसे आगे वाली आकृति है।

यह लेख इस मॉडल का पालन करता है। यह पहले बताता है कि आकृति को विश्वसनीय तरीके से कैसे पहचानें, फिर क्लोन, हटाना, छुपाना और पुनर्गठित करना दिखाता है। अंतिम भागों में लेआउट‑स्तरीय स्वरूपण, SVG निर्यात, संरेखण और फ़्लिप सेटिंग्स शामिल हैं। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल उन ऑपरेशनों को उपयोग कर सकते हैं जो आपके वर्कफ़्लो के लिए आवश्यक हैं।

## **आकृतियों की पहचान और खोज**

संग्रह सूचकांक ज्ञात फ़ाइल को प्रोसेस करते समय सुविधाजनक होते हैं, लेकिन वे स्थिर पहचानकर्ता नहीं होते। किसी आकृति को जोड़ने, हटाने या पुनर्गठित करने से उसका सूचकांक बदल सकता है। प्रस्तुतीकरण के निर्माण और रखरखाव के तरीके के अनुसार एक पहचानकर्ता चुनें:

- [Shape.name](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/name/) उन टेम्पलेट्स के लिए उपयोगी है जो डेवलपर‑नियंत्रित होते हैं और PowerPoint की Selection Pane में आसानी से देखा जा सकता है। नामों को संपादित किया जा सकता है और वे अनिवार्य रूप से विशिष्ट नहीं होते, इसलिए यदि कोड उनपर निर्भर करता है तो नामकरण सम्मेलन स्थापित करें।
- [Shape.alternative_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/alternative_text/) उपयोगी है जब कोई पहुँच‑योग्यता विवरण या लेखक‑द्वारा दिया गया टैग पहले से ही आकृति की पहचान करता हो। यह उपयोगकर्ताओं को दिखता है, स्थानीयकृत या पहुँच‑योग्यता के लिए पुनर्लेखित किया जा सकता है, और यह भी अनिवार्य रूप से विशिष्ट नहीं होता। अर्थपूर्ण पहुँच‑योग्यता पाठ को चुपके से डेटाबेस कुंजी के रूप में पुनः उपयोग न करें।
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/office_interop_shape_id/) एक केवल‑पढ़ी जाने वाली पहचानकर्ता है जो स्लाइड के भीतर अद्वितीय होती है और PowerPoint इंटरऑप द्वारा उपयोग किए जाने वाले Shape ID के अनुरूप है। PowerPoint के साथ एकीकरण या किसी आकृति के जीवन‑काल के दौरान स्पष्ट संदर्भ की आवश्यकता होने पर इसका उपयोग करें। क्लोन या पुनः निर्मित आकृति एक अलग आकृति होती है और उसका अपना ID मिलता है।

संबंधित [Shape.unique_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/unique_id/) प्रॉपर्टी का प्रस्तुति‑व्यापी दायरा है, लेकिन यह ऐड‑इन के लिए अभिप्रेत है और पुनः‑सौंपा जा सकता है। इसे स्थायी बाहरी कुंजी नहीं माना जाना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है, तो इसे एप्लिकेशन डेटा में मैप रखें और सत्यापित करें कि अपेक्षित आकृति अभी भी मौजूद है।

निम्न उदाहरण `name` के साथ निश्चित तुलना करके खोज करता है और स्लाइड‑स्कोप्ड इंटरऑप ID को रिपोर्ट करता है। जब टेम्पलेट में अपेक्षित आकृति नहीं होती, तो कोड गलत ऑब्जेक्ट के साथ आगे बढ़ने के बजाय वह परिणाम रिपोर्ट करता है।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

जब कोई ऑपरेशन विशिष्ट आकृति प्रकार के लिए हो, तो प्रकार‑विशिष्ट सदस्यों का उपयोग करने से पहले प्रकार की जाँच करें। यह उदाहरण केवल तब टेक्स्ट और alternative text को अपडेट करता है जब नामित ऑब्जेक्ट एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) हो।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **आकृति संग्रह को संशोधित करें**

जोड़ने, क्लोन करने, हटाने और पुनर्गठित करने वाले मेथड तुरंत संग्रह पर काम करते हैं। यदि कोई ऑपरेशन आकृतियों की संख्या या क्रम बदलता है, तो उस ऑपरेशन से पहले प्राप्त सूचकांकों पर निर्भरता जारी न रखें।

### **आकृति को क्लोन करें**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_clone/) एक स्वतंत्र कॉपी बनाता है और उसे लक्ष्य संग्रह में जोड़ता है। [ShapeCollection.insert_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/insert_clone/) भी एक कॉपी बनाता है, लेकिन उसे निर्दिष्ट z‑order सूचकांक पर रखता है। जो ओवरलोड निर्देशांक स्वीकार करते हैं, वे आकार बदले बिना क्लोन को स्थानांतरित करते हैं; चौड़ाई और ऊँचाई वाले ओवरलोड इसे रिसाइज़ भी कर सकते हैं।

उदाहरण एक गंतव्य स्लाइड बनाता है, लेबल वाले आयत को सामने क्लोन करता है, और दूसरे क्लोन को पीछे सम्मिलित करता है। दोनों क्लोन में किए गए परिवर्तन मूल आकृति को नहीं बदलते।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

क्लोनिंग आकृति की सामग्री और स्वरूपण को कॉपी करती है, जिसमें उसका name और alternative text शामिल है। जब इन मानों को विशिष्ट होना आवश्यक हो तो क्लोन को नए तार्किक पहचानकर्ता सौंपें। जटिल आकृतियों द्वारा उपयोग किए जाने वाले संसाधनों को प्रस्तुति संभालती है, लेकिन क्लोन एक नई संग्रह आइटम के रूप में नई आकृति पहचान के साथ बना रहता है।

### **आकृतियों को हटाएँ**

[ShapeCollection.remove](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/remove/) किसी विशिष्ट आकृति ऑब्जेक्ट को उसके संग्रह से हटा देता है। जब आप सूचकांक‑आधारित इटरेशन के दौरान कई मिलान हटाते हैं, तो अंत से शुरू करके यात्रा करें ताकि प्रत्येक शेष सूचकांक वैध बना रहे।

यह उदाहरण निर्दिष्ट नाम वाली प्रत्येक आकृति को हटाता है। यह `slide.shapes[index]` को पढ़ता है, न कि स्थिर संग्रह आइटम को, और अनावश्यक रूप से आकृति को कास्ट नहीं करता।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

हटाने के बाद आकृति संख्या और बाद की आकृतियों के सूचकांक बदलते हैं। प्रभावित नहीं हुई आकृतियों के संदर्भ सहेजे गए सूचकांकों की तुलना में अधिक विश्वसनीय होते हैं। साथ ही कनेक्टर्स, एनीमेशन और अन्य प्रस्तुति‑विशेषताएँ जो हटाई गई वस्तु को संदर्भित कर सकती हैं, उनका भी ध्यान रखें; एक दृश्यमान आकृति को हटाने से स्लाइड की उपस्थिति से अधिक परिवर्तन हो सकता है।

### **आकृति को छुपाएँ**

[Shape.hidden](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/hidden/) को `True` पर सेट करने से आकृति संग्रह में बनी रहती है, लेकिन सामान्य स्लाइड‑शो में दिखाई नहीं देती। उसका सूचकांक, स्वरूपण और सामग्री कोड के लिए उपलब्ध रहती हैं, इसलिए छुपाना वैकल्पिक तत्वों के लिए उपयुक्त है जिन्हें बाद में पुनर्स्थापित किया जा सकता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

छुपाना हटाना या सुरक्षा नहीं है। वस्तु को फिर भी उपयोगकर्ता या कोड द्वारा खोजा और अनछुपा किया जा सकता है, और यह प्रस्तुति फ़ाइल का हिस्सा बनी रहती है।

### **Z‑Order बदलें**

ऊपर‑नीचे स्थित आकृतियाँ संग्रह क्रम में पेंट की जाती हैं। [ShapeCollection.reorder](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/reorder/) मौजूदा आकृति को क्लोन किए बिना लक्ष्य सूचकांक पर ले जाता है। सूचकांक `0` पीछे है; `len(slide.shapes) - 1` आगे है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

आयत सबसे पहले बनाई गई और प्रारंभ में अंडाकार के पीछे थी। उसे अंतिम सूचकांक पर ले जाने से वह आगे आ जाती है। सभी संबंधित आकृतियों को जोड़ने या क्लोन करने के बाद z‑order को अंतिम रूप दें, क्योंकि ये ऑपरेशन नई संग्रह आइटम जोड़ या सम्मिलित कर सकते हैं और इच्छित स्टैक को बदल सकते हैं।

## **लेआउट स्लाइड्स पर आकृतियों की जाँच**

सामान्य स्लाइड्स, लेआउट स्लाइड्स और मास्टर स्लाइड्स के अलग‑अलग आकृति संग्रह होते हैं। लेआउट संग्रह में एक आकृति सामान्य स्लाइड पर समान रूप से स्थित आकृति के समान ऑब्जेक्ट नहीं होती। लेआउट स्वरूपण को समझने या बदलने की आवश्यकता होने पर लेआउट आकृतियों की जाँच करें।

निम्न उदाहरण प्रत्येक लेआउट आकृति के [Shape.fill_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/fill_format/) और [Shape.line_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/line_format/) को पढ़ता है, बिना यह मानते हुए कि प्रत्येक आकृति `AutoShape` है।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

लेआउट को संपादित करने से उस लेआउट का उपयोग करने वाली कई स्लाइड्स प्रभावित हो सकती हैं। लेआउट आकृति बदलने से पहले यह निर्धारित करें कि क्या सामान्य स्लाइड ऑब्जेक्ट को विरासत में लेती है या स्थानीय ओवरराइड रखती है, और उस लेआउट का उपयोग करने वाली प्रत्येक स्लाइड का परीक्षण करें।

## **आकृति को SVG में निर्यात करें**

[Shape.write_as_svg](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/write_as_svg/) एक आकृति की रेंडर की गई सामग्री को स्ट्रीम में लिखता है। परिणाम में केवल आकृति होती है, पूरे स्लाइड बैकग्राउंड या पड़ोसी आकृतियों नहीं।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

रेंडरिंग के दौरान प्रस्तुति खुली रखें। आउटपुट आकृति के स्वरूपण और फ़ॉन्ट व छवि जैसे संसाधनों पर निर्भर करता है। यदि आपको संपूर्ण संरचना चाहिए, तो व्यक्तिगत आकृति के बजाय स्लाइड को निर्यात करें। कॉलर स्ट्रीम का मालिक होता है और उसे बंद करना चाहिए।

## **आकृतियों को संरेखित करें**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/hi/python-net/aspose.slides.util/slideutil/align_shapes/) ओवरलोड सभी आकृतियों या चयनित संग्रह सूचकांकों को संरेखित करते हैं। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapesalignmenttype/) किनारा, केंद्र रेखा या वितरण मोड निर्दिष्ट करता है। `align_to_slide` को `True` पर सेट करने से स्लाइड के किनारों का उपयोग होता है; `False` पर सेट करने से चयनित आकृतियों को आपस में संरेखित किया जाता है।

यह उदाहरण तीन आकृतियों को स्लाइड के शीर्ष किनारे के साथ संरेखित करता है। उनके वर्तमान सूचकांकों को संरेखण से ठीक पहले हल किया जाता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

संरेखण स्थिति बदलता है, न कि z‑order। सापेक्ष संरेखण के लिए सामान्यतः कम से कम दो आकृतियों की आवश्यकता होती है, जबकि क्षैतिज या ऊर्ध्वाधर वितरण के लिए पर्याप्त आकृतियों की आवश्यकता होती है ताकि स्पेसिंग निर्धारित हो सके। मेथड कॉल करने से पहले यदि आप संग्रह को संशोधित करते हैं तो सूचकांकों को पुनः‑गणना करें।

## **आकृति को फ़्लिप करें**

[ShapeFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapeframe/) वर्ग स्थिति, आकार, क्षैतिज और लंबवत फ़्लिप सेटिंग्स, तथा घूर्णन संग्रहीत करता है। इसके `flip_h` और `flip_v` मान [NullableBool](https://reference.aspose.com/slides/hi/python-net/aspose.slides/nullablebool/) का उपयोग करते हैं: `TRUE` फ़्लिप सक्रिय करता है, `FALSE` निष्क्रिय करता है, और `NOT_DEFINED` अनिर्दिष्ट या डिफ़ॉल्ट स्थिति को बरकरार रखता है।

नीचे दिया गया इनपुट प्रस्तुति एक अनफ़्लिप्ड आकृति रखता है।

![फ़्लिप करने से पहले की आकृति](shape_to_be_flipped.png)

उदाहरण प्रत्येक अन्य फ्रेम मान को बना रखता है और केवल दो फ़्लिप सेटिंग्स को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Shape.frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/frame/) नियुक्त करने से पूरा फ्रेम प्रतिस्थापित हो जाता है।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

सहेजी गई आकृति क्षैतिज और लंबवत रूप से प्रतिबिंबित होती है जबकि उसकी स्थिति, आकार और घूर्णन अपरिवर्तित रहता है।

![फ़्लिप करने के बाद की आकृति](flipped_shape.png)

## **FAQ**

**क्या मुझे आकृति पहचानकर्ता के रूप में संग्रह सूचकांक का उपयोग करना चाहिए?**

केवल अल्पकालिक प्रोसेसिंग के लिए जब संग्रह उपयोग से पहले नहीं बदलता। निर्मित टेम्पलेट्स के लिए सत्यापित `name` या `alternative_text` सम्मेलन को प्राथमिकता दें, या स्लाइड‑स्कोप्ड इंटरऑप कार्य के लिए `office_interop_shape_id` को प्रयोग करें।

**क्या छुपाई गई आकृति z‑order से हट जाती है?**

नहीं। छुपाई गई आकृति समान सूचकांक पर संग्रह में बनी रहती है। उसे पाया, पुनर्गठित, संपादित या फिर से दृश्यमान किया जा सकता है।

**क्लोन की गई आकृति ने किसी अन्य आकृति के आगे क्यों प्रकट की?**

`add_clone` क्लोन को संग्रह के अंत में जोड़ता है, जो z‑order के आगे का स्थान है। प्रारंभिक सूचकांक चुनने के लिए `insert_clone` का उपयोग करें या सभी आकृतियों को जोड़ने के बाद `reorder` का प्रयोग करें।