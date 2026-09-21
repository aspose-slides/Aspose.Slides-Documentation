---
title: Редактировать PDF-документы на Android
linktitle: Редактировать PDF
type: docs
weight: 65
url: /ru/androidjava/edit-pdf/
keywords:
- редактировать PDF
- заменить текст PDF
- PDF в PPTX
- PPTX в PDF
- Android
- Java
- Aspose.Slides
description: "Редактировать PDF-документы на Android с помощью Java, импортируя их в Aspose.Slides, заменяя текст и сохраняя изменённую презентацию обратно в PDF."
---
## **Обзор**

Aspose.Slides for Android via Java позволяет редактировать содержимое PDF, импортируя его страницы как слайды, изменяя презентацию и экспортируя её обратно в PDF. В этой статье показана простая замена текста. Презентация остаётся в памяти, поэтому сохранение промежуточного файла PPTX необязательно.

## **Замена текста в PDF**

Используйте [addFromPdf](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) для импорта страниц, [replaceText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) для обновления текста и [save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) для экспорта результата.

В следующем примере ожидается, что `input.pdf` содержит слово «Draft» как редактируемый текст после импорта. Оно заменяет это слово на «Final» и записывает `edited.pdf`. Очистка первоначального слайда перед импортом предотвращает появление дополнительной пустой страницы в результате. Поиск сопоставляет полные слова с учётом регистра; `null` означает, что обратный вызов результата не требуется.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Для получения дополнительных вариантов см. [Поиск и замена текста](/slides/ru/androidjava/search-and-replace-text/) и [Конвертация PowerPoint в PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Замена текста работает с импортированным текстом, а не с текстом внутри отсканированных изображений. Конверсия может влиять на макет и форматирование, поэтому проверяйте результат, особенно если заменяемый текст длиннее оригинала.
{{% /alert %}}

## **FAQ**

**Нужно ли сохранять файл PPTX перед экспортом в PDF?**

Нет. Вы можете редактировать и экспортировать одну и ту же презентацию в памяти. Сохраните копию PPTX только если вы также хотите продолжать редактировать её в PowerPoint; см. [Сохранить презентации](/slides/ru/androidjava/save-presentation/).

**Почему некоторый текст остаётся неизменным?**

Пример сопоставляет полное слово «Draft» с точным регистром. Текст, импортированный как изображение, или разбитый по отдельным текстовым фреймам, может не соответствовать поиску. Проверьте импортированное содержание и скорректируйте поиск для вашего документа.