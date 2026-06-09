---
title: Εξαγωγή Παρουσιάσεων σε XAML με JavaScript
linktitle: Παρουσίαση σε XAML
type: docs
weight: 30
url: /el/nodejs-java/export-to-xaml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες PowerPoint και OpenDocument σε XAML με JavaScript χρησιμοποιώντας το Aspose.Slides για Node.js—γρήγορη, λύση χωρίς Office που διατηρεί το σχέδιά σας αμετάβλητο."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εξάγετε παρουσιάσεις PowerPoint σε XAML χρησιμοποιώντας το Aspose.Slides. Περιλαμβάνει μια σύντομη εισαγωγή στο XAML, δείχνει πώς να αποθηκεύσετε μια παρουσίαση σε XAML με προεπιλεγμένες ρυθμίσεις και επιδεικνύει πώς να προσαρμόσετε την εξαγωγή μέσω [XamlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/xamloptions/), συμπεριλαμβανομένης της εξαγωγής κρυφών διαφανειών. Το άρθρο επίσης απαντά σε μερικές κοινές ερωτήσεις σχετικά με τις εφεδρικές γραμματοσειρές, τη συμβατότητα των στοίβων XAML και τη συμπεριφορά εξαγωγής κρυφών διαφανειών.

## **Σχετικά με το XAML**

Το XAML είναι μια περιγραφική γλώσσα προγραμματισμού που επιτρέπει τη δημιουργία ή τη συγγραφή κλάσεων χρήστη για εφαρμογές, ιδιαίτερα για εκείνες που χρησιμοποιούν WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) και Xamarin Forms.

Το XAML, το οποίο είναι μια γλώσσα βασισμένη σε XML, είναι η παραλλαγή της Microsoft για την περιγραφή διεπαφής χρήστη (GUI). Πιθανότατα θα χρησιμοποιείτε έναν σχεδιαστή για να εργάζεστε με αρχεία XAML τις περισσότερες φορές, αλλά μπορείτε ακόμη να γράψετε και να επεξεργαστείτε τη διεπαφή σας.

## **Εξαγωγή Παρουσιάσεων σε XAML με Προεπιλεγμένες Επιλογές**

Αυτός ο κώδικας JavaScript σας δείχνει πώς να εξάγετε μια παρουσίαση σε XAML με προεπιλεγμένες ρυθμίσεις:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Εξαγωγή Παρουσιάσεων σε XAML με Προσαρμοσμένες Επιλογές**

Μπορείτε να επιλέξετε επιλογές από την κλάση [XamlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/XamlOptions) που ελέγχει τη διαδικασία εξαγωγής και καθορίζει πώς το Aspose.Slides εξάγει την παρουσίασή σας σε XAML.

Για παράδειγμα, εάν θέλετε το Aspose.Slides να προσθέσει κρυφές διαφάνειες από την παρουσίασή σας κατά την εξαγωγή σε XAML, μπορείτε να ορίσετε τη μέθοδο [setExportHiddenSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) σε true. Δείτε αυτόν τον δείγμα κώδικα JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να εξασφαλίσω προβλέψιμες γραμματοσειρές αν η αρχική γραμματοσειρά δεν είναι διαθέσιμη στο μηχάνημα;**

Χρησιμοποιήστε το [setDefaultRegularFont](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) στο [XamlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/xamloptions/) — χρησιμοποιείται ως εφεδρική γραμματοσειρά όταν η αρχική λείπει. Αυτό βοηθά στην αποφυγή απροσδόκητων αντικαταστάσεων.

**Η εξαγόμενη XAML προορίζεται μόνο για WPF ή μπορεί επίσης να χρησιμοποιηθεί σε άλλες στοίβες XAML;**

Το XAML είναι μια γενική γλώσσα σήμανσης UI που χρησιμοποιείται σε WPF, UWP και Xamarin.Forms. Η εξαγωγή στοχεύει στη συμβατότητα με τις στοίβες XAML της Microsoft· η ακριβής συμπεριφορά και η υποστήριξη συγκεκριμένων δομών εξαρτώνται από την πλατφόρμα‑στόχο. Δοκιμάστε το σήμα στο περιβάλλον σας.

**Υποστηρίζονται οι κρυφές διαφάνειες και πώς μπορώ να αποτρέψω την εξαγωγή τους από προεπιλογή;**

Από προεπιλογή, οι κρυφές διαφάνειες δεν περιλαμβάνονται. Μπορείτε να ελέγξετε αυτή τη συμπεριφορά μέσω του [setExportHiddenSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) στο [XamlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/xamloptions/) — κρατήστε το απενεργοποιημένο αν δεν χρειάζεστε την εξαγωγή τους.