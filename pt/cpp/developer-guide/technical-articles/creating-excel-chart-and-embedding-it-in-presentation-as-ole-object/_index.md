---
title: Criar gráficos do Excel e incorporá-los em apresentações como objetos OLE
type: docs
weight: 40
url: /pt/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Gráfico do Excel
- Incorporar gráfico
- Objeto OLE
- PowerPoint
- Apresentação
- C++
- Aspose.Slides
description: "Crie um gráfico do Excel com Aspose.Cells para C++ e incorpore a pasta de trabalho em uma apresentação do PowerPoint com Aspose.Slides, incluindo uma visualização do gráfico."
---
## **Visão geral**

Este artigo mostra como criar um gráfico de colunas do Excel com Aspose.Cells for C++ e incorporar sua pasta de trabalho em uma apresentação do PowerPoint com Aspose.Slides for C++. A pasta de trabalho incorporada contém tanto os dados de origem quanto o gráfico. Uma visualização PNG separada exibe o gráfico no slide antes que o objeto OLE seja ativado.

O resultado é um objeto Excel incorporado, e não um gráfico nativo do PowerPoint. Editar a pasta de trabalho via OLE requer um aplicativo desktop que ofereça suporte à ativação OLE e uma instalação compatível do Excel.

## **Pré‑requisitos**

Configure seu projeto C++ com os cabeçalhos e bibliotecas do Aspose.Cells for C++ e do Aspose.Slides for C++. Coloque o código de exemplo no ponto de entrada da sua aplicação, com as declarações de inclusão em escopo de arquivo. O Microsoft Office não é necessário para gerar a apresentação com essas bibliotecas.

Nenhum arquivo de entrada é necessário: o exemplo cria os dados e o gráfico na memória e, em seguida, grava `OutputChart.pptx` no diretório de trabalho atual. Aplique licenças para ambos os produtos ao executar fora do modo de avaliação.

## **Como a incorporação funciona**

1. Crie uma pasta de trabalho com uma planilha de dados e uma planilha de gráfico.  
1. Torne a planilha de gráfico a ativa para que a pasta de trabalho seja aberta no gráfico.  
1. Defina o intervalo de exibição OLE da pasta de trabalho e renderize o gráfico em PNG.  
1. Salve a pasta de trabalho como XLSX na memória e incorpore esses bytes em um slide.  
1. Atribua o PNG como visualização do objeto OLE e salve a apresentação como PPTX.

O intervalo de exibição da pasta de trabalho e a moldura no slide têm papéis diferentes. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) recebe índices de linha e coluna de início/fim baseados em zero. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) recebe, em vez disso, a linha superior, a coluna esquerda, a linha inferior e a coluna direita. O exemplo usa o índice de linha 55 e o índice de coluna 25 como limites inferiores direitos; esses valores são escolhas de layout, não o número de linhas ou colunas de dados.

A moldura do slide usa pontos. O exemplo a ajusta dentro do slide e a centraliza preservando a proporção do PNG, em vez de esticar a visualização para preencher o slide.

## **Criar e incorporar o gráfico**

O exemplo completo a seguir preenche `DataSheet` com quatro linhas e cinco colunas de valores. Cada linha se torna uma série do gráfico. `ChartSheet` é selecionado como a planilha ativa antes de salvar a pasta de trabalho.

A pasta de trabalho é salva explicitamente como XLSX, correspondendo à extensão `xlsx` passada para [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/). O PNG é carregado de um fluxo em memória sem conversão intermediária para bitmap. Aspose.Cells retorna vetores de bytes, que o exemplo copia para o tipo de array aceito pelo Aspose.Slides. Inicialize Aspose.Cells antes de usar seus objetos e libere seus recursos depois que esses objetos forem destruídos. Atribuir através de [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) substitui o placeholder OLE padrão.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// Inicialize Cells antes de criar quaisquer de seus objetos.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // Renderize a visualização do gráfico e serialize a pasta de trabalho editável separadamente.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Copie os buffers do Cells para o tipo de array usado pelo Slides.
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // Ajuste a visualização dentro do slide sem alterar sua proporção.
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// Libere os recursos do Cells após todos os objetos Cells terem sido destruídos.
Aspose::Cells::Cleanup();
```

## **Resultado esperado**

`OutputChart.pptx` contém um slide com uma pasta de trabalho Excel incorporada e uma visualização do gráfico. A pasta de trabalho contém os dados originais e um gráfico de colunas com quatro séries. A visualização está centralizada no slide e mantém suas proporções.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

Em um ambiente desktop compatível do PowerPoint com Excel disponível, clique duas vezes no objeto para ativar e editar a pasta de trabalho incorporada. A ativação e a edição dependem do suporte OLE do aplicativo host e das configurações de segurança.

## **Perguntas frequentes**

**Por que uma imagem de visualização é necessária?**

A pasta de trabalho incorporada e sua visualização no slide são conteúdos distintos. Forneça uma imagem do gráfico para que o slide mostre o gráfico em vez do placeholder padrão “EMBEDDED OLE OBJECT”. Veja [Problema de visualização do objeto ao adicionar OleObjectFrame](/slides/pt/cpp/object-preview-issue-when-adding-oleobjectframe/).

**A visualização é atualizada automaticamente quando eu altero a pasta de trabalho no código?**

Trate a visualização como uma captura instantânea. Ao atualizar os dados da pasta de trabalho programaticamente, regenere a imagem do gráfico e substitua a visualização, bem como os dados da pasta de trabalho incorporada.

**Posso usar XLS em vez de XLSX?**

Sim. Salve a pasta de trabalho no formato XLS e use `xls` como a extensão de dados incorporada. A extensão deve corresponder ao formato real da pasta de trabalho; alterar apenas a extensão não converte os dados.

**Por que o objeto pode mudar de tamanho após a ativação?**

O aplicativo host pode atualizar a apresentação do objeto OLE quando ativa a pasta de trabalho. Tanto o intervalo de exibição OLE da pasta de trabalho quanto as dimensões da moldura do slide são relevantes. Veja [Solução funcional para redimensionamento de gráfico em PPTX](/slides/pt/cpp/working-solution-for-chart-resizing-in-pptx/).

## **Seções relacionadas**

- [Solução funcional para redimensionamento de gráfico em PPTX](/slides/pt/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Problema de visualização do objeto ao adicionar OleObjectFrame](/slides/pt/cpp/object-preview-issue-when-adding-oleobjectframe/)