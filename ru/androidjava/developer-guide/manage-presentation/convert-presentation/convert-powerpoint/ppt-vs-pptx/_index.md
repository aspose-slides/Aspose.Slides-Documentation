---
title: PPT против PPTX
type: docs
weight: 10
url: /ru/androidjava/ppt-vs-pptx/
keywords: "PPT против PPTX"
description: "Читать о различиях между PPT и PPTX в Aspose.Slides."
---

## **Что такое PPT?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) — это бинарный файловый формат, то есть его содержимое невозможно просмотреть без специальных инструментов. Первые версии PowerPoint 97-2003 работали с форматом файлов PPT, однако его расширяемость ограничена.

## **Что такое PPTX?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) — это новый формат файлов презентаций, основанный на стандарте Office Open XML (ISO 29500:2008-2016, ECMA-376). PPTX представляет собой архивированный набор XML и медиафайлов. Формат PPTX легко расширяем. Например, легко добавить поддержку нового типа графика или типа формы, не изменяя формат PPTX в каждой новой версии PowerPoint. Формат PPTX используется начиная с PowerPoint 2007.

## **PPT против PPTX**
Несмотря на то, что PPTX предоставляет гораздо более широкий функционал, PPT по-прежнему остается довольно популярным. Необходимость конвертации из PPT в PPTX и наоборот очень высока.

Однако конвертация между старым форматом PPT и новым форматом PPTX является самым сложным вызовом среди других форматов Microsoft Office. Хотя спецификация формата PPT открыта, с ним сложно работать. PowerPoint может создавать специальные части (MetroBlob) в файлах PPT для хранения информации из PPTX, которая не поддерживается форматом PPT и не может быть отображена в старых версиях PowerPoint. Эта информация может быть восстановлена, когда файл PPT загружен в современную версию PowerPoint или конвертирован в формат PPTX.

Aspose.Slides предоставляет общий интерфейс для работы со всеми форматами презентаций. Он позволяет конвертировать из PPT в PPTX и из PPTX в PPT очень простым способом. Aspose.Slides полностью поддерживает конвертацию из PPT в PPTX, а также поддерживает конвертацию из PPTX в PPT с некоторыми ограничениями. Мы рекомендуем использовать формат PPTX, где это возможно.

{{% alert color="primary" %}} 

Проверьте качество конвертации PPT в PPTX и PPTX в PPT с помощью онлайн-приложения [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

```java
// Создаем объект презентации, представляющий файл PPT
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// Сохранение презентации PPT в формате PPTX
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Читать далее [**Как конвертировать презентации PPT в PPTX**.](/slides/ru/androidjava/convert-ppt-to-pptx/)
{{% /alert %}} 