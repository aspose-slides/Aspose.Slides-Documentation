---
title: Obter propriedades efetivas de formas de apresentações em PHP
linktitle: Propriedades Efetivas
type: docs
weight: 50
url: /pt/php-java/shape-effective-properties/
keywords:
- propriedades de forma
- propriedades da câmera
- configuração de iluminação
- forma chanfrada
- quadro de texto
- estilo de texto
- altura da fonte
- formato de preenchimento
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda como usar Aspose.Slides para PHP via Java para distinguir a formatação local, herdada e efetiva de formas em apresentações do PowerPoint."
---
## **Compreender Propriedades Locais, Herdadas e Efetivas**

A formatação do PowerPoint pode vir de vários locais. O valor armazenado diretamente em um objeto é o seu **valor local**. Se esse valor não estiver definido, o PowerPoint procura nas fontes de formatação dos pais, como o padrão de parágrafo, um estilo de texto, um layout ou slide mestre, um tema ou os padrões ao nível da apresentação. Esses valores são **valores herdados**. O valor que resta depois que toda a hierarquia é resolvida é o **valor efetivo** — o valor usado para renderizar o objeto.

Por exemplo, uma porção de texto pode não definir sua própria altura de fonte. Seu valor local [getFontHeight](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/) então é `NAN`, o que significa “não definido aqui”. A porção pode herdar uma altura do seu parágrafo, do estilo de texto padrão da apresentação ou de outra fonte aplicável. Chamar [getEffective](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portionformat/geteffective/) no formato da porção devolve a altura final resolvida.

Use os dois tipos de dados de formatação para finalidades diferentes:

- Leia ou altere um objeto de formato local, como [PortionFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portionformat/), quando precisar controlar onde um valor está definido.
- Leia um objeto de dados efetivo, como os [dados retornados por PortionFormat.getEffective](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portionformat/geteffective/), quando precisar do resultado final renderizado. Dados efetivos são somente leitura.

Antes de executar os exemplos, [instale Aspose.Slides for PHP via Java](/slides/pt/php-java/installation/).

## **Comparar Valores Locais, Herdados e Efetivos**

O exemplo completo a seguir cria uma forma e aplica alturas de fonte nos níveis de apresentação, parágrafo e porção. Cada etapa imprime os valores definidos nesses níveis e o valor efetivo resultante para a mesma porção de texto. Também demonstra por que os dados efetivos devem ser lidos novamente após alterações de formatação.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // Ler dados efetivos após as alterações anteriores.
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // Definir valores herdados em dois níveis diferentes.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // Um valor local na porção substitui ambos os valores herdados.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // Alterar um valor herdado não substitui um valor local existente.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // Limpar o valor local. A porção agora herda novamente do parágrafo.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // Limpar o valor do parágrafo. O padrão da apresentação agora fornece o resultado.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A prioridade neste exemplo é a formatação local da porção, seguida pela formatação do parágrafo e, por fim, o padrão da apresentação. Outros objetos podem ter cadeias de herança diferentes, mas o princípio é o mesmo: um valor explícito mais específico vence, e [getEffective](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portionformat/geteffective/) devolve o resultado final.

## **Obter Propriedades de Texto Efetivas**

A formatação de texto está dividida em vários objetos:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/geteffective/) resolve propriedades do quadro de texto, como margens, âncora, ajuste automático e direção vertical do texto.
- [TextStyle.getEffective](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textstyle/geteffective/) resolve a formatação de parágrafo para cada nível de estilo de texto.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/geteffective/) resolve propriedades de parágrafo, como alinhamento, recuo e marcadores.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portionformat/geteffective/) resolve propriedades de caractere, como altura de fonte, tipo de fonte, cor, negrito e itálico.

Para o próximo exemplo, `text-formatting.pptx` deve conter ao menos um slide e um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) com um quadro de texto não vazio. O AutoShape pode aparecer em qualquer posição na coleção de formas; o código procura um objeto adequado e o valida antes do uso.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Obter Propriedades 3D Efetivas**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/geteffective/) devolve um objeto de dados efetivo que agrupa todas as configurações 3D resolvidas. Seus métodos [getCamera](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/geteffective/) e [getBevelBottom](https://reference.aspose.com/slides/pt/php-java/aspose.slides/threedformat/geteffective/) expõem os respectivos dados efetivos. Ler essas configurações relacionadas em conjunto facilita a compreensão da aparência 3D final de uma forma.

Para este exemplo, `shape-3d.pptx` deve conter ao menos uma forma no primeiro slide. Aplique configurações de câmera 3D, iluminação ou chanfradura nessa forma se quiser que a saída contenha valores diferentes dos padrões.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Obter Formatação de Tabela Efetiva**

A formatação de tabela pode vir do estilo da tabela e de formatações aplicadas a toda a tabela, a uma coluna, a uma linha ou a uma célula individual. Em conflitos entre preenchimentos definidos explicitamente, a prioridade é célula, linha, coluna e, por fim, toda a tabela. O formato efetivo de uma célula é o formato final usado para desenhá‑la.

Para este exemplo, `table-formatting.pptx` deve conter ao menos uma tabela no primeiro slide. A tabela deve ter ao menos uma linha e uma coluna. O código procura um [Table](https://reference.aspose.com/slides/pt/php-java/aspose.slides/table/) em vez de supor que `getShapes()->get_Item(0)` seja uma tabela.

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Se precisar da cor e não apenas do tipo de preenchimento, primeiro verifique o valor efetivo de [getFillType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fillformat/geteffective/), e então leia o método correspondente a esse tipo — por exemplo, [getSolidFillColor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fillformat/geteffective/) para um preenchimento sólido.

## **Ler Dados Efetivos Novamente Após Alterações**

Dados efetivos descrevem a hierarquia de formatação no momento em que são resolvidos. Chame `getEffective` novamente após alterar qualquer coisa que possa participar dessa hierarquia, incluindo:

- a formatação local do objeto;
- padrões de parágrafo ou quadro de texto;
- um estilo de tabela, tabela, coluna, linha ou formato de célula;
- formatação de layout ou slide mestre;
- dados de tema ou padrões ao nível da apresentação;
- o layout ou mestre atribuído a um slide.

Não mantenha um objeto de dados efetivo como um instantâneo permanente. Aspose.Slides pode armazenar em cache alguns dados efetivos internamente, e uma chamada posterior a `getEffective` pode atualizar esses dados. Se precisar comparar valores antes e depois de uma alteração, copie os valores escalares que precisar — como altura de fonte, cor, alinhamento ou largura da chanfradura—para suas próprias variáveis antes de efetuar a mudança.

Para mudar um valor, atualize o objeto de formato local apropriado e então chame `getEffective` para verificar o resultado. Objetos de dados efetivos são somente leitura.

## **FAQ**

**Como posso saber qual nível forneceu um valor efetivo?**

Dados efetivos contêm o valor final, não sua origem. Inspecione os objetos locais aplicáveis a partir do nível mais específico para fora. Para texto, isso pode incluir a porção, parágrafo, quadro de texto, layout, mestre, tema e padrões da apresentação. Valores indefinidos como `NAN` ou `null` indicam que a busca continua em outro nível.

**O que acontece quando nenhum nível define uma propriedade?**

Aspose.Slides resolve o padrão apropriado do PowerPoint ou da biblioteca. Esse valor resolvido aparece nos dados efetivos mesmo que nenhum objeto local o defina explicitamente.

**Por que um valor efetivo às vezes é igual ao valor local?**

O valor local venceu o cálculo de herança. Isso é esperado quando a propriedade está explicitamente definida no objeto e nenhuma regra mais específica a sobrescreve.

**Quando devo usar dados locais em vez de dados efetivos?**

Use dados locais para inspecionar ou editar um nível específico de formatação. Use dados efetivos quando precisar da aparência final após herança, regras de tema e estilos aplicáveis terem sido resolvidos. O [exemplo completo de comparação](#compare-local-inherited-and-effective-values) demonstra ambos no mesmo fluxo de trabalho.