---
title: ActiveX vezérlők kezelése prezentációkban C++ használatával
linktitle: ActiveX
type: docs
weight: 80
url: /hu/cpp/activex/
keywords:
- ActiveX
- ActiveX vezérlő
- ActiveX kezelése
- ActiveX hozzáadása
- ActiveX módosítása
- médialejátszó
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Szerkessze az ActiveX szövegdobozokat és gombokat, frissítse a vezérlő előnézeteket, valamint használja újra a Windows Media Player vezérlőt PowerPoint prezentációkban az Aspose.Slides for C++ segítségével."
---
## **Bevezetés**

Az ActiveX vezérlők interaktív elemeket adnak a PowerPoint diához, például szövegdobozokat, parancsgombokat és médialejátszókat. Az Aspose.Slides for C++ a dia vezérlőit a [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/) segítségével teszi elérhetővé. Használja ezt a gyűjteményt egy vezérlő szerkesztéséhez, áthelyezéséhez a dián, vagy eltávolításához.

## **ActiveX vezérlők listázása és tárolt tulajdonságaik**

Egy ismeretlen sablon ellenőrzéséhez nyissa meg olvasásra, és iteráljon végig a diákon lévő vezérlőkön. A példa jelentést készít a dia számáról, a vezérlő nevéről, a [class ID](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/) értékről, valamint minden kulcs-ertek párról a [stored properties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/) gyűjteményben. A prezentációt anélkül olvassa be, hogy a vezérlőket aktiválná, eseményeket vagy makrókat hívna meg, értékeket változtatna, vagy a fájlt mentené.

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

A `ActiveX.pptm` kiválasztott kimenete egy szövegdobozt és egy parancsgombot mutat.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Egy üres tulajdonsággyűjtemény `[]` formában jelenik meg. Azoknál a vezérlőknél, amelyek bináris tárolást használnak, a `get_Properties` visszaadhat `nullptr` értéket, amelyet a `Properties unavailable` jelöl. Ha csak a nevekre van szüksége, használja a [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) függvényt, miután ellenőrizte, hogy a gyűjtemény létezik. A jelentés felsorolja a prezentációból elérhető tulajdonságokat. Egy vezérlő futasidoben további tulajdonságokat is támogathat.

## **ActiveX vezérlők módosítása**

A példa egy makró-engedélyezett prezentációt vár, amelyen az első dián egy `TextBox1` nevű szövegdoboz és egy `CommandButton1` nevű parancsgomb található. A [control properties collection](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) segítségével módosítja a szövegdoboz értékét és a gomb feliratát. Minden vezérlőnek van egy statikus előnézete is, amelyet a PowerPoint aktiválás előtt megjeleníthet. Adjon meg egy PNG-t minden vezérlőhöz, amely a frissített szöveget és megjelenést mutatja. A példa ezeket a képeket az [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/) segítségével rendeli hozzá.

A példa minden vezérlőt az első dián 100 ponttal lefelé mozgat a [frame](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/) módosításával. A szerkesztett prezentációt PPTM formátumban menti, majd a [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) segítségével elment egy második példányt, amelyből az összes ActiveX vezérlő el van távolítva az adott diáról.

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

## **ActiveX médiaplayer vezérlő hozzáadása**

Egy előre beállított Windows Media Player vezérlő újrahasználatához kezdjen egy olyan sablonnal, amelynek első diáján egy `WindowsMediaPlayer1` nevű lejátszó található. Az [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) lemásolja az egész diát egy új prezentációba. A példa a lejátszó `URL`-jét a [properties collection](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) segítségével állítja be, és a klónozott diát az egyetlen diaként menti a kimenetbe. A videó külső marad, ezért válasszon egy útvonalat, amelyhez a lejátszó a lejátszás során hozzáfér.

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

**Az Aspose.Slides képes megőrizni az ActiveX vezérlőket anélkül, hogy futtatná őket?**

Igen. Az Aspose.Slides képes beolvasni és menteni a vezérlőket, beleértve azok tulajdonságait és pozícióit, anélkül, hogy aktiválná őket.

**Miben különböznek az ActiveX vezérlők az OLE objektumoktól?**

Az ActiveX vezérlők lehetővé teszik a felhasználók számára, hogy interakcióba lépjenek a diával, például szöveget írjanak be vagy gombra kattintsanak. Egy [OLE object](/slides/hu/cpp/manage-ole/) lehetővé teszi, hogy a dia akár tartalmazzon, akár hivatkozzon egy másik alkalmazás által kezelt tartalomra, mint például egy Excel munkalap.

**Az ActiveX események még mindig aktiválják a VBA makrókat, ha az Aspose.Slides-szel mentek egy prezentációt?**

Mentse a prezentációt makró-engedélyezett formátumban, például PPTM-ben, hogy megőrizze a VBA projektet. A Windows PowerPoint képes futtatni a meglévő eseménykezelőket, ha a biztonsági beállítások engedélyezik az ActiveX vezérlőket és a makrókat.