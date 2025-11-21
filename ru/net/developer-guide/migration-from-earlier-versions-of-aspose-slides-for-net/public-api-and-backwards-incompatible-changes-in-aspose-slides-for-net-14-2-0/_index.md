---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 14.2.0
linktitle: Aspose.Slides для .NET 14.2.0
type: docs
weight: 40
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- миграция
- унаследованный код
- современный код
- унаследованный подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Изучите обновления публичного API и критические изменения в Aspose.Slides для .NET, чтобы плавно мигрировать решения для презентаций PowerPoint PPT, PPTX и ODP."
---

## **Публичный API и несовместимые изменения, нарушающие обратную совместимость**
{{% alert color="primary" %}} 

Мы внесли некоторые изменения в API Aspose.Slides для .NET 14.2.0. Некоторые свойства и методы были удалены, а некоторые перемещены в другое пространство имён.

{{% /alert %}} 
### **Методы Aspose.Slides.IPresentation.Write(…) удалены**
Эти методы сохраняли объекты Presentation только в файл формата PPTX. В новом API класс Presentation предназначен для работы со всеми форматами. Можно использовать методы Presentation.Save(…) для сохранения объектов Presentation во всех поддерживаемых форматах.
### **Классы, связанные со стилями тем, перемещены в пространство имён Aspose.Slides.Theme**
Следующие классы были перемещены из пространства имён Aspose.Slides в пространство имён Aspose.Slides.Theme.

- Types ColorScheme
- EffectStyle
- EffectStyleCollection
- EffectStyleCollectionEffectiveData
- ExtraColorSchemeCollection
- ExtraColorSchemeCollection
- ExtraColorScheme
- FillFormatCollection
- FillFormatCollectionEffectiveData
- FontScheme
- FontSchemeEffectiveData
- FormatScheme
- IColorScheme
- IEffectStyle
- IEffectStyleCollection
- IEffectStyleCollectionEffectiveData
- IEffectStyleEffectiveData
- IExtraColorScheme
- IExtraColorSchemeCollection
- IFillFormatCollection
- IFillFormatCollectionEffectiveData
- IFontScheme
- IFontSchemeEffectiveData
- IFormatScheme
- ILineFormatCollection
- ILineFormatCollectionEffectiveData
### **Изменения с версии Aspose.Slides для .NET 8.X.0**
Функции Aspose.Slides для .NET 8.4 добавлены в Aspose.Slides для .NET 14.2.0