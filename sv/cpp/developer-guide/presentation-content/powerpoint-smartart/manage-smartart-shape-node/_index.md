---
title: Hantera SmartArt-formnoder i presentationer med C++
linktitle: SmartArt-formnod
type: docs
weight: 30
url: /sv/cpp/manage-smartart-shape-node/
keywords:
- SmartArt-nod
- barnnod
- lägg till nod
- nodposition
- åtkomstnod
- ta bort nod
- anpassad position
- assistentnod
- fyllningsformat
- rendera nod
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Hantera SmartArt-formnoder i PPT och PPTX med Aspose.Slides för C++. Få tydliga kodexempel och tips för att effektivisera dina presentationer."
---
## **Översikt**

SmartArt‑grafik i PowerPoint‑presentationer organiseras genom noder som innehåller text och definierar diagrammets struktur. Aspose.Slides låter dig arbeta med dessa SmartArt‑noder programmässigt: lägga till nya noder och barnnoder, infoga barnnoder på en specifik position, komma åt befintliga noder och läsa deras text, nivå och position.

Denna artikel förklarar hur du hanterar SmartArt‑formnodernas noder. Den visar hur du tar bort noder, arbetar med barnnoder efter index eller position, ändrar en assistentnod till en normal nod, justerar position, storlek och rotation för SmartArt‑nodformer, anger nodens fyllningsformat och genererar en miniatyrbild för en SmartArt‑barnnod.

## **Lägg till en SmartArt‑nod**
Aspose.Slides för C++ har tillhandahållit det enklaste API‑et för att hantera SmartArt‑former på ett lättillgängligt sätt. Följande exempel hjälper dig att lägga till nod och barnnod i en SmartArt‑form.

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) klassen och läs in presentationen med SmartArt‑form.
- Hämta referensen till den första bilden genom att använda dess Index.
- Gå igenom varje form i den första bilden.
- Kontrollera om formen är av SmartArt‑typ och typkonvertera vald form till SmartArt om den är SmartArt.
- Lägg till en ny Node i SmartArt‑formens NodeCollection och sätt texten i TextFrame.
- Lägg nu till en Child Node i den nyss tillagda SmartArt‑Node och sätt texten i TextFrame.
- Spara presentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **Lägg till en SmartArt‑nod på en specifik position**
I följande exempel visar vi hur du lägger till barnnoder som tillhör respektive noder i SmartArt‑formen på en viss position.

- Skapa en instans av `Presentation` klassen.
- Hämta referensen till den första bilden genom att använda dess Index.
- Lägg till en StackedList‑typ SmartArt‑form i den åtkomna bilden.
- Kom åt den första noden i den tillagda SmartArt‑formen.
- Lägg nu till Child Node för den valda noden på position 2 och sätt dess text.
- Spara presentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **Kom åt en SmartArt‑nod**
Följande kodexempel hjälper dig att komma åt noder i en SmartArt‑form. Observera att du inte kan ändra LayoutType för SmartArt eftersom den är skrivskyddad och endast sätts när SmartArt‑formen läggs till.

- Skapa en instans av `Presentation` klassen och läs in presentationen med SmartArt‑form.
- Hämta referensen till den första bilden genom att använda dess Index.
- Gå igenom varje form i den första bilden.
- Kontrollera om formen är av SmartArt‑typ och typkonvertera vald form till SmartArt om den är SmartArt.
- Gå igenom alla Nodes i SmartArt‑formen.
- Kom åt och visa information såsom SmartArt‑nodens position, nivå och text.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **Kom åt en SmartArt‑barnnod**
Följande kodexempel hjälper dig att komma åt barnnoder som tillhör respektive noder i SmartArt‑formen.

- Skapa en instans av PresentationEx‑klassen och läs in presentationen med SmartArt‑form.
- Hämta referensen till den första bilden genom att använda dess Index.
- Gå igenom varje form i den första bilden.
- Kontrollera om formen är av SmartArt‑typ och typkonvertera vald form till SmartArtEx om den är SmartArt.
- Gå igenom alla Nodes i SmartArt‑formen.
- För varje vald SmartArt‑formenod, gå igenom alla Child Nodes i den specifika noden.
- Kom åt och visa information såsom barnnodens position, nivå och text.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **Kom åt en SmartArt‑barnnod på en specifik position**
I detta exempel lär vi oss att komma åt barnnoder på en viss position som tillhör respektive noder i SmartArt‑formen.

- Skapa en instans av `Presentation` klassen.
- Hämta referensen till den första bilden genom att använda dess Index.
- Lägg till en StackedList‑typ SmartArt‑form.
- Kom åt den tillagda SmartArt‑formen.
- Kom åt noden med index 0 för den åtkomna SmartArt‑formen.
- Kom nu åt Child Node på position 1 för den åtkomna SmartArt‑nod som använder metoden GetNodeByPosition().
- Kom åt och visa information såsom barnnodens position, nivå och text.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **Ta bort en SmartArt‑nod**
I detta exempel lär vi oss att ta bort noder i en SmartArt‑form.

- Skapa en instans av `Presentation` klassen och läs in presentationen med SmartArt‑form.
- Hämta referensen till den första bilden genom att använda dess Index.
- Gå igenom varje form i den första bilden.
- Kontrollera om formen är av SmartArt‑typ och typkonvertera vald form till SmartArt om den är SmartArt.
- Kontrollera om SmartArt har fler än 0 noder.
- Välj SmartArt‑nod som ska tas bort.
- Ta nu bort den valda noden med metoden RemoveNode().
- Spara presentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **Ta bort en SmartArt‑nod på en specifik position**
I detta exempel lär vi oss att ta bort noder i en SmartArt‑form på en viss position.

- Skapa en instans av `Presentation` klassen och läs in presentationen med SmartArt‑form.
- Hämta referensen till den första bilden genom att använda dess Index.
- Gå igenom varje form i den första bilden.
- Kontrollera om formen är av SmartArt‑typ och typkonvertera vald form till SmartArt om den är SmartArt.
- Välj SmartArt‑formens nod med index 0.
- Kontrollera nu om den valda SmartArt‑nod har fler än 2 barnnoder.
- Ta nu bort noden på position 1 med metoden RemoveNodeByPosition().
- Spara presentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **Ange en anpassad position för en SmartArt‑barnnod**
Aspose.Slides stödjer nu att ställa in egenskaperna X och Y för SmartArtShape. Kodsnutten nedan visar hur du anger en anpassad position, storlek och rotation för SmartArtShape; observera också att tillsats av nya noder orsakar en omräkning av alla noders positioner och storlekar.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **Kontrollera en assistentnod**
I följande kodexempel undersöker vi hur man identifierar Assistant Nodes i SmartArt‑nodsamlingen och ändrar dem.

- Skapa en instans av PresentationEx‑klassen och läs in presentationen med SmartArt‑form.
- Hämta referensen till den andra bilden genom att använda dess Index.
- Gå igenom varje form i den första bilden.
- Kontrollera om formen är av SmartArt‑typ och typkonvertera vald form till SmartArtEx om den är SmartArt.
- Gå igenom alla noder i SmartArt‑formen och kontrollera om de är Assistant Nodes.
- Ändra status för Assistant Node till en normal nod.
- Spara presentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **Ange en nodes fyllningsformat**
Aspose.Slides för C++ möjliggör att lägga till anpassade SmartArt‑former och ange deras fyllningsformat. Denna artikel förklarar hur du skapar och kommer åt SmartArt‑former samt anger deras fyllningsformat med Aspose.Slides för C++.

Följ stegen nedan:

- Skapa en instans av `Presentation` klassen.
- Hämta referensen till en bild genom dess index.
- Lägg till en SmartArt‑form genom att ange dess LayoutType.
- Ange FillFormat för SmartArt‑formens noder.
- Skriv den ändrade presentationen som en PPTX‑fil.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **Generera en miniatyrbild av en SmartArt‑barnnod**
Utvecklare kan generera en miniatyrbild av en barnnod i SmartArt genom att följa stegen nedan:

1. Instansiera `Presentation` klassen som representerar PPTX‑filen.
2. Lägg till SmartArt.
3. Hämta referensen till en nod genom att använda dess Index.
4. Hämta miniatyrbilden.
5. Spara miniatyrbilden i önskat bildformat.

Exemplet nedan genererar en miniatyrbild av en SmartArt‑barnnod

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Stöds SmartArt‑animation?**

Ja. SmartArt behandlas som en vanlig form, så du kan [tillämpa standardanimationer](/slides/sv/cpp/shape-animation/) (ingång, utgång, betoning, rörelsebanor) och justera timing. Du kan även animera former inuti SmartArt‑noder vid behov.

**Hur kan jag på ett pålitligt sätt lokalisera en specifik SmartArt på en bild om dess interna ID är okänt?**

Tilldela och sök efter [alternativ text]((https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/set_alternativetext/)). Genom att sätta en distinkt AltText på SmartArt kan du hitta den programmässigt utan att förlita dig på interna identifierare.

**Bevaras SmartArt‑utseendet när presentationen konverteras till PDF?**

Ja. Aspose.Slides renderar SmartArt med hög visuell noggrannhet vid [PDF‑export](/slides/sv/cpp/convert-powerpoint-to-pdf/), och bevarar layout, färger och effekter.

**Kan jag extrahera en bild av hela SmartArt (för förhandsgranskningar eller rapporter)?**

Ja. Du kan rendera en SmartArt‑form till [rasterformat]((https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/getimage/)) eller till [SVG]((https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/writeassvg/)) för skalbar vektoroutput, vilket är lämpligt för miniatyrer, rapporter eller webbbruk.