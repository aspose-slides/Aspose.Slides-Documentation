---
title: Fusionner efficacement des présentations en PHP
linktitle: Fusionner des présentations
type: docs
weight: 40
url: /fr/php-java/merge-presentation/
keywords:
- fusionner PowerPoint
- fusionner présentations
- fusionner diapositives
- fusionner PPT
- fusionner PPTX
- fusionner ODP
- combiner PowerPoint
- combiner présentations
- combiner diapositives
- combiner PPT
- combiner PPTX
- combiner ODP
- PHP
- Aspose.Slides
description: "Apprenez comment fusionner des présentations PowerPoint et OpenDocument en PHP en clonant des diapositives, en contrôlant les masters et les dispositions, en redimensionnant le contenu des diapositives, en préservant les sections et en gérant les fichiers protégés ou volumineux."
---
## **Vue d'ensemble**

Aspose.Slides for PHP via Java fusionne des présentations en clonant les diapositives d’une [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) vers une autre. L’opération principale est [SlideCollection::addClone()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidecollection/addclone/), qui peut conserver le formatage de la diapositive source ou attacher la diapositive clonée à un master ou à une disposition dans la présentation de destination.

Cet article couvre les flux de travail de fusion les plus courants :

- fusionner toutes les diapositives tout en conservant leur formatage source ;
- fusionner des diapositives sélectionnées ;
- appliquer un master de la présentation de destination ;
- appliquer une disposition spécifique de la présentation de destination ;
- normaliser des tailles de diapositives différentes avant la fusion ;
- ajouter des diapositives clonées à une section ;
- fusionner plusieurs présentations dans un flux de travail complet ;
- gérer les masters, les ressources, les notes, les commentaires, les médias, les polices, les mots de passe, les gros fichiers et les problèmes de multithreading.

## **Comment le clonage de diapositives affecte les masters et les dispositions**

Une diapositive hérite d’une grande partie de son apparence de sa disposition et de son master. Pour cette raison, la surcharge de clonage que vous choisissez détermine la façon dont la diapositive fusionnée est intégrée à la présentation de destination.

Utilisez [SlideCollection::addClone()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidecollection/addclone/) de l’une des manières suivantes :

- `addClone(sourceSlide)` — conserver la disposition et le formatage de la diapositive source. Si nécessaire, le master source peut être cloné automatiquement dans la présentation de destination. Aspose.Slides suit les masters clonés automatiquement afin que les diapositives répétées utilisant le même master source ne provoquent pas de clonage répété de ce master.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — attacher la diapositive clonée à un [MasterSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/) de destination spécifique. Aspose.Slides recherche une disposition correspondante sous ce master par type ou par nom.
- `addClone(sourceSlide, destinationLayout)` — attacher directement la diapositive clonée à un [LayoutSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/) de destination spécifique.

Le master ou la disposition passé à une surcharge `addClone` doit appartenir à la **présentation de destination**, et non à la présentation source.

## **Fusionner des présentations entières en conservant le formatage source**

La fusion la plus simple copie chaque diapositive de la présentation source vers la présentation de destination. C’est le choix approprié lorsque les diapositives importées doivent conserver leur thème, master et relations de disposition d’origine.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

La présentation résultante peut contenir plusieurs masters lorsque la source et la destination utilisent des conceptions différentes. C’est le comportement attendu lorsque le formatage source est intentionnellement conservé.

## **Fusionner des diapositives sélectionnées**

Vous n’avez pas besoin de cloner chaque diapositive. L’exemple suivant importe uniquement les index de diapositives sélectionnés depuis la présentation source.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Validez les index de diapositives avant le clonage lorsqu’ils proviennent d’une entrée utilisateur ou d’une configuration externe.

## **Fusionner des diapositives en utilisant un master de destination**

Utilisez la surcharge [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidecollection/addclone/) lorsque les diapositives importées doivent suivre un master qui appartient déjà à la présentation de destination.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides sélectionne une disposition appropriée sous le master indiqué en faisant correspondre le type ou le nom de la disposition source. Si aucune disposition adéquate n’existe et que `allowCloneMissingLayout` vaut `true`, la disposition source est clonée afin que la diapositive puisse être ajoutée. Si elle vaut `false`, une [PptxEditException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pptxeditexception/) est levée.

Utilisez `false` lorsque vous souhaitez que la fusion échoue plutôt que d’introduire une disposition supplémentaire dans le master de destination.

## **Fusionner des diapositives en utilisant une disposition de destination spécifique**

Utilisez la surcharge [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidecollection/addclone/) lorsque vous savez exactement quelle disposition de destination les diapositives importées doivent utiliser.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

L’application d’une disposition de destination modifie la relation de disposition héritée ; elle ne redessine pas le contenu de la diapositive source. Si les dispositions source et destination possèdent des structures de zones réservées différentes, inspectez le résultat pour confirmer que le formatage hérité et le comportement des zones réservées sont appropriés.

## **Fusionner des présentations avec des tailles de diapositive différentes**

Des présentations avec des dimensions de diapositive différentes peuvent être fusionnées, mais cloner une diapositive dans une présentation dont la taille de diapositive diffère ne redessine pas automatiquement son contenu pour le nouveau canevas. Les formes peuvent donc apparaître déplacées, redimensionnées de façon inattendue ou en dehors de la zone visible de la diapositive.

Une approche pratique consiste à redimensionner la présentation source avant le clonage. La méthode [SlideSize::setSize()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidesize/setsize/) peut mettre à l’échelle le contenu existant tout en modifiant les dimensions des diapositives. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidesizescaletype/) met le contenu à l’échelle pour qu’il tienne dans la taille demandée.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Le redimensionnement modifie l’objet de la présentation source en mémoire. Si vous avez besoin que la présentation source d’origine reste inchangée pour d’autres opérations, ouvrez une instance distincte pour la fusion.

## **Fusionner des diapositives dans une section de présentation**

La boucle de clonage de diapositives de base ne recrée pas la hiérarchie de sections de la présentation source. Si les sections sont importantes dans le résultat, créez ou sélectionnez des sections dans la présentation de destination et clonez les diapositives dedans explicitement avec [addClone(Slide, Section)](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidecollection/addclone/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Les diapositives clonées sont ajoutées à la section de destination spécifiée. Pour conserver plusieurs sections sources, recréez ces sections dans la destination et associez chaque diapositive source à la section de destination correspondante.

## **Fusionner plusieurs présentations en toute sécurité**

L’exemple de bout en bout suivant utilise la première présentation comme destination, normalise la taille de diapositive de chaque source supplémentaire, garde chaque source ouverte uniquement pendant sa copie, et enregistre le fichier final une fois.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

C’est une base utile pour conserver le formatage source des diapositives importées. Si votre résultat doit utiliser un thème unique de destination, remplacez l’appel simple `addClone($slide)` par la surcharge master‑de‑destination ou layout‑de‑destination appropriée présentée plus haut.

## **Considérations pratiques**

### **Masters, dispositions et fidélité du formatage**

Le clonage de diapositives par défaut peut automatiquement introduire un master source requis dans la présentation de destination. Aspose.Slides conserve un registre interne des masters clonés automatiquement afin d’éviter de cloner le même master à plusieurs reprises. Les masters clonés manuellement ne sont pas suivis par ce registre, évitez donc de pré‑cloner les masters sauf si vous avez besoin d’un contrôle explicite sur la structure du master.

Ne partez pas du principe que deux masters ou deux dispositions portant le même nom sont visuellement équivalents. Si un modèle d’entreprise doit contrôler l’apparence finale, choisissez explicitement un master ou une disposition de destination et vérifiez le résultat après la fusion.

### **Notes et commentaires**

Les notes du présentateur et les commentaires de diapositive sont associés au contenu de la diapositive et sont copiés lorsqu’une diapositive est clonée. Aspose.Slides propose également des API dédiées pour les [notes de présentation](https://docs.aspose.com/slides/fr/php-java/presentation-notes/) et les [commentaires de présentation](https://docs.aspose.com/slides/fr/php-java/presentation-comments/).

Si le formatage de la page de notes est important, vérifiez la présentation fusionnée car les masters de notes sont des objets au niveau de la présentation et peuvent différer entre les fichiers sources. Pour les flux de révision, vérifiez également les auteurs des commentaires et les commentaires en fil après avoir combiné des fichiers provenant d’auteurs ou de modèles différents.

### **Images, audio, vidéo, objets OLE et liens externes**

Les diapositives peuvent référencer des ressources au niveau de la présentation : images, audio intégré, vidéo intégrée et données OLE. Clonez la diapositive elle‑même plutôt que de copier uniquement ses formes visibles afin qu’Aspose.Slides puisse maintenir les relations de la diapositive avec ses ressources.

Les ressources incorporées et les ressources liées doivent être traitées différemment. Un audio, une vidéo, un objet OLE ou un hyperlien lié demeure dépendant de sa cible externe ; le clonage d’une diapositive ne transforme pas un lien externe en contenu incorporé. Testez les chemins et les URL des ressources liées dans l’environnement où la présentation fusionnée sera ouverte.

Aspose.Slides suit explicitement les masters clonés automatiquement, mais cela ne doit pas être considéré comme une garantie générale que des ressources binaires identiques provenant de présentations sources différentes seront toujours dédupliquées. Si la taille du fichier de sortie est importante, inspectez le package fusionné et mesurez le résultat plutôt que de compter sur la déduplication implicite.

### **Polices incorporées et disponibilité des polices**

Les polices sont gérées au niveau de la présentation. Si la typographie doit rester cohérente d’une machine à l’autre, ne supposez pas que le simple clonage de diapositives garantit que chaque police requise est disponible dans l’environnement de destination. Vous pouvez inspecter les polices incorporées avec [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/getembeddedfonts/) et gérer l’incorporation explicitement comme décrit dans [Incorporer des polices dans les présentations](https://docs.aspose.com/slides/fr/php-java/embedded-font/).

Vérifiez également que vous êtes autorisé à incorporer les polices utilisées par les fichiers sources. Les licences de polices peuvent restreindre l’incorporation.

### **Présentations protégées par mot de passe**

Une source protégée par mot de passe doit être ouverte avec succès avant que ses diapositives puissent être clonées. Fournissez le mot de passe via [LoadOptions::setPassword()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/setpassword/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Travaillez avec la présentation déchiffrée.
} finally {
    $source->dispose();
}
```

L’ouverture d’une source chiffrée n’applique pas automatiquement la même protection à la présentation de destination. Configurez la protection de sortie séparément si nécessaire.

### **Présentations volumineuses et utilisation de la mémoire**

Les présentations volumineuses contenant des images haute résolution, de l’audio, de la vidéo ou d’autres gros objets binaires peuvent consommer beaucoup de mémoire. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) offre des contrôles pour la gestion des BLOB et l’utilisation de fichiers temporaires. Consultez [Ouvrir des présentations](https://docs.aspose.com/slides/fr/php-java/open-presentation/#open-large-presentations) pour un exemple PHP via Java de gros fichiers.

Pour les gros fichiers, privilégiez le chargement depuis des chemins de fichier lorsqu’il est possible, libérez chaque présentation source dès qu’elle a été fusionnée, et évitez d’enregistrer de façon répétée des résultats intermédiaires sauf si le flux de travail impose des points de contrôle.

### **Sécurité des threads**

Ne chargez, modifiez, enregistrez ou clonez pas d’instances de [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) dans plusieurs threads. Ces opérations ne sont pas prises en charge pour une utilisation multithread en PHP via Java. Si vous avez besoin de travaux de fusion parallèles, exécutez‑les dans des processus séparés monothreads, chaque processus utilisant ses propres instances de présentation, et suivez les [directives multithreading d’Aspose.Slides](https://docs.aspose.com/slides/fr/php-java/multithreading/).

## **FAQ**

**Comment conserver le design original de chaque présentation source ?**

Utilisez [`addClone(sourceSlide)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidecollection/addclone/) sans fournir de master ou de disposition de destination. Aspose.Slides peut cloner automatiquement le master source lorsqu’il est nécessaire pour la diapositive importée.

**Comment faire en sorte que les diapositives importées utilisent le thème de destination ?**

Utilisez la surcharge qui accepte un master de destination. Passez un master de la présentation de destination, pas de la source. Aspose.Slides tentera de mapper chaque diapositive source à une disposition appropriée sous ce master.

**Quand faut‑il utiliser une disposition de destination spécifique plutôt qu’un master de destination ?**

Utilisez une disposition spécifique lorsque chaque diapositive importée doit utiliser une disposition connue. Utilisez un master lorsque vous voulez qu’Aspose.Slides sélectionne parmi les dispositions de ce master en fonction du type ou du nom de la disposition source.

**Les présentations avec des tailles de diapositive différentes peuvent‑elles être fusionnées ?**

Oui, mais le contenu des diapositives n’est pas automatiquement redessiné pour les dimensions de destination. Redimensionnez d’abord la présentation source lorsque vous avez besoin d’un placement prévisible, par exemple avec [SlideSize::setSize()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidesize/setsize/) et [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidesizescaletype/).

**Puis‑je fusionner des présentations PPT, PPTX et ODP en un seul fichier ?**

Oui. Chargez chaque présentation source, clonez les diapositives requises dans une destination unique, puis enregistrez la destination dans un format de sortie pris en charge. Parce que les formats de présentation ne supportent pas exactement le même ensemble de fonctionnalités, vérifiez le contenu complexe après des fusions inter‑format. Voir [Formats de fichiers pris en charge](https://docs.aspose.com/slides/fr/php-java/supported-file-formats/).

**Les sections sources sont‑elles préservées automatiquement ?**

Pas avec une boucle de base qui ne clone que les diapositives. Recréez les sections requises dans la destination et utilisez la surcharge de section de [addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidecollection/addclone/) lorsque la structure des sections doit être conservée.

**Les notes du présentateur et les commentaires sont‑ils conservés ?**

Ils sont copiés avec la diapositive clonée. Pour les flux qui dépendent du style du master de notes, des auteurs de commentaires ou des données de révision en fil, vérifiez le résultat fusionné car ces scénarios impliquent également des structures au niveau de la présentation.

**Que se passe‑t‑il avec l’audio, la vidéo, les objets OLE et les hyperliens ?**

Le contenu incorporé est transporté avec les relations de ressources de la diapositive clonée. Les liens externes restent externes, leurs fichiers cibles ou URL doivent donc rester accessibles après la fusion.

**Les polices incorporées de chaque source sont‑elles garanties d’être disponibles dans la présentation fusionnée ?**

Ne comptez pas uniquement sur le clonage de diapositives pour le déploiement des polices. Inspectez les polices incorporées de la destination et gérez explicitement l’incorporation des polices ou la disponibilité des polices externes lorsque la typographie est importante.

**Comment fusionner un fichier protégé par mot de passe ?**

Ouvrez‑le avec le bon [LoadOptions::setPassword()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/setpassword/), puis clonez ses diapositives normalement. La protection de sortie est configurée séparément.

**Comment gérer des présentations très volumineuses ?**

Utilisez la gestion des BLOB lorsque les gros objets binaires dominent l’utilisation de la mémoire, privilégiez le chargement par chemin de fichier pour les très gros fichiers, libérez rapidement les présentations sources, et enregistrez le résultat final uniquement quand cela est nécessaire.

**Puis‑je fusionner des diapositives depuis plusieurs threads ?**

Le chargement, l’enregistrement ou le clonage de présentations dans plusieurs threads n’est pas pris en charge en PHP via Java. Pour du travail parallèle, utilisez des processus séparés monothreads et maintenez les instances de présentation isolées dans chaque processus.