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
description: "Aspose.Slides for .NET içinde sunum temalarını yöneterek, tutarlı marka kimliğiyle PowerPoint dosyaları oluşturun, özelleştirin ve dönüştürün."
---
## **Giriş**

Bir sunum teması, tasarım öğelerinin özelliklerini tanımlar. Bir sunum teması seçtiğinizde, aslında belirli bir görsel öğe kümesini ve bunların özelliklerini seçmiş olursunuz.

PowerPoint'te bir tema, renkler, [fonts](/slides/tr/net/powerpoint-fonts/), [background styles](/slides/tr/net/presentation-background/) ve efektlerden oluşur.

![theme-constituents](theme-constituents.png)

## **Tema Rengini Değiştir**

Bir PowerPoint teması, slayttaki farklı öğeler için belirli bir renk seti kullanır. Renkleri beğenmezseniz, temaya yeni renkler uygulayarak değiştirirsiniz. Yeni bir tema rengi seçebilmeniz için Aspose.Slides, [SchemeColor](https://reference.aspose.com/slides/tr/net/aspose.slides/schemecolor/) sayımında değerler sağlar.

Bu C# kodu, bir tema için vurgu rengini nasıl değiştireceğinizi gösterir:

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Bu şekilde, elde edilen rengin etkili değerini belirleyebilirsiniz:

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Renk [A=255, R=128, G=100, B=162])
```

Renk değişimi işlemini daha da göstermek için, başka bir öğe oluşturup vurgu rengini (ilk işlemeden) ona atarız. Ardından temadaki rengi değiştiririz:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

Yeni renk her iki öğeye de otomatik olarak uygulanır.

### **Ek Palet'ten Tema Rengini Ayarla**

Ana tema rengine(1) parlaklık dönüşümleri uyguladığınızda, ek paletten(2) renkler oluşur. Daha sonra bu tema renklerini ayarlayabilir ve alabilirsiniz.

![additional-palette-colors](additional-palette-colors.png)

**1** - Ana tema renkleri  
**2** - Ek paletten gelen renkler.

Bu C# kodu, ek palet renklerinin ana tema renginden elde edilip şekillerde kullanıldığı bir işlemi gösterir:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Vurgu 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Vurgu 4, %80 Daha Açık
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Vurgu 4, %60 Daha Açık
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Vurgu 4, %40 Daha Açık
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Vurgu 4, %25 Daha Koyu
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Vurgu 4, %50 Daha Koyu
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **`SchemeColor`'ı `IColorScheme` Renklerine Eşleme**

[SchemeColor](https://reference.aspose.com/slides/tr/net/aspose.slides/schemecolor/) ile çalışırken, aşağıdaki tema renk değerlerini içerdiğini fark edebilirsiniz: `Background1`, `Background2`, `Text1` ve `Text2`.

Ancak `Presentation.MasterTheme.ColorScheme` [IColorScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/icolorscheme/) döndürür ve karşılık gelen renkleri şu şekilde sunar: `Dark1`, `Dark2`, `Light1` ve `Light2`.

Bu fark yalnızca adlandırmada ortaya çıkar. Bu değerler aynı tema renk yuvalarına gönderme yapar ve eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` ile `Dark`/`Light` arasında dinamik bir dönüşüm yoktur. Bunlar aynı tema renkleri için alternatif adlardır.

Bu adlandırma farkı, Microsoft Office terminolojisinden kaynaklanmaktadır. Eski Office sürümleri `Dark 1`, `Light 1`, `Dark 2` ve `Light 2` kullanırken, yeni UI sürümleri aynı yuvaları `Text 1`, `Background 1`, `Text 2` ve `Background 2` olarak gösterir.

## **Tema Yazı Tipini Değiştir**

Tema ve diğer amaçlar için yazı tiplerini seçmenizi sağlamak amacıyla, Aspose.Slides bu özel tanımlayıcıları (PowerPoint'te kullanılanlara benzer) kullanır:

* **+mn-lt** - Gövde Yazı Tipi Latin (Küçük Latin Yazı Tipi)
* **+mj-lt** - Başlık Yazı Tipi Latin (Büyük Latin Yazı Tipi)
* **+mn-ea** - Gövde Yazı Tipi Doğu Asya (Küçük Doğu Asya Yazı Tipi)
* **+mj-ea** - Başlık Yazı Tipi Doğu Asya (Büyük Doğu Asya Yazı Tipi)

Bu C# kodu, Latin yazı tipini bir tema öğesine atamanızı gösterir:

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

Bu C# kodu, sunum temasının yazı tipini nasıl değiştireceğinizi gösterir:

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

Tüm metin kutularındaki yazı tipi güncellenecektir.

{{% alert color="primary" title="TIP" %}} 
PowerPoint yazı tiplerine göz atmak isteyebilirsiniz. 
{{% /alert %}}

## **Tema Arka Plan Stilini Değiştir**

Varsayılan olarak, PowerPoint uygulaması 12 önceden tanımlı arka plan sunar ancak bu 12 arka planın yalnızca 3'ü tipik bir sunumda kaydedilir. 

![todo:image_alt_text](presentation-design_8.png)

Örneğin, PowerPoint uygulamasında bir sunumu kaydettikten sonra, sunumdaki önceden tanımlı arka plan sayısını öğrenmek için bu C# kodunu çalıştırabilirsiniz:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
[FormatScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/) sınıfındaki [BackgroundFillStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) özelliğini kullanarak, PowerPoint temasında arka plan stilini ekleyebilir veya erişebilirsiniz. 
{{% /alert %}}

Bu C# kodu, bir sunum için arka planı nasıl ayarlayacağınızı gösterir:

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**Dizin rehberi**: 0 dolgu yok anlamına gelir. Dizin 1'den başlar.

{{% alert color="primary" title="TIP" %}} 
PowerPoint Arka Planına göz atmak isteyebilirsiniz. 
{{% /alert %}}

## **Tema Efektini Değiştir**

Bir PowerPoint teması genellikle her stil dizisi için 3 değer içerir. Bu diziler, üç etkiye (hafif, orta, yoğun) birleştirilir. Örneğin, bir şekle efektler uygulandığında ortaya çıkan sonuç aşağıdaki gibidir:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme) sınıfındaki 3 özellik ([FillStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/effectstyles)) kullanarak bir temadaki öğeleri değiştirebilirsiniz (PowerPoint'teki seçeneklerden daha esnek bir şekilde).

Bu C# kodu, öğelerin bölümlerini değiştirerek bir tema efektinin nasıl değiştirileceğini gösterir:

```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

Ortaya çıkan dolgu rengi, dolgu türü, gölge efekti vb. değişiklikler:

![todo:image_alt_text](presentation-design_11.png)

## **SSS**

**Bir temayı ana temayı değiştirmeden tek bir slayta uygulayabilir miyim?**

Evet. Aspose.Slides, slayt düzeyinde tema geçersiz kılmalarını destekler, bu sayede yalnızca o slayta yerel bir tema uygulayabilir ve ana temayı (via the [SlideThemeManager](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/slidethememanager/)) aynı tutabilirsiniz.

**Bir temayı bir sunumdan diğerine taşırken en güvenli yöntem nedir?**

[Clone slides](/slides/tr/net/clone-slides/) birlikte ana temalarıyla hedef sunuma kopyalayarak. Bu, orijinal ana temayı, düzenleri ve ilişkili temayı korur, böylece görünüm tutarlı kalır.

**Tüm kalıtım ve geçersiz kılmalardan sonra "etkili" değerleri nasıl görebilirim?**

API'nin ["effective"]( /slides/tr/net/shape-effective-properties/) görünümlerini tema/renk/yazı tipi/efekt için kullanın. Bunlar, ana temanın ve herhangi bir yerel geçersiz kılmanın uygulanmasından sonra çözümlenmiş, son özellikleri döndürür.