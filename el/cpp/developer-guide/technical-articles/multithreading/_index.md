---
title: Πολυνηματισμός στο Aspose.Slides για C++
linktitle: Πολυνηματισμός
type: docs
weight: 200
url: /el/cpp/multithreading/
keywords:
- πολυνηματισμός
- πολλαπλά νήματα
- παράλληλη εργασία
- μετατροπή διαφανειών
- διαφάνειες σε εικόνες
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Ο πολυνηματισμός στο Aspose.Slides για C++ ενισχύει την επεξεργασία PowerPoint και OpenDocument. Ανακαλύψτε τις καλύτερες πρακτικές για αποτελεσματικές ροές εργασίας παρουσίασης."
---
## **Εισαγωγή**

Ενώ η παράλληλη εργασία με παρουσιάσεις είναι δυνατή (εκτός από την ανάλυση/φόρτωση/κλωνοποίηση) και τα πάντα πηγαίνουν καλά (τις περισσότερες φορές), υπάρχει μια μικρή πιθανότητα να λάβετε εσφαλμένα αποτελέσματα όταν χρησιμοποιείτε τη βιβλιοθήκη σε πολλαπλά νήματα.

Συνιστούμε ανεπιφύλακτα **να μην** χρησιμοποιείτε μια μοναδική [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) παρουσία σε περιβάλλον πολλαπλών νημάτων, επειδή ενδέχεται να οδηγήσει σε απρόβλεπτα σφάλματα ή αποτυχίες που δεν εντοπίζονται εύκολα.

Δεν είναι **ασφαλές** να φορτώνετε, αποθηκεύετε και/ή κλωνοποιείτε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) σε πολλαπλά νήματα. Τέτοιες λειτουργίες **δεν** υποστηρίζονται. Εάν χρειάζεται να εκτελέσετε τέτοια καθήκοντα, πρέπει να παραλληλίσετε τις λειτουργίες χρησιμοποιώντας πολλαπλές διαδικασίες μονής εκτέλεσης· και καθεμία από αυτές τις διαδικασίες πρέπει να χρησιμοποιεί τη δική της παρουσία παρουσίασης.

## **Μετατροπή Διαφανειών Παρουσίασης σε Εικόνες Παράλληλα**

Ας υποθέσουμε ότι θέλουμε να μετατρέψουμε όλες τις διαφάνειες από μια παρουσίαση PowerPoint σε εικόνες PNG παράλληλα. Δεδομένου ότι δεν είναι ασφαλές να χρησιμοποιήσετε μία μοναδική παρουσία `Presentation` σε πολλαπλά νήματα, χωρίζουμε τις διαφάνειες της παρουσίασης σε ξεχωριστές παρουσιάσεις και μετατρέπουμε τις διαφάνειες σε εικόνες παράλληλα, χρησιμοποιώντας κάθε παρουσία σε ξεχωριστό νήμα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να το κάνετε.

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Αποσπάστε τη διαφάνεια i σε ξεχωριστή παρουσίαση.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // Μετατρέψτε τη διαφάνεια σε εικόνα σε ξεχωριστό έργο.
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// Περιμένετε να ολοκληρωθούν όλα τα έργα.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```

## **Συχνές Ερωτήσεις**

**Πρέπει να εκτελέσω τη ρύθμιση της άδειας σε κάθε νήμα;**

Όχι. Είναι αρκετό να το κάνετε μία φορά ανά διεργασία/τομέα εφαρμογής πριν ξεκινήσουν τα νήματα. Εάν η [ρύθμιση της άδειας](/slides/el/cpp/licensing/) μπορεί να κληθεί ταυτόχρονα (για παράδειγμα, κατά την υστέρηση αρχικοποίησης), συγχρονίστε αυτήν την κλήση επειδή η μέθοδος ρύθμισης της άδειας δεν είναι ασφαλής ως προς τα νήματα.

**Μπορώ να μεταβιβάσω αντικείμενα `Presentation` ή `Slide` μεταξύ νημάτων;**

Η μεταφορά «ζωντανών» αντικειμένων παρουσίασης μεταξύ νημάτων δεν συνιστάται: χρησιμοποιήστε ανεξάρτητες παρουσίες ανά νήμα ή προδημιουργήστε ξεχωριστές παρουσιάσεις/υποδοχείς διαφανειών για κάθε νήμα. Αυτή η προσέγγιση ακολουθεί τη γενική σύσταση να μην μοιράζεστε μία μοναδική παρουσία παρουσίασης μεταξύ νημάτων.

**Είναι ασφαλές να παραλληλοποιήσετε την εξαγωγή σε διαφορετικές μορφές (PDF, HTML, εικόνες) εφόσον κάθε νήμα έχει τη δική του παρουσία `Presentation`;**

Ναι. Με ανεξάρτητες παρουσίες και ξεχωριστές διαδρομές εξόδου, τέτοιες εργασίες συνήθως παραλληλοποιούνται σωστά· αποφύγετε οποιαδήποτε κοινά αντικείμενα παρουσίασης και κοινές ροές I/O.

**Τι πρέπει να κάνω με τις παγκόσμιες ρυθμίσεις γραμματοσειρών (φάκελοι, υποκαταστάσεις) σε πολυνηματική εκτέλεση;**

Αρχικοποιήστε όλες τις παγκόσμιες ρυθμίσεις γραμματοσειρών πριν ξεκινήσετε τα νήματα και μην τις αλλάζετε κατά τη διάρκεια της παράλληλης εργασίας. Αυτό εξαλείφει τους αγώνες πρόσβασης σε κοινούς πόρους γραμματοσειρών.