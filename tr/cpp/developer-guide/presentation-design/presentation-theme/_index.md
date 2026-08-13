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
description: "C++ için Aspose.Slides içinde sunum temalarını yöneterek, tutarlı marka kimliğiyle PowerPoint dosyalarını oluşturun, özelleştirin ve dönüştürün."
---
## **Giriş**

Bir sunum teması, tasarım öğelerinin özelliklerini tanımlar. Bir sunum teması seçtiğinizde, esasen belirli bir görsel öğe seti ve bu öğelerin özelliklerini seçmiş olursunuz.

PowerPoint’te bir tema, renkler, [yazı tipleri](/slides/tr/cpp/powerpoint-fonts/), [arkaplan stilleri](/slides/tr/cpp/presentation-background/) ve efektlerden oluşur.

![theme-constituents](theme-constituents.png)

## **Tema Rengini Değiştir**

Bir PowerPoint teması, slayt üzerindeki farklı öğeler için belirli bir renk seti kullanır. Renkleri beğenmezseniz, temaya yeni renkler uygulayarak renkleri değiştirirsiniz. Yeni bir tema rengi seçmenizi sağlamak için Aspose.Slides, [SchemeColor](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) enumarasyonunda değerler sunar.

Bu C++ kodu, bir temanın vurgu rengini nasıl değiştireceğinizi gösterir:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

Bu şekilde sonuçtaki rengin etkili değerini belirleyebilirsiniz:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto fillEffective = shape->get_FillFormat()->GetEffective();

Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Renk [A=255, R=128, G=100, B=162])
```

Renk değişim işlemini daha iyi göstermek için başka bir öğe oluşturur ve başlangıçta yapılan vurgu rengini ona atarız. Ardından temadaki rengi değiştiririz:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();

auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);

otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

Yeni renk, her iki öğeye de otomatik olarak uygulanır.

### **Ek Bir Paletten Tema Rengini Ayarla**

Ana tema rengine (1) parlaklık dönüşümleri uygulandığında, ek paletten (2) renkler oluşur. Bu tema renklerini ayarlayabilir ve alabilirsiniz.

![additional-palette-colors](additional-palette-colors.png)

**1**- Ana tema renkleri  

**2**- Ek paletten gelen renkler.

Bu C++ kodu, ek palet renklerinin ana tema renginden elde edilip şekillerde nasıl kullanılacağını gösterir:

```c++
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Vurgu 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Vurgu 4, Daha Açık %80
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Vurgu 4, Daha Açık %60
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Vurgu 4, Daha Açık %40
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Vurgu 4, Daha Koyu %25
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Vurgu 4, Daha Koyu %50
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **`SchemeColor`ı `IColorScheme` Renklerine Eşle**

[SchemeColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/schemecolor/) ile çalışırken, aşağıdaki tema rengi değerlerini içerdiğini görebilirsiniz:

`Background1`, `Background2`, `Text1` ve `Text2`.

Ancak `Presentation::get_MasterTheme()::get_ColorScheme()` [IColorScheme](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/icolorscheme/) döndürür ve ilgili renkleri şu şekilde sunar:

`Dark1`, `Dark2`, `Light1` ve `Light2`.

Bu fark sadece adlandırmadadır. Bu değerler aynı tema rengi yuvalarına işaret eder ve eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` ile `Dark`/`Light` arasında dinamik bir dönüşüm yoktur. Aynı tema renkleri için yalnızca alternatif adlardır.

Bu adlandırma farkı Microsoft Office terminolojisinden kaynaklanır. Eski Office sürümleri `Dark 1`, `Light 1`, `Dark 2` ve `Light 2` kullanırken, yeni arayüz sürümleri aynı yuvaları `Text 1`, `Background 1`, `Text 2` ve `Background 2` olarak gösterir.

## **Tema Yazı Tipini Değiştir**

Temalar ve diğer amaçlar için yazı tipleri seçmenizi sağlamak amacıyla Aspose.Slides, PowerPoint’te kullanılanlara benzer özel tanımlayıcılar kullanır:

* **+mn-lt** – Gövde Yazı Tipi Latin (Küçük Latin Yazı Tipi)
* **+mj-lt** – Başlık Yazı Tipi Latin (Büyük Latin Yazı Tipi)
* **+mn-ea** – Gövde Yazı Tipi Doğu Asya (Küçük Doğu Asya Yazı Tipi)
* **+mj-ea** – Başlık Yazı Tipi Doğu Asya (Büyük Doğu Asya Yazı Tipi)

Bu C++ kodu, Latin yazı tipini bir tema öğesine nasıl atayacağınızı gösterir:

```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Bu C++ kodu, sunum teması yazı tipini nasıl değiştireceğinizi gösterir:

```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

Tüm metin kutularındaki yazı tipi güncellenecektir.

{{% alert color="info" title="TIP" %}} 
İlgili bilgilere bakmak isteyebilirsiniz: [PowerPoint yazı tipleri](/slides/tr/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Tema Arkaplan Stilini Değiştir**

Varsayılan olarak PowerPoint uygulaması 12 önceden tanımlı arkaplan sunar, ancak tipik bir sunumda bu 12 arkaplandan yalnızca 3’ü kaydedilir.

![todo:image_alt_text](presentation-design_8.png)

Örneğin, PowerPoint uygulamasında bir sunumu kaydettikten sonra, sunumdaki önceden tanımlı arkaplan sayısını öğrenmek için bu C++ kodunu çalıştırabilirsiniz:

```c++
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Theme;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
[BackgroundFillStyles](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) özelliğini [FormatScheme](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.theme.i_format_scheme/) sınıfından kullanarak bir PowerPoint temasında arkaplan stilini ekleyebilir veya erişebilirsiniz.
{{% /alert %}}

Bu C++ kodu, bir sunumun arkaplanını nasıl ayarlayacağınızı gösterir:

```c++
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Dizin rehberi**: 0 doldurma yok anlamına gelir. Dizin 1’den başlar.

{{% alert color="info" title="TIP" %}} 
İlgili bilgilere bakmak isteyebilirsiniz: [PowerPoint Arkaplan](/slides/tr/cpp/presentation-background/).
{{% /alert %}}

## **Tema Efektini Değiştir**

Bir PowerPoint teması genellikle her stil dizisi için 3 değer içerir. Bu diziler, hafif, orta ve yoğun olmak üzere 3 etkiye birleştirilir. Örneğin, bu etkiler belirli bir şekle uygulandığında ortaya çıkan sonuç şu şekildedir:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.theme.i_format_scheme/) sınıfındaki 3 özellik ([FillStyles](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) sayesinde bir temadaki öğeleri (PowerPoint’teki seçeneklerden daha esnek bir biçimde) değiştirebilirsiniz.

Bu C++ kodu, tema efektini öğe parçalarını değiştirerek nasıl değiştireceğinizi gösterir:

```c++
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");

pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

Dolayısıyla doldurma rengi, doldurma tipi, gölge efekti vb. üzerindeki değişiklikler şöyle görünür:

![todo:image_alt_text](presentation-design_11.png)

## **SSS**

### Tek bir slayda, ana temayı değiştirmeden tema uygulayabilir miyim?

Evet. Aspose.Slides, slayt düzeyinde tema geçersiz kılmalarını destekler; böylece sadece o slayda yerel bir tema uygulayabilir, ana temayı koruyabilirsiniz ([SlideThemeManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/slidethememanager/) aracılığıyla).

### Bir temayı bir sunumdan diğerine en güvenli şekilde nasıl taşıyabilirim?

[Slaytları klonlayın](/slides/tr/cpp/clone-slides/) ve ana temaları hedef sunuma aktarın. Bu, orijinal ana temayı, düzenleri ve ilişkili temayı korur, böylece görünüm tutarlı kalır.

### Tüm kalıtım ve geçersiz kılmalar sonrası “etkili” değerleri nasıl görebilirim?

Tema/rengi/yazı tipi/efekti için API'nin ["effective" görünümlerini](/slides/tr/cpp/shape-effective-properties/) kullanın. Bu, ana tema ve yerel geçersiz kılmalar uygulandıktan sonra çözümlenmiş, nihai özellikleri döndürür.