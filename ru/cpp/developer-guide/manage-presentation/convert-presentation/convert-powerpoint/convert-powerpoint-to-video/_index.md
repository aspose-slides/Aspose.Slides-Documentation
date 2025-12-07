---
title: Конвертация презентаций PowerPoint в видео на C++
linktitle: PowerPoint в видео
type: docs
weight: 130
url: /ru/cpp/convert-powerpoint-to-video/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в видео
- презентация в видео
- PPT в видео
- PPTX в видео
- PowerPoint в MP4
- презентация в MP4
- PPT в MP4
- PPTX в MP4
- сохранить PPT как MP4
- сохранить PPTX как MP4
- экспортировать PPT в MP4
- экспортировать PPTX в MP4
- конвертация видео
- PowerPoint
- C++
- Aspose.Slides
description: "Узнайте, как конвертировать презентации PowerPoint в видео на C++. Откройте образцы кода и техники автоматизации для оптимизации вашего рабочего процесса."
---

## **Обзор**

Преобразуя вашу презентацию PowerPoint в видео, вы получаете  

* **Повышенная доступность:** Все устройства (независимо от платформы) по умолчанию оснащены видеоплеерами, в отличие от приложений для открытия презентаций, поэтому пользователям проще открывать или воспроизводить видео.  
* **Более широкая аудитория:** С помощью видео вы можете охватить большую аудиторию и донести информацию, которая иначе могла бы показаться скучной в презентации. Большинство опросов и статистических данных свидетельствуют, что люди смотрят и потребляют видео чаще, чем другие формы контента, и обычно предпочитают именно его.  

В [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/) мы реализовали поддержку конвертации презентаций в видео.  

* Используйте Aspose.Slides для генерации набора кадров (из слайдов презентации), соответствующего заданному FPS (кадров в секунду)  
* Используйте стороннюю утилиту, например `ffmpeg`, для создания видео на основе этих кадров.  

## **Конвертировать презентацию PowerPoint в видео**

1. Скачайте ffmpeg [здесь](https://ffmpeg.org/download.html).  
2. Добавьте путь к `ffmpeg.exe` в переменную окружения `PATH`.  
3. Запустите код преобразования PowerPoint в видео.  

Следующий код C++ показывает, как конвертировать презентацию (с фигурой и двумя анимационными эффектами) в видео:  
```c++
void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Добавляет форму смайлика и затем анимирует её
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);
    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```


## **Эффекты видео**

Вы можете применять анимацию к объектам на слайдах и использовать переходы между слайдами.  

{{% alert color="primary" %}}  

Возможно, вам стоит посмотреть эти статьи: [PowerPoint Animation](https://docs.aspose.com/slides/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/cpp/shape-animation/), и [Shape Effect](https://docs.aspose.com/slides/cpp/shape-effect/).  

{{% /alert %}}  

Анимации и переходы делают слайд-шоу более увлекательными и интересными — и то же самое происходит с видео. Добавим еще один слайд и переход в код предыдущей презентации:  
```c++
// Добавляет форму смайлика и анимирует её

// ...

// Добавляет новый слайд и анимированный переход

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```


Aspose.Slides также поддерживает анимацию текста. Мы анимируем абзацы на объектах, которые будут появляться один за другим (с задержкой в одну секунду):  
```c++
void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Добавляет текст и анимации
    System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210.0f, 120.0f, 300.0f, 300.0f);
    System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
    para1->get_Portions()->Add(System::MakeObject<Portion>(u"Aspose Slides for C++"));
    System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
    para2->get_Portions()->Add(System::MakeObject<Portion>(u"convert PowerPoint Presentation with text to video"));

    System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
    para3->get_Portions()->Add(System::MakeObject<Portion>(u"paragraph by paragraph"));
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Add(para1);
    paragraphs->Add(para2);
    paragraphs->Add(para3);
    paragraphs->Add(System::MakeObject<Paragraph>());

    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effect = sequence->AddEffect(para1, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect2 = sequence->AddEffect(para2, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect3 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect4 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    effect->get_Timing()->set_TriggerDelayTime(1.0f);
    effect2->get_Timing()->set_TriggerDelayTime(1.0f);
    effect3->get_Timing()->set_TriggerDelayTime(1.0f);
    effect4->get_Timing()->set_TriggerDelayTime(1.0f);

    // Преобразует кадры в видео
    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);
    
    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```


## **Классы конвертации видео**

Чтобы вы могли выполнять задачи по конвертации PowerPoint в видео, Aspose.Slides предоставляет классы [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) и [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/).  

PresentationAnimationsGenerator позволяет задать размер кадра для будущего видео через конструктор. Если передать экземпляр презентации, будет использовано `Presentation.SlideSize`, и он генерирует анимации, которые использует [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/).  

При генерации анимаций генерируется событие `NewAnimation` для каждой последующей анимации, которому передаётся параметр [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/). Этот параметр — класс, представляющий плеер отдельной анимации.  

Для работы с [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/) используются свойство [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (полная длительность анимации) и метод [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). Каждая позиция анимации задаётся в диапазоне *0 — duration*, после чего метод `GetFrame` возвращает Bitmap, соответствующий состоянию анимации в данный момент.  
```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // начальное состояние анимации
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // битмап начального состояния анимации

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // конечное состояние анимации
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // последний кадр анимации
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Добавляет форму смайлика и анимирует её
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    animationsGenerator->NewAnimation += OnNewAnimation;
}
```


Чтобы все анимации в презентации воспроизводились одновременно, используется класс [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/). Этот класс принимает экземпляр [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) и FPS для эффектов в конструкторе, а затем вызывает событие `FrameTick` для всех анимаций, чтобы они воспроизводились:  
```c++
void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>(u"animated.pptx");
    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, 33);

    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());
}
```


Затем сгенерированные кадры можно собрать в видео. См. раздел [Convert PowerPoint to Video](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).  

## **Поддерживаемые анимации и эффекты**

**Вход**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Появление** | ![not supported](x.png) | ![supported](v.png) |
| **Затухание** | ![supported](v.png) | ![supported](v.png) |
| **Полет внутрь** | ![supported](v.png) | ![supported](v.png) |
| **Плавное появление** | ![supported](v.png) | ![supported](v.png) |
| **Разделение** | ![supported](v.png) | ![supported](v.png) |
| **Смахивание** | ![supported](v.png) | ![supported](v.png) |
| **Форма** | ![supported](v.png) | ![supported](v.png) |
| **Колесо** | ![supported](v.png) | ![supported](v.png) |
| **Случайные полосы** | ![supported](v.png) | ![supported](v.png) |
| **Увеличение и поворот** | ![not supported](x.png) | ![supported](v.png) |
| **Увеличение** | ![supported](v.png) | ![supported](v.png) |
| **Вращение** | ![supported](v.png) | ![supported](v.png) |
| **Отскок** | ![supported](v.png) | ![supported](v.png) |

**Акцент**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Пульсация** | ![not supported](x.png) | ![supported](v.png) |
| **Цветовая пульсация** | ![not supported](x.png) | ![supported](v.png) |
| **Качание** | ![supported](v.png) | ![supported](v.png) |
| **Вращение** | ![supported](v.png) | ![supported](v.png) |
| **Увеличение/Уменьшение** | ![not supported](x.png) | ![supported](v.png) |
| **Обесцвечивание** | ![not supported](x.png) | ![supported](v.png) |
| **Затемнение** | ![not supported](x.png) | ![supported](v.png) |
| **Осветление** | ![not supported](x.png) | ![supported](v.png) |
| **Прозрачность** | ![not supported](x.png) | ![supported](v.png) |
| **Цвет объекта** | ![not supported](x.png) | ![supported](v.png) |
| **Дополнительный цвет** | ![not supported](x.png) | ![supported](v.png) |
| **Цвет линии** | ![not supported](x.png) | ![supported](v.png) |
| **Цвет заливки** | ![not supported](x.png) | ![supported](v.png) |

**Выход**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Исчезновение** | ![not supported](x.png) | ![supported](v.png) |
| **Затухание** | ![supported](v.png) | ![supported](v.png) |
| **Полет наружу** | ![supported](v.png) | ![supported](v.png) |
| **Плавное исчезновение** | ![supported](v.png) | ![supported](v.png) |
| **Разделение** | ![supported](v.png) | ![supported](v.png) |
| **Смахивание** | ![supported](v.png) | ![supported](v.png) |
| **Форма** | ![supported](v.png) | ![supported](v.png) |
| **Случайные полосы** | ![supported](v.png) | ![supported](v.png) |
| **Уменьшение и поворот** | ![not supported](x.png) | ![supported](v.png) |
| **Увеличение** | ![supported](v.png) | ![supported](v.png) |
| **Вращение** | ![supported](v.png) | ![supported](v.png) |
| **Отскок** | ![supported](v.png) | ![supported](v.png) |

**Пути движения**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Линии** | ![supported](v.png) | ![supported](v.png) |
| **Дуги** | ![supported](v.png) | ![supported](v.png) |
| **Повороты** | ![supported](v.png) | ![supported](v.png) |
| **Фигуры** | ![supported](v.png) | ![supported](v.png) |
| **Циклы** | ![supported](v.png) | ![supported](v.png) |
| **Пользовательский путь** | ![supported](v.png) | ![supported](v.png) |

## **Часто задаваемые вопросы**

**Можно ли конвертировать презентации, защищённые паролем?**

Да, Aspose.Slides позволяет работать с [презентациями, защищёнными паролем](/slides/ru/cpp/password-protected-presentation/). При обработке таких файлов необходимо предоставить правильный пароль, чтобы библиотека могла получить доступ к содержимому презентации.

**Поддерживает ли Aspose.Slides использование в облачных решениях?**

Да, Aspose.Slides можно интегрировать в облачные приложения и сервисы. Библиотека разработана для работы в серверных окружениях, обеспечивая высокую производительность и масштабируемость при пакетной обработке файлов.

**Существуют ли ограничения по размеру презентаций при конвертации?**

Aspose.Slides способна обрабатывать презентации практически любого размера. Однако при работе с очень большими файлами могут потребоваться дополнительные системные ресурсы, и иногда рекомендуется оптимизировать презентацию для повышения производительности.