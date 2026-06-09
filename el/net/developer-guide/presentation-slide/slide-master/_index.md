---
title: "Διαχείριση master διαφανειών σε .NET"
linktitle: "Master Διαφάνειας"
type: docs
weight: 80
url: /el/net/slide-master/
keywords:
- "master διαφάνειας"
- "master διαφάνειας"
- "master διαφάνειας PPT"
- "πολλαπλά master slides"
- "σύγκριση master slides"
- φόντο
- "σύμβολο κράτησης"
- "κλώνος master slide"
- "αντιγραφή master slide"
- "αντίγραφο master slide"
- "αχρησιμοποίητο master slide"
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαχείριση master διαφανειών στο Aspose.Slides για .NET: πρόσβαση, επεξεργασία, κλωνοποίηση, σύγκριση και αφαίρεση master διαφανειών σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Ένας **slide master** ορίζει κοινές ρυθμίσεις σχεδίασης για μια ομάδα διαφανειών. Μπορεί να περιέχει κοινά σχήματα, λογότυπα, φόντα, στυλ κειμένου, ρυθμίσεις θέματος και ρυθμίσεις υποσέλιδου. Στο PowerPoint, η επεξεργασία ενός slide master είναι ο συνηθισμένος τρόπος να διατηρείται μια παρουσίαση συνεπής χωρίς να επαναλαμβάνεται η ίδια μορφοποίηση σε κάθε διαφάνεια.

Το Aspose.Slides για .NET υποστηρίζει το ίδιο μοντέλο. Μια παρουσίαση μπορεί να περιέχει μία ή περισσότερες master slides, και κάθε master slide μπορεί να περιέχει αρκετές layout slides. Οι κανονικές διαφάνειες συνήθως δεν αναφέρονται απευθείας σε μια master slide. Αντίθετα, μια κανονική διαφάνεια χρησιμοποιεί μια layout slide, η οποία ανήκει σε μια master slide.

Η ιεραρχία είναι:

1. **Slide master** - ορίζει το κοινό σχέδιο και το θέμα.
1. **Layout slide** - ορίζει μια συγκεκριμένη διάταξη στοιχείων κράτησης θέσης και μορφοποίησης επιπέδου διάταξης.
1. **Normal slide** - περιέχει το πραγματικό περιεχόμενο της παρουσίασης και χρησιμοποιεί μια layout slide.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

Στο Aspose.Slides, ένα slide master αντιπροσωπεύεται από τη διεπαφή [IMasterSlide](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslide/). Όλες οι master slides σε μια παρουσίαση είναι διαθέσιμες μέσω της συλλογής [Presentation.Masters](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/masters/), η οποία υλοποιεί το [IMasterSlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Κληρονομικότητα" %}}
Όταν η ίδια ιδιότητα ορίζεται σε περισσότερα από ένα επίπεδα, το πιο συγκεκριμένο επίπεδο κερδίζει. Για παράδειγμα, αν μια master slide και μια layout slide ορίζουν και οι δύο ένα φόντο, οι διαφάνειες που βασίζονται σε αυτή τη διάταξη θα χρησιμοποιούν το φόντο της διάταξης. Για περισσότερες πληροφορίες σχετικά με τις layout slides, δείτε [Εφαρμογή ή Αλλαγή Διατάξεων Διαφανειών](/slides/el/net/slide-layout/).
{{% /alert %}}

## **Πρόσβαση σε Slide Masters**

Στο PowerPoint, μπορείτε να ανοίξετε την προβολή Slide Master από **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

Στο Aspose.Slides, χρησιμοποιήστε τη συλλογή `Masters` για να έχετε πρόσβαση στις master slides:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Μπορείτε επίσης να λάβετε το master slide που χρησιμοποιεί μια κανονική διαφάνεια μέσω της διάταξής της:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Τι Περιέχει ένα Slide Master**

Ένα master slide είναι ένα αντικείμενο παρόμοιο με διαφάνεια. Υλοποιεί το [IBaseSlide](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseslide/), έτσι εκθέτει πολλές από τις ίδιες ιδιότητες διαφάνειας που χρησιμοποιούνται από κανονικές και layout διαφάνειες. Τα μέλη που αφορούν συγκεκριμένα το master παρατίθενται στη σελίδα API του [IMasterSlide](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslide/).

Κοινά χρησιμοποιούμενα μέλη master slide περιλαμβάνουν:

| Μέλος | Σκοπός |
| --- | --- |
| `Background` | Ορίζει το φόντο σε επίπεδο master slide. |
| `Shapes` | Αποθηκεύει σχήματα που τοποθετούνται στο master, όπως λογότυπα, πλαίσια εικόνας και κοινό κείμενο. |
| `LayoutSlides` | Αποθηκεύει τις layout slides που ανήκουν στο master. |
| `ThemeManager` | Παρέχει πρόσβαση στα API του θέματος master. |
| `HeaderFooterManager` | Ελέγχει κεφαλίδες, υποσέλιδα, ημερομηνίες και αριθμούς διαφανειών για το master και τις παιδικές του διατάξεις. |
| `GetDependingSlides` | Επιστρέφει κανονικές διαφάνειες που εξαρτώνται από το master μέσω των διατάξεων τους. |

## **Προσθήκη Εικόνας σε Slide Master**

Όταν προσθέτετε μια εικόνα σε ένα master slide, εμφανίζεται στις διαφάνειες που χρησιμοποιούν διατάξεις από αυτό το master. Αυτό είναι χρήσιμο για λογότυπα, υδατογραφήματα, διακοσμητικές λωρίδες και άλλα επαναλαμβανόμενα οπτικά στοιχεία.

Το παρακάτω παράδειγμα προσθέτει ένα λογότυπο στην πρώτη master slide:

```csharp
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

Για περισσότερες πληροφορίες σχετικά με τα πλαίσια εικόνας, δείτε [Πλαίσιο Εικόνας](/slides/el/net/picture-frame/).

## **Εργασία με Placeholders**

Τα placeholders ορίζονται κανονικά σε layout slides. Το master slide παρέχει το κοινό στυλ και το θέμα που κληρονομούν αυτές οι διατάξεις, ενώ κάθε διάταξη αποφασίζει ποια placeholders είναι διαθέσιμα και πού τοποθετούνται.

Στο PowerPoint, οι εντολές placeholder είναι διαθέσιμες στην προβολή Slide Master.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Για να προσθέσετε νέα placeholders με το Aspose.Slides, εργαστείτε με τη layout slide που ανήκει στο master:

```csharp
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

Μπορείτε επίσης να μορφοποιήσετε σχήματα placeholder που ήδη υπάρχουν σε ένα master slide. Το παρακάτω παράδειγμα βρίσκει το placeholder τίτλου και εφαρμόζει γραμμική βαθμωτή γέμιση:

```csharp
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

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Για περισσότερες επιλογές μορφοποίησης placeholders και κειμένου, δείτε [Ορισμός Κειμένου Prompt σε Placeholder](/slides/el/net/manage-placeholder/) και [Μορφοποίηση Κειμένου](/slides/el/net/text-formatting/).

## **Αλλαγή Φόντου Slide Master**

Ένα φόντο master κληρονομείται από τις διατάξεις και τις διαφάνειες που δεν το παρακάμπτουν. Το παρακάτω παράδειγμα ορίζει ένα συμπαγές χρώμα φόντου για την πρώτη master slide:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Για συναφή θέματα, δείτε [Φόντο Παρουσίασης](/slides/el/net/presentation-background/) και [Θέμα Παρουσίασης](/slides/el/net/presentation-theme/).

## **Αντιγραφή Slide Master σε Άλλη Παρουσίαση**

Χρησιμοποιήστε το [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslidecollection/addclone/) για να αντιγράψετε ένα master slide σε άλλη παρουσίαση. Το αντίγραφο master μπορεί στη συνέχεια να χρησιμοποιηθεί από διατάξεις και διαφάνειες στην προοριστική παρουσίαση.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Αν χρειάζεστε κλώνο κανονικών διαφανειών μαζί με το master τους, δείτε [Κλώνος Διαφανειών](/slides/el/net/clone-slides/).

## **Προσθήκη Πολλαπλών Slide Masters**

Μια παρουσίαση μπορεί να περιέχει πολλαπλά master slides. Αυτό είναι χρήσιμο όταν διαφορετικές ενότητες απαιτούν διαφορετική εταιρική ταυτότητα, δομή σελίδας ή ρυθμίσεις θέματος.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Το παρακάτω παράδειγμα κλωνοποιεί το προεπιλεγμένο master, δίνει στο κλώνο διαφορετικό φόντο, δημιουργεί μια διαρρύθμιση κάτω από αυτό το κλωνοποιημένο master και προσθέτει μια νέα διαφάνεια βασισμένη σε αυτή τη διάταξη:

```csharp
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

## **Σύγκριση Slide Masters**

Τα master slides μπορούν να συγκριθούν με τη μέθοδο `Equals` που κληρονομείται από το [IBaseSlide](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseslide/). Η σύγκριση ελέγχει τη δομή και το στατικό περιεχόμενο, όπως σχήματα, κείμενο, μορφοποίηση, κινήσεις και άλλες ρυθμίσεις διαφάνειας. Δεν συγκρίνει μοναδικά αναγνωριστικά, όπως τα IDs διαφανειών, ή δυναμικές τιμές placeholders, όπως η τρέχουσα ημερομηνία.

```csharp
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

Για περισσότερες πληροφορίες, δείτε [Σύγκριση Διαφανειών Παρουσίασης](/slides/el/net/compare-slides/).

## **Ορισμός Προβολής Slide Master ως Προεπιλεγμένη Προβολή**

Χρησιμοποιήστε την ιδιότητα `LastView` στην [ViewProperties](https://reference.aspose.com/slides/el/net/aspose.slides/viewproperties/) για να ελέγξετε την προβολή που ανοίγει πρώτο το PowerPoint. Το παρακάτω παράδειγμα ανοίγει την παρουσίαση στην προβολή Slide Master:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Για περισσότερες ρυθμίσεις προβολής, δείτε [Αποθήκευση Παρουσίασης](/slides/el/net/save-presentation/).

## **Αφαίρεση Μη Χρησιμοποιούμενων Master Slides**

Οι παρουσιάσεις μερικές φορές περιέχουν master slides που δεν χρησιμοποιούνται πλέον από καμία κανονική διαφάνεια. Η αφαίρεση των μη χρησιμοποιούμενων masters μπορεί να μειώσει το μέγεθος του αρχείου και να απλοποιήσει τη συντήρηση του προτύπου.

Χρησιμοποιήστε το [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/el/net/aspose.slides/masterslidecollection/removeunused/) για να αφαιρέσετε τους μη χρησιμοποιούμενους masters από τη συλλογή `Masters`:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Μπορείτε επίσης να χρησιμοποιήσετε τη μέθοδο low-code [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ ενός slide master και μιας layout slide;**

Ένας slide master ορίζει κοινές ρυθμίσεις σχεδίασης όπως θέμα, φόντο, κοινά σχήματα και στυλ κειμένου. Μια layout slide ανήκει σε ένα master slide και ορίζει μια συγκεκριμένη διάταξη placeholders. Μια κανονική διαφάνεια χρησιμοποιεί μια layout slide, έτσι κληρονομεί τόσο από τη διάταξη όσο και από το master.

**Μπορεί μια παρουσίαση να περιέχει πολλαπλά slide masters;**

Ναι. Μια παρουσίαση μπορεί να περιέχει πολλαπλά slide masters. Χρησιμοποιήστε πολλαπλούς masters όταν διαφορετικές ενότητες χρειάζονται διαφορετικά οπτικά συστήματα ή εταιρική ταυτότητα.

**Πρέπει να προσθέτω placeholders σε ένα master slide ή σε μια layout slide;**

Στις περισσότερες περιπτώσεις, προσθέτετε placeholders σε layout slides. Τοποθετήστε κοινά οπτικά στοιχεία και κοινή μορφοποίηση στο master slide, και τοποθετήστε τα placeholders περιεχομένου στις διατάξεις που θα χρησιμοποιήσουν οι κανονικές διαφάνειες.

**Μπορώ να διαγράψω ένα master slide που εξακολουθεί να χρησιμοποιείται;**

Όχι. Ένα master slide που έχει εξαρτημένες διαφάνειες δεν μπορεί να αφαιρεθεί με ασφάλεια. Πρώτα μετακινήστε αυτές τις διαφάνειες σε διατάξεις υπό άλλο master, ή χρησιμοποιήστε μια μέθοδο εκκαθάρισης μη χρησιμοποιούμενων masters που αφαιρεί μόνο τους masters που δεν είναι σε χρήση.