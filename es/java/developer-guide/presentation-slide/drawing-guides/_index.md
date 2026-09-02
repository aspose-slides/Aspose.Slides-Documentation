---
title: Administrar guías de dibujo en presentaciones en Java
linktitle: Guías de dibujo
type: docs
weight: 85
url: /es/java/drawing-guides/
keywords:
- guía de dibujo
- guía horizontal
- guía vertical
- guía de alineación
- vista de diapositiva
- diapositiva maestra
- diapositiva de diseño
- maestro de notas
- maestro de folletos
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Añadir, acceder y borrar guías de dibujo horizontales y verticales en presentaciones de PowerPoint usando Aspose.Slides para Java."
---
## **Visión general**

Las guías de dibujo son líneas horizontales y verticales ajustables que ayudan a los usuarios a alinear formas de forma coherente mientras editan una presentación en PowerPoint. Resultan especialmente útiles cuando una aplicación genera una presentación que luego se refinará manualmente: la aplicación puede guardar los mismos auxiliares de alineación que los autores deben seguir al añadir o mover contenido.

Las guías de dibujo son auxiliares de edición, no contenido de diapositiva. No aparecen en la presentación o en la salida renderizada. Aspose.Slides for Java las expone a través de la interfaz [IDrawingGuidesCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/idrawingguidescollection/). Una guía está representada por [IDrawingGuide](https://reference.aspose.com/slides/es/java/com.aspose.slides/idrawingguide/) y tiene una orientación, una posición y un color.

La posición se mide en puntos desde la esquina superior izquierda de la diapositiva o la diapositiva maestra correspondiente. Una guía vertical utiliza una coordenada horizontal, normalmente entre cero y el ancho de la diapositiva. Una guía horizontal utiliza una coordenada vertical, normalmente entre cero y la altura de la diapositiva.

## **Añadir guías a la vista de diapositiva**

Utilice [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/es/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) para gestionar las guías mostradas mientras se editan diapositivas normales. Llame a [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/es/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) con un valor de [Orientation](https://reference.aspose.com/slides/es/java/com.aspose.slides/orientation/) y una posición en puntos.

El siguiente ejemplo añade una guía vertical a la derecha del centro de la diapositiva y una guía horizontal debajo de ella:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Acceder a las guías de dibujo**

Los métodos [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/es/java/com.aspose.slides/idrawingguidescollection/#getCount--) y [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/es/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) proporcionan acceso a las guías existentes. Los métodos [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/es/java/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/es/java/com.aspose.slides/idrawingguide/#getPosition--) y [IDrawingGuide.getColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/idrawingguide/#getColor--) devuelven valores que también pueden modificarse mediante los métodos setter correspondientes.

El siguiente ejemplo lee las guías de vista de diapositiva de la presentación creada anteriormente:

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

## **Añadir guías a diapositivas maestras y de diseño**

Una diapositiva maestra y cada una de sus diapositivas de diseño pueden tener sus propias colecciones de guías de dibujo. Utilice [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslide/#getDrawingGuides--) para una diapositiva maestra y [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--) para una diapositiva de diseño.

El siguiente ejemplo añade una guía vertical a la primera diapositiva maestra y una guía horizontal a la primera diapositiva de diseño:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Añadir guías a maestras de notas y de folletos**

Las maestras de notas y de folletos también admiten guías de dibujo. Utilice [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) y [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) para acceder a sus colecciones. Si una presentación no contiene una de estas maestras, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) o [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) crea la maestra predeterminada y la devuelve.

El siguiente ejemplo añade una guía horizontal a una maestra de notas y una guía vertical a una maestra de folletos:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Borrar guías de dibujo**

Llame a [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/es/java/com.aspose.slides/idrawingguidescollection/#clear--) para eliminar todas las guías de una colección concreta. Borrar una colección no afecta a las guías almacenadas en otro ámbito.

El siguiente ejemplo borra las guías de vista de diapositiva y todas las guías en diapositivas maestras, diapositivas de diseño, la maestra de notas y la maestra de folletos sin crear maestras faltantes:

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

## **FAQ**

**¿Aparecen las guías de dibujo en una presentación o en imágenes exportadas?**

No. Las guías de dibujo son auxiliares de alineación para la edición y no se renderizan como contenido de la presentación.

**¿Se puede añadir una guía de dibujo directamente a una diapositiva normal individual?**

Las guías de edición de diapositivas normales se almacenan en las propiedades de vista de diapositiva de la presentación. Existen colecciones de guías separadas para diapositivas maestras, diapositivas de diseño, maestras de notas y maestras de folletos.

**¿Qué unidades se utilizan para las posiciones de las guías?**

Las posiciones se especifican en puntos, donde 72 puntos equivalen a una pulgada. Las posiciones verticales se miden desde el borde izquierdo y las posiciones horizontales se miden desde el borde superior.

**¿El borrado de guías de dibujo elimina formas o cambia el contenido de la diapositiva?**

No. El método [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/es/java/com.aspose.slides/idrawingguidescollection/#clear--) elimina únicamente las guías de la colección seleccionada. Las formas y demás contenido de la diapositiva permanecen sin cambios.