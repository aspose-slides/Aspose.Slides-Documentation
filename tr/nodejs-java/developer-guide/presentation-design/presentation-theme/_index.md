---
title: "JavaScript'te Sunum Temalarını Yönetme"
linktitle: "Sunum Teması"
type: docs
weight: 10
url: /tr/nodejs-java/presentation-theme/
keywords:
- "PowerPoint teması"
- "sunum teması"
- "slayt teması"
- "tema ayarla"
- "temayı değiştir"
- "temayı yönet"
- "tema rengi"
- "ek palet"
- "tema fontu"
- "tema stili"
- "tema efekti"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Node.js için Aspose.Slides ile JavaScript'te temel sunum temalarını oluşturun, özelleştirin ve tutarlı markalama ile PowerPoint dosyalarını dönüştürün."
---
## **Giriş**

Bir sunum teması, tasarım öğelerinin özelliklerini tanımlar. Bir sunum teması seçtiğinizde, esasen belirli bir görsel öğe seti ve bunların özelliklerini seçmiş olursunuz.

PowerPoint'te bir tema, renkler, [fontlar](/slides/tr/nodejs-java/powerpoint-fonts/), [arka plan stilleri](/slides/tr/nodejs-java/presentation-background/) ve efektlerden oluşur.

![theme-constituents](theme-constituents.png)

## **Tema Rengini Değiştir**

PowerPoint teması, bir slayttaki farklı öğeler için belirli bir renk seti kullanır. Renkleri beğenmezseniz, temaya yeni renkler uygulayarak renkleri değiştirirsiniz. Yeni bir tema rengi seçmenizi sağlamak için Aspose.Slides, [SchemeColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SchemeColor) enum'ı altında değerler sunar.

Bu JavaScript kodu, bir temanın vurgu rengini nasıl değiştireceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Bu şekilde, elde edilen rengin etkili değerini belirleyebilirsiniz:

```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Renk değiştirme işlemini daha da göstermek için başka bir öğe oluşturur ve ona (ilk işlemeden) elde edilen vurgu rengini atarız. Ardından temadaki rengi değiştiririz:

```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Yeni renk, her iki öğeye de otomatik olarak uygulanır.

### **Ek Paletten Tema Rengini Ayarla**

Ana tema rengine (1) parlaklık dönüşümleri uyguladığınızda, ek paletten (2) renkler oluşur. Daha sonra bu tema renklerini ayarlayabilir ve alabilirsiniz.

![additional-palette-colors](additional-palette-colors.png)

**1** - Ana tema renkleri

**2** - Ek paletten renkler.

Bu JavaScript kodu, ek palet renklerinin ana tema renginden elde edildiği ve ardından şekillerde kullanıldığı bir işlemi gösterir:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // Vurgu 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // Vurgu 4, Daha Açık %80
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // Vurgu 4, Daha Açık %60
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // Vurgu 4, Daha Açık %40
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // Vurgu 4, Daha Koyu %25
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // Vurgu 4, Daha Koyu %50
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **`SchemeColor`'ı `ColorScheme` Renklerine Eşleştir**

[SchemeColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/schemecolor/) ile çalışırken, aşağıdaki tema renk değerlerini içerdiğini fark edebilirsiniz:

`Background1`, `Background2`, `Text1` ve `Text2`.

Ancak, `Presentation.getMasterTheme().getColorScheme()` [ColorScheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/colorscheme/) döndürür ve karşılık gelen renkleri şu şekilde sunar:

`Dark1`, `Dark2`, `Light1` ve `Light2`.

Bu fark sadece adlandırmada vardır. Bu değerler aynı tema rengi yuvalarına işaret eder ve eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` ile `Dark`/`Light` arasında dinamik bir dönüşüm yoktur. Bunlar aynı tema renklerinin sadece alternatif adlarıdır.

Bu adlandırma farkı, Microsoft Office terminolojisinden kaynaklanır. Eski Office sürümleri `Dark 1`, `Light 1`, `Dark 2` ve `Light 2` kullanırken, yeni UI sürümleri aynı yuvaları `Text 1`, `Background 1`, `Text 2` ve `Background 2` olarak gösterir.

## **Tema Fontunu Değiştir**

Temalar ve diğer amaçlar için font seçmenizi sağlamak üzere, Aspose.Slides bu özel tanımlayıcıları (PowerPoint'te kullanılanlara benzer) kullanır:

* **+mn-lt** - Gövde Fontu Latin (Küçük Latin Fontu)
* **+mj-lt** - Başlık Fontu Latin (Büyük Latin Fontu)
* **+mn-ea** - Gövde Fontu Doğu Asya (Küçük Doğu Asya Fontu)
* **+mj-ea** - Gövde Fontu Doğu Asya (Büyük Doğu Asya Fontu)

Bu JavaScript kodu, Latin fontunu bir tema öğesine nasıl atayacağınızı gösterir:

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

Bu JavaScript kodu, sunum temasının fontunu nasıl değiştireceğinizi gösterir:

```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

Tüm metin kutularındaki font güncellenecektir.

{{% alert color="primary" title="İPUCU" %}} 
[PowerPoint fontları](/slides/tr/nodejs-java/powerpoint-fonts/) görmek isteyebilirsiniz.
{{% /alert %}}

## **Tema Arka Plan Stilini Değiştir**

Varsayılan olarak, PowerPoint uygulaması 12 önceden tanımlı arka plan sunar, ancak bu 12 arka planın sadece 3'ü tipik bir sunumda kaydedilir.

![todo:image_alt_text](presentation-design_8.png)

Örneğin, PowerPoint uygulamasında bir sunumu kaydettikten sonra, sunumdaki önceden tanımlı arka planların sayısını öğrenmek için bu JavaScript kodunu çalıştırabilirsiniz:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" %}} 
PowerPoint temasında arka plan stilini ekleyebilir veya erişebilirsiniz, bunu [BackgroundFillStyles](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) özelliği ve [FormatScheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FormatScheme) sınıfı aracılığıyla yapabilirsiniz.
{{% /alert %}}

Bu JavaScript kodu, bir sunumun arka planını nasıl ayarlayacağınızı gösterir:

```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Dizin rehberi**: 0 doldurma yok anlamında kullanılır. Dizin 1'den başlar.

{{% alert color="primary" title="İPUCU" %}} 
[PowerPoint Arka Planı](/slides/tr/nodejs-java/presentation-background/) görmek isteyebilirsiniz.
{{% /alert %}}

## **Tema Efektini Değiştir**

PowerPoint teması genellikle her stil dizisi için 3 değer içerir. Bu diziler, üç etkiye (hafif, orta, yoğun) birleştirilir. Örneğin, etkiler belirli bir şekle uygulandığında ortaya çıkan sonuç şu şekildedir:

![todo:image_alt_text](presentation-design_10.png)

3 özellik ([FillStyles](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) kullanarak, [FormatScheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FormatScheme) sınıfından bir temadaki öğeleri (PowerPoint'teki seçeneklerden daha esnek bir şekilde) değiştirebilirsiniz:

```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Dolgu rengi, dolgu tipi, gölge efekti vb. üzerindeki sonuç değişiklikleri:

![todo:image_alt_text](presentation-design_11.png)

## **SSS**

**Master'ı değiştirmeden bir slayta tema uygulayabilir miyim?**

Evet. Aspose.Slides, slayt seviyesinde tema geçersiz kılmalarını destekler; böylece sadece o slayta yerel bir tema uygulayabilir ve master temayı aynı tutabilirsiniz (via the [SlideThemeManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidethememanager/)).

**Bir temayı bir sunumdan diğerine taşırken en güvenli yol nedir?**

[Slide'ları Klonla](/slides/tr/nodejs-java/clone-slides/) ve masterlarını hedef sunuma taşıyın. Bu, orijinal master, düzenler ve ilişkili temayı korur, böylece görünüm tutarlı kalır.

**Tüm kalıtım ve geçersiz kılmalar sonrası "etkili" değerleri nasıl görebilirim?**

API'nin tema/renk/font/efekt için ["etkili" görünümlerini](/slides/tr/nodejs-java/shape-effective-properties/) kullanın. Bunlar, master ve yerel geçersiz kılmalar uygulandıktan sonra çözümlenen, son özellikleri döndürür.