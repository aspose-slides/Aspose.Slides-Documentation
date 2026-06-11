---
title: Publiczny API i zmiany niekompatybilne wstecz w Aspose.Slides for .NET 14.2.0
linktitle: Aspose.Slides for .NET 14.2.0
type: docs
weight: 40
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- migracja
- kod legacy
- kod nowoczesny
- podejście legacy
- podejście nowoczesne
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API i zmiany łamiące w Aspose.Slides for .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
## **Publiczny API i zmiany niekompatybilne wstecz**
{{% alert color="primary" %}} 

Wprowadziliśmy pewne zmiany w API Aspose.Slides for .NET 14.2.0. Niektóre właściwości i metody zostały usunięte, a niektóre przeniesiono do innej przestrzeni nazw.

{{% /alert %}} 
### **Metody Aspose.Slides.IPresentation.Write(…) usunięte**
Te metody zapisywały obiekty Presentation wyłącznie do pliku w formacie PPTX. W nowym API klasa Presentation służy do pracy ze wszystkimi formatami. Można używać metod Presentation.Save(…) do zapisywania obiektów Presentation we wszystkich obsługiwanych formatach.
### **Klasy związane ze stylami motywu przeniesiono do przestrzeni nazw Aspose.Slides.Theme**
Poniższe klasy zostały przeniesione z przestrzeni nazw Aspose.Slides do przestrzeni nazw Aspose.Slides.Theme.

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
### **Zmiany od Aspose.Slides for .NET 8.X.0**
Funkcje Aspose.Slides for .NET 8.4 zostały dodane do Aspose.Slides for .NET 14.2.0