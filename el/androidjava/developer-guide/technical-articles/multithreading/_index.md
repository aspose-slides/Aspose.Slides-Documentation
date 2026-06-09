---
title: Πολυνηματισμός στο Aspose.Slides για Android μέσω Java
linktitle: Πολυνηματισμός
type: docs
weight: 310
url: /el/androidjava/multithreading/
keywords:
- πολυνηματισμός
- πολλαπλά νήματα
- παράλληλη εργασία
- μετατροπή διαφανειών
- διαφάνειες σε εικόνες
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Ο πολυνηματισμός στο Aspose.Slides για Android μέσω Java ενισχύει την επεξεργασία PowerPoint και OpenDocument. Ανακαλύψτε τις βέλτιστες πρακτικές για αποδοτικές ροές εργασίας παρουσίασης."
---
## **Εισαγωγή**

Ενώ η παράλληλη εργασία με παρουσιάσεις είναι δυνατή (εκτός από την ανάλυση/φόρτωση/κλωνοποίηση) και τα πάντα κυλούν ομαλά (τις περισσότερες φορές), υπάρχει μικρή πιθανότητα να λάβετε εσφαλμένα αποτελέσματα όταν χρησιμοποιείτε τη βιβλιοθήκη σε πολλά νήματα.

Συστήνουμε έντονα να **μην** χρησιμοποιείτε μια ενιαία [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) παρουσία σε περιβάλλον πολλαπλών νημάτων, διότι μπορεί να προκαλέσει απρόβλεπτα σφάλματα ή αποτυχίες που δεν εντοπίζονται εύκολα.

ΔΕΝ είναι ασφαλές να φορτώνετε, αποθηκεύετε και/ή κλωνοποιείτε ένα αντίγραφο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) σε πολλά νήματα. Τέτοιες λειτουργίες **δεν** υποστηρίζονται. Εάν χρειάζεται να εκτελέσετε τέτοιες εργασίες, πρέπει να παράλληλοποιήσετε τις λειτουργίες χρησιμοποιώντας πολλαπλές διεργασίες μονονηματικών—και καθεμία από αυτές πρέπει να χρησιμοποιεί τη δική της παρουσία.

## **Μετατροπή Διαφανειών Παρουσίασης σε Εικόνες Παράλληλα**

Ας πούμε ότι θέλουμε να μετατρέψουμε όλες τις διαφάνειες μιας παρουσίασης PowerPoint σε εικόνες PNG παράλληλα. Δεδομένου ότι είναι μη ασφαλές να χρησιμοποιούμε ένα ενιαίο αντικείμενο `Presentation` σε πολλά νήματα, χωρίζουμε τις διαφάνειες της παρουσίασης σε ξεχωριστές παρουσιάσεις και μετατρέπουμε τις διαφάνειες σε εικόνες παράλληλα, χρησιμοποιώντας κάθε παρουσίαση σε ξεχωριστό νήμα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να το κάνουμε.

```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// Εξαγωγή της διαφάνειας i σε ξεχωριστή παρουσίαση.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Μετατροπή της διαφάνειας σε εικόνα σε ξεχωριστή εργασία.
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
			IImage image = null;
			try {
				ISlide slide = slidePresentation.getSlides().get_Item(0);

				image = slide.getImage(imageScale, imageScale);
				String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
				image.save(imageFilePath, ImageFormat.Png);
			} finally {
				if (image != null) image.dispose();
				slidePresentation.dispose();
			}
		}
	}));
}

// Περιμένετε να ολοκληρωθούν όλες οι εργασίες.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```

## **Συχνές Ερωτήσεις**

**Χρειάζεται να καλώ τη ρύθμιση άδειας σε κάθε νήμα;**

Όχι. Αρκεί να γίνει μία φορά ανά διαδικασία/λειτουργικό περιβάλλον πριν ξεκινήσουν τα νήματα. Εάν το [license setup](/slides/el/androidjava/licensing/) μπορεί να κληθεί ταυτόχρονα (π.χ., κατά την αργή αρχικοποίηση), συγχρονίστε αυτήν την κλήση, επειδή η μέθοδος ρύθμισης άδειας δεν είναι ασφαλής ως προς τα νήματα.

**Μπορώ να περάσω αντικείμενα `Presentation` ή `Slide` μεταξύ νήμάτων;**

Η μεταφορά «ζωντανών» αντικειμένων παρουσία μεταξύ νημάτων δεν συνιστάται: χρησιμοποιήστε ανεξάρτητες παρουσίες ανά νήμα ή προδημιουργήστε ξεχωριστές παρουσιάσεις/κουτιά διαφανειών για κάθε νήμα. Αυτή η προσέγγιση ευθυγραμμίζεται με τη γενική σύσταση να μην μοιράζεστε μια ενιαία παρουσία ανάμεσα σε νήματα.

**Είναι ασφαλές να παραλληλοποιήσουμε την εξαγωγή σε διαφορετικές μορφές (PDF, HTML, εικόνες) εφόσον κάθε νήμα έχει τη δική του παρουσία `Presentation`;**

Ναι. Με ανεξάρτητες παρουσίες και ξεχωριστές διαδρομές εξόδου, τέτοιες εργασίες συνήθως παραλληλοποιούνται σωστά· αποφύγετε οποιαδήποτε κοινόχρηστα αντικείμενα παρουσία ή κοινά ροές I/O.

**Τι πρέπει να κάνω με τις παγκόσμιες ρυθμίσεις γραμματοσειράς (φακέλους, αντικαταστάσεις) σε πολυνηματισμό;**

Αρχικοποιήστε όλες τις παγκόσμιες [font settings](/slides/el/androidjava/powerpoint-fonts/) πριν ξεκινήσετε τα νήματα και μην τις αλλάζετε κατά τη διάρκεια της παράλληλης εργασίας. Αυτό εξαλείφει τους αγώνες πρόσβασης σε κοινόχρηστους πόρους γραμματοσειράς.