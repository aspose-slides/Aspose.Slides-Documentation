---
title: Управление аудио в презентациях с помощью C++
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
description: "Создавайте и управляйте аудио‑кадрами в Aspose.Slides для C++ — примеры кода для встраивания, обрезки, зацикливания и настройки воспроизведения в презентациях PPT, PPTX и ODP."
---

## **Создание аудио‑кадров**

Aspose.Slides for C++ позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды в виде аудио‑кадров. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который вы хотите встроить в слайд.
4. Добавьте встроенный аудио‑кадр (содержащий аудиофайл) на слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) и `Volume`, предоставляемые объектом [IAudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_audio_frame).
6. Сохраните изменённую презентацию.

Этот код на C++ демонстрирует, как добавить встроенный аудио‑кадр на слайд:
``` cpp
// Создаёт экземпляр класса Presentation, который представляет файл презентации
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

Когда вы добавляете аудиофайл в презентацию, аудио отображается как кадр со стандартным изображением по умолчанию (см. изображение в разделе ниже). Вы можете изменить миниатюру аудио‑кадра (установить предпочитаемое изображение).

Этот код на C++ демонстрирует, как изменить миниатюру или изображение предварительного просмотра аудио‑кадра:
```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Добавляет аудио‑кадр на слайд с указанными позицией и размером.
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

Aspose.Slides for C++ позволяет изменять параметры, управляющие воспроизведением аудио или его свойствами. Например, вы можете регулировать громкость аудио, установить воспроизведение в цикле или даже скрыть значок аудио.

Панель **Audio Options** в Microsoft PowerPoint:
![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**, соответствующие методам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/) :
- **Start** выпадающий список соответствует методу [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playmode/) .
- **Volume** соответствует методу [AudioFrame::set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_volume/) .
- **Play Across Slides** соответствует методу [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playacrossslides/) .
- **Loop until Stopped** соответствует методу [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playloopmode/) .
- **Hide During Show** соответствует методу [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_hideatshowing/) .
- **Rewind after Playing** соответствует методу [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_rewindaudio/) .

Параметры **Editing** в PowerPoint, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/) :
- **Fade In** соответствует методу [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_fadeinduration/) .
- **Fade Out** соответствует методу [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_fadeoutduration/) .
- **Trim Audio Start Time** соответствует методу [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_trimfromstart/) .
- **Trim Audio End Time** значение равно длительности аудио за вычетом значения метода [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_trimfromend/) .

Элемент управления **Volume controll** в PowerPoint на панели управления аудио соответствует методу [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_volumevalue/) . Он позволяет менять громкость аудио в процентах.

Вот как изменить параметры воспроизведения аудио:
1. [Создать](#creating-audio-frame) или получить Audio Frame.
2. Установите новые значения свойств Audio Frame, которые нужно изменить.
3. Сохраните изменённый файл PowerPoint.

Этот код на C++ демонстрирует операцию, в которой параметры аудио корректируются:
``` cpp
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Получить форму
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Преобразует форму к типу AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Устанавливает режим воспроизведения для воспроизведения по щелчку
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Устанавливает громкость на Низкую
audioFrame->set_Volume(AudioVolumeMode::Low);

// Устанавливает воспроизведение аудио на всех слайдах
audioFrame->set_PlayAcrossSlides(true);

// Отключает зацикливание аудио
audioFrame->set_PlayLoopMode(false);

// Скрывает AudioFrame во время показа слайдов
audioFrame->set_HideAtShowing(true);

// Перематывает аудио к началу после воспроизведения
audioFrame->set_RewindAudio(true);

// Сохраняет файл PowerPoint на диск
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```


Этот пример на C++ показывает, как добавить новый аудио‑кадр со встроенным аудио, обрезать его и установить длительности затухания:
```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Устанавливает начальное смещение обрезки в 1,5 секунды
audioFrame->set_TrimFromStart(1500);
// Устанавливает конечное смещение обрезки в 2 секунды
audioFrame->set_TrimFromEnd(2000);

// Устанавливает длительность плавного появления в 200 мс
audioFrame->set_FadeInDuration(200);
// Устанавливает длительность плавного исчезновения в 500 мс
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```


Следующий пример кода демонстрирует, как получить аудио‑кадр со встроенным аудио и установить его громкость на 85 %:
```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Получает форму аудио‑кадра
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Устанавливает громкость аудио в 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```


## **Извлечение аудио**

Aspose.Slides позволяет извлекать звук, используемый в переходах слайд‑шоу. Например, вы можете извлечь звук, использованный в конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на соответствующий слайд по его индексу.
3. Получите доступ к переходам слайд‑шоу для этого слайда.
4. Извлеките звук в виде байтовых данных.

Этот код на C++ демонстрирует, как извлечь аудио, использованное в слайде:
``` cpp
String presName = u"AudioSlide.pptx";

// Создаёт экземпляр класса Presentation, представляющего файл презентации
auto pres = System::MakeObject<Presentation>(presName);

// Получает нужный слайд
auto slide = pres->get_Slides()->idx_get(0);

// Получает эффекты переходов слайд‑шоу для слайда
auto transition = slide->get_SlideShowTransition();

// Извлекает звук в массив байтов
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```


## **FAQ**

**Могу ли я использовать один и тот же аудио‑ресурс на нескольких слайдах без увеличения размера файла?**  
Да. Добавьте аудио один раз в общую [audio collection](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) презентации и создайте дополнительные аудио‑кадры, которые ссылаются на этот существующий ресурс. Это предотвращает дублирование медиаданных и позволяет держать размер презентации под контролем.

**Могу ли я заменить звук в существующем аудио‑кадре без пересоздания фигуры?**  
Да. Для связанного звука обновите [link path](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_linkpathlong/), указав путь к новому файлу. Для встроенного звука замените объект [embedded audio](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_embeddedaudio/) другим из [audio collection](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) презентации. Форматирование кадра и большинство параметров воспроизведения остаются неизменными.

**Изменяет ли обрезка исходные аудиоданные, хранящиеся в презентации?**  
Нет. Обрезка изменяет только границы воспроизведения. Исходные байты аудио остаются нетронутыми и доступны через встроенный аудио‑файл или [audio collection] презентации.