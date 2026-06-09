---
title: Διαχείριση Γραμματοσειρών σε Παρουσιάσεις Χρησιμοποιώντας Java
linktitle: Διαχείριση Γραμματοσειρών
type: docs
weight: 10
url: /el/java/manage-fonts/
keywords:
- διαχείριση γραμματοσειρών
- ιδιότητες γραμματοσειράς
- παράγραφος
- μορφοποίηση κειμένου
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Έλεγχος γραμματοσειρών σε Java με το Aspose.Slides: ενσωμάτωση, αντικατάσταση και φόρτωση προσαρμοσμένων γραμματοσειρών για να διατηρούνται οι παρουσιάσεις PPT, PPTX και ODP καθαρές, ασφαλείς για το εμπορικό σήμα και συνεπείς."
---
## **Επισκόπηση**

Aspose.Slides σάς επιτρέπει να διαχειρίζεστε ιδιότητες γραμματοσειράς στο κείμενο της παρουσίασης απευθείας από τον κώδικά σας. Μπορείτε να έχετε πρόσβαση στο κείμενο στις διαφάνειες μέσω σχημάτων, πλαισίων κειμένου, παραγράφων και τμημάτων, και στη συνέχεια να εφαρμόζετε μορφοποίηση στο επιλεγμένο κείμενο.

Αυτό το άρθρο εξηγεί πώς να διαμορφώσετε ιδιότητες σχετικές με τη γραμματοσειρά για υπάρχον κείμενο σε μια παρουσίαση, συμπεριλαμβανομένης της οικογένειας γραμματοσειράς, των στυλ έντονο και πλάγιο, της στοίχισης παραγράφου και του χρώματος γραμματοσειράς. Επίσης, δείχνει πώς να δημιουργήσετε ένα πλαίσιο κειμένου, να προσθέσετε κείμενο σε αυτό και να ορίσετε ιδιότητες γραμματοσειράς όπως οικογένεια γραμματοσειράς, έντονο, πλάγιο, υπογράμμιση, μέγεθος γραμματοσειράς και χρώμα πριν αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX.

## **Διαχείριση Ιδιοτήτων Σχετικών με τη Γραμματοσειρά**
{{% alert color="primary" %}} 

Οι παρουσιάσεις συνήθως περιέχουν τόσο κείμενο όσο και εικόνες. Το κείμενο μπορεί να μορφοποιηθεί με διάφορους τρόπους, είτε για να επισημάνει συγκεκριμένα τμήματα και λέξεις είτε για να συμμορφωθεί με εταιρικά στυλ. Η μορφοποίηση κειμένου βοηθά τους χρήστες να διαφοροποιήσουν την εμφάνιση και το αίσθημα του περιεχομένου της παρουσίασης. Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε το Aspose.Slides for Java για να διαμορφώσετε τις ιδιότητες γραμματοσειράς των παραγράφων κειμένου στις διαφάνειες.
{{% /alert %}} 

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.
1. Πρόσβαση στα σχήματα [Placeholder](https://reference.aspose.com/slides/el/java/com.aspose.slides/placeholder/) στη διαφάνεια και μετατροπή τους σε [AutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/autoshape/).
1. Αποκτήστε το [Paragraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/paragraph/) από το [TextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/textframe/) που εκτίθεται από το [AutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/autoshape/).
1. Στοίχιση της παραγράφου.
1. Πρόσβαση στο κείμενο [Portion](https://reference.aspose.com/slides/el/java/com.aspose.slides/portion/) μιας [Paragraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/paragraph/).
1. Ορίστε τη γραμματοσειρά χρησιμοποιώντας το [FontData](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontdata/) και ορίστε τη **Font** του κειμένου [Portion](https://reference.aspose.com/slides/el/java/com.aspose.slides/portion/) αντίστοιχα.
   1. Ορίστε τη γραμματοσειρά σε έντονη.
   1. Ορίστε τη γραμματοσειρά σε πλάγια.
1. Ορίστε το χρώμα γραμματοσειράς χρησιμοποιώντας το [FillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/) που εκτίθεται από το αντικείμενο [Portion](https://reference.aspose.com/slides/el/java/com.aspose.slides/portion/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων δίνεται παρακάτω. Παίρνει μια ακατάστατη παρουσίαση και μορφοποιεί τις γραμματοσειρές σε μία από τις διαφάνειες. Τα στιγμιότυπα οθόνης που ακολουθούν δείχνουν το αρχείο εισόδου και πώς τα αποσπάσματα κώδικα το αλλάζουν. Ο κώδικας αλλάζει τη γραμματοσειρά, το χρώμα και το στυλ της γραμματοσειράς.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Σχήμα: Το κείμενο στο αρχείο εισόδου**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Σχήμα: Το ίδιο κείμενο με ενημερωμένη μορφοποίηση**|

```java
// Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει αρχείο PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Πρόσβαση σε διαφάνεια χρησιμοποιώντας τη θέση της
	ISlide slide = pres.getSlides().get_Item(0);

	// Πρόσβαση στο πρώτο και δεύτερο placeholder στη διαφάνεια και μετατροπή τους σε AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Πρόσβαση στην πρώτη Παράγραφο
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Στοίχιση της παραγράφου
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Πρόσβαση στο πρώτο τμήμα
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Ορισμός νέων γραμματοσειρών
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Ανάθεση νέων γραμματοσειρών στο τμήμα
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Ορισμός γραμματοσειράς σε Έντονη
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Ορισμός γραμματοσειράς σε Πλάγια
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Ορισμός χρώματος γραμματοσειράς
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// Αποθήκευση του PPTX στον δίσκο
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Ορισμός Ιδιοτήτων Γραμματοσειράς Κειμένου**
{{% alert color="primary" %}} 

Όπως αναφέρεται στη **Διαχείριση Ιδιοτήτων Σχετικών με τη Γραμματοσειρά**, ένα [Portion](https://reference.aspose.com/slides/el/java/com.aspose.slides/portion/) χρησιμοποιείται για την αποθήκευση κειμένου με παρόμοιο στυλ μορφοποίησης σε μια παράγραφο. Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε το Aspose.Slides for Java για να δημιουργήσετε ένα πλαίσιο κειμένου με κάποιο κείμενο και στη συνέχεια να ορίσετε μια συγκεκριμένη γραμματοσειρά, καθώς και διάφορες άλλες ιδιότητες της κατηγορίας οικογένειας γραμματοσειρών.
{{% /alert %}} 

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα [AutoShape] τύπου **Rectangle** στη διαφάνεια.
1. Αφαιρέστε το στυλ γεμίσματος που σχετίζεται με το [AutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/autoshape/).
1. Προσπελάστε το [TextFrame] του [AutoShape](https://reference.aspose.com/slides java/com.aspose.slides/autoshape/).
1. Προσθέστε κάποιο κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/textframe/).
1. Προσπελάστε το αντικείμενο [Portion](https://reference.aspose.com/slides/el/java/com.aspose.slides/portion/) που σχετίζεται με το [TextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/textframe/).
1. Ορίστε τη γραμματοσειρά που θα χρησιμοποιηθεί για το [Portion](https://reference.aspose.com/slides/el/java/com.aspose.slides/portion/).
1. Ορίστε άλλες ιδιότητες γραμματοσειράς όπως έντονη, πλάγια, υπογράμμιση, χρώμα και ύψος χρησιμοποιώντας τις σχετικές ιδιότητες που εκτίθενται από το αντικείμενο [Portion](https://reference.aspose.com/slides/el/java/com.aspose.slides/portion/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων δίνεται παρακάτω.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Σχήμα: Κείμενο με ορισμένες ιδιότητες γραμματοσειράς που ορίστηκαν από το Aspose.Slides for Java**|

```java
// Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει αρχείο PPTX
Presentation pres = new Presentation();
try {
	// Αποκτήστε την πρώτη διαφάνεια
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Προσθέστε ένα AutoShape τύπου Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Αφαιρέστε τυχόν στυλ γεμίσματος που σχετίζεται με το AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Πρόσβαση στο TextFrame που σχετίζεται με το AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Πρόσβαση στο Portion που σχετίζεται με το TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Ορίστε τη γραμματοσειρά για το Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Ορίστε την ιδιότητα Έντονη της γραμματοσειράς
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Ορίστε την ιδιότητα Πλάγια της γραμματοσειράς
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Ορίστε την ιδιότητα Υπογράμμιση της γραμματοσειράς
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Ορίστε το ύψος της γραμματοσειράς
	port.getPortionFormat().setFontHeight(25);
	
	// Ορίστε το χρώμα της γραμματοσειράς
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Αποθηκεύστε την παρουσίαση στον δίσκο
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```