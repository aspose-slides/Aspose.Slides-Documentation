---
title: Android पर PowerPoint प्रस्तुतियों में टेक्स्ट खोजें और बदलें
linktitle: टेक्स्ट खोजें और बदलें
type: docs
weight: 55
url: /hi/androidjava/search-and-replace-text/
keywords:
- टेक्स्ट खोजें
- टेक्स्ट को हाइलाइट करें
- टेक्स्ट बदलें
- रेगुलर एक्सप्रेशन
- परिणाम कॉलबैक
- टेक्स्ट फ्रेम
- ऑडिट रिपोर्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint प्रस्तुतियों में टेक्स्ट खोजें, हाइलाइट करें और बदलें, तथा प्रत्येक मिलान को एकत्रित करें।"
---
## **समीक्षा**

Aspose.Slides for Android via Java एक व्यक्तिगत टेक्स्ट फ़्रेम या पूरी प्रस्तुति में टेक्स्ट को खोज, हाइलाइट और बदल सकता है। प्रत्येक ऑपरेशन परिणाम कॉलबैक के माध्यम से हर मिलान के बारे में एप्लीकेशन को सूचित भी कर सकता है। यह एक प्रस्तुति को अपडेट करने और साथ ही मिलाए गए टेक्स्ट, उसका संदर्भ, स्थिति, टेक्स्ट फ़्रेम और स्लाइड नंबर शामिल करते हुए ऑडिट ट्रेल बनाने को संभव बनाता है।

इन क्षमताओं का उपयोग समीक्षाओं, रीडैक्शन, शब्दावली जाँच, टेम्प्लेट साफ‑सफ़ाई और स्वचालित रिपोर्टिंग वर्कफ़्लो में किया जा सकता है।

नीचे पहले उदाहरणों में हम “sample.pptx” नामक फ़ाइल का उपयोग करते हैं, जिसमें पहली स्लाइड पर एकल टेक्स्ट बॉक्स है और उसमें नीचे दिया गया टेक्स्ट है:

![नमूना टेक्स्ट](sample_text.png)

## **खोज सीमा चुनें**

[ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) पर उपलब्ध मेथड्स का उपयोग करके ऑपरेशन को एक टेक्स्ट फ़्रेम तक सीमित किया जा सकता है। सभी लागू टेक्स्ट को प्रोसेस करने के लिए [IPresentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/) पर मेथड्स का उपयोग करें।

| ऑपरेशन | एक टेक्स्ट फ़्रेम | पूरी प्रस्तुति |
|---|---|---|
| लिटरल टेक्स्ट को हाइलाइट करें | [ITextFrame.highlightText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| रेगुलर‑एक्सप्रेशन मिलानों को हाइलाइट करें | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| लिटरल टेक्स्ट को बदलें | [ITextFrame.replaceText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| रेगुलर‑एक्सप्रेशन मिलानों को बदलें | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **पाठ मिलान को कॉन्फ़िगर करें**

लिटरल‑टेक्स्ट ऑपरेशन्स के लिए, मिलान को नियंत्रित करने हेतु [TextSearchOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textsearchoptions/) का उपयोग करें:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) मिलानों को पूर्ण शब्दों तक सीमित करता है।  
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) निर्धारित करता है कि कैरेक्टर केस मेल खाना चाहिए या नहीं।  
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) स्लाइड नोट्स को प्रस्तुति‑स्तर की खोज, प्रतिस्थापन और हाइलाइट ऑपरेशन्स में शामिल करता है।

रेगुलर‑एक्सप्रेशन ऑपरेशन्स जावा `Pattern` का उपयोग करते हैं, इसलिए केस‑सेन्सिटिविटी और शब्द सीमाएँ जैसी नियम अभिव्यक्ति और उसके फ्लैग्स द्वारा निर्धारित होते हैं।

## **कॉलबैक के साथ मिलान जानकारी एकत्र करें**

हर मिलान के लिए सूचना प्राप्त करने हेतु [IFindResultCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifindresultcallback/) को इम्प्लीमेंट करें। इसका [IFindResultCallback.foundResult](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) मेथड संबंधित टेक्स्ट फ़्रेम, स्रोत टेक्स्ट, मिलाया गया टेक्स्ट और मिलान की स्थिति प्रदान करता है।

कॉलबैक सीधे स्लाइड नंबर नहीं प्राप्त करता। नीचे दिया गया इम्प्लीमेंटेशन इसे पैरेंट स्लाइड से निकालता है और साथ ही स्लाइड नोट्स में मिले टेक्स्ट को भी संभालता है। एक nullable `Integer` समान परिणाम मॉडल को अन्य स्लाइड प्रकारों से जुड़े टेक्स्ट को दर्शाने की अनुमति देता है।

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

प्रतिस्थापन ऑपरेशन्स के लिए, `foundText` में मूल मिलाए गए टेक्स्ट होते हैं, इसलिए कॉलबैक ठीक‑ठीक रिकॉर्ड कर सकता है कि कौनसे शब्द बदले गये।

## **टेक्स्ट को हाइलाइट करें**

एक टेक्स्ट फ़्रेम में लिटरल‑टेक्स्ट मिलानों को हाइलाइट करने के लिए [ITextFrame.highlightText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) मेथड का प्रयोग करें। खोज को नियंत्रित करने हेतु [TextSearchOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textsearchoptions/) पास करें और मिलान विवरण संग्रहीत करने के लिए कॉलबैक प्रदान करें।

नीचे दिया गया कोड उदाहरण सभी **"try"** अक्षरों को हाइलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाइलाइट करता है। दोनों खोजें अपने मिलानों को एक ही कॉलबैक को रिपोर्ट करती हैं।

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

    // टेक्स्ट फ्रेम में "try" की प्रत्येक उपस्थिति को हाइलाइट करें।
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

## **रेगुलर एक्सप्रेशन का उपयोग करके टेक्स्ट को हाइलाइट करें**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) मेथड रेगुलर एक्सप्रेशन द्वारा पाए गए टेक्स्ट मिलानों को एक टेक्स्ट फ़्रेम में हाइलाइट करता है।

निम्न कोड सभी सात या अधिक अक्षर वाले शब्दों को हाइलाइट करता है और प्रत्येक मिलान को एकत्र करता है:

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

![रेगुलर एक्सप्रेशन से हाइलाइट किया गया टेक्स्ट](highlighted_text_using_regex.png)

## **पूरी प्रस्तुति में टेक्स्ट को हाइलाइट करें**

[IPresentation.highlightText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और [IPresentation.highlightRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) का उपयोग करके प्रस्तुति के सभी लागू टेक्स्ट फ़्रेम्स को खोजें। नीचे दिया गया उदाहरण एक लिटरल टर्म और सभी ई‑मेल पते को हाइलाइट करता है तथा दो खोजों के लिए अलग‑अलग परिणाम संग्रह रखता है।

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

## **टेक्स्ट फ़्रेम में टेक्स्ट को बदलें**

लिटरल टेक्स्ट के लिए [ITextFrame.replaceText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और पैटर्न‑आधारित प्रतिस्थापन के लिए [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) का उपयोग करें। ये मेथड मौजूदा टेक्स्ट फ़्रेम के भीतर मिलाए गए टेक्स्ट को अपडेट करते हैं, जिससे आसपास के फ़ॉर्मेटिंग को बनाए रखा जाता है, न कि पूरे फ़्रेम को साधारण स्ट्रिंग से पुनः बनाते हैं।

निम्न उदाहरण एक वर्तनी रूपांतर को मानकीकृत करता है और फिर संस्करण लेबल बदलता है। समान कॉलबैक दोनों ऑपरेशन्स द्वारा मिलाए गए मूल शब्दों को रिकॉर्ड करता है।

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

यदि कोई मिलान विभिन्न फ़ॉर्मेटिंग वाले हिस्सों को शामिल करता है, तो आउटपुट की जाँच करें कि प्रतिस्थापन के लिए कौनसा फ़ॉर्मेट लागू होना चाहिए।

## **पूरी प्रस्तुति में टेक्स्ट को बदलें**

[IPresentation.replaceText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और [IPresentation.replaceRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) का उपयोग करके समान ऑपरेशन्स को पूरी प्रस्तुति पर लागू करें। यह टेम्प्लेट साफ‑सफ़ाई, शब्दावली अपडेट और रीडैक्शन के लिए उपयोगी है।

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

चूँकि हर परिणाम में उसका स्लाइड नंबर और टेक्स्ट फ़्रेम संग्रहीत होता है, एप्लीकेशन मिलानों को ऑडिट, रिपोर्टिंग या रिव्यू वर्कफ़्लो के लिए समूहित कर सकते हैं। नीचे दिया गया उदाहरण पहले स्लाइड के अनुसार और फिर टेक्स्ट फ़्रेम के अनुसार एकत्रित परिणामों को समूहित करता है:

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

**मैं पूरी प्रस्तुति के बजाय केवल एक टेक्स्ट बॉक्स को कैसे खोजूँ?**

शेप के टेक्स्ट फ़्रेम को प्राप्त करें और उस टेक्स्ट फ़्रेम पर [ITextFrame.highlightText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), या [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) को कॉल करें। प्रस्तुति‑स्तर के मेथड सभी लागू टेक्स्ट फ़्रेम्स को प्रोसेस करेंगे।

**मैं पूरे शब्दों को सही केस के साथ कैसे मिलाऊँ?**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) और [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) को `true` पर सेट करें, और विकल्पों को लिटरल‑टेक्स्ट हाइलाइट या रिप्लेस मेथड को पास करें। रेगुलर एक्सप्रेशन के लिए, शब्द सीमाएँ और केस‑सेन्सिटिविटी को जावा `Pattern` में ही परिभाषित करें।

**क्या खोज और प्रतिस्थापन स्लाइड नोट्स के टेक्स्ट को शामिल कर सकते हैं?**

हां। प्रस्तुति‑स्तर की लिटरल‑टेक्स्ट ऑपरेशन का उपयोग करते समय [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) को `true` सेट करें। ऊपर दिखाया गया कॉलबैक इम्प्लीमेंटेशन नोट्स स्लाइड में मिलान को उसके पैरेंट स्लाइड नंबर से मैप करता है।

**मैं प्रस्तुति को दूसरी बार स्कैन किए बिना रिपोर्ट कैसे बनाऊँ?**

हाइलाइट या रिप्लेस ऑपरेशन को चलाते समय एक [IFindResultCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifindresultcallback/) इम्प्लीमेंटेशन पास करें। कॉलबैक ऑपरेशन के दौरान हर मिलान प्राप्त करता है, जिससे एप्लीकेशन स्रोत टेक्स्ट, मिलाया गया टेक्स्ट, स्थिति, टेक्स्ट फ़्रेम और निकाला गया स्लाइड नंबर बाद में समूहित या निर्यात करने के लिए संग्रहीत कर सकता है।

**क्या टेक्स्ट को बदलने से उसका फ़ॉर्मेटिंग बरकरार रहता है?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) मौजूदा टेक्स्ट फ़्रेम के भीतर मिलाए गए टेक्स्ट को संशोधित करते हैं और आसपास के भागों का फ़ॉर्मेटिंग बनाए रखते हैं। यदि कोई मिलान विभिन्न फ़ॉर्मेटिंग वाले हिस्सों को कवर करता है, तो परिणाम की जांच करें ताकि यह सुनिश्चित हो सके कि प्रतिस्थापन में इच्छित शैली प्रयुक्त हो।