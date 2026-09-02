---
title: Beheer presentatiekoppen en -voetteksten op Android
linktitle: Kop en voettekst
type: docs
weight: 140
url: /nl/androidjava/presentation-header-and-footer/
keywords:
- kop
- koptekst
- voettekst
- voetteksttekst
- kop instellen
- voettekst instellen
- hand-out
- notities
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u voettekst-, datum-tijd-, dia-nummer- en kop-plaatsaanduidingen op dia's, notitiepagina's en hand-outs kunt beheren met Aspose.Slides voor Android via Java."
---
## **Overzicht**

PowerPoint gebruikt verschillende kop‑ en voettekst‑plaatsaanduidingen afhankelijk van het paginatype. Aspose.Slides voor Android via Java stelt u in staat om de tekst en zichtbaarheid van deze plaatsaanduidingen te beheren via kop‑/voettekst‑manager‑interfaces.

De beschikbare plaatsaanduidingen hangen af van de scope:

| Scope | Kop | Voettekst | Datum/tijd | Dia-/paginanummer |
|---|---|---|---|---|
| Reguliere dia | Nee | Ja | Ja | Ja |
| Notitie‑master | Ja | Ja | Ja | Ja |
| Notitiedia | Ja | Ja | Ja | Ja |
| Hand‑out‑master | Ja | Ja | Ja | Ja |

Een reguliere presentatiedia heeft geen kop‑plaatsaanduiding. Koppen zijn beschikbaar op notitiepagina’s en hand‑outs. Voor reguliere dia’s gebruikt u in plaats daarvan de voettekst‑, datum/tijd‑ en dia‑nummer‑plaatsaanduidingen.

De reikwijdte van een wijziging hangt af van de gebruikte manager. De [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islideheaderfootermanager/) interface beheert één reguliere dia. De [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) interface beheert één notitiedia. Master‑ en layout‑managers kunnen instellingen ook doorgeven aan afhankelijke dia’s, terwijl de [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) interface de hand‑out‑master beheert.

## **Voettekst, datum/tijd en dia‑nummers instellen op reguliere dia’s**

Voor reguliere dia’s bestaat de basisstroomschema uit het benaderen van de kop‑/voettekst‑manager van elke dia, het instellen van de voettekst‑ en datum/tijd‑tekst, het inschakelen van de benodigde plaatsaanduidingen, en het opslaan van de presentatie. Dia‑nummers worden door de presentatie gegenereerd, dus u hoeft alleen de zichtbaarheid ervan te bepalen.

Gebruik [`setFooterText`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) en [`setDateTimeText`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) om tekst in te stellen, en gebruik [`setFooterVisibility`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), en [`setSlideNumberVisibility`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) om de overeenkomstige plaatsaanduidingen te tonen.

Het volgende end‑to‑end‑voorbeeld past dezelfde voettekst, datum/tijd‑tekst en dia‑nummer‑zichtbaarheid toe op alle reguliere dia’s:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Als u slechts één dia moet bijwerken, benader die dia rechtstreeks via de [`getSlides`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSlides--)‑methode in plaats van door de volledige collectie te itereren.

## **Koppen en voetteksten instellen op de notitie‑master**

De notitie‑master definieert algemene opmaak en plaatsaanduidingsgedrag voor notitiepagina’s. Gebruik de [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) interface wanneer u alleen de notitie‑master zelf wilt wijzigen.

Het volgende voorbeeld stelt kop‑, voettekst‑ en datum/tijd‑tekst in op de notitie‑master en maakt alle ondersteunde plaatsaanduidingen zichtbaar op die master:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De [`getMasterNotesSlide`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--)‑methode geeft `null` terug wanneer de presentatie geen notitie‑master bevat.

## **Instellingen van de notitie‑master toepassen op onderliggende notitiedia’s**

Een notitie‑master kan kop‑ en voettekst‑instellingen toepassen op zichzelf en op alle afhankelijke notitiedia’s. Gebruik de speciale propagatiemethoden op [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) wanneer dezelfde instellingen over de notitie‑hiërarchie moeten worden toegepast.

Bijvoorbeeld, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) en [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) werken de notitie‑master‑kop en alle onderliggende koppen bij. Equivalent‑methoden zijn beschikbaar voor voetteksten, datum/tijd en dia‑nummers.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De hierboven gebruikte propagatiemethoden zijn [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), en [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Koppen en voetteksten instellen op een individuele notitiedia**

Een notitiedia behoort tot een specifieke reguliere dia. Gebruik de [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) interface wanneer u alleen die notitiepagina wilt aanpassen.

De [`addNotesSlide`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--)‑methode retourneert de notitiedia voor de huidige dia en maakt er één aan als die nog niet bestaat. Het volgende voorbeeld configureert de notitiepagina die bij de eerste presentatiedia hoort:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Als u eerst instellingen van de notitie‑master doorgeeft en daarna een individuele notitiedia wijzigt, stellen de latere per‑dia‑instellingen u in staat die notitiepagina onafhankelijk aan te passen.

## **Koppen en voetteksten instellen op de hand‑out‑master**

Hand‑out‑pagina’s gebruiken de hand‑out‑master voor hun kop‑, voettekst‑, datum/tijd‑ en paginanummer‑plaatsaanduidingen. In tegenstelling tot notitiepagina’s worden hand‑out‑instellingen beheerd via de hand‑out‑master en niet via individuele hand‑out‑dia’s.

Gebruik de [`getMasterHandoutSlide`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--)‑methode om toegang te krijgen tot de hand‑out‑master. Als deze niet aanwezig is, roep dan [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) aan om de standaard hand‑out‑master aan te maken.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Scope en overerving begrijpen**

Kies de kop‑/voettekst‑manager die overeenkomt met de scope die u wilt wijzigen:

- `ISlideHeaderFooterManager` wijzigt de voettekst‑, datum/tijd‑ en dia‑nummer‑instellingen voor één reguliere dia.
- `ILayoutSlideHeaderFooterManager` beheert een layout‑dia en kan ondersteunde instellingen doorgeven aan afhankelijke dia’s.
- `IMasterSlideHeaderFooterManager` beheert een reguliere dia‑master en kan ondersteunde instellingen doorgeven aan afhankelijke dia’s.
- `IMasterNotesSlideHeaderFooterManager` beheert de notitie‑master en kan instellingen doorgeven aan alle afhankelijke notitiedia’s.
- `INotesSlideHeaderFooterManager` wijzigt één notitiedia en ondersteunt een kop‑plaatsaanduiding naast voettekst, datum/tijd en dia‑nummer.
- `IMasterHandoutSlideHeaderFooterManager` wijzigt de hand‑out‑master en ondersteunt alle vier plaatsaanduidingstypen.

Gebruik propagatie vanaf een master of layout wanneer dezelfde instelling door de gehele hiërarchie moet gelden. Gebruik een individuele dia‑ of notitiedia‑manager wanneer u een lokale instelling voor één pagina nodig heeft.

## **FAQ**

**Kan ik een kop toevoegen aan een reguliere dia?**

Nee. PowerPoint definieert geen kop‑plaatsaanduiding voor reguliere dia’s. Op reguliere dia’s gebruikt u de voettekst‑, datum/tijd‑ en dia‑nummer‑plaatsaanduidingen. Kop‑plaatsaanduidingen zijn beschikbaar op notitiepagina’s en hand‑outs.

**Wat als een voettekst‑, datum/tijd‑ of dia‑nummer‑plaatsaanduiding niet zichtbaar is?**

Gebruik de bijbehorende kop‑/voettekst‑manager om de zichtbaarheid te controleren en deze indien nodig in te schakelen. Bijvoorbeeld, [`isFooterVisible`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) geeft aan of een voettekst‑plaatsaanduiding aanwezig is, en [`setFooterVisibility`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) wijzigt de zichtbaarheid.

**Hoe begin ik met dia‑nummering vanaf een andere waarde dan 1?**

Roep de [`setFirstSlideNumber`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-)‑methode van de presentatie aan. De dia‑nummer‑plaatsaanduidingen gebruiken dan de bijgewerkte nummeringsreeks.

**Wat gebeurt er met koppen en voetteksten bij het exporteren naar PDF, afbeeldingen of HTML?**

Zichtbare kop‑ en voettekst‑elementen worden samen met de rest van de presentatie‑inhoud gerenderd in het uitvoerformaat. Hun weergave hangt af van het type pagina dat wordt geëxporteerd en de bijbehorende plaatsaanduidings‑zichtbaarheidsinstellingen.