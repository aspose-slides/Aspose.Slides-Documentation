---
title: Видеокадр
type: docs
weight: 10
url: /cpp/video-frame/
keywords: "Добавить видео, создать видеокадр, извлечь видео, презентация PowerPoint, C++, CPP, Aspose.Slides для C++"
description: "Добавить видеокадр в презентацию PowerPoint на C++"

---

Правильно размещенное видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлеченности аудитории.

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (сохраненное на вашем компьютере)
* Добавить онлайн-видео (из веб-источника, такого как YouTube).

Чтобы вы могли добавлять видео (видеообъекты) в презентацию, Aspose.Slides предоставляет интерфейсы [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) и [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) и другие соответствующие типы.

## **Создать встроенный видеокадр**

Если видеофайл, который вы хотите добавить на свой слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в вашу презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд через его индекс.
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) и передайте путь к видеофайлу, чтобы встроить видео в презентацию.
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) для создания кадра для видео.
1. Сохраните измененную презентацию.

Этот код на C++ показывает, как добавить видео, хранящееся локально, в презентацию:

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

Кроме того, вы можете добавить видео, передав его путь к файлу напрямую в метод [AddVideoFrame()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/):

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **Создать видеокадр с видео из веб-источника**

Microsoft [PowerPoint 2013 и новее](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает видео с YouTube в презентациях. Если видео, которое вы хотите использовать, доступно онлайн (например, на YouTube), вы можете добавить его в свою презентацию через его веб-ссылку.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд через его индекс.
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) и передайте ссылку на видео.
1. Установите миниатюру для видеокадра.
1. Сохраните презентацию.

Этот код на C++ показывает, как добавить видео из сети на слайд в презентации PowerPoint:

```c++
// Путь к каталогу документов.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Создает объект Presentation, представляющий файл презентации
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает доступ к первому слайду
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Добавляет видеокадр
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240, u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Устанавливает режим воспроизведения и громкость видео
vf->set_PlayMode(VideoPlayModePreset::Auto);

// Сохраняет презентацию на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Извлечь видео из слайда**

Кроме добавления видео на слайды, Aspose.Slides позволяет извлекать видео, встроенные в презентации.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), чтобы загрузить презентацию, содержащую видео.
2. Переберите все объекты [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/).
3. Переберите все объекты [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), чтобы найти [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/).
4. Сохраните видео на диск.

Этот код на C++ показывает, как извлечь видео из слайда презентации:

```c++
// Путь к каталогу документов.
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