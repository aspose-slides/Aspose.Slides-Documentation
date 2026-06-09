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
- estilo da tabela
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Gerencie linhas e colunas de tabelas no PowerPoint com Aspose.Slides para C++ e acelere a edição de apresentações e a atualização de dados."
---
## **Introdução**

Para permitir que você gerencie as linhas e colunas de uma tabela em uma apresentação do PowerPoint, o Aspose.Slides fornece a classe [Table](https://reference.aspose.com/slides/pt/cpp/aspose.slides/table/) e a interface [ITable](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itable/), além de muitos outros tipos. 

## **Definir a Primeira Linha como Cabeçalho**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) e carregue a apresentação. 
2. Obtenha a referência de um slide através do seu índice. 
3. Crie um objeto [ITable](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itable/) e defina-o como null.
4. Itere por todos os objetos [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/) para encontrar a tabela relevante. 
5. Defina a primeira linha da tabela como seu cabeçalho. 

Este código C++ mostra como definir a primeira linha de uma tabela como seu cabeçalho:

```c++
// Instancia a classe Presentation 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// Acessa o primeiro slide
auto sld = pres->get_Slides()->idx_get(0);

// Inicializa o TableEx nulo
SharedPtr<ITable> tbl;

// Itera pelos shapes e define uma referência para a tabela
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Define a primeira linha da tabela como cabeçalho 
tbl->set_FirstRow(true);
```

## **Clonar uma Linha ou Coluna de Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) e carregue a apresentação, 
2. Obtenha a referência de um slide através do seu índice. 
3. Defina um array de `columnWidth`.
4. Defina um array de `rowHeight`.
5. Adicione um objeto [ITable](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itable/) ao slide através do método [AddTable()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/addtable/).
6. Clone a linha da tabela.
7. Clone a coluna da tabela.
8. Salve a apresentação modificada.

Este código C++ mostra como clonar a linha ou coluna de uma tabela do PowerPoint:

```c++
 // O caminho para o diretório de documentos.
const String outPath = u"../out/CloningInTable_out.pptx";

// Instancia a classe Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acessa o primeiro slide
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Define colunas com larguras e linhas com alturas
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Adiciona uma forma de tabela ao slide
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Define o formato da borda para cada célula
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
	SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
	for (int y = 0; y < row->get_Count(); y++)
	{
		SharedPtr<ICell> cell = row->idx_get(y);

		cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderTop()->set_Width(5);

		cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderBottom()->set_Width(5);

		cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderLeft()->set_Width(5);

		cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderRight()->set_Width(5);

	}

}

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

//AddClone adiciona uma linha ao final da tabela
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone adiciona uma linha em uma posição específica da tabela
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone adiciona uma coluna ao final da tabela
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone adiciona uma coluna em uma posição específica da tabela
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// Salva a apresentação no disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Remover uma Linha ou Coluna de uma Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) e carregue a apresentação, 
2. Obtenha a referência de um slide através do seu índice. 
3. Defina um array de `columnWidth`.
4. Defina um array de `rowHeight`.
5. Adicione um objeto [ITable](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itable/) ao slide através do método [AddTable()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/addtable/).
6. Remova a linha da tabela.
7. Remova a coluna da tabela.
8. Salve a apresentação modificada. 

Este código C++ mostra como remover uma linha ou coluna de uma tabela:

```c++
// O caminho para o diretório de documentos.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Instancia a classe Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acessa o primeiro slide
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Define as colunas com larguras e as linhas com alturas
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Adiciona uma forma de tabela ao slide
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


 // Mescla as células (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Mescla as células (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Salva a apresentação no disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Definir Formatação de Texto no Nível de Linha da Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) e carregue a apresentação, 
2. Obtenha a referência de um slide através do seu índice. 
3. Acesse o objeto [ITable](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itable/) relevante a partir do slide. 
4. Defina a [set_FontHeight()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseportionformat/set_fontheight/) das células da primeira linha. 
5. Defina a [set_Alignment()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_alignment/) e [set_MarginRight()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_marginright/) das células da primeira linha. 
6. Defina a [set_TextVerticalType()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/textframeformat/set_textverticaltype/) das células da segunda linha.
7. Salve a apresentação modificada.

Este código C++ demonstra a operação.

```c++
// Cria uma instância da classe Presentation
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Vamos supor que a primeira forma no primeiro slide seja uma tabela
// Define a altura da fonte das células da primeira linha
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// Define o alinhamento de texto e a margem direita das células da primeira linha
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// Define o tipo de texto vertical das células da segunda linha
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// Salva a apresentação no disco
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Definir Formatação de Texto no Nível de Coluna da Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) e carregue a apresentação, 
2. Obtenha a referência de um slide através do seu índice. 
3. Acesse o objeto [ITable](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itable/) relevante a partir do slide. 
4. Defina a [set_FontHeight()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseportionformat/set_fontheight/) das células da primeira coluna. 
5. Defina a [set_Alignment()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_alignment/) e [set_MarginRight()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_marginright/) das células da primeira coluna. 
6. Defina a [set_TextVerticalType()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/textframeformat/set_textverticaltype/) das células da segunda coluna.
7. Salve a apresentação modificada. 

Este código C++ demonstra a operação: 

```c++
// Cria uma instância da classe Presentation
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Vamos supor que a primeira forma no primeiro slide seja uma tabela

// Define a altura da fonte das células da primeira coluna
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// Define o alinhamento de texto e a margem direita das células da primeira coluna em uma única chamada
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// Define o tipo de texto vertical das células da segunda coluna
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Obter Propriedades de Estilo da Tabela**

Aspose.Slides permite que você recupere as propriedades de estilo de uma tabela para que possa usar esses detalhes em outra tabela ou em outro local. Este código C++ mostra como obter as propriedades de estilo de um estilo predefinido de tabela:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso aplicar temas/estilos do PowerPoint a uma tabela já criada?**

Sim. A tabela herda o tema do slide/layout/master e ainda é possível sobrescrever preenchimentos, bordas e cores de texto sobre esse tema.

**Posso ordenar linhas da tabela como no Excel?**

Não, as tabelas do Aspose.Slides não possuem ordenação ou filtros integrados. Ordene seus dados na memória primeiro e, em seguida, repovoar as linhas da tabela nessa ordem.

**Posso ter colunas em faixas (listradas) mantendo cores personalizadas em células específicas?**

Sim. Ative colunas em faixas e, em seguida, sobrescreva células específicas com formatação local; a formatação nível célula tem precedência sobre o estilo da tabela.