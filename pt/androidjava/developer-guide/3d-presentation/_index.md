---
title: Criar efeitos 3D em apresentações no Android
linktitle: Apresentação 3D
type: docs
weight: 232
url: /pt/androidjava/3d-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aplique e renderize efeitos 3D para formas e texto do PowerPoint no Android com Aspose.Slides. Configure câmera, iluminação, material, extrusão, preenchimentos e texto 3D."
---
## **Visão geral**

Aspose.Slides for Android via Java pode criar, editar, preservar e renderizar a formatação 3D no estilo PowerPoint para formas e texto. Este artigo aborda efeitos 3D como rotação, extrusão, chanfrados, iluminação, material, preenchimentos em gradiente ou imagem e texto 3D.

{{% alert color="primary" %}}

Este artigo trata de efeitos de formatação 3D em formas e texto do PowerPoint. Não se trata de inserção ou edição de arquivos de modelo 3D independentes. Ao exportar um slide para imagem, PDF ou HTML, o Aspose.Slides renderiza esses efeitos 3D na saída 2D exportada.

{{% /alert %}}

## **Conceitos de Formatação 3D**

Use o método [IShape.getThreeDFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) para aplicar formatação 3D a uma forma. O método devolve um [IThreeDFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/), que controla a cena 3D para aquela forma.

Para texto, use o método [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Ele aplica formatação 3D ao quadro de texto em vez do corpo da forma.

Os membros de API mais importantes são:

| Membro da API | O que controla | Quando usar |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Ponto de vista, tipo de câmera predefinido, rotação, zoom e perspectiva. | Rotacionar o objeto no espaço 3D ou combinar com um predefinido de rotação 3D do PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Predefinição de luz, direção e rotação da luz. | Alterar como realces e sombras aparecem na superfície 3D. |
| [getMaterial](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) e [setMaterial](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Material da superfície, como liso, fosco, plástico ou metal. | Fazer a mesma geometria parecer mais lisa, suave, brilhante ou metálica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) e [setExtrusionHeight](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Distância que a forma se estende para trás a partir de sua face frontal. | Transformar uma forma plana em um objeto 3D visivelmente espesso. |
| [getExtrusionColor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Cor das faces laterais extrudidas. | Tornar a profundidade visível ou coordenar a cor lateral com o preenchimento frontal. |
| [getDepth](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#getDepth--) e [setDepth](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Profundidade 3D adicional usada pela formatação 3D do PowerPoint. | Ajustar finamente a profundidade para formas ou texto, especialmente junto com configurações de chanfrado e material. |
| [getBevelTop](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) e [getBevelBottom](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Bordas elevadas ou arredondadas nas faces frontal e traseira. | Adicionar um contorno suavizado ou moldado em vez de uma face plana e afiada. |
| [getContourColor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), e [setContourWidth](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Contorno ao redor do objeto 3D. | Evidenciar o limite do objeto na saída renderizada. |

## **Criar uma Forma 3D**

Uma forma normalmente precisa de quatro tipos de configurações antes de parecer convincentemente 3D:

- Configurações de câmera, pois a vista frontal padrão pode ocultar a extrusão.
- Configurações de luz, pois a iluminação torna as faces e laterais legíveis.
- Configurações de material, pois a superfície afeta como a luz é renderizada.
- Configurações de extrusão ou profundidade, pois uma forma plana precisa de espessura.

O exemplo a seguir cria um retângulo, adiciona texto à sua face frontal, aplica formatação 3D, salva a apresentação como PPTX e renderiza o slide para uma imagem PNG.

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

A imagem do slide renderizado mostra o retângulo como um bloco 3D espesso:

![Retângulo azul 3D renderizado com texto 3D branco na face frontal](img_01_01.png)

## **Girar uma Forma com a Câmera**

No PowerPoint, a rotação 3D é configurada no painel de Rotação 3-D. Os valores de rotação X, Y e Z correspondem à rotação que você define através da API de câmera.

![Painel de Rotação 3-D do PowerPoint com valores de rotação X, Y e Z destacados](img_02_01.png)

No Aspose.Slides, defina o tipo de câmera e a rotação através de [IThreeDFormat.getCamera](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Use a câmera quando precisar mudar como o visualizador vê o objeto. Ela não altera a geometria 2D da forma no slide. Ela altera o ponto de vista 3D usado pelo PowerPoint e pelo Aspose.Slides ao renderizar.

## **Adicionar Extrusão e Profundidade**

A extrusão faz uma forma parecer espessa ao estendê‑la atrás da face frontal. No PowerPoint, o controle de profundidade define essa espessura visível, e o controle de cor define a cor das faces laterais.

![Controles de profundidade do PowerPoint mapeados para propriedades de cor de extrusão e altura de extrusão](img_02_02.png)

Defina [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) para a espessura e [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) para a cor lateral:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

Use [IThreeDFormat.setDepth](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) quando precisar trabalhar diretamente com o valor de profundidade do PowerPoint ou combinar profundidade com chanfrado, material e efeitos de texto. Em muitos cenários de forma, `setExtrusionHeight` é a configuração mais clara porque expressa diretamente a extrusão visível.

## **Usar Preenchimentos em Gradiente ou Imagem com Efeitos 3D**

A formatação 3D é independente do preenchimento da forma. Você pode aplicar uma cor sólida, gradiente, padrão ou preenchimento de imagem à face frontal e ainda usar as mesmas configurações de câmera, luz, material e extrusão.

Este exemplo aplica um preenchimento em gradiente à forma e uma cor de extrusão mais escura às laterais:

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

A saída renderizada mantém o gradiente na face frontal e renderiza a extrusão separadamente:

![Retângulo 3D renderizado com preenchimento em gradiente azul‑para‑laranja e extrusão laranja](img_02_03.png)

Para usar um preenchimento de imagem, adicione a imagem à apresentação e atribua‑a ao preenchimento da forma:

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

A imagem é renderizada na face frontal, enquanto a extrusão é renderizada como a superfície lateral 3D:

![Retângulo 3D renderizado com preenchimento fotográfico na face frontal e extrusão laranja](img_02_04.png)

## **Aplicar Formatação 3D ao Texto**

A formatação 3D da forma afeta o corpo da forma. A formatação 3D do texto afeta o quadro de texto. Isso é útil para efeitos tipo WordArt, onde as próprias letras precisam de extrusão, material, iluminação e configurações de câmera.

O exemplo a seguir cria texto com preenchimento de padrão, aplica uma transformação WordArt e configurações 3D em [ITextFrameFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframeformat/):

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

O texto é renderizado como letras 3D curvas e extrudidas:

![Texto 3D renderizado com transformação WordArt arqueada, preenchimento de padrão laranja e extrusão escura](img_02_05.png)

## **Comportamento de Exportação e Renderização**

O Aspose.Slides preserva a formatação 3D ao salvar em formatos PowerPoint como PPTX. Ao renderizar ou exportar para formatos de layout fixo, a cena 3D é rasterizada ou desenhada na saída como um resultado 2D. Isso ocorre ao renderizar slides para [PNG](/slides/pt/androidjava/convert-powerpoint-to-png/), exportar para [PDF](/slides/pt/androidjava/convert-powerpoint-to-pdf/), exportar para [HTML](/slides/pt/androidjava/convert-powerpoint-to-html/) ou gerar quadros para [conversão de vídeo](/slides/pt/androidjava/convert-powerpoint-to-video/).

Tenha em mente os seguintes pontos:

- Imagens e PDFs exportados não são interativos. O objeto não pode ser girado pelo visualizador após a exportação.
- A aparência final depende da combinação de câmera, sistema de luz, material, extrusão, preenchimento e dimensionamento do slide.
- Se precisar inspecionar valores de formatação herdados ou baseados em tema, leia as [propriedades efetivas da forma](/slides/pt/androidjava/shape-effective-properties/).
- Alguns formatos de saída não podem armazenar formatação 3D editável do PowerPoint. Nesses formatos, o resultado visual é renderizado em vez de preservado como configurações 3D editáveis.

## **Perguntas Frequentes**

**O Aspose.Slides pode criar apresentações 3D interativas?**

O Aspose.Slides cria e renderiza efeitos 3D do PowerPoint para formas e texto. Não torna imagens, PDFs ou páginas HTML exportadas em cenários 3D interativos que um visualizador possa girar. No PPTX, a formatação 3D permanece editável no PowerPoint onde o formato a suporta.

**Qual a diferença entre um modelo 3D e um efeito 3D?**

Um modelo 3D é um objeto 3D separado inserido em uma apresentação. Um efeito 3D é formatação aplicada a uma forma ou texto PowerPoint regular, como rotação, extrusão, chanfrado, iluminação e material. Este artigo cobre efeitos 3D.

**Quais configurações são necessárias para que uma forma 3D seja visível?**

No mínimo, defina uma rotação de câmera e extrusão ou profundidade. Na prática, também configure um sistema de luz e material para que as faces renderizadas tenham realces e sombras claros.

**Posso aplicar efeitos 3D tanto a formas quanto a texto?**

Sim. Use [IShape.getThreeDFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) para o corpo da forma e [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) para o texto.

**Os efeitos 3D aparecerão ao exportar para imagens, PDF, HTML ou quadros de vídeo?**

Sim. O Aspose.Slides renderiza os efeitos 3D ao gerar imagens de slides, saída PDF, saída HTML e quadros usados na conversão para vídeo. A saída exportada contém a aparência renderizada, não um objeto 3D editável.

**Posso ler os valores finais 3D após a aplicação de herança e definições de tema?**

Sim. Use as APIs de formatação efetiva descritas em [Propriedades Efetivas da Forma](/slides/pt/androidjava/shape-effective-properties/) para ler a câmera final, sistema de luz, chanfrado e valores 3D relacionados.