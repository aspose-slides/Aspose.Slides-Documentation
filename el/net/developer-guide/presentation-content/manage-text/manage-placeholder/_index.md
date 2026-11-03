---
title: Διαχείριση Συμβόλων Κράτησης Παρουσίασης σε .NET
linktitle: Διαχείριση Συμβόλων Κράτησης
type: docs
weight: 10
url: /el/net/manage-placeholder/
keywords:
- σύμβολο κράτησης
- σύμβολο κράτησης κειμένου
- σύμβολο κράτησης εικόνας
- σύμβολο κράτησης διαγράμματος
- σύμβολο κράτησης περιεχομένου
- κείμενο προτροπής
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να ελέγχετε και να επεξεργάζεστε σύμβολα κράτησης κειμένου, εικόνας, διαγράμματος και περιεχομένου και να κατανοείτε την κληρονομικότητα των συμβόλων κράτησης με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Ένα σύμβολο κράτησης είναι ένα σχήμα που διατηρεί μια θέση για ένα συγκεκριμένο τύπο περιεχομένου σε ένα πρότυπο παρουσίασης. Συνήθεις παραδείγματα είναι τα σύμβολα κράτησης τίτλου, κυρίου κειμένου, εικόνας, διαγράμματος και γενικού σκοπού. Σε αντίθεση με ένα συνηθισμένο σχήμα, ένα σύμβολο κράτησης μπορεί να κληρονομήσει τη θέση, το μέγεθος, τη μορφοποίηση και άλλες ρυθμίσεις από μια διαφάνεια διάταξης ή μια κύρια διαφάνεια.

Το Aspose.Slides εκθέτει πληροφορίες σύμβολων κράτησης μέσω της ιδιότητας [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/). Η ιδιότητα επιστρέφει ένα αντικείμενο [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) ή `null` για ένα κανονικό σχήμα. Χρησιμοποιήστε το [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) για να προσδιορίσετε τι προορίζεται να περιέχει το σύμβολο κράτησης.

Η διεπαφή σχήματος εξακολουθεί να έχει σημασία αφού γνωρίζετε τον τύπο του συμβόλου κράτησης:

- Ένα κενό σύμβολο κράτησης κειμένου, εικόνας, διαγράμματος ή περιεχομένου συνήθως αντιπροσωπεύεται από ένα [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
- Ένα γεμάτο σύμβολο κράτησης εικόνας μπορεί να αντιπροσωπεύεται από ένα [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/).
- Ένα γεμάτο σύμβολο κράτησης διαγράμματος μπορεί να αντιπροσωπεύεται από ένα [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/).
- Ένα σύμβολο κράτησης περιεχομένου μπορεί να περιλαμβάνει διάφορους τύπους περιεχομένου. Ελέγξτε τόσο το [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) όσο και τη διεπαφή σχήματος χρόνου εκτέλεσης αντί να υποθέτετε ότι κάθε σύμβολο κράτησης είναι ένα [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) περιγράφει τον ρόλο ενός συμβόλου κράτησης· δεν εγγυάται τον τύπο του σχήματος χρόνου εκτέλεσης. Πάντα πραγματοποιήστε έλεγχο τύπου πριν αποκτήσετε πρόσβαση σε μέλη κειμένου, εικόνας, διαγράμματος, πίνακα ή πολυμέσων.
{{% /alert %}}

## **Κατανόηση Κληρονομικότητας Συμβόλων Κράτησης**

Τα σύμβολα κράτησης σχηματίζουν μια ιεραρχία:

1. Μια κύρια διαφάνεια ορίζει επαναχρησιμοποιήσιμα στυλ και, σε ορισμένες περιπτώσεις, σύμβολα κράτησης επιπέδου κύριας.
2. Μια διαφάνεια διάταξης ορίζει τη διάταξη που χρησιμοποιείται από μία ή περισσότερες κανονικές διαφάνειες και μπορεί να κληρονομήσει από την κύρια.
3. Μια κανονική διαφάνεια περιέχει τα σύμβολα κράτησης για αυτή τη διαφάνεια και μπορεί να κληρονομήσει από τη διάταξή της.

Καλέστε το [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) για να μετακινηθείτε ένα επίπεδο επάνω σε αυτή τη ιεραρχία. Ένα σύμβολο κράτησης διαφάνειας συνήθως επιστρέφει το σύμβολο κράτησης διάταξής του· ένα σύμβολο κράτησης διάταξης μπορεί να επιστρέψει το σύμβολο κράτησης της κύριας. Η μέθοδος επιστρέφει `null` όταν το σχήμα δεν έχει βασικό σύμβολο κράτησης.

Το παρακάτω παράδειγμα παραθέτει τα σύμβολα κράτησης στην πρώτη διαφάνεια και αναφέρει τα βασικά τους σύμβολα κράτησης:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

Η επεξεργασία ενός συμβόλου κράτησης σε μια κανονική διαφάνεια δημιουργεί ή αλλάζει μια τοπική παράκαμψη για εκείνη τη διαφάνεια. Η επεξεργασία της σχετικής διάταξης ή κύριας διαφάνειας μπορεί να επηρεάσει όλες τις διαφάνειες που ακόμα κληρονομούν αυτή τη ρύθμιση. Ένα τοπικό συνηθισμένο σχήμα δεν έχει βασικό σύμβολο κράτησης και δεν αρχίζει να κληρονομεί μόνο επειδή καταλαμβάνει τις ίδιες συντεταγμένες.

## **Αφαίρεση Κατάστασης Συμβόλου Κράτησης**

Κατά την προσαρμογή ενός προτύπου, χρησιμοποιήστε το [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/) για να διατηρήσετε ένα υπάρχον αντικείμενο ως συνηθισμένο σχήμα. Η ιδιότητα [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) του γίνεται `null`, αλλά το σχήμα παραμένει στη συλλογή της διαφάνειας. Αντίθετα, το [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) διαγράφει το σχήμα από αυτή τη συλλογή.

Το παρακάτω παράδειγμα απαιτεί το `template.pptx` με τουλάχιστον μία διαφάνεια και ένα μη κενό σύμβολο κράτησης κειμένου στην πρώτη διαφάνεια. Χρησιμοποιήστε ένα σύμβολο κράτησης με μορφοποίηση που κληρονομείται από τη διάταξή του ή την κύρια διαφάνεια για να δείτε το αποτέλεσμα της αφαίρεσης αυτής της σχέσης. Το παράδειγμα ελέγχει ότι το ίδιο σχήμα παραμένει, καλεί ξανά τη μέθοδο στο πλέον συνηθισμένο σχήμα και αποθηκεύει το αποτέλεσμα.

{{% alert color="warning" title="Warning" %}}
Η αφαίρεση της κατάστασης συμβόλου κράτησης δεν διατηρεί αυτόματα τις κληρονομικές ρυθμίσεις εμφάνισης. Το παρακάτω παράδειγμα αφήνει σκόπιμα αυτές τις ρυθμίσεις αμετάβλητες, έτσι το αποτέλεσμα ενδέχεται να φαίνεται διαφορετικό. Ένα σχήμα του οποίου η θέση και το μέγεθος κληρονομούνται πλήρως μπορεί να έχει μηδενικές συντεταγμένες και διαστάσεις μετά την κλήση και να γίνει αόρατο παρόλο που παραμένει στη συλλογή.
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // Η κλήση της μεθόδου σε ένα συνηθισμένο σχήμα δεν έχει αποτέλεσμα.
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

Για ένα αντίστοιχο σύμβολο κράτησης, όλοι οι τρεις έλεγχοι εμφανίζουν `True`. Το κείμενο παραμένει, αλλά η κληρονομική θέση, το μέγεθος, η περιστροφή, η γραμματοσειρά, η στοίχιση παραγράφου, τα περιθώρια του πλαισίου κειμένου, η κάθετη αγκύρωση, η γεμιστική και η γραμμή μπορούν να αλλάξουν όταν η σχέση του συμβόλου κράτησης αφαιρεθεί. Για παράδειγμα, η κληρονομική μορφοποίηση τίτλου μπορεί να επιστρέψει στην κανονική μορφοποίηση κειμένου. Δείτε το [Slide Layout](/slides/el/net/slide-layout/) για περισσότερα σχετικά με τις διατάξεις.

Για να διατηρήσετε την προτιμώμενη εμφάνιση, καταγράψτε τη λύση θέση, μέγεθος και περιστροφή πριν την κλήση και αντιγράψτε τις απαιτούμενες τιμές αποτελεσματικής μορφοποίησης σε ξεχωριστές μεταβλητές. Ανακτήστε αυτές τις τιμές μέσω του [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), του [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/), του [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/), του [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/), και του [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/). Μην βασίζεστε στην διατήρηση μόνο των αντικειμένων αποτελεσματικής μορφοποίησης, επειδή οι τιμές μορφοποίησης κειμένου τους μπορούν να αλλάξουν μετά την αφαίρεση της σχέσης. Εφαρμόστε ρητά τις καταγεγραμμένες τιμές στο συνηθισμένο σχήμα μετά, συμπεριλαμβανομένων της οικογένειας γραμματοσειράς, μεγέθους, στυλ, χρώματος, ρυθμίσεων παραγράφου, ρυθμίσεων πλαισίου κειμένου, γεμίσματος και γραμμής που χρησιμοποιεί το πρότυπό σας.

Η κληρονομική γεωμετρία σχήματος μπορεί επίσης να χρειάζεται να οριστεί ρητά μέσω του [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/). Για ένα ορθογώνιο σύμβολο κράτησης κειμένου, αυτό σημαίνει την ανάθεση του [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/); η αποκατάσταση μόνο του γεμίσματος και της γραμμής ενδέχεται να μην αποκαταστήσει το ορατό ορθογώνιο. Τα πρότυπα με πρόσθετα εφέ ή πιο σύνθετη μορφοποίηση απαιτούν επίσης τη διαχείριση αυτών των ρυθμίσεων.

## **Αλλαγή Κειμένου σε Σύμβολο Κράτησης**

Τα σύμβολα κράτησης τίτλου, κεντραρισμένου τίτλου, υπότιτλου, κυρίου κειμένου και κειμένου συνήθως υποστηρίζουν κείμενο. Ελέγξτε για το [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) πριν χρησιμοποιήσετε την ιδιότητά του [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/).

Αυτό το παράδειγμα ενημερώνει το πρώτο σύμβολο κράτησης τίτλου στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

Αυτό το μοτίβο αποφεύγει την μετατροπή (casting) συμβόλων κράτησης εικόνας, διαγράμματος, πίνακα ή πολυμέσων σε [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Επίσης εντοπίζει το σύμβολο κράτησης με βάση τον σκοπό του αντί να βασίζεται σε ευαίσθητο δείκτη σχήματος.

## **Ορισμός Κειμένου Προτροπής σε Διάταξη**

Το κείμενο προτροπής είναι η οδηγία κατά το σχεδιασμό που εμφανίζεται σε ένα κενό σύμβολο κράτησης, όπως *Click to add title*. Ορίστε προσαρμοσμένο κείμενο προτροπής στο σύμβολο κράτησης της διάταξης αντί να προσπαθήσετε να το προσεγγίσετε μέσω της συλλογής σ shapes μιας κανονικής διαφάνειας. Πρόσβαση στη διάταξη μέσω του [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) και επανάληψη πάνω στα [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/).

Το παρακάτω παράδειγμα αλλάζει τις προτροπές τίτλου και υποτίτλου στη διάταξη που χρησιμοποιεί η πρώτη διαφάνεια:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

Το κείμενο προτροπής δεν είναι κανονικό περιεχόμενο διαφάνειας. Προορίζεται για κενά σύμβολα κράτησης σε εφαρμογές επεξεργασίας όπως το PowerPoint. Μόλις ένας χρήστης ή πρόγραμμα παρέχει πραγματικό περιεχόμενο, η προτροπή δεν εμφανίζεται πλέον. Η αλλαγή μιας προτροπής επίσης δεν αντικαθιστά το υπάρχον κείμενο στις διαφάνειες που χρησιμοποιούν τη διάταξη.

## **Ενημέρωση Συμβόλου Κράτησης Εικόνας**

Υπάρχουν δύο περιπτώσεις προς διαχείριση:

- Εάν το σύμβολο κράτησης εικόνας είναι ήδη γεμάτο και αντιπροσωπεύεται από ένα [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), αντικαταστήστε την εικόνα μέσω του [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) και του [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/).
- Εάν εξακολουθεί να είναι κενό σύμβολο κράτησης, προσθέστε ένα πλαίσιο εικόνας στις συντεταγμένες του συμβόλου κράτησης με το [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) και αφαιρέστε το κενό σύμβολο κράτησης.

Το επόμενο παράδειγμα υποστηρίζει και τις δύο περιπτώσεις και αποθηκεύει την παρουσίαση:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

Η αντικατάσταση που δημιουργείται για ένα κενό σύμβολο κράτησης είναι ένα τοπικό πλαίσιο εικόνας, όχι ένα νέο σύμβολο κράτησης, επειδή το [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) είναι μόνο για ανάγνωση. Διατηρεί τη δεσμευμένη θέση αλλά δεν κληρονομεί πλέον τη συμπεριφορά ειδική για σύμβολα κράτησης. Εάν η διατήρηση της σχέσης του συμβόλου κράτησης είναι ουσιώδης, προετοιμάστε και γεμίστε το σύμβολο κράτησης στο PowerPoint πρώτα, στη συνέχεια ενημερώστε το προκύπτον [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) με το Aspose.Slides.

Για διαφάνεια εικόνας, περικοπή και άλλα εφέ ειδικά για εικόνες, δείτε το [Manage Picture Frames](/slides/el/net/picture-frame/). Οι λειτουργίες αυτές ανήκουν στο πλαίσιο εικόνας ή στη γεμιστική εικόνας, όχι στα μεταδεδομένα του συμβόλου κράτησης.

## **Εργασία με Σύμβολα Κράτησης Διαγράμματος και Περιεχομένου**

Ένα γεμάτο σύμβολο κράτησης διαγράμματος μπορεί να αντιπροσωπεύεται από ένα [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/). Αυτό το παράδειγμα βρίσκει ένα τέτοιο διάγραμμα τόσο με βάση τον τύπο του συμβόλου κράτησης όσο και τη διεπαφή χρόνου εκτέλεσης, αλλάζει τον τίτλο του και αποθηκεύει το αρχείο:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

Ένα γενικό σύμβολο κράτησης περιεχομένου συνήθως έχει [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/). Στο PowerPoint λειτουργεί ως εκκινητής για πολλούς τύπους περιεχομένου, συμπεριλαμβανομένων διαγραμμάτων, πινάκων, διαγραμμάτων, εικόνων και πολυμέσων. Αφού γεμίσει, εξετάστε τη πραγματική διεπαφή σχήματος για να μάθετε τι περιέχει. Εξειδικευμένες διατάξεις μπορούν επίσης να εκθέτουν [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), ή [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/).

Το Aspose.Slides δεν μετατρέπει ένα κενό σύμβολο κράτησης [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) σε ένα [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) απλώς αλλάζοντας το [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/); ο τύπος είναι μόνο για ανάγνωση. Για να γεμίσετε ένα κενό διάγραμμα ή περιοχή περιεχομένου προγραμματιστικά, προσθέστε το απαιτούμενο αντικείμενο στις συντεταγμένες του συμβόλου κράτησης και, στη συνέχεια, αφαιρέστε το κενό σύμβολο κράτησης. Το παρακάτω παράδειγμα το κάνει για ένα διάγραμμα:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

Το προστιθέμενο διάγραμμα είναι ένα κανονικό τοπικό διάγραμμα. Καταλαμβάνει την περιοχή του συμβόλου κράτησης αλλά δεν κληρονομεί από το σύμβολο κράτησης της διάταξης. Χρησιμοποιήστε τα αφιερωμένα [chart management articles](/slides/el/net/powerpoint-charts/) όταν χρειάζεται να αντικαταστήσετε τις κατηγορίες, τις σειρές ή τα δεδομένα του βιβλίου εργασίας του.

## **Πλήρες Παράδειγμα: Ενημέρωση Κειμένου ή Περιεχομένου Εικόνας**

Το παρακάτω ολοκληρωμένο παράδειγμα ανοίγει ένα πρότυπο, αναζητά στην πρώτη διαφάνεια είτε ένα σύμβολο κράτησης τίτλου είτε εικόνας, ελέγχει τους τύπους του συμβόλου κράτησης και του σχήματος, ενημερώνει το κατάλληλο περιεχόμενο και αποθηκεύει το αποτέλεσμα. Το παράδειγμα σκόπιμα αποφεύγει την υπόθεση ενός δείκτη σχήματος ή τη μετατροπή κάθε συμβόλου κράτησης στην ίδια διεπαφή.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **Συχνές Ερωτήσεις**

**Τι είναι ένα βασικό σύμβολο κράτησης;**

Ένα βασικό σύμβολο κράτησης είναι το αντίστοιχο σχήμα στη διάταξη ή στην κύρια διαφάνεια από το οποίο κληρονομεί ένα άλλο σύμβολο κράτησης. Χρησιμοποιήστε το [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) για να το ανακτήσετε. Ένα συνηθισμένο τοπικό σχήμα επιστρέφει `null` επειδή δεν αποτελεί μέρος της ιεραρχίας συμβόλων κράτησης.

**Μπορώ να αλλάξω όλους τους τίτλους των διαφανειών επεξεργάζοντας ένα σύμβολο κράτησης διάταξης;**

Μπορείτε να αλλάξετε την κληρονομική μορφοποίηση ή το κείμενο προτροπής μέσω μιας διάταξης, αλλά το υπάρχον περιεχόμενο τίτλου αποθηκεύεται στις κανονικές διαφάνειες. Για να αντικαταστήσετε το πραγματικό κείμενο τίτλου σε ολόκληρη την παρουσίαση, επαναλάβετε τις διαφάνειες και ενημερώστε κάθε σύμβολο κράτησης τίτλου.

**Πώς διαχειρίζομαι σύμβολα κράτησης ημερομηνίας, αριθμού διαφάνειας, κεφαλίδας και υποσέλιδας;**

Χρησιμοποιήστε τους διαχειριστές κεφαλίδας και υποσέλιδας στο κατάλληλο επίπεδο διαφάνειας, διάταξης, κύριας, σημειώσεων ή φυλλαδίου. Δείτε το [Manage Presentation Header and Footer](/slides/el/net/presentation-header-and-footer/) για πλήρη παραδείγματα.