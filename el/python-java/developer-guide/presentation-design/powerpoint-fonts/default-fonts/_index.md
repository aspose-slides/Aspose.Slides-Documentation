---
title: Καθορίστε τις Προεπιλεγμένες Γραμματοσειρές Παρουσίασης σε Python μέσω Java
linktitle: Προεπιλεγμένη Γραμματοσειρά
type: docs
weight: 30
url: /el/python-java/default-font/
keywords:
- προεπιλεγμένη γραμματοσειρά
- κανονική γραμματοσειρά
- απλή γραμματοσειρά
- ασιατική γραμματοσειρά
- εξαγωγή PDF
- εξαγωγή XPS
- εξαγωγή εικόνας
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Ορίστε τις προεπιλεγμένες γραμματοσειρές στο Aspose.Slides για Python μέσω Java ώστε να διασφαλιστεί η σωστή μετατροπή των αρχείων PowerPoint (PPT, PPTX) και OpenDocument (ODP) σε PDF, XPS και εικόνες."
---
## **Επισκόπηση**

Aspose.Slides σάς επιτρέπει να καθορίζετε προεπιλεγμένες γραμματοσειρές που χρησιμοποιούνται όταν μια παρουσίαση αποδίδεται. Αυτό είναι χρήσιμο κατά τη δημιουργία μικρογραφιών διαφανειών ή την εξαγωγή μιας παρουσίασης σε μορφές όπως PDF και XPS. Οι προεπιλεγμένες γραμματοσειρές ρυθμίζονται μέσω [LoadOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/) πριν φορτωθεί η παρουσίαση.

Η μέθοδος [setDefaultRegularFont](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) ορίζει την προεπιλεγμένη γραμματοσειρά για κανονικό κείμενο, ενώ η [setDefaultAsianFont](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) ορίζει την προεπιλεγμένη γραμματοσειρά για ασιατικό κείμενο. Αφού οριστούν αυτές οι επιλογές, η παρουσίαση μπορεί να φορτωθεί και να αποδοθεί χρησιμοποιώντας τις καθορισμένες γραμματοσειρές.

## **Χρήση προεπιλεγμένων γραμματοσειρών για απόδοση παρουσίασης**

Aspose.Slides σας επιτρέπει να ορίσετε προεπιλεγμένες γραμματοσειρές για την απόδοση μιας παρουσίασης σε PDF, XPS ή μικρογραφίες. Αυτή η ενότητα δείχνει πώς να ορίσετε προεπιλεγμένες γραμματοσειρές για κανονικό και ασιατικό κείμενο χρησιμοποιώντας το Aspose.Slides για Python μέσω Java:

1. Δημιουργήστε ένα στιγμιότυπο του [LoadOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/).
2. Χρησιμοποιήστε τη [setDefaultRegularFont](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) για να καθορίσετε τη γραμματοσειρά που θέλετε. Το παρακάτω παράδειγμα χρησιμοποιεί Wingdings.
3. Χρησιμοποιήστε τη [setDefaultAsianFont](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) για να καθορίσετε τη γραμματοσειρά που θέλετε. Το παρακάτω παράδειγμα επίσης χρησιμοποιεί Wingdings.
4. Φορτώστε την παρουσίαση χρησιμοποιώντας το [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) με τις επιλογές φόρτωσης.
5. Δημιουργήστε τη μικρογραφία της διαφάνειας, το PDF και το XPS για να επαληθεύσετε τα αποτελέσματα.

Το παρακάτω παράδειγμα υλοποιεί αυτά τα βήματα:

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# Χρησιμοποιήστε τις επιλογές φόρτωσης για να ορίσετε τις προεπιλεγμένες κανονικές και ασιατικές γραμματοσειρές.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# Φορτώστε την παρουσίαση.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # Δημιουργήστε μικρογραφία διαφάνειας.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Αποθηκεύστε την εικόνα στο δίσκο.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # Δημιουργήστε PDF.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # Δημιουργήστε έγγραφο XPS.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **FAQ**

**Τι ακριβώς επηρεάζουν οι προεπιλεγμένες κανονικές και ασιατικές γραμματοσειρές—μόνο η εξαγωγή, ή και οι μικρογραφίες, PDF, XPS, HTML και SVG;**

Συμμετέχουν στην αλυσίδα απόδοσης για όλες τις υποστηριζόμενες εξόδους. Αυτό περιλαμβάνει μικρογραφίες διαφανειών, [PDF](/slides/el/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/el/python-java/convert-powerpoint-to-xps/), [raster images](/slides/el/python-java/convert-powerpoint-to-png/), [HTML](/slides/el/python-java/convert-powerpoint-to-html/), και [SVG](/slides/el/python-java/render-a-slide-as-an-svg-image/), επειδή το Aspose.Slides χρησιμοποιεί την ίδια λογική διάταξης και επίλυσης γλύφων σε αυτούς τους προορισμούς.

**Εφαρμόζονται οι προεπιλεγμένες γραμματοσειρές όταν απλώς διαβάζετε και αποθηκεύετε ένα PPTX χωρίς καμία απόδοση;**

Όχι. Οι προεπιλεγμένες γραμματοσειρές είναι σημαντικές όταν πρέπει να μετρηθεί και να σχεδιαστεί το κείμενο. Μια απλή ανοίγηση‑αποθήκευση μιας παρουσίασης δεν αλλάζει τις αποθηκευμένες ακολουθίες γραμματοσειρών ή τη δομή του αρχείου. Οι προεπιλεγμένες γραμματοσειρές έρχονται σε δράση κατά τις λειτουργίες που αποδίδουν ή επανακαθορίζουν το κείμενο.

**Αν προσθέσω τους δικούς μου φακέλους γραμματοσειρών ή παρέχω γραμματοσειρές από τη μνήμη, θα ληφθούν υπόψη κατά την επιλογή των προεπιλεγμένων γραμματοσειρών;**

Ναι. Οι [Custom font sources](/slides/el/python-java/custom-font/) επεκτείνουν τον κατάλογο των διαθέσιμων οικογενειών και γλύφων που μπορεί να χρησιμοποιήσει η μηχανή. Οι προεπιλεγμένες γραμματοσειρές και τυχόν [fallback rules](/slides/el/python-java/fallback-font/) θα αναζητηθούν πρώτα σε αυτές τις πηγές, παρέχοντας πιο αξιόπιστη κάλυψη σε διακομιστές και σε containers.

**Θα επηρεάσουν οι προεπιλεγμένες γραμματοσειρές τις μετρικές κειμένου (kerning, advances) και κατά συνέπεια τις αλλαγές γραμμής και την αναδίπλωση;**

Ναι. Η αλλαγή της γραμματοσειράς αλλάζει τις μετρικές των γλύφων και μπορεί να τροποποιήσει τις αλλαγές γραμμής, την αναδίπλωση και τον αριθμό σελίδων κατά την απόδοση. Για σταθερότητα διάταξης, [embed the original fonts](/slides/el/python-java/embedded-font/) ή επιλέξτε προεπιλεγμένες και εναλλακτικές οικογένειες που είναι μετρικά συμβατές.

**Έχει νόημα να ορίζονται προεπιλεγμένες γραμματοσειρές εάν όλες οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση είναι ενσωματωμένες;**

Συχνά δεν είναι απαραίτητο, επειδή οι [embedded fonts](/slides/el/python-java/embedded-font/) ήδη εξασφαλίζουν συνεπή εμφάνιση. Οι προεπιλεγμένες γραμματοσειρές εξακολουθούν να βοηθούν ως δίκτυο ασφαλείας για χαρακτήρες που δεν καλύπτονται από το ενσωματωμένο υποσύνολο ή όταν ένα αρχείο συνδυάζει ενσωματωμένο και μη ενσωματωμένο κείμενο.