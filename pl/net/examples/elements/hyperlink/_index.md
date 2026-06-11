---
title: Hiperłącze
type: docs
weight: 130
url: /pl/net/examples/elements/hyperlink/
keywords:
- hiperłącze
- dodaj hiperłącze
- pobierz hiperłącze
- usuń hiperłącze
- zaktualizuj hiperłącze
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dodawaj i zarządzaj hiperłączami w Aspose.Slides for .NET: teksty, kształty i obrazy, ustawiaj cele i akcje dla PPT, PPTX i ODP przy użyciu przykładów w C#."
---
Ten artykuł demonstruje dodawanie, dostęp, usuwanie i aktualizowanie hiperłączy na kształtach przy użyciu **Aspose.Slides for .NET**.

## **Dodaj hiperłącze**

Utwórz prostokątny kształt z hiperłączem wskazującym na zewnętrzną witrynę.

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

## **Uzyskaj dostęp do hiperłącza**

Odczytaj informacje o hiperłączu z fragmentu tekstu kształtu.

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

## **Usuń hiperłącze**

Wyczyść hiperłącze z tekstu kształtu.

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

## **Zaktualizuj hiperłącze**

Zmień docelowy adres istniejącego hiperłącza. Użyj `HyperlinkManager`, aby zmodyfikować tekst, który już zawiera hiperłącze, co naśladuje sposób, w jaki PowerPoint bezpiecznie aktualizuje hiperłącza.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Zmiana hiperłącza wewnątrz istniejącego tekstu powinna być wykonana za pomocą
    // HyperlinkManager zamiast bezpośredniego ustawiania właściwości.
    // To naśladuje sposób, w jaki PowerPoint bezpiecznie aktualizuje hiperłącza.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```