---
title: Obtenir des rappels d'avertissement pour la substitution de polices dans Aspose.Slides
type: docs
weight: 120
url: /fr/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides pour .NET permet d'obtenir des rappels d'avertissement pour la substitution de polices dans le cas où la police utilisée n'est pas disponible sur la machine pendant le processus de rendu. Les rappels d'avertissement sont utiles pour déboguer les problèmes de polices manquantes ou inaccessibles pendant le processus de rendu.

{{% /alert %}} 
## **Obtenir des rappels d'avertissement pour la substitution de polices**
Aspose.Slides pour .NET fournit des méthodes API simples pour obtenir les rappels d'avertissement pendant le processus de rendu. Tout ce que vous avez à faire est de suivre les étapes ci-dessous pour configurer les rappels d'avertissement de votre côté :

1. Créer une classe de rappel personnalisée pour recevoir les rappels.
1. Définir les rappels d'avertissement en utilisant la classe LoadOptions.
1. Charger le fichier de présentation qui utilise une police pour le texte à l'intérieur qui n'est pas disponible sur votre machine cible.
1. Générer la miniature de la diapositive pour voir l'effet.

```c#
//Configuration des rappels d'avertissement
LoadOptions lo = new LoadOptions();
lo.WarningCallback = new HandleFontsWarnings();

//Instancier la présentation
Presentation presentation = new Presentation("1.ppt", lo);

//Génération de la miniature de la diapositive
foreach (ISlide slide in presentation.Slides)
{
    IImage image = slide.GetImage();
}
```

```c#
class HandleFontsWarnings : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        Console.WriteLine(warning.WarningType); // 1 - WarningType.DataLoss
        Console.WriteLine(warning.Description); // "La police sera substituée de X à Y"
        return ReturnAction.Continue;
    }
}
```