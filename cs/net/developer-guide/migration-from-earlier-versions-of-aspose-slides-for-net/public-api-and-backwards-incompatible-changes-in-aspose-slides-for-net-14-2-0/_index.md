---
title: Veřejné API a nekompatibilní změny v Aspose.Slides pro .NET 14.2.0
linktitle: Aspose.Slides pro .NET 14.2.0
type: docs
weight: 40
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte aktualizace veřejného API a nekompatibilní změny v Aspose.Slides pro .NET, abyste hladce migrovali vaše řešení pro prezentace PowerPoint PPT, PPTX a ODP."
---
## **Veřejné API a nekompatibilní změny**
{{% alert color="primary" %}} 

Provedli jsme některé změny v API Aspose.Slides pro .NET 14.2.0. Některé vlastnosti a metody byly odstraněny a některé byly přesunuty do jiného jmenného prostoru.

{{% /alert %}} 
### **Metody Aspose.Slides.IPresentation.Write(…) odstraněny**
Tyto metody ukládaly objekty Presentation pouze do souboru ve formátu PPTX. V novém API je třída Presentation určena pro práci se všemi formáty. Je možné použít metody Presentation.Save(…) k uložení objektů Presentation do všech podporovaných formátů.
### **Třídy související s motivovými styly přesunuty do jmenného prostoru Aspose.Slides.Theme**
Následující třídy byly přesunuty z jmenného prostoru Aspose.Slides do jmenného prostoru Aspose.Slides.Theme.

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
### **Změny od Aspose.Slides pro .NET 8.X.0**
Funkce Aspose.Slides pro .NET 8.4 byly přidány do Aspose.Slides pro .NET 14.2.0