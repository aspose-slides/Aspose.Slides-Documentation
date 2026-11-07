---
title: Séquence de sélection de polices dans Aspose.Slides pour .NET
linktitle: Sélection de polices
type: docs
weight: 80
url: /fr/net/font-selection-sequence/
keywords:
- sélection de polices
- substitution de police
- remplacement de police
- règle de substitution
- police disponible
- police manquante
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour .NET sélectionne les polices, garantissant une présentation nette et cohérente des fichiers PPT, PPTX et ODP—améliorez vos diapositives dès maintenant."
---
## **Aperçu**

Lorsqu’une présentation est chargée, rendue ou convertie dans un autre format, Aspose.Slides prend en compte ses polices intégrées et les polices disponibles pour l’application. Si une police requise est indisponible, Aspose.Slides sélectionne une police de substitution aussi proche que possible de celle que PowerPoint utiliserait.

Les polices disponibles peuvent inclure les polices système, les polices chargées par l’application et les polices intégrées dans la présentation. Pour une police intégrée et enregistrée correspondante, la préférence .NET 26.11 décrite ci‑dessous contrôle celle qui prime. Les règles de substitution de police définies via [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) sont un mécanisme séparé.

Vous pouvez également ajouter des polices à l’exécution de l’application, utiliser les polices intégrées d’une présentation ou charger des polices externes pour les documents de sortie tels que les fichiers PDF.

## **Sélection des polices**

Le texte peut référencer une police de thème, telle que `+mn-lt`, plutôt qu’un nom de famille explicite. Voir [Résoudre les références de police de thème](/slides/fr/net/presentation-theme/#resolve-theme-font-references) pour obtenir la famille spécifiée par le thème applicable. La résolution de cette référence est distincte de la vérification de la disponibilité des polices et de l’application d’une substitution au moment du rendu ou d’un repli de glyphe ; elle n’identifie pas le fichier de police réellement utilisé pour rendre le texte.

Lors du rendu des diapositives ou de la conversion d’une présentation, vérifiez que les polices demandées sont intégrées ou disponibles à partir des sources enregistrées. Les polices manquantes peuvent nécessiter un remplacement ou une substitution ; voir [**Remplacement de police**](/slides/fr/net/font-replacement/) et [**Substitution de police**](/slides/fr/net/font-substitution/).

Lors de l’investigation de la sélection des polices :

1. Résoudre la famille et le style demandés, y compris toute référence de thème.  
2. Vérifier les polices intégrées et les sources enregistrées, y compris les polices système et les polices chargées par l’application. Utilisez la préférence ci‑dessous lorsque les versions intégrées et enregistrées correspondantes sont en concurrence.  
3. Examiner les [règles de substitution de police](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) et le repli de glyphe si la police ou les caractères demandés sont indisponibles.

Aspose.Slides vous permet d’ajouter des polices à l’exécution de l’application puis d’utiliser ces polices. Voir [**Polices personnalisées**](/slides/fr/net/custom-font/).

Lorsque des polices supplémentaires sont placées dans une présentation, elles sont appelées [**Polices intégrées**](/slides/fr/net/embedded-font/).

Aspose.Slides vous permet d’ajouter des polices qui sont appliquées *uniquement* aux documents de sortie. Par exemple, si une présentation que vous souhaitez convertir en PDF contient des polices manquantes sur votre système et parmi les polices intégrées, vous pouvez ajouter ou charger les polices nécessaires en tant que **polices externes**. 

{{% alert title="Note" color="info" %}} 
Nous ne distribuons aucune police, qu’elle soit payante ou gratuite. Notre API vous permet de charger des polices externes et de les intégrer dans les documents, mais vous le faites avec les polices à votre discrétion et sous votre responsabilité.
{{% /alert %}}

## **Préférer les polices enregistrées aux polices intégrées**

À partir de .NET 26.11, [IFontsManager.PreferRegisteredFontsOverEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/preferregisteredfontsoverembedded/) permet à une police enregistrée correspondante de prendre le pas sur une police intégrée lors de l’exportation. La valeur par défaut est `false`. La correspondance utilise le nom et le style de la police ; un nom de famille différent ne constitue pas une correspondance de remplacement. Les polices enregistrées peuvent provenir du système ou [sources de polices chargées explicitement](/slides/fr/net/custom-font/).

L’exemple suivant utilise le package **Aspose.Slides.NET6.CrossPlatform 26.11** sur .NET 8. Suivez le [guide d'installation](/slides/fr/net/installation/) pour votre environnement. Fournissez `embedded-fonts.pptx` contenant une police intégrée et `preferred.ttf` avec le même nom de famille et style. Les deux fichiers de police doivent différer visiblement si vous voulez comparer le résultat.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var fontBytes = File.ReadAllBytes("preferred.ttf");
FontsLoader.LoadExternalFont(fontBytes);
using var presentation = new Presentation("embedded-fonts.pptx");

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("embedded-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = true;
presentation.Save("registered-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("restored-preference.pdf", SaveFormat.Pdf);
```

Ce paramètre modifie la priorité des polices lors de l’exportation ; il ne renomme pas la police du texte, ne supprime pas les données de police intégrées ni ne réintègre le fichier enregistré. C’est un paramètre d’exécution : réglez-le de nouveau après avoir rouvert une présentation. Si aucune police enregistrée correspondante n’est disponible, l’activation de la préférence n’en fournit pas ; vérifiez la police et la mise en page résultantes dans votre environnement cible.

Les sorties PNG et PDF avec des polices régulières explicitement chargées ont été vérifiées pour la configuration ci‑dessus. Vérifiez vos propres fichiers de police, styles, version du SDK et formats de sortie avant de compter sur des résultats identiques. Les métriques des polices peuvent modifier les sauts de ligne et le positionnement. Utilisez [remplacement de police](/slides/fr/net/font-replacement/) ou [substitution](/slides/fr/net/font-substitution/) lorsque vous avez besoin d’une famille différente, et [opérations sur les polices intégrées](/slides/fr/net/embedded-font/) lorsque vous devez modifier les polices stockées dans la présentation.

## **FAQ**

**Comment déterminer quelles polices sont réellement utilisées dans une présentation avant la conversion ?**

Aspose.Slides vous permet d’inspecter les polices utilisées via le [gestionnaire de polices](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/), afin de décider si vous devez [intégrer](/slides/fr/net/embedded-font/), [remplacer](/slides/fr/net/font-replacement/) ou ajouter des [sources externes](/slides/fr/net/custom-font/). Cela vous aide à éviter les substitutions indésirables lors du rendu et de l’exportation.

**Puis-je ajouter des répertoires de polices supplémentaires sans les installer sur le système d’exploitation ?**

Oui. Vous pouvez enregistrer des [sources de polices externes](/slides/fr/net/custom-font/) telles que des dossiers ou des flux en mémoire pour le rendu et l’exportation. Cela élimine la dépendance aux polices du système hôte et garde la mise en page prévisible.

**Comment empêcher un repli silencieux vers une police inadaptée lorsqu’un glyphe est manquant ?**

Définissez à l’avance des [remplacements de police](/slides/fr/net/font-replacement/) explicites et des [règles de repli de police](/slides/fr/net/fallback-font/). En analysant les polices utilisées et en fixant une priorité contrôlée pour les substituts, vous assurez une typographie cohérente et évitez des résultats inattendus.