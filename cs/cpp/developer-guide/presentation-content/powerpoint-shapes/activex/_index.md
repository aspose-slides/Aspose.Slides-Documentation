---
title: Správa ActiveX ovládacích prvků v prezentacích pomocí C++
linktitle: ActiveX
type: docs
weight: 80
url: /cs/cpp/activex/
keywords:
- ActiveX
- ActiveX ovládací prvek
- správa ActiveX
- přidání ActiveX
- úprava ActiveX
- přehrávač médií
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Upravujte textová pole a tlačítka ActiveX, aktualizujte náhledy ovládacích prvků a znovu použijte ovládací prvek Windows Media Player v prezentacích PowerPoint s Aspose.Slides pro C++."
---
## **Úvod**

ActiveX ovládací prvky poskytují snímku PowerPointu interaktivní prvky, jako jsou textová pole, tlačítka příkazů a přehrávače médií. Aspose.Slides for C++ zpřístupňuje ovládací prvky snímku prostřednictvím [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/). Použijte tuto kolekci k úpravě ovládacího prvku, jeho přesunu na snímku nebo odebrání.

## **Seznam ActiveX ovládacích prvků a jejich uložených vlastností**

Chcete-li prozkoumat neznámou šablonu, otevřete ji pro čtení a projděte ovládací prvky na každém snímku. Příklad uvádí číslo snímku, název ovládacího prvku, [class ID](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/), a každý pár klíč‑hodnota v [uložené vlastnosti](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/). Načte prezentaci bez aktivace ovládacích prvků, spouštění událostí nebo maker, změny hodnot či ukládání souboru.

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

Vybraný výstup ze souboru `ActiveX.pptm` zobrazuje textové pole a tlačítko příkazu.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Prázdná kolekce vlastností se zobrazuje jako `[]`. U ovládacích prvků, které používají binární úložiště, může `get_Properties` vrátit `nullptr`, což je zobrazeno jako `Properties unavailable`. Pokud potřebujete jen názvy, použijte [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) po ověření existence kolekce. Zpráva vypisuje vlastnosti dostupné v prezentaci. Ovládací prvek může za běhu podporovat další vlastnosti.

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

## **Upravit ActiveX ovládací prvky**

Příklad předpokládá prezentaci s povolenými makry, která na prvním snímku obsahuje textové pole pojmenované `TextBox1` a tlačítko příkazu pojmenované `CommandButton1`. Používá [control properties collection](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) k změně hodnoty textového pole a popisku tlačítka. Každý ovládací prvek má také statický náhled, který PowerPoint může zobrazit před aktivací. Poskytněte PNG pro každý ovládací prvek zobrazující aktuální text a vzhled. Příklad přiřadí tyto obrázky pomocí [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/).

Příklad přesune každý ovládací prvek na prvním snímku dolů o 100 bodů změnou jeho [frame](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/). Uloží upravenou prezentaci ve formátu PPTM a poté použije [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/), aby uložil druhou kopii s odstraněnými všemi ActiveX ovládacími prvky z tohoto snímku.

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

## **Přidat ActiveX Media Player ovládací prvek**

Aby bylo možné znovu použít nakonfigurovaný ovládací prvek Windows Media Player, začněte šablonou, jejíž první snímek obsahuje přehrávač pojmenovaný `WindowsMediaPlayer1`. [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) zkopíruje celý snímek do nové prezentace. Příklad nastaví `URL` přehrávače v jeho [properties collection](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) a uloží klonovaný snímek jako jediný snímek ve výstupu. Video zůstane externí, takže zvolte cestu, ke které může přehrávač během přehrávání přistupovat.

## **Často kladené otázky**

**Může Aspose.Slides zachovat ActiveX ovládací prvky bez jejich spouštění?**

Ano. Aspose.Slides může číst a ukládat ovládací prvky, včetně jejich vlastností a umístění, aniž by je aktivovalo.

**Jak se liší ActiveX ovládací prvky od OLE objektů?**

ActiveX ovládací prvky umožňují uživatelům interagovat se snímkem, například zadávat text nebo kliknout na tlačítko. [OLE objekt](/slides/cs/cpp/manage-ole/) umožňuje snímku obsahovat nebo odkazovat na obsah spravovaný jinou aplikací, jako je list Excel.

**Spustí události ActiveX stále VBA makra po uložení prezentace pomocí Aspose.Slides?**

Uložte prezentaci v makry podporujícím formátu, například PPTM, aby byl zachován její VBA projekt. PowerPoint pro Windows může spouštět existující obslužné programy událostí, pokud jsou v nastavení zabezpečení povoleny jak ActiveX ovládací prvky, tak makra.