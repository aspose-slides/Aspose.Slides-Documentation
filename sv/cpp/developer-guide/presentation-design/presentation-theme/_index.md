---
title: Hantera presentationsteman i C++
linktitle: Presentationstema
type: docs
weight: 10
url: /sv/cpp/presentation-theme/
keywords:
- PowerPoint-tema
- presentationstema
- bildtema
- ange tema
- ändra tema
- hantera tema
- temafärg
- extra palett
- tematypsnitt
- temastil
- temaeffekt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Behärska presentationsteman i Aspose.Slides för C++ för att skapa, anpassa och konvertera PowerPoint-filer med enhetlig varumärkesprofil."
---
## **Introduktion**

Ett presentationstema definierar egenskaperna hos designelement. När du väljer ett presentationstema väljer du i princip en specifik uppsättning visuella element och deras egenskaper.

I PowerPoint består ett tema av färger, [typsnitt](/slides/sv/cpp/powerpoint-fonts/), [bakgrundsstilar](/slides/sv/cpp/presentation-background/), och effekter.

![tema-komponenter](theme-constituents.png)

## **Ändra temafärg**

Ett PowerPoint‑tema använder en specifik uppsättning färger för olika element på en bild. Om du inte gillar färgerna kan du ändra dem genom att tillämpa nya färger för temat. För att låta dig välja en ny temafärg tillhandahåller Aspose.Slides värden under [SchemeColor](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28).

Denna C++‑kod visar hur du ändrar accentfärgen för ett tema:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

Du kan bestämma den resulterande färgens faktiska värde på detta sätt:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Färg [A=255, R=128, G=100, B=162])
```

För att ytterligare demonstrera färgändringsoperationen skapar vi ett annat element och tilldelar accentfärgen (från den första operationen) till det. Därefter ändrar vi färgen i temat:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

Den nya färgen tillämpas automatiskt på båda elementen.

### **Ställ in temafärg från ett extra färgpalett**

När du tillämpar luminans‑transformeringar på huvudtemafärgen(1) bildas färger från den extra paletten(2). Du kan sedan ställa in och hämta dessa temafärger.

![extra-palette-färger](additional-palette-colors.png)

**1**- Huvudtemafärger  
**2**- Färger från den extra paletten.

Denna C++‑kod demonstrerar en operation där färger från den extra paletten erhålls från huvudtemafärgen och sedan används i former:

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Accent 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Accent 4, Ljusare 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Accent 4, Ljusare 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Accent 4, Ljusare 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Accent 4, Mörkare 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Accent 4, Mörkare 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **Mappa `SchemeColor` till `IColorScheme`‑färger**

När du arbetar med [SchemeColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides.schemecolor/), kan du märka att den innehåller följande temafärgsvärden:

`Background1`, `Background2`, `Text1` och `Text2`.

Dock returnerar `Presentation::get_MasterTheme()::get_ColorScheme()` [IColorScheme](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/icolorscheme/), som exponerar de motsvarande färgerna som:

`Dark1`, `Dark2`, `Light1` och `Light2`.

Differensen ligger bara i namnet. Dessa värden avser samma temafärgsplatser och mappningen är fast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Det finns ingen dynamisk konvertering mellan `Text`/`Background` och `Dark`/`Light`. De är helt enkelt alternativa namn för samma temafärger.

Denna skillnad i namn kommer från Microsoft Office‑terminologi. Äldre Office‑versioner använde `Dark 1`, `Light 1`, `Dark 2` och `Light 2`, medan nyare UI‑versioner visar samma platser som `Text 1`, `Background 1`, `Text 2` och `Background 2`.

## **Ändra temats typsnitt**

För att låta dig välja typsnitt för teman och andra ändamål använder Aspose.Slides dessa speciella identifierare (liknande de som används i PowerPoint):

* **+mn-lt** - Kroppstypsnitt Latin (Minor Latin Font)
* **+mj-lt** - Rubriktypsnitt Latin (Major Latin Font)
* **+mn-ea** - Kroppstypsnitt Östasiatiskt (Minor East Asian Font)
* **+mj-ea** - Kroppstypsnitt Östasiatiskt (Major East Asian Font)

Denna C++‑kod visar hur du tilldelar det latinska typsnittet till ett temaelement:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Denna C++‑kod visar hur du ändrar presentationstematts typsnitt:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

Typsnittet i alla textrutor kommer att uppdateras.

{{% alert color="primary" title="TIP" %}} 
Du kanske vill se [PowerPoint typsnitt](/slides/sv/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Ändra temats bakgrundsstil**

Som standard tillhandahåller PowerPoint‑appen 12 fördefinierade bakgrunder, men endast 3 av dessa 12 bakgrunder sparas i en vanlig presentation.

![exempel på bakgrund](presentation-design_8.png)

Till exempel, efter att du har sparat en presentation i PowerPoint‑appen kan du köra denna C++‑kod för att ta reda på antalet fördefinierade bakgrunder i presentationen:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
Genom att använda egenskapen [BackgroundFillStyles](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) från klassen [FormatScheme](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.theme.i_format_scheme/) kan du lägga till eller komma åt bakgrundsstilen i ett PowerPoint‑tema. 
{{% /alert %}}

Denna C++‑kod visar hur du ställer in bakgrunden för en presentation:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Indexguide**: 0 används för ingen fyllning. Indexet börjar från 1.

{{% alert color="primary" title="TIP" %}} 
Du kanske vill se [PowerPoint Bakgrund](/slides/sv/cpp/presentation-background/).
{{% /alert %}}

## **Ändra temats effekt**

Ett PowerPoint‑tema innehåller vanligtvis 3 värden för varje stilarray. Dessa arrayer kombineras till dessa 3 effekter: subtil, måttlig och intensiv. Till exempel, så här ser resultatet ut när effekterna tillämpas på en specifik form:

![exempel på effekt](presentation-design_10.png)

Genom att använda 3 egenskaper ([FillStyles](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) från [FormatScheme](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.theme.i_format_scheme/) kan du ändra element i ett tema (ännu mer flexibelt än alternativen i PowerPoint).

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

De resulterande ändringarna i fyllningsfärg, fyllningstyp, skuggeffekt osv:

![exempel på ändrade effekter](presentation-design_11.png)

## **FAQ**

**Kan jag applicera ett tema på en enskild bild utan att ändra master?**

Ja. Aspose.Slides stödjer temaunderskrivningar på bildnivå, så du kan applicera ett lokalt tema på just den bilden samtidigt som mastertemat förblir intakt (via [SlideThemeManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/slidethememanager/)).

**Vad är det säkraste sättet att föra över ett tema från en presentation till en annan?**

[Klonade bilder](/slides/sv/cpp/clone-slides/) tillsammans med deras master till mål‑presentationen. Detta bevarar den ursprungliga mastern, layouterna och det associerade temat så att utseendet förblir konsekvent.

**Hur kan jag se de ”effektiva” värdena efter all arv och överskrivningar?**

Använd API:ets ["effektiva"](/slides/sv/cpp/shape-effective-properties/) vyer för tema/färg/typsnitt/effekt. Dessa returnerar de lösta, slutgiltiga egenskaperna efter att master och eventuella lokala överskrivningar har tillämpats.