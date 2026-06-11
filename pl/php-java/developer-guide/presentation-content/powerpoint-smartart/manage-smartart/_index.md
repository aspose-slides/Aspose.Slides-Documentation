---
title: Zarządzaj SmartArt w prezentacjach PowerPoint przy użyciu PHP
linktitle: Zarządzaj SmartArt
type: docs
weight: 10
url: /pl/php-java/manage-smartart/
keywords:
- SmartArt
- Tekst SmartArt
- typ układu
- właściwość ukryta
- wykres organizacyjny
- wykres organizacyjny z obrazkiem
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Naucz się tworzyć i edytować SmartArt w PowerPoint przy użyciu Aspose.Slides for PHP via Java, korzystając z przejrzystych przykładów kodu, które przyspieszają projektowanie slajdów i automatyzację."
---
## **Przegląd**

SmartArt jest diagramem PowerPoint utworzonym z węzłów, kształtów węzłów i układu. Dzięki Aspose.Slides for PHP via Java możesz tworzyć SmartArt, odczytywać tekst z jego węzłów, zmieniać jego układ, przeglądać ukryte węzły, konfigurować układy wykresów organizacyjnych oraz tworzyć diagramy organizacyjne z obrazkami.

## **Pobieranie tekstu z obiektu SmartArt**

Węzeł SmartArt może zawierać jeden lub więcej kształtów. Aby odczytać widoczny tekst, przeiteruj po [SmartArt::getAllNodes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/#getAllNodes), a następnie odczytaj [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) zwrócony przez [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartshape/#getTextFrame).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Zmiana typu układu obiektu SmartArt**

Układ SmartArt kontroluje sposób rozmieszczania i łączenia węzłów. Poniższy przykład tworzy obiekt SmartArt z wartością [SmartArtLayoutType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, zmienia ją na wartość `BasicProcess` i zapisuje prezentację.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sprawdzenie, czy węzeł SmartArt jest ukryty**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartnode/ishidden/) wskazuje, czy węzeł jest ukryty w modelu danych SmartArt. Ukryte węzły mogą istnieć w strukturze, nawet gdy wybrany układ nie wyświetla ich jako widoczne elementy diagramu.

Poniższy przykład dodaje węzeł do obiektu SmartArt, który używa wartości [SmartArtLayoutType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` i sprawdza stan ukrycia węzła.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Pobieranie lub ustawianie układu wykresu organizacyjnego**

W przypadku diagramów SmartArt używających układu wykresu organizacyjnego, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) i [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) określają, w jaki sposób węzły podrzędne są rozmieszczane pod węzłem nadrzędnym. Na przykład możesz ustawić węzły podrzędne, aby zwisały po lewej, prawej lub po obu stronach, w zależności od wybranego [OrganizationChartLayoutType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/organizationchartlayouttype/).

Poniższy przykład tworzy wykres organizacyjny i ustawia układ dla pierwszego węzła na wartość [OrganizationChartLayoutType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Utworzenie wykresu organizacyjnego z obrazkiem**

Wykres organizacyjny z obrazkiem to układ SmartArt zaprojektowany dla diagramów hierarchii, które zawierają miejsca na obrazy. Użyj wartości [SmartArtLayoutType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` przy dodawaniu obiektu SmartArt na slajd.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Czy SmartArt obsługuje odbicie lub odwrócenie dla języków RTL?**

Tak. Metoda [SmartArt::setReversed](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/setreversed/) zmienia kierunek diagramu z lewej‑do‑prawej na prawą‑do‑lewej lub odwrotnie, gdy wybrany układ SmartArt obsługuje odwrócenie.

**Jak mogę skopiować SmartArt na ten sam slajd lub do innej prezentacji, zachowując formatowanie?**

Możesz [sklonować kształt SmartArt](/slides/pl/php-java/shape-manipulations/) za pomocą [ShapeCollection::addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addclone/) lub [sklonować cały slajd](/slides/pl/php-java/clone-slides/) zawierający SmartArt. Oba podejścia zachowują rozmiar, pozycję i formatowanie.

**Jak wyrenderować SmartArt do obrazu rastrowego w celu podglądu lub eksportu na stronę?**

[Renderuj slajd](/slides/pl/php-java/convert-powerpoint-to-png/) lub całą prezentację do PNG lub JPEG. SmartArt jest renderowany jako część slajdu.

**Jak mogę znaleźć konkretny obiekt SmartArt na slajdzie, jeśli jest ich kilka?**

Ustaw unikalną wartość [Shape::getAlternativeText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getalternativetext/) lub [Shape::getName](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getname/) na kształcie SmartArt, przeszukaj tę wartość w [BaseSlide::getShapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslide/#getShapes), a następnie sprawdź, czy dopasowany kształt jest [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/).