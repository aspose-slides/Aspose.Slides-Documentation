---
title: Python ile Sunumlarda Tablo Hücrelerini Yönetme
linktitle: Hücreleri Yönet
type: docs
weight: 30
url: /tr/python-net/manage-cells/
keywords:
- tablo hücresi
- hücreleri birleştir
- kenarlığı kaldır
- hücresi böl
- hücrede resim
- arka plan rengi
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Python ile PowerPoint tablo hücrelerini yönetin: birleştirilmiş hücreleri tanımlayın, kenarlıkları kaldırın, hücreleri bölün ve Aspose.Slides for Python via .NET ile arka plan renkleri ve resimler ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bunları değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, birleştirme veya bölme işleminden sonra hücre numaralandırmasıyla nasıl çalışılacağını, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresine nasıl resim ekleyeceğinizi açıklar. Örnekler, bir sunumun nasıl oluşturulacağını veya açılacağını, bir slayttan tablo nasıl alınacağını, hücre özellikleri aracılığıyla hücre biçimlendirmesinin nasıl güncelleneceğini ve değiştirilmiş sunumun PPTX dosyası olarak nasıl kaydedileceğini göstermektedir.

Aspose.Slides, sıfır tabanlı indeksler kullanır. Bu makaledeki koordinatlar `(column, row)` biçiminde yazılmıştır.

## **Birleştirilmiş Tablo Hücresini Tanımlama**

Örnek, mevcut bir sunumu açar ve ilk slayttaki ilk şekle tablo olarak erişir. Slayt ve şeklin mevcut olduğu ve şeklin bir tablo olduğu varsayılır. Ardından tüm satır ve sütunlar döngüyle gezilir ve birleştirilmiş bölgelerdeki hücreleri belirlemek için [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) kullanılır. Her eşleşme için hücre koordinatları `row;column` sırasıyla, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), ve bölgenin başlangıç koordinatları, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) ve [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) yazdırılır.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **Tablo Hücre Kenarlıklarını Kaldırma**

Bir [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) oluşturun ve ilk slaytına [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) ile bir tablo ekleyin. Sütun genişlikleri, satır yükseklikleri ve tablo konumu puan cinsinden belirtilir. Örnek, dört hücre kenarlığını da [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) olarak ayarlar ve böylece kenarlıklar görünmez hale gelir.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Tablo Hücrelerini Birleştirme**

Bir dikdörtgen tablo hücresi aralığını tek bir hücreye birleştirmek için [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) kullanın. Aralığın sol‑üst ve sağ‑alt köşe hücrelerini belirtin. Son argüman, birleştirmenin belirtilen aralığın dışındaki hücreleri içerip içermeyeceğini kontrol eder; `False` birleştirmenin sadece bu aralıkta kalmasını sağlar.

Örnek, 70 puan sütun ve satır genişliğine sahip 4x4 bir tablo oluşturur ve ardından `(1, 1)` ile `(2, 2)` arasındaki dört merkezi hücreyi birleştirir. Ortaya çıkan hücre iki sütun ve iki satır kapsar, ancak tablonun temel ızgarası dört sütun ve dört satır olarak kalır. Birleştirilmiş hücrenin içeriğine veya biçimlendirmesine erişmek için bu örnekte `table.rows[1][1]` şeklindeki sol‑üst konumu kullanılır. Birleştirme aralığındaki diğer konumlar tablo ızgarasının bir parçası olmaya devam eder, bu yüzden aralık dışındaki hücrelerin indeksleri değişmez.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **Tablo Hücrelerini Bölme**

Önceki örnekte hücreleri birleştirmek, tablonun ızgarasını korur. Bir hücreyi bölmek yeni bir ızgara sütunu oluşturabilir ve sağ tarafındaki hücrelerin sütun indekslerini değiştirebilir. Aspose.Slides, PowerPoint'in tablo ızgara modelini izler.

Bu örnek, 70 puan sütun ve satır genişliğine sahip 4x4 bir tablo oluşturur ve `(1, 1)` hücresinde [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) çağırır. Hücrenin 70 puan genişliğinin yarısı, iki eşit genişlikte hücre oluşturmak için kullanılır.

Bu bölmeden sonra iki yarı `table.rows[1][1]` ve `table.rows[1][2]` olarak erişilir. Tablo ızgarası artık beş sütuna sahiptir: önceden 2. ve 3. sütunlarda olan hücreler sırasıyla 3. ve 4. sütunlara taşınır. Satır indeksleri değişmez. Bölme işleminden sonra hücrelere erişirken bu güncellenmiş sütun indekslerini kullanın.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

### **Birleştirilmiş Hücreleri Satır veya Sütun Kapsamına Göre Bölme**

Birleştirilmiş şablon hücrelerini veri doldurma için hazırlamak amacıyla, mevcut bir satır sınırına göre bölmek için [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) veya bir sütun sınırına göre bölmek için [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) kullanın.

`index` argümanı, bölmenin üst kısmındaki satırları veya sol kısmındaki sütunları sayar; bu değer birleştirilmiş bölgeye göredir:

- Satır bölme: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Sütun bölme: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

Örnek, sunumda ilk slayttaki ilk şeklin bir tablo olduğunu ve `(1, 2)` ile `(1, 3)` hücrelerinin dikey olarak birleştirildiğini varsayar. Alt konumdan başlayarak, kökeni bulmak için [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) ve [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) kullanır ve her iki kapsamı da kontrol eder. `split_by_row_span` ile indeks 1 verildiğinde, ürün isimleri için 2. ve 3. satırlar ayrılır. Yatay iki sütun birleştirme için, bunun yerine `split_by_col_span` ile indeks 1 kullanın.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # Bölme işleminden sonra tablodan elde edilen hücreleri al.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

Tablo ızgarası ve çevredeki hücre indeksleri değişmeden kalır. Sonuç hücreleri koordinatlarıyla alın; burada ikisi de 1 kapsamına sahiptir ve [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) `False` yazdırır. Daha büyük bölgeler tek bir bölmeden sonra kısmen birleştirilmiş kalabilir.

Orijinal metin ve biçimlendirmesi üst (veya sol) hücrede kalır; yeni hücre boş olur ancak dolgu, kenarlıklar ve kenar boşlukları gibi hücre biçimlendirmesini devralır. Hücreleri bölme işleminden sonra doldurun ve gerekli metin biçimlendirmesini açıkça ayarlayın.

Kaydedilen sunum, şablonun hücre biçimlendirmesini koruyan ayrı "Product A" ve "Product B" hücrelerine sahiptir. Ayrıntılar için [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) adresine bakın.

## **Tablo Hücresinin Arka Plan Rengini Değiştirme**

Bu örnek, 150 puan sütun ve 50 puan satır genişliğine sahip bir tablo oluşturur. `(2, 3)` hücresi için [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) solid ve [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) kırmızı olarak ayarlar; bu hücre üçüncü sütun ve dördüncü satırdadır.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Tablo Hücresine Resim Ekleme**

Bu örneği çalıştırmadan önce giriş resmini çalışma dizinine koyun. Resim, [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) ile yüklenir ve sunumun resim koleksiyonuna [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) ile eklenir. Daha sonra resim, tablodaki ilk hücre olan `(0, 0)` hücresinin resim dolgusuna atanır.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) resmi hücreyi dolduracak şekilde uzatır; bu, görüntünün en‑boy oranını değiştirebilir. Sütun genişlikleri ve satır yükseklikleri puan cinsindendir. Yüklenen resim, `with` bloğu sona erdiğinde otomatik olarak serbest bırakılır.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Tek bir hücrenin farklı kenarları için farklı çizgi kalınlıkları ve stiller ayarlayabilir miyim?**

Evet. [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) kenarlıkların ayrı ayrı özellikleri vardır; bu nedenle her bir tarafın kalınlığı ve stili farklı olabilir.

**Bir resmi hücrenin arka planı olarak ayarladıktan sonra sütun/satır boyutunu değiştirirsem, resim ne olur?**

Davranış, [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile) değerine bağlıdır. Uzatma seçildiyse, resim yeni hücreye uyum sağlar; döşeme (tiling) seçildiyse, döşemeler yeniden hesaplanır.

**Bir hücrenin tüm içeriğine bir hiperlink atayabilir miyim?**

[Hyperlinks](/slides/tr/python-net/manage-hyperlinks/) hücrenin metin çerçevesindeki metin (parça) düzeyinde veya tüm tablo/şekil düzeyinde ayarlanır. Pratikte, bağlantıyı bir parçaya ya da hücredeki tüm metne atarsınız.

**Tek bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, bağımsız biçimlendirmeye sahip [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (çalıştırmalar) – yazı tipi ailesi, stil, boyut ve renk – destekler.