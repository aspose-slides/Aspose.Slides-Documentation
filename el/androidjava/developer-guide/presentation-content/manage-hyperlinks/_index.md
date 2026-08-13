---
title: Διαχείριση Υπερσυνδέσμων Παρουσίασης σε Android
linktitle: Διαχείριση Υπερσυνδέσμου
type: docs
weight: 20
url: /el/androidjava/manage-hyperlinks/
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
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε άνετα τους υπερσυνδέσμους σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Android μέσω Java—βελτιώστε την αλληλεπίδραση και τη ροή εργασίας σε λίγα λεπτά."
---
## **Εισαγωγή**

Ένας υπερσύνδεσμος είναι μια αναφορά σε ένα αντικείμενο ή δεδομένα ή μια θέση σε κάτι. Αυτοί είναι συνήθεις υπερσύνδεσμοι σε παρουσιάσεις PowerPoint:

* Σύνδεσμοι προς ιστοσελίδες μέσα σε κείμενα, σχήματα ή πολυμέσα
* Σύνδεσμοι προς διαφάνειες

Το Aspose.Slides για Android μέσω Java σας επιτρέπει να εκτελείτε πολλές εργασίες που σχετίζονται με υπερσυνδέσμους σε παρουσιάσεις.

{{% alert color="info" %}} 

Μπορείτε να θέλετε να δοκιμάσετε το απλό Aspose, [δωρεάν διαδικτυακό επεξεργαστή PowerPoint.](https://products.aspose.app/slides/el/editor)

{{% /alert %}} 

## **Προσθήκη υπερσυνδέσμων URL**

### **Προσθήκη υπερσυνδέσμων URL σε κείμενο**

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο ιστοσελίδας σε κείμενο:

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

Αυτό το παραδειγματικό κώδικα σε Java δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο ιστοσελίδας σε σχήμα:

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

### **Προσθήκη υπερσυνδέσμων URL σε πολυμέσα**

Το Aspose.Slides σας επιτρέπει να προσθέτετε υπερσυνδέσμους σε εικόνες, ήχο και αρχεία βίντεο.

Αυτό το παραδειγματικό κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε μια **εικόνα**:

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
	// Δημιουργεί πλαίσιο εικόνας στη διαφάνεια 1 βάσει της προηγουμένως προστεθεισας εικόνας
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

Αυτό το παραδειγματικό κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε ένα **αρχείο ήχου**:

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

Αυτό το παραδειγματικό κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε ένα **βίντεο**:

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

Μπορείτε να θέλετε να δείτε *[Manage OLE](/slides/el/androidjava/manage-ole/)*.

{{% /alert %}}

## **Χρήση υπερσυνδέσμων για Δημιουργία Πίνακα Περιεχομένων**

Δεδομένου ότι οι υπερσύνδεσμοι σάς επιτρέπουν να προσθέτετε αναφορές σε αντικείμενα ή θέσεις, μπορείτε να τους χρησιμοποιήσετε για τη δημιουργία πίνακα περιεχομένων.

Αυτό το παραδειγματικό κώδικα δείχνει πώς να δημιουργήσετε έναν πίνακα περιεχομένων με υπερσυνδέσμους:

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

Με την ιδιότητα [ColorSource](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) στην διεπαφή [IHyperlink](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IHyperlink), μπορείτε να ορίσετε το χρώμα για τους υπερσυνδέσμους και επίσης να λάβετε πληροφορίες χρώματος από αυτούς. Η λειτουργία αυτή εισήχθη για πρώτη φορά στο PowerPoint 2019, έτσι οι αλλαγές που αφορούν την ιδιότητα δεν ισχύουν για παλαιότερες εκδόσεις του PowerPoint.

Αυτό το παραδειγματικό κώδικα παρουσιάζει μια λειτουργία όπου υπερσύνδεσμοι με διαφορετικά χρώματα προστέθηκαν στην ίδια διαφάνεια:

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

Αυτός ο κώδικας Java δείχνει πώς να αφαιρέσετε τον υπερσύνδεσμο από κείμενο σε μια διαφάνεια παρουσίασης:

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

Αυτός ο κώδικας Java δείχνει πώς να αφαιρέσετε τον υπερσύνδεσμο από ένα σχήμα σε μια διαφάνεια παρουσίασης: 

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

## **Μεταβλητός Υπερσύνδεσμος**

Η κλάση [Hyperlink](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Hyperlink) είναι μεταβλητή. Με αυτήν την κλάση, μπορείτε να αλλάξετε τις τιμές για τις ακόλουθες ιδιότητες:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Το απόσπασμα κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε μια διαφάνεια και να επεξεργαστείτε την υπόδειξη του αργότερα:

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

## **Υποστηριζόμενες Ιδιότητες στο IHyperlinkQueries**

Μπορείτε να αποκτήσετε πρόσβαση στο [IHyperlinkQueries](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IHyperlinkQueries) από μια παρουσίαση, διαφάνεια ή κείμενο για το οποίο ορίζεται ο υπερσύνδεσμος.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Η κλάση [IHyperlinkQueries](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IHyperlinkQueries) υποστηρίζει τις παρακάτω μεθόδους και ιδιότητες:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **Συχνές Ερωτήσεις**

### Πώς μπορώ να δημιουργήσω εσωτερική πλοήγηση όχι μόνο σε μια διαφάνεια, αλλά σε ένα "τμήμα" ή στην πρώτη διαφάνεια ενός τμήματος;

Τα τμήματα στο PowerPoint είναι ομαδοποιήσεις διαφανειών· η πλοήγηση στο τεχνικό επίπεδο στοχεύει μια συγκεκριμένη διαφάνεια. Για να «πλοηγηθείτε σε τμήμα», συνήθως συνδέεστε στην πρώτη της διαφάνεια.

### Μπορώ να συνδέσω έναν υπερσύνδεσμο σε στοιχεία της κύριας διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;

Ναι. Τα στοιχεία της κύριας διαφάνειας και του προτύπου υποστηρίζουν υπερσυνδέσμους. Τέτοιοι σύνδεσμοι εμφανίζονται στις θυγατρικές διαφάνειες και είναι κλικ‑δυνατοί κατά τη διάρκεια της παρουσίασης.

### Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;

Στα [PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/) και [HTML](/slides/el/androidjava/convert-powerpoint-to-html/), ναι — οι σύνδεσμοι διατηρούνται γενικά. Κατά την εξαγωγή σε [images](/slides/el/androidjava/convert-powerpoint-to-png/) και [video](/slides/el/androidjava/convert-powerpoint-to-video/), η δυνατότητα κλικ δεν μεταφέρεται λόγω του χαρακτήρα αυτών των μορφών (πλαισίων raster/βίντεο δεν υποστηρίζουν υπερσυνδέσμους).