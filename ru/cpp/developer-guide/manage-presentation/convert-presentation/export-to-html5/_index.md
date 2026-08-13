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
description: "Экспортировать презентации PowerPoint и OpenDocument в отзывчивый HTML5 с помощью Aspose.Slides для C++. Сохранить форматирование, анимацию и интерактивность."
---
## **Обзор**

Эта статья объясняет, как конвертировать презентации PowerPoint в HTML5 с помощью Aspose.Slides. Рассматривается базовый экспорт в HTML5 без веб‑расширений и дополнительных зависимостей, а также параметры управления анимацией фигур и переходами между слайдами. В статье также показан стандартный процесс экспорта PowerPoint в HTML, объясняется, как генерировать вывод HTML5 в режиме просмотра слайдов, и демонстрируется, как включить комментарии в экспортируемый документ, настроив их расположение.

## **Экспорт PowerPoint в HTML5**

Этот C++ код показывает, как экспортировать презентацию в HTML5.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 
В этом случае вы получаете чистый HTML. 
{{% /alert %}}

Вы можете указать параметры для анимации фигур и переходов между слайдами следующим образом:

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **Экспорт PowerPoint в HTML**

Этот C++ демонстрирует стандартный процесс экспорта PowerPoint в HTML:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

В этом случае содержимое презентации отображается через SVG в виде, показанном ниже:

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
При использовании этого метода экспорта PowerPoint в HTML из‑за рендеринга SVG вы не сможете применять стили или анимировать отдельные элементы. 
{{% /alert %}}

## **Экспорт PowerPoint в HTML5 с просмотром слайдов**

**Aspose.Slides** позволяет конвертировать презентацию PowerPoint в документ HTML5, в котором слайды отображаются в режиме просмотра слайдов. В этом случае, открывая полученный HTML5‑файл в браузере, вы видите презентацию в режиме просмотра слайдов на веб‑странице. 

Этот C++ код демонстрирует процесс экспорта PowerPoint в HTML5 с просмотром слайдов:

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Преобразование презентации в документ HTML5 с комментариями**

Комментарии в PowerPoint — это инструмент, позволяющий пользователям оставлять заметки или обратную связь к слайдам презентации. Они особенно полезны в совместных проектах, где несколько человек могут добавлять свои предложения или замечания к конкретным элементам слайда, не изменяя основной контент. Каждый комментарий отображает имя автора, что упрощает отслеживание, кто оставил замечание.

Предположим, у нас есть следующая презентация PowerPoint, сохранённая в файле «sample.pptx».

![Два комментария на слайде презентации](two_comments_pptx.png)

При конвертации презентации PowerPoint в документ HTML5 вы можете указать, включать ли комментарии из презентации в выходной документ. Для этого необходимо задать параметры отображения комментариев в методе `get_NotesCommentsLayouting` класса [Html5Options](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/html5options/).

Следующий пример кода конвертирует презентацию в документ HTML5 с комментариями, отображаемыми справа от слайдов.
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Документ «output.html» показан на изображении ниже.

![Комментарии в выходном документе HTML5](two_comments_html5.png)

## **FAQ**

### Можно ли управлять тем, будут ли воспроизводиться анимации объектов и переходы между слайдами в HTML5?

Да, HTML5 предоставляет отдельные параметры для включения или отключения [анимации фигур](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/html5options/set_animateshapes/) и [переходов между слайдами](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/html5options/set_animatetransitions/).

### Поддерживается ли вывод комментариев и где их можно разместить относительно слайда?

Да, комментарии могут быть добавлены в HTML5 и размещены (например, справа от слайда) с помощью параметров разметки заметок и комментариев.

### Можно ли пропустить ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?

Да, существует [настройка](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/), позволяющая пропускать гиперссылки с вызовами JavaScript при сохранении. Это помогает соответствовать строгим политикам безопасности.