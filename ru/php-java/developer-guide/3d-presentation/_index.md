---
title: Создание 3D-эффектов в презентациях с использованием PHP
linktitle: 3D-презентация
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
description: "Применяйте и рендерите 3D-эффекты для фигур и текста PowerPoint в PHP с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, экструзию, заливки и 3D-текст."
---
## **Обзор**

Aspose.Slides для PHP через Java может создавать, редактировать, сохранять и отображать 3D‑форматирование в стиле PowerPoint для фигур и текста. Эта статья охватывает 3D‑эффекты, такие как вращение, экструзия, фаски, освещение, материал, градиентные или растровые заливки и 3D‑текст.

{{% alert color="primary" %}}
Эта статья посвящена 3D‑форматирующим эффектам для фигур и текста PowerPoint. Она не касается вставки или редактирования отдельных файлов 3D‑моделей. При экспорте слайда в изображение, PDF или HTML Aspose.Slides рендерит эти 3D‑эффекты в экспортированный 2D‑вывод.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте класс [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/) и его метод [Shape::getThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#getThreeDFormat--) чтобы применить 3D‑форматирование к фигуре. Метод возвращает [ThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте класс [TextFrameFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/) и его метод [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#getThreeDFormat--) . Это применяет 3D‑форматирование к текстовой рамке вместо тела фигуры.

Самые важные настройки:

| Метод или параметр | Что контролирует | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getCamera--) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращение объекта в 3D‑пространстве или соответствие предустановке вращения 3D в PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getLightRig--) | Предустановка света, направление и вращение света. | Изменение отображения бликов и теней на 3D‑поверхности. |
| [setMaterial](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одну и ту же геометрию выглядящей более плоской, мягкой, блестящей или металлической. |
| [setExtrusionHeight](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Насколько далеко фигура выдвигается назад от её передней грани. | Преобразовать плоскую фигуру в визуально толстый 3D‑объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Цвет экструдированных боковых граней. | Сделать глубину видимой или согласовать цвет боков с заливкой передней грани. |
| [setDepth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#setDepth-double-) | Дополнительная 3D‑глубина, используемая в 3D‑форматировании PowerPoint. | Точная настройка глубины для фигур или текста, особенно совместно с настройками фасок и материала. |
| [getBevelTop](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getBevelTop--) и [getBevelBottom](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getBevelBottom--) | Поднятые или закруглённые кромки на передних и задних гранях. | Добавить смягчённую или сформованную кромку вместо острого плоского края. |
| [getContourColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getContourColor--) и [setContourWidth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Контур вокруг 3D‑объекта. | Подчеркнуть границу объекта в результирующем изображении. |

## **Создание 3D‑фигуры**

Обычно фигуре требуются четыре типа настроек, чтобы выглядеть убедительно в 3D:

- Настройки камеры, так как вид спереди по умолчанию может скрывать экструзию.  
- Настройки света, так как освещение делает грани и боковые поверхности разборчивыми.  
- Настройки материала, так как поверхность влияет на отображение света.  
- Настройки экструзии или глубины, так как плоской фигуре требуется толщина.

Следующий пример создаёт прямоугольник, добавляет текст на его переднюю грань, применяет 3D‑форматирование, сохраняет презентацию как PPTX и рендерит слайд в PNG‑изображение.

```php
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

Отображённый синий 3D‑прямоугольник с белым 3D‑текстом на передней грани:

![Отображённый синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, которое задаётся через API камеры.

![Окно 3‑D‑вращения PowerPoint с выделенными значениями вращения по X, Y и Z](img_02_01.png)

В Aspose.Slides задайте тип камеры и вращение через [ThreeDFormat::getCamera](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getCamera--):

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

Используйте камеру, когда необходимо изменить то, как зритель видит объект. Это не меняет 2D‑геометрию фигуры на слайде. Это меняет 3D‑точку обзора, используемую PowerPoint и Aspose.Slides при рендеринге.

## **Добавление экструзии и глубины**

Экструзия делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint элемент управления глубиной задаёт эту видимую толщину, а элемент управления цветом задаёт цвет боковых граней.

![Элементы управления глубиной в PowerPoint, сопоставленные с параметрами цвета экструзии и высоты экструзии](img_02_02.png)

Установите [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) для толщины и [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#getExtrusionColor--) для цвета боков:

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

Используйте [ThreeDFormat::setDepth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/#setDepth-double-), когда необходимо работать напрямую со значением глубины PowerPoint или комбинировать глубину с фаской, материалом и эффектами текста. Во многих сценариях фигур `setExtrusionHeight` является более понятной настройкой, поскольку она непосредственно выражает видимую экструзию.

## **Использование градиентных или растровых заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или растровую заливку к передней грани и при этом использовать те же настройки камеры, света, материала и экструзии.

Этот пример применяет градиентную заливку к фигуре и более тёмный цвет экструзии к боковым граням:

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

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

Отображённый результат сохраняет градиент на передней грани и рендерит экструзию отдельно:

![Отображённый 3D‑прямоугольник с синей‑оранжевой градиентной заливкой и оранжевой экструзией](img_02_03.png)

Чтобы использовать вместо этого растровую заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры:

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

Растровая заливка отображается на передней грани, а экструзия – как 3D‑поверхность боков:

![Отображённый 3D‑прямоугольник с фото‑заливкой на передней грани и оранжевой экструзией](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на тело фигуры. 3D‑форматирование текста влияет на текстовую рамку. Это полезно для эффектов, похожих на WordArt, где самим буквам нужны экструзия, материал, освещение и настройки камеры.

Следующий пример создаёт текст с узорчатой заливкой, применяет трансформацию WordArt и настраивает 3D‑параметры на [TextFrameFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/):

```php
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
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
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

Текст отображается как изогнутые, экструзированные 3D‑буквы:

![Отображённый 3D‑текст с арочной трансформацией WordArt, оранжевой узорчатой заливкой и тёмной экструзией](img_02_05.png)

## **Поведение при экспорте и рендеринге**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированной разметки 3D‑сцена растрируется или наносится в вывод как 2D‑результат. Это применяется, когда вы рендерите слайды в [PNG](/slides/ru/php-java/convert-powerpoint-to-png/), экспортируете в [PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/), экспортируете в [HTML](/slides/ru/php-java/convert-powerpoint-to-html/), или генерируете кадры для [video conversion](/slides/ru/php-java/convert-powerpoint-to-video/).

Имейте в виду следующие моменты:

- Экспортированные изображения и PDF не являются интерактивными. Объект нельзя вращать после экспорта.  
- Окончательный вид зависит от сочетания камеры, световой установки, материала, экструзии, заливки и масштабирования слайда.  
- Если необходимо изучить унаследованные или тематические значения форматирования, читайте [effective shape properties](/slides/ru/php-java/shape-effective-properties/).  
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат рендерится, а не сохраняется как редактируемые 3D‑настройки.

## **Вопросы и ответы**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**  
Aspose.Slides создаёт и рендерит 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь мог бы вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат это поддерживает.

**В чём разница между 3D‑моделью и 3D‑эффектом?**  
3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, такое как вращение, экструзия, фаска, освещение и материал. В этой статье рассматриваются 3D‑эффекты.

**Какие настройки требуются для видимой 3D‑фигуры?**  
Минимум — установить вращение камеры и либо экструзию, либо глубину. На практике также задаются световая установка и материал, чтобы поверхности имели чёткие блики и тени.

**Можно ли применять 3D‑эффекты как к фигурам, так и к тексту?**  
Да. Используйте [Shape::getThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#getThreeDFormat--) для тела фигуры и [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#getThreeDFormat--) для текста.

**Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?**  
Да. Aspose.Slides рендерит 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконвертации. Экспортированный файл содержит отрендеренный вид, а не редактируемый 3D‑объект.

**Можно ли прочитать конечные 3D‑значения после применения наследования и тем?**  
Да. Используйте API эффективного форматирования, описанные в [Shape Effective Properties](/slides/ru/php-java/shape-effective-properties/), чтобы получить окончательные значения камеры, световой установки, фаски и связанных 3D‑параметров.