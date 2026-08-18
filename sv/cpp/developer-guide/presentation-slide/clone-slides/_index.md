---
title: Klona presentationsbilder i C++
linktitle: Klona bilder
type: docs
weight: 40
url: /sv/cpp/clone-slides/
keywords:
- klona bild
- kopiera bild
- spara bild
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Duplicera snabbt PowerPoint-bilder med Aspose.Slides för C++. Följ våra tydliga kodexempel för att automatisera PPT-skapande på några sekunder och eliminera manuellt arbete."
---
## **Introduktion**

Klona är processen att göra en exakt kopia eller replik av något. Aspose.Slides for C++ möjliggör även att skapa en kopia eller klon av vilken bild som helst och sedan infoga den klonade bilden i den aktuella eller någon annan öppen presentation. Processen för bildkloning skapar en ny bild som kan modifieras av utvecklare utan att ändra den ursprungliga bilden. Det finns flera möjliga sätt att klona en bild:

- Klona i slutet inom en presentation.
- Klona på en annan position inom en presentation.
- Klona i slutet i en annan presentation.
- Klona på en annan position i en annan presentation.
- Klona på en specifik position i en annan presentation.

In Aspose.Slides for C++ (en samling av [ISlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/)‑objekt) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑objektet tillhandahåller metoderna [AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) och [InsertClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/insertclone/) för att utföra ovanstående typer av bildkloning

## **Klona en bild i slutet av en presentation**
Bör du klona en bild och sedan använda den i samma presentationsfil i slutet av de befintliga bilderna, använd metoden [AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) enligt stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
1. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/) genom att referera till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑objektet.
1. Anropa metoden [AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/)‑objektet och skicka bilden som ska klonas som en parameter till [AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/)-metoden.
1. Skriv den modifierade presentationsfilen.

I exemplet nedan har vi klonat en bild (liggande på den första positionen – nollindex – i presentationen) till slutet av presentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}


## **Klona en bild till en annan position inom en presentation**
Bör du klona en bild och sedan använda den i samma presentationsfil men på en annan position, använd metoden [InsertClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/insertclone/) :

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
1. Instansiera klassen genom att referera till **Slides**‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑objektet.
1. Anropa metoden [InsertClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/insertclone/) som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/)‑objektet och skicka den bild som ska klonas tillsammans med indexet för den nya positionen som en parameter till [InsertClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/insertclone/)-metoden.
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi klonat en bild (liggande på nollindex – position 1 – i presentationen) till index 1 – position 2 – i presentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Klona en bild i slutet av en annan presentation**
Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, i slutet av de befintliga bilderna:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) som innehåller den presentation som bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) som innehåller målpresentationen som bilden ska läggas till i.
1. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/) genom att referera till **Slides**‑samlingen som exponeras av Presentation‑objektet i målpresentationen.
1. Anropa metoden [AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/)‑objektet och skicka bilden från källpresentationen som en parameter till [AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/)-metoden.
1. Skriv den modifierade målpresentationsfilen.

I exemplet nedan har vi klonat en bild (från första indexet i källpresentationen) till slutet av målpresentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klona en bild till en annan position i en annan presentation**
Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, på en specifik position:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) som innehåller källpresentationen som bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) som innehåller presentationen som bilden ska läggas till i.
1. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/) genom att referera till Slides‑samlingen som exponeras av Presentation‑objektet i målpresentationen.
1. Anropa metoden [InsertClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/insertclone/) som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/)‑objektet och skicka bilden från källpresentationen tillsammans med önskad position som parameter till [InsertClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/insertclone/)-metoden.
1. Skriv den modifierade målpresentationsfilen.

I exemplet nedan har vi klonat en bild (från nollindex i källpresentationen) till index 1 (position 2) i målpresentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}
## **Klona en bild på en specifik position i en annan presentation**
Om du behöver klona en bild med mästaresignal från en presentation och använda den i en annan presentation, måste du först klona den önskade mästaresignalen från källpresentationen till målpresentationen. Därefter använder du den mästaresignalen för att klona bilden med mästaresignalen. Metoden **AddClone(ISlide, IMasterSlide)** förväntar sig en mästaresignal från målpresentationen snarare än från källpresentationen. För att klona bilden med mästaresignal, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) som innehåller källpresentationen som bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) som innehåller målpresentationen som bilden ska klonas till.
1. Kom åt bilden som ska klonas tillsammans med mästaresignalen.
1. Instansiera klassen [IMasterSlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslidecollection/) genom att referera till Masters‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑objektet i målpresentationen.
1. Anropa metoden [AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) som exponeras av [IMasterSlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslidecollection/)‑objektet och skicka mästaren från käll‑PPTX som ska klonas som en parameter till [AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/)-metoden.
1. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/) genom att sätta referensen till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑objektet i målpresentationen.
1. Anropa metoden [AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/)‑objektet och skicka bilden från källpresentationen som ska klonas samt mästaresignalen som en parameter till [AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/)-metoden.
1. Skriv den modifierade målpresentationsfilen.

I exemplet nedan har vi klonat en bild med mästare (liggande på nollindex i källpresentationen) till slutet av målpresentationen med mästaren från källbilden.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}
## **Klona en bild i slutet av ett specificerat avsnitt**
Om du vill klona en bild och sedan använda den i samma presentationsfil men i ett annat avsnitt, använd metoden [**AddClone()**](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) som exponeras av gränssnittet [**ISlideCollection** ](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/)interface. Aspose.Slides for C++ möjliggör att klona en bild från det första avsnittet och sedan infoga den klonade bilden i det andra avsnittet i samma presentation.

Följande kodexempel visar hur du klonar en bild och infogar den klonade bilden i ett specificerat avsnitt.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Säkerställ matchande bildstorlek**

När du klonar bilder till en annan presentation, se till att målpresentationen har samma bildstorlek som källan. Om bildstorlekarna skiljer sig, skalar inte Aspose.Slides automatiskt de klonade formerna – deras ursprungliga koordinater och dimensioner bevaras, vilket kan leda till att innehållet blir feljusterat eller sträcker sig utanför bildens kanter.

Du kan sätta målpresentationens bildstorlek så att den matchar källan innan du klonar mästaren och bilden:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

Gör detta innan du klonar mästaren och bilden.

## **FAQ**

**Klonas talarnoteringar och granskarkommentarer?**

Ja. Noteringssidan och granskarkommentarerna inkluderas i klonen. Om du inte vill ha dem, [ta bort dem](/slides/sv/cpp/presentation-notes/) efter infogning.

**Hur hanteras diagram och deras datakällor?**

Diagramobjektet, formateringen och de inbäddade data kopieras. Om diagrammet var länkat till en extern källa (t.ex. en OLE‑inbäddad arbetsbok) bevaras den länken som ett [OLE-objekt](/slides/sv/cpp/manage-ole/). Efter att ha flyttat mellan filer, kontrollera datatillgänglighet och uppdateringsbeteende.

**Kan jag kontrollera infogningspositionen och avsnitten för klonen?**

Ja. Du kan infoga klonen på ett specifikt bildindex och placera den i ett valt [avsnitt](/slides/sv/cpp/slide-section/). Om målavsnittet inte finns, skapa det först och flytta sedan bilden dit.