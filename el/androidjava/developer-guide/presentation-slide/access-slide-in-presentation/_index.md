---
title: Πρόσβαση σε διαφάνειες παρουσίασης στο Android
linktitle: Πρόσβαση στη διαφάνεια
type: docs
weight: 20
url: /el/androidjava/access-slide-in-presentation/
keywords:
- πρόσβαση διαφάνειας
- δείκτης διαφάνειας
- ID διαφάνειας
- θέση διαφάνειας
- αλλαγή θέσης
- ιδιότητες διαφάνειας
- αριθμός διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσπελάζετε και να διαχειρίζεστε διαφάνειες σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Android. Αυξήστε την παραγωγικότητα με παραδείγματα κώδικα Java."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσπελάζετε και να διαχειρίζεστε διαφάνειες σε μια παρουσίαση χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να ανακτήσετε διαφάνειες με βάση τον μηδενικό δείκτη τους από τη συλλογή διαφανειών και πώς να προσπελάσετε μια διαφάνεια με το μοναδικό της ID χρησιμοποιώντας τη μέθοδο `getSlideById`.

Επίσης, θα μάθετε πώς να αλλάζετε τη θέση μιας διαφάνειας χρησιμοποιώντας τη μέθοδο `setSlideNumber` και πώς να ορίσετε τον αρχικό αριθμό διαφάνειας για μια παρουσίαση με τη μέθοδο `setFirstSlideNumber`. Τα παραδείγματα δείχνουν τη φόρτωση μιας παρουσίασης, την ανάκτηση αναφορών σε διαφάνειες, την ενημέρωση της σειράς ή της αρίθμησης των διαφανειών και την αποθήκευση της τροποποιημένης παρουσίασης.

## **Πρόσβαση σε διαφάνεια με δείκτη**

Όλες οι διαφάνειες σε μια παρουσίαση είναι διατεταγμένες αριθμητικά με βάση τη θέση της διαφάνειας, ξεκινώντας από το 0. Η πρώτη διαφάνεια είναι προσβάσιμη μέσω του δείκτη 0· η δεύτερη διαφάνεια μέσω του δείκτη 1· κ.λπ.

Η κλάση Presentation, που αντιπροσωπεύει ένα αρχείο παρουσίασης, εκθέτει όλες τις διαφάνειες ως μια συλλογή [ISlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecollection/) (συλλογή αντικειμένων [ISlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/)). Αυτός ο κώδικας Java δείχνει πώς να προσπελάσετε μια διαφάνεια μέσω του δείκτη της:

```java
// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("demo.pptx");
try {
    // Προσεγγίζει μια διαφάνεια χρησιμοποιώντας τον δείκτη της διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Πρόσβαση σε διαφάνεια με ID**

Κάθε διαφάνεια σε μια παρουσίαση έχει ένα μοναδικό ID. Μπορείτε να χρησιμοποιήσετε τη μέθοδο [getSlideById](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSlideById-long-) (που εκτίθεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/)) για να στοχεύσετε αυτό το ID. Αυτός ο κώδικας Java δείχνει πώς να δώσετε ένα έγκυρο ID διαφάνειας και να προσπελάσετε τη διαφάνεια μέσω της μεθόδου [getSlideById](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSlideById-long-):

```java
// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("demo.pptx");
try {
    // Λαμβάνει ένα ID διαφάνειας
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Προσπελαύνει τη διαφάνεια μέσω του ID της
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Αλλαγή θέσης διαφάνειας**

Το Aspose.Slides σας επιτρέπει να αλλάξετε τη θέση μιας διαφάνειας. Για παράδειγμα, μπορείτε να ορίσετε ώστε η πρώτη διαφάνεια γίνει η δεύτερη.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Λάβετε την αναφορά της διαφάνειας (της οποίας θέση θέλετε να αλλάξετε) μέσω του δείκτη της.
1. Ορίστε νέα θέση για τη διαφάνεια μέσω της ιδιότητας [setSlideNumber](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/#setSlideNumber-int-).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Java παρουσιάζει μια λειτουργία κατά την οποία η διαφάνεια στη θέση 1 μετακινείται στη θέση 2:

```java
// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Λαμβάνει τη διαφάνεια της οποίας η θέση θα αλλάξει
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Ορίζει τη νέα θέση για τη διαφάνεια
    sld.setSlideNumber(2);
    
    // Αποθηκεύει την τροποποιημένη παρουσίαση
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Η πρώτη διαφάνεια έγινε η δεύτερη· η δεύτερη διαφάνεια έγινε η πρώτη. Όταν αλλάζετε τη θέση μιας διαφάνειας, οι άλλες διαφάνειες ρυθμίζονται αυτόματα.

## **Ορισμός αριθμού διαφάνειας**

Χρησιμοποιώντας την ιδιότητα [setFirstSlideNumber](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (που εκτίθεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/)), μπορείτε να ορίσετε έναν νέο αριθμό για την πρώτη διαφάνεια σε μια παρουσίαση. Αυτή η λειτουργία προκαλεί τον επαναϋπολογισμό των άλλων αριθμών διαφανειών.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Λάβετε τον αριθμό της διαφάνειας.
1. Ορίστε τον αριθμό της διαφάνειας.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Java παρουσιάζει μια λειτουργία όπου ο αριθμός της πρώτης διαφάνειας ορίζεται στο 10:

```java
// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Λαμβάνει τον αριθμό της πρώτης διαφάνειας
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Ορίζει τον αριθμό της πρώτης διαφάνειας
    pres.setFirstSlideNumber(10);
	
    // Αποθηκεύει την τροποποιημένη παρουσίαση
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Αν προτιμάτε να παραλείψετε την πρώτη διαφάνεια, μπορείτε να ξεκινήσετε την αρίθμηση από τη δεύτερη διαφάνεια (και να κρύψετε την αρίθμηση για την πρώτη) ως εξής:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // Ορίζει τον αριθμό για την πρώτη διαφάνεια της παρουσίασης
    presentation.setFirstSlideNumber(0);

    // Εμφανίζει τους αριθμούς διαφανειών για όλες τις διαφάνειες
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // Κρύβει τον αριθμό διαφάνειας για την πρώτη διαφάνεια
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // Αποθηκεύει την τροποποιημένη παρουσίαση
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Συχνές ερωτήσεις**

**Ο αριθμός διαφάνειας που βλέπει ο χρήστης ταιριάζει με το μηδενικό δείκτη της συλλογής;**

Ο αριθμός που εμφανίζεται σε μια διαφάνεια μπορεί να ξεκινά από οποιαδήποτε τιμή (π.χ., 10) και δεν χρειάζεται να ταιριάζει με τον δείκτη· η σχέση ελέγχεται από τη ρύθμιση [first slide number](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) της παρουσίασης.

**Οι κρυφές διαφάνειες επηρεάζουν την αρίθμηση;**

Ναι. Μια κρυφή διαφάνεια παραμένει στη συλλογή και μετράται στην αρίθμηση· το «κρυφό» αναφέρεται μόνο στην εμφάνιση, όχι στη θέση της στη συλλογή.

**Αλλάζει ο δείκτης μιας διαφάνειας όταν προστίθενται ή αφαιρούνται άλλες διαφάνειες;**

Ναι. Οι δείκτες πάντα αντανακλούν τη τρέχουσα σειρά των διαφανειών και επαναϋπολογίζονται κατά τις λειτουργίες εισαγωγής, διαγραφής και μετακίνησης.