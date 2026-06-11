---
title: Tworzenie efektów 3D w prezentacjach przy użyciu Javy
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
description: "Zastosuj i renderuj efekty 3D dla kształtów i tekstu PowerPoint w Javie za pomocą Aspose.Slides. Skonfiguruj kamerę, oświetlenie, materiał, ekstruzję, wypełnienia i tekst 3D."
---
## **Przegląd**

Aspose.Slides for Java może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPointu dla kształtów i tekstu. Ten artykuł opisuje efekty 3D takie jak obrót, ekstruzja, fazowanie, oświetlenie, materiał, wypełnienia gradientowe lub obrazkowe oraz tekst 3D.

{{% alert color="primary" %}}

Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w programie PowerPoint. Nie dotyczy wstawiania ani edytowania samodzielnych plików modeli 3D. Gdy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D w wyjściowym 2D.

{{% /alert %}}

## **Koncepcje formatowania 3D**

Użyj [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/).`getThreeDFormat()`, aby zastosować formatowanie 3D do kształtu. Zwrócony obiekt formatu kontroluje scenę 3D tego kształtu.

Dla tekstu użyj [ITextFrameFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`. To stosuje formatowanie 3D do ramki tekstowej zamiast do ciała kształtu.

Najważniejsze członki API:

| Członek API | Co kontroluje | Kiedy używać |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getCamera--) | Punkt widzenia, predefiniowany typ kamery, obrót, powiększenie i perspektywa. | Obróć obiekt w przestrzeni 3D lub dopasuj do predefiniowanego obrotu 3D w PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getLightRig--) | Predefinicja światła, kierunek i obrót światła. | Zmień sposób, w jaki podświetlenia i cienie pojawiają się na powierzchni 3D. |
| [getMaterial](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getMaterial--) i [setMaterial](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Materiał powierzchni, np. płaski, matowy, plastikowy lub metalowy. | Spraw, by ta sama geometria wyglądała bardziej płasko, miękko, błyszcząco lub metalicznie. |
| [getExtrusionHeight](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) i [setExtrusionHeight](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Jak daleko kształt jest wydłużany wstecz od swojej przedniej ściany. | Przekształć płaski kształt w widocznie gruby obiekt 3D. |
| [getExtrusionColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Kolor wyciągniętych boków. | Uwydatnij głębokość lub skoordynuj kolor boków z wypełnieniem przedniej powierzchni. |
| [getDepth](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getDepth--) i [setDepth](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Dodatkowa głębokość 3D używana przez formatowanie 3D w PowerPoint. | Doprecyzuj głębokość dla kształtów lub tekstu, szczególnie wraz z ustawieniami fazowania i materiału. |
| [getBevelTop](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getBevelTop--) i [getBevelBottom](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Podniesione lub zaokrąglone krawędzie na przedniej i tylnej powierzchni. | Dodaj zmiękczoną lub formowaną krawędź zamiast ostrej płaskiej powierzchni. |
| [getContourColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getContourWidth--), i [setContourWidth](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Obrys wokół obiektu 3D. | Podkreśl granicę obiektu w renderowanym wyniku. |

## **Utwórz kształt 3D**

Kształt zazwyczaj wymaga czterech rodzajów ustawień, zanim będzie wyglądał przekonująco 3D:

- Ustawienia kamery, ponieważ domyślny widok z przodu może ukrywać ekstruzję.
- Ustawienia światła, ponieważ oświetlenie sprawia, że powierzchnie i boki są czytelne.
- Ustawienia materiału, ponieważ powierzchnia wpływa na sposób renderowania światła.
- Ustawienia ekstruzji lub głębokości, ponieważ płaski kształt potrzebuje grubości.

Poniższy przykład tworzy prostokąt, dodaje tekst do jego przedniej powierzchni, stosuje formatowanie 3D, zapisuje prezentację jako PPTX i renderuje slajd do obrazu PNG.

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

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

![Renderowany niebieski prostokąt 3D z białym tekstem 3D na przedniej powierzchni](img_01_01.png)

## **Obróć kształt przy użyciu kamery**

W programie PowerPoint obrót 3D jest konfigurowany w panelu Obrót 3D. Wartości obrotu X, Y i Z odpowiadają obrotowi ustawionemu za pomocą API kamery.

![Panel Obrót 3D w programie PowerPoint z podświetlonymi wartościami obrotu X, Y i Z](img_02_01.png)

W Aspose.Slides ustaw typ kamery i obrót za pomocą formatu 3D zwróconego przez `shape.getThreeDFormat()`:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Użyj kamery, gdy potrzebujesz zmienić sposób, w jaki obserwator widzi obiekt. Nie zmienia ona geometrii kształtu 2D na slajdzie. Zmienia punkt widzenia 3D używany przez PowerPoint i Aspose.Slides podczas renderowania.

## **Dodaj ekstruzję i głębokość**

Ekstruzja sprawia, że kształt wygląda na gruby, wydłużając go za przednią powierzchnią. W PowerPoint kontrolka głębokości ustawia tę widoczną grubość, a kontrolka koloru określa kolor bocznych powierzchni.

![Kontrolki głębokości w PowerPoint odpowiadają właściwościom koloru ekstruzji i wysokości ekstruzji](img_02_02.png)

Ustaw wysokość ekstruzji dla grubości i kolor ekstruzji dla koloru boków:

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Użyj ustawienia głębokości, gdy musisz pracować bezpośrednio z wartością głębokości w PowerPoint lub łączyć głębokość z fazowaniem, materiałem i efektami tekstu. W wielu scenariuszach kształtów wysokość ekstruzji jest czytelniejsza, ponieważ bezpośrednio wyraża widoczną ekstruzję.

## **Użyj wypełnień gradientowych lub obrazkowych z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Możesz zastosować jednolity kolor, gradient, wzór lub wypełnienie obrazkiem na przedniej powierzchni i nadal używać tych samych ustawień kamery, światła, materiału i ekstruzji.

Ten przykład stosuje wypełnienie gradientowe do kształtu i ciemniejszy kolor ekstruzji na boki:

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

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

Renderowany wynik zachowuje gradient na przedniej powierzchni i renderuje ekstruzję osobno:

![Renderowany prostokąt 3D z wypełnieniem gradientowym od niebieskiego do pomarańczowego i pomarańczową ekstruzją](img_02_03.png)

Aby zamiast tego użyć wypełnienia obrazkiem, dodaj obraz do prezentacji i przypisz go jako wypełnienie kształtu:

```java
java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

Color extrusionColor = new Color(255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Obraz jest renderowany na przedniej powierzchni, podczas gdy ekstruzja jest renderowana jako 3D powierzchnia boczna:

![Renderowany prostokąt 3D z wypełnieniem zdjęciem na przedniej powierzchni i pomarańczową ekstruzją](img_02_04.png)

## **Zastosuj formatowanie 3D do tekstu**

Formatowanie 3D kształtu wpływa na ciało kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne przy efektach podobnych do WordArt, gdzie same litery potrzebują ekstruzji, materiału, oświetlenia i ustawień kamery.

Poniższy przykład tworzy tekst z wypełnieniem wzorem, stosuje transformację WordArt i konfiguruje ustawienia 3D na [ITextFrameFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`:

```java
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

Renderowany tekst 3D z wygiętą transformacją WordArt, pomarańczowym wypełnieniem wzorem i ciemną ekstruzją:

![Renderowany tekst 3D z wygiętą transformacją WordArt, pomarańczowym wypełnieniem wzorem i ciemną ekstruzją](img_02_05.png)

## **Zachowanie eksportu i renderowania**

Aspose.Slides zachowuje formatowanie 3D przy zapisywaniu do formatów PowerPoint, takich jak PPTX. Podczas renderowania lub eksportu do formatów o stałym układzie scenę 3D rasteryzuje się lub rysuje w wyjściu jako wynik 2D. Dotyczy to renderowania slajdów do [PNG](/slides/pl/java/convert-powerpoint-to-png/), eksportu do [PDF](/slides/pl/java/convert-powerpoint-to-pdf/), eksportu do [HTML](/slides/pl/java/convert-powerpoint-to-html/) lub generowania klatek do [konwersji wideo](/slides/pl/java/convert-powerpoint-to-video/).

- Wyeksportowane obrazy i pliki PDF nie są interaktywne. Obiekt nie może być obracany przez widza po eksporcie.
- Ostateczny wygląd zależy od kombinacji kamery, zestawu świateł, materiału, ekstruzji, wypełnienia i skalowania slajdu.
- Jeśli potrzebujesz sprawdzić dziedziczone lub oparte na motywie wartości formatowania, przeczytaj [efektywne właściwości kształtu](/slides/pl/java/shape-effective-properties/).
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D PowerPoint. W tych formatach wynik wizualny jest renderowany, a nie zachowywany jako edytowalne ustawienia 3D.

## **FAQ**

**Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?**

Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie tworzy interaktywnych scen 3D w wyeksportowanych obrazach, plikach PDF ani stronach HTML, które widz mógłby obracać. W formacie PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, o ile format to obsługuje.

**Jaka jest różnica między modelem 3D a efektem 3D?**

Model 3D to oddzielny obiekt 3D wstawiany do prezentacji. Efekt 3D to formatowanie zastosowane do zwykłego kształtu lub tekstu w PowerPoint, takie jak obrót, ekstruzja, fazowanie, oświetlenie i materiał. Ten artykuł opisuje efekty 3D.

**Jakie ustawienia są wymagane, aby kształt 3D był widoczny?**

Co najmniej należy ustawić obrót kamery oraz ekstruzję lub głębokość. W praktyce warto także ustawić zestaw świateł i materiał, aby renderowane powierzchnie miały wyraźne podświetlenia i cienie.

**Czy mogę zastosować efekty 3D zarówno do kształtów, jak i tekstu?**

Tak. Użyj [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/).`getThreeDFormat()` dla ciała kształtu oraz [ITextFrameFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` dla tekstu.

**Czy efekty 3D pojawią się przy eksporcie do obrazów, PDF, HTML lub klatek wideo?**

Tak. Aspose.Slides renderuje efekty 3D podczas tworzenia obrazów slajdów, wyjścia PDF, wyjścia HTML oraz klatek używanych do konwersji wideo. Wyeksportowany wynik zawiera renderowany wygląd, a nie edytowalny obiekt 3D.

**Czy mogę odczytać ostateczne wartości 3D po zastosowaniu dziedziczenia i ustawień motywu?**

Tak. Użyj API formatowania efektywnego opisanych w [Właściwości efektywne kształtu](/slides/pl/java/shape-effective-properties/), aby odczytać ostateczne wartości kamery, zestawu świateł, fazowania i powiązane wartości 3D.