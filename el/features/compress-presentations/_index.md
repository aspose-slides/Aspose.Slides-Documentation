---
title: Συμπίεση παρουσιάσεων
description: Μείωση μεγέθους παρουσίασης μέσω συμπίεσης εικόνων και αφαίρεσης αχρησιμοποίητου περιεχομένου.
type: docs
url: /el/features/compress-presentations/
weight: 250
feature_id: συμπίεση-παρουσιάσεων
feature_group: λειτουργίες
translationKey: slides-feature-συμπίεση-παρουσιάσεων
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Επισκόπηση**

Συμπιέστε τις εικόνες, αφαιρέστε τα περικομμένα τμήματα τους όταν δεν χρειάζονται πια, και επιλέξτε τις ρυθμίσεις συμπίεσης παρουσίασης πριν από την αποθήκευση. Αυτό είναι χρήσιμο για παρουσιάσεις με μεγάλες φωτογραφίες ή επαναλαμβανόμενο μέσο. Το ποσό που εξοικονομείται εξαρτάται από το περιεχόμενο και τις ρυθμίσεις που επιλέγετε.

## **Παράδειγμα χρήσης**

Αυτό το παράδειγμα C# φορτώνει το `input.pptx`, συμπιέζει την παρουσίαση και το αποθηκεύει ως `compressed.pptx`.

Χρησιμοποιήστε το Aspose.Slides για .NET 26.11 ή νεότερο. Για εγκατάσταση, δείτε [Εγκατάσταση Aspose.Slides για .NET](/slides/el/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![Ανάλογα κλιμασμένες εικόνες πριν και μετά τη συμπίεση, ακολουθούμενες από μετρημένες γραμμές μεγέθους αρχείου PPTX και διαστάσεις αποθηκευμένης εικόνας.](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*Μετρήθηκε σε μια συνθετική δοκιμαστική πλέξη λεπτομερειών: 584.030 → 128.323 bytes. Και οι δύο αποδόσεις χρησιμοποιούν την ίδια κλίμακα και πλαίσιο 252 × 336 σημεία. Η συμπίεση αφαιρεί τα περικομμένα περιθώρια και μειώνει την αποθηκευμένη εικόνα σε 525 × 700 pixels· η εξοικονόμηση μεγέθους εξαρτάται από το εισερχόμενο αρχείο.* 
<!-- visual-explanation:compress-presentations:end -->

## **Συχνές Ερωτήσεις**

### **Είναι αυτή μια ενιαία επιλογή βελτιστοποίησης ολόκληρου αρχείου;**

Το Aspose.Slides για .NET 26.11 προσθέτει το [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), το οποίο συνδυάζει την αφαίρεση αχρησιμοποίητων διατάξεων/μαστών, την υποσύνολο ενσωματωμένων γραμματοσειρών και τη συμπίεση εικόνων 150 DPI. Αφαιρεί μόνιμα τα περικομμένα τμήματα των εικόνων. Για επεξεργασία μόνο εικόνων, χρησιμοποιήστε το [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); για πιο ακριβή έλεγχο, δείτε το [παράδειγμα συμπίεσης ατομικής εικόνας](/slides/el/net/examples/optimization-batch/compression/). Από τη έκδοση 26.11, η ίδια κλήση για ολόκληρη την παρουσίαση είναι διαθέσιμη επίσης σε Java, Node.js μέσω Java, Python μέσω .NET και C++. Το παράδειγμα και οι σύνδεσμοι σε αυτή τη σελίδα αφορούν το .NET.

### **Αλλάζει η συμπίεση εικόνας το επεξεργάσιμο κείμενο ή τα διαγράμματα;**

Η συμπίεση εικόνας στοχεύει στα δεδομένα της εικόνας, όχι στο επεξεργάσιμο κείμενο ή τα δεδομένα των διαγραμμάτων. Ελέγξτε τις εικόνες επειδή η αλλαγή μεγέθους ή η επανσυμπίεση μπορεί να μειώσει τις λεπτομέρειές τους.

### **Πώς πρέπει να επιλέξω μια ανάλυση για τις εικόνες παρουσίασης;**

Επιλέξτε έναν στόχο με βάση το μέγεθος της εμφανιζόμενης εικόνας και τη σχεδιαζόμενη χρήση σε οθόνη ή εκτύπωση. Διατηρήστε μεγαλύτερη ανάλυση για μεγάλες οθόνες, εκτύπωση και λεπτομερή διαγράμματα, και συγκρίνετε το παραγόμενο αποτέλεσμα πριν απορρίψετε το αρχικό.

## **Οδηγοί**

- [Συμπίεση ολόκληρης της παρουσίασης σε .NET](/slides/el/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Βελτιστοποίηση διαχείρισης εικόνων σε παρουσιάσεις σε .NET](/slides/el/net/image/)

Related feature: [Αφαίρεση αχρησιμοποίητων μαστών, διατάξεων και μέσων](/slides/el/features/remove-unused-content/).

## Εκτελέσιμα παραδείγματα .NET

- [Μείωση μεγέθους παρουσίασης](/slides/el/net/examples/optimization-batch/compression/)