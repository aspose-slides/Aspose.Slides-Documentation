---
title: Diapositiva maestra
type: docs
weight: 30
url: /es/php-java/examples/elements/master-slide/
keywords:
- diapositiva maestra
- añadir diapositiva maestra
- acceder a diapositiva maestra
- eliminar diapositiva maestra
- diapositiva maestra sin usar
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Gestiona diapositivas maestras en PHP con Aspose.Slides: crea, edita, clona y formatea temas, fondos y marcadores de posición para unificar diapositivas en PowerPoint y OpenDocument."
---
Las diapositivas maestras forman el nivel superior de la jerarquía de herencia de diapositivas en PowerPoint. Una **diapositiva maestra** define elementos de diseño comunes, como fondos, logotipos y formato de texto. **Las diapositivas de diseño** heredan de las diapositivas maestras, y **las diapositivas normales** heredan de las diapositivas de diseño.

Este artículo muestra cómo crear, modificar y gestionar diapositivas maestras usando Aspose.Slides para PHP a través de Java.

## **Añadir una diapositiva maestra**

Este ejemplo muestra cómo crear una nueva diapositiva maestra clonando la predeterminada.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // Clona la diapositiva maestra predeterminada.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Consejo 1:** Las diapositivas maestras permiten aplicar una marca o elementos de diseño compartidos de forma coherente en todas las diapositivas. Cualquier cambio realizado en la maestra se reflejará automáticamente en las diapositivas de diseño y normales dependientes.

> 💡 **Consejo 2:** Cualquier forma o formato añadido a una diapositiva maestra se hereda en las diapositivas de diseño y, a su vez, en todas las diapositivas normales que utilizan esos diseños.
> La imagen a continuación ilustra cómo un cuadro de texto añadido en una diapositiva maestra se renderiza automáticamente en la diapositiva final.

![Ejemplo de herencia de diapositiva maestra](master-slide-banner.png)

## **Acceder a una diapositiva maestra**

Puede acceder a las diapositivas maestras mediante el método `Presentation::getMasters`. A continuación se muestra cómo recuperarlas y trabajar con ellas:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Acceder a la primera diapositiva maestra.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Eliminar una diapositiva maestra**

Las diapositivas maestras pueden eliminarse tanto por índice como por referencia.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Eliminar por índice.
        $presentation->getMasters()->removeAt(0);

        // O eliminar por referencia.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Eliminar diapositivas maestras no utilizadas**

Algunas presentaciones contienen diapositivas maestras que no están en uso. Eliminar estas diapositivas puede ayudar a reducir el tamaño del archivo.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Eliminar todas las diapositivas maestras no usadas (incluso las marcadas como Preserve).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **Consejo:** Utilice `removeUnused(true)` para limpiar las diapositivas maestras no utilizadas y minimizar el tamaño de la presentación.