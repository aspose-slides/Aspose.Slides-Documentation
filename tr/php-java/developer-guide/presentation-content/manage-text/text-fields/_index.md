---
title: PHP ile PowerPoint Sunumlarında Metin Alanlarını Yönetme
linktitle: Metin Alanları
type: docs
weight: 52
url: /tr/php-java/text-fields/
keywords:
- metin alanı
- otomatik metin
- slayt numarası
- tarih ve saat
- başlık
- alt bilgi
- metin bölümü
- PowerPoint
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint sunumlarındaki metin alanlarını oluşturun, inceleyin, değiştirin ve kaldırın. Biçimlendirmeyi koruyun ve kaydedilen PPTX ve PPT dosyalarını doğrulayın."
---
## **Genel Bakış**

Bir metin paragrafı bölümlerden oluşur. Olağan bir [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/) harfi metin içerirken; bir alan bölümü ayrıca bir [Field](https://reference.aspose.com/slides/tr/php-java/aspose.slides/field/) içerir ve bu alanın türü, slayt numarası veya tarih gibi otomatik olarak güncellenen bir değeri tanımlar. İki bölüm aynı karakterleri gösterebilir ancak sadece biri alan içerir.

Bunları ayırt etmek için [Portion::getField](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/#getField) kullanın: olağan metin için `null` döner. [Portion::addField](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/#addField) mevcut bir bölümü alana dönüştürür. Etiketi ve dinamik değerini ayrı bölümler olarak tutun; böylece değeri dönüştürmek etiketin de değiştirilmesine yol açmaz.

Bu kılavuz, metin içindeki alanları, bunların biçimlendirmesini ve PPTX ve PPT formatlarında kaydedilmesini kapsar. Metin çerçeveleri ve paragraflar için [Manage Text](/slides/tr/php-java/manage-text/) sayfasına bakın.

## **Slayt Numarası Alanı Oluşturma**

Aşağıdaki tam örnek, bir `Slide ` etiketi ve ardından otomatik olarak güncellenen bir sayı içeren bir metin kutusu oluşturur. Sayının boyutunu, kalınlığını ve rengini alana eklemeden önce ayarlar, ardından alanı ekler, kaydedilen sunumu yeniden açar ve alan tipini, metni ve biçimlendirmesini kontrol eder. Giriş dosyası gerektirmez.

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Yeni sunum slayt numarası 1 ile başlar; bu yüzden metin `Slide 1` olur ve her iki kontrol de `true` yazdırır. Sayı, yeniden açıldıktan sonra da alan olarak kalır; harfi `1` değildir. Doğrulamadaki indeksler, bu örnek tarafından oluşturulan şekil ve bölümlere karşılık gelir.

## **Alan Türü Seçme**

[FieldType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fieldtype/) önceden tanımlı değerler elde etmek için aşağıdaki yöntemleri sunar. Uygun değeri [addField](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/#addField) metoduna geçirin.

| Method | Purpose |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fieldtype/#getSlideNumber) | Mevcut slayt numarası. |
| [getDateTime](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fieldtype/#getDateTime) | Oluşturucu uygulamanın varsayılan biçiminde tarih/saat. |
| [getDateTime1](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fieldtype/#getDateTime9) | Önceden tanımlı tarih veya birleştirilmiş tarih/saat biçimleri. |
| [getDateTime10](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fieldtype/#getDateTime13) | Önceden tanımlı saat biçimleri; saniye ve 12‑saatli saat seçenekleri içerir. |
| [getHeader](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fieldtype/#getHeader) | Başlık alanı; aşağıdaki yer tutucu ve biçim sınırlamalarına bakın. |
| [getFooter](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fieldtype/#getFooter) | Alt bilgi (footer) alanı. |

Örneğin, [getDateTime3](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fieldtype/#getDateTime3) İngilizce olarak gün, tam ay adı ve yılı temsil eder. Bunlar önceden tanımlı alan biçimleridir, rastgele PHP tarih‑biçim dizesi değildir. [setLanguageId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setLanguageId) ile ayarlanan dil ve sunumu işleyen uygulama, görülen sonucu etkileyebilir.

## **Dahili Dizeyle Alan Oluşturma**

[addField](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/#addField) metodunun dize aşırı yüklemesi, dahili alan tanımlayıcısını kabul eder. Başka bir uygulama tarafından sağlanan ve önceden tanımlı değeri olmayan bir tanımlayıcıyı korumak istediğinizde bunu kullanın. Ayrıca tanımlayıcıdan bir [FieldType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fieldtype/#FieldType) oluşturabilirsiniz. [FieldType::getInternalString](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fieldtype/#getInternalString) bu tanımlayıcıyı inceleme amacıyla verir.

Bu örnek, geri dönüş metni `Report-042` olan uygulamaya özgü bir `custom-report-id` alanı saklar. Tanımlayıcı bir hesaplama kaydetmez: Aspose.Slides, bilinmeyen bir tip için rapor kimliği üretmez. Bu tanımlayıcıyı anlayan uygulama, anlamını sağlamalı ve değerini güncellemelidir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Bu PPTX döngüsünden sonra alan türü `custom-report-id` ve metin `Report-042` olur. `Y-m-d` gibi bir dize vermek bir alan türü adlandırır; özel bir tarih biçimi yapılandırmaz. İstediğiniz sabit bir tarih için, rastgele bir biçimde, normal metin kullanın.

## **Tarih/Saat Alanlarını İnceleme, Değiştirme ve Kaldırma**

Mevcut bir alanı [Field::setType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/field/#setType) ile değiştirin. Alanın var olduğunu kontrol ettikten sonra tipine erişin. Otomatik güncellemeyi durdurmak için [Portion::removeField](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/#removeField) çağırın. Bu, bölümü ve mevcut metnini tutarken alan ilişkisini kaldırır. Sabit bir değer gerekiyorsa, alanı kaldırdıktan sonra o metni atayın.

Tarih/saat alanı işleme ile ilgili API ayarı için [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#setCurrentDateTime) sayfasına bakın. Aşağıdaki örnek, bir alanı olağan metne dönüştürürken açık bir onay tarihini kullanır.

`sample.pptx` dosyasını indirin ve JavaBridge çalışma dizinine koyun ya da tam yolunu sunum oluşturucusuna geçirin. Dosyada iki adlandırılmış metin şekli bulunur: `UpdatedAt` ve `ApprovedDate`; her ikisi de tarih/saat alanı ve ayrıca olağan metin etiketleri içerir. Aşağıdaki örnek, normal slaytlardaki üst‑seviye metin şekillerinde dolaşır. Tarih/saat alanlarını uzun‑tarih biçimine çevirir ve italik yapar, diğer biçimlendirmelerini korur. Yalnızca `ApprovedDate` içindeki alanlar sabit metne dönüşür.

Yerleşik dahili tanımlayıcılar `datetime` ve `datetime1`‑`datetime13` tanınır. Gruplar, tablolar, notlar, düzenler ve ana slaytlar kendi metin kapsayıcılarını içerdiğinden bu örnek kapsamı dışındadır.

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Yeniden açıldıktan sonra `UpdatedAt` türü `datetime3` olur ve dinamik kalır. `ApprovedDate` artık alana sahip değildir ve `05 April 2030` metnini içerir. Her iki tarih bölümü de italik, özgün yazı tipi boyutu, kalınlık ve renkleri korunur. Olağan metin etiketleri değişmez. Doğrulama, örnek dosyada bulunan iki bilinen şeklin ilk bölümünü okur.

## **Metin Biçimlendirmesini Korumak**

Bir alan eklerken, türünü değiştirirken veya kaldırırken mevcut bölümü kullanın. Bu işlemler bölümün biçimlendirmesini korur. Renk ya da italik gibi yalnızca gerekli özellikleri değiştirmek için [Portion::getPortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/#getPortionFormat) kullanın; örneklerde olduğu gibi.

Bir alanı güncellemek için tüm metin çerçevesini yeniden inşa etmeyin: bu, orijinal bölüm sınırlarını ve bireysel biçimlendirmelerini kaybetmenize yol açabilir. Ayrıca açıkça ayarlanmış biçimlendirmeyi, paragraf, düzen ya da tema tarafından devralınan biçimlendirmeden ayırın. Daha geniş biçimlendirme seçenekleri için [Text Formatting](/slides/tr/php-java/text-formatting/) sayfasına bakın.

## **Alanlar ve Başlık/Alt Bilgi Yer Tutucuları**

Bir alan bir metin bölümünün parçasıdır. Bir yer tutucu, alt bilgi veya slayt numarası gibi bir sunum rolüne sahip bir şekildir. Olağan bir metin kutusuna alan eklemek, şekli yer tutucuya dönüştürmez.

Başlık/alt bilgi yöneticileri, slaytlar, düzenler ve ana slaytlarda yer tutucu metnini ve görünürlüğünü kontrol eder; bağımlı slaytlara da yayılır. Özel bir metin kutusundaki sayı alanı, slayt‑numarası yer tutucusunu kullanmasanız da işe yarayabilir. Tersine, yer tutucu görünürlüğünü değiştirmek, ilgili olmayan bir metin kutusundaki alanı kaldırmaz.

Önceden tanımlı başlık ve alt bilgi türleri, ilgili yer tutucuları oluşturmaz veya içerik sağlamaz. Özellikle, normal bir PowerPoint slaytında başlık yer tutucusu yoktur; başlıklar not sayfalarına ve el ilanlarına aittir. Rastgele bir şekildeki başlık veya alt bilgi alanının, yer tutucu yöneticisi aracılığıyla ayarlanan metni otomatik alacağını varsaymayın. Bu iş akışı için [Presentation Headers and Footers](/slides/tr/php-java/presentation-header-and-footer/) sayfasına bakın.

## **PPTX ve PPT Sınırlamaları**

Kaydetme ve yeniden açma sonrasında hem alan tipini hem de ortaya çıkan metni kontrol edin. Bir tanımlayıcının korunması, uygulamanın değerini hesaplayıp gösterebileceğini kanıtlamaz.

| Format | Alan davranışı ve sınırlamaları |
|---|---|
| PPTX | İç alan tanımlayıcılarını metinle birlikte saklar. Döngü kontrollerinde, önceden tanımlı tipler ve yukarıda kullanılan özel tanımlayıcı kaydedilip yeniden açıldıktan sonra da varlığını korur. Bilinmeyen özel tip geri dönüş metnini tutar; otomatik hesaplama mantığı kazanmaz. Başka bir uygulama, desteklenmeyen tanımlayıcıları farklı şekilde ele alabilir. |
| PPT | Eski alan temsilleri kullanır ve daha sınırlı uyumluluk sunar. Döngü kontrollerinde, slayt‑numarası ve önceden tanımlı tarih/saat alanları kaydedilip yeniden açıldıktan sonra da kalır. Olağan bir slayt metin kutusundaki özel alan, tanımlayıcısıyla yeniden açılır ancak metni `*` olur; aynı bağlamdaki başlık alanı da `*` üretir. Görünür metnin özel alanlarda veya desteklenmeyen bağlamlarda korunacağını varsaymayın. |

Taşınabilir, sabit bir çıktı için, desteklenmeyen alanları olağan metne dönüştürün ve kaydetmeden önce istediğiniz değeri açıkça atayın. Bu, seçilen metni korur ve otomatik güncellemeleri bilerek durdurur. Kendi alan yeniden hesaplaması iş akışınızın bir parçasıysa, hedef uygulamayı da test edin.

## **SSS**

**Görüntülenen bir sayı ya da tarih bir alan mı, nasıl anlayabilirim?**

[Portion::getField](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/#getField) metodunu inceleyin. Null olmayan değer bir alanı gösterir; yalnızca görünen metin bunu belirleyemez.

**Bir alanı kaldırmak, metni ya da biçimlendirmeyi kaldırır mı?**

Hayır. [removeField](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/#removeField) mevcut bölümü olağan metne çevirir. Sabit bir tarih ya da geri dönüş değeri istiyorsanız, ardından açık bir değer atayın.

**Dahili bir dize yeni bir tarih biçimi ya da formül tanımlayabilir mi?**

Hayır. Bu sadece bir alan türünü tanımlar. Bilinmeyen bir tanımlayıcı bir değerlendirici ya da PHP tarih‑biçimi kalıbı sağlamaz. Desteklenen önceden tanımlı bir tip kullanın ya da değeri kendiniz normal metin olarak biçimlendirin.

**Kaydedildikten sonra sunumu tekrar kontrol etmek neden gerekir?**

Alan tanımlayıcıları, hesaplanan metin ve biçimlendirme ayrı ayrı doğrulanması gereken unsurlardır. Biçim dönüşümü, alan tanımlayıcısı hâlâ mevcut olsa bile görünen sonucu değiştirebilir.