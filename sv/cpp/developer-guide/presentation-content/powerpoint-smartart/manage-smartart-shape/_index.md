---
title: Hantera SmartArt-grafik i presentationer med C++
linktitle: SmartArt-grafik
type: docs
weight: 20
url: /sv/cpp/manage-smartart-shape/
keywords:
- SmartArt-objekt
- SmartArt-grafik
- SmartArt-stil
- SmartArt-färg
- skapa SmartArt
- lägga till SmartArt
- redigera SmartArt
- ändra SmartArt
- åtkomst SmartArt
- SmartArt-layouttyp
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Automatisera skapande, redigering och formgivning av PowerPoint SmartArt i C++ med Aspose.Slides, med korta kodexempel och prestandafokuserad vägledning."
---
## **Översikt**

Aspose.Slides tillåter dig att skapa och hantera SmartArt-grafik i PowerPoint-presentationer programatiskt. Denna artikel förklarar hur du lägger till en SmartArt-form på en bild, får åtkomst till befintliga SmartArt-former, hittar SmartArt efter en specifik layouttyp och uppdaterar dess visuella utseende genom att ändra SmartArt-stilen eller färgstilen.

Exemplen visar hur du arbetar med SmartArt-former via presentationens bilds formsamling, kontrollerar om en form är SmartArt och sedan modifierar eller inspekterar dess egenskaper.

## **Skapa en SmartArt-form**

Aspose.Slides för C++ möjliggör nu att lägga till anpassade SmartArt-former i deras bilder från grunden. Aspose.Slides för C++ har tillhandahållit det enklaste API:et för att skapa SmartArt-former på det lättaste sättet. För att skapa en SmartArt-form i en bild, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) klass.
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en SmartArt-form genom att ange dess LayoutType.
- Skriv den modifierade presentationen som en PPTX-fil.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}

## **Åtkomst till en SmartArt-form på en bild**

Följande kod kommer att användas för att få åtkomst till SmartArt-formerna som lagts till i presentationsbilden. I exempelkoden kommer vi att gå igenom varje form i bilden och kontrollera om den är en SmartArt-form. Om formen är av typen SmartArt kommer vi att typkonvertera den till en SmartArt-instans.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **Åtkomst till en SmartArt-form med en viss layouttyp**

Följande exempel kod hjälper dig att få åtkomst till SmartArt-formen med en viss LayoutType. Observera att du inte kan ändra LayoutType för SmartArt eftersom den är skrivskyddad och endast sätts när SmartArt-formen läggs till.

- Skapa en instans av `Presentation` klass och ladda presentationen med SmartArt-form.
- Hämta referensen till den första bilden genom att använda dess Index.
- Gå igenom varje form i den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArt om den är SmartArt.
- Kontrollera SmartArt-formen med den specifika LayoutType och utför det som krävs efteråt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}

## **Ändra en SmartArt-formsstil**

Följande exempel kod hjälper dig att få åtkomst till SmartArt-formen med en viss LayoutType.

- Skapa en instans av `Presentation` klass och ladda presentationen med SmartArt-form.
- Hämta referensen till den första bilden genom att använda dess Index.
- Gå igenom varje form i den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArt om den är SmartArt.
- Hitta SmartArt-formen med en viss Style.
- Ställ in den nya Style för SmartArt-formen.
- Spara presentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}

## **Ändra en SmartArt-forms färgstil**

I det här exemplet kommer vi att lära oss att förändra färgstilen för en SmartArt-form. I följande exempel kod kommer vi att få åtkomst till SmartArt-formen med en viss färgstil och ändra dess stil.

- Skapa en instans av `Presentation` klass och ladda presentationen med SmartArt-form.
- Hämta referensen till den första bilden genom att använda dess Index.
- Gå igenom varje form i den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArt om den är SmartArt.
- Hitta SmartArt-formen med en viss Color Style.
- Ställ in den nya Color Style för SmartArt-formen.
- Spara presentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **Vanliga frågor**

**Kan jag animera SmartArt som ett enda objekt?**

Ja. SmartArt är en form, så du kan tillämpa [standardanimationer](/slides/sv/cpp/powerpoint-animation/) via animations‑API:t (ingång, utgång, betoning, rörelsespår) precis som för andra former.

**Hur kan jag hitta en specifik SmartArt på en bild om jag inte känner till dess interna ID?**

Ange och använd alternativ text (AltText) och sök efter formen med det värdet – detta är ett rekommenderat sätt att hitta målformen.

**Kan jag gruppera SmartArt med andra former?**

Ja. Du kan gruppera SmartArt med andra former (bilder, tabeller osv.) och sedan [manipulera gruppen](/slides/sv/cpp/group/).

**Hur får jag en bild av en specifik SmartArt (t.ex. för en förhandsgranskning eller rapport)?**

Exportera en miniatyr/bild av formen; biblioteket kan [rendera enskilda former](/slides/sv/cpp/create-shape-thumbnails/) till rasterfiler (PNG/JPG/TIFF).

**Kommer SmartArt-utseendet att bevaras när hela presentationen konverteras till PDF?**

Ja. Rendering‑motorn siktar på hög noggrannhet för [PDF‑export](/slides/sv/cpp/convert-powerpoint-to-pdf/), med ett antal kvalitets‑ och kompatibilitetsalternativ.