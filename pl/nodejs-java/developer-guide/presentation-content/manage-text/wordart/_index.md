---
title: Tworzenie i stosowanie efektów WordArt w Node.js
linktitle: WordArt
type: docs
weight: 110
url: /pl/nodejs-java/wordart/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Tworzenie i dostosowywanie efektów WordArt w Aspose.Slides dla Node.js za pośrednictwem Javy. Ten przewodnik krok po kroku pomaga programistom ulepszyć prezentacje profesjonalnym tekstem w Node.js."
---
## **Przegląd**

Efekty WordArt pozwalają stylizować tekst przy użyciu wypełnień, konturów, cieni, odbić, poświaty, przekształceń i formatowania 3D. Ten artykuł wyjaśnia, jak tworzyć i dostosowywać te efekty w prezentacjach PowerPoint przy użyciu Aspose.Slides for Node.js via Java, bez zainstalowanego Microsoft Office.

## **Utwórz prosty szablon WordArt i zastosuj go do tekstu**

Poniższe przykłady tworzą prosty styl WordArt, ustawiając tekst, czcionkę, wypełnienie wzorem i kontur.  
Każdy przykład tworzy nową prezentację i dodaje prostokąt do jej pierwszego slajdu; nie wymaga pliku wejściowego. Pierwszy przykład ustawia tekst na „Aspose.Slides”. Pozycja i wymiary kształtu są mierzone w punktach:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();

    const portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Ustaw czcionkę na Arial Black o rozmiarze 36 punktów, aby formatowanie było bardziej widoczne:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Zastosuj wzór [SmallGrid](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/patternstyle/#SmallGrid) z ciemnopomarańczowym kolorem pierwszoplanowym i białym tłem, a następnie dodaj czarny kontur tekstu o szerokości 1 punktu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
} finally {
    presentation.dispose();
}
```

Powstały tekst:

![The simple WordArt template](WordArt_template.png)

## **Zastosuj inne efekty WordArt**

Poniższe przykłady demonstrują, jak zastosować cienie, odbicia, poświatę, przekształcenia i efekty 3D do tekstu.

### **Zastosuj efekty zewnętrznego cienia**

Zewnętrzny cień dodaje głębi, umieszczając cień za tekstem. Można dostosować jego kolor, kierunek, odległość, promień rozmycia, skalę i pochylenie.

Ten przykład wywołuje [enableOuterShadowEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effectformat/#enableOuterShadowEffect) i ustawia czarny cień o promieniu rozmycia 4 punkty, kierunku 230 stopni i odległości 30 punktów. Wartości skali 100 zachowują rozmiar cienia, natomiast poziome pochylenie przechyla go o 20 stopni. Transformacja alfa ustawia jego krycie na 32%:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.32));
} finally {
    presentation.dispose();
}
```

Powstały tekst:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Gdy zewnętrzne i wstępnie ustawione cienie są używane razem, stosowany jest tylko cień zewnętrzny.
- Jeśli jednocześnie używane są cienie zewnętrzne i wewnętrzne, wynikowy efekt zależy od wersji PowerPointa. Na przykład w PowerPoint 2013 efekt jest podwojony, natomiast w PowerPoint 2007 stosowany jest tylko cień zewnętrzny.
{{% /alert %}}

### **Zastosuj efekty odbicia**

Odbicie tworzy lustrzaną kopię tekstu. Dostosuj jego pozycję, skalę, rozmycie i krycie, aby kontrolować wygląd.

Ten przykład wywołuje [enableReflectionEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effectformat/#enableReflectionEffect) i odwraca odbicie pionowo ze skalą -100%. Używa promienia rozmycia 0.5 punktu i odległości 4.72 punktu. Krycie zmniejsza się z 60% do 0.9% pomiędzy pozycjami 0% i 60% wzdłuż odbicia:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(java.newFloat(0));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(java.newFloat(0.9));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.BottomLeft));
} finally {
    presentation.dispose();
}
```

Powstały tekst:

![The Reflection effect](reflection_effect.png)

### **Zastosuj efekty poświaty**

Poświata dodaje miękki, kolorowy kontur wokół tekstu. Dostosuj jej kolor, krycie i promień, aby kontrolować efekt.

Ten przykład wywołuje [enableGlowEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effectformat/#enableGlowEffect) i stosuje czerwoną poświatę o kryciu 54% i promieniu 7 punktów:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.54));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Powstały tekst:

![The Glow effect](glow_effect.png)

### **Zastosuj przekształcenia WordArt**

Przekształcenia WordArt wyginają, rozciągają lub deformują blok tekstu.

Ustaw [setTransform](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/#setTransform) na [ArchUpPour](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textshapetype/#ArchUpPour), aby zakrzywić cały tekst w górę:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
} finally {
    presentation.dispose();
}
```

Powstały tekst:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java udostępnia zestaw predefiniowanych [transformation types](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **Zastosuj efekty 3D do kształtów i tekstu**

Można zastosować efekty 3D do kształtu lub do jego tekstu. Bryły, ekstruzja, oświetlenie i ustawienia kamery kontrolują wynikowy wygląd.

Następujący przykład używa [ThreeDFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/) aby dodać okrągłe fazety, pomarańczową ekstruzję i ciemnoczerwony kontur do prostokąta. Wymiary fazet, wysokość ekstruzji, szerokość konturu i głębokość mierzone są w punktach. Materiał plastikowy, zrównoważone oświetlenie obrócone o 40 stopni wokół osi Z oraz perspektywiczna kamera definiują jego wygląd:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Powstały kształt:

![The shape 3D effect](shape_3D_effect.png)

Ten przykład stosuje podobne formatowanie 3D do tekstu za pomocą [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Mniejsze fazety kształtują krawędzie liter, a ekstruzja i oświetlenie nadają tekstowi głębię:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Powstały tekst:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Zastosowanie efektów 3D do tekstu lub ich kształtów — oraz interakcja między tymi efektami — podlega określonym regułom. Rozważ scenę obejmującą zarówno tekst, jak i kształt go zawierający. Efekt 3D obejmuje trójwymiarową reprezentację obiektu oraz scenę, w której jest umieszczony.

- Jeśli scena jest ustawiona zarówno dla kształtu, jak i dla tekstu, priorytet ma scena kształtu, a scena tekstu jest ignorowana.
- Jeśli kształt nie ma własnej sceny, ale ma reprezentację 3D, używana jest scena tekstu.
- Jeśli kształt nie ma żadnego efektu 3D, jest traktowany jako płaski, a efekt 3D stosowany jest wyłącznie do tekstu.

Te zachowania odnoszą się do metod [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#getLightRig) i [ThreeDFormat.getCamera](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

Aby utrzymać tekst płaski i czytelny przy zachowaniu formatowania 3D kształtu, zobacz [Keep Text Flat on a 3D Shape](/slides/pl/nodejs-java/3d-presentation/) dla porównania obu ustawień i pełnego przykładu JavaScript.

## **FAQ**

**Czy mogę używać efektów WordArt z różnymi czcionkami lub skryptami (np. arabski, chiński)?**

Tak, Aspose.Slides for Node.js via Java obsługuje Unicode i współpracuje ze wszystkimi głównymi czcionkami i skryptami. Efekty WordArt, takie jak cień, wypełnienie i kontur, można zastosować niezależnie od języka, choć dostępność czcionek i renderowanie mogą zależeć od czcionek systemowych.

**Czy mogę zastosować efekty WordArt do elementów wzorca slajdu?**

Tak, możesz zastosować efekty WordArt do kształtów na slajdach wzorca, w tym do pola tytułu, stopki lub tekstu tła. Zmiany wprowadzane w układzie wzorca będą odzwierciedlane we wszystkich powiązanych slajdach.

**Czy efekty WordArt wpływają na rozmiar pliku prezentacji?**

Nieznacznie. Efekty WordArt, takie jak cienie, poświaty i gradientowe wypełnienia, mogą nieco zwiększyć rozmiar pliku ze względu na dodatkowe metadane formatowania, ale różnica jest zwykle pomijalna.

**Czy mogę podglądnąć wynik efektów WordArt bez zapisywania prezentacji?**

Tak, możesz renderować slajdy zawierające WordArt do obrazów (np. PNG, JPEG) używając [Slide.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#getImage), lub renderować poszczególne kształty przy pomocy [Shape.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getImage). Dzięki temu możesz podejrzeć wynik w pamięci lub na ekranie przed zapisaniem lub wyeksportowaniem pełnej prezentacji.