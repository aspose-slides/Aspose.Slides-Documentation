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
- proporção de aspecto
- alinhar texto
- formatação de texto
- estilo de tabela
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Criar e editar tabelas em slides do PowerPoint com Aspose.Slides para C++. Descubra exemplos de código simples para simplificar seus fluxos de trabalho com tabelas."
---
## **Introdução**

Uma tabela no PowerPoint é uma maneira eficiente de exibir e representar informações. As informações em uma grade de células (organizadas em linhas e colunas) são simples e fáceis de entender.

Aspose.Slides fornece a classe [Table](https://reference.aspose.com/slides/pt/cpp/aspose.slides/table/), a interface [ITable](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itable/), a classe [Cell](https://reference.aspose.com/slides/pt/cpp/aspose.slides/cell/), a interface [ICell](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icell/) e outros tipos para permitir que você crie, atualize e gerencie tabelas em todos os tipos de apresentações. 

## **Criar uma Tabela do Zero**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Obtenha a referência de um slide por meio de seu índice. 
3. Defina um array de `columnWidth`.
4. Defina um array de `rowHeight`.
5. Adicione um objeto [ITable](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itable/) ao slide usando o método [AddTable()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/addtable/).
6. Percorra cada [ICell](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icell/) para aplicar formatação nas bordas superior, inferior, direita e esquerda.
7. Mescle as duas primeiras células da primeira linha da tabela. 
8. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/textframe/) de um [ICell](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icell/). 
9. Adicione algum texto ao [TextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/textframe/).
10. Salve a apresentação modificada.

Este código C++ mostra como criar uma tabela em uma apresentação:

```c++
// Instancia uma classe Presentation que representa um arquivo PPTX
auto pres = System::MakeObject<Presentation>();

// Acessa o primeiro slide
auto sld = pres->get_Slides()->idx_get(0);

// Define colunas com larguras e linhas com alturas
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Adiciona uma forma de tabela ao slide
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Define o formato da borda para cada célula
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
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
// Mescla as células 1 e 2 da linha 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Adiciona algum texto à célula mesclada
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Salva a apresentação no disco
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Numeração em uma Tabela Padrão**

Em uma tabela padrão, a numeração das células é simples e baseada em zero. A primeira célula de uma tabela tem índice 0,0 (coluna 0, linha 0). 

Por exemplo, as células de uma tabela com 4 colunas e 4 linhas são numeradas da seguinte forma:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código C++ mostra como especificar a numeração para células em uma tabela:

```c++
// Instancia uma classe Presentation que representa um arquivo PPTX
auto pres = System::MakeObject<Presentation>();

// Acessa o primeiro slide
auto sld = pres->get_Slides()->idx_get(0);

// Define colunas com larguras e linhas com alturas
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Adiciona uma forma de tabela ao slide
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Define o formato da borda para cada célula
for (const auto& row : tbl->get_Rows())
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

// Salva a apresentação no disco
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Acessar uma Tabela Existente**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).

2. Obtenha a referência ao slide que contém a tabela por meio de seu índice. 

3. Crie um objeto [ITable](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itable/) e defina-o como nulo.

4. Percorra todos os objetos [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/) até encontrar a tabela.

   Se você suspeitar que o slide tratado contém uma única tabela, pode simplesmente verificar todas as formas que ele possui. Quando uma forma for identificada como tabela, você pode convertê‑la para um objeto [Table](https://reference.aspose.com/slides/pt/cpp/aspose.slides/table/). Mas se o slide contiver várias tabelas, é melhor pesquisar a tabela necessária através de seu método [set_AlternativeText()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/set_alternativetext/).

5. Use o objeto [ITable](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itable/) para trabalhar com a tabela. No exemplo abaixo, adicionamos uma nova linha à tabela.

6. Salve a apresentação modificada.

Este código C++ mostra como acessar e trabalhar com uma tabela existente:

```c++
// Instancia uma classe Presentation que representa um arquivo PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Acessa o primeiro slide
auto sld = pres->get_Slides()->idx_get(0);

// Inicializa a Table nula
System::SharedPtr<ITable> tbl;

// Percorre as formas e define uma referência para a tabela encontrada
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Define o texto para a primeira coluna da segunda linha
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Salva a apresentação modificada no disco
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Alinhar Texto em uma Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Obtenha a referência de um slide por meio de seu índice. 
3. Adicione um objeto [ITable](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itable/) ao slide. 
4. Acesse um objeto [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) da tabela. 
5. Acesse o [IParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/) do [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/).
6. Alinhe o texto verticalmente.
7. Salve a apresentação modificada.

Este código C++ mostra como alinhar o texto em uma tabela:

```c++
// Cria uma instância da classe Presentation
auto presentation = System::MakeObject<Presentation>();

// Obtém o primeiro slide 
auto slide = presentation->get_Slides()->idx_get(0);

// Define colunas com larguras e linhas com alturas
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Adiciona a forma de tabela ao slide
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Acessa o quadro de texto
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Cria o objeto Paragraph para o quadro de texto
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Cria o objeto Portion para o parágrafo
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Alinha o texto verticalmente
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Salva a Apresentação no disco
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Definir Formatação de Texto no Nível da Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Obtenha a referência de um slide por meio de seu índice. 
3. Acesse um objeto [ITable](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itable/) do slide.
4. Defina a altura da fonte com [set_FontHeight()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Defina o alinhamento com [set_Alignment()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_alignment/) e a margem direita com [set_MarginRight()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Defina o tipo de orientação vertical do texto com [set_TextVerticalType()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Salve a apresentação modificada. 

Este código C++ mostra como aplicar suas opções de formatação preferidas ao texto em uma tabela:

```c++
// Cria uma instância da classe Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Vamos supor que a primeira forma no primeiro slide seja uma tabela
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Define a altura da fonte das células da tabela
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Define o alinhamento de texto e a margem direita das células da tabela em uma única chamada
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Define o tipo de orientação vertical do texto nas células da tabela
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Obter Propriedades de Estilo da Tabela**

Aspose.Slides permite recuperar as propriedades de estilo de uma tabela para que você possa usar esses detalhes em outra tabela ou em outro lugar. Este código C++ mostra como obter as propriedades de estilo de um estilo predefinido de tabela:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Bloquear Proporção de Aspecto de uma Tabela**

A proporção de aspecto de uma forma geométrica é a relação entre seus tamanhos em diferentes dimensões. Aspose.Slides fornece a propriedade `AspectRatioLocked()` para permitir que você bloqueie a configuração de proporção de aspecto para tabelas e outras formas. 

Este código C++ mostra como bloquear a proporção de aspecto para uma tabela:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso habilitar a direção de leitura da direita para a esquerda (RTL) para uma tabela inteira e o texto em suas células?**

Sim. A tabela expõe o método [set_RightToLeft](https://reference.aspose.com/slides/pt/cpp/aspose.slides/table/set_righttoleft/), e os parágrafos têm [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/pt/cpp/aspose.slides/paragraphformat/set_righttoleft/). Usar ambos garante a ordem RTL correta e a renderização dentro das células.

**Como impedir que os usuários movam ou redimensionem uma tabela no arquivo final?**

Use [bloqueios de forma](/slides/pt/cpp/applying-protection-to-presentation/) para desativar movimentação, redimensionamento, seleção, etc. Esses bloqueios também se aplicam a tabelas.

**É suportado inserir uma imagem dentro de uma célula como plano de fundo?**

Sim. Você pode definir um [preenchimento de imagem](https://reference.aspose.com/slides/pt/cpp/aspose.slides/picturefillformat/) para uma célula; a imagem cobrirá a área da célula de acordo com o modo escolhido (esticar ou repetir).