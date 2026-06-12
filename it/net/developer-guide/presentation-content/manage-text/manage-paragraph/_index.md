---
title: Gestire i paragrafi di testo PowerPoint in .NET
linktitle: Gestire il paragrafo
type: docs
weight: 40
url: /it/net/manage-paragraph/
keywords:
- aggiungere testo
- aggiungere paragrafo
- gestire testo
- gestire paragrafo
- gestire elenco puntato
- indentazione paragrafo
- indentazione sporgente
- bullet paragrafo
- lista numerata
- lista puntata
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
description: "Domina la formattazione dei paragrafi con Aspose.Slides per .NET—ottimizza allineamento, spaziatura e stile nelle presentazioni PPT, PPTX e ODP in C#."
---
## **Introduzione**

Aspose.Slides fornisce tutte le interfacce e le classi di cui hai bisogno per lavorare con i testi, i paragrafi e le porzioni di PowerPoint in C#.

* Aspose.Slides fornisce l'interfaccia [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) per consentirti di aggiungere oggetti che rappresentano un paragrafo. Un oggetto `ITextFame` può contenere uno o più paragrafi (ogni paragrafo viene creato tramite un ritorno a capo).
* Aspose.Slides fornisce l'interfaccia [IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/) per consentirti di aggiungere oggetti che rappresentano porzioni. Un oggetto `IParagraph` può contenere una o più porzioni (collezione di oggetti iPortions).
* Aspose.Slides fornisce l'interfaccia [IPortion](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/) per consentirti di aggiungere oggetti che rappresentano testi e le loro proprietà di formattazione.

Un oggetto `IParagraph` è in grado di gestire testi con diverse proprietà di formattazione tramite i relativi oggetti `IPortion` sottostanti.

## **Aggiungere più paragrafi contenenti più porzioni**

Questi passaggi mostrano come aggiungere un riquadro di testo contenente 3 paragrafi e ciascun paragrafo contenente 3 porzioni:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi un rettangolo [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
4. Ottieni l'ITextFrame associato al [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/).
5. Crea due oggetti [IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/) e aggiungili alla collezione `IParagraphs` del [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/).
6. Creare tre oggetti [IPortion](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/) per ciascun nuovo `IParagraph` (due oggetti Portion per il paragrafo predefinito) e aggiungere ogni oggetto `IPortion` alla collezione IPortion di ciascun `IParagraph`.
7. Imposta del testo per ogni porzione.
8. Applica le funzionalità di formattazione preferite a ogni porzione usando le proprietà di formattazione esposte dall'oggetto `IPortion`.
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

    // Crea paragrafi e porzioni con formati di testo diversi
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

## **Gestire i punti elenco del paragrafo**

Le liste puntate ti aiutano a organizzare e presentare le informazioni rapidamente ed efficientemente. I paragrafi puntati sono sempre più facili da leggere e comprendere.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi un [autoshape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva selezionata.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) dell'autoshape. 
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo usando la classe [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph/).
8. Imposta il `Type` del bullet per il paragrafo su `Symbol` e imposta il carattere del bullet.
9. Imposta il `Text` del paragrafo.
10. Imposta l'`Indent` del paragrafo per il bullet.
11. Imposta un colore per il bullet.
12. Imposta un'altezza per il bullet.
13. Aggiungi il nuovo paragrafo alla collezione di paragrafi del `TextFrame`.
14. Aggiungi il secondo paragrafo e ripeti il processo descritto nei passaggi 7‑13.
15. Salva la presentazione.

```c#
// Instanzia una classe Presentation che rappresenta un file PPTX
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

    // Imposta lo stile del bullet del paragrafo e il simbolo
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Imposta il testo del paragrafo
    para.Text = "Welcome to Aspose.Slides";

    // Imposta l'indentazione del bullet
    para.ParagraphFormat.Indent = 25;

    // Imposta il colore del bullet
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // imposta IsBulletHardColor su true per usare il colore del bullet personalizzato

    // Imposta l'altezza del bullet
    para.ParagraphFormat.Bullet.Height = 100;

    // Aggiunge il paragrafo al frame di testo
    txtFrm.Paragraphs.Add(para);

    // Crea il secondo paragrafo
    Paragraph para2 = new Paragraph();

    // Imposta il tipo e lo stile del bullet del paragrafo
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Aggiunge il testo del paragrafo
    para2.Text = "This is numbered bullet";

    // Imposta l'indentazione del bullet
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // imposta IsBulletHardColor su true per usare il colore del bullet personalizzato

    // Imposta l'altezza del bullet
    para2.ParagraphFormat.Bullet.Height = 100;

    // Aggiunge il paragrafo al frame di testo
    txtFrm.Paragraphs.Add(para2);


    // Salva la presentazione modificata
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Gestire i bullet con immagine**

Le liste puntate ti aiutano a organizzare e presentare le informazioni rapidamente ed efficientemente. I paragrafi con immagine sono facili da leggere e comprendere.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi un [autoshape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/) dell'autoshape.
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo usando la classe [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph/).
7. Carica l'immagine in [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/).
8. Imposta il tipo di bullet su [Picture](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) e imposta l'immagine.
9. Imposta il `Text` del Paragraph.
10. Imposta l'`Indent` del Paragraph per il bullet.
11. Imposta un colore per il bullet.
12. Imposta un'altezza per il bullet.
13. Aggiungi il nuovo paragrafo alla collezione di paragrafi del `TextFrame`.
14. Aggiungi il secondo paragrafo e ripeti il processo basandoti sui passaggi precedenti.
15. Salva la presentazione modificata.

```c#
// Instanzia una classe Presentation che rappresenta un file PPTX
Presentation presentation = new Presentation();

// Accede alla prima diapositiva
ISlide slide = presentation.Slides[0];

// Istanzia l'immagine per i bullet
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Aggiunge e accede all'Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Accede al textframe dell'autoshape
ITextFrame textFrame = autoShape.TextFrame;

// Rimuove il paragrafo predefinito
textFrame.Paragraphs.RemoveAt(0);

// Crea un nuovo paragrafo
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Imposta lo stile del bullet del paragrafo e l'immagine
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Imposta l'altezza del bullet
paragraph.ParagraphFormat.Bullet.Height = 100;

// Aggiunge il paragrafo al text frame
textFrame.Paragraphs.Add(paragraph);

// Scrive la presentazione come file PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Scrive la presentazione come file PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Gestire i bullet a più livelli**

Le liste puntate ti aiutano a organizzare e presentare le informazioni rapidamente ed efficientemente. I bullet a più livelli sono facili da leggere e comprendere.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi un [autoshape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) nella nuova diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/) dell'autoshape.
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Creare la prima istanza di paragrafo tramite la classe [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph/) e impostare la profondità a 0.
7. Creare la seconda istanza di paragrafo tramite la classe `Paragraph` e impostare la profondità a 1.
8. Creare la terza istanza di paragrafo tramite la classe `Paragraph` e impostare la profondità a 2.
9. Creare la quarta istanza di paragrafo tramite la classe `Paragraph` e impostare la profondità a 3.
10. Aggiungi i nuovi paragrafi alla collezione di paragrafi del `TextFrame`.
11. Salva la presentazione modificata.

```c#
// Instanzia una classe Presentation che rappresenta un file PPTX
using (Presentation pres = new Presentation())
{

    // Accede alla prima diapositiva
    ISlide slide = pres.Slides[0];
    
    // Aggiunge e accede all'Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al frame di testo dell'autoshape creato
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
    // Imposta il livello del bullet
    para1.ParagraphFormat.Depth = 0;

    // Aggiunge il secondo paragrafo
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Imposta il livello del bullet
    para2.ParagraphFormat.Depth = 1;

    // Aggiunge il terzo paragrafo
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Imposta il livello del bullet
    para3.ParagraphFormat.Depth = 2;

    // Aggiunge il quarto paragrafo
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Imposta il livello del bullet
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

## **Gestire un paragrafo con un elenco numerato personalizzato**

L'interfaccia [IBulletFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/) fornisce la proprietà [NumberedBulletStartWith](https://reference.aspose.com/slides/it/net/aspose.slides/ibulletformat/numberedbulletstartwith) e altre che consentono di gestire paragrafi con numerazione o formattazione personalizzate. 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Accedi alla diapositiva contenente il paragrafo.
3. Aggiungi un [autoshape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) alla diapositiva.
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

	// Accede al frame di testo dell'autoshape creato
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

## **Impostare l'indentazione della prima riga per un paragrafo**

Utilizza la proprietà [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) per controllare l'indentazione della prima riga di un paragrafo. Questa proprietà sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga a destra, mentre le righe rimanenti rimangono allineate al corpo del paragrafo.

Usa [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/marginleft/) quando è necessario spostare l'intero paragrafo. Usa [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) quando è necessario spostare solo la prima riga.

L'esempio seguente crea diversi paragrafi e applica valori diversi di `Indent` per dimostrare come l'indentazione della prima riga influisca sul layout del paragrafo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
2. Accedi alla diapositiva di destinazione.
3. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Aggiungi un [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/) vuoto alla forma e rimuovi il paragrafo predefinito.
5. Crea diversi paragrafi e imposta valori diversi di [Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) per ciascuno.
6. Aggiungi i paragrafi al text frame.
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

![L'indentazione della prima riga dei paragrafi](first_line_indent.png)

## **Impostare l'indentazione sporgente per un paragrafo**

L'indentazione sporgente è un layout di paragrafo in cui la prima riga inizia a sinistra delle linee rimanenti. In Aspose.Slides, crei questo effetto con la proprietà [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/). Imposta `Indent` a un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

In pratica, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/marginleft/) definisce la posizione sinistra del corpo del paragrafo, e [IParagraphFormat.Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) definisce la posizione della prima riga rispetto a quel margine. Per creare un'indentazione sporgente, imposta un valore positivo per `MarginLeft` e un valore negativo per `Indent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le righe a capo devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima riga.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
2. Accedi alla diapositiva di destinazione.
3. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Aggiungi un [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/) vuoto alla forma e rimuovi il paragrafo predefinito.
5. Crea paragrafi e imposta un valore positivo di [MarginLeft](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/marginleft/) per ciascun paragrafo.
6. Imposta un valore negativo di [Indent](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraphformat/indent/) per creare l'effetto di indentazione sporgente.
7. Aggiungi i paragrafi al text frame.
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

![L'indentazione sporgente dei paragrafi](hanging_indent.png)

## **Gestire le proprietà End del paragrafo**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
2. Ottieni il riferimento per la diapositiva contenente il paragrafo tramite la sua posizione.
3. Aggiungi un rettangolo [autoshape](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/) alla diapositiva.
4. Aggiungi un [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/) con due paragrafi al rettangolo.
5. Imposta `FontHeight` e il tipo di Font per i paragrafi.
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

## **Importare testo HTML nei paragrafi**

Aspose.Slides fornisce un supporto avanzato per l'importazione di testo HTML nei paragrafi.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi un [autoshape](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/) alla diapositiva.
4. Aggiungi e accedi al [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) dell'`autoshape`.
5. Rimuovi il paragrafo predefinito nel `ITextFrame`.
6. Leggi il file HTML sorgente con un TextReader.
7. Crea la prima istanza di paragrafo tramite la classe [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph/).
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

    // Aggiunge un frame di testo alla forma
    ashape.AddTextFrame("");

    // Cancella tutti i paragrafi nel frame di testo aggiunto
    ashape.TextFrame.Paragraphs.Clear();

    // Carica il file HTML usando lo stream reader
    TextReader tr = new StreamReader("file.html");

    // Aggiunge il testo dallo stream reader HTML nel frame di testo
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Salva la presentazione
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Esportare il testo del paragrafo in HTML**

Aspose.Slides fornisce un supporto avanzato per esportare i testi (contenuti nei paragrafi) in HTML.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) e carica la presentazione desiderata.
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Accedi alla forma contenente il testo da esportare in HTML.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/) della forma.
5. Crea un'istanza di `StreamWriter` e aggiungi il nuovo file HTML.
6. Fornisci un indice di partenza a StreamWriter ed esporta i paragrafi preferiti.

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

    // Scrive i dati dei paragrafi in HTML specificando l'indice di partenza del paragrafo e il numero di paragrafi da copiare
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Salvare un paragrafo come immagine**

In questa sezione, esploreremo due esempi che mostrano come salvare un paragrafo di testo, rappresentato dall'interfaccia [IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/), come immagine. Entrambi gli esempi includono l'ottenimento dell'immagine di una forma contenente il paragrafo tramite i metodi `GetImage` dell'interfaccia [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/), il calcolo dei limiti del paragrafo all'interno della forma e l'esportazione come immagine bitmap. Questi approcci consentono di estrarre parti specifiche del testo da presentazioni PowerPoint e salvarle come immagini separate, utili per vari scenari.

Supponiamo di avere un file di presentazione chiamato sample.pptx con una diapositiva, dove la prima forma è una casella di testo contenente tre paragrafi.

![La casella di testo con tre paragrafi](paragraph_to_image_input.png)

**Esempio 1**

In questo esempio, otteniamo il secondo paragrafo come immagine. Per farlo, estraiamo l'immagine della forma dalla prima diapositiva della presentazione e quindi calcoliamo i limiti del secondo paragrafo nel text frame della forma. Il paragrafo viene poi ridisegnato su una nuova immagine bitmap, salvata in formato PNG. Questo metodo è particolarmente utile quando è necessario salvare un paragrafo specifico come immagine separata mantenendo le dimensioni e la formattazione esatte del testo.

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

![L'immagine del paragrafo](paragraph_to_image_output.png)

**Esempio 2**

In questo esempio, estendiamo l'approccio precedente aggiungendo fattori di scala all'immagine del paragrafo. La forma viene estratta dalla presentazione e salvata come immagine con un fattore di scala pari a `2`. Ciò consente di ottenere un'uscita a risoluzione più alta durante l'esportazione del paragrafo. I limiti del paragrafo sono quindi calcolati tenendo conto della scala. La scalatura può risultare particolarmente utile quando è necessaria un'immagine più dettagliata, ad esempio per materiale stampato di alta qualità.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Salva la forma in memoria come bitmap con scaling.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Crea un bitmap della forma dalla memoria.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calcola i confini del secondo paragrafo.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Calcola la dimensione per l'immagine di output (dimensione minima - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepara un bitmap per il paragrafo.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Ridisegna il paragrafo dal bitmap della forma al bitmap del paragrafo.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **FAQ**

**Posso disabilitare completamente l'andare a capo automatico all'interno di un riquadro di testo?**

Sì. Usa l'impostazione di avvolgimento del riquadro di testo ([WrapText](https://reference.aspose.com/slides/it/net/aspose.slides/textframeformat/wraptext/)) per disattivare l'andare a capo in modo che le linee non si interrompano ai bordi del riquadro.

**Come posso ottenere le coordinate esatte sullo slide di un paragrafo specifico?**

Puoi recuperare il rettangolo di delimitazione del paragrafo (e anche di una singola porzione) per conoscere la sua posizione e dimensione precise sullo slide.

**Dove è controllato l'allineamento del paragrafo (sinistra/destra/centrato/giustificato)?**

[Alignment](https://reference.aspose.com/slides/it/net/aspose.slides/paragraphformat/alignment/) è un'impostazione a livello di paragrafo in [ParagraphFormat](https://reference.aspose.com/slides/it/net/aspose.slides/paragraphformat/); si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

**Posso impostare una lingua di correzione ortografica per solo una parte di un paragrafo (ad esempio, una parola)?**

Sì. La lingua è impostata a livello di porzione ([PortionFormat.LanguageId](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/languageid/)), quindi più lingue possono coesistere all'interno di un singolo paragrafo.