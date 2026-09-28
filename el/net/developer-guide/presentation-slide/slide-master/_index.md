---
title: Διαχείριση Master Διαφανειών Παρουσίασης σε .NET
linktitle: Master Διαφάνειας
type: docs
weight: 80
url: /el/net/slide-master/
keywords:
- master διαφάνειας
- master διαφάνειας
- master διαφάνειας PPT
- πολλαπλοί master διαφάνειες
- σύγκριση master διαφανειών
- παρασκήνιο
- placeholder
- κλωνοποίηση master διαφάνειας
- αντιγραφή master διαφάνειας
- αντίγραφο master διαφάνειας
- αχρησιμοποίητη master διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαχειριστείτε τα master διαφάνειας στο Aspose.Slides για .NET: πρόσβαση, επεξεργασία, κλωνοποίηση, σύγκριση και αφαίρεση master διαφανειών σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Ένας **master διαφάνειας** ορίζει κοινές ρυθμίσεις σχεδίασης για μια ομάδα διαφανειών. Μπορεί να περιέχει κοινά σχήματα, λογότυπα, παρασκήνια, στυλ κειμένου, ρυθμίσεις θέματος και ρυθμίσεις υποσέλιδου. Στο PowerPoint, η επεξεργασία ενός master διαφάνειας είναι ο συνηθισμένος τρόπος να διατηρείται μια παρουσίαση συνεπής χωρίς να επαναλαμβάνεται η ίδια μορφοποίηση σε κάθε διαφάνεια.

Το Aspose.Slides for .NET υποστηρίζει το ίδιο μοντέλο. Μια παρουσίαση μπορεί να περιέχει μία ή περισσότερες master διαφάνειες, και κάθε master διαφάνεια μπορεί να περιέχει αρκετές διαφάνειες διάταξης. Οι κανονικές διαφάνειες συνήθως δεν αναφέρονται απευθείας σε μια master διαφάνεια. Αντ' αυτού, μια κανονική διαφάνεια χρησιμοποιεί μια διαφάνεια διάταξης, η οποία ανήκει σε μια master διαφάνεια.

Η ιεραρχία είναι:

1. **Master διαφάνειας** – ορίζει το κοινό σχέδιο και το θέμα.  
1. **Διαφάνεια διάταξης** – ορίζει μια συγκεκριμένη διάταξη στοιχείων κράτησης θέσης και μορφοποίησης επιπέδου διάταξης.  
1. **Κανονική διαφάνεια** – περιέχει το πραγματικό περιεχόμενο της παρουσίασης και χρησιμοποιεί μία διαφάνεια διάταξης.

![Η ιεραρχία των master διαφανειών, διαφανειών διάταξης και κανονικών διαφανειών](slide-master_2.jpg)

Στο Aspose.Slides, ένας master διαφάνειας αντιπροσωπεύεται από τη διεπαφή [IMasterSlide](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslide/). Όλοι οι master διαφάνειες σε μια παρουσίαση είναι διαθέσιμοι μέσω της συλλογής [Presentation.Masters](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/masters/), η οποία υλοποιεί το [IMasterSlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}

Όταν η ίδια ιδιότητα ορίζεται σε περισσότερα από ένα επίπεδα, το πιο συγκεκριμένο επίπεδο υπερισχύει. Για παράδειγμα, εάν ένας master διαφάνειας και μια διαφάνεια διάταξης ορίζουν και οι δύο ένα παρασκήνιο, οι διαφάνειες που βασίζονται σε αυτή τη διάταξη χρησιμοποιούν το παρασκήνιο της διάταξης. Για περισσότερες πληροφορίες σχετικά με τις διαφάνειες διάταξης, δείτε [Apply or Change Slide Layouts](/slides/el/net/slide-layout/).

{{% /alert %}}

## **Πρόσβαση σε Master Διαφάνειες**

Στο PowerPoint, μπορείτε να ανοίξετε την προβολή Master διαφάνειας από **View** > **Slide Master**.

![Η εντολή Master διαφάνειας στην καρτέλα View του PowerPoint](slide-master_3.jpg)

Στο Aspose.Slides, χρησιμοποιήστε τη συλλογή `Masters` για να αποκτήσετε πρόσβαση στους master διαφάνειες:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Μπορείτε επίσης να λάβετε τη master διαφάνειας που χρησιμοποιείται από μια κανονική διαφάνεια μέσω της διάταξής της:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Τι Περιέχει ένας Master Διαφάνειας**

Ένας master διαφάνειας είναι ένα αντικείμενο τύπου διαφάνειας. Εφαρμόζει το [IBaseSlide](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseslide/), έτσι ώστε να εκθέτει πολλές από τις ίδιες ιδιότητες διαφάνειας που χρησιμοποιούνται από κανονικές και διαφάνειες διάταξης. Τα μέλη που αφορούν μόνο τον master αναφέρονται στη σελίδα API του [IMasterSlide](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslide/).

Κοινά χρησιμοποιούμενα μέλη master διαφάνειας περιλαμβάνουν:

| Μέλος | Σκοπός |
| --- | --- |
| `Background` | Ορίζει το παρασκήνιο σε επίπεδο master. |
| `Shapes` | Αποθηκεύει σχήματα που τοποθετούνται στον master, όπως λογότυπα, πλαίσια εικόνας και κοινό κείμενο. |
| `LayoutSlides` | Αποθηκεύει τις διαφάνειες διάταξης που ανήκουν στον master. |
| `ThemeManager` | Παρέχει πρόσβαση στα API του θέματος master. |
| `HeaderFooterManager` | Διαχειρίζεται κεφαλίδες, υποσέλιδα, ημερομηνίες και αριθμούς διαφανειών για τον master και τις θυγατρικές του διατάξεις. |
| `GetDependingSlides` | Επιστρέφει τις κανονικές διαφάνειες που εξαρτώνται από τον master μέσω των διατάξεών τους. |

## **Προσθήκη Εικόνας σε Master Διαφάνειας**

Όταν προσθέτετε μια εικόνα σε έναν master διαφάνειας, εμφανίζεται στις διαφάνειες που χρησιμοποιούν διατάξεις από αυτόν τον master. Αυτό είναι χρήσιμο για λογότυπα, υδατογραφήματα, διακοσμητικές λωρίδες και άλλα επαναλαμβανόμενα οπτικά στοιχεία.

Το παρακάτω παράδειγμα προσθέτει ένα λογότυπο στην πρώτη master διαφάνειας:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

Για περισσότερες πληροφορίες σχετικά με τα πλαίσια εικόνας, δείτε [Picture Frame](/slides/el/net/picture-frame/).

## **Έλεγχος Ορατότητας Γραφικών Master**

Χρησιμοποιήστε το [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseslide/showmastershapes/) για να κρύψετε κληθέντα γραφικά master, όπως λογότυπα ή διακοσμητικά σχήματα, χωρίς να τα διαγράψετε από τον master. Ορίστε το [Slide.ShowMasterShapes](https://reference.aspose.com/slides/el/net/aspose.slides/slide/showmastershapes/) σε `false` στη διαφάνεια που πρέπει να παραλείπει αυτά τα γραφικά και διατηρήστε το `true` στις διαφάνειες που πρέπει να τα εμφανίζουν.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί μια μπλε διακοσμητική λωρίδα σε έναν master και δύο διαφάνειες που χρησιμοποιούν την ίδια κενή διάταξη. Η λωρίδα είναι ορατή στην πρώτη διαφάνεια και κρυφή στη δεύτερη. Δεν απαιτείται παρουσίαση εισόδου ή εικόνα.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

Το παράδειγμα χρησιμοποιεί τη διάταξη **Blank** που παρέχεται με μια νέα παρουσίαση και αφαιρεί τα αρχικά στοιχεία κράτησης θέσης της πρώτης διαφάνειας.

### **Επιλογή του Πεδίου Εφαρμογής της Ρύθμισης**

Μια κανονική διαφάνεια χρησιμοποιεί τον master της μέσω του [ISlide.LayoutSlide](https://reference.aspose.com/slides/el/net/aspose.slides/islide/layoutslide/) και του [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/masterslide/). Η ρύθμιση της ιδιότητας σε μεμονωμένη διαφάνεια επηρεάζει μόνο εκείνη τη διαφάνεια. Ορίζοντας το [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/el/net/aspose.slides/layoutslide/showmastershapes/) σε `false` κρύβει τα γραφικά master για όλες τις διαφάνειες που χρησιμοποιούν αυτή τη κοινή διάταξη, ακόμη και αν η δική τους ρύθμιση είναι `true`. Για να κρύψετε γραφικά μόνο σε μία διαφάνεια, αλλάξτε την ιδιότητα της διαφάνειας και αφήστε την κοινή διάταξη αμετάβλητη.

Η ρύθμιση δεν υποστηρίζεται ως έλεγχος ορατότητας στη ίδια τη master διαφάνειας. Σε έναν master επιστρέφει πάντα `false`, και η ανάθεση `true` προκαλεί `NotSupportedException`. Εφαρμόστε την σε κανονική διαφάνεια ή σε διάταξη.

### **Διαχωρισμός Γραφικών από το Παρασκήνιο**

| Ενέργεια | Αποτέλεσμα |
| --- | --- |
| Απόκρυψη γραφικών master | Ελέγχει την ορατότητα των κληθέντων σ shapes master χωρίς διαγραφή ή αλλαγή των δικών σας σχημάτων στη διαφάνεια. |
| Αλλαγή γεμίσματος παρασκηνίου διαφάνειας | Αλλάζει το χρώμα, το διαβάθμιση ή την εικόνα του παρασκηνίου. Τα γραφικά master είναι ξεχωριστά σ shapes και μπορούν να παραμείνουν ορατά πάνω από το παρασκήνιο. Δείτε [Presentation Background](/slides/el/net/presentation-background/). |
| Διαγραφή σ shape από τον master | Αφαιρεί το κοινό σ shape‑πηγή, ώστε να μην είναι πλέον διαθέσιμο σε καμία διαφάνεια που χρησιμοποιεί αυτόν τον master. |

## **Δουλειά με Placeholders**

Τα placeholders ορίζονται κανονικά στις διαφάνειες διάταξης. Ο master διαφάνειας παρέχει το κοινό στυλ και θέμα που κληρονομούν αυτές οι διατάξεις, ενώ κάθε διάταξη αποφασίζει ποια placeholders είναι διαθέσιμα και πού τοποθετούνται.

Στο PowerPoint, οι εντολές placeholder διατίθενται στην προβολή Master διαφάνειας.

![Η εντολή Insert Placeholder στην προβολή Master διαφάνειας του PowerPoint](slide-master_5.png)

Για να προσθέσετε νέα placeholders με το Aspose.Slides, εργαστείτε με τη διαφάνεια διάταξης που ανήκει στον master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

Μπορείτε επίσης να μορφοποιήσετε σ shapes placeholders που υπάρχουν ήδη σε έναν master διαφάνειας. Το παρακάτω παράδειγμα βρίσκει το placeholder τίτλου και εφαρμόζει ένα γραμμικό γέμισμα διαβάθμισης:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![Μορφοποιημένο placeholder τίτλου κληρονομούμενο από τις κανονικές διαφάνειες](slide-master_8.png)

Για περισσότερες επιλογές μορφοποίησης placeholders και κειμένου, δείτε [Set Prompt Text in Placeholder](/slides/el/net/manage-placeholder/) και [Text Formatting](/slides/el/net/text-formatting/).

## **Αλλαγή Παρασκηνίου Master Διαφάνειας**

Ένα master παρασκήνιο κληρονομείται από τις διατάξεις και τις διαφάνειες που δεν το παρακάμπτουν. Το παρακάτω παράδειγμα ορίζει ένα σταθερό χρώμα παρασκηνίου για την πρώτη master διαφάνειας:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Για συναφή θέματα, δείτε [Presentation Background](/slides/el/net/presentation-background/) και [Presentation Theme](/slides/el/net/presentation-theme/).

## **Κλωνοποίηση Master Διαφάνειας σε Άλλη Παρουσίαση**

Χρησιμοποιήστε το [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslidecollection/addclone/) για να αντιγράψετε έναν master διαφάνειας σε άλλη παρουσίαση. Ο αντιγραμμένος master μπορεί στη συνέχεια να χρησιμοποιηθεί από διατάξεις και διαφάνειες στην προορισμένη παρουσίαση.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Αν χρειαστεί να κλωνοποιήσετε κανονικές διαφάνειες μαζί με τον master τους, δείτε [Clone Slides](/slides/el/net/clone-slides/).

## **Προσθήκη Πολλαπλών Master Διαφανειών**

Μια παρουσίαση μπορεί να περιέχει πολλαπλούς master διαφάνειες. Αυτό είναι χρήσιμο όταν διαφορετικές ενότητες απαιτούν διαφορετικό branding, δομή σελίδας ή ρυθμίσεις θέματος.

![Εντολές PowerPoint για εισαγωγή και διαχείριση master διαφανειών](slide-master_9.jpg)

Το παρακάτω παράδειγμα κλωνοποιεί τον προεπιλεγμένο master, δίνει στον κλώνο διαφορετικό παρασκήνιο, δημιουργεί μια διάταξη κάτω από αυτόν τον κλώνο και προσθέτει μια νέα διαφάνεια βασισμένη σε αυτήν τη διάταση:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **Σύγκριση Master Διαφανειών**

Οι master διαφάνειες μπορούν να συγκριθούν με τη μέθοδο `Equals` που κληρονομείται από το [IBaseSlide](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseslide/). Η σύγκριση ελέγχει τη δομή και το στατικό περιεχόμενο, όπως σ shapes, κείμενο, μορφοποίηση, animations και άλλες ρυθμίσεις διαφάνειας. Δεν συγκρίνει μοναδικά αναγνωριστικά, όπως slide IDs, ή δυναμικές τιμές placeholders, όπως η τρέχουσα ημερομηνία.

```csharp
using Aspose.Slides;

using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

Για περισσότερες πληροφορίες, δείτε [Compare Presentation Slides](/slides/el/net/compare-slides/).

## **Ορισμός Προβολής Master Διαφάνειας ως Προεπιλεγμένη Προβολή**

Χρησιμοποιήστε την ιδιότητα `LastView` στο [ViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/) για να ελέγξετε την προβολή που ανοίγει πρώτο το PowerPoint. Το παρακάτω παράδειγμα ανοίγει την παρουσίαση σε προβολή Master διαφάνειας:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Για περισσότερες ρυθμίσεις προβολής, δείτε [Save Presentation](/slides/el/net/save-presentation/).

## **Αφαίρεση Αχρησιμοποίητων Master Διαφανειών**

Μερικές φορές οι παρουσιάσεις περιέχουν master διαφάνειες που δεν χρησιμοποιούνται πλέον από καμία κανονική διαφάνεια. Η αφαίρεση αχρησιμοποίητων master μπορεί να μειώσει το μέγεθος του αρχείου και να απλοποιήσει τη συντήρηση του προτύπου.

Χρησιμοποιήστε τη μέθοδο [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/el/net/aspose.slides/masterslidecollection/removeunused/) για να αφαιρέσετε αχρησιμοποίητους master από τη συλλογή `Masters`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Μπορείτε επίσης να χρησιμοποιήσετε τη μέθοδο low‑code [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ master διαφάνειας και διαφάνειας διάταξης;**

Ένας master διαφάνειας ορίζει κοινές ρυθμίσεις σχεδίασης όπως θέμα, παρασκήνιο, κοινά σ shapes και στυλ κειμένου. Μια διαφάνεια διάταξης ανήκει σε έναν master διαφάνειας και ορίζει μια συγκεκριμένη διάταξη placeholders. Μια κανονική διαφάνεια χρησιμοποιεί μια διαφάνεια διάταξης, έτσι κληρονομεί τόσο από τη διάταξη όσο και από τον master.

**Μπορεί μια παρουσίαση να περιέχει πολλούς master διαφάνειες;**

Ναι. Μια παρουσίαση μπορεί να περιέχει πολλούς master διαφάνειες. Χρησιμοποιήστε πολλαπλούς master όταν διαφορετικές ενότητες χρειάζονται διαφορετικά οπτικά συστήματα ή branding.

**Πρέπει να προσθέσω placeholders σε master διαφάνειας ή σε διαφάνεια διάταξης;**

Στις περισσότερες περιπτώσεις, προσθέστε placeholders σε διαφάνειες διάταξης. Τοποθετήστε κοινά οπτικά στοιχεία και κοινή μορφοποίηση στον master διαφάνειας και τα περιεχόμενα placeholders στις διατάξεις που θα χρησιμοποιήσουν οι κανονικές διαφάνειες.

**Μπορώ να διαγράψω έναν master διαφάνειας που χρησιμοποιείται ακόμα;**

Όχι. Ένας master διαφάνειας που έχει εξαρτώμενες διαφάνειες δεν μπορεί να αφαιρεθεί με ασφάλεια. Μετακινήστε πρώτα αυτές τις διαφάνειες σε διατάξεις κάτω από άλλο master ή χρησιμοποιήστε μια μέθοδο καθαρισμού αχρησιμοποίητων master που αφαιρεί μόνο τους master που δεν είναι σε χρήση.