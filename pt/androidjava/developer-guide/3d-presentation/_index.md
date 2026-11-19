---
title: Criar efeitos 3D em apresentações no Android
linktitle: Apresentação 3D
type: docs
weight: 232
url: /pt/androidjava/3d-presentation/
keywords:
- PowerPoint 3D
- Apresentação 3D
- Rotação 3D
- Profundidade 3D
- Extrusão 3D
- Gradiente 3D
- Texto 3D
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aplicar e renderizar efeitos 3D para formas e texto do PowerPoint no Android com Aspose.Slides. Configurar câmera, iluminação, material, extrusão, preenchimentos e texto 3D."
---
## **Visão geral**

Aspose.Slides for Android via Java pode criar, editar, preservar e renderizar formatação 3D no estilo PowerPoint para formas e texto. Este artigo abrange efeitos 3D como rotação, extrusão, biséis, iluminação, material, preenchimentos gradiente ou de imagem e texto 3D.

{{% alert color="info" title="Note" %}}
Este artigo trata de efeitos de formatação 3D em formas e texto do PowerPoint. Não trata da inserção ou edição de arquivos de modelo 3D independentes. Quando você exporta um slide para imagem, PDF ou HTML, o Aspose.Slides renderiza esses efeitos 3D na saída 2D exportada.
{{% /alert %}}

## **Conceitos de Formatação 3D**

Use o método [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) para aplicar formatação 3D a uma forma. O método retorna [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/), que controla a cena 3D para essa forma.

Para texto, use o método [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Isso aplica formatação 3D ao quadro de texto em vez do corpo da forma.

Os membros de API mais importantes são:

| Membro da API | O que controla | Quando usar |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Ponto de vista, tipo de câmera pré‑definido, rotação, zoom e perspectiva. | Rotacionar o objeto no espaço 3D ou combinar com um preset de rotação 3D do PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Predefinição de luz, direção e rotação da luz. | Alterar como realces e sombras aparecem na superfície 3D. |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) e [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Material da superfície, como plano, fosco, plástico ou metal. | Fazer a mesma geometria parecer mais plana, suave, brilhante ou metálica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) e [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Quão longe a forma se estende para trás a partir de sua face frontal. | Transformar uma forma plana em um objeto 3D visivelmente espesso. |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Cor dos lados extrudados. | Tornar a profundidade visível ou coordenar a cor dos lados com o preenchimento frontal. |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) e [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Profundidade 3D adicional usada pela formatação 3D do PowerPoint. | Ajustar finamente a profundidade para formas ou texto, especialmente junto com configurações de bisel e material. |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) e [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Bordas levantadas ou arredondadas nas faces frontal e traseira. | Adicionar uma borda suavizada ou moldada em vez de uma face plana e afiada. |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) e [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) e [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Contorno ao redor do objeto 3D. | Destacar o limite do objeto na saída renderizada. |

## **Criar uma Forma 3D**

Uma forma normalmente precisa de quatro tipos de configurações antes de parecer convincentemente 3D:

- Configurações de câmera, porque a vista frontal padrão pode ocultar a extrusão.
- Configurações de luz, porque a iluminação torna as faces e lados legíveis.
- Configurações de material, porque a superfície afeta como a luz é renderizada.
- Configurações de extrusão ou profundidade, porque uma forma plana necessita de espessura.

O exemplo a seguir cria um retângulo, adiciona texto à sua face frontal e aplica formatação 3D. Os valores de rotação da câmera estão em graus, e a altura da extrusão é 100 pontos. O exemplo renderiza o slide para uma imagem PNG em duas vezes suas dimensões padrão e salva a apresentação como PPTX.

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

A imagem do slide renderizado mostra o retângulo como um bloco 3D espesso:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Rotacionar uma Forma com a Câmera**

No PowerPoint, a rotação 3D é configurada no painel 3‑D Rotation. Os valores de rotação X, Y e Z correspondem à rotação que você define através da API de câmera.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

No Aspose.Slides, acesse a câmera via [IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) . Este exemplo cria um retângulo, seleciona uma vista frontal ortográfica e define suas rotações X, Y e Z para 20, 30 e 40 graus, respectivamente. Ele configura a forma na memória sem salvar um arquivo:

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

Use a câmera quando precisar mudar como o visualizador vê o objeto. Ela não altera a geometria 2D da forma no slide. Ela altera o ponto de vista 3D usado pelo PowerPoint e pelo Aspose.Slides ao renderizar.

### **Copiar Orientação da Câmera de uma Forma Modelo**

Para combinar a orientação de uma forma modelo, leia seu preset de câmera com [getCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getCameraType--) e seus ângulos de rotação com [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getRotation--) . O exemplo abre `template.pptx` e copia a orientação da câmera da primeira forma do primeiro slide para a segunda forma. Ambas as formas já possuem iluminação 3D, e a segunda forma não tem rotação de câmera explícita.

Os ângulos estão em graus. O índice `0` é latitude, o índice `1` é longitude e o índice `2` é revolução. Passe‑os para [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) nessa ordem. Se a origem retornar `null`, ela não tem rotação explícita, portanto deixe os ângulos da segunda forma não definidos. Uma rotação explícita de `(0, 0, 0)` retorna três zeros e deve ser copiada.

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

Ao reabrir `camera-copy.pptx` no PowerPoint, a seta à direita tem o mesmo preset de câmera e rotação que o retângulo à esquerda. Ambas as formas usam a mesma iluminação e profundidade de extrusão.

![A blue 3D rectangle and a right arrow with matching camera orientation, viewed from above and to the right](camera-orientation.png)

## **Adicionar Extrusão e Profundidade**

A extrusão faz uma forma parecer espessa ao estendê‑la atrás da face frontal. No PowerPoint, o controle de profundidade define essa espessura visível, e o controle de cor define a cor das faces laterais.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Use [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) para definir a espessura e [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) para acessar a cor dos lados. Este exemplo dá ao retângulo uma extrusão de 100 pontos com lados roxos e rotaciona a câmera para revelar sua espessura. Ele configura a forma na memória sem salvar um arquivo:

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

O método [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) define a profundidade de uma forma 3D. O método [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) controla a altura do efeito de extrusão, como mostrado neste exemplo.

## **Usar Preenchimentos Gradiente ou de Imagem com Efeitos 3D**

A formatação 3D é independente do preenchimento da forma. Você pode aplicar uma cor sólida, gradiente, padrão ou preenchimento de imagem à face frontal e ainda usar as mesmas configurações de câmera, luz, material e extrusão.

Este exemplo aplica um gradiente azul‑para‑laranja à face frontal e uma cor laranja escura à extrusão de 150 pontos. As paradas do gradiente em 0 e 100 marcam o início e o fim do gradiente. Os valores de rotação da câmera estão em graus. O slide é renderizado para uma imagem PNG em duas vezes suas dimensões padrão:

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

A saída renderizada mantém o gradiente na face frontal e renderiza a extrusão separadamente:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Para usar um preenchimento de imagem, adicione a imagem à apresentação e atribua‑a ao preenchimento da forma. Este exemplo requer um arquivo existente chamado "image.jpg" no diretório de trabalho. Ele estica a foto para preencher o retângulo, aplica uma extrusão de 150 pontos e define a rotação da câmera em graus. Ele configura a forma na memória sem salvar ou renderizar um arquivo:

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

A foto é renderizada na face frontal, enquanto a extrusão é renderizada como a superfície lateral 3D:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Aplicar Formatação 3D ao Texto**

A formatação 3D da forma afeta o corpo da forma. A formatação 3D do texto afeta o quadro de texto. Isso é útil para efeitos tipo WordArt onde as próprias letras precisam de extrusão, material, iluminação e configurações de câmera.

O exemplo a seguir cria texto com um padrão de grade laranja‑e‑branco, aplica um arco ascendente e configura as definições 3D através de [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . A altura da extrusão e a profundidade estão em pontos, e a rotação da luz está em graus. O preenchimento e o contorno da forma são ocultados para que apenas o texto seja visível. O exemplo renderiza uma imagem PNG em duas vezes as dimensões padrão do slide e salva a apresentação como PPTX:

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

O texto é renderizado como letras curvas, extrudidas em 3D:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Manter o Texto Plano em uma Forma 3D**

Para manter o texto legível enquanto preserva a aparência 3D da forma, chame [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) através de [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--) . Quando o valor for `true`, o texto permanece fora da cena 3D. Quando for `false`, o texto participa da cena e segue sua orientação 3D.

Esta configuração não remove a formatação 3D da forma: sua câmera, iluminação, material e extrusão permanecem configurados através de [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) . Também difere da rotação comum. [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) rotaciona a forma no plano do slide, enquanto [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) controla a rotação personalizada do texto dentro de sua caixa delimitadora. Manter o texto fora da cena 3D não redefine nenhum desses ângulos.

O exemplo auto‑contido a seguir cria um retângulo azul com texto e o clona ao lado do original. Ambas as formas têm a mesma formatação 3D; apenas a configuração de texto difere: `false` à esquerda e `true` à direita. Os ângulos da câmera estão em graus, e a altura da extrusão é 40 pontos. O exemplo salva a apresentação como PPTX e renderiza o slide de comparação para PNG em duas vezes suas dimensões padrão.

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

À esquerda, o texto segue a orientação 3D. À direita, ele permanece plano e mais fácil de ler. Ambos os retângulos mantêm a mesma extrusão visível e orientação 3D.

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **Comportamento de Exportação e Renderização**

O Aspose.Slides preserva a formatação 3D ao salvar em formatos PowerPoint como PPTX. Ao renderizar ou exportar para formatos de layout fixo, a cena 3D é rasterizada ou desenhada na saída como um resultado 2D. Isso ocorre ao renderizar slides para [PNG](/slides/pt/androidjava/convert-powerpoint-to-png/), exportar para [PDF](/slides/pt/androidjava/convert-powerpoint-to-pdf/), exportar para [HTML](/slides/pt/androidjava/convert-powerpoint-to-html/), ou gerar quadros para [conversão de vídeo](/slides/pt/androidjava/convert-powerpoint-to-video/).

Tenha em mente:

- Imagens e PDFs exportados não são interativos. O objeto não pode ser rotacionado pelo visualizador após a exportação.
- A aparência final depende da combinação de câmera, rig de luz, material, extrusão, preenchimento e dimensionamento do slide.
- Se precisar inspecionar valores de formatação herdados ou baseados em tema, leia as [effective shape properties](/slides/pt/androidjava/shape-effective-properties/).
- Alguns formatos de saída não podem armazenar formatação 3D editável do PowerPoint. Nesses formatos, o resultado visual é renderizado em vez de preservado como configurações 3D editáveis.

## **FAQ**

**O Aspose.Slides pode criar apresentações 3D interativas?**

O Aspose.Slides cria e renderiza efeitos 3D do PowerPoint para formas e texto. Ele não torna imagens, PDFs ou páginas HTML exportados em cenas 3D interativas que o visualizador possa rotacionar. Em PPTX, a formatação 3D permanece editável no PowerPoint onde o formato a suporta.

**Qual é a diferença entre um modelo 3D e um efeito 3D?**

Um modelo 3D é um objeto 3D separado inserido em uma apresentação. Um efeito 3D é formatação aplicada a uma forma ou texto PowerPoint comum, como rotação, extrusão, bisel, iluminação e material. Este artigo trata de efeitos 3D.

**Quais configurações são necessárias para uma forma 3D visível?**

No mínimo, defina uma rotação de câmera e extrusão ou profundidade. Na prática, também configure um rig de luz e material para que as faces renderizadas tenham realces e sombras claros.

**Posso aplicar efeitos 3D tanto a formas quanto a texto?**

Sim. Use [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) para o corpo da forma e [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) para o texto.

**Os efeitos 3D aparecerão ao exportar para imagens, PDF, HTML ou quadros de vídeo?**

Sim. O Aspose.Slides renderiza os efeitos 3D ao gerar imagens de slides, saída PDF, saída HTML e quadros usados para conversão de vídeo. A saída exportada contém a aparência renderizada, não um objeto 3D editável.

**Posso ler os valores finais de 3D após a aplicação de herança e configurações de tema?**

Sim. Use as APIs de formatação efetiva descritas em [Shape Effective Properties](/slides/pt/androidjava/shape-effective-properties/) para ler a câmera final, rig de luz, bisel e valores 3D relacionados.