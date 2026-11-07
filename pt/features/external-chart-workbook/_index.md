---
title: Vincular gráficos a workbooks externos
description: Vincular dados do gráfico a um workbook externo e atualizá-los.
type: docs
url: /pt/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **Visão geral**

Aponte um gráfico para uma pasta de trabalho externa em vez de manter todos os dados de origem incorporados na apresentação. Você pode definir o caminho da pasta de trabalho e escolher se atualiza o gráfico a partir desse arquivo. O gráfico salvo também pode conter dados de exibição em cache.

## **Exemplo de uso**

Este exemplo C# usa Aspose.Slides for .NET. Crie uma pasta de trabalho de vendas válida com Norte = 55 e Sul = 40 e grave-a como sales.xlsx ao lado da saída. Redefina o valor Norte do gráfico para 20, então vincule o gráfico ao caminho absoluto da pasta de trabalho e atualize: Norte volta a ser 55. O intervalo explícito cobre o cabeçalho e duas linhas de dados. Mantenha sales.xlsx disponível ao reabrir ou atualizar o gráfico vinculado; a apresentação não incorpora esse arquivo externo. Nenhum arquivo de entrada é necessário. Ele salva *external-chart-workbook.pptx* e *external-chart-workbook.png*. Instale a biblioteca usando o [guia de instalação](/slides/pt/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **FAQ**

### **Posso ler todos os valores em cache quando o arquivo vinculado está ausente?**

Aspose.Slides for .NET 26.11 pode [ler valores de gráfico armazenados diretamente](/slides/pt/net/chart-workbook/#read-cached-chart-values-without-a-workbook) sem abrir a pasta de trabalho vinculada. Isso inclui valores ordinários, valores X/Y, tamanhos de bolhas e valores de categoria quando esses caches existem. Dados em cache podem estar ausentes ou desatualizados; não constituem uma pasta de trabalho completa. Atualizar a partir da origem ainda requer uma pasta de trabalho suportada disponível. Para outros SDKs e versões, verifique o guia de gráfico correspondente.

### **O que acontece se a pasta de trabalho externa for movida?**

Atualize o caminho da pasta de trabalho externa do gráfico para sua nova localização e torne esse arquivo disponível onde a apresentação for processada. Não confie nos dados em cache para operações de acesso total aos dados quando ele estiver ausente.

### **Posso escolher se devo atualizar os dados de gráfico em cache ao vincular?**

Sim. Escolha se atualiza os dados do gráfico ao definir o vínculo. Atualizar requer uma pasta de trabalho suportada disponível; pular a atualização registra o vínculo sem ler novos valores desse arquivo.

## **Guias**

- [Gerenciar workbooks de gráficos em apresentações no .NET](/slides/pt/net/chart-workbook/)

Funcionalidade relacionada: [Preencher gráficos editáveis com dados](/slides/pt/features/chart-data-binding/).