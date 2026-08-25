---
title: Fusion efficace des présentations en .NET
linktitle: Fusionner des présentations
type: docs
weight: 40
url: /fr/net/merge-presentation/
keywords:
- fusion PowerPoint
- fusion de présentations
- fusion de diapositives
- fusion PPT
- fusion PPTX
- fusion ODP
- combiner PowerPoint
- combiner des présentations
- combiner des diapositives
- combiner PPT
- combiner PPTX
- combiner ODP
- .NET
- C#
- Aspose.Slides
description: "Apprenez à fusionner des présentations PowerPoint et OpenDocument en .NET en clonant des diapositives, en contrôlant les maîtres et les dispositions, en redimensionnant le contenu des diapositives, en préservant les sections, et en gérant les fichiers protégés ou volumineux."
---
## **Aperçu**

Aspose.Slides pour .NET fusionne des présentations en clonant des diapositives d’une [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) à une autre. L’opération principale est [ISlideCollection.AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/addclone/), qui peut préserver le formatage de la diapositive source ou attacher la diapositive clonée à un maître ou à une disposition dans la présentation de destination.

Ce document couvre les flux de travail de fusion les plus courants :

- fusionner toutes les diapositives tout en préservant le formatage source ;
- fusionner des diapositives sélectionnées ;
- appliquer un maître provenant de la présentation de destination ;
- appliquer une disposition spécifique de la présentation de destination ;
- normaliser des tailles de diapositives différentes avant la fusion ;
- ajouter les diapositives clonées à une section ;
- fusionner plusieurs présentations dans un flux de travail de bout en bout ;
- gérer les maîtres, les ressources, les notes, les commentaires, les médias, les polices, les mots de passe, les gros fichiers et les problèmes de multithreading.

## **Comment le clonage de diapositives affecte les maîtres et les dispositions**

Une diapositive hérite d’une grande partie de son apparence de sa disposition et de son maître. Pour cette raison, la surcharge de clonage que vous choisissez détermine comment la diapositive fusionnée est intégrée à la présentation de destination.

Utilisez [ISlideCollection.AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/addclone/) de l’une des manières suivantes :

- `AddClone(sourceSlide)` — préserve la disposition et le formatage de la diapositive source. Si nécessaire, le maître source peut être cloné automatiquement dans la présentation de destination. Aspose.Slides suit les maîtres clonés automatiquement afin que les diapositives répétées utilisant le même maître source ne provoquent pas de clonage répété de ce maître.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — attache la diapositive clonée à un [IMasterSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslide/) de destination spécifique. Aspose.Slides recherche une disposition correspondante sous ce maître par type ou par nom.
- `AddClone(sourceSlide, destinationLayout)` — attache directement la diapositive clonée à un [ILayoutSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/ilayoutslide/) de destination spécifique.

Le maître ou la disposition passé à une surcharge `AddClone` doit appartenir à la présentation **de destination**, pas à la présentation source.

## **Fusionner des présentations entières et préserver le formatage source**

La fusion la plus simple copie chaque diapositive de la présentation source vers la présentation de destination. C’est le choix approprié lorsque les diapositives importées doivent conserver leur thème, maître et relations de disposition d’origine.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

La présentation résultante peut contenir plusieurs maîtres lorsque la source et la destination utilisent des conceptions différentes. Cela est attendu lorsque le formatage source est intentionnellement préservé.

## **Fusionner des diapositives sélectionnées**

Vous n’avez pas besoin de cloner chaque diapositive. L’exemple suivant n’importe que les index de diapositives sélectionnés de la présentation source.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

Validez les index de diapositives avant le clonage lorsqu’ils proviennent d’une saisie utilisateur ou d’une configuration externe.

## **Fusionner des diapositives en utilisant un maître de destination**

Utilisez la surcharge [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/addclone/) lorsque les diapositives importées doivent suivre un maître déjà présent dans la présentation de destination.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides sélectionne une disposition appropriée sous le maître spécifié en faisant correspondre le type ou le nom de la disposition source. Si aucune disposition adaptée n’existe et que `allowCloneMissingLayout` est `true`, la disposition source est clonée afin que la diapositive puisse être ajoutée. Si elle est `false`, une [PptxEditException](https://reference.aspose.com/slides/fr/net/aspose.slides/pptxeditexception/) est levée.

Utilisez `false` lorsque vous souhaitez que la fusion échoue plutôt que d’introduire une disposition supplémentaire dans le maître de destination.

## **Fusionner des diapositives en utilisant une disposition spécifique de destination**

Utilisez la surcharge [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/addclone/) lorsque vous savez exactement quelle disposition de destination les diapositives importées doivent utiliser.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

Appliquer une disposition de destination modifie la relation de disposition héritée ; cela ne redessine pas le contenu de la diapositive source. Si les dispositions source et destination ont des structures de zones réservées différentes, inspectez le résultat pour confirmer que le formatage hérité et le comportement des zones réservées sont appropriés.

## **Fusionner des présentations avec des tailles de diapositives différentes**

Des présentations avec des dimensions de diapositive différentes peuvent être fusionnées, mais le clonage d’une diapositive dans une présentation dont la taille est autre ne redessine pas automatiquement son contenu pour le nouveau canevas. Les formes peuvent alors apparaître déplacées, redimensionnées de façon inattendue ou en dehors de la zone visible de la diapositive.

Une approche pratique consiste à redimensionner la présentation source avant le clonage. La méthode [SlideSize.SetSize](https://reference.aspose.com/slides/fr/net/aspose.slides/slidesize/setsize/) peut mettre à l’échelle le contenu existant tout en modifiant les dimensions de la diapositive. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/net/aspose.slides/slidesizescaletype/) met l’échelle du contenu pour qu’il s’ajuste à la taille demandée.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

Le redimensionnement modifie l’objet présentation source en mémoire. Si vous avez besoin que la présentation source d’origine reste inchangée pour d’autres opérations, ouvrez une instance distincte pour la fusion.

## **Fusionner des diapositives dans une section de présentation**

La boucle de clonage de base ne recrée pas la hiérarchie des sections de la présentation source. Si les sections sont importantes dans le résultat, créez ou sélectionnez des sections dans la présentation de destination et clonez les diapositives dans celles‑ci explicitement avec [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/addclone/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

Les diapositives clonées sont ajoutées à la section de destination spécifiée. Pour préserver plusieurs sections sources, parcourez [Presentation.Sections](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/sections/), récupérez les diapositives actuelles de chaque section source avec [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/fr/net/aspose.slides/isection/getslideslistofsection/), recréez les sections dans la destination, et clonez chaque diapositive retournée dans sa section de destination correspondante. Consultez [Manage Slide Sections](/slides/fr/net/slide-section/) pour un exemple complet d’énumération des sections, incluant les sections vides et les changements structurels.

## **Fusionner plusieurs présentations en toute sécurité**

L’exemple de bout en bout suivant utilise la première présentation comme destination, normalise la taille des diapositives de chaque source supplémentaire, ne garde chaque source ouverte que pendant la copie, et enregistre le fichier final une fois.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

C’est une base utile pour préserver le formatage source des diapositives importées. Si votre résultat doit utiliser un thème unique de destination, remplacez l’appel simple `AddClone(slide)` par la surcharge maître‑de‑destination ou disposition‑de‑destination appropriée présentée précédemment.

## **Considérations pratiques**

### **Maîtres, dispositions et fidélité du formatage**

Le clonage de diapositives par défaut peut apporter automatiquement un maître source requis dans la présentation de destination. Aspose.Slides conserve un registre interne des maîtres clonés automatiquement afin d’éviter de cloner le même maître plusieurs fois. Les maîtres clonés manuellement ne sont pas suivis par ce registre, évitez donc de pré‑cloner les maîtres sauf si vous avez besoin d’un contrôle explicite sur la structure des maîtres.

Ne supposez pas que deux maîtres ou deux dispositions portant le même nom soient visuellement équivalents. Si un modèle d’entreprise doit contrôler l’apparence finale, choisissez explicitement un maître ou une disposition de destination et vérifiez le résultat après la fusion.

### **Notes et commentaires**

Les notes du présentateur et les commentaires de diapositives sont associés au contenu de la diapositive et sont copiés lorsqu’une diapositive est clonée. Aspose.Slides expose également des API dédiées pour [presentation notes](/slides/fr/net/presentation-notes/) et [presentation comments](/slides/fr/net/presentation-comments/).

Si le formatage de la page de notes est important, vérifiez la présentation fusionnée car les maîtres de notes sont des objets au niveau de la présentation et peuvent différer entre les fichiers source. Pour les flux de révision, vérifiez également les auteurs des commentaires et les commentaires en fil après la combinaison de fichiers provenant de différents auteurs ou modèles.

### **Images, audio, vidéo, objets OLE et liens externes**

Les diapositives peuvent référencer des ressources au niveau de la présentation telles que des images, de l’audio intégré, de la vidéo intégrée et des données OLE. Clonez la diapositive elle‑même plutôt que de copier uniquement ses formes visibles afin qu’Aspose.Slides puisse maintenir les relations de la diapositive avec ses ressources.

Les ressources intégrées et les ressources liées doivent être traitées différemment. Un audio, une vidéo, un objet OLE ou un hyperlien lié restent dépendants de leur cible externe ; le clonage d’une diapositive ne transforme pas un lien externe en contenu intégré. Testez les chemins et les URL des ressources liées dans l’environnement où la présentation fusionnée sera ouverte.

Aspose.Slides suit explicitement les maîtres clonés automatiquement, mais cela ne doit pas être considéré comme une garantie générale que des ressources binaires identiques provenant de présentations sources différentes seront toujours dédupliquées. Si la taille du fichier de sortie est importante, inspectez le package fusionné et mesurez le résultat au lieu de compter sur une déduplication implicite.

### **Polices intégrées et disponibilité des polices**

Les polices sont gérées au niveau de la présentation. Si la typographie doit rester cohérente d’une machine à l’autre, ne supposez pas que le clonage de diapositives seul garantit que chaque police requise soit disponible dans l’environnement de destination. Vous pouvez inspecter les polices intégrées avec [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsmanager/getembeddedfonts/) et gérer l’intégration explicitement comme décrit dans [Embed Fonts in Presentations](/slides/fr/net/embedded-font/).

Vérifiez également que vous êtes autorisé à intégrer les polices utilisées par les fichiers source. Les licences de police peuvent restreindre l’intégration.

### **Présentations protégées par mot de passe**

Une source protégée par mot de passe doit être ouverte avec succès avant que ses diapositives puissent être clonées. Fournissez le mot de passe via [LoadOptions.Password](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

L’ouverture d’une source chiffrée n’applique pas automatiquement la même protection à la présentation de destination. Configurez la protection de sortie séparément si nécessaire.

### **Présentations volumineuses et utilisation de la mémoire**

Les présentations volumineuses contenant des images haute résolution, de l’audio, de la vidéo ou d’autres objets binaires importants peuvent consommer une mémoire importante. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/blobmanagementoptions/) offre des contrôles pour la gestion des BLOB et l’utilisation de fichiers temporaires. Consultez [Manage Presentation BLOBs](/slides/fr/net/manage-blob/) pour des stratégies de gros fichiers.

Pour les gros fichiers, privilégiez le chargement depuis des chemins de fichier lorsque cela est possible, libérez chaque présentation source dès qu’elle a été fusionnée, et évitez d’enregistrer répétitivement les résultats intermédiaires sauf si le flux de travail impose des points de contrôle.

### **Sécurité des threads**

Ne chargez, ne modifiez, n’enregistrez ni ne clonez pas la même instance de [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) simultanément depuis plusieurs threads. Gardez chaque instance de présentation confinée à une opération de fusion. Si vous parallélisez des travaux indépendants, utilisez des instances de présentation distinctes et suivez les recommandations de [Aspose.Slides multithreading guidance](/slides/fr/net/multithreading/).

## **FAQ**

**Comment conserver la conception originale de chaque présentation source ?**

Utilisez [AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/addclone/) sans fournir de maître ou de disposition de destination. Aspose.Slides peut automatiquement cloner le maître source lorsqu’il est requis par la diapositive importée.

**Comment faire en sorte que les diapositives importées utilisent le thème de destination ?**

Utilisez la surcharge qui accepte un maître de destination. Fournissez un maître provenant de la présentation de destination, pas de la source. Aspose.Slides essaiera de mapper chaque diapositive source à une disposition appropriée sous ce maître.

**Quand faut‑il utiliser une disposition spécifique de destination plutôt qu’un maître de destination ?**

Utilisez une disposition spécifique lorsque chaque diapositive importée doit utiliser une disposition connue. Utilisez un maître lorsque vous voulez qu’Aspose.Slides sélectionne parmi les dispositions de ce maître en fonction du type ou du nom de la disposition source.

**Les présentations avec des tailles de diapositives différentes peuvent‑elles être fusionnées ?**

Oui, mais le contenu des diapositives n’est pas redessiné automatiquement pour les dimensions de destination. Redimensionnez d’abord la présentation source lorsque vous avez besoin d’un placement prévisible, par exemple avec [SlideSize.SetSize](https://reference.aspose.com/slides/fr/net/aspose.slides/slidesize/setsize/) et [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fr/net/aspose.slides/slidesizescaletype/).

**Puis‑je fusionner des présentations PPT, PPTX et ODP dans un même fichier ?**

Oui. Chargez chaque présentation source, clonez les diapositives requises dans une destination unique, puis enregistrez la destination dans un format de sortie pris en charge. Comme les formats de présentation ne supportent pas exactement le même ensemble de fonctionnalités, vérifiez le contenu complexe après les fusions inter‑formats. Consultez [Supported File Formats](/slides/fr/net/supported-file-formats/).

**Les sections sources sont‑elles préservées automatiquement ?**

Pas par une boucle de base qui ne clone que les diapositives. Recréez les sections nécessaires dans la destination et utilisez la surcharge de section de [AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/addclone/) lorsque la structure des sections doit être préservée.

**Les notes du présentateur et les commentaires sont‑ils préservés ?**

Ils sont copiés avec la diapositive clonée. Pour les flux de travail dépendant du style du maître de notes, des auteurs de commentaires ou des commentaires en fil, vérifiez le résultat fusionné car ces scénarios impliquent également des structures au niveau de la présentation.

**Que se passe‑t‑il avec l’audio, la vidéo, les objets OLE et les hyperliens ?**

Le contenu intégré est transporté avec les relations de ressources de la diapositive clonée. Les liens externes restent externes, leurs fichiers cibles ou URL devant rester disponibles après la fusion.

**Les polices intégrées de chaque source sont‑elles garanties d’être disponibles dans la présentation fusionnée ?**

Ne comptez pas uniquement sur le clonage des diapositives pour le déploiement des polices. Inspectez les polices intégrées de la destination et gérez explicitement l’intégration ou la disponibilité des polices externes lorsque la typographie est importante.

**Comment fusionner un fichier protégé par mot de passe ?**

Ouvrez‑le avec le bon [LoadOptions.Password](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/password/), puis clonez ses diapositives normalement. La protection de sortie est configurée séparément.

**Comment gérer des présentations très volumineuses ?**

Utilisez la gestion des BLOB lorsque les objets binaires lourds dominent l’utilisation de la mémoire, privilégiez le chargement depuis des chemins de fichier pour les très gros fichiers, libérez rapidement les présentations sources, et n’enregistrez le résultat final qu’une seule fois lorsque c’est possible.

**Puis‑je fusionner des diapositives depuis plusieurs threads ?**

Ne utilisez pas la même instance de [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) simultanément depuis plusieurs threads. Gardez chaque opération de fusion isolée dans ses propres instances de présentation.