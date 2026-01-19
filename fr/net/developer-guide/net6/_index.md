---
title: Support .NET 6
type: docs
weight: 235
url: /fr/net/net6/
keywords:
- Support .NET 6
- Solution cloud
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

## **Introduction**

À partir de [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0), la prise en charge de .NET6 a été implémentée. La particularité de cette prise en charge est que .NET6 ne supporte plus System.Drawing.Common sous Linux ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) et Slides implémente lui-même ce sous‑système graphique en tant que composant C++.

Aspose.Slides for .NET fonctionne désormais sans dépendances sur GDI/libgdiplus sur :
* Windows
* Linux

Le support _MacOS_ est en cours.

## **Utilisation de Slides pour .NET 6 sur AWS et Azure**

.NET6 est la version préférée pour Aspose.Slides utilisé dans le cloud (AWS, Azure ou d’autres solutions cloud).

Auparavant, lorsque Aspose.Slides était utilisé sur un hôte Linux, des dépendances supplémentaires (libgdiplus) devaient être installées, ce qui était souvent contraignant ou impraticable (par exemple, lors de l’utilisation de [AWS Lambda](https://aws.amazon.com/lambda)). Avec Slides pour .NET6, ces dépendances ne sont plus nécessaires, ce qui simplifie grandement le déploiement.

Une autre considération concerne les problèmes qui survenaient lorsque Aspose.Slides était utilisé sur une solution cloud avec un hôte Windows. Par exemple, les [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) imposent des limites au processus et entraînent des problèmes lors d’une opération d’exportation PDF (voir [this](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). L’utilisation d’Aspose.Slides pour .NET6 résout ce problème.

## **Utilisation du package System.Drawing.Common et des classes Slides pour .NET 6 (CS0433: The Type Exists in Both Slides and System.Drawing.Common Error)**

Parfois, les deux dépendances System.Drawing et Slides pour .NET6 doivent être utilisées dans un projet (par exemple, lorsque le projet .NET6 dépend d’autres packages qui, à leur tour, dépendent de System.Drawing). Cela peut entraîner des erreurs de complication telles que :
* CS0433: The type 'Image' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0
* CS0433: The type 'Graphics' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0

Dans ce cas, vous pouvez utiliser [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) pour Aspose.Slides (version antérieure à 24.8) :
1) Sélectionnez l’assembly Aspose.Slides parmi les dépendances du projet, puis cliquez sur **Properties**.
  ![Aspose Slides package properties](package_properties.png)
2) Définissez un alias (par exemple, "Slides").
  ![Aspose Slides alias](set_alias.png)

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


À partir de la version 24.8, l’API publique dépréciée dépendante de System.Drawing a été supprimée. Concernant l’exemple de code ci‑above, vous pouvez obtenir l’image de la diapositive comme suit.
```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```

La nouvelle API est décrite plus en détail dans [Modern API](/slides/fr/net/modern-api/).