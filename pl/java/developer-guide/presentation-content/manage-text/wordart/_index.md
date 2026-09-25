---
title: Tworzenie i stosowanie efektów WordArt w Javie
linktitle: WordArt
type: docs
weight: 110
url: /pl/java/wordart/
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
- Java
- Aspose.Slides
description: "Twórz i dostosowuj efekty WordArt w Aspose.Slides dla Javy. Ten przewodnik krok po kroku pomaga programistom ulepszyć prezentacje profesjonalnym tekstem w Javie."
---
## **Przegląd**

Efekty WordArt pozwalają stylizować tekst przy użyciu wypełnień, obrysów, cieni, odbić, poświaty, przekształceń oraz formatowania 3D. Ten artykuł wyjaśnia, jak tworzyć i dostosowywać te efekty w prezentacjach PowerPoint przy użyciu Aspose.Slides for Java, bez zainstalowanego Microsoft Office.

## **Utwórz prosty szablon WordArt i zastosuj go do tekstu**

Poniższe przykłady budują prosty styl WordArt poprzez ustawienie tekstu, czcionki, wypełnienia wzorem i obrysu.

Każdy przykład tworzy nową prezentację i dodaje prostokąt do pierwszego slajdu; nie jest wymagany żadny plik wejściowy. W pierwszym przykładzie ustawiany jest tekst „Aspose.Slides”. Pozycja i wymiary kształtu podawane są w punktach:

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

Zastosuj wzorzec [SmallGrid](https://reference.aspose.com/slides/pl/java/com.aspose.slides/patternstyle/#SmallGrid) z ciemnopomarańczowym pierwszym planem i białym tłem, a następnie dodaj czarny obrys tekstu o szerokości 1 punktu:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    Color darkOrange = new Color(255, 140, 0);
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

Efekt końcowy:

![The simple WordArt template](WordArt_template.png)

## **Zastosuj inne efekty WordArt**

Poniższe przykłady pokazują, jak zastosować cienie, odbicia, poświatę, przekształcenia i efekty 3D do tekstu.

### **Zastosuj efekty zewnętrznego cienia**

Zewnętrzny cień dodaje głębi, umieszczając cień za tekstem. Możesz dostosować jego kolor, kierunek, odległość, promień rozmycia, skalę i pochylenie.

Ten przykład wywołuje [enableOuterShadowEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/effectformat/#enableOuterShadowEffect--) i ustawia czarny cień z promieniem rozmycia 4 punkty, kierunkiem 230 stopni i odległością 30 punktów. Wartości skali 100 zachowują rozmiar cienia, a pochylenie poziome przechyla go o 20 stopni. Transformacja alfa ustawia jego nieprzezroczystość na 32 %:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Efekt końcowy:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}

- Gdy używane są jednocześnie zewnętrzny i wstępnie ustawiony cień, stosowany jest tylko cień zewnętrzny.
- Jeśli jednocześnie zastosowane są cienie zewnętrzne i wewnętrzne, wynikowy efekt zależy od wersji PowerPointa. Na przykład w PowerPoint 2013 efekt jest podwójny, podczas gdy w PowerPoint 2007 stosowany jest tylko cień zewnętrzny.

{{% /alert %}}

### **Zastosuj efekty odbicia**

Odbicie tworzy lustrzaną kopię tekstu. Dostosuj jego pozycję, skalę, rozmycie i nieprzezroczystość, aby kontrolować wygląd.

Ten przykład wywołuje [enableReflectionEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/effectformat/#enableReflectionEffect--) i odwraca odbicie pionowo przy skali -100 %. Używa promienia rozmycia 0,5 punktu i odległości 4,72 punktu. Nieprzezroczystość zmniejsza się z 60 % do 0,9 % między pozycjami 0 % a 60 % wzdłuż odbicia:

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

Efekt końcowy:

![The Reflection effect](reflection_effect.png)

### **Zastosuj efekty poświaty**

Poświata dodaje miękki, kolorowy obrys wokół tekstu. Dostosuj jej kolor, nieprzezroczystość i promień, aby kontrolować efekt.

Ten przykład wywołuje [enableGlowEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/effectformat/#enableGlowEffect--) i stosuje czerwoną poświatę z nieprzezroczystością 54 % oraz promieniem 7 punktów:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Efekt końcowy:

![The Glow effect](glow_effect.png)

### **Zastosuj przekształcenia WordArt**

Przekształcenia WordArt wyginają, rozciągają lub deformują blok tekstu.

Ustaw [setTransform](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textframeformat/#setTransform-int-) na [ArchUpPour](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textshapetype/#ArchUpPour), aby zakrzywić cały tekst w górę:

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

Efekt końcowy:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}

Aspose.Slides for Java udostępnia zestaw wstępnie zdefiniowanych [typów przekształceń](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textshapetype/).

{{% /alert %}}

### **Zastosuj efekty 3D do kształtów i tekstu**

Można zastosować efekty 3D do kształtu lub do jego tekstu. Krawędzie, ekstruzja, oświetlenie i ustawienia kamery kontrolują ostateczny wygląd.

Poniższy przykład używa [ThreeDFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/threedformat/) do dodania okrągłych krawędzi, pomarańczowej ekstruzji i ciemnoczerwonego konturu prostokąta. Wymiary krawędzi, wysokość ekstruzji, szerokość konturu i głębokość podawane są w punktach. Materiał plastikowy, zrównoważone oświetlenie obrócone o 40 stopni wokół osi Z oraz perspektywiczna kamera definiują jego wygląd:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    Color orange = new Color(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
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

Kształt końcowy:

![The shape 3D effect](shape_3D_effect.png)

Ten przykład stosuje podobne formatowanie 3D do tekstu za pomocą [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textframeformat/#getThreeDFormat--). Mniejsze krawędzie kształtują krawędzie liter, podczas gdy ekstruzja i oświetlenie nadają tekstowi głębię:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    Color orange = new Color(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
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

Efekt końcowy:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}

Stosowanie efektów 3D do tekstu lub ich kształtów — oraz interakcja między tymi efektami — jest regulowane przez określone zasady. Rozważ scenę obejmującą zarówno tekst, jak i kształt go zawierający. Efekt 3D obejmuje reprezentację 3D obiektu oraz scenę, w której jest umieszczony.

- Jeśli scena jest ustawiona zarówno dla kształtu, jak i tekstu, priorytet ma scena kształtu, a scena tekstu jest ignorowana.
- Jeśli kształt nie ma własnej sceny, ale posiada reprezentację 3D, używana jest scena tekstu.
- Jeśli kształt nie ma w ogóle efektu 3D, traktowany jest jako płaski, a efekt 3D stosowany jest wyłącznie do tekstu.

Zachowania te dotyczą metod [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/pl/java/com.aspose.slides/threedformat/#getLightRig--) i [ThreeDFormat.getCamera](https://reference.aspose.com/slides/pl/java/com.aspose.slides/threedformat/#getCamera--).

{{% /alert %}}

Aby utrzymać tekst płaski i czytelny przy jednoczesnym zachowaniu formatowania 3D kształtu, zobacz [Keep Text Flat on a 3D Shape](/slides/pl/java/3d-presentation/) – porównanie obu ustawień oraz pełny przykład w Javie.

## **FAQ**

**Czy mogę używać efektów WordArt z różnymi czcionkami lub skryptami (np. arabski, chiński)?**

Tak, Aspose.Slides for Java obsługuje Unicode i współpracuje ze wszystkimi głównymi czcionkami i skryptami. Efekty WordArt, takie jak cień, wypełnienie i obrys, można stosować niezależnie od języka, choć dostępność czcionek i renderowanie mogą zależeć od czcionek systemowych.

**Czy mogę stosować efekty WordArt do elementów mastera slajdów?**

Tak, możesz zastosować efekty WordArt do kształtów na slajdach master, w tym do pól tytułu, stopek czy tekstu tła. Zmiany w układzie mastera będą odzwierciedlane we wszystkich powiązanych slajdach.

**Czy efekty WordArt wpływają na rozmiar pliku prezentacji?**

Nieznacznie. Efekty WordArt, takie jak cienie, poświaty i wypełnienia gradientowe, mogą nieco zwiększyć rozmiar pliku ze względu na dodatkowe metadane formatowania, ale różnica jest zazwyczaj pomijalna.

**Czy mogę podejrzeć wynik efektów WordArt bez zapisywania prezentacji?**

Tak, możesz renderować slajdy zawierające WordArt do obrazów (np. PNG, JPEG) używając [ISlide.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/#getImage--), lub renderować pojedyncze kształty przy pomocy [IShape.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getImage--). Pozwala to podglądać wynik w pamięci lub na ekranie przed zapisaniem lub eksportem pełnej prezentacji.