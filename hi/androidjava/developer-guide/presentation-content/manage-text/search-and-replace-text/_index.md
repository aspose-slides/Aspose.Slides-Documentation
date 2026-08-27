---
title: Android पर PowerPoint प्रस्तुतियों में टेक्स्ट खोजें और बदलें
linktitle: टेक्स्ट खोजें और बदलें
type: docs
weight: 55
url: /hi/androidjava/search-and-replace-text/
keywords:
- टेक्स्ट खोज
- टेक्स्ट हाइलाइट
- टेक्स्ट बदलें
- नियमित अभिव्यक्ति
- परिणाम कॉलबैक
- टेक्स्ट फ़्रेम
- ऑडिट रिपोर्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ PowerPoint प्रस्तुतियों में टेक्स्ट खोजें, हाइलाइट करें और बदलें, जबकि प्रत्येक मैच को एकत्रित करें।"
---
## **परिचय**

Aspose.Slides for Android via Java व्यक्तिगत टेक्स्ट फ़्रेम में या पूरे प्रेज़ेंटेशन में टेक्स्ट को खोज, हाइलाइट और बदल सकता है। प्रत्येक ऑपरेशन परिणाम कॉलबैक के माध्यम से प्रत्येक मैच के बारे में एप्लिकेशन को सूचित भी कर सकता है। इससे प्रेज़ेंटेशन को अपडेट करना और साथ ही मैच किए गए टेक्स्ट, उसका संदर्भ, स्थिति, टेक्स्ट फ़्रेम और स्लाइड नंबर वाला ऑडिट ट्रेल बनाना संभव हो जाता है।

इन क्षमताओं का उपयोग समीक्षा, संवेदनशीलता हटाने, शब्दावली जांच, टेम्प्लेट सफ़ाई और स्वचालित रिपोर्टिंग वर्कफ़्लो के लिए किया जा सकता है।

नीचे पहले उदाहरणों में हम "sample.pptx" नामक फ़ाइल का उपयोग करते हैं, जिसमें पहली स्लाइड पर एकल टेक्स्ट बॉक्स है जिसमें निम्नलिखित टेक्स्ट है:

![Sample text](sample_text.png)

## **खोज दायरा चुनें**

एक ऑपरेशन को एक टेक्स्ट फ़्रेम तक सीमित करने के लिए [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) पर विधियों का उपयोग करें। प्रेज़ेंटेशन में सभी लागू टेक्स्ट को प्रोसेस करने के लिए [IPresentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/) पर विधियों का उपयोग करें।

| ऑपरेशन | एक टेक्स्ट फ़्रेम | संपूर्ण प्रेज़ेंटेशन |
|---|---|---|
| Highlight literal text | [ITextFrame.highlightText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [ITextFrame.replaceText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **टेक्स्ट मिलान को कॉन्फ़िगर करें**

Literal‑text ऑपरेशनों के लिए, मिलान को नियंत्रित करने हेतु [TextSearchOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textsearchoptions/) का उपयोग करें:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) मैच को केवल पूर्ण शब्दों तक सीमित करता है।
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) निर्धारित करता है कि अक्षर केस मेल होना चाहिए या नहीं।
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) स्लाइड नोट्स को प्रेज़ेंटेशन‑लेवल खोज, प्रतिस्थापन और हाइलाइटिंग ऑपरेशनों में शामिल करता है।

Regular‑expression ऑपरेशनों में Java `Pattern` का उपयोग किया जाता है, इसलिए केस सेंसिटिविटी और शब्द सीमाओं जैसी नियम अभिव्यक्ति और उसकी फ़्लैग्स द्वारा परिभाषित होते हैं।

## **टेक्स्ट फ़्रेम के मालिक की पहचान करें**

जनरल टेक्स्ट‑प्रोसेसिंग वर्कफ़्लो अक्सर खोज, प्रतिस्थापन, सत्यापन या निर्यात के दौरान एक [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) प्राप्त करते हैं। यह निर्धारित करने के लिए कि कौन सा प्रेज़ेंटेशन ऑब्जेक्ट टेक्स्ट फ़्रेम का मालिक है, [ITextFrame.getParentShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#getParentShape--) और [ITextFrame.getParentCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#getParentCell--) का उपयोग करें।

| टेक्स्ट फ़्रेम मालिक | `getParentShape` | `getParentCell` |
|---|---|---|
| एक AutoShape या कोई अन्य टेक्स्ट‑युक्त शेप | The owning [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) | `null` |
| एक टेबल सेल | `null` | The owning [ICell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icell/) |

इन दोनों विधियों द्वारा केवल पढ़ने‑लायक नेविगेशन प्रदान किया जाता है। इन्हें कॉल करने से टेक्स्ट फ़्रेम नहीं चलता और न ही उसका मालिक बदलता है। जनरल कोड को दोनों मानों के लिए `null` जाँच करनी चाहिए और यह सम्भावना संभालनी चाहिए कि दोनों मालिक उपलब्ध न हों।

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

SmartArt कंटेंट के लिए, [ISmartArtNode.getShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ismartartnode/#getShapes--) में मौजूद शेप्स को क्रमबद्ध करें और प्रत्येक [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) तक पहुँचें। टेक्स्ट फ़्रेम को उसके जुड़े हुए शेप से [ITextFrame.getParentShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#getParentShape--) के माध्यम से ट्रेस किया जा सकता है, जबकि [ITextFrame.getParentCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#getParentCell--) `null` लौटाता है। इसलिए उदाहरण में शेप शाखा SmartArt नोड्स से टेक्स्ट को भी संभालती है।

## **कॉलबैक के साथ मैच जानकारी एकत्र करें**

हर मैच की सूचना प्राप्त करने हेतु [IFindResultCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifindresultcallback/) लागू करें। इसका [IFindResultCallback.foundResult](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) मेथड संबंधित टेक्स्ट फ़्रेम, स्रोत टेक्स्ट, मैच किया गया टेक्स्ट और मैच की स्थिति प्रदान करता है।

कॉलबैक सीधे स्लाइड नंबर नहीं प्राप्त करता। नीचे दिखाया गया कार्यान्वयन पैरेंट स्लाइड से इसे निकालता है तथा स्लाइड नोट्स में पाए गए टेक्स्ट को भी संभालता है। एक nullable `Integer` समान परिणाम मॉडल को अन्य स्लाइड प्रकारों के साथ जुड़े टेक्स्ट को दर्शाने की अनुमति देता है।

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

प्रतिस्थापन ऑपरेशनों के लिए, `foundText` मूल मैच किए गए टेक्स्ट को रखता है, इसलिए कॉलबैक ठीक‑ठीक कौन‑से शब्द बदले गए थे, रिकॉर्ड कर सकता है।

## **टेक्स्ट को हाइलाइट करें**

एक टेक्स्ट फ़्रेम में literal‑text मैच को हाइलाइट करने हेतु [ITextFrame.highlightText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) मेथड का उपयोग करें। खोज को नियंत्रित करने के लिए [TextSearchOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textsearchoptions/) पास करें और मैच विवरण एकत्र करने के लिए कॉलबैक प्रदान करें।

नीचे दिया गया कोड उदाहरण सभी **"try"** अक्षरों की घटनाओं को हाइलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाइलाइट करता है। दोनों खोजें समान कॉलबैक को अपना परिणाम रिपोर्ट करती हैं।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    int substringHighlightColor = Color.rgb(173, 216, 230);

    // टेक्स्ट फ्रेम में "try" की प्रत्येक घटना को हाइलाइट करें।
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

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

![हाइलाइट किया गया टेक्स्ट](highlighted_text.png)

## **नियमित अभिव्यक्तियों का उपयोग करके टेक्स्ट को हाइलाइट करें**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) मेथड एक नियमित अभिव्यक्ति द्वारा पाए गए टेक्स्ट मैच को टेक्स्ट फ़्रेम में हाइलाइट करता है।

निम्नलिखित कोड सात या अधिक अक्षरों वाले सभी शब्दों को हाइलाइट करता है और प्रत्येक मैच को एकत्र करता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;
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

![नियमित अभिव्यक्ति का उपयोग करके हाइलाइट किया गया टेक्स्ट](highlighted_text_using_regex.png)

## **प्रेज़ेंटेशन भर में टेक्स्ट को हाइलाइट करें**

सभी लागू टेक्स्ट फ़्रेम्स में खोज करने के लिए [IPresentation.highlightText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और [IPresentation.highlightRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) का उपयोग करें। नीचे दिया गया उदाहरण एक literal शब्द और सभी ई‑मेल पतों को अलग‑अलग परिणाम संग्रहों के साथ हाइलाइट करता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    int termHighlightColor = Color.rgb(255, 165, 0);
    presentation.highlightText("confidential", termHighlightColor, searchOptions, termCallback);

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

## **टेक्स्ट फ़्रेम में टेक्स्ट बदलें**

literal टेक्स्ट के लिए [ITextFrame.replaceText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और पैटर्न‑आधारित प्रतिस्थापन के लिए [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) का उपयोग करें। ये मेथड मौजूदा टेक्स्ट फ़्रेम के भीतर मैच किए गए टेक्स्ट को अपडेट करते हैं, जिससे आसपास के हिस्से का फ़ॉर्मेट बरकरार रहता है, न कि सामान्य स्ट्रिंग से फ़्रेम को फिर से निर्मित किया जाता है।

निम्न उदाहरण स्पेलिंग वैरिएंट को मानकीकृत करता है और फिर संस्करण लेबल को बदलता है। समान कॉलबैक दोनों ऑपरेशनों द्वारा मैच किए गए मूल शब्दों को रिकॉर्ड करता है।

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

यदि कोई मैच अलग‑अलग फ़ॉर्मेटिंग वाले हिस्सों को कवर करता है, तो आउटपुट की जाँच करें और सुनिश्चित करें कि प्रतिस्थापन टेक्स्ट पर कौन‑सी शैली लागू होनी चाहिए।

## **प्रेज़ेंटेशन भर में टेक्स्ट बदलें**

समान ऑपरेशनों को पूरे प्रेज़ेंटेशन पर लागू करने के लिए [IPresentation.replaceText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और [IPresentation.replaceRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) का उपयोग करें। यह टेम्प्लेट सफ़ाई, शब्दावली अपडेट और संवेदनशीलता हटाने के लिए उपयोगी है।

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

## **रिपोर्टिंग के लिए मैच समूहित करें**

क्योंकि प्रत्येक परिणाम अपना स्लाइड नंबर और टेक्स्ट फ़्रेम संग्रहीत करता है, एप्लिकेशन ऑडिट, रिपोर्टिंग या समीक्षा वर्कफ़्लो के लिए मैच को समूहित कर सकते हैं। नीचे दिया गया उदाहरण पहले स्लाइड के अनुसार और फिर टेक्स्ट फ़्रेम के अनुसार एकत्रित परिणामों को समूहित करता है:

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

**How can I search only one text box instead of the entire presentation?**  
आकार के टेक्स्ट फ़्रेम को प्राप्त करें और उस फ़्रेम पर [ITextFrame.highlightText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), या [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) को कॉल करें। प्रेज़ेंटेशन‑लेवल मेथड सभी लागू टेक्स्ट फ़्रेम्स को प्रोसेस करते हैं।

**How can I match complete words with the correct capitalization?**  
[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) और [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) को `true` सेट करें और इन्हें literal‑text हाइलाइट या प्रतिस्थापन मेथड में पास करें। नियमित अभिव्यक्तियों के लिये, शब्द सीमाओं और केस सेंसिटिविटी को स्वयं Java `Pattern` में परिभाषित करें।

**Can search and replacement include text in slide notes?**  
हाँ। प्रेज़ेंटेशन‑लेवल literal‑text ऑपरेशन का उपयोग करते समय [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) को `true` सेट करें। ऊपर दिखाया गया कॉलबैक इम्प्लीमेंटेशन नोट्स स्लाइड में मिले मैच को उसके पैरेंट स्लाइड नंबर से मैप करता है।

**How can I create a report without scanning the presentation a second time?**  
हाइलाइट या प्रतिस्थापन ऑपरेशन में एक [IFindResultCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifindresultcallback/) इम्प्लीमेंटेशन पास करें। कॉलबैक ऑपरेशन चलते समय हर मैच प्राप्त करता है, जिससे एप्लिकेशन स्रोत टेक्स्ट, मैच किया गया टेक्स्ट, स्थिति, टेक्स्ट फ़्रेम और निकाला गया स्लाइड नंबर को बाद में समूहित या एक्सपोर्ट करने के लिये संग्रहीत कर सकता है।

**Does replacing text preserve its formatting?**  
[ITextFrame.replaceText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) मिलान किए गए टेक्स्ट को मौजूदा टेक्स्ट फ़्रेम के भीतर अपडेट करते हैं और आसपास के भाग की फ़ॉर्मेटिंग को बरकरार रखते हैं। यदि कोई मैच अलग‑अलग फ़ॉर्मेटिंग वाले हिस्सों को कवर करता है, तो परिणाम की जाँच करें ताकि यह सुनिश्चित हो सके कि प्रतिस्थापन वांछित शैली का उपयोग करता है।