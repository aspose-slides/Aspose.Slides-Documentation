---
title: Ενότητα
type: docs
weight: 90
url: /el/nodejs-java/examples/elements/section/
keywords:
- παράδειγμα κώδικα
- ενότητα
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε τις ενοότητες διαφανειών στο Aspose.Slides για Node.js μέσω Java: δημιουργήστε, μετονομάστε, ξαναταξινομήστε και ομαδοποιήστε διαφάνειες με παραδείγματα JavaScript για PPT, PPTX και ODP."
---
Παραδείγματα διαχείρισης ενοτήτων παρουσίασης—προσθήκη, πρόσβαση, διαγραφή και μετονομασία τους προγραμματιστικά χρησιμοποιώντας **Aspose.Slides for Node.js via Java**.

## **Προσθήκη ενότητας**

Δημιουργήστε μια ενότητα που αρχίζει σε συγκεκριμένη διαφάνεια.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Καθορίστε τη διαφάνεια που σηματοδοτεί την αρχή της ενότητας.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε ενότητα**

Διαβάστε τις πληροφορίες της ενότητας από μια παρουσίαση.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Πρόσβαση σε ενότητα με δείκτη.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση ενότητας**

Διαγράψτε μια προηγουμένως προστιθέμενη ενότητα.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Αφαιρέστε την πρώτη ενότητα.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Μετονομασία ενότητας**

Αλλάξτε το όνομα μιας υπάρχουσας ενότητας.

```js
function renameSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let section = presentation.getSections().get_Item(0);
        section.setName("New Name");

        presentation.save("section_renamed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```