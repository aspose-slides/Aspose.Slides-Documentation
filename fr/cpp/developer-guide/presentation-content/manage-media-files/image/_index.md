---
title: Image
type: docs
weight: 10
url: /cpp/image/
---


## **Images dans les Diapositives des Présentations**

Les images rendent les présentations plus engageantes et intéressantes. Dans Microsoft PowerPoint, vous pouvez insérer des images depuis un fichier, l'internet ou d'autres emplacements sur des diapositives. De même, Aspose.Slides vous permet d'ajouter des images aux diapositives de vos présentations par différents procédés.

{{% alert title="Astuce" color="primary" %}} 

Aspose fournit des convertisseurs gratuits—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—qui permettent aux utilisateurs de créer rapidement des présentations à partir d'images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si vous souhaitez ajouter une image en tant qu'objet cadre—surtout si vous prévoyez d'utiliser des options de mise en forme standard pour en modifier la taille, ajouter des effets, etc.—voir [Cadre d'Image](/slides/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Remarque" color="warning" %}}

Vous pouvez manipuler les opérations d'entrée/sortie impliquant des images et des présentations PowerPoint pour convertir une image d'un format à un autre. Voir ces pages : convertir [image en JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); convertir [JPG en image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); convertir [JPG en PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); convertir [PNG en SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides prend en charge les opérations avec des images dans ces formats populaires : JPEG, PNG, GIF, et d'autres.

## **Ajouter des Images Stockées Localement aux Diapositives**

Vous pouvez ajouter une ou plusieurs images de votre ordinateur sur une diapositive d'une présentation. Ce code d'exemple en C++ vous montre comment ajouter une image à une diapositive :

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **Ajouter des Images du Web aux Diapositives**

Si l'image que vous souhaitez ajouter à une diapositive n'est pas disponible sur votre ordinateur, vous pouvez ajouter l'image directement depuis le web.

Ce code d'exemple vous montre comment ajouter une image du web à une diapositive en C++ :

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Ajouter des Images aux Maîtres de Diapositive**

Un maître de diapositive est la diapositive supérieure qui stocke et contrôle les informations (thème, mise en page, etc.) sur toutes les diapositives qui lui sont subordonnées. Ainsi, lorsque vous ajoutez une image à un maître de diapositive, cette image apparaît sur chaque diapositive sous ce maître de diapositive.

Ce code d'exemple en C++ vous montre comment ajouter une image à un maître de diapositive :

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Ajouter des Images comme Arrière-plan de Diapositive**

Vous pouvez décider d'utiliser une image comme arrière-plan pour une diapositive spécifique ou plusieurs diapositives. Dans ce cas, vous devez consulter *[Définir les Images comme Arrière-plan pour les Diapositives](https://docs.aspose.com/slides/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Insérer/Ajouter SVG dans des Présentations**
Vous pouvez ajouter ou insérer n'importe quelle image dans une présentation en utilisant la méthode [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) qui appartient à l'interface [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

Pour créer un objet image basé sur une image SVG, vous pouvez le faire de cette manière :

1. Créer un objet SvgImage à insérer dans ImageShapeCollection
2. Créer un objet PPImage à partir d'ISvgImage
3. Créer un objet PictureFrame en utilisant l'interface IPPImage

Ce code d'exemple vous montre comment implémenter les étapes ci-dessus pour ajouter une image SVG à une présentation :
``` cpp 
// Le chemin d'accès au répertoire des documents
System::String dataDir = u"D:\\Documents\\";

// Nom du fichier SVG source
System::String svgFileName = dataDir + u"sample.svg";

// Nom du fichier de présentation de sortie
System::String outPptxPath = dataDir + u"presentation.pptx";

// Créer une nouvelle présentation
auto p = System::MakeObject<Presentation>();

// Lire le contenu du fichier SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Créer un objet SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Créer un objet PPImage
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Créer un nouveau PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Sauvegarder la présentation au format PPTX
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **Convertir SVG en un Ensemble de Formes**
La conversion de SVG en un ensemble de formes avec Aspose.Slides est similaire à la fonctionnalité de PowerPoint utilisée pour travailler avec des images SVG :

![Menu contextuel PowerPoint](img_01_01.png)

Cette fonctionnalité est fournie par l'une des surcharges de la méthode [AddGroupShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) de l'interface [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) qui prend un objet [ISvgImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_svg_image) comme premier argument.

Ce code d'exemple vous montre comment utiliser la méthode décrite pour convertir un fichier SVG en un ensemble de formes :

``` cpp 
// Le chemin d'accès au répertoire des documents
System::String dataDir = u"D:\\Documents\\";

// Nom du fichier SVG source
System::String svgFileName = dataDir + u"sample.svg";

// Nom du fichier de présentation de sortie
System::String outPptxPath = dataDir + u"presentation.pptx";

// Créer une nouvelle présentation
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// Lire le contenu du fichier SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Créer un objet SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Obtenir la taille de la diapositive
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// Convertir l'image SVG en groupe de formes en l'échelonnant à la taille de la diapositive
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Sauvegarder la présentation au format PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Ajouter des Images en tant qu'EMF dans les Diapositives**
Aspose.Slides pour C++ vous permet de générer des images EMF à partir de feuilles Excel et d'ajouter les images en tant qu'EMF dans les diapositives avec Aspose.Cells.

Ce code d'exemple vous montre comment réaliser la tâche décrite :

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

// Sauvegarder le classeur dans un flux
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

{{% alert title="Info" color="info" %}}

En utilisant le convertisseur gratuit [Texte en GIF](https://products.aspose.app/slides/text-to-gif) d'Aspose, vous pouvez facilement animer des textes, créer des GIFs à partir de textes, etc.

{{% /alert %}}