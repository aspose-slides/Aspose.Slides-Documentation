---
title: "Απόδοση Διαφανειών Παρουσίασης ως Εικόνες SVG σε .NET"
linktitle: "Διαφάνεια σε SVG"
type: docs
weight: 50
url: /el/net/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint σε SVG"
- "παρουσίαση σε SVG"
- "διαφάνεια σε SVG"
- "PPT σε SVG"
- "PPTX σε SVG"
- "αποθήκευση PPT ως SVG"
- "αποθήκευση PPTX ως SVG"
- "εξαγωγή PPT σε SVG"
- "εξαγωγή PPTX σε SVG"
- "απόδοση διαφάνειας"
- "μετατροπή διαφάνειας"
- "εξαγωγή διαφάνειας"
- "διανυσματική εικόνα"
- "PowerPoint"
- "παρουσίαση"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Μάθετε πώς να αποδίδετε διαφάνειες PowerPoint ως εικόνες SVG χρησιμοποιώντας το Aspose.Slides για .NET. Υψηλής ποιότητας γραφικά με απλά παραδείγματα κώδικα C#."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να αποδίδετε διαφάνειες παρουσίασης ως εικόνες SVG χρησιμοποιώντας το Aspose.Slides. Περιγράφει τη μορφή SVG και τα πλεονεκτήματά της, συμπεριλαμβανομένης της κλιμακωσιμότητας, της προσβασιμότητας και της καταλληλότητας για ανάπτυξη ιστού.

Θα μάθετε πώς να φορτώνετε ένα αρχείο παρουσίασης, να διασχίζετε τις διαφάνειές του και να αποθηκεύετε κάθε διαφάνεια ως ξεχωριστό αρχείο SVG. Το άρθρο καλύπτει τις μορφές παρουσίασης PowerPoint και OpenDocument, συμπεριλαμβανομένων των PPT, PPTX, ODP και PPS, και δείχνει πώς να εκτελείτε τη μετατροπή προγραμματιστικά με την κλάση `Presentation` και τη μέθοδο `WriteAsSvg`.

## **Μορφή SVG**
Το SVG—συντομογραφία του Scalable Vector Graphics—είναι ένας τυποποιημένος τύπος ή μορφή γραφικών που χρησιμοποιείται για την απόδοση δισδιάστατων εικόνων. Το SVG αποθηκεύει τις εικόνες ως διανύσματα σε XML με λεπτομέρειες που ορίζουν τη συμπεριφορά ή την εμφάνισή τους.

Το SVG είναι μία από τις λίγες μορφές εικόνας που πληρούν πολύ υψηλά πρότυπα όσον αφορά: κλιμακωσιμότητα, διαδραστικότητα, απόδοση, προσβασιμότητα, προγραμματισσιμότητα και άλλα. Για αυτούς τους λόγους, χρησιμοποιείται ευρέως στην ανάπτυξη ιστού.

Μπορεί να θέλετε να χρησιμοποιήσετε αρχεία SVG όταν χρειάζεται να

- **εκτυπώσετε την παρουσίασή σας σε *πολύ μεγάλο φορμάτ*.** Τα SVG μπορούν να κλιμακώνονται σε οποιαδήποτε ανάλυση ή επίπεδο. Μπορείτε να αλλάζετε το μέγεθος των SVG όσες φορές απαιτείται χωρίς να θυσιάζετε την ποιότητα.
- **χρησιμοποιήσετε διαγράμματα και γραφήματα από τις διαφάνειές σας σε *διαφορετικά μέσα ή πλατφόρμες*.** Οι περισσότεροι αναγνώστες μπορούν να ερμηνεύσουν αρχεία SVG.
- **χρησιμοποιήσετε τα *μικρότερα δυνατότερα μεγέθη εικόνας*.** Τα SVG είναι γενικά μικρότερα από τα αντίστοιχα υψηλής ανάλυσης αρχεία σε άλλες μορφές, ειδικά σε μορφές βασισμένες σε bitmap (JPEG ή PNG).

## **Απόδοση Διαφάνειας ως Εικόνα SVG**

Το Aspose.Slides for .NET σάς επιτρέπει να εξάγετε διαφάνειες στις παρουσιάσεις σας ως εικόνες SVG. Ακολουθήστε τα παρακάτω βήματα για να δημιουργήσετε εικόνες SVG:

_Βήματα: Μετατροπές PowerPoint σε SVG σε C#_

Ο παρακάτω κώδικας δείγματος εξηγεί αυτές τις μετατροπές χρησιμοποιώντας .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Βήματα: Μετατροπή PowerPoint σε SVG σε C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Βήματα: Μετατροπή PPT σε SVG σε C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Βήματα: Μετατροπή PPTX σε SVG σε C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Βήματα: Μετατροπή ODP σε SVG σε C#</strong></a>

_Βήματα κώδικα:_

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
   * _.ppt_ επέκταση για φόρτωση αρχείου **PPT** μέσα στην κλάση _Presentation_.
   * _.pptx_ επέκταση για φόρτωση αρχείου **PPTX** μέσα στην κλάση _Presentation_.
   * _.odp_ επέκταση για φόρτωση αρχείου **ODP** μέσα στην κλάση _Presentation_.
   * _.pps_ επέκταση για φόρτωση αρχείου **PPS** μέσα στην κλάση _Presentation_.
2. Διασχίστε όλες τις διαφάνειες στην παρουσίαση.
3. Γράψτε κάθε διαφάνεια στο δικό της αρχείο SVG μέσω FileStream.

{{% alert color="primary" %}} 

Μπορεί να θέλετε να δοκιμάσετε την [ελεύθερη διαδικτυακή εφαρμογή](https://products.aspose.app/slides/el/conversion/ppt-to-svg) στην οποία υλοποιήσαμε τη λειτουργία μετατροπής PPT σε SVG από το Aspose.Slides for .NET.

{{% /alert %}} 

Αυτό το δείγμα κώδικα σε C# σας δείχνει πώς να μετατρέψετε PowerPoint σε SVG χρησιμοποιώντας το Aspose.Slides:

``` csharp
// Το αντικείμενο Presentation μπορεί να φορτώσει μορφές PowerPoint όπως PPT, PPTX, ODP κ.ά.
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```

## **Συχνές Ερωτήσεις**

**Γιατί το παραγόμενο SVG μπορεί να φαίνεται διαφορετικό σε διαφορετικούς φυλλομετρητές;**

Η υποστήριξη συγκεκριμένων χαρακτηριστικών SVG υλοποιείται διαφορετικά από τις μηχανές των φυλλομετρητών. Οι παράμετροι [SVGOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgoptions/) βοηθούν στην εξομάλυνση των ασυμβατοτήτων.

**Μπορεί να εξαχθεί όχι μόνο η διαφάνεια αλλά και μεμονωμένα σχήματα σε SVG;**

Ναι. Κάθε [σχήμα μπορεί να αποθηκευθεί ως ξεχωριστό SVG](https://reference.aspose.com/slides/el/net/aspose.slides/shape/writeassvg/), κάτι που είναι βολικό για εικονίδια, εικονογράμματα και επαναχρησιμοποίηση γραφικών.

**Μπορούν πολλές διαφάνειες να συνδυαστούν σε ένα μόνο SVG (ταινία/έγγραφο);**

Το τυπικό σενάριο είναι μία διαφάνεια → ένα SVG. Ο συνδυασμός πολλαπλών διαφανειών σε ένα μοναδικό καμβά SVG είναι στάδιο μετα-επεξεργασίας που γίνεται σε επίπεδο εφαρμογής.

## **Δείτε Επίσης** 

Αυτό το άρθρο καλύπτει επίσης τα παρακάτω θέματα. Οι κώδικες είναι ίδιοι με τους παραπάνω.

_Μορφή_: **PowerPoint**
- [C# PowerPoint to SVG Code](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG Programmatically](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG Library](#csharp-powerpoint-to-svg)
- [C# Save PowerPoint as SVG](#csharp-powerpoint-to-svg)
- [C# Generate SVG from PowerPoint](#csharp-powerpoint-to-svg)
- [C# Create SVG from PowerPoint](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG Converter](#csharp-powerpoint-to-svg)

_Μορφή_: **PPT**
- [C# PPT to SVG Code](#csharp-ppt-to-svg)
- [C# PPT to SVG API](#csharp-ppt-to-svg)
- [C# PPT to SVG Programmatically](#csharp-ppt-to-svg)
- [C# PPT to SVG Library](#csharp-ppt-to-svg)
- [C# Save PPT as SVG](#csharp-ppt-to-svg)
- [C# Generate SVG from PPT](#csharp-ppt-to-svg)
- [C# Create SVG from PPT](#csharp-ppt-to-svg)
- [C# PPT to SVG Converter](#csharp-ppt-to-svg)

_Μορφή_: **PPTX**
- [C# PPTX to SVG Code](#csharp-pptx-to-svg)
- [C# PPTX to SVG API](#csharp-pptx-to-svg)
- [C# PPTX to SVG Programmatically](#csharp-pptx-to-svg)
- [C# PPTX to SVG Library](#csharp-pptx-to-svg)
- [C# Save PPTX as SVG](#csharp-pptx-to-svg)
- [C# Generate SVG from PPTX](#csharp-pptx-to-svg)
- [C# Create SVG from PPTX](#csharp-pptx-to-svg)
- [C# PPTX to SVG Converter](#csharp-pptx-to-svg)

_Μορφή_: **ODP**
- [C# ODP to SVG Code](#csharp-odp-to-svg)
- [C# ODP to SVG API](#csharp-odp-to-svg)
- [C# ODP to SVG Programmatically](#csharp-odp-to-svg)
- [C# ODP to SVG Library](#csharp-odp-to-svg)
- [C# Save ODP as SVG](#csharp-odp-to-svg)
- [C# Generate SVG from ODP](#csharp-odp-to-svg)
- [C# Create SVG from ODP](#csharp-odp-to-svg)
- [C# ODP to SVG Converter](#csharp-odp-to-svg)