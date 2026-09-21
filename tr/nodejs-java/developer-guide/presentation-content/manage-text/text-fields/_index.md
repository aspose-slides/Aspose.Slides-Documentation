---
title: JavaScript ile PowerPoint Sunumlarındaki Metin Alanlarını Yönetme
linktitle: Metin Alanları
type: docs
weight: 52
url: /tr/nodejs-java/text-fields/
keywords:
- metin alanı
- otomatik metin
- slayt numarası
- tarih ve zaman
- başlık
- altbilgi
- metin bölümü
- PowerPoint
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint sunumlarında Aspose.Slides for Node.js ile Java üzerinden metin alanlarını oluşturun, inceleyin, değiştirin ve kaldırın. Biçimlendirmeyi koruyun ve kaydedilen PPTX ve PPT dosyalarını doğrulayın."
---
## **Genel Bakış**

Bir metin paragrafı bölümlerden oluşur. Normal bir [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) gerçek metin içerir; bir alan bölümü ayrıca bir [Field](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/field/) içerir ve türü, slayt numarası veya tarih gibi otomatik güncellenen bir değeri tanımlar. İki bölüm aynı karakterleri gösterebilir ancak sadece biri alan içerir.

Bu bölümleri ayırt etmek için [Portion.getField](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/#getField) kullanın: normal metin için `null` döner. [Portion.addField](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/#addField) mevcut bir bölümü alana dönüştürür. Etiketi ve dinamik değerini ayrı bölümlerde tutun; böylece değeri dönüştürmek etiketin de değiştirilmesine yol açmaz.

Bu kılavuz, metin içindeki alanları, bunların biçimlendirmesini ve PPTX ve PPT olarak kaydedilmesini kapsar. Metin çerçeveleri ve paragraflar için [Manage Text](/slides/tr/nodejs-java/manage-text/) bölümüne bakın.

## **Slayt Numarası Alanı Oluşturma**

Aşağıdaki tam örnek, otomatik güncellenen bir sayıdan önce bir `Slide ` etiketi içeren bir metin kutusu oluşturur. Sayının boyutunu, kalınlığını ve rengini alanı eklemeden önce ayarlar, ardından kaydedilen sunumu yeniden açar ve alan türünü, metnini ve biçimlendirmesini kontrol eder. Girdi dosyasına ihtiyaç yoktur.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Yeni sunum slayt numarası 1 ile başlar; bu nedenle metin `Slide 1` olur ve her iki kontrol de `true` yazdırır. Sayı yeniden açıldıktan sonra da bir alan olarak kalır; literal `1` değildir. Doğrulamadaki indeksler, bu örnek tarafından oluşturulan şekil ve bölümleri referans alır.

## **Alan Türünü Seçme**

[FieldType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fieldtype/) önceden tanımlı değerlere erişmek için aşağıdaki yöntemleri sunar. Uygun değeri [addField](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/#addField) metoduna geçiriniz.

| Method | Purpose |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | Geçerli slayt numarası. |
| [getDateTime](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fieldtype/#getDateTime) | Uygulamanın varsayılan formatındaki tarih/saat. |
| [getDateTime1](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | Önceden tanımlı tarih veya birleştirilmiş tarih/saat formatları. |
| [getDateTime10](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | Önceden tanımlı saat formatları, saniye ve 12 saatlik saat seçenekleriyle. |
| [getHeader](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fieldtype/#getHeader) | Başlık alanı; aşağıdaki yer tutucu ve format sınırlamalarına bakınız. |
| [getFooter](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fieldtype/#getFooter) | Alt bilgi alanı. |

Örneğin, [getDateTime3](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fieldtype/#getDateTime3) İngilizce olarak gün, tam ay adı ve yılı temsil eder. Bunlar önceden tanımlı alan formatlarıdır; keyfi tarih‑formatı dizeleri değildir. [setLanguageId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) ile ayarlanan dil ve sunumu işleyen uygulama, görülen sonucu etkileyebilir.

## **Dahili Dizeden Alan Oluşturma**

[addField](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/#addField) metodunun dize aşırı yüklemesi, dahili bir alan tanımlayıcısını kabul eder. Başka bir uygulama tarafından sağlanan ve önceden tanımlı bir değeri olmayan bir tanımlayıcıyı korurken bunu kullanın. Ayrıca tanımlayıcıdan bir [FieldType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fieldtype/) oluşturabilirsiniz. [FieldType.getInternalString](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fieldtype/#getInternalString) bu tanımlayıcıyı inceleme amacıyla ortaya çıkarır.

Bu örnek, geri dönüş metni `Report-042` olan uygulamaya‑özel bir `custom-report-id` alanı depolar. Tanımlayıcı bir hesaplama kaydetmez: Aspose.Slides bilinmeyen bir tip için rapor kimliği üretmez. Bu tanımlayıcıyı anlayan uygulama, anlamını sağlamalı ve değerini güncellemelidir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Bu PPTX turundan sonra tür `custom-report-id` ve metin `Report-042` olur. `yyyy-MM-dd` gibi bir dize geçirmek bir alan türü adlandırır; özel bir tarih formatı yapılandırmaz. Keyfi bir formatta sabit bir tarih için normal metin kullanın.

## **Tarih/Saat Alanlarını İnceleme, Değiştirme ve Kaldırma**

Mevcut bir alanı [Field.setType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/field/#setType) ile değiştirin. Alanın var olduğunu kontrol edip türüne erişin. Otomatik güncellemeleri durdurmak için [Portion.removeField](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/#removeField) metodunu çağırın. Bu, alan ilişkilendirmesini kaldırırken bölümü ve mevcut metnini korur. Sabit bir değer gerekir ise alanı kaldırdıktan sonra o metni atayın.

Tarih/saat alanı işleme ile ilgili API ayarı için [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#setCurrentDateTime) bölümüne bakın. Aşağıdaki örnek, bir alanı normal metne dönüştürürken açıkça bir onay tarihini kullanır.

`sample.pptx` dosyasını indirin ve çalışma dizinine koyun. Dosya, `UpdatedAt` ve `ApprovedDate` adlı iki metin şekli içerir; her ikisi de bir tarih/saat alanına ve ayrıca normal metin etiketlerine sahiptir. Aşağıdaki örnek, normal slaytlardaki üst‑seviye metin şekillerini dolaşır. Tarih/saat alanlarını uzun‑tarih formatına çevirir ve italik yapar, diğer biçimlendirmelerini korur. Sadece `ApprovedDate` içindeki alanlar sabit metne dönüşür.

Onay tarihi 5 Nisan 2030’dur; JavaScript ay indeksleri sıfırdan başladığı için Nisan `3`’tür. Tarih bağımsızlığı için hem oluşturma hem de biçimlendirme aşamasında UTC kullanılır.

Örnek, dahili tanımlayıcılar `datetime` ve `datetime1`‑`datetime13`’ü tanır. Gruplar, tablolar, notlar, düzenler ve masterlar kendi metin kaplarını dolaşmayı gerektirir ve bu örnek kapsamı dışındadır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Yeniden açıldıktan sonra `UpdatedAt` tür `datetime3` olur ve dinamik kalır. `ApprovedDate` alan içermez ve `05 April 2030` metnini taşır. İki tarih bölümü de italik; orijinal punto, kalınlık ve renk ayarları aynı kalır. Normal metin etiketleri değişmez. Doğrulama, örnek dosyada verilen iki bilinen şeklin ilk bölümünü okur.

## **Metin Biçimlendirmesini Koru**

Alan eklerken, türünü değiştirirken veya kaldırırken mevcut bölümü kullanın. Bu işlemler bölümün biçimlendirmesini korur. Renk ya da italik gibi sadece gerekli özellikleri değiştirmek için [Portion.getPortionFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/#getPortionFormat) kullanın; örneklerde olduğu gibi.

Bir alanı güncellemek için tüm metin çerçevesini yeniden oluşturmayın: bu, orijinal bölüm sınırlarını ve bireysel biçimlendirmelerini kaybetmenize neden olabilir. Ayrıca, açıkça ayarlanmış biçimlendirme ile paragraf, düzen ya da tema tarafından devralınan biçimlendirmeyi ayırt edin. Daha geniş biçimlendirme seçenekleri için [Text Formatting](/slides/tr/nodejs-java/text-formatting/) bölümüne bakın.

## **Alanlar ve Üstbilgi/Altbilgi Yer Tutucuları**

Bir alan bir metin bölümünün parçasıdır. Bir yer tutucu, bir sunum rolüne sahip bir şekildir; örneğin alt bilgi ya da slayt numarası. Normal bir metin kutusuna alan eklemek, şekli yer tutucuya dönüştürmez.

Üstbilgi/altbilgi yöneticileri, slaytlar, düzenler ve masterlar üzerindeki yer tutucu metnini ve görünürlüğünü kontrol eder; bu da bağımlı slaytlara yayılır. Özel bir metin kutusundaki numara alanı, slayt‑numarası yer tutucusunu kullanmasanız bile faydalı olabilir. Öte yandan, yer tutucu görünürlüğünü değiştirmek, ilgisiz bir metin kutusundaki alanı kaldırmaz.

Önceden tanımlı üstbilgi ve altbilgi türleri, ilgili yer tutucuları oluşturmaz ya da içeriklerini sağlamaz. Özellikle, normal bir PowerPoint slaytında üstbilgi yer tutucusu yoktur; üstbilgiler not sayfalarına ve dağıtımlara aittir. Rastgele bir şekildeki üstbilgi ya da altbilgi alanının, bir yer tutucu yöneticisi aracılığıyla ayarlanan metni otomatik olarak alacağını varsaymayın. Bu iş akışı için [Presentation Headers and Footers](/slides/tr/nodejs-java/presentation-header-and-footer/) bölümüne bakın.

## **PPTX ve PPT Kısıtlamaları**

Kaydedip yeniden açtıktan sonra hem alan türünü hem de ortaya çıkan metni kontrol edin. Bir tanımlayıcının korunması, bir uygulamanın değerini hesaplayabileceği veya görüntüleyebileceği anlamına gelmez.

| Format | Field behavior and limitations |
|---|---|
| PPTX | İç alan tanımlayıcılarını metinle birlikte depolar. Tur‑içi kontrollerde, önceden tanımlı türler ve yukarıda kullanılan özel tanımlayıcı kaydetme ve yeniden açma sırasında korunmuştur. Bilinmeyen özel tip, geri dönüş metnini korur; otomatik hesaplama mantığı eklemez. Başka bir uygulama, desteklenmeyen tanımlayıcıları farklı şekilde ele alabilir. |
| PPT | Eski alan temsillerini kullanır ve daha sınırlı uyumluluğa sahiptir. Tur‑içi kontrollerde, slayt‑numarası ve önceden tanımlı tarih/saat alanları kaydetme ve yeniden açma sırasında korunmuştur. Normal bir slayt metin kutusundaki özel alan, yeniden açıldığında tanımlayıcısını korur ancak metni `*` olur; aynı bağlamdaki bir başlık alanı da `*` üretir. Özel alanların ya da desteklenmeyen alan bağlamlarının görünen metnini koruyacağını varsaymayın. |

Taşınabilir, sabit çıktı için, desteklenmeyen alanları normal metne dönüştürün ve kaydetmeden önce istediğiniz değeri açıkça atayın. Bu, seçilen metni korur ancak otomatik güncellemeleri kasıtlı olarak durdurur. Çalışma akışınızın bir parçası olarak hedef uygulamanın kendi alan yeniden hesaplamasını da test edin.

## **SSS**

**Bir gösterilen sayı veya tarihin alan mı olduğunu nasıl anlayabilirim?**  
[Portion.getField](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/#getField) metodunu inceleyin. `null` olmayan bir değer alanı gösterir; yalnızca görülen metin bunu belirleyemez.

**Bir alanı kaldırmak, metnini veya biçimlendirmesini kaldırır mı?**  
Hayır. [removeField](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/#removeField) mevcut bölümü normal metne dönüştürür. Belirli bir donmuş tarih ya da geri dönüş değeri gerekiyorsa, alanı kaldırdıktan sonra açıkça bir değer atayın.

**Bir dahili dize yeni bir tarih formatı veya formül tanımlayabilir mi?**  
Hayır. Bir alan türünü tanımlar. Bilinmeyen bir tanımlayıcı değerlendirme mantığı ya da tarih‑formatı deseni sağlamaz. Desteklenen önceden tanımlı türleri kullanın ya da değeri normal metin olarak biçimlendirin.

**Kaydettikten sonra sunumu tekrar kontrol etmek neden önemlidir?**  
Alan tanımlayıcıları, hesaplanan metin ve biçimlendirme ayrı ayrı doğrulanması gereken unsurlardır. Format dönüşümü, alan tanımlayıcısı hâlâ mevcut olsa bile görünen sonucu değiştirebilir.