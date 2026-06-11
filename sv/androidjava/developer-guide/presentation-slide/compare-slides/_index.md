---
title: Jämför presentationsbilder på Android
linktitle: Jämför bilder
type: docs
weight: 50
url: /sv/androidjava/compare-slides/
keywords:
- jämföra bilder
- bildjämförelse
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Jämför PowerPoint- och OpenDocument-presentationer programatiskt med Aspose.Slides för Android. Identifiera bildskillnader i Java-kod snabbt."
---
## **Översikt**

Aspose.Slides låter dig jämföra bilder, layoutbilder och masterbilder med hjälp av `equals`-metoden som tillhandahålls av `IBaseSlide`-gränssnittet och `BaseSlide`-klassen. Denna metod returnerar `true` när de jämförda bilderna är identiska i sin struktur och statiska innehåll.

## **Jämför två bilder**
Equals-metoden har lagts till i gränssnittet [IBaseSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IBaseSlide) och klassen [BaseSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/BaseSlide). Den returnerar true för bild-/layout- och bild-/master-bilder som är identiska i sin struktur och statiska innehåll.

Två bilder är lika om alla former, stilar, texter, animationer och andra inställningar osv. är lika. Jämförelsen tar inte hänsyn till unika identifieringsvärden, t.ex. SlideId, eller dynamiskt innehåll, t.ex. aktuellt datumvärde i datum-platshållare.

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **Vanliga frågor**

**Påverkar det att en bild är dold jämförelsen av bilderna själva?**

[Hidden status](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slide/#getHidden--) är en egenskap på presentations-/uppspelningsnivå, inte visuellt innehåll. Likheten mellan två specifika bilder bestäms av deras struktur och statiska innehåll; det faktum att en bild är dold gör inte bilderna olika.

**Tas hyperlänkar och deras parametrar med i beräkningen?**

Ja. Länkar är en del av en bilds statiska innehåll. Om URL:en eller hyperlänkens åtgärd skiljer sig, behandlas detta vanligtvis som en skillnad i det statiska innehållet.

**Om ett diagram hänvisar till en extern Excel-fil, kommer innehållet i den filen att tas med i beräkningen?**

Nej. Jämförelsen utförs baserat på själva bilderna. Externa datakällor läses normalt inte vid jämförelsetillfället; endast det som finns i bildens struktur och statiska tillstånd beaktas.