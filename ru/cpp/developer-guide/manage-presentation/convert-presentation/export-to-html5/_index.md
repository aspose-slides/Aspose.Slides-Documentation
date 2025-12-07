---
title: Конвертировать презентации в HTML5 на C++
linktitle: Презентация в HTML5
type: docs
weight: 40
url: /ru/cpp/export-to-html5/
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
- C++
- Aspose.Slides
description: "Экспортировать презентации PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides для C++. Сохранить форматирование, анимацию и интерактивность."
---

{{% alert title="Информация" color="info" %}}

В [Aspose.Slides 21.9](/slides/ru/cpp/aspose-slides-for-cpp-21-9-release-notes/), мы реализовали поддержку экспорта в HTML5.

{{% /alert %}} 

Процесс экспорта в HTML5 позволяет преобразовать PowerPoint в HTML. Таким образом, используя собственные шаблоны, вы можете задавать гибкие параметры, определяющие процесс экспорта и полученные HTML, CSS, JavaScript и атрибуты анимации. 

## **Экспорт PowerPoint в HTML5**

Этот пример C++ показывает, как экспортировать презентацию в HTML5.
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```


{{% alert color="primary" %}} 

В этом случае вы получаете чистый HTML. 

{{% /alert %}}

Вы можете указать настройки анимации фигур и переходов между слайдами следующим образом:
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

Этот пример C++ демонстрирует стандартный процесс экспорта PowerPoint в HTML:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```


В этом случае содержимое презентации отображается с помощью SVG в виде:
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

При использовании этого метода экспорта PowerPoint в HTML, из‑за рендеринга SVG вы не сможете применять стили или анимировать отдельные элементы. 

{{% /alert %}}

## **Экспорт PowerPoint в HTML5 в режиме просмотра слайдов**

**Aspose.Slides** позволяет преобразовать презентацию PowerPoint в документ HTML5, в котором слайды отображаются в режиме просмотра слайдов. В этом случае, открывая полученный файл HTML5 в браузере, вы видите презентацию в режиме просмотра слайдов на веб‑странице. 

Этот пример C++ демонстрирует процесс экспорта PowerPoint в HTML5 с просмотром слайдов:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **Преобразование презентации в документ HTML5 с комментариями**

Комментарии в PowerPoint — это инструмент, позволяющий пользователям оставлять заметки или обратную связь к слайдам презентации. Они особенно полезны в совместных проектах, когда несколько человек могут добавить свои предложения или замечания к конкретным элементам слайда, не изменяя основное содержание. Каждый комментарий отображает имя автора, что упрощает отслеживание, кто оставил замечание.

Предположим, у нас есть следующая презентация PowerPoint, сохранённая в файле “sample.pptx”.

![Two comments on the presentation slide](two_comments_pptx.png)

При преобразовании презентации PowerPoint в документ HTML5 вы можете задать, включать ли комментарии из презентации в выходной документ. Для этого необходимо указать параметры отображения комментариев в методе `get_NotesCommentsLayouting` класса [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/).

Следующий пример кода преобразует презентацию в документ HTML5 с комментариями, отображаемыми справа от слайдов.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```


Документ “output.html” показан на изображении ниже.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Могу ли я контролировать, будут ли анимации объектов и переходы между слайдами воспроизводиться в HTML5?**

Да, в HTML5 есть отдельные параметры для включения или отключения [анимации фигур](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) и [переходов между слайдами](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**Поддерживается ли вывод комментариев и где их можно разместить относительно слайда?**

Да, комментарии можно добавить в HTML5 и разместить (например, справа от слайда) с помощью настроек компоновки заметок и комментариев.

**Можно ли пропускать ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**

Да, существует [настройка](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/), позволяющая пропускать гиперссылки с вызовами JavaScript при сохранении. Это помогает соответствовать строгим политикам безопасности.