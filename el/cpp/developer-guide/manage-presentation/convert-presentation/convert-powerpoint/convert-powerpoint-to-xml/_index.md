---
title: Μετατροπή παρουσιάσεων PowerPoint σε XML σε C++
linktitle: PowerPoint σε XML
type: docs
weight: 145
url: /el/cpp/convert-powerpoint-to-xml/
keywords:
- μετατροπή PowerPoint σε XML
- μετατροπή παρουσίασης σε XML
- PPT σε XML
- PPTX σε XML
- ODP σε XML
- Παρουσίαση PowerPoint XML
- SaveFormat::Xml
- αποθήκευση παρουσίασης ως XML
- εξαγωγή παρουσίασης σε XML
- ροή XML
- C++
- Aspose.Slides
description: "Μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε αρχεία ή ροές PowerPoint XML σε C++ με Aspose.Slides για C++."
---
## **Επισκόπηση**

Το Aspose.Slides for C++ μπορεί να μετατρέπει παρουσιάσεις PowerPoint στη μορφή PowerPoint XML Presentation. Η έξοδος XML είναι χρήσιμη όταν χρειάζεστε μια κειμενική αναπαράσταση για την επιθεώρηση της δομής της παρουσίασης, την αντιμετώπιση προβλημάτων των παραγόμενων εγγράφων, τη σύγκριση εξόδου σε αυτοματοποιημένες δοκιμές ή την ενσωμάτωση σε ροή εργασίας που καταναλώνει XML αντί για πακέτο παρουσίασης.

Χρησιμοποιήστε τη μέθοδο [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) με την τιμή `Xml` από την απαριθμήση [SaveFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveformat/). Μπορείτε να γράψετε το αποτέλεσμα απευθείας σε αρχείο ή σε ροή.

{{% alert color="info" title="Note" %}}
`SaveFormat::Xml` δημιουργεί μια Παρουσίαση PowerPoint XML. Δεν εξάγει τα μεμονωμένα τμήματα Office Open XML που αποθηκεύονται μέσα σε ένα πακέτο PPTX. Αν χρειάζεστε τα ακριβή τμήματα του πακέτου PPTX, όπως `ppt/presentation.xml` ή μεμονωμένα αρχεία XML διαφανειών, εξετάστε το ίδιο το πακέτο PPTX.
{{% /alert %}}

## **Μετατροπή παρουσίασης σε αρχείο XML**

Φορτώστε μια παρουσίαση προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/), και στη συνέχεια περάστε τη διαδρομή εξόδου και το `SaveFormat::Xml` στη μέθοδο [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/). Η προέλευση μπορεί να είναι οποιαδήποτε μορφή παρουσίασης που υποστηρίζεται για φόρτωση, όπως PPT, PPTX ή ODP.

Το παρακάτω παράδειγμα μετατρέπει μια παρουσίαση PPTX σε αρχείο XML:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **Γραφή εξόδου XML σε ροή**

Χρησιμοποιήστε την υπερφόρτωση ροής της μεθόδου [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) όταν το XML πρέπει να παραμείνει στη μνήμη ή να περάσει σε άλλο στοιχείο, όπως μια υπηρεσία web, παροχέα αποθήκευσης ή δεξαμενή επεξεργασίας XML. Το παρακάτω παράδειγμα γράφει το αποτέλεσμα σε ένα [MemoryStream](https://reference.aspose.com/slides/el/cpp/system.io/memorystream/) και το επαναφέρει στην αρχή για μεταγενέστερη ανάγνωση:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// Περνάτε το xmlStream στο επόμενο στοιχείο της ροής εργασίας.
```

## **Σύγκριση XML με μορφές παρουσίασης και εξαγωγής**

Επιλέξτε τη μορφή εξόδου ανάλογα με το πώς θα χρησιμοποιηθεί το αποτέλεσμα:

| Μορφή | Αποτέλεσμα | Τυπική χρήση |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Μια Παρουσίαση PowerPoint XML | Επιθεώρηση δομής, αντιμετώπιση προβλημάτων, σύγκριση παραγόμενης εξόδου και ενσωμάτωση βάσει XML |
| PPT (`.ppt`) | Ένα παλαιο δυαδικό αρχείο παρουσίασης | Συμβατότητα με παλιές ροές εργασίας PowerPoint |
| PPTX (`.pptx`) | Ένα πακέτο Office Open XML που περιέχει πολλά τμήματα | Κανονική επεξεργασία PowerPoint και ανταλλαγή παρουσιάσεων |
| PDF ή TIFF | Σελίδες σταθερού layout ή εικόνα πολλαπλών σελίδων | Προβολή, εκτύπωση και αρχειοθέτηση |
| PNG, JPEG ή SVG | Μια αποτυπωμένη αναπαράσταση μιας μεμονωμένης διαφάνειας | Μικρογραφίες, προεπισκοπήσεις και εικόνες περιουσιακών στοιχείων |
| HTML ή HTML5 | Παρουσίαση προσανατολισμένη στο web | Προβολή σε πρόγραμμα περιήγησης και δημοσίευση web |

Σε αντίθεση με τα PPT και PPTX, η έξοδος XML προορίζεται κυρίως για επιθεώρηση και ροές εργασίας προσανατολισμένες στα δεδομένα. Σε αντίθεση με PDF, TIFF, HTML και μορφές εικόνας διαφανειών, αντιπροσωπεύει δεδομένα παρουσίασης αντί για απόδοση των διαφανειών ως σελίδες ή οπτικά περιουσιακά στοιχεία. Ο πίνακας [υποστηριζόμενων μορφών αρχείων](/slides/el/cpp/supported-file-formats/) αναφέρει την Παρουσίαση PowerPoint XML ως μορφή μόνο αποθήκευσης, επομένως μην το χρησιμοποιείτε όταν μια ροή εργασίας πρέπει να φορτώσει ξανά το εξαγόμενο αρχείο στο Aspose.Slides για συνέχιση επεξεργασίας.

## **Συχνές Ερωτήσεις**

**Είναι το `SaveFormat::Xml` το ίδιο με την αποθήκευση αρχείου PPTX;**

Όχι. Το PPTX είναι ένα πακέτο που περιέχει πολλαπλά τμήματα Office Open XML, ενώ το `SaveFormat::Xml` δημιουργεί ένα αρχείο Παρουσίασης PowerPoint XML.

**Μπορώ να αποθηκεύσω την έξοδο XML χωρίς να δημιουργήσω αρχείο στο δίσκο;**

Ναι. Περάστε μια εγγράψιμη ροή στη μέθοδο [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/). Για παράδειγμα, χρησιμοποιήστε ένα [MemoryStream](https://reference.aspose.com/slides/el/cpp/system.io/memorystream/) για επεξεργασία στη μνήμη.

**Μπορεί το Aspose.Slides να φορτώσει ξανά το εξαγόμενο αρχείο XML;**

Όχι. Η Παρουσίαση PowerPoint XML υποστηρίζεται επί του παρόντος μόνο για αποθήκευση και όχι για φόρτωση. Χρησιμοποιήστε PPTX ή άλλη υποστηριζόμενη μορφή παρουσίασης όταν απαιτείται επαναληπτική επεξεργασία.

**Η μετατροπή XML αποδίδει κάθε διαφάνεια ως σελίδα ή εικόνα;**

Όχι. Η μετατροπή XML γράφει δομημένα δεδομένα παρουσίασης. Χρησιμοποιήστε PDF ή TIFF για έξοδο προσανατολισμένο σε σελίδες ή PNG, JPEG και SVG για εικόνες μεμονωμένων διαφανειών.