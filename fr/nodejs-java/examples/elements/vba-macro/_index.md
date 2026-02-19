---
title: Macro VBA
type: docs
weight: 150
url: /fr/nodejs-java/examples/elements/vba-macro/
keywords:
- exemple de code
- VBA
- macro
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatisez les présentations avec Aspose.Slides for Node.js via Java: créez, importez et sécurisez les macros VBA dans les fichiers PPT, PPTX et ODP à l'aide d'exemples JavaScript clairs."
---
Cet article montre comment ajouter, accéder et supprimer des macros VBA à l'aide de **Aspose.Slides for Node.js via Java**.

## **Ajouter une macro VBA**

Créez une présentation avec un projet VBA et un module macro simple.

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

## **Accéder à une macro VBA**

Récupérez le premier module du projet VBA.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Supposons que la présentation possède au moins un module VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer une macro VBA**

Supprimez un module du projet VBA.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // En supposant que la présentation possède au moins un module VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```