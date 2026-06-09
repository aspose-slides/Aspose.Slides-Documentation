---
title: Μετατροπή παρουσιάσεων PowerPoint σε XPS με Python
linktitle: PowerPoint σε XPS
type: docs
weight: 70
url: /el/python-net/convert-powerpoint-to-xps/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- PowerPoint σε XPS
- παρουσίαση σε XPS
- PPT σε XPS
- PPTX σε XPS
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μετατρέψτε PowerPoint PPT/PPTX σε XPS υψηλής ποιότητας, ανεξάρτητο από πλατφόρμα, με Python χρησιμοποιώντας το Aspose.Slides. Λάβετε οδηγίες βήμα‑βήμα και δείγμα κώδικα."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να μετατρέψετε παρουσιάσεις PowerPoint σε XPS αποθηκεύοντας ένα αρχείο PPT ή PPTX στη μορφή XPS. Αυτό το άρθρο εξηγεί πότε η μορφή XPS μπορεί να είναι χρήσιμη και δείχνει πώς να πραγματοποιήσετε τη μετατροπή με το Aspose.Slides χρησιμοποιώντας είτε τις προεπιλεγμένες ρυθμίσεις είτε προσαρμοσμένες [XpsOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/xpsoptions/) ρυθμίσεις.

## **Σχετικά με το XPS**
Η Microsoft ανέπτυξε το [XPS](https://docs.fileformat.com/page-description-language/xps/) ως εναλλακτική λύση προς το [PDF](https://docs.fileformat.com/pdf/). Σας επιτρέπει να εκτυπώσετε περιεχόμενο παράγοντας ένα αρχείο πολύ παρόμοιο με ένα PDF. Η μορφή XPS βασίζεται στο XML. Η διάταξη ή η δομή ενός αρχείου XPS παραμένει ίδια σε όλα τα λειτουργικά συστήματα και τους εκτυπωτές. 

## Πότε να χρησιμοποιήσετε τη μορφή Microsoft XPS

{{% alert color="primary" %}} 

Για να δείτε πώς το Aspose.Slides μετατρέπει την παρουσίαση PPT ή PPTX στη μορφή XPS, μπορείτε να εξετάσετε [αυτήν τη δωρεάν διαδικτυακή εφαρμογή μετατροπής](https://products.aspose.app/slides/el/conversion). 

{{% /alert %}} 

Εάν θέλετε να μειώσετε τα έξοδα αποθήκευσης, μπορείτε να μετατρέψετε την παρουσίαση Microsoft PowerPoint σε μορφή XPS. Με αυτόν τον τρόπο, θα βρείτε πιο εύκολο να αποθηκεύετε, να μοιράζεστε και να εκτυπώνετε τα έγγραφά σας. 

Η Microsoft συνεχίζει να προσφέρει ισχυρή υποστήριξη για το XPS στα Windows (ακόμη και στα Windows 10), οπότε ίσως θελήσετε να εξετάσετε την αποθήκευση αρχείων σε αυτή τη μορφή. Εάν εργάζεστε με Windows 8.1, Windows 8, Windows 7 και Windows Vista, το XPS μπορεί να είναι η καλύτερη επιλογή σας για ορισμένες λειτουργίες. 

- **Windows 8** χρησιμοποιεί τη μορφή OXPS (Open XPS) για αρχεία XPS. Το OXPS είναι μια τυποποιημένη έκδοση της αρχικής μορφής XPS. Τα Windows 8 παρέχουν καλύτερη υποστήριξη για αρχεία XPS από ό,τι για αρχεία PDF. 
  - **XPS:** Διαθέσιμη ενσωματωμένη προβολή/ανάγνωση XPS και δυνατότητα εκτύπωσης σε XPS. 
  - **PDF:** Διαθέσιμο πρόγραμμα ανάγνωσης PDF, αλλά δεν υπάρχει δυνατότητα εκτύπωσης σε PDF. 

- **Windows 7** και **Windows Vista** χρησιμοποιούν την αρχική μορφή XPS. Αυτά τα λειτουργικά συστήματα παρέχουν επίσης καλύτερη υποστήριξη για αρχεία XPS από ό,τι για PDF. 
  - **XPS:** Διαθέσιμη ενσωματωμένη προβολή XPS και δυνατότητα εκτύπωσης σε XPS. 
  - **PDF:** Δεν υπάρχει πρόγραμμα ανάγνωσης PDF. Δεν υπάρχει δυνατότητα εκτύπωσης σε PDF. 

|<p>**Είσοδος PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Έξοδος XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Η Microsoft τελικά υλοποίησε υποστήριξη για λειτουργίες εκτύπωσης σε PDF μέσω της δυνατότητας Print to PDF στα Windows 10. Πριν από αυτό, οι χρήστες έπρεπε να εκτυπώνουν έγγραφα μέσω της μορφής XPS. 

## Μετατροπή XPS με το Aspose.Slides

Στο [**Aspose.Slides**](https://products.aspose.com/slides/el/python-net/) για .NET, μπορείτε να χρησιμοποιήσετε τη μέθοδο [**Save**](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) που εκτίθεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για να μετατρέψετε ολόκληρη την παρουσίαση σε έγγραφο XPS. 

Κατά τη μετατροπή μιας παρουσίασης σε XPS, πρέπει να αποθηκεύσετε την παρουσίαση χρησιμοποιώντας μία από τις ακόλουθες ρυθμίσεις:

- Προεπιλεγμένες ρυθμίσεις (χωρίς [**XPSOptions**](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/xpsoptions/))
- Προσαρμοσμένες ρυθμίσεις (με [**XPSOptions**](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/xpsoptions/))

### **Μετατροπή παρουσιάσεων σε XPS χρησιμοποιώντας προεπιλεγμένες ρυθμίσεις**

Αυτό το δείγμα κώδικα σε Python δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο XPS χρησιμοποιώντας τις προεπιλεγμένες ρυθμίσεις:

```py
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
pres = slides.Presentation("Convert_XPS.pptx")

# Αποθήκευση της παρουσίασης σε έγγραφο XPS
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```

### **Μετατροπή παρουσιάσεων σε XPS χρησιμοποιώντας προσαρμοσμένες ρυθμίσεις**
Αυτό το δείγμα κώδικα δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο XPS χρησιμοποιώντας προσαρμοσμένες ρυθμίσεις σε Python:

```py
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
pres = slides.Presentation("Convert_XPS_Options.pptx")

# Δημιουργήστε ένα αντικείμενο της κλάσης TiffOptions
options = slides.export.XpsOptions()

# Αποθήκευση MetaFiles ως PNG
options.save_metafiles_as_png = True

# Αποθήκευση της παρουσίασης σε έγγραφο XPS
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **Συχνές ερωτήσεις**

**Μπορώ να αποθηκεύσω σε XPS σε ροή (stream) αντί για αρχείο;**

Ναι—το Aspose.Slides σάς επιτρέπει να εξάγετε απευθείας σε ροή, κάτι που είναι ιδανικό για web API, διακομιστή‑πλευρικές διαδρομές επεξεργασίας ή οποιοδήποτε σενάριο όπου θέλετε να στείλετε το XPS χωρίς να αγγίξετε το σύστημα αρχείων.

**Μεταφέρονται οι κρυφές διαφάνειες στο XPS, και μπορώ να τις εξαιρέσω;**

Από προεπιλογή, μόνο οι κανονικές (ορατές) διαφάνειες αποδίδονται. Μπορείτε να [συμπεριλάβετε ή εξαχίσετε κρυφές διαφάνειες](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) μέσω των [ρυθμίσεων εξαγωγής](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/xpsoptions/) πριν αποθηκεύσετε σε XPS, διασφαλίζοντας ότι η έξοδος περιέχει ακριβώς τις σελίδες που επιθυμείτε.