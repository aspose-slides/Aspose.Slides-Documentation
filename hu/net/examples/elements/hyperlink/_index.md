---
title: Hiperhivatkozás
type: docs
weight: 130
url: /hu/net/examples/elements/hyperlink/
keywords:
- hiperhivatkozás
- hiperhivatkozás hozzáadása
- hiperhivatkozás elérése
- hiperhivatkozás eltávolítása
- hiperhivatkozás frissítése
- kódrészlet
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása és kezelése az Aspose.Slides for .NET-ben: szövegek, alakzatok és képek összekapcsolása, célok és műveletek beállítása PPT, PPTX és ODP fájlokhoz C# példákkal."
---
Ez a cikk bemutatja a hiperhivatkozások hozzáadását, elérését, eltávolítását és frissítését alakzatokon a **Aspose.Slides for .NET** használatával.

## **Hiperhivatkozás hozzáadása**

Hozzon létre egy négyszögletes alakzatot, amelynek hiperhivatkozása egy külső weboldalra mutat.

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **Hiperhivatkozás elérése**

Olvassa el a hiperhivatkozás információit egy alakzat szövegrészéből.

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **Hiperhivatkozás eltávolítása**

Törölje a hiperhivatkozást az alakzat szövegéből.

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **Hiperhivatkozás frissítése**

Módosítsa egy meglévő hiperhivatkozás célját. Használja a `HyperlinkManager`-t a már hiperhivatkozást tartalmazó szöveg módosításához, ami hasonlóan működik, mint a PowerPoint a hiperhivatkozások biztonságos frissítésekor.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // A már létező szövegben lévő hiperhivatkozás módosítása
    // a HyperlinkManager-rel kell történjen, a tulajdonság közvetlen beállítása helyett.
    // Ez a PowerPoint által a hiperhivatkozások biztonságos frissítésének módját utánozza.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```