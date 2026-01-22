---
title: Конвертация PPTX в PPT в .NET
linktitle: PPTX в PPT
type: docs
weight: 21
url: /ru/net/convert-pptx-to-ppt/
keywords:
- конвертация PowerPoint
- конвертация презентации
- конвертация слайда
- конвертация PPTX
- PPTX в PPT
- сохранить PPTX как PPT
- экспортировать PPTX в PPT
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Легко конвертировать PPTX в PPT с помощью Aspose.Slides для .NET - обеспечьте безошибочную совместимость с форматами PowerPoint, сохраняя макет и качество вашей презентации."
---

## **Обзор**

Эта статья объясняет, как преобразовать презентацию PowerPoint в формате PPTX в формат PPT с помощью C#. Рассматривается следующая тема.

- Преобразовать PPTX в PPT на C#

## **Преобразование PPTX в PPT в .NET**

Для примера кода на C# по преобразованию PPTX в PPT см. раздел ниже, то есть [Преобразование PPTX в PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая разные форматы сохранения, вы также можете сохранять файл PPTX в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях. 

- [Преобразование PPTX в PDF в .NET](/slides/ru/net/convert-powerpoint-to-pdf/)
- [Преобразование PPTX в XPS в .NET](/slides/ru/net/convert-powerpoint-to-xps/)
- [Преобразование PPTX в HTML в .NET](/slides/ru/net/convert-powerpoint-to-html/)
- [Преобразование PPTX в ODP в .NET](/slides/ru/net/save-presentation/)
- [Преобразование PPTX в PNG в .NET](/slides/ru/net/convert-powerpoint-to-png/)

## **Преобразовать PPTX в PPT**
Чтобы преобразовать PPTX в PPT, просто передайте имя файла и формат сохранения в метод [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) класса [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Приведённый ниже пример кода на C# преобразует Presentation из PPTX в PPT, используя параметры по умолчанию.
```c#
// Создайте объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("presentation.pptx");

// Сохранение презентации PPTX в формат PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **Вопросы и ответы**

**Сохраняются ли все эффекты и возможности PPTX при сохранении в устаревший формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новые возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растровизированы при конвертации.

**Можно ли конвертировать только выбранные слайды в PPT вместо всей презентации?**

Прямое сохранение работает со всей презентацией. Чтобы конвертировать отдельные слайды, создайте новую презентацию, содержащую только эти слайды, и сохраните её как PPT; альтернативно используйте сервис/API, поддерживающий параметры конвертации по слайдам.

**Поддерживаются ли презентации, защищённые паролем?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем, а также [настроить параметры защиты/шифрования](/slides/ru/net/password-protected-presentation/) для сохраняемого PPT.