---
title: Ενσωμάτωση Γραμματοσειρών σε Παρουσιάσεις με C++
linktitle: Ενσωμάτωση Γραμματοσειράς
type: docs
weight: 40
url: /el/cpp/embedded-font/
keywords:
- προσθήκη γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- λήψη ενσωματωμένης γραμματοσειράς
- προσθήκη ενσωματωμένης γραμματοσειράς
- αφαίρεση ενσωματωμένης γραμματοσειράς
- συμπίεση ενσωματωμένης γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Ενσωμάτωση γραμματοσειρών TrueType σε παρουσιάσεις PowerPoint και OpenDocument με Aspose.Slides για C++, εξασφαλίζοντας ακριβή απόδοση σε όλες τις πλατφόρμες."
---
## **Εισαγωγή**

**Οι ενσωματωμένες γραμματοσειρές στο PowerPoint** βοηθούν να διασφαλιστεί ότι η παρουσίασή σας διατηρεί την προβλεπόμενη εμφάνιση όταν ανοίγει σε οποιοδήποτε σύστημα ή συσκευή. Αυτό είναι ιδιαίτερα σημαντικό όταν χρησιμοποιούνται προσαρμοσμένες, τρίτων ή μη τυποποιημένες γραμματοσειρές για branding ή δημιουργικούς σκοπούς. Χωρίς ενσωματωμένες γραμματοσειρές, το κείμενο μπορεί να αντικατασταθεί, οι διατάξεις να χαλαρώσουν και οι χαρακτήρες να εμφανιστούν ως ακατανόητα σύμβολα ή ορθογώνια, υποβαθμίζοντας το συνολικό σχέδιο.

Το Aspose.Slides for C++ παρέχει ένα σύνολο ισχυρών API για τη διαχείριση των ενσωματωμένων γραμματοσειρών προγραμματιστικά. Μπορείτε να χρησιμοποιήσετε τις κλάσεις [FontsManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/) και [FontData](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontdata/) για να ελέγξετε, να προσθέσετε ή να αφαιρέσετε ενσωματωμένες γραμματοσειρές στα αρχεία παρουσίασής σας. Επιπλέον, η κλάση [Compress](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/) σας επιτρέπει να βελτιστοποιήσετε το μέγεθος του αρχείου συμπιέζοντας τα δεδομένα της γραμματοσειράς χωρίς να επηρεάζει την ποιότητα ή την εμφάνιση.

Αυτά τα εργαλεία σας δίνουν πλήρη έλεγχο της ενσωμάτωσης γραμματοσειρών, βοηθώντας σας να διατηρήσετε συνεπή τυπογραφία σε όλες τις πλατφόρμες ενώ μειώνετε το μέγεθος του αρχείου όταν χρειάζεται.

## **Λήψη Ενσωματωμένων Γραμματοσειρών από μια Παρουσίαση**

Aspose.Slides for C++ παρέχει τη μέθοδο `GetEmbeddedFonts` μέσω της κλάσης [FontsManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/) , η οποία σας επιτρέπει να ανακτήσετε μια λίστα με τις γραμματοσειρές που έχουν ενσωματωθεί σε μια παρουσίαση PowerPoint. Αυτό μπορεί να είναι χρήσιμο για έλεγχο χρήσης γραμματοσειρών, διασφάλιση συμμόρφωσης με τις οδηγίες branding ή επαλήθευση ότι όλες οι απαραίτητες γραμματοσειρές είναι σωστά ενσωματωμένες πριν την κοινή χρήση του αρχείου.

Ο ακόλουθος κώδικας C++ δείχνει πώς να λάβετε ενσωματωμένες γραμματοσειρές από ένα αρχείο παρουσίασης:

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Ανακτήστε όλες τις ενσωματωμένες γραμματοσειρές.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Εκτυπώστε τα ονόματα των ενσωματωμένων γραμματοσειρών.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Προσθήκη Ενσωματωμένων Γραμματοσειρών σε μια Παρουσίαση**

Το Aspose.Slides for C++ σας επιτρέπει να ενσωματώσετε γραμματοσειρές σε μια παρουσίαση PowerPoint χρησιμοποιώντας τη μέθοδο [AddEmbeddedFont](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/addembeddedfont/), η οποία διαθέτει δύο υπερφορτώσεις για ευέλικτη χρήση. Μπορείτε να ελέγξετε πόσο της γραμματοσειράς θα ενσωματωθεί χρησιμοποιώντας την απαρίθμηση [EmbedFontCharacters](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/embedfontcharacters/) — για παράδειγμα, επιλέγοντας να ενσωματωθούν μόνο οι χρησιμοποιημένοι χαρακτήρες ή ολόκληρο το σύνολο της γραμματοσειράς. Αυτή η δυνατότητα είναι ιδιαίτερα χρήσιμη όταν προετοιμάζετε μια παρουσίαση για κοινή χρήση ή διανομή, διασφαλίζοντας ότι οι προσαρμοσμένες ή μη τυποποιημένες γραμματοσειρές εμφανίζονται σωστά σε όλα τα συστήματα, ακόμη και αν αυτές οι γραμματοσειρές δεν είναι εγκατεστημένες.

Ο ακόλουθος κώδικας C++ ελέγχει όλες τις γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση και ενσωματώνει τυχόν γραμματοσειρές που δεν είναι ήδη ενσωματωμένες.

```cpp
// Φορτώστε ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Ελέγξτε αν η γραμματοσειρά είναι ήδη ενσωματωμένη.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Ενσωματώστε τη γραμματοσειρά στην παρουσίαση.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Αποθηκεύστε την παρουσίαση στο δίσκο.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Αφαίρεση Ενσωματωμένων Γραμματοσειρών από μια Παρουσίαση**

Το Aspose.Slides for C++ παρέχει τη μέθοδο `RemoveEmbeddedFont` μέσω της κλάσης [FontsManager](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/) , η οποία σας επιτρέπει να αφαιρέσετε συγκεκριμένες ενσωματωμένες γραμματοσειρές από μια παρουσίαση PowerPoint. Αυτό μπορεί να βοηθήσει στη μείωση του συνολικού μεγέθους του αρχείου, ειδικά αν οι ενσωματωμένες γραμματοσειρές δεν χρησιμοποιούνται πλέον ή δεν χρειάζονται. Η αφαίρεση των αχρησιμοποίητων γραμματοσειρών μπορεί επίσης να βελτιώσει την απόδοση και να εξασφαλίσει ότι η παρουσίασή σας περιλαμβάνει μόνο ουσιώδεις πόρους.

Ο ακόλουθος κώδικας C++ δείχνει πώς να αφαιρέσετε μια ενσωματωμένη γραμματοσειρά από μια παρουσίαση:

```cpp
auto fontName = u"Calibri";

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Ανακτήστε όλες τις ενσωματωμένες γραμματοσειρές.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Αφαιρέστε την ενσωματωμένη γραμματοσειρά.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Συμπίεση Ενσωματωμένων Γραμματοσειρών**

Το Aspose.Slides for C++ παρέχει τη μέθοδο `CompressEmbeddedFonts` μέσω της κλάσης [Compress](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/), επιτρέποντάς σας να μειώσετε το συνολικό μέγεθος του αρχείου μιας παρουσίασης βελτιστοποιώντας τα ενσωματωμένα δεδομένα γραμματοσειρών. Αυτό είναι ιδιαίτερα χρήσιμο όταν η παρουσίασή σας περιλαμβάνει μεγάλες ή πολλαπλές γραμματοσειρές και θέλετε να διατηρήσετε το αρχείο ελαφρύ για κοινή χρήση, αποθήκευση ή online χρήση — χωρίς να διακυβεύεται η οπτική πιστότητα του περιεχομένου.

Ο ακόλουθος κώδικας C++ δείχνει πώς να συμπιέσετε τις ενσωματωμένες γραμματοσειρές σε μια παρουσίαση PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να διαπιστώ ότι μια συγκεκριμένη γραμματοσειρά στην παρουσίαση θα αντικατασταθεί κατά τη βιβλιοσύνθεση παρόλο που είναι ενσωματωμένη;**

Ελέγξτε τις [πληροφορίες αντικατάστασης](/slides/el/cpp/font-substitution/) στον διαχειριστή γραμματοσειρών και τους [κανόνες εναλλακτικών/αντικατάστασης](/slides/el/cpp/fallback-font/): εάν η γραμματοσειρά δεν είναι διαθέσιμη ή είναι περιορισμένη, θα χρησιμοποιηθεί εναλλακτική.

**Αξίζει να ενσωματώνονται οι «συστημικές» γραμματοσειρές όπως Arial/Calibri;**

Συνήθως όχι — είναι σχεδόν πάντα διαθέσιμες. Ωστόσο, για πλήρη φορητότητα σε «λεπτές» περιβάλλοντα (Docker, διακομιστής Linux χωρίς προεγκατεστημένες γραμματοσειρές), η ενσωμάτωση συστημικών γραμματοσειρών μπορεί να εξαλειφθεί ο κίνδυνος ανεπιθύμητης αντικατάστασης.