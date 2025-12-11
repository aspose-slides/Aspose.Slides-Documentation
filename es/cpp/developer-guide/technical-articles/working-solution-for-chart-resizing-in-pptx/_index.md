---
title: Solución funcional para el redimensionamiento de gráficos en PPTX
type: docs
weight: 60
url: /es/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionamiento de gráficos
- gráfico de Excel
- objeto OLE
- incrustar gráfico
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Soluciona el inesperado redimensionamiento de gráficos en PPTX al usar objetos OLE de Excel incrustados con Aspose.Slides para C++. Aprende dos métodos con código para mantener los tamaños consistentes."
---

## **Antecedentes**

Se ha observado que los gráficos de Excel incrustados como objetos OLE en una presentación de PowerPoint a través de los componentes Aspose se redimensionan a una escala no especificada después de su primera activación. Este comportamiento provoca una diferencia visual notable en la presentación entre los estados antes y después de la activación del gráfico. El equipo de Aspose ha investigado el problema en detalle y ha encontrado una solución. Este artículo describe las causas del problema y la corrección correspondiente.

En el [artículo anterior](/slides/es/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos cómo crear un gráfico de Excel con Aspose.Cells para C++ e incrustarlo en una presentación de PowerPoint usando Aspose.Slides para C++. Para abordar el [problema de vista previa del objeto](/slides/es/cpp/object-preview-issue-when-adding-oleobjectframe/), asignamos la imagen del gráfico al marco del objeto OLE del gráfico. En la presentación resultante, cuando se hace doble clic en el marco del objeto OLE que muestra la imagen del gráfico, se activa el gráfico de Excel. Los usuarios pueden realizar cualquier cambio deseado en el libro de Excel subyacente y luego volver a la diapositiva correspondiente haciendo clic fuera del libro activado. El tamaño del marco del objeto OLE cambia cuando el usuario vuelve a la diapositiva, y el factor de redimensionamiento varía según los tamaños originales tanto del marco del objeto OLE como del libro de Excel incrustado.

## **Causa del redimensionamiento**

Debido a que el libro de Excel tiene su propio tamaño de ventana, intenta conservar su tamaño original en su primera activación. Sin embargo, el marco del objeto OLE tiene su propio tamaño. Según Microsoft, cuando se activa el libro de Excel, Excel y PowerPoint negocian el tamaño y mantienen las proporciones correctas como parte del proceso de incrustación. Dependiendo de las diferencias entre el tamaño de la ventana de Excel y el tamaño o posición del marco del objeto OLE, se produce el redimensionamiento.

## **Solución funcional**

Existen dos escenarios posibles para crear presentaciones de PowerPoint usando Aspose.Slides para C++.

**Scenario 1:** Crear una presentación basada en una plantilla existente.  
**Scenario 2:** Crear una presentación desde cero.

La solución que proporcionamos aquí se aplica a ambos escenarios. La base de todos los enfoques de solución es la misma: **el tamaño de ventana del objeto OLE incrustado debe coincidir con el marco del objeto OLE en la diapositiva de PowerPoint**. Ahora discutiremos los dos enfoques de esta solución.

## **Primer enfoque**

En este enfoque, aprenderemos cómo establecer el tamaño de ventana del libro de Excel incrustado para que coincida con el tamaño del marco del objeto OLE en la diapositiva de PowerPoint.

**Escenario 1**  

Supongamos que hemos definido una plantilla y queremos crear presentaciones basadas en ella. Asumamos que hay una forma en el índice 2 de la plantilla donde queremos colocar un marco OLE que contiene un libro de Excel incrustado. En este escenario, el tamaño del marco del objeto OLE está predefinido — coincide con el tamaño de la forma en el índice 2 de la plantilla. Todo lo que necesitamos hacer es establecer el tamaño de ventana del libro igual al tamaño de esa forma. El siguiente fragmento de código cumple este propósito:
```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// Definir el tamaño del gráfico con una ventana. 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// Establecer el ancho de la ventana del libro de trabajo en pulgadas (dividido por 72 ya que PowerPoint usa 72 píxeles por pulgada).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// Establecer la altura de la ventana del libro de trabajo en pulgadas.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Guardar el libro de trabajo en un flujo de memoria.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Crear un marco de objeto OLE con los datos de Excel incrustados.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```


**Escenario 2**  

Digamos que queremos crear una presentación desde cero e incluir un marco de objeto OLE de cualquier tamaño con un libro de Excel incrustado. En el siguiente fragmento de código, creamos un marco de objeto OLE de 4 pulgadas de alto y 9,5 pulgadas de ancho en x = 0,5 pulgadas y y = 1 pulgada en la diapositiva. Luego establecemos la ventana del libro de Excel al mismo tamaño — 4 pulgadas de alto y 9,5 pulgadas de ancho.
```cpp
// Nuestra altura deseada.
int32_t desiredHeight = 288; // 4 pulgadas (4 * 72)

// Nuestro ancho deseado.
int32_t desiredWidth = 684; // 9.5 pulgadas (9.5 * 72)

// Define el tamaño del gráfico con una ventana. 
chart->SetSizeWithWindow(true);

// Establece el ancho de la ventana del libro de trabajo en pulgadas.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// Establece la altura de la ventana del libro de trabajo en pulgadas.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Guarda el libro de trabajo en un flujo de memoria.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Crea un marco de objeto OLE con los datos de Excel incrustados.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```


## **Segundo enfoque**

En este enfoque, aprenderemos cómo establecer el tamaño del gráfico en el libro de Excel incrustado para que coincida con el tamaño del marco del objeto OLE en la diapositiva de PowerPoint. Este enfoque es útil cuando el tamaño del gráfico se conoce de antemano y nunca cambiará.

**Escenario 1**  

Supongamos que hemos definido una plantilla y queremos crear presentaciones basadas en ella. Asumamos que hay una forma en el índice 2 de la plantilla donde pretendemos colocar un marco OLE que contiene un libro de Excel incrustado. En este escenario, el tamaño del marco OLE está predefinido — coincide con el tamaño de la forma en el índice 2 de la plantilla. Todo lo que necesitamos hacer es establecer el tamaño del gráfico en el libro igual al tamaño de esa forma. El siguiente fragmento de código cumple este propósito:
```cpp
// Definir el tamaño del gráfico sin ventana. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// Establecer el ancho del gráfico en píxeles (multiplicar por 96 ya que Excel usa 96 píxeles por pulgada).    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// Establecer la altura del gráfico en píxeles.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Definir el tamaño de impresión del gráfico.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Guardar el libro de trabajo en un flujo de memoria.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Crear un marco de objeto OLE con los datos de Excel incrustados.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```


**Escenario 2**  

Supongamos que queremos crear una presentación desde cero e incluir un marco de objeto OLE de cualquier tamaño con un libro de Excel incrustado. En el siguiente fragmento de código, creamos un marco de objeto OLE con una altura de 4 pulgadas y una anchura de 9,5 pulgadas en la diapositiva en x = 0,5 pulgadas y y = 1 pulgada. También establecemos el tamaño del gráfico correspondiente a las mismas dimensiones: una altura de 4 pulgadas y una anchura de 9,5 pulgadas.
```cpp
// Nuestra altura deseada.
int32_t desiredHeight = 288; // 4 pulgadas (4 * 576)

// Nuestro ancho deseado.
int32_t desiredWidth = 684; // 9.5 pulgadas (9.5 * 576)

// Definir el tamaño del gráfico sin ventana. 
chart->SetSizeWithWindow(false);

// Establecer el ancho del gráfico en píxeles.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// Establecer la altura del gráfico en píxeles.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Guardar el libro de trabajo en un flujo de memoria.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Crear un marco de objeto OLE con los datos de Excel incrustados.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```


## **Conclusión**

Existen dos enfoques para solucionar el problema de redimensionamiento del gráfico. La elección del enfoque depende de los requisitos y del caso de uso. Ambos enfoques funcionan de la misma manera, ya sea que las presentaciones se creen a partir de una plantilla o se creen desde cero. Además, no hay límite al tamaño del marco del objeto OLE en esta solución.

## **Preguntas frecuentes**

**¿Por qué mi gráfico de Excel incrustado cambia de tamaño después de activarlo en PowerPoint?**  
Esto ocurre porque Excel intenta restaurar el tamaño original de la ventana cuando se activa por primera vez, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la proporción, lo que puede provocar el redimensionamiento.

**¿Es posible evitar este problema de redimensionamiento por completo?**  
Sí. Al hacer coincidir el tamaño de ventana del libro de Excel o el tamaño del gráfico con el tamaño del marco del objeto OLE antes de incrustar, puedes mantener los tamaños del gráfico consistentes.

**¿Qué enfoque debo usar, establecer el tamaño de ventana del libro o establecer el tamaño del gráfico?**  
Utilice **Enfoque 1 (tamaño de ventana)** si desea mantener la proporción del libro y posiblemente permitir redimensionamientos posteriores.  
Utilice **Enfoque 2 (tamaño del gráfico)** si las dimensiones del gráfico son fijas y no cambiarán después de la incrustación.

**¿Estos métodos funcionan tanto con presentaciones basadas en plantillas como con presentaciones nuevas?**  
Sí. Ambos enfoques funcionan de la misma manera para presentaciones creadas a partir de plantillas y desde cero.

**¿Hay un límite al tamaño del marco del objeto OLE?**  
No. Puede establecer el marco OLE a cualquier tamaño siempre que se escale adecuadamente al tamaño del libro o del gráfico.

**¿Puedo usar estos métodos con gráficos creados en otros programas de hojas de cálculo?**  
Los ejemplos están diseñados para gráficos de Excel creados con Aspose.Cells, pero los principios se aplican a otros programas de hoja de cálculo compatibles con OLE siempre que admitan opciones de dimensionado similares.

## **Secciones relacionadas**

- [Crear gráficos de Excel e incrustarlos como objetos OLE en presentaciones](/slides/es/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)