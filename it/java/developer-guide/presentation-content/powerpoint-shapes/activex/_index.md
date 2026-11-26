---
title: Gestire i controlli ActiveX nelle presentazioni in Java
linktitle: ActiveX
type: docs
weight: 80
url: /it/java/activex/
keywords:
- ActiveX
- controllo ActiveX
- gestire ActiveX
- aggiungere ActiveX
- modificare ActiveX
- lettore multimediale
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Modifica caselle di testo e pulsanti ActiveX, aggiorna le anteprime dei controlli e riutilizza un controllo Windows Media Player nelle presentazioni PowerPoint con Aspose.Slides per Java."
---
## **Introduzione**

I controlli ActiveX forniscono a una diapositiva PowerPoint elementi interattivi come caselle di testo, pulsanti di comando e lettori multimediali. Aspose.Slides for Java espone i controlli di una diapositiva tramite [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--). Utilizza questa raccolta per modificare un controllo, spostarlo nella diapositiva o rimuoverlo.

## **Elenco dei controlli ActiveX e delle loro proprietà memorizzate**

Per ispezionare un modello sconosciuto, aprilo in modalità lettura e itera sui controlli di ogni diapositiva. L'esempio riporta il numero della diapositiva, il nome del controllo, [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--), e ogni coppia chiave‑valore in [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--). Legge la presentazione senza attivare i controlli, invocare eventi o macro, modificare valori o salvare il file.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
```

L'output selezionato da `ActiveX.pptm` mostra una casella di testo e un pulsante di comando.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Una raccolta di proprietà vuota appare come `[]`. Per i controlli che utilizzano archiviazione binaria, [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) può restituire `null`, mostrato come `Properties unavailable`. Se ti servono solo i nomi, usa [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) dopo il controllo di null. Il report elenca le proprietà disponibili nella presentazione. Un controllo può supportare proprietà aggiuntive a runtime.

## **Modifica dei controlli ActiveX**

L'esempio richiede una presentazione abilitata alle macro con una casella di testo denominata `TextBox1` e un pulsante di comando denominato `CommandButton1` sulla prima diapositiva. Utilizza la [control properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) per modificare il valore della casella di testo e la didascalia del pulsante. Ogni controllo ha anche un'anteprima statica che PowerPoint può visualizzare prima dell'attivazione. Fornisci un PNG per ogni controllo che mostri il testo aggiornato e l'aspetto. L'esempio assegna queste immagini tramite [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

L'esempio sposta tutti i controlli sulla prima diapositiva verso il basso di 100 punti impostando il loro frame con [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). Salva la presentazione modificata in formato PPTM, quindi utilizza [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) per salvare una seconda copia con tutti i controlli ActiveX rimossi da quella diapositiva.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Aggiungere un controllo ActiveX Media Player**

Per riutilizzare un controllo Windows Media Player configurato, inizia con un modello la cui prima diapositiva contiene un lettore chiamato `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) copia l'intera diapositiva in una nuova presentazione. L'esempio imposta il `URL` del lettore nella sua [properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) e salva la diapositiva clonata come l'unica diapositiva nel risultato. Il video rimane esterno, quindi scegli un percorso accessibile dal lettore durante la riproduzione.

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");
        
        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```

## **FAQ**

**Può Aspose.Slides preservare i controlli ActiveX senza eseguirli?**

Sì. Aspose.Slides può leggere e salvare i controlli, incluse le loro proprietà e posizioni, senza attivarli.

**Come si differenziano i controlli ActiveX dagli oggetti OLE?**

I controlli ActiveX consentono agli utenti di interagire con una diapositiva, ad esempio inserendo testo o facendo clic su un pulsante. Un [OLE object](/slides/it/java/manage-ole/) permette a una diapositiva di contenere o collegare contenuti gestiti da un'altra applicazione, come un foglio di calcolo Excel.

**Gli eventi ActiveX attiveranno ancora le macro VBA dopo aver salvato una presentazione con Aspose.Slides?**

Salva la presentazione in un formato abilitato alle macro, ad esempio PPTM, per conservare il suo progetto VBA. PowerPoint per Windows può eseguire i gestori di eventi esistenti quando le impostazioni di sicurezza consentono sia i controlli ActiveX sia le macro.