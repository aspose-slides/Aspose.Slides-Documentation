---
title: Python ile Sunumlarda Köprüleri Yönetme
linktitle: Köprüyü Yönet
type: docs
weight: 20
url: /tr/python-net/manage-hyperlinks/
keywords:
- URL ekle
- köprü ekle
- köprü oluştur
- köprü biçimlendir
- köprü kaldır
- köprüyü güncelle
- metin köprüsü
- slayt köprüsü
- şekil köprüsü
- resim köprüsü
- video köprüsü
- değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- Python
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument sunumlarında köprüleri zahmetsizce yönetin - dakikalar içinde etkileşimi ve iş akışını artırın."
---
## **Giriş**

Bir köprü, harici bir kaynağa, bir nesneye veya veri öğesine ya da bir dosya içindeki belirli bir konuma referanstır. PowerPoint sunumlarındaki yaygın köprü türleri şunlardır:

* Metin, şekil veya medya içine yerleştirilmiş web sitesi bağlantıları
* Slaytlara bağlantılar

Aspose.Slides for Python via .NET, sunumlarda çok çeşitli köprü‑ile ilgili işlemler yapmanıza olanak sağlar.

## **URL Köprüleri Ekleme**

Bu bölüm, Aspose.Slides ile çalışırken slayt öğelerine URL köprüleri eklemenin nasıl yapılacağını açıklar. Metin, şekil ve resimlere bağlantı adresleri atayarak sunum sırasında sorunsuz gezinmeyi sağlar.

### **Metne URL Köprüsü Ekleme**

Aşağıdaki kod örneği bir web sitesi köprüsünü metne nasıl ekleyeceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Şekillere veya Çerçevelere URL Köprüsü Ekleme**

Aşağıdaki kod örneği bir şekle web sitesi köprüsü eklemenin yolunu gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Medya İçin URL Köprüsü Ekleme**

Aspose.Slides, resim, ses ve video dosyalarına köprü eklemenizi sağlar.

Aşağıdaki kod örneği bir **resme** köprü eklemeyi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Sunuma bir resim ekle.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # Daha önce eklenen resmi kullanarak slayt 1'de bir resim çerçevesi oluştur.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Aşağıdaki kod örneği bir **ses dosyasına** köprü eklemeyi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Aşağıdaki kod örneği bir **videoya** köprü eklemeyi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="İpucu" color="primary" %}}
Sunumlarda Python kullanarak OLE yönetimini görmek isteyebilirsiniz[Manage OLE in Presentations Using Python](/slides/tr/python-net/manage-ole/).
{{% /alert %}}

## **İçindekiler Tablosu Oluşturmak İçin Köprü Kullanma**

Köprüler nesnelere veya konumlara referans vermenizi sağladığı için bir içindekiler tablosu oluşturmak için kullanılabilir.

Aşağıdaki örnek kod, köprülerle bir içindekiler tablosu nasıl oluşturulacağını gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Köprüleri Biçimlendirme**

Bu bölüm, Aspose.Slides içinde köprülerin görünümünün nasıl biçimlendirileceğini gösterir. Metin, şekil ve resimler arasında köprü biçimlendirmesinin tutarlı olmasını sağlamak için renk ve diğer stil seçeneklerini kontrol etmeyi öğreneceksiniz.

### **Köprü Rengi**

[Hyperlink](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/) sınıfının [color_source](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/color_source/) özelliğini kullanarak bir köprünün rengini ayarlayabilir ve renk bilgisini okuyabilirsiniz. Bu özellik PowerPoint 2019’da tanıtıldı; bu özellik aracılığıyla yapılan değişiklikler daha eski PowerPoint sürümlerine uygulanmaz.

Aşağıdaki örnek, aynı slayta farklı renklerde köprüler eklemeyi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Sunumlardan Köprüleri Kaldırma**

Bu bölüm, Aspose.Slides ile çalışırken sunumlardan köprüleri nasıl kaldıracağınızı açıklar. Metin, şekil ve resimlerdeki bağlantı hedeflerini orijinal içerik ve biçimlendirmeyi koruyarak nasıl temizleyeceğinizi öğreneceksiniz.

### **Metinden Köprüleri Kaldırma**

Aşağıdaki örnek kod, bir sunum slaydındaki metinden köprüleri nasıl kaldıracağınızı gösterir:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **Şekillerden veya Çerçevelerden Köprüleri Kaldırma**

Aşağıdaki örnek kod, bir sunum slaydındaki şekillerden köprüleri nasıl kaldıracağınızı gösterir:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Değiştirilebilir Köprüler**

[Hyperlink](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/) sınıfı değiştirilebilir. Bu sınıfı kullanarak aşağıdaki özelliklerin değerlerini değiştirebilirsiniz:

- [target_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

Aşağıdaki kod parçacığı, bir slayta köprü ekleyip ardından araç ipucunu nasıl düzenleyeceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **IHyperlinkQueries İçindeki Desteklenen Özellikler**

[HyperlinkQueries](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkqueries/) sınıfına, köprüyü içeren sunum, slayt veya metinden erişebilirsiniz.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/hyperlink_queries/)

[HyperlinkQueries](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkqueries/) sınıfı şu yöntemleri destekler:

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/tr/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Aspose’un basit, ücretsiz çevrimiçi [PowerPoint düzenleyicisini](https://products.aspose.app/slides/tr/editor) incelemek isteyebilirsiniz.
{{% /alert %}}

## **SSS**

**Bir slayta değil, bir “bölüm”e veya bir bölümün ilk slaytına iç navigasyon nasıl oluşturabilirim?**

PowerPoint’te bölümler, slayt gruplarıdır; navigasyon teknik olarak belirli bir slayta yönelir. “Bir bölüme gitmek” istediğinizde genellikle bölümün ilk slaytına bağlanırsınız.

**Ana slayt öğelerine köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?**

Evet. Ana slayt ve yerleşim öğeleri köprüleri destekler. Bu tür bağlantılar alt slaytlarda görünür ve slayt gösterisi sırasında tıklanabilir olur.

**Köprüler, PDF, HTML, görüntüler veya video olarak dışa aktarılırken korunur mu?**

[PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/python-net/convert-powerpoint-to-html/) dışa aktarmalarında evet—bağlantılar genellikle korunur. [Görüntüler](/slides/tr/python-net/convert-powerpoint-to-png/) ve [video](/slides/tr/python-net/convert-powerpoint-to-video/) dışa aktarmalarında ise tıklanabilirlik, bu formatların (raster çerçeveler/video) köprüleri desteklememesi nedeniyle taşınmaz.