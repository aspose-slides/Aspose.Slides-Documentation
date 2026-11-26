---
title: Gestire i controlli ActiveX nelle presentazioni usando C++
linktitle: ActiveX
type: docs
weight: 80
url: /it/cpp/activex/
keywords:
- ActiveX
- controllo ActiveX
- gestire ActiveX
- aggiungere ActiveX
- modificare ActiveX
- lettore multimediale
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Modifica caselle di testo e pulsanti ActiveX, aggiorna le anteprime dei controlli e riutilizza un controllo Windows Media Player nelle presentazioni PowerPoint con Aspose.Slides per C++."
---
## **Introduzione**

I controlli ActiveX forniscono a una diapositiva PowerPoint elementi interattivi come caselle di testo, pulsanti di comando e lettori multimediali. Aspose.Slides per C++ espone i controlli di una diapositiva tramite [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/). Utilizza questa raccolta per modificare un controllo, spostarlo sulla diapositiva o rimuoverlo.

## **Elenco dei controlli ActiveX e delle loro proprietà memorizzate**

Per esaminare un modello sconosciuto, aprilo in lettura e itera sui controlli di ciascuna diapositiva. L’esempio segnala il numero della diapositiva, il nome del controllo, [class ID](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/), e ogni coppia chiave‑valore nelle [stored properties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/). Legge la presentazione senza attivare i controlli, invocare eventi o macro, modificare valori o salvare il file.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");

for (auto i = 0; i < presentation->get_Slides()->get_Count(); ++i)
{
    auto controls = presentation->get_Slide(i)->get_Controls();
    for (auto j = 0; j < controls->get_Count(); ++j)
    {
        auto control = controls->idx_get(j);
        Console::WriteLine(u"Slide {0} | {1} | {2}", i + 1, control->get_Name(), control->get_ClassId().ToString());
        auto properties = control->get_Properties();
        if (!properties)
        {
            Console::WriteLine(u"  Properties unavailable");
            continue;
        }

        if (properties->get_Count() == 0)
            Console::WriteLine(u"  []");

        auto entries = properties->GetEnumerator();
        while (entries->MoveNext())
        {
            auto property = entries->get_Current();
            Console::WriteLine(u"  {0} = {1}", property.get_Key(), property.get_Value());
        }
    }
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

Una raccolta di proprietà vuota appare come `[]`. Per i controlli che usano archiviazione binaria, `get_Properties` può restituire `nullptr`, mostrato come `Properties unavailable`. Se ti servono solo i nomi, utilizza [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) dopo aver verificato che la raccolta esista. Il rapporto elenca le proprietà disponibili dalla presentazione. Un controllo può supportare proprietà aggiuntive a runtime.

## **Modifica controlli ActiveX**

L’esempio si aspetta una presentazione abilitata alle macro con una casella di testo denominata `TextBox1` e un pulsante di comando denominato `CommandButton1` nella prima diapositiva. Usa la [control properties collection](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) per modificare il valore della casella di testo e la didascalia del pulsante. Ogni controllo possiede anche un’anteprima statica che PowerPoint può visualizzare prima dell’attivazione. Fornisci un PNG per ciascun controllo che mostri il testo aggiornato e l’aspetto. L’esempio assegna queste immagini tramite [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/).

L’esempio sposta ogni controllo nella prima diapositiva verso il basso di 100 punti modificandone il [frame](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/). Salva la presentazione modificata in formato PPTM, quindi utilizza [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) per salvare una seconda copia con tutti i controlli ActiveX rimossi da quella diapositiva.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");
auto controls = presentation->get_Slide(0)->get_Controls();
SharedPtr<IControl> textBox;
SharedPtr<IControl> button;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"TextBox1")
        textBox = control;
    else if (control->get_Name() == u"CommandButton1")
        button = control;
}

if (!textBox || !button || !textBox->get_Properties() || !button->get_Properties())
{
    Console::WriteLine(u"The first slide must contain both named controls with editable properties.");
    return;
}

if (!File::Exists(u"text-box-preview.png") || !File::Exists(u"button-preview.png"))
{
    Console::WriteLine(u"Supply both preview images before updating the controls.");
    return;
}

textBox->get_Properties()->idx_set(u"Value", u"Changed text");
button->get_Properties()->idx_set(u"Caption", u"Show message");

auto textBoxBytes = File::ReadAllBytes(u"text-box-preview.png");
auto buttonBytes = File::ReadAllBytes(u"button-preview.png");
auto textBoxPreview = presentation->get_Images()->AddImage(textBoxBytes);
auto buttonPreview = presentation->get_Images()->AddImage(buttonBytes);
textBox->get_SubstitutePictureFormat()->get_Picture()->set_Image(textBoxPreview);
button->get_SubstitutePictureFormat()->get_Picture()->set_Image(buttonPreview);

for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    auto frame = control->get_Frame();
    auto movedFrame = MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation());
    control->set_Frame(movedFrame);
}

presentation->Save(u"edited-controls.pptm", SaveFormat::Pptm);

controls->Clear();
presentation->Save(u"removed-controls.pptm", SaveFormat::Pptm);
```

## **Aggiungi un controllo ActiveX Media Player**

Per riutilizzare un lettore Windows Media Player configurato, inizia con un modello la cui prima diapositiva contiene un lettore denominato `WindowsMediaPlayer1`. [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) copia l’intera diapositiva in una nuova presentazione. L’esempio imposta l'`URL` del lettore nella sua [properties collection](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) e salva la diapositiva clonata come unica diapositiva nell'output. Il video rimane esterno, quindi scegli un percorso accessibile al lettore durante la riproduzione.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto source = MakeObject<Presentation>(u"template.pptx");
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slides()->AddClone(source->get_Slide(0));
auto controls = slide->get_Controls();

SharedPtr<IControl> player;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"WindowsMediaPlayer1")
    {
        player = control;
        break;
    }
}

if (!player || !player->get_Properties())
{
    Console::WriteLine(u"The template slide must contain a named media player with editable properties.");
    return;
}

player->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

presentation->get_Slides()->RemoveAt(0);
presentation->Save(u"linked-video.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Può Aspose.Slides preservare i controlli ActiveX senza eseguirli?**

Sì. Aspose.Slides può leggere e salvare i controlli, incluse le loro proprietà e posizioni, senza attivarli.

**In che modo i controlli ActiveX differiscono dagli oggetti OLE?**

I controlli ActiveX consentono agli utenti di interagire con una diapositiva, ad esempio inserendo testo o facendo clic su un pulsante. Un [oggetto OLE](/slides/it/cpp/manage-ole/) consente a una diapositiva di contenere o collegare contenuti gestiti da un'altra applicazione, come un foglio di lavoro Excel.

**Gli eventi ActiveX attiveranno ancora le macro VBA dopo aver salvato una presentazione con Aspose.Slides?**

Salva la presentazione in un formato abilitato alle macro, come PPTM, per conservare il progetto VBA. PowerPoint per Windows può eseguire i gestori di eventi esistenti quando le impostazioni di sicurezza consentono sia i controlli ActiveX sia le macro.