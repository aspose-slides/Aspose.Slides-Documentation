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

Ένας υπερσύνδεσμος συνδέει το περιεχόμενο της παρουσίασης με μια ιστοσελίδα ή μια θέση εντός της παρουσίασης. Στο PowerPoint, οι υπερσύνδεσμοι συνήθως εξυπηρετούν δύο σκοπούς:

* Ανοίγει μια ιστοσελίδα από κείμενο, σχήμα ή πλαίσιο πολυμέσων.
* Μεταβαίνει σε άλλη διαφάνεια, για παράδειγμα, από έναν πίνακα περιεχομένων.

Aspose.Slides for .NET σας επιτρέπει να προσθέσετε αυτούς τους συνδέσμους, να ελέγξετε την εμφάνιση και τον ήχο τους, να ενημερώσετε τις ιδιότητές τους και να τους αφαιρέσετε. Τα παραδείγματα παρακάτω δείχνουν πώς να εργαστείτε με υπερσυνδέσμους σε μεμονωμένα στοιχεία και πώς να έχετε πρόσβαση σε υπερσυνδέσμους στο επίπεδο της παρουσίασης, της διαφάνειας ή του πλαισίου κειμένου.

{{% alert color="info" title="Σημείωση" %}}
Μπορείτε επίσης να επεξεργαστείτε τις παρουσιάσεις με τον [δωρεάν διαδικτυακό επεξεργαστή Aspose PowerPoint](https://products.aspose.app/slides/el/editor).
{{% /alert %}} 

## **Προσθήκη Υπερσυνδέσμων URL**

Μπορείτε να αναθέσετε ένα URL ιστοσελίδας σε κείμενο, σχήμα ή πλαίσιο πολυμέσων. Το στοιχείο στο οποίο αναθέτετε τον υπερσύνδεσμο καθορίζει την περιοχή που μπορεί να γίνει κλικ: ένα τμήμα κειμένου συνδέεται με το επιλεγμένο κείμενο, ενώ ένα σχήμα ή πλαίσιο συνδέεται με το αντικείμενο της διαφάνειας.

### **Προσθήκη Υπερσυνδέσμων URL σε Κείμενο**

Για να συνδέσετε κείμενο με μια ιστοσελίδα, αναθέστε έναν [Hyperlink](https://reference.aspose.com/slides/el/net/aspose.slides/hyperlink/) στην ιδιότητα [HyperlinkClick](https://reference.aspose.com/slides/el/net/aspose.slides/portionformat/hyperlinkclick/) του τμήματος κειμένου, όπως φαίνεται παρακάτω. Μόνο αυτό το τμήμα κειμένου γίνεται κλικ‑αποδιδόμενο.

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

### **Προσθήκη Υπερσυνδέσμων URL σε Σχήματα και Πλαίσια Πολυμέσων**

Για να κάνετε ένα σχήμα ή πλαίσιο κλικ‑αποδιδόμενο, ορίστε την ιδιότητα [HyperlinkClick](https://reference.aspose.com/slides/el/net/aspose.slides/shape/hyperlinkclick/). Ο υπερσύνδεσμος ανήκει στο ίδιο το αντικείμενο και όχι σε τμήμα κειμένου εντός αυτού.

Η ίδια προσέγγιση ισχύει για εικόνες, ήχο και βίντεο: αναθέστε τον υπερσύνδεσμο στο πλαίσιο και ορίστε το [Tooltip](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/tooltip/) εάν χρειάζεται.

Το ακόλουθο παράδειγμα κάνει ένα ορθογώνιο κλικ‑αποδιδόμενο:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Χρήση Υπερσυνδέσμων για Δημιουργία Πίνακα Περιεχομένων**

Οι εσωτερικοί υπερσύνδεσμοι επιτρέπουν στους αναγνώστες να μεταβούν από έναν πίνακα περιεχομένων σε συγκεκριμένη διαφάνεια. Το παρακάτω παράδειγμα χρησιμοποιεί τη [SetInternalHyperlinkClick](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) για να συνδέσει το κείμενο “Page 2” στην πρώτη διαφάνεια με τη δεύτερη διαφάνεια.

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

Η ιδιότητα [ColorSource](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/colorsource/) του [IHyperlink](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/) καθορίζει εάν ένας υπερσύνδεσμος χρησιμοποιεί το χρώμα υπερσυνδέσμου της παρουσίασης ή τη μορφοποίηση του τμήματος κειμένου. Για να εφαρμόσετε προσαρμοσμένο χρώμα κειμένου, επιλέξτε [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/hyperlinkcolorsource/) και ορίστε το χρώμα γεμίσματος του τμήματος. Η δυνατότητα αυτή εισήχθη στο PowerPoint 2019· παλαιότερες εκδόσεις δεν εφαρμόζουν αυτή τη ρύθμιση.

Το παρακάτω παράδειγμα προσθέτει δύο υπερσυνδέσμους κειμένου στην ίδια διαφάνεια. Ο πρώτος χρησιμοποιεί κόκκινο γέμισμα κειμένου, ενώ ο δεύτερος διατηρεί το προεπιλεγμένο χρώμα υπερσυνδέσμου.

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

Ένας υπερσύνδεσμος μπορεί να αναπαράγει ήχο όταν ενεργοποιείται ή να σταματήσει ήχο που ήδη παίζει. Χρησιμοποιήστε τις παρακάτω ιδιότητες για να ρυθμίσετε αυτή τη συμπεριφορά:

- [IHyperlink.Sound](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/sound/) καθορίζει τον ήχο που συνδέεται με τον υπερσύνδεσμο.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/stopsoundonclick/) ελέγχει αν η ενεργοποίηση του υπερσυνδέσμου σταματά τον προηγούμενο ήχο.

#### **Προσθήκη Ήχου σε Υπερσύνδεσμο**

Το παρακάτω παράδειγμα φορτώνει το `sampleaudio.wav` και το συνδέει με ένα κουμπί στην πρώτη διαφάνεια. Πατώντας το κουμπί αναπαράγεται ο ήχος και μεταβαίνει στην επόμενη διαφάνεια. Ένα δεύτερο σχήμα στην ίδια διαφάνεια σταματά τον προηγούμενο ήχο όταν γίνεται κλικ, χωρίς να εκτελεί άλλη ενέργεια πλοήγησης.

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

#### **Εξαγωγή Ήχου από Υπερσύνδεσμο**

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε παραπάνω και διαβάζει τον ήχο του πρώτου σχήματος στη μνήμη μέσω των [Sound](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/sound/) και [BinaryData](https://reference.aspose.com/slides/el/net/aspose.slides/iaudio/binarydata/).

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

Μπορείτε να ενημερώσετε τις παρακάτω ιδιότητες του [IHyperlink](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/) μετά την ανάθεση υπερσυνδέσμου σε κείμενο ή σχήμα:

- [Tooltip](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/tooltip/) ορίζει το κείμενο που μπορεί να εμφανίσει ο θεατής ως υπόδειξη για τον σύνδεσμο.
- [TargetFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/targetframe/) καθορίζει το πλαίσιο-στόχο μέσα σε ένα γονικό HTML frameset, εφόσον ισχύει.
- [History](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/history/) ελέγχει αν η ενεργοποίηση του συνδέσμου προσθέτει τον προορισμό του στη λίστα των προβλεπόμενων υπερσυνδέσμων.
- [HighlightClick](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/highlightclick/) ελέγχει αν ο υπερσύνδεσμος επισημαίνεται όταν γίνεται κλικ.

## **Αφαίρεση Υπερσυνδέσμων από Παρουσιάσεις**

Χρησιμοποιήστε τη [GetAnyHyperlinks](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) για να συλλέξετε τα containers υπερσυνδέσμων, συμπεριλαμβανομένων των συνδέσμων τμημάτων κειμένου, πριν τα αλλάξετε. Το παρακάτω παράδειγμα αφαιρεί και τους δύο τύπους ενεργοποίησης από την πρώτη διαφάνεια. Για να αφαιρέσετε μόνο έναν τύπο, καλέστε μόνο το [RemoveHyperlinkClick](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) ή το [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); η αφαίρεση μιας ενέργειας κλικ δεν αφαιρεί το αντίστοιχο mouse‑over.

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

Για αδιαπόσπαστη αφαίρεση, το [RemoveAllHyperlinks](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) αφαιρεί και τους δύο τύπους ενεργοποίησης στο επιλεγμένο περιβάλλον σε μία κλήση. Για επιλεκτικό καθαρισμό και κάλυψη των master, layout και σημειώσεων, δείτε την ενότητα [Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσμων](#report-sanitize-and-verify-hyperlinks).

## **Δημιουργία Πλήρους Απογραφής Υπερσυνδέσμων**

Πριν διανείμετε μια παρουσίαση, καταγράψτε τις διαδραστικές ενέργειές της καθώς και τους διαδικτυακούς της συνδέσμους. Η [GetAnyHyperlinks](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) επιστρέφει αντικείμενα [IHyperlinkContainer](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkcontainer/), όχι μια επίπεδη λίστα συμβολοσειρών URL. Εξετάστε τόσο το [HyperlinkClick](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) όσο και το [HyperlinkMouseOver](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) σε κάθε container. Είναι ανεξάρτητα: ο ίδιος container μπορεί να εκθέτει και τις δύο ενέργειες, έτσι μια πλήρης αναφορά απαιτεί έως δύο γραμμές ανά container.

Η σάρωση μόνο των υπερσυνδέσμων σε επίπεδο σχήματος μπορεί να παραλείψει συνδέσμους που είναι ενσωματωμένοι σε τμήματα κειμένου. Αναζητήστε το κατάλληλο scope αντί για αυτό και διατηρήστε τα containers που επιστρέφονται, ώστε να μπορείτε αργότερα να ενημερώσετε ή να αφαιρέσετε τις ενέργειές τους.

### **Αναζήτηση σε Σκοπίες Παρουσίασης, Διαφάνειας και Πλαισίου Κειμένου**

Η διεπαφή [IHyperlinkQueries](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkqueries/) είναι διαθέσιμη μέσω των [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseslide/hyperlinkqueries/) και [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/hyperlinkqueries/). Κάθε scope υποστηρίζει τις ίδιες ερωτήσεις:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) επιστρέφει containers με ενέργεια κλικ.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) επιστρέφει containers με ενέργεια mouse‑over.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) επιστρέφει containers με μία ή και τις δύο ενέργειες.

Το παρακάτω παράδειγμα δημιουργεί το `hyperlink-audit-input.pptx` με εξωτερικό σύνδεσμο κλικ, σύνδεσμο mouse‑over αρχείου, εσωτερική πλοήγηση διαφάνειας, σύνδεσμο mouse‑over κειμένου και ενέργεια μακροεντολής. Δεν εκτελεί καμία από αυτές τις ενέργειες. Οι τρεις ερωτήσεις λειτουργούν σε κάθε scope· οι μετρήσεις περιγράφουν containers, όχι το σύνολο των ενεργειών. Το scope πλαισίου κειμένου εξαιρεί τους δικούς του συνδέσμους που ανήκουν στο περιβάλλον σχήματος.

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

Για αυτό το παράδειγμα, οι ερωτήσεις παρουσίασης και διαφάνειας αναφέρουν τρία containers κλικ, δύο containers mouse‑over και τρία containers με οποιαδήποτε ενέργεια. Η ερώτηση πλαισίου κειμένου αναφέρει ένα container σε κάθε κατηγορία.

### **Κατάταξη Ενεργειών και Προορισμών**

Χρησιμοποιήστε το [IHyperlink.ActionType](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/actiontype/) για να ερμηνεύσετε μια ενέργεια πριν ερμηνεύσετε τον προορισμό της. Οι τιμές του [HyperlinkActionType](https://reference.aspose.com/slides/el/net/aspose.slides/hyperlinkactiontype/) καλύπτουν περισσότερα από απλή πλοήγηση στο web:

| Values | Σημασία για έλεγχο |
| --- | --- |
| `Hyperlink` | Εξωτερικός υπερσύνδεσμος· ελέγξτε το URL και το σχήμα του. |
| `JumpSpecificSlide` | Εσωτερική μετάβαση σε συγκεκριμένη διαφάνεια. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ενσωματωμένη πλοήγηση παρουσίασης, επιλύεται στο πλαίσιο της παρουσίασης. |
| `JumpEndShow`, `StartCustomSlideShow` | Τερματισμός τρέχουσας παρουσίασης ή εκκίνηση προσαρμοσμένης παρουσίασης. |
| `StartMacro` | Εκτέλεση μακροεντολής. |
| `StartProgram` | Έναρξη προγράμματος. |
| `OpenFile`, `OpenPresentation` | Άνοιγμα αρχείου ή άλλης παρουσίασης· ελέγξτε ξεχωριστά από URLs ιστού. |
| `StartStopMedia` | Έναρξη ή διακοπή αναπαραγωγής πολυμέσων. |
| `NoAction`, `Unknown` | Καμία ενέργεια πλοήγησης ή μη αναγνωρισμένη ενέργεια που απαιτεί έλεγχο. |

Διαβάστε τους εξωτερικούς προορισμούς από το [ExternalUrl](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/externalurl/) και τους συγκεκριμένους εσωτερικούς προορισμούς από το [TargetSlide](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/targetslide/). Οι εσωτερικές ενέργειες και οι ενσωματωμένες εντολές μπορεί να μην έχουν εξωτερικό URL· ένα κενό URL δεν σημαίνει ότι το container δεν έχει ενέργεια. Διατηρήστε το [ExternalUrlOriginal](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/externalurloriginal/) όταν διαφέρει από το κανονικοποιημένο URL, και συμπεριλάβετε το [Tooltip](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/tooltip/) εάν είναι διαθέσιμο.

### **Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσμων**

Το παρακάτω παράδειγμα .NET 6+ διαβάζει μια υπάρχουσα παρουσίαση (χρησιμοποιήστε το αρχείο που δημιουργήθηκε παραπάνω), γράφει το `hyperlink-audit.json`, εφαρμόζει μια πολιτική, αποθηκεύει το `hyperlink-sanitized.pptx` και το ανοίγει ξανά για να ελέγξει ξανά και τους δύο τύπους ενεργοποίησης. Συλλέγει containers πριν τα αλλάξει και χρησιμοποιεί ισότητα αναφοράς για να αποτρέψει την επεξεργασία του ίδιου container δύο φορές. Οι ερωτήσεις παρουσίασης καλύπτουν κανονικές διαφάνειες· για απογραφή σε όλο το πακέτο, ερωτά επίσης ρητά master, layout, σημειώσεις και τους master σημειώσεων/handout όταν υπάρχουν.

Η αναφορά καταγράφει έναν δείκτη διαφάνειας με βάση το 1 και το [SlideId](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseslide/slideid/) όπου είναι διαθέσιμο. Το [ISlideComponent.Slide](https://reference.aspose.com/slides/el/net/aspose.slides/islidecomponent/slide/) παρέχει τη διαφάνεια ιδιοκτήτη για υποστηριζόμενα containers. Οι master, layout και σημειώσεις δεν έχουν κανονικό δείκτη διαφάνειας και ταυτοποιούνται ανά scope. Τα containers σχήματος και τα containers μορφοποίησης τμημάτων κειμένου επισημαίνονται ξεχωριστά· άλλοι τύποι containers διατηρούν το όνομα τύπου εκτέλεσής τους. Κάθε container λαμβάνει ένα τοπικό ID αναφοράς ώστε οι δύο ενέργειές του να συσχετιστούν.

Αυτή η σκόπιμα περιοριστική πολιτική εφαρμογής επιτρέπει μόνο απόλυτα HTTPS URLs και έγκυρους εσωτερικούς προορισμούς διαφάνειας. Απορρίπτει μακροεντολές, προγράμματα, ενέργειες αρχείων, άλλες ενέργειες παρουσίασης, άγνωστες ενέργειες και άλλα σχήματα URL. Αυτές οι απορρίψεις είναι αποφάσεις πολιτικής, όχι απόφαση ασφαλείας του Aspose.Slides. Το μόνο HTTPS δεν εγγυάται εμπιστοσύνη: προσθέστε λίστες επιτρεπόμενων κεντρικών υπολογιστών και άλλους ελέγχους για την εφαρμογή σας. Ελέγχονται τόσο τα αρχικά όσο και τα κανονικοποιημένα εξωτερικά URLs. Το παράδειγμα ελέγχει μεταδεδομένα χωρίς να ακολουθεί συνδέσμους ή να εκτελεί ενέργειες.

Για αποκατάσταση, ο [HyperlinkManager](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) του container υποστηρίζει τα [SetExternalHyperlinkClick](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) και [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Εδώ, οι απαγορευμένοι εξωτερικοί σύνδεσμοι κλικ αντικαθίστανται με μια σταθερή σελίδα προσγείωσης HTTPS· οι άλλοι απαγορευμένοι κλικ και οι απαγορευμένες ενέργειες mouse‑over αφαιρούνται ανεξάρτητα. Ορίστε το `replaceExternalClicks` σε `false` για να αφαιρεθούν όλες οι παραβιάσεις πολιτικής. Επιλέξτε μια σελίδα αντικατάστασης που να ανήκει στην εφαρμογή σας πριν την υλοποίηση.

Η σημαία εξαγωγής της αναφοράς χρησιμοποιεί συντηρητική πολιτική ελέγχου PDF: σημαδεύει ενέργειες mouse‑over και οτιδήποτε άλλο εκτός από εξωτερικό σύνδεσμο ή συγκεκριμένο άλμα διαφάνειας ως πιθανώς μη υποστηριζόμενο. Είναι ένδειξη ελέγχου, όχι δοκιμή ικανότητας ή εγγύηση ότι τα μη σημειωμένα links θα διατηρηθούν στην εξαγωγή. Οι υποστηριζόμενες εξαγωγές [PDF](/slides/el/net/convert-powerpoint-to-pdf/) και [HTML](/slides/el/net/convert-powerpoint-to-html/) μπορεί να διατηρήσουν υπερσυνδέσμους, ανάλογα με την ενέργεια, τις επιλογές εξαγωγής και τον προβολέα. Τα raster [images](/slides/el/net/convert-powerpoint-to-png/) και [video](/slides/el/net/convert-powerpoint-to-video/) δεν μπορούν να διατηρήσουν διαδραστικούς υπερσυνδέσμους· σημαδεύστε κάθε ενέργεια όταν ελέγχετε για αυτές τις εξόδους.

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

Με το παραπάνω εισαγόμενο αρχείο, η αναφορά περιέχει πέντε γραμμές ενεργειών. Ο σύνδεσμος file mouse‑over και ο κλικ μακροεντολής αφαιρούνται, ενώ οι HTTPS σύνδεσμοι και η εσωτερική πλοήγηση διαφάνειας παραμένουν. Η επαλήθευση εμφανίζει μηδέν απαγορευμένες ενέργειες. Ένα εισαγόμενο αρχείο που περιέχει απαγορευμένο εξωτερικό URL κλικ επίσης ενεργοποιεί το κλάδο αντικατάστασης. Ένα container με επιτρεπτό κλικ και απαγορευμένο mouse‑over διατηρεί την ενέργεια κλικ.

Αυτή η επιλεκτική καθαριότητα διαφέρει από το [RemoveAllHyperlinks](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), το οποίο αφαιρεί και τους δύο τύπους ενεργοποίησης σε όλο το επιλεγμένο scope ανεξαρτήτως πολιτικής. Η επαλήθευση εδώ ελέγχει μόνο τις ενέργειες υπερσυνδέσμων· δεν αφαιρεί ενσωματωμένα VBA projects, OLE objects ή άλλο ενεργό περιεχόμενο, και δεν επικυρώνει εξαγόμενο PDF ή HTML αρχείο.

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Πώς μπορώ να συνδέσω με μια ενότητα ή την πρώτη της διαφάνεια;**

Οι ενότητες στο PowerPoint ομαδοποιούν διαφάνειες, αλλά ένας εσωτερικός υπερσύνδεσμος στοχεύει σε μια μεμονωμένη διαφάνεια. Για να δημιουργήσετε πλοήγηση σε ενότητα, συνδέστε την πρώτη διαφάνεια της ενότητας.

**Μπορώ να συνδέσω έναν υπερσύνδεσμο σε στοιχεία κύριας διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία της κύριας διαφάνειας και του layout υποστηρίζουν υπερσυνδέσμους. Οι σύνδεσμοι σε αυτά τα στοιχεία είναι διαθέσιμοι κατά τη παρουσίαση στις διαφάνειες που χρησιμοποιούν το αντίστοιχο master ή layout.

**Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;**

Οι υποστηριζόμενες εξαγωγές PDF και HTML μπορεί να διατηρήσουν υπερσυνδέσμους· οι raster εικόνες και τα βίντεο δεν μπορούν. Δείτε τις προconsiderations εξαγωγής στην ενότητα [Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσμων](#report-sanitize-and-verify-hyperlinks).