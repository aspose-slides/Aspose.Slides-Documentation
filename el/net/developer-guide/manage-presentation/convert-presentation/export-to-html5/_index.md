---
title: Μετατροπή Παρουσιάσεων σε HTML5 στο .NET
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
description: "Εξαγωγή παρουσιάσεων PowerPoint & OpenDocument σε προσαρμόσιμο HTML5 με το Aspose.Slides για .NET. Διατήρηση μορφοποίησης, κινήσεων και διαδραστικότητας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides. Καλύπτει τη βασική εξαγωγή σε HTML5, καθώς και επιλογές για έλεγχο των κινήσεων σχήματος και των μεταβάσεων διαφάνειας. Το άρθρο επίσης παρουσιάζει τη στάνταρ διαδικασία εξαγωγής PowerPoint σε HTML, εξηγεί πώς να δημιουργήσετε έξοδο HTML5 σε λειτουργία προβολής διαφάνειας και δείχνει πώς να συμπεριλάβετε σχόλια στο εξαγόμενο έγγραφο ρυθμίζοντας τη διάταξή τους.

## **Εξαγωγή PowerPoint σε HTML5**

Αυτός ο κώδικας C# δείχνει πώς να εξάγετε μια παρουσίαση σε HTML5:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 
Εκτός από το έγγραφο HTML, η εξαγωγή γράφει τα υποστηρικτικά αρχεία που αναφέρει: `pres.css`, `master.css`, `animation.js`, `effects.js` και `navigation.js`. Η δημιουργημένη σελίδα επίσης φορτώνει το jQuery και το Anime.js από δημόσιες CDN· χωρίς αυτά, η πλοήγηση διαφάνειας και οι κινήσεις δεν λειτουργούν. 
{{% /alert %}}

Μπορείτε να καθορίσετε τις ρυθμίσεις για τις κινήσεις σχήματος και τις μεταβάσεις διαφάνειας με αυτόν τον τρόπο:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **Εξαγωγή PowerPoint σε HTML**

Αυτός ο κώδικας C# δείχνει τη στάνταρ διαδικασία εξαγωγής PowerPoint σε HTML:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
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

{{% alert title="Σημείωση" color="warning" %}} 
Όταν χρησιμοποιείτε αυτή τη μέθοδο για εξαγωγή PowerPoint σε HTML, λόγω της απόδοσης SVG, δεν θα μπορείτε να εφαρμόσετε στυλ ή να αναιρέσετε συγκεκριμένα στοιχεία. 
{{% /alert %}}

## **Εξαγωγή PowerPoint σε Προβολή Διαφάνειας HTML5**

**Aspose.Slides** σας επιτρέπει να μετατρέψετε μια παρουσίαση PowerPoint σε ένα έγγραφο HTML5 στο οποίο οι διαφάνειες προβλήνονται σε λειτουργία προβολής διαφάνειας. Σε αυτήν την περίπτωση, όταν ανοίγετε το παραγόμενο αρχείο HTML5 σε έναν περιηγητή, βλέπετε την παρουσίαση σε λειτουργία προβολής διαφάνειας σε μια ιστοσελίδα. 

Αυτός ο κώδικας C# δείχνει τη διαδικασία εξαγωγής PowerPoint σε Προβολή Διαφάνειας HTML5:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **Μετατροπή Παρουσίασης σε Έγγραφο HTML5 με Σχόλια**

Τα σχόλια στο PowerPoint είναι ένα εργαλείο που επιτρέπει στους χρήστες να αφήνουν σημειώσεις ή ανατροφοδότηση στις διαφάνειες της παρουσίασης. Είναι ιδιαίτερα χρήσιμα σε συνεργατικά έργα, όπου πολλοί μπορούν να προσθέσουν προτάσεις ή παρατηρήσεις σε συγκεκριμένα στοιχεία διαφάνειας χωρίς να αλλάξουν το κύριο περιεχόμενο. Κάθε σχόλιο εμφανίζει το όνομα του συγγραφέα, καθιστώντας εύκολο να εντοπιστεί ποιος άφησε την παρατήρηση.

Ας υποθέσουμε ότι έχουμε την ακόλουθη παρουσίαση PowerPoint αποθηκευμένη στο αρχείο "sample.pptx".

![Δύο σχόλια στη διαφάνεια της παρουσίασης](two_comments_pptx.png)

Όταν μετατρέπετε μια παρουσίαση PowerPoint σε έγγραφο HTML5, μπορείτε εύκολα να καθορίσετε αν θα συμπεριλάβετε τα σχόλια της παρουσίασης στο έγγραφο εξόδου. Για να το κάνετε αυτό, πρέπει να καθορίσετε τις παραμέτρους εμφάνισης των σχολίων στην ιδιότητα `NotesCommentsLayouting` της κλάσης [Html5Options](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/) .

Το παρακάτω παράδειγμα κώδικα μετατρέπει μια παρουσίαση σε έγγραφο HTML5 με τα σχόλια να εμφανίζονται στα δεξιά των διαφανειών.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Το έγγραφο "output.html" εμφανίζεται στην παρακάτω εικόνα.

![Τα σχόλια στο εξαγόμενο έγγραφο HTML5](two_comments_html5.png)

## **Συχνές Ερωτήσεις**

### Μπορώ να ελέγξω αν οι κινήσεις αντικειμένων και οι μεταβάσεις διαφάνειας θα εκτελεστούν στο HTML5;

Ναι, το HTML5 παρέχει ξεχωριστές επιλογές για ενεργοποίηση ή απενεργοποίηση των [shape animations](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/animateshapes/) και των [slide transitions](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/animatetransitions/).

### Υποστηρίζεται η εξαγωγή σχολίων, και πού μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;

Ναι, τα σχόλια μπορούν να προστεθούν σε HTML5 και να τοποθετηθούν (π.χ., στα δεξιά της διαφάνειας) μέσω των [layout settings](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/notescommentslayouting/) για σημειώσεις και σχόλια.

### Μπορώ να παραλείψω συνδέσμους που καλούν JavaScript για λόγους ασφαλείας ή CSP;

Ναί, υπάρχει μια [setting](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) που σας επιτρέπει να παραλείψετε υπερσυνδέσμους με κλήσεις JavaScript κατά την αποθήκευση. Αυτό βοηθά στη συμμόρφωση με αυστηρές πολιτικές ασφαλείας.