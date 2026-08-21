---
title: Beheer teken-hulplijnen in presentaties op Android
linktitle: Teken-hulplijnen
type: docs
weight: 85
url: /nl/androidjava/drawing-guides/
keywords:
- teken-hulplijn
- horizontale hulplijn
- verticale hulplijn
- uitlijningshulplijn
- diaweergave
- masterdia
- layoutdia
- notitie-master
- handout-master
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Voeg horizontale en verticale teken-hulplijnen toe, raadpleeg ze en verwijder ze in PowerPoint-presentaties met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Tekenhulplijnen zijn verstelbare horizontale en verticale lijnen die gebruikers helpen vormen consistent uit te lijnen tijdens het bewerken van een presentatie in PowerPoint. Ze zijn vooral nuttig wanneer een applicatie een presentatie genereert die later handmatig verfijnd zal worden: de applicatie kan dezelfde uitlijnhulp opslaan die auteurs moeten volgen bij het toevoegen of verplaatsen van inhoud.

Tekenhulplijnen zijn bewerkingshulpmiddelen, geen dia-inhoud. Ze verschijnen niet in een diavoorstelling of gerenderde uitvoer. Aspose.Slides for Android via Java maakt ze beschikbaar via de [IDrawingGuidesCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idrawingguidescollection/) interface. Een hulplijn wordt vertegenwoordigd door [IDrawingGuide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idrawingguide/) en heeft een oriëntatie, een positie en een kleur.

De positie wordt gemeten in punten vanaf de linkerbovenhoek van de betreffende dia of master. Een verticale hulplijn gebruikt een horizontale coördinaat, meestal tussen nul en de breedte van de dia. Een horizontale hulplijn gebruikt een verticale coördinaat, meestal tussen nul en de hoogte van de dia.

## **Hulplijnen toevoegen aan de diaweergave**

Gebruik [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) om de hulplijnen te beheren die worden weergegeven tijdens het bewerken van normale dia's. Roep [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) aan met een [Orientation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/orientation/) waarde en een positie in punten.

Het volgende voorbeeld voegt één verticale hulplijn toe rechts van het midden van de dia en één horizontale hulplijn eronder:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Toegang tot hulplijnen**

De methoden [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) en [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) bieden toegang tot bestaande hulplijnen. De methoden [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idrawingguide/#getOrientation--) , [IDrawingGuide.getPosition](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idrawingguide/#getPosition--) en [IDrawingGuide.getColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idrawingguide/#getColor--) retourneren waarden die ook kunnen worden gewijzigd via de bijbehorende setter-methoden.

Het volgende voorbeeld leest de hulplijnen uit de dia-view van de hierboven gemaakte presentatie:

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

## **Hulplijnen toevoegen aan master- en layoutdia's**

Een dia-master en elk van zijn layout-dia's kunnen hun eigen collectie teken-hulplijnen hebben. Gebruik [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) voor een master-dia en [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) voor een layout-dia.

Het volgende voorbeeld voegt een verticale hulplijn toe aan de eerste master-dia en een horizontale hulplijn aan de eerste layout-dia:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hulplijnen toevoegen aan notitie- en handout-masters**

Notitie-masters en handout-masters ondersteunen ook teken-hulplijnen. Gebruik [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) en [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) om hun collecties te benaderen. Als een presentatie een van deze masters niet bevat, maakt [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) of [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) de standaard-master aan en retourneert deze.

Het volgende voorbeeld voegt een horizontale hulplijn toe aan een notitie-master en een verticale hulplijn aan een handout-master:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hulplijnen wissen**

Roep [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) aan om elke hulplijn uit een bepaalde collectie te verwijderen. Het wissen van één collectie heeft geen invloed op hulplijnen die opgeslagen zijn in een andere scope.

Het volgende voorbeeld wist de hulplijnen uit de dia-view en alle hulplijnen op dia-masters, layout-dia's, de notitie-master en de handout-master zonder ontbrekende masters te creëren:

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

## **Veelgestelde vragen**

**Verschijnen teken-hulplijnen in een diavoorstelling of geëxporteerde afbeeldingen?**

Nee. Teken-hulplijnen zijn uitlijningshulpmiddelen voor bewerken en worden niet gerenderd als presentatiedata.

**Kan een teken-hulplijn direct aan een individuele normale dia worden toegevoegd?**

Bewerkingshulplijnen voor normale dia's worden opgeslagen in de slide-view-eigenschappen van de presentatie. Er zijn aparte hulplijn-collecties beschikbaar voor dia-masters, layout-dia's, notitie-masters en handout-masters.

**Welke eenheden worden gebruikt voor hulplijn-posities?**

Posities worden opgegeven in punten, waarbij 72 punten gelijk zijn aan één inch. Verticale posities worden gemeten vanaf de linker rand en horizontale posities vanaf de bovenkant.

**Verwijdert het wissen van teken-hulplijnen vormen of wijzigt het de dia-inhoud?**

Nee. De methode [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) verwijdert alleen de hulplijnen in de geselecteerde collectie. Vormen en andere dia-inhoud blijven ongewijzigd.