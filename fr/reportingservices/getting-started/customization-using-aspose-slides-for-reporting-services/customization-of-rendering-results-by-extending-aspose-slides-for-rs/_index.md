---
title: Personnalisation des résultats de rendu en étendant Aspose.Slides pour RS
type: docs
weight: 10
url: /fr/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---

{{% alert color="primary" %}} 

Cette page décrit comment créer une extension pour Aspose.Slides pour RS.

- [Créer un assembly d'extension](/slides/fr/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [Intégrer l'extension](/slides/fr/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

La fonctionnalité d'extension personnalisée vous donne la possibilité d'ajouter des éléments supplémentaires ou de mettre à jour les éléments existants lors de l'exportation de rapports.
## **Comment créer un assembly d'extension**
1. Créez un projet .NET et ajoutez une référence à Aspose.Slides.ReportingServices.dll.
1. Ajoutez une classe et héritez-la de Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase.
1. Surchargez les méthodes virtuelles de la classe pour ajouter des fonctionnalités personnalisées.
### **Exemple**
Supposons que nous souhaitons ajouter une note avec un certain texte, un logo et mettre à jour le nom de l'entreprise pour chaque rapport exporté avec Aspose.Slides pour RS.

À cette fin, nous ajoutons la classe suivante :

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//Ajouter une note à la première diapositive

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("Ceci est la démonstration de l'extension de rendu pour Aspose.Slides pour ReportingServices",

textFormat);

}

//Afficher le logo sur chaque diapositive dans le coin inférieur droit

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//Ajouter (TM) à toute mention du nom de l'entreprise dans le rapport

string companyName = "Adventure Works";

if (textBox.Text.Contains(companyName))

{

textBox.Text = textBox.Text.Replace(companyName, companyName + "™");

}

base.PostProcessTextBox(textBox);

}

}

```

{{% alert color="primary" %}} 

Compilez-le et vous obtiendrez l'assembly d'extension. Nous sommes prêts à intégrer l'extension.

{{% /alert %}} 

[Projet Visual Studio de RenderingExtensionDemo.zip](attachments/10289195/10452998.zip)
### **Intégrer l'extension**
Supposons que votre assembly s'appelle **TestSlidesRenderingExtension.dll** :

- Copiez l'assembly dans le répertoire **bin** de ReportingService à côté de Aspose.Slides.ReportingServices.dll. (Par exemple : c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- Accordez des autorisations FullTrust à votre assembly en ajoutant le CodeGroup suivant à **rssrvpolicy.config** :

``` xml

 <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Nothing">

<IMembershipCondition class="AllMembershipCondition" version="1" />

...

<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="Ce groupe de code accorde l'autorisation d'exécution du code MyComputer. ">

<IMembershipCondition class="ZoneMembershipCondition" version="1" Zone="MyComputer" />

...

<CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_Extension" Description="Ce groupe de code accorde une confiance totale à l'extension de rendu Aspose.Slides pour Reporting Services.">

<IMembershipCondition	class="UrlMembershipCondition"	version="1" Url="c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin\TestSlidesRenderingExtension.dll" />

</CodeGroup>

</CodeGroup>

</CodeGroup>

```

Mettez à jour les sections de configuration de l'extension Aspose.Slides de **rsreportserver.config** pour inclure votre extension.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

Si vous souhaitez utiliser l'extension pour chaque type de sortie pris en charge par Aspose.Slides, ajoutez la même configuration aux extensions avec les noms ASPPTX, ASPPT, ASPPS, ASPPSX.
Le contenu de la balise Extension est un nom qualifié par assembly du type. (Voir <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

Maintenant, redémarrez Reporting Services et exportez le rapport. Vous obtiendrez quelque chose comme [cette présentation](attachments/10289195/10452997.pptx) du rapport Company Sales SQL2008R2 des exemples d'Adventureworks.