---
title: Python ile Sunum Tablolarını Yönet
linktitle: Tabloyu Yönet
type: docs
weight: 10
url: /tr/python-net/manage-table/
keywords:
- tablo ekle
- tablo oluştur
- tabloya eriş
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

PowerPoint’te bir tablo, bilgiyi sunmanın etkili bir yoludur. Hücrelerin (satırlar ve sütunlar) bir ızgara içinde düzenlenmesi doğrudan ve anlaşılması kolaydır.

Aspose.Slides, herhangi bir sunumda tablo oluşturmanıza, güncellemenize ve yönetmenize yardımcı olmak için [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) sınıfını, [Cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides/cell/) sınıfını ve diğer ilgili türleri sağlar.

## **Sıfırdan Tablo Oluşturma**

Bu bölüm, Aspose.Slides kullanarak bir slayta tablo şekli ekleyerek, satır ve sütunlarını tanımlayarak ve kesin boyutlar belirleyerek sıfırdan bir tablo oluşturmayı gösterir. Ayrıca hücreleri metinle doldurmayı, hizalamayı ve kenarlıkları ayarlamayı ve tablonun görünümünü özelleştirmeyi göreceksiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksine göre bir slayta referans alın.  
3. Bir sütun genişlikleri dizisi tanımlayın.  
4. Bir satır yüksekliği dizisi tanımlayın.  
5. Slayta bir [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) ekleyin.  
6. Her bir [Cell] üzerinde yineleme yapın ve üst, alt, sağ ve sol kenarlıklarını biçimlendirin.  
7. İlk iki satır ve ilk iki sütunun hücrelerini tek bir hücreye birleştirin.  
8. Bir [Cell]’in [TextFrame]’ine erişin.  
9. [TextFrame]’e metin ekleyin.  
10. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Python örneği, bir sunumda tablo oluşturmayı gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
with slides.Presentation() as presentation:
    # İlk slayta eriş.
    slide = presentation.slides[0]

    # Sütun genişliklerini ve satır yüksekliklerini tanımla.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Slayta bir tablo şekli ekle.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Her hücre için kenarlık biçimini ayarla.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # (satır 0, sütun 0) ile (satır 1, sütun 1) arasındaki hücreleri birleştir.
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Birleştirilmiş hücreye metin ekle.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Sunumu diske kaydet.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Standart Tablo Numarlaması**

Standart bir tabloda hücre numaralandırması doğrudan ve sıfır temellidir. Bir tablodaki ilk hücre (0, 0) (sütun 0, satır 0) olarak indekslenir.

Örneğin, 4 sütun ve 4 satırdan oluşan bir tabloda hücreler aşağıdaki gibi numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Aşağıdaki Python örneği, bu sıfır temelli numaralandırmayı kullanarak hücrelere nasıl başvurulacağını gösterir:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # İlk slayta eriş.
    slide = presentation.slides[0]

    # 4 sütun ve 4 satırla bir tablo ekle.
    table = slide.shapes.add_table(100, 50, [50, 50, 50, 50], [30, 30, 30, 30])

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            cell.text_frame.text = f"({column_index}, {row_index})"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Mevcut Bir Tabloya Erişme**

Bu bölüm, Aspose.Slides kullanarak bir sunumdaki mevcut bir tabloyu bulmayı ve onunla çalışmayı açıklar. Tabloyu bir slaytta bulmayı, satır, sütun ve hücrelerine erişmeyi ve içeriği ya da biçimlendirmeyi güncellemeyi öğreneceksiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Tabloyu içeren slayta indeksine göre referans alın.  
3. Tüm [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) nesneleri arasında tablo bulunana kadar yineleme yapın.  
4. Tabloyla çalışmak için [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) nesnesini kullanın.  
5. Değiştirilmiş sunumu kaydedin.

{{% alert color="info" title="Note" %}}
Slayt birden fazla tablo içeriyorsa, ihtiyacınız olan tabloyu `alternative_text` özelliğine göre aramak daha iyidir.
{{% /alert %}}

Aşağıdaki Python örneği, mevcut bir tabloya nasıl erişileceğini ve onunla nasıl çalışılacağını gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# PPTX dosyasını yüklemek için Presentation sınıfının bir örneğini oluştur.
with slides.Presentation("sample.pptx") as presentation:
    # İlk slayta eriş.
    slide = presentation.slides[0]

    table = None

    # Şekilleri döngüyle gez ve bulunan ilk tabloya referans ver.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # İlk satırdaki ilk hücrenin metnini ayarla.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Değiştirilmiş sunumu diske kaydet.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Metin Çerçevesine Sahip Hücreyi Bulma**

Genel metin işleme kodu bir tablodan bir [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) aldığında, sahip olduğu [Cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides/cell/) nesnesini almak için [TextFrame.parent_cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/parent_cell/) özelliğini kullanın. Bir tablo hücresi metin çerçevesi için, [TextFrame.parent_cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/parent_cell/) ayarlıdır ve [TextFrame.parent_shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/parent_shape/) `None` değerindedir; tablo kendisi bir şekildir.

Hücre koordinatları, yalnızca okuma amaçlı olan [Cell.first_column_index](https://reference.aspose.com/slides/tr/python-net/aspose.slides/cell/first_column_index/) ve [Cell.first_row_index](https://reference.aspose.com/slides/tr/python-net/aspose.slides/cell/first_row_index/) özellikleri üzerinden elde edilir. [TextFrame.parent_cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/parent_cell/) da yalnızca okuma amaçlıdır: sahibine bir yönlendirme sağlar ancak sahipliği değiştirmez. Her zaman döndürülen hücreyi `None` için kontrol edin.

Tablo‑hücre ve şekil sahiplerini tanımlayan, SmartArt düğümleriyle ilişkili şekilleri de içeren tam örnek için [Search and Replace Text](/slides/tr/python-net/search-and-replace-text/) bölümüne bakın.

## **Tablolarda Metni Hizalama**

Bu bölüm, Aspose.Slides kullanarak tablo hücreleri içindeki metnin yerleşimini nasıl kontrol edeceğinizi gösterir. Metni bir hücrede dikey olarak tutturmayı ve metnin akış yönünü değiştirmeyi öğreneceksiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksine göre slayta referans alın.  
3. Slayta bir [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) nesnesi ekleyin.  
4. Tablodan bir [Cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides/cell/) nesnesine erişin.  
5. Hücredeki metni dikey olarak ortalayın ve metin yönünü ayarlayın.  
6. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Python örneği, bir tablodaki metni nasıl hizalayacağınızı gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluştur.
with slides.Presentation() as presentation:
    # İlk slayta eriş.
    slide = presentation.slides[0]

    # Sütun genişliklerini ve satır yüksekliğini tanımla.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Slayta bir tablo şekli ekle.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Metni ortala ve dikey yönelim ayarla.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Sunumu diske kaydet.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Tablo Düzeyinde Metin Biçimlendirmesini Ayarlama**

Bu bölüm, Aspose.Slides içinde tablo düzeyinde metin biçimlendirmesi uygulamayı gösterir; böylece her hücre tutarlı, birleşik bir stil miras alır. Yazı tipi boyutlarını, hizalamaları ve kenar boşluklarını küresel olarak ayarlamayı öğreneceksiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksine göre slayta referans alın.  
3. Slayta bir [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) ekleyin.  
4. Metin için yazı tipi boyutunu (yazı tipi yüksekliğini) ayarlayın.  
5. Paragraf hizalamasını ve kenar boşluklarını ayarlayın.  
6. Dikey metin yönünü ayarlayın.  
7. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Python örneği, bir tablodaki metne tercih ettiğiniz biçimlendirme seçeneklerini nasıl uygulayacağınızı gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluştur
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Tüm tablo hücreleri için yazı tipi boyutunu ayarla.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Tüm tablo hücreleri için sağa hizalı metin ve sağ kenar boşluğu ayarla.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Tüm tablo hücreleri için dikey metin yönelimini ayarla.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Yerleşik Tablo Stillerini Uygulama**

Aspose.Slides, kod içinde doğrudan önceden tanımlanmış stiller kullanarak tabloları biçimlendirmenize olanak tanır. Örnek, bir tablo oluşturmayı, yerleşik bir stil uygulamayı ve sonucu kaydetmeyi gösterir—bu, tutarlı ve profesyonel bir formatlamayı sağlamanın etkili bir yoludur.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Tabloların En–Boy Oranını Kilitleme**

Bir şeklin en–boy oranı, boyutlarının oranıdır. Aspose.Slides, tablolar ve diğer şekiller için en–boy oranını kilitlemenizi sağlayan `aspect_ratio_locked` özelliğini sunar.

Aşağıdaki Python örneği, bir tablo için en–boy oranını nasıl kilitleyeceğinizi gösterir:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Bir tablonun tamamı ve hücrelerindeki metin için sağ‑dan‑sol (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, bir [right_to_left](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/right_to_left/) özelliği sunar ve paragraflar [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/right_to_left/) özelliğine sahiptir. Her ikisini de kullanmak, hücre içindeki doğru RTL sırasını ve renderlamayı sağlar.

**Kullanıcıların final dosyasında bir tabloyu hareket ettirmesini veya yeniden boyutlandırmasını nasıl engelleyebilirim?**

[shape locks](/slides/tr/python-net/applying-protection-to-presentation/) kullanarak hareket ettirme, yeniden boyutlandırma, seçim vb. işlemleri devre dışı bırakın. Bu kilitler tablolara da uygulanır.

**Bir hücrenin arka planı olarak bir görüntü eklemek destekleniyor mu?**

Evet. Bir hücre için bir [picture fill](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/) ayarlayabilirsiniz; görüntü, seçilen moda (germe ya da döşeme) göre hücre alanını kaplar.