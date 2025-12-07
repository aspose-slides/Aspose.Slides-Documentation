---
title: Преобразование презентаций в HTML5 в C++
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
- экспорт PPT в HTML5
- экспорт PPTX в HTML5
- экспорт ODP в HTML5
- C++
- Aspose.Slides
description: "Экспортировать презентации PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides для C++. Сохранить форматирование, анимацию и интерактивность."
---

{{% alert title="Информация" color="info" %}}

В [Aspose.Slides 21.9](/slides/ru/cpp/aspose-slides-for-cpp-21-9-release-notes/), мы реализовали поддержку экспорта в HTML5.

{{% /alert %}} 

Экспорт в HTML5 позволяет конвертировать PowerPoint в HTML. При этом, используя собственные шаблоны, можно задать гибкие параметры, определяющие процесс экспорта и полученные HTML, CSS, JavaScript и атрибуты анимации. 

## **Export PowerPoint to HTML5**

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

Вы можете указать настройки анимации фигур и переходов слайдов следующим образом:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```


## **Export PowerPoint to HTML**

Этот C++ демонстрирует стандартный процесс экспорта PowerPoint в HTML:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```


В этом случае содержимое презентации отображается через SVG в виде, приведённом ниже:
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

При использовании этого метода экспорта PowerPoint в HTML, из‑за рендеринга через SVG, вы не сможете применять стили или анимировать отдельные элементы. 

{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** позволяет конвертировать презентацию PowerPoint в документ HTML5, в котором слайды отображаются в режиме просмотра слайдов. В этом случае, открыв полученный файл HTML5 в браузере, вы увидите презентацию в режиме просмотра слайдов на веб‑странице. 

Этот C++ код демонстрирует процесс экспорта PowerPoint в режим просмотра слайдов HTML5:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **Convert a Presentation to an HTML5 Document with Comments**

Комментарии в PowerPoint — это инструмент, позволяющий пользователям оставлять заметки или обратную связь к слайдам презентации. Они особенно полезны в совместных проектах, где несколько человек могут добавить свои предложения или замечания к конкретным элементам слайда, не изменяя основной контент. Каждый комментарий отображает имя автора, что упрощает отслеживание, кто оставил замечание.

Допустим, у нас есть следующая презентация PowerPoint, сохранённая в файле «sample.pptx».

![Два комментария на слайде презентации](two_comments_pptx.png)

При конвертации презентации PowerPoint в документ HTML5 вы можете указать, включать ли комментарии из презентации в выходной документ. Для этого необходимо задать параметры отображения комментариев в методе `get_NotesCommentsLayouting` класса [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/).

В следующем примере кода презентация конвертируется в документ HTML5 с комментариями, отображаемыми справа от слайдов.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```


Документ «output.html» показан на изображении ниже.

![Комментарии в выходном документе HTML5](two_comments_html5.png)

## **FAQ**

**Могу ли я контролировать, будут ли анимации объектов и переходы слайдов воспроизводиться в HTML5?**

Да, HTML5 предоставляет отдельные параметры для включения или отключения [анимации фигур](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) и [переходов слайдов](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**Поддерживается ли вывод комментариев и где их можно разместить относительно слайда?**

Да, комментарии можно добавлять в HTML5 и размещать (например, справа от слайда) с помощью настроек макета заметок и комментариев.

**Можно ли пропускать ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**

Да, существует [параметр](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/), позволяющий пропускать гиперссылки с вызовами JavaScript при сохранении. Это помогает соответствовать строгим политикам безопасности.