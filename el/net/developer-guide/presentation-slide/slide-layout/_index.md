---
title: "Εφαρμογή ή Αλλαγή Διατάξεων Διαφανειών σε .NET"
linktitle: "Διάταξη Διαφάνειας"
type: docs
weight: 60
url: /el/net/slide-layout/
keywords:
- "διάταξη διαφάνειας"
- "διάταξη περιεχομένου"
- "πλαίσιο κράτησης θέσης"
- "σχεδιασμός παρουσίασης"
- "σχεδιασμός διαφάνειας"
- "αχρησιμοποίητη διάταξη"
- "ορατότητα υποσέλιδου"
- "διαφάνεια τίτλου"
- "τίτλος και περιεχόμενο"
- "κεφαλίδα ενότητας"
- "δύο περιεχόμενα"
- "σύγκριση"
- "μόνο τίτλος"
- "κενή διάταξη"
- "περιεχόμενο με λεζάντα"
- "εικόνα με λεζάντα"
- "τίτλος και κατακόρυφο κείμενο"
- "κατακόρυφος τίτλος και κείμενο"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "C#"
- ".NET"
- "Aspose.Slides"
description: "Διαχειριστείτε και προσαρμόστε τις διατάξεις διαφανειών στο Aspose.Slides για .NET. Εξερευνήστε τύπους διατάξεων, έλεγχο πλαισίων κράτησης θέσης και ορατότητα υποσέλιδου μέσω παραδειγμάτων κώδικα C#."
---
## **Εισαγωγή**

Μια διάταξη διαφάνειας ορίζει τη διάταξη των πλαισίων κράτησης θέσης και τη μορφοποίηση του περιεχομένου σε μια διαφάνεια. Ελέγχει ποια πλαίσια κράτησης θέσης είναι διαθέσιμα και πού εμφανίζονται. Οι διατάξεις διαφανειών σας βοηθούν να δημιουργείτε παρουσιάσεις γρήγορα και συνεπώς—είτε δημιουργείτε κάτι απλό είτε πιο σύνθετο. Μερικές από τις πιο συχνές διατάξεις διαφανειών στο PowerPoint περιλαμβάνουν:

**Διάταξη διαφάνειας τίτλου** – Περιλαμβάνει δύο πλαίσια κειμένου: ένα για τον τίτλο και ένα για τον υπότιτλο.

**Διάταξη τίτλου και περιεχομένου** – Παρουσιάζει ένα μικρότερο πλαίσιο τίτλου στην κορυφή και ένα μεγαλύτερο από κάτω για το κύριο περιεχόμενο (όπως κείμενο, κουκίδες, διαγράμματα, εικόνες κ.ά.).

**Κενή διάταξη** – Δεν περιέχει πλαίσια κράτησης θέσης, δίνοντάς σας πλήρη έλεγχο για να σχεδιάσετε τη διαφάνεια από το μηδέν.

Οι διατάξεις διαφανειών αποτελούν μέρος ενός κύριου προτύπου διαφάνειας (slide master), το οποίο είναι η κορυφαία διαφάνεια που ορίζει τα στυλ διάταξης για την παρουσίαση. Μπορείτε να αποκτήσετε πρόσβαση και να τροποποιήσετε τις διατάξεις διαφανειών μέσω του κύριου προτύπου—είτε με τον τύπο τους, το όνομα ή το μοναδικό αναγνωριστικό. Εναλλακτικά, μπορείτε να επεξεργαστείτε μια συγκεκριμένη διάταξη διαφάνειας απευθείας μέσα στην παρουσίαση.

Για να εργαστείτε με διατάξεις διαφανειών στο Aspose.Slides για .NET, μπορείτε να χρησιμοποιήσετε:
- Ιδιότητες όπως [LayoutSlides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/layoutslides/) και [Masters](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/masters/) στην κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) 
- Τύπους όπως [ILayoutSlide](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutplaceholdermanager/), και [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Για να μάθετε περισσότερα σχετικά με τη χρήση των κύριων διαφανειών, δείτε το άρθρο [Slide Master](/slides/el/net/slide-master/).
{{% /alert %}}

## **Προσθήκη διατάξεων διαφανειών σε παρουσιάσεις**

Για να προσαρμόσετε την εμφάνιση και τη δομή των διαφανειών σας, ίσως χρειαστεί να προσθέσετε νέες διατάξεις διαφανειών σε μια παρουσίαση. Το Aspose.Slides για .NET σας επιτρέπει να ελέγξετε αν μια συγκεκριμένη διάταξη υπάρχει ήδη, να προσθέσετε μια νέα αν χρειάζεται και να τη χρησιμοποιήσετε για να εισάγετε διαφάνειες βάσει εκείνης της διάταξης.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Πρόσβαση στη συλλογή [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/imasterlayoutslidecollection/).
1. Ελέγξτε αν η επιθυμητή διάταξη διαφάνειας υπάρχει ήδη στη συλλογή. Αν όχι, προσθέστε τη διάταξη διαφάνειας που χρειάζεστε.
1. Προσθέστε μια κενή διαφάνεια βάσει της νέας διάταξης διαφάνειας.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C# δείχνει πώς να προσθέσετε μια διάταξη διαφάνειας σε παρουσίαση PowerPoint:

```cs
// Δημιουργία ενός αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Περιήγηση στους τύπους διατάξεων διαφανειών για επιλογή μιας διάταξης διαφάνειας.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // Μια κατάσταση όπου η παρουσίαση δεν περιέχει όλους τους τύπους διατάξεων.
        // Το αρχείο παρουσίασης περιέχει μόνο τύπους διατάξεων Blank και Custom.
        // Ωστόσο, οι διατάξεις διαφανειών με προσαρμοσμένους τύπους μπορεί να έχουν αναγνωρίσιμα ονόματα,
        // όπως "Title", "Title and Content" κλπ., που μπορούν να χρησιμοποιηθούν για την επιλογή διάταξης διαφάνειας.
        // Μπορείτε επίσης να βασιστείτε σε ένα σύνολο τύπων σχήματος πλαισίων κράτησης θέσης.
        // Για παράδειγμα, μια διαφάνεια τίτλου πρέπει να έχει μόνο τον τύπο πλαισίου κράτησης θέσης Title, κλπ.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Προσθήκη κενής διαφάνειας χρησιμοποιώντας τη προστιθέμενη διάταξη διαφάνειας.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Αποθήκευση της παρουσίασης στο δίσκο.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Αφαίρεση αχρησιμοποίητων διατάξεων διαφανειών**

Το Aspose.Slides παρέχει τη μέθοδο [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) της κλάσης [Compress](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/) για να διαγράψετε ανεπιθύμητες και αχρησιμοποίητες διατάξεις διαφανειών.

Ο παρακάτω κώδικας C# δείχνει πώς να αφαιρέσετε μια διάταξη διαφάνειας από μια παρουσίαση PowerPoint:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Πρόσθεση πλαισίων κράτησης θέσης σε διατάξεις διαφανειών**

Το Aspose.Slides παρέχει την ιδιότητα [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/placeholdermanager/), η οποία σας επιτρέπει να προσθέσετε νέα πλαίσια κράτησης θέσης σε μια διάταξη διαφάνειας.

Αυτός ο διαχειριστής περιέχει μεθόδους για τους ακόλουθους τύπους πλαισίων κράτησης θέσης:

| PowerPoint Placeholder              | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutplaceholdermanager/) Method |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Περιεχόμενο](content.png)             | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Περιεχόμενο (Κατακόρυφα)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Κείμενο](text.png)                   | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Κείμενο (Κατακόρυφα)](textV.png)       | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Εικόνα](picture.png)             | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Διάγραμμα](chart.png)                 | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Πίνακας](table.png)                 | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Μέσα](media.png)                 | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Διαδικτυακή Εικόνα](onlineimage.png)    | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Ο παρακάτω κώδικας C# δείχνει πώς να προσθέσετε νέες μορφές πλαισίων κράτησης θέσης στη Κενή διάταξη διαφάνειας:

```cs
using (var presentation = new Presentation())
{
    // Αποκτήστε τη κενή διάταξη διαφάνειας.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Αποκτήστε τον διαχειριστή πλαισίων κράτησης θέσης της διάταξης διαφάνειας.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Προσθήκη διαφορετικών πλαισίων κράτησης θέσης στη κενή διάταξη διαφάνειας.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Προσθήκη νέας διαφάνειας με τη κενή διάταξη.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![The placeholders on the layout slide](add_placeholders.png)

## **Ορισμός ορατότητας υποσέλιδου για διάταξη διαφάνειας**

Σε παρουσιάσεις PowerPoint, τα στοιχεία του υποσέλιδου όπως η ημερομηνία, ο αριθμός διαφάνειας και το προσαρμοσμένο κείμενο μπορούν να εμφανίζονται ή να κρύβονται ανάλογα με τη διάταξη της διαφάνειας. Το Aspose.Slides για .NET σας επιτρέπει να ελέγχετε την ορατότητα αυτών των πλαισίων κράτησης θέσης του υποσέλιδου. Αυτό είναι χρήσιμο όταν θέλετε ορισμένες διατάξεις να εμφανίζουν πληροφορίες υποσέλιδου ενώ άλλες παραμένουν καθαρές και ελάχιστες.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά διάταξης διαφάνειας με βάση το δείκτη της.
1. Ορίστε το πλαίσιο κράτησης θέσης υποσέλιδου της διαφάνειας σε ορατό.
1. Ορίστε το πλαίσιο κράτησης θέσης αριθμού διαφάνειας σε ορατό.
1. Ορίστε το πλαίσιο κράτησης θέσης ημερομηνίας/ώρας σε ορατό.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C# δείχνει πώς να ορίσετε την ορατότητα ενός υποσέλιδου διαφάνειας και να εκτελέσετε σχετικές εργασίες:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```

## **Ορισμός ορατότητας υποσέλιδου παιδικής διαφάνειας**

Σε παρουσιάσεις PowerPoint, τα στοιχεία του υποσέλιδου όπως η ημερομηνία, ο αριθμός διαφάνειας και το προσαρμοσμένο κείμενο μπορούν να ελεγχθούν σε επίπεδο του κύριου προτύπου διαφάνειας ώστε να εξασφαλιστεί συνέπεια σε όλες τις διατάξεις διαφανειών. Το Aspose.Slides για .NET σας επιτρέπει να ορίσετε την ορατότητα και το περιεχόμενο αυτών των πλαισίων κράτησης θέσης του υποσέλιδου στο κύριο πρότυπο και να διαδώσετε αυτές τις ρυθμίσεις σε όλες τις παιδικές διατάξεις διαφανειών. Αυτή η προσέγγιση εξασφαλίζει ομοιόμορφη πληροφορία υποσέλιδου σε όλη την παρουσίαση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά στο κύριο πρότυπο διαφάνειας με βάση το δείκτη του.
1. Ορίστε τα πλαίσια κράτησης θέσης του υποσέλιδου του κυρίως προτύπου και όλων των παιδικών σε ορατό.
1. Ορίστε τα πλαίσια αριθμού διαφάνειας του κυρίως προτύπου και όλων των παιδικών σε ορατό.
1. Ορίστε τα πλαίσια ημερομηνίας/ώρας του κυρίως προτύπου και όλων των παιδικών σε ορατό.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C# δείχνει αυτή τη λειτουργία:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ ενός κύριου προτύπου διαφάνειας και μιας διάταξης διαφάνειας;**

Ένα κύριο πρότυπο διαφάνειας καθορίζει το γενικό θέμα και τη προεπιλεγμένη μορφοποίηση, ενώ οι διατάξεις διαφανειών ορίζουν συγκεκριμένες διατάξεις πλαισίων κράτησης θέσης για διαφορετικούς τύπους περιεχομένου.

**Μπορώ να αντιγράψω μια διάταξη διαφάνειας από μια παρουσίαση σε άλλη;**

Ναι, μπορείτε να κλωνοποιήσετε μια διάταξη διαφάνειας από τη συλλογή [LayoutSlides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/layoutslides/) μιας παρουσίασης και να την εισάγετε σε άλλη χρησιμοποιώντας τη μέθοδο `AddClone`.

**Τι συμβαίνει εάν διαγράψω μια διάταξη διαφάνειας που χρησιμοποιείται ακόμα από μια διαφάνεια;**

Εάν προσπαθήσετε να διαγράψετε μια διάταξη διαφάνειας που εξακολουθεί να αναφέρεται από τουλάχιστον μία διαφάνεια στην παρουσίαση, το Aspose.Slides θα πετάξει μια εξαίρεση [PptxEditException](https://reference.aspose.com/slides/el/net/aspose.slides/pptxeditexception/). Για να το αποφύγετε, χρησιμοποιήστε τη μέθοδο [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) η οποία αφαιρεί με ασφάλεια μόνο τις διατάξεις διαφανειών που δεν χρησιμοποιούνται.