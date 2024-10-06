---
title: Comment ajouter un en-tête et un pied de page dans une présentation
type: docs
weight: 20
url: /net/how-to-add-header-footer-in-a-presentation/
---

{{% alert color="primary" %}} 

Une nouvelle [Aspose.Slides for .NET API](/slides/net/) a été publiée et maintenant ce produit unique prend en charge la capacité de générer des documents PowerPoint à partir de zéro et de modifier ceux existants.

{{% /alert %}} 
## **Support pour le code hérité**
Pour utiliser le code hérité développé avec les versions d'Aspose.Slides for .NET antérieures à 13.x, vous devez apporter quelques modifications mineures à votre code et celui-ci fonctionnera comme auparavant. Toutes les classes qui étaient présentes dans l'ancienne Aspose.Slides for .NET sous les espaces de noms Aspose.Slide et Aspose.Slides.Pptx sont désormais fusionnées dans le seul espace de noms Aspose.Slides. Veuillez consulter l'extrait de code simple suivant pour ajouter un en-tête et un pied de page dans une présentation dans l'API Aspose.Slides héritée et suivre les étapes décrivant comment migrer vers la nouvelle API fusionnée.
## **Approche Aspose.Slides for .NET héritée**
```c#
PresentationEx sourcePres = new PresentationEx();

//Définir les propriétés de visibilité de l'en-tête et du pied de page
sourcePres.UpdateSlideNumberFields = true;

//Mettre à jour les champs de date et d'heure
sourcePres.UpdateDateTimeFields = true;

//Afficher le champ de date et d'heure
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Afficher le champ de pied de page
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Afficher le numéro de la diapositive
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Définir la visibilité de l'en-tête et du pied de page sur la diapositive de titre
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Écrire la présentation sur le disque
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
hf.HeaderText = "Texte de l'en-tête";

//Définir le texte du pied de page
hf.FooterText = "Texte du pied de page";

//Écrire la présentation sur le disque
pres.Write("HeadFoot.ppt");
```



## **Nouvelle approche Aspose.Slides for .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Définir les propriétés de visibilité de l'en-tête et du pied de page
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Mettre à jour les champs de date et d'heure
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Afficher le champ de date et d'heure
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Afficher le champ de pied de page
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Définir la visibilité de l'en-tête et du pied de page sur toutes les diapositives de titre
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Écrire la présentation sur le disque
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```