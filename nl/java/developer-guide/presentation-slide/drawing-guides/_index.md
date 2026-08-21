---
title: Beheer tekenrichtlijnen in presentaties in Java
linktitle: Tekenrichtlijnen
type: docs
weight: 85
url: /nl/java/drawing-guides/
keywords:
- tekenrichtlijn
- horizontale richtlijn
- verticale richtlijn
- uitlijnrichtlijn
- diaweergave
- masterdia
- layoutdia
- notitiemaster
- handout-master
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Voeg horizontale en verticale tekenrichtlijnen toe, en krijg toegang tot en verwijder ze in PowerPoint-presentaties met Aspose.Slides for Java."
---
## **Overzicht**

Tekenrichtlijnen zijn verstelbare horizontale en verticale lijnen die gebruikers helpen vormen consistent uit te lijnen tijdens het bewerken van een presentatie in PowerPoint. Ze zijn vooral nuttig wanneer een toepassing een presentatie genereert die later handmatig zal worden verfijnd: de toepassing kan dezelfde uitlijnhulpmiddelen opslaan die auteurs moeten volgen bij het toevoegen of verplaatsen van inhoud.

Tekenrichtlijnen zijn bewerkingshulpmiddelen, geen dia‑inhoud. Ze verschijnen niet in een diavoorstelling of gerenderde uitvoer. Aspose.Slides for Java stelt ze beschikbaar via de [IDrawingGuidesCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idrawingguidescollection/) interface. Een richtlijn wordt weergegeven door [IDrawingGuide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idrawingguide/) en heeft een oriëntatie, een positie en een kleur.

De positie wordt gemeten in punten vanaf de linkerbovenhoek van de betreffende dia of master. Een verticale richtlijn gebruikt een horizontale coördinaat, doorgaans tussen nul en de breedte van de dia. Een horizontale richtlijn gebruikt een verticale coördinaat, doorgaans tussen nul en de hoogte van de dia.

## **Richtlijnen toevoegen aan de dia‑weergave**

Gebruik [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) om richtlijnen te beheren die tijdens het bewerken van normale dia's worden weergegeven. Roep [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) aan met een [Orientation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/orientation/)‑waarde en een positie in punten.

Het volgende voorbeeld voegt één verticale richtlijn toe rechts van het middelpunt van de dia en één horizontale richtlijn eronder:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Toegang tot tekenrichtlijnen**

De methoden [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idrawingguidescollection/#getCount--) en [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) geven toegang tot bestaande richtlijnen. De methoden [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idrawingguide/#getPosition--), en [IDrawingGuide.getColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idrawingguide/#getColor--) retourneren waarden die ook kunnen worden gewijzigd via de bijbehorende setter‑methoden.

Het volgende voorbeeld leest de richtlijnen uit de dia‑weergave van de hierboven gemaakte presentatie:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Richtlijnen toevoegen aan master‑ en layout‑dia's**

Een master‑dia en elk van zijn layout‑dia's kunnen hun eigen verzameling tekenrichtlijnen hebben. Gebruik [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslide/#getDrawingGuides--) voor een master‑dia en [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--) voor een layout‑dia.

Het volgende voorbeeld voegt een verticale richtlijn toe aan de eerste master‑dia en een horizontale richtlijn aan de eerste layout‑dia:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Richtlijnen toevoegen aan notitie‑ en hand-out‑masters**

Notitiemasters en hand‑out‑masters ondersteunen eveneens tekenrichtlijnen. Gebruik [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) en [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) om hun collecties te benaderen. Als een presentatie geen van deze masters bevat, maakt [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) of [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) de standaard‑master aan en retourneert deze.

Het volgende voorbeeld voegt een horizontale richtlijn toe aan een notitiemaster en een verticale richtlijn aan een hand‑out‑master:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tekenrichtlijnen wissen**

Roep [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idrawingguidescollection/#clear--) aan om elke richtlijn uit een bepaalde collectie te verwijderen. Het wissen van één collectie heeft geen invloed op richtlijnen die in een andere scope zijn opgeslagen.

Het volgende voorbeeld wist de richtlijnen uit de dia‑weergave en alle richtlijnen op master‑dia's, layout‑dia's, de notitiemaster en de hand‑out‑master zonder ontbrekende masters te maken:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Verschijnen tekenrichtlijnen in een diavoorstelling of geëxporteerde afbeeldingen?**

Nee. Tekenrichtlijnen zijn uitlijnhulpmiddelen voor het bewerken en worden niet gerenderd als presentatiewaarde.

**Kan een tekenrichtlijn rechtstreeks aan een individuele normale dia worden toegevoegd?**

Normale‑dia‑bewerkingsrichtlijnen worden opgeslagen in de slide‑view‑eigenschappen van de presentatie. Voor master‑dia's, layout‑dia's, notitiemasters en hand‑out‑masters zijn aparte verzameling richtlijnen beschikbaar.

**Welke eenheden worden gebruikt voor de posities van de richtlijnen?**

Posities worden opgegeven in punten, waarbij 72 punten gelijk is aan één inch. Verticale posities worden gemeten vanaf de linkerrand, horizontale posities vanaf de bovenzijde.

**Verwijdert het wissen van tekenrichtlijnen vormen of verandert het de dia‑inhoud?**

Nee. De [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idrawingguidescollection/#clear--)‑methode verwijdert uitsluitend de richtlijnen in de geselecteerde collectie. Vormen en andere dia‑inhoud blijven ongewijzigd.