---
title: Διαχείριση Μεταβάσεων Διαφάνειας σε Παρουσιάσεις σε .NET
linktitle: Μετάβαση Διαφάνειας
type: docs
weight: 90
url: /el/net/slide-transition/
keywords:
- μετάβαση διαφάνειας
- προσθήκη μετάβασης διαφάνειας
- εφαρμογή μετάβασης διαφάνειας
- προχωρημένη μετάβαση διαφάνειας
- μετάβαση Morph
- τύπος μετάβασης
- εφέ μετάβασης
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εφαρμόστε μεταβάσεις διαφάνειας, ρυθμίστε την αυτόματη προώθηση διαφανειών και προσαρμόστε τις μεταβάσεις Morph και άλλα εφέ μετάβασης με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Οι μεταβάσεις διαφάνειας ελέγχουν πώς εμφανίζονται οι διαφάνειες κατά τη διάρκεια μιας παρουσίασης. Με το Aspose.Slides για .NET, μπορείτε να επιλέξετε ένα εφέ μετάβασης για κάθε διαφάνεια, να ρυθμίσετε την προώθηση με κλικ του ποντικιού ή χρονομετρητή, και να προσαρμόσετε επιλογές ειδικές για ένα εφέ. Αυτό το άρθρο χρησιμοποιεί παραδείγματα C# για να εφαρμόσει μεταβάσεις, να ορίσει ακριβείς διάρκειες μετάβασης, να διαχειριστεί το χρόνο των διαφανειών, και να δημιουργήσει μια μετάβαση Morph μεταξύ δύο διαφανειών. Τα παραδείγματα δείχνουν επίσης πώς να αποθηκεύσετε τις ρυθμίσεις σε αρχείο PPTX.

## **Προσθήκη Μετάβασης Διαφάνειας**

Για να εφαρμόσετε μια μετάβαση, φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και αποκτήστε πρόσβαση στην ιδιότητα [SlideShowTransition](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseslide/slideshowtransition/) της διαφάνειας. Ορίστε την [Type](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/type/) σε μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/transitiontype/), κατόπιν αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα εφαρμόζει μια μετάβαση Circle στην πρώτη διαφάνεια και μια μετάβαση Comb στη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Προσθήκη Προχωρημένης Μετάβασης Διαφάνειας**

Μπορείτε να ρυθμίσετε πόσο καιρό παραμένει μια διαφάνεια στην οθόνη και αν ένα κλικ του ποντικιού προχωρά την παρουσίαση. Οι παρακάτω ιδιότητες ελέγχουν αυτή τη συμπεριφορά:

- [AdvanceOnClick](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/advanceonclick/) επιτρέπει στον θεατή να προχωρήσει με κλικ του ποντικιού.
- [AdvanceAfter](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/advanceafter/) ενεργοποιεί αυτόματη προώθηση.
- [AdvanceAfterTime](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/advanceaftertime/) καθορίζει την καθυστέρηση πριν από την αυτόματη προώθηση, σε χιλιοστά του δευτερολέπτου.

Ενεργοποιήστε και τα δύο, κλικ και χρονομετρημένη προώθηση, ώστε ο θεατής να μπορεί να προχωρήσει με κλικ ή να περιμένει τον χρονομετρητή. Για χρήση μόνο του χρονομετρητή, ορίστε το [AdvanceOnClick](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/advanceonclick/) σε `false`. Η καθυστέρηση ελέγχει πότε προχωρά η παρουσίαση· δεν καθορίζει τη διάρκεια του οπτικού εφέ μετάβασης.

Αυτό το παράδειγμα εκχωρεί διαφορετικά εφέ στις πρώτες τρεις διαφάνειες και ενεργοποιεί αυτόματη προώθηση μετά από 3, 5 και 7 δευτερόλεπτα, αντίστοιχα. Τα κλικ του ποντικιού μπορούν επίσης να προωθήσουν αυτές τις διαφάνειες. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον τρεις διαφάνειες.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

Για να ελέγξετε αν είναι ενεργή η χρονομετρημένη προώθηση, διαβάστε το [AdvanceAfter](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/advanceafter/). Μια αποθηκευμένη καθυστέρηση από μόνη της δεν υποδεικνύει ότι ο χρονομετρητής είναι ενεργός.

Το επόμενο παράδειγμα ανοίγει το αρχείο που αποθηκεύτηκε παραπάνω, αναφέρει κάθε ενεργό χρονομετρητή και απενεργοποιεί την αυτόματη προώθηση για διαφάνειες με καθυστέρηση μεγαλύτερη των δύο δευτερολέπτων. Ενεργοποιεί τα κλικ του ποντικιού για αυτές τις διαφάνειες και αποθηκεύει τις ενημερωμένες ρυθμίσεις.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **Ακριβής Έλεγχος Χρόνου Μετάβασης**

Χρησιμοποιήστε το [Duration](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/slideshowtransition/duration/) για να καθορίσετε το ακριβές μήκος ενός εφέ μετάβασης σε χιλιοστά του δευτερολέπτου. Η ιδιότητα [SlideShowTransition](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseslide/slideshowtransition/) της διαφάνειας εκθέτει αυτές τις ρυθμίσεις μέσω του [ISlideShowTransition](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/):

| Property | Purpose |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/slideshowtransition/duration/) | Ορίζει τη διάρκεια του ίδιου εφέ μετάβασης, σε χιλιοστά του δευτερολέπτου. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Ορίζει την καθυστέρηση πριν η διαφάνεια προχωρήσει αυτόματα, σε χιλιοστά του δευτερολέπτου. Ενεργοποιήστε το [AdvanceAfter](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/advanceafter/) για να ενεργοποιήσετε αυτόν τον χρονομετρητή. |
| [Speed](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/slideshowtransition/speed/) | Επιλέγει μια προκαθορισμένη κατηγορία ταχύτητας από το [TransitionSpeed](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium ή Fast. Χρησιμοποιείται όταν δεν καθορίζεται ακριβής διάρκεια. |

Το [Duration](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/slideshowtransition/duration/) ελέγχει μόνο το εφέ μετάβασης· δεν καθορίζει πόσο καιρό παραμένει ορατή η διαφάνεια. Ρυθμίστε την αυτόματη καθυστέρηση προώθησης ξεχωριστά. Όταν δεν οριστεί ρητή διάρκεια, το Aspose.Slides υπολογίζει τη διάρκεια του εφέ από τον τύπο μετάβασης και την τιμή του [Speed](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Εφαρμογή του Ίδιου Διάρκειας σε Όλες τις Διαφάνειες**

Για ομοιόμορφο ρυθμό, εφαρμόστε το ίδιο εφέ και ακριβή διάρκεια σε κάθε διαφάνεια. Αυτό το παράδειγμα φορτώνει το `input.pptx`, επιλέγει Fade από το [TransitionType](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/transitiontype/), και δίνει σε κάθε μετάβαση διάρκεια 750 χιλιοστών του δευτερολέπτου. Επιπλέον ενεργοποιεί αυτόματη προώθηση μετά από 5 000 χιλιοστά και απενεργοποιεί την προώθηση με κλικ του ποντικιού, κατόπιν αποθηκεύει το αποτέλεσμα ως PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // Διαμορφώστε την αυτόματη προώθηση ανεξάρτητα από τη διάρκεια του εφέ.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Ορισμός Διαφορετικών Διάρκειών για Ατομικές Διαφάνειες**

Διαφορετικές διαφάνειες μπορούν να έχουν διαφορετικές διάρκειες εφέ. Για παράδειγμα, χρησιμοποιήστε μια σύντομη μετάβαση για τη διαφάνεια τίτλου και μια μεγαλύτερη για την εισαγωγή ενότητας. Αυτό το παράδειγμα ορίζει 500 χιλιοστά για την πρώτη διαφάνεια και 1 200 χιλιοστά για τη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **Συντονισμός Μεταβάσεων με Αναπαραγωγόμενη Έξοδο**

Κατά την προετοιμασία ενός [animated GIF](/slides/el/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/el/net/export-to-html5/), ή [video](/slides/el/net/convert-powerpoint-to-video/), ορίστε ακριβείς διάρκειες μετάβασης πριν από την εξαγωγή ώστε να ταιριάζουν με το επιθυμητό ρυθμό. Για παράδειγμα, χρησιμοποιήστε μια εξασθένιση 600 χιλιοστών μεταξύ σκηνών και ρυθμίστε την καθυστέρηση προόδου κάθε διαφάνειας ξεχωριστά για να επιτρέψετε χρόνο για την αφήγηση ή το περιεχόμενο.

Για GIF και βίντεο, συντονίστε το ρυθμό καρέ της εξόδου με τη διάρκεια του εφέ: 600 χιλιοστά αντιστοιχούν σε 18 καρέ στα 30 καρέ ανά δευτερόλεπτο. Στο HTML5, ενεργοποιήστε τις κινούμενες μεταβάσεις στις ρυθμίσεις εξαγωγής. Ελέγξτε τις υποστηριζόμενες μεταβάσεις και επιλογές χρόνου του επιλεγμένου μορφότυπου εξόδου και προεπισκοπήστε το αποτέλεσμα για να επιβεβαιώσετε το συγχρονισμό.

### **Ανάγνωση Υπάρχουσας Διάρκειας Μετάβασης**

Διαβάστε το [Duration](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/slideshowtransition/duration/) πριν τροποποιήσετε τη μετάβαση για να καθορίσετε εάν αποθηκεύεται ρητή τιμή. Μία τιμή `-1` σημαίνει ότι δεν έχει οριστεί ρητή διάρκεια· μια μη αρνητική τιμή καθορίζει τη αποθηκευμένη διάρκεια σε χιλιοστά του δευτερολέπτου. Η μη ορισμένη τιμή δεν είναι η υπολογιζόμενη διάρκεια εκτέλεσης: το Aspose.Slides χρησιμοποιεί τον τύπο μετάβασης και το [Speed](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/slideshowtransition/speed/) για να καθορίσει αυτήν τη διάρκεια. Η επιλογή τύπου μετάβασης μπορεί να αρχικοποιήσει διάρκεια, γι’ αυτό ελέγξτε πρώτα τις αρχικές ρυθμίσεις.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Μετάβαση Morph**

Η μετάβαση Morph κινεί τις αλλαγές μεταξύ αντικειμένων σε διαδοχικές διαφάνειες. Για να δημιουργήσετε ένα απλό εφέ Morph, αντιγράψτε μια διαφάνεια, μετακινήστε ή αλλάξτε το μέγεθος ενός αντικειμένου στην αντιγραφή, και εφαρμόστε τη μετάβαση Morph στη δεύτερη διαφάνεια. Αυτό παρέχει στα αντίστοιχα αντικείμενα το μονοπάτι κίνησης μεταξύ της αρχικής και της τροποποιημένης κατάστασής τους.

Το παρακάτω παράδειγμα δημιουργεί μια διαφάνεια με ένα τετράγωνο κειμένου, αντιγράφει τη διαφάνεια, και αλλάζει τη θέση και το μέγεθος του τετραγώνου στην αντιγραφή. Στη συνέχεια επιλέγει Morph από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/transitiontype/) για τη δεύτερη διαφάνεια. Ανοίξτε το αποθηκευμένο αρχείο σε προβολέα παρουσίασης που υποστηρίζει Morph για να δείτε το εφέ κατά τη διάρκεια της παρουσίασης.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Τύποι Μετάβασης Morph**

Η απαρίθμηση [TransitionMorphType](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/transitionmorphtype/) ελέγχει πώς το Morph ταιριάζει και κινεί το περιεχόμενο:

- [ByObject](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/transitionmorphtype/) αντιμετωπίζει κάθε σχήμα ως ολόκληρο αντικείμενο.
- [ByWord](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/transitionmorphtype/) κινεί το κείμενο ταιριάζοντας λέξεις όπου είναι δυνατόν.
- [ByChar](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/transitionmorphtype/) κινεί το κείμενο ταιριάζοντας χαρακτήρες όπου είναι δυνατόν.

Ορίστε την [Type](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/type/) της μετάβασης σε Morph πριν αποκτήσετε πρόσβαση στην [Value](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/value/). Η τιμή παρέχει το interface [IMorphTransition](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/imorphtransition/), του οποίου η ιδιότητα [MorphType](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/imorphtransition/morphtype/) επιλέγει τη λειτουργία αντιστοίχισης.

Αυτό το παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε στην προηγούμενη ενότητα και ρυθμίζει τη δεύτερη διαφάνεια να χρησιμοποιεί μεταφορά Morph βάσει λέξεων.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Ορισμός Εφέ Μετάβασης**

Ορισμένες μεταβάσεις εκθέτουν πρόσθετες επιλογές, όπως κατεύθυνση ή αν το εφέ ξεκινά από μαύρη οθόνη. Οι διαθέσιμες επιλογές εξαρτώνται από τον επιλεγμένο [Type](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/type/). Ορίστε πρώτα τον τύπο, κατόπιν χρησιμοποιήστε το κατάλληλο interface από το [Value](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/value/).

Το παρακάτω παράδειγμα εφαρμόζει μια μετάβαση Cut στην πρώτη διαφάνεια του `input.pptx`. Ορίζει το [FromBlack](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) μέσω του [IOptionalBlackTransition](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/ioptionalblacktransition/) ώστε η μετάβαση να ξεκινά από μαύρη οθόνη.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω την ταχύτητα αναπαραγωγής μιας μετάβασης διαφάνειας;**

Ναι. Προτιμήστε το [Duration](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/slideshowtransition/duration/) όταν χρειάζεστε ακριβή διάρκεια εφέ σε χιλιοστά του δευτερολέπτου. Χρησιμοποιήστε το [Speed](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/slideshowtransition/speed/) όταν μια προκαθορισμένη κατηγορία [TransitionSpeed](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/transitionspeed/)—Slow, Medium ή Fast—είναι επαρκής και δεν έχει οριστεί ρητή διάρκεια. Αυτές οι ρυθμίσεις ελέγχουν το εφέ μετάβασης ανεξάρτητα από την καθυστέρηση αυτόματης προώθησης.

**Μπορώ να προσθέσω ήχο σε μια μετάβαση και να τον επαναλαμβάνω;**

Ναι. Αναθέστε ενσωματωμένο ήχο στο [Sound](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/sound/), ορίστε το [SoundMode](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/soundmode/) σε StartSound από την απαρίθμηση [TransitionSoundMode](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/transitionsoundmode/), και ενεργοποιήστε το [SoundLoop](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/soundloop/). Ο ήχος επαναλαμβάνεται μέχρι το επόμενο ηχητικό γεγονός στην παρουσίαση.

**Ποιος είναι ο πιο γρήγορος τρόπος για να εφαρμόσω την ίδια μετάβαση σε κάθε διαφάνεια;**

Διέλθετε τη συλλογή [Slides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/slides/el/) της παρουσίασης και ορίστε την [Type](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/type/) της μετάβασης σε κάθε διαφάνεια στην ίδια τιμή. Ορίστε τυχόν χρονικές και επιλογές εφέ μέσα στον ίδιο βρόχο για να διατηρήσετε τη συμπεριφορά συνέπεια μεταξύ των διαφανειών.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι αυτή τη στιγμή ορισμένη σε μια διαφάνεια;**

Διαβάστε την ιδιότητα [Type](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/type/) από τη [SlideShowTransition](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseslide/slideshowtransition/) της διαφάνειας. Επιστρέφει μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/transitiontype/); η τιμή None σημαίνει ότι δεν έχει εφαρμοστεί κανένα εφέ μετάβασης.