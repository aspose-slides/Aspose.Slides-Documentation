---
title: VBA-Makro
type: docs
weight: 150
url: /de/nodejs-java/examples/elements/vba-macro/
keywords:
- Codebeispiel
- VBA
- Makro
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatisieren Sie Präsentationen mit Aspose.Slides für Node.js via Java: Erstellen, importieren und sichern Sie VBA-Makros in PPT, PPTX und ODP mithilfe klarer JavaScript-Beispiele."
---
Dieser Artikel zeigt, wie VBA‑Makros mit **Aspose.Slides for Node.js via Java** hinzugefügt, zugegriffen und entfernt werden.

## **VBA-Makro hinzufügen**

Erstellen Sie eine Präsentation mit einem VBA‑Projekt und einem einfachen Makromodul.

```js
function addVbaMacro() {
    let presentation = new aspose.slides.Presentation();
    try {
        presentation.setVbaProject(new aspose.slides.VbaProject());

        let module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.save("vba_macro.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Zugriff auf ein VBA-Makro**

Rufen Sie das erste Modul aus dem VBA‑Projekt ab.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Es wird angenommen, dass die Präsentation mindestens ein VBA-Modul enthält.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **VBA-Makro entfernen**

Löschen Sie ein Modul aus dem VBA‑Projekt.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Es wird angenommen, dass die Präsentation mindestens ein VBA-Modul enthält.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```