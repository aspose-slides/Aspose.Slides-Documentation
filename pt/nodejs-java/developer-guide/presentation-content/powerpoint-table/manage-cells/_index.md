---
title: Gerenciar Células de Tabela em Apresentações Usando JavaScript
linktitle: Gerenciar Células
type: docs
weight: 30
url: /pt/nodejs-java/manage-cells/
keywords:
- célula de tabela
- mesclar células
- remover borda
- dividir célula
- imagem na célula
- cor de fundo
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie células de tabela do PowerPoint em JavaScript: identifique células mescladas, remova bordas, divida células e defina cores de fundo e imagens com Aspose.Slides para Node.js via Java."
---
## **Visão geral**

Aspose.Slides permite acessar e modificar células de tabela em apresentações do PowerPoint. Este artigo explica como identificar células de tabela mescladas, remover bordas de célula, trabalhar com numeração de células após mesclar ou dividir células, alterar a cor de fundo de uma célula e adicionar uma imagem dentro de uma célula de tabela. Os exemplos mostram como criar ou abrir uma apresentação, obter uma tabela de um slide, atualizar a formatação da célula por meio das propriedades da célula e salvar a apresentação modificada como um arquivo PPTX.

Aspose.Slides usa índices baseados em zero para acessar células de tabela na ordem `(coluna, linha)`.

## **Identificar uma Célula de Tabela Mesclada**

O exemplo abre uma apresentação existente e acessa a primeira forma no primeiro slide como uma tabela. Ele pressupõe que o slide e a forma existam e que a forma seja uma tabela. Em seguida, itera por todas as linhas e colunas e usa [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) para identificar células em regiões mescladas. Para cada correspondência, imprime as coordenadas da célula na ordem `linha;coluna`, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), e as coordenadas iniciais da região, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) e [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Remover Bordas de Célula da Tabela**

Crie uma [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) e adicione uma tabela ao seu primeiro slide com [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/). Larguras de coluna, alturas de linha e a posição da tabela são especificadas em pontos. O exemplo define todas as quatro bordas da célula como [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), tornando-as invisíveis.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Adicionar Bordas Diagonais à Célula**

Use [getBorderDiagonalDown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonaldown/) para desenhar uma linha do canto superior esquerdo ao canto inferior direito, e [getBorderDiagonalUp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonalup/) para desenhar uma linha do canto inferior esquerdo ao canto superior direito. Uma diagonal pode marcar um cabeçalho de canto; ambas as diagonais podem formar um X para indicar que a célula não se aplica.

Cada diagonal é um [LineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/). Em seu [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/), use [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) para selecionar [FillType.Solid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) e escolha uma cor através de [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/). Defina a espessura da linha em pontos com [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/).

O exemplo cria três células em uma linha: uma diagonal descendente vermelha, uma diagonal ascendente azul e ambas as diagonais. Deixa as bordas superior, inferior, esquerda e direita da célula inalteradas.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [210, 210, 210]);
    const rowHeights = java.newArray("double", [160]);
    const table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    const downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    downwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    downwardBorder.setWidth(3);

    const upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    upwardBorder.setWidth(5);

    const crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    crossDownwardBorder.setWidth(3);

    const crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Uma diagonal é uma propriedade de formatação, não uma divisão de célula. Cada célula mantém um único *text frame*, acessado por [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/gettextframe/); as regiões em cada lado de uma diagonal não podem ser editadas independentemente.

A tabela salva, renderizada no Microsoft PowerPoint:

![Três células de tabela mostrando uma diagonal vermelha do canto superior esquerdo ao canto inferior direito, uma diagonal azul do canto inferior esquerdo ao canto superior direito e ambas as diagonais formando um X.](diagonal-cell-borders.png)

*Da esquerda para a direita: diagonal descendente (vermelha, 3 pt), diagonal ascendente (azul, 5 pt) e ambas as diagonais.*

## **Mesclar Células da Tabela**

Use [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) para combinar um intervalo retangular de células da tabela em uma única célula. Especifique as células nos cantos superior esquerdo e inferior direito do intervalo. O argumento final controla se a mescla pode incluir células fora do intervalo especificado; `false` mantém a mescla dentro desse intervalo.

O exemplo cria uma tabela 4 × 4 com colunas e linhas de 70 pontos, então mescla as quatro células centrais de `(1, 1)` até `(2, 2)`. A célula resultante abrange duas colunas e duas linhas, enquanto a grade subjacente da tabela mantém quatro colunas e quatro linhas. Para acessar o conteúdo ou a formatação da célula mesclada, use sua posição superior esquerda: `table.get_Item(1, 1)` neste exemplo. As outras posições no intervalo mesclado permanecem parte da grade da tabela, de modo que os índices das células fora do intervalo não mudam.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dividir Células da Tabela**

Mesclar células no exemplo anterior preserva a grade da tabela. Dividir uma célula pode introduzir uma nova coluna na grade e alterar os índices de coluna das células à sua direita. Aspose.Slides segue o modelo de grade de tabela do PowerPoint.

Este exemplo cria uma tabela 4 × 4 com colunas e linhas de 70 pontos e chama [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) na célula `(1, 1)`. Metade da largura de 70 pontos da célula é passada para criar duas células de largura igual.

Após essa divisão, as duas metades são acessadas como `table.get_Item(1, 1)` e `table.get_Item(2, 1)`. A grade da tabela passa a ter cinco colunas: as células originalmente nas colunas 2 e 3 movem‑se para as colunas 3 e 4, respectivamente. Os índices de linha permanecem inalterados. Use esses índices de coluna atualizados ao acessar células depois da divisão.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![Uma célula não mesclada de 70 pontos se divide em duas células de 35 pontos, adicionando uma quinta coluna à grade e deslocando os índices à sua direita.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*A divisão de largura afeta a célula (1, 1), usando índices baseados em zero (coluna, linha). As demais linhas mantêm uma célula abrangendo ambas as novas posições de coluna.*
<!-- visual-explanation:manage-cells:end -->

### **Dividir Células Mescladas por Extensão de Linha ou Coluna**

Para preparar células modelo mescladas para preenchimento de dados, use [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) para dividir ao longo de um limite de linha existente, ou [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) para dividir ao longo de um limite de coluna.

O argumento `index` conta linhas na parte superior ou colunas na parte esquerda da divisão; ele é relativo à região mesclada:

- Divisão de linha: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Divisão de coluna: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

O exemplo supõe que a apresentação tenha uma tabela como a primeira forma no primeiro slide, com `(1, 2)` e `(1, 3)` mesclados verticalmente. Começando a partir da posição inferior, ele usa [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) e [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) para localizar a origem e verifica ambas as extensões. `splitByRowSpan(1)` então separa as linhas 2 e 3 para nomes de produtos. Para uma mescla horizontal de duas colunas, use `splitByColSpan(1)` em vez disso.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // Recuperar as células resultantes da tabela após a divisão.
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

A grade da tabela e os índices das células ao redor permanecem inalterados. Recupere as células resultantes por suas coordenadas; aqui, ambas têm extensão 1 e [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) retorna `false`. Regiões maiores podem permanecer parcialmente mescladas após uma divisão.

O texto original e sua formatação permanecem na célula superior (ou esquerda); a nova célula está vazia, mas herda a formatação da célula, como preenchimento, bordas e margens. Popule as células após a divisão e defina explicitamente qualquer formatação de texto necessária.

A apresentação salva contém células separadas “Product A” e “Product B” com a formatação da célula do modelo mantida. Consulte a [Referência da API de Célula](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) para detalhes.

### **Dividir uma Célula em uma Altura Específica**

[splitByHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyheight/) recebe a altura da parte superior em pontos. [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) recebe o número de linhas da grade existentes na parte superior. Para centralizar uma célula de 40 pontos na coluna direita, subtraia 40 da altura real da célula e divida o espaço restante igualmente acima e abaixo dela.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [160, 160]);
    const rowHeights = java.newArray("double", [140]);

    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    const height = table.get_Item(1, 0).getHeight();
    const margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A primeira divisão adiciona uma linha à grade e deixa os 90 pontos inferiores na célula `(1, 1)`. A segunda divisão divide essa célula em uma célula central de 40 pontos e uma célula inferior de 50 pontos. A coluna direita agora tem três células com alturas de 50, 40 e 50 pontos de cima para baixo. A célula esquerda abrange as três linhas e mantém sua altura original de 140 pontos.

![A célula esquerda abrange toda a altura da tabela ao lado de três células com “Middle” no centro.](split-by-height.png)

## **Alterar a Cor de Fundo da Célula da Tabela**

Este exemplo cria uma tabela com colunas de 150 pontos e linhas de 50 pontos. Ele usa [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) para selecionar um preenchimento sólido e define a cor retornada por [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) para vermelho na célula `(2, 3)`, na terceira coluna e quarta linha.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Adicionar uma Imagem Dentro de uma Célula da Tabela**

Coloque a imagem de entrada no diretório de trabalho antes de executar este exemplo. Ela carrega a imagem com [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) e a adiciona à coleção de imagens da apresentação com [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/). Em seguida, atribui a imagem ao preenchimento de imagem da célula `(0, 0)`, a primeira célula da tabela.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) estica a imagem para preencher a célula, o que pode alterar sua proporção. Larguras de coluna e alturas de linha estão em pontos. A imagem carregada é descartada em um bloco `finally` após ser adicionada à apresentação.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso definir espessuras e estilos de linha diferentes para lados distintos de uma única célula?**

Sim. As bordas [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) têm propriedades separadas, de modo que a espessura e o estilo de cada lado podem ser diferentes.

**O que acontece com a imagem se eu alterar o tamanho da coluna/linha depois de definir uma foto como plano de fundo da célula?**

O comportamento depende do [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Com estiramento, a imagem se ajusta à nova célula; com ladrilamento, os ladrilhos são recalculados.

**Posso atribuir um hyperlink a todo o conteúdo de uma célula?**

[Hyperlinks](/slides/pt/nodejs-java/manage-hyperlinks/) são definidos no nível de texto (por porção) dentro do *text frame* da célula ou no nível de toda a tabela/forma. Na prática, você atribui o link a uma porção ou a todo o texto da célula.

**Posso definir fontes diferentes dentro de uma única célula?**

Sim. O *text frame* de uma célula suporta [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (segmentos) com formatação independente — família da fonte, estilo, tamanho e cor.