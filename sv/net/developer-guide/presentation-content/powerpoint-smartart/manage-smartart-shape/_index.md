---
title: Hantera SmartArt-grafik i presentationer i .NET
linktitle: SmartArt-grafik
type: docs
weight: 20
url: /sv/net/manage-smartart-shape/
keywords:
- SmartArt-objekt
- SmartArt-grafik
- SmartArt-stil
- SmartArt-färg
- skapa SmartArt
- lägga till SmartArt
- redigera SmartArt
- ändra SmartArt
- åtkomst till SmartArt
- SmartArt-layouttyp
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Automatisera skapande, redigering och formgivning av PowerPoint SmartArt i .NET med Aspose.Slides, med kortfattade kodexempel och prestandafokuserad vägledning."
---
## **Översikt**

Aspose.Slides gör det möjligt att skapa och hantera SmartArt-grafik i PowerPoint-presentationer programmässigt. Denna artikel förklarar hur man lägger till en SmartArt-form i en bild, får åtkomst till befintliga SmartArt-former, hittar SmartArt efter en specifik layouttyp och uppdaterar dess visuella utseende genom att ändra SmartArt-stilen eller färgstilen.

Exemplen visar hur man arbetar med SmartArt-former via presentationens bilds formsamling, kontrollerar om en form är SmartArt och sedan modifierar eller inspekterar dess egenskaper.

## **Skapa en SmartArt-form**

Aspose.Slides for .NET möjliggör nu att lägga till anpassade SmartArt-former i sina bilder från grunden. Aspose.Slides for .NET har tillhandahållit det enklaste API:t för att skapa SmartArt-former på ett lättast möjligt sätt. För att skapa en SmartArt-form i en bild, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) klass.
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en SmartArt-form genom att sätta dess LayoutType.
- Skriv den modifierade presentationen som en PPTX-fil.

```c#
 // Instansiera presentationen
 using (Presentation pres = new Presentation())
 {
 
     // Åtkomst till presentationsbilden
     ISlide slide = pres.Slides[0];
 
     // Lägg till SmartArt-form
     ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
 
     // Sparar presentationen
     pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **Få åtkomst till en SmartArt-form på en bild**

Följande kod kommer att användas för att få åtkomst till SmartArt-formerna som lagts till i presentationsbilden. I exempelkoden kommer vi att gå igenom varje form i bilden och kontrollera om den är en SmartArt-form. Om formen är av typen SmartArt kommer vi att typkonvertera den till en SmartArt-instans.

```c#
 // Läs in önskad presentation
 using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
 {
 
     // Gå igenom alla former i den första bilden
     foreach (IShape shape in pres.Slides[0].Shapes)
     {
         // Kontrollera om formen är av typen SmartArt
         if (shape is ISmartArt)
         {
             // Typkonvertera formen till SmartArtEx
             ISmartArt smart = (ISmartArt)shape;
             System.Console.WriteLine("Shape Name:" + smart.Name);
 
         }
     }
 }
```

## **Få åtkomst till en SmartArt-form med en viss LayoutType**

Följande exempel kod hjälper till att få åtkomst till SmartArt-formen med en viss LayoutType. Observera att du inte kan ändra LayoutType för SmartArt eftersom den är skrivskyddad och endast sätts när SmartArt-formen läggs till.

- Skapa en instans av `Presentation`-klassen och läs in presentationen med SmartArt-form.
- Hämta referensen till den första bilden genom att använda dess Index.
- Gå igenom varje form i den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArt om den är SmartArt.
- Kontrollera SmartArt-formen med den specifika LayoutType och utför sedan vad som krävs.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Gå igenom varje form i den första bilden
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Kontrollera om formen är av typen SmartArt
        if (shape is ISmartArt)
        {
            // Typkonvertera formen till SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Kontrollerar SmartArt-layout
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```

## **Ändra en SmartArt-forms stil**

Följande exempel kod hjälper till att få åtkomst till SmartArt-formen med en viss LayoutType.

- Skapa en instans av `Presentation`-klassen och läs in presentationen med SmartArt-form.
- Hämta referensen till den första bilden genom att använda dess Index.
- Gå igenom varje form i den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArt om den är SmartArt.
- Hitta SmartArt-formen med en viss Stil.
- Ställ in den nya Stilen för SmartArt-formen.
- Spara presentationen.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Gå igenom varje form i den första bilden
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Kontrollera om formen är av typen SmartArt
        if (shape is ISmartArt)
        {
            // Typkonvertera formen till SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Kontrollerar SmartArt-stil
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // Ändrar SmartArt-stil
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Sparar presentationen
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```

## **Ändra en SmartArt-forms färgstil**

I detta exempel kommer vi att lära oss att ändra färgstilen för en SmartArt-form. I följande exempel kod kommer vi att få åtkomst till SmartArt-formen med en viss färgstil och ändra dess stil.

- Skapa en instans av `Presentation`-klassen och läs in presentationen med SmartArt-form.
- Hämta referensen till den första bilden genom att använda dess Index.
- Gå igenom varje form i den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArt om den är SmartArt.
- Hitta SmartArt-formen med en viss Färgstil.
- Ställ in den nya Färgstilen för SmartArt-formen.
- Spara presentationen.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Gå igenom varje form i den första bilden
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Kontrollera om formen är av typen SmartArt
        if (shape is ISmartArt)
        {
            // Typkonvertera formen till SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Kontrollerar SmartArt-färgtyp
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Ändrar SmartArt-färgtyp
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Sparar presentationen
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Kan jag animera SmartArt som ett enda objekt?**

Ja. SmartArt är en form, så du kan tillämpa [standardanimationer](/slides/sv/net/powerpoint-animation/) via animations-API:t (entré, utgång, betoning, rörelsebanor) precis som för andra former.

**Hur kan jag hitta ett specifikt SmartArt på en bild om jag inte känner till dess interna ID?**

Ange och använd Alternativ text (AltText) och sök efter formen med det värdet – detta är ett rekommenderat sätt att hitta målformen.

**Kan jag gruppera SmartArt med andra former?**

Ja. Du kan gruppera SmartArt med andra former (bilder, tabeller etc.) och sedan [manipulera gruppen](/slides/sv/net/group/).

**Hur får jag en bild av ett specifikt SmartArt (t.ex. för en förhandsvisning eller rapport)?**

Exportera en miniatyr/bild av formen; biblioteket kan [rendera enskilda former](/slides/sv/net/create-shape-thumbnails/) till rasterfiler (PNG/JPG/TIFF).

**Kommer SmartArt:s utseende att bevaras vid konvertering av hela presentationen till PDF?**

Ja. Rendering‑motorn strävar efter hög trohet för [PDF‑export](/slides/sv/net/convert-powerpoint-to-pdf/), med ett antal kvalitets‑ och kompatibilitetsalternativ.