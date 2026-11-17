---
title: Presentasyonlarda Tablo Hücrelerini Python Kullanarak Yönetme
linktitle: Hücreleri Yönet
type: docs
weight: 30
url: /tr/python-java/manage-cells/
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
description: "Python'da PowerPoint tablo hücrelerini yönetin: birleştirilmiş hücreleri tanımlayın, kenarlıkları kaldırın, hücreleri bölün ve arka plan renkleri ve resimleri Aspose.Slides for Python via Java ile ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunularında tablo hücrelerine erişmenizi ve bunları değiştirmenizi sağlar. Bu makale birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, birleştirme veya bölme işleminden sonra hücre numaralandırmasıyla nasıl çalışılacağını, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresine nasıl resim ekleyeceğinizi açıklar. Örnekler, bir sunumu nasıl oluşturacağınızı veya açacağınızı, bir slayttan tablo almayı, hücre özellikleri aracılığıyla hücre biçimlendirmesini güncellemeyi ve değiştirilmiş sunumu PPTX dosyası olarak kaydetmeyi gösterir.

Aspose.Slides, tablo hücrelerine `(sütun, satır)` sırasıyla sıfır‑tabanlı indeksler kullanarak erişir.

## **Birleştirilmiş Tablo Hücresini Tanımlama**

Örnek, mevcut bir sunumu açar ve ilk slayttaki ilk şekle tablo olarak erişir. Slayt ve şeklin var olduğunu ve şeklin bir tablo olduğunu varsayar. Daha sonra tüm satır ve sütunlarda döngü yapar ve birleştirilmiş bölgelerdeki hücreleri tanımlamak için [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) kullanır. Her eşleşme için hücre koordinatlarını `row;column` sırasıyla, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) ve bölgenin başlangıç koordinatlarını, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) ve [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) yazar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **Tablo Hücre Kenarlıklarını Kaldırma**

Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) oluşturun ve ilk slaytına [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) kullanarak bir tablo ekleyin. Sütun genişlikleri, satır yükseklikleri ve tablo konumu nokta cinsinden belirtilir. Örnek, tüm dört hücre kenarlığını [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) olarak ayarlar ve böylece görünmez hâle getirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Köşegen Hücre Kenarlıkları Ekleme**

Üst‑sol köşeden alt‑sağa bir çizgi çizmek için [getBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown), alt‑sol köşeden üst‑sağa bir çizgi çizmek için [getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp) kullanın. Bir köşegen köşe başlığını işaretleyebilir. Her iki köşegen birleşerek bir X oluşturabilir ve hücreyi uygulanamaz olarak işaretleyebilir.

Her köşegen bir [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/) nesnesidir. Bu nesnenin [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) içinde, [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) kullanarak [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) seçilir ve [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) aracılığıyla bir renk belirlenir. Çizgi genişliği, [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) ile nokta cinsinden ayarlanır.

Örnek, bir satırda üç hücre oluşturur: kırmızı aşağı doğru köşegen, mavi yukarı doğru köşegen ve her iki köşegen. Üst, alt, sol ve sağ hücre kenarlıkları aynı bırakılır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color


def format_border(border, color, width):
    fill = border.getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setColor(color)
    border.setWidth(width)


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(45, 130, [210, 210, 210], [160])

    left_cell = table.get_Item(0, 0).getCellFormat()
    middle_cell = table.get_Item(1, 0).getCellFormat()
    right_cell = table.get_Item(2, 0).getCellFormat()
    format_border(left_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(middle_cell.getBorderDiagonalUp(), Color.BLUE, 5)
    format_border(right_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(right_cell.getBorderDiagonalUp(), Color.BLUE, 5)

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Köşegen bir biçimlendirme özelliğidir, hücre bölmesi değildir. Her hücre, [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) aracılığıyla erişilen tek bir metin çerçevesi tutar. Köşegenin iki tarafındaki bölgeler bağımsız olarak düzenlenemez.

Microsoft PowerPoint'te görüntülenen kaydedilmiş tablo:

![Üst‑sol köşeden alt‑sağa kırmızı bir köşegen, alt‑sol köşeden üst‑sağa mavi bir köşegen ve her iki köşegenin bir X oluşturduğu üç tablo hücresi.](diagonal-cell-borders.png)

*Soldan sağa: aşağı doğru köşegen (kırmızı, 3 pt), yukarı doğru köşegen (mavi, 5 pt) ve her iki köşegen.*

## **Tablo Hücrelerini Birleştirme**

Bir dizi tablo hücresini tek bir hücreye birleştirmek için [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) kullanın. Aralığın üst‑sol ve alt‑sağ köşelerindeki hücreleri belirtin. Son argüman, birleştirmenin belirtilen aralığın dışındaki hücreleri içerip içermeyeceğini denetler; `False` birleştirmenin bu aralık içinde kalmasını sağlar.

Örnek, 70 nokta genişliğinde sütun ve satırlarla 4×4 bir tablo oluşturur ve ardından `(1, 1)` ile `(2, 2)` arasındaki dört merkezi hücreyi birleştirir. Ortaya çıkan hücre iki sütun ve iki satır kaplar, ancak tablonun temel ızgarası dört sütun ve dört satır olarak kalır. Birleştirilmiş hücrenin içeriğine veya biçimlendirmesine erişmek için üst‑sol konumunu kullanın: bu örnekte `table.get_Item(1, 1)`. Birleştirme aralığının diğer konumları tablo ızgarasının bir parçası olmaya devam eder, bu yüzden aralık dışındaki hücre indeksleri değişmez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tablo Hücrelerini Bölme**

Önceki örnekte hücreleri birleştirmek tablo ızgarasını korur. Bir hücreyi bölmek yeni bir ızgara sütunu ekleyebilir ve sağındaki hücrelerin sütun indekslerini değiştirebilir. Aspose.Slides, PowerPoint'in tablo ızgara modelini izler.

Bu örnek, 70 nokta genişliğinde sütun ve satırlarla 4×4 bir tablo oluşturur ve `(1, 1)` hücresinde [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) metodunu çağırır. Hücrenin 70 noktalık genişliğinin yarısı iki eşit genişlikte hücre oluşturmak için kullanılır.

Bu bölmeden sonra iki yarı `table.get_Item(1, 1)` ve `table.get_Item(2, 1)` olarak erişilir. Tablo ızgarası artık beş sütuna sahiptir: önceden 2 ve 3. sütunlarda bulunan hücreler sırasıyla 3 ve 4. sütunlara taşır. Satır indeksleri aynı kalır. Bölmeden sonra hücrelere erişirken bu güncellenmiş sütun indekslerini kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

<!-- visual-explanation:manage-cells:start -->
[![Birleştirilmemiş 70 nokta hücresi iki 35 nokta hücreye bölünür, beşinci bir ızgara sütunu ekler ve sağındaki indeksleri kaydırır.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Genişlik bölmesi (1, 1) hücresini etkiler, sıfır‑tabanlı (sütun, satır) indeksler kullanılır. Diğer satırlar, iki yeni sütun konumunu kapsayan bir hücreyi korur.*
<!-- visual-explanation:manage-cells:end -->

### **Birleştirilmiş Hücreleri Satır veya Sütun Genişliğine Göre Bölme**

Veri doldurmak için birleştirilmiş şablon hücrelerini hazırlamak üzere, mevcut bir satır sınırı boyunca bölmek için [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) ve bir sütun sınırı boyunca bölmek için [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) kullanın.

`index` argümanı, bölmenin üst kısmındaki satırları veya sol kısmındaki sütunları sayar; birleştirilmiş bölgeye göre görelidir:

- Satır bölmesi: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Sütun bölmesi: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Örnek, sunumun ilk slaytındaki ilk şeklin bir tablo olmasını ve `(1, 2)` ile `(1, 3)` hücrelerinin dikey olarak birleştirilmiş olmasını varsayar. Alt konumdan başlayarak, kökeni bulmak için [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) ve [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) kullanır ve her iki kapsamı da kontrol eder. `splitByRowSpan(1)` ardından ürün adları için 2 ve 3. satırları ayırır. Yatay iki sütun birleştirme için `splitByColSpan(1)` kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # Bölmeden sonra tablodan elde edilen hücreleri al.
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

Tablo ızgarası ve çevredeki hücre indeksleri değişmez. Sonuç hücreleri koordinatlarıyla alın; burada her ikisi de 1 kapsamına sahiptir ve [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) `False` yazdırır. Daha büyük bölgeler bir bölmeden sonra kısmen birleşik kalabilir.

Orijinal metin ve biçimlendirmesi üst (veya sol) hücrede kalır; yeni hücre boştur ancak dolgu, kenarlık ve kenar boşlukları gibi hücre biçimlendirmesini devralır. Bölmeden sonra hücreleri doldurun ve gerekirse metin biçimlendirmesini açıkça ayarlayın.

Kaydedilen sunum, şablonun hücre biçimlendirmesini koruyan ayrı "Product A" ve "Product B" hücrelerini içerir. Ayrıntılar için [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) bakın.

### **Belirli Bir Yükseklikte Hücreyi Bölme**

[splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) üst kısmın yüksekliğini nokta cinsinden alır. [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) üst kısmın mevcut ızgara satır sayısını alır. Sağ sütunda 40 noktalık bir hücreyi ortalamak için, hücrenin gerçek yüksekliğinden 40 çıkarın ve kalan alanı üstte ve altta eşit olarak bölün.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [160, 160], [140])
    table.get_Item(0, 0).getTextFrame().setText("Left")

    height = table.get_Item(1, 0).getHeight()
    margin = (height - 40) / 2
    
    table.get_Item(1, 0).splitByHeight(margin)
    table.get_Item(1, 1).splitByHeight(40)
    table.get_Item(1, 1).getTextFrame().setText("Middle")

    presentation.save("split_by_height.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

İlk bölme bir ızgara satırı ekler ve `(1, 1)` hücresinde alt kısımda 90 nokta bırakır. İkinci bölme bu hücreyi 40 noktalık ortadaki hücre ve 50 noktalık alt hücreye ayırır. Sağ sütunda artık üstten alta doğru 50, 40 ve 50 nokta yüksekliğinde üç hücre bulunur. Sol hücre tüm üç satırı kapsar ve orijinal 140 nokta yüksekliğini korur.

![Sol hücre, ortada Orta hücresi bulunan üç hücrenin yanındaki tüm tablo yüksekliğini kapsar.](split-by-height.png)

## **Tablo Hücre Arka Plan Rengini Değiştirme**

Bu örnek, 150 nokta genişliğinde sütunlar ve 50 nokta yüksekliğinde satırlarla bir tablo oluşturur. [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) kullanarak katı bir dolgu seçer ve [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) tarafından döndürülen rengi `(2, 3)` hücresi (üçüncü sütun, dördüncü satır) için kırmızı olarak ayarlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tablo Hücresi İçine Resim Ekleme**

Bu örneği çalıştırmadan önce giriş resmini çalışma dizinine koyun. Resmi [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) ile yükler ve sunumun resim koleksiyonuna [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) ile ekler. Daha sonra resmi, tablodaki ilk hücre olan `(0, 0)` hücresinin resim dolgusuna atar.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) resmi hücreyi dolduracak şekilde (germe) uzatır; bu, en‑boy oranını değiştirebilir. Sütun genişlikleri ve satır yüksekliği nokta cinsindendir. Yüklenen resim, sunuma eklendikten sonra bir `finally` bloğunda serbest bırakılır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Tek bir hücrenin farklı kenarları için farklı çizgi kalınlıkları ve stilleri ayarlayabilir miyim?**

Evet. [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) kenarlıklarının ayrı özellikleri vardır; bu yüzden her bir kenarın kalınlığı ve stili farklı olabilir.

**Bir resmi hücrenin arka planı olarak ayarladıktan sonra sütun/satır boyutunu değiştirirsem ne olur?**

Davranış, [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile) değerine bağlıdır. Germe (stretch) durumunda görüntü yeni hücreye uyum sağlar; döşeme (tile) durumunda ise döşemeler yeniden hesaplanır.

**Bir hücrenin tüm içeriğine bir hiperlink atayabilir miyim?**

[Hyperlinks](/slides/tr/python-java/manage-hyperlinks/) hücrenin metin çerçevesindeki metin (parça) seviyesinde veya tüm tablo/şekil seviyesinde ayarlanır. Uygulamada, bağlantıyı bir parçaya veya hücredeki tüm metne atarsınız.

**Tek bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, bağımsız biçimlendirmeye sahip [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (çalıştırmalar) — yazı tipi ailesi, stil, boyut ve renk — destekler.