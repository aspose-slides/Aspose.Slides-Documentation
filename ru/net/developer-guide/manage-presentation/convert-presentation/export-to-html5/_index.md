---
title: "Преобразование презентаций в HTML5 в .NET"
linktitle: "Презентация в HTML5"
type: docs
weight: 40
url: /ru/net/export-to-html5/
keywords:
- "PowerPoint в HTML5"
- "OpenDocument в HTML5"
- "презентация в HTML5"
- "слайд в HTML5"
- "PPT в HTML5"
- "PPTX в HTML5"
- "ODP в HTML5"
- "сохранить PPT как HTML5"
- "сохранить PPTX как HTML5"
- "сохранить ODP как HTML5"
- "экспортировать PPT в HTML5"
- "экспортировать PPTX в HTML5"
- "экспортировать ODP в HTML5"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Экспорт презентаций PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides для .NET. Сохранение форматирования, анимаций и интерактивности."
---
## **Обзор**

В этой статье объясняется, как преобразовать презентации PowerPoint в HTML5 с помощью Aspose.Slides. Описывается базовый экспорт в HTML5, а также параметры, позволяющие управлять анимацией фигур и переходами между слайдами. Статья также показывает стандартный процесс экспорта PowerPoint в HTML, объясняет, как генерировать вывод HTML5 в режиме просмотра слайдов, и демонстрирует, как включить комментарии в экспортируемый документ, настроив их расположение.

## **Экспорт PowerPoint в HTML5**

Этот код C# демонстрирует, как экспортировать презентацию в HTML5:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 
Помимо HTML‑документа, экспорт записывает поддерживающие файлы, на которые он ссылается: `pres.css`, `master.css`, `animation.js`, `effects.js` и `navigation.js`. Сгенерированная страница также загружает jQuery и Anime.js из публичных CDN; без них навигация по слайдам и анимации не работают. 
{{% /alert %}}

Вы можете указать параметры анимации фигур и переходов между слайдами следующим образом:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Этот код C# демонстрирует стандартный процесс экспорта PowerPoint в HTML:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

В этом случае содержимое презентации отображается с помощью SVG в виде, подобном следующему:

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
При использовании этого метода экспорта PowerPoint в HTML, из‑за рендеринга SVG, вы не сможете применять стили или анимировать отдельные элементы. 
{{% /alert %}}

## **Экспорт PowerPoint в HTML5 с просмотром слайдов**

**Aspose.Slides** позволяет преобразовать презентацию PowerPoint в документ HTML5, в котором слайды отображаются в режиме просмотра слайдов. В этом случае, открывая полученный файл HTML5 в браузере, вы видите презентацию в режиме просмотра слайдов на веб‑странице. 

Этот код C# демонстрирует процесс экспорта PowerPoint в HTML5 с режимом просмотра слайдов:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Комментарии в PowerPoint — это инструмент, позволяющий пользователям оставлять заметки или отзывы к слайдам презентации. Они особенно полезны в совместных проектах, где несколько человек могут добавлять свои предложения или замечания к конкретным элементам слайдов, не изменяя основной контент. Каждый комментарий отображает имя автора, что упрощает отслеживание, кто оставил замечание.

Допустим, у нас есть следующая презентация PowerPoint, сохранённая в файле «sample.pptx».

![Два комментария на слайде презентации](two_comments_pptx.png)

При преобразовании презентации PowerPoint в документ HTML5 вы можете легко указать, включать ли комментарии из презентации в выходной документ. Для этого необходимо задать параметры отображения комментариев в свойстве `NotesCommentsLayouting` класса [Html5Options](https://reference.aspose.com/slides/ru/net/aspose.slides.export/html5options/).

Следующий пример кода конвертирует презентацию в документ HTML5, при этом комментарии отображаются справа от слайдов.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Документ «output.html» показан на изображении ниже.

![Комментарии в выходном документе HTML5](two_comments_html5.png)

## **Часто задаваемые вопросы**

### Можно ли управлять тем, будут ли воспроизводиться анимации объектов и переходы между слайдами в HTML5?

Да, в HTML5 предусмотрены отдельные параметры для включения или отключения [анимации фигур](https://reference.aspose.com/slides/ru/net/aspose.slides.export/html5options/animateshapes/) и [переходов между слайдами](https://reference.aspose.com/slides/ru/net/aspose.slides.export/html5options/animatetransitions/).

### Поддерживается ли вывод комментариев и где их можно разместить относительно слайда?

Да, комментарии могут быть добавлены в HTML5 и расположены (например, справа от слайда) с помощью [настроек расположения](https://reference.aspose.com/slides/ru/net/aspose.slides.export/html5options/notescommentslayouting/) для заметок и комментариев.

### Можно ли пропускать ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?

Да, существует [параметр](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveoptions/skipjavascriptlinks/), позволяющий пропускать гиперссылки с вызовами JavaScript при сохранении. Это помогает соответствовать строгим политикам безопасности.