---
title: PowerPoint Tablolarında Satır ve Sütunları Python Kullanarak Yönetme
linktitle: Satır ve Sütunlar
type: docs
weight: 20
url: /tr/python-java/manage-rows-and-columns/
keywords:
- tablo satırı
- tablo sütunu
- ilk satır
- tablo üstbilgisi
- satırı klonla
- sütunu klonla
- satırı kopyala
- sütunu kopyala
- satırı kaldır
- sütunu kaldır
- satır metin biçimlendirme
- sütun metin biçimlendirme
- tablo stili
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint'te tablo satır ve sütunlarını yönetin, sunum düzenleme ve veri güncellemelerini hızlandırın."
---
## **Giriş**

PowerPoint sunumundaki bir tablonun satır ve sütunlarını yönetebilmeniz için Aspose.Slides, [Table](https://reference.aspose.com/slides/tr/python-java/aspose.slides/table/) sınıfını ve birçok diğer türü sağlar.

## **İlk Satırı Üstbilgi Olarak Ayarla**

1. Sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Dizini kullanarak bir slayta referans alın.  
3. Bir [Table](https://reference.aspose.com/slides/tr/python-java/aspose.slides/table/) referansı oluşturun ve `None` değerine atayın.  
4. İlgili tabloyu bulmak için tüm [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) nesnelerini döngüyle gezinin.  
5. Tablonun ilk satırını üstbilgi olarak ayarlayın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir Tablo Satırını veya Sütununu Kopyala**

1. Sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Dizini kullanarak bir slayta referans alın.  
3. Sütun genişliklerinin bir listesini tanımlayın.  
4. Satır yüksekliklerinin bir listesini tanımlayın.  
5. [addTable](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addTable) yöntemiyle slayta bir [Table](https://reference.aspose.com/slides/tr/python-java/aspose.slides/table/) nesnesi ekleyin.  
6. Tablo satırını kopyalayın.  
7. Tablo sütununu kopyalayın.  
8. Değiştirilen sunumu kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)
    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tablodan Bir Satır veya Sütun Kaldır**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.  
2. Dizini kullanarak bir slayta referans alın.  
3. Sütun genişliklerinin bir listesini tanımlayın.  
4. Satır yüksekliklerinin bir listesini tanımlayın.  
5. [addTable](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addTable) yöntemiyle slayta bir [Table](https://reference.aspose.com/slides/tr/python-java/aspose.slides/table/) nesnesi ekleyin.  
6. Tablo satırını kaldırın.  
7. Tablo sütununu kaldırın.  
8. Değiştirilen sunumu kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tablo Satır Seviyesinde Metin Biçimlendirmesini Ayarla**

1. Sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Dizini kullanarak bir slayta referans alın.  
3. Slayttan ilgili [Table](https://reference.aspose.com/slides/tr/python-java/aspose.slides/table/) nesnesine erişin.  
4. İlk satır hücrelerinin yazı tipi yüksekliğini [setFontHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setFontHeight) kullanarak ayarlayın.  
5. İlk satır hücrelerinin metin hizalamasını ve sağ kenar boşluğunu [setAlignment](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setAlignment) ve [setMarginRight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setMarginRight) kullanarak ayarlayın.  
6. İkinci satır hücrelerinin dikey metin tipini [setTextVerticalType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setTextVerticalType) kullanarak ayarlayın.  
7. Değiştirilen sunumu kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getRows().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getRows().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getRows().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Tablo Sütun Seviyesinde Metin Biçimlendirmesini Ayarla**

1. Sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Dizini kullanarak bir slayta referans alın.  
3. Slayttan ilgili [Table](https://reference.aspose.com/slides/tr/python-java/aspose.slides/table/) nesnesine erişin.  
4. İlk sütun hücrelerinin yazı tipi yüksekliğini [setFontHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setFontHeight) kullanarak ayarlayın.  
5. İlk sütun hücrelerinin metin hizalamasını ve sağ kenar boşluğunu [setAlignment](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setAlignment) ve [setMarginRight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setMarginRight) kullanarak ayarlayın.  
6. İkinci sütun hücrelerinin dikey metin tipini [setTextVerticalType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setTextVerticalType) kullanarak ayarlayın.  
7. Değiştirilen sunumu kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getColumns().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getColumns().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getColumns().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Tablo Stil Özelliklerini Al**

Aspose.Slides, bir tablonun stil özelliklerini almanıza olanak tanır, böylece bu ayrıntıları başka bir tablo için veya başka bir yerde kullanabilirsiniz. Bu Python kodu, bir tablo ön ayar stilinden stil özelliklerini nasıl alacağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Zaten oluşturulmuş bir tabloya PowerPoint temalarını/stillerini uygulayabilir miyim?**

Evet. Tablo, slayt/layout/master temasını devralır ve yine de o tema üzerine dolgu, kenarlık ve metin renklerini geçersiz kılabilirsiniz.

**Tablo satırlarını Excel gibi sıralayabilir miyim?**

Hayır, Aspose.Slides tablolarında yerleşik sıralama veya filtreleme yoktur. Verilerinizi önce bellekte sıralayın, ardından tablo satırlarını o sırayla yeniden doldurun.

**Belirli hücrelerde özel renkler tutarken şeritli (banded) sütunlar olabilir mi?**

Evet. Şeritli sütunları etkinleştirin, ardından belirli hücreleri yerel biçimlendirme ile geçersiz kılın; hücre seviyesindeki biçimlendirme tablo stiline göre önceliklidir.