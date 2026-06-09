---
title: Διαχείριση υπερσυνδέσμων παρουσίασης σε Java
linktitle: Διαχείριση υπερσυνδέσμου
type: docs
weight: 20
url: /el/java/manage-hyperlinks/
keywords:
- προσθήκη URL
- προσθήκη υπερσυνδέσμου
- δημιουργία υπερσυνδέσμου
- μορφοποίηση υπερσυνδέσμου
- αφαίρεση υπερσυνδέσμου
- ενημέρωση υπερσυνδέσμου
- υπερσύνδεσμος κειμένου
- υπερσύνδεσμος διαφάνειας
- υπερσύνδεσμος σχήματος
- υπερσύνδεσμος εικόνας
- υπερσύνδεσμος βίντεο
- μεταβλητός υπερσύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Διαχειριστείτε άψογα τους υπερσυνδέσμους σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Java—βελτιώστε την αλληλεπίδραση και τη ροή εργασίας σε λίγα λεπτά."
---
## **Εισαγωγή**

Ένας υπερσύνδεσμος είναι μια αναφορά σε αντικείμενο ή δεδομένα ή σε θέση σε κάτι. Αυτοί είναι κοινά υπερσύνδεσμοι σε παρουσιάσεις PowerPoint:

* Σύνδεσμοι σε ιστότοπους μέσα σε κείμενα, σχήματα ή πολυμέσα
* Σύνδεσμοι σε διαφάνειες

Aspose.Slides for Java επιτρέπει την εκτέλεση πολλών εργασιών που αφορούν υπερσυνδέσμους σε παρουσιάσεις. 

{{% alert color="primary" %}} 

Μπορεί να θέλετε να δείτε το απλό, δωρεάν διαδικτυακό πρόγραμμα επεξεργασίας PowerPoint της Aspose, [δωρεάν διαδικτυακό πρόγραμμα επεξεργασίας PowerPoint.](https://products.aspose.app/slides/el/editor)

{{% /alert %}} 

## **Προσθήκη URL υπερσυνδέσμων**

### **Προσθήκη URL υπερσυνδέσμων σε κείμενο**

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο ιστότοπου σε κείμενο:

```java
Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

### **Προσθήκη URL υπερσυνδέσμων σε Σχήματα ή Πλαίσια**

Αυτό το δείγμα κώδικα σε Java δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο ιστότοπου σε σχήμα:

```java
Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **Προσθήκη URL υπερσυνδέσμων σε Πολυμέσα**

Το Aspose.Slides σάς επιτρέπει να προσθέτετε υπερσυνδέσμους σε εικόνες, αρχεία ήχου και βίντεο.

Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε μια **εικόνα**:

```java
Presentation pres = new Presentation();
try {
	// Προσθέτει εικόνα στην παρουσίαση
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// Δημιουργεί πλαίσιο εικόνας στη διαφάνεια 1 βάσει της προηγουμένως προστιθέμενης εικόνας
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε ένα **αρχείο ήχου**:

```java
Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε ένα **βίντεο**:

```java
Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}} 

Μπορεί να θέλετε να δείτε *[Διαχείριση OLE](/slides/el/java/manage-ole/)*.

{{% /alert %}}

## **Χρήση Υπερσυνδέσμων για Δημιουργία Πίνακα Περιεχομένων**

Δεδομένου ότι οι υπερσύνδεσμοι σας επιτρέπουν να προσθέτετε αναφορές σε αντικείμενα ή θέσεις, μπορείτε να τους χρησιμοποιήσετε για να δημιουργήσετε έναν πίνακα περιεχομένων. 

Αυτό το δείγμα κώδικα δείχνει πώς να δημιουργήσετε έναν πίνακα περιεχομένων με υπερσυνδέσμους:

```java
Presentation pres = new Presentation();
try {
	ISlide firstSlide = pres.getSlides().get_Item(0);
	ISlide secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

	IAutoShape contentTable = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
	contentTable.getFillFormat().setFillType(FillType.NoFill);
	contentTable.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
	contentTable.getTextFrame().getParagraphs().clear();

	Paragraph paragraph = new Paragraph();
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
	paragraph.setText("Title of slide 2 .......... ");

	Portion linkPortion = new Portion();
	linkPortion.setText("Page 2");
	linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

	paragraph.getPortions().add(linkPortion);
	contentTable.getTextFrame().getParagraphs().add(paragraph);

	pres.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Μορφοποίηση Υπερσυνδέσμων**

### **Χρώμα**

Με την ιδιότητα ColorSource στη διεπαφή IHyperlink, μπορείτε να ορίσετε το χρώμα για τους υπερσυνδέσμους και επίσης να λάβετε τις πληροφορίες χρώματος από τους υπερσυνδέσμους. Η δυνατότητα εισήχθη για πρώτη φορά στο PowerPoint 2019, επομένως οι αλλαγές που αφορούν αυτήν την ιδιότητα δεν ισχύουν για παλαιότερες εκδόσεις του PowerPoint.

Αυτό το δείγμα κώδικα παρουσιάζει μια λειτουργία όπου υπερσύνδεσμοι με διαφορετικά χρώματα προστέθηκαν στην ίδια διαφάνεια:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("This is a sample of colored hyperlink.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("This is a sample of usual hyperlink.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Αφαίρεση Υπερσυνδέσμων από Παρουσιάσεις**

### **Αφαίρεση Υπερσυνδέσμων από κείμενο**

Αυτός ο κώδικας Java δείχνει πώς να αφαιρέσετε τον υπερσύνδεσμο από κείμενο σε διαφάνεια παρουσίασης:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		IAutoShape autoShape = (IAutoShape)shape;
		if (autoShape != null)
		{
			for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
			{
				for (IPortion portion : paragraph.getPortions())
				{
					portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick();
				}
			}
		}
	}

	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **Αφαίρεση Υπερσυνδέσμων από Σχήματα ή Πλαίσια**

Αυτός ο κώδικας Java δείχνει πώς να αφαιρέσετε τον υπερσύνδεσμο από ένα σχήμα σε διαφάνεια παρουσίασης: 

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		shape.getHyperlinkManager().removeHyperlinkClick();
	}
	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Mutable Hyperlink**

Η κλάση Hyperlink είναι μεταβλητή. Με αυτήν την κλάση, μπορείτε να αλλάξετε τις τιμές για τις παρακάτω ιδιότητες:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Το απόσπασμα κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε διαφάνεια και να επεξεργαστείτε το tooltip του αργότερα:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Supported Properties in IHyperlinkQueries**

Μπορείτε να έχετε πρόσβαση στην IHyperlinkQueries από μια παρουσίαση, διαφάνεια ή κείμενο για το οποίο ορίζεται ο υπερσύνδεσμος. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/el/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Η κλάση IHyperlinkQueries υποστηρίζει αυτές τις μεθόδους και ιδιότητες: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**Πώς μπορώ να δημιουργήσω εσωτερική πλοήγηση όχι μόνο σε μια διαφάνεια, αλλά και σε μια «ενότητα» ή στην πρώτη διαφάνεια μιας ενότητας;**

Οι ενότητες στο PowerPoint είναι ομάδες διαφανειών· η πλοήγηση στοχεύει τεχνικά σε μια συγκεκριμένη διαφάνεια. Για να «πλοηγηθείτε σε μια ενότητα», συνήθως συνδέεστε στην πρώτη της διαφάνεια.

**Μπορώ να συσχετίσω έναν υπερσύνδεσμο με στοιχεία της κύριας διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία της κύριας διαφάνειας και του διατάξης υποστηρίζουν υπερσυνδέσμους. Αυτοί οι σύνδεσμοι εμφανίζονται στις παιδικές διαφάνειες και είναι κλικαρίσιμα κατά τη διάρκεια της παρουσίασης.

**Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;**

Στο [PDF](/slides/el/java/convert-powerpoint-to-pdf/) και το [HTML](/slides/el/java/convert-powerpoint-to-html/), ναι—οι σύνδεσμοι συνήθως διατηρούνται. Όταν εξάγετε σε [εικόνες](/slides/el/java/convert-powerpoint-to-png/) ή [βίντεο](/slides/el/java/convert-powerpoint-to-video/), η δυνατότητα κλικ δεν μεταφέρεται λόγω της φύσης αυτών των μορφών (πλαίσια raster/βίντεο δεν υποστηρίζουν υπερσυνδέσμους).