---
title: Jämför presentationsbilder i .NET
linktitle: Jämför bilder
type: docs
weight: 50
url: /sv/net/compare-slides/
keywords:
- jämför bilder
- bildjämförelse
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Jämför PowerPoint- och OpenDocument-presentationer programatiskt med Aspose.Slides för .NET. Identifiera snabbt skillnader i bilder i koden."
---
## **Översikt**

Aspose.Slides låter dig jämföra bilder, layoutbilder och masterbilder med hjälp av `Equals`‑metoden som tillhandahålls av `IBaseSlide`‑gränssnittet och `BaseSlide`‑klassen. Denna metod returnerar `true` när de jämförda bilderna är identiska i sin struktur och statiska innehåll.

## **Jämför två bilder**

`Equals`‑metoden har lagts till i [IBaseSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseslide)‑gränssnittet och [BaseSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/baseslide)‑klassen. Den returnerar true för layout‑ och master‑bilder som är identiska i sin struktur och statiska innehåll.

Två bilder är lika om alla former, stilar, texter, animationer och andra inställningar är identiska etc. Jämförelsen tar inte hänsyn till unika identifierarvärden, t.ex. SlideId, eller dynamiskt innehåll, t.ex. aktuellt datumvärde i datum‑platshållaren.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```

## **Vanliga frågor**

**Påverkar det att en bild är dold jämförelsen av själva bilderna?**

[Hidden status](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/hidden/) är en egenskap på presentations‑/uppspelningsnivå, inte visuellt innehåll. Likheten mellan två specifika bilder bestäms av deras struktur och statiska innehåll; det faktum att en bild är dold gör inte bilderna olika.

**Tas hyperlänkar och deras parametrar med i beräkningen?**

Ja. Länkar är en del av bildens statiska innehåll. Om URL:en eller hyperlänksåtgärden skiljer sig, behandlas det vanligtvis som en skillnad i det statiska innehållet.

**Om ett diagram hänvisar till en extern Excel‑fil, tas innehållet i den filen med i beräkningen?**

Nej. Jämförelsen utförs baserat på själva bilderna. Externa datakällor läses i allmänhet inte vid jämförelsetiden; endast det som finns i bildens struktur och statiska tillstånd beaktas.