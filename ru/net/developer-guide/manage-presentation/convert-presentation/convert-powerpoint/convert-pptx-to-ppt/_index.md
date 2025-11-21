---
title: Преобразовать PPTX в PPT в .NET
linktitle: PPTX в PPT
type: docs
weight: 21
url: /ru/net/convert-pptx-to-ppt/
keywords:
- преобразовать PowerPoint
- преобразовать презентацию
- преобразовать слайд
- преобразовать PPTX
- PPTX в PPT
- сохранить PPTX как PPT
- экспортировать PPTX в PPT
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Легко преобразовать PPTX в PPT с помощью Aspose.Slides для .NET — обеспечьте полную совместимость с форматами PowerPoint, сохранив макет и качество вашей презентации."
---

## **Обзор**

В этой статье объясняется, как с помощью C# преобразовать презентацию PowerPoint в формате PPTX в формат PPT. Рассмотрена следующая тема.

- Конвертировать PPTX в PPT с помощью C#

## **C# Конвертировать PPTX в PPT**

Для примера кода на C# по конвертации PPTX в PPT см. раздел ниже, а именно [Конвертировать PPTX в PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая разные форматы сохранения, можно также сохранять файл PPTX в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях. 

- [C# Конвертировать PPTX в PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Конвертировать PPTX в XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Конвертировать PPTX в HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Конвертировать PPTX в ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Конвертировать PPTX в Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **Конвертировать PPTX в PPT**
Чтобы конвертировать PPTX в PPT, просто передайте имя файла и формат сохранения методу [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) класса [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Пример кода на C# ниже конвертирует презентацию из PPTX в PPT, используя параметры по умолчанию.
```c#
// Создайте объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("presentation.pptx");

// Сохранение презентации PPTX в формат PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **FAQ**

**Сохраняются ли все эффекты и функции PPTX при сохранении в старый формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новые возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растрированы при конвертации.

**Можно ли конвертировать только выбранные слайды в PPT вместо всей презентации?**

Прямое сохранение охватывает всю презентацию. Чтобы конвертировать отдельные слайды, создайте новую презентацию, содержащую только эти слайды, и сохраните её как PPT; альтернативно используйте сервис/API, поддерживающий параметры конвертации по слайдам.

**Поддерживаются ли презентации, защищённые паролем?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем, а также [настроить параметры защиты/шифрования](/slides/ru/net/password-protected-presentation/) для сохраняемого PPT.