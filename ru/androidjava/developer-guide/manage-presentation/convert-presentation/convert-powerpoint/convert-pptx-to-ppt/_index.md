---
title: Преобразовать PPTX в PPT на Android
linktitle: PPTX в PPT
type: docs
weight: 21
url: /ru/androidjava/convert-pptx-to-ppt/
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
- Android
- Java
- Aspose.Slides
description: "Легко конвертировать PPTX в PPT с помощью Aspose.Slides для Android через Java — обеспечьте бесшовную совместимость с форматами PowerPoint, сохраняя макет и качество вашей презентации."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPTX в формат PPT с помощью Java. Рассматривается следующая тема.

- Преобразовать PPTX в PPT на Java

## **Преобразование PPTX в PPT на Android**

Для получения примера кода Java по преобразованию PPTX в PPT см. раздел ниже — [Преобразовать PPTX в PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая разные форматы сохранения, вы также можете сохранять файл PPTX в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как описано в этих статьях.

- [Java Преобразовать PPTX в PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java Преобразовать PPTX в XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java Преобразовать PPTX в HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java Преобразовать PPTX в ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java Преобразовать PPTX в изображение](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **Преобразование PPTX в PPT**
Чтобы преобразовать PPTX в PPT, просто передайте имя файла и формат сохранения в метод **Save** класса [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). Пример кода Java ниже преобразует презентацию из PPTX в PPT, используя параметры по умолчанию.
```java
// создать объект Presentation, который представляет файл PPTX
Presentation presentation = new Presentation("template.pptx");

// сохранить презентацию как PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **Часто задаваемые вопросы**

**Все ли эффекты и функции PPTX сохраняются при сохранении в устаревший формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новые возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растровыми при конвертации.

**Можно ли преобразовать только выбранные слайды в PPT вместо всей презентации?**

Прямое сохранение охватывает всю презентацию. Чтобы преобразовать отдельные слайды, создайте новую презентацию только с этими слайдами и сохраните её как PPT; альтернативно используйте сервис/API, поддерживающий параметры конвертации по слайдам.

**Поддерживаются ли презентации с паролем?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем и также [настроить параметры защиты/шифрования](/slides/ru/androidjava/password-protected-presentation/) для сохраняемого PPT.