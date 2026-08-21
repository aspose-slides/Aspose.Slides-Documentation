---
title: Zarządzanie liniami pomocniczymi w prezentacjach w Javie
linktitle: Linie pomocnicze
type: docs
weight: 85
url: /pl/java/drawing-guides/
keywords:
- linia pomocnicza
- linia pozioma
- linia pionowa
- linia wyrównania
- widok slajdu
- wzorzec slajdu
- slajd układu
- wzorzec notatek
- wzorzec wersji roboczej
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dodaj, odczytaj i usuń poziome oraz pionowe linie pomocnicze w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Javy."
---
## **Przegląd**

Linie pomocnicze rysowania są regulowanymi poziomymi i pionowymi liniami, które pomagają użytkownikom wyrównywać kształty w sposób spójny podczas edytowania prezentacji w programie PowerPoint. Są szczególnie przydatne, gdy aplikacja generuje prezentację, którą później będzie ręcznie udoskonalane: aplikacja może zapisać te same pomoce wyrównywania, które autorzy powinni stosować przy dodawaniu lub przesuwaniu treści.

Linie pomocnicze rysowania są narzędziami edycyjnymi, a nie treścią slajdu. Nie pojawiają się w pokazie slajdów ani w renderowanym wyjściu. Aspose.Slides for Java udostępnia je poprzez interfejs [IDrawingGuidesCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idrawingguidescollection/). Linia pomocnicza jest reprezentowana przez [IDrawingGuide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idrawingguide/) i posiada orientację, pozycję oraz kolor.

Pozycja jest mierzona w punktach od lewego górnego rogu odpowiedniego slajdu lub wzorca. Pionowa linia pomocnicza używa współrzędnej poziomej, zazwyczaj pomiędzy zerem a szerokością slajdu. Pozioma linia pomocnicza używa współrzędnej pionowej, zazwyczaj pomiędzy zerem a wysokością slajdu.

## **Dodawanie linii pomocniczych w widoku slajdu**

Użyj [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) aby zarządzać liniami pomocniczymi wyświetlanymi podczas edytowania zwykłych slajdów. Wywołaj [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) z wartością [Orientation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/orientation/) oraz pozycją w punktach.

Poniższy przykład dodaje jedną pionową linię pomocniczą po prawej stronie środka slajdu oraz jedną poziomą linię pomocniczą poniżej niej:

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

## **Dostęp do linii pomocniczych**

Metody [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idrawingguidescollection/#getCount--) oraz [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) zapewniają dostęp do istniejących linii pomocniczych. Metody [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idrawingguide/#getPosition--), i [IDrawingGuide.getColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idrawingguide/#getColor--) zwracają wartości, które można również zmienić przy użyciu odpowiadających metod ustawiających.

Poniższy przykład odczytuje linie pomocnicze widoku slajdu z prezentacji utworzonej powyżej:

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

## **Dodawanie linii pomocniczych do wzorców i slajdów układu**

Wzorzec slajdu i każdy ze slajdów układu może posiadać własne kolekcje linii pomocniczych. Użyj [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslide/#getDrawingGuides--) dla wzorca slajdu oraz [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--) dla slajdu układu.

Poniższy przykład dodaje pionową linię pomocniczą do pierwszego wzorca slajdu oraz poziomą linię pomocniczą do pierwszego slajdu układu:

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

## **Dodawanie linii pomocniczych do notatek i szablonów wersji roboczej**

Wzorce notatek i wzorce wersji roboczej również obsługują linie pomocnicze. Użyj [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) oraz [IMasterHandoutSlide.getDrawingGuides](https://reference.asposa.com/slides/pl/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) aby uzyskać dostęp do ich kolekcji. Jeśli prezentacja nie zawiera jednego z tych wzorców, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) lub [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) tworzy domyślny wzorzec i zwraca go.

Poniższy przykład dodaje poziomą linię pomocniczą do wzorca notatek i pionową linię pomocniczą do wzorca wersji roboczej:

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

## **Usuwanie linii pomocniczych**

Wywołaj [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idrawingguidescollection/#clear--) aby usunąć wszystkie linie pomocnicze z danej kolekcji. Czyszczenie jednej kolekcji nie wpływa na linie pomocnicze przechowywane w innym zakresie.

Poniższy przykład usuwa linie pomocnicze widoku slajdu oraz wszystkie linie pomocnicze na wzorcach slajdów, slajdach układu, wzorcu notatek i wzorcu wersji roboczej, nie tworząc brakujących wzorców:

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

**Czy linie pomocnicze pojawiają się w pokazie slajdów lub wyeksportowanych obrazach?**

Nie. Linie pomocnicze są pomocnikami wyrównywania podczas edycji i nie są renderowane jako treść prezentacji.

**Czy linię pomocniczą można dodać bezpośrednio do pojedynczego zwykłego slajdu?**

Linie pomocnicze edycji zwykłych slajdów są przechowywane w właściwościach widoku slajdu prezentacji. Oddzielne kolekcje linii pomocniczych są dostępne dla wzorców slajdów, slajdów układu, wzorców notatek i wzorców wersji roboczej.

**Jakie jednostki są używane dla pozycji linii pomocniczych?**

Pozycje są podawane w punktach, gdzie 72 punkty równa się jednemu calowi. Pozycje pionowe mierzone są od lewej krawędzi, a pozycje poziome od górnej krawędzi.

**Czy usunięcie linii pomocniczych usuwa kształty lub zmienia treść slajdu?**

Nie. Metoda [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idrawingguidescollection/#clear--) usuwa tylko linie pomocnicze w wybranej kolekcji. Kształty i inne elementy slajdu pozostają niezmienione.