---
title: Преобразование презентаций в HTML5 на Python
linktitle: Экспорт в HTML5
type: docs
weight: 40
url: /ru/python-net/export-to-html5/
keywords:
- PowerPoint в HTML5
- OpenDocument в HTML5
- презентация в HTML5
- слайд в HTML5
- PPT в HTML5
- PPTX в HTML5
- ODP в HTML5
- конвертация PowerPoint
- конвертация OpenDocument
- конвертация презентации
- конвертация слайда
- экспорт HTML5
- экспорт презентации
- экспорт слайда
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Экспорт презентаций PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides для Python через .NET. Сохранение форматирования, анимаций и интерактивности."
---

{{% alert title="Info" color="info" %}}

В **Aspose.Slides 21.9** мы реализовали поддержку экспорта в HTML5. Однако, если вы предпочитаете экспортировать PowerPoint в HTML с использованием WebExtensions, см. [эту статью](/slides/ru/net/web-extensions/) вместо этого. 

{{% /alert %}} 

Процесс экспорта в HTML5, описанный здесь, позволяет преобразовать PowerPoint в HTML без веб‑расширений и зависимостей. При этом, используя собственные шаблоны, можно задавать очень гибкие параметры, определяющие процесс экспорта и полученные HTML, CSS, JavaScript и атрибуты анимации. 

## **Экспорт PowerPoint в HTML5**

Этот python‑код показывает, как экспортировать презентацию в HTML5 без веб‑расширений и зависимостей:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 

В этом случае вы получаете чистый HTML. 

{{% /alert %}}

Вы можете задать параметры анимации фигур и переходов между слайдами следующим образом:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **Экспорт PowerPoint в HTML**

Этот python‑код демонстрирует стандартный процесс экспорта PowerPoint в HTML:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

В этом случае содержимое презентации отображается через SVG в виде, подобном следующему:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 

При использовании этого метода экспорта PowerPoint в HTML, из‑за рендеринга SVG вы не сможете применять стили или анимировать отдельные элементы. 

{{% /alert %}}

## **Экспорт PowerPoint в режим просмотра слайдов HTML5**

**Aspose.Slides** позволяет преобразовать презентацию PowerPoint в документ HTML5, в котором слайды отображаются в режиме просмотра слайдов. В этом случае, открывая полученный HTML5‑файл в браузере, вы видите презентацию в режиме просмотра слайдов на веб‑странице. 

Этот Python‑код демонстрирует процесс экспорта PowerPoint в режим просмотра слайдов HTML5:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Экспорт презентации, содержащей переходы слайдов, анимации и анимацию фигур в HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Сохранить презентацию
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **Преобразование презентации в документ HTML5 с комментариями**

Комментарии в PowerPoint — это инструмент, позволяющий пользователям оставлять заметки или обратную связь к слайдам презентации. Они особенно полезны в совместных проектах, где несколько человек могут добавлять свои предложения или замечания к конкретным элементам слайда, не изменяя основной контент. Каждый комментарий показывает имя автора, что упрощает отслеживание, кто оставил замечание.

Допустим, у нас есть следующая презентация PowerPoint, сохранённая в файле «sample.pptx».

![Два комментария на слайде презентации](two_comments_pptx.png)

При преобразовании презентации PowerPoint в документ HTML5 вы можете легко указать, включать ли комментарии из презентации в результирующий документ. Для этого необходимо задать параметры отображения комментариев в свойстве `notes_comments_layouting` класса [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/).

Следующий пример кода преобразует презентацию в документ HTML5 с комментариями, отображаемыми справа от слайдов.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

Документ «output.html» показан на изображении ниже.

![Комментарии в выходном документе HTML5](two_comments_html5.png)

## **FAQ**

**Могу ли я управлять тем, будут ли анимации объектов и переходы слайдов воспроизводиться в HTML5?**

Да, в HTML5 есть отдельные параметры для включения или отключения [анимации фигур](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) и [переходов слайдов](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**Поддерживается ли вывод комментариев, и где их можно разместить относительно слайда?**

Да, комментарии могут быть добавлены в HTML5 и позиционированы (например, справа от слайда) через [настройки разметки](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/notes_comments_layouting/) для заметок и комментариев.

**Можно ли пропускать ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**

Да, существует [параметр](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/), позволяющий пропускать гиперссылки с вызовами JavaScript при сохранении. Это помогает соответствовать строгим политикам безопасности.