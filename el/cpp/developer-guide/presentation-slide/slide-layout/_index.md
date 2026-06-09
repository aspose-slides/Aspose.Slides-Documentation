---
title: Εφαρμογή ή Αλλαγή διατάξεων διαφάνειας σε C++
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/cpp/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- placeholder
- σχεδίαση παρουσίασης
- σχεδίαση διαφάνειας
- αχρησιμοποίητη διάταξη
- ορατότητα υποσέλιδου
- διαφάνεια τίτλου
- τίτλος και περιεχόμενο
- επικεφαλίδα ενότητας
- δύο περιεχόμενα
- σύγκριση
- μόνο τίτλος
- κενή διάταξη
- περιεχόμενο με λεζάντα
- εικόνα με λεζάντα
- τίτλος και κάθετο κείμενο
- κάθετος τίτλος και κείμενο
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε και προσαρμόστε τις διατάξεις διαφάνειας στο Aspose.Slides για C++. Εξερευνήστε τους τύπους διατάξεων, τον έλεγχο των placeholder και την ορατότητα του υποσέλιδου μέσω παραδειγμάτων κώδικα C++."
---
## **Introduction**

Ένα διάταγμα διαφάνειας ορίζει τη διάταξη των πλαισίων placeholder και τη μορφοποίηση του περιεχομένου σε μια διαφάνεια. Ελέγχει ποια placeholders είναι διαθέσιμα και πού εμφανίζονται. Τα διατάγματα διαφάνειας σας βοηθούν να σχεδιάζετε παρουσιάσεις γρήγορα και συνεπώς—είτε δημιουργείτε κάτι απλό είτε πιο σύνθετο. Μερικά από τα πιο συνηθισμένα διατάγματα διαφάνειας στο PowerPoint περιλαμβάνουν:

**Title Slide layout** – Περιλαμβάνει δύο placeholders κειμένου: ένα για τον τίτλο και ένα για τον υπότιτλο.

**Title and Content layout** – Διαθέτει ένα μικρότερο placeholder τίτλου στην κορυφή και ένα μεγαλύτερο κάτω για το κύριο περιεχόμενο (όπως κείμενο, κουκίδες, διαγράμματα, εικόνες και άλλα).

**Blank layout** – Δεν περιέχει placeholders, δίνοντάς σας πλήρη έλεγχο για να σχεδιάσετε τη διαφάνεια από την αρχή.

Οι διατάξεις διαφάνειας αποτελούν μέρος ενός slide master, που είναι η ανώτερη διαφάνεια που ορίζει τα στυλ διατάξεων για την παρουσίαση. Μπορείτε να έχετε πρόσβαση και να τροποποιήσετε τις διατάξεις διαφάνειας μέσω του slide master—είτε με βάση τον τύπο, το όνομα ή το μοναδικό αναγνωριστικό τους. Εναλλακτικά, μπορείτε να επεξεργαστείτε απευθείας μια συγκεκριμένη διάταξη διαφάνειας μέσα στην παρουσίαση.

Για να εργαστείτε με διατάξεις διαφάνειας στο Aspose.Slides for Android, μπορείτε να χρησιμοποιήσετε:

- Μεθόδους όπως [get_LayoutSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_layoutslides/) και [get_Masters](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_masters/) στην κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/)
- Τύπους όπως [ILayoutSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/), και [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Πληροφορίες" color="info" %}}
Για να μάθετε περισσότερα σχετικά με την εργασία με κύριες διαφάνειες, δείτε το άρθρο [Slide Master](/slides/el/cpp/slide-master/).
{{% /alert %}}

## **Add Slide Layouts to Presentations**

Για να προσαρμόσετε την εμφάνιση και τη δομή των διαφανειών σας, ίσως χρειαστεί να προσθέσετε νέες διατάξεις διαφάνειας σε μια παρουσίαση. Το Aspose.Slides for Android σάς επιτρέπει να ελέγξετε εάν μια συγκεκριμένη διάταξη υπάρχει ήδη, να προσθέσετε μια νέα εάν χρειάζεται, και να τη χρησιμοποιήσετε για την εισαγωγή διαφανειών με βάση αυτή τη διάταξη.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Πρόσβαση στο [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterlayoutslidecollection/).
1. Ελέγξτε εάν η επιθυμητή διάταξη διαφάνειας υπάρχει ήδη στη συλλογή. Αν όχι, προσθέστε τη διάταξη που χρειάζεστε.
1. Προσθέστε μια κενή διαφάνεια βασισμένη στη νέα διάταξη διαφάνειας.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C++ δείχνει πώς να προσθέσετε μια διάταξη διαφάνειας σε μια παρουσίαση PowerPoint:

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // Μία κατάσταση όπου η παρουσίαση δεν περιέχει όλους τους τύπους διατάξεων.
    // Το αρχείο παρουσίασης περιέχει μόνο τύπους διατάξεων Blank και Custom.
    // Ωστόσο, οι διατάξεις διαφάνειας με προσαρμοσμένους τύπους μπορεί να έχουν αναγνωρίσιμα ονόματα,
    // όπως "Title", "Title and Content", κ.λπ., τα οποία μπορούν να χρησιμοποιηθούν για την επιλογή διάταξης διαφάνειας.
    // Μπορείτε επίσης να βασιστείτε σε ένα σύνολο τύπων σχήματος placeholder.
    // Για παράδειγμα, μια διαφάνεια Τίτλου πρέπει να έχει μόνο τον τύπο placeholder Title, κ.τ.λ.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Προσθέστε μια κενή διαφάνεια χρησιμοποιώντας τη διατάξη διαφάνειας που προστέθηκε.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Αποθηκεύστε την παρουσίαση στο δίσκο.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Remove Unused Layout Slides**

Το Aspose.Slides παρέχει τη μέθοδο [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) από την κλάση [Compress](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/) για να διαγράψετε ανεπιθύμητες και μη χρησιμοποιούμενες διατάξεις διαφάνειας.

Ο παρακάτω κώδικας C++ δείχνει πώς να αφαιρέσετε μια διάταξη διαφάνειας από μια παρουσίαση PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Add Placeholders To Slide Layouts**

Το Aspose.Slides παρέχει τη μέθοδο [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/), η οποία επιτρέπει την προσθήκη νέων placeholders σε μια διάταξη διαφάνειας.

Αυτός ο διαχειριστής περιέχει μεθόδους για τους παρακάτω τύπους placeholders:

| PowerPoint Placeholder | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilayoutplaceholdermanager/) Μέθοδος |
| ---------------------- | ------------------------------------------------------------ |
| ![Περιεχόμενο](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Περιεχόμενο (Κατακόρυφο)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Κείμενο](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Κείμενο (Κατακόρυφο)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Εικόνα](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Διάγραμμα](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Πίνακας](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Μέσα](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Διαδικτυακή Εικόνα](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Ο παρακάτω κώδικας C++ δείχνει πώς να προσθέσετε νέα σχήματα placeholder στη κενή διάταξη διαφάνειας:

```cpp
auto presentation = MakeObject<Presentation>();

// Λάβετε τη κενή διάταξη διαφάνειας.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Λάβετε το διαχειριστή placeholder της διάταξης διαφάνειας.
auto placeholderManager = layout->get_PlaceholderManager();

// Προσθέστε διαφορετικά placeholders στη κενή διάταξη διαφάνειας.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Προσθέστε μια νέα διαφάνεια με την κενή διάταξη.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι placeholders στη διάταξη διαφάνειας](add_placeholders.png)

## **Set Footer Visibility for a Layout Slide**

Στις παρουσιάσεις PowerPoint, τα στοιχεία του υποσέλιδου όπως η ημερομηνία, ο αριθμός διαφάνειας και το προσαρμοσμένο κείμενο μπορούν να εμφανίζονται ή να κρύβονται ανάλογα με τη διάταξη διαφάνειας. Το Aspose.Slides for Android σάς επιτρέπει να ελέγξετε την ορατότητα αυτών των placeholders υποσέλιδου. Αυτό είναι χρήσιμο όταν θέλετε ορισμένες διατάξεις να εμφανίζουν πληροφορίες υποσέλιδου ενώ άλλες παραμένουν καθαρές.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε διάταξη διαφάνειας με βάση το δείκτη της.
1. Ορίστε το placeholder υποσέλιδου της διαφάνειας σε ορατό.
1. Ορίστε το placeholder αριθμού διαφάνειας σε ορατό.
1. Ορίστε το placeholder ημερομηνίας/ώρας σε ορατό.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C++ δείχνει πώς να ορίσετε την ορατότητα του υποσέλιδου μιας διαφάνειας και να εκτελέσετε σχετικές εργασίες:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```

## **Set Child Footer Visibility for a Slide**

Στις παρουσιάσεις PowerPoint, τα στοιχεία του υποσέλιδου όπως η ημερομηνία, ο αριθμός διαφάνειας και το προσαρμοσμένο κείμενο μπορούν να ελεγχούν σε επίπεδο κύριας διαφάνειας για να διασφαλιστεί η συνέπεια σε όλες τις διατάξεις. Το Aspose.Slides for Android σας επιτρέπει να ορίσετε την ορατότητα και το περιεχόμενο αυτών των placeholders υποσέλιδου στη κύρια διαφάνεια και να διαδώσετε αυτές τις ρυθμίσεις σε όλες τις παιδικές διατάξεις διαφάνειας. Αυτή η προσέγγιση εξασφαλίζει ενιαίες πληροφορίες υποσέλιδου σε όλη την παρουσίασή σας.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε μια αναφορά στη κύρια διαφάνεια με βάση το δείκτη της.
1. Ορίστε τα placeholders υποσέλιδου της κύριας διαφάνειας και όλων των παιδικών διαφάνειων σε ορατό.
1. Ορίστε τα placeholders αριθμού διαφάνειας της κύριας διαφάνειας και όλων των παιδικών διαφάνειων σε ορατό.
1. Ορίστε τα placeholders ημερομηνίας/ώρας της κύριας διαφάνειας και όλων των παιδικών διαφάνειων σε ορατό.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C++ δείχνει αυτή τη λειτουργία:

```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Ποια είναι η διαφορά μεταξύ κύριας διαφάνειας και διάταξης διαφάνειας;**

Μια κύρια διαφάνεια ορίζει το γενικό θέμα και τις προεπιλεγμένες μορφοποιήσεις, ενώ οι διατάξεις διαφάνειας καθορίζουν συγκεκριμένες διατάξεις placeholders για διαφορετικούς τύπους περιεχομένου.

**Μπορώ να αντιγράψω μια διάταξη διαφάνειας από μια παρουσίαση σε μια άλλη;**

Ναι, μπορείτε να κλωνοποιήσετε μια διάταξη διαφάνειας από τη συλλογή διατάξεων μιας παρουσίασης, προσβάσιμη μέσω της μεθόδου [get_LayoutSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_layoutslides/), και να την εισάγετε σε άλλη παρουσίαση χρησιμοποιώντας τη μέθοδο `AddClone`.

**Τι συμβαίνει αν διαγράψω μια διάταξη διαφάνειας που χρησιμοποιείται ακόμα από μια διαφάνεια;**

Αν προσπαθήσετε να διαγράψετε μια διάταξη διαφάνειας που είναι ακόμη αναφορά από τουλάχιστον μία διαφάνεια στην παρουσίαση, το Aspose.Slides θα ρίξει ένα [PptxEditException](https://reference.aspose.com/slides/el/cpp/aspose.slides/pptxeditexception/). Για να το αποφύγετε, χρησιμοποιήστε τη [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) η οποία αφαιρεί με ασφάλεια μόνο τις διατάξεις διαφάνειας που δεν χρησιμοποιούνται.