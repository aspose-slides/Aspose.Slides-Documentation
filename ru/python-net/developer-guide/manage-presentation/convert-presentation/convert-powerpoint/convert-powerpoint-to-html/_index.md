---
title: Преобразование презентаций PowerPoint в HTML на Python
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
- презентацию в HTML
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
description: "Преобразуйте презентации PowerPoint в адаптивный HTML на Python. Сохраните макет, ссылки и изображения с руководством по конвертации Aspose.Slides для быстрых и безошибочных результатов."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формат HTML с помощью Python. Рассматриваются следующие темы.

- Конвертировать PowerPoint в HTML на Python
- Конвертировать PPT в HTML на Python
- Конвертировать PPTX в HTML на Python
- Конвертировать ODP в HTML на Python
- Конвертировать слайд PowerPoint в HTML на Python

## **Python PowerPoint в HTML**

Для примера кода Python по конвертации PowerPoint в HTML см. раздел ниже, а именно [Convert PowerPoint to HTML](#convert-powerpoint-to-html). Код может загружать несколько форматов, таких как PPT, PPTX и ODP, в объект Presentation и сохранять его в формате HTML.

## **О конвертации PowerPoint в HTML**

С помощью [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/), приложения и разработчики могут преобразовать презентацию PowerPoint в HTML: **PPTX в HTML** или **PPT в HTML**.  

**Aspose.Slides** предоставляет множество вариантов (в основном из класса [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)), которые определяют процесс конвертации PowerPoint в HTML:

* Преобразовать всю презентацию PowerPoint в HTML.
* Преобразовать отдельный слайд презентации PowerPoint в HTML.
* Преобразовать медиа презентации (изображения, видео и т.д.) в HTML.
* Преобразовать презентацию PowerPoint в адаптивный HTML.
* Преобразовать презентацию PowerPoint в HTML с включенными или исключенными примечаниями докладчика.
* Преобразовать презентацию PowerPoint в HTML с включенными или исключенными комментариями.
* Преобразовать презентацию PowerPoint в HTML с оригинальными или встроенными шрифтами.
* Преобразовать презентацию PowerPoint в HTML, используя новый CSS‑стиль.

{{% alert color="primary" %}} 

Используя собственный API, Aspose разработала бесплатные конвертеры [презентация в HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) такие как [PPT в HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX в HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP в HTML](https://products.aspose.app/slides/conversion/odp-to-html), и т.д.  

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Возможно, вам также будет интересен список других [бесплатных конвертеров от Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Помимо описанных здесь процессов конвертации, Aspose.Slides также поддерживает следующие операции преобразования, связанные с форматом HTML:

* [HTML в изображение](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **Преобразовать PowerPoint в HTML**

Используя Aspose.Slides, вы можете преобразовать всю презентацию PowerPoint в HTML следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. Используйте метод [Save ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)для сохранения объекта в файл HTML.

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Saving the presentation to HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **Преобразовать PowerPoint в адаптивный HTML**

Aspose.Slides предоставляет класс [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/), позволяющий генерировать адаптивные HTML‑файлы. Этот код демонстрирует, как преобразовать презентацию PowerPoint в адаптивный HTML на Python:

```py
# Instantiate a Presentation object that represents a presentation file
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Saving the presentation to HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **Преобразовать PowerPoint в HTML с примечаниями**

Этот код демонстрирует, как преобразовать PowerPoint в HTML с примечаниями на Python:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **Преобразовать PowerPoint в HTML с оригинальными шрифтами**

Aspose.Slides предоставляет класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/), позволяющий внедрять все шрифты презентации при её преобразовании в HTML.

Чтобы избежать встраивания определённых шрифтов, вы можете передать массив имён шрифтов в параметризованный конструктор класса [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Популярные шрифты, такие как Calibri или Arial, не требуется встраивать, поскольку большинство систем уже содержат их. При встраивании этих шрифтов получающийся HTML‑документ становится неоправданно большим.

Класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) поддерживает наследование и предоставляет метод `WriteFont`, который предназначен для переопределения. 

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# exclude default presentation fonts
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **Преобразовать слайд в HTML**

Преобразуйте отдельный слайд презентации в HTML. Для этого используйте тот же метод [**Save**], предоставляемый классом [Presentation], который используется для преобразования всей презентации PPT(X) в HTML‑документ. Класс [**HtmlOptions**] также может быть использован для задания дополнительных параметров конвертации:

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```

## **Сохранить CSS и изображения при экспорте в HTML**

С помощью новых файлов CSS вы можете легко изменить стиль HTML‑файла, полученного в результате конвертации PowerPoint в HTML.

Python‑код в этом примере демонстрирует, как использовать переопределяемые методы для создания пользовательского HTML‑документа со ссылкой на файл CSS:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Связать все шрифты при конвертации презентации в HTML**

Если вы не хотите встраивать шрифты (чтобы избежать увеличения размера получаемого HTML), вы можете связать все шрифты, реализовав собственную версию `LinkAllFontsHtmlController`.

Этот Python‑код демонстрирует, как преобразовать PowerPoint в HTML, связывая все шрифты и исключая «Calibri» и «Arial» (поскольку они уже присутствуют в системе):

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Поддержка свойства responsive для SVG**

Ниже приведён пример кода, показывающий, как экспортировать презентацию PPT(X) в HTML с адаптивным макетом:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **Экспорт медиафайлов в HTML‑файл**

С помощью Aspose.Slides для Python вы можете экспортировать медиафайлы следующим образом:

1. Создайте экземпляр класса [Presentation].
1. Получите ссылку на слайд.
1. Добавьте видео на слайд.
1. Сохраните презентацию в виде HTML‑файла.

Этот Python‑код демонстрирует, как добавить видео в презентацию и затем сохранить её в HTML:

```py
import aspose.slides as slides

# Loading a presentation
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

### **Как я могу конвертировать презентацию PowerPoint в HTML, используя Python?**

Вы можете использовать библиотеку Aspose.Slides for Python via .NET для загрузки файлов PPT, PPTX или ODP и конвертации их в HTML с помощью метода `save()` с параметром `SaveFormat.HTML`.

### **Поддерживает ли Aspose.Slides конвертацию отдельных слайдов PowerPoint в HTML?**

Да, Aspose.Slides позволяет конвертировать как всю презентацию, так и отдельные слайды в HTML, соответствующим образом настраивая `HtmlOptions`.

### **Могу ли я генерировать адаптивный HTML из презентаций PowerPoint?**

Да, с помощью класса `ResponsiveHtmlController` можно экспортировать презентацию в адаптивный HTML‑макет, который подстраивается под различные размеры экранов.

### **Можно ли включить примечания докладчика или комментарии в экспортированный HTML?**

Да, вы можете настроить `HtmlOptions` для включения или исключения примечаний докладчика и комментариев при экспорте презентаций PowerPoint в HTML.

### **Могу ли я встраивать шрифты при конвертации презентации в HTML?**

Да, Aspose.Slides предоставляет класс `EmbedAllFontsHtmlController`, который позволяет встраивать шрифты или исключать некоторые шрифты для уменьшения размера выходного файла.

### **Поддерживает ли конвертация PowerPoint в HTML медиафайлы, такие как видео и аудио?**

Да, Aspose.Slides позволяет экспортировать медиа‑контент, встроенный в слайды, в HTML с помощью `VideoPlayerHtmlController` и сопутствующих классов конфигурации.

### **Какие форматы файлов поддерживаются для конвертации в HTML?**

Aspose.Slides поддерживает конвертацию презентаций форматов PPT, PPTX и ODP в HTML. Кроме того, можно сохранять содержание слайдов в формате SVG и экспортировать медиа‑ресурсы.

### **Могу ли я избежать встраивания шрифтов, чтобы уменьшить размер HTML?**

Да, вы можете вместо встраивания соединять часто доступные системные шрифты, такие как Arial или Calibri, используя собственную реализацию `HtmlController`.

### **Есть ли онлайн‑инструмент для конвертации PowerPoint в HTML?**

Да, вы можете воспользоваться бесплатными веб‑инструментами Aspose, например [PPT в HTML](https://products.aspose.app/slides/conversion/ppt-to-html) или [PPTX в HTML](https://products.aspose.app/slides/conversion/pptx-to-html), чтобы конвертировать презентации прямо в браузере без написания кода.

### **Могу ли я использовать пользовательские стили CSS в экспортированном HTML‑файле?**

Да, Aspose.Slides позволяет привязывать внешние CSS‑файлы во время конвертации, что позволяет полностью настроить внешний вид полученного HTML‑контента.