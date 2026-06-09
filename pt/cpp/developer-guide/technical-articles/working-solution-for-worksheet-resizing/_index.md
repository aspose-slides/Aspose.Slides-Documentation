---
title: Solução Funcional para Redimensionamento de Planilhas
type: docs
weight: 130
url: /pt/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagem de pré-visualização
- redimensionamento de imagem
- Excel
- planilha
- PowerPoint
- apresentação
- C++
- Aspose.Slides for C++
description: "Solução funcional para redimensionamento de planilhas em apresentações do PowerPoint usando C++"
---
{{% alert color="primary" %}}

Foi observado que as planilhas do Excel incorporadas como objetos OLE em uma apresentação do PowerPoint através dos componentes Aspose são redimensionadas para uma escala não identificada após a primeira ativação. Esse comportamento cria uma diferença visual perceptível na apresentação entre os estados pré‑ e pós‑ativação do objeto OLE. Investigamos esse problema em detalhe e fornecemos uma solução, que está descrita neste artigo.

{{% /alert %}}

## **Contexto**

No artigo [Gerenciar OLE](/slides/pt/cpp/manage-ole/), explicamos como adicionar uma moldura OLE a uma apresentação do PowerPoint usando Aspose.Slides para C++. Para resolver o [problema de visualização do objeto](/slides/pt/cpp/object-preview-issue-when-adding-oleobjectframe/), atribuímos uma imagem da área da planilha selecionada ao quadro do objeto OLE. Na apresentação resultante, ao dar um duplo clique no quadro do objeto OLE que exibe a imagem da planilha, a pasta de trabalho do Excel é ativada. Os usuários finais podem fazer as alterações desejadas na pasta de trabalho real do Excel e, em seguida, retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho do quadro do objeto OLE mudará quando o usuário voltar ao slide. O fator de redimensionamento variará dependendo do tamanho do quadro do objeto OLE e da pasta de trabalho do Excel incorporada.

## **Causa do Redimensionamento**

Como a pasta de trabalho do Excel possui sua própria janela, ela tenta manter seu tamanho original na primeira ativação. Por outro lado, o quadro do objeto OLE tem seu próprio tamanho. Segundo a Microsoft, quando a pasta de trabalho do Excel é ativada, Excel e PowerPoint negociam o tamanho para garantir que as proporções corretas sejam mantidas como parte do processo de incorporação. O redimensionamento ocorre com base nas diferenças entre o tamanho da janela do Excel e o tamanho e a posição do quadro do objeto OLE.

## **Solução**

Existem duas soluções possíveis para evitar o efeito de redimensionamento.

- Dimensionar o tamanho da moldura OLE na apresentação do PowerPoint para corresponder à altura e largura do número desejado de linhas e colunas na moldura OLE.
- Manter o tamanho da moldura OLE constante e dimensionar o tamanho das linhas e colunas participantes para caber dentro do tamanho da moldura OLE selecionada.

### **Dimensionar o Tamanho da Moldura OLE**

Nesta abordagem, aprenderemos como definir o tamanho da moldura OLE da pasta de trabalho do Excel incorporada para corresponder ao tamanho cumulativo das linhas e colunas participantes na planilha do Excel.

Suponha que temos uma planilha modelo do Excel e queremos adicioná‑la a uma apresentação como uma moldura OLE. Nesse cenário, o tamanho do quadro do objeto OLE será primeiro calculado com base nas alturas cumulativas das linhas e nas larguras cumulativas das colunas participantes na pasta de trabalho. Em seguida, definiremos o tamanho da moldura OLE para esse valor calculado. Para evitar a mensagem vermelha "EMBEDDED OLE OBJECT" no quadro OLE no PowerPoint, também capturaremos uma imagem das porções desejadas das linhas e colunas na pasta de trabalho e a definiremos como imagem da moldura OLE.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// We need to use the modified workbook.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Add the OLE image to the presentation resources.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

### **Dimensionar o Tamanho da Faixa de Células**

Nesta abordagem, aprenderemos como dimensionar as alturas das linhas participantes e a largura das colunas participantes para corresponder a um tamanho personalizado da moldura OLE.

Suponha que temos uma planilha modelo do Excel e queremos adicioná‑la a uma apresentação como uma moldura OLE. Nesse cenário, definiremos o tamanho da moldura OLE e dimensionaremos o tamanho das linhas e colunas que participam da área da moldura OLE. Em seguida, salvaremos a pasta de trabalho em um fluxo para aplicar as alterações e a converteremos em um array de bytes para adicioná‑la ao quadro OLE. Para evitar a mensagem vermelha "EMBEDDED OLE OBJECT" no quadro OLE no PowerPoint, também capturaremos uma imagem das porções desejadas das linhas e colunas na pasta de trabalho e a definiremos como imagem da moldura OLE.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Defina o tamanho exibido quando o arquivo da pasta de trabalho for usado como um objeto OLE no PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Dimensione a faixa de células para caber no tamanho da moldura.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Precisamos usar a pasta de trabalho modificada.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Adicione a imagem OLE aos recursos da apresentação.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Crie a moldura do objeto OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
/// <param name="width">A largura esperada da faixa de células em pontos.</param>
/// <param name="height">A altura esperada da faixa de células em pontos.</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cpp
SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

## **Conclusão**

{{% alert color="primary" %}}

Existem duas abordagens para corrigir o problema de redimensionamento da planilha. A escolha da abordagem apropriada depende dos requisitos específicos e do caso de uso. Ambas as abordagens funcionam da mesma forma, seja em apresentações criadas a partir de um modelo ou do zero. Além disso, não há limite para o tamanho do quadro do objeto OLE nesta solução.

{{% /alert %}}

## **Perguntas Frequentes**

**Por que uma planilha do Excel incorporada muda de tamanho quando é ativada pela primeira vez no PowerPoint?**

Isso acontece porque o Excel tenta manter o tamanho original da janela ao ser ativado, enquanto o quadro do objeto OLE no PowerPoint tem dimensões próprias. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**É possível impedir totalmente esse problema de redimensionamento?**

Sim. Dimensionando a moldura OLE para caber no tamanho da faixa de células do Excel ou dimensionando a faixa de células para caber no tamanho desejado da moldura OLE, você pode evitar o redimensionamento indesejado.

**Qual método de dimensionamento devo usar, dimensionamento da moldura OLE ou dimensionamento da faixa de células?**

Selecione **dimensionamento da moldura OLE** se desejar manter os tamanhos originais das linhas e colunas do Excel. Se preferir um tamanho fixo para a moldura OLE na apresentação, escolha **dimensionamento da faixa de células**.

**Essas soluções funcionarão se minha apresentação for baseada em um modelo?**

Sim. Ambas as soluções funcionam para apresentações criadas a partir de modelos e do zero.

**Existe um limite para o tamanho da moldura OLE ao usar esses métodos?**

Não. Você pode definir a moldura do objeto OLE em qualquer tamanho, contanto que ajuste a escala adequadamente.

**Há como evitar o texto de espaço reservado "EMBEDDED OLE OBJECT" no PowerPoint?**

Sim. Capturando uma captura da faixa de células do Excel alvo e definindo‑a como imagem de espaço reservado da moldura OLE, é possível exibir uma imagem de pré‑visualização personalizada em vez do texto padrão.

## **Artigos Relacionados**

[Criando um Gráfico do Excel e Incorporando‑o em uma Apresentação como um Objeto OLE](/slides/pt/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)