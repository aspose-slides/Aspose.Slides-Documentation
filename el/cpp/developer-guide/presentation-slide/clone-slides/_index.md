---
title: Κλωνοποίηση Διαφανειών Παρουσίασης σε C++
linktitle: Κλωνοποίηση Διαφανειών
type: docs
weight: 40
url: /el/cpp/clone-slides/
keywords:
- κλωνοποίηση διαφάνειας
- αντιγραφή διαφάνειας
- αποθήκευση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Διπλασιάστε γρήγορα διαφάνειες PowerPoint με το Aspose.Slides για C++. Ακολουθήστε τα σαφή παραδείγματα κώδικα μας για να αυτοματοποιήσετε τη δημιουργία PPT σε δευτερόλεπτα και να εξαλείψετε την χειροκίνητη εργασία."
---
## **Εισαγωγή**

Η κλωνοποίηση είναι η διαδικασία δημιουργίας ακριβούς αντιγράφου ή αντιστοίχισης κάτι. Το Aspose.Slides for C++ καθιστά επίσης δυνατό το να δημιουργηθεί αντίγραφο ή κλώνος μιας διαφάνειας και στη συνέχεια να εισαχθεί αυτή η κλωνοποιημένη διαφάνεια στην τρέχουσα ή σε οποιαδήποτε άλλη ανοιχτή παρουσίαση. Η διαδικασία κλωνοποίησης διαφάνειας δημιουργεί μια νέα διαφάνεια που μπορεί να τροποποιηθεί από προγραμματιστές χωρίς να αλλάξει η αρχική διαφάνεια. Υπάρχουν αρκετοί πιθανοί τρόποι κλωνοποίησης διαφάνειας:

- Κλωνοποίηση στο τέλος εντός μιας παρουσίασης.
- Κλωνοποίηση σε άλλη θέση εντός παρουσίασης.
- Κλωνοποίηση στο τέλος σε άλλη παρουσίαση.
- Κλωνοποίηση σε άλλη θέση σε άλλη παρουσίαση.
- Κλωνοποίηση σε συγκεκριμένη θέση σε άλλη παρουσίαση.

Στο Aspose.Slides for C++, (μια συλλογή αντικειμένων [ISlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/) που εκτίθενται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) ) παρέχει τις μεθόδους [AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/) και [InsertClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/insertclone/) για την εκτέλεση των παραπάνω τύπων κλωνοποίησης διαφάνειας.

## **Κλωνοποίηση διαφάνειας στο τέλος μιας παρουσίασης**
Εάν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης στο τέλος των υφιστάμενων διαφανειών, χρησιμοποιήστε τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/) σύμφωνα με τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Δημιουργήστε μια παρουσία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/) αναφέροντας τη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Καλέστε τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/) και περάστε τη διαφάνεια που θα κλωνοποιηθεί ως παράμετρο στη μέθοδο [AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/).
1. Γράψτε το τροποποιημένο αρχείο παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (που βρίσκεται στην πρώτη θέση – δείκτης μηδέν – της παρουσίασης) στο τέλος της παρουσίασης.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Κλωνοποίηση διαφάνειας σε άλλη θέση εντός μιας παρουσίασης**
Σε Παρουσίαση**
Εάν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης αλλά σε διαφορετική θέση, χρησιμοποιήστε τη μέθοδο [InsertClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/insertclone/):

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Δημιουργήστε μια παρουσία της κλάσης αναφέροντας τη συλλογή **Slides** που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Καλέστε τη μέθοδο [InsertClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/insertclone/) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/) και περάστε τη διαφάνεια που θα κλωνοποιηθεί μαζί με το δείκτη για τη νέα θέση ως παράμετρο στη μέθοδο [InsertClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/insertclone/).
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (που βρίσκεται στον δείκτη μηδέν – θέση 1 – της παρουσίασης) στη θέση δείκτη 1 – Θέση 2 – της παρουσίασης.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Κλωνοποίηση διαφάνειας στο τέλος άλλης παρουσίασης**
Εάν χρειάζεται να κλωνοποιήσετε μια διαφάνεια από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, στο τέλος των υφιστάμενων διαφανειών:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) που περιέχει την παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) που περιέχει την προορισμένη παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/) αναφέροντας τη συλλογή **Slides** που εκτίθεται από το αντικείμενο Presentation της προορισμένης παρουσίασης.
1. Καλέστε τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/) και περάστε τη διαφάνεια από την πηγαία παρουσίαση ως παράμετρο στη μέθοδο [AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/).
1. Γράψτε το τροποποιημένο αρχείο προορισμένης παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από τον πρώτο δείκτη της πηγαίας παρουσίασης) στο τέλος της προορισμένης παρουσίασης.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Κλωνοποίηση διαφάνειας σε άλλη θέση σε άλλη παρουσίαση**
Εάν χρειάζεται να κλωνοποιήσετε μια διαφάνεια από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, σε συγκεκριμένη θέση:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) που περιέχει την παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/) αναφέροντας τη συλλογή Slides του αντικειμένου Presentation της προορισμένης παρουσίασης.
1. Καλέστε τη μέθοδο [InsertClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/insertclone/) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/) και περάστε τη διαφάνεια από την πηγαία παρουσίαση μαζί με τη ζητούμενη θέση ως παράμετρο στη μέθοδο [InsertClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/insertclone/).
1. Γράψτε το τροποποιημένο αρχείο προορισμένης παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από τον δείκτη μηδέν της πηγαίας παρουσίασης) στον δείκτη 1 (θέση 2) της προορισμένης παρουσίασης.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Κλωνοποίηση διαφάνειας σε συγκεκριμένη θέση σε άλλη παρουσίαση**
Εάν χρειάζεται να κλωνοποιήσετε μια διαφάνεια με κύρια διαφάνεια (master slide) από μια παρουσίαση σε άλλη παρουσίαση, πρέπει πρώτα να κλωνοποιήσετε την απαιτούμενη κύρια διαφάνεια από την πηγαία παρουσίαση στην προορισμένη παρουσίαση. Στη συνέχεια, χρησιμοποιήστε αυτήν την κύρια διαφάνεια για την κλωνοποίηση της διαφάνειας με κύρια. Η μέθοδος **AddClone(ISlide, IMasterSlide)** περιμένει κύρια διαφάνεια από την προορισμένη παρουσίαση και όχι από την πηγαία. Για να κλωνοποιήσετε τη διαφάνεια με κύρια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) που περιέχει την προορισμένη παρουσίαση στην οποία θα κλωνοποιηθεί η διαφάνεια.
1. Πρόσβαση στη διαφάνεια που θα κλωνοποιηθεί μαζί με την κύρια διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [IMasterSlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslidecollection/) αναφέροντας τη συλλογή Masters που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) της προορισμένης παρουσίασης.
1. Καλέστε τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/) που εκτίθεται από το αντικείμενο [IMasterSlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslidecollection/) και περάστε την κύρια διαφάνεια από το πηγαίο PPTX ως παράμετρο στη μέθοδο [AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/).
1. Δημιουργήστε μια παρουσία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/) ορίζοντας την αναφορά στη συλλογή Slides του αντικειμένου [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) της προορισμένης παρουσίασης.
1. Καλέστε τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/) και περάστε τη διαφάνεια από την πηγαία παρουσίαση προς κλωνοποίηση και την κύρια διαφάνεια ως παράμετρο στη μέθοδο [AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/).
1. Γράψτε το τροποποιημένο αρχείο προορισμένης παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια με κύρια (που βρίσκεται στον δείκτη μηδέν της πηγαίας παρουσίασης) στο τέλος της προορισμένης παρουσίασης χρησιμοποιώντας την κύρια διαφάνεια από τη διαφάνεια πηγής.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Κλωνοποίηση διαφάνειας στο τέλος καθορισμένου τμήματος**
Εάν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης αλλά σε διαφορετικό τμήμα, τότε χρησιμοποιήστε τη μέθοδο [**AddClone()**](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/) που εκτίθεται από το interface [**ISlideCollection**](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/). Το Aspose.Slides for C++ καθιστά δυνατό τον κλωνοποιισμό μια διαφάνειας από το πρώτο τμήμα και την εισαγωγή του κλώνου στο δεύτερο τμήμα της ίδιας παρουσίασης.

Το ακόλουθο απόσπασμα κώδικα δείχνει πώς να κλωνοποιήσετε μια διαφάνεια και να εισάγετε τον κλώνο σε ένα καθορισμένο τμήμα.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Συχνές ερωτήσεις**

**Κλωνοποιούνται οι σημειώσεις ομιλητή και τα σχόλια ελεγκτή;**

Ναι. Η σελίδα σημειώσεων και τα σχόλια ελέγχου περιλαμβάνονται στον κλώνο. Εάν δεν τα θέλετε, [αφαιρέστε τα](/slides/el/cpp/presentation-notes/) μετά την εισαγωγή.

**Πώς αντιμετωπίζονται τα γραφήματα και οι πηγές δεδομένων τους;**

Το αντικείμενο γραφήματος, η μορφοποίηση και τα ενσωματωμένα δεδομένα αντιγράφονται. Εάν το γράφημα ήταν συνδεδεμένο με εξωτερική πηγή (π.χ., ένα ενσωματωμένο OLE βιβλίο εργασίας), η σύνδεση διατηρείται ως [αντικείμενο OLE](/slides/el/cpp/manage-ole/). Μετά τη μετακίνηση μεταξύ αρχείων, ελέγξτε τη διαθεσιμότητα των δεδομένων και τη συμπεριφορά ανανέωσης.

**Μπορώ να ελέγξω τη θέση εισαγωγής και τα τμήματα για τον κλώνο;**

Ναι. Μπορείτε να εισάγετε τον κλώνο σε συγκεκριμένο δείκτη διαφάνειας και να τον τοποθετήσετε σε επιλεγμένο [τμήμα](/slides/el/cpp/slide-section/). Εάν το στόχο τμήμα δεν υπάρχει, δημιουργήστε το πρώτα και μετά μετακινήστε τη διαφάνεια σε αυτό.