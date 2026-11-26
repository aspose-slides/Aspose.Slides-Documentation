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
description: "Modifica caselle di testo e pulsanti ActiveX, aggiorna le anteprime dei controlli e riutilizza un controllo Windows Media Player nelle presentazioni PowerPoint con Aspose.Slides per .NET."
---
## **Introduzione**

I controlli ActiveX forniscono a una diapositiva PowerPoint elementi interattivi come caselle di testo, pulsanti comando e lettori multimediali. Aspose.Slides per .NET espone i controlli di una diapositiva tramite [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/). Usa questa collezione per modificare un controllo, spostarlo nella diapositiva o rimuoverlo.

## **Elenco dei controlli ActiveX e delle loro proprietà memorizzate**

Per esaminare un modello sconosciuto, aprilo in lettura e itera sui controlli di ogni diapositiva. L'esempio riporta il numero della diapositiva, il nome del controllo, [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/), e ogni coppia chiave‑valore in [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties). Legge la presentazione senza attivare i controlli, invocare eventi o macro, modificare valori o salvare il file.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
}
```

L'output selezionato da `ActiveX.pptm` mostra una casella di testo e un pulsante comando.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Una collezione di proprietà vuota appare come `[]`. Per i controlli che usano la memorizzazione binaria, `Properties` può restituire `null`, mostrato come `Properties unavailable`. Se hai bisogno solo dei nomi, usa [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) dopo il controllo di null. Il rapporto elenca le proprietà disponibili nella presentazione. Un controllo può supportare proprietà aggiuntive a runtime.

## **Modifica dei controlli ActiveX**

L'esempio richiede una presentazione abilitata alle macro con una casella di testo chiamata `TextBox1` e un pulsante comando chiamato `CommandButton1` sulla prima diapositiva. Utilizza la [collezione delle proprietà del controllo](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) per cambiare il valore della casella di testo e la didascalia del pulsante. Ogni controllo ha anche un'anteprima statica che PowerPoint può visualizzare prima dell'attivazione. Fornisci un PNG per ogni controllo che mostri il testo aggiornato e l'aspetto. L'esempio assegna queste immagini tramite [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/).

L'esempio sposta ogni controllo sulla prima diapositiva verso il basso di 100 punti modificando il suo [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/). Salva la presentazione modificata in formato PPTM, poi usa [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) per salvare una seconda copia con tutti i controlli ActiveX rimossi da quella diapositiva.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```

## **Aggiungi un controllo ActiveX Media Player**

Per riutilizzare un controllo Windows Media Player configurato, inizia con un modello la cui prima diapositiva contiene un lettore chiamato `WindowsMediaPlayer1`. [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) copia l'intera diapositiva in una nuova presentazione. L'esempio imposta l'`URL` del lettore nella sua [collezione delle proprietà](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) e salva la diapositiva clonata come unica diapositiva nell'output. Il video rimane esterno, quindi scegli un percorso a cui il lettore può accedere durante la riproduzione.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Aspose.Slides può preservare i controlli ActiveX senza eseguirli?**

Sì. Aspose.Slides può leggere e salvare i controlli, incluse le loro proprietà e posizioni, senza attivarli.

**In che modo i controlli ActiveX differiscono dagli oggetti OLE?**

I controlli ActiveX consentono agli utenti di interagire con una diapositiva, ad esempio inserendo testo o facendo clic su un pulsante. Un [oggetto OLE](/slides/it/net/manage-ole/) permette a una diapositiva di contenere o collegare contenuti gestiti da un'altra applicazione, come un foglio di lavoro Excel.

**Gli eventi ActiveX attiveranno ancora le macro VBA dopo aver salvato una presentazione con Aspose.Slides?**

Salva la presentazione in un formato abilitato alle macro, ad esempio PPTM, per conservare il suo progetto VBA. PowerPoint per Windows può eseguire i gestori di eventi esistenti quando le impostazioni di sicurezza consentono sia i controlli ActiveX sia le macro.