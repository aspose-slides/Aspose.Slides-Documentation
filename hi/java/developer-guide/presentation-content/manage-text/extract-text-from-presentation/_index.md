---
title: जावामें प्रस्तुतियों से उन्नत टेक्स्ट निष्कर्षण
linktitle: टेक्स्ट निकालें
type: docs
weight: 90
url: /hi/java/extract-text-from-presentation/
keywords:
- टेक्स्ट निकालें
- स्लाइड से टेक्स्ट निकालें
- प्रस्तुति से टेक्स्ट निकालें
- PowerPoint से टेक्स्ट निकालें
- OpenDocument से टेक्स्ट निकालें
- PPT से टेक्स्ट निकालें
- PPTX से टेक्स्ट निकालें
- ODP से टेक्स्ट निकालें
- टेक्स्ट पुनः प्राप्त करें
- स्लाइड से टेक्स्ट पुनः प्राप्त करें
- प्रस्तुति से टेक्स्ट पुनः प्राप्त करें
- PowerPoint से टेक्स्ट पुनः प्राप्त करें
- OpenDocument से टेक्स्ट पुनः प्राप्त करें
- PPT से टेक्स्ट पुनः प्राप्त करें
- PPTX से टेक्स्ट पुनः प्राप्त करें
- ODP से टेक्स्ट पुनः प्राप्त करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों से तेज़ी से टेक्स्ट निकालें। समय बचाने के लिए हमारा सरल, चरण‑बद्ध मार्गदर्शन पालन करें।"
---
## **अवलोकन**

Presentations से टेक्स्ट निकालना डेवलपर्स के लिए एक सामान्य लेकिन आवश्यक काम है जो स्लाइड सामग्री के साथ काम करते हैं। चाहे आप Microsoft PowerPoint फ़ाइलों (PPT या PPTX फ़ॉर्मेट) के साथ काम कर रहे हों, या OpenDocument प्रस्तुतियों (ODP) के साथ, टेक्स्ट डेटा तक पहुँचना और उसे निकालना विश्लेषण, ऑटोमेशन, इंडेक्सिंग, या कंटेंट माइग्रेशन जैसे उद्देश्यों के लिए महत्वपूर्ण हो सकता है।

यह लेख विभिन्न प्रस्तुति फ़ॉर्मेट्स—PPT, PPTX, और ODP—से कुशलता से टेक्स्ट निकालने के लिए एक व्यापक गाइड प्रदान करता है, जो Aspose.Slides for Java का उपयोग करता है। आप सीखेंगे कि प्रस्तुति तत्वों के माध्यम से व्यवस्थित रूप से कैसे इटररेट करें ताकि आवश्यक टेक्स्ट कंटेंट को सटीक रूप से प्राप्त किया जा सके।

## **एक स्लाइड से टेक्स्ट निकालें**

Aspose.Slides for Java [SlideUtil](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideutil/) क्लास प्रदान करता है। यह क्लास कई ओवरलोडेड स्टैटिक मेथड्स को एक्सपोज़ करती है जो पूरी प्रस्तुति या स्लाइड से सभी टेक्स्ट निकालने के लिए उपयोग होते हैं। प्रस्तुति में एक स्लाइड से टेक्स्ट निकालने के लिए, [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) मेथड का उपयोग करें। यह मेथड पैरामीटर के रूप में [IBaseSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseslide/) प्रकार की ऑब्जेक्ट स्वीकार करता है। चलाने पर, यह मेथड पूरे स्लाइड को टेक्स्ट के लिए स्कैन करता है और [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) प्रकार की ऑब्जेक्ट्स की एक एरे रिटर्न करता है, जिसमें कोई भी टेक्स्ट फ़ॉर्मेटिंग संरक्षित रहती है।

निम्न कोड स्निपेट प्रस्तुति की पहली स्लाइड से सभी टेक्स्ट निकालता है:

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

## **एक प्रस्तुति से टेक्स्ट निकालें**

पूरी प्रस्तुति से टेक्स्ट स्कैन करने के लिए, [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) स्टैटिक मेथड का उपयोग करें, जो [SlideUtil](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideutil/) क्लास द्वारा एक्सपोज़ किया गया है। यह दो पैरामीटर स्वीकार करता है:

1. पहला, एक [IPresentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/) ऑब्जेक्ट जो PowerPoint या OpenDocument प्रस्तुति को दर्शाता है, जिससे टेक्स्ट निकाला जाएगा।
2. दूसरा, एक `boolean` मान जो यह दर्शाता है कि मास्टर स्लाइड्स को टेक्स्ट स्कैन करते समय शामिल किया जाना चाहिए या नहीं।

यह मेथड [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) प्रकार की ऑब्जेक्ट्स की एरे रिटर्न करता है, जिसमें टेक्स्ट फ़ॉर्मेटिंग जानकारी भी शामिल होती है। नीचे दिया गया कोड प्रस्तुति, साथ ही मास्टर स्लाइड्स, से टेक्स्ट और फ़ॉर्मेटिंग विवरण स्कैन करता है।

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

## **वर्गीकृत और तेज़ टेक्स्ट निकासी**

[PresentationFactory](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationfactory/) क्लास भी प्रस्तुतियों से सभी टेक्स्ट निकालने के लिए मेथड्स प्रदान करती है:

```java
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textextractionarrangingmode/) enum आर्ग्युमेंट टेक्स्ट निकासी परिणाम को व्यवस्थित करने के मोड को दर्शाता है और इसे निम्न मानों में सेट किया जा सकता है:

- `Unarranged` - स्लाइड पर उसकी स्थिति को ध्यान में रखे बिना कच्चा टेक्स्ट।
- `Arranged` - टेक्स्ट उसी क्रम में व्यवस्थित होता है जैसा कि स्लाइड पर दिखता है।

यदि गति महत्वपूर्ण हो तो अनअरेन्ज्ड मोड का उपयोग किया जा सकता है; यह एरेन्ज्ड मोड की तुलना में तेज़ होता है।

[IPresentationText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationtext/) प्रस्तुति से निकाले गए कच्चे टेक्स्ट को दर्शाता है। इसका `getSlidesText` मेथड [ISlideText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidetext/) प्रकार की ऑब्जेक्ट्स की एरे रिटर्न करता है। प्रत्येक ऑब्जेक्ट संबंधित स्लाइड के टेक्स्ट को दर्शाता है। [ISlideText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidetext/) प्रकार के ऑब्जेक्ट के पास निम्न मेथड्स होते हैं:

- `getText` - स्लाइड के शैप्स के भीतर का टेक्स्ट।
- `getMasterText` - इस स्लाइड से संबंधित मास्टर स्लाइड के शैप्स के भीतर का टेक्स्ट।
- `getLayoutText` - इस स्लाइड से संबंधित लेआउट स्लाइड के शैप्स के भीतर का टेक्स्ट।
- `getNotesText` - इस स्लाइड से संबंधित नोट्स स्लाइड के शैप्स के भीतर का टेक्स्ट।
- `getCommentsText` - इस स्लाइड से जुड़े कमेंट्स में मौजूद टेक्स्ट।

```java
String presentationPath = "presentation.ppt";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **प्रायः पूछे जाने वाले प्रश्न**

**Aspose.Slides बड़े प्रस्तुतियों को टेक्स्ट निकासी के दौरान कितनी तेज़ी से प्रोसेस करता है?**

Aspose.Slides उच्च प्रदर्शन के लिए ऑप्टिमाइज़्ड है और यहाँ तक कि [बड़ी प्रस्तुतियों](/slides/hi/java/open-presentation/) को भी प्रोसेस कर सकता है, जिससे यह रियल‑टाइम या बल्क प्रोसेसिंग परिदृश्यों के लिए उपयुक्त बनता है।

**क्या Aspose.Slides प्रस्तुतियों में टेबल और चार्ट के भीतर टेक्स्ट निकाल सकता है?**

हां। Aspose.Slides कई स्लाइड तत्वों से टेक्स्ट निकाल सकता है, जिसमें टेबल और चार्ट‑संबंधित ऑब्जेक्ट्स शामिल हैं, ताकि आप सामान्य प्रस्तुति संरचनाओं में टेक्स्ट सामग्री तक पहुँच और उसका विश्लेषण कर सकें।

**क्या प्रस्तुति से टेक्स्ट निकालने के लिए मुझे Aspose.Slides का विशेष लाइसेंस चाहिए?**

आप Aspose.Slides की फ्री ट्रायल संस्करण का उपयोग करके टेक्स्ट निकाल सकते हैं, हालांकि इसमें [कुछ सीमाएँ](/slides/hi/java/licensing/) होंगी, जैसे कि सीमित संख्या में स्लाइड्स को प्रोसेस करना। अनलिमिटेड उपयोग और बड़ी प्रस्तुतियों को संभालने के लिए पूर्ण लाइसेंस खरीदने की सलाह दी जाती है।