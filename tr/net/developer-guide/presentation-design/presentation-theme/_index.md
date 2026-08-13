---
title: .NET'te Sunum Temalarını Yönet
linktitle: Sunum Teması
type: docs
weight: 10
url: /tr/net/presentation-theme/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile tutarlı marka kimliği sağlayarak PowerPoint dosyalarını oluşturmak, özelleştirmek ve dönüştürmek için ana sunum temalarını yönetin."
---
## **Giriş**

Bir sunum teması, tasarım öğelerinin özelliklerini tanımlar. Bir sunum teması seçtiğinizde, esasen belirli bir görsel öğe kümesini ve bunların özelliklerini seçmiş olursunuz.

PowerPoint'te bir tema, renkler, [yazı tipleri](/slides/tr/net/powerpoint-fonts/), [arkaplan stilleri](/slides/tr/net/presentation-background/) ve efektlerden oluşur.

![theme-constituents](theme-constituents.png)

## **Tema Rengini Değiştir**

PowerPoint teması, slayttaki farklı öğeler için belirli bir renk kümesi kullanır. Renkleri beğenmezseniz, temaya yeni renkler uygulayarak renkleri değiştirirsiniz. Yeni bir tema rengi seçebilmeniz için Aspose.Slides, [SchemeColor](https://reference.aspose.com/slides/tr/net/aspose.slides/schemecolor/) enumunda değerler sunar.

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Bu şekilde, elde edilen rengin etkili değerini belirleyebilirsiniz:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    var fillEffective = shape.FillFormat.GetEffective();

    Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Renk [A=255, R=128, G=100, B=162])
}
```

Renk değişikliği işlemini daha da göstermek için başka bir öğe oluşturup ona vurgu rengini (ilk işlemeden) atarız. Ardından temadaki rengi değiştiririz:

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.FillFormat.FillType = FillType.Solid;

    otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
}
```

Yeni renk her iki öğeye otomatik olarak uygulanır.

### **Ek Paletten Tema Rengini Ayarla**

Ana tema rengine (1) parlaklık dönüşümleri uyguladığınızda, ek paletten (2) renkler oluşur. Bu tema renklerini daha sonra ayarlayabilir ve alabilirsiniz.

![additional-palette-colors](additional-palette-colors.png)

**1** - Ana tema renkleri  
**2** - Ek paletten gelen renkler.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Accent 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Accent 4, %80 Daha Açık
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4, %60 Daha Açık
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4, %40 Daha Açık
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4, %25 Daha Koyu
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4, %50 Daha Koyu
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **`SchemeColor`'ı `IColorScheme` Renklerine Eşleştir**

[SchemeColor](https://reference.aspose.com/slides/tr/net/aspose.slides/schemecolor/) ile çalışırken, aşağıdaki tema renk değerlerini içerdiğini fark edebilirsiniz: `Background1`, `Background2`, `Text1`, ve `Text2`.

Ancak, `Presentation.MasterTheme.ColorScheme` [IColorScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/icolorscheme/) döndürür ve karşılık gelen renkleri şu şekilde gösterir: `Dark1`, `Dark2`, `Light1`, ve `Light2`.

Bu fark sadece isimlendirmededir. Bu değerler aynı tema rengi yuvalarına işaret eder ve eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` ile `Dark`/`Light` arasında dinamik bir dönüşüm yoktur. Bunlar aynı tema renklerinin sadece alternatif adlarıdır.

Bu isimlendirme farkı Microsoft Office terminolojisinden kaynaklanır. Eski Office sürümleri `Dark 1`, `Light 1`, `Dark 2` ve `Light 2` kullanırken, yeni UI sürümleri aynı yuvaları `Text 1`, `Background 1`, `Text 2` ve `Background 2` olarak gösterir.

## **Tema Yazı Tipini Değiştir**

Temalar ve diğer amaçlar için yazı tiplerini seçebilmeniz için Aspose.Slides bu özel tanımlayıcıları (PowerPoint'te kullanılanlara benzer) kullanır:

* **+mn-lt** - Gövde Yazı Tipi Latin (Küçük Latin Yazı Tipi)
* **+mj-lt** - Başlık Yazı Tipi Latin (Büyük Latin Yazı Tipi)
* **+mn-ea** - Gövde Yazı Tipi Doğu Asya (Küçük Doğu Asya Yazı Tipi)
* **+mj-ea** - Başlık Yazı Tipi Doğu Asya (Büyük Doğu Asya Yazı Tipi)

Bu C# kodu, Latin yazı tipini bir tema öğesine nasıl atayacağınızı gösterir:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.Portions.Add(portion);

    shape.TextFrame.Paragraphs.Add(paragraph);

    portion.PortionFormat.LatinFont = new FontData("+mn-lt");
}
```

Bu C# kodu, sunum teması yazı tipini nasıl değiştireceğinizi gösterir:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
}
```

Tüm metin kutularındaki yazı tipi güncellenecektir.

{{% alert color="info" title="TIP" %}} 
PowerPoint yazı tiplerine bakmak isteyebilirsiniz: [PowerPoint yazı tipleri](/slides/tr/net/powerpoint-fonts/).
{{% /alert %}}

## **Tema Arkaplan Stilini Değiştir**

Varsayılan olarak, PowerPoint uygulaması 12 ön tanımlı arka plan sunar ancak bu 12 arka planın yalnızca 3’ü tipik bir sunumda kaydedilir.

![todo:image_alt_text](presentation-design_8.png)

Örneğin, PowerPoint uygulamasında bir sunumu kaydettikten sonra, sunumdaki ön tanımlı arka plan sayısını öğrenmek için bu C# kodunu çalıştırabilirsiniz:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
[BackgroundFillStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) özelliğini [FormatScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/) sınıfından kullanarak bir PowerPoint temasında arka plan stilini ekleyebilir veya erişebilirsiniz. 
{{% /alert %}}

Bu C# kodu, bir sunumun arka planını nasıl ayarlayacağınızı gösterir:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Masters[0].Background.StyleIndex = 2;
}
```

**Dizin rehberi**: 0 dolgu yok anlamında kullanılır. Dizin 1'den başlar.

{{% alert color="info" title="TIP" %}} 
PowerPoint arka planına bakmak isteyebilirsiniz: [PowerPoint Arka Plan](/slides/tr/net/presentation-background/).
{{% /alert %}}

## **Tema Efektini Değiştir**

PowerPoint teması genellikle her stil dizisi için 3 değer içerir. Bu diziler, ince, orta ve yoğun olmak üzere 3 etkibe birleştirilir. Örneğin, efektler belirli bir şekle uygulandığında ortaya çıkan sonuç şöyledir:

![todo:image_alt_text](presentation-design_10.png)

[FillStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/effectstyles) özelliklerini [FormatScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme) sınıfından kullanarak bir temadaki öğeleri (PowerPoint'teki seçeneklerden daha esnek bir şekilde) değiştirebilirsiniz:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

Dolgu rengi, dolgu tipi, gölge efekti vb. üzerindeki sonuç değişiklikleri:

![todo:image_alt_text](presentation-design_11.png)

## **SSS**

### Bir temayı ana temayı değiştirmeden tek bir slayta uygulayabilir miyim?

Evet. Aspose.Slides, slayt düzeyinde tema geçersiz kılmalarını destekler; böylece sadece o slayta yerel bir tema uygulayabilir ve ana temayı ([SlideThemeManager](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/slidethememanager/)) değiştirmeden koruyabilirsiniz.

### Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?

[Slaytları kopyala](/slides/tr/net/clone-slides/) ve ana temaları hedef sunuma taşıyarak. Bu, orijinal ana temayı, düzenleri ve ilişkili temayı korur; böylece görünüm tutarlı kalır.

### Tüm kalıtımlar ve geçersiz kılmalar sonrası "etkili" değerleri nasıl görebilirim?

Tema/rengi/yazı tipi/efekt için API'nin ["etkili" görünümlerini](/slides/tr/net/shape-effective-properties/) kullanın. Bunlar, ana temayı ve yerel geçersiz kılmaları uyguladıktan sonra çözümlenmiş, final özellikleri döndürür.