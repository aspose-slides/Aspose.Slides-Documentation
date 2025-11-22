---
title: Supprimer une diapositive d'une présentation
type: docs
weight: 30
url: /fr/net/remove-slide-from-presentation/
keywords: "Supprimer diapositive, Supprimer la diapositive, PowerPoint, Présentation, C#, Csharp, .NET, Aspose.Slides"
description: "Supprimer une diapositive d'un PowerPoint par référence ou indice en C# ou .NET"
---

Si une diapositive (ou son contenu) devient redondante, vous pouvez la supprimer. Aspose.Slides fournit la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) qui encapsule [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), qui est un référentiel pour toutes les diapositives d’une présentation. En utilisant des pointeurs (référence ou index) pour un objet [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) connu, vous pouvez spécifier la diapositive que vous souhaitez supprimer. 

## **Supprimer la diapositive par référence**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Obtenez une référence de la diapositive que vous souhaitez supprimer via son ID ou son Index.
3. Supprimez la diapositive référencée de la présentation.
4. Enregistrez la présentation modifiée. 

Ce code C# montre comment supprimer une diapositive via sa référence :
```c#
// Instancie un objet Presentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // Accède à une diapositive via son indice dans la collection de diapositives
    ISlide slide = pres.Slides[0];

    // Supprime une diapositive via sa référence
    pres.Slides.Remove(slide);

    // Enregistre la présentation modifiée
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Supprimer la diapositive par index**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Supprimez la diapositive de la présentation via sa position d’index.
3. Enregistrez la présentation modifiée. 

Ce code C# montre comment supprimer une diapositive via son index :
```c#
// Instancie un objet Presentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // Supprime une diapositive via son indice de diapositive
    pres.Slides.RemoveAt(0);

    // Enregistre la présentation modifiée
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Supprimer les diapositives de mise en page inutilisées**

Aspose.Slides fournit la méthode [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (de la classe [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) pour vous permettre de supprimer les diapositives de mise en page indésirables et non utilisées. Ce code C# montre comment supprimer une diapositive de mise en page d’une présentation PowerPoint :
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **Supprimer les diapositives maîtres inutilisées**

Aspose.Slides fournit la méthode [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la classe [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) pour vous permettre de supprimer les diapositives maîtres indésirables et non utilisées. Ce code C# montre comment supprimer une diapositive maître d’une présentation PowerPoint :
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Que se passe-t-il avec les index des diapositives après avoir supprimé une diapositive ?**

Après la suppression, la [collection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) se réindexe : chaque diapositive suivante se décale d’une position vers la gauche, les numéros d’index précédents deviennent donc obsolètes. Si vous avez besoin d’une référence stable, utilisez l’ID persistant de chaque diapositive plutôt que son index.

**L’ID d’une diapositive est‑il différent de son index, et change‑t‑il lorsque les diapositives voisines sont supprimées ?**

Oui. L’index correspond à la position de la diapositive et change lorsqu’on ajoute ou supprime des diapositives. L’ID de la diapositive est un identifiant persistant qui ne change pas lorsque d’autres diapositives sont supprimées.

**Comment la suppression d’une diapositive affecte‑t‑elle les sections de diapositives ?**

Si la diapositive appartenait à une section, cette section contiendra simplement une diapositive de moins. La structure de la section reste ; si une section devient vide, vous pouvez [supprimer ou réorganiser les sections](/slides/fr/net/slide-section/) selon les besoins.

**Que se passe‑t‑il avec les notes et les commentaires attachés à une diapositive lorsqu’elle est supprimée ?**

[Notes](/slides/fr/net/presentation-notes/) et [commentaires](/slides/fr/net/presentation-comments/) sont liés à cette diapositive spécifique et sont supprimés avec elle. Le contenu des autres diapositives n’est pas affecté.

**En quoi la suppression de diapositives diffère‑t‑elle du nettoyage des mises en page/maîtres inutilisés ?**

La suppression enlève des diapositives normales spécifiques du fichier. Le nettoyage des mises en page/maîtres inutilisés supprime les diapositives de mise en page ou maîtres qui ne sont référencées par aucune diapositive, réduisant ainsi la taille du fichier sans modifier le contenu des diapositives restantes. Ces actions sont complémentaires : généralement, on supprime d’abord les diapositives, puis on nettoie les mises en page/maîtres.