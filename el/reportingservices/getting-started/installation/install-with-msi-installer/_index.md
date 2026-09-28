---
title: Εγκατάσταση με Εγκαταστάτη MSI
type: docs
weight: 20
url: /el/reportingservices/install-with-msi-installer/
keywords:
- Εγκαταστάτης MSI
- εγκατάσταση
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Εγκαταστήστε το Aspose.Slides for Reporting Services με τον εγκαταστάτη MSI του: τι χρειάζεται ο εγκαταστάτης, τι αλλάζει σε κάθε εγκατάσταση διακομιστή αναφορών, και πώς να ελέγξετε το αποτέλεσμα."
---
## **Εγκατάσταση**

Ο εγκαταστάτης MSI είναι ο πιο απλός τρόπος για να εγκαταστήσετε το Aspose.Slides for Reporting Services. Απαιτεί .NET Framework 3.5 και δικαιώματα διαχειριστή στον διακομιστή αναφορών· δείτε [Απαιτήσεις Συστήματος](/slides/el/reportingservices/system-requirements/).

1. Κατεβάστε τον εγκαταστάτη MSI, *Aspose.Slides for Reporting Services XX.XX*, από τη [σελίδα λήψης](https://releases.aspose.com/slides/reportingservices/) και αντιγράψτε την στον διακομιστή αναφορών.
1. Εκτελέστε το ως διαχειριστής. Εάν λείπει το .NET Framework 3.5, ο εγκαταστάτης διακόπτεται με μήνυμα· εγκαταστήστε τις δυνατότητες του .NET Framework 3.5 και εκτελέστε το ξανά.
1. Αποδεχτείτε τη συμφωνία άδειας.
1. Στη σελίδα **Custom Setup**, το δέντρο λειτουργιών εμφανίζει κάθε εγκατάσταση του SQL Server Reporting Services και του Power BI Report Server που εντοπίζει ο εγκαταστάτης στον υπολογιστή. Για να αφήσετε μια εγκατάσταση αμετάβλητη, κάντε κλικ στο εικονίδιο της και επιλέξτε **Entire feature will be unavailable**. Οι εκδόσεις Express δεν υποστηρίζουν επεκτάσεις απόδοσης, επομένως μην επιλέξετε μια εγκατάσταση Express. Ο εγκαταστάτης κρύβει τις εγκαταστάσεις Express του SQL Server 2016 και παλαιότερες.
1. Επιλέξτε **Next**, και έπειτα **Install**.

Η προαιρετική λειτουργία **Rpl Export** δεν είναι επιλεγμένη από προεπιλογή. Προσθέτει μια κρυφή επέκταση που αποθηκεύει αναφορές σε μορφή RPL, χρήσιμη όταν στέλνετε μια αναφορά προβλήματος στην Aspose· δείτε [Εξαγωγή Αναφορών σε Μορφή RPL](/slides/el/reportingservices/exporting-reports-to-rpl-format/).

## **Τι Αλλάζει ο Εγκαταστάτης**

Ο εγκαταστάτης διατηρεί τα αρχεία του στο *Aspose\Aspose.Slides for Reporting Services* κάτω από το φάκελο Program Files — *Program Files (x86)* στα Windows 64-bit, επειδή ο εγκαταστάτης είναι πακέτο 32-bit. Στη συνέχεια, για κάθε επιλεγμένη εγκατάσταση, εκτελεί:

- αντιγράφει το *Aspose.Slides.ReportingServices.dll* στον φάκελο *ReportServer\bin* της εγκατάστασης — την έκδοση για SQL Server 2005, ή την έκδοση για SQL Server 2008 και νεότερο, καθώς και Power BI Report Server·
- προσθέτει έξι επεκτάσεις απόδοσης — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS και ASODP — στο στοιχείο `<Render>` του *rsreportserver.config*·
- προσθέτει μια ομάδα κώδικα που χορηγεί πλήρη εμπιστοσύνη στο assembly στο *rssrvpolicy.config*·
- αποθηκεύει ένα αντίγραφο κάθε αρχείου ρυθμίσεων που τροποποιεί, με κατάληξη *.bak* στο όνομα του αρχείου.

[Εγκατάσταση Χειροκίνητα](/slides/el/reportingservices/install-manually/) δείχνει αυτές τις αλλαγές βήμα προς βήμα.

Εάν μια εγκατάσταση δεν μπορεί να ρυθμιστεί, ο εγκαταστάτης τη αναφέρει σε μήνυμα και γράφει τις λεπτομέρειες στο *rserrors<date>.log* στον φάκελο εγκατάστασης. Εγκαταστήστε την επέκταση σε αυτήν την εγκατάσταση χειροκίνητα.

## **Έλεγχος της Εγκατάστασης**

Ανοίξτε μια σελιδοποιημένη αναφορά στην ιστορική πύλη (Report Manager σε SQL Server 2014 και παλαιότερα) και ανοίξτε τη λίστα **Export**. Τώρα περιλαμβάνει αυτές τις μορφές:

- PPT - Παρουσίαση PowerPoint μέσω Aspose.Slides
- PPS - Παρουσίαση Διαφάνειας PowerPoint μέσω Aspose.Slides
- PPTX - Παρουσίαση PowerPoint 2007 μέσω Aspose.Slides
- PPSX - Διαφάνεια PowerPoint 2007 μέσω Aspose.Slides
- ODP - Παρουσίαση OpenDocument μέσω Aspose.Slides
- XPS - μέσω Aspose.Slides

Χωρίς άδεια, τα εξαγόμενα αρχεία φέρουν υδατογράφημα αξιολόγησης· δείτε [Αδειοδότηση](/slides/el/reportingservices/license-aspose-slides-for-reporting-services/).

## **Πότε να Εγκαταστήσετε Χειροκίνητα**

Εγκαταστήστε την επέκταση [χειροκίνητα](/slides/el/reportingservices/install-manually/) αντί για αυτό, όταν:

- ο εγκαταστάτης δεν μπορεί να ρυθμίσει μια εγκατάσταση, π.χ. λόγω ρυθμίσεων ασφαλείας στον διακομιστή·
- μετά από μια αναβάθμιση, θέλετε να αντικαταστήσετε μόνο το assembly αντί να απεγκαταστήσετε την παλιά έκδοση και να τρέξετε τον νέο εγκαταστάτη.

Η απεγκατάσταση του προϊόντος αφαιρεί το assembly και τις καταχωρίσεις ρυθμίσεων από κάθε εγκατάσταση.