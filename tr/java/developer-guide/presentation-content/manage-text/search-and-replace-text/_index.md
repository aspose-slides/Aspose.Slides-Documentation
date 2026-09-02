---
title: Java'da PowerPoint Sunumlarında Metin Arama ve Değiştirme
linktitle: Metin Ara ve Değiştir
type: docs
weight: 55
url: /tr/java/search-and-replace-text/
keywords:
- metin ara
- metin vurgula
- metin değiştir
- düzenli ifade
- sonuç geri çağırma
- metin çerçevesi
- denetim raporu
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint sunumlarında metin arayın, vurgulayın ve değiştirin; tüm eşleşmeleri toplayın."
---
## **Genel Bakış**

Aspose.Slides for Java, tek bir metin çerçevesinde veya tüm sunumda metin arama, vurgulama ve değiştirme yapabilir. Her işlem, bir sonuç geri çağırma (callback) aracılığıyla her eşleşme hakkında uygulamaya bildirim gönderebilir. Bu sayede bir sunumu güncelleyebilir ve eşleşen metni, bağlamını, konumunu, metin çerçevesini ve slayt numarasını içeren bir denetim izini aynı anda oluşturabilirsiniz.

Bu özellikler inceleme, redaksiyon, terminoloji kontrolleri, şablon temizliği ve otomatik raporlama iş akışları için yararlıdır.

Aşağıdaki ilk örneklerde, ilk slaytta tek bir metin kutusu bulunan ve aşağıdaki metni içeren “sample.pptx” adlı bir dosya kullanıyoruz:

![Sample text](sample_text.png)

## **Arama Kapsamını Seçin**

Bir işlemi tek bir metin çerçevesiyle sınırlamak için [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) üzerindeki yöntemleri kullanın. Tüm geçerli metinleri işlemek için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) üzerindeki yöntemleri kullanın.

| İşlem | Tek metin çerçevesi | Tüm sunum |
|---|---|---|
| Literal metni vurgula | [ITextFrame.highlightText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Düzenli ifade eşleşmelerini vurgula | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Literal metni değiştir | [ITextFrame.replaceText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Düzenli ifade eşleşmelerini değiştir | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Metin Eşleştirmeyi Yapılandır**

Literal‑metin işlemleri için eşleşmeyi kontrol etmek amacıyla [TextSearchOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textsearchoptions/) kullanın:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) eşleşmeleri tam kelimelerle sınırlar.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) karakter büyük/küçük harf eşleşmesinin gerekip gerekmediğini belirler.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) sunum seviyesi arama, değiştirme ve vurgulama işlemlerine slayt notlarını dahil eder.

Düzenli ifade işlemleri bir Java `Pattern` kullanır; bu nedenle büyük/küçük harf duyarlılığı ve kelime sınırları gibi kurallar ifadede ve bayraklarda tanımlanır.

## **Eşleşme Bilgilerini Geri Çağırma ile Topla**

Her eşleşme için bildirim almak üzere [IFindResultCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifindresultcallback/) uygulayın. Bu arayüzün [IFindResultCallback.foundResult](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) yöntemi ilgili metin çerçevesini, kaynak metni, eşleşen metni ve eşleşmenin konumunu sağlar.

Geri çağırma doğrudan bir slayt numarası almaz. Aşağıdaki uygulama, bunu üst slayttan türetir ve ayrıca slayt notlarındaki metni de işler. `Integer` tipinde nullable bir değer, aynı sonuç modelinin diğer slayt türleriyle ilişkili metni temsil etmesine olanak tanır.

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

Değiştirme işlemleri için `foundText` orijinal eşleşen metni içerir; böylece geri çağırma, hangi terimlerin değiştirildiğini tam olarak kaydedebilir.

## **Metni Vurgula**

Bir metin çerçevesinde literal‑metin eşleşmelerini vurgulamak için [ITextFrame.highlightText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) yöntemini kullanın. Aramayı kontrol etmek için [TextSearchOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textsearchoptions/) ve eşleşme ayrıntılarını toplamak için bir geri çağırma geçirin.

Aşağıdaki kod örneği, **"try"** karakterlerinin tüm oluşumlarını vurgular ve ardından yalnızca tam kelime **"to"** yi vurgular. Her iki arama da aynı geri çağırmaya bildirim gönderir.

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

    // Metin çerçevesindeki "try" ifadesinin her oluşumunu vurgula.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // Yalnızca tam kelime "to" yu vurgula.
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

## **Düzenli İfadeler Kullanarak Metni Vurgula**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) yöntemi, bir düzenli ifadeyle bulunan metin eşleşmelerini bir metin çerçevesinde vurgular.

Aşağıdaki kod, yedi veya daha fazla karakter içeren tüm kelimeleri vurgular ve her eşleşmeyi toplar:

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

Sonuç:

![Düzenli ifade kullanarak vurgulanan metin](highlighted_text_using_regex.png)

## **Sunum Genelinde Metni Vurgula**

[Presentation.highlightText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [Presentation.highlightRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) kullanarak bir sunumdaki tüm geçerli metin çerçevelerinde arama yapın. Aşağıdaki örnek, literal bir terimi ve tüm e‑posta adreslerini vurgular; iki arama için ayrı sonuç koleksiyonları tutulur.

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

## **Metin Çerçevesinde Metni Değiştir**

Literal metin için [ITextFrame.replaceText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), desen tabanlı değiştirme için ise [ITextFrame.replaceRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) kullanın. Bu yöntemler, mevcut metin çerçevesi içinde eşleşen metni günceller; böylece etrafındaki biçimlendirme korunur ve çerçeve yeniden oluşturulmaz.

Aşağıdaki örnek, bir yazım varyantını standart hâle getirir ve ardından sürüm etiketlerini değiştirir. Aynı geri çağırma, iki işlemde de eşleşen orijinal terimleri kaydeder.

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

Bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, çıktıyı inceleyerek değiştirme metninin hangi biçimi alması gerektiğini doğrulayın.

## **Sunum Genelinde Metni Değiştir**

[Presentation.replaceText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [Presentation.replaceRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) kullanarak aynı işlemleri tüm sunuma uygulayın. Şablon temizliği, terminoloji güncellemeleri ve redaksiyon için yararlıdır.

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

## **Raporlama İçin Eşleşmeleri Gruplandır**

Her sonuç slayt numarası ve metin çerçevesi içerdiği için uygulamalar, denetim, raporlama veya inceleme iş akışları için eşleşmeleri gruplayabilir. Aşağıdaki örnek, toplanan sonuçları önce slayta, ardından metin çerçevesine göre gruplayarak gösterir:

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

**Sadece bir metin kutusunda, tüm sunum yerine nasıl arama yapabilirim?**

Şeklin (shape) metin çerçevesini alın ve o metin çerçevesinde [ITextFrame.highlightText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), veya [ITextFrame.replaceRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) yöntemlerini çağırın. Sunum‑seviyesi yöntemler tüm geçerli metin çerçevelerini işler.

**Tam kelimeleri doğru büyük/küçük harf ile nasıl eşleştirebilirim?**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) ve [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) seçeneklerini `true` yapın ve bu seçenekleri literal‑metin vurgulama veya değiştirme yöntemine geçirin. Düzenli ifadeler için kelime sınırlarını ve büyük/küçük harf duyarlılığını Java `Pattern` içinde tanımlayın.

**Arama ve değiştirme slayt notlarındaki metni de içerebilir mi?**

Evet. Sunum‑seviyesi literal‑metin işlemi kullanırken [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) seçeneğini `true` yapın. Yukarıdaki geri çağırma uygulaması, bir not slaytındaki eşleşmeyi ebeveyn slayt numarasına bağlar.

**Sunumu ikinci kez taramadan bir rapor nasıl oluşturabilirim?**

Vurgulama veya değiştirme işlemine bir [IFindResultCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifindresultcallback/) uygulaması geçirin. Geri çağırma işlem sırasında her eşleşmeyi alır; böylece uygulama kaynak metni, eşleşen metni, konumu, metin çerçevesini ve türetilen slayt numarasını daha sonra gruplandırma veya dışa aktarma için saklayabilir.

**Metni değiştirmek biçimlendirmesini korur mu?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [ITextFrame.replaceRegex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) mevcut metin çerçevesi içinde eşleşen metni değiştirir ve çevresindeki bölümlerin biçimlendirmesini korur. Bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, istenen stilde olduğundan emin olmak için sonucu inceleyin.