---
title: Конвертация ODP в PPTX
type: docs
weight: 10
url: /cpp/convert-odp-to-pptx/
---

Aspose.Slides для .NET предлагает класс Presentation, который представляет файл презентации. Класс [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) теперь также может получать доступ к ODP через конструктор Presentation при создании объекта. В следующем примере показано, как конвертировать презентацию ODP в презентацию PPTX.

``` cpp
// Путь к каталогу документов.
String dataDir = GetDataPath();

// Открыть файл ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Сохранение презентации ODP в формате PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```



## **Живой пример**
Вы можете посетить веб-приложение [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/), которое создано с помощью **Aspose.Slides API.** Приложение демонстрирует, как можно реализовать конвертацию ODP в PPTX с помощью Aspose.Slides API.