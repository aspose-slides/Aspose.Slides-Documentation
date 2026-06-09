---
title: Ενσωμάτωση γραμματοσειρών σε παρουσιάσεις με C++
linktitle: Ενσωμάτωση γραμματοσειράς
type: docs
weight: 40
url: /el/cpp/embedded-font/
keywords:
- προσθήκη γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- ενσωμάτωση γραμματοσειρών
- λήψη ενσωματωμένης γραμματοσειράς
- προσθήκη ενσωματωμένης γραμματοσειράς
- αφαίρεση ενσωματωμένης γραμματοσειράς
- συμπίεση ενσωματωμένης γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Ενσωματώστε γραμματοσειρές TrueType σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides for C++, εξασφαλίζοντας ακριβή απόδοση σε όλες τις πλατφόρμες."
---
## **Εισαγωγή**

**Οι ενσωματωμένες γραμματοσειρές στο PowerPoint** βοηθούν να εξασφαλίσουν ότι η παρουσίασή σας διατηρεί την προγραμματισμένη της εμφάνιση όταν ανοίγεται σε οποιοδήποτε σύστημα ή συσκευή. Αυτό είναι ιδιαίτερα σημαντικό όταν χρησιμοποιείτε προσαρμοσμένες, τρίτων ή μη τυπικές γραμματοσειρές για branding ή δημιουργικούς σκοπούς. Χωρίς ενσωματωμένες γραμματοσειρές, το κείμενο μπορεί να αντικατασταθεί, οι διατάξεις να σπάσουν και οι χαρακτήρες να εμφανιστούν ως μη αναγνώσιμα σύμβολα ή ορθογώνια, θέτοντας σε κίνδυνο το συνολικό σχέδιο.

Aspose.Slides for C++ παρέχει ένα σύνολο ισχυρών API για τη διαχείριση ενσωματωμένων γραμματοσειρών προγραμματιστικά. Μπορείτε να χρησιμοποιήσετε τις κλάσεις [FontsManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/) και [FontData](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontdata/) για να ελέγξετε, να προσθέσετε ή να αφαιρέσετε ενσωματωμένες γραμματοσειρές στα αρχεία της παρουσίασής σας. Επιπλέον, η κλάση [Compress](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/) σας επιτρέπει να βελτιστοποιήσετε το μέγεθος του αρχείου συμπτύσσοντας τα δεδομένα της γραμματοσειράς χωρίς να επηρεάζει την ποιότητα ή την εμφάνιση. Αυτά τα εργαλεία σας δίνουν πλήρη έλεγχο της ενσωμάτωσης γραμματοσειρών, βοηθώντας σας να διατηρήσετε συνεπή τυπογραφία σε όλες τις πλατφόρμες ενώ μειώνετε το μέγεθος του αρχείου όταν χρειάζεται.

## **Λήψη ενσωματωμένων γραμματοσειρών από μια παρουσίαση**

Aspose.Slides for C++ παρέχει τη μέθοδο `GetEmbeddedFonts` μέσω της κλάσης [FontsManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/) , η οποία σας επιτρέπει να ανακτήσετε μια λίστα με τις γραμματοσειρές που είναι ενσωματωμένες σε μια παρουσίαση PowerPoint. Αυτό μπορεί να είναι χρήσιμο για έλεγχο χρήσης γραμματοσειρών, διασφάλιση συμμόρφωσης με τις οδηγίες branding, ή επαλήθευση ότι όλες οι απαραίτητες γραμματοσειρές έχουν ενσωματωθεί σωστά πριν την κοινή χρήση του αρχείου. Ο παρακάτω κώδικας C++ δείχνει πώς να λάβετε ενσωματωμένες γραμματοσειρές από ένα αρχείο παρουσίασης:

```cpp
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Λήψη όλων των ενσωματωμένων γραμματοσειρών.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Εκτύπωση ονομάτων των ενσωματωμένων γραμματοσειρών.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Προσθήκη ενσωματωμένων γραμματοσειρών σε μια παρουσίαση**

Το Aspose.Slides for C++ σας επιτρέπει να ενσωματώσετε γραμματοσειρές σε μια παρουσίαση PowerPoint χρησιμοποιώντας τη μέθοδο [AddEmbeddedFont](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/addembeddedfont/) , η οποία διαθέτει δύο υπερφορτώσεις για ευέλικτη χρήση. Μπορείτε να ελέγξετε πόσο της γραμματοσειράς θα ενσωματωθεί χρησιμοποιώντας την απαρίθμηση [EmbedFontCharacters](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/embedfontcharacters/) — π.χ., επιλέγοντας να ενσωματωθούν μόνο οι χρησιμοποιημένοι χαρακτήρες ή ολόκληρο το σύνολο της γραμματοσειράς. Αυτή η λειτουργία είναι ιδιαίτερα χρήσιμη κατά την προετοιμασία μιας παρουσίασης για κοινή χρήση ή διανομή, εξασφαλίζοντας ότι προσαρμοσμένες ή μη τυπικές γραμματοσειρές εμφανίζονται σωστά σε όλα τα συστήματα, ακόμη και αν αυτές οι γραμματοσειρές δεν είναι εγκατεστημένες. Ο παρακάτω κώδικας C++ ελέγχει όλες τις γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση και ενσωματώνει τυχόν γραμματοσειρές που δεν είναι ήδη ενσωματωμένες.

```cpp
// Φόρτωση αρχείου παρουσίασης.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Έλεγχος αν η γραμματοσειρά είναι ήδη ενσωματωμένη.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Ενσωμάτωση της γραμματοσειράς στην παρουσίαση.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Αποθήκευση της παρουσίασης στο δίσκο.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Αφαίρεση ενσωματωμένων γραμματοσειρών από μια παρουσίαση**

Aspose.Slides for C++ παρέχει τη μέθοδο `RemoveEmbeddedFont` μέσω της κλάσης [FontsManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/) , η οποία σας επιτρέπει να αφαιρέσετε συγκεκριμένες ενσωματωμένες γραμματοσειρές από μια παρουσίαση PowerPoint. Αυτό μπορεί να βοηθήσει στη μείωση του συνολικού μεγέθους του αρχείου, ιδιαίτερα εάν οι ενσωματωμένες γραμματοσειρές δεν χρησιμοποιούνται πλέον ή δεν χρειάζονται. Η αφαίρεση αχρησιμοποίητων γραμματοσειρών μπορεί επίσης να βελτιώσει την απόδοση και να διασφαλίσει ότι η παρουσίασή σας περιλαμβάνει μόνο τους απαραίτητους πόρους. Ο παρακάτω κώδικας C++ δείχνει πώς να αφαιρέσετε μια ενσωματωμένη γραμματοσειρά από μια παρουσίαση:

```cpp
auto fontName = u"Calibri";

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Λήψη όλων των ενσωματωμένων γραμματοσειρών.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Αφαίρεση της ενσωματωμένης γραμματοσειράς.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Συμπίεση ενσωματωμένων γραμματοσειρών**

Το Aspose.Slides for C++ παρέχει τη μέθοδο `CompressEmbeddedFonts` μέσω της κλάσης [Compress](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/) , επιτρέποντάς σας να μειώσετε το συνολικό μέγεθος του αρχείου μιας παρουσίασης βελτιστοποιώντας τα ενσωματωμένα δεδομένα γραμματοσειράς. Αυτό είναι ιδιαίτερα χρήσιμο όταν η παρουσίασή σας περιλαμβάνει μεγάλες ή πολλαπλές γραμματοσειρές και θέλετε να διατηρήσετε το αρχείο ελαφρύ για κοινή χρήση, αποθήκευση ή online χρήση — χωρίς να θυσιάζετε την οπτική ακεραιότητα του περιεχομένου. Ο παρακάτω κώδικας C++ δείχνει πώς να συμπιέσετε ενσωματωμένες γραμματοσειρές σε μια παρουσίαση PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Συχνές ερωτήσεις**

**Πώς μπορώ να διαπιστώ ότι μια συγκεκριμένη γραμματοσειρά στην παρουσίαση θα αντικατασταθεί κατά την απόδοση παρόλο που είναι ενσωματωμένη;**  
Ελέγξτε τις [πληροφορίες αντικατάστασης](/slides/el/cpp/font-substitution/) στο διαχειριστή γραμματοσειρών και τους [κανόνες εναλλακτικών/αντικατάστασης](/slides/el/cpp/fallback-font/): εάν η γραμματοσειρά δεν είναι διαθέσιμη ή περιορίζεται, θα χρησιμοποιηθεί εναλλακτική.

**Αξίζει η ενσωμάτωση των «συστημικών» γραμματοσειρών όπως Arial/Calibri;**  
Κατά κανόνα όχι—είναι σχεδόν πάντα διαθέσιμες. Ωστόσο, για πλήρη φορητότητα σε «ελαφριά» περιβάλλοντα (Docker, διακομιστής Linux χωρίς προεγκατεστημένες γραμματοσειρές), η ενσωμάτωση συστημικών γραμματοσειρών μπορεί να εξαλείψει τον κίνδυνο απροσδόκητων αντικαταστάσεων.