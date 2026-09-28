---
title: Ασφάλεια
type: docs
weight: 160
url: /el/net/security/
keywords:
- ασφάλεια
- εξαρτήσεις
- συστατικά τρίτων
- NuGet
- σάρωση ευπάθειας
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση του τρόπου με τον οποίο το Aspose.Slides για .NET επεξεργάζεται παρουσιάσεις, ποια πακέτα NuGet εξαρτάται για κάθε πλαίσιο-στόχο, και ποια συστατικά τρίτων περιλαμβάνει."
---
## **Ασφάλεια στο Aspose.Slides**

Aspose εφαρμόζει βέλτιστες πρακτικές κατά την ανάπτυξη των προϊόντων του.

* Το Aspose.Slides for .NET χρησιμοποιείται για τη διαχείριση παρουσιάσεων και τη μετατροπή τους σε άλλες μορφές. Δεν εκτελεί σενάρια στις παρουσιάσεις. Το Aspose.Slides αναλύει τη δομή της παρουσίασης και επιτρέπει στον κώδικα του τελικού χρήστη να χειρίζεται το μοντέλο αντικειμένων με βολικό τρόπο.
* Το Aspose.Slides λειτουργεί ως βιβλιοθήκη που αναλύει και ερμηνεύει έγγραφα χωρίς να εκτελεί απομακρυσμένο κώδικα. Όλα τα προϊόντα Aspose εκτελούνται στους δικούς σας υπολογιστές. Δεν μεταδίδουν δεδομένα στην Aspose. Η μόνη εξαίρεση είναι μια [metered license](https://purchase.aspose.com/faqs/licensing/metered): εάν χρησιμοποιήσετε μια, επεξεργάζεται μόνο η πληροφορία χρήσης του API σας.
* Τα στοιχεία Aspose εκτελούνται στο ίδιο πλαίσιο χρήστη με κανονικές εφαρμογές. Συνεπώς, τα στοιχεία Aspose δεν αποτελούν κίνδυνο για κρίσιμους πόρους του συστήματος. Επιπλέον, όταν ένα στοιχείο Aspose ανοίγει ένα έγγραφο, οι μακροεντολές δεν εκτελούνται αυτόματα.
* Οι κίνδυνοι που ενέχονται ή σχετίζονται με το πακέτο Microsoft Office δεν ισχύουν για τα στοιχεία Aspose, επομένως τα προϊόντα Aspose είναι πολύ ασφαλή.

## **Εξαρτήσεις NuGet**

Το Aspose.Slides for .NET εξαρτάται από πακέτα που η Microsoft δημοσιεύει στο NuGet. Οι εξαρτήσεις διαφέρουν ανά πακέτο και πλαίσιο-στόχο:

| Πακέτο | Πλαίσιο-στόχος | Εξαρτήσεις |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

Η ενότητα **Dependencies** της σελίδας [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) και της σελίδας [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) στο NuGet αναφέρει την ελάχιστη έκδοση κάθε εξάρτησης για κάθε έκδοση.

Όταν προσθέτετε το Aspose.Slides σε ένα έργο, το NuGet επαναφέρει επίσης τις εξαρτήσεις αυτών των πακέτων. Για να καταγράψετε κάθε πακέτο που το έργο σας επαναφέρει, συμπεριλαμβανομένων των μεταβατικών εξαρτήσεων, εκτελέστε αυτήν την εντολή στο φάκελο του έργου:

```bash
dotnet list package --include-transitive
```

Για να ελέγξετε το ίδιο σύνολο πακέτων έναντι γνωστών ευπαθειών, εκτελέστε:

```bash
dotnet list package --vulnerable --include-transitive
```

Για άλλους τρόπους ελέγχου των πακέτων NuGet, δείτε [Auditing package dependencies for security vulnerabilities](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages).

## **Συστατικά τρίτων**

Το Aspose.Slides περιλαμβάνει κώδικα από ανοιχτού κώδικα συστατικά τρίτων. Είναι μέρος του προϊόντος, όχι ξεχωριστά πακέτα NuGet, οπότε τα εργαλεία που διαβάζουν μόνο εξαρτήσεις NuGet δεν τα εμφανίζουν. Και τα δύο πακέτα περιέχουν το αρχείο *thirdpartylicenses.Aspose.Slides.for.NET.pdf*, το οποίο καταγράφει τα συστατικά και τις άδειές τους:

| Συστατικό | Άδεια που δηλώνεται στην σημείωση |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **Συχνές Ερωτήσεις**

**Ποια συστήματα χρησιμοποιούνται για την παρακολούθηση ευπάθειας στον κώδικα Aspose;**

Εκτελούμε στατική ανάλυση κώδικα για κάθε έκδοση του Aspose.Slides. Μπορούμε να παρέχουμε αναφορές ασφαλείας που αποδεικνύουν ότι ο κώδικας του Aspose.Slides πληροί τα OWASP Top 10.

**Χρησιμοποιεί το Aspose.Slides εξωτερικά πακέτα;**

Ναι. Εξαρτάται από τα πακέτα Microsoft NuGet που αναφέρονται στις [NuGet Dependencies](#nuget-dependencies) και περιλαμβάνει τα συστατικά τρίτων που αναφέρονται στις [Third-Party Components](#third-party-components). Συμπεριλάβετε και τα δύο στην αξιολόγηση ασφαλείας σας και χρησιμοποιήστε `dotnet list package --vulnerable --include-transitive` για να ελέγξετε τα πακέτα NuGet που επαναφέρει το έργο σας.