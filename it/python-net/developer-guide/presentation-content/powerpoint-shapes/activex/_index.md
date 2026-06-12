---
title: Gestire i controlli ActiveX nelle presentazioni con Python
linktitle: ActiveX
type: docs
weight: 80
url: /it/python-net/activex/
keywords:
- ActiveX
- controllo ActiveX
- gestire ActiveX
- aggiungere ActiveX
- modificare ActiveX
- lettore multimediale
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come Aspose.Slides for Python via .NET sfrutta ActiveX per automatizzare e migliorare le presentazioni PowerPoint, offrendo agli sviluppatori un controllo potente sulle diapositive."
---
## **Introduzione**

I controlli ActiveX sono usati nelle presentazioni. Aspose.Slides for Python via .NET ti consente di gestire i controlli ActiveX, ma gestirli è un po' più complicato e diverso dai normali oggetti forma delle presentazioni. Dalla versione Aspose.Slides for Python via .NET 6.9.0, il componente supporta la gestione dei controlli ActiveX. Al momento, puoi accedere a un controllo ActiveX già aggiunto nella tua presentazione e modificarlo o eliminarlo utilizzando le sue varie proprietà. Ricorda, i controlli ActiveX non sono forme e non fanno parte della IShapeCollection della presentazione, ma della IControlCollection separata. Questo articolo mostra come lavorare con essi.

## **Modifica i controlli ActiveX**
Per gestire un semplice controllo ActiveX come una casella di testo e un pulsante di comando su una diapositiva:

1. Crea un'istanza della classe Presentation e carica la presentazione contenente i controlli ActiveX.
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Accedi ai controlli ActiveX nella diapositiva accedendo a IControlCollection.
4. Accedi al controllo ActiveX TextBox1 utilizzando l'oggetto ControlEx.
5. Modifica le diverse proprietà del controllo ActiveX TextBox1, comprese testo, carattere, altezza del carattere e posizione del frame.
6. Accedi al secondo controllo chiamato CommandButton1.
7. Modifica la didascalia del pulsante, il carattere e la posizione.
8. Sposta la posizione dei frame dei controlli ActiveX.
9. Scrivi la presentazione modificata in un file PPTX.

Il frammento di codice seguente aggiorna i controlli ActiveX nelle diapositive della presentazione come mostrato di seguito.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Accesso alla presentazione con controlli ActiveX
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Accesso alla prima diapositiva nella presentazione
    slide = presentation.slides[0]

    # modifica del testo della TextBox
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # modifica dell'immagine sostitutiva. PowerPoint sostituirà quest'immagine durante l'attivazione ActiveX, quindi a volte è accettabile lasciare l'immagine invariata.

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # modifica della didascalia del pulsante
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # modifica della sostituzione
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # Spostamento dei frame ActiveX di 100 punti verso il basso
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # Salva la presentazione con i controlli ActiveX modificati
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Ora rimuovendo i controlli
    slide.controls.clear()

    # Salvataggio della presentazione con i controlli ActiveX cancellati
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```

## **Aggiungi il controllo ActiveX Media Player**
Per aggiungere il controllo ActiveX Media Player, segui i seguenti passaggi:

1. Crea un'istanza della classe Presentation e carica la presentazione di esempio contenente i controlli ActiveX Media Player.
2. Crea un'istanza della classe Presentation di destinazione e genera un'istanza di presentazione vuota.
3. Clona la diapositiva con il controllo ActiveX Media Player dalla presentazione modello nella presentazione di destinazione.
4. Accedi alla diapositiva clonata nella presentazione di destinazione.
5. Accedi ai controlli ActiveX nella diapositiva accedendo a IControlCollection.
6. Accedi al controllo ActiveX Media Player e imposta il percorso del video utilizzando le sue proprietà.
7. Salva la presentazione in un file PPTX.

```py
import aspose.slides as slides

# Instanzia la classe Presentation che rappresenta il file PPTX
with slides.Presentation(path + "template.pptx") as presentation:

    # Crea un'istanza di presentazione vuota
    with slides.Presentation() as newPresentation:

        # Rimuovi la diapositiva predefinita
        newPresentation.slides.remove_at(0)

        # Clona la diapositiva con il controllo Media Player ActiveX
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Accedi al controllo Media Player ActiveX e imposta il percorso del video
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Salva la presentazione
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides conserva i controlli ActiveX durante la lettura e il salvataggio se non possono essere eseguiti nell'ambiente Python?**

Sì. Aspose.Slides li tratta come parte della presentazione e può leggere/modificare le loro proprietà e i frame; non è necessario eseguire i controlli stessi per conservarli.

**In che modo i controlli ActiveX differiscono dagli oggetti OLE in una presentazione?**

I controlli ActiveX sono controlli interattivi gestiti (pulsanti, caselle di testo, lettore multimediale), mentre [OLE](/slides/it/python-net/manage-ole/) si riferisce a oggetti applicativi incorporati (ad esempio, un foglio di lavoro Excel). Sono archiviati e gestiti in modo diverso e hanno modelli di proprietà differenti.

**Gli eventi ActiveX e le macro VBA funzionano se il file è stato modificato da Aspose.Slides?**

Aspose.Slides conserva il markup e i metadati esistenti; tuttavia, eventi e macro vengono eseguiti solo all'interno di PowerPoint su Windows quando la sicurezza lo consente. La libreria non esegue VBA.