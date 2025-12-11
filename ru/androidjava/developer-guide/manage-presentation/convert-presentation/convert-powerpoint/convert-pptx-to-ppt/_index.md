---
title: Конвертировать PPTX в PPT на Android
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

В этой статье объясняется, как с помощью Java преобразовать презентацию PowerPoint в формате PPTX в формат PPT. Рассматривается следующая тема.

- Преобразование PPTX в PPT на Java

## **Преобразование PPTX в PPT на Android**

Для получения примера кода Java для преобразования PPTX в PPT см. раздел ниже — [Convert PPTX to PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая разные форматы сохранения, вы также можете сохранять файл PPTX в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях.

- [Java Convert PPTX to PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java Convert PPTX to XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java Convert PPTX to HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java Convert PPTX to ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java Convert PPTX to Image](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **Преобразование PPTX в PPT**
Чтобы преобразовать PPTX в PPT, просто передайте имя файла и формат сохранения в метод **Save** класса [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). Пример кода Java ниже преобразует презентацию из PPTX в PPT, используя параметры по умолчанию.
```java
// создать объект Presentation, представляющий файл PPTX
Presentation presentation = new Presentation("template.pptx");

// сохранить презентацию в формате PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **FAQ**

**Сохраняются ли все эффекты и функции PPTX при сохранении в устаревший формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые более новые возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растрированы при конвертации.

**Можно ли преобразовать только выбранные слайды в PPT, а не всю презентацию?**

Прямое сохранение охватывает всю презентацию. Чтобы преобразовать конкретные слайды, создайте новую презентацию, содержащую только эти слайды, и сохраните её как PPT; альтернативно используйте сервис/API, поддерживающий параметры конвертации по слайдам.

**Поддерживаются ли защищённые паролем презентации?**

Да. Вы можете определить, защищён ли файл, открыть его с помощью пароля и также [configure protection/encryption settings](/slides/ru/androidjava/password-protected-presentation/) для сохраняемого PPT.