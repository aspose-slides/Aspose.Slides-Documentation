---
title: "Gérer OLE dans les présentations avec C++"
linktitle: "Gérer OLE"
type: docs
weight: 40
url: /fr/cpp/manage-ole/
keywords:
- "Objet OLE"
- "Lien et intégration d'objets"
- "ajouter OLE"
- "intégrer OLE"
- "ajouter objet"
- "intégrer objet"
- "ajouter fichier"
- "intégrer fichier"
- "objet lié"
- "fichier lié"
- "modifier OLE"
- "icône OLE"
- "titre OLE"
- "extraire OLE"
- "extraire objet"
- "extraire fichier"
- "PowerPoint"
- "présentation"
- "C++"
- "Aspose.Slides"
description: "Optimisez la gestion des objets OLE dans PowerPoint et les fichiers OpenDocument avec Aspose.Slides pour C++. Intégrez, mettez à jour et exportez le contenu OLE en toute fluidité."
---
## **Introduction**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) est une technologie Microsoft qui permet de placer des données et des objets créés dans une application dans une autre application via le lien ou l’intégration. 
{{% /alert %}} 

Considérez un graphique créé dans MS Excel. Le graphique est ensuite placé dans une diapositive PowerPoint. Ce graphique Excel est considéré comme un objet OLE. 

- Un objet OLE peut apparaître sous forme d’icône. Dans ce cas, lorsque vous double-cliquez sur l’icône, le graphique s’ouvre dans son application associée (Excel), ou on vous demande de sélectionner une application pour ouvrir ou modifier l’objet. 
- Un objet OLE peut afficher son contenu réel, comme le contenu d’un graphique. Dans ce cas, le graphique est activé dans PowerPoint, l’interface du graphique se charge, et vous pouvez modifier les données du graphique directement dans PowerPoint.

[Aspose.Slides pour C++](https://products.aspose.com/slides/cpp/) permet d’insérer des objets OLE dans des diapositives sous forme de cadres d’objets OLE ([OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)).

## **Ajouter des cadres d’objets OLE aux diapositives**

En supposant que vous avez déjà créé un graphique dans Microsoft Excel et que vous souhaitez l’intégrer dans une diapositive en tant que cadre d’objet OLE à l’aide d’Aspose.Slides pour C++, vous pouvez procéder ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. Obtenez la référence d’une diapositive via son index.  
3. Lisez le fichier Excel en tant que tableau d’octets.  
4. Ajoutez le [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) à la diapositive en incluant le tableau d’octets et les autres informations sur l’objet OLE.  
5. Enregistrez la présentation modifiée au format PPTX.  

Dans l’exemple ci‑dessous, nous avons ajouté un graphique provenant d’un fichier Excel à une diapositive en tant que [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) à l’aide d’Aspose.Slides pour C++.  
**Note** que le constructeur [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) accepte une extension d’objet intégrable comme deuxième paramètre. Cette extension permet à PowerPoint d’interpréter correctement le type de fichier et de choisir l’application appropriée pour ouvrir cet objet OLE.  

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

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

### **Ajouter des cadres d’objets OLE liés**

Aspose.Slides pour C++ vous permet d’ajouter un [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) sans intégrer les données, mais uniquement avec un lien vers le fichier.

Ce code C++ montre comment ajouter un [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) avec un fichier Excel lié à une diapositive :

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Ajouter un cadre d'objet OLE avec un fichier Excel lié.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Accéder aux cadres d’objets OLE**

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez le retrouver ou y accéder de cette façon :

1. Chargez une présentation contenant l’objet OLE intégré en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. Obtenez la référence de la diapositive en utilisant son index.  
3. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/).  
   Dans notre exemple, nous utilisons le PPTX précédemment créé qui ne comporte qu’une seule forme sur la première diapositive. Nous *castons* ensuite cet objet en tant que [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). Il s’agit du cadre d’objet OLE désiré.  
4. Une fois le cadre d’objet OLE accessible, vous pouvez effectuer toute opération dessus.  

Dans l’exemple ci‑dessous, un cadre d’objet OLE (un objet graphique Excel intégré dans une diapositive) et ses données de fichier sont accessibles.

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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

Ce code C++ montre comment vérifier si un objet OLE est lié puis obtenir le chemin du fichier lié :

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

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

{{% alert color="info" title="Note" %}}
Dans cette section, l’exemple de code ci‑dessous utilise [Aspose.Cells pour C++](https://docs.aspose.com/cells/cpp/).  
{{% /alert %}}

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez facilement accéder à cet objet et modifier ses données ainsi :

1. Chargez une présentation contenant l’objet OLE intégré en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. Obtenez la référence de la diapositive via son index.  
3. Accédez à la forme [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/).  
   Dans notre exemple, nous utilisons le PPTX précédemment créé qui possède une forme sur la première diapositive. Nous *castons* ensuite cet objet en tant que [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). Il s’agit du cadre d’objet OLE désiré.  
4. Une fois le cadre d’objet OLE accessible, vous pouvez effectuer toute opération dessus.  
5. Créez un objet `Workbook` et accédez aux données OLE.  
6. Accédez à la `Worksheet` souhaitée et modifiez les données.  
7. Enregistrez le `Workbook` mis à jour dans un flux.  
8. Remplacez les données de l’objet OLE à partir du flux.  

Dans l’exemple ci‑dessous, un cadre d’objet OLE (un objet graphique Excel intégré dans une diapositive) est accédé et ses données de fichier sont modifiées pour mettre à jour les données du graphique.

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Aspose.Cells for C++ doit être démarré avant que ses types ne soient utilisés.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Lire les données de l'objet OLE sous forme d'objet Workbook.
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

Aspose::Cells::Cleanup();
```

## **Intégrer d’autres types de fichiers dans les diapositives**

Outre les graphiques Excel, Aspose.Slides pour C++ vous permet d’intégrer d’autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP en tant qu’objets. Lorsque l’utilisateur double‑clique sur l’objet inséré, il s’ouvre automatiquement dans le programme approprié, ou l’utilisateur est invité à choisir un programme adéquat pour l’ouvrir.  

Ce code C++ montre comment intégrer HTML et ZIP dans une diapositive :

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

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

## **Définir le type de fichier pour les objets intégrés**

Lors de la manipulation de présentations, il peut être nécessaire de remplacer d’anciens objets OLE par de nouveaux ou de remplacer un objet OLE non pris en charge par un objet pris en charge. Aspose.Slides pour C++ vous permet de définir le type de fichier d’un objet intégré, ce qui vous permet de mettre à jour les données du cadre OLE ou son extension.  

Ce code C++ montre comment définir le type de fichier d’un objet OLE intégré sur `zip` :

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

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

## **Définir les images d’icône et les titres pour les objets intégrés**

Après l’intégration d’un objet OLE, un aperçu constitué d’une image d’icône est ajouté automatiquement. Cet aperçu est ce que voient les utilisateurs avant d’accéder ou d’ouvrir l’objet OLE. Si vous souhaitez utiliser une image et un texte spécifiques comme éléments de l’aperçu, vous pouvez définir l’image d’icône et le titre à l’aide d’Aspose.Slides pour C++.  

Ce code C++ montre comment définir l’image d’icône et le titre pour un objet intégré :

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Ajouter une image aux ressources de la présentation.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Définir un titre et l'image pour l'aperçu OLE.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Empêcher le redimensionnement et le repositionnement d’un cadre d’objet OLE**

Après avoir ajouté un objet OLE lié à une diapositive de présentation, lorsque vous ouvrez la présentation dans PowerPoint, un message peut vous inviter à mettre à jour les liens. Cliquer sur le bouton « Update Links » peut modifier la taille et la position du cadre d’objet OLE parce que PowerPoint met à jour les données à partir de l’objet OLE lié et rafraîchit l’aperçu de l’objet. Pour empêcher PowerPoint de demander la mise à jour des données de l’objet, appelez la méthode [set_UpdateAutomatic](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/set_updateautomatic/) de l’interface [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) avec `false` :

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **Extraire les fichiers intégrés**

Aspose.Slides pour C++ vous permet d’extraire les fichiers intégrés dans les diapositives en tant qu’objets OLE de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) contenant les objets OLE que vous souhaitez extraire.  
2. Parcourez toutes les formes de la présentation et accédez aux formes [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/).  
3. Accédez aux données des fichiers intégrés à partir des cadres d’objet OLE et enregistrez‑les sur le disque.  

Ce code C++ montre comment extraire les fichiers intégrés dans une diapositive en tant qu’objets OLE :

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

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

**Le contenu OLE sera‑t‑il rendu lors de l’exportation des diapositives vers PDF/images ?**

Ce qui est visible sur la diapositive est rendu — l’icône/l’image de substitution (aperçu). Le contenu OLE « live » n’est pas exécuté lors du rendu. Si nécessaire, définissez votre propre image d’aperçu pour garantir l’aspect attendu dans le PDF exporté.  

Pour également conserver le fichier intégré comme pièce jointe PDF, appelez [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) avec `true`. Cette option est désactivée par défaut. Pour un exemple et des instructions sur la vérification de la pièce jointe, consultez [Preserve Embedded OLE Files as PDF Attachments](/slides/fr/cpp/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).  

**Comment verrouiller un objet OLE sur une diapositive afin que les utilisateurs ne puissent pas le déplacer/modifier dans PowerPoint ?**

Verrouillez la forme : Aspose.Slides fournit des [verrous au niveau de la forme](/slides/fr/cpp/applying-protection-to-presentation/). Ce n’est pas du chiffrement, mais cela empêche efficacement les modifications et déplacements accidentels.  

**Pourquoi un objet Excel lié « saute » ou change de taille lorsque j’ouvre la présentation ?**

PowerPoint peut rafraîchir l’aperçu de l’OLE lié. Pour un affichage stable, suivez les bonnes pratiques du [Working Solution for Worksheet Resizing](/slides/fr/cpp/working-solution-for-worksheet-resizing/) — soit ajustez le cadre à la plage, soit redimensionnez la plage à un cadre fixe et définissez une image de substitution appropriée.  

**Les chemins relatifs des objets OLE liés sont‑ils conservés au format PPTX ?**

Dans PPTX, les informations de « chemin relatif » ne sont pas disponibles — seul le chemin complet est conservé. Les chemins relatifs existent dans le format PPT plus ancien. Pour la portabilité, privilégiez des chemins absolus fiables/URI accessibles ou l’intégration.  