---
title: Solución funcional para el redimensionamiento de gráficos en PPTX
type: docs
weight: 40
url: /es/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionamiento de gráficos
- gráfico de Excel
- objeto OLE
- incrustar gráfico
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Soluciona el redimensionamiento inesperado de gráficos en PPTX al utilizar objetos OLE de Excel incrustados con Aspose.Slides para Java. Aprende dos métodos con código para mantener los tamaños consistentes."
---

## **Antecedentes**

Se ha observado que los gráficos de Excel incrustados como objetos OLE en una presentación de PowerPoint mediante los componentes de Aspose se redimensionan a una escala no especificada después de su primera activación. Este comportamiento provoca una diferencia visual notable en la presentación entre los estados antes y después de la activación del gráfico. El equipo de Aspose investigó el problema en detalle y encontró una solución. Este artículo describe las causas del problema y la corrección correspondiente.

En el [artículo anterior](/slides/es/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos cómo crear un gráfico de Excel con Aspose.Cells for Java e incrustarlo en una presentación de PowerPoint usando Aspose.Slides for Java. Para abordar el [problema de vista previa del objeto](/slides/es/java/object-preview-issue-when-adding-oleobjectframe/), asignamos la imagen del gráfico al marco del objeto OLE del gráfico. En la presentación resultante, cuando haces doble clic en el marco del objeto OLE que muestra la imagen del gráfico, se activa el gráfico de Excel. Los usuarios finales pueden realizar cualquier cambio deseado en el libro de Excel subyacente y luego volver a la diapositiva correspondiente haciendo clic fuera del libro activado. El tamaño del marco del objeto OLE cambia cuando el usuario vuelve a la diapositiva, y el factor de redimensionamiento varía según los tamaños originales tanto del marco del objeto OLE como del libro de Excel incrustado.

## **Causa del redimensionamiento**

Debido a que el libro de Excel tiene su propio tamaño de ventana, intenta conservar su tamaño original en su primera activación. Sin embargo, el marco del objeto OLE tiene su propio tamaño. Según Microsoft, cuando se activa el libro de Excel, Excel y PowerPoint negocian el tamaño y mantienen las proporciones correctas como parte del proceso de incrustación. Según las diferencias entre el tamaño de la ventana de Excel y el tamaño o posición del marco del objeto OLE, se produce el redimensionamiento.

## **Solución funcional**

Existen dos escenarios posibles para crear presentaciones de PowerPoint usando Aspose.Slides for Java.

**Scenario 1:** Crear una presentación basada en una plantilla existente.

**Scenario 2:** Crear una presentación desde cero.

La solución que proporcionamos aquí se aplica a ambos escenarios. La base de todos los enfoques de solución es la misma: **el tamaño de ventana del objeto OLE incrustado debe coincidir con el marco del objeto OLE en la diapositiva de PowerPoint**. Ahora discutiremos los dos enfoques de esta solución.

## **Primer enfoque**

En este enfoque, aprenderemos cómo establecer el tamaño de ventana del libro de Excel incrustado para que coincida con el tamaño del marco del objeto OLE en la diapositiva de PowerPoint.

**Scenario 1**

Supongamos que hemos definido una plantilla y queremos crear presentaciones basadas en ella. Asumamos que hay una forma en el índice 2 de la plantilla donde queremos colocar un marco OLE que contiene un libro de Excel incrustado. En este escenario, el tamaño del marco del objeto OLE está predefinido - coincide con el tamaño de la forma en el índice 2 de la plantilla. Todo lo que necesitamos hacer es establecer el tamaño de ventana del libro igual al tamaño de esa forma. El siguiente fragmento de código sirve para este propósito:
```java
// Establecer el ancho de ventana del libro de trabajo en pulgadas (dividido por 576 ya que PowerPoint usa 576 píxeles por pulgada).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Establecer la altura de ventana del libro de trabajo en pulgadas.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Guardar el libro de trabajo en un flujo de memoria.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crear un marco de objeto OLE con los datos de Excel incrustados.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


**Scenario 2**

Supongamos que queremos crear una presentación desde cero e incluir un marco de objeto OLE de cualquier tamaño con un libro de Excel incrustado. En el siguiente fragmento de código, creamos un marco de objeto OLE de 4 pulgadas de alto y 9.5 pulgadas de ancho en x = 0.5 pulgadas y y = 1 pulgada en la diapositiva. Luego establecemos la ventana del libro de Excel al mismo tamaño - 4 pulgadas de alto y 9.5 pulgadas de ancho.
```java
// Nuestra altura deseada.
int desiredHeight = 288; // 4 pulgadas (4 * 72)
 
// Nuestro ancho deseado.
int desiredWidth = 684; // 9.5 pulgadas (9.5 * 72)
 
// Definir el tamaño del gráfico con una ventana.
chart.setSizeWithWindow(true);
 
// Establecer el ancho de ventana del libro de trabajo en pulgadas (dividido por 576 ya que PowerPoint usa 576 píxeles por pulgada).
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// Establecer la altura de ventana del libro de trabajo en pulgadas.
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// Guardar el libro de trabajo en un flujo de memoria.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crear un marco de objeto OLE con los datos de Excel incrustados.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


## **Segundo enfoque**

En este enfoque, aprenderemos cómo establecer el tamaño del gráfico en el libro de Excel incrustado para que coincida con el tamaño del marco del objeto OLE en la diapositiva de PowerPoint. Este enfoque es útil cuando el tamaño del gráfico se conoce de antemano y nunca cambiará.

**Scenario 1**

Supongamos que hemos definido una plantilla y queremos crear presentaciones basadas en ella. Asumamos que hay una forma en el índice 2 de la plantilla donde pretendemos colocar un marco OLE que contiene un libro de Excel incrustado. En este escenario, el tamaño del marco OLE está predefinido - coincide con el tamaño de la forma en el índice 2 de la plantilla. Todo lo que necesitamos hacer es establecer el tamaño del gráfico en el libro igual al tamaño de esa forma. El siguiente fragmento de código sirve para este propósito:
```java
// Definir el tamaño del gráfico sin ventana.
chart.setSizeWithWindow(false);
 
// Establecer el ancho del gráfico en píxeles (multiplicar por 96 ya que Excel usa 96 píxeles por pulgada).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Establecer la altura del gráfico en píxeles.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Definir el tamaño de impresión del gráfico.
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// Guardar el libro de trabajo en un flujo de memoria.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crear un marco de objeto OLE con los datos de Excel incrustados.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


**Scenario 2**:

Supongamos que queremos crear una presentación desde cero e incluir un marco de objeto OLE de cualquier tamaño con un libro de Excel incrustado. En el siguiente fragmento de código, creamos un marco de objeto OLE con una altura de 4 pulgadas y un ancho de 9.5 pulgadas en la diapositiva en x = 0.5 pulgadas y y = 1 pulgada. También establecemos el tamaño del gráfico correspondiente a las mismas dimensiones: una altura de 4 pulgadas y un ancho de 9.5 pulgadas.
```java
// Nuestra altura deseada.
int desiredHeight = 288; // 4 pulgadas (4 * 72)
 
// Nuestro ancho deseado.
int desiredWidth = 684; // 9.5 pulgadas (9.5 * 72)
 
// Definir el tamaño del gráfico sin ventana.
chart.setSizeWithWindow(false);
 
// Establecer el ancho del gráfico en píxeles (multiplicar por 96 ya que Excel usa 96 píxeles por pulgada).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// Establecer la altura del gráfico en píxeles.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// Guardar el libro de trabajo en un flujo de memoria.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crear un marco de objeto OLE con los datos de Excel incrustados.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


## **Conclusión**

Existen dos enfoques para solucionar el problema de redimensionamiento del gráfico. La elección del enfoque depende de los requisitos y del caso de uso. Ambos enfoques funcionan de la misma manera, ya sea que las presentaciones se creen a partir de una plantilla o desde cero. Además, no hay límite al tamaño del marco del objeto OLE en esta solución.

## **Preguntas frecuentes**

**¿Por qué mi gráfico de Excel incrustado cambia de tamaño después de activarlo en PowerPoint?**

Esto ocurre porque Excel intenta restaurar el tamaño original de la ventana al activarse por primera vez, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la relación de aspecto, lo que puede provocar el redimensionamiento.

**¿Es posible evitar este problema de redimensionamiento por completo?**

Sí. Al hacer coincidir el tamaño de la ventana del libro de Excel o el tamaño del gráfico con el tamaño del marco del objeto OLE antes de incrustarlo, puedes mantener los tamaños de los gráficos consistentes.

**¿Qué enfoque debo usar, establecer el tamaño de la ventana del libro o el tamaño del gráfico?**

Utiliza **Enfoque 1 (tamaño de ventana)** si deseas mantener la relación de aspecto del libro y posiblemente permitir redimensionamiento más adelante.  
Utiliza **Enfoque 2 (tamaño del gráfico)** si las dimensiones del gráfico son fijas y no cambiarán después de la incrustación.

**¿Funcionarán estos métodos tanto con presentaciones basadas en plantillas como con presentaciones nuevas?**

Sí. Ambos enfoques funcionan de la misma manera para presentaciones creadas a partir de plantillas y desde cero.

**¿Existe un límite al tamaño del marco del objeto OLE?**

No. Puedes establecer el marco OLE a cualquier tamaño siempre que escale apropiadamente al tamaño del libro o del gráfico.

**¿Puedo usar estos métodos con gráficos creados en otros programas de hoja de cálculo?**

Los ejemplos están diseñados para gráficos de Excel creados con Aspose.Cells, pero los principios se aplican a otros programas de hoja de cálculo compatibles con OLE siempre que admitan opciones de tamaño similares.

## **Secciones relacionadas**

- [Crear gráficos de Excel e incrustarlos como objetos OLE en presentaciones](/slides/es/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Actualizar objetos OLE automáticamente usando un complemento de PowerPoint](/slides/es/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)