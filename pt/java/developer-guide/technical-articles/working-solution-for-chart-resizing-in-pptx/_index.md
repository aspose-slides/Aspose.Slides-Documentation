---
title: Solução Funcional para Redimensionamento de Gráficos em PPTX
type: docs
weight: 40
url: /pt/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionamento de gráfico
- gráfico do Excel
- objeto OLE
- incorporar gráfico
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Corrija o redimensionamento inesperado de gráficos em PPTX ao usar objetos OLE do Excel incorporados com Aspose.Slides para Java. Aprenda dois métodos com código para manter os tamanhos consistentes."
---
## **Contexto**

Observou‑se que gráficos do Excel incorporados como objetos OLE em uma apresentação do PowerPoint através dos componentes Aspose são redimensionados para uma escala não especificada após sua primeira ativação. Esse comportamento causa uma diferença visual perceptível na apresentação entre os estados antes e depois da ativação do gráfico. A equipe da Aspose investigou o problema em detalhe e encontrou uma solução. Este artigo descreve as causas do problema e a correção correspondente.

No [artigo anterior](/slides/pt/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos como criar um gráfico do Excel com Aspose.Cells para Java e incorporá‑lo em uma apresentação do PowerPoint usando Aspose.Slides para Java. Para resolver o [problema de visualização de objeto](/slides/pt/java/object-preview-issue-when-adding-oleobjectframe/), atribuimos a imagem do gráfico ao quadro de objeto OLE do gráfico. Na apresentação resultante, ao clicar duas vezes no quadro de objeto OLE que exibe a imagem do gráfico, o gráfico do Excel é ativado. Os usuários finais podem fazer as alterações desejadas na pasta de trabalho do Excel subjacente e, em seguida, voltar ao slide correspondente clicando fora da pasta de trabalho ativada. O tamanho do quadro de objeto OLE muda quando o usuário retorna ao slide, e o fator de redimensionamento varia dependendo dos tamanhos originais tanto do quadro de objeto OLE quanto da pasta de trabalho do Excel incorporada.

## **Causa do Redimensionamento**

Como a pasta de trabalho do Excel tem seu próprio tamanho de janela, ela tenta manter seu tamanho original na primeira ativação. O quadro de objeto OLE, porém, possui seu próprio tamanho. De acordo com a Microsoft, quando a pasta de trabalho do Excel é ativada, Excel e PowerPoint negociam o tamanho e mantêm as proporções corretas como parte do processo de incorporação. Dependendo das diferenças entre o tamanho da janela do Excel e o tamanho ou posição do quadro de objeto OLE, ocorre o redimensionamento.

## **Solução Funcional**

Existem dois cenários possíveis para criar apresentações do PowerPoint usando Aspose.Slides para Java.

**Cenário 1:** Criar uma apresentação a partir de um modelo existente.

**Cenário 2:** Criar uma apresentação do zero.

A solução que apresentamos aqui se aplica a ambos os cenários. O fundamento de todas as abordagens de solução é o mesmo: **o tamanho da janela do objeto OLE incorporado deve corresponder ao quadro de objeto OLE no slide do PowerPoint**. Agora discutiremos as duas abordagens para essa solução.

## **Primeira Abordagem**

Nesta abordagem, aprenderemos como definir o tamanho da janela da pasta de trabalho do Excel incorporada de modo que corresponda ao tamanho do quadro de objeto OLE no slide do PowerPoint.

**Cenário 1**

Suponha que tenhamos definido um modelo e queremos criar apresentações com base nele. Imagine que haja uma forma no índice 2 do modelo onde desejamos colocar um quadro OLE contendo uma pasta de trabalho do Excel incorporada. Nesse cenário, o tamanho do quadro de objeto OLE está predefinido—corresponde ao tamanho da forma no índice 2 do modelo. Tudo o que precisamos fazer é definir o tamanho da janela da pasta de trabalho igual ao tamanho dessa forma. O trecho de código a seguir cumpre esse propósito:

```java
// Defina a largura da janela da pasta de trabalho em polegadas (dividida por 576, pois o PowerPoint usa 576 pixels por polegada).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Defina a altura da janela da pasta de trabalho em polegadas.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Salve a pasta de trabalho em um stream de memória.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crie um quadro de objeto OLE com os dados do Excel incorporados.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Cenário 2**

Digamos que queiramos criar uma apresentação do zero e incluir um quadro de objeto OLE de qualquer tamanho com uma pasta de trabalho do Excel incorporada. No trecho de código a seguir, criamos um quadro de objeto OLE com 4 polegadas de altura e 9,5 polegadas de largura em x = 0,5 polegadas e y = 1 polegada no slide. Em seguida, definimos a janela da pasta de trabalho do Excel com o mesmo tamanho—4 polegadas de altura e 9,5 polegadas de largura.

```java
// Nossa altura desejada.
int desiredHeight = 288; // 4 polegadas (4 * 72)
 
// Nossa largura desejada.
int desiredWidth = 684; // 9,5 polegadas (9,5 * 72)
 
// Defina o tamanho do gráfico com uma janela.
chart.setSizeWithWindow(true);
 
// Defina a largura da janela da pasta de trabalho em polegadas (dividida por 576, pois o PowerPoint usa 576 pixels por polegada).
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// Defina a altura da janela da pasta de trabalho em polegadas.
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// Salve a pasta de trabalho em um stream de memória.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crie um quadro de objeto OLE com os dados do Excel incorporados.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Segunda Abordagem**

Nesta abordagem, aprenderemos como definir o tamanho do gráfico na pasta de trabalho do Excel incorporada para que corresponda ao tamanho do quadro de objeto OLE no slide do PowerPoint. Essa abordagem é útil quando o tamanho do gráfico é conhecido antecipadamente e nunca mudará.

**Cenário 1**

Suponha que tenhamos definido um modelo e queremos criar apresentações com base nele. Imagine que haja uma forma no índice 2 do modelo onde pretendemos colocar um quadro OLE contendo uma pasta de trabalho do Excel incorporada. Nesse cenário, o tamanho do quadro OLE está predefinido—correspondendo ao tamanho da forma no índice 2 do modelo. Tudo o que precisamos fazer é definir o tamanho do gráfico na pasta de trabalho igual ao tamanho da forma. O trecho de código a seguir cumpre esse propósito:

```java
// Defina o tamanho do gráfico sem janela.
chart.setSizeWithWindow(false);
 
// Defina a largura do gráfico em pixels (multiplique por 96, pois o Excel usa 96 pixels por polegada).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Defina a altura do gráfico em pixels.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Defina o tamanho de impressão do gráfico.
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// Salve a pasta de trabalho em um stream de memória.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crie um quadro de objeto OLE com os dados do Excel incorporados.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Cenário 2**:

Suponha que queiramos criar uma apresentação do zero e incluir um quadro de objeto OLE de qualquer tamanho com uma pasta de trabalho do Excel incorporada. No trecho de código a seguir, criamos um quadro de objeto OLE com altura de 4 polegadas e largura de 9,5 polegadas no slide em x = 0,5 polegadas e y = 1 polegada. Também definimos o tamanho do gráfico correspondente às mesmas dimensões: altura de 4 polegadas e largura de 9,5 polegadas.

```java
// Nossa altura desejada.
int desiredHeight = 288; // 4 polegadas (4 * 72)
 
// Nossa largura desejada.
int desiredWidth = 684; // 9,5 polegadas (9,5 * 72)
 
// Defina o tamanho do gráfico sem janela.
chart.setSizeWithWindow(false);
 
// Defina a largura do gráfico em pixels (multiplique por 96, pois o Excel usa 96 pixels por polegada).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// Defina a altura do gráfico em pixels.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// Salve a pasta de trabalho em um stream de memória.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crie um quadro de objeto OLE com os dados do Excel incorporados.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Conclusão**

Existem duas abordagens para corrigir o problema de redimensionamento do gráfico. A escolha da abordagem depende dos requisitos e do caso de uso. Ambas as abordagens funcionam da mesma forma, seja em apresentações criadas a partir de um modelo ou criadas do zero. Além disso, não há limite para o tamanho do quadro de objeto OLE nessa solução.

## **Perguntas Frequentes**

**Por que o gráfico do Excel incorporado muda de tamanho após ser ativado no PowerPoint?**

Isso acontece porque o Excel tenta restaurar o tamanho original da janela na primeira ativação, enquanto o quadro de objeto OLE no PowerPoint tem dimensões próprias. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**É possível impedir completamente esse problema de redimensionamento?**

Sim. Ao fazer com que o tamanho da janela da pasta de trabalho do Excel ou o tamanho do gráfico correspondam ao tamanho do quadro de objeto OLE antes da incorporação, você pode manter os tamanhos dos gráficos consistentes.

**Qual abordagem devo usar, definir o tamanho da janela da pasta de trabalho ou definir o tamanho do gráfico?**

Use **Abordagem 1 (tamanho da janela)** se quiser manter a proporção da pasta de trabalho e possibilitar redimensionamento futuro.  
Use **Abordagem 2 (tamanho do gráfico)** se as dimensões do gráfico forem fixas e não mudarem após a incorporação.

**Esses métodos funcionam tanto com apresentações baseadas em modelo quanto com apresentações novas?**

Sim. Ambas as abordagens funcionam da mesma forma para apresentações criadas a partir de modelos e para apresentações criadas do zero.

**Existe um limite para o tamanho do quadro de objeto OLE?**

Não. Você pode definir o quadro OLE em qualquer tamanho, contanto que ele seja dimensionado adequadamente em relação ao tamanho da pasta de trabalho ou do gráfico.

**Posso usar esses métodos com gráficos criados em outros programas de planilha?**

Os exemplos são projetados para gráficos do Excel criados com Aspose.Cells, mas os princípios se aplicam a outros programas de planilha compatíveis com OLE, desde que ofereçam opções de dimensionamento semelhantes.

## **Seções Relacionadas**

- [Criar Gráficos do Excel e Incorporá‑los como Objetos OLE em Apresentações](/slides/pt/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Atualizar Objetos OLE Automaticamente Usando um Add‑In do PowerPoint](/slides/pt/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)