---
title: Hantera ritningsguider i presentationer på Android
linktitle: Ritningsguider
type: docs
weight: 85
url: /sv/androidjava/drawing-guides/
keywords:
- ritningsguide
- horisontell guide
- vertikal guide
- justeringsguide
- bildvy
- masterbild
- layoutbild
- anteckningsmaster
- handout‑master
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lägg till, hämta och rensa horisontella och vertikala ritningsguider i PowerPoint‑presentationer med Aspose.Slides för Android via Java."
---
## **Översikt**

Ritningsguider är justerbara horisontella och vertikala linjer som hjälper användare att justera former konsekvent när de redigerar en presentation i PowerPoint. De är särskilt användbara när ett program genererar en presentation som senare ska finjusteras manuellt: programmet kan spara samma justeringshjälpmedel som författare ska följa när de lägger till eller flyttar innehåll.

Ritningsguider är redigeringshjälpmedel, inte bildinnehåll. De visas inte i en bildspelsvisning eller renderad utskrift. Aspose.Slides for Android via Java exponerar dem via gränssnittet [IDrawingGuidesCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idrawingguidescollection/). En guide representeras av [IDrawingGuide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idrawingguide/) och har en orientering, en position och en färg.

Positionen mäts i punkter från det övre vänstra hörnet på den aktuella bilden eller mastern. En vertikal guide använder en horisontell koordinat, vanligtvis mellan noll och bildens bredd. En horisontell guide använder en vertikal koordinat, vanligtvis mellan noll och bildens höjd.

## **Lägg till guider i bildvyn**

Använd [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) för att hantera guider som visas vid redigering av vanliga bilder. Anropa [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) med ett [Orientation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/orientation/)‑värde och en position i punkter.

Följande exempel lägger till en vertikal guide till höger om bildens centrum och en horisontell guide under den:

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

## **Åtkomst till ritningsguider**

[IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) och [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int--)‑metoderna ger åtkomst till befintliga guider. Metoderna [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idrawingguide/#getPosition--), och [IDrawingGuide.getColor](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idrawingguide/#getColor--) returnerar värden som också kan ändras via motsvarande setter‑metoder.

Följande exempel läser bildvyguidarna från presentationen som skapats ovan:

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

## **Lägg till guider till master‑ och layoutbilder**

En bildmaster och var och en av dess layoutbilder kan ha egna samlingar av ritningsguider. Använd [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) för en master‑bild och [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) för en layoutbild.

Följande exempel lägger till en vertikal guide till den första master‑bilden och en horisontell guide till den första layout‑bilden:

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

## **Lägg till guider till antecknings‑ och handout‑masterbilder**

Antecknings‑masterbilder och handout‑masterbilder stöder också ritningsguider. Använd [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) och [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) för att komma åt deras samlingar. Om en presentation inte innehåller någon av dessa masterbilder skapar [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) eller [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) standard‑masterbilden och returnerar den.

Följande exempel lägger till en horisontell guide till en antecknings‑master och en vertikal guide till en handout‑master:

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

## **Rensa ritningsguider**

Anropa [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) för att ta bort alla guider från en viss samling. Att rensa en samling påverkar inte guider som lagras i en annan omfattning.

Följande exempel rensar guiderna i bildvyn samt alla guider på bildmaster, layoutbilder, antecknings‑master och handout‑master utan att skapa saknade masterbilder:

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

## **Vanliga frågor**

**Visas ritningsguider i en bildspelsvisning eller exporterade bilder?**

Nej. Ritningsguider är justeringshjälpmedel för redigering och renderas inte som presentationsinnehåll.

**Kan en ritningsguide läggas till direkt på en enskild normal bild?**

Redigeringsguider för vanliga bilder lagras i presentationens bild‑vy‑egenskaper. Separata guidessamlingar finns för bildmaster, layoutbilder, antecknings‑master och handout‑master.

**Vilka enheter används för guidens positioner?**

Positioner anges i punkter, där 72 punkter motsvarar en tum. Vertikala positioner mäts från vänster kant och horisontella positioner mäts från överkant.

**Tar rensning av ritningsguider bort former eller förändrar bildens innehåll?**

Nej. Metoden [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) tar endast bort guiderna i den valda samlingen. Former och annat bildinnehåll förblir oförändrade.