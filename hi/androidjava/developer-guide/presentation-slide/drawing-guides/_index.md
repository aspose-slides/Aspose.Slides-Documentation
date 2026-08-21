---
title: एन्ड्रॉइड पर प्रस्तुतियों में ड्राइंग गाइड प्रबंधित करें
linktitle: ड्राइंग गाइड
type: docs
weight: 85
url: /hi/androidjava/drawing-guides/
keywords:
- ड्राइंग गाइड
- क्षैतिज गाइड
- लंबवत गाइड
- संरेखण गाइड
- स्लाइड दृश्य
- मास्टर स्लाइड
- लेआउट स्लाइड
- नोट्स मास्टर
- हैंडआउट मास्टर
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint प्रस्तुतियों में क्षैतिज और लंबवत ड्राइंग गाइड जोड़ें, एक्सेस करें और साफ़ करें।"
---
## **अवलोकन**

ड्राइंग गाइड समायोज्य क्षैतिज और लंबवत रेखाएँ हैं जो उपयोगकर्ताओं को PowerPoint में प्रस्तुति संपादित करते समय आकृतियों को सुसंगत रूप से संरेखित करने में मदद करती हैं। ये विशेष रूप से तब उपयोगी होते हैं जब कोई अनुप्रयोग प्रस्तुति बनाता है जिसे बाद में मैन्युअल रूप से सुधारा जाएगा: अनुप्रयोग समान संरेखण सहायक को सहेज सकता है जिन्हें लेखकों को सामग्री जोड़ते या स्थानांतरित करते समय अनुसरण करना चाहिए।

ड्राइंग गाइड संपादन सहायता हैं, स्लाइड सामग्री नहीं। ये स्लाइड शो या रेंडर किए गए आउटपुट में दिखाई नहीं देते। Aspose.Slides for Android via Java इन्हें [IDrawingGuidesCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idrawingguidescollection/) इंटरफ़ेस के माध्यम से प्रस्तुत करता है। एक गाइड को [IDrawingGuide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idrawingguide/) द्वारा दर्शाया जाता है और इसमें अभिमुखता, स्थिति और रंग होते हैं।

स्थिति संबंधित स्लाइड या मास्टर के ऊपर‑बाएँ कोने से पॉइंट्स में मापी जाती है। एक लंबवत गाइड एक क्षैतिज निर्देशांक का उपयोग करता है, आमतौर पर शून्य से स्लाइड की चौड़ाई के बीच। एक क्षैतिज गाइड एक लंबवत निर्देशांक का उपयोग करता है, आमतौर पर शून्य से स्लाइड की ऊँचाई के बीच।

## **स्लाइड व्यू में गाइड जोड़ें**

सामान्य स्लाइड्स को संपादित करते समय प्रदर्शित गाइड्स को प्रबंधित करने के लिए [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) का उपयोग करें। फिर [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) को एक [Orientation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/orientation/) मान और पॉइंट्स में स्थिति के साथ कॉल करें।

निम्नलिखित उदाहरण स्लाइड के केंद्र के दाएँ एक लंबवत गाइड और उसके नीचे एक क्षैतिज गाइड जोड़ता है:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ड्राइंग गाइड तक पहुंचें**

[IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) और [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int--) मेथड मौजूद गाइड्स तक पहुंच प्रदान करते हैं। [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idrawingguide/#getPosition--), और [IDrawingGuide.getColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idrawingguide/#getColor--) मेथड मान लौटाते हैं जिन्हें संबंधित सेट्टर मेथड्स द्वारा भी बदला जा सकता है।

निम्नलिखित उदाहरण ऊपर निर्मित प्रस्तुति से स्लाइड‑व्यू गाइड पढ़ता है:

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

## **मास्टर और लेआउट स्लाइड्स में गाइड जोड़ें**

एक स्लाइड मास्टर और उसके प्रत्येक लेआउट स्लाइड के पास अपनी ड्राइंग‑गाइड कलेक्शन हो सकता है। मास्टर स्लाइड के लिए [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) और लेआउट स्लाइड के लिए [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) का उपयोग करें।

निम्नलिखित उदाहरण पहले मास्टर स्लाइड में एक लंबवत गाइड और पहले लेआउट स्लाइड में एक क्षैतिज गाइड जोड़ता है:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **नोट्स और हैंडआउट मास्टर्स में गाइड जोड़ें**

नोट्स मास्टर और हैंडआउट मास्टर भी ड्राइंग गाइड का समर्थन करते हैं। उनकी कलेक्शन तक पहुंचने के लिए [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) तथा [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) का उपयोग करें। यदि प्रस्तुति में इनमें से कोई मास्टर नहीं है, तो [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) या [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) डिफ़ॉल्ट मास्टर बनाते हैं और उसे लौटाते हैं।

निम्नलिखित उदाहरण नोट्स मास्टर में एक क्षैतिज गाइड और हैंडआउट मास्टर में एक लंबवत गाइड जोड़ता है:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ड्राइंग गाइड साफ़ करें**

किसी विशेष कलेक्शन से सभी गाइड हटाने के लिए [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) को कॉल करें। एक कलेक्शन को साफ़ करने से अन्य स्कोप में संग्रहीत गाइड प्रभावित नहीं होते।

निम्नलिखित उदाहरण स्लाइड‑व्यू गाइड तथा स्लाइड मास्टर, लेआउट स्लाइड, नोट्स मास्टर और हैंडआउट मास्टर पर सभी गाइड को बिना अनुपस्थित मास्टर बनाए साफ़ करता है:

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

**क्या ड्राइंग गाइड स्लाइड शो या निर्यातित छवियों में प्रदर्शित होते हैं?**

नहीं। ड्राइंग गाइड संपादन के लिए संरेखण सहायक हैं और प्रस्तुति सामग्री के रूप में रेंडर नहीं किए जाते।

**क्या एक ड्राइंग गाइड को सीधे व्यक्तिगत सामान्य स्लाइड में जोड़ा जा सकता है?**

सामान्य स्लाइड संपादन गाइड प्रस्तुति की स्लाइड‑व्यू प्रॉपर्टीज़ में संग्रहीत होते हैं। स्लाइड मास्टर, लेआउट स्लाइड, नोट्स मास्टर, और हैंडआउट मास्टर के लिए अलग गाइड कलेक्शन उपलब्ध हैं।

**गाइड स्थितियों के लिए कौन-से इकाइयों का उपयोग किया जाता है?**

स्थिति पॉइंट्स में निर्दिष्ट की जाती है, जहां 72 पॉइंट्स एक इंच के बराबर होते हैं। लंबवत स्थितियों को बाएँ किनारे से और क्षैतिज स्थितियों को ऊपर के किनारे से मापा जाता है।

**क्या ड्राइंग गाइड साफ़ करने से आकार हटते हैं या स्लाइड सामग्री बदलती है?**

नहीं। [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) मेथड केवल चयनित कलेक्शन में गाइड को हटाता है। आकार तथा अन्य स्लाइड सामग्री अपरिवर्तित रहती है।