---
title: Преобразовать PPTX в PPT на JavaScript
linktitle: PPTX в PPT
type: docs
weight: 21
url: /ru/nodejs-java/convert-pptx-to-ppt/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Легко конвертировать PPTX в PPT с помощью Aspose.Slides — обеспечьте бесшовную совместимость с форматами PowerPoint, сохраняя макет и качество вашей презентации."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPTX в формат PPT с помощью JavaScript. Рассматривается следующая тема.

- Преобразовать PPTX в PPT с помощью JavaScript

## **Java Конвертировать PPTX в PPT**

Для примера кода JavaScript, конвертирующего PPTX в PPT, смотрите раздел ниже, а именно [Convert PPTX to PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая разные форматы сохранения, вы также можете сохранять файл PPTX во многих других форматах, таких как PDF, XPS, ODP, HTML и т.д., как описано в этих статьях.

- [Преобразовать PPTX в PDF на JavaScript](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/)
- [Преобразовать PPTX в XPS на JavaScript](/slides/ru/nodejs-java/convert-powerpoint-to-xps/)
- [Преобразовать PPTX в HTML на JavaScript](/slides/ru/nodejs-java/convert-powerpoint-to-html/)
- [Преобразовать PPTX в ODP на JavaScript](/slides/ru/nodejs-java/save-presentation/)
- [Преобразовать PPTX в PNG на JavaScript](/slides/ru/nodejs-java/convert-powerpoint-to-png/)

## **Конвертировать PPTX в PPT**

Чтобы конвертировать PPTX в PPT, просто передайте имя файла и формат сохранения методу **Save** класса [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). Приведённый ниже пример кода JavaScript конвертирует презентацию из PPTX в PPT, используя параметры по умолчанию.
```javascript
// создать объект Presentation, который представляет файл PPTX
var presentation = new aspose.slides.Presentation("template.pptx");
// сохранить презентацию в формате PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```


## **FAQ**

**Сохраняются ли все эффекты и функции PPTX при сохранении в устаревший формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новые возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растровыми при конвертации.

**Могу ли я конвертировать только выбранные слайды в PPT вместо всей презентации?**

Прямое сохранение охватывает всю презентацию. Чтобы конвертировать отдельные слайды, создайте новую презентацию, содержащую только эти слайды, и сохраните её в PPT; альтернативно используйте сервис/API, поддерживающий параметры конвертации по слайдам.

**Поддерживаются ли презентации, защищённые паролем?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем, а также [configure protection/encryption settings](/slides/ru/nodejs-java/password-protected-presentation/) для сохраняемого PPT.