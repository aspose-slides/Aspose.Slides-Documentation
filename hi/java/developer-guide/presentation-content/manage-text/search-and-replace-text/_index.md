---
title: Java में PowerPoint प्रस्तुतियों में पाठ खोजें और बदलें
linktitle: पाठ खोजें और बदलें
type: docs
weight: 55
url: /hi/java/search-and-replace-text/
keywords:
- पाठ खोजें
- पाठ को हाइलाइट करें
- पाठ बदलें
- नियमित अभिव्यक्ति
- परिणाम कॉलबैक
- पाठ फ्रेम
- ऑडिट रिपोर्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint प्रस्तुतियों में पाठ खोजें, हाइलाइट करें और बदलें, जबकि प्रत्येक मिलान को एकत्रित करें."
---
## **अवलोकन**

Aspose.Slides for Java व्यक्तिगत पाठ फ़्रेम या पूरे प्रस्तुतीकरण में पाठ को खोज, हाइलाइट और बदल सकता है। प्रत्येक ऑपरेशन परिणाम कॉलबैक के माध्यम से प्रत्येक मिलान की सूचना एप्लिकेशन को दे सकता है। इससे प्रस्तुतीकरण को अपडेट करते हुए मिलित पाठ, उसका संदर्भ, स्थिति, पाठ फ़्रेम और स्लाइड नंबर सहित ऑडिट ट्रेल बनाना संभव हो जाता है।

इन क्षमताओं का उपयोग समीक्षा, रीडैक्शन, शब्दावली जाँच, टेम्पलेट सफाई और स्वचालित रिपोर्टिंग वर्कफ़्लो में किया जा सकता है।

नीचे पहले उदाहरणों में, हम "sample.pptx" नामक फ़ाइल का उपयोग करते हैं, जिसमें पहली स्लाइड पर एकल पाठ बॉक्स है जिसमें निम्नलिखित पाठ है:

![नमूना पाठ](sample_text.png)

## **खोज दायरा चुनें**

एक ऑपरेशन को एक ही पाठ फ़्रेम तक सीमित करने के लिए [ITextFrame] की मेथड्स का प्रयोग करें। प्रस्तुतीकरण में सभी लागू पाठ को प्रोसेस करने के लिए [Presentation] की मेथड्स का प्रयोग करें।

| ऑपरेशन | एक पाठ फ़्रेम | पूरे प्रस्तुतीकरण |
|---|---|---|
| शाब्दिक पाठ को हाइलाइट करें | [ITextFrame.highlightText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| नियमित अभिव्यक्ति मिलान को हाइलाइट करें | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| शाब्दिक पाठ को बदलें | [ITextFrame.replaceText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| नियमित अभिव्यक्ति मिलान को बदलें | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **पाठ मिलान को कॉन्फ़िगर करें**

शाब्दिक-टेस्ट ऑपरेशनों के लिए, मिलान को नियंत्रित करने हेतु [TextSearchOptions] का उपयोग करें:

- [TextSearchOptions.setWholeWordsOnly] पूर्ण शब्दों तक मिलान को सीमित करता है।
- [TextSearchOptions.setCaseSensitive] कैरेक्टर केस मिलना चाहिए या नहीं, यह नियंत्रित करता है।
- [TextSearchOptions.setIncludeNotes] प्रेजेंटेशन-लेवल खोज, प्रतिस्थापन और हाइलाइटिंग ऑपरेशनों में स्लाइड नोट्स को शामिल करता है।

नियमित अभिव्यक्ति ऑपरेशनों में जावा `Pattern` का उपयोग किया जाता है, इसलिए केस सेंसिटिविटी और शब्द सीमा जैसी मिलान नियम अभिव्यक्ति और उसके फ्लैग्स द्वारा निर्धारित होते हैं।

## **कॉलबैक के साथ मिलान जानकारी एकत्र करें**

प्रत्येक मिलान के लिए सूचना प्राप्त करने हेतु [IFindResultCallback] को लागू करें। इसका [IFindResultCallback.foundResult] मेथड संबंधित पाठ फ़्रेम, स्रोत पाठ, मिलित पाठ और मिलान स्थिति प्रदान करता है।

कॉलबैक को सीधे स्लाइड नंबर नहीं मिलता। नीचे दिया गया कार्यान्वयन इसे पैरेंट स्लाइड से निकालता है तथा स्लाइड नोट्स में पाए गए पाठ को भी संभालता है। एक nullable `Integer` समान परिणाम मॉडल को अन्य स्लाइड प्रकारों के साथ जुड़े पाठ को दर्शाने देता है।

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

    private static Integer getSlideNumber(ITextFrame textFrame) {
        if (!(textFrame instanceof TextFrame)) {
            return null;
        }

        IBaseSlide parentSlide = ((TextFrame) textFrame).getSlide();

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

प्रतिस्थापन ऑपरेशनों के लिए, `foundText` में मूल मिलित पाठ होता है, इसलिए कॉलबैक सटीक रूप से रिकॉर्ड कर सकता है कि कौन से शब्दों को बदला गया।

## **पाठ को हाइलाइट करें**

पाठ फ़्रेम में शाब्दिक-टेस्ट मिलानों को हाइलाइट करने के लिए [ITextFrame.highlightText] मेथड का उपयोग करें। खोज को नियंत्रित करने के लिए [TextSearchOptions] पास करें और मिलान विवरण एकत्र करने हेतु कॉलबैक पास करें।

नीचे दिया गया कोड उदाहरण सभी **"try"** अक्षरों की उपस्थिति को हाइलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाइलाइट करता है। दोनों खोजें अपने मिलानों को समान कॉलबैक को रिपोर्ट करती हैं।

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

![हाइलाइट किया गया पाठ](highlighted_text.png)

## **नियमित अभिव्यक्तियों द्वारा पाठ को हाइलाइट करें**

[ITextFrame.highlightRegex] मेथड एक पाठ फ़्रेम में नियमित अभिव्यक्ति द्वारा पाए गए पाठ मिलानों को हाइलाइट करता है।

निम्नलिखित कोड सात या अधिक अक्षरों वाले सभी शब्दों को हाइलाइट करता है और प्रत्येक मिलान को एकत्र करता है:

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

![नियमित अभिव्यक्ति द्वारा हाइलाइट किया गया पाठ](highlighted_text_using_regex.png)

## **पूरे प्रस्तुतीकरण में पाठ को हाइलाइट करें**

एक प्रस्तुतीकरण में सभी लागू पाठ फ़्रेम खोजने के लिए [Presentation.highlightText] और [Presentation.highlightRegex] का उपयोग करें। निम्नलिखित उदाहरण एक शाब्दिक शब्द और सभी ईमेल पतों को हाइलाइट करता है जबकि दो खोजों के लिए अलग-अलग परिणाम संग्रह रखता है।

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

## **पाठ फ्रेम में पाठ को बदलें**

शाब्दिक पाठ के लिए [ITextFrame.replaceText] और पैटर्न-आधारित प्रतिस्थापन के लिए [ITextFrame.replaceRegex] का उपयोग करें। ये मेथड्स मौजूदा पाठ फ़्रेम के भीतर मिलित पाठ को अपडेट करते हैं, जिससे आसपास के भाग का फ़ॉर्मेटिंग बना रहता है और पूरे फ़्रेम को साधारण स्ट्रिंग से पुनः निर्मित नहीं किया जाता।

निम्नलिखित उदाहरण एक वर्तनी रूपांतर को मानकीकृत करता है और फिर संस्करण लेबल बदलता है। वही कॉलबैक दोनों ऑपरेशनों द्वारा मिलित मूल शब्दों को रिकॉर्ड करता है।

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

यदि कोई मिलान विभिन्न फ़ॉर्मेटिंग वाले भागों को कवर करता है, तो आउटपुट की समीक्षा करें कि प्रतिस्थापन पाठ पर कौन सी फ़ॉर्मेटिंग लागू होनी चाहिए।

## **पूरा प्रस्तुतीकरण में पाठ को बदलें**

एक प्रस्तुतीकरण में समान ऑपरेशनों को लागू करने के लिए [Presentation.replaceText] और [Presentation.replaceRegex] का प्रयोग करें। यह टेम्पलेट सफ़ाई, शब्दावली अपडेट और रीडैक्शन के लिए उपयोगी है।

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

## **रिपोर्टिंग के लिए मिलानों को समूहित करें**

क्योंकि प्रत्येक परिणाम अपने स्लाइड नंबर और पाठ फ़्रेम को संग्रहीत करता है, एप्लिकेशन ऑडिट, रिपोर्टिंग या समीक्षा वर्कफ़्लो के लिए मिलानों को समूहित कर सकते हैं। निम्नलिखित उदाहरण पहले स्लाइड द्वारा और फिर पाठ फ़्रेम द्वारा एकत्रित परिणामों को समूहित करता है:

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

**मैं पूरी प्रस्तुतीकरण के बजाय केवल एक टेक्स्ट बॉक्स में कैसे खोज करूँ?**

शेप का टेक्स्ट फ्रेम प्राप्त करें और उस टेक्स्ट फ्रेम पर [ITextFrame.highlightText]([ITextFrame.highlightText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)), [ITextFrame.highlightRegex]([ITextFrame.highlightRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)), [ITextFrame.replaceText]([ITextFrame.replaceText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)), या [ITextFrame.replaceRegex]([ITextFrame.replaceRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)) को कॉल करें। प्रस्तुतीकरण-स्तरीय मेथड सभी लागू टेक्स्ट फ्रेम प्रोसेस करते हैं।

**मैं पूर्ण शब्दों को सही कैपिटलाइज़ेशन के साथ कैसे मिलाऊँ?**

[TextSearchOptions.setWholeWordsOnly]([TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-)) और [TextSearchOptions.setCaseSensitive]([TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-)) को `true` पर सेट करें और विकल्पों को शाब्दिक-टेस्ट हाइलाइट या रिप्लेस मेथड को पास करें। नियमित अभिव्यक्तियों के लिए, शब्द सीमाएँ और केस सेंसिटिविटी को स्वयं Java `Pattern` में परिभाषित करें।

**क्या खोज और प्रतिस्थापन स्लाइड नोट्स में पाठ को शामिल कर सकते हैं?**

हाँ। प्रस्तुतीकरण-स्तर के शाब्दिक-टेस्ट ऑपरेशन का उपयोग करते समय [TextSearchOptions.setIncludeNotes]([TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-)) को `true` पर सेट करें। ऊपर दिखाए गए कॉलबैक कार्यान्वयन में नोट्स स्लाइड में मिलने वाले मिलान को उसके पैरेंट स्लाइड नंबर से मैप किया गया है।

**मैं प्रस्तुतीकरण को दूसरी बार स्कैन किए बिना रिपोर्ट कैसे बना सकता हूँ?**

हाइलाइट या रिप्लेस ऑपरेशन को चलाते समय एक [IFindResultCallback] कार्यान्वयन पास करें। कॉलबैक ऑपरेशन चलते समय प्रत्येक मिलान प्राप्त करता है, इसलिए एप्लिकेशन स्रोत पाठ, मिलित पाठ, स्थिति, टेक्स्ट फ्रेम और व्युत्पन्न स्लाइड नंबर को बाद में समूहित या निर्यात करने के लिए स्टोर कर सकता है।

**क्या पाठ को बदलने से उसका फ़ॉर्मेटिंग बना रहता है?**

[ITextFrame.replaceText]([ITextFrame.replaceText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)) और [ITextFrame.replaceRegex]([ITextFrame.replaceRegex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)) मिलित पाठ को मौजूदा टेक्स्ट फ़्रेम के भीतर संशोधित करते हैं और आसपास के भाग का फ़ॉर्मेटिंग बरकरार रखते हैं। यदि कोई मिलान विभिन्न फ़ॉर्मेटिंग वाले भागों को कवर करता है, तो परिणाम की जांच करें कि प्रतिस्थापन में इच्छित शैली लागू हुई है या नहीं।