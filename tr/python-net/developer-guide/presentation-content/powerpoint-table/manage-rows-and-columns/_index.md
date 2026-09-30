---
title: PowerPoint Tablolarında Satır ve Sütunları Python ile Yönetme
linktitle: Satır ve Sütunlar
type: docs
weight: 20
url: /tr/python-net/manage-rows-and-columns/
keywords:
- tablo satırı
- tablo sütunu
- ilk satır
- tablo başlığı
- satır klonla
- sütun klonla
- satır kopyala
- sütun kopyala
- satır kaldır
- sütun kaldır
- satır metin biçimlendirme
- sütun metin biçimlendirme
- tablo stili
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint’te tablo satır ve sütunlarını yönetin ve sunum düzenlemeyi ve veri güncellemelerini hızlandırın."
---
## **Giriş**

Aspose.Slides for Python via .NET, PowerPoint sunumlarında tablo yapısını ve biçimlendirmesini [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) sınıfı aracılığıyla yönetmenizi sağlar. Başlık satırı belirleyebilir, satır ve sütunları klonlayabilir veya kaldırabilir ve bir satır veya sütunun tamamına metin biçimlendirmesi uygulayabilirsiniz.

Bu makale, bu işlemleri Python örnekleriyle açıklar. Ayrıca bir tablonun stil ön ayarını nasıl alacağınızı ve yeniden kullanabileceğinizi gösterir. Tablo satır ve sütun indeksleri sıfır tabanlıdır.

## **Satır Yüksekliğini Kontrol Et**

[Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) özelliğini kullanarak bir satırın minimum yüksekliğini puan cinsinden ayarlayabilirsiniz. Bu, sabit bir yükseklik değil, bir alt sınırdır. [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) gerçek yüksekliği döndürür ve yalnızca okunabilir. Satırı [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/) üzerinden erişin.

Örnek, ilk slayttaki ilk şekil olan tabloyu içeren [row-height-input.pptx](row-height-input.pptx) dosyasını yükler. İlk satır 70 puanda başlar. Hücreler 18 puan Arial metin, sarma ve 6 puan üst ve alt kenar boşluğu kullanır; ikinci sütundaki uzun metin birden çok satıra sarılır. Örnek, minimumu 100 puana artırır, ardından 20 puana düşürür, her değişiklikten sonra gerçek yüksekliği yazdırır ve iki sonucu kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

Sağlanan sunumla, minimumu artırmak satıra boşluk ekler. Minimumu azaltmak bu ekstra boşluğu kaldırır, ancak gerçek yükseklik 20 puandan büyük kalır çünkü metin ve hücre kenar boşlukları daha fazla alana ihtiyaç duyar. Sadece minimumu azaltmak, içeriğin gerektirdiği boşluktan daha düşük bir satır yüksekliğine zorlayamaz.

Gerçek yüksekliği etkileyen birkaç faktör:

- **Metin ve yazı tipi boyutu:** daha uzun metin, açık satır sonları veya daha büyük bir yazı tipi daha fazla dikey alan gerektirebilir.
- **Sarma ve sütun genişliği:** sarma etkinleştirildiğinde, daha dar bir [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) daha fazla satır oluşturabilir. Daha geniş bir sütun dikey alanda tasarruf sağlayabilir.
- **Hücre kenar boşlukları:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) ve [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) dikey boşluk ekler. [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) ve [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) metin için kullanılabilir genişliği azaltır ve ek sarmalara neden olabilir.

Birleştirilmiş hücre olmayan bu tablo için, en çok dikey alan gerektiren hücre, tüm satırın içerik kaynaklı alt sınırını belirler. Satırı daha kısa yapmak için metni kısaltmanız, yazı tipi boyutunu veya kenar boşluklarını azaltmanız veya bir sütunu genişletmeniz gerekebilir.

Aşağıdaki görseller aynı tabloyu aynı ölçekte gösterir. Bu çalıştırmada, gerçek yükseklikler sırasıyla 70, 100 ve 55,2 puan oldu: son satır 20 puanlık minimumun üzerinde kaldı. Kesin metin ölçüleri ortamınızda mevcut olan yazı tiplerine göre değişebilir. Kaydedilmiş sonuçları indirin: [artırılmış minimum](row-height-increased.pptx) ve [azaltılmış minimum](row-height-decreased.pptx).

| Orijinal: minimum 70 pt, gerçek 70 pt | Artırılmış: minimum 100 pt, gerçek 100 pt | Azaltılmış: minimum 20 pt, gerçek 55.2 pt |
| --- | --- | --- |
| ![70 puanlık ilk satırla orijinal tablo.](row-height-before.png) | ![İlk satırın minimumu 100 puana artırıldıktan sonra tablo.](row-height-increased.png) | ![İlk satırın minimumu 20 puana azaltıldıktan sonra tablo; sarılan metin satırı minimumun üzerinde tutar.](row-height-decreased.png) |

## **İlk Satırı Başlık Olarak Ayarla**

[first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) özelliğini kullanarak ilk satırı başlık biçimlendirmesi için işaretleyin. Görünümü, tabloya uygulanan tablo stiline bağlıdır.

1. Sunumu [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slaytı erişin.
3. Slayttaki ilk şekil olarak saklanan tabloyu erişin.
4. İlk satırı için başlık biçimlendirmesini etkinleştirin.
5. Değiştirilmiş sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren `table.pptx` dosyasını gerektirir. İlk satır için başlık biçimlendirmesini etkinleştirir ve `First_row_header.pptx` olarak kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Tablo Satırını veya Sütununu Klonla**

Satırları veya sütunları klonlayarak içeriğini ve biçimlendirmesini yeniden kullanın. Kopyayı tablonun sonuna ekleyebilir veya belirli bir konuma yerleştirebilirsiniz.

1. Sunumu [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slaytı erişin.
3. Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
4. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) yöntemiyle bir tablo ekleyin.
5. Gerekli satırları klonlayın.
6. Gerekli sütunları klonlayın.
7. Değiştirilmiş sunumu kaydedin.

Örnek, en az bir slaytı olan `Test.pptx` dosyasını gerektirir. Üç sütun ve beş satır içeren bir tablo oluşturur; boyutlar puan cinsindendir. İlk satır ve sütunun kopyalarını sona ekler, ardından ikinci satır ve sütunun kopyalarını indeks 3 (dördüncü konum) de ekler. Sonuç tablo yedi satır ve beş sütun içerir. `False` bağımsız değişkeni, bitişik birleştirilmiş satır veya sütunlara klonlamayı devre dışı bırakır; bu tabloda birleştirilmiş hücre yoktur.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Tablo Satırını veya Sütununu Kaldır**

Artık ihtiyaç duyulmayan satırları veya sütunları bir tablodan kaldırın. Bir öğeyi kaldırmak, ardından gelen satır veya sütun indekslerini kaydırır.

1. Sunumu [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfı ile oluşturun.
2. İlk slaytı erişin.
3. Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
4. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) yöntemiyle bir tablo ekleyin.
5. İkinci satırı ve ikinci sütunu kaldırın.
6. Değiştirilmiş sunumu kaydedin.

Bu örnek, üç'e üç bir tablo oluşturur ve indeks 1'deki satır ve sütunu kaldırarak `TestTable_out.pptx` içinde iki'ye iki bir tablo bırakır. Boyutlar puan cinsindendir. `False` bağımsız değişkeni, bitişik birleştirilmiş satır veya sütunların kaldırılmasını devre dışı bırakır; bu tabloda birleştirilmiş hücre yoktur.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.shapes.add_table(100, 100, column_widths, row_heights)

    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Tablo Satır Düzeyinde Metin Biçimlendirmesini Ayarla**

Bir satırın tüm hücrelerini tutarlı tutmak için metin biçimlendirmesi uygulayın. Her hücreyi ayrı ayrı biçimlendirmeden yazı tipi özellikleri, paragraf biçimlendirmesi ve metin yönünü ayarlayabilirsiniz.

1. Sunumu [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayttaki tabloyu erişin.
3. İlk satır için [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) ayarlayın.
4. İlk satır için [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) ve [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) ayarlayın.
5. İkinci satır için [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) ayarlayın.
6. Değiştirilmiş sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren ve en az iki satır bulunan `table.pptx` dosyasını gerektirir. İlk satıra 25 puanlık metin, sağ hizalama ve 20 puanlık sağ paragraf kenar boşluğu uygular, ardından ikinci satıra dikey metin ayarlar.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Tablo Sütun Düzeyinde Metin Biçimlendirmesini Ayarla**

Bir sütunun tüm hücrelerini tutarlı tutmak için metin biçimlendirmesi uygulayın. Her hücreyi ayrı ayrı biçimlendirmeden yazı tipi özellikleri, paragraf biçimlendirmesi ve metin yönünü ayarlayabilirsiniz.

1. Sunumu [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayttaki tabloyu erişin.
3. İlk sütun için [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) ayarlayın.
4. İlk sütun için [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) ve [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) ayarlayın.
5. İkinci sütun için [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) ayarlayın.
6. Değiştirilmiş sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren ve en az iki sütun bulunan `table.pptx` dosyasını gerektirir. İlk sütuna 25 puanlık metin, sağ hizalama ve 20 puanlık sağ paragraf kenar boşluğu uygular, ardından ikinci sütuna dikey metin ayarlar.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Tablo Stil Özelliklerini Al**

[style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) özelliğini kullanarak bir tabloya uygulanmış ön ayarı alıp başka bir tabloya yeniden uygulayabilirsiniz. Bu, bireysel hücre biçimlendirme geçersiz kılmalarından ziyade ön ayarı tanımlar.

Örnek bir tablo oluşturur, [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) uygular ve ön ayarı geri okur. Alınan ön ayar uygulanan ön ayarla eşleştiğinde `True` yazdırır ve tabloyu `table.pptx` içinde kaydeder.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Zaten oluşturulmuş bir tabloya PowerPoint temaları/stilleri uygulayabilir miyim?**

Evet. Tablo, slayt/layout/ana tema miras alır ve yine de bu temanın üzerine dolgu, kenarlık ve metin renklerini geçersiz kılabilirsiniz.

**Tablo satırlarını Excel gibi sıralayabilir miyim?**

Hayır, Aspose.Slides tabloları yerleşik sıralama veya filtreleme özelliğine sahip değildir. Verileri önce bellekte sıralayın, ardından tablo satırlarını bu sırayla yeniden doldurun.

**Belirli hücrelerde özel renkleri korurken şeritli (bantlı) sütunlar oluşturabilir miyim?**

Evet. Bantlı sütunları etkinleştirin, ardından belirli hücrelerde yerel biçimlendirme uygulayın; hücre düzeyindeki biçimlendirme tablo stiline göre önceliklidir.