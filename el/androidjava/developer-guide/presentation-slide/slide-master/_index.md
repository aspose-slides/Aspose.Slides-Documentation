---
title: "Διαχείριση master διαφανειών παρουσίασης σε Android"
linktitle: "Master Διαφάνειας"
type: docs
weight: 70
url: /el/androidjava/slide-master/
keywords:
- master διαφάνειας
- master διαφάνειας
- master διαφάνειας PPT
- πολλαπλές master διαφάνειες
- σύγκριση master διαφανειών
- φόντο
- σύμβολο κράτησης
- κλωνοποίηση master διαφάνειας
- αντιγραφή master διαφάνης
- διπλασιασμός master διαφάνειας
- αχρησιμοποίητη master διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τα master διαφάνειων στο Aspose.Slides για Android μέσω Java: πρόσβαση, επεξεργασία, κλωνοποίηση, σύγκριση και αφαίρεση master διαφανειών σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Ένα **slide master** ορίζει κοινές ρυθμίσεις σχεδίασης για μια ομάδα διαφανειών. Μπορεί να περιέχει κοινά σχήματα, λογότυπα, φόντα, στιλ κειμένου, ρυθμίσεις θέματος και ρυθμίσεις υποσέλιδου. Στο PowerPoint, η επεξεργασία ενός slide master είναι ο συνηθισμένος τρόπος να διατηρείται μια παρουσίαση συνεπής χωρίς να επαναλαμβάνεται η ίδια μορφοποίηση σε κάθε διαφάνεια.

Το Aspose.Slides for Android via Java υποστηρίζει το ίδιο μοντέλο. Μια παρουσίαση μπορεί να περιέχει μία ή περισσότερες master διαφάνειες, και κάθε master διαφάνεια μπορεί να περιέχει πολλές layout διαφάνειες. Οι κανονικές διαφάνειες συνήθως δεν αναφέρονται άμεσα σε μια master διαφάνεια. Αντίθετα, μια κανονική διαφάνεια χρησιμοποιεί μια layout διαφάνεια, η οποία ανήκει σε μια master διαφάνεια.

Η ιεραρχία είναι:

1. **Slide master** – ορίζει το κοινό σχέδιο και το θέμα.  
1. **Layout slide** – ορίζει μια συγκεκριμένη διάταξη των placeholders και τη μορφοποίηση επιπέδου layout.  
1. **Normal slide** – περιέχει το πραγματικό περιεχόμενο της παρουσίασης και χρησιμοποιεί μία layout διαφάνεια.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

Στο Aspose.Slides, ένα slide master αντιπροσωπεύεται από τη διεπαφή [IMasterSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslide/) . Όλες οι master διαφάνειες σε μια παρουσίαση είναι διαθέσιμες μέσω της συλλογής [Presentation.getMasters](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getMasters--) , η οποία υλοποιεί τη [IMasterSlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslidecollection/). Για πλήρη επισκόπηση του API Android via Java, δείτε την αναφορά [com.aspose.slides API](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
Όταν η ίδια ιδιότητα ορίζεται σε περισσότερα από ένα επίπεδα, το πιο συγκεκριμένο επίπεδο κερδίζει. Για παράδειγμα, εάν μια master διαφάνεια και μια layout διαφάνεια ορίζουν και τις δύο ένα φόντο, οι διαφάνειες που βασίζονται σε αυτή τη layout χρησιμοποιούν το φόντο της layout. Για περισσότερες πληροφορίες σχετικά με τις layout διαφάνειες, δείτε [Apply or Change Slide Layouts](/slides/el/androidjava/slide-layout/).
{{% /alert %}}

## **Πρόσβαση στις Slide Masters**

Στο PowerPoint, μπορείτε να ανοίξετε την προβολή Slide Master από **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

Στο Aspose.Slides, χρησιμοποιήστε τη συλλογή `getMasters()` για πρόσβαση στις master διαφάνειες:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Μπορείτε επίσης να λάβετε τη master διαφάνεια που χρησιμοποιείται από μια κανονική διαφάνεια μέσω του layout της:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Τι Περιέχει μια Slide Master**

Μια master διαφάνεια είναι ένα αντικείμενο παρόμοιο με τη διαφάνεια. Υλοποιεί το [IBaseSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseslide/), οπότε εκθέτει πολλές από τις ίδιες ιδιότητες διαφάνειας που χρησιμοποιούνται από τις κανονικές και τις layout διαφάνειες.

Συχνά χρησιμοποιούμενα μέλη της master διαφάνειας περιλαμβάνουν:

| Member | Purpose |
| --- | --- |
| `getBackground()` | Ορίζει το φόντο σε επίπεδο master. |
| `getShapes()` | Αποθηκεύει σχήματα τοποθετημένα στη master, όπως λογότυπα, πλαίσια εικόνων και κοινό κείμενο. |
| `getLayoutSlides()` | Αποθηκεύει τις layout διαφάνειες που ανήκουν στη master. |
| `getThemeManager()` | Παρέχει πρόσβαση στα API θέματος της master. |
| `getHeaderFooterManager()` | Ελέγχει κεφαλίδες, υποσέλιδα, ημερομηνίες και αριθμούς διαφανειών για τη master και τα παιδικά της layout. |
| `getDependingSlides()` | Επιστρέφει τις κανονικές διαφάνειες που εξαρτώνται από τη master μέσω των layout τους. |

## **Προσθήκη Εικόνας σε Slide Master**

Όταν προσθέτετε μια εικόνα σε μια master διαφάνεια, εμφανίζεται στις διαφάνειες που χρησιμοποιούν layout από εκείνη τη master. Αυτό είναι χρήσιμο για λογότυπα, υδατογραφήματα, διακοσμητικές λωρίδες και άλλα επαναλαμβανόμενα οπτικά στοιχεία.

Το παρακάτω παράδειγμα προσθέτει ένα λογότυπο στην πρώτη master διαφάνεια:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για περισσότερες πληροφορίες σχετικά με τα πλαίσια εικόνας, δείτε [Picture Frame](/slides/el/androidjava/picture-frame/).

## **Εργασία με Placeholders**

Τα placeholders ορίζονται συνήθως στις layout διαφάνειες. Η master διαφάνεια παρέχει το κοινό στυλ και το θέμα που κληρονομούν αυτές οι layout, ενώ κάθε layout αποφασίζει ποια placeholders είναι διαθέσιμα και πού τοποθετούνται.

Στο PowerPoint, οι εντολές placeholder διατίθενται στην προβολή Slide Master.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Για να προσθέσετε νέα placeholders με το Aspose.Slides, εργαστείτε με τη layout διαφάνεια που ανήκει στη master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Μπορείτε επίσης να μορφοποιήσετε σχήματα placeholder που ήδη υπάρχουν σε μια master διαφάνεια. Το παρακάτω παράδειγμα εντοπίζει το placeholder τίτλου και εφαρμόζει μια γραμμική γεμίσμα κλίσης:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Για περισσότερες επιλογές μορφοποίησης placeholder και κειμένου, δείτε [Set Prompt Text in Placeholder](/slides/el/androidjava/manage-placeholder/) και [Text Formatting](/slides/el/androidjava/text-formatting/).

## **Αλλαγή Φόντου Slide Master**

Ένα φόντο master κληρονομείται από τα layout και τις διαφάνειες που δεν το παρακάμπτουν. Το παρακάτω παράδειγμα ορίζει ένα ενιαίο χρώμα φόντου για την πρώτη master διαφάνεια:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για σχετικά θέματα, δείτε [Presentation Background](/slides/el/androidjava/presentation-background/) και [Presentation Theme](/slides/el/androidjava/presentation-theme/).

## **Κλωνοποίηση Slide Master σε Άλλη Παρουσίαση**

Χρησιμοποιήστε το [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) για να αντιγράψετε μια master διαφάνεια σε άλλη παρουσίαση. Η αντιγραμμένη master μπορεί στη συνέχεια να χρησιμοποιηθεί από layout και διαφάνειες στην προορισμένη παρουσίαση.

```java
Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Αν χρειάζεται να κλωνοποιήσετε κανονικές διαφάνειες μαζί με τη master τους, δείτε [Clone Slides](/slides/el/androidjava/clone-slides/).

## **Προσθήκη Πολλών Slide Masters**

Μια παρουσίαση μπορεί να περιέχει πολλαπλές master διαφάνειες. Αυτό είναι χρήσιμο όταν διαφορετικές ενότητες απαιτούν διαφορετική σήμανση, δομή σελίδας ή ρυθμίσεις θέματος.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Το παρακάτω παράδειγμα κλωνοποιεί την προεπιλεγμένη master, δίνει στο κλώνο διαφορετικό φόντο, δημιουργεί ένα layout κάτω από αυτή τη κλωνοποιημένη master και προσθέτει μια νέα διαφάνεια βασισμένη σε αυτό το layout:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Σύγκριση Slide Masters**

Οι master διαφάνειες μπορούν να συγκριθούν με τη μέθοδο `equals` που κληρονομείται από το [IBaseSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseslide/). Η σύγκριση ελέγχει τη δομή και το στατικό περιεχόμενο, όπως σχήματα, κείμενο, μορφοποίηση, κινήσεις και άλλες ρυθμίσεις διαφάνειας. Δεν συγκρίνει μοναδικά αναγνωριστικά, όπως τα IDs διαφανειών, ή δυναμικές τιμές placeholder, όπως η τρέχουσα ημερομηνία.

```java
Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Για περισσότερες πληροφορίες, δείτε [Compare Presentation Slides](/slides/el/androidjava/compare-slides/).

## **Ορισμός Slide Master View ως Προεπιλεγμένη Προβολή**

Χρησιμοποιήστε τη μέθοδο `setLastView` στο [ViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewproperties/) για να ελέγξετε την προβολή που ανοίγει πρώτο το PowerPoint. Το παρακάτω παράδειγμα ανοίγει την παρουσίαση σε προβολή Slide Master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για περισσότερες ρυθμίσεις προβολής, δείτε [Save Presentation](/slides/el/androidjava/save-presentation/).

## **Κατάργηση Μη Χρησιμοποιούμενων Master Slides**

Μερικές φορές οι παρουσιάσεις περιέχουν master διαφάνειες που δεν χρησιμοποιούνται πλέον από καμία κανονική διαφάνεια. Η αφαίρεση των μη χρησιμοποιούμενων masters μπορεί να μειώσει το μέγεθος του αρχείου και να απλοποιήσει τη συντήρηση του προτύπου.

Χρησιμοποιήστε το `removeUnused` για να αφαιρέσετε μη χρησιμοποιούμενες masters από τη συλλογή `getMasters()`:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Μπορείτε επίσης να χρησιμοποιήσετε τη μέθοδο low‑code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Ποια είναι η διαφορά μεταξύ slide master και layout slide;**

Μια slide master ορίζει κοινές ρυθμίσεις σχεδίασης όπως θέμα, φόντο, κοινά σχήματα και στιλ κειμένου. Μια layout slide ανήκει σε μια master slide και ορίζει μια συγκεκριμένη διάταξη placeholders. Μια κανονική διαφάνεια χρησιμοποιεί μια layout slide, έτσι κληρονομεί τόσο από τη layout όσο και από τη master.

**Μπορεί μια παρουσίαση να περιέχει πολλαπλές slide masters;**

Ναι. Μια παρουσίαση μπορεί να περιέχει πολλαπλές slide masters. Χρησιμοποιήστε πολλές masters όταν διαφορετικά τμήματα χρειάζονται διαφορετικά οπτικά συστήματα ή σήμανση.

**Πρέπει να προσθέσω placeholders σε μια master slide ή σε μια layout slide;**

Στις περισσότερες περιπτώσεις, προσθέτετε placeholders στις layout διαφάνειες. Τοποθετήστε τα κοινά οπτικά στοιχεία και τη κοινή μορφοποίηση στη master slide, και μετά τα placeholders περιεχομένου στις layout που θα χρησιμοποιήσουν οι κανονικές διαφάνειες.

**Μπορώ να διαγράψω μια master slide που χρησιμοποιείται ακόμα;**

Όχι. Μια master slide που έχει εξαρτημένες διαφάνειες δεν μπορεί να αφαιρεθεί με ασφάλεια απευθείας. Πρώτα μετακινήστε αυτές τις διαφάνειες σε layout κάτω από άλλη master, ή χρησιμοποιήστε μια μέθοδο καθαρισμού μη χρησιμοποιούμενων masters που αφαιρεί μόνο τις masters που δεν είναι σε χρήση.