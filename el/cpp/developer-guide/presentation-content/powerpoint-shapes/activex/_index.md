---
title: Διαχείριση στοιχείων ελέγχου ActiveX σε παρουσιάσεις χρησιμοποιώντας C++
linktitle: ActiveX
type: docs
weight: 80
url: /el/cpp/activex/
keywords:
- ActiveX
- Στοιχείο ελέγχου ActiveX
- Διαχείριση ActiveX
- Προσθήκη ActiveX
- Τροποποίηση ActiveX
- Πρόγραμμα αναπαραγωγής πολυμέσων
- PowerPoint
- Παρουσίαση
- C++
- Aspose.Slides
description: "Επεξεργασία πλαισίων κειμένου και κουμπιών ActiveX, ενημέρωση των προεπισκοπήσεων των ελέγχων, και επαναχρησιμοποίηση ενός στοιχείου Windows Media Player σε παρουσιάσεις PowerPoint με το Aspose.Slides για C++."
---
## **Εισαγωγή**

Τα στοιχεία ελέγχου ActiveX παρέχουν σε μια διαφάνεια του PowerPoint διαδραστικά στοιχεία όπως πεδία κειμένου, κουμπιά εντολών και προγράμματα αναπαραγωγής πολυμέσων. Το Aspose.Slides for C++ εκθέτει τα στοιχεία ελέγχου μιας διαφάνειας μέσω του [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/). Χρησιμοποιήστε αυτή τη συλλογή για να επεξεργαστείτε ένα στοιχείο, να το μετακινήσετε στη διαφάνεια ή να το καταργήσετε.

## **Καταγραφή στοιχείων ελέγχου ActiveX και των αποθηκευμένων ιδιοτήτων**

Για να εξετάσετε ένα άγνωστο πρότυπο, ανοίξτε το για ανάγνωση και επαναλάβετε τα στοιχεία ελέγχου σε κάθε διαφάνεια. Το παράδειγμα εμφανίζει τον αριθμό της διαφάνειας, το όνομα του στοιχείου, το [ID κλάσης](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/), και κάθε ζεύγος κλειδιού‑τιμής στις [αποθηκευμένες ιδιότητες](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/). Διαβάζει την παρουσίαση χωρίς να ενεργοποιήσει τα στοιχεία, να καλέσει γεγονότα ή μακροεντολές, να αλλάξει τιμές ή να αποθηκεύσει το αρχείο.

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

Επιλεγμένη έξοδος από `ActiveX.pptm` δείχνει ένα πλαίσιο κειμένου και ένα κουμπί εντολής.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Μια κενή συλλογή ιδιοτήτων εμφανίζεται ως `[]`. Για στοιχεία που χρησιμοποιούν δυαδική αποθήκευση, το `get_Properties` μπορεί να επιστρέψει `nullptr`, το οποίο εμφανίζεται ως `Properties unavailable`. Εάν χρειάζεστε μόνο τα ονόματα, χρησιμοποιήστε το [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) αφού ελέγξετε ότι η συλλογή υπάρχει. Η αναφορά καταγράφει τις ιδιότητες που είναι διαθέσιμες στην παρουσίαση. Ένα στοιχείο μπορεί να υποστηρίζει πρόσθετες ιδιότητες κατά τη διάρκεια εκτέλεσης.

## **Τροποποίηση στοιχείων ελέγχου ActiveX**

Το παράδειγμα προϋποθέτει μια παρουσίαση με ενεργοποιημένες μακροεντολές που περιέχει ένα πλαίσιο κειμένου με όνομα `TextBox1` και ένα κουμπί εντολής με όνομα `CommandButton1` στην πρώτη διαφάνεια. Χρησιμοποιεί τη [συλλογή ιδιοτήτων ελέγχου](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) για να αλλάξει την τιμή του πλαισίου κειμένου και την επιγραφή του κουμπιού. Κάθε στοιχείο διαθέτει επίσης μια στατική προεπισκόπηση που μπορεί να εμφανίσει το PowerPoint πριν από την ενεργοποίηση. Παρέχετε ένα PNG για κάθε στοιχείο που να δείχνει το ενημερωμένο κείμενο και την εμφάνιση. Το παράδειγμα ορίζει αυτές τις εικόνες μέσω του [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/).

Το παράδειγμα μετακινεί κάθε στοιχείο στην πρώτη διαφάνεια προς τα κάτω κατά 100 σημεία, αλλάζοντας το [πλαίσιο](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/). Στη συνέχεια αποθηκεύει την επεξεργασμένη παρουσίαση σε μορφή PPTM και χρησιμοποιεί το [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) για να αποθηκεύσει ένα δεύτερο αντίγραφο χωρίς κανένα στοιχείο ActiveX στην εν λόγω διαφάνεια.

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

## **Προσθήκη στοιχείου ελέγχου Media Player ActiveX**

Για να επαναχρησιμοποιήσετε ένα ρυθμισμένο στοιχείο Windows Media Player, ξεκινήστε με ένα πρότυπο του οποίου η πρώτη διαφάνεια περιέχει έναν παίκτη με όνομα `WindowsMediaPlayer1`. Το [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) αντιγράφει ολόκληρη τη διαφάνεια σε μια νέα παρουσίαση. Το παράδειγμα ορίζει το `URL` του παίκτη στη [συλλογή ιδιοτήτων](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) και αποθηκεύει τη κλωνοποιημένη διαφάνεια ως τη μοναδική διαφάνεια στο αποτέλεσμα. Το βίντεο παραμένει εξωτερικό, οπότε επιλέξτε μια διαδρομή που ο παίκτης μπορεί να προσπελάσει κατά την αναπαραγωγή.

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

## **Συχνές ερωτήσεις**

**Μπορεί το Aspose.Slides να διατηρήσει στοιχεία ελέγχου ActiveX χωρίς να τα εκτελέσει;**

Ναι. Το Aspose.Slides μπορεί να διαβάσει και να αποθηκεύσει τα στοιχεία ελέγχου, συμπεριλαμβανομένων των ιδιοτήτων και των θέσεων τους, χωρίς να τα ενεργοποιήσει.

**Πώς διαφέρουν τα στοιχεία ελέγχου ActiveX από τα αντικείμενα OLE;**

Τα στοιχεία ελέγχου ActiveX επιτρέπουν στους χρήστες να αλληλεπιδράσουν με μια διαφάνεια, για παράδειγμα εισάγοντας κείμενο ή πατώντας ένα κουμπί. Ένα [OLE object](/slides/el/cpp/manage-ole/) επιτρέπει σε μια διαφάνεια να περιέχει ή να συνδέεται με περιεχόμενο που διαχειρίζεται άλλη εφαρμογή, όπως ένα φύλλο εργασίας Excel.

**Θα ενεργοποιηθούν ακόμα τα συμβάντα ActiveX και τα μακροεντολές VBA μετά την αποθήκευση μιας παρουσίασης με το Aspose.Slides;**

Αποθηκεύστε την παρουσίαση σε μορφή που υποστηρίζει μακροεντολές, όπως PPTM, για να διατηρήσετε το έργο VBA. Το PowerPoint για Windows μπορεί να εκτελέσει τους υπάρχοντες χειριστές συμβάντων όταν οι ρυθμίσεις ασφαλείας του επιτρέπουν τόσο στοιχεία ελέγχου ActiveX όσο και μακροεντολές.