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
- προηγμένη μετάβαση διαφάνειας
- μετάβαση morph
- τύπος μετάβασης
- εφέ μετάβασης
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανακαλύψτε πώς να προσαρμόζετε τις μεταβάσεις διαφάνειας στο Aspose.Slides για .NET, με καθοδήγηση βήμα προς βήμα για παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε τις μεταβάσεις διαφάνειας σε παρουσιάσεις χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να εφαρμόζετε τύπους μεταβάσεων σε διαφάνειες, να ρυθμίζετε τη συμπεριφορά της μετάβασης όπως η προώθηση με κλικ ή μετά από συγκεκριμένο χρόνο, να ελέγχετε και να απενεργοποιείτε την αυτόματη προώθηση, να χρησιμοποιείτε τη μετάβαση Morph και τους τύπους της, και να ορίζετε επιλογές εφέ μετάβασης. Τα παραδείγματα δείχνουν πώς να φορτώσετε ή να δημιουργήσετε μια παρουσίαση, να τροποποιήσετε τις ρυθμίσεις μετάβασης για επιλεγμένες διαφάνειες και να αποθηκεύσετε το αποτέλεσμα σε αρχείο PPTX. Το άρθρο επίσης απαντά σε συχνές ερωτήσεις σχετικά με την ταχύτητα της μετάβασης, τα ήχους της μετάβασης, την εφαρμογή της ίδιας μετάβασης σε πολλές διαφάνειες και τον έλεγχο της τρέχουσας μετάβασης σε μια διαφάνεια.

## **Προσθήκη Μετάβασης Διαφάνειας**
Για να γίνει πιο εύκολο να κατανοηθεί, παρουσιάσαμε τη χρήση του Aspose.Slides for .NET για τη διαχείριση απλών μεταβάσεων διαφάνειας. Οι προγραμματιστές μπορούν όχι μόνο να εφαρμόζουν διαφορετικά εφέ μετάβασης στις διαφάνειες αλλά και να προσαρμόζουν τη συμπεριφορά αυτών των εφέ. Για να δημιουργήσετε ένα απλό εφέ μετάβασης διαφάνειας, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Εφαρμόστε έναν τύπο μετάβασης διαφάνειας στη διαφάνεια χρησιμοποιώντας ένα από τα εφέ μετάβασης που προσφέρει το Aspose.Slides for .NET μέσω του enum TransitionType.
3. Αποθηκεύστε το τροποποιημένο αρχείο παρουσίασης.

```c#
// Δημιουργία αντικειμένου Presentation για φόρτωση του αρχείου πηγαίας παρουσίασης
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Εφαρμογή μετάβασης τύπου κύκλου στη διαφάνεια 1
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Εφαρμογή μετάβασης τύπου χτένι στη διαφάνεια 2
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Αποθήκευση της παρουσίασης στο δίσκο
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

## **Προσθήκη Προηγμένης Μετάβασης Διαφάνειας**
Στο προηγούμενο τμήμα, εφαρμόσαμε μόνο ένα απλό εφέ μετάβασης στη διαφάνεια. Τώρα, για να κάνετε αυτό το απλό εφέ ακόμη καλύτερο και πιο ελεγχόμενο, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Εφαρμόστε έναν τύπο μετάβασης διαφάνειας στη διαφάνεια χρησιμοποιώντας ένα από τα εφέ μετάβασης που προσφέρει το Aspose.Slides for .NET.
3. Μπορείτε επίσης να ορίσετε τη μετάβαση να προχωρά με κλικ, μετά από συγκεκριμένο χρονικό διάστημα ή και τα δύο.
4. Εάν η μετάβαση διαφάνειας είναι ενεργοποιημένη για προώθηση με κλικ, η μετάβαση θα προχωρά μόνο όταν κάποιος κάνει κλικ με το ποντίκι. Επιπλέον, εάν έχει οριστεί η ιδιότητα Advance After Time, η μετάβαση θα προχωρά αυτόματα μετά το πέρας του καθορισμένου χρόνου προώθησης.
5. Αποθηκεύστε το τροποποιημένο αρχείο παρουσίασης.

```c#
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Εφαρμογή μετάβασης τύπου κύκλου στη διαφάνεια 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Ορισμός χρόνου μετάβασης στα 3 δευτερόλεπτα
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Εφαρμογή μετάβασης τύπου χτένι στη διαφάνεια 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Ορισμός χρόνου μετάβασης στα 5 δευτερόλεπτα
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Εφαρμογή μετάβασης τύπου ζουμ στη διαφάνεια 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Ορισμός χρόνου μετάβασης στα 7 δευτερόλεπτα
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Αποθήκευση της παρουσίασης στο δίσκο
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

Επιπλέον, χρησιμοποιώντας την ιδιότητα [AdvanceAfter](https://reference.aspose.com/slides/el/net/aspose.slides/islideshowtransition/advanceafter/), μπορείτε να ελέγξετε εάν μια μετάβαση διαφάνειας έχει ρυθμιστεί να μεταβαίνει στην επόμενη διαφάνεια ή να απενεργοποιήσετε τη ρύθμιση.

Αυτός ο κώδικας C# δείχνει τη λειτουργία:

```c#
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Λαμβάνει τη μετάβαση της διαφάνειας
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Ελέγχει εάν η ρύθμιση AdvanceAfterTime είναι ενεργοποιημένη
        if (slideTransition.AdvanceAfter)
        {
            // Εκτυπώνει την τιμή AdvanceAfterTime
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Απενεργοποιεί τη μετάβαση μετά από συγκεκριμένο χρόνο αν η τιμή AdvanceAfterTime είναι μεγαλύτερη από 2 δευτερόλεπτα
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **Μετάβαση Morph**
Το Aspose.Slides for .NET υποστηρίζει τώρα τη [Morph Transition](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/imorphtransition). Αντιπροσωπεύει μια νέα μετάβαση morph που εισήχθη στο PowerPoint 2019. Η μετάβαση Morph σας επιτρέπει να δημιουργήσετε ομαλή κίνηση από τη μία διαφάνεια στην επόμενη. Αυτό το άρθρο περιγράφει την έννοια και πώς να χρησιμοποιήσετε τη μετάβαση Morph. Για να χρησιμοποιήσετε αποτελεσματικά τη μετάβαση Morph, θα χρειαστεί να έχετε δύο διαφάνειες με τουλάχιστον ένα κοινό αντικείμενο. Ο πιο εύκολος τρόπος είναι να διπλασιάσετε τη διαφάνεια και στη συνέχεια να μετακινήσετε το αντικείμενο στη δεύτερη διαφάνεια σε διαφορετική θέση.

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να προσθέσετε ένα αντίγραφο της διαφάνειας με κάποιο κείμενο στην παρουσίαση και να ορίσετε μια μετάβαση του [morph type](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) στη δεύτερη διαφάνεια.

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Τύποι Μετάβασης Morph**
Νέο enum [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/transitionmorphtype) προστέθηκε. Αντιπροσωπεύει διαφορετικούς τύπους μετάβασης Morph διαφάνειας.

Το enum TransitionMorphType έχει τρία μέλη:

- ByObject: Η μετάβαση Morph θα πραγματοποιηθεί λαμβάνοντας υπόψη τα σχήματα ως αδιάσπαστα αντικείμενα.
- ByWord: Η μετάβαση Morph θα πραγματοποιηθεί με τη μεταφορά του κειμένου ανά λέξεις όπου είναι δυνατόν.
- ByChar: Η μετάβαση Morph θα πραγματοποιηθεί με τη μεταφορά του κειμένου ανά χαρακτήρες όπου είναι δυνατόν.

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να ορίσετε τη μετάβαση morph σε διαφάνεια και να αλλάξετε τον τύπο morph:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Εφέ Μετάβασης**
Το Aspose.Slides for .NET υποστηρίζει τον ορισμό εφέ μετάβασης, π.χ. από το μαύρο, από αριστερά, από δεξιά κ.λπ. Για να ορίσετε το εφέ μετάβασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
- Αποκτήστε την αναφορά της διαφάνειας.
- Ορισμός του εφέ μετάβασης.
- Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/).

Στο παρακάτω παράδειγμα, έχουμε ορίσει τα εφέ μετάβασης.

```c#
// Δημιουργία αντικειμένου Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Ορισμός εφέ
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Αποθήκευση της παρουσίασης στο δίσκο
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Μπορώ να ελέγξω την ταχύτητα αναπαραγωγής μιας μετάβασης διαφάνειας;**

Ναι. Ορίστε την [Speed](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/slideshowtransition/speed/) της μετάβασης χρησιμοποιώντας τη ρύθμιση [TransitionSpeed](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/transitionspeed/) (π.χ. αργή/μεσαία/γρήγορη).

**Μπορώ να συνδέσω ήχο σε μια μετάβαση και να τον επαναλαμβάνω;**

Ναι. Μπορείτε να ενσωματώσετε έναν ήχο για τη μετάβαση και να ελέγξετε τη συμπεριφορά μέσω ρυθμίσεων όπως η κατάσταση ήχου και η επανάληψη (π.χ., [Sound](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/slideshowtransition/soundloop/), καθώς και μεταδεδομένα όπως [SoundIsBuiltIn](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) και [SoundName](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/slideshowtransition/soundname/)).

**Ποιος είναι ο πιο γρήγορος τρόπος για να εφαρμόσετε την ίδια μετάβαση σε κάθε διαφάνεια;**

Ρυθμίστε τον επιθυμητό τύπο μετάβασης στη ρύθμιση μετάβασης κάθε διαφάνειας· οι μεταβάσεις αποθηκεύονται ανά διαφάνεια, έτσι η εφαρμογή του ίδιου τύπου σε όλες τις διαφάνειες δίνει ένα συνεπές αποτέλεσμα.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι αυτή τη στιγμή ορισμένη σε μια διαφάνεια;**

Εξετάστε τις [ρυθμίσεις μετάβασης](https://reference.aspose.com/slides/el/net/aspose.slides/baseslide/slideshowtransition/) της διαφάνειας και διαβάστε το [transition type](https://reference.aspose.com/slides/el/net/aspose.slides.slideshow/slideshowtransition/type/); αυτή η τιμή σας δείχνει ακριβώς ποιο εφέ είναι εφαρμόσμενο.