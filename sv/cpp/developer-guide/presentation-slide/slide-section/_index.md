---
title: Hantera bildsektioner i presentationer med C++
linktitle: Bildsektion
type: docs
weight: 100
url: /sv/cpp/slide-section/
keywords:
- skapa sektion
- lägga till sektion
- redigera sektion
- ändra sektion
- sektionens namn
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Strömlinjeforma bildsektioner i PowerPoint och OpenDocument med Aspose.Slides för C++ — dela, byt namn och omordna för att optimera PPTX- och ODP-arbetsflöden."
---
## **Introduktion**

Med Aspose.Slides för C++ kan du organisera en PowerPoint‑presentation i sektioner. Du kan skapa sektioner som innehåller specifika bilder. 

Du kanske vill skapa sektioner och använda dem för att organisera eller dela upp bilder i en presentation i logiska delar i följande situationer:

- När du arbetar med en stor presentation tillsammans med andra personer eller ett team – och du behöver tilldela vissa bilder till en kollega eller några teammedlemmar. 
- När du har en presentation som innehåller många bilder – och du har svårt att hantera eller redigera dess innehåll på en gång.

Idealiskt bör du skapa en sektion som innehåller liknande bilder – bilderna har något gemensamt eller kan finnas i en grupp baserad på en regel – och ge sektionen ett namn som beskriver bilderna i den. 

## **Skapa sektioner i presentationer**

För att lägga till en sektion som kommer att innehålla bilder i en presentation tillhandahåller Aspose.Slides för C++ metoden AddSection som låter dig ange namnet på sektionen du vill skapa och bilden där sektionen börjar. 

Den här exempelkoden visar hur du skapar en sektion i en presentation i C++:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 kommer att avslutas vid newSlide2 och därefter startar section2   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## **Ändra namn på sektioner**

Efter att du har skapat en sektion i en PowerPoint‑presentation kan du besluta att ändra dess namn. 

Den här exempelkoden visar hur du ändrar namnet på en sektion i en presentation i C++ med hjälp av Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```

## **FAQ**

**Behålls sektioner när man sparar till PPT (PowerPoint 97–2003) format?**

Nej. PPT‑formatet stöder inte sektionsmetadata, så sektiongruppering går förlorad när du sparar till .ppt.

**Kan en hel sektion vara "dold"?**

Nej. Endast enskilda bilder kan döljas. En sektion som enhet har inget "dolt" tillstånd.

**Kan jag snabbt hitta en sektion via en bild och, omvänt, den första bilden i en sektion?**

Ja. En sektion definieras unikt av sin startbild; givet en bild kan du avgöra vilken sektion den tillhör, och för en sektion kan du komma åt dess första bild.