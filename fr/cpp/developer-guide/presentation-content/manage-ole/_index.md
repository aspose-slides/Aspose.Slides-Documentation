---
title: Gérer OLE dans les présentations avec C++
linktitle: Gérer OLE
type: docs
weight: 40
url: /fr/cpp/manage-ole/
keywords:
- objet OLE
- Liaison et intégration d'objets
- ajouter OLE
- intégrer OLE
- ajouter objet
- intégrer objet
- ajouter fichier
- intégrer fichier
- objet lié
- fichier lié
- modifier OLE
- icône OLE
- titre OLE
- extraire OLE
- extraire objet
- extraire fichier
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Optimisez la gestion des objets OLE dans PowerPoint et les fichiers OpenDocument avec Aspose.Slides pour C++. Intégrez, mettez à jour et exportez le contenu OLE sans effort."
---

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) est une technologie Microsoft qui permet aux données et aux objets créés dans une application d'être placés dans une autre application via le lien ou l'embarquement. 

{{% /alert %}} 

Considérez un graphique créé dans MS Excel. Le graphique est ensuite placé dans une diapositive PowerPoint. Ce graphique Excel est considéré comme un objet OLE. 

- Un objet OLE peut apparaître sous forme d'icône. Dans ce cas, lorsque vous double-cliquez sur l'icône, le graphique s'ouvre dans son application associée (Excel), ou l’on vous demande de sélectionner une application pour ouvrir ou modifier l'objet. 
- Un objet OLE peut afficher son contenu réel, comme le contenu d'un graphique. Dans ce cas, le graphique est activé dans PowerPoint, l'interface du graphique se charge, et vous pouvez modifier les données du graphique dans PowerPoint.

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) vous permet d'insérer des objets OLE dans les diapositives en tant que cadres d'objet OLE ([OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)).

## **Ajouter des cadres d'objet OLE aux diapositives**

En supposant que vous avez déjà créé un graphique dans Microsoft Excel et que vous souhaitez l'intégrer dans une diapositive en tant que cadre d'objet OLE à l'aide d'Aspose.Slides for C++, vous pouvez procéder ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d'une diapositive via son index.
3. Lisez le fichier Excel sous forme de tableau d'octets.
4. Ajoutez le [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) à la diapositive en incluant le tableau d'octets et les autres informations concernant l'objet OLE.
5. Enregistrez la présentation modifiée au format PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté un graphique d’un fichier Excel à une diapositive en tant que [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) à l’aide d’Aspose.Slides for C++. **Note** que le constructeur [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) prend une extension d’objet embarquable comme deuxième paramètre. Cette extension permet à PowerPoint d’interpréter correctement le type de fichier et de choisir l’application appropriée pour ouvrir cet objet OLE.
``` cpp
auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


### **Ajouter des cadres d'objet OLE liés**

Aspose.Slides for C++ vous permet d’ajouter un [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) sans embarquer les données, mais uniquement avec un lien vers le fichier.

Ce code C++ vous montre comment ajouter un [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) avec un fichier Excel lié à une diapositive :
```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Ajouter un cadre d'objet OLE avec un fichier Excel lié.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Accéder aux cadres d'objet OLE**

Si un objet OLE est déjà embarqué dans une diapositive, vous pouvez facilement le trouver ou y accéder de cette manière :

1. Chargez une présentation contenant l’objet OLE embarqué en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence de la diapositive en utilisant son index.
3. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/).
   Dans notre exemple, nous avons utilisé le PPTX créé précédemment qui ne contient qu’une forme sur la première diapositive. Nous avons ensuite *casté* cet objet en tant que [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). C’était le cadre d’objet OLE souhaité à accéder.
4. Une fois le cadre d’objet OLE accédé, vous pouvez effectuer toute opération dessus.

Dans l’exemple ci‑dessus, un cadre d’objet OLE (un objet graphique Excel embarqué dans une diapositive) et ses données de fichier sont accessibles.
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Obtenir les données du fichier intégré.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // Obtenir l'extension du fichier intégré.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```


### **Accéder aux propriétés du cadre d’objet OLE lié**

Aspose.Slides vous permet d’accéder aux propriétés d’un cadre d’objet OLE lié.

Ce code C++ vous montre comment vérifier si un objet OLE est lié puis obtenir le chemin du fichier lié :
```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Vérifier si l'objet OLE est lié.
    if (oleFrame->get_IsObjectLink())
    {
        // Afficher le chemin complet du fichier lié.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Afficher le chemin relatif du fichier lié s'il est présent.
        // Seules les présentations PPT peuvent contenir le chemin relatif.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```


## **Modifier les données d’un objet OLE** 

{{% alert color="primary" %}} 

Dans cette section, l’exemple de code ci‑dessous utilise [Aspose.Cells for C++](/cells/cpp/).

{{% /alert %}}

Si un objet OLE est déjà embarqué dans une diapositive, vous pouvez facilement accéder à cet objet et modifier ses données de cette manière :

1. Chargez une présentation contenant l’objet OLE embarqué en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence de la diapositive via son index.
3. Accédez à la forme [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/).
   Dans notre exemple, nous avons utilisé le PPTX créé précédemment qui possède une forme sur la première diapositive. Nous avons ensuite *casté* cet objet en tant que [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). C’était le cadre d’objet OLE souhaité à accéder.
4. Une fois le cadre d’objet OLE accédé, vous pouvez effectuer toute opération dessus.
5. Créez un objet `Workbook` et accédez aux données OLE.
6. Accédez à la `Worksheet` souhaitée et modifiez les données.
7. Enregistrez le `Workbook` mis à jour dans un flux.
8. Modifiez les données de l’objet OLE à partir du flux.

Dans l’exemple ci‑dessus, un cadre d’objet OLE (un objet graphique Excel embarqué dans une diapositive) est accédé, et ses données de fichier sont modifiées pour mettre à jour les données du graphique.
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Obtenir la première forme en tant que cadre d'objet OLE.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Lire les données de l'objet OLE en tant qu'objet Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Modifier les données du classeur.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // Modifier les données de l'objet du cadre OLE.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **Embarquer d’autres types de fichiers dans les diapositives**

En plus des graphiques Excel, Aspose.Slides for C++ vous permet d’embarquer d’autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP en tant qu’objets. Lorsqu’un utilisateur double-clique sur l’objet inséré, il s’ouvre automatiquement dans le programme correspondant, ou l’utilisateur est invité à choisir un programme approprié pour l’ouvrir.

Ce code C++ vous montre comment embarquer HTML et ZIP dans une diapositive :
``` cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Définir les types de fichiers pour les objets embarqués**

Lors de la manipulation de présentations, il peut être nécessaire de remplacer d’anciens objets OLE par de nouveaux ou de remplacer un objet OLE non pris en charge par un objet pris en charge. Aspose.Slides for C++ vous permet de définir le type de fichier d’un objet embarqué, ce qui vous permet de mettre à jour les données du cadre OLE ou son extension.

Ce code C++ vous montre comment définir le type de fichier d’un objet OLE embarqué sur `zip` :
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Modifier le type de fichier en ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Définir les images d’icône et les titres pour les objets embarqués**

Après avoir embarqué un objet OLE, un aperçu composé d’une image d’icône est ajouté automatiquement. Cet aperçu est ce que les utilisateurs voient avant d’accéder ou d’ouvrir l’objet OLE. Si vous souhaitez utiliser une image et un texte spécifiques comme éléments de l’aperçu, vous pouvez définir l’image d’icône et le titre à l’aide d’Aspose.Slides for C++.

Ce code C++ vous montre comment définir l’image d’icône et le titre pour un objet embarqué : 
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Ajouter une image aux ressources de la présentation.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Définir le titre et l'image pour l'aperçu OLE.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Empêcher un cadre d’objet OLE d’être redimensionné et repositionné**

Après avoir ajouté un objet OLE lié à une diapositive de présentation, lorsque vous ouvrez la présentation dans PowerPoint, vous pouvez voir un message vous demandant de mettre à jour les liens. Cliquer sur le bouton "Update Links" peut modifier la taille et la position du cadre d’objet OLE car PowerPoint met à jour les données de l’objet OLE lié et rafraîchit l’aperçu de l’objet. Pour empêcher PowerPoint de proposer de mettre à jour les données de l’objet, définissez la méthode `set_UpdateAutomatic` de l’interface [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) sur `false` :
```cpp
oleFrame->set_UpdateAutomatic(false);
```


## **Extraire les fichiers embarqués**

Aspose.Slides for C++ vous permet d’extraire les fichiers embarqués dans les diapositives sous forme d’objets OLE de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) contenant les objets OLE que vous souhaitez extraire.
2. Parcourez toutes les formes de la présentation et accédez aux formes [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/).
3. Accédez aux données des fichiers embarqués à partir des cadres d’objet OLE et écrivez-les sur le disque.

Ce code C++ vous montre comment extraire les fichiers embarqués dans une diapositive sous forme d’objets OLE :
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```


## **FAQ**

**Le contenu OLE sera-t-il rendu lors de l’exportation des diapositives vers PDF/images ?**

Ce qui est visible sur la diapositive est rendu — l’icône ou l’image de remplacement (aperçu). Le contenu OLE « live » n’est pas exécuté lors du rendu. Si nécessaire, définissez votre propre image d’aperçu pour garantir l’apparence attendue dans le PDF exporté.

**Comment puis‑je verrouiller un objet OLE sur une diapositive afin que les utilisateurs ne puissent pas le déplacer/modifier dans PowerPoint ?**

Verrouillez la forme : Aspose.Slides fournit des [verrous au niveau de la forme](/slides/fr/cpp/applying-protection-to-presentation/). Ce n’est pas un chiffrement, mais cela empêche efficacement les modifications et déplacements accidentels.

**Pourquoi un objet Excel lié « saute » ou change de taille lorsque j’ouvre la présentation ?**

PowerPoint peut rafraîchir l’aperçu de l’OLE lié. Pour une apparence stable, suivez les pratiques de la [Solution fonctionnelle pour le redimensionnement des feuilles de calcul](/slides/fr/cpp/working-solution-for-worksheet-resizing/) — ajustez le cadre à la plage, ou redimensionnez la plage à un cadre fixe et définissez une image de substitution appropriée.

**Les chemins relatifs des objets OLE liés seront‑ils conservés dans le format PPTX ?**

Dans le PPTX, l’information « chemin relatif » n’est pas disponible — seul le chemin complet l’est. Les chemins relatifs se trouvent dans l’ancien format PPT. Pour la portabilité, privilégiez des chemins absolus fiables/URI accessibles ou l’embarquement.