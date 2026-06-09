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
- χρονοδιάγραμμα κίνησης
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
description: "Χρησιμοποιήστε το Aspose.Slides για Node.js μέσω Java για να διαχειριστείτε τις κινήσεις PowerPoint. Αυτή η επισκόπηση αναδεικνύει βασικά χαρακτηριστικά και προσφέρει πληροφορίες για τη βελτίωση των παρουσιάσεών σας."
---
## **Εισαγωγή**

Δεδομένου ότι οι παρουσιάσεις προορίζονται να παρουσιάσουν κάτι, η οπτική τους εμφάνιση και η διαδραστική συμπεριφορά λαμβάνονται πάντα υπόψη κατά τη δημιουργία τους.

**PowerPoint animation** παίζει σημαντικό ρόλο προκειμένου η παρουσίαση να είναι ελκυστική και εντυπωσιακή για τους θεατές. Το Aspose.Slides for Node.js μέσω Java προσφέρει ευρεία γκάμα επιλογών για την προσθήκη κίνησης σε παρουσίαση PowerPoint:

- εφαρμόζετε διάφορους τύπους εφέ κίνησης PowerPoint σε σχήματα, διαγράμματα, πίνακες, αντικείμενα OLE και άλλα στοιχεία παρουσίασης.
- χρησιμοποιήστε πολλαπλά εφέ κίνησης PowerPoint σε ένα σχήμα.
- χρησιμοποιήστε τη χρονική γραμμή κίνησης για να ελέγξετε τα εφέ κίνησης.
- δημιουργήστε προσαρμοσμένη κίνηση.

Στο Aspose.Slides for Node.js μέσω Java, μπορούν να εφαρμοσθούν διάφορα εφέ κίνησης στα σχήματα. Καθώς κάθε στοιχείο στη διαφάνεια, συμπεριλαμβανομένου του κειμένου, των εικόνων, του αντικειμένου OLE, του πίνακα κ.λπ., θεωρείται σχήμα, αυτό σημαίνει ότι μπορούμε να εφαρμόσουμε εφέ κίνησης σε κάθε στοιχείο μιας διαφάνειας.

## **Εφέ Κίνησης**
Το Aspose.Slides υποστηρίζει **150+ εφέ κίνησης**, συμπεριλαμβανομένων βασικών εφέ κίνησης όπως Bounce, PathFootball, εφέ Zoom και συγκεκριμένων εφέ κίνησης όπως OLEObjectShow, OLEObjectOpen. Μπορείτε να βρείτε έναν πλήρη κατάλογο των εφέ κίνησης στην απαρίθμηση [**EffectType**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effecttype/).

Επιπλέον, αυτά τα εφέ κίνησης μπορούν να χρησιμοποιηθούν σε συνδυασμό μεταξύ τους:

- [ColorEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SetEffect)

## **Προσαρμοσμένη Κίνηση**
Είναι δυνατόν να δημιουργήσετε τις δικές σας **προσαρμοσμένες κινήσεις** στο Aspose.Slides. Αυτό μπορεί να επιτευχθεί εάν συνδυάσετε πολλές συμπεριφορές μαζί σε μια νέα προσαρμοσμένη κίνηση.

[**Behavior**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Behavior) είναι η μονάδα κατασκευής κάθε εφέ κίνησης PowerPoint. Όλα τα εφέ κίνησης είναι στην πραγματικότητα ένα σύνολο συμπεριφορών που συντίθενται σε μία στρατηγική. Μπορείτε να συνδυάσετε συμπεριφορές σε μια προσαρμοσμένη κίνηση μία φορά και να την επαναχρησιμοποιήσετε σε άλλες παρουσιάσεις. Εάν προσθέσετε μια νέα συμπεριφορά σε ένα τυπικό εφέ κίνησης PowerPoint - θα γίνει μια άλλη προσαρμοσμένη κίνηση. Για παράδειγμα, μπορείτε να προσθέσετε συμπεριφορά επανάληψης σε μια κίνηση ώστε να επαναλαμβάνεται λίγες φορές.

[**Animation Point**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Point) είναι ένα σημείο όπου η συμπεριφορά πρέπει να εφαρμοστεί.

## **Γραμμή Χρόνου Κίνησης**
[**Sequence**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Sequence) είναι μια συλλογή εφέ κίνησης, εφαρμοσμένων σε ένα συγκεκριμένο σχήμα.

[**Timeline**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AnimationTimeLine) είναι ένα σύνολο Sequencing που χρησιμοποιείται σε μια συγκεκριμένη διαφάνεια. Είναι μια μηχανή κίνησης που υπάρχει από το PowerPoint 2002. Σε προηγούμενες εκδόσεις του PowerPoint, ήταν δύσκολο να προστεθούν εφέ κίνησης στην παρουσίαση, κάτι που μπορούσε να γίνει μόνο με διάφορες εναλλακτικές λύσεις. Η Timeline αντικαθιστά την παλαιότερη κλάση AnimationSettings και παρέχει πιο σαφές μοντέλο αντικειμένων για την κίνηση PowerPoint. Μια διαφάνεια μπορεί να έχει μόνο μία γραμμή χρόνου κίνησης.

## **Διαδραστική Κίνηση**
[**Trigger**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/EffectTriggerType) επιτρέπει την καθορισμό ενεργειών χρήστη (π.χ. κλικ κουμπιού), που θα ξεκινήσουν μια συγκεκριμένη κίνηση. Τα Triggers προστέθηκαν μόνο στη νεότερη έκδοση του PowerPoint.

## **Κίνηση Σχήματος**
Το Aspose.Slides επιτρέπει την εφαρμογή κίνησης σε σχήματα, τα οποία μπορεί να είναι κείμενο, ορθογώνιο, γραμμή, πλαίσιο, αντικείμενο OLE κ.λπ.

{{% alert color="primary" %}} 
Διαβάστε περισσότερα [**About Shape Animation**](/slides/el/nodejs-java/shape-animation/).
{{% /alert %}}

## **Κινούμενα Διαγράμματα**
Για να δημιουργήσετε κινούμενα διαγράμματα, πρέπει να χρησιμοποιήσετε όλες τις ίδιες κλάσεις όπως για τα σχήματα. Ωστόσο, είναι δυνατόν να χρησιμοποιήσετε κίνηση PowerPoint μόνο σε κατηγορίες διαγράμματος ή σειρές διαγράμματος. Μπορείτε επίσης να εφαρμόσετε εφέ κίνησης σε ένα στοιχείο κατηγορίας ή σε ένα στοιχείο σειράς.

{{% alert color="primary" %}} 
Διαβάστε περισσότερα [**About Animated Charts**](/slides/el/nodejs-java/animated-charts/).
{{% /alert %}}

## **Κινούμενο κείμενο**
Εκτός από το κινούμενο κείμενο, είναι επίσης δυνατό να εφαρμόσετε κίνηση σε μια παράγραφο.

{{% alert color="primary" %}} 
Διαβάστε περισσότερα [**About Animated Text**](/slides/el/nodejs-java/animated-text/).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Θα διατηρηθούν οι κινήσεις κατά την εξαγωγή σε PDF;**

Όχι. Το PDF είναι μια στατική μορφή, έτσι οι κινήσεις και οι [slide transitions](/slides/el/nodejs-java/slide-transition/) δεν εκτελούνται. Εάν χρειάζεστε κίνηση, εξάγετε σε [HTML5](/slides/el/nodejs-java/export-to-html5/), [animated GIF](/slides/el/nodejs-java/convert-powerpoint-to-animated-gif/) ή [video](/slides/el/nodejs-java/convert-powerpoint-to-video/) αντί αυτού.

**Μπορώ να μετατρέψω μια κινούμενη παρουσίαση σε βίντεο και να ελέγξω το ρυθμό καρέ και το μέγεθος του πλαισίου;**

Ναι. Μπορείτε να [render the presentation as frames](/slides/el/nodejs-java/convert-powerpoint-to-video/) και να τα κωδικοποιήσετε σε ένα βίντεο (π.χ., μέσω ffmpeg), επιλέγοντας το FPS και την ανάλυση. Οι κινήσεις και οι μεταβάσεις διαφάνειας εκτελούνται κατά την απόδοση.

**Θα διατηρηθούν οι κινήσεις όταν δουλεύουμε με ODP (όχι μόνο PPTX);**

Τα PPT, PPTX και ODP υποστηρίζονται για [reading](/slides/el/nodejs-java/open-presentation/) και [writing](/slides/el/nodejs-java/save-presentation/), αλλά οι διαφορές μορφής σημαίνουν ότι ορισμένα εφέ μπορεί να φαίνονται ή να λειτουργούν ελαφρώς διαφορετικά. Επαληθεύστε κρίσιμες περιπτώσεις με πραγματικά δείγματα.