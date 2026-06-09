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
- metni güncelle
- metin kutusu oluştur
- metin kutusunu kontrol et
- metin sütunu ekle
- köprü ekle
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET, PowerPoint ve OpenDocument dosyalarında metin kutularını oluşturmayı, düzenlemeyi ve kopyalamayı kolaylaştırarak sunum otomasyonunuzu geliştirir."
---
## **Giriş**

Slaytlardaki metinler genellikle metin kutuları veya şekiller içinde bulunur. Bu nedenle, bir slayta metin eklemek için bir metin kutusu eklemeniz ve ardından metni metin kutusuna koymanız gerekir. Aspose.Slides for Python, içinde metin bulunan bir şekil eklemenizi sağlayan [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) sınıfını sunar.

{{% alert title="Info" color="info" %}}
Aspose.Slides ayrıca [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) sınıfını sağlar. Ancak, tüm şekiller metin tutamaz.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Bu nedenle, metin eklemek istediğiniz bir şekille çalışırken, şeklin [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) sınıfı aracılığıyla dönüştürüldüğünden emin olmak isteyebilirsiniz. Ancak o zaman [AutoShape] altında bulunan bir özellik olan [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) ile çalışabilirsiniz. Bu sayfadaki [Metni Güncelle](/slides/tr/python-net/manage-textbox/#update-text) bölümüne bakın.
{{% /alert %}}

## **Slaytlara Metin Kutuları Oluşturma**

Bir slayta metin kutusu oluşturmak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. İlk slayta bir referans alın.
3. İstediğiniz konumda `ShapeType.RECTANGLE` ile bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) içinde metni ayarlayın.
5. Sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python örneği bu adımları uygular:

```py
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluştur.
with slides.Presentation() as presentation:

    # Sunumdaki ilk slaytı al.
    slide = presentation.slides[0]

    # RECTANGLE türünde bir AutoShape ekle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Sunumu diske kaydet.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Şeklin Metin Kutusu Olup Olmadığını Kontrol Etme**

Aspose.Slides, bir şeklin metin kutusu olup olmadığını belirlemenizi sağlayan [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) sınıfında [is_text_box](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/is_text_box/) özelliğini sunar.

![Text box and shape](istextbox.png)

Bu Python örneği, bir şeklin metin kutusu olarak oluşturulup oluşturulmadığını nasıl kontrol edeceğinizi gösterir:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Eğer [ShapeCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/) sınıfını kullanarak bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) eklerseniz, şeklin `is_text_box` özelliği `False` döner. Ancak, metin ekledikten sonra—`add_text_frame` yöntemiyle ya da `text` özelliğini ayarlayarak—`is_text_box` `True` döner.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box yanlış
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box doğru

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box yanlış
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box doğru

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box yanlış
    shape3.add_text_frame("")
    # shape3.is_text_box yanlış

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box yanlış
    shape4.text_frame.text = ""
    # shape4.is_text_box yanlış
```

## **Metin Kutularına Sütun Ekleme**

Aspose.Slides, metin kutularına sütun eklemek için [TextFrameFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/) sınıfında [column_count](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/column_count/) ve [column_spacing](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/column_spacing/) özelliklerini sunar. Sütun sayısını belirtebilir ve sütunlar arasındaki boşluğu (puan olarak) ayarlayabilirsiniz.

Aşağıdaki Python kodu bu işlemi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Sunumdaki ilk slaytı al.
	slide = presentation.slides[0]

	# RECTANGLE tipinde bir AutoShape ekle.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Dikdörtgen'e bir TextFrame ekle.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# TextFrame'in metin biçimini al.
	format = shape.text_frame.text_frame_format

	# TextFrame'deki sütun sayısını belirt.
	format.column_count = 3

	# Sütunlar arasındaki boşluğu belirt.
	format.column_spacing = 10

	# Sunumu kaydet.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Metni Güncelleme**

Aspose.Slides, tek bir metin kutusundaki metni ya da tüm sunumdaki metni güncellemenizi sağlar.

Aşağıdaki Python örneği, bir sunumdaki tüm metni nasıl güncelleyeceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # Değiştirilmiş sunumu kaydet.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Köprü İçeren Metin Kutuları Ekleme**

Bir metin kutusuna bağlantı ekleyebilirsiniz. Metin kutusuna tıklandığında bağlantı açılır.

Köprü içeren bir metin kutusu eklemek için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. İlk slayta bir referans alın.
3. İstediğiniz konumda `ShapeType.RECTANGLE` ile bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) içinde metni ayarlayın.
5. [HyperlinkManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkmanager/) sınıfına bir referans alın.
6. `hyperlink_manager` özelliğini kullanarak harici bir tıklama köprüsü ayarlayın.
7. Sunumu PPTX dosyası olarak kaydedin.

Bu Python örneği, bir slayta köprü içeren bir metin kutusu nasıl ekleneceğini gösterir:

```py
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluştur.
with slides.Presentation() as presentation:

    # Sunumdaki ilk slaytı al.
    slide = presentation.slides[0]

    # RECTANGLE tipinde bir AutoShape ekle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Çerçeveye metin ekle.
    text_portion.text = "Aspose.Slides"

    # Parça metnine bir köprü ayarla.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Sunumu PPTX dosyası olarak kaydet.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Bir ana slaytla çalışırken metin kutusu ile metin yer tutucu arasındaki fark nedir?**

[placeholder](/slides/tr/python-net/manage-placeholder/) [master](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslide/) stilini/konumunu devralır ve [layouts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/) üzerinde geçersiz kılınabilir, oysa normal bir metin kutusu belirli bir slaytta bağımsız bir nesnedir ve düzenleri değiştirdiğinizde değişmez.

**Sunum boyunca, grafikler, tablolar ve SmartArt içindeki metinlere dokunmadan toplu metin değiştirme nasıl yapılır?**

İterasyonunuzu yalnızca metin çerçevelerine sahip otomatik şekillere sınırlayın ve gömülü nesneleri ([charts](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartart/)) ayrı ayrı koleksiyonlarını gezerek ya da bu nesne türlerini atlayarak dışarıda bırakın.