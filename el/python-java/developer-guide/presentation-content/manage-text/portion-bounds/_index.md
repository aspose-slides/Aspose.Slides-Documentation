---
title: Ανάκτηση ορίων τμήματος κειμένου από παρουσιάσεις σε Python μέσω Java
linktitle: Όρια τμήματος
type: docs
weight: 47
url: /el/python-java/portion-bounds/
keywords:
- όρια τμήματος κειμένου
- τμήμα κειμένου
- μέρος κειμένου
- συντεταγμένες κειμένου
- θέση κειμένου
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια τμήματος κειμένου σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Μια ενότητα κειμένου αντιπροσωπεύει ένα συγκεκριμένο τμήμα κειμένου μέσα σε μια παράγραφο και σας επιτρέπει να εργάζεστε με αυτό το τμήμα ανεξάρτητα από το περιβάλλον κείμενο. Στο Aspose.Slides, οι ενότητες μπορούν να χρησιμοποιηθούν όταν χρειάζεται να ανακτήσετε τα όρια ενός τμήματος κειμένου, να εφαρμόσετε μορφοποίηση μόνο σε μέρος μιας παραγράφου ή να ελέγξετε τη συμπεριφορά του κειμένου σε πιο λεπτομερή επίπεδο.

Αυτό το άρθρο δείχνει πώς να λάβετε το ορθογώνιο περιγράμματος μιας ενότητας χρησιμοποιώντας [Portion.getRect](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/#getRect). Επίσης δείχνει πώς να λάβετε τις συντεταγμένες της αρχής μιας ενότητας χρησιμοποιώντας [Portion.getCoordinates](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/#getCoordinates). Επιπλέον, αναδεικνύει κοινά σενάρια σχετιζόμενα με ενότητες, όπως η εφαρμογή υπερσύνδεσμου σε ένα μοναδικό τμήμα κειμένου, η κατανόηση του πώς η μορφοποίηση λυγίζεται μέσω ενότητας, παραγράφου, πλαισίου κειμένου και κληρονομικότητας θέματος, καθώς και η αντιμετώπιση περιπτώσεων όπου μια καθορισμένη γραμματοσειρά δεν είναι διαθέσιμη.

## **Λήψη ορίων μιας ενότητας κειμένου**

Χρησιμοποιήστε [Portion.getRect](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/#getRect) για να ανακτήσετε το ορθογώνιο περιγράμματος μιας ενότητας κειμένου:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **Λήψη συντεταγμένων μιας ενότητας κειμένου**

Χρησιμοποιήστε [Portion.getCoordinates](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/#getCoordinates) για να ανακτήσετε τις συντεταγμένες της αρχής μιας ενότητας κειμένου:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **Συχνές ερωτήσεις**

**Μπορώ να εφαρμόσω έναν υπερσύνδεσμο μόνο σε μέρος του κειμένου μέσα σε μια ενιαία παράγραφο;**

Ναι, μπορείτε να [αναθέσετε έναν υπερσύνδεσμο](/slides/el/python-java/manage-hyperlinks/) σε μια μεμονωμένη ενότητα· μόνο αυτό το τμήμα θα είναι κλικ‑δυνατό, όχι ολόκληρη η παράγραφος.

**Πώς λειτουργεί η κληρονομικότητα του στυλ: τι υπερισχύει από μια ενότητα και τι λαμβάνεται από μια παράγραφο ή ένα πλαίσιο κειμένου;**

Οι ιδιότητες σε επίπεδο ενότητας έχουν την υψηλότερη προτεραιότητα. Εάν μια ιδιότητα δεν έχει οριστεί στην [Portion](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/), το Aspose.Slides την παίρνει από την [Paragraph](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraph/). Εάν δεν έχει οριστεί και εκεί, το Aspose.Slides χρησιμοποιεί το στυλ του [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/) ή του [theme](https://reference.aspose.com/slides/el/python-java/aspose.slides/theme/).

**Τι συμβαίνει εάν η γραμματοσειρά που έχει καθοριστεί για μια ενότητα λείπει στο στόχο μηχανή ή διακομιστή;**

Εφαρμόζονται οι [κανόνες αντικατάστασης γραμματοσειρών](/slides/el/python-java/font-selection-sequence/). Το κείμενο ενδέχεται να αναδιαταχθεί: οι μετρικές, η συλλαβή και το πλάτος μπορεί να αλλάξουν, κάτι που είναι σημαντικό για ακριβή τοποθέτηση.

**Μπορώ να ορίσω διαφάνεια γεμίσματος κειμένου ή διαβάθμιση ειδικά για μια ενότητα, ανεξάρτητα από το υπόλοιπο της παραγράφου;**

Ναι, το χρώμα κειμένου, το γέμισμα και η διαφάνεια σε επίπεδο [Portion](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/) μπορούν να διαφέρουν από τα γειτονικά τμήματα.