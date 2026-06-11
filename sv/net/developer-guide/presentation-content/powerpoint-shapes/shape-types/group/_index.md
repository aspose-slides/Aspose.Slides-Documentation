---
title: Grupppresentation av former i .NET
linktitle: Formgrupp
type: docs
weight: 40
url: /sv/net/group/
keywords:
- gruppform
- formgrupp
- lägga till grupp
- alternativ text
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig att gruppera och avgruppera former i PowerPoint-presentationer med Aspose.Slides för .NET - en snabb steg-för-steg-guide med gratis C#-kod."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med gruppformer i Aspose.Slides. Den visar hur man lägger till en gruppform på en bild, placerar former i den och sparar den uppdaterade presentationen. Den demonstrerar också hur man får åtkomst till former som lagras i en grupp och läser deras `AlternativeText`‑värden. Dessutom täcker artikeln kort relaterade gruppform‑funktioner såsom inbäddade grupper, z‑ordning och låsalternativ.

## **Lägg till en gruppform**
Aspose.Slides stödjer arbete med gruppformer på bilder. Denna funktion hjälper utvecklare att skapa rikare presentationer. Aspose.Slides för .NET stödjer att lägga till eller komma åt gruppformer. Det är möjligt att lägga till former till en tillagd gruppform för att fylla den eller komma åt någon egenskap hos gruppformen. För att lägga till en gruppform på en bild med Aspose.Slides för .NET:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta referensen till en bild genom att använda dess Index
1. Lägg till en gruppform på bilden.
1. Lägg till formerna i den tillagda gruppformen.
1. Spara den ändrade presentationen som en PPTX‑fil.

Exemplet nedan lägger till en gruppform på en bild.

```c#
// Instansiera Presentation-klassen 
using (Presentation pres = new Presentation())
{
    // Hämta den första bilden 
    ISlide sld = pres.Slides[0];

    // Kom åt formsamlingen för bilderna 
    IShapeCollection slideShapes = sld.Shapes;

    // Lägger till en gruppform på bilden 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Lägger till former i den tillagda gruppformen 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Lägger till gruppformsram 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Skriv PPTX-filen till disk 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```



## **Kom åt AltText‑egenskapen**
Detta ämne visar enkla steg, komplett med kodexempel, för att lägga till en gruppform och komma åt AltText‑egenskapen för gruppformer på bilder. För att komma åt AltText för en gruppform i en bild med Aspose.Slides för .NET:

1. Instansiera `Presentation`‑klassen som representerar en PPTX‑fil.
1. Hämta referensen till en bild genom att använda dess Index.
1. Kom åt bildens formsamling.
1. Kom åt gruppformen.
1. Kom åt AltText‑egenskapen.

Exemplet nedan kommer åt alternativ text för gruppformen.

```c#
// Instansiera Presentation-klassen som representerar PPTX-fil
Presentation pres = new Presentation("AltText.pptx");

// Hämta den första bilden
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Kom åt formsamlingen för bilderna
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Kom åt gruppformen.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // Kom åt AltText‑egenskapen
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```

## **FAQ**

**Stöds nästlade grupper (en grupp inuti en annan grupp)?**

Ja. [GroupShape](https://reference.aspose.com/slides/sv/net/aspose.slides/groupshape/) har en [ParentGroup](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/parentgroup/) egenskap, som direkt indikerar stöd för hierarki (en grupp kan vara ett barn till en annan grupp).

**Hur styr jag gruppens z‑ordning i förhållande till andra objekt på bilden?**

Använd [GroupShape](https://reference.aspose.com/slides/sv/net/aspose.slides/groupshape/)s [ZOrderPosition](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/zorderposition/) egenskap för att inspektera dess position i visningsstacken.

**Kan jag förhindra flyttning/redigering/avgruppering?**

Ja. Gruppens låssektion exponeras via [GroupShapeLock](https://reference.aspose.com/slides/sv/net/aspose.slides/groupshape/groupshapelock/), vilket låter dig begränsa operationer på objektet.