---
title: Jämför presentationsbilder i C++
linktitle: Jämför bilder
type: docs
weight: 50
url: /sv/cpp/compare-slides/
keywords:
- jämför bilder
- bildjämförelse
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Jämför PowerPoint- och OpenDocument-presentationer programatiskt med Aspose.Slides för C++. Identifiera bildskillnader i koden snabbt."
---
## **Översikt**

Aspose.Slides låter dig jämföra bilder, layoutbilder och masterbilder med hjälp av `Equals`-metoden som tillhandahålls av `IBaseSlide`-gränssnittet och `BaseSlide`-klassen. Denna metod returnerar `true` när de jämförda bilderna är identiska i sin struktur och statiska innehåll.

## **Jämför två bilder**
Equals-metoden har lagts till i `IBaseSlide`-gränssnittet och `BaseSlide`-klassen. Den returnerar true för bilder / layoutbilder / masterbilder som är identiska i sin struktur och statiska innehåll.

Två bilder är lika om alla former, stilar, texter, animationer och andra inställningar osv. Sammanligningen tar inte hänsyn till unika identifierarvärden, t.ex. SlideId, och dynamiskt innehåll, t.ex. det aktuella datumvärdet i datumplatshållaren.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}

## **Vanliga frågor**

**Påverkar det att en bild är dold jämförelsen av själva bilderna?**

[Hidden status](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slide/get_hidden/) är en presentations-/uppspelningsnivåegenskap, inte visuellt innehåll. Likheten mellan två specifika bilder bestäms av deras struktur och statiska innehåll; själva faktumet att en bild är dold gör inte bilderna olika.

**Tas hyperlänkar och deras parametrar med i beräkningen?**

Ja. Länkar är en del av en bilds statiska innehåll. Om URL:en eller hyperlänksåtgärden skiljer sig, behandlas detta vanligtvis som en skillnad i det statiska innehållet.

**Om ett diagram refererar till en extern Excel-fil, tas innehållet i den filen med i beräkningen?**

Nej. Jämförelsen utförs baserat på själva bilderna. Externa datakällor läses vanligtvis inte vid jämförelsetillfället; endast det som finns i bildens struktur och statiska tillstånd beaktas.