---
title: Флеш
type: docs
weight: 10
url: /androidjava/flash/
description: Извлечение объектов Flash из презентации PowerPoint с использованием Java
---

## **Извлечение объектов Flash из презентации**

Aspose.Slides для Android через Java предоставляет возможность извлекать объекты Flash из презентации. Вы можете получить доступ к Flash-контролю по имени и извлечь его из презентации, включая хранение данных объекта SWF.

```java
// Создание экземпляра класса Presentation, который представляет PPTX
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```