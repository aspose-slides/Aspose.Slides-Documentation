---
title: Gerenciar Células de Tabela em Apresentações Usando C++
linktitle: Gerenciar Células
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
description: "Gerencie células de tabelas do PowerPoint em C++: identifique células mescladas, remova bordas, divida células e defina cores de fundo e imagens com Aspose.Slides para C++."
---
## **Visão geral**

Aspose.Slides permite acessar e modificar células de tabelas em apresentações do PowerPoint. Este artigo explica como identificar células de tabela mescladas, remover bordas das células, trabalhar com a numeração de células após mesclar ou dividir células, alterar a cor de fundo de uma célula e adicionar uma imagem dentro de uma célula de tabela. Os exemplos mostram como criar ou abrir uma apresentação, obter uma tabela de um slide, atualizar a formatação das células por meio das propriedades da célula e salvar a apresentação modificada como um arquivo PPTX.

Aspose.Slides usa índices baseados em zero para acessar células de tabela na ordem `(coluna, linha)`.

## **Identificar uma Célula de Tabela Mesclada**

O exemplo abre uma apresentação existente e acessa o primeiro shape no primeiro slide como uma tabela. Ele pressupõe que o slide e o shape existam e que o shape seja uma tabela. Em seguida, itera por todas as linhas e colunas e usa [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) para identificar células em regiões mescladas. Para cada correspondência, ele imprime as coordenadas da célula na ordem `linha;coluna`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), e as coordenadas iniciais da região, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) e [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

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

## **Remover Bordas de Célula de Tabela**

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

## **Adicionar Bordas Diagonais à Célula**

Use [get_BorderDiagonalDown](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonaldown/) para desenhar uma linha do canto superior esquerdo ao canto inferior direito, e [get_BorderDiagonalUp](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonalup/) para desenhar uma linha do canto inferior esquerdo ao canto superior direito. Uma diagonal pode marcar um cabeçalho de canto; ambas as diagonais podem formar um X para indicar que a célula não é aplicável.

Cada diagonal é um [ILineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/). Use [get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/) para acessar seu preenchimento, chame [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/set_filltype/) com [FillType::Solid](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) e escolha uma cor através de [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/get_solidfillcolor/). Defina a espessura da linha com [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) em pontos.

O exemplo cria três células em uma linha: uma diagonal descendente vermelha, uma diagonal ascendente azul e ambas as diagonais. Ele deixa as bordas superior, inferior, esquerda e direita da célula inalteradas.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({210, 210, 210});
auto rowHeights = MakeArray<double>({160});
auto table = slide->get_Shapes()->AddTable(45, 130, columnWidths, rowHeights);

auto downwardBorder = table->idx_get(0, 0)->get_CellFormat()->get_BorderDiagonalDown();
downwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
downwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
downwardBorder->set_Width(3);

auto upwardBorder = table->idx_get(1, 0)->get_CellFormat()->get_BorderDiagonalUp();
upwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
upwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
upwardBorder->set_Width(5);

auto crossDownwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalDown();
crossDownwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossDownwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
crossDownwardBorder->set_Width(3);

auto crossUpwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalUp();
crossUpwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossUpwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
crossUpwardBorder->set_Width(5);

presentation->Save(u"diagonal_cell_borders.pptx", SaveFormat::Pptx);
```

Uma diagonal é uma propriedade de formatação, não uma divisão da célula. Cada célula mantém um único quadro de texto acessado através de [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/); as regiões em cada lado de uma diagonal não podem ser editadas independentemente.

A tabela salva, renderizada no Microsoft PowerPoint:

![Três células de tabela mostrando uma diagonal vermelha do canto superior esquerdo ao inferior direito, uma diagonal azul do canto inferior esquerdo ao superior direito e ambas as diagonais formando um X.](diagonal-cell-borders.png)

*Da esquerda para a direita: diagonal descendente (vermelha, 3 pt), diagonal ascendente (azul, 5 pt) e ambas as diagonais.*

## **Mesclar Células de Tabela**

Use [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) para combinar um intervalo retangular de células de tabela em uma única célula. Especifique as células nos cantos superior esquerdo e inferior direito do intervalo. O argumento final controla se a mesclagem pode incluir células fora do intervalo especificado; `false` mantém a mesclagem dentro desse intervalo.

O exemplo cria uma tabela 4 × 4 com colunas e linhas de 70 pontos, então mescla as quatro células centrais de `(1, 1)` a `(2, 2)`. A célula resultante abrange duas colunas e duas linhas, enquanto a grade subjacente da tabela mantém quatro colunas e quatro linhas. Para acessar o conteúdo ou formatação da célula mesclada, use sua posição superior esquerda: `table->idx_get(1, 1)` neste exemplo. As outras posições no intervalo mesclado permanecem parte da grade da tabela, de modo que os índices das células fora do intervalo não mudam.

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

## **Dividir Células de Tabela**

Mesclar células no exemplo anterior preserva a grade da tabela. Dividir uma célula pode introduzir uma nova coluna na grade e alterar os índices de coluna das células à sua direita. Aspose.Slides segue o modelo de grade de tabelas do PowerPoint.

Este exemplo cria uma tabela 4 × 4 com colunas e linhas de 70 pontos e chama [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) na célula `(1, 1)`. Metade da largura de 70 pontos da célula é passada para criar duas células de largura igual.

Após essa divisão, as duas metades são acessadas como `table->idx_get(1, 1)` e `table->idx_get(2, 1)`. A grade da tabela agora tem cinco colunas: as células originalmente nas colunas 2 e 3 movem‑se para as colunas 3 e 4, respectivamente. Os índices de linha permanecem inalterados. Use esses índices de coluna atualizados ao acessar células depois da divisão.

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


<!-- visual-explanation:manage-cells:start -->
[![Uma célula não mesclada de 70 pontos se divide em duas células de 35 pontos, adicionando uma quinta coluna na grade e deslocando os índices à sua direita.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*A divisão de largura afeta a célula (1, 1), usando índices baseados em zero (coluna, linha). As demais linhas mantêm uma célula que abrange ambas as novas posições de coluna.*
<!-- visual-explanation:manage-cells:end -->

### **Dividir Células Mescladas por Extensão de Linha ou Coluna**

Para preparar células‑modelo mescladas para preenchimento de dados, use [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) para dividir ao longo de um limite de linha existente, ou [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) para dividir ao longo de um limite de coluna.

O argumento `index` conta linhas na parte superior ou colunas na parte esquerda da divisão; ele é relativo à região mesclada:

- Divisão de linha: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Divisão de coluna: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

O exemplo pressupõe que a apresentação possua uma tabela como o primeiro shape no primeiro slide, com `(1, 2)` e `(1, 3)` mesclados verticalmente. Começando da posição inferior, ele usa [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) e [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) para localizar a origem e verifica ambas as extensões. `SplitByRowSpan(1)` então separa as linhas 2 e 3 para nomes de produtos. Para uma mesclagem horizontal de duas colunas, use `SplitByColSpan(1)` em vez disso.

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

O texto original e sua formatação permanecem na célula superior (ou esquerda); a nova célula fica vazia, mas herda a formatação da célula, como preenchimento, bordas e margens. Preencha as células após a divisão e defina explicitamente qualquer formatação de texto necessária.

A apresentação salva contém células “Product A” e “Product B” separadas, com a formatação da célula modelo preservada. Consulte a [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) para detalhes.

### **Dividir uma Célula em uma Altura Específica**

[SplitByHeight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyheight/) recebe a altura da parte superior em pontos. [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) recebe o número de linhas da grade existentes na parte superior. Para centralizar uma célula de 40 pontos na coluna direita, subtraia 40 da altura real da célula e divida o espaço restante igualmente acima e abaixo dela.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/ITextFrame.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({160, 160});
auto rowHeights = MakeArray<double>({140});

auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Left");

auto height = table->idx_get(1, 0)->get_Height();
auto margin = (height - 40) / 2;

table->idx_get(1, 0)->SplitByHeight(margin);
table->idx_get(1, 1)->SplitByHeight(40);
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Middle");

presentation->Save(u"split_by_height.pptx", SaveFormat::Pptx);
```

A primeira divisão adiciona uma linha na grade, deixando os 90 pontos inferiores em `(1, 1)`. A segunda divisão tem como alvo essa célula e adiciona outra linha abaixo dela. A coluna direita agora contém `(1, 0)` com 50 pontos (`margin`), `(1, 1)` com 40 pontos e `(1, 2)` com 50 pontos (`margin`). A célula esquerda abrange as três linhas com sua altura original de 140 pontos.

![A célula esquerda ocupa toda a altura da tabela ao lado de três células com “Middle” no centro.](split-by-height.png)

## **Alterar a Cor de Fundo da Célula da Tabela**

Este exemplo cria uma tabela com colunas de 150 pontos e linhas de 50 pontos. Ele usa [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) para selecionar um preenchimento sólido e [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) para acessar a cor de preenchimento e defini‑la como vermelha para a célula `(2, 3)`, na terceira coluna e quarta linha.

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

## **Adicionar uma Imagem Dentro de uma Célula de Tabela**

Coloque a imagem de entrada no diretório de trabalho antes de executar este exemplo. Ela carrega a imagem com [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) e a adiciona à coleção de imagens da apresentação com [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). Em seguida, atribui a imagem ao preenchimento de imagem da célula `(0, 0)`, a primeira célula da tabela.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) estica a imagem para preencher a célula, o que pode alterar sua proporção. As larguras das colunas e alturas das linhas estão em pontos. A imagem carregada é descartada após ser adicionada à apresentação.

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

**Posso definir espessuras e estilos de linha diferentes para lados diferentes de uma única célula?**

Sim. As bordas [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) possuem propriedades separadas, de modo que a espessura e o estilo de cada lado podem ser diferentes.

**O que acontece com a imagem se eu alterar o tamanho da coluna/linha após definir uma foto como fundo da célula?**

O comportamento depende do [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile). Com estiramento, a imagem se ajusta à nova célula; com mosaico, os blocos são recalculados.

**Posso atribuir um hyperlink a todo o conteúdo de uma célula?**

[Hyperlinks](/slides/pt/cpp/manage-hyperlinks/) são definidos no nível do texto (porções) dentro do quadro de texto da célula ou no nível de toda a tabela/shape. Na prática, você atribui o link a uma porção ou a todo o texto da célula.

**Posso definir fontes diferentes dentro de uma única célula?**

Sim. O quadro de texto de uma célula suporta [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (corridas) com formatação independente — família da fonte, estilo, tamanho e cor.