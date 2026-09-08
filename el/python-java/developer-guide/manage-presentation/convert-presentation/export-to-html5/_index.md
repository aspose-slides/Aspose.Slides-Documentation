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
description: "Εξαγωγή παρουσιάσεων PowerPoint & OpenDocument σε προσαρμόσιμο HTML5 με Aspose.Slides για Python μέσω Java. Διατήρηση μορφοποίησης, κινήσεων και διαδραστικότητας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides. Καλύπτει τη βασική εξαγωγή HTML5 χωρίς πρόσθετες επεκτάσεις web, καθώς και επιλογές ελέγχου των κινήσεων σχήματος και των μεταβάσεων διαφάνειας. Το άρθρο δείχνει επίσης τη στάνταρ διαδικασία εξαγωγής PowerPoint σε HTML, εξηγεί πώς να δημιουργήσετε έξοδο HTML5 σε λειτουργία προβολής διαφάνειας και επιδεικνύει πώς να συμπεριλάβετε σχόλια στο εξαχθέν έγγραφο ρυθμίζοντας τη διάταξή τους.

## **Εξαγωγή PowerPoint σε HTML5**

Χρησιμοποιήστε [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) with [SaveFormat.Html5](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Html5) to export a presentation without additional web extensions:

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
Ο εξαγωγέας HTML5 δημιουργεί περιεχόμενο HTML για προβολή σε έναν περιηγητή. 
{{% /alert %}}

Χρησιμοποιήστε [Html5Options](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/) για να ρυθμίσετε την εξαγωγή. Καλέστε [setAnimateShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/#setAnimateShapes) και [setAnimateTransitions](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/#setAnimateTransitions) με `False` για να απενεργοποιήσετε τις κινήσεις σχήματος και τις μεταβάσεις διαφάνειας:

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

Χρησιμοποιήστε [SaveFormat.Html](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Html) για τυπική εξαγωγή HTML. Δείτε [Convert PowerPoint to HTML](/slides/el/python-java/convert-powerpoint-to-html/) για περισσότερες επιλογές:

```python
import jpime
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

Σε αυτήν την περίπτωση, το περιεχόμενο της παρουσίασης αποδίδεται μέσω SVG με μορφή όπως αυτή:

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
Η τυπική εξαγωγή HTML αποδίδει το περιεχόμενο των διαφανειών μέσω SVG και δεν παρέχει τις επιλογές κίνησης σχήματος και μεταβάσεων διαφάνειας του HTML5. 
{{% /alert %}}

## **Εξαγωγή PowerPoint σε προβολή διαφανειών HTML5**

Το **Aspose.Slides** σας επιτρέπει να μετατρέψετε μια παρουσίαση PowerPoint σε ένα έγγραφο HTML5 στο οποίο οι διαφάνειες παρουσιάζονται σε λειτουργία προβολής διαφανειών. Σε αυτήν την περίπτωση, όταν ανοίγετε το παραγόμενο αρχείο HTML5 σε έναν περιηγητή, βλέπετε την παρουσίαση σε λειτουργία προβολής διαφανειών σε μια ιστοσελίδα.

Αυτός ο κώδικας Python δείχνει τη διαδικασία εξαγωγής PowerPoint σε προβολή διαφανειών HTML5:

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

## **Μετατροπή παρουσιάσεων σε έγγραφα HTML5 με σχόλια**

Τα σχόλια στο PowerPoint είναι ένα εργαλείο που επιτρέπει στους χρήστες να αφήνουν σημειώσεις ή ανάδραση στις διαφάνειες της παρουσίασης. Είναι ιδιαίτερα χρήσιμα σε συνεργατικά έργα, όπου πολλοί άνθρωποι μπορούν να προσθέσουν προτάσεις ή παρατηρήσεις σε συγκεκριμένα στοιχεία της διαφάνειας χωρίς να τροποποιούν το κύριο περιεχόμενο. Κάθε σχόλιο εμφανίζει το όνομα του συγγραφέα, διευκολύνοντας την παρακολούθηση του ποιος άφησε την παρατήρηση.

Ας πούμε ότι διαθέτουμε την παρακάτω παρουσίαση PowerPoint αποθηκευμένη στο αρχείο "sample.pptx".

![Δύο σχόλια στη διαφάνεια της παρουσίασης](two_comments_pptx.png)

Όταν μετατρέπετε μια παρουσίαση PowerPoint σε έγγραφο HTML5, μπορείτε εύκολα να καθορίσετε εάν θα συμπεριλάβετε τα σχόλια της παρουσίασης στο τελικό έγγραφο. Για να το κάνετε αυτό, περάστε τις παραμέτρους εμφάνισης των σχολίων στην μέθοδο [setSlidesLayoutOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) της κλάσης [Html5Options](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/).

Χρησιμοποιήστε [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/) και [setCommentsPosition](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) μαζί με [CommentsPositions.Right](https://reference.aspose.com/slides/el/python-java/aspose.slides/commentspositions/#Right). Το παρακάτω παράδειγμα κώδικα μετατρέπει μια παρουσίαση σε έγγραφο HTML5 με τα σχόλια να εμφανίζονται προς τα δεξιά των διαφανειών.

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

Το έγγραφο "output.html" εμφανίζεται στην εικόνα παρακάτω.

![Τα σχόλια στο τελικό έγγραφο HTML5](two_comments_html5.png)

## **Συχνές ερωτήσεις**

**Μπορώ να ελέγξω αν οι κινήσεις αντικειμένων και οι μεταβάσεις διαφανειών θα αναπαραχθούν σε HTML5;**

Ναι, το HTML5 παρέχει ξεχωριστές επιλογές για την ενεργοποίηση ή απενεργοποίηση των [shape animations](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/#setAnimateShapes) και των [slide transitions](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/#setAnimateTransitions).

**Υποστηρίζεται η έξοδος σχολίων και πού μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;**

Ναι, τα σχόλια μπορούν να προστεθούν σε HTML5 και να τοποθετηθούν (π.χ., προς τα δεξιά της διαφάνειας) μέσω των [layout settings](https://reference.aspose.com/slides/el/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) για σημειώσεις και σχόλια.

**Μπορώ να παραλείψω συνδέσμους που εκτελούν JavaScript για λόγους ασφαλείας ή CSP;**

Ναι, υπάρχει μια [ρύθμιση](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) που σας επιτρέπει να παραλείψετε υπερσυνδέσμους με κλήσεις JavaScript κατά την αποθήκευση. Αυτό αφαιρεί αυτούς τους υπερσυνδέσμους· δεν εγγυάται από μόνο του ότι όλα τα παραγόμενα σενάρια HTML5 τηρούν την Πολιτική Ασφάλειας Περιεχομένου (CSP) του ιστότοπου.