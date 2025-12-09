---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 14.2.0
linktitle: Aspose.Slides для .NET 14.2.0
type: docs
weight: 40
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- миграция
- наследуемый код
- современный код
- наследуемый подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides для .NET, позволяющий плавно мигрировать ваши решения презентаций PowerPoint PPT, PPTX и ODP."
---

## **Публичный API и изменения, несовместимые с предыдущими версиями**
{{% alert color="primary" %}} 
Мы внесли изменения в API Aspose.Slides для .NET 14.2.0. Некоторые свойства и методы были удалены, а некоторые перемещены в другое пространство имён.
{{% /alert %}} 
### **Методы Aspose.Slides.IPresentation.Write(…) удалены**
Эти методы сохраняли объекты Presentation только в файл формата PPTX. В новом API класс Presentation предназначен для работы со всеми форматами. Можно использовать методы Presentation.Save(…) для сохранения объектов Presentation во все поддерживаемые форматы.
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
### **Изменения с Aspose.Slides для .NET 8.X.0**
Функциональность Aspose.Slides для .NET 8.4 добавлена в Aspose.Slides для .NET 14.2.0