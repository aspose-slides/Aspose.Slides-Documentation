---
title: Экспорт в HTML5
type: docs
weight: 40
url: /python-net/export-to-html5/
keywords: "PowerPoint в HTML, HTML 5, экспорт HTML, экспорт презентации, конвертировать PowerPoint в HTML, Python, Aspose.Slides для Python"
description: "Экспорт PowerPoint в HTML5 на Python"
---

{{% alert title="Информация" color="info" %}}

В **Aspose.Slides 21.9** мы реализовали поддержку экспорта в HTML5. Однако, если вы предпочитаете экспортировать ваш PowerPoint в HTML с использованием WebExtensions, смотрите [статью](/slides/net/web-extensions/) вместо этого.

{{% /alert %}} 

Процесс экспорта в HTML5 позволяет вам конвертировать PowerPoint в HTML без веб-расширений или зависимостей. Таким образом, используя свои собственные шаблоны, вы можете применять очень гибкие параметры, которые определяют процесс экспорта и результирующие HTML, CSS, JavaScript и атрибуты анимации.

## **Экспорт PowerPoint в HTML5**

Этот код на Python показывает, как экспортировать презентацию в HTML5 без веб-расширений и зависимостей:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 

В этом случае вы получите чистый HTML.

{{% /alert %}}

Вы можете захотеть указать настройки для анимаций объектов и переходов слайдов следующим образом:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

#### **Экспорт PowerPoint в HTML**

Этот код на Python демонстрирует стандартный процесс преобразования PowerPoint в HTML:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

В этом случае содержимое презентации отображается через SVG в форме, как показано ниже:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> СОДЕРЖАНИЕ СЛАЙДА ЗДЕСЬ </g>
     </svg>
</div>
</body>
```

{{% alert title="Примечание" color="warning" %}} 

Когда вы используете этот метод для экспорта PowerPoint в HTML, из-за рендеринга SVG вы не сможете применить стили или анимировать определенные элементы.

{{% /alert %}}

## **Экспорт PowerPoint в HTML5 в режиме просмотра слайдов**

**Aspose.Slides** позволяет вам конвертировать презентацию PowerPoint в HTML5-документ, в котором слайды представлены в режиме просмотра слайдов. В этом случае, когда вы открываете результирующий HTML5-файл в браузере, вы видите презентацию в режиме просмотра слайдов на веб-странице.

Этот код на Python демонстрирует процесс экспорта PowerPoint в HTML5 в режиме просмотра слайдов:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Экспорт презентации, содержащей переходы слайдов, анимации и анимации объектов в HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Сохранение презентации
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```