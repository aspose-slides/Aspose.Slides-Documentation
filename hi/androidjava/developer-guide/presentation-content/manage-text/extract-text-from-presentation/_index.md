---
title: एंड्रॉइड पर प्रस्तुतियों से उन्नत टेक्स्ट निष्कर्षण
linktitle: टेक्स्ट निकालें
type: docs
weight: 90
url: /hi/androidjava/extract-text-from-presentation/
keywords:
- टेक्स्ट निकालें
- स्लाइड से टेक्स्ट निकालें
- प्रेजेंटेशन से टेक्स्ट निकालें
- PowerPoint से टेक्स्ट निकालें
- OpenDocument से टेक्स्ट निकालें
- PPT से टेक्स्ट निकालें
- PPTX से टेक्स्ट निकालें
- ODP से टेक्स्ट निकालें
- टेक्स्ट पुनः प्राप्त करें
- स्लाइड से टेक्स्ट पुनः प्राप्त करें
- प्रेजेंटेशन से टेक्स्ट पुनः प्राप्त करें
- PowerPoint से टेक्स्ट पुनः प्राप्त करें
- OpenDocument से टेक्स्ट पुनः प्राप्त करें
- PPT से टेक्स्ट पुनः प्राप्त करें
- PPTX से टेक्स्ट पुनः प्राप्त करें
- ODP से टेक्स्ट पुनः प्राप्त करें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों से जल्दी से टेक्स्ट निकालें। समय बचाने के लिए हमारी सरल, चरणबद्ध गाइड का पालन करें।"
---
## **अवलोकन**

प्रेजेंटेशन से टेक्स्ट निकालना स्लाइड सामग्री के साथ काम करने वाले डेवलपर्स के लिए आम लेकिन आवश्यक कार्य है। चाहे आप Microsoft PowerPoint फ़ाइलें PPT या PPTX फॉर्मेट में, या OpenDocument प्रेजेंटेशन (ODP) के साथ काम कर रहे हों, टेक्स्ट डेटा को एक्सेस करना और पुनः प्राप्त करना विश्लेषण, ऑटोमेशन, इंडेक्सिंग, या कंटेंट माइग्रेशन उद्देश्यों के लिए महत्वपूर्ण हो सकता है।

यह लेख विभिन्न प्रेजेंटेशन फॉर्मेट्स—PPT, PPTX, और ODP—से टेक्स्ट को प्रभावी ढंग से निकालने के बारे में एक व्यापक गाइड प्रदान करता है, Aspose.Slides for Android via Java का उपयोग करके। आप सीखेंगे कि प्रेजेंटेशन तत्वों के माध्यम से व्यवस्थित रूप से इटरेट करके आवश्यक टेक्स्ट कंटेंट को सही तरीके से कैसे प्राप्त किया जाए।

## **स्लाइड से टेक्स्ट निकालें**

Aspose.Slides for Android via Java [SlideUtil](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideutil/) क्लास प्रदान करता है। यह क्लास प्रेजेंटेशन या स्लाइड से सभी टेक्स्ट निकालने के लिए कई ओवरलोडेड स्टेटिक मेथड्स को एक्सपोज़ करती है। किसी प्रेजेंटेशन में स्लाइड से टेक्स्ट निकालने के लिए, आप [getAllTextBoxes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) मेथड का उपयोग कर सकते हैं। यह मेथड पैरामीटर के रूप में [IBaseSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseslide/) की एक ऑब्जेक्ट को स्वीकार करता है। निष्पादित होने पर, यह मेथड पूरे स्लाइड में टेक्स्ट स्कैन करता है और [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) प्रकार की ऑब्जेक्ट्स की एक एरे लौटाता है, जिसमें कोई भी टेक्स्ट फ़ॉर्मेटिंग संरक्षित रहती है।

निम्नलिखित कोड स्निपेट प्रेजेंटेशन की पहली स्लाइड से सभी टेक्स्ट निकालता है:

```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **प्रस्तुति से टेक्स्ट निकालें**

पूरी प्रेजेंटेशन से टेक्स्ट स्कैन करने के लिए, आप [SlideUtil](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideutil/) क्लास द्वारा एक्सपोज़ किए गए स्टेटिक मेथड [getAllTextFrames](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) का उपयोग कर सकते हैं। यह दो पैरामीटर स्वीकार करता है:

1. पहला, एक [IPresentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/) ऑब्जेक्ट जो वह PowerPoint या OpenDocument प्रेजेंटेशन दर्शाता है जिससे टेक्स्ट निकाला जाएगा।
2. दूसरा, एक `boolean` मान जो यह संकेत देता है कि टेक्स्ट स्कैन करते समय मास्टर स्लाइड्स को शामिल किया जाना चाहिए या नहीं।

यह मेथड [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) प्रकार की ऑब्जेक्ट्स की एरे लौटाता है, जिसमें टेक्स्ट फ़ॉर्मेटिंग जानकारी भी शामिल होती है। नीचे दिया गया कोड प्रेजेंटेशन और उसके मास्टर स्लाइड्स से टेक्स्ट और फ़ॉर्मेटिंग विवरण स्कैन करता है।

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **वर्गीकृत और तेज़ टेक्स्ट निष्कर्षण**

[PresentationFactory](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationfactory/) क्लास भी प्रेजेंटेशनों से सभी टेक्स्ट निकालने के लिए मेथड्स प्रदान करता है:

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textextractionarrangingmode/) एनोम आर्ग्यूमेंट टेक्स्ट निष्कर्षण परिणाम को व्यवस्थित करने के मोड को दर्शाता है और निम्नलिखित मानों में सेट किया जा सकता है:
- `Unarranged` - स्लाइड पर उसकी स्थिति की परवाह किए बिना कच्चा टेक्स्ट।
- `Arranged` - टेक्स्ट स्लाइड पर जैसी क्रम में है, उसी क्रम में व्यवस्थित है।

जब गति महत्वपूर्ण हो तो अनअरेन्ज़्ड मोड का उपयोग किया जा सकता है; यह एरेन्ज़्ड मोड की तुलना में तेज़ है।

[IPresentationText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationtext/) प्रेजेंटेशन से निकाले गए कच्चे टेक्स्ट को दर्शाता है। इसका `getSlidesText` मेथड [ISlideText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidetext/) प्रकार की ऑब्जेक्ट्स की एरे लौटाता है। प्रत्येक ऑब्जेक्ट संबंधित स्लाइड पर मौजूद टेक्स्ट को दर्शाता है। [ISlideText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidetext/) प्रकार की ऑब्जेक्ट में निम्नलिखित मेथड्स होते हैं:

- `getText` - स्लाइड के शेप्स के भीतर का टेक्स्ट।
- `getMasterText` - इस स्लाइड से जुड़े मास्टर स्लाइड के शेप्स के भीतर का टेक्स्ट।
- `getLayoutText` - इस स्लाइड से जुड़े लेआउट स्लाइड के शेप्स के भीतर का टेक्स्ट।
- `getNotesText` - इस स्लाइड से जुड़े नोट्स स्लाइड के शेप्स के भीतर का टेक्स्ट।
- `getCommentsText` - इस स्लाइड से जुड़े कमेंट्स के भीतर का टेक्स्ट।

```java
String presentationPath = "presentation.pptx";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **FAQ**

**टेक्स्ट निष्कर्षण के दौरान Aspose.Slides बड़े प्रस्तुतियों को कितनी तेज़ी से प्रोसेस करता है?**

Aspose.Slides उच्च प्रदर्शन के लिए अनुकूलित है और यहाँ तक कि [large presentations](/slides/hi/androidjava/open-presentation/) को प्रोसेस कर सकता है, जिससे यह वास्तविक‑समय या बल्क प्रोसेसिंग स्थितियों के लिए उपयुक्त है।

**क्या Aspose.Slides प्रस्तुतियों के भीतर तालिकाओं और चार्ट से टेक्स्ट निकाल सकता है?**

हाँ। Aspose.Slides कई स्लाइड तत्वों, जिसमें टेबल और चार्ट‑सेटेड ऑब्जेक्ट्स शामिल हैं, से टेक्स्ट निकाल सकता है, ताकि आप सामान्य प्रेजेंटेशन संरचनाओं में टेक्स्ट सामग्री तक पहुँच और उसका विश्लेषण कर सकें।

**क्या प्रस्तुतियों से टेक्स्ट निकालने के लिए मुझे विशेष Aspose.Slides लाइसेंस की आवश्यकता है?**

आप Aspose.Slides के मुफ्त ट्रायल संस्करण का उपयोग करके टेक्स्ट निकाल सकते हैं, हालांकि इसमें [certain limitations](/slides/hi/androidjava/licensing/) होंगी, जैसे कि सीमित संख्या में स्लाइड्स को प्रोसेस करना। असीमित उपयोग और बड़े प्रस्तुतियों को संभालने के लिए पूर्ण लाइसेंस खरीदने की सलाह दी जाती है।