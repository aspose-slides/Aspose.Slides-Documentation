---
title: Преобразовать PPT в PPTX на Android
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Конвертируйте старые презентации PPT в современные PPTX быстро на Java с помощью Aspose.Slides для Android — понятный учебник, бесплатные примеры кода, без зависимости от Microsoft Office."
---

## **Обзор**

Эта статья объясняет, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью Java и онлайн‑приложения для конвертации PPT в PPTX. Рассмотрены следующие темы.

- Преобразование PPT в PPTX на Java

## **Преобразование PPT в PPTX на Android**

Для примера кода Java по преобразованию PPT в PPTX смотрите раздел ниже, т.е. [Convert PPT to PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая разные форматы сохранения, вы также можете сохранять файл PPT в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как обсуждается в этих статьях.

- [Java Конвертация PPT в PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java Конвертация PPT в XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java Конвертация PPT в HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java Конвертация PPT в ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java Конвертация PPT в изображение](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **О преобразовании PPT в PPTX**
Преобразуйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если вам необходимо преобразовать тысячи презентаций PPT в формат PPTX, лучшим решением будет сделать это программно. С Aspose.Slides API это возможно выполнить всего в несколько строк кода. API обеспечивает полную совместимость при преобразовании презентаций PPT в PPTX, и возможно:

- Преобразовать сложные структуры мастеров, макетов и слайдов.
- Преобразовать презентацию с диаграммами.
- Преобразовать презентацию с групповыми фигурами, автофигурами (например, прямоугольниками и эллипсами), фигурами с пользовательской геометрией.
- Преобразовать презентацию, содержащую текстуры и стили заливки изображениями для автофигур.
- Преобразовать презентацию с заполнителями, текстовыми фреймами и текстовыми контейнерами.

{{% alert color="primary" %}} 

Посмотрите приложение [**Aspose.Slides PPT в PPTX Конвертация**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/), поэтому вы можете увидеть живой пример базовых возможностей преобразования PPT в PPTX. Aspose.Slides Conversion — это веб‑приложение, которое позволяет перетащить файл презентации в формате PPT и загрузить его в виде конвертированного файла PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

## **Преобразование PPT в PPTX**
Aspose.Slides for Android via Java теперь позволяет разработчикам получать доступ к PPT с помощью класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и конвертировать его в соответствующий формат [PPTX](https://docs.fileformat.com/presentation/pptx/). В настоящее время поддерживается частичное преобразование [PPT](https://docs.fileformat.com/presentation/ppt/) в PPTX. Для получения более подробной информации о поддерживаемых и неподдерживаемых функциях преобразования PPT в PPTX перейдите к этой документации [link](/slides/ru/androidjava/ppt-to-pptx-conversion/).

Aspose.Slides for Android via Java предлагает класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation), который представляет файл презентации **PPTX**. Класс Presentation теперь также может получить доступ к **PPT** через объект Presentation при его создании. Ниже приведён пример, показывающий, как преобразовать презентацию PPT в презентацию PPTX.
```java
// Создайте объект Presentation, который представляет файл PPTX
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
|**Рисунок : Исходная PPT презентация**|

Вышеприведённый фрагмент кода создал следующую презентацию PPTX после преобразования

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Рисунок: Сгенерированная PPTX презентация после конвертации**|

## **Вопросы и ответы**

**В чём разница между форматами PPT и PPTX?**

PPT — это старый двоичный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — более новый XML‑основной формат, представленный в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и улучшенное восстановление данных.

**Поддерживает ли Aspose.Slides пакетное преобразование нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программного преобразования множества файлов PPT в PPTX, что подходит для сценариев пакетного преобразования.

**Будут ли содержимое и форматирование сохранены после конвертации?**

Aspose.Slides сохраняет высокую точность при преобразовании презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются при преобразовании PPT в PPTX.

**Могу ли я конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает преобразование файлов PPT в [множество форматов](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/), включая PDF, XPS, HTML, ODP и графические форматы, такие как PNG и JPEG.

**Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides — это автономный API и не требует Microsoft PowerPoint или какого‑либо стороннего программного обеспечения для выполнения конвертации.

**Существует ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете воспользоваться бесплатным [Aspose.Slides PPT в PPTX Конвертер](https://products.aspose.app/slides/conversion/ppt-to-pptx) веб‑приложением, чтобы выполнить преобразование непосредственно в браузере без написания кода.