---
title: Gérer OLE
type: docs
weight: 40
url: /fr/cpp/manage-ole/
keywords:
- ajouter OLE
- intégrer OLE
- ajouter un objet
- intégrer un objet
- intégrer un fichier
- objet lié
- Liaison et Intégration d'Objets
- objet OLE
- PowerPoint 
- présentation
- C++
- Aspose.Slides pour C++
description: Ajouter des objets OLE aux présentations PowerPoint en C++
---

{{% alert title="Info" color="info" %}}

OLE (Liaison et Intégration d'Objets) est une technologie Microsoft qui permet de placer des données et des objets créés dans une application dans une autre application via liaison ou intégration. 

{{% /alert %}} 

Considérez un graphique créé dans MS Excel. Le graphique est ensuite placé à l'intérieur d'une diapositive PowerPoint. Ce graphique Excel est considéré comme un objet OLE. 

- Un objet OLE peut apparaître sous la forme d'une icône. Dans ce cas, lorsque vous double-cliquez sur l'icône, le graphique s'ouvre dans son application associée (Excel), ou vous êtes invité à sélectionner une application pour ouvrir ou éditer l'objet. 
- Un objet OLE peut afficher des contenus réels, par exemple, le contenu d'un graphique. Dans ce cas, le graphique est activé dans PowerPoint, l'interface du graphique se charge et vous pouvez modifier les données du graphique dans l'application PowerPoint.

[Aspose.Slides pour C++](https://products.aspose.com/slides/cpp/) vous permet d'insérer des objets OLE dans des diapositives sous forme de Cadres d'Objet OLE ([OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)).



## **Ajout de Cadres d'Objet OLE aux Diapositives**

En supposant que vous avez déjà créé un graphique dans Microsoft Excel et que vous souhaitez intégrer ce graphique dans une diapositive sous forme de Cadre d'Objet OLE en utilisant Aspose.Slides pour C++, vous pouvez le faire de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez une référence à la diapositive par son index.
3. Ouvrez le fichier Excel contenant l'objet graphique Excel et enregistrez-le dans `MemoryStream`.
4. Ajoutez le [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) à la diapositive contenant le tableau d'octets et d'autres informations sur l'objet OLE.
5. Écrivez la présentation modifiée sous forme de fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté un graphique à partir d'un fichier Excel à une diapositive sous forme de [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) en utilisant Aspose.Slides pour C++.  
**Remarque** que le constructeur [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_ole_embedded_data_info) prend une extension d'objet intégrable comme second paramètre. Cette extension permet à PowerPoint d'interpréter correctement le type de fichier et de choisir la bonne application pour ouvrir cet objet OLE.

``` cpp
// Le chemin du répertoire des documents.
String dataDir = u"";
// Instancie la classe Presentation qui représente le PPTX
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Accède à la première diapositive
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);
// Charge un fichier excel dans le flux
SharedPtr<MemoryStream> mstream = System::MakeObject<MemoryStream>();

SharedPtr<FileStream> fs = System::MakeObject<FileStream>(dataDir + u"book1.xlsx", FileMode::Open, FileAccess::Read);

ArrayPtr<uint8_t> buf = System::MakeArray<uint8_t>(4096, 0);
while (true)
{
    int32_t bytesRead = fs->Read(buf, 0, buf->get_Length());
    if (bytesRead <= 0)
    {
        break;
    }
    mstream->Write(buf, 0, bytesRead);
}

// Crée un objet de données pour l'intégration
SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(mstream->ToArray(), u"xlsx");
// Ajoute une forme de Cadre d'objet Ole
SharedPtr<IOleObjectFrame> oleObjectFrame = sld->get_Shapes()->AddOleObjectFrame(0.0f, 0.0f, pres->get_SlideSize()->get_Size().get_Width(), pres->get_SlideSize()->get_Size().get_Height(), dataInfo);
// Écrit le fichier PPTX sur le disque
pres->Save(dataDir + u"OleEmbed_out.pptx", SaveFormat::Pptx);
```

## **Accéder aux Cadres d'Objet OLE**
Si un objet OLE est déjà intégré dans une diapositive, vous pouvez facilement trouver ou accéder à cet objet de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).

2. Obtenez la référence de la diapositive en utilisant son index.

3. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame).

   Dans notre exemple, nous avons utilisé le PPTX précédemment créé qui ne contient qu'une seule forme sur la première diapositive.  Nous avons ensuite *casté* cet objet en tant que [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame). C'était le Cadre d'Objet OLE souhaité à accéder.

4. Une fois le Cadre d'Objet OLE accédé, vous pouvez effectuer n'importe quelle opération dessus.

Dans l'exemple ci-dessous, un Cadre d'Objet OLE (un objet graphique Excel intégré dans une diapositive) est accédé, puis ses données de fichier sont écrites dans un fichier Excel :

``` cpp
// Le chemin du répertoire des documents.
const String templatePath = u"../templates/AccessingOLEObjectFrame.pptx";

// Charge la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Accède à la première diapositive
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Cast la forme en OleObjectFrame
SharedPtr<OleObjectFrame> oleObjectFrame = System::AsCast<OleObjectFrame>(sld->get_Shapes()->idx_get(0));

// Lit l'objet OLE et l'écrit sur le disque
if (oleObjectFrame != nullptr)
{
    // Obtient les données de fichier intégrées
    ArrayPtr<uint8_t> data = oleObjectFrame->get_EmbeddedFileData();

    // Obtient l'extension de fichier intégrée
    String fileExtention = oleObjectFrame->get_EmbeddedFileExtension();

    // Crée le chemin pour enregistrer le fichier extrait
    String extractedPath = Path::Combine(GetOutPath(), u"excelFromOLE_out" + fileExtention);

    // Enregistre les données extraites
    SharedPtr<FileStream> fstr = System::MakeObject<FileStream>(extractedPath, FileMode::Create, FileAccess::Write);
    fstr->Write(data, 0, data->get_Length());
}
```

## **Modifier les Données de l'Objet OLE**
Si un objet OLE est déjà intégré dans une diapositive, vous pouvez facilement accéder à cet objet et modifier ses données de cette manière :

1. Ouvrez la présentation souhaitée avec l'objet OLE intégré en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).

2. Obtenez la référence de la diapositive par son index. 

3. Accédez à la forme [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame).

   Dans notre exemple, nous avons utilisé le PPTX précédemment créé qui a une forme sur la première diapositive. Nous avons ensuite *casté* cet objet en tant qu'[OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame). C'était le Cadre d'Objet OLE souhaité à accéder.

4. Une fois le Cadre d'Objet OLE accédé, vous pouvez effectuer n'importe quelle opération dessus.

5. Créez l'objet Workbook et accédez aux données OLE.

6. Accédez à la feuille de calcul souhaitée et modifiez les données.

7. Enregistrez le Workbook mis à jour dans des flux.

8. Changez les données de l'objet OLE à partir des données du flux.

Dans l'exemple ci-dessous, un Cadre d'Objet OLE (un objet graphique Excel intégré dans une diapositive) est accédé, puis ses données de fichier sont modifiées pour changer les données du graphique :

``` cpp
intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> ToCellsMemoryStream(System::ArrayPtr<uint8_t> buffer)
{
    intrusive_ptr<BString> array = new BString(buffer->data_ptr(), buffer->Count());
    auto stream = new Aspose::Cells::Systems::IO::MemoryStream(array);

    return stream;
}

System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}

void ChangeOLEObjectData()
{
    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(GetDataPath() + u"ChangeOLEObjectData.pptx");
    System::SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

    System::SharedPtr<OleObjectFrame> ole;

    // Parcourt toutes les formes pour le cadre Ole
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        if (System::ObjectExt::Is<OleObjectFrame>(shape))
        {
            ole = System::ExplicitCast<OleObjectFrame>(shape);
        }
    }
    
    if (ole != nullptr)
    {
        // Lit les données de l'objet dans le Workbook
        intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> cellsInputStream = ToCellsMemoryStream(ole->get_ObjectData());
        intrusive_ptr<Aspose::Cells::IWorkbook> Wb = Aspose::Cells::Factory::CreateIWorkbook(cellsInputStream);

        // Modifie les données du workbook
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(0,4)->PutValue(u"E");
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(1, 4)->PutValue(12);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(2, 4)->PutValue(14);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(3, 4)->PutValue(15);

        intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
        Wb->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);
        
        // Change les données de l'objet du cadre Ole
        cellsOutputStream->SetPosition(0);
        System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);
        ole->set_ObjectData(msout->ToArray());
        
        pres->Save(GetOutPath() + u"OleEdit_out.pptx", Export::SaveFormat::Pptx);
    }
}
```

## Intégration d'Autres Types de Fichiers dans les Diapositives

En plus des graphiques Excel, Aspose.Slides pour C++ vous permet d'intégrer d'autres types de fichiers dans des diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP en tant qu'objets dans une diapositive. Lorsqu'un utilisateur double-clique sur l'objet inséré, l'objet se lance automatiquement dans le programme pertinant, ou l'utilisateur est dirigé pour sélectionner un programme approprié pour ouvrir l'objet. 

Ce code C++ vous montre comment intégrer HTML et ZIP dans une diapositive :

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto htmlBytes = System::IO::File::ReadAllBytes(u"embedOle.html");

auto dataInfoHtml = System::MakeObject<OleEmbeddedDataInfo>(htmlBytes, u"html");
auto oleFrameHtml = slide->get_Shapes()->AddOleObjectFrame(150.0f, 120.0f, 50.0f, 50.0f, dataInfoHtml);
oleFrameHtml->set_IsObjectIcon(true);
        
auto zipBytes = System::IO::File::ReadAllBytes(u"embedOle.zip");
auto dataInfoZip = System::MakeObject<OleEmbeddedDataInfo>(zipBytes, u"zip");
auto oleFrameZip = slide->get_Shapes()->AddOleObjectFrame(150.0f, 220.0f, 50.0f, 50.0f, dataInfoZip);
oleFrameZip->set_IsObjectIcon(true);
        
pres->Save(u"embeddedOle.pptx", SaveFormat::Pptx);

```

## Définir les Types de Fichiers pour les Objets Intégrés

Lorsque vous travaillez sur des présentations, vous pourriez avoir besoin de remplacer de vieux objets OLE par de nouveaux. Ou vous pourriez avoir besoin de remplacer un objet OLE non pris en charge par un objet pris en charge. 

Aspose.Slides pour C++ vous permet de définir le type de fichier pour un objet intégré. De cette manière, vous pouvez changer les données du cadre OLE ou son extension. 

Ce code C++ vous montre comment définir le type de fichier pour un objet OLE intégré :

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slides()->idx_get(0);
auto oleObjectFrame = System::ExplicitCast<IOleObjectFrame>(slide->get_Shapes()->idx_get(0));
Console::WriteLine(u"L'extension de données intégrées actuelle est : {0}", oleObjectFrame->get_EmbeddedData()->get_EmbeddedFileExtension());

oleObjectFrame->SetEmbeddedData(System::MakeObject<OleEmbeddedDataInfo>(File::ReadAllBytes(u"embedOle.zip"), u"zip"));

pres->Save(u"embeddedChanged.pptx", SaveFormat::Pptx);
```

## Définir des Images d'ICônes et des Titres pour les Objets Intégrés

Après avoir intégré un objet OLE, un aperçu composé d'une image d'icône et d'un titre est ajouté automatiquement. L'aperçu est ce que les utilisateurs voient avant d'accéder ou d'ouvrir l'objet OLE. 

Si vous voulez utiliser une image et un texte spécifiques comme éléments dans l'aperçu, vous pouvez définir l'image d'icône et le titre en utilisant Aspose.Slides pour C++.

Ce code C++ vous montre comment définir l'image d'icône et le titre pour un objet intégré : 

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slide(0);
auto oleObjectFrame = System::ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto oleImage = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
oleObjectFrame->set_SubstitutePictureTitle(u"Mon titre");
oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleObjectFrame->set_IsObjectIcon(false);

pres->Save(u"embeddedOle-newImage.pptx", SaveFormat::Pptx);
```

## **Empêcher un Cadre d'Objet OLE d'être Redimensionné et Repositionné**

Après avoir ajouté un objet OLE lié à une diapositive de présentation, lorsque vous ouvrez la présentation dans PowerPoint, vous pourriez voir un message vous demandant de mettre à jour les liens. Cliquer sur le bouton "Mettre à jour les liens" peut changer la taille et la position du cadre d'objet OLE car PowerPoint met à jour les données de l'objet OLE lié et actualise l'aperçu de l'objet. Pour empêcher PowerPoint de demander la mise à jour des données de l'objet, réglez la méthode `set_UpdateAutomatic` de l'interface [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) sur `false` :

```cpp
oleObjectFrame->set_UpdateAutomatic(false);
```

## Extraire des Fichiers Intégrés

Aspose.Slides pour C++ vous permet d'extraire les fichiers intégrés dans des diapositives en tant qu'objets OLE de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) contenant l'objet OLE que vous souhaitez extraire.
2. Parcourez toutes les formes de la présentation et accédez à la forme [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame).
3. Accédez aux données du fichier intégré depuis le Cadre d'Objet OLE et écrivez-le sur le disque. 

Ce code C++ vous montre comment extraire un fichier intégré dans une diapositive en tant qu'objet OLE :

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slides()->idx_get(0);

for (int32_t index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shapes()->idx_get(index);

    auto oleFrame = System::AsCast<IOleObjectFrame>(shape);

    if (oleFrame != nullptr)
    {
        auto data = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        String extension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        File::WriteAllBytes(String::Format(u"oleFrame{0}{1}", index, extension), data);
    }
}
```