---
title: Solución Funcional para el Redimensionamiento de Gráficos en PPTX
type: docs
weight: 60
url: /es/cpp/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

Se ha observado que los Gráficos de Excel incrustados como OLE en una Presentación de PowerPoint a través de componentes de Aspose se redimensionan a una escala no identificada después de la activación por primera vez. Este comportamiento crea una diferencia visual considerable en la presentación entre los estados antes y después de la activación del gráfico. El equipo de Aspose, con la ayuda del equipo de Microsoft, ha investigado este problema en detalle y ha encontrado la solución. Este artículo cubre las razones y la solución a este problema. 

{{% /alert %}} 
## **Antecedentes**
En [artículo anterior](https://docs.aspose.com/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) , hemos explicado cómo crear un Gráfico de Excel utilizando Aspose.Cells para C++ y luego incrustar este gráfico en una Presentación de PowerPoint utilizando Aspose.Slides para C++. Para abordar el problema de cambio de objeto, asignamos la imagen del gráfico al Marco de Objeto OLE del Gráfico. En la presentación de salida, cuando hacemos doble clic en el Marco de Objeto OLE que muestra la Imagen del Gráfico, se activa el Gráfico de Excel. Los usuarios finales pueden realizar cualquier cambio deseado en el libro de trabajo de Excel y luego regresar a la Diapositiva correspondiente haciendo clic fuera del libro de trabajo de Excel activado. El tamaño del Marco de Objeto OLE cambiará cuando el usuario regrese a la diapositiva. El factor de redimensionamiento será diferente para diferentes tamaños del Marco de Objeto OLE y del libro de trabajo de Excel incrustado.

## **Causa del Redimensionamiento**
Dado que el libro de trabajo de Excel tiene su propio tamaño de ventana, intenta mantener su tamaño original en la primera activación. Por otro lado, el Marco de Objeto OLE tendrá su propio tamaño. Según Microsoft, al activar el libro de trabajo de Excel, Excel y PowerPoint negocian el tamaño y aseguran que esté en las proporciones correctas como parte de la operación de incrustación. Basado en las diferencias en el tamaño de las Ventanas de Excel y el tamaño / posición del Marco de Objeto OLE, ocurre el redimensionamiento.

## **Solución Funcional**
Hay dos escenarios posibles para la creación de Presentaciones de PowerPoint utilizando Aspose.Slides para C++. 

**Escenario 1:** Crear la presentación basada en una plantilla existente.

**Escenario 2:** Crear la presentación desde cero. 

La solución que proporcionaremos aquí será válida para ambos escenarios. La base de todos los enfoques de solución será la misma. Es decir: **El tamaño de la ventana del Objeto OLE incrustado debe ser el mismo que el del Marco de Objeto OLE** **en la Diapositiva de PowerPoint**. Ahora, discutiremos los dos enfoques de la solución. 

## **Primer Enfoque**
En este enfoque, aprenderemos cómo establecer el tamaño de la ventana del libro de trabajo de Excel incrustado equivalente al tamaño del Marco de Objeto OLE en la Diapositiva de PowerPoint. 

**Escenario 1** 

Supongamos que hemos definido una plantilla y deseamos crear las presentaciones basadas en esta plantilla. Supongamos que hay alguna forma en el índice 2 de la plantilla donde queremos colocar un Marco OLE que contenga un libro de trabajo de Excel incrustado. En este escenario, el tamaño del Marco de Objeto OLE se considerará como predefinido (que es el tamaño de la forma en el índice 2 de la plantilla). Todo lo que tenemos que hacer es: establecer el tamaño de la ventana del Libro de Trabajo igual al tamaño de la Forma. El siguiente fragmento de código servirá para este propósito: 

``` cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

``` cpp
// definir el tamaño del gráfico con la ventana 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shapes()->idx_get(2);

// establecer el ancho de la ventana del libro de trabajo en pulgadas (dividido por 72, ya que PowerPoint utiliza 
// 72 píxeles / pulgada)
wb->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// establecer la altura de la ventana del libro de trabajo en pulgadas
wb->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Instanciar MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream3(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Crear un Marco de Objeto OLE con Excel incrustado
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	shape->get_X(), 
	shape->get_Y(), 
	shape->get_Width(), 
	shape->get_Height(),
	dataInfo);
```

**Escenario 2** 

Supongamos que queremos crear una presentación desde cero y deseamos un Marco de Objeto OLE de cualquier tamaño con un libro de trabajo de Excel incrustado. En el siguiente fragmento de código, hemos creado un Marco de Objeto OLE con 4 pulgadas de altura y 9.5 pulgadas de ancho en la diapositiva en el eje x=0.5 pulgadas y el eje y=1 pulgada. Además, hemos establecido el tamaño de ventana del libro de trabajo de Excel equivalente, es decir: altura de 4 pulgadas y ancho de 9.5 pulgadas. 

``` cpp
// Nuestra altura deseada
int32_t desiredHeight = 288; //4 pulgadas (4 * 72)

// Nuestro ancho deseado
int32_t desiredWidth = 684; //9.5 pulgadas (9.5 * 72)

// definir el tamaño del gráfico con la ventana 
chart->SetSizeWithWindow(true);

// establecer el ancho de la ventana del libro de trabajo en pulgadas
wb->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// establecer la altura de la ventana del libro de trabajo en pulgadas
wb->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Instanciar MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Crear un Marco de Objeto OLE con Excel incrustado
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	36.0f,
	72.0f, 
	desiredWidth, 
	desiredHeight,
	dataInfo);
```


## **Segundo Enfoque**
En este enfoque, aprenderemos cómo establecer el tamaño del gráfico presente en el libro de trabajo de Excel incrustado equivalente al tamaño del Marco de Objeto OLE en la Diapositiva de PowerPoint. Este enfoque es útil cuando el tamaño del gráfico por anticipado se conoce y nunca cambiará. 

**Escenario 1** 

Supongamos que hemos definido una plantilla y deseamos crear las presentaciones basadas en esta plantilla. Supongamos que hay alguna forma en el índice 2 de la plantilla donde queremos colocar un Marco OLE que contenga un libro de trabajo de Excel incrustado. En este escenario, el tamaño del Marco OLE se considerará como predefinido (que es el tamaño de la forma en el índice 2 de la plantilla). Todo lo que tenemos que hacer es: establecer el tamaño del gráfico en el Libro de Trabajo igual al tamaño de la forma. El siguiente fragmento de código servirá para este propósito: 

``` cpp
// definir el tamaño del gráfico sin ventana 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shapes()->idx_get(2);

// establecer el ancho del gráfico en píxeles (Multiplicar por 96 ya que Excel utiliza 96 píxeles por pulgada)    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// establecer la altura del gráfico en píxeles
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Definir el tamaño de impresión del gráfico
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Instanciar MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Crear un Marco de Objeto OLE con Excel incrustado
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	shape->get_X(), 
	shape->get_Y(), 
	shape->get_Width(),
	shape->get_Height(),
	dataInfo);
```

**Escenario 2** 

Supongamos que queremos crear una presentación desde cero y deseamos un Marco de Objeto OLE de cualquier tamaño con un libro de trabajo de Excel incrustado. En el siguiente fragmento de código, hemos creado un Marco de Objeto OLE con 4 pulgadas de altura y 9.5 pulgadas de ancho en la diapositiva en el eje x=0.5 pulgadas y el eje y=1 pulgada. Además, hemos establecido el tamaño del Gráfico equivalente, es decir: altura de 4 pulgadas y ancho de 9.5 pulgadas. 

``` cpp
// Nuestra altura deseada
int32_t desiredHeight = 288; // 4 pulgadas (4 * 576)

// Nuestro ancho deseado
int32_t desiredWidth = 684; // 9.5 pulgadas(9.5 * 576)

// definir el tamaño del gráfico sin ventana 
chart->SetSizeWithWindow(false);

// establecer el ancho del gráfico en píxeles    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// establecer la altura del gráfico en píxeles    
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Instanciar MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Crear un Marco de Objeto OLE con Excel incrustado
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	36.0f, 
	72.0f, 
	desiredWidth, 
	desiredHeight,
	dataInfo);
```

## **Conclusión**
{{% alert color="primary" %}} 

Hay dos enfoques para solucionar el problema de redimensionamiento del gráfico. La selección del enfoque apropiado depende del requisito y el caso de uso. Ambos enfoques funcionan de la misma manera, ya sea que las presentaciones se creen a partir de una plantilla o se creen desde cero. Además, no hay límite en el tamaño del Marco de Objeto OLE en la solución. 

{{% /alert %}} 
## **Secciones Relacionadas**
[Creando e Incrustando un Gráfico de Excel como Objeto OLE en la Presentación](https://docs.aspose.com/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)