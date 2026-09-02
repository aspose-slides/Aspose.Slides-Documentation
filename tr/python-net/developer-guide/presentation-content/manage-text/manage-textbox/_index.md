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
- hiperbağlantı ekle
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET, PowerPoint ve OpenDocument dosyalarında metin kutularını oluşturmayı, düzenlemeyi ve kopyalamayı kolaylaştırır, sunum otomasyonunuzu geliştirir."
---
## **Giriş**

Slaytlardaki metinler tipik olarak metin kutularında veya şekillerde bulunur. Bu nedenle, bir slayta metin eklemek için önce bir metin kutusu eklemeli ve ardından metin kutusunun içine metin yerleştirmelisiniz. Aspose.Slides for Python, bazı metin içeren bir şekil eklemenizi sağlayan [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) sınıfını sunar.

{{% alert title="Info" color="info" %}}
Aspose.Slides ayrıca [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) sınıfını sağlar. Ancak, tüm şekiller metin tutamaz.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Bu nedenle, metin eklemek istediğiniz bir şekille çalışırken, şeklin [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) sınıfı aracılığıyla dönüştürülüp dönüştürülmediğini kontrol etmek ve doğrulamak isteyebilirsiniz. Ancak o zaman [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) altındaki bir özellik olan [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) ile çalışabilirsiniz. Bu sayfadaki [Metni Güncelle](/slides/tr/python-net/manage-textbox/#update-text) bölümüne bakın.
{{% /alert %}}

## **Slaytlarda Metin Kutuları Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İlk slayta bir referans alın.  
3. İstediğiniz konumda slayta `ShapeType.RECTANGLE` ile bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.  
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) içindeki metni ayarlayın.  
5. Sunumu PPTX dosyası olarak kaydedin.  

Aşağıdaki Python örneği bu adımları uygular:

```py
import aspose.slides as slides

# Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # Sunumdaki ilk slaytı alın.
    slide = presentation.slides[0]

    # RECTANGLE tipinde bir AutoShape ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Sunumu diske kaydedin.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Şeklin Metin Kutusu Olup Olmadığını Kontrol Etme**

Aspose.Slides, bir şeklin metin kutusu olup olmadığını belirlemenizi sağlayan [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) sınıfındaki [is_text_box](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/is_text_box/) özelliğini sunar.

![Metin kutusu ve şekil](istextbox.png)

Bu Python örneği, bir şeklin metin kutusu olarak oluşturulup oluşturulmadığını nasıl kontrol edeceğinizi gösterir:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Eğer bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) i [ShapeCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/) sınıfını kullanarak eklerseniz, şeklin `is_text_box` özelliği `False` döner. Ancak, metin ekledikten sonra—`add_text_frame` yöntemiyle ya da `text` özelliğini ayarlayarak—`is_text_box` `True` döner.

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

## **Bir TextFrame'i Sahip Olan Şekli Bulma**

Genel metin işleme kodunda, bir [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) alabilirsiniz ve bunun hangi sunum nesnesinde bulunduğunu önceden bilmeyebilirsiniz. Sahibi olan [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) nesnesine geri dönmek için [TextFrame.parent_shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/parent_shape/) özelliğini kullanın.

[AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) veya başka bir metin içeren şekle ait bir metin çerçevesi için, [TextFrame.parent_shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/parent_shape/) ayarlanmıştır ve [TextFrame.parent_cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/parent_cell/) `None` dır. Her iki özellik de yalnızca okunabilir gezinme özellikleridir, bu yüzden okumak sahipliği değiştirmez. Şekle erişmeden önce her zaman döndürülen değerin `None` olup olmadığını kontrol edin.

SmartArt düğümleriyle ilişkili şekiller de dahil olmak üzere şekil ve tablo hücresi sahiplerini tanımlayan tam bir örnek için [Metin Arama ve Değiştirme](/slides/tr/python-net/search-and-replace-text/) bölümüne bakın.

## **Metin Kutularına Sütun Ekleme**

Aspose.Slides, metin kutularına sütun eklemek için [TextFrameFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/) sınıfındaki [column_count](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/column_count/) ve [column_spacing](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/column_spacing/) özelliklerini sunar. Sütun sayısını belirtebilir ve sütunlar arasındaki boşluğu (nokta cinsinden) ayarlayabilirsiniz.

Aşağıdaki Python kodu bu işlemi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Sunumdaki ilk slaytı al.
	slide = presentation.slides[0]

	# RECTANGLE tipinde bir AutoShape ekle.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Dikdörtgene bir TextFrame ekle.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# TextFrame'in metin formatını al.
	format = shape.text_frame.text_frame_format

	# TextFrame'deki sütun sayısını belirt.
	format.column_count = 3

	# Sütunlar arasındaki boşluğu belirt.
	format.column_spacing = 10

	# Sunumu kaydet.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Metni Güncelleme**

Aspose.Slides, tek bir metin kutusundaki veya tüm sunumdaki metni güncellemenizi sağlar.

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
                        portion.portion_format.font_bold = slides.NullableBool.TRUE
  
    # Değiştirilmiş sunumu kaydet.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Köprü (Hyperlink) İçeren Metin Kutuları Ekleme**

Bir metin kutusuna bir bağlantı ekleyebilirsiniz. Metin kutusuna tıklandığında bağlantı açılır.

Köprü içeren bir metin kutusu eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İlk slayta bir referans alın.  
3. Slaytta istediğiniz konuma `ShapeType.RECTANGLE` ile bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.  
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) içindeki metni ayarlayın.  
5. [HyperlinkManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkmanager/) sınıfına bir referans alın.  
6. `hyperlink_manager` özelliğini kullanarak harici bir tıklama köprüsü ayarlayın.  
7. Sunumu PPTX dosyası olarak kaydedin.  

Bu Python örneği, bir slayta köprü içeren bir metin kutusu eklemenin nasıl yapılacağını gösterir:

```py
import aspose.slides as slides

# Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # Sunumdaki ilk slaytı alın.
    slide = presentation.slides[0]

    # RECTANGLE tipinde bir AutoShape ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Çerçeveye metin ekleyin.
    text_portion.text = "Aspose.Slides"

    # Parça metni için bir hiperbağlantı ayarlayın.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Sunumu PPTX dosyası olarak kaydedin.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Metin kutusu ile ana slaytlarla çalışırken metin yer tutucusu arasındaki fark nedir?**

[yer tutucu](/slides/tr/python-net/manage-placeholder/) [ana slayt](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslide/) stilini/konumunu devralır ve [layout](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/)larda geçersiz kılınabilir, oysa normal bir metin kutusu belirli bir slaytta bağımsız bir nesnedir ve layoutları değiştirdiğinizde değişmez.

**Sunumda grafik, tablo ve SmartArt içindeki metinlere dokunmadan toplu metin değiştirme nasıl yapılır?**

Yinelemeyi yalnızca metin çerçevelerine sahip otomatik şekillerle sınırlayın ve gömülü nesneleri ([charts](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartart/)) ayrı ayrı koleksiyonlarını gezerek ya da bu nesne türlerini atlayarak dışarıda bırakın.