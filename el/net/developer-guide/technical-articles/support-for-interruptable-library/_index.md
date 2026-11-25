---
title: Διακοπή λειτουργιών παρουσίασης μεγάλας διάρκειας σε .NET
linktitle: Διακοπή λειτουργιών παρουσίασης
type: docs
weight: 150
url: /el/net/support-for-interruptable-library/
keywords:
- λειτουργίες που μπορούν να διακοπούν
- διακριτικό διακοπής
- διακριτικό ακύρωσης
- εργασία μεγάλης διάρκειας
- διακοπή εργασίας
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να ακυρώνετε λειτουργίες παρουσίασης μεγάλης διάρκειας στο Aspose.Slides για .NET και να επιστρέφετε μερικό αποτέλεσμα κατά την εξαγωγή διαφανειών σε βρόχο."
---
## **Επισκόπηση**

Το Aspose.Slides για .NET μπορεί να διακόψει λειτουργίες μεγάλης διάρκειας όπως η φόρτωση, η αποθήκευση και η απόδοση παρουσιάσεων. Η εφαρμογή σας μπορεί να χρησιμοποιήσει το ίδιο διακριτικό διακοπής για να σταματήσει έναν βρόχο πριν ξεκινήσει την επεξεργασία της επόμενης διαφάνειας.

## **Διακοπή λειτουργίας παρουσίασης**

Δημιουργήστε ένα [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/), αντιστοιχίστε το [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) του στο [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/), και περάστε τις επιλογές φόρτωσης στον [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Για να ζητήσετε ακύρωση, καλέστε [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) στην πηγή. Μια διακόψιμη λειτουργία σταματά όταν παρατηρήσει το αίτημα.

Το παράδειγμα ξεκινά τη μετατροπή του `sample.pptx` σε `sample.ppt` σε μια εργασία παρασκηνίου και ζητά ακύρωση μετά από 10 δευτερόλεπτα. Εάν η μετατροπή ολοκληρωθεί νωρίτερα, η έξοδος είναι ήδη πλήρης.

```c#
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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
    Run(action, tokenSource.Token); // εκτελεί την ενέργεια σε ξεχωριστό νήμα
    Thread.Sleep(10000);            // προθεσμία
    tokenSource.Interrupt();        // διακόπτει τη μετατροπή
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **Σύνδεση ακύρωσης .NET με Aspose.Slides**

Εάν η εφαρμογή σας χρησιμοποιεί ένα .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken), προωθήστε το αίτημα ακύρωσης στην Aspose.Slides. Το παράδειγμα ξεκινά την εξαγωγή του `sample.pptx` σε `sample.pdf` και ορίζει όριο χρόνου 20 δευτερολέπτων. Καθώς η εξαγωγή εκτελείται, ελέγχει το [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) κάθε 500 χιλιοστά του δευτερολέπτου. Όταν η ιδιότητα γίνει `true`, καλεί το [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/).

```cs
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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
    Task task = Run(action, tokenSource.Token); // εκτελεί την ενέργεια σε ξεχωριστό νήμα

    while (!task.Wait(500)) // περιμένει και παρακολουθεί εάν έχει τεθεί το cancellationToken.IsCancellationRequested
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // διακόπτει την επεξεργασία της παρουσίασης
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

## **Διακοπή πριν την επεξεργασία της επόμενης διαφάνειας**

Χρησιμοποιήστε το ίδιο [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) τόσο για την παρουσίαση όσο και για τον βρόχο που εξάγει τις διαφάνειές της. Ελέγξτε το [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) πριν ξεκινήσετε κάθε εξαγωγή. Εάν ο καλών μπορεί να χρησιμοποιήσει μερικό αποτέλεσμα, επιστρέψτε τους αριθμούς διαφανειών για τις εξαγωγές που ολοκληρώθηκαν επιτυχώς.

Χρησιμοποιήστε μια παρουσίαση με όνομα `sample.pptx` που έχει τουλάχιστον δύο διαφάνειες. Το παράδειγμα ζητά ακύρωση αμέσως μετά την καταγραφή της πρώτης επιτυχημένης εξαγωγής.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new InterruptionTokenSource();
var completed = ExportSlides("sample.pptx", source);
Console.WriteLine($"Completed: [{string.Join(", ", completed)}]");

static List<int> ExportSlides(string path, IInterruptionTokenSource source)
{
    var completed = new List<int>();
    IInterruptionToken token = source.Token;
    var options = new LoadOptions { InterruptionToken = token };
    using var presentation = new Presentation(path, options);

    for (var number = 1; number <= presentation.Slides.Count; number++)
    {
        if (token.IsInterruptionRequested)
            break;

        Console.WriteLine($"Starting slide {number}");
        try
        {
            presentation.Save($"slide-{number}.pdf", new[] { number }, SaveFormat.Pdf);
        }
        catch (OperationCanceledException) when (token.IsInterruptionRequested)
        {
            break;
        }

        completed.Add(number);
        if (number == 1)
            source.Interrupt();
    }

    return completed;
}
```

Το παράδειγμα γράφει το `slide-1.pdf` και εμφανίζει `Starting slide 1` ακολουθούμενο από `Completed: [1]`. Ο βρόχος βλέπει το αίτημα πριν ξεκινήσει τη διαφάνεια 2. Εάν η ακύρωση διακόψει αντ' αυτού το [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) κατά τη διάρκεια μιας εξαγωγής, το μπλοκ `catch` εξέρχεται από τον βρόχο προτού ο κώδικας καταγράψει τη τρέχουσα διαφάνεια ως ολοκληρωμένη.

Εάν ο καλών χρειάζεται να διαχειριστεί την ακύρωση, αντικαταστήστε τον έλεγχο `if` και το `break` στην αρχή του βρόχου με μια κλήση στο [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) στο διακριτικό. Αφαιρέστε το `try`/`catch` γύρω από την εξαγωγή ώστε η ακύρωση κατά τη διάρκεια μιας αποθήκευσης να φτάνει επίσης στον καλούντα. Με την ίδια είσοδο, το παράδειγμα εμφανίζει μόνο `Starting slide 1` και γράφει `slide-1.pdf`. Στην αρχή της δεύτερης επανάληψης, ο καλών λαμβάνει ένα [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) πριν ξεκινήσει η εξαγωγή. Η μέθοδος δεν επιστρέφει λίστα.

## **Συχνές ερωτήσεις**

**Πότε πρέπει να ζητήσω ακύρωση;**

Ζητήστε ακύρωση όταν μια λειτουργία υπερβαίνει το χρονικό όριό σας ή όταν η εφαρμογή σας δεν χρειάζεται πλέον το αποτέλεσμα.

**Ποια είναι η διαφορά μεταξύ [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) και [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/);**

Η πηγή επιτρέπει στην εφαρμογή σας να ζητήσει ακύρωση. Το διακριτικό επιτρέπει στην Aspose.Slides και στην εφαρμογή σας να ελέγχουν για αυτό το αίτημα.

**Μπορώ να χρησιμοποιήσω ένα .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) με το Aspose.Slides;**

Ναι. Όταν το .NET διακριτικό σας σήματα ακύρωσης, καλέστε το [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) στην πηγή που σχετίζεται με την παρουσίαση.

**Ποιες λειτουργίες μπορώ να διακόψω;**

Μπορείτε να διακόψετε τη φόρτωση, την αποθήκευση και την απόδοση. Περνάτε το διακριτικό στον [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) μέσω του [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/). Η παρουσίαση μπορεί τότε να παρατηρήσει την ακύρωση κατά τις επακόλουθες λειτουργίες όπως το [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/).

**Σταματάει η λειτουργία αμέσως;**

Η ακύρωση είναι συνεργατική. Μια λειτουργία ελέγχει το διακριτικό περιοδικά και σταματά όταν παρατηρήσει το αίτημα.

**Τι συμβαίνει αν καλέσω το [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) μετά το τέλος μιας λειτουργίας;**

Η ολοκληρωμένη λειτουργία διατηρεί το αποτέλεσμα της.

**Μπορούν πολλαπλές λειτουργίες να μοιράζονται ένα [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/);**

Ναι. Καλώντας το [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) ζητά ακύρωση για κάθε λειτουργία που χρησιμοποιεί ένα διακριτικό από αυτήν την πηγή. Χρησιμοποιήστε ξεχωριστή πηγή για κάθε λειτουργία που θέλετε να ακυρώσετε ανεξάρτητα.