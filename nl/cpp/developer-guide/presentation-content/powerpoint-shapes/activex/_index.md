---
title: ActiveX-besturingselementen beheren in presentaties met C++
linktitle: ActiveX
type: docs
weight: 80
url: /nl/cpp/activex/
keywords:
- ActiveX
- ActiveX-besturingselement
- ActiveX beheren
- ActiveX toevoegen
- ActiveX aanpassen
- mediaspeler
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Bewerk ActiveX-tekstvakken en -knoppen, werk voorbeeldweergaven van besturingselementen bij en hergebruik een Windows Media Player-besturingselement in PowerPoint-presentaties met Aspose.Slides voor C++."
---
## **Introductie**

ActiveX‑besturingselementen geven een PowerPoint‑dia interactieve elementen zoals tekstvakken, opdrachtknoppen en mediaspelers. Aspose.Slides for C++ maakt de besturingselementen van een dia toegankelijk via [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/). Gebruik deze verzameling om een besturingselement te bewerken, te verplaatsen op de dia, of te verwijderen.

## **Lijst van ActiveX‑besturingselementen en hun opgeslagen eigenschappen**

Om een onbekende sjabloon te inspecteren, open deze voor lezen en doorloop de besturingselementen op elke dia. Het voorbeeld geeft het slidennummer, de naam van het besturingselement, [class ID](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/), en elk sleutel‑waarde‑paar in de [opgeslagen eigenschappen](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/). Het leest de presentatie zonder de besturingselementen te activeren, gebeurtenissen of macro’s aan te roepen, waarden te wijzigen, of het bestand op te slaan.

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

Geselecteerde output van `ActiveX.pptm` toont een tekstvak en een opdrachtknop.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Een lege eigenschapverzameling verschijnt als `[]`. Voor besturingselementen die binaire opslag gebruiken, kan `get_Properties` `nullptr` retourneren, weergegeven als `Properties unavailable`. Als je alleen de namen nodig hebt, gebruik dan [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) na te hebben gecontroleerd dat de verzameling bestaat. Het rapport somt de eigenschappen op die beschikbaar zijn vanuit de presentatie. Een besturingselement kan tijdens runtime extra eigenschappen ondersteunen.

## **ActiveX‑besturingselementen wijzigen**

Het voorbeeld verwacht een macro‑ingeschakelde presentatie met een tekstvak genaamd `TextBox1` en een opdrachtknop genaamd `CommandButton1` op de eerste dia. Het gebruikt de [control properties collection](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) om de waarde van het tekstvak en het bijschrift van de knop te wijzigen. Elk besturingselement heeft ook een statische voorbeeldweergave die PowerPoint kan tonen vóór activatie. Lever een PNG voor elk besturingselement dat de bijgewerkte tekst en weergave toont. Het voorbeeld kent deze afbeeldingen toe via [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/).

Het voorbeeld verplaatst elk besturingselement op de eerste dia 100 punten naar beneden door het [frame](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/) te wijzigen. Het slaat de bewerkte presentatie op in PPTM‑formaat, en gebruikt daarna [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) om een tweede kopie op te slaan waarbij alle ActiveX‑besturingselementen van die dia verwijderd zijn.

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

## **ActiveX‑mediaspeler toevoegen**

Om een geconfigureerde Windows Media Player‑besturingselement opnieuw te gebruiken, begin met een sjabloon waarvan de eerste dia een speler bevat genaamd `WindowsMediaPlayer1`. [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) kopieert de volledige dia naar een nieuwe presentatie. Het voorbeeld stelt de `URL` van de speler in via de [properties collection](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) en slaat de gekloonde dia op als de enige dia in de uitvoer. De video blijft extern, dus kies een pad dat de speler tijdens het afspelen kan benaderen.

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

**Kan Aspose.Slides ActiveX‑besturingselementen behouden zonder ze uit te voeren?**

Ja. Aspose.Slides kan besturingselementen lezen en opslaan, inclusief hun eigenschappen en posities, zonder ze te activeren.

**Hoe verschillen ActiveX‑besturingselementen van OLE‑objecten?**

ActiveX‑besturingselementen laten gebruikers met een dia interageren, bijvoorbeeld door tekst in te voeren of op een knop te klikken. Een [OLE object](/slides/nl/cpp/manage-ole/) laat een dia inhoud bevatten of linken naar content die wordt beheerd door een andere toepassing, zoals een Excel‑werkblad.

**Zullen ActiveX‑gebeurtenissen nog steeds VBA‑macro's activeren nadat ik een presentatie opsla met Aspose.Slides?**

Sla de presentatie op in een macro‑ingeschakeld formaat zoals PPTM om het VBA‑project te behouden. PowerPoint voor Windows kan de bestaande gebeurtenishandlers uitvoeren wanneer de beveiligingsinstellingen zowel ActiveX‑besturingselementen als macro's toestaan.