---
title: Gerenciar células de tabela em apresentações no .NET
linktitle: Gerenciar Células
type: docs
weight: 30
url: /pt/net/manage-cells/
keywords:
- célula de tabela
- mesclar células
- remover borda
- dividir célula
- imagem na célula
- cor de fundo
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Gerencie facilmente células de tabela no PowerPoint com Aspose.Slides para .NET. Domine o acesso, a modificação e a estilização de células rapidamente para automação de slides perfeita."
---
## **Visão geral**

Aspose.Slides permite que você acesse e modifique células de tabela em apresentações do PowerPoint. Este artigo explica como identificar células de tabela mescladas, remover bordas de células, trabalhar com a numeração de células após mesclar ou dividir células, alterar a cor de fundo de uma célula e adicionar uma imagem dentro de uma célula de tabela. Os exemplos mostram como criar ou abrir uma apresentação, obter uma tabela de um slide, atualizar a formatação da célula por meio das propriedades da célula e salvar a apresentação modificada como um arquivo PPTX.

## **Identificar uma Célula de Tabela Mesclada**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Obtenha a tabela do primeiro slide.
3. Itere pelas linhas e colunas da tabela para encontrar células mescladas.
4. Imprima uma mensagem quando células mescladas forem encontradas.

Este código C# mostra como identificar células de tabela mescladas em uma apresentação:

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // assumindo que Slide#0.Shape#0 é uma tabela
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **Remover Bordas de Células da Tabela**

1. Crie uma instância da classe `Presentation`.
2. Obtenha a referência de um slide através de seu índice.
3. Defina um array de colunas com largura.
4. Defina um array de linhas com altura.
5. Adicione uma tabela ao slide usando o método `AddTable`.
6. Itere por cada célula para limpar as bordas superior, inferior, direita e esquerda.
7. Salve a apresentação modificada como um arquivo PPTX.

Este código C# mostra como remover as bordas das células da tabela:

```c#
// Instancia a classe Presentation que representa um arquivo PPTX
using (Presentation pres = new Presentation())
{
   // Acessa o primeiro slide
    Slide sld = (Slide)pres.Slides[0];

    // Define colunas com larguras e linhas com alturas
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Adiciona a forma de tabela ao slide
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Define o formato da borda para cada célula
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // Grava o arquivo PPTX no disco
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Numeração em Células Mescladas**

Se mesclarmos 2 pares de células (1, 1) x (2, 1) e (1, 2) x (2, 2), a tabela resultante será numerada. Este código C# demonstra o processo:

```c#
    // Instancia a classe Presentation que representa um arquivo PPTX
    using (Presentation presentation = new Presentation())
    {
        // Acessa o primeiro slide
        ISlide sld = presentation.Slides[0];

        // Define colunas com larguras e linhas com alturas
        double[] dblCols = { 70, 70, 70, 70 };
        double[] dblRows = { 70, 70, 70, 70 };

        // Adiciona uma forma de tabela ao slide
        ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

        // Define o formato da borda para cada célula
        foreach (IRow row in tbl.Rows)
        {
            foreach (ICell cell in row)
            {
                cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
                cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
                cell.CellFormat.BorderTop.Width = 5;

                cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
                cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
                cell.CellFormat.BorderBottom.Width = 5;

                cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
                cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
                cell.CellFormat.BorderLeft.Width = 5;

                cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
                cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
                cell.CellFormat.BorderRight.Width = 5;
            }
        }

        // Mescla células (1, 1) x (2, 1)
        tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

        // Mescla células (1, 2) x (2, 2)
        tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

        presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
    }
```

Em seguida, mesclamos ainda mais as células, mesclando (1, 1) e (1, 2). O resultado é uma tabela contendo uma grande célula mesclada em seu centro:

```c#
// Instancia a classe Presentation que representa um arquivo PPTX
using (Presentation presentation = new Presentation())
{
    // Acessa o primeiro slide
    ISlide slide = presentation.Slides[0];

    // Define colunas com larguras e linhas com alturas
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Adiciona uma forma de tabela ao slide
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Define o formato da borda para cada célula
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // Mescla células (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Mescla células (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Mescla células (1, 2) x (2, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    // Grava o arquivo PPTX no disco
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **Numeração em uma Célula Dividida**

Nos exemplos anteriores, quando as células da tabela eram mescladas, a numeração nas outras células não mudava.

Desta vez, usamos uma tabela regular (uma tabela sem células mescladas) e então tentamos dividir a célula (1,1) para obter uma tabela especial. Você pode querer prestar atenção à numeração desta tabela, que pode parecer estranha. No entanto, essa é a forma como o Microsoft PowerPoint numera as células da tabela e o Aspose.Slides faz o mesmo.

Este código C# demonstra o processo descrito:

```c#
// Instancia a classe Presentation que representa um arquivo PPTX
using (Presentation presentation = new Presentation())
{
    // Acessa o primeiro slide
    ISlide slide = presentation.Slides[0];

    // Define colunas com larguras e linhas com alturas
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Adiciona uma forma de tabela ao slide
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Define o formato da borda para cada célula
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // Mescla células (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Mescla células (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Divide a célula (1, 1).
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // Grava o arquivo PPTX no disco
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **Alterar a Cor de Fundo da Célula da Tabela**

Este código C# mostra como alterar a cor de fundo de uma célula de tabela:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // cria uma nova tabela
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // define a cor de fundo para uma célula 
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **Adicionar uma Imagem Dentro de uma Célula de Tabela**

1. Crie uma instância da classe `Presentation`.
2. Obtenha a referência de um slide através de seu índice.
3. Defina um array de colunas com largura.
4. Defina um array de linhas com altura.
5. Adicione uma tabela ao slide usando o método `AddTable`.
6. Crie um objeto `Bitmap` para armazenar o arquivo de imagem.
7. Adicione a imagem bitmap ao objeto `IPPImage`.
8. Defina o `FillFormat` da Célula da Tabela como `Picture`.
9. Adicione a imagem à primeira célula da tabela.
10. Salve a apresentação modificada como um arquivo PPTX

Este código C# mostra como colocar uma imagem dentro de uma célula de tabela ao criar uma tabela:

```c#
 // Instancia a classe Presentation que representa um arquivo PPTX
using (Presentation presentation = new Presentation())
{
    // Acessa o primeiro slide
    ISlide slide = presentation.Slides[0];

    // Define colunas com larguras e linhas com alturas
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Adiciona uma forma de tabela ao slide
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Carrega uma imagem de um arquivo e a adiciona aos recursos da apresentação
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Adiciona a imagem à primeira célula da tabela
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Salva o arquivo PPTX no disco
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Posso definir diferentes espessuras e estilos de linha para os diferentes lados de uma única célula?**

Sim. As bordas [superior](https://reference.aspose.com/slides/pt/net/aspose.slides/cellformat/bordertop/)/[inferior](https://reference.aspose.com/slides/pt/net/aspose.slides/cellformat/borderbottom/)/[esquerda](https://reference.aspose.com/slides/pt/net/aspose.slides/cellformat/borderleft/)/[direita](https://reference.aspose.com/slides/pt/net/aspose.slides/cellformat/borderright/) têm propriedades separadas, portanto a espessura e o estilo de cada lado podem ser diferentes. Isso decorre logicamente do controle de borda por lado para uma célula demonstrado no artigo.

**O que acontece com a imagem se eu alterar o tamanho da coluna/linha depois de definir uma imagem como plano de fundo da célula?**

O comportamento depende do [modo de preenchimento](https://reference.aspose.com/slides/pt/net/aspose.slides/picturefillmode/) (stretch/tile). Com estiramento, a imagem ajusta-se à nova célula; com repetição, os blocos são recalculados. O artigo menciona os modos de exibição da imagem em uma célula.

**Posso atribuir um hiperlink a todo o conteúdo de uma célula?**

[Hyperlinks](/slides/pt/net/manage-hyperlinks/) são definidos no nível do texto (porção) dentro da caixa de texto da célula ou no nível de toda a tabela/forma. Na prática, você atribui o link a uma porção ou a todo o texto da célula.

**Posso definir fontes diferentes dentro de uma única célula?**

Sim. A caixa de texto de uma célula suporta [porções](https://reference.aspose.com/slides/pt/net/aspose.slides/portion/) (runs) com formatação independente — família da fonte, estilo, tamanho e cor.