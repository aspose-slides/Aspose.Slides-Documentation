---
title: Gerenciar Linhas e Colunas em Tabelas do PowerPoint Usando C++
linktitle: Linhas e Colunas
type: docs
weight: 20
url: /pt/cpp/manage-rows-and-columns/
keywords:
- linha de tabela
- coluna de tabela
- primeira linha
- cabeçalho da tabela
- clonar linha
- clonar coluna
- copiar linha
- copiar coluna
- remover linha
- remover coluna
- formatação de texto da linha
- formatação de texto da coluna
- estilo de tabela
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Gerencie linhas e colunas de tabelas no PowerPoint com Aspose.Slides for C++ e agilize a edição de apresentações e a atualização de dados."
---
## **Introdução**

Aspose.Slides for C++ permite que você gerencie a estrutura e formatação de tabelas em apresentações do PowerPoint através da classe [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) e da interface [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). Você pode designar uma linha de cabeçalho, clonar ou remover linhas e colunas e aplicar formatação de texto a uma linha ou coluna inteira.

Este artigo explica essas operações com exemplos em C++. Ele também mostra como recuperar o estilo predefinido de uma tabela para reutilizá‑lo. Os índices de linhas e colunas da tabela são baseados em zero.

## **Controlar Altura da Linha**

Use [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) para definir a altura mínima de uma linha em pontos. É um limite inferior, não uma altura fixa. [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) devolve a altura real; esse valor não pode ser definido diretamente. Acesse a linha através de [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/).

O exemplo carrega [row-height-input.pptx](row-height-input.pptx), que contém uma tabela como o primeiro shape no primeiro slide. Sua primeira linha começa em 70 pontos. As células usam texto Arial de 18 pt, com quebra de linha e margens superior e inferior de 6 pt; o texto mais longo na segunda coluna envolve‑se em várias linhas. O exemplo aumenta o mínimo para 100 pt, depois diminui para 20 pt, imprime a altura real após cada alteração e salva ambos os resultados.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

Com a apresentação fornecida, aumentar o mínimo adiciona espaço à linha. Diminuí‑lo remove esse espaço extra, mas a altura real permanece maior que 20 pt porque o texto e as margens da célula exigem mais espaço. Reduzir apenas o mínimo não pode forçar a linha abaixo do espaço necessário para seu conteúdo.

Vários fatores afetam a altura real:

- **Texto e tamanho da fonte:** texto mais longo, quebras de linha explícitas ou uma fonte maior podem exigir mais espaço vertical.
- **Quebra de linha e largura da coluna:** com a quebra habilitada, diminuir a largura da coluna usando [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) pode gerar mais linhas. Uma coluna mais larga pode reduzir o espaço vertical necessário.
- **Margens da célula:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) e [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) controlam as margens que adicionam espaço vertical. [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) e [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) controlam as margens que reduzem a largura disponível para o texto e podem causar quebras adicionais.

Para esta tabela sem células mescladas, a célula que precisa de mais espaço vertical determina o limite inferior baseado no conteúdo para toda a linha. Para encurtar a linha, pode ser necessário também encurtar o texto, reduzir o tamanho da fonte ou das margens, ou ampliar uma coluna.

As imagens abaixo mostram a mesma tabela na mesma escala. Na execução de referência .NET mostrada aqui, as alturas reais foram 70, 100 e 55.2 pt: a linha final permaneceu mais alta que seu mínimo de 20 pt. As medições exatas de texto podem variar conforme as fontes disponíveis em seu ambiente. Baixe os resultados salvos: [increased minimum](row-height-increased.pptx) e [decreased minimum](row-height-decreased.pptx).

| Original: minimum 70 pt, actual 70 pt | Increased: minimum 100 pt, actual 100 pt | Decreased: minimum 20 pt, actual 55.2 pt |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **Definir a Primeira Linha como Cabeçalho**

Use o método [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) para marcar a primeira linha para formatação de cabeçalho. Sua aparência depende do estilo de tabela aplicado à tabela.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Acesse a tabela armazenada como o primeiro shape no slide.
4. Habilite a formatação de cabeçalho para sua primeira linha.
5. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como o primeiro shape no primeiro slide. Ele habilita a formatação de cabeçalho para a primeira linha e salva `First_row_header.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **Clonar uma Linha ou Coluna de Tabela**

Clone linhas ou colunas para reutilizar seu conteúdo e formatação. Você pode anexar uma cópia ao final da tabela ou inseri‑la em uma posição específica.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Defina as larguras das colunas e as alturas das linhas.
4. Adicione uma tabela com o método [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Clone as linhas necessárias.
6. Clone as colunas necessárias.
7. Salve a apresentação modificada.

O exemplo requer `Test.pptx` com ao menos um slide. Ele cria uma tabela com três colunas e cinco linhas, com dimensões especificadas em pontos. Ele anexa cópias da primeira linha e coluna, depois insere cópias da segunda linha e coluna no índice 3 (a quarta posição). A tabela resultante tem sete linhas e cinco colunas. O argumento `false` desabilita a clonagem em linhas ou colunas mescladas adjacentes; esta tabela não possui células mescladas.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Remover uma Linha ou Coluna de uma Tabela**

Remova linhas ou colunas que não são mais necessárias em uma tabela. Remover um item desloca os índices das linhas ou colunas que o seguem.

1. Crie uma apresentação com a classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Defina as larguras das colunas e as alturas das linhas.
4. Adicione uma tabela com o método [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Remova a segunda linha e a segunda coluna.
6. Salve a apresentação modificada.

Este exemplo cria uma tabela de três por três e remove a linha e a coluna no índice 1, deixando uma tabela de dois por dois em `TestTable_out.pptx`. As dimensões estão em pontos. O argumento `false` desabilita a remoção de linhas ou colunas mescladas adjacentes; esta tabela não possui células mescladas.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **Definir Formatação de Texto no Nível de Linha da Tabela**

Aplique formatação de texto a uma linha inteira para manter suas células consistentes. Você pode definir propriedades de fonte, formatação de parágrafo e direção do texto sem formatar cada célula individualmente.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acesse a tabela no primeiro slide.
3. Defina a altura da fonte com [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) para a primeira linha.
4. Defina o alinhamento e a margem direita do parágrafo com [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) e [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) para a primeira linha.
5. Defina a direção do texto com [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) para a segunda linha.
6. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como o primeiro shape no primeiro slide e ao menos duas linhas. Ele aplica texto de 25 pt, alinhamento à direita e margem direita de 20 pt à primeira linha, depois define texto vertical na segunda linha.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **Definir Formatação de Texto no Nível de Coluna da Tabela**

Aplique formatação de texto a uma coluna inteira para manter suas células consistentes. Você pode definir propriedades de fonte, formatação de parágrafo e direção do texto sem formatar cada célula individualmente.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acesse a tabela no primeiro slide.
3. Defina a altura da fonte com [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) para a primeira coluna.
4. Defina o alinhamento e a margem direita do parágrafo com [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) e [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) para a primeira coluna.
5. Defina a direção do texto com [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) para a segunda coluna.
6. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como o primeiro shape no primeiro slide e ao menos duas colunas. Ele aplica texto de 25 pt, alinhamento à direita e margem direita de 20 pt à primeira coluna, depois define texto vertical na segunda coluna.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **Obter Propriedades de Estilo da Tabela**

Use o método [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) para recuperar o preset aplicado a uma tabela e reutilizá‑lo em outra tabela. Isso identifica o preset em vez de sobrescrições individuais de formatação de célula.

O exemplo cria uma tabela, aplica [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) e lê o preset de volta. Ele imprime `DarkStyle1` e salva a tabela em `table.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Perguntas Frequentes**

**Posso aplicar temas/estilos do PowerPoint a uma tabela que já foi criada?**

Sim. A tabela herda o tema do slide/layout/master e você ainda pode sobrescrever preenchimentos, bordas e cores de texto sobre esse tema.

**Posso ordenar linhas de tabela como no Excel?**

Não, as tabelas do Aspose.Slides não possuem ordenação ou filtros embutidos. Ordene seus dados na memória primeiro e, em seguida, repopule as linhas da tabela na ordem desejada.

**Posso ter colunas listradas (banded) mantendo cores personalizadas em células específicas?**

Sim. Ative colunas listradas e, depois, sobrescreva células específicas com formatação local; a formatação ao nível da célula tem precedência sobre o estilo da tabela.