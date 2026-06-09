---
title: Σύγκριση διαφανειών παρουσίασης στο Android
linktitle: Σύγκριση διαφανειών
type: docs
weight: 50
url: /el/androidjava/compare-slides/
keywords:
- σύγκριση διαφανειών
- σύγκριση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Συγκρίνετε παρουσιάσεις PowerPoint και OpenDocument προγραμματιστικά με το Aspose.Slides για Android. Εντοπίστε γρήγορα τις διαφορές των διαφανειών στον κώδικα Java."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να συγκρίνετε διαφάνειες, διαφάνειες διάταξης και κύριες διαφάνειες χρησιμοποιώντας τη μέθοδο `equals` που παρέχεται από τη διεπαφή `IBaseSlide` και την κλάση `BaseSlide`. Αυτή η μέθοδος επιστρέφει `true` όταν οι συγκρινόμενες διαφάνειες είναι πανομοιότυπες στη δομή και το στατικό περιεχόμενό τους.

## **Σύγκριση Δύο Διαφανειών**
Η μέθοδος Equals έχει προστεθεί στη διεπαφή [IBaseSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IBaseSlide) και στην κλάση [BaseSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/BaseSlide). Επιστρέφει true για τις διαφάνειες διάταξης και τις κύριες διαφάνειες που είναι πανομοιότυπες ως προς τη δομή και το στατικό περιεχόμενό τους.

Δύο διαφάνειες είναι ίσες εάν όλα τα σχήματα, τα στυλ, τα κείμενα, οι κινήσεις και άλλες ρυθμίσεις κ.λπ. είναι ίσα. Η σύγκριση δεν λαμβάνει υπόψη τις τιμές μοναδικών αναγνωριστικών, π.χ. SlideId, καθώς και το δυναμικό περιεχόμενο, π.χ. την τρέχουσα τιμή ημερομηνίας στον Θέση Ημερομηνίας.

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

## **ΣΥΝΑΝΤΑΤΑ**

**Επηρεάζει το γεγονός ότι μια διαφάνεια είναι κρυφή τη σύγκριση των ίδιων των διαφανειών;**

[Hidden status](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slide/#getHidden--) είναι ιδιότητα επιπέδου παρουσίασης/αναπαραγωγής, όχι οπτικού περιεχομένου. Η ισότητα δύο συγκεκριμένων διαφανειών προσδιορίζεται από τη δομή και το στατικό τους περιεχόμενο· το απλό γεγονός ότι μια διαφάνεια είναι κρυφή δεν κάνει τις διαφάνειες διαφορετικές.

**Λαμβάνονται υπόψη οι υπερσυνδέσμους και οι παράμετροί τους;**

Ναι. Οι σύνδεσμοι αποτελούν μέρος του στατικού περιεχομένου μιας διαφάνειας. Εάν η διεύθυνση URL ή η λειτουργία του υπερσυνδέσμου διαφέρει, αυτό συνήθως θεωρείται διαφορά στο στατικό περιεχόμενο.

**Εάν ένα γράφημα αναφέρεται σε εξωτερικό αρχείο Excel, θα ληφθούν υπόψη τα περιεχόμενα αυτού του αρχείου;**

Όχι. Η σύγκριση πραγματοποιείται βάσει των ίδιων των διαφανειών. Οι εξωτερικές πηγές δεδομένων συνήθως δεν διαβάζονται κατά τη σύγκριση· λαμβάνεται υπόψη μόνο αυτό που υπάρχει στη δομή και την στατική κατάσταση της διαφάνειας.