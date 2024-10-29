---
title: Экспорт в HTML5
type: docs
weight: 40
url: /ru/cpp/export-to-html5/
keywords: "PowerPoint в HTML, HTML 5, экспорт в HTML, Экспорт презентации, Конвертировать PowerPoint в HTML, C++, Aspose.Slides для C++"
description: "Экспорт PowerPoint в HTML5 на C++" 
---

{{% alert title="Информация" color="info" %}}

В [Aspose.Slides 21.9](/slides/ru/cpp/aspose-slides-for-cpp-21-9-release-notes/) мы реализовали поддержку экспорта в HTML5.

{{% /alert %}}

Процесс экспорта в HTML5 позволяет вам преобразовать PowerPoint в HTML. Таким образом, используя свои собственные шаблоны, вы можете применять очень гибкие параметры, которые определяют процесс экспорта и полученные атрибуты HTML, CSS, JavaScript и анимации.

## **Экспорт PowerPoint в HTML5**

Этот C++ код показывает, как экспортировать презентацию в HTML5.

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}}

В этом случае вы получаете чистый HTML.

{{% /alert %}}

Вы можете указать настройки для анимаций форм и переходов слайдов следующим образом:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **Экспорт PowerPoint в HTML**

Этот C++ код демонстрирует стандартный процесс экспорта PowerPoint в HTML:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

В этом случае содержимое презентации рендерится через SVG в форме, подобной следующей:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> СОДЕРЖИМОЕ СЛАЙДОВ ЗДЕСЬ </g>
     </svg>
</div>
</body>
```

{{% alert title="Заметка" color="warning" %}}

Когда вы используете этот метод для экспорта PowerPoint в HTML, из-за рендеринга SVG вы не сможете применять стили или анимировать конкретные элементы.

{{% /alert %}}

## **Экспорт просмотр слайдов PowerPoint в HTML5**

**Aspose.Slides** позволяет вам конвертировать презентацию PowerPoint в документ HTML5, в котором слайды представлены в режиме просмотра слайдов. В этом случае, когда вы открываете полученный HTML5 файл в браузере, вы видите презентацию в режиме просмотра слайдов на веб-странице.

Этот C++ код демонстрирует процесс экспорта PowerPoint в HTML5 в режиме просмотра слайдов:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```