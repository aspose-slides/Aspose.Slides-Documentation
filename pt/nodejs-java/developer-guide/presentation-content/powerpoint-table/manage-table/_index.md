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

As tabelas no PowerPoint organizam informações em linhas e colunas, facilitando a leitura e a comparação de valores.

Aspose.Slides fornece a classe [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) , a classe [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) e outros tipos para permitir que você crie, atualize e gerencie tabelas em apresentações.

## **Criar uma Tabela do Zero**

Crie uma tabela especificando sua posição, larguras das colunas e alturas das linhas. Depois de adicioná‑la a um slide, você pode formatar as bordas das células, mesclar células e inserir texto.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Obtenha uma referência ao slide pelo seu índice.
3. Defina um array de larguras de coluna em pontos.
4. Defina um array de alturas de linha em pontos.
5. Adicione um objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) ao slide através do método [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-) .
6. Itere por cada [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) para aplicar formatação nas bordas superior, inferior, direita e esquerda.
7. Mescle as duas primeiras células da primeira linha da tabela.
8. Acesse a célula mesclada através do seu método [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) .
9. Defina o texto na célula mesclada.
10. Salve a apresentação modificada.

O exemplo abaixo cria uma tabela com três colunas e cinco linhas em (100, 50) pontos. Aplica bordas vermelhas com largura de 5 pontos, mescla as duas primeiras células da primeira linha e salva o resultado como `table.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Numeração em uma Tabela Padrão**

Em uma tabela padrão, os índices das células são baseados em zero e usam a ordem (coluna, linha). A primeira célula tem índice (0, 0).

Por exemplo, as células de uma tabela com 4 colunas e 4 linhas são numeradas assim:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este exemplo cria a tabela 4 × 4 ilustrada acima, com larguras de coluna e alturas de linha de 70 pontos e bordas de célula vermelhas com largura de 5 pontos. As coordenadas ilustram os índices das células; o exemplo deixa as células vazias e salva a tabela como `StandardTables_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Acessar uma Tabela Existente**

As tabelas são armazenadas na coleção de formas de um slide. Itere pelas formas para localizar uma tabela e, então, use a classe [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) para ler ou atualizar suas células.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Obtenha uma referência ao slide que contém a tabela pelo seu índice.
3. Itere pelos objetos [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) e interrompa quando encontrar uma tabela. Se o slide contiver várias tabelas, use [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) para identificar a que você precisa.
4. Atualize o texto na célula alvo.
5. Salve a apresentação modificada.

O exemplo abaixo abre `UpdateExistingTable.pptx` e encontra a primeira tabela no primeiro slide. Define a célula na coluna 0, linha 1 para `New` e salva o resultado como `table1_out.pptx`. A entrada deve conter ao menos um slide, e a primeira tabela desse slide deve ter ao menos uma coluna e duas linhas.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Para redimensionar uma linha em uma tabela existente e entender por que sua altura real pode exceder o mínimo solicitado, veja [Control Row Height](/slides/pt/nodejs-java/manage-rows-and-columns/#control-row-height).

## **Encontrar a Célula que Possui um TextFrame**

Quando um código genérico de processamento de texto recebe um [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de uma tabela, use o método [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) para recuperar a [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) proprietária. Para um TextFrame de célula de tabela, [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) devolve o proprietário e [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) devolve `null`, embora a tabela em si seja uma forma.

As coordenadas da célula estão disponíveis pelos métodos somente‑leitura [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) e [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) . [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) também fornece navegação somente‑leitura: devolve o proprietário, mas não altera a propriedade. Sempre verifique se a célula retornada é `null` antes de usá‑la.

Para um exemplo completo que identifica proprietários de célula‑tabela e de forma, incluindo formas associadas a nós de SmartArt, veja [Search and Replace Text](/slides/pt/nodejs-java/search-and-replace-text/).

## **Alinhar Texto em uma Tabela**

É possível controlar o ancoramento vertical e a direção do texto de células individuais de tabelas. O exemplo nesta seção centraliza o texto na primeira célula e o rotaciona em 270 graus.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Obtenha uma referência ao slide pelo seu índice.
3. Adicione um objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) ao slide.
4. Acesse um objeto [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) da tabela.
5. Acesse o primeiro [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) e defina seu texto e cor.
6. Defina o ancoramento vertical da célula e a direção do texto usando [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) e [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-) .
7. Salve a apresentação modificada.

Este exemplo cria uma tabela 4 × 4 com larguras de coluna de 120 pontos e alturas de linha de 100 pontos. Formata o texto na célula (0, 0), adiciona valores às demais células da primeira linha e salva o resultado como `Vertical_Align_Text_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir Formatação de Texto no Nível da Tabela**

Use [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) para aplicar formatação de texto a todas as células de uma tabela. Suas sobrecargas aceitam formatação de porção, parágrafo e quadro de texto, permitindo definir essas propriedades sem iterar pelas células individualmente.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Obtenha uma referência ao slide pelo seu índice.
3. Acesse um objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) do slide.
4. Defina o tamanho da fonte usando [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) para o texto.
5. Defina o alinhamento do parágrafo e a margem direita usando [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) e [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) .
6. Defina a direção do texto usando [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) .
7. Salve a apresentação modificada.

O exemplo abaixo abre `table.pptx`, que deve conter ao menos um slide com uma tabela como sua primeira forma. Define o tamanho da fonte para 25 pontos, alinha os parágrafos à direita com margem direita de 20 pontos e torna o texto vertical. A apresentação formatada é salva como `result.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obter Propriedades de Estilo da Tabela**

Use [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) para ler o estilo predefinido de uma tabela e [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) para atribuí‑lo. Este exemplo aplica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) a uma tabela, imprime o valor predefinido e atribui o mesmo predefinido a uma segunda tabela. Ambas as tabelas são salvas em `table-style.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bloquear a Proporção de uma Tabela**

A proporção de uma tabela é a razão entre sua largura e sua altura. Use [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) para bloquear essa razão em uma tabela.

O exemplo abaixo abre `pres.pptx`, que deve conter ao menos um slide com uma tabela como sua primeira forma. Imprime o estado atual do bloqueio, habilita o bloqueio da proporção, imprime o estado atualizado (`true`) e salva o resultado como `pres-out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Perguntas Frequentes**

**Posso habilitar a direção de leitura da direita‑para‑esquerda (RTL) para uma tabela inteira e o texto em suas células?**

Sim. A tabela expõe um método [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-) e os parágrafos têm [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-). Usar ambos garante a ordem RTL correta e a renderização dentro das células.

**Como impedir que usuários movam ou redimensionem uma tabela no arquivo final?**

Use [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) para desativar mover, redimensionar, selecionar etc. Esses bloqueios se aplicam também a tabelas.

**É suportado inserir uma imagem dentro de uma célula como plano de fundo?**

Sim. Você pode definir um [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) para uma célula; a imagem cobrirá a área da célula de acordo com o modo escolhido (esticar ou ladrilho).