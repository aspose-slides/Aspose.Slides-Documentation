---
title: Zarządzanie SmartArt w prezentacjach PowerPoint na Androidzie
linktitle: Zarządzanie SmartArt
type: docs
weight: 10
url: /pl/androidjava/manage-smartart/
keywords:
- SmartArt
- tekst SmartArt
- typ układu
- właściwość ukrywania
- wykres organizacyjny
- wykres organizacyjny ze zdjęciem
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Naucz się tworzyć i edytować SmartArt w PowerPoint przy użyciu Aspose.Slides for Android, wykorzystując przejrzyste przykłady kodu Java, które przyspieszają projektowanie slajdów i automatyzację."
---
## **Przegląd**

SmartArt to diagram programu PowerPoint utworzony z węzłów, kształtów węzłów i układu. Za pomocą Aspose.Slides for Android poprzez Java możesz tworzyć SmartArt, odczytywać tekst z jego węzłów, zmieniać jego układ, przeglądać ukryte węzły, konfigurować układy wykresów organizacyjnych oraz tworzyć wykresy organizacyjne ze zdjęciami.

## **Pobieranie tekstu z obiektu SmartArt**

Węzeł SmartArt może zawierać jeden lub więcej kształtów. Aby odczytać tekst z kształtów węzła, iteruj przez [ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--), a następnie odczytaj [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/), zwrócony przez [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

Przykład wymaga prezentacji zawierającej co najmniej jeden slajd oraz obiektu SmartArt jako pierwszego kształtu na tym slajdzie. Wypisuje każdy dostępny ramkę tekstową w konsoli.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Zmiana typu układu obiektu SmartArt**

Układ SmartArt określa, w jaki sposób węzły są rozmieszczane i połączone. Poniższy przykład tworzy obiekt SmartArt z wartością [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `BasicBlockList`, zmienia ją na wartość `BasicProcess` i zapisuje prezentację. Pozycja i rozmiar przekazywane do [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) są mierzone w punktach. Użyj [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-) , aby zmienić układ.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sprawdzenie, czy węzeł SmartArt jest ukryty**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) wskazuje, czy węzeł jest ukryty w modelu danych SmartArt. Ukryte węzły mogą istnieć w strukturze, nawet jeśli wybrany układ nie wyświetla ich jako widoczne elementy diagramu.

Poniższy przykład dodaje węzeł do obiektu SmartArt, który używa wartości [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `RadialCycle`, i sprawdza stan ukrycia dodanego węzła. Wypisuje komunikat, jeśli węzeł jest ukryty, i zapisuje diagram.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Pobieranie lub ustawianie układu wykresu organizacyjnego**

Dla diagramów SmartArt wykorzystujących układ wykresu organizacyjnego, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) i [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) definiują, w jaki sposób węzły podrzędne są rozmieszczane pod węzłem nadrzędnym. Na przykład możesz ustawić węzły podrzędne, aby wisiały po lewej, prawej lub po obu stronach, w zależności od wybranego [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/).

Poniższy przykład tworzy wykres organizacyjny i ustawia układ pierwszego węzła na wartość [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) `LeftHanging`. Indeks zero‑bazowy `0` wybiera pierwszy węzeł najwyższego poziomu; jego węzły podrzędne używają wybranego układu. Zmodyfikowana prezentacja zostaje następnie zapisana.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Utworzenie wykresu organizacyjnego ze zdjęciem**

Wykres organizacyjny ze zdjęciem to układ SmartArt przeznaczony do diagramów hierarchicznych, które zawierają znaczniki obrazu. Użyj wartości [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart` podczas dodawania obiektu SmartArt do slajdu. Ten przykład zapisuje diagram ze znacznikami obrazu; nie wypełnia znaczników obrazami.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Konwersja starszych diagramów na grupy kształtów**

Podczas modernizacji istniejącej prezentacji możesz potrzebować zaktualizować wykres organizacyjny pierwotnie utworzony w PowerPoint 97–2003. Aspose.Slides reprezentuje te starsze diagramy jako obiekty [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/). Użyj [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--) , aby przekształcić diagram w grupę kształtów, co umożliwia edycję poszczególnych elementów wizualnych. Zobacz [LegacyDiagram API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/) , aby uzyskać szczegóły.

Konwersja dodaje nową grupę do kolekcji kształtów bez usuwania pierwotnego diagramu. Po pomyślnej konwersji usuń oryginał przy użyciu [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) , aby uniknąć duplikacji zawartości. Zbierz starsze diagramy do listy przed ich konwersją, aby dodawanie i usuwanie kształtów nie zakłócało iteracji.

Poniższy przykład otwiera prezentację, przeszukuje każdy slajd, konwertuje diagramy na grupy kształtów i zapisuje zaktualizowaną prezentację jako PPTX.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zapisana prezentacja zawiera edytowalne grupy kształtów w miejsce przekonwertowanych starszych diagramów, bez pozostawionych pierwotnych diagramów. Otwórz plik PPTX w programie PowerPoint, aby edytować poszczególne elementy w każdej grupie, takie jak tekst, wypełnienie lub położenie.

## **FAQ**

**Czy SmartArt obsługuje odbicie lustrzane lub odwrócenie dla języków od prawej do lewej (RTL)?**

Tak. Metoda [ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) zmienia kierunek diagramu z lewej‑do‑prawej na prawą‑do‑lewej lub odwrotnie, gdy wybrany układ SmartArt obsługuje odwrócenie.

**Jak mogę skopiować SmartArt na ten sam slajd lub do innej prezentacji, zachowując formatowanie?**

Możesz [sklonować kształt SmartArt](/slides/pl/androidjava/shape-manipulations/) za pomocą [ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) lub [sklonować cały slajd](/slides/pl/androidjava/clone-slides/) , który zawiera SmartArt. Oba podejścia zachowują rozmiar, pozycję i formatowanie.

**Jak wyrenderować SmartArt do obrazu rastrowego w celu podglądu lub eksportu internetowego?**

[Renderuj slajd](/slides/pl/androidjava/convert-powerpoint-to-png/) lub całą prezentację do formatu PNG lub JPEG. SmartArt jest renderowany jako część slajdu.

**Jak mogę znaleźć konkretny obiekt SmartArt na slajdzie, jeśli jest ich kilka?**

Użyj [Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) lub [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-) , aby przypisać charakterystyczny tekst alternatywny lub nazwę do kształtu SmartArt, wyszukaj tę wartość w [BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) , a następnie sprawdź, czy pasujący kształt jest typu [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/).