---
title: Διαχείριση Placeholder Παρουσίασης σε .NET
linktitle: Διαχείριση Placeholder
type: docs
weight: 10
url: /el/net/manage-placeholder/
keywords:
- σύμβολο κράτησης
- σύμβολο κράτησης κειμένου
- σύμβολο κράτησης εικόνας
- σύμβολο κράτησης διαγράμματος
- σύμβολο κράτησης περιεχομένου
- κείμενο υποδείγματος
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να εξετάζετε και να επεξεργάζεστε placeholders κειμένου, εικόνας, διαγράμματος και περιεχομένου και να κατανοείτε την κληρονομικότητα των placeholders με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Ένα placeholder είναι ένα σχήμα που κρατά θέση για ένα συγκεκριμένο είδος περιεχομένου σε ένα πρότυπο παρουσίασης. Συχνά παραδείγματα είναι τα placeholders τίτλου, σώματος, εικόνας, διαγράμματος και γενικού σκοπού. Σε αντίθεση με ένα συνηθισμένο σχήμα, ένα placeholder μπορεί να κληρονομήσει τη θέση, το μέγεθος, τη μορφοποίηση και άλλες ρυθμίσεις από μια διαφάνεια διάταξης ή μια κύρια διαφάνεια.

Το Aspose.Slides εκθέτει τις πληροφορίες placeholder μέσω της ιδιότητας [IShape.Placeholder](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/placeholder/). Η ιδιότητα επιστρέφει ένα αντικείμενο [IPlaceholder](https://reference.aspose.com/slides/el/net/aspose.slides/iplaceholder/) ή `null` για ένα κανονικό σχήμα. Χρησιμοποιήστε το [IPlaceholder.Type](https://reference.aspose.com/slides/el/net/aspose.slides/iplaceholder/type/) για να καθορίσετε τι προορίζεται να περιέχει το placeholder.

Η διεπαφή του σχήματος εξακολουθεί να έχει σημασία αφού γνωρίζετε τον τύπο του placeholder:

- Ένα κενό κείμενο, εικόνα, διάγραμμα ή placeholder περιεχομένου συνήθως αντιπροσωπεύεται από ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/).
- Ένα γεμάτο placeholder εικόνας μπορεί να αντιπροσωπεύεται από ένα [IPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe/).
- Ένα γεμάτο placeholder διαγράμματος μπορεί να αντιπροσωπεύεται από ένα [IChart](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichart/).
- Ένα placeholder περιεχομένου μπορεί να περιέχει διάφορους τύπους περιεχομένου. Ελέγξτε τόσο το [IPlaceholder.Type](https://reference.aspose.com/slides/el/net/aspose.slides/iplaceholder/type/) όσο και τη διεπαφή σχήματος κατά χρόνο εκτέλεσης αντί να υποθέτετε ότι κάθε placeholder είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/el/net/aspose.slides/iplaceholder/type/) περιγράφει τον ρόλο του placeholder· δεν εγγυάται τον τύπο του σχήματος κατά χρόνο εκτέλεσης. Πάντα κάντε έλεγχο τύπου πριν αποκτήσετε πρόσβαση σε μέλη κειμένου, εικόνας, διαγράμματος, πίνακα ή πολυμέσων.
{{% /alert %}}

## **Κατανόηση της Κληρονομικότητας των Placeholder**

Τα placeholders σχηματίζουν ιεραρχία:

1. Μια κύρια διαφάνεια (master slide) ορίζει επαναχρησιμοποιήσιμα στυλ και, σε ορισμένες περιπτώσεις, placeholders επιπέδου master.
2. Μια διαφάνεια διάταξης (layout slide) ορίζει τη διάταξη που χρησιμοποιείται από μία ή περισσότερες κανονικές διαφάνειες και μπορεί να κληρονομήσει από την κύρια.
3. Μια κανονική διαφάνεια περιέχει τα placeholders για αυτή τη διαφάνεια και μπορεί να κληρονομήσει από τη διάταξη της.

Καλέστε το [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/getbaseplaceholder/) για να ανεβείτε ένα επίπεδο στην ιεραρχία. Ένα placeholder διαφάνειας συνήθως επιστρέφει το placeholder της διάταξής του· ένα placeholder διάταξης μπορεί να επιστρέψει το placeholder του master. Η μέθοδος επιστρέφει `null` όταν το σχήμα δεν έχει βασικό placeholder.

Το παρακάτω παράδειγμα καταγράφει τα placeholders στην πρώτη διαφάνεια και αναφέρει τα βασικά τους placeholders:

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

Η επεξεργασία ενός placeholder σε κανονική διαφάνεια δημιουργεί ή αλλάζει μια τοπική αντικατάσταση για εκείνη τη διαφάνεια. Η επεξεργασία της σχετικής διάταξης ή του master μπορεί να επηρεάσει όλες τις διαφάνειες που κληρονομούν ακόμη αυτήν τη ρύθμιση. Ένα τοπικό συνηθισμένο σχήμα δεν έχει βασικό placeholder και δεν αρχίζει να κληρονομεί μόνο επειδή καταλαμβάνει τις ίδιες συντεταγμένες.

## **Αλλαγή Κειμένου σε Placeholder**

Τα placeholders τίτλου, κεντραρισμένου τίτλου, υποτίτλου, σώματος και κειμένου συνήθως υποστηρίζουν κείμενο. Ελέγξτε για [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) πριν χρησιμοποιήσετε την ιδιότητα [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/textframe/).

Αυτό το παράδειγμα ενημερώνει το πρώτο placeholder τίτλου στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα:

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

Αυτό το μοτίβο αποφεύγει τη μετατροπή (casting) placeholders εικόνας, διαγράμματος, πίνακα ή πολυμέσων σε [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/). Επιπλέον, προσδιορίζει το placeholder με βάση τη λειτουργία του αντί να βασίζεται σε έναν ευπαθή δείκτη σχήματος.

## **Ορισμός Κειμένου Υποδείγματος σε Διάταξη**

Το κείμενο υποδείγματος είναι η οδηγία σχεδιασμού που εμφανίζεται σε ένα κενό placeholder, όπως *Click to add title*. Ορίστε προσαρμοσμένο κείμενο υποδείγματος στο placeholder της διάταξης αντί να προσπαθήσετε να το προσπελάσετε μέσω της συλλογής σ shapes μιας κανονικής διαφάνειας. Πρόσβαση στη διάταξη μέσω του [ISlide.LayoutSlide](https://reference.aspose.com/slides/el/net/aspose.slides/islide/layoutslide/) και επαναλάβετε τα [ILayoutSlide.Shapes](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseslide/shapes/).

Το παρακάτω παράδειγμα αλλάζει τα υποδείγματα τίτλου και υποτίτλου στη διάταξη που χρησιμοποιείται από την πρώτη διαφάνεια:

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

Το κείμενο υποδείγματος δεν είναι κανονικό περιεχόμενο διαφάνειας. Προορίζεται για κενά placeholders σε εφαρμογές επεξεργασίας όπως το PowerPoint. Μόλις ένας χρήστης ή ένα πρόγραμμα παρέχει πραγματικό περιεχόμενο, η υπόδειξη δεν εμφανίζεται πλέον. Η αλλαγή μιας υπόδειξης δεν αντικαθιστά επίσης το υπάρχον κείμενο στις διαφάνειες που χρησιμοποιούν τη διάταξη.

## **Ενημέρωση Placeholder Εικόνας**

Υπάρχουν δύο περιπτώσεις που πρέπει να χειριστούμε:

- Αν το placeholder εικόνας είναι ήδη γεμάτο και αντιπροσωπεύεται από ένα [IPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe/), αντικαταστήστε την εικόνα μέσω του [IPictureFillFormat.Picture](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/picture/) και του [ISlidesPicture.Image](https://reference.aspose.com/slides/el/net/aspose.slides/islidespicture/image/).
- Αν παραμένει κενό placeholder, προσθέστε ένα picture frame στις συντεταγμένες του placeholder με το [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addpictureframe/) και αφαιρέστε το κενό placeholder.

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

Η αντικατάσταση που δημιουργείται για ένα κενό placeholder είναι ένα τοπικό picture frame, όχι ένα νέο placeholder, επειδή το [IShape.Placeholder](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/placeholder/) είναι μόνο για ανάγνωση. Διατηρεί τη δεσμευμένη θέση αλλά δεν κληρονομεί πλέον τη συμπεριφορά του placeholder. Εάν είναι κρίσιμο να διατηρηθεί η σχέση placeholder, προετοιμάστε και γεμίστε το placeholder στο PowerPoint πρώτα, μετά ενημερώστε το προκύπτον [IPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe/) με το Aspose.Slides.

Για διαφάνεια εικόνας, περικοπή και άλλες ειδικές επιδράσεις εικόνας, δείτε το [Manage Picture Frames](/slides/el/net/picture-frame/). Αυτές οι λειτουργίες ανήκουν στο picture frame ή στο picture fill, όχι στα μεταδεδομένα του placeholder.

## **Εργασία με Placeholders Διαγραμμάτων και Περιεχομένου**

Ένα γεμάτο placeholder διαγράμματος μπορεί να αντιπροσωπεύεται από ένα [IChart](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichart/). Αυτό το παράδειγμα εντοπίζει τέτοιο διάγραμμα τόσο με βάση τον τύπο του placeholder όσο και με τη διεπαφή χρόνου εκτέλεσης, αλλάζει τον τίτλο του και αποθηκεύει το αρχείο:

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

Ένα γενικό placeholder περιεχομένου έχει συνήθως [PlaceholderType.Object](https://reference.aspose.com/slides/el/net/aspose.slides/placeholdertype/). Στο PowerPoint λειτουργεί ως εκκινητής για πολλαπλούς τύπους περιεχομένου, όπως διαγράμματα, πίνακες, διαγράμματα ροής, εικόνες και πολυμέσα. Αφού γεμίσει, ελέγξτε τη συγκεκριμένη διεπαφή σχήματος για να μάθετε τι περιέχει. Εξειδικευμένες διαδράσεις μπορούν επίσης να εκθέτουν [PlaceholderType.Chart](https://reference.aspose.com/slides/el/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/el/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/el/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/el/net/aspose.slides/placeholdertype/), ή [PlaceholderType.Diagram](https://reference.aspose.com/slides/el/net/aspose.slides/placeholdertype/).

Το Aspose.Slides δεν μετατρέπει ένα κενό placeholder [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) σε ένα [IChart](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichart/) απλώς αλλάζοντας το [IPlaceholder.Type](https://reference.aspose.com/slides/el/net/aspose.slides/iplaceholder/type/); ο τύπος είναι μόνο για ανάγνωση. Για να γεμίσετε προγραμματιστικά μια κενή περιοχή διαγράμματος ή περιεχομένου, προσθέστε το απαιτούμενο αντικείμενο στις συντεταγμένες του placeholder και, στη συνέχεια, αφαιρέστε το κενό placeholder. Το παρακάτω παράδειγμα το κάνει για ένα διάγραμμα:

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

Το προστιθέμενο διάγραμμα είναι ένα κοινό τοπικό διάγραμμα. Καταλαμβάνει την περιοχή του placeholder αλλά δεν κληρονομεί από το placeholder της διάταξης. Χρησιμοποιήστε τα ειδικά άρθρα διαχείρισης διαγραμμάτων ([chart management articles](/slides/el/net/powerpoint-charts/)) όταν χρειάζεται να αντικαταστήσετε τις κατηγορίες, τις σειρές ή τα δεδομένα του βιβλίου εργασίας.

## **Πλήρες Παράδειγμα: Ενημέρωση Κειμένου ή Περιεχομένου Εικόνας**

Το παρακάτω ολοκληρωμένο παράδειγμα ανοίγει ένα πρότυπο, ψάχνει την πρώτη διαφάνεια για είτε ένα placeholder τίτλου είτε εικόνας, ελέγχει τους τύπους του placeholder και του σχήματος, ενημερώνει το αντίστοιχο περιεχόμενο και αποθηκεύει το αποτέλεσμα. Το παράδειγμα αποφεύγει σκόπιμα την υπόθεση ενός δείκτη σχήματος ή τη μετατροπή κάθε placeholder στην ίδια διεπαφή.

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

**Τι είναι ένα βασικό placeholder;**

Ένα βασικό placeholder είναι το αντίστοιχο σχήμα στη διάταξη ή στον master από το οποίο κληρονομεί ένα άλλο placeholder. Χρησιμοποιήστε το [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/getbaseplaceholder/) για να το ανακτήσετε. Ένα κανονικό τοπικό σχήμα επιστρέφει `null` επειδή δεν αποτελεί μέρος της ιεραρχίας των placeholders.

**Μπορώ να αλλάξω όλους τους τίτλους διαφάνειας επεξεργάζοντας ένα placeholder διάταξης;**

Μπορείτε να αλλάξετε την κληρονομημένη μορφοποίηση ή το κείμενο υποδείγματος μέσω μιας διάταξης, αλλά το υπάρχον περιεχόμενο τίτλου αποθηκεύεται στις κανονικές διαφάνειες. Για να αντικαταστήσετε τον πραγματικό τίτλο σε ολόκληρη την παρουσίαση, επαναλάβετε τις διαφάνειες και ενημερώστε κάθε placeholder τίτλου.

**Πώς διαχειρίζομαι placeholders ημερομηνίας, αριθμού διαφάνειας, κεφαλίδας και υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές κεφαλίδας και υποσέλιδου στο κατάλληλο επίπεδο (διαφάνεια, διάταξη, master, σημειώσεις ή φυλλάδιο). Δείτε το [Manage Presentation Header and Footer](/slides/el/net/presentation-header-and-footer/) για πλήρη παραδείγματα.