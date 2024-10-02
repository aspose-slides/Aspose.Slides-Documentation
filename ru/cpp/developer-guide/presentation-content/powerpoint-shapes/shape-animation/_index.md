---
title: Анимация форм
type: docs
weight: 60
url: /ru/cpp/shape-animation/
keywords: "Анимация PowerPoint, Эффект анимации, Применить анимацию, Презентация PowerPoint, C++, CPP, Aspose.Slides для C++"
description: "Примените анимацию PowerPoint в C++"
---

Анимации — этоVisual эффекты, которые можно применять к текстам, изображениям, фигурам или [диаграммам](/slides/ru/cpp/animated-charts/). Они придают жизнь презентациям или их компонентам.

### **Почему стоит использовать анимацию в презентациях?**

Используя анимации, вы можете

* контролировать поток информации
* подчеркивать важные моменты
* увеличивать интерес или вовлеченность вашей аудитории
* облегчать чтение, усвоение или обработку контента
* привлекать внимание ваших читателей или зрителей к важным частям презентации

PowerPoint предлагает множество опций и инструментов для анимации и эффектов анимации в категориях **вход**, **выход**, **акцент** и **движение**.

### **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями в пространстве имен [Aspose.Slides.Animation](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation),
* Aspose.Slides предоставляет более **150 эффекта анимации** в перечислении [EffectType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Эти эффекты по существу такие же (или эквивалентные) эффекты, используемые в PowerPoint.

## **Применить анимацию к текстовому полю**

Aspose.Slides для C++ позволяет применять анимацию к тексту в фигуре.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `прямоугольник` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). 
4. Добавьте текст в [IAutoShape.TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Получите основную последовательность эффектов.
6. Добавьте эффект анимации к [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). 
7. Установите свойство [TextAnimation.BuildType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) в значение из [перечисления BuildType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Запишите презентацию на диск в формате PPTX.

Этот код C++ показывает, как применить эффект `Fade` к AutoShape и установить анимацию текста на значение *По 1-му уровню абзацев*:

```c++
// Создает экземпляр класса презентации, представляющей файл презентации.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Добавляет новую AutoShape с текстом
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Первый абзац \nВторой абзац \nТретий абзац");

// Получает основную последовательность слайда.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Добавляет эффект анимации Fade к фигуре
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Анимирует текст фигуры по 1-му уровню абзацев
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Сохраняет файл PPTX на диск
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

Кроме применения анимаций к тексту, вы также можете применять анимации к отдельному [абзацу](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph). См. [**Анимированный текст**](/slides/ru/cpp/animated-text/).

{{% /alert %}} 

## **Применить анимацию к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) на слайде. 
4. Получите основную последовательность эффектов.
5. Добавьте эффект анимации к [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame).
6. Запишите презентацию на диск в формате PPTX.

Этот код C++ показывает, как применить эффект `Fly` к рамке изображения:

```c++
// Создает экземпляр класса презентации, представляющей файл презентации.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Загружает изображение, которое будет добавлено в коллекцию изображений презентации
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Добавляет рамку изображения на слайд
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Получает основную последовательность слайда.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Добавляет эффект анимации Fly from Left к рамке изображения
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Сохраняет файл PPTX на диск
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Применить анимацию к фигуре**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `прямоугольник` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). 
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) (при нажатии на этот объект анимация проигрывается).
5. Создайте последовательность эффектов на фигуре Bevel.
6. Создайте пользовательский `UserPath`.
7. Добавьте команды для перемещения к `UserPath`.
8. Запишите презентацию на диск в формате PPTX.

Этот код C++ показывает, как применить эффект `PathFootball` к фигуре:

```c++
	// Путь к директории документа.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Загружает презентацию
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Получает первый слайд
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Получает коллекцию фигур для выбранного слайда
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Создает эффект PathFootball для существующей фигуры с нуля.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Анимированное текстовое поле");

	// Добавляет эффект анимации PathFootball
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Создает нечто вроде "кнопки".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Создает последовательность эффектов для этой кнопки.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Создает пользовательский путь. Наш объект будет перемещен только после нажатия на кнопку.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Добавляет команды для перемещения, так как созданный путь пуст.
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

## **Получить эффекты анимации, примененные к фигуре**

Вы можете решить, хотите ли вы узнать о всех эффектах анимации, примененных к одной фигуре. 

Этот код C++ показывает, как получить все эффекты, примененные к конкретной фигуре:

```c++
// Создает экземпляр класса презентации, представляющей файл презентации.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

System::SharedPtr<ISlide> firstSlide = pres->get_Slides()->idx_get(0);

// Получает основную последовательность слайда.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Получает первую фигуру на слайде.
System::SharedPtr<IShape> shape = firstSlide->get_Shapes()->idx_get(0);

// Получает все эффекты анимации, примененные к фигуре.
System::ArrayPtr<System::SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    System::Console::WriteLine(System::String(u"Фигура ") + shape->get_Name() + u" имеет " + shapeEffects->get_Length() + u" эффекта анимации.");
}
```

## **Изменить свойства времени эффекта анимации**

Aspose.Slides для C++ позволяет изменять свойства времени эффекта анимации.

Это панель времени анимации в Microsoft PowerPoint:

![example1_image](shape-animation.png)

Вот соответствия между временем PowerPoint и свойствами [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- Выпадающий список времени PowerPoint **Начало** соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- Время PowerPoint **Длительность** соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). Длительность анимации (в секундах) — это общее время, необходимое анимации для завершения одного цикла. 
- Время PowerPoint **Задержка** соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

Вот как изменить свойства времени эффекта:

1. [Примените](#apply-animation-to-shape) или получите эффект анимации.
2. Установите новые значения свойств [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c), которые вам нужны. 
3. Сохраните измененный файл PPTX.

Этот код C++ демонстрирует операцию:

```c++
// Создает экземпляр класса презентации, представляющей файл презентации.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Получает основную последовательность слайда.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Получает первый эффект основной последовательности.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Изменяет тип триггера эффекта на "начать по щелчку"
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Изменяет длительность эффекта
effect->get_Timing()->set_Duration(3.f);

// Изменяет время задержки триггера эффекта
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Сохраняет файл PPTX на диск
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Звук эффекта анимации**

Aspose.Slides предоставляет эти свойства, чтобы вы могли работать со звуками в эффектах анимации: 

- [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Добавить звук эффекта анимации**

Этот код C++ показывает, как добавить звук эффекта анимации и остановить его, когда начинается следующий эффект:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Добавляет аудио в коллекцию аудио презентации
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Получает основную последовательность слайда.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Получает первый эффект основной последовательности
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Проверяет эффект на "Нет звука"
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Добавляет звук для первого эффекта
    firstEffect->set_Sound(effectSound);
}

// Получает первую интерактивную последовательность слайда.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Устанавливает флаг эффекта "Остановить предыдущий звук"
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Записывает файл PPTX на диск
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Извлечь звук эффекта анимации**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Получите ссылку на слайд по индексу. 
3. Получите основную последовательность эффектов. 
4. Извлеките [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) встроенный в каждый эффект анимации. 

Этот код C++ показывает, как извлечь звук, встроенный в эффект анимации:

```c++
// Создает экземпляр класса презентации, представляющей файл презентации.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Получает основную последовательность слайда.
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

Aspose.Slides для C++ позволяет изменять свойство "После анимации" эффекта анимации.

Это панель эффекта анимации и расширенное меню в Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Выпадающий список PowerPoint **После анимации** соответствует следующим свойствам: 

- [set_AfterAnimationType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) свойству, которое описывает тип после анимации :
  * PowerPoint **Больше цветов** соответствует типу [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/);
  * Элемент списка PowerPoint **Не затенять** соответствует типу [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) (тип по умолчанию после анимации);
  * Элемент PowerPoint **Скрыть после анимации** соответствует типу [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) ;
  * Элемент PowerPoint **Скрыть при следующем щелчке мыши** соответствует типу [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) ;
- [set_AfterAnimationColor()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) свойству, которое определяет формат цвета после анимации. Это свойство работает совместно с типом  [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) . Если вы измените тип на другой, цвет после анимации будет очищен.

Этот код C++ показывает, как изменить эффект после анимации:

```c++
// Создает экземпляр класса презентации, представляющей файл презентации
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Получает первый эффект основной последовательности
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Изменяет тип после анимации на цвет
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Устанавливает цвет затенения после анимации
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Записывает файл PPTX на диск
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Анимировать текст**

Aspose.Slides предоставляет эти свойства, которые позволяют вам работать с блоком *Анимировать текст* эффекта анимации:

- [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) который описывает тип анимации текста эффекта. Текст фигуры может быть анимирован:
  - Все сразу ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) тип)
  - По словам ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) тип)
  - По буквам ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) тип)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) устанавливает задержку между анимированными частями текста (словами или буквами). Положительное значение указывает процент от длительности эффекта. Отрицательное значение указывает задержку в секундах.

Вот как изменить свойства Effect Animate text:

1. [Примените](#apply-animation-to-shape) или получите эффект анимации.
2. Установите свойство [set_BuildType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itextanimation/set_buildtype/) в значение [BuildType.AsOneObject](https://reference.aspose.com/slides/cpp/aspose.slides.animation/buildtype/) , чтобы отключить режим анимации *По абзацам*.
3. Установите новые значения для свойств [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) и [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).
4. Сохраните измененный файл PPTX.

Этот код C++ демонстрирует операцию:

```c++
// Создает экземпляр класса презентации, представляющей файл презентации.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Получает первый эффект основной последовательности
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Изменяет тип анимации текста эффекта на "Как один объект"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Изменяет тип анимации текста эффекта на "По словам"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Устанавливает задержку между словами на 20% от длительности эффекта
firstEffect->set_DelayBetweenTextParts(20.0f);

// Записывает файл PPTX на диск
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```