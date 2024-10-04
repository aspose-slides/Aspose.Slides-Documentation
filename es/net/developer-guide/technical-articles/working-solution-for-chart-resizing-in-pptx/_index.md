---
title: Solución Funcionante para el Redimensionamiento de Gráficos en PPTX
type: docs
weight: 60
url: /net/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

Se ha observado que los Gráficos de Excel incrustados como OLE en una Presentación de PowerPoint a través de los componentes de Aspose se redimensionan a una escala no identificada después de la primera activación. Este comportamiento crea una diferencia visual considerable en la presentación entre los estados de activación del gráfico previos y posteriores. El equipo de Aspose, con la ayuda del equipo de Microsoft, ha investigado este problema en detalle y ha encontrado la solución. Este artículo cubre las razones y la solución a este problema. 

{{% /alert %}} 
## **Antecedentes**
En [artículo anterior](/slides/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) , hemos explicado cómo crear un Gráfico de Excel usando Aspose.Cells para .NET y luego incrustar este gráfico en una Presentación de PowerPoint usando Aspose.Slides para .NET. Para acomodar el [problema de objeto cambiado](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/) , asignamos la imagen del gráfico al Marco de Objeto OLE del Gráfico. En la presentación de salida, cuando hacemos doble clic en el Marco de Objeto OLE que muestra la Imagen del Gráfico, el Gráfico de Excel se activa. Los usuarios finales pueden hacer cualquier cambio deseado en el Libro de Trabajo de Excel real y luego regresar a la Diapositiva correspondiente haciendo clic fuera del Libro de Trabajo de Excel activado. El tamaño del Marco de Objeto OLE cambiará cuando el usuario regrese a la diapositiva. El factor de redimensionamiento será diferente para diferentes tamaños de Marco de Objeto OLE y Libro de Trabajo de Excel incrustado. 
## **Causa del Redimensionamiento**
Dado que el Libro de Trabajo de Excel tiene su propio tamaño de ventana, intenta mantener su tamaño original en la primera activación. Por otro lado, el Marco de Objeto OLE tendrá su propio tamaño. Según Microsoft, en la activación del Libro de Trabajo de Excel, Excel y PowerPoint negocian el tamaño y se aseguran de que esté en las proporciones correctas como parte de la operación de incrustación. Basado en las diferencias en el tamaño de la ventana de Excel y el tamaño / posición del Marco de Objeto OLE, ocurre el redimensionamiento. 
## **Solución Funcionante**
Hay dos posibles escenarios para la creación de Presentaciones de PowerPoint usando Aspose.Slides para .NET. 

**Escenario 1:** Crear la presentación basada en una plantilla existente 

**Escenario 2:** Crear la presentación desde cero. 

La solución que proporcionaremos aquí será válida para ambos escenarios. La base de todos los enfoques de solución será la misma. Es decir: **El tamaño de la ventana de Objeto OLE incrustado debe ser el mismo que el del Marco de Objeto OLE** **en la Diapositiva de PowerPoint**. Ahora, discutiremos los dos enfoques de la solución. 
## **Primer Enfoque**
En este enfoque, aprenderemos cómo establecer el tamaño de la ventana del Libro de Trabajo de Excel incrustado equivalente al tamaño del Marco de Objeto OLE en la Diapositiva de PowerPoint. 

**Escenario 1** 

Supongamos que hemos definido una plantilla y deseamos crear las presentaciones basadas en esta plantilla. Digamos que hay una forma en el índice 2 en la plantilla donde queremos colocar un Marco OLE que contenga un Libro de Trabajo de Excel incrustado. En este escenario, el tamaño del Marco de Objeto OLE se considerará como predefinido (que es el tamaño de la forma en el índice 2 en la plantilla). Todo lo que tenemos que hacer: establecer el tamaño de la ventana del Libro de Trabajo igual al tamaño de la Forma. El siguiente fragmento de código servirá para este propósito: 

```c#
//definir el tamaño del gráfico con la ventana 
chart.SizeWithWindow = true;

//establecer el ancho de la ventana del libro en pulgadas (dividido por 72 ya que PowerPoint usa 
//72 píxeles/pulgada)
wb.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

//establecer la altura de la ventana del libro en pulgadas
wb.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

//Instanciar MemoryStream
MemoryStream ms = wb.SaveToStream();

//Crear un Marco de Objeto OLE con Excel incrustado
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
				slide.Shapes[2].X,
				slide.Shapes[2].Y,
				slide.Shapes[2].Width,
				slide.Shapes[2].Height, "Excel.Sheet.8", ms.ToArray());
```

**Escenario 2** 

Digamos que queremos crear una presentación desde cero y deseamos un Marco de Objeto OLE de cualquier tamaño con un Libro de Trabajo de Excel incrustado. En el siguiente fragmento de código, hemos creado un Marco de Objeto OLE con 4 pulgadas de altura y 9.5 pulgadas de ancho en la diapositiva en el eje x=0.5 pulgadas y el eje y=1 pulgada. Además, hemos establecido el tamaño de ventana del Libro de Trabajo de Excel equivalente, es decir: altura 4 pulgadas y ancho 9.5 pulgadas. 

```c#
 //Nuestra altura deseada
int desiredHeight = 288;//4 pulgadas (4 * 72)

//Nuestro ancho deseado
int desiredWidth = 684;//9.5 pulgadas (9.5 * 72)

//definir el tamaño del gráfico con la ventana
chart.SizeWithWindow = true;

//establecer el ancho de la ventana del libro en pulgadas
wb.Worksheets.WindowWidthInch = desiredWidth / 72f;

//establecer la altura de la ventana del libro en pulgadas
wb.Worksheets.WindowHeightInch = desiredHeight / 72f;

//Instanciar MemoryStream
MemoryStream ms = wb.SaveToStream();

//Crear un Marco de Objeto OLE con Excel incrustado
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
							36,
							72,
							desiredWidth,
							desiredHeight, "Excel.Sheet.8", ms.ToArray());
```



## **Segundo Enfoque**
En este enfoque, aprenderemos cómo establecer el tamaño del gráfico presente en el Libro de Trabajo de Excel incrustado equivalente al tamaño del Marco de Objeto OLE en la Diapositiva de PowerPoint. Este enfoque es útil cuando el tamaño del gráfico de antemano se conoce y nunca cambiará. 

**Escenario 1** 

Supongamos que hemos definido una plantilla y deseamos crear las presentaciones basadas en esta plantilla. Digamos que hay una forma en el índice 2 en la plantilla donde queremos colocar un Marco OLE que contenga un Libro de Trabajo de Excel incrustado. En este escenario, el tamaño del Marco OLE se considerará como predefinido (que es el tamaño de la forma en el índice 2 en la plantilla). Todo lo que tenemos que hacer: establecer el tamaño del gráfico en el Libro de Trabajo igual al tamaño de la forma. El siguiente fragmento de código servirá para este propósito: 

```c#
//definir el tamaño del gráfico sin ventana 
chart.SizeWithWindow = false;

//establecer el ancho del gráfico en píxeles (Multiplicar por 96 ya que Excel usa 96 píxeles por pulgada)    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

//establecer la altura del gráfico en píxeles
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

//Definir el tamaño de impresión del gráfico
chart.PrintSize = PrintSizeType.Custom;

//Instanciar MemoryStream
MemoryStream ms = wb.SaveToStream();

//Crear un Marco de Objeto OLE con Excel incrustado
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
				slide.Shapes[2].X,
				slide.Shapes[2].Y,
				slide.Shapes[2].Width,
				slide.Shapes[2].Height, "Excel.Sheet.8", ms.ToArray());

```




**Escenario 2** 

Digamos que queremos crear una presentación desde cero y deseamos un Marco de Objeto OLE de cualquier tamaño con un Libro de Trabajo de Excel incrustado. En el siguiente fragmento de código, hemos creado un Marco de Objeto OLE con 4 pulgadas de altura y 9.5 pulgadas de ancho en la diapositiva en el eje x=0.5 pulgadas y el eje y=1 pulgada. Además, hemos establecido el tamaño equivalente del Gráfico, es decir: altura 4 pulgadas y ancho 9.5 pulgadas. 

```c#
 //Nuestra altura deseada
int desiredHeight = 288;//4 pulgadas (4 * 576)

//Nuestro ancho deseado
int desiredWidth = 684;//9.5 pulgadas (9.5 * 576)

//definir el tamaño del gráfico sin ventana 
chart.SizeWithWindow = false;

//establecer el ancho del gráfico en píxeles    
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

//establecer la altura del gráfico en píxeles    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

//Instanciar MemoryStream
MemoryStream ms = wb.SaveToStream();

//Crear un Marco de Objeto OLE con Excel incrustado
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
							36,
							72,
							desiredWidth,
							desiredHeight, "Excel.Sheet.8", ms.ToArray());
```


## **Conclusión**
{{% alert color="primary" %}} 

Existen dos enfoques para solucionar el problema de redimensionamiento del gráfico. La selección del enfoque apropiado depende del requisito y el caso de uso. Ambos enfoques funcionan de la misma manera ya sea que las presentaciones se creen a partir de una plantilla o se creen desde cero. Además, no hay límite en el tamaño del Marco de Objeto OLE en la solución. 

{{% /alert %}} 
## **Secciones Relacionadas**
[Creando e Incrustando un Gráfico de Excel como Objeto OLE en la Presentación](/slides/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Actualizando Objetos OLE automáticamente](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)