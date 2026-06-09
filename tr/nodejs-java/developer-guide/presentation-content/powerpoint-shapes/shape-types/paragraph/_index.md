---
title: JavaScript'te Sunumlardan Paragraf Sınırlamalarını Alın
linktitle: Paragraf
type: docs
weight: 60
url: /tr/nodejs-java/paragraph/
keywords:
- paragraf sınırlamaları
- metin bölümü sınırlamaları
- paragraf koordinatı
- bölüm koordinatı
- paragraf boyutu
- metin bölümü boyutu
- metin çerçevesi
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile JavaScript'te paragraf ve metin bölümü sınırlamalarını öğrenerek PowerPoint sunumlarındaki metin konumlandırmasını optimize edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde paragrafların ve metin bölümlerinin sınırlamalarını, boyutlarını ve koordinatlarını nasıl alacağınızı açıklar. `getRect()` kullanarak bir `TextFrame` içindeki paragrafın dikdörtgenini nasıl alacağınızı, tablo hücresi metin çerçevesi içinde paragraf ve bölüm koordinatlarını nasıl alacağınızı gösterir ve ölçüm birimleri, metin kaydırmanın sınırlara etkisi, piksel dönüşümü ve etkili paragraf biçimlendirme değerleri gibi önemli detayları vurgular.

## **TextFrame içinde Paragraf ve Bölüm Koordinatlarını Almak**
Aspose.Slides for Node.js via Java kullanarak geliştiriciler artık TextFrame'in paragraf koleksiyonundaki Paragraf için dikdörtgen koordinatları alabilir. Ayrıca bir paragraftaki bölüm koleksiyonundaki [bölümün koordinatları](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Portion#getCoordinates--) alınmasını sağlar. Bu konuda, bir örnek yardımıyla bir paragraf için dikdörtgen koordinatları ve paragraf içindeki bölümün konumunu nasıl alacağınızı göstereceğiz.

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```

## **Paragrafın Dikdörtgen Koordinatlarını Almak**
Geliştiriciler, [**getRect()**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Paragraph#getRect--) yöntemini kullanarak paragrafın sınırlama dikdörtgenini alabilir.

```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tablo Hücresi Metin Çerçevesi içinde Paragraf ve Bölüm Boyutunu Almak**

Bir tablo hücresi metin çerçevesinde [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Portion) veya [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Paragraph) boyutunu ve koordinatlarını almak için [Portion.getRect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Portion#getRect--) ve [Paragraph.getRect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Paragraph#getRect--) yöntemlerini kullanabilirsiniz.

Bu örnek kod, açıklanan işlemi gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Paragraf ve metin bölümleri için koordinatlar hangi birimlerde döndürülür?**  
Puan (point) cinsinden, 1 inç = 72 puan. Bu, slayttaki tüm koordinat ve boyutlar için geçerlidir.

**Kelime kaydırma bir paragrafın sınırlamalarını etkiler mi?**  
Evet. [wrapping](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/setwraptext/) [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) içinde etkinleştirildiğinde, metin alan genişliğine uyacak şekilde kesilir ve bu da paragrafın gerçek sınırlamalarını değiştirir.

**Paragraf koordinatları, dışa aktarılan görüntüde piksellere güvenilir bir şekilde eşlenebilir mi?**  
Evet. Puanları piksele şu şekilde dönüştürün: pixels = points × (DPI / 72). Sonuç, render/export için seçilen DPI'ye bağlıdır.

**Stil kalıtımını dikkate alarak “etkili” paragraf biçimlendirme parametrelerini nasıl alırım?**  
[etkili paragraf biçimlendirme veri yapısı](/slides/tr/nodejs-java/shape-effective-properties/) kullanın; girintiler, boşluklar, kaydırma, RTL ve daha fazlası için nihai birleşik değerleri döndürür.