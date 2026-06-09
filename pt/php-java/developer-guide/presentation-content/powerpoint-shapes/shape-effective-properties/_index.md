---
title: Obter Propriedades Efetivas de Forma de Apresentações em PHP
linktitle: Propriedades Efetivas
type: docs
weight: 50
url: /pt/php-java/shape-effective-properties/
keywords:
- propriedades de forma
- propriedades de câmera
- conjunto de luzes
- forma chanfrada
- quadro de texto
- estilo de texto
- altura da fonte
- formato de preenchimento
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Descubra como o Aspose.Slides for PHP via Java calcula e aplica propriedades efetivas de forma para renderização precisa do PowerPoint."
---
## **Visão geral**

Este tópico explica a diferença entre propriedades **locais** e **efetivas**. Valores locais são valores que são definidos diretamente em um nível específico de formatação, como:

1. Propriedades de porção em um slide.
1. Estilos de texto de forma protótipo em um layout ou slide mestre, quando a forma do quadro de texto da porção tem um.
1. Configurações globais de texto em uma apresentação.

Valores locais podem ser definidos ou omitidos em qualquer nível. Quando o Aspose.Slides precisa da formatação final “como renderizada”, ele resolve a cadeia de herança e retorna valores **efetivos**. Você pode obtê‑los chamando o método `getEffective` no objeto de formato local.

O exemplo a seguir demonstra como obter valores efetivos. Assume‑se que a primeira forma no primeiro slide seja um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) com um quadro de texto e ao menos uma porção.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Os dados de formatação efetiva representam a formatação calculada atual após a aplicação da herança. Na implementação atual, alguns objetos de dados efetivos retornados por métodos como [PortionFormat.getEffective](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portionformat/geteffective/) podem ser armazenados em cache internamente. Chamar `getEffective` novamente após alterar a formatação pai ou herdada pode atualizar os dados em cache, e um objeto obtido anteriormente pode não representar mais o estado anterior. Se precisar preservar valores efetivos para reutilização posterior, copie as propriedades necessárias, como altura da fonte, cor de preenchimento, estilo de fonte ou alinhamento, para seu próprio objeto de dados.
{{% /alert %}}

## **Obter propriedades efetivas de uma câmera**

O Aspose.Slides permite obter propriedades efetivas de uma câmera. Os dados efetivos retornados por [ThreeDFormat.getEffective](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/geteffective/) contêm as propriedades finais da câmera para um [ThreeDFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/).

O exemplo de código a seguir demonstra como obter propriedades efetivas para a câmera. Assume‑se que a primeira forma no primeiro slide possua formatação 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Obter propriedades efetivas de um Light Rig**

O Aspose.Slides permite obter propriedades efetivas de um Light Rig. Os dados efetivos retornados por [ThreeDFormat.getEffective](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/geteffective/) contêm as propriedades finais do conjunto de luzes para um [ThreeDFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/).

O exemplo de código a seguir demonstra como obter propriedades efetivas para o conjunto de luzes. Assume‑se que a primeira forma no primeiro slide possua formatação 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Obter propriedades efetivas de um Bevel Shape**

O Aspose.Slides permite obter propriedades efetivas de um Bevel Shape. Os dados efetivos retornados por [ThreeDFormat.getEffective](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/geteffective/) contêm as propriedades finais de relevo de faces para um [ThreeDFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/).

O exemplo de código a seguir demonstra como obter propriedades efetivas para o chanfro superior de uma forma. Assume‑se que a primeira forma no primeiro slide possua formatação 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Obter propriedades efetivas de um quadro de texto**

Usando o Aspose.Slides, você pode obter propriedades efetivas de um quadro de texto. Os dados efetivos retornados por [TextFrameFormat.getEffective](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/geteffective/) contêm propriedades de formatação do quadro de texto.

O exemplo de código a seguir demonstra como obter propriedades de formatação efetiva do quadro de texto. Assume‑se que a primeira forma no primeiro slide seja um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) com um quadro de texto.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Obter propriedades efetivas de um estilo de texto**

Usando o Aspose.Slides, você pode obter propriedades efetivas de um estilo de texto. Os dados efetivos retornados por [TextStyle.getEffective](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textstyle/geteffective/) contêm propriedades de estilo de texto.

O exemplo de código a seguir demonstra como obter propriedades de estilo de texto efetivas. Assume‑se que a primeira forma no primeiro slide seja um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) com um quadro de texto.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Obter o valor de altura de fonte efetiva**

Usando o Aspose.Slides, você pode obter a altura de fonte efetiva. O código a seguir demonstra como a altura de fonte efetiva de uma porção muda após valores locais de altura de fonte serem definidos em diferentes níveis da estrutura da apresentação.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Obter o formato de preenchimento efetivo para uma tabela**

Usando o Aspose.Slides, você pode obter formatação de preenchimento efetiva para diferentes partes de uma tabela. Os dados efetivos retornados pelos objetos de formato contêm propriedades de [FillFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fillformat/). A formatação de célula tem prioridade maior que a formatação de linha, a formatação de linha tem prioridade maior que a formatação de coluna e a formatação de coluna tem prioridade maior que a formatação de tabela completa.

Como resultado, as propriedades efetivas de [CellFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cellformat/) são usadas para desenhar a célula da tabela. O exemplo de código a seguir demonstra como obter formatação de preenchimento efetiva para diferentes partes da tabela. Assume‑se que a primeira forma no primeiro slide seja uma [Table](https://reference.aspose.com/slides/pt/php-java/aspose.slides/table/).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**`getEffective` retorna um instantâneo?**

Nem sempre. Dados efetivos representam a formatação calculada após a aplicação da herança, mas alguns objetos de dados efetivos podem ser armazenados em cache internamente. Uma chamada subsequente a `getEffective` pode recalcular a formatação e atualizar os dados em cache, de modo que um objeto obtido anteriormente não deve ser tratado como um instantâneo durável.

**Quando devo ler as propriedades efetivas novamente?**

Chame `getEffective` novamente após alterar a formatação local, estilos pai, formatação de layout, formatação mestre ou padrões ao nível da apresentação. A chamada seguinte reavalia a hierarquia de formatação e retorna o resultado efetivo atual.

**Alterar ou remover um slide de layout/mestre afeta propriedades efetivas que já foram obtidas?**

Sim, mas a alteração só se reflete na próxima chamada a `getEffective`. Se uma fonte de formatação pai for alterada ou removida, os dados efetivos obtidos anteriormente podem ficar obsoletos. Quando `getEffective` for chamado novamente, o Aspose.Slides reavalia a árvore de formatação e as fontes, cores, tamanhos ou outros valores resultantes podem mudar.

**Posso modificar valores através de objetos de dados efetivos?**

Não. Objetos de dados efetivos expõem valores calculados. Faça alterações nos objetos de formatação local e, em seguida, obtenha os valores efetivos novamente.

**O que acontece se uma propriedade não estiver definida no nível da forma, nem no layout/mestre, nem nas configurações globais?**

O valor efetivo é determinado pelo mecanismo padrão, que inclui valores padrão do PowerPoint e do Aspose.Slides. Esse valor resolvido passa a fazer parte dos dados efetivos atuais.

**A partir de um valor de fonte efetivo, consigo saber qual nível forneceu o tamanho ou a família tipográfica?**

Não diretamente. Dados efetivos retornam o valor final. Para descobrir a origem, verifique os valores locais na porção, parágrafo, quadro de texto e estilos de texto nos níveis de layout, mestre e apresentação para identificar onde a primeira definição explícita aparece.

**Por que valores efetivos às vezes parecem idênticos aos locais?**

Porque o valor local acabou sendo final (nenhuma herança de nível superior foi necessária). Nesses casos, o valor efetivo coincide com o local.

**Quando devo usar propriedades efetivas e quando devo trabalhar apenas com as locais?**

Use dados efetivos quando precisar do resultado “como renderizado” após toda a herança ser aplicada, como para alinhar cores, recuos ou tamanhos. Se precisar preservar esses valores independentemente de mudanças de formatação posteriores, copie as propriedades necessárias para seu próprio objeto. Se precisar alterar a formatação em um nível específico, modifique as propriedades locais e, se necessário, leia os dados efetivos novamente para verificar o resultado.