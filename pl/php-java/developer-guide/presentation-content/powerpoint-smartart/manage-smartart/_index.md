---
title: Zarządzanie SmartArt w prezentacjach PowerPoint przy użyciu PHP
linktitle: Zarządzaj SmartArt
type: docs
weight: 10
url: /pl/php-java/manage-smartart/
keywords:
- SmartArt
- tekst SmartArt
- typ układu
- ukryta właściwość
- diagram organizacyjny
- diagram organizacyjny ze zdjęciem
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i edytować SmartArt w PowerPoint przy użyciu Aspose.Slides for PHP via Java, korzystając z przejrzystych przykładów kodu, które przyspieszają projektowanie slajdów i automatyzację."
---
## **Przegląd**

SmartArt to diagram PowerPoint utworzony z węzłów, kształtów węzłów i układu. Za pomocą Aspose.Slides for PHP via Java możesz tworzyć SmartArt, odczytywać tekst z jego węzłów, zmieniać jego układ, sprawdzać ukryte węzły, konfigurować układy diagramów organizacyjnych oraz tworzyć diagramy organizacyjne z obrazkami.

## **Pobieranie tekstu z obiektu SmartArt**

Węzeł SmartArt może zawierać jeden lub więcej kształtów. Aby odczytać tekst z kształtów węzła, iteruj przez [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/), a następnie odczytaj [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) zwracany przez [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/).

Przykład wymaga prezentacji zawierającej co najmniej jeden slajd oraz obiekt SmartArt jako pierwszy kształt na tym slajdzie. Wyświetla każdą dostępną ramkę tekstową w konsoli.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Zmiana typu układu obiektu SmartArt**

Układ SmartArt określa, jak węzły są rozmieszczane i połączone. Poniższy przykład tworzy obiekt SmartArt z wartością [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, zmienia ją na wartość `BasicProcess` i zapisuje prezentację. Pozycja i rozmiar przekazywane do [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) są mierzone w punktach. Użyj [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) aby zmienić układ.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sprawdzanie, czy węzeł SmartArt jest ukryty**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) wskazuje, czy węzeł jest ukryty w modelu danych SmartArt. Ukryte węzły mogą istnieć w strukturze, nawet gdy wybrany układ nie wyświetla ich jako widoczne elementy diagramu.

Poniższy przykład dodaje węzeł do obiektu SmartArt, który używa wartości [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` i sprawdza stan ukrycia dodanego węzła. Wyświetla komunikat, jeśli węzeł jest ukryty, i zapisuje diagram.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Pobieranie lub ustawianie układu diagramu organizacyjnego**

W diagramach SmartArt wykorzystujących układ diagramu organizacyjnego, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) i [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) określają, jak węzły podrzędne są rozmieszczane pod węzłem nadrzędnym. Na przykład możesz ustawić węzły podrzędne, aby zwisały po lewej, po prawej lub po obu stronach, w zależności od wybranego [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/).

Poniższy przykład tworzy diagram organizacyjny i ustawia układ pierwszego węzła na wartość [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. Indeks zerowy `0` wybiera pierwszy węzeł najwyższego poziomu; jego węzły podrzędne używają wybranego układu. Zmodyfikowana prezentacja zostaje następnie zapisana.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Utworzenie diagramu organizacyjnego ze zdjęciami**

Diagram organizacyjny ze zdjęciami to układ SmartArt zaprojektowany dla diagramów hierarchii, które zawierają miejsca na obrazy. Użyj wartości [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` przy dodawaniu obiektu SmartArt do slajdu. Ten przykład zapisuje diagram z miejscami na obrazy; nie wypełnia tych miejsc obrazami.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Konwersja starszych diagramów na grupy kształtów**

Podczas modernizacji istniejącej prezentacji może być konieczna aktualizacja diagramu organizacyjnego stworzonego pierwotnie w PowerPoint 97–2003. Aspose.Slides reprezentuje te starsze diagramy jako obiekty [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/). Użyj [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/), aby przekształcić diagram w grupę kształtów, co umożliwia edycję poszczególnych elementów wizualnych. Szczegóły znajdziesz w [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/).

Konwersja dodaje nową grupę do kolekcji kształtów bez usuwania oryginalnego diagramu. Po pomyślnej konwersji usuń oryginał przy użyciu [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) , aby uniknąć duplikatów. Zbierz starsze diagramy w listę przed ich konwersją, aby dodawanie i usuwanie kształtów nie zakłócało iteracji.

Poniższy przykład otwiera prezentację, przeszukuje każdy slajd, konwertuje diagramy na grupy kształtów i zapisuje zaktualizowaną prezentację jako PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Zapisana prezentacja zawiera edytowalne grupy kształtów w miejscu skonwertowanych starszych diagramów, bez pozostawionych oryginalnych diagramów. Otwórz plik PPTX w programie PowerPoint, aby edytować poszczególne elementy w każdej grupie, takie jak tekst, wypełnienie czy pozycję.

## **FAQ**

**Czy SmartArt obsługuje odbijanie lub odwracanie dla języków RTL?**

Tak. Metoda [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) zmienia kierunek diagramu z lewej do prawej na prawą do lewej lub odwrotnie, gdy wybrany układ SmartArt obsługuje odwrócenie.

**Jak mogę skopiować SmartArt na tym samym slajdzie lub do innej prezentacji, zachowując formatowanie?**

Możesz [klonować kształt SmartArt](/slides/pl/php-java/shape-manipulations/) za pomocą [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) lub [klonować cały slajd](/slides/pl/php-java/clone-slides/) zawierający SmartArt. Oba podejścia zachowują rozmiar, pozycję i formatowanie.

**Jak wyrenderować SmartArt do obrazu rastrowego w celu podglądu lub eksportu internetowego?**

[Renderuj slajd](/slides/pl/php-java/convert-powerpoint-to-png/) lub całą prezentację do PNG lub JPEG. SmartArt jest renderowany jako część slajdu.

**Jak znaleźć konkretny obiekt SmartArt na slajdzie, jeśli jest ich kilka?**

Użyj [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) lub [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) , aby przypisać wyróżniający się tekst alternatywny lub nazwę do kształtu SmartArt, przeszukaj tę wartość w [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes), a następnie sprawdź, czy dopasowany kształt jest [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/).