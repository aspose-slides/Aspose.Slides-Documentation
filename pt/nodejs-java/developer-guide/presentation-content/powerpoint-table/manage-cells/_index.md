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
description: "Gerencie células de tabela no PowerPoint com Aspose.Slides para Node.js. Domine o acesso, a modificação e o estilo das células rapidamente para automação de slides perfeita."
---
## **Visão geral**

Aspose.Slides permite acessar e modificar células de tabela em apresentações do PowerPoint. Este artigo explica como identificar células de tabela mescladas, remover bordas das células, trabalhar com numeração de células após mesclar ou dividir células, alterar a cor de fundo de uma célula e adicionar uma imagem dentro de uma célula de tabela. Os exemplos mostram como criar ou abrir uma apresentação, obter uma tabela de um slide, atualizar a formatação das células por meio das propriedades da célula e salvar a apresentação modificada como um arquivo PPTX.

## **Identificar Célula de Tabela Mesclada**
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a tabela do primeiro slide.
3. Itere pelas linhas e colunas da tabela para encontrar células mescladas.
4. Exiba uma mensagem quando células mescladas forem encontradas.

Este código JavaScript demonstra como identificar células de tabela mescladas em uma apresentação:

```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// supondo que Slide#0.Shape#0 seja uma tabela
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Remover Borda das Células de Tabela**
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide por meio de seu índice.
3. Defina um array de colunas com largura.
4. Defina um array de linhas com altura.
5. Adicione uma tabela ao slide através do método [addTable](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Itere por cada célula para limpar as bordas superior, inferior, direita e esquerda.
7. Salve a apresentação modificada como um arquivo PPTX.

Este código JavaScript demonstra como remover as bordas das células de tabela:

```javascript
// Instancia a classe Presentation que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Acessa o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Define colunas com larguras e linhas com alturas
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Adiciona a forma de tabela ao slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Define o formato da borda para cada célula
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // Grava o PPTX no disco
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Numeração em Células Mescladas**
Se mesclarmos 2 pares de células (1, 1) × (2, 1) e (1, 2) × (2, 2), a tabela resultante será numerada. Este código JavaScript demonstra o processo:

```javascript
// Instancia a classe Presentation que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Acessa o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Define colunas com larguras e linhas com alturas
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Adiciona uma forma de tabela ao slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Define o formato da borda para cada célula
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Mescla as células (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Mescla as células (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Em seguida, mesclamos ainda mais as células ao combinar (1, 1) e (1, 2). O resultado é uma tabela contendo uma grande célula mesclada em seu centro:

```javascript
    // Instancia a classe Presentation que representa um arquivo PPTX
    var pres = new aspose.slides.Presentation();
    try {
        // Acessa o primeiro slide
        var sld = pres.getSlides().get_Item(0);
        // Define colunas com larguras e linhas com alturas
        var dblCols = java.newArray("double", [70, 70, 70, 70]);
        var dblRows = java.newArray("double", [70, 70, 70, 70]);
        // Adiciona uma forma de tabela ao slide
        var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
        // Define o formato da borda para cada célula
        for (let i = 0; i < tbl.getRows().size(); i++) {
            const row = tbl.getRows().get_Item(i);
            for (let j = 0; j < row.size(); j++) {
                const cell = row.get_Item(j);
                cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderTop().setWidth(5);
                cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderBottom().setWidth(5);
                cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderLeft().setWidth(5);
                cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderRight().setWidth(5);
            }
        }
        // Mescla as células (1, 1) x (2, 1)
        tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
        // Mescla as células (1, 2) x (2, 2)
        tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
        // Mescla as células (1, 1) x (1, 2)
        tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
        // Grava o arquivo PPTX no disco
        pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Numeração em Célula Dividida**
Nos exemplos anteriores, quando as células da tabela foram mescladas, a numeração ou o sistema de numeração nas demais células não mudou.

Nesta ocasião, usamos uma tabela normal (uma tabela sem células mescladas) e então tentamos dividir a célula (1,1) para obter uma tabela especial. Você pode querer prestar atenção à numeração desta tabela, que pode parecer estranha. Entretanto, esse é o modo como o Microsoft PowerPoint numera as células da tabela e o Aspose.Slides faz o mesmo.

Este código JavaScript demonstra o processo descrito:

```javascript
// Instancia a classe Presentation que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Acessa o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Define colunas com larguras e linhas com alturas
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Adiciona uma forma de tabela ao slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Define o formato da borda para cada célula
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Mescla as células (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Mescla as células (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Divide a célula (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // Grava o arquivo PPTX no disco
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alterar Cor de Fundo da Célula da Tabela**

Este código JavaScript demonstra como alterar a cor de fundo de uma célula da tabela:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // cria uma nova tabela
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // define a cor de fundo para uma célula
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Adicionar Imagem Dentro da Célula da Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide por meio de seu índice.
3. Defina um array de colunas com largura.
4. Defina um array de linhas com altura.
5. Adicione uma tabela ao slide através do método [addTable](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Crie um objeto `Images` para armazenar o arquivo de imagem.
7. Adicione a imagem `IImage` ao objeto `PPImage`.
8. Defina o `FillFormat` da célula da tabela como `Picture`.
9. Adicione a imagem à primeira célula da tabela.
10. Salve a apresentação modificada como um arquivo PPTX.

Este código JavaScript demonstra como colocar uma imagem dentro de uma célula de tabela ao criar a tabela:

```javascript
// Instancia a classe Presentation que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Acessa o primeiro slide
    var islide = pres.getSlides().get_Item(0);
    // Define colunas com larguras e linhas com alturas
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // Adiciona uma forma de tabela ao slide
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // Cria um objeto PPImage usando o arquivo de imagem
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Adiciona a imagem à primeira célula da tabela
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Salva o arquivo PPTX no disco
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso definir espessuras e estilos de linha diferentes para os lados de uma única célula?**

Sim. As bordas [top](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/cellformat/getborderright/) têm propriedades separadas, portanto a espessura e o estilo de cada lado podem ser diferentes. Isso segue logicamente o controle de borda por lado para uma célula demonstrado no artigo.

**O que acontece com a imagem se eu alterar o tamanho da coluna/linha após definir uma imagem como plano de fundo da célula?**

O comportamento depende do [fill mode](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Ao esticar, a imagem ajusta‑se à nova célula; ao usar o modo mosaico, os blocos são recalculados. O artigo menciona os modos de exibição de imagem em uma célula.

**Posso atribuir um hyperlink a todo o conteúdo de uma célula?**

[Hyperlinks](/slides/pt/nodejs-java/manage-hyperlinks/) são definidos no nível do texto (porção) dentro da moldura de texto da célula ou no nível de toda a tabela/forma. Na prática, você atribui o link a uma porção ou a todo o texto na célula.

**Posso definir fontes diferentes dentro de uma única célula?**

Sim. A moldura de texto de uma célula suporta [portions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/) (runs) com formatação independente — família da fonte, estilo, tamanho e cor.