---
title: Γεννήτρια Πολυγλωσσικών Διαφανειών με Τεχνητή Νοημοσύνη
linktitle: Γεννήτρια με Τεχνητή Νοημοσύνη
type: docs
weight: 40
url: /el/nodejs-java/ai/generator/
keywords:
- πολυγλωσσική παρουσίαση
- πολυγλωσσική διαφάνεια
- γεννήτρια παρουσίασης με Τεχνητή Νοημοσύνη
- γεννήτρια διαφανειών με Τεχνητή Νοημοσύνη
- λειτουργία με τεχνητή νοημοσύνη
- πράκτορας Τεχνητής Νοημοσύνης
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε πολυγλωσσικές διαφάνειες από κείμενο με το Aspose.Slides για Node.js. Εφαρμόστε το πρότυπό σας και εξαγάγετε επεγερές παρουσιάσεις σε PowerPoint και OpenDocument. Μάθετε περισσότερα."
---
## **Εισαγωγή**

Το Aspose.Slides παρουσιάζει μια νέα λειτουργία με τεχνητή νοημοσύνη, τον Presentation Generator, η οποία επιτρέπει στους προγραμματιστές να δημιουργούν αυτόματα καλά δομημένες παρουσιάσεις PowerPoint από απλές κειμενικές εισόδους όπως περιγραφές θέματος, συνοπτικές περιλήψεις, παραπομπές ή κουκίδες.

Οι χρήστες μπορούν να ρυθμίσουν το επίπεδο λεπτομέρειας του περιεχομένου και προαιρετικά να εφαρμόσουν ένα προσαρμοσμένο πρότυπο παρουσίασης για να ορίσουν το οπτικό σχεδιασμό.

Προς το παρόν, ο AI Presentation Generator οργανώνει το περιεχόμενο χρησιμοποιώντας μπλοκ κειμένου, λίστες με κουκίδες και πίνακες. Η δημιουργία εικόνων δεν υποστηρίζεται ακόμη· ωστόσο, οι εικόνες μπορούν να προστεθούν εύκολα μετά, χρησιμοποιώντας τα εργαλεία του Aspose.Slides ή χειροκίνητα.

Το αποτέλεσμα είναι μια πλήρης παρουσίαση PowerPoint που μπορεί να χρησιμοποιηθεί όπως είναι ή να εξαχθεί σε οποιαδήποτε μορφή υποστηρίζεται από το API του Aspose.Slides. Αν και ο γεννήτρια παράγει αποτελέσματα υψηλής ποιότητας, μπορεί να χρειαστεί μικρή μετα-επεξεργασία για να ικανοποιηθούν συγκεκριμένες απαιτήσεις.

## **Πώς λειτουργεί**

Το Aspose.Slides δεν περιλαμβάνει ενσωματωμένα μοντέλα AI· αντίθετα, ενσωματώνεται με εξωτερικές υπηρεσίες AI μέσω του διαδικτύου. Αυτή η ενσωμάτωση διαχειρίζεται η κλάση [SlidesAIAgent](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidesaiagent/) .

Μπορείτε να χρησιμοποιήσετε τον ενσωματωμένο [OpenAIWebClient](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/openaiwebclient/), ο οποίος συνδέεται με το API του OpenAI. Το Aspose.Slides διαχειρίζεται όλη την επικοινωνία με την υπηρεσία AI και επεξεργάζεται τις απαντήσεις του AI για τη δημιουργία διαφανειών. Σημειώστε ότι το API του OpenAI είναι υπηρεσία επί πληρωμή, έτσι απαιτούνται λογαριασμός και κλειδί API όταν χρησιμοποιείτε τον ενσωματωμένο [OpenAIWebClient](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/openaiwebclient/) .

## **Ας κωδικοποιήσουμε**

### **Παράδειγμα 1**

Αυτό το παράδειγμα δείχνει πώς να δημιουργήσετε μια παρουσίαση για το θέμα Aspose.Slides χρησιμοποιώντας τον ενσωματωμένο [OpenAIWebClient](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/openaiwebclient/) .

```js
// Δημιουργήστε μια παρουσία του OpenAIWebClient, την ενσωματωμένη υλοποίηση του πελάτη web του OpenAI.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Δημιουργήστε μια παρουσία του SlidesAIAgent, που παρέχει πρόσβαση σε λειτουργίες με τεχνητή νοημοσύνη.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Ορίστε την οδηγία για τη δημιουργία της παρουσίασης.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Δημιουργήστε μια παρουσίαση με μέτρια ποσότητα περιεχομένου βάσει της οδηγίας.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Medium);
    try {
        // Αποθηκεύστε την παραγόμενη παρουσίαση στον τοπικό δίσκο ως αρχείο PowerPoint (.pptx).
        presentation.save("Aspose.Slides.NET.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Παράδειγμα 2**

Το παρακάτω παράδειγμα δείχνει τις υπερφορτώσεις της μεθόδου [generatePresentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidesaiagent/#generatePresentation). Σε αυτήν την περίπτωση, χρησιμοποιείται ένα εξωτερικά διαχειριζόμενο αντικείμενο [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) και η «master presentation» του χρήστη.

Από προεπιλογή, ο ενσωματωμένος [OpenAIWebClient](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/openaiwebclient/) δημιουργεί και διαχειρίζεται το δικό του εσωτερικό αντικείμενο [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), διαχειριζόμενο αυτόματα τον κύκλο ζωής του. Ωστόσο, εάν προτιμάτε να διαχειριστείτε εσείς το [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)· για παράδειγμα, όταν χρησιμοποιείτε ένα [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ή [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) για βελτιωμένη διαχείριση πόρων και απόδοσης· μπορείτε να παρέχετε το δικό σας αντικείμενο [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) κατά την κατασκευή του [OpenAIWebClient](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/openaiwebclient/) .

```js
// Περάστε το HttpURLConnection στον κατασκευαστή OpenAIWebClient.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Δημιουργήστε μια παρουσία του SlidesAIAgent.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Ορίστε την οδηγία για τη δημιουργία της παρουσίασης.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Φορτώστε μια κύρια παρουσίαση από τον τοπικό δίσκο για να τη χρησιμοποιήσετε ως πρότυπο σχεδίου.
    var masterPresentation = new aspose.slides.Presentation("masterPresentation.pptx");

    // Δημιουργήστε μια λεπτομερή παρουσίαση χρησιμοποιώντας την οδηγία και το κύριο πρότυπο.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Αποθηκεύστε την παραγόμενη παρουσίαση ως PDF.
        presentation.save("Aspose.Slides.NET.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Βασικά Οφέλη**

Ο νέος AI Presentation Generator στο Aspose.Slides προσφέρει έναν γρήγορο και ευέλικτο τρόπο παραγωγής δομημένων σετ διαφανειών από απλές κειμενικές προτροπές. Με υποστήριξη προσαρμοσμένων προτύπων και εξωτερικά διαχειριζόμενων αντικειμένων [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), μπορεί να ενσωματωθεί αβίαστα σε ένα ευρύ φάσμα εφαρμογών.

Τυπικές περιπτώσεις χρήσης περιλαμβάνουν τη δημιουργία παρουσιάσεων μάρκετινγκ, εκπαιδευτικού υλικού, αναφορών πελατών και εσωτερικών σετ διαφανειών. Αν και η δημιουργία εικόνων δεν υποστηρίζεται ακόμη, το εργαλείο προσφέρει ήδη μια ισχυρή βάση για αυτοματοποίηση της δημιουργίας παρουσιάσεων, με περαιτέρω βελτιώσεις να αναμένονται στο μέλλον.