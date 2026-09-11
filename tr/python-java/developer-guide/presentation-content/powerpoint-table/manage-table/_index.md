---
title: Python'da Sunum Tablolarını Yönet
linktitle: Tabloyu Yönet
type: docs
weight: 10
url: /tr/python-java/manage-table/
keywords:
- tablo ekle
- tablo oluştur
- tabloya eriş
- en‑boy oranı
- metni hizala
- metin biçimlendirme
- tablo stili
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Java aracılığıyla Python için Aspose.Slides ile PowerPoint slaytlarında tablo oluşturun ve düzenleyin. Tablo iş akışlarınızı kolaylaştırmak için basit kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'teki bir tablo, bilgiyi görüntülemenin etkili bir yoludur. Hücrelerden oluşan bir ızgara (satırlar ve sütunlar halinde düzenlenmiş) içindeki bilgi doğrudan ve anlaşılması kolaydır.

Aspose.Slides, [Table](https://reference.aspose.com/slides/tr/python-java/aspose.slides/table/) sınıfını, [Cell](https://reference.aspose.com/slides/tr/python-java/aspose.slides/cell/) sınıfını ve diğer türleri sağlayarak, her türlü sunumda tablo oluşturmanıza, güncellemenize ve yönetmenize olanak tanır.

## **Sıfırdan Bir Tablo Oluşturma**

1. Presentation sınıfının bir örneğini oluşturun.  
2. İndeksine göre bir slayta referans alın.  
3. Sütun genişliklerinin bir listesini tanımlayın.  
4. Satır yüksekliklerinin bir listesini tanımlayın.  
5. addTable yöntemiyle slayta bir Table nesnesi ekleyin.  
6. Her bir Cell üzerinde dönerken üst, alt, sağ ve sol kenarlara biçimlendirme uygulayın.  
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.  
8. Bir Cell'in TextFrame'ine erişin.  
9. TextFrame'e bir metin ekleyin.  
10. Değiştirilmiş sunumu kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# PPTX dosyasını temsil eden bir Presentation sınıfı örneklenir
presentation = Presentation()
try:

    # İlk slayta erişir
    slide = presentation.getSlides().get_Item(0)

    # Sütunları genişliklerle ve satırları yüksekliklerle tanımlar
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Slayta bir tablo şekli ekler
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Her hücre için kenarlık formatını ayarlar
    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    # 1. satırın 1. ve 2. hücrelerini birleştirir
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # Birleştirilen hücreye metin ekler
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # Sunumu diske kaydeder
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Standart Bir Tablo İçindeki Numaralandırma**

Standart bir tabloda hücre numaralandırması basittir ve sıfır tabanlıdır. Bir tablodaki ilk hücre 0,0 (sütun 0, satır 0) olarak indekslenir.

Örneğin, 4 sütun ve 4 satırdan oluşan bir tablodaki hücreler şu şekilde numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu Python kodu, standart hücre numaralandırmasıyla bir tablo oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# PPTX dosyasını temsil eden bir Presentation sınıfı örnekler
presentation = Presentation()
try:

    # İlk slayta erişir
    slide = presentation.getSlides().get_Item(0)

    # Genişlikleri ve yükseklikleriyle sütunları ve satırları tanımlar
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Slayta bir tablo şekli ekler
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Her hücre için kenarlık formatını ayarlar
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

    # Sunumu diske kaydeder
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mevcut Bir Tabloya Erişim**

1. Presentation sınıfının bir örneğini oluşturun.  
2. İndeksi aracılığıyla tabloyu içeren slayta referans alın.  
3. Bir Table nesnesi için bir değişken başlatın ve onu `None` olarak ayarlayın.  
4. Tablonun bulunana kadar tüm Shape nesneleri arasında dolaşın.  
   Eğer üzerinde çalıştığınız slaytta yalnızca tek bir tablo olduğunu düşünüyorsanız, içerdiği tüm şekilleri kontrol edebilirsiniz. Bir şekil tablo olarak tanımlanırsa, onu bir Table nesnesi olarak kullanabilirsiniz. Ancak slayt birden fazla tablo içeriyorsa, ihtiyacınız olan tabloyu getAlternativeText yöntemiyle aramanız daha iyidir.  
5. Table nesnesini kullanarak tablo üzerinde çalışın. Aşağıdaki örnekte, ikinci satırın ilk sütunundaki metni güncelliyoruz.  
6. Değiştirilmiş sunumu kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# PPTX dosyasını temsil eden Presentation sınıfını örnekler
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # İlk slayta erişir
    slide = presentation.getSlides().get_Item(0)

    # Tablo referansını başlatır.
    table = None

    # Şekiller arasında döner ve bulunan tabloya referans ayarlar
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # İkinci satırın birinci sütunu için metni ayarlar
            table.get_Item(0, 1).getTextFrame().setText("New")

    # Değiştirilmiş sunumu diske kaydeder
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir TextFrame'e Sahip Hücreyi Bulma**

Genel metin işleme kodu bir tablodan gelen bir TextFrame aldığında, ilgili Cell'i almak için TextFrame.getParentCell yöntemini kullanın. Bir tablo hücresi metin çerçevesi için TextFrame.getParentCell sahibi döndürür ve TextFrame.getParentShape `None` döndürür; tablo kendisi bir şekil olsa bile.

Hücre koordinatları, salt okunur Cell.getFirstColumnIndex ve Cell.getFirstRowIndex yöntemleriyle erişilebilir. TextFrame.getParentCell ayrıca salt okunur bir gezinme sağlar: sahibi döndürür ancak sahipliği değiştirmez. Kullanımdan önce her zaman dönen hücrenin `None` olup olmadığını kontrol edin.

Tam bir örnek için, SmartArt düğümleriyle ilişkili şekiller de dahil olmak üzere tablo hücresi ve şekil sahiplerini tanımlayan örnek için [Search and Replace Text](/slides/tr/python-java/search-and-replace-text/) sayfasına bakın.

## **Bir Tablodaki Metni Hizalama**

1. Presentation sınıfının bir örneğini oluşturun.  
2. İndeksine göre bir slayta referans alın.  
3. Slayta bir Table nesnesi ekleyin.  
4. Tablodan bir TextFrame nesnesine erişin.  
5. TextFrame nesnesinin Paragraph'ına erişin.  
6. Metni dikey olarak hizalayın.  
7. Değiştirilmiş sunumu kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# Presentation sınıfının bir örneğini oluşturur
presentation = Presentation()
try:

    # İlk slaytı alır
    slide = presentation.getSlides().get_Item(0)

    # Genişlikleriyle sütunları ve yükseklikleriyle satırları tanımlar
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Tablo şekli slayta eklenir
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # Metin çerçevesine erişir
    text_frame = table.get_Item(0, 0).getTextFrame()

    # Metin çerçevesindeki ilk paragrafı alır.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # Paragraftaki ilk bölümü alır.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Metni dikey olarak hizalar
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # Sunumu diske kaydeder
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tablo Düzeyinde Metin Biçimlendirmesini Ayarlama**

1. Presentation sınıfının bir örneğini oluşturun.  
2. İndeksine göre bir slayta referans alın.  
3. Slayttan bir Table nesnesine erişin.  
4. Metnin font yüksekliğini setFontHeight yöntemiyle ayarlayın.  
5. Hizalamayı ve sağ kenar boşluğunu setAlignment ve setMarginRight yöntemleriyle ayarlayın.  
6. Dikey metin tipini setTextVerticalType yöntemiyle ayarlayın.  
7. Değiştirilmiş sunumu kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Presentation sınıfının bir örneğini oluşturur
presentation = Presentation("simpletable.pptx")
try:

    # İlk slayttaki ilk şeklin bir tablo olduğunu varsayalım
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # Tablo hücrelerinin font yüksekliğini ayarlar
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # Tablo hücrelerinin metin hizalamasını ve sağ kenar boşluğunu tek çağrıda ayarlar
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # Tablo hücrelerinin dikey metin tipini ayarlar
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Tablo Stil Özelliklerini Almak**

Aspose.Slides, bir tablonun stil özelliklerini almanıza olanak tanır; bu detayları başka bir tablo ya da başka bir yerde kullanabilirsiniz. Bu Python kodu, bir tablo ön ayarı stilinden stil özelliklerini almayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # varsayılan stil ön ayarı temasını değiştirir

    # Tablonun stil ön ayarını alır
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # Alınan stil ön ayarını başka bir tabloya uygular
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir Tablonun En‑Boy Oranını Kilitleme**

Geometrik bir şeklin en‑boy oranı, farklı boyutlardaki ölçülerinin oranıdır. Aspose.Slides, tablolar ve diğer şekiller için en‑boy oranı kilitleme ayarını sağlamak amacıyla setAspectRatioLocked yöntemini sunar.

Bu Python kodu, bir tablonun en‑boy oranını kilitlemeyi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # tersine çevir
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **SSS**

**Bir tablonun tamamı ve hücrelerindeki metin için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, setRightToLeft yöntemini sunar ve paragrafların ParagraphFormat.setRightToLeft yöntemi vardır. Her ikisini de kullanmak, hücre içindeki doğru RTL sırasını ve render edilmesini sağlar.

**Kullanıcıların final dosyasında bir tabloyu taşımasını veya yeniden boyutlandırmasını nasıl önleyebilirim?**

[shape locks](/slides/tr/python-java/applying-protection-to-presentation/) kullanarak taşıma, yeniden boyutlandırma, seçim vb. işlemleri devre dışı bırakın. Bu kilitler tablo için de geçerlidir.

**Bir hücrenin içinde arka plan resmi olarak bir görüntü eklemek destekleniyor mu?**

Evet. Bir hücreye picture fill ayarlayabilirsiniz; görüntü seçilen moda (germe veya döşeme) göre hücre alanını kaplar.