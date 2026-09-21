---
title: Διαχείριση Πεδία Κειμένου σε Παρουσιάσεις PowerPoint σε .NET
linktitle: Πεδία Κειμένου
type: docs
weight: 52
url: /el/net/text-fields/
keywords:
- πεδίο κειμένου
- αυτόματο κείμενο
- αριθμός διαφάνειας
- ημερομηνία και ώρα
- κεφαλίδα
- υποσέλιδο
- τμήμα κειμένου
- PowerPoint
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Δημιουργήστε, εξετάστε, τροποποιήστε και αφαιρέστε πεδία κειμένου σε παρουσιάσεις PowerPoint με το Aspose.Slides για .NET. Διατηρήστε τη μορφοποίηση και επαληθεύστε τα αποθηκευμένα αρχεία PPTX και PPT."
---
## **Επισκόπηση**

Μια παράγραφος κειμένου αποτελείται από τμήματα. Ένα κανονικό [IPortion](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/) περιέχει κυριολεκτικό κείμενο· ένα τμήμα πεδίου περιλαμβάνει επίσης ένα [IField](https://reference.aspose.com/slides/el/net/aspose.slides/ifield/) του οποίου ο τύπος προσδιορίζει μια αυτόματα ενημερωμένη τιμή, όπως αριθμός διαφάνειας ή ημερομηνία. Δύο τμήματα μπορούν να εμφανίζουν τους ίδιους χαρακτήρες ενώ μόνο ένα περιέχει πεδίο.

Χρησιμοποιήστε το [IPortion.Field](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/field/) για να τα διακρίνετε: είναι `null` για κανονικό κείμενο. Το [IPortion.AddField](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/addfield/) μετατρέπει ένα υπάρχον τμήμα σε πεδίο. Διατηρήστε μια ετικέτα και τη δυναμική της τιμή σε ξεχωριστά τμήματα ώστε η μετατροπή της τιμής να μην αντικαθιστά επίσης και την ετικέτα.

Αυτός ο οδηγός καλύπτει τα πεδία εντός κειμένου, τη μορφοποίησή τους και την αποθήκευση σε PPTX και PPT. Για πλαίσια κειμένου και παραγράφους, δείτε το [Manage Text](/slides/el/net/manage-text/).

## **Δημιουργία Πεδίου Αριθμού Διαφάνειας**

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα πλαίσιο κειμένου που περιέχει μια κυριολεκτική ετικέτα `Slide ` ακολουθούμενη από έναν αυτόματα ενημερωμένο αριθμό. Ορίζει το μέγεθος, το βάρος και το χρώμα του αριθμού πριν προσθέσει το πεδίο, στη συνέχεια ανοίγει ξανά την αποθηκευμένη παρουσίαση και ελέγχει τον τύπο του πεδίου, το κείμενο και τη μορφοποίηση. Δεν απαιτείται αρχείο εισόδου.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

Η νέα παρουσίαση ξεκινά με αριθμό διαφάνειας 1, έτσι το κείμενο είναι `Slide 1` και και οι δύο έλεγχοι εμφανίζουν `True`. Ο αριθμός παραμένει πεδίο μετά το άνοιγμα ξανά· δεν είναι κυριολεκτικό `1`. Οι μετατροπές τύπων και οι δείκτες στην επαλήθευση αναφέρονται στο σχήμα και τα τμήματα που δημιουργήθηκαν από αυτό το παράδειγμα.

## **Επιλογή Τύπου Πεδίου**

Το [FieldType](https://reference.aspose.com/slides/el/net/aspose.slides/fieldtype/) υλοποιεί το [IFieldType](https://reference.aspose.com/slides/el/net/aspose.slides/ifieldtype/) και παρέχει τις παρακάτω προκαθορισμένες τιμές. Μεταβιβάστε τη σωστή τιμή στο [AddField](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/addfield/).

| Τιμή | Σκοπός |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/el/net/aspose.slides/fieldtype/slidenumber/) | Ο τρέχων αριθμός της διαφάνειας. |
| [DateTime](https://reference.aspose.com/slides/el/net/aspose.slides/fieldtype/datetime/) | Η ημερομηνία/ώρα στη προεπιλεγμένη μορφή της εφαρμογής απόδοσης. |
| [DateTime1](https://reference.aspose.com/slides/el/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/el/net/aspose.slides/fieldtype/datetime9/) | Προκαθορισμένες μορφές ημερομηνίας ή συνδυασμένες μορφές ημερομηνίας/ώρας. |
| [DateTime10](https://reference.aspose.com/slides/el/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/el/net/aspose.slides/fieldtype/datetime13/) | Προκαθορισμένες μορφές ώρας, με επιλογές για δευτερόλεπτα και 12‑ωρο ρολόι. |
| [Header](https://reference.aspose.com/slides/el/net/aspose.slides/fieldtype/header/) | Πεδίο κεφαλίδας· δείτε τις περιορισμένες θέσεις κράτησης και μορφοποίησης παρακάτω. |
| [Footer](https://reference.aspose.com/slides/el/net/aspose.slides/fieldtype/footer/) | Πεδίο υποσέλιδου. |

Για παράδειγμα, το [DateTime3](https://reference.aspose.com/slides/el/net/aspose.slides/fieldtype/datetime3/) αντιπροσωπεύει ημέρα, πλήρες όνομα μήνα και έτος στα Αγγλικά. Πρόκειται για προκαθορισμένες μορφές πεδίου, όχι αυθαίρετες συμβολοσειρές μορφοποίησης ημερομηνίας .NET. Το [LanguageId](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseportionformat/languageid/) του τμήματος και η εφαρμογή που επεξεργάζεται την παρουσίαση μπορούν να επηρεάσουν το εμφανιζόμενο αποτέλεσμα.

## **Δημιουργία Πεδίου από Εσωτερική Συμβολοσειρά**

Η υπερφόρτωση με συμβολοσειρά του [AddField](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/addfield/) δέχεται έναν εσωτερικό ταυτοποιητή πεδίου. Χρησιμοποιήστε την όταν διατηρείτε έναν ταυτοποιητή που παρέχεται από άλλη εφαρμογή χωρίς προκαθορισμένη τιμή. Μπορείτε επίσης να δημιουργήσετε ένα [FieldType](https://reference.aspose.com/slides/el/net/aspose.slides/fieldtype/fieldtype/) από τον ταυτοποιητή. Το [IFieldType.InternalString](https://reference.aspose.com/slides/el/net/aspose.slides/ifieldtype/internalstring/) εκθέτει αυτόν τον ταυτοποιητή για έλεγχο.

Αυτό το παράδειγμα αποθηκεύει ένα πεδίο `custom-report-id` ειδικό για την εφαρμογή με το εφεδρικό κείμενο `Report-042`. Ο ταυτοποιητής δεν καταχωρεί υπολογισμό: το Aspose.Slides δεν δημιουργεί IDs αναφοράς για άγνωστο τύπο. Η εφαρμογή που καταλαβαίνει αυτόν τον ταυτοποιητή πρέπει να παρέχει τη σημασία του και να ενημερώνει την τιμή του.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

Μετά από αυτόν τον κυκλικό έλεγχο PPTX, ο τύπος είναι `custom-report-id` και το κείμενο είναι `Report-042`. Η μεταβίβαση μιας συμβολοσειράς όπως `yyyy-MM-dd` θα ονόμαζε έναν τύπο πεδίου· δεν θα διαμορφώσει προσαρμοσμένη μορφή ημερομηνίας. Για σταθερή ημερομηνία σε αυθαίρετη μορφή, χρησιμοποιήστε κανονικό κείμενο.

## **Επιθεώρηση, Τροποποίηση και Κατάργηση Πεδίου Ημερομηνίας/Ώρας**

Αναγνώστε και αλλάξτε ένα υπάρχον πεδίο μέσω του [IField.Type](https://reference.aspose.com/slides/el/net/aspose.slides/ifield/type/). Ελέγξτε ότι το πεδίο υπάρχει πριν αποκτήσετε πρόσβαση στον τύπο του. Για να σταματήσετε αυτόματες ενημερώσεις, καλέστε το [IPortion.RemoveField](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/removefield/). Αυτό διατηρεί το τμήμα και το τρέχον κείμενό του ενώ αφαιρεί τη συσχέτιση πεδίου. Εάν χρειάζεστε μια συγκεκριμένη σταθερή τιμή, ορίστε αυτό το κείμενο μετά την κατάργηση του πεδίου.

Για τη ρύθμιση API που σχετίζεται με την επεξεργασία πεδίων ημερομηνίας/ώρας, δείτε το [Presentation.CurrentDateTime](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/currentdatetime/). Το παρακάτω παράδειγμα χρησιμοποιεί μια ρητή ημερομηνία έγκρισης κατά τη μετατροπή ενός πεδίου σε κανονικό κείμενο.

Κατεβάστε το [sample.pptx](sample.pptx) και τοποθετήστε το στον τρέχοντα φάκελο εργασίας. Περιέχει δύο ονομαστικά κείμενα σχήματα, `UpdatedAt` και `ApprovedDate`, καθένα με πεδίο ημερομηνίας/ώρας, καθώς και κανονικές ετικέτες κειμένου. Το παρακάτω παράδειγμα διασχίζει τα κείμενα σε επίπεδο κορυφής στις κανονικές διαφάνειες. Μετατρέπει τα πεδία ημερομηνίας/ώρας σε μορφή μακράς ημερομηνίας και τα κάνει πλάγια, διατηρώντας τις άλλες μορφοποιήσεις τους. Μόνο τα πεδία στο `ApprovedDate` μετατρέπονται σε σταθερό κείμενο.

Το δείγμα αναγνωρίζει τους ενσωματωμένους εσωτερικούς ταυτοποιητές `datetime` και `datetime1` έως `datetime13`. Οι ομάδες, πίνακες, σημειώσεις, διατάξεις και κύριοι δεσμοί απαιτούν διάσχιση των δικών τους περιεκτών κειμένου και εκτός του πεδίου αυτού του παραδείγματος.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

Μετά το άνοιγμα ξανά, το `UpdatedAt` έχει τύπο `datetime3` και παραμένει δυναμικό. Το `ApprovedDate` δεν έχει πεδίο και περιέχει `05 April 2030`. Και τα δύο τμήματα ημερομηνίας είναι πλάγια, και το αρχικό μέγεθος γραμματοσειράς, η έντονη ρύθμιση και το χρώμα παραμένουν αμετάβλητα. Οι κανονικές ετικέτες κειμένου παραμένουν όπως ήταν. Η επαλήθευση διαβάζει το πρώτο τμήμα των δύο γνωστών σχημάτων στο παρεχόμενο δείγμα.

## **Διατήρηση Μορφοποίησης Κειμένου**

Δουλέψτε με το υπάρχον τμήμα κατά την προσθήκη πεδίου, την αλλαγή του τύπου ή την κατάργησή του. Αυτές οι λειτουργίες διατηρούν τη μορφοποίηση του τμήματος. Χρησιμοποιήστε το [IPortion.PortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/portionformat/) για να αλλάξετε μόνο τις απαιτούμενες ιδιότητες, όπως κάνουν τα παραδείγματα για χρώμα ή πλάγια.

Αποφύγετε την αναδόμηση ολόκληρου πλαισίου κειμένου μόνο για την ενημέρωση ενός πεδίου: κάτι τέτοιο μπορεί να χάσει τα αρχικά όρια των τμημάτων και τη δική τους μορφοποίηση. Επίσης, διακρίνετε τη ρητά ορισμένη μορφοποίηση από αυτήν που κληρονομείται από την παράγραφο, τη διάταξη ή το θέμα. Δείτε το [Text Formatting](/slides/el/net/text-formatting/) για πιο ευρείες επιλογές μορφοποίησης.

## **Πεδία και Κράτησεις Κεφαλίδας/Υποσέλιδου**

Ένα πεδίο αποτελεί μέρος ενός τμήματος κειμένου. Μια κράτηση (placeholder) είναι ένα σχήμα με ρόλο παρουσίασης, όπως υποσέλιδο ή αριθμός διαφάνειας. Η προσθήκη πεδίου σε ένα κανονικό πλαίσιο κειμένου δεν μετατρέπει αυτό το σχήμα σε κράτηση.

Οι διαχειριστές κεφαλίδας/υποσέλιδου ελέγχουν το κείμενο κράτησης και την ορατότητα σε διαφάνειες, διατάξεις και κύρια πρότυπα, συμπεριλαμβανομένης της διάδοσης σε εξαρτημένες διαφάνειες. Ένα πεδίο αριθμού σε προσαρμοσμένο πλαίσιο κειμένου μπορεί επομένως να είναι χρήσιμο ακόμη και αν δεν χρησιμοποιείτε την κράτηση αριθμού διαφάνειας. Αντίστροφα, η αλλαγή ορατότητας της κράτησης δεν αφαιρεί ένα πεδίο από ένα μη σχετικό πλαίσιο κειμένου.

Οι προκαθορισμένοι τύποι κεφαλίδας και υποσέλιδου δεν δημιουργούν τις αντίστοιχες κρατήσεις ούτε παρέχουν το περιεχόμενό τους. Συγκεκριμένα, μια κανονική διαφάνεια PowerPoint δεν έχει κράτηση κεφαλίδας· οι κεφαλίδες ανήκουν στις σελίδες σημειώσεων και τα φυλλάδια. Μην υποθέτετε ότι ένα πεδίο κεφαλίδας ή υποσέλιδου σε ένα αυθόρμητο σχήμα θα αποκτήσει αυτόματα το κείμενο που ρυθμίστηκε μέσω του διαχειριστή κράτησης. Για αυτή τη ροή εργασίας, δείτε το [Presentation Headers and Footers](/slides/el/net/presentation-header-and-footer/).

## **Περιορισμοί PPTX και PPT**

Ελέγξτε τόσο τον τύπο του πεδίου όσο και το προκύπτον κείμενο μετά την αποθήκευση και επανεκκίνηση. Η διατήρηση ενός ταυτοποιητή δεν αποδεικνύει ότι μια εφαρμογή μπορεί να υπολογίσει ή να εμφανίσει την τιμή του.

| Μορφή | Συμπεριφορά πεδίου και περιορισμοί |
|---|---|
| PPTX | Αποθηκεύει εσωτερικούς ταυτοποιητές πεδίων μαζί με το κείμενο του πεδίου. Σε ελέγχους κυκλικής λειτουργίας, οι προκαθορισμένοι τύποι και ο προσαρμοσμένος ταυτοποιητής που χρησιμοποιήθηκε παραπάνω διατηρήθηκαν μετά την αποθήκευση και το άνοιγμα ξανά. Ο άγνωστος προσαρμοσμένος τύπος κράτησε το εφεδρικό κείμενό του· δεν απέκτησε αυτόματο λογικό υπολογισμό. Μια άλλη εφαρμογή μπορεί να αντιμετωπίσει διαφορετικά τους ανεsupported ταυτοποιητές. |
| PPT | Χρησιμοποιεί κληρονομικές αναπαραστάσεις πεδίου και έχει περιορισμένη συμβατότητα. Σε έλεγχο κυκλικής λειτουργίας, τα πεδία αριθμού διαφάνειας και τα προκαθορισμένα πεδία ημερομηνίας/ώρας διατήρησαν τη λειτουργία τους μετά την αποθήκευση και το άνοιγμα ξανά. Ένα προσαρμοσμένο πεδίο σε ένα κανονικό πλαίσιο κειμένου διαφάνειας άνοιξε ξανά με τον ταυτοποιητή του αλλά με κείμενο `*`; ένα πεδίο κεφαλίδας στο ίδιο πλαίσιο παρήγαγε επίσης `*`. Μην βασίζεστε σε προσαρμοσμένα πεδία ή μη υποστηριζόμενα συμφραζόμενα πεδίου να διατηρούν το ορατό κείμενό τους. |

Για φορητό, σταθερό αποτέλεσμα, μετατρέψτε τα μη υποστηριζόμενα πεδία σε κανονικό κείμενο και ορίστε ρητά την τιμή που θέλετε πριν την αποθήκευση. Αυτό διατηρεί το επιλεγμένο κείμενο αλλά σταματά εκ προθέσεων τις αυτόματες ενημερώσεις. Δοκιμάστε επίσης την εφαρμογή‑προορισμό όταν η δική της επαναϋπολογισμός πεδίου αποτελεί μέρος της ροής εργασίας σας.

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Πώς μπορώ να διακρίνω αν ένας εμφανιζόμενος αριθμός ή ημερομηνία είναι πεδίο;**  
Εξετάστε το [IPortion.Field](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/field/). Μια μη‑null τιμή υποδεικνύει πεδίο· το εμφανιζόμενο κείμενο μόνο του δεν μπορεί να το αποδείξει.

**Αφαιρεί η κατάργηση ενός πεδίου το κείμενο ή τη μορφοποίησή του;**  
Όχι. Το [RemoveField](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/removefield/) μετατρέπει το υπάρχον τμήμα σε κανονικό κείμενο. Ορίστε μια ρητή τιμή μετά αν χρειάζεστε μια συγκεκριμένη παγωμένη ημερομηνία ή εφεδρική τιμή.

**Μπορεί μια εσωτερική συμβολοσειρά να ορίσει νέα μορφή ημερομηνίας ή τύπο;**  
Όχι. Αναγνωρίζει έναν τύπο πεδίου. Ένας άγνωστος ταυτοποιητής δεν παρέχει εκτιμητή ή μοτίδο μορφοποίησης ημερομηνίας .NET. Χρησιμοποιήστε έναν υποστηριζόμενο προκαθορισμένο τύπο ή μορφοποιήστε την τιμή εσείς ως κανονικό κείμενο.

**Γιατί να ελέγξετε ξανά μια παρουσίαση μετά την αποθήκευση της;**  
Οι ταυτοποιητές πεδίου, το υπολογισμένο κείμενο και η μορφοποίηση είναι ξεχωριστά στοιχεία που πρέπει να επαληθευτούν. Η μετατροπή μορφής μπορεί να αλλάξει το ορατό αποτέλεσμα ακόμη και όταν ο ταυτοποιητής πεδίου παραμένει.