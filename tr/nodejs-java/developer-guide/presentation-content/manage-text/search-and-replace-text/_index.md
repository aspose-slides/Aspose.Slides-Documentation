---
title: "JavaScript'te PowerPoint Sunumlarında Metin Arama ve Değiştirme"
linktitle: "Metin Arama ve Değiştirme"
type: docs
weight: 55
url: /tr/nodejs-java/search-and-replace-text/
keywords:
- "metin ara"
- "metni vurgula"
- "metni değiştir"
- "düzenli ifade"
- "sonuç geri çağırması"
- "metin çerçevesi"
- "denetim raporu"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint sunumlarında metin arama, vurgulama ve değiştirme işlemini gerçekleştirirken her eşleşmeyi toplayın."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, bireysel bir metin çerçevesinde veya tüm bir sunumda metin arayabilir, vurgulayabilir ve değiştirebilir. Her işlem, bir sonuç geri çağırması aracılığıyla her eşleşme hakkında uygulamayı bilgilendirebilir. Bu sayede bir sunumu güncellerken eşleşen metin, bağlamı, konumu, metin çerçevesi ve slayt numarasını içeren bir denetim izi aynı anda oluşturulabilir.

Bu yetenekler, inceleme, kırpma, terminoloji kontrolleri, şablon temizliği ve otomatik raporlama iş akışları için yararlıdır.

Aşağıdaki ilk örneklerde, ilk slaytta aşağıdaki metni içeren tek bir metin kutusu bulunan “sample.pptx” adlı bir dosya kullanıyoruz:

![Örnek metin](sample_text.png)

## **Arama Kapsamını Seçin**

Bir işlemi tek bir metin çerçevesiyle sınırlamak için [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) yöntemlerini, sunumdaki tüm uygulanabilir metni işlemek için ise [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) yöntemlerini kullanın.

| İşlem | Tek metin çerçevesi | Tüm sunum |
|---|---|---|
| Düz metni vurgula | [TextFrame.highlightText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Düzenli ifade eşleşmelerini vurgula | [TextFrame.highlightRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Düz metni değiştir | [TextFrame.replaceText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Düzenli ifade eşleşmelerini değiştir | [TextFrame.replaceRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Metin Eşleştirmeyi Yapılandırma**

Düz metin işlemleri için eşleşmeyi kontrol etmek üzere [TextSearchOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textsearchoptions/) kullanın:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) eşleşmeleri yalnızca tam kelimelerle sınırlar.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) karakter büyük/küçük harf eşleşmesini kontrol eder.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) sunum‑seviyesindeki arama, değiştirme ve vurgulama işlemlerine slayt notlarını da dahil eder.

Düzenli ifade işlemleri bir Java `Pattern` kullandığından, büyük/küçük harf duyarlılığı ve kelime sınırları gibi kurallar ifadeye ve bayraklara göre tanımlanır.

## **Bir Metin Çerçevesinin Sahibini Belirleme**

Genel metin işleme iş akışları genellikle bir [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) alır; metni ararken, değiştirirken, doğrularken veya dışa aktarırken bu çerçevenin hangi sunum nesnesine ait olduğunu belirlemek için [TextFrame.getParentShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getParentShape--) ve [TextFrame.getParentCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getParentCell--) kullanılabilir.

Beklenen değerler sahibine göre değişir:

| Metin çerçevesi sahibi | `getParentShape` | `getParentCell` |
|---|---|---|
| Bir AutoShape veya başka bir metin içeren şekil | Sahip olan [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) | `null` |
| Bir tablo hücresi | `null` | Sahip olan [Cell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cell/) |

Her iki yöntem sadece salt‑okunur gezinme sağlar. Çağrıldıklarında metin çerçevesi hareket etmez veya sahibi değişmez. Genel kod, her iki değeri de `null` için kontrol etmeli ve hiçbir sahibin bulunmadığı durumları ele almalıdır.

Aşağıdaki örnek, bir sunumdaki metin çerçevelerini yinelemek için [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) kullanır. Şekiller için şekil adını, Java çalışma zamanı türünü ve içinde bulunduğu slaytı rapor eder; tablo hücreleri için sıfır‑tabanlı sütun ve satır koordinatlarını ve içinde bulunduğu slaytı rapor eder.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideLabel(baseSlide) {
    if (java.instanceOf(baseSlide, "com.aspose.slides.Slide")) {
        return "slide " + baseSlide.getSlideNumber();
    }

    if (java.instanceOf(baseSlide, "com.aspose.slides.NotesSlide")) {
        return "notes for slide " + baseSlide.getParentSlide().getSlideNumber();
    }

    return baseSlide.getClass().getSimpleName();
}

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, false);

    for (let index = 0; index < textFrames.length; index++) {
        const textFrame = textFrames[index];
        const ownerShape = textFrame.getParentShape();
        if (ownerShape !== null) {
            const shapeName = ownerShape.getName() === "" ? "(unnamed)" : ownerShape.getName();
            const shapeType = ownerShape.getClass().getSimpleName();
            const slideLabel = getSlideLabel(ownerShape.getSlide());
            console.log("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        const ownerCell = textFrame.getParentCell();
        if (ownerCell !== null) {
            const slideLabel = getSlideLabel(ownerCell.getSlide());
            console.log("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        console.log("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

SmartArt içeriği için, [SmartArtNode.getShapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartartnode/#getShapes--) içinde gezinip her [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartartshape/#getTextFrame--) öğesine erişin. Metin çerçevesi, [TextFrame.getParentShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getParentShape--) aracılığıyla ilişkili şekline izlenebilir; [TextFrame.getParentCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getParentCell--) ise `null` döner. Bu nedenle örnekteki şekil dalı, SmartArt düğümlerindeki metni de işler.

## **Eşleşme Bilgilerini Geri Çağırma ile Toplama**

Her eşleşme için bir sonuç geri çağırma proxy’si oluşturarak bir bildirim alın. Proxy işlevi ilgili metin çerçevesi, kaynak metin, eşleşen metin ve eşleşme konumunu alır.

Geri çağırma doğrudan bir slayt numarası almaz. Aşağıdaki uygulama, metin çerçevesinin sahip olduğu şekil veya tablo hücresi üzerinden, yoksa [TextFrame.getSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getSlide--) yöntemiyle slayt numarasını türetir. Ayrıca slayt notlarında bulunan metni de işler.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

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

Değiştirme işlemleri için `foundText` orijinal eşleşen metni içerir; böylece geri çağırma hangi terimlerin değiştirildiğini tam olarak kaydedebilir.

## **Metni Vurgulama**

Metin çerçevesindeki düz metin eşleşmelerini vurgulamak için [TextFrame.highlightText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) yöntemini kullanın. Aramayı denetlemek için [TextSearchOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textsearchoptions/) ile birlikte geçirin.

Aşağıdaki kod örneği **“try”** karakterlerinin tüm oluşumlarını ve ardından yalnızca tam **“to”** kelimesini vurgular.

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

    // Metin çerçevesindeki "try" ifadesinin her oluşumunu vurgula.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // "to" tam kelimesini yalnızca vurgula.
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Vurgulanan metin](highlighted_text.png)

## **Düzenli İfadeler Kullanarak Metni Vurgulama**

[Düzenli ifade] metin eşleşmelerini bir metin çerçevesinde vurgulamak için [TextFrame.highlightRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) yöntemini kullanın.

Aşağıdaki kod, yedi veya daha fazla harf içeren tüm kelimeleri vurgular:

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

[Tüm uygulanabilir metin çerçevelerini] aramak için [Presentation.highlightText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [Presentation.highlightRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) kullanın. Aşağıdaki örnek bir düz terim ve tüm e‑posta adreslerini vurgular:

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

## **Bir Metin Çerçevesinde Metni Değiştirme**

Düz metin için [TextFrame.replaceText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), desen tabanlı değiştirme için ise [TextFrame.replaceRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) kullanın. Bu yöntemler, mevcut metin çerçevesindeki eşleşen metni günceller; çevresindeki kısmın biçimlendirmesini korur, yani çerçeveyi düz bir dizeden yeniden oluşturmaz.

Aşağıdaki örnek bir imla varyantını standartlaştırır ve ardından sürüm etiketlerini değiştirir:

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

Bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, çıktıyı inceleyerek hangi biçimin değiştirilmiş metne uygulanacağını doğrulayın.

## **Sunum Genelinde Metni Değiştirme**

[Presentation.replaceText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [Presentation.replaceRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) kullanarak aynı işlemleri tüm sunuma uygulayın. Bu, şablon temizliği, terminoloji güncellemeleri ve kırpma için kullanışlıdır.

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

## **Raporlama İçin Eşleşmeleri Gruplama**

Her toplanan sonucun slayt numarası ve metin çerçevesi depolandığından, uygulamalar denetim, raporlama veya inceleme iş akışları için eşleşmeleri gruplandırabilir. Aşağıdaki örnek sonuçları önce slayta, ardından metin çerçevesine göre gruplar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

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

**Nasıl sadece bir metin kutusunu, tüm sunumu değil, arayabilirim?**

Şeklin metin çerçevesini alın ve o çerçevede [TextFrame.highlightText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) veya [TextFrame.replaceRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) metodunu çağırın. Sunum‑seviyesindeki yöntemler ise tüm uygulanabilir çerçeveleri işler.

**Tam kelimeleri doğru büyük/küçük harfle eşleştirmek nasıl yapılır?**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) ve [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) ayarlarını `true` yapın ve bu seçenekleri düz‑metin vurgulama veya değiştirme yöntemine gönderin. Düzenli ifadeler için kelime sınırları ve büyük/küçük harf duyarlılığı Java `Pattern` içinde tanımlanır.

**Arama ve değiştirme slayt notlarındaki metni de içerebilir mi?**

Evet. Sunum‑seviyesindeki düz‑metin işlemi kullanırken [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) ayarını `true` yapın. Yukarıdaki geri çağırma uygulaması, bir not slaydındaki eşleşmeyi ana slayt numarasına bağlar.

**Sunumu ikinci kez taramadan bir rapor nasıl oluşturabilirim?**

Vurgulama veya değiştirme işlemi sırasında bir Java sonuç‑geri çağırma proxy’si geçirin. Geri çağırma, işlem yürürken her eşleşmeyi alır; uygulama kaynak metin, eşleşen metin, konum, metin çerçevesi ve türetilen slayt numarasını daha sonra grup oluşturma veya dışa aktarma için saklayabilir.

**Metni değiştirmek biçimlendirmesini korur mu?**

[TextFrame.replaceText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve [TextFrame.replaceRegex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) eşleşen metni mevcut çerçeve içinde değiştirir ve çevresindeki kısmın biçimlendirmesini korur. Bir eşleşme farklı biçimlendirmeli bölümleri kapsıyorsa, sonuçları inceleyerek değiştirilen metnin istediğiniz stilde olduğundan emin olun.