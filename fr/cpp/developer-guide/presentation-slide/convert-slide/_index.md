---
title: Convertir les diapositives de présentation en images en C++
linktitle: Diapositive vers image
type: docs
weight: 41
url: /fr/cpp/convert-slide/
keywords:
- convertir diapositive
- exporter diapositive
- diapositive en image
- enregistrer diapositive comme image
- diapositive en EMF
- diapositive en PNG
- diapositive en JPEG
- diapositive en bitmap
- diapositive en TIFF
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Convertir les diapositives des présentations PPT, PPTX et ODP en PNG, JPEG, GIF, TIFF, EMF et autres formats d'image en C++ avec Aspose.Slides pour C++."
---
## **Introduction**

Aspose.Slides for C++ peut rendre des diapositives individuelles à partir de présentations PowerPoint et OpenDocument au format PNG, JPEG, GIF, TIFF et d'autres formats d'image.

Pour convertir une diapositive en image, suivez ces étapes :

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Sélectionnez la diapositive que vous souhaitez rendre.
3. Si nécessaire, configurez le rendu avec la classe [RenderingOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/renderingoptions/) ou [TiffOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/).
4. Appelez la méthode [ISlide::GetImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/getimage/). Elle renvoie un objet [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/).
5. Appelez la méthode [IImage::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/save/) et spécifiez le format de sortie avec une valeur [ImageFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imageformat/).

## **Convertir une diapositive en image PNG**

La conversion la plus simple utilise les paramètres de rendu par défaut. L'objet [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/) résultant peut être traité en mémoire ou enregistré dans un fichier.

L'exemple C++ suivant rend la première diapositive et l'enregistre au format PNG :

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Convertir des diapositives en images avec des tailles personnalisées**

Utilisez la surcharge [ISlide::GetImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/getimage/) qui accepte une valeur [Size](https://reference.aspose.com/slides/fr/cpp/system.drawing/size/) pour rendre une diapositive avec des dimensions exactes en pixels.

L'exemple suivant crée une image JPEG de 1820 × 1040 :

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Convertir les diapositives avec notes et commentaires en images**

Par défaut, les images des diapositives n'incluent pas les notes ou les commentaires. Assignez un objet [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/notescommentslayoutingoptions/) à la méthode [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) pour contrôler l'emplacement des notes et commentaires.

L'exemple suivant place des notes tronquées sous la diapositive et les commentaires à droite :

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
Pour la conversion de diapositives en images, ne définissez pas la méthode [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) sur [BottomFull](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/notespositions/). Les notes peuvent contenir plus de texte que la taille d'image fixe ne peut contenir. Utilisez [BottomTruncated](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/notespositions/) à la place.
{{% /alert %}}

## **Convertir des diapositives en images en utilisant les options TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/) vous permet de contrôler la taille, la résolution et d'autres propriétés de l'image TIFF rendue.

L'exemple suivant rend la première diapositive en une image TIFF de 2160 × 2880 à 300 DPI :

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Convertir toutes les diapositives en images**

Parcourez la collection de diapositives pour convertir l'intégralité de la présentation en une série d'images. Les diapositives masquées sont incluses, sauf si vous les ignorez explicitement.

L'exemple suivant rend chaque diapositive en une image JPEG avec des facteurs d'échelle horizontaux et verticaux de 2 :

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **Créer une sortie Enhanced Metafile**

Enhanced Metafile (EMF) est utile lorsque des graphiques vectoriels doivent être échangés avec Microsoft Office ou d'autres applications Windows qui prennent en charge les métafichiers Windows. Contrairement à une image bitmap, un EMF peut conserver les opérations de dessin vectoriel qui s'adaptent sans perte de netteté. Cependant, EMF est principalement un format de compatibilité pour les applications prenant en charge les métafichiers Windows, et non un format d'échange universel. De plus, le contenu complexe des diapositives, tel que les images bitmap et certains effets, peut être stocké sous forme d'éléments rasterisés à l'intérieur du conteneur de métafichier vectoriel.

### **Exporter une diapositive en EMF**

La méthode [ISlide::WriteAsEmf](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/writeasemf/) écrit un [ISlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/) dans un flux cible au format EMF. L'exemple suivant charge une présentation, sélectionne la première diapositive et l'écrit dans un flux de fichier EMF :

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

L'appelant possède le flux passé à [ISlide::WriteAsEmf](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/writeasemf/) et doit le fermer ou le libérer. Aspose.Slides écrit à la position actuelle du flux et le laisse ouvert.

### **Convertir une image SVG en EMF et l'ajouter à une présentation**

Utilisez [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isvgimage/writeasemf/) pour convertir le contenu SVG en EMF. Les octets résultants peuvent être ajoutés à la présentation via [IImageCollection::AddImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimagecollection/addimage/) et placés sur une diapositive avec [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides.ishapecollection/addpictureframe/).

L'exemple suivant crée un [SvgImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/svgimage/) à partir de balisage SVG, le convertit en EMF en mémoire, insère le métafichier sur la première diapositive et enregistre la présentation :

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isvgimage/writeasemf/) ne prend pas la possession du flux de destination. Après l'écriture, la position du flux se trouve à la fin des données générées. L'exemple appelle [MemoryStream::ToArray](https://reference.aspose.com/slides/fr/cpp/system.io/memorystream/toarray/) pour obtenir le tampon complet, quelle que soit la position actuelle du flux, puis transmet ce tableau d'octets à [IImageCollection::AddImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimagecollection/addimage/). Gardez le flux ouvert jusqu'à ce que le consommateur ait fini de le lire, puis fermez-le.

La génération d'EMF est disponible sur les systèmes d'exploitation pris en charge par Aspose.Slides pour C++, mais le rendu peut différer selon les plates‑formes lorsque les polices ou les dépendances graphiques natives sont indisponibles. Installez les polices utilisées par le contenu source ou configurez des substitutions appropriées, suivez les [exigences de plateforme](/slides/fr/cpp/system-requirements/) pour Aspose.Slides pour C++ et validez le résultat dans l'application cible qui consomme les EMF. Les applications sous Linux et macOS ont souvent un support limité ou incohérent pour l'affichage et l'édition des métafichiers Windows.

## **Rendu des Emoji couleur**

{{% alert title="Note" color="info" %}}
Pour rendre correctement les emojis couleur lors de la conversion des diapositives de présentation en images, les polices d'emoji utilisées dans la présentation doivent être installées et disponibles sur le système effectuant la conversion. Par exemple, si la présentation utilise **Segoe UI Emoji** et que cette police est absente, les emojis peuvent apparaître en monochrome dans les images de sortie.
{{% /alert %}}

## **FAQ**

**Aspose.Slides prend‑il en charge le rendu des diapositives avec animations ?**

Non. La méthode [ISlide::GetImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/getimage/) rend une image statique de la diapositive et n'exporte pas les animations.

**Les diapositives masquées peuvent‑elles être exportées en images ?**

Oui. Les diapositives masquées peuvent être rendues comme des diapositives normales. Incluez‑les dans la boucle de traitement, comme montré dans l'exemple ci‑dessus.

**Les ombres et autres effets sont‑ils conservés dans les images des diapositives ?**

Oui. Aspose.Slides rend les ombres, la transparence et d'autres effets graphiques pris en charge dans les images des diapositives.