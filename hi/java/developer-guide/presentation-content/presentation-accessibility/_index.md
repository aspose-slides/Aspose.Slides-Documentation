---
title: जावा में प्रस्तुति एक्सेसिबिलिटी प्रबंधित करें
linktitle: प्रस्तुति एक्सेसिबिलिटी
type: docs
weight: 30
url: /hi/java/presentation-accessibility/
keywords:
- प्रस्तुति एक्सेसिबिलिटी
- वैकल्पिक पाठ
- वैकल्पिक पाठ शीर्षक
- वैकल्पिक पाठ विवरण
- डेकोरेटिव के रूप में चिन्हित करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "जानें कि Aspose.Slides for Java कैसे PPT, PPTX और ODP फ़ाइलों में प्रस्तुति एक्सेसिबिलिटी जांच को स्वचालित करने में मदद करता है—स्क्रीन रीडर अनुभव को बेहतर बनाता है और अनुपालन को बढ़ाता है।"
---
## **परिचय**

वैकल्पिक पाठ उन लोगों को मदद करता है जो सहायक तकनीकों का उपयोग करते हैं, जिससे वे छवियों, charts, और अन्य सूचनात्मक आकृतियों का अर्थ समझ सकें। यह लेख बताता है कि Aspose.Slides for Java के साथ वैकल्पिक टेक्स्ट शीर्षक और विवरण कैसे पढ़ें और अपडेट करें, कोड में उपयोग किए गए shape नामों से accessibility विवरण को कैसे अलग करें, और यह जाँचें कि कोई shape सजावटी के रूप में चिह्नित है या नहीं।

ये सुविधाएँ प्रस्तुति की accessibility को समर्थन देती हैं, लेकिन इसकी गारंटी नहीं देतीं। पढ़ने का क्रम, रंग का कंट्रास्ट, टेक्स्ट की पठनीयता, और अन्य accessibility आवश्यकताओं की भी समीक्षा आवश्यक है।

## **वैकल्पिक पाठ शीर्षक और विवरण प्रबंधित करें**

वैकल्पिक पाठ का उपयोग उन लोगों को छवियों, charts, और अन्य सूचनात्मक आकृतियों का मतलब समझाने के लिए करें जो उन्हें देख नहीं सकते। निम्नलिखित विधियाँ और सामग्री अलग‑अलग उद्देश्यों के लिये हैं:

| विधि या सामग्री | उद्देश्य |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getAlternativeTextTitle--) | वैकल्पिक विवरण के लिए एक संक्षिप्त शीर्षक। |
| [getAlternativeText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getAlternativeText--) | स्लाइड के संदर्भ में shape की सामग्री या उद्देश्य का अर्थपूर्ण विवरण। |
| [getName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getName--) | shape का नाम, जिसे कोड प्रस्तुति में विशिष्ट shape को खोजने के लिये उपयोग कर सकता है। |
| Visible text | स्लाइड पर प्रदर्शित सामग्री, जैसे shape का टेक्स्ट या chart का शीर्षक और लेबल। वैकल्पिक पाठ को अपडेट करने से यह सामग्री नहीं बदलती। |

जब कोई प्रस्तुति टेम्पलेट के रूप में पुनः उपयोग की जाती है, तो कोड [getName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getName--) द्वारा लौटाए गए नाम से shape को खोज सकता है और फिर उसे अपडेट कर सकता है। यह नाम वैकल्पिक पाठ से अलग उद्देश्य रखता है, जो पाठक को दृश्य द्वारा संप्रेषित अर्थ समझाता है। नाम द्वारा खोजने से लेखक बिना कोड के shape खोजने के तरीके को बदले वर्णन सुधार या अनुवाद कर सकते हैं। नाम संपादित किए जा सकते हैं और अनन्य होने की गारंटी नहीं है, इसलिए सुनिश्चित करें कि नाम इच्छित shape से मेल खाता हो; देखें [शेप्स की पहचान और खोज](/slides/hi/java/shape-manipulations/#identify-and-find-shapes)।

निम्नलिखित उदाहरण को `input.pptx` की आवश्यकता है जिसमें पहले स्लाइड पर पहला shape एक office entrance की छवि हो। वह छवि सजावटी के रूप में चिह्नित नहीं होनी चाहिए। उदाहरण वर्तमान वैकल्पिक पाठ शीर्षक और विवरण पढ़ता है, दोनों मानों को अपडेट करता है, और प्रस्तुति को `output.pptx` के रूप में सहेजता है। वास्तविक छवि और उसके द्वारा संप्रेषित जानकारी के अनुसार शब्दांकन को अनुकूलित करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    System.out.println("Alternative text title: " + shape.getAlternativeTextTitle());
    System.out.println("Alternative text description: " + shape.getAlternativeText());

    shape.setAlternativeTextTitle("Office entrance");
    shape.setAlternativeText("The office entrance has a wheelchair ramp to the right of the steps.");

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

केवल वैकल्पिक पाठ जोड़ने से प्रस्तुति की accessibility या accessibility मानकों के अनुरूपता की गारंटी नहीं मिलती। विवरणों की शुद्धता और प्रासंगिकता की समीक्षा करें, साथ ही पढ़ने का क्रम, रंग कंट्रास्ट, पठनीय टेक्स्ट, और अन्य accessibility आवश्यकताओं की भी जांच करें। सूचनात्मक दृश्य को सजावटी के रूप में चिह्नित नहीं किया जाना चाहिए; अगला भाग दिखाता है कि कैसे [isDecorative](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#isDecorative--) जाँचें।

## **डेकोरेटिव के रूप में चिह्नित करें**

डेकोरेटिव के रूप में चिह्नित करने से केवल सजावटी दृश्य को स्क्रीन रीडर द्वारा छोड़ दिया जाता है, जिससे शोर कम होता है और अर्थपूर्ण सामग्री पर ध्यान केंद्रित रहता है। इसे पृष्ठभूमियों, अलंकरण और spacers पर लागू करें—कभी भी charts, icons, या ऐसी छवियों पर नहीं जिनमें सूचना होती है। Aspose.Slides इस फ़्लैग को पहचान और वैधता के लिये उजागर करता है, जिससे स्वचालित accessibility जाँच और सफाई संभव होती है।

![डेकोरेटिव के रूप में चिह्नित](mark_as_decorative.png)

निम्नलिखित कोड नमूना दर्शाता है कि कैसे पता करें कि कोई shape डेकोरेटिव के रूप में चिह्नित है या नहीं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**वैकल्पिक पाठ शीर्षक और विवरण में मुझे क्या रखना चाहिए?**

विषय की पहचान के लिये एक संक्षिप्त शीर्षक और स्लाइड के संदर्भ में दृश्य द्वारा संप्रेषित जानकारी समझाने हेतु एक विवरण उपयोग करें। एक chart के लिये, केवल “chart” कहने के बजाय प्रासंगिक प्रवृत्ति या तुलना का वर्णन करें।

**क्या मुझे टेम्पलेट में shape खोजने के लिये वैकल्पिक पाठ का उपयोग करना चाहिए?**

shape को खोजने के लिये उस नाम का उपयोग करना पसंद करें जो [getName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getName--) लौटाता है और सुनिश्चित करें कि वह अपेक्षित shape है। वैकल्पिक पाठ संपादित या अनूदित किया जा सकता है, जिससे कोड जो सटीक विवरण खोजता है टूट सकता है; देखें [शेप्स की पहचान और खोज](/slides/hi/java/shape-manipulations/)।

**किस स्थिति में shape को डेकोरेटिव के रूप में चिह्नित किया जाना चाहिए?**

उन दृश्यों के लिये डेकोरेटिव फ़्लैग उपयोग करें जो कोई जानकारी नहीं जोड़ते, जैसे अलंकरणीय सजावट। जानकारी संप्रेषित करने वाली छवियों और charts को उचित विवरण की आवश्यकता होती है।

**क्या वैकल्पिक पाठ जोड़ने से प्रस्तुति पूरी तरह से सुलभ बन जाती है?**

नहीं। वैकल्पिक पाठ केवल accessibility का एक भाग ही संबोधित करता है। पढ़ने का क्रम, रंग कंट्रास्ट, टेक्स्ट की पठनीयता, और अन्य संबंधित आवश्यकताओं की भी समीक्षा करें; केवल इन गुणों को सेट करने से अनुपालन स्थापित नहीं होता।