---
title: Διαχείριση Κεφαλίδων και Υποσέλιδων Παρουσίασης με Python
linktitle: Κεφαλίδα και Υποσέλιδο
type: docs
weight: 140
url: /el/python-net/presentation-header-and-footer/
keywords:
- κεφαλίδα
- κείμενο κεφαλίδας
- υποσέλιδο
- κείμενο υποσέλιδου
- ορισμός κεφαλίδας
- ορισμός υποσέλιδου
- φυλλάδιο
- σημειώσεις
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides για Python μέσω .NET για να προσθέσετε και να προσαρμόσετε κεφαλίδες και υποσέλιδα σε παρουσιάσεις PowerPoint και OpenDocument, ώστε να αποκτήσετε επαγγελματικό αποτέλεσμα."
---
## **Επισκόπηση**

Aspose.Slides for Python σας επιτρέπει να ελέγχετε τα σύμβολα κεφαλίδας και υποσέλιδου σε ολόκληρη την παρουσίαση με ακριβή εμβέλεια. Το κείμενο του υποσέλιδου, η ημερομηνία/ώρα και οι αριθμοί διαφανειών διαχειρίζονται από το επίπεδο του master και μπορούν να εφαρμοστούν παγκοσμίως ή να προσαρμοστούν ανά διαφάνεια. Οι κεφαλίδες υποστηρίζονται σε σημειώσεις και φυλλάδια, όπου μπορείτε να εναλλάσσετε την ορατότητα και να ορίσετε κείμενο για την κεφαλίδα, το υποσέλιδο, την ημερομηνία/ώρα και τους αριθμούς σελίδων μέσω του ειδικού διαχειριστή κεφαλίδας & υποσέλιδου στο master slide σημειώσεων ή σε μεμονωμένες διαφάνειες σημειώσεων. Αυτό το άρθρο περιγράφει τα βασικά μοτίβα για την ενημέρωση αυτών των υπό-συμβόλων και τη συνεπή διάδοση των αλλαγών σε όλη την παρουσίαση.

## **Διαχείριση κειμένου κεφαλίδας και υποσέλιδου**

Σε αυτήν την ενότητα, θα μάθετε πώς να διαχειρίζεστε το περιεχόμενο της κεφαλίδας και του υποσέλιδου σε μια παρουσίαση—να ενεργοποιήσετε ή να τροποποιήσετε το υποσέλιδο, την ημερομηνία και ώρα, και τους αριθμούς διαφανειών. Θα περιγράψουμε εν συντομία τις εμβέλειες εφαρμογής αυτών των ρυθμίσεων (ολόκληρη η παρουσίαση, επιμέρους διαφάνειες και προβολές σημειώσεων/φυλλαδίου) και θα δείξουμε πώς να χρησιμοποιήσετε το Aspose.Slides API για να τις ενημερώσετε γρήγορα και συνεπώς.

Το παρακάτω παράδειγμα κώδικα ανοίγει μια παρουσίαση, ενεργοποιεί και θέτει το κείμενο του υποσέλιδου, ενημερώνει το κείμενο της κεφαλίδας στη master δι�αφάνεια σημειώσεων, και αποθηκεύει το αρχείο.

```py
import aspose.slides as slides

# Συνάρτηση για ορισμό του κειμένου της κεφαλίδας.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Φόρτωση της παρουσίασης.
with slides.Presentation("sample.pptx") as presentation:
    # Ορισμός του υποσέλιδου.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Πρόσβαση και ενημέρωση της κεφαλίδας.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Αποθήκευση της παρουσίασης.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαχείριση κεφαλίδας και υποσέλιδου σε διαφάνειες σημειώσεων**

Σε αυτήν την ενότητα, θα μάθετε πώς να διαχειρίζεστε τις κεφαλίδες και τα υποσέλιδα ειδικά για τις διαφάνειες σημειώσεων στο Aspose.Slides. Θα καλύψουμε την ενεργοποίηση των σχετικών συμβόλων κράτησης θέσης, τον ορισμό κειμένου για τα υποσέλιδα, την ημερομηνία/ώρα και τους αριθμούς σελίδων, και την συνεπή εφαρμογή αυτών των αλλαγών στο master σημειώσεων και στις μεμονωμένες σελίδες σημειώσεων.

Ακολουθήστε τα παρακάτω βήματα:

1. Φορτώστε ένα αρχείο παρουσίασης.
2. Αποκτήστε τη master διαφάνεια σημειώσεων και τον [διαχειριστή κεφαλίδας & υποσέλιδου](https://reference.aspose.com/slides/el/python-net/aspose.slides/masternotesslideheaderfootermanager/).
3. Στη master διαφάνεια σημειώσεων, ενεργοποιήστε την ορατότητα της Κεφαλίδας, του Υποσέλιδου, του Αριθμού διαφάνειας και της Ημερομηνίας-Ώρας για το master και όλες τις θυγατρικές διαφάνειες σημειώσεων.
4. Στη master διαφάνεια σημειώσεων, ορίστε κείμενο για την Κεφαλίδα, το Υποσέλιδο και την Ημερομηνία-Ώρα για το master και όλες τις θυγατρικές διαφάνειες σημειώσεων.
5. Αποκτήστε τη διαφάνεια σημειώσεων για την πρώτη διαφάνεια παρουσίασης και τον [διαχειριστή κεφαλίδας & υποσέλιδου](https://reference.aspose.com/slides/el/python-net/aspose.slides/notesslideheaderfootermanager/).
6. Μόνο για αυτήν την πρώτη διαφάνεια σημειώσεων, εξασφαλίστε ότι η Κεφαλίδα, το Υποσέλιδο, ο Αριθμός διαφάνειας και η Ημερομηνία-Ώρα είναι ορατά (ενεργοποιήστε ό,τι είναι απενεργοποιημένο).
7. Μόνο για αυτήν την πρώτη διαφάνεια σημειώσεων, ορίστε το κείμενο για την Κεφαλίδα, το Υποσέλιδο και την Ημερομηνία-Ώρα.
8. Αποθηκεύστε την παρουσίαση σε μορφή PPTX.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Κάντε τη διαφάνεια master σημειώσεων και όλα τα θυγατρικά σύμβολα κεφαλίδας, υποσέλιδου, αριθμού διαφάνειας και ημερομηνίας/ώρας ορατά.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Ορίστε κείμενο στη διαφάνεια master σημειώσεων και όλα τα θυγατρικά σύμβολα κεφαλίδας, υποσέλιδου και ημερομηνίας/ώρας.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Αλλάξτε τις ρυθμίσεις κεφαλίδας, υποσέλιδου, αριθμού διαφάνειας και ημερομηνίας/ώρας μόνο για την πρώτη διαφάνεια σημειώσεων.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Εξασφαλίστε ότι τα σύμβολα κεφαλίδας, υποσέλιδου, αριθμού διαφάνειας και ημερομηνίας/ώρας είναι ορατά.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Ορίστε κείμενο στα σύμβολα κεφαλίδας, υποσέλιδου και ημερομηνίας/ώρας της διαφάνειας σημειώσεων.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Αποθήκευση της παρουσίασης.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές ερωτήσεις**

**Μπορώ να προσθέσω «κεφαλίδα» σε κανονικές διαφάνειες;**

Στο PowerPoint, η «κεφαλίδα» υπάρχει μόνο για σημειώσεις και φυλλάδια· σε κανονικές διαφάνειες, τα υποστηριζόμενα στοιχεία είναι το υποσέλιδο, η ημερομηνία/ώρα και ο αριθμός διαφάνειας. Στο Aspose.Slides αυτό ανταπορράται στους ίδιους περιορισμούς: κεφαλίδα μόνο για Σημειώσεις/Φυλλάδιο, και στις διαφάνειες—Υποσέλιδο/ΗμερομηνίαΏρα/ΑριθμόςΔιαφάνειας.

**Τι γίνεται αν η διάταξη δεν περιέχει περιοχή υποσέλιδου—μπορώ να «ενεργοποιήσω» την ορατότητα του;**

Ναι. Ελέγξτε την ορατότητα μέσω του διαχειριστή κεφαλίδας/υποσέλιδου και ενεργοποιήστε την εάν χρειάζεται. Αυτοί οι δείκτες και μέθοδοι του API έχουν σχεδιαστεί για περιπτώσεις όπου το σύμβολο κράτησης θέσης λείπει ή είναι κρυφό.

**Πώς μπορώ να κάνω τον αριθμό διαφάνειας να ξεκινά από τιμή διαφορετική από το 1;**

Ορίστε τον [πρώτο αριθμό διαφάνειας](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/first_slide_number/) της παρουσίασης· μετά από αυτό, όλοι οι αριθμοί επαναϋπολογίζονται. Για παράδειγμα, μπορείτε να ξεκινήσετε από 0 ή 10 και να κρύψετε τον αριθμό στην διαφάνεια τίτλου.

**Τι συμβαίνει με τις κεφαλίδες/υποσέλιδα όταν εξάγονται σε PDF/εικόνες/HTML;**

Αποτυπώνονται ως κανονικά στοιχεία κειμένου της παρουσίασης. Δηλαδή, εάν τα στοιχεία είναι ορατά στις διαφάνειες/σελίδες σημειώσεων, θα εμφανιστούν επίσης στην έξοδο μορφής μαζί με το υπόλοιπο περιεχόμενο.