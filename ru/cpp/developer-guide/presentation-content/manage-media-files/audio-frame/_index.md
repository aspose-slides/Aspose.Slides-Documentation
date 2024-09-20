---
title: Аудио Кадр
type: docs
weight: 10
url: /cpp/audio-frame/
keywords: "Добавить аудио, Аудио кадр, Свойства аудио, Извлечь аудио, C++, CPP, Aspose.Slides для C++"
description: "Добавьте аудио в презентацию PowerPoint на C++"
---

## **Создание Аудио Кадра**
Aspose.Slides для C++ позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды в виде аудио кадров.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который вы хотите встроить в слайд.
4. Добавьте встроенный аудио кадр (содержащий аудиофайл) на слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) и `Volume`, предоставляемые объектом [IAudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_audio_frame).
6. Сохраните измененную презентацию.

Этот код на C++ демонстрирует, как добавить встроенный аудио кадр на слайд:

``` cpp
// Создает экземпляр класса Presentation, представляющего файл презентации
auto pres = System::MakeObject<Presentation>();

// Получает первый слайд
auto sld = pres->get_Slides()->idx_get(0);

// Загружает wav аудиофайл в поток
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Добавляет Аудио Кадр
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Устанавливает Режим Воспроизведения и Громкость Аудио
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Записывает файл PowerPoint на диск
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Изменение Эскиза Аудио Кадра**

Когда вы добавляете аудиофайл в презентацию, аудио отображается как кадр со стандартным изображением по умолчанию (см. изображение в разделе ниже). Вы можете изменить эскиз аудио кадра (установить свое предпочтительное изображение).

Этот код на C++ показывает, как изменить эскиз аудио кадра или изображение предварительного просмотра:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Добавляет аудио кадр на слайд с указанным положением и размером.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Добавляет изображение в ресурсы презентации.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Устанавливает изображение для аудио кадра.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
// Сохраняет измененную презентацию на диск
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Изменение Параметров Воспроизведения Аудио**

Aspose.Slides для C++ позволяет менять параметры, которые контролируют воспроизведение аудио или его свойства. Например, вы можете отрегулировать громкость аудио, установить его на воспроизведение в цикле или даже скрыть значок аудио.

Панель **Опции Аудио** в Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Опции Аудио в PowerPoint, соответствующие методам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame):
- Выпадающий список **Начало** опций Аудио соответствует методу [AudioFrame::get_PlayMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a5379c1a9c1166234d674b32413215a2b) 
- **Громкость** опций Аудио соответствует методу [AudioFrame::get_Volume()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#af06a3176684b6a13326bc8526747d9f3)  
- **Воспроизвести на слайдах** соответствует методу [AudioFrame::get_PlayAcrossSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a3c6ffc45b319ce127384fc37e188f7b0)  
- **Цикл до остановки** соответствует методу [AudioFrame::get_PlayLoopMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a99b5b9cc650e93eba813bd8b2371315b)  
- **Скрыть во время показа** соответствует методу [AudioFrame::get_HideAtShowing() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#abd008322e6a3d7d06bed527e329a9082)  
- **Перемотать после воспроизведения** соответствует методу [AudioFrame::get_RewindAudio() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a4900e1df6477db16e8cdd859ad54e637) 

Вот как вы изменяете параметры воспроизведения Аудио:

1. [Создайте](#создание-аудио-кадра) или получите Аудио Кадр.
2. Установите новые значения для свойств Аудио Кадра, которые хотите изменить.
3. Сохраните измененный файл PowerPoint.

Этот код на C++ демонстрирует операцию, в которой параметры аудио настраиваются:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Получает фигуру
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Приводит фигуру к форме AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Устанавливает режим воспроизведения на воспроизведение по клику
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Устанавливает громкость на Низкую
audioFrame->set_Volume(AudioVolumeMode::Low);

// Устанавливает аудио на воспроизведение на слайдах
audioFrame->set_PlayAcrossSlides(true);

// Отключает цикл для аудио
audioFrame->set_PlayLoopMode(false);

// Скрывает AudioFrame во время показа
audioFrame->set_HideAtShowing(true);

// Перематывает аудио на начало после воспроизведения
audioFrame->set_RewindAudio(true);

// Сохраняет файл PowerPoint на диск
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

## **Извлечение Аудио**
Aspose.Slides для .NET позволяет извлекать звук, используемый в переходах слайдов. Например, вы можете извлечь звук, используемый на конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на необходимый слайд по его индексу.
3. Получите доступ к переходам слайд-шоу для слайда.
4. Извлеките звук в байтовые данные.

Этот код на C++ показывает вам, как извлечь аудио, используемое на слайде:

``` cpp
String presName = u"AudioSlide.pptx";

// Создает экземпляр класса Presentation, представляющего файл презентации
auto pres = System::MakeObject<Presentation>(presName);

// Получает доступ к нужному слайду
auto slide = pres->get_Slides()->idx_get(0);

// Получает эффекты переходов слайд-шоу для слайда
auto transition = slide->get_SlideShowTransition();

// Извлекает звук в байтовом массиве
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Длина: ") + audio->get_Length());
```