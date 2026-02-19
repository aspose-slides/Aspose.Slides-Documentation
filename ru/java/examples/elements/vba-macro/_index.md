---
title: VBA макрос
type: docs
weight: 150
url: /ru/java/examples/elements/vba-macro/
keywords:
- пример кода
- VBA
- макрос
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Автоматизируйте презентации с помощью Aspose.Slides for Java: создавайте, запускайте, импортируйте и защищайте VBA‑макросы в PPT, PPTX и ODP, используя понятные примеры на Java."
---
Эта статья демонстрирует, как добавлять, получать доступ и удалять VBA‑макросы с помощью **Aspose.Slides for Java**.

## **Добавление VBA‑макроса**
Создайте презентацию с VBA‑проектом и простым модулем макроса.

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

## **Доступ к VBA‑макросу**
Получите первый модуль из VBA‑проекта.

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

## **Удалить VBA‑макрос**
Удалите модуль из VBA‑проекта.

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