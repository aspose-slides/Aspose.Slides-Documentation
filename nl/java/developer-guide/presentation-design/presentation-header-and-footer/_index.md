---
title: Beheer presentatiekopteksten en -voetteksten in Java
linktitle: Koptekst en voettekst
type: docs
weight: 140
url: /nl/java/presentation-header-and-footer/
keywords:
- koptekst
- kopteksttekst
- voettekst
- voetteksttekst
- koptekst instellen
- voettekst instellen
- hand-out
- notities
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u voettekst-, datum-tijd-, dia-nummer- en koptekst-plaatsaanduidingen op dia's, notitiepagina's en hand-outs kunt beheren met Aspose.Slides voor Java."
---
## **Overzicht**

PowerPoint gebruikt verschillende koptekst‑ en voettekst‑plaatsaanduidingen afhankelijk van het paginatype. Aspose.Slides voor Java laat u de tekst en zichtbaarheid van deze plaatsaanduidingen beheren via koptekst/voettekst‑manager‑interfaces.

De beschikbare plaatsaanduidingen hangen af van de reikwijdte:

| Reikwijdte | Koptekst | Voettekst | Datum/tijd | Dia-/paginanummer |
|---|---|---|---|---|
| Reguliere dia | Nee | Ja | Ja | Ja |
| Notitie‑master | Ja | Ja | Ja | Ja |
| Notitiedia | Ja | Ja | Ja | Ja |
| Hand‑out‑master | Ja | Ja | Ja | Ja |

Een reguliere presentatiedia heeft geen koptekst‑plaatsaanduiding. Kopteksten zijn beschikbaar op notitie‑pagina’s en hand‑outs. Voor reguliere dia’s gebruikt u de voettekst‑, datum/tijd‑ en dia‑nummer‑plaatsaanduidingen.

De reikwijdte van een wijziging hangt af van de manager die u gebruikt. De [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideheaderfootermanager/)‑interface beheert één reguliere dia. De [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/inotesslideheaderfootermanager/)‑interface beheert één notitiedia. Master‑ en layout‑managers kunnen instellingen ook doorgeven aan afhankelijke dia’s, terwijl de [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/)‑interface het hand‑out‑master beheert.

## **Voettekst, datum/tijd en dia‑nummers instellen op reguliere dia’s**

Voor reguliere dia’s bestaat de basiswerkwijze uit: elke dia‑header/voettekst‑manager benaderen, de voettekst‑ en datum/tijd‑tekst instellen, de gewenste plaatsaanduidingen inschakelen en de presentatie opslaan. Dia‑nummers worden door de presentatie gegenereerd, dus u hoeft alleen hun zichtbaarheid te regelen.

Gebruik [`setFooterText`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) en [`setDateTimeText`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) om tekst in te stellen, en [`setFooterVisibility`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), en [`setSlideNumberVisibility`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) om de overeenkomstige plaatsaanduidingen te tonen.

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

Als u slechts één dia wilt bijwerken, benader die dia rechtstreeks via de [`getSlides`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getSlides--)‑methode in plaats van de volledige collectie te doorlopen.

## **Kopteksten en voetteksten instellen op het notitie‑master**

Het notitie‑master definieert gemeenschappelijke opmaak en plaatsaanduidingsgedrag voor notitie‑pagina’s. Gebruik de [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasternotesslideheaderfootermanager/)‑interface wanneer u alleen het notitie‑master zelf wilt wijzigen.

Het volgende voorbeeld stelt koptekst, voettekst en datum/tijd‑tekst in op het notitie‑master en maakt alle ondersteunde plaatsaanduidingen zichtbaar op dat master:

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

De [`getMasterNotesSlide`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--)‑methode retourneert `null` wanneer de presentatie geen notitie‑master bevat.

## **Instellingen van het notitie‑master toepassen op onderliggende notitiedia’s**

Een notitie‑master kan koptekst‑ en voettekst‑instellingen toepassen op zichzelf en op alle afhankelijke notitiedia’s. Gebruik de speciale propagatiemethoden op [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasternotesslideheaderfootermanager/) wanneer dezelfde instellingen door de gehele notitie‑hiërarchie moeten worden toegepast.

Bijvoorbeeld, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) en [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) werken de notitie‑master‑koptekst en alle onderliggende kopteksten bij. Vergelijkbare methoden zijn beschikbaar voor voetteksten, datum/tijd en dia‑nummers.

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

De hierboven gebruikte propagatiemethoden zijn [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), en [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Kopteksten en voetteksten instellen op een individuele notitiedia**

Een notitiedia behoort tot een specifieke reguliere dia. Gebruik de [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/inotesslideheaderfootermanager/)‑interface wanneer u alleen die notitie‑pagina wilt aanpassen.

De [`addNotesSlide`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--)‑methode retourneert de notitiedia voor de huidige dia en maakt er één aan als die nog niet bestaat. Het volgende voorbeeld configureert de notitie‑pagina die bij de eerste presentatiedia hoort:

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

Als u eerst instellingen vanuit het notitie‑master doorgeeft en daarna een individuele notitiedia wijzigt, laten de latere per‑dia‑instellingen u die notitie‑pagina onafhankelijk aanpassen.

## **Kopteksten en voetteksten instellen op het hand‑out‑master**

Hand‑out‑pagina’s gebruiken het hand‑out‑master voor hun koptekst‑, voettekst‑, datum/tijd‑ en paginanummer‑plaatsaanduidingen. In tegenstelling tot notitie‑pagina’s worden hand‑out‑instellingen beheerd via het hand‑out‑master en niet via individuele hand‑out‑dia’s.

Gebruik de [`getMasterHandoutSlide`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--)‑methode om toegang te krijgen tot het hand‑out‑master. Als deze niet aanwezig is, roep dan [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) aan om het standaard hand‑out‑master aan te maken.

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

## **Begrijp reikwijdte en overerving**

Kies de koptekst/voettekst‑manager die overeenkomt met de reikwijdte die u wilt wijzigen:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideheaderfootermanager/) wijzigt voettekst-, datum/tijd- en dia‑nummer‑instellingen voor één reguliere dia.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslideheaderfootermanager/) beheert een layout‑dia en kan ondersteunde instellingen doorgeven aan afhankelijke dia’s.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslideheaderfootermanager/) beheert een reguliere master‑dia en kan ondersteunde instellingen doorgeven aan afhankelijke dia’s.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasternotesslideheaderfootermanager/) beheert het notitie‑master en kan instellingen doorgeven aan alle afhankelijke notitiedia’s.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/inotesslideheaderfootermanager/) wijzigt één notitiedia en ondersteunt een koptekst‑plaatsaanduiding naast voettekst, datum/tijd en dia‑nummer.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) wijzigt het hand‑out‑master en ondersteunt alle vier plaatsaanduidingstypen.

Gebruik propagatie vanaf een master of layout wanneer dezelfde instelling door de gehele hiërarchie moet gelden. Gebruik een individuele dia‑ of notitiedia‑manager wanneer u een lokale instelling voor één pagina nodig heeft.

## **FAQ**

**Kan ik een koptekst toevoegen aan een reguliere dia?**

Nee. PowerPoint definieert geen koptekst‑plaatsaanduiding voor reguliere dia’s. Gebruik op reguliere dia’s de voettekst‑, datum/tijd‑ en dia‑nummer‑plaatsaanduidingen. Koptekst‑plaatsaanduidingen zijn beschikbaar op notitie‑pagina’s en hand‑outs.

**Wat als een voettekst-, datum/tijd- of dia‑nummer‑plaatsaanduiding niet zichtbaar is?**

Gebruik de overeenkomstige koptekst/voettekst‑manager om de zichtbaarheid te controleren en schakel deze in indien nodig. Bijvoorbeeld, [`isFooterVisible`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) geeft aan of een voettekst‑plaatsaanduiding aanwezig is, en [`setFooterVisibility`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) wijzigt de zichtbaarheid.

**Hoe begin ik de dia‑nummering bij een andere waarde dan 1?**

Roep de [`setFirstSlideNumber`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-)‑methode van de presentatie aan. De dia‑nummer‑plaatsaanduidingen gebruiken vervolgens de aangepaste nummerreeks.

**Wat gebeurt er met kopteksten en voetteksten bij export naar PDF, afbeeldingen of HTML?**

Zichtbare koptekst‑ en voettekst‑elementen worden samen met de rest van de presentatiewaarde gerenderd in het uitvoerformaat. Het uiterlijk hangt af van het te exporteren paginatype en de bijbehorende plaatsaanduidings‑zichtbaarheidsinstellingen.