---
title: Fusionner efficacement des présentations avec Python
linktitle: Fusionner des présentations
type: docs
weight: 40
url: /fr/python-net/merge-presentation/
keywords:
- fusion PowerPoint
- fusionner les présentations
- fusionner les diapositives
- fusionner PPT
- fusionner PPTX
- fusionner ODP
- combiner PowerPoint
- combiner les présentations
- combiner les diapositives
- combiner PPT
- combiner PPTX
- combiner ODP
- Python
- Aspose.Slides
description: "Apprenez à fusionner des présentations PowerPoint et OpenDocument en Python en clonant des diapositives, en contrôlant les maîtres et les mises en page, en redimensionnant le contenu des diapositives, en préservant les sections et en gérant les fichiers protégés ou volumineux."
---
## **Vue d'ensemble**

Aspose.Slides for Python via .NET fusionne des présentations en clonant des diapositives d’une [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) vers une autre. L’opération principale est [SlideCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/add_clone/), qui peut conserver la mise en forme de la diapositive source ou rattacher la diapositive clonée à un maître ou à une mise en page dans la présentation de destination.

Cet article couvre les flux de travail de fusion les plus courants :

- fusionner toutes les diapositives tout en conservant leur mise en forme d'origine ;
- fusionner des diapositives sélectionnées ;
- appliquer un maître de la présentation de destination ;
- appliquer une mise en page spécifique de la présentation de destination ;
- normaliser des tailles de diapositives différentes avant la fusion ;
- ajouter des diapositives clonées à une section ;
- fusionner plusieurs présentations dans un flux de travail de bout en bout ;
- gérer les maîtres, ressources, notes, commentaires, médias, polices, mots de passe, gros fichiers et considérations de multithreading.

## **Comment le clonage de diapositives affecte les maîtres et les mises en page**

Une diapositive hérite en grande partie de son apparence de sa mise en page et de son maître. Pour cette raison, la surcharge de clonage que vous choisissez détermine comment la diapositive fusionnée est intégrée à la présentation de destination.

Utilisez [SlideCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/add_clone/) de l’une des manières suivantes :

- `add_clone(source_slide)` — conserve la mise en page et la mise en forme de la diapositive source. Si nécessaire, le maître source peut être cloné automatiquement dans la présentation de destination. Aspose.Slides suit les maîtres clonés automatiquement afin que les diapositives répétées utilisant le même maître source ne provoquent pas un clonage répété de ce maître.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — rattache la diapositive clonée à un [IMasterSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imasterslide/) de destination spécifique. Aspose.Slides recherche une mise en page correspondante sous ce maître par type ou par nom.
- `add_clone(source_slide, destination_layout)` — rattache directement la diapositive clonée à un [ILayoutSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ilayoutslide/) de destination spécifique.

Le maître ou la mise en page passé à une surcharge `add_clone` doit appartenir à la **destination** et non à la présentation source.

## **Fusionner des présentations entières et conserver la mise en forme d'origine**

La fusion la plus simple copie chaque diapositive de la présentation source vers la présentation de destination. C’est le choix approprié lorsque les diapositives importées doivent garder leur thème, maître et relations de mise en page d’origine.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

La présentation résultante peut contenir plusieurs maîtres lorsque la source et la destination utilisent des conceptions différentes. C’est le comportement attendu lorsqu’on conserve intentionnellement la mise en forme source.

## **Fusionner des diapositives sélectionnées**

Il n’est pas nécessaire de cloner chaque diapositive. L’exemple suivant importe uniquement les indices de diapositives sélectionnés depuis la présentation source.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

Validez les indices de diapositives avant le clonage lorsqu’ils proviennent d’une saisie utilisateur ou d’une configuration externe.

## **Fusionner des diapositives en utilisant un maître de destination**

Utilisez la surcharge [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/add_clone/) lorsque les diapositives importées doivent suivre un maître qui appartient déjà à la présentation de destination.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides sélectionne une mise en page appropriée sous le maître spécifié en faisant correspondre le type ou le nom de la mise en page source. Si aucune mise en page adaptée n’existe et que `allow_clone_missing_layout` est `True`, la mise en page source est clonée afin que la diapositive puisse être ajoutée. Si elle est `False`, une [PptxEditException](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pptxeditexception/) est levée.

Utilisez `False` lorsque vous souhaitez que la fusion échoue au lieu d’introduire une mise en page supplémentaire dans le maître de destination.

## **Fusionner des diapositives en utilisant une mise en page de destination spécifique**

Utilisez la surcharge [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/add_clone/) lorsque vous savez exactement quelle mise en page de destination les diapositives importées doivent utiliser.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

Appliquer une mise en page de destination modifie la relation de mise en page héritée ; cela ne redessine pas le contenu de la diapositive source. Si les mises en page source et destination ont des structures de zones réservées différentes, inspectez le résultat pour confirmer que la mise en forme héritée et le comportement des zones réservées sont appropriés.

## **Fusionner des présentations avec des tailles de diapositives différentes**

Des présentations ayant des dimensions de diapositives différentes peuvent être fusionnées, mais cloner une diapositive dans une présentation avec une autre taille de diapositive ne redessine pas automatiquement son contenu pour le nouveau canevas. Les formes peuvent ainsi apparaître déplacées, redimensionnées de façon inattendue ou hors de la zone visible.

Une approche pratique consiste à redimensionner la présentation source avant le clonage. La méthode [SlideSize.set_size](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidesize/set_size/) peut mettre à l’échelle le contenu existant tout en modifiant les dimensions de la diapositive. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidesizescaletype/) met le contenu à l’échelle pour qu’il tienne dans la taille demandée.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        if (
            source.slide_size.size.width != destination.slide_size.size.width
            or source.slide_size.size.height != destination.slide_size.size.height
        ):
            source.slide_size.set_size(
                destination.slide_size.size.width,
                destination.slide_size.size.height,
                slides.SlideSizeScaleType.ENSURE_FIT)

        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged-same-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

Le redimensionnement modifie l’objet de présentation source en mémoire. Si vous devez conserver la présentation source d’origine inchangée pour d’autres opérations, ouvrez une instance distincte pour la fusion.

## **Fusionner des diapositives dans une section de présentation**

La boucle de clonage de base ne recrée pas la hiérarchie de sections de la présentation source. Si les sections sont importantes dans le résultat, créez ou sélectionnez des sections dans la présentation de destination et clonez les diapositives dans celles‑ci explicitement avec [SlideCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/add_clone/).

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

Les diapositives clonées sont ajoutées à la section de destination spécifiée. Pour préserver plusieurs sections source, parcourez [Presentation.sections](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/sections/), récupérez les diapositives actuelles de chaque section source avec [Section.get_slides_list_of_section](https://reference.aspose.com/slides/fr/python-net/aspose.slides/section/get_slides_list_of_section/), recréez les sections dans la destination et clonez chaque diapositive retournée dans sa section de destination correspondante. Voir [Manage Slide Sections](/slides/fr/python-net/slide-section/) pour un exemple complet d’énumération des sections, y compris les sections vides et les changements structurels.

## **Fusionner plusieurs présentations en toute sécurité**

L’exemple de bout en bout suivant utilise la première présentation comme destination, normalise la taille des diapositives de chaque source supplémentaire, ne garde chaque source ouverte que pendant son copiage, et enregistre le fichier final une seule fois.

```python
import aspose.slides as slides

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

with slides.Presentation(input_files[0]) as merged:
    for file_index in range(1, len(input_files)):
        with slides.Presentation(input_files[file_index]) as source:
            if (
                source.slide_size.size.width != merged.slide_size.size.width
                or source.slide_size.size.height != merged.slide_size.size.height
            ):
                source.slide_size.set_size(
                    merged.slide_size.size.width,
                    merged.slide_size.size.height,
                    slides.SlideSizeScaleType.ENSURE_FIT)

            for slide in source.slides:
                merged.slides.add_clone(slide)

    merged.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

C’est une base utile pour conserver la mise en forme source des diapositives importées. Si votre résultat doit utiliser un thème unique de destination, remplacez l’appel simple `add_clone(slide)` par la surcharge maître‑de‑destination ou mise‑en‑page‑de‑destination appropriée présentée plus haut.

## **Considérations pratiques**

### **Maîtres, mises en page et fidélité de la mise en forme**

Le clonage de diapositives par défaut peut automatiquement introduire un maître source requis dans la présentation de destination. Aspose.Slides maintient un registre interne des maîtres clonés automatiquement afin d’éviter un clonage répété du même maître. Les maîtres clonés manuellement ne sont pas suivis par ce registre, évitez donc de pré‑cloner les maîtres sauf si vous avez besoin d’un contrôle explicite de la structure du maître.

Ne supposez pas que deux maîtres ou deux mises en page portant le même nom soient visuellement équivalents. Si un modèle d’entreprise doit contrôler l’apparence finale, choisissez explicitement un maître ou une mise en page de destination et vérifiez le résultat après la fusion.

### **Notes et commentaires**

Les notes du présentateur et les commentaires de diapositive sont associés au contenu de la diapositive et sont copiés lors du clonage. Aspose.Slides expose également des API dédiées pour les [presentation notes](/slides/fr/python-net/presentation-notes/) et les [presentation comments](/slides/fr/python-net/presentation-comments/).

Si la mise en forme de la page de notes est importante, vérifiez la présentation fusionnée car les maîtres de notes sont des objets au niveau de la présentation et peuvent différer entre les fichiers source. Pour les flux de travail de révision, vérifiez également les auteurs des commentaires et les fils de commentaires après avoir combiné des fichiers provenant d’auteurs ou de modèles différents.

### **Images, audio, vidéo, objets OLE et liens externes**

Les diapositives peuvent faire référence à des ressources au niveau de la présentation telles que des images, de l’audio intégré, de la vidéo intégrée et des données OLE. Clonez la diapositive elle‑même plutôt que de copier uniquement les formes visibles afin qu’Aspose.Slides maintienne les relations de la diapositive avec ses ressources.

Les ressources intégrées et les ressources liées doivent être traitées différemment. Un audio, une vidéo, un objet OLE ou un hyperlien lié restent dépendants de leur cible externe ; cloner une diapositive ne transforme pas un lien externe en contenu intégré. Testez les chemins et les URL des ressources liées dans l’environnement où la présentation fusionnée sera ouverte.

Aspose.Slides suit explicitement les maîtres clonés automatiquement, mais cela ne doit pas être considéré comme une garantie générale que des ressources binaires identiques provenant de présentations sources différentes seront toujours dédupliquées. Si la taille du fichier de sortie est importante, inspectez le package fusionné et mesurez le résultat plutôt que de vous fier à une déduplication implicite.

### **Polices incorporées et disponibilité des polices**

Les polices sont gérées au niveau de la présentation. Si la typographie doit rester cohérente d’une machine à l’autre, ne supposez pas que le clonage de diapositives seul garantit que chaque police requise est disponible dans l’environnement de destination. Vous pouvez inspecter les polices incorporées avec [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) et gérer l’incorporation explicitement comme décrit dans [Embed Fonts in Presentations](/slides/fr/python-net/embedded-font/).

Vérifiez également que vous êtes autorisé à incorporer les polices utilisées par les fichiers source. Les licences de police peuvent restreindre l’incorporation.

### **Présentations protégées par mot de passe**

Une source protégée par mot de passe doit être ouverte correctement avant que ses diapositives puissent être clonées. Fournissez le mot de passe via [LoadOptions.password](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/password/).

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

L’ouverture d’une source chiffrée n’applique pas automatiquement la même protection à la présentation de destination. Configurez la protection de sortie séparément si nécessaire.

### **Grandes présentations et utilisation de la mémoire**

Les présentations volumineuses contenant des images haute résolution, de l’audio, de la vidéo ou d’autres gros objets binaires peuvent consommer beaucoup de mémoire. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/blob_management_options/) offre des contrôles pour la gestion des BLOB et l’utilisation de fichiers temporaires. Voir [Manage Presentation BLOBs](/slides/fr/python-net/manage-blob/) pour des stratégies de gros fichiers.

Pour les gros fichiers, privilégiez le chargement depuis des chemins de fichier lorsque c’est possible, fermez chaque présentation source dès qu’elle a été fusionnée, et évitez d’enregistrer à plusieurs reprises des résultats intermédiaires sauf si le flux de travail nécessite des points de contrôle. L’utilisation de `with slides.Presentation(...)` garantit que les ressources de la présentation sont libérées à la sortie du contexte.

### **Sécurité du multithreading**

Ne chargez, n’enregistrez ni ne clonez une instance de [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) simultanément depuis plusieurs threads. Gardez chaque opération de fusion monothread. Si vous parallélisez des travaux de fusion indépendants, utilisez des processus monothread séparés et des instances de présentation indépendantes comme décrit dans le [Aspose.Slides multithreading guidance](/slides/fr/python-net/multithreading/).

## **FAQ**

**Comment conserver le design original de chaque présentation source ?**

Utilisez [add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/add_clone/) sans fournir de maître ou de mise en page de destination. Aspose.Slides peut automatiquement cloner le maître source lorsqu’il est nécessaire pour la diapositive importée.

**Comment faire en sorte que les diapositives importées utilisent le thème de destination ?**

Utilisez la surcharge qui accepte un maître de destination. Fournissez un maître provenant de la présentation de destination, pas de la source. Aspose.Slides essaiera de mapper chaque diapositive source à une mise en page appropriée sous ce maître.

**Quand faut‑il utiliser une mise en page de destination spécifique au lieu d’un maître de destination ?**

Utilisez une mise en page spécifique lorsque chaque diapositive importée doit utiliser une mise en page connue. Utilisez un maître lorsque vous voulez qu’Aspose.Slides sélectionne parmi les mises en page de ce maître en fonction du type ou du nom de la mise en page source.

**Les présentations avec des tailles de diapositives différentes peuvent‑elles être fusionnées ?**

Oui, mais le contenu des diapositives n’est pas automatiquement redessiné pour les dimensions de destination. Redimensionnez d’abord la présentation source lorsque vous avez besoin d’un placement prévisible, par exemple avec [SlideSize.set_size](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidesize/set_size/) et [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidesizescaletype/).

**Puis‑je fusionner des présentations PPT, PPTX et ODP en un seul fichier ?**

Oui. Chargez chaque présentation source, clonez les diapositives requises dans une destination unique, puis enregistrez la destination dans un format de sortie pris en charge. Comme les formats de présentation ne supportent pas exactement le même ensemble de fonctionnalités, vérifiez le contenu complexe après des fusions inter‑formats. Voir [Supported File Formats](/slides/fr/python-net/supported-file-formats/).

**Les sections source sont‑elles préservées automatiquement ?**

Pas par une boucle de base qui ne fait que cloner les diapositives. Recréez les sections nécessaires dans la destination et utilisez la surcharge de section de [add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/add_clone/) lorsque la structure des sections doit être conservée.

**Les notes du présentateur et les commentaires sont‑ils préservés ?**

Ils sont copiés avec la diapositive clonée. Pour les flux de travail qui dépendent du style du maître de notes, des auteurs de commentaires ou des fils de révision, vérifiez le résultat fusionné car ces scénarios impliquent également des structures au niveau de la présentation.

**Que se passe‑t‑il avec l’audio, la vidéo, les objets OLE et les hyperliens ?**

Le contenu intégré est transporté avec les relations de ressources de la diapositive clonée. Les liens externes restent externes, de sorte que leurs fichiers cibles ou URL doivent toujours être disponibles après la fusion.

**Les polices incorporées de chaque source sont‑elles garanties d’être disponibles dans la présentation fusionnée ?**

Ne comptez pas uniquement sur le clonage de diapositives pour le déploiement des polices. Inspectez les polices incorporées de la destination et gérez explicitement l’incorporation des polices ou la disponibilité des polices externes lorsque la typographie est importante.

**Comment fusionner un fichier protégé par mot de passe ?**

Ouvrez‑le avec le bon [LoadOptions.password](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/password/), puis clonez ses diapositives normalement. La protection de sortie est configurée séparément.

**Comment gérer de très grandes présentations ?**

Utilisez la gestion des BLOB lorsque de gros objets binaires dominent la consommation de mémoire, privilégiez le chargement par chemin de fichier pour les très gros fichiers, fermez rapidement les présentations sources et enregistrez le résultat final uniquement lorsque c’est nécessaire.

**Puis‑je fusionner des diapositives depuis plusieurs threads ?**

Ne chargez, n’enregistrez ni ne clonez des instances de [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) dans plusieurs threads. Gardez chaque opération de fusion monothread ; utilisez des processus monothread indépendants si vous devez paralléliser des travaux de fusion distincts.