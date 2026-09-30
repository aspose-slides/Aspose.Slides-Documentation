---
title: Gerenciar Linhas e Colunas em Tabelas PowerPoint no Android
linktitle: Linhas e Colunas
type: docs
weight: 20
url: /pt/androidjava/manage-rows-and-columns/
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
- Android
- Java
- Aspose.Slides
description: "Gerencie linhas e colunas de tabelas no PowerPoint com Aspose.Slides para Android via Java e acelere a edição de apresentações e atualizações de dados."
---
## **Introdução**

Aspose.Slides for Android via Java permite gerenciar a estrutura e a formatação de tabelas em apresentações do PowerPoint através da classe [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) e da interface [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). Você pode designar uma linha de cabeçalho, clonar ou remover linhas e colunas e aplicar formatação de texto a uma linha ou coluna inteira.

Este artigo explica essas operações com exemplos em Java. Também mostra como recuperar o preset de estilo de uma tabela para que você possa reutilizá‑lo. Os índices de linhas e colunas da tabela são baseados em zero.

## **Controlar Altura da Linha**

Use [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) para definir a altura mínima de uma linha em pontos. É um limite inferior, não uma altura fixa. [IRow.getHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#getHeight--) devolve a altura real. Acesse a linha através de [ITable.getRows](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getRows--).

O exemplo carrega [row-height-input.pptx](row-height-input.pptx), que contém uma tabela como a primeira forma no primeiro slide. Sua primeira linha começa em 70 pontos. As células usam texto Arial de 18 pontos, com quebra automática e margens superior e inferior de 6 pontos; o texto mais longo na segunda coluna quebra em várias linhas. O exemplo aumenta o mínimo para 100 pontos, depois o reduz para 20 pontos, imprime a altura real após cada alteração e salva ambos os resultados.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Com a apresentação fornecida, aumentar o mínimo adiciona espaço à linha. Reduzi‑lo remove esse espaço extra, mas a altura real permanece maior que 20 pontos porque o texto e as margens das células precisam de mais espaço. Reduzir apenas o mínimo não pode forçar a linha a ficar abaixo do espaço exigido pelo seu conteúdo.

Vários fatores afetam a altura real:

- **Texto e tamanho da fonte:** texto mais longo, quebras de linha explícitas ou uma fonte maior podem exigir mais espaço vertical.
- **Quebra automática e largura da coluna:** com a quebra automática ativada, reduzir a largura da coluna com [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) pode gerar mais linhas. Uma coluna mais larga pode reduzir o espaço necessário verticalmente.
- **Margens das células:** [ICell.setMarginTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginTop-double-) e [ICell.setMarginBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginBottom-double-) adicionam espaço vertical. [ICell.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginLeft-double-) e [ICell.setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginRight-double-) reduzem a largura disponível para o texto e podem causar quebras adicionais.

Para esta tabela sem células mescladas, a célula que necessita de mais espaço vertical determina o limite inferior, dirigido pelo conteúdo, para toda a linha. Para tornar a linha mais curta, pode ser necessário encurtar o texto, reduzir o tamanho da fonte ou as margens, ou alargar uma coluna.

As imagens abaixo mostram a mesma tabela na mesma escala. Nos resultados ilustrados, as alturas reais foram 70, 100 e 55,2 pontos: a linha final permaneceu mais alta que seu mínimo de 20 pontos. Medições de texto exatas podem variar com as fontes disponíveis no seu ambiente. Baixe os resultados salvo: [mínimo aumentado](row-height-increased.pptx) e [mínimo reduzido](row-height-decreased.pptx).

| Original: mínimo 70 pt, real 70 pt | Aumentado: mínimo 100 pt, real 100 pt | Reduzido: mínimo 20 pt, real 55,2 pt |
| --- | --- | --- |
| ![Tabela original com a primeira linha de 70 pontos.](row-height-before.png) | ![Tabela após aumentar o mínimo da primeira linha para 100 pontos.](row-height-increased.png) | ![Tabela após reduzir o mínimo da primeira linha para 20 pontos; texto com quebra mantém a linha mais alta que o mínimo.](row-height-decreased.png) |

## **Definir a Primeira Linha como Cabeçalho**

Use o método [setFirstRow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setFirstRow-boolean-) para marcar a primeira linha como cabeçalho. Sua aparência depende do estilo de tabela aplicado à tabela.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Acesse a tabela armazenada como a primeira forma no slide.
4. Habilite a formatação de cabeçalho para sua primeira linha.
5. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como a primeira forma no primeiro slide. Ele habilita a formatação de cabeçalho para a primeira linha e salva `First_row_header.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Clonar uma Linha ou Coluna de Tabela**

Clone linhas ou colunas para reutilizar seu conteúdo e formatação. Você pode anexar uma cópia ao final da tabela ou inseri‑la em uma posição específica.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Defina as larguras das colunas e as alturas das linhas.
4. Adicione uma tabela com o método [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Clone as linhas necessárias.
6. Clone as colunas necessárias.
7. Salve a apresentação modificada.

O exemplo requer `Test.pptx` com ao menos um slide. Ele cria uma tabela com três colunas e cinco linhas, com dimensões especificadas em pontos. Anexa cópias da primeira linha e coluna, depois insere cópias da segunda linha e coluna no índice 3 (a quarta posição). A tabela resultante tem sete linhas e cinco colunas. O argumento `false` desativa a clonagem em linhas ou colunas mescladas adjacentes; esta tabela não possui células mescladas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Remover uma Linha ou Coluna de uma Tabela**

Remova linhas ou colunas que não são mais necessárias em uma tabela. Remover um item desloca os índices das linhas ou colunas que o seguem.

1. Crie uma apresentação com a classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Defina as larguras das colunas e as alturas das linhas.
4. Adicione uma tabela com o método [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Remova a segunda linha e a segunda coluna.
6. Salve a apresentação modificada.

Este exemplo cria uma tabela de três por três e remove a linha e a coluna no índice 1, deixando uma tabela de dois por dois em `TestTable_out.pptx`. As dimensões estão em pontos. O argumento `false` desativa a remoção de linhas ou colunas mescladas adjacentes; esta tabela não possui células mescladas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir Formatação de Texto no Nível de Linha da Tabela**

Aplique formatação de texto a uma linha inteira para manter suas células consistentes. Você pode definir propriedades de fonte, formatação de parágrafo e direção do texto sem formatar cada célula individualmente.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Acesse a tabela no primeiro slide.
3. Use [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) para a primeira linha.
4. Use [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) e [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) para a primeira linha.
5. Use [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) para a segunda linha.
6. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como a primeira forma no primeiro slide e pelo menos duas linhas. Ele aplica texto de 25 pontos, alinhamento à direita e margem direita de parágrafo de 20 pontos na primeira linha, depois define texto vertical na segunda linha.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir Formatação de Texto no Nível de Coluna da Tabela**

Aplique formatação de texto a uma coluna inteira para manter suas células consistentes. Você pode definir propriedades de fonte, formatação de parágrafo e direção do texto sem formatar cada célula individualmente.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Acesse a tabela no primeiro slide.
3. Use [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) para a primeira coluna.
4. Use [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) e [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) para a primeira coluna.
5. Use [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) para a segunda coluna.
6. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como a primeira forma no primeiro slide e pelo menos duas colunas. Ele aplica texto de 25 pontos, alinhamento à direita e margem direita de parágrafo de 20 pontos na primeira coluna, depois define texto vertical na segunda coluna.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obter Propriedades de Estilo da Tabela**

Use o método [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) para recuperar o preset aplicado a uma tabela e reutilizá‑lo em outra tabela. Isso identifica o preset em vez de sobrescrições de formatação de células individuais.

O exemplo cria uma tabela, aplica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/#DarkStyle1), e lê o preset de volta. Ele imprime o valor inteiro correspondente a `DarkStyle1` e salva a tabela em `table.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso aplicar temas/estilos do PowerPoint a uma tabela que já foi criada?**

Sim. A tabela herda o tema do slide/layout/master e ainda é possível sobrescrever preenchimentos, bordas e cores de texto sobre esse tema.

**Posso ordenar linhas de tabela como no Excel?**

Não, as tabelas do Aspose.Slides não possuem ordenação ou filtros embutidos. Ordene seus dados na memória primeiro e, em seguida, repovoar as linhas da tabela nessa ordem.

**Posso ter colunas em faixas (listradas) mantendo cores personalizadas em células específicas?**

Sim. Ative colunas em faixas e, em seguida, sobrescreva células específicas com formatação local; a formatação a nível de célula tem precedência sobre o estilo da tabela.