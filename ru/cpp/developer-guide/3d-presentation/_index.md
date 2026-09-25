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
- 3D экструдирование
- 3D градиент
- 3D текст
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Применяйте и визуализируйте 3D‑эффекты для фигур и текста PowerPoint в C++ с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, экструдирование, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides для C++ может создавать, редактировать, сохранять и визуализировать PowerPoint‑style 3D‑форматирование для фигур и текста. В этой статье рассматриваются 3D‑эффекты, такие как поворот, экструдирование, фаски, освещение, материал, градиентные или растровые заливки и 3D‑текст.

{{% alert color="info" title="Note" %}}
Эта статья о 3D‑эффектах форматирования фигур и текста PowerPoint. Она не о вставке или редактировании отдельные 3D‑модели. При экспорте слайда в изображение, PDF или HTML Aspose.Slides преобразует эти 3D‑эффекты в экспортированный 2D‑вывод.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Для применения 3D‑форматирования к фигуре используйте метод [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_threedformat/). Этот метод возвращает [IThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте метод [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/get_threedformat/). Он применяет 3D‑форматирование к текстовой рамке, а не к телу фигуры.

Самые важные методы:

| Метод | Что контролирует | Когда использовать |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_camera/) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращать объект в 3D‑пространстве или соответствовать предустановке вращения 3D в PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_lightrig/) | Предустановка света, направление и вращение света. | Изменить способ отображения бликов и теней на 3D‑поверхности. |
| [set_Material](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_material/) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одну и ту же геометрию более плоской, мягкой, глянцевой или металлической. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Насколько далеко фигура выступает назад от своей передней грани. | Преобразовать плоскую фигуру в явно толстый 3D‑объект. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Цвет экструдированных боковых граней. | Сделать глубину видимой или согласовать цвет боков с передней заливкой. |
| [set_Depth](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_depth/) | Дополнительная 3D‑глубина, используемая форматированием 3D в PowerPoint. | Точно настроить глубину фигур или текста, особенно совместно с настройками фаски и материала. |
| [get_BevelTop](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_beveltop/) и [get_BevelBottom](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Поднятые или скругленные кромки на передних и задних гранях. | Добавить смягчённый или формованный край вместо острого плоского. |
| [get_ContourColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_contourcolor/) и [set_ContourWidth](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Контур вокруг 3D‑объекта. | Подчеркнуть границу объекта в визуализированном выводе. |

## **Создание 3D‑фигуры**

Фигуре обычно требуется четыре типа настроек, чтобы выглядеть правдоподобно в 3D:

- Настройки камеры, так как вид по умолчанию спереди может скрывать экструдирование.  
- Настройки света, поскольку освещение делает грани и боковые стороны разборчивыми.  
- Настройки материала, поскольку поверхность влияет на то, как свет отображается.  
- Настройки экструдирования или глубины, поскольку плоской фигуре требуется толщина.

Следующий пример создаёт прямоугольник, добавляет текст к его передней грани и применяет 3D‑форматирование. Значения вращения камеры заданы в градусах, высота экструдирования – 100 пунктов. Пример визуализирует слайд в PNG‑изображение вдвое больше стандартных размеров и сохраняет презентацию как PPTX.

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

Визуализированный слайд показывает прямоугольник как толстый 3D‑блок:

![Отображённый синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается на панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, задаваемому через API камеры.

![Панель 3‑D Rotation в PowerPoint с выделенными значениями вращения по X, Y и Z](img_02_01.png)

В Aspose.Slides доступ к камере осуществляется через [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_camera/). Этот пример создаёт прямоугольник, выбирает ортографический вид спереди и задаёт его вращения X, Y и Z соответственно 20, 30 и 40 градусов. Он конфигурирует фигуру в памяти без сохранения файла:

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

Используйте камеру, когда нужно изменить то, как зритель видит объект. Это не меняет 2D‑геометрию фигуры на слайде. Это меняет 3D‑точку обзора, используемую PowerPoint и Aspose.Slides при визуализации.

## **Добавление экструдирования и глубины**

Экструдирование делает фигуру толстой, удлиняя её за переднюю грань. В PowerPoint элемент управления глубиной задаёт эту видимую толщину, а элемент управления цветом задаёт цвет боковых граней.

![Элементы управления глубиной в PowerPoint, связанные с цветом экструдирования и свойствами высоты экструдирования](img_02_02.png)

Установите [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_extrusionheight/) для толщины и [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) для цвета боков. Этот пример придаёт прямоугольнику экструдирование 100 пунктов с пурпурными боками и вращает камеру, чтобы показать толщину. Он конфигурирует фигуру в памяти без сохранения файла:

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

Метод [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_depth/) задаёт глубину 3D‑фигуры. Метод [set_ExtrusionHeight](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/set_extrusionheight/) управляет высотой экструдирования, как показано в этом примере.

## **Использование градиентных или растровых заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или растровую заливку к передней грани и при этом использовать те же настройки камеры, света, материала и экструдирования.

Этот пример применяет градиент от синего к оранжевому к передней грани и тёмно‑оранжевый цвет к экструдированию 150 пунктов. Остановки градиента в 0 и 100 обозначают начало и конец градиента. Значения вращения камеры заданы в градусах. Слайд визуализируется в PNG‑изображение вдвое больше стандартных размеров:

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

![Визуализированный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевым экструдированием](img_02_03.png)

Чтобы вместо этого использовать растровую заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры. Этот пример требует наличия файла с именем "image.jpg" в рабочем каталоге. Он растягивает картинку, заполняя прямоугольник, применяет экструдирование 150 пунктов и задаёт вращение камеры в градусах. Он конфигурирует фигуру в памяти без сохранения или визуализации файла:

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

![Визуализированный 3D‑прямоугольник с фотозаливкой на передней грани и оранжевым экструдированием](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на её тело. 3D‑форматирование текста влияет на текстовую рамку. Это полезно для эффектов, похожих на WordArt, где сами буквы нуждаются в экструдировании, материале, освещении и настройках камеры.

Следующий пример создаёт текст с оранжево‑белым узорчатым шаблоном, применяет восходящую арку и задаёт 3D‑параметры через [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/get_threedformat/). Высота и глубина экструдирования указаны в пунктах, вращение света — в градусах. Заливка и контур фигуры скрыты, чтобы был виден только текст. Пример визуализирует PNG‑изображение вдвое больше стандартных размеров слайда и сохраняет презентацию как PPTX:

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

![Визуализированный 3D‑текст с изогнутой трансформацией WordArt, оранжевой узорчатой заливкой и темным экструдированием](img_02_05.png)

## **Сохранение текста плоским на 3D‑фигуре**

Чтобы сохранять читаемость текста, одновременно сохраняя 3D‑вид фигуры, вызовите [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/set_keeptextflat/) через [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/get_textframeformat/). При значении `true` текст остаётся вне 3D‑сцены. При значении `false` текст участвует в сцене и следует её 3D‑ориентации.

Эта настройка не удаляет 3D‑форматирование фигуры: её камера, освещение, материал и экструдирование остаются настроенными через [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_threedformat/). Это также отличается от обычного вращения. [IShape::set_Rotation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/set_rotation/) вращает фигуру в плоскости слайда, тогда как [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/set_rotationangle/) управляет пользовательским вращением текста внутри его ограничивающего прямоугольника. Сохранение текста вне 3D‑сцены не сбрасывает ни один из этих углов.

Следующий автономный пример создаёт синий прямоугольник с текстом и клонирует его рядом с оригиналом. Обе фигуры имеют одинаковое 3D‑форматирование; различается только настройка текста: `false` слева и `true` справа. Углы камеры заданы в градусах, высота экструдирования — 40 пунктов. Пример сохраняет презентацию как PPTX и визуализирует сравнение слайда в PNG вдвое больше стандартных размеров.

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

Слева текст следует 3D‑ориентации. Справа он остаётся плоским и легче читаемым. Оба прямоугольника сохраняют одинаковое видимое экструдирование и 3D‑ориентацию.

![Параллельно расположенные 3D‑прямоугольники: KeepTextFlat = false слева и true справа](keep_text_flat.png)

## **Поведение при экспорте и визуализации**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При визуализации или экспорте в форматы фиксированной разметки 3D‑сцена растеризуется или вписывается в вывод как 2D‑результат. Это относится к визуализации слайдов в [PNG](/slides/ru/cpp/convert-powerpoint-to-png/), экспорту в [PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/), экспорту в [HTML](/slides/ru/cpp/convert-powerpoint-to-html/), а также к генерации кадров для [конвертации видео](/slides/ru/cpp/convert-powerpoint-to-video/).

- Экспортированные изображения и PDF не являются интерактивными. Объект нельзя вращать после экспорта.  
- Окончательный вид зависит от комбинации камеры, световой схемы, материала, экструдирования, заливки и масштабирования слайда.  
- Если необходимо проверить унаследованные или основанные на теме значения форматирования, читайте [effective shape properties](/slides/ru/cpp/shape-effective-properties/).  
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат рендерится, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**  
Aspose.Slides создаёт и визуализирует PowerPoint‑3D‑эффекты для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь мог бы вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат поддерживает его.

**В чём разница между 3D‑моделью и 3D‑эффектом?**  
3D‑модель — отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — форматирование, применяемое к обычной фигуре PowerPoint или тексту, такое как вращение, экструдирование, фаска, освещение и материал. Эта статья охватывает именно 3D‑эффекты.

**Какие настройки необходимы для видимой 3D‑фигуры?**  
Минимум — задать вращение камеры и либо экструдирование, либо глубину. На практике также задают световую схему и материал, чтобы визуализированные грани имели чёткие блики и тени.

**Могу ли я применять 3D‑эффекты как к фигурам, так и к тексту?**  
Да. Используйте [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_threedformat/) для тела фигуры и [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/get_threedformat/) для текста.

**Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?**  
Да. Aspose.Slides визуализирует 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для конвертации видео. Экспортированный результат содержит отрисованное изображение, а не редактируемый 3D‑объект.

**Могу ли я прочитать окончательные 3D‑значения после применения наследования и настроек темы?**  
Да. Используйте API эффективного форматирования, описанные в [Shape Effective Properties](/slides/ru/cpp/shape-effective-properties/), чтобы получить окончательные значения камеры, световой схемы, фаски и связанных 3D‑параметров.