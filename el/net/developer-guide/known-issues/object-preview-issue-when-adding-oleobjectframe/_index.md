---
title: Πρόβλημα προεπισκόπησης αντικειμένου κατά την προσθήκη OleObjectFrame
linktitle: Πρόβλημα αντικειμένου OLE
type: docs
weight: 10
url: /el/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- πρόβλημα προεπισκόπησης
- ενσωματωμένο αντικείμενο
- ενσωματωμένο αρχείο
- αντικείμενο τροποποιήθηκε
- προεπισκόπηση αντικειμένου
- παρουσίαση
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Μάθετε γιατί εμφανίζεται το EMBEDDED OLE OBJECT όταν προσθέτετε OleObjectFrame στο Aspose.Slides for .NET και πώς να διορθώσετε τα προβλήματα προεπισκόπησης σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Χρησιμοποιώντας το Aspose.Slides for .NET, όταν προσθέτετε [OleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe) σε μια διαφάνεια, εμφανίζεται ένα μήνυμα «EMBEDDED OLE OBJECT» στη διαφάνεια εξόδου. Αυτό το μήνυμα είναι εσκεμμένο και ΔΕΝ είναι σφάλμα.

Για περισσότερες πληροφορίες σχετικά με τη χρήση αντικειμένων OLE, δείτε [Manage OLE](/slides/el/net/manage-ole/). 

## **Εξήγηση και Λύση**

Το Aspose.Slides εμφανίζει το μήνυμα «EMBEDDED OLE OBJECT» για να σας ενημερώσει ότι το αντικείμενο OLE έχει τροποποιηθεί και πρέπει να ενημερωθεί η εικόνα προεπισκόπησης. 

Για παράδειγμα, εάν προσθέσετε ένα γράφημα Microsoft Excel ως [OleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe) σε μια διαφάνεια (για περισσότερες λεπτομέρειες, δείτε το άρθρο «Manage OLE») και στη συνέχεια ανοίξετε την παρουσίαση στο Microsoft PowerPoint, θα δείτε αυτήν την εικόνα στη διαφάνεια:

![Μήνυμα αντικειμένου OLE](OLE_object_message.png)

Εάν θέλετε να ελέγξετε και να επιβεβαιώσετε ότι το αντικείμενο OLE προστέθηκε στη διαφάνεια, πρέπει να κάνετε διπλό κλικ στο μήνυμα «EMBEDDED OLE OBJECT», ή μπορείτε να κάνετε δεξί κλικ πάνω του και να επιλέξετε την επιλογή **Object > Edit**.

![Αντικείμενο OLE > Επεξεργασία](OLE_object_edit.png)

Το PowerPoint στη συνέχεια ανοίγει το ενσωματωμένο αντικείμενο OLE.

![Δεδομένα αντικειμένου OLE](OLE_object_data.png)

Η διαφάνεια μπορεί να διατηρεί το μήνυμα «EMBEDDED OLE OBJECT». Μόλις κάνετε κλικ στο αντικείμενο OLE, η προεπισκόπηση της διαφάνειας ενημερώνεται και το μήνυμα «EMBEDDED OLE OBJECT» αντικαθίσταται με την πραγματική εικόνα του αντικειμένου OLE. 

![Προεπισκόπηση αντικειμένου OLE](OLE_object_preview.png)

Τώρα, ίσως θελήσετε να αποθηκεύσετε την παρουσίασή σας για να εξασφαλίσετε ότι η εικόνα του αντικειμένου OLE ενημερώνεται σωστά. Με αυτόν τον τρόπο, μετά την αποθήκευση της παρουσίασης, όταν την ανοίξετε ξανά, ΔΕΝ θα δείτε το μήνυμα «EMBEDDED OLE OBJECT». 

## **Άλλες Λύσεις**

### **Λύση 1: Αντικατάσταση του μηνύματος «Embedded OLE Object» με μια εικόνα**

Αν δεν θέλετε να αφαιρέσετε το μήνυμα «EMBEDDED OLE OBJECT» ανοίγοντας την παρουσίαση στο PowerPoint και στη συνέχεια αποθηκεύοντάς την, μπορείτε να αντικαταστήσετε το μήνυμα με την προτιμώμενη εικόνα προεπισκόπησης. Αυτές οι γραμμές κώδικα δείχνουν τη διαδικασία:

```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Προσθέστε μια εικόνα στους πόρους της παρουσίασης.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Ορίστε έναν τίτλο και την εικόνα για την προεπισκόπηση του αντικειμένου OLE.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

Η διαφάνεια που περιέχει το `OleObjectFrame` μετά αλλάζει σε αυτό:

![Νέα εικόνα αντικειμένου OLE](OLE_object_new_image.png)

### **Λύση 2: Δημιουργία πρόσθετου για PowerPoint**

Μπορείτε επίσης να δημιουργήσετε ένα πρόσθετο για το Microsoft PowerPoint που θα ενημερώνει όλα τα αντικείμενα OLE όταν ανοίγετε παρουσιάσεις στο πρόγραμμα.