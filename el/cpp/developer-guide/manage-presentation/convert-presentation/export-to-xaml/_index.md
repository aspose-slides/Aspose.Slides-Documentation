---
title: Εξαγωγή Παρουσιάσεων σε XAML σε C++
linktitle: Παρουσίαση σε XAML
type: docs
weight: 30
url: /el/cpp/export-to-xaml/
keywords:
- εξα��γωγή PowerPoint
- εξα��γωγή OpenDocument
- εξα��γωγή παρουσίασης
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
- εξα��γωγή PPT σε XAML
- εξα��γωγή PPTX σε XAML
- εξα��γωγή ODP σε XAML
- C++
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες PowerPoint και OpenDocument σε XAML σε C++ χρησιμοποιώντας το Aspose.Slides—γρήγορη, χωρίς Office λύση που διατηρεί άθικτη τη διάταξη."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εξάγετε παρουσιάσεις PowerPoint σε XAML χρησιμοποιώντας το Aspose.Slides. Περιλαμβάνει σύντομη εισαγωγή στο XAML, δείχνει πώς να αποθηκεύσετε μια παρουσίαση σε XAML με τις προεπιλεγμένες ρυθμίσεις και επιδεικνύει πώς να προσαρμόσετε την εξαγωγή μέσω [XamlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export.xaml/xamloptions/), συμπεριλαμβανομένης της εξαγωγής κρυφών διαφανειών. Το άρθρο απαντά επίσης σε μερικές συχνές ερωτήσεις σχετικά με τις εναλλακτικές γραμματοσειρές, τη συμβατότητα των XAML stack και τη συμπεριφορά εξαγωγής κρυφών διαφανειών.

## **Σχετικά με το XAML**

Το XAML είναι μια περιγραφική γλώσσα προγραμματισμού που σας επιτρέπει να δημιουργήσετε ή να γράψετε διεπαφές χρήστη για εφαρμογές, ειδικά για εκείνες που χρησιμοποιούν WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) και Xamarin forms.  

Το XAML, το οποίο είναι γλώσσα βασισμένη σε XML, είναι η παραλλαγή της Microsoft για την περιγραφή ενός GUI. Πιθανότατα θα χρησιμοποιείτε έναν σχεδιαστή για να εργαστείτε στα αρχεία XAML τις περισσότερες φορές, αλλά μπορείτε ακόμη να γράψετε και να επεξεργαστείτε το GUI σας.

## **Εξαγωγή Παρουσιάσεων σε XAML με Προεπιλεγμένες Επιλογές**

Αυτός ο κώδικας C++ σας δείχνει πώς να εξάγετε μια παρουσίαση σε XAML με τις προεπιλεγμένες ρυθμίσεις:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## **Εξαγωγή Παρουσιάσεων σε XAML με Προσαρμοσμένες Επιλογές**

Μπορείτε να επιλέξετε επιλογές από το [IXamlOptions](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.xaml.i_xaml_options) interface που ελέγχουν τη διαδικασία εξαγωγής και καθορίζουν πώς το Aspose.Slides εξάγει την παρουσίασή σας σε XAML. 

Για παράδειγμα, εάν θέλετε το Aspose.Slides να προσθέσει κρυφές διαφάνειες από την παρουσίασή σας όταν την εξάγετε σε XAML, μπορείτε να περάσετε true στη μέθοδο [set_ExportHiddenSlides()](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). Δείτε αυτό το παράδειγμα κώδικα C++:

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```

## **FAQ**

**Πώς μπορώ να διασφαλίσω προβλέψιμες γραμματοσειρές εάν η αρχική γραμματοσειρά δεν είναι διαθέσιμη στη μηχανή;**

Χρησιμοποιήστε [set_DefaultRegularFont](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) στο [XamlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export.xaml/xamloptions/) — χρησιμοποιείται ως εναλλακτική γραμματοσειρά όταν λείπει η αρχική. Αυτό βοηθά στην αποφυγή απροσδόκητων αντικαταστάσεων.

**Το εξαγόμενο XAML προορίζεται μόνο για WPF ή μπορεί να χρησιμοποιηθεί και σε άλλα XAML stacks;**

Το XAML είναι μια γενική γλώσσα σήμανσης UI που χρησιμοποιείται σε WPF, UWP και Xamarin.Forms. Η εξαγωγή στοχεύει στη συμβατότητα με τα Microsoft XAML stacks· η ακριβής συμπεριφορά και η υποστήριξη για συγκεκριμένες δομές εξαρτώνται από την πλατφόρμα-στόχο. Δοκιμάστε το σήμανση στο περιβάλλον σας.

**Υποστηρίζονται οι κρυφές διαφάνειες και πώς μπορώ να αποτρέψω την προεπιλεγμένη εξαγωγή τους;**

Από προεπιλογή, οι κρυφές διαφάνειες δεν περιλαμβάνονται. Μπορείτε να ελέγξετε αυτή τη συμπεριφορά μέσω [set_ExportHiddenSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) στο [XamlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export.xaml/xamloptions/) — κρατήστε το απενεργοποιημένο εάν δεν χρειάζεστε την εξαγωγή τους.