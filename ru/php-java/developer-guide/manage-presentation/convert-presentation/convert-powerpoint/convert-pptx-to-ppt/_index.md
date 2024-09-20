---
title: Конвертация PPTX в PPT
linktitle: Конвертация PPTX в PPT
type: docs
weight: 21
url: /php-java/convert-pptx-to-ppt/
keywords: "PHP Конвертация PPTX в PPT, Конвертация презентации PowerPoint, PPTX в PPT, Java, Aspose.Slides"
description: "Конвертация презентации PowerPoint PPTX в PPT"
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формате PPTX в формат PPT с использованием PHP. Рассматриваемая тема:

- Конвертация PPTX в PPT

## **Java Конвертация PPTX в PPT**

Для примера кода на Java для конвертации PPTX в PPT смотрите раздел ниже, т.е. [Конвертация PPTX в PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указав различные форматы сохранения, вы также можете сохранить файл PPTX в другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждено в этих статьях.

- [Java Конвертация PPTX в PDF](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java Конвертация PPTX в XPS](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java Конвертация PPTX в HTML](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java Конвертация PPTX в ODP](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java Конвертация PPTX в изображение](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **Конвертация PPTX в PPT**
Чтобы конвертировать PPTX в PPT, просто передайте имя файла и формат сохранения в метод **Save** класса [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). Пример кода на PHP ниже конвертирует презентацию из PPTX в PPT, используя параметры по умолчанию.

```php
  # создание объекта Presentation, представляющего файл PPTX
  $presentation = new Presentation("template.pptx");
  # сохранение презентации как PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```