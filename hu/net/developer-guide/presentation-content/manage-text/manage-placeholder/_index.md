---
title: Prezentációhelykitöltők kezelése .NET-ben
linktitle: Helykitöltők kezelése
type: docs
weight: 10
url: /hu/net/manage-placeholder/
keywords:
- helykitöltő
- szöveges helykitöltő
- képes helykitöltő
- diagram helykitöltő
- felhívó szöveg
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Könnyedén kezelheti a helykitöltőket az Aspose.Slides for .NET-ben: szöveg cseréje, felhívások testreszabása és képek átlátszóságának beállítása PowerPoint és OpenDocument formátumban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a prezentációhelykitöltők programozott kezelését. Ez a cikk bemutatja, hogyan találhatók meg a helykitöltők a diákon, hogyan változtatható meg a szövegük, hogyan állítható be egyedi felhívó szöveg a helykitöltő elrendezésekhez, valamint hogyan állítható be a helykitöltő háttérként használt kép átlátszósága. Emellett egy rövid FAQ is szerepel, amely tisztázza az alaphelykitöltő és a helyi alakzat közötti különbséget, elmagyarázza, hogyan alkalmazhatók a helykitöltő módosítások elrendezések vagy mesterek alapján, és útmutatót ad a fejléc‑ és lábléc‑helykitöltők kezeléséhez.

## **Szöveg módosítása egy helykitöltőben**
Az [Aspose.Slides for .NET](/slides/hu/net/) használatával megtalálhatók és módosíthatók a prezentációk diáin lévő helykitöltők. Az Aspose.Slides lehetővé teszi a helykitöltő szövegének módosítását.

**Előfeltétel**: Szüksége van egy olyan prezentációra, amely helykitöltőt tartalmaz. Ilyen prezentációt a szabványos Microsoft PowerPoint alkalmazással hozhat létre.

Így használhatja az Aspose.Slides‑t a helykitöltő szövegének cseréjéhez a prezentációban:

1. Hozza létre a [`Presentation`](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztály egy példányát, és adja át a prezentációt argumentumként.
2. Szerezzen meg egy diára való hivatkozást az indexe alapján.
3. Iteráljon végig az alakzatokon, hogy megtalálja a helykitöltőt.
4. Alakítsa át a helykitöltő alakzatot egy [`AutoShape`](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/) típusúvá, és módosítsa a szöveget a [`AutoShape`](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/)‑hez tartozó [`TextFrame`](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) segítségével.
5. Mentse a módosított prezentációt.

Ez a C# kód bemutatja, hogyan változtatható meg a szöveg egy helykitöltőben:

```c#
 // Instantiates a Presentation class
// Példányosít egy Presentation osztályt
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // Accesses the first slide
    // Eléri az első diát
    ISlide sld = pres.Slides[0];

    // Iterates through shapes to find the placeholder
    // Iterál az alakzatokon, hogy megtalálja a helykitöltőt
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // Changes the text in each placeholder
            // Megváltoztatja a szöveget minden helykitöltőben
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // Saves the presentation to disk
    // Ment a prezentációt a lemezre
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Helykitöltő felhívó szöveg beállítása**
A szabványos és előre elkészített elrendezések tartalmaznak helykitöltő felhívó szövegeket, például ***Kattintson a cím hozzáadásához*** vagy ***Kattintson az alcím hozzáadásához***. Az Aspose.Slides segítségével saját felhívó szövegeket helyezhet be a helykitöltő elrendezésekbe.

Ez a C# kód bemutatja, hogyan állítható be a felhívó szöveg egy helykitöltőben:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Iterál a dián
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint megjeleníti a "Kattintson a cím hozzáadásához"
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Alcímet ad hozzá
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **Helykitöltő kép átlátszóságának beállítása**

Az Aspose.Slides lehetővé teszi a szöveghelykitöltő háttérképének átlátszóságának beállítását. A kép átlátszóságának módosításával a keretben kiemelhető a szöveg vagy a kép (attól függően, hogy a szöveg és a kép színei hogyan viszonyulnak egymáshoz).

Ez a C# kód megmutatja, hogyan állítható be egy kép háttér átlátszósága (alakzaton belül):

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```

## **FAQ**

**Mi az az alaphelykitöltő, és miben különbözik egy helyi alakzattól egy dián?**

Az alaphelykitöltő az elrendezésen vagy a mesteren található eredeti alakzat, amelyből a dia alakzata örököl – a típus, a pozíció és néhány formázás ebből származik. A helyi alakzat független; ha nincs alaphelykitöltő, az öröklődés nem érvényesül.

**Hogyan frissíthetem az összes címet vagy feliratot a teljes prezentációban anélkül, hogy minden diát végig iterálnék?**

Szerkessze a megfelelő helykitöltőt az elrendezésen vagy a mesteren. Az azok alapján létrehozott diák automatikusan örökölni fogják a módosítást.

**Hogyan szabályozhatom a szabványos fejléc/lábléc helykitöltőket—dátum & idő, dia száma és lábléc szövege?**

Használja a HeaderFooter kezelőket a megfelelő hatókörben (normál diák, elrendezések, mester, jegyzetek/kézikönyvek) a helykitöltők be‑ vagy kikapcsolásához, illetve a tartalmuk beállításához.