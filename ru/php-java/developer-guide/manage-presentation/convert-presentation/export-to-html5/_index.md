---
title: Конвертировать презентации в HTML5 на PHP
linktitle: Презентация в HTML5
type: docs
weight: 40
url: /ru/php-java/export-to-html5/
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
- PHP
- Aspose.Slides
description: "Экспортировать презентации PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides для PHP через Java. Сохранить форматирование, анимацию и интерактивность."
---

{{% alert title="Info" color="info" %}}

В [Aspose.Slides 21.9](/slides/ru/php-java/aspose-slides-for-java-21-9-release-notes/), мы реализовали поддержку экспорта в HTML5.

{{% /alert %}} 

Процесс экспорта в HTML5 позволяет преобразовать PowerPoint в HTML без веб‑расширений и зависимостей. При этом, используя собственные шаблоны, вы можете задавать гибкие параметры, определяющие процесс экспорта и полученный HTML, CSS, JavaScript и атрибуты анимации. 

## **Экспорт PowerPoint в HTML5**

Этот PHP‑код демонстрирует, как экспортировать презентацию в HTML5 без веб‑расширений и зависимостей:
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

Вы можете указать настройки анимаций фигур и переходов между слайдами следующим образом:
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

Этот Java‑пример демонстрирует стандартный процесс экспорта PowerPoint в HTML:
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


В этом случае содержимое презентации отображается через SVG в виде:
```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```php

```


{{% alert title="Note" color="warning" %}} 

При использовании этого метода экспорта PowerPoint в HTML из‑за рендеринга SVG вы не сможете применять стили или анимировать отдельные элементы. 

{{% /alert %}}

## **Экспорт PowerPoint в режим просмотра слайдов HTML5**

**Aspose.Slides** позволяет преобразовать презентацию PowerPoint в документ HTML5, в котором слайды отображаются в режиме просмотра слайдов. В этом случае, открыв полученный файл HTML5 в браузере, вы увидите презентацию в режиме просмотра слайдов на веб‑странице. 

Этот PHP‑код демонстрирует процесс экспорта PowerPoint в режим просмотра слайдов HTML5:
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


## **Преобразование презентаций в документы HTML5 с комментариями**

Комментарии в PowerPoint — это инструмент, позволяющий пользователям оставлять заметки или обратную связь к слайдам презентации. Они особенно полезны в совместных проектах, когда несколько человек могут добавлять свои предложения или замечания к конкретным элементам слайда, не изменяя основной контент. Каждый комментарий отображает имя автора, что облегчает отслеживание, кто оставил замечание.

Предположим, у нас есть следующая презентация PowerPoint, сохранённая в файле «sample.pptx».

![Two comments on the presentation slide](two_comments_pptx.png)

При преобразовании презентации PowerPoint в документ HTML5 вы можете легко указать, включать ли комментарии из презентации в выходной документ. Для этого необходимо задать параметры отображения комментариев в методе `getNotesCommentsLayouting` класса `Html5Options`.

Ниже приведён пример кода, который преобразует презентацию в документ HTML5 с комментариями, отображаемыми справа от слайдов.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```


Документ «output.html» показан на изображении ниже.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Могу ли я управлять тем, будут ли анимации объектов и переходы между слайдами воспроизводиться в HTML5?**

Да, в HTML5 есть отдельные параметры для включения или отключения [анимаций фигур](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) и [переходов между слайдами](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/).

**Поддерживается ли вывод комментариев и где их можно разместить относительно слайда?**

Да, комментарии можно добавить в HTML5 и разместить (например, справа от слайда) с помощью [настроек расположения](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) для заметок и комментариев.

**Можно ли пропустить ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**

Да, существует [параметр](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), позволяющий пропускать гиперссылки с вызовами JavaScript при сохранении. Это помогает соответствовать строгим политикам безопасности.