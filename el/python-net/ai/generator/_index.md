---
title: Διαγεννήτρια Πολυγλωσσικών Διαφανειών με Τεχνητή Νοημοσύνη
linktitle: Διαγεννήτρια AI
type: docs
weight: 40
url: /el/python-net/ai/generator/
keywords:
- πολυγλωσσική παρουσίαση
- πολυγλωσσική διαφάνεια
- γεννήτρια παρουσίασης AI
- γεννήτρια διαφανειών AI
- λειτουργία με AI
- πράκτορας AI
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε πολυγλωσσικές διαφάνειες από κείμενο με το Aspose.Slides για Python. Εφαρμόστε το πρότυπό σας και εξάγετε επαγγελματικά decks σε PowerPoint και OpenDocument. Μάθετε περισσότερα."
---
## **Εισαγωγή**

Το Aspose.Slides παρουσιάζει μια νέα λειτουργία με τεχνητή νοημοσύνη, το Presentation Generator, η οποία επιτρέπει στους προγραμματιστές να δημιουργούν αυτόματα καλά δομημένες παρουσιάσεις PowerPoint από απλές εισροές κειμένου όπως περιγραφές θεμάτων, συνοψίσεις, αποσπάσματα ή κουκίδες.

Οι χρήστες μπορούν να ρυθμίσουν το επίπεδο λεπτομέρειας του περιεχομένου και προαιρετικά να εφαρμόσουν ένα προσαρμοσμένο πρότυπο παρουσίασης για να ορίσουν το οπτικό σχεδιασμό.

Προς το παρόν, ο AI Presentation Generator δομίζει το περιεχόμενο χρησιμοποιώντας μπλοκ κειμένου, λίστες με κουκίδες και πίνακες. Η δημιουργία εικόνων δεν υποστηρίζεται ακόμη· ωστόσο, οι εικόνες μπορούν να προστεθούν εύκολα μετά από αυτό χρησιμοποιώντας εργαλεία του Aspose.Slides ή χειροκίνητα.

Το αποτέλεσμα είναι μια πλήρης παρουσίαση PowerPoint που μπορεί να χρησιμοποιηθεί όπως είναι ή να εξαχθεί σε οποιαδήποτε μορφή υποστηρίζεται από το API του Aspose.Slides. Αν και ο δημιουργός παράγει αποτελέσματα υψηλής ποιότητας, ενδέχεται να απαιτηθεί μικρή μετα‑επεξεργασία για να καλυφθούν συγκεκριμένες απαιτήσεις.

## **Πώς Λειτουργεί**

Το Aspose.Slides δεν περιλαμβάνει ενσωματωμένα μοντέλα AI· αντίθετα, ενσωματώνεται με εξωτερικές υπηρεσίες AI μέσω του διαδικτύου. Αυτή η ενσωμάτωση διαχειρίζεται η κλάση [SlidesAIAgent](https://reference.aspose.com/slides/el/python-net/aspose.slides.ai/slidesaiagent/), η οποία χρησιμοποιεί μια υλοποίηση της κλάσης [IAIWebClient](https://reference.aspose.com/slides/el/python-net/aspose.slides.ai/iaiwebclient/) για επικοινωνία με το μοντέλο AI.

Μπορείτε να χρησιμοποιήσετε την ενσωματωμένη [OpenAIWebClient](https://reference.aspose.com/slides/el/python-net/aspose.slides.ai/openaiwebclient/), η οποία συνδέεται με το API της OpenAI, ή να παρέχετε μια προσαρμοσμένη υλοποίηση της [IAIWebClient](https://reference.aspose.com/slides/el/python-net/aspose.slides.ai/iaiwebclient/) για συνεργασία με άλλο πάροχο AI ή μοντέλο γλώσσας. Το Aspose.Slides διαχειρίζεται όλη την επικοινωνία με την υπηρεσία AI και επεξεργάζεται τις απαντήσεις του AI για τη δημιουργία διαφανειών. Σημειώστε ότι το API της OpenAI είναι υπηρεσία επί πληρωμή, επομένως απαιτείται λογαριασμός και κλειδί API όταν χρησιμοποιείτε την ενσωματωμένη [OpenAIWebClient](https://reference.aspose.com/slides/el/python-net/aspose.slides.ai/openaiwebclient/).

## **Ας Γράψουμε Κώδικα**

### **Παράδειγμα 1**

Αυτό το παράδειγμα επιδεικνύει πώς να δημιουργήσετε μια παρουσίαση για το θέμα Aspose.Slides χρησιμοποιώντας την ενσωματωμένη [OpenAIWebClient](https://reference.aspose.com/slides/el/python-net/aspose.slides.ai/openaiwebclient/).

```py
# Δημιουργήστε ένα αντικείμενο OpenAIWebClient, την ενσωματωμένη υλοποίηση του πελάτη ιστού OpenAI.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

    # Δημιουργήστε ένα αντικείμενο SlidesAIAgent, το οποίο παρέχει πρόσβαση σε λειτουργίες με τεχνητή νοημοσύνη.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Ορίστε την εντολή για τη δημιουργία της παρουσίασης.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Δημιουργήστε μια παρουσίαση με μέτριο όγκο περιεχομένου βάσει της εντολής.
    with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.MEDIUM) as presentation:

        # Αποθηκεύστε την παραγόμενη παρουσίαση στον τοπικό δίσκο ως αρχείο PowerPoint (.pptx).
        presentation.save("Aspose.Slides.NET.pptx", slides.export.SaveFormat.PPTX)
```

### **Παράδειγμα 2**

Το παρακάτω παράδειγμα δείχνει τις υπερφορτώσεις της μεθόδου [generate_presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides.ai/slidesaiagent/generate_presentation/#str-asposeslidesaipresentationcontentamounttype-asposeslidesipresentation). Σε αυτήν την περίπτωση, χρησιμοποιείται η `master presentation` του χρήστη.

```py
# Περνάτε το HttpClient στον κατασκευαστή του OpenAIWebClient.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId") as ai_web_client:

    # Δημιουργήστε ένα αντικείμενο SlidesAIAgent.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Ορίστε την εντολή για τη δημιουργία της παρουσίασης.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Φορτώστε μια κύρια παρουσίαση από τον τοπικό δίσκο για χρήση ως πρότυπο σχεδίασης.
    with slides.Presentation("masterPresentation.pptx") as masterPresentation:

        # Δημιουργήστε μια λεπτομερή παρουσίαση χρησιμοποιώντας την εντολή και το κύριο πρότυπο.
        with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.DETAILED, masterPresentation) as presentation:

            # Αποθηκεύστε την παραγόμενη παρουσίαση ως PDF.
            presentation.save("Aspose.Slides.NET.pdf", slides.export.SaveFormat.PDF)
```

## **Κύρια Οφέλη**

Ο νέος AI Presentation Generator στο Aspose.Slides παρέχει έναν γρήγορο και ευέλικτο τρόπο παραγωγής δομημένων σετ διαφανειών από απλές προτροπές κειμένου. Με υποστήριξη προσαρμοσμένων προτύπων, μπορεί να ενσωματωθεί άψογα σε μια ευρεία γκάμα εφαρμογών.

Τυπικές περιπτώσεις χρήσης περιλαμβάνουν τη δημιουργία παρουσιάσεων μάρκετινγκ, εκπαιδευτικό υλικό, αναφορές πελατών και εσωτερικά σετ διαφανειών. Παρόλο που η δημιουργία εικόνων δεν υποστηρίζεται ακόμη, το εργαλείο ήδη προσφέρει μια ισχυρή βάση για την αυτοματοποίηση της δημιουργίας παρουσιάσεων, με περαιτέρω βελτιώσεις να αναμένονται στο μέλλον.