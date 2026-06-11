---
title: Zarządzanie SmartArt w prezentacjach PowerPoint przy użyciu Javy
linktitle: Zarządzanie SmartArt
type: docs
weight: 10
url: /pl/java/manage-smartart/
keywords:
- SmartArt
- tekst SmartArt
- typ układu
- ukryta właściwość
- diagram organizacyjny
- diagram organizacyjny ze zdjęciem
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Naucz się tworzyć i edytować SmartArt w PowerPoint przy użyciu Aspose.Slides for Java, korzystając z przejrzystych przykładów kodu, które przyspieszają projektowanie slajdów i automatyzację."
---
## **Przegląd**

SmartArt to diagram PowerPoint zbudowany z węzłów, kształtów węzłów i układu. Za pomocą Aspose.Slides for Java można tworzyć SmartArt, odczytywać tekst z jego węzłów, zmieniać jego układ, sprawdzać ukryte węzły, konfigurować układy diagramów organizacyjnych oraz tworzyć diagramy organizacyjne ze zdjęciami.

## **Pobieranie tekstu z obiektu SmartArt**

Węzeł SmartArt może zawierać jeden lub więcej kształtów. Aby odczytać widoczny tekst, przeiteruj przez [ISmartArt.getAllNodes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ismartart/#getAllNodes--), a następnie odczytaj [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) zwrócony przez [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ismartartshape/#getTextFrame--).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Zmienianie typu układu obiektu SmartArt**

Układ SmartArt kontroluje sposób rozmieszczenia i połączenia węzłów. Poniższy przykład tworzy obiekt SmartArt z wartością [SmartArtLayoutType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`, zmienia go na wartość `BasicProcess` i zapisuje prezentację.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sprawdzanie, czy węzeł SmartArt jest ukryty**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ismartartnode/#isHidden--) wskazuje, czy węzeł jest ukryty w modelu danych SmartArt. Ukryte węzły mogą istnieć w strukturze, nawet gdy wybrany układ nie wyświetla ich jako widoczne elementy diagramu.

Poniższy przykład dodaje węzeł do obiektu SmartArt, który korzysta z wartości [SmartArtLayoutType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArtLayoutType) `RadialCycle`, i sprawdza stan ukrycia węzła.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Pobieranie lub ustawianie układu diagramu organizacyjnego**

Dla diagramów SmartArt wykorzystujących układ diagramu organizacyjnego, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) i [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) określają, jak węzły podrzędne są rozmieszczane pod węzłem nadrzędnym. Na przykład, można ustawić węzły podrzędne tak, aby zwisały po lewej, po prawej lub po obu stronach, w zależności od wybranego [OrganizationChartLayoutType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/OrganizationChartLayoutType).

Poniższy przykład tworzy diagram organizacyjny i ustawia układ pierwszego węzła na wartość [OrganizationChartLayoutType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tworzenie diagramu organizacyjnego ze zdjęciem**

Diagram organizacyjny ze zdjęciem to układ SmartArt przeznaczony dla diagramów hierarchicznych zawierających miejsca na obrazy. Użyj wartości [SmartArtLayoutType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` podczas dodawania obiektu SmartArt do slajdu.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy SmartArt obsługuje odbicie lustrzane lub odwrócenie dla języków RTL?**

Tak. Metoda [ISmartArt.setReversed](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ismartart/#setReversed-boolean-) zmienia kierunek diagramu z lewej‑do‑prawej na prawą‑do‑lewej lub z powrotem, gdy wybrany układ SmartArt obsługuje odwrócenie.

**Jak mogę skopiować SmartArt na ten sam slajd lub do innej prezentacji, zachowując formatowanie?**

Możesz [sklonować kształt SmartArt](/slides/pl/java/shape-manipulations/) za pomocą [ShapeCollection.addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) lub [sklonować cały slajd](/slides/pl/java/clone-slides/) zawierający SmartArt. Oba podejścia zachowują rozmiar, pozycję i formatowanie.

**Jak wyrenderować SmartArt do obrazu rastrowego w celu podglądu lub eksportu internetowego?**

[Renderuj slajd](/slides/pl/java/convert-powerpoint-to-png/) lub całą prezentację do formatu PNG lub JPEG. SmartArt jest renderowany jako część slajdu.

**Jak mogę znaleźć konkretny obiekt SmartArt na slajdzie, jeśli jest ich kilka?**

Ustaw unikalną wartość [Shape.getAlternativeText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getAlternativeText--) lub [Shape.getName](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getName--) na kształcie SmartArt, wyszukaj tę wartość w [BaseSlide.getShapes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseslide/#getShapes--), a następnie sprawdź, czy dopasowany kształt jest typu [ISmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ismartart/).