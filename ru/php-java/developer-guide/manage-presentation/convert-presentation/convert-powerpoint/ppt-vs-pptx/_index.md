---
title: PPT против PPTX
type: docs
weight: 10
url: /ru/php-java/ppt-vs-pptx/
keywords: "PPT против PPTX"
description: "Узнайте о различиях между PPT и PPTX в Aspose.Slides."
---

## **Что такое PPT?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) это бинарный формат файла, т.е. невозможно просмотреть его содержимое без специальных инструментов. Первые версии PowerPoint 97-2003 работали с форматом файлов PPT, однако его расширяемость ограничена.
## **Что такое PPTX?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) это новый формат презентации, основанный на стандарте Office Open XML (ISO 29500:2008-2016, ECMA-376). PPTX представляет собой архивированный набор XML и медиафайлов. Формат PPTX легко расширяется. Например, легко добавить поддержку нового типа диаграммы или формы, не меняя формат PPTX в каждой новой версии PowerPoint. Формат PPTX используется начиная с PowerPoint 2007.
## **PPT против PPTX**
Хотя PPTX предоставляет гораздо более широкие возможности, PPT остается довольно популярным. Необходимость конвертации из PPT в PPTX и наоборот высоко востребована.

Тем не менее, конвертация между старым форматом PPT и новым форматом PPTX является самой сложной задачей среди других форматов Microsoft Office. Хотя спецификация формата PPT открыта, с ним трудно работать. PowerPoint может создавать специальные части (MetroBlob) в файлах PPT для хранения информации из PPTX, которая не поддерживается форматом PPT и не может быть отображена в старых версиях PowerPoint. Эта информация может быть восстановлена, когда файл PPT загружается в современную версию PowerPoint или конвертируется в формат PPTX.

Aspose.Slides предоставляет общий интерфейс для работы со всеми форматами презентаций. Это позволяет конвертировать из PPT в PPTX и из PPTX в PPT очень простым способом. Aspose.Slides полностью поддерживает конвертацию из PPT в PPTX и также поддерживает конвертацию из PPTX в PPT с некоторыми ограничениями. Рекомендуем использовать формат PPTX, где это возможно.

{{% alert color="primary" %}} 

Проверьте качество конвертации PPT в PPTX и PPTX в PPT с помощью онлайн [**приложения Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

```php
  # Создайте объект Presentation, который представляет файл PPT
  $pres = new Presentation("PPTtoPPTX.ppt");
  try {
    # Сохранение презентации PPT в формате PPTX
    $pres->save("PPTtoPPTX_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
Читать далее [**Как конвертировать презентации PPT в PPTX**.](/slides/ru/php-java/convert-ppt-to-pptx/)
{{% /alert %}} 