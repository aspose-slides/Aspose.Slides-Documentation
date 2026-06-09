---
title: Python'da Sunumlardan Paragraf Sınırlarını Alın
linktitle: Paragraf
type: docs
weight: 60
url: /tr/python-net/paragraph/
keywords:
- paragraf sınırları
- metin bölümü sınırları
- paragraf koordinatı
- bölüm koordinatı
- paragraf boyutu
- metin bölümü boyutu
- metin çerçevesi
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET içinde paragraf ve metin bölümü sınırlarını nasıl alacağınızı öğrenerek, PowerPoint ve OpenDocument sunumlarında metin konumlandırmasını optimize edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde paragrafların ve metin bölümlerinin sınırlarını, boyutlarını ve koordinatlarını nasıl alacağını açıklar. `get_rect()` kullanarak bir `TextFrame` içindeki paragrafın dikdörtgenini nasıl alınacağını, tablo hücresi metin çerçevesi içinde paragraf ve bölüm koordinatlarını nasıl alacağını gösterir ve ölçü birimleri, metin kaydırmanın sınırlar üzerindeki etkisi, piksel dönüşümü ve etkili paragraf biçimlendirme değerleri gibi önemli ayrıntıları vurgular.

## **TextFrame içinde Paragraf ve Bölüm Koordinatlarını Almak**

Aspose.Slides for Python via .NET kullanarak, geliştiriciler artık TextFrame’in paragraf koleksiyonundaki Paragraf için dikdörtgen koordinatlarını alabilir. Ayrıca bir paragraftaki bölüm koleksiyonundaki bölümün koordinatlarını almanıza da izin verir. Bu konuda, bir örnek yardımıyla paragrafın dikdörtgen koordinatlarını ve paragraf içindeki bölümün konumunu nasıl alacağınızı göstereceğiz.

## **Paragrafın Dikdörtgen Koordinatlarını Alın**

Yeni **GetRect()** yöntemi eklendi. Paragraf sınırları dikdörtgenini almanıza olanak tanır.

```py
import aspose.slides as slides

# Bir sunum dosyasını temsil eden Presentation nesnesi örneği oluşturur
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Tablo hücresi metin çerçevesi içinde paragraf ve bölümün boyutunu al** ##

Bir tablo hücresi metin çerçevesinde [Portion](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/) veya [Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) boyutunu ve koordinatlarını almak için [IPortion.GetRect](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iportion/) ve [IParagraph.GetRect](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iparagraph/) yöntemlerini kullanabilirsiniz.

Bu örnek kod, açıklanan işlemi gösterir:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **SSS**

**Paragraf ve metin bölümlerinin koordinatları hangi birimlerde döndürülür?**

Nokta (point) biriminde, 1 inç = 72 point olarak ölçülür. Bu, slayttaki tüm koordinat ve boyutlara uygulanır.

**Kelime kaydırma bir paragrafın sınırlarını etkiler mi?**

Evet. [wrapping](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/wrap_text/) [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) içinde etkinleştirildiğinde, metin alan genişliğine sığacak şekilde bölünür ve bu da paragrafın gerçek sınırlarını değiştirir.

**Paragraf koordinatları dışa aktarılan görüntüde piksellere güvenilir bir şekilde eşlenebilir mi?**

Evet. Noktaları piksellere şu şekilde dönüştürün: pixels = points × (DPI / 72). Sonuç, render/ dışa aktarım için seçilen DPI değerine bağlıdır.

**Stil kalıtımını göz önünde bulundurarak "etkili" paragraf biçimlendirme parametrelerini nasıl alabilirim?**

[effective paragraph formatting data structure](/slides/tr/python-net/shape-effective-properties/) kullanın; girintiler, aralıklar, kaydırma, RTL ve daha fazlası için son birleşik değerleri döndürür.