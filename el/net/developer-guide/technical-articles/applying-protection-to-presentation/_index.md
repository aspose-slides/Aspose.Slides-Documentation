---
title: Αποτροπή Επεξεργασιών Παρουσίασης με Κλειδώματα Σχημάτων στην .NET
linktitle: Αποτροπή Επεξεργασιών Παρουσίασης
type: docs
weight: 70
url: /el/net/applying-protection-to-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Ανακαλύψτε πώς το Aspose.Slides για .NET κλειδώνει ή ξεκλειδώνει σχήματα σε αρχεία PPT, PPTX και ODP, εξασφαλίζοντας τις παρουσιάσεις ενώ επιτρέπει ελεγχόμενες επεξεργασίες."
---
## **Ιστορικό**

Μια κοινή χρήση του Aspose.Slides είναι η δημιουργία, ενημέρωση και αποθήκευση παρουσιάσεων Microsoft PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Οι χρήστες εφαρμογών που χρησιμοποιούν το Aspose.Slides με αυτόν τον τρόπο έχουν πρόσβαση στις δημιουργημένες παρουσιάσεις, επομένως η προστασία τους από επεξεργασία αποτελεί κοινή ανησυχία. Είναι σημαντικό οι αυτόματα δημιουργημένες παρουσιάσεις να διατηρούν την αρχική μορφοποίηση και το περιεχόμενό τους.

Αυτό το άρθρο εξηγεί πώς δομούνται οι παρουσιάσεις και οι διαφάνειες και πώς το Aspose.Slides για .NET μπορεί να εφαρμόσει προστασία σε μια παρουσίαση και στη συνέχεια να την αφαιρέσει. Παρέχει στους προγραμματιστές έναν τρόπο να ελέγχουν πώς χρησιμοποιούνται οι παρουσιάσεις που δημιουργούν οι εφαρμογές τους.

## **Σύνθεση μιας Διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από στοιχεία όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνας, πλαίσια βίντεο, συνδέσεις και άλλα στοιχεία που χρησιμοποιούνται για τη δημιουργία μιας παρουσίασης. Στο Aspose.Slides για .NET, κάθε στοιχείο σε μια διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που υλοποιεί τη διεπαφή [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/) ή κληρονομεί από μια κλάση που το κάνει.

Η δομή του PPTX είναι πολύπλοκη, επομένως, σε αντίθεση με το PPT, όπου μπορεί να χρησιμοποιηθεί ένα γενικό κλείδωμα για όλους τους τύπους σχημάτων, διαφορετικοί τύποι σχημάτων απαιτούν διαφορετικά κλειδώματα. Η διεπαφή [IBaseShapeLock](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseshapelock/) είναι η γενική κλάση κλειδώματος για το PPTX. Οι παρακάτω τύποι κλειδωμάτων υποστηρίζονται στο Aspose.Slides για .NET για το PPTX:

- Το [IAutoShapeLock](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshapelock/) κλειδώνει τα αυτόματα σχήματα.  
- Το [IConnectorLock](https://reference.aspose.com/slides/el/net/aspose.slides/iconnectorlock/) κλειδώνει τα σχήματα συνδέσεων.  
- Το [IGraphicalObjectLock](https://reference.aspose.com/slides/el/net/aspose.slides/igraphicalobjectlock/) κλειδώνει τα γραφικά αντικείμενα.  
- Το [IGroupShapeLock](https://reference.aspose.com/slides/el/net/aspose.slides/igroupshapelock/) κλειδώνει τα ομαδοποιημένα σχήματα.  
- Το [IPictureFrameLock](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframelock/) κλειδώνει τα πλαίσια εικόνας.  

Οποιαδήποτε ενέργεια εκτελεστεί σε όλα τα αντικείμενα σχήματος σε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) εφαρμόζεται σε ολόκληρη την παρουσίαση.

## **Εφαρμογή και Κατάργηση Προστασίας**

Η εφαρμογή προστασίας διασφαλίζει ότι μια παρουσίαση δεν μπορεί να επεξεργαστεί. Είναι μια χρήσιμη τεχνική για την προστασία του περιεχομένου της παρουσίασης.

### **Εφαρμογή Προστασίας σε Σχήματα PPTX**

Το Aspose.Slides για .NET παρέχει τη διεπαφή [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/) για εργασία με σχήματα σε μια διαφάνεια.

Όπως αναφέρθηκε νωρίτερα, κάθε κλάση σχήματος έχει μια συνδεδεμένη κλάση κλειδώματος σχήματος για προστασία. Αυτό το άρθρο εστιάζει στα κλειδώματα NoSelect, NoMove και NoResize. Αυτά τα κλειδώματα διασφαλίζουν ότι τα σχήματα δεν μπορούν να επιλεγούν (μέσω κλικ του ποντικιού ή άλλων μεθόδων επιλογής) και ότι δεν μπορούν να μετακινηθούν ή να αλλάξουν μέγεθος.

Το παρακάτω παράδειγμα κώδικα εφαρμόζει προστασία σε όλους τους τύπους σχημάτων σε μια παρουσίαση.

```cs
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
using Presentation presentation = new Presentation("Sample.pptx");

// Περιήγηση σε όλες τις διαφάνειες της παρουσίασης.
foreach (ISlide slide in presentation.Slides)
{
    // Περιήγηση σε όλα τα σχήματα της διαφάνειας.
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

// Αποθήκευση του αρχείου παρουσίασης.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Κατάργηση Προστασίας**

Για να ξεκλειδώσετε ένα σχήμα, ορίστε την τιμή του εφαρμόσμενου κλειδώματος σε `false`. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ξεκλειδώσετε σχήματα σε μια κλειδωμένη παρουσίαση.

```cs
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// Περιήγηση σε όλες τις διαφάνειες της παρουσίασης.
foreach (ISlide slide in presentation.Slides)
{
    // Περιήγηση σε όλα τα σχήματα της διαφάνειας.
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

// Αποθήκευση του αρχείου παρουσίασης.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Συμπέρασμα**

Το Aspose.Slides προσφέρει αρκετές επιλογές για την προστασία σχημάτων σε μια παρουσίαση. Μπορείτε να κλειδώσετε ένα μεμονωμένο σχήμα ή να επαναλάβετε όλα τα σχήματα σε μια παρουσίαση και να κλειδώσετε καθένα ώστε να ασφαλιστεί αποτελεσματικά ολόκληρο το αρχείο. Μπορείτε να αφαιρέσετε την προστασία ορίζοντας την τιμή του κλειδώματος σε `false`.

## **Συχνές Ερωτήσεις**

**Μπορώ να συνδυάσω τα κλειδώματα σχημάτων και την προστασία με κωδικό στην ίδια παρουσίαση;**

Ναι. Τα κλειδώματα περιορίζουν την επεξεργασία των αντικειμένων μέσα στο αρχείο, ενώ η [προστασία με κωδικό](/slides/el/net/password-protected-presentation/) ελέγχει την πρόσβαση στο άνοιγμα και/ή στην αποθήκευση αλλαγών. Αυτοί οι μηχανισμοί συμπληρώνουν ο ένας τον άλλον και λειτουργούν μαζί.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώματα στα σχήματα των επιλεγμένων διαφανειών· οι υπόλοιπες διαφάνειες θα παραμείνουν επεξεργάσιμες.

**Εφαρμόζονται τα κλειδώματα σχημάτων σε ομαδοποιημένα αντικείμενα και συνδέσμους;**

Ναι. Υποστηρίζονται ειδικοί τύποι κλειδωμάτων για ομάδες, συνδέσμους, γραφικά αντικείμενα και άλλα είδη σχημάτων.