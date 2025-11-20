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
description: "Конвертировать презентации PowerPoint в адаптивный HTML на Python. Сохранить макет, ссылки и изображения с помощью руководства по конвертации Aspose.Slides для быстрых, безошибочных результатов."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формат HTML с использованием Python. Она охватывает следующие темы.

- Преобразовать PowerPoint в HTML на Python
- Преобразовать PPT в HTML на Python
- Преобразовать PPTX в HTML на Python
- Преобразовать ODP в HTML на Python
- Преобразовать слайд PowerPoint в HTML на Python

## **PowerPoint в HTML на Python**

Для примера кода на Python, преобразующего PowerPoint в HTML, смотрите раздел ниже, т.е. [Преобразовать PowerPoint в HTML](#convert-powerpoint-to-html). Код может загружать несколько форматов, таких как PPT, PPTX и ODP, в объект Presentation и сохранять его в формате HTML.

## **О преобразовании PowerPoint в HTML**

С помощью [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/), приложения и разработчики могут преобразовать презентацию PowerPoint в HTML: **PPTX в HTML** или **PPT в HTML**.

**Aspose.Slides** предоставляет множество параметров (в основном из класса [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)), определяющих процесс преобразования PowerPoint в HTML:

* Преобразовать всю презентацию PowerPoint в HTML.
* Преобразовать отдельный слайд презентации PowerPoint в HTML.
* Преобразовать медиа презентации (изображения, видео и т.д.) в HTML.
* Преобразовать презентацию PowerPoint в адаптивный HTML.
* Преобразовать презентацию PowerPoint в HTML с включёнными или исключёнными нотатками докладчика.
* Преобразовать презентацию PowerPoint в HTML с включёнными или исключёнными комментариями.
* Преобразовать презентацию PowerPoint в HTML с оригинальными или вшитыми шрифтами.
* Преобразовать презентацию PowerPoint в HTML с использованием нового CSS‑стиля.

{{% alert color="primary" %}} 

Используя собственный API, Aspose разработала бесплатные конвертеры [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT в HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX в HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP в HTML](https://products.aspose.app/slides/conversion/odp-to-html), и т.д.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Возможно, вам будет интересно посмотреть другие [бесплатные конвертеры от Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Помимо описанных здесь процессов конвертации, Aspose.Slides также поддерживает следующие операции конвертации, связанные с форматом HTML:

* [HTML в изображение](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}


## **Преобразовать PowerPoint в HTML**

С помощью Aspose.Slides вы можете преобразовать всю презентацию PowerPoint в HTML следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
1. Используйте метод [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) для сохранения объекта в файл HTML.

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


## **Преобразовать PowerPoint в адаптивный HTML**

Aspose.Slides предоставляет класс [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/), который позволяет генерировать адаптивные HTML‑файлы. Этот код показывает, как преобразовать презентацию PowerPoint в адаптивный HTML на Python:
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


## **Преобразовать PowerPoint в HTML с заметками**

Этот код показывает, как преобразовать PowerPoint в HTML с заметками на Python:
```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```


## **Преобразовать PowerPoint в HTML с оригинальными шрифтами**

Aspose.Slides предоставляет класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/), который позволяет встраивать все шрифты презентации при её конвертации в HTML.

Чтобы предотвратить встраивание определённых шрифтов, вы можете передать массив имён шрифтов в параметризованный конструктор класса [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Популярные шрифты, такие как Calibri или Arial, используемые в презентации, не требуют встраивания, поскольку большинство систем уже содержат их. Если такие шрифты встраиваются, результирующий HTML‑документ становится ненужно большим.

Класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) поддерживает наследование и предоставляет метод `WriteFont`, предназначенный для переопределения. 
```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# исключить шрифты по умолчанию презентации
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```


## **Преобразовать слайд в HTML**

Преобразовать отдельный слайд презентации в HTML. Для этого используйте тот же метод [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), который используется для конвертации всей презентации PPT(X) в HTML‑документ. Класс [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) также можно использовать для задания дополнительных параметров конвертации:
```py
# [TODO[not_supported_yet]: реализация .net интерфейса на python]
```



## **Сохранить CSS и изображения при экспорте в HTML**

Используя новые CSS‑файлы, вы можете легко изменить стиль HTML‑файла, полученного в результате конвертации PowerPoint в HTML. 

Python‑код в этом примере показывает, как использовать переопределяемые методы для создания пользовательского HTML‑документа со ссылкой на файл CSS:
```py
# [TODO[not_supported_yet]: реализация .net интерфейсов на python]
```


## **Связать все шрифты при конвертации презентации в HTML**

Если вы не хотите встраивать шрифты (чтобы избежать увеличения размера итогового HTML), вы можете связать все шрифты, реализовав свою версию `LinkAllFontsHtmlController`.

Этот python‑код показывает, как преобразовать PowerPoint в HTML, связывая все шрифты и исключая "Calibri" и "Arial" (поскольку они уже присутствуют в системе):
```py
# [TODO[not_supported_yet]: реализация .net интерфейсов на python]
```


## **Поддержка адаптивного свойства SVG**

Пример кода ниже показывает, как экспортировать презентацию PPT(X) в HTML с адаптивным макетом:
```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```


## **Экспортировать медиафайлы в HTML‑файл**

С помощью Aspose.Slides для python вы можете экспортировать медиафайлы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд.
1. Добавьте видео на слайд.
1. Сохраните презентацию как HTML‑файл.

Этот python‑код показывает, как добавить видео в презентацию и затем сохранить её как HTML:
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


## **FAQ**

**Как я могу преобразовать презентацию PowerPoint в HTML с помощью Python?**

Вы можете использовать библиотеку Aspose.Slides for Python via .NET для загрузки файлов PPT, PPTX или ODP и конвертации их в HTML с помощью метода `save()` с параметром `SaveFormat.HTML`.

**Поддерживает ли Aspose.Slides конвертацию отдельных слайдов PowerPoint в HTML?**

Да, Aspose.Slides позволяет конвертировать как всю презентацию, так и отдельные слайды в HTML, соответствующим образом настраивая `HtmlOptions`.

**Могу ли я создать адаптивный HTML из презентаций PowerPoint?**

Да, с помощью класса `ResponsiveHtmlController` вы можете экспортировать презентацию в адаптивный HTML‑макет, который подстраивается под разные размеры экранов.

**Можно ли включить нотатки докладчика или комментарии в экспортированный HTML?**

Да, вы можете настроить `HtmlOptions` для включения или исключения нотаток докладчика и комментариев при экспорте презентаций PowerPoint в HTML.

**Могу ли я встраивать шрифты при конвертации презентации в HTML?**

Да, Aspose.Slides предоставляет класс `EmbedAllFontsHtmlController`, который позволяет встраивать шрифты или исключать определённые шрифты для уменьшения размера выходного файла.

**Поддерживает ли конвертация PowerPoint в HTML медиафайлы, такие как видео и аудио?**

Да, Aspose.Slides позволяет экспортировать медиа‑контент, встроенный в слайды, в HTML с помощью `VideoPlayerHtmlController` и связанных классов конфигурации.

**Какие форматы файлов поддерживаются для конвертации в HTML?**

Aspose.Slides поддерживает конвертацию форматов презентаций PPT, PPTX и ODP в HTML. Кроме того, он позволяет сохранять содержимое слайдов в SVG и экспортировать медиа‑ресурсы.

**Могу ли я избежать встраивания шрифтов, чтобы уменьшить размер HTML‑вывода?**

Да, вы можете связать часто доступные системные шрифты, такие как Arial или Calibri, вместо их встраивания, используя пользовательскую реализацию `HtmlController`.

**Существует ли онлайн‑инструмент для конвертации PowerPoint в HTML?**

Да, вы можете воспользоваться бесплатными веб‑инструментами Aspose, такими как [PPT в HTML](https://products.aspose.app/slides/conversion/ppt-to-html) или [PPTX в HTML](https://products.aspose.app/slides/conversion/pptx-to-html), чтобы конвертировать презентации непосредственно в браузере без написания кода.

**Могу ли я использовать пользовательские стили CSS в экспортированном HTML‑файле?**

Да, Aspose.Slides позволяет привязывать внешние CSS‑файлы во время конвертации, что дает возможность полностью настроить внешний вид полученного HTML‑контента.