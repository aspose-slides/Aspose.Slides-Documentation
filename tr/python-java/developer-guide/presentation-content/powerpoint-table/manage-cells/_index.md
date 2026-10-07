---
title: Python Kullanarak Sunumlarda Tablo Hücrelerini Yönetme
linktitle: Hücreleri Yönet
type: docs
weight: 30
url: /tr/python-java/manage-cells/
keywords:
- tablo hücresi
- hücreleri birleştir
- kenarlığı kaldır
- hücresi böl
- hücrede görüntü
- arka plan rengi
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Python'da PowerPoint tablo hücrelerini yönetin: birleştirilmiş hücreleri belirleyin, kenarlıkları kaldırın, hücreleri bölün ve Aspose.Slides for Python via Java ile arka plan renkleri ve görüntüler ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenize ve bu hücreleri değiştirmenize olanak tanır. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, birleştirme veya bölme işleminden sonra hücre numaralandırmasıyla nasıl çalışılacağını, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresine nasıl görsel ekleneceğini açıklar. Örnekler, bir sunumun nasıl oluşturulup açılacağını, bir slayttan tablonun nasıl alınacağını, hücre özellikleri aracılığıyla hücre biçimlendirmesinin nasıl güncelleneceğini ve değiştirilmiş sunumun PPTX dosyası olarak nasıl kaydedileceğini gösterir.

Aspose.Slides, tablo hücrelerine `(sütun, satır)` sırasıyla sıfır‑tabanlı dizinler kullanarak erişir.

## **Birleştirilmiş Tablo Hücresini Tanımlama**

Örnek, mevcut bir sunumu açar ve ilk slayttaki ilk şekle tablo olarak erişir. Slayt ve şeklin var olduğu ve şeklin bir tablo olduğu varsayılır. Daha sonra tüm satır ve sütunlarda döngü yapılır ve [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) kullanılarak birleştirilmiş bölgelerdeki hücreler belirlenir. Eşleşen her hücre için `row;column` sırasındaki hücre koordinatları, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) ve bölgenin başlangıç koordinatları, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) ve [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) yazdırılır.

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

[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) oluşturun ve ilk slaytına [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) ile bir tablo ekleyin. Sütun genişlikleri, satır yükseklikleri ve tablo konumu puan birimiyle belirtilir. Örnek, dört hücre kenarlığının tümünü [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) ile ayarlayarak görünmez yapar.

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

## **Tablo Hücrelerini Birleştirme**

[mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) kullanarak dikdörtgensel bir hücre aralığını tek hücreye birleştirebilirsiniz. Aralığın sol‑üst ve sağ‑alt köşe hücrelerini belirtin. Son parametre, birleştirmenin belirtilen aralığın dışındaki hücreleri kapsayıp kapsamayacağını denetler; `False` birleştirmenin bu aralık içinde kalmasını sağlar.

Örnek, 70 puan genişliğinde sütun ve satırlara sahip 4‑x‑4 bir tablo oluşturur, ardından `(1, 1)`‑den `(2, 2)`‑ye kadar dört merkezi hücreyi birleştirir. Ortaya çıkan hücre iki sütun ve iki satır kapsar, ancak tablonun temel ızgarası dört sütun ve dört satır olarak kalır. Birleşik hücrenin içeriğine veya biçimlendirmesine erişmek için üst‑sol konumu kullanın: bu örnekte `table.get_Item(1, 1)`. Birleşik aralıktaki diğer konumlar tablo ızgarasının bir parçası kalır, bu yüzden aralık dışındaki hücrelerin indeksleri değişmez.

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

Önceki örnekte hücrelerin birleştirilmesi, tablonun ızgarasını korur. Bir hücreyi bölmek yeni bir ızgara sütunu ekleyebilir ve sağ tarafındaki hücrelerin sütun indekslerini değiştirebilir. Aspose.Slides, PowerPoint'in tablo ızgara modelini izler.

Bu örnek, 70 puan genişliğinde sütun ve satırlara sahip 4‑x‑4 bir tablo oluşturur ve `(1, 1)` hücresinde [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) çağırır. Hücrenin 70 puan genişliğinin yarısı iki eşit genişlikte hücre oluşturmak için kullanılır.

Bu bölmeden sonra iki yarı `table.get_Item(1, 1)` ve `table.get_Item(2, 1)` olarak erişilir. Tablo ızgarası artık beş sütuna sahiptir: önceden 2 ve 3. sütunlarda bulunan hücreler sırasıyla 3 ve 4. sütunlara kayar. Satır indeksleri değişmez. Bölmeden sonra hücrelere erişirken bu güncellenmiş sütun indekslerini kullanın.

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

### **Birleştirilmiş Hücreleri Satır veya Sütun Yayılımına Göre Bölme**

Birleştirilmiş şablon hücrelerini veri doldurmak için hazırlarken, mevcut bir satır sınırı boyunca bölmek için [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan), bir sütun sınırı boyunca bölmek için ise [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) kullanın.

`index` argümanı, bölmenin üst kısmındaki satırları veya sol kısmındaki sütunları sayar; birleştirilmiş bölgeye göredir:

- Satır bölme: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Sütun bölme: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Örnek, sunumun ilk slaytındaki ilk şeklin bir tablo olduğunu ve `(1, 2)` ile `(1, 3)` hücrelerinin dikey olarak birleştirildiğini varsayar. Alt konumdan başlayarak, başlangıcı bulmak için [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) ve [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) kullanılır ve her iki yayılım da kontrol edilir. `splitByRowSpan(1)` ardından ürün adları için 2. ve 3. satırları ayırır. Yatay iki sütun birleştirme için `splitByColSpan(1)` kullanılır.

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

        # Bölme işleminden sonra tablodan ortaya çıkan hücreleri alın.
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

Tablo ızgarası ve çevredeki hücre indeksleri değişmez. Sonuç hücreleri koordinatlarıyla alın; burada ikisi de 1 yayılımına sahiptir ve [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) `False` yazdırır. Daha büyük bölgeler tek bir bölme sonrasında kısmen birleştirilmiş kalabilir.

Orijinal metin ve biçimlendirme üst (veya sol) hücrede kalır; yeni hücre boştur ancak dolgu, kenarlık ve kenar boşlukları gibi hücre biçimlendirmesini devralır. Bölmeden sonra hücreleri doldurun ve gereken metin biçimlendirmesini açıkça ayarlayın.

Kaydedilen sunum, şablonun hücre biçimlendirmesi korunmuş olarak ayrı “Product A” ve “Product B” hücrelerini içerir. Ayrıntılar için [Hücre API Referansı](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) inceleyin.

## **Tablo Hücresinin Arka Plan Rengini Değiştirme**

Bu örnek, 150 puan genişliğinde sütunlar ve 50 puan yüksekliğinde satırlara sahip bir tablo oluşturur. [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) kullanarak katı bir dolgu seçer ve [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) tarafından döndürülen rengi, `(2, 3)` hücresi için kırmızı olarak ayarlar; bu hücre üçüncü sütun ve dördüncü satırdadır.

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

## **Tablo Hücresi İçine Görüntü Ekleme**

Bu örneği çalıştırmadan önce giriş görselini çalışma dizinine yerleştirin. Görsel, [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) ile yüklenir ve [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) ile sunumun görüntü koleksiyonuna eklenir. Ardından görsel, `(0, 0)` hücresinin resim doldurmasına atanır; bu hücre tablodaki ilk hücredir.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) görseli hücreye sığdırmak için genişletir, bu da en-boy oranını değiştirebilir. Sütun genişlikleri ve satır yükseklikleri puan birimindedir. Yüklenen görsel, `finally` bloğunda sunuma eklendikten sonra yok edilir.

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

**Bir hücrenin farklı tarafından farklı çizgi kalınlıkları ve stilleri ayarlayabilir miyim?**

Evet. [üst](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[alt](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[sol](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[sağ](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) kenarlıkların ayrı özellikleri vardır, bu yüzden her bir tarafın kalınlığı ve stili farklı olabilir.

**Bir resmi hücrenin arka planı olarak ayarladıktan sonra sütun/satır boyutunu değiştirirsem ne olur?**

Davranış, [dolgu modu](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile) ile ilgilidir. Streçleme durumunda görsel yeni hücreye uyum sağlar; döşeme durumunda ise döşemeler yeniden hesaplanır.

**Bir hücrenin tüm içeriğine bir hipermetin bağlantısı atayabilir miyim?**

[Hipermetin Bağlantıları](/slides/tr/python-java/manage-hyperlinks/) hücrenin metin çerçevesi içinde metin (parça) seviyesinde veya tüm tablo/şekil seviyesinde ayarlanır. Pratikte, bağlantıyı bir parçaya ya da hücredeki tüm metne atarsınız.

**Bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, bağımsız biçimlendirme (yazı tipi ailesi, stil, boyut ve renk) destekleyen [parçalar](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) içerir.