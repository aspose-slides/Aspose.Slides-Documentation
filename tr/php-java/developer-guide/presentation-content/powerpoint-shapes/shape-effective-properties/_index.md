---
title: PHP ile Sunumlardan Şekil Etkili Özelliklerini Alın
linktitle: Etkili Özellikler
type: docs
weight: 50
url: /tr/php-java/shape-effective-properties/
keywords:
- şekil özellikleri
- kamera özellikleri
- ışık donanımı
- köşe şekli
- metin çerçevesi
- metin stili
- yazı tipi yüksekliği
- dolgu biçimi
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'ı kullanarak PowerPoint sunumlarındaki yerel, kalıtılmış ve etkili şekil biçimlendirmesini ayırt etmeyi öğrenin."
---
## **Yerel, Kalıtılmış ve Etkili Özellikleri Anlama**

PowerPoint biçimlendirmesi çeşitli yerlerden gelebilir. Bir nesneye doğrudan kaydedilen değer **yerel değerdir**. Bu değer ayarlanmamışsa, PowerPoint paragraf varsayılanı, metin stili, düzen veya ana slayt, tema veya sunum‑seviyesi varsayılanları gibi üst biçimlendirme kaynaklarına bakar. Bu değerler **kalıtılmış değerler**dir. Tüm hiyerarşi çözüldükten sonra kalan değer **etkili değerdir**—nesneyi oluşturmak için kullanılan değer.

Örneğin, bir metin bölümü kendi yazı tipi yüksekliğini tanımlamıyor olabilir. Yerel [getFontHeight](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/) değeri `NAN` olur; bu “burada ayarlanmamış” anlamına gelir. Bölüm, paragraftan, sunumun varsayılan metin stilinden veya başka bir geçerli kaynaktan yüksekliği devralabilir. Bölüm biçiminde [getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portionformat/geteffective/) çağrısı, son çözülmüş yüksekliği döndürür.

İki tür biçimlendirme verisini farklı amaçlar için kullanın:

- Bir değerin nerede tanımlandığını kontrol etmeniz gerektiğinde, [PortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portionformat/) gibi bir yerel biçim nesnesini okuyun veya değiştirin.
- Son, oluşturulmuş sonucu gerektiğinde, [PortionFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portionformat/geteffective/) tarafından döndürülen etkili veri nesnesini okuyun. Etkili veri yalnızca okunabilir.

Örnekleri çalıştırmadan önce, [Aspose.Slides for PHP via Java’yı kurun](/slides/tr/php-java/installation/).

## **Yerel, Kalıtılmış ve Etkili Değerleri Karşılaştırma**

Aşağıdaki tam örnek bir şekil oluşturur ve sunum, paragraf ve bölüm düzeylerinde yazı tipi yüksekliği uygular. Her adım, bu seviyelerde tanımlanan değerleri ve aynı metin bölümü için ortaya çıkan etkili değeri yazdırır. Ayrıca, biçimlendirme değişikliklerinden sonra etkili verinin yeniden okunması gerektiğini gösterir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // Önceki değişikliklerden sonra etkili veriyi oku.
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // İki farklı seviyede kalıtılmış değerleri tanımla.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // Bölümdeki yerel değer, her iki kalıtılmış değeri geçersiz kılar.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // Kalıtılmış bir değeri değiştirmek, mevcut yerel değeri geçersiz kılmaz.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // Yerel değer temizlenir. Bölüm artık paragraftan yeniden kalıtım alır.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // Paragraf değeri temizlenir. Sunum varsayılanı şimdi sonucu sağlar.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bu örnekte öncelik önce bölümün yerel biçimlendirmesi, ardından paragraf biçimlendirmesi ve sonunda sunum varsayılanıdır. Diğer nesnelerin farklı kalıtım zincirleri olabilir, ancak prensip aynı kalır: daha belirgin açık bir değer kazanır ve [getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portionformat/geteffective/) son sonucu döndürür.

## **Etkili Metin Özelliklerini Alın**

Metin biçimlendirmesi birkaç nesneye yayılmıştır:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/geteffective/) kenar boşlukları, sabitleme, otomatik sığdırma ve dikey metin yönü gibi metin‑çerçeve özelliklerini çözer.
- [TextStyle.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textstyle/geteffective/) her metin stili seviyesinin paragraf biçimlendirmesini çözer.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraphformat/geteffective/) hizalama, girinti ve madde işaretleri gibi paragraf özelliklerini çözer.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portionformat/geteffective/) yazı tipi yüksekliği, tip, renk, kalın ve italik gibi karakter özelliklerini çözer.

Sonraki örnek için `text-formatting.pptx` en az bir slayt ve boş olmayan bir metin çerçevesi içeren bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) içermelidir. AutoShape şekil koleksiyonunda herhangi bir konumda bulunabilir; kod uygun bir nesne arar ve kullanmadan önce doğrular.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Etkili 3D Özelliklerini Alın**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/geteffective/) tüm çözülmüş 3D ayarlarını gruplayan tek bir etkili veri nesnesi döndürür. Its [getCamera](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/geteffective/) ve [getBevelBottom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/geteffective/) metodları ilgili etkili verileri sunar. Bu ilgili ayarları birlikte okumak, bir şeklin son 3D görünümünü anlamayı kolaylaştırır.

Bu örnek için `shape-3d.pptx` ilk slaytında en az bir şekil içermelidir. Çıktının varsayılanların dışında değerler içermesini istiyorsanız, o şekle 3D kamera, aydınlatma veya köşe ayarları uygulayın.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Etkili Tablo Biçimlendirmesini Alın**

Tablo biçimlendirmesi tablo stilinden ve tabloya, bir sütuna, bir satıra ya da tek bir hücreye uygulanan biçimlerden gelebilir. Açıkça tanımlanan dolgu çakışmalarında öncelik hücre, satır, sütun ve ardından tüm tablo şeklindedir. Bir hücrenin etkili biçimi, o hücreyi çizerken kullanılan son biçimdir.

Bu örnek için `table-formatting.pptx` ilk slaytında en az bir tablo içermelidir. Tablo en az bir satır ve bir sütun içermelidir. Kod, `getShapes()->get_Item(0)`'ın bir tablo olduğunu varsaymak yerine bir [Table](https://reference.aspose.com/slides/tr/php-java/aspose.slides/table/) arar.

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Renk ihtiyacınız varsa ve yalnızca dolgu türü değil, önce etkili [getFillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/geteffective/) değerini kontrol edin, ardından o türe göre uygulanacak metodu okuyun—örneğin katı dolgu için [getSolidFillColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/geteffective/).

## **Değişikliklerden Sonra Etkili Veriyi Yeniden Okuyun**

Etkili veri, çözülme anındaki biçimlendirme hiyerarşisini tanımlar. Hiyerarşiye katılabilecek herhangi bir şeyi değiştirdikten sonra `getEffective` metodunu tekrar çağırın; bunlar şunları içerir:

- nesnenin yerel biçimlendirmesi;
- paragraf veya metin‑çerçeve varsayılanları;
- bir tablo stili, tablo, sütun, satır veya hücre biçimi;
- düzen veya ana slayt biçimlendirmesi;
- tema verileri veya sunum‑seviyesi varsayılanları;
- bir slayta atanan düzen veya ana slayt.

Etkili veri nesnesini kalıcı bir anlık görüntü olarak saklamayın. Aspose.Slides bazı etkili verileri dahili olarak önbelleğe alabilir ve sonraki bir `getEffective` çağrısı bu verileri yenileyebilir. Bir değişiklik öncesi ve sonrası değerleri karşılaştırmanız gerekiyorsa, değişikliği yapmadan önce ihtiyaç duyduğunuz skaler değerleri (ör. yazı tipi yüksekliği, renk, hizalama veya köşe genişliği) kendi değişkenlerinize kopyalayın.

Bir değeri değiştirmek için ilgili yerel biçim nesnesini güncelleyin ve ardından sonucu doğrulamak için `getEffective` çağırın. Etkili veri nesneleri kendileri yalnızca okunabilir.

## **SSS**

**Etkili bir değerin hangi seviyeden geldiğini nasıl öğrenebilirim?**

Etkili veri, son değeri içerir, kaynağını değil. En özel seviyeden dışa doğru geçerli yerel nesneleri inceleyin. Metin için bu, bölüm, paragraf, metin çerçevesi, düzen, ana slayt, tema ve sunum varsayılanlarını içerebilir. `NAN` veya `null` gibi tanımsız değerler, aramanın başka bir seviyeye devam ettiğini gösterir.

**Hiçbir seviye bir özelliği tanımlamazsa ne olur?**

Aspose.Slides uygun PowerPoint ya da kütüphane varsayılanını çözer. Bu çözülen değer, yerel bir nesne açıkça tanımlamasa bile etkili veride görünür.

**Neden bazen etkili değer yerel değerle aynı olur?**

Yerel değer, kalıtım hesabını kazanmıştır. Bu, özelliğin nesne üzerinde açıkça ayarlandığı ve daha spesifik bir kuralın üzerine yazmadığı durumlarda beklenir.

**Yerel veriyi ne zaman etkili veri yerine kullanmalıyım?**

Belirli bir biçimlendirme seviyesini incelemek veya düzenlemek için yerel veriyi kullanın. Kalıtım, tema kuralları ve uygulanabilir stiller çözüldükten sonra son görünümü elde etmeniz gerektiğinde etkili veriyi kullanın. [Tam karşılaştırma örneği](#compare-local-inherited-and-effective-values) aynı iş akışında ikisini de gösterir.