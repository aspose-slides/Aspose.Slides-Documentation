---
title: Zarządzanie prowadzącymi rysunkowymi w prezentacjach na Androidzie
linktitle: Prowadzące rysunkowe
type: docs
weight: 85
url: /pl/androidjava/drawing-guides/
keywords:
- linia prowadząca
- linia prowadząca pozioma
- linia prowadząca pionowa
- linia wyrównująca
- widok slajdu
- master slajdu
- slajd układu
- master notatek
- master wersji drukowanej
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dodawaj, uzyskuj dostęp i usuwaj poziome oraz pionowe linie prowadzące w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Androida w Javie."
---
## **Przegląd**

Linie prowadzące to regulowane poziome i pionowe linie, które pomagają użytkownikom konsekwentnie wyrównywać kształty podczas edycji prezentacji w programie PowerPoint. Są szczególnie przydatne, gdy aplikacja generuje prezentację, którą później będzie ręcznie dopracowywać: aplikacja może zapisać te same pomoce wyrównania, które autorzy powinni stosować przy dodawaniu lub przenoszeniu treści.

Linie prowadzące są pomocą przy edycji, a nie treścią slajdu. Nie pojawiają się podczas pokazu slajdów ani w renderowanym wyjściu. Aspose.Slides for Android via Java udostępnia je za pośrednictwem interfejsu [IDrawingGuidesCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idrawingguidescollection/). Prowadząca jest reprezentowana przez [IDrawingGuide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idrawingguide/) i posiada orientację, pozycję oraz kolor.

Pozycja jest mierzona w punktach od lewego górnego rogu odpowiedniego slajdu lub mastera. Pionowa prowadząca używa współrzędnej poziomej, zwykle w przedziale od zera do szerokości slajdu. Pozioma prowadząca używa współrzędnej pionowej, zwykle w przedziale od zera do wysokości slajdu.

## **Dodaj prowadzące do widoku slajdu**

Użyj [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) aby zarządzać prowadzącymi wyświetlanymi podczas edycji zwykłych slajdów. Wywołaj [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) z wartością [Orientation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/orientation/) oraz pozycją w punktach.

Poniższy przykład dodaje jedną pionową prowadzącą po prawej stronie środka slajdu oraz jedną poziomą prowadzącą poniżej niego:

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

## **Dostęp do prowadzących**

Metody [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) i [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) zapewniają dostęp do istniejących prowadzących. Metody [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idrawingguide/#getPosition--) oraz [IDrawingGuide.getColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idrawingguide/#getColor--) zwracają wartości, które można także zmienić za pomocą odpowiednich metod ustawiających.

Poniższy przykład odczytuje prowadzące widoku slajdu z prezentacji utworzonej powyżej:

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

## **Dodaj prowadzące do mastera i slajdów układu**

Master slajdu oraz każdy z jego slajdów układu mogą posiadać własne kolekcje linii prowadzących. Użyj [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) dla mastera slajdu oraz [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) dla slajdu układu.

Poniższy przykład dodaje pionową prowadzącą do pierwszego mastera slajdu oraz poziomą prowadzącą do pierwszego slajdu układu:

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

## **Dodaj prowadzące do masterów notatek i wersji drukowanych**

Mastery notatek i mastery wersji drukowanych również obsługują linie prowadzące. Użyj [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) oraz [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) aby uzyskać dostęp do ich kolekcji. Jeśli prezentacja nie zawiera jednego z tych masterów, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) lub [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) tworzy domyślny master i zwraca go.

Poniższy przykład dodaje poziomą prowadzącą do mastera notatek oraz pionową prowadzącą do mastera wersji drukowanej:

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

## **Wyczyść linie prowadzące**

Wywołaj [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) aby usunąć wszystkie prowadzące z danej kolekcji. Czyszczenie jednej kolekcji nie wpływa na prowadzące przechowywane w innym zakresie.

Poniższy przykład usuwa prowadzące widoku slajdu oraz wszystkie prowadzące na masterach slajdów, slajdach układu, masterze notatek i masterze wersji drukowanej, bez tworzenia brakujących masterów:

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

**Czy linie prowadzące pojawiają się w pokazie slajdów lub wyeksportowanych obrazach?**

Nie. Linie prowadzące są pomocą przy wyrównywaniu podczas edycji i nie są renderowane jako treść prezentacji.

**Czy linię prowadzącą można dodać bezpośrednio do pojedynczego zwykłego slajdu?**

Prowadzące edytujące zwykłe slajdy są przechowywane w właściwościach widoku slajdu prezentacji. Oddzielne kolekcje prowadzących są dostępne dla masterów slajdów, slajdów układu, masterów notatek i masterów wersji drukowanych.

**Jakie jednostki są używane dla pozycji prowadzących?**

Pozycje podawane są w punktach, gdzie 72 punkty równa się jednemu calowi. Pozycje pionowe mierzone są od lewej krawędzi, a pozycje poziome od górnej krawędzi.

**Czy wyczyszczenie linii prowadzących usuwa kształty lub zmienia treść slajdu?**

Nie. Metoda [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) usuwa tylko prowadzące w wybranej kolekcji. Kształty i inne elementy slajdu pozostają niezmienione.