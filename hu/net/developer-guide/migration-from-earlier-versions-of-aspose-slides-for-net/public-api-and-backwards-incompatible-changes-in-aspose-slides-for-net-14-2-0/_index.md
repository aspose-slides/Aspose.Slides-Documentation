---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 14.2.0-ban
linktitle: Aspose.Slides for .NET 14.2.0
type: docs
weight: 40
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for .NET nyilvános API frissítéseit és a romboló változásokat, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
## **Nyilvános API és visszafelé nem kompatibilis változások**
{{% alert color="info" %}} 

Változtatásokat hajtottunk végre az Aspose.Slides for .NET 14.2.0 API-jában. Néhány tulajdonság és metódus el lett távolítva, illetve néhány át lett helyezve egy másik névtérbe.

{{% /alert %}} 
### **Az Aspose.Slides.IPresentation.Write(…) metódusok eltávolítva**
Ezek a metódusok a Presentation objektumokat csak PPTX formátumú fájlba írták. Az új API-ban a Presentation osztály minden formátummal való munkához használható. A Presentation.Save(…) metódusokkal a Presentation objektumok menthetők minden támogatott formátumba.
### **A téma stílusokkal kapcsolatos osztályok áthelyezve az Aspose.Slides.Theme névtérbe**
Az alábbi osztályok át lettek helyezve az Aspose.Slides névtérből az Aspose.Slides.Theme névtérbe.

- Típusok ColorScheme
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
### **Változások az Aspose.Slides for .NET 8.X.0 verziótól**
Az Aspose.Slides for .NET 8.4 funkciói hozzá lettek adva az Aspose.Slides for .NET 14.2.0-hoz.