---
title: Hyperodkaz
type: docs
weight: 130
url: /cs/net/examples/elements/hyperlink/
keywords:
- hyperodkaz
- přidat hyperodkaz
- získat hyperodkaz
- odstranit hyperodkaz
- aktualizovat hyperodkaz
- příklad kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přidávejte a spravujte hyperodkazy v Aspose.Slides pro .NET: textové odkazy, tvary a obrázky, nastavujte cíle a akce pro PPT, PPTX a ODP s příklady v C#."
---
Tento článek ukazuje přidávání, získávání, odstraňování a aktualizaci hyperodkazů na tvarech pomocí **Aspose.Slides for .NET**.

## **Přidat hyperodkaz**

Vytvořte obdélníkový tvar s hyperodkazem směřujícím na externí webovou stránku.

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

## **Získat hyperodkaz**

Přečtěte si informace o hyperodkazu z textové části tvaru.

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

## **Odstranit hyperodkaz**

Odstraňte hyperodkaz z textu tvaru.

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

## **Aktualizovat hyperodkaz**

Změňte cílový odkaz existujícího hyperodkazu. Použijte `HyperlinkManager` k úpravě textu, který již obsahuje hyperodkaz, což napodobuje způsob, jakým PowerPoint bezpečně aktualizuje hyperodkazy.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Změna hypertextového odkazu v existujícím textu by měla být provedena pomocí
    // HyperlinkManager místo přímého nastavení vlastnosti.
    // Toto napodobuje, jak PowerPoint bezpečně aktualizuje hyperodkazy.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```