---
title: Общий API и обратно несовместимые изменения в Aspose.Slides для .NET 14.2.0
type: docs
weight: 40
url: /ru/net/obshchiy-api-i-obratno-nesovmestimyye-izmeneniya-v-aspose-slides-dlya-net-14-2-0/
---

## **Общий API и обратно несовместимые изменения**
{{% alert color="primary" %}} 

Мы внесли некоторые изменения в API Aspose.Slides для .NET 14.2.0. Некоторые свойства и методы были удалены, а некоторые были перемещены в другое пространство имен.

{{% /alert %}} 
### **Методы Aspose.Slides.IPresentation.Write(…) Удалены**
Эти методы записывали объекты Presentation только в файл формата PPTX. В новом API класс Presentation предназначен для работы со всеми форматами. Теперь можно использовать методы Presentation.Save(…) для сохранения объектов Presentation во все поддерживаемые форматы.
### **Классы, связанные со стилями темы, перемещены в пространство имен Aspose.Slides.Theme**
Следующие классы были перемещены из пространства имен Aspose.Slides в пространство имен Aspose.Slides.Theme.

- Типы ColorScheme
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
Функции Aspose.Slides для .NET 8.4 добавлены в Aspose.Slides для .NET 14.2.0