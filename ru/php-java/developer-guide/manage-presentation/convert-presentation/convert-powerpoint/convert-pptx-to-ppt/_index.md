---
title: Конвертировать PPTX в PPT на PHP
linktitle: PPTX в PPT
type: docs
weight: 21
url: /ru/php-java/convert-pptx-to-ppt/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPTX
- PPTX в PPT
- сохранить PPTX как PPT
- экспортировать PPTX в PPT
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Легко конвертировать PPTX в PPT с помощью Aspose.Slides — обеспечьте бесшовную совместимость с форматами PowerPoint, сохраняя макет и качество вашей презентации."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPTX в формат PPT с помощью PHP. Рассмотрены следующие темы.

- Конвертировать PPTX в PPT

## **Конвертировать PPTX в PPT на PHP**

Для примера кода на Java, преобразующего PPTX в PPT, см. раздел ниже — [Convert PPTX to PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая различные форматы сохранения, вы также можете сохранять файл PPTX в другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях. 

- [Конвертировать PPTX в PDF на PHP](/slides/ru/php-java/convert-powerpoint-to-pdf/)
- [Конвертировать PPTX в XPS на PHP](/slides/ru/php-java/convert-powerpoint-to-xps/)
- [Конвертировать PPTX в HTML на PHP](/slides/ru/php-java/convert-powerpoint-to-html/)
- [Конвертировать PPTX в ODP на PHP](/slides/ru/php-java/save-presentation/)
- [Конвертировать PPTX в PNG на PHP](/slides/ru/php-java/convert-powerpoint-to-png/)

## **Конвертировать PPTX в PPT**
Чтобы конвертировать PPTX в PPT, просто передайте имя файла и формат сохранения в метод **Save** класса [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). Пример кода на PHP ниже преобразует презентацию из PPTX в PPT, используя параметры по умолчанию.
```php
  # создать объект Presentation, который представляет файл PPTX
  $presentation = new Presentation("template.pptx");
  # сохранить презентацию в формате PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```


## **FAQ**

**Все ли эффекты и функции PPTX сохраняются при сохранении в устаревший формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новые возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растрированы во время конвертации.

**Могу ли я конвертировать только выбранные слайды в PPT вместо всей презентации?**

Прямое сохранение охватывает всю презентацию. Чтобы конвертировать конкретные слайды, создайте новую презентацию только с этими слайдами и сохраните её как PPT; альтернативно используйте сервис/ API, поддерживающий параметры конвертации для отдельных слайдов.

**Поддерживаются ли защищённые паролем презентации?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем, а также [настроить параметры защиты/шифрования](/slides/ru/php-java/password-protected-presentation/) для сохраняемого PPT.