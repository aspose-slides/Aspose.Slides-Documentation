---
title: Κινούμενο κείμενο PowerPoint σε .NET
linktitle: Κινούμενο κείμενο
type: docs
weight: 60
url: /el/net/animated-text/
keywords:
- κινούμενο κείμενο
- κίνηση κειμένου
- κινούμενη παράγραφος
- κίνηση παραγράφου
- εφέ κίνησης
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε δυναμικό κείμενο με κίνηση σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για .NET, με παραδείγματα κώδικα C# εύκολα προς κατανόηση και βελτιστοποιημένα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλεύετε με κείμενο με κίνηση στο Aspose.Slides εφαρμόζοντας εφέ κίνησης σε μεμονωμένες παραγράφους και ανακτώντας τα εφέ που έχουν ήδη εκχωρηθεί σε παραγράφους σε ένα πλαίσιο κειμένου. Επικεντρώνεται στις μεθόδους API που χρησιμοποιούνται για την προσθήκη κίνησης σε επίπεδο παραγράφου και για την επιθεώρηση των υπαρχόντων εφέ κίνησης παραγράφων σε μια παρουσίαση.

## **Προσθήκη εφέ κίνησης σε παραγράφους**

Προσθέσαμε τη μέθοδο [**AddEffect()**](https://reference.aspose.com/slides/el/net/aspose.slides.animation/sequence/methods/addeffect/index) στις κλάσεις [**Sequence**](https://reference.aspose.com/slides/el/net/aspose.slides.animation/sequence) και [**ISequence**](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence). Αυτή η μέθοδος σας επιτρέπει να προσθέσετε εφέ κίνησης σε μία μόνο παράγραφο. Αυτό το παράδειγμα κώδικα δείχνει πώς να προσθέσετε ένα εφέ κίνησης σε μία μόνο παράγραφο:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // επιλέξτε παράγραφο για να προσθέσετε εφέ
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // προσθέστε εφέ κίνησης Fly στην επιλεγμένη παράγραφο
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## **Λήψη εφέ κίνησης για παραγράφους**

Μπορεί να χρειαστεί να μάθετε ποια εφέ κίνησης έχουν προστεθεί σε μια παράγραφο — για παράδειγμα, σε ένα σενάριο θέλετε να λάβετε τα εφέ κίνησης σε μια παράγραφο επειδή σχεδιάζετε να τα εφαρμόσετε σε άλλη παράγραφο ή σχήμα.

Το Aspose.Slides for .NET σας επιτρέπει να λάβετε όλα τα εφέ κίνησης που έχουν εφαρμοστεί σε παραγράφους που περιέχονται σε ένα πλαίσιο κειμένου (σχήμα). Αυτό το παράδειγμα κώδικα δείχνει πώς να λάβετε τα εφέ κίνησης σε μια παράγραφο:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```

## **Συχνές ερωτήσεις**

**Πώς διαφέρουν τα εφέ κίνησης κειμένου από τις μεταβάσεις διαφανειών και μπορούν να συνδυαστούν;**

Τα εφέ κίνησης κειμένου ελέγχουν τη συμπεριφορά του αντικειμένου με το πέρασμα του χρόνου σε μια διαφάνεια, ενώ [transitions](/slides/el/net/slide-transition/) ελέγχουν πώς αλλάζουν οι διαφάνειες. Είναι ανεξάρτητα και μπορούν να χρησιμοποιηθούν μαζί· η σειρά αναπαραγωγής καθορίζεται από το χρονοδιάγραμμα των εφέ κίνησης και τις ρυθμίσεις των μεταβάσεων.

**Διατηρούνται τα εφέ κίνησης κειμένου κατά την εξαγωγή σε PDF ή εικόνες;**

Όχι. Τα PDF και οι εικόνες bitmap είναι στατικά, επομένως βλέπετε μια μοναδική κατάσταση της διαφάνειας χωρίς κίνηση. Για να διατηρήσετε την κίνηση, χρησιμοποιήστε εξαγωγή σε [video](/slides/el/net/convert-powerpoint-to-video/) ή [HTML](/slides/el/net/export-to-html5/).

**Λειτουργούν τα εφέ κίνησης κειμένου σε διατάξεις και στο master της διαφάνειας;**

Τα εφέ που εφαρμόζονται σε αντικείμενα διατάξεων/μαστερ κληρονομούνται από τις διαφάνειες, αλλά το χρονοδιάγραμμα και η αλληλεπίδρασή τους με εφέ κίνησης επιπέδου διαφάνειας εξαρτώνται από την τελική ακολουθία στη διαφάνεια.