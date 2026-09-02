---
title: PowerPoint Sunumlarında Metin Arama ve Değiştirme (JavaScript)
linktitle: Metin Arama ve Değiştirme
type: docs
weight: 55
url: /tr/nodejs-java/search-and-replace-text/
keywords:
- metin ara
- metin vurgula
- metin değiştir
- düzenli ifade
- sonuç geri çağrısı
- metin çerçevesi
- denetim raporu
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint sunumlarında metin arama, vurgulama ve değiştirme işlemlerini, Aspose.Slides for Node.js via Java ile her eşleşmeyi toplayarak gerçekleştirin."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, bireysel bir metin çerçevesinde veya tüm bir sunumda metin arama, vurgulama ve değiştirme işlemleri yapabilir. Her işlem, her eşleşme hakkında bir sonuç geri çağrısı aracılığıyla uygulamaya bildirimde bulunabilir. Bu, bir sunumu güncellerken eşleşen metni, bağlamını, konumunu, metin çerçevesini ve slayt numarasını içeren bir denetim izini aynı anda oluşturmayı mümkün kılar.

Bu yetenekler, inceleme, sansür, terminoloji kontrolleri, şablon temizliği ve otomatik raporlama iş akışları için faydalıdır.

Aşağıdaki ilk örneklerde, ilk slaytta aşağıdaki metni içeren tek bir metin kutusu bulunan "sample.pptx" adlı dosyayı kullanıyoruz:

![Örnek metin](sample_text.png)

## **Arama Kapsamını Seçin**

Bir işlemi tek bir metin çerçevesi ile sınırlamak için [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) yöntemlerini kullanın. Sunumdaki tüm uygulanabilir metni işlemek için [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) yöntemlerini kullanın.

| İşlem | Tek metin çerçevesi | Tüm sunum |
|---|---|---|
| Doğrudan metni vurgula | [TextFrame.highlightText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Düzenli ifade eşleşmelerini vurgula | [TextFrame.highlightRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Doğrudan metni değiştir | [TextFrame.replaceText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Düzenli ifade eşleşmelerini değiştir | [TextFrame.replaceRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Metin Eşleşmesini Yapılandırın**

Doğrudan metin işlemleri için eşleşmeyi kontrol etmek üzere [TextSearchOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textsearchoptions/) kullanın:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) tam kelimelerle eşleşmeleri sınırlar.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) karakter harf duyarlılığının eşleşmesini kontrol eder.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) slayt notlarını sunum düzeyindeki arama, değiştirme ve vurgulama işlemlerine dahil eder.

Düzenli ifade işlemleri bir Java `Pattern` kullanır, bu yüzden harf duyarlılığı ve kelime sınırları gibi eşleşme kuralları ifadenin ve bayraklarının kendisi tarafından tanımlanır.

## **Eşleşme Bilgilerini Geri Çağrı ile Toplayın**

Her eşleşme için bir bildirim almak amacıyla sonuç geri çağrısı için bir Java proxy'si oluşturun. Proxy işlevi ilgili metin çerçevesini, kaynak metni, eşleşen metni ve eşleşme konumunu alır.

Geri çağrı doğrudan bir slayt numarası almaz. Aşağıdaki uygulama bunu [TextFrame.getSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getSlide--), [Slide.getSlideNumber](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#getSlideNumber--), ve [NotesSlide.getParentSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notesslide/#getParentSlide--) aracılığıyla türetir. Ayrıca slayt notlarında bulunan metni de işler.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

function createTextSearchCallback(results) {
    return java.newProxy("com.aspose.slides.IFindResultCallback", {
        foundResult: function(textFrame, sourceText, foundText, textPosition) {
            results.push({
                textFrame: textFrame,
                sourceText: sourceText,
                foundText: foundText,
                textPosition: textPosition,
                slideNumber: getSlideNumber(textFrame)
            });
        }
    });
}
```

Değiştirme işlemleri için `foundText` orijinal eşleşen metni içerir, böylece geri çağrı tam olarak hangi terimlerin değiştirildiğini kaydedebilir.

## **Metni Vurgula**

Bir metin çerçevesinde doğrudan metin eşleşmelerini vurgulamak için [TextFrame.highlightText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) yöntemini kullanın. Aramayı kontrol etmek için [TextSearchOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textsearchoptions/) geçirin.

Aşağıdaki kod örneği, **"try"** karakterlerinin tüm oluşumlarını vurgular ve ardından sadece tam kelime **"to"** yi vurgular.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const substringSearchOptions = new aspose.slides.TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    const substringHighlightColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    // Metin çerçevesinde "try" ifadesinin her oluşumunu vurgula.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Sadece tam kelime "to" yu vurgula.
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Vurgulanan metin](highlighted_text.png)

## **Düzenli İfadelerle Metni Vurgulama**

[TextFrame.highlightRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) yöntemi, bir metin çerçevesinde düzenli ifade ile bulunan metin eşleşmelerini vurgular.

Aşağıdaki kod, yedi veya daha fazla karakter içeren tüm kelimeleri vurgular:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    shape.getTextFrame().highlightRegex(regex, highlightColor, null);

    presentation.save(
        "highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Düzenli ifade kullanılarak vurgulanan metin](highlighted_text_using_regex.png)

## **Sunum Genelinde Metni Vurgulama**

Sunumda tüm uygulanabilir metin çerçevelerini aramak için [Presentation.highlightText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [Presentation.highlightRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) kullanın. Aşağıdaki örnek, bir doğrudan terimi ve tüm e-posta adreslerini vurgular:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);
    const termHighlightColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");

    presentation.highlightText(
        "confidential", termHighlightColor, searchOptions, null);

    const emailRegex = Pattern.compile(
        "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
        Pattern.CASE_INSENSITIVE);
    const emailHighlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightRegex(emailRegex, emailHighlightColor, null);
    presentation.save("highlighted_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Metin Çerçevesinde Metni Değiştir**

Doğrudan metin için [TextFrame.replaceText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), desen tabanlı değiştirme için [TextFrame.replaceRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) kullanın. Bu yöntemler, mevcut metin çerçevesindeki eşleşen metni günceller ve metin çerçevesini düz bir dizeden yeniden oluşturmak yerine çevreleyen bölüm biçimlendirmesini korur.

Aşağıdaki örnek, bir yazım varyantını standartlaştırır ve ardından sürüm etiketlerini değiştirir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText(
        "colour", "color", searchOptions, null);

    const versionRegex = Pattern.compile(
        "\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", null);

    presentation.save("updated_text_frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Eğer bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, hangi biçimin değiştirme metnine uygulanması gerektiğini doğrulamak için çıktıyı inceleyin.

## **Sunum Genelinde Metni Değiştir**

Aynı işlemleri sunum genelinde uygulamak için [Presentation.replaceText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [Presentation.replaceRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) kullanın. Bu, şablon temizliği, terminoloji güncellemeleri ve sansür için faydalıdır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText(
        "Contoso", "Example Corp", searchOptions, null);

    const accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", null);

    presentation.save("updated_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Raporlama için Eşleşmeleri Gruplandırma**

Her toplanan sonuç slayt numarasını ve metin çerçevesini depoladığından, uygulamalar denetim, raporlama veya inceleme iş akışları için eşleşmeleri gruplayabilir. Aşağıdaki örnek, sonuçları önce slayta göre, ardından metin çerçevesine göre gruplar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

const results = [];
const callback = java.newProxy("com.aspose.slides.IFindResultCallback", {
    foundResult: function(textFrame, sourceText, foundText, textPosition) {
        results.push({
            textFrame: textFrame,
            sourceText: sourceText,
            foundText: foundText,
            textPosition: textPosition,
            slideNumber: getSlideNumber(textFrame)
        });
    }
});

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setCaseSensitive(false);
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightText(
        "confidential", highlightColor, searchOptions, callback);

    const matchesBySlide = new Map();

    for (const result of results) {
        const slideLabel = result.slideNumber === null ? "Other" : result.slideNumber;

        if (!matchesBySlide.has(slideLabel)) {
            matchesBySlide.set(slideLabel, new Map());
        }

        const matchesByTextFrame = matchesBySlide.get(slideLabel);
        if (!matchesByTextFrame.has(result.textFrame)) {
            matchesByTextFrame.set(result.textFrame, []);
        }

        matchesByTextFrame.get(result.textFrame).push(result);
    }

    for (const [slideLabel, matchesByTextFrame] of matchesBySlide) {
        console.log("Slide: " + slideLabel);

        for (const [textFrame, textFrameMatches] of matchesByTextFrame) {
            console.log("  Text frame: " + textFrame.getText());

            for (const result of textFrameMatches) {
                console.log(
                    "    '" + result.foundText + "' at position " +
                    result.textPosition + "; context: '" + result.sourceText + "'");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **SSS**

**Sadece tüm sunum yerine tek bir metin kutusunda nasıl arama yapabilirim?**

Şeklin metin çerçevesini alın ve bu çerçevede [TextFrame.highlightText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), veya [TextFrame.replaceRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) yöntemlerini çağırın. Sunum düzeyindeki yöntemler ise tüm uygulanabilir metin çerçevelerini işler.

**Doğru büyük/küçük harfle tam kelimeleri nasıl eşleştirebilirim?**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) ve [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) değerlerini `true` olarak ayarlayın ve bu seçenekleri doğrudan metin vurgulama veya değiştirme yöntemine geçirin. Düzenli ifadeler için ise kelime sınırlarını ve harf duyarlılığını Java `Pattern` içinde tanımlayın.

**Arama ve değiştirme slayt notlarındaki metni içerebilir mi?**

Evet. Sunum düzeyinde bir doğrudan metin işlemi kullanırken [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) değerini `true` olarak ayarlayın. Yukarıda gösterilen geri çağrı uygulaması, bir not slaydındaki eşleşmeyi ana slayt numarasına geri eşler.

**Sunumu ikinci kez taramadan bir rapor nasıl oluşturabilirim?**

Vurgulama veya değiştirme işlemine bir Java sonuç‑geri‑çağrı proxy’si geçirin. Geri çağrı, işlem çalışırken her eşleşmeyi alır; böylece uygulama kaynak metni, eşleşen metni, konumu, metin çerçevesini ve türetilen slayt numarasını daha sonra gruplama veya dışa aktarma için depolayabilir.

**Metni değiştirmek biçimlendirmesini korur mu?**

[TextFrame.replaceText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [TextFrame.replaceRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) mevcut metin çerçevesindeki eşleşen metni değiştirir ve çevreleyen bölüm biçimlendirmesini korur. Eğer bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, değiştirme işleminin istenen stili kullandığından emin olmak için sonucu inceleyin.