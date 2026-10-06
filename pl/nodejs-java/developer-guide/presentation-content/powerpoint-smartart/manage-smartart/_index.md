---
title: Zarządzanie SmartArt w prezentacjach PowerPoint przy użyciu JavaScript
linktitle: Zarządzaj SmartArt
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
description: "Dowiedz się, jak tworzyć i edytować SmartArt w PowerPoint przy użyciu Aspose.Slides dla Node.js, korzystając z przejrzystych przykładów kodu JavaScript, które przyspieszają projektowanie slajdów i automatyzację."
---
## **Przegląd**

SmartArt jest diagramem PowerPoint składającym się z węzłów, kształtów węzłów i układu. Dzięki Aspose.Slides for Node.js via Java możesz tworzyć SmartArt, odczytywać tekst z jego węzłów, zmieniać jego układ, przeglądać ukryte węzły, konfigurować układy wykresów organizacyjnych oraz tworzyć wykresy organizacyjne z obrazkami.

## **Pobieranie tekstu z obiektu SmartArt**

Węzeł SmartArt może zawierać jeden lub więcej kształtów. Aby odczytać tekst z kształtów węzła, iteruj przez [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/), a następnie odczytaj [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/), zwracany przez [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/).

Przykład wymaga prezentacji z co najmniej jednym slajdem oraz obiektem SmartArt jako pierwszym kształtem na tym slajdzie. Wypisuje każdy dostępny obiekt TextFrame w konsoli.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **Zmiana typu układu obiektu SmartArt**

Układ SmartArt kontroluje sposób rozmieszczenia i połączenia węzłów. Poniższy przykład tworzy obiekt SmartArt z wartością [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, zmienia go na wartość `BasicProcess` i zapisuje prezentację. Pozycja i rozmiar przekazywane do [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) są mierzone w punktach. Użyj [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/), aby zmienić układ.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sprawdzenie, czy węzeł SmartArt jest ukryty**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) wskazuje, czy węzeł jest ukryty w modelu danych SmartArt. Ukryte węzły mogą istnieć w strukturze, nawet gdy wybrany układ nie wyświetla ich jako widoczne elementy diagramu.

Poniższy przykład dodaje węzeł do obiektu SmartArt, który używa wartości [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` i sprawdza stan ukrycia dodanego węzła. Wypisuje komunikat, jeśli węzeł jest ukryty, i zapisuje diagram.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Pobieranie lub ustawianie układu wykresu organizacyjnego**

Dla diagramów SmartArt używających układu wykresu organizacyjnego, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) i [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) określają, jak węzły podrzędne są rozmieszczone pod węzłem nadrzędnym. Na przykład możesz ustawić węzły podrzędne, aby zwisały z lewej, prawej lub obu stron, w zależności od wybranego [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/).

Poniższy przykład tworzy wykres organizacyjny i ustawia układ pierwszego węzła na wartość [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. Indeks zerowy `0` wybiera pierwszy węzeł najwyższego poziomu; jego węzły podrzędne używają wybranego rozmieszczenia. Zmieniona prezentacja jest następnie zapisywana.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Utworzenie wykresu organizacyjnego z obrazkiem**

Wykres organizacyjny z obrazkiem to układ SmartArt przeznaczony do diagramów hierarchicznych zawierających miejsca na obrazy. Użyj wartości [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` przy dodawaniu obiektu SmartArt do slajdu. Ten przykład zapisuje diagram z miejscami na obrazy; nie wypełnia tych miejsc obrazami.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Konwersja diagramów dziedziczonych na grupy kształtów**

Podczas modernizacji istniejącej prezentacji możesz potrzebować zaktualizować wykres organizacyjny pierwotnie utworzony w PowerPoint 97–2003. Aspose.Slides reprezentuje te diagramy dziedziczone jako obiekty [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/). Użyj [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/), aby przekształcić diagram w grupę kształtów, co umożliwia edycję poszczególnych elementów wizualnych. Zobacz [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) po szczegóły.

Konwersja dodaje nową grupę do kolekcji kształtów bez usuwania pierwotnego diagramu. Po pomyślnej konwersji usuń oryginał przy użyciu [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/), aby uniknąć duplikatów. Zbierz diagramy dziedziczone do listy przed ich konwersją, aby dodawanie i usuwanie kształtów nie zakłócało iteracji.

Poniższy przykład otwiera prezentację, przeszukuje każdy slajd, konwertuje diagramy na grupy kształtów i zapisuje zaktualizowaną prezentację jako PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zapisana prezentacja zawiera edytowalne grupy kształtów zamiast skonwertowanych diagramów dziedziczonych, bez pozostawionych oryginalnych diagramów. Otwórz plik PPTX w PowerPoint, aby edytować poszczególne elementy w każdej grupie, takie jak tekst, wypełnienie czy pozycję.

## **Najczęściej zadawane pytania**

**Czy SmartArt obsługuje odbicie lustrzane lub odwrócenie dla języków RTL?**

Tak. Metoda [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) zmienia kierunek diagramu z lewej do prawej na prawą do lewej lub z powrotem, gdy wybrany układ SmartArt obsługuje odwrócenie.

**Jak mogę skopiować SmartArt na ten sam slajd lub do innej prezentacji, zachowując formatowanie?**

Możesz [sklonować kształt SmartArt](/slides/pl/nodejs-java/shape-manipulations/) przy użyciu [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) lub [sklonować cały slajd](/slides/pl/nodejs-java/clone-slides/) zawierający SmartArt. Oba podejścia zachowują rozmiar, pozycję i formatowanie.

**Jak wyrenderować SmartArt do obrazu rastrowego w celu podglądu lub eksportu sieciowego?**

[Renderuj slajd](/slides/pl/nodejs-java/convert-powerpoint-to-png/) lub całą prezentację do PNG lub JPEG. SmartArt jest renderowany jako część slajdu.

**Jak znaleźć konkretny obiekt SmartArt na slajdzie, jeśli jest ich kilka?**

Użyj [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) lub [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) , aby przypisać charakterystyczny tekst alternatywny lub nazwę do kształtu SmartArt, wyszukaj tę wartość w [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), a następnie sprawdź, czy pasujący kształt jest [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/).