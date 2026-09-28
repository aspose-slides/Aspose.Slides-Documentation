---
title: Presentaties maken op Android
linktitle: Presentatie maken
type: docs
weight: 10
url: /nl/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Maak presentaties in Java met Aspose.Slides voor Android—maak PPT-, PPTX- en ODP-bestanden, profiteer van OpenDocument-ondersteuning en sla ze programmatisch op voor betrouwbare resultaten."
---
## **Overzicht**

Dit artikel toont hoe je een presentatie maakt in Aspose.Slides voor Android via Java, een tekstvak toevoegt aan de eerste dia, en het resultaat opslaat als een bestand in de opslag van je app. Om een bestaande presentatie te openen of deze in een ander formaat op te slaan, zie [Open Presentation](/slides/nl/androidjava/open-presentation/) en [Save Presentation](/slides/nl/androidjava/save-presentation/). Een korte FAQ aan het einde beantwoordt veelgestelde vragen over formaten, sjablonen, dia-afmetingen, eenheden, geheugenverbruik, threading, licenties, digitale handtekeningen en VBA‑ondersteuning.

Voordat je begint, voeg Aspose.Slides toe aan je Android‑project vanuit de Maven‑repository van Aspose. Zie [Installation](/slides/nl/androidjava/install-aspose-slides-for-android-via-java/).

## **Een PowerPoint‑presentatie maken**

Om een presentatie te maken en een tekstvak op de eerste dia te plaatsen, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑klasse. Een nieuwe presentatie bevat al één lege dia.  
2. Haal die dia op uit de [slide collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) op basis van de index 0.  
3. Voeg een rechthoek toe met de [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-)‑methode van de [shape collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) en stel de tekst in van het bijbehorende [text frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) met de [setText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-)‑methode.  
4. Sla de presentatie op als een PPTX‑bestand met de [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)‑methode, in het [SaveFormat.Pptx](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/)‑formaat.

De code draait binnen een `Activity`, bijvoorbeeld in de `onCreate`‑methode. Het bestand wordt opgeslagen in de map die wordt geretourneerd door de [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir())‑methode: de private opslag van je app, waartoe kan worden geschreven zonder extra machtigingen aan te vragen.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De linkerbovenhoek van de rechthoek ligt 50 points vanaf de linkerrand en 50 points vanaf de bovenzijde van de dia; de rechthoek is 400 points breed en 100 points hoog. Het opgeslagen bestand bevat één dia met die rechthoek en de bijbehorende tekst. Zonder licentie voegt Aspose.Slides ook een evaluatiewatermerk toe aan elke dia die wordt opgeslagen; zie [Licensing](/slides/nl/androidjava/licensing/).

Om het bestand te bekijken, open je de [Device Explorer](https://developer.android.com/studio/debug/device-file-explorer) van Android Studio en zoek je *hello.pptx* onder *data/data/* in de *files*‑map van je app. In een echte app verwerk je presentaties in een achtergrond‑thread zodat de gebruikersinterface responsief blijft.

## **FAQ**

### In welke formaten kan ik een nieuwe presentatie opslaan?

Je kunt opslaan naar [PPTX, PPT en ODP](/slides/nl/androidjava/save-presentation/), en exporteren naar [PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/nl/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/nl/androidjava/convert-powerpoint-to-html/), [SVG](/slides/nl/androidjava/render-a-slide-as-an-svg-image/) en [afbeeldingen](/slides/nl/androidjava/convert-powerpoint-to-png/), onder andere.

### Kan ik starten vanuit een sjabloon (POTX/POTM) en opslaan als een regulier PPTX?

Ja. Laad het sjabloon en sla op in het gewenste formaat; POTX/POTM/PPTM en vergelijkbare formaten worden [ondersteund](/slides/nl/androidjava/supported-file-formats/).

### Hoe regel ik de dia‑grootte/beeldverhouding bij het maken van een presentatie?

Stel de [slide size](/slides/nl/androidjava/slide-size/) in (inclusief presets zoals 4:3 en 16:9 of aangepaste afmetingen) en kies hoe de inhoud moet schalen.

### In welke eenheden worden afmetingen en coördinaten gemeten?

In points: 1 inch is gelijk aan 72 eenheden.

### Hoe ga ik om met zeer grote presentaties (met veel mediabestanden) om het geheugenverbruik te beperken?

Gebruik [BLOB‑beheersstrategieën](/slides/nl/androidjava/manage-blob/), beperk opslag in het geheugen door tijdelijke bestanden te gebruiken, en geef de voorkeur aan bestand‑gebaseerde workflows boven puur in‑memory streams.

### Kan ik presentaties parallel maken/opslaan?

Je kunt niet op dezelfde [Presentation](/slides/nl/androidjava/presentation/)‑instantie werken vanuit [multiple threads](/slides/nl/androidjava/multithreading/). Gebruik afzonderlijke, geïsoleerde instanties per thread of proces.

### Hoe verwijder ik het proef‑watermerk en de beperkingen?

[Apply a license](/slides/nl/androidjava/licensing/) één keer per proces. Het licentie‑XML‑bestand moet ongewijzigd blijven, en de licentie‑instelling moet gesynchroniseerd worden als meerdere threads betrokken zijn.

### Kan ik de PPTX die ik maak digitaal ondertekenen?

Ja. [Digital signatures](/slides/nl/androidjava/digital-signature-in-powerpoint/) (toevoegen en verifiëren) worden ondersteund voor presentaties.

### Worden macro's (VBA) ondersteund in aangemaakte presentaties?

Ja. Je kunt [create/edit VBA projects](/slides/nl/androidjava/presentation-via-vba/) en macro‑ingeschakelde bestanden opslaan, zoals PPTM/PPSM.