---
title: C++'ta Sunum Temalarını Yönetme
linktitle: Sunum Teması
type: docs
weight: 10
url: /tr/cpp/presentation-theme/
keywords:
- PowerPoint teması
- sunum teması
- slayt teması
- tema ayarla
- temayı değiştir
- temayı yönet
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
description: "Aspose.Slides for C++'ta tutarlı markalama ile PowerPoint dosyaları oluşturmak, özelleştirmek ve dönüştürmek için ana sunum temaları."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, dolgu, çizgi ve efektlerden oluşan koordineli bir set tanımlar. Tema farkındalığı olan nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur, böylece bir tema değişikliği birden çok nesneyi aynı anda güncelleyebilir.

Aspose.Slides içinde, sunum seviyesindeki tema [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_mastertheme/) aracılığıyla kullanılabilir. Bir sunum ayrıca daha alt seviyelerde tema geçersiz kılmalarını içerebilir. Bir master, temayı [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) ile geçersiz kılabilir, bir düzen veya tek bir slayt ise [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) kullanabilir. Pratikte, bir slayt için geçerli tema, bu kalıtım zinciri aracılığıyla çözülür: sunum teması, master geçersiz kılması, düzen geçersiz kılması ve slayt geçersiz kılması.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersizlikler çözüldükten sonra geçerli değerleri okuma.

## **Tema İnceleme**

[MasterTheme](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/mastertheme/) nesnesi temanın [get_ColorScheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), ve [get_FormatScheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) yöntemlerini ortaya koyar. Bu koleksiyonları değiştirmeden önce incelemek, bir sunum dış bir kaynaktan geldiğinde stil girişlerinin sayısı ve içeriği değişebileceği için özellikle faydalıdır.

Aşağıdaki örnek ana tema özelliklerini okur ve temada kaç adet arka plan, dolgu, çizgi ve efekt stilinin depolandığını raporlar:

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

Bir dosya birden fazla master içeriyorsa, her slaytın aynı geçerli temaya sahip olduğunu varsaymayın. Slayt ile ilişkili master'ı inceleyin ve düzen ya da slayt geçersizlikleri mevcut olduğunda bu makalede daha sonra gösterilen geçerli‑tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema farkındalığı olan dolgular, çizgiler ve metinler, [SchemeColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/schemecolor/) enumundan bir mantıksal renge başvurabilir. Temanın [IColorScheme](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/icolorscheme/) içindeki ilgili girişi değiştirdiğinizde, hâlâ o tema rengine başvuran tüm nesneler yeni değerle çözülür. Doğrudan bir RGB rengi kullanan nesneler tema‑renk güncellemesinden etkilenmez.

Aşağıdaki uçtan‑uca örnek `Accent4` kullanan bir şekil oluşturur, temanın `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, tekrar açar ve geçerli dolgu rengini yazdırır:

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

Dikdörtgen `Accent4` ile bağlantılı kaldığı için tema değiştirildikten sonra görünür rengi kırmızı olur. Şekildeki şema rengini doğrudan bir renkle değiştirirseniz, sonraki `Accent4` değişiklikleri bu dolguyu artık etkilemez.

### **Ek Paletten Renkleri Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar türetmek için renk dönüşümleri uygular. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/colortransformoperation/) aracılığıyla sunar.

![Ana tema renkleri ve ek paletten oluşturulan daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** - Ana tema renkleri.  
**2** - Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek `Accent4` temelinde altı dikdörtgen oluşturur, beş tanesine parlaklık dönüşümleri uygular ve sonucu kaydeder:

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

### **`SchemeColor` Değerlerini `IColorScheme` Yuvalarına Eşleme**

[SchemeColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/schemecolor/) enumu `Text1`, `Background1`, `Text2` ve `Background2` değerlerini kullanırken, [IColorScheme](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/icolorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak sunar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için bir ana (major) yazı tipi seti ve gövde metni için bir yan (minor) yazı tipi seti içerir. [FontScheme::get_Major()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/fontscheme/get_major/) ve [FontScheme::get_Minor()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/fontscheme/get_minor/) yöntemleri bu setleri ortaya koyar.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmede kullanılabilir:

* `+mn-lt` - Gövde Yazı Tipi Latin (Küçük Latin Yazı Tipi)
* `+mj-lt` - Başlık Yazı Tipi Latin (Büyük Latin Yazı Tipi)
* `+mn-ea` - Gövde Yazı Tipi Doğu Asya (Küçük Doğu Asya Yazı Tipi)
* `+mj-ea` - Başlık Yazı Tipi Doğu Asya (Büyük Doğu Asya Yazı Tipi)

Aşağıdaki örnek bir başlık oluşturur; başlık ana Latin tema yazı tipini, bir gövde satırı yan Latin tema yazı tipini kullanır. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

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

Başlık ana yazı tipini, gövde metni ise yan yazı tipini izler. Tema tanımlayıcısı yerine açıkça bir yazı tipi adı verilmiş metin, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

{{% alert color="info" title="Tip" %}}
Sunum yazı tipleri hakkında daha fazla bilgi için, [PowerPoint Fonts](/slides/tr/cpp/powerpoint-fonts/) sayfasına bakın.
{{% /alert %}}

## **Bir Temayı Kopyalama veya Uygulama**

İki yaygın iş akışı vardır ve bunlar farklı problemleri çözer.

### **Kaynak Temasını Slayt Taşıdığınızda Korumak**

Bir slaytı başka bir sunuma taşıyıp özgün tasarımını korumak istiyorsanız, kaynak master'ı hedef sunuma [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslidecollection/addclone/) ile klonlayın, ardından slaytı [ISlideCollection::AddClone()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) ve klonlanmış master ile klonlayın. Bu, master'ı, düzenlerini ve ilişkili temayı birlikte taşır.

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

Kaynak slaytın hedefte aynı görünmesi gerektiğinde tercih edilen iş akışıdır. İçeriği alakasız bir hedef master üzerine sadece klonlamak, tema‑tahrikli renkleri, yazı tiplerini, arka planları ve efektleri değiştirebilir.

### **Mevcut Bir Slayta Tema Değerlerini Uygulama**

Hedef slayt mevcut master ve düzeninde kalmalıysa, kaynak temadan bir slayt‑seviyesi geçersizlik başlatın. [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) ve [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) yöntemleri üç ana tema bileşenini geçersiz kılmaya kopyalar.

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

Bu, o slaytın kullandığı temayı diğer slaytların kalıtılan temasını değiştirmeden değiştirir. Yerel geçersiz kılmayı kaldırıp kalıtılan değerlere dönmek için [OverrideTheme::Clear()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/overridetheme/clear/) çağırın.

### **Bir Düzen İçin Tema Geçersiz Kılmasını Uygulama**

Düzen‑seviyesi bir geçersizlik, özel bir slayt kendi geçersizliğine sahip değilse o düzeni kullanan slaytlara uygulanır. Aynı başlatma yöntemleri düzenin [IOverrideThemeManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/ioverridethememanager/) üzerinden kullanılabilir:

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

Bir master veya sunum‑seviyesi tema, birçok düzen ve slayt aynı temel tasarımı paylaşmalıysa kullanın; bir düzen geçersiz kılması, bir düzen ailesinin farklı stilizasyon ihtiyacı olduğunda; ve bir slayt geçersiz kılması yalnızca gerçek istisnalar için. Aşırı slayt‑seviyesi geçersizlikler, daha sonraki küresel tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelleme**

Temanın arka plan doldurmaları [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) içinde depolanır. PowerPoint, UI'da temanın doldurmalarını tema renkleri ve diğer stil referanslarıyla birleştirebildiği için bu koleksiyonda fiziksel olarak depolanan dolgu tanımlarından daha fazla arka plan seçeneği sunabilir.

![Sunum teması için PowerPoint arka plan stil galerisi](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce, depolanmış koleksiyonu ve geçerli [Background::get_StyleIndex()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/background/get_styleindex/) değerini inceleyin. `StyleIndex` temalı bir dolgu olmadığında `0` kullanır; pozitif değerler tema arka plan‑stil referanslarıdır. Bu, `idx_get(0)` ile doğrudan bir C++ koleksiyonunu indekslemeden farklıdır; burada `0` ilk depolanmış öğeyi ifade eder. Her sunumun aynı sayıda arka plan doldurma stili içerdiğini varsaymayın.

Aşağıdaki örnek kullanılabilir arka plan dolgu sayısını raporlar, ilk master'a temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünür sonuç, master tarafından referans alınan tema girdisine ve düzen ya da slayt seviyesindeki arka plan geçersizliklerine bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca master arka planını değiştirmek o slaytı etkilemeyebilir. Kalıtım uygulandıktan sonra nihai arka planı öğrenmeniz gerektiğinde [Background::GetEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/background/geteffective/) kullanın.

{{% alert color="warning" title="Warning" %}}
`StyleIndex`i sıfır‑tabanlı bir koleksiyon indeksi gibi işlemeyin. Ayrıca bir dosyadan sabit bir stil numarasını kodlayıp başka bir dosyada aynı görünümü sağlayacağını varsımaktan kaçının; tema stil tanımları sunuma özeldir.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için, [Presentation Background](/slides/tr/cpp/presentation-background/) sayfasına bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema format şeması ayrı ayrı [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/formatscheme/get_linestyles/) ve [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) koleksiyonlarını içerir. Tipik Office temaları genellikle görsel olarak hafif, orta ve yoğun biçimlendirmeye karşılık gelen üç temel stil girdisi barındırır, ancak kod sabit bir sayıyı varsaymak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanan hafif, orta ve yoğun tema efektleri](presentation-design_10.png)

C++ içinde bu koleksiyonlara eriştiğinizde, koleksiyon indeksi sıfır‑tabanlıdır: `idx_get(0)` ilk depolanmış stil, `idx_get(2)` üçüncüdür. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapestyle/) aracılığıyla ortaya konur. Bir tema stilini değiştirmek, o tema stiline başvuran şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek gerekli stil girdilerinin mevcut olduğunu kontrol eder, ilk çizgi stilini değiştirir, üçüncü dolgu stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

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

Bu yuvalara başvuran şekiller için, ilk tema çizgi stili kırmızı, üçüncü tema dolgu stili katı orman yeşili, üçüncü efekt stili ise 10 puan mesafeli bir dış gölge kazanır. Tam görsel sonuç, her şeklin hangi stil yuvalarına referans verdiğine ve doğrudan biçimlendirme temayı geçersiz kılıyor mu olduğuna bağlıdır.

![Satır, dolgu ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Geçerli Tema Değerlerini Okuma**

Ham tema nesneleri belirli bir seviyede tanımlananları gösterir. Geçerli değerler, bir slayt ya da şeklin kalıtım ve yerel geçersizlikler çözüldükten sonra gerçekte ne kullandığını gösterir. Bir slayt için [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) çağırın. Bir arka plan için [Background::GetEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/background/geteffective/), bir dolgu için ise [FillFormat::GetEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/geteffective/) kullanın.

Aşağıdaki örnek bir slayttan geçerli tema, arka plan ve ilk şekil dolgusunu okur:

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

Rendring tanılamaları, doğrulama ve karşılaştırmalar için geçerli verileri kullanın. Yalnızca [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_mastertheme/) incelemeniz, nihai görünümü değiştiren bir master, düzen, slayt veya şekil geçersizliğini kaçırmanıza neden olabilir.

## **SSS**

**Bir tema, master'ı değiştirmeden tek bir slayta uygulanabilir mi?**  
Evet. Slaytın [IOverrideThemeManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/ioverridethememanager/) kullanın ve geçersizlik temasını başlatın. Değişiklik yalnızca o slayda yerel olarak uygulanır; diğer slaytlar mevcut temalarını miras almaya devam eder.

**Bir temayı bir sunumdan diğerine taşırken en güvenli yol nedir?**  
Bir slaytı taşırken ve kaynak görünümünü korurken, kaynak master'ı hedefe klonlayın ve ardından slaytı o master ile [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslidecollection/addclone/) ve [ISlideCollection::AddClone()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) kullanarak klonlayın. Bu, master, düzenler ve temayı birlikte tutar.

**Kalıtım ve geçersizliklerden sonra geçerli değerleri nasıl görebilirim?**  
Bir slayt veya düzen teması için [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) ve [Background::GetEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/background/geteffective/) ve [FillFormat::GetEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/geteffective/) gibi ilgili geçerli‑veri yöntemlerini kullanın. Bu API'ler, kalıtım ve geçersizlikler uygulandıktan sonra çözülen değerleri döndürür.