---
title: Notitiepaginasize en -oriëntatie wijzigen in Java
linktitle: Notitiepaginasize
type: docs
weight: 10
url: /nl/java/notes-size/
keywords:
- grootte van notitiepagina
- oriëntatie van notities
- liggende notities
- staande notities
- grootte van handout
- PowerPoint
- presentatie
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Lees en wijzig de afmetingen van de notitiepagina in Aspose.Slides voor Java, wissel de oriëntatie, controleer de opgeslagen groottes en exporteer notities of hand-outs naar PDF en afbeeldingen."
---
## **Overzicht**

Gebruik [Presentation.getNotesSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getNotesSize--) om de instellingen van de notitiepagina van de presentatie te benaderen. Het retourneert een [INotesSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/inotessize/) object waarvan de [setSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) methode de paginagrootte instelt. Hoewel het instellingenobject zelf niet kan worden vervangen, kun je via deze methode nieuwe afmetingen toewijzen.

Breedte en hoogte worden opgegeven in **points**, met 72 points per inch. Bijvoorbeeld, 900 × 600 points is 12,5 × 8⅓ inch. Deze instellingen gelden voor de presentatie, niet voor de notities van een individuele slide.

| Instelling | Doel |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getNotesSize--) | Regelt de afmetingen van de notitiepagina en de paginagrootte die wordt gebruikt voor handout-export. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getSlideSize--) | Regelt de reguliere slide-afmetingen van de presentatie via [ISlideSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidesize/). |

Het wijzigen van de ene instelling verandert niet automatisch de andere. Het wijzigen van de oriëntatie van de notitiepagina roteert ook niet de reguliere slides. Zie [Slide Size](/slides/nl/java/slide-size/) om de reguliere slides te wijzigen.

De voorbeelden hieronder gebruiken een bestaande `sample.pptx`. Voor de exportvoorbeelden gebruik je een presentatie met ten minste één slide met spreker‑notities. Elk voorbeeld kan onafhankelijk worden uitgevoerd.

## **De notitiepaginasize en -oriëntatie lezen**

Lees de breedte en hoogte en vergelijk ze om de oriëntatie te bepalen: een bredere pagina is liggend, een hogere pagina is staand, en gelijke afmetingen beschrijven een vierkante pagina. Dit voorbeeld geeft de werkelijke afmetingen in points weer, zonder een standaard papierformaat aan te nemen.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Schakel over naar liggend zonder het papierformaat te wijzigen**

Om alleen de oriëntatie te wijzigen, wissel je de huidige breedte en hoogte om. Dit behoudt de lengtes van beide zijden, inclusief die van een aangepast papierformaat. De voorwaarde hieronder voorkomt dat een reeds liggende pagina wordt teruggeschakeld naar staand en laat een vierkante pagina onveranderd.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor staande oriëntatie gebruik je dezelfde toewijzing wanneer `size.getWidth() > size.getHeight()`. Vervang geen A4- of Letter‑afmetingen tenzij je ook het papierformaat wilt wijzigen.

## **Een aangepaste notitiepaginasize instellen en verifiëren**

Ken beide afmetingen tegelijk toe, en gebruik vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) om de presentatie weg te schrijven. Dit voorbeeld stelt een liggende pagina van 900 × 600 points in, slaat deze op als PPTX, en opent het opgeslagen bestand opnieuw om de permanente waarden te controleren. De vergelijking staat een tolerantiewaarde van 0,01 point toe voor floating‑point‑waarden; dit is geen garantie voor absolute precisie voor elk bestandsformaat.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Het verwachte resultaat is `900.0 x 600.0 points` en `Size preserved: true`. Het controleren van een nieuw geopende presentatie verifieert het opgeslagen bestand, niet alleen de in‑memory instellingen.

## **Notities en hand-outs exporteren**

De paginagrootte bepaalt het beschikbare gebied voor notities of hand‑out‑lay‑outs. Ze activeren die lay‑outs niet automatisch: configureer ook de exportopties. Export van reguliere slides blijft de slide‑afmetingen gebruiken.

### **Notities exporteren naar PDF en PNG**

Ken [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/notescommentslayoutingoptions/) toe aan [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) om notities in de PDF op te nemen. Dit voorbeeld rendert bovendien de eerste slide met notities naar PNG met behulp van [Slide.getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) en [RenderingOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/renderingoptions/).

De [BottomTruncated](https://reference.aspose.com/slides/nl/java/com.aspose.slides/notespositions/) modus houdt de notities op één pagina; notities die niet passen kunnen worden afgekapt. De PDF gebruikt pagina’s van 900 × 600 points. Bij de afbeelding‑schaal van 1 × 1 die hieronder wordt gebruikt, is de PNG 900 × 600 pixels. Points beschrijven de paginageometrie; pixels beschrijven de rasteruitvoer, waarvan de afmetingen ook afhangen van de render‑schaal.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Voor PDF‑export met lange notities maakt [BottomFull](https://reference.aspose.com/slides/nl/java/com.aspose.slides/notespositions/) extra pagina’s mogelijk indien nodig. Gebruik die modus niet met de enkele‑slide‑afbeeldingsaanroep hierboven, die dit niet ondersteunt. Na het wijzigen van de grootte, inspecteer de output op afgekapt notities en de plaatsing van bestaande notes‑master‑objecten; het afzonderlijk wijzigen van de paginagrootte is geen garantie dat alle inhoud past. Zie [Convert PowerPoint to PDF with Notes](/slides/nl/java/convert-powerpoint-to-pdf-with-notes/) voor meer informatie over notitie‑export.

### **Hand-outs exporteren naar PDF**

Gebruik [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/handoutlayoutingoptions/) voor meerdere slide‑miniaturen op één pagina. Het volgende voorbeeld stelt een pagina van 900 × 600 points in en gebruikt [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/nl/java/com.aspose.slides/handouttype/) om maximaal vier slides per pagina te rangschikken. De horizontale preset regelt de volgorde van de slides; de pagina‑oriëntatie wordt bepaald door de breedte en hoogte.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Het wijzigen van de paginagrootte verandert het beschikbare gebied voor het hand‑out‑rooster zonder de afmetingen van de bron‑slides te wijzigen. Voor hand‑out‑afbeeldingen, gebruik [Presentation.getImages](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) met de hand‑out‑lay‑out, in plaats van de afbeelding‑methode van een individuele slide. In Aspose.Slides gebruikt rendering op presentatieniveau de notitiepaginasize, terwijl de afbeelding‑aanroep van een individuele slide de hand‑out‑pagina niet produceert. Zie [Handout Mode](/slides/nl/java/convert-powerpoint-in-handout-mode/) voor lay‑outopties.

## **Paginagrootte in viewers, export en afdrukken**

Houd de opgeslagen presentatiesize, de geëxporteerde paginagrootte en de afgedrukte papiergrootte gescheiden:

- **Presentatie‑viewers:** Een viewer kan notities weergeven of afdrukken volgens eigen lay‑outrichtlijnen. Als een andere applicatie het bestand opslaat, open het dan opnieuw en controleer de afmetingen; de bestandsconversie van die applicatie kan ze normaliseren.
- **Exportformaten:** De notities‑ en hand‑out‑PDF‑voorbeelden hierboven gebruiken de geconfigureerde paginagrootte. Rasterafbeeldingen gebruiken gehele pixelafmetingen en een render‑schaal, zodat fractiële point‑waarden kunnen worden afgerond in de afbeelding‑output. Export van reguliere slides past de notitiepaginasize niet toe.
- **Printer‑drivers:** Papierselectie, automatische rotatie en fit‑to‑page‑instellingen kunnen de fysieke output wijzigen zonder de in de presentatie of PDF opgeslagen afmetingen te veranderen. Voor een specifiek papierformaat, stem de printerinstellingen af en controleer de afdrukpreview.

## **FAQ**

**Kan ik de notitiesize alleen voor één slide instellen?**

De notitiepaginasize is een instelling op presentatieniveau. Individuele slides kunnen verschillende notitie‑inhoud hebben, maar deze eigenschap biedt geen afzonderlijke paginagrootte per slide.

**Waarom veranderde de oriëntatie van notities mijn slides niet?**

Notitiepagina’s en reguliere slides hebben onafhankelijke afmetingen. Gebruik de reguliere slide‑size‑instellingen wanneer je de slides zelf wilt herschalen.

**Waarom heeft mijn opgeslagen of afgedrukte resultaat een andere grootte?**

Open eerst de opgeslagen presentatie opnieuw en vergelijk de notitie‑afmetingen. Als die veranderd zijn, controleer dan of het opslaan of converteren van het bestand in een andere applicatie de paginainstellingen heeft aangepast. Als dat niet het geval is, controleer dan de export‑lay‑out, afbeelding‑schaal, viewer‑instellingen en printer‑papierselectie.