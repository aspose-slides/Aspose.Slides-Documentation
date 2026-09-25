---
title: Criar efeitos 3D em apresentações usando Node.js
linktitle: Apresentação 3D
type: docs
weight: 232
url: /pt/nodejs-java/3d-presentation/
keywords:
- PowerPoint 3D
- apresentação 3D
- rotação 3D
- profundidade 3D
- extrusão 3D
- gradiente 3D
- texto 3D
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aplicar e renderizar efeitos 3D para formas e texto do PowerPoint no Node.js com Aspose.Slides. Configurar câmera, iluminação, material, extrusão, preenchimentos e texto 3D."
---
## **Visão geral**

Aspose.Slides for Node.js via Java pode criar, editar, preservar e renderizar formatação 3D no estilo PowerPoint para formas e texto. Este artigo aborda efeitos 3D como rotação, extrusão, chanfrados, iluminação, material, preenchimentos em gradiente ou imagem e texto 3D.

{{% alert color="info" title="Note" %}}
Este artigo trata de efeitos de formatação 3D em formas e texto do PowerPoint. Não trata da inserção ou edição de arquivos de modelo 3D autônomos. Quando você exporta um slide para uma imagem, PDF ou HTML, o Aspose.Slides renderiza esses efeitos 3D na saída 2D exportada.
{{% /alert %}}

## **Conceitos de Formatação 3D**

Use o método [Shape.getThreeDFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getThreeDFormat) para aplicar formatação 3D a uma forma. O método retorna [ThreeDFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/), que controla a cena 3D para essa forma.

Para texto, use o método [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Isso aplica formatação 3D ao quadro de texto em vez do corpo da forma.

Os membros mais importantes da API são:

| Membro da API | O que controla | Quando usar |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#getCamera) | Ponto de vista, tipo de câmera predefinido, rotação, zoom e perspectiva. | Gire o objeto no espaço 3D ou corresponda a um preset de rotação 3D do PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#getLightRig) | Preset de luz, direção e rotação da luz. | Altere como os realces e sombras aparecem na superfície 3D. |
| [getMaterial](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#getMaterial) e [setMaterial](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#setMaterial) | Material da superfície, como plano, fosco, plástico ou metal. | Faça a mesma geometria parecer mais plana, suave, brilhante ou metálica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) e [setExtrusionHeight](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Quão longe a forma se estende para trás a partir de sua face frontal. | Transforme uma forma plana em um objeto 3D visivelmente espesso. |
| [getExtrusionColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Cor dos lados extrudados. | Torne a profundidade visível ou coordene a cor dos lados com o preenchimento frontal. |
| [getDepth](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#getDepth) e [setDepth](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#setDepth) | Profundidade 3D adicional usada pela formatação 3D do PowerPoint. | Ajuste fino da profundidade para formas ou texto, especialmente junto com configurações de chanfrado e material. |
| [getBevelTop](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#getBevelTop) e [getBevelBottom](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Bordas elevadas ou arredondadas nas faces frontal e traseira. | Adicione uma borda suavizada ou moldada em vez de uma face plana e afiada. |
| [getContourColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#getContourWidth) e [setContourWidth](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Contorno ao redor do objeto 3D. | Enfatize o contorno do objeto na saída renderizada. |

## **Criar uma Forma 3D**

Uma forma normalmente precisa de quatro tipos de configurações antes de parecer convincentemente 3D:

- Configurações de câmera, pois a visualização frontal padrão pode esconder a extrusão.
- Configurações de iluminação, pois a luz torna as faces e lados legíveis.
- Configurações de material, pois a superfície afeta como a luz é renderizada.
- Configurações de extrusão ou profundidade, pois uma forma plana precisa de espessura.

O exemplo a seguir cria um retângulo, adiciona texto à sua face frontal e aplica formatação 3D. Os valores de rotação da câmera estão em graus, e a altura da extrusão é de 100 pontos. O exemplo renderiza o slide para uma imagem PNG em duas vezes suas dimensões padrão e salva a apresentação como PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A imagem do slide renderizado mostra o retângulo como um bloco 3D espesso:

![Retângulo 3D azul renderizado com texto 3D branco na face frontal](img_01_01.png)

## **Rotacionar uma Forma com a Câmera**

No PowerPoint, a rotação 3D é configurada a partir do painel Rotação 3-D. Os valores de rotação X, Y e Z correspondem à rotação que você define através da API de câmera.

![Painel Rotação 3-D do PowerPoint com valores de rotação X, Y e Z destacados](img_02_01.png)

No Aspose.Slides, acesse a câmera através de [ThreeDFormat.getCamera](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#getCamera). Este exemplo cria um retângulo, seleciona uma visualização frontal ortográfica e define suas rotações X, Y e Z para 20, 30 e 40 graus, respectivamente. Ele configura a forma na memória sem salvar um arquivo:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Use a câmera quando precisar mudar como o visualizador vê o objeto. Ela não altera a geometria da forma 2D no slide. Ela altera o ponto de vista 3D usado pelo PowerPoint e pelo Aspose.Slides ao renderizar.

## **Adicionar Extrusão e Profundidade**

A extrusão faz uma forma parecer espessa ao estendê‑la por trás da face frontal. No PowerPoint, o controle de profundidade define essa espessura visível, e o controle de cor define a cor das faces laterais.

![Controles de profundidade do PowerPoint mapeados para as propriedades cor da extrusão e altura da extrusão](img_02_02.png)

Use [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) para definir a espessura e [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) para acessar a cor lateral. Este exemplo dá ao retângulo uma extrusão de 100 pontos com lados roxos e rotaciona a câmera para revelar sua espessura. Ele configura a forma na memória sem salvar um arquivo:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

O método [ThreeDFormat.setDepth](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#setDepth) define a profundidade de uma forma 3D. O método [setExtrusionHeight](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) controla a altura do efeito de extrusão, como mostrado neste exemplo.

## **Usar Preenchimentos em Gradiente ou Imagem com Efeitos 3D**

A formatação 3D é independente do preenchimento da forma. Você pode aplicar uma cor sólida, gradiente, padrão ou preenchimento de imagem à face frontal e ainda usar a mesma câmera, luz, material e configurações de extrusão.

Este exemplo aplica um gradiente azul‑para‑laranja à face frontal e uma cor laranja escura à extrusão de 150 pontos. As paradas do gradiente em 0 e 100 marcam o início e o fim do gradiente. Os valores de rotação da câmera estão em graus. O slide é renderizado para uma imagem PNG em duas vezes suas dimensões padrão:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

A saída renderizada mantém o gradiente na face frontal e renderiza a extrusão separadamente:

![Retângulo 3D renderizado com preenchimento em gradiente azul-para-laranja e extrusão laranja](img_02_03.png)

Para usar um preenchimento de imagem, adicione a imagem à apresentação e atribua‑a ao preenchimento da forma. Este exemplo requer um arquivo existente chamado "image.jpg" no diretório de trabalho. Ele estica a foto para preencher o retângulo, aplica uma extrusão de 150 pontos e define a rotação da câmera em graus. Ele configura a forma na memória sem salvar ou renderizar um arquivo:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

A imagem é renderizada na face frontal, enquanto a extrusão é renderizada como a superfície lateral 3D:

![Retângulo 3D renderizado com preenchimento fotográfico na face frontal e extrusão laranja](img_02_04.png)

## **Aplicar Formatação 3D ao Texto**

A formatação 3D da forma afeta o corpo da forma. A formatação 3D do texto afeta o quadro de texto. Isso é útil para efeitos semelhantes ao WordArt, onde as próprias letras precisam de extrusão, material, iluminação e configurações de câmera.

O exemplo a seguir cria texto com um padrão de grade laranja‑e‑branco, aplica um arco ascendente e configura as definições 3D através de [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). A altura da extrusão e a profundidade estão em pontos, e a rotação da luz está em graus. O preenchimento e o contorno da forma estão ocultos para que apenas o texto fique visível. O exemplo renderiza uma imagem PNG em duas vezes as dimensões padrão do slide e salva a apresentação como PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O texto é renderizado como letras 3D curvadas e extrudadas:

![Texto 3D renderizado com transformação WordArt arqueada, preenchimento em padrão laranja e extrusão escura](img_02_05.png)

## **Manter Texto Plano em uma Forma 3D**

Para manter o texto legível preservando a aparência 3D da forma, chame [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) através de [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). Quando o valor é `true`, o texto permanece fora da cena 3D. Quando é `false`, o texto participa da cena e segue sua orientação 3D.

Esta configuração não remove a formatação 3D da forma: sua câmera, iluminação, material e extrusão permanecem configurados através de [Shape.getThreeDFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getThreeDFormat). Também difere da rotação comum. [Shape.setRotation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#setRotation) rotaciona a forma no plano do slide, enquanto [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) controla a rotação personalizada do texto dentro de sua caixa delimitadora. Manter o texto fora da cena 3D não redefine nenhum desses ângulos.

O exemplo autônomo a seguir cria um retângulo azul com texto e o clona ao lado do original. Ambas as formas têm a mesma formatação 3D; apenas a configuração de texto difere: `false` à esquerda e `true` à direita. Os ângulos da câmera estão em graus, e a altura da extrusão é de 40 pontos. O exemplo salva a apresentação como PPTX e renderiza o slide de comparação para PNG em duas vezes suas dimensões padrão.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

À esquerda, o texto segue a orientação 3D. À direita, ele permanece plano e mais fácil de ler. Ambos os retângulos mantêm a mesma extrusão visível e orientação 3D.

![Retângulos 3D lado a lado: texto segue a orientação 3D à esquerda e permanece plano à direita](keep_text_flat.png)

## **Comportamento de Exportação e Renderização**

Aspose.Slides preserva a formatação 3D ao salvar em formatos PowerPoint como PPTX. Ao renderizar ou exportar para formatos de layout fixo, a cena 3D é rasterizada ou desenhada na saída como um resultado 2D. Isso se aplica quando você renderiza slides para [PNG](/slides/pt/nodejs-java/convert-powerpoint-to-png/), exporta para [PDF](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/), exporta para [HTML](/slides/pt/nodejs-java/convert-powerpoint-to-html/), ou gera quadros para [conversão de vídeo](/slides/pt/nodejs-java/convert-powerpoint-to-video/).

- Imagens e PDFs exportados não são interativos. O objeto não pode ser girado pelo visualizador após a exportação.
- A aparência final depende da combinação de câmera, rig de luz, material, extrusão, preenchimento e dimensionamento do slide.
- Se precisar inspecionar valores herdados ou baseados em tema, leia as [effective shape properties](/slides/pt/nodejs-java/shape-effective-properties/).
- Alguns formatos de saída não podem armazenar a formatação 3D editável do PowerPoint. Nesses formatos, o resultado visual é renderizado ao invés de preservado como configurações 3D editáveis.

## **FAQ**

**O Aspose.Slides pode criar apresentações 3D interativas?**

Aspose.Slides cria e renderiza efeitos 3D do PowerPoint para formas e texto. Ele não transforma imagens, PDFs ou páginas HTML exportadas em cenas 3D interativas que o visualizador possa girar. No PPTX, a formatação 3D permanece editável no PowerPoint onde o formato a suporta.

**Qual é a diferença entre um modelo 3D e um efeito 3D?**

Um modelo 3D é um objeto 3D separado inserido em uma apresentação. Um efeito 3D é formatação aplicada a uma forma ou texto padrão do PowerPoint, como rotação, extrusão, chanfrado, iluminação e material. Este artigo cobre efeitos 3D.

**Quais configurações são necessárias para uma forma 3D visível?**

No mínimo, defina uma rotação de câmera e either extrusão ou profundidade. Na prática, também configure um rig de luz e material para que as faces renderizadas tenham realces e sombras claros.

**Posso aplicar efeitos 3D tanto a formas quanto a texto?**

Sim. Use [Shape.getThreeDFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getThreeDFormat) para o corpo da forma e [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) para o texto.

**Os efeitos 3D aparecerão ao exportar para imagens, PDF, HTML ou quadros de vídeo?**

Sim. Aspose.Slides renderiza os efeitos 3D ao produzir imagens de slides, saída PDF, saída HTML e quadros usados para conversão de vídeo. A saída exportada contém a aparência renderizada, não um objeto 3D editável.

**Posso ler os valores finais de 3D após a herança e as configurações de tema serem aplicadas?**

Sim. Use as APIs de formatação efetiva descritas em [Shape Effective Properties](/slides/pt/nodejs-java/shape-effective-properties/) para ler a câmera final, rig de luz, chanfrado e valores 3D relacionados.