---
title: C++'ta Sunum Temalarını Yönet
linktitle: Sunum Teması
type: docs
weight: 10
url: /tr/cpp/presentation-theme/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde sunum temalarını yöneterek, PowerPoint dosyalarını tutarlı marka kimliğiyle oluşturun, özelleştirin ve dönüştürün."
---
## **Giriş**

Bir sunum teması, tasarım öğelerinin özelliklerini tanımlar. Bir sunum teması seçtiğinizde, esasen belirli bir görsel öğe seti ve bunların özelliklerini seçmiş olursunuz.

PowerPoint’te bir tema, renkler, [yazı tipleri](/slides/tr/cpp/powerpoint-fonts/), [arkaplan stilleri](/slides/tr/cpp/presentation-background/) ve efektlerden oluşur.

![theme-constituents](theme-constituents.png)

## **Tema Rengini Değiştir**

PowerPoint teması, slayttaki farklı öğeler için belirli bir renk seti kullanır. Renkleri beğenmezseniz, temaya yeni renkler uygulayarak renkleri değiştirirsiniz. Yeni bir tema rengi seçebilmeniz için Aspose.Slides, [SchemeColor](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) enumerasyonunda değerler sağlar.

Bu C++ kodu, tema için vurgu renginin nasıl değiştirileceğini gösterir:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

Bu şekilde ortaya çıkan rengin etkili değerini belirleyebilirsiniz:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Renk [A=255, R=128, G=100, B=162])
```

Renk değiştirme işlemini daha da göstermek için başka bir öğe oluşturup vurgu rengini (ilk işlemeden) ona atarız. Ardından temadaki rengi değiştiririz:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

Yeni renk, her iki öğeye de otomatik olarak uygulanır.

### **Ek Paletten Tema Rengini Ayarla**

Ana tema rengine (1) parlaklık dönüşümleri uyguladığınızda, ek palet (2) renkleri oluşur. Daha sonra bu tema renklerini ayarlayabilir ve alabilirsiniz.

![additional-palette-colors](additional-palette-colors.png)

**1**- Ana tema renkleri  
**2** - Ek paletten renkler.

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Vurgu 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Vurgu 4, %80 Daha Açık
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Vurgu 4, %60 Daha Açık
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Vurgu 4, %40 Daha Açık
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Vurgu 4, %25 Daha Koyu
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Vurgu 4, %50 Daha Koyu
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **`SchemeColor`'ı `IColorScheme` Renklerine Eşle**

[SchemeColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/schemecolor/) ile çalışırken, aşağıdaki tema rengi değerlerini içerdiğini fark edebilirsiniz:

`Background1`, `Background2`, `Text1` ve `Text2`.

Bununla birlikte, `Presentation::get_MasterTheme()::get_ColorScheme()` [IColorScheme](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/icolorscheme/) döndürür ve ilgili renkleri şu şekilde sunar:

`Dark1`, `Dark2`, `Light1` ve `Light2`.

Bu fark yalnızca adlandırmada vardır. Bu değerler aynı tema rengi yuvalarına işaret eder ve eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dinamik bir dönüşüm `Text`/`Background` ile `Dark`/`Light` arasında yoktur. Bunlar aynı tema renkleri için sadece alternatif isimlerdir.

Bu adlandırma farkı Microsoft Office terminolojisinden gelmektedir. Eski Office sürümleri `Dark 1`, `Light 1`, `Dark 2` ve `Light 2` kullanırken, yeni UI sürümleri aynı yuvaları `Text 1`, `Background 1`, `Text 2` ve `Background 2` olarak gösterir.

## **Tema Yazı Tipini Değiştir**

Aspose.Slides, temalar ve diğer amaçlar için yazı tipleri seçebilmeniz adına bu özel tanımlayıcıları kullanır (PowerPoint’te kullanılanlara benzer):

* **+mn-lt** - Gövde Yazı Tipi Latin (Küçük Latin Yazı Tipi)
* **+mj-lt** - Başlık Yazı Tipi Latin (Büyük Latin Yazı Tipi)
* **+mn-ea** - Gövde Yazı Tipi Doğu Asya (Küçük Doğu Asya Yazı Tipi)
* **+mj-ea** - Gövde Yazı Tipi Doğu Asya (Büyük Doğu Asya Yazı Tipi)

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Bu C++ kodu, tema için Latin yazı tipini nasıl atayacağınızı gösterir:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

Tüm metin kutularındaki yazı tipi güncellenecektir.

{{% alert color="primary" title="TIP" %}} 
PowerPoint yazı tiplerine bakmak isteyebilirsiniz [PowerPoint yazı tipleri](/slides/tr/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Tema Arka Plan Stili Değiştir**

Varsayılan olarak, PowerPoint uygulaması 12 önceden tanımlı arka plan sunar ancak bu 12 arka planın yalnızca 3'ü tipik bir sunumda kaydedilir.

![todo:image_alt_text](presentation-design_8.png)

Örneğin, PowerPoint uygulamasında bir sunumu kaydettikten sonra, bu C++ kodunu çalıştırarak sunumdaki önceden tanımlı arka planların sayısını öğrenebilirsiniz:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
[BackgroundFillStyles](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) özelliğini [FormatScheme](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.theme.i_format_scheme/) sınıfından kullanarak, PowerPoint temasında arka plan stilini ekleyebilir veya erişebilirsiniz. 
{{% /alert %}}

Bu C++ kodu, bir sunum için arka planı nasıl ayarlayacağınızı gösterir:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Dizin kılavuzu**: 0 doldurma yok demektir. Dizin 1'den başlar.

{{% alert color="primary" title="TIP" %}} 
PowerPoint arka planına bakmak isteyebilirsiniz [PowerPoint Arka Planı](/slides/tr/cpp/presentation-background/).
{{% /alert %}}

## **Tema Efektini Değiştir**

PowerPoint teması genellikle her stil dizisi için 3 değer içerir. Bu diziler, üç etkiye: hafif, orta ve yoğun birleştirilir. Örneğin, bu bir şekle etkiler uygulandığında elde edilen sonuçtur:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.theme.i_format_scheme/) sınıfından 3 özelliği ([FillStyles](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) kullanarak, bir temadaki öğeleri değiştirebilirsiniz (PowerPoint'teki seçeneklerden daha esnek bir şekilde).

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

Sonuçta oluşan dolgu rengi, dolgu türü, gölge efekti vb. değişiklikler:

![todo:image_alt_text](presentation-design_11.png)

## **SSS**

**Bir tek slayta, master'ı değiştirmeden tema uygulayabilir miyim?**

Evet. Aspose.Slides, slayt seviyesinde tema geçersiz kılmalarını destekler; böylece sadece o slayta yerel bir tema uygulayabilir, master temayı aynı tutabilirsiniz (via the [SlideThemeManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/slidethememanager/)).

**Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?**

[Slide'ları klonla](/slides/tr/cpp/clone-slides/) ve master'larını hedef sunuma taşıyarak. Bu, orijinal master, düzenler ve ilgili temayı korur, böylece görünüm tutarlı kalır.

**Tüm kalıtım ve geçersiz kılmalar sonrasında "etkili" değerleri nasıl görebilirim?**

API'nin tema/rengi/yazı tipi/efekt için ["effective" görünümlerini](/slides/tr/cpp/shape-effective-properties/) kullanın. Bu, master ve yerel geçersiz kılmalar uygulandıktan sonra çözümlenmiş, nihai özellikleri döndürür.