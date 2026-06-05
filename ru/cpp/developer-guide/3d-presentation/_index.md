---
title: Создание 3D эффектов в презентациях с использованием C++
linktitle: 3D презентация
type: docs
weight: 232
url: /ru/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D презентация
- 3D вращение
- 3D глубина
- 3D экструзия
- 3D градиент
- 3D текст
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Применяйте и визуализируйте 3D эффекты для фигур и текста PowerPoint в C++ с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, экструзию, заливки и 3D текст."
---
## **Обзор**

Aspose.Slides for C++ может создавать, редактировать, сохранять и визуализировать 3D‑форматирование в стиле PowerPoint для фигур и текста. Эта статья охватывает 3D‑эффекты, такие как вращение, экструзия, фаски, освещение, материал, градиентные или растровые заливки и 3D‑текст.

{{% alert color="primary" %}}
Эта статья о 3D‑форматировании фигур и текста в PowerPoint. Она не про вставку или редактирование отдельных 3D‑модельных файлов. При экспорте слайда в изображение, PDF или HTML Aspose.Slides визуализирует эти 3D‑эффекты в экспортированном 2D‑выводе.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте метод [get_ThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_threedformat/) интерфейса [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/) , чтобы применить 3D‑форматирование к фигуре. Метод возвращает [IThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/), который управляет 3D‑сценой этой фигуры.

Для текста используйте метод [get_ThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/get_threedformat/) интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/) . Он применяет 3D‑форматирование к текстовому фрейму, а не к телу фигуры.

Самыми важными методами являются:

| Метод | Что управляет | Когда использовать |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_camera/) | Точка наблюдения, предустановленный тип камеры, вращение, масштаб и перспектива. | Поворот объекта в 3D‑пространстве или соответствие предустановке 3D‑вращения в PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_lightrig/) | Предустановка освещения, направление и вращение света. | Изменить отображение бликов и теней на 3D‑поверхности. |
| [set_Material](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_material/) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одинаковую геометрию более плоской, мягкой, блестящей или металлической. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Насколько глубоко фигура вытягивается назад от своей передней грани. | Превратить плоскую фигуру в заметно толстый 3D‑объект. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Цвет экструзированных боковых граней. | Сделать глубину видимой или согласовать цвет боков с передней заливкой. |
| [set_Depth](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_depth/) | Дополнительная 3D‑глубина, используемая в 3D‑форматировании PowerPoint. | Точно настроить глубину для фигур или текста, особенно совместно с параметрами фаски и материала. |
| [get_BevelTop](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_beveltop/) и [get_BevelBottom](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Поднятые или закруглённые кромки на передней и задней гранях. | Добавить смягчённый или формованный край вместо острого плоского. |
| [get_ContourColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_contourcolor/) и [set_ContourWidth](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Контур вокруг 3D‑объекта. | Подчеркнуть границу объекта в визуализированном выводе. |

## **Создание 3D‑фигуры**

Фигура обычно требует четырёх видов настроек, чтобы выглядеть правдоподобно 3D:

- Настройки камеры, поскольку стандартный вид спереди может скрывать экструзию.
- Настройки освещения, так как свет делает грани и стороны различимыми.
- Настройки материала, поскольку поверхность влияет на то, как отображается свет.
- Настройки экструзии или глубины, так как плоской фигуре нужна толщина.

Следующий пример создаёт прямоугольник, добавляет текст на его переднюю грань, применяет 3D‑форматирование, сохраняет презентацию в формате PPTX и визуализирует слайд в PNG‑изображение.

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = System::Drawing::Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = System::Drawing::Color::get_Blue();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"shape_3d.png");
thumbnail->Dispose();

presentation->Save(u"shape_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Отрендеренный слайд показывает прямоугольник как толстый 3D‑блок:

![Отрендеренный синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, задаваемому через API камеры.

![Панель 3‑D Rotation в PowerPoint с выделенными значениями вращения X, Y и Z](img_02_01.png)

В Aspose.Slides тип камеры и вращение задаются через [IThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/):

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

Используйте камеру, когда необходимо изменить способ просмотра объекта. Это не меняет 2D‑геометрию фигуры на слайде. Оно изменяет 3D‑точку наблюдения, используемую PowerPoint и Aspose.Slides при визуализации.

## **Добавление экструзии и глубины**

Экструзия делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint управление глубиной задаёт эту видимую толщину, а управление цветом задаёт цвет боковых граней.

![Управление глубиной в PowerPoint, сопоставленное с параметрами цвета экструзии и высоты экструзии](img_02_02.png)

Установите [set_ExtrusionHeight](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_extrusionheight/) для толщины и [get_ExtrusionColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) для цвета сторон:

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Используйте [set_Depth](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_depth/), когда нужно работать непосредственно со значением глубины PowerPoint или комбинировать глубину с фаской, материалом и текстовыми эффектами. Во многих сценариях фигур `set_ExtrusionHeight` является более понятным параметром, поскольку он напрямую задаёт видимую экструзию.

## **Использование градиентных или растровых заливок с 3D‑эффектами**

3D‑форматирование не зависит от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или растровую заливку к передней грани и при этом использовать те же настройки камеры, света, материала и экструзии.

Этот пример применяет градиентную заливку к фигуре и более тёмный цвет экструзии к бокам:

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = System::Drawing::Color::get_Blue();
auto secondGradientColor = System::Drawing::Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"gradient_3d.png");
thumbnail->Dispose();

presentation->Dispose();
```

Отрендеренный вывод сохраняет градиент на передней грани и визуализирует экструзию отдельно:

![Отрендеренный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевой экструзией](img_02_03.png)

Чтобы использовать растровую заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры:

```cpp
auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Изображение визуализируется на передней грани, а экструзия отображается как 3D‑боковая поверхность:

![Отрендеренный 3D‑прямоугольник с фотозаливкой на передней грани и оранжевой экструзией](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигур влияет на тело фигуры. 3D‑форматирование текста влияет на текстовый фрейм. Это полезно для эффектов, похожих на WordArt, когда сами буквы требуют экструзии, материала, освещения и настроек камеры.

Следующий пример создаёт текст с узорной заливкой, применяет трансформацию WordArt и настраивает 3D‑параметры на [ITextFrameFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/):

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = System::Drawing::Color::get_DarkOrange();
auto backgroundColor = System::Drawing::Color::get_White();
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(foregroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(backgroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_Transform(TextShapeType::ArchUp);
textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);
textFrameFormat->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text_3d.png");
thumbnail->Dispose();

presentation->Save(u"text_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Текст визуализируется как изогнутые, экструзированные 3D‑буквы:

![Отрендеренный 3D‑текст с арочным преобразованием WordArt, оранжевой узорной заливкой и тёмной экструзией](img_02_05.png)

## **Поведение при экспорте и визуализации**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При визуализации или экспорте в форматы фиксированной раскладки 3D‑сцена растеризуется или рисуется в вывод как 2D‑результат. Это относится к визуализации слайдов в [PNG](/slides/ru/cpp/convert-powerpoint-to-png/), экспорту в [PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/), экспорту в [HTML](/slides/ru/cpp/convert-powerpoint-to-html/) или созданию кадров для [конвертации видео](/slides/ru/cpp/convert-powerpoint-to-video/).

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать после экспорта.
- Окончательный вид зависит от комбинации камеры, светового комплекта, материала, экструзии, заливки и масштабирования слайда.
- Если нужно просмотреть унаследованные или основанные на теме значения форматирования, читайте [Эффективные свойства фигуры](/slides/ru/cpp/shape-effective-properties/).
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат визуализируется, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создает и визуализирует 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь может вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат поддерживает это.

**В чем разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, такое как вращение, экструзия, фаска, освещение и материал. В этой статье рассматриваются 3D‑эффекты.

**Какие настройки необходимы для видимой 3D‑фигуры?**

Минимум — задать вращение камеры и либо экструзию, либо глубину. На практике также устанавливают световой комплект и материал, чтобы отрисованные грани имели чёткие блики и тени.

**Могу ли я применять 3D‑эффекты к фигурам и тексту?**

Да. Используйте [IShape] для тела фигуры и [ITextFrameFormat] для текста.

**Отобразятся ли 3D‑эффекты при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides визуализирует 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для конвертации в видео. Экспортированный файл содержит визуализированный вид, а не редактируемый 3D‑объект.

**Могу ли я прочитать окончательные 3D‑значения после применения наследования и настроек темы?**

Да. Используйте API эффективного форматирования, описанные в [Эффективные свойства фигуры](/slides/ru/cpp/shape-effective-properties/), чтобы прочитать окончательные значения камеры, светового комплекта, фаски и связанных 3D‑параметров.