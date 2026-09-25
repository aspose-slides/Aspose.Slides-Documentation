---
title: Criar e aplicar efeitos WordArt no Android
linktitle: WordArt
type: docs
weight: 110
url: /pt/androidjava/wordart/
keywords:
- WordArt
- criar WordArt
- modelo WordArt
- efeito WordArt
- efeito de sombra
- efeito de reflexo
- efeito de brilho
- transformação WordArt
- efeito 3D
- efeito de sombra externa
- efeito de sombra interna
- Android
- Java
- Aspose.Slides
description: "Criar e personalizar efeitos WordArt no Aspose.Slides para Android via Java. Este guia passo a passo ajuda desenvolvedores a aprimorar apresentações com texto profissional no Android."
---
## **Visão geral**

Os efeitos WordArt permitem estilizar texto com preenchimentos, contornos, sombras, reflexos, brilho, transformações e formatação 3D. Este artigo explica como criar e personalizar esses efeitos em apresentações do PowerPoint usando Aspose.Slides para Android via Java, sem a necessidade de Microsoft Office instalado.

## **Criar um modelo WordArt simples e aplicá‑lo ao texto**

Os exemplos a seguir criam um estilo WordArt simples definindo o texto, a fonte, o preenchimento de padrão e o contorno.

Cada exemplo cria uma nova apresentação e adiciona um retângulo ao seu primeiro slide; nenhum arquivo de entrada é necessário. O primeiro exemplo define o texto como “Aspose.Slides”. A posição e as dimensões da forma são medidas em pontos:

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

Defina a fonte como Arial Black em 36 pontos para tornar a formatação mais perceptível:

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

Aplique um padrão [SmallGrid](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/patternstyle/#SmallGrid) com primeiro plano laranja escuro e fundo branco, e então adicione um contorno de texto preto com largura de 1 ponto:

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

O texto resultante:

![O modelo WordArt simples](WordArt_template.png)

## **Aplicar outros efeitos WordArt**

Os exemplos a seguir demonstram como aplicar sombras, reflexos, brilho, transformações e efeitos 3D ao texto.

### **Aplicar efeitos de sombra externa**

Uma sombra externa adiciona profundidade ao colocar uma sombra atrás do texto. Você pode personalizar sua cor, direção, distância, raio de desfoque, escala e inclinação.

Este exemplo chama [enableOuterShadowEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/effectformat/#enableOuterShadowEffect--) e define uma sombra preta com raio de desfoque de 4 pontos, direção de 230 graus e distância de 30 pontos. Valores de escala de 100 preservam o tamanho da sombra, enquanto a inclinação horizontal a inclina 20 graus. A transformação alfa define sua opacidade em 32%:

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

O texto resultante:

![O efeito de sombra externa](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Quando sombras externas e predefinidas são usadas juntas, apenas a sombra externa é aplicada.
- Se sombras externas e internas são usadas simultaneamente, o efeito resultante depende da versão do PowerPoint. Por exemplo, no PowerPoint 2013, o efeito é dobrado, enquanto no PowerPoint 2007, somente a sombra externa é aplicada.
{{% /alert %}}

### **Aplicar efeitos de reflexão**

Uma reflexão cria uma cópia espelhada do texto. Ajuste sua posição, escala, desfoque e opacidade para controlar a aparência.

Este exemplo chama [enableReflectionEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/effectformat/#enableReflectionEffect--) e inverte a reflexão verticalmente com escala de -100 %. Usa um raio de desfoque de 0,5 ponto e distância de 4,72 pontos. A opacidade diminui de 60 % para 0,9 % entre as posições 0 % e 60 % ao longo da reflexão:

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

O texto resultante:

![O efeito de reflexão](reflection_effect.png)

### **Aplicar efeitos de brilho**

Um brilho adiciona um contorno colorido suave ao redor do texto. Ajuste sua cor, opacidade e raio para controlar o efeito.

Este exemplo chama [enableGlowEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/effectformat/#enableGlowEffect--) e aplica um brilho vermelho com 54 % de opacidade e raio de 7 pontos:

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

O texto resultante:

![O efeito de brilho](glow_effect.png)

### **Aplicar transformações WordArt**

As transformações WordArt curvam, esticam ou distorcem um bloco de texto.

Defina [setTransform](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframeformat/#setTransform-int-) como [ArchUpPour](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textshapetype/#ArchUpPour) para curvar todo o quadro de texto para cima:

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

O texto resultante:

![A transformação WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides para Android via Java fornece um conjunto de [tipos de transformação predefinidos](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textshapetype/).
{{% /alert %}}

### **Aplicar efeitos 3D a formas e texto**

Você pode aplicar efeitos 3D a uma forma ou ao seu texto. Bisel, extrusão, iluminação e configurações de câmera controlam a aparência resultante.

O exemplo a seguir usa [ThreeDFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/threedformat/) para adicionar biséis circulares, extrusão laranja e contorno vermelho escuro ao retângulo. As dimensões do bisel, altura da extrusão, largura do contorno e profundidade são medidas em pontos. Um material plástico, iluminação equilibrada girada 40 graus ao redor do eixo Z e uma câmera em perspectiva definem sua aparência:

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

A forma resultante:

![O efeito 3D da forma](shape_3D_effect.png)

Este exemplo aplica formatação 3D semelhante ao texto através de [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframeformat/#getThreeDFormat--). Biseles menores modelam as bordas das letras, enquanto extrusão e iluminação dão profundidade ao texto:

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

O texto resultante:

![O efeito 3D do texto](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
A aplicação de efeitos 3D ao texto ou às suas formas — e a interação entre esses efeitos — é regida por regras específicas. Considere uma cena envolvendo tanto o texto quanto a forma que o contém. Um efeito 3D inclui a representação 3D do objeto e a cena na qual ele está inserido.

- Se uma cena for definida tanto para a forma quanto para o texto, a cena da forma tem prioridade e a cena do texto é ignorada.
- Se a forma não possuir sua própria cena mas tiver representação 3D, a cena do texto é usada.
- Se a forma não tiver efeito 3D algum, ela é tratada como plana, e o efeito 3D é aplicado apenas ao texto.

Esses comportamentos relacionam‑se aos métodos [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/threedformat/#getLightRig--) e [ThreeDFormat.getCamera](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Para manter o texto plano e legível enquanto preserva a formatação 3D da forma, veja [Manter texto plano em uma forma 3D](/slides/pt/androidjava/3d-presentation/) para comparação de ambas as configurações e um exemplo Java completo.

## **Perguntas frequentes**

**Posso usar efeitos WordArt com diferentes fontes ou scripts (por exemplo, Árabe, Chinês)?**

Sim, Aspose.Slides para Android via Java suporta Unicode e funciona com todas as principais fontes e scripts. Efeitos WordArt como sombra, preenchimento e contorno podem ser aplicados independentemente do idioma, embora a disponibilidade de fontes e a renderização possam depender das fontes do sistema.

**Posso aplicar efeitos WordArt aos elementos mestre de slide?**

Sim, você pode aplicar efeitos WordArt a formas em slides mestre, incluindo marcadores de posição de título, rodapés ou texto de fundo. Alterações feitas no layout mestre serão refletidas em todos os slides associados.

**Os efeitos WordArt afetam o tamanho do arquivo da apresentação?**

Um pouco. Efeitos WordArt como sombras, brilhos e preenchimentos gradientes podem aumentar ligeiramente o tamanho do arquivo devido ao acréscimo de metadados de formatação, mas a diferença costuma ser insignificante.

**Posso visualizar o resultado dos efeitos WordArt sem salvar a apresentação?**

Sim, você pode renderizar slides que contêm WordArt em imagens (por exemplo, PNG, JPEG) usando [ISlide.getImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islide/#getImage--), ou renderizar formas individuais usando [IShape.getImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getImage--). Isso permite pré‑visualizar o resultado na memória ou na tela antes de salvar ou exportar a apresentação completa.