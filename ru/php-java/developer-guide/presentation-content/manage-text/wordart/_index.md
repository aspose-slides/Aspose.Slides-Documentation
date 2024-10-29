---
title: WordArt
type: docs
weight: 110
url: /ru/php-java/wordart/
---


## **Что такое WordArt?**
WordArt или Word Art — это функция, которая позволяет применять эффекты к текстам, чтобы сделать их более привлекательными. С помощью WordArt, например, вы можете обвести текст или залить его цветом (или градиентом), добавить к нему 3D эффекты и т.д. Вы также можете искажать, изгибать и растягивать форму текста.

{{% alert color="primary" %}} 

WordArt позволяет рассматривать текст так, как вы рассматриваете графический объект. В общем, WordArt состоит из эффектов или специальных модификаций, произведенных над текстами, чтобы сделать их более привлекательными или заметными.

{{% /alert %}} 

**WordArt в Microsoft PowerPoint**

Чтобы использовать WordArt в Microsoft PowerPoint, вам нужно выбрать один из предопределенных шаблонов WordArt. Шаблон WordArt — это набор эффектов, который применяется к тексту или его форме.

**WordArt в Aspose.Slides**

В Aspose.Slides для PHP через Java 20.10 была реализована поддержка WordArt и внесены улучшения в эту функцию в последующих релизах Aspose.Slides для PHP через Java.

С Aspose.Slides для PHP через Java вы можете легко создать свой собственный шаблон WordArt (один эффект или комбинацию эффектов) и применить его к текстам.

## Создание простого шаблона WordArt и его применение к тексту

**Использование Aspose.Slides**

Сначала создадим простой текст с помощью следующего PHP-кода:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
Теперь мы задаем высоту шрифта текста на большее значение, чтобы эффект был более заметным, с помощью этого кода:

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```

**Использование Microsoft PowerPoint**

Перейдите в меню эффектов WordArt в Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Из меню справа вы можете выбрать предопределенный эффект WordArt. Из меню слева вы можете задать настройки для нового WordArt.

Вот некоторые из доступных параметров или опций:

![todo:image_alt_text](image-20200930114015-3.png)

**Использование Aspose.Slides**

Здесь мы применяем цвет паттерна [SmallGrid](https://reference.aspose.com/slides/php-java/aspose.slides/PatternStyle#SmallGrid) к тексту и добавляем черную рамку шириной 1 с помощью этого кода:

```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

```

Результирующий текст:

![todo:image_alt_text](image-20200930114108-4.png)

## Применение других эффектов WordArt

**Использование Microsoft PowerPoint**

Из интерфейса программы вы можете применять эти эффекты к тексту, текстовому блоку, форме или аналогичному элементу:

![todo:image_alt_text](image-20200930114129-5.png)

Например, эффекты тени, отражения и свечения могут быть применены к тексту; 3D формат и 3D вращение могут быть применены к текстовому блоку; свойство мягких краев может быть применено к объекту формы (оно все равно оказывает эффект, когда ни одно свойство 3D формата не задано).

### Применение эффектов тени

Здесь мы собираемся установить свойства, касающиеся только текста. Мы применяем эффект тени к тексту с помощью этого кода:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(65);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4.73);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(2);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(30);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.32);

```

API Aspose.Slides поддерживает три типа теней: OuterShadow, InnerShadow и PresetShadow.

С помощью PresetShadow вы можете применить тень к тексту (с использованием предустановленных значений).

**Использование Microsoft PowerPoint**

В PowerPoint вы можете использовать один тип тени. Вот пример:

![todo:image_alt_text](image-20200930114225-6.png)

**Использование Aspose.Slides**

Aspose.Slides на самом деле позволяет применять два типа теней одновременно: InnerShadow и PresetShadow.

**Примечания:**

- Когда OuterShadow и PresetShadow используются вместе, применяется только эффект OuterShadow.
- Если одновременно используются OuterShadow и InnerShadow, итоговый или примененный эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается. Но в PowerPoint 2007 применяется эффект OuterShadow.

### Применение отражения к текстам

Мы добавляем отражение к тексту с помощью этого примера кода:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->BottomLeft);

```

### Применение эффекта свечения к текстам

Мы применяем эффект свечения к тексту, чтобы он сиял или выделялся, с помощью этого кода:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);

```

Результат операции:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Вы можете изменять параметры для тени, отражения и свечения. Свойства эффектов задаются для каждой части текста отдельно.

{{% /alert %}} 

### Использование трансформаций в WordArt

Мы используем свойство Transform (присущее всему блоку текста) с помощью этого кода:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);

```

Результат:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Как Microsoft PowerPoint, так и Aspose.Slides для PHP через Java предоставляют определенное количество предопределенных типов преобразования.

{{% /alert %}} 

**Использование PowerPoint**

Чтобы получить доступ к предопределенным типам преобразования, перейдите по следующему пути: **Формат** -> **ЭффектТекста** -> **Трансформация**

**Использование Aspose.Slides**

Чтобы выбрать тип преобразования, используйте перечисление TextShapeType.

### Применение 3D эффектов к текстам и формам

Мы устанавливаем 3D эффект для текстовой формы с помощью этого образца кода:

```php
  $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
  $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);
  $autoShape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $autoShape->getThreeDFormat()->setExtrusionHeight(6);
  $autoShape->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $autoShape->getThreeDFormat()->setContourWidth(1.5);
  $autoShape->getThreeDFormat()->setDepth(3);
  $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

```

Результирующий текст и его форма:

![todo:image_alt_text](image-20200930114816-9.png)

Мы применяем 3D эффект к тексту с помощью этого PHP-кода:

```php
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

```

Результат операции:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Применение 3D эффектов к текстам или их формам и взаимодействие между эффектами основаны на определенных правилах. 

Рассмотрим сцену для текста и формы, содержащей этот текст. 3D эффект включает в себя представление 3D объекта и сцену, на которой объект был размещен.

- Когда сцена задана как для фигуры, так и для текста, приоритет отдается сцене фигуры — сцена текста игнорируется. 
- Когда у фигуры отсутствует собственная сцена, но есть 3D представление, используется сцена текста. 
- В противном случае — когда форма изначально не имеет 3D эффекта — форма плоская, и 3D эффект применяется только к тексту. 

Эти описания связаны с методами ThreeDFormat.getLightRig() и ThreeDFormat.getCamera().

{{% /alert %}} 

## **Применение эффектов внешней тени к текстам**
Aspose.Slides для PHP через Java предоставляет классы [**IOuterShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IOuterShadow) и [**IInnerShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IInnerShadow), которые позволяют применять эффекты тени к тексту, содержащемуся в [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame). Следуйте этим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте AutoShape типа Rectangle на слайд.
4. Получите доступ к TextFrame, связанному с AutoShape.
5. Установите FillType для AutoShape на NoFill.
6. Создайте экземпляр класса OuterShadow.
7. Установите BlurRadius для тени.
8. Установите Direction для тени.
9. Установите Distance для тени.
10. Установите RectangleAlign на TopLeft.
11. Установите PresetColor для тени на черный.
12. Запишите презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

Этот пример кода — реализация указанных выше шагов — показывает, как применить эффект внешней тени к тексту:

```php
  $pres = new Presentation();
  try {
    # Получить ссылку на слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Добавить TextFrame к прямоугольнику
    $ashp->addTextFrame("Aspose TextBox");
    # Отключить заливку фигуры, чтобы получить тень текста
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Добавить внешнюю тень и установить все необходимые параметры
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # Записать презентацию на диск
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Применение эффекта внутренней тени к формам**
Следуйте этим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Получите ссылку на слайд.
3. Добавьте AutoShape типа Rectangle.
4. Включите InnerShadowEffect.
5. Установите все необходимые параметры.
6. Установите ColorType как Scheme.
7. Установите цвет схемы.
8. Запишите презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

Этот пример кода (на основе вышеуказанных шагов) показывает, как добавить соединитель между двумя формами:

```php
  $pres = new Presentation();
  try {
    # Получить ссылку на слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Добавить TextFrame к прямоугольнику
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # Включить InnerShadowEffect
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # Установить все необходимые параметры
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # Установить ColorType как Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # Установить цвет схемы
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # Сохранить презентацию
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```