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
description: "Конвертировать устаревшие презентации PPT в современные PPTX быстро в .NET с помощью Aspose.Slides — понятный учебник, бесплатные примеры кода C#, без зависимости от Microsoft Office."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью C# и онлайн‑приложения для конвертации PPT в PPTX. Рассматривается следующая тема.

- [Конвертировать PPT в PPTX на C#](#convert-ppt-to-pptx)

## **Конвертировать PPT в PPTX в .NET**

Для примера кода на C# по конвертации PPT в PPTX см. раздел ниже, то есть [Convert PPT to PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая разные форматы сохранения, вы также можете сохранять файл PPT во многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях.

- [C# Преобразовать PPT в PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Преобразовать PPT в XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Преобразовать PPT в HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Преобразовать PPT в ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Преобразовать PPT в Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**

Преобразуйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если вам нужно конвертировать тысячи презентаций PPT в формат PPTX, лучшее решение — сделать это программно. С Aspose.Slides API это возможно выполнить всего в несколько строк кода. API обеспечивает полную совместимость для конвертации презентации PPT в PPTX, и это возможно:

- Преобразовать сложные структуры мастеров, макетов и слайдов.
- Преобразовать презентацию с диаграммами.
- Преобразовать презентацию с группированными фигурами, автофигурками (например, прямоугольниками и эллипсами), фигурами с пользовательской геометрией.
- Преобразовать презентацию, содержащую текстуры и стили заполнения изображениями для автофигур.
- Преобразовать презентацию с заполнителями, текстовыми фреймами и текстовыми полями.

{{% alert color="primary" %}} 

Посмотрите приложение [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе **Aspose.Slides API**, поэтому вы можете увидеть живой пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — это веб‑приложение, которое позволяет загрузить файл презентации в формате PPT и скачать его конвертированным в PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **Конвертировать PPT в PPTX**

Чтобы конвертировать PPT в PPTX, просто передайте имя файла и формат сохранения методу [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) method of [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) class. Пример кода на C# ниже конвертирует презентацию из PPT в PPTX, используя параметры по умолчанию.
```c#
// Создайте объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Сохранение презентации PPTX в формате PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


Подробнее о [**PPT vs PPTX**](/slides/ru/net/ppt-vs-pptx/) форматах презентаций и о том, как [**Aspose.Slides supports PPT to PPTX conversion**](/slides/ru/net/convert-ppt-to-pptx/).

## **FAQ**

**В чем разница между форматами PPT и PPTX?**

PPT — это более старый бинарный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — новый формат на основе XML, представленный в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и улучшенное восстановление данных.

**Могу ли я конвертировать PPT в PPTX с помощью .NET?**

Да, используя библиотеку Aspose.Slides для .NET, вы можете легко загрузить файл PPT и сохранить его в формате PPTX всего несколькими строками кода.

**Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программной конвертации нескольких файлов PPT в PPTX, что подходит для пакетных сценариев.

**Сохранятся ли содержимое и форматирование после конвертации?**

Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при конвертации PPT в PPTX.

**Могу ли я конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает конвертацию файлов PPT в различные форматы, включая PDF, XPS, HTML, ODP и графические форматы, такие как PNG и JPEG.

**Возможно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides для .NET — это автономный API, не требующий установки Microsoft PowerPoint или какого‑либо стороннего программного обеспечения для выполнения конвертации.

**Есть ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете использовать бесплатное веб‑приложение [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения конвертации прямо в браузере без написания кода.