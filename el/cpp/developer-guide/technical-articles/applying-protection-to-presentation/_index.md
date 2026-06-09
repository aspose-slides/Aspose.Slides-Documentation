---
title: Αποτροπή επεξεργασιών παρουσίασης με κλειδώματα σχήματος
linktitle: Αποτροπή επεξεργασιών παρουσίασης
type: docs
weight: 10
url: /el/cpp/applying-protection-to-presentation/
keywords:
- αποτροπή επεξεργασιών
- προστασία από επεξεργασία
- κλείδωμα σχήματος
- κλείδωμα θέσης
- κλείδωμα επιλογής
- κλείδωμα μεγέθους
- κλείδωμα ομαδοποίησης
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Ανακαλύψτε πώς το Aspose.Slides for C++ κλειδώνει ή ξεκλειδώνει σχήματα σε αρχεία PPT, PPTX και ODP, προστατεύοντας τις παρουσιάσεις ενώ επιτρέπει ελεγχόμενες επεξεργασίες και ταχύτερη παράδοση."
---
## **Ιστορικό**

Μια συνηθισμένη χρήση του Aspose.Slides είναι η δημιουργία, η ενημέρωση και η αποθήκευση παρουσιάσεων Microsoft PowerPoint (PPTX) στο πλαίσιο μιας αυτοματοποιημένης ροής εργασιών. Οι χρήστες των εφαρμογών που χρησιμοποιούν το Aspose.Slides με αυτόν τον τρόπο έχουν πρόσβαση στις παραγόμενες παρουσιάσεις, επομένως η προστασία τους από επεξεργασία αποτελεί κοινό ζήτημα. Είναι σημαντικό οι αυτόματα δημιουργημένες παρουσιάσεις να διατηρούν την αρχική μορφοποίηση και το περιεχόμενό τους.

Αυτό το άρθρο εξηγεί πώς δομούνται οι παρουσιάσεις και οι διαφάνειες και πώς το Aspose.Slides for C++ μπορεί να εφαρμόσει προστασία σε μια παρουσίαση και αργότερα να την αφαιρέσει. Παρέχει στους προγραμματιστές έναν τρόπο να ελέγχουν πώς χρησιμοποιούνται οι παρουσιάσεις που δημιουργούν οι εφαρμογές τους.

## **Σύνθεση μιας Διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από στοιχεία όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνας, πλαίσια βίντεο, συνδέσμους και άλλα στοιχεία που χρησιμοποιούνται για τη δημιουργία μιας παρουσίασης. Στο Aspose.Slides for C++, κάθε στοιχείο σε μια διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που υλοποιεί το [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/) interface ή κληρονομεί από μια κλάση που το κάνει.

Η δομή του PPTX είναι πολύπλοκη, έτσι σε αντίθεση με το PPT, όπου μπορεί να χρησιμοποιηθεί ένας γενικός κλείδωμα για όλους τους τύπους σχημάτων, διαφορετικοί τύποι σχημάτων απαιτούν διαφορετικά κλειδώματα. Το interface [IBaseShapeLock](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseshapelock/) είναι η γενική κλάση κλειδώματος για το PPTX. Οι ακόλουθοι τύποι κλειδωμάτων υποστηρίζονται στο Aspose.Slides for C++ για PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshapelock/) κλειδώνει αυτόματα σχήματα.  
- [IConnectorLock](https://reference.aspose.com/slides/el/cpp/aspose.slides/iconnectorlock/) κλειδώνει τα σχήματα συνδέσεων.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/el/cpp/aspose.slides/igraphicalobjectlock/) κλειδώνει γραφικά αντικείμενα.  
- [IGroupShapeLock](https://reference.aspose.com/slides/el/cpp/aspose.slides/igroupshapelock/) κλειδώνει τα ομαδοποιημένα σχήματα.  
- [IPictureFrameLock](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframelock/) κλειδώνει τα πλαίσια εικόνας.   

Οποιαδήποτε ενέργεια εκτελείται σε όλα τα αντικείμενα σχήματος σε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) εφαρμόζεται σε ολόκληρη την παρουσίαση.

## **Εφαρμογή και Αφαίρεση Προστασίας**

Η εφαρμογή προστασίας εξασφαλίζει ότι μια παρουσίαση δεν μπορεί να υποστεί επεξεργασία. Είναι μια χρήσιμη τεχνική για την προστασία του περιεχομένου της παρουσίασης.

### **Εφαρμογή Προστασίας σε Σχήματα PPTX**

Το Aspose.Slides for C++ παρέχει το interface [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/) για εργασία με σχήματα σε μια διαφάνεια.

Όπως αναφέρθηκε νωρίτερα, κάθε τάξη σχήματος έχει μια συσχετισμένη τάξη κλειδώματος σχήματος για προστασία. Αυτό το άρθρο εστιάζει στα κλειδώματα NoSelect, NoMove και NoResize. Αυτά τα κλειδώματα εξασφαλίζουν ότι τα σχήματα δεν μπορούν να επιλεγούν (μέσω κλικ του ποντικιού ή άλλων μεθόδων επιλογής) και ότι δεν μπορούν να μετακινηθούν ή να αλλάξουν το μέγεθός τους.

Το παρακάτω δείγμα κώδικα εφαρμόζει προστασία σε όλους τους τύπους σχημάτων σε μια παρουσίαση.

```cpp
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Διασχίζοντας όλες τις διαφάνειες της παρουσίασης.
for (auto&& slide : presentation->get_Slides())	{

	// Διασχίζοντας όλα τα σχήματα στη διαφάνεια.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Μετατροπή του σχήματος σε αυτόματο σχήμα και λήψη του κλειδώματος σχήματος.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Μετατροπή του σχήματος σε ομαδοποιημένο σχήμα και λήψη του κλειδώματος σχήματος.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Μετατροπή του σχήματος σε σχήμα σύνδεσης και λήψη του κλειδώματος σχήματος.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Μετατροπή του σχήματος σε πλαίσιο εικόνας και λήψη του κλειδώματος σχήματος.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// Αποθήκευση του αρχείου παρουσίασης.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Αφαίρεση Προστασίας**

Για να ξεκλειδώσετε ένα σχήμα, ορίστε την τιμή του εφαρμοσμένου κλειδώματος σε `false`. Το παρακάτω δείγμα κώδικα δείχνει πώς να ξεκλειδώσετε σχήματα σε μια κλειδωμένη παρουσίαση.

```cpp
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// Διασχίζοντας όλες τις διαφάνειες της παρουσίασης.
for (auto&& slide : presentation->get_Slides())	{

	// Διασχίζοντας όλα τα σχήματα στη διαφάνεια.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Μετατροπή του σχήματος σε αυτόματο σχήμα και λήψη του κλειδώματος σχήματος.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Μετατροπή του σχήματος σε ομαδοποιημένο σχήμα και λήψη του κλειδώματος σχήματος.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Μετατροπή του σχήματος σε σχήμα σύνδεσης και λήψη του κλειδώματος σχήματος.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Μετατροπή του σχήματος σε πλαίσιο εικόνας και λήψη του κλειδώματος σχήματος.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// Αποθήκευση του αρχείου παρουσίασης.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Συμπέρασμα**

Το Aspose.Slides προσφέρει πολλές επιλογές για την προστασία των σχημάτων σε μια παρουσίαση. Μπορείτε να κλειδώσετε ένα μεμονωμένο σχήμα ή να περάσετε διαμέσου όλων των σχημάτων σε μια παρουσίαση και να κλειδώσετε το καθένα για να εξασφαλίσετε αποτελεσματικά όλο το αρχείο. Μπορείτε να αφαιρέσετε την προστασία ορίζοντας την τιμή του κλειδώματος σε `false`.

## **Συχνές Ερωτήσεις**

**Μπορώ να συνδυάσω κλειδώματα σχημάτων και προστασία με κωδικό πρόσβασης στην ίδια παρουσίαση;**

Ναι. Τα κλειδώματα περιορίζουν την επεξεργασία αντικειμένων μέσα στο αρχείο, ενώ η [password protection](/slides/el/cpp/password-protected-presentation/) ελέγχει την πρόσβαση στο άνοιγμα και/ή την αποθήκευση αλλαγών. Αυτοί οι μηχανισμοί συμπληρώνουν ο ένας τον άλλον και λειτουργούν μαζί.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώματα στα σχήματα των επιλεγμένων διαφανειών· οι υπόλοιπες διαφάνειες θα παραμείνουν επεξεργάσιμες.

**Ισχύουν τα κλειδώματα σχημάτων για ομαδοποιημένα αντικείμενα και συνδέσμους;**

Ναι. Υποστηρίζονται ειδικοί τύποι κλειδωμάτων για ομάδες, συνδέσμους, γραφικά αντικείμενα και άλλα είδη σχημάτων.