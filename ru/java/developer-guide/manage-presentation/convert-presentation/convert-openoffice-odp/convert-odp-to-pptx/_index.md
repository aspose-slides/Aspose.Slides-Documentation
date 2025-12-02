---
title: Конвертировать ODP в PPTX на Java
linktitle: ODP в PPTX
type: docs
weight: 10
url: /ru/java/convert-odp-to-pptx/
keywords:
- конвертировать OpenDocument
- конвертировать презентацию
- конвертировать слайд
- конвертировать ODP
- OpenDocument в PPTX
- ODP в PPTX
- сохранить ODP как PPTX
- экспортировать ODP в PPTX
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Конвертировать ODP в PPTX с помощью Aspose.Slides для Java. Чистые примеры кода Java, советы по пакетной обработке и высококачественные результаты - без необходимости в PowerPoint."
---

## **Конвертировать ODP в презентацию PPTX/PPT**
Aspose.Slides for Java предоставляет класс [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), представляющий файл презентации. Класс [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) теперь также может получать доступ к ODP через конструктор [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#Presentation-java.lang.String-), когда объект создаётся. Следующий пример показывает, как конвертировать презентацию ODP в презентацию PPTX.
```java
// Открыть файл ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Сохранение презентации ODP в формат PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Живой пример**
Вы можете посетить веб-приложение [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/), построенное с помощью **Aspose.Slides API.** Приложение демонстрирует, как можно реализовать конвертацию ODP в PPTX с использованием Aspose.Slides API.