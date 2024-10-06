---
title: API Public et Changements Incompatibles avec les Versions Précédentes dans Aspose.Slides pour .NET 14.2.0
type: docs
weight: 40
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
---

## **API Public et Changements Incompatibles avec les Versions Précédentes**
{{% alert color="primary" %}} 

Nous avons apporté quelques changements dans l'API Aspose.Slides pour .NET 14.2.0. Certaines propriétés et méthodes ont été supprimées et d'autres ont été déplacées vers un autre espace de noms.

{{% /alert %}} 
### **Méthodes Aspose.Slides.IPresentation.Write(…) Supprimées**
Ces méthodes écrivaient des objets Presentation uniquement dans un fichier au format PPTX. Dans la nouvelle API, la classe Presentation est destinée à travailler avec tous les formats. Il est possible d'utiliser les méthodes Presentation.Save(…) pour enregistrer les objets Presentation dans tous les formats pris en charge.
### **Classes Liées aux Styles de Thème Déplacées vers l'Espace de Noms Aspose.Slides.Theme**
Les classes suivantes ont été déplacées de l'espace de noms Aspose.Slides vers l'espace de noms Aspose.Slides.Theme.

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
### **Changements d'Aspose.Slides pour .NET 8.X.0**
Les caractéristiques d'Aspose.Slides pour .NET 8.4 sont ajoutées à Aspose.Slides pour .NET 14.2.0