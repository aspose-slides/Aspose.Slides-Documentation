---
title: Πρόβλημα Προεπισκόπησης Αντικειμένου Κατά την Προσθήκη OleObjectFrame
linktitle: Πρόβλημα Αντικειμένου OLE
type: docs
weight: 10
url: /el/androidjava/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- πρόβλημα προεπισκόπησης
- ενσωματωμένο αντικείμενο
- ενσωματωμένο αρχείο
- αντικείμενο αλλαγμένο
- προεπισκόπηση αντικειμένου
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε γιατί εμφανίζεται το EMBEDDED OLE OBJECT κατά την προσθήκη OleObjectFrame στο Aspose.Slides για Android μέσω Java και πώς να διορθώσετε τα προβλήματα προεπισκόπησης σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Χρησιμοποιώντας το Aspose.Slides για Android μέσω Java, όταν προσθέτετε το [OleObjectFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/oleobjectframe/) σε μια διαφάνεια, εμφανίζεται το μήνυμα "EMBEDDED OLE OBJECT" στη διαφάνεια εξόδου. Αυτό το μήνυμα είναι σκόπιμο και ΔΕΝ αποτελεί σφάλμα.

Για περισσότερες πληροφορίες σχετικά με τη χρήση αντικειμένων OLE, δείτε την ενότητα [Manage OLE](/slides/el/androidjava/manage-ole/). 

## **Εξήγηση και Λύση**

Το Aspose.Slides εμφανίζει το μήνυμα "EMBEDDED OLE OBJECT" για να σας ειδοποιήσει ότι το αντικείμενο OLE έχει αλλάξει και η προεπισκόπηση εικόνας πρέπει να ενημερωθεί. 

Για παράδειγμα, εάν προσθέσετε ένα γράφημα Microsoft Excel ως [OleObjectFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/oleobjectframe/) σε μια διαφάνεια (για περισσότερες λεπτομέρειες, δείτε το άρθρο "Manage OLE") και έπειτα ανοίξετε την παρουσίαση στο Microsoft PowerPoint, θα δείτε αυτήν την εικόνα στη διαφάνεια:

![μήνυμα αντικειμένου OLE](OLE_object_message.png)

Αν θέλετε να ελέγξετε και να επιβεβαιώσετε ότι το αντικείμενο OLE προστέθηκε στη διαφάνεια, πρέπει να κάνετε διπλό κλικ στο μήνυμα "EMBEDDED OLE OBJECT", ή μπορείτε να κάνετε δεξί κλικ σε αυτό και να επιλέξετε την επιλογή **Αντικείμενο > Επεξεργασία**.

![Αντικείμενο OLE > Επεξεργασία](OLE_object_edit.png)

Το PowerPoint τότε ανοίγει το ενσωματωμένο αντικείμενο OLE.

![δεδομένα αντικειμένου OLE](OLE_object_data.png)

Η διαφάνεια μπορεί να διατηρεί το μήνυμα "EMBEDDED OLE OBJECT". Μόλις κάνετε κλικ στο αντικείμενο OLE, η προεπισκόπηση της διαφάνειας ενημερώνεται και το μήνυμα "EMBEDDED OLE OBJECT" αντικαθίσταται από την πραγματική εικόνα του αντικειμένου OLE. 

![προεπισκόπηση αντικειμένου OLE](OLE_object_preview.png)

Τώρα, ίσως θέλετε να αποθηκεύσετε την παρουσίασή σας για να διασφαλίσετε ότι η εικόνα του αντικειμένου OLE ενημερώνεται σωστά. Με αυτόν τον τρόπο, μετά την αποθήκευση της παρουσίασης, όταν την ανοίξετε ξανά, ΔΕΝ θα δείτε το μήνυμα "EMBEDDED OLE OBJECT". 

## **Άλλες Λύσεις**

### **Λύση 1: Αντικατάσταση του μηνύματος "Embedded OLE Object" με εικόνα**

Αν δεν θέλετε να αφαιρέσετε το μήνυμα "EMBEDDED OLE OBJECT" ανοίγοντας την παρουσίαση στο PowerPoint και στη συνέχεια αποθηκεύοντάς την, μπορείτε να αντικαταστήσετε το μήνυμα με την προτιμώμενη εικόνα προεπισκόπησης. Οι παρακάτω γραμμές κώδικα δείχνουν τη διαδικασία:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Προσθήκη εικόνας στους πόρους της παρουσίασης.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Ορισμός τίτλου και εικόνας για την προεπισκόπηση του αντικειμένου OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

Η διαφάνεια που περιέχει το `OleObjectFrame` αλλάζει σε αυτήν:

![νέα εικόνα αντικειμένου OLE](OLE_object_new_image.png)

### **Λύση 2: Δημιουργία πρόσθετου για το PowerPoint**

Μπορείτε επίσης να δημιουργήσετε ένα πρόσθετο για το Microsoft PowerPoint που ενημερώνει όλα τα αντικείμενα OLE όταν ανοίγετε παρουσιάσεις στο πρόγραμμα.