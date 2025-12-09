---
title: Support .NET 6
type: docs
weight: 235
url: /fr/net/net6/
keywords:
- prise en charge .NET 6
- solution cloud
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "Configurez Aspose.Slides pour .NET 6 afin de créer, modifier et convertir des présentations PowerPoint PPT, PPTX et ODP dans des applications C# modernes et multiplateformes."
---

## Introduction

À partir de [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0), la prise en charge de .NET6 a été implémentée. La particularité de cette prise en charge est que .NET6 ne prend plus en charge System.Drawing.Common sous Linux ([modification majeure](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) et Slides implémente lui‑même ce sous‑système graphique sous forme de composant C++.

Aspose.Slides pour .NET fonctionne maintenant sans dépendances sur GDI/libgdiplus sur :
* Windows
* Linux

_Le support _MacOS_ est en cours.

## Utilisation de Slides pour .NET6 sur AWS et Azure

.NET6 est la version recommandée pour Aspose.Slides utilisée dans le cloud (AWS, Azure ou autres solutions cloud).

Auparavant, lorsque Aspose.Slides était utilisé sur un hôte Linux, des dépendances supplémentaires (libgdiplus) devaient être installées, ce qui était souvent gênant ou impraticable (par exemple, lors de l’utilisation d'[AWS Lambda](https://aws.amazon.com/lambda)). Avec Slides pour .NET6, ces dépendances ne sont plus nécessaires, ce qui rend le déploiement beaucoup plus simple.

Une autre considération concerne les problèmes survenus lorsqu'Aspose.Slides était utilisé sur une solution cloud avec un hôte Windows. Par exemple, les [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) ont des limitations pour le processus et entraînent des problèmes lors d’une opération d’exportation PDF (voir [ceci](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). L’utilisation d’Aspose.Slides pour .NET6 résout ce problème.

## Utilisation du package System.Drawing.Common et des classes Slides pour .NET6 (erreur CS0433 : le type existe à la fois dans Slides et dans System.Drawing.Common)

Parfois, les dépendances System.Drawing et Slides pour .NET6 doivent être utilisées dans un même projet (par exemple, lorsque le projet .NET6 dépend d’autres packages qui, à leur tour, dépendent de System.Drawing). Cela peut entraîner des erreurs de compilation comme les suivantes :

* CS0433 : le type 'Image' existe à la fois dans 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' et 'System.Drawing.Common, Version=6.0.0.0
* CS0433 : le type 'Graphics' existe à la fois dans 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' et 'System.Drawing.Common, Version=6.0.0.0

Dans ce cas, vous pouvez utiliser [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) pour Aspose.Slides (version antérieure à 24.8) :
1) Sélectionnez l’assembly Aspose.Slides dans les dépendances du projet, puis cliquez sur **Properties**.  
   ![Propriétés du package Aspose Slides](package_properties.png)
2) Définissez un alias (par exemple, « Slides »).  
   ![Alias Aspose Slides](set_alias.png)

Désormais, les types provenant de System.Drawing.Common seront utilisés par défaut. L’alias d’assembly externe doit être spécifié là où les types Aspose.Slides sont nécessaires.
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


À partir de la version 24.8, l’API publique obsolète avec des dépendances sur System.Drawing a été supprimée. Concernant l’exemple de code ci‑above, vous pouvez obtenir l’image de la diapositive comme suit.
```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```

La nouvelle API est décrite plus en détail dans la [Modern API](/net/modern-api/).