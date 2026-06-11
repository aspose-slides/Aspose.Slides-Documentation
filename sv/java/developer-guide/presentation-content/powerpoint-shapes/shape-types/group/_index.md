---
title: Gruppformer i presentationer i Java
linktitle: Formgrupp
type: docs
weight: 40
url: /sv/java/group/
keywords:
- gruppform
- formgrupp
- lägga till grupp
- alternativ text
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig gruppera och avgruppera former i PowerPoint-presentationer med Aspose.Slides för Java - snabb, steg-för-steg-guide med fri Java-kod."
---
## **Overview**

Den här artikeln förklarar hur man arbetar med gruppformer i Aspose.Slides. Den visar hur man lägger till en gruppform på en bild, placerar former inuti den och sparar den uppdaterade presentationen. Den demonstrerar också hur man får åtkomst till former som lagras i en grupp och läser deras `AlternativeText`‑värden. Dessutom täcker artikeln kort relaterade funktioner för gruppformer såsom nästlade grupper, z‑order och låsalternativ.

## **Add a Group Shape**
Aspose.Slides stöder arbete med gruppformer på bilder. Denna funktion hjälper utvecklare att skapa rikare presentationer. Aspose.Slides for Java stöder att lägga till eller komma åt gruppformer. Det är möjligt att lägga till former i en skapad gruppform för att fylla den eller komma åt någon egenskap hos gruppformen. Så här lägger du till en gruppform på en bild med Aspose.Slides for Java:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Hämta referensen till en bild genom att använda dess Index
1. Lägg till en gruppform på bilden.
1. Lägg till formerna i den skapade gruppformen.
1. Spara den modifierade presentationen som en PPTX‑fil.

Exemplet nedan lägger till en gruppform på en bild.

```java
// Instansiera Presentation-klass
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Åtkomst till bildens formsamling
    IShapeCollection slideShapes = sld.getShapes();

    // Lägger till en gruppform på bilden
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Lägger till former i den skapade gruppformen
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Lägger till gruppformens ram
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Skriver PPTX-filen till disk
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Access the AltText Property**
Det här avsnittet visar enkla steg, komplett med kodexempel, för att lägga till en gruppform och komma åt AltText‑egenskapen för gruppformer på bilder. Så här får du åtkomst till AltText för en gruppform i en bild med Aspose.Slides for Java:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) som representerar en PPTX‑fil.
1. Hämta referensen till en bild genom att använda dess Index.
1. Åtkomst till bildens formsamling.
1. Åtkomst till gruppformen.
1. Åtkomst till egenskapen [AlternativeText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape#getAlternativeText--).

Exemplet nedan får åtkomst till alternativ text för gruppformen.

```java
// Instansiera Presentation-klass som representerar PPTX-fil
Presentation pres = new Presentation("AltText.pptx");
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Åtkomst till bildens formsamling
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Åtkomst till gruppformen.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // Åtkomst till AltText‑egenskapen
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Is nested grouping (a group inside a group) supported?**

Ja. [GroupShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/groupshape/) har en [getParentGroup](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getParentGroup--)‑metod, vilket tydligt visar stöd för hierarki (en grupp kan vara ett barn till en annan grupp).

**How do I control the group’s z-order relative to other objects on the slide?**

Använd [GroupShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/groupshape/)‑metoden [getZOrderPosition](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getZOrderPosition--) för att undersöka dess position i visningsstacken.

**Can I prevent moving/editing/ungrouping?**

Ja. Gruppens låssektion exponeras via [GroupShapeLock](https://reference.aspose.com/slides/sv/java/com.aspose.slides/groupshape/#getGroupShapeLock--), vilket låter dig begränsa operationer på objektet.