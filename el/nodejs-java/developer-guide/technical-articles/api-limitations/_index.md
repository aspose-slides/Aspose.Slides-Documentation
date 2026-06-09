---
title: Περιορισμοί API
type: docs
weight: 320
url: /el/nodejs-java/api-limitations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε τους περιορισμούς του Aspose.Slides for Node.js: οι εξαγωγές ορίζουν σταθερά μεταδεδομένα Application/Producer σε PPT, PPTX, ODP και PDF—σας βοηθά να προγραμματίσετε ενσωματώσεις χωρίς εκπλήξεις."
---
## **Επισκόπηση**

Όταν δημιουργούνται ή εξάγονται παρουσιάσεις με Aspose.Slides, ορισμένα τεχνικά μεταδεδομένα γράφονται στο αρχείο εξόδου. Αυτό το άρθρο εξηγεί τους περιορισμούς που αφορούν τα πεδία μεταδεδομένων `Application`, `Creator` και `Producer` σε αρχεία PPTX και PDF.

## **Εφαρμογή και Παραγωγός**

Όταν δημιουργείτε ή εξάγετε παρουσιάσεις με Aspose.Slides for Node.js via Java, ορισμένα τεχνικά μεταδεδομένα γράφονται στο αρχείο. Δύο πεδία συχνά προκαλούν ερωτήσεις:

**Application** προσδιορίζει το πρόγραμμα που δημιούργησε ή αποθήκευσε τελευταία μια παρουσίαση **PPTX**. Στο Aspose.Slides for Node.js via Java, αυτή η τιμή είναι σταθερή και εμφανίζει τον προμηθευτή της βιβλιοθήκης αντί για το όνομα της εφαρμογής σας, ακόμη και αν χρησιμοποιείτε [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** προσδιορίζει τη μηχανή απόδοσης που δημιούργησε το τελικό αρχείο κατά την εξαγωγή. Στις εξαγωγές **PDF**, τα μεταδεδομένα χρησιμοποιούν τα πεδία **Creator** και **Producer**. Με το Aspose.Slides for Node.js via Java, και τα δύο είναι σταθερά και αντανακλούν τη βιβλιοθήκη και την έκδοσή της.

**Τι περιορίζεται**

Δεν μπορείτε να αντικαταστήσετε αυτά τα πεδία μέσω του API για τις παραπάνω μορφές. Για **PPTX**, η ιδιότητα Application γράφεται ως «Aspose.Slides for Node.js via Java». Για **PDF**, οι ιδιότητες Creator και Producer γράφονται ως «Aspose.Slides for Node.js via Java x.x.x». Αυτή η συμπεριφορά είναι σχεδιασμένη και ισχύει ανεξάρτητα από το πώς φορτώνετε ή αποθηκεύετε το αρχείο, και ανεξάρτητα από τις τιμές που έχουν οριστεί χρησιμοποιώντας [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).