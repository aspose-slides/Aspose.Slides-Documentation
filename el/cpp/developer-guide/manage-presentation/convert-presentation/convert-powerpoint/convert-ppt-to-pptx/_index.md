---
title: Μετατροπή PPT σε PPTX σε C++
linktitle: PPT σε PPTX
type: docs
weight: 20
url: /el/cpp/convert-ppt-to-pptx/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- PPT σε PPTX
- αποθήκευση PPT ως PPTX
- εξαγωγή PPT σε PPTX
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μετατροπή παλαιών αρχείων PPT σε PPTX σε C++ με Aspose.Slides. Περιλαμβάνει παραδείγματα C++ για μετατροπή ενός αρχείου ή δέσμης, διαχείριση σφαλμάτων και σημειώσεις ακρίβειας."
---
## **Επισκόπηση**

Το PPT είναι η παλαιότερη δυαδική μορφή PowerPoint, ενώ το PPTX είναι η νεότερη μορφή Open XML. Το Aspose.Slides για C++ μπορεί να φορτώσει ένα αρχείο PPT και να το αποθηκεύσει ως PPTX χωρίς το Microsoft PowerPoint. Αυτό το άρθρο δείχνει πώς να μετατρέψετε ένα αρχείο ή έναν φάκελο αρχείων και εξηγεί τι πρέπει να ελέγξετε μετά τη μετατροπή.

## **Μετατροπή αρχείου PPT σε PPTX**

Φορτώστε το αρχείο προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/), έπειτα καλέστε το [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) με το [SaveFormat::Pptx](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveformat/). Απελευθερώστε την παρουσίαση όταν δεν τη χρειάζεστε πια για να απελευθερώσετε τους πόρους της.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η επέκταση αρχείου δεν επιλέγει από μόνη της τη μορφή εξόδου· το όρισμα [SaveFormat::Pptx](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveformat/) το κάνει. Διατηρήστε διαφορετικές τις διαδρομές εισόδου και εξόδου εάν χρειάζεται να διατηρήσετε το αρχικό αρχείο PPT.

## **Μετατροπή πολλαπλών αρχείων PPT**

Το παρακάτω παράδειγμα μετατρέπει κάθε αρχείο `.ppt` σε έναν φάκελο. Κάθε αρχείο επεξεργάζεται ανεξάρτητα, ώστε μια αποτυχημένη μετατροπή να μην σταματήσει το υπόλοιπο σύνολο.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

Για παραγωγικά φορτία εργασίας, καταγράψτε την πλήρη εξαίρεση, αποφασίστε αν ένα υπάρχον αρχείο εξόδου μπορεί να αντικατασταθεί και γράψτε τα ονόματα των αποτυχημένων αρχείων σε μια ουρά επανάληψης ή ελέγχου. Κατεστραμμένα αρχεία, αρχεία προστατευμένα με κωδικό πρόσβασης που ανοίγονται χωρίς τον απαιτούμενο κωδικό, μη προσβάσιμες διαδρομές και μη υποστηριζόμενο περιεχόμενο μπορούν όλα να προκαλέσουν αποτυχία μετατροπής. Δείτε το [Password-Protected Presentations](/cpp/password-protected-presentation/) για τη φόρτωση κρυπτογραφημένων αρχείων.

## **Ακρίβεια και Παλαιές Λειτουργίες**

Η μετατροπή συνήθως διατηρεί τις διαφάνειες, τα master, τις διατάξεις, το κείμενο, τα σχήματα, τις εικόνες, τους πίνακες και τα διαγράμματα. Ωστόσο, τα PPT και PPTX δεν αντιπροσωπεύουν κάθε λειτουργία με ακριβώς τον ίδιο τρόπο. Μια παλαιότερη λειτουργία που δεν έχει ισοδύναμο στο PPTX ή δεν υποστηρίζεται από τη βιβλιοθήκη μπορεί να ομαλοποιηθεί, να παραλειφθεί ή να εμφανιστεί διαφορετικά.

Ελέγξτε το μετατρεπόμενο αρχείο όταν περιέχει κινούμενα σχέδια, μεταβάσεις, ενσωματωμένα ή συνδεδεμένα αντικείμενα OLE, ελεγκτές ActiveX, ενσωματωμένα πολυμέσα, σπάνιες γραμματοσειρές ή μακροεντολές VBA. Ένα απλό αρχείο PPTX δεν είναι μορφή με υποστήριξη μακροεντολών, επομένως χρησιμοποιήστε μια κατάλληλη ροή εργασίας με υποστήριξη μακροεντολών όταν το VBA πρέπει να παραμείνει διαθέσιμο. Επίσης, βεβαιωθείτε ότι οι απαιτούμενες γραμματοσειρές και οι εξωτερικοί πόροι είναι παρόντες στο περιβάλλον όπου η μετατρεπόμενη παρουσίαση θα ανοίξει ή θα αποδοθεί.

Για σημαντικά έγγραφα, ανοίξτε ξανά το παραγόμενο PPTX προγραμματιστικά και ελέγξτε τον αριθμό και το περιεχόμενο των κύριων διαφανειών, έπειτα συγκρίνετε την εμφάνιση και τη συμπεριφορά της παρουσίασης στο επιθυμητό πρόγραμμα προβολής. Μην θεωρείτε μια επιτυχημένη κλήση στο [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) απόδειξη ότι κάθε παλαιότερη λειτουργία έχει ακριβή αναπαράσταση στο PPTX.

## **Πότε να Χρησιμοποιήσετε το PPTX**

Χρησιμοποιήστε το PPTX όταν η παρουσίαση θα επεξεργαστεί σε τρέχουσες εκδόσεις του PowerPoint, θα ανταλλαγεί με συστήματα που δουλεύουν με πακέτα Open XML ή θα αποθηκευτεί σε μορφή ευκολότερη στην επιθεώρηση και ανάκτηση από το παλαιότερο δυαδικό PPT. Διατηρήστε το αρχικό PPT ως αρχείο αρχειοθέτησης ή εφεδρικό αντίγραφο μέχρι η μετατραπείσα παρουσίαση περάσει τους ελέγχους ακρίβειας.

Εάν χρειάζεστε PDF, HTML, εικόνες, XPS ή κάποιον άλλο τύπο εξόδου, χρησιμοποιήστε τις οδηγίες για συγκεκριμένες μορφές στο [Convert Presentations to Multiple Formats](/cpp/convert-presentation/) αντί να υποθέτετε ότι όλοι οι προορισμοί διατηρούν επεξεργάσιμες λειτουργίες του PowerPoint.

## **Διαδικτυακός Μετατροπέας**

Για περιστασιακό αρχείο ή γρήγορη σύγκριση, μπορείτε να χρησιμοποιήσετε το [online PPT to PPTX converter](https://products.aspose.app/slides/el/conversion/ppt-to-pptx). Για επαναλαμβανόμενες μετατροπές, επεξεργασία σε δέσμες ή διαχείριση σφαλμάτων σε επίπεδο εφαρμογής, χρησιμοποιήστε το C++ API.

## **Σχετικά Άρθρα**

- [Αποθήκευση παρουσιάσεων σε C++](/cpp/save-presentation/)
- [Υποστηριζόμενες μορφές αρχείων](/cpp/supported-file-formats/)
- [Άνοιγμα παρουσιάσεων σε C++](/cpp/open-presentation/)

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω PPT σε PPTX χωρίς να είναι εγκατεστημένο το Microsoft PowerPoint;**

Ναι. Το Aspose.Slides για C++ φορτώνει και αποθηκεύει αρχεία παρουσίασης χωρίς να απαιτεί το Microsoft PowerPoint.

**Θα διατηρήσει η μετατροπή PPT‑σε‑PPTX όλο το περιεχόμενο ακριβώς;**

Διατηρεί το κοινό περιεχόμενο της παρουσίασης, αλλά η απόλυτη ακρίβεια δεν είναι εγγυημένη για κάθε παλαιότερη ή μη υποστηριζόμενη λειτουργία. Ελέγξτε το δημιουργημένο αρχείο όταν περιέχει μακροεντολές, αντικείμενα OLE ή ActiveX, πολυμέσα, εξειδικευμένα κινούμενα σχέδια ή σπάνιες γραμματοσειρές.

**Μπορώ να μετατρέψω ένα αρχείο PPT προστατευμένο με κωδικό;**

Ναι, εφόσον παρέχετε τον σωστό κωδικό πρόσβασης κατά τη φόρτωση του αρχείου. Η απουσία ή ο λανθασμένος κωδικός πρόσβασης προκαλεί αποτυχία της λειτουργίας φόρτωσης.

**Πρέπει να διαγράψω το αρχείο PPT μετά τη μετατροπή;**

Διατηρήστε το αρχικό μέχρι να επαληθεύσετε το PPTX στα προγράμματα προβολής και τις ροές εργασίας που σας ενδιαφέρουν. Αυτό παρέχει ένα αντίγραφο εφεδρείας εάν κάποια παλαιότερη λειτουργία μετατραπεί με διαφορετικό τρόπο.