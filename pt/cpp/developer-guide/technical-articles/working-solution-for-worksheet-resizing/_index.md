---
title: Solução funcional para redimensionamento de planilhas
type: docs
weight: 130
url: /pt/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagem de visualização
- redimensionamento de imagem
- Excel
- planilha
- PowerPoint
- apresentação
- C++
- Aspose.Slides for C++
description: "Solução funcional para redimensionamento de planilhas em apresentações do PowerPoint usando C++"
---
{{% alert color="info" %}}

Foi observado que as planilhas do Excel incorporadas como objetos OLE em uma apresentação do PowerPoint por meio dos componentes Aspose são redimensionadas para uma escala não identificada após a primeira ativação. Esse comportamento cria uma diferença visual perceptível na apresentação entre os estados pré‑ e pós‑ativação do objeto OLE. Investigamos esse problema em detalhe e fornecemos uma solução, apresentada neste artigo.

{{% /alert %}}

## **Contexto**

No artigo [Manage OLE](/slides/pt/cpp/manage-ole/), explicamos como adicionar uma moldura OLE a uma apresentação do PowerPoint usando Aspose.Slides for C++. Para resolver o [object preview issue](/slides/pt/cpp/object-preview-issue-when-adding-oleobjectframe/), atribuimos uma imagem da área da planilha selecionada à moldura do objeto OLE. Na apresentação gerada, ao dar um duplo clique na moldura OLE que exibe a imagem da planilha, a pasta de trabalho do Excel é ativada. Os usuários podem fazer as alterações desejadas na pasta de trabalho real do Excel e, em seguida, retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho da moldura OLE mudará quando o usuário voltar ao slide. O fator de redimensionamento variará conforme o tamanho da moldura OLE e da pasta de trabalho incorporada.

## **Causa do Redimensionamento**

Como a pasta de trabalho do Excel possui seu próprio tamanho de janela, ela tenta manter seu tamanho original na primeira ativação. Por outro lado, a moldura OLE tem seu próprio tamanho. Segundo a Microsoft, quando a pasta de trabalho do Excel é ativada, Excel e PowerPoint negociam o tamanho para garantir que ele mantenha as proporções corretas como parte do processo de incorporação. O redimensionamento ocorre com base nas diferenças entre o tamanho da janela do Excel e o tamanho e a posição da moldura OLE.

## **Solução Funcional**

Existem duas soluções possíveis para evitar o efeito de redimensionamento.

- Dimensionar o tamanho da moldura OLE na apresentação do PowerPoint para corresponder à altura e largura do número desejado de linhas e colunas na moldura OLE.
- Manter o tamanho da moldura OLE constante e dimensionar o tamanho das linhas e colunas participantes para que se encaixem na moldura OLE selecionada.

### **Dimensionar o Tamanho da Moldura OLE**

Nesta abordagem, aprenderemos como definir o tamanho da moldura OLE da pasta de trabalho do Excel incorporada para corresponder ao tamanho cumulativo das linhas e colunas participantes na planilha do Excel.

Suponha que tenhamos uma planilha modelo do Excel e queiramos adicioná‑la a uma apresentação como uma moldura OLE. Nesse cenário, o tamanho da moldura do objeto OLE será primeiro calculado com base nas alturas cumulativas das linhas e nas larguras cumulativas das colunas das linhas e colunas participantes na pasta de trabalho. Em seguida, definiremos o tamanho da moldura OLE para esse valor calculado. Para evitar a mensagem vermelha “EMBEDDED OLE OBJECT” para a moldura OLE no PowerPoint, também capturaremos uma imagem das partes desejadas das linhas e colunas na pasta de trabalho e a definiremos como imagem da moldura OLE.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/image.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Definir o tamanho exibido quando o arquivo da pasta de trabalho é usado como objeto OLE no PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Obter a largura e a altura da imagem OLE em pontos.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// Precisamos usar a pasta de trabalho modificada.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Adicionar a imagem OLE aos recursos da apresentação.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Criar a moldura do objeto OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"
using namespace System;
using namespace System::IO;

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

Nesta abordagem, aprenderemos como dimensionar as alturas das linhas participantes e a largura das colunas participantes para corresponder a um tamanho de moldura OLE personalizado.

Suponha que tenhamos uma planilha modelo do Excel e queiramos adicioná‑la a uma apresentação como uma moldura OLE. Nesse cenário, definiremos o tamanho da moldura OLE e dimensionaremos o tamanho das linhas e colunas que participam da área da moldura OLE. Em seguida, salvaremos a pasta de trabalho em um fluxo para aplicar as alterações e convertê‑la em um array de bytes para adicioná‑la à moldura OLE. Para evitar a mensagem vermelha “EMBEDDED OLE OBJECT” para a moldura OLE no PowerPoint, também capturaremos uma imagem das partes desejadas das linhas e colunas na pasta de trabalho e a definiremos como imagem da moldura OLE.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Definir o tamanho exibido quando o arquivo da pasta de trabalho é usado como objeto OLE no PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Dimensionar a faixa de células para caber no tamanho da moldura.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Precisamos usar a pasta de trabalho modificada.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Adicionar a imagem OLE aos recursos da apresentação.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Criar a moldura do objeto OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

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
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"
using namespace System;
using namespace System::IO;

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

{{% alert color="info" %}}

Existem duas abordagens para corrigir o problema de redimensionamento da planilha. A escolha da abordagem adequada depende dos requisitos específicos e do caso de uso. Ambas as abordagens funcionam da mesma forma, tanto para apresentações criadas a partir de um modelo quanto para apresentações criadas do zero. Além disso, não há limite para o tamanho da moldura OLE nesta solução.

{{% /alert %}}

## **FAQ**

### Por que uma planilha do Excel incorporada muda de tamanho quando é ativada pela primeira vez no PowerPoint?

Isso ocorre porque o Excel tenta manter o tamanho original da janela ao ser ativado, enquanto a moldura OLE no PowerPoint tem suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

### É possível impedir esse problema de redimensionamento completamente?

Sim. Dimensionando a moldura OLE para se adequar ao tamanho da faixa de células do Excel ou dimensionando a faixa de células para se adequar ao tamanho desejado da moldura OLE, é possível impedir o redimensionamento indesejado.

### Qual método de dimensionamento devo usar, dimensionamento da moldura OLE ou dimensionamento da faixa de células?

Escolha **dimensionamento da moldura OLE** se quiser manter os tamanhos originais das linhas e colunas do Excel. Escolha **dimensionamento da faixa de células** se quiser um tamanho fixo para a moldura OLE na sua apresentação.

### Essas soluções funcionam se minha apresentação for baseada em um modelo?

Sim. Ambas as soluções funcionam para apresentações criadas a partir de modelos e do zero.

### Existe um limite para o tamanho da moldura OLE ao usar esses métodos?

Não. Você pode definir a moldura OLE com qualquer tamanho, contanto que ajuste a escala adequadamente.

### Há como evitar o texto de espaço reservado “EMBEDDED OLE OBJECT” no PowerPoint?

Sim. Capturando uma captura de tela da faixa de células do Excel de destino e definindo‑a como imagem de espaço reservado da moldura OLE, você pode exibir uma imagem de pré‑visualização personalizada em vez do espaço reservado padrão.

## **Artigos Relacionados**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/pt/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)