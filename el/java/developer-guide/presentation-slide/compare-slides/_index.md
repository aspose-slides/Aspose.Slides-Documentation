---
title: Σύγκριση διαφανειών παρουσίασης σε Java
linktitle: Σύγκριση διαφανειών
type: docs
weight: 50
url: /el/java/compare-slides/
keywords:
- σύγκριση διαφανειών
- σύγκριση διαφανειών
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Συγκρίνετε προγραμματιστικά παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Java. Αναγνωρίστε γρήγορα τις διαφορές των διαφανειών στον κώδικα."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να συγκρίνετε διαφάνειες, διαφάνειες διάταξης και κύριες διαφάνειες χρησιμοποιώντας τη μέθοδο `equals` που παρέχεται από τη διεπαφή `IBaseSlide` και την κλάση `BaseSlide`. Αυτή η μέθοδος επιστρέφει `true` όταν οι συγκρινόμενες διαφάνειες είναι ταυτόσημες στην δομή και το στατικό περιεχόμενό τους.

## **Σύγκριση Δύο Διαφανειών**
Η μέθοδος Equals έχει προστεθεί στη διεπαφή [IBaseSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/IBaseSlide) και στην κλάση [BaseSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/BaseSlide). Επιστρέφει true για τις διαφάνειες/διάταξη και τις διαφάνειες/κύρια που είναι ταυτόσημες στη δομή και το στατικό περιεχόμενο.

Δύο διαφάνειες θεωρούνται ίσες εάν όλα τα σχήματα, τα στυλ, τα κείμενα, οι κινήσεις και άλλες ρυθμίσεις κ.λπ. είναι ίσα. Η σύγκριση δεν λαμβάνει υπόψη τις μοναδικές τιμές ταυτοτήτων, π.χ. SlideId, και το δυναμικό περιεχόμενο, π.χ. την τρέχουσα τιμή ημερομηνίας στην θέση κράτησης ημερομηνίας.

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **Συχνές ερωτήσεις**

**Επηρεάζει το γεγονός ότι μια διαφάνεια είναι κρυμμένη τη σύγκριση των ίδιων των διαφανειών;**

[Hidden status](https://reference.aspose.com/slides/el/java/com.aspose.slides/slide/#getHidden--) είναι μια ιδιότητα σε επίπεδο παρουσίασης/αναπαραγωγής, όχι οπτικό περιεχόμενο. Η ισοτιμία δύο συγκεκριμένων διαφανειών καθορίζεται από τη δομή και το στατικό περιεχόμενό τους· το απλό γεγονός ότι μια διαφάνεια είναι κρυμμένη δεν τις κάνει διαφορετικές.

**Λαμβάνονται υπόψη οι υπερσυνδέσεις και οι παράμετροι τους;**

Ναι. Οι σύνδεσμοι αποτελούν μέρος του στατικού περιεχομένου μιας διαφάνειας. Εάν το URL ή η ενέργεια του υπερσυνδέσμου διαφέρει, αυτό συνήθως θεωρείται διαφορά στο στατικό περιεχόμενο.

**Εάν ένα γράφημα αναφέρεται σε εξωτερικό αρχείο Excel, θα ληφθούν υπόψη τα περιεχόμενα αυτού του αρχείου;**

Όχι. Η σύγκριση πραγματοποιείται βάσει των ίδιων των διαφανειών. Οι εξωτερικές πηγές δεδομένων συνήθως δεν διαβάζονται κατά τη σύγκριση· λαμβάνεται υπόψη μόνο ό,τι υπάρχει στη δομή και την στατική κατάσταση της διαφάνειας.