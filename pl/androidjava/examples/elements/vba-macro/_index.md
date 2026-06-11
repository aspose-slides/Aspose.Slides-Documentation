---
title: Makro VBA
type: docs
weight: 150
url: /pl/androidjava/examples/elements/vba-macro/
keywords:
- przykład kodu
- VBA
- makro
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Automatyzuj prezentacje za pomocą Aspose.Slides for Android: twórz, uruchamiaj, importuj i zabezpieczaj makra VBA w formatach PPT, PPTX i ODP przy użyciu przejrzystych przykładów Java."
---
Ten artykuł demonstruje, jak dodać, uzyskać dostęp i usunąć makra VBA przy użyciu **Aspose.Slides for Android via Java**.

## **Dodaj makro VBA**

Utwórz prezentację z projektem VBA i prostym modułem makr.

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

## **Uzyskaj dostęp do makra VBA**

Pobierz pierwszy moduł z projektu VBA.

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

## **Usuń makro VBA**

Usuń moduł z projektu VBA.

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