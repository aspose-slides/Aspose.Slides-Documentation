---
title: Comparer des Diapositives
type: docs
weight: 50
url: /net/compare-slides/
keywords: "Comparer des diapositives PowerPoint, Comparer deux diapositives, Présentation, C#, Csharp, .NET, Aspose.Slides"
description: "Comparer des diapositives de présentation PowerPoint en C# ou .NET"
---

## **Comparer Deux Diapositives**
La méthode Equals a été ajoutée à l'interface [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) et à la classe [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide). Elle renvoie true pour les diapositives/layout et les diapositives/diapositives maîtres qui sont identiques par leur structure et leur contenu statique.

Deux diapositives sont égales si toutes les formes, styles, textes, animations et autres paramètres, etc. sont identiques. La comparaison ne prend pas en compte les valeurs d'identifiant unique, par exemple, SlideId et le contenu dynamique, par exemple, la valeur de la date actuelle dans le champ de date.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} est égal à SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```