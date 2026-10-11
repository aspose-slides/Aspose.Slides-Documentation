---
title: Modifier la taille et l'orientation de la page de notes en C++
linktitle: Taille de la page de notes
type: docs
weight: 10
url: /fr/cpp/notes-size/
keywords:
- taille de la page de notes
- orientation des notes
- notes en mode paysage
- notes en mode portrait
- taille du document de distribution
- PowerPoint
- présentation
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Lire et modifier les dimensions de la page de notes dans Aspose.Slides pour C++, changer l'orientation, vérifier les tailles enregistrées, et exporter les notes ou les documents de distribution en PDF et en images."
---
## **Aperçu**

Utilisez [Presentation::get_NotesSize](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_notessize/) pour accéder aux paramètres de la page de notes de la présentation. Elle renvoie un objet [INotesSize](https://reference.aspose.com/slides/fr/cpp/aspose.slides/inotessize/) dont la méthode [set_Size](https://reference.aspose.com/slides/fr/cpp/aspose.slides/inotessize/set_size/) définit les dimensions. Bien que l'objet des paramètres de notes ne puisse pas être remplacé, vous pouvez modifier sa taille.

La largeur et la hauteur sont spécifiées en **points**, avec 72 points par pouce. Par exemple, 900 × 600 points correspondent à 12,5 × 8⅓ pouces. Ces paramètres s’appliquent à la présentation, plutôt qu’aux notes d’une diapositive individuelle.

| Paramètre | Objectif |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_notessize/) | Contrôle les dimensions de la page de notes et les dimensions de page utilisées pour l’exportation de documents de distribution. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_slidesize/) | Contrôle les dimensions des diapositives normales de la présentation via [ISlideSize](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidesize/). |

Modifier l’un ou l’autre des paramètres ne modifie pas automatiquement l’autre. Modifier l’orientation de la page de notes ne fait pas non plus pivoter les diapositives normales. Voir [Slide Size](/slides/fr/cpp/slide-size/) pour redimensionner les diapositives normales.

Les exemples ci‑dessous utilisent un fichier `sample.pptx` existant. Pour les exemples d’exportation, utilisez une présentation contenant au moins une diapositive avec des notes de présentateur. Chaque exemple peut être exécuté indépendamment.

## **Lire la taille et l’orientation de la page de notes**

Lisez la largeur et la hauteur et comparez‑les pour déterminer l’orientation : une page plus large est en mode paysage, une page plus haute est en mode portrait, et des dimensions égales décrivent une page carrée. Cet exemple affiche les dimensions réelles en points, sans supposer une taille de papier standard.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **Passer en mode paysage sans modifier la taille du papier**

Pour ne modifier que l’orientation, échangez la largeur et la hauteur existantes. Cela préserve les longueurs des deux côtés, y compris celles d’une taille de papier personnalisée. La condition ci‑dessus empêche une page déjà en paysage d’être basculée en portrait et laisse une page carrée inchangée.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

Pour l’orientation portrait, utilisez la même affectation lorsque `size.get_Width() > size.get_Height()`. Ne remplacez pas les dimensions A4 ou Letter sauf si vous souhaitez également modifier la taille du papier.

## **Définir et vérifier une taille de page de notes personnalisée**

Attribuez les deux dimensions conjointement, puis utilisez [Presentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/) pour enregistrer la présentation. Cet exemple définit une page paysage de 900 × 600 points, l’enregistre au format PPTX, puis rouvre le fichier enregistré afin de vérifier les valeurs persistées. La comparaison accepte une tolérance de 0,01 point pour les valeurs à virgule flottante ; elle ne garantit pas la précision pour chaque format de fichier.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

Le résultat attendu est `900 x 600 points` et `Size preserved: True`. Vérifier une présentation nouvellement ouverte confirme le fichier enregistré, plutôt que les seuls paramètres en mémoire.

## **Exporter les notes et les documents de distribution**

Les dimensions de la page définissent la zone disponible pour les dispositions des notes ou des documents de distribution. Elles n’activent pas ces dispositions seules : configurez également les options d’exportation. L’exportation des diapositives normales continue d’utiliser les dimensions des diapositives.

### **Exporter les notes en PDF et PNG**

Attribuez [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/notescommentslayoutingoptions/) à [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) pour inclure les notes dans le PDF. Cet exemple rend également la première diapositive avec notes en PNG en utilisant [Slide::GetImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slide/getimage/) et [RenderingOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/renderingoptions/).

Le mode [BottomTruncated](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/notespositions/) conserve les notes sur une page ; les notes qui ne tiennent pas peuvent être tronquées. Le PDF utilise des pages de 900 × 600 points. À l’échelle d’image de 1 × 1 utilisée ci‑dessus, le PNG fait 900 × 600 pixels. Les points décrivent la géométrie de la page ; les pixels décrivent la sortie raster, dont les dimensions dépendent également de l’échelle de rendu.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

Pour l’exportation PDF avec des notes longues, [BottomFull](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/notespositions/) autorise des pages supplémentaires si nécessaire. N’utilisez pas ce mode avec l’appel d’image d’une seule diapositive ci‑dessus, qui ne le prend pas en charge. Après redimensionnement, inspectez la sortie pour les notes découpées et le positionnement des objets notes‑master existants ; modifier uniquement les dimensions de la page ne doit pas être considéré comme une garantie que tout le contenu tiendra. Voir [Convert PowerPoint to PDF with Notes](/slides/fr/cpp/convert-powerpoint-to-pdf-with-notes/) pour plus d’informations sur l’exportation des notes.

### **Exporter les documents de distribution en PDF**

Utilisez [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/handoutlayoutingoptions/) pour plusieurs vignettes de diapositives sur une page. L’exemple suivant définit une page de 900 × 600 points et utilise [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/handouttype/) pour disposer jusqu’à quatre diapositives par page. Le préréglage horizontal contrôle l’ordre des diapositives ; l’orientation de la page provient de sa largeur et de sa hauteur.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

Modifier la taille de la page modifie la zone disponible pour la grille du document de distribution sans changer les dimensions des diapositives sources. Pour les images de documents de distribution, utilisez [Presentation::GetImages](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/getimages/) avec la mise en page du document de distribution, plutôt que la méthode d’image d’une diapositive individuelle. Dans Aspose.Slides, le rendu de document de distribution au niveau de la présentation utilise les dimensions de la page de notes, tandis que l’appel d’image d’une diapositive individuelle ne produit pas la page de distribution. Voir [Handout Mode](/slides/fr/cpp/convert-powerpoint-in-handout-mode/) pour les options de mise en page.

## **Taille de page dans les visionneuses, l’exportation et l’impression**

Gardez distinctes la taille de la présentation stockée, la taille de page exportée et la taille du papier imprimé :

- **Visionneuses de présentation** : Un visionneur peut afficher ou imprimer les notes en utilisant ses propres règles de mise en page. Si une autre application enregistre le fichier, rouvrez‑le et vérifiez à nouveau les dimensions ; la conversion de format de cette application peut les normaliser.
- **Formats d’exportation** : Les exemples PDF de notes et de documents de distribution ci‑dessus utilisent les dimensions de page configurées. Les images raster utilisent des dimensions de pixels entiers et une échelle de rendu, de sorte que les valeurs de points fractionnaires peuvent être arrondies dans la sortie d’image. L’exportation des diapositives normales n’applique pas la taille de la page de notes.
- **Pilotes d’imprimante** : La sélection du papier, la rotation automatique et les réglages d’ajustement à la page peuvent modifier la sortie physique sans changer les dimensions stockées dans la présentation ou le PDF. Pour une taille de papier spécifique, alignez les paramètres de l’imprimante et inspectez l’aperçu avant impression.

## **FAQ**

**Puis‑je définir la taille des notes pour une seule diapositive ?**

La taille de la page de notes est un paramètre au niveau de la présentation. Les diapositives individuelles peuvent contenir un contenu de notes différent, mais cette propriété ne fournit pas de taille de page distincte pour chaque diapositive.

**Pourquoi le fait de changer l’orientation des notes n’a pas modifié mes diapositives ?**

Les pages de notes et les diapositives normales ont des dimensions indépendantes. Utilisez les paramètres de taille de diapositive normale lorsque vous souhaitez redimensionner les diapositives elles‑mêmes.

**Pourquoi mon résultat enregistré ou imprimé a‑t‑il une taille différente ?**

Commencez par rouvrir la présentation enregistrée et comparer ses dimensions de notes. Si elles ont changé, vérifiez si l’enregistrement ou la conversion du fichier dans une autre application a modifié les paramètres de page. Si ce n’est pas le cas, examinez la mise en page d’exportation, l’échelle de l’image, les réglages du visionneur et la sélection du papier d’imprimante.