---
title: Создание 3D‑эффектов в презентациях с использованием .NET
linktitle: 3D Презентация
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
description: "Применяйте и рендерьте 3D‑эффекты для фигур и текста PowerPoint в .NET с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, выдавливание, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides for .NET может создавать, изменять, сохранять и отображать 3D‑форматирование в стиле PowerPoint для фигур и текста. В этой статье рассматриваются 3D‑эффекты, такие как вращение, выдавливание, скосы, освещение, материал, градиентные или растровые заливки и 3D‑текст.

{{% alert color="primary" %}}
Эта статья посвящена эффектам 3D‑форматирования фигур и текста PowerPoint. Она не относится к вставке или редактированию автономных файлов 3D‑моделей. При экспорте слайда в изображение, PDF или HTML Aspose.Slides преобразует эти 3D‑эффекты в экспортированный 2D‑вывод.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте свойство [IShape.ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/properties/threedformat), чтобы применить 3D‑форматирование к фигуре. Свойство раскрывает [IThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat), который управляет 3D‑сценой для этой фигуры.

Для текста используйте свойство [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/properties/threedformat). Оно применяет 3D‑форматирование к текстовой рамке вместо тела фигуры.

Самыми важными свойствами являются:

| Свойство | Что управляет | Когда использовать |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/camera) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращение объекта в 3D‑пространстве или соответствие предустановке вращения 3D в PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/lightrig) | Предустановка освещения, направление и вращение света. | Изменить отображение бликов и теней на 3D‑поверхности. |
| [Material](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/material) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одну и ту же геометрию более плоской, мягкой, блестящей или металлической. |
| [ExtrusionHeight](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/extrusionheight) | Насколько далеко фигура вытягивается назад от своей передней грани. | Преобразовать плоскую фигуру в видимый толщинный 3D‑объект. |
| [ExtrusionColor](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Цвет вытянутых боковых граней. | Сделать видимой глубину или согласовать цвет боков с заливкой передней грани. |
| [Depth](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/depth) | Дополнительная 3D‑глубина, используемая в 3D‑форматировании PowerPoint. | Точно настроить глубину фигур или текста, особенно вместе с настройками скоса и материала. |
| [BevelTop](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/beveltop) и [BevelBottom](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/bevelbottom) | Поднятые или закруглённые кромки на передней и задней гранях. | Добавить сглаженный или формованный край вместо острого плоского лица. |
| [ContourColor](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/contourcolor) и [ContourWidth](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/contourwidth) | Контур вокруг 3D‑объекта. | Подчеркнуть границу объекта в визуальном выводе. |

## **Создание 3D‑фигуры**

Фигура обычно требует четырёх видов настроек, чтобы выглядеть убедительно 3D:

- Настройки камеры, потому что вид по умолчанию может скрывать выдавливание.
- Настройки освещения, потому что свет делает грани и боковины различимыми.
- Настройки материала, потому что поверхность влияет на то, как свет отображается.
- Настройки выдавливания или глубины, потому что плоской фигуре нужна толщина.

Следующий пример создаёт прямоугольник, добавляет текст на его переднюю грань, применяет 3D‑форматирование, сохраняет презентацию как PPTX и рендерит слайд в PNG‑изображение.

```csharp
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

Отображённый синий 3D‑прямоугольник с белым 3D‑текстом на передней грани:

![Отображённый синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, задаваемому через API камеры.

![Панель 3‑D вращения PowerPoint с выделенными значениями вращения по X, Y и Z](img_02_01.png)

В Aspose.Slides задайте тип камеры и вращение через [IThreeDFormat.Camera](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/camera):

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Используйте камеру, когда нужно изменить точку зрения наблюдателя. Это не меняет 2D‑геометрию фигуры на слайде, а лишь меняет 3D‑точку обзора, используемую PowerPoint и Aspose.Slides при рендеринге.

## **Добавление выдавливания и глубины**

Выдавливание делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint контроль глубины задаёт видимую толщину, а контроль цвета задаёт цвет боковых граней.

![Элементы управления глубиной PowerPoint, сопоставленные со свойствами цвета выдавливания и высоты выдавливания](img_02_02.png)

Установите [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/extrusionheight) для толщины и [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/extrusioncolor) для цвета сторон:

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Используйте [IThreeDFormat.Depth](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/properties/depth), когда необходимо работать напрямую со значением глубины PowerPoint или комбинировать глубину со скосом, материалом и текстовыми эффектами. Во многих сценариях фигур `ExtrusionHeight` более понятно, поскольку напрямую задаёт видимую выдавливку.

## **Использование градиентных или изображений в качестве заливки с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Можно применить сплошной цвет, градиент, узор или растровую заливку к передней грани и одновременно использовать те же настройки камеры, света, материала и выдавливания.

Этот пример применяет градиентную заливку к фигуре и более тёмный цвет выдавливания к боковым граням:

```csharp
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

Отображённый результат сохраняет градиент на передней грани и отдельно рендерит выдавливание:

![Отображённый 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевым выдавливанием](img_02_03.png)

Чтобы использовать растровую заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры:

```csharp
var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

Изображение рендерится на передней грани, а выдавливание отображается как 3D‑поверхность боков:

![Отображённый 3D‑прямоугольник с фотозаливкой на передней грани и оранжевым выдавливанием](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на тело фигуры. 3D‑форматирование текста влияет на текстовую рамку. Это полезно для эффектов, похожих на WordArt, когда сами буквы требуют выдавливания, материала, освещения и настроек камеры.

Следующий пример создаёт текст с узорной заливкой, применяет трансформацию WordArt и настраивает 3D‑параметры у [ITextFrameFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat):

```csharp
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

Текст рендерится как изогнутые, выдавленные 3D‑буквы:

![Отображённый 3D‑текст с арочным преобразованием WordArt, оранжевой узорчатой заливкой и тёмным выдавливанием](img_02_05.png)

## **Экспорт и поведение рендеринга**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированного макета 3D‑сцена растеризуется или отрисовывается в результате как 2D‑изображение. Это относится к рендерингу слайдов в [PNG](/slides/ru/net/convert-powerpoint-to-png/), экспорту в [PDF](/slides/ru/net/convert-powerpoint-to-pdf/), экспорту в [HTML](/slides/ru/net/convert-powerpoint-to-html/), а также к генерации кадров для [video conversion](/slides/ru/net/convert-powerpoint-to-video/).

Имейте в виду следующие моменты:

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать зрителем после экспорта.
- Окончательный вид зависит от комбинации камеры, системы освещения, материала, выдавливания, заливки и масштаба слайда.
- Если необходимо просмотреть унаследованные или основанные на теме значения форматирования, читайте [эффективные свойства фигуры](/slides/ru/net/shape-effective-properties/).
- Некоторые форматы вывода не могут сохранять редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат рендерится, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**  
Aspose.Slides создаёт и рендерит 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь мог бы вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат поддерживает это.

**В чём разница между 3D‑моделью и 3D‑эффектом?**  
3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint (вращение, выдавливание, скос, освещение, материал). В этой статье рассматриваются именно 3D‑эффекты.

**Какие настройки нужны для видимой 3D‑фигуры?**  
Как минимум необходимо задать вращение камеры и либо выдавливание, либо глубину. На практике также задают систему освещения и материал, чтобы у полученных граней были чёткие блики и тени.

**Можно ли применять 3D‑эффекты к фигурам и тексту?**  
Да. Для тела фигуры используйте [IShape.ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/properties/threedformat), а для текста — [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/properties/threedformat).

**Будут ли 3D‑эффекты видимы при экспорте в изображения, PDF, HTML или видеокадры?**  
Да. Aspose.Slides рендерит 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконвертации. Экспортированный результат содержит уже отрисованный внешний вид, а не редактируемый 3D‑объект.

**Можно ли прочитать окончательные 3D‑значения после применения наследования и настроек темы?**  
Да. Используйте API эффективного форматирования, описанные в [эффективных свойствах фигуры](/slides/ru/net/shape-effective-properties/), чтобы получить финальные значения камеры, системы освещения, скоса и связанных 3D‑параметров.