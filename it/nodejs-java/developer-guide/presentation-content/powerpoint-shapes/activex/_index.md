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
description: "Modifica caselle di testo e pulsanti ActiveX, aggiorna le anteprime dei controlli e riutilizza un controllo Windows Media Player nelle presentazioni PowerPoint con Aspose.Slides per Node.js via Java."
---
## **Introduzione**

I controlli ActiveX forniscono a una diapositiva PowerPoint elementi interattivi come caselle di testo, pulsanti di comando e lettori multimediali. Aspose.Slides per Node.js via Java espone i controlli di una diapositiva tramite [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls). Usa questa collezione per modificare un controllo, spostarlo nella diapositiva o rimuoverlo.

## **Elenco dei controlli ActiveX e delle loro proprietà archiviate**

Per esaminare un modello sconosciuto, aprirlo in modalità lettura e iterare i controlli su ogni diapositiva. L'esempio riporta il numero della diapositiva, il nome del controllo, [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId), e ogni coppia chiave‑valore in [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties). Legge la presentazione senza attivare i controlli, invocare eventi o macro, modificare valori o salvare il file.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
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

Una collezione di proprietà vuota appare come `[]`. Per i controlli che utilizzano memorizzazione binaria, [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) può restituire `null`, visualizzato come `Properties unavailable`. Se ti servono solo i nomi, usa [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) dopo il controllo di null. Il rapporto elenca le proprietà disponibili dalla presentazione. Un controllo può supportare proprietà aggiuntive a runtime.

## **Modifica i controlli ActiveX**

L'esempio si aspetta una presentazione con macro abilitata contenente una casella di testo denominata `TextBox1` e un pulsante di comando denominato `CommandButton1` nella prima diapositiva. Utilizza la [collezione delle proprietà del controllo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) per modificare il valore della casella di testo e la didascalia del pulsante. Ogni controllo ha anche un'anteprima statica che PowerPoint può visualizzare prima dell'attivazione. Fornisci un PNG per ogni controllo che mostri il testo e l'aspetto aggiornati. L'esempio assegna queste immagini tramite [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat).

L'esempio sposta tutti i controlli nella prima diapositiva verso il basso di 100 punti impostando il loro riquadro con [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame). Salva la presentazione modificata in formato PPTM, poi utilizza [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) per salvare una seconda copia con tutti i controlli ActiveX rimossi da quella diapositiva.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```

## **Aggiungi un controllo ActiveX Media Player**

Per riutilizzare un controllo Windows Media Player configurato, inizia con un modello la cui prima diapositiva contiene un lettore denominato `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) copia l'intera diapositiva in una nuova presentazione. L'esempio imposta l'`URL` del lettore nella sua [collezione delle proprietà](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) e salva la diapositiva clonata come unica diapositiva nell'output. Il video rimane esterno, quindi scegli un percorso a cui il lettore può accedere durante la riproduzione.

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```

## **FAQ**

**Può Aspose.Slides preservare i controlli ActiveX senza eseguirli?**

Sì. Aspose.Slides può leggere e salvare i controlli, incluse le loro proprietà e posizioni, senza attivarli.

**In che modo i controlli ActiveX differiscono dagli oggetti OLE?**

I controlli ActiveX consentono agli utenti di interagire con una diapositiva, ad esempio inserendo testo o facendo clic su un pulsante. Un [oggetto OLE](/slides/it/nodejs-java/manage-ole/) consente a una diapositiva di contenere o collegare contenuti gestiti da un'altra applicazione, come un foglio di lavoro Excel.

**Gli eventi ActiveX attiveranno ancora le macro VBA dopo aver salvato una presentazione con Aspose.Slides?**

Salva la presentazione in un formato con macro abilitato, ad esempio PPTM, per mantenere il suo progetto VBA. PowerPoint per Windows può eseguire i gestori di eventi esistenti quando le impostazioni di sicurezza consentono sia controlli ActiveX sia macro.