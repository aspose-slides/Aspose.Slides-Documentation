---
title: Android'de Sunum Temalarını Yönetme
linktitle: Sunum Teması
type: docs
weight: 10
url: /tr/androidjava/presentation-theme/
keywords:
- PowerPoint teması
- sunum teması
- slayt teması
- tema ayarla
- tema değiştir
- temayı yönet
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
description: "Java aracılığıyla Android için Aspose.Slides'te sunum temalarını yöneterek, tutarlı marka kimliğiyle PowerPoint dosyaları oluşturun, özelleştirin ve dönüştürün."
---
## **Giriş**

Bir sunum teması, tasarım öğelerinin özelliklerini tanımlar. Bir sunum teması seçtiğinizde, temelde belirli bir görsel öğe kümesini ve bu öğelerin özelliklerini seçmiş olursunuz.

PowerPoint'te bir tema, renkler, [fonts](/slides/tr/androidjava/powerpoint-fonts/), [background styles](/slides/tr/androidjava/presentation-background/) ve efektlerden oluşur.

![theme-constituents](theme-constit

## **Tema Rengini Değiştirme**

PowerPoint teması, slayttaki farklı öğeler için belirli bir renk kümesi kullanır. Renkleri beğenmezseniz, temaya yeni renkler uygulayarak renkleri değiştirebilirsiniz. Yeni bir tema rengi seçmenizi sağlamak için Aspose.Slides, [SchemeColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SchemeColor) enumunda değerler sunar.

Bu Java kodu, bir temasının vurgu rengini nasıl değiştireceğinizi gösterir:

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

Bu şekilde oluşan rengin etkili değerini belirleyebilirsiniz:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Renk değişikliği işlemini daha da göstermek için başka bir öğe oluşturup vurgu rengini (ilk işlemden) ona atıyoruz. Ardından temadaki rengi değiştiriyoruz:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

Yeni renk otomatik olarak her iki öğeye de uygulanır.

### **Ek Paletten Tema Rengini Ayarlama**

Ana tema rengine (1) parlaklık dönüşümleri uyguladığınızda, ek paletten (2) renkler oluşur. Bu tema renklerini daha sonra ayarlayabilir ve alabilirsiniz.

![additional-palette-colors](additional-palette-colors.png)

**1** - Ana tema renkleri  
**2** - Ek paletten gelen renkler.

Bu Java kodu, ek palet renklerinin ana tema renginden elde edilip şekillerde kullanılmasını gösterir:

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

### **`SchemeColor`'ı `IColorScheme` Renklerine Eşleme**

[SchemeColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/schemecolor/) ile çalışırken aşağıdaki tema rengi değerlerini içerdiğini fark edebilirsiniz:

`Background1`, `Background2`, `Text1` ve `Text2`.

Ancak `Presentation.getMasterTheme().getColorScheme()` [IColorScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icolorscheme/) döndürür ve ilgili renkleri şu şekilde sunar:

`Dark1`, `Dark2`, `Light1` ve `Light2`.

Bu fark yalnızca adlandırmadadır. Bu değerler aynı tema rengi konumlarına işaret eder ve eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` ile `Dark`/`Light` arasında dinamik bir dönüşüm yoktur. Bunlar aynı tema renkleri için sadece alternatif isimlerdir.

Bu adlandırma farkı Microsoft Office terminolojisinden gelmektedir. Eski Office sürümleri `Dark 1`, `Light 1`, `Dark 2` ve `Light 2` kullanırken, yeni UI sürümleri aynı konumları `Text 1`, `Background 1`, `Text 2` ve `Background 2` olarak gösterir.

## **Tema Yazı Tipini Değiştirme**

Tema ve diğer amaçlar için yazı tipleri seçmenizi sağlamak amacıyla Aspose.Slides, bu özel tanımlayıcıları (PowerPoint'te kullanılanlara benzer) kullanır:

* **+mn-lt** - Gövde Yazı Tipi Latin (Küçük Latin Yazı Tipi)
* **+mj-lt** - Başlık Yazı Tipi Latin (Büyük Latin Yazı Tipi)
* **+mn-ea** - Gövde Yazı Tipi Doğu Asya (Küçük Doğu Asya Yazı Tipi)
* **+mj-ea** - Gövde Yazı Tipi Doğu Asya (Büyük Doğu Asya Yazı Tipi)

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
PowerPoint yazı tiplerine bakmak isteyebilirsiniz. 
{{% /alert %}}

## **Tema Arka Plan Stilini Değiştirme**

Varsayılan olarak, PowerPoint uygulaması 12 önceden tanımlanmış arka plan sağlar ancak bu 12 arka planın sadece 3'ü tipik bir sunumda kaydedilir.

![todo:image_alt_text](presentation-design_8.png)

Örneğin, PowerPoint uygulamasında bir sunumu kaydettikten sonra, sunumdaki önceden tanımlanmış arka plan sayısını öğrenmek için bu Java kodunu çalıştırabilirsiniz:

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
PowerPoint temasında arka plan stilini eklemek veya erişmek için [FormatScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FormatScheme) sınıfının [BackgroundFillStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) özelliğini kullanabilirsiniz. 
{{% /alert %}} 

Bu Java kodu, bir sunum için arka planı nasıl ayarlayacağınızı gösterir:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Dizin rehberi**: 0 doldurma yok anlamında kullanılır. Dizin 1'den başlar.

{{% alert color="primary" title="TIP" %}} 
PowerPoint Arka Planına bakmak isteyebilirsiniz. 
{{% /alert %}}

## **Tema Efektini Değiştirme**

PowerPoint teması genellikle her stil dizisi için 3 değer içerir. Bu diziler, ince, orta ve yoğun olmak üzere bu 3 etkeye birleştirilir. Örneğin, etkiler belirli bir şekle uygulandığında ortaya çıkan sonuç şu şekildedir:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FormatScheme) sınıfının 3 özelliğini ([FillStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) kullanarak bir temadaki öğeleri (PowerPoint'teki seçeneklerden daha esnek bir şekilde) değiştirebilirsiniz:

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

Dolgu rengi, dolgu tipi, gölge efekti vb. üzerindeki oluşan değişiklikler:

![todo:image_alt_text](presentation-design_11.png)

## **SSS**

**Bir master'ı değiştirmeden bir slayda tema uygulayabilir miyim?**  
Evet. Aspose.Slides, slayt düzeyinde tema geçersiz kılmalarını destekler; bu sayede sadece o slayta yerel bir tema uygulayabilir ve ana temayı ( [SlideThemeManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidethememanager/) aracılığıyla) aynı tutabilirsiniz.

**Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?**  
[Clone slides](/slides/tr/androidjava/clone-slides/) hedef sunuma, masterlarıyla birlikte taşıyın. Bu, orijinal master, düzenler ve ilişkili temayı korur, böylece görünüm tutarlı kalır.

**Tüm kalıtım ve geçersiz kılmalar sonrasında “etkili” değerleri nasıl görebilirim?**  
Tema, renk, yazı tipi ve efekt için API'nin [“effective” görünümlerini](/slides/tr/androidjava/shape-effective-properties/) kullanın. Bunlar, master ve yerel geçersiz kılmalar uygulandıktan sonra çözülmüş, nihai özellikleri döndürür.