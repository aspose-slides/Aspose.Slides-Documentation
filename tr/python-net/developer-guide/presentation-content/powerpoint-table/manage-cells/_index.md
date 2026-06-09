---
title: Python ile Sunumlarda Tablo Hücrelerini Yönetme
linktitle: Hücreleri Yönet
type: docs
weight: 30
url: /tr/python-net/manage-cells/
keywords:
- tablo hücresi
- hücre birleştirme
- kenarlık kaldırma
- hücre bölme
- hücrede resim
- arka plan rengi
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument'ta tablo hücrelerini zahmetsizce yönetin. Hücrelere hızlıca erişin, değiştirin ve stil verin, sorunsuz slayt otomasyonu sağlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bu hücreleri değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, hücreleri birleştirdikten veya bölüştükten sonra hücre numaralandırmasıyla nasıl çalışılacağını, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresine nasıl resim ekleyeceğinizi açıklar. Örnekler, bir sunumu nasıl oluşturup açacağınızı, bir slayttan tablo almayı, hücre özellikleri aracılığıyla hücre biçimlendirmesini güncellemeyi ve değiştirilen sunumu PPTX dosyası olarak kaydetmeyi gösterir.

## **Birleştirilmiş Tablo Hücrelerini Belirleme**

Tablolar genellikle başlıklar için veya ilişkili verileri gruplamak amacıyla birleştirilmiş hücreler içerir. Bu bölümde, belirli bir hücrenin birleştirilmiş bir bölgeye ait olup olmadığını nasıl belirleyeceğinizi ve tüm bloğu tutarlı bir şekilde okuyup biçimlendirebilmek için ana (sol üst) hücreye nasıl referans vereceğinizi göreceksiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlk slayttan tabloyu alın.
3. Birleştirilmiş hücreleri bulmak için tablonun satır ve sütunlarında yineleme yapın.
4. Birleştirilmiş hücreler bulunduğunda bir mesaj yazdırın.

Aşağıdaki Python kodu, bir sunumdaki birleştirilmiş tablo hücrelerini tanımlar:

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # İlk slayttaki ilk şeklin bir tablo olduğunu varsayarak.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **Tablo Hücre Kenarlıklarını Kaldırma**

Bazen tablo kenarlıkları içerikten dikkati dağıtır veya görsel karmaşa yaratır. Bu bölüm, seçilen hücrelerin—veya bir hücrenin belirli kenarlarının—kenarlıklarını nasıl kaldıracağınızı gösterir, böylece daha temiz bir düzen elde eder ve slayt tasarımınıza daha iyi uyum sağlarsınız.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksiyle slaytı alın.
3. Sütun genişliklerinin bir dizisini tanımlayın.
4. Satır yüksekliklerinin bir dizisini tanımlayın.
5. Slayta, [add_table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_table/) metodunu kullanarak bir tablo ekleyin.
6. Her hücreyi dolaşarak üst, alt, sol ve sağ kenarlıkları temizleyin.
7. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, tablo hücrelerinden kenarlıkların nasıl kaldırılacağını gösterir:

```python
import aspose.slides as slides

# PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # İlk slayta erişin.
    slide = presentation.slides[0]

    # Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlayın.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Slayta bir tablo şekli ekleyin.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Her hücre için kenarlık doldurmayı temizleyin.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # PPTX dosyasını diske kaydedin.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Birleştirilmiş Hücrelerde Numaralandırma**

Eğer iki hücre çiftini birleştirirseniz—örneğin (1, 1) x (2, 1) ve (1, 2) x (2, 2)—sonuçta oluşan tablo, birleştirme yapılmamış tabloyla aynı hücre numaralandırmasını korur. Aşağıdaki Python kodu bu davranışı gösterir:

```python
import aspose.slides as slides

# PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # İlk slayta erişin.
    slide = presentation.slides[0]

    # Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlayın.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Slayta bir tablo şekli ekleyin.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Hücreleri (1,1) ve (2,1) birleştirin.
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Hücreleri (1, 2) ve (2, 2) birleştirin.
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Hücre indekslerini yazdırın.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # PPTX dosyasını diske kaydedin.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

Çıktı:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **Bölünmüş Hücrelerde Numaralandırma**

Önceki örnekte, tablo hücreleri birleştirildiğinde, diğer hücrelerdeki numaralandırma değişmezdi. Bu sefer, birleştirilmiş hücresi olmayan normal bir tablo oluşturup ardından (1, 1) hücresini bölerek özel bir tablo elde ediyoruz. Bu tablonun numaralandırmasına dikkat edin—alışılmadık görünebilir. Ancak, bu Microsoft PowerPoint'in tablo hücrelerini numaralandırma şeklidir ve Aspose.Slides aynı davranışı izler.

Aşağıdaki Python kodu bu davranışı gösterir:

```python
import aspose.slides as slides

# PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation() as presentation:
    # İlk slayta erişin.
    slide = presentation.slides[0]

    # Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Slayta bir tablo şekli ekleyin.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Hücreyi (1, 1) bölün.
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Hücre indekslerini yazdırın.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # PPTX dosyasını diske kaydedin.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

Çıktı:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **Tablo Hücresinin Arka Plan Rengini Değiştirme**

Aşağıdaki Python örneği, bir tablo hücresinin arka plan renginin nasıl değiştirileceğini gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Yeni bir tablo oluştur.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Bir hücrenin arka plan rengini ayarla.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Tablo Hücrelerine Resim Ekleme**

Bu bölüm, Aspose.Slides içinde bir tablo hücresine nasıl resim ekleneceğini gösterir. Hedef hücreye resim doldurma uygulanması ve görüntüleme seçeneklerinin (genişletme veya döşeme gibi) yapılandırılmasını kapsar.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksiyle bir slayt referansı alın.
3. Sütun genişliklerinin bir dizisini tanımlayın.
4. Satır yüksekliklerinin bir dizisini tanımlayın.
5. Slayta, [add_table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_table/) metodunu kullanarak bir tablo ekleyin.
6. Resmi bir dosyadan yükleyin.
7. Sunumun images koleksiyonuna resmi ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) elde edin.
8. Tablo hücresinin [FillType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) özelliğini `PICTURE` olarak ayarlayın.
9. Resmi tablo hücresine uygulayın ve bir doldurma modu seçin (ör. `STRETCH`).
10. Sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, bir tablo oluştururken tablo hücresine nasıl resim yerleştirileceğini gösterir:

```python
import aspose.slides as slides

# Presentation nesnesini örnekleyin.
with slides.Presentation() as presentation:
    # İlk slayta erişin.
    slide = presentation.slides[0]

    # Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Slayta bir tablo şekli ekleyin.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Görüntüyü yükleyin ve sunuma ekleyerek bir PPImage elde edin.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Görüntüyü ilk tablo hücresine uygulayın.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Sunumu diske kaydedin.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Tek bir hücrenin farklı kenarları için farklı çizgi kalınlıkları ve stilleri ayarlayabilir miyim?**

Evet. [top](https://reference.aspose.com/slides/tr/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/tr/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/tr/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/tr/python-net/aspose.slides/cellformat/border_right/) kenarlarının ayrı özellikleri vardır, bu yüzden her bir kenarın kalınlığı ve stili farklı olabilir. Bu, makalede gösterilen hücre için kenar kontrolünün taraf bazlı olmasından mantıksal olarak doğrudur.

**Hücrenin arka planı olarak bir resim ayarladıktan sonra sütun/ satır boyutunu değiştirirsem resim ne olur?**

Davranış, [fill mode](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillmode/) değerine bağlıdır. Genişletme (stretch) seçildiğinde resim yeni hücreye göre ayarlanır; döşeme (tile) seçildiğinde döşemeler yeniden hesaplanır. Makale, hücre içindeki resim görüntüleme modlarından bahseder.

**Bir hücrenin tüm içeriğine bir köprü (hyperlink) atayabilir miyim?**

[Hyperlinks](/slides/tr/python-net/manage-hyperlinks/) hücrenin metin çerçevesi içindeki metin (parça) düzeyinde veya tüm tablo/şekil düzeyinde ayarlanır. Pratikte, bağlantıyı bir parçaya ya da hücredeki tüm metne atarsınız.

**Tek bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, bağımsız biçimlendirmeye sahip [portions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/) (koşular) — yazı tipi ailesi, stil, boyut ve renk — destekler.