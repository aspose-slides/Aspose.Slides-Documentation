---
title: VBA макрос
type: docs
weight: 150
url: /ru/androidjava/examples/elements/vba-macro/
keywords:
- пример кода
- VBA
- макрос
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Автоматизируйте создание презентаций с помощью Aspose.Slides for Android: создавайте, запускайте, импортируйте и защищайте макросы VBA в PPT, PPTX и ODP, используя понятные примеры на Java."
---
В этой статье демонстрируется, как добавлять, получать доступ и удалять макросы VBA с использованием **Aspose.Slides for Android via Java**.

## **Добавить макрос VBA**

Создайте презентацию с проектом VBA и простым модулем макроса.

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

## **Получить доступ к макросу VBA**

Получите первый модуль из проекта VBA.

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

## **Удалить макрос VBA**

Удалите модуль из проекта VBA.

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