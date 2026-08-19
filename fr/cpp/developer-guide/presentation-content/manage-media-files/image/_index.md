---
title: Optimiser la gestion des images dans les présentations avec C++
linktitle: Gérer les images
type: docs
weight: 10
url: /fr/cpp/image/
keywords:
- ajouter image
- ajouter image
- remplacer image
- collection d'images
- cadre d'image
- image liée
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- SVG vers formes
- ressources SVG externes
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Découvrez comment ajouter, réutiliser, lier, remplacer et gérer les images raster et SVG dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour C++."
---
## **Introduction**

Aspose.Slides for C++ propose plusieurs façons de travailler avec les images, chacune ayant un objectif différent. Vous pouvez stocker une image dans une présentation, l’afficher dans un cadre d’image, l’utiliser comme arrière‑plan d’une diapositive, créer un lien vers une image externe, remplacer une ressource d’image partagée ou convertir du contenu SVG en formes modifiables.

Cet article se concentre sur les ressources d’image et leur utilisation dans une présentation. Pour le recadrage, la transparence, les effets, l’étirement et d’autres formatages appliqués à un cadre d’image individuel, consultez [Cadre d’image](/slides/fr/cpp/picture-frame/).

## **Comprendre le modèle d’image**

Les concepts d’API suivants sont étroitement liés mais non interchangeables :

- La [collection d’images de présentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimagecollection/) stocke les ressources d’image utilisées par la présentation. Utilisez [IImageCollection::AddImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimagecollection/addimage/) pour ajouter des données d’image et obtenir une ressource [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/).
- Un [cadre d’image](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipictureframe/) est une forme qui affiche une image sur une diapositive, une disposition ou un maître. Utilisez [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/addpictureframe/) pour placer une ressource d’image sur une diapositive.
- Un arrière‑plan de diapositive utilise une image comme partie du remplissage de la diapositive plutôt que comme une forme. Il ne se comporte donc pas comme un cadre d’image.
- [IPPImage::ReplaceImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/replaceimage/) remplace une ressource d’image. Si plusieurs éléments de la présentation utilisent cette ressource, ils utilisent tous le remplacement.
- La conversion d’un SVG en formes crée des formes de diapositive modifiables. Après la conversion, le contenu n’est plus géré comme une unique ressource d’image.

Un flux de travail typique est donc : ajouter des données d’image à la collection d’images, recevoir un [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/), puis utiliser cette ressource dans un ou plusieurs cadres d’image ou remplissages.

## **Ajouter une image intégrée**

Pour insérer une image locale, lisez le fichier, ajoutez ses données à la collection d’images et créez un cadre d’image qui utilise la ressource [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/) retournée.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

L’image ajoutée de cette façon est intégrée à la présentation, de sorte que le fichier résultant ne dépend pas de la disponibilité continue du fichier image d’origine.

### **Ajouter une image depuis le Web**

Lorsqu’une image est disponible via HTTP ou HTTPS, téléchargez ses octets, ajoutez‑les à la collection d’images de la présentation et utilisez la ressource d’image retournée de la même manière qu’une image locale.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Net;

auto imageUri = MakeObject<Uri>(u"https://example.com/image.png");
auto webClient = MakeObject<WebClient>();
auto imageData = webClient->DownloadData(imageUri);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(imageData);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation-from-web.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Validez les URL distants, les tailles de réponse et les types de contenu lorsque la source n’est pas fiable. Dans les applications qui utilisent déjà un autre client HTTP, vous pouvez télécharger l’image avec ce client et transmettre les octets ou le flux résultant à [IImageCollection::AddImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimagecollection/addimage/).

## **Réutiliser des images sur plusieurs diapositives**

Si la même image est nécessaire plusieurs fois, ajoutez‑la une seule fois à la présentation et réutilisez le [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/) retourné lors de la création de cadres d’image supplémentaires. Cela évite de charger à plusieurs reprises les mêmes données source et rend explicite la relation entre la ressource d’image partagée et ses utilisations.

Pour les graphiques qui doivent apparaître automatiquement sur de nombreuses diapositives, comme le logo d’une entreprise, envisagez de placer le cadre d’image sur un [maître de diapositive](/slides/fr/cpp/slide-master/) ou une disposition plutôt que d’ajouter une forme équivalente à chaque diapositive.

## **Utiliser une image comme arrière‑plan de diapositive**

Une image d’arrière‑plan est attribuée au remplissage de la diapositive ; elle n’est pas ajoutée en tant que forme de cadre d’image. Ceci est utile lorsque l’image doit couvrir tout l’arrière‑plan de la diapositive et ne doit pas être manipulée comme un objet de diapositive normal.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"background.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

presentation->Save(u"background-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pour d’autres options d’arrière‑plan, y compris les arrière‑plans de maîtres et de dispositions, consultez [Arrière‑plan de présentation](/slides/fr/cpp/presentation-background/).

## **Images intégrées et images liées**

Les images intégrées et les images liées présentent des compromis différents en termes de portabilité et de taille de fichier :

- **Image intégrée :** les données de l’image sont stockées à l’intérieur de la présentation. La présentation est autonome, mais la taille du fichier inclut les données de l’image.
- **Image liée :** la présentation stocke un chemin ou une URL vers une image externe. Cela peut réduire la taille de la présentation, mais la ressource externe doit rester accessible lorsque la présentation est ouverte ou rendue.

Une image liée peut être créée en affectant le chemin ou l’URL externe via [ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidespicture/set_linkpathlong/) plutôt qu’en intégrant les données de l’image.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, nullptr);
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://example.com/image.png");

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Utilisez des images liées uniquement lorsque l’environnement de déploiement peut accéder de façon fiable à la ressource externe. Pour les présentations qui doivent fonctionner hors ligne ou être déplacées entre systèmes, les images intégrées sont généralement plus sûres.

## **Travailler avec les images SVG**

SVG est un format vectoriel, il peut donc être utile pour des icônes, des diagrammes et d’autres graphiques qui doivent être redimensionnés sans perte de détail comme les images raster. Aspose.Slides prend en charge SVG à la fois comme ressource d’image et comme source de formes de diapositive modifiables.

### **Ajouter un SVG en tant qu’image**

Créez un [SvgImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/svgimage/), ajoutez‑le à la collection d’images et placez la ressource d’image résultante dans un cadre d’image.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"icon.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(svgImage);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 200.0f, image);

presentation->Save(u"svg-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Fichiers SVG avec ressources externes**

Un SVG peut référencer des images, des feuilles de style ou des polices externes. Dans ces cas, [SvgImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/svgimage/) propose des constructeurs qui acceptent un [IExternalResourceResolver](https://reference.aspose.com/slides/fr/cpp/aspose.slides.import/iexternalresourceresolver/) et une URI de base. Le résolveur peut mapper une URI relative à une URI absolue autorisée et retourner un flux pour la ressource demandée.

Le résolveur rend les ressources externes disponibles pendant le traitement du SVG par Aspose.Slides, mais ne réécrit pas le SVG en un document autonome. Si le SVG doit rester portable, intégrez les ressources nécessaires directement dans le SVG, par exemple en utilisant des URI `data:` pour les images liées.

Lorsque les fichiers SVG proviennent de sources non fiables, restreignez les schémas, les emplacements de fichiers et les hôtes que le résolveur peut atteindre. Les résolveurs réseau doivent également appliquer des délais d’attente, des limites de taille de réponse et une validation du contenu.

### **Convertir le SVG en formes modifiables**

Aspose.Slides peut convertir un SVG en un groupe de formes de diapositive modifiables, similaire à la commande correspondante de PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Utilisez la surcharge [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/addgroupshape/) qui accepte un [ISvgImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isvgimage/) pour effectuer la conversion.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"diagram.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddGroupShape(svgImage, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height());

presentation->Save(u"editable-svg-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Utilisez la conversion SVG‑vers‑formes lorsque des éléments vectoriels individuels doivent être édités en tant que formes PowerPoint. Si le SVG doit seulement être affiché, le conserver comme image est plus simple et évite de créer de nombreuses formes séparées.

## **Remplacer une ressource d’image existante**

Utilisez [IPPImage::ReplaceImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/replaceimage/) lorsque vous souhaitez remplacer une ressource d’image existante. Cela est particulièrement utile pour les graphiques partagés tels que les logos.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto imageToReplace = presentation->get_Image(0);
auto imageData = File::ReadAllBytes(u"new-logo.png");
imageToReplace->ReplaceImage(imageData);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Si plusieurs cadres d’image, arrière‑plans, maîtres ou dispositions utilisent la même ressource d’image, le remplacement de cette ressource met à jour toutes ces utilisations. Si un seul cadre d’image doit changer, affectez une image différente à ce cadre plutôt que de remplacer la ressource partagée.

[IPPImage::ReplaceImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/replaceimage/) propose également des surcharges qui acceptent un [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/) ou un autre [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/).

## **Conseils pratiques de gestion des images**

### **Contrôler la taille de la présentation**

Les images raster volumineuses peuvent rendre une présentation inutilement grande. Utilisez des images sources dont les dimensions sont appropriées à la taille d’affichage prévue, réutilisez les ressources d’image partagées lorsque cela est possible et évitez d’intégrer des copies répétées du même graphique haute résolution.

Pour les images raster déjà placées dans des cadres d’image, [IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipicturefillformat/compressimage/) peut réduire les données d’image selon la résolution sélectionnée et les paramètres de recadrage. Il s’agit d’un traitement de cadre d’image plutôt que d’une gestion de collection d’images, consultez donc [Cadre d’image](/slides/fr/cpp/picture-frame/) pour les opérations de formatage associées.

### **Choisir entre contenu intégré et lié**

L’intégration rend la présentation portable puisque toutes les données d’image nécessaires voyagent avec le fichier. Le lien peut réduire la taille du fichier, mais introduit une dépendance externe. N’utilisez les liens que lorsque cette dépendance est acceptable et stable.

### **Réutiliser la charte graphique partagée**

Pour les logos, filigranes ou graphiques décoratifs récurrents, utilisez une seule ressource d’image et réutilisez‑la. Si le graphique fait partie du design de la présentation plutôt que du contenu des diapositives, placez‑le sur un maître ou une disposition afin qu’il soit hérité par les diapositives appropriées.

### **Conserver les ressources SVG portables**

Un SVG autonome est plus facile à déplacer et à rendre de manière cohérente qu’un SVG dépendant de fichiers externes ou de ressources réseau. Dans la mesure du possible, intégrez les ressources nécessaires avant d’importer le SVG. Convertissez le SVG en formes uniquement lorsque les éléments vectoriels individuels doivent être édités.

### **Utiliser l’API Image d’Aspose.Slides**

Pour les flux de travail d’images en C++, utilisez les API Aspose.Slides [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/) et [Images](https://reference.aspose.com/slides/fr/cpp/aspose.slides/images/) lorsque vous avez besoin d’un objet image, et utilisez [IImageCollection::AddImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimagecollection/addimage/) lorsque vous devez enregistrer des données d’image en tant que ressource de présentation. Les surcharges de la collection prennent également en charge les tableaux d’octets et les flux, ce qui est utile lorsque les données d’image proviennent de fichiers, de clients réseau, de bases de données ou d’autres bibliothèques.

Générer du contenu EMF à partir de feuilles de calcul ou d’un autre produit constitue un flux de travail d’intégration distinct et ne relève pas du champ de cet article. Si un fichier WMF ou EMF existant doit seulement être inséré dans une présentation, transmettez ses données à la surcharge appropriée de [IImageCollection::AddImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimagecollection/addimage/) sans ajouter une dépendance supplémentaire au produit dans le flux de gestion des images.

## **FAQ**

**Quelle est la différence entre la collection d’images et un cadre d’image ?**

La collection d’images stocke des ressources d’image réutilisables. Un cadre d’image est une forme de diapositive qui affiche l’une de ces ressources et offre des options de formatage spécifiques à l’image telles que le recadrage et les effets.

**Quelle est la meilleure façon de remplacer le même logo partout ?**

Si le logo est déjà partagé en tant que ressource d’image unique, remplacez cette ressource avec [IPPImage::ReplaceImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/replaceimage/). Pour une identité visuelle à l’échelle de la présentation, placer le logo sur un maître ou une disposition permet également de réduire le contenu dupliqué des diapositives.

**Pourquoi une image liée disparaît‑elle sur un autre ordinateur ?**

Une image liée dépend de son fichier externe ou de son URL. Si cette ressource n’est pas accessible depuis l’autre ordinateur, l’image liée peut être indisponible. Intégrez l’image lorsque la présentation doit être autonome.

**Une SVG insérée peut‑elle être modifiée en tant que formes PowerPoint ?**

Oui. Convertissez le SVG avec [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/addgroupshape/) ; le groupe résultant contient des formes de diapositive modifiables plutôt qu’une seule image SVG.

**Comment garder les présentations contenant de nombreuses images plus petites ?**

Réutilisez les ressources d’image partagées, évitez les sources raster inutilement volumineuses, compressez les images raster appropriées lorsque cela est pertinent, conservez les éléments de marque répétés sur des maîtres ou des dispositions, et n’utilisez des images liées que lorsqu’une dépendance externe est acceptable.