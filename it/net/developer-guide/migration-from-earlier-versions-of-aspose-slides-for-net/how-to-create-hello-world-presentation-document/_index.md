---
title: Come creare presentazioni Hello World in .NET
linktitle: Presentazione Hello World
type: docs
weight: 10
url: /it/net/how-to-create-hello-world-presentation-document/
keywords:
- migrazione
- ciao mondo
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
description: "Crea una presentazione PowerPoint PPT, PPTX e ODP Hello World in .NET con Aspose.Slides usando sia le API legacy che quelle moderne in una semplice guida."
---
{{% alert color="info" %}} 

È stata rilasciata una nuova [Aspose.Slides for .NET API](/slides/it/net/) e ora questo singolo prodotto supporta la capacità di generare documenti PowerPoint da zero e modificare quelli esistenti.

{{% /alert %}} 
## **Supporto per il codice legacy**
Per utilizzare il codice legacy sviluppato con versioni di Aspose.Slides per .NET precedenti alla 13.x, è necessario apportare alcune piccole modifiche al proprio codice e il codice funzionerà come prima. Tutte le classi che erano presenti nella vecchia Aspose.Slides per .NET nei namespace Aspose.Slide e Aspose.Slides.Pptx sono ora fuse in un unico namespace Aspose.Slides. Si prega di dare un'occhiata al seguente semplice snippet di codice per creare un documento di presentazione Hello World nell'API legacy di Aspose.Slides e seguire i passaggi che descrivono come migrare alla nuova API unificata.
## **Approccio Legacy di Aspose.Slides per .NET**
```c#
using System.Drawing;
using Aspose.Slides;

//Istanzia un oggetto Presentation che rappresenta un file PPT
Presentation pres = new Presentation();

//Crea un oggetto License
License license = new License();

//Imposta la licenza di Aspose.Slides per .NET per evitare le limitazioni di valutazione
license.SetLicense("Aspose.Slides.lic");

//Aggiunge una diapositiva vuota alla presentazione e ottiene il riferimento di
//quella diapositiva vuota
Slide slide = pres.AddEmptySlide();

//Aggiunge un rettangolo (X=2400, Y=1800, Larghezza=1000 & Altezza=500) alla diapositiva
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Nasconde le linee del rettangolo
rect.LineFormat.ShowLines = false;

//Aggiunge un frame di testo al rettangolo con "Hello World" come testo predefinito
rect.AddTextFrame("Hello World");

//Rimuove la prima diapositiva della presentazione che è sempre aggiunta da
//Aspose.Slides per .NET di default durante la creazione della presentazione
pres.Slides.RemoveAt(0);

//Scrive la presentazione come file PPT
pres.Write("C:\\hello.ppt");
```



## **Nuovo approccio Aspose.Slides per .NET 13.x**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantiate Presentation
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```