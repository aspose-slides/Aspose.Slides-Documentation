---
title: Administrar los marcadores de datos de gráfico en presentaciones usando C++
linktitle: Marcador de datos
type: docs
url: /es/cpp/chart-data-marker/
keywords:
- gráfico
- punto de datos
- marcador
- opciones de marcador
- tamaño del marcador
- tipo de relleno
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda a personalizar los marcadores de datos de los gráficos en Aspose.Slides para C++, mejorando el impacto de las presentaciones en formatos PPT y PPTX con claros ejemplos de código en C++."
---

## **Establecer marcadores de gráfico**
Aspose.Slides para C++ ofrece una API sencilla para establecer automáticamente el marcador de la serie del gráfico. En la siguiente función, cada serie del gráfico obtendrá automáticamente un símbolo de marcador predeterminado diferente.

El siguiente ejemplo de código muestra cómo establecer automáticamente el marcador de la serie del gráfico.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Establecer opciones de marcador de gráfico**
Los marcadores pueden establecerse en los puntos de datos del gráfico dentro de una serie determinada. Para establecer opciones de marcador de gráfico, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Crear el gráfico predeterminado.
- Establecer la imagen.
- Obtener la primera serie del gráfico.
- Añadir un nuevo punto de datos.
- Guardar la presentación en disco.

En el ejemplo a continuación, hemos configurado las opciones de marcador de gráfico a nivel de puntos de datos.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Establecer marcadores de gráfico a nivel de punto de datos de la serie**
Ahora, los marcadores pueden establecerse en los puntos de datos del gráfico dentro de una serie determinada. Para establecer opciones de marcador de gráfico, siga los pasos a continuación:

- Instanciar la clase Presentation.
- Crear el gráfico predeterminado.
- Establecer la imagen.
- Obtener la primera serie del gráfico.
- Añadir un nuevo punto de datos.
- Guardar la presentación en disco.

En el ejemplo a continuación, hemos configurado las opciones de marcador de gráfico a nivel de puntos de datos.
```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instanciar la clase Presentation que representa un archivo PPTX
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Acceder a la primera diapositiva
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Añadir gráfico con datos predeterminados
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Establecer el índice de la hoja de datos del gráfico
int defaultWorksheetIndex = 0;

// Obtener la hoja de datos del gráfico
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Eliminar series y categorías generadas por defecto
chart->get_ChartData()->get_Series()->Clear();

// Ahora, añadiendo una nueva serie
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Obtener la imagen
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Añadir la imagen a la colección de imágenes de la presentación
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Añadir nuevo punto (1:3) allí.
SharedPtr<IChartDataPoint> point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

// Cambiar el marcador de la serie del gráfico
series->get_Marker()->set_Size(15);

// Guardar el archivo de presentación en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```


## **Aplicar un color a los puntos de datos**
Puede aplicar color a los puntos de datos del gráfico utilizando Aspose.Slides para C++. Se han añadido las clases [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) y **[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/)** para acceder a las propiedades de los niveles de puntos de datos. Este artículo muestra cómo puede acceder y aplicar color a los puntos de datos de un gráfico.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**¿Qué formas de marcador están disponibles de forma predeterminada?**

Están disponibles formas estándar (círculo, cuadrado, diamante, triángulo, etc.); la lista está definida por la enumeración [MarkerStyleType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/markerstyletype/). Si necesita una forma no estándar, utilice un marcador con relleno de imagen para emular diseños personalizados.

**¿Se conservan los marcadores al exportar un gráfico a una imagen o SVG?**

Sí. Al renderizar gráficos a [formatos raster](/slides/es/cpp/convert-powerpoint-to-png/) o al guardar [formas como SVG](/slides/es/cpp/render-a-slide-as-an-svg-image/), los marcadores conservan su apariencia y configuración, incluido el tamaño, el relleno y el contorno.