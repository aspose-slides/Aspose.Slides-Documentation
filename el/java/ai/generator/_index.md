---
title: Γεννήτρια Πολυγλωσσικών Διαφανειών με Τεχνητή Νοημοσύνη
linktitle: Γεννήτρια με Τεχνητή Νοημοσύνη
type: docs
weight: 40
url: /el/java/ai/generator/
keywords:
- πολυγλωσσική παρουσίαση
- πολυγλωσσική διαφάνεια
- γεννήτρια παρουσίασης με AI
- γεννήτρια διαφανειών με AI
- λειτουργία με AI
- πράκτορας AI
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε πολύγλωσσες διαφάνειες από κείμενο με το Aspose.Slides για Java. Εφαρμόστε το πρότυπό σας και εξάγετε επεγγελματικά σετ σε PowerPoint και OpenDocument. Μάθετε περισσότερα."
---
## **Εισαγωγή**

Το Aspose.Slides παρουσιάζει μια νέα δυνατότητα με τεχνητή νοημοσύνη, τον Γεννήτρια Παρουσιαών, η οποία επιτρέπει στους προγραμματιστές να δημιουργούν αυτόματα καλά δομημένες παρουσιάσεις PowerPoint από απλές κειμενικές εισόδους όπως περιγραφές θέματος, περιλήψεις, παραθέσεις ή κουκίδες.

Οι χρήστες μπορούν να ρυθμίσουν το επίπεδο λεπτομέρειας του περιεχομένου και προαιρετικά να εφαρμόσουν ένα προσαρμοσμένο πρότυπο παρουσίασης για να ορίσουν το οπτικό σχεδιασμό.

Προς το παρόν, η Γεννήτρια Παρουσιαστικών AI δομεί το περιεχόμενο χρησιμοποιώντας μπλοκ κειμένου, λίστες με κουκίδες και πίνακες. Η δημιουργία εικόνων δεν υποστηρίζεται ακόμη· όμως, οι εικόνες μπορούν να προστεθούν εύκολα αργότερα χρησιμοποιώντας τα εργαλεία του Aspose.Slides ή με το χέρι.

Η έξοδος είναι μια πλήρης παρουσίαση PowerPoint που μπορεί να χρησιμοποιηθεί όπως είναι ή να εξαχθεί σε οποιαδήποτε μορφή υποστηρίζεται από το API του Aspose.Slides. Ενώ η γεννήτρια παράγει αποτελέσματα υψηλής ποιότητας, μπορεί να απαιτηθεί μικρή μετα-επεξεργασία για να ικανοποιηθούν συγκεκριμένες απαιτήσεις.

## **Πώς Λειτουργεί**

Το Aspose.Slides δεν περιλαμβάνει ενσωματωμένα μοντέλα AI· αντίθετα, ενσωματώνεται με εξωτερικές υπηρεσίες AI μέσω του διαδικτύου. Αυτή η ενσωμάτωση διαχειρίζεται η κλάση [SlidesAIAgent](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidesaiagent/), η οποία χρησιμοποιεί μια υλοποίηση της διεπαφής [IAIWebClient](https://reference.aspose.com/slides/el/java/com.aspose.slides/iaiwebclient/) για να επικοινωνήσει με το μοντέλο AI.

Μπορείτε να χρησιμοποιήσετε το ενσωματωμένο [OpenAIWebClient](https://reference.aspose.com/slides/el/java/com.aspose.slides/openaiwebclient/), το οποίο συνδέεται με το API της OpenAI, ή να παρέχετε μια προσαρμοσμένη υλοποίηση της [IAIWebClient](https://reference.aspose.com/slides/el/java/com.aspose.slides/iaiwebclient/) για εργασία με άλλο πάροχο AI ή μοντέλο γλώσσας. Το Aspose.Slides διαχειρίζεται όλη την επικοινωνία με την υπηρεσία AI και επεξεργάζεται τις απαντήσεις του AI για να δημιουργήσει διαφάνειες. Σημειώστε ότι το API της OpenAI είναι υπηρεσία με χρέωση, επομένως απαιτούνται λογαριασμός και κλειδί API όταν χρησιμοποιείτε το ενσωματωμένο [OpenAIWebClient](https://reference.aspose.com/slides/el/java/com.aspose.slides/openaiwebclient/).

## **Ας Γράψουμε Κώδικα**

### **Παράδειγμα 1**

Αυτό το παράδειγμα δείχνει πώς να δημιουργήσετε μια παρουσίαση για το θέμα Aspose.Slides χρησιμοποιώντας το ενσωματωμένο [OpenAIWebClient](https://reference.aspose.com/slides/el/java/com.aspose.slides/openaiwebclient/).

```java
// Δημιουργήστε μια παρουσίαση του OpenAIWebClient, της ενσωματωμένης υλοποίησης του πελάτη ιστού OpenAI.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Δημιουργήστε μια παρουσίαση του SlidesAIAgent, που παρέχει πρόσβαση σε δυνατότητες με τεχνητή νοημοσύνη.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Ορίστε την εντολή για τη δημιουργία της παρουσίασης.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Δημιουργήστε μια παρουσίαση με μέτριο όγκο περιεχομένου βάσει της εντολής.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
        // Αποθηκεύστε την παραγόμενη παρουσίαση στο τοπικό δίσκο ως αρχείο PowerPoint (.pptx).
        presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Παράδειγμα 2**

Το παρακάτω παράδειγμα παρουσιάζει τις υπερφορτώσεις της μεθόδου [generatePresentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-). Σε αυτήν την περίπτωση χρησιμοποιείται ένα εξωτερικά διαχειριζόμενο αντικείμενο [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) και η `master presentation` του χρήστη.

Από προεπιλογή, το ενσωματωμένο [OpenAIWebClient](https://reference.aspose.com/slides/el/java/com.aspose.slides/openaiwebclient/) δημιουργεί και διαχειρίζεται το δικό του εσωτερικό αντικείμενο [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), διαχειριζόμενο αυτόματα τον κύκλο ζωής του. Ωστόσο, εάν προτιμάτε να διαχειριστείτε εσείς το [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)· για παράδειγμα, όταν χρησιμοποιείτε ένα [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ή [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) για βελτιωμένη διαχείριση πόρων και απόδοση· μπορείτε να παρέχετε το δικό σας αντικείμενο [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) κατά τη δημιουργία του [OpenAIWebClient](https://reference.aspose.com/slides/el/java/com.aspose.slides/openaiwebclient/).

```java
// Περάστε το HttpURLConnection στον κατασκευαστή OpenAIWebClient.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Δημιουργήστε ένα αντίτυπο του SlidesAIAgent.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Ορίστε την εντολή για τη δημιουργία της παρουσίασης.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Φορτώστε μία κύρια παρουσίαση από τον τοπικό δίσκο για χρήση ως πρότυπο σχεδίασης.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // Δημιουργήστε μια λεπτομερή παρουσίαση χρησιμοποιώντας την εντολή και το κύριο πρότυπο.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Αποθηκεύστε την παραγόμενη παρουσίαση ως PDF.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Κύρια Οφέλη**

Η νέα Γεννήτρια Παρουσιαστικών AI στο Aspose.Slides παρέχει έναν γρήγορο και ευέλικτο τρόπο παραγωγής δομημένων σετ διαφανειών από απλές κειμενικές εντολές. Με υποστήριξη προσαρμοσμένων προτύπων και εξωτερικά διαχειριζόμενα αντικείμενα [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), μπορεί να ενσωματωθεί ομαλά σε ένα ευρύ φάσμα εφαρμογών.

Τυπικές περιπτώσεις χρήσης περιλαμβάνουν τη δημιουργία παρουσιάσεων μάρκετινγκ, εκπαιδευτικού υλικού, αναφορών πελατών και εσωτερικών σετ διαφανειών. Αν και η δημιουργία εικόνων δεν υποστηρίζεται ακόμη, το εργαλείο ήδη προσφέρει ισχυρή βάση για αυτοματοποίηση δημιουργίας παρουσιάσεων, με περαιτέρω βελτιώσεις που αναμένεται να εμφανιστούν στο μέλλον.