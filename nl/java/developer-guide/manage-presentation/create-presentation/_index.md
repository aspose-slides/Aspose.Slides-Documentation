---
title: Maak presentaties in Java
linktitle: Maak presentatie
type: docs
weight: 10
url: /nl/java/create-presentation/
keywords:
- presentatie maken
- nieuwe presentatie
- PPT maken
- nieuwe PPT
- PPTX maken
- nieuwe PPTX
- ODP maken
- nieuwe ODP
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Maak presentaties in Java met Aspose.Slides—produceer PPT-, PPTX- en ODP-bestanden, profiteer van OpenDocument-ondersteuning, en sla ze programmatisch op voor betrouwbare resultaten."
---
## **Overzicht**

Dit artikel laat zien hoe u een presentatie maakt in Aspose.Slides, een vorm met tekst toevoegt aan de eerste dia, en het resultaat opslaat als een PPTX‑bestand. Om een bestaande presentatie te openen en op te slaan in een ander formaat, zie [Presentaties openen](/slides/nl/java/open-presentation/) en [Presentaties opslaan](/slides/nl/java/save-presentation/). Een korte FAQ aan het einde behandelt veelvoorkomende vragen over formaten, sjablonen, diagrootte, eenheden, geheugengebruik, threading, licenties, digitale handtekeningen en VBA‑ondersteuning.

Voordat u begint, voegt u Aspose.Slides for Java toe aan uw project vanuit de Maven‑repository van Aspose. Zie [Installatie](/slides/nl/java/installation/) voor de Maven‑configuratie en voor wat Linux daarnaast nodig heeft.

## **Een presentatie maken**

Een PowerPoint‑bestand vanaf nul maken in Aspose.Slides for Java begint met een instantie van de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑klasse. De constructor levert een lege presentatie met één dia, klaar voor vormen, tekst, grafieken of andere inhoud die uw applicatie nodig heeft. Zodra u die dia wijzigt of nieuwe toevoegt, kunt u het resultaat opslaan in PPTX, het oudere PPT‑formaat of OpenDocument‑formaten.

Om een presentatie te maken en een vorm met tekst op de eerste dia te plaatsen, volgt u deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑klasse. Een nieuwe presentatie bevat al één lege dia.  
2. Haal die dia op via de index 0 uit de collectie die [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) retourneert.  
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) van het type `Cloud` toe met de [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) methode, en stel de tekst in met [setText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#setText-java.lang.String-).  
4. Sla de presentatie op als een PPTX‑bestand met de [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) methode.

Het voorbeeld hieronder is een volledig programma. In het Maven‑project van [Installatie](/slides/nl/java/installation/), sla het op als *src/main/java/HelloSlides.java* en voer `mvn compile exec:java` uit.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Maak een presentatie. Deze bevat al één lege dia.
        Presentation presentation = new Presentation();
        try {
            // Haal de eerste dia op.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Voeg een wolkvorm toe en zet er tekst in.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Sla de presentatie op als een PPTX-bestand.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

De linkerbovenhoek van de wolk ligt 20 punten vanaf de linkerrand en 20 punten vanaf de bovenzijde van de dia, en de vorm is 200 punten breed en 80 punten hoog. Het programma slaat *new_presentation.pptx* op met één dia die de wolk en de bijbehorende tekst bevat. Zonder licentie voegt Aspose.Slides ook een evaluatiewatermerk toe aan elke dia die wordt opgeslagen; zie [Licenties](/slides/nl/java/licensing/).

Het resultaat:

![De nieuwe presentatie](new_presentation.png)

## **FAQ**

### In welke formaten kan ik een nieuwe presentatie opslaan?

U kunt opslaan naar [PPTX, PPT en ODP](/slides/nl/java/save-presentation/), en exporteren naar [PDF](/slides/nl/java/convert-powerpoint-to-pdf/), [XPS](/slides/nl/java/convert-powerpoint-to-xps/), [HTML](/slides/nl/java/convert-powerpoint-to-html/), [SVG](/slides/nl/java/render-a-slide-as-an-svg-image/), en [afbeeldingen](/slides/nl/java/convert-powerpoint-to-png/), onder andere.

### Kan ik vertrekken van een sjabloon (POTX/POTM) en opslaan als een reguliere PPTX?

Ja. Laad het sjabloon en sla op in het gewenste formaat; POTX/POTM/PPTM en soortgelijke formaten [worden ondersteund](/slides/nl/java/supported-file-formats/).

### Hoe beheer ik de dia‑grootte/beeldverhouding bij het maken van een presentatie?

Stel de [dia‑grootte](/slides/nl/java/slide-size/) in (inclusief presets zoals 4:3 en 16:9 of aangepaste afmetingen) en kies hoe de inhoud moet worden geschaald.

### In welke eenheden worden afmetingen en coördinaten gemeten?

In punten: 1 inch is gelijk aan 72 eenheden.

### Hoe ga ik om met zeer grote presentaties (met veel mediabestanden) om het geheugengebruik te verminderen?

Gebruik [BLOB‑beheersstrategieën](/slides/nl/java/manage-blob/), beperk het in‑geheugen opslaan door tijdelijke bestanden te gebruiken, en geef de voorkeur aan bestandsgebaseerde werkwijzen boven puur in‑geheugen‑streams.

### Kan ik presentaties parallel aanmaken/op slaan?

U kunt niet dezelfde [Presentation]‑instantie vanuit [meerdere threads](/slides/nl/java/multithreading/) bedienen. Gebruik afzonderlijke, geïsoleerde instanties per thread of proces.

### Hoe verwijder ik het proef‑watermerk en de beperkingen?

[Pas een licentie toe](/slides/nl/java/licensing/) één keer per proces. De licentie‑XML moet onveranderd blijven en de licentie‑instelling moet gesynchroniseerd worden als er meerdere threads betrokken zijn.

### Kan ik de PPTX die ik maak digitaal ondertekenen?

Ja. [Digitale handtekeningen](/slides/nl/java/digital-signature-in-powerpoint/) (toevoegen en verifiëren) worden ondersteund voor presentaties.

### Worden macro’s (VBA) ondersteund in aangemaakte presentaties?

Ja. U kunt [VBA‑projecten maken/bewerken](/slides/nl/java/presentation-via-vba/) en macro‑ingeschakelde bestanden zoals PPTM/PPSM opslaan.