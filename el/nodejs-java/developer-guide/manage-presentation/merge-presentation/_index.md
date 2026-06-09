---
title: Αποτελεσματική Συγχώνευση Παρουσιάσεων σε JavaScript
linktitle: Συγχώνευση Παρουσιάσεων
type: docs
weight: 40
url: /el/nodejs-java/merge-presentation/
keywords:
- συγχώνευση PowerPoint
- συγχώνευση παρουσιάσεων
- συγχώνευση διαφανειών
- συγχώνευση PPT
- συγχώνευση PPTX
- συγχώνευση ODP
- συνδυασμός PowerPoint
- συνδυασμός παρουσιάσεων
- συνδυασμός διαφανειών
- συνδυασμός PPT
- συνδυασμός PPTX
- συνδυασμός ODP
- Node.js
- JavaScript
- Aspose.Slides
description: "Συγχωνεύστε αβίαστα παρουσιάσεις PowerPoint (PPT, PPTX) και OpenDocument (ODP) σε JavaScript με το Aspose.Slides για Node.js, βελτιώνοντας τη ροή εργασίας σας."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να συγχωνεύετε παρουσιάσεις κλωνοποιώντας διαφάνειες από μία παρουσίαση σε άλλη. Αυτό το άρθρο εξηγεί πώς να συγχωνεύετε ολόκληρες παρουσιάσεις ή επιλεγμένες διαφάνειες, να χρησιμοποιείτε έναν κύριο πρότυπο διαφάνειας ή μια συγκεκριμένη διάταξη κατά τη συγχώνευση, να διαχειρίζεστε παρουσιάσεις με διαφορετικά μεγέθη διαφανειών, και να προσθέτετε τις συγχωνευμένες διαφάνειες σε μια ενότητα παρουσίασης. Περιλαμβάνει επίσης πρακτικές σημειώσεις σχετικά με το συγχωνευμένο περιεχόμενο, όπως σημειώσεις ομιλητή, σχόλια, αρχεία πηγής με κωδικό πρόσβασης και χρήση νημάτων.

## **Συγχώνευση Παρουσιάσεων**

Όταν συγχωνεύετε μία παρουσίαση με άλλη, συνδυάζετε ουσιαστικά τις διαφάνειές τους σε μία ενιαία παρουσίαση για να παράγετε ένα αρχείο. 

{{% alert title="Πληροφορίες" color="info" %}}

Τα περισσότερα προγράμματα παρουσίασης (PowerPoint ή OpenOffice) δεν διαθέτουν λειτουργίες που επιτρέπουν στους χρήστες να συνδυάζουν παρουσιάσεις με αυτόν τον τρόπο. 

[**Aspose.Slides για Node.js μέσω Java**](https://products.aspose.com/slides/el/nodejs-java/), όμως, επιτρέπει τη συγχώνευση παρουσιάσεων με διάφορους τρόπους. Μπορείτε να συγχωνεύσετε παρουσιάσεις με όλα τα σχήματα, στυλ, κείμενα, μορφοποιήσεις, σχόλια, κινήσεις κ.λπ., χωρίς να ανησυχείτε για απώλεια ποιότητας ή δεδομένων.

**Δείτε επίσης**

[Αντιγραφή Διαφανειών](https://docs.aspose.com/slides/el/nodejs-java/clone-slides/).

{{% /alert %}}

### **Τι Μπορεί να Συγχωνευθεί**

Με το Aspose.Slides, μπορείτε να συγχωνεύσετε 

* ολόκληρες παρουσιάσεις. Όλες οι διαφάνειες από τις παρουσιάσεις καταλήγουν σε μία παρουσίαση
* συγκεκριμένες διαφάνειες. Οι επιλεγμένες διαφάνειες καταλήγουν σε μία παρουσίαση
* παρουσιάσεις σε μία μορφή (PPT σε PPT, PPTX σε PPTX, κλπ.) και σε διαφορετικές μορφές (PPT σε PPTX, PPTX σε ODP, κλπ.) μεταξύ τους. 

### **Επιλογές Συγχώνευσης**

Μπορείτε να εφαρμόσετε επιλογές που καθορίζουν αν

* κάθε διαφάνεια στην τελική παρουσίαση διατηρεί μοναδικό στυλ
* ένα συγκεκριμένο στυλ χρησιμοποιείται για όλες τις διαφάνειες στην τελική παρουσίαση. 

Για τη συγχώνευση παρουσιάσεων, το Aspose.Slides παρέχει τις μεθόδους [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) (από την κλάση [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection)). Υπάρχουν διάφορες υλοποιήσεις των μεθόδων `addClone` που ορίζουν τις παραμέτρους της διαδικασίας συγχώνευσης παρουσίασης. Κάθε αντικείμενο Presentation έχει μια συλλογή [Slides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--)· έτσι μπορείτε να καλέσετε μια μέθοδο `addClone` από την παρουσίαση στην οποία θέλετε να συγχωνεύσετε διαφάνειες.

Η μέθοδος `addClone` επιστρέφει ένα αντικείμενο `Slide`, το οποίο είναι ένα κλώνο της διαφάνειας πηγής. Οι διαφάνειες στην τελική παρουσίαση είναι απλώς αντίγραφα των διαφανειών της πηγής. Συνεπώς, μπορείτε να κάνετε αλλαγές στις προκύπτουσες διαφάνειες (π.χ., να εφαρμόσετε στυλ, επιλογές μορφοποίησης ή διατάξεις) χωρίς να επηρεαστούν οι πηγές παρουσιάσεις. 

## **Συγχώνευση Παρουσιάσεων** 

Το Aspose.Slides παρέχει τη μέθοδο [**AddClone(ISlide)**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) που επιτρέπει τον συνδυασμό διαφανειών ενώ διατηρούν τις διατάξεις και τα στυλ τους (προεπιλεγμένες παράμετροι).

Αυτός είναι ο κώδικας JavaScript που δείχνει πώς να συγχωνεύσετε παρουσιάσεις:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Συγχώνευση Παρουσιάσεων με Κύριο Πρότυπο Διαφάνειας**

Το Aspose.Slides παρέχει τη μέθοδο [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) που επιτρέπει τον συνδυασμό διαφανειών εφαρμόζοντας ένα πρότυπο κύριου διαφάνειας. Με αυτόν τον τρόπο, εάν χρειαστεί, μπορείτε να αλλάξετε το στυλ των διαφανειών στην τελική παρουσίαση.

Αυτός ο κώδικας JavaScript επιδεικνύει την περιγραφείσα λειτουργία:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

{{% alert title="Σημείωση" color="warning" %}} 

Η διάταξη της διαφάνειας για το κύριο πρότυπο καθορίζεται αυτόματα. Όταν δεν μπορεί να προσδιοριστεί κατάλληλη διάταξη, εάν η boolean παράμετρος `allowCloneMissingLayout` της μεθόδου `addClone` είναι ορισμένη σε true, χρησιμοποιείται η διάταξη της διαφάνειας πηγής. Διαφορετικά, θα πεταχθεί η εξαίρεση [PptxEditException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PptxEditException). 

{{% /alert %}}

Αν θέλετε οι διαφάνειες στην τελική παρουσίαση να έχουν διαφορετική διάταξη, χρησιμοποιήστε τη μέθοδο [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) αντί για αυτήν κατά τη συγχώνευση.

## **Συγχώνευση Συγκεκριμένων Διαφανειών από Παρουσιάσεις**

Η συγχώνευση συγκεκριμένων διαφανειών από πολλαπλές παρουσιάσεις είναι χρήσιμη για τη δημιουργία προσαρμοσμένων σετ διαφανειών. Το Aspose.Slides για Node.js μέσω Java επιτρέπει την επιλογή και εισαγωγή μόνο των διαφανειών που χρειάζεστε. Το API διατηρεί τη μορφοποίηση, τη διάταξη και το σχέδιο των αρχικών διαφανειών.

Ο παρακάτω κώδικας JavaScript δημιουργεί μια νέα παρουσίαση, προσθέτει διαφάνειες τίτλου από δύο άλλες παρουσιάσεις και αποθηκεύει το αποτέλεσμα σε αρχείο:

```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```
```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

## **Συγχώνευση Παρουσιάσεων με Διάταξη Διαφάνειας**

Αυτός ο κώδικας JavaScript δείχνει πώς να συνδυάσετε διαφάνειες από παρουσιάσεις εφαρμόζοντας τη επιθυμητή διάταξη διαφάνειας για να πάρετε μία τελική παρουσίαση:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Συγχώνευση Παρουσιάσεων με Διαφορετικά Μεγέθη Διαφανειών**

{{% alert title="Σημείωση" color="warning" %}} 

Δεν μπορείτε να συγχωνεύσετε παρουσιάσεις με διαφορετικά μεγέθη διαφανειών. 

{{% /alert %}}

Για να συγχωνεύσετε 2 παρουσιάσεις με διαφορετικά μεγέθη διαφανειών, πρέπει να αλλάξετε το μέγεθος της μίας από τις παρουσιάσεις ώστε να ταιριάζει με το μέγεθος της άλλης.

Αυτός είναι ο κώδικας δείγματος που επιδεικνύει την περιγραφείσα λειτουργία:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Συγχώνευση Διαφανειών σε Ενότητα Παρουσίασης**

Αυτός ο κώδικας JavaScript δείχνει πώς να συγχωνεύσετε μια συγκεκριμένη διαφάνεια σε μια ενότητα παρουσίασης:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

Η διαφάνεια προστίθεται στο τέλος της ενότητας. 

## **Συχνές Ερωτήσεις**

**Διατηρούνται οι σημειώσεις ομιλητή κατά τη συγχώνευση;**

Ναι. Κατά την κλωνοποίηση διαφανειών, το Aspose.Slides μεταφέρει όλα τα στοιχεία της διαφάνειας, συμπεριλαμβανομένων των σημειώσεων, της μορφοποίησης και των κινήσεων.

**Μεταφέρονται τα σχόλια και οι συγγραφείς τους;**

Τα σχόλια, ως μέρος του περιεχομένου της διαφάνειας, αντιγράφονται με τη διαφάνεια. Οι ετικέτες συγγραφέα σχολίου διατηρούνται ως αντικείμενα σχολίων στην προκύπτουσα παρουσίαση.

**Τι γίνεται αν η πηγή παρουσίασης είναι προστατευμένη με κωδικό;**

Πρέπει να ανοιχτεί με τον κωδικό [από εδώ](/slides/el/nodejs-java/password-protected-presentation/) μέσω της μεθόδου [LoadOptions.setPassword](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/setpassword/). Μετά τη φόρτωση, οι διαφάνειες μπορούν να κλωνοποιηθούν με ασφάλεια σε ένα μη προστατευμένο αρχείο προορισμού (ή και σε προστατευμένο).

**Πόσο ασφαλής είναι η λειτουργία συγχώνευσης ως προς τα νήματα;**

Μην χρησιμοποιείτε το ίδιο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) από [πολλά νήματα](/slides/el/nodejs-java/multithreading/). Ο κανόνας είναι «ένα έγγραφο — ένα νήμα»· διαφορετικά αρχεία μπορούν να επεξεργαστούν παράλληλα σε ξεχωριστά νήματα.

## **Δείτε επίσης**

Το Aspose προσφέρει ένα [ΔΩΡΕΑΝ Online Collage Maker](https://products.aspose.app/slides/el/collage). Χρησιμοποιώντας αυτήν την online υπηρεσία, μπορείτε να συγχωνεύσετε [JPG σε JPG](https://products.aspose.app/slides/el/collage/jpg) ή PNG σε PNG εικόνες, να δημιουργήσετε [πλέγμα φωτογραφιών](https://products.aspose.app/slides/el/collage/photo-grid) και άλλα.

Δοκιμάστε το [ΔΩΡΕΑΝ Online Merger του Aspose](https://products.aspose.app/slides/el/merger). Σας επιτρέπει να συγχωνεύσετε παρουσιάσεις PowerPoint στην ίδια μορφή (π.χ., PPT σε PPT, PPTX σε PPTX) ή μεταξύ διαφορετικών μορφών (π.χ., PPT σε PPTX, PPTX σε ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/el/merger)