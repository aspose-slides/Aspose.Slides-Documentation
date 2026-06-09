---
title: Sunumlarda JavaScript Kullanarak Şekil Efektleri Uygulama
linktitle: Şekil Efekti
type: docs
weight: 30
url: /tr/nodejs-java/shape-effect/
keywords:
- şekil efekti
- gölge efekti
- yansıma efekti
- parlaklık efekti
- yumuşak kenar efekti
- efekt formatı
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js kullanarak gelişmiş şekil efektleriyle PPT ve PPTX dosyalarınızı dönüştürün—saniyeler içinde çarpıcı, profesyonel slaytlar oluşturun."
---
## **Giriş**

PowerPoint'teki efektler bir şekli öne çıkarmak için kullanılabilir, ancak [doldurulmalar](/slides/tr/nodejs-java/shape-formatting/#gradient-fill) veya kenarlıklardan farklıdır. PowerPoint efektlerini kullanarak bir şeklin üzerinde ikna edici yansımalar yaratabilir, bir şeklin parlaklığını yayabilirsiniz, vb.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint şekillere uygulanabilen altı efekt sunar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz. 

* Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle PowerPoint'te **Preset** seçeneği vardır. Preset seçenekleri temelde iki veya daha fazla efektin iyi görünen bir kombinasyonudur. Bu şekilde, bir preset seçerek farklı efektleri test etmek veya birleştirmek için zaman kaybetmezsiniz.

Aspose.Slides, [EffectFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/EffectFormat) sınıfı altında özellikler ve yöntemler sunar ve bu sayede PowerPoint sunumlarındaki şekillere aynı efektleri uygulayabilirsiniz.

## **Gölge Efekti Uygula**

Bu JavaScript kodu, dış gölge efektini ([getOuterShadowEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/EffectFormat#getOuterShadowEffect)) bir dikdörtgene nasıl uygulayacağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "DARK_GRAY"));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Yansıma Efekti Uygula**

Bu JavaScript kodu, bir şekle yansıma efektini nasıl uygulayacağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);
    pres.save("reflection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Parlaklık Efekti Uygula**

Bu JavaScript kodu, bir şekle parlaklık efektini nasıl uygulayacağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    shape.getEffectFormat().getGlowEffect().setRadius(15);
    pres.save("glow.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Yumuşak Kenarlar Efekti Uygula**

Bu JavaScript kodu, bir şekle yumuşak kenarları nasıl uygulayacağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);
    pres.save("softEdges.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **S.S.S.**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, gölge, yansıma ve parlaklık gibi farklı efektleri tek bir şekle birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Autoshape, grafik, tablo, resim, SmartArt nesnesi, OLE nesnesi ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplandırılmış şekillere efekt uygulayabilir miyim?**

Evet, gruplandırılmış şekillere efekt uygulayabilirsiniz. Efekt tüm grup üzerinde uygulanır.