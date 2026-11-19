---
title: Создание 3D‑эффектов в презентациях с использованием .NET
linktitle: 3D‑презентация
type: docs
weight: 232
url: /ru/net/3d-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Применяйте и визуализируйте 3D‑эффекты для фигур и текста PowerPoint в .NET с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, экструзию, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides for .NET может создавать, изменять, сохранять и отображать 3D‑форматирование в стиле PowerPoint для фигур и текста. В этой статье рассматриваются 3D‑эффекты, такие как вращение, экструзия, фаски, освещение, материал, градиентные или картинные заливки и 3D‑текст.

{{% alert color="info" title="Note" %}}
Эта статья о 3D‑эффектах форматирования фигур и текста PowerPoint. Она не о вставке или редактировании отдельных файлов 3D‑моделей. Когда вы экспортируете слайд в изображение, PDF или HTML, Aspose.Slides отображает эти 3D‑эффекты в экспортированном 2D‑выводе.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте свойство [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat), чтобы применить 3D‑форматирование к фигуре. Это свойство предоставляет доступ к [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat), который управляет 3D‑сценой этой фигуры.

Для текста используйте свойство [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat). Это применяет 3D‑форматирование к текстовому кадру, а не к телу фигуры.

Самыми важными свойствами являются:

| Свойство | Что контролирует | Когда использовать |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращайте объект в 3D‑пространстве или используйте предустановку вращения 3D PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) | Предустановка освещения, направление и вращение света. | Измените отображение бликов и теней на 3D‑поверхности. |
| [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделайте одну и ту же геометрию более плоской, мягкой, глянцевой или металлической. |
| [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) | Насколько далеко фигура простирается назад от её передней грани. | Превратите плоскую фигуру в явно толщинный 3D‑объект. |
| [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Цвет экструдированных боковых граней. | Сделайте глубину видимой или согласуйте цвет боковых граней с передней заливкой. |
| [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) | Дополнительная 3D‑глубина, используемая в 3D‑форматировании PowerPoint. | Точно настройте глубину фигур или текста, особенно в сочетании с фасками и настройками материала. |
| [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) and [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) | Поднятые или закруглённые края на передних и задних гранях. | Добавьте смягчённый или формованный край вместо острого плоского. |
| [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) and [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) | Контур вокруг 3D‑объекта. | Подчеркните границу объекта в отрисованном выводе. |

## **Создать 3D‑фигуру**

Обычно фигуре нужны четыре типа настроек, чтобы выглядеть убедительно 3D:

- Настройки камеры, поскольку вид спереди по умолчанию может скрывать экструзию.
- Настройки света, потому что освещение делает грани и боковые стороны различимыми.
- Настройки материала, поскольку поверхность влияет на то, как свет отображается.
- Настройки экструзии или глубины, так как плоской фигуре нужна толщина.

Следующий пример создаёт прямоугольник, добавляет текст к его передней грани и применяет 3D‑форматирование. Значения вращения камеры указаны в градусах, а высота экструзии — 100 пунктов. Пример выводит слайд в изображение PNG вдвое превышающее его обычные размеры и сохраняет презентацию как PPTX.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

Отрендеренное изображение слайда показывает прямоугольник как толстый 3D‑блок:

![Отрисованный синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, установленному через API камеры.

![Панель 3‑D Rotation в PowerPoint с выделенными значениями вращения по X, Y и Z](img_02_01.png)

В Aspose.Slides доступ к камере осуществляется через [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera). Этот пример создаёт прямоугольник, выбирает ортографический вид спереди и задаёт его вращения X, Y и Z соответственно 20, 30 и 40 градусов. Он настраивает фигуру в памяти без сохранения файла:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Используйте камеру, когда необходимо изменить то, как наблюдатель видит объект. Это не меняет 2D‑геометрию фигуры на слайде. Это меняет 3D‑точку обзора, используемую PowerPoint и Aspose.Slides при рендеринге.

### **Копирование ориентации камеры из шаблонной фигуры**

Чтобы сопоставить фигуру в шаблоне, скопируйте её предустановку [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) и получите её углы с помощью [GetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/getrotation/). Пример открывает `template.pptx`, считывает камеру первой фигуры на первом слайде и применяет её ориентацию ко второй фигуре. Обе фигуры уже имеют 3D‑освещение, а у второй фигуры нет явного вращения камеры.

Углы задаются в градусах. Индекс `0` — широта, индекс `1` — долгота, индекс `2` — оборот. Передайте их в [SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) в указанном порядке. Если источник возвращает `null`, значит явного вращения нет, поэтому оставьте углы второй фигуры неустановленными. Явное вращение `(0, 0, 0)` возвращает три нуля и должно быть скопировано.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var shapes = presentation.Slides[0].Shapes;

var sourceCamera = shapes[0].ThreeDFormat.Camera;
var destinationCamera = shapes[1].ThreeDFormat.Camera;

destinationCamera.CameraType = sourceCamera.CameraType;
var angles = sourceCamera.GetRotation();
if (angles != null)
{
    destinationCamera.SetRotation(angles[0], angles[1], angles[2]);
}

presentation.Save("camera-copy.pptx", SaveFormat.Pptx);
```

При повторном открытии `camera-copy.pptx` обе фигуры имеют одинаковую предустановку камеры и вращение. В PowerPoint стрелка справа использует ориентацию камеры, скопированную из прямоугольника слева. Обе фигуры используют одинаковое освещение и глубину экструзии.

![Синий 3D‑прямоугольник и правосторонняя стрелка с совпадающей ориентацией камеры, вид сверху и справа](camera-orientation.png)

## **Добавить экструзию и глубину**

Экструзия делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint управление глубиной задаёт эту видимую толщину, а управление цветом задаёт цвет боковых граней.

![Элементы управления глубиной в PowerPoint, сопоставленные с параметрами цвета экструзии и высоты экструзии](img_02_02.png)

Установите [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) для толщины и [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) для цвета боков. Этот пример придаёт прямоугольнику экструзию в 100 пунктов с фиолетовыми сторонами и вращает камеру, чтобы показать его толщину. Он настраивает фигуру в памяти без сохранения файла:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Свойство [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) задаёт глубину 3D‑фигуры. Свойство [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) управляет высотой эффекта экструзии, как показано в этом примере.

## **Использовать градиентные или картинные заливки с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или картинную заливку к передней грани и при этом использовать те же настройки камеры, света, материала и экструзии.

Этот пример применяет градиент от синего к оранжевому к передней грани и тёмно‑оранжевый цвет к экструзии в 150 пунктов. Остановки градиента на 0 и 100 обозначают начало и конец градиента. Значения вращения камеры указаны в градусах. Слайд отрисовывается в изображение PNG вдвое превышающее его обычные размеры:

```csharp
using System.Drawing;
using Aspose.Slides;

const float imageScale = 2;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

Отрисованный результат сохраняет градиент на передней грани и отдельно отрисовывает экструзию:

![Отрисованный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевой экструзией](img_02_03.png)

Чтобы использовать картинную заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры. Этот пример требует наличия файла "image.jpg" в рабочем каталоге. Он растягивает изображение, чтобы заполнить прямоугольник, применяет экструзию в 150 пунктов и задаёт вращение камеры в градусах. Он настраивает фигуру в памяти без сохранения или отрисовки файла:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

Изображение отрисовывается на передней грани, а экструзия – как 3D‑боковая поверхность:

![Отрисованный 3D‑прямоугольник с фотозаливкой на передней грани и оранжевой экструзией](img_02_04.png)

## **Применить 3D‑форматирование к тексту**

3D‑форматирование фигуры влияет на тело фигуры. 3D‑форматирование текста влияет на текстовый кадр. Это полезно для эффектов, похожих на WordArt, где сами буквы требуют экструзии, материала, освещения и настроек камеры.

В следующем примере создаётся текст с оранжево‑белой сетчатой заливкой, применяется вверх дуговой изгиб и настраиваются 3D‑параметры через [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat). Высота экструзии и глубина задаются в пунктах, а вращение света – в градусах. Заливка и контур фигуры скрыты, чтобы был виден только текст. Пример отрисовывает PNG‑изображение вдвое превышающее стандартные размеры слайда и сохраняет презентацию как PPTX:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

Текст отрисовывается как изогнутые, экструзированные 3D‑буквы:

![Отрисованный 3D‑текст с арочным преобразованием WordArt, оранжевой узорной заливкой и тёмной экструзией](img_02_05.png)

## **Сохранить текст плоским на 3D‑фигуре**

Чтобы сохранить читаемость текста, сохраняя 3D‑вид фигуры, установите [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/keeptextflat/) через [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframe/textframeformat/). Когда значение `true`, текст остаётся вне 3D‑сцены. Когда значение `false`, текст участвует в сцене и следует её 3D‑ориентации.

Эта настройка не удаляет 3D‑форматирование фигуры: её камера, освещение, материал и экструзия остаются настроенными через [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/). Это также отличается от обычного вращения. [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) вращает фигуру в плоскости слайда, тогда как [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) управляет пользовательским вращением текста внутри его ограничивающего прямоугольника. Сохранение текста вне 3D‑сцены не сбрасывает ни один из этих углов.

Следующий самостоятельный пример создаёт синий прямоугольник с текстом и клонирует его рядом с оригиналом. Обе фигуры имеют одинаковое 3D‑форматирование; различается только настройка текста: `false` слева и `true` справа. Углы камеры указаны в градусах, высота экструзии — 40 пунктов. Пример сохраняет презентацию как PPTX и отрисовывает сравнительный слайд в PNG вдвое превышающий обычные размеры.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

Слева текст следует 3D‑ориентации. Справа он остаётся плоским и легче читаемым. Оба прямоугольника сохраняют одинаковую видимую экструзию и 3D‑ориентацию.

![Параллельно расположенные 3D‑прямоугольники: KeepTextFlat false слева и true справа](keep_text_flat.png)

## **Поведение экспорта и рендеринга**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированной разметки 3D‑сцена растрируется или рисуется в вывод как 2D‑результат. Это касается рендеринга слайдов в [PNG](/slides/ru/net/convert-powerpoint-to-png/), экспорта в [PDF](/slides/ru/net/convert-powerpoint-to-pdf/), экспорта в [HTML](/slides/ru/net/convert-powerpoint-to-html/), а также создания кадров для [video conversion](/slides/ru/net/convert-powerpoint-to-video/).

Имейте в виду следующие моменты:

- Экспортированные изображения и PDF не являются интерактивными. Объект нельзя вращать после экспорта.
- Окончательный вид зависит от комбинации камеры, световой схемы, материала, экструзии, заливки и масштабирования слайда.
- Если необходимо просмотреть унаследованные или темы‑основанные значения форматирования, используйте [эффективные свойства фигуры](/slides/ru/net/shape-effective-properties/).
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат отрисовывается, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создает и отрисовывает 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь мог бы вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат поддерживает его.

**В чём разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре PowerPoint или тексту, такое как вращение, экструзия, фаска, освещение и материал. В этой статье рассматриваются 3D‑эффекты.

**Какие настройки необходимы для видимой 3D‑фигуры?**

Минимум — задать вращение камеры и либо экструзию, либо глубину. На практике также следует задать световую схему и материал, чтобы отрисованные грани имели чёткие блики и тени.

**Могу ли я применять 3D‑эффекты к фигурам и тексту?**

Да. Используйте [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) для тела фигуры и [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) для текста.

**Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides отрисовывает 3D‑эффекты при создании изображений слайдов, вывода PDF, HTML и кадров, используемых для видеоконвертации. Экспортированный результат содержит отрисованное изображение, а не редактируемый 3D‑объект.

**Могу ли я прочитать окончательные 3D‑значения после применения наследования и настроек темы?**

Да. Используйте API эффективного форматирования, описанные в [Эффективные свойства фигуры](/slides/ru/net/shape-effective-properties/), чтобы прочитать окончательные значения камеры, световой схемы, фаски и связанные 3D‑параметры.