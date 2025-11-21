---
title: API publique et changements incompatibles rétroactifs dans Aspose.Slides pour .NET 14.2.0
linktitle: Aspose.Slides pour .NET 14.2.0
type: docs
weight: 40
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Examinez les mises à jour de l'API publique et les changements majeurs dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---

## **API publique et changements incompatibles rétroactifs**
{{% alert color="primary" %}} 

Nous avons apporté des modifications à l’API Aspose.Slides pour .NET 14.2.0. Certaines propriétés et méthodes ont été supprimées et d’autres ont été déplacées vers d’autres espaces de noms.

{{% /alert %}} 
### **Méthodes Aspose.Slides.IPresentation.Write(…) supprimées**
Ces méthodes écrivaient les objets Presentation uniquement au format de fichier PPTX. Dans la nouvelle API, la classe Presentation sert à travailler avec tous les formats. Il est possible d’utiliser les méthodes Presentation.Save(…) pour enregistrer les objets Presentation dans tous les formats pris en charge.
### **Classes liées aux styles de thème déplacées vers l’espace de noms Aspose.Slides.Theme**
Les classes suivantes ont été déplacées de l’espace de noms Aspose.Slides vers l’espace de noms Aspose.Slides.Theme.

- Type ColorScheme
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
### **Modifications depuis Aspose.Slides pour .NET 8.X.0**
Les fonctionnalités d’Aspose.Slides pour .NET 8.4 ont été ajoutées à Aspose.Slides pour .NET 14.2.0