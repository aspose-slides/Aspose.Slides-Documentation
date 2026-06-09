---
title: Μετατροπή Παρουσίασεων PowerPoint σε XPS με C++
linktitle: PowerPoint σε XPS
type: docs
weight: 70
url: /el/cpp/convert-powerpoint-to-xps
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε XPS
- παρουσίαση σε XPS
- διαφάνεια σε XPS
- PPT σε XPS
- PPTX σε XPS
- αποθήκευση PPT ως XPS
- αποθήκευση PPTX ως XPS
- εξαγωγή PPT σε XPS
- εξαγωγή PPTX σε XPS
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μετατρέψτε PowerPoint PPT/PPTX σε υψηλής ποιότητας, ανεξάρτητο από πλατφόρμα XPS με C++ χρησιμοποιώντας Aspose.Slides. Λάβετε οδηγό βήμα‑βήμα και δείγμα κώδικα."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να μετατρέπετε παρουσιάσεις PowerPoint σε XPS αποθηκεύοντας ένα αρχείο PPT ή PPTX στη μορφή XPS. Αυτό το άρθρο εξηγεί πότε η μορφή XPS μπορεί να είναι χρήσιμη και δείχνει πώς να πραγματοποιήσετε τη μετατροπή με το Aspose.Slides χρησιμοποιώντας είτε προεπιλεγμένες ρυθμίσεις είτε προσαρμοσμένες ρυθμίσεις [XpsOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/xpsoptions/) .

## **Σχετικά με το XPS**

Η Microsoft ανέπτυξε το [XPS](https://docs.fileformat.com/page-description-language/xps/) ως εναλλακτική λύση στο [PDF](https://docs.fileformat.com/pdf/). Σας επιτρέπει να εκτυπώσετε περιεχόμενο εξάγοντας ένα αρχείο παρόμοιο με PDF. Η μορφή XPS βασίζεται σε XML. Η διάταξη ή η δομή ενός αρχείου XPS παραμένει ίδια σε όλα τα λειτουργικά συστήματα και εκτυπωτές. 

## **Πότε να Χρησιμοποιήσετε τη Μορφή Microsoft XPS**

{{% alert color="primary" %}} 

Για να δείτε πώς το Aspose.Slides μετατρέπει παρουσίαση PPT ή PPTX σε μορφή XPS, μπορείτε να δοκιμάσετε [αυτήν τη δωρεάν διαδικτυακή εφαρμογή μετατροπής](https://products.aspose.app/slides/el/conversion). 

{{% /alert %}} 

Αν θέλετε να μειώσετε το κόστος αποθήκευσης, μπορείτε να μετατρέψετε την παρουσίαση Microsoft PowerPoint σε μορφή XPS. Με αυτόν τον τρόπο θα είναι πιο εύκολο να αποθηκεύετε, να μοιράζεστε και να εκτυπώνετε τα έγγραφά σας. 

Η Microsoft συνεχίζει να παρέχει ισχυρή υποστήριξη για XPS στα Windows (ακόμη και στα Windows 10), οπότε ίσως θελήσετε να σκεφτείτε την αποθήκευση αρχείων σε αυτή τη μορφή. Αν χρησιμοποιείτε Windows 8.1, Windows 8, Windows 7 ή Windows Vista, το XPS ίσως είναι η καλύτερη επιλογή για ορισμένες λειτουργίες. 

- **Windows 8** χρησιμοποιεί τη μορφή OXPS (Open XPS) για αρχεία XPS. Το OXPS είναι μια τυποποιημένη έκδοση του αρχικού XPS. Τα Windows 8 προσφέρουν καλύτερη υποστήριξη για αρχεία XPS από ό,τι για αρχεία PDF. 
  - **XPS:** Διαθέσιμο ενσωματωμένο πρόγραμμα προβολής/ανάγνωσης XPS και δυνατότητα εκτύπωσης σε XPS. 
  - **PDF:** Διαθέσιμο πρόγραμμα ανάγνωσης PDF, αλλά χωρίς δυνατότητα εκτύπωσης σε PDF. 

- **Windows 7 και Windows Vista** χρησιμοποιούν την αρχική μορφή XPS. Αυτά τα λειτουργικά συστήματα επίσης παρέχουν καλύτερη υποστήριξη για αρχεία XPS από ό,τι για PDF. 
  - **XPS:** Διαθέσιμο ενσωματωμένο πρόγραμμα προβολής XPS και δυνατότητα εκτύπωσης σε XPS. 
  - **PDF:** Δεν υπάρχει πρόγραμμα ανάγνωσης PDF. Δεν υπάρχει δυνατότητα εκτύπωσης σε PDF. 

|<p>**Είσοδος PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Έξοδος XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Η Microsoft τελικά υλοποίησε υποστήριξη για λειτουργίες εκτύπωσης σε PDF μέσω της δυνατότητας Εκτύπωση σε PDF στα Windows 10. Πριν από αυτό, οι χρήστες έπρεπε να εκτυπώνουν έγγραφα μέσω της μορφής XPS. 

## **Μετατροπή XPS με το Aspose.Slides**

Στο [**Aspose.Slides**](https://products.aspose.com/slides/el/cpp/) για C++, μπορείτε να χρησιμοποιήσετε τη μέθοδο [**Save**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) που εκτίθεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) για να μετατρέψετε ολόκληρη την παρουσίαση σε έγγραφο XPS. 

Κατά τη μετατροπή μιας παρουσίασης σε XPS, πρέπει να αποθηκεύσετε την παρουσίαση χρησιμοποιώντας μία από τις παρακάτω ρυθμίσεις:

- Προεπιλεγμένες ρυθμίσεις (χωρίς [**XPSOptions**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.xps_options))
- Προσαρμοσμένες ρυθμίσεις (με [**XPSOptions**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.xps_options))

### **Μετατροπή Παρουσιάσεων σε XPS με Προεπιλεγμένες Ρυθμίσεις**

Αυτό το δείγμα κώδικα σε C++ δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο XPS χρησιμοποιώντας τις τυπικές ρυθμίσεις:

``` cpp
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Αποθήκευση της παρουσίασης σε έγγραφο XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **Μετατροπή Παρουσιάσεων σε XPS με Προσαρμοσμένες Ρυθμίσεις**

Αυτό το δείγμα κώδικα δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο XPS χρησιμοποιώντας προσαρμοσμένες ρυθμίσεις σε C++:

``` cpp
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Δημιουργία αντικειμένου της κλάσης TiffOptions
auto options = System::MakeObject<XpsOptions>();

// Αποθήκευση MetaFiles ως PNG
options->set_SaveMetafilesAsPng(true);

// Αποθήκευση της παρουσίασης σε έγγραφο XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **Συχνές Ερωτήσεις**

**Μπορώ να αποθηκεύσω σε XPS σε ροή αντί για αρχείο;**

Ναι—το Aspose.Slides σας επιτρέπει να εξάγετε απευθείας σε ροή, κάτι που είναι ιδανικό για web‑API, διαδικασίες στο διακομιστή ή οποιοδήποτε σενάριο όπου θέλετε να στείλετε το XPS χωρίς να αγγίξετε το σύστημα αρχείων.

**Μεταφέρονται οι κρυμμένες διαφάνειες στο XPS και μπορώ να τις εξαιρέσω;**

Από προεπιλογή, μόνο οι κανονικές (ορατές) διαφάνειες αποδίδονται. Μπορείτε να [συμπεριλάβετε ή εξαιρέσετε κρυμμένες διαφάνειες](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) μέσω των [ρυθμίσεων εξαγωγής](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/xpsoptions/) πριν αποθηκεύσετε σε XPS, εξασφαλίζοντας ότι η έξοδος περιέχει ακριβώς τις σελίδες που επιθυμείτε.