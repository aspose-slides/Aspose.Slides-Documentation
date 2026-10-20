---
title: Criar gráficos do Excel e incorporá-los em apresentações como objetos OLE
type: docs
weight: 50
url: /pt/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Gráfico do Excel
- incorporar gráfico
- objeto OLE
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Crie um gráfico do Excel com Aspose.Cells for .NET e incorpore a pasta de trabalho em uma apresentação do PowerPoint com Aspose.Slides, incluindo uma visualização do gráfico."
---
## **Visão geral**

Este artigo mostra como criar um gráfico de colunas do Excel com Aspose.Cells for .NET e incorporar sua pasta de trabalho em uma apresentação do PowerPoint com Aspose.Slides for .NET. A pasta de trabalho incorporada contém tanto os dados de origem quanto o gráfico. Uma visualização PNG separada exibe o gráfico no slide antes que o objeto OLE seja ativado.

O resultado é um objeto Excel incorporado, não um gráfico nativo do PowerPoint. Editar a pasta de trabalho através do OLE requer um aplicativo desktop que suporte ativação OLE e uma instalação compatível do Excel.

## **Pré-requisitos**

Adicione referências ao Aspose.Cells for .NET e ao Aspose.Slides for .NET no seu projeto C#. O exemplo usa declarações de nível superior e requer C# 9 ou posterior. O Microsoft Office não é necessário para gerar a apresentação com essas bibliotecas.

Nenhum arquivo de entrada é necessário: o exemplo cria os dados e o gráfico na memória, depois grava `OutputChart.pptx` no diretório de trabalho atual. Aplique licenças para ambos os produtos ao executar fora do modo de avaliação.

## **Como a incorporação funciona**

1. Crie uma pasta de trabalho com uma planilha de dados e uma planilha de gráfico.  
2. Torne a planilha de gráfico a ativa para que a pasta de trabalho abra no gráfico.  
3. Defina o intervalo de exibição OLE da pasta de trabalho e renderize o gráfico para PNG.  
4. Salve a pasta de trabalho como XLSX na memória e incorpore esses bytes em um slide.  
5. Atribua o PNG como a visualização do objeto OLE e salve a apresentação como PPTX.

O intervalo de exibição da pasta de trabalho e a moldura no slide têm funções diferentes. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) recebe índices de linha e coluna inicial/final baseados em zero. [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) em vez disso recebe a linha superior, coluna esquerda, linha inferior e coluna direita. O exemplo usa o índice de linha 55 e o índice de coluna 25 como limites inferiores direitos; esses valores são escolhas de layout, não o número de linhas ou colunas de dados.

A moldura do slide usa pontos. O exemplo ajusta-a dentro do slide e a centraliza preservando a proporção do PNG, em vez de esticar a visualização para preencher o slide.

## **Criar e incorporar o gráfico**

O exemplo completo a seguir preenche `DataSheet` com quatro linhas e cinco colunas de valores. Cada linha se torna uma série de gráfico. `ChartSheet` é selecionada como a planilha ativa antes de a pasta de trabalho ser salva.

A pasta de trabalho é salva explicitamente como XLSX, correspondendo à extensão `xlsx` passada para [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/). O PNG é carregado diretamente de seu stream sem uma conversão intermediante de bitmap. Atribuí‑lo através de [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) substitui o placeholder OLE padrão.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// Renderize a visualização do gráfico e serialize a pasta de trabalho editável separadamente.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Ajuste a visualização dentro do slide sem alterar sua proporção.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Resultado esperado**

`OutputChart.pptx` contém um slide com uma pasta de trabalho Excel incorporada e uma visualização do gráfico. A pasta de trabalho contém os dados originais e um gráfico de colunas com quatro séries. A visualização está centralizada no slide e mantém suas proporções.

![Gráfico de colunas do Excel exibido como visualização de uma pasta de trabalho incorporada](excel-chart-ole-preview.png)

Em um ambiente desktop PowerPoint compatível com Excel disponível, clique duas vezes no objeto para ativar e editar a pasta de trabalho incorporada. A ativação e a edição dependem do suporte OLE do aplicativo host e das configurações de segurança.

## **Perguntas frequentes**

**Por que é necessária uma imagem de visualização?**  
A pasta de trabalho incorporada e sua visualização no slide são conteúdos separados. Forneça uma imagem do gráfico para que o slide mostre o gráfico em vez do placeholder padrão "EMBEDDED OLE OBJECT". Veja [Problema de visualização de objeto ao adicionar OleObjectFrame](/slides/pt/net/object-preview-issue-when-adding-oleobjectframe/).

**A visualização é atualizada automaticamente quando altero a pasta de trabalho no código?**  
Considere a visualização como uma captura. Ao atualizar os dados da pasta de trabalho programaticamente, regenere a imagem do gráfico e substitua a visualização assim como os dados da pasta de trabalho incorporada.

**Posso usar XLS em vez de XLSX?**  
Sim. Salve a pasta de trabalho no formato XLS e use `xls` como a extensão dos dados incorporados. A extensão deve corresponder ao formato real da pasta de trabalho; mudar apenas a extensão não converte os dados.

**Por que o objeto pode mudar de tamanho após a ativação?**  
O aplicativo host pode atualizar a apresentação do objeto OLE ao ativar a pasta de trabalho. O intervalo de exibição OLE da pasta de trabalho e as dimensões da moldura do slide são importantes. Veja [Solução funcional para redimensionamento de gráfico em PPTX](/slides/pt/net/working-solution-for-chart-resizing-in-pptx/).

## **Seções relacionadas**

- [Solução funcional para redimensionamento de gráfico em PPTX](/slides/pt/net/working-solution-for-chart-resizing-in-pptx/)
- [Problema de visualização de objeto ao adicionar OleObjectFrame](/slides/pt/net/object-preview-issue-when-adding-oleobjectframe/)
- [Atualizar objetos OLE automaticamente usando um complemento PowerPoint](/slides/pt/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)