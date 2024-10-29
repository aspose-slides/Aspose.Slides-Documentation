---
title: Конвертация ODP в PPTX
type: docs
weight: 10
url: /ru/java/convert-odp-to-pptx/
---

## **Конвертация ODP в PPTX/PPT Презентацию**
Aspose.Slides для Java предлагает класс [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), который представляет собой файл презентации. Класс [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) теперь также может получать доступ к ODP через конструктор [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#Presentation-java.lang.String-), когда объект инициализирован. Следующий пример демонстрирует, как конвертировать ODP-презентацию в PPTX-презентацию.

```java
// Открыть файл ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Сохранение ODP презентации в формат PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Живой пример**
Вы можете посетить веб-приложение [**Конвертация Aspose.Slides**](https://products.aspose.app/slides/conversion/), которое создано с использованием **Aspose.Slides API.** Приложение демонстрирует, как может быть реализована конвертация ODP в PPTX с помощью Aspose.Slides API.