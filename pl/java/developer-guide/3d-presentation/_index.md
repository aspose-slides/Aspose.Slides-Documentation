---
title: Tworzenie efektów 3D w prezentacjach przy użyciu Java
linktitle: Prezentacja 3D
type: docs
weight: 232
url: /pl/java/3d-presentation/
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
- Java
- Aspose.Slides
description: "Zastosuj i renderuj efekty 3D dla kształtów i tekstu PowerPoint w Javie przy użyciu Aspose.Slides. Konfiguruj kamerę, oświetlenie, materiał, ekstruzję, wypełnienia i tekst 3D."
---
## **Przegląd**

Aspose.Slides for Java może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPoint dla kształtów i tekstu. Ten artykuł opisuje efekty 3D, takie jak obrót, ekstruzja, fazowanie, oświetlenie, materiał, wypełnienia gradientowe lub obrazkowe oraz tekst 3D.

{{% alert color="info" title="Uwaga" %}}
Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w PowerPoint. Nie jest to temat wstawiania lub edycji samodzielnych plików modeli 3D. Gdy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D w wyjściowym 2D.
{{% /alert %}}

## **Koncepcje formatowania 3D**

Użyj metody [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) aby zastosować formatowanie 3D do kształtu. Metoda zwraca obiekt [IThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/), który kontroluje scenę 3D dla tego kształtu.

Dla tekstu użyj metody [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) . To stosuje formatowanie 3D do ramki tekstowej, a nie do ciała kształtu.

Najważniejsze członki API to:

| Członek API | Co kontroluje | Kiedy używać |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) | Punkt widzenia, typ kamery wstępnie ustawiony, obrót, przybliżenie i perspektywa. | Obróć obiekt w przestrzeni 3D lub dopasuj do wstępnego ustawienia obrotu 3D w PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getLightRig--) | Wstępne ustawienie światła, kierunek i obrót światła. | Zmieniaj sposób, w jaki podświetlenia i cienie pojawiają się na powierzchni 3D. |
| [getMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getMaterial--) i [setMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Materiał powierzchni, np. płaski, matowy, plastikowy lub metaliczny. | Spraw, by ta sama geometria wyglądała na płaską, miękką, błyszczącą lub metaliczną. |
| [getExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) i [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Jak daleko kształt rozciąga się wstecz od swojej przedniej powierzchni. | Zamień płaski kształt w widocznie gruby obiekt 3D. |
| [getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Kolor wyciągniętych boków. | Uwidocznij głębię lub dopasuj kolor boków do przedniego wypełnienia. |
| [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getDepth--) i [setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Dodatkowa głębokość 3D używana przez formatowanie 3D w PowerPoint. | Dostosuj głębokość kształtów lub tekstu, zwłaszcza razem z ustawieniami fazowania i materiału. |
| [getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) i [getBevelBottom](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Wzniesione lub zaokrąglone krawędzie na przedniej i tylnej powierzchni. | Dodaj zmiękczony lub formowany brzeg zamiast ostrej płaskiej ściany. |
| [getContourColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourColor--) oraz [getContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourWidth--) i [setContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Kontur wokół obiektu 3D. | Podkreśl granicę obiektu w renderowanym wyjściu. |

## **Utworzenie kształtu 3D**

Kształt zazwyczaj wymaga czterech rodzajów ustawień, aby wyglądał przekonująco 3D:

- Ustawienia kamery, ponieważ domyślny widok z przodu może ukrywać ekstruzję.
- Ustawienia światła, ponieważ oświetlenie sprawia, że powierzchnie i boki są czytelne.
- Ustawienia materiału, ponieważ powierzchnia wpływa na sposób renderowania światła.
- Ustawienia ekstruzji lub głębokości, ponieważ płaski kształt potrzebuje grubości.

Poniższy przykład tworzy prostokąt, dodaje tekst na jego przedniej powierzchni i stosuje formatowanie 3D. Wartości obrotu kamery podane są w stopniach, a wysokość ekstruzji wynosi 100 punktów. Przykład renderuje slajd do obrazu PNG w dwukrotności domyślnych wymiarów i zapisuje prezentację jako PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Renderowany obraz slajdu pokazuje prostokąt jako gruby blok 3D:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Obrócenie kształtu za pomocą kamery**

W PowerPoint obrót 3D konfiguruje się w panelu 3‑D Rotation. Wartości obrotu X, Y i Z odpowiadają obrotom ustawionym przez API kamery.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

W Aspose.Slides dostęp do kamery uzyskuje się przez [IThreeDFormat.getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--). Ten przykład tworzy prostokąt, wybiera ortograficzny widok z przodu i ustawia obroty X, Y i Z na 20, 30 i 40 stopni. Konfiguruje kształt w pamięci bez zapisywania pliku:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Używaj kamery, gdy musisz zmienić sposób, w jaki obserwator widzi obiekt. Nie zmienia to geometrii 2D kształtu na slajdzie. Zmienia to punkt widzenia 3D używany przez PowerPoint i przez Aspose.Slides przy renderowaniu.

### **Skopiowanie orientacji kamery z kształtu szablonu**

Aby dopasować orientację do kształtu szablonu, odczytaj jego wstępnie ustawiony typ kamery metodą [getCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getCameraType--) oraz kąty obrotu metodą [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getRotation--). Przykład otwiera `template.pptx` i kopiuje orientację kamery z pierwszego kształtu na pierwszym slajdzie do drugiego kształtu. Oba kształty mają już oświetlenie 3D, a drugi kształt nie ma jawnego obrotu kamery.

Kąty podawane są w stopniach. Indeks `0` to szerokość geograficzna, indeks `1` to długość geograficzna, a indeks `2` to obrot. Przekaż je do [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) w tej kolejności. Jeśli źródło zwróci `null`, nie ma jawnego obrotu, więc pozostaw kąty drugiego kształtu nieustawione. Jawny obrót `(0, 0, 0)` zwraca trzy zera i powinien zostać skopiowany.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Po ponownym otwarciu `camera-copy.pptx` w PowerPoint strzałka po prawej ma ten sam wstępny typ kamery i obrót co prostokąt po lewej. Oba kształty używają tego samego oświetlenia i głębokości ekstruzji.

![A blue 3D rectangle and a right arrow with matching camera orientation, viewed from above and to the right](camera-orientation.png)

## **Dodanie ekstruzji i głębokości**

Ekstruzja sprawia, że kształt wydaje się gruby, wydłużając go za przednią powierzchnię. W PowerPoint kontrolka głębokości ustawia tę widoczną grubość, a kontrolka koloru ustawia kolor boków.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Użyj [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) aby ustawić grubość i [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) aby odczytać kolor boków. Ten przykład daje prostokątowi ekstruzję 100 punktów z fioletowymi bokami i obraca kamerę, aby ukazać jego grubość. Konfiguruje kształt w pamięci bez zapisywania pliku:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Metoda [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) ustawia głębokość kształtu 3D. Metoda [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) kontroluje wysokość efektu ekstruzji, jak pokazano w tym przykładzie.

## **Użycie wypełnie gradientowych lub obrazkowych z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Możesz zastosować jednorodny kolor, gradient, wzór lub wypełnienie obrazem na przedniej powierzchni i nadal korzystać z tych samych ustawień kamery, światła, materiału i ekstruzji.

Ten przykład nakłada gradient od niebieskiego do pomarańczowego na przednią powierzchnię oraz ciemnopomarańczowy kolor na ekstruzję o wysokości 150 punktów. Przerwy gradientu w 0 i 100 oznaczają początek i koniec gradientu. Wartości obrotu kamery podane są w stopniach. Slajd renderowany jest do obrazu PNG w dwukrotności domyślnych wymiarów:

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

Renderowany wynik zachowuje gradient na przedniej powierzchni i oddzielnie renderuje ekstruzję:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Aby użyć wypełnienia obrazem, dodaj obraz do prezentacji i przypisz go jako wypełnienie kształtu. Ten przykład wymaga istniejącego pliku o nazwie „image.jpg” w katalogu roboczym. Rozciąga obraz, aby wypełnić prostokąt, stosuje ekstruzję 150 punktów i ustawia obrót kamery w stopniach. Konfiguruje kształt w pamięci bez zapisywania ani renderowania pliku:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    Path imagePath = Paths.get("image.jpg");
    byte[] imageData = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Obraz renderowany jest na przedniej powierzchni, a ekstruzja jako trójwymiarowa powierzchnia boczna:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Zastosowanie formatowania 3D do tekstu**

Formatowanie 3D kształtu wpływa na ciało kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne przy efektach podobnych do WordArt, gdzie same litery wymagają ekstruzji, materiału, oświetlenia i ustawień kamery.

Poniższy przykład tworzy tekst z pomarańczowo‑białym wzorem kratki, nakłada łukowaty łuk i konfiguruje ustawienia 3D przez [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). Wysokość ekstruzji i głębokość podane są w punktach, a obrót światła w stopniach. Wypełnienie i obrys kształtu ukryte, aby widoczny był tylko tekst. Przykład renderuje obraz PNG w dwukrotności domyślnych wymiarów slajdu i zapisuje prezentację jako PPTX:

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color patternColor = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tekst renderowany jest jako zakrzywione, ekstruzowane litery 3D:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Utrzymanie płaskości tekstu na kształcie 3D**

Aby tekst pozostał czytelny przy zachowaniu wyglądu 3D kształtu, wywołaj [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) przez [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getTextFrameFormat--). Gdy wartość jest `true`, tekst pozostaje poza sceną 3D. Gdy jest `false`, tekst uczestniczy w scenie i podąża za jej orientacją 3D.

To ustawienie nie usuwa formatowania 3D kształtu: jego kamery, oświetlenia, materiału i ekstruzji pozostają skonfigurowane przez [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--). Jest to także różne od zwykłego obrotu. [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) obraca kształt w płaszczyźnie slajdu, natomiast [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) steruje niestandardowym obrotem tekstu w jego ramce. Utrzymanie tekstu poza sceną 3D nie resetuje żadnego z tych kątów.

Poniższy, samodzielny przykład tworzy niebieski prostokąt z tekstem i klonuje go obok oryginału. Oba kształty mają takie samo formatowanie 3D; jedynie ustawienie tekstu się różni: `false` po lewej i `true` po prawej. Kąty kamery podane są w stopniach, a wysokość ekstruzji wynosi 40 punktów. Przykład zapisuje prezentację jako PPTX i renderuje slajd porównawczy do PNG w dwukrotności domyślnych wymiarów.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Po lewej tekst podąża za orientacją 3D. Po prawej pozostaje płaski i łatwiejszy do odczytania. Oba prostokąty zachowują tę samą widoczną ekstruzję i orientację 3D.

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **Zachowanie przy eksporcie i renderowaniu**

Aspose.Slides zachowuje formatowanie 3D przy zapisie do formatów PowerPoint, takich jak PPTX. Przy renderowaniu lub eksporcie do formatów o stałym układzie scena 3D jest rasteryzowana lub rysowana w wyjściu jako wynik 2D. Dotyczy to renderowania slajdów do [PNG](/slides/pl/java/convert-powerpoint-to-png/), eksportu do [PDF](/slides/pl/java/convert-powerpoint-to-pdf/), eksportu do [HTML](/slides/pl/java/convert-powerpoint-to-html/) lub generowania klatek dla [konwersji wideo](/slides/pl/java/convert-powerpoint-to-video/).

Pamiętaj o następujących kwestiach:

- Wyeksportowane obrazy i pliki PDF nie są interaktywne. Obiekt nie może być obracany przez odbiorcę po eksporcie.
- Ostateczny wygląd zależy od kombinacji kamery, oświetlenia, materiału, ekstruzji, wypełnienia i skalowania slajdu.
- Jeśli potrzebujesz sprawdzić wartości formatowania odziedziczone lub oparte na motywie, odczytaj [effective shape properties](/slides/pl/java/shape-effective-properties/).
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D PowerPoint. W tych formatach wynik wizualny jest renderowany, a nie zachowywany jako edytowalne ustawienia 3D.

## **FAQ**

**Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?**

Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie sprawia, że wyeksportowane obrazy, PDF‑y ani strony HTML są interaktywnymi scenami 3D, które odbiorca może obracać. W PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, o ile format to umożliwia.

**Jaka jest różnica między modelem 3D a efektem 3D?**

Model 3D to odrębny obiekt 3D wstawiony do prezentacji. Efekt 3D to formatowanie zastosowane do zwykłego kształtu lub tekstu PowerPoint, takie jak obrót, ekstruzja, fazowanie, oświetlenie i materiał. Ten artykuł opisuje efekty 3D.

**Jakie ustawienia są wymagane, aby 3D był widoczny?**

Co najmniej ustaw obrót kamery oraz ekstruzję lub głębokość. W praktyce warto także ustawić oświetlenie i materiał, aby renderowane powierzchnie miały wyraźne podświetlenia i cienie.

**Czy mogę zastosować efekty 3D zarówno do kształtów, jak i do tekstu?**

Tak. Użyj [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) dla ciała kształtu oraz [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) dla tekstu.

**Czy efekty 3D pojawią się przy eksporcie do obrazów, PDF, HTML lub klatek wideo?**

Tak. Aspose.Slides renderuje efekty 3D przy tworzeniu obrazów slajdów, wyjścia PDF, HTML oraz klatek używanych do konwersji wideo. Wyjściowy plik zawiera wyrenderowany wygląd, a nie edytowalny obiekt 3D.

**Czy mogę odczytać ostateczne wartości 3D po zastosowaniu dziedziczenia i ustawień motywu?**

Tak. Skorzystaj z API formatowania efektywnego opisanych w [Shape Effective Properties](/slides/pl/java/shape-effective-properties/), aby odczytać finalne wartości kamery, oświetlenia, fazowania i powiązane parametry 3D.