---
title: Gestire i controlli ActiveX nelle presentazioni con Python
linktitle: ActiveX
type: docs
weight: 80
url: /it/python-net/activex/
keywords:
- ActiveX
- Controllo ActiveX
- gestire ActiveX
- aggiungere ActiveX
- modificare ActiveX
- lettore multimediale
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Modifica caselle di testo e pulsanti ActiveX, aggiorna le anteprime dei controlli e riutilizza un controllo Windows Media Player nelle presentazioni PowerPoint con Aspose.Slides per Python via .NET."
---
## **Introduzione**

I controlli ActiveX forniscono a una diapositiva PowerPoint elementi interattivi come caselle di testo, pulsanti di comando e lettori multimediali. Aspose.Slides per Python via .NET espone i controlli di una diapositiva tramite [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/). Utilizza questa raccolta per modificare un controllo, spostarlo sulla diapositiva o rimuoverlo.

## **Elenca i controlli ActiveX e le loro proprietà memorizzate**

Per esaminare un modello non familiare, aprilo in lettura e itera sui controlli di ciascuna diapositiva. L'esempio riporta il numero della diapositiva, il nome del controllo, [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/), e ogni coppia chiave-valore in [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties). Legge la presentazione senza attivare i controlli, invocare eventi o macro, modificare valori o salvare il file.

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
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

Una raccolta di proprietà vuota appare come `[]`. Per i controlli che utilizzano memorizzazione binaria, `properties` può restituire `None`, visualizzato come `Properties unavailable`. Se ti servono solo i nomi, utilizza [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) dopo aver verificato `None`. Il report elenca le proprietà disponibili nella presentazione. Un controllo può supportare proprietà aggiuntive a runtime.

## **Modifica i controlli ActiveX**

L'esempio richiede una presentazione con macro abilitata contenente una casella di testo denominata `TextBox1` e un pulsante di comando denominato `CommandButton1` nella prima diapositiva. Utilizza la [control properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) per modificare il valore della casella di testo e la didascalia del pulsante. Ogni controllo dispone anche di un'anteprima statica che PowerPoint può mostrare prima dell'attivazione. Fornisci un PNG per ogni controllo che mostri il testo e l'aspetto aggiornati. L'esempio assegna queste immagini tramite [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/).

L'esempio sposta ogni controllo della prima diapositiva verso il basso di 100 punti modificando il suo [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/). Salva la presentazione modificata in formato PPTM, quindi utilizza [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) per salvare una seconda copia con tutti i controlli ActiveX rimossi da quella diapositiva.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **Aggiungi un controllo Media Player ActiveX**

Per riutilizzare un controllo Windows Media Player configurato, parti da un modello la cui prima diapositiva contiene un lettore denominato `WindowsMediaPlayer1`. [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) copia l'intera diapositiva in una nuova presentazione. L'esempio imposta l'`URL` del lettore nella sua [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) e salva la diapositiva clonata come unica diapositiva nell'output. Il video rimane esterno, quindi scegli un percorso che il lettore possa accedere durante la riproduzione.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides può conservare i controlli ActiveX senza eseguirli?**

Sì. Aspose.Slides può leggere e salvare i controlli, incluse le loro proprietà e posizioni, senza attivarli.

**In che modo i controlli ActiveX differiscono dagli oggetti OLE?**

I controlli ActiveX consentono agli utenti di interagire con una diapositiva, ad esempio inserendo testo o facendo clic su un pulsante. Un [OLE object](/slides/it/python-net/manage-ole/) permette a una diapositiva di contenere o collegare contenuti gestiti da un'altra applicazione, come un foglio di lavoro Excel.

**Gli eventi ActiveX attiveranno ancora le macro VBA dopo aver salvato una presentazione con Aspose.Slides?**

Salva la presentazione in un formato abilitato alle macro, ad esempio PPTM, per conservare il progetto VBA. PowerPoint per Windows può eseguire i gestori di eventi esistenti quando le impostazioni di sicurezza consentono sia i controlli ActiveX sia le macro.