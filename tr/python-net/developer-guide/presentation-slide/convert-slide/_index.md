---
title: PowerPoint Slaytlarını Python'da Görüntülere Dönüştür
linktitle: Slayttan Görüntüye
type: docs
weight: 41
url: /tr/python-net/convert-slide/
keywords:
- slaytı dönüştür
- slaytı görüntüye dönüştür
- slaytı görüntü olarak dışa aktar
- slaytı görüntü olarak kaydet
- slayttan görüntüye
- slayttan PNG'ye
- slayttan JPEG'e
- slayttan bitmap'e
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument slaytlarını çeşitli formatlara nasıl dönüştüreceğinizi öğrenin. PPTX ve ODP slaytlarını BMP, PNG, JPEG, TIFF ve daha fazlasına yüksek kaliteyle kolayca dışa aktarın."
---
## **Giriş**

Aspose.Slides for Python via .NET, PowerPoint ve OpenDocument sunum slaytlarını BMP, PNG, JPG (JPEG), GIF ve diğer çeşitli görüntü formatlarına kolayca dönüştürmenizi sağlar.

Bir slaytı görüntüye dönüştürmek için aşağıdaki adımları izleyin:

1. İstenen dönüşüm ayarlarını tanımlayın ve dışa aktarmak istediğiniz slaytları aşağıdakileri kullanarak seçin:
    - [TiffOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/) sınıfı, veya
    - [RenderingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/renderingoptions/) sınıfı.
2. `get_image` yöntemini [Slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/) sınıfından çağırarak slayt görüntüsünü oluşturun.

Aspose.Slides for Python via .NET içinde, [IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) piksel verileriyle tanımlanan görüntülerle çalışmanıza olanak sağlayan bir sınıftır. Bu sınıfın bir örneğini kullanarak görüntüleri geniş bir format yelpazesinde (BMP, JPG, PNG vb.) kaydedebilirsiniz.

## **Slaytları Bitmap'e Dönüştür ve PNG Olarak Kaydet**

Bir slaytı bitmap nesnesine dönüştürüp uygulamanızda doğrudan kullanabilirsiniz. Alternatif olarak, slaytı bitmap'e dönüştürüp görüntüyü JPEG veya istediğiniz başka bir formatta kaydedebilirsiniz.

Bu Python kodu, bir sunumun ilk slaytını bitmap nesnesine dönüştürüp ardından PNG formatında kaydetmeyi gösterir:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # Sunumdaki ilk slaytı bitmap'e dönüştür.
    with presentation.slides[0].get_image() as image:
        # Görüntüyü PNG formatında kaydet.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Özel Boyutlarda Slaytları Görüntülere Dönüştür**

Belirli bir boyutta bir görüntü elde etmeniz gerekebilir. [get_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) yönteminin bir aşırı yüklemesini kullanarak bir slaytı belirli boyutlarla (genişlik ve yükseklik) görüntüye dönüştürebilirsiniz. 

Bu örnek kod bunun nasıl yapılacağını gösterir:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # Sunumdaki ilk slaytı belirtilen boyutta bitmap'e dönüştür.
    with presentation.slides[0].get_image(image_size) as image:
        # Görüntüyü JPEG formatında kaydet.
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Notlar ve Yorumlar İçeren Slaytları Görüntülere Dönüştür**

Bazı slaytlar not ve yorumlar içerebilir.

Aspose.Slides, sunum slaytlarının görüntülere dönüştürülmesini kontrol etmenizi sağlayan iki sınıf—[TiffOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/) ve [RenderingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/renderingoptions/)—sunar. Her iki sınıf da `slides_layout_options` özelliğini içerir; bu özellik, bir slaytı görüntüye dönüştürürken not ve yorumların nasıl render edileceğini yapılandırmanıza olanak tanır.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/notescommentslayoutingoptions/) sınıfı ile sonuç görüntüde not ve yorumların tercih ettiğiniz konumunu belirleyebilirsiniz.

Bu Python kodu, not ve yorum içeren bir slaytı nasıl dönüştüreceğinizi gösterir:

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

    # Render seçeneklerini oluştur.
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # Sunumdaki ilk slaytı bir görüntüye dönüştür.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # Görüntüyü GIF formatında kaydet.
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 
Herhangi bir slayt‑görüntü dönüşüm sürecinde, [notes_position](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) özelliği `BOTTOM_FULL` olarak ayarlanamaz (notların konumunu belirlemek için) çünkü bir notun metni çok büyük olabilir ve belirtilen görüntü boyutuna sığmayabilir.
{{% /alert %}} 

## **TIFF Seçeneklerini Kullanarak Slaytları Görüntülere Dönüştür**

[TiffOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/) sınıfı, boyut, çözünürlük, renk paleti ve daha fazlası gibi parametreleri belirlemenize olanak tanıyarak ortaya çıkan TIFF görüntüsü üzerinde daha fazla kontrol sağlar.

Bu Python kodu, TIFF seçenekleri kullanılarak 300 DPI çözünürlükte ve 2160 × 2800 boyutunda siyah‑beyaz bir görüntü üretme sürecini gösterir:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# Bir sunum dosyasını yükle.
with slides.Presentation("sample.pptx") as presentation:
    # Sunumdan ilk slaytı al.
    slide = presentation.slides[0]

    # Çıktı TIFF görüntüsünün ayarlarını yapılandır.
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # Görüntü boyutunu ayarla.
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # Piksel formatını ayarla (siyah beyaz).
    options.dpi_x = 300                                                        # Yatay çözünürlüğü ayarla.
    options.dpi_y = 300                                                        # Dikey çözünürlüğü ayarla.

    # Slaytı belirtilen seçeneklerle bir görüntüye dönüştür.
    with slide.get_image(options) as image:
        # Görüntüyü TIFF formatında kaydet.
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Tüm Slaytları Görüntülere Dönüştür**

Aspose.Slides, bir sunumdaki tüm slaytları görüntülere dönüştürmenizi sağlar; böylece tüm sunumu bir dizi görüntüye çevirir.

Bu örnek kod, bir sunumdaki tüm slaytların Python ile görüntülere nasıl dönüştürüleceğini gösterir:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # Sunumu slayt slayt görüntülere render et.
    for i, slide in enumerate(presentation.slides):
        # Gizli slaytları kontrol et (gizli slaytları render etme).
        if slide.hidden:
            continue

        # Slaytı bir görüntüye dönüştür.
        with slide.get_image(scale_x, scale_y) as image:
            # Görüntüyü JPEG formatında kaydet.
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```

## **SSS**

**Aspose.Slides, animasyonlu slaytların render edilmesini destekliyor mu?**

Hayır, `get_image` yöntemi yalnızca slaytın statik bir görüntüsünü kaydeder, animasyon içermez.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet, gizli slaytlar normal slaytlar gibi işlenebilir. İşleme döngüsüne dahil olduklarından emin olun.

**Görüntüler gölgeler ve efektlerle kaydedilebilir mi?**

Evet, Aspose.Slides, slaytları görüntü olarak kaydederken gölgeler, şeffaflık ve diğer grafik efektlerinin render edilmesini destekler.