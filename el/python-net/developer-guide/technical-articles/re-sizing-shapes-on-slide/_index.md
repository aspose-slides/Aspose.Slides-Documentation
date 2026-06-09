---
title: Αλλαγή μεγέθους σχημάτων σε παρουσιάσεις με Python
linktitle: Αλλαγή μεγέθους σχημάτων
type: docs
weight: 130
url: /el/python-net/re-sizing-shapes-on-slide/
keywords:
- αλλαγή μεγέθους σχήματος
- αλλαγή μεγέθους σχήματος
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Αλλάξτε εύκολα το μέγεθος των σχημάτων σε διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω .NET—αυτοματοποιήστε τις προσαρμογές διάταξης διαφανειών και αυξήστε την παραγωγικότητα."
---
## **Επισκόπηση**

Μία από τις πιο συχνές ερωτήσεις των πελατών του Aspose.Slides for Python είναι πώς να αλλάξετε το μέγεθος των σχημάτων ώστε, όταν αλλάζει το μέγεθος της διαφάνειας, τα δεδομένα να μην περικοπούν. Αυτό το σύντομο τεχνικό άρθρο δείχνει πώς να το κάνετε.

## **Αλλαγή Μεγέθους Σχημάτων**

Για να αποτρέψετε την εκτροπή των σχημάτων όταν αλλάζει το μέγεθος της διαφάνειας, ενημερώστε τη θέση και τις διαστάσεις κάθε σχήματος ώστε να ταιριάζουν με τη νέα διάταξη της διαφάνειας.

```py
import aspose.slides as slides

# Φορτώνει το αρχείο παρουσίασης.
with slides.Presentation("sample.pptx") as presentation:
    # Λαμβάνει το αρχικό μέγεθος της διαφάνειας.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Αλλάζει το μέγεθος της διαφάνειας χωρίς κλιμάκωση των υπαρχόντων σχημάτων.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Λαμβάνει το νέο μέγεθος της διαφάνειας.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Αλλάζει το μέγεθος και τη θέση των σχημάτων σε κάθε διαφάνεια.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # Κλιμακώνει το μέγεθος του σχήματος.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Κλιμακώνει τη θέση του σχήματος.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
Εάν μια διαφάνεια περιέχει πίνακα, ο παραπάνω κώδικας δεν θα λειτουργήσει σωστά. Σε αυτήν την περίπτωση, κάθε κελί του πίνακα πρέπει να αλλάξει μέγεθος.
{{% /alert %}} 

Χρησιμοποιήστε τον παρακάτω κώδικα από την πλευρά σας για να αλλάξετε το μέγεθος διαφανειών που περιέχουν πίνακες. Για πίνακες, ο ορισμός του πλάτους ή του ύψους αποτελεί ειδική περίπτωση: πρέπει να προσαρμόσετε τα ύψη των μεμονωμένων γραμμών και τα πλάτη των στηλών για να αλλάξετε το συνολικό μέγεθος του πίνακα.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Λαμβάνει το αρχικό μέγεθος της διαφάνειας.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Αλλάζει το μέγεθος της διαφάνειας χωρίς κλιμάκωση των υπαρχόντων σχημάτων.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Λαμβάνει το νέο μέγεθος της διαφάνειας.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # Κλιμακώνει το μέγεθος του σχήματος.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Κλιμακώνει τη θέση του σχήματος.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # Κλιμακώνει το μέγεθος του σχήματος.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # Κλιμακώνει τη θέση του σχήματος.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Κλιμακώνει το μέγεθος του σχήματος.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Κλιμακώνει τη θέση του σχήματος.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Γιατί τα σχήματα παραμορφώνονται ή κόβονται μετά την αλλαγή μεγέθους μιας διαφάνειας;**

Κατά την αλλαγή μεγέθους μιας διαφάνειας, τα σχήματα διατηρούν τη αρχική τους θέση και μέγεθος εκτός εάν η κλίμακα αλλάξει ρητά. Αυτό μπορεί να οδηγήσει σε περικοπή του περιεχομένου ή σε διαστρεβλωση των σχημάτων.

**Λειτουργεί ο παρεχόμενος κώδικας για όλους τους τύπους σχημάτων;**

Το βασικό παράδειγμα λειτουργεί για τους περισσότερους τύπους σχημάτων (πλαίσια κειμένου, εικόνες, γραφήματα κ.λπ.). Ωστόσο, για πίνακες, πρέπει να διαχειριστείτε ξεχωριστά τις γραμμές και τις στήλες, καθώς το ύψος και το πλάτος ενός πίνακα καθορίζονται από τις διαστάσεις των μεμονωμένων κελιών.

**Πώς μπορώ να αλλάξω το μέγεθος των πινάκων όταν αλλάζω το μέγεθος μιας διαφάνειας;**

Πρέπει να κάνετε επανάληψη σε όλες τις γραμμές και στήλες του πίνακα και να αλλάξετε το ύψος και το πλάτος τους ανάλογα, όπως φαίνεται στο δεύτερο παράδειγμα κώδικα.

**Θα λειτουργήσει αυτή η αλλαγή μεγέθους και για κύριες διαφάνειες (master) και διαφάνειες διάταξης;**

Ναι, αλλά θα πρέπει επίσης να κάνετε επανάληψη στα [Masters](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/masters/) και στα [Layout slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/layout_slides/) και να εφαρμόσετε την ίδια λογική κλιμάκωσης στα σχήματά τους για να εξασφαλίσετε συνέπεια σε όλη την παρουσίαση.

**Μπορώ να αλλάξω τον προσανατολισμό μιας διαφάνειας (πορτραίτο/τοπίο) μαζί με την αλλαγή μεγέθους;**

Ναι. Μπορείτε να χρησιμοποιήσετε το [presentation.slide_size.orientation](https://reference.aspose.com/slides/el/python-net/aspose.slides/islidesize/orientation/) για να αλλάξετε τον προσανατολισμό. Βεβαιωθείτε ότι έχετε ορίσει τη λογική κλιμάκωσης αναλόγως ώστε να διατηρείται η διάταξη.

**Υπάρχει όριο στο μέγεθος διαφάνειας που μπορώ να ορίσω;**

Το Aspose.Slides υποστηρίζει προσαρμοσμένα μεγέθη, αλλά πολύ μεγάλα μεγέθη μπορεί να επηρεάσουν την απόδοση ή τη συμβατότητα με ορισμένες εκδόσεις του PowerPoint.

**Πώς μπορώ να αποτρέψω τα σχήματα με σταθερό λόγο διαστάσεων να παραμορφωθούν;**

Μπορείτε να ελέγξετε την ιδιότητα `aspect_ratio_locked` του σχήματος πριν από την κλιμάκωση. Αν είναι κλειδωμένη, προσαρμόστε το πλάτος ή το ύψος αναλογικά αντί να τα κλιμακώσετε ξεχωριστά.