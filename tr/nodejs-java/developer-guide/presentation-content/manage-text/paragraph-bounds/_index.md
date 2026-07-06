---
title: JavaScript'te Sunumlardan Paragraf Sınırlarını Alın
linktitle: Paragraf Sınırları
type: docs
weight: 43
url: /tr/nodejs-java/paragraph-bounds/
keywords:
- paragraf sınırları
- paragraf koordinatı
- paragraf boyutu
- metin çerçevesi
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint sunumlarında metin konumlandırmayı optimize etmek için Java üzerinden Aspose.Slides for Node.js'te paragraf sınırlarını nasıl alacağınızı öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde paragrafların sınırlarını, boyutunu ve koordinatlarını nasıl alacağınızı açıklar. Bir paragraf dikdörtgenini [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) üzerinden [Paragraph.getRect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/getrect/) kullanarak nasıl alacağınızı, bir tablo hücresi metin çerçevesi içindeki paragraf koordinatlarını nasıl elde edeceğinizi gösterir ve ölçü birimleri, metin kaydırmanın sınırlar üzerindeki etkisi, piksel dönüşümü ve etkili paragraf biçimlendirme değerleri gibi önemli ayrıntıları vurgular.

## **Bir Paragrafın Dikdörtgen Koordinatlarını Almak**

Bir paragrafın sınırlayıcı dikdörtgenini elde etmek için [Paragraph.getRect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/getrect/) kullanın.

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Bir Tablo Hücresi TextFrame İçindeki Paragrafın Boyutunu Alın**

Bir tablo hücresi metin çerçevesindeki bir [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) boyutunu ve koordinatlarını elde etmek için [Paragraph.getRect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/getrect/) kullanın. Döndürülen dikdörtgen tablo hücresi metin çerçevesine göre görelidir, bu yüzden slayt seviyesindeki koordinatlara ihtiyacınız olduğunda tablo konumunu ve hücre ofsetini ekleyin.

Aşağıdaki örnek, bir tablo hücresi içindeki paragraf sınırlarını alır ve bu sınırları görselleştirmek için slayta dikdörtgenler çizer:

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Paragraf koordinatları hangi birimlerde ölçülür?**

Puan cinsinden ölçülür, 1 inç 72 puana eşittir. Bu, slayttaki tüm koordinat ve boyutlar için geçerlidir.

**Metin kaydırma bir paragrafın sınırlarını etkiler mi?**

Evet. Eğer [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/setwraptext/) [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) için etkinleştirilmişse, metin alan genişliğine sığdırmak için kırılır ve bu, paragrafın gerçek sınırlarını değiştirir.

**Paragraf koordinatları, dışa aktarılmış görüntüde piksellere güvenilir bir şekilde eşlenebilir mi?**

Evet. Puanları piksele şu formülle dönüştürün: piksel = puan x (DPI / 72). Sonuç, render veya dışa aktarım için seçilen DPI'ye bağlıdır.

**Stil kalıtımını dikkate alarak "etkili" paragraf biçimlendirme parametrelerini nasıl alırım?**

[effective paragraph formatting data structure](/slides/tr/nodejs-java/shape-effective-properties/) kullanın; bu, girintiler, aralık, kaydırma, RTL ve daha fazlası için nihai birleştirilmiş değerleri döndürür.