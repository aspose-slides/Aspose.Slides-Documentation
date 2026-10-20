---
title: Solução Funcional para Redimensionamento de Gráficos em PPTX
type: docs
weight: 60
url: /pt/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionamento de gráfico
- gráfico do Excel
- objeto OLE
- incorporar gráfico
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Corrija o redimensionamento inesperado de gráficos em PPTX ao usar objetos OLE do Excel incorporados com Aspose.Slides para C++. Defina dimensões fixas para o gráfico para manter os tamanhos do gráfico e da moldura OLE consistentes."
---
## **Contexto**

Gráficos do Excel incorporados como objetos OLE em apresentações do PowerPoint usando componentes Aspose podem mudar de tamanho após sua primeira ativação. Isso pode causar uma diferença perceptível na aparência do gráfico antes e depois da ativação. Este artigo explica por que o redimensionamento ocorre e mostra como evitá‑lo combinando dimensões fixas do gráfico com a moldura OLE.

Em [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/pt/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos como criar um gráfico do Excel com Aspose.Cells para C++ e incorporá‑lo em uma apresentação do PowerPoint usando Aspose.Slides para C++. Para resolver o [object preview issue](/slides/pt/cpp/object-preview-issue-when-adding-oleobjectframe/), atribuimos a imagem do gráfico à moldura do objeto OLE do gráfico. Na apresentação de saída, ao clicar duas vezes na moldura do objeto OLE que exibe a imagem do gráfico, o gráfico do Excel é ativado. Os usuários podem editar a pasta de trabalho do Excel incorporada e, em seguida, retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho da moldura do objeto OLE muda quando o usuário retorna ao slide, e o fator de redimensionamento varia dependendo dos tamanhos originais tanto da moldura do objeto OLE quanto da pasta de trabalho do Excel incorporada.

## **Causa do Redimensionamento**

O workbook do Excel incorporado tem suas próprias dimensões de janela, que o Excel tenta manter quando o objeto é ativado pela primeira vez. A moldura OLE no slide tem dimensões definidas independentemente. Quando o workbook do Excel é ativado, Excel e PowerPoint negociam o tamanho do objeto para manter suas proporções como parte do processo de incorporação. Diferenças entre a janela do workbook e a moldura OLE podem, portanto, causar o redimensionamento do objeto.

## **Solução Funcional**

Combine o tamanho do gráfico com a moldura OLE no slide e mantenha as dimensões do gráfico independentes da janela do workbook. Esta solução funciona com uma nova apresentação ou um modelo existente.

O exemplo requer Aspose.Cells para C++ e Aspose.Slides para C++. Ele cria um gráfico de colunas simples em uma planilha de gráfico ativa e incorpora a pasta de trabalho no formato XLS. Nenhuma imagem de pré‑visualização do gráfico é atribuída; o gráfico se torna visível quando o objeto OLE é ativado no PowerPoint.

Coloque o código de exemplo no ponto de entrada da aplicação, com as declarações de inclusão no escopo de arquivo. Inicialize Aspose.Cells antes de criar seus objetos e libere seus recursos depois que esses objetos forem destruídos. O exemplo copia o vetor de bytes da pasta de trabalho retornado por Aspose.Cells para o tipo de array aceito por Aspose.Slides.

O exemplo cria uma nova apresentação com uma moldura OLE de 9.5 × 4 polegadas posicionada a 0.5 polegada da borda esquerda e 1 polegada do topo. As coordenadas e dimensões do slide estão em pontos (72 pontos por polegada). Para uma apresentação existente, veja [Use a Template](#use-a-template).

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // As coordenadas e dimensões do slide estão em pontos (72 pontos por polegada).
    auto width = 684.f; // 9,5 polegadas.
    auto height = 288.f; // 4 polegadas.

    chart.SetSizeWithWindow(false);
    // Converter pontos para pixels do gráfico usando 96 pixels por polegada.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Copiar o vetor de bytes do Cells para o tipo de array aceito pelo Slides.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **Defina um Tamanho Fixo para o Gráfico**

Defina [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) como false para que as dimensões do gráfico sejam independentes da janela do workbook. Defina as dimensões do [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) através de [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) e [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/), convertendo pontos para pixels usando 96 pixels por polegada: uma moldura que mede 684 × 288 pontos corresponde a um gráfico que mede 912 × 384 pixels. Defina [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) para o valor Custom de [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/). O exemplo incorpora a pasta de trabalho com [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) e salva uma apresentação com uma moldura OLE de 9.5 × 4 polegadas.

## **Usar um Modelo**

A lógica de dimensionamento é a mesma para uma apresentação existente. Para adaptar o exemplo:

1. Carregue a apresentação modelo em vez de criar uma apresentação vazia.  
1. Verifique se o primeiro slide contém pelo menos três formas e, então, use a forma no índice 2 como o marcador de posição.  
1. Obtenha a largura e a altura da moldura a partir dessa forma em vez de usar os valores fixos 684 e 288. Mantenha os cálculos de dimensionamento inalterados.  
1. Adicione a moldura OLE na posição do marcador de posição em vez das coordenadas fixas 36 e 72.  
1. Remova o marcador de posição antes de salvar a apresentação.

## **Perguntas Frequentes**

**Por que meu gráfico do Excel incorporado muda de tamanho após ser ativado no PowerPoint?**

Isso ocorre porque o Excel tenta restaurar o tamanho original da janela quando ativado pela primeira vez, enquanto a moldura do objeto OLE no PowerPoint tem suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**Como posso manter os tamanhos do gráfico e da moldura OLE consistentes?**

Defina dimensões fixas para o gráfico que correspondam à moldura OLE e use um tamanho de impressão de gráfico personalizado antes de incorporar a pasta de trabalho. O exemplo acima mostra as configurações necessárias e as conversões de unidades.

**A correspondência do tamanho da janela do workbook é suficiente?**

A correspondência apenas do tamanho da janela do workbook não impede de forma confiável que a moldura OLE mude de tamanho após a ativação. Use dimensões fixas para o gráfico conforme mostrado no exemplo.

**Esta solução funciona tanto com apresentações baseadas em modelo quanto com novas apresentações?**

Sim. Para um modelo, use as dimensões e a posição do marcador de posição. Para uma nova apresentação, especifique diretamente as dimensões e a posição da moldura.

**Posso usar este exemplo com gráficos criados em outros programas de planilha?**

O exemplo usa uma pasta de trabalho do Excel criada com Aspose.Cells. Ele não demonstra o comportamento de ativação para outros programas de planilha.

## **Seções Relacionadas**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/pt/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)