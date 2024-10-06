---
title: Flash
type: docs
weight: 10
url: /androidjava/flash/
description: Extraire des objets Flash d'une présentation PowerPoint en utilisant Java
---

## **Extraire des objets Flash de la présentation**

Aspose.Slides pour Android via Java fournit une fonctionnalité pour extraire des objets flash d'une présentation. Vous pouvez accéder au contrôle flash par son nom et l'extraire de la présentation, y compris stocker les données de l'objet SWF.

```java
// Instancier la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```