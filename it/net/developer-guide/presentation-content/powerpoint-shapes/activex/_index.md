---
title: Gestire i controlli ActiveX nelle presentazioni in .NET
linktitle: ActiveX
type: docs
weight: 80
url: /it/net/activex/
keywords:
- ActiveX
- controllo ActiveX
- gestire ActiveX
- aggiungere ActiveX
- modificare ActiveX
- lettore multimediale
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come Aspose.Slides per .NET utilizza ActiveX per automatizzare e migliorare le presentazioni PowerPoint, offrendo agli sviluppatori un controllo potente sulle diapositive."
---
## **Introduzione**

I controlli ActiveX sono utilizzati nelle presentazioni. Aspose.Slides per .NET consente di gestire i controlli ActiveX, ma la loro gestione è un po' più complessa e differente dalle forme normali delle presentazioni. Dalla versione Aspose.Slides per .NET 6.9.0, il componente supporta la gestione dei controlli ActiveX. Al momento è possibile accedere a un controllo ActiveX già aggiunto nella presentazione e modificarlo o eliminarlo utilizzando le sue varie proprietà. Ricorda, i controlli ActiveX non sono forme e non fanno parte della IShapeCollection della presentazione, ma della IControlCollection separata. Questo articolo mostra come lavorare con essi.
## **Modifica dei controlli ActiveX**
Per gestire un semplice controllo ActiveX come una casella di testo e un pulsante di comando su una diapositiva:

1. Crea un'istanza della classe Presentation e carica la presentazione contenente i controlli ActiveX.
1. Ottieni un riferimento alla diapositiva mediante il suo indice.
1. Accedi ai controlli ActiveX nella diapositiva mediante la IControlCollection.
1. Accedi al controllo ActiveX TextBox1 usando l'oggetto ControlEx.
1. Modifica le varie proprietà del controllo ActiveX TextBox1, inclusi testo, carattere, altezza del carattere e posizione del frame.
1. Accedi al secondo controllo, chiamato CommandButton1.
1. Modifica la didascalia del pulsante, il carattere e la posizione.
1. Sposta la posizione dei frame dei controlli ActiveX.
1. Scrivi la presentazione modificata in un file PPTX.

Il frammento di codice seguente aggiorna i controlli ActiveX nelle diapositive della presentazione come mostrato di seguito.

```c#
// Accesso alla presentazione con controlli ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// Accesso alla prima diapositiva nella presentazione
ISlide slide = presentation.Slides[0];

// modifica del testo della TextBox
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // modifica dell'immagine sostitutiva. PowerPoint sostituirà quest'immagine durante l'attivazione di ActiveX, quindi a volte è accettabile lasciare l'immagine invariata.

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// modifica della didascalia del pulsante
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // modifica del sostituto
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// Spostamento dei frame ActiveX di 100 punti verso il basso
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Salva la presentazione con i controlli ActiveX modificati
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Ora rimuovendo i controlli
slide.Controls.Clear();

// Salvataggio della presentazione con i controlli ActiveX cancellati
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```

## **Aggiungi un controllo ActiveX Media Player**
Per aggiungere un controllo ActiveX Media Player, esegui i seguenti passaggi:

1. Crea un'istanza della classe Presentation e carica la presentazione di esempio contenente i controlli ActiveX Media Player.
1. Crea un'istanza della classe Presentation di destinazione e genera un'istanza di presentazione vuota.
1. Clona la diapositiva con il controllo ActiveX Media Player dalla presentazione modello nella presentazione di destinazione.
1. Accedi alla diapositiva clonata nella presentazione di destinazione.
1. Accedi ai controlli ActiveX nella diapositiva mediante la IControlCollection.
1. Accedi al controllo ActiveX Media Player e imposta il percorso del video usando le sue proprietà.
1. Salva la presentazione in un file PPTX.

```c#
// Istanzia la classe Presentation che rappresenta il file PPTX
Presentation presentation = new Presentation("template.pptx");

// Crea un'istanza vuota di presentazione
Presentation newPresentation = new Presentation();

// Rimuovi la diapositiva predefinita
newPresentation.Slides.RemoveAt(0);

// Clona la diapositiva con il controllo Media Player ActiveX
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Accedi al controllo Media Player ActiveX e imposta il percorso del video
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Salva la presentazione
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Aspose.Slides conserva i controlli ActiveX durante la lettura e il salvataggio se non possono essere eseguiti nel runtime .NET?**

Sì. Aspose.Slides li considera parte della presentazione e può leggere/modificare le loro proprietà e i loro frame; l'esecuzione dei controlli stessi non è necessaria per conservarli.

**In che modo i controlli ActiveX differiscono dagli oggetti OLE in una presentazione?**

I controlli ActiveX sono controlli interattivi gestiti (pulsanti, caselle di testo, lettore multimediale), mentre [OLE](/slides/it/net/manage-ole/) si riferisce a oggetti applicativi incorporati (ad esempio, un foglio di lavoro Excel). Sono memorizzati e gestiti diversamente e possiedono modelli di proprietà differenti.

**Gli eventi ActiveX e le macro VBA funzionano se il file è stato modificato da Aspose.Slides?**

Aspose.Slides conserva il markup e i metadati esistenti; tuttavia, eventi e macro vengono eseguiti solo all'interno di PowerPoint su Windows quando la sicurezza lo consente. La libreria non esegue VBA.