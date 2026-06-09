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
  - satır metin biçimlendirmesi
  - sütun metin biçimlendirmesi
  - tablo stili
  - PowerPoint
  - sunum
  - Python
  - Aspose.Slides
description: "Aspose.Slides for Python ve .NET kullanarak PowerPoint ve OpenDocument'te tablo satırları ve sütunlarını yönetin; sunum düzenlemelerini ve veri güncellemelerini hızlandırın."
---
## **Genel Bakış**

Bu makale, PowerPoint ve OpenDocument sunumlarında tablo satırları ve sütunlarını Aspose.Slides for Python kullanarak yönetmeyi gösterir. Satır veya sütunları ekleme, ekleme, klonlama ve silme, ilk satırı başlık olarak işaretleme, boyutlandırma ve düzeni ayarlama ve satır veya sütun düzeyinde metin ve stil biçimlendirmesi uygulamayı öğreneceksiniz. Her görev, [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) API'sine dayalı kompakt ve bağımsız kod parçacıklarıyla gösterilir, böylece bir slaytta tabloyu hızlıca bulup tasarımınıza uygun şekilde yapısını yeniden şekillendirebilirsiniz.

## **İlk Satırı Başlık Olarak Ayarlama**

Tablonun ilk satırını başlık olarak işaretleyerek sütun başlıklarını veriden açıkça ayırın. Aspose.Slides for Python'da, seçilen tablo stilinin tanımladığı başlık biçimlendirmesini uygulamak için tablonun *First Row* (İlk Satır) seçeneğini etkinleştirin.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun ve sunumu yükleyin.  
1. Slayta indeksine göre erişin.  
1. İlgili tabloyu bulmak için tüm [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) nesnelerini döngüyle gezinin.  
1. Tablonun ilk satırını başlık olarak ayarlayın.  

Bu Python kodu, bir tablonun ilk satırını başlık olarak ayarlamayı gösterir:

```python
import aspose.slides as slides

# Presentation sınıfını örnekleyin.
with slides.Presentation("table.pptx") as presentation:
    # İlk slayta erişin.
    slide = presentation.slides[0]

    # Şekilleri dolaşın ve tabloya referans alın.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # Tablonun ilk satırını başlık olarak ayarlayın.
    table.first_row = True
    
    # Sunumu diske kaydedin.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Tablo Satırını veya Sütununu Klonlama**

Tablodaki herhangi bir satır veya sütunu klonlayın ve kopyayı tablonun istediğiniz konumuna ekleyin. Kopya, hücre içeriğini, biçimlendirmesini ve boyutlarını korur, böylece düzenleri hızlı ve tutarlı bir şekilde genişletebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun ve sunumu yükleyin.  
1. Slayta indeksine göre erişin.  
1. Sütun genişlikleri için bir dizi tanımlayın.  
1. Satır yükseklikleri için bir dizi tanımlayın.  
1. `add_table(x, y, column_widths, row_heights)` kullanarak slayta bir [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) ekleyin.  
1. Bir tablo satırını klonlayın.  
1. Bir tablo sütununu klonlayın.  
1. Değiştirilmiş sunumu kaydedin.  

PowerPoint tablosunda bir satır ve sütunu klonlamayı gösteren Python kodu aşağıdadır:

```python
 import aspose.slides as slides

# Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # İlk slayta erişin.
    slide = presentation.slides[0]

    # Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Slayta bir tablo ekleyin.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # 1. satır, 1. sütuna metin ekleyin.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # 2. satır, 1. sütuna metin ekleyin.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # 1. satırı tablonun sonuna klonlayın.
    table.rows.add_clone(table.rows[0], False)

    # 1. satır, 2. sütuna metin ekleyin.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # 2. satır, 2. sütuna metin ekleyin.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # 2. satırı tablonun 4. satırı olarak klonlayın.
    table.rows.insert_clone(3,table.rows[1], False)

    # İlk sütunu sonuna klonlayın.
    table.columns.add_clone(table.columns[0], False)

    # İkinci sütunu indeks 3'te (4. konum) klonlayın.
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Sunumu diske kaydedin.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Tablo'dan Satır veya Sütun Kaldırma**

Aspose.Slides for Python kullanarak indeksle herhangi bir satır veya sütunu kaldırarak tabloyu sadeleştirin—düzen otomatik olarak yeniden ayarlanır ve kalan hücrelerin biçimlendirmesi korunur. Bu, veri ızgaralarını basitleştirmek ya da tabloyu yeniden oluşturmadan yer tutucuları silmek için kullanışlıdır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun ve sunumu yükleyin.  
1. Slayta indeksine göre erişin.  
1. Sütun genişlikleri için bir dizi tanımlayın.  
1. Satır yükseklikleri için bir dizi tanımlayın.  
1. `add_table(x, y, column_widths, row_heights)` kullanarak slayta bir ITable ekleyin.  
1. Tablo satırını kaldırın.  
1. Tablo sütununu kaldırın.  
1. Değiştirilmiş sunumu kaydedin.  

Bir tablo'dan satır ve sütunu kaldırmayı gösteren Python kodu aşağıdadır:

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

## **Tablo Satır Düzeyinde Metin Biçimlendirmesini Ayarlama**

Bir tablo satırına tek adımda tutarlı metin stili uygulayın. Aspose.Slides for Python ile, satırdaki tüm hücreler için yazı tipi ailesi, boyutu, ağırlığı, rengi ve hizalamasını bir anda ayarlayarak başlıkları veya veri gruplarını tutarlı tutabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun ve sunumu yükleyin.  
1. Slayta indeksine göre erişin.  
1. Slayttaki ilgili [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) nesnesine erişin.  
1. İlk satır hücreleri için yazı tipi yüksekliğini ayarlayın.  
1. İlk satır hücreleri için hizalamayı ve sağ kenar boşluğunu ayarlayın.  
1. İkinci satır hücreleri için metin dikey tipini ayarlayın.  
1. Değiştirilmiş sunumu kaydedin.  

Bu Python kodu işlemi gösterir.

```python
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # İlk satır hücreleri için yazı tipi yüksekliğini ayarlayın.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # İlk satır hücrelerinin metin hizalamasını ve sağ kenar boşluğunu ayarlayın.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # İkinci satır hücrelerinin metin dikey tipini ayarlayın.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
    
    # Sunumu diske kaydedin.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Tablo Sütun Düzeyinde Metin Biçimlendirmesini Ayarlama**

Bir tablo sütununa tek seferde tutarlı metin stili uygulayın. Aspose.Slides for Python ile, bir sütundaki tüm hücreler için yazı tipi ailesi, boyutu, ağırlığı, rengi ve hizalamasını ayarlayarak başlıklar veya veriler için tek tip dikey bantlar oluşturabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun ve sunumu yükleyin.  
1. Slayta indeksine göre erişin.  
1. Slayttaki ilgili [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) nesnesine erişin.  
1. İlk sütun hücreleri için yazı tipi yüksekliğini ayarlayın.  
1. İlk sütun hücreleri için hizalamayı ve sağ kenar boşluğunu ayarlayın.  
1. İkinci sütun hücreleri için metin dikey tipini ayarlayın.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıdaki Python kodu işlemi gösterir:

```python
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # İlk sütun hücrelerinin yazı tipi yüksekliğini ayarlayın.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # İlk sütun hücrelerinin metin hizalamasını ve sağ kenar boşluğunu ayarlayın.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # İkinci sütun hücrelerinin metin dikey tipini ayarlayın.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # Sunumu diske kaydedin.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Tablo Stil Özelliklerini Al**

Aspose.Slides, bir tablonun stil özelliklerini almanıza olanak tanır, böylece bunları başka bir tablo ya da başka bir yerde yeniden kullanabilirsiniz. Aşağıdaki Python kodu, önceden tanımlı bir tablo stilinden stil özelliklerini nasıl alacağınızı gösterir:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Varolan bir tabloya PowerPoint temaları/stilleri uygulayabilir miyim?**  
Evet. Tablo, slayt/düzen/ana tema mirasını alır ve bu temanın üzerine dolgu, kenarlık ve metin renklerini hâlâ geçersiz kılabilirsiniz.

**Tablo satırlarını Excel gibi sıralayabilir miyim?**  
Hayır, Aspose.Slides tablolarında yerleşik sıralama veya filtreleme yoktur. Verilerinizi önce bellekte sıralayın, ardından tablo satırlarını o sırayla yeniden doldurun.

**Belirli hücrelerde özel renkleri koruyarak şeritli (banded) sütunlar kullanabilir miyim?**  
Evet. Şeritli sütunları etkinleştirin, ardından belirli hücreleri yerel biçimlendirme ile geçersiz kılın; hücre düzeyindeki biçimlendirme, tablo stiline üstünlük sağlar.