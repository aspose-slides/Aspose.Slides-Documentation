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
description: "Быстро конвертируйте устаревшие PPT‑презентации в современный PPTX в .NET с помощью Aspose.Slides — понятный учебник, бесплатные примеры кода на C#, без зависимости от Microsoft Office."
---

## **Обзор**

Эта статья объясняет, как конвертировать презентацию PowerPoint в формате PPT в формат PPTX с помощью C# и онлайн‑приложения для конвертации PPT в PPTX. Следующая тема рассматривается.

- [Конвертировать PPT в PPTX на C#](#convert-ppt-to-pptx)

## **C# Конвертация PPT в PPTX**

Для образца кода C# для конвертации PPT в PPTX смотрите раздел ниже, т.е. [Convert PPT to PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая разные форматы сохранения, вы также можете сохранять файл PPT во многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях. 

- [C# Конвертация PPT в PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Конвертация PPT в XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Конвертация PPT в HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Конвертация PPT в ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Конвертация PPT в изображение](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**
Конвертировать старый формат PPT в PPTX с помощью Aspose.Slides API. Если вам нужно конвертировать тысячи презентаций PPT в формат PPTX, лучшее решение — делать это программно. С Aspose.Slides API это возможно выполнить всего в несколько строк кода. API поддерживает полную совместимость для конвертации презентации PPT в PPTX и позволяет:

- Конвертировать сложные структуры шаблонов (masters), макетов и слайдов.
- Конвертировать презентацию с диаграммами.
- Конвертировать презентацию с групповыми объектами, автофигурами (например, прямоугольниками и эллипсами), объектами с пользовательской геометрией.
- Конвертировать презентацию, содержащую текстуры и стили заполнения изображениями для автофигур.
- Конвертировать презентацию с заполнителями, текстовыми фреймами и текстовыми контейнерами.

{{% alert color="primary" %}} 

Посмотрите приложение [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе **Aspose.Slides API**, поэтому вы можете увидеть живой пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — это веб‑приложение, которое позволяет перетащить файл презентации в формате PPT и скачать его в формате PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **Конвертация PPT в PPTX**
Чтобы конвертировать PPT в PPTX, просто передайте имя файла и формат сохранения в метод [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) класса [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation). Приведённый ниже пример кода C# конвертирует презентацию из PPT в PPTX, используя параметры по умолчанию.
```c#
// Создать объект Presentation, представляющий файл PPTX
// Сохранение PPTX-презентации в формате PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Saving the PPTX presentation to PPTX format
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


Подробнее о форматах презентаций [**PPT vs PPTX**](/slides/ru/net/ppt-vs-pptx/) и о том, как [**Aspose.Slides поддерживает конвертацию PPT в PPTX**](/slides/ru/net/convert-ppt-to-pptx/).

## **Часто задаваемые вопросы**
**В чём разница между форматами PPT и PPTX?**

PPT — это более старый двоичный формат файла, используемый Microsoft PowerPoint, тогда как PPTX — более новый основанный на XML формат, представленный в Microsoft Office 2007. Файлы PPTX обеспечивают более высокую производительность, меньший размер и улучшенное восстановление данных.

**Могу ли я конвертировать PPT в PPTX с помощью .NET?**

Да, используя библиотеку Aspose.Slides для .NET, вы легко можете загрузить файл PPT и сохранить его в формате PPTX всего несколькими строками кода.

**Поддерживает ли Aspose.Slides пакетную конвертацию многих файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программной конвертации нескольких файлов PPT в PPTX, что делает его подходящим для сценариев пакетной конвертации.

**Сохраняются ли содержимое и форматирование после конвертации?**

Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при конвертации PPT в PPTX.

**Могу ли я конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает конвертацию файлов PPT в несколько форматов, включая PDF, XPS, HTML, ODP и форматы изображений, такие как PNG и JPEG.

**Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides для .NET — это автономный API и не требует установки Microsoft PowerPoint или какого‑либо стороннего программного обеспечения для выполнения конвертации.

**Существует ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения конвертации непосредственно в браузере без написания кода.