---
title: Конвертация OpenOffice ODP
type: docs
weight: 10
url: /ru/net/convert-openoffice-odp/
keywords: "Конвертация ODP в PDF, ODP в PPT, ODP в PPTX, ODP в XPS, ODP в HTML, ODP в TIFF"
description: "Конвертация ODP в PDF, ODP в PPT, ODP в PPTX, ODP в HTML и другие форматы с помощью Aspose.Slides."
---

[**API Aspose.Slides**](https://products.aspose.com/slides/net/) позволяет вам конвертировать презентации OpenOffice ODP в различные форматы. API, используемый для конвертации ODP файлов в другие документные форматы, такой же, как и для операций конвертации PowerPoint (PPT и PPTX).

Эти примеры покажут вам, как конвертировать ODP документы в другие форматы (просто измените исходный ODP файл):

- [Конвертировать ODP в HTML](/slides/ru/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [Конвертировать ODP в PDF](/slides/ru/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Конвертировать ODP в TIFF](/slides/ru/net/convert-powerpoint-to-tiff/)
- [Конвертировать ODP в SWF Flash](/slides/ru/net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [Конвертировать ODP в XPS](/slides/ru/net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [Конвертировать ODP в PDF с заметками](/slides/ru/net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [Конвертировать ODP в TIFF с заметками](/slides/ru/net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

Например, если вам нужно конвертировать презентацию ODP в PDF, это можно сделать следующим образом:

```csharp
using (Presentation pres = new Presentation("pres.odp"))
{
    pres.Save("pres.pdf", SaveFormat.Pdf);
}
```

## Презентация OpenDocument в различных приложениях

Когда файл Презентации OpenDocument открывается в PowerPoint, он может утратить форматирование, которое было в оригинальном приложении, где он был создан, потому что приложение Презентации OpenDocument и приложение PowerPoint предоставляют разные функции и опции.

Вот некоторые различия:
- В PowerPoint все таблицы обычно загружаются последними и накладываются на другие фигуры (независимо от расположения фигур на слайде ODP).
- Заполнение изображением для таблиц ODP не поддерживается в PowerPoint.
- Вертикальное вращение текста (270, стопка) и распределенное выравнивание не поддерживаются в LibreOffice/OpenOffice Impress.
- Заполнение изображением, градиентное заполнение и паттерн заполнения для текста не поддерживаются в LibreOffice/OpenOffice Impress.

MS PowerPoint и LibreOffice/OpenOffice Impress также по-разному обрабатывают списки. Файл ODP, созданный в PowerPoint, не откроется правильно в LibreOffice/OpenOffice и наоборот.

Это изображение показывает вид списка, созданного в LibreOffice Impress:

![odp-list-example](odp-list-example.png)

**Aspose.Slides** сохраняет списки ODP, чтобы обеспечить их правильное отображение в LibreOffice/OpenOffice Impress.

[Узнайте больше о формате OpenDocument и PowerPoint](https://support.microsoft.com/en-gb/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0/).