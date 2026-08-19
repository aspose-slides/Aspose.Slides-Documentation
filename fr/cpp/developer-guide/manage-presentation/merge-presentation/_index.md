---
title: Fusionner efficacement les présentations en C++
linktitle: Fusionner les présentations
type: docs
weight: 40
url: /fr/cpp/merge-presentation/
keywords:
- fusionner PowerPoint
- fusionner des présentations
- fusionner des diapositives
- fusionner PPT
- fusionner PPTX
- fusionner ODP
- combiner PowerPoint
- combiner des présentations
- combiner des diapositives
- combiner PPT
- combiner PPTX
- combiner ODP
- C++
- Aspose.Slides
description: "Apprenez à fusionner des présentations PowerPoint et OpenDocument en C++ en clonant des diapositives, en contrôlant les maîtres et les dispositions, en redimensionnant le contenu des diapositives, en préservant les sections et en gérant les fichiers protégés ou volumineux."
---
## **Vue d'ensemble**

Aspose.Slides for C++ fusionne des présentations en clonant les diapositives d'une [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) vers une autre. L'opération principale est [ISlideCollection::AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/), qui peut préserver la mise en forme de la diapositive source ou attacher la diapositive clonée à un maître ou à une disposition dans la présentation de destination.

Cet article couvre les flux de travail de fusion les plus courants :

- fusionner toutes les diapositives tout en conservant leur mise en forme d'origine ;
- fusionner des diapositives sélectionnées ;
- appliquer un maître de la présentation de destination ;
- appliquer une disposition spécifique de la présentation de destination ;
- normaliser différentes tailles de diapositives avant la fusion ;
- ajouter les diapositives clonées à une section ;
- fusionner plusieurs présentations dans un flux de travail complet ;
- gérer les maîtres, les ressources, les notes, les commentaires, les médias, les polices, les mots de passe, les fichiers volumineux et les problèmes de multithreading.

## **Comment le clonage de diapositives affecte les maîtres et les dispositions**

Une diapositive hérite d’une grande partie de son apparence de sa disposition et de son maître. Pour cette raison, la surcharge de clonage que vous choisissez détermine la façon dont la diapositive fusionnée est intégrée à la présentation de destination.

Utilisez [ISlideCollection::AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) de l’une des manières suivantes :

- `AddClone(sourceSlide)` — préserve la disposition et la mise en forme de la diapositive source. Si nécessaire, le maître source peut être cloné automatiquement dans la présentation de destination. Aspose.Slides suit les maîtres clonés automatiquement afin que les diapositives répétées utilisant le même maître source ne provoquent pas de clonage répété de ce maître.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — attache la diapositive clonée à un [IMasterSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslide/) de destination spécifique. Aspose.Slides recherche une disposition correspondante sous ce maître par type ou par nom de disposition.
- `AddClone(sourceSlide, destinationLayout)` — attache directement la diapositive clonée à un [ILayoutSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/) de destination spécifique.

Le maître ou la disposition passé à une surcharge `AddClone` doit appartenir à la présentation **de destination**, pas à la présentation source.

## **Fusionner des présentations complètes et préserver la mise en forme source**

La fusion la plus simple copie chaque diapositive de la présentation source vers la présentation de destination. C’est le choix approprié lorsque les diapositives importées doivent conserver leur thème, maître et relations de disposition d'origine.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

La présentation résultante peut contenir plusieurs maîtres lorsque la source et la destination utilisent des conceptions différentes. C’est attendu lorsque la mise en forme source est délibérément préservée.

## **Fusionner des diapositives sélectionnées**

Vous n’avez pas besoin de cloner chaque diapositive. L’exemple suivant importe uniquement les index de diapositives sélectionnés de la présentation source.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

Validez les index de diapositives avant le clonage lorsqu’ils proviennent d’une saisie utilisateur ou d’une configuration externe.

## **Fusionner des diapositives en utilisant un maître de destination**

Utilisez la surcharge [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) lorsque les diapositives importées doivent suivre un maître qui appartient déjà à la présentation de destination.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides sélectionne une disposition appropriée sous le maître spécifié en faisant correspondre le type ou le nom de la disposition source. Si aucune disposition adaptée n’existe et que `allowCloneMissingLayout` est `true`, la disposition source est clonée afin que la diapositive puisse être ajoutée. Si elle est `false`, une [PptxEditException](https://reference.aspose.com/slides/fr/cpp/aspose.slides/details_pptxeditexception/) est levée.

Utilisez `false` lorsque vous souhaitez que la fusion échoue plutôt que d’introduire une disposition supplémentaire dans le maître de destination.

## **Fusionner des diapositives en utilisant une disposition de destination spécifique**

Utilisez la surcharge [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) lorsque vous savez exactement quelle disposition de destination les diapositives importées doivent utiliser.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

L’application d’une disposition de destination modifie la relation de disposition héritée ; cela ne redessine pas le contenu de la diapositive source. Si les dispositions source et destination ont des structures de zones réservées différentes, inspectez le résultat pour confirmer que la mise en forme héritée et le comportement des zones réservées sont appropriés.

## **Fusionner des présentations avec des tailles de diapositives différentes**

Des présentations avec des dimensions de diapositives différentes peuvent être fusionnées, mais le clonage d’une diapositive dans une présentation avec une autre taille de diapositive ne redessine pas automatiquement son contenu pour le nouveau canevas. Les formes peuvent ainsi apparaître déplacées, redimensionnées de façon inattendue ou hors de la zone visible de la diapositive.

Une approche pratique consiste à redimensionner la présentation source avant le clonage. La méthode [SlideSize::SetSize](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slidesize/setsize/) peut mettre à l’échelle le contenu existant tout en modifiant les dimensions de la diapositive. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slidesizescaletype/) met à l’échelle le contenu pour qu’il s’ajuste à la taille demandée.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

Le redimensionnement modifie l’objet de la présentation source en mémoire. Si vous avez besoin que la présentation source originale reste inchangée pour d’autres opérations, ouvrez une instance séparée pour la fusion.

## **Fusionner des diapositives dans une section de présentation**

La boucle de clonage de diapositives de base ne recrée pas la hiérarchie des sections de la présentation source. Si les sections sont importantes dans le résultat, créez ou sélectionnez des sections dans la présentation de destination et clonez les diapositives dedans explicitement avec [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/).

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

Les diapositives clonées sont ajoutées à la section de destination spécifiée. Pour conserver plusieurs sections sources, recréez ces sections dans la destination et associez chaque diapositive source à la section de destination correspondante.

## **Fusionner plusieurs présentations en toute sécurité**

L’exemple complet suivant utilise la première présentation comme destination, normalise la taille des diapositives de chaque source supplémentaire, maintient chaque source ouverte uniquement pendant sa copie, et enregistre le fichier final une fois.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

Ceci constitue une base utile pour préserver la mise en forme source des diapositives importées. Si votre résultat doit utiliser un thème de destination unique, remplacez l’appel simple `AddClone(slide)` par la surcharge de maître de destination ou de disposition de destination appropriée présentée précédemment.

## **Considérations pratiques**

### **Maîtres, dispositions et fidélité de la mise en forme**

Le clonage de diapositive par défaut peut automatiquement amener un maître source requis dans la présentation de destination. Aspose.Slides maintient un registre interne des maîtres clonés automatiquement afin d’éviter de cloner le même maître à plusieurs reprises. Les maîtres clonés manuellement ne sont pas suivis par ce registre, évitez donc de pré‑cloner les maîtres sauf si vous avez besoin d’un contrôle explicite sur la structure des maîtres.

Ne supposez pas que deux maîtres ou dispositions portant le même nom soient visuellement équivalents. Si un modèle d’entreprise doit contrôler l’apparence finale, choisissez explicitement un maître ou une disposition de destination et vérifiez le résultat après la fusion.

### **Notes et commentaires**

Les notes du présentateur et les commentaires de diapositive sont associés au contenu de la diapositive et sont copiés lorsqu’une diapositive est clonée. Aspose.Slides expose également des API dédiées aux [notes de présentation](https://docs.aspose.com/slides/fr/cpp/presentation-notes/) et aux [commentaires de présentation](https://docs.aspose.com/slides/fr/cpp/presentation-comments/).

Si la mise en forme de la page de notes est importante, vérifiez la présentation fusionnée car les maîtres de notes sont des objets au niveau de la présentation et peuvent différer entre les fichiers sources. Pour les flux de travail de révision, vérifiez également les auteurs des commentaires et les commentaires en fil après avoir combiné des fichiers provenant de différents auteurs ou modèles.

### **Images, audio, vidéo, objets OLE et liens externes**

Les diapositives peuvent référencer des ressources au niveau de la présentation telles que des images, de l’audio intégré, de la vidéo intégrée et des données OLE. Clonez la diapositive elle‑même plutôt que de copier uniquement ses formes visibles afin qu’Aspose.Slides puisse maintenir les relations de la diapositive avec ses ressources.

Les ressources intégrées et liées doivent être traitées différemment. Un audio, une vidéo, un objet OLE ou un hyperlien lié reste dépendant de sa cible externe ; le clonage d’une diapositive ne transforme pas un lien externe en contenu intégré. Testez les chemins et les URL des ressources liées dans l’environnement où la présentation fusionnée sera ouverte.

Aspose.Slides suit explicitement les maîtres clonés automatiquement, mais cela ne doit pas être considéré comme une garantie générale que des ressources binaires identiques provenant de présentations sources indépendantes seront toujours dédupliquées. Si la taille du fichier de sortie est importante, inspectez le package fusionné et mesurez le résultat plutôt que de vous fier à la déduplication implicite.

### **Polices intégrées et disponibilité des polices**

Les polices sont gérées au niveau de la présentation. Si la typographie doit rester cohérente d’une machine à l’autre, ne supposez pas que le clonage des diapositives garantit que chaque police requise est disponible dans l’environnement de destination. Vous pouvez inspecter les polices intégrées avec [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsmanager/getembeddedfonts/) et gérer l’intégration explicitement comme décrit dans [Intégrer des polices dans les présentations](https://docs.aspose.com/slides/fr/cpp/embedded-font/).

Vérifiez également que vous êtes autorisé à intégrer les polices utilisées par les fichiers sources. Les licences de polices peuvent restreindre l’intégration.

### **Présentations protégées par mot de passe**

Une source protégée par mot de passe doit être ouverte avec succès avant que ses diapositives puissent être clonées. Fournissez le mot de passe via [LoadOptions::set_Password](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_password/).

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

L’ouverture d’une source chiffrée n’applique pas automatiquement la même protection à la présentation de destination. Configurez la protection de sortie séparément si nécessaire.

### **Grandes présentations et utilisation de la mémoire**

Les grandes présentations contenant des images haute résolution, de l’audio, de la vidéo ou d’autres gros objets binaires peuvent consommer une mémoire importante. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) offre des contrôles pour la gestion des BLOB et l’utilisation de fichiers temporaires. Consultez [Gérer les BLOB de présentation](https://docs.aspose.com/slides/fr/cpp/manage-blob/) pour les stratégies de gros fichiers.

Pour les gros fichiers, privilégiez le chargement à partir de chemins de fichiers lorsque cela est possible, libérez chaque présentation source dès qu’elle a été fusionnée, et évitez d’enregistrer de façon répétée des résultats intermédiaires sauf si le flux de travail nécessite des points de contrôle.

### **Sécurité des threads**

Ne chargez, modifiez, enregistrez ou clonez pas la même [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) instance simultanément depuis plusieurs threads. Gardez chaque instance de présentation confinée à une opération de fusion. Si vous parallélisez des tâches indépendantes, utilisez des instances de présentation indépendantes et suivez les [directives multithreads d’Aspose.Slides](https://docs.aspose.com/slides/fr/cpp/multithreading/).

## **FAQ**

**Comment conserver le design original de chaque présentation source ?**

Utilisez [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) sans fournir de maître ou de disposition de destination. Aspose.Slides peut cloner automatiquement le maître source lorsqu’il est requis par la diapositive importée.

**Comment faire en sorte que les diapositives importées utilisent le thème de destination ?**

Utilisez la surcharge qui accepte un maître de destination. Passez un maître provenant de la présentation de destination, pas de la source. Aspose.Slides tentera de mapper chaque diapositive source à une disposition appropriée sous ce maître.

**Quand devrais‑je utiliser une disposition de destination spécifique au lieu d’un maître de destination ?**

Utilisez une disposition spécifique lorsque chaque diapositive importée doit utiliser une disposition connue. Utilisez un maître lorsque vous souhaitez qu’Aspose.Slides sélectionne parmi les dispositions de ce maître en fonction du type ou du nom de la disposition source.

**Les présentations avec des tailles de diapositives différentes peuvent‑elles être fusionnées ?**

Oui, mais le contenu des diapositives n’est pas automatiquement redessiné pour les dimensions de destination. Redimensionnez d’abord la présentation source lorsque vous avez besoin d’un placement prévisible, par exemple avec [SlideSize::SetSize](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slidesize/setsize/) et [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slidesizescaletype/).

**Puis‑je fusionner des présentations PPT, PPTX et ODP en un seul fichier ?**

Oui. Chargez chaque présentation source, clonez les diapositives requises dans une destination unique, et enregistrez la destination dans un format de sortie pris en charge. Étant donné que les formats de présentation ne supportent pas exactement le même ensemble de fonctionnalités, vérifiez le contenu complexe après les fusions inter‑formates. Consultez les [Formats de fichiers pris en charge](https://docs.aspose.com/slides/fr/cpp/supported-file-formats/).

**Les sections sources sont‑elles préservées automatiquement ?**

Pas par une boucle de base qui ne clone que les diapositives. Recréez les sections requises dans la destination et utilisez la surcharge de section de [AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) lorsque la structure des sections doit être préservée.

**Les notes du présentateur et les commentaires sont‑ils préservés ?**

Ils sont copiés avec la diapositive clonée. Pour les flux de travail qui dépendent du style du maître de notes, des auteurs des commentaires ou des données de révision en fil, vérifiez le résultat fusionné car ces scénarios impliquent à la fois des structures au niveau de la présentation et du contenu au niveau de la diapositive.

**Que se passe‑t‑il avec l’audio, la vidéo, les objets OLE et les hyperliens ?**

Le contenu intégré est porté comme partie des relations de ressources de la diapositive clonée. Les liens externes restent externes, leurs fichiers cibles ou URL doivent donc rester disponibles après la fusion.

**Les polices intégrées de chaque source sont‑elles garanties d’être disponibles dans la présentation fusionnée ?**

Ne comptez pas uniquement sur le clonage de diapositives pour le déploiement des polices. Inspectez les polices intégrées de la destination et gérez explicitement l’intégration des polices ou la disponibilité des polices externes lorsque la typographie est importante.

**Comment fusionner un fichier protégé par mot de passe ?**

Ouvrez‑le avec le bon [LoadOptions::set_Password](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_password/), puis clonez ses diapositives normalement. La protection de la sortie est configurée séparément.

**Comment gérer des présentations très volumineuses ?**

Utilisez la gestion des BLOB lorsque de gros objets binaires dominent l’utilisation de la mémoire, privilégiez le chargement à partir de chemins de fichiers pour les très gros fichiers, libérez rapidement les présentations source, et enregistrez le résultat final uniquement lorsque nécessaire.

**Puis‑je fusionner des diapositives depuis plusieurs threads ?**

N’utilisez pas une même instance de [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) simultanément depuis plusieurs threads. Gardez chaque opération de fusion isolée dans ses propres instances de présentation.