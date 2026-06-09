---
title: Διαχείριση ετικετών και προσαρμοσμένων δεδομένων σε παρουσιάσεις με C++
linktitle: Ετικέτες και προσαρμοσμένα δεδομένα
type: docs
weight: 300
url: /el/cpp/managing-tags-and-custom-data/
keywords:
- ιδιότητες εγγράφου
- ετικέτα
- προσαρμοσμένα δεδομένα
- προσθήκη ετικέτας
- τιμές ζεύγους
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, διαβάζετε, ενημερώνετε και αφαιρείτε ετικέτες & προσαρμοσμένα δεδομένα στο Aspose.Slides για C++, με παραδείγματα για παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς το Aspose.Slides λειτουργεί με ετικέτες και προσαρμοσμένα δεδομένα σε παρουσιάσεις PowerPoint. Περιγράφει σύντομα πώς αποθηκεύονται τα δεδομένα σε αρχεία PPTX, σημειώνει ότι τα δεδομένα ειδικά για την παρουσίαση μπορούν να υπάρξουν ως ετικέτες και προσαρμοσμένα τμήματα XML, και περιγράφει τις ετικέτες ως ζεύγη κλειδιού-τιμής τύπου συμβολοσειράς.

Δείχνει επίσης πώς να διαβάσετε τις τιμές των ετικετών και πώς να προσθέσετε ετικέτες σε μια παρουσίαση, σε μια μεμονωμένη διαφάνεια ή σε ένα σχήμα. Επιπλέον, το άρθρο καλύπτει κοινές εργασίες διαχείρισης ετικετών όπως η εκκαθάριση όλων των ετικετών, η αφαίρεση μιας ετικέτας με όνομα και η ανάκτηση της λίστας των ονομάτων ετικετών.

## **Αποθήκευση Δεδομένων σε Αρχεία Παρουσίασης**

Τα αρχεία PPTX—αντικείμενα με την επέκταση .pptx—αποθηκεύονται σε μορφή PresentationML, η οποία αποτελεί μέρος της προδιαγραφής Office Open XML. Η μορφή Office Open XML ορίζει τη δομή των δεδομένων που περιέχονται σε παρουσιάσεις.

Με μια *διαφάνεια* να είναι ένα από τα στοιχεία στις παρουσιάσεις, ένα *τμήμα διαφάνειας* περιέχει το περιεχόμενο μιας μόνο διαφάνειας. Ένα τμήμα διαφάνειας επιτρέπεται να έχει ρητές σχέσεις με πολλά τμήματα—όπως οι Ετικέτες Χρήστη—που ορίζονται από το ISO/IEC 29500.

Προσαρμοσμένα δεδομένα (ειδικά για μια παρουσίαση) ή ο χρήστης μπορούν να υπάρξουν ως ετικέτες ([ITagCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/itagcollection/)) και CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/icustomxmlpartcollection/)).
{{% alert color="primary" %}} 
Οι ετικέτες είναι ουσιαστικά τιμές ζεύγους κλειδί‑συμβολοσειράς. 
{{% /alert %}} 

## **Λήψη Τιμών Ετικετών**

Στις διαφάνειες, μια ετικέτα αντιστοιχεί στην ιδιότητα IDocumentProperties.Keywords. Αυτό το δείγμα κώδικα δείχνει πώς να λάβετε την τιμή μιας ετικέτας με το Aspose.Slides για C++ για την [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/):
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **Προσθήκη Ετικετών σε Παρουσιάσεις**

Το Aspose.Slides σάς επιτρέπει να προσθέσετε ετικέτες σε παρουσιάσεις. Μια ετικέτα συνήθως αποτελείται από δύο στοιχεία:
- το όνομα μιας προσαρμοσμένης ιδιότητας - `MyTag` 
- την τιμή της προσαρμοσμένης ιδιότητας - `My Tag Value`

Εάν χρειάζεται να ταξινομήσετε κάποιες παρουσιάσεις βάσει ενός συγκεκριμένου κανόνα ή ιδιότητας, τότε μπορείτε να επωφεληθείτε από την προσθήκη ετικετών σε αυτές τις παρουσιάσεις. Για παράδειγμα, εάν θέλετε να κατηγοριοποιήσετε ή να συγκεντρώσετε όλες τις παρουσιάσεις από χώρες της Βόρειας Αμερικής, μπορείτε να δημιουργήσετε μια ετικέτα «North American» και στη συνέχεια να αντιστοιχίσετε τις σχετικές χώρες (ΗΠΑ, Μεξικό και Καναδά) ως τιμές.

Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε μια ετικέτα σε μια [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) χρησιμοποιώντας το Aspose.Slides για C++:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Οι ετικέτες μπορούν επίσης να οριστούν για το [Slide](https://reference.aspose.com/slides/el/cpp/aspose.slides/slide/):
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Ή για οποιοδήποτε μεμονωμένο [Shape](https://reference.aspose.com/slides/el/cpp/aspose.slides/shape/):
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Περιορισμοί**

Οι ετικέτες που προστίθενται μέσω της συλλογής ετικετών προσαρμοσμένων δεδομένων χρησιμοποιώντας `get_CustomData()->get_Tags()` αποθηκεύονται μόνο εντός του αρχείου PowerPoint. Δεν **μεταφέρονται** στη δομή ετικετών PDF όταν η παρουσίαση εξάγεται σε PDF. Συνεπώς, ένας προσαρμοσμένος ταυτοποιητής που έχει οριστεί ως ετικέτα δεν μπορεί να ανακτηθεί από το PDF με ετικέτες.

**Λύση**: Μπορείτε να αποθηκεύσετε έναν προσαρμοσμένο ταυτοποιητή στο **Alt Text** του αντικειμένου (π.χ., `shape->set_AlternativeText(u"MyId")`). Μετά την εξαγωγή σε PDF, το Alt Text μπορεί να εμφανιστεί στη δομή ετικετών PDF.

## **Συχνές Ερωτήσεις**

**Μπορώ να αφαιρέσω όλες τις ετικέτες από μια παρουσίαση, διαφάνεια ή σχήμα σε μία λειτουργία;**

Ναι. Η [συλλογή ετικετών](https://reference.aspose.com/slides/el/cpp/aspose.slides/tagcollection/) υποστηρίζει τη λειτουργία [clear](https://reference.aspose.com/slides/el/cpp/aspose.slides/tagcollection/clear/) η οποία διαγράφει όλα τα ζεύγη κλειδιού‑τιμής ταυτόχρονα.

**Πώς μπορώ να διαγράψω μια μεμονωμένη ετικέτα με το όνομά της χωρίς επανάληψη σε ολόκληρη τη συλλογή;**

Χρησιμοποιήστε τη λειτουργία [Remove(name)](https://reference.aspose.com/slides/el/cpp/aspose.slides/tagcollection/remove/) στη [TagCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/tagcollection/) για να διαγράψετε την ετικέτα με το κλειδί της.

**Πώς μπορώ να ανακτήσω την πλήρη λίστα των ονομάτων ετικετών για ανάλυση ή φιλτράρισμα;**

Χρησιμοποιήστε το [GetNamesOfTags](https://reference.aspose.com/slides/el/cpp/aspose.slides/tagcollection/getnamesoftags/) στη [συλλογή ετικετών](https://reference.aspose.com/slides/el/cpp/aspose.slides/tagcollection/); επιστρέφει έναν πίνακα με όλα τα ονόματα ετικετών.