---
title: Lägg till ellipser i presentationer i .NET
linktitle: Ellips
type: docs
weight: 30
url: /sv/net/ellipse/
keywords:
- ellips
- form
- lägga till ellips
- skapa ellips
- rita ellips
- formaterad ellips
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du skapar, formaterar och manipulerar ellipsformer i Aspose.Slides för .NET i PPT- och PPTX-presentationer—C#-kodexempel inkluderade."
---
## **Översikt**

Denna artikel visar hur du lägger till ellipsformer i PowerPoint‑bilder genom att använda Aspose.Slides. Den täcker att skapa en enkel ellips, att skapa en formaterad ellips och att spara den uppdaterade presentationen som en PPTX‑fil. Den berör även relaterade frågor såsom arbete med ellipsens position och storlek, kontroll av staplingsordning och applicering av animationseffekter.

## **Skapa en ellips**
För att lägga till en enkel ellips på en vald bild i presentationen, följ stegen nedan:

1. Skapa en instans av [Presentation ](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)klass
1. Hämta referensen till en bild genom att använda dess Index
1. Lägg till en AutoShape av typen Ellipse med hjälp av AddAutoShape‑metoden som exponeras av IShapes‑objektet
1. Skriv den modifierade presentationen som en PPTX‑fil

I exemplet nedan har vi lagt till en ellips på den första bilden.

```c#
    // Instansiera Presentation-klassen som representerar PPTX
    using (Presentation pres = new Presentation())
    {
    
        // Hämta den första bilden
        ISlide sld = pres.Slides[0];
    
        // Lägg till autoshape av ellipstyp
        sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
        //Skriv PPTX-filen till disk
        pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
    }
```

## **Skapa en formaterad ellips**
För att lägga till en bättre formaterad ellips på en bild, följ stegen nedan:

1. Skapa en instans av [Presentation ](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)klass.
2. Hämta referensen till en bild genom att använda dess Index.
3. Lägg till en AutoShape av typen Ellipse med hjälp av AddAutoShape‑metoden som exponeras av IShapes‑objektet.
4. Ställ in fyllningstypen för ellipsen till Solid.
5. Ställ in färgen på ellipsen med solidfyllnadsfärgens Color‑egenskap som exponeras av FillFormat‑objektet som är kopplat till IShape‑objektet.
6. Ställ in färgen på ellipsens linjer.
7. Ställ in bredden på ellipsens linjer.
8. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en formaterad ellips på den första bilden i presentationen.

```c#
 // Instansiera Presentation-klassen som representerar PPTX
 using (Presentation pres = new Presentation())
 {
 
     // Hämta den första bilden
     ISlide sld = pres.Slides[0];
 
     // Lägg till autoshape av ellipstyp
     IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
 
     // Applicera viss formatering på ellipsformen
     shp.FillFormat.FillType = FillType.Solid;
     shp.FillFormat.SolidFillColor.Color = Color.Chocolate;
 
     // Applicera viss formatering på ellipsens linje
     shp.LineFormat.FillFormat.FillType = FillType.Solid;
     shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
     shp.LineFormat.Width = 5;
 
     //Skriv PPTX-filen till disk
     pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
 }
```

## **Vanliga frågor**

**Hur anger jag den exakta positionen och storleken på en ellips i förhållande till bildens enheter?**

Koordinater och storlekar specificeras vanligtvis **i punkter**. För förutsägbara resultat bör du basera dina beräkningar på bildens storlek och konvertera erforderliga millimeter eller tum till punkter innan du tilldelar värden.

**Hur kan jag placera en ellips ovanför eller under andra objekt (kontroll av staplingsordning)?**

Justera ritordningen för objektet genom att föra det framåt eller skicka det bakåt. Detta gör att ellipsen kan överlappa andra objekt eller avslöja de som ligger under den.

**Hur animerar jag en ellipsens framträdande eller betoning?**

[Tillämpa](/slides/sv/net/shape-animation/) ingångs‑, betoning‑ eller utgångseffekter på formen, och konfigurera triggers och tidpunkter för att orkestrera när och hur animationen spelas upp.