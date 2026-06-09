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
- proporção de aspecto
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

Uma tabela no PowerPoint é uma maneira eficiente de exibir e representar informações. As informações em uma grade de células (arranjadas em linhas e colunas) são diretas e fáceis de entender.

Aspose.Slides fornece a classe [Table](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Table), a interface [ITable](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITable), a classe [Cell](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/cell/), a interface [ICell](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icell/) e outros tipos para permitir que você crie, atualize e gerencie tabelas em todos os tipos de apresentações.

## **Criar uma Tabela do Zero**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).  
2. Obtenha a referência de um slide por seu índice.  
3. Defina um array de `columnWidth`.  
4. Defina um array de `rowHeight`.  
5. Adicione um objeto [ITable](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITable) ao slide através do método [addTable](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).  
6. Percorra cada [ICell](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icell/) para aplicar formatação às bordas superior, inferior, direita e esquerda.  
7. Mescle as duas primeiras células da primeira linha da tabela.  
8. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframe/) de uma [ICell](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icell/).  
9. Adicione algum texto ao [TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframe/).  
10. Salve a apresentação modificada.

Este código Java mostra como criar uma tabela em uma apresentação:

```java
// Instancia uma classe Presentation que representa um arquivo PPTX
Presentation pres = new Presentation();
try {
    // Acessa o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Define colunas com larguras e linhas com alturas
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Adiciona uma forma de tabela ao slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Define o formato da borda para cada célula
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
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
    // Mescla as células 1 e 2 da linha 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Adiciona texto à célula mesclada
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Salva a apresentação no disco
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numeração em uma Tabela Padrão**

Em uma tabela padrão, a numeração das células é direta e baseada em zero. A primeira célula de uma tabela tem índice 0,0 (coluna 0, linha 0).

Por exemplo, as células de uma tabela com 4 colunas e 4 linhas são numeradas da seguinte forma:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código Java mostra como especificar a numeração das células em uma tabela:

```java
// Instancia uma classe Presentation que representa um arquivo PPTX
Presentation pres = new Presentation();
try {
    // Acessa o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Define colunas com larguras e linhas com alturas
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Adiciona uma forma de tabela ao slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Define o formato da borda para cada célula
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

    // Salva a apresentação no disco
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acessar uma Tabela Existente**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).  

2. Obtenha a referência ao slide que contém a tabela por seu índice.  

3. Crie um objeto [ITable](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITable) e atribua null a ele.  

4. Percorra todos os objetos [IShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/) até que a tabela seja encontrada.  

   Se você suspeitar que o slide contém uma única tabela, pode simplesmente verificar todas as formas que ele contém. Quando uma forma for identificada como tabela, você pode convertê‑la para um objeto [Table](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Table). Mas se o slide contiver várias tabelas, é melhor procurar a tabela necessária através de seu [setAlternativeText(String value)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).  

5. Use o objeto [ITable](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITable) para trabalhar com a tabela. No exemplo abaixo, adicionamos uma nova linha à tabela.  

6. Salve a apresentação modificada.

Este código Java mostra como acessar e trabalhar com uma tabela existente:

```java
// Instancia a classe Presentation que representa um arquivo PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Acessa o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicializa a TableEx como null
    ITable tbl = null;

    // Percorre as formas e define uma referência para a tabela encontrada
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Define o texto para a primeira coluna da segunda linha
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Salva a apresentação modificada no disco
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alinhar Texto em uma Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).  
2. Obtenha a referência de um slide por seu índice.  
3. Adicione um objeto [ITable](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITable) ao slide.  
4. Acesse um objeto [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) da tabela.  
5. Acesse o [IParagraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/) do [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/).  
6. Alinhe o texto verticalmente.  
7. Salve a apresentação modificada.

Este código Java mostra como alinhar o texto em uma tabela:

```java
// Cria uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    // Obtém o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Define colunas com larguras e linhas com alturas
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Adiciona a forma de tabela ao slide
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Acessa o quadro de texto
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Cria o objeto Paragraph para o quadro de texto
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Cria o objeto Portion para o parágrafo
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Alinha o texto verticalmente
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Salva a apresentação no disco
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir Formatação de Texto no Nível da Tabela**

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).  
2. Obtenha a referência de um slide por seu índice.  
3. Acesse um objeto [ITable](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITable) do slide.  
4. Defina o [setFontHeight(float value)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) para o texto.  
5. Defina o [setAlignment(int value)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) e o [setMarginRight(float value)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Defina o [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Salve a apresentação modificada.

Este código Java mostra como aplicar suas opções de formatação preferidas ao texto em uma tabela:

```java
// Cria uma instância da classe Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Vamos supor que a primeira forma no primeiro slide seja uma tabela
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Define a altura da fonte das células da tabela
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Define o alinhamento do texto das células da tabela e a margem direita em uma única chamada
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Define o tipo vertical do texto das células da tabela
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obter Propriedades de Estilo da Tabela**

Aspose.Slides permite que você recupere as propriedades de estilo de uma tabela para que possa usar esses detalhes em outra tabela ou em outro local. Este código Java mostra como obter as propriedades de estilo de um estilo de tabela predefinido:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // alterar o tema de preset de estilo padrão 
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bloquear Proporção de Aspecto de uma Tabela**

A proporção de aspecto de um objeto geométrico é a relação entre seus tamanhos em diferentes dimensões. Aspose.Slides fornece a propriedade [**setAspectRatioLocked**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) para permitir que você bloqueie a configuração de proporção de aspecto para tabelas e outras formas.

Este código Java mostra como bloquear a proporção de aspecto de uma tabela:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // inverter

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso habilitar a direção de leitura da direita para a esquerda (RTL) para uma tabela inteira e o texto em suas células?**

Sim. A tabela expõe o método [setRightToLeft](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-), e os parágrafos possuem [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Usar ambos garante a ordem RTL correta e a renderização dentro das células.

**Como posso impedir que os usuários movam ou redimensionem uma tabela no documento final?**

Use bloqueios de forma para desativar mover, redimensionar, selecionar etc. Esses bloqueios se aplicam também às tabelas.

**É suportado inserir uma imagem dentro de uma célula como plano de fundo?**

Sim. Você pode definir um [picture fill](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/picturefillformat/) para uma célula; a imagem cobrirá a área da célula de acordo com o modo escolhido (esticar ou repetir).