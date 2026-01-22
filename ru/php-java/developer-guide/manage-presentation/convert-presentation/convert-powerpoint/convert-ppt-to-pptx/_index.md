---
title: Конвертировать PPT в PPTX с помощью PHP
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/php-java/convert-ppt-to-pptx/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- PPT в PPTX
- сохранить PPT как PPTX
- экспортировать PPT в PPTX
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Быстро конвертировать устаревшие презентации PPT в современные PPTX с помощью Aspose.Slides для PHP через Java — подробный урок, бесплатные примеры кода, без зависимости от Microsoft Office."
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формате PPT в формат PPTX с помощью PHP и онлайн‑приложения для конвертации PPT в PPTX. Рассматривается следующая тема.

- Конвертировать PPT в PPTX

## **Конвертация PPT в PPTX с помощью PHP**

Для примера кода Java по конвертации PPT в PPTX см. раздел ниже, то есть [Convert PPT to PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая различные форматы сохранения, вы также можете сохранять файл PPT в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях.

- [Конвертировать PPT в PDF с помощью PHP](/slides/ru/php-java/convert-powerpoint-to-pdf/)
- [Конвертировать PPT в XPS с помощью PHP](/slides/ru/php-java/convert-powerpoint-to-xps/)
- [Конвертировать PPT в HTML с помощью PHP](/slides/ru/php-java/convert-powerpoint-to-html/)
- [Конвертировать PPT в ODP с помощью PHP](/slides/ru/php-java/save-presentation/)
- [Конвертировать PPT в PNG с помощью PHP](/slides/ru/php-java/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**

Конвертируйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если вам нужно преобразовать тысячи презентаций PPT в формат PPTX, лучшее решение — сделать это программно. С Aspose.Slides API это возможно выполнить всего в несколько строк кода. API обеспечивает полную совместимость для конвертации презентаций PPT в PPTX, и возможно:

- Конвертировать сложные структуры шаблонов, макетов и слайдов.
- Конвертировать презентацию с диаграммами.
- Конвертировать презентацию с групповыми фигурами, автофигурами (например, прямоугольниками и эллипсами), фигурами с пользовательской геометрией.
- Конвертировать презентацию, имеющую текстуры и стили заливки изображениями для автофигур.
- Конвертировать презентацию с заполнителями, текстовыми рамками и текстовыми контейнерами.

{{% alert color="primary" %}} 

Взгляните на приложение [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/), поэтому вы можете увидеть работающий пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — это веб‑приложение, которое позволяет перетащить файл презентации в формате PPT и загрузить его в виде преобразованного в PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

## **Конвертация PPT в PPTX**

Aspose.Slides для PHP через Java теперь облегчает разработчикам доступ к PPT с помощью экземпляра класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и его конвертацию в соответствующий формат [PPTX](https://docs.fileformat.com/presentation/pptx/). В настоящее время поддерживается частичная конвертация [PPT ](https://docs.fileformat.com/presentation/ppt/)в PPTX. Для получения более подробной информации о поддерживаемых и неподдерживаемых функциях при конвертации PPT в PPTX перейдите к этой документации [link](/slides/ru/php-java/ppt-to-pptx-conversion/).

Aspose.Slides для PHP через Java предоставляет класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation), который представляет файл презентации **PPTX**. Класс Presentation теперь также может получать доступ к **PPT** через Presentation при создании объекта. Следующий пример показывает, как конвертировать презентацию PPT в презентацию PPTX.

```php
  # Создать объект Presentation, представляющий файл PPTX
  $pres = new Presentation("Aspose.ppt");
  try {
    # Сохранить презентацию PPTX в формате PPTX
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

Приведённый выше фрагмент кода создал следующую презентацию PPTX после конвертации

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Рисунок: Сгенерированная презентация PPTX после конвертации**|

## **Часто задаваемые вопросы**

**В чём разница между форматами PPT и PPTX?**

PPT — это более старый двоичный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — новый основанный на XML формат, представленный в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и улучшенное восстановление данных.

**Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программной конвертации нескольких файлов PPT в PPTX, что делает его подходящим для сценариев пакетной конвертации.

**Будут ли сохранены содержание и форматирование после конвертации?**

Aspose.Slides обеспечивает высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при конвертации PPT в PPTX.

**Могу ли я конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает конвертацию файлов PPT в [несколько форматов](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/), включая PDF, XPS, HTML, ODP и графические форматы, такие как PNG и JPEG.

**Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides — это самостоятельный API и не требует установки Microsoft PowerPoint или какого-либо стороннего программного обеспечения для выполнения конвертации.

**Существует ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения конвертации непосредственно в браузере без написания кода.