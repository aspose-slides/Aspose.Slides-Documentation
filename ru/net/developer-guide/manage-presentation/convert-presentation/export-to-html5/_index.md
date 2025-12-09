---
title: Конвертировать презентации в HTML5 на .NET
linktitle: Презентация в HTML5
type: docs
weight: 40
url: /ru/net/export-to-html5/
keywords:
- PowerPoint в HTML5
- OpenDocument в HTML5
- презентация в HTML5
- слайд в HTML5
- PPT в HTML5
- PPTX в HTML5
- ODP в HTML5
- сохранить PPT как HTML5
- сохранить PPTX как HTML5
- сохранить ODP как HTML5
- экспортировать PPT в HTML5
- экспортировать PPTX в HTML5
- экспортировать ODP в HTML5
- .NET
- C#
- Aspose.Slides
description: "Экспортировать презентации PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides для .NET. Сохранять форматирование, анимацию и интерактивность."
---

{{% alert title="Информация" color="info" %}}

В [Aspose.Slides 21.9](/slides/ru/net/aspose-slides-for-net-21-9-release-notes/) мы реализовали поддержку экспорта в HTML5. Однако, если вы предпочитаете экспортировать PowerPoint в HTML с использованием WebExtensions, см. [эту статью](/slides/ru/net/web-extensions/) вместо этого. 

{{% /alert %}} 

Процесс экспорта в HTML5 позволяет преобразовать PowerPoint в HTML без веб‑расширений и зависимостей. Таким образом, используя собственные шаблоны, вы можете применять гибкие параметры, определяющие процесс экспорта и результирующий HTML, CSS, JavaScript и атрибуты анимации. 

## **Экспорт PowerPoint в HTML5**

Этот C#‑код демонстрирует, как экспортировать презентацию в HTML5 без веб‑расширений и зависимостей:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```


{{% alert color="primary" %}} 

В этом случае вы получаете чистый HTML. 

{{% /alert %}}

Вы можете указать параметры анимации фигур и переходов между слайдами следующим образом:
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


## **Экспорт PowerPoint в HTML**

Этот C#‑пример демонстрирует стандартный процесс экспорта PowerPoint в HTML:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```


В этом случае содержимое презентации отображается через SVG в виде:
```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```


{{% alert title="Примечание" color="warning" %}} 

При использовании этого метода экспорта PowerPoint в HTML из‑за рендеринга SVG вы не сможете применять стили или анимировать отдельные элементы. 

{{% /alert %}}

## **Экспорт PowerPoint в режим просмотра слайдов HTML5**

**Aspose.Slides** позволяет преобразовать презентацию PowerPoint в документ HTML5, в котором слайды отображаются в режиме просмотра слайдов. В этом случае, открывая полученный файл HTML5 в браузере, вы видите презентацию в режиме просмотра слайдов на веб‑странице. 

Этот C#‑код демонстрирует процесс экспорта PowerPoint в режим просмотра слайдов HTML5:
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


## **Преобразование презентации в документ HTML5 с комментариями**

Комментарии в PowerPoint — это инструмент, позволяющий пользователям оставлять заметки или отзывы о слайдах презентации. Они особенно полезны в совместных проектах, где несколько человек могут добавлять свои предложения или замечания к конкретным элементам слайда, не изменяя основной контент. Каждый комментарий отображает имя автора, что упрощает отслеживание того, кто оставил замечание.

Предположим, у нас есть презентация PowerPoint, сохранённая в файле «sample.pptx».

![Два комментария на слайде презентации](two_comments_pptx.png)

При преобразовании презентации PowerPoint в документ HTML5 вы можете указать, включать ли комментарии из презентации в результирующий документ. Для этого необходимо задать параметры отображения комментариев в свойстве `NotesCommentsLayouting` класса [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). 

Следующий пример кода преобразует презентацию в документ HTML5 с комментариями, отображаемыми справа от слайдов.
```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```


Документ «output.html» показан на изображении ниже.

![Комментарии в результирующем документе HTML5](two_comments_html5.png)

## **FAQ**

**Можно ли управлять тем, будут ли воспроизводиться анимации объектов и переходы между слайдами в HTML5?**

Да, в HTML5 есть отдельные параметры для включения или отключения [shape animations](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) и [slide transitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**Поддерживается ли вывод комментариев и где их можно разместить относительно слайда?**

Да, комментарии можно добавить в HTML5 и разместить (например, справа от слайда) с помощью [layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/) для заметок и комментариев.

**Можно ли пропустить ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**

Да, существует [setting](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/), позволяющий пропускать гиперссылки с вызовами JavaScript при сохранении. Это помогает соответствовать строгим политикам безопасности.