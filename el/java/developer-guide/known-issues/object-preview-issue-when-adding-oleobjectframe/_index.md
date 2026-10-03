---
title: Δείγμα Προεπισκόπησης Αντικειμένου Όταν Προστίθεται OleObjectFrame
linktitle: Δείγμα Προεπισκόπησης OLE
type: docs
weight: 10
url: /el/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- πρόβλημα προεπισκόπησης
- δείκτης κράτησης προεπισκόπησης
- επίτηδες
- ενσωματωμένο αντικείμενο
- ενσωματωμένο αρχείο
- αντικείμενο άλλαξε
- προεπισκόπηση αντικειμένου
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Γιατί ένα αντικείμενο OLE που προστέθηκε με Aspose.Slides για Java εμφανίζει έναν δείκτη κράτησης EMBEDDED OLE OBJECT μέχρι να ενημερωθεί η προεπισκόπηση του, και πώς να ορίσετε τη δική σας εικόνα προεπισκόπησης."
---
## **Εισαγωγή**

Χρησιμοποιώντας το Aspose.Slides για Java, όταν προσθέτετε [OleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/oleobjectframe/) σε μια διαφάνεια, εμφανίζεται το μήνυμα "EMBEDDED OLE OBJECT" στη διαφάνεια εξόδου. Αυτό το μήνυμα είναι σκόπιμο και ΔΕΝ αποτελεί σφάλμα.

Για περισσότερες πληροφορίες σχετικά με τη χρήση αντικειμένων OLE, δείτε [Διαχείριση OLE](/slides/el/java/manage-ole/).

## **Εξήγηση και Λύση**

Το Aspose.Slides εμφανίζει το μήνυμα "EMBEDDED OLE OBJECT" για να σας ενημερώσει ότι το αντικείμενο OLE έχει αλλάξει και η εικόνα προεπισκόπησης πρέπει να ενημερωθεί.

Για παράδειγμα, εάν προσθέσετε ένα διάγραμμα Microsoft Excel ως [OleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/oleobjectframe/) σε μια διαφάνεια (για περισσότερες λεπτομέρειες, δείτε το άρθρο "Manage OLE") και στη συνέχεια ανοίξετε την παρουσίαση στο Microsoft PowerPoint, θα δείτε αυτή την εικόνα στη διαφάνεια:

![Μήνυμα αντικειμένου OLE](OLE_object_message.png)

Εάν θέλετε να ελέγξετε και να επιβεβαιώσετε ότι το αντικείμενο OLE προστέθηκε στη διαφάνεια, πρέπει να κάνετε διπλό κλικ στο μήνυμα "EMBEDDED OLE OBJECT", ή μπορείτε να κάνετε δεξί κλικ επάνω του και να περάσετε από την επιλογή **Object > Edit**.

![Αντικείμενο OLE > Επεξεργασία](OLE_object_edit.png)

Το PowerPoint έπειτα ανοίγει το ενσωματωμένο αντικείμενο OLE.

![Δεδομένα αντικειμένου OLE](OLE_object_data.png)

Η διαφάνεια ενδέχεται να διατηρήσει το μήνυμα "EMBEDDED OLE OBJECT". Μόλις κάνετε κλικ στο αντικείμενο OLE, η προεπισκόπηση της διαφάνειας ενημερώνεται και το μήνυμα "EMBEDDED OLE OBJECT" αντικαθίσταται από την πραγματική εικόνα του αντικειμένου OLE.

![Προεπισκόπηση αντικειμένου OLE](OLE_object_preview.png)

Τώρα, ίσως θελήσετε να αποθηκεύσετε την παρουσίαση για να διασφαλίσετε ότι η εικόνα του αντικειμένου OLE ενημερώνεται σωστά. Με αυτόν τον τρόπο, μετά την αποθήκευση της παρουσίασης, όταν ανοίξετε ξανά την παρουσίαση, ΔΕΝ θα δείτε το μήνυμα "EMBEDDED OLE OBJECT".

## **Άλλη Λύση**

Εάν δεν θέλετε να αφαιρέσετε το μήνυμα "EMBEDDED OLE OBJECT" ανοίγοντας την παρουσίαση στο PowerPoint και στη συνέχεια αποθηκεύοντάς την, μπορείτε να αντικαταστήσετε το μήνυμα με την προτιμώμενη εικόνα προεπισκόπησης. Αυτές οι γραμμές κώδικα δείχνουν τη διαδικασία. Υποθέτουν ότι το πρώτο σχήμα στην πρώτη διαφάνεια του *embeddedOLE.pptx* είναι το πλαίσιο αντικειμένου OLE και ότι το *myImage.png* περιέχει την εικόνα που θα εμφανιστεί, και αποθηκεύουν το αποτέλεσμα ως *embeddedOLE-newImage.pptx*:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Προσθέστε μια εικόνα στους πόρους της παρουσίασης.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // Ορίστε την εικόνα για την προεπισκόπηση του αντικειμένου OLE.
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η διαφάνεια που περιέχει το `OleObjectFrame` στη συνέχεια αλλάζει σε αυτό:

![Νέα εικόνα αντικειμένου OLE](OLE_object_new_image.png)