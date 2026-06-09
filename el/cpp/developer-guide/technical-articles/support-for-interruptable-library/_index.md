---
title: Υποστήριξη για τη Βιβλιοθήκη Διακοπής
type: docs
weight: 150
url: /el/cpp/support-for-interruptable-library/
keywords:
- βιβλιοθήκη διακοπής
- token διακοπής
- token ακύρωσης
- εργασία μεγάλης διάρκειας
- εργασία διακοπής
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Κάντε τις εργασίες μεγάλης διάρκειας ακυρώσιμες με το Aspose.Slides για C++. Διακόψτε με ασφάλεια την απόδοση και τις μετατροπές για PowerPoint και OpenDocument, με παραδείγματα."
---
## **Επισκόπηση**

Η Aspose.Slides παρέχει έναν μηχανισμό επεξεργασίας με διακοπές για εργασίες παρουσίασης μεγάλου χρόνου, όπως αποσειριοποίηση, σειριοποίηση και απόδοση. Αυτός ο μηχανισμός βασίζεται στις κλάσεις `InterruptionToken` και `InterruptionTokenSource`.

Ένα `InterruptionToken` μπορεί να εκχωρηθεί στο `LoadOptions` και να περάσει στον κατασκευαστή `Presentation`. Όταν κληθεί το `InterruptionTokenSource::Interrupt()`, η σχετική εργασία μεγάλου χρόνου διακόπτεται.

## **Βιβλιοθήκη Διακοπής**

Στην [Aspose.Slides 18.4](https://releases.aspose.com/slides/el/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/), εισάγαμε τις κλάσεις [InterruptionToken](https://reference.aspose.com/slides/el/cpp/aspose.slides/interruptiontoken/) και [InterruptionTokenSource](https://reference.aspose.com/slides/el/cpp/aspose.slides/interruptiontokensource/). Σας επιτρέπουν να διακόπτετε εργασίες μεγάλου χρόνου όπως αποσειριοποίηση, σειριοποίηση και απόδοση.

- [InterruptionTokenSource](https://reference.aspose.com/slides/el/cpp/aspose.slides/interruptiontokensource/) είναι η πηγή του(των) token(s) που περνιούνται στο [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_interruptiontoken/).
- Όταν το [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_interruptiontoken/) οριστεί και η παρουσία [LoadOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/) περάσει στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/), η κλήση του [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/el/cpp/aspose.slides/interruptiontokensource/interrupt/) διακόπτει οποιαδήποτε εργασία μεγάλου χρόνου που σχετίζεται με αυτό το [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).

```cpp
void Run(Action<SharedPtr<IInterruptionToken>> action, SharedPtr<IInterruptionToken> token)
{
    auto threadFunction = std::function<void()>([&action, &token]() -> void
    {
        action(token);
    });

    auto thread = System::MakeObject<Threading::Thread>(threadFunction);
    thread->Start();
}

void Run()
{
    String dataDir = GetDataPath();

    auto function = std::function<void(SharedPtr<IInterruptionToken> token)> ([&dataDir](SharedPtr<IInterruptionToken> token) -> void
    {
        auto options = System::MakeObject<LoadOptions>();
        options->set_InterruptionToken(token);

        auto presentation = System::MakeObject<Presentation>(dataDir + u"sample.pptx", options);
        presentation->Save(dataDir + u"sample.ppt", Export::SaveFormat::Ppt);
    });

    auto action = System::Action<SharedPtr<IInterruptionToken>>(function);
    auto tokenSource = System::MakeObject<InterruptionTokenSource>();
    
    Run(action, tokenSource->get_Token()); // εκτελεί τη δράση σε ξεχωριστό νήμα
    Threading::Thread::Sleep(10000);       // χρονικό όριο
    tokenSource->Interrupt();              // σταματά τη μετατροπή
}
```

## **Συχνές ερωτήσεις**

**Ποιος είναι ο σκοπός της βιβλιοθήκης διακοπής της Aspose.Slides;**

Παρέχει έναν μηχανισμό για τη διακοπή λειτουργιών μεγάλης διάρκειας — όπως η φόρτωση, η αποθήκευση ή η απόδοση παρουσιάσεων — πριν ολοκληρωθούν. Αυτό είναι χρήσιμο όταν πρέπει να περιοριστεί ο χρόνος επεξεργασίας ή όταν η εργασία δεν χρειάζεται πλέον.

**Ποια είναι η διαφορά μεταξύ [InterruptionToken](https://reference.aspose.com/slides/el/cpp/aspose.slides/interruptiontoken/) και [InterruptionTokenSource](https://reference.aspose.com/slides/el/cpp/aspose.slides/interruptiontokensource/);**

- `InterruptionToken` περνιέται στο API της Aspose.Slides και ελέγχεται κατά τη διάρκεια των λειτουργιών μεγάλης διάρκειας.
- `InterruptionTokenSource` χρησιμοποιείται στον κώδικά σας για τη δημιουργία token και την έναρξη διακοπών καλώντας το `Interrupt()`.

**Ποιες εργασίες μπορούν να διακοπούν;**

Οποιαδήποτε εργασία της Aspose.Slides που δέχεται ένα [InterruptionToken](https://reference.aspose.com/slides/el/cpp/aspose.slides/interruptiontoken/) — όπως η φόρτωση μιας παρουσίασης με `Presentation(path, loadOptions)` ή η αποθήκευση με `Presentation::Save(...)` — μπορεί να διακοπεί.

**Συμβαίνει η διακοπή αμέσως;**

Όχι. Η διακοπή είναι συνεργατική: η λειτουργία ελέγχει περιοδικά το token και σταματά αμέσως μόλις εντοπίσει ότι το [Interrupt()](https://reference.aspose.com/slides/el/cpp/aspose.slides/interruptiontokensource/interrupt/) έχει κληθεί.

**Τι συμβαίνει αν καλέσω το [Interrupt()](https://reference.aspose.com/slides/el/cpp/aspose.slides/interruptiontokensource/interrupt/) αφού η εργασία έχει ήδη ολοκληρωθεί;**

Τίποτα — η κλήση δεν έχει κανένα αποτέλεσμα εάν η αντίστοιχη εργασία έχει ήδη ολοκληρωθεί.

**Μπορώ να επαναχρησιμοποιήσω το ίδιο [InterruptionTokenSource](https://reference.aspose.com/slides/el/cpp/aspose.slides/interruptiontokensource/) για πολλαπλές εργασίες;**

Ναι — αλλά αφού καλέσετε το [Interrupt()](https://reference.aspose.com/slides/el/cpp/aspose.slides/interruptiontokensource/interrupt/) σε αυτήν την πηγή, όλες οι εργασίες που χρησιμοποιούν τα tokens της θα διακοπούν. Χρησιμοποιήστε ξεχωριστές πηγές token για να διαχειρίζεστε τις εργασίες ανεξάρτητα.