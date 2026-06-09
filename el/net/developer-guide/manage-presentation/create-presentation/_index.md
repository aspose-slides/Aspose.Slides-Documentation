---
title: Δημιουργία παρουσιάσεων σε .NET
linktitle: Δημιουργία παρουσίασης
type: docs
weight: 10
url: /el/net/create-presentation/
keywords:
- δημιουργία παρουσίασης
- νέα παρουσίαση
- δημιουργία PPT
- νέο PPT
- δημιουργία PPTX
- νέο PPTX
- δημιουργία ODP
- νέο ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε παρουσιάσεις σε .NET με Aspose.Slides—παράγουμε αρχεία PPT, PPTX και ODP, επωφεληθείτε από τη υποστήριξη OpenDocument και αποθηκεύστε τα προγραμματιστικά για αξιόπιστα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια παρουσίαση στο Aspose.Slides, να προσθέσετε απλό περιεχόμενο σε μια διαφάνεια και να αποθηκεύσετε το αποτέλεσμα ως αρχείο. Επίσης, επιδεικνύει πώς να δημιουργήσετε και να αποθηκεύσετε μια νέα παρουσίαση, να ανοίξετε μια υπάρχουσα παρουσίαση σε υποστηριζόμενη μορφή και να την αποθηκεύσετε σε άλλη μορφή. Επιπλέον, το άρθρο περιλαμβάνει μια σύντομη ενότητα FAQ που καλύπτει συχνές ερωτήσεις σχετικά με μορφές, πρότυπα, διαστάσεις διαφάνειας, μονάδες, χρήση μνήμης, πολυνηματικότητα, αδειοδότηση, ψηφιακές υπογραφές και υποστήριξη VBA.

## **Δημιουργία παρουσίασης PowerPoint**

Για να προσθέσετε μια απλή γραμμή σε μια επιλεγμένη διαφάνεια της παρουσίασης, παρακαλώ ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
2. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
3. Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο AddAutoShape που εκτίθεται από το αντικείμενο Shapes.
4. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε μια γραμμή στην πρώτη διαφάνεια της παρουσίασης.

```c#
 // Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
 using (Presentation presentation = new Presentation())
 {
     // Πάρτε την πρώτη διαφάνεια
     ISlide slide = presentation.Slides[0];

     // Προσθέστε ένα αυτόματο σχήμα τύπου γραμμή
     slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
     presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
 }
```

## **Δημιουργία και αποθήκευση παρουσίασης**

<a name="csharp-create-save-presentation"><strong>Βήματα: Δημιουργία και αποθήκευση παρουσίασης σε C#</strong></a>

1. Δημιουργήστε ένα στιγμιότυπο της [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) κλάσης.
2. Αποθηκεύστε το _Presentation_ σε οποιαδήποτε μορφή υποστηρίζεται από [SaveFormat](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveformat/)

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **Άνοιγμα και αποθήκευση παρουσίασης**

<a name="csharp-open-save-presentation"><strong>Βήματα: Άνοιγμα και αποθήκευση παρουσίασης σε C#</strong></a>

1. Δημιουργήστε ένα στιγμιότυπο της [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) κλάσης με οποιαδήποτε μορφή, π.χ. PPT, PPTX, ODP κλπ.
2. Αποθηκεύστε το _Presentation_ σε οποιαδήποτε μορφή υποστηρίζεται από [SaveFormat](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveformat/)

```c#
 // Φορτώστε οποιοδήποτε υποστηριζόμενο αρχείο σε Presentation π.χ. ppt, pptx, odp κλπ.
 Presentation presentation = new Presentation("Sample.odp");

 presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **Συχνές ερωτήσεις**

**Σε ποιες μορφές μπορώ να αποθηκεύσω μια νέα παρουσίαση;**

Μπορείτε να αποθηκεύσετε σε [PPTX, PPT, and ODP](/slides/el/net/save-presentation/), και να εξάγετε σε [PDF](/slides/el/net/convert-powerpoint-to-pdf/), [XPS](/slides/el/net/convert-powerpoint-to-xps/), [HTML](/slides/el/net/convert-powerpoint-to-html/), [SVG](/slides/el/net/convert-powerpoint-to-png/), και [images](/slides/el/net/convert-powerpoint-to-png/), μεταξύ άλλων.

**Μπορώ να ξεκινήσω από ένα πρότυπο (POTX/POTM) και να το αποθηκεύσω ως κανονικό PPTX;**

Ναι. Φορτώστε το πρότυπο και αποθηκεύστε στην επιθυμητή μορφή· οι μορφές POTX/POTM/PPTM και παρόμοιες [are supported](/slides/el/net/supported-file-formats/).

**Πώς ελέγχω το μέγεθος/αναλογία διαφάνειας όταν δημιουργώ μια παρουσίαση;**

Ορίστε το [slide size](/slides/el/net/slide-size/) (συμπεριλαμβανομένων προκαθορισμένων όπως 4:3 και 16:9 ή προσαρμοσμένων διαστάσεων) και επιλέξτε πώς πρέπει να κλιμακώνεται το περιεχόμενο.

**Σε ποιες μονάδες μετρώνται τα μεγέθη και οι συντεταγμένες;**

Σε points: 1 ίντσα ισούται με 72 μονάδες.

**Πώς διαχειρίζομαι πολύ μεγάλες παρουσιάσεις (με πολλά αρχεία πολυμέσων) για να μειώσω τη χρήση μνήμης;**

Χρησιμοποιήστε [BLOB management strategies](/slides/el/net/manage-blob/), περιορίστε την αποθήκευση στη μνήμη αξιοποιώντας προσωρινά αρχεία, και προτιμήστε ροές εργασίας βασισμένες σε αρχεία αντί για καθαρά ρεύματα στη μνήμη.

**Μπορώ να δημιουργήσω/αποθηκεύσω παρουσιάσεις παράλληλα;**

Δεν μπορείτε να λειτουργείτε στην ίδια [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) παρουσίαση από [multiple threads](/slides/el/net/multithreading/). Εκτελέστε ξεχωριστά, απομονωμένα στιγμιότυπα ανά νήμα ή διαδικασία.

**Πώς αφαιρώ το υδατογράφημα δοκιμαστικής έκδοσης και τους περιορισμούς;**

[Apply a license](/slides/el/net/licensing/) μία φορά ανά διεργασία. Το XML της άδειας πρέπει να παραμείνει αμετάβλητο, και η ρύθμιση της άδειας πρέπει να συγχρονίζεται εάν εμπλέκονται πολλαπλά νήματα.

**Μπορώ να υπογράψω ψηφιακά το PPTX που δημιουργώ;**

Ναι. [Digital signatures](/slides/el/net/digital-signature-in-powerpoint/) (προσθήκη και επαλήθευση) υποστηρίζονται για παρουσιάσεις.

**Υποστηρίζονται μακροεντολές (VBA) στις δημιουργημένες παρουσιάσεις;**

Ναι. Μπορείτε να [create/edit VBA projects](/slides/el/net/presentation-via-vba/) και να αποθηκεύσετε αρχεία με δυνατότητα μακροεντολών όπως PPTM/PPSM.