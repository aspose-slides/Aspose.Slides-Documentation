---
title: Экспорт в HTML5
type: документы
weight: 40
url: /java/export-to-html5/
keywords: "PowerPoint в HTML, HTML 5, экспорт HTML, экспорт презентации, конвертировать PowerPoint в HTML, Java, Aspose.Slides для Java"
description: "Экспорт PowerPoint в HTML5 на Java"
---

{{% alert title="Информация" color="info" %}}

В [Aspose.Slides 21.9](/slides/java/aspose-slides-for-java-21-9-release-notes/) мы внедрили поддержку экспорта в HTML5.

{{% /alert %}} 

Процесс экспорта в HTML5 позволяет конвертировать PowerPoint в HTML без веб-расширений или зависимостей. Таким образом, используя свои собственные шаблоны, вы можете применять очень гибкие параметры, определяющие процесс экспорта и результирующие атрибуты HTML, CSS, JavaScript и анимации. 

## **Экспорт PowerPoint в HTML5**

Этот код на Java демонстрирует, как экспортировать презентацию в HTML5 без веб-расширений и зависимостей:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

В этом случае вы получите чистый HTML. 

{{% /alert %}}

Вы можете указать настройки для анимаций объектов и переходов слайдов следующим образом:

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

## **Экспорт PowerPoint в HTML5 режим слайдов**

**Aspose.Slides** позволяет вам конвертировать презентацию PowerPoint в документ HTML5, в котором слайды отображаются в режиме слайд-шоу. В этом случае, когда вы открываете результирующий HTML5 файл в браузере, вы видите презентацию в режиме просмотра слайдов на веб-странице. 

Этот код на Java демонстрирует процесс экспорта PowerPoint в HTML5 режим слайдов:

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