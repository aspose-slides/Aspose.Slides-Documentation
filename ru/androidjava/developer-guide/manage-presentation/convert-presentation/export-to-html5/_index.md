---
title: Преобразование презентаций в HTML5 на Android
linktitle: Презентация в HTML5
type: docs
weight: 40
url: /ru/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "Экспорт презентаций PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides для Android через Java. Сохраняет форматирование, анимацию и интерактивность."
---

{{% alert title="Info" color="info" %}}

В [Aspose.Slides 21.9](/slides/ru/androidjava/aspose-slides-for-java-21-9-release-notes/), мы реализовали поддержку экспорта в HTML5.

{{% /alert %}} 

Процесс экспорта в HTML5 позволяет конвертировать PowerPoint в HTML без веб‑расширений и зависимостей. Таким образом, используя собственные шаблоны, вы можете задать очень гибкие параметры, определяющие процесс экспорта и получаемый HTML, CSS, JavaScript и атрибуты анимации. 

## **Export PowerPoint to HTML5**

Этот Java‑код показывает, как экспортировать презентацию в HTML5 без веб‑расширений и зависимостей:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 

В этом случае вы получаете чистый HTML. 

{{% /alert %}}

Вы можете задать настройки анимации фигур и переходов между слайдами следующим образом:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Export PowerPoint to HTML**

Этот Java‑код демонстрирует стандартный процесс экспорта PowerPoint в HTML:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```


В этом случае содержимое презентации отображается через SVG в виде, как показано ниже:
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

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** позволяет конвертировать презентацию PowerPoint в документ HTML5, в котором слайды отображаются в режиме просмотра слайдов. В этом случае, открыв полученный HTML5‑файл в браузере, вы увидите презентацию в режиме просмотра слайдов на веб‑странице. 

Этот Java‑код демонстрирует процесс экспорта PowerPoint в режим просмотра слайдов HTML5:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Convert a Presentation to an HTML5 Document with Comments**

Комментарии в PowerPoint – это инструмент, позволяющий пользователям оставлять заметки или отзывы на слайдах презентации. Они особенно полезны в совместных проектах, где несколько человек могут добавить свои предложения или замечания к отдельным элементам слайда, не изменяя основной контент. Каждый комментарий отображает имя автора, что упрощает отслеживание, кто оставил замечание.

Допустим, у нас есть следующая презентация PowerPoint, сохранённая в файле "sample.pptx".

![Two comments on the presentation slide](two_comments_pptx.png)

При конвертации презентации PowerPoint в документ HTML5 вы можете легко указать, включать ли комментарии из презентации в выходной документ. Для этого необходимо задать параметры отображения комментариев в методе `getNotesCommentsLayouting` класса [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/).

Следующий пример кода преобразует презентацию в документ HTML5 с комментариями, отображаемыми справа от слайдов.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```


Документ "output.html" показан на изображении ниже.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Могу ли я управлять тем, будут ли анимации объектов и переходы между слайдами воспроизводиться в HTML5?**

Да, HTML5 предоставляет отдельные параметры для включения или отключения [shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) и [slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Поддерживается ли вывод комментариев и где их можно разместить относительно слайда?**

Да, комментарии можно добавить в HTML5 и разместить (например, справа от слайда) с помощью [layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) для заметок и комментариев.

**Могу ли я пропускать ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**

Да, существует [setting](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) , позволяющий пропускать гиперссылки с вызовами JavaScript при сохранении. Это помогает соответствовать строгим политикам безопасности.