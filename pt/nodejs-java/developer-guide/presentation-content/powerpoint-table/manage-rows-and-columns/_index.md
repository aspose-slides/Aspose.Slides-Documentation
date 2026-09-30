---
title: Gerenciar Linhas e Colunas em Tabelas do PowerPoint Usando JavaScript
linktitle: Linhas e Colunas
type: docs
weight: 20
url: /pt/nodejs-java/manage-rows-and-columns/
keywords:
- linha de tabela
- coluna de tabela
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie linhas e colunas de tabelas no PowerPoint com JavaScript e Aspose.Slides para Node.js via Java e acelere a edição de apresentações e a atualização de dados."
---
## **Introdução**

Aspose.Slides for Node.js via Java permite gerenciar a estrutura e a formatação de tabelas em apresentações do PowerPoint por meio da classe [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Você pode designar uma linha de cabeçalho, clonar ou remover linhas e colunas e aplicar formatação de texto a uma linha ou coluna inteira.

Este artigo explica essas operações com exemplos em JavaScript. Ele também mostra como recuperar a predefinição de estilo de uma tabela para que você possa reutilizá‑la. Os índices de linhas e colunas da tabela são baseados em zero.

## **Controlar a Altura da Linha**

Use [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) para definir a altura mínima de uma linha em pontos. É um limite inferior, não uma altura fixa. [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) retorna a altura real. Acesse a linha através de [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--).

O exemplo carrega [row-height-input.pptx](row-height-input.pptx), que contém uma tabela como o primeiro shape no primeiro slide. Sua primeira linha começa em 70 pontos. As células usam texto Arial de 18 pontos, com quebra de linha e margens superior e inferior de 6 pontos; o texto mais longo na segunda coluna quebra em várias linhas. O exemplo aumenta o mínimo para 100 pontos, depois o diminui para 20 pontos, imprime a altura real após cada alteração e salva ambos os resultados.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Com a apresentação fornecida, aumentar o mínimo adiciona espaço à linha. Diminuí‑lo remove esse espaço extra, mas a altura real permanece maior que 20 pontos porque o texto e as margens da célula precisam de mais espaço. Reduzir apenas o mínimo não pode forçar a linha a ficar abaixo do espaço exigido pelo seu conteúdo.

Vários fatores influenciam a altura real:

- **Texto e tamanho da fonte:** texto mais longo, quebras de linha explícitas ou uma fonte maior podem exigir mais espaço vertical.  
- **Quebra de linha e largura da coluna:** com quebra de linha ativada, reduzir a largura da coluna com [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) pode gerar mais linhas. Uma coluna mais larga pode reduzir o espaço vertical necessário.  
- **Margens da célula:** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) e [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) adicionam espaço vertical. [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) e [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) reduzem a largura disponível para o texto e podem causar quebras adicionais.

Para esta tabela sem células mescladas, a célula que precisa de mais espaço vertical determina o limite inferior impulsionado pelo conteúdo para toda a linha. Para tornar a linha mais curta, pode ser necessário encurtar o texto, reduzir o tamanho da fonte ou as margens, ou alargar uma coluna.

As imagens abaixo mostram a mesma tabela na mesma escala. Nos resultados ilustrados, as alturas reais foram 70, 100 e 55,2 pontos: a linha final permaneceu mais alta que seu mínimo de 20 pontos. Medidas exatas de texto podem variar com as fontes disponíveis no seu ambiente. Baixe os resultados salvos: [increased minimum](row-height-increased.pptx) e [decreased minimum](row-height-decreased.pptx).

| Original: mínimo 70 pt, real 70 pt | Aumentado: mínimo 100 pt, real 100 pt | Diminuído: mínimo 20 pt, real 55.2 pt |
| --- | --- | --- |
| ![Tabela original com a primeira linha de 70 pontos.](row-height-before.png) | ![Tabela após aumentar o mínimo da primeira linha para 100 pontos.](row-height-increased.png) | ![Tabela após diminuir o mínimo da primeira linha para 20 pontos; texto em quebra mantém a linha mais alta que o mínimo.](row-height-decreased.png) |

## **Definir a Primeira Linha como Cabeçalho**

Use o método [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) para marcar a primeira linha para formatação de cabeçalho. Sua aparência depende do estilo de tabela aplicado.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).  
2. Acesse o primeiro slide.  
3. Acesse a tabela armazenada como o primeiro shape no slide.  
4. Ative a formatação de cabeçalho para sua primeira linha.  
5. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como o primeiro shape no primeiro slide. Ele ativa a formatação de cabeçalho para a primeira linha e salva `First_row_header.pptx`.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Clonar uma Linha ou Coluna da Tabela**

Clone linhas ou colunas para reutilizar seu conteúdo e formatação. Você pode anexar uma cópia ao final da tabela ou inseri‑la em uma posição específica.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).  
2. Acesse o primeiro slide.  
3. Defina as larguras das colunas e as alturas das linhas.  
4. Adicione uma tabela com o método [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
5. Clone as linhas necessárias.  
6. Clone as colunas necessárias.  
7. Salve a apresentação modificada.

O exemplo requer `Test.pptx` com ao menos um slide. Ele cria uma tabela com três colunas e cinco linhas, com dimensões especificadas em pontos. Ele anexa cópias da primeira linha e da primeira coluna, depois insere cópias da segunda linha e da segunda coluna no índice 3 (a quarta posição). A tabela resultante possui sete linhas e cinco colunas. O argumento `false` desabilita a clonagem em linhas ou colunas mescladas adjacentes; esta tabela não possui células mescladas.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Remover uma Linha ou Coluna de uma Tabela**

Remova linhas ou colunas que não são mais necessárias em uma tabela. Remover um item desloca os índices das linhas ou colunas que o seguem.

1. Crie uma apresentação com a classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).  
2. Acesse o primeiro slide.  
3. Defina as larguras das colunas e as alturas das linhas.  
4. Adicione uma tabela com o método [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
5. Remova a segunda linha e a segunda coluna.  
6. Salve a apresentação modificada.

Este exemplo cria uma tabela 3 × 3 e remove a linha e a coluna no índice 1, resultando em uma tabela 2 × 2 em `TestTable_out.pptx`. As dimensões estão em pontos. O argumento `false` desabilita a remoção de linhas ou colunas mescladas adjacentes; esta tabela não possui células mescladas.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir Formatação de Texto no Nível da Linha da Tabela**

Aplique formatação de texto a uma linha inteira para manter a consistência das células. Você pode definir propriedades de fonte, formatação de parágrafo e direção do texto sem formatar cada célula individualmente.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).  
2. Acesse a tabela no primeiro slide.  
3. Use [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) para a primeira linha.  
4. Use [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) e [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) para a primeira linha.  
5. Use [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) para a segunda linha.  
6. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como o primeiro shape no primeiro slide e ao menos duas linhas. Ele aplica texto de 25 pontos, alinhamento à direita e margem de parágrafo à direita de 20 pontos na primeira linha, depois define texto vertical na segunda linha.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir Formatação de Texto no Nível da Coluna da Tabela**

Aplique formatação de texto a uma coluna inteira para manter a consistência das células. Você pode definir propriedades de fonte, formatação de parágrafo e direção do texto sem formatar cada célula individualmente.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).  
2. Acesse a tabela no primeiro slide.  
3. Use [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) para a primeira coluna.  
4. Use [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) e [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) para a primeira coluna.  
5. Use [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) para a segunda coluna.  
6. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como o primeiro shape no primeiro slide e ao menos duas colunas. Ele aplica texto de 25 pontos, alinhamento à direita e margem de parágrafo à direita de 20 pontos na primeira coluna, depois define texto vertical na segunda coluna.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obter Propriedades de Estilo da Tabela**

Use o método [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) para recuperar a predefinição aplicada a uma tabela e reutilizá‑la em outra tabela. Isso identifica a predefinição em vez de sobrescrições de formatação de células individuais.

O exemplo cria uma tabela, aplica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1) e lê a predefinição de volta. Ele imprime o valor inteiro correspondente a `DarkStyle1` e salva a tabela em `table.pptx`.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Perguntas Frequentes**

**Posso aplicar temas/estilos do PowerPoint a uma tabela já criada?**  
Sim. A tabela herda o tema do slide/layout/master e ainda assim você pode sobrescrever preenchimentos, bordas e cores de texto sobre esse tema.

**Posso ordenar linhas da tabela como no Excel?**  
Não, as tabelas do Aspose.Slides não possuem ordenação ou filtros integrados. Ordene seus dados em memória primeiro e, depois, preencha as linhas da tabela nessa ordem.

**Posso ter colunas listradas (banded) mantendo cores personalizadas em células específicas?**  
Sim. Ative colunas listradas e depois sobrescreva células específicas com formatação local; a formatação no nível da célula tem precedência sobre o estilo da tabela.