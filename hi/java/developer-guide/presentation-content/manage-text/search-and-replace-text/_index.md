---
title: Java में PowerPoint प्रस्तुतियों में टेक्स्ट की खोज और प्रतिस्थापन
linktitle: खोज और प्रतिस्थापन टेक्स्ट
type: docs
weight: 55
url: /hi/java/search-and-replace-text/
keywords:
- टेक्स्ट खोज
- टेक्स्ट हाइलाइट
- टेक्स्ट बदलें
- नियमित अभिव्यक्ति
- परिणाम कॉलबैक
- टेक्स्ट फ्रेम
- ऑडिट रिपोर्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ प्रत्येक मैच को एकत्र करते हुए PowerPoint प्रस्तुतियों में टेक्स्ट को खोजें, हाइलाइट करें और बदलें।"
---
## **अवलोकन**

Aspose.Slides for Java एकल टेक्स्ट फ्रेम या पूरे प्रेजेंटेशन में टेक्स्ट को खोजने, हाइलाइट करने और बदलने में सक्षम है। प्रत्येक ऑपरेशन प्रत्येक मैच के बारे में परिणाम कॉलबैक के माध्यम से एप्लिकेशन को सूचित भी कर सकता है। इससे प्रेजेंटेशन को अपडेट करना और समानांतर में मैच किए गए टेक्स्ट, उसका संदर्भ, स्थिति, टेक्स्ट फ्रेम और स्लाइड नंबर सहित ऑडिट ट्रेल बनाना संभव हो जाता है।

ये क्षमताएँ रिव्यू, रिडैक्शन, शब्दावली जाँच, टेम्पलेट सफाई और स्वचालित रिपोर्टिंग वर्कफ़्लो के लिए उपयोगी हैं।

नीचे पहले उदाहरणों में, हम "sample.pptx" नामक फ़ाइल का उपयोग करते हैं, जिसमें पहली स्लाइड पर एकल टेक्स्ट बॉक्स में निम्नलिखित टेक्स्ट होता है:

![नमूना पाठ](sample_text.png)

## **खोज सीमा चुनें**

[ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) पर उपलब्ध मेथड्स का उपयोग करके ऑपरेशन को एक टेक्स्ट फ्रेम तक सीमित करें। [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) पर उपलब्ध मेथड्स का उपयोग करके प्रेजेंटेशन में सभी लागू टेक्स्ट को प्रोसेस करें।

| ऑपरेशन | एक टेक्स्ट फ्रेम | पूरे प्रेजेंटेशन |
|---|---|---|
| Highlight literal text | [ITextFrame.highlightText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular‑expression matches | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [ITextFrame.replaceText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular‑expression matches | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **टेक्स्ट मिलान कॉन्फ़िगर करें**

Literal‑text ऑपरेशन्स के लिए, मैचिंग को नियंत्रित करने हेतु [TextSearchOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textsearchoptions/) का उपयोग करें:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) मैच को केवल पूर्ण शब्दों तक सीमित करता है।
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) यह नियंत्रित करता है कि अक्षर का केस मेल करना आवश्यक है या नहीं।
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) स्लाइड नोट्स को प्रेजेंटेशन‑स्तर की खोज, बदलाव और हाइलाइट ऑपरेशन्स में शामिल करता है।

Regular‑expression ऑपरेशन्स Java `Pattern` का उपयोग करते हैं, इसलिए केस संवेदनशीलता और शब्द सीमाएँ जैसी नियम अभिव्यक्ति और उसके फ़्लैग्स द्वारा निर्धारित होते हैं।

## **टेक्स्ट फ्रेम के मालिक की पहचान करें**

जनरिक टेक्स्ट‑प्रोसेसिंग वर्कफ़्लो अक्सर खोज, बदलाव, वैधता जाँच या एक्सपोर्ट के दौरान एक [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) प्राप्त करते हैं। वह प्रस्तुति ऑब्जेक्ट जो टेक्स्ट फ्रेम का मालिक है, यह निर्धारित करने के लिए [ITextFrame.getParentShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#getParentShape--) और [ITextFrame.getParentCell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#getParentCell--) का उपयोग करें।

अपेक्षित मान मालिक पर निर्भर करते हैं:

| टेक्स्ट फ्रेम मालिक | `getParentShape` | `getParentCell` |
|---|---|---|
| एक AutoShape या कोई अन्य टेक्स्ट‑समेत शैप | The owning [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) | `null` |
| एक टेबल सेल | `null` | The owning [ICell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icell/) |

दोनों मेथड केवल‑पढ़ने योग्य नेविगेशन प्रदान करते हैं। इन्हें कॉल करने से टेक्स्ट फ्रेम नहीं बदलेगा और न ही उसका मालिक बदल जाएगा। जनरिक कोड को दोनों मानों के `null` होने की जाँच करनी चाहिए और उस स्थिति को संभालना चाहिए जब कोई मालिक उपलब्ध न हो।

निम्न उदाहरण में [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) का उपयोग करके प्रेजेंटेशन के सभी टेक्स्ट फ्रेमों पर इटरिट किया गया है। शैप्स के लिए यह शैप का नाम, Java रन‑टाइम टाइप और शामिल स्लाइड को रिपोर्ट करता है। टेबल सेल्स के लिए यह शून्य‑आधारित कॉलम और रो निर्देशांक तथा सम्मिलित स्लाइड को रिपोर्ट करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, false);

    for (ITextFrame textFrame : textFrames) {
        IShape ownerShape = textFrame.getParentShape();
        if (ownerShape != null) {
            String shapeName = ownerShape.getName().isEmpty() ? "(unnamed)" : ownerShape.getName();
            String shapeType = ownerShape.getClass().getSimpleName();
            IBaseSlide baseSlide = ownerShape.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        ICell ownerCell = textFrame.getParentCell();
        if (ownerCell != null) {
            IBaseSlide baseSlide = ownerCell.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        System.out.println("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

SmartArt कंटेंट के लिए, [ISmartArtNode.getShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ismartartnode/#getShapes--) में शैप्स पर इटरिट करें और प्रत्येक [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ismartartshape/#getTextFrame--) को एक्सेस करें। टेक्स्ट फ्रेम को उसके संबंधित शैप से [ITextFrame.getParentShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#getParentShape--) द्वारा ट्रेस किया जा सकता है, जबकि [ITextFrame.getParentCell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#getParentCell--) `null` लौटाता है। इसलिए, उदाहरण में शैप शाखा SmartArt नोड्स से आने वाले टेक्स्ट को भी संभालती है।

## **कॉलबैक के साथ मेल जानकारी एकत्रित करें**

[IFindResultCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifindresultcallback/) को लागू करके प्रत्येक मैच के लिए सूचना प्राप्त करें। इसका [IFindResultCallback.foundResult](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) मेथड संबंधित टेक्स्ट फ्रेम, स्रोत टेक्स्ट, मैच किया गया टेक्स्ट और मैच की स्थिति प्रदान करता है।

कॉलबैक सीधे स्लाइड नंबर नहीं प्राप्त करता। नीचे दिया गया इम्प्लीमेंटेशन इसे पैरेंट स्लाइड से प्राप्त करता है और साथ ही स्लाइड नोट्स में मिलने वाला टेक्स्ट भी संभालता है। एक nullable `Integer` समान परिणाम मॉडल को अन्य स्लाइड प्रकारों से जुड़े टेक्स्ट को दर्शाने की अनुमति देता है।

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

final class TextMatch {
    private final ITextFrame textFrame;
    private final String sourceText;
    private final String foundText;
    private final int textPosition;
    private final Integer slideNumber;

    TextMatch(ITextFrame textFrame, String sourceText, String foundText, int textPosition, Integer slideNumber) {
        this.textFrame = textFrame;
        this.sourceText = sourceText;
        this.foundText = foundText;
        this.textPosition = textPosition;
        this.slideNumber = slideNumber;
    }

    ITextFrame getTextFrame() {
        return textFrame;
    }

    String getSourceText() {
        return sourceText;
    }

    String getFoundText() {
        return foundText;
    }

    int getTextPosition() {
        return textPosition;
    }

    Integer getSlideNumber() {
        return slideNumber;
    }
}

final class TextSearchCallback implements IFindResultCallback {
    private final List<TextMatch> results = new ArrayList<TextMatch>();

    List<TextMatch> getResults() {
        return results;
    }

    @Override
    public void foundResult(ITextFrame textFrame, String sourceText, String foundText, int textPosition) {
        Integer slideNumber = getSlideNumber(textFrame);
        TextMatch result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);
        results.add(result);
    }

    private Integer getSlideNumber(ITextFrame textFrame) {
        IShape parentShape = textFrame.getParentShape();
        ICell parentCell = textFrame.getParentCell();
        IBaseSlide parentSlide = parentShape != null ? parentShape.getSlide() : parentCell != null ? parentCell.getSlide() : textFrame.getSlide();

        if (parentSlide instanceof ISlide) {
            return ((ISlide) parentSlide).getSlideNumber();
        }

        if (parentSlide instanceof INotesSlide) {
            return ((INotesSlide) parentSlide).getParentSlide().getSlideNumber();
        }

        return null;
    }
}
```

बदलाव ऑपरेशन्स के लिए, `foundText` मूल मैच किए गए टेक्स्ट को रखता है, इसलिए कॉलबैक ठीक‑ठीक रिकॉर्ड कर सकता है कि कौन‑से शब्द बदले गए।

## **टेक्स्ट को हाईलाइट करें**

[ITextFrame.highlightText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) मेथड का उपयोग करके एक टेक्स्ट फ्रेम में literal‑text मैचों को हाईलाइट करें। खोज को नियंत्रित करने के लिए [TextSearchOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textsearchoptions/) पास करें और मैच विवरण एकत्रित करने के लिए एक कॉलबैक प्रदान करें।

नीचे दिया गया कोड उदाहरण सभी **"try"** अक्षरों की उपस्थिति को हाईलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाईलाइट करता है। दोनों खोजें समान कॉलबैक को उनके मैच रिपोर्ट करती हैं।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    Color substringHighlightColor = new Color(173, 216, 230);

    // टेक्स्ट फ्रेम में "try" की प्रत्येक उपस्थिति को हाइलाइट करें।
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // केवल पूर्ण शब्द "to" को हाइलाइट करें।
    shape.getTextFrame().highlightText("to", wholeWordHighlightColor, wholeWordSearchOptions, callback);

    for (TextMatch result : callback.getResults()) {
        System.out.println("Found '" + result.getFoundText() + "' at position " +
                result.getTextPosition() + " on slide " + result.getSlideNumber() + ".");
    }

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![हाइलाइट किया हुआ टेक्स्ट](highlighted_text.png)

## **नियमित अभिव्यक्तियों का उपयोग करके टेक्स्ट को हाईलाइट करें**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) मेथड नियमित अभिव्यक्ति द्वारा पाए गए टेक्स्ट मैचों को एक टेक्स्ट फ्रेम में हाईलाइट करता है।

निम्न कोड सात या अधिक अक्षर वाले सभी शब्दों को हाईलाइट करता है और प्रत्येक मैच को एकत्रित करता है:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    Pattern regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![नियमित अभिव्यक्ति का उपयोग करके हाइलाइट किया हुआ टेक्स्ट](highlighted_text_using_regex.png)

## **प्रेजेंटेशन में टेक्स्ट को हाईलाइट करें**

[Presentation.highlightText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और [Presentation.highlightRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) का उपयोग करके प्रेजेंटेशन के सभी लागू टेक्स्ट फ्रेमों को खोजें। नीचे दिया गया उदाहरण एक literal टर्म और सभी ई‑मेल एड्रेस को हाईलाइट करता है जबकि दो खोजों के लिए अलग‑अलग परिणाम संग्रह रखता है।

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    presentation.highlightText("confidential", Color.ORANGE, searchOptions, termCallback);

    TextSearchCallback emailCallback = new TextSearchCallback();
    Pattern emailRegex = Pattern.compile(
            "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
            Pattern.CASE_INSENSITIVE);

    presentation.highlightRegex(emailRegex, Color.YELLOW, emailCallback);
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट फ्रेम में टेक्स्ट को बदलें**

[ITextFrame.replaceText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) को literal टेक्स्ट के लिए और [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) को पैटर्न‑आधारित बदलाव के लिए उपयोग करें। ये मेथड मौजूदा टेक्स्ट फ्रेम के भीतर मैच किए गए टेक्स्ट को अपडेट करते हैं, जिससे आसपास के हिस्से का फॉर्मेट बरकरार रहता है और पूरी स्ट्रिंग को पुनः निर्मित नहीं करना पड़ता।

निम्न उदाहरण पहले एक स्पेलिंग वैरिएंट को मानकीकृत करता है और फिर संस्करण लेबल को बदलता है। वही कॉलबैक दोनों ऑपरेशन्स द्वारा मैच किए गए मूल शब्दों को रिकॉर्ड करता है।

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText("colour", "color", searchOptions, callback);

    Pattern versionRegex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", callback);

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि किसी एक मैच में विभिन्न फॉर्मेट वाले भाग शामिल हों, तो आउटपुट की जांच करें कि बदलाव वाले टेक्स्ट पर कौन‑सा फॉर्मेट लागू होना चाहिए।

## **प्रेजेंटेशन में टेक्स्ट को बदलें**

[Presentation.replaceText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और [Presentation.replaceRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) का उपयोग करके समान ऑपरेशन पूरे प्रेजेंटेशन पर लागू करें। यह टेम्पलेट सफाई, शब्दावली अपडेट और रिडैक्शन के लिए उपयोगी है।

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText("Contoso", "Example Corp", searchOptions, callback);

    Pattern accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **रिपोर्टिंग के लिए मैच ग्रुप करें**

चूंकि प्रत्येक परिणाम अपना स्लाइड नंबर और टेक्स्ट फ्रेम रखता है, एप्लिकेशन ऑडिट, रिपोर्टिंग या रिव्यू वर्कफ़्लो के लिए मैचों को समूहित कर सकते हैं। नीचे दिया गया उदाहरण पहले स्लाइड के अनुसार और फिर टेक्स्ट फ्रेम के अनुसार एकत्रित परिणामों को समूहित करता है:

```java
import com.aspose.slides.ITextFrame;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

Map<Integer, Map<ITextFrame, List<TextMatch>>> matchesBySlide =
        new LinkedHashMap<Integer, Map<ITextFrame, List<TextMatch>>>();

for (TextMatch result : callback.getResults()) {
    Integer slideNumber = result.getSlideNumber();
    Map<ITextFrame, List<TextMatch>> matchesByTextFrame = matchesBySlide.get(slideNumber);

    if (matchesByTextFrame == null) {
        matchesByTextFrame = new LinkedHashMap<ITextFrame, List<TextMatch>>();
        matchesBySlide.put(slideNumber, matchesByTextFrame);
    }

    ITextFrame textFrame = result.getTextFrame();
    List<TextMatch> textFrameMatches = matchesByTextFrame.get(textFrame);

    if (textFrameMatches == null) {
        textFrameMatches = new java.util.ArrayList<TextMatch>();
        matchesByTextFrame.put(textFrame, textFrameMatches);
    }

    textFrameMatches.add(result);
}

for (Map.Entry<Integer, Map<ITextFrame, List<TextMatch>>> slideEntry : matchesBySlide.entrySet()) {
    String slideLabel = slideEntry.getKey() == null ? "Other" : slideEntry.getKey().toString();
    System.out.println("Slide: " + slideLabel);

    for (Map.Entry<ITextFrame, List<TextMatch>> textFrameEntry : slideEntry.getValue().entrySet()) {
        System.out.println("  Text frame: " + textFrameEntry.getKey().getText());

        for (TextMatch result : textFrameEntry.getValue()) {
            System.out.println("    '" + result.getFoundText() + "' at position " +
                    result.getTextPosition() + "; context: '" + result.getSourceText() + "'");
        }
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरी प्रस्तुति के बजाय केवल एक टेक्स्ट बॉक्स कैसे खोज सकता हूँ?**

शेप के टेक्स्ट फ्रेम को प्राप्त करें और उस टेक्स्ट फ्रेम पर [ITextFrame.highlightText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), या [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) को कॉल करें। प्रेजेंटेशन‑स्तर के मेथड सभी लागू टेक्स्ट फ्रेमों को प्रोसेस करते हैं।

**मैं पूरा शब्द सही केस के साथ कैसे मैच करूँ?**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) और [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) को `true` पर सेट करें, और विकल्पों को literal‑text हाइलाइट या रिप्लेस मेथड को पास करें। नियमित अभिव्यक्तियों के लिए, शब्द सीमाएँ और केस संवेदनशीलता को Java `Pattern` में ही निर्धारित करें।

**क्या खोज और बदलाव स्लाइड नोट्स में टेक्स्ट को भी शामिल कर सकते हैं?**

हां। प्रेजेंटेशन‑स्तर के literal‑text ऑपरेशन का उपयोग करते समय [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) को `true` पर सेट करें। ऊपर दिखाया गया कॉलबैक इम्प्लीमेंटेशन नोट्स स्लाइड में मैच को उसके पैरेंट स्लाइड नंबर से मैप करता है।

**मैं रिपोर्ट को दो बार प्रेजेंटेशन स्कैन किए बिना कैसे बना सकता हूँ?**

हाइलाइट या रिप्लेस ऑपरेशन को चलाते समय एक [IFindResultCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifindresultcallback/) इम्प्लीमेंटेशन पास करें। कॉलबैक हर मैच को ऑपरेशन के दौरान प्राप्त करता है, जिससे एप्लिकेशन स्रोत टेक्स्ट, मैच किया गया टेक्स्ट, स्थिति, टेक्स्ट फ्रेम और व्युत्पन्न स्लाइड नंबर को बाद में समूहित या निर्यात करने के लिए स्टोर कर सकता है।

**क्या टेक्स्ट बदलने से उसका फॉर्मेट संरक्षित रहता है?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) मौजूदा टेक्स्ट फ्रेम के भीतर मैच किए गए टेक्स्ट को बदलते हैं और आसपास के भाग के फॉर्मेट को बनाए रखते हैं। यदि कोई मैच विभिन्न फॉर्मेट वाले भागों को कवर करता है, तो परिणाम की जांच करें ताकि सुनिश्चित हो सके कि बदलाव वाला टेक्स्ट इच्छित शैली का उपयोग करे।