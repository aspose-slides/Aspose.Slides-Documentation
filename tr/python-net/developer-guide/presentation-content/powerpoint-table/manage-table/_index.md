---
title: Python ile Sunum Tablolarını Yönetme
linktitle: Tabloyu Yönet
type: docs
weight: 10
url: /tr/python-net/manage-table/
keywords:
- tablo ekle
- tablo oluştur
- tabloya eriş
- en‑boy oranı
- metni hizala
- metin biçimlendirme
- tablo stili
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument slaytlarında tablo oluşturun ve düzenleyin. Tablo iş akışlarınızı hızlandırmak için basit kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'te bir tablo, bilgiyi sunmanın etkili bir yoludur. Hücre ızgarasında (satırlar ve sütunlar) düzenlenen bilgi, anlaşılması basit ve nettir.

Aspose.Slides, sunumlarda tablo oluşturmanıza, güncellemenize ve yönetmenize yardımcı olmak için [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) sınıfını, [Cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides/cell/) sınıfını ve diğer ilgili tipleri sağlar.

## **Sıfırdan Tablo Oluşturma**

Bu bölüm, bir slayta tablo şekli ekleyerek, satır ve sütunlarını tanımlayarak ve kesin boyutlar ayarlayarak Aspose.Slides ile sıfırdan bir tablo oluşturmayı gösterir. Ayrıca hücreleri metinle doldurmayı, hizalamayı ve kenarlıkları ayarlamayı ve tablonun görünümünü özelleştirmeyi göreceksiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayta referans alın.
3. Sütun genişliklerinin bir dizisini tanımlayın.
4. Satır yüksekliğinin bir dizisini tanımlayın.
5. Slayta bir [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) ekleyin.
6. Her bir [Cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides/cell/) üzerinde dolaşarak üst, alt, sağ ve sol kenarlıklarını biçimlendirin.
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.
8. Bir [Cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides/cell/) nin [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) nesnesine erişin.
9. [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) e metin ekleyin.
10. Değiştirilen sunumu kaydedin.

Aşağıdaki Python örneği, bir sunumda tablo oluşturmayı gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # İlk slayta erişin.
    slide = presentation.slides[0]

    # Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Slayta bir tablo şekli ekleyin.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Her hücre için kenarlık biçimini ayarlayın.
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
        
    # Hücreleri (satır 0, sütun 0) ile (satır 1, sütun 1) arasında birleştirin.
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Birleştirilen hücreye metin ekleyin.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Sunumu diske kaydedin.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Standart Tablo Numaralandırması**

Standart bir tabloda, hücre numaralandırması doğrudan ve sıfır tabanlıdır. Bir tablodaki ilk hücre (0, 0) (sütun 0, satır 0) olarak indekslenir.

Örneğin, 4 sütun ve 4 satır içeren bir tabloda hücreler şu şekilde numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Aşağıdaki Python örneği, bu sıfır tabanlı numaralandırmayı kullanarak hücrelere nasıl başvurulacağını gösterir:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **Mevcut Bir Tabloya Erişim**

Bu bölüm, Aspose.Slides kullanarak bir sunum içinde mevcut bir tabloyu bulma ve çalışma yöntemlerini açıklar. Tabloyu bir slaytta nasıl bulacağınızı, satır, sütun ve hücrelerine nasıl erişeceğinizi ve içeriği ya da biçimlendirmeyi nasıl güncelleyeceğinizi öğreneceksiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Tabloyu içeren slayta indeksine göre referans alın.
3. Tabloyu bulana kadar tüm [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) nesneleri arasında dolaşın.
4. Tabloyla çalışmak için [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) nesnesini kullanın.
5. Değiştirilen sunumu kaydedin.

{{% alert color="info" %}}
Slayt birden fazla tablo içeriyorsa, ihtiyacınız olan tabloyu `alternative_text` özelliğiyle aramanız daha iyidir.
{{% /alert %}}

Aşağıdaki Python örneği, mevcut bir tabloya nasıl erişileceğini ve onunla nasıl çalışılacağını gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# PPTX dosyasını yüklemek için Presentation sınıfını örnekleyin.
with slides.Presentation("sample.pptx") as presentation:
    # İlk slayta erişin.
    slide = presentation.slides[0]

    table = None

    # Şekiller arasında dolaşarak bulunan ilk tabloyu referans alın.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # İlk satırdaki ilk hücrenin metnini ayarlayın.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Değiştirilen sunumu diske kaydedin.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Tablolarda Metni Hizalama**

Bu bölüm, Aspose.Slides kullanarak tablo hücreleri içinde metin hizalamasını nasıl kontrol edeceğinizi gösterir. Hücrelerde yatay ve dikey hizalama ayarlamayı öğrenerek içeriğinizi net ve tutarlı tutabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayta referans alın.
3. Slayta bir [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) nesnesi ekleyin.
4. Tablodan bir [Cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides/cell/) nesnesine erişin.
5. Metni dikey olarak hizalayın.
6. Değiştirilen sunumu kaydedin.

Aşağıdaki Python örneği, bir tabloda metni nasıl hizalayacağınızı gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation() as presentation:
    # İlk slayta erişin.
    slide = presentation.slides[0]

    # Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Slayta bir tablo şekli ekleyin.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Metni ortalayın ve dikey yönlendirmeyi ayarlayın.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Sunumu diske kaydedin.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Tablo Düzeyinde Metin Biçimlendirmesini Ayarlama**

Bu bölüm, Aspose.Slides içinde tablo düzeyinde metin biçimlendirmesi uygulayarak her hücrenin tutarlı bir stil miras almasını nasıl sağlayacağınızı gösterir. Yazı tipi boyutları, hizalamalar ve kenar boşluklarını küresel olarak ayarlamayı öğreneceksiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayta referans alın.
3. Slayta bir [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) ekleyin.
4. Metin için yazı tipi boyutunu (yazı yüksekliği) ayarlayın.
5. Paragraf hizalamasını ve kenar boşluklarını ayarlayın.
6. Dikey metin yönünü ayarlayın.
7. Değiştirilen sunumu kaydedin.

Aşağıdaki Python örneği, bir tabloda metne tercih ettiğiniz biçimlendirme seçeneklerini nasıl uygulayacağınızı gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluşturur
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Tüm tablo hücreleri için yazı tipi boyutunu ayarlayın.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Tüm tablo hücreleri için sağa hizalanmış metin ve sağ kenar boşluğu ayarlayın.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Tüm tablo hücreleri için dikey metin yönelimini ayarlayın.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Yerleşik Tablo Stillerini Uygulama**

Aspose.Slides, kod içinde doğrudan tanımlı stiller kullanarak tabloları biçimlendirmenizi sağlar. Örnek, bir tablo oluşturmayı, yerleşik bir stil uygulamayı ve sonucu kaydetmeyi gösterir—tutarlı ve profesyonel bir biçimlendirme sağlamak için etkili bir yoldur.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Tabloların En‑Boy Oranını Kilitleme**

Bir şeklin en‑boy oranı, boyutlarının oranıdır. Aspose.Slides, tablolar ve diğer şekiller için en‑boy oranını kilitlemenizi sağlayan `aspect_ratio_locked` özelliğini sunar.

Aşağıdaki Python örneği, bir tablonun en‑boy oranını nasıl kilitleyeceğinizi gösterir:

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

## **SSS**

**Bir tablonun ve hücrelerindeki metnin tümü için sağ‑dan‑sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, `right_to_left` özelliğini, paragraf ise `ParagraphFormat.right_to_left` özelliğini sunar. İkisini birlikte kullanmak, hücreler içinde doğru RTL sırasını ve renderlamayı sağlar.

**Kullanıcıların son dosyada bir tabloyu hareket ettirmesini veya yeniden boyutlandırmasını nasıl engelleyebilirim?**

[shape locks](/slides/tr/python-net/applying-protection-to-presentation/) kullanarak hareket, yeniden boyutlandırma, seçim vb. işlemleri devre dışı bırakabilirsiniz. Bu kilitlemeler tablolar için de geçerlidir.

**Bir hücrenin içinde arka plan olarak bir resim eklemek destekleniyor mu?**

Evet. Bir hücre için [picture fill](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/) ayarlayabilirsiniz; görüntü, seçilen moda (germe veya döşeme) göre hücre alanını kaplar.