---
title: "Comparer les diapositives"
type: docs
weight: 50
url: /fr/net/compare-slides/
keywords: "Comparer les diapositives PowerPoint, Comparer deux diapositives, Présentation, C#, Csharp, .NET, Aspose.Slides"
description: "Comparer les diapositives d’une présentation PowerPoint en C# ou .NET"
---

## **Comparer deux diapositives**
La méthode Equals a ete ajoutee a l'interface [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) et a la classe [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide). Elle renvoie true pour les diapositives/maquettes et les diapositives maitre qui sont identiques par leur structure et leur contenu statique.

Deux diapositives sont egales si toutes les formes, styles, textes, animations et autres parametres, etc. sont identiques. La comparaison ne tient pas compte des valeurs d'identifiants uniques, par exemple SlideId, ni du contenu dynamique, par exemple la valeur de date actuelle dans le champ de texte Date.
```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```


## **FAQ**

**Le fait qu'une diapositive soit masquee affecte-t-il la comparaison des diapositives elles-elles ?**

[Hidden status](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) est une propriete au niveau de la presentation/lecture, pas un contenu visuel. L'egalite de deux diapositives specifiques est determinee par leur structure et leur contenu statique ; le simple fait qu'une diapositive soit masquee ne rend pas les diapositives differentes.

**Les hyperliens et leurs paramètres sont-ils pris en compte ?**

Oui. Les liens font partie du contenu statique d'une diapositive. Si l'URL ou l'action du hyperlien differe, cela est generally considere comme une difference dans le contenu statique.

**Si un graphe fait reference a un fichier Excel externe, le contenu de ce fichier sera-t-il pris en compte ?**

Non. La comparaison est effectuee en se basant sur les diapositives elles-memes. Les sources de donnees externes ne sont generally pas lues au moment de la comparaison ; seulement ce qui est present dans la structure et l'etat statique de la diapositive est considere.