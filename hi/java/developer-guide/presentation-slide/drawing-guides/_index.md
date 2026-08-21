---
title: Java में प्रस्तुतियों में ड्रॉइंग गाइड्स को प्रबंधित करें
linktitle: ड्रॉइंग गाइड्स
type: docs
weight: 85
url: /hi/java/drawing-guides/
keywords:
- ड्रॉइंग गाइड
- क्षैतिज गाइड
- ऊर्ध्वाधर गाइड
- संरेखण गाइड
- स्लाइड व्यू
- मास्टर स्लाइड
- लेआउट स्लाइड
- नोट्स मास्टर
- हैंडआउट मास्टर
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint प्रस्तुतियों में क्षैतिज और ऊर्ध्वाधर ड्रॉइंग गाइड्स को जोड़ें, एक्सेस करें और साफ़ करें।"
---
## **अवलोकन**

ड्रॉइंग गाइड्स समायोज्य क्षैतिज और ऊर्ध्वाधर रेखाएँ होती हैं जो उपयोगकर्ताओं को PowerPoint में प्रस्तुति को संपादित करते समय आकृतियों को लगातार संरेखित करने में मदद करती हैं। ये विशेष रूप से तब उपयोगी होती हैं जब कोई एप्लिकेशन प्रस्तुति उत्पन्न करता है जिसे बाद में मैन्युअल रूप से परिष्कृत किया जाएगा: एप्लिकेशन वही संरेखण सहायक सहेज सकता है जिसे लेखक सामग्री जोड़ते या स्थानांतरित करते समय अनुसरण करें।

ड्रॉइंग गाइड्स संपादन सहायक होते हैं, स्लाइड सामग्री नहीं। वे स्लाइड शो या रेंडर किए गए आउटपुट में दिखाई नहीं देते। Aspose.Slides for Java उन्हें [IDrawingGuidesCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idrawingguidescollection/) इंटरफ़ेस के माध्यम से उजागर करता है। एक गाइड को [IDrawingGuide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idrawingguide/) द्वारा प्रस्तुत किया जाता है और इसमें अभिविन्यास, स्थिति और रंग होते हैं।

स्थिति को संबंधित स्लाइड या मास्टर के ऊपर‑बाएँ कोने से पॉइंट्स में मापा जाता है। एक ऊर्ध्वाधर गाइड क्षैतिज निर्देशांक का उपयोग करता है, आमतौर पर शून्य से स्लाइड की चौड़ाई के बीच। एक क्षैतिज गाइड ऊर्ध्वाधर निर्देशांक का उपयोग करता है, आमतौर पर शून्य से स्लाइड की ऊँचाई के बीच।

## **स्लाइड व्यू में गाइड्स जोड़ें**

सामान्य स्लाइड्स को संपादित करते समय प्रदर्शित गाइड्स को प्रबंधित करने के लिए [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) का उपयोग करें। एक [Orientation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/orientation/) मान और पॉइंट्स में एक स्थिति के साथ [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) को कॉल करें।

निम्नलिखित उदाहरण स्लाइड के केंद्र के दाएँ ओर एक ऊर्ध्वाधर गाइड और उसके नीचे एक क्षैतिज गाइड जोड़ता है:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ड्रॉइंग गाइड्स तक पहुँच**

[IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idrawingguidescollection/#getCount--) और [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idrawingguidescollection/#get_Item-int--) मेथड्स मौजूदा गाइड्स तक पहुँच प्रदान करते हैं। [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idrawingguide/#getPosition--), और [IDrawingGuide.getColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idrawingguide/#getColor--) मेथड्स ऐसे मान लौटाते हैं जिन्हें संबंधित सेट्टर मेथड्स के माध्यम से भी बदला जा सकता है।

निम्नलिखित उदाहरण ऊपर निर्मित प्रस्तुति से स्लाइड‑व्यू गाइड्स को पढ़ता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **मास्टर और लेआउट स्लाइड्स में गाइड्स जोड़ें**

एक स्लाइड मास्टर और उसके प्रत्येक लेआउट स्लाइड की अपनी ड्रॉइंग‑गाइड कलेक्शन हो सकती है। एक मास्टर स्लाइड के लिए [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslide/#getDrawingGuides--) और एक लेआउट स्लाइड के लिए [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--) का उपयोग करें।

निम्नलिखित उदाहरण प्रथम मास्टर स्लाइड में एक ऊर्ध्वाधर गाइड और प्रथम लेआउट स्लाइड में एक क्षैतिज गाइड जोड़ता है:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **नोट्स और हैंडआउट मास्टर्स में गाइड्स जोड़ें**

नोट्स मास्टर्स और हैंडआउट मास्टर्स भी ड्रॉइंग गाइड्स को समर्थन देते हैं। उनके कलेक्शन तक पहुँचने के लिए [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) और [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) का उपयोग करें। यदि प्रस्तुति में इनमें से कोई मास्टर नहीं है, तो [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) या [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) डिफ़ॉल्ट मास्टर बनाता है और उसे वापस करता है।

निम्नलिखित उदाहरण नोट्स मास्टर में एक क्षैतिज गाइड और हैंडआउट मास्टर में एक ऊर्ध्वाधर गाइड जोड़ता है:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ड्रॉइंग गाइड्स साफ़ करें**

किसी विशिष्ट कलेक्शन से सभी गाइड्स को हटाने के लिए [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idrawingguidescollection/#clear--) को कॉल करें। एक कलेक्शन को साफ़ करने से अन्य स्कोप में संग्रहीत गाइड्स पर कोई असर नहीं पड़ता।

निम्नलिखित उदाहरण स्लाइड‑व्यू गाइड्स और स्लाइड मास्टर्स, लेआउट स्लाइड्स, नोट्स मास्टर और हैंडआउट मास्टर पर सभी गाइड्स को बिना लापता मास्टर बनाए साफ़ करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या ड्रॉइंग गाइड्स स्लाइड शो या निर्यातित छवियों में दिखते हैं?**  
नहीं। ड्रॉइंग गाइड्स संपादन के लिए संरेखण सहायक होते हैं और उन्हें प्रस्तुति सामग्री के रूप में रेंडर नहीं किया जाता।

**क्या ड्रॉइंग गाइड को सीधे किसी व्यक्तिगत सामान्य स्लाइड में जोड़ा जा सकता है?**  
सामान्य स्लाइड संपादन गाइड्स प्रस्तुति की स्लाइड‑व्यू प्रॉपर्टीज़ में संग्रहीत होते हैं। स्लाइड मास्टर्स, लेआउट स्लाइड्स, नोट्स मास्टर्स, और हैंडआउट मास्टर्स के लिए अलग-अलग गाइड कलेक्शन उपलब्ध हैं।

**गाइड स्थितियों के लिए कौन सी इकाइयाँ उपयोग की जाती हैं?**  
स्थिति को पॉइंट्स में निर्दिष्ट किया जाता है, जहाँ 72 पॉइंट एक इंच के बराबर होते हैं। ऊर्ध्वाधर स्थितियों को बाएँ किनारे से तथा क्षैतिज स्थितियों को ऊपर के किनारे से मापा जाता है।

**क्या ड्रॉइंग गाइड्स को साफ़ करने से आकृतियां हटती हैं या स्लाइड सामग्री बदलती है?**  
नहीं। [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idrawingguidescollection/#clear--) मेथड केवल चयनित कलेक्शन में मौजूद गाइड्स को हटाता है। आकृतियां और अन्य स्लाइड सामग्री अपरिवर्तित रहती हैं।