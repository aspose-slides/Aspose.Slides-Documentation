---
title: Creare tabelle usando VSTO e Aspose.Slides per .NET
linktitle: Creare tabelle
type: docs
weight: 50
url: /it/net/creating-a-table-on-powerpoint-slide/
keywords:
- creare tabella
- migrazione
- VSTO
- automazione Office
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Migra dall'automazione di Microsoft Office ad Aspose.Slides per .NET e crea tabelle nelle diapositive PowerPoint (PPT, PPTX) in C# con formattazione flessibile."
---
{{% alert color="primary" %}} 

Le tabelle sono ampiamente utilizzate per visualizzare dati nelle diapositive di presentazione. Questo articolo mostra come creare programmaticamente una tabella 15 x 15 con una dimensione del carattere di 10, utilizzando prima [VSTO 2008](/slides/it/net/creating-a-table-on-powerpoint-slide/) e poi [Aspose.Slides for .NET](/slides/it/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **Creare tabelle**
#### **Esempio VSTO 2008**
I passaggi seguenti aggiungono una tabella a una diapositiva Microsoft PowerPoint utilizzando VSTO:

1. Creare una presentazione.
1. Aggiungere una diapositiva vuota alla presentazione.
1. Aggiungere una tabella 15 x 15 alla diapositiva.
1. Aggiungere testo a ciascuna cella della tabella con una dimensione del carattere di 10.
1. Salvare la presentazione su disco.

```c#
//Crea una presentazione
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Aggiungi una diapositiva vuota
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Aggiungi una tabella 15 x 15
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//Scorri tutte le righe
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Scorri tutte le celle nella riga
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Ottieni il frame di testo di ogni cella
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Aggiungi del testo
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Imposta la dimensione del carattere del testo a 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Salva la presentazione su disco
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Esempio Aspose.Slides per .NET**
I passaggi seguenti aggiungono una tabella a una diapositiva Microsoft PowerPoint utilizzando Aspose.Slides:

1. Creare una presentazione.
1. Aggiungere una tabella 15 x 15 alla prima diapositiva.
1. Aggiungere testo a ciascuna cella della tabella con una dimensione del carattere di 10.
1. Scrivere la presentazione su disco.

```c#
Presentation pres = new Presentation();

//Accedi alla prima diapositiva
ISlide sld = pres.Slides[0];

//Definisci colonne con larghezze e righe con altezze
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Aggiungi una tabella
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Imposta il formato del bordo per ogni cella
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Ottieni il frame di testo di ogni cella
		ITextFrame tf = cell.TextFrame;
		//Aggiungi del testo
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Imposta la dimensione del carattere a 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Scrivi la presentazione su disco
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```