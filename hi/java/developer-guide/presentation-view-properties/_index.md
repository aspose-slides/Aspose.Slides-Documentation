---
title: Java में प्रस्तुति दृश्य गुणों को प्राप्त करें और अपडेट करें
linktitle: दृश्य गुण
type: docs
weight: 80
url: /hi/java/presentation-view-properties/
keywords:
- दृश्य गुण
- सामान्य दृश्य
- रूपरेखा सामग्री
- रूपरेखा आइकन
- वर्टिकल स्प्लिटर स्नैप
- एकल दृश्य
- बार स्थिति
- आयाम आकार
- स्वतः समायोजन
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के दृश्य गुणों की खोज करें ताकि PPT, PPTX और ODP स्लाइड्स के फ़ॉर्मेट को अनुकूलित किया जा सके — लेआउट, ज़ूम लेवल और डिस्प्ले सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य में तीन सामग्री क्षेत्रों होते हैं: स्वयं स्लाइड, एक पक्षीय सामग्री क्षेत्र, और एक निचला सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों की स्थिति से संबंधित गुण। यह जानकारी अनुप्रयोग को अपने दृश्य स्थिति को फ़ाइल में सहेजने की अनुमति देती है, ताकि पुनः खोलने पर दृश्य उसी स्थिति में हो जैसे प्रस्तुति को आखिरी बार सहेजा गया था।

विधि [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) को जोड़ा गया है जिससे प्रस्तुति की सामान्य दृश्य गुणों तक पहुंच मिल सके।  

[INormalViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewRestoredProperties) इंटरफ़ेस और उनके उत्तराधिकारी, [SplitterBarStateType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType) एन्नुम को जोड़ा गया है।

## **INormalViewProperties के बारे में**

सामान्य दृश्य गुणों का प्रतिनिधित्व करता है।

विधाएँ [getShowOutlineIcons](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) और [setShowOutlineIcons](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) यह निर्दिष्ट करती हैं कि सामान्य दृश्य मोड में किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री प्रदर्शित करते समय अनुप्रयोग को आइकन दिखाने चाहिए या नहीं।

विधाएँ [getSnapVerticalSplitter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) और [setSnapVerticalSplitter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) यह निर्दिष्ट करती हैं कि साइड क्षेत्र पर्याप्त छोटा होने पर वर्टिकल स्प्लिटर को न्यूनतम स्थिति में स्नैप करना चाहिए या नहीं।

गुण [getPreferSingleView](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) और [setPreferSingleView](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--) यह निर्दिष्ट करता है कि उपयोगकर्ता मानक तीन सामग्री क्षेत्रों वाले सामान्य दृश्य के बजाय पूर्ण‑खिड़की एकल‑सामग्री क्षेत्र देखना पसंद करता है या नहीं। यदि सक्रिय किया गया, तो अनुप्रयोग पूरे विंडो में किसी एक सामग्री क्षेत्र को प्रदर्शित कर सकता है।

विधियाँ [getVerticalBarState](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) यह निर्धारित करती हैं कि क्षैतिज या लंबवत स्प्लिटर बार किस स्थिति में दिखाया जाना चाहिए। एक क्षैतिज स्प्लिटर बार स्लाइड को स्लाइड के नीचे की सामग्री क्षेत्र से अलग करता है, लंबवत स्प्लिटर बार स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभावित मान हैं: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType#Maximized) और [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType#Restored)।

विधियाँ [getRestoredLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) और [getRestoredTop](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) यह निर्दिष्ट करती हैं कि सामान्य दृश्य में शीर्ष या साइड स्लाइड क्षेत्र का आकार क्या होना चाहिए, जब [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType#Restored) मान को [getVerticalBarState](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) के लिए लागू किया जाता है।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

सामान्य दृश्य में स्लाइड क्षेत्र (चौड़ाई जब यह [getRestoredTop](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) का बच्चा हो, ऊँचाई जब यह [getRestoredLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) का बच्चा हो) के आकार को निर्दिष्ट करता है, जब क्षेत्र का पुनर्स्थापित आकार परिवर्ती हो (न तो न्यूनतम और न अधिकतम)।

विधि [getDimensionSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) स्लाइड क्षेत्र (चौड़ाई जब यह restoredTop का बच्चा हो, ऊँचाई जब यह restoredLeft का बच्चा हो) का आकार निर्दिष्ट करती है।

विधि [getAutoAdjust](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) यह निर्धारित करती है कि जब अनुप्रयोग में दृश्य वाली विंडो का आकार बदलते हैं तो साइड सामग्री क्षेत्र का आकार नई स्थिति के अनुसार समायोजित होना चाहिए या नहीं।

नीचे एक उदाहरण दिया गया है जो दर्शाता है कि आप प्रस्तुति के लिए [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) गुणों तक कैसे पहुँच सकते हैं।

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // प्रस्तुति के दृश्य गुणों को पुनर्स्थापित करें
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

{{% alert color="info" %}} 
Aspose.Slides for Java अब प्रस्तुति के लिए डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है जिससे प्रस्तुति खोलने पर ज़ूम पहले से ही सेट हो जाता है। यह प्रस्तुति की [ViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties) को सेट करके किया जा सकता है। [getSlideViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) तथा [getNotesViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) को प्रोग्रामेटिक रूप से सेट किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ दिखाएंगे कि Aspose.Slides में [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties) कैसे सेट करें।
{{% /alert %}} 

दृश्य गुण सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएं।
1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties) सेट करें।
1. प्रस्तुति को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।
   नीचे दिए गए उदाहरण में, हमने स्लाइड दृश्य और नोट्स दृश्य दोनों के लिए ज़ूम मान सेट किया है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // प्रस्तुति के दृश्य गुण सेट करना
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // स्लाइड दृश्य के लिए प्रतिशत में ज़ूम मान
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // नोट्स दृश्य के लिए प्रतिशत में ज़ूम मान 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ग्रिड स्पेसिंग सेट करें**

[Presentation.getViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getViewProperties--) का उपयोग करके प्रस्तुति‑व्यापी दृश्य सेटिंग्स तक पहुंचें। [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iviewproperties/#getGridSpacing--) और [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) विधियाँ आधारभूत संपादन ग्रिड के अंतराल को पढ़ती या बदलती हैं। यह सेटिंग पूरी प्रस्तुति पर लागू होती है, न कि व्यक्तिगत स्लाइड पर। ग्रिड स्पेसिंग पॉइंट्स में निर्दिष्ट की जाती है, जहाँ 72 पॉइंट्स एक इंच के बराबर होते हैं। API दस्तावेज़ के अनुसार एक धनात्मक मान का उपयोग करें।

निम्नलिखित उदाहरण एक मौज़ूद `demo.pptx` खोलता है, उसकी वर्तमान ग्रिड स्पेसिंग को प्रिंट करता है, एक चौथाई इंच का अंतराल सेट करता है, और परिणाम को सहेजता है।

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ग्रिड [ड्राइंग गाइड्स](/slides/hi/java/drawing-guides/) से अलग है। ग्रिड स्पेसिंग एक नियमित अंतराल को नियंत्रित करती है, जबकि ड्राइंग गाइड्स व्यक्तिगत रूप से स्थित क्षैतिज या लंबवत संरेखण रेखाएँ होती हैं। ड्राइंग गाइड्स को जोड़ना, चलाना या साफ़ करना ग्रिड स्पेसिंग को नहीं बदलता।

ग्रिड और ड्राइंग गाइड दोनों ही संपादन सहायता हैं। इन्हें PDF, छवियों, SVG, या स्लाइडशो में स्लाइड सामग्री के रूप में प्रदर्शित नहीं किया जाता। ग्रिड स्पेसिंग को संग्रहीत करने से यह सुनिश्चित नहीं होता कि संपादक ग्रिड दिखाएगा: इसकी दृश्यता दर्शक या संपादक की पसंद पर भी निर्भर करती है।

## **FAQ**

**मैं प्रस्तुति पुनः खोलने के बाद ग्रिड क्यों नहीं देख पा रहा हूँ?**  
फ़ाइल ग्रिड स्पेसिंग को संग्रहीत करती है, लेकिन यह संपादक तय करता है कि ग्रिड दिखाया जाए या नहीं। संपादक की ग्रिड दृश्यता सेटिंग्स की जाँच करें।

**क्या ड्राइंग गाइड्स को साफ़ करने से ग्रिड स्पेसिंग बदलती है?**  
नहीं। ड्राइंग गाइड्स और ग्रिड स्पेसिंग स्वतंत्र सेटिंग्स हैं। गाइड्स को साफ़ करने से संग्रहीत ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या मैं प्रस्तुति के विभिन्न अनुभागों के लिए अलग-अलग दृश्य सेटिंग्स सेट कर सकता हूँ?**  
दृश्य सेटिंग्स प्रस्तुति स्तर पर निर्धारित की जाती हैं (Normal View/Slide View), न कि प्रत्येक अनुभाग के अनुसार, इसलिए जब दस्तावेज़ खुलता है तो एक ही पैरामीटर सेट पूरे दस्तावेज़ पर लागू होता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग-अलग दृश्य स्थितियों को पहले से निर्धारित कर सकता हूँ?**  
नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और साझा रहती हैं। दर्शक अनुप्रयोग उपयोगकर्ता की प्राथमिकताओं को मान सकते हैं, लेकिन फ़ाइल स्वयं केवल एक सेट दृश्य गुणों को समेटे होती है।

**क्या मैं पूर्वनिर्धारित View Properties के साथ एक टेम्प्लेट तैयार कर सकता हूँ ताकि नई प्रस्तुतियों का खुलना समान हो?**  
हां। क्योंकि view properties प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें टेम्प्लेट में एम्बेड कर सकते हैं और उससे नई दस्तावेज़ों को उसी प्रारंभिक दृश्य कॉन्फ़िगरेशन के साथ बना सकते हैं।