---
title: Criar ou Atualizar Gráficos de Apresentação PowerPoint em JavaScript
linktitle: Criar ou Atualizar Gráficos
type: docs
weight: 10
url: /pt/nodejs-java/create-chart/
keywords:
- adicionar gráfico
- criar gráfico
- editar gráfico
- alterar gráfico
- atualizar gráfico
- gráfico de dispersão
- gráfico de pizza
- gráfico de linhas
- gráfico de mapa de árvore
- gráfico de ações
- gráfico de caixa e bigodes
- gráfico em funil
- gráfico Sunburst
- gráfico de histograma
- gráfico de radar
- gráfico de múltiplas categorias
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Crie e personalize gráficos em apresentações PowerPoint com Aspose.Slides para Node.js. Adicione, formate e edite gráficos com exemplos práticos de código em JavaScript."
---
## **Visão geral**

Este artigo fornece um guia completo sobre como criar e personalizar gráficos usando Aspose.Slides. Você aprenderá como adicionar programaticamente um gráfico a um slide, preenchê‑lo com dados e aplicar várias opções de formatação para atender aos requisitos de design específicos. Ao longo do artigo, exemplos de código detalhados ilustram cada etapa, desde a inicialização da apresentação e do objeto de gráfico até a configuração de séries, eixos e legendas. Seguindo este guia, você obterá uma compreensão sólida de como integrar a geração dinâmica de gráficos em suas aplicações, simplificando o processo de criação de apresentações baseadas em dados.

## **Criar gráfico**
Os gráficos ajudam as pessoas a visualizar rapidamente os dados e obter insights, que podem não ser imediatamente óbvios em uma tabela ou planilha. 


**Por que criar gráficos?**

Com os gráficos, você pode

* agregar, condensar ou resumir grandes quantidades de dados em um único slide de uma apresentação
* expor padrões e tendências nos dados
* deduzir a direção e o impulso dos dados ao longo do tempo ou em relação a uma unidade de medida específica 
* identificar outliers, aberrações, desvios, erros, dados sem sentido, etc. 
* comunicar ou apresentar dados complexos

No PowerPoint, você pode criar gráficos através da função Inserir, que fornece modelos usados para projetar diversos tipos de gráficos. Usando Aspose.Slides, você pode criar gráficos regulares (baseados em tipos populares de gráficos) e gráficos personalizados. 

{{% alert color="primary" %}} 

Para permitir que você crie gráficos, Aspose.Slides fornece a classe [ChartType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartType). Os campos desta classe correspondem a diferentes tipos de gráficos.

{{% /alert %}} 

### **Criando gráficos normais**

_Steps: Create Chart_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Steps:</em> Create PowerPoint Chart in JavaScript</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Steps:</em> Create Presentation Chart in JavaScript</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Chart in JavaScript</strong></a>

_Code Steps:_

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através de seu índice.
3. Adicione um gráfico com alguns dados e especifique o tipo de gráfico desejado. 
4. Adicione um título ao gráfico. 
5. Acesse a planilha de dados do gráfico. 
6. Limpe todas as séries e categorias padrão. 
7. Adicione novas séries e categorias. 
8. Adicione novos dados ao gráfico para as séries. 
9. Defina uma cor de preenchimento para as séries do gráfico. 
10. Adicione rótulos para as séries do gráfico. 
11. Grave a apresentação modificada como um arquivo PPTX. 

Este código JavaScript mostra como criar um gráfico normal:

```javascript
// Instancia uma classe de apresentação que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Acessa o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Adiciona um gráfico com seus dados padrão
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Define o título do gráfico
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // Define a primeira série para mostrar valores
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Define o índice para a planilha de dados do gráfico
    var defaultWorksheetIndex = 0;
    // Obtém a planilha de dados do gráfico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Exclui as séries e categorias geradas por padrão
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Adiciona novas séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Adiciona novas categorias
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Obtém a primeira série do gráfico
    var series = chart.getChartData().getSeries().get_Item(0);
    // Agora preenche os dados da série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Define a cor de preenchimento para a série
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Obtém a segunda série do gráfico
    series = chart.getChartData().getSeries().get_Item(1);
    // Preenche os dados da série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Define a cor de preenchimento para a série
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Cria rótulos personalizados para cada categoria da nova série
    // Define o primeiro rótulo para mostrar o nome da categoria
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Mostra o valor para o terceiro rótulo
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Salva a apresentação com o gráfico
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Criando gráficos de dispersão**
Os gráficos de dispersão (também conhecidos como diagramas de dispersão ou gráficos x‑y) são frequentemente usados para verificar padrões ou demonstrar correlações entre duas variáveis. 

Você pode querer usar um gráfico de dispersão quando 

* possuir dados numéricos emparelhados
* possuir duas variáveis que se combinam bem
* quiser determinar se duas variáveis estão relacionadas
* tiver uma variável independente que possui múltiplos valores para uma variável dependente

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Steps:</em> Create Scattered Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Steps:</em> Create PowerPoint Scattered Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Scattered Chart in JavaScript</strong></a>

1. Siga as etapas mencionadas acima em [Creating Normal Charts](#creating-normal-charts)
2. No terceiro passo, adicione um gráfico com alguns dados e especifique seu tipo de gráfico como um dos seguintes  
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Representa um Gráfico de Dispersão._  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Representa um Gráfico de Dispersão conectado por curvas, com marcadores de dados._  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Representa um Gráfico de Dispersão conectado por curvas, sem marcadores de dados._  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Representa um Gráfico de Dispersão conectado por linhas, com marcadores de dados._  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Representa um Gráfico de Dispersão conectado por linhas, sem marcadores de dados._  

Este código JavaScript mostra como criar gráficos de dispersão com diferentes séries de marcadores:

```javascript
// Instancia uma classe de apresentação que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Acessa o primeiro slide
    var slide = pres.getSlides().get_Item(0);
    // Cria o gráfico padrão
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Obtém o índice da planilha de dados padrão do gráfico
    var defaultWorksheetIndex = 0;
    // Obtém a planilha de dados do gráfico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Exclui as séries de demonstração
    chart.getChartData().getSeries().clear();
    // Adiciona novas séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Obtém a primeira série do gráfico
    var series = chart.getChartData().getSeries().get_Item(0);
    // Adiciona um novo ponto (1:3) à série
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Adiciona um novo ponto (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Altera o tipo da série
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Altera o marcador da série do gráfico
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // Obtém a segunda série do gráfico
    series = chart.getChartData().getSeries().get_Item(1);
    // Adiciona um novo ponto (5:2) lá
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // Adiciona um novo ponto (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // Adiciona um novo ponto (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // Adiciona um novo ponto (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // Altera o marcador da série do gráfico
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Criando gráficos de pizza**

Os gráficos de pizza são mais adequados para mostrar a relação parte‑para‑todo nos dados, especialmente quando os dados contêm rótulos categóricos com valores numéricos. No entanto, se seus dados contiverem muitas partes ou rótulos, considere usar um gráfico de barras em vez disso.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Steps:</em> Create Pie Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Steps:</em> Create PowerPoint Pie Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Pie Chart in JavaScript</strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation). 
2. Obtenha a referência de um slide pelo seu índice. 
3. Adicione um gráfico com dados padrão junto ao tipo desejado (neste caso, [ChartType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartType).Pie). 
4. Acesse os dados do gráfico através de [ChartDataWorkbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartDataWorkbook). 
5. Limpe as séries e categorias padrão. 
6. Adicione novas séries e categorias. 
7. Adicione novos dados ao gráfico para as séries. 
8. Adicione novos pontos ao gráfico e defina cores personalizadas para os setores do gráfico de pizza. 
9. Defina rótulos para as séries. 
10. Defina linhas de ligação para os rótulos das séries. 
11. Defina o ângulo de rotação para os slides do gráfico de pizza. 
12. Grave a apresentação modificada em um arquivo PPTX. 

Este código JavaScript mostra como criar um gráfico de pizza:

```javascript
// Instancia uma classe de apresentação que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Acessa o primeiro slide
    var slides = pres.getSlides().get_Item(0);
    // Adiciona um gráfico com dados padrão
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Define o título do gráfico
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Define a primeira série para mostrar valores
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Define o índice para a planilha de dados do gráfico
    var defaultWorksheetIndex = 0;
    // Obtém a planilha de dados do gráfico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Exclui as séries e categorias geradas por padrão
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Adiciona novas categorias
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Adiciona novas séries
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Preenche os dados da série
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Não funciona na nova versão
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Define a borda do setor
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Define a borda do setor
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Define a borda do setor
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
    // Cria rótulos personalizados para cada categoria da nova série
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // Exibe linhas de ligação para o gráfico
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Define o ângulo de rotação para os setores do gráfico de pizza
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Salva a apresentação com um gráfico
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Criando gráficos de linhas**

Os gráficos de linhas (também conhecidos como gráficos de linha) são mais adequados quando você deseja demonstrar alterações de valor ao longo do tempo. Usando um gráfico de linhas, você pode comparar muitos dados de uma só vez, acompanhar mudanças e tendências ao longo do tempo, destacar anomalias em séries de dados, etc.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation). 
1. Obtenha a referência de um slide pelo seu índice. 
1. Adicione um gráfico com dados padrão junto ao tipo desejado (neste caso, `ChartType.Line`). 
1. Acesse os dados do gráfico através de IChartDataWorkbook. 
1. Limpe as séries e categorias padrão. 
1. Adicione novas séries e categorias. 
1. Adicione novos dados ao gráfico para as séries. 
1. Grave a apresentação modificada em um arquivo PPTX. 

Este código JavaScript mostra como criar um gráfico de linhas:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Por padrão, os pontos em um gráfico de linhas são ligados por linhas retas contínuas. Se quiser que os pontos sejam ligados por traços, especifique o tipo de traço desejado desta forma:

```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```

### **Criando gráficos de árvore (Tree Map)**

Os gráficos de árvore são mais adequados para dados de vendas quando você deseja mostrar o tamanho relativo das categorias de dados e, ao mesmo tempo, chamar rapidamente a atenção para itens que são grandes contribuintes de cada categoria. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Steps:</em> Create Tree Map Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Steps:</em> Create PowerPoint Tree Map Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Tree Map Chart in JavaScript</strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation). 
2. Obtenha a referência de um slide pelo seu índice. 
3. Adicione um gráfico com dados padrão junto ao tipo desejado (neste caso, [ChartType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartType).TreeMap). 
4. Acesse os dados do gráfico através de [ChartDataWorkbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartDataWorkbook). 
5. Limpe as séries e categorias padrão. 
6. Adicione novas séries e categorias. 
7. Adicione novos dados ao gráfico para as séries. 
8. Grave a apresentação modificada em um arquivo PPTX. 

Este código JavaScript mostra como criar um gráfico de árvore:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // ramo 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // ramo 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Criando gráficos de ações (Stock)**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Steps:</em> Create Stock Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Steps:</em> Create PowerPoint Stock Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Stock Chart in JavaScript</strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation). 
2. Obtenha a referência de um slide pelo seu índice. 
3. Adicione um gráfico com dados padrão junto ao tipo desejado ([ChartType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartType).OpenHighLowClose). 
4. Acesse os dados do gráfico através de [ChartDataWorkbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartDataWorkbook). 
5. Limpe as séries e categorias padrão. 
6. Adicione novas séries e categorias. 
7. Adicione novos dados ao gráfico para as séries. 
8. Especifique o formato HiLowLines. 
9. Grave a apresentação modificada em um arquivo PPTX. 

Exemplo de código JavaScript usado para criar um gráfico de ações:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);
  
    var wb = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));
    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));
    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));
    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));
    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Criando gráficos de caixa e bigodes (Box and Whisker)**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Steps:</em> Create Box and Whisker Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Steps:</em> Create PowerPoint Box and Whisker Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Box and Whisker Chart in JavaScript</strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation). 
2. Obtenha a referência de um slide pelo seu índice. 
3. Adicione um gráfico com dados padrão junto ao tipo desejado ([ChartType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartType).BoxAndWhisker). 
4. Acesse os dados do gráfico através de [ChartDataWorkbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartDataWorkbook). 
5. Limpe as séries e categorias padrão. 
6. Adicione novas séries e categorias. 
7. Adicione novos dados ao gráfico para as séries. 
8. Grave a apresentação modificada em um arquivo PPTX. 

Este código JavaScript mostra como criar um gráfico de caixa e bigodes:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Criando gráficos em funil (Funnel)**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Steps:</em> Create Funnel Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Steps:</em> Create PowerPoint Funnel Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Funnel Chart in JavaScript</strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation). 
2. Obtenha a referência de um slide pelo seu índice. 
3. Adicione um gráfico com dados padrão junto ao tipo desejado ([ChartType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartType).Funnel). 
4. Grave a apresentação modificada em um arquivo PPTX. 

O código JavaScript mostra como criar um gráfico em funil:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Criando gráficos Sunburst**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Steps:</em> Create Sunburst Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Steps:</em> Create PowerPoint Sunburst Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Sunburst Chart in JavaScript</strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation). 
2. Obtenha a referência de um slide pelo seu índice. 
3. Adicione um gráfico com dados padrão junto ao tipo desejado (neste caso, [ChartType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartType).sunburst). 
4. Grave a apresentação modificada em um arquivo PPTX. 

Este código JavaScript mostra como criar um gráfico Sunburst:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // ramo 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // ramo 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Criando gráficos de histograma**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Steps:</em> Create Histogram Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Steps:</em> Create PowerPoint Histogram Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Histogram Chart in JavaScript</strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation). 
2. Obtenha a referência de um slide pelo seu índice. 
3. Adicione um gráfico com dados padrão junto ao tipo desejado ([ChartType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartType).Histogram). 
4. Acesse os dados do gráfico através de [ChartDataWorkbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartDataWorkbook). 
5. Limpe as séries e categorias padrão. 
6. Adicione novas séries e categorias. 
7. Grave a apresentação modificada em um arquivo PPTX. 

Este código JavaScript mostra como criar um gráfico de histograma:

```javascript
var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **Criando gráficos de radar**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Steps:</em> Create Radar Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Steps:</em> Create PowerPoint Radar Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Radar Chart in JavaScript</strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation). 
2. Obtenha a referência de um slide pelo seu índice. 
3. Adicione um gráfico com alguns dados e especifique seu tipo de gráfico preferido (`ChartType.Radar` neste caso). 
4. Grave a apresentação modificada em um arquivo PPTX. 

Este código JavaScript mostra como criar um gráfico de radar:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Criando gráficos de múltiplas categorias**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Steps:</em> Create Multi Category Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Steps:</em> Create PowerPoint Multi Category Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Multi Category Chart in JavaScript</strong></a>

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation). 
2. Obtenha a referência de um slide pelo seu índice. 
3. Adicione um gráfico com dados padrão junto ao tipo desejado ([ChartType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartType).ClusteredColumn). 
4. Acesse os dados do gráfico através de [ChartDataWorkbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartDataWorkbook). 
5. Limpe as séries e categorias padrão. 
6. Adicione novas séries e categorias. 
7. Adicione novos dados ao gráfico para as séries. 
8. Grave a apresentação modificada em um arquivo PPTX. 

Este código JavaScript mostra como criar um gráfico de múltiplas categorias:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));
    // Adicionando Série
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // Salvar apresentação com gráfico
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Criando gráficos de mapa**

Um gráfico de mapa é uma visualização de uma área contendo dados. Gráficos de mapa são mais adequados para comparar dados ou valores entre regiões geográficas.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Steps:</em> Create Map Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Steps:</em> Create PowerPoint Map Chart in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Map Chart in JavaScript</strong></a>

Este código JavaScript mostra como criar um gráfico de mapa:

```javascript
let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Criando gráficos combinados**

Um gráfico combinado (ou combo) combina dois ou mais tipos de gráficos em um único diagrama. Esse gráfico permite que você destaque, compare ou examine diferenças entre dois ou mais conjuntos de dados, ajudando a identificar relações entre eles.

![The combination chart](combination_chart.png)

O código JavaScript a seguir mostra como criar o gráfico combinado exibido acima em uma apresentação PowerPoint:

```js
function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Definir o título do gráfico.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Definir a legenda do gráfico.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Excluir as séries e categorias geradas por padrão.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Adicionar novas categorias.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Adicionar a primeira série.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // Definir o eixo horizontal.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Definir o eixo vertical.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Definir a cor das linhas de grade principais verticais.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // Definir o eixo horizontal secundário.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Definir o eixo vertical secundário.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **Atualizando gráficos**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Steps:</em> Update PowerPoint Chart in JavaScript</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Steps:</em> Update Presentation Chart in JavaScript</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Steps:</em> Update PowerPoint Presentation Chart in JavaScript</strong></a>

1. Instancie uma classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) que representa a apresentação contendo o gráfico que você deseja atualizar.
2. Obtenha a referência de um slide usando seu índice.
3. Percorra todas as formas para localizar o gráfico desejado.
4. Acesse a planilha de dados do gráfico.
5. Modifique os dados da série do gráfico alterando os valores da série.
6. Adicione uma nova série e preencha os dados nela.
7. Grave a apresentação modificada como um arquivo PPTX.

Este código JavaScript mostra como atualizar um gráfico:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Acessar o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Obter gráfico com dados padrão
    var chart = sld.getShapes().get_Item(0);
    // Definir o índice da planilha de dados do gráfico
    var defaultWorksheetIndex = 0;
    // Obter a planilha de dados do gráfico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Alterar o nome da categoria do gráfico
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Obter a primeira série do gráfico
    var series = chart.getChartData().getSeries().get_Item(0);
    // Agora atualizando os dados da série
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Modificando o nome da série
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Obter a segunda série do gráfico
    series = chart.getChartData().getSeries().get_Item(1);
    // Agora atualizando os dados da série
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Modificando o nome da série
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Agora, adicionando uma nova série
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Obter a terceira série do gráfico
    series = chart.getChartData().getSeries().get_Item(2);
    // Agora preenchendo os dados da série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Salvar a apresentação com o gráfico
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definindo intervalo de dados para gráficos**

Para definir o intervalo de dados de um gráfico, faça o seguinte:

1. Instancie uma classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) que representa a apresentação contendo o gráfico.
2. Obtenha a referência de um slide pelo seu índice.
3. Percorra todas as formas para localizar o gráfico desejado.
4. Acesse os dados do gráfico e defina o intervalo.
5. Salve a apresentação modificada como um arquivo PPTX.

Este código JavaScript mostra como definir o intervalo de dados de um gráfico:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Usando marcadores padrão em gráficos**
Quando você usa um marcador padrão em gráficos, cada série de gráfico recebe automaticamente símbolos de marcador diferentes.

Este código JavaScript mostra como definir automaticamente um marcador de série de gráfico:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Obter a segunda série do gráfico
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Agora preenchendo os dados da série
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Quais tipos de gráficos são suportados pelo Aspose.Slides?**

Aspose.Slides suporta uma ampla variedade de tipos de gráficos, incluindo barra, linha, pizza, área, dispersão, histograma, radar e muitos outros. Essa flexibilidade permite escolher o tipo de gráfico mais adequado às suas necessidades de visualização de dados.

**Como adiciono um novo gráfico a um slide?**

Para adicionar um gráfico, primeiro crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) , recupere o slide desejado usando seu índice e, em seguida, chame o método para adicionar um gráfico, especificando o tipo de gráfico e os dados iniciais. Esse processo integra o gráfico diretamente à sua apresentação.

**Como posso atualizar os dados exibidos em um gráfico?**

Você pode atualizar os dados de um gráfico acessando sua planilha de dados ([ChartDataWorkbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdataworkbook/)), limpando quaisquer séries e categorias padrão e, então, adicionando seus próprios dados personalizados. Isso permite atualizar programaticamente o gráfico para refletir os dados mais recentes.

**É possível personalizar a aparência do gráfico?**

Sim, Aspose.Slides oferece amplas opções de personalização. Você pode modificar cores, fontes, rótulos, legendas e outros elementos de formatação para adaptar a aparência do gráfico aos requisitos de design específicos.