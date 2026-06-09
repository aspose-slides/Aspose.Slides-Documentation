---
title: Gerenciar linhas e colunas em tabelas PowerPoint usando JavaScript
linktitle: Linhas e colunas
type: docs
weight: 20
url: /pt/nodejs-java/manage-rows-and-columns/
keywords:
- linha da tabela
- coluna da tabela
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
- estilo da tabela
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie linhas e colunas de tabelas no PowerPoint com JavaScript e Aspose.Slides para Node.js via Java e acelere a edição de apresentações e atualizações de dados."
---
## **Introdução**

Para permitir que você gerencie linhas e colunas de uma tabela em uma apresentação PowerPoint, o Aspose.Slides fornece a classe [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/table/) e outros tipos.

## **Definir a primeira linha como cabeçalho**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) e carregue a apresentação.
2. Obtenha a referência de um slide através do seu índice.
3. Crie um objeto [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table) e defina-o como nulo.
4. Percorra todos os objetos [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/) para encontrar a tabela relevante.
5. Defina a primeira linha da tabela como seu cabeçalho.

Este código JavaScript mostra como definir a primeira linha de uma tabela como seu cabeçalho:

```javascript
// Instancia a classe Presentation
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // Acessa o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Inicializa a TableEx nula
    var tbl = null;
    // Itera pelas shapes e define uma referência para a tabela
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Define a primeira linha de uma tabela como seu cabeçalho
            tbl.setFirstRow(true);
        }
    }
    // Salva a apresentação no disco
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Clonar linha ou coluna da tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) e carregue a apresentação,
2. Obtenha a referência de um slide através do seu índice.
3. Defina um array de `columnWidth`.
4. Defina um array de `rowHeight`.
5. Adicione um objeto [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table) ao slide através do método [addTable](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
6. Clone a linha da tabela.
7. Clone a coluna da tabela.
8. Salve a apresentação modificada.

Este código JavaScript mostra como clonar a linha ou coluna de uma tabela PowerPoint:

```javascript
// Instancia a classe Presentation
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // Acessa o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Define colunas com larguras e linhas com alturas
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Adiciona uma forma de tabela ao slide
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Adiciona texto à célula 1 da linha 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // Adiciona texto à célula 2 da linha 1
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // Clona a linha 1 ao final da tabela
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // Adiciona texto à célula 1 da linha 2
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // Adiciona texto à célula 2 da linha 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // Clona a linha 2 como a 4ª linha da tabela
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // Clona a primeira coluna ao final
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // Clona a 2ª coluna no índice da 4ª coluna
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // Salva a apresentação no disco
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Remover linha ou coluna da tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) e carregue a apresentação,
2. Obtenha a referência de um slide através do seu índice.
3. Defina um array de `columnWidth`.
4. Defina um array de `rowHeight`.
5. Adicione um objeto [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table) ao slide através do método [addTable](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
6. Remova a linha da tabela.
7. Remova a coluna da tabela.
8. Salve a apresentação modificada.

Este código JavaScript mostra como remover uma linha ou coluna de uma tabela:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir formatação de texto no nível da linha da tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) e carregue a apresentação,
2. Obtenha a referência de um slide através do seu índice.
3. Acesse o objeto [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table) relevante no slide.
4. Defina a [setFontHeight(float value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) das células da primeira linha.
5. Defina a [setAlignment(int value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) e a [setMarginRight(float value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) das células da primeira linha.
6. Defina a [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) das células da segunda linha.
7. Salve a apresentação modificada.

Este código JavaScript demonstra a operação.

```javascript
// Cria uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Vamos supor que a primeira forma no primeiro slide seja uma tabela
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Define a altura da fonte das células da primeira linha
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // Define o alinhamento de texto e a margem direita das células da primeira linha
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // Define o tipo vertical de texto das células da segunda linha
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // Salva a apresentação no disco
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir formatação de texto no nível da coluna da tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) e carregue a apresentação,
2. Obtenha a referência de um slide através do seu índice.
3. Acesse o objeto [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Table) relevante no slide.
4. Defina a [setFontHeight(float value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) das células da primeira coluna.
5. Defina a [setAlignment(int value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) e a [setMarginRight(float value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) das células da primeira coluna.
6. Defina a [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) das células da segunda coluna.
7. Salve a apresentação modificada.

Este código JavaScript demonstra a operação:

```javascript
// Cria uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Vamos supor que a primeira forma no primeiro slide seja uma tabela
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Define a altura da fonte das células da primeira coluna
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // Define o alinhamento de texto e a margem direita das células da primeira coluna em uma chamada
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // Define o tipo vertical de texto das células da segunda coluna
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Obter propriedades de estilo da tabela**

O Aspose.Slides permite recuperar as propriedades de estilo de uma tabela para que você possa usar esses detalhes em outra tabela ou em outro local. Este código JavaScript mostra como obter as propriedades de estilo de um estilo predefinido de tabela:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// alterar o tema de estilo predefinido padrão
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso aplicar temas/estilos do PowerPoint a uma tabela que já foi criada?**

Sim. A tabela herda o tema do slide/layout/master e você ainda pode sobrescrever preenchimentos, bordas e cores de texto sobre esse tema.

**Posso classificar linhas de tabela como no Excel?**

Não, as tabelas do Aspose.Slides não possuem classificação ou filtros integrados. Classifique seus dados na memória primeiro e, em seguida, repovoar as linhas da tabela nessa ordem.

**Posso ter colunas listradas (bandeadas) mantendo cores personalizadas em células específicas?**

Sim. Ative colunas listradas e, então, sobrescreva células específicas com formatação local; a formatação ao nível da célula tem precedência sobre o estilo da tabela.