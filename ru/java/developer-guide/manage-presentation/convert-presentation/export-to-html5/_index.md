---
title: Экспорт в HTML5
type: docs
weight: 40
url: /ru/java/export-to-html5/
keywords: "PowerPoint в HTML, HTML 5, экспорт HTML, Экспорт презентации, Конвертировать PowerPoint в HTML, Java, Aspose.Slides для Java"
description: "Экспорт PowerPoint в HTML5 на Java"
---

{{% alert title="Информация" color="info" %}}

В [Aspose.Slides 21.9](/slides/ru/java/aspose-slides-for-java-21-9-release-notes/) мы реализовали поддержку экспорта в HTML5.

{{% /alert %}}

Процесс экспорта в HTML5 здесь позволяет вам конвертировать PowerPoint в HTML без веб-расширений или зависимостей. Таким образом, с использованием ваших собственных шаблонов вы можете применять очень гибкие параметры, которые определяют процесс экспорта и полученные HTML, CSS, JavaScript и атрибуты анимации.

## **Экспорт PowerPoint в HTML5**

Этот код на Java показывает, как экспортировать презентацию в HTML5 без веб-расширений и зависимостей:

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

Вы можете указать параметры для анимаций объектов и переходов слайдов таким образом:

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

## **Экспорт PowerPoint в HTML**

Этот код на Java демонстрирует стандартный процесс экспорта PowerPoint в HTML:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

В этом случае содержимое презентации отображается через SVG в следующем виде:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> СОДЕРЖИМОЕ СЛАЙДА ЗДЕСЬ </g>
     </svg>
</div>
</body>
```

{{% alert title="Примечание" color="warning" %}} 

Когда вы используете этот метод для экспорта PowerPoint в HTML, из-за рендеринга SVG вы не сможете применять стили или анимировать конкретные элементы. 

{{% /alert %}}

## **Экспорт PowerPoint в HTML5 в режим слайдов**

**Aspose.Slides** позволяет вам конвертировать презентацию PowerPoint в документ HTML5, в котором слайды отображаются в режиме просмотра слайдов. В этом случае, когда вы открываете полученный файл HTML5 в браузере, вы видите презентацию в режиме просмотра слайдов на веб-странице.

Этот код на Java демонстрирует процесс экспорта PowerPoint в HTML5 в режиме просмотра слайдов:

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