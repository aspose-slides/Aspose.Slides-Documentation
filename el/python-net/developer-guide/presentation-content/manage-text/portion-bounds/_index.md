---
title: Ανάκτηση Ορίων Τμημάτων Κειμένου από Παρουσιάσεις σε Python
linktitle: Όρια Τμημάτων
type: docs
weight: 47
url: /el/python-net/portion-bounds/
keywords:
- όρια τμήματος κειμένου
- τμήμα κειμένου
- μέρος κειμένου
- συντεταγμένες κειμένου
- θέση κειμένου
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια τμημάτων κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Ένα τμήμα κειμένου αντιπροσωπεύει ένα συγκεκριμένο απόσπασμα κειμένου μέσα σε μια παράγραφο και σας επιτρέπει να εργάζεστε με αυτό το απόσπασμα ανεξάρτητα από το περιβάλλον. Στο Aspose.Slides, τα τμήματα μπορούν να χρησιμοποιηθούν όταν χρειάζεται να ανακτήσετε τα όρια ενός αποσπάσματος κειμένου, να εφαρμόσετε μορφοποίηση μόνο σε μέρος μιας παραγράφου ή να ελέγξετε τη συμπεριφορά του κειμένου σε πιο λεπτομερή επίπεδα.

Αυτό το άρθρο δείχνει πώς να λάβετε το ορθογώνιο περιορισμού ενός τμήματος χρησιμοποιώντας [Portion.get_rect](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/get_rect/). Επίσης, δείχνει πώς να λάβετε τις συντεταγμένες της αρχής ενός τμήματος χρησιμοποιώντας [Portion.get_coordinates](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/get_coordinates/). Επιπλέον, επισημαίνει κοινά σενάρια που σχετίζονται με τμήματα, όπως η εφαρμογή υπερσυνδέσμου σε ένα μόνο απόσπασμα κειμένου, η κατανόηση του πώς η μορφοποίηση επιλύεται μέσω τμήματος, παραγράφου, πλαισίου κειμένου και κληρονόμησης θέματος, καθώς και η διαχείριση περιπτώσεων όπου η καθορισμένη γραμματοσειρά δεν είναι διαθέσιμη.

## **Λήψη ορίων τμήματος κειμένου**

Χρησιμοποιήστε [Portion.get_rect](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/get_rect/) για να ανακτήσετε το ορθογώνιο περιορισμού ενός τμήματος κειμένου:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **Λήψη συντεταγμένων τμήματος κειμένου**

Χρησιμοποιήστε [Portion.get_coordinates](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/get_coordinates/) για να ανακτήσετε τις συντεταγμένες της αρχής ενός τμήματος κειμένου:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **Συχνές ερωτήσεις**

**Μπορώ να εφαρμόσω υπερσύνδεσμο μόνο σε μέρος του κειμένου μέσα σε μία παράγραφο;**

Ναι, μπορείτε να [επιλάβετε έναν υπερσύνδεσμο](/slides/el/python-net/manage-hyperlinks/) σε ένα μεμονωμένο τμήμα· μόνο εκείνο το απόσπασμα θα είναι κλικαριστέο, όχι ολόκληρη η παράγραφος.

**Πώς λειτουργεί η κληρονόμηση στυλ: τι παρακάμπτει ένα τμήμα και τι λαμβάνει από μια παράγραφο ή πλαίσιο κειμένου;**

Οι ιδιότητες επιπέδου [Portion] έχουν την υψηλότερη προτεραιότητα. Εάν μια ιδιότητα δεν έχει οριστεί στο [Portion](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/), το Aspose.Slides την λαμβάνει από το [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/). Εάν δεν έχει οριστεί εκεί επίσης, το Aspose.Slides χρησιμοποιεί το στυλ του [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) ή του [theme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/theme/).

**Τι συμβαίνει αν η γραμματοσειρά που ορίστηκε για ένα τμήμα λείπει από τον προορισμό ή τον διακομιστή;**

Εφαρμόζονται [Κανόνες αντικατάστασης γραμματοσειρών](/slides/el/python-net/font-selection-sequence/). Το κείμενο μπορεί να αναδιαταχθεί: μετρικές, συλλαβισμός και πλάτος μπορεί να αλλάξουν, κάτι που είναι σημαντικό για ακριβή τοποθέτηση.

**Μπορώ να ορίσω διαφάνεια ή διαβάθμιση γεμίσματος κειμένου ειδικά για ένα τμήμα, ανεξάρτητα από το υπόλοιπο της παραγράφου;**

Ναι, το χρώμα κειμένου, το γέμισμα και η διαφάνεια στο επίπεδο [Portion](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/) μπορούν να διαφέρουν από τα γειτονικά τμήματα.