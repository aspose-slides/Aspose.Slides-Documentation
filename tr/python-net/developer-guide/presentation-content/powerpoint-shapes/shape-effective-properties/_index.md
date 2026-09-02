---
title: Python'da Sunumlardan Şekil Etkili Özelliklerini Al
linktitle: Etkili Özellikler
type: docs
weight: 50
url: /tr/python-net/shape-effective-properties/
keywords:
- şekil özellikleri
- kamera özellikleri
- ışık rig'i
- köşe şekli
- metin çerçevesi
- metin stili
- font yüksekliği
- dolgu biçimi
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'i kullanarak PowerPoint sunumlarında yerel, miras alınan ve etkili şekil biçimlendirmesini ayırt etmeyi öğrenin."
---
## **Yerel, Miras Alınan ve Etkili Özellikleri Anlama**

PowerPoint biçimlendirmesi birkaç kaynaktan gelebilir. Bir nesne üzerinde doğrudan depolanan değer **yerel değer** olarak adlandırılır. Bu değer ayarlanmamışsa, PowerPoint bir paragraf varsayılanı, bir metin stili, bir düzen ya da ana slayt, bir tema veya sunum düzeyindeki varsayılanlar gibi üst biçimlendirme kaynaklarına bakar. Bu değerler **miras alınan değerler** olarak adlandırılır. Tüm hiyerarşi çözüldükten sonra kalan değer **etkili değer** olarak adlandırılır ve nesneyi renderlamak için kullanılır.

Örneğin, bir metin bölümü kendi font yüksekliğini tanımlamayabilir. Yerel [font_height](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ibaseportionformat/font_height/) değeri `float("nan")` olur; bu, “burada ayarlanmamış” anlamına gelir. Bölüm, yüksekliği paragrafından, sunumun varsayılan metin stilinden veya başka bir geçerli kaynaktan miras alabilir. Bölüm formatı üzerinde [get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iportionformat/get_effective/) çağrısı, son çözülmüş yüksekliği döndürür.

- Bir değer nerede tanımlanmışsa kontrol etmek istediğinizde, [IPortionFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iportionformat/) gibi bir yerel biçim nesnesini okuyun veya değiştirin.  
- Son, renderlanmış sonucu istediğinizde, [IPortionFormatEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iportionformateffectivedata/) gibi bir etkili veri nesnesini okuyun. Etkili veri sadece okunur.

## **Yerel, Miras Alınan ve Etkili Değerleri Karşılaştırma**

Aşağıdaki tam örnek bir şekil oluşturur ve sunum, paragraf ve bölüm seviyelerinde font yüksekliği uygular. Her adım, bu seviyelerde tanımlanan değerleri ve aynı metin bölümü için ortaya çıkan etkili değeri yazdırır. Ayrıca, biçimlendirme değişikliklerinden sonra etkili verinin neden yeniden okunması gerektiğini gösterir.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # Önceki değişikliklerden sonra etkili veriyi oku.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # İki farklı seviyede miras alınan değerleri tanımla.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Bölümdeki yerel bir değer, her iki miras alınan değeri de geçersiz kılar.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Bir miras alınan değeri değiştirmek, mevcut bir yerel değeri geçersiz kılmaz.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Yerel değeri temizle. Bölüm artık paragraftan tekrar miras alır.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Paragraf değerini temizle. Sunum varsayılanı şimdi sonucu sağlar.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

Bu örnekte öncelik bölüm yerel biçimlendirmesi, ardından paragraf biçimlendirmesi ve son olarak sunum varsayılanıdır. Diğer nesnelerin farklı miras zincirleri olabilir, ancak prensip aynıdır: daha spesifik açık bir değer kazanır ve [get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iportionformat/get_effective/) son sonucu döndürür.

## **Etkin Metin Özelliklerini Alma**

Metin biçimlendirmesi birkaç nesneye yayılmıştır:

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/tr/python-net/aspose.slides/itextframeformat/get_effective/) kenar boşlukları, sabitleme, otomatik sığdırma ve dikey metin yönü gibi metin çerçevesi özelliklerini çözer.  
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/tr/python-net/aspose.slides/itextstyle/get_effective/) her metin stili seviyesindeki paragraf biçimlendirmesini çözer.  
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iparagraphformat/get_effective/) hizalama, girinti ve madde işaretleri gibi paragraf özelliklerini çözer.  
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iportionformat/get_effective/) font yüksekliği, yazı tipi, renk, kalın ve italik gibi karakter özelliklerini çözer.

Sonraki örnek için `text-formatting.pptx` en az bir slayt ve boş olmayan bir metin çerçevesi içeren bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) içermelidir. AutoShape, şekil koleksiyonunda herhangi bir konumda bulunabilir; kod uygun bir nesne arar ve kullanmadan önce doğrular.

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **Etkin 3D Özelliklerini Alma**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ithreedformat/get_effective/) tüm çözülmüş 3D ayarlarını bir araya getiren bir [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ithreedformateffectivedata/) nesnesi döndürür. Bu nesnenin [camera](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ithreedformateffectivedata/camera/), [light_rig](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), [bevel_top](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/) ve [bevel_bottom](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) özellikleri ilgili etkili verileri sunar. Bu ilişkili ayarları birlikte okumak, bir şeklin nihai 3D görünümünü anlamayı kolaylaştırır.

Bu örnek için `shape-3d.pptx` ilk slaytında en az bir şekil içermelidir. Çıktının varsayılanların dışındaki değerleri içermesini istiyorsanız, o şekle 3D kamera, aydınlatma veya köşe (bevel) ayarları uygulayın.

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **Etkin Tablo Biçimlendirmesini Alma**

Tablo biçimlendirmesi tablo stilinden ve tüm tablo, bir sütun, bir satır veya tek bir hücreye uygulanan formatlardan gelebilir. Açıkça tanımlanmış dolgu çakışmalarında öncelik sırası hücre, satır, sütun ve ardından tüm tablo şeklindedir. Bir hücrenin etkili formatı, o hücreyi çizmeye kullanılan son formattır.

Bu örnek için `table-formatting.pptx` ilk slaytında en az bir tablo içermelidir. Tablo en az bir satır ve bir sütun içermelidir. Kod, `shapes[0]` bir tablo varsayımı yerine bir [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) arar.

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

Renk ihtiyacınız varsa ve sadece dolgu tipini değil, önce etkili [fill_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ifillformateffectivedata/fill_type/) kontrol edin, ardından o tipe uygulanan özelliği okuyun; örneğin katı dolgu için [solid_fill_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) kullanılabilir.

## **Değişikliklerden Sonra Etkin Veriyi Tekrar Okuma**

Etkin veri, çözüldüğü anki biçimlendirme hiyerarşisini tanımlar. Hiyerarşiye katılabilecek herhangi bir şeyi değiştirdikten sonra `get_effective` çağrısını tekrar yapın; buna dahil:

- nesnenin yerel biçimlendirmesi;
- paragraf veya metin çerçevesi varsayılanları;
- bir tablo stili, tablo, sütun, satır veya hücre formatı;
- düzen veya ana slayt biçimlendirmesi;
- tema verileri veya sunum düzeyindeki varsayılanlar;
- bir slayta atanmış düzen veya ana.

Etkin veri nesnesini kalıcı bir anlık görüntü olarak tutmayın. Aspose.Slides bazı etkin verileri dahili olarak önbelleğe alabilir ve sonraki bir `get_effective` çağrısı bu verileri yenileyebilir. Bir değişiklik öncesi ve sonrası değerleri karşılaştırmanız gerekiyorsa, font yüksekliği, renk, hizalama veya köşe genişliği gibi ihtiyacınız olan skalarlara kendi değişkenlerinize kopyalayın, ardından değişikliği yapın.

Bir değeri değiştirmek için ilgili yerel format nesnesini güncelleyin ve sonuçları doğrulamak için `get_effective` çağrısı yapın. Etkin veri nesneleri kendileri sadece okunur.

## **SSS**

**Etkin bir değeri hangi seviyenin sağladığını nasıl anlayabilirim?**

Etkin veri sadece son değeri içerir, kaynağını değil. En spesifik seviyeden dışa doğru uygulanabilir yerel nesneleri inceleyin. Metin için bu, bölüm, paragraf, metin çerçevesi, düzen, ana, tema ve sunum varsayılanlarını içerebilir. `float("nan")` veya `None` gibi tanımsız değerler, aramanın başka bir seviyeye devam ettiğini gösterir.

**Hiçbir seviye bir özelliği tanımlamazsa ne olur?**

Aspose.Slides uygun PowerPoint veya kütüphane varsayılanını çözer. Çözülen bu değer, yerel bir nesne açıkça tanımlamasa bile etkili veride görünür.

**Bazen bir etkin değer yerel değerle aynı neden olur?**

Yerel değer miras hesabını kazanmıştır. Bu, özelliğin nesne üzerinde açıkça ayarlandığı ve daha spesifik bir kuralın onu geçersiz kılmadığı durumlarda beklenir.

**Yerel veri yerine ne zaman etkili veri kullanmalıyım?**

Belirli bir biçimlendirme seviyesini incelemek veya düzenlemek için yerel veri kullanın. Miras, tema kuralları ve uygulanabilir stiller çözüldükten sonraki nihai görünümü ihtiyacınız olduğunda etkili veri kullanın. [tam karşılaştırma örneği](#compare-local-inherited-and-effective-values) aynı iş akışında ikisini de gösterir.