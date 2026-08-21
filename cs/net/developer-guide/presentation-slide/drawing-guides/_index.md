---
title: Správa kreslicích vodítek v prezentacích v .NET
linktitle: Kreslicí vodítka
type: docs
weight: 85
url: /cs/net/drawing-guides/
keywords:
- kreslicí vodítko
- vodorovné vodítko
- svislé vodítko
- vodítko pro zarovnání
- zobrazení snímku
- hlavní snímek
- snímek rozvržení
- master poznámek
- master letáků
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přidávejte, přistupujte a odstraňujte vodorovná a svislá kreslicí vodítka v prezentacích PowerPoint pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Kreslicí vodítka jsou nastavitelná vodorovná a svislá čáry, které pomáhají uživatelům konzistentně zarovnávat tvary při úpravě prezentace v PowerPointu. Jsou zvláště užitečná, když aplikace generuje prezentaci, která bude později ručně doladěna: aplikace může uložit stejné pomůcky pro zarovnání, které by autoři měli dodržovat při přidávání nebo přesouvání obsahu.

Kreslicí vodítka jsou pomocné nástroje pro úpravy, nikoli obsah snímku. Nezobrazují se v prezentaci ani ve vykresleném výstupu. Aspose.Slides pro .NET je zpřístupňuje prostřednictvím rozhraní [IDrawingGuidesCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/idrawingguidescollection/) . Vodítko je reprezentováno rozhraním [IDrawingGuide](https://reference.aspose.com/slides/cs/net/aspose.slides/idrawingguide/) a má orientaci, pozici a barvu.

Pozice se měří v bodech od levého horního rohu příslušného snímku nebo masteru. Svislé vodítko používá vodorovnou souřadnici, obvykle mezi nulou a šířkou snímku. Vodorovné vodítko používá svislou souřadnici, obvykle mezi nulou a výškou snímku.

## **Přidání vodítek do zobrazení snímku**

Použijte [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/cs/net/aspose.slides/icommonslideviewproperties/drawingguides/) abyste spravovali vodítka zobrazovaná při úpravě běžných snímků. Zavolejte [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/cs/net/aspose.slides/idrawingguidescollection/add/) s hodnotou [Orientation](https://reference.aspose.com/slides/cs/net/aspose.slides/orientation/) a pozicí v bodech.

Následující příklad přidá jedno svislé vodítko vpravo od středu snímku a jedno vodorovné vodítko pod ním:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **Přístup ke kreslicím vodítkům**

Vlastnost a indexer [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/cs/net/aspose.slides/idrawingguidescollection/count/) poskytují přístup k existujícím vodítkům. Vlastnosti [IDrawingGuide.Orientation](https://reference.aspose.com/slides/cs/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/cs/net/aspose.slides/idrawingguide/position/) a [IDrawingGuide.Color](https://reference.aspose.com/slides/cs/net/aspose.slides/idrawingguide/color/) lze číst i měnit.

Následující příklad načte vodítka zobrazení snímku z výše vytvořené prezentace:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **Přidání vodítek do masteru a rozvržení snímků**

Slide master a každý z jeho snímků rozvržení může mít vlastní kolekce kreslicích vodítek. Použijte [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslide/drawingguides/) pro master snímek a [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutslide/drawingguides/) pro snímek rozvržení.

Následující příklad přidá svislé vodítko na první master snímek a vodorovné vodítko na první snímek rozvržení:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Přidání vodítek do poznámkových a letákových masterů**

Poznámkové mastery a letákové mastery také podporují kreslicí vodítka. Použijte [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/cs/net/aspose.slides/imasternotesslide/drawingguides/) a [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterhandoutslide/drawingguides/) pro přístup k jejich kolekcím. Pokud prezentace neobsahuje některý z těchto masterů, [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) nebo [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) vytvoří výchozí master a vrátí jej.

Následující příklad přidá vodorovné vodítko do poznámkového masteru a svislé vodítko do letákového masteru:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Vymazání kreslicích vodítek**

Zavolejte [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/cs/net/aspose.slides/idrawingguidescollection/clear/) , aby se odstranilo každé vodítko z konkrétní kolekce. Vymazání jedné kolekce neovlivní vodítka uložená v jiné oblasti.

Následující příklad vymaže vodítka zobrazení snímku a všechna vodítka na slide masterech, snímcích rozvržení, poznámkovém masteru i letákovém masteru, aniž by vytvořil chybějící mastery:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **Často kladené otázky**

**Objevují se kreslicí vodítka v prezentaci nebo exportovaných obrázcích?**

Ne. Kreslicí vodítka jsou pomůcky pro zarovnání při úpravách a nejsou vykreslována jako obsah prezentace.

**Lze kreslicí vodítko přidat přímo k jednotlivému běžnému snímku?**

Vodítka pro úpravy běžných snímků jsou uložena ve vlastnostech zobrazení snímku prezentace. Samostatné kolekce vodítek jsou k dispozici pro slide mastery, snímky rozvržení, poznámkové mastery a letákové mastery.

**Jaké jednotky se používají pro pozice vodítek?**

Pozice jsou uvedeny v bodech, kde 72 bodů odpovídá jednomu palci. Svislé pozice se měří od levého okraje a vodorovné pozice od horního okraje.

**Způsobí vymazání kreslicích vodítek odstranění tvarů nebo změnu obsahu snímku?**

Ne. Metoda `Clear` odstraňuje pouze vodítka ve vybrané kolekci. Tvary a ostatní obsah snímku zůstávají beze změny.