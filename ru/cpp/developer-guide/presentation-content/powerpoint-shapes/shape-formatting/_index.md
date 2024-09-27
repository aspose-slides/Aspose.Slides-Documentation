---
title: Форматирование фигур
type: docs
weight: 20
url: /ru/cpp/shape-formatting/
keywords: "Формат фигуры, формат линий, формат стилей соединений, градиентная заливка, заливка узором, заливка картинкой, сплошная заливка цветом, поворот фигур, эффекты 3d фаски, эффект 3d ротации, презентация PowerPoint, C++, Aspose.Slides для C++"
description: "Форматирование фигуры в презентации PowerPoint на C++"
---

В PowerPoint вы можете добавлять фигуры на слайды. Так как фигуры состоят из линий, вы можете форматировать фигуры, изменяя или применяя определенные эффекты к их составным линиям. Кроме того, вы можете форматировать фигуры, указывая настройки, которые определяют, как они (область внутри них) заполняются.

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides для C++** предоставляет интерфейсы и свойства, которые позволяют форматировать фигуры на основе известных опций в PowerPoint.

## **Форматировние линий**

С помощью Aspose.Slides вы можете указать предпочтительный стиль линии для фигуры. Эти шаги описывают такую процедуру:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) на слайд.
4. Установите цвет для линий фигуры.
5. Установите ширину для линий фигуры.
6. Установите [стиль линии](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a837c78839bf6ebb16979455cd1de59e4) для линии фигуры.
7. Установите [стиль штриховки](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a7eaad354a35a3b567a7327d625be3c6e) для линии фигуры.
8. Запишите измененную презентацию в файл PPTX.

Этот код на C++ демонстрирует операцию, где мы отформатировали прямоугольник `AutoShape`:

```cpp
// Создает экземпляр класса презентации, который представляет файл презентации
auto pres = MakeObject<Presentation>();

// Получает первый слайд
auto slide = pres->get_Slides()->idx_get(0);

// Добавляет фигуру типа прямоугольник
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Устанавливает цвет заливки для фигуры прямоугольника
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_White());

// Применяет некоторые настройки к линиям прямоугольника
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Устанавливает цвет для линии прямоугольника
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Записывает файл PPTX на диск
pres->Save(u"RectShpLn_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Формат стилей соединений**
Это 3 доступных варианта соединения:

* Закругление
* Скошенный угол
* Фаска

По умолчанию, когда PowerPoint соединяет две линии под углом (или угол фигуры), он использует настройку **Закругление**. Однако, если вы хотите нарисовать фигуру с очень острыми углами, вам может быть нужно выбрать **Скошенный угол**.

![join-style-powerpoint](join-style-powerpoint.png)

Этот код на C++ демонстрирует операцию, где 3 прямоугольника (изображение выше) были созданы с настройками стиля соединения Скошенный угол, Фаска и Закругление:

```cpp
// Создает экземпляр класса презентации, который представляет файл презентации
auto pres = MakeObject<Presentation>();

// Получает первый слайд
auto slide = pres->get_Slides()->idx_get(0);

// Добавляет 3 фигуры типа прямоугольник
SharedPtr<IAutoShape> shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);
SharedPtr<IAutoShape> shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 300, 100, 150, 75);
SharedPtr<IAutoShape> shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 250, 150, 75);

// Устанавливает цвет заливки для фигуры прямоугольника
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Устанавливает ширину линии
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Устанавливает цвет для линии прямоугольника
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Устанавливает стиль соединения
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Добавляет текст к каждому прямоугольнику
shape1->get_TextFrame()->set_Text(u"Стиль соединения Скошенный угол");
shape2->get_TextFrame()->set_Text(u"Стиль соединения Фаска");
shape3->get_TextFrame()->set_Text(u"Стиль соединения Закругление");

// Записывает файл PPTX на диск
pres->Save(u"RectShpLnJoin_out.pptx", Export::SaveFormat::Pptx);
```

## **Градиентная заливка**
В PowerPoint градиентная заливка - это параметр форматирования, который позволяет вам применять непрерывный переход цветов к фигуре. Например, вы можете применить два или более цветов в настройке, где один цвет постепенно исчезает и сменяется другим цветом.

Вот как вы используете Aspose.Slides для применения градиентной заливки к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) фигуры в `Gradient`.
5. Добавьте ваши 2 предпочтительных цвета с определенными позициями, используя методы `Add`, предоставленные коллекцией `GradientStops`, связанной с классом `GradientFormat`.
6. Запишите измененную презентацию в файл PPTX.

Этот C++ код демонстрирует операцию, где эффект градиентной заливки был использован на эллипсе:

```cpp
// Создает экземпляр класса презентации, который представляет файл презентации
auto pres = MakeObject<Presentation>();

// Получает первый слайд
auto slide = pres->get_Slides()->idx_get(0);
    
// Добавляет эллипс
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 150, 75, 150);

// Применяет градиентное форматирование к эллипсу
autoShape->get_FillFormat()->set_FillType(FillType::Gradient);
autoShape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Устанавливает направление градиента
autoShape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Добавляет 2 градиентные остановки
autoShape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
autoShape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Записывает файл PPTX на диск
pres->Save(u"FillShapesGradient_out.pptx", Export::SaveFormat::Pptx);
```

## **Заливка узором**
В PowerPoint заливка узором - это параметр форматирования, который позволяет применять двухцветный дизайн, состоящий из точек, полос, крестиков или клеток к фигуре. Кроме того, вы можете выбрать предпочтительные цвета для переднего и заднего плана вашего узора.

Aspose.Slides предоставляет более 45 предопределенных стилей, которые можно использовать для форматирования фигур и обогащения презентаций. Даже после того, как вы выбрали предопределенный узор, вы все равно можете указать цвета, которые должен содержать узор.

Вот как вы используете Aspose.Slides для применения заливки узором к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) фигуры в `Pattern`.
5. Установите предпочтительный стиль узора для фигуры.
6. Установите [Цвет фона](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_pattern_format#af55b6343b7bd80d0ad95070e96b8766e) для [PatternFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.pattern_format).
7. Установите [Цвет переднего плана](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_pattern_format#a4121d8c2233df4b90cbfd6ea4c312cbe) для [PatternFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.pattern_format).
8. Запишите измененную презентацию в файл PPTX.

Этот C++ код демонстрирует операцию, где заливка узором использовалась для украшения прямоугольника:

```cpp
// Создает экземпляр класса презентации, который представляет файл презентации
auto pres = MakeObject<Presentation>();

// Получает первый слайд
auto slide = pres->get_Slides()->idx_get(0);

// Добавляет прямоугольник
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// Устанавливает тип заливки в узор
autoShape->get_FillFormat()->set_FillType(FillType::Pattern);

// Устанавливает стиль узора
autoShape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Устанавливает цвета узора фона и переднего плана
autoShape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
autoShape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Записывает файл PPTX на диск
pres->Save(u"RectShpPatt_out.pptx", Export::SaveFormat::Pptx);
```

## **Заливка картинкой**
В PowerPoint заливка картинкой - это параметр форматирования, который позволяет разместить картинку внутри фигуры. По сути, вы можете использовать картинку в качестве фона фигуры.

Вот как вы используете Aspose.Slides для заполнения фигуры картинкой:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) фигуры в `Picture`.
5. Установите режим заливки картины в Тайлы.
6. Создайте объект `IPPImage`, используя изображение, которое будет использоваться для заполнения фигуры.
7. Установите свойство `Picture.Image` объекта `PictureFillFormat` на только что созданный `IPPImage`.
8. Запишите измененную презентацию в файл PPTX.

Этот C++ код показывает вам, как заполнить фигуру картинкой:

```cpp
// Создает экземпляр класса презентации, который представляет файл презентации
auto pres = MakeObject<Presentation>();

// Получает первый слайд
auto slide = pres->get_Slides()->idx_get(0);

// Добавляет прямоугольник
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// Устанавливает тип заливки в картинку
autoShape->get_FillFormat()->set_FillType(FillType::Picture);

// Устанавливает режим заливки картинки
autoShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Устанавливает картинку
auto img = Images::FromFile(u"Tulips.jpg");
auto imgx = pres->get_Images()->AddImage(img);
autoShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Записывает файл PPTX на диск
pres->Save(u"RectShpPic_out.pptx", Export::SaveFormat::Pptx);
```

## **Сплошная заливка цветом**
В PowerPoint сплошная заливка цветом - это параметр форматирования, который позволяет заполнять фигуру единым цветом. Выбранный цвет обычно является простым цветом. Цвет применяется к фону фигуры без каких-либо специальных эффектов или модификаций.

Вот как вы используете Aspose.Slides для применения сплошной заливки цветом к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) фигуры в `Solid`.
5. Установите свой предпочтительный цвет для фигуры.
6. Запишите измененную презентацию в файл PPTX.

Вышеупомянутые шаги реализованы в примере ниже.

```cpp
// Создает экземпляр класса презентации, который представляет файл презентации
auto pres = MakeObject<Presentation>();

// Получает первый слайд
auto slide = pres->get_Slides()->idx_get(0);

// Добавляет прямоугольник
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// Устанавливает тип заливки в сплошной цвет
autoShape->get_FillFormat()->set_FillType(FillType::Solid);

// Устанавливает цвет для прямоугольника
autoShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Записывает файл PPTX на диск
pres->Save(u"RectShpSolid_out.pptx", Export::SaveFormat::Pptx);
```

## **Установить прозрачность**

В PowerPoint, когда вы заполняете фигуры сплошными цветами, градиентами, картинками или текстурами, вы можете указать уровень прозрачности, который определяет непрозрачность заливки. Таким образом, например, если вы установите низкий уровень прозрачности, объект слайда или фон за (фигурой) покажется сквозь фигуру.

Aspose.Slides позволяет вам установить уровень прозрачности для фигуры следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) на слайд.
4. Используйте `Color.FromArgb` с установленным компонентом альфа.
5. Сохраните объект как файл PowerPoint.

Этот C++ код демонстрирует процесс:

```cpp
// Создает экземпляр класса презентации, который представляет файл презентации
auto pres = MakeObject<Presentation>();

// Получает первый слайд
auto slide = pres->get_Slides()->idx_get(0);

// Добавляет фигуру с плотной заливкой
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 175, 75, 150);

// Добавляет прозрачную фигуру на фигуру с плотной заливкой
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(128, 204, 102, 0));
   
// Записывает файл PPTX на диск
pres->Save(u"ShapeTransparentOverSolid_out.pptx", Export::SaveFormat::Pptx);
```

## **Поворот фигур**
Aspose.Slides позволяет вам поворачивать фигуру, добавленную на слайд, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) на слайд.
4. Поверните фигуру на необходимое количество градусов.
5. Запишите измененную презентацию в файл PPTX.

Этот C++ код показывает вам, как повернуть фигуру на 90 градусов:

```cpp
// Создает экземпляр класса презентации, который представляет файл презентации
auto pres = MakeObject<Presentation>();

// Получает первый слайд
auto slide = pres->get_Slides()->idx_get(0);

// Добавляет фигуру типа прямоугольник
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// Поворачивает фигуру на 90 градусов
autoShape->set_Rotation(90.f);

// Записывает файл PPTX на диск
pres->Save(u"RectShpRot_out.pptx", Export::SaveFormat::Pptx);
```

## **Добавить эффекты 3D фаски**
Aspose.Slides позволяет вам добавлять эффекты 3D фаски к фигуре, изменяя свойства [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) на слайд.
3. Установите ваши предпочтительные параметры для свойств [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) фигуры.
4. Запишите презентацию на диск.

Этот C++ код показывает вам, как добавить эффекты 3D фаски к фигуре:

```cpp
// Создает экземпляр класса презентации, который представляет файл презентации
auto pres = MakeObject<Presentation>();

// Получает первый слайд
auto slide = pres->get_Slides()->idx_get(0);

// Добавляет фигуру на слайд
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
auto format = shape->get_LineFormat()->get_FillFormat();
format->set_FillType(FillType::Solid);
format->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Устанавливает свойства 3D формата фигуры
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Записывает презентацию в файл PPTX
pres->Save(u"Bavel_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Добавить эффект 3D ротации**
Aspose.Slides позволяет вам применять эффекты 3D ротации к фигуре, изменяя свойства [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд через его индекс.
3. Добавьте [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) на слайд.
3. Укажите ваши предпочтительные фигуры для [CameraType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_camera#aea0717e8ef5f3199df99ed2cb2ea2dcb) и [LightType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_light_rig#a2cd12029664967d0e2f93eee25a4963f).
4. Запишите презентацию на диск.

Этот C++ код показывает вам, как применить эффекты 3D ротации к фигуре:

```cpp
// Создает экземпляр класса презентации, который представляет файл презентации
auto pres = MakeObject<Presentation>();

// Получает первый слайд
auto slide = pres->get_Slides()->idx_get(0);
    
// Добавляет фигуру на слайд
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);

// Устанавливает свойства 3D формата фигуры
shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Добавляет фигуру на слайд
shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 300, 200, 200);

// Устанавливает свойства 3D формата фигуры
shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(0, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Записывает презентацию в файл PPTX
pres->Save(u"Rotation_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Сброс форматирования**

Этот C++ код показывает вам, как сбросить форматирование в слайде и вернуть позицию, размер и форматирование каждой фигуры, которая имеет заполнение на [LayoutSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.layout_slide), к их значениям по умолчанию:

```c++
auto pres = System::MakeObject<Presentation>();

for (auto slide : pres->get_Slides())
{
    // Каждая фигура на слайде, которая имеет заполнение на макете, будет возвращена
    slide->Reset();
}
```