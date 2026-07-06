---
title: .NET'te Sunumlardan Metin Bölümü Sınırlarını Al
linktitle: Bölüm Sınırları
type: docs
weight: 47
url: /tr/net/portion-bounds/
keywords:
- metin bölüm sınırları
- metin bölümü
- metin parçası
- metin koordinatları
- metin konumu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint sunumlarında metin bölümü sınırlarını nasıl alacağınızı öğrenin."
---
## **Genel Bakış**

Bir metin bölümü, bir paragraftaki belirli bir metin fragmentini temsil eder ve bu fragmenti çevreleyen içerikten bağımsız olarak çalışmanıza olanak tanır. Aspose.Slides içinde, bir metin fragmentinin sınırlarını almak, bir paragrafın yalnızca bir kısmına biçimlendirme uygulamak veya metin davranışını daha ayrıntılı bir seviyede kontrol etmek gerektiğinde bölümler kullanılabilir.

Bu makale, bir bölümün sınırlayıcı dikdörtgenini [IPortion.GetRect](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/getrect/) kullanarak nasıl alacağınızı gösterir. Ayrıca, bir bölümün başlangıç koordinatlarını [IPortion.GetCoordinates](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/getcoordinates/) kullanarak nasıl alacağınızı gösterir. Ek olarak, tek bir metin fragmentine bir hiperlink eklemek, biçimlendirmenin bölüm, paragraf, metin çerçevesi ve tema kalıtımı üzerinden nasıl çözüldüğünü anlamak ve belirtilen bir yazı tipinin mevcut olmaması durumlarını ele almak gibi yaygın bölümle ilgili senaryoları vurgular.

## **Metin Bölümünün Sınırlarını Al**

[IPortion.GetRect](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/getrect/) kullanarak bir metin bölümünün sınırlayıcı dikdörtgenini alın:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **Metin Bölümünün Koordinatlarını Al**

[IPortion.GetCoordinates](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/getcoordinates/) kullanarak bir metin bölümünün başlangıç koordinatlarını alın:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **SSS**

**Bir paragraftaki metnin yalnızca bir kısmına hiperlink uygulayabilir miyim?**

Evet, bir bireysel bölüme [assign a hyperlink](/slides/tr/net/manage-hyperlinks/) atayabilirsiniz; yalnızca o fragment tıklanabilir olur, tüm paragraf değil.

**Stil kalıtımı nasıl çalışır: bölüm neyi geçersiz kılar, paragraf veya metin çerçevesinden ne alınır?**

Bölüm düzeyindeki özellikler en yüksek önceliğe sahiptir. Bir özellik [IPortion](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/) üzerinde ayarlanmamışsa, Aspose.Slides bunu [IParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/) üzerinden alır. Orada da ayarlanmamışsa, Aspose.Slides [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) veya [theme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/theme/) stilini kullanır.

**Bir bölüm için belirtilen yazı tipi hedef makine veya sunucuda eksik olursa ne olur?**

[Font substitution rules](/slides/tr/net/font-selection-sequence/) uygulanır. Metin yeniden akabilir: ölçümler, heceleme ve genişlik değişebilir, bu da hassas konumlandırma için önem taşır.

**Paragrafın geri kalanından bağımsız olarak bölüm‑özel metin doldurma saydamlığı veya bir degrade ayarlayabilir miyim?**

Evet, [IPortion](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/) düzeyinde metin rengi, doldurma ve saydamlık komşu fragmentlerden farklı olabilir.