---
title: Criar Gráficos do Excel e Incorporá-los em Apresentações como Objetos OLE
type: docs
weight: 40
url: /pt/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Gráfico do Excel
- incorporar gráfico
- objeto OLE
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Crie gráficos do Excel e incorpore-os como objetos OLE em apresentações PowerPoint e OpenDocument usando C++. Guia passo a passo com exemplos de código."
---
## **Contexto**

Em PowerPoint, usar gráficos editáveis para exibir dados graficamente é uma prática comum. Aspose oferece suporte à criação de gráficos do Excel com Aspose.Cells for C++, e esses gráficos podem ser incorporados como objetos OLE em slides do PowerPoint através do Aspose.Slides for C++. Este artigo aborda as etapas necessárias e fornece exemplos de código C++ para criar um gráfico do Excel e incorporá‑lo como objeto OLE em uma apresentação PowerPoint usando Aspose.Cells e Aspose.Slides.

## **Passos Necessários**

A sequência de etapas a seguir é necessária para criar e incorporar um gráfico do Excel como objeto OLE em um slide do PowerPoint:

1. Criar um gráfico do Excel usando Aspose.Cells.
1. Definir o tamanho OLE do gráfico do Excel usando Aspose.Cells.
1. Obter uma imagem do gráfico do Excel com Aspose.Cells.
1. Incorporar o gráfico do Excel como um objeto OLE em uma apresentação PPTX usando Aspose.Slides.
1. Substituir a imagem "EMBEDDED OLE OBJECT" pela imagem obtida na etapa 3 para resolver o [object preview issue](/slides/pt/cpp/object-preview-issue-when-adding-oleobjectframe/).
1. Salvar a apresentação no disco no formato PPTX.

## **Implementação dos Passos Necessários**

A implementação em C++ dos passos acima é a seguinte:

```cpp
// Etapa - 1: Criar um gráfico do Excel usando Aspose.Cells.
// ---------------------------------------------------
// Create a workbook.
intrusive_ptr<Aspose::Cells::IWorkbook> workbook = Aspose::Cells::Factory::CreateIWorkbook();
// Add an Excel chart.
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Etapa - 2: Definir o tamanho OLE do gráfico usando Aspose.Cells.
// -----------------------------------------------------------
workbook->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);

// Etapa - 3: Obter a imagem do gráfico com Aspose.Cells.
// -------------------------------------------------------
System::SharedPtr<System::Drawing::Bitmap> chartImage = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
// Save the workbook to a stream.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

// Etapa - 4 E 5
// =============
// Etapa - 4: Incorporar o gráfico como um objeto OLE dentro de uma apresentação .ppt usando Aspose.Slides.
// ------------------------------------------------------------------------------------------
// Etapa - 5: Substituir a imagem "EMBEDDED OLE OBJECT" pela imagem obtida na etapa 3 para resolver o Problema de Visualização do Objeto.
// --------------------------------------------------------------------------------------------------------------------
// Create a presentation.
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);
// Add the workbook to the slide.
AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

// Etapa - 6: Salvar a apresentação de saída no disco.
// -----------------------------------------------
presentation->Save(u"OutputChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

```cpp
void AddExcelChartInPresentation(System::SharedPtr<Presentation> presentation, System::SharedPtr<ISlide> slide, 
                                 System::SharedPtr<System::IO::Stream> workbookStream, 
                                 intrusive_ptr<Aspose::Cells::Systems::Drawing::Bitmap> chartImage)
{
    float oleWidth = presentation->get_SlideSize()->get_Size().get_Width();
    float oleHeight = presentation->get_SlideSize()->get_Size().get_Height();
    int32_t x = 0;
    System::ArrayPtr<uint8_t> oleData = System::MakeArray<uint8_t>(workbookStream->get_Length(), 0);
    workbookStream->set_Position(0);
    workbookStream->Read(oleData, 0, oleData->get_Length());

    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(oleData, u"xls");
    System::SharedPtr<IOleObjectFrame> oleFrame;
    oleFrame = slide->get_Shapes()->AddOleObjectFrame(static_cast<float>(x), 0.0f, oleWidth, oleHeight, dataInfo);

    intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
    chartImage->Save(cellsOutputStream, Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetBmp());

    auto slidesImage = Images::FromStream(ToSlidesMemoryStream(cellsOutputStream));
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(slidesImage));
}
```

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
int32_t AddExcelChartInWorkbook(intrusive_ptr<Aspose::Cells::IWorkbook> workbook, int32_t chartRows, int32_t chartCols)
{
    // Um array de nomes de células.
    System::ArrayPtr<System::String> cellNames = System::MakeArray<System::String>(
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    });
    
    // Um array de dados das células.
    System::ArrayPtr<int32_t> cellValues = System::MakeArray<int32_t>(
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    });

    // Adicionar uma nova planilha para preencher células com dados.
    int32_t dataSheetIndex = workbook->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIndex);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // Preencher a planilha de dados com valores.
    for (int32_t i = 0; i < cellNames->get_Length(); i++)
    {
        System::String cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // Adicionar uma planilha de gráfico.
    int32_t chartSheetIndex = workbook->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex);
    chartSheet->SetName(new String("ChartSheet"));

    // Adicionar um gráfico à planilha de gráfico com séries de dados da planilha de dados.
    int32_t chartIndex = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIndex);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // Definir a planilha de gráfico como planilha ativa.
    workbook->GetIWorksheets()->SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

A apresentação criada pelo método acima conterá o gráfico do Excel como um objeto OLE que pode ser ativado ao clicar duas vezes na moldura do objeto OLE.

## **Conclusão**

Usando Aspose.Cells for C++ junto com Aspose.Slides for C++, podemos criar qualquer gráfico do Excel suportado pelo Aspose.Cells e incorporá‑lo como objeto OLE em um slide do PowerPoint. O tamanho OLE do gráfico do Excel também pode ser definido. Os usuários finais podem então editar o gráfico do Excel como qualquer outro objeto OLE.

## **Seções Relacionadas**

- [Solução Funcionando para Redimensionamento de Gráficos em PPTX](/slides/pt/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Problema de Visualização de Objeto ao Adicionar OleObjectFrame](/slides/pt/cpp/object-preview-issue-when-adding-oleobjectframe/)