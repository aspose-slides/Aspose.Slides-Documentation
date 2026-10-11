---
title: Wijzig notitiepagina-grootte en -oriëntatie op Android
linktitle: Notitiepagina-grootte
type: docs
weight: 10
url: /nl/androidjava/notes-size/
keywords:
- notitiepagina-grootte
- notitie-oriëntatie
- liggende notities
- staande notities
- hand-out-grootte
- PowerPoint
- presentatie
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Lees en wijzig notitiepagina-afmetingen in Aspose.Slides voor Android via Java, wijzig de oriëntatie, controleer de opgeslagen maten en exporteer notities of hand-outs naar PDF en afbeeldingen."
---
## **Overzicht**

Gebruik [Presentation.getNotesSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getNotesSize--) om de notitiepagina‑instellingen van de presentatie te benaderen. Het retourneert een [INotesSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/inotessize/) object waarvan de [setSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) methode de paginadimensies instelt. Hoewel het instellingenobject zelf niet kan worden vervangen, kun je via deze methode nieuwe afmetingen toewijzen.

Breedte en hoogte worden opgegeven in **points**, met 72 points per inch. Bijvoorbeeld, 900 × 600 points is 12,5 × 8⅓ inch. Deze instellingen gelden voor de hele presentatie, niet voor de notities van een enkele dia.

| Instelling | Doel |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getNotesSize--) | Bepaalt de afmetingen van de notitiepagina en de paginadimensies die worden gebruikt bij het exporteren van hand-outs. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSlideSize--) | Bepaalt de normale dia‑afmetingen van de presentatie via [ISlideSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidesize/). |

Het wijzigen van de ene instelling verandert de andere niet automatisch. Het wijzigen van de oriëntatie van de notitiepagina draait de gewone dia's eveneens niet. Zie [Slide Size](/slides/nl/androidjava/slide-size/) om de gewone dia's te verkleinen/of te vergroten.

De voorbeelden hieronder gebruiken een bestaand `sample.pptx`. Voor de exportvoorbeelden gebruik je een presentatie met minstens één dia die spreker‑notities bevat. Elk voorbeeld kan onafhankelijk worden uitgevoerd.

## **Lees de grootte en oriëntatie van de notitiepagina**

Lees de breedte en hoogte en vergelijk ze om de oriëntatie te bepalen: een bredere pagina is liggend, een hogere pagina is staand, en gelijke afmetingen beschrijven een vierkante pagina. Dit voorbeeld drukt de werkelijke afmetingen in points af, zonder een standaardpapierformaat aan te nemen.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
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

## **Schakel over naar liggend zonder de papierspecificatie te wijzigen**

Om alleen de oriëntatie te veranderen, wissel je de bestaande breedte en hoogte om. Dit behoudt de lengtes van beide zijden, inclusief die van een aangepast papierformaat. De voorwaarde hieronder voorkomt dat een reeds liggende pagina terug wordt geschakeld naar staand en laat een vierkante pagina onveranderd.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor staande oriëntatie gebruik je dezelfde toekenning wanneer `size.getWidth() > size.getHeight()`. Vervang geen A4‑ of Letter‑afmetingen tenzij je ook het papierformaat wilt wijzigen.

## **Stel een aangepaste notitiepagina‑grootte in en controleer deze**

Wijs beide afmetingen tegelijk toe en gebruik vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) om de presentatie op te slaan. Dit voorbeeld stelt een liggende pagina van 900 × 600 points in, slaat deze op als PPTX en opent het opgeslagen bestand opnieuw om de bewaarde waarden te controleren. De vergelijking staat een tolerantie van 0,01 point toe voor drijvende‑komma‑waarden; dit is geen garantie voor absolute precisie voor elk bestandsformaat.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
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

Het verwachte resultaat is `900.0 x 600.0 points` en `Size preserved: true`. Het controleren van een nieuw geopende presentatie verifieert het opgeslagen bestand, in plaats van alleen de instellingen in het geheugen.

## **Exporteer notities en hand‑outs**

De paginadimensies bepalen de beschikbare ruimte voor notities of hand‑out‑indelingen. Ze activeren die indelingen niet automatisch: configureer ook de exportopties. Export van gewone dia's blijft de dia‑afmetingen gebruiken.

### **Exporteer notities naar PDF en PNG**

Wijs [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/notescommentslayoutingoptions/) toe aan [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) om notities in de PDF op te nemen. Dit voorbeeld rendert ook de eerste dia met notities naar PNG met behulp van [Slide.getImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) en [RenderingOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/renderingoptions/).

De modus [BottomTruncated](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/notespositions/) houdt de notities op één pagina; notities die niet passen, kunnen worden afgekapt. De PDF gebruikt pagina’s van 900 × 600 points. Bij de hieronder gebruikte afbeelding schaal van 1 × 1 is de PNG 900 × 600 pixels. Points beschrijven de paginageometrie; pixels beschrijven de rasteroutput, waarvan de afmetingen ook afhangen van de render‑schaal.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Voor PDF‑export met lange notities biedt [BottomFull](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/notespositions/) extra pagina’s naar behoefte. Gebruik die modus niet met de enkele‑dia‑afbeeldingsaanroep hierboven, die dit niet ondersteunt. Na het wijzigen van de afmetingen, controleer de output op afgekorte notities en de plaatsing van bestaande notes‑master‑objecten; het alleen wijzigen van paginadimensies mag niet worden beschouwd als een garantie dat alle inhoud past. Zie [Convert PowerPoint to PDF with Notes](/slides/nl/androidjava/convert-powerpoint-to-pdf-with-notes/) voor meer informatie over notitie‑export.

### **Exporteer hand‑outs naar PDF**

Gebruik [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/handoutlayoutingoptions/) voor meerdere dia‑miniaturen op één pagina. Het volgende voorbeeld stelt een pagina van 900 × 600 points in en gebruikt [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/handouttype/) om tot vier dia's per pagina te rangschikken. De horizontale preset bepaalt de volgorde van de dia's; de paginariëntatie komt voort uit de breedte en hoogte.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Het wijzigen van de paginagrootte verandert het beschikbare gebied voor het hand‑out‑rooster zonder de afmetingen van de bron‑dia’s te wijzigen. Voor hand‑out‑afbeeldingen gebruik je [Presentation.getImages](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) met de hand‑out‑indeling, in plaats van de afbeelding‑methode van een individuele dia. In Aspose.Slides gebruikt rendering op presentatieniveau de notitiepagina‑afmetingen, terwijl de afbeelding‑aanroep van een enkele dia geen hand‑out‑pagina produceert. Zie [Handout Mode](/slides/nl/androidjava/convert-powerpoint-in-handout-mode/) voor indelingsopties.

## **Pagina‑grootte in viewers, export en afdrukken**

Houd de opgeslagen presentatiedimensies, de geëxporteerde paginadimensies en de afgedrukte papiergrootte gescheiden:

- **Presentatie‑viewers:** Een viewer kan notities weergeven of afdrukken volgens eigen lay‑outregels. Als een andere applicatie het bestand opslaat, open het dan opnieuw en controleer de afmetingen; de conversie van die applicatie kan ze normaliseren.
- **Exportformaten:** De notitie‑ en hand‑out‑PDF‑voorbeelden hierboven gebruiken de geconfigureerde paginadimensies. Rasterafbeeldingen gebruiken gehele pixel‑afmetingen en een render‑schaal, zodat fractionele point‑waarden kunnen worden afgerond in de afbeeldingoutput. Export van gewone dia's past de notitiepagina‑grootte niet toe.
- **Printerstuurprogramma’s:** Papierselectie, automatische rotatie en aan‑pas‑aan‑pagina‑instellingen kunnen de fysieke output wijzigen zonder de in de presentatie of PDF opgeslagen afmetingen te veranderen. Voor een specifiek papierformaat stem de printerinstelling af en controleer de afdrukvoorbeeld.

## **FAQ**

**Kan ik de notitie‑grootte voor slechts één dia instellen?**

De notitiepagina‑grootte is een instelling op presentatieniveau. Individuele dia's kunnen verschillende notitie‑inhoud hebben, maar deze eigenschap biedt geen aparte paginagrootte per dia.

**Waarom veranderde het aanpassen van de notitie‑oriëntatie mijn dia’s niet?**

Notitiepagina’s en gewone dia’s hebben onafhankelijke afmetingen. Gebruik de instellingen voor de reguliere dia‑grootte wanneer je de dia’s zelf wilt aanpassen.

**Waarom heeft mijn opgeslagen of afgedrukte resultaat een andere grootte?**

Open eerst de opgeslagen presentatie opnieuw en vergelijk de notitie‑afmetingen. Als die gewijzigd zijn, controleer dan of het opslaan of converteren van het bestand in een andere applicatie de paginainstellingen heeft aangepast. Als dat niet zo is, controleer dan de export‑lay‑out, afbeelding­schaal, viewer‑instellingen en printer‑papierselectie.