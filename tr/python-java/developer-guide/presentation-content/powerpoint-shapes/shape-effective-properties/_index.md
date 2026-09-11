---
title: Python üzerinden Java ile Sunumlardan Şekil Etkili Özelliklerini Alın
linktitle: Etkili Özellikler
type: docs
weight: 50
url: /tr/python-java/shape-effective-properties/
keywords:
- şekil özellikleri
- kamera özellikleri
- ışık donanımı
- eğimli şekil
- metin çerçevesi
- metin stili
- yazı tipi yüksekliği
- dolgu biçimi
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarında yerel, devralınan ve etkili şekil biçimlendirmesini nasıl ayırt edeceğinizi öğrenin."
---
## **Yerel, Devralınan ve Etkili Özellikleri Anlamak**

PowerPoint biçimlendirmesi birkaç kaynaktan gelebilir. Bir nesne üzerinde doğrudan depolanan değer **yerel değerdir**. Bu değer ayarlanmamışsa, PowerPoint bir paragraf varsayılanı, bir metin stili, bir yerleşim veya ana slayt, bir tema veya sunum düzeyinde varsayılanlar gibi üst biçimlendirme kaynaklarına bakar. Bu değerler **devralınan değerler**dir. Tüm hiyerarşi çözüldükten sonra kalan değer **etkili değerdir**—nesneyi oluşturan değer.

Örneğin, bir metin bölümü kendi yazı tipi yüksekliğini tanımlamıyor olabilir. Yerel [getFontHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#getFontHeight) değeri `float("nan")` olur; bu “burada ayarlanmamış” anlamına gelir. Bölüm, paragrafından, sunumun varsayılan metin stilinden veya başka bir geçerli kaynaktan bir yükseklik devralabilir. Bölüm formatı üzerinde [getEffective](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/#getEffective) çağrısı, sonunda çözülen yüksekliği döndürür.

İki tür biçimlendirme verisini farklı amaçlar için kullanın:

- Bir değerin nerede tanımlandığını kontrol etmeniz gerektiğinde, örneğin [PortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/) gibi yerel bir format nesnesini okuyun veya değiştirin.
- Son, oluşturulmuş sonucu elde etmeniz gerektiğinde, `PortionFormatEffectiveData` gibi bir etkili veri nesnesini okuyun. Etkili veriler yalnızca okunabilir.

## **Yerel, Devralınan ve Etkili Değerleri Karşılaştırın**

Aşağıdaki tam örnek bir şekil oluşturur ve sunum, paragraf ve bölüm düzeylerinde yazı tipi yükseklikleri uygular. Her adım bu seviyelerde tanımlanan değerleri ve aynı metin bölümü için oluşan etkili değeri yazdırır. Ayrıca, biçimlendirme değişikliklerinden sonra etkili verilerin yeniden okunması gerektiğini gösterir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # Önceki değişikliklerden sonra etkili veriyi okuyun.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # İki farklı seviyede devralınan değerleri tanımlayın.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Bölümdeki yerel değer, her iki devralınan değerin üzerine yazar.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Devralınan bir değeri değiştirmek, mevcut bir yerel değerin üzerine yazmaz.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Yerel değeri temizleyin. Bölüm artık paragraftan yeniden devralır.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Paragraf değerini temizleyin. Sunum varsayılanı şimdi sonucu sağlar.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bu örnekte öncelik bölümün yerel biçimlendirmesi, ardından paragraf biçimlendirmesi ve son olarak sunum varsayılanı şeklindedir. Diğer nesnelerin farklı miras zincirleri olabilir, ancak prensip aynı kalır: daha özgül açık değer kazanır ve [getEffective](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/#getEffective) son sonucu döndürür.

## **Etkili Metin Özelliklerini Alın**

Metin biçimlendirmesi birkaç nesne arasında bölünmüştür:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#getEffective) kenar boşlukları, sabitleme, otomatik sığdırma ve dikey metin yönü gibi metin çerçevesi özelliklerini çözer.
- [TextStyle.getEffective](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textstyle/#getEffective) her metin stili düzeyi için paragraf biçimlendirmesini çözer.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#getEffective) hizalama, girinti ve madde işaretleri gibi paragraf özelliklerini çözer.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/#getEffective) yazı tipi yüksekliği, yazı tipi, renk, kalın ve eğik gibi karakter özelliklerini çözer.

Bir sonraki örnek için `text-formatting.pptx` dosyasında en az bir slayt ve boş olmayan bir metin çerçevesi içeren bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) bulunmalıdır. AutoShape, şekil koleksiyonundaki herhangi bir konumda olabilir; kod uygun bir nesne arar ve kullanmadan önce doğrular.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **Etkili 3D Özelliklerini Alın**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getEffective) tüm çözülen 3D ayarlarını gruplandıran bir `ThreeDFormatEffectiveData` nesnesi döndürür. `getCamera`, `getLightRig`, `getBevelTop` ve `getBevelBottom` metodları ilgili etkili verileri ortaya çıkarır. Bu ilgili ayarları bir arada okumak, bir şeklin son 3D görünümünü anlamayı kolaylaştırır.

Bu örnek için `shape-3d.pptx` dosyasında ilk slaytında en az bir şekil bulunmalıdır. Çıktının varsayılanların dışındaki değerleri içermesini istiyorsanız, o şekle 3D kamera, aydınlatma veya kiriş ayarları uygulayın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **Etkili Tablo Biçimlendirmesini Alın**

Tablo biçimlendirmesi tablo stilinden ve tabloya, bir sütuna, bir satıra veya bireysel bir hücreye uygulanan formatlardan gelebilir. Açıkça tanımlanan dolgu çakışmalarında öncelik hücre, satır, sütun ve ardından tüm tablo şeklindedir. Bir hücrenin etkili formatı, o hücreyi çizerken kullanılan son formattır.

Bu örnek için `table-formatting.pptx` dosyasında ilk slaytında en az bir tablo bulunmalıdır. Tablo en az bir satır ve bir sütun içermelidir. Kod, `getShapes().get_Item(0)` ifadesinin bir tablo olduğunu varsaymak yerine bir [Table](https://reference.aspose.com/slides/tr/python-java/aspose.slides/table/) arar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

Eğer sadece dolgu tipini değil, rengini de istiyorsanız, önce etkili `getFillType` metodunu kontrol edin ve ardından o tipe ait metodu okuyun—örneğin katı dolgu için `getSolidFillColor`.

## **Değişikliklerden Sonra Etkili Verileri Yeniden Okuyun**

Etkili veri, çözümleme anındaki biçimlendirme hiyerarşisini tanımlar. Hiyerarşiye katılabilecek herhangi bir şeyi değiştirdikten sonra [getEffective](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/#getEffective) metodunu tekrar çağırın; örnekler:

- nesnenin yerel biçimlendirmesi;
- paragraf veya metin çerçevesi varsayılanları;
- bir tablo stili, tablo, sütun, satır veya hücre formatı;
- yerleşim veya ana slayt biçimlendirmesi;
- tema verileri veya sunum düzeyi varsayılanları;
- bir slayta atanmış yerleşim veya ana slayt.

Etkili veri nesnesini kalıcı bir anlık görüntü olarak saklamayın. Aspose.Slides bazı etkili verileri dahili olarak önbelleğe alabilir ve sonraki bir [getEffective](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/#getEffective) çağrısı bu verileri yenileyebilir. Değişiklik öncesi ve sonrası değerleri karşılaştırmanız gerekiyorsa, değişikliği yapmadan önce ihtiyacınız olan tekil değerleri—örneğin yazı tipi yüksekliği, renk, hizalama veya kiriş genişliği—kendi değişkenlerinize kopyalayın.

Bir değeri değiştirmek için ilgili yerel format nesnesini güncelleyin ve ardından sonucu doğrulamak için [getEffective](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/#getEffective) çağırın. Etkili veri nesneleri kendileri yalnızca okunabilir.

## **SSS**

**Etkili bir değeri hangi seviyenin sağladığını nasıl öğrenebilirim?**

Etkili veri son değeri içerir, kaynağını değil. En özel seviyeden dışa doğru ilgili yerel nesneleri inceleyin. Metin için bu, bölüm, paragraf, metin çerçevesi, yerleşim, ana slayt, tema ve sunum varsayılanları olabilir. `float("nan")` veya `None` gibi tanımsız değerler, aramanın başka bir seviyeye devam ettiğini gösterir.

**Hiçbir seviye bir özelliği tanımlamazsa ne olur?**

Aspose.Slides uygun PowerPoint veya kütüphane varsayılanını çözer. Bu çözülen değer, yerel bir nesne açıkça tanımlamasa da etkili veride görünür.

**Neden bazen etkili değer yerel değerle aynı olur?**

Yerel değer, miras hesabını kazanmıştır. Bu, özelliğin nesne üzerinde açıkça ayarlandığı ve daha spesifik bir kuralın onu geçersiz kılmadığı durumlarda beklenen bir davranıştır.

**Ne zaman yerel veriyi, etkili veri yerine kullanmalıyım?**

Belirli bir biçimlendirme seviyesini incelemek veya düzenlemek için yerel veriyi kullanın. Miras, tema kuralları ve uygulanabilir stiller çözüldükten sonraki son görünüm gerektiğinde etkili veriyi kullanın. [Tam karşılaştırma örneği](#compare-local-inherited-and-effective-values) aynı iş akışında her ikisini de gösterir.