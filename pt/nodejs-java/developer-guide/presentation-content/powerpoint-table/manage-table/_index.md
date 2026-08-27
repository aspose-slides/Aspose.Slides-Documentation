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
- proporção de aspecto
- alinhar texto
- formatação de texto
- estilo de tabela
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Criar e editar tabelas em slides do PowerPoint com JavaScript e Aspose.Slides para Node.js. Descubra exemplos de código simples para otimizar seus fluxos de trabalho com tabelas."
---
## **Introdução**

Uma tabela no PowerPoint é uma maneira eficiente de exibir e representar informações. As informações em uma grade de células (organizadas em linhas e colunas) são diretas e fáceis de entender.

Aspose.Slides fornece a classe [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table), a classe [Cell](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/cell/) e outros tipos para permitir que você crie, atualize e gerencie tabelas em todos os tipos de apresentações.

## **Criar Tabela do Zero**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através de seu índice. 
3. Defina um array de `columnWidth`.
4. Defina um array de `rowHeight`.
5. Adicione um objeto [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table) ao slide usando o método [addTable](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Percorra cada [Cell](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/cell/) para aplicar formatação nas bordas superior, inferior, direita e esquerda.
7. Mescle as quatro células no canto superior‑esquerdo da tabela (as duas primeiras colunas das duas primeiras linhas) em uma única célula. 
8. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) de uma [Cell](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/cell/).
9. Adicione algum texto ao [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/).
10. Salve a apresentação modificada.

Este código JavaScript mostra como criar uma tabela em uma apresentação:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
    // Define o formato da borda para cada célula
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
    // Mescla o bloco 2x2 superior esquerdo de células em uma única célula
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

Em uma tabela padrão, a numeração das células é direta e baseada em zero. A primeira célula de uma tabela tem índice 0,0 (coluna 0, linha 0). 

Por exemplo, as células em uma tabela com 4 colunas e 4 linhas são numeradas da seguinte forma:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código JavaScript mostra como especificar a numeração para as células de uma tabela:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

3. Crie um objeto [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table) e defina‑o como null.

4. Percorra todos os objetos [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/) até encontrar a tabela.

   Se você suspeitar que o slide em questão contém apenas uma tabela, pode simplesmente verificar todas as formas que ele contém. Quando uma forma é identificada como uma tabela, você pode fazer o cast para um objeto [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table). Mas se o slide contiver várias tabelas, é melhor procurar a tabela desejada através de seu [setAlternativeText(String value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. Use o objeto [Table] para trabalhar com a tabela. No exemplo abaixo, definimos o texto de uma célula da tabela.

6. Salve a apresentação modificada.

Este código JavaScript mostra como acessar e trabalhar com uma tabela existente:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instancia a classe Presentation que representa um arquivo PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Acessa o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Inicializa TableEx como null
    var tbl = null;
    // Percorre as formas e define uma referência para a tabela encontrada
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

## **Encontrar a Célula que Possui um Quadro de Texto**

Quando um código genérico de processamento de texto recebe um [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) de uma tabela, use o método [TextFrame.getParentCell](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#getParentCell--) para recuperar a [Cell](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/cell/) proprietária. Para um quadro de texto de célula de tabela, [TextFrame.getParentCell](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#getParentCell--) devolve o proprietário e [TextFrame.getParentShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#getParentShape--) devolve `null`, embora a própria tabela seja uma forma.

As coordenadas da célula estão disponíveis através dos métodos somente‑leitura [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) e [Cell.getFirstRowIndex](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/cell/#getFirstRowIndex--). [TextFrame.getParentCell](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/#getParentCell--) também fornece navegação somente‑leitura: ele devolve o proprietário mas não altera a propriedade. Sempre verifique se a célula retornada é `null` antes de utilizá‑la.

Para um exemplo completo que identifica proprietários de células‑tabela e de formas, incluindo formas associadas a nós de SmartArt, veja [Search and Replace Text](/slides/pt/nodejs-java/search-and-replace-text/).

## **Alinhar Texto em Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através de seu índice. 
3. Adicione um objeto [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table) ao slide.
4. Acesse um objeto [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) da tabela.
5. Acesse o [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/) do [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/).
6. Alinhe o texto verticalmente.
7. Salve a apresentação modificada.

Este código JavaScript mostra como alinhar o texto em uma tabela:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
    // Salva a apresentação no disco
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir Formatação de Texto no Nível da Tabela**

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através de seu índice. 
3. Acesse um objeto [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table) do slide.
4. Defina o [setFontHeight(float value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) para o texto.
5. Defina o [setAlignment(int value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) e o [setMarginRight(float value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Defina o [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Salve a apresentação modificada. 

Este código JavaScript mostra como aplicar suas opções de formatação preferidas ao texto de uma tabela:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
    // Define o tipo de orientação vertical do texto das células da tabela
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir Estilo de Tabela Pré‑definido**

Aspose.Slides inclui os estilos de tabela integrados do PowerPoint como a enumeração [TableStylePreset](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tablestylepreset/), permitindo que você aplique a mesma aparência a qualquer tabela. Este código JavaScript mostra como substituir o estilo padrão de uma tabela por um estilo pré‑definido:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// alterar o tema de preset de estilo padrão
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bloquear Proporção de Aspecto da Tabela**

A proporção de aspecto de uma forma geométrica é a razão entre seus tamanhos em diferentes dimensões. Aspose.Slides fornece a propriedade [**setAspectRatioLocked**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) para permitir que você bloqueie a configuração de proporção de aspecto para tabelas e outras formas.

Este código JavaScript mostra como bloquear a proporção de aspecto de uma tabela:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Use bloqueios de forma para desativar movimentação, redimensionamento, seleção etc. Esses bloqueios também se aplicam a tabelas.

**É suportado inserir uma imagem dentro de uma célula como plano de fundo?**

Sim. Você pode definir um [picture fill](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/) para uma célula; a imagem cobrirá a área da célula conforme o modo escolhido (esticar ou ladrilhar).