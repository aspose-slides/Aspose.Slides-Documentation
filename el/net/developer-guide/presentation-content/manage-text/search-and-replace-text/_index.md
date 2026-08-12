---
title: Αναζήτηση και Αντικατάσταση Κειμένου σε Παρουσιάσεις PowerPoint σε .NET
linktitle: Αναζήτηση και Αντικατάσταση Κειμένου
type: docs
weight: 55
url: /el/net/search-and-replace-text/
keywords:
- αναζήτηση κειμένου
- επισήμανση κειμένου
- αντικατάσταση κειμένου
- κανονική έκφραση
- κλήση επιστροφής αποτελέσματος
- πλαίσιο κειμένου
- αποτελέσματα ελέγχου
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Αναζητήστε, επισημάνετε και αντικαταστήστε κείμενο σε παρουσιάσεις PowerPoint ενώ συλλέγετε κάθε αντιστοίχιση με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Το Aspose.Slides for .NET μπορεί να αναζητήσει, να επισημάνει και να αντικαταστήσει κείμενο σε ένα μεμονωμένο πλαίσιο κειμένου ή σε ολόκληρη την παρουσίαση. Κάθε λειτουργία μπορεί επίσης να ενημερώνει μια εφαρμογή για κάθε αντιστοίχηση μέσω μιας κλήσης επιστροφής (callback) αποτελέσματος. Αυτό καθιστά δυνατό το να ενημερώνεται μια παρουσίαση ενώ ταυτόχρονα δημιουργείται ένα αρχείο καταγραφής που περιέχει το αντιστοιχισμένο κείμενο, το πλαίσιο του, τη θέση, το πλαίσιο κειμένου και τον αριθμό της διαφάνειας.

Αυτές οι δυνατότητες είναι χρήσιμες για αξιολόγηση, διαγραφή, έλεγχο ορολογίας, καθαρισμό προτύπων και αυτοματοποιημένες ροές εργασίας αναφοράς.

Στα πρώτα παραδείγματα παρακάτω, χρησιμοποιούμε ένα αρχείο με όνομα "sample.pptx", το οποίο περιέχει ένα μοναδικό πλαίσιο κειμένου στην πρώτη διαφάνεια με το ακόλουθο κείμενο:

![Δείγμα κειμένου](sample_text.png)

## **Επιλέξτε το Πεδίο Αναζήτησης**

Χρησιμοποιήστε μεθόδους στο [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) για να περιορίσετε μια λειτουργία σε ένα πλαίσιο κειμένου. Χρησιμοποιήστε μεθόδους στο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) για να επεξεργαστείτε όλο το κείμενο που ισχύει στην παρουσίαση.

| Λειτουργία | Ένα πλαίσιο κειμένου | Ολόκληρη παρουσίαση |
|---|---|---|
| Επισήμανση κυριολεκτικού κειμένου | [ITextFrame.HighlightText](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/highlighttext/) |
| Επισήμανση αντιστοιχιών κανονικής έκφρασης | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/highlightregex/) |
| Αντικατάσταση κυριολεκτικού κειμένου | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/replacetext/) |
| Αντικατάσταση αντιστοιχιών κανονικής έκφρασης | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/replaceregex/) |

## **Διαμόρφωση Αντιστοίχισης Κειμένου**

Για λειτουργίες κυριολεκτικού κειμένου, χρησιμοποιήστε το [TextSearchOptions](https://reference.aspose.com/slides/el/net/aspose.slides/textsearchoptions/) για να ελέγξετε την αντιστοίχιση:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/el/net/aspose.slides/textsearchoptions/wholewordsonly/) περιορίζει τις αντιστοιχίες σε πλήρεις λέξεις.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/el/net/aspose.slides/textsearchoptions/casesensitive/) ελέγχει αν πρέπει να ταιριάζει η πεζο‑κεφαλαία μορφή των χαρακτήρων.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/el/net/aspose.slides/textsearchoptions/includenotes/) συμπεριλαμβάνει τις σημειώσεις διαφάνειας στις λειτουργίες αναζήτησης, αντικατάστασης και επισήμανσης σε επίπεδο παρουσίασης.

Οι λειτουργίες κανονικής έκφρασης χρησιμοποιούν ένα .NET `Regex`, έτσι οι κανόνες αντιστοίχισης όπως η ευαισθησία πεζών‑κεφαλαίων και τα σύνορα λέξεων ορίζονται από την έκφραση και τις επιλογές της.

## **Συλλογή Πληροφοριών Αντιστοίχισης με Κλήση Επιστροφής**

Εφαρμόστε το [IFindResultCallback](https://reference.aspose.com/slides/el/net/aspose.slides/ifindresultcallback/) για να λαμβάνετε μια ειδοποίηση για κάθε αντιστοίχηση. Η μέθοδος [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/el/net/aspose.slides/ifindresultcallback/foundresult/) παρέχει το σχετικό πλαίσιο κειμένου, το πηγαίο κείμενο, το κείμενο που ταιριάζει και τη θέση της αντιστοίχισης.

Η κλήση επιστροφής δεν λαμβάνει απευθείας τον αριθμό της διαφάνειας. Η υλοποίηση παρακάτω το προκύπτει από τη γονική διαφάνεια και διαχειρίζεται επίσης κείμενο που βρίσκεται σε σημειώσεις διαφάνειας. Ένας αριθμός διαφάνειας που μπορεί να είναι κενός (nullable) επιτρέπει στο ίδιο μοντέλο αποτελέσματος να αντιπροσωπεύει κείμενο συνδεδεμένο με άλλους τύπους διαφάνειας.

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

Για λειτουργίες αντικατάστασης, το `FoundText` περιέχει το αρχικό κείμενο που ταιριάζει, ώστε η κλήση επιστροφής να μπορεί να καταγράψει ακριβώς ποιες λέξεις αντικαταστάθηκαν.

## **Επισήμανση Κειμένου**

Χρησιμοποιήστε τη μέθοδο [ITextFrame.HighlightText](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/highlighttext/) για να επισημάνετε τις κυριολεκτικές αντιστοιχίες σε ένα πλαίσιο κειμένου. Μεταβιβάστε το [TextSearchOptions](https://reference.aspose.com/slides/el/net/aspose.slides/textsearchoptions/) για να ελέγξετε την αναζήτηση και μια κλήση επιστροφής για τη συλλογή των λεπτομερειών της αντιστοίχισης.

Ο κώδικας παρακάτω επισημαίνει όλες τις εμφανίσεις των χαρακτήρων **"try"** και στη συνέχεια επισημαίνει μόνο τη πλήρη λέξη **"to"**. Και οι δύο αναζητήσεις αναφέρουν τις αντιστοιχίες τους στην ίδια κλήση επιστροφής.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Λάβετε το πρώτο σχήμα από την πρώτη διαφάνεια.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Επισημάνετε κάθε εμφάνιση του "try" στο πλαίσιο κειμένου.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Επισημάνετε μόνο τη πλήρη λέξη "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το επισήμασμένο κείμενο](highlighted_text.png)

## **Επισήμανση Κειμένου Χρησιμοποιώντας Κανονικές Εκφράσεις**

Η μέθοδος [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/highlightregex/) επισήμανε τις αντιστοιχίες κειμένου που βρίσκονται από μια κανονική έκφραση σε ένα πλαίσιο κειμένου.

Ο παρακάτω κώδικας επισήμανε όλες τις λέξεις που περιέχουν επτά ή περισσότερους χαρακτήρες και συλλέγει κάθε αντιστοίχηση:

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το επισήμασμένο κείμενο χρησιμοποιώντας κανονική έκφραση](highlighted_text_using_regex.png)

## **Επισήμανση Κειμένου σε Όλη την Παρουσίαση**

Χρησιμοποιήστε τα [Presentation.HighlightText](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/highlighttext/) και [Presentation.HighlightRegex](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/highlightregex/) για να αναζητήσετε όλα τα πλαίσια κειμένου που ισχύουν σε μια παρουσίαση. Το παρακάτω παράδειγμα επισήμανε έναν κυριολεκτικό όρο και όλες τις διευθύνσεις email ενώ διατηρεί ξεχωριστές συλλογές αποτελεσμάτων για τις δύο αναζητήσεις.

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **Αντικατάσταση Κειμένου σε Πλαίσιο Κειμένου**

Χρησιμοποιήστε το [ITextFrame.ReplaceText](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/replacetext/) για κυριολεκτικό κείμενο και το [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/replaceregex/) για αντικατάσταση βάσει προτύπου. Αυτές οι μέθοδοι ενημερώνουν το ταιριασμένο κείμενο μέσα στο υπάρχον πλαίσιο κειμένου, διατηρώντας τη μορφοποίηση του γύρω τμήματος αντί να ξαναχτίζουν το πλαίσιο κειμένου από μια απλή συμβολοσειρά.

Το παρακάτω παράδειγμα ενοποιεί μια παραλλαγή ορθογραφίας και στη συνέχεια αντικαθιστά ετικέτες εκδόσεων. Η ίδια κλήση επιστροφής καταγράφει τους αρχικούς όρους που ταιριάστηκαν και από τις δύο λειτουργίες.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

Αν μια αντιστοίχηση εκτείνεται σε τμήματα με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα για να επιβεβαιώσετε ποια μορφοποίηση πρέπει να εφαρμοστεί στο κείμενο αντικατάστασης.

## **Αντικατάσταση Κειμένου σε Όλη την Παρουσίαση**

Χρησιμοποιήστε τα [Presentation.ReplaceText](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/replacetext/) και [Presentation.ReplaceRegex](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/replaceregex/) για να εφαρμόσετε τις ίδιες λειτουργίες σε όλη την παρουσίαση. Αυτό είναι χρήσιμο για καθαρισμό προτύπων, ενημερώσεις ορολογίας και διαγραφή.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **Ομαδοποίηση Αντιστοιχιών για Αναφορά**

Επειδή κάθε αποτέλεσμα αποθηκεύει τον αριθμό της διαφάνειας και το πλαίσιο κειμένου, οι εφαρμογές μπορούν να ομαδοποιήσουν τις αντιστοιχίες για ελέγχους, αναφορές ή ροές εργασίας αξιολόγησης. Το παρακάτω παράδειγμα ομαδοποιεί τα συλλεγμένα αποτελέσματα πρώτα κατά διαφάνεια και έπειτα κατά πλαίσιο κειμένου:

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αναζητήσω μόνο ένα πλαίσιο κειμένου αντί για ολόκληρη την παρουσίαση;**

Αποκτήστε το πλαίσιο κειμένου του σχήματος και καλέστε το [ITextFrame.HighlightText](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/replacetext/) ή το [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/replaceregex/) στο εν λόγω πλαίσιο κειμένου. Οι μέθοδοι σε επίπεδο παρουσίασης επεξεργάζονται όλα τα πλαίσια κειμένου που ισχύουν.

**Πώς μπορώ να ταιριάζω πλήρεις λέξεις με τη σωστή κεφαλαιοποίηση;**

Ορίστε το [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/el/net/aspose.slides/textsearchoptions/wholewordsonly/) και το [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/el/net/aspose.slides/textsearchoptions/casesensitive/) σε `true` και περάστε τις επιλογές σε μια μέθοδο κυριολεκτικής επισήμανσης ή αντικατάστασης. Για κανονικές εκφράσεις, ορίστε τα σύνορα λέξεων και την ευαισθησία πεζών‑κεφαλαίων στο ίδιο το .NET `Regex`.

**Μπορεί η αναζήτηση και η αντικατάσταση να περιλαμβάνουν κείμενο σε σημειώσεις διαφάνειας;**

Ναι. Ορίστε το [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/el/net/aspose.slides/textsearchoptions/includenotes/) σε `true` όταν χρησιμοποιείτε μια λειτουργία κυριολεκτικού κειμένου σε επίπεδο παρουσίασης. Η υλοποίηση της κλήσης επιστροφής που εμφανίζεται παραπάνω χαρτογραφεί μια αντιστοίχηση σε διαφάνεια σημειώσεων πίσω στον γονικό αριθμό διαφάνειας.

**Πώς μπορώ να δημιουργήσω μια αναφορά χωρίς να σαρώσω τη παρουσίαση δεύτερη φορά;**

Περάστε μια υλοποίηση του [IFindResultCallback](https://reference.aspose.com/slides/el/net/aspose.slides/ifindresultcallback/) στην λειτουργία επισήμανσης ή αντικατάστασης. Η κλήση επιστροφής λαμβάνει κάθε αντιστοίχηση καθώς τρέχει η λειτουργία, ώστε η εφαρμογή να μπορεί να αποθηκεύσει το πηγαίο κείμενο, το κείμενο που ταιριάζει, τη θέση, το πλαίσιο κειμένου και τον προκύπτοντα αριθμό διαφάνειας για μεταγενέστερη ομαδοποίηση ή εξαγωγή.

**Διατηρεί η αντικατάσταση κειμένου τη μορφοποίησή του;**

Τα [ITextFrame.ReplaceText](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/replacetext/) και [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/replaceregex/) τροποποιούν το ταιριασμένο κείμενο μέσα στο υπάρχον πλαίσιο κειμένου και διατηρούν τη μορφοποίηση του γύρω τμήματος. Αν μια αντιστοίχηση εκτείνεται σε τμήματα με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα για να βεβαιωθείτε ότι η αντικατάσταση χρησιμοποιεί το επιθυμητό στυλ.