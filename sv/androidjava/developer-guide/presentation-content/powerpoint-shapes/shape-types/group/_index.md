---
title: Gruppformar i presentation på Android
linktitle: Formgrupp
type: docs
weight: 40
url: /sv/androidjava/group/
keywords:
- gruppform
- formgrupp
- lägg till grupp
- alternativ text
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig att gruppera och avgruppa former i PowerPoint-presentationer med Aspose.Slides för Android—snabb, steg-för-steg guide med gratis Java-kod."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med gruppformer i Aspose.Slides. Den visar hur man lägger till en gruppform på en bild, placerar former i den och sparar den uppdaterade presentationen. Den demonstrerar också hur man får åtkomst till former som lagras i en grupp och läser deras `AlternativeText`-värden. Dessutom behandlar artikeln kort relaterade funktioner för gruppformer såsom nästlade grupper, z-order och låsalternativ.

## **Lägg till en gruppform**
Aspose.Slides stöder arbete med gruppformer på bilder. Denna funktion hjälper utvecklare att skapa rikare presentationer. Aspose.Slides för Android via Java stöder att lägga till eller komma åt gruppformer. Det är möjligt att lägga till former i en tillagd gruppform för att fylla den eller komma åt någon egenskap hos gruppformen. För att lägga till en gruppform på en bild med Aspose.Slides för Android via Java:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)-klassen.
1. Hämta referensen till en bild genom att använda dess Index
1. Lägg till en gruppform på bilden.
1. Lägg till formerna i den tillagda gruppformen.
1. Spara den modifierade presentationen som en PPTX-fil.

Exemplet nedan lägger till en gruppform på en bild.

```java
// Instansiera Presentation-klassen
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Åtkomst till bildens formsamling
    IShapeCollection slideShapes = sld.getShapes();

    // Lägga till en gruppform på bilden
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Lägga till former i den tillagda gruppformen
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Lägga till gruppformens ram
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Skriv PPTX-filen till disk
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Åtkomst till AltText-egenskapen**
Detta ämne visar enkla steg, komplett med kodexempel, för att lägga till en gruppform och få åtkomst till AltText-egenskapen för gruppformer på bilder. För att få åtkomst till AltText för en gruppform på en bild med Aspose.Slides för Android via Java:

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)-klassen som representerar en PPTX-fil.
1. Hämta referensen till en bild genom att använda dess Index.
1. Få åtkomst till bildens formsamling.
1. Få åtkomst till gruppformen.
1. Få åtkomst till [AlternativeText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape#getAlternativeText--) -egenskapen.

Exemplet nedan hämtar alternativ text för gruppformen.

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

**Stöds nästlad gruppering (en grupp inuti en grupp)?**

Ja. [GroupShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/groupshape/) har en [getParentGroup](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#getParentGroup--) -metod, som tydligt visar stöd för hierarki (en grupp kan vara ett barn till en annan grupp).

**Hur kontrollerar jag gruppens z-order i förhållande till andra objekt på bilden?**

Använd [GroupShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/groupshape/)s [getZOrderPosition](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#getZOrderPosition--) -metod för att undersöka dess position i visningsstacken.

**Kan jag hindra flyttning/redigering/avgruppering?**

Ja. Gruppens låsavsnitt exponeras via [getGroupShapeLock](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--) , vilket låter dig begränsa operationer på objektet.