---
title: "Σύγκριση διαφανειών παρουσίασης σε JavaScript"
linktitle: "Σύγκριση διαφανειών"
type: docs
weight: 50
url: /el/nodejs-java/compare-slides/
keywords:
- σύγκριση διαφανειών
- σύγκριση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Συγκρίνετε παρουσιάσεις PowerPoint και OpenDocument προγραμματιστικά με το Aspose.Slides για Node.js μέσω Java. Αναγνωρίστε γρήγορα τις διαφορές διαφανειών στον κώδικα."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να συγκρίνετε διαφάνειες, διαφάνειες διάταξης και κύριες διαφάνειες χρησιμοποιώντας τη μέθοδο `equals` που παρέχεται από την κλάση `BaseSlide`. Αυτή η μέθοδος επιστρέφει `true` όταν οι συγκρινόμενες διαφάνειες είναι ταυτόσημες στη δομή τους και το στατικό περιεχόμενό τους.

## **Σύγκριση Δύο Διαφανειών**

Η μέθοδος Equals έχει προστεθεί στην κλάση [BaseSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/BaseSlide) και στην κλάση [BaseSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/BaseSlide). Επιστρέφει true για τις διαφάνειες/διάταξη και τις διαφάνειες/κύριες που είναι ταυτόσημες στη δομή και το στατικό περιεχόμενο. 

Δύο διαφάνειες είναι ίσες εάν όλα τα σχήματα, τα στυλ, τα κείμενα, οι κινούμενες εικόνες και άλλες ρυθμίσεις κ.λπ. είναι ίσα. Η σύγκριση δεν λαμβάνει υπόψη τις μοναδικές τιμές αναγνωριστικών, π.χ. SlideId, καθώς και το δυναμικό περιεχόμενο, π.χ. την τρέχουσα τιμή ημερομηνίας σε θέση κράτησης ημερομηνίας.

```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Η πραγματικότητα ότι μια διαφάνεια είναι κρυφή επηρεάζει τη σύγκριση των διαφανειών καθαυτών;**

[Hidden status](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/gethidden/) είναι ιδιότητα σε επίπεδο παρουσίασης/αναπαραγωγής, όχι οπτικό περιεχόμενο. Η ισότητα δύο συγκεκριμένων διαφανειών καθορίζεται από τη δομή και το στατικό τους περιεχόμενο· το γεγονός μόνο ότι μια διαφάνεια είναι κρυφή δεν τις κάνει διαφορετικές.

**Λαμβάνονται υπόψη οι υπερσυνδέσεις και οι παράμετροί τους;**

Ναι. Οι σύνδεσμοι αποτελούν μέρος του στατικού περιεχομένου μιας διαφάνειας. Εάν η διεύθυνση URL ή η δράση του υπερσυνδέσμου διαφέρει, αυτό θεωρείται συνήθως διαφορά στο στατικό περιεχόμενο.

**Εάν ένα γράφημα αναφέρεται σε εξωτερικό αρχείο Excel, θα ληφθεί υπόψη το περιεχόμενό του;**

Όχι. Η σύγκριση πραγματοποιείται με βάση τις ίδιες τις διαφάνειες. Οι εξωτερικές πηγές δεδομένων συνήθως δεν διαβάζονται κατά τη σύγκριση· λαμβάνονται υπόψη μόνο όσα υπάρχουν στη δομή και την κατάσταση της διαφάνειας.