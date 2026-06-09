---
title: Αφαίρεση διαφανειών από παρουσιάσεις σε C++
linktitle: Αφαίρεση διαφάνειας
type: docs
weight: 30
url: /el/cpp/remove-slide-from-presentation/
keywords:
- αφαίρεση διαφάνειας
- διαγραφή διαφάνειας
- αφαίρεση αχρησιμοποίητης διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Αφαιρέστε εύκολα διαφάνειες από παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για C++. Λάβετε σαφή παραδείγματα κώδικα και βελτιώστε τη ροή εργασίας σας."
---
## **Εισαγωγή**

Εάν μια διαφάνεια (ή τα περιεχόμενά της) γίνει περιττή, μπορείτε να τη διαγράψετε. Η Aspose.Slides παρέχει την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) που ενσωματώνει το [ISlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/), ένα αποθετήριο για όλες τις διαφάνειες σε μια παρουσίαση. Χρησιμοποιώντας δείκτες (αναφορά ή δείκτη) για ένα γνωστό αντικείμενο [ISlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/), μπορείτε να καθορίσετε τη διαφάνεια που θέλετε να αφαιρέσετε. 

## **Αφαίρεση διαφάνειας με αναφορά**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε μια αναφορά στη διαφάνεια που θέλετε να αφαιρέσετε μέσω του ID ή του Index της.
1. Αφαιρέστε τη διαφάνεια που αναφέρεται από την παρουσίαση.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας C++ σας δείχνει πώς να αφαιρέσετε μια διαφάνεια μέσω της αναφοράς της: 

```c++
	// Η διαδρομή προς τον φάκελο εγγράφων
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Προσεγγίζει μια διαφάνεια μέσω του δείκτη της στη συλλογή διαφανειών
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Αφαιρεί μια διαφάνεια μέσω της αναφοράς της
	pres->get_Slides()->Remove(slide);

	// Αποθηκεύει τη τροποποιημένη παρουσίαση
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Αφαίρεση διαφάνειας με δείκτη**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αφαιρέστε τη διαφάνεια από την παρουσίαση μέσω της θέσης δείκτη της.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας C++ σας δείχνει πώς να αφαιρέσετε μια διαφάνεια μέσω του δείκτη της: 

```c++
	// Η διαδρομή προς τον φάκελο εγγράφων
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Αφαιρεί μια διαφάνεια μέσω του δείκτη της
	pres->get_Slides()->RemoveAt(0);

	// Αποθηκεύει τη τροποποιημένη παρουσίαση
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Αφαίρεση αχρησιμοποίητων διαφανειών διάταξης**

Η Aspose.Slides παρέχει τη μέθοδο [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (από την κλάση [Compress](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/)) ώστε να μπορείτε να διαγράψετε ανεπιθύμητες και αχρησιμοποίητες διαφάνειες διάταξης. Αυτός ο κώδικας C++ σας δείχνει πώς να αφαιρέσετε μια διαφάνεια διάταξης από μια παρουσίαση PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Αφαίρεση αχρησιμοποίητων κύριων διαφανειών**

Η Aspose.Slides παρέχει τη μέθοδο [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (από την κλάση [Compress](https://reference.aspose.com/slides/el/cpp/aspose.slides.lowcode/compress/)) ώστε να μπορείτε να διαγράψετε ανεπιθύμητες και αχρησιμοποίητες κύριες διαφάνειες. Αυτός ο κώδικας C++ σας δείχνει πώς να αφαιρέσετε μια κύρια διαφάνεια από μια παρουσίαση PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Συχνές ερωτήσεις**

**Τι συμβαίνει με τους δείκτες διαφανειών μετά τη διαγραφή μιας διαφάνειας;**

Μετά τη διαγραφή, η [collection](https://reference.aspose.com/slides/el/cpp/aspose.slides/slidecollection/) επαναδιατάσσεται: κάθε επόμενη διαφάνεια μετατοπίζεται αριστερά κατά μία θέση, οπότε οι προηγούμενοι αριθμοί δείκτη γίνονται ξεπερασμένοι. Εάν χρειάζεστε σταθερή αναφορά, χρησιμοποιήστε το μόνιμο ID της κάθε διαφάνειας αντί για το δείκτη της.

**Το ID μιας διαφάνειας διαφέρει από τον δείκτη της και αλλάζει όταν διαγράφονται γειτονικές διαφάνειες;**

Ναι. Ο δείκτης είναι η θέση της διαφάνειας και θα αλλάξει όταν προστίθενται ή αφαιρούνται διαφάνειες. Το ID της διαφάνειας είναι ένας μόνιμος ταυτοποιητής και δεν αλλάζει όταν διαγράφονται άλλες διαφάνειες.

**Πώς επηρεάζει η διαγραφή μιας διαφάνειας τις ενότητες διαφάνειας;**

Εάν η διαφάνεια ανήκε σε μια ενότητα, η ενότητα θα περιέχει απλά μία διαφάνεια λιγότερο. Η δομή της ενότητας παραμένει· εάν μια ενότητα γίνει κενή, μπορείτε να [remove or reorganize sections](/slides/el/cpp/slide-section/) όπως χρειάζεται.

**Τι συμβαίνει με τις σημειώσεις και τα σχόλια που είναι συνδεδεμένα με μια διαφάνεια όταν αυτή διαγραφεί;**

[Notes](/slides/el/cpp/presentation-notes/) και [comments](/slides/el/cpp/presentation-comments/) είναι δεσμευμένα σε εκείνη τη διαφάνεια και αφαιρούνται μαζί της. Το περιεχόμενο των άλλων διαφανειών παραμένει ανεπηρέαστο.

**Πώς διαφέρει η διαγραφή διαφανειών από τον καθαρισμό αχρησιμοποίητων διατάξεων/κυρίων;**

Η διαγραφή αφαιρεί συγκεκριμένες κανονικές διαφάνειες από το αρχείο. Ο καθαρισμός αχρησιμοποίητων διατάξεων/κυρίων αφαιρεί διαφάνειες διάταξης ή κύριες διαφάνειες που δεν χρησιμοποιεί καμία άλλη διαφάνεια, μειώνοντας το μέγεθος του αρχείου χωρίς να αλλάζει το περιεχόμενο των υπολειπόμενων διαφανειών. Οι ενέργειες είναι συμπληρωματικές: συνήθως διαγράψτε πρώτα, έπειτα κάντε καθαρισμό.