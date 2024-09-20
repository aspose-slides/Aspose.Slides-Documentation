---
title: Конвертировать PPT в PPTX
linktitle: Конвертировать PPT в PPTX
type: docs
weight: 20
url: /php-java/convert-ppt-to-pptx/
keywords: "PHP Конвертировать PPT в PPTX, PowerPoint PPT в PPTX"
description: "Конвертировать PowerPoint PPT в PPTX."
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формате PPT в формат PPTX с использованием PHP и онлайн-приложения для конвертации PPT в PPTX. Рассматриваемая тема:

- Конвертация PPT в PPTX

## **Java Конвертация PPT в PPTX**

Для получения примера кода на Java для конвертации PPT в PPTX смотрите раздел ниже, т.е. [Конвертировать PPT в PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая разные форматы сохранения, вы также можете сохранить файл PPT в множество других форматов, таких как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях.

- [Java Конвертация PPT в PDF](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java Конвертация PPT в XPS](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java Конвертация PPT в HTML](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java Конвертация PPT в ODP](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java Конвертация PPT в Изображение](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**
Конвертируйте старый формат PPT в PPTX с помощью API Aspose.Slides. Если вам нужно конвертировать тысячи презентаций PPT в формат PPTX, лучшим решением является сделать это программно. С API Aspose.Slides это можно сделать всего за несколько строк кода. API поддерживает полную совместимость для конвертации презентации PPT в PPTX, и это возможно:

- Конвертировать сложные структуры мастеров, макетов и слайдов.
- Конвертировать презентации с графиками.
- Конвертировать презентации с группами фигур, автофигурами (такими как прямоугольники и эллипсы), фигурами с пользовательской геометрией.
- Конвертировать презентации с текстурами и стилями заливки изображениями для автофигур.
- Конвертировать презентации с заполнителями, текстовыми рамками и текстовыми полями.

{{% alert color="primary" %}} 

Посмотрите на [**Конвертацию PPT в PPTX от Aspose.Slides**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение разработано на основе [**API Aspose.Slides**](https://products.aspose.com/slides/php-java/), так что вы можете увидеть живой пример базовых возможностей конвертации PPT в PPTX. Конвертация Aspose.Slides — это веб-приложение, которое позволяет загрузить файл презентации в формате PPT и скачать его в конвертированном формате PPTX.

Найдите другие живые примеры [**Конвертации Aspose.Slides**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

## **Конвертация PPT в PPTX**
Aspose.Slides для PHP через Java теперь дает возможность разработчикам получать доступ к PPT с помощью экземпляра класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и конвертировать его в соответствующий формат [PPTX](https://docs.fileformat.com/presentation/pptx/). В настоящее время он поддерживает частичную конвертацию [PPT ](https://docs.fileformat.com/presentation/ppt/) в PPTX. Для получения дополнительной информации о поддерживаемых и неподдерживаемых функциях конвертации PPT в PPTX, пожалуйста, перейдите по этой ссылке на документацию [ссылку](/slides/php-java/ppt-to-pptx-conversion/).

Aspose.Slides для PHP через Java предлагает класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation), который представляет файл **PPTX**. Класс Presentation теперь также может получать доступ к **PPT** через Presentation, когда объект инстанциирован. Следующий пример показывает, как конвертировать презентацию PPT в презентацию PPTX.

```php
  # Создаем объект Presentation, представляющий файл PPTX
  $pres = new Presentation("Aspose.ppt");
  try {
    # Сохраняем презентацию PPTX в формате PPTX
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Рисунок : Исходная презентация PPT**|

Приведенный выше фрагмент кода сгенерировал следующую презентацию PPTX после конвертации

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Рисунок: Сгенерированная презентация PPTX после конвертации**|