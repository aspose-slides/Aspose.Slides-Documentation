---
title: Διαχείριση master διαφανειών παρουσίασης σε Android
linktitle: Master Διαφάνειας
type: docs
weight: 70
url: /el/androidjava/slide-master/
keywords:
- master διαφάνειας
- master διαφάνειας
- PPT master διαφάνειας
- πολλαπλά master διαφάνειας
- σύγκριση master διαφάνειας
- φόντο
- σύμβολο κράτησης
- κλωνοποίηση master διαφάνειας
- αντιγραφή master διαφάνειας
- αντίγραφο master διαφάνειας
- αχρησιμοποίητο master διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τα master διαφάνειας στο Aspose.Slides για Android μέσω Java: πρόσβαση, επεξεργασία, κλωνοποίηση, σύγκριση και κατάργηση των master διαφανειών σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Ένας **slide master** ορίζει κοινές ρυθμίσεις σχεδίασης για μια ομάδα διαφανειών. Μπορεί να περιέχει κοινά σχήματα, λογότυπα, φόντο, στυλ κειμένου, ρυθμίσεις θέματος και ρυθμίσεις υποσέλιδου. Στο PowerPoint, η επεξεργασία ενός slide master είναι ο συνηθισμένος τρόπος να διατηρείται μια παρουσίαση συνεπής χωρίς να επαναλαμβάνεται η ίδια μορφοποίηση σε κάθε διαφάνεια.

Aspose.Slides for Android via Java υποστηρίζει το ίδιο μοντέλο. Μια παρουσίαση μπορεί να περιέχει ένα ή περισσότερα master slides και κάθε master slide μπορεί να περιέχει πολλά layout slides. Οι κανονικές διαφάνειες συνήθως δεν αναφέρονται απευθείας σε ένα master slide. Αντίθετα, μια κανονική διαφάνεια χρησιμοποιεί ένα layout slide, το οποίο ανήκει σε ένα master slide.

Η ιεραρχία είναι:

1. **Slide master** - ορίζει το κοινό σχέδιο και το θέμα.
1. **Layout slide** - ορίζει μια συγκεκριμένη διάταξη placeholders και μορφοποίησης επιπέδου διάταξης.
1. **Normal slide** - περιέχει το πραγματικό περιεχόμενο της παρουσίασης και χρησιμοποιεί ένα layout slide.

![Η ιεραρχία των master slides, layout slides και normal slides](slide-master_2.jpg)

Στο Aspose.Slides, ένα slide master αντιπροσωπεύεται από το interface [IMasterSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslide/) . Όλες οι master slides σε μια παρουσίαση είναι διαθέσιμες μέσω της συλλογής [Presentation.getMasters](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getMasters--) , η οποία υλοποιεί το [IMasterSlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslidecollection/). Για το πλήρες σύνολο API Android μέσω Java, δείτε το [com.aspose.slides API reference](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
Όταν η ίδια ιδιότητα ορίζεται σε περισσότερα από ένα επίπεδα, το πιο συγκεκριμένο επίπεδο προτεραιότητα. Για παράδειγμα, εάν ένα master slide και ένα layout slide ορίζουν και τα δύο ένα φόντο, οι διαφάνειες που βασίζονται σε εκείνη τη διάταξη χρησιμοποιούν το φόντο της διάταξης. Για περισσότερες πληροφορίες σχετικά με τα layout slides, δείτε το [Apply or Change Slide Layouts](/slides/el/androidjava/slide-layout/).
{{% /alert %}}

## **Πρόσβαση σε Slide Masters**

Στο PowerPoint, μπορείτε να ανοίξετε την προβολή Slide Master από **View** > **Slide Master**.

![Η εντολή Slide Master στην καρτέλα View του PowerPoint](slide-master_3.jpg)

Στο Aspose.Slides, χρησιμοποιήστε τη συλλογή `getMasters()` για να αποκτήσετε πρόσβαση στα master slides:

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

Μπορείτε επίσης να λάβετε το master slide που χρησιμοποιείται από μια κανονική διαφάνεια μέσω της διάταξής της:

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

Ένα master slide είναι ένα αντικείμενο τύπου διαφάνειας. Υλοποιεί το [IBaseSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseslide/), επομένως εκθέτει πολλές από τις ίδιες ιδιότητες διαφάνειας που χρησιμοποιούνται από κανονικές και layout διαφάνειες.

Τα πιο συχνά χρησιμοποιούμενα μέλη του master slide περιλαμβάνουν:

| Μέλος | Σκοπός |
| --- | --- |
| `getBackground()` | Ορίζει το φόντο της διαφάνειας σε επίπεδο master. |
| `getShapes()` | Αποθηκεύει τα σχήματα που τοποθετούνται στο master, όπως λογότυπα, πλαίσια εικόνας και κοινό κείμενο. |
| `getLayoutSlides()` | Αποθηκεύει τα layout slides που ανήκουν στο master. |
| `getThemeManager()` | Παρέχει πρόσβαση στα API του θέματος του master. |
| `getHeaderFooterManager()` | Ελέγχει κεφαλίδες, υποσέλιδα, ημερομηνίες και αριθμούς διαφανειών για το master και τις παιδικές του διατάξεις. |
| `getDependingSlides()` | Επιστρέφει τις κανονικές διαφάνειες που εξαρτώνται από το master μέσω των διατάξεων τους. |

## **Προσθήκη Εικόνας σε Slide Master**

Όταν προσθέτετε μια εικόνα σε ένα master slide, εμφανίζεται στις διαφάνειες που χρησιμοποιούν διατάξεις από αυτό το master. Αυτό είναι χρήσιμο για λογότυπα, υδατογραφήματα, διακοσμητικές λωρίδες και άλλα επαναλαμβανόμενα οπτικά στοιχεία.

Το παρακάτω παράδειγμα προσθέτει ένα λογότυπο στο πρώτο master slide:

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

Για περισσότερες πληροφορίες σχετικά με τα πλαίσια εικόνας, δείτε το [Picture Frame](/slides/el/androidjava/picture-frame/).

## **Έλεγχος Ορατότητας των Γραφικών του Master**

Χρησιμοποιήστε το [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) για να κρύψετε τα κληρονομημένα γραφικά του master, όπως λογότυπα ή διακοσμητικά σχήματα, χωρίς να τα διαγράψετε από το master. Περάστε `false` στη [Slide.setShowMasterShapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) της διαφάνειας που πρέπει να παραλείψει αυτά τα γραφικά και κρατήστε το `true` στις διαφάνειες που πρέπει να τα εμφανίζει.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί μια μπλε διακοσμητική λωρίδα σε ένα master και δύο διαφάνειες που χρησιμοποιούν την ίδια κενή διάταξη. Η λωρίδα είναι ορατή στην πρώτη διαφάνεια και κρυμμένη στη δεύτερη. Δεν απαιτείται είσοδος παρουσίασης ή εικόνα.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
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

Το παράδειγμα χρησιμοποιεί τη διάταξη **Blank** που παρέχεται με μια νέα παρουσίαση και αφαιρεί τα δικά του placeholders από την αρχική διαφάνεια.

### **Επιλογή Εύρους της ρύθμισης**

Μια κανονική διαφάνεια χρησιμοποιεί το master της μέσω των [ISlide.getLayoutSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/#getLayoutSlide--) και [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--). Ορίζοντας την ιδιότητα σε μια μεμονωμένη διαφάνεια επηρεάζει μόνο αυτή τη διαφάνεια. Περάτοντας `false` στη [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) κρύβετε τα γραφικά του master για τις διαφάνειες που χρησιμοποιούν αυτή την κοινή διάταξη, ακόμη και αν η δική τους ρύθμιση είναι `true`. Για να κρύψετε τα γραφικά μόνο σε μία διαφάνεια, αλλάξτε την ιδιότητα της διαφάνειας και αφήστε την κοινή διάταξη αμετάβλητη.

Η ρύθμιση δεν υποστηρίζεται ως έλεγχος ορατότητας στο ίδιο το master slide. Σε ένα master, η [getShowMasterShapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) επιστρέφει πάντα `false`, και περνώντας `true` στη [setShowMasterShapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) προκαλεί εξαίρεση. Εφαρμόστε την σε μια κανονική διαφάνεια ή σε μια διάταξη.

### **Διαχωρισμός Γραφικών από το Φόντο**

| Λειτουργία | Αποτέλεσμα |
| --- | --- |
| Κρύψιμο των γραφικών του master | Ελέγχει την ορατότητα των κληρονομημένων σ_shapeμάτων master χωρίς να τα διαγράψει ή να αλλάξει τα δικά σχήματα της διαφάνειας. |
| Αλλαγή γεμίσματος φόντου διαφάνειας | Αλλάζει το χρώμα, το διαβάθμιση ή την εικόνα του φόντου. Τα γραφικά του master είναι ξεχωριστά σχήματα και μπορούν να παραμείνουν ορατά πάνω σε αυτό το φόντο. Δείτε το [Presentation Background](/slides/el/androidjava/presentation-background/). |
| Διαγραφή σχήματος από το master | Αφαιρεί το κοινό σχήμα προέλευσης, ώστε να μην είναι πλέον διαθέσιμο σε καμία διαφάνεια που χρησιμοποιεί αυτό το master. |

## **Εργασία με Placeholders**

Τα placeholders ορίζονται συνήθως σε layout slides. Το master slide παρέχει το κοινό στυλ και θέμα που κληρονομούν αυτές οι διατάξεις, ενώ κάθε διάταξη αποφασίζει ποια placeholders είναι διαθέσιμα και πού τοποθετούνται.

Στο PowerPoint, οι εντολές placeholder είναι διαθέσιμες στην προβολή Slide Master.

![Η εντολή Insert Placeholder στην προβολή Slide Master του PowerPoint](slide-master_5.png)

Για να προσθέσετε νέα placeholders με το Aspose.Slides, εργαστείτε με το layout slide που ανήκει στο master:

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

Μπορείτε επίσης να μορφοποιήσετε σχήματα placeholder που υπάρχουν ήδη σε ένα master slide. Το παρακάτω παράδειγμα βρίσκει το placeholder τίτλου και εφαρμόζει ένα γραμμικό γεμισμα διαβάθμισης:

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

![Μορφοποιημένο placeholder τίτλου που κληρονομείται από τις κανονικές διαφάνειες](slide-master_8.png)

Για περισσότερες επιλογές placeholder και μορφοποίησης κειμένου, δείτε το [Set Prompt Text in Placeholder](/slides/el/androidjava/manage-placeholder/) και το [Text Formatting](/slides/el/androidjava/text-formatting/).

## **Αλλαγή Φόντου Slide Master**

Ένα φόντο master κληρονομείται από τις διατάξεις και τις διαφάνειες που δεν το υπερισχύουν. Το παρακάτω παράδειγμα ορίζει ένα συμπαγές χρώμα φόντου για το πρώτο master slide:

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

Για συναφή θέματα, δείτε το [Presentation Background](/slides/el/androidjava/presentation-background/) και το [Presentation Theme](/slides/el/androidjava/presentation-theme/).

## **Κλωνοποίηση Slide Master σε Άλλη Παρουσίαση**

Χρησιμοποιήστε το [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) για να αντιγράψετε ένα master slide σε άλλη παρουσίαση. Το αντίγραφο master μπορεί στη συνέχεια να χρησιμοποιηθεί από τις διατάξεις και τις διαφάνειες στην προορισμένη παρουσίαση.

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

Αν χρειάζεστε να κλωνοποιήσετε κανονικές διαφάνειες μαζί με το master τους, δείτε το [Clone Slides](/slides/el/androidjava/clone-slides/).

## **Προσθήκη Πολλαπλών Slide Masters**

Μια παρουσίαση μπορεί να περιέχει πολλαπλά master slides. Αυτό είναι χρήσιμο όταν διαφορετικά τμήματα απαιτούν διαφορετική επωνυμία, δομή σελίδας ή ρυθμίσεις θέματος.

![Εντολές PowerPoint για την εισαγωγή και διαχείριση master slides](slide-master_9.jpg)

Το παρακάτω παράδειγμα κλωνοποιεί το προεπιλεγμένο master, του δίνει διαφορετικό φόντο, δημιουργεί μια διάταξη κάτω από αυτό το κλωνοποιημένο master και προσθέτει μια νέα διαφάνεια βασισμένη σε αυτή τη διάταξη:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

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

Τα master slides μπορούν να συγκριθούν με τη μέθοδο `equals` που κληρονομείται από το [IBaseSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseslide/). Η σύγκριση ελέγχει τη δομή και το στατικό περιεχόμενο, όπως σχήματα, κείμενο, μορφοποίηση, κινήσεις και άλλες ρυθμίσεις διαφάνειας. Δεν συγκρίνει μοναδικά αναγνωριστικά, όπως slide IDs, ή δυναμικές τιμές placeholders, όπως η τρέχουσα ημερομηνία.

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

Για περισσότερες πληροφορίες, δείτε το [Compare Presentation Slides](/slides/el/androidjava/compare-slides/).

## **Ορισμός Προβολής Slide Master ως Προεπιλεγμένη Προβολή**

Χρησιμοποιήστε τη μέθοδο `setLastView` στο [ViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewproperties/) για να ελέγξετε την προβολή που ανοίγει πρώτο το PowerPoint. Το παρακάτω παράδειγμα ανοίγει την παρουσίαση σε προβολή Slide Master:

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

Για περισσότερες ρυθμίσεις προβολής, δείτε το [Save Presentation](/slides/el/androidjava/save-presentation/).

## **Αφαίρεση Μη Χρησιμοποιούμενων Master Slides**

Μερικές φορές οι παρουσιάσεις περιέχουν master slides που δεν χρησιμοποιούνται πλέον από καμία κανονική διαφάνεια. Η αφαίρεση των μη χρησιμοποιούμενων masters μπορεί να μειώσει το μέγεθος του αρχείου και να απλοποιήσει τη συντήρηση του προτύπου.

Χρησιμοποιήστε το `removeUnused` για να αφαιρέσετε τους μη χρησιμοποιούμενους masters από τη συλλογή `getMasters()`:

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

Μπορείτε επίσης να χρησιμοποιήσετε τη μέθοδο low-code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-):

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

**Ποια είναι η διαφορά μεταξύ ενός slide master και ενός layout slide;**

Ένα slide master ορίζει κοινές ρυθμίσεις σχεδίασης όπως θέμα, φόντο, κοινά σχήματα και στυλ κειμένου. Ένα layout slide ανήκει σε ένα slide master και ορίζει μια συγκεκριμένη διάταξη placeholders. Μια κανονική διαφάνεια χρησιμοποιεί ένα layout slide, έτσι κληρονομεί τόσο από τη διάταξη όσο και από το master.

**Μπορεί μια παρουσίαση να περιέχει πολλαπλά slide masters;**

Ναι. Μια παρουσίαση μπορεί να περιέχει πολλαπλά slide masters. Χρησιμοποιήστε πολλαπλά masters όταν διαφορετικά τμήματα χρειάζονται διαφορετικά οπτικά συστήματα ή επωνυμία.

**Θα πρέπει να προσθέτω placeholders σε ένα master slide ή σε ένα layout slide;**

Στις περισσότερες περιπτώσεις, προσθέτετε placeholders σε layout slides. Τοποθετήστε κοινά οπτικά στοιχεία και κοινή μορφοποίηση στο master slide, και έπειτα τοποθετήστε placeholders περιεχομένου στις διατάξεις που θα χρησιμοποιούν οι κανονικές διαφάνειες.

**Μπορώ να διαγράψω ένα master slide που εξακολουθεί να χρησιμοποιείται;**

Όχι. Ένα master slide που έχει εξαρτημένες διαφάνειες δεν μπορεί να αφαιρεθεί άμεσα με ασφάλεια. Πρώτα μετακινήστε αυτές τις διαφάνειες σε διατάξεις κάτω από άλλο master, ή χρησιμοποιήστε μια μέθοδο καθαρισμού μη χρησιμοποιημένων masters που αφαιρεί μόνο τα masters που δεν είναι σε χρήση.