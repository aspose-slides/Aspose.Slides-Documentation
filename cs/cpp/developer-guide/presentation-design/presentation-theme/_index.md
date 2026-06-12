---
title: Správa prezentačních motivů v C++
linktitle: Prezentační motiv
type: docs
weight: 10
url: /cs/cpp/presentation-theme/
keywords:
- PowerPoint motiv
- prezentační motiv
- motiv snímku
- nastavení motivu
- změna motivu
- správa motivu
- barva motivu
- další paleta
- písmo motivu
- styl motivu
- efekt motivu
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Spravujte hlavní prezentační motivy v Aspose.Slides pro C++ pro vytváření, úpravu a konverzi souborů PowerPoint s jednotným brandováním."
---
## **Úvod**

Prezentační motiv určuje vlastnosti návrhových prvků. Když vyberete prezentační motiv, v podstatě si volíte konkrétní sadu vizuálních prvků a jejich vlastností.

V PowerPointu motiv zahrnuje barvy, [fonts](/slides/cs/cpp/powerpoint-fonts/), [background styles](/slides/cs/cpp/presentation-background/) a efekty.

![theme-constituents](theme-constituents.png)

## **Změna barvy motivu**

PowerPointový motiv používá konkrétní sadu barev pro různé prvky na snímku. Pokud se vám barvy nelíbí, můžete je změnit aplikací nových barev pro motiv. Aby vám bylo umožněno vybrat novou barvu motivu, Aspose.Slides poskytuje hodnoty v enumeraci [SchemeColor](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28).

Tento C++ kód ukazuje, jak změnit akcentní barvu motivu:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

Tímto způsobem můžete zjistit efektivní hodnotu výsledné barvy:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Barva [A=255, R=128, G=100, B=162])
```

Pro další ukázku operace změny barvy vytvoříme další prvek a přiřadíme mu akcentní barvu (z počáteční operace). Poté změníme barvu v motivu:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

Nová barva se automaticky použije na oba prvky.

### **Nastavení barvy motivu z další palety**

Když na hlavní barvu motivu (1) použijete transformace jasu, vytvoří se barvy z další palety (2). Pak můžete tyto barvy motivu nastavit a získat.

![additional-palette-colors](additional-palette-colors.png)

**1**‑ Hlavní barvy motivu  
**2**‑ Barvy z další palety.

Tento C++ kód demonstruje operaci, kde barvy z další palety jsou získány z hlavní barvy motivu a následně použity ve tvarech:

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Accent 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Accent 4, Lighter 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Accent 4, Lighter 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Accent 4, Lighter 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Accent 4, Darker 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Accent 4, Darker 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **Mapování `SchemeColor` na barvy `IColorScheme`**

Když pracujete s [SchemeColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides.schemecolor/), můžete si všimnout, že obsahuje následující hodnoty barev motivu:

`Background1`, `Background2`, `Text1` a `Text2`.

Nicméně `Presentation::get_MasterTheme()::get_ColorScheme()` vrací [IColorScheme](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/icolorscheme/), který zpřístupňuje odpovídající barvy jako:

`Dark1`, `Dark2`, `Light1` a `Light2`.

Tento rozdíl je pouze v pojmenování. Tyto hodnoty se vztahují ke stejným slotům barvy motivu a mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Neexistuje žádná dynamická konverze mezi `Text`/`Background` a `Dark`/`Light`. Jedná se jen o alternativní názvy stejných barev motivu.

Tento rozdíl v pojmenování pochází z terminologie Microsoft Office. Starší verze Office používaly `Dark 1`, `Light 1`, `Dark 2` a `Light 2`, zatímco novější verze UI zobrazují stejné sloty jako `Text 1`, `Background 1`, `Text 2` a `Background 2`.

## **Změna písma motivu**

Aby vám bylo umožněno vybrat písma pro motivy a další účely, Aspose.Slides používá tyto speciální identifikátory (podobné těm, které se používají v PowerPointu):

* **+mn-lt** – tělo písmo Latin (Minor Latin Font)
* **+mj-lt** – nadpis písmo Latin (Major Latin Font)
* **+mn-ea** – tělo písmo East Asian (Minor East Asian Font)
* **+mj-ea** – tělo písmo East Asian (Major East Asian Font)

Tento C++ kód ukazuje, jak přiřadit písmo Latin do prvku motivu:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Tento C++ kód ukazuje, jak změnit písmo prezentačního motivu:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

Písmo ve všech textových polích bude aktualizováno.

{{% alert color="primary" title="TIP" %}} 
Možná budete chtít zobrazit [PowerPoint fonts](/slides/cs/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Změna stylu pozadí motivu**

Ve výchozím nastavení aplikace PowerPoint poskytuje 12 předdefinovaných pozadí, ale v typické prezentaci jsou uložena jen 3 z těchto 12 pozadí.

![todo:image_alt_text](presentation-design_8.png)

Například po uložení prezentace v aplikaci PowerPoint můžete spustit tento C++ kód a zjistit počet předdefinovaných pozadí v prezentaci:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
Pomocí vlastnosti [BackgroundFillStyles](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) z třídy [FormatScheme](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.theme.i_format_scheme/) můžete přidat nebo získat styl pozadí v PowerPoint motivu. 
{{% /alert %}}

Tento C++ kód ukazuje, jak nastavit pozadí pro prezentaci:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Průvodce indexem**: 0 se používá pro žádnou výplň. Index začíná od 1.

{{% alert color="primary" title="TIP" %}} 
Možná budete chtít zobrazit [PowerPoint Background](/slides/cs/cpp/presentation-background/).
{{% /alert %}}

## **Změna efektu motivu**

PowerPointový motiv obvykle obsahuje 3 hodnoty pro každý pole stylů. Tato pole jsou sloučena do těchto 3 efektů: subtilní, střední a intenzivní. Například toto je výsledek, když jsou efekty aplikovány na konkrétní tvar:

![todo:image_alt_text](presentation-design_10.png)

Pomocí 3 vlastností ([FillStyles](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) ze třídy [FormatScheme](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.theme.i_format_scheme/) můžete měnit prvky v motivu (ještě flexibilněji než možnosti v PowerPointu).

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

Výsledné změny ve výplňové barvě, typu výplně, stínovém efektu atd.:

![todo:image_alt_text](presentation-design_11.png)

## **Často kladené dotazy**

**Mohu aplikovat motiv na jediný snímek bez změny hlavní šablony?**

Ano. Aspose.Slides podporuje přepsání motivu na úrovni snímku, takže můžete aplikovat lokální motiv jen na tento snímek a zároveň zachovat hlavní motiv neporušený (prostřednictvím [SlideThemeManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/slidethememanager/)).

**Jaký je nejbezpečnější způsob přenést motiv z jedné prezentace do druhé?**

[Clone slides](/slides/cs/cpp/clone-slides/) spolu s jejich hlavní šablonou do cílové prezentace. Tím se zachová původní hlavní šablona, rozvržení a přidružený motiv, takže vzhled zůstane konzistentní.

**Jak mohu zobrazit "efektivní" hodnoty po veškerém dědění a přepsání?**

Použijte „efektivní“ pohledy API [/slides/cs/cpp/shape-effective-properties/] pro motiv/barvu/písmo/efekt. Tyto vracejí rozlišené, konečné vlastnosti po aplikaci hlavní šablony a jakýchkoli lokálních přepsání.