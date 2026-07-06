---
title: JavaScript'te Sunumlardan Metin Bölümü Sınırlarını Al
linktitle: Bölüm Sınırları
type: docs
weight: 47
url: /tr/nodejs-java/portion-bounds/
keywords:
- metin bölümü sınırları
- metin bölümü
- metin parçası
- metin koordinatları
- metin konumu
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak Java aracılığıyla PowerPoint sunumlarındaki metin bölümü sınırlarını nasıl alacağınızı öğrenin."
---
## **Genel Bakış**

Bir metin bölümü, bir paragraftaki belirli bir metin parçacığını temsil eder ve bu parçacıkla, çevresindeki içerikten bağımsız olarak çalışmanıza olanak tanır. Aspose.Slides içinde, bölümler bir metin parçacığının sınırlarını almak, yalnızca bir paragrafın bir kısmına biçimlendirme uygulamak veya metin davranışını daha ayrıntılı bir seviyede kontrol etmek istediğinizde kullanılabilir.

Bu makale, bir bölümün sınırlayıcı dikdörtgenini [Portion.getRect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/getrect/) kullanarak nasıl alacağınızı gösterir. Ayrıca, bir bölümün başlangıç koordinatlarını [Portion.getCoordinates](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/getcoordinates/) kullanarak nasıl alacağınızı gösterir. Ek olarak, tek bir metin parçacığına hiperlink ekleme, biçimlendirmenin bölüm, paragraf, metin çerçevesi ve tema kalıtımı üzerinden nasıl çözüldüğünü anlama ve belirtilen bir yazı tipinin bulunmadığı durumları ele alma gibi yaygın bölümle ilgili senaryoları vurgular.

## **Metin Bölümünün Sınırlarını Al**

Metin bölümünün sınırlayıcı dikdörtgenini almak için [Portion.getRect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/getrect/) kullanın:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Metin Bölümünün Koordinatlarını Al**

Metin bölümünün başlangıç koordinatlarını almak için [Portion.getCoordinates](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/getcoordinates/) kullanın:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **SSS**

**Bir paragraf içinde metnin yalnızca bir kısmına hiperlink uygulayabilir miyim?**

Evet, tek bir bölüme [hyperlink atayın](/slides/tr/nodejs-java/manage-hyperlinks/); yalnızca o parçacık tıklanabilir olur, tüm paragraf değil.

**Stil kalıtımı nasıl çalışır: bir bölüm neyi geçersiz kılar ve neyi bir paragraf veya metin çerçevesinden alır?**

Bölüm düzeyindeki özellikler en yüksek önceliğe sahiptir. Bir özellik [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) üzerinde ayarlanmamışsa, Aspose.Slides onu [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) üzerinden alır. Orada da ayarlanmamışsa, Aspose.Slides [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) veya [theme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/theme/) stilini kullanır.

**Bir bölüm için belirtilen yazı tipi hedef makine veya sunucuda bulunamazsa ne olur?**

[Yazı tipi ikame kuralları](/slides/tr/nodejs-java/font-selection-sequence/) uygulanır. Metin yeniden akabilir: ölçümler, heceleme ve genişlik değişebilir, bu da hassas konumlandırma için önemlidir.

**Bölüme özgü metin dolgu şeffaflığını ya da bir geçişi paragrafın geri kalanından bağımsız olarak ayarlayabilir miyim?**

Evet, [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) düzeyinde metin rengi, dolgu ve şeffaflık komşu parçacıklardan farklı olabilir.