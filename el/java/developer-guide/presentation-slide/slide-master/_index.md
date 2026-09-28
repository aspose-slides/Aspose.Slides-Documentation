---
title: Διαχείριση Master Διαφανειών Παρουσίασης σε Java
linktitle: Master Διαφάνειας
type: docs
weight: 70
url: /el/java/slide-master/
keywords:
- master διαφάνειας
- master διαφάνειας
- master διαφάνειας PPT
- πολλαπλές master διαφάνειες
- συγκρίνετε master διαφάνειες
- φόντο
- σύμβολο κράτησης
- αντίγραφο master διαφάνειας
- αντιγραφή master διαφάνειας
- δημιουργία αντιγράφου master διαφάνειας
- αχρησιμοποίητη master διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Διαχείριση master διαφανειών στο Aspose.Slides για Java: πρόσβαση, επεξεργασία, κλωνοποίηση, σύγκριση και αφαίρεση master διαφανειών σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Ένα **slide master** ορίζει κοινές ρυθμίσεις σχεδίασης για μια ομάδα διαφανειών. Μπορεί να περιέχει κοινά σχήματα, λογότυπα, φόντα, στυλ κειμένου, ρυθμίσεις θέματος και ρυθμίσεις υποσέλιδου. Στο PowerPoint, η επεξεργασία ενός slide master είναι ο συνήθης τρόπος να διατηρηθεί μια παρουσίαση συνεπής χωρίς να επαναλαμβάνεται η ίδια μορφοποίηση σε κάθε διαφάνεια.

Το Aspose.Slides for Java υποστηρίζει το ίδιο μοντέλο. Μια παρουσίαση μπορεί να περιέχει μία ή περισσότερες master διαφάνειες, και κάθε master διαφάνεια μπορεί να περιέχει πολλές layout διαφάνειες. Οι κανονικές διαφάνειες συνήθως δεν αναφέρονται άμεσα σε μια master διαφάνεια. Αντίθετα, μια κανονική διαφάνεια χρησιμοποιεί μια layout διαφάνεια, η οποία ανήκει σε μια master διαφάνεια.

Η ιεραρχία είναι:

1. **Slide master** – ορίζει το κοινό σχέδιο και το θέμα.  
1. **Layout slide** – ορίζει μια συγκεκριμένη διάταξη placeholders και μορφοποίηση επιπέδου layout.  
1. **Normal slide** – περιέχει το πραγματικό περιεχόμενο της παρουσίασης και χρησιμοποιεί μία layout διαφάνεια.

![Η ιεραρχία των master διαφανειών, layout διαφανειών και normal διαφανειών](slide-master_2.jpg)

Στο Aspose.Slides, ένα slide master αντιπροσωπεύεται από το interface [IMasterSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslide/). Όλες οι master διαφάνειες σε μια παρουσίαση είναι διαθέσιμες μέσω της συλλογής [Presentation.getMasters](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getMasters--) που υλοποιεί το [IMasterSlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}

Όταν η ίδια ιδιότητα ορίζεται σε περισσότερα από ένα επίπεδα, το πιο συγκεκριμένο επίπεδο κερδίζει. Για παράδειγμα, αν μια master διαφάνεια και μια layout διαφάνεια ορίζουν και τα δύο φόντο, οι διαφάνειες που βασίζονται σε αυτή τη layout χρησιμοποιούν το φόντο της layout. Για περισσότερες πληροφορίες σχετικά με τις layout διαφάνειες, δείτε [Apply or Change Slide Layouts](/slides/el/java/slide-layout/).

{{% /alert %}}

## **Πρόσβαση σε Slide Masters**

Στο PowerPoint, μπορείτε να ανοίξετε την προβολή Slide Master από **View** > **Slide Master**.

![Η εντολή Slide Master στην κορδέλα View του PowerPoint](slide-master_3.jpg)

Στο Aspose.Slides, χρησιμοποιήστε τη συλλογή `getMasters()` για πρόσβαση στις master διαφάνειες:

```java
import com.aspose.slides.*;

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

Μπορείτε επίσης να πάρετε τη master διαφάνεια που χρησιμοποιείται από μια κανονική διαφάνεια μέσω του layout της:

```java
import com.aspose.slides.*;

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

## **Τι Περιέχει ένα Slide Master**

Μια master διαφάνεια είναι ένα αντικείμενο παρόμοιο με διαφάνεια. Εφαρμόζει το interface [IBaseSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseslide/), έτσι εκθέτει πολλά από τα ίδια properties διαφάνειας που χρησιμοποιούνται από κανονικές και layout διαφάνειες. Τα μέλη που αφορούν αποκλειστικά τη master διαφάνεια αναφέρονται στη σελίδα API του [IMasterSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslide/).

Κοινά χρησιμοποιούμενα μέλη της master διαφάνειας περιλαμβάνουν:

| Μέλος | Σκοπός |
| --- | --- |
| `getBackground()` | Ορίζει το φόντο σε επίπεδο master. |
| `getShapes()` | Αποθηκεύει σχήματα που τοποθετούνται στη master, όπως λογότυπα, πλαίσια εικόνας και κοινό κείμενο. |
| `getLayoutSlides()` | Αποθηκεύει τις layout διαφάνειες που ανήκουν στη master. |
| `getThemeManager()` | Παρέχει πρόσβαση στα API του θέματος της master. |
| `getHeaderFooterManager()` | Ελέγχει κεφαλίδες, υποσέλιδα, ημερομηνίες και αριθμούς διαφανειών για τη master και τις παιδικές της layout. |
| `getDependingSlides()` | Επιστρέφει τις κανονικές διαφάνειες που εξαρτώνται από τη master μέσω των layout τους. |

## **Προσθήκη Εικόνας σε Slide Master**

Όταν προσθέτετε μια εικόνα σε μια master διαφάνεια, εμφανίζεται στις διαφάνειες που χρησιμοποιούν layout από αυτή τη master. Είναι χρήσιμο για λογότυπα, υδατογραφήματα, διακοσμητικές λωρίδες και άλλα επαναλαμβανόμενα οπτικά στοιχεία.

Το παρακάτω παράδειγμα προσθέτει ένα λογότυπο στην πρώτη master διαφάνεια:

```java
import com.aspose.slides.*;

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

Για περισσότερες πληροφορίες σχετικά με τα πλαίσια εικόνας, δείτε [Picture Frame](/slides/el/java/picture-frame/).

## **Έλεγχος Ορατότητας των Γραφικών της Master**

Χρησιμοποιήστε το [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) για απόκρυψη των κληρονομούμενων γραφικών της master, όπως λογότυπα ή διακοσμητικά σχήματα, χωρίς να τα διαγράψετε από τη master. Περάστε `false` στο [Slide.setShowMasterShapes](https://reference.aspose.com/slides/el/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) στη διαφάνεια που πρέπει να παραλείψει αυτά τα γραφικά και κρατήστε το `true` στις διαφάνειες που πρέπει να τα εμφανίζει.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί μια μπλε διακοσμητική λωρίδα σε μια master και δύο διαφάνειες που χρησιμοποιούν το ίδιο κενό layout. Η λωρίδα είναι ορατή στην πρώτη διαφάνεια και κρυμμένη στη δεύτερη. Δεν απαιτείται εισαγωγική παρουσίαση ή εικόνα.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το παράδειγμα χρησιμοποιεί το layout **Blank** που παρέχεται με μια νέα παρουσίαση και αφαιρεί τα αρχικά placeholders της πρώτης διαφάνειας.

### **Επιλογή Πεδίου Εφαρμογής της Ρύθμισης**

Μια κανονική διαφάνεια χρησιμοποιεί τη master της μέσω των [ISlide.getLayoutSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/#getLayoutSlide--) και [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/#getMasterSlide--). Η ρύθμιση της ιδιότητας σε μια μεμονωμένη διαφάνεια επηρεάζει μόνο εκείνη τη διαφάνεια. Περάστε `false` στο [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/el/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) για απόκρυψη των γραφικών της master στις διαφάνειες που χρησιμοποιούν εκείνο το κοινό layout, ακόμη και αν η δική τους ρύθμιση είναι `true`. Για απόκρυψη γραφικών σε μόνο μία διαφάνεια, αλλάξτε την ιδιότητα της διαφάνειας και αφήστε το κοινό layout αμετάβλητο.

Η ρύθμιση δεν υποστηρίζεται ως έλεγχος ορατότητας στη ίδια τη master διαφάνεια. Σε μια master, η μέθοδος [getShowMasterShapes](https://reference.aspose.com/slides/el/java/com.aspose.slides/masterslide/#getShowMasterShapes--) επιστρέφει πάντα `false`, και το πέρασμα `true` στη [setShowMasterShapes](https://reference.aspose.com/slides/el/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) προκαλεί εξαίρεση. Εφαρμόστε τη σε μια κανονική διαφάνεια ή σε μια layout.

### **Διαχωρισμός Γραφικών από το Φόντο**

| Λειτουργία | Αποτέλεσμα |
| --- | --- |
| Απόκρυψη γραφικών της master | Ελέγχει την ορατότητα των κληρονομούμενων σ shapes της master χωρίς να τα διαγράψει ή να αλλάξει τα δικά shapes της διαφάνειας. |
| Αλλαγή γεμίσματος φόντου διαφάνειας | Αλλάζει το χρώμα, την διαβάθμιση ή την εικόνα φόντου. Τα γραφικά της master είναι ξεχωριστά σ shapes και μπορούν να παραμείνουν ορατά πάνω από αυτό το φόντο. Δείτε το [Presentation Background](/slides/el/java/presentation-background/). |
| Διαγραφή shape από τη master | Αφαιρεί το κοινό shape προέλευσης, οπότε δεν είναι πλέον διαθέσιμο σε καμία διαφάνεια που χρησιμοποιεί αυτή τη master. |

## **Εργασία με Placeholders**

Τα placeholders συνήθως ορίζονται στις layout διαφάνειες. Η master διαφάνεια παρέχει το κοινό στυλ και θέμα που κληρονομούν αυτές οι layout, ενώ κάθε layout αποφασίζει ποια placeholders είναι προσβάσιμα και πού τοποθετούνται.

Στο PowerPoint, οι εντολές placeholder είναι διαθέσιμες στην προβολή Slide Master.

![Η εντολή Insert Placeholder στην προβολή Slide Master του PowerPoint](slide-master_5.png)

Για προσθήκη νέων placeholders με το Aspose.Slides, εργαστείτε με τη layout διαφάνεια που ανήκει στη master:

```java
import com.aspose.slides.*;

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

Μπορείτε επίσης να μορφοποιήσετε σ shapes placeholder που ήδη υπάρχουν σε μια master διαφάνεια. Το παρακάτω παράδειγμα εντοπίζει το placeholder τίτλου και εφαρμόζει γραμμική διαβάθμιση:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

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

![Μορφοποιημένο placeholder τίτλου που κληρονόμησε από κανονικές διαφάνειες](slide-master_8.png)

Για περισσότερες επιλογές placeholder και μορφοποίησης κειμένου, δείτε [Set Prompt Text in Placeholder](/slides/el/java/manage-placeholder/) και [Text Formatting](/slides/el/java/text-formatting/).

## **Αλλαγή Φόντου Slide Master**

Ένα φόντο master κληρονομείται από τις layout και τις διαφάνειες που δεν το παρακάμπτουν. Το παρακάτω παράδειγμα ορίζει ένα στερεό χρώμα φόντου για την πρώτη master διαφάνεια:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για σχετικά θέματα, δείτε [Presentation Background](/slides/el/java/presentation-background/) και [Presentation Theme](/slides/el/java/presentation-theme/).

## **Κλωνοποίηση Slide Master σε Άλλη Παρουσίαση**

Χρησιμοποιήστε το [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) για αντιγραφή μιας master διαφάνειας σε άλλη παρουσίαση. Η αντιγραμμένη master μπορεί τότε να χρησιμοποιηθεί από layout και διαφάνειες στην προορισμένη παρουσίαση.

```java
import com.aspose.slides.*;

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

Αν χρειάζεστε κλωνοποίηση κανονικών διαφανειών μαζί με τη master τους, δείτε [Clone Slides](/slides/el/java/clone-slides/).

## **Προσθήκη Πολλαπλών Slide Masters**

Μια παρουσίαση μπορεί να περιέχει πολλαπλές master διαφάνειες. Αυτό είναι χρήσιμο όταν διαφορετικές ενότητες απαιτούν διαφορετική επωνυμία, δομή σελίδας ή ρυθμίσεις θέματος.

![Εντολές PowerPoint για εισαγωγή και διαχείριση master διαφανειών](slide-master_9.jpg)

Το παρακάτω παράδειγμα κλωνοποιεί τη προεπιλεγμένη master, δίνει στο κλώνο διαφορετικό φόντο, δημιουργεί μια layout κάτω από αυτή τη κλωνοποιημένη master και προσθέτει μια νέα διαφάνεια βασισμένη σε αυτή τη layout:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

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

Οι master διαφάνειες μπορούν να συγκριθούν με τη μέθοδο `equals` που κληρονομείται από το [IBaseSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseslide/). Η σύγκριση ελέγχει τη δομή και το στατικό περιεχόμενο, όπως σ shapes, κείμενο, μορφοποίηση, κινήσεις και άλλες ρυθμίσεις διαφάνειας. Δεν συγκρίνει μοναδικά αναγνωριστικά, όπως slide IDs, ή δυναμικές τιμές placeholder, όπως η τρέχουσα ημερομηνία.

```java
import com.aspose.slides.*;

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

Για περισσότερες πληροφορίες, δείτε [Compare Presentation Slides](/slides/el/java/compare-slides/).

## **Ορισμός Slide Master View ως Προεπιλεγμένη Προβολή**

Χρησιμοποιήστε τη μέθοδο `setLastView` στο [ViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/viewproperties/) για έλεγχο της προβολής που ανοίγει πρώτο το PowerPoint. Το παρακάτω παράδειγμα ανοίγει την παρουσίαση σε προβολή Slide Master:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για περισσότερες ρυθμίσεις προβολής, δείτε [Save Presentation](/slides/el/java/save-presentation/).

## **Αφαίρεση Μη Χρησιμοποιούμενων Master Διαφανειών**

Μερικές φορές οι παρουσιάσεις περιέχουν master διαφάνειες που δεν χρησιμοποιούνται πλέον από καμία κανονική διαφάνεια. Η αφαίρεση μη χρησιμοποιούμενων master μπορεί να μειώσει το μέγεθος του αρχείου και να απλοποιήσει τη συντήρηση του προτύπου.

Χρησιμοποιήστε το `removeUnused` για αφαίρεση μη χρησιμοποιούμενων master από τη συλλογή `getMasters()`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Μπορείτε επίσης να χρησιμοποιήσετε τη low-code μέθοδο [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
import com.aspose.slides.*;

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

Ένα slide master ορίζει κοινές ρυθμίσεις σχεδίασης όπως θέμα, φόντο, κοινά σ shapes και στυλ κειμένου. Μια layout slide ανήκει σε ένα slide master και ορίζει μια συγκεκριμένη διάταξη placeholders. Μια κανονική διαφάνεια χρησιμοποιεί μια layout slide, οπότε κληρονομεί από τη layout και από τη master.

**Μπορεί μια παρουσίαση να περιέχει πολλές slide masters;**

Ναι. Μια παρουσίαση μπορεί να περιέχει πολλές slide masters. Χρησιμοποιήστε πολλαπλές masters όταν διαφορετικές ενότητες χρειάζονται διαφορετικά οπτικά συστήματα ή επωνυμίες.

**Πρέπει να προσθέσω placeholders σε μια master slide ή σε μια layout slide;**

Στις περισσότερες περιπτώσεις, προσθέστε placeholders στις layout διαφάνειες. Τοποθετήστε τα κοινά οπτικά στοιχεία και τη κοινή μορφοποίηση στη master slide, και τα placeholders περιεχομένου στις layout που θα χρησιμοποιήσουν οι κανονικές διαφάνειες.

**Μπορώ να διαγράψω μια master slide που χρησιμοποιείται ακόμα;**

Όχι. Μια master slide που έχει εξαρτημένες διαφάνειες δεν μπορεί να αφαιρεθεί άμεσα. Πρώτα μετακινήστε αυτές τις διαφάνειες σε layout κάτω από άλλη master, ή χρησιμοποιήστε τη μέθοδο καθαρισμού μη χρησιμοποιούμενων master που αφαιρεί μόνο τις masters που δεν χρησιμοποιούνται.