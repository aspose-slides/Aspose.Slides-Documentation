---
title: PowerPoint Sunumlarında PHP ile Metin Arama ve Değiştirme
linktitle: Metin Arama ve Değiştirme
type: docs
weight: 55
url: /tr/php-java/search-and-replace-text/
keywords:
- metin arama
- metin vurgulama
- metin değiştirme
- düzenli ifade
- sonuç geri çağrısı
- metin çerçevesi
- denetim raporu
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PowerPoint sunumlarında metin arama, vurgulama ve değiştirme işlemlerini Aspose.Slides for PHP via Java ile gerçekleştirirken her eşleşmeyi toplar."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, tek bir metin çerçevesinde ya da tüm bir sunumda metin arama, vurgulama ve değiştirme yapabilir. Her işlem, bir sonuç geri çağrısı aracılığıyla uygulamayı her eşleşme hakkında bilgilendirebilir. Bu, bir sunumu güncellerken eşleşen metin, bağlamı, konumu, metin çerçevesi ve slayt numarasını içeren bir denetim izini aynı anda oluşturmayı mümkün kılar.

Bu özellikler, inceleme, gizleme, terminoloji kontrolleri, şablon temizliği ve otomatik raporlama iş akışları için yararlıdır.

Aşağıdaki ilk örneklerde, ilk slaytta aşağıdaki metni içeren tek bir metin kutusu bulunan "sample.pptx" adlı dosyayı kullanıyoruz:

![Örnek metin](sample_text.png)

## **Arama Kapsamını Seçin**

[TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) üzerindeki yöntemleri kullanarak bir işlemi tek bir metin çerçevesiyle sınırlayabilirsiniz. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) üzerindeki yöntemleri kullanarak sunumdaki tüm uygulanabilir metni işleyebilirsiniz.

| İşlem | Tek metin çerçevesi | Tüm sunum |
|---|---|---|
| Highlight literal text | [TextFrame::highlightText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#highlightText) |
| Highlight regular-expression matches | [TextFrame::highlightRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#highlightRegex) |
| Replace literal text | [TextFrame::replaceText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#replaceText) |
| Replace regular-expression matches | [TextFrame::replaceRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#replaceRegex) |

## **Metin Eşleştirmeyi Yapılandırın**

Literal metin işlemleri için, eşleşmeyi kontrol etmek amacıyla [TextSearchOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textsearchoptions/) kullanın:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) eşleşmeleri tam kelimelerle sınırlar.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) karakter büyük/küçük harf eşleşmesinin zorunlu olup olmadığını kontrol eder.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) sunum düzeyindeki arama, değiştirme ve vurgulama işlemlerine slayt notlarını dahil eder.

Düzenli ifade işlemleri bir Java `Pattern` kullanır, bu nedenle büyük/küçük harf duyarlılığı ve kelime sınırları gibi eşleşme kuralları ifade ve bayrakları tarafından tanımlanır.

## **Geri Çağrıyla Eşleşme Bilgilerini Toplayın**

Vurgulama ya da değiştirme yöntemine bir Java proxy geri çağrısı geçirerek her eşleşme için bir bildirim alabilirsiniz. Geri çağrı yöntemi ilgili metin çerçevesini, kaynak metni, eşleşen metni ve eşleşme konumunu alır.

Geri çağrı doğrudan bir slayt numarası almaz. Aşağıdaki uygulama, onu ana slayttan türetir ve slayt notlarında bulunan metni de işler. Sonuç dizisi, metin başka bir slayt türüyle ilişkili olduğunda `null` kullanır.

```php
class TextSearchCallback {
    private $results = [];

    public function getResults() {
        return $this->results;
    }

    public function foundResult($textFrame, $sourceText, $foundText, $textPosition) {
        $slideNumber = $this->getSlideNumber($textFrame);
        $this->results[] = [
            "textFrame" => $textFrame,
            "sourceText" => java_values($sourceText),
            "foundText" => java_values($foundText),
            "textPosition" => java_values($textPosition),
            "slideNumber" => $slideNumber
        ];
    }

    private function getSlideNumber($textFrame) {
        $parentSlide = $textFrame->getSlide();
        if (java_is_null($parentSlide)) {
            return null;
        }

        $parentSlideClass = $parentSlide->getClass();
        $classNameValue = $parentSlideClass->getName();
        $className = java_values($classNameValue);

        if ($className === "com.aspose.slides.Slide") {
            $slideNumber = $parentSlide->getSlideNumber();
            return java_values($slideNumber);
        }

        if ($className === "com.aspose.slides.NotesSlide") {
            $slide = $parentSlide->getParentSlide();
            $slideNumber = $slide->getSlideNumber();
            return java_values($slideNumber);
        }

        return null;
    }
}
```

Bu PHP nesnesi için bir proxy oluşturup bir işleme geçirmeden önce:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Değiştirme işlemleri için, `foundText` orijinal eşleşen metni içerir, böylece geri çağrı tam olarak hangi terimlerin değiştirildiğini kaydedebilir.

## **Metni Vurgula**

[TextFrame::highlightText] yöntemini bir metin çerçevesindeki literal metin eşleşmelerini vurgulamak için kullanın. Aramayı kontrol etmek için [TextSearchOptions] gönderin.

Aşağıdaki kod örneği **"try"** karakterlerinin tüm görünümlerini ve ardından sadece tam **"to"** kelimesini vurgular.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $callbackHandler = new TextSearchCallback();
    $callbackInterface = java("com.aspose.slides.IFindResultCallback");
    $callback = java_closure(
        $callbackHandler,
        null,
        $callbackInterface
    );

    $substringSearchOptions = new TextSearchOptions();
    $substringSearchOptions->setCaseSensitive(false);
    $substringHighlightColor = new Java("java.awt.Color", 173, 216, 230);

    // Metin çerçevesinde "try" ifadesinin her görünümünü vurgula.
    $shape->getTextFrame()->highlightText(
        "try",
        $substringHighlightColor,
        $substringSearchOptions,
        $callback
    );

    $wholeWordSearchOptions = new TextSearchOptions();
    $wholeWordSearchOptions->setWholeWordsOnly(true);
    $wholeWordSearchOptions->setCaseSensitive(false);
    $wholeWordHighlightColor = new Java("java.awt.Color", 238, 130, 238);

    // Sadece tam kelime "to" yu vurgula.
    $shape->getTextFrame()->highlightText(
        "to",
        $wholeWordHighlightColor,
        $wholeWordSearchOptions,
        $callback
    );

    foreach ($callbackHandler->getResults() as $result) {
        echo(
            "Found '" . $result["foundText"] . "' at position " .
            $result["textPosition"] . " on slide " .
            $result["slideNumber"] . ".\n"
        );
    }

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Sonuç:

![Vurgulanan metin](highlighted_text.png)

## **Düzenli İfadeler Kullanarak Metni Vurgula**

[TextFrame::highlightRegex] yöntemi bir metin çerçevesinde düzenli ifade ile bulunan metin eşleşmelerini vurgular.

Aşağıdaki kod yedi veya daha fazla karakter içeren tüm kelimeleri vurgular:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $regex = java("java.util.regex.Pattern")->compile("\\b[^\\s]{7,}\\b");
    $highlightColor = java("java.awt.Color")->YELLOW;

    $shape->getTextFrame()->highlightRegex($regex, $highlightColor, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Sonuç:

![Düzenli ifade kullanarak vurgulanan metin](highlighted_text_using_regex.png)

## **Sunumda Metni Vurgula**

[Presentation::highlightText] ve [Presentation::highlightRegex] yöntemlerini bir sunumdaki tüm uygulanabilir metin çerçevelerini aramak için kullanın. Aşağıdaki örnek literal bir terimi ve tüm e-posta adreslerini vurgular:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);
    $termHighlightColor = java("java.awt.Color")->ORANGE;

    $presentation->highlightText(
        "confidential",
        $termHighlightColor,
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $emailPattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b";
    $emailRegex = $patternClass->compile(
        $emailPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $emailHighlightColor = java("java.awt.Color")->YELLOW;

    $presentation->highlightRegex($emailRegex, $emailHighlightColor, null);
    $presentation->save("highlighted_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Bir Metin Çerçevesinde Metni Değiştir**

Literal metin için [TextFrame::replaceText], desen tabanlı değiştirme için [TextFrame::replaceRegex] kullanın. Bu yöntemler eşleşen metni mevcut metin çerçevesi içinde günceller; böylece çerçeve, düz bir dizeden yeniden oluşturulmak yerine çevresindeki biçimlendirmeyi korur.

Aşağıdaki örnek bir yazım varyantını standartlaştırır ve ardından sürüm etiketlerini değiştirir:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);

    $shape->getTextFrame()->replaceText(
        "colour",
        "color",
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $versionPattern = "\\bv\\d+(?:\\.\\d+)*\\b";
    $versionRegex = $patternClass->compile(
        $versionPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $shape->getTextFrame()->replaceRegex(
        $versionRegex,
        "current version",
        null
    );

    $presentation->save("updated_text_frame.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Eğer bir eşleşme farklı biçimlendirmeli bölümleri kapsıyorsa, çıktıyı gözden geçirerek hangi biçimlendirmenin değiştirme metnine uygulanacağını doğrulayın.

## **Sunumda Metni Değiştir**

[Presentation::replaceText] ve [Presentation::replaceRegex] yöntemlerini aynı işlemleri sunum genelinde uygulamak için kullanın. Bu, şablon temizliği, terminoloji güncellemeleri ve gizleme için yararlıdır.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);

    $presentation->replaceText(
        "Contoso",
        "Example Corp",
        $searchOptions,
        null
    );

    $accountNumberRegex = java("java.util.regex.Pattern")->compile(
        "\\bACCT-\\d{6}\\b"
    );
    $presentation->replaceRegex(
        $accountNumberRegex,
        "ACCT-REDACTED",
        null
    );

    $presentation->save("updated_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Raporlama İçin Eşleşmeleri Gruplandır**

Her sonuç slayt numarasını ve metin çerçevesini depoladığından, uygulamalar denetim, raporlama ya da inceleme iş akışları için eşleşmeleri gruplayabilir. Aşağıdaki örnek toplanan sonuçları önce slayta, sonra metin çerçevesine göre gruplar:

```php
$matchesBySlide = [];
$systemClass = java("java.lang.System");

foreach ($callbackHandler->getResults() as $result) {
    $slideNumber = $result["slideNumber"];
    $slideLabel = $slideNumber === null ? "Other" : (string) $slideNumber;
    $textFrame = $result["textFrame"];
    $textFrameHash = $systemClass->identityHashCode($textFrame);
    $textFrameKey = (string) java_values($textFrameHash);

    if (!isset($matchesBySlide[$slideLabel])) {
        $matchesBySlide[$slideLabel] = [];
    }

    if (!isset($matchesBySlide[$slideLabel][$textFrameKey])) {
        $matchesBySlide[$slideLabel][$textFrameKey] = [
            "textFrame" => $textFrame,
            "matches" => []
        ];
    }

    $matchesBySlide[$slideLabel][$textFrameKey]["matches"][] = $result;
}

foreach ($matchesBySlide as $slideLabel => $textFrameGroups) {
    echo("Slide: " . $slideLabel . "\n");

    foreach ($textFrameGroups as $textFrameGroup) {
        $textFrame = $textFrameGroup["textFrame"];
        echo("  Text frame: " . $textFrame->getText() . "\n");

        foreach ($textFrameGroup["matches"] as $result) {
            echo(
                "    '" . $result["foundText"] . "' at position " .
                $result["textPosition"] . "; context: '" .
                $result["sourceText"] . "'\n"
            );
        }
    }
}
```

## **SSS**

**Nasıl yalnızca bir metin kutusunda, tüm sunumu değil, arama yapabilirim?**

Şeklin metin çerçevesini alın ve o çerçevede [TextFrame::highlightText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#replaceText) veya [TextFrame::replaceRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#replaceRegex) yöntemlerini çağırın. Sunum düzeyindeki yöntemler tüm uygulanabilir metin çerçevelerini işler.

**Tam kelimeleri doğru büyük/küçük harfle nasıl eşleştirebilirim?**

[TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) ve [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) değerlerini `true` olarak ayarlayın ve seçenekleri literal metin vurgulama ya da değiştirme yöntemine iletin. Düzenli ifadeler için kelime sınırlarını ve büyük/küçük harf duyarlılığını Java `Pattern` içinde tanımlayın.

**Arama ve değiştirme slayt notlarındaki metni içerebilir mi?**

Evet. Sunum düzeyinde literal metin işlemi uygularken [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) değerini `true` olarak ayarlayın.

**Sunumu ikinci kez taramadan bir rapor nasıl oluşturabilirim?**

Vurgulama ya da değiştirme işlemine bir Java proxy geri çağrısı geçirin. İşlem çalışırken her eşleşmeyi alır; böylece uygulama kaynak metni, eşleşen metni, konumu, metin çerçevesini ve türetilen slayt numarasını daha sonra gruplamak ya da dışa aktarmak için saklayabilir.

**Metni değiştirmek biçimlendirmesini korur mu?**

[TextFrame::replaceText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#replaceText) ve [TextFrame::replaceRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#replaceRegex) eşleşen metni mevcut metin çerçevesi içinde değiştirir ve çevresindeki biçimlendirmeyi korur. Eğer bir eşleşme farklı biçimlendirmeli bölümleri kapsıyorsa, değiştirme istenen stili kullandığından emin olmak için sonucu inceleyin.