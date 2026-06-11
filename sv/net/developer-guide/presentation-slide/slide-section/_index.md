---
title: Hantera bildsektioner i presentationer i .NET
linktitle: Bildsektion
type: docs
weight: 100
url: /sv/net/slide-section/
keywords:
- skapa sektion
- lägga till sektion
- redigera sektion
- ändra sektion
- sektionens namn
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Optimera bildsektioner i PowerPoint och OpenDocument med Aspose.Slides för .NET – dela upp, byta namn och omordna för att effektivisera PPTX- och ODP-arbetsflöden."
---
## **Introduktion**

Med Aspose.Slides for .NET kan du organisera en PowerPoint-presentation i sektioner. Du kan skapa sektioner som innehåller specifika bilder. 

Du kan vilja skapa sektioner och använda dem för att organisera eller dela upp bilder i en presentation i logiska delar i dessa situationer:

- När du arbetar med en stor presentation tillsammans med andra personer eller ett team—och du behöver tilldela vissa bilder till en kollega eller några teammedlemmar. 
- När du har en presentation som innehåller många bilder—och du har svårt att hantera eller redigera dess innehåll samtidigt.

Idealiskt bör du skapa en sektion som samlar liknande bilder—bilderna har något gemensamt eller kan existera i en grupp baserat på en regel—och ge sektionen ett namn som beskriver bilderna i den. 

## **Skapa sektioner i presentationer**

För att lägga till en sektion som ska innehålla bilder i en presentation tillhandahåller Aspose.Slides for .NET metoden AddSection som låter dig ange namnet på sektionen du vill skapa och bilden från vilken sektionen börjar. 

Denna exempelkod visar hur du skapar en sektion i en presentation i C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 kommer att avslutas vid newSlide2 och efter det startar section2   

    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## **Ändra namn på sektioner**

Efter att du har skapat en sektion i en PowerPoint-presentation kan du bestämma dig för att ändra dess namn. 

Denna exempelkod visar hur du ändrar namnet på en sektion i en presentation i C# med Aspose.Slides:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```

## **Vanliga frågor**

**Behålls sektioner när man sparar till PPT (PowerPoint 97–2003)-formatet?**

Nej. PPT-formatet stöder inte sektionmetadata, så sektionens gruppering går förlorad vid sparande till .ppt.

**Kan en hel sektion vara "dold"?**

Nej. Endast enskilda bilder kan döljas. En sektion som en enhet har inget "dolt" tillstånd.

**Kan jag snabbt hitta en sektion via en bild och, omvänt, den första bilden i en sektion?**

Ja. En sektion definieras entydigt av sin startbild; given en bild kan du avgöra vilken sektion den tillhör, och för en sektion kan du komma åt dess första bild.