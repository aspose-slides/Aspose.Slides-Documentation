---
title: Создание 3D‑эффектов в презентациях с использованием PHP
linktitle: 3D‑презентация
type: docs
weight: 232
url: /ru/php-java/3d-presentation/
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
- PHP
- Aspose.Slides
description: "Применяйте и визуализируйте 3D‑эффекты для фигур PowerPoint и текста в PHP с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, экструзию, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides for PHP via Java может создавать, редактировать, сохранять и отображать 3D‑форматирование в стиле PowerPoint для фигур и текста. В этой статье рассматриваются 3D‑эффекты, такие как вращение, экструзия, фаски, освещение, материал, градиентные или растровые заливки и 3D‑текст.

{{% alert color="info" title="Note" %}}
Эта статья посвящена эффектам 3D‑форматирования фигур и текста PowerPoint. Она не о вставке или редактировании отдельные файлы 3D‑моделей. При экспорте слайда в изображение, PDF или HTML Aspose.Slides отображает эти 3D‑эффекты в экспортированном 2D‑выводе.
{{% /alert %}}

## **Концепции 3D‑форматирования**

С помощью метода [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) применяют 3D‑форматирование к фигуре. Метод возвращает [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте метод [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat). Он применяет 3D‑форматирование к текстовой рамке вместо тела фигуры.

Самыми важными членами API являются:

| Член API | Что контролирует | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | Точка зрения, предустановленный тип камеры, вращение, масштаб и перспектива. | Поворот объекта в 3D‑пространстве или совпадение с предустановкой вращения 3D в PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | Предустановленная световая схема, направление и вращение света. | Изменить отображение светлых и теневых участков на 3D‑поверхности. |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | Материал поверхности, например плоский, матовый, пластиковый или металлический. | Сделать одинаковую геометрию более плоской, мягкой, глянцевой или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | Насколько далеко фигура выступает назад от своей передней грани. | Превратить плоскую фигуру в явно толщинную 3D‑объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | Цвет экструдированных боковых граней. | Сделать глубину видимой или согласовать цвет боков с заполнением передней грани. |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | Дополнительная 3D‑глубина, используемая в 3D‑форматировании PowerPoint. | Точно настроить глубину для фигур или текста, особенно совместно с настройками фаски и материала. |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | Поднятые или закруглённые кромки на передних и задних гранях. | Добавить смягчённый или формованный край вместо острого плоского. |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) and [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) and [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | Контур вокруг 3D‑объекта. | Подчеркнуть границу объекта в визуализированном выводе. |

## **Создание 3D‑фигуры**

Фигуре обычно требуются четыре типа настроек, чтобы выглядеть правдоподобно 3D:

- Настройки камеры, потому что вид по умолчанию спереди может скрывать экструзию.
- Настройки освещения, потому что свет делает видимыми грани и боковые стороны.
- Настройки материала, потому что поверхность влияет на отображение света.
- Настройки экструзии или глубины, потому что плоской фигуре нужна толщина.

В следующем примере создаётся прямоугольник, добавляется текст к его передней грани и применяется 3D‑форматирование. Значения вращения камеры указаны в градусах, высота экструзии — 100 пунктов. Пример визуализирует слайд в PNG‑изображении вдвое превышающем стандартные размеры и сохраняет презентацию как PPTX.

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

Отрисованное изображение слайда показывает прямоугольник как толстый 3D‑блок:

![Отображённый синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, которое задаётся через API камеры.

![Панель 3‑D Rotation в PowerPoint с выделенными значениями вращения X, Y и Z](img_02_01.png)

В Aspose.Slides доступ к камере осуществляется через [ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera). В этом примере создаётся прямоугольник, выбирается ортографический вид спереди, и его вращения по X, Y и Z устанавливаются соответственно в 20, 30 и 40 градусов. Фигура настраивается в памяти без сохранения файла:

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

Используйте камеру, когда необходимо изменить то, как зритель видит объект. Это не меняет 2D‑геометрию фигуры на слайде. Оно меняет 3D‑точку обзора, используемую PowerPoint и Aspose.Slides при визуализации.

### **Копирование ориентации камеры из шаблонной фигуры**

Чтобы совпасть с ориентацией шаблонной фигуры, прочитайте её предустановку камеры с помощью [Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) и её углы вращения с помощью [Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation). Пример открывает `template.pptx` и копирует ориентацию камеры из первой фигуры на первом слайде во вторую фигуру. Обе фигуры уже имеют 3D‑освещение, а у второй фигуры нет явного вращения камеры.

Углы задаются в градусах. Индекс `0` — широта, индекс `1` — долгота, индекс `2` — оборот. Передайте их в [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) в этом порядке. Если источник возвращает `null`, у него нет явного вращения, поэтому оставьте углы второй фигуры неустановленными. Явное вращение `(0, 0, 0)` возвращает три нуля и должно быть скопировано.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $sourceCamera = $shapes->get_Item(0)->getThreeDFormat()->getCamera();
    $destinationCamera = $shapes->get_Item(1)->getThreeDFormat()->getCamera();

    $destinationCamera->setCameraType($sourceCamera->getCameraType());
    $angles = java_values($sourceCamera->getRotation());
    if ($angles !== null) {
        $destinationCamera->setRotation($angles[0], $angles[1], $angles[2]);
    }

    $presentation->save("camera-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

При повторном открытии `camera-copy.pptx` в PowerPoint правая стрелка имеет ту же предустановку камеры и вращение, что и левый прямоугольник. Обе фигуры используют одинаковое освещение и глубину экструзии.

![Синий 3D‑прямоугольник и правая стрелка с совпадающей ориентацией камеры, вид сверху и справа](camera-orientation.png)

## **Добавление экструзии и глубины**

Экструзия делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint контроль глубины задаёт эту видимую толщину, а контроль цвета задаёт цвет боковых граней.

![Элементы управления глубиной в PowerPoint, связанные с цветом экструзии и свойством высоты экструзии](img_02_02.png)

Используйте [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) для установки толщины и [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) для доступа к цвету боков. В этом примере прямоугольнику задаётся экструзия 100 пунктов с пурпурными боками и камера вращается, чтобы показать толщину. Фигура настраивается в памяти без сохранения файла:

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

Метод [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) задаёт глубину 3D‑фигуры. Метод [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) управляет высотой эффекта экструзии, как показано в этом примере.

## **Использование градиентных или растровых заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Можно применить сплошной цвет, градиент, узор или растровую заливку к передней грани и при этом использовать те же настройки камеры, света, материала и экструзии.

В этом примере к передней грани применяется градиент от синего к оранжевому, а к экструзии 150 пунктов — тёмно‑оранжевый цвет. Остановки градиента на 0 и 100 обозначают начало и конец градиента. Значения вращения камеры указаны в градусах. Слайд визуализируется в PNG‑изображение вдвое превышающее стандартные размеры:

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

Отрисованный результат сохраняет градиент на передней грани и отдельно визуализирует экструзию:

![Отрисованный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевой экструзией](img_02_03.png)

Чтобы вместо этого использовать растровую заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры. В этом примере требуется существующий файл с именем "image.jpg" в рабочем каталоге. Изображение растягивается, заполняя прямоугольник, задаётся экструзия 150 пунктов и вращение камеры в градусах. Фигура настраивается в памяти без сохранения или визуализации файла:

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

Изображение визуализируется на передней грани, а экструзия – как 3D‑боковая поверхность:

![Отрисованный 3D‑прямоугольник с фотозаливкой на передней грани и оранжевой экструзией](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на тело фигуры. 3D‑форматирование текста влияет на текстовую рамку. Это полезно для эффектов, похожих на WordArt, когда сами буквы требуют экструзии, материала, освещения и настроек камеры.

В следующем примере создаётся текст с оранжево‑белой сеткой, применяется восходящий арочный изгиб и настраиваются 3D‑параметры через [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat). Высота экструзии и глубина указаны в пунктах, а вращение света — в градусах. Заливка и контур фигуры скрыты, так что виден только текст. Пример визуализирует PNG‑изображение вдвое превышающее стандартные размеры слайда и сохраняет презентацию как PPTX:

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

Текст отображается как изогнутый, экструдированный 3D‑текст:

![Отрисованный 3D‑текст с арочным трансформом WordArt, оранжевой узорной заливкой и темной экструзией](img_02_05.png)

## **Сохранение текста плоским на 3D‑фигуре**

Чтобы текст оставался читаемым, сохраняя 3D‑вид фигуры, вызовите [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat) через [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat). Когда значение `true`, текст находится вне 3D‑сцены. Когда `false`, текст участвует в сцене и следует её 3D‑ориентации.

Эта настройка не удаляет 3D‑форматирование фигуры: её камера, освещение, материал и экструзия остаются настроенными через [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat). Это также отличается от обычного вращения. [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) вращает фигуру в плоскости слайда, тогда как [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) контролирует пользовательское вращение текста внутри его ограничивающего прямоугольника. Сохранение текста вне 3D‑сцены не сбрасывает ни один из этих углов.

В следующем автономном примере создаётся синий прямоугольник с текстом и клонируется рядом с оригиналом. Обе фигуры имеют одинаковое 3D‑форматирование; различается только настройка текста: `false` слева и `true` справа. Углы камеры указаны в градусах, высота экструзии — 40 пунктов. Пример сохраняет презентацию как PPTX и визуализирует сравнительный слайд в PNG вдвое превышающий стандартные размеры.

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

Слева текст следует 3D‑ориентации. Справа он остаётся плоским и легче читаемым. Оба прямоугольника сохраняют одинаковую видимую экструзию и 3D‑ориентацию.

![Параллельно расположенные 3D‑прямоугольники: текст следует 3D‑ориентации слева и остаётся плоским справа](keep_text_flat.png)

## **Экспорт и поведение при визуализации**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При визуализации или экспорте в форматы фиксированной разметки 3D‑сцена растеризуется или вписывается в вывод как 2D‑результат. Это относится к визуализации слайдов в [PNG](/slides/ru/php-java/convert-powerpoint-to-png/), экспорту в [PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/), экспорту в [HTML](/slides/ru/php-java/convert-powerpoint-to-html/), или генерации кадров для [video conversion](/slides/ru/php-java/convert-powerpoint-to-video/).

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать зрителем после экспорта.
- Окончательный вид зависит от комбинации камеры, световой установки, материала, экструзии, заливки и масштаба слайда.
- Если необходимо просмотреть унаследованные или основанные на теме значения форматирования, читайте [эффективные свойства фигуры](/slides/ru/php-java/shape-effective-properties/).
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат визуализируется, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создает и визуализирует 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые зритель мог бы вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат это поддерживает.

**В чём разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, такое как вращение, экструзия, фаска, освещение и материал. Эта статья охватывает 3D‑эффекты.

**Какие настройки требуются для видимой 3D‑фигуры?**

Минимум — задать вращение камеры и либо экструзию, либо глубину. На практике также следует задать световую установку и материал, чтобы отрисованные грани имели чёткие блики и тени.

**Можно ли применять 3D‑эффекты и к фигурам, и к тексту?**

Да. Используйте [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) для тела фигуры и [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) для текста.

**Появятся ли 3D‑эффекты при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides визуализирует 3D‑эффекты при создании изображений слайдов, вывода PDF, вывода HTML и кадров для видеоконвертации. Экспортируемый результат содержит отрисованный внешний вид, а не редактируемый 3D‑объект.

**Можно ли считать окончательные 3D‑значения после применения наследования и настроек темы?**

Да. Используйте API эффективного форматирования, описанные в [эффективные свойства фигуры](/slides/ru/php-java/shape-effective-properties/), чтобы прочитать окончательные значения камеры, световой установки, фаски и связанных 3D‑параметров.