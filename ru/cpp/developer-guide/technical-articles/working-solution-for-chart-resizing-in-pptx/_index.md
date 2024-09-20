---
title: Рабочее решение для изменения размеров диаграмм в PPTX
type: docs
weight: 60
url: /cpp/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

Наблюдается, что диаграммы Excel, встроенные в презентацию PowerPoint в виде OLE через компоненты Aspose, изменяются до неидентифицированного масштаба после первого активации. Это поведение создает значительное визуальное отличие презентации между состояниями до и после активации диаграммы. Команда Aspose с помощью команды Microsoft подробно расследовала эту проблему и нашла решение. Эта статья охватывает причины и решение данной проблемы. 

{{% /alert %}} 
## **Предыстория**
В [предыдущей статье](https://docs.aspose.com/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) мы объяснили, как создать диаграмму Excel с использованием Aspose.Cells для C++ и далее встроить эту диаграмму в презентацию PowerPoint с использованием Aspose.Slides для C++. Чтобы учесть проблему изменения объекта, мы назначили изображение диаграммы для OLE-объекта-рамки диаграммы. В выходной презентации, когда мы дважды щелкаем на OLE-рамку, показывающую изображение диаграммы, диаграмма Excel активируется. Конечные пользователи могут вносить любые желаемые изменения в фактическую рабочую книгу Excel, а затем вернуться к соответствующему слайду, щелкнув вне активной рабочей книги Excel. Размер OLE-рамки изменится, когда пользователь вернется к слайду. Фактор изменения размеров будет отличаться для различных размеров OLE-рамки и встроенной рабочей книги Excel.

## **Причина изменения размеров**
Поскольку рабочая книга Excel имеет свой собственный размер окна, она пытается сохранить свой первоначальный размер во время первого активации. С другой стороны, OLE-рамка будет иметь свой собственный размер. Согласно данным Microsoft, при активации рабочей книги Excel Excel и PowerPoint согласовывают размер и обеспечивают его правильные пропорции в рамках операции встраивания. На основе различий в размере окон Excel и размерах / позиции OLE-рамки происходит изменение размеров. 

## **Рабочее решение**
Существуют два возможных сценария создания презентаций PowerPoint с использованием Aspose.Slides для C++. 

**Сценарий 1:** Создать презентацию на основе существующего шаблона.

**Сценарий 2:** Создать презентацию с нуля. 

Решение, которое мы предоставим здесь, будет действовать для обоих сценариев. Основой всех подходов к решению будет одно и то же: **Размер окна встроенного OLE-объекта должен быть таким же, как и у OLE-рамки** **в слайде PowerPoint**. Теперь мы обсудим два подхода к решению. 

## **Первый подход**
В этом подходе мы узнаем, как установить размер окна встроенной рабочей книги Excel, равный размеру OLE-рамки в слайде PowerPoint. 

**Сценарий 1** 

Допустим, мы определили шаблон и желаем создать презентации на основе этого шаблона. Предположим, что в шаблоне есть какая-то фигура на индексе 2, где мы хотим разместить OLE-рамку с встроенной рабочей книгой Excel. В этом сценарии размер OLE-рамки будет считаться предопределенным (это размер фигуры на индексе 2 в шаблоне). Все, что нам нужно сделать: установить размер окна рабочей книги, равный размеру фигуры. Следующий фрагмент кода будет служить этой цели: 

``` cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

``` cpp
// определить размер диаграммы с окном 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shapes()->idx_get(2);

// установить ширину окна рабочей книги в дюймах (разделить на 72, так как PowerPoint использует 
// 72 пикселя / дюйм)
wb->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// установить высоту окна рабочей книги в дюймах
wb->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Инициализировать MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream3(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Создать OLE-рамку с встроенной Excel
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	shape->get_X(), 
	shape->get_Y(), 
	shape->get_Width(), 
	shape->get_Height(),
	dataInfo);
```

**Сценарий 2** 

Допустим, мы хотим создать презентацию с нуля и желаем OLE-рамку любого размера с встроенной рабочей книгой Excel. В следующем фрагменте кода мы создали OLE-рамку высотой 4 дюйма и шириной 9,5 дюйма в слайде по оси x=0,5 дюйма и оси y=1 дюйм. Далее мы установили эквивалентный размер окна рабочей книги Excel, т.е.: высота 4 дюйма и ширина 9,5 дюйма. 

``` cpp
// Наша желаемая высота
int32_t desiredHeight = 288; // 4 дюйма (4 * 72)

// Наша желаемая ширина
int32_t desiredWidth = 684; // 9,5 дюйма (9,5 * 72)

// определить размер диаграммы с окном 
chart->SetSizeWithWindow(true);

// установить ширину окна рабочей книги в дюймах
wb->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// установить высоту окна рабочей книги в дюймах
wb->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Инициализировать MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Создать OLE-рамку с встроенной Excel
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	36.0f,
	72.0f, 
	desiredWidth, 
	desiredHeight,
	dataInfo);
```


## **Второй подход**
В этом подходе мы узнаем, как установить размер диаграммы, находящейся в встроенной рабочей книге Excel, равным размеру OLE-рамки в слайде PowerPoint. Этот подход полезен, когда размер диаграммы заранее известен и никогда не изменится. 

**Сценарий 1** 

Допустим, мы определили шаблон и желаем создать презентации на основе этого шаблона. Предположим, что в шаблоне есть какая-то фигура на индексе 2, где мы хотим разместить OLE-рамку с встроенной рабочей книгой Excel. В этом сценарии размер OLE-рамки будет считаться предопределенным (это размер фигуры на индексе 2 в шаблоне). Все, что нам нужно сделать: установить размер диаграммы в рабочей книге, равный размеру фигуры. Следующий фрагмент кода будет служить этой цели: 

``` cpp
// определить размер диаграммы без окна 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shapes()->idx_get(2);

// установить ширину диаграммы в пикселях (умножить на 96, так как Excel использует 96 пикселей на дюйм)    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// установить высоту диаграммы в пикселях
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Определить размер печати диаграммы
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Инициализировать MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Создать OLE-рамку с встроенной Excel
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	shape->get_X(), 
	shape->get_Y(), 
	shape->get_Width(),
	shape->get_Height(),
	dataInfo);
```

**Сценарий 2** 

Допустим, мы хотим создать презентацию с нуля и желаем OLE-рамку любого размера с встроенной рабочей книгой Excel. В следующем фрагменте кода мы создали OLE-рамку высотой 4 дюйма и шириной 9,5 дюйма в слайде по оси x=0,5 дюйма и оси y=1 дюйм. Далее мы установили эквивалентный размер диаграммы, т.е.: высота 4 дюйма и ширина 9,5 дюйма. 

``` cpp
// Наша желаемая высота
int32_t desiredHeight = 288; // 4 дюйма (4 * 576)

// Наша желаемая ширина
int32_t desiredWidth = 684; // 9,5 дюйма(9,5 * 576)

// определить размер диаграммы без окна 
chart->SetSizeWithWindow(false);

// установить ширину диаграммы в пикселях    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// установить высоту диаграммы в пикселях    
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Инициализировать MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Создать OLE-рамку с встроенной Excel
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	36.0f, 
	72.0f, 
	desiredWidth, 
	desiredHeight,
	dataInfo);
```

## **Заключение**
{{% alert color="primary" %}} 

Существует два подхода для решения проблемы изменения размера диаграмм. Выбор подходящего подхода зависит от требований и конкретного случая использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации на основе шаблона или с нуля. Также в решении нет ограничений по размеру OLE-рамки. 

{{% /alert %}} 
## **Связанные разделы**
[Создание и встраивание диаграммы Excel в виде OLE-объекта в презентации](https://docs.aspose.com/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)