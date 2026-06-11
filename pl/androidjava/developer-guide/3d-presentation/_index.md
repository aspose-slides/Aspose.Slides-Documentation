---
title: Tworzenie efektów 3D w prezentacjach na Androidzie
linktitle: Prezentacja 3D
type: docs
weight: 232
url: /pl/androidjava/3d-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Zastosuj i renderuj efekty 3D dla kształtów i tekstu PowerPoint na Androidzie przy użyciu Aspose.Slides. Konfiguruj kamerę, oświetlenie, materiał, ekstruzję, wypełnienia i tekst 3D."
---
## **Przegląd**

Aspose.Slides for Android via Java może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPoint dla kształtów i tekstu. Ten artykuł opisuje efekty 3D takie jak obrót, ekstruzja, fazowanie, oświetlenie, materiały, wypełnienia gradientowe lub obrazkowe oraz tekst 3D.

{{% alert color="primary" %}}
Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w PowerPoint. Nie chodzi o wstawianie lub edytowanie samodzielnych plików modeli 3D. Kiedy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D w wyjściowym 2D.
{{% /alert %}}

## **Koncepcje formatowania 3D**

Użyj metody [IShape.getThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) aby zastosować formatowanie 3D do kształtu. Metoda zwraca [IThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/), który kontroluje scenę 3D dla tego kształtu.

Dla tekstu użyj metody [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . To stosuje formatowanie 3D do ramki tekstowej zamiast do korpusu kształtu.

Najważniejsze członki API to:

| Członek API | Co kontroluje | Kiedy używać |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Punkt widzenia, typ kamery wstępnie ustawiony, obrót, powiększenie i perspektywa. | Obrócić obiekt w przestrzeni 3D lub dopasować do wstępnie ustawionego obrotu 3D w PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Ustawienia światła, kierunek i obrót światła. | Zmienić sposób, w jaki podświetlenia i cienie pojawiają się na powierzchni 3D. |
| [getMaterial](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) i [setMaterial](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Materiał powierzchni, np. płaski, matowy, plastikowy lub metalowy. | Sprawić, by ta sama geometria wyglądała bardziej płasko, miękko, błyszcząco lub metalicznie. |
| [getExtrusionHeight](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) i [setExtrusionHeight](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Jak daleko kształt rozciąga się w tył od swojej przedniej powierzchni. | Przekształcić płaski kształt w widocznie grubą bryłę 3D. |
| [getExtrusionColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Kolor wypukłych boków. | Umożliwić widoczność głębokości lub skoordynować kolor boków z wypełnieniem przedniej części. |
| [getDepth](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#getDepth--) i [setDepth](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Dodatkowa głębokość 3D używana w formatowaniu 3D PowerPointa. | Dostroić głębokość dla kształtów lub tekstu, szczególnie w połączeniu z ustawieniami fazowania i materiału. |
| [getBevelTop](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) i [getBevelBottom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Podniesione lub zaokrąglone krawędzie na przedniej i tylnej powierzchni. | Dodać zmiękczony lub formowany brzeg zamiast ostrej płaskiej powierzchni. |
| [getContourColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), i [setContourWidth](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Obrys wokół obiektu 3D. | Podkreślić granicę obiektu w renderowanym wyniku. |

## **Utworzenie kształtu 3D**

Kształt zazwyczaj wymaga czterech rodzajów ustawień, aby wyglądał przekonująco 3D:

- Ustawienia kamery, ponieważ domyślny widok z przodu może ukrywać ekstruzję.
- Ustawienia oświetlenia, ponieważ światło sprawia, że powierzchnie i boki są czytelne.
- Ustawienia materiału, ponieważ powierzchnia wpływa na sposób renderowania światła.
- Ustawienia ekstruzji lub głębokości, ponieważ płaski kształt potrzebuje grubości.

Poniższy przykład tworzy prostokąt, dodaje tekst do jego przedniej powierzchni, stosuje formatowanie 3D, zapisuje prezentację jako PPTX i renderuje slajd jako obraz PNG.

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

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

Renderowany obraz slajdu pokazuje prostokąt jako grubą bryłę 3D:

![Renderowany niebieski prostokąt 3D z białym tekstem 3D na przedniej powierzchni](img_01_01.png)

## **Obrót kształtu przy użyciu kamery**

W PowerPoint obrót 3D konfiguruje się w panelu **3‑D Rotation**. Wartości obrotu X, Y i Z odpowiadają obrotowi ustawionemu przez API kamery.

![Panel rotacji 3D w PowerPoint z podświetlonymi wartościami obrotu X, Y i Z](img_02_01.png)

W Aspose.Slides ustaw typ kamery i obrót za pomocą [IThreeDFormat.getCamera](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Używaj kamery, gdy potrzebujesz zmienić sposób, w jaki obserwator widzi obiekt. Nie zmienia to geometrycznej postaci 2D kształtu na slajdzie. Zmienia punkt widzenia 3D używany przez PowerPoint i przez Aspose.Slides przy renderowaniu.

## **Dodanie ekstruzji i głębokości**

Ekstruzja sprawia, że kształt wygląda na gruby, wydłużając go za przednią powierzchnię. W PowerPoint kontrolka głębokości ustawia tę widoczną grubość, a kontrolka koloru określa kolor bocznych powierzchni.

![Kontrolki głębokości w PowerPoint powiązane z właściwościami koloru ekstruzji i wysokości ekstruzji](img_02_02.png)

Ustaw [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) dla grubości i [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) dla koloru boków:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

Użyj [IThreeDFormat.setDepth](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) gdy potrzebujesz pracować bezpośrednio z wartością głębokości PowerPointa lub łączyć głębokość z fazowaniem, materiałem i efektami tekstu. W wielu scenariuszach kształtu `setExtrusionHeight` jest bardziej przejrzystym ustawieniem, ponieważ bezpośrednio opisuje widoczną ekstruzję.

## **Użycie wypełnień gradientowych lub obrazkowych z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Możesz zastosować jednolity kolor, gradient, wzór lub wypełnienie obrazkiem na przednią powierzchnię i nadal używać tych samych ustawień kamery, światła, materiału i ekstruzji.

Ten przykład stosuje wypełnienie gradientowe do kształtu i ciemniejszy kolor ekstruzji po bokach:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

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

![Renderowany prostokąt 3D z wypełnieniem gradientowym od niebieskiego do pomarańczowego oraz pomarańczową ekstruzją](img_02_03.png)

Aby użyć wypełnienia obrazkiem, dodaj obraz do prezentacji i przypisz go jako wypełnienie kształtu:

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

![Renderowany prostokąt 3D z wypełnieniem zdjęciem na przedniej powierzchni i pomarańczową ekstruzją](img_02_04.png)

## **Zastosowanie formatowania 3D do tekstu**

Formatowanie 3D kształtu wpływa na korpus kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne przy efektach podobnych do WordArt, gdzie same litery wymagają ekstruzji, materiału, oświetlenia i ustawień kamery.

Poniższy przykład tworzy tekst z wypełnieniem wzorem, stosuje przekształcenie WordArt i konfiguruje ustawienia 3D na [ITextFrameFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframeformat/):

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
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

![Renderowany tekst 3D z wygiętym przekształceniem WordArt, pomarańczowym wypełnieniem wzorem i ciemną ekstruzją](img_02_05.png)

## **Zachowanie eksportu i renderowania**

Aspose.Slides zachowuje formatowanie 3D przy zapisie do formatów PowerPoint, takich jak PPTX. Przy renderowaniu lub eksporcie do formatów o stałym układzie scena 3D jest rasteryzowana lub rysowana do wyjścia jako wynik 2D. Dotyczy to renderowania slajdów do [PNG](/slides/pl/androidjava/convert-powerpoint-to-png/), eksportu do [PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/), eksportu do [HTML](/slides/pl/androidjava/convert-powerpoint-to-html/), lub generowania klatek dla [konwersji wideo](/slides/pl/androidjava/convert-powerpoint-to-video/).

Pamiętaj o następujących kwestiach:

- Wyeksportowane obrazy i pliki PDF nie są interaktywne. Obiekt nie może być obracany przez odbiorcę po eksporcie.
- Ostateczny wygląd zależy od kombinacji kamery, zestawu świateł, materiału, ekstruzji, wypełnienia i skalowania slajdu.
- Jeśli potrzebujesz sprawdzić wartości formatowania odziedziczone lub oparte na motywie, przeczytaj [effective shape properties](/slides/pl/androidjava/shape-effective-properties/).
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D PowerPoint. W tych formatach efekt wizualny jest renderowany, a nie zachowywany jako edytowalne ustawienia 3D.

## **FAQ**

**Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?**

Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie tworzy interaktywnych scen 3D w wyeksportowanych obrazach, PDF‑ach ani stronach HTML, które użytkownik mógłby obracać. W PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, o ile format to umożliwia.

**Jaka jest różnica między modelem 3D a efektem 3D?**

Model 3D to odrębny obiekt 3D wstawiany do prezentacji. Efekt 3D to formatowanie zastosowane do zwykłego kształtu lub tekstu PowerPoint, takie jak obrót, ekstruzja, fazowanie, oświetlenie i materiał. Ten artykuł opisuje efekty 3D.

**Jakie ustawienia są wymagane, aby kształt 3D był widoczny?**

Minimalnie należy ustawić obrót kamery oraz ekstruzję lub głębokość. W praktyce warto także ustawić zestaw świateł i materiał, aby renderowane powierzchnie miały wyraźne podświetlenia i cienie.

**Czy mogę zastosować efekty 3D zarówno do kształtów, jak i do tekstu?**

Tak. Użyj [IShape.getThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) dla korpusu kształtu oraz [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) dla tekstu.

**Czy efekty 3D pojawią się przy eksporcie do obrazów, PDF, HTML lub klatek wideo?**

Tak. Aspose.Slides renderuje efekty 3D podczas generowania obrazów slajdów, wyjścia PDF, HTML oraz klatek używanych do konwersji wideo. Wyeksportowany wynik zawiera wyrenderowany wygląd, a nie edytowalny obiekt 3D.

**Czy mogę odczytać ostateczne wartości 3D po zastosowaniu dziedziczenia i ustawień motywu?**

Tak. Użyj API formatowania efektywnego opisanych w [Shape Effective Properties](/slides/pl/androidjava/shape-effective-properties/), aby odczytać ostateczne wartości kamery, zestawu świateł, fazowania i powiązane wartości 3D.