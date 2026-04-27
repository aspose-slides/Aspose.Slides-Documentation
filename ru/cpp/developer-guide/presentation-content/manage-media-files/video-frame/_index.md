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
- веб источник
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с использованием Aspose.Slides для C++. Быстрое руководство."
---
Хорошо размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости аудитории. 

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Для добавления видео (видео‑объектов) в презентацию Aspose.Slides предоставляет интерфейсы [IVideo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideo/) и [IVideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/), а также другие релевантные типы. 

## **Создание встроенного видеокадра**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу. 
3. Добавьте объект [IVideo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideo/) и передайте путь к видеофайлу, чтобы встроить видео в презентацию. 
4. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/) , чтобы создать кадр для видео.  
5. Сохраните изменённую презентацию. 

Этот код C++ показывает, как добавить локальное видео в презентацию:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Loads the video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Gets the first slide and adds a videoframe
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Saves the presentation to disk
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

В качестве альтернативы можно добавить видео, передав путь к файлу непосредственно методу [AddVideoFrame()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/addvideoframe/) :

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **Создание видеокадра с видео из веб‑источника**

Microsoft [PowerPoint 2013 и новее](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает видео YouTube в презентациях. Если нужное вам видео доступно онлайн (например, на YouTube), вы можете добавить его в презентацию по веб‑ссылке. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу. 
3. Добавьте объект [IVideo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideo/) и передайте ссылку на видео. 
4. Установите миниатюру для видеокадра. 
5. Сохраните презентацию. 

Этот код C++ показывает, как добавить видео из веба на слайд в презентации PowerPoint:

```c++
// Путь к директории документов.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Создаёт объект Presentation, представляющий файл презентации
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Доступ к первому слайду
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Добавляет видеокадр 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Устанавливает режим воспроизведения и громкость видео
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Сохраняет презентацию на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Управление субтитрами видео**

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через метод [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/get_captiontracks/) .

**Добавление субтитров к видеокадру**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) .
2. Добавьте видео в презентацию. 
3. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/) на слайд. 
4. Используйте возвращаемый [ICaptionsCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icaptionscollection/) через [get_CaptionTracks](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/get_captiontracks/) , чтобы добавить дорожку субтитров WebVTT. 
5. Сохраните изменённую презентацию. 

Следующий код показывает, как добавить субтитры к видеокадру:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Adds a new captions track from a WebVTT file.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Интерфейс [ICaptionsCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icaptionscollection/) также предоставляет перегрузку, позволяющую добавить субтитры из потока.

**Извлечение субтитров из видеокадра**

1. Загрузите презентацию, содержащую видео. 
2. Найдите целевой объект [IVideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/) . 
3. Пройдитесь по дорожкам субтитров, возвращаемым методом [get_CaptionTracks](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/get_captiontracks/) . 
4. Сохраните каждую дорожку субтитров в файл с расширением `.vtt` . 

Следующий код показывает, как извлечь субтитры из видеокадра:

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

Каждый объект [ICaptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icaptions/) предоставляет идентификатор субтитров, метку, двоичные данные и данные субтитров в виде строки UTF-8.

**Удаление субтитров из видеокадра**

1. Загрузите презентацию, содержащую видео. 
2. Получите целевой объект [IVideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/) . 
3. Удалите дорожки субтитров из коллекции, возвращаемой методом [get_CaptionTracks](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/get_captiontracks/) . 
4. Сохраните изменённую презентацию. 

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

Если необходимо удалить только одну дорожку субтитров, используйте методы [Remove](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icaptionscollection/remove/) или [RemoveAt](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icaptionscollection/removeat/) вместо [Clear](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icaptionscollection/clear/) .

## **Извлечение видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенное в презентацию видео.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) , чтобы загрузить презентацию, содержащую видео. 
2. Пройдитесь по всем объектам [ISlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/) . 
3. Пройдитесь по всем объектам [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/) , чтобы найти [VideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/videoframe/) . 
4. Сохраните видео на диск. 

Этот код C++ показывает, как извлечь видео со слайда презентации:

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

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/ru/cpp/aspose.slides/videoframe/set_playmode/) (авто или по щелчку) и [циклическим воспроизведением](https://reference.aspose.com/slides/ru/cpp/aspose.slides/videoframe/set_playloopmode/) . Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/videoframe/) .

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео двоичные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При добавлении онлайн‑видео встраиваются ссылка и миниатюра, поэтому рост размера меньше.

**Можно ли заменить видео в существующем VideoFrame, не изменяя его позицию и размер?**

Да. Вы можете заменить [содержимое видео](https://reference.aspose.com/slides/ru/cpp/aspose.slides/videoframe/set_embeddedvideo/) в кадре, сохранив геометрию формы; это распространённый сценарий обновления медиа в существующей раскладке.

**Можно ли определить тип контента (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип контента](https://reference.aspose.com/slides/ru/cpp/aspose.slides/video/get_contenttype/) , который можно прочитать и использовать, например при сохранении на диск.