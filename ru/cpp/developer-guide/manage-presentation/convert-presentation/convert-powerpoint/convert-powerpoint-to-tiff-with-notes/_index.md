---
title: Конвертирование PowerPoint в TIFF с заметками
type: docs
weight: 100
url: /cpp/convert-powerpoint-to-tiff-with-notes/
keywords: "Конвертирование PowerPoint в TIFF с заметками"
description: "Конвертирование PowerPoint в TIFF с заметками в Aspose.Slides."
---

TIFF является одним из нескольких широко используемых форматов изображений, которые поддерживаются Aspose.Slides для C++ для конвертирования презентаций PowerPoint PPT и PPTX с заметками в изображения. Вы также можете генерировать эскизы слайдов в режиме заметок. Метод [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e), предоставляемый классом Presentation, можно использовать для конвертации всей презентации в режиме заметок в TIFF. Сохранение презентации Microsoft PowerPoint в TIFF с заметками с помощью Aspose.Slides для C++ - это процесс в две строки. Вы просто открываете презентацию и сохраняете её в TIFF с заметками. Вы также можете создать эскиз слайда в режиме заметок для отдельных слайдов. Приведенные ниже фрагменты кода обновляют образец презентации в TIFF изображении в режиме заметок, как показано ниже:

``` cpp
// Путь к каталогу с документами.
System::String dataDir = GetDataPath();

// Создаем объект Presentation, который представляет файл презентации
auto presentation = System::MakeObject<Presentation>(dataDir + u"NotesFile.pptx");

// Сохранение презентации в TIFF с заметками
presentation->Save(dataDir + u"Notes_In_Tiff_out.tiff", SaveFormat::Tiff);
```

{{% alert title="Совет" color="primary" %}}

Вам может быть интересно ознакомиться с [БЕСПЛАТНЫМ конвертером PowerPoint в постер](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) от Aspose.

{{% /alert %}}