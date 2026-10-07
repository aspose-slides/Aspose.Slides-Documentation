---
title: Gerenciar células de tabela em apresentações usando C++
linktitle: Gerenciar células
type: docs
weight: 30
url: /pt/cpp/manage-cells/
keywords:
- célula de tabela
- mesclar células
- remover borda
- dividir célula
- imagem na célula
- cor de fundo
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Gerencie células de tabela do PowerPoint em C++: identifique células mescladas, remova bordas, divida células e defina cores de fundo e imagens com Aspose.Slides para C++."
---
## **Visão geral**

Aspose.Slides permite acessar e modificar células de tabela em apresentações do PowerPoint. Este artigo explica como identificar células de tabela mescladas, remover bordas das células, trabalhar com a numeração de células após mesclar ou dividir células, alterar a cor de fundo de uma célula e adicionar uma imagem dentro de uma célula de tabela. Os exemplos mostram como criar ou abrir uma apresentação, obter uma tabela de um slide, atualizar a formatação da célula através das propriedades da célula e salvar a apresentação modificada como um arquivo PPTX.

Aspose.Slides usa índices baseados em zero para acessar células de tabela na ordem `(column, row)`.

## **Identificar uma célula de tabela mesclada**

O exemplo abre uma apresentação existente e acessa a primeira forma no primeiro slide como uma tabela. Assume que o slide e a forma existem e que a forma é uma tabela. Em seguida, itera por todas as linhas e colunas e usa [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) para identificar células em regiões mescladas. Para cada correspondência, ele imprime as coordenadas da célula na ordem `row;column`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), e as coordenadas iniciais da região, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) e [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **Remover bordas de células de tabela**

Crie uma [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) e adicione uma tabela ao seu primeiro slide com [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). As larguras das colunas, alturas das linhas e a posição da tabela são especificadas em pontos. O exemplo define todas as quatro bordas da célula como [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), tornando-as invisíveis.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Mesclar células de tabela**

Use [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) para combinar um intervalo retangular de células de tabela em uma única célula. Especifique as células nos cantos superior esquerdo e inferior direito do intervalo. O argumento final controla se a mesclagem pode incluir células fora do intervalo especificado; `false` mantém a mesclagem dentro desse intervalo.

O exemplo cria uma tabela 4x4 com colunas e linhas de 70 pontos, então mescla as quatro células centrais de `(1, 1)` até `(2, 2)`. A célula resultante abrange duas colunas e duas linhas, enquanto a grade subjacente da tabela mantém quatro colunas e quatro linhas. Para acessar o conteúdo ou a formatação da célula mesclada, use sua posição superior esquerda: `table->idx_get(1, 1)` neste exemplo. As outras posições no intervalo mesclado permanecem parte da grade da tabela, de modo que os índices das células fora do intervalo não mudam.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **Dividir células de tabela**

Mesclar células no exemplo anterior preserva a grade da tabela. Dividir uma célula pode introduzir uma nova coluna na grade e alterar os índices de coluna das células à sua direita. Aspose.Slides segue o modelo de grade de tabela do PowerPoint.

Este exemplo cria uma tabela 4x4 com colunas e linhas de 70 pontos e chama [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) na célula `(1, 1)`. Metade da largura de 70 pontos da célula é usada para criar duas células de largura igual.

Após essa divisão, as duas metades são acessadas como `table->idx_get(1, 1)` e `table->idx_get(2, 1)`. A grade da tabela agora possui cinco colunas: células originalmente nas colunas 2 e 3 movem-se para as colunas 3 e 4, respectivamente. Os índices de linha permanecem inalterados. Use esses índices de coluna atualizados ao acessar células após a divisão.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```

### **Dividir células mescladas por extensão de linha ou coluna**

Para preparar células mescladas de modelo para preenchimento de dados, use [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) para dividir ao longo de uma fronteira de linha existente, ou [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) para dividir ao longo de uma fronteira de coluna.

O argumento `index` conta linhas na parte superior ou colunas na parte esquerda da divisão; ele é relativo à região mesclada:
- Divisão por linha: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Divisão por coluna: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

O exemplo pressupõe que uma apresentação tenha uma tabela como a primeira forma no primeiro slide, com `(1, 2)` e `(1, 3)` mesclados verticalmente. Começando a partir da posição inferior, ele usa [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) e [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) para localizar a origem e verifica ambas as extensões. `SplitByRowSpan(1)` então separa as linhas 2 e 3 para os nomes dos produtos. Para uma mesclagem horizontal de duas colunas, use `SplitByColSpan(1)`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // Recupere as células resultantes da tabela após a divisão.
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

A grade da tabela e os índices das células ao redor permanecem inalterados. Recupere as células resultantes por suas coordenadas; aqui, ambas têm extensão 1 e [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) imprime `False`. Regiões maiores podem permanecer parcialmente mescladas após uma divisão.

O texto original e sua formatação permanecem na célula superior (ou esquerda); a nova célula está vazia, mas herda a formatação da célula, como preenchimento, bordas e margens. Preencha as células após a divisão e defina explicitamente qualquer formatação de texto necessária.

A apresentação salva contém células separadas "Product A" e "Product B" com a formatação da célula do modelo mantida. Consulte a [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) para obter detalhes.

## **Alterar a cor de fundo da célula da tabela**

Este exemplo cria uma tabela com colunas de 150 pontos e linhas de 50 pontos. Ele usa [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) para selecionar um preenchimento sólido e [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) para acessar a cor de preenchimento e definir a cor como vermelho para a célula `(2, 3)`, na terceira coluna e quarta linha.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **Adicionar uma imagem dentro de uma célula de tabela**

Coloque a imagem de entrada no diretório de trabalho antes de executar este exemplo. Ela carrega a imagem com [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) e a adiciona à coleção de imagens da apresentação com [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). Em seguida, atribui a imagem ao preenchimento de imagem da célula `(0, 0)`, a primeira célula da tabela.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) estica a imagem para preencher a célula, o que pode mudar sua proporção. As larguras das colunas e alturas das linhas estão em pontos. A imagem carregada é descartada após ser adicionada à apresentação.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso definir diferentes espessuras e estilos de linha para diferentes lados de uma única célula?**

Sim. As bordas [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) têm propriedades separadas, portanto a espessura e o estilo de cada lado podem ser diferentes.

**O que acontece com a imagem se eu alterar o tamanho da coluna/linha após definir uma imagem como fundo da célula?**

O comportamento depende do [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile). Com esticamento, a imagem ajusta-se à nova célula; com mosaico, os blocos são recalculados.

**Posso atribuir um hyperlink a todo o conteúdo de uma célula?**

[Hyperlinks](/slides/pt/cpp/manage-hyperlinks/) são definidas no nível de texto (porção) dentro do quadro de texto da célula ou no nível de toda a tabela/forma. Na prática, você atribui o link a uma porção ou a todo o texto na célula.

**Posso definir fontes diferentes dentro de uma única célula?**

Sim. O quadro de texto de uma célula suporta [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (segmentos) com formatação independente — família de fonte, estilo, tamanho e cor.