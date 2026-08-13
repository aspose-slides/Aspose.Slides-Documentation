---
title: Применение анимаций фигур в презентациях с использованием C++
linktitle: Анимация фигур
type: docs
weight: 60
url: /ru/cpp/shape-animation/
keywords:
- фигура
- анимация
- эффект
- анимированная фигура
- анимированный текст
- добавить анимацию
- получить анимацию
- извлечь анимацию
- добавить эффект
- получить эффект
- извлечь эффект
- звук эффекта
- применить анимацию
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как создавать и настраивать анимации фигур в презентациях PowerPoint с помощью Aspose.Slides для C++. Выделяйтесь!"
---
## **Введение**

Анимации — это визуальные эффекты, которые могут быть применены к текстам, изображениям, фигурам или [диаграмм](/slides/ru/cpp/animated-charts/). Они придают жизнь презентациям или их компонентам. 

## **Зачем использовать анимацию в презентациях?**

Используя анимацию, вы можете 

* контролировать поток информации
* выделять важные моменты
* повышать интерес или вовлечённость аудитории
* делать контент легче читаемым, усваиваемым или обрабатываемым
* привлекать внимание читателей или зрителей к важным частям презентации

PowerPoint предоставляет множество вариантов и инструментов для анимаций и эффектов анимации в категориях **вход**, **выход**, **акцент** и **траектории движения**. 

## **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями, в пространстве имён [Aspose.Slides.Animation](https://reference.aspose.com/slides/ru/cpp/namespace/aspose.slides.animation),
* Aspose.Slides предоставляет более **150 эффектов анимации** в перечислении [EffectType](https://reference.aspose.com/slides/ru/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Эти эффекты в сущности те же (или эквивалентные), которые используются в PowerPoint.

## **Применить анимацию к TextBox**

Aspose.Slides для C++ позволяет применять анимацию к тексту в фигуре. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_auto_shape). 
4. Добавьте текст в [IAutoShape.TextFrame](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Получите основную последовательность эффектов.
6. Добавьте эффект анимации к [IAutoShape](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_auto_shape). 
7. Установите свойство [TextAnimation.BuildType](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) в значение из [перечисления BuildType](https://reference.aspose.com/slides/ru/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Сохраните презентацию на диск в формате PPTX.

Этот код C++ показывает, как применить эффект `Fade` к AutoShape и установить анимацию текста со значением *By 1st Level Paragraphs*:

```c++
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Instantiates a presentation class that represents a presentation file.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Adds new AutoShape with text
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Adds Fade animation effect to shape
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animates shape text by 1st level paragraphs
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Save the PPTX file to disk
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}} 

Помимо применения анимаций к тексту, вы также можете применять анимации к отдельному [Paragraph](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_paragraph). См. [**Animated Text**](/slides/ru/cpp/animated-text/).

{{% /alert %}} 

## **Применить анимацию к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_picture_frame) на слайде. 
4. Получите основную последовательность эффектов.
5. Добавьте эффект анимации к [PictureFrame](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_picture_frame).
6. Сохраните презентацию на диск в формате PPTX.

Этот код C++ показывает, как применить эффект `Fly` к picture frame:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Создает экземпляр класса презентации, представляющего файл презентации.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Загрузить изображение, которое будет добавлено в коллекцию изображений презентации
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Добавляет рамку изображения на слайд
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Получает основную последовательность слайда.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Добавляет анимационный эффект Fly from Left к рамке изображения.
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Сохраняет файл PPTX на диск
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Применить анимацию к Shape**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_auto_shape). 
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_auto_shape) (при щелчке по этому объекту анимация воспроизводится).
5. Создайте последовательность эффектов для формы Bevel.
6. Создайте пользовательский `UserPath`.
7. Добавьте команды перемещения к `UserPath`.
8. Сохраните презентацию на диск в формате PPTX.

Этот код C++ показывает, как применить эффект `PathFootball` (path football) к фигуре:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionEffect.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

	// Путь к каталогу документов.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Загружает презентацию
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Получает первый слайд
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Получает коллекцию фигур выбранного слайда
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Создаёт эффект PathFootball для существующей фигуры с нуля.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Добавляет анимационный эффект PathFootball
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Создаёт некую "кнопку".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Создаёт последовательность эффектов для этой кнопки.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Создаёт пользовательский путь. Наш объект будет перемещён только после щелчка по кнопке.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Добавляет команды перемещения, так как созданный путь пуст.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 // Записывает файл PPTX на диск
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Получить эффекты анимации, применённые к Shape**

В следующих примерах показано, как использовать метод `GetEffectsByShape` из интерфейса [ISequence](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/isequence/) для получения всех эффектов анимации, применённых к фигуре.

**Пример 1: Получить эффекты анимации, применённые к фигуре на обычном слайде**

Ранее вы узнали, как добавлять эффекты анимации к фигурам в презентациях PowerPoint. Следующий пример кода демонстрирует, как получить эффекты, применённые к первой фигуре на первом обычном слайде презентации `AnimExample_out.pptx`.

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Получает основную последовательность анимации слайда.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Получает первую фигуру на первом слайде.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Получает эффекты анимации, применённые к фигуре.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**Пример 2: Получить все эффекты анимации, включая унаследованные из заполнительных объектов**

Если фигура на обычном слайде имеет заполнители, расположенные на слайде‑макете и/или слайде‑шаблоне, и к этим заполнителям добавлены эффекты анимации, то все эффекты фигуры будут воспроизводиться во время показа слайдов, включая унаследованные из заполнителей.

Предположим, у нас есть файл презентации PowerPoint `sample.pptx` с одним слайдом, содержащим только форму нижнего колонтитула с текстом «Made with Aspose.Slides», к которой применён эффект **Random Bars**.

![Эффект анимации формы на слайде](slide-shape-animation.png)

Также предположим, что эффект **Split** применён к заполнителю нижнего колонтитула на слайде **layout**.

![Эффект анимации формы макета](layout-shape-animation.png)

И, наконец, эффект **Fly In** применён к заполнителю нижнего колонтитула на слайде **master**.

![Эффект анимации формы мастера](master-shape-animation.png)

Следующий пример кода демонстрирует, как использовать метод `GetBasePlaceholder` из интерфейса [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/) для доступа к заполнителям фигур и получения эффектов анимации, применённых к форме нижнего колонтитула, включая унаследованные из заполнителей, расположенных на слайдах‑макете и мастере.

```cpp
#include <DOM/Animation/IEffect.h>
#include <system/array.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};
```
```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Получить эффекты анимации фигуры на обычном слайде.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Получить эффекты анимации заполнителя на слайде макета.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Получить эффекты анимации заполнителя на слайде мастера.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Полет, снизу
Type: 134, subtype: 45            // Разделить, вертикальное появление
Type: 126, subtype: 22            // Случайные полосы, горизонтальные
```

## **Изменить свойства тайминга эффекта анимации**

Aspose.Slides для C++ позволяет изменять свойства Timing (времени) эффекта анимации.

Это панель Animation Timing в Microsoft PowerPoint:

![Панель анимации тайминга](shape-animation.png)

Это соответствия между PowerPoint Timing и свойствами [Effect.Timing](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- Выпадающий список **Start** в PowerPoint Timing соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- **Duration** в PowerPoint Timing соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). Длительность анимации (в секундах) — это общее время, необходимое анимации для завершения одного цикла. 
- **Delay** в PowerPoint Timing соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

Так изменяются свойства Effect Timing:

1. Примените ([Apply](#apply-animation-to-shape)) или получите эффект анимации.
2. Установите новые значения нужных свойств [Effect.Timing](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c).
3. Сохраните изменённый файл PPTX.

```c++
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Создаёт экземпляр класса презентации, представляющего файл презентации.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Получает основную последовательность слайда.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Получает первый эффект основной последовательности.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Изменяет свойство TriggerType эффекта, чтобы запускался по щелчку
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Изменяет длительность эффекта
effect->get_Timing()->set_Duration(3.f);

// Изменяет время задержки TriggerDelayTime эффекта
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Сохраняет файл PPTX на диск
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Звук эффекта анимации**

Aspose.Slides предоставляет следующие свойства для работы со звуками в эффектах анимации: 

- [set_Sound()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Добавить звук к эффекту анимации**

Этот код C++ демонстрирует, как добавить звук к эффекту анимации и остановить его, когда начинается следующий эффект:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System::IO;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Добавляет аудио в коллекцию аудио презентации
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Получает основную последовательность слайда.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Получает первый эффект основной последовательности
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Проверяет эффект на отсутствие звука
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Добавляет звук к первому эффекту
    firstEffect->set_Sound(effectSound);
}

// Получает первую интерактивную последовательность слайда.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Устанавливает флаг эффекта «Остановить предыдущий звук»
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Сохраняет файл PPTX на диск
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Извлечь звук эффекта анимации**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу. 
3. Получите основную последовательность эффектов. 
4. Извлеките встроенный в каждый эффект анимации [set_Sound()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/effect/set_sound/). 

Этот код C++ показывает, как извлечь звук, встроенный в эффект анимации:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Создаёт экземпляр класса презентации, представляющего файл презентации.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **После анимации**

Aspose.Slides для C++ позволяет изменять свойство After animation (после анимации) эффекта анимации.

Это панель Animation Effect и расширенное меню в Microsoft PowerPoint:

![Панель эффекта анимации и расширенное меню](shape-after-animation.png)

Выпадающий список **After animation** в PowerPoint Effect соответствует следующим свойствам: 

- Свойство [set_AfterAnimationType()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) описывающее тип After animation:
  * В PowerPoint **More Colors** соответствует типу [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/afteranimationtype/) ;
  * В PowerPoint **Don't Dim** соответствует типу [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/afteranimationtype/) (тип по умолчанию);
  * В PowerPoint **Hide After Animation** соответствует типу [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/afteranimationtype/) ;
  * В PowerPoint **Hide on Next Mouse Click** соответствует типу [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/afteranimationtype/) ;
- Свойство [set_AfterAnimationColor()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) определяющее формат цвета после анимации. Оно работает совместно с типом [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/afteranimationtype/). При изменении типа на другой цвет после анимации будет очищен.

```c++
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IColorFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// Создаёт экземпляр класса презентации, представляющего файл презентации
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Получает первый эффект основной последовательности
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Изменяет тип анимации после на Color
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Устанавливает цвет затемнения после анимации
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Сохраняет файл PPTX на диск
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Анимация текста**

Aspose.Slides предоставляет следующие свойства для работы с блоком *Animate text* эффекта анимации:

- Свойство [set_AnimateTextType()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) описывающее тип анимации текста эффекта. Текст фигуры может анимироваться:
  - Всё сразу ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/animatetexttype/) тип)
  - По словам ([AnimateTextType.ByWord](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/animatetexttype/) тип)
  - По буквам ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/animatetexttype/) тип)
- Свойство [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) задаёт задержку между анимированными частями текста (словами или буквами). Положительное значение указывает процент от длительности эффекта. Отрицательное значение указывает задержку в секундах.

Так можно изменить свойства Effect Animate text:

1. Примените ([Apply](#apply-animation-to-shape)) или получите эффект анимации.
2. Установите свойство [set_BuildType()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itextanimation/set_buildtype/) в значение [BuildType.AsOneObject](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/buildtype/) чтобы отключить режим анимации *By Paragraphs*.
3. Установите новые значения свойств [set_AnimateTextType()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) и [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).
4. Сохраните изменённый файл PPTX.

```c++
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// Создаёт экземпляр класса презентации, представляющего файл презентации.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Получает первый эффект основной последовательности
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Изменяет тип анимации текста эффекта на «Как один объект»
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Изменяет тип анимации текста эффекта на «По слову»
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Устанавливает задержку между словами в 20% длительности эффекта
firstEffect->set_DelayBetweenTextParts(20.0f);

// Сохраняет файл PPTX на диск
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **Часто задаваемые вопросы**

### Как обеспечить сохранение анимаций при публикации презентации в веб?

Используйте [Export to HTML5](/slides/ru/cpp/export-to-html5/) и включите [options](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/html5options/), отвечающие за анимацию [shape](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/html5options/set_animateshapes/) и [transition](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/html5options/set_animatetransitions/). Обычный HTML не воспроизводит анимацию слайдов, тогда как HTML5 — воспроизводит.

### Как изменение порядка z‑order (порядка слоёв) фигур влияет на анимацию?

Порядок анимации и порядок отрисовки независимы: эффект управляет временем и типом появления/исчезновения, тогда как [z-order](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shape/get_zorderposition/) определяет, что что покрывает. Видимый результат определяется их комбинацией. (Это общее поведение PowerPoint; модель эффектов и фигур Aspose.Slides следует той же логике.)

### Есть ли ограничения при конвертации анимаций в видео для некоторых эффектов?

Как правило, [animations are supported](/slides/ru/cpp/convert-powerpoint-to-video/), но в редких случаях или для отдельных эффектов результат может отличаться. Рекомендуется протестировать используемые эффекты и версию библиотеки.