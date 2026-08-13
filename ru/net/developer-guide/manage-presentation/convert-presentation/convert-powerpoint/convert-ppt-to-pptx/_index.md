---
title: Конвертация PPT в PPTX в .NET
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/net/convert-ppt-to-pptx/
keywords:
  - конвертация PowerPoint
  - конвертация презентации
  - конвертация слайда
  - конвертировать PPT
  - PPT в PPTX
  - сохранить PPT как PPTX
  - экспортировать PPT в PPTX
  - PowerPoint
  - презентация
  - .NET
  - C#
  - Aspose.Slides
description: "Конвертируйте старые презентации PPT в современные PPTX быстро в .NET с помощью Aspose.Slides — понятный учебник, бесплатные примеры кода C#, без зависимости от Microsoft Office."
---
## **Обзор**

Эта статья объясняет, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью C# и онлайн‑приложения для преобразования PPT в PPTX. Рассмотрены следующие темы.

- [Преобразовать PPT в PPTX на C#](#convert-ppt-to-pptx)

## **Преобразование PPT в PPTX в .NET**

Для образца кода C# по преобразованию PPT в PPTX см. раздел ниже, то есть [Преобразовать PPT в PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая различные форматы сохранения, вы также можете сохранять файл PPT во многих других форматах, таких как PDF, XPS, ODP, HTML и др., как обсуждается в этих статьях. 

- [Преобразовать PPT в PDF в .NET](/slides/ru/net/convert-powerpoint-to-pdf/)
- [Преобразовать PPT в XPS в .NET](/slides/ru/net/convert-powerpoint-to-xps/)
- [Преобразовать PPT в HTML в .NET](/slides/ru/net/convert-powerpoint-to-html/)
- [Преобразовать PPT в ODP в .NET](/slides/ru/net/save-presentation/)
- [Преобразовать PPT в PNG в .NET](/slides/ru/net/convert-powerpoint-to-png/)

## **О преобразовании PPT в PPTX**
Преобразуйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если вам нужно конвертировать тысячи презентаций PPT в формат PPTX, лучшим решением является выполнение этого программно. С Aspose.Slides API это возможно сделать всего в несколько строк кода. API обеспечивает полную совместимость при преобразовании презентации PPT в PPTX и позволяет:

- Преобразовать сложные структуры шаблонов, макетов и слайдов.
- Преобразовать презентацию с диаграммами.
- Преобразовать презентацию с групповыми фигурами, автофигурами (например, прямоугольниками и эллипсами), фигурами с пользовательской геометрией.
- Преобразовать презентацию, содержащую текстуры и изображения для заливки автофигур.
- Преобразовать презентацию с заполнителями, текстовыми кадрами и текстовыми контейнерами.

{{% alert color="info" %}} 

Ознакомьтесь с приложением [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx)

Это приложение построено на основе **Aspose.Slides API**, поэтому вы можете увидеть живой пример базовых возможностей преобразования PPT в PPTX. Aspose.Slides Conversion — это веб‑приложение, позволяющее перетащить файл презентации в формате PPT и загрузить его преобразованным в PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/ru/conversion/).

{{% /alert %}} 

## **Преобразование PPT в PPTX**
Чтобы преобразовать PPT в PPTX, просто передайте имя файла и формат сохранения методу [**Save**](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/methods/save/index) класса [**Presentation**](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation). Приведённый ниже образец кода C# преобразует презентацию из PPT в PPTX, используя параметры по умолчанию.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Сохранение презентации PPTX в формате PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

Подробнее о форматах презентаций [**PPT vs PPTX**](/slides/ru/net/ppt-vs-pptx/) и о том, как [**Aspose.Slides поддерживает преобразование PPT в PPTX**](/slides/ru/net/convert-ppt-to-pptx/).

## **Часто задаваемые вопросы**

### Какова разница между форматами PPT и PPTX?

PPT — это более старый бинарный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — новый формат на основе XML, введённый в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и улучшенное восстановление данных.

### Можно ли конвертировать PPT в PPTX с помощью .NET?

Да, используя библиотеку Aspose.Slides для .NET, вы можете легко загрузить файл PPT и сохранить его в формате PPTX, используя всего несколько строк кода.

### Поддерживает ли Aspose.Slides пакетное преобразование нескольких файлов PPT в PPTX?

Да, вы можете использовать Aspose.Slides в цикле для программного преобразования нескольких файлов PPT в PPTX, что подходит для сценариев пакетного преобразования.

### Сохранится ли содержание и форматирование после преобразования?

Aspose.Slides сохраняет высокую точность при преобразовании презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при преобразовании PPT в PPTX.

### Могу ли я конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?

Да, Aspose.Slides поддерживает преобразование файлов PPT в различные форматы, включая PDF, XPS, HTML, ODP и графические форматы, такие как PNG и JPEG.

### Возможно ли преобразовать PPT в PPTX без установленного Microsoft PowerPoint?

Да, Aspose.Slides для .NET — это автономный API, который не требует наличия Microsoft PowerPoint или какого-либо стороннего программного обеспечения для выполнения преобразования.

### Есть ли онлайн‑инструмент для преобразования PPT в PPTX?

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx) для выполнения преобразования непосредственно в браузере без написания кода.