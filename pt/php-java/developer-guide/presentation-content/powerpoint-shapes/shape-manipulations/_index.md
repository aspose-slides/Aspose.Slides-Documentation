---
title: Gerenciar Formas de Apresentação em PHP
linktitle: Manipulação de Formas
type: docs
weight: 40
url: /pt/php-java/shape-manipulations/
keywords:
- forma do PowerPoint
- forma da apresentação
- forma no slide
- encontrar forma
- clonar forma
- remover forma
- ocultar forma
- alterar ordem da forma
- obter ID da forma interop
- texto alternativo da forma
- ponto de ajuste da forma
- ajuste predefinido de forma
- geometria da forma
- formatos de layout da forma
- forma como SVG
- forma para SVG
- alinhar forma
- inverter forma
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: Aprenda a identificar, ajustar, clonar, remover, ocultar, reorganizar, exportar, alinhar e inverter formas de apresentação com Aspose.Slides para PHP via Java.
---
## **Visão Geral**

Aspose.Slides for PHP via Java representa as formas em um slide como uma [ShapeCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/) ordenada. A coleção é tanto o local onde você encontra e modifica formas quanto a fonte da ordem de empilhamento delas: o índice `0` corresponde à forma mais ao fundo, enquanto o último índice corresponde à forma mais ao frente.

Este artigo segue esse modelo. Primeiro explica como identificar uma forma de forma confiável e modificar pontos de ajuste predefinidos, depois mostra como clonar, remover, ocultar e reorganizar formas. As seções finais tratam de formatação em nível de layout, exportação SVG, alinhamento e configurações de inversão. Cada exemplo é independente, de modo que você pode usar apenas as operações necessárias ao seu fluxo de trabalho.

## **Identificar e Encontrar Formas**

Os índices da coleção são convenientes ao processar um arquivo conhecido, mas não são identificadores estáveis. Inserir, remover ou reorganizar uma forma pode mudar seu índice. Escolha um identificador de acordo com a forma como a apresentação foi criada e mantida:

- [Name](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getname/) é útil para modelos controlados por desenvolvedor e é fácil de inspecionar no Painel de Seleção do PowerPoint. Nomes podem ser editados e não são garantidos como únicos, portanto estabeleça uma convenção de nomenclatura se o código depender deles.
- [AlternativeText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getalternativetext/) é útil quando uma descrição de acessibilidade ou uma tag fornecida pelo autor já identifica a forma. É visível aos usuários, pode ser localizado ou reescrito para acessibilidade e não é garantido como único. Não reutilize silenciosamente texto de acessibilidade significativo como chave de banco de dados.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getofficeinteropshapeid/) é um identificador apenas para leitura que é exclusivo dentro de um slide e corresponde ao ID de forma usado pela interoperabilidade do PowerPoint. Use-o ao integrar com o PowerPoint ou quando precisar de uma referência inequívoca durante a vida útil de uma forma. Uma forma clonada ou recriada é uma forma diferente e recebe seu próprio ID.

O método relacionado [Shape::getUniqueId](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getuniqueid/) retorna um identificador com escopo de apresentação, mas esse identificador foi pensado para complementos e pode ser reatribuído. Não deve ser tratado como uma chave externa permanente. Se a identidade de longo prazo for essencial, mantenha o mapeamento nos dados da aplicação e valide se a forma esperada ainda existe.

O exemplo a seguir procura por nome com comparação exata e relata o ID de interop com escopo de slide. Quando o modelo não contém a forma esperada, o código relata esse resultado em vez de continuar com o objeto errado.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Quando uma operação é específica para um tipo de forma, verifique a classe em tempo de execução antes de usar membros específicos de tipo. Este exemplo atualiza texto e texto alternativo apenas se o objeto nomeado for um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Identificar e Modificar Ajustes Predefinidos de Forma**

Formas de geometria predefinida podem expor pontos de ajuste que controlam recursos como tamanho de canto, proporções de setas ou ângulos de arco. Acesse-os através da coleção somente‑leitura [GeometryShape::getAdjustments](https://reference.aspose.com/slides/pt/php-java/aspose.slides/geometryshape/#getAdjustments). A própria coleção é fornecida pela forma, mas cada [AdjustValue](https://reference.aspose.com/slides/pt/php-java/aspose.slides/adjustvalue/) contém um valor que pode ser alterado.

Não confie apenas em um índice fixo da coleção. Percorra os ajustes e inspecione o método somente‑leitura [AdjustValue::getType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/adjustvalue/#getType), cujo valor [ShapeAdjustmentType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapeadjustmenttype/) descreve o que o ajuste controla. O método somente‑leitura [AdjustValue::getName](https://reference.aspose.com/slides/pt/php-java/aspose.slides/adjustvalue/getname/) fornece informações adicionais de identificação e é especialmente útil quando um predefinido contém mais de um ajuste com o mesmo tipo semântico.

Use o método de valor que corresponde ao significado do ajuste:

| Tipo de ajuste | Propósito | Valor a alterar |
|---|---|---|
| `CornerSize` | Tamanho dos cantos arredondados | [setRawValue](https://reference.aspose.com/slides/pt/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Espessura da cauda de uma seta | `setRawValue` |
| `ArrowheadLength` | Comprimento da ponta da seta | `setRawValue` |
| `ArrowheadWidth` | Largura da ponta da seta | `setRawValue` |
| `StartAngle` | Ângulo inicial de uma pizza ou arco | [setAngleValue](https://reference.aspose.com/slides/pt/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Ângulo final de uma pizza ou arco | `setAngleValue` |

`getType` e `getName` retornam informações somente‑leitura. `getRawValue` e `setRawValue` trabalham com um inteiro nas unidades nativas da geometria do predefinido, enquanto `getAngleValue` e `setAngleValue` trabalham com ângulos em graus. O número, ordem, significado e intervalo válido dos ajustes dependem do predefinido [GeometryShape::getShapeType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/geometryshape/#getShapeType). Um valor válido para um predefinido pode ser inválido ou ter efeito diferente em outro.

Quando `getType` retorna `ShapeAdjustmentType::Custom`, a API não reconhece um significado semântico padrão. Inspecione `getName`, o tipo do predefinido e o valor existente, e deixe o ajuste inalterado a menos que o significado e intervalo esperados sejam conhecidos. Mesmo para tipos reconhecidos, verifique se o mesmo tipo ocorre mais de uma vez antes de selecionar um valor. O artigo [Connector](/slides/pt/php-java/connector/) mostra essa situação com ajustes de curva de conector.

O exemplo completo a seguir cria versões padrão e modificadas de três formas predefinidas. Ele percorre cada ajuste, relata seu nome e tipo, altera valores relacionados ao tamanho através de `setRawValue`, altera ângulos através de `setAngleValue` e salva o resultado. A coluna da esquerda mantém a geometria padrão; a coluna da direita mostra o retângulo arredondado ajustado, a seta de quatro vias e a pizza.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Adicionar cabeçalhos para as colunas de forma padrão e ajustada.
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Verificar o tipo semântico antes de mudar um valor torna o código explícito quanto à sua intenção e evita supor que um determinado índice de coleção tem o mesmo significado em diferentes formas predefinidas.

## **Modificar a Coleção de Formas**

Os métodos de adicionar, clonar, remover e reorganizar operam na coleção imediatamente. Se uma operação altera o número ou a ordem das formas, não continue a depender de índices capturados antes dessa operação.

### **Clonar uma Forma**

[ShapeCollection::addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/addclone/) cria uma cópia independente e a anexa à coleção de destino. [ShapeCollection::insertClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/insertclone/) também cria uma cópia, mas a posiciona em um índice de ordem Z especificado. As sobrecargas que aceitam coordenadas movem a cópia sem alterar seu tamanho; sobrecargas com largura e altura podem redimensioná‑la também.

O exemplo cria um slide de destino, clona um retângulo rotulado para a frente e insere um segundo clone na parte de trás. Alterações em qualquer um dos clones não modificam a forma de origem.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Clonar copia o conteúdo e a formatação da forma, incluindo seu nome e texto alternativo. Atribua novos identificadores lógicos ao clone quando esses valores precisarem ser únicos. Recursos usados por formas complexas são manipulados pela apresentação, mas um clone permanece um novo item da coleção com uma nova identidade de forma.

### **Remover Formas**

[ShapeCollection::remove](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/remove/) exclui um objeto de forma específico de sua coleção. Ao remover várias correspondências durante iteração indexada, percorra do final para que cada índice restante continue válido.

Este exemplo remove toda forma com um nome designado. Ele lê a forma no índice atual, não um item fixo da coleção, e não faz cast desnecessário da forma.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Após a remoção, a contagem de formas e os índices das formas posteriores mudam. Referências a formas não afetadas permanecem mais confiáveis que índices salvos. Também considere conectores, animações e outros recursos da apresentação que possam referir‑se ao objeto removido; remover uma forma visível pode mudar mais do que a aparência do slide.

### **Ocultar uma Forma**

Definir [Shape::setHidden](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/sethidden/) como `true` mantém a forma na coleção, mas impede que ela apareça na apresentação normal. Seu índice, formatação e conteúdo permanecem disponíveis ao código, de modo que ocultar é adequado para elementos opcionais que podem ser restaurados mais tarde.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ocultar não é exclusão nem segurança. O objeto ainda pode ser descoberto e desocultado por um usuário ou por código, e continua parte do arquivo da apresentação.

### **Alterar a Ordem Z**

Formas sobrepostas são pintadas na ordem da coleção. [ShapeCollection::reorder](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/reorder/) move uma forma existente para um índice alvo sem cloná‑la. O índice `0` é o fundo; `size() - 1` é o frente.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O retângulo é criado primeiro e inicialmente fica atrás da elipse. Movê‑lo para o índice final o coloca à frente. Finalize a ordem Z após adicionar ou clonar todas as formas relacionadas, pois essas operações adicionam ou inserem novos itens na coleção e podem alterar a pilha pretendida.

## **Inspecionar Formas em Slides de Layout**

Slides normais, slides de layout e slides mestre têm coleções de formas separadas. Uma forma em uma coleção de layout não é o mesmo objeto que uma forma posicionada de forma semelhante em um slide normal. Inspecione as formas de layout quando precisar entender ou alterar a formatação fornecida por um layout.

O exemplo a seguir lê o [FillFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getfillformat/) e o [LineFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getlineformat/) de cada forma de layout sem assumir que toda forma é um `AutoShape`.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Editar um layout pode afetar múltiplos slides que o utilizam. Antes de mudar uma forma de layout, determine se um slide normal herda o objeto ou contém uma substituição local, e teste cada slide que usa aquele layout.

## **Exportar uma Forma para SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/writeassvg/) grava o conteúdo renderizado de uma forma em um stream. O resultado contém a forma, não o fundo inteiro do slide ou formas vizinhas.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Mantenha a apresentação aberta enquanto renderiza. A saída depende da formatação da forma e de recursos como fontes e imagens. Se precisar de toda a composição, exporte o slide ao invés de uma forma individual. O chamador possui o stream e deve fechá‑lo.

## **Alinhar Formas**

As sobrecargas de [SlideUtil::alignShapes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideutil/alignshapes/) alinham todas as formas ou índices de coleção selecionados. [ShapesAlignmentType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapesalignmenttype/) especifica a borda, linha central ou modo de distribuição. Defina `alignToSlide` como `true` para usar as bordas do slide; defina como `false` para alinhar as formas selecionadas entre si.

Este exemplo alinha três formas à borda superior do slide. As referências de forma retornadas são convertidas para seus índices atuais imediatamente antes do alinhamento.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Alinhamento altera posições, não a ordem Z. O alinhamento relativo normalmente requer ao menos duas formas, enquanto distribuição horizontal ou vertical precisa de formas suficientes para definir espaçamento. Recalcule os índices se modificar a coleção antes de chamar o método.

## **Inverter uma Forma**

A classe [ShapeFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapeframe/) armazena posição, tamanho, configurações de inversão horizontal e vertical e rotação. Seus valores `getFlipH` e `getFlipV` utilizam [NullableBool](https://reference.aspose.com/slides/pt/php-java/aspose.slides/nullablebool/): `True` habilita a inversão, `False` desabilita e `NotDefined` preserva o estado não especificado/padrão.

A apresentação de entrada abaixo contém uma forma não invertida.

![The shape before flipping](shape_to_be_flipped.png)

O exemplo preserva todos os outros valores do frame e substitui apenas as duas configurações de inversão. Isso é importante porque atribuir um novo [Frame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/setframe/) substitui o frame completo.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A forma salva é espelhada horizontal e verticalmente enquanto mantém sua posição, tamanho e rotação.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Devo usar um índice de coleção como identificador de forma?**

Apenas para processamento de curta duração quando a coleção não mudará antes que o índice seja usado. Prefira uma convenção validada de `Name` ou `AlternativeText` para modelos criados, ou `OfficeInteropShapeId` para trabalho de interop com escopo de slide.

**Ocultar uma forma a remove da ordem Z?**

Não. Uma forma oculta permanece na coleção no mesmo índice. Ela pode ser encontrada, reordenada, editada ou tornada visível novamente.

**Por que uma forma clonada apareceu à frente de outra forma?**

`addClone` anexa o clone ao final da coleção, que é a frente da ordem Z. Use `insertClone` para escolher o índice inicial ou `reorder` após todas as formas terem sido adicionadas.

**Posso usar um índice fixo para identificar um ajuste predefinido de forma?**

Apenas após validar o predefinido exato e o layout da coleção. Prefira iterar por `GeometryShape::getAdjustments` e verificar `AdjustValue::getType`; use `AdjustValue::getName` como informação adicional quando o mesmo tipo semântico aparecer mais de uma vez.