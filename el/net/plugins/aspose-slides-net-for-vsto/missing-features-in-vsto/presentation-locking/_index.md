---
title: Κλείδωμα Παρουσίασης
type: docs
weight: 110
url: /el/net/presentation-locking/
---
## **Κλείδωμα Παρουσίασης**
Μία συνηθισμένη χρήση του **Aspose.Slides** είναι η δημιουργία, ενημέρωση και αποθήκευση παρουσιάσεων Microsoft PowerPoint 2007 (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Οι χρήστες της εφαρμογής που χρησιμοποιεί το Aspose.Slides με αυτόν τον τρόπο αποκτούν πρόσβαση στις τελικές παρουσιάσεις. Η προστασία τους από επεξεργασία είναι μια κοινή ανησυχία. Είναι σημαντικό οι αυτόματα δημιουργημένες παρουσιάσεις να διατηρούν την αρχική μορφοποίηση και το περιεχόμενό τους.

Αυτό εξηγεί πώς δημιουργούνται οι παρουσιάσεις και οι διαφάνειες και πώς το Aspose.Slides for .NET μπορεί να εφαρμόσει προστασία σε μια παρουσίαση και, στη συνέχεια, να την αφαιρέσει. Αυτή η δυνατότητα είναι μοναδική για το Aspose.Slides και, τη στιγμή της συγγραφής, δεν είναι διαθέσιμη στο Microsoft PowerPoint. Παρέχει στους προγραμματιστές έναν τρόπο ελέγχου του τρόπου χρήσης των παρουσιάσεων που δημιουργούν οι εφαρμογές τους.
## **Σύνθεση Διαφάνειας**
Μια διαφάνεια PPTX αποτελείται από έναν αριθμό στοιχείων όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνας, πλαίσια βίντεο, συνδέσμους και διάφορα άλλα στοιχεία που διατίθενται για τη δημιουργία μιας παρουσίασης.

Στο Aspose.Slides for .NET, κάθε στοιχείο σε μια διαφάνεια μετατρέπεται σε αντικείμενο Shape. Με άλλα λόγια, κάθε στοιχείο στη διαφάνεια είναι είτε ένα αντικείμενο Shape είτε ένα αντικείμενο που προέρχεται από το Shape.

Η δομή του PPTX είναι σύνθετη, επομένως, σε αντίθεση με το PPT, όπου μπορεί να χρησιμοποιηθεί ένα γενικό κλείδωμα για όλους τους τύπους σχημάτων, υπάρχουν διαφορετικοί τύποι κλειδωμάτων για διαφορετικούς τύπους σχημάτων. Η κλάση BaseShapeLock είναι η γενική κλάση κλειδώματος PPTX. Οι παρακάτω τύποι κλειδωμάτων υποστηρίζονται στο Aspose.Slides for .NET για PPTX.

- AutoShapeLock κλειδώνει αυτόματα σχήματα.
- ConnectorLock κλειδώνει σχήματα συνδέσμων.
- GraphicalObjectLock κλειδώνει γραφικά αντικείμενα.
- GroupshapeLock κλειδώνει ομαδοποιημένα σχήματα.
- PictureFrameLock κλειδώνει πλαίσια εικόνας.

Οποιαδήποτε ενέργεια εκτελείται σε όλα τα αντικείμενα Shape σε ένα αντικείμενο Presentation εφαρμόζεται σε ολόκληρη την παρουσίαση.
## **Εφαρμογή και Απομάκρυνση Προστασίας**
Η εφαρμογή προστασίας διασφαλίζει ότι μια παρουσίαση δεν μπορεί να επεξεργαστεί. Είναι μια χρήσιμη τεχνική για την προστασία του περιεχομένου μιας παρουσίασης.

**Εφαρμογή Προστασίας σε Σχήματα PPTX**

Το Aspose.Slides for .NET παρέχει την κλάση Shape για τη διαχείριση ενός σχήματος στη διαφάνεια.

Όπως αναφέρθηκε νωρίτερα, κάθε κλάση σχήματος έχει μια σχετική κλάση κλειδώματος σχήματος για προστασία. Αυτό το άρθρο εστιάζει στα κλειδώματα NoSelect, NoMove και NoResize. Αυτά τα κλειδώματα διασφαλίζουν ότι τα σχήματα δεν μπορούν να επιλεχθούν (μέσω κλικ του ποντικιού ή άλλων μεθόδων επιλογής) και ότι δεν μπορούν να μετακινηθούν ή να αλλάξουν μέγεθος.

Τα παραδείγματα κώδικα που ακολουθούν εφαρμόζουν προστασία σε όλους τους τύπους σχημάτων σε μια παρουσίαση.

``` csharp

 //Δημιουργία κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Δημιουργία κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX


//Αντικείμενο ISlide για πρόσβαση στις διαφάνειες της παρουσίασης

SlideEx slide = pTemplate.Slides[0];

//Αντικείμενο IShape για προσωρινή αποθήκευση σχημάτων

ShapeEx shape;

//Διαπέραση όλων των διαφανειών στην παρουσίαση

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Διαπέραση όλων των σχημάτων στις διαφάνειες

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//αν το σχήμα είναι AutoShape

		if (shape is AutoShapeEx)

		{

			//Μετατροπή τύπου σε Auto shape και λήψη του κλειδώματος του Auto shape

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Εφαρμογή κλειδωμάτων στα σχήματα

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//αν το σχήμα είναι GroupShape

		else if (shape is GroupShapeEx)

		{

			//Μετατροπή τύπου σε group shape και λήψη του κλειδώματος του group shape

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Εφαρμογή κλειδωμάτων στα σχήματα

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//αν το σχήμα είναι Connector

		else if (shape is ConnectorEx)

		{

			//Μετατροπή τύπου σε connector shape και λήψη του κλειδώματος του connector shape

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Εφαρμογή κλειδωμάτων στα σχήματα

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//αν το σχήμα είναι PictureFrame

		else if (shape is PictureFrameEx)

		{

			//Μετατροπή τύπου σε picture frame shape και λήψη του κλειδώματος του picture frame shape

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Εφαρμογή κλειδωμάτων στα σχήματα

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Αποθήκευση του αρχείου παρουσίασης

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 

**Αφαίρεση Προστασίας**

Η προστασία που εφαρμόζεται με χρήση του Aspose.Slides for .NET μπορεί να αφαιρεθεί μόνο με το Aspose.Slides for .NET. Για να ξεκλειδώσετε ένα σχήμα, ορίστε την τιμή του εφαρμόσιμου κλειδώματος σε false. Το παράδειγμα κώδικα που ακολουθεί δείχνει πώς να ξεκλειδώσετε σχήματα σε μια κλειδωμένη παρουσίαση.

``` csharp

 //Ανοίξτε την επιθυμητή παρουσίαση
PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//Αντικείμενο ISlide για πρόσβαση στις διαφάνειες της παρουσίασης
SlideEx slide = pTemplate.Slides[0];

//Αντικείμενο IShape για προσωρινή αποθήκευση σχημάτων
ShapeEx shape;

//Διαπέραση όλων των διαφανειών στην παρουσίαση
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
	slide = pTemplate.Slides[slideCount];
	//Διαπέραση όλων των σχημάτων στις διαφάνειες
	for (int count = 0; count < slide.Shapes.Count; count++)
	{
		shape = slide.Shapes[count];
		//αν το σχήμα είναι autoshape
		if (shape is AutoShapeEx)
		{
			//Μετατροπή τύπου σε Auto shape και λήψη του κλειδώματος του auto shape
			AutoShapeEx Ashp = shape as AutoShapeEx;
			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;
			//Εφαρμογή κλειδωμάτων στα σχήματα
			AutoShapeLock.PositionLocked = false;
			AutoShapeLock.SelectLocked = false;
			AutoShapeLock.SizeLocked = false;
		}
		//αν το σχήμα είναι group shape
		else if (shape is GroupShapeEx)
		{
			//Μετατροπή τύπου σε group shape και λήψη του κλειδώματος του group shape
			GroupShapeEx Group = shape as GroupShapeEx;
			GroupShapeLockEx groupShapeLock = Group.ShapeLock;
			//Εφαρμογή κλειδωμάτων στα σχήματα
			groupShapeLock.GroupingLocked = false;
			groupShapeLock.PositionLocked = false;
			groupShapeLock.SelectLocked = false;
			groupShapeLock.SizeLocked = false;
		}
		//αν το σχήμα είναι Connector shape
		else if (shape is ConnectorEx)
		{
			//Μετατροπή τύπου σε connector shape και λήψη του κλειδώματος του connector shape
			ConnectorEx Conn = shape as ConnectorEx;
			ConnectorLockEx ConnLock = Conn.ShapeLock;
			//Εφαρμογή κλειδωμάτων στα σχήματα
			ConnLock.PositionMove = false;
			ConnLock.SelectLocked = false;
			ConnLock.SizeLocked = false;
		}
		//αν το σχήμα είναι picture frame
		else if (shape is PictureFrameEx)
		{
			//Μετατροπή τύπου σε picture frame shape και λήψη του κλειδώματος του picture frame shape
			PictureFrameEx Pic = shape as PictureFrameEx;
			PictureFrameLockEx PicLock = Pic.ShapeLock;
			//Εφαρμογή κλειδωμάτων στα σχήματα
			PicLock.PositionLocked = false;
			PicLock.SelectLocked = false;
			PicLock.SizeLocked = false;
		}
	}
}

//Αποθήκευση του αρχείου παρουσίασης
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **Λήψη Δειγμάτων Κώδικα**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)