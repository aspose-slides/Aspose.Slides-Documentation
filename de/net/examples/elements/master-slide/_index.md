---
title: Masterfolie
type: docs
weight: 30
url: /de/net/examples/elements/master-slide/
keywords:
- Masterfolie
- Masterfolie hinzufügen
- Zugriff auf Masterfolie
- Masterfolie entfernen
- unbenutzte Masterfolie
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie Beispiele für Masterfolien mit Aspose.Slides für .NET: Erstellen, Bearbeiten und Gestalten von Masterfolien, Platzhaltern und Designs in PPT, PPTX und ODP mit verständlichem C#-Code."
---
Masterfolien bilden die oberste Ebene der Folienvererbungshierarchie in PowerPoint. Eine **Masterfolie** definiert gemeinsame Designelemente wie Hintergründe, Logos und Textformatierungen. **Layoutfolien** erben von Masterfolien, und **Normalfolien** erben von Layoutfolien.

Dieser Artikel zeigt, wie man Masterfolien mit Aspose.Slides für .NET erstellt, ändert und verwaltet.

## **Eine Masterfolie hinzufügen**

Dieses Beispiel demonstriert, wie man eine neue Masterfolie erstellt, indem man die Standardfolie klont. Anschließend wird ein Unternehmensnamen‑Banner über die Layoutvererbung zu allen Folien hinzugefügt.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // Klonen Sie die Standard-Masterfolie.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // Fügen Sie ein Banner mit Firmennamen oben auf der Masterfolie hinzu.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Weisen Sie die neue Masterfolie einer Layoutfolie zu.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // Weisen Sie die Layoutfolie der ersten Folie in der Präsentation zu.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **Hinweis 1:** Masterfolien ermöglichen es, ein einheitliches Branding oder gemeinsam genutzte Designelemente über alle Folien hinweg anzuwenden. Änderungen an der Masterfolie werden automatisch auf abhängige Layout‑ und Normalfolien übertragen.

> 💡 **Hinweis 2:** Alle zu einer Masterfolie hinzugefügten Formen oder Formatierungen werden von Layoutfolien und damit von allen Normalfolien, die diese Layouts verwenden, geerbt.
> Das Bild unten zeigt, wie ein Textfeld, das einer Masterfolie hinzugefügt wurde, automatisch auf der endgültigen Folie dargestellt wird.

![Master Inheritance Example](master-slide-banner.png)

## **Auf eine Masterfolie zugreifen**

Sie können auf Masterfolien über die Sammlung `Presentation.Masters` zugreifen. So rufen Sie sie ab und arbeiten mit ihnen:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // Greifen Sie auf die erste Masterfolie zu.
    var firstMasterSlide = presentation.Masters[0];

    // Hintergrundtyp ändern.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **Eine Masterfolie entfernen**

Masterfolien können entweder nach Index oder nach Referenz entfernt werden.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // Entfernen einer Masterfolie nach Index.
    presentation.Masters.RemoveAt(0);

    // Entfernen einer Masterfolie per Referenz.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **Unbenutzte Masterfolien entfernen**

Einige Präsentationen enthalten Masterfolien, die nicht verwendet werden. Das Entfernen dieser Folien kann die Dateigröße reduzieren.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // Entfernt alle ungenutzten Masterfolien (auch solche, die als Preserve markiert sind).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```