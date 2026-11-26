---
title: Hantera ActiveX‑kontroller i presentationer med C++
linktitle: ActiveX
type: docs
weight: 80
url: /sv/cpp/activex/
keywords:
- ActiveX
- ActiveX‑kontroll
- hantera ActiveX
- lägga till ActiveX
- modifiera ActiveX
- mediaspelare
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Redigera ActiveX‑textrutor och -knappar, uppdatera kontroll‑förhandsgranskningar och återanvänd en Windows Media Player‑kontroll i PowerPoint‑presentationer med Aspose.Slides för C++."
---
## **Introduktion**

ActiveX‑kontroller ger en PowerPoint‑bild interaktiva element såsom textrutor, kommando‑knappar och mediespelare. Aspose.Slides for C++ exponerar en bilds kontroller via [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/). Använd den här samlingen för att redigera en kontroll, flytta den på bilden eller ta bort den.

## **Lista ActiveX‑kontroller och deras lagrade egenskaper**

För att granska en okänd mall, öppna den för läsning och iterera genom kontrollerna på varje bild. Exemplet rapporterar bildnumret, kontrollens namn, [klass-ID](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/), och varje nyckel‑värde‑par i [lagrade egenskaper](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/). Det läser presentationen utan att aktivera kontroller, utlösa händelser eller makron, ändra värden eller spara filen.

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

Det valda resultatet från `ActiveX.pptm` visar en textruta och en kommando‑knapp.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

En tom egenskapssamling visas som `[]`. För kontroller som använder binär lagring kan `get_Properties` returnera `nullptr`, vilket visas som `Properties unavailable`. Om du bara behöver namnen, använd [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) efter att ha kontrollerat att samlingen finns. Rapporten listar de egenskaper som är tillgängliga i presentationen. En kontroll kan stödja ytterligare egenskaper vid körning.

## **Ändra ActiveX‑kontroller**

Exemplet förutsätter en makro‑aktiverad presentation med en textruta benägen `TextBox1` och en kommando‑knapp benägen `CommandButton1` på den första bilden. Det använder [kontrollegenskapssamling](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) för att ändra textrutans värde och knappens rubrik. Varje kontroll har också en statisk förhandsgranskning som PowerPoint kan visa innan aktivering. Tillhandahåll en PNG för varje kontroll som visar dess uppdaterade text och utseende. Exemplet tilldelar dessa bilder via [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/).

Exemplet flyttar varje kontroll på den första bilden nedåt med 100 punkter genom att ändra dess [ram](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/). Det sparar den redigerade presentationen i PPTM‑format, och använder sedan [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) för att spara en andra kopia med alla ActiveX‑kontroller borttagna från den bilden.

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

## **Lägg till en ActiveX‑mediaspelarkontroll**

För att återanvända en konfigurerad Windows Media Player‑kontroll, börja med en mall vars första bild innehåller en spelare benägen `WindowsMediaPlayer1`. [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) kopierar hela bilden till en ny presentation. Exemplet sätter spelarens `URL` i dess [egenskapssamling](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) och sparar den klonade bilden som den enda bilden i utskicket. Videon förblir extern, så välj en sökväg som spelaren kan komma åt under uppspelning.

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

## **Vanliga frågor**

**Kan Aspose.Slides bevara ActiveX‑kontroller utan att köra dem?**

Ja. Aspose.Slides kan läsa och spara kontroller, inklusive deras egenskaper och positioner, utan att aktivera dem.

**Hur skiljer sig ActiveX‑kontroller från OLE‑objekt?**

ActiveX‑kontroller låter användare interagera med en bild, till exempel genom att skriva in text eller klicka på en knapp. Ett [OLE‑objekt](/slides/sv/cpp/manage-ole/) låter en bild innehålla eller länka till innehåll som hanteras av ett annat program, såsom ett Excel‑arbetsblad.

**Kommer ActiveX‑händelser fortfarande att utlösa VBA‑makron efter att jag sparat en presentation med Aspose.Slides?**

Spara presentationen i ett makro‑aktiverat format såsom PPTM för att behålla dess VBA‑projekt. PowerPoint för Windows kan köra de befintliga händelsehanterarna när säkerhetsinställningarna tillåter både ActiveX‑kontroller och makron.