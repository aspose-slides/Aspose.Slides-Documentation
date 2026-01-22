---
title: Конвертация PPT в PPTX на Java
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
description: "Быстро конвертируйте устаревшие презентации PPT в современные PPTX на Java с помощью Aspose.Slides — понятный учебник, бесплатные примеры кода, без зависимости от Microsoft Office."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формате PPT в формат PPTX с помощью Java и онлайн‑приложения для конвертации PPT в PPTX. Рассмотрены следующие темы.

- Преобразовать PPT в PPTX на Java

## **Преобразовать PPT в PPTX на Java**

Для примера кода на Java по преобразованию PPT в PPTX см. раздел ниже — [Преобразовать PPT в PPTX](#convert-ppt-to-pptx). Он просто загружает файл PPT и сохраняет его в формате PPTX. Указывая различные форматы сохранения, можно также сохранять файл PPT в многие другие форматы, такие как PDF, XPS, ODP, HTML и т.д., как описано в этих статьях.

- [Преобразовать PPT в PDF на Java](/slides/ru/java/convert-powerpoint-to-pdf/)
- [Преобразовать PPT в XPS на Java](/slides/ru/java/convert-powerpoint-to-xps/)
- [Преобразовать PPT в HTML на Java](/slides/ru/java/convert-powerpoint-to-html/)
- [Преобразовать PPT в ODP на Java](/slides/ru/java/save-presentation/)
- [Преобразовать PPT в PNG на Java](/slides/ru/java/convert-powerpoint-to-png/)

## **О конвертации PPT в PPTX**

Преобразуйте старый формат PPT в PPTX с помощью Aspose.Slides API. Если нужно конвертировать тысячи презентаций PPT в формат PPTX, лучшим решением будет выполнить это программно. С Aspose.Slides API это возможно сделать всего в нескольких строках кода. API обеспечивает полную совместимость при конвертации презентаций PPT в PPTX, и возможно:

- Конвертировать сложные структуры шаблонов, макетов и слайдов.
- Конвертировать презентацию с диаграммами.
- Конвертировать презентацию с групповыми фигурами, автофигурками (например, прямоугольниками и эллипсами), фигурами с пользовательской геометрией.
- Конвертировать презентацию, содержащую текстуры и изображения в качестве заливки автофигур.
- Конвертировать презентацию с заполнителями, текстовыми кадрами и текстовыми полями.

{{% alert color="primary" %}} 

Взгляните на приложение [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Это приложение построено на основе [**Aspose.Slides API**](https://products.aspose.com/slides/java/), поэтому вы можете увидеть живой пример базовых возможностей конвертации PPT в PPTX. Aspose.Slides Conversion — веб‑приложение, позволяющее перетащить файл презентации в формате PPT и загрузить его в виде конвертированного файла PPTX.

Найдите другие живые примеры [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **Преобразовать PPT в PPTX**

Aspose.Slides for Java теперь позволяет разработчикам получить доступ к PPT через класс [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) и преобразовать его в соответствующий формат [PPTX](https://docs.fileformat.com/presentation/pptx/). В настоящее время поддерживается частичная конвертация [PPT ](https://docs.fileformat.com/presentation/ppt/) в PPTX. Для получения подробной информации о поддерживаемых и неподдерживаемых функциях при конвертации PPT в PPTX перейдите к этой документации [ссылка](/slides/ru/java/ppt-to-pptx-conversion/).

Aspose.Slides for Java предоставляет класс [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation), который представляет **PPTX**‑презентацию. Класс Presentation теперь также может получать доступ к **PPT**, когда объект создаётся. Ниже показан пример того, как преобразовать презентацию PPT в презентацию PPTX.
```java
// Создание объекта Presentation, представляющего файл PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
// Сохранение презентации PPTX в формате PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Рисунок: Исходная PPT‑презентация**|

Вышеприведённый фрагмент кода сгенерировал следующую PPTX‑презентацию после конвертации

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Рисунок: Сгенерированная PPTX‑презентация после конвертации**|

## **Часто задаваемые вопросы**

**В чём разница между форматами PPT и PPTX?**

PPT — это более старый бинарный формат файлов, используемый Microsoft PowerPoint, тогда как PPTX — это более новый формат на основе XML, представленный в Microsoft Office 2007. Файлы PPTX обеспечивают лучшую производительность, меньший размер и улучшенное восстановление данных.

**Поддерживает ли Aspose.Slides пакетную конвертацию нескольких файлов PPT в PPTX?**

Да, вы можете использовать Aspose.Slides в цикле для программного преобразования множества файлов PPT в PPTX, что подходит для пакетных сценариев.

**Будут ли сохранены содержимое и форматирование после конвертации?**

Aspose.Slides сохраняет высокую точность при конвертации презентаций. Макеты слайдов, анимации, фигуры, диаграммы и другие элементы дизайна сохраняются во время преобразования PPT в PPTX.

**Могу ли я конвертировать другие форматы, такие как PDF или HTML, из файлов PPT?**

Да, Aspose.Slides поддерживает конвертацию файлов PPT в [множество форматов](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/), включая PDF, XPS, HTML, ODP и графические форматы, такие как PNG и JPEG.

**Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да, Aspose.Slides — это автономное API и не требует Microsoft PowerPoint или любого стороннего программного обеспечения для выполнения конвертации.

**Существует ли онлайн‑инструмент для конвертации PPT в PPTX?**

Да, вы можете воспользоваться бесплатным веб‑приложением [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) для выполнения конвертации непосредственно в браузере без написания кода.