---
title: Masterfolie
type: docs
weight: 30
url: /de/net/examples/elements/master-slide/
keywords:
- Beispiel für Masterfolie
- Masterfolie hinzufügen
- Zugriff auf Masterfolie
- Masterfolie entfernen
- Unbenutzte Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Masterfolien in C# mit Aspose.Slides verwalten: Erstellen, Bearbeiten, Klonen und Formatieren von Designs, Hintergründen, Platzhaltern, um Folien in PowerPoint und OpenDocument zu vereinheitlichen."
---

Masterfolien bilden die oberste Ebene der Folienvererbungshierarchie in PowerPoint. Eine **Masterfolie** definiert gemeinsame Designelemente wie Hintergründe, Logos und Textformatierung. **Layoutfolien** erben von Masterfolien, und **Normalfolien** erben von Layoutfolien.

Dieser Artikel zeigt, wie man Masterfolien mit Aspose.Slides für .NET erstellt, ändert und verwaltet.

## Masterfolie hinzufügen

Dieses Beispiel zeigt, wie man eine neue Masterfolie erstellt, indem man die Standardfolie dupliziert. Anschließend fügt es einen Firmenname-Banner zu allen Folien über die Layout-Vererbung hinzu.

```csharp
static void Add_Master_Slide()
{
    using var pres = new Presentation();

    // Clone the default master slide
    var defaultMasterSlide = pres.Masters[0];
    var newMaster = pres.Masters.AddClone(defaultMasterSlide);

    // Add a banner with company name to the top of the master slide
    var textBox = newMaster.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Assign the new master slide to a layout slide
    var layoutSlide = pres.LayoutSlides[0];
    layoutSlide.MasterSlide = newMaster;

    // Assign the layout slide to the first slide in the presentation
    pres.Slides[0].LayoutSlide = layoutSlide;
}
````

> 💡 **Tipp 1:** Masterfolien bieten die Möglichkeit, einheitliches Branding oder gemeinsam genutzte Designelemente auf alle Folien anzuwenden. Alle Änderungen an der Masterfolie werden automatisch auf abhängige Layout‑ und Normalfolien übertragen.

> 💡 **Tipp 2:** Alle Formen oder Formatierungen, die einer Masterfolie hinzugefügt werden, werden von Layoutfolien und damit von allen Normalfolien, die diese Layouts verwenden, geerbt.

Das Bild unten zeigt, wie ein auf einer Masterfolie hinzugefügtes Textfeld automatisch auf der endgültigen Folie dargestellt wird.

![Beispiel für Master‑Vererbung](master-slide-banner.png)

## Auf eine Masterfolie zugreifen

Sie können Masterfolien über die Sammlung `Presentation.Masters` abrufen. So holen und bearbeiten Sie sie:

```csharp
static void Access_Master_Slide()
{
    using var pres = new Presentation();

    // Access the first master slide
    var firstMasterSlide = pres.Masters[0];

    // Change the background type
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## Masterfolie entfernen

Masterfolien können entweder nach Index oder nach Referenz entfernt werden.

```csharp
static void Remove_Master_Slide()
{
    using var pres = new Presentation();

    // Remove by index
    pres.Masters.RemoveAt(0);

    // Or remove by reference
    var firstMasterSlide = pres.Masters[0];
    pres.Masters.Remove(firstMasterSlide);
}
```

## Unbenutzte Masterfolien entfernen

Einige Präsentationen enthalten Masterfolien, die nicht verwendet werden. Das Entfernen dieser Folien kann die Dateigröße reduzieren.

```csharp
static void RemoveUnused_Master_Slide()
{
    using var pres = new Presentation();

    // Remove all unused master slides (even those marked as Preserve)
    pres.Masters.RemoveUnused(ignorePreserveField: true);
}
```

> ⚙️ **Tipp:** Verwenden Sie `RemoveUnused(true)`, um unbenutzte Masterfolien zu bereinigen und die Präsentationsgröße zu minimieren.