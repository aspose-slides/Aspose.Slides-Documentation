---
title: Δείκτης Προεπισκόπησης Αντικειμένου κατά την Προσθήκη OleObjectFrame
linktitle: Δείκτης Προεπισκόπησης OLE
type: docs
weight: 10
url: /el/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- πρόβλημα προεπισκόπησης
- δείκτης προεπισκόπησης
- κατά σχεδίαση
- ενσωματωμένο αντικείμενο
- ενσωματωμένο αρχείο
- αντικείμενο που άλλαξε
- προεπισκόπηση αντικειμένου
- παρουσίαση
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Γιατί ένα αντικείμενο OLE που προστέθηκε με το Aspose.Slides για .NET εμφανίζει έναν δείκτη EMBEDDED OLE OBJECT μέχρι να ενημερωθεί η προεπισκόπηση του, και πώς να ορίσετε τη δική σας εικόνα προεπισκόπησης."
---
## **Εισαγωγή**

Χρησιμοποιώντας το Aspose.Slides για .NET, όταν προσθέτετε το [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/) σε μια διαφάνεια, εμφανίζεται το μήνυμα «EMBEDDED OLE OBJECT» στη διαφάνεια εξόδου. Αυτό το μήνυμα είναι σκόπιμο και ΔΕΝ είναι σφάλμα.

Για περισσότερες πληροφορίες σχετικά με τη χρήση αντικειμένων OLE, δείτε το [Manage OLE](/slides/el/net/manage-ole/).

## **Επεξήγηση και Λύση**

Το Aspose.Slides εμφανίζει το μήνυμα «EMBEDDED OLE OBJECT» για να σας ειδοποιήσει ότι το αντικείμενο OLE έχει αλλάξει και ότι η εικόνα προεπισκόπησης πρέπει να ενημερωθεί.

Για παράδειγμα, εάν προσθέσετε ένα διάγραμμα του Microsoft Excel ως [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/) σε μια διαφάνεια (για περισσότερες λεπτομέρειες, δείτε το άρθρο «Manage OLE») και, στη συνέχεια, ανοίξετε την παρουσίαση στο Microsoft PowerPoint, θα δείτε αυτήν την εικόνα στη διαφάνεια:

![Μήνυμα αντικειμένου OLE](OLE_object_message.png)

Αν θέλετε να ελέγξετε και να επιβεβαιώσετε ότι το αντικείμενο OLE προστέθηκε στη διαφάνεια, πρέπει να κάνετε διπλό κλικ στο μήνυμα «EMBEDDED OLE OBJECT», ή μπορείτε να κάνετε δεξί κλικ πάνω του και να περάσετε από την επιλογή **Object > Edit**.

![Αντικείμενο OLE > Επεξεργασία](OLE_object_edit.png)

Το PowerPoint στη συνέχεια ανοίγει το ενσωματωμένο αντικείμενο OLE.

![Δεδομένα αντικειμένου OLE](OLE_object_data.png)

Η διαφάνεια ενδέχεται να διατηρήσει το μήνυμα «EMBEDDED OLE OBJECT». Μόλις κάνετε κλικ στο αντικείμενο OLE, η προεπισκόπηση της διαφάνειας ενημερώνεται και το μήνυμα «EMBEDDED OLE OBJECT» αντικαθίσταται από την πραγματική εικόνα του αντικειμένου OLE.

![Προεπισκόπηση αντικειμένου OLE](OLE_object_preview.png)

Τώρα, ίσως θέλετε να αποθηκεύσετε την παρουσίαση για να διασφαλίσετε ότι η εικόνα του αντικειμένου OLE ενημερώνεται σωστά. Με αυτόν τον τρόπο, αφού αποθηκεύσετε την παρουσίαση, όταν την ανοίξετε ξανά, ΔΕΝ θα δείτε το μήνυμα «EMBEDDED OLE OBJECT».

## **Άλλες Λύσεις**

### **Λύση 1: Αντικατάσταση του μηνύματος «Embedded OLE Object» με μια εικόνα**

Εάν δεν θέλετε να αφαιρέσετε το μήνυμα «EMBEDDED OLE OBJECT» ανοίγοντας την παρουσίαση στο PowerPoint και στη συνέχεια αποθηκεύοντάς την, μπορείτε να αντικαταστήσετε το μήνυμα με την προτιμώμενη εικόνα προεπισκόπησης. Οι παρακάτω γραμμές κώδικα δείχνουν τη διαδικασία:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set the image for the OLE object preview.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

Η διαφάνεια που περιέχει το `OleObjectFrame` τότε αλλάζει σε αυτό:

![Νέα εικόνα αντικειμένου OLE](OLE_object_new_image.png)

### **Λύση 2: Δημιουργία πρόσθετου για PowerPoint**

Μπορείτε επίσης να δημιουργήσετε ένα πρόσθετο για το Microsoft PowerPoint που ενημερώνει όλα τα αντικείμενα OLE όταν ανοίγετε παρουσιάσεις στο πρόγραμμα.