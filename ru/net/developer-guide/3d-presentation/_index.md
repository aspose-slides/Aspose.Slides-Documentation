---
title: Создание 3D-эффектов в презентациях с использованием .NET
linktitle: 3D презентация
type: docs
weight: 232
url: /ru/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D презентация
- 3D вращение
- 3D глубина
- 3D выдавливание
- 3D градиент
- 3D текст
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Применяйте и рендерьте 3D-эффекты для фигур и текста PowerPoint в .NET с Aspose.Slides. Настраивайте камеру, освещение, материал, выдавливание, заливки и 3D-текст."
---
## **Обзор**

Aspose.Slides for .NET может создавать, изменять, сохранять и отображать 3D-форматирование в стиле PowerPoint для фигур и текста. В этой статье рассматриваются 3D-эффекты, такие как вращение, выдавливание, фаски, освещение, материал, градиентные или растровые заливки и 3D-текст.

{{% alert color="info" title="Note" %}}
Эта статья посвящена эффектам 3D-форматирования фигур и текста в PowerPoint. Она не относится к вставке или редактированию отдельные файлы 3D-моделей. При экспорте слайда в изображение, PDF или HTML Aspose.Slides отображает эти 3D-эффекты в экспортированном 2D-выводе.
{{% /alert %}}

## **Концепции 3D-форматирования**

Используйте свойство [IShape.ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/properties/threedformat) для применения 3D-форматирования к фигуре. Это свойство предоставляет [IThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat), который управляет 3D-сценой для данной фигуры.

Для текста используйте свойство [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/properties/threedformat). Оно применяет 3D-форматирование к текстовой рамке, а не к телу фигуры.

Самыми важными свойствами являются:

| Свойство | Что контролирует | Когда использовать |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/camera) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращайте объект в 3D-пространстве или соответствуйте предустановке вращения 3D в PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/lightrig) | Предустановка света, направление и вращение света. | Изменяйте отображение бликов и теней на 3D-поверхности. |
| [Material](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/material) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделайте одну и ту же геометрию более плоской, мягкой, блестящей или металлической. |
| [ExtrusionHeight](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/extrusionheight) | Насколько далеко фигура вытягивается назад от своей передней грани. | Преобразуйте плоскую фигуру в видимый толстой 3D-объект. |
| [ExtrusionColor](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Цвет вытянутых боковых граней. | Сделайте глубину видимой или согласуйте цвет сторон с передней заливкой. |
| [Depth](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/depth) | Дополнительная 3D-глубина, используемая в 3D-форматировании PowerPoint. | Точно настройте глубину фигур или текста, особенно вместе с настройками фаски и материала. |
| [BevelTop](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/beveltop) и [BevelBottom](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/bevelbottom) | Поднятые или скруглённые кромки на передних и задних гранях. | Добавьте смягчённый или формованный край вместо острого плоского. |
| [ContourColor](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/contourcolor) и [ContourWidth](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/contourwidth) | Контур вокруг 3D-объекта. | Подчеркните границу объекта в отрисованном выводе. |

## **Создание 3D-фикуры**

Фигуре обычно требуются четыре типа настроек, прежде чем она будет выглядеть правдоподобно 3D:

- Настройки камеры, поскольку вид по умолчанию может скрывать выдавливание.
- Настройки света, поскольку освещение делает грани и стороны заметными.
- Настройки материала, поскольку поверхность влияет на то, как свет отображается.
- Настройки выдавливания или глубины, поскольку плоской фигуре нужна толщина.

Следующий пример создает прямоугольник, добавляет текст к его передней грани и применяет 3D-форматирование. Значения вращения камеры указаны в градусах, высота выдавливания — 100 пунктов. Пример рендерит слайд в PNG-изображение с двойными размерами по сравнению с оригиналом и сохраняет презентацию в формате PPTX.

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

Отрендеренное изображение слайда показывает прямоугольник как толстый 3D-блок:

![Отображенный синий 3D-прямоугольник с белым 3D-текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D-вращение настраивается в панеле 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, установленному через API камеры.

![Панель 3‑D Rotation в PowerPoint с выделенными значениями вращения X, Y и Z](img_02_01.png)

В Aspose.Slides доступ к камере осуществляется через [IThreeDFormat.Camera](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/camera). Этот пример создает прямоугольник, выбирает ортографический фронтальный вид и устанавливает вращения X, Y и Z соответственно в 20, 30 и 40 градусов. Он конфигурирует фигуру в памяти без сохранения файла:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Используйте камеру, когда необходимо изменить то, как зритель видит объект. Это не меняет 2D-геометрию фигуры на слайде. Это меняет 3D-точку обзора, используемую PowerPoint и Aspose.Slides при рендеринге.

## **Добавление выдавливания и глубины**

Выдавливание делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint контроль глубины задаёт эту видимую толщину, а контроль цвета задаёт цвет боковых граней.

![Элементы управления глубиной в PowerPoint, сопоставленные с параметрами цвета выдавливания и высоты выдавливания](img_02_02.png)

Установите [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/extrusionheight) для толщины и [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/extrusioncolor) для цвета боковых граней. В этом примере прямоугольнику задаётся выдавливание 100 пунктов с пурпурными боковыми гранями, а камера вращается, чтобы показать его толщину. Фигура конфигурируется в памяти без сохранения файла:

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

Свойство [IThreeDFormat.Depth](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/depth) задаёт глубину 3D-фигуры. Свойство [ExtrusionHeight](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/extrusionheight) управляет высотой эффекта выдавливания, как показано в этом примере.

## **Использование градиентных или растровых заливок с 3D-эффектами**

3D-форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или растровую заливку к передней грани и при этом использовать те же настройки камеры, света, материала и выдавливания.

В этом примере к передней грани применяется градиент от синего к оранжевому, а к выдавливанию 150 пунктов — тёмно-оранжовый цвет. Остановки градиента на 0 и 100 указывают начало и конец градиента. Значения вращения камеры указаны в градусах. Слайд рендерится в PNG-изображение с двойными размерами по сравнению с оригиналом:

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

![Отрендеренный 3D-прямоугольник с градиентной заливкой от синего к оранжевому и оранжевым выдавливанием](img_02_03.png)

Чтобы использовать растровую заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры. Этот пример требует наличия файла с именем "image.jpg" в рабочем каталоге. Он растягивает изображение, чтобы заполнить прямоугольник, применяет выдавливание 150 пунктов и задаёт вращение камеры в градусах. Фигура конфигурируется в памяти без сохранения или рендеринга файла:

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

![Отрендеренный 3D-прямоугольник с фотозаливкой на передней грани и оранжевым выдавливанием](img_02_04.png)

## **Применение 3D-форматирования к тексту**

3D-форматирование фигуры влияет на тело фигуры. 3D-форматирование текста влияет на текстовую рамку. Это полезно для эффектов, похожих на WordArt, где самим буквам нужны выдавливание, материал, освещение и настройки камеры.

В следующем примере создаётся текст с оранжево-белым узором сетки, применяется верхняя дуга, и настраиваются 3D-параметры через [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/properties/threedformat). Высота выдавливания и глубина указаны в пунктах, а вращение света — в градусах. Заливка и контур фигуры скрыты, чтобы был виден только текст. Пример рендерит PNG-изображение с двойными размерами по сравнению с оригиналом и сохраняет презентацию в формате PPTX:

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

![Отрендеренный 3D-текст с аркой WordArt, оранжевой узорной заливкой и темным выдавливанием](img_02_05.png)

## **Сохранение текста плоским на 3D-фигуре**

Чтобы текст оставался читаемым, сохраняя 3D-вид фигуры, установите [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/keeptextflat/) через [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/textframeformat/). При значении `true` текст остаётся вне 3D-сцены. При значении `false` текст участвует в сцене и следует её 3D-ориентации.

Эта настройка не удаляет 3D-форматирование фигуры: её камера, освещение, материал и выдавливание остаются настроенными через [IShape.ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/threedformat/). Это также отличается от обычного вращения. [IShape.Rotation](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/rotation/) вращает фигуру в плоскости слайда, тогда как [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/rotationangle/) управляет пользовательским вращением текста внутри его ограничивающего прямоугольника. Сохранение текста вне 3D-сцены не сбрасывает ни один из этих углов.

В следующем автономном примере создаётся синий прямоугольник с текстом и клонируется рядом с оригиналом. Обе фигуры имеют одинаковое 3D-форматирование; различается только настройка текста: `false` слева и `true` справа. Углы камеры указаны в градусах, высота выдавливания — 40 пунктов. Пример сохраняет презентацию в формате PPTX и рендерит сравнительный слайд в PNG с двойными размерами по сравнению с оригиналом.

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

![Боковые 3D-прямоугольники: KeepTextFlat — false слева и true справа](keep_text_flat.png)

## **Экспорт и поведение рендеринга**

Aspose.Slides сохраняет 3D-форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированного макета 3D-сцена растеризуется или рисуется в вывод как 2D-результат. Это относится к рендерингу слайдов в [PNG](/slides/ru/net/convert-powerpoint-to-png/), экспорту в [PDF](/slides/ru/net/convert-powerpoint-to-pdf/), экспорту в [HTML](/slides/ru/net/convert-powerpoint-to-html/), либо к генерации кадров для [video conversion](/slides/ru/net/convert-powerpoint-to-video/).

- Экспортированные изображения и PDF не являются интерактивными. Объект нельзя вращать зрителем после экспорта.
- Окончательный вид зависит от комбинации камеры, светового оборудования, материала, выдавливания, заливки и масштабирования слайда.
- Если необходимо просмотреть наследованные или основанные на теме значения форматирования, читайте [эффективные свойства фигуры](/slides/ru/net/shape-effective-properties/).
- Некоторые форматы вывода не могут хранить редактируемое 3D-форматирование PowerPoint. В этих форматах визуальный результат рендерится, а не сохраняется как редактируемые 3D-настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создает и рендерит 3D-эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые зритель мог бы вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат поддерживает его.

**В чем разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, например вращение, выдавливание, фаска, освещение и материал. В этой статье рассматриваются 3D‑эффекты.

**Какие настройки необходимы для видимой 3D‑фигуры?**

Минимально необходимо задать вращение камеры и либо выдавливание, либо глубину. На практике также стоит установить световое оборудование и материал, чтобы отрисованные грани имели чёткие блики и тени.

**Можно ли применять 3D‑эффекты как к фигурам, так и к тексту?**

Да. Используйте [IShape.ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/properties/threedformat) для тела фигуры и [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/properties/threedformat) для текста.

**Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides рендерит 3D-эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконверсии. Экспортированный результат содержит отрисованный вид, а не редактируемый 3D‑объект.

**Можно ли прочитать окончательные 3D‑значения после применения наследования и настроек темы?**

Да. Используйте API эффективного форматирования, описанные в [эффективные свойства фигуры](/slides/ru/net/shape-effective-properties/), чтобы прочитать окончательные значения камеры, светового оборудования, фаски и связанных 3D‑параметров.