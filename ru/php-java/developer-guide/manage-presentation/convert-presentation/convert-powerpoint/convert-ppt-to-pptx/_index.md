---
title: Конвертировать PPT в PPTX в PHP
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
description: "Быстро конвертировать устаревшие презентации PPT в современные PPTX с помощью Aspose.Slides for PHP via Java — понятный учебник, бесплатные образцы кода, без зависимости от Microsoft Office."
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формате PPT в формат PPTX с использованием PHP и онлайн‑приложения для конвертации PPT в PPTX. Рассмотрена следующая тема.

- Конвертировать PPT в PPTX

## **Конвертировать PPT в PPTX на PHP**

Для примера кода на Java по конвертации PPT в PPTX, пожалуйста, смотрите раздел ниже, то есть [Convert PPT to PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет в формате PPTX. Указывая различные форматы сохранения, вы также можете сохранять файл PPT в другие форматы, такие как PDF, XPS, ODP, HTML и др., как обсуждается в этих статьях.

- [Java Конвертировать PPT в PDF](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java Конвертировать PPT в XPS](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java Конвертировать PPT в HTML](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java Конвертировать PPT в ODP](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java Конвертировать PPT в изображение](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**

Конвертируйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если вам нужно конвертировать тысячи презентаций PPT в формат PPTX, лучшее решение — выполнить это программно. С Aspose.Slides API это возможно выполнить всего в нескольких строках кода. API обеспечивает полную совместимость для конвертации презентации PPT в PPTX, и возможно:

- Конвертировать сложные структуры шаблонов, разметок и слайдов.
- Конвертировать презентацию с диаграммами.
- Конвертировать презентацию с группированными объектами, автоматическими фигурами (например, прямоугольниками и эллипсами), фигурами с пользовательской геометрией.
- Конвертировать презентацию, содержащую текстуры и стили заливки изображениями для автоматических фигур.
- Конвертировать презентацию с заполнителями, текстовыми рамками и текстовыми объектами.

{{% alert color="primary" %}} 

Посмотрите приложение [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/), поэтому вы можете увидеть живой пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — это веб‑приложение, которое позволяет загрузить файл презентации в формате PPT и скачать его в преобразованном виде PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **Конвертировать PPT в PPTX**

Aspose.Slides for PHP via Java теперь позволяет разработчикам получать доступ к PPT с помощью экземпляра класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и конвертировать его в соответствующий формат [PPTX](https://docs.fileformat.com/presentation/pptx/). В настоящее время поддерживается частичная конвертация [PPT ](https://docs.fileformat.com/presentation/ppt/)в PPTX. Для получения более подробной информации о поддерживаемых и неподдерживаемых функциях в конвертации PPT в PPTX, перейдите к этой документации [link](/slides/ru/php-java/ppt-to-pptx-conversion/).

Aspose.Slides for PHP via Java предлагает класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation), представляющий файл презентации **PPTX**. Класс Presentation теперь также может получать доступ к **PPT** через Presentation при создании объекта. Ниже приведён пример, показывающий, как конвертировать презентацию PPT в презентацию PPTX.

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
|**Рисунок : Исходная PPT презентация**|

Вышеуказанный фрагмент кода сгенерировал следующую презентацию PPTX после конвертации

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Рисунок: Сгенерированная PPTX презентация после конвертации**|

## **FAQ**

**В чём разница между форматами PPT и PPTX?**

PPT — это старый двоичный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — более новый XML‑основой формат, введённый в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и улучшенное восстановление данных.

**Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программной конвертации нескольких файлов PPT в PPTX, что делает его подходящим для пакетных сценариев конвертации.

**Сохраняются ли содержимое и форматирование после конвертации?**

Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при конвертации PPT в PPTX.

**Могу ли я конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает конвертацию файлов PPT в [многие форматы](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/), включая PDF, XPS, HTML, ODP и форматы изображений, такие как PNG и JPEG.

**Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides — это отдельный API и не требует Microsoft PowerPoint или какого‑либо стороннего программного обеспечения для выполнения конвертации.

**Существует ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете использовать бесплатное веб‑приложение [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения конвертации непосредственно в браузере без написания кода.