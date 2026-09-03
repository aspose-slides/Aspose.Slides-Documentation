---
title: Python ile Sunumlarda Metin Kutularını Yönetme
linktitle: Metin Kutusunu Yönet
type: docs
weight: 20
url: /tr/python-net/manage-textbox/
keywords:
  - metin kutusu
  - metin çerçevesi
  - metin ekle
  - metin güncelle
  - metin kutusu oluştur
  - metin kutusunu kontrol et
  - metin sütunu ekle
  - köprü ekle
  - PowerPoint
  - sunum
  - Python
  - Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarında metin kutularını oluşturma, tanımlama, biçimlendirme ve güncelleme."
---
## **Giriş**

Aspose.Slides for Python via .NET'de slayt metni, şekillere ait metin çerçevelerinde depolanır. [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) sınıfı, en yaygın metin içeren şekli temsil eder ve metnini [AutoShape.text_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/text_frame/) özelliği aracılığıyla ortaya çıkar.

{{% alert color="info" title="Note" %}}
Her otomatik şekil [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) sınıfından türetilir, ancak her şekil bir otomatik şekil değildir veya bir metin çerçevesini desteklemez. Mevcut bir sunumu işlerken, şeklin metnine erişmeden önce şekil türünü kontrol etmek için `isinstance(shape, slides.AutoShape)` kullanın.
{{% /alert %}}

## **Bir Slaytta Metin Kutusu Oluşturma**

Metin kutusu oluşturmak için bir slayta otomatik bir şekil ekleyin, metni onun metin çerçevesine ekleyin ve sunumu kaydedin. Aşağıdaki örnek, dikdörtgen bir metin kutusu oluşturur:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

[ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_auto_shape/)'a geçirilen koordinatlar ve boyutlar puan cinsindendir. [AutoShape.add_text_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/add_text_frame/) metin çerçevesini verilen metinle başlatır.

## **Metin Kutusu Şekli Kontrolü**

Metin kutusu olarak kabul edilip edilmediğini belirlemek için [AutoShape.is_text_box](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/is_text_box/) özelliğini kullanın. Bu, bir sunumun hem metin içeren hem de yalnızca grafiksel otomatik şekiller içerdiği durumlarda faydalıdır.

![Bir metin kutusu ve bir şekil](istextbox.png)

Aşağıdaki örnek, bir sunumdaki her otomatik şekli inceler:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

Yeni eklenen bir otomatik şekil, boş olmayan metin içermediği sürece metin kutusu olarak kabul edilmez. Bu metni [AutoShape.add_text_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/add_text_frame/) veya [TextFrame.text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/text/) aracılığıyla sağlayabilirsiniz. Boş bir dize eklemek veya atamak, [is_text_box](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/is_text_box/) özelliğinin `False` olmasını sağlar:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

İlk iki çağrı `True` yazdırır; son iki çağrı ise `False` yazdırır.

## **Metin Çerçevesine Sahip Şekli Bulma**

Genel metin işleme kodu, hangi sunum nesnesinin içinde olduğunu bilmeden bir [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) alabilir. Sahip olduğu [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/)’e geri dönmek için yalnızca okunabilir [TextFrame.parent_shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/parent_shape/) özelliğini kullanın.

Bir otomatik şekil veya başka bir metin içeren şekil tarafından sahip olunan bir metin çerçevesi için, [parent_shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/parent_shape/) sahibi içerir ve [TextFrame.parent_cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/parent_cell/) `None`'dır. Erişmeden önce döndürülen değeri kontrol edin. Şekil ve tablo hücresi sahiplerini, SmartArt düğümleriyle ilişkili şekilleri de dahil olmak üzere tanımlamak için [Search and Replace Text](/slides/tr/python-net/search-and-replace-text/) bölümüne bakın.

## **Metin Kutusuna Sütun Ekleme**

[TextFrameFormat.column_count](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/column_count/) özelliği metin çerçevesini sütunlara böler, [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/column_spacing/) ise sütunlar arasındaki boşluğu puan cinsinden ayarlar. Her iki ayar da [TextFrameFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/)’a aittir ve mevcut bir metin kutusunun metin çerçevesi aracılığıyla değiştirilebilir. Metin aynı şekil içinde sütunlar arasında yeniden akar; başka bir şekle devam etmez.

Aşağıdaki örnek, sütunlar arasında 10 puan boşluk olan üç sütunlu bir metin kutusu oluşturur, sunumu kaydeder ve çıktı dosyasından kaydedilen ayarları geri okur:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **Bireysel Sütunlardan Metin Çıkarma**

Mevcut bir metin çerçevesindeki her görsel sütuna atanmış metni elde etmek için [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/split_text_by_columns/) kullanın. Yöntem, sütun tabanlı okuma sırasına göre her sütun için bir dize döndürür. Tek sütunlu bir metin çerçevesi bir öğe içeren bir liste üretir ve boş bir sütun boş bir dizeyle temsil edilir. Dize yalnızca düz metin içerir; parça düzeyindeki biçimlendirme korunmaz.

Bu, aşağıdaki durumlarda faydalıdır:

- Metni sütun tabanlı okuma sırasını koruyarak çıkarmak.
- Çok sütunlu slaytların içeriğini indekslemek veya karşılaştırmak.
- Her sütunu ayrı bir dosyaya, veri tabanı alanına veya başka bir hedefe aktarmak.
- [TextFrameFormat.column_count](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/column_count/), [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/column_spacing/), yazı tipini veya metin çerçevesi boyutunu değiştirdikten sonra metnin nasıl yeniden dağıtıldığını incelemek.

Yöntem, mevcut [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) içinde dağıtılan metni raporlar; ayrı şekiller veya metin kutuları arasında metni otomatik olarak akıtmaz. Sütun dağılımı, mevcut yazı tiplerine ve diğer metin düzeni ayarlarına bağlı olabilir; tutarlı sonuçların önemli olduğu durumlarda gerekli yazı tiplerinin mevcut olduğundan emin olun.

Aşağıdaki örnek bir sunumu yükler, metin çerçevesine sahip ilk çok sütunlu otomatik şekli bulur, yapılandırılmış sütun sayısını okur ve her sütundaki metni ayrı bir dosyaya yazar. Metin çerçevesi sağlamayan şekiller atlanır.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **Metni Güncelleme**

Bir sunumdaki metni güncellemek için slaytlar ve şekiller üzerinden döngü yapın, otomatik şekilleri seçin ve ardından metin bölümlerini düzenleyin. Bölüm seviyesinde çalışmak, hem metni hem de karakter biçimlendirmesini değiştirmenizi sağlar.

Aşağıdaki örnek, otomatik şekil metnindeki her `years` ifadesini `months` ile değiştirir ve etkilenen her bölümü kalın yapar:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

Bu dolaşım yalnızca otomatik şekillerdeki metni günceller. Tablo, grafik, SmartArt veya gruplanmış şekillerde depolanan metin, o nesnelerin kendi koleksiyonları üzerinden dolaşım gerektirir.

## **Köprü İçeren Bir Metin Kutusu Ekleme**

Bir köprü, belirli bir metin bölümüne atanabilir, böylece yalnızca o metin tıklanabilir bağlantı olur. Bölümü dış bir URL ile ilişkilendirmek için [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/) kullanın.

Aşağıdaki örnek bağlanmış metin oluşturur ve bir sunuma kaydeder:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Bir ana veya düzen slaytındaki metin kutusu ile metin yer tutucusu arasındaki fark nedir?**

Bir [placeholder](/slides/tr/python-net/manage-placeholder/) konumunu ve biçimlendirmesini bir [master slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslide/) veya [layout slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/) üzerinden devralabilir. Normal bir metin kutusu, oluşturulduğu slaytta bağımsız bir şekildir ve düzen değiştiğinde yer tutucu davranışı kazanmaz.

**Grafik, tablo veya SmartArt'taki metni değiştirmeden metni nasıl değiştirebilirim?**

Dolaşımı, Metni Güncelleme örneğinde gösterildiği gibi yalnızca [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) örnekleriyle sınırlayın. Grafikler, tablolar ve SmartArt, metni kendi nesne modellerinde sakladığından, bu döngü tarafından değiştirilmezler.