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
description: "Μετατρέψτε τα κληροδοτημένα αρχεία PPT σε PPTX σε C++ με το Aspose.Slides. Περιλαμβάνει παραδείγματα C++ για μετατροπή ενός αρχείου ή δέσμης, διαχείριση σφαλμάτων και σημειώσεις ακρίβειας."
---
## **Επισκόπηση**

Το PPT είναι η παλαιότερη δυαδική μορφή PowerPoint, ενώ το PPTX είναι η νεότερη μορφή Open XML. Το Aspose.Slides για C++ μπορεί να φορτώσει ένα αρχείο PPT και να το αποθηκεύσει ως PPTX χωρίς το Microsoft PowerPoint. Αυτό το άρθρο δείχνει πώς να μετατρέψετε ένα αρχείο ή έναν φάκελο αρχείων και εξηγεί τι πρέπει να ελέγξετε μετά τη μετατροπή.

## **Μετατροπή αρχείου PPT σε PPTX**

Φορτώστε το αρχείο προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/), στη συνέχεια καλέστε [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) με το [SaveFormat::Pptx](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveformat/). Αποδεσμεύστε την παρουσίαση όταν δεν τη χρειάζεστε πλέον για να ελευθερώσετε τις πηγές της.

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

Η επέκταση του αρχείου δεν επιλέγει από μόνη της τη μορφή εξόδου· το όρισμα [SaveFormat::Pptx](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveformat/) το κάνει. Κρατήστε διαφορετικές διαδρομές εισόδου και εξόδου αν χρειάζεται να διατηρήσετε το αρχικό αρχείο PPT.

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

Για παραγωγική χρήση, καταγράψτε την πλήρη εξαίρεση, αποφασίστε εάν ένα υπάρχον αρχείο εξόδου μπορεί να αντικατασταθεί και γράψτε τα ονόματα των αποτυχημένων αρχείων σε μια ουρά επανεκτέλεσης ή ελέγχου. Κατεστραμμένα αρχεία, αρχεία με κωδικό πρόσβασης που ανοίγονται χωρίς τον απαιτούμενο κωδικό, μη προσπελάσιμες διαδρομές και μη υποστηριζόμενο περιεχόμενο μπορούν όλα να προκαλέσουν αποτυχία μετατροπής. Δείτε [Παρουσιάσεις με κωδικό πρόσβασης](/slides/el/cpp/password-protected-presentation/) για τη φόρτωση κρυπτογραφημένων αρχείων.

## **Ακρίβεια και κληροδοτημένα χαρακτηριστικά**

Η μετατροπή συνήθως διατηρεί διαφάνειες, master, διατάξεις, κείμενο, σχήματα, εικόνες, πίνακες και διαγράμματα. Ωστόσο, τα PPT και PPTX δεν αντιπροσωπεύουν κάθε χαρακτηριστικό με ακριβώς τον ίδιο τρόπο. Ένα κληροδοτημένο χαρακτηριστικό που δεν έχει ισοδύναμο στο PPTX ή δεν υποστηρίζεται από τη βιβλιοθήκη μπορεί να κανονικοποιηθεί, να παραλειφθεί ή να εμφανιστεί διαφορετικά.

Ελέγξτε το μετατρεπόμενο αρχείο όταν περιέχει κινούμενα στοιχεία, μεταβάσεις, ενσωματωμένα ή συνδεδεμένα αντικείμενα OLE, ελέγχους ActiveX, ενσωματωμένα πολυμέσα, σπάνιες γραμματοσειρές ή μακροεντολές VBA. Ένα απλό αρχείο PPTX δεν είναι μορφή με ενεργοποιημένες μακροεντολές, οπότε χρησιμοποιήστε κατάλληλη ροή εργασίας με ενεργοποιημένες μακροεντολές όταν η VBA πρέπει να παραμείνει διαθέσιμη. Επίσης, επιβεβαιώστε ότι οι απαιτούμενες γραμματοσειρές και εξωτερικοί πόροι υπάρχουν στο περιβάλλον όπου θα ανοίξει ή θα αποδοθεί η μετατρεπόμενη παρουσίαση.

Για σημαντικά έγγραφα, ανοίξτε προγραμματιστικά το παραγόμενο PPTX και ελέγξτε βασικούς αριθμούς διαφανειών και περιεχομένου, έπειτα συγκρίνετε την εμφάνισή του και τη συμπεριφορά προβολής διαφανειών στον προοριζόμενο θεατή. Μην θεωρείτε μια επιτυχημένη κλήση [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) απόδειξη ότι κάθε κληροδοτημένο χαρακτηριστικό έχει ακριβή αναπαράσταση στο PPTX.

## **Πότε να χρησιμοποιήσετε PPTX**

Χρησιμοποιήστε PPTX όταν η παρουσίαση θα επεξεργαστεί σε τρέχουσες εκδόσεις του PowerPoint, θα ανταλλαχθεί με συστήματα που δουλεύουν με πακέτα Open XML ή θα αποθηκευτεί σε μια μορφή που είναι πιο εύκολη στην επιθεώρηση και ανάκτηση από το κληροδοτημένο δυαδικό PPT. Διατηρήστε το αρχικό PPT ως αρχείο αρχειοθέτησης ή εφεδρικό αντίγραφο μέχρι η μετατρεπόμενη παρουσίαση να περάσει τους ελέγχους ακρίβειας.

Αν χρειάζεστε PDF, HTML, εικόνες, XPS ή άλλη μορφή εξόδου, ακολουθήστε τις οδηγίες μορφής στο [Μετατροπή παρουσιάσεων σε πολλαπλές μορφές](/slides/el/cpp/convert-presentation/) αντί να υποθέτετε ότι όλοι οι προορισμοί διατηρούν επεξεργάσιμα χαρακτηριστικά PowerPoint.

## **Διαδικτυακός μετατροπέας**

Για ένα περιστασιακό αρχείο ή μια γρήγορη σύγκριση, μπορείτε να χρησιμοποιήσετε τον [διαδικτυακό μετατροπέα PPT σε PPTX](https://products.aspose.app/slides/el/conversion/ppt-to-pptx). Για επαναλαμβανόμενες μετατροπές, επεξεργασία δέσμης ή διαχείριση σφαλμάτων σε επίπεδο εφαρμογής, χρησιμοποιήστε το API C++.

## **Σχετικά άρθρα**

- [Αποθήκευση παρουσιάσεων σε C++](/slides/el/cpp/save-presentation/)
- [Υποστηριζόμενες μορφές αρχείων](/slides/el/cpp/supported-file-formats/)
- [Άνοιγμα παρουσιάσεων σε C++](/slides/el/cpp/open-presentation/)

## **Συχνές ερωτήσεις**

**Μπορώ να μετατρέψω PPT σε PPTX χωρίς εγκατεστημένο Microsoft PowerPoint;**

Ναι. Το Aspose.Slides για C++ φορτώνει και αποθηκεύει αρχεία παρουσίασης χωρίς να απαιτεί το Microsoft PowerPoint.

**Θα διατηρήσει η μετατροπή PPT‑σε‑PPTX όλο το περιεχόμενο ακριβώς;**

Διατηρεί το κοινό περιεχόμενο παρουσίασης, αλλά η ακριβής ακρίβεια δεν εγγυάται για κάθε κληροδοτημένο ή μη υποστηριζόμενο χαρακτηριστικό. Εξετάστε το παραγόμενο αρχείο όταν περιέχει μακροεντολές, αντικείμενα OLE ή ActiveX, πολυμέσα, εξειδικευμένες κινούμενες εικόνες ή σπάνιες γραμματοσειρές.

**Μπορώ να μετατρέψω ένα PPT αρχείο με κωδικό πρόσβασης;**

Ναι, εφόσον παρέχετε τον σωστό κωδικό πρόσβασης κατά τη φόρτωση του αρχείου. Η έλλειψη ή εσφαλμένος κωδικός προκαλεί αποτυχία της λειτουργίας φόρτωσης.

**Πρέπει να διαγράψω το αρχείο PPT μετά τη μετατροπή;**

Διατηρήστε το αρχικό μέχρι να επαληθεύσετε το PPTX στους προωθητές και τις ροές εργασίας που σας ενδιαφέρουν. Αυτό παρέχει εφεδρικό αντίγραφο σε περίπτωση που ένα κληροδοτημένο χαρακτηριστικό μετατραπεί διαφορετικά.