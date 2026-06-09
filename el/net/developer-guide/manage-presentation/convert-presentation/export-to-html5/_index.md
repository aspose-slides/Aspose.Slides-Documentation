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
description: "Εξαγωγή παρουσιάσεων PowerPoint & OpenDocument σε προσαρμοστικό HTML5 με το Aspose.Slides για .NET. Διατήρηση μορφοποίησης, αναπαραστάσεων και διαδραστικότητας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides. Καλύπτει τη βασική εξαγωγή σε HTML5 χωρίς web extensions ή πρόσθετες εξαρτήσεις, καθώς και επιλογές για έλεγχο των αναπαραστάσεων σχήματος και των μεταβάσεων διαφάνειας. Το άρθρο δείχνει επίσης τη στάνταρ διαδικασία εξαγωγής PowerPoint σε HTML, εξηγεί πώς να δημιουργήσετε έξοδο HTML5 σε λειτουργία προβολής διαφάνειας και επιδεικνύει πώς να συμπεριλάβετε σχόλια στο εξαγόμενο έγγραφο ρυθμίζοντας τη διάταξή τους.

## **Εξαγωγή PowerPoint σε HTML5**

Αυτός ο κώδικας C# δείχνει πώς να εξαγάγετε μια παρουσίαση σε HTML5 χωρίς web extensions και εξαρτήσεις:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}}Σε αυτήν την περίπτωση, λαμβάνετε καθαρό HTML.{{% /alert %}}

Μπορείτε να καθορίσετε ρυθμίσεις για τις αναπαραστάσεις σχήματος και τις μεταβάσεις διαφάνειας με τον siguiente τρόπο:

```c#
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

Αυτό το παράδειγμα C# παρουσιάζει τη στάνταρ διαδικασία εξαγωγής PowerPoint σε HTML:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

Σε αυτήν την περίπτωση, το περιεχόμενο της παρουσίασης αποδίδεται μέσω SVG με μορφή όπως η παρακάτω:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Σημείωση" color="warning" %}}Όταν χρησιμοποιείτε αυτή τη μέθοδο για εξαγωγή PowerPoint σε HTML, λόγω της απόδοσης SVG, δεν θα μπορείτε να εφαρμόσετε στυλ ή να δημιουργήσετε κινούμενα στοιχεία.{{% /alert %}}

## **Εξαγωγή PowerPoint σε HTML5 προβολή διαφάνειας**

**Aspose.Slides** επιτρέπει τη μετατροπή μιας παρουσίασης PowerPoint σε έγγραφο HTML5 όπου οι διαφάνειες παρουσιάζονται σε λειτουργία προβολής διαφάνειας. Σε αυτήν την περίπτωση, όταν ανοίγετε το παραγόμενο αρχείο HTML5 σε έναν φυλλομετρητή, βλέπετε την παρουσίαση σε λειτουργία προβολής διαφάνειας σε μια ιστοσελίδα.

Αυτός ο κώδικας C# παρουσιάζει τη διαδικασία εξαγωγής PowerPoint σε HTML5 προβολή διαφάνειας:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **Μετατροπή παρουσίασης σε έγγραφο HTML5 με σχόλια**

Τα σχόλια στο PowerPoint είναι ένα εργαλείο που επιτρέπει στους χρήστες να αφήνουν σημειώσεις ή παρατηρήσεις στις διαφάνειες της παρουσίασης. Είναι ιδιαίτερα χρήσιμα σε συνεργατικά έργα, όπου πολλοί μπορούν να προσθέσουν προτάσεις ή παρατηρήσεις σε συγκεκριμένα στοιχεία της διαφάνειας χωρίς να τροποποιήσουν το κύριο περιεχόμενο. Κάθε σχόλιο εμφανίζει το όνομα του συγγραφέα, καθιστώντας εύκολο τον εντοπισμό του ατόμου που το άφησε.

Ας υποθέσουμε ότι έχουμε την ακόλουθη παρουσίαση PowerPoint αποθηκευμένη στο αρχείο «sample.pptx».

![Δύο σχόλια στη διαφάνεια της παρουσίασης](two_comments_pptx.png)

Όταν μετατρέπετε μια παρουσίαση PowerPoint σε έγγραφο HTML5, μπορείτε εύκολα να καθορίσετε εάν θα συμπεριληφθούν τα σχόλια της παρουσίασης στο παραγόμενο έγγραφο. Για να το κάνετε αυτό, πρέπει να καθορίσετε τις παραμέτρους εμφάνισης για τα σχόλια στην ιδιότητα `NotesCommentsLayouting` της κλάσης [Html5Options](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/) .

Το παρακάτω παράδειγμα κώδικα μετατρέπει μια παρουσίαση σε έγγραφο HTML5 με τα σχόλια να εμφανίζονται στα δεξιά των διαφανειών.
```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Το έγγραφο «output.html» εμφανίζεται στην εικόνα παρακάτω.

![Τα σχόλια στο παραγόμενο έγγραφο HTML5](two_comments_html5.png)

## **Συχνές ερωτήσεις**

**Μπορώ να ελέγξω αν οι αναπαραστάσεις αντικειμένων και οι μεταβάσεις διαφάνειας θα εκτελεστούν σε HTML5;**

Ναι, το HTML5 παρέχει ξεχωριστές επιλογές για ενεργοποίηση ή απενεργοποίηση των [shape animations](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/animateshapes/) και των [slide transitions](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/animatetransitions/).

**Υποστηρίζεται η εξαγωγή σχολίων και πού μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;**

Ναι, τα σχόλια μπορούν να προστεθούν σε HTML5 και να τοποθετηθούν (για παράδειγμα, στα δεξιά της διαφάνειας) μέσω των [layout settings](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/notescommentslayouting/) για σημειώσεις και σχόλια.

**Μπορώ να παραλείψω συνδέσμους που καλούν JavaScript για λόγους ασφαλείας ή CSP;**

Ναι, υπάρχει ένα [setting](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) που σας επιτρέπει να παραλείψετε υπερσυνδέσμους με κλήσεις JavaScript κατά την αποθήκευση. Αυτό βοηθά στην τήρηση αυστηρών πολιτικών ασφαλείας.