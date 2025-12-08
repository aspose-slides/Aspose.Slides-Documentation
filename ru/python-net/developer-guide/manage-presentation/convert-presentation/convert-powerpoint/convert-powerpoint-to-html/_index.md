---
title: Конвертировать презентации PowerPoint в HTML на Python
linktitle: PowerPoint в HTML
type: docs
weight: 30
url: /ru/python-net/convert-powerpoint-to-html/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в HTML
- презентация в HTML
- слайд в HTML
- PPT в HTML
- PPTX в HTML
- сохранить PowerPoint как HTML
- сохранить презентацию как HTML
- сохранить слайд как HTML
- сохранить PPT как HTML
- сохранить PPTX как HTML
- Python
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в адаптивный HTML на Python. Сохраните макет, ссылки и изображения с помощью руководства по конвертации Aspose.Slides для быстрых и безошибочных результатов."
---

## **Обзор**

Эта статья объясняет, как преобразовать презентацию PowerPoint в формат HTML с использованием Python. Она охватывает следующие темы.

- Преобразовать PowerPoint в HTML с помощью Python
- Преобразовать PPT в HTML с помощью Python
- Преобразовать PPTX в HTML с помощью Python
- Преобразовать ODP в HTML с помощью Python
- Преобразовать слайд PowerPoint в HTML с помощью Python

## **Python PowerPoint to HTML**

Для примера кода Python по преобразованию PowerPoint в HTML смотрите раздел ниже, то есть [Convert PowerPoint to HTML](#convert-powerpoint-to-html). Код может загружать различные форматы, такие как PPT, PPTX и ODP, в объект Presentation и сохранять его в формате HTML.

## **О преобразовании PowerPoint в HTML**

С помощью [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/), приложения и разработчики могут конвертировать презентацию PowerPoint в HTML: **PPTX to HTML** или **PPT to HTML**. 

**Aspose.Slides** предоставляет многие варианты (в основном из класса [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)), которые определяют процесс преобразования PowerPoint в HTML:

* Преобразовать всю презентацию PowerPoint в HTML.
* Преобразовать конкретный слайд презентации PowerPoint в HTML.
* Преобразовать медиа презентации (изображения, видео и т.д.) в HTML.
* Преобразовать презентацию PowerPoint в адаптивный HTML. 
* Преобразовать презентацию PowerPoint в HTML с включенными или исключенными заметками выступающего. 
* Преобразовать презентацию PowerPoint в HTML с включенными или исключенными комментариями. 
* Преобразовать презентацию PowerPoint в HTML с оригинальными или встроенными шрифтами. 
* Преобразовать презентацию PowerPoint в HTML, используя новый стиль CSS. 

{{% alert color="primary" %}} 

С помощью собственного API Aspose разработала бесплатные конвертеры [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html) и т.д. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Вы можете проверить другие [бесплатные конвертеры от Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Помимо описанных здесь процессов конвертации, Aspose.Slides также поддерживает следующие операции преобразования, связанные с форматом HTML: 

* [HTML to image](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **Convert PowerPoint to HTML**
С помощью Aspose.Slides вы можете преобразовать всю презентацию PowerPoint в HTML следующим способом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
1. Вызовите метод [Save ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)для сохранения объекта в файл HTML.

Этот код показывает, как преобразовать PowerPoint в HTML на Python:
```python
import aspose.slides as slides

# Создайте объект Presentation, который представляет файл презентации
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Сохранение презентации в HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```


## **Convert PowerPoint to Responsive HTML**
Aspose.Slides предоставляет класс [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/), который позволяет генерировать адаптивные HTML‑файлы. Этот код показывает, как экспортировать презентацию PowerPoint в адаптивный HTML на Python:
```py
# Создайте объект Presentation, который представляет файл презентации
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Сохранение презентации в HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```


## **Convert PowerPoint to HTML with Notes**
Этот код показывает, как преобразовать PowerPoint в HTML с заметками на Python:
```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```


## **Convert PowerPoint to HTML with Original Fonts**
Aspose.Slides предоставляет класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/), который позволяет внедрять все шрифты презентации при конвертации её в HTML.

Чтобы предотвратить внедрение определённых шрифтов, можно передать массив имён шрифтов в параметризованный конструктор класса [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Популярные шрифты, такие как Calibri или Arial, при использовании в презентации не требуется внедрять, поскольку большинство систем уже содержат их. Когда такие шрифты внедряются, полученный HTML‑документ становится избыточно большим.

Класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) поддерживает наследование и предоставляет метод `WriteFont`, который предполагается переопределить. 
```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# исключить шрифты по умолчанию презентации
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```


## **Convert Slide to HTML**
Преобразовать отдельный слайд презентации в HTML. Для этого используйте тот же метод [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), предоставляемый классом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), который используется для конвертации всей презентации PPT(X) в HTML‑документ. Класс [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) также можно использовать для задания дополнительных параметров конвертации:
```py
# [TODO[not_supported_yet]: реализация интерфейса .net на python]
```


## **Save CSS and Images When Exporting To HTML**
Используя новые CSS‑файлы стилей, вы можете легко изменить стиль HTML‑файла, полученного в результате конвертации PowerPoint в HTML. 

Python‑код в этом примере показывает, как использовать переопределяемые методы для создания пользовательского HTML‑документа со ссылкой на CSS‑файл:
```py
# [TODO[not_supported_yet]: реализация .net интерфейсов на python]
```


## **Link All Fonts When Converting Presentation to HTML**
Если вы не хотите внедрять шрифты (чтобы не увеличивать размер получаемого HTML), можно связать все шрифты, реализовав собственную версию `LinkAllFontsHtmlController`. 

Этот Python‑код показывает, как преобразовать PowerPoint в HTML, связывая все шрифты и исключая «Calibri» и «Arial» (поскольку они уже присутствуют в системе):
```py
# [TODO[not_supported_yet]: реализация .net интерфейсов на python]
```


## **Support of SVG Responsive Property**
Пример кода ниже демонстрирует, как экспортировать презентацию PPT(X) в HTML с адаптивным макетом:
```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```


## **Export Media Files to HTML file**
С помощью Aspose.Slides for python вы можете экспортировать медиа‑файлы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд.
1. Добавьте видео на слайд.
1. Сохраните презентацию в файл HTML.

Этот Python‑код показывает, как добавить видео в презентацию и затем сохранить её как HTML:
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

### **How can I convert a PowerPoint presentation to HTML using Python?**
Вы можете использовать библиотеку Aspose.Slides for Python via .NET для загрузки файлов PPT, PPTX или ODP и их преобразования в HTML с помощью метода `save()` с параметром `SaveFormat.HTML`.

### **Does Aspose.Slides support converting individual PowerPoint slides to HTML?**
Да, Aspose.Slides позволяет конвертировать как всю презентацию, так и отдельные слайды в HTML, используя соответствующую настройку `HtmlOptions`.

### **Can I generate responsive HTML from PowerPoint presentations?**
Да, с помощью класса `ResponsiveHtmlController` вы можете экспортировать презентацию в адаптивный HTML‑макет, который подстраивается под различные размеры экранов.

### **Is it possible to include speaker notes or comments in the exported HTML?**
Да, вы можете настроить `HtmlOptions` для включения или исключения заметок выступающего и комментариев при экспорте презентаций PowerPoint в HTML.

### **Can I embed fonts when converting a presentation to HTML?**
Да, Aspose.Slides предоставляет класс `EmbedAllFontsHtmlController`, который позволяет внедрять шрифты или исключать определённые шрифты, чтобы уменьшить размер выходного файла.

### **Does the PowerPoint to HTML conversion support media files like videos and audio?**
Да, Aspose.Slides позволяет экспортировать медиа‑контент, встроенный в слайды, в HTML, используя `VideoPlayerHtmlController` и связанные классы конфигурации.

### **What file formats are supported for conversion to HTML?**
Aspose.Slides поддерживает конвертацию форматов PPT, PPTX и ODP в HTML. Также возможно сохранять содержимое слайдов в виде SVG и экспортировать медиа‑ресурсы.

### **Can I avoid embedding fonts to reduce HTML output size?**
Да, вы можете связывать часто используемые системные шрифты, такие как Arial или Calibri, вместо их внедрения, реализовав собственную версию `HtmlController`.

### **Is there an online tool to convert PowerPoint to HTML?**
Да, вы можете воспользоваться бесплатными веб‑инструментами Aspose, например [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html) или [PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html), чтобы конвертировать презентации напрямую в браузере без написания кода.

### **Can I use custom CSS styles in the exported HTML file?**
Да, Aspose.Slides позволяет подключать внешние CSS‑файлы во время конвертации, что даёт полную возможность кастомизировать внешний вид полученного HTML‑контента.