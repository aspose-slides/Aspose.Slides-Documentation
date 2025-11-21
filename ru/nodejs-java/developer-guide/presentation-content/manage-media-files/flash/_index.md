---
title: Flash
type: docs
weight: 10
url: /ru/nodejs-java/flash/
description: Извлечение объектов Flash из презентации PowerPoint с помощью JavaScript
---

## **Извлечение Flash‑объектов из презентации**

Aspose.Slides for Node.js via Java предоставляет возможность извлекать flash‑объекты из презентации. Вы можете получить доступ к flash‑элементу по имени и извлечь его из презентации, включая хранение данных объекта SWF.
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var controls = pres.getSlides().get_Item(0).getControls();
    var flashControl = null;
    for (var i = 0; i < controls.size(); i++) {
        var control = controls.get_Item(i);
        console.log(control.getName() === "ShockwaveFlash1");
        if (control.getName() === "ShockwaveFlash1") {
            flashControl = control;
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Часто задаваемые вопросы**

**Какие форматы презентаций поддерживаются при извлечении Flash‑контента?**

[Aspose.Slides поддерживает](/slides/ru/nodejs-java/supported-file-formats/) основные форматы PowerPoint, такие как PPT и PPTX, поскольку он может загружать эти контейнеры и получать доступ к их элементам управления, включая элементы ActiveX, связанные с Flash.

**Могу ли я конвертировать презентацию с Flash в HTML5 и сохранить интерактивность Flash?**

Нет. Aspose.Slides не выполняет SWF‑контент и не конвертирует его интерактивность. Хотя экспорт в [HTML](/slides/ru/nodejs-java/convert-powerpoint-to-html/)/[HTML5](/slides/ru/nodejs-java/export-to-html5/) поддерживается, Flash не будет воспроизводиться в современных браузерах из‑за окончания поддержки. Рекомендуется заменить Flash альтернативами, например видео или анимациями HTML5, перед экспортом.

**С точки зрения безопасности, Aspose.Slides выполняет SWF‑файлы при чтении презентации?**

Нет. Aspose.Slides рассматривает Flash как бинарные данные, встроенные в файл, и не выполняет SWF‑контент во время обработки.

**Как следует обрабатывать презентации, содержащие Flash вместе с другими вложенными файлами через OLE?**

Aspose.Slides поддерживает [извлечение вложенных OLE‑объектов](/slides/ru/nodejs-java/manage-ole/), поэтому вы можете обработать всё связанное вложенное содержимое за один проход, обрабатывая Flash‑элементы и другие OLE‑вложенные документы совместно.