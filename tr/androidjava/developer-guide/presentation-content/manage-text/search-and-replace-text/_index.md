---
title: Android'de PowerPoint Sunumlarında Metin Arama ve Değiştirme
linktitle: Metin Arama ve Değiştirme
type: docs
weight: 55
url: /tr/androidjava/search-and-replace-text/
keywords:
- metin ara
- metni vurgula
- metni değiştir
- düzenli ifade
- sonuç geri çağırması
- metin çerçevesi
- denetim raporu
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "PowerPoint sunumlarında metin arayın, vurgulayın ve değiştirin; Aspose.Slides for Android via Java ile her eşleşmeyi toplayın."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, bir metin çerçevesinde ya da tüm bir sunumda metin arayabilir, vurgulayabilir ve değiştirebilir. Her işlem, eşleşmeler hakkında bir sonuç geri çağrısı aracılığıyla uygulamayı da bilgilendirebilir. Bu sayede bir sunumu güncellerken eşleşen metni, bağlamını, konumunu, metin çerçevesini ve slayt numarasını içeren bir denetim izini aynı anda oluşturmak mümkün olur.

Bu yetenekler, gözden geçirme, redaksiyon, terminoloji kontrolleri, şablon temizliği ve otomatik raporlama iş akışları için yararlıdır.

Aşağıdaki ilk örneklerde, birincil slaytta tek bir metin kutusu içeren ve aşağıdaki metni barındıran "sample.pptx" adlı dosyayı kullanıyoruz:

![Örnek metin](sample_text.png)

## **Arama Kapsamını Seçin**

[ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) üzerindeki yöntemleri, bir işlemi tek bir metin çerçevesiyle sınırlamak için kullanın. [IPresentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/) üzerindeki yöntemleri, sunumdaki tüm geçerli metni işlemek için kullanın.

| İşlem | Tek metin çerçevesi | Tüm sunum |
|---|---|---|
| Doğrudan metni vurgula | [ITextFrame.highlightText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Düzenli ifade eşleşmelerini vurgula | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Doğrudan metni değiştir | [ITextFrame.replaceText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Düzenli ifade eşleşmelerini değiştir | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Metin Eşleştirmeyi Yapılandır**

Doğrudan metin işlemleri için, eşleşmeyi kontrol etmek amacıyla [TextSearchOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textsearchoptions/) kullanın:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) eşleşmeleri yalnızca tam kelimelerle sınırlar.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) karakter büyük/küçük harf eşleşmesinin gerekip gerekmediğini kontrol eder.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) sunum düzeyinde arama, değiştirme ve vurgulama işlemlerine slayt notlarını da dahil eder.

Düzenli ifade işlemleri, bir Java `Pattern` kullanır; bu nedenle büyük/küçük harf duyarlılığı ve kelime sınırları gibi eşleşme kuralları ifadenin ve bayrakların içinde tanımlanır.

## **Eşleşme Bilgilerini Geri Çağırma ile Topla**

[IFindResultCallback](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifindresultcallback/) implement ederek her eşleşme için bir bildirim alın. Onun [IFindResultCallback.foundResult](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) yöntemi ilgili metin çerçevesini, kaynak metni, eşleşen metni ve eşleşme konumunu sağlar.

Geri çağırma doğrudan bir slayt numarası almaz. Aşağıdaki uygulama, bu numarayı üst slayttan türetir ve slayt notlarında bulunan metni de işler. Null olabilen bir `Integer`, aynı sonuç modelinin diğer slayt türleriyle ilişkilendirilen metni temsil etmesini sağlar.

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

Değiştirme işlemleri için, `foundText` orijinal eşleşen metni içerir; böylece geri çağırma tam olarak hangi terimlerin değiştirildiğini kaydedebilir.

## **Metni Vurgula**

[ITextFrame.highlightText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) yöntemini, bir metin çerçevesindeki doğrudan metin eşleşmelerini vurgulamak için kullanın. Aramayı kontrol etmek için [TextSearchOptions] ve eşleşme ayrıntılarını toplamak için bir geri çağırma geçirin.

Aşağıdaki kod örneği, **"try"** karakterlerinin tüm tekrarlarını vurgular ve ardından yalnızca **"to"** tam kelimesini vurgular. Her iki arama da eşleşmelerini aynı geri çağırmaya rapor eder.

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

    // Metin çerçevesinde "try" kelimesinin her geçişini vurgula.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // Yalnızca tam kelime "to"yu vurgula.
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

Sonuç:

![Vurgulanan metin](highlighted_text.png)

## **Düzenli İfadelerle Metni Vurgula**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) yöntemi, bir metin çerçevesinde bir düzenli ifade ile bulunan metin eşleşmelerini vurgular.

Aşağıdaki kod, yedi veya daha fazla karakter içeren tüm kelimeleri vurgular ve her bir eşleşmeyi toplar:

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

Sonuç:

![Düzenli ifade kullanılarak vurgulanan metin](highlighted_text_using_regex.png)

## **Bir Sunum Genelinde Metni Vurgula**

[IPresentation.highlightText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [IPresentation.highlightRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) yöntemlerini, bir sunumdaki tüm geçerli metin çerçevelerinde arama yapmak için kullanın. Aşağıdaki örnek, bir doğrudan terimi ve tüm e-posta adreslerini vurgular; iki arama için ayrı sonuç koleksiyonları tutar.

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

## **Bir Metin Çerçevesinde Metni Değiştir**

Doğrudan metin için [ITextFrame.replaceText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) , desen tabanlı değiştirme için [ITextFrame.replaceRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) kullanın. Bu yöntemler, mevcut metin çerçevesindeki eşleşen metni günceller; çevresindeki bölümlerin biçimlendirmesini tutar ve metin çerçevesini düz bir dizeden yeniden oluşturmaz.

Aşağıdaki örnek, bir yazım varyantını standartlaştırır ve ardından sürüm etiketlerini değiştirir. Aynı geri çağırma, her iki işlemde eşleşen orijinal terimleri kaydeder.

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

Eğer bir eşleşme, farklı biçimlendirmeye sahip bölümleri kapsıyorsa, çıktıyı gözden geçirerek hangi biçimlendirmenin yerine konulan metne uygulanması gerektiğini teyit edin.

## **Bir Sunum Genelinde Metni Değiştir**

[IPresentation.replaceText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [IPresentation.replaceRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) yöntemlerini, bir sunum genelinde aynı işlemleri uygulamak için kullanın. Bu, şablon temizliği, terminoloji güncellemeleri ve redaksiyon için yararlıdır.

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

## **Raporlama için Eşleşmeleri Grupla**

Her sonuç slayt numarasını ve metin çerçevesini depoladığından, uygulamalar eşleşmeleri denetim, raporlama veya gözden geçirme iş akışları için gruplayabilir. Aşağıdaki örnek, toplanan sonuçları önce slayta, ardından metin çerçevesine göre gruplar:

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

## **SSS**

**Yalnızca bir metin kutusunu tüm sunum yerine nasıl arayabilirim?**

Şeklin metin çerçevesini alın ve bu metin çerçevesi üzerinde [ITextFrame.highlightText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), veya [ITextFrame.replaceRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) yöntemlerini çağırın. Sunum düzeyindeki yöntemler, tüm geçerli metin çerçevelerini işler.

**Tam kelimeleri doğru büyük/küçük harfle nasıl eşleştirebilirim?**

Tam kelimeleri ve doğru büyük/küçük harfleri eşleştirmek için [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) ve [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) değerlerini `true` olarak ayarlayın ve bu seçenekleri doğrudan metin vurgulama veya değiştirme yöntemine geçirin. Düzenli ifadeler için, kelime sınırlarını ve büyük/küçük harf duyarlılığını Java `Pattern` içinde tanımlayın.

**Arama ve değiştirme slayt notlarındaki metni içerebilir mi?**

Evet. Sunum düzeyinde doğrudan metin işlemi kullanırken [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) değerini `true` olarak ayarlayın. Yukarıda gösterilen geri çağırma uygulaması, bir not slaydındaki eşleşmeyi üst slayt numarasına eşler.

**Sunumu ikinci kez taramadan nasıl bir rapor oluşturabilirim?**

[IFindResultCallback](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifindresultcallback/) uygulamasını vurgulama veya değiştirme işlemine geçirin. Geri çağırma, işlem çalışırken her eşleşmeyi alır; böylece uygulama, kaynak metni, eşleşen metni, konumu, metin çerçevesini ve türetilen slayt numarasını daha sonra gruplama veya dışa aktarma için depolayabilir.

**Metni değiştirmek biçimlendirmesini korur mu?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [ITextFrame.replaceRegex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) eşleşen metni mevcut metin çerçevesi içinde değiştirir ve çevresindeki bölümlerin biçimlendirmesini korur. Eğer bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, sonucun istenen stili kullandığından emin olmak için kontrol edin.