---
title: PowerPoint Sunumlarında Python ile Metin Alanlarını Yönetme
linktitle: Metin Alanları
type: docs
weight: 52
url: /tr/python-net/text-fields/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint sunumlarında metin alanlarını oluşturun, inceleyin, değiştirin ve kaldırın. Biçimlendirmeyi koruyun ve kaydedilen PPTX ve PPT dosyalarını doğrulayın."
---
## **Genel Bakış**

Bir metin paragrafı bölümlerden oluşur. Normal bir [Portion](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/) doğrudan metin içerir; bir alan bölümü ise otomatik olarak güncellenen bir değeri tanımlayan bir [Field](https://reference.aspose.com/slides/tr/python-net/aspose.slides/field/) içerir; örneğin slayt numarası veya tarih. İki bölüm aynı karakterleri gösterebilir ancak sadece biri alan içerir.

Onları ayırt etmek için [Portion.field](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/field/) kullanın: normal metin için `None` döner. [Portion.add_field](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/add_field/) mevcut bir bölümü alana dönüştürür. Etiketi ve dinamik değerini ayrı bölümlerde tutun, böylece değeri dönüştürmek etiketin de değiştirilmesine yol açmaz.

Bu kılavuz, metin içindeki alanları, bunların biçimlendirilmesini ve PPTX ile PPT olarak kaydedilmesini kapsar. Metin çerçeveleri ve paragraflar için [Manage Text](/slides/tr/python-net/manage-text/) bölümüne bakın.

## **Slayt Numarası Alanı Oluşturma**

Sonraki tam örnek, `Slide ` etiketi içeren ve ardından otomatik olarak güncellenen bir numara ekleyen bir metin kutusu oluşturur. Sayının boyutunu, kalınlığını ve rengini alan eklemeden önce ayarlar, ardından kaydedilen sunumu yeniden açar ve alan tipini, metni ve biçimlendirmeyi kontrol eder. Girdi dosyasına ihtiyaç yoktur.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

Yeni sunum slayt numarası 1 ile başlar, bu yüzden metin `Slide 1` olur ve her iki kontrol de `True` yazdırır. Yeniden açıldıktan sonra sayı bir alan olarak kalır; doğrudan `1` değildir. Doğrulamadaki indeksler bu örnek tarafından oluşturulan şekil ve bölümleri referans alır.

## **Bir Alan Türü Seçme**

[FieldType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fieldtype/) aşağıdaki önceden tanımlı değerleri sağlar. Uygun değeri [add_field](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/add_field/) metoduna aktarın.

| Değer | Amaç |
|---|---|
| [slide_number](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fieldtype/slide_number/) | Mevcut slayt numarası. |
| [date_time](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fieldtype/date_time/) | Sunum uygulamasının varsayılan biçiminde tarih/saat. |
| [date_time1](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fieldtype/date_time9/) | Önceden tanımlı tarih veya birleştirilmiş tarih/saat biçimleri. |
| [date_time10](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fieldtype/date_time13/) | Önceden tanımlı zaman biçimleri, saniyeler ve 12 saatlik saat seçenekleriyle. |
| [header](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fieldtype/header/) | Üstbilgi alanı; aşağıdaki yer tutucu ve biçim sınırlamalarına bakın. |
| [footer](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fieldtype/footer/) | Altbilgi alanı. |

Örneğin, [date_time3](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fieldtype/date_time3/) gün, tam ay adı ve yılı İngilizce olarak temsil eder. Bunlar önceden tanımlı alan biçimleridir, rastgele Python tarih biçim dizesi değildir. Bölümün [language_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/language_id/) ve sunumu işleyen uygulama gösterilen sonucu etkileyebilir.

## **İç Dizeden Alan Oluşturma**

[add_field](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/add_field/) metodunun dize aşırı yüklemesi, iç alan tanımlayıcısını kabul eder. Önceden tanımlı bir değeri olmayan başka bir uygulama tarafından sağlanan tanımlayıcıyı korurken bunu kullanın. Tanımlayıcıdan bir [FieldType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fieldtype/__init__/) da oluşturabilirsiniz. [FieldType.internal_string](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fieldtype/internal_string/) bu tanımlayıcıyı inceleme amacıyla ortaya çıkarır.

Bu örnek, `custom-report-id` adlı uygulamaya özgü bir alanı `Report-042` yedek metniyle saklar. Tanımlayıcı bir hesaplama kaydetmez: Aspose.Slides bilinmeyen bir tür için rapor kimlikleri üretmez. Bu tanımlayıcıyı anlayan uygulama, anlamını sağlamalı ve değerini güncellemelidir.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

Bu PPTX dönüşümünden sonra tür `custom-report-id` ve metin `Report-042` olur. `%Y-%m-%d` gibi bir dize geçirmek bir alan tipi adlandırır; özel bir tarih biçimi yapılandırmaz. Rasgele bir biçimde sabit bir tarih için normal metin kullanın.

## **Tarih/Saat Alanlarını İnceleme, Değiştirme ve Kaldırma**

Mevcut bir alanı [Field.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/field/type/) üzerinden okuyup değiştirebilirsiniz. Tipine erişmeden önce alanın var olduğunu kontrol edin. Otomatik güncellemeleri durdurmak için [Portion.remove_field](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/remove_field/) metodunu çağırın. Bu, alan ilişkilendirmesini kaldırırken bölümü ve mevcut metnini korur. Belirli bir sabit değere ihtiyacınız varsa, alanı kaldırdıktan sonra o metni atayın.

API ayarı için [Presentation.current_date_time](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/current_date_time/) bölümüne bakın. Aşağıdaki örnek, bir alanı normal metne dönüştürürken açık bir onay tarihini kullanır. İngilizce ay adı ikilisi, sabit tarihi sistem yerel ayarından bağımsız tutar.

[sample.pptx](sample.pptx) dosyasını indirin ve çalışma dizinine koyun. Dosya, `UpdatedAt` ve `ApprovedDate` adlı iki metin şekli içerir; her biri bir tarih/saat alanına ve normal metin etiketlerine sahiptir. Aşağıdaki örnek, normal slaytlardaki üst düzey metin şekillerini dolaşır. Tarih/saat alanlarını uzun tarih biçimine dönüştürür ve diğer biçimlendirmeyi korurken italik yapar. Yalnızca `ApprovedDate` içindeki alanlar sabit metin haline gelir.

Örnek, yerleşik iç tanımlayıcılar `datetime` ve `datetime1` ile `datetime13` arasında tanır. Gruplar, tablolar, notlar, düzenler ve ana slaytlar kendi metin kapsayıcılarının dolaşılmasını gerektirir ve bu örnek kapsamının dışındadır.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

Yeniden açıldıktan sonra `UpdatedAt` türü `datetime3` olur ve dinamik kalır. `ApprovedDate` alan içermez ve `05 April 2030` metnini taşır. Her iki tarih bölümü de italik olup, orijinal yazı tipi boyutu, kalın ayarı ve rengi korunur. Normal metin etiketleri değişmez. Doğrulama, sağlanan örnek içindeki iki bilinen şeklin ilk bölümünü okur.

## **Metin Biçimlendirmesini Korumak**

Bir alan eklerken, tipini değiştirirken veya kaldırırken mevcut bölümle çalışın. Bu işlemler bölümün biçimlendirmesini korur. Gereken yalnızca özellikleri değiştirmek için [Portion.portion_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/portion_format/) kullanın; örneklerde renk veya italik için olduğu gibi.

Bir alanı güncellemek için tüm bir metin çerçevesini yeniden oluşturmaktan kaçının: bu, orijinal bölüm sınırlarını ve bireysel biçimlendirmelerini kaybetmeye yol açabilir. Ayrıca, açıkça ayarlanmış biçimlendirmeyi paragraftan, düzenden veya temadan devralınan biçimlendirmeden ayırın. Daha geniş biçimlendirme seçenekleri için [Text Formatting](/slides/tr/python-net/text-formatting/) bölümüne bakın.

## **Alanlar ve Üstbilgi/Altbilgi Yer Tutucuları**

Bir alan, bir metin bölümünün parçasıdır. Yer tutucu ise altbilgi veya slayt numarası gibi bir sunum rolüne sahip bir şekildir. Normal bir metin kutusuna alan eklemek o şekli yer tutucuya dönüştürmez.

Üstbilgi/altbilgi yöneticileri, slaytlar, düzenler ve ana slaytlarda yer tutucu metin ve görünürlüğü kontrol eder, bağlı slaytlara yayılımı da içerir. Özel bir metin kutusundaki sayı alanı, slayt numarası yer tutucusunu kullanmasanız bile faydalı olabilir. Aksine, yer tutucu görünürlüğünü değiştirmek, alakasız bir metin kutusundaki alanı kaldırmaz.

Önceden tanımlı üstbilgi ve altbilgi tipleri, ilgili yer tutucuları oluşturmaz veya içeriklerini sağlamaz. Özellikle, normal bir PowerPoint slaytının üstbilgi yer tutucusu yoktur; üstbilgiler not sayfalarına ve el ilanlarına aittir. Rastgele bir şekildeki üstbilgi veya altbilgi alanının, yer tutucu yöneticisi tarafından yapılandırılan metni otomatik olarak alacağını varsaymayın. Bu iş akışı için [Presentation Headers and Footers](/slides/tr/python-net/presentation-header-and-footer/) bölümüne bakın.

## **PPTX ve PPT Kısıtlamaları**

Kaydedip yeniden açtıktan sonra hem alan tipini hem de ortaya çıkan metni kontrol edin. Bir tanımlayıcının korunması, bir uygulamanın değerini hesaplayabileceği veya gösterebileceği anlamına gelmez.

| Biçim | Alan davranışı ve kısıtlamalar |
|---|---|
| PPTX | İç alan tanımlayıcılarını alan metniyle birlikte depolar. Dönüşümlü kontrollerde, önceden tanımlı tipler ve yukarıda kullanılan özel tanımlayıcı kaydedilip yeniden açıldığında korunur. Bilinmeyen özel tip yedek metnini korur; otomatik hesaplama mantığı kazanmaz. Başka bir uygulama desteklenmeyen tanımlayıcıları farklı şekilde ele alabilir. |
| PPT | Eski alan temsillerini kullanır ve daha sınırlı uyumluluğa sahiptir. Dönüşümlü kontrollerde, slayt numarası ve önceden tanımlı tarih/saat alanları kaydedilip yeniden açıldığında korunur. Normal bir slayt metin kutusundaki özel bir alan, tanımlayıcısıyla birlikte `*` metniyle yeniden açılır; aynı bağlamda bir üstbilgi alanı da `*` üretir. Özel alanların veya desteklenmeyen alan bağlamlarının görünür metinlerini koruyacağına güvenmeyin. |

Taşınabilir, sabit çıktı için, desteklenmeyen alanları normal metne dönüştürün ve kaydetmeden önce istediğiniz değeri açıkça atayın. Bu, seçilen metni korur ancak otomatik güncellemeleri kasıtlı olarak durdurur. Kendi alan yeniden hesaplaması iş akışınızın bir parçasıysa hedef uygulamayı da test edin.

## **SSS**

**Gösterilen bir sayı veya tarihin alan olup olmadığını nasıl anlayabilirim?**

[Portion.field](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/field/) özelliğine bakın. `None` dışındaki bir değer bir alanı tanımlar; yalnızca gösterilen metin bunu belirtemez.

**Bir alanı kaldırmak metnini veya biçimlendirmesini de kaldırır mı?**

Hayır. [remove_field](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/remove_field/) mevcut bölümü normal metne dönüştürür. Belirli bir sabit tarih veya yedek değer gerekiyorsa, alanı kaldırdıktan sonra açık bir değer atayın.

**Bir iç dize yeni bir tarih biçimi veya formül tanımlayabilir mi?**

Hayır. Bir alan tipini tanımlar. Bilinmeyen bir tanımlayıcı bir değerlendirici veya Python tarih biçim dizesi sağlamaz. Desteklenen önceden tanımlı bir tip kullanın veya değeri kendiniz normal metin olarak biçimlendirin.

**Bir sunumu kaydettikten sonra neden tekrar kontrol etmeliyim?**

Alan tanımlayıcıları, hesaplanan metin ve biçimlendirme doğrulanması gereken ayrı öğelerdir. Biçim dönüştürmesi, alan tanımlayıcısı hâlâ mevcut olsa bile görünür sonucu değiştirebilir.