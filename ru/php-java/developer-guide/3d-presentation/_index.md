---
title: "Создание 3D‑эффектов в презентациях с использованием PHP"
linktitle: "3D‑презентация"
type: docs
weight: 232
url: /ru/php-java/3d-presentation/
keywords:
- "3D PowerPoint"
- "3D‑презентация"
- "3D‑вращение"
- "3D‑глубина"
- "3D‑выдавливание"
- "3D‑градиент"
- "3D‑текст"
- "PowerPoint"
- "презентация"
- "PHP"
- "Aspose.Slides"
description: "Применяйте и визуализируйте 3D‑эффекты для фигур и текста PowerPoint в PHP с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, выдавливание, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides for PHP via Java может создавать, редактировать, сохранять и визуализировать 3D‑форматирование в стиле PowerPoint для фигур и текста. В этой статье рассматриваются 3D‑эффекты, такие как вращение, выдавливание, фаски, освещение, материал, градиентные или растровые заливки и 3D‑текст.

{{% alert color="info" title="Note" %}}
Эта статья посвящена 3D‑форматированию фигур и текста PowerPoint. Она не о вставке или редактировании отдельных 3D‑моделей. При экспорте слайда в изображение, PDF или HTML Aspose.Slides преобразует эти 3D‑эффекты в экспортируемый 2D‑вывод.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте метод [Shape::getThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#getThreeDFormat--) для применения 3D‑форматирования к фигуре. Метод возвращает [ThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте метод [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#getThreeDFormat--) . Он применяет 3D‑форматирование к текстовой рамке, а не к телу фигуры.

Самыми важными членами API являются:

| Член API | Что контролирует | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getCamera--) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращайте объект в 3D‑пространстве или используйте предустановку вращения PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getLightRig--) | Предустановка света, направление и вращение света. | Измените отображение бликов и теней на 3D‑поверхности. |
| [getMaterial](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getMaterial--) и [setMaterial](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделайте одинаковую геометрию более плоской, мягкой, глянцевой или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getExtrusionHeight--) и [setExtrusionHeight](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Насколько далеко фигура выступает назад от своей передней грани. | Преобразуйте плоскую фигуру в явно толстый 3D‑объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Цвет выдавленных боковых граней. | Сделайте глубину видимой или согласуйте цвет боковых граней с передней заливкой. |
| [getDepth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getDepth--) и [setDepth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#setDepth-double-) | Дополнительная 3D‑глубина, используемая в 3D‑форматировании PowerPoint. | Точно настройте глубину для фигур или текста, особенно совместно с настройками фаски и материала. |
| [getBevelTop](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getBevelTop--) и [getBevelBottom](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getBevelBottom--) | Поднятые или закруглённые края на передней и задней гранях. | Добавьте смягчённый или сформированный край вместо острого плоского. |
| [getContourColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getContourColor--) и [getContourWidth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getContourWidth--) и [setContourWidth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Контур вокруг 3D‑объекта. | Подчеркните границу объекта в визуализированном выводе. |

## **Создать 3D‑фигуру**

Фигура обычно требует четырёх видов настроек, чтобы выглядеть правдоподобно 3D:

- Настройки камеры, поскольку вид спереди по умолчанию может скрывать выдавливание.  
- Настройки света, так как освещение делает грани и боковые стороны различимыми.  
- Настройки материала, поскольку поверхность влияет на отображение света.  
- Настройки выдавливания или глубины, поскольку плоской фигуре нужна толщина.  

Следующий пример создаёт прямоугольник, добавляет текст к его передней грани и применяет 3D‑форматирование. Значения вращения камеры задаются в градусах, высота выдавливания — 100 пунктов. Пример визуализирует слайд в PNG‑изображение в двойном размере от стандартного и сохраняет презентацию как PPTX.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Визуализированное изображение слайда показывает прямоугольник как толстый 3D‑блок:

![Отображённый синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели 3‑D Rotation. Значения вращения по X, Y и Z соответствуют вращению, задаваемому через API камеры.

![Панель 3‑D Rotation в PowerPoint с выделенными значениями вращения X, Y и Z](img_02_01.png)

В Aspose.Slides доступ к камере осуществляется через [ThreeDFormat::getCamera](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getCamera--). Этот пример создаёт прямоугольник, выбирает ортографический вид спереди и задаёт вращения X, Y и Z соответственно 20, 30 и 40 градусов. Он настраивает фигуру в памяти без сохранения файла:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

Используйте камеру, когда нужно изменить восприятие объекта зрителем. Это не меняет 2D‑геометрию фигуры на слайде. Это меняет 3D‑точку зрения, используемую PowerPoint и Aspose.Slides при визуализации.

## **Добавить выдавливание и глубину**

Выдавливание делает фигуру толщиной, расширяя её за переднюю грань. В PowerPoint регулировка глубины задаёт эту видимую толщину, а регулировка цвета задаёт цвет боковых граней.

![Элементы управления глубиной в PowerPoint, сопоставленные с параметрами цвета выдавливания и высоты выдавливания](img_02_02.png)

Используйте [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) для задания толщины и [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getExtrusionColor--) для доступа к цвету боковых граней. Этот пример задаёт прямоугольнику выдавливание 100 пунктов с фиолетовыми сторонами и вращает камеру, чтобы показать толщину. Он настраивает фигуру в памяти без сохранения файла:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

Метод [ThreeDFormat::setDepth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#setDepth-double-) задаёт глубину 3D‑фигуры. Метод [setExtrusionHeight](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) контролирует высоту эффекта выдавливания, как показано в этом примере.

## **Использовать градиентные или растровые заливки с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или растровую заливку к передней грани и при этом использовать те же настройки камеры, света, материала и выдавливания.

Этот пример применяет градиент от синего к оранжевому к передней грани и тёмно‑оранжевый цвет к выдавливанию 150 пунктов. Остановки градиента на 0 % и 100 % отмечают начало и конец градиента. Значения вращения камеры задаются в градусах. Слайд визуализируется в PNG‑изображение в двойном размере от стандартного:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Визуализированный вывод сохраняет градиент на передней грани и отдельно визуализирует выдавливание:

![Отображённый 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевым выдавливанием](img_02_03.png)

Чтобы вместо этого использовать растровую заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры. Этот пример требует существующего файла с именем "image.jpg" в рабочем каталоге. Он растягивает изображение, заполняя прямоугольник, применяет выдавливание 150 пунктов и задаёт вращение камеры в градусах. Он настраивает фигуру в памяти без сохранения или визуализации файла:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

Изображение визуализируется на передней грани, а выдавливание — как 3D‑боковая поверхность:

![Отображённый 3D‑прямоугольник с фотозаливкой на передней грани и оранжевым выдавливанием](img_02_04.png)

## **Применить 3D‑форматирование к тексту**

3D‑форматирование фигуры влияет на её тело. 3D‑форматирование текста влияет на текстовую рамку. Это полезно для эффектов, похожих на WordArt, когда сами буквы требуют выдавливания, материала, освещения и настроек камеры.

Следующий пример создаёт текст с оранжево‑белой сеткой, применяет восходящий арочный изгиб и настраивает 3D‑параметры через [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Высота выдавливания и глубина указаны в пунктах, вращение света — в градусах. Заливка и контур фигуры скрыты, так что виден только текст. Пример визуализирует PNG‑изображение в двойном размере от стандартного и сохраняет презентацию как PPTX:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Текст визуализируется как изогнутые, выдавленные 3D‑буквы:

![Отображённый 3D‑текст с арочным трансформом WordArt, оранжевой паттерн‑заливкой и тёмным выдавливанием](img_02_05.png)

## **Сделать текст плоским на 3D‑фигуре**

Чтобы текст оставался читаемым, сохраняя 3D‑вид фигуры, вызовите [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setKeepTextFlat-boolean-) через [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#getTextFrameFormat--). Когда значение `true`, текст остаётся вне 3D‑сцены. Когда `false`, текст участвует в сцене и следует её 3D‑ориентации.

Эта настройка не удаляет 3D‑форматирование фигуры: её камера, освещение, материал и выдавливание остаются настроенными через [Shape::getThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#getThreeDFormat--). Это также отличается от обычного вращения. [Shape::setRotation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#setRotation-float-) вращает фигуру в плоскости слайда, тогда как [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setRotationAngle-float-) управляет пользовательским вращением текста внутри его ограничивающего прямоугольника. Сохранение текста вне 3D‑сцены не сбрасывает ни один из этих углов.

Следующий автономный пример создаёт синий прямоугольник с текстом и клонирует его рядом с оригиналом. Обе фигуры имеют одинаковое 3D‑форматирование; различается только настройка текста: `false` слева и `true` справа. Углы камеры заданы в градусах, высота выдавливания — 40 пунктов. Пример сохраняет презентацию как PPTX и визуализирует сравнение слайда в PNG в двойном размере от стандартного.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Слева текст следует 3D‑ориентации. Справа он остаётся плоским и легче читается. Оба прямоугольника сохраняют одинаковое видимое выдавливание и 3D‑ориентацию.

![Параллельно расположенные 3D‑прямоугольники: текст следует 3D‑ориентации слева и остаётся плоским справа](keep_text_flat.png)

## **Поведение при экспорте и визуализации**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При визуализации или экспорте в форматы фиксированной разметки 3D‑сцена растеризуется или вписывается в вывод как 2D‑результат. Это относится к визуализации слайдов в [PNG](/slides/ru/php-java/convert-powerpoint-to-png/), экспорту в [PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/), экспорту в [HTML](/slides/ru/php-java/convert-powerpoint-to-html/), а также к генерации кадров для [видеоконвертации](/slides/ru/php-java/convert-powerpoint-to-video/).

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать зрителем после экспорта.  
- Окончательный вид зависит от сочетания камеры, освещения, материала, выдавливания, заливки и масштабирования слайда.  
- Если необходимо просмотреть унаследованные или основанные на теме значения форматирования, обратитесь к [effective shape properties](/slides/ru/php-java/shape-effective-properties/).  
- Некоторые форматы вывода не могут сохранять редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат визуализируется, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создаёт и визуализирует 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые можно вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат поддерживает его.

**В чём разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, например вращение, выдавливание, фаска, освещение и материал. В этой статье рассматриваются 3D‑эффекты.

**Какие настройки требуются для видимой 3D‑фигуры?**

Минимум — задать вращение камеры и либо выдавливание, либо глубину. На практике также задают световую схему и материал, чтобы поверхности имели чёткие блики и тени.

**Могу ли я применить 3D‑эффекты к фигурам и тексту?**

Да. Используйте [Shape::getThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#getThreeDFormat--) для тела фигуры и [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#getThreeDFormat--) для текста.

**Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides визуализирует 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконвертации. Экспортированный результат содержит визуализированный вид, а не редактируемый 3D‑объект.

**Можно ли прочитать окончательные 3D‑значения после применения наследования и темных настроек?**

Да. Используйте API эффективного форматирования, описанные в [Shape Effective Properties](/slides/ru/php-java/shape-effective-properties/), чтобы прочитать окончательные значения камеры, световой схемы, фаски и связанных 3D‑параметров.