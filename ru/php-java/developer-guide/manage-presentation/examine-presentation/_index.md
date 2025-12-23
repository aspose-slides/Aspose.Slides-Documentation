---
title: Получить и обновить информацию о презентации в PHP
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/php-java/examine-presentation/
keywords:
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- читать свойства
- изменить свойства
- модифицировать свойства
- обновить свойства
- анализировать PPTX
- анализировать PPT
- анализировать ODP
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Исследуйте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for PHP для более быстрых аналитических выводов и более умных проверок контента."
---

Aspose.Slides for PHP via Java позволяет изучать презентацию, чтобы узнать её свойства и понять её поведение.

{{% alert title="Info" color="info" %}} 

Классы [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) и [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) содержат свойства и методы, используемые в этих операциях.

{{% /alert %}} 

## **Проверка формата презентации**

Прежде чем работать с презентацией, вам может потребоваться узнать, в каком формате (PPT, PPTX, ODP и др.) она находится в данный момент.

Вы можете проверить формат презентации без её загрузки. См. этот код PHP:
```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```


## **Получение свойств презентации**

Этот код PHP показывает, как получить свойства презентации (информацию о презентации):
```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```


Возможно, вы захотите увидеть [свойства в классе DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Обновление свойств презентации**

Aspose.Slides предоставляет метод [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) , который позволяет вносить изменения в свойства презентации.

Предположим, у нас есть презентация PowerPoint со свойствами документа, отображёнными ниже.

![Исходные свойства документа презентации PowerPoint](input_properties.png)

Этот пример кода показывает, как изменить некоторые свойства презентации:
```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```


Результаты изменения свойств документа показаны ниже.

![Изменённые свойства документа презентации PowerPoint](output_properties.png)

## **Полезные ссылки**

Чтобы получить больше информации о презентации и её атрибутах безопасности, вам могут пригодиться следующие ссылки:

- [Проверка, зашифрована ли презентация](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Проверка, защищена ли презентация от записи (только чтение)](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Проверка, защищена ли презентация паролем перед загрузкой](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Подтверждение пароля, используемого для защиты презентации](https://docs.aspose.com/slides/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Как проверить, встроены ли шрифты и какие именно?**

Ищите [информацию о встроенных шрифтах](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getembeddedfonts/) на уровне презентации, затем сравните эти записи с набором [фактически используемых шрифтов](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getfonts/)…, чтобы определить, какие шрифты критичны для рендеринга.

**Как быстро определить, содержит ли файл скрытые слайды и их количество?**

Пройдитесь по [коллекции слайдов](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) и проверьте [флаг видимости](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/) каждого слайда.

**Можно ли определить, используется ли пользовательский размер и ориентация слайда, и отличаются ли они от стандартных?**

Да. Сравните текущий [размер слайда](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslidesize/) и ориентацию со стандартными предустановками; это помогает предвидеть поведение при печати и экспорте.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Пройдитесь по всем [диаграммам](https://reference.aspose.com/slides/php-java/aspose.slides/chart/), проверьте их [источник данных](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/), и отметьте, являются ли данные внутренними или ссылочными, включая любые битые ссылки.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Для каждого слайда подсчитайте количество объектов и ищите крупные изображения, прозрачность, тени, анимацию и мультимедиа; присвойте приблизительный показатель сложности, чтобы отметить потенциальные узкие места в производительности.