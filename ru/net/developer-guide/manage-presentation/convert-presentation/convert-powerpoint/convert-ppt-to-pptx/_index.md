---
title: Конвертировать PPT в PPTX в .NET
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/net/convert-ppt-to-pptx/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- PPT в PPTX
- сохранить PPT как PPTX
- экспортировать PPT в PPTX
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Быстро преобразуйте устаревшие презентации PPT в современный формат PPTX в .NET с Aspose.Slides — понятный учебник, бесплатные примеры кода C#, без зависимости от Microsoft Office."
---

## **Обзор**

Эта статья объясняет, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью C# и онлайн‑приложения для конвертации PPT в PPTX. Рассмотрены следующие темы.

- [Преобразовать PPT в PPTX на C#](#convert-ppt-to-pptx)

## **Преобразование PPT в PPTX в .NET**

Для примера кода C# по преобразованию PPT в PPTX см. раздел ниже, то есть [Преобразовать PPT в PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая другие форматы сохранения, вы также можете сохранять файл PPT в множество других форматов, таких как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях. 

- [Преобразовать PPT в PDF в .NET](/slides/ru/net/convert-powerpoint-to-pdf/)
- [Преобразовать PPT в XPS в .NET](/slides/ru/net/convert-powerpoint-to-xps/)
- [Преобразовать PPT в HTML в .NET](/slides/ru/net/convert-powerpoint-to-html/)
- [Преобразовать PPT в ODP в .NET](/slides/ru/net/save-presentation/)
- [Преобразовать PPT в PNG в .NET](/slides/ru/net/convert-powerpoint-to-png/)

## **О преобразовании PPT в PPTX**

Преобразуйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если вам нужно преобразовать тысячи презентаций PPT в формат PPTX, лучшее решение — сделать это программно. С Aspose.Slides API это возможно выполнить всего в несколько строк кода. API поддерживает полную совместимость при преобразовании презентаций PPT в PPTX и позволяет:

- Преобразовать сложные структуры шаблонов, макетов и слайдов.
- Преобразовать презентацию с диаграммами.
- Преобразовать презентацию с групповыми объектами, автофигурами (например, прямоугольниками и эллипсами), фигурами с пользовательской геометрией.
- Преобразовать презентацию, содержащую текстуры и стили заполнения изображениями для автофигур.
- Преобразовать презентацию с заполнителями, текстовыми фреймами и текстовыми держателями.

{{% alert color="primary" %}} 

Посмотрите на приложение [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе **Aspose.Slides API**, поэтому вы можете увидеть живой пример базовых возможностей преобразования PPT в PPTX. Aspose.Slides Conversion — это веб‑приложение, которое позволяет перетаскивать файл презентации в формате PPT и загружать его в преобразованном виде в PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 


## **Преобразование PPT в PPTX**
Чтобы преобразовать PPT в PPTX, просто передайте имя файла и формат сохранения методу [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) класса [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation). Пример кода на C# ниже преобразует презентацию из PPT в PPTX, используя параметры по умолчанию.
```c#
// Создайте объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Сохранение презентации PPTX в формате PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


Подробнее о форматах презентаций [**PPT vs PPTX**](/slides/ru/net/ppt-vs-pptx/) и о том, как [**Aspose.Slides поддерживает преобразование PPT в PPTX**](/slides/ru/net/convert-ppt-to-pptx/).

## **FAQ**

**В чем разница между форматами PPT и PPTX?**

PPT — более старый двоичный файловый формат, используемый Microsoft PowerPoint, тогда как PPTX — более новый формат на основе XML, введённый в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер файла и улучшенное восстановление данных.

**Могу ли я преобразовать PPT в PPTX с помощью .NET?**

Да, используя библиотеку Aspose.Slides для .NET, вы можете легко загрузить файл PPT и сохранить его в формате PPTX всего за несколько строк кода.

**Поддерживает ли Aspose.Slides пакетное преобразование нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программного преобразования нескольких файлов PPT в PPTX, что делает его подходящим для пакетных сценариев преобразования.

**Будут ли сохранены содержимое и форматирование после преобразования?**

Aspose.Slides сохраняет высокую точность при преобразовании презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при переходе от PPT к PPTX.

**Могу ли я преобразовать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает преобразование файлов PPT в несколько форматов, включая PDF, XPS, HTML, ODP и графические форматы, такие как PNG и JPEG.

**Можно ли преобразовать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides для .NET — это самостоятельный API, который не требует установки Microsoft PowerPoint или какого‑либо стороннего программного обеспечения для выполнения преобразования.

**Есть ли онлайн‑инструмент для преобразования PPT в PPTX?**

Да, вы можете использовать бесплатное веб‑приложение [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения преобразования напрямую в браузере без написания кода.