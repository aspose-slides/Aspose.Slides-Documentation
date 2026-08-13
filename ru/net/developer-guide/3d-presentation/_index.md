---
title: Создание 3D‑эффектов в презентациях с помощью .NET
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

Aspose.Slides for .NET может создавать, редактировать, сохранять и визуализировать 3D‑форматирование в стиле PowerPoint для фигур и текста. Эта статья охватывает 3D‑эффекты, такие как поворот, экструзия, фаски, освещение, материал, градиентные или рисунковые заливки и 3D‑текст.

{{% alert color="info" %}}
Эта статья посвящена 3D‑эффектам форматирования фигур и текста в PowerPoint. Она не о вставке или редактировании отдельных 3D‑модельных файлов. При экспорте слайда в изображение, PDF или HTML Aspose.Slides преобразует эти 3D‑эффекты в экспортируемый 2D‑вывод.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте свойство [IShape.ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/properties/threedformat), чтобы применить 3D‑форматирование к фигуре. Это свойство раскрывает [IThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat), который управляет 3D‑сценой для этой фигуры.

Для текста используйте свойство [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/properties/threedformat). Оно применяет 3D‑форматирование к текстовой рамке, а не к телу фигуры.

Самые важные свойства:

| Слойв•о | Что управляет | Когда использовать |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/camera) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Поворот объекта в 3D‑пространстве или соответствие предустановке вращения 3D в PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/lightrig) | Предустановка света, направление и вращение света. | Изменить отображение бликов и теней на 3D‑поверхности. |
| [Material](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/material) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одну и ту же геометрию более плоской, мягкой, глянцевой или металлической. |
| [ExtrusionHeight](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/extrusionheight) | Насколько фигура вытягивается назад от её передней грани. | Преобразовать плоскую фигуру в явно толстый 3D‑объект. |
| [ExtrusionColor](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Цвет экструдированных боковых граней. | Сделать глубину видимой или согласовать цвет боков с передней заливкой. |
| [Depth](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/depth) | Дополнительная 3D‑глубина, используемая в 3D‑форматировании PowerPoint. | Точно настроить глубину фигур или текста, особенно совместно с настройками фаски и материала. |
| [BevelTop](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/beveltop) и [BevelBottom](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/bevelbottom) | Поднятые или скруглённые кромки на передних и задних гранях. | Добавить смягчённую или формуёную кромку вместо острой плоской грани. |
| [ContourColor](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/contourcolor) и [ContourWidth](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/contourwidth) | Контур вокруг 3D‑объекта. | Подчеркнуть границу объекта в визуализированном выводе. |

## **Создание 3D‑фигуры**

Фигура обычно требует четырёх видов настроек, чтобы выглядеть убедительно 3D:

- Настройки камеры, потому что вид спереди по умолчанию может скрывать экструзию.
- Настройки освещения, поскольку свет делает грани и боковые стороны различимыми.
- Настройки материала, потому что поверхность влияет на отображение света.
- Настройки экструзии или глубины, поскольку плоской фигуре требуется толщины.

Следующий пример создаёт прямоугольник, добавляет текст к его передней грани, применяет 3D‑форматирование, сохраняет презентацию как PPTX и визуализирует слайд в PNG‑изображение.

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

Отображённый слайд показывает прямоугольник как толстый 3D‑блок:

![Отображённый синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Поворот фигуры с помощью камеры**

В PowerPoint 3D‑поворот настраивается через панель 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, заданному через API камеры.

![Панель 3‑D Rotation в PowerPoint с подсвеченными значениями вращения X, Y и Z](img_02_01.png)

В Aspose.Slides задайте тип камеры и вращение через [IThreeDFormat.Camera](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/camera):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Используйте камеру, когда нужно изменить способ просмотра объекта. Это не меняет 2D‑геометрию фигуры на слайде. Это меняет 3D‑точку обзора, используемую PowerPoint и Aspose.Slides при визуализации.

## **Добавление экструзии и глубины**

Экструзия делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint контроллер глубины задаёт эту видимую толщину, а контроллер цвета определяет цвет боковых граней.

![Элементы управления глубиной в PowerPoint, сопоставленные со свойствами цвета экструзии и высоты экструзии](img_02_02.png)

Задайте [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/extrusionheight) для толщины и [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/extrusioncolor) для цвета боков:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Используйте [IThreeDFormat.Depth](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/depth), когда необходимо работать напрямую со значением глубины PowerPoint или комбинировать глубину с фаской, материалом и текстовыми эффектами. Во многих сценариях фигур `ExtrusionHeight` является более понятной настройкой, так как она напрямую задаёт видимую экструзию.

## **Использование градиентных или рисунковых заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, шаблон или рисунок к передней грани и при этом использовать те же настройки камеры, света, материала и экструзии.

Этот пример применяет градиентную заливку к фигуре и более тёмный цвет экструзии к боковым граням:

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

Визуализированный вывод сохраняет градиент на передней грани и визуализирует экструзию отдельно:

![Визуализированный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевой экструзией](img_02_03.png)

Чтобы использовать рисунок вместо градиента, добавьте изображение в презентацию и назначьте его заливкой фигуры:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

Изображение визуализируется на передней грани, а экструзия отображается как 3D‑поверхность боков:

![Визуализированный 3D‑прямоугольник с фотографией в заливке передней грани и оранжевой экструзией](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигур влияет на тело фигуры. 3D‑форматирование текста влияет на текстовую рамку. Это полезно для эффектов, похожих на WordArt, когда сами буквы требуют экструзии, материала, освещения и настроек камеры.

Следующий пример создаёт текст с узорчатой заливкой, применяет трансформ WordArt и настраивает 3D‑параметры на [ITextFrameFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat):

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

Текст визуализируется как изогнутые, экструдированные 3D‑буквы:

![Визуализированный 3D‑текст с изогнутым трансформом WordArt, оранжевой заливкой узором и тёмной экструзией](img_02_05.png)

## **Поведение при экспорте и визуализации**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При визуализации или экспорте в форматы фиксированного макета 3D‑сцена растеризуется или рисуется в вывод как 2D‑результат. Это применимо, когда вы визуализируете слайды в [PNG](/slides/ru/net/convert-powerpoint-to-png/), экспортируете в [PDF](/slides/ru/net/convert-powerpoint-to-pdf/), экспортируете в [HTML](/slides/ru/net/convert-powerpoint-to-html/), или генерируете кадры для [video conversion](/slides/ru/net/convert-powerpoint-to-video/).

Учтите следующие моменты:

- Экспортированные изображения и PDF не являются интерактивными. Объект нельзя вращать после экспорта.
- Конечный вид зависит от комбинации камеры, освещения, материала, экструзии, заливки и масштабирования слайда.
- Если необходимо проверить унаследованные или основанные на теме значения форматирования, см. [эффективные свойства фигуры](/slides/ru/net/shape-effective-properties/).
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат визуализируется, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

### Может ли Aspose.Slides создавать интерактивные 3D‑презентации?
Aspose.Slides создаёт и визуализирует 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь мог бы вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint там, где формат это поддерживает.

### В чем разница между 3D‑моделью и 3D‑эффектом?
3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, такое как вращение, экструзия, фаска, освещение и материал. Эта статья рассматривает 3D‑эффекты.

### Какие настройки требуются для видимой 3D‑фигуры?
Минимум — задать вращение камеры и либо экструзию, либо глубину. На практике также устанавливают освещение и материал, чтобы визуализированные грани имели чёткие блики и тени.

### Можно ли применять 3D‑эффекты к фигурам и тексту?
Да. Используйте [IShape.ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/properties/threedformat) для тела фигуры и [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/properties/threedformat) для текста.

### Появятся ли 3D‑эффекты при экспорте в изображения, PDF, HTML или видеокадры?
Да. Aspose.Slides визуализирует 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконвертации. Экспортированный вывод содержит отрисованное изображение, а не редактируемый 3D‑объект.

### Можно ли прочитать окончательные 3D‑значения после применения наследования и темы?
Да. Используйте API эффективного форматирования, описанные в [effective shape properties](/slides/ru/net/shape-effective-properties/), чтобы получить окончательные значения камеры, освещения, фаски и связанных 3D‑параметров.