---
title: Βελτιστοποίηση Διαχείρισης Εικόνων σε Παρουσιάσεις στο Android
linktitle: Διαχείριση Εικόνων
type: docs
weight: 10
url: /el/androidjava/image/
keywords:
- προσθήκη εικόνας
- προσθήκη φωτογραφίας
- προσθήκη bitmap
- αντικατάσταση εικόνας
- αντικατάσταση φωτογραφίας
- από web
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
- Android
- Java
- Aspose.Slides
description: "Βελτιώστε τη διαχείριση εικόνων σε PowerPoint και OpenDocument με το Aspose.Slides για Android μέσω Java, βελτιώνοντας την απόδοση και αυτοματοποιώντας τη ροή εργασιών σας."
---
## **Εισαγωγή**

Οι εικόνες κάνουν τις παρουσιάσεις πιο ελκυστικές και ενδιαφέρουσες. Στο Microsoft PowerPoint, μπορείτε να εισάγετε εικόνες από αρχείο, το διαδίκτυο ή άλλες τοποθεσίες στις διαφάνειες. Παρομοίως, το Aspose.Slides σας επιτρέπει να προσθέτετε εικόνες σε διαφάνειες στις παρουσιάσεις σας μέσω διαφορετικών διαδικασιών. 

{{% alert  title="Tip" color="primary" %}} 
Το Aspose παρέχει δωρεάν μετατροπείς—[JPEG σε PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG σε PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που επιτρέπουν στους χρήστες να δημιουργούν παρουσιάσεις γρήγορα από εικόνες. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Αν θέλετε να προσθέσετε μια εικόνα ως αντικείμενο πλαισίου—ειδικά εάν σκοπεύετε να χρησιμοποιήσετε τυπικές επιλογές μορφοποίησης για να αλλάξετε το μέγεθός της, να προσθέσετε εφέ κ.λπ.—δείτε το [Picture Frame](https://docs.aspose.com/slides/el/androidjava/picture-frame/). 
{{% /alert %}} 

Το Aspose.Slides υποστηρίζει λειτουργίες με εικόνες σε αυτές τις δημοφιλείς μορφές: JPEG, PNG, GIF και άλλες. 

## **Προσθήκη Εικόνων Αποθηκευμένων Τοπικά σε Διαφάνειες**

Μπορείτε να προσθέσετε μία ή πολλές εικόνες από τον υπολογιστή σας σε μια διαφάνεια παρουσίασης. Αυτός ο κώδικας δείγματος σε Java δείχνει πώς να προσθέσετε μια εικόνα σε μια διαφάνεια:

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

Εάν η εικόνα που θέλετε να προσθέσετε σε μια διαφάνεια δεν είναι διαθέσιμη στον υπολογιστή σας, μπορείτε να προσθέσετε την εικόνα απευθείας από το διαδίκτυο. 

Αυτός ο κώδικας δείγματος δείχνει πώς να προσθέσετε μια εικόνα από το διαδίκτυο σε μια διαφάνεια σε Java:

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

Ένα slide master είναι η κορυφαία διαφάνεια που αποθηκεύει και ελέγχει πληροφορίες (θέμα, διάταξη κ.ά.) για όλες τις διαφάνειες που βρίσκονται κάτω από αυτήν. Έτσι, όταν προσθέτετε μια εικόνα σε ένα slide master, αυτή η εικόνα εμφανίζεται σε κάθε διαφάνεια κάτω από το συγκεκριμένο slide master. 

Αυτός ο κώδικας δείγματος Java δείχνει πώς να προσθέσετε μια εικόνα σε ένα slide master:

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

Μπορείτε να αποφασίσετε να χρησιμοποιήσετε μια εικόνα ως φόντο για μια συγκεκριμένη διαφάνεια ή πολλές διαφάνειες. Σε αυτήν την περίπτωση, πρέπει να δείτε *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/el/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Προσθήκη SVG σε Παρουσιάσεις**

Μπορείτε να προσθέσετε ή να ενσωματώσετε οποιαδήποτε εικόνα σε μια παρουσίαση χρησιμοποιώντας τη μέθοδο [addPictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) που ανήκει στη διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection). 

Για να δημιουργήσετε ένα αντικείμενο εικόνας βασισμένο σε SVG, μπορείτε να το κάνετε ως εξής:

1. Δημιουργήστε αντικείμενο SvgImage για να το εισάγετε στο ImageShapeCollection
2. Δημιουργήστε αντικείμενο PPImage από το ISvgImage
3. Δημιουργήστε αντικείμενο PictureFrame χρησιμοποιώντας τη διεπαφή IPPImage

Αυτός ο κώδικας δείγματος δείχνει πώς να εφαρμόσετε τα παραπάνω βήματα για να προσθέσετε μια SVG εικόνα σε μια παρουσίαση:
```java 
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο PPTX
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

Η μετατροπή SVG σε σύνολο σχημάτων του Aspose.Slides είναι παρόμοια με τη λειτουργία του PowerPoint που χρησιμοποιείται για εργασία με SVG εικόνες:

![PowerPoint Popup Menu](img_01_01.png)

Η λειτουργία παρέχεται από μία από τις υπερφορτώσεις της μεθόδου [addGroupShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) της διεπαφής [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection) που δέχεται ως πρώτο όρισμα ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISvgImage). 

Αυτός ο κώδικας δείγματος δείχνει πώς να χρησιμοποιήσετε τη περιγραφόμενη μέθοδο για να μετατρέψετε ένα αρχείο SVG σε σύνολο σχημάτων:

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

    // Μετατροπή εικόνας SVG σε ομάδα σχημάτων κλιμακώνοντάς την στο μέγεθος της διαφάνειας
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

Το Aspose.Slides για Android μέσω Java σας επιτρέπει να δημιουργείτε εικόνες EMF από φύλλα Excel και να προσθέτετε τις εικόνες ως EMF σε διαφάνειες με το Aspose.Cells. 

Αυτός ο κώδικας δείγματος δείχνει πώς να εκτελέσετε την περιγραφόμενη εργασία:

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

Το Aspose.Slides σας επιτρέπει να αντικαθιστάτε εικόνες που είναι αποθηκευμένες στη συλλογή εικόνων μιας παρουσίασης (συμπεριλαμβανομένων αυτών που χρησιμοποιούνται από σχήματα διαφάνειας). Αυτή η ενότητα δείχνει διάφορες προσεγγίσεις για την ενημέρωση εικόνων στη συλλογή. Το API παρέχει απλές μεθόδους για την αντικατάσταση μιας εικόνας χρησιμοποιώντας ακατέργαστα δεδομένα byte, μια εμφάνιση [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/), ή μια άλλη εικόνα που ήδη υπάρχει στη συλλογή. 

1. Φορτώστε το αρχείο παρουσίασης που περιέχει εικόνες χρησιμοποιώντας τη κλάση [Presentation].
1. Φορτώστε μια νέα εικόνα από αρχείο σε έναν πίνακα byte.
1. Αντικαταστήστε την εικόνα-στόχο με τη νέα εικόνα χρησιμοποιώντας τον πίνακα byte.
1. Στη δεύτερη προσέγγιση, φορτώστε την εικόνα σε ένα αντικείμενο [IImage] και αντικαταστήστε την εικόνα-στόχο με αυτό το αντικείμενο.
1. Στην τρίτη προσέγγιση, αντικαταστήστε την εικόνα-στόχο με μια εικόνα που υπάρχει ήδη στη συλλογή εικόνων της παρουσίασης.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο παρουσίασης.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Ο πρώτος τρόπος.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
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

{{% alert title="Info" color="info" %}}
Χρησιμοποιώντας τον ΔΩΡΕΑΝ μετατροπέα Aspose [Text to GIF](https://products.aspose.app/slides/el/text-to-gif), μπορείτε εύκολα να δημιουργείτε κείμενα σε κίνηση, να δημιουργείτε GIF από κείμενα κ.λπ. 
{{% /alert %}}

## **FAQ**

**Παραμένει η αρχική ανάλυση της εικόνας αμετάβλητη μετά την εισαγωγή;**

Ναι. Τα αρχικά pixel διατηρούνται, αλλά η τελική εμφάνιση εξαρτάται από το πώς η [picture](/slides/el/androidjava/picture-frame/) κλιμακώνεται στη διαφάνεια και τυχόν συμπίεση που εφαρμόζεται κατά την αποθήκευση.

**Ποιος είναι ο καλύτερος τρόπος για να αντικαταστήσετε το ίδιο λογότυπο σε δεκάδες διαφάνειες ταυτόχρονα;**

Τοποθετήστε το λογότυπο στο master slide ή σε μια διάταξη και αντικαταστήστε το στη συλλογή εικόνων της παρουσίασης — οι ενημερώσεις θα εξαπλωθούν σε όλα τα στοιχεία που χρησιμοποιούν αυτόν τον πόρο.

**Μπορεί ένα εισαχθέν SVG να μετατραπεί σε επεξεργάσιμα σχήματα;**

Ναι. Μπορείτε να μετατρέψετε ένα SVG σε ομάδα σχημάτων, μετά τα μεμονωμένα τμήματα γίνονται επεξεργάσιμα με τις τυπικές ιδιότητες σχήματος.

**Πώς μπορώ να ορίσω μια εικόνα ως φόντο για πολλές διαφάνειες ταυτόχρονα;**

Ορίστε την εικόνα ως φόντο στο master slide ή στη σχετική διάταξη — όλες οι διαφάνειες που χρησιμοποιούν αυτό το master/διάταξη θα κληρονομήσουν το φόντο.

**Πώς μπορώ να αποτρέψω την παρουσίαση από το "να φουσκώνει" σε μέγεθος εξαιτίας πολλών εικόνων;**

Επαναχρησιμοποιήστε έναν ενιαίο πόρο εικόνας αντί για διπλότυπα, επιλέξτε λογικές αναλύσεις, εφαρμόστε συμπίεση κατά την αποθήκευση και κρατήστε τα επαναλαμβανόμενα γραφικά στο master όπου είναι κατάλληλο.