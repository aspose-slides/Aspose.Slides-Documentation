---
title: Απαιτήσεις Συστήματος
type: docs
weight: 60
url: /el/python-net/system-requirements/
keywords:
- απαιτήσεις συστήματος
- λειτουργικό σύστημα
- εγκατάσταση
- εξαρτήσεις
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Ανακαλύψτε τις απαιτήσεις συστήματος του Aspose.Slides for Python μέσω .NET. Εξασφαλίστε απρόσκοπτη υποστήριξη PowerPoint και OpenDocument στα Windows, Linux και macOS."
---
## **Εισαγωγή**

Το Aspose.Slides for Python μέσω .NET δεν απαιτεί την εγκατάσταση τριτογενών προϊόντων, όπως το Microsoft PowerPoint. Το Aspose.Slides είναι μια μηχανή για δημιουργία, τροποποίηση, μετατροπή και απόδοση εγγράφων σε διάφορες μορφές, συμπεριλαμβανομένων των μορφών παρουσίασης του Microsoft PowerPoint.

## **Υποστηριζόμενα Λειτουργικά Συστήματα**

Το Aspose.Slides for Python υποστηρίζει Windows (32-bit και 64-bit), macOS και 64-bit Linux σε συστήματα με εγκατεστημένο Python 3.5 ή νεότερο.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">Λειτουργικό Σύστημα</td>
        <td style="font-weight: bold; width:400px">Εκδόσεις</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Linux</td>
        <td>
            <ul>
                <li>Ubuntu</li>
                <li>OpenSUSE</li>
                <li>CentOS</li>
                <li>και άλλα</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>macOS</td>
        <td>
            <ul>
                <li>12 "Monterey"</li>
            </ul>
        </td>
    </tr>
</table>

## **Απαιτήσεις Συστήματος για Πλατφόρμες Linux και macOS**

- Βιβλιοθήκες χρόνου εκτέλεσης GCC 6 (ή νεότερες).
- [libgdiplus](https://github.com/mono/libgdiplus), μια ανοιχτού κώδικα υλοποίηση του API GDI+.
- Εξαρτήσεις του .NET Core Runtime. Η εγκατάσταση του .NET Core Runtime δεν απαιτείται.
- Για Python 3.5–3.7: απαιτείται η κατασκευή `pymalloc` του Python. Η επιλογή κατασκευής `--with-pymalloc` είναι ενεργοποιημένη εξ ορισμού. Συνήθως η κατασκευή `pymalloc` του Python σημειώνεται με το επίθημα `m` στο όνομα αρχείου.
- Η κοινόχρηστη βιβλιοθήκη `libpython`. Η επιλογή κατασκευής `--enable-shared` του Python είναι απενεργοποιημένη εξ ορισμού, και κάποιες διανομές Python δεν περιλαμβάνουν τη κοινόχρηστη βιβλιοθήκη `libpython`. Σε ορισμένες πλατφόρμες Linux, μπορείτε να εγκαταστήσετε τη βιβλιοθήκη `libpython` χρησιμοποιώντας τον διαχειριστή πακέτων (π.χ., `sudo apt-get install libpython3.7`). Ένα συνηθισμένο πρόβλημα είναι ότι η βιβλιοθήκη `libpython` εγκαθίσταται σε μη τυπική θέση για κοινόχρηστες βιβλιοθήκες. Μπορείτε να το λύσετε χρησιμοποιώντας επιλογές κατασκευής του Python για να ορίσετε εναλλακτικές διαδρομές βιβλιοθηκών κατά τη μεταγλώττιση, ή δημιουργώντας έναν συμβολικό δεσμό προς το αρχείο της βιβλιοθήκης `libpython` στην τυπική θέση κοινόχρηστων βιβλιοθηκών του συστήματος. Συνήθως το όνομα αρχείου της κοινόχρηστης βιβλιοθήκης `libpython` είναι `libpythonX.Ym.so.1.0` για Python 3.5–3.7 ή `libpythonX.Y.so.1.0` για Python 3.8 ή νεότερο (π.χ., `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **Συχνές Ερωτήσεις**

**Χρειάζεται να είναι εγκατεστημένο το Microsoft PowerPoint για μετατροπές και απόδοση;**

Όχι, το PowerPoint δεν απαιτείται· το Aspose.Slides είναι μια αυτόνομη μηχανή για [δημιουργία](/slides/el/python-net/create-presentation/), τροποποίηση, [μετατροπή](/slides/el/python-net/convert-presentation/) και [απόδοση](/slides/el/python-net/convert-powerpoint-to-png/) παρουσιάσεων.

**Απαιτείται συγκεκριμένη έκδοση .NET (Core/5+/6+) στον υπολογιστή;**

Η εγκατάσταση του .NET Runtime δεν είναι απαραίτητη, αλλά πρέπει να υπάρχουν οι εξαρτήσεις του σε Linux/macOS. Αυτό σημαίνει ότι το σύστημα πρέπει να περιέχει τα πακέτα που συνήθως εγκαθίστανται ως εξαρτήσεις του .NET, χωρίς την πλήρη εγκατάσταση του runtime.

**Ποια γραμματοσυλλογές απαιτούνται για σωστή απόδοση;**

Στην πράξη, οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση ή οι κατάλληλες [υποκατάστασες](/slides/el/python-net/font-substitution/) πρέπει να είναι διαθέσιμες. Για να διασφαλιστεί συνεπής απόδοση σε Linux/macOS, συνιστάται η εγκατάσταση κοινών πακέτων γραμματοσειρών.

**Γιατί μια προσαρμοσμένη γραμματοσειρά εμφανίζεται ως εναλλακτική ή λείπει κείμενο σε Linux;**

Εάν το αρχείο γραμματοσειράς περιέχει ασυνεπείς ή κατεστραμμένες καταχωρήσεις στον πίνακα ονομάτων, η στοίβα αντιστοίχισης γραμματοσειρών του Linux (FreeType/fontconfig) μπορεί να επιλέξει μια μη έγκυρη εγγραφή, προκαλώντας την αδυναμία εύρεσης της γραμματοσειράς. Η χρήση μιας έκδοσης γραμματοσειράς με διορθωμένες εγγραφές ή η εγκατάσταση μιας συνεπούς αντικατάστασης λύνει το πρόβλημα.