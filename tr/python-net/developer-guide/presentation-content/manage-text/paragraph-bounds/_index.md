---
title: Python'da Sunumlardan Paragraf Sınırlarını Al
linktitle: Paragraf Sınırları
type: docs
weight: 43
url: /tr/python-net/paragraph-bounds/
keywords:
- paragraf sınırları
- paragraf koordinatı
- paragraf boyutu
- metin çerçevesi
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarında metin konumlandırmayı optimize etmek için paragraf sınırlarını nasıl alacağınızı öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde paragrafların sınırlarını, boyutunu ve koordinatlarını nasıl alacağınızı açıklar. [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) üzerinden bir paragraf dikdörtgeni elde etmek için [Paragraph.get_rect](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/get_rect/) nasıl kullanılacağını, tablo hücresi metin çerçevesi içindeki paragraf koordinatlarının nasıl alınacağını gösterir ve ölçüm birimleri, metin kaydırmanın sınırlar üzerindeki etkisi, piksel dönüşümü ve etkili paragraf biçimlendirme değerleri gibi önemli detayları vurgular.

## **Paragrafın Dikdörtgen Koordinatlarını Al**

Bir paragrafın sınırlayıcı dikdörtgenini almak için [Paragraph.get_rect](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/get_rect/) kullanın.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **Tablo Hücresi TextFrame İçindeki Paragrafın Boyutunu Al**

Bir tablo hücresi metin çerçevesindeki bir [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) boyutunu ve koordinatlarını almak için [Paragraph.get_rect](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/get_rect/) kullanın. Döndürülen dikdörtgen tablo hücresi metin çerçevesine göre görecelidir, bu nedenle slayt seviyesindeki koordinatlara ihtiyacınız olduğunda tablo konumunu ve hücre ofsetini ekleyin.

İşte aşağıdaki örnek, bir tablo hücresi içindeki paragraf sınırlarını alır ve bu sınırları görselleştirmek üzere slayta dikdörtgenler çizer:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Paragraf koordinatları hangi birimlerde ölçülür?**

Puan (point) cinsinden ölçülür; 1 inç 72 puana eşittir. Bu, slayttaki tüm koordinat ve boyutlar için geçerlidir.

**Kelime kaydırma bir paragrafın sınırlarını etkiler mi?**

Evet. [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/wrap_text/) [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) için etkinleştirilmişse, metin alan genişliğine sığacak şekilde bölünür ve bu da paragrafın gerçek sınırlarını değiştirir.

**Paragraf koordinatları dışa aktarılan görüntüde piksellere güvenilir bir şekilde eşlenebilir mi?**

Evet. Puanları pikselye bu formülle dönüştürün: piksel = puan x (DPI / 72). Sonuç, oluşturma veya dışa aktarma için seçilen DPI'ye bağlıdır.

**"Etkili" paragraf biçimlendirme parametrelerini stil kalıtımını göz önünde bulundurarak nasıl alırım?**

Bu amaçla [effective paragraph formatting data structure](/slides/tr/python-net/shape-effective-properties/) kullanın; girintiler, boşluklar, kaydırma, RTL ve diğerleri için son birleştirilmiş değerleri döndürür.