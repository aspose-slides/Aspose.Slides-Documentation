---
title: Gerenciar linhas e colunas em tabelas do PowerPoint no Android
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
- estilo de tabela
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Gerencie linhas e colunas de tabelas no PowerPoint com Aspose.Slides para Android via Java e acelere a edição de apresentações e a atualização de dados."
---
## **Introdução**

Para permitir que você gerencie linhas e colunas de uma tabela em uma apresentação do PowerPoint, o Aspose.Slides fornece a classe [Table](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/table/) , a interface [ITable](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITable) e muitos outros tipos.

## **Definir a Primeira Linha como Cabeçalho**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) e carregue a apresentação.
2. Obtenha a referência de um slide através de seu índice.
3. Crie um objeto [ITable] e defina-o como null.
4. Itere por todos os objetos [IShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/) para encontrar a tabela relevante.
5. Defina a primeira linha da tabela como seu cabeçalho. 

Este código Java mostra como definir a primeira linha de uma tabela como seu cabeçalho:

```java
// Instancia a classe Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // Acessa o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicializa a TableEx nula
    ITable tbl = null;

    // Itera pelos shapes e define uma referência para a tabela
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Define a primeira linha da tabela como cabeçalho
            tbl.setFirstRow(true);
        }
    }
    
    // Salva a apresentação no disco
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Clonar uma Linha ou Coluna de Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) e carregue a apresentação,
2. Obtenha a referência de um slide através de seu índice. 
3. Defina um array de `columnWidth`.
4. Defina um array de `rowHeight`.
5. Adicione um objeto [ITable] ao slide através do método [addTable](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Clone a linha da tabela.
7. Clone a coluna da tabela.
8. Salve a apresentação modificada.

Este código Java mostra como clonar a linha ou a coluna de uma tabela do PowerPoint:

```java
 // Instancia a classe Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // Acessa o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Define colunas com larguras e linhas com alturas
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Adiciona uma forma de tabela ao slide
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Adiciona algum texto à célula 1 da linha 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Adiciona algum texto à célula 2 da linha 1
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Clona a Linha 1 no final da tabela
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Adiciona algum texto à célula 1 da linha 2
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Adiciona algum texto à célula 2 da linha 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Clona a Linha 2 como a 4ª linha da tabela
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Clona a primeira coluna no final
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Clona a segunda coluna no índice da 4ª coluna
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Salva a apresentação no disco
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remover uma Linha ou Coluna de uma Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) e carregue a apresentação,
2. Obtenha a referência de um slide através de seu índice. 
3. Defina um array de `columnWidth`.
4. Defina um array de `rowHeight`.
5. Adicione um objeto [ITable] ao slide através do método [addTable](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Remova a linha da tabela.
7. Remova a coluna da tabela.
8. Salve a apresentação modificada. 

Este código Java mostra como remover uma linha ou coluna de uma tabela:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir Formatação de Texto no Nível de Linha da Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) e carregue a apresentação,
2. Obtenha a referência de um slide através de seu índice. 
3. Acesse o objeto [ITable] relevante a partir do slide.
4. Defina nas células da primeira linha o [setFontHeight(float value)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Defina nas células da primeira linha [setAlignment(int value)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) e [setMarginRight(float value)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Defina nas células da segunda linha o [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Salve a apresentação modificada.

Este código Java demonstra a operação.

```java
// Cria uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    // Vamos supor que a primeira forma no primeiro slide seja uma tabela
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // Define a altura da fonte das células da primeira linha
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // Define o alinhamento de texto e a margem direita das células da primeira linha
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Define o tipo de texto vertical das células da segunda linha
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Salva a apresentação no disco
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir Formatação de Texto no Nível de Coluna da Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) e carregue a apresentação,
2. Obtenha a referência de um slide através de seu índice. 
3. Acesse o objeto [ITable] relevante a partir do slide.
4. Defina nas células da primeira coluna o [setFontHeight(float value)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Defina nas células da primeira coluna [setAlignment(int value)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) e [setMarginRight(float value)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Defina nas células da segunda coluna o [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Salve a apresentação modificada. 

Este código Java demonstra a operação: 

```java
// Cria uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    // Vamos supor que a primeira forma no primeiro slide seja uma tabela
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // Define a altura da fonte das células da primeira coluna
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Define o alinhamento de texto e a margem direita das células da primeira coluna em uma única chamada
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Define o tipo de texto vertical das células da segunda coluna
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obter Propriedades de Estilo da Tabela**

Aspose.Slides permite que você recupere as propriedades de estilo de uma tabela para que possa usar esses detalhes em outra tabela ou em outro lugar. Este código Java mostra como obter as propriedades de estilo a partir de um estilo predefinido de tabela:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // alterar o tema padrão do preset de estilo
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas Frequentes**

**Posso aplicar temas/estilos do PowerPoint a uma tabela já criada?**

Sim. A tabela herda o tema do slide/layout/master e ainda é possível sobrescrever preenchimentos, bordas e cores de texto sobre esse tema.

**Posso classificar linhas da tabela como no Excel?**

Não, as tabelas do Aspose.Slides não possuem classificação ou filtros incorporados. Classifique seus dados na memória primeiro e, em seguida, repopule as linhas da tabela nessa ordem.

**Posso ter colunas alternadas (listradas) mantendo cores personalizadas em células específicas?**

Sim. Ative colunas alternadas e, em seguida, sobrescreva células específicas com formatação local; a formatação ao nível de célula tem precedência sobre o estilo da tabela.