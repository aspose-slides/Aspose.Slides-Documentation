---
title: Marcador de Datos de Gráfico
type: docs
url: /cpp/chart-data-marker/
---

## **Establecer Marcador de Gráfico**
Aspose.Slides para C++ proporciona una API simple para establecer automáticamente el marcador de la serie de gráficos. En la siguiente función, cada serie de gráficos obtendrá automáticamente un símbolo de marcador predeterminado diferente.

El siguiente ejemplo de código muestra cómo establecer automáticamente el marcador de la serie de gráficos.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}


## **Establecer Opciones del Marcador de Gráfico**
Los marcadores se pueden establecer en los puntos de datos del gráfico dentro de una serie particular. Para establecer opciones del marcador del gráfico, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Crear el gráfico predeterminado.
- Establecer la imagen.
- Tomar la primera serie de gráficos.
- Agregar un nuevo punto de datos.
- Escribir una presentación en el disco.

En el ejemplo dado a continuación, hemos establecido las opciones del marcador de gráficos a nivel de puntos de datos.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}


## **Establecer Marcador de Gráfico en el Nivel de Puntos de Datos de la Serie**
Ahora, los marcadores se pueden establecer en los puntos de datos del gráfico dentro de una serie particular. Para establecer opciones del marcador del gráfico, siga los pasos a continuación:

- Instanciar la clase Presentation.
- Crear el gráfico predeterminado.
- Establecer la imagen.
- Tomar la primera serie de gráficos.
- Agregar un nuevo punto de datos.
- Escribir una presentación en el disco.

En el ejemplo dado a continuación, hemos establecido las opciones del marcador de gráficos a nivel de puntos de datos.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instanciar la clase Presentation que representa el archivo PPTX
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Acceder a la primera diapositiva
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Agregar gráfico con datos predeterminados
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Estableciendo el índice de la hoja de datos del gráfico
int defaultWorksheetIndex = 0;

// Obtener la hoja de datos del gráfico
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Eliminar series y categorías generadas por defecto
chart->get_ChartData()->get_Series()->Clear();

// Ahora, agregando una nueva serie
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Serie 1")), chart->get_Type());

// Obtener la imagen
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Agregar imagen a la colección de imágenes de la presentación
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Agregar nuevo punto (1:3) allí.
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

// Cambiando el marcador de la serie de gráficos
series->get_Marker()->set_Size(15);

// Escribir el archivo de presentación en el disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **Aplicar Color a los Puntos de Datos**
Puede aplicar color a los puntos de datos en el gráfico utilizando Aspose.Slides para C++. La clase **[IChartDataPointLevelsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager)** y **[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level)** se han agregado para acceder a las propiedades de los niveles de puntos de datos. Este artículo demuestra cómo puede acceder y aplicar color a los puntos de datos en un gráfico.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}