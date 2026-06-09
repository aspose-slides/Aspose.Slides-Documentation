---
title: JavaScript'te Sunum Erişilebilirliğini Yönet
linktitle: Sunum Erişilebilirliği
type: docs
weight: 30
url: /tr/nodejs-java/presentation-accessibility/
keywords:
- sunum erişilebilirliği
- dekoratif olarak işaretle
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile PPT, PPTX ve ODP dosyalarında sunum erişilebilirlik kontrollerini otomatikleştirin—ekran okuyucu deneyimini artırın ve uyumluluğu yükseltin."
---
## **Genel Bakış**

Sunum erişilebilirliği, ekran okuyucular, braille ekranları veya yalnızca klavye ile gezinme gibi yardımcı teknolojileri kullanan kişilerin slaytlarınızı, görsel olarak gören ve fare kullanan izleyiciler kadar etkili bir şekilde anlamasını ve gezinmesini sağlar. İyi uygulama, net bir okuma sırası, bilgilendirici görseller için anlamlı alternatif metin, yeterli renk kontrastı, okunabilir tipografi, açıklayıcı bağlantı metni ve anlamın yalnızca renk veya konumla iletilmesinden kaçınmaya odaklanır. Erişilebilirlik baştan planlandığında, sonuç daha temiz bir yapı, daha tutarlı görseller ve her izleyiciye ek çözümler olmadan ulaşan içerik olur.

## **Dekoratif Olarak İşaretle**

Dekoratif olarak işaretleme, yalnızca süs amaçlı görselleri işaretleyerek ekran okuyucuların bunları atlamasını sağlar, böylece gürültü azalır ve anlamlı içeriğe odaklanılır. Arka planlar, süslemeler ve boşluk dolduruculara uygulanır—hiçbir zaman bilgi sağlayan grafikler, simgeler veya resimlere uygulanmaz. Aspose.Slides, bu bayrağı tespit ve doğrulama amacıyla ortaya koyar; böylece otomatik erişilebilirlik denetimleri ve temizlik mümkün olur.

![Mark as Decorative](mark_as_decorative.png)

Aşağıdaki kod örneği, bir şeklin dekoratif olarak işaretlenip işaretlenmediğini nasıl belirleyeceğinizi gösterir.

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Is shape decorative:", shape.isDecorative());
} finally {
    presentation.dispose();
}
```