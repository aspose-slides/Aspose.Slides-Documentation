---
title: Lägg till ellipser i presentationer i Python
linktitle: Ellips
type: docs
weight: 30
url: /sv/python-net/ellipse/
keywords:
- ellips
- form
- lägg till ellips
- skapa ellips
- rita ellips
- formaterad ellips
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du skapar, formaterar och manipulerar ellipsformer i Aspose.Slides för Python via .NET i PPT-, PPTX- och ODP-presentationer - kodexempel inkluderade."
---
## **Översikt**

Den här artikeln visar hur man lägger till ellipsformer i PowerPoint-bilder med hjälp av Aspose.Slides. Den täcker hur man skapar en enkel ellips, hur man skapar en formaterad ellips och hur man sparar den uppdaterade presentationen som en PPTX‑fil. Den berör också relaterade frågor såsom arbete med ellipsens position och storlek, styrning av staplingsordning och tillämpning av animationseffekter.

## **Skapa ellips**
I detta avsnitt kommer vi att introducera utvecklare för hur man lägger till ellipsformer i sina presentationer med Aspose.Slides for Python via .NET. Aspose.Slides for Python via .NET erbjuder ett enklare API‑set för att rita olika typer av former med bara några rader kod. För att lägga till en enkel ellips på en vald bild i presentationen, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)klass
1. Hämta referensen till en bild genom att använda dess Index
1. Lägg till en AutoShape av typen Ellipse med AddAutoShape‑metoden som exponeras av IShapes‑objektet
1. Skriv den modifierade presentationen som en PPTX‑fil

I exemplet nedan har vi lagt till en ellips på den första bilden.

```py
import aspose.slides as slides

# Skapa en Presentation-klass som representerar PPTX-filen
with slides.Presentation() as pres:
    # Hämta den första bilden
    sld = pres.slides[0]

    # Lägg till en autoshape av ellipstyp
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #Skriv PPTX-filen till disk
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Skapa formaterad ellips**
För att lägga till en bättre formaterad ellips på en bild, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)klass.
1. Hämta referensen till en bild genom att använda dess Index.
1. Lägg till en AutoShape av typen Ellipse med AddAutoShape‑metoden som exponeras av IShapes‑objektet.
1. Ställ in fyllningstypen för ellipsen till Solid.
1. Ställ in färgen på ellipsen med egenskapen SolidFillColor.Color som exponeras av FillFormat‑objektet kopplat till IShape‑objektet.
1. Ställ in färgen på ellipsens linjer.
1. Ställ in bredden på ellipsens linjer.
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en formaterad ellips på den första bilden i presentationen.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Skapa en Presentation-klass som representerar PPTX-filen
with slides.Presentation() as pres:
    # Hämta den första bilden
    sld = pres.slides[0]

    # Lägg till en autoshape av ellipstyp
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Tillämpa viss formatering på ellipsformen
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Tillämpa viss formatering på ellipsens linje
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Write PPTX-filen till disk
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Hur anger jag exakt position och storlek för en ellips i förhållande till bildens enheter?**

Koordinater och storlekar specificeras vanligtvis **i punkter**. För förutsägbara resultat bör du basera dina beräkningar på bildens storlek och konvertera erforderliga millimeter eller tum till punkter innan du tilldelar värden.

**Hur kan jag placera en ellips ovanför eller under andra objekt (styra staplingsordning)?**

Justera ritordningen för objektet genom att föra det framåt eller skicka det bakåt. Detta låter ellipsen överlappa andra objekt eller avslöja de som ligger under.

**Hur animerar jag en ellipss framträdande eller betoning?**

[Apply](/slides/sv/python-net/shape-animation/) ingångs‑, betoning‑ eller utgångseffekter på formen, och konfigurera triggers och tidpunkt för att orkestrera när och hur animationen spelas.