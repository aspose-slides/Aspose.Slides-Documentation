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

{{% alert title="Info" color="info" %}}
В [Aspose.Slides 21.9](/slides/ru/cpp/aspose-slides-for-cpp-21-9-release-notes/) мы реализовали поддержку экспорта в HTML5.
{{% /alert %}} 

Процесс экспорта в HTML5 позволяет конвертировать PowerPoint в HTML. Таким образом, используя собственные шаблоны, вы можете применять очень гибкие параметры, определяющие процесс экспорта и полученные HTML, CSS, JavaScript и атрибуты анимации. 

## **Экспорт PowerPoint в HTML5**

Этот код на C++ показывает, как экспортировать презентацию в HTML5.
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```


{{% alert color="primary" %}} 
В этом случае вы получаете чистый HTML. 
{{% /alert %}}

Вы можете указать настройки анимаций фигур и переходов слайдов следующим образом:
```cpp
using namespace Aspose::Slides;
using namespace Aspense::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```


## **Экспорт PowerPoint в HTML**

Этот код на C++ демонстрирует стандартный процесс экспорта PowerPoint в HTML:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```


В этом случае содержимое презентации рендерится через SVG в виде, как показано ниже:
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
При использовании этого метода экспорта PowerPoint в HTML, из‑за рендеринга SVG, вы не сможете применять стили или анимировать отдельные элементы. 
{{% /alert %}}

## **Экспорт PowerPoint в режим просмотра слайдов HTML5**

**Aspose.Slides** позволяет конвертировать презентацию PowerPoint в документ HTML5, в котором слайды отображаются в режиме просмотра слайдов. В этом случае, открывая полученный файл HTML5 в браузере, вы видите презентацию в режиме просмотра слайдов на веб‑странице. 

Этот код на C++ демонстрирует процесс экспорта PowerPoint в режим просмотра слайдов HTML5:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **Преобразование презентации в документ HTML5 с комментариями**

Комментарии в PowerPoint — это инструмент, позволяющий пользователям оставлять заметки или отзывы к слайдам презентации. Они особенно полезны в совместных проектах, где несколько человек могут добавлять свои предложения или замечания к отдельным элементам слайда, не изменяя основной контент. Каждый комментарий отображает имя автора, что упрощает отслеживание, кто оставил замечание.

Предположим, у нас есть следующая презентация PowerPoint, сохранённая в файле "sample.pptx".

![Два комментария на слайде презентации](two_comments_pptx.png)

При конвертации презентации PowerPoint в документ HTML5 вы можете легко указать, включать ли комментарии из презентации в итоговый документ. Для этого необходимо задать параметры отображения комментариев в методе `get_NotesCommentsLayouting` класса [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) .

Следующий пример кода конвертирует презентацию в документ HTML5 с комментариями, отображаемыми справа от слайдов.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```


Документ "output.html" показан на изображении ниже.

![Комментарии в результирующем документе HTML5](two_comments_html5.png)

## **Часто задаваемые вопросы**

**Могу ли я контролировать, будут ли анимации объектов и переходы слайдов воспроизводиться в HTML5?**  
**Да, HTML5 предоставляет отдельные параметры для включения или отключения [анимаций фигур](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) и [переходов слайдов](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).**

**Поддерживается ли вывод комментариев и где их можно разместить относительно слайда?**  
**Да, комментарии можно добавить в HTML5 и разместить (например, справа от слайда) с помощью настроек компоновки заметок и комментариев.**

**Могу ли я пропускать ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**  
**Да, существует [настройка](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/), позволяющая пропускать гиперссылки с вызовами JavaScript при сохранении.**