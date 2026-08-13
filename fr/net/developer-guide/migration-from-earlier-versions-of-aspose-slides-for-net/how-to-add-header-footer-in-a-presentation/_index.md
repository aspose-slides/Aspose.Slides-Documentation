---
title: Comment ajouter des en-têtes et pieds de page aux présentations en .NET
linktitle: Ajouter un en-tête et un pied de page
type: docs
weight: 20
url: /fr/net/how-to-add-header-footer-in-a-presentation/
keywords:
- migration
- ajouter un en-tête
- ajouter un pied de page
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
description: "Apprenez comment ajouter des en-têtes et des pieds de page aux présentations PowerPoint PPT, PPTX et ODP en .NET en utilisant les API Aspose.Slides héritées et modernes."
---
{{% alert color="info" %}} 
Une nouvelle [Aspose.Slides for .NET API](/slides/fr/net/) a été publiée et ce produit unique prend désormais en charge la génération de documents PowerPoint à partir de zéro ainsi que la modification des documents existants.
{{% /alert %}} 
## **Support du code hérité**
Pour utiliser le code hérité développé avec les versions d’Aspose.Slides for .NET antérieures à 13.x, vous devez apporter quelques modifications mineures à votre code et celui‑ci fonctionnera comme auparavant. Toutes les classes présentes dans l’ancienne Aspose.Slides for .NET sous les espaces de noms Aspose.Slide et Aspose.Slides.Pptx sont désormais fusionnées dans un seul espace de noms Aspose.Slides. Veuillez examiner le fragment de code simple suivant pour ajouter un en‑tête et un pied de page à une présentation dans l’API Aspose.Slides héritée et suivre les étapes décrivant comment migrer vers la nouvelle API fusionnée.
## **Approche héritée d’Aspose.Slides for .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Définir les propriétés de visibilité des en-têtes et pieds de page
//Mettre à jour les champs de date et d'heure
//Afficher l'espace réservé à la date et à l'heure
//Afficher l'espace réservé au pied de page
//Afficher le numéro de diapositive
//Définir la visibilité des en-têtes et pieds de page sur la diapositive de titre
//Écrire la présentation sur le disque
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

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

//Écrire la présentation sur le disque
pres.Write("HeadFoot.ppt");
```

## **Nouvelle approche d’Aspose.Slides for .NET 13.x**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //Définir les propriétés de visibilité des en-têtes et pieds de page
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Mettre à jour les champs de date et d'heure
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Afficher l'espace réservé à la date et à l'heure
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Afficher l'espace réservé au pied de page
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Définir la visibilité des en-têtes et pieds de page sur la diapositive de titre
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Écrire la présentation sur le disque
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```