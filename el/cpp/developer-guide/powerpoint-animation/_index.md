---
title: Βελτιώστε τις παρουσιάσεις PowerPoint με κινήσεις σε C++
linktitle: Κίνηση PowerPoint
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
- χρονοδιάγραμμα κίνησης
- διαδραστική κίνηση
- προσαρμοσμένη κίνηση
- κίνηση σχήματος
- κινούμενο διάγραμμα
- κινούμενο κείμενο
- κινούμενο σχήμα
- κινούμενο αντικείμενο OLE
- κινούμενη εικόνα
- κινούμενος πίνακας
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να ελέγχετε προχωρημένα εφέ κίνησης στο Aspose.Slides για C++ για να δημιουργείτε δυναμικές παρουσιάσεις PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Δεδομένου ότι οι παρουσιάσεις προορίζονται να παρουσιάζουν κάτι, η οπτική τους εμφάνιση και η διαδραστική συμπεριφορά τους λαμβάνονται πάντα υπόψη κατά τη δημιουργία τους.

**PowerPoint animation** παίζει σημαντικό ρόλο ώστε η παρουσίαση να είναι εντυπωσιακή και ελκυστική για τους θεατές. Aspose.Slides for C++ προσφέρει ένα ευρύ φάσμα επιλογών για να **προσθέσετε κίνηση** σε παρουσίαση PowerPoint:

- Εφαρμόστε διάφορους τύπους εφέ κίνησης PowerPoint σε σχήματα, διαγράμματα, πίνακες, αντικείμενα OLE και άλλα στοιχεία της παρουσίασης.  
- Χρησιμοποιήστε πολλαπλά εφέ κίνησης PowerPoint σε ένα σχήμα.  
- Χρησιμοποιήστε τη γραμμή χρόνου κίνησης για να ελέγξετε τα εφέ κίνησης.  
- Δημιουργήστε προσαρμοσμένη κίνηση.

Στο Aspose.Slides for C++ μπορούν να εφαρμοστούν διάφορα εφέ κίνησης στα σχήματα. Καθώς κάθε στοιχείο στη διαφάνεια, συμπεριλαμβανομένου κειμένου, εικόνων, αντικειμένου OLE, πίνακα κ.λπ., θεωρείται σχήμα, σημαίνει ότι μπορούμε να εφαρμόσουμε εφέ κίνησης σε κάθε στοιχείο μιας διαφάνειας.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides.animation) **namespace** παρέχει κλάσεις για εργασία με τις κινούμενες παρουσιάσεις PowerPoint.

## **Εφέ Κίνησης**
Το Aspose.Slides υποστηρίζει **150+ εφέ κίνησης**, συμπεριλαμβανομένων βασικών εφέ όπως Bounce, PathFootball, εφέ Ζουμ και συγκεκριμένων εφέ όπως OLEObjectShow, OLEObjectOpen. Μπορείτε να βρείτε μια πλήρη λίστα των εφέ κίνησης στην [**EffectType**](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) αρίθμηση.

Επιπλέον, αυτά τα εφέ κίνησης μπορούν να χρησιμοποιηθούν σε συνδυασμό μεταξύ τους:

- [ColorEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.set_effect)

## **Προσαρμοσμένη Κίνηση**
Μπορείτε να δημιουργήσετε τις δικές σας **προσαρμοσμένες κινήσεις** στο Aspose.Slides. Αυτό μπορεί να επιτευχθεί εάν συνδυάσετε πολλές συμπεριφορές σε μια νέα προσαρμοσμένη κίνηση.

[**Behavior**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.behavior) είναι η δομική μονάδα κάθε εφέ κίνησης PowerPoint. Όλα τα εφέ κίνησης είναι στην πραγματικότητα ένα σύνολο συμπεριφορών που συντίθενται σε μία στρατηγική. Μπορείτε να συνδυάσετε συμπεριφορές σε μια προσαρμοσμένη κίνηση μία φορά και να την επαναχρησιμοποιήσετε σε άλλες παρουσιάσεις. Αν προσθέσετε μια νέα συμπεριφορά σε ένα τυπικό εφέ κίνησης PowerPoint, θα προκύψει μια άλλη προσαρμοσμένη κίνηση. Για παράδειγμα, μπορείτε να προσθέσετε συμπεριφορά επανάληψης σε μια κίνηση ώστε να επαναλαμβάνεται λίγες φορές.

[**Animation Point**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.point) είναι ένα σημείο όπου πρέπει να εφαρμοστεί η συμπεριφορά.

## **Γραμμή Χρόνου Κίνησης**
[**Sequence**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.sequence) είναι μια συλλογή εφέ κίνησης, εφαρμοσμένων σε ένα συγκεκριμένο σχήμα.

[**AnimationTimeLine**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.animation_time_line) είναι ένα σύνολο ακολουθιών (Sequences) που χρησιμοποιείται σε μια συγκεκριμένη διαφάνεια. Είναι ένας κινητήρας κίνησης που υλοποιήθηκε από το PowerPoint 2002. Σε προηγούμενες εκδόσεις του PowerPoint ήταν δύσκολο να προστεθούν εφέ κίνησης στην παρουσίαση, κάτι που μπορούσε να γίνει μόνο με διάφορες εναλλακτικές λύσεις. Η γραμμή χρόνου αντικαθιστά την παλιά κλάση AnimationSettings και παρέχει πιο σαφή μοντέλο αντικειμένων για την κίνηση PowerPoint. Μία διαφάνεια μπορεί να έχει μόνο μία γραμμή χρόνου κίνησης.

## **Διαδραστική Κίνηση**
[**EffectTriggerType**](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) επιτρέπει τον ορισμό ενεργειών χρήστη (π.χ. κλικ κουμπιού), που θα ξεκινήσουν μια συγκεκριμένη κίνηση. Οι ενεργοποιητές προστέθηκαν μόνο στην τελευταία έκδοση του PowerPoint.

## **Κίνηση Σχήματος**
Aspose.Slides επιτρέπει την εφαρμογή κίνησης σε σχήματα, τα οποία μπορεί στην πραγματικότητα να είναι κείμενο, ορθογώνιο, γραμμή, πλαίσιο, αντικείμενο OLE κ.λπ.

{{% alert color="primary" %}} 
Διαβάστε περισσότερα [**About Shape Animation**](/slides/el/cpp/shape-animation/).
{{% /alert %}}

## **Κινούμενα Διαγράμματα**
Για να δημιουργήσετε κινούμενα διαγράμματα, πρέπει να χρησιμοποιήσετε τις ίδιες κλάσεις όπως και για τα σχήματα. Ωστόσο, είναι δυνατόν να χρησιμοποιήσετε την κίνηση PowerPoint μόνο σε κατηγορίες ή σειρές διαγράμματος. Μπορείτε επίσης να εφαρμόσετε εφέ κίνησης σε ένα στοιχείο κατηγορίας ή σε ένα στοιχείο σειράς.

{{% alert color="primary" %}} 
Διαβάστε περισσότερα [**About Animated Charts**](/slides/el/cpp/animated-charts/).
{{% /alert %}}

## **Κινούμενο Κείμενο**
Εκτός από το κινούμενο κείμενο, είναι επίσης δυνατό να εφαρμόσετε κίνηση σε μια παράγραφο.

{{% alert color="primary" %}} 
Διαβάστε περισσότερα [**About Animated Text**](/slides/el/cpp/animated-text/).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Θα διατηρηθούν τα εφέ κίνησης κατά την εξαγωγή σε PDF;**

Όχι. Το PDF είναι στατικό φορμάτ, επομένως τα εφέ κίνησης και οι [μεταβάσεις διαφανειών](/slides/el/cpp/slide-transition/) δεν αναπαράγονται. Αν χρειάζεστε κίνηση, εξάγετε σε [HTML5](/slides/el/cpp/export-to-html5/), [animated GIF](/slides/el/cpp/convert-powerpoint-to-animated-gif/) ή [video](/slides/el/cpp/convert-powerpoint-to-video/) αντί για αυτό.

**Μπορώ να μετατρέψω μια κινούμενη παρουσίαση σε βίντεο και να ελέγξω το ρυθμό καρέ και το μέγεθος του καρέ;**

Ναι. Μπορείτε να [render the presentation as frames](/slides/el/cpp/convert-powerpoint-to-video/) και να τα κωδικοποιήσετε σε βίντεο (π.χ., μέσω ffmpeg), επιλέγοντας FPS και ανάλυση. Τα εφέ κίνησης και οι μεταβάσεις διαφανειών αναπαράγονται κατά τη διαδικασία rendering.

**Θα παραμείνουν αμετάβλητα τα εφέ κίνησης όταν δουλεύω με ODP (όχι μόνο PPTX);**

Τα PPT, PPTX και ODP υποστηρίζονται για [reading](/slides/el/cpp/open-presentation/) και [writing](/slides/el/cpp/save-presentation/), αλλά οι διαφορές μορφών σημαίνουν ότι ορισμένα εφέ μπορεί να εμφανίζονται ή να συμπεριφέρονται ελαφρώς διαφορετικά. Επικυρώστε κρίσιμες περιπτώσεις με πραγματικά δείγματα.