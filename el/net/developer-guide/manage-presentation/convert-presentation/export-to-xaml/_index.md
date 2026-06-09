---
title: Εξαγωγή Παρουσιάσεων σε XAML σε .NET
linktitle: Παρουσίαση σε XAML
type: docs
weight: 30
url: /el/net/export-to-xaml/
keywords:
- εξαγωγή PowerPoint
- εξαγωγή OpenDocument
- εξαγωγή παρουσίασης
- μετατροπή PowerPoint
- μετατροπή OpenDocument
- μετατροπή παρουσίασης
- PowerPoint σε XAML
- OpenDocument σε XAML
- παρουσίαση σε XAML
- PPT σε XAML
- PPTX σε XAML
- ODP σε XAML
- αποθήκευση PPT ως XAML
- αποθήκευση PPTX ως XAML
- αποθήκευση ODP ως XAML
- εξαγωγή PPT σε XAML
- εξαγωγή PPTX σε XAML
- εξαγωγή ODP σε XAML
- .NET
- C#
- Aspose.Slides
description: "Μετατροπή διαφανειών PowerPoint και OpenDocument σε XAML σε .NET χρησιμοποιώντας Aspose.Slides—γρήγορη, λύση χωρίς Office που διατηρεί τη διάταξη σας αμετάβλητη."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εξάγετε παρουσιάσεις PowerPoint σε XAML χρησιμοποιώντας το Aspose.Slides. Περιλαμβάνει μια σύντομη εισήγηση στο XAML, δείχνει πώς να αποθηκεύσετε μια παρουσίαση σε XAML με τις προεπιλεγμένες ρυθμίσεις και παρουσιάζει πώς να προσαρμόσετε την εξαγωγή μέσω [XamlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/xamloptions/), συμπεριλαμβανομένης της εξαγωγής κρυφών διαφανειών. Το άρθρο επίσης απαντά σε μερικές κοινές ερωτήσεις σχετικά με τις εφεδρικές γραμματοσειρές, τη συμβατότητα των XAML στοίβων και τη συμπεριφορά εξαγωγής κρυφών διαφανειών.

## **Σχετικά με το XAML**

Το XAML είναι μια περιγραφική γλώσσα προγραμματισμού που σας επιτρέπει να δημιουργήσετε ή να γράψετε διεπαφές χρήστη για εφαρμογές, ιδιαίτερα για αυτές που χρησιμοποιούν WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) και Xamarin Forms.  
Το XAML, το οποίο είναι μια γλώσσα βασισμένη σε XML, είναι η παραλλαγή της Microsoft για περιγραφή γραφικού περιβάλλοντος χρήστη. Πιθανώς να χρησιμοποιείτε έναν σχεδιαστή για να εργαστείτε στα αρχεία XAML τις περισσότερες φορές, αλλά μπορείτε ακόμη να γράψετε και να επεξεργαστείτε το GUI σας.

## **Εξαγωγή Παρουσιάσεων σε XAML με Προεπιλεγμένες Επιλογές**

Αυτός ο κώδικας C# σας δείχνει πώς να εξάγετε μια παρουσίαση σε XAML με τις προεπιλεγμένες ρυθμίσεις:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## **Εξαγωγή Παρουσιάσεων σε XAML με Προσαρμοσμένες Επιλογές**

Μπορείτε να επιλέξετε επιλογές από τη διεπαφή [IXamlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/ixamloptions) η οποία ελέγχει τη διαδικασία εξαγωγής και καθορίζει πώς το Aspose.Slides εξάγει την παρουσίασή σας σε XAML.  

Για παράδειγμα, εάν θέλετε το Aspose.Slides να προσθέτει κρυφές διαφάνειες από την παρουσίασή σας κατά την εξαγωγή σε XAML, μπορείτε να ορίσετε την ιδιότητα [ExportHiddenSlides](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) σε true. Δείτε αυτόν τον δειγματικό κώδικα C#:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να εξασφαλίσω προβλεπόμενες γραμματοσειρές εάν η αρχική γραμματοσειρά δεν είναι διαθέσιμη στο σύστημα;**

Ορίστε το [DefaultRegularFont](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveoptions/defaultregularfont/) στο [XamlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/xamloptions/) — χρησιμοποιείται ως εφεδρική γραμματοσειρά όταν η αρχική λείπει. Αυτό βοηθά στην αποφυγή ανεπιθύμητων αντικαταστάσεων.

**Απευθύνεται το εξαχθέν XAML μόνο στο WPF ή μπορεί επίσης να χρησιμοποιηθεί σε άλλες στοίβες XAML;**

Το XAML είναι μια γενική γλώσσα σήμανσης UI που χρησιμοποιείται σε WPF, UWP και Xamarin.Forms. Η εξαγωγή στοχεύει στη συμβατότητα με τις στοίβες XAML της Microsoft· η ακριβής συμπεριφορά και η υποστήριξη συγκεκριμένων δομών εξαρτώνται από την πλατφόρμα-στόχο. Δοκιμάστε το σήμαμα στο περιβάλλον σας.

**Υποστηρίζονται οι κρυφές διαφάνειες και πώς μπορώ να αποτρέψω την προεπιλεγμένη εξαγωγή τους;**

Από προεπιλογή, οι κρυφές διαφάνειες δεν περιλαμβάνονται. Μπορείτε να ελέγξετε αυτή τη συμπεριφορά μέσω του [ExportHiddenSlides](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) στο [XamlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/xamloptions/) — διατηρήστε το απενεργοποιημένο εάν δεν χρειάζεται να τις εξάγετε.