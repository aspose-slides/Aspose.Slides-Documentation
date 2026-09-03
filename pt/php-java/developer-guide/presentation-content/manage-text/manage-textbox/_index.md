---
title: Gerenciar Caixas de Texto em Apresentações Usando PHP
linktitle: Gerenciar Caixa de Texto
type: docs
weight: 20
url: /pt/php-java/manage-textbox/
keywords:
- caixa de texto
- quadro de texto
- adicionar texto
- atualizar texto
- criar caixa de texto
- verificar caixa de texto
- adicionar coluna de texto
- adicionar hiperlink
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Criar, identificar, formatar e atualizar caixas de texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para PHP via Java."
---
## **Introdução**

Em Aspose.Slides para PHP via Java, o texto dos slides é armazenado em quadros de texto que pertencem a formas. A classe [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) representa a forma mais comum que contém texto e expõe seu texto através do método [AutoShape::getTextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Nota" %}}
Todo auto shape deriva de [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/), mas nem toda forma é um auto shape ou oferece suporte a um quadro de texto. Ao processar uma apresentação existente, use `java_instanceof` para verificar se uma forma é um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) antes de acessar seu texto.
{{% /alert %}}

## **Criar uma Caixa de Texto em um Slide**

Para criar uma caixa de texto, adicione um auto shape a um slide, adicione texto ao seu quadro de texto e salve a apresentação. O exemplo a seguir cria uma caixa de texto retangular:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
    $textBox->addTextFrame("Aspose TextBox");

    $presentation->save("TextBox.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

As coordenadas e dimensões passadas para [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/#addAutoShape) são medidas em pontos. [AutoShape::addTextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/#addTextFrame) inicializa o quadro de texto com o texto fornecido.

## **Verificar se é uma Forma de Caixa de Texto**

Use o método [AutoShape::isTextBox](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/#isTextBox) para determinar se um auto shape é tratado como uma caixa de texto. Isso é útil quando uma apresentação contém tanto auto shapes que carregam texto quanto auto shapes puramente gráficas.

![Uma caixa de texto e uma forma](istextbox.png)

O exemplo a seguir inspeciona cada auto shape em uma apresentação:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
    $textBox->addTextFrame("Text box");
    $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $currentSlide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($currentSlide->getShapes()->size()); $shapeIndex++) {
            $shape = $currentSlide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $autoShapeClass)) {
                echo (java_is_true($shape->isTextBox()) ? "The shape is a text box." : "The shape is not a text box.") . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Um auto shape recém‑adicionado não é considerado uma caixa de texto até que contenha texto não vazio. Você pode fornecer esse texto através de [AutoShape::addTextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/#addTextFrame) ou [TextFrame::setText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#setText). Definir ou atribuir uma string vazia faz com que [AutoShape::isTextBox](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/#isTextBox) retorne `false`:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
    $shape1->addTextFrame("Shape 1");
    echo (java_is_true($shape1->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
    $shape2->getTextFrame()->setText("Shape 2");
    echo (java_is_true($shape2->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
    $shape3->addTextFrame("");
    echo (java_is_true($shape3->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
    $shape4->getTextFrame()->setText("");
    echo (java_is_true($shape4->isTextBox()) ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

As duas primeiras chamadas imprimem `true`; as duas últimas imprimem `false`.

## **Encontrar a Forma que Possui um Quadro de Texto**

Código genérico de processamento de texto pode receber um [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) sem saber a qual objeto de apresentação ele pertence. Use o método somente‑leitura [TextFrame::getParentShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#getParentShape) para voltar à sua [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/) proprietária.

Para um quadro de texto pertencente a um auto shape ou outra forma que contém texto, [TextFrame::getParentShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#getParentShape) devolve o proprietário e [TextFrame::getParentCell](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#getParentCell) devolve `null`. Verifique o valor retornado com `java_is_null` antes de acessá‑lo. Para identificar tanto proprietários de forma quanto de célula de tabela, incluindo formas associadas a nós de SmartArt, consulte [Search and Replace Text](/slides/pt/php-java/search-and-replace-text/).

## **Adicionar Colunas a uma Caixa de Texto**

O método [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/#setColumnCount) divide o quadro de texto em colunas, enquanto [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/#setColumnSpacing) define o espaço entre colunas em pontos. Ambas as configurações pertencem a [TextFrameFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/) e podem ser alteradas por meio do quadro de texto de uma caixa de texto existente. O texto é redistribuído entre colunas dentro da mesma forma; não continua em outra forma.

O exemplo a seguir cria uma caixa de texto com três colunas e 10 pontos de espaçamento entre elas, salva a apresentação e lê as configurações armazenadas do arquivo de saída:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
    $textBox->addTextFrame("This text is distributed automatically across all columns in the text box.");

    $textFrameFormat = $textBox->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setColumnCount(3);
    $textFrameFormat->setColumnSpacing(10);

    $presentation->save("TextBoxColumns.pptx", SaveFormat::Pptx);

    $savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        $savedTextBox = $savedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedFormat = $savedTextBox->getTextFrame()->getTextFrameFormat();
        echo "Columns: " . java_values($savedFormat->getColumnCount()) . "; spacing: " . java_values($savedFormat->getColumnSpacing()) . " points" . PHP_EOL;
    } finally {
        $savedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Extrair Texto de Colunas Individuais**

Use [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#splitTextByColumns) para obter o texto atribuído a cada coluna visual em um quadro de texto existente. O método devolve uma string para cada coluna, na ordem de leitura baseada em colunas. Um quadro de texto de coluna única produz um array com um elemento, e uma coluna vazia é representada por uma string vazia. As strings contêm apenas texto puro; a formatação em nível de porção não é preservada.

Isso é útil quando você precisa:

- Extrair texto preservando a ordem de leitura baseada em colunas.
- Indexar ou comparar o conteúdo de slides com múltiplas colunas.
- Exportar cada coluna para um arquivo separado, campo de banco de dados ou outro destino.
- Inspecionar como o texto é redistribuído após alterar a contagem de colunas com [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/#setColumnCount), o espaçamento com [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/#setColumnSpacing), a fonte ou o tamanho do quadro de texto.

O método reporta o texto distribuído dentro do [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) atual; não envia automaticamente o texto entre formas ou caixas de texto separadas. A distribuição em colunas pode depender das fontes disponíveis e de outras configurações de layout de texto, portanto certifique‑se de que as fontes necessárias estejam presentes quando resultados consistentes forem importantes.

O exemplo a seguir carrega uma apresentação, encontra o primeiro auto shape multi‑coluna com um quadro de texto, lê a contagem de colunas configurada e grava o texto de cada coluna em um arquivo separado. Formas que não fornecem um quadro de texto são ignoradas.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("MultiColumnText.pptx");
try {
    $textBox = null;
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (java_instanceof($shape, $autoShapeClass)) {
            $textFrame = $shape->getTextFrame();
            if (!java_is_null($textFrame)) {
                $columnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
                if ($columnCount > 1) {
                    $textBox = $shape;
                    break;
                }
            }
        }
    }

    if ($textBox === null) {
        echo "No multi-column text frame was found." . PHP_EOL;
    } else {
        $textFrame = $textBox->getTextFrame();
        $configuredColumnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
        $columnTexts = java_values($textFrame->splitTextByColumns());

        echo "Configured columns: " . $configuredColumnCount . PHP_EOL;

        foreach ($columnTexts as $columnIndex => $columnText) {
            $columnNumber = $columnIndex + 1;
            echo "Column " . $columnNumber . ": " . $columnText . PHP_EOL;
            $outputPath = "Column-" . $columnNumber . ".txt";
            $bytesWritten = file_put_contents($outputPath, $columnText);
            if ($bytesWritten === false) {
                echo "Could not write column " . $columnNumber . " to " . $outputPath . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Atualizar Texto**

Para atualizar texto em toda a apresentação, itere pelos slides e pelas formas, selecione auto shapes e então edite suas porções de texto. Trabalhar no nível de porção permite alterar tanto o texto quanto a formatação de caracteres.

O exemplo a seguir substitui cada ocorrência de `years` por `months` em textos de auto shapes e torna cada porção afetada em negrito:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Text.pptx");
try {
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $text = java_values($portion->getText());
                    if ($text !== null && strpos($text, "years") !== false) {
                        $updatedText = str_replace("years", "months", $text);
                        $portion->setText($updatedText);
                        $portion->getPortionFormat()->setFontBold(NullableBool::True);
                    }
                }
            }
        }
    }

    $presentation->save("TextChanged.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Essa travessia atualiza texto apenas em auto shapes. Texto armazenado em tabelas, gráficos, SmartArt ou formas agrupadas requer a travessia das coleções próprias desses objetos.

## **Adicionar uma Caixa de Texto com Hiperlink**

Um hiperlink pode ser atribuído a uma porção de texto específica, de modo que somente esse texto funcione como link clicável. Use [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) para associar a porção a uma URL externa.

O exemplo a seguir cria texto vinculado e o salva em uma apresentação:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
    $textBox->addTextFrame("Aspose.Slides");

    $textPortion = $textBox->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $textPortion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://www.aspose.com/");

    $presentation->save("Hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Qual a diferença entre uma caixa de texto e um espaço reservado de texto em um slide mestre ou de layout?**

Um [placeholder](/slides/pt/php-java/manage-placeholder/) pode herdar sua posição e formatação de um [master slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslide/) ou [layout slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/). Uma caixa de texto regular é uma forma independente no slide onde foi criada e não adquire o comportamento de placeholder quando o layout muda.

**Como posso substituir texto sem alterar o texto em gráficos, tabelas ou SmartArt?**

Limite a travessia aos objetos [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) conforme demonstrado no exemplo Atualizar Texto. Gráficos, tabelas e SmartArt armazenam texto em seus próprios modelos de objeto, portanto não são modificados por esse loop.