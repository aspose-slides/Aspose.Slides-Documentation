---
title: Преобразование презентаций в HTML5 на JavaScript
linktitle: Презентация в HTML5
type: docs
weight: 40
url: /ru/nodejs-java/export-to-html5/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Экспорт презентаций PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides для Node.js. Сохранение форматирования, анимаций и интерактивности."
---

Aspose.Slides поддерживает экспорт в HTML5. Процесс экспорта в HTML5 позволяет преобразовать PowerPoint в HTML без веб‑расширений и зависимостей. Таким образом, используя собственные шаблоны, вы можете применять очень гибкие параметры, определяющие процесс экспорта и полученные HTML, CSS, JavaScript и атрибуты анимации. 

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

Вы можете задать параметры анимации фигур и переходов слайдов следующим образом:
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


В этом случае содержимое презентации визуализируется через SVG в виде, как показано ниже:
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
При использовании этого метода экспорта PowerPoint в HTML, из‑за визуализации SVG вы не сможете применять стили или анимировать отдельные элементы. 
{{% /alert %}}

## **Экспорт PowerPoint в HTML5 в режиме просмотра слайдов**

**Aspose.Slides** позволяет преобразовать презентацию PowerPoint в документ HTML5, в котором слайды отображаются в режиме просмотра слайдов. В этом случае, открывая полученный файл HTML5 в браузере, вы видите презентацию в режиме просмотра слайдов на веб‑странице. 

Этот JavaScript‑код демонстрирует процесс экспорта PowerPoint в HTML5 в режиме просмотра слайдов:
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


## **Преобразовать презентацию в документ HTML5 с комментариями**

Комментарии в PowerPoint — это инструмент, позволяющий пользователям оставлять заметки или отзывы к слайдам презентации. Они особенно полезны в совместных проектах, где несколько человек могут добавлять свои предложения или замечания к конкретным элементам слайда, не изменяя основное содержание. Каждый комментарий отображает имя автора, что упрощает отслеживание, кто оставил замечание.

Допустим, у нас есть следующая презентация PowerPoint, сохранённая в файле "sample.pptx".

![Два комментария на слайде презентации](two_comments_pptx.png)

При преобразовании презентации PowerPoint в документ HTML5 вы можете легко указать, следует ли включать комментарии из презентации в выходной документ. Для этого необходимо задать параметры отображения комментариев в свойстве `notes_comments_layouting` класса [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/).

Следующий пример кода преобразует презентацию в документ HTML5 с комментариями, отображаемыми справа от слайдов.
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```


Документ "output.html" показан на изображении ниже.

![Комментарии в выводимом документе HTML5](two_comments_html5.png)

## **FAQ**

**Могу ли я контролировать, будут ли анимации объектов и переходы слайдов воспроизводиться в HTML5?**  
Да, в HTML5 имеются отдельные параметры для включения или отключения [анимации фигур](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimateshapes/) и [переходов слайдов](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimatetransitions/).

**Поддерживается ли вывод комментариев и где их можно разместить относительно слайда?**  
Да, комментарии могут быть добавлены в HTML5 и размещены (например, справа от слайда) с помощью [настроек расположения](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) для заметок и комментариев.

**Могу ли я пропустить ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**  
Да, существует [параметр](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), позволяющий пропускать гиперссылки с вызовами JavaScript при сохранении. Это помогает соответствовать строгим политическим требованиям безопасности.