---
title: "Διακοπή Μακροχρόνιων Λειτουργιών Παρουσίασης σε C++"
linktitle: "Διακοπή Λειτουργιών Παρουσίασης"
type: docs
weight: 150
url: /el/cpp/support-for-interruptable-library/
keywords:
- "διακόψιμες λειτουργίες"
- "token διακοπής"
- "token ακύρωσης"
- "μακροχρόνια εργασία"
- "διακοπή εργασίας"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "C++"
- "Aspose.Slides"
description: "Μάθετε πώς να ακυρώνετε μακροχρόνιες λειτουργίες παρουσίασης στο Aspose.Slides for C++ και να επιστρέφετε μερικό αποτέλεσμα κατά την εξαγωγή διαφανειών σε βρόχο."
---
## **Επισκόπηση**

Το Aspose.Slides for C++ μπορεί να διακόψει μακροχρόνιες λειτουργίες όπως η φόρτωση, η αποθήκευση και η απόδοση παρουσιάσεων. Η εφαρμογή σας μπορεί να χρησιμοποιεί το ίδιο token διακοπής για να σταματήσει έναν βρόχο πριν ξεκινήσει την επεξεργασία της επόμενης διαφάνειας.

## **Διακοπή λειτουργίας παρουσίασης**

Δημιουργήστε ένα [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/), ανακτήστε το token του με [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/), περάστε το token στο [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/), και περάστε τις επιλογές φόρτωσης στον [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/). Για να ζητήσετε ακύρωση, καλέστε [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) στην πηγή. Μια λειτουργία που μπορεί να διακοπεί σταματά όταν παρατηρήσει το αίτημα.

Το παράδειγμα αρχίζει να μετατρέπει το `sample.pptx` σε `sample.ppt` σε μια διεργασία παρασκηνίου και ζητά ακύρωση εάν η διεργασία εξακολουθεί να εκτελείται μετά από 10 δευτερόλεπτα. Εάν η μετατροπή ολοκληρωθεί νωρίτερα, το αποτέλεσμα είναι ήδη πλήρες.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.ppt", Export::SaveFormat::Ppt);
});

if (conversion.wait_for(std::chrono::seconds(10)) == std::future_status::timeout)
    source->Interrupt();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
```

## **Σύνδεση ακύρωσης εφαρμογής με Aspose.Slides**

Εάν η εφαρμογή σας χρησιμοποιεί ένα [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/), χρησιμοποιήστε το [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) για να προωθήσετε τα αιτήματα ακυρώσεων στο [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/). Το παράδειγμα εξάγει το `sample.pptx` σε `sample.pdf` σε μια διεργασία παρασκηνίου. Εάν η εξαγωγή εξακολουθεί να εκτελείται μετά από 20 δευτερόλεπτα, η εφαρμογή καλεί το [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/), το οποίο εκτελεί την καταχωρημένη κλήση επιστροφής.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <system/threading/cancellation_token.h>
#include <system/threading/cancellation_token_source.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto cancellation = MakeObject<Threading::CancellationTokenSource>();
auto cancellationToken = cancellation->get_Token();
auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto interrupt = Action<>([source]() { source->Interrupt(); });
auto registration = cancellationToken.Register(interrupt);

auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.pdf", Export::SaveFormat::Pdf);
});

if (conversion.wait_for(std::chrono::seconds(20)) == std::future_status::timeout)
    cancellation->Cancel();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
registration.Dispose();
```

## **Διακοπή πριν την επεξεργασία της επόμενης διαφάνειας**

Χρησιμοποιήστε το ίδιο [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) για την παρουσίαση και για το βρόχο που εξάγει τις διαφάνειές της. Ελέγξτε το [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) πριν ξεκινήσετε κάθε εξαγωγή. Εάν ο καλών μπορεί να χρησιμοποιήσει μερικό αποτέλεσμα, επιστρέψτε τους αριθμούς των διαφανειών για τις εξαγωγές που ολοκληρώθηκαν επιτυχώς.

Χρησιμοποιήστε μια παρουσίαση με όνομα `sample.pptx` που περιέχει τουλάχιστον δύο διαφάνειες. Το παράδειγμα ζητά ακύρωση αμέσως μετά την καταγραφή της πρώτης επιτυχημένης εξαγωγής.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <DOM/ISlideCollection.h>
#include <system/array.h>
#include <iostream>
#include <vector>

using namespace Aspose::Slides;
using namespace System;

auto exportSlides = [](String path, SharedPtr<InterruptionTokenSource> source)
{
    std::vector<int32_t> completed;
    auto token = source->get_Token();
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(path, options);
    auto slideCount = presentation->get_Slides()->get_Count();

    for (auto number = 1; number <= slideCount; ++number)
    {
        if (token->get_IsInterruptionRequested())
            break;

        std::cout << "Starting slide " << number << '\n';
        auto filename = String::Format(u"slide-{0}.pdf", number);
        auto slides = MakeArray<int32_t>({number});
        try
        {
            presentation->Save(filename, slides, Export::SaveFormat::Pdf);
        }
        catch (const OperationCanceledException&)
        {
            if (!token->get_IsInterruptionRequested())
                throw;
            break;
        }

        completed.push_back(number);
        if (number == 1)
            source->Interrupt();
    }
    return completed;
};

auto source = MakeObject<InterruptionTokenSource>();
auto completed = exportSlides(u"sample.pptx", source);
std::cout << "Completed: [";
for (size_t i = 0; i < completed.size(); ++i)
    std::cout << (i == 0 ? "" : ", ") << completed[i];
std::cout << "]\n";
```

Το παράδειγμα γράφει το `slide-1.pdf` και εκτυπώνει `Starting slide 1` ακολουθούμενο από `Completed: [1]`. Ο βρόχος βλέπει το αίτημα πριν ξεκινήσει τη διαφάνεια 2. Εάν η ακύρωση διακόψει αντ' αυτού το [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) κατά τη διάρκεια μιας εξαγωγής, το τμήμα `catch` εξέρχεται από το βρόχο πριν ο κώδικας καταγράψει τη τρέχουσα διαφάνεια ως ολοκληρωμένη.

Εάν ο καλών χρειάζεται να διαχειριστεί την ακύρωση, αντικαταστήστε τον έλεγχο `if` και τη `break` στο πάνω μέρος του βρόχου με μια κλήση στο [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) στο token. Αφαιρέστε το `try`/`catch` γύρω από την εξαγωγή ώστε η ακύρωση κατά τη διάρκεια αποθήκευσης να φθάνει και στον καλών. Με την ίδια είσοδο, το παράδειγμα εκτυπώνει μόνο `Starting slide 1` και γράφει `slide-1.pdf`. Στην αρχή της δεύτερης επανάληψης, ο καλών λαμβάνει ένα [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) προτού αρχίσει η εξαγωγή. Ο καλών δεν λαμβάνει λίστα ολοκληρωμένων διαφανειών.

## **FAQ**

**Πότε πρέπει να ζητήσω ακύρωση;**

Ζητήστε ακύρωση όταν μια λειτουργία υπερβαίνει το χρονικό όριο ή όταν η εφαρμογή σας δεν χρειάζεται πλέον το αποτέλεσμα.

**Ποια είναι η διαφορά μεταξύ [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) και [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/);**

Η πηγή επιτρέπει στην εφαρμογή σας να ζητήσει ακύρωση. Το token επιτρέπει στο Aspose.Slides και στην εφαρμογή σας να ελέγχουν για αυτό το αίτημα.

**Μπορώ να χρησιμοποιήσω ένα [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) με το Aspose.Slides;**

Ναι. Όταν το token της εφαρμογής σας υποδείξει ακύρωση, καλέστε το [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) στην πηγή που συνδέεται με την παρουσίαση.

**Ποιες λειτουργίες μπορώ να διακόψω;**

Μπορείτε να διακόψετε τη φόρτωση, την αποθήκευση και την απόδοση. Περνάτε το token στον [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) μέσω του [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/). Η παρουσίαση μπορεί τότε να παρατηρήσει την ακύρωση κατά τις επόμενες λειτουργίες, όπως το [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

**Σταματάει η λειτουργία άμεσα;**

Η ακύρωση είναι συνεργατική. Μια λειτουργία ελέγχει το token περιοδικά και σταματά όταν παρατηρεί το αίτημα.

**Τι συμβαίνει αν καλέσω το [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) μετά το τέλος μιας λειτουργίας;**

Η ολοκληρωμένη λειτουργία διατηρεί το αποτέλεσμα της.

**Μπορούν πολλές λειτουργίες να μοιράζονται ένα [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/);**

Ναι. Καλώντας το [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) ζητάται ακύρωση για κάθε λειτουργία που χρησιμοποιεί ένα token από αυτή την πηγή. Χρησιμοποιήστε ξεχωριστή πηγή για κάθε λειτουργία που θέλετε να ακυρώσετε ανεξάρτητα.