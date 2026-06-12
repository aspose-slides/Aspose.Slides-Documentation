---
title: Come creare presentazioni Hello World in .NET
linktitle: Presentazione Hello World
type: docs
weight: 10
url: /it/net/how-to-create-hello-world-presentation-document/
keywords:
- migrazione
- hello world
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
- description: "Crea una presentazione PowerPoint PPT, PPTX e ODP Hello World in .NET con Aspose.Slides utilizzando sia le API legacy sia quelle moderne in una semplice guida."
---
{{% alert color="primary" %}} 
È stata rilasciata una nuova [Aspose.Slides for .NET API](/slides/it/net/) e ora questo unico prodotto supporta la capacità di generare documenti PowerPoint da zero e modificare quelli esistenti.
{{% /alert %}} 
## **Supporto al codice legacy**
Per utilizzare il codice legacy sviluppato con le versioni di Aspose.Slides per .NET precedenti alla 13.x, è necessario apportare alcune modifiche minori al proprio codice e il codice funzionerà come prima. Tutte le classi presenti nella vecchia Aspose.Slides per .NET nei namespace Aspose.Slide e Aspose.Slides.Pptx sono ora unite in un unico namespace Aspose.Slides. Si prega di esaminare il seguente semplice frammento di codice per creare un documento di presentazione Hello World nell'API legacy di Aspose.Slides e seguire i passaggi che descrivono come migrare alla nuova API unificata.
## **Approccio legacy di Aspose.Slides per .NET**
```c#
//Istanzia un oggetto Presentation che rappresenta un file PPT
Presentation pres = new Presentation();

//Crea un oggetto License
License license = new License();

//Imposta la licenza di Aspose.Slides per .NET per evitare le limitazioni della valutazione
license.SetLicense("Aspose.Slides.lic");

//Aggiunta di una slide vuota alla presentazione e ottenimento del riferimento della
//slide vuota
Slide slide = pres.AddEmptySlide();

//Aggiunta di un rettangolo (X=2400, Y=1800, Larghezza=1000 & Altezza=500) alla slide
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Nascondere le linee del rettangolo
rect.LineFormat.ShowLines = false;

//Aggiunta di un frame di testo al rettangolo con "Hello World" come testo predefinito
rect.AddTextFrame("Hello World");

//Rimozione della prima slide della presentazione, che è sempre aggiunta da
//Aspose.Slides per .NET per impostazione predefinita durante la creazione della presentazione
pres.Slides.RemoveAt(0);

//Scrittura della presentazione come file PPT
pres.Write("C:\\hello.ppt");
```

## **Nuovo approccio Aspose.Slides per .NET 13.x**
```c#
// Istanzia una presentazione
Presentation pres = new Presentation();

// Ottieni la prima slide
ISlide sld = (ISlide)pres.Slides[0];

// Aggiungi un AutoShape di tipo Rettangolo
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Aggiungi ITextFrame al Rettangolo
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```