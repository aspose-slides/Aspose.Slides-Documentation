---
title: Tworzenie efektów 3D w prezentacjach przy użyciu Node.js
linktitle: Prezentacja 3D
type: docs
weight: 232
url: /pl/nodejs-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentacja
- 3D rotacja
- 3D głębokość
- 3D ekstruzja
- 3D gradient
- 3D tekst
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zastosuj i renderuj efekty 3D dla kształtów i tekstu PowerPoint w Node.js przy użyciu Aspose.Slides. Skonfiguruj kamerę, oświetlenie, materiał, ekstruzję, wypełnienia i tekst 3D."
---
## **Przegląd**

Aspose.Slides for Node.js via Java może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPoint dla kształtów i tekstu. Ten artykuł opisuje efekty 3D, takie jak rotacja, ekstruzja, fazowania, oświetlenie, materiały, wypełnienia gradientowe lub obrazkowe oraz tekst 3D.

{{% alert color="info" title="Note" %}}
Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w PowerPoint. Nie dotyczy wstawiania ani edycji oddzielnych plików modeli 3D. Gdy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D w wyjściowym 2D.
{{% /alert %}}

## **Koncepcje formatowania 3D**

Użyj metody [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat), aby zastosować formatowanie 3D do kształtu. Metoda zwraca [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/), które kontroluje scenę 3D dla tego kształtu.

Dla tekstu użyj metody [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). To stosuje formatowanie 3D do ramki tekstowej zamiast do ciała kształtu.

Najważniejsze elementy API są:

| Członek API | Co kontroluje | Kiedy używać |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) | Punkt widzenia, typ kamery predefiniowany, rotacja, przybliżenie i perspektywa. | Obróć obiekt w przestrzeni 3D lub dopasuj do predefiniowanego ustawienia rotacji 3D w PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getLightRig) | Predefiniowane oświetlenie, kierunek i rotacja światła. | Zmieniaj sposób, w jaki podświetlenia i cienie pojawiają się na powierzchni 3D. |
| [getMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getMaterial) i [setMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setMaterial) | Materiał powierzchni, np. płaski, matowy, plastikowy lub metalowy. | Spraw, aby ta sama geometria wyglądała płasko, miękko, błyszcząco lub metalicznie. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) i [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Jak daleko kształt rozciąga się w tył od swojej przedniej powierzchni. | Zamień płaski kształt w widocznie gruby obiekt 3D. |
| [getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Kolor wyciągniętych boków. | Uwydatnij głębię lub zsynchronizuj kolor boków z wypełnieniem przedniej części. |
| [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getDepth) i [setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) | Dodatkowa głębia 3D używana przez formatowanie 3D w PowerPoint. | Dokładnie dopasuj głębię dla kształtów lub tekstu, zwłaszcza w połączeniu z ustawieniami fazowania i materiału. |
| [getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) i [getBevelBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Podniesione lub zaokrąglone krawędzie na przedniej i tylnej powierzchni. | Dodaj zmiękczony lub formowany brzeg zamiast ostrej płaskiej powierzchni. |
| [getContourColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourWidth) i [setContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Obrys wokół obiektu 3D. | Podkreśl granicę obiektu w renderowanym wyniku. |

## **Utworzenie kształtu 3D**

Kształt zwykle wymaga czterech rodzajów ustawień, aby wyglądał przekonująco 3D:

- Ustawienia kamery, ponieważ domyślny widok z przodu może ukrywać ekstruzję.
- Ustawienia światła, ponieważ oświetlenie sprawia, że powierzchnie i boki są czytelne.
- Ustawienia materiału, ponieważ powierzchnia wpływa na sposób renderowania światła.
- Ustawienia ekstruzji lub głębi, ponieważ płaski kształt potrzebuje grubości.

Poniższy przykład tworzy prostokąt, dodaje tekst do jego przedniej powierzchni i stosuje formatowanie 3D. Wartości rotacji kamery podawane są w stopniach, a wysokość ekstruzji wynosi 100 punktów. Przykład renderuje slajd do obrazu PNG w dwukrotności domyślnych wymiarów i zapisuje prezentację jako PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wyrenderowany obraz slajdu pokazuje prostokąt jako gruby blok 3D:

![Wyrenderowany niebieski prostokąt 3D z biały tekst 3D na przedniej powierzchni](img_01_01.png)

## **Obrócenie kształtu przy użyciu kamery**

W PowerPoint rotacja 3D jest konfigurowana w panelu Rotacja 3‑D. Wartości rotacji X, Y i Z odpowiadają rotacji ustawionej przez API kamery.

![Panel rotacji 3D w PowerPoint z podświetlonymi wartościami rotacji X, Y i Z](img_02_01.png)

W Aspose.Slides dostęp do kamery uzyskuje się przez [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera). Ten przykład tworzy prostokąt, wybiera ortograficzny widok z przodu i ustawia rotacje X, Y i Z na odpowiednio 20, 30 i 40 stopni. Konfiguruje kształt w pamięci bez zapisywania pliku:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Używaj kamery, gdy musisz zmienić sposób, w jaki widz widzi obiekt. Nie zmienia to geometrii 2D kształtu na slajdzie. Zmienia to punkt widzenia 3D używany przez PowerPoint i Aspose.Slides podczas renderowania.

### **Skopiuj orientację kamery z kształtu szablonu**

Aby dopasować orientację kształtu szablonu, odczytaj jego predefiniowaną kamerę za pomocą [getCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getCameraType) oraz kąty rotacji za pomocą [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getRotation). Przykład otwiera `template.pptx` i kopiuje orientację kamery z pierwszego kształtu na pierwszym slajdzie do drugiego kształtu. Oba kształty mają już oświetlenie 3D, a drugi kształt nie ma explicite ustawionej rotacji kamery.

Kąty podawane są w stopniach. Indeks `0` to szerokość geograficzna, indeks `1` to długość geograficzna, a indeks `2` to obrót. Przekaż je do [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) w tej kolejności. Jeśli źródło zwróci `null`, nie ma explicite rotacji, więc pozostaw kąty drugiego kształtu nieustawione. Explicite ustawienie rotacji `(0, 0, 0)` zwraca trzy zera i powinno zostać skopiowane.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    const destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    const angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Po ponownym otwarciu `camera-copy.pptx` w PowerPoint strzałka po prawej ma taki sam predefiniowany typ kamery i rotację jak prostokąt po lewej. Oba kształty używają tego samego oświetlenia i głębokości ekstruzji.

![Niebieski prostokąt 3D i strzałka w prawo z dopasowaną orientacją kamery, widziane z góry i z prawej strony](camera-orientation.png)

## **Dodaj ekstruzję i głębię**

Ekstruzja sprawia, że kształt wygląda na gruby, wydłużając go za przednią powierzchnią. W PowerPoint kontrolka głębokości ustawia tę widoczną grubość, a kontrolka koloru ustawia kolor boków.

![Kontrolki głębokości w PowerPoint powiązane z właściwościami koloru ekstruzji i wysokości ekstruzji](img_02_02.png)

Użyj [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight), aby ustawić grubość, oraz [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor), aby odczytać kolor boków. Ten przykład nadaje prostokątowi ekstruzję 100 punktów z fioletowymi bokami i obraca kamerę, aby pokazać jego grubość. Konfiguruje kształt w pamięci bez zapisywania pliku:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Metoda [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) ustawia głębokość kształtu 3D. Metoda [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) kontroluje wysokość efektu ekstruzji, jak pokazano w tym przykładzie.

## **Użyj wypełnień gradientowych lub obrazkowych z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Możesz zastosować jednolity kolor, gradient, wzór lub wypełnienie obrazem do przedniej powierzchni i nadal używać tych samych ustawień kamery, światła, materiału i ekstruzji.

Ten przykład stosuje gradient od niebieskiego do pomarańczowego na przedniej powierzchni oraz ciemnopomarańczowy kolor na ekstruzję 150 punktów. Przerwy gradientu przy 0 i 100 oznaczają początek i koniec gradientu. Wartości rotacji kamery podawane są w stopniach. Slajd renderowany jest do obrazu PNG w dwukrotności domyślnych wymiarów:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

Wyrenderowany wynik zachowuje gradient na przedniej powierzchni i renderuje ekstruzję osobno:

![Wyrenderowany prostokąt 3D z wypełnieniem gradientowym od niebieskiego do pomarańczowego oraz pomarańczową ekstruzją](img_02_03.png)

Aby użyć wypełnienia obrazem, dodaj obraz do prezentacji i przypisz go jako wypełnienie kształtu. Ten przykład wymaga istniejącego pliku o nazwie "image.jpg" w katalogu roboczym. Rozciąga obraz, aby wypełnić prostokąt, stosuje ekstruzję 150 punktów i ustawia rotację kamery w stopniach. Konfiguruje kształt w pamięci bez zapisywania lub renderowania pliku:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Obraz renderowany jest na przedniej powierzchni, podczas gdy ekstruzja renderowana jest jako boczna powierzchnia 3D:

![Wyrenderowany prostokąt 3D z wypełnieniem zdjęciem na przedniej powierzchni i pomarańczową ekstruzją](img_02_04.png)

## **Zastosowanie formatowania 3D do tekstu**

Formatowanie 3D kształtu wpływa na ciało kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne przy efektach podobnych do WordArt, gdzie same litery wymagają ekstruzji, materiału, oświetlenia i ustawień kamery.

Poniższy przykład tworzy tekst z pomarańczowo‑białym wzorem kratki, stosuje łuk w górę i konfiguruje ustawienia 3D przez [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Wysokość i głębokość ekstruzji podawane są w punktach, a rotacja światła w stopniach. Wypełnienie i obrys kształtu są ukryte, aby widoczny był tylko tekst. Przykład renderuje obraz PNG w dwukrotności domyślnych wymiarów slajdu i zapisuje prezentację jako PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tekst renderowany jest jako zakrzywione, wyciągnięte litery 3D:

![Wyrenderowany tekst 3D z łukowym przekształceniem WordArt, pomarańczowym wypełnieniem wzorem i ciemną ekstruzją](img_02_05.png)

## **Utrzymaj tekst płaskim na kształcie 3D**

Aby zachować czytelność tekstu przy jednoczesnym zachowaniu wyglądu 3D kształtu, wywołaj [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) przez [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). Gdy wartość jest `true`, tekst pozostaje poza sceną 3D. Gdy jest `false`, tekst uczestniczy w scenie i podąża za jej orientacją 3D.

To ustawienie nie usuwa formatowania 3D kształtu: jego kamera, oświetlenie, materiał i ekstruzja pozostają skonfigurowane przez [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat). Jest to także inne niż zwykła rotacja. [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) obraca kształt w płaszczyźnie slajdu, podczas gdy [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) steruje niestandardową rotacją tekstu w jego ramce. Pozostawienie tekstu poza sceną 3D nie resetuje żadnego z tych kątów.

Poniższy samodzielny przykład tworzy niebieski prostokąt z tekstem i klonuje go obok oryginału. Oba kształty mają to samo formatowanie 3D; różni je tylko ustawienie tekstu: `false` po lewej i `true` po prawej. Kąty kamery podawane są w stopniach, a wysokość ekstruzji wynosi 40 punktów. Przykład zapisuje prezentację jako PPTX i renderuje slajd porównawczy do PNG w dwukrotności domyślnych wymiarów.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Po lewej tekst podąża za orientacją 3D. Po prawej pozostaje płaski i łatwiejszy do odczytania. Oba prostokąty zachowują tę samą widoczną ekstruzję i orientację 3D.

![Prostokąty 3D obok siebie: tekst podąża za orientacją 3D po lewej i pozostaje płaski po prawej](keep_text_flat.png)

## **Zachowanie przy eksporcie i renderowaniu**

Aspose.Slides zachowuje formatowanie 3D przy zapisywaniu do formatów PowerPoint, takich jak PPTX. Podczas renderowania lub eksportu do formatów o stałym układzie, scena 3D jest rasteryzowana lub rysowana w wyjściu jako wynik 2D. Dotyczy to renderowania slajdów do [PNG](/slides/pl/nodejs-java/convert-powerpoint-to-png/), eksportu do [PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/), eksportu do [HTML](/slides/pl/nodejs-java/convert-powerpoint-to-html/), lub generowania klatek do [konwersję wideo](/slides/pl/nodejs-java/convert-powerpoint-to-video/).

- Eksportowane obrazy i pliki PDF nie są interaktywne. Obiekt nie może być obracany przez użytkownika po eksporcie.
- Końcowy wygląd zależy od połączenia kamery, zestawu świateł, materiału, ekstruzji, wypełnienia i skalowania slajdu.
- Jeśli potrzebujesz sprawdzić dziedziczone lub oparte na temacie wartości formatowania, odczytaj [efektywne właściwości kształtu](/slides/pl/nodejs-java/shape-effective-properties/).
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D PowerPoint. W tych formatach wynik wizualny jest renderowany, a nie zachowywany jako edytowalne ustawienia 3D.

## **FAQ**

**Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?**  
Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie tworzy interaktywnych scen 3D w wyeksportowanych obrazach, PDF‑ach ani stronach HTML, które użytkownik mógłby obracać. W PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, o ile format to obsługuje.

**Jaka jest różnica między modelem 3D a efektem 3D?**  
Model 3D to oddzielny obiekt 3D wstawiany do prezentacji. Efekt 3D to formatowanie zastosowane do zwykłego kształtu lub tekstu PowerPoint, takie jak rotacja, ekstruzja, fazowanie, oświetlenie i materiał. Ten artykuł dotyczy efektów 3D.

**Jakie ustawienia są wymagane dla widocznego kształtu 3D?**  
Minimum to ustawienie rotacji kamery oraz ekstruzji lub głębii. W praktyce warto także ustawić zestaw świateł i materiał, aby renderowane powierzchnie miały wyraźne podświetlenia i cienie.

**Czy mogę stosować efekty 3D zarówno do kształtów, jak i tekstu?**  
Tak. Użyj [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) dla ciała kształtu oraz [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) dla tekstu.

**Czy efekty 3D pojawią się przy eksporcie do obrazów, PDF, HTML lub klatek wideo?**  
Tak. Aspose.Slides renderuje efekty 3D przy tworzeniu obrazów slajdów, wyjścia PDF, wyjścia HTML oraz klatek używanych do konwersji wideo. Wyeksportowany wynik zawiera renderowany wygląd, a nie edytowalny obiekt 3D.

**Czy mogę odczytać ostateczne wartości 3D po zastosowaniu dziedziczenia i ustawień tematu?**  
Tak. Użyj API efektywnego formatowania opisanych w [efektywne właściwości kształtu](/slides/pl/nodejs-java/shape-effective-properties/), aby odczytać ostateczne wartości kamery, zestawu świateł, fazowania i powiązane parametry 3D.