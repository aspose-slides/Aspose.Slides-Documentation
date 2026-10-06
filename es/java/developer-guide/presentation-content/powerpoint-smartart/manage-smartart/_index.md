---
title: Gestionar SmartArt en presentaciones de PowerPoint usando Java
linktitle: Gestionar SmartArt
type: docs
weight: 10
url: /es/java/manage-smartart/
keywords:
- SmartArt
- texto de SmartArt
- tipo de disposición
- propiedad oculta
- organigrama
- organigrama con imagen
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprende a crear y editar SmartArt de PowerPoint con Aspose.Slides para Java usando ejemplos de código claros que aceleran el diseño y la automatización de diapositivas."
---
## **Visión general**

SmartArt es un diagrama de PowerPoint formado por nodos, formas de nodo y una disposición. Con Aspose.Slides for Java, puedes crear SmartArt, leer texto de sus nodos, cambiar su disposición, inspeccionar nodos ocultos, configurar disposiciones de organigramas y crear organigramas con imágenes.

## **Obtener texto de un objeto SmartArt**

Un nodo de SmartArt puede contener una o más formas. Para leer el texto de las formas del nodo, itera a través de [ISmartArt.getAllNodes](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#getAllNodes--), luego lee el [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) devuelto por [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartshape/#getTextFrame--).

El ejemplo requiere una presentación con al menos una diapositiva y un objeto SmartArt como la primera forma en esa diapositiva. Imprime cada marco de texto disponible en la consola.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Cambiar el tipo de disposición de un objeto SmartArt**

La disposición de SmartArt controla cómo se organizan y conectan los nodos. El siguiente ejemplo crea un objeto SmartArt con el valor `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) , lo cambia al valor `BasicProcess` y guarda la presentación. La posición y el tamaño pasados a [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) se miden en puntos. Usa [ISmartArt.setLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setLayout-int-) para cambiar la disposición.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comprobar si un nodo SmartArt está oculto**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) indica si el nodo está oculto en el modelo de datos de SmartArt. Los nodos ocultos pueden existir en la estructura incluso cuando la disposición seleccionada no los muestra como elementos visibles del diagrama.

El siguiente ejemplo añade un nodo a un objeto SmartArt que utiliza el valor `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) . Comprueba el estado oculto del nodo añadido. Imprime un mensaje si el nodo está oculto y guarda el diagrama.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obtener o establecer la disposición del organigrama**

Para los diagramas SmartArt que utilizan una disposición de organigrama, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) y [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) definen cómo se organizan los nodos hijo bajo un nodo padre. Por ejemplo, puedes establecer que los nodos hijo cuelguen a la izquierda, derecha o ambos lados, según el [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) seleccionado.

El siguiente ejemplo crea un organigrama y establece la disposición del primer nodo al valor `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) . El índice basado en cero `0` selecciona el primer nodo de nivel superior; sus nodos hijo utilizan la disposición seleccionada. La presentación modificada se guarda entonces.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Crear un organigrama con imagen**

Un organigrama con imagen es una disposición de SmartArt diseñada para diagramas jerárquicos que incluyen marcadores de posición de imagen. Usa el valor `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) al añadir el objeto SmartArt a una diapositiva. Este ejemplo guarda un diagrama con marcadores de posición de imagen; no rellena los marcadores con imágenes.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Convertir diagramas heredados a grupos de formas**

Al modernizar una presentación existente, puede que necesites actualizar un organigrama creado originalmente en PowerPoint 97–2003. Aspose.Slides representa estos diagramas heredados como objetos [ILegacyDiagram](https://reference.aspose.com/slides/java/com.aspose.slides/ilegacydiagram/) . Usa [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/#convertToGroupShape--) para convertir un diagrama en un grupo de formas, de modo que puedas editar elementos visuales individuales. Consulta la [LegacyDiagram API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/) para más detalles.

La conversión añade un nuevo grupo a la colección de formas sin eliminar el diagrama original. Tras una conversión exitosa, elimina el original con [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) para evitar contenido duplicado. Recopila los diagramas heredados en una lista antes de convertirlos, de modo que añadir y eliminar formas no interrumpa la iteración.

El siguiente ejemplo abre una presentación, busca en cada diapositiva, convierte los diagramas en grupos de formas y guarda la presentación actualizada como PPTX.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La presentación guardada contiene grupos de formas editables en lugar de los diagramas heredados convertidos, sin diagramas originales restantes junto a ellos. Abre el PPTX en PowerPoint para editar los elementos individuales dentro de cada grupo, como su texto, relleno o posición.

## **Preguntas frecuentes**

**¿SmartArt admite la reflexión o inversión para idiomas RTL?**  
Sí. El método [ISmartArt.setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setReversed-boolean-) cambia la dirección del diagrama de izquierda a derecha a derecha a izquierda, o viceversa, cuando la disposición de SmartArt seleccionada admite la inversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación preservando el formato?**  
Puedes [clonar la forma SmartArt](/slides/es/java/shape-manipulations/) con [ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) o [clonar la diapositiva completa](/slides/es/java/clone-slides/) que contiene el SmartArt. Ambos enfoques conservan el tamaño, la posición y el formato.

**¿Cómo renderizo SmartArt a una imagen rasterizada para vista previa o exportación web?**  
[Renderiza la diapositiva](/slides/es/java/convert-powerpoint-to-png/) o toda la presentación a PNG o JPEG. SmartArt se renderiza como parte de la diapositiva.

**¿Cómo puedo encontrar un objeto SmartArt específico en una diapositiva si hay varios?**  
Utiliza [Shape.setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) o [Shape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setName-java.lang.String-) para asignar un texto alternativo o un nombre distintivo a la forma SmartArt, busca ese valor en [BaseSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) , y luego verifica que la forma coincidente sea un [ISmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/).