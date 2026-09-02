---
title: Управление видеокадрами в презентациях с использованием C++
linktitle: Видеокадр
type: docs
weight: 10
url: /ru/cpp/video-frame/
keywords:
- добавить видео
- создать видео
- встроить видео
- извлечь видео
- получить видео
- видеокадр
- веб-источник
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Изучите, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для C++. Быстрое практическое руководство."
---
## **Введение**

Хорошо размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости аудитории. 

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы дать вам возможность добавлять видео (объекты video) в презентацию, Aspose.Slides предоставляет интерфейсы [IVideo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideo/) и [IVideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/), а также другие соответствующие типы. 

## **Создание встроенного видеокадра**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideo/) и передайте путь к файлу видео, чтобы встроить его в презентацию. 
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/) для создания кадра для видео.  
1. Сохраните изменённую презентацию. 

Этот C++‑код показывает, как добавить локально сохранённое видео в презентацию:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Загружает видео
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Получает первый слайд и добавляет видеокадр
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Сохраняет презентацию на диск
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

В качестве альтернативы вы можете добавить видео, передав путь к файлу напрямую методу [AddVideoFrame()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/addvideoframe/):

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```


## **Создание видеокадра с видео из веб‑источника**

Новые версии Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) поддерживают онлайн‑видео в презентациях. Если нужное вам видео доступно в сети (например, на YouTube), его можно добавить в презентацию по веб‑ссылке.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideo/) и передайте ссылку на видео.
1. Установите миниатюру для видеокадра. 
1. Сохраните презентацию. 

Этот C++‑код показывает, как добавить видео из сети на слайд в PowerPoint‑презентации:

```c++
// Путь к директории документов.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Создаёт объект Presentation, представляющий файл презентации
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает первый слайд
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Добавляет видеокадр 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Устанавливает режим воспроизведения и громкость видео
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Сохраняет презентацию на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Обрезка видеокадра**

Aspose.Slides позволяет управлять тем, какая часть видео воспроизводится, задавая параметры trim‑from‑start и trim‑from‑end через методы [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/set_trimfromstart/) и [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/set_trimfromend/). Оба значения указываются в миллисекундах и определяют, сколько времени пропускается в начале и в конце видео соответственно. Эти настройки изменяют параметры воспроизведения видео в презентации; они не обрезают и не меняют бинарные данные встроенного видео.

**Установить параметры обрезки**

Чтобы создать видеокадр и задать параметры обрезки:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideo/) в презентацию.
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/) на слайд.
1. Задайте значения trim‑from‑start и trim‑from‑end через методы [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/set_trimfromstart/) и [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/set_trimfromend/).
1. Сохраните изменённую презентацию.

Следующий пример кода пропускает первые 2,5 секунды и последнюю секунду встроенного видео при воспроизведении:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);

videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Чтение параметров обрезки**

Чтобы просмотреть существующие параметры обрезки, загрузите презентацию, найдите объект [IVideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/) среди фигур на первом слайде и считайте значения через методы [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/get_trimfromstart/) и [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/get_trimfromend/).

Следующий пример кода находит первый видеокадр на первом слайде и выводит его параметры обрезки в миллисекундах:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");

auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        auto trimFromStart = videoFrame->get_TrimFromStart();
        auto trimFromEnd = videoFrame->get_TrimFromEnd();

        Console::WriteLine(u"Trim from start: {0} ms", trimFromStart);
        Console::WriteLine(u"Trim from end: {0} ms", trimFromEnd);

        break;
    }
}

presentation->Dispose();
```

## **Управление субтитрами к видео**

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через метод [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Добавление субтитров к видеокадру**

Чтобы добавить субтитры к видеокадру:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Добавьте видео в презентацию.
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/) на слайд.
1. Используйте объект [ICaptionsCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icaptionscollection/), возвращаемый методом [get_CaptionTracks](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/get_captiontracks/), чтобы добавить дорожку субтитров в формате WebVTT.
1. Сохраните изменённую презентацию.

Следующий код показывает, как добавить субтитры к видеокадру:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Добавляет новую дорожку субтитров из файла WebVTT.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Интерфейс [ICaptionsCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icaptionscollection/) также предоставляет перегрузку, позволяющую добавлять субтитры из потока.

**Извлечение субтитров из видеокадра**

Чтобы извлечь субтитры из видеокадра:

1. Загрузите презентацию, содержащую видео.
1. Найдите нужный объект [IVideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/).
1. Пройдитесь по дорожкам субтитров, возвращаемым методом [get_CaptionTracks](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. Сохраните каждую дорожку субтитров в файл с расширением `.vtt`.

Следующий код демонстрирует извлечение субтитров из видеокадра:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : videoFrame->get_CaptionTracks())
        {
            // Сохраняет дорожку субтитров в файл WebVTT.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Каждый объект [ICaptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icaptions/) раскрывает идентификатор субтитров, метку, бинарные данные и текст субтитров в виде строки UTF‑8.

**Удаление субтитров из видеокадра**

Чтобы удалить субтитры из видеокадра:

1. Загрузите презентацию, содержащую видео.
1. Получите нужный объект [IVideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/).
1. Удалите дорожки субтитров из коллекции, возвращаемой методом [get_CaptionTracks](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. Сохраните изменённую презентацию.

Следующий код показывает, как удалить все субтитры из видеокадра:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Удаляет все субтитры из видеокадра.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Если нужно удалить только одну дорожку субтитров, используйте методы [Remove](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icaptionscollection/remove/) или [RemoveAt](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icaptionscollection/removeat/) вместо [Clear](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icaptionscollection/clear/).

## **Извлечение видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать видео, встроенные в презентации.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) для загрузки презентации, содержащей видео. 
2. Пройдитесь по всем объектам [ISlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/).
3. Пройдитесь по всем объектам [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/) в поисках [VideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/videoframe/). 
4. Сохраните видео на диск.

Этот C++‑код демонстрирует, как извлечь видео со слайда презентации:

```c++
// Путь к директории документов.
const System::String templatePath = u"../templates/Video.pptx";
const System::String outPath = u"../out/Video_out";

auto presentation = System::MakeObject<Presentation>(templatePath);
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (System::ObjectExt::Is<VideoFrame>(shape))
        {
            System::SharedPtr<VideoFrame> vf = System::AsCast<VideoFrame>(shape);
            System::String type = vf->get_EmbeddedVideo()->get_ContentType();
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            auto buffer = vf->get_EmbeddedVideo()->get_BinaryData();

            auto stream = System::MakeObject<System::IO::FileStream>(
                outPath + type, System::IO::FileMode::Create, System::IO::FileAccess::Write,
                System::IO::FileShare::Read);
            stream->Write(buffer, 0, buffer->get_Length());
        }
    }
}
```

## **FAQ**

**Какие параметры воспроизведения видео можно изменить для VideoFrame?**

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/ru/cpp/aspose.slides/videoframe/set_playmode/) (авто или по щелчку) и [циклическим воспроизведением](https://reference.aspose.com/slides/ru/cpp/aspose.slides/videoframe/set_playloopmode/). Эти возможности доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео его бинарные данные включаются в документ, поэтому размер презентации растёт пропорционально размеру файла. При добавлении онлайн‑видео в документ встраиваются только ссылка и миниатюра, поэтому увеличение размера меньше.

**Можно ли заменить видео в существующем VideoFrame, не меняя его положение и размер?**

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/ru/cpp/aspose.slides/videoframe/set_embeddedvideo/) внутри кадра, сохранив геометрию фигуры; это обычный сценарий обновления медиа в уже существующей раскладке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/ru/cpp/aspose.slides/video/get_contenttype/), который можно прочитать и использовать, например, при сохранении на диск.