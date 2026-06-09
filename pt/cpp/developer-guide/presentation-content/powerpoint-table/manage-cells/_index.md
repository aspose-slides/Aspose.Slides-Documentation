---
title: Gerenciar Células de Tabela em Apresentações usando C++
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
description: "Gerencie facilmente células de tabela no PowerPoint com Aspose.Slides para C++. Domine o acesso, a modificação e a estilização de células rapidamente para automação de slides perfeita."
---
## **Visão geral**

Aspose.Slides permite acessar e modificar células de tabelas em apresentações do PowerPoint. Este artigo explica como identificar células de tabela mescladas, remover bordas das células, trabalhar com numeração de células após mesclar ou dividir células, alterar a cor de fundo de uma célula e adicionar uma imagem dentro de uma célula de tabela. Os exemplos demonstram como criar ou abrir uma apresentação, obter uma tabela de um slide, atualizar a formatação da célula por meio das propriedades da célula e salvar a apresentação modificada como um arquivo PPTX.

## **Identificar uma Célula Mesclada**
1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) classe.
2. Obtenha a tabela do primeiro slide. 
3. Percorra as linhas e colunas da tabela para encontrar células mescladas.
4. Imprima uma mensagem quando células mescladas forem encontradas.

Este código C++ mostra como identificar células de tabela mescladas em uma apresentação:

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// assuming that Slide#0.Shape#0 is a table
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **Remover Bordas de Células da Tabela**
1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) classe.
2. Obtenha a referência de um slide através de seu índice. 
3. Defina um array de colunas com largura.
4. Defina um array de linhas com altura.
5. Adicione uma tabela ao slide usando o método `AddTable`.
6. Percorra cada célula para limpar as bordas superior, inferior, direita e esquerda.
7. Salve a apresentação modificada como um arquivo PPTX.

Este código C++ mostra como remover as bordas das células da tabela:

``` cpp
// Instancia a classe Presentation que representa um arquivo PPTX
auto pres = MakeObject<Presentation>();
// Acessa o primeiro slide
auto sld = pres->get_Slides()->idx_get(0);

// Define colunas com larguras e linhas com alturas
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// Adiciona uma forma de tabela ao slide
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Define o formato de borda para cada célula
for (const auto& row : System::IterateOver(tbl->get_Rows()))
{
    for (const auto& cell : System::IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }
}

// Grava o arquivo PPTX no disco
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Numeração em Células Mescladas**
Se mesclarmos 2 pares de células (1, 1) × (2, 1) e (1, 2) × (2, 2), a tabela resultante será numerada. Este código C# demonstra o processo:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// Carrega a apresentação desejada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acessa o primeiro slide
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Define colunas com larguras e linhas com alturas
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Adiciona uma forma de tabela ao slide
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Define o formato de borda para cada célula
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
// Mescla as células (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Mescla as células (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Grava o arquivo PPTX no disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Em seguida mesclamos ainda mais as células mesclando (1, 1) e (1, 2). O resultado é uma tabela contendo uma grande célula mesclada em seu centro: 

```c++
// O caminho para o diretório de documentos.
const String outPath = u"../out/MergeCells_out.pptx";

// Carrega a apresentação desejada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acessa o primeiro slide
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Define colunas com larguras e linhas com alturas
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Adiciona uma forma de tabela ao slide
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Define o formato de borda para cada célula
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

// Mescla as células (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Mescla as células (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Grava o arquivo PPTX no disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Numeração em uma Célula Dividida**
Nos exemplos anteriores, quando as células da tabela eram mescladas, a numeração ou o sistema de numeração nas demais células não mudava. 

Desta vez, pegamos uma tabela regular (uma tabela sem células mescladas) e então tentamos dividir a célula (1,1) para obter uma tabela especial. Você pode querer prestar atenção à numeração desta tabela, que pode parecer estranha. No entanto, esse é o modo como o Microsoft PowerPoint numera as células da tabela e o Aspose.Slides faz o mesmo.

Este código C++ demonstra o processo descrito:

```c++
// O caminho para o diretório de documentos.
const String outPath = u"../out/CellSplit_out.pptx";

// Carrega a apresentação desejada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acessa o primeiro slide
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Define colunas com larguras e linhas com alturas
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Adiciona uma forma de tabela ao slide
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Define o formato de borda para cada célula
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

// Mescla as células (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Mescla as células (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// Divide a célula (1, 1). 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// Grava o arquivo PPTX no disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Alterar a Cor de Fundo da Célula da Tabela**

Este código C++ mostra como alterar a cor de fundo de uma célula da tabela:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// cria uma nova tabela
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// define a cor de fundo para uma célula
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Adicionar uma Imagem Dentro de uma Célula da Tabela**
1. Crie uma instância da `Presentation` classe.
2. Obtenha a referência de um slide através de seu índice.
3. Defina um array de colunas com largura.
4. Defina um array de linhas com altura.
5. Adicione uma tabela ao slide usando o método `AddTable`. 
6. Crie um objeto `Bitmap` para armazenar o arquivo de imagem.
7. Adicione a imagem bitmap ao objeto `IPPImage`.
8. Defina o `FillFormat` da Célula da Tabela como `Picture`.
9. Adicione a imagem à primeira célula da tabela.
10. Salve a apresentação modificada como um arquivo PPTX

Este código C# mostra como inserir uma imagem dentro de uma célula da tabela ao criar a tabela:

```c++
// O caminho para o diretório de documentos.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Carrega a apresentação desejada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acessa o primeiro slide
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Define colunas com larguras e linhas com alturas
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// Adiciona uma forma de tabela ao slide
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// Obtém a imagem
auto img = Images::FromFile(ImagePath);

// Adiciona a imagem à coleção de imagens da apresentação
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// Adiciona a imagem à primeira célula da tabela
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Grava o arquivo PPTX no disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Perguntas Frequentes**

**Posso definir diferentes espessuras e estilos de linha para diferentes lados de uma única célula?**

Sim. As bordas [superior](https://reference.aspose.com/slides/pt/cpp/aspose.slides/cellformat/get_bordertop/)/[inferior](https://reference.aspose.com/slides/pt/cpp/aspose.slides/cellformat/get_borderbottom/)/[esquerda](https://reference.aspose.com/slides/pt/cpp/aspose.slides/cellformat/get_borderleft/)/[direita](https://reference.aspose.com/slides/pt/cpp/aspose.slides/cellformat/get_borderright/) possuem propriedades separadas, portanto a espessura e o estilo de cada lado podem ser diferentes. Isso decorre logicamente do controle de borda por lado para uma célula demonstrado no artigo.

**O que acontece com a imagem se eu alterar o tamanho da coluna/linha após definir uma foto como fundo da célula?**

O comportamento depende do [modo de preenchimento](https://reference.aspose.com/slides/pt/cpp/aspose.slides/picturefillmode/) (stretch/tiling). Com estiramento, a imagem se ajusta à nova célula; com ladrilhamento, os ladrilhos são recalculados. O artigo menciona os modos de exibição de imagem em uma célula.

**Posso atribuir um hyperlink a todo o conteúdo de uma célula?**

[Hyperlinks](/slides/pt/cpp/manage-hyperlinks/) são definidos ao nível do trecho (portion) de texto dentro do quadro de texto da célula ou ao nível de toda a tabela/forma. Na prática, você atribui o link a um trecho ou a todo o texto da célula.

**Posso definir fontes diferentes dentro de uma única célula?**

Sim. O quadro de texto de uma célula suporta [porções](https://reference.aspose.com/slides/pt/cpp/aspose.slides/portion/) (runs) com formatação independente — família da fonte, estilo, tamanho e cor.