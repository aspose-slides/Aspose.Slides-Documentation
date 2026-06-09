---
title: Ενότητα
type: docs
weight: 90
url: /el/java/examples/elements/section/
keywords:
- παράδειγμα κώδικα
- ενότητα
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Διαχειριστείτε τις ενότητες διαφανειών στο Aspose.Slides for Java: δημιουργήστε, μετονομάστε, αναδιατάξτε και ομαδοποιήστε διαφάνειες με παραδείγματα Java για PPT, PPTX και ODP."
---
Παραδείγματα διαχείρισης ενοτήτων παρουσίασης—προσθήκη, πρόσβαση, διαγραφή και μετονομασία τους προγραμματιστικά χρησιμοποιώντας **Aspose.Slides for Java**.

## **Προσθήκη Ενότητας**

Δημιουργήστε μια ενότητα που αρχίζει σε μια συγκεκριμένη διαφάνεια.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Καθορίστε τη διαφάνεια που σηματοδοτεί την έναρξη της ενότητας.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε Ενότητα**

Αναγνώστε πληροφορίες ενότητας από μια παρουσίαση.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Πρόσβαση σε ενότητα με δείκτη.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Διαγραφή Ενότητας**

Διαγράψτε μια προηγουμένως προστιθέμενη ενότητα.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // Αφαιρέστε την πρώτη ενότητα.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Μετονομασία Ενότητας**

Αλλάξτε το όνομα μιας υπάρχουσας ενότητας.

```java
static void renameSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("Old Name", slide);

        ISection section = presentation.getSections().get_Item(0);
        section.setName("New Name");
    } finally {
        presentation.dispose();
    }
}
```