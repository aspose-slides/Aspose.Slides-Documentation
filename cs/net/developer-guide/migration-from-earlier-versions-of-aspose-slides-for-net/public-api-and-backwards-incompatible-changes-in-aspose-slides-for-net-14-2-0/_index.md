---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 14.2.0
linktitle: Aspose.Slides pro .NET 14.2.0
type: docs
weight: 40
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- migrace
- zastaralý kód
- moderní kód
- zastaralý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte aktualizace veřejného API a zásadní změny v Aspose.Slides pro .NET, abyste hladce migrovali svá řešení prezentací PowerPoint PPT, PPTX a ODP."
---
## **Veřejné API a zpětně nekompatibilní změny**
{{% alert color="info" %}} 

V API Aspose.Slides pro .NET 14.2.0 jsme provedli několik změn. Některé vlastnosti a metody byly odstraněny a některé byly přesunuty do jiného jmenného prostoru.

{{% /alert %}} 
### **Metody Aspose.Slides.IPresentation.Write(…) odstraněny**
Tyto metody zapisovaly objekty Presentation pouze do souboru ve formátu PPTX. V novém API třída Presentation slouží k práci se všemi formáty. Je možné použít metody Presentation.Save(…) k uložení objektů Presentation do všech podporovaných formátů.
### **Třídy související s motivovými styly přesunuty do jmenného prostoru Aspose.Slides.Theme**
Následující třídy byly přesunuty z jmenného prostoru Aspose.Slides do jmenného prostoru Aspose.Slides.Theme.

- Typy ColorScheme
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