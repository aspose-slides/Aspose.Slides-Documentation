---
title: Преобразование презентаций в HTML5 на .NET
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
description: "Экспортировать презентации PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides для .NET. Сохраняет форматирование, анимацию и интерактивность."
---

{{% alert title="Info" color="info" %}}

В [Aspose.Slides 21.9](/slides/ru/net/aspose-slides-for-net-21-9-release-notes/) мы реализовали поддержку экспорта в HTML5. Однако, если вы предпочитаете экспортировать PowerPoint в HTML с помощью WebExtensions, см. [this article](/slides/ru/net/web-extensions/) вместо этого. 

{{% /alert %}} 

Процесс экспорта в HTML5 позволяет конвертировать PowerPoint в HTML без веб‑расширений и зависимостей. Таким образом, используя собственные шаблоны, вы можете задавать гибкие параметры, определяющие процесс экспорта и полученный HTML, CSS, JavaScript и свойства анимации. 

## **Экспорт PowerPoint в HTML5**

Этот код C# показывает, как экспортировать презентацию в HTML5 без веб‑расширений и зависимостей:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```


{{% alert color="primary" %}} 

В этом случае вы получаете чистый HTML. 

{{% /alert %}}

Вы можете указать настройки анимации фигур и переходов между слайдами следующим образом:
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

Этот пример C# демонстрирует стандартный процесс экспорта PowerPoint в HTML:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```


В этом случае содержимое презентации рендерится через SVG в виде:
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

При использовании этого метода экспорта PowerPoint в HTML из‑за рендеринга SVG вы не сможете применять стили или анимировать отдельные элементы. 

{{% /alert %}}

## **Экспорт PowerPoint в режим просмотра слайдов HTML5**

**Aspose.Slides** позволяет конвертировать презентацию PowerPoint в документ HTML5, в котором слайды отображаются в режиме просмотра слайдов. В этом случае, открывая полученный файл HTML5 в браузере, вы видите презентацию в режиме просмотра слайдов на веб‑странице. 

Этот код C# демонстрирует процесс экспорта PowerPoint в режим просмотра слайдов HTML5:
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

Комментарии в PowerPoint — это инструмент, позволяющий пользователям оставлять заметки или отзывы о слайдах презентации. Они особенно полезны в совместных проектах, где несколько человек могут добавлять свои предложения или замечания к отдельным элементам слайда без изменения основного содержания. Каждый комментарий отображает имя автора, что упрощает отслеживание того, кто оставил замечание.

Предположим, у нас есть следующая презентация PowerPoint, сохранённая в файле «sample.pptx».

![Two comments on the presentation slide](two_comments_pptx.png)

При конвертации презентации PowerPoint в документ HTML5 вы можете указать, включать ли комментарии из презентации в результирующий документ. Для этого необходимо задать параметры отображения комментариев в свойстве `NotesCommentsLayouting` класса [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). 

Ниже приведён пример кода, который конвертирует презентацию в документ HTML5 с комментариями, отображаемыми справа от слайдов.
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

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Можно ли управлять тем, будут ли анимации объектов и переходы между слайдами воспроизводиться в HTML5?**

Да, в HTML5 есть отдельные параметры для включения или отключения [анимации фигур](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) и [переходов между слайдами](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**Поддерживается ли вывод комментариев и где их можно разместить относительно слайда?**

Да, комментарии могут быть добавлены в HTML5 и размещены (например, справа от слайда) с помощью [настроек разметки](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/) для заметок и комментариев.

**Можно ли пропустить ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**

Да, существует [настройка](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/), позволяющая пропускать гиперссылки с вызовами JavaScript при сохранении. Это помогает соблюдать строгие политики безопасности.