---
title: Správa témat prezentací v C++
linktitle: Motiv prezentace
type: docs
weight: 10
url: /cs/cpp/presentation-theme/
keywords:
- Motiv PowerPoint
- Motiv prezentace
- Motiv snímku
- Nastavit motiv
- Změnit motiv
- Spravovat motiv
- Barva motivu
- Další paleta
- Písmo motivu
- Styl motivu
- Efekt motivu
- PowerPoint
- OpenDocument
- Prezentace
- C++
- Aspose.Slides
description: "Spravujte motivy prezentací v Aspose.Slides pro C++, abyste mohli vytvářet, přizpůsobovat a konvertovat soubory PowerPoint s konzistentní značkou."
---
## **Úvod**

Prezentace téma určuje vlastnosti návrhových prvků. Když vyberete téma prezentace, v podstatě volíte konkrétní sadu vizuálních prvků a jejich vlastnosti.

V PowerPointu motiv zahrnuje barvy, [písma](/slides/cs/cpp/powerpoint-fonts/), [styly pozadí](/slides/cs/cpp/presentation-background/), a efekty.

![složky‑motivu](theme-constituents.png)

## **Změna barvy motivu**

Motiv PowerPoint používá konkrétní sadu barev pro různé prvky na snímku. Pokud se vám barvy nelíbí, můžete je změnit aplikací nových barev pro motiv. Aby bylo možné vybrat novou barvu motivu, Aspose.Slides poskytuje hodnoty v enumeraci [SchemeColor](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28).

Tento C++ kód ukazuje, jak změnit akcentní barvu motivu:

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

Můžete takto určit efektivní hodnotu výsledné barvy:

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
// ff8064a2 (Barva [A=255, R=128, G=100, B=162])
```

Pro další demonstraci operace změny barvy vytvoříme další prvek a přiřadíme mu akcentní barvu (z úvodní operace). Poté změníme barvu v motivu:

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

Nová barva se automaticky použije na oba prvky.

### **Nastavení barvy motivu z další palety**

Když aplikujete transformace luminance na hlavní barvu motivu(1), vzniknou barvy z dodatečné palety(2). Pak můžete tyto barvy motivu nastavit a získat.

![dodatečné‑barvy‑palety](additional-palette-colors.png)

**1**‑ Hlavní barvy motivu  
**2**‑ Barvy z dodatečné palety.

Tento C++ kód demonstruje operaci, kde jsou barvy dodatečné palety získány z hlavní barvy motivu a poté použity ve tvarech:

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

// Akcent 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Akcent 4, světlejší 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Akcent 4, světlejší 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Akcent 4, světlejší 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Akcent 4, tmavší 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Akcent 4, tmavší 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **Mapování `SchemeColor` na barvy `IColorScheme`**

Když pracujete s [SchemeColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides.schemecolor/), můžete si všimnout, že obsahuje následující hodnoty barvy motivu:

`Background1`, `Background2`, `Text1` a `Text2`.

Nicméně `Presentation::get_MasterTheme()::get_ColorScheme()` vrací [IColorScheme](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/icolorscheme/), který zpřístupňuje odpovídající barvy jako:

`Dark1`, `Dark2`, `Light1` a `Light2`.

Tento rozdíl je pouze v názvech. Tyto hodnoty odkazují na stejná místa barvy motivu a mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Mezi `Text`/`Background` a `Dark`/`Light` neexistuje dynamická konverze. Jedná se jen o alternativní názvy pro stejné barvy motivu.

Tento rozdíl v názvosloví pochází z terminologie Microsoft Office. Starší verze Office používaly `Dark 1`, `Light 1`, `Dark 2` a `Light 2`, zatímco novější UI verze zobrazují stejná místa jako `Text 1`, `Background 1`, `Text 2` a `Background 2`.

## **Změna písma motivu**

Aby bylo možné vybrat písma pro motivy a další účely, Aspose.Slides používá tyto speciální identifikátory (podobně jako v PowerPointu):

* **+mn‑lt** – tělesné písmo Latin (menší latinské písmo)
* **+mj‑lt** – nadpisové písmo Latin (větší latinské písmo)
* **+mn‑ea** – tělesné písmo East Asian (menší východoasijské písmo)
* **+mj‑ea** – tělesné písmo East Asian (větší východoasijské písmo)

Tento C++ kód ukazuje, jak přiřadit latinské písmo k prvku motivu:

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

Tento C++ kód ukazuje, jak změnit písmo motivu prezentace:

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

Písmo ve všech textových polích bude aktualizováno.

{{% alert color="info" title="TIP" %}} 
Možná budete chtít zobrazit [PowerPoint písma](/slides/cs/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Změna stylu pozadí motivu**

Ve výchozím nastavení aplikace PowerPoint poskytuje 12 předdefinovaných pozadí, ale pouze 3 z těchto 12 pozadí jsou uložena v typické prezentaci.

![todo:image_alt_text](presentation-design_8.png)

Například po uložení prezentace v aplikaci PowerPoint můžete spustit tento C++ kód, abyste zjistili počet předdefinovaných pozadí v prezentaci:

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
Pomocí vlastnosti [BackgroundFillStyles](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) ze třídy [FormatScheme](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.theme.i_format_scheme/) můžete přidat nebo získat styl pozadí v motivu PowerPointu. 
{{% /alert %}}

Tento C++ kód ukazuje, jak nastavit pozadí pro prezentaci:

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

**Indexová příručka**: 0 znamená bez výplně. Index začíná od 1.

{{% alert color="info" title="TIP" %}} 
Možná budete chtít zobrazit [PowerPoint pozadí](/slides/cs/cpp/presentation-background/).
{{% /alert %}}

## **Změna efektu motivu**

Motiv PowerPoint obvykle obsahuje 3 hodnoty pro každé pole stylů. Tato pole jsou sloučena do těchto 3 efektů: jemný, střední a intenzivní. Například takto vypadá výsledek, když jsou efekty aplikovány na konkrétní tvar:

![todo:image_alt_text](presentation-design_10.png)

Pomocí 3 vlastností ([FillStyles](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) ze třídy [FormatScheme](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.theme.i_format_scheme/) můžete měnit prvky v motivu (ještě flexibilněji než možnosti v PowerPointu).

Tento C++ kód ukazuje, jak změnit efekt motivu úpravou částí prvků:

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

Výsledné změny ve výplni barvy, typu výplně, stínovém efektu atd.:

![todo:image_alt_text](presentation-design_11.png)

## **Často kladené otázky**

### Mohu použít motiv na jeden snímek, aniž bych změnil hlavní motiv?

Ano. Aspose.Slides podporuje přepsání motivu na úrovni snímku, takže můžete použít lokální motiv pouze na tento snímek a zároveň zachovat hlavní motiv beze změny (prostřednictvím [SlideThemeManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/slidethememanager/)).

### Jaký je nejbezpečnější způsob, jak přenést motiv z jedné prezentace do druhé?

[Klonejte snímky](/slides/cs/cpp/clone-slides/) spolu s jejich hlavním motivem do cílové prezentace. Tím se zachová původní hlavní motiv, rozvržení a související motiv, takže vzhled zůstane konzistentní.

### Jak mohu zobrazit „efektivní“ hodnoty po všech dědění a přepsáních?

Použijte „efektivní“ pohledy API [/slides/cs/cpp/shape-effective-properties/] pro motiv/barvu/písmo/efekt. Tyto pohledy vracejí vyřešené, konečné vlastnosti po aplikaci hlavního motivu a všech lokálních přepsání.