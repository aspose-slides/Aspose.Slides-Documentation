---
title: Αυτοματοποιήστε την τοπικοποίηση παρουσιάσεων σε .NET
linktitle: Τοπικοποίηση Παρουσίασης
type: docs
weight: 100
url: /el/net/presentation-localization/
keywords:
- αλλαγή γλώσσας
- ορθογραφικός έλεγχος
- καταστολή ορθογραφικού ελέγχου
- γλώσσα απόδειξης
- αναγνωριστικό γλώσσας
- πολυγλωσσικό κείμενο
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ορίστε γλώσσες απόδειξης για κείμενο παρουσιάσεων PowerPoint και OpenDocument σε .NET με Aspose.Slides, συμπεριλαμβανομένων των προεπιλογών και των πολυγλωσσικών παραγράφων."
---
## **Επισκόπηση**

Το Aspose.Slides for .NET σάς επιτρέπει να ρυθμίζετε μεταδεδομένα ελέγχου απόδειξης για μεμονωμένα τμήματα κειμένου. Χρησιμοποιήστε [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseportionformat/languageid/) για να προσδιορίσετε τη γλώσσα ελέγχου απόδειξης, [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/spellcheck/) για να επιτρέψετε ή να καταστέλλετε τον ορθογραφικό έλεγχο, και [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/proofdisabled/) για να ελέγξετε την πιο γενική κατάσταση «μη απόδειξη». Δεδομένου ότι αυτές οι ρυθμίσεις εφαρμόζονται σε επίπεδο τμήματος, μία παράγραφος μπορεί να περιέχει πολλαπλές γλώσσες και διαφορετικούς κανόνες απόδειξης.

Αυτό το άρθρο εξηγεί πώς να ορίσετε μια γλώσσα για συγκεκριμένο κείμενο, να ορίσετε τη προεπιλεγμένη γλώσσα για νέο κείμενο με [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/defaulttextlanguage/), να δημιουργήσετε πολυγλωσσικές παραγράφους, να επιλέξετε μεταξύ `SpellCheck` και `ProofDisabled`, και να διατηρήσετε τις προορισμένες ρυθμίσεις όταν χρησιμοποιείτε [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/joinportionswithsameformatting/). Αυτές οι ιδιότητες αποθηκεύουν μεταδεδομένα για εφαρμογές παρουσίασης· δεν μεταφράζουν το κείμενο, δεν εκτελούν ορθογραφικό έλεγχο βάσει λεξικού, ούτε επιστρέφουν λανθασμένες λέξεις.

## **Ορισμός της γλώσσας ελέγχου απόδειξης για κείμενο**

Δημιουργήστε ή φορτώστε ένα [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/), αποκτήστε πρόσβαση στο απαιτούμενο τμήμα κειμένου μέσω [IPortion.PortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/portionformat/), και αναθέστε το αναγνωριστικό γλώσσας του. Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα, ορίζει τη βρετανική αγγλική ως γλώσσα ελέγχου απόδειξης, και αποθηκεύει το αποτέλεσμα με [Presentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Ορισμός της προεπιλεγμένης γλώσσας για νέο κείμενο**

Χρησιμοποιήστε [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/defaulttextlanguage/) για να καθορίσετε τη γλώσσα ελέγχου απόδειξης που το Aspose.Slides θα αναθέτει στο νέο κείμενο. Αυτή η ρύθμιση είναι χρήσιμη όταν η πλειονότητα ή όλο το νέο κείμενο σε μια παρουσίαση χρησιμοποιεί την ίδια γλώσσα. Δεν αλλάζει τα μεταδεδομένα γλώσσας του κειμένου που ήδη έχει ρητή γλώσσα.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση της οποίας το νέο κείμενο χρησιμοποιεί τους γερμανικούς κανόνες απόδειξης:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **Χρήση πολλαπλών γλωσσών σε μία παράγραφο**

Ένα [IParagraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/) περιέχει μια συλλογή τμημάτων κειμένου. Δημιουργήστε ένα ξεχωριστό [Portion](https://reference.aspose.com/slides/el/net/aspose.slides/portion/) για κάθε γλώσσα και ορίστε το `LanguageId` ανεξάρτητα.

Αυτό το παράδειγμα δημιουργεί μία παράγραφο με τμήματα αγγλικού και γαλλικού κειμένου:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **Ενεργοποίηση ή καταστολή του ορθογραφικού ελέγχου για μεμονωμένα τμήματα**

[IPortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iportionformat/) κληρονομεί τις κοινές ιδιότητες κειμένου που ορίζονται από [IBasePortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseportionformat/). Πρόσβαση στη μορφή ενός τμήματος μέσω [IPortion.PortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/portionformat/) και ορίστε [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/spellcheck/) για να ελέγξετε εάν μια εφαρμογή παρουσίασης μπορεί να ελέγξει την ορθογραφία για εκείνο το τμήμα. Η προεπιλεγμένη τιμή είναι `false`: `true` επιτρέπει τον ορθογραφικό έλεγχο, ενώ `false` τον καταστέλλει.

Η ρύθμιση εφαρμόζεται σε μεμονωμένα τμήματα κειμένου. Διάφορα τμήματα στην ίδια παράγραφο μπορούν έτσι να χρησιμοποιούν διαφορετικές τιμές. [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/languageid/) και `SpellCheck` εξυπηρετούν συμπληρωματικούς σκοπούς: το `LanguageId` προσδιορίζει τη γλώσσα ελέγχου απόδειξης, ενώ το `SpellCheck` καθορίζει εάν επιτρέπεται ο ορθογραφικός έλεγχος για το τμήμα.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/proofdisabled/) ελέγχει επίσης την απόδειξη, αλλά αντιπροσωπεύει την ευρύτερη κατάσταση «μη απόδειξη» ως [NullableBool](https://reference.aspose.com/slides/el/net/aspose.slides/nullablebool/). Χρησιμοποιήστε `SpellCheck` όταν χρειάζεστε άμεση Boolean εναλλαγή ειδικά για ορθογραφικούς ελέγχους. Χρησιμοποιήστε `ProofDisabled` όταν θέλετε να διατηρήσετε ή να ελέγξετε ρητά τα μεταδεδομένα «μη απόδειξης» της παρουσίασης, συμπεριλαμβανομένης της κατάστασης `NotDefined`. Εάν ορίσετε και τις δύο ιδιότητες, διατηρήστε τις τιμές τους συνεπείς· μην συνδυάζετε `SpellCheck = true` με `ProofDisabled = NullableBool.True`.

Αυτές οι ιδιότητες διαμορφώνουν μεταδεδομένα ελέγχου απόδειξης που χρησιμοποιούν το PowerPoint και άλλες εφαρμογές παρουσίασης. Το Aspose.Slides δεν τις χρησιμοποιεί για εκτέλεση ορθογραφικού ελέγχου βάσει λεξικού ή για επιστροφή λίστας λανθασμένων λέξεων.

Το παρακάτω πλήρες παράδειγμα δημιουργεί μια αρχική παρουσίαση, τη φορτώνει, αναθέτει διαφορετικές ρυθμίσεις ορθογραφικού ελέγχου και γλώσσες απόδειξης σε δύο τμήματα στην ίδια παράγραφο, αποθηκεύει το αποτέλεσμα, το ανοίγει ξανά και επαληθεύει τις αποθηκευμένες τιμές:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/joinportionswithsameformatting/) συνδυάζει διαδοχικά τμήματα που έχουν την ίδια μορφή. Μια διαφορά μόνο στο `SpellCheck` δεν διατηρεί τα τμήματα χωριστά· μετά τη σύζευξη, το προκύπτον τμήμα διατηρεί την τιμή `SpellCheck` του πρώτου τμήματος. Εάν τα τμήματα χρειάζονται διαφορετικές ρυθμίσεις ελέγχου ορθογραφίας, καλέστε `JoinPortionsWithSameFormatting` πριν ορίσετε αυτές τις ρυθμίσεις, ή ελέγξτε τα όρια του προκύπτον τμήματος και εφαρμόστε ξανά τις ρυθμίσεις μετά. Τμήματα με διαφορετικές τιμές `LanguageId` παραμένουν ξεχωριστά επειδή η μορφοποίηση της γλώσσας απόδειξης διαφέρει.

## **Συχνές ερωτήσεις**

**Μεταφράζει ένας κωδικός γλώσσας το κείμενο;**

Όχι. Το [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseportionformat/languageid/) αποθηκεύει μεταδεδομένα ελέγχου απόδειξης για ορθογραφία και γραμματική· δεν αλλάζει το περιεχόμενο του κειμένου. Μεταφράστε το κείμενο ξεχωριστά και, στη συνέχεια, ορίστε το κατάλληλο αναγνωριστικό γλώσσας για κάθε μεταφρασμένο τμήμα.

**Ο έλεγχος απόδειξης ελέγχει γραμματοσειρές, συλλαβισμό ή αναδίπλωση γραμμής;**

Όχι. Το αναγνωριστικό γλώσσας προορίζεται για απόδειξη. Η απόδοση και η διάταξη του κειμένου εξαρτώνται κυρίως από τις διαθέσιμες [fonts](/slides/el/net/powerpoint-fonts/), το σύστημα γραφής και τις ρυθμίσεις του πλαισίου κειμένου. Για αξιόπιστη απόδοση, παρέχετε τις απαιτούμενες γραμματοσειρές, διαμορφώστε [font substitution](/slides/el/net/font-substitution/), ή [embed fonts](/slides/el/net/embedded-font/) στην παρουσίαση.

**Μπορεί μια παράγραφος να χρησιμοποιεί πολλές γλώσσες απόδειξης;**

Ναι. Αναθέστε κάθε γλώσσα σε ξεχωριστό τμήμα, όπως φαίνεται στο παράδειγμα πολυγλωσσικής παραγράφου.

**Να χρησιμοποιήσω `DefaultTextLanguage` ή `LanguageId`;**

Χρησιμοποιήστε [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/defaulttextlanguage/) όταν θέλετε μια προεπιλογή για νέο κείμενο. Χρησιμοποιήστε [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseportionformat/languageid/) όταν ένα συγκεκριμένο τμήμα χρειάζεται ρητή γλώσσα απόδειξης ή όταν μια παράγραφος περιέχει πολλαπλές γλώσσες.