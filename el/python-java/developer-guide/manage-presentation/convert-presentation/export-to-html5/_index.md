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
description: "Εξαγωγή παρουσιάσεων PowerPoint & OpenDocument σε προσαρμοστικό HTML5 με το Aspose.Slides for Python via Java. Διατήρηση μορφοποίησης, κινήσεων και διαδραστικότητας."
---
## **Επισκόπηση**

Το άρθρο αυτό εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides. Καλύπτει τη βασική εξαγωγή HTML5 χωρίς πρόσθετες web επεκτάσεις, καθώς και επιλογές για τον έλεγχο των εφέ κίνησης σχημάτων και των μεταβάσεων διαφανειών. Το άρθρο δείχνει επίσης τη στάνταρ διαδικασία εξαγωγής PowerPoint σε HTML, εξηγεί πώς να δημιουργήσετε έξοδο HTML5 σε λειτουργία προβολής διαφανειών και επιδεικνύει πώς να συμπεριλάβετε σχόλια στο εξαγόμενο έγγραφο διαμορφώνοντάς τα.

Τα παραδείγματα απαιτούν Aspose.Slides for Python via Java και ένα συμβατό Java runtime. Τοποθετήστε το `pres.pptx` (ή `sample.pptx` για το παράδειγμα με τα σχόλια) στον τρέχοντα φάκελο εργασίας. Κάθε παράδειγμα ξεκινά το JVM μόνο αν δεν είναι ήδη σε λειτουργία.

## **Εξαγωγή PowerPoint σε HTML5**

Χρησιμοποιήστε [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) με [SaveFormat.Html5](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Html5) για να εξάγετε μια παρουσίαση χωρίς πρόσθετες web επεκτάσεις:

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

{{% alert color="info" title="Σημείωση" %}} 
Ο εξαγωγέας HTML5 δημιουργεί περιεχόμενο HTML για προβολή σε έναν φυλλομετρητή. 
{{% /alert %}}

Χρησιμοποιήστε [Html5Options](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/) για να διαμορφώσετε την εξαγωγή. Καλέστε τις μεθόδους [setAnimateShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/#setAnimateShapes) και [setAnimateTransitions](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/#setAnimateTransitions) με `False` για να απενεργοποιήσετε τις κινήσεις σχημάτων και τις μεταβάσεις διαφανών:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Εξαγωγή PowerPoint σε HTML**

Χρησιμοποιήστε [SaveFormat.Html](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Html) για τυπική εξαγωγή HTML. Δείτε το [Convert PowerPoint to HTML](/slides/el/python-java/convert-powerpoint-to-html/) για περισσότερες επιλογές:

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

Σε αυτήν την περίπτωση, το περιεχόμενο της παρουσίασης αποδίδεται μέσω SVG με τη μορφή όπως αυτή:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Προειδοποίηση" color="warning" %}} 
Η τυπική εξαγωγή HTML αποδίδει το περιεχόμενο της διαφάνειας μέσω SVG και δεν παρέχει τις επιλογές κίνησης σχήματος και μετάβασης διαφάνειας του HTML5. 
{{% /alert %}}

## **Εξαγωγή PowerPoint σε HTML5 Προβολή Διαφάνειας**

Το **Aspose.Slides** σας επιτρέπει να μετατρέψετε μια παρουσίαση PowerPoint σε ένα έγγραφο HTML5 στο οποίο οι διαφάνειες παρουσιάζονται σε λειτουργία προβολής διαφάνειας. Σε αυτήν την περίπτωση, όταν ανοίξετε το παραγόμενο αρχείο HTML5 σε έναν φυλλομετρητή, θα δείτε την παρουσίαση σε λειτουργία προβολής διαφάνειας σε μια ιστοσελίδα.

Αυτός ο κώδικας Python παρουσιάζει τη διαδικασία εξαγωγής PowerPoint σε HTML5 Προβολή Διαφάνειας:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Μετατροπή Παρουσιάσεων σε Έγγραφα HTML5 με Σχόλια**

Τα σχόλια στο PowerPoint είναι ένα εργαλείο που επιτρέπει στους χρήστες να αφήνουν σημειώσεις ή ανατροφοδότηση σε διαφάνειες της παρουσίασης. Είναι ιδιαίτερα χρήσιμα σε συνεργατικά έργα, όπου πολλοί άνθρωποι μπορούν να προσθέσουν προτάσεις ή παρατηρήσεις σε συγκεκριμένα στοιχεία της διαφάνειας χωρίς να μεταβάλουν το κύριο περιεχόμενο. Κάθε σχόλιο εμφανίζει το όνομα του συγγραφέα, καθιστώντας εύκολο τον εντοπισμό του ποιος άφησε το σχόλιο.

Ας υποθέσουμε ότι έχουμε την παρακάτω παρουσίαση PowerPoint αποθηκευμένη στο αρχείο "sample.pptx".

![Δύο σχόλια στη διαφάνεια της παρουσίασης](two_comments_pptx.png)

Όταν μετατρέπετε μια παρουσίαση PowerPoint σε έγγραφο HTML5, μπορείτε εύκολα να ορίσετε αν θα συμπεριλάβετε σχόλια από την παρουσίαση στο έγγραφο εξόδου. Για να το κάνετε αυτό, περάστε τις παραμέτρους εμφάνισης των σχολίων στη μέθοδο [setSlidesLayoutOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) της κλάσης [Html5Options](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/) .

Χρησιμοποιήστε [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/) και [setCommentsPosition](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) με [CommentsPositions.Right](https://reference.aspose.com/slides/el/python-java/aspose.slides/commentspositions/#Right). Το παρακάτω παράδειγμα κώδικα μετατρέπει μια παρουσίαση σε έγγραφο HTML5 με τα σχόλια να εμφανίζονται δεξιά των διαφανειών.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Το έγγραφο "output.html" φαίνεται στην παρακάτω εικόνα.

![Τα σχόλια στο παραγόμενο έγγραφο HTML5](two_comments_html5.png)

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω αν οι κινήσεις αντικειμένων και οι μεταβάσεις διαφανειών θα παιχτούν σε HTML5;**

Ναι, το HTML5 παρέχει ξεχωριστές επιλογές για την ενεργοποίηση ή απενεργοποίηση των [shape animations](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/#setAnimateShapes) και των [slide transitions](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/#setAnimateTransitions).

**Μπορούν τα σχόλια να εξαχθούν, και πού μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;**

Ναι, τα σχόλια μπορούν να προστεθούν σε HTML5 και να τοποθετηθούν (για παράδειγμα, δεξιά της διαφάνειας) μέσω των [layout settings](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) για σημειώσεις και σχόλια.

**Μπορώ να παραλείψω συνδέσμους που καλούν JavaScript για λόγους ασφαλείας ή CSP;**

Ναι, υπάρχει μια [setting](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) που επιτρέπει το παράλειμμα των υπερσυνδέσμων με κλήσεις JavaScript κατά την αποθήκευση. Αυτό αφαιρεί τους εν λόγω υπερσυνδέσμους· δεν εγγυάται αυτόματα ότι όλα τα παραγόμενα σενάρια HTML5 τηρούν την Πολιτική Ασφάλειας Περιεχομένου (Content Security Policy) του ιστότοπου.