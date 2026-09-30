---
title: Python'da Sunum Tablolarını Yönetme
linktitle: Tabloyu Yönet
type: docs
weight: 10
url: /tr/python-java/manage-table/
keywords:
- tablo ekle
- tablo oluştur
- tabloya eriş
- en-boy oranı
- metni hizala
- metin biçimlendirme
- tablo stili
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint slaytlarında tablolar oluşturun ve düzenleyin. Tablo iş akışlarınızı kolaylaştırmak için basit kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'teki tablolar, bilgiyi satır ve sütunlara düzenleyerek değerlerin okunmasını ve karşılaştırılmasını kolaylaştırır.

Aspose.Slides, sunumlarda tabloları oluşturmanızı, güncellemenizi ve yönetmenizi sağlayan [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) ve [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) sınıfları ve diğer türleri sağlar.

## **Sıfırdan Tablo Oluşturma**

Konumunu, sütun genişliklerini ve satır yüksekliklerini belirterek bir tablo oluşturun. Slayta ekledikten sonra hücre kenarlıklarını biçimlendirebilir, hücreleri birleştirebilir ve metin ekleyebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksine göre slayta bir referans alın.  
3. Puan cinsinden sütun genişliklerinin bir listesini tanımlayın.  
4. Puan cinsinden satır yüksekliklerinin bir listesini tanımlayın.  
5. Slayta, [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) yöntemi aracılığıyla bir [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) nesnesi ekleyin.  
6. Her bir [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) üzerinden döngü yaparak üst, alt, sağ ve sol kenarlıklara biçimlendirme uygulayın.  
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.  
8. Birleştirilen hücreye, [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) yöntemiyle erişin.  
9. Birleştirilen hücreye metni ayarlayın.  
10. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek, (100, 50) puanda üç sütun ve beş satırdan oluşan bir tablo oluşturur. 5 puan genişliğinde kırmızı kenarlıklar uygular, ilk satırdaki ilk iki hücreyi birleştirir ve sonucu `table.pptx` olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

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

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Standart Bir Tablo İçinde Numaralandırma**

Standart bir tabloda hücre indeksleri sıfır tabanlıdır ve (sütun, satır) sırasını kullanır. İlk hücre (0, 0) olarak indekslenir.

Örneğin, 4 sütun ve 4 satırdan oluşan bir tablodaki hücreler şu şekilde numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu örnek, yukarıda gösterilen 4 × 4 tabloyu, sütun genişlikleri ve satır yükseklikleri 70 puan ve 5 puan genişliğinde kırmızı hücre kenarlıklarıyla oluşturur. Koordinatlar hücre indekslerini gösterir; örnek hücreleri boş bırakır ve tabloyu `StandardTables_out.pptx` olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

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

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mevcut Bir Tabloya Erişim**

Tablolar, bir slaydın şekil koleksiyonunda depolanır. Şekilleri dolaşarak bir tablo bulun, ardından [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) sınıfını kullanarak hücrelerini okuyabilir veya güncelleyebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfını kullanarak sunumu yükleyin.  
2. İndeksine göre tabloyu içeren slayta bir referans alın.  
3. [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) nesnelerini dolaşın ve bir tablo bulunduğunda durun. Slayt birden fazla tablo içeriyorsa, ihtiyacınız olanı belirlemek için [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) yöntemini kullanın.  
4. Hedef hücredeki metni güncelleyin.  
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek `UpdateExistingTable.pptx` dosyasını açar ve ilk slayttaki ilk tabloyu bulur. 0. sütun, 1. satır hücresine `New` değerini atar ve sonucu `table1_out.pptx` olarak kaydeder. Giriş dosyası en az bir slayt içermeli ve o slayttaki ilk tablo en az bir sütun ve iki satır içermelidir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mevcut bir tabloda bir satırı yeniden boyutlandırmak ve gerçek yüksekliğinin istenen minimumu neden aşabileceğini anlamak için [Control Row Height](/slides/tr/python-java/manage-rows-and-columns/#control-row-height) bölümüne bakın.

## **Bir Metin Çerçevesine Sahip Hücreyi Bulma**

Genel metin işleme kodu bir tablodan [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) aldığında, sahibi olan [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) nesnesini elde etmek için [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) yöntemini kullanın. Bir tablo hücresi metin çerçevesi için [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) sahibi döner ve [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) `None` döner, tablonun kendisi bir şekil olsa bile.

Hücre koordinatları, yalnızca okuma izni olan [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) ve [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) yöntemleriyle elde edilebilir. [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) aynı zamanda yalnızca okuma navigasyonu sağlar: sahibi döner ancak sahipliği değiştirmez. Kullanımdan önce döndürülen hücrenin `None` olup olmadığını kontrol edin.

SmartArt düğümleriyle ilişkili şekilleri de içeren tablo hücresi ve şekil sahiplerini tanımlayan tam bir örnek için [Search and Replace Text](/slides/tr/python-java/search-and-replace-text/) bölümüne bakın.

## **Tablodaki Metni Hizalama**

Tek tek tablo hücrelerinin dikey sabitlemesini ve metin yönünü kontrol edebilirsiniz. Bu bölümdeki örnek, ilk hücredeki metni ortalar ve 270 derece döndürür.

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksine göre slayta bir referans alın.  
3. Slayta bir [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) nesnesi ekleyin.  
4. Tablodan bir [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) nesnesine erişin.  
5. İlk [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) nesnesine erişin ve metnini ve rengini ayarlayın.  
6. [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) ve [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType) kullanarak hücrenin dikey sabitlemesini ve metin yönünü ayarlayın.  
7. Değiştirilmiş sunumu kaydedin.

Bu örnek, 120 puan sütun genişliği ve 100 puan satır yüksekliği olan 4 × 4 bir tablo oluşturur. (0, 0) hücresindeki metni biçimlendirir, ilk satırdaki kalan hücrelere değer ekler ve sonucu `Vertical_Align_Text_out.pptx` olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tablo Düzeyinde Metin Biçimlendirmesini Ayarlama**

[setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) kullanarak bir tablodaki tüm hücrelere metin biçimlendirmesi uygulayabilirsiniz. Aşırı yüklemeleri bölüm, paragraf ve metin çerçevesi biçimlendirmesini kabul eder, böylece bireysel hücreleri dolaşmadan bu özellikleri ayarlayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfını kullanarak sunumu yükleyin.  
2. İndeksine göre slayta bir referans alın.  
3. Slayttan bir [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) nesnesine erişin.  
4. Metin için [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) kullanarak yazı tipi boyutunu ayarlayın.  
5. [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) ve [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) kullanarak paragraf hizalamasını ve sağ kenar boşluğunu ayarlayın.  
6. [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) kullanarak metin yönünü ayarlayın.  
7. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek, ilk şekli tablo olan en az bir slayt içeren `table.pptx` dosyasını açar. Yazı tipi boyutunu 25 puana, paragrafları sağa hizalayarak 20 puan sağ kenar boşluğu ve metni dikey yapar. Biçimlendirilmiş sunum `result.pptx` olarak kaydedilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tablo Stil Özelliklerini Almak**

Bir tablonun ön tanımlı stilini okumak için [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) ve atamak için [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) kullanın. Bu örnek, bir tabloya [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) uygular, ön tanımlı değeri yazdırır ve aynı ön tanımlıyı ikinci tabloya atar. Her iki tablo da `table-style.pptx` içinde kaydedilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir Tablonun En-Boy Oranını Kilitleme**

Bir tablonun en-boy oranı, genişliğinin yüksekliğine oranıdır. Bu oranı bir tablo için kilitlemek üzere [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) kullanın.

Aşağıdaki örnek, ilk şekli tablo olan en az bir slayt içeren `pres.pptx` dosyasını açar. Mevcut kilit durumunu yazdırır, en-boy oranı kilidini etkinleştirir, güncellenmiş durumu (`True`) yazar ve sonucu `pres-out.pptx` olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Bir tablonun tamamı ve hücrelerindeki metin için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, bir [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft) yöntemi sunar ve paragraflar da [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft) yöntemine sahiptir. İkisini birlikte kullanmak, hücre içindeki doğru RTL sırasını ve görüntülenmesini sağlar.

**Kullanıcıların son dosyada bir tabloyu taşımasını veya yeniden boyutlandırmasını nasıl engelleyebilirim?**

[shape locks](/slides/tr/python-java/applying-protection-to-presentation/) kullanarak taşıma, yeniden boyutlandırma, seçim vb. işlevleri devre dışı bırakabilirsiniz. Bu kilitler tabloya da uygulanır.

**Bir hücrenin arka planı olarak bir resim eklemek destekleniyor mu?**

Evet. Bir hücre için [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) ayarlayabilirsiniz; resim, seçilen moda (germe veya döşeme) göre hücre alanını kaplar.