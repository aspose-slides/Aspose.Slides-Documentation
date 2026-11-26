---
title: Gestisci i controlli ActiveX nelle presentazioni utilizzando Python
linktitle: ActiveX
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
description: "Modifica caselle di testo e pulsanti ActiveX, aggiorna le anteprime dei controlli e riutilizza un controllo Windows Media Player nelle presentazioni PowerPoint con Aspose.Slides per Python via Java."
---
## **Introduzione**

I controlli ActiveX forniscono a una diapositiva PowerPoint elementi interattivi come caselle di testo, pulsanti di comando e lettori multimediali. Aspose.Slides per Python tramite Java espone i controlli di una diapositiva tramite [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls). Usa questa collezione per modificare un controllo, spostarlo nella diapositiva o rimuoverlo.

## **Elenca i controlli ActiveX e le loro proprietà memorizzate**

Per esaminare un modello sconosciuto, aprilo in modalità lettura e itera sui controlli di ogni diapositiva. L’esempio riporta il numero della diapositiva, il nome del controllo, [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId) e ogni coppia chiave‑valore in [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties). Legge la presentazione senza attivare i controlli, invocare eventi o macro, modificare valori o salvare il file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
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

Una collezione di proprietà vuota appare come `[]`. Per i controlli che usano archiviazione binaria, [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) può restituire `None`, mostrato come `Properties unavailable`. Se ti servono solo i nomi, utilizza [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) dopo aver verificato che la collezione sia disponibile. Il report elenca le proprietà disponibili dalla presentazione. Un controllo può supportare proprietà aggiuntive a runtime.

## **Modifica i controlli ActiveX**

L’esempio prevede una presentazione abilitata alle macro con una casella di testo denominata `TextBox1` e un pulsante di comando denominato `CommandButton1` nella prima diapositiva. Utilizza la [control properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) per cambiare il valore della casella di testo e la didascalia del pulsante. Ogni controllo ha anche un’anteprima statica che PowerPoint può visualizzare prima dell’attivazione. Fornisci un PNG per ciascun controllo che mostri il testo e l’aspetto aggiornati. L’esempio assegna queste immagini tramite [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat).

L’esempio sposta tutti i controlli della prima diapositiva verso il basso di 100 punti impostando il loro riquadro con [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame). Salva la presentazione modificata in formato PPTM, poi utilizza [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) per salvare una seconda copia con tutti i controlli ActiveX rimossi da quella diapositiva.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **Aggiungi un controllo ActiveX Media Player**

Per riutilizzare un controllo Windows Media Player configurato, inizia con un modello la cui prima diapositiva contiene un player denominato `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) copia l’intera diapositiva in una nuova presentazione. L’esempio imposta l’`URL` del player nella sua [properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) e salva la diapositiva clonata come unica diapositiva nell’output. Il video rimane esterno, quindi scegli un percorso accessibile al player durante la riproduzione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **FAQ**

**Può Aspose.Slides preservare i controlli ActiveX senza eseguirli?**

Sì. Aspose.Slides può leggere e salvare i controlli, incluse le loro proprietà e posizioni, senza attivarli.

**In che modo i controlli ActiveX differiscono dagli oggetti OLE?**

I controlli ActiveX consentono agli utenti di interagire con una diapositiva, ad esempio inserendo testo o facendo clic su un pulsante. Un [oggetto OLE](/slides/it/python-java/manage-ole/) consente a una diapositiva di contenere o collegare contenuti gestiti da un’altra applicazione, come un foglio di calcolo Excel.

**Gli eventi ActiveX attiveranno ancora le macro VBA dopo aver salvato una presentazione con Aspose.Slides?**

Salva la presentazione in un formato abilitato alle macro, ad esempio PPTM, per mantenere il progetto VBA. PowerPoint per Windows può eseguire i gestori di eventi esistenti quando le impostazioni di sicurezza consentono sia i controlli ActiveX sia le macro.