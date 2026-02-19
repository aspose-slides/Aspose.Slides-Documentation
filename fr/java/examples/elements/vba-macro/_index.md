---
title: Macro VBA
type: docs
weight: 150
url: /fr/java/examples/elements/vba-macro/
keywords:
- exemple de code
- VBA
- macro
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Automatisez les présentations avec Aspose.Slides for Java : créez, exécutez, importez et sécurisez les macros VBA dans PPT, PPTX et ODP à l’aide d’exemples Java clairs."
---
Cet article montre comment ajouter, accéder et supprimer des macros VBA en utilisant **Aspose.Slides for Java**.

## **Ajouter une macro VBA**

Créez une présentation avec un projet VBA et un module de macro simple.

```java
static void addVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à une macro VBA**

Récupérez le premier module du projet VBA.

```java
static void accessVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        IVbaModule firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer une macro VBA**

Supprimez un module du projet VBA.

```java
static void removeVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.getVbaProject().getModules().remove(module);
    } finally {
        presentation.dispose();
    }
}
```