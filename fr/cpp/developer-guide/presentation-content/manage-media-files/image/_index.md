---
title: Optimiser la gestion des images dans les présentations avec C++
linktitle: Gestion des images
type: docs
weight: 10
url: /fr/cpp/image/
keywords:
- ajouter image
- ajouter illustration
- ajouter bitmap
- remplacer image
- remplacer illustration
- depuis le web
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- ajouter EMF
- ajouter WMF
- ajouter TIFF
- PowerPoint
- OpenDocument
- présentation
- EMF
- SVG
- C++
- Aspose.Slides
description: "Simplifiez la gestion des images dans PowerPoint et OpenDocument avec Aspose.Slides pour C++, en optimisant les performances et en automatisant votre flux de travail."
---

## **Images dans les diapositives de présentation**

Les images rendent les présentations plus attrayantes et intéressantes. Dans Microsoft PowerPoint, vous pouvez insérer des images depuis un fichier, Internet ou d’autres emplacements sur les diapositives. De même, Aspose.Slides vous permet d’ajouter des images aux diapositives de vos présentations via différentes procédures. 

{{% alert title="Astuce" color="primary" %}} 

Aspose propose des convertisseurs gratuits — [JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — qui permettent de créer rapidement des présentations à partir d’images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si vous souhaitez ajouter une image en tant qu’objet de cadre—surtout si vous prévoyez d’utiliser les options de mise en forme standard pour modifier sa taille, ajouter des effets, etc.—consultez [Picture Frame](/slides/fr/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Remarque" color="warning" %}}

Vous pouvez manipuler les opérations d’entrée/sortie impliquant des images et des présentations PowerPoint pour convertir une image d’un format à un autre. Voir ces pages : convertir [image to JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/) ; convertir [JPG to image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/) ; convertir [JPG to PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), convertir [PNG to JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/) ; convertir [PNG to SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), convertir [SVG to PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides prend en charge les opérations avec des images dans ces formats populaires : JPEG, PNG, GIF et d’autres. 

## **Ajouter des images stockées localement aux diapositives**

Vous pouvez ajouter une ou plusieurs images de votre ordinateur sur une diapositive d’une présentation. Ce code d’exemple en C++ montre comment ajouter une image à une diapositive :
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```




## **Ajouter des images depuis le Web aux diapositives**

Si l’image que vous souhaitez ajouter à une diapositive n’est pas disponible sur votre ordinateur, vous pouvez l’ajouter directement depuis le Web. 

Ce code d’exemple montre comment ajouter une image depuis le Web à une diapositive en C++ :
``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Ajouter des images aux maîtres de diapositives**

Un maître de diapositive est la diapositive supérieure qui stocke et contrôle les informations (thème, mise en page, etc.) de toutes les diapositives qui en dépendent. Ainsi, lorsque vous ajoutez une image à un maître de diapositive, cette image apparaît sur chaque diapositive dépendante. 

Ce code d’exemple en C++ montre comment ajouter une image à un maître de diapositive :
``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Ajouter des images comme arrière‑plan de diapositives**

Vous pouvez choisir d’utiliser une image comme arrière‑plan d’une diapositive spécifique ou de plusieurs diapositives. Dans ce cas, consultez *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Ajouter du SVG aux présentations**
Vous pouvez ajouter ou insérer n’importe quelle image dans une présentation en utilisant la méthode [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) qui appartient à l’interface [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

Pour créer un objet image basé sur un SVG, procédez ainsi :

1. Créez un objet SvgImage pour l’insérer dans ImageShapeCollection  
2. Créez un objet PPImage depuis ISvgImage  
3. Créez un objet PictureFrame en utilisant l’interface IPPImage  

Ce code d’exemple montre comment mettre en œuvre les étapes ci‑dessus pour ajouter une image SVG à une présentation :
``` cpp
// Le chemin du répertoire des documents
System::String dataDir = u"D:\\Documents\\";

// Nom du fichier SVG source
System::String svgFileName = dataDir + u"sample.svg";

// Nom du fichier de présentation en sortie
System::String outPptxPath = dataDir + u"presentation.pptx";

// Créer une nouvelle présentation
auto p = System::MakeObject<Presentation>();

// Lire le contenu du fichier SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Créer l'objet SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Créer l'objet PPImage
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Crée un nouveau PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Enregistrer la présentation au format PPTX
p->Save(outPptxPath, SaveFormat::Pptx);
```


## **Convertir un SVG en jeu de formes**
La conversion d’un SVG en jeu de formes avec Aspose.Slides est similaire à la fonctionnalité PowerPoint utilisée pour travailler avec les images SVG :

![PowerPoint Popup Menu](img_01_01.png)

Cette fonctionnalité est fournie par l’une des surcharges de la méthode [AddGroupShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) de l’interface [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) qui accepte un objet [ISvgImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_svg_image) en premier argument.

Ce code d’exemple montre comment utiliser la méthode décrite pour convertir un fichier SVG en jeu de formes :
``` cpp 
// Le chemin du répertoire des documents
System::String dataDir = u"D:\\Documents\\";

// Nom du fichier SVG source
System::String svgFileName = dataDir + u"sample.svg";

// Nom du fichier de présentation en sortie
System::String outPptxPath = dataDir + u"presentation.pptx";

// Créer une nouvelle présentation
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// Lire le contenu du fichier SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Créer l'objet SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Obtenir la taille de la diapositive
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// Convertir l'image SVG en groupe de formes en l'adaptant à la taille de la diapositive
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Enregistrer la présentation au format PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```


## **Ajouter des images au format EMF aux diapositives**
Aspose.Slides for C++ vous permet de générer des images EMF à partir de feuilles Excel et d’ajouter ces images en tant qu’EMF dans les diapositives avec Aspose.Cells. 

Ce code d’exemple montre comment réaliser la tâche décrite :
``` cpp 
System::String dataDir = u"D:\\Documents\\";

StringPtr cellsXls = new String(dataDir.ToWCS().c_str());
cellsXls->Append(L"chart.xls");
intrusive_ptr<Aspose::Cells::IWorkbook> book = Aspose::Cells::Factory::CreateIWorkbook(cellsXls);

intrusive_ptr<Aspose::Cells::IWorksheet> sheet = book->GetIWorksheets()->GetObjectByIndex(0);
intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> options = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
options->SetHorizontalResolution(200);
options->SetVerticalResolution(200);
options->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetEmf());

// Save the workbook to stream
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Page" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```


## **Remplacer des images dans la collection d’images**

Aspose.Slides vous permet de remplacer les images stockées dans la collection d’images d’une présentation (y compris celles utilisées par les formes de diapositives). Cette section présente plusieurs approches pour mettre à jour les images de la collection. L’API propose des méthodes simples pour remplacer une image à l’aide de données brutes, d’une instance [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) ou d’une autre image déjà présente dans la collection.

Suivez les étapes ci‑dessous :

1. Chargez le fichier de présentation contenant des images à l’aide de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. Chargez une nouvelle image depuis un fichier dans un tableau d’octets.  
3. Remplacez l’image cible par la nouvelle image à l’aide du tableau d’octets.  
4. Dans la deuxième approche, chargez l’image dans un objet [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) et remplacez l’image cible par cet objet.  
5. Dans la troisième approche, remplacez l’image cible par une image déjà présente dans la collection d’images de la présentation.  
6. Enregistrez la présentation modifiée au format PPTX.  
```cpp
// Instancier la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// La première façon.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// La deuxième façon.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// La troisième façon.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Enregistrer la présentation dans un fichier.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}

En utilisant le convertisseur GRATUIT Aspose [Text to GIF](https://products.aspose.app/slides/text-to-gif), vous pouvez facilement animer du texte, créer des GIF à partir de texte, etc. 

{{% /alert %}}

## **FAQ**

**La résolution d’origine de l’image reste‑t‑elle intacte après l’insertion ?**

Oui. Les pixels source sont conservés, mais l’apparence finale dépend de la façon dont le [picture](/slides/fr/cpp/picture-frame/) est redimensionné sur la diapositive et de la compression appliquée lors de l’enregistrement.

**Quelle est la meilleure façon de remplacer le même logo sur des dizaines de diapositives en une seule fois ?**

Placez le logo sur le maître de diapositive ou sur une mise en page et remplacez‑le dans la collection d’images de la présentation — les mises à jour se propageront à tous les éléments qui utilisent cette ressource.

**Un SVG inséré peut‑il être converti en formes éditables ?**

Oui. Vous pouvez convertir un SVG en groupe de formes, après quoi chaque partie devient éditable avec les propriétés de forme standard.

**Comment définir une image comme arrière‑plan pour plusieurs diapositives à la fois ?**

[Assignez l’image comme arrière‑plan](/slides/fr/cpp/presentation-background/) sur le maître de diapositive ou sur la mise en page concernée — toutes les diapositives utilisant ce maître/mise en page hériteront de l’arrière‑plan.

**Comment empêcher la présentation de « gonfler » en taille à cause de nombreuses images ?**

Réutilisez une même ressource d’image au lieu de duplicata, choisissez des résolutions raisonnables, appliquez la compression lors de l’enregistrement et conservez les graphiques répétés sur le maître lorsque cela est approprié.