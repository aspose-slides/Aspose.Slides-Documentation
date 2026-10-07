---
title: Gerenciar Células de Tabela em Apresentações no Android
linktitle: Gerenciar Células
type: docs
weight: 30
url: /pt/androidjava/manage-cells/
keywords:
- célula de tabela
- mesclar células
- remover borda
- dividir célula
- imagem na célula
- cor de fundo
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Gerencie células de tabela do PowerPoint no Android: identifique células mescladas, remova bordas, divida células e defina cores de fundo e imagens com Aspose.Slides para Android via Java."
---
## **Visão geral**

Aspose.Slides permite que você acesse e modifique células de tabela em apresentações do PowerPoint. Este artigo explica como identificar células de tabela mescladas, remover bordas de células, trabalhar com a numeração de células após mesclar ou dividir células, alterar a cor de fundo de uma célula e adicionar uma imagem dentro de uma célula de tabela. Os exemplos mostram como criar ou abrir uma apresentação, obter uma tabela de um slide, atualizar a formatação da célula por meio das propriedades da célula e salvar a apresentação modificada como um arquivo PPTX.

Aspose.Slides usa índices baseados em zero para acessar células de tabela na ordem `(coluna, linha)`.

## **Identificar uma Célula de Tabela Mesclada**

O exemplo abre uma apresentação existente e acessa a primeira forma no primeiro slide como uma tabela. Assume-se que o slide e a forma existam e que a forma seja uma tabela. Em seguida, itera por todas as linhas e colunas e usa [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) para identificar células em regiões mescladas. Para cada correspondência, ele imprime as coordenadas da célula na ordem `linha;coluna`, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), e as coordenadas iniciais da região, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) e [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Remover Bordas de Células da Tabela**

Crie uma [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) e adicione uma tabela ao seu primeiro slide com [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). As larguras das colunas, alturas das linhas e a posição da tabela são especificadas em pontos. O exemplo define todas as quatro bordas da célula como [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), tornando-as invisíveis.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mesclar Células de Tabela**

Use [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) para combinar um intervalo retangular de células de tabela em uma única célula. Especifique as células nos cantos superior esquerdo e inferior direito do intervalo. O argumento final controla se a mesclagem pode incluir células fora do intervalo especificado; `false` mantém a mesclagem dentro desse intervalo.

O exemplo cria uma tabela 4 × 4 com colunas e linhas de 70 pontos, depois mescla as quatro células centrais de `(1, 1)` até `(2, 2)`. A célula resultante abrange duas colunas e duas linhas, enquanto a grade subjacente da tabela permanece com quatro colunas e quatro linhas. Para acessar o conteúdo ou a formatação da célula mesclada, use sua posição superior esquerda: `table.get_Item(1, 1)` neste exemplo. As outras posições no intervalo mesclado permanecem parte da grade da tabela, portanto os índices das células fora do intervalo não mudam.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dividir Células de Tabela**

Mesclar células no exemplo anterior preserva a grade da tabela. Dividir uma célula pode introduzir uma nova coluna na grade e alterar os índices de coluna das células à sua direita. Aspose.Slides segue o modelo de grade de tabelas do PowerPoint.

Este exemplo cria uma tabela 4 × 4 com colunas e linhas de 70 pontos e chama [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) na célula `(1, 1)`. Metade da largura de 70 pontos da célula é usada para criar duas células de largura igual.

Após essa divisão, as duas metades são acessadas como `table.get_Item(1, 1)` e `table.get_Item(2, 1)`. A grade da tabela agora tem cinco colunas: as células originalmente nas colunas 2 e 3 movem‑se para as colunas 3 e 4, respectivamente. Os índices de linha permanecem inalterados. Use esses índices de coluna atualizados ao acessar células depois da divisão.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Dividir Células Mescladas por Extensão de Linha ou Coluna**

Para preparar células de modelo mescladas para preenchimento de dados, use [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) para dividir ao longo de um limite de linha existente, ou [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) para dividir ao longo de um limite de coluna.

O argumento `index` conta linhas na parte superior ou colunas na parte esquerda da divisão; ele é relativo à região mesclada:

- Divisão de linha: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Divisão de coluna: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

O exemplo supõe que a apresentação contenha uma tabela como a primeira forma no primeiro slide, com `(1, 2)` e `(1, 3)` mesclados verticalmente. Começando pela posição inferior, ele usa [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) e [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) para localizar a origem e verifica ambas as extensões. `splitByRowSpan(1)` então separa as linhas 2 e 3 para nomes de produto. Para uma mesclagem horizontal de duas colunas, use `splitByColSpan(1)` em vez disso.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // Recupere as células resultantes da tabela após a divisão.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

A grade da tabela e os índices das células ao redor permanecem inalterados. Recupere as células resultantes por suas coordenadas; aqui, ambas têm extensão 1 e [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) indica `false`. Regiões maiores podem permanecer parcialmente mescladas após uma divisão.

O texto original e sua formatação permanecem na célula superior (ou esquerda); a nova célula está vazia, mas herda a formatação da célula, como preenchimento, bordas e margens. Preencha as células após a divisão e defina explicitamente quaisquer formatações de texto necessárias.

A apresentação salva contém células separadas “Product A” e “Product B” com a formatação de célula do modelo mantida. Consulte a [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) para mais detalhes.

## **Alterar a Cor de Fundo da Célula da Tabela**

Este exemplo cria uma tabela com colunas de 150 pontos e linhas de 50 pontos. Ele usa [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) para selecionar um preenchimento sólido e define a cor retornada por [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) como vermelho para a célula `(2, 3)`, na terceira coluna e quarta linha.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Adicionar uma Imagem Dentro de uma Célula de Tabela**

Coloque a imagem de entrada no diretório de trabalho antes de executar este exemplo. Ela carrega a imagem com [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) e a adiciona à coleção de imagens da apresentação com [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Em seguida, atribui a imagem ao preenchimento de imagem da célula `(0, 0)`, a primeira célula da tabela.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) estica a imagem para preencher a célula, o que pode alterar sua proporção. As larguras das colunas e alturas das linhas estão em pontos. A imagem carregada é descartada em um bloco `finally` após ser adicionada à apresentação.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Perguntas Frequentes**

**Posso definir espessuras e estilos de linha diferentes para os lados de uma única célula?**

Sim. As bordas [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) têm propriedades separadas, portanto a espessura e o estilo de cada lado podem ser diferentes.

**O que acontece com a imagem se eu mudar o tamanho da coluna/linha após definir uma imagem como fundo da célula?**

O comportamento depende do [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile). Com esticamento, a imagem se ajusta à nova célula; com ladrilhamento, os ladrilhos são recalculados.

**Posso atribuir um hiperlink a todo o conteúdo de uma célula?**

[Hyperlinks](/slides/pt/androidjava/manage-hyperlinks/) são definidos no nível de texto (porção) dentro da caixa de texto da célula ou no nível de toda a tabela/forma. Na prática, você atribui o link a uma porção ou a todo o texto da célula.

**Posso definir fontes diferentes dentro de uma única célula?**

Sim. A caixa de texto de uma célula suporta [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (execuções) com formatação independente — família de fonte, estilo, tamanho e cor.