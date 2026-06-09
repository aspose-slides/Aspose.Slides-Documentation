---
title: .NET'te Sunumlarda Metin Bölümlerini Yönetme
linktitle: Metin Bölümü
type: docs
weight: 70
url: /tr/net/portion/
keywords:
- metin bölümü
- metin parçası
- metin koordinatları
- metin konumu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint sunumlarında metin bölümlerini nasıl yöneteceğinizi öğrenin, performans ve özelleştirmeyi artırın."
---
## **Overview**

Bir metin bölümü, bir paragraftaki belirli bir metin parçasını temsil eder ve bu parçayı çevresindeki içerikten bağımsız olarak çalışmanıza olanak tanır. Aspose.Slides'te, bir metin parçasının konumunu almak, yalnızca bir paragrafın bir kısmına biçimlendirme uygulamak veya metin davranışını daha ayrıntılı bir seviyede kontrol etmek istediğinizde bölümler kullanılabilir.

Bu makale, `GetCoordinates()` yöntemini kullanarak bir bölümün başlangıç koordinatlarını nasıl alacağınızı gösterir. Ayrıca, tek bir metin parçasına köprü ekleme, biçimlendirmenin bölüm, paragraf, metin çerçevesi ve tema kalıtımı üzerinden nasıl çözüldüğünü anlama ve belirtilen bir yazı tipinin bulunamadığı durumları ele alma gibi yaygın bölüm‑ilişkili senaryoları vurgular. Ayrıca, aynı paragrafta ayrı ayrı bölümler için metin doldurma, renk ve saydamlığın farklı şekilde ayarlanabileceği belirtilir.

## **Get Coordinates of a Text Portion**
**GetCoordinates()** yöntemi IPortion ve Portion sınıflarına eklenmiştir ve bölümün başlangıç koordinatlarını almanızı sağlar:

```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```

## **FAQ**

**Bir paragraf içinde yalnızca metnin bir kısmına köprü uygulayabilir miyim?**

Evet, bir bölüme [bir köprü atayın](/slides/tr/net/manage-hyperlinks/); sadece o parça tıklanabilir, tüm paragraf değil.

**Stil kalıtımı nasıl çalışır: bir Portion neyi geçersiz kılar ve neyi Paragraph/TextFrame'den alır?**

Bölüm düzeyindeki özellikler en yüksek önceliğe sahiptir. Bir özellik [Portion](https://reference.aspose.com/slides/tr/net/aspose.slides/portion/) üzerinde ayarlanmamışsa, motor bunu [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraph/) üzerinden alır; orada da ayarlanmamışsa, [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/) veya [theme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/theme/) stilinden alır.

**Bir Portion için belirtilen yazı tipi hedef makine/sunucuda eksikse ne olur?**

[Yazı tipi ikame kuralları](/slides/tr/net/font-selection-sequence/) uygulanır. Metin yeniden akış gösterebilir: ölçümler, bölünme ve genişlik değişebilir, bu da kesin konumlandırma için önemlidir.

**Bir Portion'a özgü metin doldurma saydamlığını veya geçişini paragrafın geri kalanından bağımsız olarak ayarlayabilir miyim?**

Evet, [Portion](https://reference.aspose.com/slides/tr/net/aspose.slides/portion/) seviyesindeki metin rengi, doldurma ve saydamlık komşu parçalardan farklı olabilir.