---
title: Управление видеокадрами в презентациях с помощью C++
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
- веб‑источник
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Научитесь программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для C++. Быстрое руководство‑по‑использованию."
---

Правильно размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости аудитории. 

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы вы могли добавлять видео (виде‑объекты) в презентацию, Aspose.Slides предоставляет интерфейсы [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) и [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/), а также другие соответствующие типы. 

## **Создать встроенный видеокадр**

Если файл видео, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)class.  
1. Получите ссылку на слайд по его индексу.  
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) и передайте путь к файлу видео, чтобы встроить его в презентацию.  
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) для создания кадра видео.  
1. Сохраните изменённую презентацию.  

Этот код C++ показывает, как добавить локально хранящееся видео в презентацию:
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


В качестве альтернативы вы можете добавить видео, передав путь к файлу напрямую в метод [AddVideoFrame()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/):
``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```



## **Создать видеокадр с видео из веб‑источника**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает YouTube‑видео в презентациях. Если нужное вам видео доступно онлайн (например, на YouTube), вы можете добавить его в презентацию по веб‑ссылке. 

1. Создайте экземпляр [Presentation ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)class  
1. Получите ссылку на слайд по его индексу.  
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) и передайте ссылку на видео.  
1. Установите миниатюру для видеокадра.  
1. Сохраните презентацию.  

Этот код C++ показывает, как добавить видео из веба на слайд в презентацию PowerPoint:
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

//Sохраняет презентацию на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Извлечь видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентацию видео.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) для загрузки презентации, содержащей видео.  
2. Пройдите по всем объектам [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/).  
3. Пройдите по всем объектам [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) чтобы найти [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/).  
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

Вы можете управлять [playback mode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (авто или по щелчку) и [looping](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео бинарные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При добавлении онлайн‑видео встраивается ссылка и миниатюра, поэтому увеличение размера меньше.

**Могу ли я заменить видео в существующем VideoFrame, не меняя его положение и размер?**

Да. Вы можете заменить [video content](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) внутри кадра, сохранив геометрию фигуры; это распространённый сценарий обновления медиа в существующем макете.

**Можно ли определить тип контента (MIME) встроенного видео?**

Да. Встроенное видео имеет [content type](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/), который вы можете прочитать и использовать, например при сохранении на диск.