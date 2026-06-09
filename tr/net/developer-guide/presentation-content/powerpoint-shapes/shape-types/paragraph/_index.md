---
title: Sunumlarda .NET ile Paragraf Sınırlarını Alın
linktitle: Paragraf
type: docs
weight: 60
url: /tr/net/paragraph/
keywords:
- paragraf sınırları
- metin bölümü sınırları
- paragraf koordinatı
- bölüm koordinatı
- paragraf boyutu
- metin bölümü boyutu
- metin çerçevesi
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te paragraf ve metin bölümü sınırlarını nasıl alacağınızı öğrenerek PowerPoint sunumlarında metin konumlandırmayı optimize edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta paragrafların ve metin bölümlerinin sınırlarını, boyutlarını ve koordinatlarını nasıl alacağınızı açıklar. `GetRect()` kullanarak bir `TextFrame` içindeki paragrafın dikdörtgenini nasıl alacağınızı, bir tablo hücresi metin çerçevesindeki paragraf ve bölüm koordinatlarını nasıl elde edeceğinizi gösterir ve ölçü birimleri, metin kaydırmanın sınırlar üzerindeki etkisi, piksel dönüşümü ve etkili paragraf biçimlendirme değerleri gibi önemli ayrıntıları vurgular.

## **Bir TextFrame'de Paragraf ve Bölüm Koordinatlarını Alma**
Aspose.Slides for .NET kullanarak geliştiriciler artık TextFrame'in paragraf koleksiyonundaki Paragrafın dikdörtgen koordinatlarını alabilir. Ayrıca bir paragrafın bölüm koleksiyonundaki bölümün koordinatlarını almanızı sağlar. Bu konuda, bir paragrafın dikdörtgen koordinatlarını bölümün konumu ile birlikte nasıl alacağınızı bir örnekle göstereceğiz.

## **Bir Paragrafın Dikdörtgen Koordinatlarını Almak**
Yeni **GetRect()** yöntemi eklendi. Paragraf sınırları dikdörtgenini almanıza olanak tanır.

```c#
// Bir sunum dosyasını temsil eden bir Presentation nesnesi oluşturun
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **Bir Tablo Hücresi TextFrame İçindeki Paragraf ve Bölüm Boyutunu Almak**

Bir tablo hücresi metin çerçevesinde [Portion](https://reference.aspose.com/slides/tr/net/aspose.slides/portion) veya [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraph) boyutunu ve koordinatlarını alabilmek için [IPortion.GetRect](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/methods/getrect) ve [IParagraph.GetRect](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/methods/getrect) yöntemlerini kullanabilirsiniz.

Bu örnek kod belirtilen işlemi gösterir:

```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```

## **SSS**

**Paragraf ve metin bölümleri için döndürülen koordinatlar hangi birimlerde ölçülür?**

Noktalarda, 1 inç = 72 nokta. Bu, slayttaki tüm koordinat ve boyutlar için geçerlidir.

**Kelime kaydırma, bir paragrafın sınırlarını etkiler mi?**

Evet. [wrapping](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat/wraptext/) [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/) içinde etkinleştirildiğinde, metin alan genişliğine sığdırılacak şekilde bölünür ve bu da paragrafın gerçek sınırlarını değiştirir.

**Paragraf koordinatları dışa aktarılan görüntüde piksellere güvenilir şekilde eşlenebilir mi?**

Evet. Noktaları piksellere şu şekilde dönüştürün: pixels = points × (DPI / 72). Sonuç, render/alma için seçilen DPI'ye bağlıdır.

**Stil kalıtımını göz önünde bulundurarak “etkili” paragraf biçimlendirme parametrelerini nasıl alırım?**

[effective paragraph formatting data structure](/slides/tr/net/shape-effective-properties/) kullanın; bu, girinti, boşluk, kaydırma, RTL ve daha fazlası için nihai birleştirilmiş değerleri döndürür.