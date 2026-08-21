---
title: Gestionar guías de dibujo en presentaciones en Android
linktitle: Guías de dibujo
type: docs
weight: 85
url: /es/androidjava/drawing-guides/
keywords:
- guía de dibujo
- guía horizontal
- guía vertical
- guía de alineación
- vista de diapositiva
- diapositiva maestra
- diapositiva de diseño
- maestro de notas
- maestro de folleto
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Agregar, acceder y eliminar guías de dibujo horizontales y verticales en presentaciones de PowerPoint usando Aspose.Slides para Android a través de Java."
---
## **Descripción general**

Las guías de dibujo son líneas horizontales y verticales ajustables que ayudan a los usuarios a alinear formas de manera coherente mientras editan una presentación en PowerPoint. Son especialmente útiles cuando una aplicación genera una presentación que posteriormente será afinada manualmente: la aplicación puede guardar los mismos auxiliares de alineación que los autores deben seguir al añadir o mover contenido.

Las guías de dibujo son ayudas de edición, no contenido de diapositiva. No aparecen en una presentación o salida renderizada. Aspose.Slides for Android a través de Java las expone mediante la interfaz [IDrawingGuidesCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idrawingguidescollection/). Una guía está representada por [IDrawingGuide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idrawingguide/) y tiene una orientación, una posición y un color.

La posición se mide en puntos desde la esquina superior izquierda de la diapositiva o maestro correspondiente. Una guía vertical utiliza una coordenada horizontal, normalmente entre cero y el ancho de la diapositiva. Una guía horizontal utiliza una coordenada vertical, normalmente entre cero y la altura de la diapositiva.

## **Agregar guías a la vista de diapositiva**

Utilice [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) para gestionar las guías mostradas mientras se editan diapositivas normales. Llame a [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) con un valor de [Orientation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/orientation/) y una posición en puntos.

El siguiente ejemplo agrega una guía vertical a la derecha del centro de la diapositiva y una guía horizontal debajo de ella:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Acceder a las guías de dibujo**

Los métodos [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) y [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) proporcionan acceso a las guías existentes. Los métodos [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idrawingguide/#getPosition--), y [IDrawingGuide.getColor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idrawingguide/#getColor--) devuelven valores que también pueden modificarse mediante los métodos setter correspondientes.

El siguiente ejemplo lee las guías de la vista de diapositiva de la presentación creada arriba:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Agregar guías a diapositivas maestras y de diseño**

Una diapositiva maestra y cada una de sus diapositivas de diseño pueden tener sus propias colecciones de guías de dibujo. Utilice [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) para una diapositiva maestra y [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) para una diapositiva de diseño.

El siguiente ejemplo agrega una guía vertical a la primera diapositiva maestra y una guía horizontal a la primera diapositiva de diseño:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Agregar guías a maestros de notas y de folleto**

Los maestros de notas y los maestros de folleto también admiten guías de dibujo. Utilice [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) y [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) para acceder a sus colecciones. Si una presentación no contiene uno de estos maestros, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) o [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) crea el maestro predeterminado y lo devuelve.

El siguiente ejemplo agrega una guía horizontal a un maestro de notas y una guía vertical a un maestro de folleto:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eliminar guías de dibujo**

Llame a [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) para eliminar todas las guías de una colección concreta. Vaciar una colección no afecta a las guías almacenadas en otro ámbito.

El siguiente ejemplo elimina las guías de la vista de diapositiva y todas las guías en los maestros de diapositiva, diapositivas de diseño, el maestro de notas y el maestro de folleto sin crear maestros ausentes:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Aparecen las guías de dibujo en una presentación o en imágenes exportadas?**

No. Las guías de dibujo son ayudas de alineación para la edición y no se renderizan como contenido de la presentación.

**¿Se puede añadir una guía de dibujo directamente a una diapositiva normal individual?**

Las guías de edición de diapositivas normales se almacenan en las propiedades de vista de diapositiva de la presentación. Existen colecciones de guías separadas para los maestros de diapositiva, diapositivas de diseño, maestros de notas y maestros de folleto.

**¿Qué unidades se utilizan para las posiciones de las guías?**

Las posiciones se especifican en puntos, donde 72 puntos equivalen a una pulgada. Las posiciones verticales se miden desde el borde izquierdo y las horizontales desde el borde superior.

**¿El borrado de las guías de dibujo elimina formas o modifica el contenido de la diapositiva?**

No. El método [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) elimina solo las guías de la colección seleccionada. Las formas y demás contenido de la diapositiva permanecen sin cambios.