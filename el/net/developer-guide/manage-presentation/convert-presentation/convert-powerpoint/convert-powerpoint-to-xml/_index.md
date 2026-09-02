---
title: Μετατροπή παρουσιάσεων PowerPoint σε XML με .NET
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
description: "Μετατρέψτε παρουσιάσεις PowerPoint και OpenDocument σε αρχεία ή ροές PowerPoint XML με C# χρησιμοποιώντας Aspose.Slides για .NET."
---
## **Επισκόπηση**

Το Aspose.Slides for .NET μπορεί να μετατρέπει παρουσιάσεις PowerPoint στη μορφή PowerPoint XML Presentation. Η έξοδος XML είναι χρήσιμη όταν χρειάζεστε μια κειμενική αναπαράσταση για την εξέταση της δομής της παρουσίασης, την αντιμετώπιση προβλημάτων σε παραγόμενα έγγραφα, τη σύγκριση της εξόδου σε αυτόματες δοκιμές ή την ενσωμάτωση με μια ροή εργασίας που χρησιμοποιεί XML αντί για πακέτο παρουσίασης.

Χρησιμοποιήστε τη μέθοδο [Presentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/) με την τιμή `Xml` από την απαρίθμηση [SaveFormat](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveformat/). Μπορείτε να γράψετε το αποτέλεσμα απευθείας σε αρχείο ή σε ροή.

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` δημιουργεί μια παρουσίαση PowerPoint XML. Δεν εξάγει τα μεμονωμένα τμήματα Office Open XML που αποθηκεύονται μέσα σε ένα πακέτο PPTX. Εάν χρειάζεστε τα ακριβή τμήματα του πακέτου PPTX, όπως το `ppt/presentation.xml` ή μεμονωμένα αρχεία XML διαφάνειας, εξετάστε το ίδιο το πακέτο PPTX.

{{% /alert %}}

## **Μετατροπή παρουσίασης σε αρχείο XML**

Φορτώστε μια παρουσίαση πηγής με την κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και στη συνέχεια περάστε τη διαδρομή εξόδου και το `SaveFormat.Xml` στη μέθοδο [Presentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/). Η πηγή μπορεί να είναι οποιαδήποτε μορφή παρουσίασης που υποστηρίζεται για φόρτωση, όπως PPT, PPTX ή ODP.

Το ακόλουθο παράδειγμα μετατρέπει μια παρουσίαση PPTX σε αρχείο XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Εγγραφή του XML εξόδου σε ροή**

Χρησιμοποιήστε την υπερφόρτωση ροής της [Presentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/) όταν το XML πρέπει να παραμείνει στη μνήμη ή να περάσει σε άλλο στοιχείο, όπως μια υπηρεσία web, πάροχο αποθήκευσης ή δίαυλο επεξεργασίας XML. Το ακόλουθο παράδειγμα γράφει το αποτέλεσμα σε ένα [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) και το επαναφέρει στην αρχή για επόμενη ανάγνωση:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Περάστε το xmlStream στο επόμενο στοιχείο της ροής εργασίας.
```

## **Σύγκριση XML με μορφές παρουσίασης και εξαγωγής**

Επιλέξτε τη μορφή εξόδου ανάλογα με το πώς θα χρησιμοποιηθεί το αποτέλεσμα:

| Μορφή | Έξοδος | Τυπική χρήση |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Μια παρουσίαση PowerPoint XML | Εξέταση δομής, αντιμετώπιση προβλημάτων, σύγκριση παραγόμενου αποτελέσματος και ενσωμάτωση βασισμένη σε XML |
| PPT (`.ppt`) | Ένα παλαιό δυαδικό αρχείο παρουσίασης | Συμβατότητα με παλαιότερες ροές εργασίας PowerPoint |
| PPTX (`.pptx`) | Ένα πακέτο Office Open XML που περιέχει πολλαπλά τμήματα | Κανονική επεξεργασία PowerPoint και ανταλλαγή παρουσιάσεων |
| PDF ή TIFF | Σελίδες σταθερής διάταξης ή εικόνα πολλαπλών σελίδων | Προβολή, εκτύπωση και αρχειοθέτηση |
| PNG, JPEG ή SVG | Μια αποδιδόμενη αναπαράσταση μιας μεμονωμένης διαφάνειας | Μικρογραφίες, προεπισκοπήσεις και εικόνες περιουσιακών στοιχείων |
| HTML ή HTML5 | Παράγοντας παρουσίασης προσανατολισμένο στο web | Προβολή σε προγράμματα περιήγησης και δημοσίευση στο web |

Σε αντίθεση με τα PPT και PPTX, η έξοδος XML προορίζεται κυρίως για επιθεώρηση και εργασίες προσανατολισμένες στα δεδομένα. Σε αντίθεση με PDF, TIFF, HTML και μορφές εικόνας διαφάνειας, αντιπροσωπεύει δεδομένα παρουσίασης αντί για απόδοση διαφανειών ως σελίδων ή οπτικών στοιχείων. Ο πίνακας [υποστηριζόμενων μορφών αρχείων](/slides/el/net/supported-file-formats/) καταγράφει το PowerPoint XML Presentation ως μορφή μόνο αποθήκευσης· επομένως μην το χρησιμοποιείτε όταν μια ροή εργασίας πρέπει να φορτώσει το εξαχθέν αρχείο ξανά στο Aspose.Slides για συνεχή επεξεργασία.

## **Συχνές ερωτήσεις**

**Είναι το `SaveFormat.Xml` το ίδιο με την αποθήκευση ενός αρχείου PPTX;**

Όχι. Το PPTX είναι ένα πακέτο που περιέχει πολλαπλά τμήματα Office Open XML, ενώ το `SaveFormat.Xml` δημιουργεί ένα αρχείο PowerPoint XML Presentation.

**Μπορώ να αποθηκεύσω την έξοδο XML χωρίς να δημιουργήσω αρχείο στο δίσκο;**

Ναι. Περάστε μια εγγράψιμη ροή στη μέθοδο [Presentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/). Για παράδειγμα, χρησιμοποιήστε ένα [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) για επεξεργασία στη μνήμη.

**Μπορεί το Aspose.Slides να φορτώσει ξανά το εξαγόμενο αρχείο XML;**

Όχι. Η παρουσίαση PowerPoint XML υποστηρίζεται αυτή τη στιγμή μόνο για αποθήκευση και όχι για φόρτωση. Χρησιμοποιήστε PPTX ή άλλη υποστηριζόμενη μορφή παρουσίασης όταν απαιτείται επαναληπτική επεξεργασία.

**Η μετατροπή XML αποδίδει κάθε διαφάνεια ως σελίδα ή εικόνα;**

Όχι. Η μετατροπή XML γράφει δομημένα δεδομένα παρουσίασης. Χρησιμοποιήστε PDF ή TIFF για έξοδο προσανατολισμένο σε σελίδες ή PNG, JPEG και SVG για μεμονωμένες εικόνες διαφανειών.