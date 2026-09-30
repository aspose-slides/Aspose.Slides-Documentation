---
title: Python ile Sunum Tablolarını Yönetme
linktitle: Tabloyu Yönet
type: docs
weight: 10
url: /tr/python-net/manage-table/
keywords:
- tablo ekle
- tablo oluştur
- tablo erişimi
- en-boy oranı
- metni hizala
- metin biçimlendirme
- tablo stili
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument slaytlarında tablolar oluşturun ve düzenleyin. Tablo iş akışlarınızı kolaylaştırmak için basit kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'teki tablolar bilgiyi satır ve sütunlara düzenler, böylece değerleri okumak ve karşılaştırmak daha kolay olur.

Aspose.Slides, sunumlarda tablolar oluşturmanıza, güncellemenize ve yönetmenize olanak tanıyan [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) ve [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) sınıflarını ve diğer türleri sağlar.

## **Sıfırdan Tablo Oluşturma**

Pozisyonunu, sütun genişliklerini ve satır yüksekliklerini belirterek bir tablo oluşturun. Slayta ekledikten sonra hücre kenarlıklarını biçimlendirebilir, hücreleri birleştirebilir ve metin ekleyebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksiyle slayta bir referans alın.  
3. Sütun genişliklerini puan cinsinden bir liste olarak tanımlayın.  
4. Satır yüksekliklerini puan cinsinden bir liste olarak tanımlayın.  
5. Slayta, [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) yöntemi aracılığıyla bir [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) nesnesi ekleyin.  
6. Her bir [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) üzerinde döngü yaparak üst, alt, sağ ve sol kenarlara biçimlendirme uygulayın.  
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.  
8. Birleşik hücreye, onun [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) özelliği üzerinden erişin.  
9. Birleşik hücreye metin atayın.  
10. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek, (100, 50) puan konumunda üç sütun ve beş satırdan oluşan bir tablo oluşturur. 5 puan genişliğinde kırmızı kenarlıklar uygular, ilk satırdaki ilk iki hücreyi birleştirir ve sonucu `table.pptx` olarak kaydeder.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Standart Bir Tablodaki Numaralandırma**

Standart bir tabloda hücre indisleri sıfır tabanlıdır ve (sütun, satır) sırasını kullanır. İlk hücre (0, 0) olarak indekslenir. Python'da bir hücreye `table.rows[row_index][column_index]` ile erişilir; bu ifadede satır indeksi önce gelir.

Örneğin, 4 sütun ve 4 satırdan oluşan bir tablodaki hücreler şu şekilde numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu örnek, yukarıda gösterilen 4 × 4 tabloyu, sütun genişlikleri ve satır yükseklikleri 70 puan ve 5 puan genişliğinde kırmızı hücre kenarlıklarıyla oluşturur. Koordinatlar hücre indislerini gösterir; örnek hücreleri boş bırakır ve tabloyu `StandardTables_out.pptx` olarak kaydeder.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mevcut Bir Tabloya Erişim**

Tablolar, bir slaydın şekil koleksiyonunda depolanır. Şekiller arasında dolaşarak bir tabloyu bulun, ardından hücrelerini okumak veya güncellemek için [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) sınıfını kullanın.

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfını kullanarak sunumu yükleyin.  
2. Tablonun bulunduğu slayta indeksine göre bir referans alın.  
3. [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) nesneleri arasında dolaşın ve bir tablo bulunduğunda durun. Slayt birden fazla tablo içeriyorsa, ihtiyacınız olanı belirlemek için [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) kullanın.  
4. Hedef hücredeki metni güncelleyin.  
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek, `UpdateExistingTable.pptx` dosyasını açar ve ilk slayttaki ilk tabloyu bulur. 0. sütun, 1. satırdaki hücreyi `New` olarak ayarlar ve sonucu `table1_out.pptx` olarak kaydeder. Girdi en az bir slayt içermeli ve o slayttaki ilk tablo en az bir sütun ve iki satır içermelidir.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

Mevcut bir tabloda bir satırı yeniden boyutlandırmak ve gerçek yüksekliğinin istenen minimumu neden aşabileceğini anlamak için [Satır Yüksekliğini Kontrol Et](/slides/tr/python-net/manage-rows-and-columns/#control-row-height) bölümüne bakın.

## **Bir Metin Çerçevesine Sahip Hücreyi Bulma**

Genel bir metin işleme kodu bir tablodan [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) aldığında, sahip olduğu [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) nesnesini almak için [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) özelliğini kullanın. Bir tablo hücresi metin çerçevesi için, [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) ayarlı ve [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) `None` değerindedir; tablo kendisi bir şekil olsa bile.

Hücre koordinatları, yalnızca okunabilir [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) ve [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) özellikleriyle elde edilebilir. [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) de yalnızca okunabilir: sahipliğe yönlendirme sağlar ancak sahipliği değiştirmez. Kullanımdan önce döndürülen hücrenin `None` olup olmadığını kontrol edin.

Tablo hücresi ve şekil sahiplerini, SmartArt düğümleriyle ilişkili şekilleri de tanımlayan eksiksiz bir örnek için [Metin Ara ve Değiştir](/slides/tr/python-net/search-and-replace-text/) bölümüne bakın.

## **Tabloda Metni Hizalama**

Bireysel tablo hücrelerinin dikey sabitlemesini ve metin yönünü kontrol edebilirsiniz. Bu bölüme ait örnek, metni ilk hücrede ortalar ve 270 derece döndürür.

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksiyle slayta bir referans alın.  
3. Slayta bir [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) nesnesi ekleyin.  
4. Tablodan bir [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) nesnesine erişin.  
5. İlk [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) nesnesine erişin ve metin ile rengini ayarlayın.  
6. Hücrenin [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) ve [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/) özelliklerini ayarlayın.  
7. Değiştirilmiş sunumu kaydedin.

Bu örnek, sütun genişlikleri 120 puan ve satır yükseklikleri 100 puan olan 4 × 4 bir tablo oluşturur. (0, 0) hücresindeki metni biçimlendirir, ilk satırdaki kalan hücrelere değer ekler ve sonucu `Vertical_Align_Text_out.pptx` olarak kaydeder.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Tablo Düzeyinde Metin Biçimlendirme Ayarlama**

[Tüm hücrelere metin biçimlendirmesi uygulamak için [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) yöntemini kullanın. Aşırı yüklemeleri bölüm, paragraf ve metin çerçevesi biçimlendirmesini kabul eder, böylece bireysel hücreler arasında yineleme yapmadan bu özellikleri ayarlayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfını kullanarak sunumu yükleyin.  
2. İndeksiyle slayta bir referans alın.  
3. Slayttan bir [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) nesnesine erişin.  
4. Metin için [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) ayarlayın.  
5. [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) ve [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) ayarlayın.  
6. [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) ayarlayın.  
7. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek, `table.pptx` dosyasını açar; bu dosya en az bir tablo içeren bir slayta sahip olmalıdır. Yazı tipini 25 puana, paragrafları sağa hizalamayı 20 puan sağ kenar boşluğu ile ayarlar ve metni dikey yapar. Biçimlendirilmiş sunum `result.pptx` olarak kaydedilir.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Tablo Stil Özelliklerini Almak**

[style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) yöntemiyle bir tablonun ön ayar stilini okuyabilir veya atayabilirsiniz. Bu örnek, bir tabloya [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) uygular, ön ayar adını yazdırır ve aynı ön ayarı ikinci bir tabloya atar. Her iki tablo da `table-style.pptx` içinde kaydedilir.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Tablonun En-Boy Oranını Kilitleme**

Bir tablonun en‑boy oranı, genişliğinin yüksekliğine oranıdır. Bu oranı bir tablo için kilitlemek üzere [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) özelliğini kullanın.

Aşağıdaki örnek, `pres.pptx` dosyasını açar; bu dosya en az bir tablo içeren bir slayta sahip olmalıdır. Mevcut kilit durumunu yazdırır, en‑boy oranı kilidini etkinleştirir, güncellenmiş durumu (`True`) yazar ve sonucu `pres-out.pptx` olarak kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Bir tablo ve hücrelerindeki metin için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, bir [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) özelliği sunar ve paragraflar da [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/) özelliğine sahiptir. Her ikisini de kullanmak, hücre içindeki doğru RTL sırasını ve renderlamasını sağlar.

**Kullanıcıların son dosyada bir tabloyu taşımasını veya yeniden boyutlandırmasını nasıl önleyebilirim?**

[şekil kilitleri](/slides/tr/python-net/applying-protection-to-presentation/) kullanarak taşıma, yeniden boyutlandırma, seçim vb. işlemleri devre dışı bırakabilirsiniz. Bu kilitler tablolara da uygulanır.

**Bir hücrenin arka planı olarak bir resim eklemek destekleniyor mu?**

Evet. Bir hücre için [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) ayarlayabilirsiniz; resim, seçilen moda (germe veya döşeme) göre hücre alanını kaplar.