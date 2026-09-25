---
title: Tworzenie i stosowanie efektów WordArt na Androidzie
linktitle: WordArt
type: docs
weight: 110
url: /pl/androidjava/wordart/
keywords:
- WordArt
- tworzenie WordArt
- szablon WordArt
- efekt WordArt
- efekt cienia
- efekt odbicia
- efekt poświaty
- przekształcenie WordArt
- efekt 3D
- efekt zewnętrznego cienia
- efekt wewnętrznego cienia
- Android
- Java
- Aspose.Slides
description: "Tworzenie i dostosowywanie efektów WordArt w Aspose.Slides for Android via Java. Ten przewodnik krok po kroku pomaga programistom ulepszyć prezentacje przy użyciu profesjonalnego tekstu na Androidzie."
---
## **Przegląd**

Efekty WordArt pozwalają stylizować tekst przy użyciu wypełnień, obrysów, cieni, odbić, poświaty, przekształceń oraz formatowania 3D. Ten artykuł wyjaśnia, jak tworzyć i dostosowywać te efekty w prezentacjach PowerPoint przy użyciu Aspose.Slides for Android via Java, bez instalacji Microsoft Office.

## **Utwórz prosty szablon WordArt i zastosuj go do tekstu**

Poniższe przykłady tworzą prosty styl WordArt, ustawiając tekst, czcionkę, wypełnienie wzorem i obrys.

Każdy przykład tworzy nową prezentację i dodaje prostokąt do jej pierwszego slajdu; nie jest wymagany żaden plik wejściowy. Pierwszy przykład ustawia tekst na „Aspose.Slides”. Pozycja i wymiary kształtu są mierzone w punktach:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Ustaw czcionkę na Arial Black o rozmiarze 36 punktów, aby formatowanie było bardziej widoczne:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Zastosuj wzór [SmallGrid](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/patternstyle/#SmallGrid) z ciemnopomarańczowym kolorem pierwszego planu i białym tłem, a następnie dodaj czarny obrys tekstu o szerokości 1 punktu:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    int darkOrange = Color.rgb(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

Powstały tekst:

![Prosty szablon WordArt](WordArt_template.png)

## **Zastosuj inne efekty WordArt**

Poniższe przykłady pokazują, jak zastosować cienie, odbicia, poświatę, przekształcenia i efekty 3D do tekstu.

### **Zastosuj efekty cienia zewnętrznego**

Cień zewnętrzny dodaje głębi, umieszczając cień za tekstem. Możesz dostosować jego kolor, kierunek, odległość, promień rozmycia, skalę i pochylenie.

Ten przykład wywołuje [enableOuterShadowEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effectformat/#enableOuterShadowEffect--) i ustawia czarny cień o promieniu rozmycia 4 punkty, kierunku 230 stopni i odległości 30 punktów. Wartość skali 100 zachowuje rozmiar cienia, natomiast poziome pochylenie przechyla go o 20 stopni. Transformacja alfa ustawia jego krycie na 32 %:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

Powstały tekst:

![Efekt cienia zewnętrznego](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Gdy jednocześnie używane są cienie zewnętrzne i wstępnie ustawione, stosowany jest tylko cień zewnętrzny.
- Jeśli jednocześnie używane są cienie zewnętrzne i wewnętrzne, wynikowy efekt zależy od wersji PowerPointa. Na przykład w PowerPoint 2013 efekt podwaja się, natomiast w PowerPoint 2007 stosowany jest tylko cień zewnętrzny.
{{% /alert %}}

### **Zastosuj efekty odbicia**

Odbicie tworzy lustrzane odbicie tekstu. Dostosuj jego pozycję, skalę, rozmycie i krycie, aby kontrolować wygląd.

Ten przykład wywołuje [enableReflectionEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effectformat/#enableReflectionEffect--) i odbija odbicie pionowo ze skalą –100 %. Używa promienia rozmycia 0,5 punkta i odległości 4,72 punktu. Krycie zmniejsza się z 60 % do 0,9 % między pozycjami 0 % a 60 % wzdłuż odbicia:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);
} finally {
    presentation.dispose();
}
```

Powstały tekst:

![Efekt odbicia](reflection_effect.png)

### **Zastosuj efekty poświaty**

Poświata dodaje miękki, kolorowy obrys wokół tekstu. Dostosuj jej kolor, krycie i promień, aby kontrolować efekt.

Ten przykład wywołuje [enableGlowEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effectformat/#enableGlowEffect--) i stosuje czerwoną poświatę o kryciu 54 % i promieniu 7 punktów:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Powstały tekst:

![Efekt poświaty](glow_effect.png)

### **Zastosuj przekształcenia WordArt**

Przekształcenia WordArt wyginają, rozciągają lub deformują blok tekstu.

Ustaw [setTransform](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textframeformat/#setTransform-int-) na [ArchUpPour](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textshapetype/#ArchUpPour), aby zakrzywić cały tekst w górę:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

Powstały tekst:

![Przekształcenie WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java udostępnia zestaw predefiniowanych [typów przekształceń](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textshapetype/).
{{% /alert %}}

### **Zastosuj efekty 3D do kształtów i tekstu**

Można zastosować efekty 3D do kształtu lub jego tekstu. Krawędzie (bevels), ekstruzja, oświetlenie i ustawienia kamery kontrolują ostateczny wygląd.

Poniższy przykład używa [ThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/threedformat/) do dodania okrągłych krawędzi, pomarańczowej ekstruzji i ciemnoczerwonego konturu prostokąta. Wymiary krawędzi, wysokość ekstruzji, szerokość konturu i głębokość mierzone są w punktach. Materiał plastikowy, zrównoważone oświetlenie obrócone o 40 stopni wokół osi Z oraz perspektywiczna kamera definiują jego wygląd:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    int orange = Color.rgb(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Powstały kształt:

![Efekt 3D kształtu](shape_3D_effect.png)

Ten przykład stosuje podobne formatowanie 3D do tekstu poprzez [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textframeformat/#getThreeDFormat--). Mniejsze krawędzie kształtują krawędzie liter, a ekstruzja i oświetlenie nadają tekstowi głębię:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    int orange = Color.rgb(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Powstały tekst:

![Efekt 3D tekstu](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Stosowanie efektów 3D do tekstu lub jego kształtów — oraz interakcja między tymi efektami — podlega określonym regułom. Rozważ scenę obejmującą zarówno tekst, jak i zawierający go kształt. Efekt 3D obejmuje trójwymiarową reprezentację obiektu oraz scenę, w której jest umieszczony.

- Jeśli scena jest ustawiona zarówno dla kształtu, jak i dla tekstu, scenę kształtu ma pierwszeństwo, a scena tekstu jest ignorowana.
- Jeśli kształt nie ma własnej sceny, ale posiada trójwymiarową reprezentację, używana jest scena tekstu.
- Jeśli kształt nie ma w ogóle efektu 3D, jest traktowany jako płaski, a efekt 3D jest stosowany wyłącznie do tekstu.

Zachowania te odnoszą się do metod [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/threedformat/#getLightRig--) i [ThreeDFormat.getCamera](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Aby zachować tekst płaski i czytelny, jednocześnie zachowując formatowanie 3D kształtu, zobacz [Keep Text Flat on a 3D Shape](/slides/pl/androidjava/3d-presentation/) po porównanie obu ustawień i kompletny przykład w Javie.

## **FAQ**

**Czy mogę używać efektów WordArt z różnymi czcionkami lub skryptami (np. arabski, chiński)?**

Tak, Aspose.Slides for Android via Java obsługuje Unicode i współpracuje ze wszystkimi głównymi czcionkami i skryptami. Efekty WordArt, takie jak cień, wypełnienie i obrys, mogą być stosowane bez względu na język, choć dostępność czcionek i renderowanie mogą zależeć od czcionek systemowych.

**Czy mogę zastosować efekty WordArt do elementów mastera slajdu?**

Tak, możesz stosować efekty WordArt do kształtów na slajdach master, w tym do pól tytułu, stopek lub tekstu tła. Zmiany w układzie mastera zostaną odzwierciedlone we wszystkich powiązanych slajdach.

**Czy efekty WordArt wpływają na rozmiar pliku prezentacji?**

Nieznacznie. Efekty WordArt, takie jak cienie, poświaty i gradientowe wypełnienia, mogą nieco zwiększyć rozmiar pliku ze względu na dodatkowe metadane formatowania, ale różnica zazwyczaj jest pomijalna.

**Czy mogę podglądać wynik efektów WordArt bez zapisywania prezentacji?**

Tak, możesz renderować slajdy zawierające WordArt do obrazów (np. PNG, JPEG) używając [ISlide.getImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#getImage--), lub renderować poszczególne kształty przy pomocy [IShape.getImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getImage--). Pozwala to podglądnąć wynik w pamięci lub na ekranie przed zapisem lub eksportem pełnej prezentacji.