---
title: Экспорт в HTML5
type: docs
weight: 40
url: /ru/php-java/export-to-html5/
keywords: "PowerPoint в HTML, HTML 5, Экспорт HTML, Экспорт презентации, Конвертация PowerPoint в HTML, Java, Aspose.Slides для PHP через Java"
description: "Экспорт PowerPoint в HTML5"
---

{{% alert title="Информация" color="info" %}}

В [Aspose.Slides 21.9](/slides/ru/php-java/aspose-slides-for-java-21-9-release-notes/) мы реализовали поддержку экспорта в HTML5.

{{% /alert %}} 

Процесс экспорта в HTML5 позволяет вам конвертировать PowerPoint в HTML без веб-расширений или зависимостей. Таким образом, используя свои собственные шаблоны, вы можете применять очень гибкие параметры, которые определяют процесс экспорта и результатирующие HTML, CSS, JavaScript и атрибуты анимации. 

## **Экспорт PowerPoint в HTML5**

Этот PHP-код демонстрирует, как экспортировать презентацию в HTML5 без веб-расширений и зависимостей:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html5);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

В этом случае вы получаете чистый HTML. 

{{% /alert %}}

Вы можете указать параметры для анимаций фигур и переходов слайдов следующим образом:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(false);
    $html5Options->setAnimateTransitions(false);
    $pres->save("pres5.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Экспорт PowerPoint в HTML**

Этот Java-код демонстрирует стандартный процесс экспорта PowerPoint в HTML:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

В этом случае содержание презентации отображается через SVG в форме:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> СОДЕРЖИМОЕ СЛАЙДА ЗДЕСЬ </g>
     </svg>
</div>
</body>
```php

```

{{% alert title="Примечание" color="warning" %}} 

При использовании этого метода для экспорта PowerPoint в HTML, из-за рендеринга SVG, вы не сможете применять стили или анимировать конкретные элементы. 

{{% /alert %}}

## **Экспорт PowerPoint в HTML5 в режиме просмотра слайдов**

**Aspose.Slides** позволяет вам конвертировать презентацию PowerPoint в документ HTML5, в котором слайды представлены в режиме просмотра слайдов. В этом случае, когда вы открываете полученный HTML5 файл в браузере, вы видите презентацию в режиме просмотра слайдов на веб-странице. 

Этот PHP-код демонстрирует процесс экспорта PowerPoint в HTML5 в режиме просмотра слайдов:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(true);
    $html5Options->setAnimateTransitions(true);
    $pres->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```