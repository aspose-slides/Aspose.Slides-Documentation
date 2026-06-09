---
title: Προσθήκη διαφανειών σε παρουσιάσεις με C++
linktitle: Προσθήκη διαφάνειας
type: docs
weight: 10
url: /el/cpp/add-slide-to-presentation/
keywords:
- προσθήκη διαφάνειας
- δημιουργία διαφάνειας
- κενή διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Προσθέστε εύκολα διαφάνειες στις παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για C++ — απρόσκοπτη, αποδοτική εισαγωγή διαφανειών σε δευτερόλεπτα."
---
## **Overview**

Το Aspose.Slides σάς επιτρέπει να προσθέτετε διαφάνειες σε παρουσιάσεις PowerPoint προγραμματιστικά. Μια παρουσίαση περιλαμβάνει διαφάνειες master/διάταξης και κανονικές διαφάνειες, και οι κανονικές διαφάνειες διατάσσονται με βάση έναν δείκτη που ξεκινά από το μηδέν. Κάθε διαφάνεια έχει μοναδικό ID, και αρχεία παρουσίασης χωρίς διαφάνειες δεν υποστηρίζονται.

Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε ένα αντικείμενο `Presentation`, να προσπελάσετε τη συλλογή διαφανειών του, να προσθέσετε μια κενή διαφάνεια, να εργαστείτε με τη νεοπροστέθηκε διαφάνεια και να αποθηκεύσετε τη ενημερωμένη παρουσίαση. Επίσης καλύπτει σχετικές πτυχές όπως η εισαγωγή διαφανειών σε συγκεκριμένη θέση, η χρήση διατάξεων και η κατανόηση της άδειας διαφάνειας που υπάρχει σε μια νεοδημιουργημένη παρουσίαση.

## **Add a Slide to a Presentation**
Πριν συζητήσουμε για την προσθήκη διαφανειών στα αρχεία παρουσίασης, ας εξετάσουμε μερικά στοιχεία σχετικά με τις διαφάνειες. Κάθε αρχείο παρουσίασης PowerPoint περιέχει διαφάνεια Master / Layout και άλλες κανονικές διαφάνειες. Αυτό σημαίνει ότι ένα αρχείο παρουσίασης περιέχει τουλάχιστον μία ή περισσότερες διαφάνειες. Είναι σημαντικό να γνωρίζετε ότι αρχεία παρουσίασης χωρίς διαφάνειες δεν υποστηρίζονται από το Aspose.Slides for C++. Κάθε διαφάνεια έχει μοναδικό Id και όλες οι κανονικές διαφάνειες διατάσσονται με τη σειρά που ορίζεται από τον δείκτη που αρχίζει από το μηδέν. Το Aspose.Slides for C++ επιτρέπει στους προγραμματιστές να προσθέτουν κενές διαφάνειες στην παρουσίασή τους. Για να προσθέσετε μια κενή διαφάνεια στην παρουσίαση, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
- Δημιουργήστε ένα στιγμιότυπο της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/) ορίζοντας μια αναφορά στη ιδιότητα Slides (συλλογή αντικειμένων Slide περιεχομένου) που εκτίθεται από το αντικείμενο Presentation .
- Προσθέστε μια κενή διαφάνεια στην παρουσίαση στο τέλος της συλλογής διαφανειών περιεχομένου καλέγοντας τις μεθόδους AddEmptySlide που εκτίθενται από το αντικείμενο ISlideCollection .
- Κάντε κάποιες ενέργειες με τη νεοπροστέθηκε κενή διαφάνεια.
- Τέλος, γράψτε το αρχείο παρουσίασης χρησιμοποιώντας το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **FAQ**

**Can I insert a new slide at a specific position, not just at the end?**

Ναι. Η βιβλιοθήκη υποστηρίζει συλλογές διαφανειών και λειτουργίες [insert](https://reference.aspose.com/slides/el/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/el/cpp/aspose.slides/slidecollection/insertclone/) , ώστε να μπορείτε να προσθέσετε μια διαφάνεια στον απαιτούμενο δείκτη αντί μόνο στο τέλος.

**Are the theme/styles preserved when adding a slide based on a layout?**

Ναι. Μια διάταξη κληρονομεί τη μορφοποίηση από το master της, και η νέα διαφάνεια κληρονομεί από τη επιλεγμένη διάταξη και το συναφή master της.

**Which slide is present in a new "empty" presentation before adding slides?**

Μια νεοδημιουργημένη παρουσίαση περιέχει ήδη μία κενή διαφάνεια με δείκτη μηδέν. Αυτό είναι σημαντικό να ληφθεί υπόψη όταν υπολογίζετε δείκτες εισαγωγής.

**How do I choose the "right" layout for a new slide if the master has many options?**

Γενικά επιλέξτε το [LayoutSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/layoutslide/) που ταιριάζει στη ζητούμενη δομή ([Title and Content, Two Content, κ.λπ.](https://reference.aspose.com/slides/el/cpp/aspose.slides/slidelayouttype/)). Εάν λείπει τέτοια διάταξη, μπορείτε να την [προσθέστε τη στο master](/slides/el/cpp/slide-layout/) και στη συνέχεια να τη χρησιμοποιήσετε.