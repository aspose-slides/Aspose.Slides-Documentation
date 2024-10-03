---
title: Конвертация ODP в PPTX
type: docs
weight: 10
url: /ru/php-java/convert-odp-to-pptx/
---

## **Конвертация ODP в PPTX/PPT Презентацию**
Aspose.Slides для PHP через Java предлагает класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), который представляет файл презентации. Класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) теперь также может получать доступ к ODP через конструктор [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#Presentation-java.lang.String-), когда объект создается. Следующий пример показывает, как конвертировать ODP-презентацию в PPTX-презентацию.

```php
// Открыть файл ODP
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # Сохранение ODP-презентации в формате PPTX
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Пример в реальном времени**
Вы можете посетить веб-приложение [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/), которое построено на основе **Aspose.Slides API.** Приложение демонстрирует, как можно реализовать конвертацию ODP в PPTX с помощью Aspose.Slides API.