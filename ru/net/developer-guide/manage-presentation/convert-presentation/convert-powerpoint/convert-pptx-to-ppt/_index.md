---
title: Конвертировать PPTX в PPT с помощью C#
linktitle: Конвертировать PPTX в PPT
type: docs
weight: 21
url: /ru/net/convert-pptx-to-ppt/
keywords: "C# Конвертировать PPTX в PPT, Конвертировать презентацию PowerPoint, PPTX в PPT, C#, Aspose.Slides"
description: "Конвертировать PowerPoint PPTX в PPT с помощью C#"
---

## **Обзор**

Эта статья объясняет, как с помощью C# преобразовать презентацию PowerPoint в формате PPTX в формат PPT. Рассматривается следующая тема.

- Конвертация PPTX в PPT на C#

## **C# Конвертация PPTX в PPT**

Для примера кода на C# по конвертации PPTX в PPT см. раздел ниже, а именно [Convert PPTX to PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая разные форматы сохранения, вы также можете сохранять файл PPTX во многих других форматах, таких как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях.

- [C# Convert PPTX to PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Convert PPTX to XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Convert PPTX to HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Convert PPTX to ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Convert PPTX to Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **Конвертация PPTX в PPT**
Чтобы конвертировать PPTX в PPT, просто передайте имя файла и формат сохранения методу [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) класса [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Пример кода на C# ниже конвертирует презентацию из PPTX в PPT, используя параметры по умолчанию.
```c#
// Создать объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("presentation.pptx");

// Сохранение презентации PPTX в формат PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **FAQ**

**Все ли эффекты и возможности PPTX сохраняются при сохранении в устаревший формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новые возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растрированы при конвертации.

**Можно ли конвертировать только выбранные слайды в PPT вместо всей презентации?**

Сохранение напрямую охватывает всю презентацию. Чтобы конвертировать отдельные слайды, создайте новую презентацию только с этими слайдами и сохраните её как PPT; в качестве альтернативы можно использовать сервис/API, поддерживающий параметры конвертации для отдельных слайдов.

**Поддерживаются ли презентации, защищённые паролем?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем, а также [настройте параметры защиты/шифрования](/slides/ru/net/password-protected-presentation/) для сохранённого PPT.