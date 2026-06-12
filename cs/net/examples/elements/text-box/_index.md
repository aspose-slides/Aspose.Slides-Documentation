---
title: Textové pole
type: docs
weight: 40
url: /cs/net/examples/elements/text-box/
keywords:
- textové pole
- přidat textové pole
- přístup k textovému poli
- odstranit textové pole
- ukázkový kód
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Pracujte s textovými poli v Aspose.Slides pro .NET: přidávejte, formátujte, zarovnávejte, zalamujte, automaticky přizpůsobujte a stylizujte text pomocí C# pro prezentace PPT, PPTX a ODP."
---
V Aspose.Slides je **textové pole** reprezentováno jako `AutoShape`. Téměř jakýkoli tvar může obsahovat text, ale typické textové pole nemá výplň ani okraj a zobrazuje pouze text.

Tento průvodce vysvětluje, jak programově přidávat, přistupovat k a odstraňovat textová pole.

## **Přidání textového pole**

Textové pole je jednoduše `AutoShape` bez výplně ani okraje a s nějakým formátovaným textem. Zde je návod, jak jej vytvořit:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Vytvořte obdélníkový tvar (ve výchozím nastavení vyplněný okrajem a bez textu).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Odeberte výplň a okraj, aby vypadal jako typické textové pole.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Nastavte formátování textu.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Přiřaďte skutečný textový obsah.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Poznámka:** Jakýkoli `AutoShape`, který obsahuje ne‑prázdný `TextFrame`, může fungovat jako textové pole.

## **Přístup k textovým polím podle obsahu**

Pro nalezení všech textových polí obsahujících konkrétní klíčové slovo (např. "Slide") procházejte tvary a kontrolujte jejich text:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // Pouze AutoShape mohou obsahovat upravitelný text.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Proveďte něco s odpovídajícím textovým polem.
            }
        }
    }
}
```

## **Odstranění textových polí podle obsahu**

Tento příklad najde a smaže všechna textová pole na první snímku, která obsahují konkrétní klíčové slovo:

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **Tip:** Vždy vytvořte kopii kolekce tvarů před tím, než ji během iterace upravujete, abyste se vyhnuli chybám při úpravě kolekce.