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
description: "Gerencie facilmente células de tabela no PowerPoint com Aspose.Slides para Android via Java. Domine o acesso, modificação e estilização de células rapidamente para automação perfeita de slides."
---
## **Visão geral**

Aspose.Slides permite acessar e modificar células de tabelas em apresentações do PowerPoint. Este artigo explica como identificar células de tabelas mescladas, remover bordas de células, trabalhar com numeração de células após mesclar ou dividir células, alterar a cor de fundo de uma célula e adicionar uma imagem dentro de uma célula de tabela. Os exemplos mostram como criar ou abrir uma apresentação, obter uma tabela de um slide, atualizar a formatação das células por meio das propriedades da célula e salvar a apresentação modificada como um arquivo PPTX.

## **Identificar uma célula de tabela mesclada**
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
2. Obtenha a tabela do primeiro slide. 
3. Percorra as linhas e colunas da tabela para encontrar células mescladas.
4. Exiba uma mensagem quando células mescladas forem encontradas.

Este código Java mostra como identificar células de tabela mescladas em uma apresentação:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // assumindo que Slide#0.Shape#0 é uma tabela
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remover bordas de células de tabela**
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
2. Obtenha a referência de um slide pelo seu índice. 
3. Defina um array de colunas com largura.
4. Defina um array de linhas com altura.
5. Adicione uma tabela ao slide por meio do método [addTable](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Percorra todas as células para limpar as bordas superior, inferior, direita e esquerda.
7. Salve a apresentação modificada como um arquivo PPTX.

Este código Java mostra como remover as bordas das células de tabela:

```java
// Instancia a classe Presentation que representa um arquivo PPTX
Presentation pres = new Presentation();
try {
    // Acessa o primeiro slide
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Define colunas com larguras e linhas com alturas
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Adiciona a forma de tabela ao slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Define o formato de borda para cada célula
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // grava o PPTX no disco
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numeração em células mescladas**
Se mesclarmos 2 pares de células (1, 1) × (2, 1) e (1, 2) × (2, 2), a tabela resultante será numerada. Este código Java demonstra o processo:

```java
// Instancia a classe Presentation que representa um arquivo PPTX
Presentation pres = new Presentation();
try {
    // Acessa o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Define colunas com larguras e linhas com alturas
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Adiciona a forma de tabela ao slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Define o formato de borda para cada célula
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Mescla células (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Mescla células (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Em seguida mesclamos as células ainda mais, mesclando (1, 1) e (1, 2). O resultado é uma tabela contendo uma grande célula mesclada no centro:

```java
// Instancia a classe Presentation que representa um arquivo PPTX
Presentation pres = new Presentation();
try {
    // Acessa o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Define colunas com larguras e linhas com alturas
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Adiciona uma forma de tabela ao slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Define o formato de borda para cada célula
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Mescla células (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Mescla células (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Mescla células (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// Grava o arquivo PPTX no disco
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numeração em uma célula dividida**
Nos exemplos anteriores, quando as células da tabela foram mescladas, a numeração ou o sistema de numeração nas outras células não mudou.

Desta vez, pegamos uma tabela regular (uma tabela sem células mescladas) e então tentamos dividir a célula (1,1) para obter uma tabela especial. Preste atenção à numeração desta tabela, que pode parecer estranha. No entanto, esse é o modo como o Microsoft PowerPoint numera as células da tabela e o Aspose.Slides faz o mesmo.

Este código Java demonstra o processo descrito:

```java
// Instancia a classe Presentation que representa um arquivo PPTX
Presentation pres = new Presentation();
try {
    // Acessa o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Define colunas com larguras e linhas com alturas
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Adiciona uma forma de tabela ao slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Define o formato de borda para cada célula
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Mescla células (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Mescla células (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Divide a célula (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    //Grava o arquivo PPTX no disco
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alterar a cor de fundo da célula da tabela**

Este código Java mostra como alterar a cor de fundo de uma célula de tabela:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // criar uma nova tabela
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // definir a cor de fundo para uma célula 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Adicionar uma imagem dentro de uma célula de tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
2. Obtenha a referência de um slide pelo seu índice.
3. Defina um array de colunas com largura.
4. Defina um array de linhas com altura.
5. Adicione uma tabela ao slide por meio do método [AddTable](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Crie um objeto `Images` para armazenar o arquivo de imagem.
7. Adicione a imagem `IImage` ao objeto `IPPImage`.
8. Defina o `FillFormat` da célula da tabela como `Picture`.
9. Adicione a imagem à primeira célula da tabela.
10. Salve a apresentação modificada como um arquivo PPTX

Este código Java mostra como inserir uma imagem dentro de uma célula de tabela ao criar a tabela:

```java
// Instancia a classe Presentation que representa um arquivo PPTX
Presentation pres = new Presentation();
try {
    // Acessa o primeiro slide
    ISlide islide = pres.getSlides().get_Item(0);

    // Define colunas com larguras e linhas com alturas
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Adiciona uma forma de tabela ao slide
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Cria um objeto IPPImage usando o arquivo de imagem
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Adiciona a imagem à primeira célula da tabela
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Salva o arquivo PPTX no disco
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso definir espessuras e estilos de linha diferentes para lados diferentes de uma única célula?**

Sim. As bordas [top](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/cellformat/#getBorderRight--) têm propriedades separadas, de modo que a espessura e o estilo de cada lado podem ser diferentes. Isso decorre logicamente do controle de borda por lado demonstrado no artigo.

**O que acontece com a imagem se eu alterar o tamanho da coluna/linha depois de definir uma imagem como plano de fundo da célula?**

O comportamento depende do [fill mode](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile). Com estiramento, a imagem se ajusta à nova célula; com mosaico, os mosaicos são recalculados. O artigo menciona os modos de exibição da imagem em uma célula.

**Posso atribuir um hyperlink a todo o conteúdo de uma célula?**

[Hyperlinks](/slides/pt/androidjava/manage-hyperlinks/) são definidos no nível de texto (por porção) dentro da moldura de texto da célula ou no nível de toda a tabela/forma. Na prática, você atribui o link a uma porção ou a todo o texto da célula.

**Posso definir fontes diferentes dentro de uma única célula?**

Sim. A moldura de texto de uma célula suporta [portions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/portion/) (trechos) com formatação independente—família da fonte, estilo, tamanho e cor.