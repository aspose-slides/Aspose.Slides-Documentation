---
title: Opérations de présentation Low-Code en C++
linktitle: API Low-Code
type: docs
weight: 50
url: /fr/cpp/low-code-presentation-operations/
keywords:
- API de présentation low-code
- conversion de présentation
- fusion de présentations
- parcourir les diapositives
- parcourir les formes
- parcourir le texte
- collecter les formes
- compresser la présentation
- supprimer les diapositives maîtres inutilisées
- supprimer les diapositives de mise en page inutilisées
- compresser les polices incorporées
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Utilisez l'API low-code d'Aspose.Slides en C++ pour convertir et fusionner des présentations, parcourir le contenu, collecter des formes et réduire la taille de la présentation."
---
## **Vue d'ensemble**

L'espace de noms [Aspose::Slides::LowCode](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/) fournit des classes d'assistance statiques pour les opérations courantes sur les présentations. Ces assistants encapsulent les flux de travail fréquemment utilisés du modèle d'objet dans des méthodes ciblées, de sorte que vous pouvez convertir ou fusionner des fichiers, traiter les éléments de la présentation, collecter les formes et supprimer le contenu inutilisé avec moins de code.

Les assistants low‑code sont les plus utiles lorsque l'opération s'applique à un fichier ou à une présentation complète et que le flux de travail par défaut correspond à vos besoins. Utilisez le modèle d'objet complet [Aspose.Slides object model](https://reference.aspose.com/slides/fr/cpp/aspose.slides/) lorsque vous avez besoin d'un contrôle fin sur des diapositives, maîtres, mises en page, formes, paramètres d'exportation ou relations entre les éléments de la présentation.

Le tableau suivant résume les assistants disponibles :

| Assistant | À quoi il sert |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/convert/) | Conversion d'une présentation vers un autre format avec un appel direct fichier à fichier. |
| [Merger](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/merger/) | Combinaison de fichiers de présentation complets du même format. |
| [ForEach](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/foreach/) | Exécution d'une action pour chaque diapositive, forme, paragraphe ou portion de texte. |
| [Collect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/collect/) | Récupération des formes de l'ensemble de la présentation pour un traitement ou une analyse répétés. |
| [Compress](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/compress/) | Suppression des maîtres et des mises en page inutilisés et réduction des données de polices incorporées. |

## **Convertir une présentation**

Utilisez [Convert::AutoByExtension](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/convert/autobyextension/) lorsque l'extension du fichier de sortie suffit à sélectionner le format d'exportation. La méthode ouvre la présentation source, détermine le format requis à partir du chemin de sortie et écrit le résultat.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/convert/) fournit également des méthodes dédiées pour la sortie PDF, SVG, JPEG, PNG et TIFF. Utilisez le modèle d'objet complet lorsque vous devez inspecter ou modifier la présentation avant l'exportation ou configurer une option d'exportation qui n'est pas exposée par l'assistant sélectionné. Consultez [Convert Presentation](/slides/fr/cpp/convert-presentation/) pour les flux de travail et les options spécifiques à chaque format.

## **Fusionner des présentations**

Utilisez [Merger::Process](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/merger/process/) pour combiner des fichiers de présentation complets en un seul appel. Les présentations d'entrée doivent être au même format de fichier.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

L'assistant est approprié lorsque toutes les diapositives doivent être ajoutées à un résultat unique sans les sélectionner ou les remapper individuellement. Utilisez le modèle d'objet complet lorsque vous devez fusionner des diapositives sélectionnées, appliquer un maître ou une mise en page de destination, conserver explicitement les sections ou concilier des tailles de diapositives différentes. Consultez [Merge Presentations](/slides/fr/cpp/merge-presentation/) pour ces scénarios.

## **Parcourir les éléments de la présentation**

La classe [ForEach](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/foreach/) invoque un rappel pour chaque type d'élément de présentation demandé. Elle évite les boucles de collections imbriquées et est pratique pour l'inspection ou les modifications de format à l'échelle de la présentation.

L'exemple suivant utilise [ForEach::Slide](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/foreach/paragraph/), et [ForEach::Portion](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/foreach/portion/) pour inspecter les éléments correspondants :

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

Par défaut, le parcours des formes et du texte à l'échelle de la présentation inclut les diapositives normales, maîtres et de mise en page. Les surcharges avec un paramètre `includeNotes` peuvent également traiter les diapositives de notes. Utilisez des boucles de collections directes lorsque l'ordre de parcours, la sortie anticipée, le filtrage avant l'invocation du rappel ou le contrôle détaillé parent‑enfant sont importants.

## **Collecter des formes**

Utilisez [Collect::Shapes](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/collect/shapes/) lorsque vous avez besoin d'une collection de toutes les formes d'une présentation plutôt que d'un rappel pour chaque forme. Ceci est utile lorsque le même ensemble sera filtré, compté ou traité plusieurs fois.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

Utilisez [ForEach::Shape](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/foreach/shape/) à la place lorsque chaque forme peut être traitée immédiatement et que vous n'avez pas besoin de conserver le résultat collecté.

## **Compresser le contenu de la présentation**

La classe [Compress](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/compress/) peut supprimer les éléments structurels inutilisés et réduire les données de polices incorporées :

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) supprime les diapositives de mise en page qui ne sont référencées par aucune diapositive normale.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) supprime les diapositives maîtres qui ne sont plus utilisées.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) supprime les caractères inutilisés des polices incorporées.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

Supprimez d'abord les mises en page inutilisées, puis les maîtres inutilisés afin qu'un maître devenu orphelin après le nettoyage des mises en page puisse également être supprimé. Enregistrez la présentation optimisée dans un nouveau fichier si vous devez éventuellement conserver les maîtres, les mises en page ou les données complètes de polices incorporées d'origine. Pour plus de détails, consultez [Slide Master](/slides/fr/cpp/slide-master/) et [Embedded Font](/slides/fr/cpp/embedded-font/).

## **FAQ**

**Quand dois‑je utiliser l’API low‑code plutôt que le modèle d’objet complet ?**  
Utilisez les assistants low‑code lorsqu’une opération standard s’applique à un fichier ou à une présentation complète et qu’elle ne nécessite pas de contrôle détaillé sur des éléments individuels. Utilisez le modèle d’objet complet lorsque vous devez sélectionner des diapositives spécifiques, contrôler les relations maître‑mise en page, inspecter l’état intermédiaire ou configurer un comportement que l’assistant n’expose pas.

**Le Merger peut‑il combiner des présentations dans différents formats de fichier ?**  
Non. [Merger::Process](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/merger/process/) exige que les présentations d’entrée soient dans le même format. Convertissez d’abord les fichiers d’entrée vers un format commun, par exemple avec [Convert::AutoByExtension](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/convert/autobyextension/), puis fusionnez les fichiers convertis.

**ForEach traite‑t‑il les diapositives maîtres, mises en page et notes ?**  
[ForEach::Slide](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/foreach/slide/) parcourt les diapositives normales de la présentation. Les opérations à l’échelle de la présentation [ForEach::Shape](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/foreach/paragraph/) et [ForEach::Portion](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/foreach/portion/) incluent par défaut les diapositives normales, maîtres et de mise en page. Utilisez leurs surcharges avec `includeNotes` réglé sur `true` pour inclure les diapositives de notes.

**Quelle est la différence entre ForEach::Shape et Collect::Shapes ?**  
Utilisez [ForEach::Shape](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/foreach/shape/) pour traiter chaque forme immédiatement via un rappel. Utilisez [Collect::Shapes](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/collect/shapes/) lorsque vous avez besoin d’un résultat énumérable qui peut être conservé, filtré, compté ou parcouru plusieurs fois.

**Compress réduit‑il toujours la taille du fichier de présentation ?**  
Pas forcément. Le résultat dépend de la présence ou non de mises en page inutilisées, de maîtres inutilisés ou de polices incorporées contenant des caractères inutilisés. Si aucun de ces éléments n’est présent, les opérations [Compress](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/compress/) correspondantes peuvent ne pas diminuer la taille du fichier.

**Les modifications effectuées par ForEach ou Compress sont‑elles enregistrées automatiquement ?**  
Non. Ces assistants opèrent sur l’objet [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) chargé en mémoire. Après avoir modifié des éléments dans un rappel [ForEach](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/foreach/) ou exécuté [Compress](https://reference.aspose.com/slides/fr/cpp/aspose.slides.lowcode/compress/), appelez [Presentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/) pour écrire le résultat.

## **Articles associés**

- [Convertir une présentation](/slides/fr/cpp/convert-presentation/)
- [Fusionner des présentations](/slides/fr/cpp/merge-presentation/)
- [Maître de diapositive](/slides/fr/cpp/slide-master/)
- [Gérer la zone de texte](/slides/fr/cpp/manage-textbox/)
- [Police incorporée](/slides/fr/cpp/embedded-font/)