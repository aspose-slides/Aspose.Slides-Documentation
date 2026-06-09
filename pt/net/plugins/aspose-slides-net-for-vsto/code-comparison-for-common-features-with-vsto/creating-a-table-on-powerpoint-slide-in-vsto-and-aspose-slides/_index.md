---
title: Criando uma Tabela em Slide do PowerPoint no VSTO e Aspose.Slides
type: docs
weight: 90
url: /pt/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---
As etapas a seguir adicionam uma tabela a um slide do Microsoft PowerPoint usando VSTO:

- Criar uma apresentação.
- Adicionar um slide vazio à apresentação.
- Adicionar uma tabela de 15 × 15 ao slide.
- Adicionar texto a cada célula da tabela com tamanho de fonte 10.
- Salvar a apresentação no disco.
## **VSTO**
``` csharp

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
pres.SaveAs("tblVSTO.ppt",
	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	  Microsoft.Office.Core.MsoTriState.msoFalse);
``` 

As etapas a seguir adicionam uma tabela a um slide do Microsoft PowerPoint usando Aspose.Slides:

- Criar uma apresentação.
- Adicionar uma tabela de 15 × 15 ao primeiro slide.
- Adicionar texto a cada célula da tabela com tamanho de fonte 10.
- Gravar a apresentação no disco.
## **Aspose.Slides**
``` csharp

 //Criar uma apresentação
Presentation pres = new Presentation();

//Acessar o primeiro slide
Slide sld = pres.GetSlideByPosition(1);

//Adicionar uma tabela
Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

//Percorrer as linhas
for (int i = 0; i < tbl.RowsNumber; i++)
	//Percorrer as células
	for (int j = 0; j < tbl.ColumnsNumber; j++)
	{
		//Obter o quadro de texto de cada célula
		TextFrame tf = tbl.GetCell(j, i).TextFrame;
		//Adicionar algum texto
		tf.Text = "T" + i.ToString() + j.ToString();
		//Definir o tamanho da fonte como 10
		tf.Paragraphs[0].Portions[0].FontHeight = 10;
		tf.Paragraphs[0].HasBullet = false;
	}

//Gravar a apresentação no disco
pres.Write("tblSLD.ppt");
``` 
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)