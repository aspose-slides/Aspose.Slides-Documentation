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
description: "Duplicera snabbt PowerPoint-bilder med Aspose.Slides för C++. Följ våra tydliga kodexempel för att automatisera skapandet av PPT på några sekunder och eliminera manuellt arbete."
---
## **Introduktion**

Kloning är processen att göra en exakt kopia eller replika av något. Aspose.Slides för C++ gör det också möjligt att skapa en kopia eller klon av vilken bild som helst och sedan infoga den klonade bilden i den aktuella eller någon annan öppen presentation. Processen för bildkloning skapar en ny bild som kan modifieras av utvecklare utan att ändra den ursprungliga bilden. Det finns flera möjliga sätt att klona en bild:

- Kloning i slutet av en presentation.
- Kloning på en annan position i presentationen.
- Kloning i slutet av en annan presentation.
- Kloning på en annan position i en annan presentation.
- Kloning på en specifik position i en annan presentation.

I Aspose.Slides för C++, (en samling av [ISlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/) objekt) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑objektet tillhandahåller [AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) och [InsertClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/insertclone/)‑metoderna för att utföra ovanstående typer av bildkloning

## **Klona en bild i slutet av en presentation**
Om du vill klona en bild och sedan använda den i samma presentationsfil i slutet av de befintliga bilderna, använd [AddClone]-metoden enligt stegen nedan:

1. Skapa en instans av [Presentation]-klassen.
1. Instansiera [ISlideCollection]-klassen genom att referera till Slides‑samlingen som exponeras av [Presentation]-objektet.
1. Anropa [AddClone]-metoden som exponeras av [ISlideCollection]-objektet och skicka bilden som ska klonas som en parameter till [AddClone]-metoden.
1. Skriv den modifierade presentationsfilen.

I exemplet nedan har vi klonat en bild (som ligger på den första positionen – nollindex – i presentationen) till slutet av presentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Klona en bild till en annan position inom en presentation**
Om du vill klona en bild och sedan använda den i samma presentationsfil men på en annan position, använd [InsertClone]-metoden:

1. Skapa en instans av [Presentation]-klassen.
1. Instansiera klassen genom att referera till **Slides**‑samlingen som exponeras av [Presentation]-objektet.
1. Anropa [InsertClone]-metoden som exponeras av [ISlideCollection]-objektet och skicka bilden som ska klonas tillsammans med indexet för den nya positionen som en parameter till [InsertClone]-metoden.
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi klonat en bild (som ligger på nollindex – position 1 – i presentationen) till index 1 – Position 2 – i presentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Klona en bild i slutet av en annan presentation**
Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, i slutet av de befintliga bilderna:

1. Skapa en instans av [Presentation]-klassen som innehåller presentationen som bilden ska klonas från.
1. Skapa en instans av [Presentation]-klassen som innehåller målpresentationen som bilden ska läggas till i.
1. Instansiera [ISlideCollection]-klassen genom att referera till **Slides**‑samlingen som exponeras av Presentation‑objektet för målpresentationen.
1. Anropa [AddClone]-metoden som exponeras av [ISlideCollection]-objektet och skicka bilden från källpresentationen som en parameter till [AddClone]-metoden.
1. Skriv den modifierade mål‑presentationsfilen.

I exemplet nedan har vi klonat en bild (från det första indexet i källpresentationen) till slutet av målpresentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klona en bild till en annan position i en annan presentation**
Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, på en specifik position:

1. Skapa en instans av [Presentation]-klassen som innehåller källpresentationen som bilden ska klonas från.
1. Skapa en instans av [Presentation]-klassen som innehåller presentationen som bilden ska läggas till i.
1. Instansiera [ISlideCollection]-klassen genom att referera till Slides‑samlingen som exponeras av Presentation‑objektet för målpresentationen.
1. Anropa [InsertClone]-metoden som exponeras av [ISlideCollection]-objektet och skicka bilden från källpresentationen tillsammans med önskad position som parameter till [InsertClone]-metoden.
1. Skriv den modifierade mål‑presentationsfilen.

I exemplet nedan har vi klonat en bild (från nollindex i källpresentationen) till index 1 (position 2) i målpresentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klona en bild på en specifik position i en annan presentation**
Om du behöver klona en bild tillsammans med master‑bilden från en presentation och använda den i en annan presentation, måste du först klona den önskade master‑bilden från källpresentationen till målpresentationen. Därefter använder du den master‑bilden för att klona bilden med master. **AddClone(ISlide, IMasterSlide)** förväntar sig master‑bilden från målpresentationen snarare än från källpresentationen. Följ stegen nedan för att klona bilden med master:

1. Skapa en instans av [Presentation]-klassen som innehåller källpresentationen som bilden ska klonas från.
1. Skapa en instans av [Presentation]-klassen som innehåller målpresentationen som bilden ska klonas till.
1. Åtkom bilden som ska klonas tillsammans med master‑bilden.
1. Instansiera [IMasterSlideCollection]-klassen genom att referera till Masters‑samlingen som exponeras av [Presentation]-objektet för målpresentationen.
1. Anropa [AddClone]-metoden som exponeras av [IMasterSlideCollection]-objektet och skicka master‑bilden från käll‑PPTX som ska klonas som parameter till [AddClone]-metoden.
1. Instansiera [ISlideCollection]-klassen genom att sätta referensen till Slides‑samlingen som exponeras av [Presentation]-objektet för målpresentationen.
1. Anropa [AddClone]-metoden som exponeras av [ISlideCollection]-objektet och skicka bilden från källpresentationen som ska klonas samt master‑bilden som parameter till [AddClone]-metoden.
1. Skriv den modifierade mål‑presentationsfilen.

I exemplet nedan har vi klonat en bild med master (som ligger på nollindex i källpresentationen) till slutet av målpresentationen med master från käll‑bilden.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Klona en bild i slutet av ett specificerat avsnitt**
Om du vill klona en bild och sedan använda den i samma presentationsfil men i ett annat avsnitt, använd då [**AddClone()**]-metoden som exponeras av [**ISlideCollection**]-gränssnittet. Aspose.Slides för C++ gör det möjligt att klona en bild från det första avsnittet och sedan infoga den klonade bilden i det andra avsnittet av samma presentation.

Följande kodsnutt visar hur du klonar en bild och infogar den klonade bilden i ett specificerat avsnitt.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Vanliga frågor**

**Klonas talarnoteringar och granskningskommentarer?**

Ja. Notessidan och granskningskommentarerna ingår i klonen. Om du inte vill ha dem, [ta bort dem](/slides/sv/cpp/presentation-notes/) efter infogning.

**Hur hanteras diagram och deras datakällor?**

Diagramobjektet, formateringen och inbäddade data kopieras. Om diagrammet var länkat till en extern källa (t.ex. en OLE‑inbäddad arbetsbok) bevaras den länken som ett [OLE‑objekt](/slides/sv/cpp/manage-ole/). Efter flytt mellan filer, verifiera datatillgänglighet och uppdateringsbeteende.

**Kan jag styra infogningsposition och avsnitt för klonen?**

Ja. Du kan infoga klonen på ett specifikt bildindex och placera den i ett valt [avsnitt](/slides/sv/cpp/slide-section/). Om målavsnittet inte finns, skapa det först och flytta sedan bilden dit.