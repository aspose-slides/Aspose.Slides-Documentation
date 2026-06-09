---
title: Gerenciar Tabelas de Apresentação em JavaScript
linktitle: Gerenciar Tabela
type: docs
weight: 10
url: /pt/nodejs-java/manage-table/
keywords:
- adicionar tabela
- criar tabela
- acessar tabela
- proporção
- alinhar texto
- formatação de texto
- estilo de tabela
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Crie e edite tabelas em slides do PowerPoint com JavaScript e Aspose.Slides para Node.js. Descubra exemplos de código simples para otimizar seus fluxos de trabalho com tabelas."
---
## **Introdução**

Uma tabela no PowerPoint é uma forma eficiente de exibir e representar informações. As informações em uma grade de células (organizadas em linhas e colunas) são simples e fáceis de entender.

Aspose.Slides fornece a classe [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table), a classe [Cell](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/cell/) e outros tipos para permitir que você crie, atualize e gerencie tabelas em todos os tipos de apresentações.

## **Criar Tabela do Zero**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através de seu índice. 
3. Defina um array de `columnWidth`.
4. Defina um array de `rowHeight`.
5. Adicione um objeto [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table) ao slide por meio do método [addTable](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Itere por cada [Cell](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/cell/) para aplicar formatação nas bordas superior, inferior, direita e esquerda.
7. Mescle as duas primeiras células da primeira linha da tabela. 
8. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) de um [Cell](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/cell/).
9. Adicione algum texto ao [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/).
10. Salve a apresentação modificada.

Este código JavaScript mostra como criar uma tabela em uma apresentação:

```javascript
// Instancia uma classe Presentation que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Acessa o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Define colunas com larguras e linhas com alturas
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Adiciona uma forma de tabela ao slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Define o formato de borda para cada célula
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Mescla as células 1 e 2 da linha 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Adiciona algum texto à célula mesclada
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Salva a apresentação no disco
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Numeração em Tabela Padrão**

Em uma tabela padrão, a numeração das células é simples e baseada em zero. A primeira célula de uma tabela tem o índice 0,0 (coluna 0, linha 0). 

Por exemplo, as células em uma tabela com 4 colunas e 4 linhas são numeradas da seguinte forma:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código JavaScript mostra como especificar a numeração das células em uma tabela:

```javascript
// Instancia uma classe Presentation que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Acessa o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Define colunas com larguras e linhas com alturas
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Adiciona uma forma de tabela ao slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Define o formato de borda para cada célula
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
    // Salva a apresentação no disco
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Acessar Tabela Existente**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha uma referência ao slide que contém a tabela através de seu índice. 
3. Crie um objeto [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table) e defina-o como null.
4. Itere por todos os objetos [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/) até que a tabela seja encontrada.

   Se você suspeita que o slide que está analisando contém uma única tabela, pode simplesmente verificar todas as formas que ele contém. Quando uma forma é identificada como uma tabela, você pode convertê‑la para um objeto [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table). Mas se o slide que está analisando contém várias tabelas, é melhor procurar a tabela que precisa através do seu [setAlternativeText(String value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. Use o objeto [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table) para trabalhar com a tabela. No exemplo abaixo, adicionamos uma nova linha à tabela.
6. Salve a apresentação modificada.

Este código JavaScript mostra como acessar e trabalhar com uma tabela existente:

```javascript
// Instancia a classe Presentation que representa um arquivo PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Acessa o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Inicializa TableEx nula
    var tbl = null;
    // Itera pelas formas e define uma referência para a tabela encontrada
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Define o texto para a primeira coluna da segunda linha
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Salva a apresentação modificada no disco
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alinhar Texto na Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através de seu índice. 
3. Adicione um objeto [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table) ao slide.
4. Acesse um objeto [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) da tabela.
5. Acesse o [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/) do [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/).
6. Alinhe o texto verticalmente.
7. Salve a apresentação modificada.

Este código JavaScript mostra como alinhar o texto em uma tabela:

```javascript
// Cria uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide
    var slide = pres.getSlides().get_Item(0);
    // Define colunas com larguras e linhas com alturas
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Adiciona a forma de tabela ao slide
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Acessa o quadro de texto
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Cria o objeto Paragraph para o quadro de texto
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Cria o objeto Portion para o parágrafo
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Alinha o texto verticalmente
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Salva a apresentação no disco
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir Formatação de Texto no Nível da Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através de seu índice. 
3. Acesse um objeto [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table) do Slide.
4. Defina o [setFontHeight(float value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) para o texto.
5. Defina o [setAlignment(int value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) e o [setMarginRight(float value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Defina o [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Salve a apresentação modificada. 

Este código JavaScript mostra como aplicar suas opções de formatação preferidas ao texto em uma tabela:

```javascript
// Cria uma instância da classe Presentation
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Vamos supor que a primeira forma no primeiro slide seja uma tabela
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Define a altura da fonte das células da tabela
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Define o alinhamento de texto e a margem direita das células da tabela em uma única chamada
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Define o tipo vertical de texto das células da tabela
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Obter Propriedades de Estilo da Tabela**

Aspose.Slides permite que você recupere as propriedades de estilo de uma tabela para que possa usar esses detalhes em outra tabela ou em outro lugar. Este código JavaScript mostra como obter as propriedades de estilo de um estilo predefinido de tabela:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// alterar o tema padrão do preset de estilo
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bloquear Proporção da Tabela**

A proporção de uma forma geométrica é a relação de seus tamanhos em diferentes dimensões. Aspose.Slides fornece a propriedade [**setAspectRatioLocked**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) para permitir que você bloqueie a configuração de proporção para tabelas e outras formas.

Este código JavaScript mostra como bloquear a proporção de uma tabela:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invert
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso habilitar a direção de leitura da direita para a esquerda (RTL) para uma tabela inteira e o texto em suas células?**

Sim. A tabela expõe o método [setRightToLeft](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/table/setrighttoleft/) e os parágrafos possuem [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). Usar ambos garante a ordem RTL correta e a renderização dentro das células.

**Como posso impedir que os usuários movam ou redimensionem uma tabela no arquivo final?**

Use bloqueios de forma para desabilitar mover, redimensionar, seleção, etc. Esses bloqueios se aplicam às tabelas também.

**É suportado inserir uma imagem dentro de uma célula como plano de fundo?**

Sim. Você pode definir um [picture fill](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/) para uma célula; a imagem cobrirá a área da célula de acordo com o modo escolhido (esticar ou repetir).