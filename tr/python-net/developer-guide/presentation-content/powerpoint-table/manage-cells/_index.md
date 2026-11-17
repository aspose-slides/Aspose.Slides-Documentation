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
- sunum
- Python
- Aspose.Slides
description: "Python ile PowerPoint tablo hücrelerini yönetin: birleştirilmiş hücreleri belirleyin, kenarlıkları kaldırın, hücreleri bölün ve Aspose.Slides for Python via .NET ile arka plan renkleri ve resimler ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bunları değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, birleştirme veya bölme işlemlerinden sonra hücre numaralandırmasıyla nasıl çalışılacağını, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresine nasıl resim ekleyeceğinizi açıklar. Örnekler, bir sunumun nasıl oluşturulacağını veya açılacağını, bir slayttan tablo almayı, hücre özellikleri aracılığıyla hücre biçimlendirmesini güncellemeyi ve değiştirilen sunumu PPTX dosyası olarak kaydetmeyi gösterir.

Aspose.Slides, sıfır tabanlı indeksler kullanır. Bu makaledeki koordinatlar `(column, row)` biçiminde yazılmıştır.

## **Birleştirilmiş Tablo Hücresini Tanımlama**

Örnek, mevcut bir sunumu açar ve ilk slayttaki ilk şekle tablo olarak erişir. Slayt ve şeklin mevcut olduğu ve şeklin bir tablo olduğu varsayılır. Daha sonra tüm satır ve sütunları döngüye alır ve birleştirilmiş bölgelerdeki hücreleri tanımlamak için [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) kullanır. Her eşleşme için hücre koordinatlarını `row;column` sırasıyla, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), ve bölgenin başlangıç koordinatlarını, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) ve [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) yazdırır.

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

Bir [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) oluşturun ve ilk slaytına [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) kullanarak bir tablo ekleyin. Sütun genişlikleri, satır yükseklikleri ve tablo konumu puan cinsinden belirtilir. Örnek, dört hücre kenarını da [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) olarak ayarlar ve böylece görünmez hâle getirir.

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
## **Çapraz Hücre Kenarlıkları Ekleme**

Üst sol köşeden alt sağ köşeye bir çizgi çizmek için [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) kullanın, alt sol köşeden üst sağ köşeye bir çizgi çizmek için [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) kullanın. Bir çapraz, köşe başlığını işaretleyebilir; iki çapraz bir X oluşturabilir ve hücreyi geçerli olmayan olarak işaretleyebilir.

Her çapraz bir [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/) nesnesidir. Bunun [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) içinde, [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) özelliğini [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) olarak ayarlayın ve bir [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) seçin. Çizginin [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) değerini puan cinsinden ayarlayın.

Örnek, bir satırda üç hücre oluşturur: kırmızı aşağı doğru çapraz, mavi yukarı doğru çapraz ve her iki çapraz. Üst, alt, sol ve sağ hücre kenarlarını değiştirmeden bırakır.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```
Bir çapraz bir biçimlendirme özelliğidir, hücre bölünmesi değildir. Her hücre tek bir [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) tutar; çaprazın her iki tarafındaki bölgeler bağımsız olarak düzenlenemez.

The saved table, rendered in Microsoft PowerPoint:

![Üst sol köşeden alt sağ köşeye kırmızı bir çapraz, alt sol köşeden üst sağ köşeye mavi bir çapraz ve her iki çaprazın X oluşturduğu üç tablo hücresi.](diagonal-cell-borders.png)

*Soldan sağa: aşağı doğru çapraz (kırmızı, 3 pt), yukarı doğru çapraz (mavi, 5 pt) ve her iki çapraz.*

## **Tablo Hücrelerini Birleştirme**

[merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) kullanarak dikdörtgen bir tablo hücresi aralığını tek bir hücreye birleştirin. Aralığın üst sol ve alt sağ köşelerindeki hücreleri belirtin. Son argüman, birleştirmenin belirtilen aralığın dışındaki hücreleri kapsayıp kapsamayacağını denetler; `False` birleştirmenin bu aralık içinde kalmasını sağlar.

Örnek, 70 puanlık sütun ve satırlara sahip 4x4 bir tablo oluşturur, ardından `(1, 1)` ile `(2, 2)` arasındaki dört merkezi hücreyi birleştirir. Oluşan hücre iki sütun ve iki satır kapsar, ancak tablonun temel ızgarası dört sütun ve dört satır olarak kalır. Birleştirilmiş hücrenin içeriğine veya biçimlendirmesine erişmek için üst sol konumunu kullanın: bu örnekte `table.rows[1][1]`. Birleştirme aralığındaki diğer konumlar tablo ızgarasının bir parçası olmaya devam eder, bu yüzden aralık dışındaki hücre indeksleri değişmez.

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

Önceki örnekte hücrelerin birleştirilmesi tablo ızgarasını korur. Bir hücreyi bölmek yeni bir ızgara sütunu ekleyebilir ve sağındaki hücrelerin sütun indekslerini değiştirebilir. Aspose.Slides, PowerPoint'in tablo ızgara modelini izler.

Bu örnek, 70 puanlık sütun ve satırlara sahip 4x4 bir tablo oluşturur ve `(1, 1)` hücresinde [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) metodunu çağırır. Hücrenin 70 puanlık genişliğinin yarısı iki eşit genişlikte hücre oluşturmak için kullanılır.

Bu bölünmeden sonra iki yarı `table.rows[1][1]` ve `table.rows[1][2]` olarak erişilir. Tablo ızgarası artık beş sütuna sahiptir: önceki 2 ve 3. sütunlardaki hücreler sırasıyla 3 ve 4. sütunlara taşınır. Satır indeksleri değişmez. Bölünmeden sonra hücrelere erişirken bu güncellenmiş sütun indekslerini kullanın.

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

<!-- visual-explanation:manage-cells:start -->
[![Birleştirilmemiş 70 puanlık bir hücre, iki 35 puanlık hücreye bölünür, beşinci bir ızgara sütunu ekler ve sağ tarafındaki indeksleri kaydırır.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Genişlik bölünmesi hücre (1, 1)'i etkiler, sıfır tabanlı (column, row) indeksleri kullanır. Diğer satırlar, hücrenin her iki yeni sütun konumunu da kapsamasını korur.*
<!-- visual-explanation:manage-cells:end -->

### **Birleştirilmiş Hücreleri Satır veya Sütun Yayılımına Göre Bölme**

Birleştirilmiş şablon hücrelerini veri doldurmak için hazırlamak amacıyla, mevcut bir satır sınırı boyunca bölmek için [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) kullanın, ya da bir sütun sınırı boyunca bölmek için [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) kullanın.

`index` argümanı, bölmenin üst kısmındaki satırları veya sol kısmındaki sütunları sayar; birleştirilmiş bölgeye göre relatiftir:

- Satır bölmesi: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Sütun bölmesi: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

Örnek, bir sunumun ilk slayttaki ilk şekli olarak bir tablo içerdiğini ve `(1, 2)` ile `(1, 3)` hücrelerinin dikey olarak birleştirildiğini varsayar. Alt konumdan başlayarak, kökeni bulmak için [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) ve [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) kullanır ve her iki yayılımı da kontrol eder. `split_by_row_span` metodunu index 1 ile kullanarak satır 2 ve 3'ü ürün adları için ayırır. Yatay iki sütun birleşimi için, bunun yerine `split_by_col_span` metodunu index 1 ile kullanın.

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

        # Ayrıştırmadan sonra tablodan elde edilen hücreleri al.
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
Tablo ızgarası ve çevredeki hücre indeksleri değişmez. Oluşan hücreleri koordinatlarıyla alın; burada her ikisi de 1 yayılımına sahiptir ve [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) `False` döndürür. Daha büyük bölgeler bir bölünmeden sonra kısmen birleşik kalabilir.

Orijinal metin ve biçimlendirmesi üst (veya sol) hücrede kalır; yeni hücre boştur ancak dolgu, kenarlıklar ve kenar boşlukları gibi hücre biçimlendirmesini miras alır. Hücreleri bölünmeden sonra doldurun ve gerekli metin biçimlendirmesini açıkça ayarlayın.

Kaydedilen sunum, şablonun hücre biçimlendirmesini koruyan ayrı "Product A" ve "Product B" hücreleri içerir. Ayrıntılar için [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) sayfasına bakın.

### **Bir Hücreyi Belirli Bir Yükseklikte Bölme**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) üst kısmın yüksekliğini puan cinsinden alır. [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) üst kısmın mevcut ızgara satır sayısını alır. Sağ sütunda bir 40 puanlık hücreyi dikey olarak ortalamak için, hücrenin gerçek yüksekliğinden 40 çıkarın ve kalan boşluğu üstte ve altta eşit olarak bölün.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```
İlk bölme bir ızgara satırı ekler ve `table.rows[1][1]` içinde alt 90 puanı bırakır. İkinci bölme bu hücreyi 40 puanlık orta hücre ve 50 puanlık alt hücreye ayırır. Sağ sütundaki üç hücre artık üstten alta 50, 40 ve 50 puan yüksekliğe sahiptir. Sol hücre, orijinal 140 puan yüksekliğinde üç satırı kapsar.

![Sol hücre, ortada 'Middle' bulunan üç hücrenin yanında tablonun tam yüksekliğini kapsar.](split-by-height.png)

## **Tablo Hücresinin Arka Plan Rengini Değiştirme**

Bu örnek, 150 puanlık sütunlar ve 50 puanlık satırlarla bir tablo oluşturur. `(2, 3)` hücresi (üçüncü sütun ve dördüncü satır) için [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) solid ve [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) kırmızı olarak ayarlar.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```
## **Tablo Hücresi İçine Resim Ekleme**

Bu örneği çalıştırmadan önce girdi resmini çalışma dizinine yerleştirin. Resmi [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) ile yükler ve sunumun resim koleksiyonuna [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) ile ekler. Ardından resmi, tablodaki ilk hücre olan `(0, 0)` hücresinin resim doldurmasına atar.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) resmi hücreye sığdırmak için uzatır, bu da en/boy oranını değiştirebilir. Sütun genişlikleri ve satır yükseklikleri puan cinsindendir. Yüklenen resim, `with` bloğu sona erdiğinde otomatik olarak serbest bırakılır.

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

Evet. [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) kenarlıkların ayrı özellikleri vardır, bu yüzden her bir tarafın kalınlığı ve stili farklı olabilir.

**Bir resmi hücrenin arka planı olarak ayarladıktan sonra sütun/satır boyutunu değiştirirsem ne olur?**

Davranış, [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile) değerine bağlıdır. Stretching (uzatma) ile resim yeni hücreye uyum sağlar, tiling (döşeme) ile döşemeler yeniden hesaplanır.

**Bir hücrenin tüm içeriğine bir köprü atayabilir miyim?**

[Hyperlinks](/slides/tr/python-net/manage-hyperlinks/) hücrenin metin çerçevesindeki metin (parça) seviyesinde veya tüm tablo/şekil seviyesinde ayarlanır. Pratikte, bağlantıyı bir parçaya ya da hücredeki tüm metne atarsınız.

**Tek bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, bağımsız biçimlendirme (yazı tipi, stil, boyut, renk) destekleyen [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (run) içerir.