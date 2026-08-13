---
title: Создание 3D‑эффектов в презентациях с использованием C++
linktitle: 3D презентация
type: docs
weight: 232
url: /ru/cpp/3d-presentation/
keywords:
- PowerPoint 3D
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
description: "Применяйте и визуализируйте 3D‑эффекты для фигур и текста PowerPoint в C++ с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, экструзию, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides for C++ может создавать, редактировать, сохранять и визуализировать 3D‑форматирование в стиле PowerPoint для фигур и текста. Эта статья охватывает 3D‑эффекты, такие как вращение, экструзия, фаски, освещение, материал, градиентные или растровые заливки и 3D‑текст.

{{% alert color="info" %}}
Эта статья посвящена 3D‑форматирующим эффектам для фигур и текста PowerPoint. Она не касается вставки или редактирования отдельных 3D‑модельных файлов. При экспорте слайда в изображение, PDF или HTML Aspose.Slides визуализирует эти 3D‑эффекты в экспортируемом 2D‑выводе.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Для применения 3D‑форматирования к фигуре используйте метод [get_ThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_threedformat/) интерфейса [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/). Метод возвращает объект [IThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте метод [get_ThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/get_threedformat/) интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/). Он применяет 3D‑форматирование к текстовому кадру, а не к телу фигуры.

Самыми важными методами являются:

| Метод | Что контролирует | Когда использовать |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_camera/) | Точка зрения, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращение объекта в 3D‑пространстве или соответствие предустановке вращения 3D в PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_lightrig/) | Предустановка света, направление и вращение света. | Изменить отображение бликов и теней на 3D‑поверхности. |
| [set_Material](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_material/) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одинаковую геометрию более плоской, мягкой, блестящей или металлической. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Насколько фигура вытягивается назад от её передней грани. | Преобразовать плоскую фигуру в явно толщину 3D‑объект. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Цвет экструзированных боковых граней. | Сделать глубину видимой или согласовать цвет боков с заливкой передней грани. |
| [set_Depth](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_depth/) | Дополнительная 3D‑глубина, используемая в 3D‑форматировании PowerPoint. | Точно настроить глубину фигур или текста, особенно совместно с настройками фаски и материала. |
| [get_BevelTop](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_beveltop/) и [get_BevelBottom](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Поднятые или закруглённые края на передних и задних гранях. | Добавить смягчённый или формованный край вместо острого плоского. |
| [get_ContourColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_contourcolor/) и [set_ContourWidth](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Контур вокруг 3D‑объекта. | Подчеркнуть границу объекта в визуализированном выводе. |

## **Создание 3D‑фигуры**

Для того чтобы фигура выглядела убедительно 3D, обычно требуются четыре типа настроек:

- Настройки камеры, потому что вид по умолчанию может скрывать экструзию.
- Настройки освещения, поскольку свет делает грани и боковые поверхности различимыми.
- Настройки материала, потому что поверхность влияет на рендеринг света.
- Настройки экструзии или глубины, поскольку плоской фигуре требуется толщина.

Следующий пример создает прямоугольник, добавляет текст к его передней грани, применяет 3D‑форматирование, сохраняет презентацию в формате PPTX и визуализирует слайд в изображение PNG.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

Сформированное изображение слайда показывает прямоугольник как массивный 3D‑блок:

![Синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, задаваемому через API камеры.

![Панель 3‑D Rotation в PowerPoint с выделенными значениями вращения по X, Y и Z](img_02_01.png)

В Aspose.Slides задайте тип камеры и вращение через [IThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/):

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

Используйте камеру, когда необходимо изменить то, как зритель видит объект. Это не меняет 2D‑геометрию фигуры на слайде. Это изменяет 3D‑точку обзора, используемую PowerPoint и Aspose.Slides при визуализации.

## **Добавление экструзии и глубины**

Экструзия делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint параметр глубины задаёт эту видимую толщину, а параметр цвета задаёт цвет боковых граней.

![Элементы управления глубиной в PowerPoint, сопоставленные с свойствами цвета экструзии и высоты экструзии](img_02_02.png)

Установите [set_ExtrusionHeight](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_extrusionheight/) для задания толщины и [get_ExtrusionColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) для цвета боков:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Используйте [set_Depth](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_depth/), когда необходимо работать напрямую со значением глубины PowerPoint или комбинировать глубину с фаской, материалом и текстовыми эффектами. Во многих сценариях фигур `set_ExtrusionHeight` яснее, так как он напрямую задаёт видимую экструзию.

## **Использование градиентных или растровых заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Можно применить сплошной цвет, градиент, рисунок или растровую заливку к передней грани и при этом использовать те же настройки камеры, света, материала и экструзии.

В этом примере к фигуре применяется градиентная заливка, а к боковым граням — более тёмный цвет экструзии:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

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

Сформированный вывод сохраняет градиент на передней грани и отдельно визуализирует экструзию:

![Сформированный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевой экструзией](img_02_03.png)

Чтобы использовать растровую заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

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

![Сформированный 3D‑прямоугольник с фото‑заливкой на передней грани и оранжевой экструзией](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигур влияет на тело фигуры. 3D‑форматирование текста воздействует на текстовый кадр. Это полезно для эффектов, похожих на WordArt, где сами буквы требуют экструзии, материала, освещения и настроек камеры.

В следующем примере создаётся текст с заливкой узором, применяется трансформация WordArt и настраиваются 3D‑параметры у [ITextFrameFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/):

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

Текст визуализируется как изогнутый, экструзированный 3D‑шрифт:

![Сформированный 3D‑текст с изогнутой трансформацией WordArt, оранжевой заливкой узором и тёмной экструзией](img_02_05.png)

## **Экспорт и поведение при визуализации**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При визуализации или экспорте в форматы фиксированной разметки 3D‑сцена растеризуется или вписывается в вывод как 2D‑результат. Это относится к рендерингу слайдов в [PNG](/slides/ru/cpp/convert-powerpoint-to-png/), экспорту в [PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/), экспорту в [HTML](/slides/ru/cpp/convert-powerpoint-to-html/) или генерации кадров для [video conversion](/slides/ru/cpp/convert-powerpoint-to-video/).

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать после экспорта.
- Окончательный вид зависит от комбинации камеры, световой установки, материала, экструзии, заливки и масштабирования слайда.
- Если необходимо проверить унаследованные или основанные на теме значения форматирования, читайте [Эффективные свойства фигур](/slides/ru/cpp/shape-effective-properties/).
- Некоторые форматы вывода не могут сохранять редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат визуализируется, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

### Может ли Aspose.Slides создавать интерактивные 3D‑презентации?

Aspose.Slides создаёт и визуализирует 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь мог бы вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат поддерживает его.

### В чём разница между 3D‑моделью и 3D‑эффектом?

3D‑модель — отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, такое как вращение, экструзия, фаска, освещение и материал. Эта статья охватывает 3D‑эффекты.

### Какие настройки необходимы для видимой 3D‑фигуры?

Минимум — задать вращение камеры и либо экструзию, либо глубину. На практике также следует задать световую установку и материал, чтобы визуализированные грани имели чёткие блики и тени.

### Можно ли применять 3D‑эффекты и к фигурам, и к тексту?

Да. Используйте [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/) для тела фигуры и [ITextFrameFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/) для текста.

### Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?

Да. Aspose.Slides визуализирует 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконвертации. Экспортированный вывод содержит отрисованный вид, а не редактируемый 3D‑объект.

### Можно ли прочитать окончательные 3D‑значения после применения наследования и настроек темы?

Да. Используйте API эффективного форматирования, описанные в [Эффективных свойствах фигур](/slides/ru/cpp/shape-effective-properties/), чтобы прочитать окончательные значения камеры, световой установки, фаски и связанные 3D‑параметры.