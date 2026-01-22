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

В этой статье объясняется, как с помощью Java преобразовать презентацию PowerPoint в формате PPTX в формат PPT. Рассматривается следующая тема.

- Конвертация PPTX в PPT на Java

## **Конвертация PPTX в PPT на Java**

Для примера кода на Java, преобразующего PPTX в PPT, см. раздел ниже — [Конвертация PPTX в PPT](#convert-pptx-to-ppt). Он просто загружает файл PPTX и сохраняет его в формате PPT. Указывая разные форматы сохранения, вы также можете сохранять файл PPTX в другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как описано в этих статьях.

- [Конвертация PPTX в PDF на Java](/slides/ru/java/convert-powerpoint-to-pdf/)
- [Конвертация PPTX в XPS на Java](/slides/ru/java/convert-powerpoint-to-xps/)
- [Конвертация PPTX в HTML на Java](/slides/ru/java/convert-powerpoint-to-html/)
- [Конвертация PPTX в ODP на Java](/slides/ru/java/save-presentation/)
- [Конвертация PPTX в PNG на Java](/slides/ru/java/convert-powerpoint-to-png/)

## **Конвертация PPTX в PPT**
Чтобы преобразовать PPTX в PPT, просто передайте имя файла и формат сохранения в метод **Save** класса [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). Пример кода на Java ниже преобразует презентацию из PPTX в PPT, используя параметры по умолчанию.
```java
// создать объект Presentation, представляющий файл PPTX
Presentation presentation = new Presentation("template.pptx");

// сохранить презентацию в формате PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **FAQ**

**Все ли эффекты и функции PPTX сохраняются при сохранении в устаревший формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новые возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растеризованы при конвертации.

**Можно ли конвертировать только выбранные слайды в PPT вместо всей презентации?**

Прямое сохранение охватывает всю презентацию. Чтобы конвертировать отдельные слайды, создайте новую презентацию, содержащую только эти слайды, и сохраните её как PPT; альтернативно используйте сервис/API, поддерживающий параметры конвертации по слайдам.

**Поддерживаются ли презентации, защищённые паролем?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем и также [настроить параметры защиты/шифрования](/slides/ru/java/password-protected-presentation/) для сохраняемого PPT.