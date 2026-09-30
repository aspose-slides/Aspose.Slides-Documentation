---
title: Gerenciar Tabelas de Apresentação em C++
linktitle: Gerenciar Tabela
type: docs
weight: 10
url: /pt/cpp/manage-table/
keywords:
- adicionar tabela
- criar tabela
- acessar tabela
- proporção
- alinhar texto
- formatação de texto
- estilo de tabela
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Criar e editar tabelas em slides do PowerPoint com Aspose.Slides para C++. Descubra exemplos de código simples para agilizar seus fluxos de trabalho com tabelas."
---
## **Introdução**

As tabelas no PowerPoint organizam informações em linhas e colunas, facilitando a leitura e a comparação de valores.

Aspose.Slides fornece a classe [Tabela](https://reference.aspose.com/slides/cpp/aspose.slides/table/), a interface [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/), a classe [Célula](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) e a interface [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/), além de outros tipos para permitir a criação, atualização e gerenciamento de tabelas em apresentações.

## **Criar uma Tabela do Zero**

Crie uma tabela especificando sua posição, larguras das colunas e alturas das linhas. Depois de adicioná‑la a um slide, você pode formatar as bordas das células, mesclar células e inserir texto.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenha uma referência ao slide pelo seu índice.
3. Defina um array de larguras de coluna em pontos.
4. Defina um array de alturas de linha em pontos.
5. Adicione um objeto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) ao slide através do método [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. Percorra cada [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) para aplicar formatação às bordas superior, inferior, direita e esquerda.
7. Mescle as duas primeiras células da primeira linha da tabela.
8. Acesse a célula mesclada por meio do seu método [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/).
9. Defina o texto na célula mesclada.
10. Salve a apresentação modificada.

O exemplo a seguir cria uma tabela com três colunas e cinco linhas nas coordenadas (100, 50) pontos. Ele aplica bordas vermelhas com largura de 5 pontos, mescla as duas primeiras células da primeira linha e salva o resultado como `table.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Numeração em uma Tabela Padrão**

Em uma tabela padrão, os índices das células são baseados em zero e usam a ordem (coluna, linha). A primeira célula tem índice (0, 0).

Por exemplo, as células em uma tabela com 4 colunas e 4 linhas são numeradas assim:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este exemplo cria a tabela 4 × 4 ilustrada acima, com larguras de coluna e alturas de linha de 70 pontos e bordas de célula vermelhas com largura de 5 pontos. As coordenadas ilustram os índices das células; o exemplo deixa as células vazias e salva a tabela como `StandardTables_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Acessar uma Tabela Existente**

As tabelas são armazenadas na coleção de formas de um slide. Percorra as formas para localizar uma tabela e, então, use a interface [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) para ler ou atualizar suas células.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenha uma referência ao slide que contém a tabela pelo seu índice.
3. Percorra os objetos [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) e pare quando uma tabela for encontrada. Se o slide contiver várias tabelas, use [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) para identificar a que você precisa.
4. Atualize o texto na célula alvo.
5. Salve a apresentação modificada.

O exemplo a seguir abre `UpdateExistingTable.pptx` e encontra a primeira tabela do primeiro slide. Ele define a célula na coluna 0, linha 1 como `New` e salva o resultado como `table1_out.pptx`. A entrada deve conter ao menos um slide, e a primeira tabela desse slide deve ter ao menos uma coluna e duas linhas.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

Para redimensionar uma linha em uma tabela existente e entender por que sua altura real pode exceder a mínima solicitada, veja [Control Row Height](/slides/pt/cpp/manage-rows-and-columns/#control-row-height).

## **Encontrar a Célula que Possui um Quadro de Texto**

Quando um código genérico de processamento de texto recebe um [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) de uma tabela, use [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) para recuperar a [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) proprietária. Para um quadro de texto de célula de tabela, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) retorna o proprietário e [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) retorna `nullptr`, embora a própria tabela seja uma forma.

As coordenadas da célula estão disponíveis através dos métodos somente‑leitura [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) e [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/). [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) também fornece navegação somente‑leitura: ele devolve o proprietário mas não altera a propriedade. Sempre verifique se a célula retornada é `nullptr` antes de usá‑la.

Para um exemplo completo que identifica proprietários de célula‑tabela e de forma, incluindo formas associadas a nós de SmartArt, veja [Search and Replace Text](/slides/pt/cpp/search-and-replace-text/).

## **Alinhar Texto em uma Tabela**

Você pode controlar o ancoramento vertical e a direção do texto de células individuais da tabela. O exemplo desta seção centraliza o texto na primeira célula e o gira 270 graus.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenha uma referência ao slide pelo seu índice.
3. Adicione um objeto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) ao slide.
4. Acesse um objeto [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) da tabela.
5. Acesse o primeiro [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) e defina seu texto e cor.
6. Defina o ancoramento vertical da célula e a direção do texto usando [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) e [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/).
7. Salve a apresentação modificada.

Este exemplo cria uma tabela 4 × 4 com larguras de coluna de 120 pontos e alturas de linha de 100 pontos. Ele formata o texto na célula (0, 0), adiciona valores às demais células da primeira linha e salva o resultado como `Vertical_Align_Text_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Definir Formatação de Texto no Nível da Tabela**

Use [SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) para aplicar formatação de texto a todas as células de uma tabela. Seus overloads aceitam formatação de porções, parágrafos e quadros de texto, permitindo definir essas propriedades sem iterar por células individuais.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenha uma referência ao slide pelo seu índice.
3. Acesse um objeto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) do slide.
4. Defina o tamanho da fonte usando [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) para o texto.
5. Defina o alinhamento do parágrafo e a margem direita usando [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) e [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).
6. Defina a direção do texto usando [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Salve a apresentação modificada.

O exemplo abaixo abre `table.pptx`, que deve conter ao menos um slide com uma tabela como sua primeira forma. Ele define o tamanho da fonte para 25 pontos, alinha os parágrafos à direita com margem direita de 20 pontos e torna o texto vertical. A apresentação formatada é salva como `result.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Obter Propriedades de Estilo da Tabela**

Use [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) para ler o estilo predefinido de uma tabela e [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) para atribuí‑lo. Este exemplo aplica [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) a uma tabela, imprime o nome da predefinição e atribui a mesma predefinição a uma segunda tabela. Ambas as tabelas são salvas em `table-style.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **Bloquear Proporção da Tabela**

A proporção de uma tabela é a relação entre sua largura e sua altura. Use [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) para bloquear essa relação em uma tabela.

O exemplo abaixo abre `pres.pptx`, que deve conter ao menos um slide com uma tabela como sua primeira forma. Ele imprime o estado atual do bloqueio, habilita o bloqueio da proporção, imprime o estado atualizado (`True`) e salva o resultado como `pres-out.pptx`.

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso habilitar a direção de leitura da direita para a esquerda (RTL) para toda a tabela e o texto em suas células?**

Sim. A tabela expõe o método [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/), e os parágrafos possuem [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/). Usar ambos garante a ordem RTL correta e a renderização dentro das células.

**Como impedir que os usuários movam ou redimensionem uma tabela no arquivo final?**

Use [bloqueios de forma](/slides/pt/cpp/applying-protection-to-presentation/) para desativar mover, redimensionar, selecionar etc. Esses bloqueios se aplicam também às tabelas.

**É suportado inserir uma imagem dentro de uma célula como plano de fundo?**

Sim. Você pode definir um [preenchimento de imagem](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) para uma célula; a imagem cobrirá a área da célula de acordo com o modo escolhido (esticar ou ladrilhar).