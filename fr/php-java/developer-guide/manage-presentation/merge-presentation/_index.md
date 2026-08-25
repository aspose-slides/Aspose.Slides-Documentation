---
title: Fusionner efficacement les présentations en PHP
linktitle: Fusionner les présentations
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
description: Apprenez à fusionner des présentations PowerPoint et OpenDocument en PHP en clonant des diapositives, en contrôlant les masters et les dispositions, en redimensionnant le contenu des diapositives, en préservant les sections et en gérant les fichiers protégés ou volumineux.
---
## **Vue d'ensemble**

Aspose.Slides for PHP via Java fusionne des présentations en clonant des diapositives d’une [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) vers une autre. L’opération principale est [SlideCollection::addClone()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidecollection/addclone/), qui peut préserver le formatage de la diapositive source ou attacher la diapositive clonée à un master ou à une disposition dans la présentation de destination.

Cet article couvre les flux de travail de fusion les plus courants :

- fusionner toutes les diapositives en conservant leur formatage source ;
- fusionner des diapositives sélectionnées ;
- appliquer un master de la présentation de destination ;
- appliquer une disposition spécifique de la présentation de destination ;
- normaliser des tailles de diapositives différentes avant la fusion ;
- ajouter des diapositives clonées à une section ;
- fusionner plusieurs présentations dans un flux de travail de bout en bout ;
- gérer les masters, ressources, notes, commentaires, médias, polices, mots de passe, gros fichiers et les problèmes de multithreading.

## **Comment le clonage de diapositives affecte les masters et les dispositions**

Une diapositive hérite d’une grande partie de son apparence de sa disposition et de son master. Pour cette raison, la surcharge de clonage que vous choisissez détermine comment la diapositive fusionnée est intégrée dans la présentation de destination.

Utilisez [SlideCollection::addClone()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidecollection/addclone/) de l’une des manières suivantes :

- `addClone(sourceSlide)` — préserve la disposition et le formatage de la diapositive source. Si nécessaire, le master source peut être cloné automatiquement dans la présentation de destination. Aspose.Slides suit les masters clonés automatiquement afin que les diapositives répétées utilisant le même master source ne provoquent pas de clonage répété de ce master.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — attache la diapositive clonée à un [MasterSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/) de destination spécifique. Aspose.Slides recherche une disposition correspondante sous ce master par type ou par nom.
- `addClone(sourceSlide, destinationLayout)` — attache directement la diapositive clonée à une [LayoutSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/) de destination spécifique.

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

La présentation résultante peut contenir plusieurs masters lorsque la source et la destination utilisent des conceptions différentes. C’est le comportement attendu lorsque le formatage source est intentionnellement préservé.

## **Fusionner des diapositives sélectionnées**

Vous n’avez pas besoin de cloner chaque diapositive. L’exemple suivant importe uniquement les indices de diapositives sélectionnés depuis la présentation source.

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

Validez les indices de diapositives avant le clonage lorsqu’ils proviennent d’une saisie utilisateur ou d’une configuration externe.

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

Aspose.Slides sélectionne une disposition appropriée sous le master spécifié en faisant correspondre le type ou le nom de la disposition source. Si aucune disposition adaptée n’existe et que `allowCloneMissingLayout` vaut `true`, la disposition source est clonée afin que la diapositive puisse être ajoutée. Si elle vaut `false`, une [PptxEditException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pptxeditexception/) est levée.

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

L’application d’une disposition de destination modifie la relation de disposition héritée ; elle ne redessine pas le contenu de la diapositive source. Si les dispositions source et destination ont des structures d’espace réservé différentes, inspectez le résultat pour vérifier que le formatage hérité et le comportement des espaces réservés sont appropriés.

## **Fusionner des présentations avec des tailles de diapositive différentes**

Des présentations avec des dimensions de diapositive différentes peuvent être fusionnées, mais le clonage d’une diapositive dans une présentation dont la taille de diapositive diffère ne redessine pas automatiquement son contenu pour le nouveau canevas. Les formes peuvent donc apparaître déplacées, mises à l’échelle de façon inattendue ou en dehors de la zone visible.

Une approche pratique consiste à redimensionner la présentation source avant le clonage. La méthode [SlideSize::setSize()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidesize/setsize/) peut mettre à l’échelle le contenu existant tout en modifiant les dimensions de la diapositive. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidesizescaletype/) met le contenu à l’échelle pour qu’il s’ajuste à la taille demandée.

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

Le redimensionnement modifie l’objet présentation source en mémoire. Si vous devez conserver la présentation source d’origine inchangée pour d’autres opérations, ouvrez une instance distincte pour la fusion.

## **Fusionner des diapositives dans une section de présentation**

La boucle de clonage de diapositives de base ne recrée pas la hiérarchie de sections de la présentation source. Si les sections sont importantes dans le résultat, créez ou sélectionnez des sections dans la présentation de destination et clonez les diapositives dans celles‑ci explicitement avec [addClone(Slide, Section)](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidecollection/addclone/).

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

Les diapositives clonées sont ajoutées à la section de destination spécifiée. Pour conserver plusieurs sections sources, parcourez [Presentation::getSections](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation/#getSections), récupérez les diapositives actuelles de chaque section source avec [Section::getSlidesListOfSection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Section/#getSlidesListOfSection), recréez les sections dans la destination et clonez chaque diapositive retournée dans la section de destination correspondante. Consultez [Manage Slide Sections](/slides/fr/php-java/slide-section/) pour un exemple complet d’énumération de sections, incluant les sections vides et les changements structurels.

## **Fusionner plusieurs présentations en toute sécurité**

L’exemple de bout en bout suivant utilise la première présentation comme destination, normalise la taille de diapositive de chaque source supplémentaire, ne garde chaque source ouverte que pendant son copié, puis enregistre le fichier final une seule fois.

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

C’est une base utile pour préserver le formatage source des diapositives importées. Si votre résultat doit utiliser un thème de destination unique, remplacez l’appel simple `addClone($slide)` par la surcharge master‑ou‑disposition de destination appropriée montrée précédemment.

## **Considérations pratiques**

### **Masters, dispositions et fidélité du formatage**

Le clonage par défaut des diapositives peut introduire automatiquement le master source requis dans la présentation de destination. Aspose.Slides conserve un registre interne des masters clonés automatiquement afin d’éviter de cloner le même master plusieurs fois. Les masters clonés manuellement ne sont pas suivis par ce registre, évitez donc le pré‑clonage des masters sauf si vous avez besoin d’un contrôle explicite de la structure du master.

Ne supposez pas que deux masters ou dispositions portant le même nom soient visuellement équivalents. Si un modèle d’entreprise doit contrôler l’apparence finale, choisissez explicitement un master ou une disposition de destination et vérifiez le résultat après la fusion.

### **Notes et commentaires**

Les notes du présentateur et les commentaires de diapositive sont associés au contenu de la diapositive et sont copiés lorsqu’une diapositive est clonée. Aspose.Slides propose également des API dédiées aux [presentation notes](/slides/fr/php-java/presentation-notes/) et aux [presentation comments](/slides/fr/php-java/presentation-comments/).

Si le formatage de la page de notes est important, vérifiez la présentation fusionnée car les masters de notes sont des objets au niveau de la présentation et peuvent différer entre les fichiers source. Pour les flux de travail de révision, vérifiez également les auteurs des commentaires et les fils de discussion après avoir combiné des fichiers provenant d’auteurs ou de modèles différents.

### **Images, audio, vidéo, objets OLE et liens externes**

Les diapositives peuvent référencer des ressources au niveau de la présentation telles que des images, audio intégré, vidéo intégrée et données OLE. Clonez la diapositive elle‑même plutôt que de copier uniquement ses formes visibles afin qu’Aspose.Slides puisse maintenir les relations de la diapositive avec ses ressources.

Les ressources incorporées et les ressources liées doivent être traitées différemment. Un audio, une vidéo, un objet OLE ou un hyperlien lié reste dépendant de sa cible externe ; le clonage d’une diapositive ne transforme pas un lien externe en contenu incorporé. Testez les chemins et les URL des ressources liées dans l’environnement où la présentation fusionnée sera ouverte.

Aspose.Slides suit explicitement les masters clonés automatiquement, mais cela ne constitue pas une garantie générale que des ressources binaires identiques provenant de présentations sources différentes seront toujours dédupliquées. Si la taille du fichier de sortie est importante, examinez le paquet fusionné et mesurez le résultat plutôt que de compter sur une déduplication implicite.

### **Polices incorporées et disponibilité des polices**

Les polices sont gérées au niveau de la présentation. Si la typographie doit rester cohérente sur différents ordinateurs, ne supposez pas que le clonage de diapositives seul garantit que chaque police requise est disponible dans l’environnement de destination. Vous pouvez examiner les polices incorporées avec [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/getembeddedfonts/) et gérer l’incorporation explicitement comme décrit dans [Embed Fonts in Presentations](/slides/fr/php-java/embedded-font/).

Vérifiez également que vous êtes autorisé à incorporer les polices utilisées par les fichiers source. Les licences de police peuvent restreindre l’incorporation.

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
    // Travailler avec la présentation décryptée.
} finally {
    $source->dispose();
}
```

L’ouverture d’une source chiffrée n’applique pas automatiquement la même protection à la présentation de destination. Configurez la protection de sortie séparément si nécessaire.

### **Présentations volumineuses et utilisation de la mémoire**

Les présentations volumineuses contenant des images haute résolution, de l’audio, de la vidéo ou d’autres gros objets binaires peuvent consommer une mémoire importante. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) fournit des contrôles pour la gestion des BLOB et l’utilisation de fichiers temporaires. Consultez [Open Presentations](/slides/fr/php-java/open-presentation/#open-large-presentations) pour un exemple PHP via Java de fichier volumineux.

Pour les gros fichiers, privilégiez le chargement depuis des chemins de fichiers lorsque c’est possible, libérez chaque présentation source dès qu’elle a été fusionnée et évitez d’enregistrer à plusieurs reprises des résultats intermédiaires sauf si le flux de travail nécessite des points de contrôle.

### **Sécurité des threads**

Ne chargez, modifiez, enregistrez ou clonez pas des instances de [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) dans plusieurs threads. Ces opérations ne sont pas prises en charge pour une utilisation multithread en PHP via Java. Si vous avez besoin de travaux de fusion parallèles, exécutez‑les dans des processus séparés mono‑thread, chaque processus utilisant ses propres instances de présentation, et suivez les directives de [Aspose.Slides multithreading](/slides/fr/php-java/multithreading/).

## **FAQ**

**Comment conserver le design original de chaque présentation source ?**

Utilisez [SlideCollection::addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidecollection/addclone/) sans fournir de master ou de disposition de destination. Aspose.Slides peut cloner automatiquement le master source lorsqu’il est nécessaire à la diapositive importée.

**Comment faire en sorte que les diapositives importées utilisent le thème de destination ?**

Utilisez la surcharge qui accepte un master de destination. transmettez un master provenant de la présentation de destination, pas de la source. Aspose.Slides essaiera de faire correspondre chaque diapositive source à une disposition appropriée sous ce master.

**Quand faut‑il utiliser une disposition de destination spécifique plutôt qu’un master de destination ?**

Utilisez une disposition spécifique lorsque chaque diapositive importée doit utiliser une disposition connue. Utilisez un master lorsque vous souhaitez qu’Aspose.Slides sélectionne parmi les dispositions de ce master en fonction du type ou du nom de la disposition source.

**Les présentations avec des tailles de diapositive différentes peuvent‑elles être fusionnées ?**

Oui, mais le contenu des diapositives n’est pas automatiquement redessiné pour les dimensions de destination. Redimensionnez d’abord la présentation source lorsque vous avez besoin d’un placement prévisible, par exemple avec [SlideSize::setSize()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidesize/setsize/) et [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidesizescaletype/).

**Puis‑je fusionner des présentations PPT, PPTX et ODP en un seul fichier ?**

Oui. Chargez chaque présentation source, clonez les diapositives requises dans une destination unique et enregistrez la destination dans un format de sortie pris en charge. Parce que les formats de présentation ne supportent pas exactement le même ensemble de fonctionnalités, vérifiez le contenu complexe après les fusions inter‑formats. Consultez [Supported File Formats](/slides/fr/php-java/supported-file-formats/).

**Les sections sources sont‑elles préservées automatiquement ?**

Pas par une boucle de base qui ne clone que les diapositives. Recréez les sections requises dans la destination et utilisez la surcharge de section de [addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidecollection/addclone/) lorsque la structure des sections doit être conservée.

**Les notes du présentateur et les commentaires sont‑ils conservés ?**

Ils sont copiés avec la diapositive clonée. Pour les flux de travail dépendant du style du master de notes, des auteurs de commentaires ou des discussions en fil, vérifiez le résultat fusionné car ces scénarios impliquent également des structures au niveau de la présentation.

**Que se passe‑t‑il avec l’audio, la vidéo, les objets OLE et les hyperliens ?**

Le contenu incorporé est transporté comme partie des relations de ressources de la diapositive clonée. Les liens externes restent externes, leurs fichiers cibles ou URL devant donc être disponibles après la fusion.

**Les polices incorporées de chaque source sont‑elles garanties d’être disponibles dans la présentation fusionnée ?**

Ne comptez pas uniquement sur le clonage de diapositives pour le déploiement des polices. Examinez les polices incorporées de la destination et gérez explicitement l’incorporation ou la disponibilité des polices externes lorsque la typographie est importante.

**Comment fusionner un fichier protégé par mot de passe ?**

Ouvrez‑le avec le bon [LoadOptions::setPassword()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/setpassword/), puis clonez ses diapositives normalement. La protection de sortie est configurée séparément.

**Comment gérer des présentations très volumineuses ?**

Utilisez la gestion des BLOB lorsque de gros objets binaires dominent l’utilisation de la mémoire, privilégiez le chargement depuis le système de fichiers pour les très gros fichiers, libérez rapidement les présentations source et enregistrez le résultat final uniquement lorsque c’est nécessaire.

**Puis‑je fusionner des diapositives depuis plusieurs threads ?**

Le chargement, l’enregistrement ou le clonage de présentations dans plusieurs threads n’est pas supporté en PHP via Java. Pour un travail parallèle, utilisez des processus séparés mono‑thread et maintenez les instances de présentation isolées dans chaque processus.