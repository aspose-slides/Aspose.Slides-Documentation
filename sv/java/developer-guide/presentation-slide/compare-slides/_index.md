---
title: Jämför presentationsbilder i Java
linktitle: Jämför bilder
type: docs
weight: 50
url: /sv/java/compare-slides/
keywords:
- jämför bilder
- bildjämförelse
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Jämför PowerPoint- och OpenDocument-presentationer programmässigt med Aspose.Slides för Java. Identifiera bildskillnader i kod snabbt."
---
## **Översikt**

Aspose.Slides gör det möjligt att jämföra bilder, layoutbilder och mästarbilder med hjälp av `equals`-metoden som tillhandahålls av gränssnittet `IBaseSlide` och klassen `BaseSlide`. Denna metod returnerar `true` när de jämförda bilderna är identiska i sin struktur och statiska innehåll.

## **Jämför två bilder**
Equals-metoden har lagts till i gränssnittet [IBaseSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IBaseSlide) och klassen [BaseSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/BaseSlide). Den returnerar true för bilder/layout och bilder/mästarbilder som är identiska i sin struktur och statiska innehåll.

Två bilder är lika om alla former, stilar, texter, animationer och andra inställningar osv. är lika. Jämförelsen tar inte hänsyn till unika identifieringsvärden, t.ex. SlideId och dynamiskt innehåll, t.ex. aktuellt datumvärde i datumplatshållare.

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

**Påverkar det att en bild är dold jämförelsen av själva bilderna?**

[Dolt status](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slide/#getHidden--) är en egenskap på presentations-/uppspelningsnivå, inte visuellt innehåll. Likheten mellan två specifika bilder bestäms av deras struktur och statiska innehåll; det faktum att en bild är dold gör inte bilderna olika.

**Tas hyperlänkar och deras parametrar med i beräkningen?**

Ja. Länkar är en del av en bilds statiska innehåll. Om URL:en eller hyperlänkåtgärden skiljer sig, betraktas detta vanligtvis som en skillnad i det statiska innehållet.

**Om ett diagram refererar till en extern Excel-fil, kommer innehållet i den filen att tas med i beräkningen?**

Nej. Jämförelsen utförs baserat på själva bilderna. Externa datakällor läses vanligen inte vid jämförelsetillfället; endast det som finns i bildens struktur och statiska tillstånd beaktas.