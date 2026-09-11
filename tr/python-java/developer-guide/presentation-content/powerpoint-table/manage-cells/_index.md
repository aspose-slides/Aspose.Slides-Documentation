---
title: Python Kullanarak Sunumlarda Tablo Hücrelerini Yönetme
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
description: "Aspose.Slides for Python via Java ile PowerPoint'te tablo hücrelerini sorunsuz bir şekilde yönetin. Hücrelere hızlıca erişme, değiştirme ve biçimlendirme konusunda ustalaşarak sorunsuz slayt otomasyonu sağlayın."
---
## **Genel Bakış**

Aspose.Slides PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bunları değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, hücreleri birleştirdikten veya ayırdıktan sonra hücre numaralandırmasıyla nasıl çalışacağınızı, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresine nasıl resim ekleyeceğinizi açıklar. Örnekler, bir sunumun nasıl oluşturulacağını veya açılacağını, bir slayttan tablonun nasıl alınacağını, hücre özellikleri aracılığıyla hücre biçimlendirmesinin nasıl güncelleneceğini ve değiştirilmiş sunumun PPTX dosyası olarak nasıl kaydedileceğini gösterir.

## **Birleştirilmiş Tablo Hücresini Tanımlama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İlk slayttan tabloyu alın.  
3. Birleştirilmiş hücreleri bulmak için tablonun satırları ve sütunları arasında dolaşın.  
4. Birleştirilmiş hücreler bulunduğunda bir mesaj yazdırın.  

Bu Python kodu, bir sunumda birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # İlk slayttaki ilk şeklin bir tablo olduğunu varsayın.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Tablo Hücre Kenarlıklarını Kaldırma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksiyle bir slayta referans alın.  
3. Sütun genişliklerinin bir listesini tanımlayın.  
4. Satır yüksekliklerinin bir listesini tanımlayın.  
5. Slayta, [addTable](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addTable) yöntemiyle bir tablo ekleyin.  
6. Her hücre üzerinde dolaşarak üst, alt, sağ ve sol kenarlıkları temizleyin.  
7. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.  

Bu Python kodu, tablo hücrelerinin kenarlıklarını nasıl kaldıracağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # İlk slayta eriş.
    slide = presentation.getSlides().get_Item(0)

    # Sütun genişliklerini ve satır yüksekliklerini tanımla.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Slayta bir tablo ekle.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Her hücre için kenarlık biçimini ayarla.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # Sunumu PPTX dosyası olarak kaydet.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Birleştirilmiş Hücrelerde Numaralandırma**

Eğer iki hücre çifti, (1, 1) ve (2, 1) ile (1, 2) ve (2, 2), birleştirilirse, oluşan tablo hücre numaralandırmasını korur. Bu Python kodu süreci gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # İlk slayta eriş.
    slide = presentation.getSlides().get_Item(0)

    # Sütun genişliklerini ve satır yüksekliklerini tanımla.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Slayta bir tablo ekle.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Her hücre için kenarlık biçimini ayarla.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # (1, 1) ve (2, 1) hücrelerini birleştir.
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # (1, 2) ve (2, 2) hücrelerini birleştir.
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Sunumu PPTX dosyası olarak kaydet.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Daha sonra (1, 1) ve (1, 2) hücrelerini birleştirerek hücreleri daha da birleştiriyoruz. Sonuç, ortasında büyük bir birleştirilmiş hücre bulunan bir tablo olur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # İlk slayta eriş.
    slide = presentation.getSlides().get_Item(0)

    # Sütun genişliklerini ve satır yüksekliklerini tanımla.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Slayta bir tablo ekle.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Her hücre için kenarlık biçimini ayarla.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # (1, 1) ve (2, 1) hücrelerini birleştir.
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # (1, 2) ve (2, 2) hücrelerini birleştir.
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # (1, 1) ve (1, 2) hücrelerini birleştir.
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # Sunumu PPTX dosyası olarak kaydet.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bölünmüş Hücrede Numaralandırma**

Önceki örneklerde, tablo hücrelerini birleştirmek diğer hücrelerin numaralandırmasını değiştirmedi.

Bu sefer, birleştirilmiş hücreleri olmayan normal bir tablo alıyoruz ve ardından (1, 1) hücresini bölerek özel bir tablo elde etmeye çalışıyoruz. Bu tablonun numaralandırmasına dikkat etmek isteyebilirsiniz; bu garip görünebilir. Ancak bu, Microsoft PowerPoint'in tablo hücrelerini numaralandırma şeklidir ve Aspose.Slides da aynı şeyi yapar.

Bu Python kodu, açıklanan süreci gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # İlk slayta eriş.
    slide = presentation.getSlides().get_Item(0)

    # Sütun genişliklerini ve satır yüksekliklerini tanımla.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Slayta bir tablo ekle.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Her hücre için kenarlık biçimini ayarla.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # (1, 1) hücresini böl.
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # Sunumu PPTX dosyası olarak kaydet.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


## **Tablo Hücresinin Arka Plan Rengini Değiştirme**

Bu Python kodu, bir tablo hücresinin arka plan rengini nasıl değiştireceğinizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # İlk slayta eriş.
    slide = presentation.getSlides().get_Item(0)

    # Sütun genişliklerini ve satır yüksekliklerini tanımla.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Slayta bir tablo ekle.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Bir hücrenin arka plan rengini ayarla.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Sunumu PPTX dosyası olarak kaydet.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tablo Hücresi İçine Resim Ekleme**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksiyle bir slayta referans alın.  
3. Sütun genişliklerinin bir listesini tanımlayın.  
4. Satır yüksekliklerinin bir listesini tanımlayın.  
5. Slayta, [addTable](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addTable) yöntemiyle bir tablo ekleyin.  
6. [Images.fromFile](https://reference.aspose.com/slides/tr/python-java/aspose.slides/images/#fromFile) kullanarak resim dosyasını yükleyin.  
7. Sunuma resmi ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) nesnesi oluşturun.  
8. Tablo hücresinin [FillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fillformat/) doldurma türünü [FillType.Picture](https://reference.aspose.com/slides/tr/python-java/aspose.slides/filltype/#Picture) olarak ayarlayın.  
9. Resmi tablonun ilk hücresine ekleyin.  
10. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.  

Bu Python kodu, bir tablo oluştururken tablo hücresine nasıl resim yerleştirileceğini gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # İlk slayta eriş.
    slide = presentation.getSlides().get_Item(0)

    # Sütun genişliklerini ve satır yüksekliklerini tanımla.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # Slayta bir tablo ekle.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Görüntü dosyasından sunum resmi oluştur.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Görüntüyü ilk tablo hücresine ekle.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Sunumu PPTX dosyası olarak kaydet.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Tek bir hücrenin farklı kenarları için farklı çizgi kalınlıkları ve stiller ayarlayabilir miyim?**

Evet. [top](https://reference.aspose.com/slides/tr/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/tr/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/tr/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/tr/python-java/aspose.slides/cellformat/#getBorderRight) kenarlıkların ayrı özellikleri vardır, bu yüzden her bir kenarın kalınlığı ve stili farklı olabilir. Bu, makalede gösterilen bir hücre için kenar kontrolünün yan‑tarafına dayalı mantıktır.

**Resmi hücrenin arka planı olarak bir resim ayarladıktan sonra sütun/ satır boyutunu değiştirirsem ne olur?**

Davranış, [fill mode](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillmode/) (stretch/tile) değerine bağlıdır. Gerçekleştirildiğinde, resim yeni hücreye uyacak şekilde ayarlanır; döşendiğinde, döşemeler yeniden hesaplanır. Makale, bir hücredeki resim görüntüleme modlarından bahseder.

**Bir hücrenin tüm içeriğine bir bağlantı atayabilir miyim?**

[Hyperlinks](/slides/tr/python-java/manage-hyperlinks/) hücrenin metin çerçevesindeki metin (parça) düzeyinde veya tüm tablo/şekil düzeyinde ayarlanır. Pratikte, bağlantıyı bir parçaya veya hücredeki tüm metne atarsınız.

**Tek bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, bağımsız biçimlendirmeye (yazı tipi ailesi, stil, boyut ve renk) sahip [portions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/) (parçalar) destekler.