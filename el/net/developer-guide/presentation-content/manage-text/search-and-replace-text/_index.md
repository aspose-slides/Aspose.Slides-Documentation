---
title: Αναζήτηση και αντικατάσταση κειμένου σε παρουσιάσεις PowerPoint σε .NET
linktitle: Αναζήτηση και αντικατάσταση κειμένου
type: docs
weight: 55
url: /el/net/search-and-replace-text/
keywords:
- αναζήτηση κειμένου
- επισημάνση κειμένου
- αντικατάσταση κειμένου
- κανονική έκφραση
- callback αποτελέσματος
- πλαίσιο κειμένου
- αναφορά ελέγχου
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Αναζήτηση, επισημάνση και αντικατάσταση κειμένου σε παρουσιάσεις PowerPoint με τη συλλογή κάθε αντιστοίχησης μέσω Aspose.Slides για .NET."
---
## **Επισκόπηση**

Το Aspose.Slides for .NET μπορεί να αναζητήσει, να επισημάνει και να αντικαταστήσει κείμενο σε ένα μεμονωμένο πλαίσιο κειμένου ή σε ολόκληρη την παρουσίαση. Κάθε λειτουργία μπορεί επίσης να ειδοποιήσει μια εφαρμογή για κάθε αντιστοίχηση μέσω μιας κλήσης αποτελέσματος. Αυτό καθιστά δυνατή την ενημέρωση μιας παρουσίασης και ταυτόχρονα την καταγραφή ενός αρχείου ελέγχου που περιέχει το ταιριασμένο κείμενο, το πλαίσιο, τη θέση, το πλαίσιο κειμένου και τον αριθμό της διαφάνειας.

Αυτές οι δυνατότητες είναι χρήσιμες για ανασκόπηση, διαγραφή, έλεγχο ορολογίας, καθαρισμό προτύπων και αυτοματοποιημένες ροές εργασίας αναφοράς.

Στα πρώτα παραδείγματα παρακάτω, χρησιμοποιούμε ένα αρχείο με όνομα “sample.pptx”, το οποίο περιέχει ένα μόνο πλαίσιο κειμένου στην πρώτη διαφάνεια με το ακόλουθο κείμενο:

![Δείγμα κειμένου](sample_text.png)

## **Επιλέξτε το Πεδίο Αναζήτησης**

Χρησιμοποιήστε μεθόδους στο [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) για να περιορίσετε μια λειτουργία σε ένα πλαίσιο κειμένου. Χρησιμοποιήστε μεθόδους στο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) για να επεξεργαστείτε όλο το κείμενο που είναι εφαρμόσιμο στην παρουσίαση.

| Λειτουργία | Ένα πλαίσιο κειμένου | Ολόκληρη παρουσίαση |
|---|---|---|
| Επισήμανση κυριολεκτικού κειμένου | [ITextFrame.HighlightText](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/highlighttext/) |
| Επισήμανση αντιστοιχιών κανονικής έκφρασης | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/highlightregex/) |
| Αντικατάσταση κυριολεκτικού κειμένου | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/replacetext/) |
| Αντικατάσταση αντιστοιχιών κανονικής έκφρασης | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/replaceregex/) |

## **Διαμόρφωση Ταύτισης Κειμένου**

Για λειτουργίες κυριολεκτικού κειμένου, χρησιμοποιήστε το [TextSearchOptions](https://reference.aspose.com/slides/el/net/aspose.slides/textsearchoptions/) για να ελέγξετε την ταύτιση:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/el/net/aspose.slides/textsearchoptions/wholewordsonly/) περιορίζει τις αντιστοιχίσεις σε ολόκληρες λέξεις.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/el/net/aspose.slides/textsearchoptions/casesensitive/) ελέγχει αν πρέπει να ταιριάζει η διάκριση πεζών-κεφαλαίων.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/el/net/aspose.slides/textsearchoptions/includenotes/) περιλαμβάνει τις σημειώσεις διαφάνειας στις λειτουργίες αναζήτησης, αντικατάστασης και επισήμανσης σε επίπεδο παρουσίασης.

Οι λειτουργίες κανονικής έκφρασης χρησιμοποιούν ένα .NET `Regex`, επομένως οι κανόνες ταύτισης όπως η διάκριση πεζών-κεφαλαίων και τα όρια λέξεων ορίζονται από την έκφραση και τις επιλογές της.

## **Προσδιορισμός Ιδιοκτήτη Πλαισίου Κειμένου**

Οι γενικές ροές επεξεργασίας κειμένου συχνά λαμβάνουν ένα [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) κατά την αναζήτηση, αντικατάσταση, επικύρωση ή εξαγωγή κειμένου. Χρησιμοποιήστε τα [ITextFrame.ParentShape](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/parentshape/) και [ITextFrame.ParentCell](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/parentcell/) για να προσδιορίσετε ποιο αντικείμενο παρουσίασης κατέχει το πλαίσιο κειμένου.

Οι αναμενόμενες τιμές εξαρτώνται από τον ιδιοκτήτη:

| Ιδιοκτήτης πλαισίου κειμένου | `ParentShape` | `ParentCell` |
|---|---|---|
| Ένα AutoShape ή άλλο σχήμα που περιέχει κείμενο | Το κυρίως [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/) | `null` |
| Ένα κελί πίνακα | `null` | Το κυρίως [ICell](https://reference.aspose.com/slides/el/net/aspose.slides/icell/) |

Και οι δύο ιδιότητες είναι μόνο για ανάγνωση. Η ανάγνωσή τους δεν μετακινεί το πλαίσιο κειμένου ούτε αλλάζει τον ιδιοκτήτη του. Ο γενικός κώδικας θα πρέπει να ελέγχει και τις δύο τιμές για `null` και να αντιμετωπίζει την περίπτωση που κανένας ιδιοκτήτης δεν είναι διαθέσιμος.

Το ακόλουθο παράδειγμα χρησιμοποιεί το [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/el/net/aspose.slides.util/slideutil/getalltextframes/) για επανάληψη στα πλαίσια κειμένου μιας παρουσίασης. Για σχήματα, αναφέρει το όνομα του σχήματος, τον τύπο του σχήματος και τη διαφάνεια που το περιέχει. Για κελιά πίνακα, αναφέρει τις τιμές στήλης και γραμμής (από το μηδέν) και τη διαφάνεια που τα περιέχει.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

Για περιεχόμενο SmartArt, επαναλάβετε στα σχήματα στο [ISmartArtNode.Shapes](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/ismartartnode/shapes/) και αποκτήστε πρόσβαση σε κάθε [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/ismartartshape/textframe/). Το πλαίσιο κειμένου μπορεί να εντοπιστεί στο σχετικό σχήμα μέσω του [ITextFrame.ParentShape](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/parentshape/), ενώ το [ITextFrame.ParentCell](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/parentcell/) είναι `null`. Συνεπώς, ο κλάδος σχήματος στο παράδειγμα χειρίζεται επίσης κείμενο από κόμβους SmartArt.

## **Συλλογή Πληροφοριών Αντιστοιχίας με Callback**

Υλοποιήστε το [IFindResultCallback](https://reference.aspose.com/slides/el/net/aspose.slides/ifindresultcallback/) για να λαμβάνετε ειδοποίηση για κάθε αντιστοίχιση. Η μέθοδος [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/el/net/aspose.slides/ifindresultcallback/foundresult/) παρέχει το σχετικό πλαίσιο κειμένου, το αρχικό κείμενο, το ταιριασμένο κείμενο και τη θέση της αντιστοίχισης.

Το callback δεν λαμβάνει απευθείας αριθμό διαφάνειας. Η υλοποίηση παρακάτω τον εξάγει από τη διαφάνεια‑γονέα και επίσης επεξεργάζεται κείμενο που βρίσκεται στις σημειώσεις διαφάνειας. Ένας nullable αριθμός διαφάνειας επιτρέπει στο ίδιο μοντέλο αποτελέσματος να αντιπροσωπεύει κείμενο που σχετίζεται με άλλους τύπους διαφανειών.

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
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

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

Για λειτουργίες αντικατάστασης, το `FoundText` περιέχει το αρχικό ταιριασμένο κείμενο, έτσι ώστε το callback να μπορεί να καταγράψει ακριβώς ποιοι όροι αντικαταστάθηκαν.

## **Επισήμανση Κειμένου**

Χρησιμοποιήστε τη μέθοδο [ITextFrame.HighlightText](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/highlighttext/) για να επισημάνετε κυριολεκτικές αντιστοιχίες σε ένα πλαίσιο κειμένου. Πέραστε ένα [TextSearchOptions](https://reference.aspose.com/slides/el/net/aspose.slides/textsearchoptions/) για να ελέγξετε την αναζήτηση και ένα callback για τη συλλογή λεπτών στοιχείων.

Το παρακάτω παράδειγμα κώδικα επισημαίνει όλες τις εμφανίσεις των χαρακτήρων **"try"** και κατόπιν επισημαίνει μόνο τη λέξη **"to"**. Και οι δύο αναζητήσεις αναφέρουν τις αντιστοιχίες τους στο ίδιο callback.

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

// Επισημάνετε μόνο τη λέξη "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο](highlighted_text.png)

## **Επισήμανση Κειμένου Χρησιμοποιώντας Κανονικές Εκφράσεις**

Η μέθοδος [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/highlightregex/) επισημαίνει τις αντιστοιχίες κειμένου που βρίσκονται από μια κανονική έκφραση σε ένα πλαίσιο κειμένου.

Ο παρακάτω κώδικας επισημαίνει όλες τις λέξεις που περιέχουν επτά ή περισσότερους χαρακτήρες και συλλέγει κάθε αντιστοίχηση:

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

![Το επισημασμένο κείμενο χρησιμοποιώντας την κανονική έκφραση](highlighted_text_using_regex.png)

## **Επισήμανση Κειμένου σε Ολοκληρη Παρουσίαση**

Χρησιμοποιήστε τις μεθόδους [Presentation.HighlightText](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/highlighttext/) και [Presentation.HighlightRegex](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/highlightregex/) για να αναζητήσετε όλα τα εφαρμόσιμα πλαίσια κειμένου σε μια παρουσίαση. Το παρακάτω παράδειγμα επισημαίνει έναν κυριολεκτικό όρο και όλες τις διευθύνσεις email, διατηρώντας ξεχωριστές συλλογές αποτελεσμάτων για τις δύο αναζητήσεις.

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

Χρησιμοποιήστε το [ITextFrame.ReplaceText](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/replacetext/) για κυριολεκτικό κείμενο και το [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/replaceregex/) για αντικατάσταση με βάση πρότυπο. Αυτές οι μέθοδοι ενημερώνουν το ταιριασμένο κείμενο εντός του υπάρχοντος πλαισίου κειμένου, διατηρώντας τη μορφοποίηση του γύρω κειμένου αντί να δημιουργούν νέο πλαίσιο κειμένου από ακατέργαστη συμβολοσειρά.

Το παρακάτω παράδειγμα ενοποιεί μια παραλλαγή ορθογραφίας και στη συνέχεια αντικαθιστά ετικέτες έκδοσης. Το ίδιο callback καταγράφει τους αρχικούς όρους που ταιριάζουν και στις δύο λειτουργίες.

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

Αν μία αντιστοίχιση καλύπτει περιοχές με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα για να βεβαιωθείτε ποια μορφοποίηση πρέπει να εφαρμοστεί στο κείμενο αντικατάστασης.

## **Αντικατάσταση Κειμένου σε Ολοκληρη Παρουσίαση**

Χρησιμοποιήστε τις μεθόδους [Presentation.ReplaceText](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/replacetext/) και [Presentation.ReplaceRegex](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/replaceregex/) για να εφαρμόσετε τις ίδιες λειτουργίες σε όλη την παρουσίαση. Αυτό είναι χρήσιμο για καθαρισμό προτύπων, ενημέρωση ορολογίας και διαγραφή ευαίσθητων πληροφοριών.

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

## **Ομαδοποίηση Ταίριασμα για Αναφορές**

Επειδή κάθε αποτέλεσμα αποθηκεύει τον αριθμό της διαφάνειας και το πλαίσιο κειμένου, οι εφαρμογές μπορούν να ομαδοποιούν τατριχιμα για ελεγκτικούς, αναφορικούς ή επαγγελματικούς σκοπούς. Το παρακάτω παράδειγμα ομαδοποιεί τα συλλεγμένα αποτελέσματα πρώτα κατά διαφάνεια και μετά κατά πλαίσιο κειμένου:

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

## **FAQ**

**Πώς μπορώ να αναζητήσω μόνο ένα πλαίσιο κειμένου αντί για ολόκληρη την παρουσίαση;**

Αποκτήστε το πλαίσιο κειμένου του σχήματος και καλέστε το [ITextFrame.HighlightText](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/replacetext/) ή το [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/replaceregex/) σε αυτό το πλαίσιο κειμένου. Οι μέθοδοι σε επίπεδο παρουσίασης επεξεργάζονται όλα τα εφαρμόσιμα πλαίσια κειμένου.

**Πώς μπορώ να ταιριάξω πλήρεις λέξεις με την σωστή κεφαλοποίηση;**

Ορίστε το [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/el/net/aspose.slides/textsearchoptions/wholewordsonly/) και το [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/el/net/aspose.slides/textsearchoptions/casesensitive/) σε `true` και περάστε τις επιλογές σε μια μέθοδο κυριολεκτικής επισήμανσης ή αντικατάστασης. Για κανονικές εκφράσεις, ορίστε τα όρια λέξεων και τη διάκριση πεζών‑κεφαλαίων στο ίδιο το .NET `Regex`.

**Μπορεί η αναζήτηση και η αντικατάσταση να περιλαμβάνει κείμενο στις σημειώσεις διαφάνειας;**

Ναι. Ορίστε το [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/el/net/aspose.slides/textsearchoptions/includenotes/) σε `true` όταν χρησιμοποιείτε μια λειτουργία κυριολεκτικού κειμένου σε επίπεδο παρουσίασης. Η υλοποίηση του callback που εμφανίζεται παραπάνω αντιστοιχίζει μια αντιστοίχιση σε διαφάνεια σημειώσεων στον αριθμό της γονικής διαφάνειας.

**Πώς μπορώ να δημιουργήσω αναφορά χωρίς να σαρώσω ξανά την παρουσίαση;**

Περάστε μια υλοποίηση του [IFindResultCallback](https://reference.aspose.com/slides/el/net/aspose.slides/ifindresultcallback/) στην λειτουργία επισήμανσης ή αντικατάστασης. Το callback λαμβάνει κάθε αντιστοίχηση ενώ η λειτουργία εκτελείται, ώστε η εφαρμογή να μπορεί να αποθηκεύσει το πηγαίο κείμενο, το ταιριασμένο κείμενο, τη θέση, το πλαίσιο κειμένου και τον προκύπτοντα αριθμό διαφάνειας για μετέπειτα ομαδοποίηση ή εξαγωγή.

**Διατηρεί η αντικατάσταση κειμένου τη μορφοποίησή του;**

Τα [ITextFrame.ReplaceText](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/replacetext/) και [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/replaceregex/) τροποποιούν το ταιριασμένο κείμενο εντός του υπάρχοντος πλαισίου κειμένου και διατηρούν τη μορφοποίηση του γύρω κειμένου. Εάν μια αντιστοίχιση καλύπτει περιοχές με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα ώστε η αντικατάσταση να χρησιμοποιεί το επιθυμητό στυλ.