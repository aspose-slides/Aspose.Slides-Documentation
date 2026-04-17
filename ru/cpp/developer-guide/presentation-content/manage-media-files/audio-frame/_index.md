---
title: Управление аудио в презентациях с использованием C++
linktitle: Аудио‑кадр
type: docs
weight: 10
url: /ru/cpp/audio-frame/
keywords:
- аудио
- аудио‑кадр
- миниатюра
- добавить аудио
- свойства аудио
- параметры аудио
- извлечение аудио
- C++
- Aspose.Slides
description: "Создание и управление аудио‑кадрами в Aspose.Slides для C++ — примеры кода для встраивания, обрезки, зацикливания и настройки воспроизведения в презентациях PPT, PPTX и ODP."
---
## **Создание аудио‑кадров**

Aspose.Slides for C++ позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды в виде аудио‑кадров. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который хотите встроить в слайд.
4. Добавьте встроенный аудио‑кадр (содержащий аудиофайл) на слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/ru/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) и `Volume`, предоставляемые объектом [IAudioFrame](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_audio_frame).
6. Сохраните изменённую презентацию.

``` cpp
// Создаёт объект класса Presentation, представляющий файл презентации
auto pres = System::MakeObject<Presentation>();

// Получает первый слайд
auto sld = pres->get_Slides()->idx_get(0);

// Загружает wav‑файл звука в поток
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Добавляет аудио‑кадр
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Устанавливает режим воспроизведения и громкость аудио
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Записывает файл PowerPoint на диск
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Изменение миниатюры аудио‑кадра**

При добавлении аудиофайла в презентацию он отображается в виде кадра со стандартным изображением по умолчанию (см. изображение ниже). Вы можете изменить миниатюру аудио‑кадра, задав собственное изображение.

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Добавляет аудио‑кадр на слайд с указанным положением и размером.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Добавляет изображение в ресурсы презентации.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Устанавливает изображение для аудио‑кадра.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
//Сохраняет изменённую презентацию на диск
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Изменение параметров воспроизведения аудио**

Aspose.Slides for C++ позволяет менять параметры, контролирующие воспроизведение аудио или его свойства. Например, можно отрегулировать громкость, установить воспроизведение в цикле или скрыть значок аудио.

Панель **Audio Options** в Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**, соответствующие методам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/audioframe/):

- **Start** — выпадающий список соответствует методу [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/ru/cpp/aspose.slides/audioframe/set_playmode/).
- **Volume** — соответствует методу [AudioFrame::set_Volume](https://reference.aspose.com/slides/ru/cpp/aspose.slides/audioframe/set_volume/).
- **Play Across Slides** — соответствует методу [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/audioframe/set_playacrossslides/).
- **Loop until Stopped** — соответствует методу [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/ru/cpp/aspose.slides/audioframe/set_playloopmode/).
- **Hide During Show** — соответствует методу [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/ru/cpp/aspose.slides/audioframe/set_hideatshowing/).
- **Rewind after Playing** — соответствует методу [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/ru/cpp/aspose.slides/audioframe/set_rewindaudio/).

PowerPoint **Editing** options, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/audioframe/):

- **Fade In** — соответствует методу [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/ru/cpp/aspose.slides/audioframe/set_fadeinduration/).
- **Fade Out** — соответствует методу [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/ru/cpp/aspose.slides/audioframe/set_fadeoutduration/).
- **Trim Audio Start Time** — соответствует методу [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/ru/cpp/aspose.slides/audioframe/set_trimfromstart/).
- **Trim Audio End Time** — значение равно длительности аудио минус значение, задаваемое методом [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/ru/cpp/aspose.slides/audioframe/set_trimfromend/).

Ползунок **Volume** на панели управления аудио в PowerPoint соответствует методу [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/ru/cpp/aspose.slides/audioframe/set_volumevalue/). Он позволяет изменить громкость аудио в процентах.

Как изменить параметры воспроизведения аудио:

1. [Create](#creating-audio-frame) или получите аудио‑кадр.
2. Установите новые значения свойств аудио‑кадра, которые требуется изменить.
3. Сохраните изменённый файл PowerPoint.

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Получить форму
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Приводит форму к типу AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Устанавливает режим воспроизведения «по щелчку»
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Устанавливает громкость на низкую
audioFrame->set_Volume(AudioVolumeMode::Low);

// Делает аудио воспроизводимым на всех слайдах
audioFrame->set_PlayAcrossSlides(true);

// Отключает зацикливание для аудио
audioFrame->set_PlayLoopMode(false);

// Скрывает AudioFrame во время показа слайдов
audioFrame->set_HideAtShowing(true);

// Перематывает аудио к началу после воспроизведения
audioFrame->set_RewindAudio(true);

// Сохраняет файл PowerPoint на диск
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

Этот пример C++ показывает, как добавить новый аудио‑кадр с встроенным аудио, обрезать его и задать длительности затухания:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Sets the trimming start offset to 1.5 seconds
audioFrame->set_TrimFromStart(1500);
// Sets the trimming end offset to 2 seconds
audioFrame->set_TrimFromEnd(2000);

// Sets the fade-in duration to 200 ms
audioFrame->set_FadeInDuration(200);
// Sets the fade-out duration to 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

Следующий пример кода демонстрирует получение аудио‑кадра с встроенным аудио и установку громкости в 85 %:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Получает форму аудио-кадра
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Устанавливает громкость аудио на 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **Управление субтитрами аудио**

Aspose.Slides позволяет добавлять закрытые субтитры к аудио‑кадру через метод [get_CaptionTracks](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iaudioframe/get_captiontracks/). Этот метод возвращает объект [ICaptionsCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icaptionscollection/), который позволяет добавлять дорожки WebVTT, перебрать существующие дорожки и при необходимости удалять их.

**Добавление субтитров к аудио**

Используйте метод [get_CaptionTracks](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iaudioframe/get_captiontracks/) для привязки одной или нескольких дорожек к аудио‑кадру. В примере ниже аудиофайл добавляется на слайд, после чего новая дорожка субтитров загружается из файла `.vtt`.

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// Add a new caption track from a WebVTT file.
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Извлечение субтитров из аудио**

Можно пройтись по дорожкам субтитров, связанным с аудио‑кадром, и сохранить их как файлы `.vtt`. Каждая дорожка предоставляет свои двоичные данные и уникальный идентификатор, которые могут использоваться при экспорте субтитров.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IAudioFrame>(shape))
    {
        auto audioFrame = ExplicitCast<IAudioFrame>(shape);
        for (auto&& captionTrack : audioFrame->get_CaptionTracks())
        {
            // Сохранить каждую дорожку субтитров как файл .vtt.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

**Удаление субтитров из аудио**

Для удаления субтитров из аудио‑кадра используйте методы из [ICaptionsCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icaptionscollection/), такие как [Clear](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icaptionscollection/remove/), или [RemoveAt](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icaptionscollection/removeat/). Пример ниже удаляет все дорожки субтитров из аудио‑кадра.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// Удалить все дорожки субтитров из аудио‑кадра.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Извлечение аудио**
Aspose.Slides позволяет извлекать звук, используемый в переходах слайд‑шоу. Например, можно извлечь звук, используемый в конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на нужный слайд по его индексу.
3. Получите доступ к переходам слайд‑шоу для этого слайда.
4. Извлеките звук в виде массива байт.

``` cpp
String presName = u"AudioSlide.pptx";

// Создаёт объект класса Presentation, представляющий файл презентации
auto pres = System::MakeObject<Presentation>(presName);

// Получает нужный слайд
auto slide = pres->get_Slides()->idx_get(0);

// Получает эффекты перехода слайд‑шоу для слайда
auto transition = slide->get_SlideShowTransition();

// Извлекает звук в массив байт
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **FAQ**

**Можно ли использовать один и тот же аудио‑ресурс на нескольких слайдах без увеличения размера файла?**

Да. Добавьте аудио один раз в общую [audio collection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_audios/) презентации и создайте дополнительные аудио‑кадры, ссылающиеся на этот существующий ресурс. Это предотвращает дублирование медиа‑данных и удерживает размер презентации под контролем.

**Можно ли заменить звук в существующем аудио‑кадре, не создавая форму заново?**

Да. Для связанного звука обновите [link path](https://reference.aspose.com/slides/ru/cpp/aspose.slides/audioframe/set_linkpathlong/) до нового файла. Для встроенного звука замените объект [embedded audio](https://reference.aspose.com/slides/ru/cpp/aspose.slides/audioframe/set_embeddedaudio/) другим из [audio collection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_audios/) презентации. Формат кадра и большинство настроек воспроизведения сохранятся.

**Изменяется ли исходный аудио‑файл при обрезке?**

Нет. Обрезка меняет только границы воспроизведения. Исходные байты аудио остаются нетронутыми и доступны через встроенный аудио‑объект или коллекцию аудио презентации.