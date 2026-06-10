---
title: "Prezentációs témák kezelése C++-ban"
linktitle: "Prezentációs téma"
type: docs
weight: 10
url: /hu/cpp/presentation-theme/
keywords:
- "PowerPoint téma"
- "prezentációs téma"
- "dia téma"
- "téma beállítása"
- "téma módosítása"
- "téma kezelése"
- "téma színe"
- "kiegészítő paletta"
- "téma betűtípusa"
- "téma stílusa"
- "téma effektusa"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "C++"
- "Aspose.Slides"
description: "Mester prezentációs témák az Aspose.Slides C++-hoz a PowerPoint fájlok létrehozásához, testreszabásához és konvertálásához következetes arculattal."
---
## **Bevezetés**

Egy bemutató téma meghatározza a tervezési elemek tulajdonságait. Ha kiválaszt egy bemutató témát, tulajdonképpen egy meghatározott vizuális elemek és azok tulajdonságainak halmazát választja ki.

In PowerPoint, a theme comprises colors, [betűtípusok](/slides/hu/cpp/powerpoint-fonts/), [háttérstílusok](/slides/hu/cpp/presentation-background/), and effects.

![theme-constituents](theme-constituents.png)

## **Téma színének módosítása**

A PowerPoint téma egy meghatározott színkészletet használ a dián lévő különböző elemekhez. Ha nem tetszenek a színek, azokat a téma új színeinek alkalmazásával módosíthatja. Az új téma szín kiválasztásához az Aspose.Slides a [SchemeColor](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) felsorolásban értékeket biztosít.

Ez a C++ kód bemutatja, hogyan lehet megváltoztatni egy téma hangsúlyszínét:
```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

Így határozhatja meg a keletkezett szín tényleges értékét:
```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Szín [A=255, R=128, G=100, B=162])
```

Az színmódosítás művelet további bemutatásához egy másik elemet hozunk létre, és ráadjuk a hangsúlyszínt (az első műveletből). Ezután megváltoztatjuk a színt a témában:
```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

Az új szín automatikusan alkalmazásra kerül mindkét elemre.

### **A téma színének beállítása egy kiegészítő palettáról**

Ha fényességtranszformációkat alkalmaz a fő téma színére (1), akkor a kiegészítő palettáról (2) színek keletkeznek. Ezután beállíthatja és lekérheti ezeket a téma színeket.

![additional-palette-colors](additional-palette-colors.png)

**1**- A fő téma színek  
**2**- A kiegészítő palettáról származó színek.

Ez a C++ kód egy olyan műveletet mutat be, ahol a kiegészítő paletta színeit a fő téma színéből származtatják, majd alakzatokban használják:
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

### **A `SchemeColor` leképezése az `IColorScheme` színekre**

Ha a [SchemeColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/schemecolor/) elemmel dolgozik, észreveheti, hogy a következő témaszínek értékeit tartalmazza:
`Background1`, `Background2`, `Text1` és `Text2`.

Azonban a `Presentation::get_MasterTheme()::get_ColorScheme()` egy [IColorScheme](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/icolorscheme/) objektumot ad vissza, amely a megfelelő színeket a következőként teszi elérhetővé:
`Dark1`, `Dark2`, `Light1` és `Light2`.

Ez a különbség csak a megnevezésben van. Ezek az értékek ugyanazokra a téma színhelyekre vonatkoznak, és a leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Nincs dinamikus átalakítás a `Text`/`Background` és a `Dark`/`Light` között. Ezek egyszerűen csak alternatív elnevezések ugyanazokra a témaszínekre.

Ez a néveltérést a Microsoft Office terminológia okozza. A régebbi Office verziók a `Dark 1`, `Light 1`, `Dark 2` és `Light 2` elnevezéseket használták, míg az újabb felhasználói felületek ugyanezeket a helyeket `Text 1`, `Background 1`, `Text 2` és `Background 2` névvel jelenítik meg.

## **Téma betűtípusának módosítása**

A témákhez és egyéb célokra betűtípusok kiválasztásához az Aspose.Slides ezekkel a speciális azonosítókkal dolgozik (hasonlóan a PowerPointban használtakhoz):

* **+mn-lt** - Törzs betűtípus Latin (Minor Latin Font)
* **+mj-lt** - Címsor betűtípus Latin (Major Latin Font)
* **+mn-ea** - Törzs betűtípus Kelet‑Ázsiai (Minor East Asian Font)
* **+mj-ea** - Címsor betűtípusa Kelet‑Ázsiai (Major East Asian Font)

Ez a C++ kód bemutatja, hogyan lehet a latin betűtípust egy téma elemhez hozzárendelni:
```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Ez a C++ kód azt mutatja, hogyan lehet módosítani a bemutató téma betűtípusát:
```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

Az összes szövegdoboz betűtípusa frissülni fog.

{{% alert color="primary" title="TIPP" %}} 
Érdemes megnézni a [PowerPoint betűtípusokat](/slides/hu/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Téma háttérstílusának módosítása**

Alapértelmezés szerint a PowerPoint alkalmazás 12 előre definiált hátteret biztosít, de egy tipikus prezentációban csak 3 ebben a 12-ben tárolódik.

![todo:image_alt_text](presentation-design_8.png)

Például, miután elment egy bemutatót a PowerPoint alkalmazásban, futtathatja ezt a C++ kódot, hogy megtudja a prezentációban szereplő előre definiált hátterek számát:
```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
Az [BackgroundFillStyles](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) tulajdonságot a [FormatScheme](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.theme.i_format_scheme/) osztályból használva hozzáadhat vagy elérheti a háttérstílust egy PowerPoint témában. 
{{% /alert %}}

Ez a C++ kód bemutatja, hogyan állítható be a háttér egy prezentációhoz:
```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Index útmutató**: 0 a kitöltés nélküli állapotot jelöli. Az index 1‑től kezdődik.

{{% alert color="primary" title="TIPP" %}} 
Érdemes megnézni a [PowerPoint háttér](/slides/hu/cpp/presentation-background/).
{{% /alert %}}

## **Téma effektusának módosítása**

Egy PowerPoint téma általában 3 értéket tartalmaz minden stílus tömbhöz. Ezek a tömbök a három effektusba – finom, közepes és intenzív – kombinálódnak. Például, ez az eredmény, amikor az effektusokat egy adott alakzatra alkalmazzák:

![todo:image_alt_text](presentation-design_10.png)

Az [FillStyles](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58) tulajdonságokat a [FormatScheme](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.theme.i_format_scheme/) osztályból használva rugalmasabban változtathatja meg a téma elemeit, mint a PowerPoint lehetőségei.
```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

A kapott változások a kitöltési színben, kitöltési típusban, árnyékhatásban stb.:
![todo:image_alt_text](presentation-design_11.png)

## **GYIK**

**Alkalmazhatok egy témát egyetlen diára anélkül, hogy a mestert módosítanám?**  
Igen. Az Aspose.Slides támogatja a diaszintű téma felülírást, így helyi témát alkalmazhat csak arra a diára, miközben a fő témát változatlanul hagyja (a [SlideThemeManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/slidethememanager/) segítségével).

**Mi a legbiztonságosabb módja egy téma átvitelének az egyik prezentációból a másikba?**  
[Dia másolás](/slides/hu/cpp/clone-slides/) a saját mesterükkel együtt a célprezentációba. Ez megőrzi az eredeti mestert, elrendezéseket és a kapcsolódó témát, így a megjelenés konzisztens marad.

**Hogyan tekinthetem meg a „valódi” értékeket a teljes öröklődés és felülírás után?**  
Használja az API "[effective" nézeteit](/slides/hu/cpp/shape-effective-properties/) a téma/szín/betűtípus/effektus esetén. Ezek a mester és a helyi felülírások alkalmazása után kiszámított, végső tulajdonságokat adnak vissza.