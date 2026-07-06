---
title: .NET'te Sunumlardan Paragraf Sınırlarını Al
linktitle: Paragraf Sınırları
type: docs
weight: 43
url: /tr/net/paragraph-bounds/
keywords:
- paragraf sınırları
- paragraf koordinatı
- paragraf boyutu
- metin çerçevesi
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te paragraf sınırlarını alarak PowerPoint sunumlarında metin konumlandırmasını optimize etmeyi öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde paragrafların sınırlarını, boyutunu ve koordinatlarını nasıl alacağınızı açıklar. [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) üzerinden bir paragraf dikdörtgenini [IParagraph.GetRect](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/getrect/) kullanarak nasıl alacağınızı, tablo hücresi metin çerçevesi içinde paragraf koordinatlarını nasıl elde edeceğinizi gösterir ve ölçüm birimleri, metin kaydırmanın sınırlar üzerindeki etkisi, piksel dönüşümü ve etkili paragraf biçimlendirme değerleri gibi önemli ayrıntıları vurgular.

## **Paragrafın Dikdörtgen Koordinatlarını Al**

[IParagraph.GetRect](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/getrect/) kullanarak bir paragrafın sınırlayıcı dikdörtgenini alın.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **Bir Tablo Hücresi Metin Çerçevesi İçindeki Paragrafın Boyutunu Al**

Bir tablo hücresi metin çerçevesindeki bir [IParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/) öğesinin boyutunu ve koordinatlarını almak için [IParagraph.GetRect](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/getrect/) kullanın. Döndürülen dikdörtgen tablo hücresi metin çerçevesine göre görecelidir; slayt düzeyinde koordinatlara ihtiyaç duyduğunuzda tablo konumunu ve hücre ofsetini ekleyin.

Aşağıdaki örnek, bir tablo hücresi içinde paragraf sınırlarını alır ve bu sınırları görselleştirmek için slayta dikdörtgenler çizer:

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **SSS**

**Paragraf koordinatları hangi birimlerde ölçülür?**

Paragraf koordinatları puan (point) biriminde ölçülür; 1 inç 72 puana eşittir. Bu, slayttaki tüm koordinat ve boyutlar için geçerlidir.

**Kelime kaydırma bir paragrafın sınırlarını etkiler mi?**

Evet. [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) için [TextFrameFormat.WrapText](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat/wraptext/) etkinleştirildiğinde, metin alan genişliğine sığacak şekilde bölünür ve bu da paragrafın gerçek sınırlarını değiştirir.

**Paragraf koordinatları dışa aktarılan görüntüde pikselere güvenilir bir şekilde eşlenebilir mi?**

Evet. Puanları pikselere bu formülle dönüştürün: pixels = points × (DPI / 72). Sonuç, oluşturma ya da dışa aktarma için seçilen DPI'ye bağlıdır.

**Stil kalıtımını dikkate alarak "etkili" paragraf biçimlendirme parametrelerini nasıl alırım?**

[etkili paragraf biçimlendirme veri yapısı](/slides/tr/net/shape-effective-properties/) kullanın; girintiler, boşluklar, kaydırma, RTL ve daha fazlası için nihai birleştirilmiş değerleri döndürür.