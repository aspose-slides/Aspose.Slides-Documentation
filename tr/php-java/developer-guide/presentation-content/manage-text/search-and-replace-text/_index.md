---
title: PHP'de PowerPoint Sunumlarında Metin Ara ve Değiştir
linktitle: Metin Ara ve Değiştir
type: docs
weight: 55
url: /tr/php-java/search-and-replace-text/
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
- PHP
- Aspose.Slides
description: "PowerPoint sunumlarında metin arama, vurgulama ve değiştirme işlemlerini Aspose.Slides for PHP via Java ile gerçekleştirirken her eşleşmeyi toplar."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, bir tek metin çerçevesinde ya da tüm sunumda metin arama, vurgulama ve değiştirme işlemleri yapabilir. Her işlem, eşleşmeler hakkında bir sonuç geri çağrısı (callback) aracılığıyla uygulamaya bildirim gönderir. Bu sayede bir sunumu güncellerken eşleşen metni, bağlamını, konumunu, metin çerçevesini ve slayt numarasını içeren bir denetim izi oluşturmak mümkün olur.

Bu yetenekler, inceleme, sansürleme, terminoloji denetimi, şablon temizliği ve otomatik raporlama iş akışları için faydalıdır.

Aşağıdaki ilk örneklerde, ilk slaytta tek bir metin kutusu bulunan ve aşağıdaki metni içeren **sample.pptx** adlı dosya kullanılmıştır:

![Örnek metin](sample_text.png)

## **Arama Kapsamını Seçin**

Bir işlemi tek bir metin çerçevesiyle sınırlamak için [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) üzerindeki yöntemleri kullanın. Sunumdaki tüm ilgili metinleri işlemek için ise [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) üzerindeki yöntemleri kullanın.

| İşlem | Tek metin çerçevesi | Tüm sunum |
|---|---|---|
| Düz metni vurgula | [TextFrame::highlightText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#highlightText) |
| Düzenli ifade eşleşmelerini vurgula | [TextFrame::highlightRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#highlightRegex) |
| Düz metni değiştir | [TextFrame::replaceText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#replaceText) |
| Düzenli ifade eşleşmelerini değiştir | [TextFrame::replaceRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#replaceRegex) |

## **Metin Eşleştirmeyi Yapılandır**

Düz metin işlemleri için eşleşmeyi kontrol etmek amacıyla [TextSearchOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textsearchoptions/) kullanın:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) yalnızca tam kelimelerle eşleşmeyi sınırlar.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) karakter duyarlılığının zorunlu olup olmadığını kontrol eder.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) sunum seviyesindeki arama, değiştirme ve vurgulama işlemlerine slayt notlarını dahil eder.

Düzenli ifade işlemleri bir Java `Pattern` kullanır; bu nedenle büyük/küçük harf duyarlılığı ve kelime sınırları gibi kurallar ifadede ve bayraklarında tanımlanır.

## **Bir Metin Çerçevesinin Sahibini Belirleyin**

Genel metin işleme iş akışları, arama, değiştirme, doğrulama veya dışa aktarma sırasında çoğu zaman bir [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) alır. Metin çerçevesinin hangi sunum nesnesine ait olduğunu belirlemek için [TextFrame::getParentShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#getParentShape) ve [TextFrame::getParentCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#getParentCell) yöntemlerini kullanın.

Beklenen değerler sahibine göre değişir:

| Metin çerçevesi sahibi | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape veya başka bir metin içeren şekil | Sahibi olan [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) | `null` |
| Tablo hücresi | `null` | Sahibi olan [Cell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cell/) |

Her iki yöntem de yalnızca okuma amaçlı gezinme sağlar. Çağrıldıklarında metin çerçevesini taşımaz veya sahibini değiştirmez. Genel kod, her iki değeri de `java_is_null` ile kontrol etmeli ve hiçbir sahibin bulunmama olasılığını ele almalıdır.

Aşağıdaki örnek, bir sunumdaki metin çerçevelerini yinelemek için [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideutil/#getAllTextFrames) kullanır. Şekiller için şekil adını, Java çalışma zamanı tipini ve içinde bulunduğu slaytı raporlar. Tablo hücreleri için sıfır‑tabanlı sütun ve satır koordinatlarını ve içinde bulunduğu slaytı raporlar.

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$presentation = new Presentation("presentation.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $textFrames = SlideUtil::getAllTextFrames($presentation, false);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        $textFrame = $textFrames[$textFrameIndex];
        $ownerShape = $textFrame->getParentShape();
        if (!java_is_null($ownerShape)) {
            $shapeName = java_values($ownerShape->getName());
            $shapeName = $shapeName === "" ? "(unnamed)" : $shapeName;
            $shapeType = java_values($ownerShape->getClass()->getSimpleName());
            $baseSlide = $ownerShape->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Shape: " . $shapeName . "; type: " . $shapeType . "; " . $slideLabel . "\n");
            continue;
        }

        $ownerCell = $textFrame->getParentCell();
        if (!java_is_null($ownerCell)) {
            $baseSlide = $ownerCell->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Table cell: column " . java_values($ownerCell->getFirstColumnIndex()) . ", row " . java_values($ownerCell->getFirstRowIndex()) . "; " . $slideLabel . "\n");
            continue;
        }

        echo("The text frame owner is not available as a shape or table cell.\n");
    }
} finally {
    $presentation->dispose();
}
```

SmartArt içeriği için, [SmartArtNode::getShapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartnode/#getShapes) içindeki şekilleri yineleyin ve her bir [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartartshape/#getTextFrame) öğesine erişin. Metin çerçevesi, [TextFrame::getParentShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#getParentShape) aracılığıyla ilişkili şekle izlenebilir; [TextFrame::getParentCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#getParentCell) ise `null` döndürür. Bu nedenle örnekteki şekil dalı, SmartArt düğümlerinden gelen metni de işler.

## **Bir Geri Çağrı ile Eşleşme Bilgilerini Toplayın**

Vurgulama veya değiştirme metoduna bir Java proxy geri çağrısı geçirerek her eşleşme için bildirim alabilirsiniz. Geri çağrı metodu ilgili metin çerçevesini, kaynak metni, eşleşen metni ve eşleşme konumunu alır.

Geri çağrı doğrudan bir slayt numarası almaz. Aşağıdaki uygulama, bunu üst slayttan türetir ve slayt notlarında bulunan metni de işler. Sonuç dizisi, metin başka bir slayt türüne ait olduğunda `null` kullanır.

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
        $parentShape = $textFrame->getParentShape();
        $parentCell = $textFrame->getParentCell();

        if (!java_is_null($parentShape)) {
            $parentSlide = $parentShape->getSlide();
        } elseif (!java_is_null($parentCell)) {
            $parentSlide = $parentCell->getSlide();
        } else {
            $parentSlide = $textFrame->getSlide();
        }

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

Bu PHP nesnesi için bir proxy oluşturun ve ardından bir işleme geçirin:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Değiştirme işlemleri için, `foundText` orijinal eşleşen metni içerir; böylece geri çağrı hangi terimlerin değiştirildiğini tam olarak kaydedebilir.

## **Metni Vurgula**

Düz metin eşleşmelerini bir metin çerçevesinde vurgulamak için [TextFrame::highlightText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#highlightText) metodunu kullanın. Aramayı kontrol etmek için [TextSearchOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textsearchoptions/) geçirin.

Aşağıdaki kod örneği, **"try"** karakterlerinin tüm oluşumlarını vurgular ve ardından yalnızca tam kelime **"to"** yi vurgular.

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

    // Metin çerçevesindeki "try" ifadesinin her oluşumunu vurgula.
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

    // Sadece tam kelime "to"yu vurgula.
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

## **Düzenli İfadelerle Metin Vurgula**

[TextFrame::highlightRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#highlightRegex) metodu, bir düzenli ifadeyle bulunan metin eşleşmelerini bir metin çerçevesinde vurgular.

Aşağıdaki kod, yedi veya daha fazla karakter içeren tüm kelimeleri vurgular:

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

![Düzenli ifade kullanılarak vurgulanan metin](highlighted_text_using_regex.png)

## **Sunum Genelinde Metin Vurgula**

[Presentation::highlightText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#highlightText) ve [Presentation::highlightRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#highlightRegex) metodlarını kullanarak bir sunumdaki tüm uygulanabilir metin çerçevelerinde arama yapın. Aşağıdaki örnek bir düz terimi ve tüm e‑posta adreslerini vurgular:

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

Düz metin için [TextFrame::replaceText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#replaceText), desen tabanlı değiştirme için ise [TextFrame::replaceRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#replaceRegex) kullanın. Bu yöntemler, eşleşen metni mevcut metin çerçevesi içinde günceller; böylece etrafındaki biçimlendirme korunur ve metin çerçevesi tamamen yeni bir dizeyle yeniden oluşturulmaz.

Aşağıdaki örnek bir yazım varyantını standart hale getirir ve ardından sürüm etiketlerini değiştirir:

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

Bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, çıktıyı inceleyerek hangi biçimin değiştirme metnine uygulanacağını doğrulayın.

## **Sunum Genelinde Metni Değiştir**

[Presentation::replaceText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#replaceText) ve [Presentation::replaceRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#replaceRegex) metodlarını kullanarak aynı işlemleri tüm sunuma uygulayın. Bu, şablon temizliği, terminoloji güncellemeleri ve sansürleme için faydalıdır.

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

## **Raporlama İçin Eşleşmeleri Gruplayın**

Her sonuç slayt numarasını ve metin çerçevesini sakladığından, uygulamalar denetim, raporlama veya inceleme iş akışları için eşleşmeleri gruplayabilir. Aşağıdaki örnek, toplanan sonuçları önce slayta, ardından metin çerçevesine göre gruplar:

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

**Yalnızca bir metin kutusunu, tüm sunumu değil, nasıl arayabilirim?**

Şeklin metin çerçevesini alın ve o çerçeve üzerinde [TextFrame::highlightText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#replaceText) veya [TextFrame::replaceRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#replaceRegex) yöntemlerini çağırın. Sunum seviyesindeki yöntemler ise tüm uygulanabilir metin çerçevelerini işler.

**Tam kelimeleri doğru büyük‑küçük harfle eşleştirmek nasıl yapılır?**

[TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) ve [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) seçeneklerini `true` yapın ve bu seçenekleri düz metin vurgulama veya değiştirme metoduna geçirin. Düzenli ifadeler için kelime sınırlarını ve büyük/küçük harf duyarlılığını Java `Pattern` içinde tanımlayın.

**Arama ve değiştirme slayt notlarındaki metni de kapsar mı?**

Evet. Sunum seviyesindeki düz metin işlemlerinde [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) seçeneğini `true` yapın.

**Sunumu ikinci kez taramadan bir rapor nasıl oluşturabilirim?**

Vurgulama veya değiştirme işlemi sırasında bir Java proxy geri çağrısı geçirin. İşlem çalışırken her eşleşme bildirilir; böylece uygulama kaynak metni, eşleşen metni, konumu, metin çerçevesini ve türetilen slayt numarasını daha sonra gruplayıp dışa aktarmak için saklayabilir.

**Metin değiştirme biçimlendirmesini korur mu?**

[TextFrame::replaceText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#replaceText) ve [TextFrame::replaceRegex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#replaceRegex) metodları, eşleşen metni mevcut metin çerçevesi içinde değiştirir ve çevresindeki bölüm biçimlendirmesini korur. Bir eşleşme farklı biçimlendirmeye sahip bölümleri kapsıyorsa, değiştirme işleminin istediğiniz stile sahip olduğundan emin olmak için sonucu inceleyin.