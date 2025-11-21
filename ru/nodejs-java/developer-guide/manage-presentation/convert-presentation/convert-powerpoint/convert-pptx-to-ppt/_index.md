---
title: Конвертировать PPTX в PPT на JavaScript
linktitle: Конвертировать PPTX в PPT
type: docs
weight: 21
url: /ru/nodejs-java/convert-pptx-to-ppt/
keywords: "Java Конвертировать PPTX в PPT, Конвертировать презентацию PowerPoint, PPTX в PPT, Java, Aspose.Slides"
description: "Конвертировать PowerPoint PPTX в PPT на JavaScript"
---

## **Обзор**

В этой статье объясняется, как с помощью JavaScript преобразовать презентацию PowerPoint в формате PPTX в формат PPT. Рассматривается следующая тема.

- Конвертировать PPTX в PPT с помощью JavaScript

## **Java Конвертировать PPTX в PPT**

Для примера кода JavaScript, который конвертирует PPTX в PPT, см. раздел ниже [Convert PPTX to PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая различные форматы сохранения, вы также можете сохранить файл PPTX в many other formats like PDF, XPS, ODP, HTML etc. as discussed in these articles.

- [Java Конвертировать PPTX в PDF](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-pdf/)
- [Java Конвертировать PPTX в XPS](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-xps/)
- [Java Конвертировать PPTX в HTML](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-html/)
- [Java Конвертировать PPTX в ODP](https://docs.aspose.com/slides/nodejs-java/save-presentation/)
- [Java Конвертировать PPTX в Image](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-png/)

## **Конвертировать PPTX в PPT**

Чтобы конвертировать PPTX в PPT, просто передайте имя файла и формат сохранения методу **Save** класса [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). Пример кода JavaScript ниже конвертирует презентацию из PPTX в PPT, используя параметры по умолчанию.
```javascript
// создайте объект Presentation, который представляет файл PPTX
var presentation = new aspose.slides.Presentation("template.pptx");
// сохраните презентацию в формате PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```


## **Часто задаваемые вопросы**

**Все ли эффекты и функции PPTX сохраняются при сохранении в устаревший формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новейшие возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растрированы при конвертации.

**Могу ли я конвертировать только выбранные слайды в PPT вместо всей презентации?**

Прямое сохранение охватывает всю презентацию. Чтобы конвертировать определённые слайды, создайте новую презентацию, содержащую только эти слайды, и сохраните её как PPT; либо используйте сервис/API, поддерживающий параметры конвертации по отдельным слайдам.

**Поддерживаются ли презентации, защищённые паролем?**

Да. Вы можете определить, защищён ли файл паролем, открыть его с паролем и также [настроить параметры защиты/шифрования](/slides/ru/nodejs-java/password-protected-presentation/) для сохраняемого PPT.