---
title: Создание и применение эффектов WordArt в PHP
linktitle: WordArt
type: docs
weight: 110
url: /ru/php-java/wordart/
keywords:
- WordArt
- создать WordArt
- шаблон WordArt
- эффект WordArt
- эффект тени
- эффект отображения
- эффект свечения
- трансформация WordArt
- 3D-эффект
- эффект внешней тени
- эффект внутренней тени
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создание и настройка эффектов WordArt в Aspose.Slides для PHP через Java. Это пошаговое руководство помогает разработчикам улучшать презентации с профессиональным оформлением текста."
---

## **О WordArt?**
WordArt или Word Art — это функция, позволяющая применять эффекты к тексту, чтобы он выделялся. С помощью WordArt, например, можно обвести текст контуром или заполнить его цветом (или градиентом), добавить 3D‑эффекты и т.д. Вы также можете наклонять, изгибать и растягивать форму текста. 

{{% alert color="primary" %}} 
WordArt позволяет обращаться с текстом так же, как с графическим объектом. Как правило, WordArt состоит из эффектов или специальных модификаций, применяемых к тексту, чтобы сделать его более привлекательным или заметным. 
{{% /alert %}} 

**WordArt в Microsoft PowerPoint**

Чтобы использовать WordArt в Microsoft PowerPoint, необходимо выбрать один из предопределённых шаблонов WordArt. Шаблон WordArt представляет собой набор эффектов, которые применяются к тексту или его форме. 

**WordArt в Aspose.Slides**

В Aspose.Slides for PHP via Java 20.10 мы реализовали поддержку WordArt и внесли улучшения в эту функцию в последующих выпусках Aspose.Slides for PHP via Java.  
С помощью Aspose.Slides for PHP via Java вы можете легко создать собственный шаблон WordArt (один эффект или комбинацию эффектов) и применить его к текстам. 

## **Создать простой шаблон WordArt и применить его к тексту**

**Использование Aspose.Slides** 

Сначала мы создаём простой текст с помощью этого PHP‑кода:
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

Затем мы устанавливаем высоту шрифта текста на более крупное значение, чтобы эффект был заметнее, с помощью этого кода:
```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);
```


**Использование Microsoft PowerPoint**

Перейдите в меню эффектов WordArt в Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

В меню справа можно выбрать предопределённый эффект WordArt. В меню слева можно задать параметры для нового WordArt.  

Ниже представлены некоторые доступные параметры или опции:

![todo:image_alt_text](image-20200930114015-3.png)

**Использование Aspose.Slides**

Здесь мы применяем цвет шаблона [SmallGrid](https://reference.aspose.com/slides/php-java/aspose.slides/PatternStyle#SmallGrid) к тексту и добавляем чёрную обводку текстовой рамки толщиной 1 с помощью этого кода:
```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
```


Получившийся текст:

![todo:image_alt_text](image-20200930114108-4.png)

## **Применить другие эффекты WordArt**

**Использование Microsoft PowerPoint**

Из интерфейса программы можно применять эти эффекты к тексту, блоку текста, фигуре или аналогичному элементу:

![todo:image_alt_text](image-20200930114129-5.png)

Например, к тексту могут применяться эффекты Тень, Отражение и Свечение; к блоку текста — эффекты 3D Формат и 3D Поворот; к объекту Shape может применяться свойство Мягкие края (оно работает даже если не установлен параметр 3D Формат). 

### **Применить эффекты тени**

Здесь мы намерены установить свойства, относящиеся только к тексту. Мы применяем эффект тени к тексту с помощью этого кода :
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


Aspose.Slides API поддерживает три типа теней: OuterShadow, InnerShadow и PresetShadow.  
С помощью PresetShadow можно применить тень к тексту (используя предустановленные значения).  

**Использование Microsoft PowerPoint**

В PowerPoint можно использовать один тип тени. Пример:

![todo:image_alt_text](image-20200930114225-6.png)

**Использование Aspose.Slides**

Aspose.Slides действительно позволяет применять одновременно два типа теней: InnerShadow и PresetShadow.  

**Примечания:**
- Когда одновременно используются OuterShadow и PresetShadow, применяется только эффект OuterShadow.  
- Если одновременно используются OuterShadow и InnerShadow, итоговый эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется эффект OuterShadow.  

### **Применить эффекты отражения к тексту**

Мы добавляем отражение к тексту с помощью этого примера кода :
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


### **Применить эффекты свечения к тексту**

Мы применяем эффект свечения к тексту, чтобы он светился или выделялся, с помощью этого кода:
```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```


Результат выполнения:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Вы можете менять параметры для тени, отображения и свечения. Свойства эффектов задаются отдельно для каждой части текста. 
{{% /alert %}} 

### **Использовать трансформации в WordArt**

Мы используем свойство Transform (присущее всему блоку текста) с помощью этого кода:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```


Результат:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
И Microsoft PowerPoint, и Aspose.Slides for PHP via Java предоставляют определённое количество предопределённых типов трансформаций. 
{{% /alert %}} 

**Использование PowerPoint**

Чтобы получить доступ к предопределённым типам трансформаций, перейдите: **Format** -> **TextEffect** -> **Transform**  

**Использование Aspose.Slides**

Для выбора типа трансформации используйте перечисление TextShapeType.  

### **Применить 3D‑эффекты к тексту и фигурам**

Мы задаём 3D‑эффект текстовой фигуре с помощью этого примера кода:
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


Получившийся текст и его форма:

![todo:image_alt_text](image-20200930114816-9.png)

Мы применяем 3D‑эффект к тексту с помощью этого PHP‑кода:
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


Результат выполнения:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
Применение 3D‑эффектов к текстам или их фигурам и взаимодействие между эффектами основаны на определённых правилах.  
Рассмотрим сцену для текста и фигуры, содержащей этот текст. 3D‑эффект включает представление 3D‑объекта и сцену, в которой объект размещён.  

- Если сцена задана как для фигуры, так и для текста, приоритет имеет сцена фигуры — сцена текста игнорируется.  
- Если у фигуры нет собственной сцены, но есть 3D‑представление, используется сцена текста.  
- В остальных случаях, когда у фигуры изначально нет 3D‑эффекта, фигура остаётся плоской, и 3D‑эффект применяется только к тексту.  

Эти описания связаны с методами ThreeDFormat.getLightRig() и ThreeDFormat.getCamera().  
{{% /alert %}} 

## **Применить внешние тени к тексту**
Aspose.Slides for PHP via Java предоставляет классы [**IOuterShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IOuterShadow) и [**IInnerShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IInnerShadow), позволяющие применять эффекты тени к тексту, содержащемуся в [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame). Выполните следующие шаги:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
2. Получить ссылку на слайд, используя его индекс.  
3. Добавить к слайду AutoShape типа Rectangle.  
4. Получить доступ к TextFrame, связанному с AutoShape.  
5. Установить свойство FillType у AutoShape в значение NoFill.  
6. Создать экземпляр класса OuterShadow.  
7. Задать BlurRadius тени.  
8. Задать Direction тени.  
9. Задать Distance тени.  
10. Установить RectanglelAlign в TopLeft.  
11. Задать PresetColor тени в Black.  
12. Сохранить презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Этот пример кода — реализация перечисленных шагов — демонстрирует, как применить внешний эффект тени к тексту:
```php
  $pres = new Presentation();
  try {
    # Получить ссылку на слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Добавить TextFrame к прямоугольнику
    $ashp->addTextFrame("Aspose TextBox");
    # Отключить заливку фигуры, если нужно получить тень текста
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Добавить внешнюю тень и задать все необходимые параметры
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # Сохранить презентацию на диск
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Применить внутренние тени к фигурам**
Выполните следующие шаги:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
2. Получить ссылку на слайд.  
3. Добавить AutoShape типа Rectangle.  
4. Включить InnerShadowEffect.  
5. Задать все необходимые параметры.  
6. Установить ColorType как Scheme.  
7. Задать Scheme Color.  
8. Сохранить презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Этот пример кода (основанный на перечисленных шагах) показывает, как добавить соединитель между двумя фигурами :
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
    # Установить Scheme Color
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # Сохранить презентацию
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Часто задаваемые вопросы**

**Можно ли использовать эффекты WordArt с разными шрифтами или скриптами (например, арабский, китайский)?**  
Да, Aspose.Slides поддерживает Unicode и работает со всеми крупными шрифтами и скриптами. Эффекты WordArt, такие как тень, заливка и контур, могут применяться независимо от языка, хотя наличие шрифтов и их отображение могут зависеть от системных шрифтов.

**Можно ли применять эффекты WordArt к элементам шаблона слайдов?**  
Да, вы можете применять эффекты WordArt к фигурам на мастер‑слайдах, включая заполнители заголовков, нижние колонтитулы или фоновой текст. Изменения, внесённые в макет мастера, отразятся на всех связанных слайдами.

**Влияют ли эффекты WordArt на размер файла презентации?**  
Незначительно. Эффекты WordArt, такие как тени, свечение и градиентные заливки, могут немного увеличить размер файла из‑за дополнительной метаданных форматирования, но разница обычно несущественная.

**Можно ли просмотреть результат эффектов WordArt без сохранения презентации?**  
Да, вы можете отрисовать слайды с WordArt в изображения (например, PNG, JPEG), используя метод `getImage` из интерфейсов [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) или [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/). Это позволяет предварительно просмотреть результат в памяти или на экране до сохранения или экспорта полной презентации.