---
title: "Gestire i controlli ActiveX nelle presentazioni usando Python"
linktitle: "ActiveX"
type: docs
weight: 80
url: /it/python-java/activex/
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
description: "Scopri come Aspose.Slides per Python tramite Java utilizza ActiveX per automatizzare e migliorare le presentazioni PowerPoint, offrendo agli sviluppatori un controllo potente sulle diapositive."
---
## **Introduzione**

I controlli ActiveX sono usati nelle presentazioni. Aspose.Slides per Python tramite Java consente di aggiungere e gestire i controlli ActiveX, ma sono un po' più difficili da gestire rispetto alle forme normali della presentazione. Aspose.Slides supporta l'aggiunta di controlli ActiveX Media Player. Nota che i controlli ActiveX non sono forme; non fanno parte della presentazione's[ShapeCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/). Fanno invece parte della separata[ControlCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/controlcollection/) invece. In questo argomento, ti mostreremo come lavorare con essi.

## **Aggiungere un controllo ActiveX Media Player a una diapositiva**

Per aggiungere un controllo ActiveX Media Player, esegui questi passaggi:

1. Crea un'istanza della classe[Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e genera un'istanza di presentazione vuota.  
2. Accedi alla diapositiva di destinazione nella[Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).  
3. Aggiungi il controllo ActiveX Media Player utilizzando il metodo[addControl](https://reference.aspose.com/slides/it/python-java/aspose.slides/controlcollection/#addControl) esposto da[ControlCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/controlcollection/).  
4. Accedi al controllo ActiveX Media Player e imposta il percorso video utilizzando le sue proprietà.  
5. Salva la presentazione come file PPTX.

Questo codice di esempio, basato sui passaggi precedenti, mostra come aggiungere un controllo ActiveX Media Player a una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# Crea una presentazione vuota.
presentation = Presentation()
try:
    # Aggiungi il controllo ActiveX Media Player.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # Imposta il percorso del video.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # Salva la presentazione.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modificare un controllo ActiveX**

{{% alert color="info" title="Note" %}}

Aspose.Slides per Python tramite Java fornisce componenti per la gestione dei controlli ActiveX. Puoi accedere al controllo ActiveX già aggiunto nella tua presentazione e modificarlo o eliminarlo tramite le sue proprietà.

{{% /alert %}}

Per gestire un semplice controllo ActiveX come una casella di testo e un semplice pulsante di comando su una diapositiva, esegui questi passaggi:

1. Crea un'istanza della classe[Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica la presentazione contenente controlli ActiveX.  
2. Ottieni un riferimento alla diapositiva tramite il suo indice.  
3. Accedi ai controlli ActiveX nella diapositiva accedendo al[ControlCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/controlcollection/).  
4. Accedi al controllo ActiveX TextBox1 utilizzando l'oggetto[Control](https://reference.aspose.com/slides/it/python-java/aspose.slides/control/).  
5. Modifica le proprietà del controllo ActiveX TextBox1, che includono testo, carattere, altezza del carattere e posizione del riquadro.  
6. Accedi al secondo controllo ActiveX chiamato CommandButton1.  
7. Modifica la didascalia del pulsante, il carattere e la posizione.  
8. Sposta la posizione dei riquadri dei controlli ActiveX.  
9. Scrivi la presentazione modificata in un file PPTM.

Questo codice di esempio, basato sui passaggi precedenti, mostra come gestire un semplice controllo ActiveX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# Carica la presentazione con i controlli ActiveX.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # Accedi alla prima diapositiva.
        slide = presentation.getSlides().get_Item(0)

        # Modifica il testo della casella di testo.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # Cambia l'immagine sostitutiva. PowerPoint la sostituisce durante l'attivazione di ActiveX,
            # quindi a volte può rimanere invariata.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

            graphics = image.getGraphics()
            graphics.setColor(SystemColor.window)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            graphics.drawString(new_text, 10, 20)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Modifica la didascalia del pulsante.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # Cambia l'immagine sostitutiva.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
            graphics = image.getGraphics()
            graphics.setColor(SystemColor.control)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            metrics = graphics.getFontMetrics(font)
            graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Sposta i controlli verso il basso di 100 punti.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # Rimuovi i controlli.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **FAQ**

**Aspose.Slides mantiene i controlli ActiveX durante la lettura e la risalvataggio se non possono essere eseguiti nel runtime Python?**

Sì. Aspose.Slides li tratta come parte della presentazione e può leggere/modificare le loro proprietà e i riquadri; l'esecuzione dei controlli stessi non è necessaria per conservarli.

**In che modo i controlli ActiveX differiscono dagli oggetti OLE in una presentazione?**

I controlli ActiveX sono controlli interattivi gestiti (pulsanti, caselle di testo, media player), mentre[OLE](/slides/it/python-java/manage-ole/) si riferisce a oggetti applicativi incorporati (ad esempio, un foglio di lavoro Excel). Sono memorizzati e gestiti in modo diverso e hanno modelli di proprietà differenti.

**Gli eventi ActiveX e le macro VBA funzionano se il file è stato modificato da Aspose.Slides?**

Aspose.Slides conserva il markup e i metadati esistenti; tuttavia, eventi e macro vengono eseguiti solo all'interno di PowerPoint su Windows quando la sicurezza lo consente. La libreria non esegue VBA.