---
title: Solución funcional para el redimensionamiento de gráficos en PPTX
type: docs
weight: 60
url: /es/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionamiento de gráficos
- gráfico de Excel
- objeto OLE
- incrustar gráfico
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Soluciona el inesperado redimensionamiento de gráficos en PPTX al usar objetos OLE de Excel incrustados con Aspose.Slides para .NET. Aprende dos métodos con código para mantener los tamaños consistentes."
---

## **Antecedentes**

Se ha observado que los gráficos de Excel incrustados como objetos OLE en una presentación de PowerPoint mediante los componentes de Aspose se redimensionan a una escala no especificada después de su primera activación. Este comportamiento genera una diferencia visual notable en la presentación entre los estados antes y después de la activación del gráfico. El equipo de Aspose investigó el problema en detalle y encontró una solución. Este artículo describe las causas del problema y la corrección correspondiente.

En el [artículo anterior](/slides/es/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos cómo crear un gráfico de Excel con Aspose.Cells para .NET e incrustarlo en una presentación de PowerPoint usando Aspose.Slides para .NET. Para abordar el [object preview issue](/slides/es/net/object-preview-issue-when-adding-oleobjectframe/), asignamos la imagen del gráfico al marco del objeto OLE del gráfico. En la presentación resultante, cuando se hace doble clic en el marco del objeto OLE que muestra la imagen del gráfico, se activa el gráfico de Excel. Los usuarios finales pueden realizar los cambios deseados en el libro de Excel subyacente y luego volver a la diapositiva correspondiente haciendo clic fuera del libro activado. El tamaño del marco del objeto OLE cambia cuando el usuario regresa a la diapositiva, y el factor de redimensionamiento varía según los tamaños originales tanto del marco del objeto OLE como del libro de Excel incrustado.

## **Causa del redimensionamiento**

Porque el libro de Excel tiene su propio tamaño de ventana, intenta mantener su tamaño original en la primera activación. Sin embargo, el marco del objeto OLE tiene su propio tamaño. Según Microsoft, cuando se activa el libro de Excel, Excel y PowerPoint negocian el tamaño y mantienen las proporciones correctas como parte del proceso de incrustación. Dependiendo de las diferencias entre el tamaño de la ventana de Excel y el tamaño o posición del marco del objeto OLE, se produce el redimensionamiento.

## **Solución funcional**

Existen dos escenarios posibles para crear presentaciones de PowerPoint usando Aspose.Slides para .NET.

**Escenario 1:** Crear una presentación a partir de una plantilla existente.

**Escenario 2:** Crear una presentación desde cero.

La solución que ofrecemos aquí se aplica a ambos escenarios. La base de todos los enfoques de solución es la misma: **el tamaño de la ventana del objeto OLE incrustado debe coincidir con el marco del objeto OLE en la diapositiva de PowerPoint**. Ahora discutiremos los dos enfoques de esta solución.

## **Primer enfoque**

En este enfoque, aprenderemos cómo establecer el tamaño de ventana del libro de Excel incrustado para que coincida con el tamaño del marco del objeto OLE en la diapositiva de PowerPoint.

**Escenario 1**

Supongamos que hemos definido una plantilla y queremos crear presentaciones basadas en ella. Asumamos que hay una forma en el índice 2 de la plantilla donde deseamos colocar un marco OLE que contiene un libro de Excel incrustado. En este escenario, el tamaño del marco del objeto OLE está predefinido—coincide con el tamaño de la forma en el índice 2 de la plantilla. Lo único que necesitamos hacer es establecer el tamaño de ventana del libro igual al tamaño de esa forma. El siguiente fragmento de código sirve para este propósito:
```cs
// Definir el tamaño del gráfico con una ventana. 
chart.SizeWithWindow = true;

// Establecer el ancho de la ventana del libro de trabajo en pulgadas (dividido por 72 ya que PowerPoint usa 72 píxeles por pulgada).
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// Establecer la altura de la ventana del libro de trabajo en pulgadas.
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// Guardar el libro de trabajo en un flujo de memoria.
MemoryStream workbookStream = workbook.SaveToStream();

// Crear un marco de objeto OLE con los datos de Excel incrustados.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**Escenario 2**

Supongamos que queremos crear una presentación desde cero e incluir un marco de objeto OLE de cualquier tamaño con un libro de Excel incrustado. En el siguiente fragmento de código, creamos un marco de objeto OLE de 4 pulgadas de alto y 9.5 pulgadas de ancho en x = 0.5 pulgadas y y = 1 pulgada en la diapositiva. Luego establecemos la ventana del libro de Excel al mismo tamaño—4 pulgadas de alto y 9.5 pulgadas de ancho.
```cs
// Altura deseada.
int desiredHeight = 288; // 4 pulgadas (4 * 72)

// Ancho deseado.
int desiredWidth = 684;// 9.5 pulgadas (9.5 * 72)

// Definir el tamaño del gráfico con una ventana.
chart.SizeWithWindow = true;

// Establecer el ancho de la ventana del libro de trabajo en pulgadas.
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// Establecer la altura de la ventana del libro de trabajo en pulgadas.
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// Guardar el libro de trabajo en un flujo de memoria.
MemoryStream workbookStream = workbook.SaveToStream();

// Crear un marco de objeto OLE con los datos de Excel incrustados.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **Segundo enfoque**

En este enfoque, aprenderemos cómo establecer el tamaño del gráfico en el libro de Excel incrustado para que coincida con el tamaño del marco del objeto OLE en la diapositiva de PowerPoint. Este enfoque es útil cuando el tamaño del gráfico se conoce de antemano y nunca cambiará.

**Escenario 1**

Supongamos que hemos definido una plantilla y queremos crear presentaciones basadas en ella. Asumamos que hay una forma en el índice 2 de la plantilla donde pretendemos colocar un marco OLE que contiene un libro de Excel incrustado. En este escenario, el tamaño del marco OLE está predefinido—coincide con el tamaño de la forma en el índice 2 de la plantilla. Lo único que necesitamos hacer es establecer el tamaño del gráfico en el libro para que sea igual al tamaño de esa forma. El siguiente fragmento de código sirve para este propósito:
```cs
// Definir el tamaño del gráfico sin ventana. 
chart.SizeWithWindow = false;

// Establecer el ancho del gráfico en píxeles (multiplicar por 96 ya que Excel usa 96 píxeles por pulgada).    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// Establecer la altura del gráfico en píxeles.
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// Definir el tamaño de impresión del gráfico.
chart.PrintSize = PrintSizeType.Custom;

// Guardar el libro de trabajo en un flujo de memoria.
MemoryStream workbookStream = workbook.SaveToStream();

// Crear un marco de objeto OLE con los datos de Excel incrustados.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**Escenario 2**

Supongamos que queremos crear una presentación desde cero e incluir un marco de objeto OLE de cualquier tamaño con un libro de Excel incrustado. En el siguiente fragmento de código, creamos un marco de objeto OLE con una altura de 4 pulgadas y un ancho de 9.5 pulgadas en la diapositiva en x = 0.5 pulgadas y y = 1 pulgada. También establecemos el tamaño del gráfico correspondiente a las mismas dimensiones: una altura de 4 pulgadas y un ancho de 9.5 pulgadas.
```cs
 // Altura deseada.
int desiredHeight = 288; // 4 pulgadas (4 * 576)

// Ancho deseado.
int desiredWidth = 684; // 9.5 pulgadas (9.5 * 576)

// Definir el tamaño del gráfico sin ventana. 
chart.SizeWithWindow = false;

// Establecer el ancho del gráfico en píxeles.   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// Establecer la altura del gráfico en píxeles.    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// Guardar el libro de trabajo en un flujo de memoria.
MemoryStream workbookStream = workbook.SaveToStream();

// Crear un marco de objeto OLE con los datos de Excel incrustados.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **Conclusión**

Existen dos enfoques para solucionar el problema de redimensionamiento del gráfico. La elección del enfoque depende de los requisitos y del caso de uso. Ambos enfoques funcionan de la misma manera, ya sea que las presentaciones se creen a partir de una plantilla o se creen desde cero. Además, no hay límite al tamaño del marco del objeto OLE en esta solución.

## **Preguntas frecuentes**

**¿Por qué mi gráfico de Excel incrustado cambia de tamaño después de activarlo en PowerPoint?**  
Esto ocurre porque Excel intenta restaurar el tamaño original de la ventana al activarse por primera vez, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la proporción, lo que puede provocar el redimensionamiento.

**¿Es posible evitar este problema de redimensionamiento por completo?**  
Sí. Al hacer coincidir el tamaño de la ventana del libro de Excel o el tamaño del gráfico con el tamaño del marco del objeto OLE antes de incrustarlo, se pueden mantener los tamaños de los gráficos consistentes.

**¿Qué enfoque debo utilizar, establecer el tamaño de la ventana del libro o establecer el tamaño del gráfico?**  
Use **Enfoque 1 (tamaño de ventana)** si desea mantener la proporción del libro y posiblemente permitir redimensionamientos posteriores.  
Use **Enfoque 2 (tamaño del gráfico)** si las dimensiones del gráfico son fijas y no cambiarán después de incrustarlo.

**¿Funcionarán estos métodos tanto con presentaciones basadas en plantillas como con presentaciones nuevas?**  
Sí. Ambos enfoques funcionan de la misma manera para presentaciones creadas a partir de plantillas y desde cero.

**¿Existe un límite al tamaño del marco del objeto OLE?**  
No. Puede establecer el marco OLE a cualquier tamaño siempre que se escale adecuadamente al tamaño del libro o del gráfico.

**¿Puedo usar estos métodos con gráficos creados en otros programas de hoja de cálculo?**  
Los ejemplos están diseñados para gráficos de Excel creados con Aspose.Cells, pero los principios se aplican a otros programas de hoja de cálculo compatibles con OLE siempre que admitan opciones de tamaño similares.

## **Secciones relacionadas**

- [Crear gráficos de Excel e incrustarlos como objetos OLE en presentaciones](/slides/es/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Actualizar objetos OLE automáticamente usando un complemento de PowerPoint](/slides/es/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)