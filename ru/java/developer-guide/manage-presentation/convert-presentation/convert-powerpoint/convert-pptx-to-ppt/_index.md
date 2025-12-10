---
title: Конвертировать PPTX в PPT на Java
linktitle: PPTX в PPT
type: docs
weight: 21
url: /ru/java/convert-pptx-to-ppt/
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
- Java
- Aspose.Slides
description: "Легко конвертировать PPTX в PPT с помощью Aspose.Slides для Java — обеспечьте бесшовную совместимость с форматами PowerPoint, сохраняя макет и качество вашей презентации."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPTX в формат PPT с использованием Java. Рассматривается следующая тема.

- Преобразование PPTX в PPT на Java

## **Преобразование PPTX в PPT на Java**

Для примера кода на Java, который преобразует PPTX в PPT, см. раздел ниже, а именно [Convert PPTX to PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая разные форматы сохранения, вы также можете сохранять файл PPTX в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях. 

- [Java Convert PPTX to PDF](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java Convert PPTX to XPS](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java Convert PPTX to HTML](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java Convert PPTX to ODP](https://docs.aspose.com/slides/java/save-presentation/)
- [Java Convert PPTX to Image](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **Преобразование PPTX в PPT**
Чтобы преобразовать PPTX в PPT, просто передайте имя файла и формат сохранения в метод **Save** класса [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). Пример кода на Java ниже преобразует презентацию из PPTX в PPT, используя параметры по умолчанию.
```java
// создать объект Presentation, который представляет файл PPTX
Presentation presentation = new Presentation("template.pptx");

// сохранить презентацию как PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **FAQ**

**Все ли эффекты и функции PPTX сохраняются при сохранении в устаревший формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новые возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растеризованы во время конвертации.

**Можно ли конвертировать только выбранные слайды в PPT вместо всей презентации?**

Прямое сохранение охватывает всю презентацию. Чтобы конвертировать конкретные слайды, создайте новую презентацию только с этими слайдами и сохраните её как PPT; альтернативно используйте сервис/API, поддерживающий параметры конвертации по слайдам.

**Поддерживаются ли защищённые паролем презентации?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем и также [configure protection/encryption settings](/slides/ru/java/password-protected-presentation/) для сохранённого PPT.