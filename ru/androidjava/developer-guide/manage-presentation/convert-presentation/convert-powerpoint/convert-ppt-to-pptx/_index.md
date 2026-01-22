---
title: Преобразование PPT в PPTX на Android
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/androidjava/convert-ppt-to-pptx/
keywords:
- конвертировать PowerPoint
- преобразовать презентацию
- преобразовать слайд
- преобразовать PPT
- PPT в PPTX
- сохранить PPT как PPTX
- экспортировать PPT в PPTX
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Быстро преобразуйте устаревшие презентации PPT в современный формат PPTX на Java с Aspose.Slides для Android — понятный учебник, бесплатные образцы кода, без зависимости от Microsoft Office."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью Java и онлайн‑приложения для конвертации PPT в PPTX. Рассмотрены следующие темы.

- Преобразовать PPT в PPTX на Java

## **Преобразование PPT в PPTX на Android**

Для образца кода Java по преобразованию PPT в PPTX, смотрите раздел ниже, т. е. [Convert PPT to PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая различные форматы сохранения, вы также можете сохранять файл PPT во множество других форматов, таких как PDF, XPS, ODP, HTML и т. д., как обсуждается в этих статьях.

- [Преобразовать PPT в PDF на Android](/slides/ru/androidjava/convert-powerpoint-to-pdf/)
- [Преобразовать PPT в XPS на Android](/slides/ru/androidjava/convert-powerpoint-to-xps/)
- [Преобразовать PPT в HTML на Android](/slides/ru/androidjava/convert-powerpoint-to-html/)
- [Преобразовать PPT в ODP на Android](/slides/ru/androidjava/save-presentation/)
- [Преобразовать PPT в PNG на Android](/slides/ru/androidjava/convert-powerpoint-to-png/)

## **О преобразовании PPT в PPTX**

Преобразуйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если вам нужно преобразовать тысячи презентаций PPT в формат PPTX, оптимальное решение — делать это программно. С Aspose.Slides API это возможно выполнить всего в несколько строк кода. API поддерживает полную совместимость для преобразования презентаций PPT в PPTX и позволяет:

- Преобразовывать сложные структуры мастеров, разметок и слайдов.
- Преобразовывать презентацию с диаграммами.
- Преобразовывать презентацию с групповыми фигурами, автофигурами (например, прямоугольниками и эллипсами), фигурами с пользовательской геометрией.
- Преобразовывать презентацию, содержащую текстуры и стили заполнения изображениями для автофигур.
- Преобразовывать презентацию с заполнителями, текстовыми фреймами и держателями текста.

{{% alert color="primary" %}} 

Ознакомьтесь с приложением [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/), поэтому вы можете увидеть живой пример базовых возможностей преобразования PPT в PPTX. Aspose.Slides Conversion — веб‑приложение, позволяющее загрузить файл презентации в формате PPT и скачать его в виде преобразованного в PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **Преобразование PPT в PPTX**

Aspose.Slides для Android через Java теперь упрощает разработчикам доступ к PPT с помощью экземпляра класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и его преобразование в соответствующий формат [PPTX](https://docs.fileformat.com/presentation/pptx/). В настоящее время поддерживается частичное преобразование [PPT ](https://docs.fileformat.com/presentation/ppt/)в PPTX.

Aspose.Slides для Android через Java предоставляет класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation), который представляет файл презентации **PPTX**. Класс Presentation теперь также может получить доступ к **PPT** через Presentation при создании объекта. Следующий пример показывает, как преобразовать презентацию PPT в презентацию PPTX.

```java
// Создать объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
// Сохранение презентации PPTX в формат PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Рисунок : Исходная презентация PPT**|

Приведенный выше фрагмент кода создал следующую презентацию PPTX после конвертации

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Рисунок: Сгенерированная презентация PPTX после конвертации**|

## **FAQ**

**В чём разница между форматами PPT и PPTX?**

PPT — это более старый бинарный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — более новый формат на основе XML, представленный в Microsoft Office 2007. Файлы PPTX обеспечивают более высокую производительность, меньший размер и улучшенное восстановление данных.

**Поддерживает ли Aspose.Slides пакетное преобразование нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программного преобразования нескольких файлов PPT в PPTX, что делает его подходящим для пакетных сценариев конвертации.

**Сохраняются ли содержимое и форматирование после конвертации?**

Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются во время преобразования PPT в PPTX.

**Можно ли преобразовать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает преобразование файлов PPT в [множество форматов](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/), включая PDF, XPS, HTML, ODP и форматы изображений, такие как PNG и JPEG.

**Можно ли преобразовать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides — это автономный API и не требует наличия Microsoft PowerPoint или какого-либо стороннего программного обеспечения для выполнения конвертации.

**Есть ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения конверсии непосредственно в браузере без написания кода.