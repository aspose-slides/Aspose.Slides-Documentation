---
title: Γεννήτρια Πολυγλωσσικών Διαφανειών με Τεχνητή Νοημοσύνη
linktitle: Γεννήτρια με Τεχνητή Νοημοσύνη
type: docs
weight: 40
url: /el/python-java/ai/generator/
keywords:
- πολυγλωσσική παρουσίαση
- πολυγλωσσική διαφάνεια
- γεννήτρια παρουσίασης με AI
- γεννήτρια διαφανειών με AI
- πρότυπο παρουσίασης
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Δημιουργήστε πολυγλωσσικές παρουσιάσεις από κείμενο με το Aspose.Slides για Python μέσω Java. Επιλέξτε λεπτομέρεια περιεχομένου, εφαρμόστε ένα πρότυπο, και εξάγετε σε PowerPoint ή PDF."
---
## **Εισαγωγή**

Η Γεννήτρια Παρουσιάσεων AI στο Aspose.Slides για Python μέσω Java δημιουργεί παρουσιάσεις από περιγραφές θέματος, συνοπτικές περιλήψεις, παραθέσεις ή σημειώσεις με κουκκίδες. Καθορίστε τη ζητούμενη γλώσσα στην προτροπή σας, επιλέξτε την ποσότητα του περιεχομένου και, προαιρετικά, παρέχετε ένα πρότυπο παρουσίασης για να ορίσετε τη διάταξη και το σχέδιο.

Η γεννήτρια οργανώνει το περιεχόμενο χρησιμοποιώντας μπλοκ κειμένου, λίστες με κουκκίδες και πίνακες. Δεν δημιουργεί εικόνες· μπορείτε να τις προσθέσετε στην τελική παρουσίαση μετά. Ελέγξτε το παραγόμενο περιεχόμενο και τη διάταξη πριν μοιραστείτε την παρουσίαση.

## **Πώς Λειτουργεί**

[SlidesAIAgent](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidesaiagent/) χρησιμοποιεί έναν πελάτη AI για επικοινωνία με εξωτερικό μοντέλο. Τα παρακάτω παραδείγματα χρησιμοποιούν τον ενσωματωμένο [OpenAIWebClient](https://reference.aspose.com/slides/el/python-java/aspose.slides/openaiwebclient/). Το Aspose.Slides επεξεργάζεται τις απαντήσεις του μοντέλου και δημιουργεί μια παρουσίαση που μπορείτε να επεξεργαστείτε ή να εξάγετε.

Use [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidesaiagent/#generatePresentation) με μια περιγραφή κειμένου και μια τιμή [PresentationContentAmountType](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationcontentamounttype/). Η υπερφόρτωση με τρίτο όρισμα δέχεται μια παρουσίαση που θα χρησιμοποιηθεί ως σχεδιαστικό πρότυπο.

## **Προαπαιτούμενα**

Ακολουθήστε την [Installation](/slides/el/python-java/installation/) για να ρυθμίσετε το Python, Java, JPype και το Aspose.Slides. Ορίστε τις μεταβλητές περιβάλλοντος `OPENAI_API_KEY` και `OPENAI_MODEL` πριν εκτελέσετε τα παραδείγματα. Επιλέξτε ένα μοντέλο που υποστηρίζεται από τον ενσωματωμένο πελάτη και είναι διαθέσιμο στον λογαριασμό API σας.

{{% alert color="info" title="Note" %}}
Η υπηρεσία AI απαιτεί σύνδεση στο internet και ξεχωριστή πρόσβαση API. Οι προτροπές αποστέλλονται στην ρυθμισμένη υπηρεσία, και τα τέλη χρήσης της εφαρμόζονται ανεξάρτητα από την άδεια του Aspose.Slides σας.
{{% /alert %}}

Κάθε παράδειγμα εκκινεί τη JVM μόνο εάν δεν τρέχει ήδη και τη αφήνει διαθέσιμη για επακόλουθες λειτουργίες. Δείτε την [JVM lifecycle guidance](/slides/el/python-java/limitations-and-api-differences/#import-the-library) όταν προσαρμόζετε τον κώδικα για σημειωματάρια.

## **Δημιουργία Παρουσίας από Κείμενο**

Αυτό το παράδειγμα δημιουργεί μια παρουσίαση στα Αγγλικά με ποσότητα περιεχομένου [Medium](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationcontentamounttype/#Medium) και την αποθηκεύει ως αρχείο PowerPoint.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Δημιουργία Παρουσίας Χρησιμοποιώντας Πρότυπο**

Τοποθετήστε το `masterPresentation.pptx` στον κατάλογο εργασίας. Αυτό το παράδειγμα το φορτώνει με το [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/), δημιουργεί μια παρουσίαση στα Ισπανικά με περιεχόμενο [Detailed](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationcontentamounttype/#Detailed) και την εξάγει σε PDF. Τόσο το πρότυπο όσο και η παραγόμενη παρουσίαση απελευθερώνονται, ακόμη και αν η δημιουργία ή η αποθήκευση αποτύχουν.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

Εάν χρειάζεται να ρυθμίσετε διακομιστή μεσολάβησης ή χρονικά όρια σύνδεσης, δείτε την [Configure the HTTP Connection](/slides/el/python-java/ai/translator/#configure-the-http-connection). Μπορείτε επίσης να περάσετε τον παραγόμενο πελάτη στη γεννήτρια.

## **Βασικά Οφέλη**

Η δημιουργία μπορεί να μειώσει την αρχική εργασία σύνταξης για υλικό εκπαίδευσης, επισκόπηση προϊόντων, αναφορές πελατών και εσωτερικές παρουσιάσεις. Οι προτροπές ελέγχουν το θέμα και τη γλώσσα, ενώ ένα πρότυπο σας επιτρέπει να επαναχρησιμοποιήσετε έναν υπάρχοντα σχεδιασμό παρουσίασης.

## **Συχνές Ερωτήσεις**

**Πώς ελέγχω το μήκος της παραγόμενης παρουσίασης;**

Επιλέξτε [Brief](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationcontentamounttype/#Medium) ή [Detailed](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationcontentamounttype/#Detailed). Αυτές οι ρυθμίσεις επηρεάζουν τόσο τον αριθμό των διαφανειών όσο και την λεπτομέρεια σε κάθε διαφάνεια· δεν καθορίζουν ακριβή αριθμό διαφανειών.

**Μπορώ να δημιουργήσω διαφάνειες σε άλλη γλώσσα;**

Ναι. Συμπεριλάβετε την επιθυμητή γλώσσα στην περιγραφή κειμένου. Το αποτέλεσμα εξαρτάται από τις γλωσσικές δυνατότητες του επιλεγμένου μοντέλου.

**Μπορώ να διατηρήσω εκδοχή επεξεργάσιμη κατά την εξαγωγή σε PDF;**

Ναι. Πριν διαγράψετε την παραγόμενη παρουσίαση, αποθηκεύστε την επίσης ως PPTX χρησιμοποιώντας την προσέγγιση του πρώτου παραδείγματος.