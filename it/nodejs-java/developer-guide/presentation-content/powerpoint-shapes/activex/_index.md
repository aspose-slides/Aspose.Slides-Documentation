---
title: Gestire i controlli ActiveX nelle presentazioni usando JavaScript
linktitle: ActiveX
type: docs
weight: 80
url: /it/nodejs-java/activex/
keywords:
- ActiveX
- controllo ActiveX
- gestire ActiveX
- aggiungere ActiveX
- modificare ActiveX
- lettore multimediale
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come Aspose.Slides per Node.js via Java sfrutta ActiveX per automatizzare e migliorare le presentazioni PowerPoint, offrendo agli sviluppatori un controllo potente sulle slide."
---
## **Introduzione**

I controlli ActiveX sono utilizzati nelle presentazioni. Aspose.Slides per Node.js via Java consente di aggiungere e gestire i controlli ActiveX, ma sono un po' più complessi da gestire rispetto alle normali forme della presentazione. Abbiamo implementato il supporto per aggiungere il controllo Active di Media Player in Aspose.Slides. Nota che i controlli ActiveX non sono forme; non fanno parte della presentazione's [ShapeCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/). Sono invece parte della separata [ControlCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/controlcollection/) . In questo argomento, ti mostreremo come lavorare con essi.

## **Aggiunta del controllo ActiveX Media Player alla diapositiva**
Per aggiungere un controllo ActiveX Media Player, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) e genera un'istanza di presentazione vuota.  
2. Accedi alla diapositiva di destinazione nella [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).  
3. Aggiungi il controllo ActiveX Media Player utilizzando il metodo [addControl](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) esposto da [ControlCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/controlcollection/).  
4. Accedi al controllo ActiveX Media Player e imposta il percorso del video utilizzando le sue proprietà.  
5. Salva la presentazione come file PPTX.

Questo esempio di codice, basato sui passaggi precedenti, mostra come aggiungere il controllo ActiveX Media Player a una diapositiva:

```javascript
// Crea un'istanza di presentazione vuota
var pres = new aspose.slides.Presentation();
try {
    // Aggiunta del controllo ActiveX Media Player
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // Accedi al controllo ActiveX Media Player e imposta il percorso del video
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // Salva la presentazione
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modifica del controllo ActiveX**

Per gestire un semplice controllo ActiveX come una casella di testo e un pulsante di comando semplice su una diapositiva, procedi così:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) e carica la presentazione contenente i controlli ActiveX in essa.  
2. Ottieni un riferimento alla diapositiva tramite il suo indice.  
3. Accedi ai controlli ActiveX nella diapositiva accedendo alla [ControlCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/controlcollection/).  
4. Accedi al controllo ActiveX TextBox1 utilizzando l'oggetto [Control](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/control/).  
5. Modifica le proprietà del controllo ActiveX TextBox1, inclusi testo, font, altezza del font e posizione del frame.  
6. Accedi al secondo controllo di accesso chiamato CommandButton1.  
7. Modifica la didascalia del pulsante, il font e la posizione.  
8. Sposta la posizione dei frame dei controlli ActiveX.  
9. Scrivi la presentazione modificata in un file PPTX.

Questo esempio di codice, basato sui passaggi precedenti, mostra come gestire un semplice controllo ActiveX: 

```javascript
const imageio = java.import("javax.imageio.ImageIO");
// Accesso alla presentazione con controlli ActiveX
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // Accesso alla prima diapositiva nella presentazione
    var slide = pres.getSlides().get_Item(0);
    // Modifica del testo della casella di testo
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // Modifica dell'immagine sostitutiva. PowerPoint sostituirà questa immagine durante l'attivazione di ActiveX,
        // quindi a volte va bene lasciare l'immagine invariata.
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // Modifica della didascalia del pulsante
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Modifica dell'immagine sostitutiva
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // Spostamento di 100 punti verso il basso
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // Rimozione dei controlli
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Aspose.Slides conserva i controlli ActiveX durante la lettura e il salvataggio se non possono essere eseguiti nell'ambiente di runtime Python?**  
Sì. Aspose.Slides li tratta come parte della presentazione e può leggere/modificarne le proprietà e i frame; l'esecuzione dei controlli stessi non è necessaria per conservarli.

**In che modo i controlli ActiveX differiscono dagli oggetti OLE in una presentazione?**  
I controlli ActiveX sono controlli interattivi gestiti (pulsanti, caselle di testo, lettore multimediale), mentre [OLE](/slides/it/nodejs-java/manage-ole/) si riferisce a oggetti applicativi incorporati (ad esempio, un foglio di lavoro Excel). Sono archiviati e gestiti in modo diverso e hanno modelli di proprietà differenti.

**Gli eventi ActiveX e le macro VBA funzionano se il file è stato modificato da Aspose.Slides?**  
Aspose.Slides conserva il markup e i metadati esistenti; tuttavia, gli eventi e le macro vengono eseguiti solo all'interno di PowerPoint su Windows quando la sicurezza lo consente. La libreria non esegue VBA.