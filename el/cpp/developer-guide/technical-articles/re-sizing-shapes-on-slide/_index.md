---
title: Αλλαγή Μεγέθους Σχημάτων σε Διαφάνειες Παρουσίασης
type: docs
weight: 100
url: /el/cpp/re-sizing-shapes-on-slide/
keywords:
- αλλαγή μεγέθους σχήματος
- αλλαγή μεγέθους σχήματος
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Εύκολη αλλαγή μεγέθους σχημάτων σε διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides για C++—αυτοματοποιήστε τις προσαρμογές διάταξης διαφανειών και αυξήστε την παραγωγικότητα."
---
## **Επισκόπηση**

Μία από τις πιο συνηθισμένες ερωτήσεις των πελατών του Aspose.Slides for C++ είναι πώς να αλλάξουν το μέγεθος των σχημάτων έτσι ώστε, όταν αλλάζει το μέγεθος της διαφάνειας, τα δεδομένα να μην αποκόπτονται. Αυτό το σύντομο τεχνικό άρθρο δείχνει πώς να το κάνετε.

## **Αλλαγή Μεγέθους Σχημάτων**

Για να αποτρέψετε τα σχήματα να εκκεντρώνονται όταν αλλάζει το μέγεθος της διαφάνειας, ενημερώστε τη θέση και τις διαστάσεις κάθε σχήματος ώστε να ταιριάζουν με τη νέα διάταξη της διαφάνειας.

```cpp
// Φορτώστε το αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Get the original slide size.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Change the slide size without scaling existing shapes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Get the new slide size.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Resize and reposition shapes on every slide.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Κλιμακώστε το μέγεθος του σχήματος.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Κλιμακώστε τη θέση του σχήματος.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}} 
Εάν μια διαφάνεια περιέχει πίνακα, ο παραπάνω κώδικας δεν θα λειτουργήσει σωστά. Σε αυτήν την περίπτωση, κάθε κελί του πίνακα πρέπει να αλλάξει μέγεθος.
{{% /alert %}} 

Χρησιμοποιήστε τον παρακάτω κώδικα στην πλευρά σας για να αλλάξετε το μέγεθος των διαφανειών που περιέχουν πίνακες. Για τους πίνακες, ο καθορισμός του πλάτους ή του ύψους αποτελεί ειδική περίπτωση: πρέπει να προσαρμόσετε τα ύψη των μεμονωμένων σειρών και τα πλάτη των στηλών για να αλλάξετε το συνολικό μέγεθος του πίνακα.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Λάβετε το αρχικό μέγεθος της διαφάνειας.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Αλλάξτε το μέγεθος της διαφάνειας χωρίς κλιμάκωση των υπαρχόντων σχημάτων.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Λάβετε το νέο μέγεθος της διαφάνειας.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Κλιμακώστε το μέγεθος του σχήματος.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Κλιμακώστε τη θέση του σχήματος.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Κλιμακώστε το μέγεθος του σχήματος.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Κλιμακώστε τη θέση του σχήματος.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Κλιμακώστε το μέγεθος του σχήματος.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Κλιμακώστε τη θέση του σχήματος.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Συχνές Ερωτήσεις**

**Γιατί τα σχήματα παραμορφώνονται ή κόβονται μετά την αλλαγή μεγέθους μιας διαφάνειας;**

Όταν αλλάζετε το μέγεθος μιας διαφάνειας, τα σχήματα διατηρούν την αρχική τους θέση και μέγεθος, εκτός εάν η κλίμακα αλλάξει ρητά. Αυτό μπορεί να οδηγήσει στο περικοπή του περιεχομένου ή σε εκκεντρωμένα σχήματα.

**Λειτουργεί ο παρεχόμενος κώδικας για όλους τους τύπους σχημάτων;**

Το βασικό παράδειγμα λειτουργεί για τους περισσότερους τύπους σχημάτων (πλαίσια κειμένου, εικόνες, διαγράμματα κ.λπ.). Ωστόσο, για τους πίνακες, πρέπει να διαχειρίζεστε ξεχωριστά τις σειρές και τις στήλες, επειδή το ύψος και το πλάτος ενός πίνακα καθορίζονται από τις διαστάσεις των μεμονωμένων κελιών.

**Πώς αλλάζω το μέγεθος των πινάκων όταν αλλάζω το μέγεθος μιας διαφάνειας;**

Πρέπει να κάνετε βρόχο σε όλες τις σειρές και στήλες του πίνακα και να αλλάξετε το ύψος και το πλάτος τους ανάλογα, όπως φαίνεται στο δεύτερο παράδειγμα κώδικα.

**Θα λειτουργήσει αυτή η αλλαγή μεγέθους και για master διαφάνειες και layout διαφάνειες;**

Ναι, αλλά πρέπει επίσης να κάνετε βρόχο μέσω των [Κύριες διαφάνειες](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_masters/) και των [Διαφάνειες διάταξης](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_layoutslides/) και να εφαρμόσετε την ίδια λογική κλιμάκωσης στα σχήματά τους ώστε να εξασφαλιστεί η συνοχή σε όλη την παρουσίαση.

**Μπορώ να αλλάξω τον προσανατολισμό μιας διαφάνειας (κατακόρυφα/οριζόντια) μαζί με την αλλαγή μεγέθους;**

Ναι. Μπορείτε να χρησιμοποιήσετε το [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidesize/set_orientation/) για να αλλάξετε τον προσανατολισμό. Βεβαιωθείτε ότι έχετε ορίσει τη λογική κλιμάκωσης ανάλογα ώστε να διατηρηθεί η διάταξη.

**Υπάρχει όριο στο μέγεθος της διαφάνειας που μπορώ να ορίσω;**

Το Aspose.Slides υποστηρίζει προσαρμοσμένα μεγέθη, αλλά πολύ μεγάλα μεγέθη μπορεί να επηρεάσουν την απόδοση ή τη συμβατότητα με ορισμένες εκδόσεις του PowerPoint.

**Πώς μπορώ να αποτρέψω τα σχήματα με σταθερό λόγο διαστάσεων να παραμορφώνονται;**

Μπορείτε να ελέγξετε τη μέθοδο `get_AspectRatioLocked` του σχήματος πριν το κλιμακώσετε. Εάν είναι κλειδωμένη, προσαρμόστε το πλάτος ή το ύψος αναλογικά αντί να τα κλιμακώνετε ξεχωριστά.