---
title: Конвертировать PPTX в PPT на Java
linktitle: Конвертировать PPTX в PPT
type: docs
weight: 21
url: /androidjava/convert-pptx-to-ppt/
keywords: "Java Конвертировать PPTX в PPT, Конвертировать презентацию PowerPoint, PPTX в PPT, Java, Aspose.Slides"
description: "Конвертировать PowerPoint PPTX в PPT на Java"
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формате PPTX в формат PPT с использованием Java. Рассматривается следующая тема.

- Конвертация PPTX в PPT на Java

## **Java Конвертировать PPTX в PPT**

Чтобы увидеть пример кода на Java для конвертации PPTX в PPT, пожалуйста, смотрите раздел ниже т.е. [Конвертировать PPTX в PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая различные форматы сохранения, вы также можете сохранить файл PPTX в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждено в этих статьях.

- [Java Конвертировать PPTX в PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java Конвертировать PPTX в XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java Конвертировать PPTX в HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java Конвертировать PPTX в ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java Конвертировать PPTX в Изображение](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **Конвертировать PPTX в PPT**
Чтобы конвертировать PPTX в PPT, просто передайте имя файла и формат сохранения в метод **Save** класса [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). Пример кода на Java ниже конвертирует презентацию из PPTX в PPT с использованием параметров по умолчанию.

```java
// создайте объект Presentation, представляющий файл PPTX
Presentation presentation = new Presentation("template.pptx");

// сохраните презентацию как PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```