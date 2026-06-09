---
title: Criar Efeitos 3D em Apresentações Usando PHP
linktitle: Apresentação 3D
type: docs
weight: 232
url: /pt/php-java/3d-presentation/
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
- PHP
- Aspose.Slides
description: "Aplicar e renderizar efeitos 3D para formas e texto do PowerPoint em PHP com Aspose.Slides. Configurar câmera, iluminação, material, extrusão, preenchimentos e texto 3D."
---
## **Visão Geral**

Aspose.Slides for PHP via Java pode criar, editar, preservar e renderizar formatação 3D ao estilo PowerPoint para formas e texto. Este artigo aborda efeitos 3D como rotação, extrusão, chanfrados, iluminação, material, preenchimentos gradiente ou de imagem e texto 3D.

{{% alert color="primary" %}}

Este artigo trata de efeitos de formatação 3D em formas e texto do PowerPoint. Não se refere à inserção ou edição de arquivos de modelo 3D autônomos. Quando você exporta um slide para imagem, PDF ou HTML, o Aspose.Slides renderiza esses efeitos 3D na saída 2D exportada.

{{% /alert %}}

## **Conceitos de Formatação 3D**

Use a classe [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/) e seu método [Shape::getThreeDFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getThreeDFormat--) para aplicar formatação 3D a uma forma. O método devolve um objeto [ThreeDFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/), que controla a cena 3D para essa forma.

Para texto, use a classe [TextFrameFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/) e seu método [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/#getThreeDFormat--) . Isso aplica formatação 3D ao quadro de texto em vez do corpo da forma.

As configurações mais importantes são:

| Método ou configuração | O que controla | Quando usar |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/#getCamera--) | Ponto de vista, tipo de câmera predefinido, rotação, zoom e perspectiva. | Rotacionar o objeto no espaço 3D ou usar um predefinido de rotação 3D do PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/#getLightRig--) | Predefinição de luz, direção e rotação da luz. | Alterar como realces e sombras aparecem na superfície 3D. |
| [setMaterial](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Material da superfície, como liso, fosco, plástico ou metal. | Fazer a mesma geometria parecer mais plana, suave, brilhante ou metálica. |
| [setExtrusionHeight](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Quão longe a forma se estende para trás a partir da face frontal. | Transformar uma forma plana em um objeto 3D visivelmente espesso. |
| [getExtrusionColor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Cor dos lados extrudidos. | Tornar a profundidade visível ou coordenar a cor lateral com o preenchimento frontal. |
| [setDepth](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/#setDepth-double-) | Profundidade 3D adicional usada pela formatação 3D do PowerPoint. | Ajustar a profundidade de formas ou texto, especialmente junto com configurações de chanfrado e material. |
| [getBevelTop](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/#getBevelTop--) e [getBevelBottom](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/#getBevelBottom--) | Bordas elevadas ou arredondadas nas faces frontal e traseira. | Adicionar uma borda suavizada ou moldada em vez de uma face plana e afiada. |
| [getContourColor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/#getContourColor--) e [setContourWidth](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Contorno ao redor do objeto 3D. | Realçar o limite do objeto na saída renderizada. |

## **Criar uma Forma 3D**

Uma forma geralmente precisa de quatro tipos de configuração antes de parecer convincentemente 3D:

- Configurações de câmera, pois a visualização frontal padrão pode ocultar a extrusão.
- Configurações de luz, pois a iluminação torna as faces e lados legíveis.
- Configurações de material, pois a superfície influencia como a luz é renderizada.
- Configurações de extrusão ou profundidade, pois uma forma plana precisa de espessura.

O exemplo a seguir cria um retângulo, adiciona texto à sua face frontal, aplica formatação 3D, salva a apresentação como PPTX e renderiza o slide para uma imagem PNG.

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A imagem do slide renderizado mostra o retângulo como um bloco 3D espesso:

![Retângulo 3D azul renderizado com texto 3D branco na face frontal](img_01_01.png)

## **Rotacionar uma Forma com a Câmera**

No PowerPoint, a rotação 3D é configurada no painel de Rotação 3-D. Os valores de rotação X, Y e Z correspondem à rotação que você define por meio da API de câmera.

![Painel de rotação 3-D do PowerPoint com valores X, Y e Z destacados](img_02_01.png)

No Aspose.Slides, defina o tipo de câmera e a rotação através de [ThreeDFormat::getCamera](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/#getCamera--):

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

Use a câmera quando precisar mudar como o observador vê o objeto. Ela não altera a geometria 2D da forma no slide. Ela altera o ponto de vista 3D usado pelo PowerPoint e pelo Aspose.Slides ao renderizar.

## **Adicionar Extrusão e Profundidade**

A extrusão faz uma forma parecer espessa ao estendê‑la atrás da face frontal. No PowerPoint, o controle de profundidade define essa espessura visível, e o controle de cor define a cor das faces laterais.

![Controles de profundidade do PowerPoint mapeados para as propriedades de cor de extrusão e altura de extrusão](img_02_02.png)

Defina [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) para a espessura e [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/#getExtrusionColor--) para a cor lateral:

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

Use [ThreeDFormat::setDepth](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/#setDepth-double-) quando precisar trabalhar diretamente com o valor de profundidade do PowerPoint ou combinar profundidade com chanfrado, material e efeitos de texto. Na maioria dos cenários de forma, `setExtrusionHeight` é a configuração mais clara porque expressa diretamente a extrusão visível.

## **Usar Preenchimentos Gradiente ou de Imagem com Efeitos 3D**

A formatação 3D é independente do preenchimento da forma. Você pode aplicar uma cor sólida, gradiente, padrão ou preenchimento de imagem à face frontal e ainda usar as mesmas configurações de câmera, luz, material e extrusão.

Este exemplo aplica um preenchimento gradiente à forma e uma cor de extrusão mais escura aos lados:

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

A saída renderizada mantém o gradiente na face frontal e renderiza a extrusão separadamente:

![Retângulo 3D renderizado com preenchimento gradiente de azul a laranja e extrusão laranja](img_02_03.png)

Para usar um preenchimento de imagem, adicione a imagem à apresentação e atribua‑a ao preenchimento da forma:

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

A imagem é renderizada na face frontal, enquanto a extrusão é renderizada como superfície lateral 3D:

![Retângulo 3D renderizado com preenchimento fotográfico na face frontal e extrusão laranja](img_02_04.png)

## **Aplicar Formatação 3D ao Texto**

A formatação 3D de forma afeta o corpo da forma. A formatação 3D de texto afeta o quadro de texto. Isso é útil para efeitos tipo WordArt onde as próprias letras precisam de extrusão, material, iluminação e configurações de câmera.

O exemplo a seguir cria texto com preenchimento de padrão, aplica uma transformação WordArt e configura as definições 3D em [TextFrameFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/):

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O texto é renderizado como letras 3D curvadas e extrudidas:

![Texto 3D renderizado com transformação WordArt arqueada, preenchimento de padrão laranja e extrusão escura](img_02_05.png)

## **Comportamento de Exportação e Renderização**

O Aspose.Slides preserva a formatação 3D ao salvar em formatos do PowerPoint como PPTX. Ao renderizar ou exportar para formatos de layout fixo, a cena 3D é rasterizada ou desenhada na saída como um resultado 2D. Isso ocorre ao renderizar slides para [PNG](/slides/pt/php-java/convert-powerpoint-to-png/), exportar para [PDF](/slides/pt/php-java/convert-powerpoint-to-pdf/), exportar para [HTML](/slides/pt/php-java/convert-powerpoint-to-html/), ou gerar quadros para [conversão de vídeo](/slides/pt/php-java/convert-powerpoint-to-video/).

Tenha em mente estes pontos:

- Imagens e PDFs exportados não são interativos. O objeto não pode ser rotacionado pelo visualizador após a exportação.
- A aparência final depende da combinação de câmera, conjunto de luz, material, extrusão, preenchimento e dimensionamento do slide.
- Se precisar inspecionar valores de formatação herdados ou baseados em tema, leia as [propriedades efetivas da forma](/slides/pt/php-java/shape-effective-properties/).
- Alguns formatos de saída não podem armazenar formatação 3D editável do PowerPoint. Nesses formatos, o resultado visual é renderizado em vez de preservado como configurações 3D editáveis.

## **FAQ**

**O Aspose.Slides pode criar apresentações 3D interativas?**

O Aspose.Slides cria e renderiza efeitos 3D do PowerPoint para formas e texto. Ele não torna imagens, PDFs ou páginas HTML exportadas em cenas 3D interativas que o visualizador possa rotacionar. No PPTX, a formatação 3D permanece editável no PowerPoint onde o formato a suporta.

**Qual a diferença entre um modelo 3D e um efeito 3D?**

Um modelo 3D é um objeto 3D separado inserido na apresentação. Um efeito 3D é formatação aplicada a uma forma ou texto padrão do PowerPoint, como rotação, extrusão, chanfrado, iluminação e material. Este artigo trata de efeitos 3D.

**Quais configurações são necessárias para que uma forma 3D seja visível?**

No mínimo, defina uma rotação de câmera e either extrusão ou profundidade. Na prática, também configure um conjunto de luz e material para que as faces renderizadas tenham realces e sombras claros.

**Posso aplicar efeitos 3D tanto a formas quanto a texto?**

Sim. Use [Shape::getThreeDFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getThreeDFormat--) para o corpo da forma e [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/#getThreeDFormat--) para o texto.

**Os efeitos 3D aparecerão ao exportar para imagens, PDF, HTML ou quadros de vídeo?**

Sim. O Aspose.Slides renderiza os efeitos 3D ao produzir imagens de slides, saída PDF, saída HTML e quadros usados na conversão para vídeo. A saída exportada contém a aparência renderizada, não um objeto 3D editável.

**Posso ler os valores finais de 3D após a aplicação de herança e tema?**

Sim. Use as APIs de formatação efetiva descritas em [Propriedades Efetivas da Forma](/slides/pt/php-java/shape-effective-properties/) para ler a câmera final, conjunto de luz, chanfrado e valores 3D relacionados.