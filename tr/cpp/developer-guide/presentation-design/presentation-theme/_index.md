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
- tema değiştir
- tema yönet
- harici tema
- THMX
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
description: "C++ için Aspose.Slides'te ana sunum temalarını, PowerPoint dosyalarını tutarlı bir markalama ile oluşturmak, özelleştirmek ve dönüştürmek için kullanın."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, doldurmalar, çizgiler ve efektler gibi koordineli bir set tanımlar. Tema‑bilgili nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu paylaşılan tanımları referans alır; böylece bir tema değişikliği, birçok nesneyi bir kerede güncelleyebilir.

Aspose.Slides içinde sunum‑seviyesi tema, [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_mastertheme/) aracılığıyla kullanılabilir. Bir sunum ayrıca daha düşük seviyelerde tema geçersiz kılmalarını içerebilir. Bir master, [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) ile sunum temasını geçersiz kılabilirken, bir düzen veya tek bir slayt, [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) kullanabilir. Pratikte, bir slayt için etkili tema şu kalıtım zinciri üzerinden çözülür: sunum teması, master geçersiz kılma, düzen geçersiz kılma ve slayt geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersiz kılmalar çözüldükten sonra etkili değerleri okuma.

## **Bir Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/mastertheme/) nesnesi, temanın [get_ColorScheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) ve [get_FormatScheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) metodlarını ortaya çıkarır. Bu koleksiyonları değiştirmeden önce incelemek, sunum dış bir kaynaktan geldiğinde stil girişlerinin sayısı ve içeriği değişebileceği için özellikle yararlıdır.

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

Bir dosya birden çok master kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsaymayın. Slaytla ilişkili masterı inceleyin ve düzen veya slayt geçersiz kılmaları mevcut olduğunda bu makalenin sonraki bölümlerinde gösterilen etkili‑tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema‑bilgili dolgular, çizgiler ve metinler, [SchemeColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/schemecolor/) adlı mantıksal bir renge referans verebilir. Temanın [IColorScheme](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/icolorscheme/) içindeki ilgili girişi değiştirdiğinizde, hâlâ o tema rengini referans alan tüm nesneler yeni değere karşı çözülür. Doğrudan RGB rengi kullanan nesneler tema‑renk güncellemesinden etkilenmez.

Aşağıdaki uçtan‑uca örnek, `Accent4` kullanan bir şekil oluşturur, temadaki `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili dolgu rengini yazdırır:

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

Dikdörtgen `Accent4` ile bağlı kaldığından, tema değiştirildiğinde görünür rengi kırmızı olur. Şekildeki şema rengini doğrudan bir renkle değiştirirseniz, sonraki `Accent4` değişiklikleri o dolguyu etkilemez.

### **Ek Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar türetmek için renk dönüşümleri uygular. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/colortransformoperation/) aracılığıyla sunar.

![Ana tema renkleri ve ek paletten üretilen daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** – Ana tema renkleri.  
**2** – Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `Accent4` temelinde altı dikdörtgen oluşturur, beşine parlaklık dönüşümleri uygular ve sonucu kaydeder:

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

### **`SchemeColor` Değerlerini `IColorScheme` Slotlarına Eşleme**

[SchemeColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/schemecolor/) enumu `Text1`, `Background1`, `Text2` ve `Background2` kullanırken, [IColorScheme](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/icolorscheme/) aynı tema slotlarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak ortaya koyar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema slotları için alternatif adlardır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Tema yazı tipi şeması, başlıklar için büyük bir yazı tipi seti ve gövde metni için küçük bir yazı tipi seti içerir. [FontScheme::get_Major()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/fontscheme/get_major/) ve [FontScheme::get_Minor()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/fontscheme/get_minor/) metodları bu setleri ortaya çıkarır.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmesinde kullanılabilir:

* `+mn-lt` – Gövde Yazı Tipi Latin (Minor Latin Font)
* `+mj-lt` – Başlık Yazı Tipi Latin (Major Latin Font)
* `+mn-ea` – Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
* `+mj-ea` – Başlık Yazı Tipi Doğu Asya (Major East Asian Font)

Aşağıdaki örnek, büyük Latin tema yazı tipini kullanan bir başlık ve küçük Latin tema yazı tipini kullanan bir gövde satırı oluşturur. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

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

Başlık büyük yazı tipini, gövde metni ise küçük yazı tipini izler. Açık bir yazı tipi adı içeren metin, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

Büyük ve küçük yazı tipi koleksiyonları, Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemeleri de içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Script‑Specific Theme Fonts](/slides/tr/cpp/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="Tip" %}}

Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/cpp/powerpoint-fonts/) sayfasına bakın.

{{% /alert %}}

## **Bir Temayı Kopyalama veya Uygulama**

Aşağıdaki iş akışları farklı tema‑ile ilgili sorunları çözer.

### **Bir Master’ın Bağlı Slaytlarına Harici Tema Uygulama**

PowerPoint tema dosyası (`.thmx`) elinizde ve belirli bir master’a bağlı tüm slaytların stilini yeniden oluşturmak istediğinizde [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) kullanın. [Presentation::get_Masters](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_masters/) koleksiyonundan masterı seçin (bu koleksiyon [IMasterSlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslidecollection/) uygular) ve yöntemine tema dosya yolunu aktarın.

Yöntem şu işlemleri yapar:

1. Seçilen master’a dayalı yeni bir master slayt oluşturur.  
2. Harici temayı yeni master’a uygular.  
3. Daha önce seçilen master’a bağımlı olan tüm slaytlara yeni masterı atar.  
4. Yeni oluşturulan [IMasterSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslide/) nesnesini döndürür.

Aşağıdaki örnek, ilk master’a bağımlı slaytlara harici bir tema uygular ve sunumu kaydeder:

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);
auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");

Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());
presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

Geçersiz, bozuk veya desteklenmeyen bir tema, [PptxException](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pptxexception/) veya onun biçim‑ilişkili alt sınıflarından birine neden olabilir. Kullanıcıların sağladığı yolları doğrulayın, dosya sistemi erişim hatalarını yönetin ve temayı başarıyla uyguladıktan sonra sunumu kaydedin.

Yalnızca seçilen master’a bağımlı slaytlar yeniden atanır. Diğer masterlarla ilişkili slaytlar mevcut master ve temalarını korur. Tema‑bilgili renkler, yazı tipleri, dolgular, çizgiler, arka planlar ve efektler harici temaya göre çözülür. Doğrudan atanmış renkler, yazı tipleri, dolgular ve diğer açık biçimlendirmeler değişmeden kalabilir. Düzen‑seviyesi ve slayt‑seviyesi geçersiz kılmalar da yeni master’dan miras alınan değerler üzerinde öncelik kazanabilir.

Tema, çalışma zaman ortamında bulunmayan yazı tiplerine referans verebilir. Tutarlı render ve dışa aktarım için gerekli yazı tiplerini kurun, [özel yazı tipi kaynakları](/slides/tr/cpp/custom-font/) aracılığıyla sağlayın veya [yazı tipi ikamesi](/slides/tr/cpp/font-substitution/) yapılandırın.

Bu doğrudan master‑seviyesi bir iş akışıdır: yöntem bir `.thmx` dosya yolunu alır ve slayt‑seviyesi veya düzen‑seviyesi tema geçersiz kılmaları manuel olarak oluşturmayı gerektirmez.

### **Çok‑Masterlı Sunumda Farklı Harici Temalar Uygulama**

İlgili master önceden bilinmiyorsa, onu temsili bir slayttan [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/get_layoutslide/) ve [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/get_masterslide/) aracılığıyla alın. Tema uygulamadan önce orijinal master referanslarını saklayın; her çağrı sunumda başka bir master oluşturur.

Aşağıdaki örnek, iki bölümden slaytları kullanarak masterlarını bulur ve her grup için farklı bir harici tema uygular:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());
        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

İlk çağrı yalnızca `firstGroupMaster`’a bağımlı slaytları etkiler, ikinci çağrı ise yalnızca `secondGroupMaster`’a bağımlı slaytları etkiler. Diğer masterlara ait slaytlar yeniden stilize edilmez.

### **Slayt Taşırken Kaynak Temasını Koruma**

Bir slaytı başka bir sunuma taşımak ve özgün tasarımını korumak istiyorsanız, kaynak masterı hedef sunuma [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslidecollection/addclone/) ile klonlayın, ardından slaytı ve klonlanan masterı [ISlideCollection::AddClone()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) ile klonlayın. Bu, masterı, düzenlerini ve ilişkili temayı bir arada taşır.

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

Bu, kaynak slaytın hedefte aynı görünmesini istediğinizde tercih edilen iş akışıdır. İçeriği alakasız bir hedef master’a klonlamak, tema‑tabanlı renkleri, yazı tiplerini, arka planları ve efektleri değiştirebilir.

### **Mevcut Bir Slayta Tema Değerleri Uygulama**

Hedef slayt mevcut master ve düzeninde kalmalıysa, kaynak temadan bir slayt‑seviyesi geçersiz kılma başlatın. [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) ve [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) metodları üç ana tema bileşenini geçersiz kılmaya kopyalar.

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

Bu, diğer slaytların miras aldığı temayı değiştirmeden sadece o slaytın kullandığı temayı değiştirir. Yerel geçersiz kılmayı kaldırıp miras alınan değerlere dönmek için [OverrideTheme::Clear()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/overridetheme/clear/) çağırın.

### **Bir Düzen’e Tema Geçersiz Kılma Uygulama**

Düzen‑seviyesi geçersiz kılma, o düzeni kullanan slaytlara uygulanır; özel bir slayt kendi geçersiz kılmasını yapmadıkça. Aynı başlatma metodları, düzenin [IOverrideThemeManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/ioverridethememanager/) aracılığıyla kullanılabilir:

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

Bir çok düzen ve slayt aynı temel tasarımı paylaşmalıysa master veya sunum‑seviyesi temayı, bir düzen ailesi farklı stillere ihtiyaç duyuyorsa düzen geçersiz kılmasını ve sadece gerçek istisnalar için slayt geçersiz kılmasını kullanın. Aşırı slayt‑seviyesi geçersiz kılmalar, sonraki küresel tema değişikliklerini öngörmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelleme**

Tema arka plan dolgu stilleri, [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) içinde depolanır. PowerPoint, UI’sinde temalı dolgulardan, tema renklerinden ve diğer stil referanslarından kombinasyonlar oluşturabildiği için bu koleksiyonda fiziksel olarak tanımlı dolgu sayısından daha fazla arka plan seçeneği sunabilir.

![Sunum temasına ait PowerPoint arka plan stil galerisii](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce, depolanmış koleksiyonu ve mevcut [Background::get_StyleIndex()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/background/get_styleindex/) değerini inceleyin. `StyleIndex` temalı dolgu yoksa `0` kullanır; pozitif değerler tema arka plan‑stil referanslarıdır. Bu, `idx_get(0)` ile doğrudan bir C++ koleksiyonunu indekslemede `0` ilk öğeyi ifade eder anlamından farklıdır. Her sunumun aynı sayıda arka plan dolgu stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek, kullanılabilir arka plan dolgu sayısını raporlar, ilk master’a temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünür sonuç, master tarafından referans verilen tema girişine ve düzen veya slayt seviyesindeki olası arka plan geçersiz kılmalarına bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca master arka planını değiştirmek o slaytı etkilemez. Kalıtım uygulandıktan sonra nihai arka planı öğrenmek için [Background::GetEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/background/geteffective/) kullanın.

{{% alert color="warning" title="Uyarı" %}}

`StyleIndex`i sıfır‑tabanlı bir koleksiyon indeksi gibi işlemeyin. Ayrıca bir dosyadan bir stil numarasını sabit kodlamak ve başka bir dosyada aynı görünüme sahip olacağını varsaymak da yanlıştır; tema stil tanımları sunuma özeldir.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için [Presentation Background](/slides/tr/cpp/presentation-background/) bölümüne bakın.

{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Tema format şeması, ayrı ayrı [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/formatscheme/get_linestyles/) ve [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) koleksiyonlarını içerir. Tipik Office temaları genellikle görsel olarak hafif, orta ve yoğun biçimlendirmelere karşılık gelen üç ana stil girdisi içerir, ancak kod sabit bir sayıyı varsaymak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanmış hafif, orta ve yoğun tema efektleri](presentation-design_10.png)

Bu koleksiyonlara C++’ta erişirken, koleksiyon indeksi sıfır‑tabanlıdır: `idx_get(0)` ilk depolanmış stil, `idx_get(2)` üçüncü stildir. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapestyle/) aracılığıyla ortaya çıkar. Bir tema stilini değiştirmek, o tema stiline referans veren şekilleri etkiler; doğrudan biçimlendirme kullanılan şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girdilerinin mevcut olduğunu kontrol eder, ilk çizgi stilini değiştirir, üçüncü dolgu stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

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

Bu slotlara referans veren şekillerde, ilk tema çizgi stili kırmızı, üçüncü tema dolgu stili katı orman yeşili ve üçüncü efekt stili 10 puan uzaklıkta bir dış gölge kazanır. Tam görsel sonuç, her şeklin hangi stil slotunu referans aldığı ve doğrudan biçimlendirme temayı geçersiz kılıyor mu olmasına bağlıdır.

![Satır, dolgu ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Etkili Katı Dolgunun Tema Rengi Kullanıp Kullanmadığını Belirleme**

Bir dolgu nesne üzerine doğrudan depolanabilir veya bir paragraftan, düzenden, masterdan, tema stilinden veya başka bir biçimlendirme seviyesinden miras alınabilir. Bu hiyerarşiyi değişmez bir [IFillFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifillformateffectivedata/) nesnesine çözmek için [IFillFormat::GetEffective](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifillformat/geteffective/) çağırın. Önce [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifillformateffectivedata/get_filltype/) kontrol edin. `FillType::Solid` olduğunda katı‑dolgu özelliklerini okuyun.

Katı dolgu için [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) kalıtım, tema araması ve renk dönüşümleri uygulandıktan sonraki nihai RGB değerini döndürür. [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) ilgili mantıksal [SchemeColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/schemecolor/) slotunu verir; örneğin `Text1` veya `Accent6`. `SchemeColor::NotDefined` değeri, etkili katı dolgunun bir şema rengine dayalı olmadığını gösterir. Tema renkleri veya doğrudan RGB renklerinden birini kullanan bir iş akışında bu değer, doğrudan RGB dolgu olduğunu belirler.

Yerel [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icolorformat/get_schemecolor/) değerine yalnızca bakarak bir dolguyu sınıflandırmayın. Örneğin bir metin parçasının yerel olarak tanımlı bir şema rengi olmayabilir; bu yüzden yerel değeri `NotDefined` iken, etkili dolgu bir tema rengine miras alabilir ve `Text1` veya `Accent6` olarak çözülür. Öte yandan `get_SolidFillSchemeColor` size hangi mantıksal tema slotunun etkili rengi ürettiğini söyler, ancak bu slotun nesneden, paragraftan, düzenden, masterdan veya başka bir seviyeden geldiğini söylemez.

Aşağıdaki örnek bir sunumu yükler, hem şekil dolgularını hem de metin‑parçası dolgularını denetler, her bir son RGB değerini ve ilgili şema rengini yazdırır ve tema rengi değişikliklerini takip etmeyecek katı dolguları işaretler:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto auditFill = [](const String& objectName, const SharedPtr<IFillFormat>& localFill)
{
    auto effectiveFill = localFill->GetEffective();

    if (effectiveFill->get_FillType() != FillType::Solid)
    {
        Console::WriteLine(u"{0}: fill type = {1}; not a solid fill.", objectName, effectiveFill->get_FillType());
        return;
    }

    auto rgb = effectiveFill->get_SolidFillColor();
    auto effectiveSchemeColor = effectiveFill->get_SolidFillSchemeColor();
    auto localSchemeColor = localFill->get_SolidFillColor()->get_SchemeColor();

    Console::WriteLine(u"{0}: RGB = #{1:X2}{2:X2}{3:X2}", objectName, rgb.get_R(), rgb.get_G(), rgb.get_B());
    Console::WriteLine(u"{0}: local scheme = {1}, effective scheme = {2}", objectName, localSchemeColor, effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor::NotDefined)
    {
        Console::WriteLine(u"{0}: direct RGB or another non-scheme fill; audit as theme-independent.", objectName);
    }
    else
    {
        Console::WriteLine(u"{0}: theme-dependent through {1}.", objectName, effectiveSchemeColor);
    }
};

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int32_t slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    auto shapeCount = slide->get_Shapes()->get_Count();
    for (int32_t shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        auto shapeName = String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex + 1);
        auditFill(shapeName, shape->get_FillFormat());

        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
            for (int32_t paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                auto paragraph = textFrame->get_Paragraph(paragraphIndex);

                auto portionCount = paragraph->get_Portions()->get_Count();
                for (int32_t portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    auto portion = paragraph->get_Portion(portionIndex);
                    auto portionName = String::Format(u"{0}, paragraph {1}, portion {2}", shapeName, paragraphIndex + 1, portionIndex + 1);
                    auditFill(portionName, portion->get_PortionFormat()->get_FillFormat());
                }
            }
        }
    }
}
```

`NotDefined` dalı, tema rengi slotlarındaki değişikliklere yanıt vermeyecek katı dolguların bir denetim listesini sağlar. Yeni bir marka paleti benimsenirken bu nesneleri gözden geçirin. Raporlanan RGB değeri hâlâ mevcut görünümü gösterirken, şema değeri bu görünümün tema ile bağlantılı olup olmadığını açıklar.

Etkili‑format nesneleri anlık görüntüdür. Sunum temasını, bir tema geçersiz kılmasını veya herhangi bir miras alınan biçimlendirmeyi değiştirdikten sonra `GetEffective`i tekrar çağırın ve renkleri karşılaştırmadan veya raporlamadan önce yeni bir `IFillFormatEffectiveData` nesnesi alın.

## **Etkili Tema Değerlerini Okuma**

Ham tema nesneleri belirli bir seviyede tanımlı olanı söyler. Etkili değerler ise bir slayt veya şeklin kalıtım ve yerel geçersiz kılmalar çözüldükten sonra gerçekte ne kullandığını gösterir. Bir slayt için [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) çağırın. Bir arka plan için [Background::GetEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/background/geteffective/), bir dolgu için ise [FillFormat::GetEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/geteffective/) kullanın.

Aşağıdaki örnek bir slayttan etkili temayı, arka planı ve ilk şekil dolgusunu okur:

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

Render teşhisleri, doğrulama ve karşılaştırmalar için etkili verileri kullanın. Yalnızca [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_mastertheme/) incelerseniz, bir master, düzen, slayt veya şekil geçersiz kılmasının nihai görünümü değiştirdiğini kaçırabilirsiniz.

## **SSS**

**Harici bir tema uygulamak, sunumdaki her slaytı etkiler mi?**

Hayır. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) yalnızca seçilen master’a bağımlı slaytları yeniden atar. Diğer masterları kullanan slaytlar mevcut temalarını korur.

**Master’ı değiştirmeden tek bir slayta tema uygulayabilir miyim?**

Evet. Slaydın [IOverrideThemeManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/ioverridethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik yalnızca o slayda yerel kalır; diğer slaytlar mevcut temalarını miras almaya devam eder.

**Bir temayı bir sunumdan başka bir sunuma taşımanın en güvenli yolu nedir?**

Bir slaytı taşırken ve kaynak görünümünü korurken, kaynak masterı hedefe klonlayın ve ardından slaytı bu masterla birlikte [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslidecollection/addclone/) ve [ISlideCollection::AddClone()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) ile klonlayın. Böylece master, düzenler ve tema bir arada kalır.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya düzen teması için [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) ve format nesneleri için ilgili etkili‑veri metodlarını (ör. [Background::GetEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/background/geteffective/) ve [FillFormat::GetEffective()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/geteffective/)) kullanın. Bu API’ler, kalıtım ve geçersiz kılmalar uygulandıktan sonra çözülmüş değerleri döndürür.