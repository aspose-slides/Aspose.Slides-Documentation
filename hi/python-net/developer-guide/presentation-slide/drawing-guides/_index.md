---
title: Python में प्रस्तुतियों में ड्राइंग गाइड्स प्रबंधित करें
linktitle: ड्राइंग गाइड्स
type: docs
weight: 85
url: /hi/python-net/drawing-guides/
keywords:
- ड्राइंग गाइड
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
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint प्रस्तुतियों में क्षैतिज और लंबवत ड्राइंग गाइड्स जोड़ें, पहुँचें और साफ़ करें।"
---
## **परिचय**

ड्राइंग गाइड्स समायोज्य क्षैतिज और लंबवत रेखाएँ हैं जो उपयोगकर्ताओं को PowerPoint में प्रस्तुति संपादित करते समय आकारों को सुसंगत रूप से संरेखित करने में मदद करती हैं। ये विशेष रूप से तब उपयोगी होते हैं जब कोई एप्लिकेशन प्रस्तुति उत्पन्न करता है जिसे बाद में मैन्युअल रूप से परिष्कृत किया जाएगा: एप्लिकेशन वही संरेखण सहायता सहेज सकता है जिसे लेखक सामग्री जोड़ते या स्थानांतरित करते समय अनुसरण करें।

ड्राइंग गाइड्स संपादन सहायक हैं, स्लाइड सामग्री नहीं। वे स्लाइड शो या रेंडर किए गए आउटपुट में दिखाई नहीं देते। Aspose.Slides for Python via .NET इन्हें [IDrawingGuidesCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/idrawingguidescollection/) इंटरफ़ेस के माध्यम से उजागर करता है। एक गाइड को [IDrawingGuide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/idrawingguide/) द्वारा दर्शाया जाता है और इसमें अभिमुखता, स्थिति और रंग होते हैं।

स्थिति संबंधित स्लाइड या मास्टर के ऊपर‑बाएँ कोने से पॉइंट्स में मापा जाता है। एक लंबवत गाइड क्षैतिज निर्देशांक का उपयोग करता है, आमतौर पर शून्य और स्लाइड की चौड़ाई के बीच। एक क्षैतिज गाइड लंबवत निर्देशांक का उपयोग करता है, आमतौर पर शून्य और स्लाइड की ऊँचाई के बीच।

## **स्लाइड व्यू में गाइड जोड़ें**

सामान्य स्लाइड्स को संपादित करते समय प्रदर्शित गाइड्स को प्रबंधित करने के लिए [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) का उपयोग करें। [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/hi/python-net/aspose.slides/idrawingguidescollection/add/) को एक [Orientation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/orientation/) मान और पॉइंट्स में एक स्थिति के साथ कॉल करें।

निम्न उदाहरण स्लाइड केंद्र के दाएँ ओर एक लंबवत गाइड और उसके नीचे एक क्षैतिज गाइड जोड़ता है:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **ड्राइंग गाइड्स तक पहुँच**

[IDrawingGuidesCollection.count](https://reference.aspose.com/slides/hi/python-net/aspose.slides/idrawingguidescollection/count/) संपत्ति और इंडेक्सर मौजूदा गाइड्स तक पहुँच प्रदान करते हैं। [IDrawingGuide.orientation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/hi/python-net/aspose.slides/idrawingguide/position/), और [IDrawingGuide.color](https://reference.aspose.com/slides/hi/python-net/aspose.slides/idrawingguide/color/) गुण को पढ़ा या बदला जा सकता है।

निम्न उदाहरण उपर बनाया गया प्रस्तुति से स्लाइड‑व्यू गाइड्स को पढ़ता है:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **मास्टर और लेआउट स्लाइड्स में गाइड जोड़ें**

एक स्लाइड मास्टर और उसके प्रत्येक लेआउट स्लाइड में अपने स्वयं के ड्राइंग‑गाइड संग्रह हो सकते हैं। मास्टर स्लाइड के लिए [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imasterslide/drawing_guides/), और लेआउट स्लाइड के लिए [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ilayoutslide/drawing_guides/) का उपयोग करें।

निम्न उदाहरण पहले मास्टर स्लाइड में एक लंबवत गाइड और पहले लेआउट स्लाइड में एक क्षैतिज गाइड जोड़ता है:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **नोट्स और हैंडआउट मास्टर्स में गाइड जोड़ें**

नोट्स मास्टर और हैंडआउट मास्टर भी ड्राइंग गाइड्स का समर्थन करते हैं। उनके संग्रह तक पहुँचने के लिए [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imasternotesslide/drawing_guides/) और [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) का उपयोग करें। यदि प्रस्तुति में इन मास्टरों में से कोई नहीं है, तो [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) या [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) डिफ़ॉल्ट मास्टर बनाते हैं और उसे लौटाते हैं।

निम्न उदाहरण नोट्स मास्टर में एक क्षैतिज गाइड और हैंडआउट मास्टर में एक लंबवत गाइड जोड़ता है:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **ड्राइंग गाइड्स को साफ़ करें**

[IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides/idrawingguidescollection/clear/) को कॉल करके किसी विशेष संग्रह से सभी गाइड्स को हटाया जा सकता है। एक संग्रह को साफ़ करने से दूसरे स्कोप में संग्रहीत गाइड्स प्रभावित नहीं होते।

निम्न उदाहरण स्लाइड‑व्यू गाइड्स तथा स्लाइड मास्टर्स, लेआउट स्लाइड्स, नोट्स मास्टर और हैंडआउट मास्टर पर सभी गाइड्स को बिना अनुपलब्ध मास्टर बनाए साफ़ करता है:

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या ड्राइंग गाइड्स स्लाइड शो या निर्यातित चित्रों में प्रदर्शित होते हैं?**  
नहीं। ड्राइंग गाइड्स संपादन के लिए संरेखण सहायता हैं और प्रस्तुति की सामग्री के रूप में रेंडर नहीं होते।

**क्या एक ड्राइंग गाइड को सीधे व्यक्तिगत सामान्य स्लाइड में जोड़ा जा सकता है?**  
सामान्य स्लाइड के संपादन गाइड्स प्रस्तुति की स्लाइड‑व्यू गुणों में संग्रहीत होते हैं। स्लाइड मास्टर्स, लेआउट स्लाइड्स, नोट्स मास्टर और हैंडआउट मास्टर के लिए अलग गाइड संग्रह उपलब्ध हैं।

**गाइड स्थितियों के लिए कौन से इकाइयाँ उपयोग की जाती हैं?**  
स्थितियों को पॉइंट्स में निर्दिष्ट किया जाता है, जहाँ 72 पॉइंट्स एक इंच के बराबर होते हैं। लंबवत स्थितियों को बाएँ किनारे से मापा जाता है, और क्षैतिज स्थितियों को शीर्ष किनारे से मापा जाता है।

**क्या ड्राइंग गाइड्स को साफ़ करने से शैलियाँ हटती हैं या स्लाइड सामग्री बदलती है?**  
नहीं। `clear` मेथड केवल चयनित संग्रह में मौजूद गाइड्स को हटाता है। शैलियाँ और अन्य स्लाइड सामग्री अपरिवर्तित रहती हैं।