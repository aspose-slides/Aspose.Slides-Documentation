---
title: Διαχείριση Στοιχείων Κράτησης Θέσης στην C++
linktitle: Διαχείριση Στοιχείων Κράτησης Θέσης
type: docs
weight: 10
url: /el/cpp/manage-placeholder/
keywords:
- στοιχείο κράτησης θέσης
- στοιχείο κράτησης θέσης κειμένου
- στοιχείο κράτησης θέσης εικόνας
- στοιχείο κράτησης θέσης διαγράμματος
- κείμενο προτροπής
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε άψογα τα στοιχεία κράτησης θέσης στο Aspose.Slides για C++: αντικαταστήστε το κείμενο, προσαρμόστε τις προτροπές και ορίστε τη διαφάνεια εικόνας στο PowerPoint και το OpenDocument."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε τα στοιχεία κράτησης θέσης παρουσιάσεων προγραμματιστικά. Αυτό το άρθρο εξηγεί πώς να βρίσκετε στοιχεία κράτησης θέσης στις διαφάνειες και να αλλάζετε το κείμενό τους, να ορίζετε προσαρμοσμένο κείμενο προτροπής για τα layouts των στοιχείων κράτησης θέσης και να προσαρμόζετε τη διαφάνεια μιας εικόνας που χρησιμοποιείται ως φόντο στοιχείου κράτησης θέσης. Περιλαμβάνει επίσης μια σύντομη ενότητα **Συχνές Ερωτήσεις** που διευκρινίζει τη διαφορά μεταξύ βασικών στοιχείων κράτησης θέσης και τοπικών σχημάτων, εξηγεί πώς οι αλλαγές στοιχείων κράτησης θέσης μπορούν να εφαρμοστούν μέσω layouts ή master, και παραπέμπει στη διαχείριση των στοιχείων κράτησης θέσης κεφαλίδας και υποστίγματος.

## **Αλλαγή κειμένου σε στοιχείο κράτησης θέσης**
Χρησιμοποιώντας το [Aspose.Slides for C++](/slides/el/cpp/), μπορείτε να εντοπίσετε και να τροποποιήσετε στοιχεία κράτησης θέσης στις διαφάνειες των παρουσιάσεων. Το Aspose.Slides σας επιτρέπει να κάνετε αλλαγές στο κείμενο ενός στοιχείου κράτησης θέσης.

**Προαπαιτούμενο**: Χρειάζεστε μια παρουσίαση που περιέχει ένα στοιχείο κράτησης θέσης. Μπορείτε να δημιουργήσετε μια τέτοια παρουσίαση με την τυπική εφαρμογή Microsoft PowerPoint.

Αυτή είναι η διαδικασία χρήσης του Aspose.Slides για την αντικατάσταση του κειμένου στο στοιχείο κράτησης θέσης σε αυτήν την παρουσίαση:

1. Δημιουργήστε μια παρουσίαση της κλάσης [`Presentation`](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation/) και περάστε την παρουσίαση ως όρισμα.
2. Λάβετε μια αναφορά σε διαφάνεια μέσω του δείκτη της.
3. Διατρέξτε τα σχήματα για να εντοπίσετε το στοιχείο κράτησης θέσης.
4. Μετατρέψτε το σχήμα του στοιχείου κράτησης θέσης σε ένα [`AutoShape`](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.auto_shape/) και αλλάξτε το κείμενο χρησιμοποιώντας το [`TextFrame`](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.text_frame/) που συσχετίζεται με το [`AutoShape`](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.auto_shape/).
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας C++ δείχνει πώς να αλλάξετε το κείμενο σε ένα στοιχείο κράτησης θέσης:

```c++
// Η διαδρομή προς το φάκελο εγγράφων.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Φορτώνει την επιθυμητή παρουσίαση
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Προσεγγίζει την πρώτη διαφάνεια
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Προσεγγίζει το πρώτο και το δεύτερο στοιχείο κράτησης θέσης στη διαφάνεια και το μετατρέπει σε AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// Αποθηκεύει την παρουσίαση στο δίσκο
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ορισμός κειμένου προτροπής σε στοιχείο κράτησης θέσης**
Τα τυπικά και προ-σχεδιασμένα layouts περιέχουν κείμενα προτροπής στοιχείων κράτησης θέσης, όπως ***Κάντε κλικ για προσθήκη τίτλου*** ή ***Κάντε κλικ για προσθήκη υποτίτλου***. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να εισάγετε τα προτιμώμενα κείμενα προτροπής σας στα layouts των στοιχείων κράτησης θέσης.

Αυτός ο κώδικας C++ σας δείχνει πώς να ορίσετε το κείμενο προτροπής σε ένα στοιχείο κράτησης θέσης:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Όταν δεν υπάρχει κείμενο σε αυτό, το PowerPoint εμφανίζει "Click to add title". 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Κάνει το ίδιο για το υπότιτλο.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ορισμός διαφάνειας εικόνας στοιχείου κράτησης θέσης**

Το Aspose.Slides σας επιτρέπει να ορίσετε τη διαφάνεια της εικόνας φόντου σε ένα στοιχείο κράτησης θέσης κειμένου. Ρυθμίζοντας τη διαφάνεια της εικόνας σε ένα τέτοιο πλαίσιο, μπορείτε να κάνετε το κείμενο ή την εικόνα να ξεχωρίζουν (ανάλογα με τα χρώματα του κειμένου και της εικόνας).

Αυτός ο κώδικας C++ δείχνει πώς να ορίσετε τη διαφάνεια για μια εικόνα φόντου (μέσα σε σχήμα):

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```

## **Συχνές Ερωτήσεις**

**Τι είναι ένα βασικό στοιχείο κράτησης θέσης και πώς διαφέρει από ένα τοπικό σχήμα σε μια διαφάνεια;**

Ένα βασικό στοιχείο κράτησης θέσης είναι το αρχικό σχήμα σε ένα layout ή master από το οποίο κληρονομεί το σχήμα της διαφάνειας — τύπος, θέση και κάποιες μορφοποιήσεις προέρχονται από αυτό. Ένα τοπικό σχήμα είναι ανεξάρτητο· εάν δεν υπάρχει βασικό στοιχείο κράτησης θέσης, η κληρονομικότητα δεν εφαρμόζεται.

**Πώς μπορώ να ενημερώσω όλους τους τίτλους ή τις λεζάντες σε ολόκληρη την παρουσίαση χωρίς να επαναλαμβάνομαι σε κάθε διαφάνεια;**

Επεξεργαστείτε το αντίστοιχο στοιχείο κράτησης θέσης στο layout ή στο master. Οι διαφάνειες που βασίζονται σε αυτά τα layouts/αυτό το master θα κληρονομήσουν αυτόματα την αλλαγή.

**Πώς ελέγχω τα τυπικά στοιχεία κράτησης θέσης κεφαλίδας/υποστίγματος — ημερομηνία & ώρα, αριθμός διαφάνειας και κείμενο υποστίγματος;**

Χρησιμοποιήστε τους διαχειριστές HeaderFooter στο κατάλληλο επίπεδο (κανονικές διαφάνειες, layouts, master, σημειώσεις/φυλλάδια) για να ενεργοποιήσετε ή να απενεργοποιήσετε αυτά τα στοιχεία κράτησης θέσης και να ορίσετε το περιεχόμενό τους.