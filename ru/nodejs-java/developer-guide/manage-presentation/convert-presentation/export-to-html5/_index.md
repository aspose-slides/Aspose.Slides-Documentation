---
title: Экспорт в HTML5
type: docs
weight: 40
url: /ru/nodejs-java/export-to-html5/
keywords:
- PowerPoint в HTML
- слайды в HTML
- HTML5
- Экспорт HTML
- экспорт презентации
- преобразование презентации
- преобразование слайдов
- Java
- Aspose.Slides для Node.js через Java
description: "Экспорт PowerPoint в HTML5 на JavaScript"
---

{{% alert title="Информация" color="info" %}}

В [Aspose.Slides 21.9](/slides/ru/nodejs-java/aspose-slides-for-java-21-9-release-notes/) мы реализовали поддержку экспорта в HTML5.

{{% /alert %}} 

Процесс экспорта в HTML5 позволяет преобразовать PowerPoint в HTML без веб‑расширений и зависимостей. Таким образом, используя собственные шаблоны, вы можете задавать гибкие параметры, определяющие процесс экспорта и полученные HTML, CSS, JavaScript и атрибуты анимации. 

## **Экспорт PowerPoint в HTML5**

Этот JavaScript‑код показывает, как экспортировать презентацию в HTML5 без веб‑расширений и зависимостей:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

В этом случае вы получаете чистый HTML. 

{{% /alert %}}

Вы можете задать настройки анимаций фигур и переходов между слайдами следующим образом:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Экспорт PowerPoint в HTML**

Этот JavaScript демонстрирует стандартный процесс экспорта PowerPoint в HTML:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
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

**Aspose.Slides** позволяет преобразовать презентацию PowerPoint в документ HTML5, в котором слайды представлены в режиме просмотра слайдов. В этом случае, открывая полученный файл HTML5 в браузере, вы видите презентацию в режиме просмотра слайдов на веб‑странице. 

Этот JavaScript‑код демонстрирует процесс экспорта PowerPoint в режим просмотра слайдов HTML5:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Преобразование презентации в документ HTML5 с комментариями**

Комментарии в PowerPoint — это инструмент, позволяющий пользователям оставлять заметки или отзывы к слайдам презентации. Они особенно полезны в совместных проектах, где несколько человек могут добавлять свои предложения или замечания к конкретным элементам слайда, не изменяя основное содержание. Каждый комментарий отображает имя автора, что упрощает отслеживание, кто оставил замечание.

Предположим, у нас есть следующая презентация PowerPoint, сохранённая в файле «sample.pptx».

![Two comments on the presentation slide](two_comments_pptx.png)

При преобразовании презентации PowerPoint в документ HTML5 вы можете указать, включать ли комментарии из презентации в выходной документ. Для этого необходимо задать параметры отображения комментариев в свойстве `notes_comments_layouting` класса [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/).

Следующий пример кода преобразует презентацию в документ HTML5 с комментариями, отображаемыми справа от слайдов.
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```


Документ «output.html» показан на изображении ниже.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Могу ли я управлять тем, будут ли анимации объектов и переходы между слайдами воспроизводиться в HTML5?**

Да, в HTML5 есть отдельные параметры для включения или отключения [анимаций фигур](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimateshapes/) и [переходов между слайдами](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimatetransitions/).

**Поддерживается ли вывод комментариев и где их можно разместить относительно слайда?**

Да, комментарии могут быть добавлены в HTML5 и размещены (например, справа от слайда) с помощью [настроек размещения](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) для заметок и комментариев.

**Можно ли отключить ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**

Да, существует [параметр](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), позволяющий пропускать гиперссылки с вызовами JavaScript при сохранении. Это помогает соответствовать строгим политикам безопасности.