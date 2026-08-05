---
title: Gestisci i paragrafi di testo PowerPoint in .NET
linktitle: Gestisci paragrafo
type: docs
weight: 40
url: /it/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- aggiungere testo
- aggiungere paragrafo
- gestire testo
- gestire paragrafo
- gestire elenco puntato
- rientro del paragrafo
- rientro sospeso
- punto elenco del paragrafo
- elenco numerato
- elenco puntato
- proprietà del paragrafo
- importare HTML
- testo in HTML
- paragrafo in HTML
- paragrafo in immagine
- testo in immagine
- esportare paragrafo
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Domina la formattazione dei paragrafi con Aspose.Slides per .NET—ottimizza allineamento, spaziatura e stile in presentazioni PPT, PPTX e ODP in C#."
---
## **Introduzione**

Aspose.Slides fornisce tutte le interfacce e le classi necessarie per lavorare con i testi, i paragrafi e le porzioni di PowerPoint in C#.

* Aspose.Slides fornisce l'interfaccia [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) per consentire di aggiungere oggetti che rappresentano un paragrafo. Un oggetto `ITextFame` può contenere uno o più paragrafi (ogni paragrafo viene creato tramite un ritorno a capo).
* Aspose.Slides fornisce l'interfaccia [IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/) per consentire di aggiungere oggetti che rappresentano porzioni. Un oggetto `IParagraph` può contenere una o più porzioni (collezione di oggetti iPortions).
* Aspose.Slides fornisce l'interfaccia [IPortion](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/) per consentire di aggiungere oggetti che rappresentano testi e le loro proprietà di formattazione. 

Un oggetto `IParagraph` è in grado di gestire testi con diverse proprietà di formattazione attraverso i relativi oggetti `IPortion` sottostanti.

## **Aggiungi più paragrafi contenenti più porzioni**

Questi passaggi mostrano come aggiungere un frame di testo contenente 3 paragrafi e ogni paragrafo contenente 3 porzioni:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi un rettangolo [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
4. Ottieni l'ITextFrame associato al [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) .
5. Crea due oggetti [IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/) e aggiungili alla collezione `IParagraphs` del [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) .
6. Crea tre oggetti [IPortion](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/) per ogni nuovo `IParagraph` (due oggetti Portion per il paragrafo predefinito) e aggiungi ogni oggetto `IPortion` alla collezione IPortion di ciascun `IParagraph`.
7. Imposta del testo per ciascuna porzione.
8. Applica le funzionalità di formattazione preferite a ciascuna porzione usando le proprietà di formattazione esposte dall'oggetto `IPortion`.
9. Salva la presentazione modificata.

```c#
// Instanzia una classe Presentation che rappresenta un file PPTX
using (Presentation pres = new Presentation())
{
    // Accede alla prima diapositiva
    ISlide slide = pres.Slides[0];

    // Aggiunge un IAutoShape rettangolare
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Accede al TextFrame dell'AutoShape
    ITextFrame tf = ashp.TextFrame;

    // Crea paragrafi e porzioni con diversi formati di testo
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // Salva la presentazione modificata
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);

}
```

## **Gestisci i punti elenco dei paragrafi**

Le elenchi puntati ti aiutano a organizzare e presentare le informazioni rapidamente ed efficientemente. I paragrafi puntati sono sempre più facili da leggere e comprendere.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi una [autoshape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva selezionata.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) dell'autoshape.
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo usando la classe [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph/) .
8. Imposta il `Type` del punto elenco per il paragrafo a `Symbol` e imposta il carattere del punto elenco.
9. Imposta il `Text` del paragrafo.
10. Imposta l'`Indent` del paragrafo per il punto elenco.
11. Imposta un colore per il punto elenco.
12. Imposta un'altezza per il punto elenco.
13. Aggiungi il nuovo paragrafo alla collezione di paragrafi del `TextFrame`.
14. Aggiungi il secondo paragrafo e ripeti il processo indicato nei passaggi 7-13.
15. Salva la presentazione.

```c#
// Istanzia una classe Presentation che rappresenta un file PPTX
using (Presentation pres = new Presentation())
{

    // Accede alla prima diapositiva
    ISlide slide = pres.Slides[0];


    // Aggiunge e accede all'Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al frame di testo dell'autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // Rimuove il paragrafo predefinito
    txtFrm.Paragraphs.RemoveAt(0);

    // Crea un paragrafo
    Paragraph para = new Paragraph();

    // Imposta lo stile e il simbolo del punto elenco del paragrafo
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Imposta il testo del paragrafo
    para.Text = "Welcome to Aspose.Slides";

    // Imposta il rientro del punto elenco
    para.ParagraphFormat.Indent = 25;

    // Imposta il colore del punto elenco
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // imposta IsBulletHardColor su true per usare il colore del punto elenco personalizzato

    // Imposta l'altezza del punto elenco
    para.ParagraphFormat.Bullet.Height = 100;

    // Aggiunge il paragrafo al frame di testo
    txtFrm.Paragraphs.Add(para);

    // Crea il secondo paragrafo
    Paragraph para2 = new Paragraph();

    // Imposta il tipo e lo stile del punto elenco del paragrafo
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Aggiunge il testo del paragrafo
    para2.Text = "This is numbered bullet";

    // Imposta il rientro del punto elenco
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // imposta IsBulletHardColor su true per usare il colore del punto elenco personalizzato

    // Imposta l'altezza del punto elenco
    para2.ParagraphFormat.Bullet.Height = 100;

    // Aggiunge il paragrafo al frame di testo
    txtFrm.Paragraphs.Add(para2);


    // Salva la presentazione modificata
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Gestisci i punti elenco con immagine**

Le elenchi puntati ti aiutano a organizzare e presentare le informazioni rapidamente ed efficientemente. I paragrafi con immagine sono facili da leggere e comprendere.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi una [autoshape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/) dell'autoshape.
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo usando la classe [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph/) .
7. Carica l'immagine in [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) .
8. Imposta il tipo di punto elenco a [Picture](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) e imposta l'immagine.
9. Imposta il `Text` del Paragraph.
10. Imposta l'`Indent` del Paragraph per il punto elenco.
11. Imposta un colore per il punto elenco.
12. Imposta un'altezza per il punto elenco.
13. Aggiungi il nuovo paragrafo alla collezione di paragrafi del `TextFrame`.
14. Aggiungi il secondo paragrafo e ripeti il processo basandoti sui passaggi precedenti.
15. Salva la presentazione modificata.

```c#
// Istanzia una classe Presentation che rappresenta un file PPTX
Presentation presentation = new Presentation();

// Accede alla prima diapositiva
ISlide slide = presentation.Slides[0];

// Istanzia l'immagine per i punti elenco
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Aggiunge e accede all'Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Accede al frame di testo dell'autoshape
ITextFrame textFrame = autoShape.TextFrame;

// Rimuove il paragrafo predefinito
textFrame.Paragraphs.RemoveAt(0);

// Crea un nuovo paragrafo
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Imposta lo stile del punto elenco del paragrafo e l'immagine
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Imposta l'altezza del punto elenco
paragraph.ParagraphFormat.Bullet.Height = 100;

// Aggiunge il paragrafo al frame di testo
textFrame.Paragraphs.Add(paragraph);

// Scrive la presentazione come file PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Scrive la presentazione come file PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Gestisci i punti elenco a più livelli**

Le elenchi puntati ti aiutano a organizzare e presentare le informazioni rapidamente ed efficientemente. I punti elenco a più livelli sono facili da leggere e comprendere.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi una [autoshape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) nella nuova diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/) dell'autoshape.
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo tramite la classe [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph/) e imposta la profondità a 0.
7. Crea la seconda istanza di paragrafo tramite la classe `Paragraph` e imposta la profondità a 1.
8. Crea la terza istanza di paragrafo tramite la classe `Paragraph` e imposta la profondità a 2.
9. Crea la quarta istanza di paragrafo tramite la classe `Paragraph` e imposta la profondità a 3.
10. Aggiungi i nuovi paragrafi alla collezione di paragrafi del `TextFrame`.
11. Salva la presentazione modificata.

```c#
// Istanzia una classe Presentation che rappresenta un file PPTX
using (Presentation pres = new Presentation())
{

    // Accede alla prima diapositiva
    ISlide slide = pres.Slides[0];
    
    // Aggiunge e accede all'Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al frame di testo dell'autoshape creata
    ITextFrame text = aShp.AddTextFrame("");
    
    // Cancella il paragrafo predefinito
    text.Paragraphs.Clear();

    // Aggiunge il primo paragrafo
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Imposta il livello del punto elenco
    para1.ParagraphFormat.Depth = 0;

    // Aggiunge il secondo paragrafo
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Imposta il livello del punto elenco
    para2.ParagraphFormat.Depth = 1;

    // Aggiunge il terzo paragrafo
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Imposta il livello del punto elenco
    para3.ParagraphFormat.Depth = 2;

    // Aggiunge il quarto paragrafo
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Imposta il livello del punto elenco
    para4.ParagraphFormat.Depth = 3;

    // Aggiunge i paragrafi alla collezione
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Scrive la presentazione come file PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Gestisci un paragrafo con un elenco numerato personalizzato**

L'interfaccia [IBulletFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/) fornisce la proprietà [NumberedBulletStartWith](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/numberedbulletstartwith) e altre che consentono di gestire paragrafi con numerazione o formattazione personalizzata.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
2. Accedi alla diapositiva contenente il paragrafo.
3. Aggiungi una [autoshape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/) dell'autoshape.
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo tramite la classe [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph/) e imposta [NumberedBulletStartWith](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/numberedbulletstartwith) a 2.
7. Crea la seconda istanza di paragrafo tramite la classe `Paragraph` e imposta `NumberedBulletStartWith` a 3.
8. Crea la terza istanza di paragrafo tramite la classe `Paragraph` e imposta `NumberedBulletStartWith` a 7.
9. Aggiungi i nuovi paragrafi alla collezione di paragrafi del `TextFrame`.
10. Salva la presentazione modificata.

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Accede al frame di testo dell'autoshape creata
	ITextFrame textFrame = shape.TextFrame;

	// Rimuove il paragrafo predefinito esistente
	textFrame.Paragraphs.RemoveAt(0);

	// Prima lista
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **Imposta il rientro della prima riga per un paragrafo**

Utilizza la proprietà [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) per controllare il rientro della prima riga di un paragrafo. Questa proprietà sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga a destra, mentre le righe rimanenti rimangono allineate al corpo del paragrafo.

Usa [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/marginleft/) quando è necessario spostare l'intero paragrafo. Usa [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) quando è necessario spostare solo la prima riga.

L'esempio seguente crea diversi paragrafi e applica valori `Indent` diversi per dimostrare come il rientro della prima riga influisce sul layout del paragrafo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) .
2. Accedi alla diapositiva target.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Aggiungi un [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/) vuoto alla forma e rimuovi il paragrafo predefinito.
5. Crea diversi paragrafi e imposta valori [Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) differenti per ciascuno.
6. Aggiungi i paragrafi al frame di testo.
7. Salva la presentazione modificata.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Imposta rientro sospeso per un paragrafo**

Un rientro sospeso è un layout di paragrafo in cui la prima riga inizia a sinistra delle righe rimanenti. In Aspose.Slides, crei questo effetto con la proprietà [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/). Imposta `Indent` a un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

Nel pratico, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/marginleft/) definisce la posizione sinistra del corpo del paragrafo, e [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) definisce la posizione della prima riga rispetto a quel margine. Per creare un rientro sospeso, imposta un valore positivo per `MarginLeft` e un valore negativo per `Indent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le righe avvolte devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima riga.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) .
2. Accedi alla diapositiva target.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Aggiungi un [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/) vuoto alla forma e rimuovi il paragrafo predefinito.
5. Crea paragrafi e imposta un valore positivo di [MarginLeft](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/marginleft/) per ciascun paragrafo.
6. Imposta un valore negativo di [Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) per creare l'effetto di rientro sospeso.
7. Aggiungi i paragrafi al frame di testo.
8. Salva la presentazione modificata.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![The hanging indent of the paragraphs](hanging_indent.png)

## **Gestisci le proprietà finali del paragrafo**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
2. Ottieni il riferimento della diapositiva contenente il paragrafo tramite la sua posizione.
3. Aggiungi una [autoshape](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Aggiungi un [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/) con due paragrafi al rettangolo.
5. Imposta `FontHeight` e il tipo di carattere per i paragrafi.
6. Imposta le proprietà End per i paragrafi.
7. Scrivi la presentazione modificata come file PPTX.

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Importa testo HTML nei paragrafi**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi una [autoshape](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/) alla diapositiva.
4. Aggiungi e accedi al [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) dell'autoshape.
5. Rimuovi il paragrafo predefinito nel `ITextFrame`.
6. Leggi il file HTML sorgente con un TextReader.
7. Crea la prima istanza di paragrafo tramite la classe [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph/) .
8. Aggiungi il contenuto del file HTML letto dal TextReader alla [ParagraphCollection](https://reference.aspose.com/slides/it/net/aspose.slides/paragraphcollection/) del TextFrame.
9. Salva la presentazione modificata.

```c#
// Crea un'istanza vuota di presentazione
using (Presentation pres = new Presentation())
{
    // Accede alla prima diapositiva predefinita della presentazione
    ISlide slide = pres.Slides[0];

    // Aggiunge l'AutoShape per contenere il contenuto HTML
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Aggiunge il frame di testo alla forma
    ashape.AddTextFrame("");

    // Cancella tutti i paragrafi nel frame di testo aggiunto
    ashape.TextFrame.Paragraphs.Clear();

    // Carica il file HTML usando lo StreamReader
    TextReader tr = new StreamReader("file.html");

    // Aggiunge il testo dallo stream reader HTML al frame di testo
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Salva la presentazione
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Esporta il testo del paragrafo in HTML**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) e carica la presentazione desiderata.
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Accedi alla forma contenente il testo che sarà esportato in HTML.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/) della forma.
5. Crea un'istanza di `StreamWriter` e aggiungi il nuovo file HTML.
6. Fornisci un indice iniziale a StreamWriter ed esporta i paragrafi preferiti.

```c#
// Carica il file di presentazione
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Accede alla prima diapositiva predefinita della presentazione
    ISlide slide = pres.Slides[0];

    // Accede all'indice richiesto
    int index = 0;

    // Accede alla forma aggiunta
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Scrive i dati dei paragrafi in HTML specificando l'indice di inizio del paragrafo e il numero di paragrafi da copiare
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Salva un paragrafo come immagine**

Nella presente sezione, esploreremo due esempi che dimostrano come salvare un paragrafo di testo, rappresentato dall'interfaccia [IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/), come immagine. Entrambi gli esempi includono l'ottenimento dell'immagine di una forma contenente il paragrafo usando i metodi `GetImage` dell'interfaccia [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/), il calcolo dei limiti del paragrafo all'interno della forma e l'esportazione come immagine bitmap. Questi approcci consentono di estrarre parti specifiche del testo da presentazioni PowerPoint e salvarle come immagini separate, utili per ulteriori utilizzi.

Supponiamo di avere un file di presentazione chiamato sample.pptx con una diapositiva, dove la prima forma è una casella di testo contenente tre paragrafi.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Esempio 1**

In questo esempio otteniamo il secondo paragrafo come immagine. Per fare ciò, estraiamo l'immagine della forma dalla prima diapositiva della presentazione e poi calcoliamo i limiti del secondo paragrafo nel frame di testo della forma. Il paragrafo viene quindi ridisegnato su una nuova immagine bitmap, salvata in formato PNG. Questo metodo è particolarmente utile quando è necessario salvare un paragrafo specifico come immagine separata preservando le dimensioni e la formattazione esatte del testo.

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

Il risultato:

![The paragraph image](paragraph_to_image_output.png)

**Esempio 2**

Questo esempio estende l'approccio precedente aggiungendo fattori di scala all'immagine del paragrafo. La forma viene estratta dalla presentazione e salvata come immagine con un fattore di scala di `2`. Ciò consente di ottenere un'output a risoluzione più alta quando si esporta il paragrafo. I limiti del paragrafo vengono poi calcolati tenendo conto della scala. La scalatura può essere particolarmente utile quando è necessaria un'immagine più dettagliata, ad esempio per l'uso in materiali stampati di alta qualità.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap with scaling.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **FAQ**

**Posso disabilitare completamente l'andare a capo automatico all'interno di un TextFrame?**

Sì. Usa l'impostazione di avvolgimento del TextFrame ([WrapText](https://reference.aspose.com/slides/it/net/aspose.slides/textframeformat/wraptext/)) per disattivare l'andare a capo, così le linee non si interromperanno ai bordi del frame.

**Come posso ottenere i limiti esatti del paragrafo sulla diapositiva?**

Puoi recuperare il rettangolo di delimitazione del paragrafo (e anche di una singola porzione) per conoscere la sua posizione e dimensione precise sulla diapositiva.

**Dove è controllato l'allineamento del paragrafo (sinistra/destra/centrato/giustificato)?**

[Alignment](https://reference.aspose.com/slides/it/net/aspose.slides/paragraphformat/alignment/) è un'impostazione a livello di paragrafo in [ParagraphFormat](https://reference.aspose.com/slides/it/net/aspose.slides/paragraphformat/); si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

**Posso impostare una lingua di correzione ortografica per solo una parte di un paragrafo (ad esempio, una parola)?**

Sì. La lingua viene impostata a livello di porzione ([PortionFormat.LanguageId](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/languageid/)), quindi più lingue possono coesistere all'interno dello stesso paragrafo.