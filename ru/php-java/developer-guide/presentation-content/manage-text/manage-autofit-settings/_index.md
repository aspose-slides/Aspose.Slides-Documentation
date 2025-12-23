---
title: Повышайте качество презентаций с AutoFit в PHP
linktitle: Настройки AutoFit
type: docs
weight: 30
url: /ru/php-java/manage-autofit-settings/
keywords:
- текстовое поле
- автоподгонка
- не автоподгонка
- подгонка текста
- сжатие текста
- перенос текста
- изменение размера фигуры
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Управляйте настройками AutoFit в Aspose.Slides для PHP, чтобы оптимизировать отображение текста в ваших презентациях PowerPoint и OpenDocument и улучшить читаемость контента."
---

По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует параметр **Изменить размер фигуры, чтобы зафиксировать текст** для этого поля — он автоматически изменяет размер текстового поля, чтобы его текст всегда помещался в нём. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или больше, PowerPoint автоматически увеличивает высоту текстового поля, чтобы оно могло вместить больше текста. 
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает высоту текстового поля, удаляя лишнее пространство. 

В PowerPoint существуют 4 важных параметра или опции, управляющих поведением автоподгонки для текстового поля: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for PHP via Java предоставляет аналогичные параметры — некоторые свойства класса [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat), позволяющие управлять поведением автоподгонки для текстовых полей в презентациях.

## **Изменить размер фигуры, чтобы соответствовать тексту**

Если вы хотите, чтобы текст в рамке всегда помещался в рамку после изменения текста, необходимо использовать параметр **Resize shape to fix text**. Чтобы задать этот параметр, установите свойство [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) в `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Этот PHP‑код показывает, как указать, что текст всегда должен помещаться в свою рамку в презентации PowerPoint:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Если текст становится длиннее или больше, текстовое поле будет автоматически изменено (увеличена высота), чтобы весь текст поместился. Если текст становится короче, произойдёт обратное действие. 

## **Do Not Autofit**

Если вы хотите, чтобы текстовое поле или фигура сохраняли свои размеры независимо от изменений текста, необходимо использовать параметр **Do not Autofit**. Чтобы задать этот параметр, установите свойство [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) в `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Этот PHP‑код показывает, как указать, что текстовое поле всегда должно сохранять свои размеры в презентации PowerPoint:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Когда текст становится слишком длинным для своей рамки, он выходит за её пределы. 

## **Shrink Text on Overflow**

Если текст становится слишком длинным для своей рамки, с помощью параметра **Shrink text on overflow** можно задать уменьшение размера и межбуквенного интервала текста, чтобы он уместился в рамке. Чтобы задать этот параметр, установите свойство [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) в `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Этот PHP‑код показывает, как указать, что текст должен уменьшаться при переполнении в презентации PowerPoint:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Info" color="info" %}}
При использовании параметра **Shrink text on overflow** настройка применяется только тогда, когда текст становится слишком длинным для своей рамки. 
{{% /alert %}}

## **Wrap Text**

Если вы хотите, чтобы текст в фигуре переносился внутри этой фигуры, когда текст превышает её границу (только по ширине), используйте параметр **Wrap text in shape**. Чтобы задать эту настройку, установите свойство [WrapText](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getWrapText--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) в `true`.

Этот PHP‑код показывает, как использовать параметр Wrap Text в презентации PowerPoint:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Note" color="warning" %}} 
Если установить свойство `WrapText` в `False` для фигуры, когда текст внутри фигуры становится шире её границы, текст будет вытягиваться за пределы фигуры в одну строку. 
{{% /alert %}}

## **FAQ**

**Влияют ли внутренние отступы рамки текста на AutoFit?**

Да. Внутренние отступы уменьшают доступную площадь для текста, поэтому AutoFit срабатывает раньше — шрифт уменьшается или фигура изменяется быстрее. Проверьте и настройте отступы перед настройкой AutoFit.

**Как AutoFit взаимодействует с ручными и мягкими разрывами строк?**

Принудительные разрывы остаются на месте, а AutoFit подбирает размер шрифта и интервалы вокруг них. Удаление ненужных разрывов часто уменьшает необходимость сильного сжатия текста.

**Влияют ли изменение темы шрифта или подстановка шрифта на результаты AutoFit?**

Да. Подстановка шрифта с другими метрическими характеристиками меняет ширину/высоту текста, что может изменить конечный размер шрифта и перенос строк. После любой замены шрифта повторно проверьте слайды.