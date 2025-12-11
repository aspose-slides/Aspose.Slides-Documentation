---
title: Рабочее решение проблемы изменения размера диаграммы в PPTX
type: docs
weight: 60
url: /ru/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- изменение размера диаграммы
- диаграмма Excel
- OLE-объект
- встраивание диаграммы
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Исправьте неожиданное изменение размера диаграмм в PPTX при использовании встроенных OLE-объектов Excel с Aspose.Slides для C++. Узнайте два метода с кодом, позволяющие сохранять размеры неизменными."
---

## **Фон**

Было замечено, что диаграммы Excel, встроенные как OLE‑объекты в презентацию PowerPoint через компоненты Aspose, масштабируются до неопределённого размера после их первой активации. Это поведение приводит к заметному визуальному различию в презентации между состоянием диаграммы до и после активации. Команда Aspose подробно исследовала проблему и нашла решение. В этой статье описаны причины проблемы и соответствующее исправление.

В [previous article](/slides/ru/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) мы объяснили, как создать диаграмму Excel с помощью Aspose.Cells for C++ и встроить её в презентацию PowerPoint с помощью Aspose.Slides for C++. Чтобы решить [object preview issue](/slides/ru/cpp/object-preview-issue-when-adding-oleobjectframe/), мы присвоили изображение диаграммы OLE‑объекту кадра диаграммы. В результирующей презентации, когда вы дважды щёлкните OLE‑объект кадра, отображающий изображение диаграммы, диаграмма Excel активируется. Конечные пользователи могут вносить любые желаемые изменения в подлежащую книгу Excel, а затем вернуться к соответствующему слайду, щёлкнув вне активированной книги. Размер OLE‑объекта кадра изменяется, когда пользователь возвращается к слайду, и коэффициент изменения размера варьируется в зависимости от исходных размеров как OLE‑объекта кадра, так и встроенной книги Excel.

## **Причина изменения размера**

Поскольку у книги Excel есть собственный размер окна, она пытается сохранить исходный размер при первой активации. OLE‑объект кадра, однако, имеет свой размер. По данным Microsoft, когда книга Excel активируется, Excel и PowerPoint согласовывают размер и поддерживают правильные пропорции как часть процесса встраивания. В зависимости от различий между размером окна Excel и размером или положением OLE‑объекта кадра происходит изменение размера.

## **Рабочее решение**

Существует два возможных сценария создания презентаций PowerPoint с использованием Aspose.Slides for C++.

**Сценарий 1:** Создание презентации на основе существующего шаблона.

**Сценарий 2:** Создание презентации с нуля.

Решение, которое мы предоставляем здесь, применимо к обоим сценариям. Основа всех подходов к решению одинакова: **Размер окна встроенного OLE‑объекта должен соответствовать размеру OLE‑объекта кадра в слайде PowerPoint**. Теперь мы обсудим два подхода к этому решению.

## **Первый подход**

В этом подходе мы научимся задавать размер окна встроенной книги Excel так, чтобы он соответствовал размеру OLE‑объекта кадра в слайде PowerPoint.

**Сценарий 1**

Предположим, что мы определили шаблон и хотим создавать презентации на его основе. Считаем, что в шаблоне есть фигура с индексом 2, в которой мы хотим разместить OLE‑кадр, содержащий встроенную книгу Excel. В этом сценарии размер OLE‑объекта кадра предопределён — он соответствует размеру фигуры с индексом 2 в шаблоне. Всё, что нам нужно сделать, — задать размер окна книги, равный размеру этой фигуры. Следующий фрагмент кода служит этой цели:
```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// Определить размер диаграммы с окном. 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// Установить ширину окна книги в дюймах (делить на 72, так как PowerPoint использует 72 пикселя на дюйм).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// Установить высоту окна книги в дюймах.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Сохранить книгу в поток памяти.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Create an OLE object frame with the embedded Excel data.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```


**Сценарий 2**

Допустим, мы хотим создать презентацию с нуля и включить OLE‑кадр любого размера с встроенной книгой Excel. В следующем фрагменте кода мы создаём OLE‑кадр высотой 4 дюйма и шириной 9,5 дюйма в точке x = 0,5 дюйма и y = 1 дюйм на слайде. Затем мы задаём окно книги Excel того же размера — 4 дюйма в высоту и 9,5 дюйма в ширину.
```cpp
// Желаемая высота.
int32_t desiredHeight = 288; // 4 дюйма (4 * 72)

// Желаемая ширина.
int32_t desiredWidth = 684; // 9.5 дюйма (9.5 * 72)

// Задаем размер диаграммы с окном. 
chart->SetSizeWithWindow(true);

// Устанавливаем ширину окна книги в дюймах.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// Устанавливаем высоту окна книги в дюймах.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Сохраняем книгу в поток памяти.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Создаём OLE‑кадр с встраиваемыми данными Excel.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```


## **Второй подход**

В этом подходе мы научимся задавать размер диаграммы во встроенной книге Excel так, чтобы он соответствовал размеру OLE‑объекта кадра в слайде PowerPoint. Этот подход полезен, когда размер диаграммы известен заранее и никогда не меняется.

**Сценарий 1**

Предположим, что мы определили шаблон и хотим создавать презентации на его основе. Считаем, что в шаблоне есть фигура с индексом 2, в которой мы планируем разместить OLE‑кадр, содержащий встроенную книгу Excel. В этом сценарии размер OLE‑кадра предопределён — он соответствует размеру фигуры с индексом 2 в шаблоне. Всё, что нам нужно сделать, — задать размер диаграммы в книге, равный размеру этой фигуры. Следующий фрагмент кода служит этой цели:
```cpp
// Задайте размер диаграммы без окна. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// Установите ширину диаграммы в пикселях (умножьте на 96, так как Excel использует 96 пикселей на дюйм).    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// Установите высоту диаграммы в пикселях.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Задайте размер печати диаграммы.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Сохраните книгу в поток памяти.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Создайте OLE‑кадр с встроенными данными Excel.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```


**Сценарий 2**

Предположим, мы хотим создать презентацию с нуля и включить OLE‑кадр любого размера с встроенной книгой Excel. В следующем фрагменте кода мы создаём OLE‑кадр высотой 4 дюйма и шириной 9,5 дюйма на слайде в точке x = 0,5 дюйма и y = 1 дюйм. Мы также задаём соответствующий размер диаграммы тем же самым: высоту 4 дюйма и ширину 9,5 дюйма.
```cpp
// Желаемая высота.
int32_t desiredHeight = 288; // 4 дюйма (4 * 576)

// Желаемая ширина.
int32_t desiredWidth = 684; // 9.5 дюйма(9.5 * 576)

// Задайте размер диаграммы без окна. 
chart->SetSizeWithWindow(false);

// Установите ширину диаграммы в пикселях.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// Установите высоту диаграммы в пикселях.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Сохраните книгу в поток памяти.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Создайте OLE‑кадр с встроенными данными Excel.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```


## **Заключение**

Существует два подхода к устранению проблемы изменения размера диаграммы. Выбор подхода зависит от требований и сценария использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или с нуля. Кроме того, в этом решении нет ограничения по размеру OLE‑объекта кадра.

## **FAQ**

**Почему моя встроенная диаграмма Excel меняет размер после активации в PowerPoint?**

Это происходит потому, что Excel пытается восстановить исходный размер окна при первой активации, тогда как OLE‑кадр в PowerPoint имеет свои размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что может вызвать изменение размера.

**Можно ли полностью исключить эту проблему изменения размера?**

Да. Сопоставив размер окна книги Excel или размер диаграммы с размером OLE‑кадра перед встраиванием, вы можете поддерживать постоянный размер диаграмм.

**Какой подход следует выбрать — задавать размер окна книги или размер диаграммы?**

Используйте **Подход 1 (размер окна)**, если хотите сохранить соотношение сторон книги и, возможно, позже разрешить изменение размера.
Используйте **Подход 2 (размер диаграммы)**, если размеры диаграммы фиксированы и не изменятся после встраивания.

**Будут ли эти методы работать как с шаблонными презентациями, так и с новыми презентациями?**

Да. Оба подхода работают одинаково для презентаций, созданных из шаблонов, и для презентаций, созданных с нуля.

**Есть ли ограничение по размеру OLE‑кадра?**

Нет. Вы можете задать OLE‑кадр любого размера, при условии, что он масштабируется соответственно к размеру книги или диаграммы.

**Можно ли использовать эти методы с диаграммами, созданными в других табличных программах?**

Примеры созданы для диаграмм Excel, созданных с помощью Aspose.Cells, но принципы применимы к другим OLE‑совместимым табличным программам, если они поддерживают аналогичные параметры размера.

## **Связанные разделы**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ru/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)