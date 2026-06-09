---
title: Κινούμενο κείμενο PowerPoint σε C++
linktitle: Κινούμενο κείμενο
type: docs
weight: 60
url: /el/cpp/animated-text/
keywords:
- κινούμενο κείμενο
- κίνηση κειμένου
- κινούμενη παράγραφος
- κίνηση παραγράφου
- εφέ κίνησης
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Δημιουργήστε δυναμικό κείμενο με κίνηση σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για C++, με παραδείγματα κώδικα C++ εύκολα στην παρακολούθηση και βελτιστοποιημένα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργαστείτε με κείμενο με κίνηση στο Aspose.Slides εφαρμόζοντας εφέ κίνησης σε μεμονωμένες παραγράφους και ανακτώντας τα εφέ που έχουν ήδη ανατεθεί σε παραγράφους σε ένα πλαίσιο κειμένου. Επικεντρώνεται στις μεθόδους API που χρησιμοποιούνται για την προσθήκη κίνησης σε επίπεδο παραγράφου και την επιθεώρηση των υπαρχόντων εφέ κίνησης παραγράφων σε μια παρουσίαση.

## **Προσθήκη εφέ κίνησης σε παραγράφους**

Προσθέσαμε τη μέθοδο [**AddEffect()**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) στις κλάσεις [**Sequence**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.sequence) και [**ISequence**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.i_sequence). Αυτή η μέθοδος σάς επιτρέπει να προσθέτετε εφέ κίνησης σε μια μόνο παράγραφο. Αυτό το δείγμα κώδικα σας δείχνει πώς να προσθέσετε ένα εφέ κίνησης σε μια μόνο παράγραφο:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// επιλέξτε παράγραφο για προσθήκη εφέ
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// προσθέστε εφέ κίνησης Fly στην επιλεγμένη παράγραφο
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```

## **Ανάκτηση εφέ κίνησης για παραγράφους**

Μπορεί να θέλετε να ανακαλύψετε τα εφέ κίνησης που προστέθηκαν σε μια παράγραφο· για παράδειγμα, σε ένα σενάριο, μπορεί να θέλετε να λάβετε τα εφέ κίνησης σε μια παράγραφο επειδή σκοπεύετε να εφαρμόσετε αυτά τα εφέ σε άλλη παράγραφο ή σχήμα.

Το Aspose.Slides for C++ σας επιτρέπει να λάβετε όλα τα εφέ κίνησης που εφαρμόζονται σε παραγράφους που περιλαμβάνονται σε ένα πλαίσιο κειμένου (σχήμα). Αυτό το δείγμα κώδικα σας δείχνει πώς να λάβετε τα εφέ κίνησης σε μια παράγραφο:

``` cpp
String dataDir = GetDataPath();
auto pres = System::MakeObject<Presentation>(dataDir + u"Test.pptx");

auto sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(1));

for (auto paragraph : autoShape->get_TextFrame()->get_Paragraphs())
{
	auto effects = sequence->GetEffectsByParagraph(paragraph);

	if (effects->get_Length() > 0)
	{
		Console::WriteLine(String(u"Paragraph \"") + paragraph->get_Text() + u"\" has " + ObjectExt::ToString(effects[0]->get_Type()) + u" effect.");
	}
}
```

## **Συχνές ερωτήσεις**

**Πώς διαφέρουν τα εφέ κίνησης κειμένου από τις μεταβάσεις διαφάνειας και μπορούν να συνδυαστούν;**

Τα εφέ κίνησης κειμένου ελέγχουν τη συμπεριφορά του αντικειμένου με την πάροδο του χρόνου σε μια διαφάνεια, ενώ οι [transitions](/slides/el/cpp/slide-transition/) ελέγχουν πώς αλλάζουν οι διαφάνειες. Είναι ανεξάρτητα και μπορούν να χρησιμοποιηθούν μαζί· η σειρά αναπαραγωγής καθορίζεται από τη γραμμή χρόνου των εφέ κίνησης και τις ρυθμίσεις των μεταβάσεων.

**Διατηρούνται τα εφέ κίνησης κειμένου κατά την εξαγωγή σε PDF ή εικόνες;**

Όχι. Τα PDF και οι ραστερ εικόνες είναι στατικά, έτσι θα δείτε μια μόνο κατάσταση της διαφάνειας χωρίς κίνηση. Για να διατηρήσετε την κίνηση, χρησιμοποιήστε εξαγωγή σε [video](/slides/el/cpp/convert-powerpoint-to-video/) ή [HTML](/slides/el/cpp/export-to-html5/).

**Λειτουργούν τα εφέ κίνησης κειμένου σε διατάξεις και στο κύριο πρότυπο διαφάνειας;**

Τα εφέ που εφαρμόζονται σε αντικείμενα διάταξης/πρότυπου κληρονομούνται από τις διαφάνειες, αλλά ο χρονισμός τους και η αλληλεπίδρασή τους με τα εφέ κίνησης σε επίπεδο διαφάνειας εξαρτώνται από την τελική ακολουθία στη διαφάνεια.