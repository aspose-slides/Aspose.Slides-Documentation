---
title: Экспорт в HTML5
type: docs
weight: 40
url: /net/export-to-html5/
keywords: "PowerPoint в HTML, HTML 5, экспорт HTML, экспорт презентации, конвертация PowerPoint в HTML, C#, Csharp, Aspose.Slides для .NET"
description: "Экспорт PowerPoint в HTML5 на C# или .NET"
---

{{% alert title="Информация" color="info" %}}

В [Aspose.Slides 21.9](/slides/net/aspose-slides-for-net-21-9-release-notes/) мы реализовали поддержку экспорта в HTML5. Однако, если вы предпочитаете экспортировать ваш PowerPoint в HTML с использованием WebExtensions, смотрите [этот раздел](/slides/net/web-extensions/) вместо этого.

{{% /alert %}}

Процесс экспорта в HTML5 здесь позволяет вам конвертировать PowerPoint в HTML без веб-расширений или зависимостей. Таким образом, используя свои собственные шаблоны, вы можете применять очень гибкие параметры, которые определяют процесс экспорта и результирующие атрибуты HTML, CSS, JavaScript и анимации.

## **Экспорт PowerPoint в HTML5**

Этот код на C# показывает, как экспортировать презентацию в HTML5 без веб-расширений и зависимостей:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}}

В этом случае вы получаете чистый HTML.

{{% /alert %}}

Вы можете указать настройки для анимации объектов и переходов слайдов таким образом:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

#### **Экспорт PowerPoint в HTML**

Этот код на C# демонстрирует стандартный процесс PowerPoint в HTML:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

В этом случае содержимое презентации отображается через SVG в следующей форме:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> СОДЕРЖИМОЕ СЛАЙДА РАСПОЛАГАЕТСЯ ЗДЕСЬ </g>
     </svg>
</div>
</body>
```

{{% alert title="Примечание" color="warning" %}}

Когда вы используете этот метод для экспорта PowerPoint в HTML, из-за отображения SVG вы не сможете применить стили или анимировать конкретные элементы.

{{% /alert %}}

## **Экспорт PowerPoint в HTML5 в режиме слайд-шоу**

**Aspose.Slides** позволяет вам конвертировать презентацию PowerPoint в документ HTML5, в котором слайды представлены в режиме слайд-шоу. В этом случае, когда вы открываете результирующий HTML5 файл в браузере, вы видите презентацию в режиме слайд-шоу на веб-странице.

Этот код на C# демонстрирует процесс экспорта PowerPoint в HTML5 в режиме слайд-шоу:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```