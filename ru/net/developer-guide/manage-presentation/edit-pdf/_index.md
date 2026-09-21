---
title: Редактирование PDF документов в .NET
linktitle: Редактировать PDF
type: docs
weight: 65
url: /ru/net/edit-pdf/
keywords:
- редактировать PDF
- заменить текст PDF
- PDF в PPTX
- PPTX в PDF
- .NET
- C#
- Aspose.Slides
description: "Редактировать PDF документы на C#, импортируя их в Aspose.Slides, заменяя текст и сохраняя изменённую презентацию обратно в PDF."
---
## **Обзор**

Aspose.Slides for .NET позволяет редактировать содержимое PDF, импортируя его страницы как слайды, изменяя презентацию и экспортируя её обратно в PDF. В этой статье показана простая замена текста. Презентация остаётся в памяти, поэтому сохранение промежуточного файла PPTX необязательно.

## **Замена текста в PDF**

Используйте [AddFromPdf](https://reference.aspose.com/slides/ru/net/aspose.slides/slidecollection/addfrompdf/) для импорта страниц, [ReplaceText](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/replacetext/) — для обновления текста и [Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/) — для экспорта результата.

В следующем примере предполагается, что `input.pdf` содержит слово «Draft» как редактируемый текст после импорта. Оно заменяется на «Final», и результат записывается в `edited.pdf`. Очистка первого слайда перед импортом предотвращает появление лишней пустой страницы в выводе. Поиск учитывает полные слова с учётом регистра; `null` означает, что обратный вызов результата не требуется.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

Больше вариантов см. в разделе [Search and Replace Text](/slides/ru/net/search-and-replace-text/) и [Convert PowerPoint to PDF](/slides/ru/net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Примечание" %}}
Замена текста работает с импортированным текстом, а не с текстом, находящимся в отсканированных изображениях. Конвертация может изменить макет и форматирование, поэтому рекомендуется проверять результат, особенно если заменяемый текст длиннее оригинального.
{{% /alert %}}

## **FAQ**

**Нужно ли сохранять файл PPTX перед экспортом в PDF?**

Нет. Вы можете редактировать и экспортировать одну и ту же презентацию в памяти. Сохраняйте копию PPTX только если хотите продолжить редактирование в PowerPoint; см. [Save Presentations](/slides/ru/net/save-presentation/).

**Почему часть текста остаётся без изменений?**

В примере используется точное совпадение полного слова «Draft» с учётом регистра. Текст, импортированный как изображение, или разбитый по отдельным текстовым фреймам, может не соответствовать поиску. Проверьте импортированное содержимое и скорректируйте запрос под ваш документ.