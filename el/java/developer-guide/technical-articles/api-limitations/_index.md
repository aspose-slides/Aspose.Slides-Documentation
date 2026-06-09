---
title: "Περιορισμοί API"
type: docs
weight: 320
url: /el/java/api-limitations/
keywords:
- "Περιορισμοί API"
- "μορφή εξαγωγής"
- "εφαρμογή"
- "παραγωγός"
- "ιδιότητες εγγράφου"
- "μεταδεδομένα"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "Java"
- "Aspose.Slides"
description: "Μάθετε τους περιορισμούς του Aspose.Slides for Java: οι εξαγωγές ορίζουν σταθερά μεταδεδομένα Application/Producer σε PPT, PPTX, ODP και PDF—σας βοηθούν να προγραμματίζετε ενσωματώσεις χωρίς εκπλήξεις."
---
## **Επισκόπηση**

Όταν παρουσιάσεις δημιουργούνται ή εξάγονται με το Aspose.Slides, ορισμένα τεχνικά μεταδεδομένα εγγράφονται στο αρχείο εξόδου. Αυτό το άρθρο εξηγεί τους περιορισμούς που σχετίζονται με τα πεδία μεταδεδομένων `Application`, `Creator` και `Producer` σε αρχεία PPTX και PDF.

## **Application και Producer**

Όταν δημιουργείτε ή εξάγετε παρουσιάσεις με το Aspose.Slides for Java, ορισμένα τεχνικά μεταδεδομένα εγγράφονται στο αρχείο. Δύο πεδία συχνά εγείρουν ερωτήσεις:

**Application** προσδιορίζει το πρόγραμμα που δημιούργησε ή αποθήκευσε τελευταία μια παρουσίαση **PPTX**. Στο Aspose.Slides for Java, αυτή η τιμή είναι σταθερή και εμφανίζει τον προμηθευτή της βιβλιοθήκης αντί για το όνομα της εφαρμογής σας, ακόμη και αν χρησιμοποιήσετε [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/el/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** προσδιορίζει τη μηχανή απόδοσης που δημιούργησε το τελικό αρχείο κατά την εξαγωγή. Στις εξαγωγές **PDF**, τα μεταδεδομένα χρησιμοποιούν τα πεδία **Creator** και **Producer**. Με το Aspose.Slides for Java, και τα δύο είναι σταθερά και αντικατοπτρίζουν τη βιβλιοθήκη και την έκδοσή της.

**Τι είναι περιορισμένο**

Δεν μπορείτε να αντικαταστήσετε αυτά τα πεδία μέσω του API για τις παραπάνω μορφές. Για **PPTX**, η ιδιότητα Application γράφεται ως «Aspose.Slides for Java». Για **PDF**, οι ιδιότητες Creator και Producer γράφονται ως «Aspose.Slides for Java x.x.x». Αυτή η συμπεριφορά είναι σχεδιασμένη έτσι και ισχύει ανεξάρτητα από το πώς φορτώνετε ή αποθηκεύετε το αρχείο, καθώς και ανεξάρτητα από τις τιμές που έχουν οριστεί χρησιμοποιώντας [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/el/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).