---
title: Criando Tabelas Usando VSTO e Aspose.Slides para .NET
linktitle: Criando Tabelas
type: docs
weight: 50
url: /pt/net/creating-a-table-on-powerpoint-slide/
keywords:
- criar tabela
- migração
- VSTO
- Automação Office
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Migre da automação do Microsoft Office para Aspose.Slides para .NET e crie tabelas em slides PowerPoint (PPT, PPTX) usando C# com formatação flexível."
---
{{% alert color="info" %}} 

As tabelas são amplamente usadas para exibir dados em slides de apresentação. Este artigo mostra como criar uma tabela 15 × 15 com tamanho de fonte 10 programaticamente usando primeiro [VSTO 2008](/slides/pt/net/creating-a-table-on-powerpoint-slide/) e depois [Aspose.Slides for .NET](/slides/pt/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **Criando Tabelas**
#### **Exemplo VSTO 2008**
Os passos a seguir adicionam uma tabela a um slide do Microsoft PowerPoint usando VSTO:

1. Criar uma apresentação.
1. Adicionar um slide em branco à apresentação.
1. Adicionar uma tabela 15 × 15 ao slide.
1. Adicionar texto a cada célula da tabela com tamanho de fonte 10.
1. Salvar a apresentação no disco.

```c#
//Criar uma apresentação
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Adicionar um slide em branco
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Add a 15 x 15 table
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//Percorrer todas as linhas
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Percorrer todas as células da linha
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Obter o quadro de texto de cada célula
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Adicionar algum texto
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Definir o tamanho da fonte do texto como 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Salvar a apresentação no disco
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Exemplo Aspose.Slides for .NET**
Os passos a seguir adicionam uma tabela a um slide do Microsoft PowerPoint usando Aspose.Slides:

1. Criar uma apresentação.
1. Adicionar uma tabela 15 × 15 ao primeiro slide.
1. Adicionar texto a cada célula da tabela com tamanho de fonte 10.
1. Gravar a apresentação no disco.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

//Acessar o primeiro slide
ISlide sld = pres.Slides[0];

//Definir colunas com larguras e linhas com alturas
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Adicionar uma tabela
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Definir o formato de borda para cada célula
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Obter o quadro de texto de cada célula
		ITextFrame tf = cell.TextFrame;
		//Adicionar algum texto
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Definir tamanho da fonte como 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Gravar a apresentação no disco
pres.Save("tblSLD.ppt", SaveFormat.Ppt);
```