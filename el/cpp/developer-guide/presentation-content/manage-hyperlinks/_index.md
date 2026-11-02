---
title: Διαχείριση υπερσυνδέσμων παρουσίασης σε C++
linktitle: Διαχείριση υπερσυνδέσμων
type: docs
weight: 20
url: /el/cpp/manage-hyperlinks/
keywords:
- προσθήκη URL
- προσθήκη υπερσύνδεσμου
- δημιουργία υπερσύνδεσμου
- μορφοποίηση υπερσύνδεσμου
- αφαίρεση υπερσύνδεσμου
- ενημέρωση υπερσύνδεσμου
- υπερσύνδεσμος κειμένου
- υπερσύνδεσμος διαφάνειας
- υπερσύνδεσμος σχήματος
- υπερσύνδεσμος εικόνας
- υπερσύνδεσμος βίντεο
- μεταβλητός υπερσύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Προσθήκη, μορφοποίηση, ενημέρωση και αφαίρεση υπερσυνδέσμων σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για C++, χρησιμοποιώντας παραδείγματα C++."
---
## **Εισαγωγή**

Ένας υπερσύνδεσμος συνδέει το περιεχόμενο της παρουσίασης με έναν ιστότοπο ή μια θέση εντός της παρουσίασης. Στο PowerPoint, οι υπερσύνδεσμοι συνήθως εξυπηρετούν δυο σκοπούς:

* Άνοιγμα ιστότοπου από κείμενο, σχήμα ή πλαίσιο πολυμέσων.
* Μετάβαση σε άλλη διαφάνεια, για παράδειγμα από έναν πίνακα περιεχομένων.

Το Aspose.Slides για C++ σας επιτρέπει να προσθέσετε αυτούς τους συνδέσμους, να ελέγξετε την εμφάνιση και τον ήχο τους, να ενημερώσετε τις ρυθμίσεις τους και να τους αφαιρέσετε. Τα παραδείγματα παρακάτω δείχνουν πώς να εργαστείτε με υπερσυνδέσμους σε μεμονωμένα στοιχεία και πώς να αποκτήσετε πρόσβαση σε υπερσυνδέσμους σε επίπεδο παρουσίασης, διαφάνειας ή πλαισίου κειμένου.

{{% alert color="info" title="Note" %}}
You can also edit presentations with the [δωρεάν διαδικτυακό πρόγραμμα επεξεργασίας Aspose PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Προσθήκη Υπερσυνδέσμων URL**

Μπορείτε να αντιστοιχίσετε μια διεύθυνση URL ιστότοπου σε κείμενο, σχήμα ή πλαίσιο πολυμέσων. Το στοιχείο στο οποίο αντιστοιχίζετε τον υπερσύνδεσμο καθορίζει την περιοχή κλικ: ένα τμήμα κειμένου συνδέει το επιλεγμένο κείμενο, ενώ ένα σχήμα ή πλαίσιο συνδέει το αντικείμενο της διαφάνειας.

Για παρουσιάσεις που περιέχουν σχετικούς υπερσυνδέσμους, δείτε το [Διαχείριση Βάσης Υπερσυνδέσμου](/slides/el/cpp/presentation-properties/#manage-the-hyperlink-base) για να διαβάσετε, να αλλάξετε ή να διαγράψετε τη βάση σε επίπεδο εγγράφου.

### **Προσθήκη Υπερσυνδέσμων URL σε Κείμενο**

Για να συνδέσετε κείμενο με έναν ιστότοπο, δημιουργήστε ένα [Υπερσύνδεσμο](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlink/) και αντιστοιχίστε το με τη μέθοδο [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/set_hyperlinkclick/) του τμήματος κειμένου, όπως φαίνεται παρακάτω. Μόνο αυτό το τμήμα κειμένου γίνεται κλικ‑δυνατό.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto textShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
textShape->AddTextFrame(u"Aspose: File Format APIs");
auto portionFormat = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");
portionFormat->set_FontHeight(32);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **Προσθήκη Υπερσυνδέσμων URL σε Σχήματα και Πλαίσια Πολυμέσων**

Για να κάνετε ένα σχήμα ή πλαίσιο κλικ‑δυνατό, χρησιμοποιήστε τη μέθοδο [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_hyperlinkclick/). Ο υπερσύνδεσμος ανήκει στο ίδιο το αντικείμενο αντί σε τμήμα κειμένου μέσα σε αυτό.

Η ίδια προσέγγιση εφαρμόζεται σε πλαίσια εικόνων, ήχου και βίντεο: αντιστοιχίστε τον υπερσύνδεσμο στο πλαίσιο και χρησιμοποιήστε το [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) για να προσθέσετε μια υπόδειξη εάν χρειάζεται.

Το παρακάτω παράδειγμα κάνει ένα ορθογώνιο κλικ‑δυνατό:

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **Χρήση Υπερσυνδέσμων για Δημιουργία Πίνακα Περιεχομένων**

Οι εσωτερικοί υπερσύνδεσμοι επιτρέπουν στους αναγνώστες να μεταβούν από έναν πίνακα περιεχομένων σε μια συγκεκριμένη διαφάνεια. Το παρακάτω παράδειγμα χρησιμοποιεί το [SetInternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) για να συνδέσει το κείμενο “Page 2” στην πρώτη διαφάνεια με τη δεύτερη διαφάνεια.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto tableOfContents = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
tableOfContents->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
tableOfContents->get_TextFrame()->get_Paragraphs()->Add(paragraph);

presentation->Save(u"link_to_slide.pptx", SaveFormat::Pptx);
```

## **Μορφοποίηση Υπερσυνδέσμων**

### **Χρώμα**

Η μέθοδος [set_ColorSource](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_colorsource/) του [IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) καθορίζει εάν ένας υπερσύνδεσμος χρησιμοποιεί το χρώμα υπερσυνδέσμου της παρουσίασης ή τη μορφοποίηση του τμήματος κειμένου. Για να εφαρμόσετε προσαρμοσμένο χρώμα κειμένου, επιλέξτε το [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkcolorsource/) και ορίστε το χρώμα γεμίσματος του τμήματος. Αυτή η δυνατότητα εισήχθη στο PowerPoint 2019· παλαιότερες εκδόσεις δεν εφαρμόζουν αυτήν τη ρύθμιση.

Το παρακάτω παράδειγμα προσθέτει δύο υπερσυνδέσμους κειμένου στην ίδια διαφάνεια. Ο πρώτος χρησιμοποιεί κόκκινο γέμισμα κειμένου, ενώ ο δεύτερος διατηρεί το προεπιλεγμένο χρώμα υπερσυνδέσμου.

```cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto coloredShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
coloredShape->AddTextFrame(u"This hyperlink uses a custom color.");
auto coloredPortionFormat = coloredShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
coloredPortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
coloredPortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
coloredPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
coloredPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

auto defaultShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
defaultShape->AddTextFrame(u"This hyperlink uses the default color.");
defaultShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```

### **Ήχος**

Ένας υπερσύνδεσμος μπορεί να αναπαράγει ήχο όταν ενεργοποιηθεί ή να σταματήσει ήχο που ήδη αναπαράγεται. Χρησιμοποιήστε τις παρακάτω μεθόδους για να διαμορφώσετε αυτές τις συμπεριφορές:

- Το [IHyperlink::set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_sound/) καθορίζει το ήχο που συνδέεται με τον υπερσύνδεσμο.
- Το [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) ελέγχει εάν η ενεργοποίηση του υπερσυνδέσμου σταματά τον προηγούμενο ήχο.

#### **Προσθήκη Ήχου σε Υπερσύνδεσμο**

Το παρακάτω παράδειγμα φορτώνει το `sampleaudio.wav` και το συσχετίζει με ένα κουμπί στην πρώτη διαφάνεια. Το κλικ στο κουμπί αναπαράγει τον ήχο και μεταβαίνει στην επόμενη διαφάνεια. Ένα δεύτερο σχήμα σε αυτή τη διαφάνεια σταματά τον προηγούμενο ήχο όταν κλικάρεται, χωρίς να εκτελεί ενέργεια πλοήγησης.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto audioData = System::IO::File::ReadAllBytes(u"sampleaudio.wav");
auto hyperlinkSound = presentation->get_Audios()->AddAudio(audioData);

auto firstSlide = presentation->get_Slide(0);

auto playButton = firstSlide->get_Shapes()->AddAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
playButton->set_HyperlinkClick(Hyperlink::get_NextSlide());

if (!playButton->get_HyperlinkClick()->get_StopSoundOnClick() && playButton->get_HyperlinkClick()->get_Sound() == nullptr)
{
    playButton->get_HyperlinkClick()->set_Sound(hyperlinkSound);
}

auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto stopButton = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
stopButton->set_HyperlinkClick(Hyperlink::get_NoAction());

stopButton->get_HyperlinkClick()->set_StopSoundOnClick(true);

presentation->Save(u"hyperlink-sound.pptx", SaveFormat::Pptx);
```

#### **Εξαγωγή Ήχου από Υπερσύνδεσμο**

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε παραπάνω και διαβάζει τον ήχο υπερσυνδέσμου του πρώτου σχήματος στη μνήμη μέσω των μεθόδων [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_sound/) και [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/).

```cpp
#include <DOM/IAudio.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"hyperlink-sound.pptx");

if (presentation->get_Slides()->get_Count() > 0 && presentation->get_Slide(0)->get_Shapes()->get_Count() > 0)
{
    auto hyperlink = presentation->get_Slide(0)->get_Shape(0)->get_HyperlinkClick();
    auto sound = hyperlink != nullptr ? hyperlink->get_Sound() : nullptr;
    if (sound != nullptr)
    {
        auto audioData = sound->get_BinaryData();
        System::Console::WriteLine(u"Extracted {0} bytes of hyperlink audio.", audioData->get_Length());
    }
    else
    {
        System::Console::WriteLine(u"The first shape has no hyperlink sound.");
    }
}
else
{
    System::Console::WriteLine(u"The presentation has no first slide or shape to inspect.");
}
```

### **Ρυθμίσεις Tooltip και Αλληλεπίδρασης**

Μπορείτε να ενημερώσετε τις παρακάτω ρυθμίσεις του [IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) μέσω αυτών των μεθόδων μετά την αντιστοίχηση ενός υπερσυνδέσμου σε κείμενο ή σχήμα:

- Το [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) ορίζει το κείμενο που μπορεί να εμφανίσει ο θεατής ως υπόδειξη για το σύνδεσμο.
- Το [set_TargetFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_targetframe/) καθορίζει το πλαίσιο‑στόχο μέσα σε ένα γονικό HTML frameset, όταν είναι εφαρμόσιμο.
- Το [set_History](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_history/) ελέγχει αν η ενεργοποίηση του συνδέσμου προσθέτει τον προορισμό του στη λίστα των προβεβλημένων υπερσυνδέσμων.
- Το [set_HighlightClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_highlightclick/) ελέγχει αν ο υπερσύνδεσμος επισημαίνεται όταν κλικάρεται.

## **Αφαίρεση Υπερσυνδέσμων από Παρουσιάσεις**

Χρησιμοποιήστε το [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) για να συλλέξετε τα containers υπερσυνδέσμων, συμπεριλαμβανομένων των συνδέσμων τμημάτων κειμένου, πριν τα αλλάξετε. Το παρακάτω παράδειγμα αφαιρεί και τους δύο τύπους ενεργοποίησης από την πρώτη διαφάνεια. Για να αφαιρέσετε μόνο έναν τύπο, καλέστε μόνο το [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) ή το [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); η αφαίρεση μιας ενέργειας κλικ δεν αφαιρεί την αντίστοιχη ενέργεια mouse‑over.

```cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

if (presentation->get_Slides()->get_Count() > 0)
{
    auto containers = presentation->get_Slide(0)->get_HyperlinkQueries()->GetAnyHyperlinks();
    for (const auto& container : containers)
    {
        container->get_HyperlinkManager()->RemoveHyperlinkClick();
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
    presentation->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"The presentation has no slides to process.");
}
```

Για αδιάκοπη αφαίρεση, το [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) αφαιρεί και τους δύο τύπους ενεργοποίησης στο επιλεγμένο εύρος με μία κλήση. Για επιλεκτικό καθαρισμό και κάλυψη των master, layouts και σημειώσεων, δείτε το [Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσμων](#report-sanitize-and-verify-hyperlinks).

## **Δημιουργία Πλήρους Καταλογισμού Υπερσυνδέσμων**

Πριν τη διανομή μιας παρουσίασης, καταγράψτε τις διαδραστικές της ενέργειες καθώς και τους ιστότοπους συνδέσμους. Το [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) επιστρέφει αντικείμενα [IHyperlinkContainer](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/), όχι μια επίπεδη λίστα συμβολοσειρών URL. Εξετάστε τόσο το [get_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) όσο και το [get_HyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) σε κάθε container. Είναι ανεξάρτητα: το ίδιο container μπορεί να εκθέτει και τις δύο ενέργειες, έτσι μια πλήρης αναφορά απαιτεί έως δύο σειρές ανά container.

Η σάρωση μόνο των υπερσυνδέσμων σε επίπεδο σχήματος μπορεί να παραλείψει συνδέσμους που είναι προσαρτημένοι σε τμήματα κειμένου. Αντ' αυτού ερωτήστε το κατάλληλο εύρος και διατηρήστε τα επιστρεφόμενα containers ώστε να μπορείτε αργότερα να ενημερώσετε ή να αφαιρέσετε τις ενέργειές τους.

### **Ερώτηση για Εύρη Παρουσίασης, Διαφάνειας και Πλαισίου‑Κειμένου**

Η διεπαφή [IHyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/) είναι διαθέσιμη μέσω των [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/), και [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_hyperlinkqueries/). Κάθε εύρος υποστηρίζει τις ίδιες ερωτήσεις:

- Το [GetHyperlinkClicks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) επιστρέφει containers με ενέργεια κλικ.
- Το [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) επιστρέφει containers με ενέργεια mouse‑over.
- Το [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) επιστρέφει containers με είτε ή και τις δύο ενέργειες.

Το παρακάτω παράδειγμα δημιουργεί το `hyperlink-audit-input.pptx` με έναν εξωτερικό σύνδεσμο κλικ, έναν σύνδεσμο αρχείου mouse‑over, εσωτερική πλοήγηση διαφάνειας, έναν σύνδεσμο κειμένου mouse‑over και μια ενέργεια μακροεντολής. Δεν εκτελεί καμία από αυτές τις ενέργειες. Οι ίδιες τρεις ερωτήσεις λειτουργούν σε κάθε εύρος· οι μετρήσεις περιγράφουν containers, όχι συνολικούς αριθμούς ενεργειών. Το εύρος πλαισίου‑κειμένου εξαιρεί τους δικούς του συνδέσμους του περιβάλλοντος σχήματος.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto printCounts = [](System::String scope, System::SharedPtr<IHyperlinkQueries> queries)
{
    auto clickContainers = queries->GetHyperlinkClicks();
    auto mouseOverContainers = queries->GetHyperlinkMouseOvers();
    auto allContainers = queries->GetAnyHyperlinks();
    System::Console::WriteLine(u"{0}: click={1}, mouse-over={2}, any={3}", scope, clickContainers->get_Count(), mouseOverContainers->get_Count(), allContainers->get_Count());
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddEmptySlide(slide->get_LayoutSlide());
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
shape->get_TextFrame()->set_Text(u"Click the text to go to slide 2");
shape->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://example.com/");
shape->get_HyperlinkClick()->set_Tooltip(u"Public website");
shape->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"file:///C:/private/report.xlsx");

auto portionFormat = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->get_HyperlinkManager()->SetInternalHyperlinkClick(destination);
portionFormat->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"https://example.com/help");
auto macroButton = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
macroButton->get_HyperlinkManager()->SetMacroHyperlinkClick(u"ReviewPresentation");

printCounts(u"Presentation", presentation->get_HyperlinkQueries());
printCounts(u"Slide 1", slide->get_HyperlinkQueries());
printCounts(u"Text frame", shape->get_TextFrame()->get_HyperlinkQueries());
presentation->Save(u"hyperlink-audit-input.pptx", SaveFormat::Pptx);
```

Για αυτό το παράδειγμα, οι ερωτήσεις παρουσίασης και διαφάνειας αναφέρουν τρία containers κλικ, δύο containers mouse‑over και τρία containers με είτε ενέργεια. Η ερώτηση πλαισίου‑κειμένου αναφέρει ένα container σε κάθε κατηγορία.

### **Κατηγοριοποίηση Ενεργειών και Προορισμών**

Χρησιμοποιήστε το [IHyperlink::get_ActionType](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_actiontype/) για να ερμηνεύσετε μια ενέργεια πριν ερμηνεύσετε τον προορισμό της. Οι τιμές του [HyperlinkActionType](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkactiontype/) καλύπτουν περισσότερα από πλοήγηση στον ιστό:

| Τιμές | Σημασία για έλεγχο |
| --- | --- |
| `Hyperlink` | Εξωτερικός υπερσύνδεσμος· ελέγξτε το URL και το σχήμα του. |
| `JumpSpecificSlide` | Εσωτερική πλοήγηση σε συγκεκριμένη διαφάνεια. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ενσωματωμένη πλοήγηση παρουσίασης, επιλύεται σε πλαίσιο παρουσίασης. |
| `JumpEndShow`, `StartCustomSlideShow` | Τερματισμός τρέχουσας παρουσίασης ή έναρξη προσαρμοσμένης παρουσίασης. |
| `StartMacro` | Εκτέλεση μακροεντολής. |
| `StartProgram` | Εκκίνηση προγράμματος. |
| `OpenFile`, `OpenPresentation` | Άνοιγμα αρχείου ή άλλης παρουσίασης· εξετάστε ξεχωριστά από τις διευθύνσεις URL ιστού. |
| `StartStopMedia` | Έναρξη ή τερματισμός αναπαραγωγής πολυμέσων. |
| `NoAction`, `Unknown` | Καμία ενέργεια πλοήγησης ή μη αναγνωρισμένη ενέργεια που απαιτεί έλεγχο. |

Διαβάστε εξωτερικούς προορισμούς από το [get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) και συγκεκριμένους εσωτερικούς προορισμούς από το [get_TargetSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_targetslide/). Οι εσωτερικές ενέργειες και οι ενσωματωμένες εντολές μπορεί να μην έχουν εξωτερικό URL· ένα κενό URL δεν σημαίνει ότι το container δεν έχει ενέργεια. Διατηρήστε το [get_ExternalUrlOriginal](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) όταν διαφέρει από το κανονικοποιημένο URL, και συμπεριλάβετε το tooltip που επιστρέφεται από το [get_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_tooltip/) όταν είναι διαθέσιμο.

### **Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσμων**

Το παρακάτω παράδειγμα C++ διαβάζει μια υπάρχουσα παρουσίαση (χρησιμοποιήστε το αρχείο που δημιουργήθηκε παραπάνω), γράφει το `hyperlink-audit.json`, εφαρμόζει μια πολιτική, αποθηκεύει το `hyperlink-sanitized.pptx` και το ανοίγει ξανά για να ελέγξει ξανά και τους δύο τύπους ενεργοποίησης. Συλλέγει containers πριν τα αλλάξει και χρησιμοποιεί ταυτοποίηση δεικτών για να αποφύγει την επεξεργασία του ίδιου container δύο φορές. Οι ερωτήσεις παρουσίασης καλύπτουν τις συνηθισμένες διαφάνειες· για ενδεχόμενο καταλογισμό πακέτου, ερωτά επίσης ρητά τους master, τα layouts, τις σημειώσεις και τους master σημειώσεων και διανομής όταν υπάρχουν.

Η αναφορά καταγράφει έναν δείκτη διαφάνειας με βάση το 1 και το [get_SlideId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideid/) όπου είναι διαθέσιμο. Το [ISlideComponent::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/islidecomponent/get_slide/) παρέχει τη διαφάνεια ιδιοκτήτη για υποστηριζόμενα containers. Οι master, τα layouts και οι σημειώσεις δεν έχουν συνηθισμένο δείκτη διαφάνειας και ταυτοποιούνται με το εύρος τους. Τα containers σχήματος και τα containers μορφοποίησης τμήματος κειμένου επισημαίνονται ξεχωριστά· άλλοι τύποι containers διατηρούν το όνομα τύπου χρόνου εκτέλεσης. Κάθε container λαμβάνει ένα τοπικό ID αναφοράς ώστε οι δύο ενέργειές του να μπορούν να συσχετιστούν.

Αυτή η σκόπιμα περιοριστική πολιτική εφαρμογής επιτρέπει μόνο απόλυτα HTTPS URLs και έγκυρους εσωτερικούς προορισμούς διαφάνειας. Απορρίπτει μακροεντολές, προγράμματα, ενέργειες αρχείων, άλλες ενέργειες παρουσίασης, άγνωστες ενέργειες και άλλα σχήματα URL. Αυτές οι απορρίψεις είναι αποφάσεις πολιτικής, όχι απόφαση ασφαλείας του Aspose.Slides. Το μόνο HTTPS δεν εγγυάται εμπιστοσύνη· προσθέστε λίστες επιτρεπόμενων κεντρικών υπολογιστών και άλλους ελέγχους για την εφαρμογή σας. Ελέγχονται τόσο τα αρχικά όσο και τα κανονικοποιημένα εξωτερικά URLs. Το παράδειγμα ελέγχει μεταδεδομένα χωρίς να ακολουθεί συνδέσμους ή να εκτελεί ενέργειες.

Για αντιμετώπιση, το container's [get_HyperlinkManager](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) υποστηρίζει το [SetExternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), το [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) και το [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Εδώ, οι απαγορευμένοι εξωτερικοί σύνδεσμοι κλικ αντικαθίστανται με μια σταθερή σελίδα προσγείωσης HTTPS· οι άλλοι απαγορευμένοι κλικ και οι απαγορευμένες ενέργειες mouse‑over αφαιρούνται ανεξάρτητα. Ορίστε το `replaceExternalClicks` σε `false` για να αφαιρέσετε όλες τις παραβιάσεις πολιτικής αντ' αυτού. Επιλέξτε μια σελίδα αντικατάστασης που ανήκει στην εφαρμογή πριν από την ανάπτυξη.

Η σημαία εξαγωγής της αναφοράς χρησιμοποιεί μια συντηρητική πολιτική ελέγχου PDF: σημαδεύει ενέργειες mouse‑over και οτιδήποτε άλλο εκτός από εξωτερικό σύνδεσμο ή συγκεκριμένο άλμα διαφάνειας ως πιθανώς μη υποστηριζόμενο. Είναι μια υπόδειξη ελέγχου, όχι δοκιμή δυνατότητας ή εγγύηση ότι οι μη επισημασμένοι σύνδεσμοι θα παραμείνουν στην εξαγωγή. Τα υποστηριζόμενα [PDF](/slides/el/cpp/convert-powerpoint-to-pdf/) και [HTML](/slides/el/cpp/convert-powerpoint-to-html/) εξαγόμενα μπορεί να διατηρήσουν τους υπερσυνδέσμους, ανάλογα με την ενέργεια, τις επιλογές εξαγωγής και τον προγράμματος προβολής. Οι ραστερ [εικόνες](/slides/el/cpp/convert-powerpoint-to-png/) και [βίντεο](/slides/el/cpp/convert-powerpoint-to-video/) δεν μπορούν να διατηρήσουν διαδραστικούς υπερσυνδέσμους· σημαδεύστε κάθε ενέργεια όταν ελέγχετε αυτά τα αποτελέσματα.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkActionType.h>
#include <DOM/IBaseSlide.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPresentation.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideComponent.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/uri.h>
#include <system/environment.h>
#include <fstream>
#include <sstream>
#include <iomanip>
#include <vector>
#include <unordered_set>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const auto replaceExternalClicks = true;
const System::String replacementUrl = u"https://example.com/blocked-link";
auto presentation = System::MakeObject<Presentation>(u"hyperlink-audit-input.pptx");

auto collectContainers = [](System::SharedPtr<IPresentation> source)
{
    std::vector<System::SharedPtr<IHyperlinkContainer>> found;
    std::unordered_set<IHyperlinkContainer*> seen;
    auto addQueries = [&](System::SharedPtr<IHyperlinkQueries> queries)
    {
        auto containers = queries->GetAnyHyperlinks();
        for (const auto& container : containers)
        {
            if (seen.insert(container.get()).second) found.push_back(container);
        }
    };
    auto addScope = [&](System::SharedPtr<IBaseSlide> slide)
    {
        if (slide != nullptr) addQueries(slide->get_HyperlinkQueries());
    };
    addQueries(source->get_HyperlinkQueries());
    for (const auto& master : source->get_Masters()) addScope(master);
    for (const auto& layout : source->get_LayoutSlides()) addScope(layout);
    for (const auto& slide : source->get_Slides()) addScope(slide->get_NotesSlideManager()->get_NotesSlide());
    addScope(source->get_MasterNotesSlideManager()->get_MasterNotesSlide());
    addScope(source->get_MasterHandoutSlideManager()->get_MasterHandoutSlide());
    return found;
};

auto isHttps = [](System::String value)
{
    System::SharedPtr<System::Uri> uri;
    return System::Uri::TryCreate(value, System::UriKind::Absolute, uri) && uri->get_Scheme() == System::Uri::UriSchemeHttps;
};
auto policyViolation = [&](System::SharedPtr<IHyperlink> link) -> System::String
{
    if (link == nullptr) return u"";
    if (link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide)
    {
        return link->get_TargetSlide() == nullptr ? u"Missing target slide" : u"";
    }
    if (link->get_ActionType() != HyperlinkActionType::Hyperlink) return u"Action is not allowed";
    if (!isHttps(link->get_ExternalUrl())) return u"Normalized URL is not absolute HTTPS";
    auto original = link->get_ExternalUrlOriginal();
    if (!original.IsNullOrEmpty() && !isHttps(original)) return u"Original URL is not absolute HTTPS";
    return u"";
};
auto slideIndex = [&](System::SharedPtr<IBaseSlide> slide)
{
    for (auto index = 0; index < presentation->get_Slides()->get_Count(); index++)
    {
        if (presentation->get_Slide(index) == slide) return index + 1;
    }
    return 0;
};
auto jsonString = [](System::String value)
{
    std::ostringstream escaped;
    escaped << '"';
    for (unsigned char character : value.ToUtf8String())
    {
        if (character == '"' || character == '\\') escaped << '\\' << character;
        else if (character < 0x20) escaped << "\\u" << std::hex << std::setw(4) << std::setfill('0') << static_cast<int>(character);
        else escaped << character;
    }
    escaped << '"';
    return escaped.str();
};
auto containers = collectContainers(presentation);
std::ofstream report("hyperlink-audit.json", std::ios::binary);
if (!report)
{
    System::Console::WriteLine(u"Cannot open the audit report for writing.");
    System::Environment::set_ExitCode(1);
    return;
}
auto rowCount = 0;
report << "[\n";
auto addRow = [&](System::SharedPtr<IHyperlink> link, System::String activation, System::SharedPtr<IHyperlinkContainer> container, size_t containerId)
{
    if (link == nullptr) return;
    auto component = System::AsCast<ISlideComponent>(container);
    auto ownerSlide = component != nullptr ? component->get_Slide() : nullptr;
    auto targetSlide = link->get_TargetSlide();
    auto violation = policyViolation(link);
    auto shape = System::AsCast<IShape>(container);
    auto portionFormat = System::AsCast<IPortionFormat>(container);
    auto ownerType = shape != nullptr ? System::String(u"Shape") : portionFormat != nullptr ? System::String(u"Text portion") : container->GetType().get_Name();
    auto ordinaryAction = link->get_ActionType() == HyperlinkActionType::Hyperlink || link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide;
    auto ownerIndex = slideIndex(ownerSlide);
    auto targetIndex = slideIndex(targetSlide);
    if (rowCount++ != 0) report << ",\n";
    report << "  {\"ContainerId\":" << containerId;
    report << ",\"SlideIndex\":" << (ownerIndex != 0 ? std::to_string(ownerIndex) : "null");
    report << ",\"SlideId\":" << (ownerSlide != nullptr ? std::to_string(ownerSlide->get_SlideId()) : "null");
    report << ",\"Scope\":" << (ownerSlide != nullptr ? jsonString(ownerSlide->GetType().get_Name()) : "null");
    report << ",\"OwnerType\":" << jsonString(ownerType);
    report << ",\"Activation\":" << jsonString(activation);
    report << ",\"ActionType\":" << jsonString(System::ObjectExt::ToString(link->get_ActionType()));
    report << ",\"ExternalUrl\":" << jsonString(link->get_ExternalUrl());
    report << ",\"TargetSlideIndex\":" << (targetIndex != 0 ? std::to_string(targetIndex) : "null");
    report << ",\"TargetSlideId\":" << (targetSlide != nullptr ? std::to_string(targetSlide->get_SlideId()) : "null");
    report << ",\"Tooltip\":" << jsonString(link->get_Tooltip());
    report << ",\"OriginalExternalUrl\":" << (link->get_ExternalUrlOriginal() != link->get_ExternalUrl() ? jsonString(link->get_ExternalUrlOriginal()) : "null");
    report << ",\"PotentiallyUnsafe\":" << (!violation.IsNullOrEmpty() ? "true" : "false");
    report << ",\"PolicyViolation\":" << (!violation.IsNullOrEmpty() ? jsonString(violation) : "null");
    report << ",\"TargetExport\":\"PDF\",\"PotentiallyUnsupportedByExport\":" << (activation == u"mouse-over" || !ordinaryAction ? "true" : "false") << "}";
};
for (auto index = size_t{0}; index < containers.size(); index++)
{
    auto container = containers[index];
    addRow(container->get_HyperlinkClick(), u"click", container, index + 1);
    addRow(container->get_HyperlinkMouseOver(), u"mouse-over", container, index + 1);
}
report << "\n]\n";
report.close();
if (!report)
{
    System::Console::WriteLine(u"The audit report could not be written completely.");
    System::Environment::set_ExitCode(1);
    return;
}

for (const auto& container : containers)
{
    auto click = container->get_HyperlinkClick();
    if (!policyViolation(click).IsNullOrEmpty())
    {
        if (replaceExternalClicks && click->get_ActionType() == HyperlinkActionType::Hyperlink)
        {
            container->get_HyperlinkManager()->SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container->get_HyperlinkManager()->RemoveHyperlinkClick();
        }
    }
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty())
    {
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
}
presentation->Save(u"hyperlink-sanitized.pptx", SaveFormat::Pptx);
auto reopened = System::MakeObject<Presentation>(u"hyperlink-sanitized.pptx");
auto remainingContainers = collectContainers(reopened);
auto violations = 0;
for (const auto& container : remainingContainers)
{
    if (!policyViolation(container->get_HyperlinkClick()).IsNullOrEmpty()) violations++;
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty()) violations++;
}
System::Console::WriteLine(u"Audit rows: {0}; prohibited actions after reopening: {1}", rowCount, violations);
if (violations != 0)
{
    System::Console::WriteLine(u"Verification failed: do not distribute the saved presentation.");
    System::Environment::set_ExitCode(1);
}
```

Με το παραπάνω εισροή, η αναφορά περιέχει πέντε σειρές ενεργειών. Ο σύνδεσμος αρχείου mouse‑over και το κλικ μακροεντολής αφαιρούνται, ενώ οι HTTPS σύνδεσμοι και η εσωτερική πλοήγηση διαφάνειας παραμένουν. Η επαλήθευση εμφανίζει μηδέν απαγορευμένες ενέργειες. Μια εισροή με απαγορευμένο εξωτερικό URL κλικ επίσης ενεργοποιεί το κλάδο αντικατάστασης. Ένα container με επιτρεπόμενο κλικ και απαγορευμένο mouse‑over διατηρεί την ενέργεια κλικ της.

Αυτός ο επιλεκτικός καθαρισμός διαφέρει από το [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), το οποίο αφαιρεί και τους δύο τύπους ενεργοποίησης σε όλο το επιλεγμένο εύρος ανεξάρτητα από την πολιτική. Η επαλήθευση εδώ ελέγχει μόνο τις ενέργειες υπερσυνδέσμων· δεν αφαιρεί ενσωματωμένα VBA projects, αντικείμενα OLE ή άλλο ενεργό περιεχόμενο, και δεν επαληθεύει ένα εξαγόμενο PDF ή HTML αρχείο.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να συνδέσω σε ενότητα ή στην πρώτη διαφάνειά της;**

Οι ενότητες στο PowerPoint ομαδοποιούν διαφάνειες, αλλά ένας εσωτερικός υπερσύνδεσμος στοχεύει σε μια μεμονωμένη διαφάνεια. Για να δημιουργήσετε πλοήγηση σε ενότητα, συνδέστε τη πρώτη διαφάνεια της ενότητας.

**Μπορώ να συνδέσω έναν υπερσύνδεσμο σε στοιχεία master διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία master διαφάνειας και layout υποστηρίζουν υπερσυνδέσμους. Οι σύνδεσμοι σε αυτά τα στοιχεία είναι διαθέσιμοι κατά τη διάρκεια της παρουσίασης στις διαφάνειες που χρησιμοποιούν τον αντίστοιχο master ή layout.

**Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;**

Τα υποστηριζόμενα PDF και HTML εξαγόμενα μπορεί να διατηρήσουν τους υπερσυνδέσμους· οι ραστερ εικόνες και τα βίντεο δεν μπορούν. Δείτε τις προϋποθέσεις εξαγωγής στο [Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσμων](#report-sanitize-and-verify-hyperlinks).