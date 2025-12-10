---
title: Преобразовать PPTX в PPT в .NET
linktitle: PPTX в PPT
type: docs
weight: 21
url: /ru/net/convert-pptx-to-ppt/
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
- .NET
- C#
- Aspose.Slides
description: "Легко конвертировать PPTX в PPT с помощью Aspose.Slides для .NET—обеспечивает бесшовную совместимость с форматами PowerPoint, сохраняет макет и качество вашей презентации."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPTX в формат PPT с использованием C#. Рассмотрена следующая тема.

- Преобразовать PPTX в PPT на C#

## **Преобразование PPTX в PPT в .NET**

Для примера кода C# по преобразованию PPTX в PPT см. раздел ниже, а именно [Convert PPTX to PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет в формате PPT. Указывая разные форматы сохранения, вы также можете сохранить файл PPTX во многих других форматах, таких как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях. 

- [C# Преобразовать PPTX в PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Преобразовать PPTX в XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Преобразовать PPTX в HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Преобразовать PPTX в ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Преобразовать PPTX в Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **Преобразование PPTX в PPT**
Для преобразования PPTX в PPT просто передайте имя файла и формат сохранения методу [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) класса [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Пример кода на C# ниже преобразует объект Presentation из PPTX в PPT, используя параметры по умолчанию.
```c#
// Создать объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("presentation.pptx");

// Сохранить презентацию PPTX в формате PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **FAQ**

**Сохраняются ли все эффекты и возможности PPTX при сохранении в устаревший формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые современные возможности (например, определённые эффекты, объекты и поведения), поэтому при конвертации функции могут быть упрощены или растрированы.

**Могу ли я преобразовать только выбранные слайды в PPT вместо всей презентации?**

Прямое сохранение охватывает всю презентацию. Чтобы преобразовать отдельные слайды, создайте новую презентацию, содержащую только нужные слайды, и сохраните её в формате PPT; альтернативно, используйте сервис/API, поддерживающий параметры конвертации по слайдам.

**Поддерживаются ли защищённые паролем презентации?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем, а также [configure protection/encryption settings](/slides/ru/net/password-protected-presentation/) для сохранённого PPT.