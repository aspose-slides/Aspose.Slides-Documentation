---
title: Βελτιώστε τις παρουσιάσεις PowerPoint με animation σε C++
linktitle: Animation PowerPoint
type: docs
weight: 150
url: /el/cpp/powerpoint-animation/
keywords:
- προσθήκη animation
- ενημέρωση animation
- αλλαγή animation
- αφαίρεση animation
- διαχείριση animation
- έλεγχος animation
- εφέ animation
- animation PowerPoint
- animation timeline
- διαδραστικό animation
- προσαρμοσμένο animation
- animation σχήματος
- animation γραφήματος
- animation κειμένου
- animation σχήματος
- animation αντικειμένου OLE
- animation εικόνας
- animation πίνακα
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να ελέγχετε προχωρημένα εφέ animation στο Aspose.Slides για C++ ώστε να δημιουργείτε δυναμικές παρουσιάσεις PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Καθώς οι παρουσιάσεις προορίζονται να παρουσιάζουν κάτι, η οπτική τους εμφάνιση και η διαδραστική συμπεριφορά λαμβάνονται πάντα υπόψη κατά τη δημιουργία τους.

**PowerPoint animation** παίζει σημαντικό ρόλο ώστε η παρουσίαση να είναι εντυπωσιακή και ελκυστική για τους θεατές. Aspose.Slides for C++ προσφέρει μια ευρεία γκάμα επιλογών για την προσθήκη animation σε παρουσίαση PowerPoint:

- εφαρμόστε διάφορους τύπους εφέ animation PowerPoint σε σχήματα, γραφήματα, πίνακες, αντικείμενα OLE και άλλα στοιχεία της παρουσίασης.
- χρησιμοποιήστε πολλαπλά εφέ animation PowerPoint σε ένα σχήμα.
- χρησιμοποιήστε το animation timeline για να ελέγξετε τα εφέ animation.
- δημιουργήστε προσαρμοσμένο animation.

In Aspose.Slides for C++, διάφορα εφέ animation μπορούν να εφαρμοστούν στα σχήματα. Καθώς κάθε στοιχείο στη διαφάνεια, συμπεριλαμβανομένου του κειμένου, των εικόνων, του αντικειμένου OLE, του πίνακα κ.λπ., θεωρείται σχήμα, αυτό σημαίνει ότι μπορούμε να εφαρμόσουμε εφέ animation σε κάθε στοιχείο μιας διαφάνειας.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides.animation) **namespace** παρέχει κλάσεις για εργασία με animation PowerPoint.

## **Εφέ Animation**

Το Aspose.Slides υποστηρίζει **150+ animation effects**, συμπεριλαμβανομένων βασικών εφέ animation όπως Bounce, PathFootball, εφέ Zoom και συγκεκριμένων εφέ animation όπως OLEObjectShow, OLEObjectOpen. Μπορείτε να βρείτε πλήρη λίστα εφέ animation στην απαρίθμηση [**EffectType**](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31).

Επιπλέον, αυτά τα εφέ animation μπορούν να χρησιμοποιηθούν σε συνδυασμό με αυτά:

- [ColorEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.set_effect)

## **Προσαρμοσμένο Animation**

Είναι δυνατόν να δημιουργήσετε τις δικές σας **custom animations** στο Aspose.Slides. Αυτό μπορεί να επιτευχθεί εάν συνδυάσετε αρκετές συμπεριφορές (behaviours) σε ένα νέο custom animation.

Το [**Behavior**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.behavior) είναι η δομική μονάδα κάθε εφέ animation PowerPoint. Όλα τα εφέ animation είναι στην πραγματικότητα ένα σύνολο συμπεριφορών (behaviours) που συντίθενται σε μία στρατηγική. Μπορείτε να συνδυάσετε συμπεριφορές σε ένα custom animation μία φορά και να τις επαναχρησιμοποιήσετε σε άλλες παρουσιάσεις. Εάν προσθέσετε μια νέα συμπεριφορά σε ένα τυπικό εφέ animation PowerPoint - θα γίνει ένα άλλο custom animation. Για παράδειγμα, μπορείτε να προσθέσετε επαναληπτική συμπεριφορά σε ένα animation ώστε να επαναλαμβάνεται αρκετές φορές.

Το [**Animation Point**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.point) είναι ένα σημείο όπου πρέπει να εφαρμοστεί η συμπεριφορά.

## **Γραμμή Χρόνου Animation**

Το [**Sequence**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.sequence) είναι μια συλλογή εφέ animation, που εφαρμόζονται σε ένα συγκεκριμένο σχήμα.

Το [**AnimationTimeLine**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.animation_time_line) είναι ένα σύνολο Sequences που χρησιμοποιείται σε μια συγκεκριμένη διαφάνεια. Είναι μια μηχανή animation που υπάρχει από το PowerPoint 2002. Σε προηγούμενες εκδόσεις του PowerPoint, ήταν δύσκολο να προστεθούν εφέ animation στην παρουσίαση, κάτι που μπορούσε να επιτευχθεί μόνο με διάφορες παρακάμψεις. Το Timeline αντικαθιστά την παλιά κλάση AnimationSettings και παρέχει πιο σαφή μοντέλο αντικειμένων για το animation PowerPoint. Μια διαφάνεια μπορεί να έχει μόνο μία animation timeline.

## **Διαδραστικό Animation**

Το [**EffectTriggerType**](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) επιτρέπει τον ορισμό ενεργειών χρήστη (π.χ. κλικ κουμπιού), που θα θέτουν σε κίνηση ένα συγκεκριμένο animation. Τα triggers προστέθηκαν μόνο στην τελευταία έκδοση του PowerPoint.

## **Animation Σχήματος**

Το Aspose.Slides επιτρέπει την εφαρμογή animation σε σχήματα, που μπορεί να είναι κείμενο, ορθογώνιο, γραμμή, πλαίσιο, αντικείμενο OLE κ.λπ.

{{% alert color="info" %}} 
Διαβάστε περισσότερα [**Σχετικά με το Animation Σχημάτων**](/slides/el/cpp/shape-animation/).
{{% /alert %}}

## **Γραφήματα με Animation**

Για τη δημιουργία γραφημάτων με animation, πρέπει να χρησιμοποιήσετε όλες τις ίδιες κλάσεις όπως για τα σχήματα. Ωστόσο, είναι δυνατόν να χρησιμοποιήσετε animation PowerPoint μόνο σε κατηγορίες γραφήματος ή σειρές γραφήματος. Μπορείτε επίσης να εφαρμόσετε εφέ animation σε ένα στοιχείο κατηγορίας ή σε ένα στοιχείο σειράς.

{{% alert color="info" %}} 
Διαβάστε περισσότερα [**Σχετικά με τα Γραφήματα με Animation**](/slides/el/cpp/animated-charts/).
{{% /alert %}}

## **Κείμενο με Animation**

Εκτός από το animated text, είναι επίσης δυνατό να εφαρμοστεί animation σε μια παράγραφο.

{{% alert color="info" %}} 
Διαβάστε περισσότερα [**Σχετικά με το Animated Text**](/slides/el/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

### Θα διατηρηθούν τα animations κατά την εξαγωγή σε PDF;

Όχι. Το PDF είναι μορφότυπο στατικό, επομένως τα animations και οι [slide transitions](/slides/el/cpp/slide-transition/) δεν εκτελούνται. Εάν χρειάζεστε κίνηση, εξάγετε σε [HTML5](/slides/el/cpp/export-to-html5/), [animated GIF](/slides/el/cpp/convert-powerpoint-to-animated-gif/), ή [video](/slides/el/cpp/convert-powerpoint-to-video/) αντί αυτού.

### Μπορώ να μετατρέψω μια παρουσίαση με animation σε βίντεο και να ελέγξω το ρυθμό καρέ και το μέγεθος του καρέ;

Ναι. Μπορείτε να [αποδώσετε την παρουσίαση ως καρέ](/slides/el/cpp/convert-powerpoint-to-video/) και να τα κωδικοποιήσετε σε βίντεο (π.χ., μέσω ffmpeg), επιλέγοντας τα FPS και την ανάλυση. Τα animations και οι slide transitions εκτελούνται κατά την απόδοση.

### Θα παραμείνουν τα animations άθικτα κατά την εργασία με ODP (όχι μόνο PPTX);

Το PPT, PPTX και ODP υποστηρίζονται για [ανάγνωση](/slides/el/cpp/open-presentation/) και [εγγραφή](/slides/el/cpp/save-presentation/), αλλά οι διαφορές μορφής σημαίνουν ότι ορισμένα εφέ μπορεί να φαίνονται ή να συμπεριφέρονται ελαφρώς διαφορετικά. Επικυρώστε κρίσιμες περιπτώσεις με πραγματικά δείγματα.