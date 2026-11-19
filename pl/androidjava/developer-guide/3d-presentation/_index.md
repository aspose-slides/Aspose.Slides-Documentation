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
description: "Zastosuj i renderuj efekty 3D dla kształtów i tekstu PowerPoint na Androidzie przy użyciu Aspose.Slides. Skonfiguruj kamerę, oświetlenie, materiał, ekstruzję, wypełnienia i tekst 3D."
---
## **Przegląd**

Aspose.Slides for Android via Java może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPoint dla kształtów i tekstu. Ten artykuł obejmuje efekty 3D, takie jak obrót, ekstruzja, fazety, oświetlenie, materiały, wypełnienia gradientowe lub obrazkowe oraz tekst 3D.

{{% alert color="info" title="Note" %}}
Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w PowerPoint. Nie dotyczy wstawiania ani edytowania samodzielnych plików modeli 3D. Kiedy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D w wyjściowym 2D.
{{% /alert %}}

## **Koncepcje formatowania 3D**

Użyj metody [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) aby zastosować formatowanie 3D do kształtu. Metoda zwraca [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/), które steruje sceną 3D dla tego kształtu.

Dla tekstu użyj metody [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Nakłada ona formatowanie 3D na ramkę tekstową zamiast na ciało kształtu.

Najważniejsze członkiny API to:

| Członek API | Co kontroluje | Kiedy używać |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Punkt widzenia, typ kamery wstępnie ustawiony, obrót, powiększenie i perspektywa. | Obróć obiekt w przestrzeni 3D lub dopasuj do wstępnie ustawionego obrotu 3D w PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Ustawienie światła, kierunek i obrót światła. | Zmień sposób, w jaki podświetlenia i cienie pojawiają się na powierzchni 3D. |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) i [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Materiał powierzchni, np. płaski, matowy, plastikowy lub metalowy. | Spraw, aby ta sama geometria wyglądała bardziej płasko, miękko, błyszcząco lub metalicznie. |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) i [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Jak daleko kształt wydłuża się w tył od swojej przedniej powierzchni. | Przekształć płaski kształt w widocznie gruby obiekt 3D. |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Kolor wyciągniętych boków. | Uczyń głębokość widoczną lub skoordynuj kolor boków z wypełnieniem przedniej powierzchni. |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) i [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Dodatkowa głębokość 3D używana w formatowaniu 3D w PowerPoint. | Dostosuj precyzyjnie głębokość kształtów lub tekstu, szczególnie wraz z ustawieniami fazetu i materiału. |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) i [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Podniesione lub zaokrąglone krawędzie na przedniej i tylnej powierzchni. | Dodaj zmiękczony lub formowany brzeg zamiast ostrej płaskiej powierzchni. |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) i [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) i [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Obrys wokół obiektu 3D. | Podkreśl granicę obiektu w renderowanym wyniku. |

## **Utwórz kształt 3D**

Kształt zazwyczaj potrzebuje czterech rodzajów ustawień, aby wyglądał przekonująco 3D:

- Ustawienia kamery, ponieważ domyślny widok z przodu może ukrywać ekstruzję.  
- Ustawienia oświetlenia, ponieważ światło sprawia, że powierzchnie i boki są widoczne.  
- Ustawienia materiału, ponieważ powierzchnia wpływa na to, jak światło jest renderowane.  
- Ustawienia ekstruzji lub głębokości, ponieważ płaski kształt potrzebuje grubości.  

Poniższy przykład tworzy prostokąt, dodaje tekst do jego przedniej powierzchni i stosuje formatowanie 3D. Wartości obrotu kamery są podane w stopniach, a wysokość ekstruzji wynosi 100 punktów. Przykład renderuje slajd do obrazu PNG w dwukrotnych domyślnych wymiarach i zapisuje prezentację jako PPTX.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Wyrenderowany niebieski prostokąt 3D z białym tekstem 3D na przedniej powierzchni](img_01_01.png)

## **Obróć kształt za pomocą kamery**

W programie PowerPoint obrót 3D jest konfigurowany w panelu Obrót 3D. Wartości obrotu X, Y i Z odpowiadają obrotowi ustawionemu za pośrednictwem API kamery.

![Panel Obrót 3D w PowerPoint z podświetlonymi wartościami obrotu X, Y i Z](img_02_01.png)

W Aspose.Slides dostęp do kamery uzyskuje się poprzez [IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--). Ten przykład tworzy prostokąt, wybiera ortograficzny widok z przodu i ustawia obroty X, Y i Z na odpowiednio 20, 30 i 40 stopni. Konfiguruje kształt w pamięci bez zapisywania pliku:

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

Użyj kamery, gdy musisz zmienić sposób, w jaki widz postrzega obiekt. Nie zmienia ona geometrii 2D kształtu na slajdzie. Zmienia punkt widzenia 3D używany przez PowerPoint i Aspose.Slides podczas renderowania.

### **Skopiuj orientację kamery z kształtu szablonu**

Aby dopasować orientację kształtu szablonu, odczytaj jego wstępnie ustawioną kamerę za pomocą [getCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getCameraType--) oraz kąty obrotu za pomocą [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getRotation--). Przykład otwiera `template.pptx` i kopiuje orientację kamery z pierwszego kształtu na pierwszym slajdzie do drugiego kształtu. Oba kształty już mają oświetlenie 3D, a drugi kształt nie ma wyraźnego obrotu kamery.

Kąty podawane są w stopniach. Indeks `0` to szerokość, indeks `1` to długość, a indeks `2` to obrót. Przekaż je do [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) w tej kolejności. Jeśli źródło zwraca `null`, nie ma wyraźnego obrotu, więc pozostaw kąty drugiego kształtu nieustawione. Wyraźny obrót `(0, 0, 0)` zwraca trzy zera i powinien być skopiowany.

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

Gdy ponownie otworzysz `camera-copy.pptx` w PowerPoint, strzałka po prawej ma taki sam wstępny ustawiony typ kamery i obrót jak prostokąt po lewej. Oba kształty używają tego samego oświetlenia i głębokości ekstruzji.

![Niebieski prostokąt 3D i strzałka skierowana w prawo z dopasowaną orientacją kamery, widziane z góry i z prawej strony](camera-orientation.png)

## **Dodaj ekstruzję i głębokość**

Ekstruzja sprawia, że kształt wygląda na gruby, wydłużając go za przednią powierzchnię. W PowerPoint kontrolka głębokości określa tę widoczną grubość, a kontrolka koloru ustawia kolor bocznych powierzchni.

![Kontrolki głębokości w PowerPoint odzwierciedlone w właściwościach koloru ekstruzji i wysokości ekstruzji](img_02_02.png)

Użyj [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) , aby ustawić grubość, oraz [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) , aby uzyskać dostęp do koloru boków. Ten przykład nadaje prostokątowi ekstruzję 100 punktów z fioletowymi bokami i obraca kamerę, aby ujawnić jego grubość. Konfiguruje kształt w pamięci bez zapisywania pliku:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

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

Metoda [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) ustawia głębokość kształtu 3D. Metoda [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) kontroluje wysokość efektu ekstruzji, jak pokazano w tym przykładzie.

## **Użyj wypełnień gradientowych lub obrazkowych z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Możesz zastosować jednolity kolor, gradient, wzór lub wypełnienie obrazkiem na przedniej powierzchni i nadal używać tych samych ustawień kamery, światła, materiału i ekstruzji.

Ten przykład stosuje gradient od niebieskiego do pomarańczowego na przedniej powierzchni oraz ciemnopomarańczowy kolor dla ekstruzji 150 punktów. Punkty zatrzymania gradientu przy 0 i 100 oznaczają początek i koniec gradientu. Wartości obrotu kamery podane są w stopniach. Slajd jest renderowany do obrazu PNG w dwukrotnych domyślnych wymiarach:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int extrusionColor = Color.rgb(255, 140, 0);
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

![Wyrenderowany prostokąt 3D z gradientowym wypełnieniem od niebieskiego do pomarańczowego i pomarańczową ekstruzją](img_02_03.png)

Aby zamiast tego użyć wypełnienia obrazkiem, dodaj obraz do prezentacji i przypisz go do wypełnienia kształtu. Ten przykład wymaga istniejącego pliku o nazwie "image.jpg" w katalogu roboczym. Rozciąga obraz, aby wypełnić prostokąt, stosuje ekstruzję 150 punktów i ustawia obrót kamery w stopniach. Konfiguruje kształt w pamięci bez zapisywania ani renderowania pliku:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
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

![Wyrenderowany prostokąt 3D z wypełnieniem zdjęciem na przedniej powierzchni i pomarańczową ekstruzją](img_02_04.png)

## **Zastosuj formatowanie 3D do tekstu**

Formatowanie 3D kształtu wpływa na ciało kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne przy efektach podobnych do WordArt, gdzie same litery wymagają ekstruzji, materiału, oświetlenia i ustawień kamery.

Poniższy przykład tworzy tekst z pomarańczowo-białym wzorem siatki, nakłada łuk skierowany do góry i konfiguruje ustawienia 3D za pomocą [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Wysokość i głębokość ekstruzji podane są w punktach, a obrót światła w stopniach. Wypełnienie i kontur kształtu są ukryte, aby widoczny był tylko tekst. Przykład renderuje obraz PNG w dwukrotnych domyślnych wymiarach slajdu i zapisuje prezentację jako PPTX:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int patternColor = Color.rgb(255, 140, 0);
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

![Wyrenderowany tekst 3D z łukowatą transformacją WordArt, pomarańczowym wypełnieniem wzorem i ciemną ekstruzją](img_02_05.png)

## **Utrzymaj tekst płaski na kształcie 3D**

Aby tekst był czytelny, zachowując jednocześnie wygląd 3D kształtu, wywołaj [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) przez [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). Gdy wartość jest `true`, tekst pozostaje poza sceną 3D. Gdy jest `false`, tekst uczestniczy w scenie i podąża za jej orientacją 3D.

To ustawienie nie usuwa formatowania 3D kształtu: jego kamera, oświetlenie, materiał i ekstruzja pozostają skonfigurowane poprzez [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). Jest to również inne niż zwykły obrót. [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) obraca kształt w płaszczyźnie slajdu, podczas gdy [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) kontroluje niestandardowy obrót tekstu w ramach jego obszaru. Utrzymanie tekstu poza sceną 3D nie resetuje żadnego z tych kątów.

Poniższy samodzielny przykład tworzy niebieski prostokąt z tekstem i klonuje go obok oryginału. Oba kształty mają to samo formatowanie 3D; różni je jedynie ustawienie tekstu: `false` po lewej i `true` po prawej. Kąty kamery podane są w stopniach, a wysokość ekstruzji wynosi 40 punktów. Przykład zapisuje prezentację jako PPTX i renderuje slajd porównawczy do PNG w dwukrotnych domyślnych wymiarach.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
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

![Prostokąty 3D obok siebie: tekst podąża za orientacją 3D po lewej i pozostaje płaski po prawej](keep_text_flat.png)

## **Zachowanie eksportu i renderowania**

Aspose.Slides zachowuje formatowanie 3D podczas zapisywania w formatach PowerPoint, takich jak PPTX. Podczas renderowania lub eksportu do formatów o stałym układzie, scena 3D jest rasteryzowana lub rysowana w wyjściu jako wynik 2D. Dotyczy to renderowania slajdów do [PNG](/slides/pl/androidjava/convert-powerpoint-to-png/), eksportu do [PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/), eksportu do [HTML](/slides/pl/androidjava/convert-powerpoint-to-html/), lub generowania klatek do [video conversion](/slides/pl/androidjava/convert-powerpoint-to-video/).

- Eksportowane obrazy i pliki PDF nie są interaktywne. Obiekt nie może być obracany przez widza po eksporcie.  
- Ostateczny wygląd zależy od kombinacji kamery, zestawu świateł, materiału, ekstruzji, wypełnienia i skalowania slajdu.  
- Jeśli musisz sprawdzić dziedziczone lub tematyczne wartości formatowania, odczytaj [efektywne właściwości kształtu](/slides/pl/androidjava/shape-effective-properties/).  
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D w PowerPoint. W tych formatach rezultat wizualny jest renderowany, a nie zachowywany jako edytowalne ustawienia 3D.

## **FAQ**

**Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?**

Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie zamienia eksportowanych obrazów, PDF‑ów ani stron HTML w interaktywne sceny 3D, które widz może obracać. W formacie PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, o ile format to umożliwia.

**Jaka jest różnica między modelem 3D a efektem 3D?**

Model 3D to osobny obiekt 3D wstawiany do prezentacji. Efekt 3D to formatowanie zastosowane do zwykłego kształtu lub tekstu w PowerPoint, takie jak obrót, ekstruzja, fazet, oświetlenie i materiał. Ten artykuł opisuje efekty 3D.

**Jakie ustawienia są wymagane, aby kształt 3D był widoczny?**

Co najmniej należy ustawić obrót kamery oraz ekstruzję lub głębokość. W praktyce warto także ustawić zestaw świateł i materiał, aby renderowane powierzchnie miały wyraźne podświetlenia i cienie.

**Czy mogę zastosować efekty 3D zarówno do kształtów, jak i do tekstu?**

Tak. Użyj [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) dla ciała kształtu oraz [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) dla tekstu.

**Czy efekty 3D będą widoczne przy eksporcie do obrazów, PDF, HTML lub klatek wideo?**

Tak. Aspose.Slides renderuje efekty 3D przy tworzeniu obrazów slajdów, wyjścia PDF, HTML oraz klatek używanych przy konwersji wideo. Wyeksportowany wynik zawiera wyrenderowany wygląd, a nie edytowalny obiekt 3D.

**Czy mogę odczytać ostateczne wartości 3D po zastosowaniu dziedziczenia i ustawień motywu?**

Tak. Użyj API efektywnego formatowania opisanych w [efektywne właściwości kształtu](/slides/pl/androidjava/shape-effective-properties/), aby odczytać ostateczne wartości kamery, zestawu świateł, fazetu i powiązane wartości 3D.