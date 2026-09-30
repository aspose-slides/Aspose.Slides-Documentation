---
title: Gerenciar Tabelas de Apresentação no Android
linktitle: Gerenciar Tabela
type: docs
weight: 10
url: /pt/androidjava/manage-table/
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
- Android
- Java
- Aspose.Slides
description: "Crie e edite tabelas em slides do PowerPoint com Aspose.Slides para Android. Descubra exemplos simples de código Java para simplificar seus fluxos de trabalho com tabelas."
---
## **Introdução**

As tabelas no PowerPoint organizam informações em linhas e colunas, facilitando a leitura e a comparação de valores.

Aspose.Slides fornece a classe [Tabela](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) , a interface [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) , a classe [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) , a interface [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) e outros tipos para permitir que você crie, atualize e gerencie tabelas em apresentações.

## **Criar uma Tabela do Zero**

Crie uma tabela especificando sua posição, larguras das colunas e alturas das linhas. Depois de adicioná‑la a um slide, você pode formatar bordas de células, mesclar células e inserir texto.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Obtenha uma referência ao slide pelo seu índice.
3. Defina um array de larguras de coluna em pontos.
4. Defina um array de alturas de linha em pontos.
5. Adicione um objeto [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) ao slide através do método [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) .
6. Percorra cada [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) para aplicar formatação nas bordas superior, inferior, direita e esquerda.
7. Mescle as duas primeiras células da primeira linha da tabela.
8. Acesse a célula mesclada através do seu método [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) .
9. Defina o texto na célula mesclada.
10. Salve a apresentação modificada.

O exemplo abaixo cria uma tabela com três colunas e cinco linhas em (100, 50) pontos. Ele aplica bordas vermelhas com largura de 5 pontos, mescla as duas primeiras células da primeira linha e salva o resultado como `table.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Numeração em uma Tabela Padrão**

Em uma tabela padrão, os índices das células são baseados em zero e utilizam a ordem (coluna, linha). A primeira célula tem índice (0, 0).

Por exemplo, as células de uma tabela com 4 colunas e 4 linhas são numeradas assim:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este exemplo cria a tabela 4 × 4 ilustrada acima, com larguras de coluna e alturas de linha de 70 pontos e bordas de célula vermelhas com largura de 5 pontos. As coordenadas ilustram os índices das células; o exemplo deixa as células vazias e salva a tabela como `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Acessar uma Tabela Existente**

As tabelas são armazenadas na coleção de formas de um slide. Percorra as formas para localizar uma tabela e, em seguida, use a interface [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) para ler ou atualizar suas células.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Obtenha uma referência ao slide que contém a tabela pelo seu índice.
3. Percorra os objetos [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) e pare quando encontrar uma tabela. Se o slide contiver várias tabelas, use [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) para identificar a que você precisa.
4. Atualize o texto na célula alvo.
5. Salve a apresentação modificada.

O exemplo abaixo abre `UpdateExistingTable.pptx` e encontra a primeira tabela no primeiro slide. Ele define a célula na coluna 0, linha 1 para `New` e salva o resultado como `table1_out.pptx`. A entrada deve conter ao menos um slide, e a primeira tabela desse slide deve possuir ao menos uma coluna e duas linhas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Para redimensionar uma linha em uma tabela existente e entender por que sua altura real pode exceder o mínimo solicitado, veja [Control Row Height](/slides/pt/androidjava/manage-rows-and-columns/#control-row-height).

## **Encontrar a Célula que Possui um Quadro de Texto**

Quando um código genérico de processamento de texto recebe um [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) de uma tabela, use o método [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) para recuperar o [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) proprietário. Para um quadro de texto de célula de tabela, [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) retorna o dono e [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) retorna `null`, embora a própria tabela seja uma forma.

As coordenadas da célula estão disponíveis através dos métodos somente‑leitura [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) e [ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) . [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) também fornece navegação somente‑leitura: ele retorna o proprietário mas não altera a propriedade. Sempre verifique se a célula retornada é `null` antes de usá‑la.

Para um exemplo completo que identifica proprietários de células de tabela e de formas, incluindo formas associadas a nós de SmartArt, veja [Search and Replace Text](/slides/pt/androidjava/search-and-replace-text/).

## **Alinhar Texto em uma Tabela**

Você pode controlar o ancoramento vertical e a direção do texto de células individuais da tabela. O exemplo nesta seção centraliza o texto na primeira célula e o rotaciona em 270 graus.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Obtenha uma referência ao slide pelo seu índice.
3. Adicione um objeto [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) ao slide.
4. Acesse um objeto [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) da tabela.
5. Acesse o primeiro [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) e defina seu texto e cor.
6. Defina o ancoramento vertical da célula e a direção do texto usando [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) e [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-) .
7. Salve a apresentação modificada.

Este exemplo cria uma tabela 4 × 4 com larguras de coluna de 120 pontos e alturas de linha de 100 pontos. Ele formata o texto na célula (0, 0), adiciona valores às demais células da primeira linha e salva o resultado como `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir Formatação de Texto no Nível da Tabela**

Use [setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) para aplicar formatação de texto a todas as células de uma tabela. Seus sobrecargas aceitam formatação de porção, parágrafo e quadro de texto, permitindo definir essas propriedades sem percorrer células individuais.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Obtenha uma referência ao slide pelo seu índice.
3. Acesse um objeto [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) do slide.
4. Defina o tamanho da fonte usando [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) para o texto.
5. Defina o alinhamento do parágrafo e a margem direita usando [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) e [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) .
6. Defina a direção do texto usando [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) .
7. Salve a apresentação modificada.

O exemplo abaixo abre `table.pptx`, que deve conter ao menos um slide com uma tabela como sua primeira forma. Ele define o tamanho da fonte para 25 pontos, alinha os parágrafos à direita com margem direita de 20 pontos e torna o texto vertical. A apresentação formatada é salva como `result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obter Propriedades de Estilo da Tabela**

Use [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) para ler o estilo predefinido de uma tabela e [setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) para atribuí‑lo. Este exemplo aplica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/) a uma tabela, imprime o valor predefinido e atribui o mesmo predefinido a uma segunda tabela. Ambas as tabelas são salvas em `table-style.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bloquear Proporção da Tabela**

A proporção de uma tabela é a relação entre sua largura e sua altura. Use [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) para bloquear essa proporção para uma tabela.

O exemplo abaixo abre `pres.pptx`, que deve conter ao menos um slide com uma tabela como sua primeira forma. Ele imprime o estado atual do bloqueio, habilita o bloqueio da proporção, imprime o estado atualizado (`true`) e salva o resultado como `pres-out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso habilitar a direção de leitura da direita para a esquerda (RTL) para toda a tabela e o texto em suas células?**

Sim. A tabela expõe o método [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-), e os parágrafos possuem [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Usar ambos garante a ordem RTL correta e a renderização dentro das células.

**Como posso impedir que usuários movam ou redimensionem uma tabela no arquivo final?**

Use [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) para desabilitar movimentação, redimensionamento, seleção etc. Esses bloqueios se aplicam também a tabelas.

**É suportado inserir uma imagem dentro de uma célula como plano de fundo?**

Sim. Você pode definir um [picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) para uma célula; a imagem cobrirá a área da célula de acordo com o modo escolhido (esticar ou repetir).