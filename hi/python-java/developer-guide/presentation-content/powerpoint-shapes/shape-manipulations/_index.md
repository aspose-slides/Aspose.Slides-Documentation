---
title: Python द्वारा Java में प्रस्तुति आकारों का प्रबंधन
linktitle: आकार परिवर्तन
type: docs
weight: 40
url: /hi/python-java/shape-manipulations/
keywords:
- PowerPoint आकार
- प्रस्तुति आकार
- स्लाइड पर आकार
- आकार खोजें
- आकार क्लोन करें
- आकार हटाएँ
- आकार छिपाएँ
- आकार क्रम बदलें
- इंटरऑप आकार ID प्राप्त करें
- आकार वैकल्पिक टेक्स्ट
- आकार समायोजन बिंदु
- प्रीसेट आकार समायोजन
- आकार ज्योमेट्री
- आकार लेआउट स्वरूप
- SVG के रूप में आकार
- आकार को SVG में
- आकार संरेखित करें
- आकार फ़्लिप करें
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ प्रस्तुति आकारों की पहचान, समायोजन, क्लोन, हटाना, छिपाना, क्रम बदलना, निर्यात, संरेखण और फ़्लिप करना सीखें।"
---
## **सारांश**

Aspose.Slides for Python via Java स्लाइड पर आकारों को क्रमबद्ध [ShapeCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/) के रूप में दर्शाता है। यह संग्रह वह स्थान है जहाँ आप आकारों को खोज और संशोधित कर सकते हैं और उनका स्टैक क्रम निर्धारित करता है: इंडेक्स `0` सबसे पीछे वाला आकार है, जबकि अंतिम इंडेक्स सबसे आगे वाला आकार है।

यह लेख उसी मॉडल को अपनाता है। पहले यह समझाता है कि किसी आकार की विश्वसनीय पहचान कैसे करें और प्रीसेट आकार समायोजन बिंदुओं को कैसे बदलें, फिर क्लोन, हटाना, छिपाना और क्रम बदलने के बारे में दिखाता है। अंतिम भाग लेआउट‑स्तर फॉर्मेटिंग, SVG निर्यात, अलाइनमेंट और फ़्लिप सेटिंग्स को कवर करता है। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल वही ऑपरेशन उपयोग कर सकते हैं जो आपके कार्य‑प्रवाह के लिए आवश्यक है।

## **आकारों की पहचान और खोज**

कलेक्शन इंडेक्स ज्ञात फ़ाइल को प्रोसेस करते समय सुविधाजनक होते हैं, लेकिन वे स्थायी पहचानकर्ता नहीं हैं। आकार जोड़ने, हटाने या क्रम बदलने से उनका इंडेक्स बदल सकता है। प्रस्तुति के निर्माण और रख‑रखाव के तरीके के अनुसार पहचानकर्ता चुनें:

- [Name](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getName) उन टेम्पलेट्स के लिए उपयोगी है जिन्हें डेवलपर नियंत्रित करता है और PowerPoint के Selection Pane में आसानी से देखा जा सकता है। नामों को संपादित किया जा सकता है और वे अनिवार्य रूप से अद्वितीय नहीं होते, इसलिए यदि कोड उन पर निर्भर करता है तो नामकरण नियम स्थापित करें।
- [AlternativeText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getAlternativeText) तब उपयोगी होता है जब कोई एक्सेसिबिलिटी विवरण या लेखक‑द्वारा दिया गया टैग पहले से ही आकार की पहचान करता हो। यह उपयोगकर्ताओं को दिखता है, स्थानीयकृत या एक्सेसिबिलिटी के लिये पुनः‑लेखा जा सकता है, और यह अनिवार्य रूप से अद्वितीय नहीं है। अर्थपूर्ण एक्सेसिबिलिटी टेक्स्ट को चुपचाप डेटाबेस कुंजी के रूप में उपयोग न करें।
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getOfficeInteropShapeId) एक केवल‑पढ़ने योग्य पहचानकर्ता है जो स्लाइड के भीतर अद्वितीय है और PowerPoint इंटरोप द्वारा उपयोग किए जाने वाले Shape ID से मेल खाता है। PowerPoint के साथ एकीकरण या किसी आकार के जीवन‑काल के दौरान अस्पष्ट संदर्भ की आवश्यकता होने पर इसका उपयोग करें। क्लोन या पुनः‑निर्मित आकार अलग होता है और अपना स्वयं का ID प्राप्त करता है।

संबंधित [getUniqueId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getUniqueId) विधि प्रस्तुति‑स्तर पर पहचानकर्ता लौटाती है, लेकिन यह पहचानकर्ता ऐड‑इन के लिये अभिप्रेत है और पुनः‑सेट किया जा सकता है। इसे स्थायी बाहरी कुंजी के रूप में नहीं माना जाना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है, तो अनुप्रयोग डेटा में मैपिंग रखें और यह सत्यापित करें कि अपेक्षित आकार अभी भी मौजूद है।

निम्न उदाहरण नाम द्वारा सटीक तुलना के साथ खोजता है और स्लाइड‑स्कोप्ड इंटरोप ID रिपोर्ट करता है। जब टेम्पलेट में अपेक्षित आकार नहीं मिलता, तो कोड गलत ऑब्जेक्ट के साथ आगे बढ़ने के बजाय वह परिणाम रिपोर्ट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

जब कोई ऑपरेशन आकार प्रकार विशेष होता है, तो प्रकार‑विशिष्ट सदस्य उपयोग करने से पहले प्रकार जाँचें। यह उदाहरण तभी टेक्स्ट और वैकल्पिक टेक्स्ट अपडेट करता है जब नामित वस्तु एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) हो।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **प्रीसेट आकार समायोजन की पहचान और संशोधन**

प्रीसेट ज्योमेट्री आकार समायोजन बिंदु उजागर कर सकते हैं जो कोने के आकार, तीर अनुपात या चाप कोण जैसे गुणों को नियंत्रित करते हैं। इन्हें केवल‑पढ़ने योग्य [GeometryShape.getAdjustments](https://reference.aspose.com/slides/hi/python-java/aspose.slides/geometryshape/#getAdjustments) संग्रह के माध्यम से पहुँचें। यह संग्रह स्वयं आकार द्वारा प्रदान किया जाता है, लेकिन प्रत्येक [AdjustValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/) में एक मान होता है जिसे बदला जा सकता है।

केवल स्थिर संग्रह इंडेक्स पर निर्भर न रहें। समायोजनों पर इटरेट करें और केवल‑पढ़ने योग्य [getType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#getType) विधि की जाँच करें, जिसका [ShapeAdjustmentType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapeadjustmenttype/) मान बताता है कि समायोजन किस चीज़ को नियंत्रित करता है। केवल‑पढ़ने योग्य [getName](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#getName) विधि अतिरिक्त पहचान जानकारी प्रदान करती है और जब प्रीसेट में समान अर्थ वाले कई समायोजन हों तब विशेष रूप से उपयोगी होती है।

समायोजन के अर्थ से मेल खाने वाले मान‑विधि का उपयोग करें:

| समायोजन प्रकार | उद्देश्य | बदलने के लिये मान |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | गोल कोनों का आकार | [setRawValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | तीर के पूंछ की मोटाई | [setRawValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | तीर की नोक की लंबाई | [setRawValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | तीर की नोक की चौड़ाई | [setRawValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | पाई या चाप का प्रारंभिक कोण | [setAngleValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | पाई या चाप का अंतिम कोण | [setAngleValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#getType) और [getName](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#getName) केवल‑पढ़ने योग्य जानकारी लौटाते हैं। [getRawValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#getRawValue) और [setRawValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#setRawValue) प्रीसेट की मूल ज्योमेट्री इकाइयों में पूर्णांक के साथ काम करते हैं, जबकि [getAngleValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#getAngleValue) और [setAngleValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#setAngleValue) डिग्री में कोण के साथ काम करते हैं। समायोजन की संख्या, क्रम, अर्थ और वैध रेंज प्रीसेट [ShapeType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/geometryshape/#getShapeType) पर निर्भर करती है। एक प्रीसेट के लिये मान्य एक मान दूसरे प्रीसेट में अमान्य या अलग प्रभाव डाल सकता है।

जब [getType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#getType) [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapeadjustmenttype/#Custom) लौटाता है, तो API कोई मानक अर्थ नहीं पहचानती। [getName](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#getName), प्रीसेट प्रकार और मौजूदा मान देखें, और तभी समायोजन बदलें जब अपेक्षित अर्थ और रेंज ज्ञात हों। पहचाने गये प्रकारों के लिये भी जाँचें कि क्या वही प्रकार कई बार प्रकट होता है, तब ही मान चुनें। [Connector](/slides/hi/python-java/connector/) आलेख में कनेक्टर बेंड समायोजनों की स्थिति दिखायी गयी है।

निम्न पूर्ण उदाहरण तीन प्रीसेट आकारों के डिफ़ॉल्ट और संशोधित संस्करण बनाता है। यह हर समायोजन पर इटरेट करता है, उसका नाम और प्रकार रिपोर्ट करता है, आकार‑संबंधी मानों को [setRawValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#setRawValue) से बदलता है, कोणों को [setAngleValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#setAngleValue) से बदलता है, और परिणाम सहेजता है। बायाँ कॉलम डिफ़ॉल्ट ज्योमेट्री रखता है; दायाँ कॉलम समायोजित गोल आयत, चार‑तरफ़ा तीर और पाई दिखाता है।

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # डिफ़ॉल्ट और समायोजित आकार कॉलम के लिए हेडर जोड़ता है।
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

समायोजन बदलने से पहले अर्थ‑जाँच करने से कोड का इरादा स्पष्ट रहता है और यह मानते हुए त्रुटियों से बचता है कि विभिन्न प्रीसेट आकारों में समान संग्रह‑इंडेक्स का समान अर्थ है।

## **आकार संग्रह में संशोधन**

जोड़ने, क्लोन करने, हटाने और क्रम‑बदलने की विधियाँ संग्रह पर तुरंत प्रभाव डालती हैं। यदि कोई ऑपरेशन आकारों की संख्या या क्रम बदलता है, तो उस ऑपरेशन से पहले प्राप्त किए गये इंडेक्स पर निर्भर नहीं रहना चाहिए।

### **आकार क्लोन करना**

[addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addClone) एक स्वतंत्र कॉपी बनाता है और उसे लक्ष्य संग्रह के अंत में जोड़ता है। [insertClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#insertClone) भी कॉपी बनाता है लेकिन उसे निर्दिष्ट z‑order इंडेक्स पर रखता है। समन्वय‑स्वीकार करने वाले ओवरलोड क्लोन का आकार नहीं बदलते; चौड़ाई‑और‑ऊँचाई वाले ओवरलोड इसे आकार बदल भी सकते हैं।

निम्न उदाहरण एक लक्ष्य स्लाइड बनाता है, लेबल‑युक्त आयत को आगे क्लोन करता है, और दूसरा क्लोन पीछे सम्मिलित करता है। किसी भी क्लोन में परिवर्तन स्रोत आकार को प्रभावित नहीं करता।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

क्लोन आकार की सामग्री और फ़ॉर्मेटिंग, जिसमें उसका नाम और वैकल्पिक टेक्स्ट शामिल है, को भी कॉपी करता है। जब ये मान अद्वितीय होने चाहिए तो क्लोन को नए तार्किक पहचानकर्ता दें। जटिल आकारों द्वारा उपयोग किए गये संसाधनों को प्रस्तुति संभालती है, लेकिन क्लोन एक नया संग्रह आइटम होता है जिसका अपना आकार पहचान होता है।

### **आकार हटाना**

[remove](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#remove) एक विशिष्ट आकार वस्तु को उसकी संग्रह से हटाता है। जब आप इंडेक्स‑आधारित इटरेशन के दौरान कई मिलान हटाते हैं, तो अंत से शुरू करके चलें ताकि शेष इंडेक्स वैध रहें।

यह उदाहरण निर्दिष्ट नाम वाले सभी आकारों को हटाता है। यह वर्तमान इंडेक्स पर आकार पढ़ता है, न कि निश्चित संग्रह आइटम, और आकार को अनावश्यक रूप से कास्ट नहीं करता।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

हटाने के बाद आकार गणना और बाद के आकारों के इंडेक्स बदलते हैं। अप्रभावित आकारों के संदर्भ सहेजे गये इंडेक्स की तुलना में अधिक विश्वसनीय रहते हैं। साथ ही कनेक्टर, एनीमेशन और अन्य प्रस्तुति सुविधाओं पर भी विचार करें जो हटाए गये वस्तु को संदर्भित कर सकते हैं; दृश्य आकार हटाने से स्लाइड की उपस्थिति से अधिक कुछ बदल सकता है।

### **आकार छिपाना**

[Hidden](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#setHidden) को `True` पर सेट करने से आकार संग्रह में बना रहता है लेकिन सामान्य स्लाइड शो में दिखाई नहीं देता। उसका इंडेक्स, फ़ॉर्मेटिंग और सामग्री कोड के लिये उपलब्ध रहती है, इसलिए वैकल्पिक तत्वों को बाद में पुनः‑प्रकट करने के लिये छिपाना उपयुक्त है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

छिपाना हटाना या सुरक्षा नहीं है। वस्तु को उपयोगकर्ता या कोड द्वारा अभी भी खोजा और अनहिड़ किया जा सकता है, और वह प्रस्तुति फ़ाइल का हिस्सा बनी रहती है।

### **Z‑Order बदलना**

ओवरलैपिंग आकार संग्रह क्रम में पेंट होते हैं। [reorder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#reorder) मौजूदा आकार को लक्ष्य इंडेक्स पर ले जाता है बिना क्लोन किए। इंडेक्स `0` पीछे है; संग्रह [size](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#size)‑1 आगे है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

आयत पहले बनाया जाता है और प्रारम्भ में दीर्घवृत्त के पीछे रहता है। उसे अंतिम इंडेक्स पर ले जाने से वह आगे आ जाता है। सभी संबंधित आकारों को जोड़ने या क्लोन करने के बाद z‑order को अंतिम रूप दें, क्योंकि ये ऑपरेशन नए संग्रह आइटम जोड़ते या सम्मिलित करते हैं और स्टैक क्रम बदल सकते हैं।

## **लेआउट स्लाइड्स पर आकारों का निरीक्षण**

सामान्य स्लाइड्स, लेआउट स्लाइड्स और मास्टर स्लाइड्स के अलग‑अलग आकार संग्रह होते हैं। लेआउट संग्रह में एक आकार सामान्य स्लाइड पर समान‑स्थिति वाले आकार के समान वस्तु नहीं होता। लेआउट आकारों का निरीक्षण तब करें जब आपको लेआउट द्वारा प्रदान किए गये फ़ॉर्मेटिंग को समझना या बदलना हो।

निम्न उदाहरण प्रत्येक लेआउट आकार की [FillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getFillFormat) और [LineFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getLineFormat) को पढ़ता है, बिना यह मानते हुए कि हर आकार एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

लेआउट में बदलाव कई स्लाइड्स को प्रभावित कर सकता है जो उसका उपयोग करती हैं। लेआउट आकार बदलने से पहले निर्धारित करें कि क्या कोई सामान्य स्लाइड वस्तु को विरासत में प्राप्त करती है या स्थानीय ओवरराइड रखती है, और उस लेआउट का उपयोग करने वाली प्रत्येक स्लाइड का परीक्षण करें।

## **आकार को SVG में निर्यात करना**

[Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) की `writeAsSvg` विधि एक आकार की रेंडर की गई सामग्री को स्ट्रीम में लिखती है। परिणाम में केवल वह आकार होता है, पूरी स्लाइड पृष्ठभूमि या पड़ोसी आकार नहीं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

रेंडरिंग के दौरान प्रस्तुति खुली रखे। आउटपुट आकार की फ़ॉर्मेटिंग तथा फ़ॉन्ट और छवियों जैसी संसाधनों पर निर्भर करता है। यदि आपको पूरी रचना चाहिए तो स्लाइड को निर्यात करें, न कि व्यक्तिगत आकार को। कॉलर को स्ट्रीम का स्वामित्व होता है और उसे बंद करना आवश्यक है।

## **आकारों को संरेखित करना**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideutil/#alignShapes) के ओवरलोड सभी आकारों या चयनित संग्रह इंडेक्स को संरेखित करते हैं। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapesalignmenttype/) किनारा, केंद्र रेखा या वितरण मोड निर्दिष्ट करता है। `align_to_slide` को `True` पर सेट करने से स्लाइड किनारे उपयोग होते हैं; `False` पर सेट करने से चयनित आकार आपस में संरेखित होते हैं।

यह उदाहरण तीन आकारों को स्लाइड के शीर्ष किनारे पर संरेखित करता है। लौटाए गये आकार संदर्भों को संरेखण से ठीक पहले उनके वर्तमान इंडेक्स में परिवर्तित किया जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

संरेखण स्थिति बदलता है, z‑order नहीं। सापेक्ष संरेखण सामान्यतः कम से कम दो आकारों की आवश्यकता रखता है, जबकि क्षैतिज या लंबवत वितरण के लिये पर्याप्त संख्या में आकारों की आवश्यकता होती है ताकि अंतराल निर्धारित किया जा सके। विधि कॉल करने से पहले यदि आप संग्रह संशोधित करते हैं तो इंडेक्स पुनः‑गणना करें।

## **आकार को फ़्लिप करना**

[ShapeFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapeframe/) क्लास स्थिति, आकार, क्षैतिज और लंबवत फ़्लिप सेटिंग्स तथा घूर्णन संग्रहीत करता है। इसकी [getFlipH](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapeframe/#getFlipH) और [getFlipV](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapeframe/#getFlipV) मान [NullableBool](https://reference.aspose.com/slides/hi/python-java/aspose.slides/nullablebool/) का उपयोग करते हैं: `True` फ़्लिप सक्षम करता है, `False` निष्क्रिय करता है, और `NotDefined` अनिर्दिष्ट/डिफ़ॉल्ट स्थिति को बनाए रखता है।

नीचे दिया गया इनपुट प्रस्तुति एक अनफ़्लिप्ड आकार रखती है।

![The shape before flipping](shape_to_be_flipped.png)

उदाहरण सभी अन्य फ्रेम मानों को बरकरार रखता है और केवल दो फ़्लिप सेटिंग को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Frame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#setFrame) असाइन करने से पूरा फ्रेम बदल जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

सहेजा गया आकार क्षैतिज और लंबवत दोनों दिशा में प्रतिबिंबित हो जाता है, जबकि उसकी स्थिति, आकार और घूर्णन समान रहता है।

![The shape after flipping](flipped_shape.png)

## **FAQ**

**क्या मुझे आकार पहचानकर्ता के रूप में संग्रह इंडेक्स का उपयोग करना चाहिए?**

केवल अल्पकालिक प्रोसेसिंग के लिये जब संग्रह उस इंडेक्स के उपयोग से पहले नहीं बदलेगा। लिखित टेम्पलेट्स के लिये मान्य [Name](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getName) या [AlternativeText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getAlternativeText) नियम का उपयोग करें, या स्लाइड‑स्कोप्ड इंटरोप कार्य के लिये [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getOfficeInteropShapeId) प्रयोग करें।

**क्या आकार को छिपाने से वह z‑order से हट जाता है?**

नहीं। छिपा आकार वही इंडेक्स पर संग्रह में रहता है। उसे पाया, क्रम बदल, संपादित या फिर से दृश्यमान किया जा सकता है।

**क्लोन किया गया आकार किसी अन्य आकार के सामने क्यों दिखाई दिया?**

[addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addClone) क्लोन को संग्रह के अंत में जोड़ता है, जो z‑order के आगे के बराबर है। प्रारम्भिक इंडेक्स चुनने के लिये [insertClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#insertClone) का उपयोग करें या सभी आकार जोड़ने के बाद [reorder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#reorder) करें।

**क्या मैं प्रीसेट आकार समायोजन की पहचान के लिये स्थिर इंडेक्स इस्तेमाल कर सकता हूँ?**

केवल तभी जब आप सटीक प्रीसेट और संग्रह लेआउट को सत्यापित करें। [GeometryShape.getAdjustments](https://reference.aspose.com/slides/hi/python-java/aspose.slides/geometryshape/#getAdjustments) के माध्यम से इटरेट करें और [AdjustValue.getType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#getType) की जाँच करें; जब समान अर्थ वाला प्रकार कई बार आता है तो अतिरिक्त जानकारी के लिये [AdjustValue.getName](https://reference.aspose.com/slides/hi/python-java/aspose.slides/adjustvalue/#getName) का उपयोग करें।