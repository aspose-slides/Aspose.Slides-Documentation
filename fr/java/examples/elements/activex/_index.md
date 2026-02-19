---
title: ActiveX
type: docs
weight: 200
url: /fr/java/examples/elements/activex/
keywords:
- exemple de code
- ActiveX
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Voir les exemples ActiveX d'Aspose.Slides pour Java : insérer, configurer et contrôler des objets ActiveX dans les présentations PPT et PPTX avec un code Java clair."
---
Cet article démontre comment ajouter, accéder, supprimer et configurer des contrôles ActiveX dans une présentation en utilisant **Aspose.Slides for Java**.

## **Ajouter un contrôle ActiveX**

Insérez un nouveau contrôle ActiveX et, éventuellement, définissez ses propriétés.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Ajouter un nouveau contrôle ActiveX.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Optionnellement définir certaines propriétés.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à un contrôle ActiveX**

Lisez les informations du premier contrôle ActiveX de la diapositive.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Accéder au premier contrôle ActiveX.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer un contrôle ActiveX**

Supprimez un contrôle ActiveX existant de la diapositive.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Supprimer le premier contrôle ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Définir les propriétés ActiveX**

Ajoutez un contrôle et configurez plusieurs propriétés ActiveX.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Ajouter un contrôle Windows Media Player et configurer les propriétés.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```