---
title: Szövegdoboz
type: docs
weight: 40
url: /hu/net/examples/elements/text-box/
keywords:
- szövegdoboz
- szövegdoboz hozzáadása
- szövegdoboz elérése
- szövegdoboz eltávolítása
- kód példa
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Munka szövegdobozokkal az Aspose.Slides for .NET-ben: szöveg hozzáadása, formázása, igazítása, sortördelése, automatikus méretezése és stílusozása C#-ban PPT, PPTX és ODP prezentációkhoz."
---
Az Aspose.Slides-ban egy **szövegdoboz** egy `AutoShape`-ként van ábrázolva. Gyakorlatilag bármely alakzat tartalmazhat szöveget, de egy tipikus szövegdoboz nem rendelkezik kitöltéssel vagy szegéllyel, és csak a szöveget jeleníti meg.

Ez az útmutató bemutatja, hogyan lehet programozottan hozzáadni, elérni és eltávolítani a szövegdobozokat.

## **Szövegdoboz hozzáadása**

A szövegdoboz egyszerűen egy `AutoShape`, amelynek nincs kitöltése vagy szegélye, és tartalmaz formázott szöveget. Íme, hogyan hozhatunk létre egyet:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Hozzon létre egy téglalap alakzatot (alapértelmezés szerint kitöltött szegéllyel és szöveg nélkül).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Távolítsa el a kitöltést és a szegélyt, hogy tipikus szövegdoboznak tűnjön.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Állítsa be a szövegformázást.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Rendelje hozzá a tényleges szövegtartalmat.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Megjegyzés:** Bármely `AutoShape`, amely nem üres `TextFrame`-et tartalmaz, szövegdobozként funkcionálhat.

## **Szövegdobozok elérése tartalom szerint**

Az összes olyan szövegdoboz megtalálásához, amely egy adott kulcsszót tartalmaz (pl. "Slide"), iteráljunk át az alakzatokon, és ellenőrizzük a szövegüket:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // Csak az AutoShape-ek tartalmazhatnak szerkeszthető szöveget.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Valamit tegyünk a megfelelő szövegdobozzal.
            }
        }
    }
}
```

## **Szövegdobozok eltávolítása tartalom szerint**

Ez a példa megtalálja és törli az első dián az összes olyan szövegdobozt, amely egy adott kulcsszót tartalmaz:

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

> 💡 **Tipp:** Mindig készítsünk másolatot az alakzatgyűjteményről, mielőtt módosítanánk azt iterálás közben, hogy elkerüljük a gyűjtemény módosításával kapcsolatos hibákat.