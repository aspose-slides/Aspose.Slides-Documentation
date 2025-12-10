---
title: Управление маркерами данных диаграмм в презентациях с использованием C++
linktitle: Маркер данных
type: docs
url: /ru/cpp/chart-data-marker/
keywords:
- диаграмма
- точка данных
- маркер
- опции маркера
- размер маркера
- тип заливки
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как настраивать маркеры данных диаграмм в Aspose.Slides для C++, повышая эффективность презентаций в форматах PPT и PPTX с помощью наглядных примеров кода на C++."
---

## **Установка маркеров диаграммы**
Aspose.Slides for C++ предоставляет простой API для автоматической установки маркера серии диаграммы. В следующей функции каждая серия диаграммы будет автоматически получать различный маркер по умолчанию.

Пример кода ниже показывает, как автоматически установить маркер серии диаграммы.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}


## **Параметры маркеров диаграммы**
Маркеры можно устанавливать для точек данных диаграммы внутри определенной серии. Чтобы задать параметры маркеров диаграммы, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
- Создайте диаграмму по умолчанию.
- Установите изображение.
- Получите первую серию диаграммы.
- Добавьте новую точку данных.
- Сохраните презентацию на диск.

В приведённом ниже примере мы задали параметры маркеров диаграммы на уровне точек данных.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}


## **Установка маркеров диаграммы на уровне точек данных серии**
Теперь маркеры можно устанавливать для точек данных диаграммы внутри определенной серии. Чтобы задать параметры маркеров диаграммы, выполните следующие шаги:

- Создайте экземпляр класса Presentation .
- Создайте диаграмму по умолчанию.
- Установите изображение.
- Получите первую серию диаграммы.
- Добавьте новую точку данных.
- Сохраните презентацию на диск.

В приведённом ниже примере мы задали параметры маркеров диаграммы на уровне точек данных.
```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Создать экземпляр класса Presentation, представляющего файл PPTX
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Доступ к первому слайду
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Добавить диаграмму с данными по умолчанию
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Setting the index of chart data sheet
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Delete default generated series and categories
chart->get_ChartData()->get_Series()->Clear();

// Now, Adding a new series
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Get the picture
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Add image to presentation's images collection
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Add new point (1:3) there.
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

// Changing the chart series marker
series->get_Marker()->set_Size(15);

// Write the presentation file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```


## **Применение цвета к точкам данных**
Вы можете применять цвет к точкам данных диаграммы с помощью Aspose.Slides for C++. [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager) и **[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level)** классы были добавлены для доступа к свойствам уровней точек данных. В этой статье показано, как получить доступ к точкам данных диаграммы и применить к ним цвет.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **Вопросы и ответы**

**Какие формы маркеров доступны сразу же?**

Доступны стандартные формы (круг, квадрат, ромб, треугольник и т.д.); список определяется перечислением [MarkerStyleType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/markerstyletype/) . Если вам нужна нестандартная форма, используйте маркер с заливкой изображением, чтобы имитировать пользовательские визуальные элементы.

**Сохраняются ли маркеры при экспорте диаграммы в изображение или SVG?**

Да. При рендеринге диаграмм в [растр форматы](/slides/ru/cpp/convert-powerpoint-to-png/) или сохранении [форм в SVG](/slides/ru/cpp/render-a-slide-as-an-svg-image/) маркеры сохраняют свой внешний вид и настройки, включая размер, заливку и контур.