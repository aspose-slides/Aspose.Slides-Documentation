---
title: PowerPoint Slaytlarını Python’da Görsellere Dönüştür
linktitle: Slayttan Görsele
type: docs
weight: 41
url: /tr/python-net/convert-slide/
keywords:
- slaytı dönüştür
- slaytı görsele dönüştür
- slaytı görsel olarak dışa aktar
- slaytı görsel olarak kaydet
- slayttan görsele
- slayttan PNG
- slayttan JPEG
- slayttan bitmap
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument slaytlarını çeşitli formatlara nasıl dönüştüreceğinizi öğrenin. PPTX ve ODP slaytlarını BMP, PNG, JPEG, TIFF ve daha fazlasına yüksek kaliteli sonuçlarla kolayca dışa aktarın."
---
## **Giriş**

Aspose.Slides for Python via .NET, PowerPoint ve OpenDocument sunum slaytlarını BMP, PNG, JPG (JPEG), GIF ve diğer çeşitli görüntü formatlarına kolayca dönüştürmenizi sağlar.

Bir slaytı görsele dönüştürmek için şu adımları izleyin:

1. İstediğiniz dönüştürme ayarlarını tanımlayın ve dışa aktarmak istediğiniz slaytları seçin:
    - [TiffOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/) sınıfını kullanarak, veya
    - [RenderingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/renderingoptions/) sınıfını kullanarak.
2. [Slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/) sınıfından `get_image` metodunu çağırarak slayt görselini oluşturun.

Aspose.Slides for Python via .NET içinde, [IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) piksel verileriyle tanımlanan görsellerle çalışmanıza olanak tanıyan bir sınıftır. Bu sınıfın bir örneğini, BMP, JPG, PNG vb. geniş bir format yelpazesinde görselleri kaydetmek için kullanabilirsiniz.

## **Slaytları Bitmap’e Dönüştür ve Görselleri PNG Olarak Kaydet**

Bir slaytı bitmap nesnesine dönüştürüp doğrudan uygulamanızda kullanabilirsiniz. Alternatif olarak, bir slaytı bitmap’e dönüştürüp ardından JPEG veya tercih ettiğiniz başka bir formatta kaydedebilirsiniz.

Aşağıdaki Python kodu, bir sunumun ilk slaytını bitmap nesnesine dönüştürüp PNG formatında kaydetmeyi gösterir:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # Sunumdaki ilk slaytı bitmap’e dönüştür.
    with presentation.slides[0].get_image() as image:
        # Görseli PNG formatında kaydet.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Özel Boyutlarla Slaytları Görsellere Dönüştür**

Belirli bir boyutta görsele ihtiyacınız olabilir. [get_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) metodunun bir aşırı yüklemesini kullanarak slaytı belirli genişlik ve yükseklikte bir görsele dönüştürebilirsiniz.

Bu örnek kod bu işlemi nasıl yapacağınızı gösterir:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # Sunumdaki ilk slaytı belirtilen boyutta bitmap’e dönüştür.
    with presentation.slides[0].get_image(image_size) as image:
        # Görseli JPEG formatında kaydet.
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Not ve Yorum İçeren Slaytları Görsellere Dönüştür**

Bazı slaytlar not ve yorum içerebilir.

Aspose.Slides, sunum slaytlarını görsellere dönüştürmeyi kontrol etmenizi sağlayan iki sınıf sunar—[TiffOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/) ve [RenderingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/renderingoptions/). Her iki sınıfta da slaytı görsele dönüştürürken not ve yorumların nasıl işleneceğini yapılandırmanızı sağlayan `slides_layout_options` özelliği bulunur.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/notescommentslayoutingoptions/) sınıfı ile ortaya çıkan görselde not ve yorumların konumunu istediğiniz gibi belirtebilirsiniz.

Aşağıdaki Python kodu, not ve yorum içeren bir slaytı nasıl dönüştüreceğinizi gösterir:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # Notların konumunu ayarla.
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # Yorumların konumunu ayarla.
    notes_comments_options.comments_area_width = 500                                       # Yorum alanının genişliğini ayarla.
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # Yorum alanının rengini ayarla.

    # Renderleme seçeneklerini oluştur.
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # Sunumdaki ilk slaytı bir görsele dönüştür.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # Görseli GIF formatında kaydet.
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 

Herhangi bir slayt‑görsel dönüşüm sürecinde, [notes_position](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) özelliği `BOTTOM_FULL` (notların konumunu belirlemek için) olarak ayarlanamaz; çünkü bir notun metni çok büyük olabilir ve belirtilen görsel boyutuna sığmayabilir.

{{% /alert %}} 

## **TIFF Seçenekleriyle Slaytları Görsellere Dönüştür**

[TiffOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/) sınıfı, boyut, çözünürlük, renk paleti ve daha fazlası gibi parametreleri belirlemenize izin vererek oluşturulan TIFF görüntüsü üzerinde daha fazla kontrol sağlar.

Aşağıdaki Python kodu, 300 DPI çözünürlükte ve 2160 × 2800 boyutunda siyah‑beyaz bir görüntü üretmek için TIFF seçeneklerinin nasıl kullanılacağını gösterir:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# Sunum dosyasını yükle.
with slides.Presentation("sample.pptx") as presentation:
    # Sunumdan ilk slaytı al.
    slide = presentation.slides[0]

    # Çıktı TIFF görüntüsünün ayarlarını yapılandır.
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # Görüntü boyutunu ayarla.
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # Piksel formatını ayarla (siyah ve beyaz).
    options.dpi_x = 300                                                        # Yatay çözünürlüğü ayarla.
    options.dpi_y = 300                                                        # Dikey çözünürlüğü ayarla.

    # Slaytı belirtilen seçeneklerle görsele dönüştür.
    with slide.get_image(options) as image:
        # Görüntüyü TIFF formatında kaydet.
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Tüm Slaytları Görsellere Dönüştür**

Aspose.Slides, bir sunumdaki tüm slaytları görsellere dönüştürmenize olanak tanır; böylece tüm sunumu bir dizi görsele çevirebilirsiniz.

Aşağıdaki örnek kod, bir sunumdaki tüm slaytların Python’da nasıl görsellere dönüştürüleceğini gösterir:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # Sunumu slayt slayt görüntülere dönüştür.
    for i, slide in enumerate(presentation.slides):
        # Gizli slaytları kontrol et (gizli slaytları renderlama).
        if slide.hidden:
            continue

        # Slaytı bir görsele dönüştür.
        with slide.get_image(scale_x, scale_y) as image:
            # Görüntüyü JPEG formatında kaydet.
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```

## **Renkli Emoji Renderlama**

{{% alert title="Note" color="warning" %}} 
Sunum slaytlarını görsellere dönüştürürken renkli emojilerin doğru şekilde renderlanabilmesi için, sunumda kullanılan emoji yazı tiplerinin dönüştürmeyi yapan sistemde yüklü ve erişilebilir olması gerekir. Örneğin, sunum **Segoe UI Emoji** yazı tipini kullanıyorsa ve bu yazı tipi eksikse, emojiler çıktı görsellerinde tek renkli görünebilir.
{{% /alert %}}

## **SSS**

**Aspose.Slides animasyonlu slaytların renderlanmasını destekliyor mu?**  

Hayır, `get_image` metodu sadece slaydın statik bir görüntüsünü kaydeder, animasyonları içermez.

**Gizli slaytlar görsel olarak dışa aktarılabilir mi?**  

Evet, gizli slaytlar normal slaytlar gibi işlenebilir. Sadece işleme döngüsünde yer aldıklarından emin olun.

**Görseller gölgeler ve efektlerle kaydedilebilir mi?**  

Evet, Aspose.Slides slaytları görsel olarak kaydederken gölgeler, saydamlık ve diğer grafik efektlerinin renderlanmasını destekler.