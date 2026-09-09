---
title: Python via Java Kullanarak Sunumlarda Metin Kutularını Yönetme
linktitle: Metin Kutusunu Yönet
type: docs
weight: 20
url: /tr/python-java/manage-textbox/
keywords:
  - metin kutusu
  - metin çerçevesi
  - metin ekle
  - metni güncelle
  - metin kutusu oluştur
  - metin kutusunu kontrol et
  - metin sütunu ekle
  - hiperlink ekle
  - PowerPoint
  - sunum
  - Python
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument sunumlarında metin kutularını oluşturma, tanımlama, biçimlendirme ve güncelleme."
---
## **Giriş**

Aspose.Slides for Python via Java'da, slayt metni şekillere ait metin çerçevelerinde depolanır. [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) sınıfı en yaygın metin içeren şekli temsil eder ve metnini [AutoShape.getTextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/#getTextFrame) yöntemiyle ortaya çıkarır.

{{% alert color="info" title="Note" %}}
Her otomatik şekil [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) sınıfından miras alır, ancak her şekil bir otomatik şekil değildir veya bir metin çerçevesini desteklemez. Mevcut bir sunumu işlerken, bir şeklin metnine erişmeden önce onun [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) örneği olduğundan emin olun.
{{% /alert %}}

## **Bir Slaytta Metin Kutusu Oluşturma**

Bir metin kutusu oluşturmak için bir slayta otomatik şekil ekleyin, metin çerçevesine metin ekleyin ve sunumu kaydedin. Aşağıdaki örnek dikdörtgen bir metin kutusu oluşturur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[ShapeCollection.addAutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addAutoShape) yöntemine geçirilen koordinat ve boyutlar nokta biriminde ölçülür. [AutoShape.addTextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/#addTextFrame) verilen metinle metin çerçevesini başlatır.

## **Metin Kutusu Şekli Kontrolü**

Bir otomatik şeklin metin kutusu olarak ele alınıp alınmadığını belirlemek için [AutoShape.isTextBox](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/#isTextBox) yöntemini kullanın. Bu, bir sunumda hem metin içeren hem de yalnızca grafiksel otomatik şekiller bulunduğunda yararlıdır.

![Bir metin kutusu ve bir şekil](istextbox.png)

Aşağıdaki örnek bir sunumdaki tüm otomatik şekilleri inceler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

Yeni eklenen bir otomatik şekil, içinde boş olmayan metin bulunmadıkça metin kutusu olarak değerlendirilmez. Bu metni [AutoShape.addTextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/#addTextFrame) veya [TextFrame.setText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#setText) aracılığıyla sağlayabilirsiniz. Boş bir dize eklemek veya atamak, [AutoShape.isTextBox](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/#isTextBox) metodunun `False` döndürmesine yol açar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

İlk iki çağrı `True`, son iki çağrı ise `False` yazdırır.

## **Metin Çerçevesine Sahip Şekli Bulma**

Genel metin işleme kodu, hangi sunum nesnesinin içinde olduğunu bilmeden bir [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) alabilir. Sahibi olan [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) nesnesine geri dönmek için yalnızca‑okunur [TextFrame.getParentShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#getParentShape) yöntemini kullanın.

Otomatik şekil ya da başka bir metin içeren şekil tarafından sahip olunan bir metin çerçevesi için [TextFrame.getParentShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#getParentShape) sahibi döndürür ve [TextFrame.getParentCell](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#getParentCell) `None` döndürür. Erişmeden önce döndürülen değeri kontrol edin. Hem şekil hem de tablo‑hücre sahiplerini, SmartArt düğümleriyle ilişkilendirilen şekilleri tanımlamak için [Search and Replace Text](/slides/tr/python-java/search-and-replace-text/) bölümüne bakın.

## **Metin Kutusuna Sütun Ekleme**

[TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setColumnCount) yöntemi metin çerçevesini sütunlara böler, [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setColumnSpacing) ise sütunlar arasındaki boşluğu nokta biriminde ayarlar. Her iki ayar da [TextFrameFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/) sınıfına aittir ve mevcut bir metin kutusunun metin çerçevesi üzerinden değiştirilebilir. Metin aynı şekil içinde sütunlar arasında yeniden akar; başka bir şekle devam etmez.

Aşağıdaki örnek, sütunlar arası 10 nokta boşlukla üç sütunlu bir metin kutusu oluşturur, sunumu kaydeder ve ayarları çıktı dosyasından geri okur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **Tek Tek Sütunlardan Metin Çıkarma**

Mevcut bir metin çerçevesinde her görsel sütuna atanmış metni almak için [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#splitTextByColumns) yöntemini kullanın. Yöntem, sütun‑tabanlı okuma sırasına göre her sütun için bir dize döndürür. Tek‑sütunlu bir metin çerçevesi bir elemanlı bir dizi üretirken, boş bir sütun boş bir dizeyle temsil edilir. Dize yalnızca düz metin içerir; bölüm‑seviye biçimlendirme korunmaz.

Bu, aşağıdaki durumlarda kullanışlıdır:

- Metni, sütun‑tabanlı okuma sırasını koruyarak çıkarma.
- Çok‑sütunlu slaytların içeriğini indeksleme veya karşılaştırma.
- Her sütunu ayrı bir dosyaya, veritabanı alanına veya başka bir hedefe aktarma.
- [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setColumnCount), [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setColumnSpacing), font veya metin‑çerçevesi boyutu gibi ayarları değiştirdikten sonra metnin nasıl yeniden dağıtıldığını inceleme.

Yöntem, mevcut [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) içinde dağıtılan metni rapor eder; ayrı şekiller veya metin kutuları arasında otomatik akış oluşturmaz. Sütun dağılımı kullanılabilir fontlar ve diğer metin‑dizayn ayarlarına bağlı olabilir; tutarlı sonuçların önemli olduğu durumlarda gerekli fontların mevcut olduğundan emin olun.

Aşağıdaki örnek bir sunumu yükler, metin çerçevesi olan ilk çok‑sütunlu otomatik şekli bulur, yapılandırılmış sütun sayısını okur ve her sütunun metnini ayrı bir dosyaya yazar. Metin çerçevesi sağlamayan şekiller atlanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **Metni Güncelleme**

Bir sunumda metni güncellemek için slaytları ve şekilleri yineleyin, otomatik şekilleri seçin ve ardından metin bölümlerini düzenleyin. Bölüm seviyesinde çalışmak, hem metni hem de karakter biçimlendirmesini değiştirmenize olanak tanır.

Aşağıdaki örnek, otomatik‑şekil metnindeki her `years` ifadesini `months` ile değiştirir ve etkilenen her bölümü kalın yapar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bu gezinme yalnızca otomatik şekillerdeki metni günceller. Tablolar, grafikler, SmartArt veya gruplanmış şekillerde depolanan metin, bu nesnelerin kendi koleksiyonlarının yinelemesini gerektirir.

## **Bağlantılı Bir Metin Kutusu Ekleme**

Bir bağlantı, belirli bir metin bölümüne atanabilir; böylece yalnızca o metin tıklanabilir bağlantı haline gelir. Bölümü harici bir URL ile ilişkilendirmek için [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) metodunu kullanın.

Aşağıdaki örnek bağlantılı metin oluşturur ve bir sunuma kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Metin kutusu ile bir ana slayt veya düzen slaytındaki metin yer tutucusu arasındaki fark nedir?**

[placeholder](/slides/tr/python-java/manage-placeholder/) bir [master slide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/) veya [layout slide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layoutslide/) üzerinden konum ve biçimlendirmesini miras alabilir. Normal bir metin kutusu, oluşturulduğu slaytta bağımsız bir şekildir ve düzen değiştiğinde yer tutucu davranışı edinmez.

**Grafiklerde, tablolarda veya SmartArt'ta metni değiştirmeden metni nasıl değiştirebilirim?**

Metni yalnızca [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) örnekleri olan şekillerde dolaşarak güncelleyin; bu, Metni Güncelleme örneğinde gösterildiği gibidir. Grafikler, tablolar ve SmartArt kendi nesne modellerinde metin depolar, bu yüzden o döngü tarafından değiştirilmezler.