---
title: Βελτιώστε τις Παρουσιάσεις PowerPoint με Κινούμενα Σχέδια σε .NET
linktitle: Κίνηση PowerPoint
type: docs
weight: 150
url: /el/net/powerpoint-animation/
keywords:
- προσθήκη κίνησης
- ενημέρωση κίνησης
- αλλαγή κίνησης
- αφαίρεση κίνησης
- διαχείριση κίνησης
- έλεγχος κίνησης
- εφέ κίνησης
- Κίνηση PowerPoint
- γραμμή χρόνου κίνησης
- διαδραστική κίνηση
- προσαρμοσμένη κίνηση
- κίνηση σχήματος
- κινούμενο γράφημα
- κινούμενο κείμενο
- κινούμενο σχήμα
- κινούμενο αντικείμενο OLE
- κινούμενη εικόνα
- κινούμενος πίνακας
- παρουσίαση PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Εξερευνήστε τις δυνατότητες του Aspose.Slides για .NET στη διαχείριση κινήσεων PowerPoint. Αυτή η γενική επισκόπηση αναδεικνύει βασικά χαρακτηριστικά και προσφέρει ιδέες για τη βελτίωση των παρουσιάσεών σας."
---
## **Εισαγωγή**

Καθώς οι παρουσιάσεις προορίζονται να παρουσιάζουν κάτι, η οπτική τους εμφάνιση και η διαδραστική συμπεριφορά λαμβάνονται πάντα υπόψη κατά τη δημιουργία.

**PowerPoint animation** παίζει σημαντικό ρόλο στο να κάνει μια παρουσίαση ελκυστική και συναρπαστική για τους θεατές. Το Aspose.Slides for .NET παρέχει μια μεγάλη ποικιλία επιλογών για την προσθήκη κινούμενων σχεδίων σε παρουσιάσεις PowerPoint:

- Εφαρμόστε διάφορους τύπους εφέ κίνησης PowerPoint σε σχήματα, διαγράμματα, πίνακες, αντικείμενα OLE και άλλα στοιχεία παρουσίασης.
- Χρησιμοποιήστε πολλαπλά εφέ κίνησης PowerPoint σε ένα μόνο σχήμα.
- Χρησιμοποιήστε τη γραμμή χρόνου κίνησης για να ελέγξετε τα εφέ κίνησης.
- Δημιουργήστε προσαρμοσμένες κινήσεις.

Στο Aspose.Slides for .NET, μπορούν να εφαρμοστούν διάφορα εφέ κίνησης σε σχήματα. Δεδομένου ότι κάθε στοιχείο σε μια διαφάνεια, συμπεριλαμβανομένου του κειμένου, των εικόνων, των αντικειμένων OLE και των πινάκων, θεωρείται σχήμα, τα εφέ κίνησης μπορούν να εφαρμοστούν σε οποιοδήποτε στοιχείο της διαφάνειας.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/el/net/aspose.slides.animation/) namespace παρέχει κλάσεις για εργασία με κινήσεις PowerPoint.

## **Εφέ Κίνησης**

Το Aspose.Slides υποστηρίζει **150+ εφέ κίνησης**, συμπεριλαμβανομένων βασικών εφέ όπως Bounce, PathFootball και Zoom, καθώς και συγκεκριμένων όπως OLEObjectShow και OLEObjectOpen. Μπορείτε να βρείτε πλήρη λίστα των εφέ κίνησης στην αρίθμηση [EffectType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effecttype).

Επιπλέον, αυτά τα εφέ κίνησης μπορούν να χρησιμοποιηθούν σε συνδυασμό με τα παρακάτω:
- [ColorEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/seteffect)

## **Προσαρμοσμένες Κινήσεις**

Είναι δυνατόν να δημιουργήσετε τις δικές σας **προσαρμοσμένες κινήσεις** στο Aspose.Slides. Αυτό μπορεί να επιτευχθεί συνδυάζοντας πολλές συμπεριφορές σε μια νέα προσαρμοσμένη κίνηση.

[Behaviour](https://reference.aspose.com/slides/el/net/aspose.slides.animation/behavior) είναι το δομικό στοιχείο κάθε εφέ κίνησης PowerPoint. Όλα τα εφέ κίνησης είναι ουσιαστικά ένα σύνολο συμπεριφορών που συντίθενται σε μια στρατηγική. Μπορείτε να συνδυάσετε συμπεριφορές σε μια προσαρμοσμένη κίνηση μία φορά και να την επαναχρησιμοποιήσετε σε άλλες παρουσιάσεις. Εάν προσθέσετε μια νέα συμπεριφορά σε ένα τυπικό εφέ κίνησης PowerPoint, θα γίνει μια άλλη προσαρμοσμένη κίνηση. Για παράδειγμα, μπορείτε να προσθέσετε μια συμπεριφορά επανάληψης σε μια κίνηση ώστε να επαναλαμβάνεται μερικές φορές.

[Animation Point](https://reference.aspose.com/slides/el/net/aspose.slides.animation/point) είναι ένα σημείο στο οποίο πρέπει να εφαρμοστεί μια συμπεριφορά.

## **Γραμμή Χρόνου Κίνησης**

[Sequence](https://reference.aspose.com/slides/el/net/aspose.slides.animation/sequence) είναι μια συλλογή εφέ κίνησης που εφαρμόζονται σε ένα συγκεκριμένο σχήμα.

[Timeline](https://reference.aspose.com/slides/el/net/aspose.slides.animation/animationtimeline) είναι ένα σύνολο ακολουθιών που χρησιμοποιείται σε μια συγκεκριμένη διαφάνεια. Είναι ένας μηχανισμός κίνησης που εισήχθη στο PowerPoint 2002. Σε προηγούμενες εκδόσεις του PowerPoint, η προσθήκη εφέ κίνησης σε παρουσιάσεις ήταν δύσκολη και μπορούσε να επιτευχθεί μόνο με διάφορες λύσεις. Η γραμμή χρόνου αντικαθιστά την παλιά κλάση AnimationSettings και παρέχει ένα πιο σαφή μοντέλο αντικειμένων για τις κινήσεις PowerPoint. Μια διαφάνεια μπορεί να έχει μόνο μία γραμμή χρόνου κίνησης.

## **Διαδραστική Κίνηση**

[Trigger](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effecttriggertype) σας επιτρέπει να ορίσετε ενέργειες χρήστη (π.χ., κλικ σε κουμπί) που θα ενεργοποιήσουν μια συγκεκριμένη κίνηση. Τα triggers εισήχθησαν στην πιο πρόσφατη έκδοση του PowerPoint.

## **Κίνηση Σχήματος**

Το Aspose.Slides σας επιτρέπει να εφαρμόζετε κινήσεις σε σχήματα, τα οποία μπορούν να περιλαμβάνουν κείμενο, ορθογώνια, γραμμές, πλαίσια, αντικείμενα OLE και άλλα.

{{% alert color="info" %}} 
Διαβάστε περισσότερα [**Σχετικά με την Κίνηση Σχήματος**](/slides/el/net/shape-animation/).
{{% /alert %}}

## **Κινούμενα Διαγράμματα**

Για να δημιουργήσετε κινούμενα διαγράμματα, πρέπει να χρησιμοποιήσετε τις ίδιες κλάσεις όπως για τα σχήματα. Ωστόσο, οι κινήσεις PowerPoint μπορούν να εφαρμοστούν μόνο σε κατηγορίες διαγράμματος ή σειρές διαγράμματος. Μπορείτε επίσης να εφαρμόσετε εφέ κίνησης σε ένα στοιχείο κατηγορίας ή σε ένα στοιχείο σειράς.

{{% alert color="info" %}} 
Διαβάστε περισσότερα [**Σχετικά με τα Κινούμενα Διαγράμματα**](/slides/el/net/animated-charts/).
{{% /alert %}}

## **Κινούμενο Κείμενο**

Εκτός από το κινούμενο κείμενο, είναι επίσης δυνατό να εφαρμόσετε κίνηση σε μια παράγραφο.

{{% alert color="info" %}} 
Διαβάστε περισσότερα [**Σχετικά με το Κινούμενο Κείμενο**](/slides/el/net/animated-text/).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

### Θα διατηρηθούν οι κινήσεις κατά την εξαγωγή σε PDF;

Όχι. Το PDF είναι μορφή στατική, επομένως οι κινήσεις και οι [slide transitions](/slides/el/net/slide-transition/) δεν παίζουν. Εάν χρειάζεστε κίνηση, εξάγετε σε [HTML5](/slides/el/net/export-to-html5/), [animated GIF](/slides/el/net/convert-powerpoint-to-animated-gif/), ή [video](/slides/el/net/convert-powerpoint-to-video/) αντ' αυτού.

### Μπορώ να μετατρέψω μια κινούμενη παρουσίαση σε βίντεο και να ελέγξω το ρυθμό καρέ και το μέγεθος του καρέ;

Ναι. Μπορείτε να [render the presentation as frames](/slides/el/net/convert-powerpoint-to-video/) και να τα κωδικοποιήσετε σε βίντεο (π.χ., μέσω ffmpeg), επιλέγοντας τα FPS και την ανάλυση. Οι κινήσεις και οι μεταβάσεις διαφάνειας παίζονται κατά την απόδοση.

### Θα παραμείνουν οι κινήσεις αμετάβλητες κατά την εργασία με ODP (όχι μόνο PPTX);

Το PPT, PPTX και ODP υποστηρίζονται για [reading](/slides/el/net/open-presentation/) και [writing](/slides/el/net/save-presentation/), αλλά οι διαφορές μορφοποίησης σημαίνουν ότι ορισμένα εφέ μπορεί να εμφανίζονται ή να συμπεριφέρονται ελαφρώς διαφορετικά. Επικυρώστε κρίσιμες περιπτώσεις με πραγματικά δείγματα.