---
title: Comment ajouter des en-têtes et pieds de page aux présentations en .NET
linktitle: Ajouter en-tête & pied de page
type: docs
weight: 20
url: /fr/net/how-to-add-header-footer-in-a-presentation/
keywords:
- migration
- ajouter en-tête
- ajouter pied de page
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
description: "Apprenez à ajouter des en-têtes et des pieds de page aux présentations PowerPoint PPT, PPTX et ODP en .NET en utilisant les API Aspose.Slides legacy et modernes."
---

{{% alert color="primary" %}} 
Une nouvelle [Aspose.Slides for .NET API](/slides/fr/net/) a été publiée et ce produit unique prend désormais en charge la génération de documents PowerPoint à partir de zéro ainsi que la modification des documents existants.
{{% /alert %}} 
## **Prise en charge du code hérité**
Pour utiliser le code hérité développé avec les versions d'Aspose.Slides pour .NET antérieures à 13.x, vous devez apporter quelques modifications mineures à votre code et celui‑ci fonctionnera comme précédemment. Toutes les classes qui existaient dans l'ancienne version d'Aspose.Slides pour .NET sous les espaces de noms Aspose.Slide et Aspose.Slides.Pptx sont désormais fusionnées dans un seul espace de noms Aspose.Slides. Veuillez consulter le fragment de code simple suivant pour ajouter un en‑tête et un pied de page à une présentation dans l'API legacy d'Aspose.Slides et suivre les étapes décrivant comment migrer vers la nouvelle API fusionnée.
## **Approche legacy d'Aspose.Slides pour .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Définition des propriétés de visibilité des en-têtes et pieds de page
sourcePres.UpdateSlideNumberFields = true;

//Mettre à jour les champs de date et d'heure
sourcePres.UpdateDateTimeFields = true;

//Afficher le texte de remplacement de la date et l'heure
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Afficher le texte de remplacement du pied de page
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Afficher le numéro de diapositive
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Définir la visibilité des en-têtes et pieds de page sur la diapositive de titre
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Enregistrer la présentation sur le disque
sourcePres.Write("NewSource.pptx");
```

```c#
//Créer la présentation
Presentation pres = new Presentation();

//Obtenir la première diapositive
Slide sld = pres.GetSlideByPosition(1);

//Accéder à l'en-tête / pied de page de la diapositive
HeaderFooter hf = sld.HeaderFooter;

//Définir la visibilité du numéro de page
hf.PageNumberVisible = true;

//Définir la visibilité du pied de page
hf.FooterVisible = true;

//Définir la visibilité de l'en-tête
hf.HeaderVisible = true;

//Définir la visibilité de la date et de l'heure
hf.DateTimeVisible = true;

//Définir le format de la date et de l'heure
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Définir le texte de l'en-tête
hf.HeaderText = "Header Text";

//Définir le texte du pied de page
hf.FooterText = "Footer Text";

//Enregistrer la présentation sur le disque
pres.Write("HeadFoot.ppt");
```


## **Nouvelle approche d'Aspose.Slides pour .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Définition des propriétés de visibilité des en-têtes et pieds de page
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Mettre à jour les champs Date et Heure
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Afficher le champ de texte de remplacement de la date et de l'heure
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Afficher le champ de texte de remplacement du pied de page
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Définir la visibilité des en-têtes et pieds de page sur la diapositive de titre
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Enregistrer la présentation sur le disque
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
