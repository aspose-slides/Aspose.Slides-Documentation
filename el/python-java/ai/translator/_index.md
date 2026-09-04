---
title: Μεταφραστής Παρουσίασης με Τεχνητή Νοημοσύνη
linktitle: Μεταφραστής με Τεχνητή Νοημοσύνη
type: docs
weight: 20
url: /el/python-java/ai/translator/
keywords:
- Μεταφραστής παρουσίασης με AI
- Μεταφραστής διαφάνειας με AI
- Πολυγλωσσική παρουσίαση
- Μετάφραση παρουσίασης
- Μετάφραση διαφάνειας
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Μεταφράστε παρουσιάσεις με AI χρησιμοποιώντας το Aspose.Slides for Python via Java. Τοπικοποιήστε το κείμενο των διαφανειών και αποθηκεύστε τη μεταφρασμένη παρουσίαση ως PowerPoint ή PDF."
---
## **Εισαγωγή**

Η Aspose.Slides for Python via Java παρέχει ένα API μετάφρασης παρουσίασης με τεχνητή νοημοσύνη για την τοπική προσαρμογή του περιεχομένου των διαφανειών. Μεταφράστε μια υπάρχουσα παρουσίαση σε μια συγκεκριμένη γλώσσα και, στη συνέχεια, αποθηκεύστε τη μεταφρασμένη έκδοση στη μορφή που χρειάζεται το κοινό σας.

## **Πώς λειτουργεί**

[SlidesAIAgent](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidesaiagent/) επικοινωνεί με μια εξωτερική υπηρεσία AI μέσω ενός πελάτη AI. Τα παραδείγματα χρησιμοποιούν τον ενσωματωμένο [OpenAIWebClient](https://reference.aspose.com/slides/el/python-java/aspose.slides/openaiwebclient/).

[SlidesAIAgent.translate](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidesaiagent/#translate) ενημερώνει την παρουσίαση που του παρέχεται. Η Aspose.Slides επεξεργάζεται τις αποκρίσεις AI και αντικαθιστά το κείμενο των διαφανειών διατηρώντας την υπάρχουσα διάταξη και μορφοποίηση. Εξετάστε το αποτέλεσμα: το μεταφρασμένο κείμενο μπορεί να είναι πιο μακρύ από το αρχικό και να απαιτεί προσαρμογές διάταξης.

## **Προαπαιτούμενα**

Ακολουθήστε την [Εγκατάσταση](/slides/el/python-java/installation/) για να διαμορφώσετε τη βιβλιοθήκη και το χρόνο εκτέλεσής της. Ορίστε τις μεταβλητές περιβάλλοντος `OPENAI_API_KEY` και `OPENAI_MODEL` πριν εκτελέσετε τα παραδείγματα. Επιλέξτε ένα μοντέλο που υποστηρίζεται από τον ενσωματωμένο πελάτη και είναι διαθέσιμο στον λογαριασμό API σας.

{{% alert color="info" title="Σημείωση" %}}
Η μετάφραση απαιτεί σύνδεση στο Διαδίκτυο και αποστέλλει το κείμενο της παρουσίασης στην ρυθμισμένη υπηρεσία AI. Η πρόσβαση στο API και τα κόστη χρήσης του είναι ξεχωριστά από την άδεια χρήσης της Aspose.Slides σας.
{{% /alert %}}

Τα παραδείγματα επαναχρησιμοποιούν ένα ενεργό JVM ή το ξεκινούν εάν είναι απαραίτητο. Δείτε την [Οδηγίες κύκλου ζωής JVM](/slides/el/python-java/limitations-and-api-differences/#import-the-library) για χρήση σε σημειωματάριο.

## **Μετάφραση παρουσίασης**

Τοποθετήστε το `sample.pptx` στον τρέχοντα φάκελο εργασίας. Αυτό το παράδειγμα το φορτώνει με την [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/), μεταφράζει το κείμενό του στα Ιαπωνικά και αποθηκεύει το αποτέλεσμα ως PDF. Απελευθερώνει την παρουσίαση και κλείνει τον πελάτη AI ακόμη και αν αποτύχει κάποια λειτουργία.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    presentation = Presentation("sample.pptx")
    try:
        ai_agent = SlidesAIAgent(ai_client)
        ai_agent.translate(presentation, "Japanese")
        presentation.save("sample_ja.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Διαμόρφωση της σύνδεσης HTTP**

Από προεπιλογή, η [OpenAIWebClient](https://reference.aspose.com/slides/el/python-java/aspose.slides/openaiwebclient/) διαχειρίζεται την HTTP σύνδεσή της εσωτερικά. Ο κατασκευαστής με τέσσερα ορίσματα δέχεται επίσης μια εξωτερική διαχειριζόμενη Java [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html). Χρησιμοποιήστε αυτήν την υπερφόρτωση όταν χρειάζεται να διαμορφώσετε έναν διακομιστή μεσολάβησης ή χρόνους λήξης σύνδεσης.

Το παρακάτω παράδειγμα δημιουργεί έναν διακομιστή μεσολάβησης HTTP Java με τη [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) και ανοίγει σύνδεση μέσω της [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)). Αντικαταστήστε το `proxy.example.com` και τη θύρα με τις ρυθμίσεις του διακομιστή σας. Η σύνδεση περνά απευθείας μέσω JPype· μια συνεδρία HTTP Python δεν μπορεί να χρησιμοποιηθεί στη θέση της.

```python
import os
import jpype
import jpype.imports
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.net import InetSocketAddress, Proxy, URL
from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
proxy_address = InetSocketAddress("proxy.example.com", 8080)
proxy = Proxy(Proxy.Type.HTTP, proxy_address)
endpoint = URL("https://api.openai.com/v1/chat/completions")
connection = endpoint.openConnection(proxy)
try:
    connection.setConnectTimeout(30000)
    connection.setReadTimeout(60000)
    ai_client = OpenAIWebClient(model, api_key, None, connection)
    try:
        presentation = Presentation("sample.pptx")
        try:
            ai_agent = SlidesAIAgent(ai_client)
            ai_agent.translate(presentation, "Japanese")
            presentation.save("sample_ja.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        ai_client.close()
finally:
    connection.disconnect()
```

## **Κύρια οφέλη**

Η αυτοματοποιημένη μετάφραση βοηθά στην προετοιμασία πολυγλωσσικού εκπαιδευτικού υλικού, παρουσιάσεων προϊόντων και αναφορών πελατών, ενώ επαναχρησιμοποιεί το υπάρχον σχέδιο των διαφανειών. Αποθηκεύστε μια επεξεργάσιμη παρουσίαση για περαιτέρω ανασκόπηση ή εξάγετε ένα PDF για διανομή.

## **Συχνές ερωτήσεις**

**Δημιουργεί η μετάφραση ένα ξεχωριστό αντικείμενο παρουσίασης;**

Όχι. Η [SlidesAIAgent.translate](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidesaiagent/#translate) τροποποιεί την παρεχόμενη παρουσίαση. Αποθηκεύστε την με νέο όνομα αρχείου για να διατηρήσετε το αρχικό αρχείο αμετάβλητο.

**Πώς καθορίζω τη γλώσσα-προορισμό;**

Περάστε το όνομα της γλώσσας, όπως `"Japanese"` ή `"Spanish"`, ως δεύτερο όρισμα. Η ποιότητα της μετάφρασης και η κάλυψη γλωσσών εξαρτώνται από το επιλεγμένο μοντέλο.

**Μπορώ να μεταφράσω χωρίς χρήση διακομιστή μεσολάβησης;**

Ναι. Χρησιμοποιήστε τον κατασκευαστή πελάτη με τρία ορίσματα που φαίνεται στο πρώτο παράδειγμα. Το παράδειγμα προσαρμοσμένης σύνδεσης απαιτείται μόνο όταν η εφαρμογή σας απαιτεί ρητές ρυθμίσεις σύνδεσης.