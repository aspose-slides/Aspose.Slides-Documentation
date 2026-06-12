---
title: Obrázek
type: docs
weight: 50
url: /cs/net/examples/elements/picture/
keywords:
- obrázek
- rám obrázku
- přidat obrázek
- přístup k obrázku
- příklad kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Práce s obrázky v Aspose.Slides pro .NET: vkládání, ořezávání, komprimace, změna barev a export obrázků s příklady v C# pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak vkládat a získávat obrázky z obrázků uložených v paměti pomocí **Aspose.Slides for .NET**. Níže uvedené příklady vytvoří obrázek v paměti, umístí jej na snímek a poté jej načtou.

## **Přidat obrázek**

Tento kód vygeneruje malý bitmapový obrázek, převede jej do proudu a vloží jej jako rámeček obrázku na první snímek.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Vytvořte jednoduchý obrázek v paměti.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // Převeďte bitmapu do MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Přidejte obrázek do prezentace.
    var image = presentation.Images.AddImage(imageStream);

    // Vložte rámeček obrázku zobrazující obrázek na prvním snímku.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Přístup k obrázku**

Tento příklad zajistí, že snímek obsahuje rámeček obrázku, a následně získá první nalezený.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Zajistěte, aby existoval alespoň jeden rámeček obrázku, se kterým lze pracovat.
    using var bitmap = new Bitmap(40, 40);

    // Převést bitmapu na MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Přidat obrázek do prezentace.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // Získat první rámeček obrázku na snímku.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```