---
title: Définir la légende de l'icône OLE
type: docs
weight: 110
url: /fr/cpp/set-caption-to-ole-icon/
---

De nouvelles méthodes **get_SubstitutePictureTitle()** et **set_SubstitutePictureTitle()** ont été ajoutées aux classes **IOleObjectFrame** et **OleObjectFrame**. Cela permet d'obtenir, de définir ou de changer la légende d'une icône OLE. L'extrait de code ci-dessous montre un exemple de création d'un objet Excel et de définition de sa légende.

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Ajouter un objet OLE à la diapositive
auto allBytes = System::IO::File::ReadAllBytes(u"oleSourceFile.xlsx");
auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(allBytes, "xlsx");

auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);
    
// Ajouter une image à la collection d'images de la présentation
auto image = Images::FromFile(u"oleIconFile.ico");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Définir l'image comme une icône pour l'objet OLE
oleFrame->set_IsObjectIcon(true);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(ppImage);

// Définir une légende pour l'icône OLE
oleFrame->set_SubstitutePictureTitle(u"Exemple de légende");
```