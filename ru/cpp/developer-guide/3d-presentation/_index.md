---
title: Создание 3D‑эффектов в презентациях с C++
linktitle: 3D‑презентация
type: docs
weight: 232
url: /ru/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D презентация
- 3D вращение
- 3D глубина
- 3D экструдирование
- 3D градиент
- 3D текст
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Применяйте и визуализируйте 3D‑эффекты для фигур и текста PowerPoint в C++ с Aspose.Slides. Настраивайте камеру, освещение, материал, экструдирование, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides for C++ может создавать, редактировать, сохранять и визуализировать 3D‑форматирование в стиле PowerPoint для фигур и текста. В этой статье рассматриваются 3D‑эффекты, такие как вращение, экструдирование, фаски, освещение, материал, градиентные или растровые заливки и 3D‑текст.

{{% alert color="info" title="Note" %}}
Эта статья посвящена эффектам 3D‑форматирования фигур и текста PowerPoint. Она не касается вставки или редактирования автономных файлов 3D‑моделей. При экспорте слайда в изображение, PDF или HTML Aspose.Slides преобразует эти 3D‑эффекты в экспортируемый 2D‑вывод.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте метод [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) для применения 3D‑форматирования к фигуре. Метод возвращает [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте метод [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/). Этот метод применяет 3D‑форматирование к текстовому фрейму вместо тела фигуры.

| Метод | Что контролирует | Когда использовать |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращать объект в 3D‑пространстве или сопоставить предустановку 3D‑вращения PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_lightrig/) | Предустановка света, направление и вращение света. | Изменить отображение подсветок и теней на 3D‑поверхности. |
| [set_Material](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_material/) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одинаковую геометрию более плоской, мягкой, блестящей или металлической. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Насколько фигура выступает назад от передней грани. | Преобразовать плоскую фигуру в явно толстый 3D‑объект. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Цвет экструзированных боковых граней. | Сделать глубину видимой или согласовать цвет боков с передней заливкой. |
| [set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) | Дополнительная 3D‑глубина, используемая в 3D‑форматировании PowerPoint. | Точно настроить глубину фигур или текста, особенно совместно с настройками фаски и материала. |
| [get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) и [get_BevelBottom](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Поднятые или скруглённые кромки на передних и задних гранях. | Добавить смягчённую или формованную кромку вместо острой плоской грани. |
| [get_ContourColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_contourcolor/) и [set_ContourWidth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Контур вокруг 3D‑объекта. | Подчеркнуть границу объекта в визуализированном выводе. |

## **Создание 3D‑фигуры**

- Настройки камеры, поскольку вид по умолчанию может скрывать экструзию.
- Настройки света, поскольку освещение делает грани и стороны видимыми.
- Настройки материала, поскольку поверхность влияет на то, как свет отображается.
- Настройки экструзии или глубины, поскольку плоской фигуре нужна толщина.

Следующий пример создаёт прямоугольник, добавляет текст к его передней грани и применяет 3D‑форматирование. Значения вращения камеры указаны в градусах, а высота экструдирования — 100 пунктов. Пример визуализирует слайд в PNG‑изображение в два раза больше стандартных размеров и сохраняет презентацию как PPTX.

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = Color::get_Blue();
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

Отрендеренное изображение слайда показывает прямоугольник как толстый 3D‑блок:

![Отрисованный синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, установленному через API камеры.

![Панель PowerPoint 3‑D Rotation с выделенными значениями вращения X, Y и Z](img_02_01.png)

В Aspose.Slides доступ к камере осуществляется через [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/). Этот пример создаёт прямоугольник, выбирает ортографический фронтальный вид и задаёт его вращения X, Y и Z соответственно 20, 30 и 40 градусов. Он конфигурирует фигуру в памяти без сохранения файла:

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

presentation->Dispose();
```

Используйте камеру, когда нужно изменить то, как зритель видит объект. Это не меняет 2D‑геометрию фигуры на слайде. Это меняет 3D‑точку зрения, используемую PowerPoint и Aspose.Slides при визуализации.

### **Копирование ориентации камеры из шаблонной фигуры**

Для совпадения ориентации камеры шаблонной фигуры считайте её предустановку с помощью [get_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/get_cameratype/) и примените её через [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/). Пример открывает `template.pptx` и копирует ориентацию камеры с первой фигуры первого слайда во вторую фигуру. Обе фигуры уже имеют 3D‑освещение, а у второй фигуры нет явного вращения камеры.

[GetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/getrotation/) возвращает углы в градусах. Индекс `0` — широта, индекс `1` — долгота, индекс `2` — оборот. Передайте углы в [SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) в этом порядке. Если у источника нет явного вращения, `GetRotation` возвращает нулевой указатель, поэтому оставьте углы второй фигуры неустановленными. Явное вращение `(0, 0, 0)` возвращает массив из трёх нулей и должно быть скопировано.

```cpp
#include <DOM/ICamera.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

auto sourceCamera = slide->get_Shape(0)->get_ThreeDFormat()->get_Camera();
auto destinationCamera = slide->get_Shape(1)->get_ThreeDFormat()->get_Camera();

destinationCamera->set_CameraType(sourceCamera->get_CameraType());
auto angles = sourceCamera->GetRotation();
if (angles != nullptr)
{
    destinationCamera->SetRotation(angles[0], angles[1], angles[2]);
}

presentation->Save(u"camera-copy.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

При повторном открытии `camera-copy.pptx` в PowerPoint стрелка справа имеет ту же предустановку камеры и вращение, что и прямоугольник слева. Обе фигуры используют одинаковое освещение и глубину экструдирования.

![Синий 3D‑прямоугольник и правая стрелка с соответствующей ориентацией камеры, вид сверху и справа](camera-orientation.png)

## **Добавление экструзии и глубины**

Экструзия делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint элемент управления глубиной задаёт эту видимую толщину, а элемент управления цветом задаёт цвет боковых граней.

![Элементы управления глубиной PowerPoint, соответствующие свойствам цвета экструдирования и высоты экструдирования](img_02_02.png)

Задайте [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) для толщины и [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) для цвета боков. Этот пример придаёт прямоугольнику экструдирование в 100 пунктов с пурпурными боками и вращает камеру, чтобы показать толщину. Он конфигурирует фигуру в памяти без сохранения файла:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

Метод [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) задаёт глубину 3D‑фигуры. Метод [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) управляет высотой эффекта экструдирования, как показано в этом примере.

## **Использование градиентных или картинных заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или картинную заливку к передней грани и при этом использовать те же настройки камеры, света, материала и экструдирования.

Этот пример применяет градиент от синего к оранжевому к передней грани и тёмно‑оранжевый цвет к экструдированию в 150 пунктов. Стопы градиента на 0 % и 100 % отмечают начало и конец градиента. Значения вращения камеры указаны в градусах. Слайд визуализируется в PNG‑изображение в два раза больше стандартных размеров:

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = Color::get_Blue();
auto secondGradientColor = Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = Color::get_DarkOrange();
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

Отрисованный вывод сохраняет градиент на передней грани и визуализирует экструдирование отдельно:

![Отрисованный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевой экструзией](img_02_03.png)

Чтобы использовать картинную заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры. Этот пример требует существующего файла `image.jpg` в рабочем каталоге. Он растягивает изображение, заполняя прямоугольник, применяет экструдирование в 150 пунктов и задаёт вращение камеры в градусах. Фигура конфигурируется в памяти без сохранения или визуализации файла:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

auto imageData = File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

Картинка визуализируется на передней грани, а экструдирование отображается как 3D‑боковая поверхность:

![Отрисованный 3D‑прямоугольник с фото‑заливкой на передней грани и оранжевой экструзией](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры затрагивает тело фигуры. 3D‑форматирование текста затрагивает текстовый фрейм. Это полезно для эффектов, похожих на WordArt, когда сами буквы требуют экструдирования, материала, освещения и настроек камеры.

Следующий пример создаёт текст с оранжево‑белой узорчатой заливкой, применяет восходящую арку и настраивает 3D‑параметры через [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/). Высота экструдирования и глубина указаны в пунктах, вращение света — в градусах. Заливка и контур фигуры скрыты, чтобы был виден только текст. Пример визуализирует PNG‑изображение в два раза больше стандартных размеров слайда и сохраняет презентацию как PPTX:

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = Color::get_DarkOrange();
auto backgroundColor = Color::get_White();
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

Текст отображается как изогнутые, экструдированные 3D‑буквы:

![Отрисованный 3D‑текст с арочным преобразованием WordArt, оранжевой узорчатой заливкой и тёмной экструзией](img_02_05.png)

## **Сохранить текст плоским на 3D‑фигуре**

Чтобы текст оставался читаемым при сохранении 3D‑внешнего вида фигуры, вызовите [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_keeptextflat/) через [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_textframeformat/). Когда значение `true`, текст остаётся вне 3D‑сцены. При `false` текст участвует в сцене и следует её 3D‑ориентации.

Эта настройка не удаляет 3D‑форматирование фигуры: её камера, освещение, материал и экструдирование остаются настроенными через [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/). Это также отличается от обычного вращения. [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) вращает фигуру в плоскости слайда, тогда как [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) управляет пользовательским вращением текста внутри его рамки. Сохранение текста вне 3D‑сцены не сбрасывает ни один из этих углов.

Следующий автономный пример создаёт синий прямоугольник с текстом и клонирует его рядом с оригиналом. Обе фигуры имеют одинаковое 3D‑форматирование; различается только настройка текста: `false` слева и `true` справа. Углы камеры указаны в градусах, высота экструдирования — 40 пунктов. Пример сохраняет презентацию как PPTX и визуализирует сравнение слайдов в PNG в два раза больше стандартных размеров.

```cpp
#include <DOM/ITextFrameFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
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

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 70.0f, 160.0f, 240.0f, 140.0f);

shape->get_TextFrame()->set_Text(u"Readable text");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);
shape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Center);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_CornflowerBlue());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(30.0f, 30.0f, 0.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(40.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(Color::get_RoyalBlue());
shape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(false);

auto clonedShape = slide->get_Shapes()->AddClone(shape, 400.0f, 160.0f);
auto flatTextShape = System::ExplicitCast<IAutoShape>(clonedShape);
flatTextShape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(true);

presentation->Save(u"keep_text_flat.pptx", SaveFormat::Pptx);
auto image = slide->GetImage(2.0f, 2.0f);
image->Save(u"keep_text_flat.png");
image->Dispose();
presentation->Dispose();
```

Слева текст следует 3D‑ориентации. Справа он остаётся плоским и легче читаемым. Оба прямоугольника сохраняют одинаковую видимую экструдированность и 3D‑ориентацию.

![Бок о бок 3D‑прямоугольники: KeepTextFlat = false слева и true справа](keep_text_flat.png)

## **Экспорт и поведение при визуализации**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При визуализации или экспорте в форматы фиксированной разметки 3D‑сцена растеризуется или рисуется в вывод как 2D‑результат. Это касается визуализации слайдов в [PNG](/slides/ru/cpp/convert-powerpoint-to-png/), экспорта в [PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/), экспорта в [HTML](/slides/ru/cpp/convert-powerpoint-to-html/), а также генерации кадров для [video conversion](/slides/ru/cpp/convert-powerpoint-to-video/).

Имейте в виду следующее:

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать после экспорта.
- Финальный вид зависит от комбинации камеры, световой схемы, материала, экструдирования, заливки и масштабирования слайда.
- Если необходимо проверить унаследованные или тематические значения форматирования, читайте [effective shape properties](/slides/ru/cpp/shape-effective-properties/).
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат рендерится, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**  
Aspose.Slides создаёт и визуализирует 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь может вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат поддерживает это.

**В чём разница между 3D‑моделью и 3D‑эффектом?**  
3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, например вращение, экструдирование, фаска, освещение и материал. В этой статье рассматриваются 3D‑эффекты.

**Какие настройки необходимы для видимой 3D‑фигуры?**  
Минимум — задать вращение камеры и либо экструдирование, либо глубину. На практике также задают световую схему и материал, чтобы визуализированные грани имели чёткие подсветки и тени.

**Можно ли применять 3D‑эффекты и к фигурам, и к тексту?**  
Да. Используйте [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) для тела фигуры и [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) для текста.

**Отображаются ли 3D‑эффекты при экспорте в изображения, PDF, HTML или видеокадры?**  
Да. Aspose.Slides рендерит 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконвертации. Экспортированный вывод содержит отрендеренный вид, а не редактируемый 3D‑объект.

**Можно ли прочитать окончательные 3D‑значения после применения наследования и тем?**  
Да. Используйте API эффективного форматирования, описанное в [Shape Effective Properties](/slides/ru/cpp/shape-effective-properties/), чтобы прочитать окончательные значения камеры, световой схемы, фаски и связанных 3D‑параметров.