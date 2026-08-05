---
title: Διαχείριση Callouts σε Διαγράμματα Παρουσιάσεων χρησιμοποιώντας C++
linktitle: Σημείωση
type: docs
url: /el/cpp/callout/
keywords:
- callout διαγράμματος
- χρήση σημείωσης
- ετικέτα δεδομένων
- μορφή ετικέτας
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Δημιουργήστε και μορφοποιήστε σημειώσεις στο Aspose.Slides για C++ με σύντομα παραδείγματα κώδικα, συμβατά με PPT και PPTX για αυτοματοποίηση των διαδικασιών παρουσίασης."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με τα callouts για ετικέτες δεδομένων διαγράμματος στο Aspose.Slides. Δείχνει πώς να χρησιμοποιήσετε τη μέθοδο `set_ShowLabelAsDataCallout` για να εμφανίσετε τις ετικέτες ως callouts, πώς να διαμορφώσετε τις ρυθμίσεις ετικετών σχετικές με τα callout για ένα διάγραμμα doughnut, και σημειώνει ότι τα callouts και η εμφάνισή τους διατηρούνται όταν οι παρουσιάσεις εξάγονται σε PDF, HTML5, SVG και μορφές raster εικόνας.

## **Χρήση Callouts**
Νέα ιδιότητα **ShowLabelAsDataCallout** προστέθηκε στην κλάση **DataLabelFormat** και στο interface **IDataLabelFormat**, η οποία καθορίζει εάν η ετικέτα δεδομένων του συγκεκριμένου διαγράμματος θα εμφανίζεται ως data callout ή ως ετικέτα δεδομένων. Στο παρακάτω παράδειγμα, έχουμε ορίσει τα Callouts.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Ορισμός Callout για Διάγραμμα Doughnut**
Το Aspose.Slides for C++ παρέχει υποστήριξη για τον ορισμό του σχήματος callout ετικέτας δεδομένων σειράς για ένα διάγραμμα Doughnut. Παρατίθεται το παρακάτω δείγμα κώδικα.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**Διατηρούνται τα callouts κατά τη μετατροπή μιας παρουσίασης σε PDF, HTML5, SVG ή εικόνες;**

Ναι. Τα callouts αποτελούν μέρος της απόδοσης του διαγράμματος, επομένως όταν εξάγετε σε [PDF](/slides/el/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/el/cpp/export-to-html5/), [SVG](/slides/el/cpp/render-a-slide-as-an-svg-image/), ή [raster images](/slides/el/cpp/convert-powerpoint-to-png/), διατηρούνται μαζί με τη μορφοποίηση της διαφάνειας.

**Λειτουργούν οι προσαρμοσμένες γραμματοσειρές στα callouts, και μπορεί η εμφάνισή τους να διατηρηθεί κατά την εξαγωγή;**

Ναι. Το Aspose.Slides υποστηρίζει [ενσωμάτωση γραμματοσειρών](/slides/el/cpp/embedded-font/) στην παρουσίαση και ελέγχει την ενσωμάτωση γραμματοσειρών κατά τις εξαγωγές όπως το [PDF](/slides/el/cpp/convert-powerpoint-to-pdf/), διασφαλίζοντας ότι τα callouts διατηρούν την ίδια εμφάνιση σε διαφορετικά συστήματα.