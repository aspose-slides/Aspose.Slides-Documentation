---
title: JavaScript Kullanarak Sunumlarda Şekil Efektlerini Uygula
linktitle: Şekil Efekti
type: docs
weight: 30
url: /tr/nodejs-java/shape-effect/
keywords:
- şekil efekti
- gölge efekti
- yansıma efekti
- parıltı efekti
- yumuşak kenarlar efekti
- efekt formatı
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js kullanarak gelişmiş şekil efektleriyle PPT ve PPTX dosyalarınızı dönüştürün—saniyeler içinde çarpıcı, profesyonel slaytlar oluşturun."
---
## **Giriş**

PowerPoint'taki efektler bir şeklin öne çıkmasını sağlarken, [doldurmalardan](/slides/tr/nodejs-java/shape-formatting/#gradient-fill) veya kenarlıklardan farklıdır. PowerPoint efektlerini kullanarak bir şekil üzerinde ikna edici yansımalar oluşturabilir, şeklin parlamasını yayabilir vb.

![Shape effect](shape-effect.png)

PowerPoint, şekillere uygulanabilen altı efekt sunar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle, PowerPoint **Preset** altında seçenekler sunar. Preset seçenekleri, iyi göründüğü bilinen iki veya daha fazla efektin kombinasyonlarıdır. Böylece bir preset seçerek, güzel bir kombinasyon bulmak için farklı efektleri deneme veya birleştirme konusunda zaman kaybetmezsiniz.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanızı sağlayan [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) sınıfı altında özellikler ve yöntemler sunar.

## **Gölge Efekti Uygulama**

Aspose.Slides for Node.js via Java, şekiller için dış ve iç gölgeleri destekler. Renklerini, yönünü, mesafesini ve bulanıklaştırma yarıçapını sunum tasarımınıza uygun şekilde özelleştirebilirsiniz.

### **Dış Gölge Uygulama**

Bir kartın veya panelin slayt arka planına karşı öne çıkmasını sağlamak için dış gölge kullanın. Gölge, şeklin kenarlarının ötesine uzanarak şeklin slayt üzerinde yükselmiş gibi görünmesini sağlar. Renk, yön, mesafe ve bulanıklaştırma yarıçapını şablonunuzun aydınlatması ve stiline uygun şekilde ayarlayın.

Bu JavaScript kodu, bir dikdörtgene [outer shadow effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) nasıl uygulanacağını gösterir:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Gölge efekti](shadow_effect.png)

### **İç Gölge Uygulama**

Bir şablonun görsel stilini yeniden üretirken, bir kartın veya panelin girintili bir görünüm kazanması için iç gölge kullanın. Dış gölge, şeklin dışına uzanarak yükselmiş görünürken, iç gölge kenarların içini gölgeler.

[enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) metodunu çağırın, ardından [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) tarafından döndürülen gölgeyi yapılandırın. Daha büyük bulanıklaştırma yarıçapı değerleri daha yumuşak kenarlar üretir.

Bu JavaScript örneği, koyu gri bir iç gölgeye sahip açık mavi bir kart oluşturur ve PPTX dosyası olarak kaydeder. Gölgenin yönü 225 derece, mesafesi 7 puan ve bulanıklaştırma yarıçapı 6 puandır:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![İç gölgeli açık mavi dikdörtgen](inner_shadow_effect.png)

İç gölgeyi kaldırmak için şeklin efekt formatında [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) metodunu çağırın.

## **Yansıma Efekti Uygulama**

Aspose.Slides for Node.js via Java'da yansıma efekti uygulamak için şekillere ayna benzeri bir yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha cilalı ve sofistike bir görünüm sağlayarak sunumlarınızın estetiğini artırır. Basit kodla kolayca uygulanabilir ve tutarlı bir tasarım için birden çok öğeye hızlıca uygulanmasını sağlar.

Bu JavaScript kodu, bir şekle [reflection effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) nasıl uygulanacağını gösterir:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Yansıma efekti](reflection_effect.png)

## **Parıltı Efekti Uygulama**

Aspose.Slides for Node.js via Java'da bir şekle parıltı efekti uygulamak için şekillerin etrafına yumuşak, ışıklı bir aura ekleyebilir, renk ve boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekillerin öne çıkmasını sağlar ve sunumunuza çekici, göz alıcı bir görsel öğe ekler. Minimum kodla kolayca uygulanabilir ve slaytlarınızın genel görünümünü artırır.

Bu JavaScript kodu, bir şekle [glow effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) nasıl uygulanacağını gösterir:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Parıltı efekti](glow_effect.png)

## **Yumuşak Kenarlar Efekti Uygulama**

Aspose.Slides for Node.js via Java'da yumuşak kenarlar efekti uygulamak için bir şeklin kenarları etrafında pürüzsüz, bulanık bir geçiş oluşturabilirsiniz. Bu efekt, daha hafif ve rafine bir görünüm ekler; nazik, daha yumuşak bir görünüm gerektiren tasarımlar için mükemmeldir. Sunumunuzdaki çeşitli şekillerde istenen efekti elde etmek için yarıçap gibi parametreleri kolayca ayarlayabilirsiniz.

Bu JavaScript kodu, bir şekle [soft edges effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) nasıl uygulanacağını gösterir:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Yumuşak kenarlar efekti](soft_edges_effect.png)

## **Bulanıklık Efekti Uygulama**

Şekil bulanıklığını, şeklin doldurulmasını ve konturunu düzenlenebilir tutarak yumuşatmak için kullanın. Şeklin efekt formatında [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) metodunu çağırın. Yarıçap, puan cinsinden ölçülür (1/72 inç): negatif olmayan bir değer kullanın; daha büyük değerler daha güçlü bir bulanıklık üretir. Sıfır yarıçap görünümü değiştirmez.

[getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) ayarı, etkinin görünen sınırlarını kontrol eder. `false` olduğunda, bulanıklık orijinal boyalı sınırlarla, kontur dahil, kırpılır. `true` olduğunda, bulanıklık bu sınırların ötesine uzanabilir. Hiçbir ayar şeklin konumunu veya boyutlarını değiştirmez.

Aşağıdaki karşılaştırma, tüm aşamalarda aynı doldurma, kontur ve şekil boyutlarını kullanır. Üst satır `grow = false`; alt satır `grow = true` kullanır.

![Büyütme kapalı ve açık iken 5 ve 15 puan bulanıklık yarıçaplarıyla karşılaştırılan orijinal dikdörtgen](shape_blur_comparison.png)

Bu JavaScript örneği, koyu mavi bir kontura sahip turuncu bir dikdörtgen oluşturur, 5 puanlık bulanıklık uygular ve ardından [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) metodunu tekrar çağırarak 15 puanlık bulanıklığa günceller. Her iki bulanıklaşmış durumu kaydeder, ardından [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) metodunu çağırıp şekli bulansız olarak kaydeder.
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Şekil bulanıklığı doldurma ve konturu birlikte etkiler. Yumuşak kenarlar efekti şeklin kenarlarını soluklaştırırken, gölge bulanıklığı sadece gölgeyi yumuşatır. Görüntü dönüşüm efektleri görüntü içeriği üzerinde çalışır; bu örnek şekli bir görüntüye dönüştürmeden doğrudan şeklin efekt formatına bulanıklık uygular.

## **SSS**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, gölge, yansıma ve parıltı gibi farklı efektleri tek bir şekle birleştirerek daha dinamik bir görünüm yaratabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Otomatik şekiller, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplandırılmış şekillere efekt uygulayabilir miyim?**

Evet, gruplandırılmış şekillere efekt uygulayabilirsiniz. Efekt bütün gruba uygulanır.