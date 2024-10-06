---
title: Prise en charge de .NET6
type: docs
weight: 235
url: /net/net6/
keywords: 
- .NET 6
- Cloud
- AWS
- Azure
description: "Prise en charge de .NET6"
---

## Introduction

À partir de [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0), la prise en charge de .NET6 a été mise en œuvre. La particularité de cette prise en charge est que .NET6 ne prend plus en charge System.Drawing.Common pour Linux ([changement de rupture](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) et Slides implémente ce sous-système graphique lui-même en tant que composant C++.

Aspose.Slides pour .NET fonctionne désormais sans dépendances sur GDI/libgdiplus sur :
* Windows
* Linux

Le support de _MacOS_ est en cours.

## Utilisation de Slides pour .NET6 sur AWS et Azure

.NET6 est la version préférée pour Aspose.Slides utilisée dans le cloud (AWS, Azure ou d'autres solutions cloud).

Auparavant, lorsque Aspose.Slides était utilisé sur un hôte Linux, des dépendances supplémentaires (libgdiplus) devaient être installées, ce qui était souvent peu pratique ou impraticable (par exemple, lors de l'utilisation de [AWS Lambda](https://aws.amazon.com/lambda)). Avec Slides pour .NET6, ces dépendances ne sont plus nécessaires, ce qui rend le déploiement beaucoup plus facile.

Une autre considération concerne les problèmes survenus lorsque Aspose.Slides était utilisé sur une solution cloud avec un hôte Windows. Par exemple, [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) ont des limitations pour le processus et entraînent des problèmes lors d'une opération d'exportation PDF (voir [cela](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). L'utilisation d'Aspose.Slides pour .NET6 résout ce problème.

## Utilisation du package System.Drawing.Common et des classes Slides pour .NET6 (CS0433 : Le type existe à la fois dans Slides et System.Drawing.Common erreur)

Parfois, les dépendances System.Drawing et Slides pour .NET6 doivent être utilisées dans un projet (par exemple, lorsque le projet .NET6 dépend d'autres packages, qui dépendent à leur tour de System.Drawing). Cela peut provoquer des erreurs de complication comme celles-ci :

* CS0433 : Le type 'Image' existe à la fois dans 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' et 'System.Drawing.Common, Version=6.0.0.0'
* CS0433 : Le type 'Graphics' existe à la fois dans 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' et 'System.Drawing.Common, Version=6.0.0.0'

Dans ce cas, vous pouvez utiliser [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) pour Aspose.Slides (version inférieure à 24.8) :
1) Sélectionnez l'assembly Aspose.Slides dans les dépendances du projet, puis cliquez sur **Propriétés**.
  ![Propriétés du package Aspose Slides](package_properties.png)
2) Définissez un alias (par exemple, "Slides").
  ![Alias Aspose Slides](set_alias.png)

Maintenant, les types de System.Drawing.Common seront utilisés par défaut. L'alias d'assemblage externe doit être spécifié là où les types Aspose.Slides sont nécessaires.

```c#
extern alias Slides;
using Slides::Aspose.Slides;
```

Exemple complet :

```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```

À partir de la version 24.8, l'API publique obsolète avec des dépendances sur System.Drawing a été supprimée. Concernant l'exemple de code ci-dessus, vous pouvez obtenir l'image de la diapositive comme suit.

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
La nouvelle API est décrite plus en détail dans [API moderne](/net/modern-api/).