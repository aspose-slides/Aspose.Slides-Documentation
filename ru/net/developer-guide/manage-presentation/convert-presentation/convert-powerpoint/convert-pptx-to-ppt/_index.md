---
title: Конвертировать PPTX в PPT в .NET
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
description: "Легко конвертировать PPTX в PPT с помощью Aspose.Slides для .NET — обеспечьте бесшовную совместимость с форматами PowerPoint, сохраняя макет и качество вашей презентации."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPTX в формат PPT с использованием C#. Рассматривается следующая тема.

- Преобразовать PPTX в PPT на C#

## **C# Преобразование PPTX в PPT**

Для примера кода C# по преобразованию PPTX в PPT см. раздел ниже, а именно [Convert PPTX to PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая различные форматы сохранения, вы также можете сохранить файл PPTX во многих других форматах, таких как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях. 

- [C# Преобразование PPTX в PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Преобразование PPTX в XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Преобразование PPTX в HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Преобразование PPTX в ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Преобразование PPTX в Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **Преобразование PPTX в PPT**
Чтобы преобразовать PPTX в PPT, просто передайте имя файла и формат сохранения в метод [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) класса [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Пример кода на C# ниже преобразует объект Presentation из PPTX в PPT, используя параметры по умолчанию.
```c#
// Создайте объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("presentation.pptx");

// Сохранение презентации PPTX в формате PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **Часто задаваемые вопросы**

**Сохраняются ли все эффекты и функции PPTX при сохранении в старый формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новые возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растрированы при преобразовании.

**Можно ли конвертировать только выбранные слайды в PPT вместо всей презентации?**

Прямое сохранение охватывает всю презентацию. Чтобы конвертировать отдельные слайды, создайте новую презентацию, содержащую только эти слайды, и сохраните её как PPT; альтернативно используйте сервис/API, поддерживающий параметры конвертации по отдельным слайдам.

**Поддерживаются ли презентации, защищённые паролем?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем, а также [configure protection/encryption settings](/slides/ru/net/password-protected-presentation/) для сохранённого PPT.