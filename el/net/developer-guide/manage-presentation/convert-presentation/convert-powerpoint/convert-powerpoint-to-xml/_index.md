---
title: Μετατρέψτε παρουσιάσεις PowerPoint σε XML στο .NET
linktitle: PowerPoint σε XML
type: docs
weight: 145
url: /el/net/convert-powerpoint-to-xml/
keywords:
- μετατροπή PowerPoint σε XML
- μετατροπή παρουσίασης σε XML
- PPT σε XML
- PPTX σε XML
- ODP σε XML
- Παρουσίαση PowerPoint XML
- SaveFormat.Xml
- αποθήκευση παρουσίασης ως XML
- εξαγωγή παρουσίασης σε XML
- ροή XML
- .NET
- C#
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint και OpenDocument σε αρχεία ή ροές PowerPoint XML με C# χρησιμοποιώντας το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Το Aspose.Slides for .NET μπορεί να μετατρέπει παρουσιάσεις PowerPoint σε μορφή PowerPoint XML Presentation. Η έξοδος XML είναι χρήσιμη όταν χρειάζεστε μια κειμενική αναπαράσταση για την επιθεώρηση της δομής της παρουσίασης, την αντιμετώπιση προβλημάτων των παραγόμενων εγγράφων, τη σύγκριση της εξόδου σε αυτοματοποιημένες δοκιμές ή την ενσωμάτωση σε ροή εργασίας που καταναλώνει XML αντί για πακέτο παρουσίασης.

Χρησιμοποιήστε τη μέθοδο [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) με την τιμή `Xml` από την απαρίθμηση [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). Μπορείτε να γράψετε το αποτέλεσμα απευθείας σε αρχείο ή σε ροή.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` δημιουργεί μια PowerPoint XML Presentation. Δεν εξάγει τα μεμονωμένα μέρη Office Open XML που αποθηκεύονται μέσα σε ένα πακέτο PPTX. Εάν χρειάζεστε τα ακριβή μέρη του πακέτου PPTX, όπως `ppt/presentation.xml` ή τα μεμονωμένα αρχεία XML διαφάνειας, εξετάστε το ίδιο το πακέτο PPTX.
{{% /alert %}}

## **Μετατροπή παρουσίασης σε αρχείο XML**

Φορτώστε μια πηγαία παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) και, στη συνέχεια, περάστε τη διαδρομή εξόδου και το `SaveFormat.Xml` στη μέθοδο [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Η πηγή μπορεί να είναι οποιαδήποτε μορφή παρουσίασης που υποστηρίζεται για φόρτωση, όπως PPT, PPTX ή ODP.

Το παρακάτω παράδειγμα μετατρέπει μια παρουσίαση PPTX σε αρχείο XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Γράψτε την έξοδο XML σε ροή**

Χρησιμοποιήστε την υπερφόρτωση ροής της μεθόδου [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) όταν το XML πρέπει να παραμείνει στη μνήμη ή να μεταβιβαστεί σε άλλο στοιχείο, όπως μια υπηρεσία ιστού, πάροχο αποθήκευσης ή pipeline επεξεργασίας XML. Το παρακάτω παράδειγμα γράφει το αποτέλεσμα σε ένα [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) και το επαναφέρει στην αρχή για επακόλουθη ανάγνωση:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Μεταβιβάστε το xmlStream στο επόμενο στοιχείο της ροής εργασίας.
```

## **Σύγκριση XML με μορφές παρουσίασης και εξαγωγής**

Επιλέξτε τη μορφή εξόδου ανάλογα με τον τρόπο χρήσης του αποτελέσματος:

| Μορφή | Έξοδος | Τυπική χρήση |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Μια PowerPoint XML Presentation | Επιθεώρηση δομής, αντιμετώπιση προβλημάτων, σύγκριση παραγόμενης εξόδου και ενσωμάτωση βάσει XML |
| PPT (`.ppt`) | Ένα παλαιότερο δυαδικό αρχείο παρουσίασης | Συμβατότητα με παλαιότερες ροές εργασίας PowerPoint |
| PPTX (`.pptx`) | Ένα πακέτο Office Open XML που περιέχει πολλαπλά μέρη | Κανονική επεξεργασία PowerPoint και ανταλλαγή παρουσιάσεων |
| PDF ή TIFF | Σταθερές σελίδες ή εικόνες TIFF | Προβολή, εκτύπωση και αρχειοθέτηση |
| PNG, JPEG ή SVG | Μια αποδόση μιας μεμονωμένης διαφάνειας | Μικρογραφίες, προεπισκοπήσεις και γραφικά στοιχεία |
| HTML ή HTML5 | Έξοδος παρουσίασης για το web | Προβολή σε προγράμματα περιήγησης και δημοσίευση στο web |

Σε αντίθεση με τα PPT και PPTX, η έξοδος XML προορίζεται κυρίως για επιθεώρηση και ροές εργασίας προσανατολισμένες στα δεδομένα. Σε αντίθεση με τα PDF, TIFF, HTML και μορφές εικόνας διαφάνειας, αντιπροσωπεύει τα δεδομένα παρουσίασης αντί για την απόδοση των διαφανειών ως σελίδες ή οπτικά στοιχεία. Ο πίνακας [υποστηριζόμενες μορφές αρχείων](/slides/el/net/supported-file-formats/) καταγράφει κάθε μορφή που μπορεί να φορτώσει, εισάγει, αποθηκεύσει ή αποδώσει το Aspose.Slides.

## **Συχνές ερωτήσεις**

**Είναι το `SaveFormat.Xml` το ίδιο με την αποθήκευση ενός αρχείου PPTX;**

Όχι. Το PPTX είναι ένα πακέτο που περιέχει πολλαπλά μέρη Office Open XML, ενώ το `SaveFormat.Xml` δημιουργεί ένα αρχείο PowerPoint XML Presentation.

**Μπορώ να αποθηκεύσω την έξοδο XML χωρίς να δημιουργήσω αρχείο στο δίσκο;**

Ναι. Περάστε μια ροή με δυνατότητα εγγραφής στη μέθοδο [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Για παράδειγμα, χρησιμοποιήστε ένα [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) για επεξεργασία στη μνήμη.

**Μπορεί το Aspose.Slides να φορτώσει ξανά το εξαχθέν αρχείο XML;**

Ναι. Περάστε το αρχείο XML ή μια ροή στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Η ιδιότητα [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) επιστρέφει τότε `SourceFormat.Xml`. Η μέθοδος [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) αναφέρει `LoadFormat.Unknown` για αυτή τη μορφή, οπότε μην τη χρησιμοποιείτε για να αποφασίσετε αν ένα αρχείο XML μπορεί να ανοιχθεί.

**Η μετατροπή XML αποδίδει κάθε διαφάνεια ως σελίδα ή εικόνα;**

Όχι. Η μετατροπή XML γράφει δομημένα δεδομένα παρουσίασης. Χρησιμοποιήστε PDF ή TIFF για έξοδο προσανατολισμένο σε σελίδες, ή PNG, JPEG και SVG για εικόνες μεμονωμένων διαφανειών.