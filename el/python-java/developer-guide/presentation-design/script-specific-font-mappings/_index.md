---
title: Διαχείριση γραμματοσειρών θέματος ειδικές για σενάριο σε Python μέσω Java
linktitle: Γραμματοσειρές Θέματος ειδικές για σενάριο
type: docs
weight: 15
url: /el/python-java/script-specific-font-mappings/
keywords:
- γραμματοσειρά ειδική για σενάριο
- αντιστοίχιση γραμματοσειράς θέματος
- πολύγλωσση παρουσίαση
- σύστημα γραφής
- γραμματοσειρά Κυριλλικών
- γραμματοσειρά Αραβικών
- γραμματοσειρά Ιαπωνικής
- γραμματοσειρά Γεωργιανικών
- γραμματοσειρά Θάνα
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Επιθεώρηση, προσθήκη, αντικατάσταση και αφαίρεση αντιστοιχίσεων γραμματοσειρών ειδικών για σενάριο σε θέματα PowerPoint με Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Ένα θέμα παρουσίασης μπορεί να επιλέγει διαφορετικές οικογένειες γραμματοσειρών για διαφορετικά συστήματα γραφής. Αυτό επιτρέπει στο πολύγλωσσο κείμενο που εξακολουθεί να χρησιμοποιεί τις γραμματοσειρές του θέματος να ακολουθεί ένα ενιαίο σχήμα γραμματοσειρών, χρησιμοποιώντας τα κατάλληλα γραμματοστέλεχος για Κυριλλικά, Αραβικά, Ιαπωνικά, Γεωργιανά, Θάνα και άλλα σκριπτά.

Το θέμα's [FontScheme](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontscheme/) περιέχει μια κύρια συλλογή γραμματοσειρών, συνήθως χρησιμοποιούμενη για επικεφαλίδες, και μια δευτερεύουσα συλλογή γραμματοσειρών, συνήθως για το κυρίως κείμενο. Εκτός από τις ρυθμίσεις γραμματοσειρών για Λατινικό και Ανατολική Ασία, και οι δύο συλλογές εκθέτουν αντιστοιχίσεις από ετικέτες συστήματος γραφής σε ονόματα οικογενειών γραμματοσειρών μέσω της κλάσης [Fonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/fonts/).

Αυτό το άρθρο δείχνει πώς να ελέγξετε και να τροποποιήσετε αυτές τις αντιστοιχίσεις στο κύριο θέμα της παρουσίασης και να επαληθεύσετε ότι οι αλλαγές διατηρούνται μετά από κύκλο αποθήκευσης‑επαναφόρτωσης.

## **Κατανόηση Ετικετών Σεναρίων**

Οι μέθοδοι γραμματοσειρών script χρησιμοποιούν υπο‑ετικέτες σεναρίων τεσσάρων γραμμάτων BCP 47 για να προσδιορίσουν συστήματα γραφής. Συνήθεις τιμές περιλαμβάνουν:

| Ετικέτα σεναρίου | Σύστημα γραφής |
|---|---|
| `Cyrl` | Κυριλλικά |
| `Arab` | Αραβικό |
| `Hans` | Απλοποιημένα Κινέζικα |
| `Jpan` | Ιαπωνικά |
| `Geor` | Γεωργιανά |
| `Thaa` | Θάνα |

Αυτές οι αντιστοιχίσεις ανήκουν στο σχήμα γραμματοσειράς του θέματος, όχι σε μεμονωμένα τμήματα κειμένου. Μια παρουσίαση μπορεί να ορίσει διαφορετικές αντιστοιχίσεις για τις κύριες και δευτερεύουσες συλλογές, και μπορεί να παραλείψει αντιστοιχίσεις για ορισμένα σκριπτά.

## **Πρόσβαση και Επιθεώρηση Αντιστοιχίσεων Γραμματοσειρών Script**

Χρησιμοποιήστε [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getMasterTheme) για να αποκτήσετε το θέμα σε επίπεδο παρουσίασης. Οι μέθοδοι [FontScheme.getMajor](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontscheme/#getMajor) και [FontScheme.getMinor](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontscheme/#getMinor) επιστρέφουν τις δύο συλλογές [Fonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/fonts/).

Καλέστε [Fonts.getScriptFontMap](https://reference.aspose.com/slides/el/python-java/aspose.slides/fonts/#getScriptFontMap) για να ανακτήσετε όλες τις αντιστοιχίσεις από μια συλλογή. Για να αναζητήσετε ένα σύστημα γραφής, καλέστε [Fonts.getScriptFont](https://reference.aspose.com/slides/el/python-java/aspose.slides/fonts/#getScriptFont) με την ετικέτα του script. `getScriptFont` επιστρέφει `None` όταν η συλλογή δεν ορίζει την ζητούμενη αντιστοίχιση.

## **Τροποποίηση Αντιστοιχίσεων και Επαλήθευση Μόνιμης Αποθήκευσης**

Χρησιμοποιήστε [Fonts.setScriptFont](https://reference.aspose.com/slides/el/python-java/aspose.slides/fonts/#setScriptFont) για να δημιουργήσετε μια αντιστοίχιση ή να αντικαταστήσετε την τρέχουσα οικογένεια γραμματοσειράς. Χρησιμοποιήστε [Fonts.removeScriptFont](https://reference.aspose.com/slides/el/python-java/aspose.slides/fonts/#removeScriptFont) για να αφαιρέσετε μια αντιστοίχιση.

Το παρακάτω παράδειγμα end‑to‑end διαβάζει όλες τις υπάρχουσες κύριες και δευτερεύουσες αντιστοιχίσεις, εντοπίζει τη μεγάλη ιαπωνική γραμματοσειρά, αλλάζει τη μεγάλη κυριλλική γραμματοσειρά, αφαιρεί τη μικρή αντιστοίχιση Θάνα, αποθηκεύει την παρουσίαση και την ανοίγει ξανά για να επαληθεύσει και τις δύο αλλαγές. Για να κάνει το βήμα αφαίρεσης ανεξάρτητο από το αρχικό θέμα, το παράδειγμα πρώτα δημιουργεί μια αντιστοίχιση Θάνα μόνο όταν δεν υπάρχει ήδη ορισμένη.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

Η επαλήθευση χρησιμοποιεί την ίδια συμπεριφορά `None` όπως μια κανονική αναζήτηση: μετά την αποθήκευση της αφαίρεσης, το `getScriptFont("Thaa")` επιστρέφει `None` για τη δευτερεύουσα συλλογή.

## **Διαχωρισμός Αντιστοιχίσεων Θέματος από Άλλες Ρυθμίσεις Γραμματοσειράς**

Οι αντιστοιχίσεις θέματος ειδικές για script συμμετέχουν στην επιλογή γραμματοσειράς, αλλά λύνουν διαφορετικό πρόβλημα από την άμεση διαμόρφωση κειμένου, την αντικατάσταση και την απόθεση:

| Μηχανισμός | Σκοπός | Αποτέλεσμα αλλαγής αντιστοίχισης θέματος |
|---|---|---|
| Script‑specific theme font mapping | Επιλέγει μια μεγάλη ή μικρή γραμματοσειρά θέματος για ένα σύστημα γραφής. | Το κείμενο που εξακολουθεί να χρησιμοποιεί τη σχετική γραμματοσειρά θέματος μπορεί να αντικατασταθεί από τη νέα αντιστοιχισμένη οικογένεια. |
| Font assigned explicitly to a text portion | Διευκρινίζει την επιλεγμένη οικογένεια γραμματοσειράς σε αυτό το τμήμα αντί να βασίζεται στο θέμα. | Το τμήμα μπορεί να παραμείνει αμετάβλητο επειδή η άμεση μορφοποίηση υπερισχύει της επιλογής θέματος. |
| Font substitution | Αντικαθιστά μια ζητούμενη γραμματοσειρά όταν αυτή δεν είναι διαθέσιμη ή όταν ισχύει κανόνας αντικατάστασης. | Συμβαίνει αφού έχει ζητηθεί η γραμματοσειρά· δεν επαναορίζει την αντιστοίχηση script του θέματος. |
| Font fallback | Παρέχει γλύφη που δεν περιέχει η επιλεγμένη γραμματοσειρά, συχνά για συγκεκριμένα εύρη Unicode. | Συμπληρώνει το ελλιπές γλυφικό σύνολο· δεν αλλάζει την αποθηκευμένη αντιστοίχιση θέματος. |

Για περισσότερες πληροφορίες σχετικά με τους δύο τελευταίους μηχανισμούς, δείτε [Font Substitution](/slides/el/python-java/font-substitution/) και [Fallback Fonts](/slides/el/python-java/fallback-font/).

Η αλλαγή μιας αντιστοίχισης στο [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getMasterTheme) επηρεάζει μόνο το περιεχόμενο του οποίου η αποτελεσματική μορφοποίηση εξακολουθεί να εξαρτάται από αυτό το θέμα. Το κείμενο μπορεί αντίθετα να κληρονομήσει μια έξτρα ρύθμιση θέματος από ένα master, layout ή slide, ή να χρησιμοποιήσει μια ρητά ανατεθειμένη γραμματοσειρά. Ελέγξτε αυτά τα επίπεδα όταν το οπτικό αποτέλεσμα δεν ακολουθεί την αντιστοίχιση σε επίπεδο παρουσίασης.

## **Διασφαλίστε τη Διαθεσιμότητα των Αντιστοιχισμένων Γραμματοσειρών και Επικυρώστε το Αποτέλεσμα**

Μια αντιστοίχηση script αποθηκεύει μόνο το όνομα οικογένειας γραμματοσειράς· δεν εγκαθιστά ή φορτώνει το αντίστοιχο αρχείο γραμματοσειράς. Για συνεπή απόδοση και εξαγωγή, κάθε αντιστοιχισμένη γραμματοσειρά πρέπει να είναι εγκατεστημένη στο περιβάλλον ή να παρέχεται στην Aspose.Slides μέσω μιας προσαρμοσμένης πηγής, όπως [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsloader/#loadExternalFonts) ή [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Δείτε την ενότητα [Custom Fonts](/slides/el/python-java/custom-font/) για τις διαθέσιμες επιλογές φόρτωσης.

Η επαλήθευση της αποθηκευμένης αντιστοίχισης επιβεβαιώνει μόνο ότι ο ορισμός θέματος διατηρήθηκε. Δεν αποδεικνύει ότι η γραμματοσειρά είναι διαθέσιμη, ότι περιέχει όλα τα απαιτούμενα γλύφη ή ότι παράγει την επιθυμητή διάταξη. Αποδώστε αντιπροσωπευτικό κείμενο για κάθε απαιτούμενο σύστημα γραφής σε εικόνα ή PDF και εξετάστε το αποτέλεσμα. Αυτό εντοπίζει ελλιπείς γραμματοσειρές, μη πλήρη κάλυψη γλύφων, συμπεριφορά fallback και αλλαγές διάταξης πριν τη διανομή της παρουσίασης. Δείτε το [Convert PowerPoint Presentations](/slides/el/python-java/convert-powerpoint/) για παραδείγματα απόδοσης και εξαγωγής.

## **Συχνές Ερωτήσεις**

**Τι επιστρέφει το `getScriptFont` όταν ένα script δεν έχει αντιστοιχιστεί;**

[Fonts.getScriptFont](https://reference.aspose.com/slides/el/python-java/aspose.slides/fonts/#getScriptFont) επιστρέφει `None` όταν η ζητούμενη αντιστοίχιση script δεν είναι ορισμένη στη συγκεκριμένη κύρια ή δευτερεύουσα συλλογή γραμματοσειρών.

**Προσθέτει το `setScriptFont` δεύτερη αντιστοίχιση όταν το script υπάρχει ήδη;**

Όχι. Το [Fonts.setScriptFont](https://reference.aspose.com/slides/el/python-java/aspose.slides/fonts/#setScriptFont) δημιουργεί την αντιστοίχιση όταν λείπει και αντικαθιστά την υπάρχουσα οικογένεια γραμματοσειράς όταν η ίδια ετικέτα script είναι ήδη παρούσα.

**Γιατί η αλλαγή μιας αντιστοίχισης θέματος δεν άλλαξε κάποιο κείμενο;**

Το κείμενο μπορεί να έχει μια ρητά ανατεθειμένη γραμματοσειρά, να κληρονομεί διαφορετικό θέμα μέσω υπερίσχυσης, ή να επηρεάζεται από αντικατάσταση ή απόθεση κατά την απόδοση. Μια αντιστοίχηση script σε επίπεδο παρουσίασης ελέγχει μόνο το κείμενο του οποίου η αποτελεσματική μορφοποίηση εξακολουθεί να αναφέρεται στη συλλογή γραμματοσειρών του θέματος.

**Είναι η αποθήκευση και επαναφόρτωση επαρκείς για την επικύρωση της πολύγλωσσης εξόδου;**

Όχι. Η επαναφόρτωση επαληθεύει μόνο τη μόνιμη αποθήκευση των δεδομένων θέματος. Θα πρέπει επίσης να αποδοθεί αντιπροσωπευτικό κείμενο από κάθε απαιτούμενο σύστημα γραφής για να επιβεβαιωθεί ότι οι αντιστοιχισμένες γραμματοσειρές είναι διαθέσιμες και περιέχουν τα απαραίτητα γλύφη.