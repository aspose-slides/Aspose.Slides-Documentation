---
title: Конвертация PPTX в PPT на Java
linktitle: Конвертация PPTX в PPT
type: docs
weight: 21
url: /java/convert-pptx-to-ppt/
keywords: "Java Конвертация PPTX в PPT, Конвертация презентации PowerPoint, PPTX в PPT, Java, Aspose.Slides"
description: "Конвертация PowerPoint PPTX в PPT на Java"
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формате PPTX в формат PPT с помощью Java. Рассматриваемая тема:

- Конвертация PPTX в PPT на Java

## **Java Конвертация PPTX в PPT**

Для примера кода на Java для конвертации PPTX в PPT смотрите раздел ниже, т.е. [Конвертация PPTX в PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая различные форматы сохранения, вы также можете сохранить файл PPTX в множество других форматов, таких как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях.

- [Java Конвертация PPTX в PDF](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java Конвертация PPTX в XPS](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java Конвертация PPTX в HTML](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java Конвертация PPTX в ODP](https://docs.aspose.com/slides/java/save-presentation/)
- [Java Конвертация PPTX в изображение](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **Конвертация PPTX в PPT**
Чтобы конвертировать PPTX в PPT, просто передайте имя файла и формат сохранения в метод **Save** класса [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). Пример кода на Java ниже конвертирует презентацию из PPTX в PPT, используя параметры по умолчанию.

```java
// создаем объект Presentation, представляющий файл PPTX
Presentation presentation = new Presentation("template.pptx");

// сохраняем презентацию в формате PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```