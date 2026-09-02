---
title: Gestire le caselle di testo nelle presentazioni in .NET
linktitle: Gestire la casella di testo
type: docs
weight: 20
url: /it/net/manage-textbox/
keywords:
- casella di testo
- frame di testo
- aggiungere testo
- aggiornare testo
- creare casella di testo
- verificare casella di testo
- aggiungere colonna di testo
- aggiungere collegamento ipertestuale
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides per .NET semplifica la creazione, la modifica e la clonazione delle caselle di testo in file PowerPoint e OpenDocument, migliorando l'automazione delle tue presentazioni."
---
## **Introduzione**

I testi nelle diapositive si trovano tipicamente in caselle di testo o forme. Pertanto, per aggiungere testo a una diapositiva, devi prima aggiungere una casella di testo e poi inserire del testo all'interno della casella.

Per consentirti di aggiungere una forma che possa contenere testo, Aspose.Slides per .NET fornisce l'interfaccia [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape).

{{% alert title="Note" color="warning" %}} 

Aspose.Slides fornisce anche l'interfaccia [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape) per consentirti di aggiungere forme alle diapositive. Tuttavia, non tutte le forme aggiunte tramite l'interfaccia `IShape` possono contenere testo. Le forme aggiunte tramite l'interfaccia [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape) tipicamente contengono testo.

Pertanto, quando lavori con una forma esistente a cui vuoi aggiungere testo, potresti voler verificare e confermare che sia stata convertita tramite l'interfaccia `IAutoShape`. Solo in quel caso potrai lavorare con [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/properties/textframe), che è una proprietà di `IAutoShape`. Vedi la sezione [Update Text](https://docs.aspose.com/slides/it/net/manage-textbox/#update-text) in questa pagina. 

{{% /alert %}}

## **Creare una casella di testo su una diapositiva**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation). 
2. Ottieni il riferimento della prima diapositiva tramite il suo indice. 
3. Aggiungi un oggetto [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape) con [ShapeType](https://reference.aspose.com/slides/it/net/aspose.slides/igeometryshape/properties/shapetype) impostato su `Rectangle` nella posizione desiderata sulla diapositiva e ottieni il riferimento per il nuovo oggetto `IAutoShape`. 
4. Aggiungi la proprietà `TextFrame` all'oggetto `IAutoShape` che conterrà del testo. Nell'esempio seguente, abbiamo aggiunto questo testo: *Aspose TextBox* 
5. Infine, scrivi il file PPTX tramite l'oggetto `Presentation`. 

Questo codice C#—un'implementazione dei passaggi sopra—mostra come aggiungere testo a una diapositiva:

```c#
using Aspose.Slides;

// Istanzia PresentationEx
using (Presentation pres = new Presentation())
{

    // Ottiene la prima diapositiva nella presentazione
    ISlide sld = pres.Slides[0];

    // Aggiunge un AutoShape con tipo impostato a Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Aggiunge TextFrame al rettangolo
    ashp.AddTextFrame(" ");

    // Accede al TextFrame
    ITextFrame txtFrame = ashp.TextFrame;

    // Crea l'oggetto Paragraph per il TextFrame
    IParagraph para = txtFrame.Paragraphs[0];

    // Crea un oggetto Portion per il paragrafo
    IPortion portion = para.Portions[0];

    // Imposta il testo
    portion.Text = "Aspose TextBox";

    // Salva la presentazione su disco
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Verificare la presenza di una forma casella di testo**

Aspose.Slides fornisce la proprietà [IsTextBox](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/istextbox/) dell'interfaccia [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) per esaminare le forme e identificare le caselle di testo.

![Casella di testo e forma](istextbox.png)

Questo codice C# mostra come verificare se una forma è stata creata come casella di testo: 

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```

Nota che se aggiungi semplicemente un'autoshape usando il metodo `AddAutoShape` dell'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/), la proprietà `IsTextBox` dell'autoshape restituirà `false`. Tuttavia, dopo aver aggiunto testo all'autoshape mediante il metodo `AddTextFrame` o la proprietà `Text`, la proprietà `IsTextBox` restituisce `true`.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox è false
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox è true

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox è false
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox è true

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox è false
    shape3.AddTextFrame("");
    // shape3.IsTextBox è false

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox è false
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox è false
}
```

## **Trovare la forma che possiede un TextFrame**

Nel codice generico di elaborazione del testo, potresti ricevere un [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) senza sapere già quale oggetto presentazione lo contiene. Usa la proprietà [ITextFrame.ParentShape](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/parentshape/) per tornare alla [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/) proprietaria.

Per un TextFrame che appartiene a un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) o a un'altra forma contenente testo, [ITextFrame.ParentShape](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/parentshape/) è impostato e [ITextFrame.ParentCell](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/parentcell/) è `null`. Entrambe le proprietà sono proprietà di sola lettura, quindi leggerle non cambia la proprietà. Controlla sempre il valore restituito per `null` prima di accedere alla forma.

Per un esempio completo che identifica i proprietari di forma e di cella tabella, incluse le forme associate a nodi SmartArt, vedi [Search and Replace Text](/slides/it/net/search-and-replace-text/).

## **Aggiungere colonne a una casella di testo**

Aspose.Slides fornisce le proprietà [ColumnCount](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/properties/columncount) e [ColumnSpacing](https://reference.aspose.com/slides/it/net/aspose.slides/textframeformat/properties/columnspacing) (dall'interfaccia [ITextFrameFormat](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat) e dalla classe [TextFrameFormat](https://reference.aspose.com/slides/it/net/aspose.slides/textframeformat)) per consentirti di aggiungere colonne alle caselle di testo. Puoi specificare il numero di colonne in una casella di testo e poi impostare la spaziatura in punti tra le colonne. 

Questo codice C# dimostra l'operazione descritta: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	// Ottiene la prima diapositiva nella presentazione
	ISlide slide = presentation.Slides[0];

	// Aggiunge un AutoShape con tipo impostato a Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Aggiunge TextFrame al rettangolo
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Ottiene il formato testo del TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Specifica il numero di colonne nel TextFrame
	format.ColumnCount = 3;

	// Specifica la spaziatura tra le colonne
	format.ColumnSpacing = 10;

	// Salva la presentazione
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Aggiungere colonne a un TextFrame**
Aspose.Slides per .NET fornisce la proprietà [ColumnCount](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat/properties/columncount) (dall'interfaccia [ITextFrameFormat](https://reference.aspose.com/slides/it/net/aspose.slides/itextframeformat)) che consente di aggiungere colonne nei TextFrame. Attraverso questa proprietà, puoi specificare il numero di colonne desiderato in un TextFrame. 

Questo codice C# mostra come aggiungere una colonna all'interno di un TextFrame:

```c#
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.IsNaN(((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing));
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```

## **Aggiornare il testo**

Aspose.Slides ti consente di modificare o aggiornare il testo contenuto in una casella di testo o tutti i testi contenuti in una presentazione. 

Questo codice C# dimostra un'operazione in cui tutti i testi di una presentazione vengono aggiornati o modificati:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Controlla se la forma supporta il text frame (IAutoShape).
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Itera attraverso i paragrafi nel text frame
               {
                   foreach (IPortion portion in paragraph.Portions) //Itera attraverso ogni porzione nel paragrafo
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Cambia il testo
                       portion.PortionFormat.FontBold = NullableBool.True; //Cambia la formattazione
                   }
               }
           }
       }
   }
  
   //Salva la presentazione modificata
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Aggiungere una casella di testo con un collegamento ipertestuale** 

Puoi inserire un collegamento all'interno di una casella di testo. Quando la casella di testo viene cliccata, gli utenti vengono indirizzati ad aprire il collegamento. 

1. Crea un'istanza della classe `Presentation`. 
2. Ottieni il riferimento della prima diapositiva tramite il suo indice.  
3. Aggiungi un oggetto `AutoShape` con `ShapeType` impostato su `Rectangle` nella posizione desiderata sulla diapositiva e ottieni un riferimento al nuovo oggetto AutoShape. 
4. Aggiungi un `TextFrame` all'oggetto `AutoShape` che contiene *Aspose TextBox* come testo predefinito. 
5. Istanziate la classe `IHyperlinkManager`. 
6. Assegna l'oggetto `IHyperlinkManager` alla proprietà [HyperlinkClick](https://reference.aspose.com/slides/it/net/aspose.slides/shape/properties/hyperlinkclick) associata alla porzione desiderata del `TextFrame`. 
7. Infine, scrivi il file PPTX tramite l'oggetto `Presentation`. 

Questo codice C#—un'implementazione dei passaggi sopra—mostra come aggiungere una casella di testo con un collegamento ipertestuale a una diapositiva:

```c#
using Aspose.Slides;

// Istanzia una classe Presentation che rappresenta un PPTX
Presentation pptxPresentation = new Presentation();

// Ottiene la prima diapositiva nella presentazione
ISlide slide = pptxPresentation.Slides[0];

// Aggiunge un oggetto AutoShape con tipo impostato a Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Converte la forma in AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Accede alla proprietà ITextFrame associata all'AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Aggiunge del testo al frame
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Imposta l'Hyperlink per il testo della porzione
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Salva la presentazione PPTX
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Qual è la differenza tra una casella di testo e un segnaposto di testo quando si lavora con le diapositive master?**

Un [placeholder](/slides/it/net/manage-placeholder/) eredita stile/posizione dal [master](https://reference.aspose.com/slides/it/net/aspose.slides/masterslide/) e può essere sovrascritto nei [layouts](https://reference.aspose.com/slides/it/net/aspose.slides/layoutslide/), mentre una normale casella di testo è un oggetto indipendente su una diapositiva specifica e non cambia quando si cambiano i layout.

**Come posso eseguire una sostituzione di testo in blocco su tutta la presentazione senza modificare il testo all'interno di grafici, tabelle e SmartArt?**

Limita l'iterazione alle auto‑shape che hanno TextFrame ed escludi gli oggetti incorporati ([charts](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/it/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/smartart/)) attraversando le loro collezioni separatamente o saltando quei tipi di oggetto.