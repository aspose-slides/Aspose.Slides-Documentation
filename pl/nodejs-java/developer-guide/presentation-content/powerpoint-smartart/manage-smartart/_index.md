---
title: Zarządzanie SmartArt w prezentacjach PowerPoint przy użyciu JavaScript
linktitle: Zarządzanie SmartArt
type: docs
weight: 10
url: /pl/nodejs-java/manage-smartart/
keywords:
- SmartArt
- tekst SmartArt
- typ układu
- właściwość ukryta
- diagram organizacyjny
- diagram organizacyjny z obrazkiem
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Naucz się tworzyć i edytować SmartArt w PowerPoint przy użyciu Aspose.Slides dla Node.js, korzystając z przejrzystych przykładów kodu JavaScript, które przyspieszają projektowanie slajdów i automatyzację."
---
## **Przegląd**

SmartArt to diagram PowerPoint utworzony z węzłów, kształtów węzłów i układu. Za pomocą Aspose.Slides for Node.js via Java możesz tworzyć SmartArt, odczytywać tekst z jego węzłów, zmieniać jego układ, sprawdzać ukryte węzły, konfigurować układy diagramów organizacyjnych oraz tworzyć diagramy organizacyjne z obrazkami.

## **Pobieranie tekstu z obiektu SmartArt**

Węzeł SmartArt może zawierać jeden lub więcej kształtów. Aby odczytać widoczny tekst, iteruj przez [SmartArt.getAllNodes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartart/#getAllNodes--), a następnie odczytaj [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) zwrócony przez [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartartshape/#getTextFrame--).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Zmiana typu układu obiektu SmartArt**

Układ SmartArt kontroluje sposób rozmieszczania i łączenia węzłów. Poniższy przykład tworzy obiekt SmartArt z wartością [SmartArtLayoutType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, zmienia go na wartość `BasicProcess` i zapisuje prezentację.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sprawdzanie, czy węzeł SmartArt jest ukryty**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartartnode/ishidden/) wskazuje, czy węzeł jest ukryty w modelu danych SmartArt. Ukryte węzły mogą istnieć w strukturze, nawet gdy wybrany układ nie wyświetla ich jako widoczne elementy diagramu.

Poniższy przykład dodaje węzeł do obiektu SmartArt, który używa wartości [SmartArtLayoutType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` i sprawdza stan ukrycia węzła.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Pobieranie lub ustawianie układu diagramu organizacyjnego**

Dla diagramów SmartArt wykorzystujących układ diagramu organizacyjnego, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) oraz [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) określają, w jaki sposób węzły potomne są rozmieszczane pod węzłem nadrzędnym. Na przykład możesz ustawić węzły potomne, aby zwisały po lewej, po prawej lub po obu stronach, w zależności od wybranego [OrganizationChartLayoutType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/organizationchartlayouttype/).

Poniższy przykład tworzy diagram organizacyjny i ustawia układ pierwszego węzła na wartość [OrganizationChartLayoutType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Utworzenie diagramu organizacyjnego z obrazkiem**

Diagram organizacyjny z obrazkiem to układ SmartArt przeznaczony do diagramów hierarchicznych zawierających miejsca na obrazy. Użyj wartości [SmartArtLayoutType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` podczas dodawania obiektu SmartArt do slajdu.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy SmartArt obsługuje odbicie lub odwrócenie dla języków RTL?**

Tak. Metoda [SmartArt.setReversed](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartart/setreversed/) zmienia kierunek diagramu z lewej-do-prawej na prawą-do-lewej lub odwrotnie, gdy wybrany układ SmartArt obsługuje odwrócenie.

**Jak mogę skopiować SmartArt na ten sam slajd lub do innej prezentacji, zachowując formatowanie?**

Możesz [klonować kształt SmartArt](/slides/pl/nodejs-java/shape-manipulations/) przy użyciu [ShapeCollection.addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/addclone/) lub [sklonować cały slajd](/slides/pl/nodejs-java/clone-slides/) zawierający SmartArt. Oba podejścia zachowują rozmiar, pozycję i formatowanie.

**Jak wyrenderować SmartArt do obrazu rastrowego w celu podglądu lub eksportu internetowego?**

[Renderuj slajd](/slides/pl/nodejs-java/convert-powerpoint-to-png/) lub całą prezentację do PNG lub JPEG. SmartArt jest renderowany jako część slajdu.

**Jak znaleźć konkretny obiekt SmartArt na slajdzie, jeśli jest ich kilka?**

Ustaw unikalną wartość [Shape.setAlternativeText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/setalternativetext/) lub [Shape.setName](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/setname/) na kształcie SmartArt, przeszukaj tę wartość w [BaseSlide.getShapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslide/#getShapes), a następnie sprawdź, czy pasujący kształt jest [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartart/).