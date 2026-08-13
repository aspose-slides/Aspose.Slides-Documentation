---
title: Android'de Sunum Temalarını Yönet
linktitle: Sunum Teması
type: docs
weight: 10
url: /tr/androidjava/presentation-theme/
keywords:
- PowerPoint teması
- sunum teması
- slayt teması
- tema ayarla
- temayı değiştir
- tema yönet
- tema rengi
- ek palet
- tema yazı tipi
- tema stili
- tema efekti
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Java üzerinden Android için Aspose.Slides'te sunum temalarını yöneterek, PowerPoint dosyalarını tutarlı bir marka kimliğiyle oluşturun, özelleştirin ve dönüştürün."
---
## **Giriş**

Bir sunum teması, tasarım öğelerinin özelliklerini tanımlar. Bir sunum teması seçtiğinizde, aslında belirli bir görsel öğe seti ve onların özelliklerini seçmiş olursunuz.

PowerPoint'te bir tema, renkler, [fonts](/slides/tr/androidjava/powerpoint-fonts/), [background styles](/slides/tr/androidjava/presentation-background/) ve efektlerden oluşur.

![theme-constituents](theme-constituents.png)

## **Tema Rengini Değiştir**

PowerPoint teması, slayttaki farklı öğeler için belirli bir renk seti kullanır. Renkleri beğenmezseniz, tema için yeni renkler uygulayarak renkleri değiştirirsiniz. Yeni bir tema rengi seçebilmeniz için Aspose.Slides, [SchemeColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SchemeColor) numaralandırması altında değerler sunar.

Bu Java kodu, bir temanın vurgu renginin nasıl değiştirileceğini gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Aşağıdaki şekilde elde edilen rengin etkili değerini belirleyebilirsiniz:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

Renk değişimi işlemini daha iyi göstermek için başka bir öğe oluşturur ve ona (ilk işlemden elde edilen) vurgu rengini atarız. Ardından temadaki rengi değiştiririz:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

Yeni renk her iki öğeye de otomatik olarak uygulanır.

### **Ek Paletten Tema Rengi Ayarlama**

Ana tema rengine (1) parlaklık dönüşümleri uygulandığında, ek paletten (2) renkler oluşur. Bu tema renklerini ayarlayabilir ve alabilirsiniz.

![additional-palette-colors](additional-palette-colors.png)

**1** - Ana tema renkleri  

**2** - Ek paletten gelen renkler.

Bu Java kodu, ek palet renklerinin ana tema renginden elde edildiği ve ardından şekillerde kullanıldığı bir işlemi gösterir:

```java
import com.aspose.slides.*;

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

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **`SchemeColor`'ı `IColorScheme` Renklerine Eşleme**

[SchemeColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/schemecolor/) ile çalışırken aşağıdaki tema renk değerlerini içerdiğini görebilirsiniz:

`Background1`, `Background2`, `Text1` ve `Text2`.

Ancak `Presentation.getMasterTheme().getColorScheme()` [IColorScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icolorscheme/) döndürür ve ilgili renkleri şu şekilde sunar:

`Dark1`, `Dark2`, `Light1` ve `Light2`.

Bu fark sadece adlandırmadadır. Bu değerler aynı tema rengi yuvalarına karşılık gelir ve eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` ile `Dark`/`Light` arasında dinamik bir dönüşüm yoktur. Aynı tema renklerinin alternatif adlarıdır.

Bu adlandırma farkı Microsoft Office terminolojisinden kaynaklanır. Eski Office sürümleri `Dark 1`, `Light 1`, `Dark 2` ve `Light 2` kullanırken, yeni UI sürümleri aynı yuvaları `Text 1`, `Background 1`, `Text 2` ve `Background 2` olarak gösterir.

## **Tema Yazı Tipini Değiştir**

Tema ve diğer amaçlar için yazı tiplerini seçebilmeniz için Aspose.Slides, PowerPoint'te kullanılanlarla benzer özel tanımlayıcıları kullanır:

* **+mn-lt** – Gövde Yazı Tipi Latin (Minor Latin Font)
* **+mj-lt** – Başlık Yazı Tipi Latin (Major Latin Font)
* **+mn-ea** – Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
* **+mj-ea** – Başlık Yazı Tipi Doğu Asya (Major East Asian Font)

Bu Java kodu, Latin yazı tipini bir tema öğesine atamayı gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

Bu Java kodu, sunum temasının yazı tipini nasıl değiştireceğinizi gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

Tüm metin kutularındaki yazı tipi güncellenecektir.

{{% alert color="info" title="TIP" %}} 
Temayı görmek isteyebilirsiniz [PowerPoint fonts](/slides/tr/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Tema Arka Plan Stili Değiştir**

Varsayılan olarak PowerPoint uygulaması 12 önceden tanımlı arka plan sunar, ancak tipik bir sunumda bu 12 arka planın yalnızca 3'ü kaydedilir.

![todo:image_alt_text](presentation-design_8.png)

Örneğin, PowerPoint uygulamasında bir sunumu kaydettikten sonra, sunumdaki önceden tanımlı arka plan sayısını öğrenmek için bu Java kodunu çalıştırabilirsiniz:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
[BackgroundFillStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) özelliğini [FormatScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FormatScheme) sınıfından kullanarak bir PowerPoint temasında arka plan stilini ekleyebilir veya erişebilirsiniz.
{{% /alert %}} 

Bu Java kodu, bir sunumun arka planını nasıl ayarlayacağınızı gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**Dizin rehberi**: 0, doldurma yok anlamına gelir. Dizin 1'den başlar.

{{% alert color="info" title="TIP" %}} 
[PowerPoint Background](/slides/tr/androidjava/presentation-background/) sayfasına bakabilirsiniz.
{{% /alert %}}

## **Tema Efektini Değiştir**

Bir PowerPoint teması genellikle her stil dizisi için 3 değer içerir. Bu diziler, şunları birleştirerek 3 etki oluşturur: ince, orta ve yoğun. Örneğin, etkiler belirli bir şekle uygulandığında ortaya çıkan sonuç şöyle olur:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FormatScheme) sınıfından 3 özellik ([FillStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) kullanarak bir temadaki öğeleri (PowerPoint'teki seçeneklerden daha esnek bir şekilde) değiştirebilirsiniz.

Bu Java kodu, öğelerin bölümlerini değiştirerek bir tema efektini nasıl değiştireceğinizi gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Dolayısıyla doldurma rengi, doldurma türü, gölge efekti vb. değişiklikler şu şekilde görünür:

![todo:image_alt_text](presentation-design_11.png)

## **SSS**

### Tek bir slayta, master değiştirilmeden tema uygulayabilir miyim?

Evet. Aspose.Slides, slayt seviyesinde tema geçersiz kılmalarını destekler; böylece yalnızca o slayta yerel bir tema uygulayabilir ve master temayı ( [SlideThemeManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidethememanager/) aracılığıyla) bozmadan bırakabilirsiniz.

### Bir sunumdan diğerine temayı en güvenli şekilde nasıl taşıyabilirim?

[Clone slides](/slides/tr/androidjava/clone-slides/) komutunu, hedef sunuma masterıyla birlikte kullanın. Bu, orijinal master, düzenler ve ilişkili temayı korur, böylece görünüm tutarlı kalır.

### Tüm kalıtım ve geçersiz kılmalar sonrası “etkin” değerleri nasıl görebilirim?

Tema/rengi/yazı tipi/efekti için API'nin ["effective" views](/slides/tr/androidjava/shape-effective-properties/) özelliğini kullanın. Bu, master ve yerel geçersiz kılmalar uygulandıktan sonra çözülmüş, son özellikleri döndürür.