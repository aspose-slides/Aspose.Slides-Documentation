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
description: "Zastosuj i renderuj efekty 3D dla kształtów i tekstu PowerPoint w Javie przy użyciu Aspose.Slides. Konfiguruj kamerę, oświetlenie, materiał, ekstruzję, wypełnienia i tekst 3D."
---
## **Przegląd**

Aspose.Slides for Java może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPoint dla kształtów i tekstu. Ten artykuł omawia efekty 3D takie jak obrót, ekstruzja, fazowanie, oświetlenie, materiał, wypełnienia gradientowe lub obrazkowe oraz tekst 3D.

{{% alert color="info" title="Note" %}}
Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w PowerPoint. Nie chodzi o wstawianie lub edytowanie samodzielnych plików modeli 3D. Gdy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D w wyjściowym 2D.
{{% /alert %}}

## **Koncepcje formatowania 3D**

Użyj metody [IShape.getThreeDFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getThreeDFormat--) aby zastosować formatowanie 3D do kształtu. Metoda zwraca [IThreeDFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/), który steruje sceną 3D dla tego kształtu.

Dla tekstu użyj metody [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). Stosuje ona formatowanie 3D do ramki tekstowej zamiast do ciała kształtu.

Najważniejsze elementy API to:

| Element API | Co kontroluje | Kiedy używać |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getCamera--) | Punkt widzenia, preset typu kamery, obrót, przybliżenie i perspektywa. | Obróć obiekt w przestrzeni 3D lub dopasuj preset obrotu 3D w PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getLightRig--) | Preset światła, kierunek i obrót światła. | Zmieniaj sposób, w jaki podświetlenia i cienie pojawiają się na powierzchni 3D. |
| [getMaterial](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getMaterial--) i [setMaterial](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Materiał powierzchni, np. płaski, matowy, plastikowy lub metalowy. | Spraw, aby ta sama geometria wyglądała płasko, miękko, błyszcząco lub metalicznie. |
| [getExtrusionHeight](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) i [setExtrusionHeight](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Jak daleko kształt rozciąga się w tył od swojej przedniej powierzchni. | Przekształć płaski kształt w widocznie grubą obiekt 3D. |
| [getExtrusionColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Kolor wyextrudowanych boków. | Umożliw widoczność głębokości lub skoordynuj kolor boków z wypełnieniem frontu. |
| [getDepth](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getDepth--) i [setDepth](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Dodatkowa głębokość 3D używana w formatowaniu 3D PowerPoint. | Dopracuj głębokość dla kształtów lub tekstu, szczególnie w połączeniu z ustawieniami fazowania i materiału. |
| [getBevelTop](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getBevelTop--) i [getBevelBottom](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Wypukłe lub zaokrąglone krawędzie na przedniej i tylnej powierzchni. | Dodaj zmiękczoną lub formowaną krawędź zamiast ostrej płaskiej powierzchni. |
| [getContourColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getContourColor--) i [getContourWidth](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getContourWidth--) i [setContourWidth](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Kontur wokół obiektu 3D. | Podkreśl granicę obiektu w renderowanym wyniku. |

## **Utwórz kształt 3D**

Kształt zazwyczaj potrzebuje czterech rodzajów ustawień, zanim będzie wyglądał wiarygodnie 3D:

- Ustawienia kamery, ponieważ domyślny widok z przodu może ukrywać ekstruzję.  
- Ustawienia światła, ponieważ oświetlenie sprawia, że powierzchnie i boki są widoczne.  
- Ustawienia materiału, ponieważ powierzchnia wpływa na sposób renderowania światła.  
- Ustawienia ekstruzji lub głębokości, ponieważ płaski kształt potrzebuje grubości.  

Przykład poniżej tworzy prostokąt, dodaje tekst do jego przedniej powierzchni i stosuje formatowanie 3D. Wartości obrotu kamery podane są w stopniach, a wysokość ekstruzji to 100 punktów. Przykład renderuje slajd do obrazu PNG w dwukrotnie większych niż domyślne wymiarach i zapisuje prezentację jako PPTX.

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

![Renderowany niebieski prostokąt 3D z białym tekstem 3D na przedniej powierzchni](img_01_01.png)

## **Obróć kształt przy użyciu kamery**

W programie PowerPoint obrót 3D konfiguruje się w panelu Obrót 3D. Wartości obrotu X, Y i Z odpowiadają obrotowi ustawionemu przy użyciu API kamery.

![Panel Obrót 3D w PowerPoint z podświetlonymi wartościami obrotu X, Y i Z](img_02_01.png)

W Aspose.Slides dostęp do kamery uzyskuje się przez [IThreeDFormat.getCamera](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getCamera--). Ten przykład tworzy prostokąt, wybiera ortograficzny widok z przodu i ustawia jego rotacje X, Y i Z na 20, 30 i 40 stopni odpowiednio. Konfiguruje kształt w pamięci bez zapisywania pliku:

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

Używaj kamery, gdy potrzebujesz zmienić sposób, w jaki obserwator widzi obiekt. Nie zmienia to geometrii 2D kształtu na slajdzie. Zmienia to punkt widzenia 3D używany przez PowerPoint i przez Aspose.Slides podczas renderowania.

## **Dodaj ekstruzję i głębokość**

Ekstruzja sprawia, że kształt wygląda na gruby, wydłużając go za przednią powierzchnię. W PowerPoint kontrola głębokości ustawia tę widoczną grubość, a kontrola koloru ustawia kolor boków.

![Kontrolki głębokości w PowerPoint mapowane na właściwości koloru ekstruzji i wysokości ekstruzji](img_02_02.png)

Użyj [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) aby ustawić grubość oraz [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) aby uzyskać dostęp do koloru boków. Ten przykład nadaje prostokątowi ekstruzję 100 punktów z fioletowymi bokami i obraca kamerę, aby ukazać jego grubość. Konfiguruje kształt w pamięci bez zapisywania pliku:

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

Metoda [IThreeDFormat.setDepth](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#setDepth-double-) ustawia głębokość kształtu 3D. Metoda [setExtrusionHeight](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) kontroluje wysokość efektu ekstruzji, jak pokazano w tym przykładzie.

## **Użyj wypełnie gradientowych lub obrazkowych z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Można zastosować jednolity kolor, gradient, wzór lub wypełnienie obrazkiem na przedniej powierzchni i nadal używać tych samych ustawień kamery, światła, materiału i ekstruzji.

Ten przykład stosuje gradient od niebieskiego do pomarańczowego na przedniej powierzchni oraz ciemnopomarańczowy kolor dla ekstruzji 150 punktów. Punkty przystankowe gradientu przy 0 i 100 oznaczają początek i koniec gradientu. Wartości obrotu kamery podane są w stopniach. Slajd jest renderowany do obrazu PNG w dwukrotnie większych niż domyślne wymiarach:

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

Renderowany wynik zachowuje gradient na przedniej powierzchni i renderuje ekstruzję osobno:

![Renderowany prostokąt 3D z wypełnieniem gradientowym od niebieskiego do pomarańczowego i pomarańczową ekstruzją](img_02_03.png)

Aby zamiast tego użyć wypełnienia obrazkiem, dodaj obraz do prezentacji i przypisz go do wypełnienia kształtu. Ten przykład wymaga istniejącego pliku o nazwie "image.jpg" w katalogu roboczym. Rozciąga obraz, aby wypełnić prostokąt, stosuje ekstruzję 150 punktów i ustawia obrót kamery w stopniach. Konfiguruje kształt w pamięci bez zapisywania ani renderowania pliku:

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

Obraz jest renderowany na przedniej powierzchni, podczas gdy ekstruzja jest renderowana jako 3D powierzchnia boczna:

![Renderowany prostokąt 3D z wypełnieniem zdjęciem na przedniej powierzchni i pomarańczową ekstruzją](img_02_04.png)

## **Zastosuj formatowanie 3D do tekstu**

Formatowanie 3D kształtu wpływa na ciało kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne w przypadkach efektów podobnych do WordArt, gdzie same litery wymagają ekstruzji, materiału, oświetlenia i ustawień kamery.

Poniższy przykład tworzy tekst z pomarańczowo-białym wzorem kratki, stosuje wznoszący łuk i konfiguruje ustawienia 3D za pomocą [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). Wysokość ekstruzji i głębokość podane są w punktach, a obrót światła w stopniach. Wypełnienie i kontur kształtu są ukryte, tak aby widoczny był tylko tekst. Przykład renderuje obraz PNG w dwukrotnie większych wymiarach slajdu niż domyślne i zapisuje prezentację jako PPTX:

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

Tekst jest renderowany jako zakrzywione, wyextrudowane litery 3D:

![Renderowany tekst 3D z zakrzywioną transformacją WordArt, pomarańczowym wypełnieniem wzorem i ciemną ekstruzją](img_02_05.png)

## **Utrzymaj tekst płaski na kształcie 3D**

Aby tekst był czytelny przy zachowaniu wyglądu 3D kształtu, wywołaj [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) za pośrednictwem [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#getTextFrameFormat--). Gdy wartość to `true`, tekst pozostaje poza sceną 3D. Gdy jest `false`, tekst uczestniczy w scenie i podąża za jej orientacją 3D.

To ustawienie nie usuwa formatowania 3D kształtu: jego kamera, oświetlenie, materiał i ekstruzja pozostają skonfigurowane przez [IShape.getThreeDFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getThreeDFormat--). Jest to także inne niż zwykły obrót. [IShape.setRotation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#setRotation-float-) obraca kształt w płaszczyźnie slajdu, podczas gdy [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) kontroluje własny obrót tekstu w jego ramce. Utrzymanie tekstu poza sceną 3D nie resetuje żadnego z tych kątów.

Poniższy samodzielny przykład tworzy niebieski prostokąt z tekstem i klonuje go obok oryginału. Oba kształty mają to samo formatowanie 3D; różni je jedynie ustawienie tekstu: `false` po lewej i `true` po prawej. Kąty kamery podane są w stopniach, a wysokość ekstruzji wynosi 40 punktów. Przykład zapisuje prezentację jako PPTX i renderuje slajd porównawczy do PNG w dwukrotnie większych niż domyślne wymiarach.

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

![Prostokąty 3D obok siebie: tekst podąża za orientacją 3D po lewej i pozostaje płaski po prawej](keep_text_flat.png)

## **Zachowanie eksportu i renderowania**

Aspose.Slides zachowuje formatowanie 3D przy zapisywaniu w formatach PowerPoint, takich jak PPTX. Podczas renderowania lub eksportu do formatów o stałym układzie, scena 3D jest rastrowana lub rysowana w wyjściu jako wynik 2D. Dotyczy to renderowania slajdów do [PNG](/slides/pl/java/convert-powerpoint-to-png/), eksportu do [PDF](/slides/pl/java/convert-powerpoint-to-pdf/), eksportu do [HTML](/slides/pl/java/convert-powerpoint-to-html/), lub generowania klatek do [konwersji wideo](/slides/pl/java/convert-powerpoint-to-video/).

Pamiętaj o następujących kwestiach:

- Wyeksportowane obrazy i PDF-y nie są interaktywne. Obiekt nie może być obracany przez odbiorcę po eksporcie.  
- Ostateczny wygląd zależy od połączenia kamery, zestawu oświetlenia, materiału, ekstruzji, wypełnienia i skalowania slajdu.  
- Jeśli potrzebujesz sprawdzić odziedziczone lub oparte na motywie wartości formatowania, przeczytaj [efektywne właściwości kształtu](/slides/pl/java/shape-effective-properties/).  
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D PowerPoint. W tych formatach wynik wizualny jest renderowany, a nie zachowywany jako edytowalny obiekt 3D.

## **FAQ**

**Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?**

Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie przekształca wyeksportowanych obrazów, PDF‑ów ani stron HTML w interaktywne sceny 3D, które odbiorca mógłby obracać. W formacie PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, o ile format to umożliwia.

**Jaka jest różnica między modelem 3D a efektem 3D?**

Model 3D to oddzielny obiekt 3D wstawiany do prezentacji. Efekt 3D to formatowanie zastosowane do zwykłego kształtu lub tekstu w PowerPoint, takie jak obrót, ekstruzja, fazowanie, oświetlenie i materiał. Ten artykuł omawia efekty 3D.

**Jakie ustawienia są wymagane, aby kształt 3D był widoczny?**

Co najmniej należy ustawić obrót kamery oraz ekstruzję lub głębokość. W praktyce warto także ustawić zestaw oświetlenia i materiał, aby renderowane powierzchnie miały wyraźne podświetlenia i cienie.

**Czy mogę zastosować efekty 3D zarówno do kształtów, jak i tekstu?**

Tak. Użyj [IShape.getThreeDFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getThreeDFormat--) dla ciała kształtu oraz [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) dla tekstu.

**Czy efekty 3D pojawią się przy eksporcie do obrazów, PDF, HTML lub klatek wideo?**

Tak. Aspose.Slides renderuje efekty 3D przy generowaniu obrazów slajdów, wyjścia PDF, wyjścia HTML oraz klatek używanych do konwersji wideo. Wyeksportowany plik zawiera wyrenderowany wygląd, a nie edytowalny obiekt 3D.

**Czy mogę odczytać ostateczne wartości 3D po zastosowaniu dziedziczenia i ustawień motywu?**

Tak. Użyj API formatowania efektywnego opisanych w [efektywne właściwości kształtu](/slides/pl/java/shape-effective-properties/), aby odczytać ostateczne wartości kamery, zestawu oświetlenia, fazowania i powiązane wartości 3D.