---
title: Конвертация презентаций в HTML5 на PHP
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
description: "Экспорт презентаций PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides для PHP через Java. Сохранение форматирования, анимаций и интерактивности."
---

Aspose.Slides поддерживает экспорт в HTML5. Процесс экспорта в HTML5 позволяет преобразовать PowerPoint в HTML без веб‑расширений и зависимостей. Таким образом, используя собственные шаблоны, вы можете задавать гибкие параметры, определяющие процесс экспорта и получающийся HTML, CSS, JavaScript и атрибуты анимации. 

## **Экспорт PowerPoint в HTML5**

Этот PHP‑код показывает, как экспортировать презентацию в HTML5 без веб‑расширений и зависимостей:
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

Вы можете указать параметры анимации фигур и переходов между слайдами следующим образом:
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

Этот Java‑пример демонстрирует стандартный процесс преобразования PowerPoint в HTML:
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
При использовании этого метода экспорта PowerPoint в HTML, из‑за рендеринга SVG вы не сможете применять стили или анимировать отдельные элементы. 
{{% /alert %}}

## **Экспорт PowerPoint в HTML5 Slide View**

**Aspose.Slides** позволяет преобразовать презентацию PowerPoint в документ HTML5, в котором слайды отображаются в режиме просмотра слайдов. В этом случае, открывая полученный файл HTML5 в браузере, вы видите презентацию в режиме просмотра слайдов на веб‑странице. 

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

Комментарии в PowerPoint — это инструмент, позволяющий пользователям оставлять заметки или обратную связь к слайдам презентации. Они особенно полезны в совместных проектах, где несколько человек могут добавлять свои предложения или замечания к отдельным элементам слайда, не изменяя основной контент. Каждый комментарий отображает имя автора, что облегчает отслеживание, кто оставил замечание.

Предположим, у нас есть следующая презентация PowerPoint, сохранённая в файле «sample.pptx».

![Два комментария на слайде презентации](two_comments_pptx.png)

При преобразовании презентации PowerPoint в документ HTML5 вы можете указать, включать ли комментарии из презентации в выходной документ. Для этого необходимо задать параметры отображения комментариев в методе `getNotesCommentsLayouting` класса `Html5Options`.

Следующий пример кода преобразует презентацию в документ HTML5 с комментариями, отображаемыми справа от слайдов.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```


Документ «output.html» показан на изображении ниже.

![Комментарии в выходном документе HTML5](two_comments_html5.png)

## **FAQ**

**Могу ли я управлять тем, будут ли воспроизводиться анимации объектов и переходы слайдов в HTML5?**

Да, в HTML5 имеются отдельные параметры для включения или отключения [анимаций фигур](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) и [переходов слайдов](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/).

**Поддерживается ли вывод комментариев и где их можно разместить относительно слайда?**

Да, комментарии могут быть добавлены в HTML5 и расположены (например, справа от слайда) через [настройки компоновки](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) заметок и комментариев.

**Могу ли я пропустить ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**

Да, существует [параметр](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), позволяющий пропускать гиперссылки с вызовами JavaScript при сохранении. Это помогает соответствовать строгим политикам безопасности.