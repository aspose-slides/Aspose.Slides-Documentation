---
title: Prezentációhelykitöltők kezelése Androidon
linktitle: Helykitöltők kezelése
type: docs
weight: 10
url: /hu/androidjava/manage-placeholder/
keywords:
- helykitöltő
- szöveges helykitöltő
- kép helykitöltő
- diagram helykitöltő
- utasító szöveg
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Könnyedén kezelheti a helykitöltőket az Aspose.Slides for Android via Java segítségével: szöveg cseréje, promptok testreszabása és kép átlátszóság beállítása PowerPointban és OpenDocumentban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a prezentációhelykitöltők programozott kezelését. Ez a cikk bemutatja, hogyan találhatók meg a helykitöltők a diákon, hogyan módosítható a szövegük, hogyan állítható be egyedi prompt szöveg a helykitöltő elrendezésekhez, valamint hogyan szabályozható a helykitöltő háttérként használt kép átlátszósága. Tartalmaz egy rövid GYIK-ot is, amely tisztázza az alaphelykitöltők és a helyi alakzatok közötti különbséget, elmagyarázza, hogyan alkalmazhatók a helykitöltő változtatások elrendezéseken vagy mester fájlokon keresztül, és hivatkozik a fejléc és lábléc helykitöltőinek kezelésére.

## **Szöveg módosítása egy helykitöltőben**
A [Aspose.Slides for Android via Java](/slides/hu/androidjava/) segítségével megtalálhatja és módosíthatja a helykitöltőket a prezentációk diáin. Az Aspose.Slides lehetővé teszi a helykitöltő szövegének módosítását.

**Előfeltétel**: Szüksége van egy olyan prezentációra, amely helykitöltőt tartalmaz. Ilyen prezentációt létrehozhat a standard Microsoft PowerPoint alkalmazásban.

Ez a módja, ahogyan az Aspose.Slides-t használva kicserélheti a helykitöltő szövegét abban a prezentációban:

1. Hozza létre a [`Presentation`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztály egy példányát, és adja át a prezentációt argumentumként.
2. Szerezzen meg egy diareferenciát az indexe alapján.
3. Iteráljon a formák között, hogy megtalálja a helykitöltőt.
4. Alakítsa át a helykitöltő alakzatot egy [`AutoShape`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/AutoShape) típusra, és módosítsa a szöveget a hozzá tartozó [`TextFrame`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TextFrame) használatával, amely a [`AutoShape`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/AutoShape)-hez van társítva.
5. Mentse el a módosított prezentációt.

Ez a Java kód bemutatja, hogyan módosítható a szöveg egy helykitöltőben:

```java
// Példányosít egy Presentation osztályt
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Iterál a formákon, hogy megtalálja a helykitöltőt
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Módosítja a szöveget minden helykitöltőben
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Elmenti a prezentációt a lemezre
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Prompt szöveg beállítása egy helykitöltőben**
A szabványos és előre épített elrendezések tartalmaznak helykitöltő prompt szövegeket, például ***Click to add a title*** vagy ***Click to add a subtitle***. Az Aspose.Slides segítségével beillesztheti saját preferált prompt szövegeit a helykitöltő elrendezésekbe.

Ez a Java kód azt mutatja, hogyan állítható be a prompt szöveg egy helykitöltőben:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Iterál a dián
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint megjeleníti a "Kattintson a cím hozzáadásához" szöveget
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Alcím hozzáadása
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Helykitöltő kép átlátszóságának beállítása**
Az Aspose.Slides lehetővé teszi a háttérkép átlátszóságának beállítását egy szöveghelykitöltőben. A kép átlátszóságának szabályozásával egy ilyen keretben kiemelheti a szöveget vagy a képet (a szöveg és a kép színétől függően).

Ez a Java kód bemutatja, hogyan állítható be egy kép háttér (alakzaton belül) átlátszósága:

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Mi az az alaphelykitöltő, és miben különbözik egy helyi alakzattól a dián?**

Egy alaphelykitöltő a layouton vagy a mesteren található eredeti alakzat, amelyből a dia alakzata örököl (típusa, pozíciója és egyes formázási beállításai innen származnak). A helyi alakzat önálló; ha nincs alaphelykitöltő, az öröklődés nem érvényesül.

**Hogyan frissíthetem az összes címet vagy feliratot egy prezentációban anélkül, hogy minden dián iterálnék?**

Szerkessze a megfelelő helykitöltőt a layouton vagy a mesteren. A azok alapján létrehozott diák automatikusan örökölni fogják a módosítást.

**Hogyan vezérelhetem a szabványos fejléc/lábléc helykitöltőket - dátum & idő, dia száma és lábléc szöveg?**

Használja a HeaderFooter kezelőket a megfelelő hatókörben (normál diák, layoutok, mester, jegyzetek/előlapok), hogy be- vagy kikapcsolja ezeket a helykitöltőket, és beállítsa a tartalmukat.