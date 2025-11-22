---
title: Flash
type: docs
weight: 10
url: /ru/net/flash/
keywords: "Извлечение flash, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Извлечение flash‑объекта из презентации PowerPoint на C# или .NET"
---

## **Извлечение Flash-объектов из презентации**
Aspose.Slides for .NET предоставляет возможность извлекать flash-объекты из презентации. Вы можете получить доступ к flash‑элементу по имени и извлечь его из презентации, включая сохранённые данные объекта SWF.
```c#
using (Presentation pres = new Presentation("withFlash.pptm"))
{
    IControlCollection controls = pres.Slides[0].Controls;
    Control flashControl = null;
    foreach (IControl control in controls)
    {
        if (control.Name == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
}
```


## **FAQ**

**Какие форматы презентаций поддерживаются при извлечении Flash‑контента?**

[Aspose.Slides supports](/slides/ru/net/supported-file-formats/) основные форматы PowerPoint, такие как PPT и PPTX, поскольку он может загружать эти контейнеры и получать доступ к их элементам управления, включая связанные с Flash ActiveX‑элементы.

**Могу ли я конвертировать презентацию с Flash в HTML5 и сохранить интерактивность Flash?**

Нет. Aspose.Slides не выполняет SWF‑контент и не конвертирует его интерактивность. Хотя экспорт в [HTML](/slides/ru/net/convert-powerpoint-to-html/)/[HTML5](/slides/ru/net/export-to-html5/) поддерживается, Flash не будет работать в современных браузерах из‑за прекращения поддержки. Рекомендуется заменить Flash альтернативами, такими как видео или анимации HTML5, перед экспортом.

**С точки зрения безопасности, выполняет ли Aspose.Slides SWF‑файлы при чтении презентации?**

Нет. Aspose.Slides рассматривает Flash как бинарные данные, встроенные в файл, и не выполняет SWF‑контент во время обработки.

**Как обрабатывать презентации, содержащие Flash вместе с другими встраиваемыми файлами через OLE?**

Aspose.Slides поддерживает [extracting embedded OLE objects](/slides/ru/net/manage-ole/), поэтому вы можете обработать весь связанный встраиваемый контент за один проход, обрабатывая Flash‑элементы управления и другие OLE‑встроенные документы вместе.