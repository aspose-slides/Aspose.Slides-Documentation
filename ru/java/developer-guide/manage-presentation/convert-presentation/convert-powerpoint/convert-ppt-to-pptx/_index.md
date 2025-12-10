---
title: Конвертировать PPT в PPTX на Java
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Конвертировать устаревшие PPT-презентации в современные PPTX быстро на Java с Aspose.Slides — понятный учебник, бесплатные образцы кода, без зависимости от Microsoft Office."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью Java и онлайн‑приложения для конвертации PPT в PPTX. Рассмотрены следующие темы.

- Конвертация PPT в PPTX в Java

## **Конвертация PPT в PPTX в Java**

Для примера кода Java, преобразующего PPT в PPTX, см. раздел ниже — [Convert PPT to PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указав другие форматы сохранения, вы также можете экспортировать PPT в множество других форматов, таких как PDF, XPS, ODP, HTML и др., как обсуждается в этих статьях.

- [Java Convert PPT to PDF](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java Convert PPT to XPS](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java Convert PPT to HTML](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java Convert PPT to ODP](https://docs.aspose.com/slides/java/save-presentation/)
- [Java Convert PPT to Image](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**
Преобразуйте старый формат PPT в PPTX с помощью API Aspose.Slides. Если вам нужно конвертировать тысячи презентаций PPT в формат PPTX, лучше всего сделать это программно. С API Aspose.Slides это возможно выполнить в пару строк кода. API обеспечивает полную совместимость при конвертации презентаций PPT в PPTX и позволяет:

- Конвертировать сложные структуры мастеров, макетов и слайдов.
- Конвертировать презентации с диаграммами.
- Конвертировать презентации с групповыми фигурами, автофигурами (например, прямоугольниками и эллипсами), фигурами с пользовательской геометрией.
- Конвертировать презентации, содержащие текстуры и стили заливки изображениями для автофигур.
- Конвертировать презентации с заполнителями, текстовыми фреймами и текстовыми контейнерами.

{{% alert color="primary" %}} 

Посмотрите приложение [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе [**Aspose.Slides API**](https://products.aspose.com/slides/java/), поэтому вы можете увидеть живой пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — это веб‑приложение, позволяющее перетащить файл презентации в формате PPT и скачать его в формате PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

## **Конвертация PPT в PPTX**
Aspose.Slides for Java теперь позволяет разработчикам получать доступ к PPT через экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) и преобразовывать его в соответствующий формат [PPTX](https://docs.fileformat.com/presentation/pptx/). В настоящее время поддерживается частичная конвертация [PPT](https://docs.fileformat.com/presentation/ppt/) в PPTX. Для получения более подробной информации о поддерживаемых и неподдерживаемых возможностях конвертации PPT в PPTX см. эту документацию [link](/slides/ru/java/ppt-to-pptx-conversion/).

Aspose.Slides for Java предоставляет класс [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation), представляющий файл презентации **PPTX**. Класс Presentation теперь также может работать с **PPT**, когда объект создаётся. Ниже показан пример того, как преобразовать презентацию PPT в презентацию PPTX.
```java
// Создать объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
// Сохранение PPTX презентации в формате PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Рисунок : Исходная PPT‑презентация**|

В результате выполнения приведённого кода будет сгенерирована следующая презентация PPTX после конвертации

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Рисунок : Сгенерированная PPTX‑презентация после конвертации**|

## **Вопросы и ответы**

**В чем разница между форматами PPT и PPTX?**

PPT — это старый двоичный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — новый основанный на XML формат, введённый в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и повышенную возможность восстановления данных.

**Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программной конвертации множества файлов PPT в PPTX, что подходит для пакетных сценариев.

**Будут ли сохранены содержание и форматирование после конвертации?**

Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимация, фигуры, диаграммы и другие элементы дизайна сохраняются при переходе из PPT в PPTX.

**Можно ли конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает конвертацию файлов PPT в [множество форматов](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/), включая PDF, XPS, HTML, ODP и графические форматы, такие как PNG и JPEG.

**Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides — автономное API и не требует наличия Microsoft PowerPoint или стороннего программного обеспечения для выполнения конвертации.

**Существует ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете использовать бесплатное веб‑приложение [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения конвертации прямо в браузере без написания кода.