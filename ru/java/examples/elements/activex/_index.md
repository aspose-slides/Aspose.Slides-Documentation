---
title: ActiveX
type: docs
weight: 200
url: /ru/java/examples/elements/activex/
keywords:
- пример кода
- ActiveX
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Смотрите примеры ActiveX для Aspose.Slides for Java: вставка, настройка и управление объектами ActiveX в презентациях PPT и PPTX с понятным кодом Java."
---
В этой статье демонстрируется, как добавлять, получать доступ, удалять и настраивать элементы управления ActiveX в презентации с использованием **Aspose.Slides for Java**.

## **Add an ActiveX Control**
Вставьте новый элемент управления ActiveX и при желании задайте его свойства.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Добавить новый элемент управления ActiveX.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // При необходимости установить некоторые свойства.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Access an ActiveX Control**
Считайте информацию из первого элемента управления ActiveX на слайде.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Доступ к первому элементу управления ActiveX.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove an ActiveX Control**
Удалите существующий элемент управления ActiveX со слайда.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Удалить первый элемент управления ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Set ActiveX Properties**
Добавьте элемент управления и настройте несколько свойств ActiveX.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Добавить элемент управления Windows Media Player и настроить свойства.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```