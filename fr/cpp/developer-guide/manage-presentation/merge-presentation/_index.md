---
title: Fusionner efficacement des présentations en C++
linktitle: Fusionner des présentations
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
description: "Apprenez à fusionner des présentations PowerPoint et OpenDocument en C++ en clonant des diapositives, en contrôlant les maîtres et les mises en page, en redimensionnant le contenu des diapositives, en préservant les sections et en gérant les fichiers protégés ou volumineux."
---
## **Vue d'ensemble**

Aspose.Slides for C++ combine des présentations en clonant des diapositives d'une [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) à une autre. L'opération principale est [ISlideCollection::AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/), qui peut préserver le formatage de la diapositive source ou attacher la diapositive clonée à un maître ou à une mise en page dans la présentation de destination.

Cet article couvre les flux de travail de fusion les plus courants :

- fusionner toutes les diapositives tout en conservant leur formatage d'origine ;
- fusionner des diapositives sélectionnées ;
- appliquer un maître de la présentation de destination ;
- appliquer une mise en page spécifique de la présentation de destination ;
- normaliser des tailles de diapositive différentes avant la fusion ;
- ajouter des diapositives clonées à une section ;
- fusionner plusieurs présentations dans un flux de travail de bout en bout ;
- gérer les maîtres, les ressources, les notes, les commentaires, les médias, les polices, les mots de passe, les gros fichiers et les problèmes de multithreading.

## **Comment le clonage de diapositives affecte les maîtres et les mises en page**

Une diapositive hérite d’une grande partie de son apparence de sa mise en page et de son maître. Pour cette raison, la surcharge de clonage que vous choisissez détermine comment la diapositive fusionnée est intégrée à la présentation de destination.

Utilisez [ISlideCollection::AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) de l’une des manières suivantes :

- `AddClone(sourceSlide)` — préserver la mise en page et le formatage de la diapositive source. Si nécessaire, le maître source peut être cloné automatiquement dans la présentation de destination. Aspose.Slides suit les maîtres clonés automatiquement afin que les diapositives répétées utilisant le même maître source ne provoquent pas de clonage répété de ce maître.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — attacher la diapositive clonée à un [IMasterSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslide/) de destination spécifique. Aspose.Slides recherche une mise en page correspondante sous ce maître par type ou par nom de mise en page.
- `AddClone(sourceSlide, destinationLayout)` — attacher la diapositive clonée directement à un [ILayoutSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/) de destination spécifique.

Le maître ou la mise en page passé à une surcharge `AddClone` doit appartenir à la **présentation de destination**, pas à la présentation source.

## **Fusionner des présentations entières tout en conservant le formatage d'origine**

La fusion la plus simple copie chaque diapositive de la présentation source vers la présentation de destination. C’est le choix approprié lorsque les diapositives importées doivent garder leur thème, leur maître et leurs relations de mise en page d’origine.

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

La présentation résultante peut contenir plusieurs maîtres lorsque la source et la destination utilisent des conceptions différentes. C’est le comportement attendu quand le formatage source est intentionnellement conservé.

## **Fusionner des diapositives sélectionnées**

Vous n’avez pas besoin de cloner chaque diapositive. L’exemple suivant importe uniquement les indices de diapositives sélectionnés depuis la présentation source.

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

Validez les indices de diapositives avant le clonage lorsqu’ils proviennent d’une saisie utilisateur ou d’une configuration externe.

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

Aspose.Slides sélectionne une mise en page appropriée sous le maître spécifié en faisant correspondre le type ou le nom de la mise en page source. Si aucune mise en page adaptée n’existe et que `allowCloneMissingLayout` est `true`, la mise en page source est clonée afin que la diapositive puisse être ajoutée. Si elle est `false`, une [PptxEditException](https://reference.aspose.com/slides/fr/cpp/aspose.slides/details_pptxeditexception/) est levée.

Utilisez `false` lorsque vous souhaitez que la fusion échoue au lieu d’introduire une mise en page supplémentaire dans le maître de destination.

## **Fusionner des diapositives en utilisant une mise en page de destination spécifique**

Utilisez la surcharge [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) lorsque vous savez exactement quelle mise en page de destination les diapositives importées doivent utiliser.

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

Appliquer une mise en page de destination modifie la relation de mise en page héritée ; cela ne redessine pas le contenu de la diapositive source. Si les mises en page source et destination ont des structures de zones réservées différentes, inspectez le résultat pour confirmer que le formatage hérité et le comportement des zones réservées sont appropriés.

## **Fusionner des présentations avec des tailles de diapositive différentes**

Des présentations avec des dimensions de diapositive différentes peuvent être fusionnées, mais cloner une diapositive dans une présentation dont la taille de diapositive est autre n’ajuste pas automatiquement son contenu au nouveau canevas. Les formes peuvent donc apparaître déplacées, redimensionnées de façon inattendue ou hors de la zone visible de la diapositive.

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

Le redimensionnement modifie l’objet de la présentation source en mémoire. Si vous avez besoin que la présentation source d’origine reste inchangée pour d’autres opérations, ouvrez une instance distincte pour la fusion.

## **Fusionner des diapositives dans une section de présentation**

La boucle de clonage de diapositives de base ne recrée pas la hiérarchie de sections de la présentation source. Si les sections sont importantes dans le résultat, créez ou sélectionnez des sections dans la présentation de destination et clonez les diapositives dans celles‑ci explicitement avec [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/).

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

Les diapositives clonées sont ajoutées à la section de destination spécifiée. Pour préserver plusieurs sections source, parcourez [Presentation::get_Sections](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_sections/), récupérez les diapositives actuelles de chaque section source avec [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isection/getslideslistofsection/), recréez les sections dans la destination, et clonez chaque diapositive retournée dans la section de destination correspondante. Consultez [Manage Slide Sections](/slides/fr/cpp/slide-section/) pour un exemple complet d’énumération de sections, y compris les sections vides et les changements structurels.

## **Fusionner plusieurs présentations en toute sécurité**

L’exemple de bout en bout suivant utilise la première présentation comme destination, normalise la taille de diapositive de chaque source supplémentaire, ne garde chaque source ouverte que pendant son copiage, et enregistre le fichier final une fois terminé.

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

C’est une base utile pour préserver le formatage source des diapositives importées. Si votre sortie doit utiliser un thème unique de destination, remplacez l’appel simple `AddClone(slide)` par la surcharge maître‑de‑destination ou mise‑en‑page‑de‑destination appropriée présentée précédemment.

## **Considérations pratiques**

### **Maîtres, mises en page et fidélité du formatage**

Le clonage de diapositives par défaut peut automatiquement introduire un maître source requis dans la présentation de destination. Aspose.Slides conserve un registre interne des maîtres clonés automatiquement afin d’éviter de cloner le même maître à plusieurs reprises. Les maîtres clonés manuellement ne sont pas suivis par ce registre, évitez donc de pré‑cloner les maîtres sauf si vous avez besoin d’un contrôle explicite sur la structure des maîtres.

Ne supposez pas que deux maîtres ou deux mises en page portant le même nom soient visuellement équivalents. Si un modèle d’entreprise doit contrôler l’apparence finale, choisissez explicitement un maître ou une mise en page de destination et vérifiez le résultat après la fusion.

### **Notes et commentaires**

Les notes du présentateur et les commentaires de diapositive sont associés au contenu de la diapositive et sont copiés lorsqu’une diapositive est clonée. Aspose.Slides expose également des API dédiées pour les [notes de présentation](/slides/fr/cpp/presentation-notes/) et les [commentaires de présentation](/slides/fr/cpp/presentation-comments/).

Si le formatage de la page de notes est important, vérifiez la présentation fusionnée parce que les maîtres de notes sont des objets au niveau de la présentation et peuvent différer entre les fichiers source. Pour les flux de travail de révision, vérifiez également les auteurs des commentaires et les commentaires en fils après avoir combiné des fichiers provenant d’auteurs ou de modèles différents.

### **Images, audio, vidéo, objets OLE et liens externes**

Les diapositives peuvent référencer des ressources au niveau de la présentation telles que des images, de l’audio intégré, de la vidéo intégrée et des données OLE. Clonez la diapositive elle‑même plutôt que de copier seulement ses formes visibles afin qu’Aspose.Slides puisse maintenir les relations de la diapositive avec ses ressources.

Les ressources incorporées et les ressources liées doivent être traitées différemment. Un audio, une vidéo, un objet OLE ou un hyperlien lié reste dépendant de sa cible externe ; le clonage d’une diapositive ne transforme pas un lien externe en contenu incorporé. Testez les chemins et les URL des ressources liées dans l’environnement où la présentation fusionnée sera ouverte.

Aspose.Slides suit explicitement les maîtres clonés automatiquement, mais cela ne doit pas être considéré comme une garantie générale que des ressources binaires identiques provenant de présentations sources non liées seront toujours dédupliquées. Si la taille du fichier de sortie est importante, inspectez le package fusionné et mesurez le résultat plutôt que de compter sur la déduplication implicite.

### **Polices intégrées et disponibilité des polices**

Les polices sont gérées au niveau de la présentation. Si la typographie doit rester cohérente d’une machine à l’autre, ne supposez pas que le clonage de diapositives garantisse que chaque police requise soit disponible dans l’environnement de destination. Vous pouvez inspecter les polices incorporées avec [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsmanager/getembeddedfonts/) et gérer l’incorporation explicitement comme décrit dans [Embed Fonts in Presentations](/slides/fr/cpp/embedded-font/).

Vérifiez également que vous êtes autorisé à incorporer les polices utilisées par les fichiers source. Les licences de polices peuvent restreindre l’incorporation.

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

Les grandes présentations contenant des images haute résolution, de l’audio, de la vidéo ou d’autres gros objets binaires peuvent consommer beaucoup de mémoire. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) fournit des contrôles pour la gestion des BLOB et l’utilisation de fichiers temporaires. Consultez [Manage Presentation BLOBs](/slides/fr/cpp/manage-blob/) pour les stratégies liées aux gros fichiers.

Pour les gros fichiers, privilégiez le chargement depuis des chemins de fichier lorsque cela est possible, libérez chaque présentation source dès qu’elle a été fusionnée, et évitez d’enregistrer à plusieurs reprises des résultats intermédiaires sauf si le flux de travail nécessite des points de contrôle.

### **Sécurité des threads**

Ne chargez pas, ne modifiez pas, ne sauvegardez pas et ne clonez pas la même instance de [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) simultanément depuis plusieurs threads. Gardez chaque instance de présentation confinée à une opération de fusion. Si vous parallélisez des travaux indépendants, utilisez des instances de présentation distinctes et suivez les [directives multithreading d’Aspose.Slides](/slides/fr/cpp/multithreading/).

## **FAQ**

**Comment conserver le design original de chaque présentation source ?**

Utilisez [AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) sans fournir de maître ou de mise en page de destination. Aspose.Slides peut automatiquement cloner le maître source lorsqu’il est requis par la diapositive importée.

**Comment faire en sorte que les diapositives importées utilisent le thème de destination ?**

Utilisez la surcharge qui accepte un maître de destination. Passez un maître de la présentation de destination, pas de la source. Aspose.Slides tentera de faire correspondre chaque diapositive source à une mise en page appropriée sous ce maître.

**Quand faut‑il utiliser une mise en page de destination spécifique plutôt qu’un maître de destination ?**

Utilisez une mise en page spécifique lorsque chaque diapositive importée doit utiliser une mise en page connue. Utilisez un maître lorsque vous voulez qu’Aspose.Slides sélectionne parmi les mises en page de ce maître en fonction du type ou du nom de la mise en page source.

**Les présentations avec des tailles de diapositive différentes peuvent‑elles être fusionnées ?**

Oui, mais le contenu des diapositives n’est pas redessiné automatiquement pour les dimensions de destination. Redimensionnez d’abord la présentation source lorsque vous avez besoin d’un placement prévisible, par exemple avec [SlideSize::SetSize](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slidesize/setsize/) et [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slidesizescaletype/).

**Puis‑je fusionner des présentations PPT, PPTX et ODP en un seul fichier ?**

Oui. Chargez chaque présentation source, clonez les diapositives requises dans une destination unique, puis enregistrez la destination dans un format de sortie pris en charge. Comme les formats de présentation ne supportent pas exactement le même ensemble de fonctionnalités, vérifiez le contenu complexe après des fusions inter‑formats. Consultez [Supported File Formats](/slides/fr/cpp/supported-file-formats/).

**Les sections source sont‑elles préservées automatiquement ?**

Pas par une boucle de base qui ne clone que les diapositives. Recréez les sections nécessaires dans la destination et utilisez la surcharge de section de [AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) lorsque la structure des sections doit être conservée.

**Les notes du présentateur et les commentaires sont‑ils préservés ?**

Ils sont copiés avec la diapositive clonée. Pour les flux de travail dépendant du style du maître de notes, des auteurs de commentaires ou des données de révision en fil, vérifiez le résultat fusionné car ces scénarios impliquent également des structures au niveau de la présentation.

**Que se passe‑t‑il avec l’audio, la vidéo, les objets OLE et les hyperliens ?**

Le contenu intégré est transporté comme partie des relations de ressources de la diapositive clonée. Les liens externes restent externes, leurs fichiers cibles ou URL doivent donc rester disponibles après la fusion.

**Les polices incorporées de chaque source sont‑elles garanties d’être disponibles dans la présentation fusionnée ?**

Ne comptez pas uniquement sur le clonage de diapositives pour le déploiement des polices. Inspectez les polices incorporées de la destination et gérez explicitement l’incorporation des polices ou la disponibilité des polices externes lorsque la typographie est importante.

**Comment fusionner un fichier protégé par mot de passe ?**

Ouvrez‑le avec le bon [LoadOptions::set_Password](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_password/), puis clonez ses diapositives normalement. La protection de sortie est configurée séparément.

**Comment gérer des présentations très volumineuses ?**

Utilisez la gestion des BLOB lorsque de gros objets binaires dominent la consommation de mémoire, privilégiez le chargement par chemin de fichier pour les très gros fichiers, libérez rapidement les présentations source et enregistrez le résultat final uniquement lorsque cela est nécessaire.

**Puis‑je fusionner des diapositives depuis plusieurs threads ?**

N’utilisez pas la même instance de [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) simultanément depuis plusieurs threads. Gardez chaque opération de fusion isolée dans ses propres instances de présentation.