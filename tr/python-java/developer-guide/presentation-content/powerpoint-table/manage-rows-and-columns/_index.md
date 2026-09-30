---
title: PowerPoint Tablolarında Satır ve Sütunları Python ile Yönetme
linktitle: Satır ve Sütunlar
type: docs
weight: 20
url: /tr/python-java/manage-rows-and-columns/
keywords:
- tablo satırı
- tablo sütunu
- ilk satır
- tablo başlığı
- satırı çoğalt
- sütunu çoğalt
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
description: "Aspose.Slides for Python via Java ile PowerPoint'te tablo satır ve sütunlarını yönetin ve sunum düzenleme ve veri güncellemelerini hızlandırın."
---
## **Giriş**

Aspose.Slides for Python via Java, PowerPoint sunumlarında tablo yapısını ve biçimlendirmesini [Tablo](https://reference.aspose.com/slides/python-java/aspose.slides/table/) sınıfı aracılığıyla yönetmenizi sağlar. Bir başlık satırı belirleyebilir, satır ve sütunları kopyalayabilir veya kaldırabilir ve bir bütün satır veya sütuna metin biçimlendirmesi uygulayabilirsiniz.

Bu makale bu işlemleri Python örnekleriyle açıklar. Ayrıca bir tablonun stil ön ayarını alıp yeniden kullanmayı gösterir. Tablo satır ve sütun indeksleri sıfır tabanlıdır.

## **Satır Yüksekliğini Kontrol Et**

[Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) metodunu kullanarak bir satırın minimum yüksekliğini nokta cinsinden ayarlayabilirsiniz. Bu bir alt sınırdır, sabit bir yükseklik değildir. [Row.getHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#getHeight) gerçek yüksekliği döndürür. Satıra [Table.getRows](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getRows) üzerinden erişin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren [row-height-input.pptx](row-height-input.pptx) dosyasını yükler. İlk satırı 70 noktada başlar. Hücreler 18 punto Arial metin, satır sonu ve 6 nokta üst‑alt kenar boşluğu kullanır; ikinci sütundaki uzun metin birden fazla satıra sarılır. Örnek minimumu 100 noktaya yükseltir, ardından 20 noktaya düşürür, her değişiklikten sonra gerçek yüksekliği yazdırır ve her iki sonucu da kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("row-height-input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    row = table.getRows().get_Item(0)

    row.setMinimalHeight(100)
    print(f"Increased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx)

    row.setMinimalHeight(20)
    print(f"Decreased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sağlanan sunumla, minimumu artırmak satıra boşluk ekler. Azaltmak bu ekstra boşluğu kaldırır, ancak gerçek yükseklik 20 noktadan büyük kalır çünkü metin ve hücre kenar boşlukları daha fazla alana ihtiyaç duyar. Yalnızca minimumu azaltmak, içeriğin gerektirdiği boşluğun altına satırı zorlayamaz.

Gerçek yüksekliği etkileyen çeşitli faktörler:

- **Metin ve yazı tipi boyutu:** daha uzun metin, açık satır sonları veya daha büyük bir yazı tipi daha fazla dikey alan gerektirebilir.
- **Sarma ve sütun genişliği:** sarma etkinleştirildiğinde, [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) ile sütun genişliğinin azaltılması daha fazla satır oluşturabilir. Daha geniş bir sütun dikey alana ihtiyaç duyulan boşluğu azaltabilir.
- **Hücre kenar boşlukları:** [Cell.setMarginTop](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginTop) ve [Cell.setMarginBottom](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginBottom) dikey boşluk ekler. [Cell.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginLeft) ve [Cell.setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginRight) metin için kullanılabilir genişliği azaltır ve ek sarma oluşturabilir.

Birleştirilmiş hücreleri olmayan bu tabloda, en çok dikey alan gerektiren hücre, tüm satırın içerik‑tabanlı alt sınırını belirler. Satırı kısaltmak için metni kısaltmanız, yazı tipi boyutunu veya kenar boşluklarını azaltmanız veya bir sütunu genişletmeniz gerekebilir.

Aşağıdaki görseller aynı tabloyu aynı ölçekte gösterir. Görselleştirilen sonuçlarda gerçek yükseklikler 70, 100 ve 55,2 nokta oldu: son satır 20 nokta minimumundan daha yüksek kaldı. Metin ölçümleri ortamınızdaki yazı tiplerine bağlı olarak değişebilir. Kaydedilmiş sonuçları indirin: [arttırılmış minimum](row-height-increased.pptx) ve [azaltılmış minimum](row-height-decreased.pptx).

| Orijinal: minimum 70 pt, gerçek 70 pt | Artırılmış: minimum 100 pt, gerçek 100 pt | Azaltılmış: minimum 20 pt, gerçek 55,2 pt |
| --- | --- | --- |
| ![İlk satırı 70 nokta olan orijinal tablo.](row-height-before.png) | ![İlk satırın minimumu 100 noktaya artırıldıktan sonraki tablo.](row-height-increased.png) | ![İlk satırın minimumu 20 noktaya azaltıldıktan sonraki tablo; sarılmış metin satırı minimumun üzerine çıkarır.](row-height-decreased.png) |

## **İlk Satırı Başlık Olarak Ayarla**

[setFirstRow](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setFirstRow) metodunu kullanarak ilk satırı başlık biçimlendirmesi için işaretleyin. Görünümü, tabloya uygulanan tablo stiline bağlıdır.

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfı ile sunumu yükleyin.
2. İlk slayta erişin.
3. Slayttaki ilk şekil olarak depolanan tabloya erişin.
4. İlk satırı için başlık biçimlendirmesini etkinleştirin.
5. Değiştirilmiş sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren `table.pptx` gerektirir. İlk satır için başlık biçimlendirmesini etkinleştirir ve `First_row_header.pptx` olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    table.setFirstRow(True)

    presentation.save("First_row_header.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir Tablo Satırını veya Sütununu Kopyala**

Satırları veya sütunları kopyalayarak içerik ve biçimlendirmelerini yeniden kullanın. Kopyayı tablonun sonuna ekleyebilir veya belirli bir konuma yerleştirebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfı ile sunumu yükleyin.
2. İlk slayta erişin.
3. Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
4. [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) metoduyla bir tablo ekleyin.
5. Gerekli satırları kopyalayın.
6. Gerekli sütunları kopyalayın.
7. Değiştirilmiş sunumu kaydedin.

Örnek `Test.pptx` gerektirir; en az bir slaytı olmalıdır. Üç sütun ve beş satırdan oluşan bir tablo oluşturur, boyutları nokta cinsindendir. İlk satır ve sütunun kopyalarını sona ekler, ardından ikinci satır ve sütunun kopyalarını 3. indeks (dördüncü konum) üzerine ekler. Sonuçta tablo yedi satır ve beş sütun olur. `False` argümanı, bitişik birleştirilmiş satır veya sütunlara kopyalamanın önüne geçer; bu tabloda birleştirilmiş hücre yoktur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([50, 50, 50])
    row_heights = jpype.JArray(jpype.JDouble)([50, 30, 30, 30, 30])
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

## **Bir Tablo Satırını veya Sütununu Kaldır**

Artık ihtiyaç duyulmayan satırları veya sütunları tablodan kaldırın. Bir öğeyi kaldırmak, ardından gelen satır veya sütunların indekslerini kaydırır.

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfı ile bir sunum oluşturun.
2. İlk slayta erişin.
3. Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
4. [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) metoduyla bir tablo ekleyin.
5. İkinci satırı ve ikinci sütunu kaldırın.
6. Değiştirilmiş sunumu kaydedin.

Bu örnek, üç‑üç tablo oluşturur ve indeks 1’deki satır ve sütunu kaldırarak `TestTable_out.pptx` içinde iki‑iki tablo bırakır. Boyutlar nokta cinsindendir. `False` argümanı, bitişik birleştirilmiş satır veya sütunların kaldırılmasını engeller; bu tabloda birleştirilmiş hücre yoktur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 50, 30])
    row_heights = jpype.JArray(jpype.JDouble)([30, 50, 30])
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)

    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tablo Satır Düzeyinde Metin Biçimlendirmesi Uygula**

Tüm satır için metin biçimlendirmesi uygulayarak hücrelerin tutarlı olmasını sağlayın. Her hücreyi ayrı ayrı biçimlendirmeye gerek kalmadan yazı tipi özelliklerini, paragraf biçimlendirmesini ve metin yönünü ayarlayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfı ile sunumu yükleyin.
2. İlk slayttaki tabloya erişin.
3. İlk satır için [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) kullanın.
4. İlk satır için [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) ve [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) kullanın.
5. İkinci satır için [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) kullanın.
6. Değiştirilmiş sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren ve en az iki satırı olan `table.pptx` gerektirir. İlk satıra 25 punto metin, sağ hizalama ve 20 punto sağ paragraf kenar boşluğu uygular, ardından ikinci satıra dikey metin ayarlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

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

    presentation.save("row_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tablo Sütun Düzeyinde Metin Biçimlendirmesi Uygula**

Tüm sütun için metin biçimlendirmesi uygulayarak hücrelerin tutarlı olmasını sağlayın. Her hücreyi ayrı ayrı biçimlendirmeye gerek kalmadan yazı tipi özelliklerini, paragraf biçimlendirmesini ve metin yönünü ayarlayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfı ile sunumu yükleyin.
2. İlk slayttaki tabloya erişin.
3. İlk sütun için [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) kullanın.
4. İlk sütun için [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) ve [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) kullanın.
5. İkinci sütun için [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) kullanın.
6. Değiştirilmiş sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren ve en az iki sütunu olan `table.pptx` gerektirir. İlk sütuna 25 punto metin, sağ hizalama ve 20 punto sağ paragraf kenar boşluğu uygular, ardından ikinci sütuna dikey metin ayarlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

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

    presentation.save("column_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tablo Stil Özelliklerini Al**

[getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) metodunu kullanarak bir tabloya uygulanan ön ayarı alabilir ve başka bir tabloda yeniden kullanabilirsiniz. Bu, bireysel hücre biçimlendirme geçersiz kılmalarından ziyade ön ayarı tanımlar.

Örnek bir tablo oluşturur, [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/#DarkStyle1) uygular ve ön ayarı geri okur. `DarkStyle1` karşılığı olan tamsayı değerini yazdırır ve tabloyu `table.pptx` olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 150])
    row_heights = jpype.JArray(jpype.JDouble)([5, 5, 5])
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print(style_preset)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Bir tablo oluşturulduktan sonra PowerPoint temalarını/biçimlerini uygulayabilir miyim?**

Evet. Tablo, slayt/yerleşim/ana tema miras alır ve yine de bu temanın üzerine dolgu, kenarlık ve metin renklerini geçersiz kılabilirsiniz.

**Tablo satırlarını Excel’deki gibi sıralayabilir miyim?**

Hayır, Aspose.Slides tablolarında yerleşik sıralama veya filtreleme bulunmaz. Verilerinizi önceden bellekte sıralayın, ardından tablo satırlarını o sırayla yeniden doldurun.

**Özel renkleri belirli hücrelerde tutarken, şeritli (çizgili) sütunlar elde edebilir miyim?**

Evet. Şeritli sütunları etkinleştirin, ardından belirli hücrelerde yerel biçimlendirme ile üzerine yazın; hücre‑düzeyi biçimlendirme tablo stiline göre önceliklidir.