---
title: PPT ve PPTX'yi Python'da JPG'ye Dönüştür
linktitle: PowerPoint'ten JPG'ye
type: docs
weight: 60
url: /tr/python-java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PowerPoint'ten JPG
- PPT'den JPG
- PPTX'ten JPG
- slaytı JPG olarak kaydet
- PPT'yi JPG'ye dışa aktar
- PPTX'i JPG'ye dışa aktar
- Python
- Java
- Aspose.Slides
description: "Python üzerinden Java ile PowerPoint (PPT, PPTX) slaytlarını JPG görüntülerine dönüştürün. Özel görüntü boyutları ayarlayın ve notları ile yorumları Aspose.Slides ile oluşturun."
---
## **Giriş**

Aspose.Slides for Python via Java, PowerPoint ve OpenDocument sunumlarını (PPT, PPTX ve ODP) JPEG görüntülerine dönüştürmenizi sağlar. Her bir slaytı veya seçili bir slaytı dışa aktararak küçük resimler oluşturabilir, bir sunum görüntüleyici oluşturabilir veya slayt önizlemelerini bir web sitesine veya uygulamaya yerleştirebilirsiniz.

## **PowerPoint PPT/PPTX'yi JPG'ye Dönüştür**

1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) ile yükleyin.
2. [getSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSlides) kullanarak slaytları alın.
3. Her slaytı oluşturmak için yatay ve dikey ölçek çarpanlarıyla [Slide.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) çağırın.
4. [ImageFormat.Jpeg](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imageformat/#Jpeg) kullanarak her oluşturulan görüntüyü JPEG olarak kaydedin, ardından görüntü kaynaklarını serbest bırakın.

{{% alert color="info" title="Note" %}}
JPG'ye dışa aktarmak, her slayt için ayrı bir görüntü oluşturur. Sunumu doğrudan bir görüntü biçimine kaydetmek yerine oluşturulan görüntüyü kaydedin.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Özelleştirilmiş Boyutlarla PowerPoint PPT/PPTX'yi JPG'ye Dönüştür**

İstenen piksel boyutları ve orijinal slayt boyutundan yatay ve dikey ölçek çarpanlarını hesaplayın, ardından bunları [Slide.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage)'e iletin. Aşağıdaki örnek, her slayt için 1200 × 800 boyutunda bir görüntü hedefler.

Farklı ölçek çarpanları kullanmak slaytı gerletebilir. En‑boy oranını korumak için her iki eksen için aynı ölçek çarpanını kullanın; ortaya çıkan genişlik ve yükseklik orijinal slayt oranlarını takip edecektir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Slaytları Görüntü Olarak Kaydederken Yorumları Oluştur**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/) kullanarak notları ve yorumları yapılandırın ve düzeni [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) aracılığıyla uygulayın. Bu örnek notları alt kısma yerleştirir, sığmayan notları kırpar ve yorumları sağ tarafta 200 piksel genişliğinde bir alanda gösterir. Her oluşturulan slaytı JPG görüntüsü olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **SSS**

**Birden fazla slaytı veya sunumu JPG'ye dönüştürebilir miyim?**  
Evet. Örnekler tüm slaytlar üzerinde döngü yapar ve her slayt için bir JPG kaydeder. Birden fazla sunumu işlemek için, dönüşümü her giriş dosyası için tekrarlayın ve görüntülerin üzerine yazılmasını önlemek adına ayrı çıktı klasörleri veya benzersiz dosya adları kullanın.

**Grafikler, SmartArt, tablolar ve şekiller görüntülere dahil mi?**  
Bu nesneler slaytın bir parçası olarak işlenir. Yazı tipi ikamesinden kaynaklanan farkları azaltmak için, sunumda kullanılan yazı tiplerini dönüşüm ortamında mevcut hale getirin.

**Büyük sunumları dışa aktarırken bellek kullanımını nasıl azaltabilirim?**  
Görüntüleri tek tek işleyin, her birini kaydettikten sonra serbest bırakın ve gereksiz derecede büyük çıktı boyutlarından kaçının. Bellek gereksinimleri slayt içeriğine ve görüntü boyutuna bağlıdır.

## **İlgili Bağlantılar**

- [PowerPoint'i PNG'ye Dönüştür](/slides/tr/python-java/convert-powerpoint-to-png/).
- [Bir slaytı SVG görüntüsü olarak oluştur](/slides/tr/python-java/render-a-slide-as-an-svg-image/).