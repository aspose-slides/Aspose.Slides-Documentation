---
title: PowerPoint Sunumlarında Python ile Java aracılığıyla Metin Alanlarını Yönetme
linktitle: Metin Alanları
type: docs
weight: 52
url: /tr/python-java/text-fields/
keywords:
- metin alanı
- otomatik metin
- slayt numarası
- tarih ve saat
- üstbilgi
- altbilgi
- metin bölümü
- PowerPoint
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint sunumlarında metin alanlarını oluşturun, inceleyin, değiştirin ve kaldırın. Biçimlendirmeyi koruyun ve kaydedilen PPTX ve PPT dosyalarını doğrulayın."
---
## **Genel Bakış**

Bir metin paragrafı bölümlerden oluşur. Normal bir [Portion](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/) gerçek metin içerir; bir alan bölümü ayrıca bir [Field](https://reference.aspose.com/slides/tr/python-java/aspose.slides/field/) içerir ve türü otomatik olarak güncellenen bir değeri belirler, örneğin bir slayt numarası veya tarih. İki bölüm aynı karakterleri gösterebilir ancak sadece biri bir alan içerir.

Bu ayırımı yapmak için [Portion.getField](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/#getField) kullanın: normal metin için `None` döner. [Portion.addField](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/#addField) mevcut bir bölümü alana dönüştürür. Etiketi ve dinamik değerini ayrı bölümlerde tutun, böylece değeri dönüştürmek etiketi de değiştirmez.

Bu kılavuz, metin içindeki alanları, bunların biçimlendirmesini ve PPTX ve PPT olarak kaydetmeyi ele alır. Metin çerçeveleri ve paragrafları için [Manage Text](/slides/tr/python-java/manage-text/) bölümüne bakın.

## **Slayt Numarası Alanı Oluşturma**

Aşağıdaki tam örnek, literal `Slide ` etiketi ve ardından otomatik olarak güncellenen bir sayı içeren bir metin kutusu oluşturur. Sayının boyutunu, kalınlığını ve rengini alanı eklemeden önce ayarlar, ardından kaydedilen sunumu yeniden açar ve alan türünü, metnini ve biçimlendirmesini denetler. Girdi dosyasına ihtiyaç yoktur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Yeni sunum slayt numarası 1 ile başlar, bu yüzden metin `Slide 1` olur ve her iki denetim de `True` yazar. Sayı yeniden açıldıktan sonra da bir alan olarak kalır; literal `1` değildir. Doğrulamadaki indeksler, bu örnek tarafından oluşturulan şekil ve bölümleri işaret eder.

## **Alan Türünü Seçme**

[FieldType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fieldtype/) önceden tanımlı değerleri elde etmek için aşağıdaki yöntemleri sağlar. Uygun değeri [addField](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/#addField) metoduna geçirin.

| Yöntem | Amaç |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fieldtype/#getSlideNumber) | Mevcut slayt numarası. |
| [getDateTime](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fieldtype/#getDateTime) | Render uygulamasının varsayılan biçimindeki tarih/saat. |
| [getDateTime1](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fieldtype/#getDateTime9) | Önceden tanımlı tarih ya da birleştirilmiş tarih/saat biçimleri. |
| [getDateTime10](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fieldtype/#getDateTime13) | Önceden tanımlı zaman biçimleri, saniye ve 12 saatli saat seçenekleriyle. |
| [getHeader](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fieldtype/#getHeader) | Bir üstbilgi alanı; aşağıdaki yer tutucu ve biçim sınırlamalarına bakın. |
| [getFooter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fieldtype/#getFooter) | Bir altbilgi alanı. |

Örneğin, [getDateTime3](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fieldtype/#getDateTime3) İngilizce olarak gün, tam ay adı ve yılı temsil eder. Bunlar önceden tanımlı alan biçimleridir, rastgele Python tarih‑biçim dizesi değildir. [setLanguageId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setLanguageId) ile ayarlanan dil ve sunumu işleyen uygulama, görüntülenen sonucu etkileyebilir.

## **Dahili Dizeden Alan Oluşturma**

[addField](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/#addField) yönteminin dize aşırı yüklemesi dahili bir alan tanımlayıcısını kabul eder. Başka bir uygulama tarafından sağlanan, önceden tanımlı bir değeri olmayan bir tanımlayıcıyı korurken kullanın. Ayrıca tanımlayıcıdan bir [FieldType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fieldtype/#FieldType) oluşturabilirsiniz. [FieldType.getInternalString](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fieldtype/#getInternalString) bu tanımlayıcıyı inceleme amaçlı ortaya çıkarır.

Bu örnek, `custom-report-id` adlı uygulamaya özgü bir alanı yedek metin `Report-042` ile depolar. Tanımlayıcı bir hesaplama kaydetmez: Aspose.Slides bilinmeyen bir tür için rapor kimliği üretmez. Bu tanımlayıcıyı anlayan uygulama, anlamını sağlayıp değerini güncellemelidir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Bu PPTX turundan sonra tür `custom-report-id` ve metin `Report-042` olur. `yyyy-MM-dd` gibi bir dize geçirmek bir alan türü adlandırır; özel bir tarih biçimi yapılandırmaz. İstediğiniz sabit bir tarihi rastgele bir biçimde göstermek için normal metin kullanın.

## **Tarih/Saat Alanlarını İnceleme, Değiştirme ve Kaldırma**

Mevcut bir alanı [Field.setType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/field/#setType) ile değiştirin. Alanın varlığını kontrol ettikten sonra türüne erişin. Otomatik güncellemeleri durdurmak için [Portion.removeField](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/#removeField) çağırın. Bu, alan ilişkisini kaldırırken bölümü ve mevcut metnini tutar. Sabit bir değer gerekiyorsa, alanı kaldırdıktan sonra o metni atayın.

Tarih/saat alanı işleme ile ilgili API ayarı için [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#setCurrentDateTime) bölümüne bakın. Aşağıdaki örnek, bir alanı normal metne dönüştürürken açık bir onay tarihi kullanır.

[Download sample.pptx](sample.pptx) ve çalışma dizinine koyun. Dosya, `UpdatedAt` ve `ApprovedDate` adlı iki metin şekli içerir; her biri bir tarih/saat alanına sahiptir ve ayrıca normal metin etiketleri bulunur. Aşağıdaki örnek, normal slaytlardaki üst‑seviye metin şekillerini dolaşır. Tarih/saat alanlarını uzun tarih biçimine çevirir ve italik yapar, diğer biçimlendirmelerini korur. Yalnızca `ApprovedDate` içindeki alanlar sabit metne dönüşür.

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # İngilizce ay adlarını sistem yerel ayarından bağımsız olarak kullanın.
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Yeniden açıldıktan sonra `UpdatedAt` tür `datetime3` olur ve dinamik kalır. `ApprovedDate` alan içermez ve `05 April 2030` metnini taşır. Her iki tarih bölümü de italik, özgün yazı tipi boyutu, kalınlık ayarı ve rengi korunur. Normal metin etiketleri değişmez. Doğrulama, sağlanan örnek dosyadaki iki bilinen şeklin ilk bölümünü okur.

## **Metin Biçimlendirmesini Korumak**

Alan eklerken, türünü değiştirirken veya kaldırırken mevcut bölümü kullanın. Bu işlemler, bölümün biçimlendirmesini korur. Renk ya da italik gibi yalnızca gerekli özellikleri değiştirmek için [Portion.getPortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/#getPortionFormat) kullanın.

Bir alanı güncellemek için tüm metin çerçevesini yeniden oluşturmayın: bu, orijinal bölüm sınırlarını ve bireysel biçimlendirmelerini kaybetmenize yol açabilir. Ayrıca, paragraf, düzen veya temadan devralınan biçimlendirmeyi açıkça ayarlanan biçimlendirmeden ayırın. Daha geniş biçimlendirme seçenekleri için [Text Formatting](/slides/tr/python-java/text-formatting/) bölümüne bakın.

## **Alanlar ve Üstbilgi/Altbilgi Yer Tutucuları**

Bir alan, bir metin bölümünün parçasıdır. Bir yer tutucu, slayt numarası veya altbilgi gibi bir sunum rolü taşıyan bir şekildir. Normal bir metin kutusuna alan eklemek, şekli yer tutucuya dönüştürmez.

Üstbilgi/altbilgi yöneticileri, slaytlarda, düzenlerde ve ana temalarda yer tutucu metni ve görünürlüğü kontrol eder, bağımlı slaytlara da yayar. Özel bir metin kutusundaki bir sayı alanı, slayt‑numarası yer tutucusunu kullanmasanız bile faydalı olabilir. Tersine, yer tutucu görünürlüğünü değiştirmek, alakasız bir metin kutusundaki alanı kaldırmaz.

Önceden tanımlı üstbilgi ve altbilgi türleri, ilgili yer tutucuları oluşturmaz ya da içeriklerini sağlamaz. Özellikle, normal bir PowerPoint slaytının üstbilgi yer tutucusu yoktur; üstbilgiler not sayfalarına ve dağıtımlara aittir. Rastgele bir şekildeki bir üstbilgi veya altbilgi alanının, yer tutucu yöneticisi aracılığıyla ayarlanan metni otomatik alacağını varsaymayın. Bu iş akışı için [Presentation Headers and Footers](/slides/tr/python-java/presentation-header-and-footer/) bölümüne bakın.

## **PPTX ve PPT Sınırlamaları**

Kaydedip yeniden açtıktan sonra hem alan türünü hem de ortaya çıkan metni kontrol edin. Bir tanımlayıcıyı korumak, bir uygulamanın değerini hesaplayabileceğini veya görüntüleyebileceğini kanıtlamaz.

| Biçim | Alan davranışı ve sınırlamaları |
|---|---|
| PPTX | İç alan tanımlayıcılarını alan metniyle birlikte depolar. Tur‑kontrollerinde, önceden tanımlı türler ve yukarıda kullanılan özel tanımlayıcı kaydedilip yeniden açıldıktan sonra da korunur. Bilinmeyen özel tür yedek metnini tutar; otomatik hesaplama mantığı eklemez. Başka bir uygulama, desteklenmeyen tanımlayıcıları farklı şekilde ele alabilir. |
| PPT | Eski alan temsillerini kullanır ve daha sınırlı uyumluluğa sahiptir. Tur‑kontrollerinde, slayt‑numarası ve önceden tanımlı tarih/saat alanları kaydedilip yeniden açıldıktan sonra korunur. Normal bir slayt metin kutusundaki özel bir alan tanımlayıcısıyla yeniden açıldığında metin `*` olur; aynı bağlamdaki bir üstbilgi alanı da `*` üretir. Özel alanların veya desteklenmeyen alan bağlamlarının görünen metnini koruyacağına güvenmeyin. |

Taşınabilir, sabit çıktı için desteklenmeyen alanları normal metne dönüştürün ve kaydetmeden önce istediğiniz değeri açıkça atayın. Böylece seçilen metin korunur ancak otomatik güncellemeler kasıtlı olarak durdurulur. İş akışınızın bir parçası olarak hedef uygulamanın kendi alan yeniden‑hesaplamasını da test edin.

## **SSS**

**Görüntülenen bir sayı ya da tarihin bir alan olup olmadığını nasıl anlayabilirim?**  
[Portion.getField](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/#getField) inceleyin. `None` olmayan bir değer alanı gösterir; yalnızca görüntülenen metin bunu söylemez.

**Bir alanı kaldırmak metni ya da biçimlendirmeyi kaldırır mı?**  
Hayır. [removeField](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/#removeField) mevcut bölümü normal metne dönüştürür. Belirli bir dondurulmuş tarih ya da yedek değer gerekiyorsa, kaldırma sonrası açık bir değer atayın.

**Dahili bir dize yeni bir tarih biçimi ya da formül tanımlayabilir mi?**  
Hayır. Bir alan türünü tanımlar. Bilinmeyen bir tanımlayıcı bir değerlendirici ya da Python tarih‑biçim kalıbı sağlamaz. Desteklenen önceden tanımlı türü kullanın veya değeri normal metin olarak kendiniz biçimlendirin.

**Sunumu kaydettikten sonra tekrar kontrol etmemin nedeni nedir?**  
Alan tanımlayıcıları, hesaplanan metin ve biçimlendirme ayrı ayrı doğrulanması gereken öğelerdir. Biçim dönüşümü, alan tanımlayıcısı hâlâ mevcut olsa bile görünen sonucu değiştirebilir.