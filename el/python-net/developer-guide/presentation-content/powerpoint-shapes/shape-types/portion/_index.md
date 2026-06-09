---
title: Διαχείριση Τμημάτων Κειμένου σε Παρουσιάσεις με Python
linktitle: Τμήμα Κειμένου
type: docs
weight: 70
url: /el/python-net/portion/
keywords:
- τμήμα κειμένου
- μέρος κειμένου
- συντεταγμένες κειμένου
- θέση κειμένου
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τμήματα κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET, ενισχύοντας την απόδοση και την προσαρμοστικότητα."
---
## **Εισαγωγή**

Μια ενότητα κειμένου αντιπροσωπεύει ένα συγκεκριμένο τμήμα κειμένου μέσα σε μια παράγραφο και σας επιτρέπει να εργάζεστε με αυτό το τμήμα ανεξάρτητα από το περιεχόμενο γύρω του. Στο Aspose.Slides, οι ενότητες μπορούν να χρησιμοποιηθούν όταν χρειάζεται να ανακτήσετε τη θέση ενός τμήματος κειμένου, να εφαρμόσετε μορφοποίηση μόνο σε μέρος μιας παραγράφου ή να ελέγξετε τη συμπεριφορά του κειμένου σε πιο λεπτομερή επίπεδο.

## **Λήψη Συντεταγμένων Τμημάτων Κειμένου**

Η μέθοδος [get_coordinates](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/get_coordinates/) προστέθηκε στην κλάση [Portion](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/) η οποία επιτρέπει την ανάκτηση των συντεταγμένων των τμημάτων κειμένου:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Μπορώ να εφαρμόσω έναν υπερσύνδεσμο μόνο σε μέρος του κειμένου μέσα σε μία παράγραφο;**

Ναι, μπορείτε να [αναθέσετε έναν υπερσύνδεσμο](/slides/el/python-net/manage-hyperlinks/) σε μια μεμονωμένη ενότητα· μόνο αυτό το τμήμα θα είναι κλικ-δυνατό, όχι όλη η παράγραφος.

**Πώς λειτουργεί η κληρονομικότητα στυλ: τι αντικαθιστά μια Portion και τι λαμβάνεται από το Paragraph/TextFrame;**

Οι ιδιότητες σε επίπεδο Portion έχουν την υψηλότερη προτεραιότητα. Εάν μια ιδιότητα δεν έχει οριστεί στην [Portion](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/), η μηχανή τη λαμβάνει από το [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/); αν δεν έχει οριστεί και εκεί, από το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) ή το στυλ του [theme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/theme/).

**Τι συμβαίνει εάν η γραμματοσειρά που έχει καθοριστεί για μια Portion λείπει από τον προορισμό μηχανή/διακομιστή;**

Εφαρμόζονται οι [κανόνες αντικατάστασης γραμματοσειράς](/slides/el/python-net/font-selection-sequence/). Το κείμενο μπορεί να αναδιαταχθεί: οι μετρικές, η συλλαβιστική και το πλάτος μπορούν να αλλάξουν, κάτι που έχει σημασία για ακριβή τοποθέτηση.

**Μπορώ να ορίσω διαφάνεια ή διαβάθμιση γεμίσματος κειμένου ειδική για μια Portion, ανεξάρτητα από την υπόλοιπη παράγραφο;**

Ναι, το χρώμα κειμένου, το γέμισμα και η διαφάνεια σε επίπεδο [Portion](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/) μπορούν να διαφέρουν από τα γειτονικά τμήματα.