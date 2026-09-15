---
title: Πρόβλημα Προεπισκόπησης Αντικειμένου Κατά την Προσθήκη OleObjectFrame
linktitle: Πρόβλημα Αντικειμένου OLE
type: docs
weight: 10
url: /el/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- πρόβλημα προεπισκόπησης
- ενσωματωμένο αντικείμενο
- ενσωματωμένο αρχείο
- αντικείμενο τροποποιήθηκε
- προεπισκόπηση αντικειμένου
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε γιατί εμφανίζεται το EMBEDDED OLE OBJECT όταν προστίθεται OleObjectFrame στο Aspose.Slides για Java και πώς να διορθώσετε τα προβλήματα προεπισκόπησης σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Χρησιμοποιώντας το Aspose.Slides for Java, όταν προσθέτετε το [OleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/oleobjectframe/) σε μια διαφάνεια, εμφανίζεται το μήνυμα "EMBEDDED OLE OBJECT" στη διαφάνεια εξόδου. Αυτό το μήνυμα είναι σκόπιμο και ΔΕΝ αποτελεί σφάλμα.

Για περισσότερες πληροφορίες σχετικά με τη δουλειά με αντικείμενα OLE, δείτε [Manage OLE](/slides/el/java/manage-ole/).

## **Εξήγηση και Λύση**

Το Aspose.Slides εμφανίζει το μήνυμα "EMBEDDED OLE OBJECT" για να σας ενημερώσει ότι το αντικείμενο OLE έχει τροποποιηθεί και ότι η προεπισκόπηση της εικόνας πρέπει να ενημερωθεί.

Για παράδειγμα, εάν προσθέσετε ένα διάγραμμα Microsoft Excel ως [OleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/oleobjectframe/) σε μια διαφάνεια (για περισσότερες λεπτομέρειες, δείτε το άρθρο "Manage OLE") και στη συνέχεια ανοίξετε την παρουσίαση στο Microsoft PowerPoint, θα δείτε αυτήν την εικόνα στη διαφάνεια:

![μήνυμα αντικειμένου OLE](OLE_object_message.png)

Εάν θέλετε να ελέγξετε και να επιβεβαιώσετε ότι το αντικείμενο OLE προστέθηκε στη διαφάνεια, πρέπει να κάνετε διπλό κλικ στο μήνυμα "EMBEDDED OLE OBJECT", ή μπορείτε να κάνετε δεξί κλικ πάνω του και να επιλέξετε την επιλογή **Αντικείμενο > Επεξεργασία**.

![Αντικείμενο > Επεξεργασία](OLE_object_edit.png)

Το PowerPoint ανοίγει τότε το ενσωματωμένο αντικείμενο OLE.

![δεδομένα αντικειμένου OLE](OLE_object_data.png)

Η διαφάνεια μπορεί να διατηρήσει το μήνυμα "EMBEDDED OLE OBJECT". Μόλις κάνετε κλικ στο αντικείμενο OLE, η προεπισκόπηση της διαφάνειας ενημερώνεται και το μήνυμα "EMBEDDED OLE OBJECT" αντικαθίσταται με την πραγματική εικόνα του αντικειμένου OLE.

![προεπισκόπηση αντικειμένου OLE](OLE_object_preview.png)

Τώρα, ίσως θελήσετε να αποθηκεύσετε την παρουσίασή σας ώστε η εικόνα για το αντικείμενο OLE να ενημερωθεί σωστά. Με αυτόν τον τρόπο, αφού αποθηκεύσετε την παρουσίαση, όταν την ανοίξετε ξανά, ΔΕΝ θα δείτε το μήνυμα "EMBEDDED OLE OBJECT".

## **Άλλη Λύση**

Εάν δεν θέλετε να αφαιρέσετε το μήνυμα "EMBEDDED OLE OBJECT" ανοίγοντας την παρουσίαση στο PowerPoint και έπειτα αποθηκεύοντάς την, μπορείτε να αντικαταστήσετε το μήνυμα με την προτιμώμενη εικόνα προεπισκόπησης. Οι παρακάτω γραμμές κώδικα δείχνουν τη διαδικασία:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Προσθέστε μια εικόνα στους πόρους της παρουσίασης.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Ορίστε έναν τίτλο και την εικόνα για την προεπισκόπηση του αντικειμένου OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

Η διαφάνεια που περιέχει το `OleObjectFrame` τότε αλλάζει σε αυτήν:

![νέα εικόνα αντικειμένου OLE](OLE_object_new_image.png)