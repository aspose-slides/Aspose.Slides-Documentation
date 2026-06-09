---
title: ActiveX
type: docs
weight: 200
url: /pt/java/examples/elements/activex/
keywords:
- exemplo de código
- ActiveX
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Veja exemplos de ActiveX do Aspose.Slides for Java: inserir, configurar e controlar objetos ActiveX em apresentações PPT e PPTX com código Java claro."
---
Este artigo demonstra como adicionar, acessar, remover e configurar controles ActiveX em uma apresentação usando **Aspose.Slides for Java**.

## **Adicionar um Controle ActiveX**

Insira um novo controle ActiveX e, opcionalmente, defina suas propriedades.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Adicione um novo controle ActiveX.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Opcionalmente defina algumas propriedades.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar um Controle ActiveX**

Leia informações do primeiro controle ActiveX no slide.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Acesse o primeiro controle ActiveX.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remover um Controle ActiveX**

Exclua um controle ActiveX existente do slide.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Remova o primeiro controle ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Definir Propriedades do ActiveX**

Adicione um controle e configure várias propriedades do ActiveX.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Adicione um controle Windows Media Player e configure as propriedades.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```