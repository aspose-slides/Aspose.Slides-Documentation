---
title: Verwalten von ActiveX-Steuerelementen in Präsentationen mit C++
linktitle: ActiveX
type: docs
weight: 80
url: /de/cpp/activex/
keywords:
- ActiveX
- ActiveX-Steuerelement
- ActiveX verwalten
- ActiveX hinzufügen
- ActiveX ändern
- Mediaplayer
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "ActiveX-Textfelder und -Schaltflächen bearbeiten, Steuerelement-Vorschauen aktualisieren und ein Windows Media Player-Steuerelement in PowerPoint-Präsentationen mit Aspose.Slides für C++ wiederverwenden."
---
## **Einleitung**

ActiveX‑Steuerelemente geben einer PowerPoint‑Folie interaktive Elemente wie Textfelder, Befehls‑Schaltflächen und Medien‑Player. Aspose.Slides für C++ stellt die Steuerelemente einer Folie über [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/) bereit. Verwenden Sie diese Sammlung, um ein Steuerelement zu bearbeiten, es auf der Folie zu verschieben oder zu entfernen.

## **Auflisten von ActiveX‑Steuerelementen und deren gespeicherten Eigenschaften**

Um eine unbekannte Vorlage zu untersuchen, öffnen Sie sie zum Lesen und iterieren Sie über die Steuerelemente jeder Folie. Das Beispiel gibt die Foliennummer, den Namen des Steuerelements, die [Class‑ID](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/), und jedes Schlüssel‑Wert‑Paar in den [gespeicherten Eigenschaften](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/) aus. Es liest die Präsentation, ohne Steuerelemente zu aktivieren, Ereignisse oder Makros auszulösen, Werte zu ändern oder die Datei zu speichern.

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

Die ausgewählte Ausgabe von `ActiveX.pptm` zeigt ein Textfeld und eine Befehls‑Schaltfläche.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Eine leere Eigenschaftssammlung erscheint als `[]`. Für Steuerelemente, die binäre Speicherung verwenden, kann `get_Properties` `nullptr` zurückgeben, angezeigt als `Properties unavailable`. Wenn Sie nur die Namen benötigen, verwenden Sie [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) nachdem Sie überprüft haben, dass die Sammlung existiert. Der Bericht listet die aus der Präsentation verfügbaren Eigenschaften auf. Ein Steuerelement kann zur Laufzeit zusätzliche Eigenschaften unterstützen.

## **ActiveX‑Steuerelemente ändern**

Das Beispiel erwartet eine makrofähige Präsentation mit einem Textfeld namens `TextBox1` und einer Befehls‑Schaltfläche namens `CommandButton1` auf der ersten Folie. Es verwendet die [Steuerelement‑Eigenschaftssammlung](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/), um den Wert des Textfelds und die Beschriftung der Schaltfläche zu ändern. Jedes Steuerelement verfügt außerdem über eine statische Vorschau, die PowerPoint vor der Aktivierung anzeigen kann. Stellen Sie für jedes Steuerelement ein PNG bereit, das den aktualisierten Text und das Erscheinungsbild zeigt. Das Beispiel weist diese Bilder über [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/) zu.

Das Beispiel verschiebt jedes Steuerelement auf der ersten Folie um 100 Punkte nach unten, indem es dessen [frame](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/) ändert. Es speichert die bearbeitete Präsentation im PPTM‑Format und verwendet anschließend [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/), um eine zweite Kopie zu speichern, in der alle ActiveX‑Steuerelemente von dieser Folie entfernt sind.

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
## **Ein ActiveX‑Media‑Player‑Steuerelement hinzufügen**

Um ein konfiguriertes Windows Media Player‑Steuerelement wiederzuverwenden, beginnen Sie mit einer Vorlage, bei der die erste Folie einen Player namens `WindowsMediaPlayer1` enthält. [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) kopiert die gesamte Folie in eine neue Präsentation. Das Beispiel setzt die `URL` des Players in seiner [Eigenschaftssammlung](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) und speichert die geklonte Folie als einzige Folie in der Ausgabe. Das Video bleibt extern, wählen Sie also einen Pfad, auf den der Player während der Wiedergabe zugreifen kann.

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

**Kann Aspose.Slides ActiveX‑Steuerelemente erhalten, ohne sie auszuführen?**

Ja. Aspose.Slides kann Steuerelemente lesen und speichern, einschließlich ihrer Eigenschaften und Positionen, ohne sie zu aktivieren.

**Wie unterscheiden sich ActiveX‑Steuerelemente von OLE‑Objekten?**

ActiveX‑Steuerelemente ermöglichen es Benutzern, mit einer Folie zu interagieren, beispielsweise indem sie Text eingeben oder eine Schaltfläche anklicken. Ein [OLE‑Objekt](/slides/de/cpp/manage-ole/) lässt eine Folie Inhalte enthalten oder damit verlinken, die von einer anderen Anwendung verwaltet werden, etwa ein Excel‑Arbeitsblatt.

**Lösen ActiveX‑Ereignisse weiterhin VBA‑Makros aus, nachdem ich eine Präsentation mit Aspose.Slides gespeichert habe?**

Speichern Sie die Präsentation in einem makrofähigen Format wie PPTM, um ihr VBA‑Projekt zu erhalten. PowerPoint für Windows kann die vorhandenen Ereignis‑Handler ausführen, wenn die Sicherheitseinstellungen sowohl ActiveX‑Steuerelemente als auch Makros zulassen.