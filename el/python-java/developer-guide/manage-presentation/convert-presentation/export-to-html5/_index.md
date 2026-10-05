---
title: Μετατροπή Παρουσιάσεων σε HTML5 με Python μέσω Java
linktitle: Παρουσίαση σε HTML5
type: docs
weight: 40
url: /el/python-java/export-to-html5/
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
- Python
- Java
- Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint & OpenDocument σε ανταποκριτικό HTML5 με Aspose.Slides για Python μέσω Java. Διατήρηση μορφοποίησης, κινήσεων και διαδραστικότητας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides for Python via Java. Καλύπτει τη βασική εξαγωγή, τον έλεγχο των κινούμενων σχημάτων και των μεταβάσεων διαφάνειας, καθώς και τη διάταξη σχολίων. Συγκρίνει επίσης την έξοδο HTML5 με την έξοδο βασισμένη σε SVG της τυπικής εξαγωγής HTML.

Τα παραδείγματα απαιτούν το Aspose.Slides for Python via Java και ένα συμβατό περιβάλλον εκτέλεσης Java. Τοποθετήστε τις εισερχόμενες παρουσιάσεις στον τρέχοντα κατάλογο εργασίας. Κάθε παράδειγμα ξεκινά το JVM μόνο αν δεν εκτελείται ήδη.

## **Εξαγωγή PowerPoint σε HTML5**

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση από τον κατάλογο εργασίας και την αποθηκεύει σε μορφή HTML5. Χρησιμοποιεί τις προεπιλεγμένες ρυθμίσεις εξαγωγής· το επόμενο παράδειγμα δείχνει πώς να ελέγξετε ρητά την αναπαραγωγή των κινούμενων σχεδίων. Αντικαταστήστε το μονοπάτι εισόδου με το μονοπάτι της παρουσίασής σας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Εκτός από το έγγραφο HTML, η εξαγωγή δημιουργεί υποστηρικτικά αρχεία CSS και JavaScript για το στυλ των διαφανειών, τις κινήσεις, τα εφέ και την πλοήγηση. Κρατήστε αυτά τα αρχεία μαζί με το έγγραφο HTML όταν μετακινείτε ή δημοσιεύετε το αποτέλεσμα. Η παραγόμενη σελίδα φορτώνει επίσης jQuery και Anime.js από δημόσια CDNs· χωρίς αυτά, η πλοήγηση και οι κινήσεις των διαφανειών δεν λειτουργούν.
{{% /alert %}}

Για να εξάγετε χωρίς την αναπαραγωγή των κινήσεων σχημάτων ή των μεταβάσεων διαφάνειας, περάστε `False` στο [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) και στο [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) στο [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Αυτές οι ρυθμίσεις είναι ανεξάρτητες, έτσι μπορείτε να ενεργοποιήσετε τη μία ενώ απενεργοποιείτε την άλλη. Το παράδειγμα εξάγει την παρουσίαση με και τους δύο τύπους κινήσεων απενεργοποιημένους στη δημιουργημένη σελίδα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(False)
html5_options.setAnimateTransitions(False)

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Εξαγωγή PowerPoint σε HTML**

Η τυπική εξαγωγή HTML χρησιμοποιεί διαφορετική προσέγγιση απόδοσης: το περιεχόμενο της διαφάνειας αντιπροσωπεύεται από SVG μέσα σε μια σελίδα HTML. Το παρακάτω παράδειγμα μετατρέπει μια παρουσίαση σε έγγραφο HTML χρησιμοποιώντας αυτήν την προσέγγιση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Η παρακάτω απλοποιημένη σήμανση απεικονίζει τη δομή της παραγόμενης σελίδας. Το στοιχείο SVG περιέχει το αποδιδόμενο περιεχόμενο της διαφάνειας· το κείμενο υποκατάστασης αντιπροσωπεύει αυτό το περιεχόμενο και δεν είναι κυριολεκτικό αποτέλεσμα εξαγωγής.

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
Η εξαγωγή βασισμένη σε SVG δεν εκθέτει τα σχήματα PowerPoint ως ξεχωριστά στοιχεία HTML. Χρησιμοποιήστε την εξαγωγή HTML5 όταν χρειάζεστε τις επιλογές κίνησης σχήματος και μετάβασης διαφάνειας που επιδεικνύονται σε αυτό το άρθρο.
{{% /alert %}}

## **Εξαγωγή PowerPoint σε Προβολή Διαφανειών HTML5**

Η εξαγωγή HTML5 δημιουργεί μια σελίδα για προβολή και περιήγηση των διαφανειών της παρουσίασης σε πρόγραμμα περιήγησης. Αυτό το παράδειγμα ενεργοποιεί τόσο το [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) όσο και το [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) ώστε η εξαγόμενη προβολή διαφανειών να μπορεί να αναπαράγει τα εφέ από την πηγαία παρουσίαση.

Χρησιμοποιήστε μια παρουσίαση που ήδη περιέχει κινήσεις σχημάτων και μεταβάσεις διαφάνειας για να δείτε το αποτέλεσμα αυτών των ρυθμίσεων. Η ενεργοποίησή τους δεν προσθέτει νέα εφέ σε διαφάνειες που δεν τα έχουν. Μετά την εξαγωγή, ανοίξτε το παραγόμενο έγγραφο HTML5 σε πρόγραμμα περιήγησης με τα υποστηρικτικά αρχεία διαθέσιμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(True)
html5_options.setAnimateTransitions(True)

presentation = Presentation("pres.pptx")
try:
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Μετατροπή Παρουσίασης σε Έγγραφο HTML5 με Σχόλια**

Μπορείτε να συμπεριλάβετε υπάρχοντα σχόλια διαφάνειας στην έξοδο HTML5 έτσι ώστε οι αναγνώστες να βλέπουν τα σχόλια μαζί με το περιεχόμενο της διαφάνειας. Το παράδειγμα σε αυτήν την ενότητα υποθέτει ότι η πηγαία παρουσίαση περιέχει σχόλια, όπως φαίνεται παρακάτω. Εξάγει αυτά τα σχόλια· δεν δημιουργεί νέα.

![Δύο σχόλια στη διαφάνεια της παρουσίασης](two_comments_pptx.png)

Περάστε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) στη μέθοδο [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) του [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Χρησιμοποιήστε το [setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) για να επιλέξετε `Right` από την απαρίθμηση [CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/) ώστε να τοποθετήσετε τα σχόλια στα δεξιά κάθε διαφάνειας.

Το παρακάτω παράδειγμα εξάγει την παρουσίαση σε HTML5 με αυτήν τη διάταξη σχολίων. Μία παρουσίαση χωρίς σχόλια δεν θα έχει κείμενο σχολίου για προβολή.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, Html5Options, NotesCommentsLayoutingOptions, Presentation, SaveFormat

layout_options = NotesCommentsLayoutingOptions()
layout_options.setCommentsPosition(CommentsPositions.Right)

html5_options = Html5Options()
html5_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Τα σχόλια στο παραγόμενο έγγραφο HTML5

![Τα σχόλια στο παραγόμενο έγγραφο HTML5](two_comments_html5.png)

## **Εξαίρεση Υπερσυνδέσμων JavaScript Κατά τη Διάρκεια Εξαγωγής**

Ας υποθέσουμε ότι το `hyperlinks.pptx` περιέχει κειμενικό σύνδεσμο με προορισμό `javascript:alert('Hello')` και έναν συνηθισμένο σύνδεσμο `https://example.com/`. Για να εξαιρέσετε τον υπερσύνδεσμο JavaScript κατά την εξαγωγή, περάστε `True` στη μέθοδο [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). Η προεπιλογή είναι `False`, έτσι αυτοί οι σύνδεσμοι δεν φιλτράρονται εκτός εάν ενεργοποιήσετε την επιλογή.

Το παρακάτω παράδειγμα φορτώνει την παρουσίαση από τον κατάλογο εργασίας και την εξάγει χρησιμοποιώντας το [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setSkipJavaScriptLinks(True)

presentation = Presentation("hyperlinks.pptx")
try:
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Το εξαγόμενο αρχείο παραλείπει τον υπερσύνδεσμο JavaScript ενώ διατηρεί το κείμενό του και τον συνηθισμένο σύνδεσμο HTTPS. Η πηγαία παρουσίαση δεν τροποποιείται.

Αυτή η επιλογή φιλτράρει τους υπερσυνδέσμους JavaScript· δεν αφαιρεί όλα τα σενάρια ή άλλο ενεργό περιεχόμενο, ούτε εγγυάται τη συμμόρφωση με το CSP. Για παράδειγμα, η έξοδος HTML5 εξακολουθεί να περιλαμβάνει σενάρια για την πλοήγηση των διαφανών και τις κινήσεις.

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω αν οι κινήσεις αντικειμένων και οι μεταβάσεις διαφανειών θα αναπαράγονται στο HTML5;**

Ναι, η εξαγωγή HTML5 παρέχει ξεχωριστές επιλογές για την ενεργοποίηση ή απενεργοποίηση των [shape animations](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) καθώς και των [slide transitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions).

**Υποστηρίζονται τα σχόλια και πού μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;**

Ναι, τα υπάρχοντα σχόλια μπορούν να συμπεριληφθούν στην έξοδο HTML5 και να τοποθετηθούν (για παράδειγμα, στα δεξιά της διαφάνειας) μέσω των [layout settings](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) για σημειώσεις και σχόλια.

**Μπορώ να παραλείψω συνδέσμους που εκτελούν JavaScript για λόγους ασφαλείας ή CSP;**

Ναι, η ρύθμιση [setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) σας επιτρέπει να παραλείψετε υπερσυνδέσμους με κλήσεις JavaScript κατά την αποθήκευση. Η προεπιλογή είναι `False`. Δείτε το [Exclude JavaScript Hyperlinks During Export](/slides/el/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) για ένα παράδειγμα εξαγωγής HTML5 και το πεδίο εφαρμογής του φίλτρου. Αυτή η ρύθμιση δεν αφαιρεί το JavaScript που χρησιμοποιείται από το πρόγραμμα προβολής HTML5 για πλοήγηση και κινήσεις.