---
title: Διαχείριση Υπερσυνδέσμων Παρουσίασης σε Java
linktitle: Διαχείριση Υπερσυνδέσμου
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
description: "Διαχειριστείτε εύκολα τους υπερσυνδέσμους σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Java—βελτιώστε την αλληλεπίδραση και τη ροή εργασίας σε λίγα λεπτά."
---
## **Εισαγωγή**

Ένα υπερσύνδεσμο είναι μια αναφορά σε ένα αντικείμενο ή δεδομένα ή σε μια θέση σε κάτι. Αυτά είναι συνηθισμένοι υπερσύνδεσμοι σε παρουσιάσεις PowerPoint:

* Συνδέσεις σε ιστοτόπους μέσα σε κείμενα, σχήματα ή μέσα
* Συνδέσεις σε διαφάνειες

Aspose.Slides for Java σας επιτρέπει να εκτελείτε πολλές εργασίες που αφορούν υπερσυνδέσμους σε παρουσιάσεις. 

{{% alert color="info" %}} 

Μπορείτε να ρίξετε μια ματιά στο απλό, [δωρεάν διαδικτυακό πρόγραμμα επεξεργασίας PowerPoint.](https://products.aspose.app/slides/el/editor)

{{% /alert %}} 

## **Προσθήκη υπερσυνδέσμων URL**

### **Προσθήκη υπερσυνδέσμων URL σε κείμενο**

Αυτός ο κώδικας Java σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο ιστοσελίδας σε κείμενο:

```java
import com.aspose.slides.*;

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

### **Προσθήκη υπερσυνδέσμων URL σε σχήματα ή πλαίσια**

Αυτό το δείγμα κώδικα σε Java σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο ιστοσελίδας σε σχήμα:

```java
import com.aspose.slides.*;

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

### **Προσθήκη υπερσυνδέσμων URL σε μέσα**

Το Aspose.Slides σας επιτρέπει να προσθέσετε υπερσυνδέσμους σε εικόνες, ήχο και αρχεία βίντεο. 

Αυτό το δείγμα κώδικα σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε μια **εικόνα**:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	// Προσθέτει εικόνα στην παρουσίαση
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	// Δημιουργεί πλαίσιο εικόνας στη διαφάνεια 1 βάσει της προηγουμένως προστιθέμενης εικόνας
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

Αυτό το δείγμα κώδικα σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε ένα **αρχείο ήχου**:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

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

Αυτό το δείγμα κώδικα σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε ένα **βίντεο**:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

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

{{%  alert  title="Tip"  color="info"  %}} 

Ίσως θέλετε να δείτε *[Διαχείριση OLE](/slides/el/java/manage-ole/)*.

{{% /alert %}}

## **Χρήση υπερσυνδέσμων για δημιουργία πίνακα περιεχομένων**

Καθώς οι υπερσύνδεσμοι σας επιτρέπουν να προσθέτετε αναφορές σε αντικείμενα ή θέσεις, μπορείτε να τους χρησιμοποιήσετε για να δημιουργήσετε έναν πίνακα περιεχομένων. 

Αυτό το δείγμα κώδικα σας δείχνει πώς να δημιουργήσετε έναν πίνακα περιεχομένων με υπερσυνδέσμους:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Μορφοποίηση υπερσυνδέσμων**

### **Χρώμα**

Με την ιδιότητα [ColorSource](https://reference.aspose.com/slides/el/java/com.aspose.slides/Hyperlink#setColorSource-int-) στο interface [IHyperlink](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlink), μπορείτε να ορίσετε το χρώμα για υπερσυνδέσμους και επίσης να λάβετε πληροφορίες χρώματος από τους υπερσυνδέσμους. Η δυνατότητα εισήχθη για πρώτη φορά στο PowerPoint 2019, οπότε αλλαγές που αφορούν την ιδιότητα δεν ισχύουν για παλαιότερες εκδόσεις PowerPoint.

Αυτό το δείγμα κώδικα δείχνει μια λειτουργία όπου υπερσύνδεσμοι με διαφορετικά χρώματα προστέθηκαν στην ίδια διαφάνεια:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Αφαίρεση υπερσυνδέσμων από παρουσιάσεις**

### **Αφαίρεση υπερσυνδέσμων από κείμενο**

Αυτός ο κώδικας Java σας δείχνει πώς να αφαιρέσετε τον υπερσύνδεσμο από κείμενο σε διαφάνεια παρουσίασης:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		if (shape instanceof IAutoShape)
		{
			IAutoShape autoShape = (IAutoShape)shape;
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

### **Αφαίρεση υπερσυνδέσμων από σχήματα ή πλαίσια**

Αυτός ο κώδικας Java σας δείχνει πώς να αφαιρέσετε τον υπερσύνδεσμο από σχήμα σε διαφάνεια παρουσίασης: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

## **Μεταβλητός υπερσύνδεσμος**

Η κλάση [Hyperlink](https://reference.aspose.com/slides/el/java/com.aspose.slides/Hyperlink) είναι μεταβλητή. Με αυτήν την κλάση, μπορείτε να αλλάξετε τις τιμές για αυτές τις ιδιότητες:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Το απόσπασμα κώδικα σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε διαφάνεια και να επεξεργαστείτε το tooltip αργότερα:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	// Αλλάζει το tooltip του υπερσυνδέσμου που έχει ήδη προστεθεί
	portionFormat.getHyperlinkClick().setTooltip("Aspose: the File Format APIs");

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Υποστηριζόμενες ιδιότητες στο IHyperlinkQueries**

Μπορείτε να αποκτήσετε πρόσβαση στο [IHyperlinkQueries](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlinkQueries) από μια παρουσίαση, διαφάνεια ή κείμενο για το οποίο ορίζεται ο υπερσύνδεσμος. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/el/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Η κλάση [IHyperlinkQueries](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlinkQueries) υποστηρίζει αυτές τις μεθόδους και ιδιότητες: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/el/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

### Πώς μπορώ να δημιουργήσω εσωτερική πλοήγηση όχι μόνο σε διαφάνεια, αλλά σε «ενότητα» ή στην πρώτη διαφάνεια μιας ενότητας;

Οι ενότητες στο PowerPoint είναι ομαδοποιήσεις διαφανειών· η πλοήγηση τεχνικά στοχεύει σε συγκεκριμένη διαφάνεια. Για να «πλοηγηθείτε σε ενότητα», συνήθως συνδέεστε με την πρώτη της διαφάνεια.

### Μπορώ να συνδέσω έναν υπερσύνδεσμο σε στοιχεία κύριας διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;

Ναι. Τα στοιχεία της κύριας διαφάνειας και του προτύπου υποστηρίζουν υπερσυνδέσμους. Τέτοιου είδους συνδέσμους εμφανίζονται στις παιδικές διαφάνειες και είναι κλικάριστα κατά την προβολή της παρουσίασης.

### Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;

Στα [PDF](/slides/el/java/convert-powerpoint-to-pdf/) και [HTML](/slides/el/java/convert-powerpoint-to-html/), ναι—οι σύνδεσμοι διατηρούνται γενικά. Κατά την εξαγωγή σε [εικόνες](/slides/el/java/convert-powerpoint-to-png/) και [βίντεο](/slides/el/java/convert-powerpoint-to-video/), η δυνατότητα κλικ δεν θα μεταφερθεί λόγω της φύσης αυτών των μορφών (τα ραστερικά πλαίσια/βίντεο δεν υποστηρίζουν υπερσυνδέσμους).