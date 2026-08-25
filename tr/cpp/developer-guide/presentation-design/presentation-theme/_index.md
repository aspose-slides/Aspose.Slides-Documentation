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
description: "C++ için Aspose.Slides'te ana sunum temalarını yöneterek, tutarlı marka kimliğiyle PowerPoint dosyaları oluşturun, özelleştirin ve dönüştürün."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, dolgu, çizgi ve efektlerden oluşan koordineli bir set tanımlar. Tema farkındalığına sahip nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur, böylece bir tema değişikliği birden çok nesneyi aynı anda güncelleyebilir.

Aspose.Slides içinde, sunum düzeyindeki tema, [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_mastertheme/) aracılığıyla kullanılabilir. Bir sunum ayrıca daha düşük seviyelerde tema geçersiz kılmaları içerebilir. Bir master, [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) aracılığıyla sunum temasını geçersiz kılabilir, bir layout veya bireysel slayt ise [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) kullanabilir. Pratikte, bir slayt için etkili tema, bu kalıtım zinciri üzerinden çözülür: sunum teması, master geçersiz kılması, layout geçersiz kılması ve slayt geçersiz kılması.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersiz kılmalar çözüldükten sonra etkili değerleri okuma.

## **Temayı İncele**

[MasterTheme](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/mastertheme/) nesnesi, temanın [get_ColorScheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) ve [get_FormatScheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) metodlarını ortaya çıkarır. Bu koleksiyonları değiştirmeden önce incelemek, bir sunum dış bir kaynaktan geldiğinde özellikle yararlıdır; çünkü stil girişlerinin sayısı ve içeriği değişkenlik gösterebilir.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada kaç tane arka plan, dolgu, çizgi ve efekt stilinin depolandığını raporlar:

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

Bir dosya birden çok master kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsaymayın. Slayt ile ilişkili masterı inceleyin ve layout ya da slayt geçersiz kılmaları mevcut olduğunda daha sonra bu makalede gösterilen etkili tema iş akışını kullanın.

## **Tema Renklerini Değiştir**

Tema farkındalığına sahip dolgu, çizgi ve metinler, [SchemeColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/schemecolor/) enum'undaki mantıksal bir renge başvurabilir. Tema'nın [IColorScheme](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/icolorscheme/) içindeki ilgili girişi değiştirdiğinizde, hâlâ o tema rengine başvuran tüm nesneler yeni değere göre çözülür. Doğrudan RGB rengi kullanan nesneler, tema rengi güncellemesinden etkilenmez.

Aşağıdaki uçtan uca örnek, `Accent4` kullanan bir şekil oluşturur, temanın `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili dolgu rengini yazdırır:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

Dikdörtgen `Accent4`e bağlı kalmaya devam ettiğinden, tema değiştirildiğinde görünür rengi kırmızı olur. Şekilde şema rengini doğrudan bir renkle değiştirirseniz, sonraki `Accent4` değişiklikleri artık o dolguya etki etmez.

### **Ek Paletten Renkleri Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar türetmek için renk dönüşümleri uygular. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/colortransformoperation/) üzerinden sunar.

![Ana tema renkleri ve ek paletten türetilen daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** - Ana tema renkleri.  
**2** - Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `Accent4` temelli altı dikdörtgen oluşturur, beşine parlaklık dönüşümleri uygular ve sonucu kaydeder:

```cpp
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
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

Bu varyantlar tema rengine dayalı kalır. `Accent4` daha sonra değişirse, dönüştürülmüş renkler yeni `Accent4` değerinden yeniden hesaplanır.

### **`SchemeColor` Değerlerini `IColorScheme` Yuvalarına Eşle**

[SchemeColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/schemecolor/) enum'ı `Text1`, `Background1`, `Text2` ve `Background2` değerlerini kullanırken, [IColorScheme](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/icolorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak sunar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştir**

Bir tema yazı tipi şeması, başlıklar için ana yazı tipi kümesi ve gövde metni için ikincil bir yazı tipi kümesi içerir. [FontScheme::get_Major()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/fontscheme/get_major/) ve [FontScheme::get_Minor()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/fontscheme/get_minor/) metodları bu kümeleri ortaya çıkarır.

PowerPoint uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmede kullanılabilir:

* `+mn-lt` – Gövde Yazı Tipi Latin (Minor Latin Font)
* `+mj-lt` – Başlık Yazı Tipi Latin (Major Latin Font)
* `+mn-ea` – Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
* `+mj-ea` – Başlık Yazı Tipi Doğu Asya (Major East Asian Font)

Aşağıdaki örnek, ana Latin tema yazı tipini kullanan bir başlık ve ikincil Latin tema yazı tipini kullanan bir gövde satırı oluşturur. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

Başlık ana yazı tipini, gövde metni ise ikincil yazı tipini izler. Tema tanımlayıcısı yerine açıkça belirtilmiş bir yazı tipi adı varsa, tema yazı tipi şeması değiştiğinde otomatik olarak geçmez.

Ana ve ikincil yazı tipi koleksiyonları ayrıca Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemeleri içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Script‑Specific Theme Fonts](/slides/tr/cpp/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="İpucu" %}}

Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/cpp/powerpoint-fonts/) sayfasına bakın.

{{% /alert %}}

## **Bir Temayı Kopyala veya Uygula**

İki yaygın iş akışı vardır ve farklı problemleri çözerler.

### **Kaynak Temayı Slaytları Taşırken Koru**

Bir slaytı başka bir sunuma taşımak ve orijinal tasarımını korumak istiyorsanız, kaynak masterı hedef sunuma [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslidecollection/addclone/) ile klonlayın, ardından slaytı [ISlideCollection::AddClone()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) ve klonlanmış master ile klonlayın. Bu, masterı, layoutlarını ve ilişkili temayı bir arada taşır.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto sourceSlide = source->get_Slide(0);
auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);
target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

Bu, kaynak slaytın hedefte aynı görünmesi gerektiğinde tercih edilen iş akışıdır. İlişkili olmayan bir hedef master üzerine sadece içeriği klonlamak, tema‑türetilen renkleri, yazı tiplerini, arka planları ve efektleri değiştirebilir.

### **Tema Değerlerini Mevcut Bir Slayta Uygula**

Hedef slayt mevcut master ve layout üzerinde kalmalıysa, kaynak temadan slayt‑düzeyinde bir geçersiz kılma başlatın. [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) ve [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) metodları üç ana tema bileşenini geçersiz kılmaya kopyalar.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

Bu, diğer slaytların miras aldığı temayı değiştirmeden sadece bu slaytın temasını değiştirir. Yerel geçersiz kılmayı kaldırıp miras alınan değerlere dönmek için [OverrideTheme::Clear()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/overridetheme/clear/) çağırın.

### **Bir Layout İçin Tema Geçersiz Kılmasını Uygula**

Layout‑düzeyindeki geçersiz kılma, o layoutu kullanan slaytlara uygulanır; yalnızca belirli bir slayt kendi geçersiz kılmasına sahipse farklı davranır. Aynı başlatma metodları, layoutun [IOverrideThemeManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/ioverridethememanager/) üzerinden kullanılabilir:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

Birçok layout ve slayt aynı temel tasarımı paylaşmalıysa master veya sunum‑düzeyinde tema kullanın; bir layout ailesi farklı stil gerektiriyorsa layout geçersiz kılması, yalnızca gerçek istisnalar için slayt geçersiz kılması kullanın. Aşırı slayt‑düzeyinde geçersiz kılmalar, daha sonraki küresel tema değişikliklerini öngörmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelle**

Temanın arka plan dolgu stilleri, [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) içinde depolanır. PowerPoint, UI’da temalı dolguları tema renkleri ve diğer stil referanslarıyla birleştirebildiği için bu koleksiyonda fiziksel olarak depolanan dolgu tanımlarından daha fazla arka plan seçeneği sunabilir.

![PowerPoint sunum teması için arka plan stil galerisii](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce, depolanmış koleksiyonu ve mevcut [Background::get_StyleIndex()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/background/get_styleindex/) değerini inceleyin. `StyleIndex` temalı dolgu yoksa `0` kullanır; pozitif değerler tema arka plan‑stil referanslarıdır. Bu, `idx_get(0)` ile bir C++ koleksiyonunu doğrudan indekslemenin (burada `0` ilk depolanmış öğeyi gösterir) farklıdır. Her sunumun aynı sayıda arka plan dolgu stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek, mevcut arka plan dolgu sayısını raporlar, ilk mastera temalı bir arka plan referansı atar ve sunumu kaydeder:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);
    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

Görünür sonuç, masterın başvurduğu tema girişi ve layout ya da slayt düzeyindeki olası arka plan geçersiz kılmalarına bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca master arka planını değiştirmek o slaytı etkilemez. Kalıtım uygulandıktan sonra nihai arka planı öğrenmeniz gerektiğinde [Background::GetEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/background/geteffective/) kullanın.

{{% alert color="warning" title="Uyarı" %}}

`StyleIndex`i sıfır tabanlı bir koleksiyon indeksi gibi işlemeyin. Ayrıca bir dosyadan bir stil numarasını sabit kodlayıp başka bir dosyada aynı görünüme sahip olacağını varsamayın; tema stil tanımları sunuma özgüdür.

{{% /alert %}}

{{% alert color="info" title="İpucu" %}}

Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için [Presentation Background](/slides/tr/cpp/presentation-background/) bölümüne bakın.

{{% /alert %}}

## **Tema Efektlerini Güncelle**

Bir tema format şeması, ayrı ayrı [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/formatscheme/get_linestyles/) ve [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) koleksiyonlarını içerir. Tipik Office temaları genellikle görsel olarak ince, orta ve yoğun biçimlendirmelere karşılık gelen üç ana stil girdisi barındırır, ancak kod her koleksiyonu sabit bir sayı varsaymak yerine incelemelidir.

![Aynı şekle uygulanmış ince, orta ve yoğun tema efektleri](presentation-design_10.png)

C++'ta bu koleksiyonlara eriştiğinizde, koleksiyon indeksi sıfır‑tabanlıdır: `idx_get(0)` ilk depolanmış stil, `idx_get(2)` üçüncüdür. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapestyle/) aracılığıyla ortaya çıkar. Bir tema stilini değiştirmek, o tema stiline başvuran şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girdilerinin mevcut olduğunu doğrular, ilk çizgi stilini değiştirir, üçüncü dolgu stilini değiştirir, üçüncü efekt stiline dış gölge ekler ve sonucu kaydeder:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
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
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

Bu yuvalara başvuran şekiller için, ilk tema çizgi stili kırmızı, üçüncü tema dolgu stili katı orman yeşili ve üçüncü efekt stili 10 puan mesafeli dış gölge kazanır. Tam görsel sonuç hâlâ hangi stil yuvalarının her şekil tarafından referans alındığına ve doğrudan biçimlendirmenin temayı geçersiz kılıp kılmadığına bağlıdır.

![Satır, dolgu ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Etkili Tema Değerlerini Oku**

Ham tema nesneleri belirli bir seviyede tanımlananları gösterir. Etkili değerler, kalıtım ve yerel geçersiz kılmalar çözüldükten sonra bir slayt ya da şeklin gerçekte ne kullandığını gösterir. Bir slayt için [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) çağırın. Bir arka plan için [Background::GetEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/background/geteffective/), bir dolgu için ise [FillFormat::GetEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/geteffective/) kullanın.

Aşağıdaki örnek, bir slayttan etkili temayı, arka planı ve ilk şekil dolgusunu okur:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

Rendere diagnostikleri, doğrulama ve karşılaştırmalar için etkili verileri kullanın. Yalnızca [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_mastertheme/) incelediğinizde, final görünümü değiştiren bir master, layout, slayt ya da şekil geçersiz kılmasını kaçırabilirsiniz.

## **SSS**

**Bir slayta masterı değiştirmeden tek bir slayta tema uygulayabilir miyim?**

Evet. Slaydın [IOverrideThemeManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/ioverridethememanager/) kullanın ve geçersiz temaını başlatın. Değişiklik yalnızca o slayda yerel kalır; diğer slaytlar mevcut temalarını miras almaya devam eder.

**Bir temayı bir sunumdan diğerine taşırken en güvenli yol nedir?**

Bir slaytı taşırken ve kaynak görünümünü korurken, kaynak masterı hedefe [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslidecollection/addclone/) ile klonlayın ve ardından slaytı aynı master ile [ISlideCollection::AddClone()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) kullanarak klonlayın. Bu, masterı, layoutları ve temayı birlikte tutar.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt ya da layout teması için [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) ve [Background::GetEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/background/geteffective/) ve [FillFormat::GetEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/geteffective/) gibi ilgili etkili‑veri metodlarını kullanın. Bu API'ler, kalıtım ve geçersiz kılmalar uygulandıktan sonra çözümlenmiş değerleri döndürür.