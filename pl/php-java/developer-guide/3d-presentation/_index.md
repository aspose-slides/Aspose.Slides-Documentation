---
title: Tworzenie efektów 3D w prezentacjach przy użyciu PHP
linktitle: Prezentacja 3D
type: docs
weight: 232
url: /pl/php-java/3d-presentation/
keywords:
- PowerPoint 3D
- prezentacja 3D
- obrót 3D
- głębokość 3D
- ekstruzja 3D
- gradient 3D
- tekst 3D
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Zastosuj i renderuj efekty 3D dla kształtów i tekstu PowerPoint w PHP przy użyciu Aspose.Slides. Skonfiguruj kamerę, oświetlenie, materiał, ekstruzję, wypełnienia i tekst 3D."
---
## **Przegląd**

Aspose.Slides for PHP via Java może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPoint dla kształtów i tekstu. Ten artykuł opisuje efekty 3D, takie jak obrót, ekstruzja, fazowanie, oświetlenie, materiał, wypełnienia gradientowe lub obrazkowe oraz tekst 3D.

{{% alert color="primary" %}}
Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w PowerPoint. Nie dotyczy on wstawiania ani edytowania samodzielnych plików modeli 3D. Kiedy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D w wyjściowym 2D.
{{% /alert %}}

## **Koncepcje formatowania 3D**

Użyj klasy [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/) i jej [Shape::getThreeDFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getThreeDFormat--) metody, aby zastosować formatowanie 3D do kształtu. Metoda zwraca [ThreeDFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/), który steruje sceną 3D dla tego kształtu.

Dla tekstu użyj klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/) oraz jej [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/#getThreeDFormat--) metody. To stosuje formatowanie 3D do ramki tekstowej zamiast do ciała kształtu.

Najważniejsze ustawienia to:

| Metoda lub ustawienie | Co kontroluje | Kiedy używać |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/#getCamera--) | Punkt widzenia, predefiniowany typ kamery, obrót, przybliżenie i perspektywa. | Obróć obiekt w przestrzeni 3D lub dopasuj do predefiniowanego obrotu 3D w PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/#getLightRig--) | Predefiniowane oświetlenie, kierunek i obrót światła. | Zmień sposób, w jaki podświetlenia i cienie pojawiają się na powierzchni 3D. |
| [setMaterial](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Materiał powierzchni, taki jak płaski, matowy, plastikowy lub metalowy. | Spraw, by ta sama geometria wyglądała na płaską, miękką, błyszczącą lub metaliczną. |
| [setExtrusionHeight](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Jak daleko kształt wystaje w tył od swojej przedniej powierzchni. | Przekształć płaski kształt w widocznie grubą bryłę 3D. |
| [getExtrusionColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Kolor wyciągniętych boków. | Umożliw widoczność głębokości lub dopasuj kolor boków do wypełnienia przedniej powierzchni. |
| [setDepth](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/#setDepth-double-) | Dodatkowa głębokość 3D używana przez formatowanie 3D w PowerPoint. | Dostrój głębokość dla kształtów lub tekstu, szczególnie w połączeniu z ustawieniami fazowania i materiału. |
| [getBevelTop](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/#getBevelTop--) i [getBevelBottom](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/#getBevelBottom--) | Wypukłe lub zaokrąglone krawędzie na przedniej i tylnej powierzchni. | Dodaj zmiękczoną lub kształtowaną krawędź zamiast ostrej płaskiej powierzchni. |
| [getContourColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/#getContourColor--) i [setContourWidth](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Obrys wokół obiektu 3D. | Podkreśl granicę obiektu w renderowanym wyjściu. |

## **Utworzenie kształtu 3D**

Kształt zazwyczaj wymaga czterech rodzajów ustawień, aby wyglądał przekonująco 3D:

- Ustawienia kamery, ponieważ domyślny widok frontu może ukrywać ekstruzję.  
- Ustawienia światła, ponieważ oświetlenie sprawia, że powierzchnie i boki są widoczne.  
- Ustawienia materiału, ponieważ powierzchnia wpływa na to, jak światło jest renderowane.  
- Ustawienia ekstruzji lub głębokości, ponieważ płaski kształt potrzebuje grubości.

Poniższy przykład tworzy prostokąt, dodaje tekst do jego przedniej powierzchni, stosuje formatowanie 3D, zapisuje prezentację jako PPTX i renderuje slajd do obrazu PNG.

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Renderowany obraz slajdu pokazuje prostokąt jako grubą bryłę 3D:

![Renderowany niebieski prostokąt 3D z białym tekstem 3D na przedniej powierzchni](img_01_01.png)

## **Obracanie kształtu za pomocą kamery**

W PowerPoint rotacja 3D jest konfigurowana w panelu 3‑D Rotation. Wartości rotacji X, Y i Z odpowiadają rotacji ustawionej za pomocą API kamery.

![Panel 3‑D Rotation w PowerPoint z podświetlonymi wartościami rotacji X, Y i Z](img_02_01.png)

W Aspose.Slides ustaw typ kamery i rotację za pomocą [ThreeDFormat::getCamera](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/#getCamera--):

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

Użyj kamery, gdy potrzebujesz zmienić sposób, w jaki widz widzi obiekt. Nie zmienia ona geometrii kształtu 2D na slajdzie. Zmienia ona punkt widzenia 3D używany przez PowerPoint i Aspose.Slides podczas renderowania.

## **Dodanie ekstruzji i głębokości**

Ekstruzja sprawia, że kształt wygląda na gruby, wydłużając go za przednią powierzchnię. W PowerPoint kontrolka głębokości ustawia tę widoczną grubość, a kontrolka koloru określa kolor boków.

![Kontrolki głębokości w PowerPoint powiązane z właściwościami koloru ekstruzji i wysokości ekstruzji](img_02_02.png)

Ustaw [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) dla grubości i [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/#getExtrusionColor--) dla koloru boków:

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

Użyj [ThreeDFormat::setDepth](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/#setDepth-double-) , gdy potrzebujesz pracować bezpośrednio z wartością głębokości w PowerPoint lub łączyć głębokość z fazowaniem, materiałem i efektami tekstu. W wielu scenariuszach kształtu `setExtrusionHeight` jest jaśniejszym ustawieniem, ponieważ bezpośrednio określa widoczną ekstruzję.

## **Użycie wypełnień gradientowych lub obrazkowych z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Możesz zastosować jednolity kolor, gradient, wzór lub wypełnienie obrazkiem na przedniej powierzchni i nadal używać tych samych ustawień kamery, światła, materiału i ekstruzji.

Ten przykład stosuje wypełnienie gradientowe do kształtu i ciemniejszy kolor ekstruzji na bokach:

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

![Renderowany prostokąt 3D z wypełnieniem gradientowym od niebieskiego do pomarańczowego oraz pomarańczową ekstruzją](img_02_03.png)

Aby zamiast tego użyć wypełnienia obrazkiem, dodaj obraz do prezentacji i przypisz go jako wypełnienie kształtu:

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

![Renderowany prostokąt 3D z wypełnieniem zdjęciem na przedniej powierzchni i pomarańczową ekstruzją](img_02_04.png)

## **Zastosowanie formatowania 3D do tekstu**

Formatowanie 3D kształtu wpływa na ciało kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne w efektach podobnych do WordArt, gdzie same litery potrzebują ekstruzji, materiału, oświetlenia i ustawień kamery.

Poniższy przykład tworzy tekst z wypełnieniem wzorem, stosuje transformację WordArt i konfiguruje ustawienia 3D w [TextFrameFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/):

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Renderowany tekst 3D z wygiętą transformacją WordArt, pomarańczowym wypełnieniem wzorem oraz ciemną ekstruzją](img_02_05.png)

## **Zachowanie przy eksporcie i renderowaniu**

Aspose.Slides zachowuje formatowanie 3D przy zapisywaniu do formatów PowerPoint takich jak PPTX. Podczas renderowania lub eksportu do formatów o stałym układzie scena 3D jest rasteryzowana lub rysowana do wyniku jako 2D. Dotyczy to, gdy renderujesz slajdy do [PNG](/slides/pl/php-java/convert-powerpoint-to-png/), eksportujesz do [PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/), eksportujesz do [HTML](/slides/pl/php-java/convert-powerpoint-to-html/), lub generujesz klatki do [video conversion](/slides/pl/php-java/convert-powerpoint-to-video/).

Pamiętaj o następujących punktach:

- Wyeksportowane obrazy i pliki PDF nie są interaktywne. Obiekt nie może być obracany przez widza po eksporcie.  
- Końcowy wygląd zależy od kombinacji kamery, zestawu świateł, materiału, ekstruzji, wypełnienia i skalowania slajdu.  
- Jeśli potrzebujesz sprawdzić dziedziczone lub oparte na temacie wartości formatowania, przeczytaj [effective shape properties](/slides/pl/php-java/shape-effective-properties/).  
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D PowerPoint. W tych formatach efekt wizualny jest renderowany, a nie zachowywany jako edytowalne ustawienia 3D.

## **FAQ**

**Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?**

Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie tworzy interaktywnych scen 3D w wyeksportowanych obrazach, plikach PDF ani stronach HTML, które widz mógłby obracać. W PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, o ile format to obsługuje.

**Jaka jest różnica między modelem 3D a efektem 3D?**

Model 3D to osobny obiekt 3D wstawiany do prezentacji. Efekt 3D to formatowanie zastosowane do zwykłego kształtu lub tekstu w PowerPoint, takie jak obrót, ekstruzja, fazowanie, oświetlenie i materiał. Ten artykuł opisuje efekty 3D.

**Jakie ustawienia są wymagane dla widocznego kształtu 3D?**

Co najmniej należy ustawić obrót kamery oraz ekstruzję lub głębokość. W praktyce warto także ustawić zestaw świateł i materiał, aby renderowane powierzchnie posiadały wyraźne podświetlenia i cienie.

**Czy mogę zastosować efekty 3D zarówno do kształtów, jak i tekstu?**

Tak. Użyj [Shape::getThreeDFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getThreeDFormat--) dla ciała kształtu i [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/#getThreeDFormat--) dla tekstu.

**Czy efekty 3D pojawią się przy eksporcie do obrazów, PDF, HTML lub klatek wideo?**

Tak. Aspose.Slides renderuje efekty 3D przy tworzeniu obrazów slajdów, wyjścia PDF, wyjścia HTML oraz klatek używanych do konwersji wideo. Wyeksportowane wyjście zawiera renderowany wygląd, a nie edytowalny obiekt 3D.

**Czy mogę odczytać ostateczne wartości 3D po zastosowaniu dziedziczenia i ustawień motywu?**

Tak. Skorzystaj z interfejsów API efektywnego formatowania opisanych w [Shape Effective Properties](/slides/pl/php-java/shape-effective-properties/), aby odczytać ostateczne wartości kamery, zestawu świateł, fazowania i powiązane wartości 3D.