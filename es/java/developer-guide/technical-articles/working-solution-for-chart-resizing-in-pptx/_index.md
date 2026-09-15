---
title: Solución funcional para el redimensionado de gráficos en PPTX
type: docs
weight: 40
url: /es/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionado de gráficos
- gráfico de Excel
- objeto OLE
- incrustar gráfico
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Soluciona el inesperado redimensionado de gráficos en PPTX al usar objetos OLE de Excel incrustados con Aspose.Slides para Java. Aprende dos métodos con código para mantener los tamaños consistentes."
---
## **Antecedentes**

Se ha observado que los gráficos de Excel incrustados como objetos OLE en una presentación de PowerPoint mediante los componentes de Aspose se redimensionan a una escala no especificada tras su primera activación. Este comportamiento provoca una diferencia visual notable en la presentación entre los estados antes y después de la activación del gráfico. El equipo de Aspose ha investigado el problema en detalle y ha encontrado una solución. Este artículo describe las causas del problema y la corrección correspondiente.

En el [artículo anterior](/slides/es/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos cómo crear un gráfico de Excel con Aspose.Cells for Java e incrustarlo en una presentación de PowerPoint mediante Aspose.Slides for Java. Para abordar el [problema de vista previa del objeto](/slides/es/java/object-preview-issue-when-adding-oleobjectframe/), asignamos la imagen del gráfico al marco del objeto OLE del gráfico. En la presentación resultante, al hacer doble clic en el marco del objeto OLE que muestra la imagen del gráfico, se activa el gráfico de Excel. Los usuarios pueden realizar los cambios deseados en el libro de Excel subyacente y luego volver a la diapositiva correspondiente haciendo clic fuera del libro activado. El tamaño del marco del objeto OLE cambia cuando el usuario vuelve a la diapositiva, y el factor de redimensionado varía según los tamaños originales tanto del marco del objeto OLE como del libro de Excel incrustado.

Existen dos escenarios posibles para crear presentaciones de PowerPoint utilizando Aspose.Slides for Java.

**Escenario 1:** Crear una presentación basada en una plantilla existente.

**Escenario 2:** Crear una presentación desde cero.

La solución que ofrecemos aquí se aplica a ambos escenarios. La base de todas las aproximaciones a la solución es la misma: **el tamaño de la ventana del objeto OLE incrustado debe coincidir con el marco del objeto OLE en la diapositiva de PowerPoint**. A continuación, analizaremos los dos enfoques para esta solución.

## **Primer enfoque**

En este enfoque, aprenderemos a establecer el tamaño de ventana del libro de Excel incrustado para que coincida con el tamaño del marco del objeto OLE en la diapositiva de PowerPoint.

**Escenario 1**

Supongamos que hemos definido una plantilla y queremos crear presentaciones basadas en ella. Asumamos que hay una forma en el índice 2 de la plantilla donde deseamos colocar un marco OLE que contenga un libro de Excel incrustado. En este escenario, el tamaño del marco del objeto OLE está predefinido: coincide con el tamaño de la forma en el índice 2 de la plantilla. Lo único que necesitamos hacer es establecer el tamaño de ventana del libro de trabajo igual al tamaño de esa forma. El siguiente fragmento de código cumple esta función:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Establece el ancho de ventana del libro de trabajo en pulgadas (dividido por 72 ya que PowerPoint usa 72 puntos por pulgada).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Establece la altura de ventana del libro de trabajo en pulgadas.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Guarda el libro de trabajo en un flujo de memoria.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crea un marco de objeto OLE con los datos de Excel incrustados.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Escenario 2**

Supongamos que queremos crear una presentación desde cero e incluir un marco de objeto OLE de cualquier tamaño con un libro de Excel incrustado. En el siguiente fragmento de código, creamos un marco de objeto OLE de 4 pulgadas de alto y 9,5 pulgadas de ancho en x = 0,5 pulgadas e y = 1 pulgada en la diapositiva. A continuación, establecemos la ventana del libro de Excel al mismo tamaño: 4 pulgadas de alto y 9,5 pulgadas de ancho.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Nuestra altura deseada.
int desiredHeight = 288; // 4 pulgadas (4 * 72)
 
// Nuestra anchura deseada.
int desiredWidth = 684; // 9,5 pulgadas (9.5 * 72)
 
// Define el tamaño del gráfico con ventana.
chart.setSizeWithWindow(true);
 
// Establece el ancho de ventana del libro de trabajo en pulgadas (dividido por 72 ya que PowerPoint usa 72 puntos por pulgada).
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// Establece la altura de ventana del libro de trabajo en pulgadas.
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// Guarda el libro de trabajo en un flujo de memoria.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crea un marco de objeto OLE con los datos de Excel incrustados.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0,5 pulgada (0.5 * 72)
    72,  // y = 1 pulgada (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Segundo enfoque**

En este enfoque, aprenderemos a establecer el tamaño del gráfico en el libro de Excel incrustado para que coincida con el tamaño del marco del objeto OLE en la diapositiva de PowerPoint. Este enfoque es útil cuando el tamaño del gráfico se conoce de antemano y nunca cambiará.

**Escenario 1**

Supongamos que hemos definido una plantilla y queremos crear presentaciones basadas en ella. Asumamos que hay una forma en el índice 2 de la plantilla donde pretendemos colocar un marco OLE que contenga un libro de Excel incrustado. En este escenario, el tamaño del marco OLE está predefinido, coincidiendo con el tamaño de la forma en el índice 2 de la plantilla. Lo único que necesitamos hacer es establecer el tamaño del gráfico en el libro de trabajo igual al tamaño de esa forma. El siguiente fragmento de código cumple esta función:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Define el tamaño del gráfico sin ventana.
chart.setSizeWithWindow(false);
 
// Establece el ancho del gráfico en píxeles (multiplica por 96 ya que Excel usa 96 píxeles por pulgada).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Establece la altura del gráfico en píxeles.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Define el tamaño de impresión del gráfico.
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// Guarda el libro de trabajo en un flujo de memoria.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crea un marco de objeto OLE con los datos de Excel incrustados.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Escenario 2**:

Supongamos que queremos crear una presentación desde cero e incluir un marco de objeto OLE de cualquier tamaño con un libro de Excel incrustado. En el siguiente fragmento de código, creamos un marco de objeto OLE con una altura de 4 pulgadas y un ancho de 9,5 pulgadas en la diapositiva en x = 0,5 pulgadas e y = 1 pulgada. También establecemos el tamaño del gráfico correspondiente a las mismas dimensiones: una altura de 4 pulgadas y un ancho de 9,5 pulgadas.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Nuestra altura deseada.
int desiredHeight = 288; // 4 pulgadas (4 * 72)
 
// Nuestro ancho deseado.
int desiredWidth = 684; // 9.5 pulgadas (9.5 * 72)
 
// Define el tamaño del gráfico sin ventana.
chart.setSizeWithWindow(false);
 
// Establece el ancho del gráfico en píxeles (dividido por 72 para obtener pulgadas, multiplicado por 96 ya que Excel usa 96 píxeles por pulgada).
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// Establece la altura del gráfico en píxeles.
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// Guarda el libro de trabajo en un flujo de memoria.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crea un marco de objeto OLE con los datos de Excel incrustados.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 pulgada (0.5 * 72)
    72,  // y = 1 pulgada (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Conclusión**

Existen dos enfoques para resolver el problema de redimensionado del gráfico. La elección del enfoque depende de los requisitos y del caso de uso. Ambos enfoques funcionan de la misma manera, tanto si las presentaciones se crean a partir de una plantilla como si se crean desde cero. Además, no hay límite para el tamaño del marco del objeto OLE en esta solución.

## **Preguntas frecuentes**

### ¿Por qué mi gráfico de Excel incrustado cambia de tamaño después de activarlo en PowerPoint?

Esto ocurre porque Excel intenta restaurar el tamaño original de la ventana al activarse por primera vez, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la proporción, lo que puede provocar el cambio de tamaño.

### ¿Es posible evitar este problema de cambio de tamaño por completo?

Sí. Al hacer coincidir el tamaño de la ventana del libro de Excel o el tamaño del gráfico con el tamaño del marco del objeto OLE antes de incrustarlo, puedes mantener los tamaños de los gráficos consistentes.

### ¿Qué enfoque debo usar, establecer el tamaño de la ventana del libro de trabajo o el tamaño del gráfico?

Utiliza **Enfoque 1 (tamaño de ventana)** si deseas mantener la proporción del libro de trabajo y, posiblemente, permitir el cambio de tamaño más adelante.  
Utiliza **Enfoque 2 (tamaño del gráfico)** si las dimensiones del gráfico son fijas y no cambiarán después de la incrustación.

### ¿Funcionarán estos métodos tanto con presentaciones basadas en plantillas como con presentaciones nuevas?

Sí. Ambos enfoques funcionan de la misma manera para presentaciones creadas a partir de plantillas o desde cero.

### ¿Existe un límite para el tamaño del marco del objeto OLE?

No. Puedes establecer el marco OLE a cualquier tamaño siempre que se escale adecuadamente al tamaño del libro de trabajo o del gráfico.

### ¿Puedo usar estos métodos con gráficos creados en otros programas de hojas de cálculo?

Los ejemplos están diseñados para gráficos de Excel creados con Aspose.Cells, pero los principios se aplican a otros programas de hojas de cálculo compatibles con OLE siempre que admitan opciones de dimensionado similares.

## **Secciones relacionadas**

- [Crear gráficos de Excel e incrustarlos como objetos OLE en presentaciones](/slides/es/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)