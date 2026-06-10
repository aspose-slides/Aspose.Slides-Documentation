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
description: "Tekintse át a nyilvános API frissítéseket és a törésre okot adó változásokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
## **Nyilvános API és visszafelé nem kompatibilis változások**
{{% alert color="primary" %}} 

Az Aspose.Slides for .NET 14.2.0 API-jában néhány változtatást végeztünk. Néhány tulajdonság és metódus eltávolításra került, és egyesek más névtérbe kerültek.

{{% /alert %}} 
### **Az Aspose.Slides.IPresentation.Write(…) metódusok eltávolítva**
Ezek a metódusok csak PPTX formátumú fájlba írták a Presentation objektumokat. Az új API-ban a Presentation osztály minden formátummal való munkára szolgál. Lehetőség van a Presentation.Save(…) metódusok használatára a Presentation objektumok mentéséhez minden támogatott formátumba.
### **A téma stílusokkal kapcsolatos osztályok áthelyezve az Aspose.Slides.Theme névtérbe**
Az alábbi osztályok át lettek helyezve az Aspose.Slides névtérből az Aspose.Slides.Theme névtérbe.

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
### **Változások az Aspose.Slides for .NET 8.X.0 verziótól**
Az Aspose.Slides for .NET 8.4 funkciói hozzá lettek adva az Aspose.Slides for .NET 14.2.0-hoz.