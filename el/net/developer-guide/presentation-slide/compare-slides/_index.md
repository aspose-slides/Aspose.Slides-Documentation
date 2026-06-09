---
title: Σύγκριση διαφανειών παρουσίασης σε .NET
linktitle: Σύγκριση διαφανειών
type: docs
weight: 50
url: /el/net/compare-slides/
keywords:
- σύγκριση διαφανειών
- σύγκριση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Συγκρίνετε προγραμματικά παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για .NET. Εντοπίστε τις διαφορές των διαφανειών στον κώδικα γρήγορα."
---
## **Overview**

Το Aspose.Slides σας επιτρέπει να συγκρίνετε διαφάνειες, διαφάνειες διάταξης και κύριες διαφάνειες χρησιμοποιώντας τη μέθοδο `Equals` που παρέχεται από τη διεπαφή `IBaseSlide` και την κλάση `BaseSlide`. Αυτή η μέθοδος επιστρέφει `true` όταν οι συγκρινόμενες διαφάνειες είναι πανομοιότυπες στη δομή τους και στο στατικό τους περιεχόμενο.

## **Compare Two Slides**

Η μέθοδος Equals προστέθηκε στη διεπαφή [IBaseSlide](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseslide) και στην κλάση [BaseSlide](https://reference.aspose.com/slides/el/net/aspose.slides/baseslide). Επιστρέφει true για τις διαφάνειες διάταξης και τις κύριες διαφάνειες που είναι πανομοιότυπες ως προς τη δομή και το στατικό περιεχόμενο.

Δύο διαφάνειες θεωρούνται ίσες εάν όλα τα σχήματα, τα στυλ, τα κείμενα, η κίνηση και άλλες ρυθμίσεις κ.λπ. είναι ίδια. Η σύγκριση δεν λαμβάνει υπόψη τις μοναδικές τιμές ταυτοτήτων, π.χ. SlideId, ούτε το δυναμικό περιεχόμενο, όπως η τρέχουσα τιμή ημερομηνίας σε Placeholder ημερομηνίας.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```

## **FAQ**

**Does the fact that a slide is hidden affect the comparison of the slides themselves?**

Η [Hidden status](https://reference.aspose.com/slides/el/net/aspose.slides/slide/hidden/) είναι ιδιότητα επιπέδου παρουσίασης/αναπαραγωγής, όχι οπτικού περιεχομένου. Η ισότητα δύο συγκεκριμένων διαφανειών καθορίζεται από τη δομή και το στατικό τους περιεχόμενο· το απλό γεγονός ότι μια διαφάνεια είναι κρυφή δεν καθιστά τις διαφάνειες διαφορετικές.

**Are hyperlinks and their parameters taken into account?**

Ναι. Οι σύνδεσμοι αποτελούν μέρος του στατικού περιεχομένου μιας διαφάνειας. Εάν το URL ή η δράση του υπερσυνδέσμου διαφέρει, αυτό συνήθως θεωρείται διαφορά στο στατικό περιεχόμενο.

**If a chart refers to an external Excel file, will the contents of that file be taken into account?**

Όχι. Η σύγκριση πραγματοποιείται βάσει των ίδιων των διαφανειών. Οι εξωτερικές πηγές δεδομένων συνήθως δεν διαβάζονται κατά τη σύγκριση· λαμβάνεται υπόψη μόνο ό,τι υπάρχει στη δομή και την στατική κατάσταση της διαφάνειας.