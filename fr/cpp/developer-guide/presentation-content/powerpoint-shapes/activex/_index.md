---
title: Gérer les contrôles ActiveX dans les présentations avec C++
linktitle: ActiveX
type: docs
weight: 80
url: /fr/cpp/activex/
keywords:
  - ActiveX
  - contrôle ActiveX
  - gérer ActiveX
  - ajouter ActiveX
  - modifier ActiveX
  - lecteur multimédia
  - PowerPoint
  - présentation
  - C++
  - Aspose.Slides
description: "Découvrez comment Aspose.Slides pour C++ exploite ActiveX afin d'automatiser et d'améliorer les présentations PowerPoint, offrant aux développeurs un contrôle puissant sur les diapositives."
---

Les controles ActiveX sont utilises dans les presentations. Aspose.Slides pour C++ vous permet de gerer les controles ActiveX, mais leur gestion est un peu plus compliquee et differentes des formes normales de la presentation. A partir d'Aspose.Slides pour C++ 18.1, le composant prend en charge la gestion des controles ActiveX. Pour le moment, vous pouvez acceder aux controles ActiveX deja ajoutes dans votre presentation et les modifier ou les supprimer en utilisant leurs differentes proprietes. Rappelez-vous que les controles ActiveX ne sont pas des formes et ne font pas partie de l'IShapeCollection de la presentation mais de l'IControlCollection distincte. Cet article montre comment travailler avec eux.

## **Modifier un controle ActiveX**

1. Creer une instance de la classe Presentation et chargez la presentation contenant des controles ActiveX.  
2. Obtenez une reference a la diapositive par son indice.  
3. Accedez aux controles ActiveX de la diapositive en accedant a l'IControlCollection.  
4. Accedez au controle ActiveX TextBox1 en utilisant l'objet ControlEx.  
5. Modifiez les differentes proprietes du controle ActiveX TextBox1, y compris le texte, la police, la hauteur de la police et la position du cadre.  
6. Accedez au deuxieme controle d'acces appelle CommandButton1.  
7. Modifiez la legende du bouton, la police et la position.  
8. Deplacez la position des cadres des controles ActiveX.  
9. Enregistrez la presentation modifiee dans un fichier PPTX.

L'extrait de code ci-dessous met a jour les controles ActiveX des diapositives de la presentation comme illustre ci-dessous.
```cpp
// Accès à la présentation avec des contrôles ActiveX
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Accès à la première diapositive de la présentation
auto slide = presentation->get_Slides()->idx_get(0);

// Modification du texte du TextBox
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // Modification de l'image de substitution. PowerPoint remplacera cette image lors de l'activation d'ActiveX, il est donc parfois acceptable de laisser l'image inchangée.
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// Modification de la légende du bouton
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // Modification de la substitution
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// Déplacement des cadres ActiveX de 100 points vers le bas
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// Enregistrer la présentation avec les contrôles ActiveX modifiés
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Suppression des contrôles
slide->get_Controls()->Clear();

// Enregistrement de la présentation avec les contrôles ActiveX supprimés
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```


## **Ajouter un controle ActiveX Media Player**

Les controles ActiveX sont utilises dans les presentations. Aspose.Slides pour C++ vous permet d'ajouter et de gerer les controles ActiveX, mais leur gestion est un peu plus compliquee et differentes des formes normales de la presentation. A partir d'Aspose.Slides pour C++ 18.1, la prise en charge de l'ajout de controles ActiveX Media Player a ete integree a Aspose.Slides. Rappelez-vous que les controles ActiveX ne sont pas des formes et ne font pas partie de l'IShapeCollection de la presentation mais de l'IControlExCollection distincte. Cet article montre comment travailler avec eux. Pour gerer un controle ActiveX Media Player, veuillez suivre les etapes suivantes :

1. Creer une instance de la classe Presentation et chargez la presentation d'exemple contenant des controles ActiveX Media Player.  
2. Creer une instance de la classe Presentation cible et generez une instance de presentation vide.  
3. Clonez la diapositive contenant le controle ActiveX Media Player de la presentation modele vers la presentation cible.  
4. Accedez a la diapositive clonee dans la presentation cible.  
5. Accedez aux controles ActiveX de la diapositive en accedant a l'IControlCollection.  
6. Accedez au controle ActiveX Media Player et definissez le chemin de la video en utilisant ses proprietes.  
7. Enregistrez la presentation dans un fichier PPTX.
```cpp
// Instancier la classe Presentation qui représente le fichier PPTX
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Créer une instance de présentation vide
auto newPresentation = System::MakeObject<Presentation>();

// Supprimer la diapositive par défaut
newPresentation->get_Slides()->RemoveAt(0);

// Cloner la diapositive contenant le contrôle ActiveX Media Player
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Accéder au contrôle ActiveX Media Player et définir le chemin de la vidéo
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Enregistrer la présentation
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Aspose.Slides conserve-t-il les controles ActiveX lors de la lecture et du re-enregistrement s'ils ne peuvent pas etre executes dans le runtime C++ ?**  
Oui. Aspose.Slides les traite comme faisant partie de la presentation et peut lire/modifier leurs proprietes et cadres; l'execution des controles eux-memes n'est pas requise pour les preserver.

**En quoi les controles ActiveX diffèrent-ils des objets OLE dans une presentation ?**  
Les controles ActiveX sont des controles interactifs geres (boutons, zones de texte, lecteur multimedia), tandis que [OLE](/slides/fr/cpp/manage-ole/) designe des objets d'application embarques (par exemple, une feuille de calcul Excel). Ils sont stockes et gestes différemment et possedent des modeles de proprietes differents.

**Les evenements ActiveX et les macros VBA fonctionnent-ils si le fichier a ete modifie par Aspose.Slides ?**  
Aspose.Slides preserve le balisage et les metadonnees existants; cependant, les evenements et macros ne s'executent que dans PowerPoint sous Windows lorsque la securite le permet. La bibliotheque n'execute pas le VBA.