---
title: Android'de Sunumlarda Şekil Efektleri Uygulama
linktitle: Şekil Efekti
type: docs
weight: 30
url: /tr/androidjava/shape-effect/
keywords:
- şekil efekti
- gölge efekti
- yansıma efekti
- parlama efekti
- yumuşak kenarlar efekti
- efekt formatı
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'i Java aracılığıyla kullanarak PPT ve PPTX dosyalarınızı gelişmiş şekil efektleriyle dönüştürün—saniyeler içinde çarpıcı ve profesyonel slaytlar oluşturun."
---
## **Giriş**

PowerPoint'teki efektler bir şekli öne çıkarmak için kullanılabilirken, [dolgu](/slides/tr/androidjava/shape-formatting/#gradient-fill) veya kenarlıklardan farklıdır. PowerPoint efektlerini kullanarak bir şeklin üzerinde ikna edici yansımalar oluşturabilir, şeklin parlamasını yayabilirsiniz, vb.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint, şekillere uygulanabilen altı efekt sağlar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz. 

* Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle, PowerPoint **Preset** altında seçenekler sunar. Preset seçenekleri, temelde iki veya daha fazla efektin iyi görünen bilinen bir kombinasyonudur. Böylece bir preset seçerek farklı efektleri test edip kombinlemek için zaman harcamazsınız.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanıza olanak tanıyan [EffectFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/EffectFormat) sınıfı altında özellikler ve yöntemler sağlar.

## **Gölge Efekti Uygulama**

Bu Java kodu, dış gölge efekti ([OuterShadowEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) bir dikdörtgene nasıl uygulayacağınızı gösterir:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Yansıma Efekti Uygulama**

Bu Java kodu, yansıma efektini bir şekle nasıl uygulayacağınızı gösterir:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);

    pres.save("reflection.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Parlama Efekti Uygulama**

Bu Java kodu, parlama efektini bir şekle nasıl uygulayacağınızı gösterir:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    pres.save("glow.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Yumuşak Kenarlar Efekti Uygulama**

Bu Java kodu, yumuşak kenarları bir şekle nasıl uygulayacağınızı gösterir:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);

    pres.save("softEdges.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, tek bir şekle gölge, yansıma ve parlama gibi farklı efektleri birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Otomatik şekiller, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplanmış şekillere efekt uygulayabilir miyim?**

Evet, grup halinde bulunan şekillere efekt uygulayabilirsiniz. Efekt tüm gruba uygulanacaktır.