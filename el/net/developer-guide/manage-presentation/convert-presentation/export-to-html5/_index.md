---
title: Μετατροπή παρουσιάσεων σε HTML5 στο .NET
linktitle: Παρουσίαση σε HTML5
type: docs
weight: 40
url: /el/net/export-to-html5/
keywords:
- PowerPoint σε HTML5
- OpenDocument σε HTML5
- παρουσίαση σε HTML5
- διαφάνεια σε HTML5
- PPT σε HTML5
- PPTX σε HTML5
- ODP σε HTML5
- αποθήκευση PPT ως HTML5
- αποθήκευση PPTX ως HTML5
- αποθήκευση ODP ως HTML5
- εξαγωγή PPT σε HTML5
- εξαγωγή PPTX σε HTML5
- εξαγωγή ODP σε HTML5
- .NET
- C#
- Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint & OpenDocument σε ανταποκρίσιμο HTML5 με το Aspose.Slides για .NET. Διατήρηση μορφοποίησης, κινήσεων και διαδραστικότητας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides για .NET. Καλύπτει τη βασική εξαγωγή, τον έλεγχο των κινήσεων σχήματος και των μεταβάσεων διαφάνειας, καθώς και τη διάταξη σχολίων. Επίσης συγκρίνει την έξοδο HTML5 με την έξοδο βασισμένη σε SVG της τυπικής εξαγωγής HTML.

## **Εξαγωγή PowerPoint σε HTML5**

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση από τον τρέχοντα φάκελο και την αποθηκεύει σε μορφή HTML5. Χρησιμοποιεί τις προεπιλεγμένες ρυθμίσεις εξαγωγής· το επόμενο παράδειγμα δείχνει πώς να ελέγξετε την αναπαραγωγή των κινήσεων ρητά. Αντικαταστήστε τη διαδρομή εισόδου με τη διαδρομή της παρουσίασής σας.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Note" %}}
Εκτός από το έγγραφο HTML, η εξαγωγή γράφει υποστηρικτικά αρχεία CSS και JavaScript για τη μορφοποίηση των διαφανειών, τις κινήσεις, τα εφέ και την πλοήγηση. Διατηρήστε αυτά τα αρχεία μαζί με το έγγραφο HTML όταν μετακινείτε ή δημοσιεύετε το αποτέλεσμα. Η παραγόμενη σελίδα φορτώνει επίσης το jQuery και το Anime.js από δημόσια CDNs· χωρίς αυτά, η πλοήγηση των διαφανείων και οι κινήσεις δεν λειτουργούν.
{{% /alert %}}

Για να εξάγετε χωρίς την αναπαραγωγή κινήσεων σχήματος ή μεταβάσεων διαφάνειας, ορίστε το [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) και το [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) σε `false` στο [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Αυτές οι ρυθμίσεις είναι ανεξάρτητες, επομένως μπορείτε να ενεργοποιήσετε τη μία ενώ απενεργοποιείτε την άλλη. Το παράδειγμα εξάγει την παρουσίαση με και τους δύο τύπους κινήσεων απενεργοποιημένους στη δημιουργημένη σελίδα.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **Εξαγωγή PowerPoint σε HTML**

Η τυπική εξαγωγή HTML χρησιμοποιεί διαφορετική προσέγγιση απόδοσης: το περιεχόμενο της διαφάνειας αναπαρίσταται από SVG μέσα σε μια σελίδα HTML. Το παρακάτω παράδειγμα μετατρέπει μια παρουσίαση σε έγγραφο HTML χρησιμοποιώντας αυτήν την προσέγγιση απόδοσης.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

Η απλοποιημένη σήμανση παρακάτω απεικονίζει τη δομή της παραγόμενης σελίδας. Το στοιχείο SVG περιέχει το αποδομένο περιεχόμενο της διαφάνειας· το κείμενο κράτησης θέσης αντιπροσωπεύει αυτό το περιεχόμενο και δεν είναι κυριολεκτική έξοδος εξαγωγής.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
Η εξαγωγή βασισμένη σε SVG δεν εκθέτει τα σχήματα PowerPoint ως μεμονωμένα στοιχεία HTML. Χρησιμοποιήστε την εξαγωγή HTML5 όταν χρειάζεστε τις επιλογές κίνησης σχήματος και μετάβασης διαφάνειας που παρουσιάζονται σε αυτό το άρθρο.
{{% /alert %}}

## **Εξαγωγή PowerPoint σε προβολή διαφάνειας HTML5**

Η εξαγωγή HTML5 δημιουργεί μια σελίδα για προβολή και πλοήγηση των διαφανειών της παρουσίασης σε έναν περιηγητή. Αυτό το παράδειγμα ενεργοποιεί τόσο το [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) όσο και το [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) ώστε η εξαγόμενη προβολή διαφάνειας να μπορεί να αναπαράγει τα εφέ από την αρχική παρουσίαση.

Χρησιμοποιήστε μια παρουσίαση που ήδη περιέχει κινήσεις σχημάτων και μεταβάσεις διαφάνειας για να δείτε το αποτέλεσμα αυτών των ρυθμίσεων. Η ενεργοποίησή τους δεν προσθέτει νέα εφέ σε διαφάνειες που δεν τα έχουν. Μετά την εξαγωγή, ανοίξτε το παραγόμενο έγγραφο HTML5 σε έναν περιηγητή με τα υποστηρικτικά αρχεία διαθέσιμα.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **Μετατροπή παρουσίασης σε έγγραφο HTML5 με σχόλια**

Μπορείτε να συμπεριλάβετε υπάρχοντα σχόλια διαφανειών στην έξοδο HTML5 ώστε οι αναγνώστες να βλέπουν τα σχόλια δίπλα στο περιεχόμενο της διαφάνειας. Το παράδειγμα σε αυτήν την ενότητα υποθέτει ότι η πηγαία παρουσίαση περιέχει σχόλια, όπως εμφανίζεται παρακάτω. Εξάγει αυτά τα σχόλια· δεν δημιουργεί νέα.

![Δύο σχόλια στη διαφάνεια της παρουσίασης](two_comments_pptx.png)

Αντιστοιχίστε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) στην ιδιότητα [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) του [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Ορίστε το [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) σε `Right` από την κλήρωση [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) για να τοποθετήσετε τα σχόλια δεξιά από κάθε διαφάνεια.

Το παρακάτω παράδειγμα εξάγει την παρουσίαση σε HTML5 με αυτήν τη διάταξη σχολίων. Μια παρουσίαση χωρίς σχόλια δεν θα έχει κείμενο σχολίου προς εμφάνιση.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Η εικόνα παρακάτω δείχνει το εξαγόμενο έγγραφο HTML5 με τα σχόλια εμφανισμένα δίπλα στη διαφάνεια.

![Τα σχόλια στο παραγόμενο έγγραφο HTML5](two_comments_html5.png)

## **Εξαίρεση υπερσυνδέσμων JavaScript κατά την εξαγωγή**

Έστω ότι το `hyperlinks.pptx` περιέχει κειμενοσυνδέσμους με προορισμό `javascript:alert('Hello')` και έναν απλό σύνδεσμο `https://example.com/`. Για να εξαλλάξετε τον υπερσύνδεσμο JavaScript κατά την εξαγωγή, ορίστε το [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) σε `true`. Η προεπιλογή είναι `false`, επομένως αυτοί οι σύνδεσμοι δεν φιλτράρονται εκτός εάν ενεργοποιήσετε την επιλογή.

Το παρακάτω παράδειγμα φορτώνει την παρουσίαση από τον τρέχοντα φάκελο και την εξάγει χρησιμοποιώντας το [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

Το εξαγόμενο αρχείο παραλείπει τον υπερσύνδεσμο JavaScript κρατώντας το κείμενό του και τον κανονικό σύνδεσμο HTTPS. Η πηγαία παρουσίαση παραμένει αμετάβλητη.

Αυτή η επιλογή φιλτράρει τους υπερσυνδέσμους JavaScript· δεν αφαιρεί όλα τα σενάρια ή άλλο ενεργό περιεχόμενο, ούτε εγγυάται τη συμμόρφωση με CSP. Για παράδειγμα, η έξοδος HTML5 εξακολουθεί να περιλαμβάνει σενάρια για την πλοήγηση των διαφανειών και τις κινήσεις.

## **Συχνές ερωτήσεις**

**Μπορώ να ελέγξω αν οι κινήσεις αντικειμένων και οι μεταβάσεις διαφάνειας θα αναπαράγονται στο HTML5;**

Ναι, η εξαγωγή HTML5 παρέχει ξεχωριστές επιλογές για την ενεργοποίηση ή απενεργοποίηση των [κινήσεις σχήματος](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) και των [μεταβάσεις διαφάνειας](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**Υποστηρίζονται τα σχόλια και πού μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;**

Ναι, τα υπάρχοντα σχόλια μπορούν να συμπεριληφθούν στην έξοδο HTML5 και να τοποθετηθούν (π.χ., δεξιά της διαφάνειας) μέσω των [ρυθμίσεων διάταξης](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) για σημειώσεις και σχόλια.

**Μπορώ να παραλείψω συνδέσμους που καλούν JavaScript για λόγους ασφαλείας ή CSP;**

Ναι, η ρύθμιση [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) σας επιτρέπει να παραλείψετε υπερσυνδέσμους με κλήσεις JavaScript κατά την αποθήκευση. Η προεπιλογή είναι `false`. Δείτε το [Εξαίρεση υπερσυνδέσμων JavaScript κατά την εξαγωγή](/slides/el/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) για ένα απλό παράδειγμα εξαγωγής σε HTML, HTML5 και PDF και το εύρος του φίλτρου. Αυτή η ρύθμιση δεν αφαιρεί το JavaScript που χρησιμοποιείται από τον προβολέα HTML5 για πλοήγηση και κινήσεις.