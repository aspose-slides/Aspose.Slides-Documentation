---
title: Управление маркерами данных диаграммы в презентациях с использованием C++
linktitle: Маркер данных
type: docs
url: /ru/cpp/chart-data-marker/
keywords:
- диаграмма
- точка данных
- маркер
- параметры маркера
- размер маркера
- тип заливки
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как настроить маркеры данных диаграммы в Aspose.Slides для C++, повышая эффективность презентаций в форматах PPT и PPTX с помощью понятных примеров кода на C++."
---
## **Обзор**

Эта статья объясняет, как работать с маркерами данных диаграммы в Aspose.Slides. В ней показано, как создать диаграмму, получить доступ к серии и её точкам данных, применить заливку изображением к маркерам на уровне точек данных, изменить размер маркера и сохранить обновлённую презентацию. Также отмечается, что стандартные формы маркеров доступны через перечисление `MarkerStyleType`, и что внешний вид маркеров сохраняется при экспорте диаграмм в растровые форматы или SVG.

## **Установить маркеры диаграммы**
Aspose.Slides for C++ предоставляет простой API для автоматической установки маркера серии диаграммы. В следующей функции каждая серия диаграммы автоматически получит различный маркер по умолчанию.

Ниже приведён пример кода, показывающий, как автоматически установить маркер серии диаграммы.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Установить параметры маркера диаграммы**
Маркеры можно устанавливать на точках данных диаграммы внутри определённой серии. Чтобы задать параметры маркера диаграммы, выполните следующие действия:

- Instantiate [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) class.
- Creating the default chart.
- Set the picture.
- Take the first chart series.
- Add a new data point.
- Write a presentation to disk.

В приведённом ниже примере мы задали параметры маркера диаграммы на уровне точек данных.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Установить маркеры диаграммы на уровне точек данных серии**
Теперь маркеры можно устанавливать на точках данных диаграммы внутри определённой серии. Чтобы задать параметры маркера диаграммы, выполните следующие действия:

- Instantiate Presentation class.
- Creating the default chart.
- Set the picture.
- Take the first chart series.
- Add a new data point.
- Write a presentation to disk.

В приведённом ниже примере мы задали параметры маркера диаграммы на уровне точек данных.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Создать объект класса Presentation, представляющего файл PPTX
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Получить первый слайд
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Добавить диаграмму с данными по умолчанию
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Установка индекса листа данных диаграммы
int defaultWorksheetIndex = 0;

// Получение листа данных диаграммы
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Удалить сгенерированные по умолчанию серии и категории
chart->get_ChartData()->get_Series()->Clear();

// Теперь добавляем новую серию
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Получить изображение
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Добавить изображение в коллекцию изображений презентации
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Добавить новую точку (1:3) здесь.
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

// Изменение маркера серии диаграммы
series->get_Marker()->set_Size(15);

// Сохранить файл презентации на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **Применить цвет к точкам данных**
Вы можете применить цвет к точкам данных в диаграмме, используя Aspose.Slides for C++. [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) и **[IChartDataPointLevel](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatapointlevel/)** добавлены для доступа к свойствам уровней точек данных. Эта статья демонстрирует, как получить доступ к точкам данных диаграммы и применить к ним цвет.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **Часто задаваемые вопросы**

**Какие формы маркеров доступны из коробки?**

Стандартные формы доступны (круг, квадрат, ромб, треугольник и т.д.); список определяется перечислением [MarkerStyleType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/markerstyletype/). Если вам нужна нестандартная форма, используйте маркер с заливкой изображением, чтобы имитировать пользовательскую графику.

**Сохраняются ли маркеры при экспорте диаграммы в изображение или SVG?**

Да. При рендеринге диаграмм в [raster formats](/slides/ru/cpp/convert-powerpoint-to-png/) или сохранении [shapes as SVG](/slides/ru/cpp/render-a-slide-as-an-svg-image/), маркеры сохраняют свой внешний вид и настройки, включая размер, заливку и контур.