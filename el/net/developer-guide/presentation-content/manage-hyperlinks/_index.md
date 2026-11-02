---
title: Διαχείριση Υπερσυνδέσμων Παρουσίασης σε .NET
linktitle: Διαχείριση Υπερσυνδέσμων
type: docs
weight: 20
url: /el/net/manage-hyperlinks/
keywords:
- προσθήκη URL
- προσθήκη υπερσυνδέσμου
- δημιουργία υπερσυνδέσμου
- μορφοποίηση υπερσυνδέσμου
- αφαίρεση υπερσυνδέσμου
- ενημέρωση υπερσυνδέσμου
- υπερσύνδεσμος κειμένου
- υπερσύνδεσμος διαφάνειας
- υπερσύνδεσμος σχήματος
- υπερσύνδεσμος εικόνας
- υπερσύνδεσμος βίντεο
- μεταβλητός υπερσύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Προσθήκη, μορφοποίηση, ενημέρωση και αφαίρεση υπερσυνδέσμων σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για .NET, χρησιμοποιώντας παραδείγματα C#."
---
## **Εισαγωγή**

Ένας υπερσύνδεσμος συνδέει το περιεχόμενο της παρουσίασης με μια ιστοσελίδα ή μια θέση εντός της παρουσίασης. Στο PowerPoint, οι υπερσύνδεσμοι συχνά εξυπηρετούν δύο σκοπούς:

* Άνοιγμα ιστοσελίδας από κείμενο, σχήμα ή πλαίσιο πολυμέσων.
* Πλοήγηση σε άλλη διαφάνεια, για παράδειγμα, από έναν πίνακα περιεχομένων.

Το Aspose.Slides for .NET σας επιτρέπει να προσθέσετε αυτούς τους συνδέσμους, να ελέγξετε την εμφάνιση και τον ήχο τους, να ενημερώσετε τις ιδιότητές τους και να τους αφαιρέσετε. Τα παραδείγματα παρακάτω δείχνουν πώς να εργαστείτε με υπερσυνδέσμους σε μεμονωμένα στοιχεία και πώς να έχετε πρόσβαση στους υπερσυνδέσμους σε επίπεδο παρουσίασης, διαφάνειας ή πλαισίου κειμένου.

{{% alert color="info" title="Note" %}}
Μπορείτε επίσης να επεξεργαστείτε παρουσιάσεις με το [δωρεάν διαδικτυακό επεξεργαστή Aspose PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Προσθήκη URL υπερσυνδέσμων**

Μπορείτε να αναθέσετε ένα URL ιστοσελίδας σε κείμενο, σχήμα ή πλαίσιο πολυμέσων. Το στοιχείο στο οποίο αναθέτετε τον υπερσύνδεσμο καθορίζει την περιοχή που είναι κλικαρίσιμη: ένα τμήμα κειμένου συνδέει το επιλεγμένο κείμενο, ενώ ένα σχήμα ή πλαίσιο συνδέει το αντικείμενο της διαφάνειας.

Για παρουσιάσεις που περιέχουν σχετικούς υπερσυνδέσμους, δείτε το [Διαχειριστείτε τη Βάση Υπερσυνδέσμου](/slides/el/net/presentation-properties/#manage-the-hyperlink-base) για ανάγνωση, αλλαγή ή εκκαθάριση της βάσης εγγράφου.

### **Προσθήκη URL υπερσυνδέσμων σε Κείμενο**

Για να συνδέσετε κείμενο με μια ιστοσελίδα, αναθέστε ένα [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) στην ιδιότητα [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) του τμήματος κειμένου, όπως φαίνεται παρακάτω. Μόνο αυτό το τμήμα κειμένου γίνεται κλικαρίσιμο.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **Προσθήκη URL υπερσυνδέσμων σε Σχήματα και Πλαισία Πολυμέσων**

Για να κάνετε ένα σχήμα ή πλαίσιο κλικαρίσιμο, ορίστε την ιδιότητα [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) του. Ο υπερσύνδεσμος ανήκει στο ίδιο το αντικείμενο και όχι σε τμήμα κειμένου μέσα σε αυτό.

Η ίδια προσέγγιση ισχύει για πλαίσια εικόνας, ήχου και βίντεο: αναθέστε τον υπερσύνδεσμο στο πλαίσιο και ορίστε το [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) του συνδέσμου, εάν χρειάζεται.

Το παρακάτω παράδειγμα κάνει ένα ορθογώνιο κλικαρίσιμο:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Χρησιμοποιήστε Υπερσυνδέσμους για Δημιουργία Πίνακα Περιεχομένων**

Οι εσωτερικοί υπερσύνδεσμοι επιτρέπουν στους αναγνώστες να πηδούν από έναν πίνακα περιεχομένων σε μια συγκεκριμένη διαφάνεια. Το παρακάτω παράδειγμα χρησιμοποιεί τη μέθοδο [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) για να συνδέσει το κείμενο “Page 2” στην πρώτη διαφάνεια με τη δεύτερη διαφάνεια.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **Μορφοποίηση Υπερσυνδέσμων**

### **Χρώμα**

Η ιδιότητα [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) του [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) καθορίζει εάν ένας υπερσύνδεσμος χρησιμοποιεί το χρώμα υπερσυνδέσμου της παρουσίασης ή τη μορφοποίηση του τμήματος κειμένου. Για να εφαρμόσετε ένα προσαρμοσμένο χρώμα κειμένου, επιλέξτε το [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) και ορίστε το χρώμα γεμίσματος του τμήματος. Αυτή η δυνατότητα εισήχθη στο PowerPoint 2019· οι παλαιότερες εκδόσεις δεν εφαρμόζουν αυτή τη ρύθμιση.

Το παρακάτω παράδειγμα προσθέτει δύο υπερσυνδέσμους κειμένου στην ίδια διαφάνεια. Ο πρώτος χρησιμοποιεί κόκκινο γεμίσμα κειμένου, ενώ ο δεύτερος διατηρεί το προεπιλεγμένο χρώμα υπερσυνδέσμου.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```

### **Ήχος**

Ένας υπερσύνδεσμος μπορεί να αναπαράγει ήχο όταν ενεργοποιείται ή να σταματήσει ήχο που ήδη παίζει. Χρησιμοποιήστε τις ακόλουθες ιδιότητες για να ρυθμίσετε αυτές τις συμπεριφορές:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) καθορίζει το ήχο που συσχετίζεται με τον υπερσύνδεσμο.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) ελέγχει εάν η ενεργοποίηση του υπερσυνδέσμου σταματά τον προηγούμενο ήχο.

#### **Προσθήκη Ήχου σε Υπερσύνδεσμο**

Το παρακάτω παράδειγμα φορτώνει το `sampleaudio.wav` και το συσχετίζει με ένα κουμπί στην πρώτη διαφάνεια. Κάνοντας κλικ στο κουμπί αναπαράγει τον ήχο και πηγαίνει στην επόμενη διαφάνεια. Ένα δεύτερο σχήμα σε αυτή τη διαφάνεια σταματά το προηγούμενο ήχο όταν κλικάρεται, χωρίς να εκτελεί ενέργεια πλοήγησης.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **Ανάκτηση Ήχου από Υπερσύνδεσμο**

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε παραπάνω και διαβάζει τον ήχο υπερσυνδέσμου του πρώτου σχήματος στην μνήμη μέσω των [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) και [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **Ρυθμίσεις Tooltip και Αλληλεπίδρασης**

Μπορείτε να ενημερώσετε τις παρακάτω ιδιότητες του [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) μετά την ανάθεση ενός υπερσυνδέσμου σε κείμενο ή σχήμα:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) ορίζει το κείμενο που μπορεί να εμφανίσει ο θεατής ως υπόδειξη για το σύνδεσμο.
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) καθορίζει το πλαίσιο-στόχο μέσα σε ένα γονικό σύνολο πλαισίων HTML, όταν είναι εφαρμόσιμο.
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) ελέγχει εάν η ενεργοποίηση του συνδέσμου προσθέτει τον προορισμό του στη λίστα των προβληθέντων υπερσυνδέσμων.
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) ελέγχει εάν ο υπερσύνδεσμος επισημαίνεται όταν κλικάρεται.

## **Αφαίρεση Υπερσυνδέσμων από Παρουσιάσεις**

Χρησιμοποιήστε το [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) για να συλλέξετε τα containers των υπερσυνδέσμων, συμπεριλαμβανομένων των συνδέσμων τμημάτων κειμένου, πριν τα αλλάξετε. Το παρακάτω παράδειγμα αφαιρεί και τους δύο τύπους ενεργοποίησης από την πρώτη διαφάνεια. Για να αφαιρέσετε μόνο έναν τύπο, καλέστε μόνο το [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) ή το [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); η αφαίρεση μιας ενέργειας κλικ δεν αφαιρεί το αντίστοιχο mouse‑over.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

Για αδιαπόρητη αφαίρεση, το [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) αφαιρεί και τους δύο τύπους ενεργοποίησης στο επιλεγμένο εύρος με μία κλήση. Για επιλεκτικό καθαρισμό και κάλυψη των master, layout και σημειώσεων, δείτε το [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Δημιουργία Πλήρους Καταλόγου Υπερσυνδέσμων**

Πριν διανείμετε μια παρουσίαση, καταγράψτε τις διαδραστικές της ενέργειες καθώς και τους συνδέσμους ιστού. Το [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) επιστρέφει αντικείμενα [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/), όχι μια επίπεδη λίστα αλφαριθμητικών URL. Εξετάστε τόσο τα [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) όσο και τα [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) σε κάθε container. Είναι ανεξάρτητα: το ίδιο container μπορεί να εκθέτει και τις δύο ενέργειες, έτσι ένας πλήρης αναφορά χρειάζεται έως δύο γραμμές ανά container.

Η σάρωση μόνο των υπερσυνδέσμων σε επίπεδο σχήματος μπορεί να χάσει συνδέσμους που είναι συνδεδεμένοι με τμήματα κειμένου. Ανακτήστε αντί αυτού το κατάλληλο εύρος και διατηρήστε τα containers που επιστρέφονται ώστε να μπορείτε αργότερα να ενημερώσετε ή να αφαιρέσετε τις ενέργειές τους.

### **Αναζήτηση σε Εύρη Παρουσίασης, Διαφάνειας και Πλαισίου Κειμένου**

Η διεπαφή [IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) είναι διαθέσιμη μέσω των [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/) και [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/). Κάθε εύρος υποστηρίζει τις ίδιες ερωτήσεις:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) επιστρέφει containers με ενέργεια κλικ.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) επιστρέφει containers με ενέργεια mouse‑over.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) επιστρέφει containers με μία ή και τις δύο ενέργειες.

Το παρακάτω παράδειγμα δημιουργεί το `hyperlink-audit-input.pptx` με έναν εξωτερικό σύνδεσμο κλικ, έναν σύνδεσμο αρχείου mouse‑over, εσωτερική πλοήγηση διαφάνειας, έναν σύνδεσμο κειμένου mouse‑over και μια ενέργεια μακροεντολής. Δεν εκτελεί καμία από αυτές τις ενέργειες. Οι ίδιες τρεις ερωτήσεις λειτουργούν σε κάθε εύρος· οι μετρήσεις περιγράφουν containers, όχι το σύνολο των ενεργειών. Το εύρος πλαισίου κειμένου εξαιρεί τους δικούς του συνδέσμους του περιβάλλοντος σχήματος.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

Για αυτό το παράδειγμα, οι ερωτήσεις παρουσίασης και διαφάνειας αναφέρουν τρία containers κλικ, δύο containers mouse‑over και τρία containers με μία από τις δύο ενέργειες. Η ερώτηση πλαισίου κειμένου αναφέρει ένα container σε κάθε κατηγορία.

### **Κατηγοριοποίηση Ενεργειών και Προορισμών**

Χρησιμοποιήστε το [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) για να ερμηνεύσετε μια ενέργεια πριν ερμηνεύσετε τον προορισμό της. Οι τιμές του [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) καλύπτουν περισσότερα από την πλοήγηση στο web:

| Τιμές | Σημασία για έλεγχο |
| --- | --- |
| `Hyperlink` | Εξωτερικός υπερσύνδεσμος· ελέγξτε το URL και το σχήμα του. |
| `JumpSpecificSlide` | Εσωτερική πλοήγηση σε συγκεκριμένη διαφάνεια. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ενσωματωμένη πλοήγηση παρουσίασης, επιλύεται στο πλαίσιο παρουσίασης. |
| `JumpEndShow`, `StartCustomSlideShow` | Τερματισμός της τρέχουσας παρουσίασης ή εκκίνηση προσαρμοσμένης παρουσίασης. |
| `StartMacro` | Εκτέλεση μακροεντολής. |
| `StartProgram` | Έναρξη προγράμματος. |
| `OpenFile`, `OpenPresentation` | Άνοιγμα αρχείου ή άλλης παρουσίασης· ελέγξτε ξεχωριστά από τα web URLs. |
| `StartStopMedia` | Έναρξη ή παύση αναπαραγωγής πολυμέσων. |
| `NoAction`, `Unknown` | Καμία ενέργεια πλοήγησης, ή άγνωστη ενέργεια που απαιτεί έλεγχο. |

Διαβάστε εξωτερικούς προορισμούς από το [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) και συγκεκριμένους εσωτερικούς προορισμούς από το [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/). Οι εσωτερικές ενέργειες και οι ενσωματωμένες εντολές μπορεί να μην έχουν εξωτερικό URL· ένα κενό URL δεν σημαίνει ότι το container δεν έχει ενέργεια. Διατηρήστε το [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) όταν διαφέρει από το κανονικοποιημένο URL, και συμπεριλάβετε το [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) όταν είναι διαθέσιμο.

### **Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσμων**

Το παρακάτω παράδειγμα .NET 6+ διαβάζει μια υπάρχουσα παρουσίαση (χρησιμοποιήστε το αρχείο που δημιουργήθηκε παραπάνω), γράφει το `hyperlink-audit.json`, εφαρμόζει πολιτική, αποθηκεύει το `hyperlink-sanitized.pptx` και το ανοίγει ξανά για να ελέγξει και πάλι και τους δύο τύπους ενεργοποίησης. Συλλέγει containers πριν τα αλλάξει και χρησιμοποιεί ισότητα αναφοράς για να αποφύγει την επεξεργασία του ίδιου container δύο φορές. Οι ερωτήσεις παρουσίασης καλύπτουν τις κανονικές διαφάνειες· για ένα κατάλογο σε όλο το πακέτο, ερωτά ρητά επίσης τα master, layout, σημειώσεις και τα master σημειώσεων/χειροδειγμάτων όταν υπάρχουν.

Η αναφορά καταγράφει έναν δείκτη διαφάνειας που ξεκινά από το 1 και το [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) όπου είναι διαθέσιμο. Το [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) παρέχει τη διαφάνεια ιδιοκτήτη για τα υποστηριζόμενα containers. Τα master, layout και σημειώσεις δεν έχουν κανονικό δείκτη διαφάνειας και προσδιορίζονται από το πεδίο τους. Τα containers σχήματος και τα containers μορφοποίησης τμημάτων κειμένου επισημαίνονται ξεχωριστά· άλλοι τύποι containers διατηρούν το όνομα τύπου χρόνου εκτέλεσης. Κάθε container λαμβάνει ένα τοπικό αναγνωριστικό στην αναφορά ώστε οι δύο του ενέργειες να μπορούν να συσχετιστούν.

Αυτή η σκόπιμα περιοριστική πολιτική εφαρμογής επιτρέπει μόνο απόλυτα HTTPS URLs και έγκυρους εσωτερικούς προορισμούς διαφάνειας. Απορρίπτει μακροεντολές, προγράμματα, ενέργειες αρχείων, άλλες ενέργειες παρουσίασης, άγνωστες ενέργειες και άλλα σχήματα URL. Αυτές οι απορρίψεις είναι αποφάσεις πολιτικής, όχι μια αξιολόγηση ασφαλείας του Aspose.Slides. Το HTTPS μόνο δεν εγγυάται εμπιστοσύνη: προσθέστε λιστές επιτρεπόμενων κεντρικών υπολογιστών και άλλους ελέγχους για την εφαρμογή σας. Ελέγχονται τόσο τα αρχικά όσο και τα κανονικοποιημένα εξωτερικά URLs. Το παράδειγμα ελέγχει μεταδεδομένα χωρίς να ακολουθεί συνδέσμους ή να εκτελεί ενέργειες.

Για αποκατάσταση, το [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) του container υποστηρίζει τις μεθόδους [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) και [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Εδώ, οι απαγορευμένοι εξωτερικοί σύνδεσμοι κλικ αντικαθίστανται με μια σταθερή σελίδα προορισμού HTTPS· άλλοι απαγορευμένοι κλικ και απαγορευμένες ενέργειες mouse‑over αφαιρούνται ανεξάρτητα. Ορίστε το `replaceExternalClicks` σε `false` για να αφαιρέσετε όλες τις παραβάσεις πολιτικής. Επιλέξτε μια σελίδα αντικατάστασης που ανήκει στην εφαρμογή προ της ανάπτυξης.

Η σημαία εξαγωγής της αναφοράς χρησιμοποιεί μια επιφυλακτική πολιτική ελέγχου PDF: σημαδέψτε ενέργειες mouse‑over και οτιδήποτε εκτός από εξωτερικό σύνδεσμο ή συγκεκριμένο άλμα διαφάνειας ως πιθανώς μη υποστηριζόμενο. Είναι υπόδειξη ελέγχου, όχι δοκιμή ικανότητας ή εγγύηση ότι οι μη σημειωμένοι σύνδεσμοι θα διατηρηθούν κατά την εξαγωγή. Οι υποστηριζόμενες εξαγωγές σε [PDF](/slides/el/net/convert-powerpoint-to-pdf/) και [HTML](/slides/el/net/convert-powerpoint-to-html/) μπορεί να διατηρήσουν υπερσυνδέσμους, ανάλογα με την ενέργεια, τις επιλογές εξαγωγής και τον προβολέα. Τα raster [images](/slides/el/net/convert-powerpoint-to-png/) και [video](/slides/el/net/convert-powerpoint-to-video/) δεν μπορούν να διατηρήσουν διαδραστικούς υπερσυνδέσμους· σημαδέψτε κάθε ενέργεια όταν ελέγχετε για αυτές τις εξόδους.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

Με το παραπάνω εισαγόμενο αρχείο, η αναφορά περιέχει πέντε γραμμές ενεργειών. Ο σύνδεσμος αρχείου mouse‑over και το κλικ μακροεντολής αφαιρέθηκαν, ενώ οι σύνδεσμοι HTTPS και η εσωτερική πλοήγηση διαφάνειας παραμένουν. Η επαλήθευση εκτυπώνει μηδέν απαγορευμένες ενέργειες. Ένα εισαγόμενο αρχείο που περιέχει απαγορευμένο εξωτερικό URL κλικ επίσης εκτελεί τον κλάδο αντικατάστασης. Ένα container με επιτρεπόμενο κλικ και απαγορευμένο mouse‑over διατηρεί τη δράση κλικ.

Αυτός ο επιλεκτικός καθαρισμός διαφέρει από το [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), το οποίο αφαιρεί και τους δύο τύπους ενεργοποίησης σε όλο το επιλεγμένο εύρος ανεξάρτητα από την πολιτική. Η επαλήθευση εδώ ελέγχει μόνο τις ενέργειες υπερσυνδέσμου· δεν αφαιρεί ενσωματωμένα έργα VBA, αντικείμενα OLE ή άλλο ενεργό περιεχόμενο, και δεν επικυρώνει ένα εξαγόμενο αρχείο PDF ή HTML.

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Πώς μπορώ να συνδέσω σε ενότητα ή την πρώτη της διαφάνεια;**

Οι ενότητες στο PowerPoint ομαδοποιούν διαφάνειες, αλλά ένας εσωτερικός υπερσύνδεσμος στοχεύει σε μία μεμονωμένη διαφάνεια. Για να δημιουργήσετε πλοήγηση σε ενότητα, συνδέστε στην πρώτη διαφάνεια της ενότητας.

**Μπορώ να προσθέσω υπερσύνδεσμο σε στοιχεία master διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία του master διαφάνειας και του layout υποστηρίζουν υπερσυνδέσμους. Οι σύνδεσμοι σε αυτά τα στοιχεία είναι διαθέσιμοι κατά την παρουσίαση στις διαφάνειες που χρησιμοποιούν το αντίστοιχο master ή layout.

**Θα διατηρηθούν οι υπερσύνδεσμοι όταν εξάγονται σε PDF, HTML, εικόνες ή βίντεο;**

Οι υποστηριζόμενες εξαγωγές σε PDF και HTML μπορεί να διατηρήσουν τους υπερσυνδέσμους· οι raster εικόνες και τα βίντεο δεν μπορούν. Δείτε τις considerations στην ενότητα [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).