---
title: Zarządzanie kontrolkami ActiveX w prezentacjach przy użyciu C++
linktitle: ActiveX
type: docs
weight: 80
url: /pl/cpp/activex/
keywords:
- ActiveX
- kontrolka ActiveX
- zarządzaj ActiveX
- dodaj ActiveX
- modyfikuj ActiveX
- odtwarzacz multimedialny
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Edytuj pola tekstowe i przyciski ActiveX, aktualizuj podglądy kontrolek oraz ponownie użyj kontrolki Windows Media Player w prezentacjach PowerPoint przy pomocy Aspose.Slides for C++."
---
## **Wprowadzenie**

Kontrolki ActiveX zapewniają slajdowi programu PowerPoint elementy interaktywne, takie jak pola tekstowe, przyciski poleceń i odtwarzacze multimedialne. Aspose.Slides for C++ udostępnia kontrolki slajdu poprzez [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/). Użyj tej kolekcji, aby edytować kontrolkę, przenieść ją na slajdzie lub usunąć ją.

## **Lista kontrolek ActiveX i ich przechowywanych właściwości**

Aby zbadać nieznany szablon, otwórz go do odczytu i przeiteruj kontrolki na każdym slajdzie. Przykład raportuje numer slajdu, nazwę kontrolki, [identyfikator klasy](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/), oraz każdą parę klucz‑wartość w [przechowywane właściwości](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/). Odczytuje prezentację bez aktywacji kontrolek, wywoływania zdarzeń lub makr, zmieniania wartości ani zapisywania pliku.

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

Wybrany wynik z `ActiveX.pptm` pokazuje pole tekstowe i przycisk polecenia.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Pusta kolekcja właściwości wyświetla się jako `[]`. Dla kontrolek używających binarnego przechowywania, `get_Properties` może zwrócić `nullptr`, co jest pokazane jako `Properties unavailable`. Jeśli potrzebujesz tylko nazw, użyj [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) po sprawdzeniu, czy kolekcja istnieje. Raport wymienia właściwości dostępne w prezentacji. Kontrolka może obsługiwać dodatkowe właściwości w czasie wykonywania.

## **Modyfikacja kontrolek ActiveX**

Przykład zakłada prezentację z włączonymi makrami zawierającą pole tekstowe o nazwie `TextBox1` oraz przycisk polecenia o nazwie `CommandButton1` na pierwszym slajdzie. Używa [kolekcja właściwości kontrolki](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) do zmiany wartości pola tekstowego i napisu przycisku. Każda kontrolka ma również statyczny podgląd, który PowerPoint może wyświetlić przed aktywacją. Dostarcz plik PNG dla każdej kontrolki, pokazujący zaktualizowany tekst i wygląd. Przykład przypisuje te obrazy poprzez [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/).

Przykład przesuwa każdą kontrolkę na pierwszym slajdzie w dół o 100 punktów, zmieniając jej [ramka](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/). Zapisuje edytowaną prezentację w formacie PPTM, a następnie używa [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) aby zapisać drugą kopię z usuniętymi wszystkimi kontrolkami ActiveX z tego slajdu.

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

## **Dodanie kontrolki odtwarzacza multimedialnego ActiveX**

Aby ponownie użyć skonfigurowanej kontrolki Windows Media Player, rozpocznij od szablonu, którego pierwszy slajd zawiera odtwarzacz o nazwie `WindowsMediaPlayer1`. [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) kopiuje cały slajd do nowej prezentacji. Przykład ustawia `URL` odtwarzacza w jego [kolekcja właściwości](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) i zapisuje sklonowany slajd jako jedyny slajd w wyniku. Wideo pozostaje zewnętrzne, więc wybierz ścieżkę dostępną dla odtwarzacza podczas odtwarzania.

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

## **Najczęściej zadawane pytania**

**Czy Aspose.Slides może zachować kontrolki ActiveX bez ich uruchamiania?**

Tak. Aspose.Slides może odczytywać i zapisywać kontrolki, w tym ich właściwości i pozycje, bez ich aktywacji.

**Czym kontrolki ActiveX różnią się od obiektów OLE?**

Kontrolki ActiveX pozwalają użytkownikom wchodzić w interakcję ze slajdem, np. wprowadzając tekst lub klikając przycisk. [obiekt OLE](/slides/pl/cpp/manage-ole/) pozwala slajdowi zawierać lub odwoływać się do treści zarządzanej przez inną aplikację, taką jak arkusz Excel.

**Czy zdarzenia ActiveX nadal wywołają makra VBA po zapisaniu prezentacji przy użyciu Aspose.Slides?**

Zapisz prezentację w formacie z włączonymi makrami, takim jak PPTM, aby zachować projekt VBA. PowerPoint dla systemu Windows może uruchamiać istniejące obsługi zdarzeń, gdy ustawienia zabezpieczeń zezwalają zarówno na kontrolki ActiveX, jak i makra.