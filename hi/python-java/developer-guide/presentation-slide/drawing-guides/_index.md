---
title: Python में प्रस्तुतियों में ड्रॉइंग गाइड्स का प्रबंधन
linktitle: ड्रॉइंग गाइड्स
type: docs
weight: 85
url: /hi/python-java/drawing-guides/
keywords:
- ड्रॉइंग गाइड
- क्षैतिज गाइड
- लंबवत गाइड
- संरेखण गाइड
- स्लाइड व्यू
- मास्टर स्लाइड
- लेआउट स्लाइड
- नोट्स मास्टर
- हैंडआउट मास्टर
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों में क्षैतिज और लंबवत ड्रॉइंग गाइड्स को जोड़ें, एक्सेस करें और साफ़ करें।"
---
## **अवलोकन**

ड्रॉइंग गाइड समायोज्य क्षैतिज और लंबवत रेखाएँ हैं जो उपयोगकर्ताओं को PowerPoint में प्रस्तुति को संपादित करते समय आकृतियों को लगातार संरेखित करने में मदद करती हैं। ये विशेष रूप से तब उपयोगी होती हैं जब कोई एप्लीकेशन प्रस्तुति बनाता है जिसे बाद में मैन्युअल रूप से परिष्कृत किया जाएगा: एप्लीकेशन समान संरेखण सहायक को सहेज सकता है जिसे लेखक सामग्री जोड़ते या स्थानांतरित करते समय पालन करें।

ड्रॉइंग गाइड संपादन सहायता हैं, स्लाइड सामग्री नहीं। वे स्लाइड शो या रेंडर किए गए आउटपुट में दिखाई नहीं देते। Aspose.Slides for Python via Java इन्हें [DrawingGuidesCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/drawingguidescollection/) क्लास के माध्यम से उजागर करता है। एक गाइड को [DrawingGuide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/drawingguide/) द्वारा दर्शाया जाता है और इसमें अभिविन्यास, स्थिति और रंग होता है।

स्थिति संबंधित स्लाइड या मास्टर के ऊपर‑बाएँ कोने से पॉइंट में मापी जाती है। एक लंबवत गाइड क्षैतिज निर्देशांक का उपयोग करता है, आम तौर पर शून्य से स्लाइड की चौड़ाई तक। एक क्षैतिज गाइड ऊर्ध्वाधर निर्देशांक का उपयोग करता है, आम तौर पर शून्य से स्लाइड की ऊँचाई तक।

## **स्लाइड व्यू में गाइड जोड़ें**

सामान्य स्लाइड व्यू प्रॉपर्टीज़ में प्रदर्शित गाइड को प्रबंधित करने के लिए [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) का उपयोग करें। एक [Orientation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/orientation/) मान और पॉइंट में स्थिति के साथ [DrawingGuidesCollection.add](https://reference.aspose.com/slides/hi/python-java/aspose.slides/drawingguidescollection/#add) को कॉल करें।

निम्न उदाहरण स्लाइड के केंद्र के दाएँ ओर एक लंबवत गाइड और उसके नीचे एक क्षैतिज गाइड जोड़ता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ड्रॉइंग गाइड्स तक पहुँचें**

[DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/hi/python-java/aspose.slides/drawingguidescollection/#getCount) और [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/hi/python-java/aspose.slides/drawingguidescollection/#get_Item) मेथड मौजूदा गाइड्स तक पहुँच प्रदान करते हैं। [DrawingGuide.getOrientation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/drawingguide/#getPosition) और [DrawingGuide.getColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/drawingguide/#getColor) मेथड मान लौटाते हैं जिन्हें संबंधित सेट्टर मेथड के माध्यम से बदला भी जा सकता है।

निम्न उदाहरण ऊपर बनाए गए प्रस्तुति से स्लाइड‑व्यू गाइड्स को पढ़ता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **मास्टर और लेआउट स्लाइड्स में गाइड जोड़ें**

एक स्लाइड मास्टर और उसकी प्रत्येक लेआउट स्लाइड की अपनी ड्रॉइंग‑गाइड संग्रह हो सकती है। मास्टर स्लाइड के लिए [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/#getDrawingGuides) और लेआउट स्लाइड के लिए [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/#getDrawingGuides) का उपयोग करें।

निम्न उदाहरण पहले मास्टर स्लाइड में एक लंबवत गाइड और पहले लेआउट स्लाइड में एक क्षैतिज गाइड जोड़ता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **नोट्स और हैंडआउट मास्टर्स में गाइड जोड़ें**

नोट्स मास्टर और हैंडआउट मास्टर भी ड्रॉइंग गाइड्स का समर्थन करते हैं। इनके संग्रह तक पहुँचने के लिए [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masternotesslide/#getDrawingGuides) और [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) का उपयोग करें। यदि प्रस्तुति में इनमें से कोई मास्टर मौजूद नहीं है, तो `MasterNotesSlideManager.setDefaultMasterNotesSlide` या `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` डिफ़ॉल्ट मास्टर बनाता है और उसे लौटाता है।

निम्न उदाहरण नोट्स मास्टर में एक क्षैतिज गाइड और हैंडआउट मास्टर में एक लंबवत गाइड जोड़ता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ड्रॉइंग गाइड्स साफ़ करें**

किसी विशेष संग्रह से सभी गाइड हटाने के लिए [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/drawingguidescollection/#clear) को कॉल करें। एक संग्रह को साफ़ करने से दूसरे स्कोप में संग्रहीत गाइड्स प्रभावित नहीं होते।

निम्न उदाहरण स्लाइड‑व्यू गाइड्स और स्लाइड मास्टर, लेआउट स्लाइड, नोट्स मास्टर तथा हैंडआउट मास्टर पर सभी गाइड्स को बिना गायब मास्टर बनाए साफ़ करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या ड्रॉइंग गाइड्स स्लाइड शो या निर्यातित चित्रों में दिखाई देते हैं?**

नहीं। ड्रॉइंग गाइड्स संपादन के लिए संरेखण सहायता हैं और प्रस्तुति सामग्री के रूप में रेंडर नहीं होते।

**क्या कोई ड्रॉइंग गाइड सीधे व्यक्तिगत सामान्य स्लाइड में जोड़ी जा सकती है?**

सामान्य‑स्लाइड संपादन गाइड्स प्रस्तुति की स्लाइड‑व्यू प्रॉपर्टीज़ में संग्रहीत होते हैं। स्लाइड मास्टर, लेआउट स्लाइड, नोट्स मास्टर और हैंडआउट मास्टर के लिए अलग गाइड संग्रह उपलब्ध हैं।

**गाइड स्थितियों के लिए कौन सी इकाइयाँ उपयोग की जाती हैं?**

स्थितियों को पॉइंट में निर्दिष्ट किया जाता है, जहाँ 72 पॉइंट एक इंच के बराबर होते हैं। लंबवत स्थितियाँ बाएँ किनारे से मापी जाती हैं, और क्षैतिज स्थितियाँ ऊपर के किनारे से मापी जाती हैं।

**क्या ड्रॉइंग गाइड्स साफ़ करने से आकृतियों या स्लाइड सामग्री में परिवर्तन होते हैं?**

नहीं। [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/drawingguidescollection/#clear) मेथड केवल चयनित संग्रह में मौजूद गाइड्स को हटाता है। आकृतियाँ और अन्य स्लाइड सामग्री अपरिवर्तित रहती हैं।