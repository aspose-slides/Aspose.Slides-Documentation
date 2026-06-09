---
title: Υποστήριξη για τη Διακόψιμη Βιβλιοθήκη
type: docs
weight: 150
url: /el/net/support-for-interruptable-library/
keywords:
- διακόψιμη βιβλιοθήκη
- Token διακοπής
- Token ακύρωσης
- εργασία μεγάλης διάρκειας
- εργασία διακοπής
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Κάντε τις εργασίες μεγάλης διάρκειας ακυρώσιμες με το Aspose.Slides για .NET. Διακόψτε με ασφάλεια την απόδοση και τις μετατροπές για PowerPoint και OpenDocument, με παραδείγματα."
---
## **Επισκόπηση**

Το Aspose.Slides για .NET παρέχει έναν μηχανισμό διακοπτέας επεξεργασίας για εργασίες παρουσίασης μεγάλου χρόνου εκτέλεσης, όπως απο-σειροποίηση, σειροποίηση και απόδοση. Αυτός ο μηχανισμός βασίζεται στις κλάσεις `InterruptionToken` και `InterruptionTokenSource`.

Ένα `InterruptionToken` μπορεί να εκχωρηθεί στο `LoadOptions` και να περαστεί στον κατασκευαστή `Presentation`. Όταν καλείται το `InterruptionTokenSource.Interrupt()`, η σχετική εργασία μεγάλου χρόνου εκτέλεσης διακόπτεται. Το άρθρο δείχνει επίσης πώς να χρησιμοποιήσετε αυτόν τον μηχανισμό μαζί με το πρότυπο .NET `CancellationToken`, παρακολουθώντας τα αιτήματα ακύρωσης και καλώντας το `Interrupt()` όταν ζητηθεί ακύρωση.

## **Βιβλιοθήκη Διακόψιμη**

Στο [Aspose.Slides 18.4](https://releases.aspose.com/slides/el/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/), εισαγάγαμε τις κλάσεις [InterruptionToken](https://reference.aspose.com/slides/el/net/aspose.slides/interruptiontoken/) και [InterruptionTokenSource](https://reference.aspose.com/slides/el/net/aspose.slides/interruptiontokensource/). Σας επιτρέπουν να διακόψετε εργασίες μεγάλου χρόνου εκτέλεσης όπως απο-σειροποίηση, σειροποίηση και απόδοση.

- [InterruptionTokenSource](https://reference.aspose.com/slides/el/net/aspose.slides/interruptiontokensource/) είναι η πηγή του(ων) token(s) που περνίονται στο [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/el/net/aspose.slides/iloadoptions/interruptiontoken/).
- Όταν το [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/el/net/aspose.slides/iloadoptions/interruptiontoken/) οριστεί και η παρουσία [LoadOptions](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/) περάσει στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/), η κλήση του [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/el/net/aspose.slides/interruptiontokensource/interrupt/) διακόπτει οποιαδήποτε εργασία μεγάλου χρόνου εκτέλεσης που σχετίζεται με αυτήν την [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να διακόψετε μια εκτελούμενη εργασία:

```c#
public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("sample.pptx", options))
        {
            presentation.Save("sample.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // εκτελέστε τη δράση σε ξεχωριστό νήμα
    Thread.Sleep(10000);            // λήξη χρόνου
    tokenSource.Interrupt();        // διακόψτε τη μετατροπή
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET CancellationToken και Βιβλιοθήκη Διακόψιμη**

Όταν χρειάζεται να χρησιμοποιήσετε ένα [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) μαζί με τη βιβλιοθήκη Διακόψιμη του Aspose.Slides, τυλίξτε την επεξεργασία του [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και διακόψτε το [InterruptionToken](https://reference.aspose.com/slides/el/net/aspose.slides/interruptiontoken/) όταν το [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) είναι `true`.

Αυτός ο κώδικας C# δείχνει τη λειτουργία:

```cs
public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("sample.pptx", "sample.pdf", tokenSource.Token);
}

static void ProcessPresentation(string path, string outPath, CancellationToken cancellationToken)
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions {InterruptionToken = token};
        using (Presentation presentation = new Presentation(path, options))
        {
            presentation.Save(outPath, SaveFormat.Pdf);
        }
    };
    
    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Task task = Run(action, tokenSource.Token); // εκτελέστε τη δράση σε ξεχωριστό νήμα

    while (!task.Wait(500)) // αναμείνετε και παρακολουθήστε αν έχει οριστεί το cancellationToken.IsCancellationRequested
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // διακόψτε την επεξεργασία Presentation
        }
    }
}

private static Task Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    return Task.Run(() =>
    {
        action(token);
    });
}
```

## **Συχνές Ερωτήσεις**

**Ποιος είναι ο σκοπός της βιβλιοθήκης διακοπής του Aspose.Slides;**

Παρέχει έναν μηχανισμό για τη διακοπή εργασιών μεγάλου χρόνου εκτέλεσης — όπως η φόρτωση, η αποθήκευση ή η απόδοση παρουσιάσεων — πριν ολοκληρωθούν. Αυτό είναι χρήσιμο όταν ο χρόνος επεξεργασίας πρέπει να περιοριστεί ή όταν η εργασία δεν χρειάζεται πλέον.

**Ποια είναι η διαφορά μεταξύ [InterruptionToken](https://reference.aspose.com/slides/el/net/aspose.slides/interruptiontoken/) και [InterruptionTokenSource](https://reference.aspose.com/slides/el/net/aspose.slides/iinterruptiontokensource/);**

- `InterruptionToken` περνίεται στο API του Aspose.Slides και ελέγχεται κατά τη διάρκεια εργασιών μεγάλου χρόνου εκτέλεσης.
- `InterruptionTokenSource` χρησιμοποιείται στον κώδικά σας για τη δημιουργία tokens και την ενεργοποίηση διακοπών καλώντας το `Interrupt()`.

**Μπορώ να χρησιμοποιήσω το .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) με τη βιβλιοθήκη διακοπής;**

Ναι. Μπορείτε να παρακολουθείτε το [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) στη λογική της εφαρμογής σας και να καλείτε το [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/el/net/aspose.slides/iinterruptiontokensource/interrupt/) όταν ζητηθεί η ακύρωση. Αυτό επιτρέπει στο Aspose.Slides να ενσωματωθεί σε τυπικές διαδικασίες ακύρωσης του .NET.

**Ποιες εργασίες μπορούν να διακοπούν;**

Οποιαδήποτε εργασία του Aspose.Slides που δέχεται ένα [InterruptionToken](https://reference.aspose.com/slides/el/net/aspose.slides/interruptiontoken/) — όπως η φόρτωση παρουσίασης με `Presentation(path, loadOptions)` ή η αποθήκευση με `Presentation.Save(...)` — μπορεί να διακοπεί.

**Συμβαίνει η διακοπή αμέσως;**

Όχι. Η διακοπή είναι συνεργατική: η λειτουργία ελέγχει περιοδικά το token και σταματά μόλις εντοπίσει ότι έχει κληθεί το [Interrupt()](https://reference.aspose.com/slides/el/net/aspose.slides/iinterruptiontokensource/interrupt/).

**Τι συμβαίνει αν καλέσω το [Interrupt()](https://reference.aspose.com/slides/el/net/aspose.slides/iinterruptiontokensource/interrupt/) μετά από την ολοκλήρωση μιας εργασίας;**

Τίποτα — η κλήση δεν έχει καμία επίδραση αν η αντίστοιχη εργασία έχει ήδη ολοκληρωθεί.

**Μπορώ να επαναχρησιμοποιήσω το ίδιο [InterruptionTokenSource](https://reference.aspose.com/slides/el/net/aspose.slides/iinterruptiontokensource/) για πολλές εργασίες;**

Ναι — αλλά αφού καλέσετε το [Interrupt()](https://reference.aspose.com/slides/el/net/aspose.slides/iinterruptiontokensource/interrupt/) σε αυτό το source, όλες οι εργασίες που χρησιμοποιούν τα tokens του θα διακοπούν. Χρησιμοποιήστε ξεχωριστές πηγές token για τη διαχείριση των εργασιών ανεξάρτητα.