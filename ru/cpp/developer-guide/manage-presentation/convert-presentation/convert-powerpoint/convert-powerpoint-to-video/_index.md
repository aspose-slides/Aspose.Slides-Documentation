---
title: Конвертация PowerPoint в видео
type: docs
weight: 130
url: /cpp/convert-powerpoint-to-video/
keywords: "Конвертация PowerPoint, PPT, PPTX, Презентация, Видео, MP4, PPT в видео, PPT в MP4, C++, Aspose.Slides"
description: "Конвертация PowerPoint в видео с помощью Aspose.Slides для C++ API"
---

Преобразовав вашу презентацию PowerPoint в видео, вы получите 

* **Увеличение доступности:** Все устройства (независимо от платформы) по умолчанию оснащены видео плеерами по сравнению с приложениями для открытия презентаций, поэтому пользователям проще открывать или воспроизводить видео.
* **Большой охват:** С помощью видео вы можете достичь широкой аудитории и предоставить информацию, которая в противном случае могла бы показаться скучной в презентации. Большинство опросов и статистических данных показывают, что люди смотрят и потребляют видео чаще, чем другие формы контента, и вообще предпочитают такой контент.

## **Конвертация PowerPoint в видео с помощью Aspose.Slides**

В [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/) мы внедрили поддержку конвертации презентаций в видео.

* Используйте Aspose.Slides для создания набора кадров (из слайдов презентации), которые соответствуют определенному FPS (кадрам в секунду)
* Используйте стороннюю утилиту, такую как `ffmpeg`, чтобы создать видео на основе кадров.

### **Конвертация PowerPoint в видео**

1. Скачайте ffmpeg [здесь](https://ffmpeg.org/download.html).
2. Добавьте путь к `ffmpeg.exe` в переменную окружения `PATH`.
3. Запустите код для конвертации PowerPoint в видео.

Этот код на C++ показывает, как конвертировать презентацию (содержащую фигуру и два анимационных эффекта) в видео:

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

    // Добавляет фигуру смайлика и затем анимирует её
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

## **Видеоеффекты**

Вы можете применять анимации к объектам на слайдах и использовать переходы между слайдами.

{{% alert color="primary" %}} 

Вам также могут быть интересны эти статьи: [Анимация PowerPoint](https://docs.aspose.com/slides/cpp/powerpoint-animation/), [Анимация фигуры](https://docs.aspose.com/slides/cpp/shape-animation/), и [Эффект фигуры](https://docs.aspose.com/slides/cpp/shape-effect/).

{{% /alert %}} 

Анимации и переходы делают слайд-шоу более увлекательными и интересными — и они делают то же самое для видео. Давайте добавим другой слайд и переход в код для предыдущей презентации:

```c++
// Добавляет фигуру смайлика и анимирует её

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

Aspose.Slides также поддерживает анимацию для текстов. Поэтому мы анимируем абзацы на объектах, которые будут появляться один за другим (с задержкой, установленной на одну секунду):

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
    para1->get_Portions()->Add(System::MakeObject<Portion>(u"Aspose Slides для C++"));
    System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
    para2->get_Portions()->Add(System::MakeObject<Portion>(u"конвертация презентации PowerPoint с текстом в видео"));

    System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
    para3->get_Portions()->Add(System::MakeObject<Portion>(u"абзац за абзацем"));
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

    // Конвертирует кадры в видео
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

Чтобы позволить вам выполнять задачи конвертации PowerPoint в видео, Aspose.Slides предоставляет классы [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) и [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/).

PresentationAnimationsGenerator позволяет вам устанавливать размер кадра для видео (которое будет создано позже) через свой конструктор. Если вы передадите экземпляр презентации, будет использоваться `Presentation.SlideSize`, и он генерирует анимации, которые использует [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/).

Когда анимации генерируются, для каждой последующей анимации создается событие `NewAnimation`, которое имеет параметр [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/). Последний является классом, представляющим проигрыватель для отдельной анимации.

Чтобы работать с [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/), используются свойство [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (общее время анимации) и метод [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). Каждое положение анимации устанавливается в пределах диапазона *0 до продолжительности*, а затем метод `GetFrame` вернет Bitmap, который соответствует состоянию анимации в данный момент.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Общее время анимации: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // начальное состояние анимации
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // начальный кадр состояния анимации

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

    // Добавляет фигуру смайлика и анимирует её
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

Чтобы заставить все анимации в презентации воспроизводиться одновременно, используется класс [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/). Этот класс принимает экземпляр [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) и FPS для эффектов в своем конструкторе, а затем вызывает событие `FrameTick`, чтобы воспроизвести все анимации:

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

Затем сгенерированные кадры могут быть собраны для создания видео. См. раздел [Конвертация PowerPoint в видео](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Поддерживаемые анимации и эффекты**


**Вход**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Появление** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Затмение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Влет** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Вплытие** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Разделение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Стирание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Фигура** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Колесо** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Случайные полосы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Увеличение и поворот** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Масштабирование** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Крутить** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Деформация** | ![поддерживается](v.png) | ![поддерживается](v.png) |


**Упрощение**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Пульсация** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цветовая пульсация** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Качание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Вращение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Увеличение/уменьшение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Десатурация** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Затемнение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Освещение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Прозрачность** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цвет объекта** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Дополнительный цвет** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цвет линии** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цвет заливки** | ![не поддерживается](x.png) | ![поддерживается](v.png) |

**Выход**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Исчезновение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Затмение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Вылет** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Выплывание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Разделение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Стирание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Фигура** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Случайные полосы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Сжатие и поворот** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Масштабирование** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Крутить** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Деформация** | ![поддерживается](v.png) | ![поддерживается](v.png) |

**Движения по пути:**

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Линии** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Дуги** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Повороты** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Фигуры** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Циклы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Пользовательский путь** | ![поддерживается](v.png) | ![поддерживается](v.png) |