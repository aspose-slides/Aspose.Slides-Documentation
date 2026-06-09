---
title: JavaScript Kullanarak Sunumlarda Metin Bölümlerini Yönetme
linktitle: Metin Bölümü
type: docs
weight: 70
url: /tr/nodejs-java/portion/
keywords:
- metin bölümü
- metin parçası
- metin koordinatları
- metin konumu
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Java ve Aspose.Slides for Node.js kullanarak JavaScript ile PowerPoint sunumlarındaki metin bölümlerini nasıl yöneteceğinizi öğrenin, performansı ve özelleştirmeyi artırın."
---
## **Genel Bakış**

Bir metin bölümü, bir paragraftaki belirli bir metin parçasını temsil eder ve bu parçayla çevredeki içerikten bağımsız olarak çalışmanızı sağlar. Aspose.Slides içinde, bir metin parçasının konumunu almak, sadece bir paragrafın bir kısmına biçimlendirme uygulamak veya metin davranışını daha ayrıntılı bir seviyede kontrol etmek gerektiğinde bölümler kullanılabilir.

Bu makale, `getCoordinates()` metodunu kullanarak bir bölümün başlangıç koordinatlarını nasıl alacağınızı gösterir. Ayrıca, tek bir metin parçasına bir köprü (hyperlink) ekleme, biçimlendirmenin bölüm, paragraf, metin çerçevesi ve tema kalıtımı üzerinden nasıl çözümlendiğini anlama ve belirtilen bir yazı tipinin bulunmadığı durumları ele alma gibi yaygın bölümle ilgili senaryoları vurgular. Ek olarak, aynı paragraftaki bireysel bölümler için metin doldurma, renk ve şeffaflığın farklı şekilde ayarlanabileceğini belirtir.

## **Bölümün Konum Koordinatlarını Al**
[**getCoordinates()**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Portion#getCoordinates--) metodu, bölümün başlangıç koordinatlarını almanıza olanak tanıyan [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) sınıfına eklenmiştir.

```javascript
// PPTX'i temsil eden Prseetation sınıfını örnekle
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Sunum bağlamını yeniden şekillendirme
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Tek bir paragraftaki metnin yalnızca bir kısmına köprü (hyperlink) ekleyebilir miyim?**

Evet, bir bireysel bölüme [köprü atayabilirsiniz](/slides/tr/nodejs-java/manage-hyperlinks/); yalnızca o parça tıklanabilir, tüm paragraf değil.

**Stil kalıtımı nasıl çalışır: Bir Portion neyi geçersiz kılar ve neyi Paragraph/TextFrame'den alır?**

Bölüm düzeyindeki özellikler en yüksek önceliğe sahiptir. Bir özellik [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) içinde ayarlanmamışsa, motor bunu [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) öğesinden alır; orada da ayarlanmamışsa, [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) veya [theme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/theme/) stilinden alır.

**Bir Portion için belirtilen yazı tipi hedef makine/sunucuda yoksa ne olur?**

[Yazı tipi ikame kuralları](/slides/tr/nodejs-java/font-selection-sequence/) uygulanır. Metin yeniden akış gösterebilir: ölçümler, heceleme ve genişlik değişebilir, bu da kesin konumlandırma için önemlidir.

**Bir Paragraph'ın geri kalanından bağımsız olarak, yalnızca bir Portion için metin doldurma şeffaflığını veya gradyanı ayarlayabilir miyim?**

Evet, [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) seviyesindeki metin rengi, doldurma ve şeffaflık komşu parçalarla farklılık gösterebilir.