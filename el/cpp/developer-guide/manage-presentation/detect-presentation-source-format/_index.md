---
title: Καθορίστε την Αρχική Μορφή Παρουσίασης σε C++
linktitle: Μορφή Πηγής
type: docs
weight: 35
url: /el/cpp/detect-presentation-source-format/
keywords:
- μορφή πηγής
- ανίχνευση μορφής παρουσίασης
- PowerPoint
- OpenDocument
- παρουσίαση
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Διαβάστε την αρχική μορφή μιας φορτωμένης παρουσίασης σε C++ με το Aspose.Slides για C++, συγκρίνετε τα APIs ανίχνευσης και διαχειριστείτε αρχεία, ροές και παλαιές μορφές."
---
## **Επισκόπηση**

Αφού φορτώσετε μια παρουσίαση, καλέστε [Presentation::get_SourceFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_sourceformat/) για να προσδιορίσετε την αρχική της μορφή. Η μέθοδος είναι επίσης διαθέσιμη μέσω του [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/get_sourceformat/). Χρησιμοποιήστε την όταν η επακόλουθη επεξεργασία εξαρτάται από τη μορφή από την οποία φορτώθηκε η τρέχουσα παρουσίαση.

Η πηγαία μορφή είναι διαφορετική από το [SaveFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveformat/) που έχει επιλεχθεί για ένα αρχείο εξόδου. Η αποθήκευση σε άλλη μορφή δεν αλλάζει τη πηγαία μορφή της υπάρχουσας παρουσίασης.

## **Ανάγνωση του Source Format ενός Αρχείου**

Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο `sample.pptx`. Φορτώνει το αρχείο και επιλέγει μια πολιτική επεξεργασίας εφαρμογής χρησιμοποιώντας το [Presentation::get_SourceFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_sourceformat/), αντί του ονόματος αρχείου. Αλλάξτε τη διαδρομή εισόδου για να δοκιμάσετε άλλες μορφές. Το παράδειγμα εκτυπώνει την επιλεγμένη πολιτική· αντικαταστήστε τα μηνύματα με τη λογική της εφαρμογής σας.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **Αναγνώριση των Υποστηριζόμενων Τιμών**

Η απαρίθμηση [SourceFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/sourceformat/) διακρίνει τις παρακάτω μορφές παρουσιάσεων. Οι παρακάτω επεκτάσεις είναι συμβατικές, όχι ανακατασκευή του αρχικού ονόματος αρχείου.

| Τιμή SourceFormat | Επέκταση | Μορφή |
| --- | --- | --- |
| `Ppt` | `.ppt` | Παρουσίαση PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Παρουσίαση Office Open XML |
| `Pptm` | `.pptm` | Παρουσίαση Office Open XML με ενεργές μακροεντολές |
| `Pps` | `.pps` | Επίδειξη διαφανειών PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Επίδειξη διαφανειών Office Open XML |
| `Ppsm` | `.ppsm` | Επίδειξη διαφανειών Office Open XML με ενεργές μακροεντολές |
| `Pot` | `.pot` | Πρότυπο PowerPoint 97–2003 |
| `Potx` | `.potx` | Πρότυπο Office Open XML |
| `Potm` | `.potm` | Πρότυπο Office Open XML με ενεργές μακροεντολές |
| `Odp` | `.odp` | Παρουσίαση OpenDocument |
| `Otp` | `.otp` | Πρότυπο παρουσίασης OpenDocument |
| `Fodp` | `.fodp` | Παρέμβαση Flat XML ODF παρουσίασης |
| `Xml` | `.xml` | Παρουσίαση PowerPoint XML |

## **Ανάγνωση του Source Format από Ροή**

Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο `sample.pps`. Η ανάγνωση των byte του σε μια ροή μνήμης μοντελοποιεί είσοδο που λήφθηκε χωρίς όνομα αρχείου, όπως μια τιμή βάσης δεδομένων ή ένας ανεβασμένος πίνακας byte. Ο κατασκευαστής [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) δέχεται μόνο τη ροή.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

Τα PPT, PPS και POT χρησιμοποιούν την ίδια υποκείμενη δυαδική μορφή. Κατά τη φόρτωση με διαδρομή αρχείου, η επέκταση μπορεί να βοηθήσει στον διαχωρισμό μιας παρουσίασης διαφάνειας ή προτύπου. Χωρίς όνομα αρχείου, το περιεχόμενο παλαιών PPS και POT μπορεί να αναφερθεί ως `SourceFormat::Ppt`; το παράδειγμα PPS παραπάνω αναφέρει `Ppt`.

Αν η εφαρμογή σας πρέπει να διατηρήσει αυτή τη διάκριση, κρατήστε το αρχικό όνομα αρχείου ή τα μεταδεδομένα υποτύπου χωριστά. Η επέκταση είναι χρήσιμη υπόδειξη για αυτά τα παλιά υποτύπους, αλλά δεν πρέπει να αποτελεί τη μόνη βάση για την ταυτοποίηση αυθαίρετου περιεχομένου παρουσίασης.

## **Σύγκριση Ανίχνευσης Πριν και Μετά τη Φόρτωση**

Χρησιμοποιήστε το [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentationfactory/getpresentationinfo/) και το [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/get_loadformat/) όταν χρειάζεται να ελέγξετε ένα αρχείο πριν φορτώσετε το πλήρες αντικειμενοστραφές μοντέλο της παρουσίασης. Χρησιμοποιήστε το [Presentation::get_SourceFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_sourceformat/) όταν η παρουσίαση υπάρχει ήδη.

Αυτό το παράδειγμα απαιτεί `sample.pptx` και εκτυπώνει `Pptx` και για τις δύο ελέγχους. Σε παραγωγή, επιλέξτε το API που ταιριάζει στο στάδιο επεξεργασίας· μια παρουσίαση που έχει ήδη φορτωθεί δεν χρειάζεται δεύτερο έλεγχο μόνο για την απόκτηση της πηγαίας μορφής.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

Τα αποτελέσματα έχουν διαφορετικούς τύπους απαρίθμησης: [LoadFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadformat/) και [SourceFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/sourceformat/). Μην τα συγκρίνετε μετατρέποντας τις αριθμητικές τους τιμές ή υποθέτετε ότι κάθε μορφή έχει ταυτόσημα αποτελέσματα ανίχνευσης. Το PowerPoint XML μπορεί να αναφερθεί ως `LoadFormat::Unknown` πριν τη φόρτωση και ως `SourceFormat::Xml` μετά τη φόρτωση.

## **Διατήρηση των Πηγών και των Μορφών Εξόδου Ξεχωριστά**

Αυτό το παράδειγμα απαιτεί `sample.pptx` και γράφει `converted.odp`. Εκτυπώνει `Pptx` τόσο πριν όσο και μετά την αποθήκευση της αρχικής παρουσίασης. Μόνο η νέα παρουσίαση που φορτώθηκε από το αρχείο εξόδου ODP αναφέρει `Odp`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

Μια παρουσίαση που δημιουργείται από το μηδέν με `MakeObject<Presentation>()` αναφέρει `SourceFormat::Pptx`. Δεν υπάρχει αρχείο εισόδου: αυτή είναι η προεπιλεγμένη τιμή για μια νέα παρουσίαση, όχι απόδειξη ότι φορτώθηκε αρχείο PPTX. Παρακολουθείτε εάν η εφαρμογή σας δημιούργησε ή φόρτωσε την παρουσίαση ξεχωριστά εάν αυτή η διάκριση έχει σημασία.

## **Αντιστοίχιση Source Format σε Επέκταση**

Το παρακάτω παράδειγμα απαιτεί `sample.pptx`. Αντιστοιχεί κάθε τρέχουσα υποστηριζόμενη τιμή του [SourceFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/sourceformat/) σε μια συμβατική επέκταση, χωρίς να αναλύει το όνομα αρχείου εισόδου. Η εναλλακτική λύση αποτρέπει την αθόρυβη ανάθεση επέκτασης σε μη αναγνωρισμένη τιμή.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

Αυτή η αντιστοίχηση δεν μετατρέπει αρχείο ούτε επαναφέρει ένα παλιό υποτύπο PPS/POT που χάθηκε κατά τη φόρτωση της ροής. Για πραγματική αποθήκευση, επιλέξτε ένα [SaveFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveformat/) ρητά, ή χρησιμοποιήστε τη μετατροπή που φαίνεται στην ενότητα [Save Presentations in Their Original Format](/slides/el/cpp/save-presentation/#save-presentations-in-their-original-format).

## **Επαλήθευση Μορφών με Αποθήκευση και Επαναφόρτωση**

Αυτό το αυτόνομο παράδειγμα δημιουργεί μια παρουσίαση και γράφει τρία αρχεία στον τρέχοντα φάκελο εργασίας, αντικαθιστώντας αρχεία με τα ίδια ονόματα. Επαναφορά κάθε εξόδου τόσο με διαδρομή όσο και μέσω ροής μνήμης. Για PPTX και ODP, και οι δύο διαδρομές αναφέρουν τη αποθηκευμένη μορφή. Για PPS, η φόρτωση με διαδρομή αναφέρει `Pps`, ενώ η φόρτωση των ίδιων byte χωρίς όνομα αρχείου αναφέρει `Ppt`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

| Αποθηκευμένη μορφή | SourceFormat από διαδρομή αρχείου | SourceFormat από ροή χωρίς όνομα |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` αντίστοιχα | Ίδιο με τη διαδρομή |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` αντίστοιχα | Ίδιο με τη διαδρομή |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` αντίστοιχα | Ίδιο με τη διαδρομή |
| ODP, OTP | `Odp`, `Otp` αντίστοιχα | Ίδιο με τη διαδρομή |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Τα παλαιά περιεχόμενα PPS/POT κανονικοποιούνται σε `Ppt` για ροές χωρίς όνομα. Ο πίνακας περιγράφει την ταυτοποίηση μορφής, όχι τη διατήρηση κάθε δυνατότητας παρουσίασης κατά τη μετατροπή.

## **Συχνές Ερωτήσεις**

**Αλλάζει η αποθήκευση σε ODP τη πηγαία μορφή μιας παρουσίασης που φορτώθηκε από PPTX;**

Όχι. Η υπάρχουσα παρουσίαση εξακολουθεί να αναφέρει `Pptx`. Μια παρουσίαση που φορτώθηκε από το αποθηκευμένο αρχείο ODP αναφέρει `Odp`.

**Μπορεί μια ροή πάντα να διακρίνει μια παλιά παρουσίαση, παρουσίαση διαφάνειας και πρότυπο;**

Όχι. Τα PPT, PPS και POT μοιράζονται την ίδια δυαδική μορφή. Διατηρήστε το όνομα αρχείου ή τα μεταδεδομένα υποτύπου χωριστά όταν απαιτείται αυτή η διάκριση.

**Ποιο API πρέπει να χρησιμοποιήσω αν η παρουσίαση είναι ήδη φορτωμένη;**

Διαβάστε το [Presentation::get_SourceFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_sourceformat/). Χρησιμοποιήστε το [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentationfactory/getpresentationinfo/) για έλεγχο πριν τη φόρτωση.