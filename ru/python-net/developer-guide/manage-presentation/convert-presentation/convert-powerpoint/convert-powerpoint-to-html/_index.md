---
title: Конвертация PowerPoint в HTML на Python
linktitle: Конвертация PowerPoint в HTML
type: docs
weight: 30
url: /python-net/convert-powerpoint-to-html/
keywords: "Python PowerPoint в HTML, Конвертация презентации PowerPoint, PPTX, PPT, PPT в HTML, PPTX в HTML, PowerPoint в HTML, Сохранить PowerPoint как HTML, Сохранить PPT как HTML, Сохранить PPTX как HTML, Python, Aspose.Slides, экспорт HTML"
description: "Конвертация PowerPoint в HTML: Сохраните PPTX или PPT в HTML. Сохраните слайды как HTML"
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формат HTML с помощью Python. Рассматриваются следующие темы:

- Конвертация PowerPoint в HTML на Python
- Конвертация PPT в HTML на Python
- Конвертация PPTX в HTML на Python
- Конвертация ODP в HTML на Python
- Конвертация слайда PowerPoint в HTML на Python

## **Python PowerPoint в HTML**

Для примера кода на Python для конвертации PowerPoint в HTML смотрите следующий раздел, т.е. [Конвертация PowerPoint в HTML](#convert-powerpoint-to-html). Код может загружать множество форматов, таких как PPT, PPTX и ODP в объекте Presentation и сохранять его в формате HTML.


## **О конвертации PowerPoint в HTML**
С помощью [**Aspose.Slides для Python через .NET**](https://products.aspose.com/slides/python-net/) приложения и разработчики могут конвертировать презентацию PowerPoint в HTML: **PPTX в HTML** или **PPT в HTML**.

**Aspose.Slides** предоставляет множество опций (в основном из класса [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)), которые определяют процесс конвертации PowerPoint в HTML:

* Конвертировать всю презентацию PowerPoint в HTML.
* Конвертировать конкретный слайд в презентации PowerPoint в HTML.
* Конвертировать мультимедия презентации (изображения, видео и т.д.) в HTML.
* Конвертировать презентацию PowerPoint в адаптивный HTML.
* Конвертировать презентацию PowerPoint в HTML с включенными либо исключенными примечаниями спикера.
* Конвертировать презентацию PowerPoint в HTML с включенными либо исключенными комментариями.
* Конвертировать презентацию PowerPoint в HTML с оригинальными или встроенными шрифтами.
* Конвертировать презентацию PowerPoint в HTML, используя новый стиль CSS.

{{% alert color="primary" %}} 

С помощью своего API компания Aspose разработала бесплатные [конвертеры презентаций в HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT в HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX в HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP в HTML](https://products.aspose.app/slides/conversion/odp-to-html) и т.д.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Рекомендуем ознакомиться с другими [бесплатными конвертерами от Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Примечание" color="warning" %}} 

Кроме процессов конвертации, описанных здесь, Aspose.Slides также поддерживает эти операции конвертации, связанные с форматом HTML: 

* [HTML в изображение](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}


## **Конвертация PowerPoint в HTML**
С помощью Aspose.Slides вы можете конвертировать всю презентацию PowerPoint в HTML следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
1. Используйте метод [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) для сохранения объекта в виде HTML-файла.

Этот код показывает, как конвертировать PowerPoint в HTML на Python:

```python
import aspose.slides as slides

# Создание объекта Presentation, представляющего файл презентации
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Сохранение презентации в HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **Конвертация PowerPoint в адаптивный HTML**

Aspose.Slides предоставляет класс [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/), который позволяет генерировать адаптивные HTML-файлы. Этот код показывает, как конвертировать презентацию PowerPoint в адаптивный HTML на Python:

```py
# Создание объекта Presentation, представляющего файл презентации
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Сохранение презентации в HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **Конвертация PowerPoint в HTML с примечаниями**
Этот код показывает, как конвертировать PowerPoint в HTML с примечаниями на Python:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **Конвертация PowerPoint в HTML с оригинальными шрифтами**
Aspose.Slides предоставляет класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/), который позволяет встроить все шрифты в презентации при конвертации в HTML.

Чтобы предотвратить встраивание определенных шрифтов, вы можете передать массив имен шрифтов в параметризованный конструктор класса [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Популярные шрифты, такие как Calibri или Arial, когда используются в презентации, не обязательно встраивать, поскольку многие системы уже содержат такие шрифты. Когда эти шрифты встраиваются, результирующий HTML-документ становится ненужным образом большим.

Класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) поддерживает наследование и предоставляет метод `WriteFont`, который должен быть переопределен. 

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# исключить стандартные шрифты презентации
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **Конвертация слайда в HTML**
Конвертируйте отдельный слайд презентации в HTML. Для этого используйте тот же метод [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), предоставленный классом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), который используется для конвертации всей презентации PPT(X) в HTML-документ. Класс [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) также может быть использован для установки дополнительных параметров конвертации:

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```


## **Сохранение CSS и изображений при экспорте в HTML**
Используя новые файлы стилей CSS, вы можете легко изменить стиль HTML-файла, полученного в результате процесса конвертации PowerPoint в HTML. 

Код на Python в этом примере показывает, как использовать переопределяемые методы для создания пользовательского HTML-документа со ссылкой на файл CSS:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Связывание всех шрифтов при конвертации презентации в HTML**
Если вы не хотите встраивать шрифты (чтобы избежать увеличения размера результирующего HTML), вы можете связать все шрифты, реализовав свою версию `LinkAllFontsHtmlController`.

Этот код на Python показывает, как конвертировать PowerPoint в HTML, связывая все шрифты и исключая "Calibri" и "Arial" (поскольку они уже существуют в системе): 

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Поддержка адаптивного свойства SVG**
Пример кода ниже показывает, как экспортировать презентацию PPT(X) в HTML с адаптивной компоновкой:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```


## **Экспорт медиафайлов в HTML-файл**
Используя Aspose.Slides для Python, вы можете экспортировать медиафайлы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд.
1. Добавьте видео на слайд.
1. Запишите презентацию как HTML-файл.

Этот код на Python показывает, как добавить видео в презентацию и затем сохранить его как HTML:

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