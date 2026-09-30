---
title: Gerenciar Linhas e Colunas em Tabelas PowerPoint Usando PHP
linktitle: Linhas e Colunas
type: docs
weight: 20
url: /pt/php-java/manage-rows-and-columns/
keywords:
- linha da tabela
- coluna da tabela
- primeira linha
- cabeçalho da tabela
- clonar linha
- clonar coluna
- copiar linha
- copiar coluna
- remover linha
- remover coluna
- formatação de texto da linha
- formatação de texto da coluna
- estilo da tabela
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Gerencie linhas e colunas de tabelas no PowerPoint com Aspose.Slides for PHP via Java e acelere a edição de apresentações e a atualização de dados."
---
## **Introdução**

Aspose.Slides for PHP via Java permite que você gerencie a estrutura e formatação de tabelas em apresentações do PowerPoint através da classe [Tabela](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Você pode designar uma linha de cabeçalho, clonar ou remover linhas e colunas e aplicar formatação de texto a uma linha ou coluna inteira.

Este artigo explica essas operações com exemplos em PHP. Também mostra como recuperar a predefinição de estilo de uma tabela para que você possa reutilizá‑la. Os índices de linhas e colunas da tabela são baseados em zero.

## **Controlar Altura da Linha**

Use [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) to set a row's minimum height in points. It is a lower bound, not a fixed height. [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) returns the actual height. Access the row through [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/).

O exemplo carrega [row-height-input.pptx](row-height-input.pptx), que contém uma tabela como a primeira forma no primeiro slide. Sua primeira linha começa em 70 pontos. As células usam texto Arial 18 pt, com quebra de linha e margens superior e inferior de 6 pt; o texto mais longo na segunda coluna quebra em várias linhas. O exemplo aumenta o mínimo para 100 pt, depois reduz para 20 pt, imprime a altura real após cada alteração e salva ambos os resultados.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Com a apresentação fornecida, aumentar o mínimo adiciona espaço à linha. Reduzir remove esse espaço extra, porém a altura real permanece maior que 20 pt porque o texto e as margens das células precisam de mais espaço. Reduzir apenas o mínimo não pode forçar a linha a ficar abaixo do espaço exigido pelo seu conteúdo.

Vários fatores afetam a altura real:

- **Texto e tamanho da fonte:** texto mais longo, quebras de linha explícitas ou fonte maior podem exigir mais espaço vertical.
- **Quebra de linha e largura da coluna:** com quebra de linha ativada, diminuir a largura da coluna com [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) pode gerar mais linhas. Uma coluna mais larga pode reduzir o espaço necessário na vertical.
- **Margens da célula:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) e [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) adicionam espaço vertical. [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) e [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) reduzem a largura disponível para o texto e podem causar quebras adicionais.

Para esta tabela sem células mescladas, a célula que necessita de mais espaço vertical determina o limite inferior baseado no conteúdo para toda a linha. Para encurtar a linha, pode ser necessário encurtar o texto, reduzir o tamanho da fonte ou das margens, ou alargar uma coluna.

As imagens abaixo mostram a mesma tabela na mesma escala. Nos resultados ilustrados, as alturas reais foram 70, 100 e 55,2 pt: a linha final permaneceu mais alta que seu mínimo de 20 pt. Medidas exatas de texto podem variar com as fontes disponíveis no seu ambiente. Baixe os resultados salvos: [mínimo aumentado](row-height-increased.pptx) e [mínimo reduzido](row-height-decreased.pptx).

| Original: mínimo 70 pt, real 70 pt | Aumentado: mínimo 100 pt, real 100 pt | Reduzido: mínimo 20 pt, real 55.2 pt |
| --- | --- | --- |
| ![Tabela original com primeira linha de 70 pontos.](row-height-before.png) | ![Tabela após aumentar o mínimo da primeira linha para 100 pontos.](row-height-increased.png) | ![Tabela após diminuir o mínimo da primeira linha para 20 pontos; o texto em linha continua a tornar a linha mais alta que o mínimo.](row-height-decreased.png) |

## **Definir a Primeira Linha como Cabeçalho**

Use o método [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) para marcar a primeira linha para formatação de cabeçalho. Sua aparência depende do estilo de tabela aplicado à tabela.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Acesse a tabela armazenada como a primeira forma no slide.
4. Habilite a formatação de cabeçalho para sua primeira linha.
5. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como a primeira forma no primeiro slide. Ele habilita a formatação de cabeçalho para a primeira linha e salva `First_row_header.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Clonar uma Linha ou Coluna de Tabela**

Clone linhas ou colunas para reutilizar seu conteúdo e formatação. Você pode acrescentar uma cópia ao final da tabela ou inseri‑la em uma posição específica.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Defina as larguras das colunas e as alturas das linhas.
4. Adicione uma tabela com o método [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Clone as linhas necessárias.
6. Clone as colunas necessárias.
7. Salve a apresentação modificada.

O exemplo requer `Test.pptx` com pelo menos um slide. Ele cria uma tabela com três colunas e cinco linhas, com dimensões especificadas em pontos. Ele acrescenta cópias da primeira linha e da primeira coluna, depois insere cópias da segunda linha e da segunda coluna no índice 3 (a quarta posição). A tabela resultante tem sete linhas e cinco colunas. O argumento `false` desabilita a clonagem em linhas ou colunas mescladas adjacentes; esta tabela não possui células mescladas.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Remover uma Linha ou Coluna de uma Tabela**

Remova linhas ou colunas que não são mais necessárias em uma tabela. Remover um item desloca os índices das linhas ou colunas que o seguem.

1. Crie uma apresentação com a classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Defina as larguras das colunas e as alturas das linhas.
4. Adicione uma tabela com o método [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Remova a segunda linha e a segunda coluna.
6. Salve a apresentação modificada.

Este exemplo cria uma tabela 3 × 3 e remove a linha e a coluna no índice 1, deixando uma tabela 2 × 2 em `TestTable_out.pptx`. As dimensões estão em pontos. O argumento `false` desabilita a remoção de linhas ou colunas mescladas adjacentes; esta tabela não possui células mescladas.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Definir Formatação de Texto no Nível de Linha da Tabela**

Aplique formatação de texto a uma linha inteira para manter suas células consistentes. Você pode definir propriedades de fonte, formatação de parágrafo e direção do texto sem formatar cada célula individualmente.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acesse a tabela no primeiro slide.
3. Use [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) para a primeira linha.
4. Use [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) e [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) para a primeira linha.
5. Use [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) para a segunda linha.
6. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como a primeira forma no primeiro slide e pelo menos duas linhas. Ele aplica texto de 25 pt, alinhamento à direita e margem de parágrafo direita de 20 pt à primeira linha, então define texto vertical na segunda linha.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Definir Formatação de Texto no Nível de Coluna da Tabela**

Aplique formatação de texto a uma coluna inteira para manter suas células consistentes. Você pode definir propriedades de fonte, formatação de parágrafo e direção do texto sem formatar cada célula individualmente.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acesse a tabela no primeiro slide.
3. Use [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) para a primeira coluna.
4. Use [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) e [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) para a primeira coluna.
5. Use [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) para a segunda coluna.
6. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como a primeira forma no primeiro slide e pelo menos duas colunas. Ele aplica texto de 25 pt, alinhamento à direita e margem de parágrafo direita de 20 pt à primeira coluna, então define texto vertical na segunda coluna.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Obter Propriedades de Estilo da Tabela**

Use o método [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) para recuperar a predefinição aplicada a uma tabela e reutilizá‑la em outra tabela. Isso identifica a predefinição ao invés de sobrescrições de formatação de células individuais.

O exemplo cria uma tabela, aplica [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1) e lê a predefinição de volta. Ele imprime o valor inteiro correspondente a `DarkStyle1` e salva a tabela em `table.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Posso aplicar temas/estilos do PowerPoint a uma tabela que já foi criada?**

Sim. A tabela herda o tema do slide/layout/master, e você ainda pode sobrescrever preenchimentos, bordas e cores de texto além desse tema.

**Posso classificar linhas de tabela como no Excel?**

Não, as tabelas do Aspose.Slides não possuem ordenação ou filtros incorporados. Classifique seus dados na memória primeiro, depois repopule as linhas da tabela nessa ordem.

**Posso ter colunas em faixas (listradas) mantendo cores personalizadas em células específicas?**

Sim. Ative colunas em faixas, depois sobrescreva células específicas com formatação local; a formatação a nível de célula tem precedência sobre o estilo da tabela.