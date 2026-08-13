---
title: Διαχείριση Γραμματοσειρών σε Παρουσιάσεις στο Android
linktitle: Διαχείριση Γραμματοσειρών
type: docs
weight: 10
url: /el/androidjava/manage-fonts/
keywords:
- διαχείριση γραμματοσειρών
- ιδιότητες γραμματοσειράς
- παράγραφος
- μορφοποίηση κειμένου
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Έλεγχος γραμματοσειρών σε Java με το Aspose.Slides για Android: ενσωμάτωση, αντικατάσταση και φόρτωση προσαρμοσμένων γραμματοσειρών για να διατηρούνται οι παρουσιάσεις PPT, PPTX και ODP καθαρές, ασφαλείς για το εμπορικό σήμα και συνεπείς."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να διαχειρίζεστε τις ιδιότητες γραμματοσειράς στο κείμενο μιας παρουσίασης απευθείας από τον κώδικά σας. Μπορείτε να έχετε πρόσβαση στο κείμενο των διαφανειών μέσω σχήματος, πλαισίων κειμένου, παραγράφων και τμημάτων, και στη συνέχεια να εφαρμόζετε μορφοποίηση στο επιλεγμένο κείμενο.

Αυτό το άρθρο εξηγεί πώς να ρυθμίσετε τις ιδιότητες σχετικές με τη γραμματοσειρά για υπάρχον κείμενο σε μια παρουσίαση, συμπεριλαμβανομένης της οικογένειας γραμματοσειράς, των στυλ έντονης και πλάγιας γραφής, της στοίχισης παραγράφου και του χρώματος γραμματοσειράς. Επίσης δείχνει πώς να δημιουργήσετε ένα πλαίσιο κειμένου, να προσθέσετε κείμενο σε αυτό, και να ορίσετε ιδιότητες γραμματοσειράς όπως η οικογένεια γραμματοσειράς, η έντονη, η πλάγια, η υπογράμμιση, το μέγεθος γραμματοσειράς και το χρώμα πριν αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX.

## **Διαχείριση Ιδιοτήτων Σχετικών με τη Γραμματοσειρά**
{{% alert color="info" %}} 

Οι παρουσιάσεις συνήθως περιέχουν τόσο κείμενο όσο και εικόνες. Το κείμενο μπορεί να μορφοποιηθεί με διάφορους τρόπους, είτε για να επισημάνει συγκεκριμένα τμήματα και λέξεις είτε για να εναρμονιστεί με εταιρικά στυλ. Η μορφοποίηση κειμένου βοηθά τους χρήστες να διαφοροποιούν την εμφάνιση του περιεχομένου της παρουσίασης. Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε το Aspose.Slides για Android μέσω Java για να ρυθμίσετε τις ιδιότητες γραμματοσειράς των παραγράφων κειμένου στις διαφάνειες.
{{% /alert %}} 

Για να διαχειριστείτε τις ιδιότητες γραμματοσειράς μιας παραγράφου χρησιμοποιώντας το Aspose.Slides για Android μέσω Java:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.
1. Προσπελάστε τα σχήματα [Placeholder](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/placeholder/) στη διαφάνεια και κάντε μετατροπή τύπου σε [AutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/autoshape/).
1. Αποκτήστε το [Paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraph/) από το [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframe/) που παρέχεται από το [AutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/autoshape/).
1. Δικαιολογήστε την παράγραφο.
1. Προσπελάστε το κείμενο της [Paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraph/) μέσω του [Portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/portion/).
1. Ορίστε τη γραμματοσειρά χρησιμοποιώντας το [FontData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontdata/) και ορίστε τη **Font** του κειμένου [Portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/portion/) ανάλογα.
   1. Ορίστε τη γραμματοσειρά σε έντονη.
   1. Ορίστε τη γραμματοσειρά σε πλάγια.
1. Ορίστε το χρώμα της γραμματοσειράς χρησιμοποιώντας το [FillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fillformat/) που παρέχεται από το αντικείμενο [Portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/portion/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων δίνεται παρακάτω. Παίρνει μια ακατέργαστη παρουσίαση και μορφοποιεί τις γραμματοσειρές σε μία από τις διαφάνειες. Τα screenshots που ακολουθούν δείχνουν το αρχείο εισόδου και πώς τα αποσπάσματα κώδικα το τροποποιούν. Ο κώδικας αλλάζει τη γραμματοσειρά, το χρώμα και το στυλ της γραμματοσειράς.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Σχήμα: Το κείμενο στο αρχείο εισόδου**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Σχήμα: Το ίδιο κείμενο με ενημερωμένη μορφοποίηση**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργία αντικειμένου Presentation το οποίο αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Πρόσβαση σε διαφάνεια χρησιμοποιώντας τη θέση της
	ISlide slide = pres.getSlides().get_Item(0);

	// Πρόσβαση στον πρώτο και δεύτερο placeholder στη διαφάνεια και μετατροπή τύπου σε AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Πρόσβαση στην πρώτη Παράγραφο
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Στοίχιση παραγράφου
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

	// Ορισμός γραμματοσειράς σε έντονη (Bold)
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Ορισμός γραμματοσειράς σε πλάγια (Italic)
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Ορισμός χρώματος γραμματοσειράς
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// Αποθήκευση του PPTX στο δίσκο
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Ορισμός Ιδιοτήτων Γραμματοσειράς Κειμένου**
{{% alert color="info" %}} 

Όπως αναφέρθηκε στην **Διαχείριση Ιδιοτήτων Σχετικών με τη Γραμματοσειρά**, ένα [Portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/portion/) χρησιμοποιείται για να κρατά κείμενο με παρόμοιο στυλ μορφοποίησης σε μια παράγραφο. Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε το Aspose.Slides για Android μέσω Java για να δημιουργήσετε ένα πλαίσιο κειμένου με κάποιο κείμενο και στη συνέχεια να ορίσετε μια συγκεκριμένη γραμματοσειρά, καθώς και διάφορες άλλες ιδιότητες της κατηγορίας οικογένειας γραμματοσειράς.
{{% /alert %}} 

Για να δημιουργήσετε ένα πλαίσιο κειμένου και να ορίσετε τις ιδιότητες γραμματοσειράς του κειμένου σε αυτό:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/autoshape/) τύπου **Rectangle** στη διαφάνεια.
1. Αφαιρέστε το στυλ γεμίσματος που σχετίζεται με το [AutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/autoshape/).
1. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframe/) του [AutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/autoshape/).
1. Προσθέστε κάποιο κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframe/).
1. Προσπελάστε το αντικείμενο [Portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/portion/) που σχετίζεται με το [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframe/).
1. Ορίστε τη γραμματοσειρά που θα χρησιμοποιηθεί για το [Portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/portion/).
1. Ορίστε άλλες ιδιότητες γραμματοσειράς όπως έντονη, πλάγια, υπογράμμιση, χρώμα και ύψος χρησιμοποιώντας τις σχετικές ιδιότητες που παρέχονται από το αντικείμενο [Portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/portion/).
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων δίνεται παρακάτω.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Σχήμα: Κείμενο με κάποιες ιδιότητες γραμματοσειράς ορισμένες από το Aspose.Slides για Android μέσω Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
	// Αποκτήστε την πρώτη διαφάνεια
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Προσθήκη AutoShape τύπου Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Αφαίρεση οποιουδήποτε στυλ γεμίσματος που σχετίζεται με το AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Πρόσβαση στο TextFrame που σχετίζεται με το AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Πρόσβαση στο Portion που σχετίζεται με το TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Ορισμός της γραμματοσειράς για το Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Ορισμός ιδιότητας Bold στη γραμματοσειρά
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Ορισμός ιδιότητας Italic στη γραμματοσειρά
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Ορισμός ιδιότητας Underline στη γραμματοσειρά
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Ορισμός ύψους της γραμματοσειράς
	port.getPortionFormat().setFontHeight(25);
	
	// Ορισμός χρώματος της γραμματοσειράς
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Αποθήκευση της παρουσίασης στον δίσκο
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```