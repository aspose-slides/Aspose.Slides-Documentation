---
title: Μετατροπή Παρουσιάσεων σε HTML5 σε Python
linktitle: Παρουσίαση σε HTML5
type: docs
weight: 40
url: /el/python-net/export-to-html5/
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
- Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint & OpenDocument σε ανταποκρίσιμο HTML5 με το Aspose.Slides για Python μέσω .NET. Διατηρεί τη μορφοποίηση, τις κινήσεις και την αλληλεπίδραση."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET. Καλύπτει τη βασική εξαγωγή, τον έλεγχο των κινήσεων σχήματος και των μεταβάσεων διαφάνειας, καθώς και τη διάταξη σχολίων. Επιπλέον, συγκρίνει την έξοδο HTML5 με την έξοδο βασισμένη σε SVG της τυπικής εξαγωγής HTML.

## **Εξαγωγή PowerPoint σε HTML5**

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση από τον τρέχοντα φάκελο και την αποθηκεύει σε μορφή HTML5. Χρησιμοποιεί τις προεπιλεγμένες ρυθμίσεις εξαγωγής· το επόμενο παράδειγμα δείχνει πώς να ελέγξετε ρητά την αναπαραγωγή των κινήσεων. Αντικαταστήστε τη διαδρομή εισόδου με τη διαδρομή της παρουσίασής σας.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Σημείωση" %}}
Εκτός από το έγγραφο HTML, η εξαγωγή γράφει υποστηρικτικά αρχεία CSS και JavaScript για το στυλ των διαφανειών, τις κινήσεις, τα εφέ και την πλοήγηση. Διατηρήστε αυτά τα αρχεία μαζί με το έγγραφο HTML όταν μετακινείτε ή δημοσιεύετε το αποτέλεσμα. Η παραγόμενη σελίδα φορτώνει επίσης το jQuery και το Anime.js από δημόσια CDNs· χωρίς αυτά, η πλοήγηση των διαφανειών και οι κινήσεις δεν λειτουργούν.
{{% /alert %}}

Για να εξαγάγετε χωρίς την αναπαραγωγή κινήσεων σχήματος ή μεταβάσεων διαφάνειας, ορίστε [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) και [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) σε `False` στο [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Αυτές οι ρυθμίσεις είναι ανεξάρτητες, έτσι μπορείτε να ενεργοποιήσετε τη μία ενώ απενεργοποιείτε την άλλη. Το παράδειγμα εξάγει την παρουσίαση με και τους δύο τύπους κινήσεων απενεργοποιημένους στη δημιουργημένη σελίδα.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Εξαγωγή PowerPoint σε HTML**

Η τυπική εξαγωγή HTML χρησιμοποιεί διαφορετική προσέγγιση απόδοσης: το περιεχόμενο της διαφάνειας απεικονίζεται ως SVG μέσα σε μια σελίδα HTML. Το παρακάτω παράδειγμα μετατρέπει μια παρουσίαση σε έγγραφο HTML χρησιμοποιώντας αυτήν την προσέγγιση απόδοσης.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

Η απλοποιημένη σήμανση παρακάτω απεικονίζει τη δομή της δημιουργημένης σελίδας. Το στοιχείο SVG περιέχει το αποδιδόμενο περιεχόμενο της διαφάνειας· το κείμενο αντικατάστασης αντιπροσωπεύει αυτό το περιεχόμενο και δεν αποτελεί κυριολεκτική έξοδο εξαγωγής.

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
Η εξαγωγή βασισμένη σε SVG δεν εκθέτει τα σχήματα PowerPoint ως ξεχωριστά στοιχεία HTML. Χρησιμοποιήστε την εξαγωγή HTML5 όταν χρειάζεστε τις επιλογές κίνησης σχήματος και μετάβασης διαφάνειας που παρουσιάζονται σε αυτό το άρθρο.
{{% /alert %}}

## **Εξαγωγή PowerPoint σε Προβολή Διαφάνειας HTML5**

Η εξαγωγή HTML5 παράγει μια σελίδα για προβολή και πλοήγηση των διαφανειών της παρουσίασης σε έναν περιηγητή. Αυτό το παράδειγμα ενεργοποιεί και τα [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) και [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) ώστε η εξαγόμενη προβολή διαφάνειας να μπορεί να αναπαράγει τα εφέ από την πηγαία παρουσίαση.

Χρησιμοποιήστε μια παρουσίαση που ήδη περιέχει κινήσεις σχήματος και μεταβάσεις διαφάνειας για να δείτε το αποτέλεσμα αυτών των ρυθμίσεων. Η ενεργοποίηση τους δεν προσθέτει νέα εφέ σε διαφάνειες που δεν έχουν. Μετά την εξαγωγή, ανοίξτε το δημιουργημένο έγγραφο HTML5 σε έναν περιηγητή με διαθέσιμα τα υποστηρικτικά αρχεία.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Μετατροπή Παρουσίασης σε Έγγραφο HTML5 με Σχόλια**

Μπορείτε να συμπεριλάβετε υπάρχοντα σχόλια διαφάνειας στην έξοδο HTML5 ώστε οι αναγνώστες να βλέπουν σχόλια μαζί με το περιεχόμενο της διαφάνειας. Το παράδειγμα σε αυτήν την ενότητα υποθέτει ότι η πηγαία παρουσίαση περιέχει σχόλια, όπως φαίνεται παρακάτω. Εξάγει αυτά τα σχόλια· δεν δημιουργεί νέα.

![Δύο σχόλια στη διαφάνεια παρουσίασης](two_comments_pptx.png)

Αντιστοιχίστε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) στην ιδιότητα [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) του [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Ορίστε το [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) σε `RIGHT` από την απαρίθμηση [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) για να τοποθετήσετε τα σχόλια στα δεξιά κάθε διαφάνειας.

Το παρακάτω παράδειγμα εξάγει την παρουσίαση σε HTML5 με αυτήν τη διάταξη σχολίων. Μια παρουσίαση χωρίς σχόλια δεν θα έχει κείμενο σχολίου για εμφάνιση.

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

![Τα σχόλια στο παραγόμενο έγγραφο HTML5](two_comments_html5.png)

## **Απόκρυψη Συνδέσμων JavaScript κατά την Εξαγωγή**

Έστω ότι το `hyperlinks.pptx` περιέχει κείμενο με σύνδεσμο `javascript:alert('Hello')` και έναν κανονικό σύνδεσμο `https://example.com/`. Για να αποκρύψετε τον σύνδεσμο JavaScript κατά την εξαγωγή, ορίστε το [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) σε `True`. Η προεπιλογή είναι `False`, έτσι αυτοί οι σύνδεσμοι δεν φιλτράρονται εκτός αν ενεργοποιήσετε την επιλογή.

Το παρακάτω παράδειγμα φορτώνει την παρουσίαση από τον τρέχοντα φάκελο και την εξάγει χρησιμοποιώντας το [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/):

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

Το εξαγόμενο αρχείο παραλείπει τον σύνδεσμο JavaScript ενώ διατηρεί το κείμενό του και τον κανονικό σύνδεσμο HTTPS. Η πηγαία παρουσίαση παραμένει αμετάβλητη.

Αυτή η επιλογή φιλτράρει συνδέσμους JavaScript· δεν αφαιρεί όλα τα σενάρια ή άλλο ενεργό περιεχόμενο, ούτε εγγυάται τη συμμόρφωση με CSP. Για παράδειγμα, η έξοδος HTML5 εξακολουθεί να περιλαμβάνει σενάρια για την πλοήγηση των διαφανών και τις κινήσεις.

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω αν οι κινήσεις αντικειμένων και οι μεταβάσεις διαφάνειας θα αναπαράγονται σε HTML5;**

Ναι, η εξαγωγή HTML5 παρέχει ξεχωριστές επιλογές για την ενεργοποίηση ή απενεργοποίηση των [shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) και των [slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**Υποστηρίζονται τα σχόλια, και που μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;**

Ναι, τα υπάρχοντα σχόλια μπορούν να συμπεριληφθούν στην έξοδο HTML5 και να τοποθετηθούν (π.χ. στα δεξιά της διαφάνειας) μέσω των [layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) για σημειώσεις και σχόλια.

**Μπορώ να παραλείψω συνδέσμους που εκτελούν JavaScript για λόγους ασφαλείας ή CSP;**

Ναι, η ρύθμιση [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) σας επιτρέπει να παραλείψετε συνδέσμους με κλήσεις JavaScript κατά την αποθήκευση. Η προεπιλογή είναι `False`. Δείτε το [Exclude JavaScript Hyperlinks During Export](/slides/el/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) για ένα παράδειγμα εξαγωγής HTML5 και το εύρος του φίλτρου. Αυτή η ρύθμιση δεν αφαιρεί το JavaScript που χρησιμοποιεί ο προβολέας HTML5 για πλοήγηση και κινήσεις.