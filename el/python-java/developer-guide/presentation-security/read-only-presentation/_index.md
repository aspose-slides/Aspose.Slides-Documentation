---
title: Αποθήκευση παρουσιάσεων σε λειτουργία ανάγνωση-μόνο χρησιμοποιώντας Python
linktitle: Παρουσίαση ανάγνωση-μόνο
type: docs
weight: 30
url: /el/python-java/read-only-presentation/
keywords:
- μόνο για ανάγνωση
- προστασία παρουσίασης
- αποτροπή επεξεργασίας
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Φόρτωση και αποθήκευση αρχείων PowerPoint (PPT, PPTX) σε λειτουργία ανάγνωση-μόνο με Aspose.Slides for Python via Java, προσφέροντας ακριβείς προεπισκοπήσεις διαφανειών χωρίς να αλλάζετε τις παρουσιάσεις σας."
---
## **Εισαγωγή**

Στο PowerPoint 2019, η Microsoft εισήγαγε τη ρύθμιση **Always Open Read-Only** ως μία από τις επιλογές που μπορούν να χρησιμοποιούν οι χρήστες για να προστατεύσουν τις παρουσιάσεις τους. Μπορείτε να θέλετε να χρησιμοποιήσετε αυτή τη ρύθμιση **Read-Only** για να προστατεύσετε μια παρουσίαση όταν:

- Θέλετε να αποτρέψετε τυχαίες επεμβάσεις και να κρατήσετε το περιεχόμενο της παρουσίασής σας ασφαλές. 
- Θέλετε να ενημερώσετε τους ανθρώπους ότι η παρουσίαση που παρέχετε είναι η τελική έκδοση. 

Αφού επιλέξετε την επιλογή **Always Open Read-Only** για μια παρουσίαση, όταν οι χρήστες ανοίξουν την παρουσίαση, βλέπουν τη σύσταση **Read-Only** και μπορεί να εμφανιστεί το ακόλουθο μήνυμα: *Για να αποτραπούν τυχαίες αλλαγές, ο δημιουργός έχει ορίσει αυτό το αρχείο να ανοίγει ως ανάγνωση-μόνο.*

Η σύσταση **Read-Only** είναι ένα απλό όμως αποτελεσματικό αποτρεπτικό μέτρο που αποθαρρύνει την επεξεργασία, επειδή οι χρήστες πρέπει να εκτελέσουν μια ενέργεια για να την αφαιρέσουν πριν τους επιτραπεί η επεξεργασία μιας παρουσίασης. Εάν δεν θέλετε οι χρήστες να κάνουν αλλαγές σε μια παρουσίαση και θέλετε να το ενημερώσετε με ευγενικό τρόπο, τότε η σύσταση **Read-Only** μπορεί να είναι μια καλή επιλογή για εσάς. 

> Εάν μια παρουσίαση με προστασία **Read-Only** ανοίξει σε παλαιότερη έκδοση του Microsoft PowerPoint—που δεν υποστηρίζει τη πρόσφατα εισαχθείσα λειτουργία—η σύσταση **Read-Only** αγνοείται (η παρουσίαση ανοίγει κανονικά).

## **Εφαρμογή Λειτουργίας Read-Only**

Το Aspose.Slides for Python μέσω Java σάς επιτρέπει να ορίσετε μια παρουσίαση σε **Read-Only**, που σημαίνει ότι οι χρήστες (αφού ανοίξουν την παρουσίαση) βλέπουν τη σύσταση **Read-Only**. Αυτό το δείγμα κώδικα σας δείχνει πώς να ορίσετε μια παρουσίαση σε **Read-Only** σε Python χρησιμοποιώντας το Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Η σύσταση **Read-Only** προορίζεται απλώς να αποθαρρύνει την επεξεργασία ή να εμποδίσει τους χρήστες να κάνουν τυχαίες αλλαγές σε μια παρουσίαση PowerPoint. Εάν ένα κίνητο άτομο—που γνωρίζει τι κάνει—αποφασίσει να επεξεργαστεί την παρουσίασή σας, μπορεί εύκολα να αφαιρέσει τη ρύθμιση Read-Only. Εάν χρειάζεστε σοβαρά την πρόληψη μη εξουσιοδοτημένης επεξεργασίας, είναι καλύτερο να χρησιμοποιήσετε [more stringent protections that involve encryption and passwords](/slides/el/python-java/password-protected-presentation/). 

{{% /alert %}} 

## **Συχνές ερωτήσεις**

**Πώς διαφέρει το 'Read-Only recommended' από την πλήρη προστασία με κωδικό;**

`'Read-Only recommended'` εμφανίζει μόνο μια πρόταση να ανοίξει το αρχείο σε λειτουργία ανάγνωσης-μόνο και είναι εύκολο να παρακαμφθεί. Η [Password protection](/slides/el/python-java/password-protected-presentation/) περιορίζει πραγματικά το άνοιγμα ή την επεξεργασία και είναι κατάλληλη όταν χρειάζεστε αληθινό έλεγχο ασφαλείας. 

**Μπορεί το 'Read-Only recommended' να συνδυαστεί με υδατογραφήματα για να αποθαρρύνει περαιτέρω τις επεμβάσεις;**

Ναι. Η σύσταση μπορεί να συνδυαστεί με [watermarks](/slides/el/python-java/watermark/) ως οπτικό αποτρεπτικό μέτρο· είναι ξεχωριστοί μηχανισμοί και λειτουργούν καλά μαζί. 

**Μπορεί μια μακροεντολή ή εξωτερικό εργαλείο ακόμη να τροποποιήσει το αρχείο όταν η σύσταση είναι ενεργοποιημένη;**

Ναι. Η σύσταση δεν εμποδίζει τις προγραμματισμένες αλλαγές. Για να αποτρέψετε αυτοματοποιημένες επεμβάσεις, χρησιμοποιήστε [passwords and encryption](/slides/el/python-java/password-protected-presentation/). 

**Πώς σχετίζεται το 'Read-Only recommended' με τις μεθόδους [isEncrypted](https://reference.aspose.com/slides/el/python-java/aspose.slides/protectionmanager/#isEncrypted) και [isWriteProtected](https://reference.aspose.com/slides/el/python-java/aspose.slides/protectionmanager/#isWriteProtected);**

Πρόκειται για διαφορετικά σήματα. Το 'Read-Only recommended' είναι μια ήπια, προαιρετική προτροπή· τα [isWriteProtected](https://reference.aspose.com/slides/el/python-java/aspose.slides/protectionmanager/#isWriteProtected) και [isEncrypted](https://reference.aspose.com/slides/el/python-java/aspose.slides/protectionmanager/#isEncrypted) υποδεικνύουν πραγματικούς περιορισμούς εγγραφής ή ανάγνωσης που εξαρτώνται από κωδικούς ή κρυπτογράφηση.