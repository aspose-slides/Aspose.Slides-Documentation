---
title: Gestire i controlli ActiveX nelle presentazioni su Android
linktitle: ActiveX
type: docs
weight: 80
url: /it/androidjava/activex/
keywords:
- ActiveX
- controllo ActiveX
- gestire ActiveX
- aggiungere ActiveX
- modificare ActiveX
- lettore multimediale
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Impara come Aspose.Slides per Android tramite Java utilizza ActiveX per automatizzare e migliorare le presentazioni PowerPoint, offrendo agli sviluppatori un controllo potente sulle diapositive."
---
## **Introduzione**

I controlli ActiveX sono usati nelle presentazioni. Aspose.Slides per Android via Java consente di aggiungere e gestire i controlli ActiveX, ma sono un po' più difficili da gestire rispetto alle forme normali della presentazione. Abbiamo implementato il supporto per aggiungere il controllo Active Media Player in Aspose.Slides. Nota che i controlli ActiveX non sono forme; non fanno parte della presentazione's [IShapeCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/). Fanno parte invece della separata [IControlCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icontrolcollection/) . In questo argomento, mostreremo come lavorare con essi.

## **Aggiungere un controllo ActiveX Media Player a una diapositiva**
Per aggiungere un controllo ActiveX Media Player, procedi così:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) e genera un'istanza vuota della presentazione.  
1. Accedi alla diapositiva di destinazione nella [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).  
1. Aggiungi il controllo ActiveX Media Player usando il metodo [addControl](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) esposto da [IControlCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icontrolcollection/).  
1. Accedi al controllo ActiveX Media Player e imposta il percorso del video utilizzando le sue proprietà.  
1. Salva la presentazione come file PPTX.  

Questo esempio di codice, basato sui passaggi precedenti, mostra come aggiungere un controllo ActiveX Media Player a una diapositiva:

```java
// Crea un'istanza vuota della presentazione
Presentation pres = new Presentation();
try {
    // Aggiunta del controllo ActiveX Media Player
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Accedi al controllo ActiveX Media Player e imposta il percorso del video
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Salva la presentazione
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modificare un controllo ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides per Android via Java 7.1.0 e versioni successive sono dotati di componenti per la gestione dei controlli ActiveX. È possibile accedere al controllo ActiveX già aggiunto nella presentazione e modificarlo o eliminarlo tramite le sue proprietà.  

{{% /alert %}} 

Per gestire un semplice controllo ActiveX come una casella di testo e un pulsante di comando su una diapositiva, procedi così:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) e carica la presentazione con i controlli ActiveX al suo interno.  
1. Ottieni un riferimento alla diapositiva per indice.  
1. Accedi ai controlli ActiveX nella diapositiva accedendo alla [IControlCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icontrolcollection/).  
1. Accedi al controllo ActiveX TextBox1 usando l'oggetto [IControl](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icontrol/) .  
1. Modifica le proprietà del controllo ActiveX TextBox1, che includono testo, font, altezza del font e posizione del frame.  
1. Accedi al secondo controllo di accesso chiamato CommandButton1.  
1. Modifica la didascalia del pulsante, il font e la posizione.  
1. Sposta la posizione dei frame dei controlli ActiveX.  
1. Scrivi la presentazione modificata in un file PPTX.  

Questo esempio di codice, basato sui passaggi precedenti, mostra come gestire un semplice controllo ActiveX: 

```java
// Accesso alla presentazione con controlli ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Accesso alla prima diapositiva nella presentazione
    ISlide slide = pres.getSlides().get_Item(0);

    // modifica del testo della TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Modifica dell'immagine sostitutiva. PowerPoint sostituirà questa immagine durante l'attivazione di ActiveX,
        // quindi a volte è accettabile lasciare l'immagine invariata.
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // Modifica della didascalia del pulsante
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Modifica della sostituzione
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);
        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
                graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
                graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

                graphics.dispose();

                ByteArrayOutputStream baos = new ByteArrayOutputStream();
                ImageIO.write(image, "PNG", baos);

                control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
            }

            // spostamento di 100 punti verso il basso
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // rimozione dei controlli
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **FAQ**

**Aspose.Slides conserva i controlli ActiveX quando si legge e si salva nuovamente se non possono essere eseguiti nell'ambiente Java?**

Sì. Aspose.Slides li tratta come parte della presentazione e può leggere/modificare le loro proprietà e i loro frame; non è necessario eseguire i controlli stessi per conservarli.

**In che modo i controlli ActiveX differiscono dagli oggetti OLE in una presentazione?**

I controlli ActiveX sono controlli gestiti interattivi (pulsanti, caselle di testo, media player), mentre [OLE](/slides/it/androidjava/manage-ole/) si riferisce a oggetti applicativi incorporati (ad esempio, un foglio di lavoro Excel). Sono memorizzati e gestiti diversamente e hanno modelli di proprietà differenti.

**Gli eventi ActiveX e le macro VBA funzionano se il file è stato modificato da Aspose.Slides?**

Aspose.Slides conserva il markup e i metadati esistenti; tuttavia, eventi e macro vengono eseguiti solo all'interno di PowerPoint su Windows quando la sicurezza lo consente. La libreria non esegue VBA.