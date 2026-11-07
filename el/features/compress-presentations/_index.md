---
title: Συμπίεση παρουσιάσεων
description: Μείωση του μεγέθους της παρουσίασης με συμπίεση εικόνων και αφαίρεση αχρησιμοποίητου περιεχομένου.
type: docs
url: /el/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: λειτουργίες
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Επισκόπηση**

Συμπιέστε τις εικόνες, αφαιρέστε τις κομμένες περιοχές εικόνων όταν δεν χρειάζονται πλέον, και επιλέξτε τις ρυθμίσεις συμπίεσης της παρουσίασης πριν την αποθήκευση. Αυτό είναι χρήσιμο για παρουσιάσεις με μεγάλα φωτογραφικά αρχεία ή επαναλαμβανόμενα μέσα. Το ποσό που εξοικονομείται εξαρτάται από το περιεχόμενο και τις ρυθμίσεις που επιλέγετε.

## **Παράδειγμα χρήσης**

Αυτό το παράδειγμα C# φορτώνει το `input.pptx`, συμπιέζει την παρουσίαση και το αποθηκεύει ως `compressed.pptx`.

Χρησιμοποιήστε το Aspose.Slides for .NET 26.11 ή νεότερο. Για εγκατάσταση, δείτε [Εγκατάσταση Aspose.Slides for .NET](/slides/el/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **Συχνές ερωτήσεις**

### **Είναι αυτό ένας μοναδικός διακόπτης βελτιστοποίησης ολόκληρου αρχείου;**

Το Aspose.Slides for .NET 26.11 προσθέτει το [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), το οποίο συνδυάζει την κατάργηση αχρησιμοποίητων διατάξεων/κατα κυρίαρχων, την υποομάδα ενσωματωμένων γραμματοσειρών και τη συμπίεση εικόνων 150 DPI. Αφαιρεί μόνιμα τις κομμένες περιοχές εικόνων. Για επεξεργασία μόνο εικόνων, χρησιμοποιήστε το [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); για πιο ακριβή έλεγχο, δείτε το [παράδειγμα συμπίεσης μεμονωμένης εικόνας](/slides/el/net/examples/optimization-batch/compression/). Αυτοί οι νέοι βοηθοί είναι ειδικοί για τη συγκεκριμένη έκδοση .NET· ελέγξτε τον αντίστοιχο οδηγό για άλλα SDK.

### **Η συμπίεση εικόνας αλλάζει επεξεργάσιμο κείμενο ή γραφήματα;**

Η συμπίεση εικόνας στοχεύει τα δεδομένα της εικόνας, όχι το επεξεργάσιμο κείμενο ή τα δεδομένα των διαγραμμάτων. Εξετάστε τις εικόνες, επειδή η αλλαγή μεγέθους ή η επανασυμπίεση μπορεί να μειώσει τις λεπτομέρειές τους.

### **Πώς πρέπει να επιλέξω ανάλυση για τις εικόνες παρουσίασης;**

Επιλέξτε έναν στόχο με βάση το εμφανιζόμενο μέγεθος της εικόνας και τη προοριζόμενη χρήση σε οθόνη ή εκτύπωση. Διατηρήστε μεγαλύτερη ανάλυση για μεγάλες οθόνες, εκτύπωση και λεπτομερή διαγράμματα, και συγκρίνετε το παραγόμενο αποτέλεσμα πριν απορρίψετε το αρχικό.

## **Οδηγοί**

- [Συμπίεση ολόκληρης παρουσίασης σε .NET](/slides/el/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Βελτιστοποίηση διαχείρισης εικόνων σε παρουσιάσεις σε .NET](/slides/el/net/image/)

Σχετικό χαρακτηριστικό: [Αφαίρεση αχρησιμοποίητων master, layout και μέσων](/slides/el/features/remove-unused-content/).

## Εκτελέσιμα παραδείγματα .NET

- [Μείωση μεγέθους παρουσίασης](/slides/el/net/examples/optimization-batch/compression/)