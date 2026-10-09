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
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для C++. Быстрое руководство."
---
## **Введение**

Видео может помочь объяснить идеи и заинтересовать аудиторию. Aspose.Slides for C++ позволяет добавлять видеокадры на слайды, настраивать параметры воспроизведения, управлять субтитрами и извлекать встроенные видеоданные.

PowerPoint поддерживает локальные видео и ссылки на онлайн‑видео, такие как видео с YouTube.

Для представления видеоданных и видеокадров Aspose.Slides предоставляет интерфейсы [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) и [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/), а также другие соответствующие типы.

## **Создание встроенного видеокадра**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию.

В этом примере локальное видео встраивается на первый слайд существующей презентации и сохраняется результат. Координаты и размеры кадра указаны в пунктах. Поток остаётся открытым до завершения сохранения, потому что [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) удерживает его заблокированным, пока презентация использует его.

```cpp
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <Export/SaveFormat.h>
#include <LoadingStreamBehavior.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto videoStream = File::OpenRead(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::KeepLocked);
slide->get_Shapes()->AddVideoFrame(10, 10, 150, 250, video);

presentation->Save(u"embedded_video.pptx", SaveFormat::Pptx);

presentation->Dispose();
videoStream->Dispose();
```

Вы также можете передать путь к локальному видео напрямую в [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/). В этом примере видео встраивается на первый слайд новой презентации. Видео должно оставаться доступным до сохранения презентации.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

slide->get_Shapes()->AddVideoFrame(50, 150, 300, 150, u"video.avi");

presentation->Save(u"video_from_path.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Создание видеокадра с видео из веб‑источника**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) поддерживает онлайн‑видео в презентациях. Вы можете создать видеокадр, который ссылается на онлайн‑видео, например видео с YouTube.

В этом примере добавляется ссылка на видео YouTube и миниатюра на первый слайд. Замените идентификатор видео, чтобы использовать другое видео. Метод [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) запрашивает автоматическое воспроизведение. Загрузка миниатюры и воспроизведение видео требуют доступа к интернету. Средство просмотра презентаций также должно поддерживать онлайн‑воспроизведение видео.

```cpp
#include <net/web_client.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/VideoPlayModePreset.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);


auto webClient = MakeObject<System::Net::WebClient>();

String videoId = u"aqz-KE-bpKQ";
auto videoUrl = String::Format(u"https://www.youtube.com/embed/{0}", videoId);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

auto thumbnailUrl = String::Format(u"https://img.youtube.com/vi/{0}/hqdefault.jpg", videoId);
auto thumbnailData = webClient->DownloadData(thumbnailUrl);
auto thumbnail = presentation->get_Images()->AddImage(thumbnailData);
videoFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"online_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Воспроизведение видео в полноэкранном режиме**

В учебной презентации вы можете воспроизводить демонстрацию программного обеспечения в полноэкранном режиме, чтобы аудитория могла видеть детали. [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) принимает `true`, чтобы включить это поведение во время воспроизведения.

В этом примере открывается презентация, находится первый [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) на первом слайде и включается полноэкранное воспроизведение. Входная презентация должна содержать как минимум один слайд с существующим видеокадром на первом слайде.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_FullScreenMode(true);
        break;
    }
}

presentation->Save(u"full_screen_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Полноэкранное воспроизведение управляет тем, как отображается видео. Отдельно, [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) определяет, будет ли оно запускаться автоматически или по щелчку, а [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) определяет, будет ли оно повторяться. Чтобы выбрать поведение запуска, установите режим воспроизведения в [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/). Пример сохраняет существующие настройки запуска и зацикливания.

## **Перемотка видео после воспроизведения**

В учебной презентации возврат демонстрационного видео в начало делает его готовым к повторному воспроизведению. Вызовите [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) с `true`, чтобы вернуть видео в начало после завершения воспроизведения.

В этом примере открывается презентация, находится первый [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) на первом слайде и включается перемотка. Отключается зацикливание, чтобы воспроизведение могло завершиться, и устанавливается запуск воспроизведения по щелчку. Входная презентация должна содержать как минимум один слайд с существующим видеокадром на первом слайде.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <DOM/VideoPlayModePreset.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_RewindVideo(true);
        videoFrame->set_PlayLoopMode(false);
        videoFrame->set_PlayMode(VideoPlayModePreset::OnClick);
        break;
    }
}

presentation->Save(u"rewind_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Перемотка возвращает видео в начало без повторного запуска. В отличие от этого, включение [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) повторяет воспроизведение автоматически. Оставляйте зацикливание отключённым, когда нужно, чтобы видео завершилось и было готово к повторному воспроизведению. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) независимо управляет автоматическим или щелчковым запуском; в этом примере используется [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/), чтобы ведущий контролировал момент начала воспроизведения. Устанавливайте режим воспроизведения после настройки зацикливания, как показано в примере. Перемотка работает независимо от [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/).

## **Обрезка видеокадра**

Используйте [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) и [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/), чтобы пропустить часть начала или конца видео во время воспроизведения. Оба значения указаны в миллисекундах. Обрезка изменяет настройки воспроизведения без изменения встроенных видеоданных.

**Настройка обрезки**

В этом примере встраивается локальное видео и при воспроизведении пропускаются первые 2,5 секунды и последняя секунда. Используйте видео длительностью более 3,5 секунды, чтобы оставался воспроизводимый фрагмент.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);
videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Чтение настроек обрезки**

В этом примере выводятся значения обрезки первого видеокадра на первом слайде в миллисекундах. Презентация должна содержать как минимум один слайд. Если на этом слайде нет видеокадра, ничего не выводится. Предыдущий пример выдаёт значения 2500 и 1000.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        Console::WriteLine(String::Format(u"Trim from start: {0} ms", videoFrame->get_TrimFromStart()));
        Console::WriteLine(String::Format(u"Trim from end: {0} ms", videoFrame->get_TrimFromEnd()));
        break;
    }
}

presentation->Dispose();
```

## **Управление субтитрами видео**

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через метод [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Добавление субтитров к видеокадру**

В этом примере встраивается локальное видео и добавляется дорожка субтитров WebVTT с меткой English. Метки времени субтитров должны соответствовать видео. Сохранённая презентация содержит как видео, так и его субтитры.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Интерфейс [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) также предоставляет перегрузку, позволяющую добавить субтитры из потока.

**Извлечение субтитров из видеокадра**

В этом примере сохраняются все дорожки субтитров из видеокадров на первом слайде как отдельные файлы WebVTT. Последовательные номера позволяют различать файлы вывода. Консоль сообщает количество извлечённых дорожек. Презентация должна содержать как минимум один слайд.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto trackCount = 0;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : IterateOver(videoFrame->get_CaptionTracks()))
        {
            trackCount++;
            auto outputPath = String::Format(u"captions_{0}.vtt", trackCount);
            File::WriteAllBytes(outputPath, captionTrack->get_BinaryData());
        }
    }
}

Console::WriteLine(String::Format(u"Caption tracks extracted: {0}", trackCount));

presentation->Dispose();
```

Каждый объект [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) раскрывает идентификатор субтитров, метку, бинарные данные и текст субтитров как строку UTF-8.

**Удаление субтитров из видеокадра**

В этом примере удаляются все субтитры из видеокадра, находящегося в первой позиции фигуры на первом слайде, и сохраняется результат. Предполагается, что слайд и фигура существуют и что фигура является видеокадром.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Если необходимо удалить только одну дорожку субтитров, используйте методы [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) или [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/), вместо [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/).

## **Извлечение видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентацию видео.

В этом примере извлекаются встроенные видео со всех слайдов в отдельные нумерованные бинарные файлы. Связанные видео пропускаются, так как они не содержат встроенных данных. Консоль выводит MIME‑тип каждого видео и общее количество. Вывод использует общее расширение `.bin`; при необходимости измените его в соответствие с указанным типом медиа.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IVideo.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation_with_videos.pptx");

auto videoCount = 0;
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            auto videoFrame = ExplicitCast<IVideoFrame>(shape);
            auto video = videoFrame->get_EmbeddedVideo();
            if (video == nullptr)
            {
                Console::WriteLine(u"Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            auto outputPath = String::Format(u"extracted_video_{0}.bin", videoCount);
            File::WriteAllBytes(outputPath, video->get_BinaryData());
            Console::WriteLine(String::Format(u"Video {0}: {1}", videoCount, video->get_ContentType()));
        }
    }
}

Console::WriteLine(String::Format(u"Embedded videos extracted: {0}", videoCount));

presentation->Dispose();
```

## **FAQ**

**Какие параметры воспроизведения видео можно изменить для видеокадра?**

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (авто или по щелчку) и [зацикливанием](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/). Эти параметры доступны через методы объекта [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео бинарные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При ссылке на онлайн‑видео и добавлении миниатюры презентация сохраняет только ссылку и изображение превью, а не данные видео, поэтому увеличение размера обычно меньше.

**Можно ли заменить видео в существующем видеокадре без изменения его положения и размеров?**

Да. Вы можете заменить [видео контент](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) внутри кадра, сохраняя геометрию фигуры; это распространённый сценарий обновления медиа в существующей раскладке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/), который можно прочитать и использовать, например при сохранении на диск.