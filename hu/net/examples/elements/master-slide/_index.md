---
title: Mesterdia
type: docs
weight: 30
url: /hu/net/examples/elements/master-slide/
keywords:
- mesterdia
- mesterdia hozzáadása
- mesterdia elérése
- mesterdia eltávolítása
- használaton kívüli mesterdia
- kódpélda
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for .NET mesterdia példákat: hozza létre, szerkessze és formázza a mesterdiákat, helyettesítőket és sablonokat PPT, PPTX és ODP formátumokban, tiszta C# kóddal."
---
A mesterdia a dia öröklési hierarchia legfelső szintjét alkotja a PowerPointban. Egy **mesterdia** közös tervezési elemeket határoz meg, például háttérképeket, logókat és szövegformázást. A **elrendezésdia** a mesterdiáktól örököl, és a **normál dia** az elrendezésdíákból örököl.

Ez a cikk bemutatja, hogyan hozhatók létre, módosíthatók és kezelhetők a mesterdiák az Aspose.Slides for .NET segítségével.

## **Mesterdia hozzáadása**

Ez a példa azt mutatja be, hogyan hozhatunk létre egy új mesterdiát az alapértelmezett klónozásával. Ezután a vállalat neve feliratot adja minden diához az elrendezés öröklése révén.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // Klónozza az alapértelmezett mesterdiát.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // Adjon hozzá egy vállalati név feliratos bannert a mesterdia tetejéhez.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Rendelje hozzá az új mesterdiát egy elrendezésdiához.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // Rendelje hozzá az elrendezésdiát a prezentáció első diájához.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **Megjegyzés 1:** A mesterdiák lehetővé teszik a konzisztens márkaarculat vagy közös tervezési elemek alkalmazását az összes dián. A mesteren végzett módosítások automatikusan megjelennek a függő elrendezés- és normál diákon.
> 
> 💡 **Megjegyzés 2:** A mesterdiára hozzáadott alakzatok vagy formázások öröklődnek az elrendezésdíákra, és végül az azokat használó összes normál diára.
> 
> A lenti kép illusztrálja, hogyan jelenik meg automatikusan egy mesterdiára hozzáadott szövegdoboz a végső dián.

![Mester öröklés példa](master-slide-banner.png)

## **Mesterdia elérése**

A mesterdiák a `Presentation.Masters` gyűjteményen keresztül érhetők el. Íme, hogyan kérhetők le és dolgozhatunk velük:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // Az első mesterdia elérése.
    var firstMasterSlide = presentation.Masters[0];

    // A háttér típusának módosítása.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **Mesterdia eltávolítása**

A mesterdiák eltávolíthatók index vagy hivatkozás alapján.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // Egy mesterdiát eltávolít index alapján.
    presentation.Masters.RemoveAt(0);

    // Egy mesterdiát eltávolít hivatkozás alapján.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **Használaton kívüli mesterdiák eltávolítása**

Néhány bemutató olyan mesterdiákat tartalmaz, amelyeket nem használnak. Ezek eltávolítása csökkentheti a fájlméretet.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // Az összes használaton kívüli mesterdiát eltávolítja (még a Preserve‑ként megjelöltöket is).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```