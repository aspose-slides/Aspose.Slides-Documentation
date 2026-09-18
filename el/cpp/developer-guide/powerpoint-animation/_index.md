---
title: "Βελτιώστε τις παρουσιάσεις PowerPoint με κινήσεις σε C++"
linktitle: "Κίνηση PowerPoint"
type: docs
weight: 150
url: /el/cpp/powerpoint-animation/
keywords:
- προσθήκη κίνησης
- ενημέρωση κίνησης
- αλλαγή κίνησης
- αφαίρεση κίνησης
- διαχείριση κίνησης
- έλεγχος κίνησης
- εφέ κίνησης
- κίνηση PowerPoint
- χρονογραμμή κίνησης
- διαδραστική κίνηση
- προσαρμοσμένη κίνηση
- κίνηση σχήματος
- διάγραμμα με κίνηση
- κείμενο με κίνηση
- σχήμα με κίνηση
- αντικείμενο OLE με κίνηση
- εικόνα με κίνηση
- πίνακας με κίνηση
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να ελέγχετε προχωρημένα εφέ κίνησης στην Aspose.Slides για C++ ώστε να δημιουργείτε δυναμικές παρουσιάσεις PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Δεδομένου ότι οι παρουσιάσεις προορίζονται να παρουσιάζουν κάτι, η οπτική τους εμφάνιση και η διαδραστική συμπεριφορά λαμβάνονται πάντα υπόψη κατά τη δημιουργία.

**PowerPoint animation** παίζει σημαντικό ρόλο στο να κάνει μια παρουσίαση ελκυστική και ενδιαφέρουσα για τους θεατές. Η Aspose.Slides παρέχει μια ευρεία γκάμα επιλογών για την προσθήκη κινήσεων σε παρουσιάσεις PowerPoint:

- Εφαρμόζετε διάφορους τύπους εφέ κίνησης PowerPoint σε σχήματα, διαγράμματα, πίνακες, αντικείμενα OLE και άλλα στοιχεία παρουσίασης.
- Χρησιμοποιείτε πολλαπλά εφέ κίνησης PowerPoint σε ένα μόνο σχήμα.
- Χρησιμοποιείτε τη χρονογραμμή κίνησης για να ελέγχετε τα εφέ κίνησης.
- Δημιουργείτε προσαρμοσμένες κινήσεις.

Στην Aspose.Slides, μπορούν να εφαρμοστούν διάφορα εφέ κίνησης σε σχήματα. Δεδομένου ότι κάθε στοιχείο σε μια διαφάνεια, συμπεριλαμβανομένου του κειμένου, των εικόνων, των αντικειμένων OLE και των πινάκων, θεωρείται σχήμα, τα εφέ κίνησης μπορούν να εφαρμοστούν σε οποιοδήποτε στοιχείο της διαφάνειας.

Ο χώρος ονομάτων [Aspose::Slides::Animation](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/) παρέχει κλάσεις για εργασία με κινήσεις PowerPoint.

## **Εφέ Κίνησης**

Η Aspose.Slides υποστηρίζει **150+ εφέ κίνησης**, συμπεριλαμβανομένων βασικών εφέ όπως Bounce, PathFootball και Zoom, καθώς και συγκεκριμένων εφέ όπως OLEObjectShow και OLEObjectOpen. Μπορείτε να βρείτε μια πλήρη λίστα στην απαρίθμηση [EffectType](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/effecttype/).

Επιπλέον, αυτά τα εφέ κίνησης μπορούν να χρησιμοποιηθούν σε συνδυασμό με τις ακόλουθες συμπεριφορές:

- [ColorEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/seteffect/)

## **Προσαρμοσμένη Κίνηση**

Για πλήρη παραδείγματα C++ που δημιουργούν, επιθεωρούν και τροποποιούν συμπεριφορές και επεξεργάσιμες διαδρομές κίνησης, δείτε [Custom Animation](/slides/el/cpp/custom-animation/).

Είναι δυνατόν να δημιουργήσετε τις δικές σας **προσαρμοσμένες κινήσεις** στην Aspose.Slides. Αυτό μπορεί να επιτευχθεί συνδυάζοντας αρκετές συμπεριφορές σε μια νέα προσαρμοσμένη κίνηση.

[Behavior](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/behavior/) είναι ένα δομικό στοιχείο ενός εφέ κίνησης PowerPoint. Συνδυάστε συμπεριφορές για να προσαρμόσετε ένα εφέ ή προσθέστε μια συμπεριφορά για να επεκτείνετε ένα προ-ορισμένο εφέ. Η επανάληψη ρυθμίζεται μέσω των ρυθμίσεων χρονομέτρησης και όχι μέσω ξεχωριστής συμπεριφοράς επανάληψης.

[Animation Point](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/point/) είναι ένα σημείο στο οποίο πρέπει να εφαρμοστεί μια συμπεριφορά.

## **Χρονογραμμή Κίνησης**

[Sequence](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/sequence/) είναι μια συλλογή εφέ κίνησης που μπορούν να στοχεύσουν διαφορετικά σχήματα.

[IAnimationTimeLine](https://reference.aspose.com/slides/el/cpp/aspose.slides/ianimationtimeline/) είναι ένα σύνολο ακολουθιών που χρησιμοποιείται σε μια συγκεκριμένη διαφάνεια. Είναι μια μηχανή κίνησης που εισήχθη στο PowerPoint 2002. Σε προηγούμενες εκδόσεις του PowerPoint, η προσθήκη εφέ κίνησης σε παρουσιάσεις ήταν δύσκολη και μπορούσε να επιτευχθεί μόνο με διάφορες παρακάμπτες λύσεις. Η χρονογραμμή παρέχει ένα πιο σαφές μοντέλο αντικειμένων για τις κινήσεις PowerPoint. Μια διαφάνεια μπορεί να έχει μόνο μία χρονογραμμή κίνησης.

## **Διαδραστική Κίνηση**

[Trigger](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/effecttriggertype/) σας επιτρέπει να ορίσετε ενέργειες χρήστη, όπως κλικ σε κουμπί, που εκκινούν μια συγκεκριμένη κίνηση.

## **Κίνηση Σχήματος**

Η Aspose.Slides σας επιτρέπει να εφαρμόζετε κινήσεις σε σχήματα, τα οποία μπορούν να περιλαμβάνουν κείμενο, ορθογώνια, γραμμές, πλαίσια, αντικείμενα OLE και άλλα.

{{% alert color="info" title="Note" %}}
Διαβάστε περισσότερα [**Σχετικά με την Κίνηση Σχήματος**](/slides/el/cpp/shape-animation/).
{{% /alert %}}

## **Διαγράμματα με Κίνηση**

Για να δημιουργήσετε διαγράμματα με κίνηση, πρέπει να χρησιμοποιήσετε τις ίδιες κλάσεις όπως για σχήματα. Ωστόσο, οι κινήσεις PowerPoint μπορούν να εφαρμοστούν μόνο σε κατηγορίες διαγράμματος ή σειρές διαγράμματος. Μπορείτε επίσης να εφαρμόσετε εφέ κίνησης σε ένα στοιχείο κατηγορίας ή σε ένα στοιχείο σειράς.

{{% alert color="info" title="Note" %}}
Διαβάστε περισσότερα [**Σχετικά με τα Διαγράμματα με Κίνηση**](/slides/el/cpp/animated-charts/).
{{% /alert %}}

## **Κείμενο με Κίνηση**

Εκτός από την κίνηση κειμένου, μπορείτε να εφαρμόσετε κίνηση σε μια παράγραφο.

{{% alert color="info" title="Note" %}}
Διαβάστε περισσότερα [**Σχετικά με το Κείμενο με Κίνηση**](/slides/el/cpp/animated-text/).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Θα διατηρηθούν οι κινήσεις κατά την εξαγωγή σε PDF;**

Όχι. Το PDF είναι μια στατική μορφή, έτσι οι κινήσεις και οι [slide transitions](/slides/el/cpp/slide-transition/) δεν εκτελούνται. Αν χρειάζεστε κίνηση, εξάγετε σε [HTML5](/slides/el/cpp/export-to-html5/), [animated GIF](/slides/el/cpp/convert-powerpoint-to-animated-gif/) ή [video](/slides/el/cpp/convert-powerpoint-to-video/) αντί.

**Μπορώ να μετατρέψω μια παρουσίαση με κίνηση σε βίντεο και να ελέγξω το ρυθμό καρέ και το μέγεθος του καρέ;**

Ναι. Μπορείτε να [render the presentation as frames](/slides/el/cpp/convert-powerpoint-to-video/) και να τα κωδικοποιήσετε σε βίντεο (π.χ., μέσω ffmpeg), επιλέγοντας τα FPS και την ανάλυση. Οι κινήσεις και οι μεταβάσεις διαφάνειας εκτελούνται κατά τη διαδικασία απόδοσης.

**Θα παραμείνουν οι κινήσεις αμετάβλητες όταν εργάζεστε με ODP (όχι μόνο PPTX);**

Τα PPT, PPTX και ODP υποστηρίζονται για [reading](/slides/el/cpp/open-presentation/) και [writing](/slides/el/cpp/save-presentation/), αλλά αυτό δεν εγγυάται τη διατήρηση των κινήσεων. Τα δεδομένα προσαρμοσμένων κινήσεων μπορεί να χαθούν κατά τη μετατροπή σε ODP. Δείτε το [Custom Animation](/slides/el/cpp/custom-animation/) για παραδείγματα και οδηγίες σχετικά με τον έλεγχο της συμβατότητας μορφής.