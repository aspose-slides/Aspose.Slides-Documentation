---
title: Διαχείριση master διαφάνειας παρουσίασης σε C++
linktitle: Master Διαφάνειας
type: docs
weight: 80
url: /el/cpp/slide-master/
keywords:
- master διαφάνειας
- master διαφάνειας
- PPT master διαφάνειας
- πολλαπλές master διαφάνειες
- σύγκριση master διαφανειών
- φόντο
- σύμβολο κράτησης
- κλωνοποίηση master διαφάνειας
- αντιγραφή master διαφάνειας
- δημιουργία διπλότυπης master διαφάνειας
- αχρησιμοποίητη master διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε τα master διαφάνειων στο Aspose.Slides για C++: πρόσβαση, επεξεργασία, κλωνοποίηση, σύγκριση και αφαίρεση master διαφανειών σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Ένας **slide master** ορίζει κοινές ρυθμίσεις σχεδίασης για μια ομάδα διαφανειών. Μπορεί να περιέχει κοινά σχήματα, λογότυπα, φόντα, στυλ κειμένου, ρυθμίσεις θέματος και ρυθμίσεις υποσέλιδου. Στο PowerPoint, η επεξεργασία ενός slide master είναι ο συνηθισμένος τρόπος για να διατηρείται μια παρουσίαση συνεπής χωρίς να επαναλαμβάνεται η ίδια μορφοποίηση σε κάθε διαφάνεια.

Το Aspose.Slides για C++ υποστηρίζει το ίδιο μοντέλο. Μια παρουσίαση μπορεί να περιέχει μία ή περισσότερες master διαφάνειες, και κάθε master διαφάνεια μπορεί να περιέχει πολλές layout διαφάνειες. Οι κανονικές διαφάνειες συνήθως δεν αναφέρονται άμεσα σε μια master διαφάνεια. Αντίθετα, μια κανονική διαφάνεια χρησιμοποιεί μια layout διαφάνεια, και αυτή η layout διαφάνεια ανήκει σε μια master διαφάνεια.

Η ιεραρχία είναι:

1. **Slide master** - ορίζει το κοινό σχέδιο και το θέμα.
1. **Layout slide** - ορίζει μια συγκεκριμένη διάταξη placeholders και μορφοποίησης επιπέδου layout.
1. **Normal slide** - περιέχει το πραγματικό περιεχόμενο της παρουσίασης και χρησιμοποιεί μία layout διαφάνεια.

![Η ιεραρχία των master διαφανειών, layout διαφανειών και κανονικών διαφανειών](slide-master_2.jpg)

Στο Aspose.Slides, ένα slide master αντιπροσωπεύεται από το interface [IMasterSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslide/). Όλες οι master διαφάνειες σε μια παρουσίαση είναι διαθέσιμες μέσω της συλλογής [Presentation::get_Masters](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_masters/) , η οποία υλοποιεί το [IMasterSlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Όταν η ίδια ιδιότητα ορίζεται σε περισσότερα από ένα επίπεδα, το πιο συγκεκριμένο επίπεδο έχει προτεραιότητα. Για παράδειγμα, εάν μια master διαφάνεια και μια layout διαφάνεια ορίζουν και τα δύο φόντο, οι διαφάνειες που βασίζονται σε αυτή τη διάταξη χρησιμοποιούν το φόντο της διάταξης. Για περισσότερες πληροφορίες σχετικά με τις layout διαφάνειες, δείτε [Εφαρμογή ή Αλλαγή Διατάξεων Διαφάνειας](/slides/el/cpp/slide-layout/).
{{% /alert %}}

## **Πρόσβαση σε Slide Masters**

Στο PowerPoint, μπορείτε να ανοίξετε την προβολή Slide Master από **View** > **Slide Master**.

![Η εντολή Slide Master στην καρτέλα View του PowerPoint](slide-master_3.jpg)

Στο Aspose.Slides, χρησιμοποιήστε τη συλλογή `get_Masters()` για πρόσβαση στις master διαφάνειες:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Μπορείτε επίσης να λάβετε τη master διαφάνεια που χρησιμοποιείται από μια κανονική διαφάνεια μέσω της διάταξής της:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Τι Περιέχει Ένα Slide Master**

Μια master διαφάνεια είναι ένα αντικείμενο παρόμοιο με διαφάνεια. Υλοποιεί το [IBaseSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseslide/), έτσι αποκαλύπτει πολλές από τις ίδιες ιδιότητες διαφάνειας που χρησιμοποιούνται από τις κανονικές και τις layout διαφάνειες. Τα μέλη ειδικά για τη master εμφανίζονται στη σελίδα API του [IMasterSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslide/).

Κοινώς χρησιμοποιημένα μέλη master διαφάνειας περιλαμβάνουν:

| Μέλος | Σκοπός |
| --- | --- |
| `get_Background()` | Ορίζει το φόντο της διαφάνειας σε επίπεδο master. |
| `get_Shapes()` | Αποθηκεύει τα σχήματα που τοποθετούνται στη master, όπως λογότυπα, πλαίσια εικόνας και κοινό κείμενο. |
| `get_LayoutSlides()` | Αποθηκεύει τις layout διαφάνειες που ανήκουν στη master. |
| `get_ThemeManager()` | Παρέχει πρόσβαση στα API του θέματος της master. |
| `get_HeaderFooterManager()` | Έλεγχο κεφαλίδων, υποσέλιδων, ημερομηνιών και αριθμών διαφανειών για τη master και τις θυγατρικές της layout. |
| `GetDependingSlides()` | Επιστρέφει τις κανονικές διαφάνειες που εξαρτώνται από τη master μέσω των layout τους. |

## **Προσθήκη Εικόνας σε Slide Master**

Όταν προσθέτετε μια εικόνα σε μια master διαφάνεια, αυτή εμφανίζεται στις διαφάνειες που χρησιμοποιούν layout από τη συγκεκριμένη master. Αυτό είναι χρήσιμο για λογότυπα, υδατογραφήματα, διακοσμητικές ζώνες και άλλα επαναλαμβανόμενα οπτικά στοιχεία.

Το παρακάτω παράδειγμα προσθέτει ένα λογότυπο στην πρώτη master διαφάνεια:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Για περισσότερες πληροφορίες σχετικά με πλαίσια εικόνας, δείτε [Πλαίσιο Εικόνας](/slides/el/cpp/picture-frame/).

## **Εργασία με Placeholders**

Τα placeholders ορίζονται συνήθως στις layout διαφάνειες. Η master διαφάνεια παρέχει το κοινό στυλ και το θέμα που κληρονομούν αυτές οι layout, ενώ κάθε layout αποφασίζει ποια placeholders είναι διαθέσιμα και πού τοποθετούνται.

Στο PowerPoint, οι εντολές placeholder είναι διαθέσιμες στην προβολή Slide Master.

![Η εντολή Insert Placeholder στην προβολή Slide Master του PowerPoint](slide-master_5.png)

Για να προσθέσετε νέα placeholders με Aspose.Slides, εργαστείτε με τη layout διαφάνεια που ανήκει στη master:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Μπορείτε επίσης να μορφοποιήσετε σχήματα placeholder που υπάρχουν ήδη σε μια master διαφάνεια. Το παρακάτω παράδειγμα βρίσκει το placeholder του τίτλου και εφαρμόζει μια γραμμική διαβάθμιση:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Μορφοποιημένο placeholder τίτλου που κληρονομείται από κανονικές διαφάνειες](slide-master_8.png)

Για περισσότερες επιλογές placeholder και μορφοποίησης κειμένου, δείτε [Ορισμός Κειμένου Προτροπής σε Placeholder](/slides/el/cpp/manage-placeholder/) και [Μορφοποίηση Κειμένου](/slides/el/cpp/text-formatting/).

## **Αλλαγή Φόντου Slide Master**

Ένα φόντο master κληρονομείται από τις layout και τις διαφάνειες που δεν το παρακάμπτουν. Το παρακάτω παράδειγμα ορίζει ένα συμπαγές χρώμα φόντου για την πρώτη master διαφάνεια:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Για συναφή θέματα, δείτε [Φόντο Παρουσίασης](/slides/el/cpp/presentation-background/) και [Θέμα Παρουσίασης](/slides/el/cpp/presentation-theme/).

## **Κλωνοποίηση Slide Master σε Άλλη Παράσταση**

Χρησιμοποιήστε το [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslidecollection/addclone/) για να αντιγράψετε μια master διαφάνεια σε άλλη παρουσίαση. Η αντιγραμμένη master μπορεί στη συνέχεια να χρησιμοποιηθεί από layout και διαφάνειες στην προοριστική παρουσίαση.

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Εάν χρειάζεται να κλωνοποιήσετε κανονικές διαφάνειες μαζί με τη master τους, δείτε [Κλωνοποίηση Διαφανειών](/slides/el/cpp/clone-slides/).

## **Προσθήκη Πολλαπλών Slide Masters**

Μια παρουσίαση μπορεί να περιέχει πολλαπλές master διαφάνειες. Αυτό είναι χρήσιμο όταν διαφορετικές ενότητες απαιτούν διαφορετική επωνυμία, δομή σελίδας ή ρυθμίσεις θέματος.

![Εντολές PowerPoint για εισαγωγή και διαχείριση master διαφανειών](slide-master_9.jpg)

Το παρακάτω παράδειγμα κλωνοποιεί τη προεπιλεγμένη master, δίνει στο κλώνο διαφορετικό φόντο, δημιουργεί μια layout κάτω από αυτή τη κλωνοποιημένη master και προσθέτει μια νέα διαφάνεια βασισμένη σε αυτή τη layout:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Σύγκριση Slide Masters**

Οι master διαφάνειες μπορούν να συγκριθούν με τη μέθοδο `Equals` που κληρονομείται από το [IBaseSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseslide/). Η σύγκριση ελέγχει τη δομή και το στατικό περιεχόμενο, όπως σχήματα, κείμενο, μορφοποίηση, κινούμενα σχέδια και άλλες ρυθμίσεις διαφάνειας. Δεν συγκρίνει μοναδικά αναγνωριστικά, όπως τα IDs διαφανειών, ή δυναμικές τιμές placeholder, όπως η τρέχουσα ημερομηνία.

```cpp
auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

Για περισσότερες πληροφορίες, δείτε [Σύγκριση Διαφανειών Παρουσίασης](/slides/el/cpp/compare-slides/).

## **Ορισμός Προβολής Slide Master ως Προεπιλεγμένη Προβολή**

Χρησιμοποιήστε τη μέθοδο `set_LastView` στο [ViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/) για να ελέγξετε την προβολή που ανοίγει πρώτο το PowerPoint. Το παρακάτω παράδειγμα ανοίγει την παρουσίαση στην προβολή Slide Master:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Για περισσότερες ρυθμίσεις προβολής, δείτε [Αποθήκευση Παρουσίασης](/slides/el/cpp/save-presentation/).

## **Αφαίρεση Μη Χρησιμοποιούμενων Master Διαφανειών**

Οι παρουσιάσεις μερικές φορές περιέχουν master διαφάνειες που δεν χρησιμοποιούνται πλέον από καμία κανονική διαφάνεια. Η αφαίρεση των μη χρησιμοποιούμενων masters μπορεί να μειώσει το μέγεθος του αρχείου και να απλοποιήσει τη συντήρηση των προτύπων.

Χρησιμοποιήστε το [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/el/cpp/aspose.slides/masterslidecollection/removeunused/) για να αφαιρέσετε μη χρησιμοποιούμενες master διαφάνειες από τη συλλογή `get_Masters()`:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Μπορείτε επίσης να χρησιμοποιήσετε τη low‑code μέθοδο [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Τι είναι η διαφορά μεταξύ ενός slide master και μιας layout διαφάνειας;**

Ένα slide master ορίζει κοινές ρυθμίσεις σχεδίασης όπως θέμα, φόντο, κοινά σχήματα και στυλ κειμένου. Μια layout διαφάνεια ανήκει σε ένα slide master και ορίζει μια συγκεκριμένη διάταξη placeholders. Μια κανονική διαφάνεια χρησιμοποιεί μια layout διαφάνεια, οπότε κληρονομεί τόσο από τη layout όσο και από το master.

**Μπορεί μια παρουσίαση να περιέχει πολλές slide masters;**

Ναι. Μια παρουσίαση μπορεί να περιέχει πολλές slide masters. Χρησιμοποιήστε πολλαπλές masters όταν διαφορετικές ενότητες χρειάζονται διαφορετικά οπτικά συστήματα ή επωνυμία.

**Πρέπει να προσθέτω placeholders σε slide master ή σε layout διαφάνειας;**

Στις περισσότερες περιπτώσεις, προσθέτετε placeholders σε layout διαφάνειες. Τοποθετήστε κοινά οπτικά στοιχεία και κοινή μορφοποίηση στη slide master, ενώ τα placeholders περιεχομένου τοποθετείτε στις layout που θα χρησιμοποιήσουν οι κανονικές διαφάνειες.

**Μπορώ να διαγράψω ένα slide master που εξακολουθεί να χρησιμοποιείται;**

Όχι. Ένα slide master που έχει εξαρτημένες διαφάνειες δεν μπορεί να αφαιρεθεί με ασφάλεια άμεσα. Πρώτα μεταφέρετε αυτές τις διαφάνειες σε layout κάτω από άλλο master, ή χρησιμοποιήστε μια μέθοδο καθαρισμού μη χρησιμοποιούμενων masters που αφαιρεί μόνο τα masters που δεν είναι σε χρήση.