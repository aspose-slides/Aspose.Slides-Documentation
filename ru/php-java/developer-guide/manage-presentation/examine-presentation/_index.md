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
- просмотр PPTX
- просмотр PPT
- просмотр ODP
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Изучайте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для PHP для более быстрых аналитических выводов и умных аудитов контента."
---
## **Обзор**

В этой статье показано, как просматривать информацию о презентации в Aspose.Slides. Описывается, как определить текущий формат презентации без загрузки полного файла, прочитать её свойства документа и при необходимости обновить эти свойства.

Примеры основаны на API [PresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/) и [DocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/) и демонстрируют типичные операции работы с метаданными презентации.

## **Проверить формат презентации**

Прежде чем работать с презентацией, вам может понадобиться узнать, в каком формате (PPT, PPTX, ODP и другие) она находится в данный момент.

Вы можете проверить формат презентации без её загрузки. См. следующий PHP‑код:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Получить свойства презентации**

Этот PHP‑код показывает, как получить свойства презентации (информацию о презентации):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

Возможно, вам будет интересно увидеть [свойства в классе DocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Обновить свойства презентации**

Aspose.Slides предоставляет метод [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), позволяющий вносить изменения в свойства презентации.

Предположим, у нас есть презентация PowerPoint со свойствами документа, показанными ниже.

![Исходные свойства документа PowerPoint‑презентации](input_properties.png)

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

![Изменённые свойства документа PowerPoint‑презентации](output_properties.png)

## **Полезные ссылки**

Чтобы получить больше информации о презентации и её атрибутах безопасности, могут быть полезны следующие ссылки:

- [Защита презентаций паролем](/slides/ru/php-java/password-protected-presentation/)
- [Защита презентаций от записи](/slides/ru/php-java/write-protected-presentation/)

## **FAQ**

**Как проверить, встроены ли шрифты и какие именно?**

Ищите [информацию о встроенных шрифтах](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/getembeddedfonts/) на уровне презентации, затем сравните эти записи с набором [фактически используемых шрифтов](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/getfonts/), чтобы определить, какие шрифты критичны для отображения.

**Как быстро узнать, есть ли скрытые слайды и их количество?**

Пройдите по [коллекции слайдов](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidecollection/) и проверьте у каждого слайда [флаг видимости](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/gethidden/).

**Можно ли определить, использованы ли пользовательские размер и ориентация слайда, и отличаются ли они от значений по умолчанию?**

Да. Сравните текущий [размер слайда](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/getslidesize/) и ориентацию со стандартными настройками; это помогает предсказать поведения при печати и экспорте.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Пройдите все [диаграммы](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/), проверьте их [источник данных](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/getdatasourcetype/) и отметьте, являются ли данные внутренними или ссылочными, включая любые битые ссылки.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Для каждого слайда подсчитайте количество объектов и ищите большие изображения, прозрачность, тени, анимацию и мультимедиа; назначьте приблизительный коэффициент сложности, чтобы выявить потенциальные узкие места производительности.