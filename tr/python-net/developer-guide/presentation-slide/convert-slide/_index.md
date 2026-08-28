---
title: Sunum Slaytlarını Python'da Görüntülere Dönüştür
linktitle: Slayttan Görüntüye
type: docs
weight: 41
url: /tr/python-net/convert-slide/
keywords:
- slaytı dönüştür
- slaytı dışa aktar
- slayttan görüntüye
- slaytı görüntü olarak kaydet
- slayttan EMF
- slayttan PNG
- slayttan JPEG
- slayttan bitmap
- slayttan TIFF
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "PPT, PPTX ve ODP sunumlarından slaytları PNG, JPEG, GIF, TIFF, EMF ve diğer görüntü formatlarına Python'da Aspose.Slides ile dönüştürün."
---
## **Giriş**

Aspose.Slides for Python via .NET, PowerPoint ve OpenDocument sunumlarındaki tek tek slaytları PNG, JPEG, GIF, TIFF ve diğer görüntü formatlarında oluşturabilir.

Bir slaytı görüntüye dönüştürmek için şu adımları izleyin:

1. Sunumu [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfı ile yükleyin.
2. Oluşturmak istediğiniz slaytı seçin.
3. Gerekirse, renderlemeyi [RenderingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/renderingoptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/) sınıfı ile yapılandırın.
4. [Slide.get_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/) metodunu çağırın. Bu metod bir [IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) nesnesi döndürür.
5. [IImage.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/save/) metodunu çağırın ve çıktısının formatını bir [ImageFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imageformat/) değeriyle belirtin.

## **Bir Slaytı PNG Görüntüsü Olarak Dönüştür**

En basit dönüşüm, varsayılan renderleme ayarlarını kullanır. Ortaya çıkan [IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) nesnesi bellek içinde işlenebilir veya bir dosyaya kaydedilebilir.

Aşağıdaki Python örneği ilk slaytı render eder ve bir PNG görüntüsü olarak kaydeder:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Özel Boyutlarla Slaytları Görüntülere Dönüştür**

[Slide.get_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) aşırı yüklemesini kullanın; bu aşırı yükleme bir [Size](https://reference.aspose.com/slides/tr/python-net/aspose.pydrawing/size/) değerini kabul eder ve slaytı tam piksel boyutlarıyla render eder.

Aşağıdaki örnek 1820 × 1040 JPEG görüntüsü oluşturur:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Notlar ve Yorumlar İçeren Slaytları Görüntülere Dönüştür**

Varsayılan olarak, slayt görüntüleri notları veya yorumları içermez. Notların ve yorumların nerede görüneceğini kontrol etmek için bir [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/notescommentslayoutingoptions/) nesnesini [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) özelliğine atayın.

Aşağıdaki örnek, kırpılmış notları slaytın altına ve yorumları sağ tarafına yerleştirir:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Warning" color="warning" %}}
Slayt‑görüntü dönüşümü için, [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) özelliğini [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/notespositions/) olarak ayarlamayın. Notlar, sabit görüntü boyutunun alabileceğinden daha fazla metin içerebilir. Bunun yerine [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/notespositions/) kullanın.
{{% /alert %}}

## **TIFF Seçeneklerini Kullanarak Slaytları Görüntülere Dönüştür**

[TiffOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/) sınıfı, oluşturulan TIFF görüntüsünün boyutunu, çözünürlüğünü ve diğer özelliklerini kontrol etmenizi sağlar.

Aşağıdaki örnek ilk slaytı 2160 × 2880 TIFF görüntüsü olarak, 300 DPI'da render eder:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Tüm Slaytları Görüntülere Dönüştür**

Sunumun tamamını bir dizi görüntüye dönüştürmek için slayt koleksiyonunda döngü oluşturun. Gizli slaytlar, açıkça atlamadığınız sürece dahil edilir.

Aşağıdaki örnek her slaytı yatay ve dikey ölçek faktörleri 2 olan bir JPEG görüntüsü olarak render eder:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **Gelişmiş Metafile Çıktısı Oluştur**

Gelişmiş Metafile (EMF), vektör tabanlı grafiklerin Microsoft Office veya Windows metafilleri destekleyen diğer Windows uygulamalarıyla değiş tokuş edilmesi gerektiğinde faydalıdır. Piksel tabanlı bir görüntünün aksine, EMF vektör çizim işlemlerini korur ve ölçeklendirildiğinde aynı netlik kaybını yaşamaz. Ancak EMF, öncelikle Windows metafili desteği olan uygulamalar için bir uyumluluk biçimidir, evrensel bir değiş‑tokuş biçimi değildir. Ayrıca, bitmap görüntüler ve bazı efektler gibi karmaşık slayt içerikleri, vektör metafili konteyneri içinde rasterleştirilmiş öğeler olarak saklanabilir.

### **Bir Slaytı EMF Olarak Dışa Aktar**

[Slide.write_as_emf](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/write_as_emf/) metodu bir [Slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/) nesnesini EMF formatında hedef akışa yazar. Aşağıdaki örnek bir sunumu yükler, ilk slaytı seçer ve onu bir EMF dosya akışına yazar:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

Çağıran, [Slide.write_as_emf](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/write_as_emf/) metoduna geçirilen akışı sahiplenir ve kapatmalıdır. Aspose.Slides, akışın mevcut konumunda yazar ve akışı açık bırakır.

### **Bir SVG Görüntüsünü EMF'e Dönüştür ve Sunuma Ekle**

SVG içeriğini EMF'e dönüştürmek için [SvgImage.write_as_emf](https://reference.aspose.com/slides/tr/python-net/aspose.slides/svgimage/write_as_emf/) kullanın. Elde edilen baytlar, [ImageCollection.add_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imagecollection/add_image/) aracılığıyla sunuma eklenebilir ve bir slayta [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_picture_frame/) ile yerleştirilebilir.

Aşağıdaki örnek, SVG işaretlemesinden bir [SvgImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/svgimage/) oluşturur, bunu bellek içi bir EMF'e dönüştürür, metafili ilk slayta ekler ve sunumu kaydeder:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/tr/python-net/aspose.slides/svgimage/write_as_emf/) hedef akışın sahipliğini almaz. Yazma işleminden sonra, akış konumu oluşturulan verinin sonundadır. Yukarıda gösterildiği gibi, mevcut akış konumundan bağımsız olarak tam tamponu elde etmek için `getvalue` çağırın. Veriler okunana kadar akışı açık tutun ve ardından kapatın.

EMF oluşturma, Aspose.Slides for Python via .NET tarafından desteklenen işletim sistemlerinde mevcuttur, ancak yazı tipleri veya yerel grafik bağımlılıkları bulunmadığında platformlar arasında renderleme farklılıkları olabilir. Kaynak içeriğin kullandığı yazı tiplerini kurun veya uygun ikameler yapılandırın, Aspose.Slides için [platform gereksinimlerini](/slides/tr/python-net/system-requirements/) izleyin ve sonucu hedef EMF tüketen uygulamada doğrulayın. Linux ve macOS uygulamaları genellikle Windows metafillerinin görüntülenmesi ve düzenlenmesi konusunda sınırlı veya tutarsız destek sunar.

## **Renkli Emoji Renderleme**

{{% alert title="Note" color="info" %}}
Sunum slaytlarını görüntülere dönüştürürken renkli emojileri doğru şekilde renderlemek için, sunumda kullanılan emoji yazı tiplerinin dönüşümün yapıldığı sistemde kurulu ve erişilebilir olması gerekir. Örneğin, sunum **Segoe UI Emoji** yazı tipini kullanıyorsa ve bu yazı tipi eksikse, emojiler çıktı görüntülerinde tek renkli görünebilir.
{{% /alert %}}

## **SSS**

**Aspose.Slides animasyonlu slaytları renderlemeyi destekliyor mu?**

Hayır. [Slide.get_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/) metodu slaytin statik bir görüntüsünü render eder ve animasyonları dışa aktarmaz.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet. Gizli slaytlar normal slaytlar gibi render edilebilir. Yukarıdaki örnekte gösterildiği gibi işleme döngüsüne dahil edin.

**Gölge ve diğer efektler slayt görüntülerinde korunur mu?**

Evet. Aspose.Slides gölgeleri, şeffaflığı ve desteklenen diğer grafik efektleri slayt görüntülerinde render eder.