---
title: Сохранение презентаций в C++
linktitle: Сохранить презентацию
type: docs
weight: 80
url: /ru/cpp/save-presentation/
keywords:
- сохранить PowerPoint
- сохранить OpenDocument
- сохранить презентацию
- сохранить слайд
- сохранить PPT
- сохранить PPTX
- сохранить ODP
- презентация в файл
- презентация в поток
- предопределенный тип представления
- строгий формат Office Open XML
- режим Zip64
- обновление миниатюры
- прогресс сохранения
- C++
- Aspose.Slides
description: "Узнайте, как сохранять презентации в C++ с помощью Aspose.Slides — экспортировать в PowerPoint или OpenDocument, сохраняя макеты, шрифты и эффекты."
---

## **Обзор**

[Open Presentations in C++](/slides/ru/cpp/open-presentation/) описал, как использовать класс [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) для открытия презентации. Эта статья объясняет, как создавать и сохранять презентации. Класс [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) содержит содержимое презентации. Независимо от того, создаёте ли вы презентацию с нуля или изменяете существующую, вам понадобится сохранить её после завершения работы. С Aspose.Slides для C++ вы можете сохранять в **файл** или **поток**. Эта статья описывает различные способы сохранения презентации.

## **Сохранение презентаций в файлы**

Сохраните презентацию в файл, вызвав метод `Save` класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). Передайте в метод имя файла и формат сохранения. Ниже показан пример, как сохранить презентацию с помощью Aspose.Slides.
```cpp
// Создать экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Выполнить некоторую работу здесь...

// Сохранить презентацию в файл.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```


## **Сохранение презентаций в потоки**

Вы можете сохранить презентацию в поток, передав поток вывода методу `Save` класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). Презентацию можно записать во многие типы потоков. В примере ниже мы создаём новую презентацию и сохраняем её в файловый поток.
```cpp
// Создать экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Сохранить презентацию в поток.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```


## **Сохранение презентаций с предопределённым типом представления**

Aspose.Slides позволяет задать начальный вид, который PowerPoint использует при открытии сгенерированной презентации, с помощью класса [ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/). Используйте метод [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/set_lastview/) со значением из перечисления [ViewType](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/).
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Сохранение презентаций в строгом формате Office Open XML**

Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Используйте класс [PptxOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/) и задайте его свойство conformance при сохранении. Если установить `Conformance.Iso29500_2008_Strict`, выходной файл будет сохранён в строгом формате Office Open XML. Пример ниже создаёт презентацию и сохраняет её в строгом формате Office Open XML.
```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Создать экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Сохранить презентацию в строгом формате Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```


## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Файл Office Open XML представляет собой ZIP‑архив, накладывающий ограничения в 4 ГБ (2^32 байт) на несжатый размер любого файла, сжатый размер любого файла и общий размер архива, а также ограничивающий количество файлов в архиве до 65 535 (2^16‑1). Расширения формата ZIP64 повышают эти ограничения до 2^64. Метод [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) позволяет выбрать, когда использовать расширения формата ZIP64 при сохранении файла Office Open XML. Этот метод может использоваться со следующими режимами:
- `IfNecessary` использует расширения формата ZIP64 только если презентация превышает указанные выше ограничения. Это режим по умолчанию.
- `Never` никогда не использует расширения формата ZIP64.
- `Always` всегда использует расширения формата ZIP64. Следующий код демонстрирует, как сохранить презентацию как PPTX с включенными расширениями формата ZIP64:
```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```


{{% alert title="NOTE" color="warning" %}}
При сохранении с `Zip64Mode.Never` выбрасывается [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/), если презентацию невозможно сохранить в формате ZIP32.
{{% /alert %}}

## **Сохранение презентаций без обновления миниатюры**

Метод [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) управляет генерацией миниатюры при сохранении презентации в PPTX:
- Если установлено `true`, миниатюра обновляется во время сохранения. Это значение по умолчанию.
- Если установлено `false`, текущая миниатюра сохраняется. Если у презентации нет миниатюры, она не будет создаваться. В приведённом ниже коде презентация сохраняется в PPTX без обновления её миниатюры.
```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}
Эта опция помогает сократить время, необходимое для сохранения презентации в формате PPTX.
{{% /alert %}}

## **Обновления прогресса сохранения в процентах**

Интерфейс [IProgressCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iprogresscallback/) используется через метод `set_ProgressCallback`, предоставляемый интерфейсом [ISaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/isaveoptions/) и абстрактным классом [SaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/). Назначьте реализацию [IProgressCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iprogresscallback/) с помощью `set_ProgressCallback`, чтобы получать обновления прогресса сохранения в процентах. В следующих фрагментах кода показано, как использовать `IProgressCallback`.
```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // Используйте здесь значение процента выполнения.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```

```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}
Aspose разработала [бесплатное приложение PowerPoint Splitter](https://products.aspose.app/slides/splitter) с использованием собственного API. Приложение позволяет разбить презентацию на несколько файлов, сохранив выбранные слайды в новые файлы PPTX или PPT.
{{% /alert %}}

## **Часто задаваемые вопросы**

**Поддерживается ли «быстрое сохранение» (инкрементальное сохранение), при котором записываются только изменения?**

Нет. При сохранении каждый раз создаётся полный целевой файл; инкрементальное «быстрое сохранение» не поддерживается.

**Безопасно ли сохранять один и тот же объект Presentation из нескольких потоков?**

Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) [не является потокобезопасным](/slides/ru/cpp/multithreading/); сохраняйте его из одного потока.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении?**

[Гиперссылки](/slides/ru/cpp/manage-hyperlinks/) сохраняются. Внешние связанные файлы (например, видео по относительным путям) не копируются автоматически — убедитесь, что указанные пути остаются доступными.

**Можно ли задать/сохранить метаданные документа (Автор, Заголовок, Компания, Дата)?**

Да. Стандартные [свойства документа](/slides/ru/cpp/presentation-properties/) поддерживаются и будут записаны в файл при сохранении.