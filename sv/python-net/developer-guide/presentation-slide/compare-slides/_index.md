---
title: Jämför presentationsbilder i Python
linktitle: Jämför bilder
type: docs
weight: 50
url: /sv/python-net/compare-slides/
keywords:
- jämför bilder
- bildjämförelse
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Jämför PowerPoint- och OpenDocument-presentationer programatiskt med Aspose.Slides för Python via .NET. Identifiera skillnader i bilder i koden snabbt."
---
## **Översikt**

Aspose.Slides låter dig jämföra bilder, layout-bilder och master-bilder med hjälp av `equals`-metoden som tillhandahålls av klassen `BaseSlide`. Metoden returnerar `True` när de jämförda bilderna är identiska i sin struktur och statiska innehåll.

## **Jämför två bilder**
`equals`-metoden har lagts till i klassen [BaseSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslide/). Den returnerar true för bilder/layout-bilder och bilder/master-bilder som är identiska i sin struktur och statiska innehåll.

Två bilder är lika om alla former, stilar, texter, animationer och andra inställningar ... osv. Jämförelsen tar inte hänsyn till unika identifieringsvärden, t.ex. SlideId, och dynamiskt innehåll, t.ex. aktuellt datumvärde i datum-platshållare.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i].equals(p2.masters[j]):
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```

## **FAQ**

**Påverkar det att en bild är dold jämförelsen av bilderna själva?**

[Hidden status](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/hidden/) är en egenskap på presentations-/uppspelningsnivå, inte visuellt innehåll. Likheten mellan två specifika bilder bestäms av deras struktur och statiska innehåll; det faktum att en bild är dold gör inte bilderna olika.

**Tas hyperlänkar och deras parametrar med i beräkningen?**

Ja. Länkar är en del av en bilds statiska innehåll. Om URL:en eller hyperlänk-åtgärden skiljer sig, behandlas det vanligtvis som en skillnad i statiskt innehåll.

**Om ett diagram refererar till en extern Excel-fil, kommer innehållet i den filen att tas med?**

Nej. Jämförelsen görs baserat på bilderna själva. Externa datakällor läses vanligtvis inte vid jämförelsetillfället; endast det som finns i bildens struktur och statiska tillstånd beaktas.