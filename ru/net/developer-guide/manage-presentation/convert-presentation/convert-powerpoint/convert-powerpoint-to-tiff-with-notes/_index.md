---
title: Конвертация PowerPoint в TIFF с заметками
type: docs
weight: 100
url: /net/convert-powerpoint-to-tiff-with-notes/
keywords: "Конвертация PowerPoint в TIFF с заметками"
description: "Конвертация PowerPoint в TIFF с заметками в Aspose.Slides."
---

{{% alert title="Совет" color="primary" %}}

Вам может быть интересно ознакомиться с [БЕСПЛАТНЫМ конвертером PowerPoint в постер](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) от Aspose.

{{% /alert %}}

TIFF является одним из нескольких широко используемых форматов изображений, которые поддерживает Aspose.Slides для .NET для конвертации презентаций PowerPoint PPT и PPTX с заметками в изображения. Вы также можете генерировать миниатюры слайдов в режиме заметок. Метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index), предоставленный классом Presentation, можно использовать для конвертации всей презентации в режиме заметок в TIFF. Сохранение презентации Microsoft PowerPoint в TIFF с заметками с помощью Aspose.Slides для .NET — это процесс в две строки. Вы просто открываете презентацию и сохраняете её в формате TIFF с заметками. Вы также можете генерировать миниатюры слайдов в режиме заметок для отдельных слайдов. Приведенный ниже код обновляет пример презентации в TIFF-изображения в режиме заметок, как показано ниже:

```c#
// Создаем объект Presentation, представляющий файл презентации
using (Presentation presentation = new Presentation("NotesFile.pptx"))
{
    // Сохраняем презентацию в TIFF с заметками
    presentation.Save("Notes_In_Tiff_out.tiff", SaveFormat.Tiff);
}
```