---
title: Βελτιστοποίηση Διαχείρισης Εικόνων σε Παρουσιάσεις με Java
linktitle: Διαχείριση Εικόνων
type: docs
weight: 10
url: /el/java/image/
keywords:
- προσθήκη εικόνας
- προσθήκη φωτογραφίας
- προσθήκη bitmap
- αντικατάσταση εικόνας
- αντικατάσταση φωτογραφίας
- από το διαδίκτυο
- φόντο
- προσθήκη PNG
- προσθήκη JPG
- προσθήκη SVG
- προσθήκη EMF
- προσθήκη WMF
- προσθήκη TIFF
- PowerPoint
- OpenDocument
- παρουσίαση
- EMF
- SVG
- Java
- Aspose.Slides
description: "Βελτιώστε τη διαχείριση εικόνων στο PowerPoint και στο OpenDocument με το Aspose.Slides για Java, βελτιστοποιώντας την απόδοση και αυτοματοποιώντας τη ροή εργασιών σας."
---
## **Εισαγωγή**

Οι εικόνες κάνουν τις παρουσιάσεις πιο ελκυστικές και ενδιαφέρουσες. Στο Microsoft PowerPoint, μπορείτε να εισάγετε εικόνες από αρχείο, το διαδίκτυο ή άλλες τοποθεσίες σε διαφάνειες. Παρομοίως, το Aspose.Slides σας επιτρέπει να προσθέσετε εικόνες σε διαφάνειες των παρουσιάσεών σας μέσω διαφορετικών διαδικασιών. 

{{% alert  title="Συμβουλή" color="primary" %}} 

Το Aspose παρέχει δωρεάν μετατροπείς—[JPEG to PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG to PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που επιτρέπουν στους χρήστες να δημιουργούν παρουσιάσεις γρήγορα από εικόνες. 

{{% /alert %}} 

{{% alert title="Πληροφορία" color="info" %}}

Εάν θέλετε να προσθέσετε μια εικόνα ως αντικείμενο πλαισίου—ιδιαίτερα αν σκοπεύετε να χρησιμοποιήσετε τυπικές επιλογές μορφοποίησης για αλλαγή μεγέθους, προσθήκη εφέ κ.λπ.—δείτε το [Picture Frame](https://docs.aspose.com/slides/el/java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Σημείωση" color="warning" %}}

Μπορείτε να χειριστείτε λειτουργίες εισόδου/εξόδου που αφορούν εικόνες και παρουσιάσεις PowerPoint για να μετατρέψετε μια εικόνα από τη μία μορφή στην άλλη. Δείτε αυτές τις σελίδες: μετατροπή [image to JPG](https://products.aspose.com/slides/el/java/conversion/image-to-jpg/); μετατροπή [JPG to image](https://products.aspose.com/slides/el/java/conversion/jpg-to-image/); μετατροπή [JPG to PNG](https://products.aspose.com/slides/el/java/conversion/jpg-to-png/), μετατροπή [PNG to JPG](https://products.aspose.com/slides/el/java/conversion/png-to-jpg/); μετατροπή [PNG to SVG](https://products.aspose.com/slides/el/java/conversion/png-to-svg/), μετατροπή [SVG to PNG](https://products.aspose.com/slides/el/java/conversion/svg-to-png/).

{{% /alert %}}

Το Aspose.Slides υποστηρίζει λειτουργίες με εικόνες σε αυτές τις δημοφιλείς μορφές: JPEG, PNG, GIF και άλλες. 

## **Προσθήκη Εικόνων Αποθηκευμένων Τοπικά σε Διαφάνειες**

Μπορείτε να προσθέσετε μία ή πολλές εικόνες από τον υπολογιστή σας σε μια διαφάνεια παρουσίασης. Αυτό το δείγμα κώδικα σε Java δείχνει πώς να προσθέσετε μια εικόνα σε διαφάνεια:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
	slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Προσθήκη Εικόνων από το Διαδίκτυο σε Διαφάνειες**

Εάν η εικόνα που θέλετε να προσθέσετε δεν είναι διαθέσιμη στον υπολογιστή σας, μπορείτε να την προσθέσετε άμεσα από το διαδίκτυο. 

Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε μια εικόνα από το διαδίκτυο σε διαφάνεια σε Java:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[REPLACE WITH URL]");
	URLConnection connection = imageUrl.openConnection();
	InputStream inputStream = connection.getInputStream();

	ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
	try {
		byte[] buffer = new byte[1024];
		int read;

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Προσθήκη Εικόνων σε Slide Masters**

Ένας slide master είναι η κορυφαία διαφάνεια που αποθηκεύει και ελέγχει πληροφορίες (θέμα, διάταξη κ.λπ.) για όλες τις διαφάνειες που τον ακολουθούν. Έτσι, όταν προσθέτετε μια εικόνα σε slide master, αυτή εμφανίζεται σε κάθε διαφάνεια κάτω από αυτόν τον master. 

Αυτό το δείγμα κώδικα Java δείχνει πώς να προσθέσετε μια εικόνα σε slide master:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Προσθήκη Εικόνων ως Φόντο Διαφάνειας**

Μπορείτε να αποφασίσετε να χρησιμοποιήσετε μια εικόνα ως φόντο για συγκεκριμένη διαφάνεια ή για πολλαπλές διαφάνειες. Σε αυτήν την περίπτωση, δείτε *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/el/java/presentation-background/#setting-images-as-background-for-slides)*.

## **Προσθήκη SVG σε Παρουσιάσεις**
Μπορείτε να προσθέσετε ή να εισάγετε οποιαδήποτε εικόνα σε μια παρουσίαση χρησιμοποιώντας τη μέθοδο [addPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) που ανήκει στη διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection).

Για να δημιουργήσετε ένα αντικείμενο εικόνας βάσει SVG, μπορείτε να ακολουθήσετε τα εξής βήματα:

1. Δημιουργήστε αντικείμενο SvgImage για εισαγωγή στο ImageShapeCollection
2. Δημιουργήστε αντικείμενο PPImage από ISvgImage
3. Δημιουργήστε αντικείμενο PictureFrame χρησιμοποιώντας τη διεπαφή IPPImage

Αυτό το δείγμα κώδικα δείχνει πώς να υλοποιήσετε τα παραπάνω βήματα για να προσθέσετε μια SVG εικόνα σε παρουσίαση:
```java 
// Αρχικοποίηση της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
			ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Μετατροπή SVG σε Σύνολο Σχημάτων**
Η μετατροπή SVG σε σύνολο σχημάτων του Aspose.Slides είναι παρόμοια με τη λειτουργικότητα του PowerPoint για SVG εικόνες:

![PowerPoint Popup Menu](img_01_01.png)

Η λειτουργία παρέχεται από μία από τις υπερφορτώσεις της μεθόδου [addGroupShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) της διεπαφής [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection) που δέχεται ως πρώτο όρισμα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISvgImage).

Αυτό το δείγμα κώδικα δείχνει πώς να χρησιμοποιήσετε τη μέθοδο για να μετατρέψετε ένα αρχείο SVG σε σύνολο σχημάτων:

```java 
// Δημιουργία νέας παρουσίασης
IPresentation presentation = new Presentation();
try {
    // Ανάγνωση περιεχομένου αρχείου SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Δημιουργία αντικειμένου SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Λήψη μεγέθους διαφάνειας
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Μετατροπή εικόνας SVG σε ομάδα σχημάτων με κλιμάκωση στο μέγεθος διαφάνειας
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Αποθήκευση παρουσίασης σε μορφή PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Προσθήκη Εικόνων ως EMF σε Διαφάνειες**
Το Aspose.Slides for Java σας επιτρέπει να δημιουργήσετε εικόνες EMF από φύλλα Excel και να τις προσθέσετε ως EMF σε διαφάνειες με το Aspose.Cells.  

Αυτό το δείγμα κώδικα δείχνει πώς να εκτελέσετε την περιγραφείσα εργασία:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Αποθήκευση του βιβλίου εργασίας σε ροή
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αντικατάσταση Εικόνων στη Συλλογή Εικόνων**

Το Aspose.Slides σας επιτρέπει να αντικαταστήσετε εικόνες που αποθηκεύονται στη συλλογή εικόνων μιας παρουσίασης (συμπεριλαμβανομένων αυτών που χρησιμοποιούνται από σχήματα διαφάνειας). Αυτή η ενότητα δείχνει διάφορες προσεγγίσεις για την ενημέρωση εικόνων στη συλλογή. Το API παρέχει απλές μεθόδους για αντικατάσταση μιας εικόνας χρησιμοποιώντας ακατέργαστα δεδομένα byte, ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/) ή άλλη εικόνα που υπάρχει ήδη στη συλλογή.

Ακολουθήστε τα παρακάτω βήματα:

1. Φορτώστε το αρχείο παρουσίασης που περιέχει εικόνες χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Φορτώστε μια νέα εικόνα από αρχείο σε πίνακα byte.
1. Αντικαταστήστε την στόχευση εικόνα με τη νέα εικόνα χρησιμοποιώντας τον πίνακα byte.
1. Στη δεύτερη προσέγγιση, φορτώστε την εικόνα σε αντικείμενο [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/) και αντικαταστήστε την στόχευση εικόνα με αυτό το αντικείμενο.
1. Στην τρίτη προσέγγιση, αντικαταστήστε την στόχευση εικόνα με μια εικόνα που υπάρχει ήδη στη συλλογή εικόνων της παρουσίασης.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```java
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Ο πρώτος τρόπος.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Ο δεύτερος τρόπος.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // Ο τρίτος τρόπος.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Αποθήκευση της παρουσίασης σε αρχείο.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Πληροφορία" color="info" %}}

Χρησιμοποιώντας τον δωρεάν μετατροπέα Aspose FREE [Text to GIF](https://products.aspose.app/slides/el/text-to-gif) μπορείτε εύκολα να ανιματίσετε κείμενα, να δημιουργήσετε GIF από κείμενα κ.λπ. 

{{% /alert %}}

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Παραμένει η αρχική ανάλυση της εικόνας αμετάβλητη μετά την εισαγωγή;**

Ναι. Τα αρχικά εικονοστοιχεία διατηρούνται, αλλά η τελική εμφάνιση εξαρτάται από το πώς το [picture](/slides/el/java/picture-frame/) έχει κλιμακωθεί στη διαφάνεια και από τυχόν συμπίεση κατά την αποθήκευση.

**Ποιος είναι ο βέλτιστος τρόπος να αντικαταστήσετε το ίδιο λογότυπο σε δεκάδες διαφάνειες ταυτόχρονα;**

Τοποθετήστε το λογότυπο στον master slide ή σε μια διάταξη και αντικαταστήστε το στη συλλογή εικόνων της παρουσίασης· οι αλλαγές θα διαδοθούν σε όλα τα στοιχεία που χρησιμοποιούν τον πόρο.

**Μπορεί ένα εισαχθέν SVG να μετατραπεί σε επεξεργάσιμα σχήματα;**

Ναι. Μπορείτε να μετατρέψετε ένα SVG σε ομάδα σχημάτων, μετά τα ατομικά μέρη γίνονται επεξεργάσιμα με τις τυπικές ιδιότητες σχήματος.

**Πώς μπορώ να ορίσω μια εικόνα ως φόντο για πολλαπλές διαφάνειες ταυτόχρονα;**

[Assign the image as the background](/slides/el/java/presentation-background/) στον master slide ή στη σχετική διάταξη· όλες οι διαφάνειες που χρησιμοποιούν αυτόν τον master/διάταξη θα κληρονομήσουν το φόντο.

**Πώς να αποτρέψω την παρουσίαση από το «φούσκωμα» του μεγέθους λόγω πολλών εικόνων;**

Ξαναχρησιμοποιήστε έναν μοναδικό πόρο εικόνας αντί για αντίγραφα, επιλέξτε λογικές αναλύσεις, εφαρμόστε συμπίεση κατά την αποθήκευση και κρατήστε τα επαναλαμβανόμενα γραφικά στον master όπου είναι κατάλληλο.