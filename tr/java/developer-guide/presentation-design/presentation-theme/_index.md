---
title: Java'da Sunum Temalarını Yönetme
linktitle: Sunum Teması
type: docs
weight: 10
url: /tr/java/presentation-theme/
keywords:
- PowerPoint teması
- sunum teması
- slayt teması
- tema ayarla
- tema değiştir
- tema yönet
- tema rengi
- ek palet
- tema yazı tipi
- tema stili
- tema efekti
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Java için Aspose.Slides'te ana sunum temalarını yöneterek, PowerPoint dosyalarını tutarlı marka kimliğiyle oluşturun, özelleştirin ve dönüştürün."
---
## **Giriş**

Bir sunum teması, tasarım öğelerinin özelliklerini tanımlar. Bir sunum teması seçtiğinizde, aslında belirli bir görsel öğe seti ve bu öğelerin özelliklerini seçmiş olursunuz.

PowerPoint’te bir tema, renkler, [fonts](/slides/tr/java/powerpoint-fonts/), [background styles](/slides/tr/java/presentation-background/) ve efektlerden oluşur.

![theme-constituents](theme-constituents.png)

## **Tema Rengini Değiştir**

PowerPoint teması, slayttaki farklı öğeler için belirli bir renk seti kullanır. Renkleri beğenmezseniz, temaya yeni renkler uygulayarak renkleri değiştirirsiniz. Yeni bir tema rengi seçmenizi sağlamak için Aspose.Slides, [SchemeColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SchemeColor) enumarasyonu altında değerler sunar.

Bu Java kodu, bir temanın vurgu rengini nasıl değiştireceğinizi gösterir:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Aşağıdaki şekilde sonucun etkili renk değerini belirleyebilirsiniz:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Renk değiştirme işlemini daha iyi göstermek için başka bir öğe oluşturup, vurgu rengini (ilk işlemlerden) ona atarız. Ardından temadaki rengi değiştiririz:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

Yeni renk, her iki öğeye de otomatik olarak uygulanır.

### **Ek Paletten Tema Rengini Ayarla**

Ana tema rengine (1) parlaklık dönüşümleri uyguladığınızda, ek paletten (2) renkler oluşur. Bu tema renklerini daha sonra ayarlayabilir ve alabilirsiniz.

![additional-palette-colors](additional-palette-colors.png)

**1** - Ana tema renkleri

**2** - Ek paletten renkler.

Bu Java kodu, ek palet renklerinin ana tema renginden elde edilip şekillerde nasıl kullanılacağını gösterir:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Vurgu 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Vurgu 4, %80 Daha Açık
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Vurgu 4, %60 Daha Açık
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Vurgu 4, %40 Daha Açık
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Vurgu 4, %25 Daha Koyu
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Vurgu 4, %50 Daha Koyu
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **`SchemeColor`ı `IColorScheme` Renklerine Eşleştir**

[SchemeColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/schemecolor/) ile çalıştığınızda, aşağıdaki tema renk değerlerini içerdiğini fark edebilirsiniz:

`Background1`, `Background2`, `Text1` ve `Text2`.

Ancak `Presentation.getMasterTheme().getColorScheme()` [IColorScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icolorscheme/) döndürür ve karşılık gelen renkleri şu şekilde sunar:

`Dark1`, `Dark2`, `Light1` ve `Light2`.

Bu fark sadece adlandırmadadır. Bu değerler aynı tema rengi yuvalarına karşılık gelir ve eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` ile `Dark`/`Light` arasında dinamik bir dönüşüm yoktur. Aynı tema renklerinin alternatif adlarıdır.

Bu adlandırma farkı Microsoft Office terminolojisinden kaynaklanır. Eski Office sürümleri `Dark 1`, `Light 1`, `Dark 2` ve `Light 2` kullanırken, yeni UI sürümleri aynı yuvaları `Text 1`, `Background 1`, `Text 2` ve `Background 2` olarak gösterir.

## **Tema Yazı Tipini Değiştir**

Temalar ve diğer amaçlar için yazı tiplerini seçmenizi sağlamak üzere Aspose.Slides, PowerPoint’te kullanılanlara benzer özel tanımlayıcılar kullanır:

* **+mn-lt** - Body Font Latin (Minor Latin Font)
* **+mj-lt** - Heading Font Latin (Major Latin Font)
* **+mn-ea** - Body Font East Asian (Minor East Asian Font)
* **+mj-ea** - Body Font East Asian (Major East Asian Font)

Bu Java kodu, Latin yazı tipini bir tema öğesine nasıl atayacağınızı gösterir:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Bu Java kodu, sunum temasının yazı tipini nasıl değiştireceğinizi gösterir:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

Tüm metin kutularındaki yazı tipi güncellenecektir.

{{% alert color="primary" title="TIP" %}} 
Sunum yazı tiplerini görmek isterseniz [PowerPoint fonts](/slides/tr/java/powerpoint-fonts/) sayfasına göz atabilirsiniz.
{{% /alert %}}

## **Tema Arka Plan Stilini Değiştir**

Varsayılan olarak PowerPoint uygulaması 12 önceden tanımlı arka plan sunar, ancak tipik bir sunumda bu 12 arka planın sadece 3’ü kaydedilir.

![todo:image_alt_text](presentation-design_8.png)

Örneğin, PowerPoint uygulamasında bir sunumu kaydettikten sonra, sunumdaki önceden tanımlı arka plan sayısını bulmak için aşağıdaki Java kodunu çalıştırabilirsiniz:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
[BackgroundFillStyles](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) özelliğini, [FormatScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FormatScheme) sınıfından kullanarak bir PowerPoint temasına arka plan stili ekleyebilir veya erişebilirsiniz.
{{% /alert %}} 

Bu Java kodu, bir sunum için arka planı nasıl ayarlayacağınızı gösterir:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Dizin kılavuzu**: 0 doldurma yok anlamına gelir. Dizin 1’den başlar.

{{% alert color="primary" title="TIP" %}} 
PowerPoint arka planlarını görmek isterseniz [PowerPoint Background](/slides/tr/java/presentation-background/) sayfasına bakabilirsiniz.
{{% /alert %}}

## **Tema Efektini Değiştir**

Bir PowerPoint teması genellikle her stil dizisi için 3 değer içerir. Bu diziler, şeffaf, orta ve yoğun olmak üzere 3 efekt halinde birleştirilir. Örneğin, etkiler belirli bir şekle uygulandığında elde edilen sonuç şu şekildedir:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FormatScheme) sınıfının 3 özelliğini ([FillStyles](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FormatScheme#getEffectStyles--)) kullanarak bir temadaki öğeleri (PowerPoint’teki seçeneklerden daha esnek bir şekilde) değiştirebilirsiniz.

Bu Java kodu, bir tema efektini öğe bölümlerini değiştirerek nasıl değiştireceğinizi gösterir:

```java
Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dolaylı renk, doldurma türü, gölge efekti vb. üzerindeki sonuç değişiklikleri:

![todo:image_alt_text](presentation-design_11.png)

## **SSS**

**Bir temayı yalnızca bir slayda, üst temayı değiştirmeden uygulayabilir miyim?**

Evet. Aspose.Slides, slayt düzeyinde tema geçersiz kılmalarını destekler; böylece yalnızca o slayta yerel bir tema uygulayabilir, üst temayı aynı tutabilirsiniz ([SlideThemeManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidethememanager/) aracılığıyla).

**Bir temayı bir sunumdan diğerine en güvenli şekilde nasıl taşıyabilirim?**

[Clone slides](/slides/tr/java/clone-slides/) komutunu, hedef sunuma masterlarıyla birlikte kullanın. Bu, özgün master, düzenler ve ilişkili temayı korur, böylece görünüm tutarlı kalır.

**Tüm kalıtım ve geçersiz kılmalar sonrası "etkili" değerleri nasıl görebilirim?**

Tema/rengin/yazı tipinin/efektin ["effective" görünümlerini](/slides/tr/java/shape-effective-properties/) kullanın. Bu, master ve yerel geçersiz kılmalar uygulandıktan sonra çözümlenmiş, son özellikleri döndürür.