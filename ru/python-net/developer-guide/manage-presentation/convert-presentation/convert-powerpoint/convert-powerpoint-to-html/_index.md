---
title: Конвертировать презентации PowerPoint в HTML на Python
linktitle: PowerPoint в HTML
type: docs
weight: 30
url: /ru/python-net/developer-guide/manage-presentation/convert-presentation/convert-powerpoint/convert-powerpoint-to-html/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to HTML
- presentation to HTML
- slide to HTML
- PPT to HTML
- PPTX to HTML
- save PowerPoint as HTML
- save presentation as HTML
- save slide as HTML
- save PPT as HTML
- save PPTX as HTML
- Python
- Aspose.Slides
description: "Конвертируйте презентации PowerPoint в адаптивный HTML на Python. Сохраняйте макет, ссылки и изображения с помощью руководства по конвертации Aspose.Slides для быстрого и безупречного результата."
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формат HTML с помощью Python. Рассматриваются следующие темы.

- Конвертировать PowerPoint в HTML на Python
- Конвертировать PPT в HTML на Python
- Конвертировать PPTX в HTML на Python
- Конвертировать ODP в HTML на Python
- Конвертировать слайд PowerPoint в HTML на Python

## **Python PowerPoint в HTML**

Для примера кода на Python, конвертирующего PowerPoint в HTML, смотрите раздел ниже — [Convert PowerPoint to HTML](#convert-powerpoint-to-html). Код может загружать различные форматы, такие как PPT, PPTX и ODP, в объект Presentation и сохранять их в формате HTML.

## **О конвертации PowerPoint в HTML**
С помощью [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/), приложения и разработчики могут конвертировать презентацию PowerPoint в HTML: **PPTX в HTML** или **PPT в HTML**. 

**Aspose.Slides** предоставляет множество вариантов (в основном из класса [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)), определяющих процесс конвертации PowerPoint в HTML:

* Конвертировать всю презентацию PowerPoint в HTML.
* Конвертировать отдельный слайд презентации PowerPoint в HTML.
* Конвертировать медиаконтент презентации (изображения, видео и др.) в HTML.
* Конвертировать презентацию PowerPoint в адаптивный HTML. 
* Конвертировать презентацию PowerPoint в HTML с включёнными или исключёнными нотатками выступающего. 
* Конвертировать презентацию PowerPoint в HTML с включёнными или исключёнными комментариями. 
* Конвертировать презентацию PowerPoint в HTML с оригинальными или встроенными шрифтами. 
* Конвертировать презентацию PowerPoint в HTML, используя новый стиль CSS. 

{{% alert color="primary" %}} 

С помощью собственного API Aspose разработала бесплатные конвертеры [презентация в HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT в HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX в HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP в HTML](https://products.aspose.app/slides/conversion/odp-to-html) и др. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Вы также можете ознакомиться с другими [бесплатными конвертерами от Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Помимо описанных здесь процессов конвертации, Aspose.Slides поддерживает и следующие операции с форматом HTML: 

* [HTML в изображение](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **Конвертировать PowerPoint в HTML**
С помощью Aspose.Slides вы можете конвертировать всю презентацию PowerPoint в HTML следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. Вызовите метод [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) для сохранения объекта в виде HTML‑файла.

Этот код демонстрирует, как конвертировать PowerPoint в HTML на Python:

```python
import aspose.slides as slides

# Создаём объект Presentation, представляющий файл презентации
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Сохраняем презентацию в HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **Конвертировать PowerPoint в адаптивный HTML**

Aspose.Slides предоставляет класс [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/), позволяющий генерировать адаптивные HTML‑файлы. Этот код показывает, как конвертировать презентацию PowerPoint в адаптивный HTML на Python:

```py
# Создаём объект Presentation, представляющий файл презентации
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Сохраняем презентацию в HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **Конвертировать PowerPoint в HTML с нотатками**
Этот код показывает, как конвертировать PowerPoint в HTML с нотатками на Python:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **Конвертировать PowerPoint в HTML с оригинальными шрифтами**
Aspose.Slides предоставляет класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/), позволяющий внедрять все шрифты презентации при конвертации в HTML.

Чтобы исключить определённые шрифты из внедрения, можно передать массив имён шрифтов в параметризованный конструктор класса [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Популярные шрифты, такие как Calibri или Arial, обычно уже присутствуют в системе, поэтому их внедрение лишь увеличивает размер итогового HTML‑документа.

Класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) поддерживает наследование и предоставляет метод `WriteFont`, предназначенный для переопределения. 

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# исключаем шрифты по умолчанию
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **Конвертировать слайд в HTML**
Конвертировать отдельный слайд презентации в HTML. Для этого используйте тот же метод [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), предоставляемый классом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), который применяется для конвертации всей презентации PPT(X) в HTML‑документ. Класс [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) также может использоваться для задания дополнительных параметров конвертации:

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```

## **Сохранение CSS и изображений при экспорте в HTML**
Используя новые CSS‑файлы стилей, вы можете легко изменить внешний вид HTML‑файла, полученного в результате конвертации PowerPoint в HTML. 

Python‑код в этом примере демонстрирует, как с помощью переопределяемых методов создать пользовательский HTML‑документ со ссылкой на CSS‑файл:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Связывание всех шрифтов при конвертации презентации в HTML**
Если вы не хотите внедрять шрифты (чтобы избежать увеличения размера HTML), можно связать все шрифты, реализовав собственную версию `LinkAllFontsHtmlController`. 

Этот Python‑код показывает, как конвертировать PowerPoint в HTML, связывая все шрифты и исключая «Calibri» и «Arial» (поскольку они уже присутствуют в системе): 

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Поддержка свойства SVG Responsive**
Пример кода ниже показывает, как экспортировать презентацию PPT(X) в HTML с адаптивным макетом:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **Экспорт медиа‑файлов в HTML‑файл**
С помощью Aspose.Slides for Python вы можете экспортировать медиа‑файлы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд.
3. Добавьте видео на слайд.
4. Сохраните презентацию как HTML‑файл.

Этот Python‑код показывает, как добавить видео в презентацию и затем сохранить её в HTML:

```py
import aspose.slides as slides

# Загрузка презентации
presentation = slides.Presentation("Media File.pptx")

path = "C:\\"
fileName = "ExportMediaFiles_out.html"
baseUri = "http://www.example.com/"

controller = slides.export.VideoPlayerHtmlController(path, fileName, baseUri)

htmlOptions = slides.export.HtmlOptions(controller)
svgOptions = slides.export.SVGOptions(controller)

htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
htmlOptions.slide_image_format = slides.export.SlideImageFormat.svg(svgOptions)

presentation.save(path + "ExportMediaFiles_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## Часто задаваемые вопросы

### **Как конвертировать презентацию PowerPoint в HTML с помощью Python?**

Можно использовать библиотеку Aspose.Slides for Python via .NET для загрузки файлов PPT, PPTX или ODP и конвертации их в HTML с помощью метода `save()` и параметра `SaveFormat.HTML`.

### **Поддерживает ли Aspose.Slides конвертацию отдельных слайдов PowerPoint в HTML?**

Да, Aspose.Slides позволяет конвертировать как всю презентацию, так и отдельные слайды в HTML, задав соответствующие параметры `HtmlOptions`.

### **Можно ли генерировать адаптивный HTML из презентаций PowerPoint?**

Да, класс `ResponsiveHtmlController` позволяет экспортировать презентацию в адаптивный HTML‑макет, который подстраивается под различные размеры экрана.

### **Можно ли включить нотатки выступающего или комментарии в экспортированный HTML?**

Да, можно настроить `HtmlOptions` для включения или исключения нотаток выступающего и комментариев при экспорте презентаций PowerPoint в HTML.

### **Можно ли внедрять шрифты при конвертации презентации в HTML?**

Да, Aspose.Slides предоставляет класс `EmbedAllFontsHtmlController`, который позволяет внедрять шрифты или исключать определённые шрифты для уменьшения размеров итогового файла.

### **Поддерживает ли конвертация PowerPoint в HTML медиафайлы, такие как видео и аудио?**

Да, Aspose.Slides позволяет экспортировать медиаконтент, встроенный в слайды, в HTML с помощью `VideoPlayerHtmlController` и связанных классов конфигурации.

### **Какие форматы файлов поддерживаются для конвертации в HTML?**

Aspose.Slides поддерживает конвертацию форматов PPT, PPTX и ODP в HTML. Кроме того, возможно сохранять содержимое слайдов как SVG и экспортировать медиаресурсы.

### **Можно ли избежать внедрения шрифтов для уменьшения размера HTML‑вывода?**

Да, вместо внедрения можно связать общедоступные системные шрифты, такие как Arial или Calibri, реализовав собственную версию `HtmlController`.

### **Есть ли онлайн‑инструмент для конвертации PowerPoint в HTML?**

Да, вы можете воспользоваться бесплатными веб‑инструментами Aspose, например [PPT в HTML](https://products.aspose.app/slides/conversion/ppt-to-html) или [PPTX в HTML](https://products.aspose.app/slides/conversion/pptx-to-html), чтобы конвертировать презентации прямо в браузере без написания кода.

### **Можно ли использовать пользовательские CSS‑стили в экспортированном HTML‑файле?**

Да, Aspose.Slides позволяет привязывать внешние CSS‑файлы во время конвертации, что даёт полную свободу настройки внешнего вида получаемого HTML‑контента.