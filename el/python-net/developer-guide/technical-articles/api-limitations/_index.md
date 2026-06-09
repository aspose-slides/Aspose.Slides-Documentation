---
title: Περιορισμοί API
type: docs
weight: 210
url: /el/python-net/api-limitations/
keywords:
- Περιορισμοί API
- μορφή εξαγωγής
- εφαρμογή
- παραγωγός
- ιδιότητες εγγράφου
- μεταδεδομένα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Γνωρίστε τους περιορισμούς του Aspose.Slides for Python: οι εξαγωγές ορίζουν σταθερά μεταδεδομένα Application/Producer στα PPT, PPTX, ODP και PDF - σας βοηθά να σχεδιάσετε ενσωματώσεις χωρίς εκπλήξεις."
---
## **Overview**

Όταν παρουσιάσεις δημιουργούνται ή εξάγονται με Aspose.Slides, ορισμένα τεχνικά μεταδεδομένα γράφονται στο αρχείο εξόδου. Αυτό το άρθρο εξηγεί τους περιορισμούς που σχετίζονται με τα πεδία μεταδεδομένων `Application`, `Creator` και `Producer` σε αρχεία PPTX και PDF.

## **Application and Producer**

Όταν δημιουργείτε ή εξάγετε παρουσιάσεις με Aspose.Slides for Python via .NET, κάποια τεχνικά μεταδεδομένα γράφονται στο αρχείο. Δύο πεδία συχνά προκαλούν ερωτήματα:

**Application** προσδιορίζει το πρόγραμμα που δημιούργησε ή αποθήκευσε τελευταία μια παρουσίαση **PPTX**. Στο Aspose.Slides for Python via .NET, αυτή η τιμή είναι σταθερή και εμφανίζει τον προμηθευτή της βιβλιοθήκης αντί για το όνομα της εφαρμογής σας, ακόμη και αν ορίσετε [DocumentProperties.name_of_application](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/name_of_application/).

**Producer** προσδιορίζει τη μηχανή απόδοσης που δημιούργησε το τελικό αρχείο κατά την εξαγωγή. Στις εξαγωγές **PDF**, τα μεταδεδομένα χρησιμοποιούν τα πεδία **Creator** και **Producer**. Με το Aspose.Slides for Python via .NET, και τα δύο είναι σταθερά και αντικατοπτρίζουν τη βιβλιοθήκη και την έκδοσή της.

**What’s restricted**

Δεν μπορείτε να αντικαταστήσετε αυτά τα πεδία μέσω του API για τις μορφές που αναφέρονται παραπάνω. Για **PPTX**, η ιδιότητα Application γράφεται ως «Aspose.Slides for Python via .NET». Για **PDF**, οι ιδιότητες Creator και Producer γράφονται ως «Aspose.Slides for Python via .NET x.x.x». Αυτή η συμπεριφορά είναι σχεδιασμένη και ισχύει ανεξάρτητα από το πώς φορτώνετε ή αποθηκεύετε το αρχείο, καθώς και ανεξάρτητα από τις τιμές που ανατίθενται στο [DocumentProperties.name_of_application](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/name_of_application/).