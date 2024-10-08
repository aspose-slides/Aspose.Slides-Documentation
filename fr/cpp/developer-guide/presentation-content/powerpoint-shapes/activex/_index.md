---
title: ActiveX
type: docs
weight: 80
url: /fr/cpp/activex/
---


Les contrôles ActiveX sont utilisés dans les présentations. Aspose.Slides pour C++ vous permet de gérer les contrôles ActiveX, mais leur gestion est un peu plus délicate et différente de celle des formes de présentation normales. À partir d'Aspose.Slides pour C++ 18.1, le composant prend en charge la gestion des contrôles ActiveX. Pour le moment, vous pouvez accéder au contrôle ActiveX déjà ajouté dans votre présentation et le modifier ou le supprimer en utilisant ses différentes propriétés. N'oubliez pas que les contrôles ActiveX ne sont pas des formes et ne font pas partie de l'IShapeCollection de la présentation mais du IControlCollection séparé. Cet article montre comment travailler avec eux.

## **Modifier le contrôle ActiveX**
Pour gérer un simple contrôle ActiveX comme une zone de texte et un bouton de commande simple sur une diapositive :

1. Créez une instance de la classe Presentation et chargez la présentation avec des contrôles ActiveX.
1. Obtenez une référence à la diapositive par son indice.
1. Accédez aux contrôles ActiveX dans la diapositive en accédant au IControlCollection.
1. Accédez au contrôle ActiveX TextBox1 en utilisant l'objet ControlEx.
1. Modifiez les différentes propriétés du contrôle ActiveX TextBox1, y compris le texte, la police, la hauteur de la police et la position du cadre.
1. Accédez au deuxième contrôle d'accès appelé CommandButton1.
1. Modifiez la légende du bouton, la police et la position.
1. Déplacez la position des cadres des contrôles ActiveX.
1. Écrivez la présentation modifiée dans un fichier PPTX.

L'extrait de code ci-dessous met à jour les contrôles ActiveX sur les diapositives de la présentation comme montré ci-dessous.

``` cpp
// Accéder à la présentation avec des contrôles ActiveX
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Accéder à la première diapositive de la présentation
auto slide = presentation->get_Slides()->idx_get(0);

// changer le texte de TextBox
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Texte modifié";
    control->get_Properties()->idx_set(u"Value", newText);

    // changer l'image de substitution. Powerpoint remplacera cette image lors de l'activation ActiveX, donc parfois il est acceptable de laisser l'image inchangée.
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

// changer la légende du bouton
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // changer la substitution
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

// Déplacer les cadres ActiveX de 100 points vers le bas
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// Enregistrer la présentation avec les contrôles ActiveX modifiés
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Maintenant, supprimer les contrôles
slide->get_Controls()->Clear();

// Enregistrer la présentation avec les contrôles ActiveX effacés
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **Ajouter un contrôle ActiveX Media Player**
Les contrôles ActiveX sont utilisés dans les présentations. Aspose.Slides pour C++ vous permet d'ajouter et de gérer des contrôles ActiveX, mais leur gestion est un peu plus délicate et différente de celle des formes de présentation normales. À partir d'Aspose.Slides pour C++ 18.1, le support pour ajouter le contrôle ActiveX Media Player a été ajouté dans Aspose.Slides. N'oubliez pas que les contrôles ActiveX ne sont pas des formes et ne font pas partie de l'IShapeCollection de la présentation mais du IControlExCollection séparé. Cet article montre comment travailler avec eux. Pour gérer un contrôle ActiveX Media Player, veuillez effectuer les étapes suivantes :

1. Créez une instance de la classe Presentation et chargez la présentation d'exemple avec des contrôles ActiveX Media Player.
1. Créez une instance de la classe Presentation cible et générez une instance de présentation vide.
1. Clonez la diapositive contenant le contrôle ActiveX Media Player dans la présentation modèle vers la présentation cible.
1. Accédez à la diapositive clonée dans la présentation cible.
1. Accédez aux contrôles ActiveX dans la diapositive en accédant au IControlCollection.
1. Accédez au contrôle ActiveX Media Player et définissez le chemin de la vidéo en utilisant ses propriétés.
1. Enregistrez la présentation dans un fichier PPTX.

``` cpp
// Instancier la classe Presentation qui représente le fichier PPTX
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Créer une instance de présentation vide
auto newPresentation = System::MakeObject<Presentation>();

// Supprimer la diapositive par défaut
newPresentation->get_Slides()->RemoveAt(0);

// Cloner la diapositive avec le contrôle ActiveX Media Player
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Accéder au contrôle ActiveX Media Player et définir le chemin de la vidéo
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Enregistrer la Présentation
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```