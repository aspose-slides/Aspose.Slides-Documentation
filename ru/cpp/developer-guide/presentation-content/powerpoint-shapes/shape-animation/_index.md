---
title: Применение анимации фигур в презентациях с помощью C++
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
description: "Узнайте, как создавать и настраивать анимацию фигур в презентациях PowerPoint с помощью Aspose.Slides для C++. Выделяйтесь!"
---

Анимации — это визуальные эффекты, которые можно применять к текстам, изображениям, фигурам или [диаграммам](/slides/ru/cpp/animated-charts/). Они придают жизнь презентациям или их составляющим. 

## **Зачем использовать анимации в презентациях?**

С помощью анимаций вы можете 

* контролировать поток информации
* выделять важные моменты
* повышать интерес или вовлечённость аудитории
* делать контент проще для чтения, восприятия или обработки
* привлекать внимание читателей или зрителей к важным частям презентации

PowerPoint предоставляет множество вариантов и инструментов для анимаций и анимационных эффектов в категориях **вход**, **выход**, **акцент** и **трассы движения**. 

## **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями в пространстве имён [Aspose.Slides.Animation](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation),
* Aspose.Slides предлагает более **150 анимационных эффектов** в перечислении [EffectType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Эти эффекты по сути совпадают (или эквивалентны) эффектам, используемым в PowerPoint.

## **Применение анимации к TextBox**

Aspose.Slides для C++ позволяет применять анимацию к тексту в фигуре. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) . 
4. Добавьте текст в [IAutoShape.TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) .
5. Получите основную последовательность эффектов.
6. Добавьте анимационный эффект к [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) . 
7. Установите свойство [TextAnimation.BuildType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) значением из перечисления [BuildType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7) .
8. Запишите презентацию на диск в виде файла PPTX.

Этот C++ код показывает, как применить эффект `Fade` к AutoShape и задать анимацию текста со значением *By 1st Level Paragraphs* :
```c++
// Создает объект класса презентации, представляющий файл презентации.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Добавляет новую AutoShape с текстом
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Получает основную последовательность слайда.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Добавляет эффект анимации Fade к фигуре
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Анимирует текст фигуры по абзацам первого уровня
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Сохраняет файл PPTX на диск
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


{{%  alert color="primary"  %}} 

Кроме применения анимаций к тексту, вы можете также применять анимации к отдельному [Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph) . См. [**Animated Text**](/slides/ru/cpp/animated-text/) .

{{% /alert %}} 

## **Применение анимации к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) на слайде. 
4. Получите основную последовательность эффектов.
5. Добавьте анимационный эффект к [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) .
6. Запишите презентацию на диск в виде файла PPTX.

Этот C++ код показывает, как применить эффект `Fly` к рамке изображения :
```c++
// Создаёт объект класса презентации, представляющий файл презентации.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Загружает изображение, которое будет добавлено в коллекцию изображений презентации
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Добавляет рамку изображения к слайду
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Получает основную последовательность слайда.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Добавляет эффект анимации Fly слева к рамке изображения
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Сохраняет файл PPTX на диск
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Применение анимации к Shape**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) . 
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) (при щелчке по этому объекту анимация запускается) .
5. Создайте последовательность эффектов для фигуры bevel.
6. Создайте пользовательскую `UserPath` .
7. Добавьте команды для перемещения по `UserPath` .
8. Запишите презентацию на диск в виде файла PPTX.

Этот C++ код показывает, как применить эффект `PathFootball` (path football) к фигуре :
```c++
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

	// Добавляет анимационный эффект PathFootBall
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Создаёт некую «кнопку».
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Создаёт последовательность эффектов для этой кнопки.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Создаёт пользовательский путь. Наш объект будет перемещён только после нажатия кнопки.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Добавляет команды перемещения, поскольку созданный путь пуст.
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
	 
	 //Записывает файл PPTX на диск
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Получение анимационных эффектов, применённых к фигуре**

Ниже приведённые примеры показывают, как использовать метод `GetEffectsByShape` интерфейса [ISequence](https://reference.aspose.com/slides/cpp/aspose.slides.animation/isequence/) для получения всех анимационных эффектов, применённых к фигуре.

**Пример 1: Получение анимационных эффектов, применённых к фигуре на обычном слайде**

Ранее вы изучили, как добавлять анимационные эффекты к фигурам в презентациях PowerPoint. Следующий пример кода показывает, как получить эффекты, применённые к первой фигуре на первом обычном слайде презентации `AnimExample_out.pptx` .
```c++
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Gets the main animation sequence of the slide.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Gets the first shape on the first slide.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Gets animation effects applied to the shape.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```


**Пример 2: Получение всех анимационных эффектов, включая унаследованные из заполнителей**

Если фигура на обычном слайде имеет заполнители, которые находятся на слайде‑макете и/или мастере, и к этим заполнителям добавлены анимационные эффекты, тогда все эффекты фигуры будут воспроизводиться во время показа слайдов, включая унаследованные из заполнителей.

Предположим, у нас есть файл презентации PowerPoint `sample.pptx` с одним слайдом, содержащим только фигуру нижнего колонтитула с текстом «Made with Aspose.Slides», к которой применён эффект **Random Bars** .

![Slide shape animation effect](slide-shape-animation.png)

Предположим также, что к заполнителю нижнего колонтитула на **layout**‑слайде применён эффект **Split** .

![Layout shape animation effect](layout-shape-animation.png)

И, наконец, к заполнителю нижнего колонтитула на **master**‑слайде применён эффект **Fly In** .

![Master shape animation effect](master-shape-animation.png)

Следующий пример кода показывает, как использовать метод `GetBasePlaceholder` интерфейса [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) для доступа к заполнителям фигуры и получения анимационных эффектов, применённых к фигуре нижнего колонтитула, включая унаследованные из заполнителей, расположенных на слайдах‑макете и мастере .
```cpp
void PrintEffects(ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
}
```

```cpp
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Получить анимационные эффекты фигуры на обычном слайде.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Получить анимационные эффекты заполнителя на слайде макета.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Получить анимационные эффекты заполнителя на слайде мастера.
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
Type: 134, subtype: 45            // Разделение, вертикальное
Type: 126, subtype: 22            // Случайные полосы, горизонтальное
```


## **Изменение свойств времени анимационного эффекта**

Aspose.Slides для C++ позволяет менять свойства Timing (время) анимационного эффекта.

Это панель Timing анимации в Microsoft PowerPoint :

![example1_image](shape-animation.png)

Это соответствия между Timing в PowerPoint и свойствами [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) :

- Выпадающий список PowerPoint Timing **Start** соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3) .
- Поле PowerPoint Timing **Duration** соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340) . Длительность анимации (в секундах) — это общее время, необходимое для завершения одного цикла анимации. 
- Поле PowerPoint Timing **Delay** соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b) . 

Так меняются свойства Timing эффекта :

1. [Apply](#apply-animation-to-shape) или получите анимационный эффект.
2. Установите новые значения нужных вам свойств [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) .
3. Сохраните изменённый файл PPTX.

Этот C++ код демонстрирует операцию :
```c++
// Создает объект класса презентации, представляющий файл презентации.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Получает основную последовательность слайда.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Получает первый эффект основной последовательности.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Изменяет тип триггера эффекта на запуск по щелчку
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Изменяет длительность эффекта
effect->get_Timing()->set_Duration(3.f);

// Изменяет время задержки триггера эффекта
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Сохраняет файл PPTX на диск
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Звук анимационного эффекта**

Aspose.Slides предоставляет следующие свойства для работы со звуками в анимационных эффектах :

- [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Добавить звук к анимационному эффекту**

Этот C++ код показывает, как добавить звук к анимационному эффекту и остановить его, когда начинается следующий эффект :
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Добавляет звук в коллекцию аудио презентации
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

// Устанавливает флаг эффекта "Stop previous sound"
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Записывает файл PPTX на диск
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```


### **Извлечь звук из анимационного эффекта**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу. 
3. Получите основную последовательность эффектов. 
4. Извлеките встроенный звук из каждого анимационного эффекта с помощью [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) .

Этот C++ код показывает, как извлечь звук, встроенный в анимационный эффект :
```c++
// Создает объект класса презентации, представляющий файл презентации.
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


## **After Animation**

Aspose.Slides для C++ позволяет менять свойство After animation анимационного эффекта.

Это панель Effect и расширенное меню в Microsoft PowerPoint :

![example1_image](shape-after-animation.png)

Выпадающий список PowerPoint Effect **After animation** соответствует следующим свойствам :

- Свойство [set_AfterAnimationType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) описывает тип After animation :
  * Пункт PowerPoint **More Colors** соответствует типу [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) ;
  * Пункт PowerPoint **Don't Dim** соответствует типу [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) (значение по умолчанию) ;
  * Пункт PowerPoint **Hide After Animation** соответствует типу [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) ;
  * Пункт PowerPoint **Hide on Next Mouse Click** соответствует типу [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) ;
- Свойство [set_AfterAnimationColor()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) задаёт цвет после анимации. Это свойство работает совместно с типом [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) . Если изменить тип на иной, цвет после анимации будет очищен.

Этот C++ код показывает, как изменить эффект After animation :
```c++
// Создает объект класса презентации, представляющий файл презентации
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Получает первый эффект основной последовательности
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Изменяет тип анимации после выполнения на Цвет
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Устанавливает цвет затемнения после анимации
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Записывает файл PPTX на диск
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```


## **Animate Text**

Aspose.Slides предоставляет следующие свойства для работы с блоком *Animate text* анимационного эффекта :

- [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) описывает тип анимации текста эффекта. Текст фигуры может анимироваться :
  - Всё сразу ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) тип)
  - По словам ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) тип)
  - По буквам ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) тип)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) задаёт задержку между частями анимированного текста (словами или буквами). Положительное значение указывает процент от длительности эффекта. Отрицательное значение задаёт задержку в секундах.

Так можно изменить свойства Effect Animate text :

1. [Apply](#apply-animation-to-shape) или получите анимационный эффект.
2. Установите свойство [set_BuildType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itextanimation/set_buildtype/) в значение [BuildType.AsOneObject](https://reference.aspose.com/slides/cpp/aspose.slides.animation/buildtype/) чтобы отключить режим анимации *By Paragraphs* .
3. Установите новые значения для свойств [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) и [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) .
4. Сохраните изменённый файл PPTX.

Этот C++ код демонстрирует операцию :
```c++
// Создает объект класса презентации, представляющий файл презентации.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Получает первый эффект основной последовательности
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Изменяет тип анимации текста эффекта на "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Изменяет тип анимации текста эффекта на "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Устанавливает задержку между словами в 20% от длительности эффекта
firstEffect->set_DelayBetweenTextParts(20.0f);

// Записывает файл PPTX на диск
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Как обеспечить сохранение анимаций при публикации презентации в веб?**

[Export to HTML5](/slides/ru/cpp/export-to-html5/) и включите [параметры](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) отвечающие за анимацию [shape](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) и [transition](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) . Обычный HTML не воспроизводит анимацию слайдов, тогда как HTML5 делает.

**Как изменение порядка слоёв (z-order) фигур влияет на анимацию?**

Порядок анимации и порядок рисования независимы: эффект управляет временем и типом появления/исчезновения, а [z-order](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_zorderposition/) определяет, что покрывает что. Видимый результат определяется их сочетанием. (Это общее поведение PowerPoint; модель Aspose.Slides effects-and-shapes следует той же логике.)

**Есть ли ограничения при конвертации анимаций в видео для некоторых эффектов?**

В целом, [анимации поддерживаются](/slides/ru/cpp/convert-powerpoint-to-video/), но редкие случаи или специфические эффекты могут отображаться иначе. Рекомендуется тестировать используемые эффекты и версию библиотеки.