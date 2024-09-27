---
title: Конвертация ODP в PPTX
type: docs
weight: 10
url: /ru/androidjava/convert-odp-to-pptx/
---

## **Конвертация ODP в PPTX/PPT Презентацию**
Aspose.Slides для Android через Java предлагает класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), который представляет файл презентации. Класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) теперь также может получать доступ к ODP через конструктор [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-), когда объект создается. В следующем примере показано, как конвертировать презентацию ODP в презентацию PPTX.

```java
// Открываем файл ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Сохранение презентации ODP в формате PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Пример в реальном времени**
Вы можете посетить веб-приложение [**Конвертация Aspose.Slides**](https://products.aspose.app/slides/conversion/), которое построено с использованием **Aspose.Slides API.** Приложение демонстрирует, как можно реализовать конвертацию ODP в PPTX с помощью Aspose.Slides API.