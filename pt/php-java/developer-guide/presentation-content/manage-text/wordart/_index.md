---
title: Criar e Aplicar Efeitos WordArt em PHP
linktitle: WordArt
type: docs
weight: 110
url: /pt/php-java/wordart/
keywords:
- WordArt
- criar WordArt
- modelo WordArt
- efeito WordArt
- efeito de sombra
- efeito de reflexão
- efeito de brilho
- transformação WordArt
- efeito 3D
- efeito de sombra externa
- efeito de sombra interna
- PHP
- Aspose.Slides
description: "Crie e personalize efeitos WordArt no Aspose.Slides para PHP via Java. Este guia passo a passo ajuda os desenvolvedores a melhorar apresentações com texto profissional em PHP."
---
## **Visão geral**

Os efeitos WordArt permitem estilizar texto com preenchimentos, contornos, sombras, reflexos, brilho, transformações e formatação 3D. Este artigo explica como criar e personalizar esses efeitos em apresentações do PowerPoint usando Aspose.Slides for PHP via Java, sem a necessidade de ter o Microsoft Office instalado.

## **Criar um Modelo WordArt Simples e Aplicá‑lo ao Texto**

Os exemplos a seguir criam um estilo WordArt simples definindo o texto, a fonte, o preenchimento de padrão e o contorno.

Cada exemplo cria uma nova apresentação e adiciona um retângulo ao seu primeiro slide; nenhum arquivo de entrada é necessário. O primeiro exemplo define o texto como "Aspose.Slides". A posição e as dimensões da forma são medidas em pontos:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();

    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
} finally {
    $presentation->dispose();
}
```

Defina a fonte como Arial Black com 36 pontos para tornar a formatação mais evidente:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);
} finally {
    $presentation->dispose();
}
```

Aplicar um padrão [SmallGrid](https://reference.aspose.com/slides/pt/php-java/aspose.slides/patternstyle/#SmallGrid) com primeiro plano laranja escuro e fundo branco, e então adicionar um contorno de texto preto com largura de 1 ponto:

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($darkOrange);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::SmallGrid);

    $portion->getPortionFormat()->getLineFormat()->setWidth(1);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
} finally {
    $presentation->dispose();
}
```

Texto resultante:

![O modelo WordArt simples](WordArt_template.png)

## **Aplicar Outros Efeitos WordArt**

Os exemplos a seguir demonstram como aplicar sombras, reflexos, brilho, transformações e efeitos 3D ao texto.

### **Aplicar Efeito de Sombra Externa**

Uma sombra externa adiciona profundidade ao colocar uma sombra atrás do texto. É possível personalizar sua cor, direção, distância, raio de desfoque, escala e inclinação.

Este exemplo chama [enableOuterShadowEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effectformat/#enableOuterShadowEffect--) e define uma sombra preta com raio de desfoque de 4 pontos, direção de 230 graus e distância de 30 pontos. Valores de escala de 100 mantêm o tamanho da sombra, enquanto a inclinação horizontal a inclina em 20 graus. A transformação alfa define sua opacidade em 32%:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(30);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(20);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.32);
} finally {
    $presentation->dispose();
}
```

Texto resultante:

![O efeito de sombra externa](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Quando sombras externas e predefinidas são usadas juntas, apenas a sombra externa é aplicada.
- Se sombras externas e internas forem usadas simultaneamente, o efeito resultante depende da versão do PowerPoint. Por exemplo, no PowerPoint 2013 o efeito é dobrado, enquanto no PowerPoint 2007 apenas a sombra externa é aplicada.
{{% /alert %}}

### **Aplicar Efeitos de Reflexão**

Uma reflexão cria uma cópia espelhada do texto. Ajuste sua posição, escala, desfoque e opacidade para controlar sua aparência.

Este exemplo chama [enableReflectionEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effectformat/#enableReflectionEffect--) e inverte a reflexão verticalmente com escala de -100%. Usa um raio de desfoque de 0,5 ponto e uma distância de 4,72 pontos. A opacidade diminui de 60% para 0,9% entre as posições 0% e 60% ao longo da reflexão:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::BottomLeft);
} finally {
    $presentation->dispose();
}
```

Texto resultante:

![O efeito de reflexão](reflection_effect.png)

### **Aplicar Efeitos de Brilho**

Um brilho adiciona um contorno suave colorido ao redor do texto. Ajuste sua cor, opacidade e raio para controlar o efeito.

Este exemplo chama [enableGlowEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effectformat/#enableGlowEffect--) e aplica um brilho vermelho com 54% de opacidade e raio de 7 pontos:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->RED);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.54);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
} finally {
    $presentation->dispose();
}
```

Texto resultante:

![O efeito de brilho](glow_effect.png)

### **Aplicar Transformações WordArt**

As transformações WordArt dobram, esticam ou distorcem um bloco de texto.

Defina [setTransform](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/#setTransform-int-) para [ArchUpPour](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textshapetype/#ArchUpPour) para curvar todo o quadro de texto para cima:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");
    $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
} finally {
    $presentation->dispose();
}
```

Texto resultante:

![A transformação WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java fornece um conjunto de [tipos de transformação](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textshapetype/) predefinidos.
{{% /alert %}}

### **Aplicar Efeitos 3D a Formas e Texto**

É possível aplicar efeitos 3D a uma forma ou ao seu texto. Chanfros, extrusão, iluminação e configurações de câmera controlam a aparência resultante.

O exemplo a seguir usa [ThreeDFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/) para adicionar chanfros circulares, extrusão laranja e contorno vermelho escuro ao retângulo. As dimensões do chanfre, altura da extrusão, largura e profundidade do contorno são medidas em pontos. Um material plástico, iluminação equilibrada girada 40 graus ao redor do eixo Z, e uma câmera em perspectiva definem sua aparência:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $autoShape->getTextFrame()->setText("Aspose.Slides");

    $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
    $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);

    $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
    $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $autoShape->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $autoShape->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $autoShape->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $autoShape->getThreeDFormat()->setContourWidth(1.5);

    $autoShape->getThreeDFormat()->setDepth(3);

    $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

Forma resultante:

![O efeito 3D da forma](shape_3D_effect.png)

Este exemplo aplica formatação 3D semelhante ao texto por meio de [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Chanfros menores moldam as bordas das letras, enquanto a extrusão e a iluminação dão profundidade ao texto:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

Texto resultante:

![O efeito 3D do texto](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
A aplicação de efeitos 3D ao texto ou às suas formas — e a interação entre esses efeitos — é regida por regras específicas. Considere uma cena envolvendo tanto o texto quanto a forma que o contém. Um efeito 3D inclui a representação 3D do objeto e a cena em que ele está inserido.

- Se uma cena for definida tanto para a forma quanto para o texto, a cena da forma tem prioridade e a cena do texto é ignorada.
- Se a forma não possuir sua própria cena, mas tiver uma representação 3D, a cena do texto será usada.
- Se a forma não possuir efeito 3D algum, ela será tratada como plana, e o efeito 3D será aplicado somente ao texto.

Esses comportamentos relacionam‑se aos métodos [ThreeDFormat::getLightRig](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/#getLightRig--) e [ThreeDFormat::getCamera](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Para mais exemplos de formatação 3D, veja [Criar Efeitos 3D em Apresentações Usando PHP](/slides/pt/php-java/3d-presentation/).

## **FAQ**

**Posso usar efeitos WordArt com diferentes fontes ou scripts (por exemplo, Árabe, Chinês)?**

Sim, o Aspose.Slides for PHP via Java oferece suporte a Unicode e funciona com todas as principais fontes e scripts. Efeitos WordArt como sombra, preenchimento e contorno podem ser aplicados independentemente do idioma, embora a disponibilidade da fonte e a renderização possam depender das fontes instaladas no sistema.

**Posso aplicar efeitos WordArt aos elementos do mestre de slides?**

Sim, você pode aplicar efeitos WordArt a formas nos mestres de slides, incluindo espaços reservados de título, rodapés ou texto de fundo. Alterações feitas no layout mestre serão refletidas em todos os slides associados.

**Os efeitos WordArt afetam o tamanho do arquivo da apresentação?**

Um pouco. Efeitos WordArt como sombras, brilhos e preenchimentos em gradiente podem aumentar ligeiramente o tamanho do arquivo devido aos metadados de formatação adicionais, mas a diferença costuma ser insignificante.

**Posso visualizar o resultado dos efeitos WordArt sem salvar a apresentação?**

Sim, você pode renderizar slides que contêm WordArt em imagens (por exemplo, PNG, JPEG) usando [Slide::getImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#getImage--), ou renderizar formas individuais usando [Shape::getImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getImage--). Isso permite visualizar o resultado na memória ou na tela antes de salvar ou exportar a apresentação completa.