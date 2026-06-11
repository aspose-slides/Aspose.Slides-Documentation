---
title: Zarządzanie SmartArt w prezentacjach PowerPoint na Androidzie
linktitle: Zarządzaj SmartArt
type: docs
weight: 10
url: /pl/androidjava/manage-smartart/
keywords:
- SmartArt
- Tekst SmartArt
- typ układu
- właściwość ukrycia
- diagram organizacyjny
- diagram organizacyjny z obrazem
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Naucz się tworzyć i edytować SmartArt w PowerPoint za pomocą Aspose.Slides dla Androida, korzystając z przejrzystych przykładów kodu Java, które przyspieszają projektowanie slajdów i automatyzację."
---
## **Overview**

SmartArt jest diagramem PowerPoint składającym się z węzłów, kształtów węzłów i układu. Za pomocą Aspose.Slides dla Androida przez Java możesz tworzyć SmartArt, odczytywać tekst z jego węzłów, zmieniać układ, przeglądać ukryte węzły, konfigurować układy diagramu organizacyjnego oraz tworzyć diagramy organizacyjne z obrazkami.

## **Get Text from a SmartArt Object**

Węzeł SmartArt może zawierać jeden lub więcej kształtów. Aby odczytać widoczny tekst, przeglądaj wszystkie węzły za pomocą [ISmartArt.getAllNodes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ismartart/#getAllNodes--), a następnie odczytaj [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/) zwrócony przez [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

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

## **Change the Layout Type of a SmartArt Object**

Układ SmartArt określa, jak węzły są rozmieszczone i połączone. Poniższy przykład tworzy obiekt SmartArt z wartością [SmartArtLayoutType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`, zmienia go na wartość `BasicProcess` i zapisuje prezentację.

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

## **Check Whether a SmartArt Node Is Hidden**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ismartartnode/#isHidden--) wskazuje, czy węzeł jest ukryty w modelu danych SmartArt. Ukryte węzły mogą istnieć w strukturze, nawet gdy wybrany układ nie wyświetla ich jako widoczne elementy diagramu.

Poniższy przykład dodaje węzeł do obiektu SmartArt, który używa wartości [SmartArtLayoutType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtLayoutType) `RadialCycle` i sprawdza stan ukrycia węzła.

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

## **Get or Set the Organization Chart Layout**

W diagramach SmartArt wykorzystujących układ diagramu organizacyjnego, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) i [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) określają, jak węzły potomne są rozmieszczone pod węzłem nadrzędnym. Na przykład, można ustawić węzły potomne, aby zwisały po lewej, prawej lub po obu stronach, w zależności od wybranego [OrganizationChartLayoutType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/OrganizationChartLayoutType).

Poniższy przykład tworzy diagram organizacyjny i ustawia układ pierwszego węzła na wartość [OrganizationChartLayoutType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`.

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

## **Create a Picture Organization Chart**

Diagram organizacyjny ze zdjęciem to układ SmartArt przeznaczony do diagramów hierarchicznych zawierających miejsca na obrazy. Użyj wartości [SmartArtLayoutType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` podczas dodawania obiektu SmartArt do slajdu.

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

**Does SmartArt support mirroring or reversing for RTL languages?**

Tak. Metoda [ISmartArt.setReversed](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) zmienia kierunek diagramu z lewej do prawej na prawą do lewej lub z powrotem, gdy wybrany układ SmartArt obsługuje odwrócenie.

**How can I copy SmartArt to the same slide or to another presentation while preserving formatting?**

Możesz [sklonować kształt SmartArt](/slides/pl/androidjava/shape-manipulations/) za pomocą [ShapeCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) lub [sklonować cały slajd](/slides/pl/androidjava/clone-slides/) zawierający SmartArt. Oba podejścia zachowują rozmiar, pozycję i formatowanie.

**How do I render SmartArt to a raster image for preview or web export?**

[Renderuj slajd](/slides/pl/androidjava/convert-powerpoint-to-png/) lub całą prezentację do PNG lub JPEG. SmartArt jest renderowany jako część slajdu.

**How can I find a specific SmartArt object on a slide if there are several?**

Ustaw wyróżniający [Shape.getAlternativeText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getAlternativeText--) lub [Shape.getName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getName--) na kształcie SmartArt, wyszukaj tę wartość w [BaseSlide.getShapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseslide/#getShapes--), a następnie sprawdź, czy pasujący kształt jest [ISmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ismartart/).