---
title: Βελτιώστε τις παρουσιάσεις PowerPoint με κινήσεις σε JavaScript
linktitle: Κίνηση PowerPoint
type: docs
weight: 150
url: /el/nodejs-java/powerpoint-animation/
keywords:
- προσθήκη κίνησης
- ενημέρωση κίνησης
- αλλαγή κίνησης
- αφαίρεση κίνησης
- διαχείριση κίνησης
- έλεγχος κίνησης
- εφέ κίνησης
- κίνηση PowerPoint
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
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides for Node.js via Java για τη διαχείριση των κινήσεων PowerPoint. Αυτό το επισκόπιο τονίζει τα βασικά χαρακτηριστικά και προσφέρει ιδέες για να βελτιώσετε τις παρουσιάσεις σας."
---
## **Εισαγωγή**

Καθώς οι παρουσιάσεις προορίζονται να παρουσιάζουν κάτι, η οπτική τους εμφάνιση και η διαδραστική τους συμπεριφορά λαμβάνονται πάντα υπόψη κατά τη δημιουργία.

**PowerPoint animation** παίζει σημαντικό ρόλο στο να κάνει μια παρουσίαση ελκυστική και ενδιαφέρουσα για το κοινό. Το Aspose.Slides for Node.js via Java παρέχει ευρύ φάσμα επιλογών για προσθήκη κινήσεων σε παρουσιάσεις PowerPoint:

- Εφαρμόζετε διάφορους τύπους εφέ κίνησης PowerPoint σε σχήματα, διαγράμματα, πίνακες, αντικείμενα OLE και άλλα στοιχεία παρουσίασης.
- Χρησιμοποιείτε πολλαπλά εφέ κίνησης PowerPoint σε ένα μόνο σχήμα.
- Εκμεταλλεύεστε τη γραμμή χρόνου κίνησης για να ελέγχετε τα εφέ κίνησης.
- Δημιουργείτε προσαρμοσμένες κινήσεις.

Στο Aspose.Slides for Node.js via Java, μπορούν να εφαρμοστούν διάφορα εφέ κίνησης σε σχήματα. Δεδομένου ότι κάθε στοιχείο σε μια διαφάνεια, συμπεριλαμβανομένου του κειμένου, των εικόνων, των αντικειμένων OLE και των πινάκων, θεωρείται σχήμα, τα εφέ κίνησης μπορούν να εφαρμοστούν σε οποιοδήποτε στοιχείο της διαφάνειας.

## **Εφέ Κίνησης**

Το Aspose.Slides υποστηρίζει **150+ εφέ κίνησης**, συμπεριλαμβανομένων των βασικών εφέ όπως Bounce, PathFootball και Zoom, καθώς και συγκεκριμένων εφέ όπως OLEObjectShow και OLEObjectOpen. Μπορείτε να βρείτε πλήρη λίστα στο [EffectType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effecttype/) enumeration.

Επιπλέον, αυτά τα εφέ κίνησης μπορούν να χρησιμοποιηθούν σε συνδυασμό με τις παρακάτω συμπεριφορές:

- [ColorEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SetEffect)

## **Προσαρμοσμένη Κίνηση**

Για πλήρη παραδείγματα JavaScript που δημιουργούν, επιθεωρούν και τροποποιούν συμπεριφορές και επεξεργάσιμες διαδρομές κίνησης, δείτε [Custom Animation](/slides/el/nodejs-java/custom-animation/).

Είναι δυνατόν να δημιουργήσετε τις δικές σας **προσαρμοσμένες κινήσεις** στο Aspose.Slides. Αυτό μπορεί να επιτευχθεί συνδυάζοντας πολλές συμπεριφορές σε μια νέα προσαρμοσμένη κίνηση.

[Behavior](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behavior/) είναι ένα δομικό στοιχείο ενός εφέ κίνησης PowerPoint. Συνδυάστε συμπεριφορές για να προσαρμόσετε ένα εφέ, ή προσθέστε μια συμπεριφορά για να επεκτείνετε ένα προκαθορισμένο εφέ. Η επανάληψη ρυθμίζεται μέσω των ρυθμίσεων χρόνου αντί για ξεχωριστή συμπεριφορά επανάληψης.

[Animation Point](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/point/) είναι ένα σημείο στο οποίο πρέπει να εφαρμοστεί μια συμπεριφορά.

## **Γραμμή Χρόνου Κίνησης**

[Sequence](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sequence/) είναι μια συλλογή εφέ κίνησης που μπορούν να στοχεύουν διαφορετικά σχήματα.

[Timeline](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/animationtimeline/) είναι ένα σύνολο ακολουθιών που χρησιμοποιείται σε μια συγκεκριμένη διαφάνεια. Είναι μια μηχανή κίνησης που παρουσιάστηκε στο PowerPoint 2002. Σε παλαιότερες εκδόσεις του PowerPoint, η προσθήκη εφέ κίνησης σε παρουσιάσεις ήταν δύσκολη και μπορούσε να επιτευχθεί μόνο με διάφορες εναλλακτικές λύσεις. Η γραμμή χρόνου παρέχει πιο σαφή μοντέλο αντικειμένου για τις κινήσεις του PowerPoint. Μια διαφάνεια μπορεί να έχει μόνο μία γραμμή χρόνου κίνησης.

## **Διαδραστική Κίνηση**

[Trigger](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effecttriggertype/) σας επιτρέπει να ορίσετε ενέργειες χρήστη, όπως κλικ σε κουμπί, που εκκινούν μια συγκεκριμένη κίνηση.

## **Κίνηση Σχήματος**

Το Aspose.Slides σας επιτρέπει να εφαρμόζετε κινήσεις σε σχήματα, τα οποία μπορούν να περιλαμβάνουν κείμενο, ορθογώνια, γραμμές, πλαίσια, αντικείμενα OLE και άλλα.

{{% alert color="info" title="Note" %}}
Διαβάστε περισσότερα [**Σχετικά με την Κίνηση Σχήματος**](/slides/el/nodejs-java/shape-animation/).
{{% /alert %}}

## **Κινούμενα Διαγράμματα**

Για να δημιουργήσετε κινούμενα διαγράμματα, θα πρέπει να χρησιμοποιήσετε τις ίδιες κλάσεις με αυτές για τα σχήματα. Ωστόσο, οι κινήσεις PowerPoint μπορούν να εφαρμοστούν μόνο σε κατηγορίες διαγράμματος ή σειρές διαγράμματος. Μπορείτε επίσης να εφαρμόσετε εφέ κίνησης σε ένα στοιχείο κατηγορίας ή σε ένα στοιχείο σειράς.

{{% alert color="info" title="Note" %}}
Διαβάστε περισσότερα [**Σχετικά με τα Κινούμενα Διαγράμματα**](/slides/el/nodejs-java/animated-charts/).
{{% /alert %}}

## **Κινούμενο Κείμενο**

Εκτός από την κίνηση κειμένου, μπορείτε να εφαρμόσετε κίνηση σε μια παράγραφο.

{{% alert color="info" title="Note" %}}
Διαβάστε περισσότερα [**Σχετικά με το Κινούμενο Κείμενο**](/slides/el/nodejs-java/animated-text/).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Θα διατηρηθούν οι κινήσεις κατά την εξαγωγή σε PDF;**

Όχι. Το PDF είναι μορφή στατική, έτσι οι κινήσεις και οι [slide transitions](/slides/el/nodejs-java/slide-transition/) δεν εκτελούνται. Εάν χρειάζεστε κίνηση, εξάγετε σε [HTML5](/slides/el/nodejs-java/export-to-html5/), [animated GIF](/slides/el/nodejs-java/convert-powerpoint-to-animated-gif/), ή [video](/slides/el/nodejs-java/convert-powerpoint-to-video/) αντί.

**Μπορώ να μετατρέψω μια κινούμενη παρουσίαση σε βίντεο και να ελέγξω το ρυθμό καρέ και το μέγεθος καρέ;**

Ναι. Μπορείτε να [render the presentation as frames](/slides/el/nodejs-java/convert-powerpoint-to-video/) και να τα κωδικοποιήσετε σε βίντεο (π.χ., μέσω ffmpeg), επιλέγοντας το FPS και την ανάλυση. Οι κινήσεις και οι μεταβάσεις διαφανειών αναπαράγονται κατά τη διαδικασία απόδοσης.

**Θα παραμείνουν αμετάβλητες οι κινήσεις κατά την εργασία με ODP (και όχι μόνο PPTX);**

Τα PPT, PPTX και ODP υποστηρίζονται για [reading](/slides/el/nodejs-java/open-presentation/) και [writing](/slides/el/nodejs-java/save-presentation/), αλλά αυτό δεν εγγυάται τη διατήρηση των κινήσεων. Τα δεδομένα προσαρμοσμένης κίνησης μπορούν να χαθούν κατά τη μετατροπή σε ODP. Δείτε το [Custom Animation](/slides/el/nodejs-java/custom-animation/) για παραδείγματα και οδηγίες ελέγχου συμβατότητας μορφής.